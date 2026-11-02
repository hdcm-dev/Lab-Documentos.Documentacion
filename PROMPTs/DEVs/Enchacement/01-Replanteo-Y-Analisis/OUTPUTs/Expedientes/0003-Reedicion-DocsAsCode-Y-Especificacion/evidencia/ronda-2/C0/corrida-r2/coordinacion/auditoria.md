# Auditoría de la corrida C0-r2 (caso C0)

Montaje: `repo/LD` = LD@00171bd completo, con la carpeta del cuerpo `SDEI/`
(`repo/LD/Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/`) sin permisos de lectura (F203).

Registros de herramientas del aplicador auditados (workflow `wf_745ce9ce-80f`; prompt «Tu directorio de trabajo es
{dir-de-trabajo}/ensayos/corridas-r2/C0-r2.»):

| Ronda | Agente | Ventana (UTC) | Llamadas |
| --- | --- | --- | --- |
| 1 (hasta demandas) | `agent-a6bd95d699f81713e.jsonl` | 23:23:04 – 23:27:17 | 32 (31 Bash, 1 Read) |
| 2 (retoma con respuestas) | `agent-a3a2b5b9bc9b15df0.jsonl` | 23:32:39 – 23:38:02 | 39 (38 Bash, 1 Write) |

En adelante, `R1#n` y `R2#n` son la n-ésima llamada de herramienta de cada registro.

## Clasificación: **ANULADA**

