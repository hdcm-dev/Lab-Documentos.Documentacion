#!/bin/sh
# C1-26: ¿se puede activar packages.lock.json sólo en ejecutables?
# Variante P: condición OutputType en Directory.Build.props. Variante T: en Directory.Build.targets.
set -u
for v in P T; do
  rm -rf /tmp/w$v; mkdir -p /tmp/w$v/App /tmp/w$v/Lib; cd /tmp/w$v
  cond='<Project><PropertyGroup Condition="'"'"'$(OutputType)'"'"' == '"'"'Exe'"'"'"><RestorePackagesWithLockFile>true</RestorePackagesWithLockFile></PropertyGroup></Project>'
  if [ $v = P ]; then echo "$cond" > Directory.Build.props; else echo "$cond" > Directory.Build.targets; fi
  printf '<Project Sdk="Microsoft.NET.Sdk"><PropertyGroup><OutputType>Exe</OutputType><TargetFramework>net8.0</TargetFramework></PropertyGroup><ItemGroup><PackageReference Include="Newtonsoft.Json" Version="13.0.3" /><ProjectReference Include="../Lib/Lib.csproj" /></ItemGroup></Project>\n' > App/App.csproj
  printf 'class P{static void Main(){}}\n' > App/P.cs
  printf '<Project Sdk="Microsoft.NET.Sdk"><PropertyGroup><TargetFramework>net8.0</TargetFramework></PropertyGroup><ItemGroup><PackageReference Include="Newtonsoft.Json" Version="13.0.3" /></ItemGroup></Project>\n' > Lib/Lib.csproj
  dotnet restore App/App.csproj -v q >/dev/null 2>&1; echo "rc=$?"
  echo "== variante $v ($( [ $v = P ] && echo Directory.Build.props || echo Directory.Build.targets ))"
  for p in App Lib; do [ -f $p/packages.lock.json ] && echo "  $p: packages.lock.json SI" || echo "  $p: packages.lock.json NO"; done
done
echo "== variante T en modo CI (RestoreLockedMode=true, como A.4 con CI=true), cache limpia"
cd /tmp/wT && rm -rf App/obj Lib/obj /root/.nuget/packages
dotnet restore App/App.csproj -p:RestoreLockedMode=true > /tmp/ci.log 2>&1; echo "rc=$?"; grep -E "error|NU1" /tmp/ci.log | head -3
echo "== cambio de versión sin regenerar el lock del ejecutable, modo CI"
sed -i 's/13.0.3/13.0.1/' App/App.csproj
dotnet restore App/App.csproj -p:RestoreLockedMode=true > /tmp/ci2.log 2>&1; echo "rc=$?"; grep -oE "error NU1004[^.]*" /tmp/ci2.log | head -1
