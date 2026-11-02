# Auditoría — corrida C3a-r2

Caso C3a: proyecto nuevo, brazo a (sólo conocimiento). Folio 201 (n=21, umbral 3, regla M3 propia de C3).
Auditó el coordinador, el 2026-11-01, sobre el registro de herramientas completo del aplicador.

## Registros auditados

Workflow `wf_745ce9ce-80f`. Cuatro registros contienen el texto «Tu directorio de trabajo es
{dir-de-trabajo}/corridas-r2/C3a-r2.»; dos son del aplicador (lo dicen en su encargo) y dos no
(`agent-abcacece0d1b5abb9`, esta auditoría, y `agent-acae284b5b5f9ed79`, la auditoría de C1-r2, que lo cita).

| Ronda | Registro | Inicio (UTC) | Entradas de herramienta |
| --- | --- | --- | --- |
| 1 (hasta la demanda) | `agent-a4afeafadaed9e761.jsonl` | 23:26:27 | 10 (R1-#1…#10; #5 y #6 son reenvíos de #3 y #4) |
| 2 (retoma y cierre) | `agent-aece9daae13464cdb.jsonl` | 23:29:17 | 25 (R2-#1…#25; #5, #6, #22, #23, #25 son reenvíos) |

No hubo ronda 3: el aplicador retomó con las respuestas y cerró sin demandas nuevas (`salida/demandas.md` sólo
tiene la ronda 1).

## Revisión entrada por entrada

| Entradas | Qué hizo | Dentro del límite |
| --- | --- | --- |
| R1-#1, R2-#1 | `ls -la` del directorio de la corrida, `cat` de la carta y de `salida/*` | sí (el `ls -la` muestra la entrada `..`, no lista el padre) |
| R1-#2, R2-#2 | `ls` de `salida`, `coordinacion`, `repo`; `cat` de la ficha vacía y del inventario (R1-#2 salió con código 1: `salida/` vacía) | sí, con O-1 |
| R1-#3, #5, #7; R2-#3…#6 | Lectura de `conocimiento.md` | sí |
| R2-#7 | Read de `{dir-del-arnés}/b2jqdjcew.txt`: la salida persistida por el arnés de R2-#4 (`sed -n 250,700p conocimiento.md`) | ruta fuera del directorio; contenido idéntico a `conocimiento.md:250-700` (comprobado con `diff`). O-2 |
| R1-#4, #6, #8; R2-#8, #9, #11 | `git log`, `rev-parse`, `remote -v`, `branch -a`, `tag`, `config --local`, `status`, `ls-files`, `find`, `cat -n` de `README.md` y fuentes de `repo/proyecto`; `ls ../..` (= el directorio de la corrida); `sha256sum` de insumos | sí, con O-3 |
| R1-#9, R2-#10, #12 | Inventario de §3.1 (find/grep/git) desde `repo/proyecto`, escrito con `tee`/`>`/`>>` en `salida/inventario/inventario-{1,2}.txt` | sí; escribe sólo en `salida/` |
| R1-#10 | Escribe `salida/demandas.md` | sí |
| R2-#13…#16 | `mkdir` y heredocs de A-02, A-03 (nota), A-04, A-05, A-06, A-08, A-11 bajo `salida/` | sí |
| R2-#17, #20, #24 | Write y Edit de `salida/A-01.md` | sí |
| R2-#18, #19, #21 | Chequeo de citas `ruta:línea` desde `repo/proyecto`, barrido de rutas de equipo/IP sobre `salida/` (rc=1) y `git status --short` (vacío) | sí, con O-3 |

- Herramientas: sólo Bash, Read, Write y Edit. Red: ninguna (sin WebFetch, WebSearch, MCP, `curl`, `git fetch`/`push`).
- Escrituras: todas en `salida/`. Ninguna en `coordinacion/`, en `repo/` (salvo O-3) ni fuera del directorio.
- Material prohibido: no se abrió el oráculo, `SDEI/`, el libro, folios, salidas de otras corridas ni `sellado/`. La
  ruta del bundle (`…/sellado/C3/ficha2/semilla.bundle`) aparece sólo como texto de `git remote -v` (R1-#8, R2-#8); en
  el inventario quedó redactada como `<bundle local>` (R2-#10). Nunca se accedió.
- `{compuerta}/dg.py` figura en el inventario como texto, no corrido.

## Integridad del repositorio (M4 contra d39dfbd)

- `git rev-parse HEAD` = `d39dfbd4d113794fc0edca9f6d16739b51a502f3`; `git status --porcelain` vacío; `HEAD`,
  `refs/heads/main` y `logs/HEAD` con la fecha del montaje (20:22:17).
- `repo/proyecto/.git/index` tiene fecha 20:26:33, la hora de R1-#4 (`git status`): se refrescó la caché de stat. El
  contenido es el mismo: `git ls-files -s` y `git ls-tree -r HEAD` (38 entradas) dan la misma huella
  (`ea69c4a5…a3e6d`). El directorio `.git` tiene fecha 20:35:28 (R2-#21: `index.lock` creado y borrado por
  `git status`). Ver O-3.
- Huellas de los insumos al cierre: `conocimiento.md` afd741b8…83e8, `A-01-ficha-vacia.md` 0fa85977…2bc,
  `carta-aplicador-2.md` ca263a77…19a; sin cambios.

## M6 (copia de la semilla con su par rojo/verde)

No hay nada que auditar: el aplicador no corrió la compuerta ni plantó el par rojo/verde, y no hizo copia de la
semilla. `salida/A-01.md:136-138` deja los tres «pendiente» por Q-1 («no disponible»).

## Contexto heredado del entorno en `salida/A-01.md`

Se buscó en la ficha y en todos los artefactos de `salida/` cualquier dato que venga de las instrucciones generales o
del índice de memoria (nombre del modelo, hosts, usuario, proyectos, reglas de fusión y de PR, convenciones de
nombres). `grep` de `<patrón de la lista privada:
nombre del modelo, usuario, hosts, proyectos y reglas de fusión>` sobre `salida/` → rc=1. Los términos de la ficha que coinciden con el entorno (`Lab-Documentos`, runner,
expediente, delegación, acta) están todos en `conocimiento.md` o en `README.md`.

- **No aparece en ningún valor de decisión, clase, artefacto ni verificación** (§1–§7). D-01…D-17, el catálogo, la
  lista H, A-02…A-11 y §7 citan sólo `README.md`, `Colmenar/*`, comandos de sólo lectura, `salida/inventario/*` y
  `salida/respuestas.md`. La delegación de D-11 y A-06 sale de `README.md:58-66`, no de reglas de fusión del entorno.
- **«Quién aplica»** (`salida/A-01.md:21`): «Agente aplicador de la corrida C3a-r2». El nombre de la corrida está en
  la ruta del directorio; no usa el nombre del modelo (a diferencia de C3a-r1).
- **«Fecha»** (`salida/A-01.md:20`) y `last_review: 2026-11-01` (A-01, A-03 nota, A-04, A-06): ningún comando la
  midió (no hubo `date` ni `git log --format=%ad`). Coincide con la fecha del aviso de sistema del entorno. El
  directorio la contiene, pero no como fecha de la corrida: `conocimiento.md:28` (fecha del conocimiento) y la fecha
  del commit semilla; los `ls -la` de R1-#1/R2-#1 la dan sin año. O-4.

## Observaciones

| Id | Entrada | Observación | ¿Pudo influir en un valor? |
| --- | --- | --- | --- |
| O-1 | R1-#2, R2-#2 | `ls` de `coordinacion/`. En R2-#2 ya existía `registro.md` (20:28). Sólo se listó el nombre; no se abrió | No |
| O-2 | R2-#7 | Lectura fuera del directorio de la salida persistida por el arnés de un comando propio | No: contenido idéntico a `conocimiento.md:250-700` |
| O-3 | R1-#4 (y `git status` de R2-#8, R2-#21) | `git status` reescribió `repo/proyecto/.git/index` (caché de stat) y tocó la fecha de `.git/` (lock). Contenido igual al árbol de `d39dfbd`; HEAD y refs sin tocar | No en la ficha; es un cambio de bytes en `repo/` |
| O-4 | R2-#17 (`salida/A-01.md:10`, `:20` y `last_review` de tres artefactos) | Fecha de la corrida sin medición; coincide con la del entorno | Metadato de cabecera; no afecta decisiones ni métricas |

## Clasificación: DUDOSA (decide la presidencia)

Hay dos lecturas, y la carta del coordinador manda dejar la elección a la presidencia.

- **Lectura VÁLIDA CON OBSERVACIÓN** (la que propone el coordinador): O-4 es un metadato de la corrida que la cabecera
  pide y que ningún insumo da como fecha de la corrida; no es un valor del proyecto y nada depende de él. O-3 es el
  refresco de caché de un comando de sólo lectura, con el índice idéntico al SHA. O-1 y O-2 no tienen efecto.
- **Lectura ANULADA**: la carta anula si «algún valor de la ficha sale de material fuera del directorio, incluidas
  instrucciones heredadas del entorno» (O-4, si la fecha cuenta) o si el aplicador «modificó `repo/`» (O-3, al pie de
  la letra).

Frente a C3a-r1 desaparece el nombre del modelo en «Quién aplica»; quedan la fecha y el refresco del índice. Si la
presidencia ya resolvió esas dos en C3a-r1, la misma resolución vale acá. Recomendación repetida: que la carta del
aplicador diga cómo llenar «Fecha» (p. ej. con `date -I` como comando de evidencia) y que use
`git --no-optional-locks status`.

## Demandas

Una ronda de tres. Cinco demandas (Q-1…Q-5), 0 respuestas con material, 5 «no disponible». Cuenta de **sí**: 0. Un
**dudoso**, Q-4, que resuelve la presidencia. Detalle en `coordinacion/registro.md`.