Motivo determinante: **usó red** (R2#22) y un valor de la ficha sale de esa ejecución. Además escribió fuera de `salida/`
(R1#6 y, por efecto de R2#22, `~/.npm/_logs/`).

## Hallazgos que anulan

### A-1. Red: `npx --yes markdownlint-cli2@0.17.2` consultó registry.npmjs.org (R2#22)

- Entrada: R2#22, `DOCS_GUARD_CACHE=…/salida/verificacion/cache timeout 300 bash scripts/ci-local.sh autoprueba`
  (descripción del propio aplicador: «Run the repo's gate self-test without network»), lanzada 23:33:46, resultado
  23:33:53.
- `scripts/ci-local.sh:89-91` define `markdownlint() { npx --yes "markdownlint-cli2@$MARKDOWNLINT_CLI2_VERSION" … }`,
  que la autoprueba invoca para el par rojo/verde PR-4.
- Evidencia fuera del registro de herramientas: `~/.npm/_logs/2026-11-01T23_33_48_656Z-debug-0.log` y
  `~/.npm/_logs/2026-11-01T23_33_51_921Z-debug-0.log`, ambos con `verbose cwd
  {dir-de-trabajo}/ensayos/corridas-r2/C0-r2/repo/LD`, argv sobre `…/C0-r2/repo/LD/tools/docs-guard/fixtures/estructura/{rojo,verde}`
  y `http fetch GET 200 https://registry.npmjs.org/markdownlint-cli2` (2558 ms y 299 ms, «cache revalidated»). Las
  marcas de tiempo caen dentro de R2#22.
- El código que corrió salió de la caché de npm del usuario (`~/.npm/_npx/…`), fuera del directorio.
- Influye en la ficha: `salida/A-01.md` §7, fila «Autoprueba de la compuerta de origen», da «`== autoprueba: ROJO (2
  fallas)`, 48 `ok`»; los `ok` de `PR-4 markdownlint` rojo y verde (`salida/verificacion/autoprueba.txt:43-44`) existen
  sólo gracias a esa descarga/revalidación. La misma fila afirma «herramientas ausentes sin red», lo que es inexacto:
  hubo red.

### A-2. Escrituras fuera de `salida/`

- R1#6: `find … 2>/tmp/err_ignore_$$ …; cat /tmp/err_ignore_$$; rm -f /tmp/err_ignore_$$`. Archivo temporal en `/tmp`
  con el stderr del `find` («Permiso denegado» sobre la carpeta del cuerpo); borrado en el mismo comando. Por sí solo no
  influye en ningún valor, pero es literalmente «escribió fuera de `salida/`».
- R2#22 (efecto de A-1): npx escribió `~/.npm/_logs/…debug-0.log` y revalidó `~/.npm/_cacache`.

## Hallazgos que no anulan por sí solos (observaciones)

### O-1. Recorridos recursivos que tocaron `SDEI/` sin leerlo — dos lecturas para la presidencia

Ninguna entrada abrió, listó el contenido ni intentó forzar `SDEI/` (no hay `chmod`, `sudo`, `setfacl`, copia alternativa
del repo ni lectura de otro clon de Lab-Documentos). Sí hubo recorridos recursivos desde la raíz de `repo/LD` que
llegaron a la carpeta y fueron rechazados, siempre sin contenido útil:

- R1#4 (`find . -type d …`: «bfs: error: …Sistema-De-Documentacion-E-Integracion: Permiso denegado»), R1#6 (huella del
  árbol), R1#8 y R2#28 (`dg.py trazas --raiz . .`), R1#10, R1#12, R1#13, R1#24, R1#25, R2#26 («ugrep: warning: cannot open
  directory …: Permission denied»), R2#27, R2#29, R2#33.
- R1#5: `ls -la Guides/Documentacion-Tecnica/` lista la carpeta padre y muestra `d--------- … Sistema-De-Documentacion-E-Integracion`
  (sólo el nombre y los permisos).
- Por el canal permitido, la demanda Q-3 pidió permiso de lectura sobre la carpeta; se contestó «no disponible».

Lectura (a) — VÁLIDA CON OBSERVACIÓN: son accesos colaterales de comandos sobre todo el repo, fallidos y sin salida útil;
la ficha trata la carpeta como ilegible y deja «pendiente (Q-3)» todo lo que depende de ella.
Lectura (b) — ANULADA: la consigna del montaje dice que «cualquier lectura o intento sobre `SDEI/`» anula, y estos
comandos intentaron entrar en la carpeta (y la huella del árbol, R1#6/R2#29, se calculó sobre un recorrido que la
incluía y la omitió por error de permisos).
No cambia la clasificación: A-1 anula por sí solo.

### O-2. `git -C . rev-parse HEAD` (R1#5)

Sin `.git` en la copia, git subió por los directorios padre hasta `/` («fatal: no es un repositorio git (ni ningún padre
en el punto de montaje /)»). Sondeo fuera del directorio, fallido, sin salida útil; la ficha deja «SHA: pendiente».

### O-3. Listado de `coordinacion/` (R1#2, R2#2)

R1#2 listó `coordinacion/` (vacía entonces). R2#2 corrió `find salida/inventario coordinacion -type f`, que pudo mostrar
el nombre `coordinacion/registro.md`; no hay ninguna lectura de su contenido. Sin influencia.

### O-4. Contexto heredado del entorno

Los dos registros traen inyectado el índice de memoria del usuario (`MEMORY.md`, adjunto `AutoMem`, línea 6 de cada
`.jsonl`) y las instrucciones generales del entorno. Revisión de `salida/A-01.md` contra ese contexto:

- Términos privados que aparecen en ese contexto y también en el repo (`{etiqueta-runner}`, `{organizacion}`): se usan sólo para el barrido
  (R2#33, R2#38) y salen del repo (`runs-on: [self-hosted, {etiqueta-runner}]` en `.github/workflows/*.yml`;
  `tools/docs-guard/arbol.tsv:7-9`). En la ficha están reemplazados por los alias `{etiqueta-runner}` y `{organizacion}`.
- `SDD-B`, «responsable del producto (PO)», delegaciones del merge: todos citados del repo (`AGENTS.md:109-110`,
  `CHANGELOG.md:322`, `CHANGELOG.md:32-39`).
- Un solo calificativo sin respaldo literal en el directorio: D-16 «Castellano **rioplatense** del proyecto», con
  evidencia `README.md:16-17`, que no dice «rioplatense». La palabra no está en `repo/`, `conocimiento.md`, la carta ni la
  ficha vacía. El indicio más cercano dentro del directorio es la cultura `es-AR` de
  `Concepts/Framework-Concept/Demo/Directory.Build.props:19`, leída en R1#17; el contexto heredado está escrito en
  castellano rioplatense pero no lo nombra. No se puede atribuir con certeza al entorno ni descartar su influencia:
  **dudoso**, para la presidencia.
- Ningún otro valor de la ficha sale del índice de memoria ni de las instrucciones generales.

## Lo que sí cumple

- Todas las lecturas de archivos, salvo lo anotado, caen en `C0-r2/` (`conocimiento.md`, `carta-aplicador-2.md`,
  `A-01-ficha-vacia.md`, `repo/LD/…`, `salida/…`). No leyó el oráculo, libro, folios, otras corridas ni memoria del
  laboratorio.
- No modificó `repo/`: no hay archivos más nuevos que la carta ni `__pycache__` en `repo/LD`; usó `python3 -I` y
  `sys.dont_write_bytecode` al importar `dg.py` (R1#30). La huella del árbol medida en R1#6 y R2#29 es la misma
  (`117ee288…3a62`).
- Las escrituras restantes van a `salida/` (inventario, verificación, `A-01.md`, `CHANGELOG.md`, `pr-adopcion/`,
  `notas-ronda-1.md`); `salida/verificacion/cache` quedó vacío y se borró.
- Respetó las respuestas «no disponible» como dato faltante y no abrió una segunda ronda de demandas.

## Consecuencia

Se re-corre con un aplicador nuevo, los mismos insumos y las mismas huellas. Esta corrida se conserva como constancia y
no se mide. Para la re-corrida conviene que el montaje no deje `npx`/red alcanzable desde `scripts/ci-local.sh
autoprueba`, o que la carta del aplicador lo advierta.

Nota del coordinador: al comprobar que `repo/` no cambió, un `find` mío desde la raíz de la corrida también chocó con el
permiso de `SDEI/` («Permiso denegado»); no se leyó nada de la carpeta.
