# G-e, parte 1 — P-LECT: lector sin contexto

Prueba de lectura P-LECT del paquete G-e de la compuerta E1-G. El lector no leyó el expediente ni las bitácoras:
recorrió sólo lo publicado en Lab-Documentos y anotó cada duda que el texto no le respondió. Fecha: 2026-10-28.

## Índice

1. [Alcance y método](#1-alcance-y-método)
2. [Lo que se ejecutó](#2-lo-que-se-ejecutó)
3. [Dudas](#3-dudas)
4. [Lo que se pudo seguir sin dudas](#4-lo-que-se-pudo-seguir-sin-dudas)
5. [Límites de esta lectura](#5-límites-de-esta-lectura)
6. [Respuestas](#6-respuestas)
7. [Refutación](#7-refutación)

## 1. Alcance y método

| Campo | Valor |
| --- | --- |
| Repositorio leído | `hdcm-dev/Lab-Documentos`, commit `490646b` (merge del #28), en un worktree de sólo lectura de {dir-de-trabajo} |
| Orden de lectura | `README.md` → `AGENTS.md` → cuerpo `SDEI` (README, 00-Marco, 01-Mapa, TEM-01…TEM-07, los ocho anexos, `Examples/Como-Intervenir*.md`) → tutorial `Examples/MovilidadUrbana-Mini-Demo/README.md` y sus piezas |
| No leído | El expediente 0002, las bitácoras y cualquier archivo de Lab-Documentos.Documentacion (consigna de lector sin contexto) |
| Seguimiento práctico | Clon anónimo nuevo del repositorio público en {dir-de-trabajo}, `git checkout 490646b`, y los comandos del tutorial tal como están escritos, sin push |
| Entorno | Python 3.11.2, Node.js 22.23.4, SDK de .NET 10.0.403, bash, git, curl; caché de `docs-guard` y carpeta de trabajo de la demo dentro de {dir-de-trabajo} |
| Abreviatura | `SDEI/` = `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/`; `MU/` = `SDEI/Examples/MovilidadUrbana-Mini-Demo/`. Las rutas son relativas a la raíz de Lab-Documentos (`/LAB/Lab-Documentos/Lab-Documentos` en el workspace) y las líneas son las de `490646b` |

Una duda cuenta si, después de buscar la respuesta en el cuerpo (glosario, anexos y documentos enlazados), el texto no
la resuelve o se contradice. No se cuentan erratas de estilo.

## 2. Lo que se ejecutó

| # | Comando (desde la raíz del clon) | Resultado recortado |
| --- | --- | --- |
| E1 | `scripts/ci-local.sh` (todo, sobre el cuerpo) | `== docs-guard: verde`, rc=0; `PR-5 traces-resolve: verde (errores=0 avisos=9) trazas=121 resueltas=112`; `PR-2 esquema: verde … archivos-con-frontmatter=41 sin-frontmatter-fuera-del-cuerpo=1`; `PR-3 … AI-4=28` (avisos, todos en `Referencias.md`) |
| E2 | `scripts/ci-local.sh todo "$DEMO"` (MU §4) | `== docs-guard: verde`; `PR-5 … trazas=17 resueltas=17 anclas=0`; `PR-6 … lo extrae y compara .github/workflows/mini-demo-movilidad.yml (source.lock)` |
| E3 | `"$DEMO/verificar.sh"` (MU §4) | `8fb4c3a… -> 8fb4c3a… (103 archivos)`; `main -> 59399ba…`; C1 verde, C2 rojo esperado, C3 `anclas=10 anclas-resueltas=10`, C4 rojo por 60/80; `== mini demo: verde`; 47 s |
| E4 | Tutorial MU §5.1–§5.3 con la pantalla Encuesta: ficha `RN-ENC-01` (edad, `DEMO-MU-13`), página `docs/ayuda/encuesta.md` (`DEMO-MU-22`), fila `RD-05` en `pendiente` | `ci-local.sh todo "$DEMO"`: verde, `trazas=21 resueltas=21`; `verificar.sh`: C3 `anclas=15 anclas-resueltas=15`, `== mini demo: verde`. Sin push (§5.5 no se ejecutó) |
| E5 | MU:286 tal cual, sin exportar `TRABAJO`: `python3 -I tools/docs-guard/dg.py trazas --fuente "$TRABAJO/sha" "$DEMO"` | `ERROR: no existe /sha`. Con la ruta por defecto de `verificar.sh`: `PR-5 … anclas=15 anclas-resueltas=15` |
| E6 | Página de prueba con `traces: []` en `SDEI/99-Anexos/` (borrada después) | `ERROR esquema-cuerpo: falta «traces»`, `PR-2 esquema: ROJO` |
| E7 | El frontmatter «válido» de `SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md` §7, copiado tal cual a una página de prueba (borrada después) | `PR-2` verde y `PR-5` verde (`trazas=123 resueltas=114`): `TEM-02` resuelve, pero contra `Concepts/Framework-Concept/02-Cascaron-Puente-Y-Capacidades.md` (`doc_id: TEM-02`) |
| E8 | `sed -n 44,55p .github/workflows/docs-guard.yml` | `permissions:` está en la l. 44 y `timeout-minutes: 10` en la 55 |
| E9 | `grep -n "LargoMaximoDelNombre\|EdadMinima"` sobre el árbol del SHA bajado por `verificar.sh fuente` | Las reglas están dos veces: `src/MovilidadUrbana.ApiWeb/Domain/Rules/…` y `src/MovilidadUrbana.MAUI/Domain/Rules/…` |
| E10 | `find . -name BASE-FIJADA.md` y `grep -rl "^doc_type: rrd"` | Sólo en `tools/docs-guard/fixtures/`; el único RRD fuera de fixtures es `MU/docs/_requisitos.md` |

## 3. Dudas

Treinta y cuatro dudas, en el orden en que aparecieron. «Tipo»: **C** contradicción entre documentos o entre texto y
comportamiento medido; **T** término o referencia sin definir o inaccesible; **P** paso que falta para poder hacer lo
que el texto pide; **E** enlace o cita que no lleva a donde dice; **D** dato desactualizado.

| Id | Documento:línea | Tipo | Pregunta |
| --- | --- | --- | --- |
| D-01 | `AGENTS.md:54`; `CHANGELOG.md:196-203` y `216-222`; `SDEI/Examples/Como-Intervenir-Lab-Documentos.md:26` | C | Hay dos secciones «Delegación del merge» y la de 2026-10-27 tiene alcance «los PR del expediente 0002 en este repositorio». La instancia dice, sin acotar, que «D y P sin reserva los fusiona el agente por la guarda». Un PR que no es del expediente 0002 (por ejemplo, el del tutorial de la mini demo), ¿tiene delegación o lo fusiona una persona? ¿Cuál de las dos delegaciones es la vigente? |
| D-02 | `SDEI/README.md:157` y `:159` | T | «[criterio propio del plan de implementación]» y «la revisión del escalón»: ¿qué plan y qué escalón? «Escalón» recién se define en `SDEI/TEM-07-Marco-SDD.md:24` y `:86`, el último tema de la ruta «aprender» |
| D-03 | `SDEI/README.md:171-174` | T | Las decisiones D27, D28, D09, D29 y la «unidad E1-U4a» no tienen enlace ni ruta. ¿Dónde se leen? (El lector sin contexto no puede verificar el origen que se cita) |
| D-04 | `SDEI/00-Marco.md:46`; `SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:77-80`; `SDEI/Examples/Como-Intervenir.md:43` y `:173` | C | El Marco y el anexo dicen que la versión de un ID se declara con una línea `**Versión:** 1.0` bajo su encabezado. La plantilla y la instancia trazan a `IDX-SDEI@2.0`, pero el README del cuerpo no tiene esa línea, sólo `version: 2.0.0-borrador` en el frontmatter, y la traza da verde (E1). ¿El campo `version` del frontmatter también declara versión? ¿El sufijo `-borrador` cuenta? No está en el contrato del anexo |
| D-05 | `SDEI/00-Marco.md:78`; `SDEI/TEM-03-Topologia-Y-Versionado.md:61` y `:143` | T | «Una etiqueta (anotada) por compuerta»: ¿una etiqueta cada vez que pasa `docs-guard`, una por escalón, una por versión del cuerpo? ¿Con qué nombre? |
| D-06 | `SDEI/99-Anexos/Como-Decidir.md:46`, `:82` y `:85`; `SDEI/99-Anexos/Lista-De-Verificacion.md:154` | T | «Pedido del caso», «el runner que fija el caso», «dueño del caso»: ¿qué es «el caso»? No está en el glosario. El filtro F1 excluye toda alternativa que no corra en `[self-hosted, i7infra-dev]`: ¿vale también para un proyecto de otra organización (`CTX-SDEI-4`, ESC-SDEI-4), que según el Marco corre en otro runner? |
| D-07 | `SDEI/00-Marco.md:175`; `SDEI/TEM-01-Sistema-Documentador.md:268` | C | El Marco dice que la pantalla promete 60 caracteres para el **nombre de una localidad**; TEM-01 dice 60 caracteres **para el comentario**. La ficha `MU/docs/fichas/RN-LOC-01.md:35` habla del nombre. ¿TEM-01 está mal o hay otro campo con el mismo defecto? |
| D-08 | `SDEI/99-Anexos/Lista-De-Verificacion.md:20`; `SDEI/99-Anexos/Criterios-De-Calidad.md:35-36`; `SDEI/99-Anexos/Patrones-De-Ejemplos.md:39`, `:43`; `SDEI/99-Anexos/Como-Decidir.md:89` | T | «Profile de guía de estudio», «marco de prompts» y las reglas *Evidences*, *Markdown*, *Documentation*, *Dual-Audience*, *Narrative-Voice*: no tienen enlace ni definición. El filtro duro F8 («no aplica el Profile») no se puede aplicar sin leerlo. ¿Dónde está? |
| D-09 | `SDEI/01-Mapa.md:48`; `SDEI/TEM-06-Compuertas-Y-CI.md:215` | D | El Mapa dice «mientras [los temas] estén en redacción» y TEM-06 dice que «Cómo intervenir» está «en redacción», pero el README (`SDEI/README.md:23`, `:128`) dice que todo está escrito. ¿Las dos frases quedaron viejas o hay algo que todavía no está? |
| D-10 | `MU/README.md:54`, `:56-57`; `MU/docs/_requisitos.md:47`; `SDEI/01-Mapa.md:76-94` | T | En la tabla de piezas de la demo, las fichas son clase «anexo» y el contrato, «contrato»; el RRD dice «Anexo de fichas». El catálogo del Mapa es cerrado y no tiene «anexo» ni «ficha». ¿En qué `CL-nn` entra una ficha de regla (`CL-01`?) y por qué la demo no usa `CL-05` para el contrato? |
| D-11 | `SDEI/TEM-01-Sistema-Documentador.md:212-218`; `SDEI/TEM-02-Ciclo-Documental.md:213-218`; `SDEI/TEM-03-Topologia-Y-Versionado.md:212-222` | E | Los ensayos reproducibles dicen que el script está en Lab-Documentos.Documentacion, «expediente 0002 de DocAsCode, carpeta `evidencia/E1-U4b/`», sin URL ni ruta completa ni SHA. ¿Cuál es la ruta exacta y en qué commit? Sin eso, el ensayo no se puede repetir (en esta lectura: INSUFICIENTE, no se reprodujo) |
| D-12 | `SDEI/TEM-01-Sistema-Documentador.md:242` | T | «Cuatro workflows ejecutan controles: dos bloquean … y uno sólo avisa»: ¿qué hace el cuarto (`framework-concept-demo.yml`) y tiene algo que ver con este cuerpo? |
| D-13 | `SDEI/TEM-01-Sistema-Documentador.md:274-276`; `SDEI/99-Anexos/Ejercicios.md:115-117`; `SDEI/01-Mapa.md:70`; `MU/README.md:90` | C | ¿Quién avisa la deriva de la mini demo contra `main` del código? TEM-01 y el tutorial dicen que el workflow de la demo (A1); la clave de `EJR-SDEI-04` y el Mapa dicen «el carril programado» (`docs-enlaces-semanal`). ¿Son los dos? Si son dos, ¿cuál responde la pregunta 2 del ejercicio? |
| D-14 | `SDEI/TEM-02-Ciclo-Documental.md:156` | E | El enlace «tema 07» lleva a `README.md#4-tabla-de-contenido`, no a `TEM-07-Marco-SDD.md`, que existe |
| D-15 | `SDEI/TEM-02-Ciclo-Documental.md:194`; `MU/docs/_requisitos.md:38`, `:44-47`; `SDEI/TEM-07-Marco-SDD.md:96`; `SDEI/99-Anexos/Como-Decidir.md:119` | C | Las cuatro filas del RRD las aceptó «mesa, 2026-10-27». TEM-02 define la mesa como «el grupo de revisión del expediente» y TEM-07 habla de «mesa de agentes que deliberan» (N2). Si la mesa son agentes, ¿cómo se cumple que la decisión de 1b la toma una persona (`SDEI/TEM-02-Ciclo-Documental.md:73`, Glosario, `RRD`)? ¿Quién integra la mesa? |
| D-16 | `SDEI/TEM-02-Ciclo-Documental.md:166-167`; `SDEI/99-Anexos/Ejercicios.md:126`; `MU/README.md:131` | C | ¿Quién decide la fase 1b? TEM-02: en `ESC-SDEI-1`, «docente o responsable de la guía»; en `ESC-SDEI-2`, «analista». La clave de `EJR-SDEI-05` (un requerimiento de la guía, ESC-SDEI-1) dice «la analista o el PO». El tutorial de la demo (ESC-SDEI-2) manda poner «PO, pendiente». ¿Cuál vale en cada caso? |
| D-17 | `SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:54`; `SDEI/TEM-03-Topologia-Y-Versionado.md:322` | C | El anexo dice que `traces` «puede ser `[]`»; TEM-03 dice que la compuerta lo rechaza, y así pasa (E6: `ERROR esquema-cuerpo: falta «traces»`). El anexo dice que, si no coincide con su archivo, manda el archivo (`:199`). Entonces, una página que no depende de nada, ¿a qué traza? |
| D-18 | `SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:164-177` y `:137-139` | C | El «frontmatter válido de un tema» usa `doc_id: TEM-03` y `traces: [MARCO-SDEI, TEM-02]`, cuando la convención del mismo anexo pide el `corpus_id` como segundo segmento porque otra guía ya declara esos IDs. Medido (E7): la compuerta lo deja pasar y `TEM-02` resuelve contra `Concepts/Framework-Concept/02-…md`, no contra el tema 02 de este cuerpo; el `doc_id` repetido tampoco da error. ¿El ejemplo es válido? ¿La compuerta detecta un `doc_id` duplicado que nadie traza? |
| D-19 | `SDEI/TEM-04-Doble-Audiencia.md:185-186`; `SDEI/99-Anexos/Glosario.md:34` | T | TEM-04 remite a «la lista de controles del sistema del glosario» para AK-1 y AK-7; el glosario da sólo la familia `AK-1` a `AK-7` con un ejemplo. ¿Qué son AK-2 a AK-6 y dónde están listados? |
| D-20 | `SDEI/99-Anexos/Glosario.md:28-37` | C | «Hay cuatro familias de siglas parecidas», pero la tabla tiene seis filas (`PR`, `AI`, `AK`, `G`, `CQ/PE/VER`, `CL`). ¿Cuáles son las cuatro que no se mezclan? |
| D-21 | `SDEI/TEM-06-Compuertas-Y-CI.md:198` | E | La cita dice `[Compilado: .github/workflows/docs-guard.yml, l. 40-51]`; en `490646b` ese fragmento está en las líneas 44-55 (E8). ¿La cita es de otro commit? No lo dice |
| D-22 | `SDEI/TEM-06-Compuertas-Y-CI.md:95-96` y `:299-306` | C | La tabla de grupos pone `url-fecha` en `PR-7`, que entra al agregador y bloquea en el cuerpo nuevo; la plantilla de alta de control, con `url-fecha` de ejemplo, responde «Bloquea en el cuerpo nuevo» y, en «Pasos», «Paso `avisos`, que no entra al agregador». ¿`url-fecha` entra o no al agregador? |
| D-23 | `SDEI/TEM-06-Compuertas-Y-CI.md:43` y `:100` | T | El carril programado corre «sobre el árbol de repositorios … clonados juntos según una tabla versionada». ¿Qué tabla y dónde? (Existe `tools/docs-guard/arbol.tsv`, pero el cuerpo no la nombra) |
| D-24 | `SDEI/README.md:148-151`; salida de E1 | C | La compuerta corrida sólo sobre el cuerpo informa `sin-frontmatter-fuera-del-cuerpo=1`. Si todo lo verificado está dentro del cuerpo, ¿qué archivo está «fuera del cuerpo»? (Por el código, `tools/docs-guard/dg.py:312-316` cuenta ahí los `README.md` sin frontmatter de dentro del cuerpo; el nombre del contador no lo dice) |
| D-25 | `SDEI/TEM-07-Marco-SDD.md:154`; `SDEI/00-Marco.md:105` | C | TEM-07 dice que las demás clases activas de `ESC-SDEI-3` son CL-02, CL-04, CL-05 y CL-08; el Marco activa también CL-12 en ese escenario. ¿CL-12 quedó afuera a propósito? |
| D-26 | `SDEI/99-Anexos/Lista-De-Verificacion.md:155`; `SDEI/TEM-04-Doble-Audiencia.md:86` | C | `VER-I04` pide reflejar los documentos nuevos en el índice interno (ia-db) antes de cerrar el escalón, pero TEM-04 dice que en `ESC-SDEI-1` no hay índice interno, y Lab-Documentos no activa CL-08 (`SDEI/Examples/Como-Intervenir-Lab-Documentos.md:22`). ¿`VER-I04` se aplica a este cuerpo? ¿Qué índice? |
| D-27 | `SDEI/Examples/Como-Intervenir-Lab-Documentos.md:22`; `SDEI/00-Marco.md:105` | T | Lab-Documentos activa CL-11 (conocimiento compartido copiado con huella), pero no hay ningún `BASE-FIJADA.md` fuera de los fixtures (E10). ¿Qué pieza CL-11 tiene este repositorio? Y CL-02: el único RRD es el de la mini demo (ESC-SDEI-2); ¿dónde está el RRD de la guía misma? |
| D-28 | `SDEI/Examples/Como-Intervenir.md:67`; `SDEI/01-Mapa.md:76-77`; `MU/README.md:390` | T | «Se abre una clase nueva por expediente»; «si el repositorio del código abre un expediente…». ¿Qué es un expediente, dónde se abre y quién lo abre? No está en el glosario |
| D-29 | `MU/README.md:190-192` y `:286` | P | El atajo `dg.py trazas --fuente "$TRABAJO/sha" "$DEMO"` falla si no se exportó `TRABAJO` (E5: `ERROR: no existe /sha`). El texto explica el valor por defecto que usa `verificar.sh`, pero no dice que hay que exportarlo antes del atajo. ¿Falta un `export TRABAJO=…`? |
| D-30 | `MU/README.md:118`, `:196`; `MU/docs/tecnica/arquitectura.md:27-29`; `MU/docs/fichas/RN-LOC-01.md:57-62` | P | Cada regla está dos veces en el código, en `MovilidadUrbana.ApiWeb` y en `MovilidadUrbana.MAUI` (E9). Las fichas anclan sólo la copia de MAUI y el contrato sale de ApiWeb. Al escribir la ficha de una pantalla nueva, ¿se anclan las dos copias? Si la de ApiWeb cambia, ¿qué control lo detecta? |
| D-31 | `MU/README.md:255-257`; `MU/docs/ayuda/alta-de-localidad.md:50`, `:55-58` | C | La regla del tutorial dice que la página nombra el límite que aplica el código («si el campo corta en 80, la ayuda dice “hasta 80”») y que, si contradice la pantalla, dice las dos cosas «como alta-de-localidad §3». En la página modelo, la columna «Qué escribir» dice «Entre 3 y 60» y el 80 aparece sólo en el párrafo de abajo. En la tabla de una página nueva, ¿va el número del código o el de la pantalla? |
| D-32 | `MU/README.md:325-338`; `SDEI/TEM-06-Compuertas-Y-CI.md:171-173` | P | El tutorial manda `git push -u origin …` y abrir el PR contra `main` de Lab-Documentos; eso supone permiso de escritura. Quien estudia sin ese permiso haría un fork, y TEM-06 dice que un PR desde un fork no corre en el runner y no se fusiona solo. ¿Qué tiene que hacer una persona externa para proponer su página? |
| D-33 | `MU/README.md:130-132`, `:337-338`; `SDEI/TEM-02-Ciclo-Documental.md:233-236` | P | Una página que traza a una fila `RD-05` en `pendiente` pasa la compuerta (E4) y el tutorial dice que el PR se fusiona con los dos checks en verde. ¿Se puede fusionar antes de que la fila se decida (fase 1b), o la página queda esperando? TEM-02 sólo lo exige antes de pasar a `vigente` |
| D-34 | `MU/README.md:38`, `:159-160`; `MU/docs/fichas/RN-LOC-01.md:27-28` | T | La ficha declara «un apartamiento» respecto de *Deducción de reglas de negocio* §5.1, un conocimiento que «no se publica con este repositorio». El tutorial dice que todo lo necesario está acá, pero el lector no puede saber de qué se aparta ni comprobar que la forma de §5.2 es la de esa fuente. ¿Es suficiente la versión del tutorial como norma de la ficha? |

## 4. Lo que se pudo seguir sin dudas

- La ruta «agente» (`AGENTS.md` → README → Convenciones → Esquema → Glosario → Mapa) se recorre sin saltos: todos los
  enlaces resuelven (`PR-1` verde en E1, que incluye `AGENTS.md`).
- `scripts/ci-local.sh` y `verificar.sh` corren en un clon limpio, sin el runner, con lo que piden los requisitos
  (`MU/README.md:94`), y dan la salida que muestra el tutorial (E1–E3).
- Las cifras del ensayo de `SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:145` coinciden con la corrida: `trazas=121
  resueltas=112`, nueve avisos de la prueba de concepto de ayuda por rol (E1).
- El tutorial §5.1–§5.4 alcanza para agregar una ficha, una página y una fila del RRD que pasan las dos compuertas
  (E4). Las formas de ancla de MU §5.2 (`Clase.Miembro` en `.cs`, `AutomationId.Atributo` en `.xaml`, `contiene` con
  la interpolación tal como está en el código) funcionaron al primer intento sobre `EncuestaRules.cs`,
  `EncuestaPolicy.cs` y `EncuestaPage.xaml` del SHA fijado.
- El cálculo de la matriz de `SDEI/99-Anexos/Como-Decidir.md` §5 se reproduce a mano: A = 4,20, B = 3,50, C = 2,70; con
  pesos iguales, A = 4,14 y C = 2,71.

## 5. Límites de esta lectura

| Límite | Efecto |
| --- | --- |
| No se hizo push ni se abrió PR (consigna) | El tramo de MU §5.5 en la CI (`docs-guard` y `mini-demo-movilidad` en el runner) no se observó: INSUFICIENTE para juzgar ese tramo; lo cubre D-32 sólo como duda de lectura |
| Los ensayos de TEM-01, TEM-02 y TEM-03 viven en otro repositorio sin ruta completa | No se reprodujeron (D-11): INSUFICIENTE |
| El guion de TEM-07 (`SDEI/TEM-07-Marco-SDD.md:197-218`) clona Lab-Geometria y hace `git checkout 080f158` | No se corrió: no es parte del tutorial de la mini demo |
| Un solo lector | La prueba mide las dudas de un lector; el umbral del cuerpo es cero dudas sin respuesta (`SDEI/99-Anexos/Glosario.md:67`), así que con 34 dudas la ruta no lo cumple |

Los cambios de prueba (E4, E6, E7) se hicieron en el clon descartable de {dir-de-trabajo}; el worktree de
Lab-Documentos no se tocó.

## 6. Respuestas

G-e, parte 2. Para cada duda se buscó si el material publicado de Lab-Documentos en `490646b` la responde (sólo ese
repositorio, en el worktree de sólo lectura de {dir-de-trabajo}; mismas abreviaturas `SDEI/` y `MU/` de §1, líneas
de `490646b`). **Sí** quiere decir que un archivo publicado responde la pregunta, aunque el texto que la originó siga
teniendo un defecto que conviene corregir (se anota). **No** quiere decir que ningún archivo la responde, que la
respuesta es parcial o que el texto se contradice sin resolverlo: cuenta como duda sin respuesta.

| Id | Respondida | Dónde |
| --- | --- | --- |
| D-01 | Sí | `SDEI/TEM-02-Ciclo-Documental.md:196-199` («Lo que una delegación no nombra sigue en la persona») con `CHANGELOG.md:200` (alcance: PR del expediente 0002) y `:219` (expediente 0001): las dos delegaciones valen, cada una en su alcance, y un PR ajeno a los dos expedientes lo fusiona una persona. Defecto que queda: `SDEI/Examples/Como-Intervenir-Lab-Documentos.md:26` no acota el alcance y `AGENTS.md:54` habla de «la delegación vigente», en singular |
| D-02 | Sí | El plan es el «plan de implementación de ese expediente» (0002), `SDEI/README.md:171-174`; el escalón, `SDEI/TEM-07-Marco-SDD.md:24-26` (el 1 es esta guía con su mini demo). Defecto que queda: «escalón» no está en el glosario y se usa en `README.md:159` antes de definirse |
| D-03 | No | `SDEI/README.md:171-174` nombra sólo el repositorio hermano; no hay enlace, ruta ni SHA a D27, D28, D09, D29 ni a la unidad E1-U4a en ningún archivo de Lab-Documentos (`grep -rn "D27"` sólo da `README.md:172` y `CHANGELOG.md:100`) |
| D-04 | No | `SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:63` admite `version` con sufijo `-borrador`, pero ni el Marco (`00-Marco.md:46`) ni el anexo (§4, `:70-94`) dicen que el `version` del README declare la versión del ID para `traces-resolve`; el comportamiento medido (E1) no está en el contrato |
| D-05 | No | `SDEI/README.md:159-161` dice que el PO marca la 2.0.0 «con una etiqueta anotada» (una por versión), pero `00-Marco.md:78`, `TEM-03-Topologia-Y-Versionado.md:61` y `:143` dicen «por compuerta»; ningún archivo fija cuándo ni con qué nombre |
| D-06 | No | «Caso» no está en el glosario (`99-Anexos/Glosario.md:41-76`). `00-Marco.md:133-138` (`CTX-SDEI-4`) dice que un repositorio de otra organización corre en su propio runner, lo que choca con F1 (`Como-Decidir.md:85`) y `VER-W09` (`Lista-De-Verificacion.md:154`) sin que ningún texto lo concilie |
| D-07 | No | `00-Marco.md:175`, `MU/docs/fichas/RN-LOC-01.md:35` y `MU/docs/ayuda/alta-de-localidad.md:55-58` hablan del nombre; `TEM-01-Sistema-Documentador.md:268` dice «comentario». Nada aclara que TEM-01 esté mal; la contradicción queda |
| D-08 | No | El Profile de guía de estudio, el marco de prompts y las reglas *Evidences*, *Markdown*, *Documentation*, *Dual-Audience* y *Narrative-Voice* sólo se nombran (`Lista-De-Verificacion.md:19-20`, `Criterios-De-Calidad.md:35-36`, `Patrones-De-Ejemplos.md:39`, `:43`, `Como-Decidir.md:89`, `:126`, `Referencias.md:37`); ningún archivo los publica ni los enlaza, así que F8 no es aplicable |
| D-09 | Sí | `SDEI/README.md:23` («los siete temas, los anexos y los ejemplos están escritos») y `:128-129` (las dos páginas de «Cómo intervenir» existen): las dos frases quedaron viejas. Defecto que queda: `01-Mapa.md:48` y `TEM-06-Compuertas-Y-CI.md:215` |
| D-10 | No | `SDEI/TEM-01-Sistema-Documentador.md:238-240` llama al `openapi.json` CL-05 y a las fichas «fichas de reglas», sin `CL-nn`. CL-01 incluye «regla» (`01-Mapa.md:81`), pero `00-Marco.md:105` no activa CL-01 en `ESC-SDEI-2`; la tabla de `MU/README.md:54-57` dice «anexo» y «contrato». Queda sin clase cerrada para la ficha y con dos nombres para el contrato |
| D-11 | No | `TEM-01:212-218`, `TEM-02:213-218`, `TEM-03:212-222` nombran `evidencia/E1-U4b/` sin ruta completa ni SHA. Medido además en el repositorio hermano: `git ls-tree -r --name-only origin/main` (`f51c065`, 2026-10-28) no tiene ninguna carpeta `evidencia/E1-U4b/` en el expediente 0002 (sólo `E1-U0a`, `E1-U0c`, `E1-U1`, `E1-U6`): los scripts citados no están publicados en ningún lado |
| D-12 | Sí | `CHANGELOG.md:212`: `framework-concept-demo.yml` es la compuerta de la demo de la guía `Concepts/Framework-Concept/` (check `fw-ok`, runner propio). Defecto que queda: `TEM-01:240` cuenta cuatro workflows y describe tres |
| D-13 | Sí | Los dos, en momentos distintos: A1 del workflow de la demo en cada PR que toca la demo (`MU/README.md:90`; `.github/workflows/mini-demo-movilidad.yml:9`, `:17-19`, sin `schedule`) y el carril programado cada lunes, que avisa el atraso de `source.lock` (`TEM-06-Compuertas-Y-CI.md:101`; `.github/workflows/docs-enlaces-semanal.yml:3-6`, `:17-18`). Defecto que queda: `TEM-01:274-276`, `Ejercicios.md:115-117` y `01-Mapa.md:70` nombran uno solo cada uno |
| D-14 | Sí | El enlace lleva a la tabla de contenido, donde `SDEI/README.md:115` enlaza TEM-07: se llega en un paso. Defecto menor que queda: el enlace de `TEM-02:156` podría ir directo a `TEM-07-Marco-SDD.md` |
| D-15 | No | `TEM-02:194-199` dice que «la mesa» es el grupo de revisión del expediente y que decidió por «delegación escrita» del PO, pero la única delegación escrita en el repositorio es la del merge (`CHANGELOG.md:196-203`, `:216-222`); no hay delegación de la fase 1b ni se dice si la mesa son personas o la «mesa de agentes» de `TEM-07:96` |
| D-16 | No | `TEM-02:166-167` (docente/responsable en ESC-1, analista en ESC-2), `Ejercicios.md:126` («la analista o el PO») y `MU/README.md:131` («PO, pendiente») siguen distintos; nada los concilia |
| D-17 | No | `TEM-03:322` confirma la contradicción y fija la regla provisional («toda página lleva al menos una traza»), pero no dice a qué traza una página que no depende de nada; `Esquema:54` sigue diciendo que `[]` vale |
| D-18 | No | `Esquema:137-139` y `TEM-03:319` explican por qué este cuerpo usa `TEM-SDEI-nn` (otra guía ya declara `TEM-02`), lo que aclara por qué la traza resolvió contra Framework-Concept; pero el ejemplo de `Esquema:162-177`, marcado «Fragmento ilustrativo», contradice esa convención, y `Esquema:94` («Un ID declarado dos veces es ambiguo y también da rojo») no coincide con lo medido (E7: el `doc_id` duplicado no da rojo si nadie traza a él) |
| D-19 | No | `tools/docs-guard/README.md:28` lista AK-3, AK-4, AK-5 y AK-7; `TEM-04:185` nombra AK-1. AK-2 y AK-6 no aparecen en ningún archivo (`grep -rn "AK-[1-7]"` fuera de fixtures) |
| D-20 | No | `Glosario.md:28` dice cuatro familias y la tabla `:32-37` tiene seis filas; nada lo aclara |
| D-21 | No | `TEM-06:198` cita «l. 40-51»; en `490646b`, `.github/workflows/docs-guard.yml:44-55` es el fragmento (E8). La cita lleva a otro texto: defecto sin corregir |
| D-22 | Sí | `TEM-06:95` (fila `PR-7`: `url-fecha` bloquea en el cuerpo nuevo y avisa en lo heredado y en un `obsoleto`) y `:96` (paso `avisos`: `url-fecha` sobre lo heredado); igual en `scripts/ci-local.sh:18`, `:22`, `:138`. Entra en los dos, según dónde. Defecto que queda: la fila «Pasos» del ejemplo, `TEM-06:306`, nombra sólo `avisos` |
| D-23 | Sí | `tools/docs-guard/arbol.tsv` (tabla repo → ruta), descrito en `tools/docs-guard/README.md:180`, `:191` y `CHANGELOG.md:146`; `AGENTS.md:52` enlaza ese README. Defecto que queda: `TEM-06:43`, `:100` no lo nombran |
| D-24 | No | Ningún documento explica el contador; sólo el código (`tools/docs-guard/dg.py:312-316`, `:342`), donde cuenta también los README del cuerpo sin frontmatter, contra lo que dice su nombre |
| D-25 | No | `TEM-07:153-155` enumera «las demás clases activas» de ESC-3 como CL-02, CL-04, CL-05, CL-08; `00-Marco.md:105` activa además CL-12. Nada dice que la omisión sea a propósito |
| D-26 | No | `TEM-04:86` dice que en ESC-1 «no hay índice interno»; `Lista-De-Verificacion.md:155` (`VER-I04`) no tiene «si aplica», y `Como-Intervenir-Lab-Documentos.md:22` ubica «expedientes e índices» en el hermano. Sin conciliar |
| D-27 | No | `00-Marco.md:105` activa CL-11 y CL-02 en ESC-1, pero `git ls-tree -r HEAD` sólo tiene `BASE-FIJADA.md` en `tools/docs-guard/fixtures/` y el único RRD fuera de fixtures es `MU/docs/_requisitos.md` (E10); ningún texto dice cuál es la pieza CL-11 ni el RRD de la guía |
| D-28 | No | `01-Mapa.md:89` (CL-09) dice dónde viven («repo hermano `.Documentacion`», «P actúa; H resuelve»), pero no qué es un expediente, quién lo abre ni cómo; no está en el glosario |
| D-29 | Sí | `MU/README.md:190-192`: si `TRABAJO` no está, la carpeta es `$RUNNER_TEMP`, `$TMPDIR` o `/tmp` más `/mini-demo-movilidad` (igual en `MU/verificar.sh:18`, `:29`); con esa ruta el comando da verde (E5). Defecto que queda: el bloque de `MU/README.md:286` falla tal como está escrito si no se exporta la variable |
| D-30 | No | `MU/docs/tecnica/arquitectura.md:61-63` responde la primera parte (las fichas anclan la app móvil, que es la unidad documentada; la API tiene su copia con los mismos valores). La segunda, qué control detecta un cambio de la regla en ApiWeb, no la responde ningún archivo |
| D-31 | Sí | `MU/README.md:256-258`: si lo que el código aplica contradice lo que la pantalla promete, la página dice las dos cosas «como alta-de-localidad §3»; el modelo (`MU/docs/ayuda/alta-de-localidad.md:50`, `:55-58`) pone la promesa en la tabla y el límite real en la nota. Defecto que queda: la primera oración de `MU/README.md:256` («la ayuda dice “hasta 80”») leído sólo parece pedir otra cosa |
| D-32 | Sí | `TEM-06:171-173`: desde un fork el job no corre y el cambio «no se fusiona solo: alguien con permiso lo lleva a una rama del repositorio y abre el pull request desde ahí». Defecto que queda: `MU/README.md:325-338` no lo menciona |
| D-33 | Sí | `TEM-02:233-236` (una fila `pendiente` es válida y pasa; antes de pasar un documento a `vigente` no puede quedar ninguna fila `pendiente` de la que dependa una página) con `MU/README.md:130-132` y `:337-338` (el PR se fusiona con los dos checks en verde y lista lo que queda para decidir): se fusiona en `borrador` antes de la decisión de 1b |
| D-34 | Sí | `MU/README.md:159-161`: la fuente «no se publica con este repositorio; todo lo que hace falta de él está acá», es decir, alcanza con la versión del tutorial |

**Recuento.** Respondidas: 13 (D-01, D-02, D-09, D-12, D-13, D-14, D-22, D-23, D-29, D-31, D-32, D-33, D-34). Sin
respuesta: 21 (D-03 a D-08, D-10, D-11, D-15 a D-21, D-24 a D-28, D-30). El umbral de G-e es cero dudas sin respuesta
(`SDEI/99-Anexos/Glosario.md:67`; folio 133, fila G-e): **NO CUMPLE**. Además, las trece respondidas dejan defectos
de texto anotados en la columna «Dónde», que conviene corregir en la misma reparación.

## 7. Refutación

Sostiene NO CUMPLE. Reproducida por la crítica del paquete el 2026-10-28 contra el folio `012` §6 de
Lab-Documentos.Documentacion (protocolo P-LECT):

- `012` §6 clasifica cada duda en «con respuesta no alcanzada», «hueco» o «respondida», y para E1 pide «0 dudas con
  respuesta no alcanzada; huecos = 0 o declarados fuera de alcance en el cuerpo; […] CI verde en `runs-on:
  [self-hosted, i7infra-dev]`» sobre una consigna con PR simulado. Esta acta usa dos clases (Sí/No): con las tres
  de `012`, según la refutación (la crítica no reclasificó duda por duda), D-01, D-02, D-12, D-14, D-22, D-23 y
  D-32 serían «con respuesta no alcanzada» (la respuesta existe pero el lector no llega a ella desde donde surge la
  duda), y el recuento sería más severo.
- Falta el tramo del PR simulado con CI verde (§5, primera fila: no se hizo push).
- El acta no identifica al lector (§1 no tiene ese campo).
