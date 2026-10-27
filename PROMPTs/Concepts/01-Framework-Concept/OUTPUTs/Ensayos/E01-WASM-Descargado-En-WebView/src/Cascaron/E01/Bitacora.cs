namespace Cascaron.E01;

/// <summary>Registro a logcat con la etiqueta E01 y el tiempo desde el arranque del proceso.</summary>
public static class Bitacora
{
	public static long MsDesdeArranque()
	{
#if ANDROID
		return Android.OS.SystemClock.ElapsedRealtime() - Android.OS.Process.StartElapsedRealtime;
#else
		return Environment.TickCount64;
#endif
	}

	public static void Log(string mensaje)
	{
		var linea = $"t={MsDesdeArranque()}ms {mensaje}";
#if ANDROID
		Android.Util.Log.Info("E01", linea);
#else
		System.Diagnostics.Debug.WriteLine("E01 " + linea);
#endif
	}
}
