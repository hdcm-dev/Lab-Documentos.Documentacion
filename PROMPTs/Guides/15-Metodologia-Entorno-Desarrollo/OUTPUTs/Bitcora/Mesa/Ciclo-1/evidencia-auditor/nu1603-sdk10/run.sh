dotnet --version
echo "== A: CPM + transitive pinning, SIN lock, NU1603 como error"
dotnet restore App.csproj > a.log 2>&1; rc=$?; grep -E "NU1603|Restored" a.log | sed 's#/w/##'; echo "restore rc=$rc"
echo "== B: lo mismo CON lock (RestorePackagesWithLockFile), NU1603 como error, cache fria"
rm -rf obj /root/.nuget/packages; dotnet restore App.csproj -p:RestorePackagesWithLockFile=true > b.log 2>&1; rc=$?; grep -E "NU1603|Restored" b.log | sed 's#/w/##'; echo "restore rc=$rc"
grep -A4 '"Microsoft.Extensions.Primitives"' packages.lock.json | head -5
