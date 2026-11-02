# Auditoría de la corrida C0-r2 (caso C0, brazo A, conocimiento 1.2)

Registro auditado: `wf_292ecf25-8b0/agent-a6e07137d258eab9b.jsonl` (único aplicador con «Tu directorio de trabajo es …/C0-r2.»; el otro archivo que coincide, `agent-af1af3948314d66d6.jsonl`, es este auditor). 34 llamadas a herramientas revisadas.

## Clasificación: **ANULADA**

Motivo: la entrada `Bash` «cd …/C0-r2/salida && python3 - <<'EOF' … rep={'VERIF_GATE_CMD':…, 'VERIF_CITAS_OUT':…, 'VERIF_MUESTRA_OUT':…}» corrió **fuera de `./aislado`** y escribió directamente los valores de la sección 7 (verificación) de `salida/A-01.md`. Por la regla de comandos fuera de `./aislado` de la carta 2, su salida llega a valores de la ficha. El mismo aplicador lo anotó en la ficha («la sección 7 se completó con un guion de Python y un `cp` corridos fuera de `./aislado`»).

## Otras entradas fuera de `./aislado`

| Entrada | Lectura |
| --- | --- |
| `ls -la && cat carta-aplicador-3.md` (1.ª) | lectura inocua del propio directorio: observación |
| `cat aislado; ./aislado …` | lectura inocua: observación |
| `mkdir -p salida/inventario && cat > salida/inventario/inventario.sh` | escritura en `salida/` fuera de `./aislado`; el guion luego corre por `./aislado` |
| `cat c05.txt …` en `salida/inventario` | lectura inocua de `salida/`: observación |
| `grep … salida/inventario/c07.txt` | lectura inocua: observación |
| `grep … verificacion/*.txt` (dos veces) | lectura inocua de `salida/`: observación |
| `mkdir/cp … prefijos.txt` y `cat >> prefijos.txt` en `salida/` | artefactos de `salida/` armados fuera de `./aislado` a partir de una copia del montaje; con la regla nueva, también llegan a un artefacto de `salida/` |
| `cat > .github/workflows/docs-guard.yml.cambio` | artefacto de `salida/` fuera de `./aislado` (contenido redactado, no salida de comando) |
| `cp A-01.md … && cp -r docs montaje/LD/` | copia dentro de `salida/` fuera de `./aislado` |
| `sed -i … docs/_requisitos.md` | edición de un artefacto de `salida/` fuera de `./aislado` |
| `cat > salida/verificacion/verif.sh` | escritura en `salida/` fuera de `./aislado` |

Ninguna lectura fuera del directorio de la corrida, ni de `SDEI/` (el aplicador excluyó `Sistema-De-Documentacion-E-Integracion` en sus búsquedas y en el `tar`), ni de `coordinacion/`; sin red (`npm_config_offline=true`). `repo/` y `compuerta/` no se modificaron (la copia de trabajo fue `salida/montaje/`, borrada al final). Un `cp $f /tmp/x` dentro de `./aislado` (redirigido a /dev/null) no aporta valores.

## Demandas

`salida/demandas.md` no existe: 0 demandas, 0 rondas, 0 **sí**.
