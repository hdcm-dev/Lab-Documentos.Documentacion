# Auditoría de la ronda 1 de corridas ciegas

Coordinador de ensayos del expediente 0003, 2026-11-01. La ceguera de los aplicadores se garantiza con un coordinador
que audita el registro de cada sesión (decisión del PO del 2026-11-01). Esta es la auditoría de las seis corridas de
la ronda 1: C0-r1, C0-r2, C1-r1, C1-r2, C2-r1, C2-r2.

## Método

`auditar_corrida.py <registro.jsonl> <dir-de-trabajo> --json <salida>` lee el registro de la sesión del aplicador,
extrae cada `tool_use` y marca:

- **(a) fuera del directorio**: rutas absolutas fuera de `{dir-de-trabajo}`, `cd` que salen de él, `~`/`$HOME`,
  `Read`/`Grep`/`Glob` con ruta externa, y comandos sin anclaje (rutas relativas sin `cd` al directorio: se resolverían
  contra el cwd heredado de la sesión, que está fuera). Rutas de sistema (`/usr/`, `/bin/`, `/dev/null`, …) van aparte,
  como inocuas.
- **(b) red**: `WebFetch`, `WebSearch`, y comandos `curl`, `wget`, `ssh`, `git clone/fetch/pull/push`, `gh`, `npx`,
  instaladores; URLs en el comando.
- **(c) escrituras fuera de `salida/`**: `Write`/`Edit` y redirecciones de Bash con destino fuera de
  `{dir-de-trabajo}/salida/`; comandos que escriben (`cp`, `mv`, `rm`, `mkdir`, `sed -i`, `git` que modifica) se marcan
  para revisión.
- **Contexto heredado en la ficha**: términos distintivos del contexto inicial que la sesión recibió sin pedirlo
  (índice de memoria del entorno, cwd, datos de sesión) que aparecen en `salida/A-01.md` y **no** están en ningún archivo
  de texto de `{dir-de-trabajo}` fuera de `salida/`.

El script marca de más a propósito (los patrones de `grep`, los heredocs y los artefactos escritos contienen rutas y
comandos que no se ejecutan). Cada marca se revisó a mano; la columna «reales» cuenta lo que quedó.

Además se verificó que ninguna sesión recibió mensajes a mitad de turno, que ninguna usó `Agent`, `ToolSearch`,
`WebFetch` ni `WebSearch`, y que no quedaron `__pycache__` ni `.pyc` en los `repo/`.

## Resultado

| Corrida | Llamadas | Marcadas por el script | Fuera del dir. (reales) | Red (real) | Escrituras fuera de `salida/` (reales) | Contexto heredado en la ficha | Clasificación |
|---|---|---|---|---|---|---|---|
| C0-r1 | 36 (Bash 35, Write 1) | 10 | 0 | 0 | 0 | 0 de 458 términos | **VÁLIDA** |
| C0-r2 | 40 (Bash 33, Read 2, Write 5) | 8 | 0 lecturas; 1 patrón de búsqueda con 2 nombres de máquina tomados del contexto heredado | 0 | 0 | 0 de 458 | **VÁLIDA CON OBSERVACIÓN** |
| C1-r1 | 40 (Bash 37, Read 2, Write 1) | 9 | 2 lecturas de volcados de su propia salida de comando | 0 | 0 | 0 de 458 | **VÁLIDA CON OBSERVACIÓN** |
| C1-r2 | 39 (Bash 35, Read 2, Write 2) | 14 | 0 | 0 | 0 | 0 de 458 (1 coincidencia descartada) | **VÁLIDA** |
| C2-r1 | 28 | 9 | 0 | 0 | 0 | 0 de 458 | **VÁLIDA** |
| C2-r2 | 33 | 8 | 0 | 0 | 0 | 0 de 458 | **VÁLIDA** |

Ninguna corrida se anula: ninguna leyó material del laboratorio fuera de su directorio.

## Adjudicación de las marcas (C0 y C1)

