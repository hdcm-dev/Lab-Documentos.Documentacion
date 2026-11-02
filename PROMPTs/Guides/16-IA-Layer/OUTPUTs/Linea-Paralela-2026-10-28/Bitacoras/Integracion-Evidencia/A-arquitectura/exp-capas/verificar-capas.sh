#!/bin/sh
# Prueba de arquitectura por grep (las capas son carpetas de un solo ensamblado: el compilador no la hace cumplir).
cd "$(dirname "$0")"
echo "== using de IA por carpeta (Microsoft.Extensions.AI | Microsoft.Agents | OllamaSharp | VectorData)"
for d in Copia/Domain Copia/Application Nuevo/Application Nuevo/Infrastructure/AI; do
  n=$(grep -rlE '^using (Microsoft\.Extensions\.AI|Microsoft\.Agents|OllamaSharp|Microsoft\.Extensions\.VectorData|CommunityToolkit\.VectorData)' $d | wc -l)
  echo "  $d: $n archivo(s)"; done
echo "== fidelidad de la copia: diff -r contra el caso base"
SRC="${1:?ruta de la copia}"
diff -r "$SRC/Domain" Copia/Domain && diff -r "$SRC/Application" Copia/Application && echo "  idénticas (0 diferencias)"
