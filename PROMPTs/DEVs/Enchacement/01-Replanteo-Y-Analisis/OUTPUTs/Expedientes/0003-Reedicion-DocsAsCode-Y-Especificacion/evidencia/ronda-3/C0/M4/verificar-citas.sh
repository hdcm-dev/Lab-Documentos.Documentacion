#!/usr/bin/env bash
# Uso: verificar-citas.sh <corrida>  (dir con repo/ y salida/)
# Extrae citas archivo:linea[-linea] de A-01.md y artefactos de salida/ (excluye inventario/ y verificacion/, que son volcados de herramientas) y las comprueba contra repo/LD/ (y salida/ para artefactos propios).
# Estados: OK | OK-SALIDA (artefacto producido) | FUERA-DE-RANGO | INEXISTENTE
c="$1"
grep -rhoE '[A-Za-z0-9_.][A-Za-z0-9_./-]*\.[A-Za-z0-9]+:[0-9]+(-[0-9]+)?' --exclude-dir=inventario --exclude-dir=verificacion "$c/salida" | sort -u | while IFS= read -r cit; do
  f="${cit%:*}"; r="${cit##*:}"; a="${r%-*}"; b="${r#*-}"
  est=INEXISTENTE
  for base in repo/LD salida; do
    p="$c/$base/$f"
    if [ -f "$p" ]; then n=$(wc -l <"$p"); [ "$n" -lt 1 ] && n=1
      if [ "$b" -le "$((n+1))" ]; then [ $base = repo/LD ] && est=OK || est=OK-SALIDA; else est="FUERA-DE-RANGO($n)"; fi
      [ "${est#OK}" != "$est" ] && break
    fi
  done
  printf '%s\t%s\n' "$est" "$cit"
done