**C0-r1.** Marcas (a): un prefijo de directorio personal y `/*/` son patrones de `grep` y comodines de bucle, corridos con `cd` a
`{dir-de-trabajo}/repo/LD` o a `{dir-de-trabajo}/salida`. Marcas (c): las redirecciones van a `$O=../../salida/_inventario`
(dentro de `salida/`); `mkdir`, `cp`, `sed -i` operan en `salida/`. Los términos de barrido de privacidad que usó ya
habían aparecido en resultados previos de su `repo/`.

**C0-r2.** Marcas (a) `/fixtures/*` y dos prefijos de rutas locales: patrones de `find -not -path` y de `grep`. Marca (b) `npx`: es
`which … npx` (consulta de presencia local, sin ejecutarlo). Marcas (c): `salida/docs/plantada.md` creado y borrado para
el par rojo/verde. **Observación:** el patrón del barrido de privacidad de la llamada 23 incluye dos nombres de máquina
que no figuran en `{dir-de-trabajo}` ni en ningún resultado previo de la sesión; vienen del contexto heredado (índice de
memoria del entorno). Devolvió 0 coincidencias y no aparecen en `salida/`: no influyó en la ficha, pero muestra que el
contexto heredado llega al aplicador.

**C1-r1.** **Observación:** las llamadas 2 y 7 son `Read` de dos archivos fuera del directorio: los volcados que el
arnés escribe cuando la salida de un comando de la propia sesión es demasiado larga («salida persistida»). Su contenido
es la salida de comandos de la corrida sobre su `repo/`; inocuo. Resto: `-not -path '*/node_modules/*'`, `/.git/*`,
`/{etiqueta-runner}/g` y `/v1/`, `/openapi/v1.json` son patrones y texto de artefactos; las redirecciones de la llamada
33 (heredocs) van a `salida/LG/…` y `salida/LGD/…` tras un `cd` en otra línea; la copia `salida/_rv` del par rojo/verde
se borra al final.

**C1-r2.** Marcas (a) un prefijo de directorio personal, `/IA/IA`, `/obj/`, `/node_modules/*`: patrones de `grep`/`find`. Marca (b) `git clone`
y `https://github.com/${REPO_CODIGO}.git`: texto de `.github/workflows/atraso.yml`, escrito en `salida/LGD/` (artefacto,
no ejecutado). Marca (c): heredocs dentro de `salida/`. Contexto: la única coincidencia, «Runners», es una etiqueta
genérica de la ficha con evidencia en `repo/` (`ci.yml`, `verificar.yml`, `e2e.yml`); se descarta.

**C2-r1, C2-r2** ({servicio-privado}). Sólo cifras: 17 llamadas marcadas en total, 17 falsos positivos (patrones de
búsqueda, un `gh` dentro de un workflow escrito en `salida/`, copias de verificación dentro de `salida/`, `/dev/null`).
0 accesos fuera del directorio, 0 red, 0 escrituras fuera de `salida/`, 0 términos del contexto heredado en la ficha.
El detalle está en la carpeta privada del expediente.

## Contexto heredado

Las seis sesiones recibieron, sin pedirlo, el mismo contexto inicial: el índice de memoria del entorno (~25 KB), el
directorio de trabajo de la sesión (fuera de la corrida) y datos de la cuenta. De ese contexto se extrajeron 458
términos distintivos. En las fichas aparecen entre 9 y 16 de ellos, pero todos están también en el directorio de la
corrida (nombres de proyectos y repositorios que la memoria también menciona). Ningún término del contexto sin origen
posible en el directorio llegó a `salida/A-01.md`; tampoco rutas de la sesión, correo ni referencias a la memoria.

**Límite.** Un término que está a la vez en el contexto y en `repo/` no distingue la fuente. **Recomendación para la
ronda 2:** lanzar los aplicadores sin el índice de memoria y con el cwd en `{dir-de-trabajo}`; C0-r2 prueba que el
contexto llega y se usa, aunque esta vez sin efecto.

## Archivos

- `auditar_corrida.py`: el script.
- Las salidas crudas por llamada (`<corrida>.json`) no se publican: contienen comandos literales con nombres de
  máquina y rutas locales. Quedan fuera del repositorio.
