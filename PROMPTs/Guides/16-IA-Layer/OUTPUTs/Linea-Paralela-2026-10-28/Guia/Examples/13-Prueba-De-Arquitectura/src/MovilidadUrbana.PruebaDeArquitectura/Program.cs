using MovilidadUrbana.ApiWeb.Infrastructure.Persistence;
using MovilidadUrbana.ApiWeb.Sessions;
using MovilidadUrbana.PruebaDeArquitectura;

// La API del caso base con la capa de IA agregada. Este ejemplo no necesita levantarla: lo que enseña
// está en la prueba de arquitectura (tests/), que inspecciona lo compilado.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AgregarServicios(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();
DatabaseInitializer.Initialize(app.Services);
app.UseMiddleware<SessionHeaderMiddleware>();
app.MapControllers();
app.Run();
