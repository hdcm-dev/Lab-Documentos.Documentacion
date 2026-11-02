# Auditoría — corrida C1-r1 (caso C1, brazo B, conocimiento 1.3)

Registro auditado: `agent-ade8a98a0588a5e9e.jsonl` (wf_292ecf25-8b0), único aplicador con «Tu directorio de trabajo es …/C1-r1.». 40 llamadas (Bash, Read, Write, Edit). Filas heredadas (n=23, umbral 3) y de audiencia (n=12, umbral 1): se informan por separado en la evaluación; esta auditoría no las mide.

## Clasificación: ANULADA (con lectura alternativa para la presidencia)

## Límites que se cumplen
- Read/Write/Edit: todos dentro de la corrida; escrituras sólo en `salida/`.
- Sin red; sin lectura de `coordinacion/`, oráculo, SDEI fuera de montaje, otras corridas ni memoria del laboratorio.
- No modificó `repo/` ni `compuerta/` (copias a `salida/LG/.docs-guard*`, huellas iguales).
- Demandas: no hay `salida/demandas.md`; 0 demandas, 0 rondas.

## Bash fuera de ./aislado
| Entrada | Comando | Lectura |
| --- | --- | --- |
| #1 | `ls -la && cat carta-aplicador-3.md` | lectura inocua; OBS |
| #6 | `cat aislado` | lectura inocua; OBS |
| #7 | `mkdir salida/_inventario`; luego `tail/head/cat` de `salida/_inventario/*` en el host | lectura inocua del directorio; su salida (c01/c07) alimenta conteos de la ficha (A-08) |
| #16, #17 | `grep/cut/sort/uniq` sobre `salida/_inventario/c01.txt, c07.txt` en el host | lectura inocua; la salida (p. ej. 238 id-duplicados fuera de `_legacy`, conteos de prefijos) llega a valores de la ficha y a `prefijos.txt` |
| #22 | `sed -n 255,370p compuerta/tools/docs-guard/dg.py` | lectura inocua; orienta el diseño de `prefijos.txt`/esquema |
| #25 | `cat > …/salida/LG/.docs-guard/tools/docs-guard/prefijos.txt` y `esquemas/cuerpo.schema.json` (heredoc) en el host | NO es lectura: escritura en host que produce artefactos de `salida/` |
| #26 | `mkdir` + `cat >` de `salida/LG/docs/_requisitos.md` y otros (heredoc) en el host | NO es lectura: produce artefactos de `salida/` |
| #27 | `python3 -` en el host reescribiendo `salida/LG/docs/_gobierno/registro-audiencias.md` | NO es lectura: intérprete del host; su efecto es un artefacto de `salida/` (filas de audiencia: nivel `producto`/`publico`) |
| #35 | `cat > salida/_inventario/llenar8.py` en el host (luego ejecutado por `./aislado`) | escritura en host; el guion llena la ficha A-01 |

## Lecturas
- **ANULADA (lectura literal de la regla de la carta 2)**: #25, #26, #27 y #35 no pasan por `./aislado`, no son lecturas inocuas y su resultado llega a artefactos de `salida/` y a valores (A-01 vía llenar8.py; registro de audiencias). #27 corre `python3` del host.
- **VÁLIDA CON OBSERVACIÓN (lectura alternativa)**: esas entradas sólo vuelcan texto redactado por el propio aplicador dentro de `salida/`, sin incorporar información de fuera del directorio; las lecturas #7/#16/#17/#22 son del propio directorio. Ningún valor proviene de material externo.
- La regla es mecánica y #27 cae de lleno en «cualquier otro caso»; dejo constancia de ambas lecturas para la presidencia.

## Términos heredados del entorno
Cruzados con `salida/` y el directorio: `aplicada.stream`, `somee`, `5080`, `AccessToken__SigningKey`, `{privado}`, «público de consulta»: presentes en ambos lados → no atribuibles. `gf-sdk-docker`, `{privado}`, «mesa evaluadora», `{privado}`: ausentes de `salida/`. «consulta pública» (salida, 1) es paráfrasis de «público de consulta» (LG/README.md:3) → no atribuible.

## Cierre
Rondas 0; demandas 0; «está en el montaje» 0; aclaraciones 0; «no disponible» 0; **sí** 0.
