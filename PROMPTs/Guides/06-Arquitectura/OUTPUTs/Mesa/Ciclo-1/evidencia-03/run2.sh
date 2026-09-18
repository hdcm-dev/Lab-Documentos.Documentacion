cd /w/g
dotnet new webapi -n Api --use-controllers >/dev/null
cd Api
dotnet add package MediatR 2>&1 | grep -E "PackageReference|error" | head -3
rm -f Controllers/WeatherForecastController.cs WeatherForecast.cs
cat > Guia.cs <<'CS'
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
public class DomainException(string m) : Exception(m);
public class Producto
{
    public Guid Id { get; private set; }
    public string Nombre { get; private set; } = "";
    public decimal Precio { get; private set; }
    public bool Activo { get; private set; }
    private Producto() { }
    public static Producto Create(string nombre, decimal precio)
    {
        if (precio <= 0) throw new DomainException("El precio debe ser mayor a cero.");
        return new Producto { Id = Guid.NewGuid(), Nombre = nombre, Precio = precio, Activo = true };
    }
}
public record ObtenerProductosQuery() : IRequest<List<ProductoResponseDto>>;
public record CrearProductoCommand(string Nombre, decimal Precio) : IRequest<Guid>;
public record ProductoResponseDto(Guid Id, string Nombre, decimal Precio, bool Activo);
public record CrearProductoRequestDto(string Nombre, decimal Precio);

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductosController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var resultado = await _mediator.Send(new ObtenerProductosQuery(), ct);
        return Ok(resultado);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CrearProductoCommand command, CancellationToken ct)
    {
        var id = await _mediator.Send(command, ct);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
}

public interface IProductoApiService
{
    Task<List<ProductoResponseDto>> GetAllAsync(CancellationToken ct = default);
    Task<ProductoResponseDto?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<Guid> CreateAsync(CrearProductoRequestDto request, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
}
public class ProductoApiService : IProductoApiService
{
    private readonly HttpClient _http;
    public ProductoApiService(HttpClient http) => _http = http;
    public async Task<List<ProductoResponseDto>> GetAllAsync(CancellationToken ct = default)
    {
        return await _http.GetFromJsonAsync<List<ProductoResponseDto>>("api/productos", ct)
               ?? new List<ProductoResponseDto>();
    }
    public async Task<Guid> CreateAsync(CrearProductoRequestDto request, CancellationToken ct = default)
    {
        var response = await _http.PostAsJsonAsync("api/productos", request, ct);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Guid>(cancellationToken: ct);
    }
}
public static class Afuera { public static void Probar(Producto p) { p.Precio = -5; } }
CS
dotnet build 2>&1 | grep -E "error" | sed 's#/w/g/Api/##' | sort -u
