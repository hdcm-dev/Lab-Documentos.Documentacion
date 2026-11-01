---
doc_id: EXP0003-F012
doc_type: informe
title: Informe de la comisión del Lector sin contexto — dónde se traba quien llega sin contexto al cuerpo SDEI, al libro y al conocimiento de especificación
status: vigente
origin: agent
confidence: alta en lo medido (comandos con salida del 2026-11-01 y cinco ensayos en contenedor efímero o copia descartable); media en las posiciones, que son lectura de quien llega sin contexto y no diseño
owner: comisión C-LECT (núcleo permanente) de la mesa de la reedición DocsAsCode
last_review: 2026-11-01
audience: [presidencia, refutador, análisis de decisiones, jurado de veredicto, editores, PO]
traces: [TP, EXP0003-F001, EXP0003-F004, DB-R02-02]
---

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-01 |
| Autor | Comisión C-LECT, silla «Lector sin contexto» (núcleo permanente), a ciegas |
| Corrige | — |

| Cabecera de comisión | Valor |
| --- | --- |
| Rol | ¿Puede trabajar con el libro y con el conocimiento sin preguntar? Cada pregunta es un hallazgo (`004-acta-jurado-composicion.md:202`) |
| Preguntas a cargo | P-03, P-06, P-17, P-23, P-24, P-26 (`02-Propuesta-De-Panel.md` §7) |
| No-competencia | Proponer correcciones de fondo. Este informe dice dónde se trabó y qué alternativa le deja menos preguntas a quien llega; no redacta el texto corregido |
| Norma | `IA.Knowledge.Base/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` 3.1 (`MEP`) |
| Secciones de `MEP` leídas | Mapa de carga (`MEP:95-115`), fila «Sos una comisión» (`MEP:106`); §2.2; §3.2; §3.3; §5.1 (lectura P0–P3, `MEP:371`). §4 por la propuesta de panel (`PP` §8, criterio de corte) |
| Otros documentos cargados | `Knowledge-Cadena-De-Consecuencias.md` 2.0 §2 (antes de recomendar); `Rule-Forma-De-Conocimiento.md` 1.3 §0, §3.1 y §3.12 (para P-23 y P-24); `Knowledge-Mesa-Consulta-A-Un-Tercero.md` 2.0, por nombre, sin uso: esta comisión no consultó a nadie de afuera |
| Insumos leídos | El pedido (`TP`, 105 líneas, SHA-256 `da388e9d…74b37`, coincide con `PP` §2); `PP` (contrato de entrada); folios 001 y 004. El cuerpo SDEI entero en `0bed863` leído directo. **No se leyeron** `Nucleo-N1` a `Nucleo-N7`, `01-Cohesion-Global.md` ni informes de otras comisiones (`mesa/01x-*`) |
| Medios propios | `grep`, `sed`, `git` de sólo lectura; dos corridas de la prueba de concepto en un contenedor efímero `mcr.microsoft.com/dotnet/sdk:10.0` (SDK `10.0.403`); dos corridas de `scripts/ci-local.sh` sobre una copia descartable del worktree; seis consultas web |
| Arnés | El mismo que el resto de la mesa (Claude Code). La carta pedía «de otro arnés si se puede»: no se pudo desde este despacho, y se declara |

## Índice

