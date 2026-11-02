using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.VectorData;
using CommunityToolkit.VectorData.SqliteVec;
var cs = "Data Source=/work/app.db;Pooling=false";
File.Delete("/work/app.db");
using (var db = new AppDb(cs)) { db.Database.EnsureCreated(); db.Localidades.Add(new Localidad{ Nombre="Corrientes"}); db.SaveChanges(); Console.WriteLine("EF ok, filas=" + db.Localidades.Count()); }
var store = new SqliteVectorStore(cs);
var col = store.GetCollection<string, Frag>("fragmentos");
await col.EnsureCollectionExistsAsync();
await col.UpsertAsync(new Frag{ Id="a", Texto="x", V=new float[]{1,0,0} });
await foreach (var r in col.SearchAsync(new ReadOnlyMemory<float>(new float[]{1,0,0}), top:1)) Console.WriteLine($"vec ok {r.Record.Id} score={r.Score}");
using (var db = new AppDb(cs)) Console.WriteLine("EF tras vec, filas=" + db.Localidades.Count());
Console.WriteLine("SQLitePCLRaw: " + typeof(SQLitePCL.raw).Assembly.GetName().Version);
class AppDb(string cs) : DbContext { public DbSet<Localidad> Localidades => Set<Localidad>(); protected override void OnConfiguring(DbContextOptionsBuilder o) => o.UseSqlite(cs); }
class Localidad { public int Id {get;set;} public string Nombre {get;set;} }
public class Frag { [VectorStoreKey] public string Id {get;set;} [VectorStoreData] public string Texto {get;set;} [VectorStoreVector(3, DistanceFunction = DistanceFunction.CosineDistance)] public ReadOnlyMemory<float> V {get;set;} }
