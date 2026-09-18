export DOTNET_CLI_HOME=/tmp HOME=/tmp DOTNET_NOLOGO=1
cd /w && rm -rf T2 && mkdir T2 && cd T2
dotnet new sln -n Tienda >/dev/null; ls
dotnet new classlib -n Tienda.Domain -o src/Tienda.Domain >/dev/null
dotnet new classlib -n Tienda.Infrastructure -o src/Tienda.Infrastructure >/dev/null
rm src/*/Class1.cs
cat > src/Tienda.Domain/Producto.cs <<'CS'
namespace Tienda.Domain;
public class Producto
{
    public string Nombre { get; private set; } = "";
    public decimal Precio { get; private set; }
    public static Producto Create(string nombre, decimal precio)
    {
        if (precio <= 0) throw new ArgumentException("El precio debe ser mayor a cero.");
        return new Producto { Nombre = nombre, Precio = precio };
    }
}
CS
cat > src/Tienda.Infrastructure/ProductoRepository.cs <<'CS'
namespace Tienda.Infrastructure;
using Tienda.Domain;
public class ProductoRepository
{
    public void Guardar(Producto p) { p.Precio = -1; }
}
CS
echo "== sin referencia"; dotnet build src/Tienda.Infrastructure 2>&1 | grep -E "error|Build" | sort -u | head
dotnet add src/Tienda.Infrastructure reference src/Tienda.Domain
echo "== con referencia"; dotnet build src/Tienda.Infrastructure 2>&1 | grep -E "error|Build" | sort -u | head
dotnet list src/Tienda.Infrastructure reference
