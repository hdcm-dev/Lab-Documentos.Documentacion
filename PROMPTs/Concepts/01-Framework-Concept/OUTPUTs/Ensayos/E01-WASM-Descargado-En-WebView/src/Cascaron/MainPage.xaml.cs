using Cascaron.E01;

namespace Cascaron;

public partial class MainPage : ContentPage
{
	bool _iniciado;

	public MainPage()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		if (_iniciado) return;
		_iniciado = true;
		Bitacora.Log("main-page-appearing");

		string resultado;
		try
		{
			resultado = await new Actualizador().ActualizarAsync();
		}
		catch (Exception ex)
		{
			resultado = "error del actualizador: " + ex.GetType().Name + ": " + ex.Message;
		}
		Bitacora.Log("actualizador: " + resultado);
		Estado.Text = "E01 · " + resultado + " · instalada: " + (Actualizador.VersionInstalada() ?? "ninguna");

		// El WebView se crea DESPUÉS de actualizar: así carga la versión recién activada.
		var hwv = new HybridWebView { HybridRoot = "semilla", DefaultFile = "index.html" };
		hwv.WebResourceRequested += ServidorDeContenido.AlPedirRecurso;
		hwv.SetInvokeJavaScriptTarget(new PuenteNativo());
		Contenedor.Children.Add(hwv);
		Bitacora.Log("hybridwebview-agregado");
	}
}
