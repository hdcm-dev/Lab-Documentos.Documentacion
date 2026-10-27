namespace Cascaron.E01;

/// <summary>
/// Sirve al HybridWebView los archivos de content/current interceptando las requests (WebResourceRequested, .NET 10).
/// Si el archivo no existe en current, no se maneja: la request sigue al comportamiento por defecto del control
/// (HybridRoot embebido, _framework/hybridwebview.js y el canal __hwvInvokeDotNet del puente).
/// </summary>
public static class ServidorDeContenido
{
	static int _contador;

	public static void AlPedirRecurso(object? sender, WebViewWebResourceRequestedEventArgs e)
	{
		var n = Interlocked.Increment(ref _contador);
		var uri = e.Uri;
		var raiz = Actualizador.DirCurrent;
		var ruta = Uri.UnescapeDataString(uri.AbsolutePath).TrimStart('/');
		if (ruta.Length == 0) ruta = "index.html";

		string? completo = null;
		if (Directory.Exists(raiz) && !ruta.StartsWith("__hwv", StringComparison.Ordinal))
		{
			var raizCompleta = Path.GetFullPath(raiz) + Path.DirectorySeparatorChar;
			var candidato = Path.GetFullPath(Path.Combine(raiz, ruta));
			if (candidato.StartsWith(raizCompleta, StringComparison.Ordinal) && File.Exists(candidato))
				completo = candidato;
		}

		if (completo is null)
		{
			if (n <= 80) Bitacora.Log($"req#{n} {e.Method} {uri} → sin manejar (por defecto)");
			return;
		}

		e.Handled = true;
		e.SetResponse(200, "OK", TipoMime(completo), File.OpenRead(completo));
		if (n <= 80) Bitacora.Log($"req#{n} {e.Method} {uri} → content/current/{ruta}");
	}

	static string TipoMime(string archivo) => Path.GetExtension(archivo).ToLowerInvariant() switch
	{
		".html" => "text/html",
		".js" => "text/javascript",
		".mjs" => "text/javascript",
		".css" => "text/css",
		".wasm" => "application/wasm",
		".json" => "application/json",
		".dat" => "application/octet-stream",
		".png" => "image/png",
		".svg" => "image/svg+xml",
		".ico" => "image/x-icon",
		".woff2" => "font/woff2",
		_ => "application/octet-stream",
	};
}
