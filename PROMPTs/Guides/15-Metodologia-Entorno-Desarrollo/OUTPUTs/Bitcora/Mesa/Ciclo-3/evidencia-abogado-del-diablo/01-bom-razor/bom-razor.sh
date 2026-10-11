#!/bin/sh
# Abogado del diablo, ciclo 3, experimento 01.
# Pregunta: ¿las herramientas del SDK «reponen» el BOM de un .razor (como dotnet sln add con .sln),
# o sólo lo traen las plantillas al CREAR? ¿Y las plantillas de ítem de .cs traen BOM igual que las de .razor?
# Corre dentro de mcr.microsoft.com/dotnet/sdk:8.0 y :10.0, sin red salvo la restauración.
set -u
bom() { if [ "$(head -c3 "$1" | od -An -tx1 | tr -d ' ')" = "efbbbf" ]; then echo BOM; else echo sinBOM; fi; }
cuenta() { # cuenta archivos con y sin BOM para un patrón
  c=0; s=0
  for f in $(find . -name "$1" -not -path '*/obj/*' -not -path '*/bin/*'); do
    if [ "$(bom "$f")" = BOM ]; then c=$((c+1)); else s=$((s+1)); fi
  done
  echo "$1: conBOM=$c sinBOM=$s"
}
export DOTNET_CLI_TELEMETRY_OPTOUT=1 DOTNET_NOLOGO=1 HOME=/tmp
echo "== SDK $(dotnet --version)"
rm -rf /tmp/w && mkdir -p /tmp/w && cd /tmp/w
dotnet new blazor -n Web -o Web >/dev/null 2>&1 || dotnet new blazorserver -n Web -o Web >/dev/null 2>&1
cd Web
echo "-- 1. plantilla de proyecto (dotnet new blazor)"
cuenta '*.razor'; cuenta '*.cs'; cuenta '*.csproj'
echo "-- 2. plantillas de ITEM: dotnet new razorcomponent / class / interface"
mkdir -p Items
dotnet new razorcomponent -n Nuevo -o Items >/dev/null 2>&1 && echo "Items/Nuevo.razor: $(bom Items/Nuevo.razor)"
dotnet new class -n Clase -o Items >/dev/null 2>&1 && echo "Items/Clase.cs: $(bom Items/Clase.cs)"
dotnet new interface -n IFace -o Items >/dev/null 2>&1 && echo "Items/IFace.cs: $(bom Items/IFace.cs)"
echo "-- 3. se quita el BOM de TODOS los .razor existentes y se corren comandos habituales del SDK"
for f in $(find . -name '*.razor' -not -path '*/obj/*'); do
  if [ "$(bom "$f")" = BOM ]; then tail -c +4 "$f" > "$f.t" && mv "$f.t" "$f"; fi
done
cuenta '*.razor'
dotnet build -c Release -v q >/dev/null 2>&1; echo "dotnet build rc=$?"
printf 'root = true\n[*]\ncharset = utf-8\n' > .editorconfig
dotnet format whitespace --verify-no-changes >/dev/null 2>&1; echo "dotnet format whitespace --verify-no-changes (charset=utf-8) rc=$?"
dotnet format whitespace >/dev/null 2>&1; echo "dotnet format whitespace (aplica) rc=$?"
dotnet add package Microsoft.Extensions.Logging.Abstractions --version 8.0.0 >/dev/null 2>&1; echo "dotnet add package rc=$?"
echo "-- 4. después de build, format y add package:"
cuenta '*.razor'
echo "-- 5. ¿Razor compila igual con y sin BOM? (texto no ASCII en el .razor)"
printf '@page "/acento"\n<p>Atención: señal</p>\n' > Components/Pages/Acento.razor 2>/dev/null || printf '@page "/acento"\n<p>Atención: señal</p>\n' > Pages/Acento.razor
dotnet build -c Release -v q >/dev/null 2>&1; echo "build con .razor UTF-8 SIN BOM y acentos rc=$?"
g=$(find obj -name 'Acento_razor.g.cs' 2>/dev/null | head -1)
if [ -n "$g" ]; then grep -o 'Atención: señal' "$g" | head -1; else
  dll=$(find bin/Release -name 'Web.dll' | head -1); echo "en la DLL: $(grep -c 'Atenci' "$dll" 2>/dev/null) coincidencias ASCII de 'Atenci' (UTF-16 no se ve con grep)"; fi
