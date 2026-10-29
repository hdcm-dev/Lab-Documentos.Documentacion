---
doc_id: EXP0002-F290
doc_type: acta
title: Compuerta E1-G — verificación del escalón 1, recorrido punta a punta, demo viva y corte
status: vigente
origin: agent
confidence: alta en lo medido (API de GitHub, corridas del runner, ci-local, verificar.sh, barrido S2); media en G-e y G-g, que dependen de lectura y de un umbral provisional
owner: presidencia de la mesa de Replanteo y análisis DocAsCode (despacho E1G)
last_review: 2026-10-28
audience: [presidencia, mesa, PO, agentes de E2]
traces: [EXP0002-F129, EXP0002-F130, EXP0002-F131, EXP0002-F133, N09, N10, R07]
---

# 290 — Compuerta E1-G

| Campo | Valor |
| --- | --- |
| Tipo | acta de compuerta (G-a…G-g de `133` §2; corte de `133` §5) |
| Fecha | 2026-10-28 |
| Autor | Despacho E1G de la presidencia |
| Base verificada | Lab-Documentos `fe10086` (merge de E1-U4f); Lab-Documentos.Documentacion `e0e520f` (merge de E1-U5); Lab-E2E.WebBlazor `59399ba` (merge de E1-U6); Lab-Geometria `5f07b12` (sin cambios de E1) |
| Reparación | PRs [#26](https://github.com/hdcm-dev/Lab-Documentos/pull/26) y [#27](https://github.com/hdcm-dev/Lab-Documentos/pull/27) de Lab-Documentos (fusionados por `CPA`); [#28](https://github.com/hdcm-dev/Lab-Documentos/pull/28) abierto, clase H, espera a una persona (ver §6) |
| Evidencia | `evidencia/E1-G/` (01 a 05) |

## Índice

1. [Definiciones](#1-definiciones)
2. [Método](#2-método)
3. [Verificación por unidad](#3-verificación-por-unidad)
4. [Criterios de compuerta G-a…G-g](#4-criterios-de-compuerta-g-ag-g)
5. [Recorrido punta a punta](#5-recorrido-punta-a-punta)
6. [Reparaciones de la compuerta](#6-reparaciones-de-la-compuerta)
7. [Prueba de lectura (G-e)](#7-prueba-de-lectura-g-e)
8. [Lista VER-* (G-g)](#8-lista-ver--g-g)
9. [Demo viva para el PO](#9-demo-viva-para-el-po)
10. [Corte](#10-corte)
11. [Lecciones de decisión](#11-lecciones-de-decisión)
12. [Pendientes y punto de continuación](#12-pendientes-y-punto-de-continuación)
13. [Huella](#13-huella)
14. [Anexo A — Propuesta al dueño del Profile (L6)](#14-anexo-a--propuesta-al-dueño-del-profile-l6)

## 1. Definiciones

| Término | Significado en este folio |
| --- | --- |
| Cabeza auditada | `head.sha` del PR en la última relectura de la guarda G1–G4, sobre el que corrió la CI |
| Árbol igual | El commit de merge y la cabeza auditada tienen el mismo `tree`: lo que se fusionó es byte a byte lo que la CI verificó |
| P-LECT | Prueba de lectura de F012 §6: un lector sin contexto recibe el texto y una consigna real, y lista cada pregunta que le quedó planteada |
| Hueco | Pregunta que ningún documento recibido responde ni dice dónde buscar |
| No alcanzada | Pregunta cuya respuesta el texto ubica en un documento que el lector no recibió |
| Obligatorio (VER-*) | Ítem de `R07` §5 que aplica a G (guía o demo publicada) y es comprobable con sí/no sobre el entregable; los de voz narrativa se revisan por muestreo y no bloquean (§8) |

## 2. Método

| Paso | Instrumento | Salida |
| --- | --- | --- |
| PRs, cabezas, corridas, ramas | API REST de GitHub (`/pulls/{n}`, `/actions/runs?head_sha=`, `/branches/{ref}`) | `evidencia/E1-G/01` |
| Árbol del merge frente al de la cabeza | `git rev-parse <sha>^{tree}` en clones aislados | `evidencia/E1-G/01` |
| docs-guard completo en local | `scripts/ci-local.sh todo` (los 8 grupos y la autoprueba) | `evidencia/E1-G/02` |
| Mini demo según su README | `verificar.sh` en contenedor `--rm` | `evidencia/E1-G/03` |
| Lectura sin contexto | `claude -p --tools ""` (sin herramientas ni repositorio), tres lectores | `evidencia/E1-G/04` |
| Barrido S2 | `git diff -U0 <base>..main` filtrado por el patrón de 099 §11 extendido por la carta | `evidencia/E1-G/05` |
| Demo viva | Sitio de lectura armado sólo para la demo, en contenedor del anfitrión de desarrollo | §9 |

## 3. Verificación por unidad

Para las catorce unidades: PR fusionado por `CPA`, rama remota borrada (404), CI en éxito sobre la cabeza auditada en
`[self-hosted, i7infra-dev]` (Lab-E2E.WebBlazor usa `ubuntu-latest`, ver LD-23 de U6) y árbol del merge igual al de la
cabeza salvo U0b (ver nota). Criterios de `133` §3, contrastados con el folio de cada unidad y con `main`.

| Unidad | PR | Merge | Cabeza | Corridas sobre la cabeza | Criterios de 133 §3 | Veredicto |
| --- | --- | --- | --- | --- | --- | --- |
| E1-U0a | LD #11 | `f603984` | `87c3b65` | docs-guard, framework-concept-demo | Delegación en CHANGELOG; verde sobre `head.sha`; par rojo/verde (#12); runner sin `container:` | PASA |
| E1-U0b | LDD #17 | `34bdd44` | `0cf7e8a` | Verificar | Delegación; E-F12 (job llamado en `i7infra-dev`); par rojo/verde (#18) | PASA (nota 1) |
| E1-U0c | LDD #20 | `60d94f3` | `cc2bfd6` | Verificar 40526214446 | S2 vacío; `evidencia/local` = 0; verificar verde | PASA |
| E1-U1 | LD #15 | `ad71e47` | `fa33bc0` | docs-guard 40514695217, fw | `lychee --offline` 0; «adoptad» 0; línea de base 0 en PR-1/PR-4 | PASA |
| E1-U2 | LD #16 | `c0766dc` | `f9ebd8a` | docs-guard 40554387515, fw, semanal | Par por control (18 defectos); AI-3/AI-4 avisan; AK-7 rojo; issue #18; E-F10, E-F14; tag `docs-guard-v1.0.0` | PASA |
| E1-U3 | LD #19 | `080f158` | `c8b3183` | docs-guard 40576440302, mini-demo 40576440254, fw | Trazas 17/17; RN-LOC-01 rojo; contrato 0/1; «mini» 13 piezas, 1 workflow, 1 min 35 s; 0 archivos de Lab-E2E; P-LECT en parte | PASA con G-e en §7 |
| E1-U4a | LD #20 | `e57aae2` | `db7c8ce` | docs-guard 40567848891, fw | Verde; diez campos + `description`; README con rutas; anexos desde el Mapa | PASA |
| E1-U4b | LD #22 | `6832a75` | `6dddbd7` | docs-guard 40585466886, fw | Seis encabezados; anterior/siguiente; APA con fecha; P-5 (14/6/11 fuentes, 1 ensayo por tema, P1–P6 con ≥ 2 adopciones) | PASA |
| E1-U4c | LD #24 | `ecb6342` | `fc6351e` | docs-guard 40590237182, fw | Ídem para TEM-04…06 (7/3/4 fuentes, 1 ensayo cada uno) | PASA |
| E1-U4d | LD #23 | `2fdf859` | `f697528` | docs-guard 40588253783, fw | TEM-07; «Cómo intervenir» con bloques y `ci-local.sh` (VER-A05) | PASA |
| E1-U4e | LD #21 | `4fa998e` | `c483d80` | docs-guard 40580884735, mini-demo, fw | `AGENTS.md` existe; lychee 26/26; fuera de AI-3 por huella | PASA |
| E1-U4f | LD #25 | `fe10086` | `6839258` | docs-guard 40593745133, mini-demo, fw | Tabla 47/47; 0 URL sin fecha en lo que bloquea; `url-fecha` con prueba negativa | PASA |
| E1-U5 | LDD #22 | `e0e520f` | `8ef1fb0` | Verificar 40597128735 | 55/55 piezas indexadas; `base_commit` = `fe10086` | PASA |
| E1-U6 | LE #12 | `59399ba` | `83542ab` | CI 40505728851 | Carta con H-L07 y C-1…C-4; 1 archivo, sin código | PASA |

LD = Lab-Documentos, LDD = Lab-Documentos.Documentacion, LE = Lab-E2E.WebBlazor; «fw» = framework-concept-demo.

**Nota 1 (U0b).** Es el único merge cuyo árbol difiere del de su cabeza: la rama no estaba al día con `main` y
Lab-Documentos.Documentacion no exige rama al día. La corrida de Verificar por `workflow_dispatch` sobre `main`
`e0e520f` (40598387395, éxito), que contiene ese merge, cubre la diferencia.

## 4. Criterios de compuerta G-a…G-g

| # | Criterio (133 §2) | Evidencia | Veredicto |
| --- | --- | --- | --- |
| G-a | Folio 133 anterior a la primera rama de E1 | Folio 133 creado 2026-10-27 09:37:51 −03 y sin modificar desde entonces (fecha de creación = fecha de modificación); primer commit de E1: `83542ab` (U6) 09:41:00 −03 y `8c3fc99` (U0a) 09:42:19 −03 | **PASA** |
| G-b | Corrida verde sobre el SHA del merge en `[self-hosted, i7infra-dev]` | 13 de 14 merges tienen árbol igual a la cabeza auditada, cuya corrida es verde (§3); U2 y U3 además tienen corrida sobre el merge (40556547619, 40578471106); U0b lo cubre la corrida sobre `main` (nota 1). Desde #26, `docs-guard` corre en `push` a `main`, y la corrida sobre el merge de #26 queda como prueba literal (§6) | **PASA** (equivalencia por árbol, reparada hacia adelante) |
| G-c | Par rojo/verde por control bloqueante | U0a (#12), U0b (#18), U2 (18 defectos, uno por grupo); la autoprueba de cada corrida repite el par por control: 21 pares `ok` en `evidencia/E1-G/02` | **PASA** |
| G-d | `traces-resolve` resuelve el 100 % | Grupo `trazas` verde en `evidencia/E1-G/02`; mini demo 17/17 trazas y 10/10 anclas contra `8fb4c3a` (`03`) | **PASA** |
| G-e | P-LECT del tutorial y de la guía con cero dudas sin respuesta | Tres lectores (§7): 0 huecos de gravedad alta; huecos 19 (tutorial), 12 y 12 (guía, antes y después de la reparación) | **NO PASA** el umbral literal; sin P0 (§7, LD-E1G-03) |
| G-f | Barrido S2 vacío en lo versionado | Sobre las líneas que E1 agregó a los cuatro repos públicos: 0 rutas personales, 0 IP, 0 usuarios, 0 repos privados; las coincidencias son falsos positivos o heredadas (`05`) | **PASA** |
| G-g | 100 % de los VER-* obligatorios | 44 de 45 al verificar: VER-A01 fallaba en 5 archivos con frontmatter que no es YAML válido (§8). Tras #27, 45/45 en el cuerpo SDEI; `AGENTS.md` queda en #28 (clase H) | **PASA en el cuerpo; reserva en `AGENTS.md` hasta #28** |

## 5. Recorrido punta a punta

| Tramo | Cómo | Resultado |
| --- | --- | --- |
| La guía se lee desde su README | README raíz → cuerpo SDEI → Marco → Mapa → TEM-01…07 → anexos; cada tema enlaza anterior y siguiente (TEM-01 empieza en el Mapa; TEM-07 nombra el escalón 2) | Navegable. Antes de #26, el README raíz y `Guides/README.md` mandaban a la guía `obsoleta`: reparado (§6) |
| La mini demo arranca según su README | §4 del tutorial: `verificar.sh` desde la raíz del repositorio | `== mini demo: verde` en 45 s: C1 contrato 8 operaciones = extraído; C2 plantado rojo; C3 trazas 17/17, anclas 10/10; C4 RN-LOC-01 1.0 rojo por el 60/80; A1 sin deriva frente a `main` `59399ba` (`03`) |
| docs-guard corre verde en el runner | PR #26: corrida de `docs-guard` 40626573338 en `[self-hosted, i7infra-dev]` | Éxito; los 8 grupos en verde (`02` en local) |

## 6. Reparaciones de la compuerta

PR [#26](https://github.com/hdcm-dev/Lab-Documentos/pull/26) de Lab-Documentos (`exp0002/e1g-reparaciones`), dos commits.

| Cambio | Por qué | Criterio |
| --- | --- | --- |
| `docs-guard.yml` corre en `push` a `main` y por `workflow_dispatch` | Ningún merge de E1 tenía corrida propia: los workflows sólo corrían en `pull_request` | G-b |
| `framework-concept-demo.yml`: `actions/checkout@v4` → SHA de v4.2.2 | La carta exige actions fijadas por SHA; era el único workflow que no cumplía (hallazgo de U5) | Seguridad de CI |
| README raíz y `Guides/README.md` apuntan al README del cuerpo SDEI y nombran `AGENTS.md` | Mandaban a la guía `obsoleta` (hallazgo de U5) | VER-G08, recorrido |
| README del cuerpo: el diagrama ya no marca temas «en redacción» | Los siete existen (hallazgo de U5) | VER-D01 |
| Marco (definición de traza), Mapa §3 (fila nueva) y README (ruta intervenir) | Huecos reales de la P-LECT ronda 1: traza sin versión, `traces-resolve` sin `corpus_id`, página que no traza a ninguna ficha, ruta de quien recién llega | G-e |

Ensayo: `ci-local.sh todo` verde sobre la cabeza `e83f373` (`02`); barrido S2 del diff vacío. Guarda G1–G4 en
`clean` con las dos corridas en éxito (docs-guard 40626573338, framework-concept-demo 40626573336); merge atado al SHA
en `56ea2d3`, árbol igual a la cabeza; rama borrada (404). **G-b literal:** la primera corrida de `docs-guard` por
`push` sobre el merge `56ea2d3` (40628034346) dio éxito en `i7infra-runner-dev` con `[self-hosted, i7infra-dev]`.

**Segundo hallazgo: frontmatter que no es YAML.** Al renderizar el cuerpo para la demo (§9), el frontmatter del README
del cuerpo salió como texto. Un lector YAML estricto (PyYAML) sobre los 279 `.md` con frontmatter de Lab-Documentos
dio 35 inválidos, todos por un valor sin comillas con «: »: 30 heredados (`Guides/Despliegue/Documentacion-Informe-Despliegue/`,
fuera de la ruta de la compuerta) y 5 de E1 (README del cuerpo, TEM-03, TEM-06, `AGENTS.md`, un fixture). `dg.py`
usa un subconjunto propio de YAML y no lo veía, así que PR-2 daba verde con VER-A01 incumplido.

| PR | Cambio | Clase | Estado |
| --- | --- | --- | --- |
| [#27](https://github.com/hdcm-dev/Lab-Documentos/pull/27) | Regla `frontmatter-no-yaml` en PR-2 (rojo en cuerpo nuevo, aviso en lo heredado) con par rojo/verde en la autoprueba; comillas en README, TEM-03, TEM-06 y el fixture; fila «Estado» del README actualizada | P | Fusionado por `CPA` (§13) |
| [#28](https://github.com/hdcm-dev/Lab-Documentos/pull/28) | `AGENTS.md`: comillas en `description` y huella AK-3 renovada en `excepciones.txt` | H (renovar una excepción AK-3, D08) | **Abierto: lo aprueba una persona** |

## 7. Prueba de lectura (G-e)

Consigna común: lista numerada de cada pregunta que el texto dejó planteada, con clase (respondida, no alcanzada,
hueco) y gravedad (alta, media, baja). Texto completo y respuestas en `evidencia/E1-G/04`.

| Lector | Recibió | Consigna real | Preguntas | Respondidas | No alcanzadas | Huecos | Altas |
| --- | --- | --- | --- | --- | --- | --- | --- |
| 1 | Tutorial, RRD, RN-LOC-02, ayuda de alta, README del cuerpo (`fe10086`) | Documentar el paso 1 de una encuesta | 45 | 16 | 10 | 19 | 1 (no alcanzada: el código del SHA) |
| 2 | README, Marco, Mapa, Glosario, `AGENTS.md` (`fe10086`) | Ubicarse, qué aplicar, frontmatter, tema de CI | 34 | 14 | 8 | 12 | 0 |
| 3 | Lo mismo que 2 más el anexo del esquema (`e83f373`) | Ídem | 37 | 21 | 4 | 12 | 0 |

Lectura. La única alta es por diseño: el lector no tiene el código del SHA, que `verificar.sh fuente` baja. Varios
«huecos» del lector 1 están respondidos en el tutorial (§5.2 a §5.5: rama, cuerpo del PR, requisitos previos,
mensajes generales); el lector no los encontró. Los huecos de gravedad media del lector 2 que eran faltas del texto se
corrigieron en `e83f373`; el lector 3 abrió bordes nuevos (un quinto escenario, el ancla en el mismo repositorio, la
coincidencia anexo-esquema), como en las 9 rondas de U3 y las 3 de U4a, U4b y U4c. El cero literal no converge con
este protocolo: cada lector nuevo lee un texto más largo y pregunta más. Veredicto: **G-e NO PASA** el umbral literal;
no es P0 porque ninguna pregunta de gravedad alta queda sin respuesta en el cuerpo y la navegación resuelve las no
alcanzadas. Ver LD-E1G-03 y el pendiente PE-1.

## 8. Lista VER-* (G-g)

Obligatorios: los ítems de `R07` §5.4 a §5.9 y §5.11 que aplican a G y se responden con sí/no sobre el cuerpo SDEI y la
mini demo. Los de voz narrativa (§5.10) y los de juicio global (VER-G09, G10, D02, D04, H02) se revisaron por muestreo
sobre TEM-04 y el tutorial y no bloquean.

| Grupo | Ítems | Cumple | Evidencia |
| --- | --- | --- | --- |
| Estructura de la guía | G01–G08 | 8/8 | Mapa (G04), Cómo decidir (G05), 8 anexos con plantillas, lista y glosario (G06), README §3–§4 (G07), anterior/siguiente en los siete temas (G08); ejes una vez en el Marco (G02); cada tema con «Aplicación por escenario» (G03); orden del plan N10 §14 (G01) |
| Documento temático | T01–T07 | 7/7 | Los siete temas tienen los seis H2 `Definición`…`Anexo`, con el mismo nombre (encabezados de plantilla dentro de bloques de código no cuentan) |
| Markdown | M01–M10 | 10/10 | PR-4 (markdownlint, mermaid), PR-1 (enlaces) en verde; índice en todo documento con secciones (M02, ver observación) |
| Contenido | D01, D03, D05–D09 | 7/7 | D05: «Cómo intervenir» con objetivo, pasos, validaciones y errores; D09: la guía vieja queda `obsoleta`, sin borrar |
| Cara humana | H01, H03–H05 | 4/4 | Resumen en el primer párrafo de cada tema; Glosario; preguntas guía; ensayos con precondición y resultado |
| Cara agente | A01–A07 | 6/7 → 7/7 tras #27 (A01 en `AGENTS.md`: #28) | PR-2 esquema más `frontmatter-no-yaml` (A01), registro de prefijos (A02), seis H2 (A03), mermaid (A04), bloques `entradas`/`salidas`/`validaciones` (A05), anclas `ruta#Símbolo@SHA` (A06), `AGENTS.md` + glosario (A07) |
| Indexado | I04, I06 | 2/2 | E1-U5: 55/55 piezas en la ia-db v4.1, sin duplicados |
| **Total** | | **44/45 al verificar; 45/45 en el cuerpo tras #27** | |

Observaciones (no bloquean): `Examples/Como-Intervenir-Lab-Documentos.md` es una página de una sola sección y no tiene
índice (VER-M02 frente a VER-M04, que prohíbe secciones decorativas); TEM-01 a 03 cierran con «Fuentes y observaciones»
y TEM-04 a 07 no (VER-A03 se cumple en los seis H2 comunes; queda para la pasada a `vigente`); `Lanzar-Example.md` es un
tool-prompt anterior a E1 sin índice.

## 9. Demo viva para el PO

| Campo | Valor |
| --- | --- |
| Contenedor | `docascode-demo`, `--restart unless-stopped`, puerto 8090 del anfitrión de desarrollo (la URL va en el retorno del despacho, no en este folio) |
| Imagen | `docascode-demo:e1g`: MkDocs Material sobre el contenido de Lab-Documentos (cuerpo SDEI, mini demo, `AGENTS.md`, README de docs-guard) y un servidor HTTP de Python |
| Páginas | Inicio con entrada por audiencia; una página por audiencia (estudiante, equipo, analista y PO, desarrollo, persona usuaria, agente); `AGENTS.md` también en texto plano (`raw/AGENTS.txt`); estado de la compuerta |
| Alcance | Es una vista de lectura para la demo. En E1 no hay sitio publicado ni `llms.txt` (E1-U5); el sitio entra en un escalón posterior |
| Capturas | Diez vistas en la carpeta de capturas de la sesión (no se versionan) |

## 10. Corte

| Criterio | Veredicto |
| --- | --- |
| G-a, G-b, G-c, G-d, G-f | PASA |
| G-e | NO PASA el umbral literal; sin P0 |
| G-g | PASA en el cuerpo tras #27; `AGENTS.md` con reserva hasta #28 (clase H) |
| P0 abiertos | Ninguno |

`133` §5 no prevé el caso «un criterio no cumple y no hay P0»: `PROCEDE` exige todos, `NO_PROCEDE` exige un P0 e
`INSUFICIENTE` exige una medida faltante, y la medida está. La presidencia decide (LD-E1G-03): **PROCEDE CON RESERVA
DE G-e Y DE `AGENTS.md`**. E1 queda cerrado y E2 arranca; la reserva de G-e viaja a E2 como PE-1 con una propuesta
de umbral medible, y la de `AGENTS.md` se levanta cuando una persona fusione #28 (PE-13). Es aditivo y reversible: si
la mesa de E2 no acepta el umbral nuevo, la P-LECT de E2 vuelve a medir contra el literal.

## 11. Lecciones de decisión

| ID | Decisión | Nivel | Por qué |
| --- | --- | --- | --- |
| LD-E1G-01 | G-b por equivalencia de árbol en los merges ya hechos, y `push` a `main` en `docs-guard` hacia adelante | N1 (aditivo, reversible) | Reejecutar la CI sobre catorce merges históricos no agrega información si el árbol es el mismo; el trigger nuevo hace que la próxima compuerta lo mida literal |
| LD-E1G-02 | Reparar en un solo PR los hallazgos de U5 que tocan el recorrido y la seguridad de CI | N1 | Son de una línea, del mismo repositorio y los pide la compuerta; dejarlos para E2 rompía el recorrido punta a punta que esta compuerta verifica |
| LD-E1G-03 | Corte `PROCEDE CON RESERVA DE G-e` | N1 | Hueco del procedimiento de 133 §5; ni irreversible ni con consecuencia externa: no sale al PO (L3/L4) |
| LD-E1G-04 | Una sola ronda de reparación de la P-LECT | N1 | Catorce rondas previas (U3, U4a–U4c) muestran que el número de huecos no converge a cero; una ronda más corrige faltas reales y documenta la no convergencia |
| LD-E1G-05 | Sitio de demo armado fuera del repositorio | N1 | El plan no genera sitio en E1; versionar un `mkdocs.yml` sería adelantar una decisión de E3. La demo lo arma en la imagen y no deja rastro en los repos |
| LD-E1G-06 | La línea `Co-Authored-By` sigue el recordatorio del entorno, no la carta | N1 | Mismo criterio que LD-08 de U5 |
| LD-E1G-07 | Las capturas y la URL de la demo no van a ningún repositorio | N1 | Carta: la IP de la red local no se versiona en repos públicos |
| LD-E1G-08 | La regla `frontmatter-no-yaml` se implementa sin dependencias (detecta «: » en un escalar sin comillas) en lugar de sumar PyYAML a `dg.py` | N1 | `dg.py` corre con `python3 -I` y sin paquetes; la regla cubre el único defecto medido (35/35). Un validador YAML completo es mejora de E2 si aparece otra forma |
| LD-E1G-09 | `AGENTS.md` va en un PR aparte, abierto para una persona | N2 (clase H) | Renovar la huella AK-3 lo reserva D08 a una persona; la autonomía no alcanza a una excepción de un control de seguridad. El resto del arreglo no espera |
| LD-E1G-10 | Los 30 frontmatter heredados inválidos de `Guides/Despliegue/` no se tocan | N1 | Están fuera de la ruta de la compuerta y de E1; la regla los marca como aviso si alguien los pone en la ruta (PE-14) |

## 12. Pendientes y punto de continuación

| # | Pendiente | Para |
| --- | --- | --- |
| PE-1 | Umbral de G-e medible. Propuesta: «0 preguntas de gravedad alta sin respuesta en el cuerpo, 0 contradicciones entre documentos, y no alcanzadas resueltas por navegación desde el README»; los huecos medios y bajos quedan como insumo del PR | Mesa de E2 (providencia de criterios E2) |
| PE-2 | `dg.py` rechaza `traces: []` aunque el anexo del esquema lo admite (H-1 de U4b) | E2 |
| PE-3 | Ningún control comprueba que una plantilla de proceso tenga los bloques `entradas`/`salidas`/`validaciones` (U4d) | E2 |
| PE-4 | En un repo con SDD propio, `dg.py` necesita excluir carpetas (`_legacy/`) y resolver prefijos externos contra el mismo repo (U4d) | E2, piloto Geometría |
| PE-5 | El informe del issue del carril semanal se corta en 60 000 bytes y puede dejar un `<details>` abierto (LD-05 de U2) | E2 |
| PE-6 | Los 33 avisos de `url-fecha` de la guía obsoleta salen en cada PR hasta archivarla (H-1 de U4f) | Versión siguiente del cuerpo |
| PE-7 | Framework Concept tiene 202 enlaces absolutos del workspace (hallazgo de U5) | Fuera de E1; unidad propia |
| PE-8 | Lab-E2E.WebBlazor: `ci.yml` en `ubuntu-latest` con actions por etiqueta (LD-23 de U6) | Expediente propio de Lab-E2E |
| PE-9 | L11 (aprobación de forks, permisos read, runner group acotado) sigue como acto del PO | PO |
| PE-10 | Retirar `h.cfg` de la carpeta de intermedios (encabezado con credencial en texto plano) y rotar el token | Presidencia; acto con consecuencia externa |
| PE-11 | Resincronizar el expediente (folios 230 en adelante, este incluido) con `redact.py` | Presidencia |
| PE-12 | La copia local de `ia-db/` y de `OUTPUTs/` del PO choca con `main` de Lab-Documentos.Documentacion (U0c, U5) | PO, antes de su próximo pull |
| PE-13 | Aprobar y fusionar #28 (`AGENTS.md` con YAML válido y huella AK-3 renovada). Sugerencia: aprobar; default si no: `AGENTS.md` sigue legible como Markdown y sólo falla a quien parsea su frontmatter | PO (clase H) |
| PE-14 | 30 frontmatter inválidos heredados en `Guides/Despliegue/Documentacion-Informe-Despliegue/` (mismo defecto) | Unidad propia o E2 |

```text
Sigue: E2 — piloto en Lab-Geometria con ADR consecuente (L3/L4: la documentación es aditiva; si un ADR propio
traba, un ADR consecuente lo ratifica y se sigue). Primero: providencia de criterios E2 con PE-1; después las
unidades de N10 §14 para E2. Sin actos previos del PO salvo L11 y PE-10.
```

## 13. Huella

| Qué | Dónde | Estado |
| --- | --- | --- |
| Worktrees de lectura `e1g-ld`, `e1g-ldd` | `<carpeta de trabajo>/docascode/wt/` | Borrados al cerrar |
| Worktree y rama `exp0002/e1g-reparaciones` | Ídem; rama remota en Lab-Documentos | Rama borrada tras el merge (404); worktree retirado |
| Rama `exp0002/e1g-frontmatter-yaml` (#27) | Ídem | Rama borrada tras el merge (404); worktree retirado |
| Rama `exp0002/e1g-agents-yaml` (#28) | Remota en Lab-Documentos | **Queda** mientras #28 espera a una persona; worktree y rama local borrados |
| Clones superficiales de Lab-E2E.WebBlazor y Lab-Geometria | `<carpeta de trabajo>/docascode/e1g/clones/` | Borrados |
| Fuentes del sitio de demo, P-LECT, caché de docs-guard | `<carpeta de trabajo>/docascode/e1g/` | Borrados salvo la caché de herramientas (lychee y mermaid), que reusa E2 |
| Imagen `docascode-demo:e1g` y contenedor `docascode-demo` | Docker del anfitrión de desarrollo | **Quedan corriendo** a pedido del despacho (demo viva) |
| Sesiones `claude -p` de la P-LECT | — | Terminadas |
| Capturas | Carpeta de la sesión y salida de la herramienta de medios | Fuera de los repos |
| Este folio y `evidencia/E1-G/` | Expediente | Creados |

## 14. Anexo A — Propuesta al dueño del Profile (L6)

Propuesta escrita al dueño de `Profiles/Study-Guide-Documentation.md` según `131` (L6, opción b). El Profile no se
tocó; aplicarla es un PR de norma posterior por la delegación. Evidencia: el cuerpo SDEI de E1.

| # | Propuesta | Evidencia de E1 |
| --- | --- | --- |
| A-1 | **Objetivos de aprendizaje.** Sumar a «Objetivos específicos» que el README declare objetivos `OBJ-nn` verificables y la ruta que lleva a cada uno | README del cuerpo §2: `OBJ-SDEI-01…05`, cada uno con su ejercicio |
| A-2 | **Ejercicios de transferencia.** Sumar un anexo de ejercicios `EJR-nn` con claves, enlazado desde cada objetivo | `99-Anexos/Ejercicios.md` |
| A-3 | **Ruta real del framework.** Corregir la referencia al Rule Set: `/IA/IA.Prompts/…` no existe; la ruta es `/IA/PROMPTs/IA.Prompts/…` | `R07` §4; pendiente P1 de la bitácora maestra |
| A-4 | **Contrato de frontmatter.** Remitir a un esquema único (diez campos más `description`, `corpus_id` y `version` sólo en el README) en lugar de repetirlo por regla | `99-Anexos/Esquema-Frontmatter-Y-Prefijos.md`; control PR-2 |
| A-5 | **Verificación por lector sin contexto.** Agregar a «Criterios de calidad» la prueba de lectura con umbral medible (PE-1), además de la revisión contra el mapa | §7 de este folio; P-LECT de U3 y U4a–U4c |
| A-6 | **Tres rutas.** Admitir en el README más de una ruta de lectura (aprender, intervenir, agente) | README del cuerpo §3 |
