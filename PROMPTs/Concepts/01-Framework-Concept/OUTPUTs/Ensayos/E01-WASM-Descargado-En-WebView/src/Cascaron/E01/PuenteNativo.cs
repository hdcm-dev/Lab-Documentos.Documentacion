using System.Text.Json;

namespace Cascaron.E01;

/// <summary>Objeto destino de window.HybridWebView.InvokeDotNet (puente JS → C#).</summary>
public sealed class PuenteNativo
{
	public string DeviceInfo()
	{
		var info = new
		{
			modulo = "device.info",
			fabricante = Microsoft.Maui.Devices.DeviceInfo.Current.Manufacturer,
			modelo = Microsoft.Maui.Devices.DeviceInfo.Current.Model,
			plataforma = Microsoft.Maui.Devices.DeviceInfo.Current.Platform.ToString(),
			version = Microsoft.Maui.Devices.DeviceInfo.Current.VersionString,
			contenido = Actualizador.VersionInstalada(),
		};
		var json = JsonSerializer.Serialize(info);
		Bitacora.Log("puente DeviceInfo → " + json);
		return json;
	}

	public void Marca(string nombre, int perfMs)
	{
		Bitacora.Log($"js-marca '{nombre}' perf.now={perfMs}ms");
	}
}
