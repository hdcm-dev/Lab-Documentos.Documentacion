// Sonda 4: ¿EF Core traduce un agregado por medio cuando Medios se persiste con el ValueConverter del caso base?
// La entidad y el OnModelCreating de RespuestaDeEncuesta están transcritos de ApiWeb@59399ba (AppDbContext.cs); sólo se recorta lo demás.
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using var cn = new SqliteConnection("Data Source=:memory:"); cn.Open();
var opts = new DbContextOptionsBuilder<Ctx>().UseSqlite(cn).Options;
using (var c = new Ctx(opts))
{
    c.Database.EnsureCreated();
    c.Encuestas.AddRange(
        new() { SessionId = "s", Nombre = "Ana", Medios = ["colectivo", "bicicleta"], Motivo = "trabajo", Localidad = "Goya" },
        new() { SessionId = "s", Nombre = "Beto", Medios = ["colectivo"], Motivo = "estudio", Localidad = "Goya" },
        new() { SessionId = "s", Nombre = "Caro", Medios = ["auto"], Motivo = "trabajo", Localidad = "Corrientes" });
    c.SaveChanges();
}
using var ctx = new Ctx(opts);
void Probar(string rotulo, Func<object> q)
{
    try { Console.WriteLine($"[{rotulo}] OK → {System.Text.Json.JsonSerializer.Serialize(q())}"); }
    catch (Exception e) { Console.WriteLine($"[{rotulo}] {e.GetType().Name}: {e.Message.Split('\n')[0][..Math.Min(220, e.Message.Split('\n')[0].Length)]}"); }
}
Probar("A SelectMany(Medios).GroupBy en el servidor", () => ctx.Encuestas.Where(e => e.SessionId == "s").SelectMany(e => e.Medios).GroupBy(m => m).Select(g => new { Medio = g.Key, N = g.Count() }).ToList());
Probar("B Count(e => e.Medios.Contains(\"colectivo\"))", () => ctx.Encuestas.Count(e => e.SessionId == "s" && e.Medios.Contains("colectivo")));
Probar("C GroupBy(Motivo) en el servidor", () => ctx.Encuestas.Where(e => e.SessionId == "s").GroupBy(e => e.Motivo).Select(g => new { Motivo = g.Key, N = g.Count() }).ToList());
Probar("D proyección sólo de Medios + agregado en memoria", () => ctx.Encuestas.Where(e => e.SessionId == "s").Select(e => e.Medios).AsEnumerable().SelectMany(m => m).GroupBy(m => m).Select(g => new { Medio = g.Key, N = g.Count() }).ToList());
Console.WriteLine("[SQL de D] " + ctx.Encuestas.Where(e => e.SessionId == "s").Select(e => e.Medios).ToQueryString().Replace("\n", " "));

public class RespuestaDeEncuesta
{
    public int Id { get; set; }
    public string SessionId { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Localidad { get; set; } = string.Empty;
    public IReadOnlyList<string> Medios { get; set; } = [];
    public string Motivo { get; set; } = string.Empty;
}
public class Ctx(DbContextOptions<Ctx> o) : DbContext(o)
{
    public DbSet<RespuestaDeEncuesta> Encuestas => Set<RespuestaDeEncuesta>();
    protected override void OnModelCreating(ModelBuilder model) => model.Entity<RespuestaDeEncuesta>(entidad =>
    {
        entidad.Property(e => e.SessionId).HasMaxLength(64).IsRequired();
        entidad.Property(e => e.Nombre).HasMaxLength(80).IsRequired();
        entidad.HasIndex(e => e.SessionId);
        entidad.Property(e => e.Medios).HasConversion(
            new ValueConverter<IReadOnlyList<string>, string>(
                medios => string.Join(',', medios),
                texto => texto.Length == 0 ? new List<string>() : texto.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()),
            new ValueComparer<IReadOnlyList<string>>(
                (a, b) => a!.SequenceEqual(b!),
                lista => lista.Aggregate(0, (acumulado, valor) => HashCode.Combine(acumulado, valor.GetHashCode())),
                lista => lista.ToList()));
    });
}
