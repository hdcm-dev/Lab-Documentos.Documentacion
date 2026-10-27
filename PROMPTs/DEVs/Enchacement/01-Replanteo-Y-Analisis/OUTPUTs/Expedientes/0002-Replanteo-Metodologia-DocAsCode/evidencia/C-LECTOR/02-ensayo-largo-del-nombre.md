# Ensayo E-02 — largo del nombre de una localidad (MovilidadUrbana.MAUI)

Fecha: 2026-10-26. Fuente copiada: /LAB/Lab-E2E.WebBlazor/Lab-E2E.WebBlazor/src/MovilidadUrbana.MAUI/Domain/Rules/LocalidadRules.cs (commit 8fb4c3a).
Intermedios en un directorio fuera del workspace ($WORK/ensayo-largo), borrado al terminar.

## Programa (Program.cs)

```csharp
using Microsoft.EntityFrameworkCore;
using MovilidadUrbana.MAUI.Domain.Rules;
var nombre = new string('a', 70);
Console.WriteLine($"Requisito mostrado: Entre {LocalidadRules.LargoMinimoDelNombre} y {LocalidadRules.LargoMaximoDelNombre} caracteres");
Console.WriteLine($"NombreValido(70 chars) = {LocalidadRules.NombreValido(nombre)}");
using var db = new Db(); db.Database.EnsureCreated();
db.Locs.Add(new Loc { Nombre = nombre }); db.SaveChanges();
Console.WriteLine($"SQLite guardó largo = {db.Locs.AsNoTracking().First().Nombre.Length} con HasMaxLength(60)");
class Loc { public int Id { get; set; } public string Nombre { get; set; } = ""; }
class Db : DbContext {
  public DbSet<Loc> Locs => Set<Loc>();
  protected override void OnConfiguring(DbContextOptionsBuilder o) => o.UseSqlite("Data Source=/tmp/e.db");
  protected override void OnModelCreating(ModelBuilder m) => m.Entity<Loc>().Property(l => l.Nombre).HasMaxLength(60).IsRequired();
}
```

## Proyecto (e.csproj)

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup><OutputType>Exe</OutputType><TargetFramework>net10.0</TargetFramework><Nullable>enable</Nullable><ImplicitUsings>enable</ImplicitUsings></PropertyGroup>
  <ItemGroup><PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="10.0.11" /></ItemGroup>
</Project>
```

## Comando

```bash
docker run --rm -u $(id -u):$(id -g) -e HOME=/tmp -v $WORK/ensayo-largo:/w -w /w mcr.microsoft.com/dotnet/sdk:10.0 dotnet run
```

## Salida (recortada: se omite un aviso de workloads del SDK)

```text
Requisito mostrado: Entre 3 y 60 caracteres
NombreValido(70 chars) = True
SQLite guardó largo = 70 con HasMaxLength(60)
```

## Lectura

- La pantalla muestra «Entre 3 y 60 caracteres, único por provincia.» (`src/MovilidadUrbana.MAUI/Application/Localidades/LocalidadPolicy.cs:15-16`).
- La validación del servicio sólo controla el mínimo (`Application/Localidades/LocalidadService.cs:76-79`; `Domain/Rules/LocalidadRules.cs:18-19`).
- El campo admite 80 caracteres (`Pages/LocalidadEditorPage.xaml:22`, `MaxLength="80"`).
- `HasMaxLength(60)` (`Infrastructure/Persistence/AppDbContext.cs:28`) no impide guardar 70 caracteres en SQLite: lo mostró la corrida.
- No se corrió la app en un dispositivo: el ensayo reproduce la regla y la persistencia, no la pantalla.
