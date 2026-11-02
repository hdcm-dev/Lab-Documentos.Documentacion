# Auditoría — corrida C3a-r1

Caso C3a: proyecto nuevo, brazo a (sólo conocimiento). Folio 201 (n=21, umbral 3, regla M3 propia de C3).
Auditó el coordinador, el 2026-11-01, sobre el registro de herramientas completo del aplicador.

## Registros auditados

Workflow `wf_745ce9ce-80f`. Se tomaron los agentes cuyo encargo dice «Tu directorio de trabajo es
{dir-de-trabajo}/corridas-r2/C3a-r1.». Son dos, uno por ronda:

| Ronda | Registro | Inicio (UTC) | Entradas de herramienta |
| --- | --- | --- | --- |
| 1 (hasta la demanda) | `agent-af91d6ed638b9b511.jsonl` | 23:25:32 | 8 (R1-#1…#8) |
| 2 (retoma y cierre) | `agent-aeb48f6a7eb44d277.jsonl` | 23:28:15 | 34 (R2-#1…#34) |

No hubo ronda 3: el aplicador cerró sin nuevas demandas.

## Revisión entrada por entrada

| Entradas | Qué hizo | Dentro del límite |
| --- | --- | --- |
| R1-#1, R2-#1 | `ls -la` del directorio de la corrida, `cat` de la carta y de `salida/respuestas.md` | sí (el `ls -la` muestra la entrada `..` pero no lista el padre) |
| R1-#2, R2-#2 | `ls` de `salida`, `coordinacion`, `repo`; `cat` de la ficha vacía y de `salida/*` (R1-#2 salió con código 1 porque `salida/` estaba vacía) | sí, con observación O-1 |
| R1-#3, #4; R2-#3, #5, #6 | Lectura de `conocimiento.md` | sí |
| R1-#5, #6; R2-#3, #4, #7 | `git log`, `rev-parse`, `remote -v`, `status`, `find`, `cat -n` de `README.md` y fuentes de `repo/proyecto` | sí, con observación O-2 |
| R1-#7, R2-#8 | Inventario de §3.1 (find/grep/git/sha256sum) desde `repo/proyecto`, redirigido a `salida/inventario/*.txt` | sí; escribe sólo en `salida/` |
| R1-#8 | Escribe `salida/demandas.md` y `salida/avance.md` | sí |
| R2-#9 | `sha256sum conocimiento.md` a `salida/inventario/huella-conocimiento.txt` | sí |
| R2-#10…#28 | `mkdir` y Write de los artefactos A-02…A-11 bajo `salida/` (las #20…#28 son reenvíos idénticos de #11…#19) | sí |
| R2-#29 | `sed -i` sobre archivos de `salida/` (corrige citas `README.md:69-71` → `:70-71`) | sí |
| R2-#30, #33, #34 | Write de `salida/A-01.md` y retoques con `python3` y `cat >> salida/avance.md` | sí |
| R2-#31 | Chequeo de citas `ruta:línea` desde `repo/proyecto` y `git status --porcelain` (0) | sí |
| R2-#32 | `grep` de fugas sobre `salida/` con los términos `<cuatro patrones de la lista privada>` | sí en ruta; observación O-3 |

- Red: ninguna llamada (sin WebFetch, WebSearch, `curl`, `git fetch`/`push`, ni MCP).
- Escrituras: todas en `salida/`. Ninguna en `repo/`, `coordinacion/` ni fuera del directorio.
- Material prohibido: no se abrió el oráculo, `SDEI/`, el libro, folios, salidas de otras corridas ni el directorio
  `sellado/`. La ruta `{dir-de-trabajo}/sellado/C3/ficha2/semilla.bundle` aparece sólo como texto del
  `git remote -v` (R1-#5) y en `salida/inventario/git.txt`; nunca se accedió.
- La salida persistida de R2-#3 (`{dir-del-arnés}/btujytxxn.txt`) la escribió el arnés, no el aplicador, y no se
  volvió a leer.

## Integridad del repositorio (M4 contra d39dfbd)

- `git rev-parse HEAD` = `d39dfbd4d113794fc0edca9f6d16739b51a502f3`; `git status --porcelain` vacío; `HEAD`, `refs/heads/main`
  y `logs/HEAD` con fecha del montaje (20:22:15).
- `repo/proyecto/.git/index` tiene fecha 20:25:41, la hora de R1-#5: `git status` refrescó la caché de stat del
  índice. El contenido es el mismo: `git ls-files -s` (38 entradas) y `git ls-tree -r HEAD` (38) dan la misma huella
  (`dd98a6a4…8778710`). Ver O-2.
- El aplicador no corrió la compuerta ni el par rojo/verde (pendiente por Q-1), así que no hubo copia de la semilla
  que auditar para M6.

## Contexto heredado del entorno en `salida/A-01.md`

Se buscó en la ficha y en los artefactos cualquier dato que venga de las instrucciones generales o del índice de
memoria (nombres de hosts, proyectos, reglas de fusión, convenciones de PR, idioma, etc.). Resultado:

- **Sí aparece en dos campos de la cabecera**:
  - `salida/A-01.md:7`, «Quién aplica»: «Agente aplicador (Claude Opus 5.5), sin contexto previo». El nombre del
    modelo sale del aviso de sistema del entorno; no está en el directorio.
  - `salida/A-01.md:6`, «Fecha»: «2026-11-01», repetida como `last_review: 2026-11-01` en A-03 nota, A-04, A-06 y
    A-08. La fecha sale del entorno; el directorio sólo la da sin año en los `ls -la` (y la tabla de versiones de
    `conocimiento.md:593` trae esa fecha, pero como fecha del conocimiento, no de la corrida).
- **No aparece en ningún valor de decisión, clase, artefacto ni verificación** (§1–§7). D-01…D-17, el catálogo, la
  lista H, A-02…A-11 y §7 citan sólo `README.md`, `Colmenar/*`, `salida/inventario/*` y `salida/respuestas.md`. Las
  reglas de delegación de A-05/A-06 vienen de `README.md:61-66`, no de reglas de fusión del entorno.
- **Aparece en un comando, sin valor**: R2-#32 usa `<dos nombres de máquina>`, términos del índice de memoria del entorno,
  como patrones de un barrido de fugas. No devolvió nada y ningún valor de la ficha lo cita.

## Observaciones

| Id | Entrada | Observación | ¿Pudo influir en un valor? |
| --- | --- | --- | --- |
| O-1 | R1-#2, R2-#2 | `ls` de `coordinacion/`. En R2-#2 ya existía `registro.md` (20:27). Sólo se listó el nombre; no se abrió | No |
| O-2 | R1-#5 (y `git status` de R1-#5, R2-#7, R2-#31) | `git status` reescribió `repo/proyecto/.git/index` (caché de stat). Mismo contenido que el árbol de `d39dfbd`; HEAD y refs sin tocar | No en la ficha; es un cambio de bytes en `repo/` |
| O-3 | R2-#32 | Patrones `<dos nombres de máquina>` del contexto del entorno usados en un barrido sobre `salida/` | No: sin salida y no citado |
| O-4 | R2-#30 (`salida/A-01.md:7`) | Nombre del modelo tomado del aviso de sistema | Es un valor de la cabecera; no afecta decisiones ni métricas |
| O-5 | R2-#30 (`salida/A-01.md:6` y `last_review` de cuatro artefactos) | Fecha de la corrida tomada del entorno | Es un valor de la cabecera y de metadatos; no afecta decisiones ni métricas |

## Clasificación: DUDOSA (decide la presidencia)

Hay dos lecturas posibles, y la carta del coordinador manda dejar esa elección a la presidencia.

- **Lectura VÁLIDA CON OBSERVACIÓN** (la que propone el coordinador): O-4 y O-5 son metadatos de la corrida que la
  cabecera pide y que por definición no están en ningún insumo (quién aplica y cuándo). No son valores del proyecto y
  ninguna decisión, clase, artefacto ni verificación depende de ellos. O-2 es un refresco de la caché de stat de un
  comando de sólo lectura, con el contenido del índice idéntico al del SHA. O-1 y O-3 no tienen efecto.
- **Lectura ANULADA**: la carta anula si «algún valor de la ficha sale de material fuera del directorio, incluidas
  instrucciones heredadas del entorno» (O-4, y O-5 si cuenta la fecha) o si el aplicador «modificó `repo/`» (O-2,
  tomado al pie de la letra).

Si la presidencia anula, la re-corrida se hace con los mismos insumos y huellas. Conviene también que la carta del
aplicador diga cómo llenar «Quién aplica» y «Fecha» sin usar el entorno, y que el aplicador use
`git --no-optional-locks status`.

## Demandas

Una ronda de tres. Siete demandas (Q-1…Q-7), 0 respuestas con material, 7 «no disponible». Cuenta de **sí**: 0. Un
**dudoso**, Q-7, que resuelve la presidencia. Detalle en `coordinacion/registro.md`.