1. [Definiciones y forma de este informe](#1-definiciones-y-forma-de-este-informe)
2. [Cómo leyó esta comisión](#2-cómo-leyó-esta-comisión)
3. [Hallazgos](#3-hallazgos)
4. [Dictamen por pregunta](#4-dictamen-por-pregunta)
   1. [P-03 — Partes, orden y anexos del libro](#p-03--partes-orden-y-anexos-del-libro)
   2. [P-06 — Cómo entra `Lanzar-Example`](#p-06--cómo-entra-lanzar-example)
   3. [P-17 — Quién decide la fase 1b en `ESC-SDEI-1`](#p-17--quién-decide-la-fase-1b-en-esc-sdei-1)
   4. [P-23 — Forma del conocimiento](#p-23--forma-del-conocimiento)
   5. [P-24 — Neutralidad respecto de SDD](#p-24--neutralidad-respecto-de-sdd)
   6. [P-26 — Oráculo e insumos de cada caso](#p-26--oráculo-e-insumos-de-cada-caso)
5. [Ensayos corridos](#5-ensayos-corridos)
6. [Fuentes externas](#6-fuentes-externas)
7. [Lo que revisé y está bien](#7-lo-que-revisé-y-está-bien)
8. [Lo no verificado](#8-lo-no-verificado)
9. [Inventario de lo creado y lo borrado](#9-inventario-de-lo-creado-y-lo-borrado)

---

## 1. Definiciones y forma de este informe

| Término | Definición en este informe |
| --- | --- |
| **Traba** | Un punto donde quien llega sin contexto no puede seguir sin preguntarle a alguien, porque el texto calla, se contradice o lo manda a algo que no existe para él |
| **Pregunta del lector** | La pregunta que esa traba lo obliga a hacer, escrita como la haría. Cada una es un hallazgo (carta de la silla) |
| **Clase de ancla** | E1: medición mecánica (comando con su salida). E2: regla o decisión escrita, con ruta y línea. C: opinión, sólo funda una pregunta (`MEP` §3.2) |
| **P0–P3** | La lectura del contrato de entrada (`PP` §8): P0 viola una restricción dura o hace imposible el objetivo; P1 retrabajo o lectura divergente; P2 pérdida acotada; P3 claridad |
| `SDEI/` | `Lab-Documentos/Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/` en `0bed863` |
| `{dir-de-trabajo}` | La raíz del espacio de trabajo de esta mesa; no se transcribe |

Las rutas privadas, el nombre del servicio privado y el host de pruebas no aparecen: se usan
`{servicio-privado}`, `{dir-de-trabajo}` y `{host-de-pruebas}`.

## 2. Cómo leyó esta comisión

Se tomaron los dos objetivos que el pedido le da a quien llega: «que los agentes de IA o humanos en otro contexto
diferente pudieran aplicarlos» (`TP:18`) y «material suficiente para que un grupo de desarrolladores […] trabaje»
(`TP:70`). Con eso se recorrieron las tres rutas del cuerpo (`SDEI/README.md:94-96`) y se intentaron tres tareas
concretas sin preguntar a nadie:

1. Resolver `EJR-SDEI-05` con el cuerpo, sin mirar la clave, y después compararla.
2. Levantar la prueba de concepto de ayuda por rol siguiendo `Lanzar-Example.md` al pie de la letra.
3. Escribir un conocimiento en `SDEI/Conocimientos/` con la forma de la base y ver qué dice la compuerta.

El libro y el conocimiento todavía no existen (`ls SDEI/Conocimientos` → «No existe el fichero o el directorio»;
`find` de `*Designing-Specification*` en los dos worktrees → vacío). Lo que este informe dice del libro y del
conocimiento es lo que el cuerpo actual le deja a quien los va a escribir y a quien los va a leer.

## 3. Hallazgos

Doce, el tope. Cada uno con la pregunta que obligó a hacer.

| Id | P | Ancla | Dónde se trabó | Pregunta del lector | Evidencia |
| --- | --- | --- | --- | --- | --- |
| LECT-01 | P1 | E2 | `ESC-SDEI-1`, fase 1b: cuatro respuestas para quién decide | «¿Quién acepta la fila que pide `EJR-SDEI-05`: la analista, el docente, el responsable de la guía o el PO?» | `00-Marco.md:145` (analista); `TEM-02:73` y `:246` (`ACT-SDEI-2`); `TEM-02:166` («Docente o responsable de la guía»); `Ejercicios.md:126` («la analista o el PO»). Además `00-Marco.md:148`: el docente (`ACT-SDEI-5`) «no decide» el contenido normativo, y «responsable de la guía» no es un actor de la tabla |
| LECT-02 | P1 | E1 | `Lanzar-Example.md` no corre fuera del equipo que lo escribió | «¿Dónde está `$P` en mi máquina? ¿Qué es `/LAB/…`?» | `Lanzar-Example.md:18` y `:35`: ruta absoluta del espacio de trabajo del equipo. `00-Marco.md:170`: «en lo versionado no van rutas del equipo». En un clon, esa ruta no existe |
| LECT-03 | P2 | E1 | `Lanzar-Example.md` y el README de la prueba remiten a la guía obsoleta, y la guía obsoleta remite de vuelta | «¿Dónde está la explicación vigente de lo que esta prueba demuestra?» | `Lanzar-Example.md:27` y `Prueba-Ayuda-Por-Rol/README.md:3` → «sección 7 de `Sistema-Documentador-Tecnico-Guide.md`» (`status: obsoleto`); su tabla de destinos lleva 7.8 a `Lanzar-Example.md` (`Sistema-Documentador-Tecnico-Guide.md:70`). El destino vigente, `TEM-05` §3.3, no aparece en ninguno de los dos |
| LECT-04 | P2 | E1 | `Lanzar-Example.md:140` cita `Rule-Evidences.md` | «¿Qué dice esa regla y dónde está?» | `find {worktree LD} -name 'Rule-Evidences*'` → vacío; `grep -rn Rule-Evidences` → sólo esa línea |
| LECT-05 | P2 | E1 | Versiones móviles en el procedimiento | «¿Con qué versión de `@devcontainers/cli` y de `cloudflared` se midió lo que dice "Esperado"?» | `Lanzar-Example.md:51`, `:59` (`@latest`), `:92` (`cloudflared:latest`); ídem `Prueba-Ayuda-Por-Rol/README.md:19`, `:30` |
| LECT-06 | P2 | E1 | Libro de un solo archivo: 7 encabezados repetidos siete veces y 43 enlaces a anclas de los temas | «Si sigo `#anexo` en el libro, ¿a qué capítulo voy?» | `cat TEM-0*.md \| grep -E '^#{2,3} ' \| sort \| uniq -c` → «Definición», «Aplicación por escenario», «Ejemplos concretos», «Preguntas guía», «Criterios de calidad», «Anexo», «Índice»: 7 cada uno. `grep -o 'TEM-0[1-7][^)]*\.md#[^)]*'` → 43. En un solo archivo GitHub sufija `-1`, `-2`… (§6, F-6): el ancla lleva al primer capítulo que la tenga |
| LECT-07 | P1 | E1 | El conocimiento en `SDEI/Conocimientos/` con sólo la cabecera de la base da rojo | «¿Qué cabecera lleva: la del cuerpo, la de la base o las dos?» | Ensayo 3 (§5): `ERROR sin-frontmatter` en PR-2. `dg.py:267-276`: una carpeta es cuerpo nuevo si un ancestro tiene README con `corpus_id` |
| LECT-08 | P1 | E1 | El alias del caso privado contiene la palabra que la compuerta de neutralidad de la base prohíbe | «Si el conocimiento nombra el escenario 4 por su alias, ¿pasa la prueba de neutralidad?» | `neutralidad.txt:14`: `SDD\t\bSDD\b`; `echo "el alias SDD-B" \| grep -cP '\bSDD\b'` → 1. Alias en `00-Marco.md:96`, `:170`; `Glosario.md:73` |
| LECT-09 | P1 | E1 | La ia-db que el pedido manda leer de Geometría tiene tres estados | «¿Cuál README de la ia-db es el insumo: el de `main`, el de la rama `ia-db/4.0` o el que está en disco?» | `git status --short \| wc -l` → 33 cambios sin commitear sobre `main` `0202722`; `git diff --stat` → 15 archivos, 479 inserciones, 2206 borrados; `diff -rq` contra `origin/ia-db/4.0` (`b47d22b`, 2026-10-26) → 32 diferencias. El estado en disco no lo puede reproducir nadie de afuera |
| LECT-10 | P2 | E1 | «Hay cuatro familias de siglas» con seis filas | «¿Cuáles son las cuatro?» | `Glosario.md` §1: la frase y seis filas (`PR`, `AI`, `AK`, `G`, `CQ/PE/VER`, `CL`) |
| LECT-11 | P3 | E1 | Variables usadas antes de definirse en el procedimiento | «¿De dónde saco `$CID` y `$W` en el paso 1?» | `Lanzar-Example.md:54` dice «guardar el `containerId`»; `$CID` aparece en `:70` y se define en `:76`, junto con `$W` |
| LECT-12 | P3 | E2 | Un documento de estudio que habla en voz de agente | «¿"Reportar al usuario" me lo dice a mí, que soy el usuario?» | `Lanzar-Example.md:15` («Tool-Prompt»), `:119` («Reportar al usuario»), `:101` (túneles «del usuario»); frontmatter `doc_type: guia-practica` y `title` distinto del H1 (`:4` frente a `:15`) |

Ningún hallazgo es P0: no se encontró nada privado expuesto en `SDEI/` (los alias se usan como manda
`00-Marco.md:170`) ni un guion que no corra en su parte central (ensayos 1 y 2).

## 4. Dictamen por pregunta

Cada pregunta: posición, fundamento, cadena de consecuencias (`Cadena-De-Consecuencias` §2: dónde cae, cuánto pesa,
qué pierde la otra, reversibilidad), fuentes, riesgos y qué evidencia la sostendría.

### P-03 — Partes, orden y anexos del libro

**Posición.** La estructura base que trae `PP` (prólogo, partes I a VI, capítulos 1-18, anexos A-J, orden TEM-01→07)
**con las tres variantes**, y una condición de lector: **cada encabezado del libro es único en el archivo** (número
de capítulo en el título o prefijo del tema).

**Fundamento desde el lector.**

- Quien llega sin contexto entra por una de tres rutas (`README.md:94-96`). Un libro de un solo archivo pierde el
  README como puerta; la primera sección tiene que decir «si venís a aprender, a intervenir o sos un agente, empezá
  acá». Rotular cada parte por su forma (tutorial, guía práctica, referencia, explicación) le contesta al lector
  «¿esto lo leo o lo consulto?» sin preguntar (§6, F-1).
- El anexo de herramientas con versión contesta la pregunta de LECT-05.
- La sección «de la explicación al conocimiento» contesta la pregunta que más me trabó en P-23: cuándo uso el libro
  y cuándo el conocimiento.
- La condición de unicidad sale de LECT-06: con 49 encabezados repetidos y 43 enlaces a anclas, sin ella el libro
  manda al lector al capítulo equivocado sin error visible.

**Cadena.** Cae en los editores (diseño editorial y corrección de pruebas). Pesa: 49 encabezados a renombrar y 43
enlaces a reescribir (medidos, LECT-06). La alternativa sin rótulos ni anexo ahorra unas páginas y deja abiertas las
preguntas de LECT-05 y de P-23. Reversible: es estructura de un documento en borrador.

**Fuentes.** F-1 (Diátaxis), F-6 (anclas de GitHub).

**Riesgo.** Rotular por Diátaxis capítulos que mezclan formas (cada tema hoy tiene definición, ejemplos y preguntas
guía, `README.md:135-136`) obliga a decidir qué rótulo manda; si no se decide, el rótulo miente.

**Evidencia que la sostendría.** Render del libro (peritaje previsto en `PP` §6.3) con un chequeo de anclas sobre el
archivo único: 0 anclas duplicadas y los 43 enlaces resueltos al capítulo correcto.

### P-06 — Cómo entra `Lanzar-Example`

**Posición.** Ni íntegro ni sólo movido: **en el libro entra el procedimiento genérico** (variables explicadas,
versiones fijas, sin rutas ni nombres del entorno, con remisión a `TEM-05` §3.3), y **el tool-prompt de agente**
(túnel, «reportar al usuario», túneles ajenos) **va a LDD**. Es la unión de las dos ramas de la segunda alternativa.

**Fundamento desde el lector.** Seguí el documento al pie de la letra y me trabé en el paso 1 (LECT-02), y antes de
eso en el «Contexto», que me manda a un documento obsoleto (LECT-03). Pero el contenido funciona: el ensayo 1 compila
con 0 errores y el log dice exactamente lo que el paso 3 espera; el ensayo 2 da los cinco códigos de la tabla del
paso 5 (`200`, `302`, `200`, `404`, `200`) sin túnel. El README de la prueba ya trae un procedimiento casi genérico
(`Prueba-Ayuda-Por-Rol/README.md:16-34`). La traba no es el contenido sino el envoltorio de entorno.

**Cadena.** Cae en el editor de contenido y en quien mantiene LDD. Pesa: un documento de 141 líneas
(`wc -l`), del que el procedimiento útil son los pasos 1-3 y 5. Entrarlo íntegro pierde el criterio de
`00-Marco.md:170` y deja a todo lector externo trabado en el paso 1 (P1); moverlo entero a LDD deja el libro sin un
procedimiento ejecutable de la ayuda por rol, que es la evidencia de `TEM-05`. Reversible.

**Fuentes.** F-2 (Google: el lector tiene lo que necesita antes de empezar; cada marcador de posición se explica);
F-3 (Docker: una etiqueta móvil no garantiza el mismo resultado en cada build).

**Riesgo.** Fijar versiones congela fixes de seguridad (lo dice F-3); necesita quién las suba y cuándo.

**Evidencia que la sostendría.** Un lector de otro equipo, en un clon limpio, corre el procedimiento del libro y
obtiene los cinco códigos del paso 5 sin preguntar nada (la «prueba del lector sobre el tutorial» de `PP` §6.3).

### P-17 — Quién decide la fase 1b en `ESC-SDEI-1`

**Posición (nueva, entre las tres).** **Un rol, una regla**: en todos los escenarios decide 1b el rol
`ACT-SDEI-2` (analista), como dice el Marco, y la tabla de `TEM-02:164-169` dice **qué persona ocupa ese rol** en cada
escenario (en `ESC-SDEI-1`, la persona responsable de la guía). La clave de `EJR-SDEI-05` contesta con el rol y
con esa persona, no con una disyunción.

**Fundamento desde el lector.** Intenté resolver `EJR-SDEI-05` (es un caso de `ESC-SDEI-1`: un docente pide algo a
una guía) y encontré cuatro respuestas (LECT-01). El Marco dice que cada eje se define allí «y en ningún otro lugar»
(`00-Marco.md:19`); con esta lectura el Marco sigue mandando y la tabla de `TEM-02` deja de contradecirlo: sólo
nombra al ocupante. Las otras tres alternativas, tal como están escritas, dejan una pregunta abierta cada una:
«analista» sola no dice quién es la analista de un corpus de guías; «docente o responsable» choca con
`00-Marco.md:148` y con la tabla de actores; «analista o PO» no dice cuándo uno y cuándo otro.

**Cadena.** Cae en tres archivos: `TEM-02` (una celda), `Ejercicios.md` (una línea), y opcionalmente una nota en el
Marco. Pesa poco. La alternativa «docente» pierde la regla de `00-Marco.md:148`; «analista o PO» pierde la
univocidad. Reversible.

**Fuentes.** F-4 (GitHub `CODEOWNERS`: la industria nombra un responsable por ruta, que es quien aprueba).

**Riesgo.** Si en Lab-Documentos la persona responsable de la guía es el PO, el lector confunde rol y persona; la
celda tiene que decir que es el ocupante del rol, no otro actor.

**Evidencia que la sostendría.** `grep -n "1b" SDEI/**/*.md` devuelve un solo actor por escenario y la clave de
`EJR-SDEI-05` coincide con la fila `ESC-SDEI-1` de `TEM-02`.

### P-23 — Forma del conocimiento

**Posición.** **Forma estricta de la base** (once campos, §0-§10) **más el frontmatter del cuerpo**, con una
línea que diga qué versión manda.

**Fundamento desde el lector.** Medido: la forma libre o la forma de la base sola, si vive en `SDEI/Conocimientos/`
(`TP:54`), da rojo (ensayo 3, LECT-07). La doble cabecera da verde en PR-2 y en PR-5 (ensayo 4). Desde la lectura:
los campos `Consumidor` y `Condicion-de-carga` (`Rule-Forma-De-Conocimiento.md`, §3.1) contestan las dos primeras
preguntas que me hago ante un conocimiento —«¿es para mí?» y «¿cuándo lo cargo?»—, que una forma libre no garantiza.
Es lo mismo que exige el formato de habilidades de agentes de la industria: `name` y `description` obligatorios,
y la descripción dice qué hace y cuándo usarlo (F-5).

**Cadena.** Cae en quien escribe el conocimiento y en el lector. Pesa: 11 líneas de cabecera más 12 de frontmatter.
La forma libre ahorra eso y pierde el verde de la compuerta del cuerpo (medido) y las respuestas de «para quién» y
«cuándo». Reversible.

**Fuentes.** F-5 (Agent Skills), F-7 (AGENTS.md: Markdown sin esquema obligatorio, como contraste: la industria
acepta forma libre para instrucciones de repositorio, no para piezas que se eligen por su descripción).

**Riesgo.** Dos números de versión a la vista: `version` del cuerpo sólo vive en el README (`00-Marco.md:161`) y
`**Versión:**` del conocimiento en su cabecera. Si no se dice cuál manda para citar el conocimiento, el lector
pregunta.

**Evidencia que la sostendría.** El conocimiento real pasa `ci-local.sh todo` en LD y `verificar.py` de la base (la
segunda no la corrí, §8).

### P-24 — Neutralidad respecto de SDD

**Posición.** **«SDD» sólo en el apéndice por escenario** (primera alternativa), y el caso privado nombrado en el
cuerpo del conocimiento **por un rótulo que no contenga la sigla**.

**Fundamento desde el lector.** El pedido dice «en otro contexto diferente», para proyectos «nuevos o ya
existentes» (`TP:18`). El cuerpo ya reconoce que hay proyectos sin SDD (`CTX-SDEI-2`, `00-Marco.md:121-125`). Un
conocimiento que presupone SDD en su cuerpo me deja la pregunta «¿y si mi proyecto no tiene?». Además, si el
conocimiento se copia a la base (agregado AG-3 de `PP` §3.4), la compuerta de neutralidad mide `\bSDD\b`, y el alias
actual del caso privado lo dispara (LECT-08). La alternativa «sin restricción» funciona hoy en LD, pero cierra la
puerta a la base sin decirlo.

**Cadena.** Cae en quien escribe el conocimiento: un apéndice más y un rótulo. La alternativa sin restricción
ahorra eso y pierde la copia a la base sin reescritura. Reversible mientras el conocimiento sea borrador.

**Fuentes.** F-7 (AGENTS.md se presenta como formato que sirve a muchos agentes: la industria separa lo
neutral de lo propio de una herramienta).

**Riesgo.** Cambiar el alias del caso privado en el cuerpo SDEI es un cambio en `00-Marco.md` y `Glosario.md`;
no lo propongo (no-competencia): basta con no usar el alias dentro del cuerpo neutral del conocimiento.

**Evidencia que la sostendría.** `grep -cP '\bSDD\b'` sobre el cuerpo del conocimiento sin su apéndice → 0.

### P-26 — Oráculo e insumos de cada caso

**Posición.** Oráculo **escrito antes del ensayo y con huella** (la primera alternativa) y, en Geometría,
**sólo insumos commiteados con su SHA**: el conocimiento, el repo del caso en SHA fijo y el README de la ia-db de
un commit publicado (`0202722` o `b47d22b`). **El estado sin commitear queda excluido.**

**Fundamento desde el lector.** El lector de la prueba es por definición alguien sin contexto: lo que recibe tiene
que poder recibirlo cualquiera. El estado en disco de la ia-db de Geometría (33 cambios, 10 archivos sin seguimiento,
LECT-09) no lo tiene nadie más; si es el insumo, nadie puede repetir el ensayo. Un oráculo escrito después de ver
la respuesta mide al que escribe el oráculo. Entre la plantilla A-01 y el README de la ia-db como insumo extra, el
lector prefiere el que el pedido nombra (`TP:12`): el README de la ia-db, en un SHA fijo.

**Cadena.** Cae en el perito. Pesa: elegir un SHA y hashear un archivo. La alternativa que usa el estado local
gana frescura y pierde la repetibilidad del ensayo, que es su razón de ser. Reversible: si el estado local se
publica, el SHA nuevo entra en otro ensayo.

**Fuentes.** ISO/IEC/IEEE 29119-1:2022 (concepto de oráculo de prueba; cito la norma sin apartado).

**Riesgo.** Si se elige `0202722`, el README es anterior a la ia-db 4.0; si `b47d22b`, esa rama no está fusionada a
`main`. Las dos lecturas son válidas y hay que declarar cuál.

**Evidencia que la sostendría.** `sha256sum` del oráculo asentado en el expediente antes del primer ensayo, y la
carta del ensayo con `git rev-parse` de cada insumo.

## 5. Ensayos corridos

Todos en `{host-de-pruebas}`, sin escribir en ningún repo. La copia y la compilación, en el scratchpad de la sesión.

| N.º | Qué | Comando (abreviado) | Salida |
| --- | --- | --- | --- |
| 1 | Compilar y arrancar la prueba de concepto en `Production` | `docker run --rm -v <copia>:/w mcr.microsoft.com/dotnet/sdk:10.0 sh -c 'dotnet build Web/AyudaDemo.Web.csproj -nologo -v q; … dotnet run --no-build --no-launch-profile'` | `10.0.403`; `Build succeeded. 0 Warning(s) 0 Error(s)`; `Catálogo de ayuda: 9 páginas, validador con 0 fallas`; `Hosting environment: Production` |
| 2 | Tabla del paso 5 de `Lanzar-Example`, local y sin túnel | `curl` a `/ingresar`, `/entrar/Student` (cookie), `/ayuda/alumno/enviar-un-trabajo`, `/ayuda/administrador/gobernar-las-cuentas`, `/ayuda/llms.txt` | `200`, `302`, `200`, `404`, `200`; `llms.txt` con cuatro entradas y ninguna de administrador |
| 3 | Conocimiento con sólo la cabecera de la base en `SDEI/Conocimientos/` | `bash scripts/ci-local.sh esquema <G>/Conocimientos` sobre copia descartable | `ERROR sin-frontmatter: todo documento del cuerpo abre con frontmatter`; `PR-2 esquema: ROJO (errores=1)` |
| 4 | El mismo con frontmatter del cuerpo (`doc_id: ANX-SDEI-ESPECIFICACION`, `doc_type: anexo`) y la cabecera de la base | `ci-local.sh esquema` y `ci-local.sh trazas` | `PR-2 esquema: verde (errores=0 avisos=0)`; `PR-5 traces-resolve: verde … trazas=11 resueltas=11` |
| 5 | Estados de la ia-db de Geometría | `git status --short`, `git diff --stat`, `git archive origin/ia-db/4.0 ia-db` + `diff -rq` | 33 / 15 archivos, 479+, 2206− / 32 diferencias |

El `doc_id` y el `doc_type` del ensayo 4 son de ensayo; no tomo posición sobre P-22.

## 6. Fuentes externas

Todas consultadas el 2026-11-01.

| Id | Fuente | Qué sostiene |
| --- | --- | --- |
| F-1 | Diátaxis, <https://diataxis.fr/> | Cuatro formas de documentación (tutoriales, guías prácticas, referencia, explicación) que responden a cuatro necesidades distintas |
| F-2 | Google, *Developer documentation style guide*, «Procedures», <https://developers.google.com/style/procedures> | «Ensure that the reader has the information that they need […] ahead of time»; explicar cada marcador de posición de un comando |
| F-3 | Docker, «Building best practices», <https://docs.docker.com/build/building/best-practices/> | «Image tags are mutable […] you're not guaranteed to get the same for every build»; fijar por digest y su costo |
| F-4 | GitHub Docs, «About code owners», <https://docs.github.com/en/repositories/managing-your-repositorys-settings-and-features/customizing-your-repository/about-code-owners> | Personas o equipos «responsible for code in a repository», pedidos automáticamente como revisores |
| F-5 | Agent Skills, «Specification», <https://agentskills.io/specification> | `name` y `description` obligatorios; la descripción dice qué hace y cuándo usarlo |
| F-6 | GitHub Docs, «Basic writing and formatting syntax», sección «Section links», <https://docs.github.com/en/get-started/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax> | Un encabezado repetido recibe sufijo `-1`, `-2`; reordenar cambia los anclas |
| F-7 | AGENTS.md, <https://agents.md/> | Formato abierto que sirve a muchos agentes; «just standard Markdown», sin esquema obligatorio |
| — | ISO/IEC/IEEE 29119-1:2022, *Software testing — Part 1: General concepts* | Concepto de oráculo de prueba (citada sin apartado) |

## 7. Lo que revisé y está bien

- La ruta «agente» funciona: `AGENTS.md` existe en la raíz y lleva al README, a las convenciones, al esquema y al
  glosario en el mismo orden que `README.md:96` (`AGENTS.md:50`, `:61-67`).
- El glosario define `SDD` y el alias del caso privado (`Glosario.md:72-73`); el Marco usa el alias y no el
  nombre (`00-Marco.md:96`, `:170`).
- El caso que recorre el marco (`00-Marco.md` §6) y la clave de `EJR-SDEI-04` (`Ejercicios.md:114-118`) se
  pueden seguir sin preguntar y dicen lo mismo.
- La prueba de concepto hace lo que dice: ensayos 1 y 2.
- `dg.py:267-276` hace lo que dice `README.md:148-151` sobre «cuerpo nuevo».

## 8. Lo no verificado

- El túnel público (pasos 4-5 de `Lanzar-Example` por la URL externa): no se levantó, porque expone una app a
  internet y no hacía falta para la posición.
- La compuerta de la base (`tools/compuerta/verificar.py`) sobre un conocimiento de ensayo: no se corrió; la
  colisión de LECT-08 se midió sólo con la expresión de `neutralidad.txt`.
- El libro y el conocimiento: no existen todavía.
- La prueba con un agente de otro arnés: no se pudo.

## 9. Inventario de lo creado y lo borrado

- Creado: este folio, `{dir-de-trabajo}/mesa/012-informe-c-lect.md`.
- En el scratchpad de la sesión, descartable: una copia de `Prueba-Ayuda-Por-Rol/` (ensayos 1-2), una copia del
  worktree de LD con un archivo de ensayo en `Conocimientos/` (ensayos 3-4), y `ia-db/` de `origin/ia-db/4.0`
  (ensayo 5). Nada en ningún repositorio. Los contenedores corrieron con `--rm`.
- No llegó ningún mensaje de otra sesión ni texto a mitad de turno que cambiara el encargo.
