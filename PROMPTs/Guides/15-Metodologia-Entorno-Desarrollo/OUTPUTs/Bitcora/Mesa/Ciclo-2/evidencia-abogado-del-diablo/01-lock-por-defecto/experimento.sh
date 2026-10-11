#!/bin/sh
# Abogado del diablo, ciclo 2, AD-01. La política .NET POR DEFECTO de la guía (A.3 + A.4 + A.4b + A.6)
# aplicada a una app de escritorio (WinExe, el tipo de proyecto de ESC-01) y a una consola (Exe),
# con una versión central inexistente (Primitives 8.0.2 -> NuGet aproxima 9.0.0, como E4-2).
# Uso: sh experimento.sh <dir-plantillas-A> <dir-trabajo>   (dentro de mcr.microsoft.com/dotnet/sdk:8.0)
set -u
P=$1; W=$2
rm -rf "$W"; mkdir -p "$W"; cd "$W" || exit 2
cp "$P/global.json" "$P/Directory.Build.props" "$P/Directory.Build.targets" "$P/nuget.config" .
cat > Directory.Packages.props <<'X'
<Project>
  <PropertyGroup>
    <ManagePackageVersionsCentrally>true</ManagePackageVersionsCentrally>
    <CentralPackageTransitivePinningEnabled>true</CentralPackageTransitivePinningEnabled>
  </PropertyGroup>
  <ItemGroup>
    <PackageVersion Include="Microsoft.Extensions.Primitives" Version="8.0.2" />
  </ItemGroup>
</Project>
X
mkdir -p Escritorio Consola
cat > Escritorio/Escritorio.csproj <<'X'
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>net8.0-windows</TargetFramework>
    <UseWindowsForms>true</UseWindowsForms>
    <EnableWindowsTargeting>true</EnableWindowsTargeting>
  </PropertyGroup>
  <ItemGroup><PackageReference Include="Microsoft.Extensions.Primitives" /></ItemGroup>
</Project>
X
cat > Consola/Consola.csproj <<'X'
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup><PackageReference Include="Microsoft.Extensions.Primitives" /></ItemGroup>
</Project>
X
echo "class P { static void Main() {} }" > Escritorio/P.cs; cp Escritorio/P.cs Consola/P.cs
export NUGET_PACKAGES=/tmp/nuget-$$ DOTNET_NOLOGO=1 DOTNET_CLI_TELEMETRY_OPTOUT=1
r() { # $1 rotulo, $2 proyecto, resto: variables
  rot=$1; prj=$2; shift 2
  out=$(env "$@" dotnet restore "$prj" 2>&1); rc=$?
  n=$(printf '%s\n' "$out" | grep -c 'NU1603')
  e=$(printf '%s\n' "$out" | grep -m1 -o 'error NU1603' || true)
  w=$(printf '%s\n' "$out" | grep -m1 -o 'warning NU1603' || true)
  lk=$( [ -f "$(dirname "$prj")/packages.lock.json" ] && echo "SI" || echo "NO")
  printf '%-58s rc=%s  NU1603: %s%s  lock=%s\n' "$rot" "$rc" "${e:-}" "${w:-}" "$lk"
  [ -f "$(dirname "$prj")/packages.lock.json" ] && grep -o '"requested": "[^"]*",[^}]*"resolved": "[^"]*"' "$(dirname "$prj")/packages.lock.json" | head -1 | sed 's/^/      lock: /'
}
echo "SDK $(dotnet --version)"
echo "== 1. Plantillas TAL CUAL (política por defecto: lock + disable; NU1603 comentado)"
r "Consola (Exe), estación"            Consola/Consola.csproj       X=1
r "Escritorio (WinExe), estación"      Escritorio/Escritorio.csproj X=1
r "Consola (Exe), CI=true"             Consola/Consola.csproj       CI=true
r "Escritorio (WinExe), CI=true"       Escritorio/Escritorio.csproj CI=true
echo "   OutputType/RestorePackagesWithLockFile/RestoreLockedMode del WinExe en CI:"
CI=true dotnet msbuild Escritorio/Escritorio.csproj -getProperty:OutputType -getProperty:RestorePackagesWithLockFile -getProperty:RestoreLockedMode 2>&1 | tr -d '\n '; echo
echo "== 2. Lo mismo con NU1603 como error TAMBIÉN en la política con lock (A.4 descomentado)"
rm -rf Consola/obj Escritorio/obj Consola/packages.lock.json "$NUGET_PACKAGES"
sed -i 's|<!-- <WarningsAsErrors>$(WarningsAsErrors);NU1603</WarningsAsErrors> -->|<WarningsAsErrors>$(WarningsAsErrors);NU1603</WarningsAsErrors>|' Directory.Build.props
grep -c '^ *<WarningsAsErrors>' Directory.Build.props | sed 's/^/   WarningsAsErrors activo: /'
r "Consola (Exe), estación, cache fría (genera el lock)" Consola/Consola.csproj       X=1
r "Consola (Exe), CI=true"                               Consola/Consola.csproj       CI=true
r "Escritorio (WinExe), estación"                        Escritorio/Escritorio.csproj X=1
r "Escritorio (WinExe), CI=true"                         Escritorio/Escritorio.csproj CI=true
