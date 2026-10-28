# G-g — Lista VER-* aplicable sobre el cuerpo SDEI y la mini demo

| Campo | Valor |
| --- | --- |
| Compuerta | E1-G, prueba G-g (`N09` §9.2; folio `133` §2, fila G-g: «la lista VER-* aplicable (`R07` §5) · se revisa el cuerpo · 100 % de los obligatorios · lista marcada») |
| Fecha | 2026-10-28, en hpdev (contingencia por la caída de i7infra) |
| Árbol medido | Lab-Documentos `490646b` (main tras el merge del #28), worktree de sólo lectura `{dir-de-trabajo}/ld-main`; las corridas, sobre un `git archive 490646b` en `{dir-de-trabajo}/ggld` |
| Hermano | Lab-Documentos.Documentacion `origin/main` = `f51c065` (2026-10-28 08:58 -03) |
| Alcance | `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/` (en adelante `GDE/`): README, Marco, Mapa, TEM-01…TEM-07, `99-Anexos/`, `Examples/` (mini demo `MovilidadUrbana-Mini-Demo/` incluida) |
| Resultado | **NO CUMPLE**: de 111 ítems, 73 aplican y 51 son obligatorios; cumplen 43 y no cumplen 8 (84,3 %). Además, 1 de los 6 umbrales P-5 no cumple. Ningún defecto es P0 a juicio de este despacho; la mesa decide |

## Índice

1. [Criterio de aplicabilidad y obligatoriedad](#1-criterio-de-aplicabilidad-y-obligatoriedad)
2. [Instrumentos](#2-instrumentos)
3. [Defectos hallados](#3-defectos-hallados)
4. [Tabla VER-*](#4-tabla-ver-)
5. [Umbrales P-5 (133 §4)](#5-umbrales-p-5-133-4)
6. [Recuento](#6-recuento)
7. [Observaciones](#7-observaciones)
8. [Refutación](#8-refutación)

## 1. Criterio de aplicabilidad y obligatoriedad

Ni `R07` ni `133` dicen qué VER-* son «obligatorios». La regla que sigue es **[criterio propio]** de este despacho y
la mesa puede cambiarla.

- **Aplica** cuando la columna «Aplica a» de `R07` §5 incluye **G** (guía o demos publicadas) o cuando el ítem está en
  §5.5, §5.8, §5.9, §5.10 o §5.14, que no tienen esa columna y regulan documentos. **No aplica** lo que es sólo **P**
  (proceso de la mesa) o sólo **B** (bitácoras): esos ítems no se revisan «sobre el cuerpo» (`133` §2). Tampoco
  aplica VER-C01: la fase de sólo lectura terminó con el mandato de escritura de E1 (`N10` §6). Los ítems de
  `R07` §6 (VER-P01, VER-P02) quedan fuera porque G-g nombra sólo §5.
- **Obligatorio** cuando aplica y además (a) lo citan `133` §3 o `N10` §6 como aceptación (VER-G07, VER-G08,
  VER-T01…T07, VER-A05), o (b) se responde sí/no con un comando o con una lectura dirigida a una ubicación.
- **Aplica, no obligatorio para G-g** cuando aplica pero exige juicio de lectura sin umbral (voz, claridad,
  carácter formativo, densidad de tablas): se resuelve en la P-LECT de G-e o lo juzga la mesa. Igual se marca lo
  observado.

## 2. Instrumentos

| # | Instrumento | Resultado relevante |
| --- | --- | --- |
| I-1 | `DOCS_GUARD_CACHE=… bash scripts/ci-local.sh todo` sobre `git archive 490646b` | `rc=0`. PR-1: «622 Total … 569 OK 🚫 0 Errors 👻 53 Excluded». PR-2: `errores=0 avisos=0 archivos-con-frontmatter=41 sin-frontmatter-fuera-del-cuerpo=1`. PR-3: `AI-1=0 AI-2=0 AI-3=0 AI-4=28` (avisos en `Referencias.md`). PR-4: markdownlint verde; `mermaid: verde (bloques=28 invalidos=0)`. PR-5: `trazas=121 resueltas=112` (9 avisos `traza-no-verificable` en `Prueba-Ayuda-Por-Rol`, heredado). PR-6: `contratos=1` verde. PR-7: `reflint referencias=51` verde. Autoprueba verde. «== docs-guard: verde» |
| I-2 | `awk` sobre encabezados `## ` fuera de bloques de código en `GDE/TEM-0*.md` | Los siete temas: `Definición`, `Aplicación por escenario`, `Ejemplos concretos`, `Preguntas guía`, `Criterios de calidad`, `Anexo`, en ese orden. TEM-01…03 suman `Fuentes y observaciones` |
| I-3 | `grep` de «anterior/siguiente» al pie de cada documento | Ver VER-G08 |
| I-4 | `grep '^## Índice'` sobre los `.md` agregados desde `9162e07` | Sólo `Examples/Como-Intervenir-Lab-Documentos.md` (35 líneas) no tiene índice |
| I-5 | Referencias por tema: anclas `Referencias.md#ref-…` distintas y su estado `Verificación: V/P` y «consultado el» en `99-Anexos/Referencias.md` | Ver §5 |
| I-6 | API pública de GitHub, `commits?path=…&per_page=1&until=2026-10-28T00:00:00Z`, para las 15 filas de adopciones de TEM-01 y TEM-03 | Ver §5 |
| I-7 | `git ls-tree origin/main` (f51c065) de `…/0002-…/evidencia/` en Lab-Documentos.Documentacion, y la API `git/trees/main?recursive=1` (`truncated: False`) | Existen `E1-U0a E1-U0c E1-U1 E1-U6`; **no existen** `E1-U4b` ni `E1-U4c`. `find / -xdev -name 01-tem01-inventario.sh …` en hpdev: sin resultado |
| I-8 | Cuerpos de los PR #22, #23 y #24 de Lab-Documentos (API) | #22: «Ensayos 01 a 04 en `evidencia/E1-U4b/`»; #24: «`evidencia/E1-U4c/02` a `04` del expediente» |
| I-9 | Script de TEM-04 §3.3 (`GDE/TEM-04-Doble-Audiencia.md:134-144`) corrido dos veces sobre `GDE/` | `diff` vacío; 29 líneas; las tres primeras coinciden con la salida registrada en `:150-152` |
| I-10 | API de Actions, jobs de `mini-demo-movilidad.yml` | Ver §5 |
| I-11 | `grep` de muletillas y conectores (VER-V07, VER-V08) y de rutas de host, IP privadas y usuario sobre `GDE/` sin la guía obsoleta | 0 coincidencias en prosa (la única es la definición del ítem en `Lista-De-Verificacion.md:143`) |

## 3. Defectos hallados

| Id | Defecto | Evidencia | VER afectados | Severidad propuesta |
| --- | --- | --- | --- | --- |
| D1 | TEM-01, TEM-02 y TEM-03 dicen que los guiones de sus ensayos «están en el repositorio público Lab-Documentos.Documentacion (expediente 0002 de DocAsCode, carpeta `evidencia/E1-U4b/`)», y las marcas `[Compilado: evidencia/E1-U4b/0n-….sh …]` apuntan ahí. Esa carpeta no existe en `origin/main` ni en ninguna rama remota: se escribió en i7infra y se perdió sin commitear. Los cuatro guiones (01 inventario, 02 RRD, 03 ancla, 04 adopciones) no son reproducibles desde la guía | `GDE/TEM-01-Sistema-Documentador.md:213`, `:217`, `:246`; `GDE/TEM-02-Ciclo-Documental.md:214`, `:217`; `GDE/TEM-03-Topologia-Y-Versionado.md:193`, `:213`, `:221`; I-7; I-8 | E02, E03, D01, A06, F05 y P-5 «ensayo» | P1 **[criterio propio]**: afirmación hoy falsa en un repositorio público, pero no inventada (las salidas registradas y la re-medición de I-6 concuerdan) |
| D2 | `evidencia/E1-U4c/` (ensayos de TEM-04…06 según el PR #24) tampoco existe. Los temas 04 a 07 traen el guion o los comandos en el propio documento, así que siguen siendo reproducibles desde la guía (I-9 lo comprueba para TEM-04), pero no hay ensayo en `evidencia/` como pide el umbral | I-7; I-8; `GDE/TEM-07-Marco-SDD.md:198` | P-5 «ensayo» | P2 |
| D3 | El tutorial de la mini demo, paso de la ruta «aprender» entre TEM-07 y Ejercicios (`GDE/README.md:94`; `GDE/TEM-07-Marco-SDD.md:329-331`), no enlaza al documento anterior ni al siguiente: la cadena se corta ahí | `grep -n -i 'anterior\|siguiente' GDE/Examples/MovilidadUrbana-Mini-Demo/README.md` sólo da `:113`, que no es un enlace de recorrido | G08 | P2 |
| D4 | `Examples/Como-Intervenir-Lab-Documentos.md`, creado en E1-U4d (`f697528`), no tiene índice | I-4 | M02 | P3 |
| D5 | La sección de observaciones (hechos frente a interpretaciones) está en TEM-01, TEM-02 y TEM-03 (`Fuentes y observaciones`, `:334`, `:333`, `:309`) y falta en TEM-04…07 | I-2 | E07 | P3 |

## 4. Tabla VER-*

Las rutas sin prefijo son relativas a `GDE/`. «Juicio» = aplica, no obligatorio para G-g (§1).

| VER | Aplica | Obligatorio | Cumple | Evidencia |
| --- | --- | --- | --- | --- |
| VER-W01…W05 | No (P, B) | — | — | Proceso de la mesa |
| VER-W06 | Sí (P, G) | No (proceso) | Sí | La guía de un solo archivo se conservó como `obsoleto` con tabla de destinos (`README.md:98-100`, `:124`); el ejemplo `Prueba-Ayuda-Por-Rol` se reutilizó (`README.md:126`) |
| VER-W07, W08 | No (B, P) | — | — | — |
| VER-W09 | Sí (G) | Sí | Sí | `runs-on: [self-hosted, i7infra-dev]` en `.github/workflows/docs-guard.yml:54`, `mini-demo-movilidad.yml:35`, `docs-enlaces-semanal.yml:43`. El job corre hoy en `hpdev-runner-dev`, que lleva esa etiqueta: cambio de entorno, no falla (I-10) |
| VER-N01…N09 | No (P, B) | — | — | — |
| VER-E01 | Sí | Sí | Sí | Re-medición independiente: 15/15 adopciones existen y caen en la ventana (I-6); 7/7 temas con fuentes `V` (I-5); ensayo de TEM-04 reproducido (I-9). No se halló dato inventado; la afirmación falsa de D1 es una pérdida, no una invención |
| VER-E02 | Sí | Sí | **No** | D1: cuatro marcas `[Compilado: evidencia/E1-U4b/…]` apuntan a archivos inexistentes |
| VER-E03 | Sí | Sí | **No** | D1: los ensayos 01…04 ya no se pueden verificar y el texto no lo marca. En el resto, los límites se declaran («Lo que demuestra / lo que no», `TEM-02-Ciclo-Documental.md:232-235`; `TEM-07-Marco-SDD.md:27`) |
| VER-E04 | Sí | Sí | Sí | `[criterio propio]` presente en los 7 temas (1 a 3 por tema) y en `00-Marco.md`; p. ej. `TEM-01-Sistema-Documentador.md:190`, `README.md:157` |
| VER-E05, E06, E09 | No (B) | — | — | — |
| VER-E07 | Sí | Sí | **No** (parcial) | D5: 3 de 7 temas |
| VER-E08 | Sí | Sí | Sí | Cada tema cita entre 4 y 14 referencias distintas con ancla `ref-…`, de las cuales entre 3 y 13 están verificadas en fuente primaria (I-5, §5) |
| VER-G01 | Sí (P, G) | Sí | Sí | El esqueleto (README, Marco, Mapa, anexos) entró en E1-U4a antes que los temas (PR #20, después #22, #24, #23; `git log` de `GDE/`); el orden de lectura es README → Marco → Mapa → temas → anexos (`README.md:94`) |
| VER-G02 | Sí | Sí | Sí | Escenarios, contextos y actores se definen sólo en `00-Marco.md` §2 (`:54`), §3 (`:111`) y §4 (`:140`); los temas los citan por ID (`ESC-SDEI-n`, `CTX-SDEI-n`, `ACT-SDEI-n`) |
| VER-G03 | Sí | Sí | Sí | Los 7 temas tienen `## Aplicación por escenario` (I-2) |
| VER-G04 | Sí | Sí | Sí | `01-Mapa.md` §2 Por escenario (`:51`), §3 Por contexto (`:60`), §4 Por artefacto (`:74`), §5 Por actor (`:98`) |
| VER-G05 | Sí | Sí | Sí | `99-Anexos/Como-Decidir.md`: criterios, escala anclada, filtros, regla de firmeza y matriz trabajada |
| VER-G06 | Sí | Sí | Sí | Plantillas comentadas en el `## Anexo` de los 7 temas; `99-Anexos/Lista-De-Verificacion.md`; `99-Anexos/Glosario.md` |
| VER-G07 | Sí | Sí (133 §3, E1-U4a) | Sí | `README.md` §3 (`:65-100`, tres rutas) y §4 (`:102-129`, 24 filas: README, Marco, Mapa, 7 temas, 8 anexos, guía obsoleta, tutorial, ejemplo por rol, Lanzar, plantilla e instancia) |
| VER-G08 | Sí | Sí (133 §3, E1-U4b/c/d) | **No** (parcial) | Los 7 temas cumplen (`TEM-01…:348`, `TEM-02…:348`, `TEM-03…:325`, `TEM-04…:278`, `TEM-05…:280`, `TEM-06…:310`, `TEM-07…:329`), igual que Marco (`:196`) y Mapa (`:128`). Los anexos cierran con «Volver al Mapa» y no quedan huérfanos. Falla D3 |
| VER-G09 | Sí | No (es la propia compuerta E1-G) | — | Lo resuelve la mesa de E1-G con G-a…G-g |
| VER-G10 | Sí | Juicio | — | P-LECT (G-e) |
| VER-T01 | Sí | Sí (133 §3) | Sí | `### Qué no es` o «**Qué no es.**» dentro de `## Definición` en los 7: `TEM-01…:133`, `TEM-02…:147`, `TEM-03…:129`, `TEM-04…:54`, `TEM-05…:57`, `TEM-06…:57`, `TEM-07…:73` |
| VER-T02 | Sí | Sí (133 §3) | Sí | `## Aplicación por escenario` en los 7 (I-2) |
| VER-T03 | Sí | Sí (133 §3) | Sí | `## Ejemplos concretos` en los 7, con casos del dominio (mini demo MovilidadUrbana, Lab-Geometria en `5f07b12`, portal de un proveedor de notificaciones) |
| VER-T04 | Sí | Sí (133 §3) | Sí | `## Preguntas guía` en los 7 (I-2) |
| VER-T05 | Sí | Sí (133 §3) | Sí | `## Criterios de calidad` en los 7 (I-2) |
| VER-T06 | Sí | Sí (133 §3) | Sí | `## Anexo` con plantilla y la pregunta de cada campo en los 7; p. ej. `TEM-04…:243-260` (comentario `#` por campo), `TEM-06…:292-305` (columna «Pregunta que lo guía»), `TEM-07…:304-320` |
| VER-T07 | Sí | Sí (133 §3) | Sí | Los seis encabezados son idénticos y van en el mismo orden en los 7 (I-2) |
| VER-M01 | Sí | Sí | Sí | PR-4 markdownlint verde con MD001, MD003, MD024 (siblings), MD025 (`scripts/docs-guard.markdownlint-cli2.jsonc`); I-1 |
| VER-M02 | Sí | Sí | **No** | D4. Además, sin índice y heredados de antes de E1: `Examples/Lanzar-Example.md` y la guía `obsoleta` |
| VER-M03 | Sí | Juicio | — | P-LECT (G-e) |
| VER-M04 | Sí | Sí | Sí | `awk`: ningún encabezado fuera de código seguido directamente de otro de nivel igual o superior en los `.md` del cuerpo y la mini demo (0 coincidencias) |
| VER-M05 | Sí | Juicio | — | Sin umbral. Hay celdas largas, p. ej. `TEM-04-Doble-Audiencia.md:88` y `:169` |
| VER-M06 | Sí | Sí | Sí | 0 bloques de código sin lenguaje fuera de la guía obsoleta (`awk` sobre aperturas de bloque) |
| VER-M07 | Sí | Sí | Sí | 28 bloques Mermaid (I-1). El árbol de carpetas en `text` de `README.md:139-146` es un listado, no un diagrama |
| VER-M08 | Sí | Sí | Sí | `PR-4 mermaid: verde (bloques=28 invalidos=0)` (I-1) |
| VER-M09 | Sí | Sí | Sí | 15 marcas `[Compilado…]` y 16 `[Fragmento ilustrativo…]` en el cuerpo y la mini demo. La marca existe en todas; la procedencia rota de cuatro de ellas está en A06 |
| VER-M10 | Sí | Sí | Sí | lychee `--offline --include-fragments`: 569 OK, 0 errores (I-1). Las rutas de D1 son texto, no enlaces, y no las ve lychee |
| VER-M11 | Sí | Juicio | — | P-LECT (G-e) |
| VER-D01 | Sí | Sí | **No** | D1 (estado real del repositorio hermano mal descripto) |
| VER-D02 | Sí | Juicio | — | — |
| VER-D03 | Sí | Sí | Sí | `01-Mapa.md` §2-§5; `TEM-03-Topologia-Y-Versionado.md` (topologías y anclas); `Examples/Como-Intervenir-Lab-Documentos.md:20-27` |
| VER-D04 | Sí | Juicio | — | P-LECT (G-e) |
| VER-D05 | Sí | Sí | Sí | `Examples/Como-Intervenir.md` §3-§7, con `entradas`/`salidas`/`validaciones` por paso (`:70-76`, `:88-94`, `:113-120`) y la vuelta del rojo (`:53`, `:62`); `Examples/MovilidadUrbana-Mini-Demo/docs/tecnica/compilar-y-primer-pedido.md` §1-§6 |
| VER-D06 | Sí | Sí | Sí | `Examples/MovilidadUrbana-Mini-Demo/docs/tecnica/arquitectura.md` §2 Capas, §3 Dónde vive cada regla, §4 límites |
| VER-D07 | Sí | Sí | Sí | `corpus_id` y `version` sólo en `README.md` (`grep -rln '^corpus_id'` da un archivo); los términos viven en el Glosario y el contrato en el Esquema |
| VER-D08 | Sí | Sí | Sí | Temas de 279 a 349 líneas, anexos de 72 a 202, cada uno de un solo asunto (`wc -l`). La guía de 841 líneas es la `obsoleta` |
| VER-D09 | Sí | Sí | Sí | La guía de un solo archivo se conserva como `obsoleto`, con su tabla de destinos (`README.md:98-100`, `:124`) |
| VER-H01 | Sí | Sí | Sí | Los 16 documentos de prosa creados en E1 abren con un párrafo de qué es y para qué (primer párrafo tras el H1, p. ej. `TEM-03…:17`, `01-Mapa.md:17`). `Lanzar-Example.md` (heredado) abre con «Invocación» |
| VER-H02 | Sí | Juicio | — | Hay casos de punta a punta (`00-Marco.md` §6 `:173`; mini demo §5) |
| VER-H03 | Sí | Juicio | — | — |
| VER-H04 | Sí | Sí | Sí | `## Preguntas guía` en los 7 temas, `00-Marco.md:188` y `01-Mapa.md:122` |
| VER-H05 | Sí | Juicio | — | TEM-01…03 usan «Precondición / Resultado esperado / Lo que demuestra»; TEM-04…07 lo dicen en prosa libre (p. ej. `TEM-04…:128-131`) |
| VER-A01 | Sí | Sí | Sí | PR-2 verde, 41 archivos con frontmatter validados contra el esquema (I-1). El único sin frontmatter es `Examples/Prueba-Ayuda-Por-Rol/README.md`, exceptuado por diseño (`README.md:148`) |
| VER-A02 | Sí | Sí | Sí | PR-5 `traces-resolve` verde: 112 de 121 resuelven; las 9 restantes son avisos de IDs externos del ejemplo heredado por rol (I-1). El detalle está en `evidencia/E1-G/G-d-traces.txt` |
| VER-A03 | Sí | Sí | Sí | Los temas comparten los seis encabezados y sus anclas (I-2). La sección extra de TEM-01…03 no rompe anclas (ver D5) |
| VER-A04 | Sí | Sí | Sí | 28 diagramas en Mermaid; los únicos binarios son las 7 capturas PNG de `Examples/Prueba-Ayuda-Por-Rol/capturas/`, que no tienen alternativa como código |
| VER-A05 | Sí | Sí (133 §3) | Sí | `Examples/Como-Intervenir.md:23-24` define los tres bloques; `:113-120` nombra `scripts/ci-local.sh todo` como validación |
| VER-A06 | Sí | Sí | **No** | D1: 4 de 15 marcas `[Compilado…]` citan rutas que no existen. Las demás llevan ruta, rango y versión (p. ej. `TEM-06…:198`, `TEM-05…:119`, `:168`) |
| VER-A07 | Sí | Juicio | — | — |
| VER-V01…V06, V09…V11 | Sí | Juicio | — | P-LECT (G-e) |
| VER-V07 | Sí | Sí | Sí | 0 muletillas de la lista en la prosa del cuerpo (I-11) |
| VER-V08 | Sí | Sí | Sí | 0 conectores de la lista al inicio de oración (I-11) |
| VER-I01…I03, I05 | No (P, B) | — | — | — |
| VER-I04 | Sí (G) | Sí | Sí | La ia-db v4.1 de Lab-Documentos.Documentacion indexa hasta `fe10086` (`ia-db/README.md:122`). `git diff --name-status fe10086 490646b` no agrega documentos al cuerpo: sólo modifica archivos existentes (README, Marco, Mapa, TEM-03, TEM-06) y suma fixtures. El desfase de tres merges sólo avisa (D04) |
| VER-I06 | Sí | Juicio | — | — |
| VER-S01…S08 | No (P) | — | — | — |
| VER-C01 | No | — | — | Restricción de la fase 1, de sólo lectura |
| VER-C02 | Sí | Sí | Sí | 0 rutas de host, IP privadas o usuario (I-11). El barrido formal es G-f (`evidencia/E1-G/G-f-barrido-s2.txt`) |
| VER-C03 | Sí | Sí | Sí | Los repositorios públicos se nombran (Lab-Documentos, Lab-Geometria, MovilidadUrbana, IA.SDD) |
| VER-C04, C05 | No (P) | — | — | — |
| VER-F01…F04 | No | — | — | Cierre y reporte de la corrida: los cubre el folio de E1-G |
| VER-F05 | Sí | Sí | **No** | D1: el cuerpo contradice el estado del repositorio hermano |

## 5. Umbrales P-5 (133 §4)

| Umbral | Medida | Cumple |
| --- | --- | --- |
| ≥ 3 fuentes primarias con fecha por tema | Referencias distintas citadas / verificadas `V` / con fecha de consulta: TEM-01 14/13/14; TEM-02 6/6/6; TEM-03 11/11/11; TEM-04 7/7/7; TEM-05 4/3/3 (más van der Meij y Carroll, 1995, libro, `P`); TEM-06 4/4/4; TEM-07 6/6/6 | **Sí** (mínimo 3, en TEM-05) |
| ≥ 1 ensayo reproducible en `evidencia/` por tema | `evidencia/E1-U4b/` y `evidencia/E1-U4c/` no existen en `origin/main` (I-7). TEM-01…03 remiten a guiones perdidos (D1). TEM-04…07 traen guion o comandos en el propio documento; el de TEM-04 se reprodujo (I-9). Ninguno de los 7 está en `evidencia/` | **No** |
| ≥ 2 adopciones públicas ≤ 24 meses por práctica (TEM-01, TEM-03) | P1 3, P2 2, P3 3, P4 2, P5 2, P6 2. Re-medido (I-6): 15/15 filas dentro de la ventana (la más vieja, `github/docs` `.github/workflows/link-check-daily.yml`, 2026-01-26); 13/15 dan el mismo commit; `MicrosoftDocs/azure-docs/articles` y `github/rest-api-description/descriptions` dan uno posterior del mismo 2026-10-27, que es deriva esperable de rutas vivas | **Sí** |
| «mini» ≤ 20 piezas | `find …/MovilidadUrbana-Mini-Demo -type f \| wc -l` = 10 | **Sí** |
| «mini» 1 workflow | Sólo `.github/workflows/mini-demo-movilidad.yml` la nombra (`grep -l`) | **Sí** |
| «mini» < 15 min | `timeout-minutes: 15` (`mini-demo-movilidad.yml:36`). Jobs: 117 s en `i7infra-runner-dev` (run 40578471106, `workflow_dispatch` sobre `080f158`); 35 s, 35 s y 44 s en `hpdev-runner-dev` (runs 40628593557, 40682342976, 40682963933, cabezas `4fbcc33` y `56f40c5` del #28) | **Sí** |

URLs: `https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40578471106`,
`https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40682963933`.

Re-medición de adopciones (I-6), salida completa:

```text
P1   github/docs                  content                                  ee20fda5d481 2026-10-27 coincide=True
P1   github/docs                  .github/workflows/link-check-daily.yml   7abf80d21149 2026-01-26 coincide=True
P1   kubernetes/website           content/en                               ed70e311737a 2026-10-26 coincide=True
P1   MicrosoftDocs/azure-docs     articles                                 0c91eeb5e679 2026-10-27 coincide=False (esperado d7e590b)
P2   github/rest-api-description  descriptions                             69fa1a67ff3b 2026-10-27 coincide=False (esperado a5c38c1)
P2   stripe/openapi               openapi                                  a6cd9878ad3d 2026-10-26 coincide=True
P3   mintlify/docs                .vale.ini                                4a8f15c3dc3f 2026-08-14 coincide=True
P3   openshift/openshift-docs     .vale.ini                                df831314fea6 2026-08-25 coincide=True
P3   grafana/grafana              .vale.ini                                5427e8d92b28 2026-08-03 coincide=True
P4   backstage/backstage          docs                                     82079b4e75b6 2026-10-27 coincide=True
P4   grafana/grafana              docs/sources                             7b102dddd2bf 2026-10-27 coincide=True
P5   kubernetes/website           content/en                               ed70e311737a 2026-10-26 coincide=True
P5   istio/istio.io               content                                  2100f4033a62 2026-10-27 coincide=True
P6   facebook/docusaurus          website/versioned_docs                   206e741f1fed 2026-10-16 coincide=True
P6   jestjs/jest                  website/versioned_docs                   ea7258e3338b 2026-08-31 coincide=True
```

## 6. Recuento

| Conjunto | Cantidad |
| --- | --- |
| Ítems de `R07` §5 | 111 (W 9, N 9, E 9, G 10, T 7, M 11, D 9, H 5, A 7, V 11, I 6, S 8, C 5, F 5) |
| Aplican | 73 (W06, W09; E01-E04, E07, E08; G01-G10; T01-T07; M01-M11; D01-D09; H01-H05; A01-A07; V01-V11; I04, I06; C02, C03; F05) |
| Obligatorios | 51 (W09; E01-E04, E07, E08; G01-G08; T01-T07; M01, M02, M04, M06-M10; D01, D03, D05-D09; H01, H04; A01-A06; V07, V08; I04; C02, C03; F05) |
| Obligatorios que cumplen | 43 (84,3 %) |
| Obligatorios que no cumplen | 8: E02, E03, E07, G08, M02, D01, A06, F05. El defecto D1 solo explica cinco (E02, E03, D01, A06, F05) |
| Umbrales P-5 que no cumplen | 1 de 6 (ensayo en `evidencia/`) |

## 7. Observaciones

**Hechos.**

- La compuerta `docs-guard` está en verde sobre `490646b` y no puede ver D1: lychee revisa enlaces, y las rutas a
  `evidencia/E1-U4b/` están escritas como texto en code spans y en marcas `[Compilado: …]`.
- Los PR #22 y #24 declararon «Sí» en el umbral del ensayo (I-8), cuando los guiones existían en i7infra. La pérdida
  vino después y es la misma que se llevó los folios 230 y E1-U2…U5.
- Las salidas registradas en TEM-01 y TEM-03 concuerdan con la re-medición de I-6, así que la tabla de adopciones se
  puede reconstruir sin el guion perdido.

**Interpretaciones** (criterio propio).

- La reparación de D1 y D2 es barata. Hay dos caminos: volver a escribir los cuatro guiones de `E1-U4b` (sus salidas
  están en los temas y bastan como oráculo) y versionarlos en `evidencia/` con un PR al hermano, o pasar el guion al
  propio tema, como ya hacen TEM-04…07, y corregir el texto. El segundo camino deja el umbral P-5 «en `evidencia/`»
  sin cumplir, salvo que la mesa lo reinterprete como «reproducible desde un repositorio público».
- D3, D4 y D5 son de forma y se corrigen en un solo PR de clase P.
- Ningún defecto bloquea el uso de la guía ni rompe la compuerta, por eso no se proponen como P0. Si la mesa entiende
  que una afirmación falsa en un repositorio público es P0 (VER-E01/E02), D1 sube de severidad.

## 8. Refutación

Sostiene NO CUMPLE. Reproducida por la crítica del paquete el 2026-10-28 sobre `490646b`:

- El NO CUMPLE no depende del criterio propio de §1: con sólo los VER que cita `133` §3, VER-G08 falla por D3.
- Marcas `[Compilado: evidencia/E1-U4b/…]`: son 5 (`TEM-01:217`, `:246`; `TEM-02:217`; `TEM-03:193`, `:221`) para 4
  guiones; las otras 3 líneas de D1 (`TEM-01:213`, `TEM-02:214`, `TEM-03:213`) nombran la carpeta en prosa.
- La medida de «mini < 15 min» sobre las cabezas del #28 vale para `490646b`: `git diff --stat 56f40c5 490646b --
  <mini demo> .github/workflows/mini-demo-movilidad.yml` vacío.
- VER-G08 se evaluó con indulgencia: «Volver al Mapa» no es anterior/siguiente, y `Ejercicios.md` y
  `Como-Intervenir-Lab-Documentos.md` tampoco enlazan anterior/siguiente (no re-medido por la crítica).
- VER-A02 depende de G-d (§5 de `G-d-traces.txt`).
