#!/bin/sh
set -u
dotnet --version
rm -rf /tmp/w; mkdir -p /tmp/w/Win /tmp/w/Web; cd /tmp/w
echo '<Project><PropertyGroup Condition="'"'"'$(OutputType)'"'"' == '"'"'Exe'"'"' Or '"'"'$(OutputType)'"'"' == '"'"'WinExe'"'"'"><RestorePackagesWithLockFile>true</RestorePackagesWithLockFile></PropertyGroup></Project>' > Directory.Build.targets
cat Directory.Build.targets
printf '<Project Sdk="Microsoft.NET.Sdk"><PropertyGroup><OutputType>WinExe</OutputType><TargetFramework>net8.0</TargetFramework></PropertyGroup><ItemGroup><PackageReference Include="Newtonsoft.Json" Version="13.0.3" /></ItemGroup></Project>\n' > Win/Win.csproj
printf 'class P{static void Main(){}}\n' > Win/P.cs
printf '<Project Sdk="Microsoft.NET.Sdk.Web"><PropertyGroup><TargetFramework>net8.0</TargetFramework></PropertyGroup><ItemGroup><PackageReference Include="Newtonsoft.Json" Version="13.0.3" /></ItemGroup></Project>\n' > Web/Web.csproj
printf 'class P{static void Main(){}}\n' > Web/P.cs
for p in Win Web; do dotnet restore $p/$p.csproj -v q >/dev/null 2>&1; echo "$p restore rc=$?"; [ -f $p/packages.lock.json ] && echo "  $p: packages.lock.json SI" || echo "  $p: packages.lock.json NO"; dotnet msbuild $p/$p.csproj -getProperty:OutputType; done
