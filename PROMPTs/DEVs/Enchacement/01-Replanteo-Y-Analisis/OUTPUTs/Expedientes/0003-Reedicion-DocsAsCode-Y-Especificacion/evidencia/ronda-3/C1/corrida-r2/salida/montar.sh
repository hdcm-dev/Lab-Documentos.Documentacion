# Arma salida/_montaje/LG = copia de repo/LG + artefactos de salida/LG (sin tocar repo/). Uso: bash salida/montar.sh
set -e; rm -rf salida/_montaje; mkdir -p salida/_montaje
cp -r repo/LG salida/_montaje/LG; cp -r salida/LG/. salida/_montaje/LG/
rm -f salida/_montaje/LG/SDD/Docs/Producto/11-Documentacion/Contrato-Agentes.md.propuesta-A-05.md
