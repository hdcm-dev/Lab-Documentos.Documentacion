using System.IO.Compression;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.Json;

namespace Cascaron.E01;

/// <summary>
/// Descargador mínimo del ensayo: manifest.json → zip a staging → sha256 → descomprimir → mover a current.
/// Sin firma (fuera del alcance de E01): sólo verifica el hash publicado en el manifiesto.
/// </summary>
public sealed class Actualizador
{
	public static string Raiz => Path.Combine(FileSystem.AppDataDirectory, "content");
	public static string DirCurrent => Path.Combine(Raiz, "current");
	public static string DirPrevious => Path.Combine(Raiz, "previous");
	public static string DirStaging => Path.Combine(Raiz, "staging");

	public static string Servidor =>
		typeof(Actualizador).Assembly.GetCustomAttributes<AssemblyMetadataAttribute>()
			.FirstOrDefault(a => a.Key == "ServidorContenido")?.Value ?? "http://10.0.2.2:8099";

	public static string? VersionInstalada()
	{
		var f = Path.Combine(DirCurrent, ".version");
		return File.Exists(f) ? File.ReadAllText(f).Trim() : null;
	}

	sealed record Manifiesto(string version, string archivo, string sha256, long tamano);

	public async Task<string> ActualizarAsync()
	{
		using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(30) };
		var urlManifiesto = Servidor.TrimEnd('/') + "/manifest.json";
		Bitacora.Log("manifiesto: GET " + urlManifiesto);
		Manifiesto? m;
		try
		{
			using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
			var json = await http.GetStringAsync(urlManifiesto, cts.Token);
			m = JsonSerializer.Deserialize<Manifiesto>(json);
		}
		catch (Exception ex)
		{
			return "sin manifiesto (" + ex.GetType().Name + ": " + ex.Message + "), se usa lo instalado";
		}
		if (m is null) return "manifiesto vacío";

		var instalada = VersionInstalada();
		if (instalada == m.version) return "al día (" + m.version + ")";

		Directory.CreateDirectory(DirStaging);
		var zip = Path.Combine(DirStaging, m.version + ".zip");
		var sw = System.Diagnostics.Stopwatch.StartNew();
		using (var resp = await http.GetAsync(Servidor.TrimEnd('/') + "/" + m.archivo, HttpCompletionOption.ResponseHeadersRead))
		{
			resp.EnsureSuccessStatusCode();
			await using var fs = File.Create(zip);
			await resp.Content.CopyToAsync(fs);
		}
		var tDescarga = sw.ElapsedMilliseconds;

		string hash;
		await using (var fs = File.OpenRead(zip))
			hash = Convert.ToHexString(await SHA256.HashDataAsync(fs)).ToLowerInvariant();
		var tamano = new FileInfo(zip).Length;
		Bitacora.Log($"descarga {m.archivo} {tamano} bytes en {tDescarga} ms, sha256={hash}");
		if (!string.Equals(hash, m.sha256, StringComparison.OrdinalIgnoreCase))
		{
			File.Delete(zip);
			return "RECHAZADO: sha256 no coincide (esperado " + m.sha256 + ", obtenido " + hash + ")";
		}

		var destinoStaging = Path.Combine(DirStaging, m.version);
		if (Directory.Exists(destinoStaging)) Directory.Delete(destinoStaging, true);
		sw.Restart();
		ZipFile.ExtractToDirectory(zip, destinoStaging);
		File.WriteAllText(Path.Combine(destinoStaging, ".version"), m.version);
		File.Delete(zip);
		var tDescomp = sw.ElapsedMilliseconds;

		// Activación: current → previous, staging/vN → current (renombres en el mismo volumen).
		if (Directory.Exists(DirPrevious)) Directory.Delete(DirPrevious, true);
		if (Directory.Exists(DirCurrent)) Directory.Move(DirCurrent, DirPrevious);
		Directory.Move(destinoStaging, DirCurrent);
		Bitacora.Log($"activada {m.version} (antes {instalada ?? "ninguna"}); descomprimir {tDescomp} ms");
		return "instalada " + m.version + " (antes " + (instalada ?? "ninguna") + ")";
	}
}
