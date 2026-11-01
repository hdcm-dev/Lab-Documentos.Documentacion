---
doc_id: EXP0003-F010
doc_type: informe
title: Informe de la comisión de Requisitos — univocidad, atomicidad y verificabilidad del cuerpo SDEI, del libro y del conocimiento, y lo que falta
status: vigente
origin: agent
confidence: alta en lo medido (lecturas con línea y seis ensayos con salida del 2026-11-01); media en las posiciones, que son propuesta de esta comisión y votan el jurado y el análisis de decisiones
owner: comisión C-REQ (núcleo permanente) de la mesa de la reedición DocsAsCode (expediente 0003)
last_review: 2026-11-01
audience: [presidencia, refutador, análisis de decisiones, jurado de veredicto, PO]
traces: [TP:18, TP:20, TP:42, TP:48, TP:50, TP:70, TP:104, PP:296-347, EXP0003-F001, EXP0003-F004, N1, N2, N3, N4, N5, N6]
---

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-01 |
| Autor | Comisión C-REQ, silla «Requisitos (núcleo permanente)», titular: analista de sistemas. A ciegas |
| Corrige | — |

| Cabecera de comisión | Valor |
| --- | --- |
| Rol | Requisitos: ¿cada afirmación del cuerpo SDEI, del libro y del conocimiento es unívoca, atómica y verificable? ¿Qué falta? (folio 004 §6) |
| Preguntas a cargo | P-01, P-13, P-14, P-15, P-16, P-17, P-18, P-21, P-23, P-24, P-28 (`PP` §7) |
| No-competencia | Forma editorial y estilo del libro; pesos y criterios de decisión; arquitectura de la demo |
| Norma | `IA.Knowledge.Base/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` 3.1 (`MEP`) |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Líneas 1–111 (cabecera y §0, con el Mapa de carga); fila «Sos una comisión»: §2.2, §3.2, §3.3, §4 y §5.2 |
| Otros documentos cargados | `Cadena-De-Consecuencias` 2.0 §2; `Mesa-Consulta-A-Un-Tercero` 2.0, cabecera y §0 (no rige para esta silla: no hay tercero, folio 004 §9); `Rule-Escalas-De-Juicio` 1.2 §3.3 y §3.4 (`EJ`); `Rule-Forma-De-Conocimiento` 1.3 §3.12 (`RFC`); Profile `Study-Guide-Documentation` (`PSG`) y `Rule-Documentation` (`RD`) de IA.Prompts |
| Insumos leídos | Pedido `TP` entero (sha256 `da388e9d…4b37`, coincide con el folio 001 §3); folios 001 y 004; `PP`; `N1` entero; `N2` §2.3, §3 y §6; `N3` §3 a §6; `N4` §6, §7 y §9; `N5` §4 y §5; la bitácora privada de N5 (leída, **no se transcribe**); `N6` por búsqueda. **No se leyó ningún informe de otra comisión** (`mesa/01x-*`) |
| Cuerpo leído directamente | `SDEI/` en el worktree de LD, rama `dac/0003-base`, cabeza `0bed863`; expediente 0002 en el worktree de LDD (`8b96bc6`) |
| Medios propios | `git grep`, `grep`, `sed`; `dg.py` del worktree sobre copias en `{dir-de-trabajo}`; la compuerta de IA.Knowledge.Base (`tools/compuerta/verificar.py`) sobre una raíz parcial; tres consultas web (§8) |

## Índice

1. [Definiciones y forma de este informe](#1-definiciones-y-forma-de-este-informe)
2. [Lectura del pedido: qué falta](#2-lectura-del-pedido-qué-falta)
3. [Hallazgos](#3-hallazgos)
4. [Dictamen por pregunta](#4-dictamen-por-pregunta)
5. [Criterios de aceptación propuestos](#5-criterios-de-aceptación-propuestos)
6. [Ensayos corridos](#6-ensayos-corridos)
7. [Lo que revisé y está bien](#7-lo-que-revisé-y-está-bien)
8. [Fuentes externas](#8-fuentes-externas)
9. [Señales para otras sillas y solicitudes de convocatoria](#9-señales-para-otras-sillas-y-solicitudes-de-convocatoria)
10. [Excepciones a conocimientos](#10-excepciones-a-conocimientos)
11. [Lo no verificado e incidencias](#11-lo-no-verificado-e-incidencias)
12. [Inventario de lo creado y lo borrado](#12-inventario-de-lo-creado-y-lo-borrado)
13. [Barrido de lo privado de este folio](#13-barrido-de-lo-privado-de-este-folio)

---

## 1. Definiciones y forma de este informe

### 1.1 Definiciones

| Término | Definición en este informe | Fuente |
| --- | --- | --- |
| **Afirmación** | Una oración del cuerpo, del libro o del conocimiento que dice cómo es algo (descripción) u obliga, prohíbe o permite algo a un sujeto (regla) | Criterio propio |
| **Unívoca** | Admite una sola lectura: cada término tiene un solo sentido en todo el corpus | `RM:198`; INCOSE *Guide to Writing Requirements*, característica «unambiguous» (§8, fuente 1) |
| **Atómica** | Dice o exige una sola cosa | `RM:198`; INCOSE, «singular» |
| **Verificable** | Hay un instrumento (comando, control, lectura con criterio cerrado) que decide si se cumple, sin juicio de quien la escribió | `RM:198-199`; INCOSE, «verifiable» |
| **Criterio de aceptación** | **Dado** / **Cuando** / **Entonces** más el **instrumento** que lo observa | Palabras clave en español de Gherkin (§8, fuente 2); el instrumento, criterio propio, como en el folio 010 del 0002 |
| **Fuente única** | Un dato vive en un solo documento; el resto lo referencia | `RD:28` (aplicado por `PSG:17` vía `RuleSet-Study-Guide.md:13`) |
| **Ejemplo conductor** | El caso 60/80 de la mini demo MovilidadUrbana (`Patrones-De-Ejemplos.md:32`, `PE-01`) | `SDEI/` |

**Alias.** Los del folio 001 §1. Además: `SDEI/` es la carpeta del cuerpo; `LD` y `LDD`, los worktrees de
Lab-Documentos y de Lab-Documentos.Documentacion; `EXP2/` es la carpeta del expediente 0002 en LDD; `KB` es
IA.Knowledge.Base; `{servicio-privado}` y `{host-de-pruebas}` como en el folio 001.

### 1.2 Lectura P0–P3 aplicada

La del folio 001 §9, sin cambios. En este informe, **P1** es una afirmación que dos lectores (persona y agente)
aplican distinto o que no tiene instrumento; **P0** es, además, un dato falso sobre el ejemplo conductor.

### 1.3 Observaciones de forma

- El libro (`SDEI/DocsAsCode-Developer-Guide.md`) y el conocimiento (`SDEI/Conocimientos/knowledge-DocsAsCode-Designing-Specification.md`)
  **existen sólo como archivos vacíos sin seguimiento** en el clon principal de LD (`wc -l` = 0; `git status`:
  `??`; creados el 2026-11-01 a las 14:34), y no existen en el worktree. Esta comisión juzga por eso los
  **requisitos** de las dos piezas (lo que el cuerpo y las bitácoras les exigen), no un texto.
- El pedido nombra al servicio privado en varias líneas (`TP:14`, `TP:18`, `TP:20`, `TP:22`); aquí va por alias.

## 2. Lectura del pedido: qué falta

| Frase | Qué tiene hoy la hipótesis | Qué falta para que sea verificable | Hallazgo |
| --- | --- | --- | --- |
| «aplicarlos en **nuevos o ya existentes** proyectos» (`TP:18`) | Cuatro casos de reproducción: LD, Geometría, `{servicio-privado}` y la app de la mini demo (`N3` §5.6, tabla «Casos»). Los cuatro son proyectos **existentes** | Un caso de proyecto **nuevo** (repositorio sin documentación, sólo un enunciado), o la declaración de que esa mitad no se prueba | H12 |
| «a fin de **probar la efectividad**» (`TP:20`) | Prueba de reproducción con métricas (`N3` §5.6) y ensayo en Geometría (`N4` §7.3), con umbrales distintos | Una métrica única (P-25, no es de esta silla) | — |
| «**material suficiente** para que un grupo […] trabaje en una aplicación» (`TP:70`) | Clasificado como incógnita (`PP:51`, E-15). Ninguna bitácora le da instrumento: la reproducción mide si el diseño se repite, «no mide si el diseño es bueno» (`N3` §5.6, último párrafo) | Un criterio Dado/Cuando/Entonces con instrumento (§5, CA-12) | H12 |
| «que los editores **editen** un documento unificado» (`TP:42`) y «que este documento **reúna** los documentos individuales» (`TP:48`) | Lectura A de L-1: el libro reúne y la fuente manda (`PP:84`) | Una regla que haga verificable que libro y fuente dicen lo mismo, o una sola fuente | P-01 |
| «Aplicar» el Profile `Study-Guide-Documentation` (`TP:104-105`) | El libro lo aplica (`N2` §2) | Reconciliar «un dato vive en un solo documento» (`RD:28`) con un libro que copia las fuentes | P-01 |

## 3. Hallazgos

Tope: 12 (folio 004 §6). Ancla según `EJ` §3.3. Las afirmaciones de colisión de un término van con E1
(`EJ` §3.4, regla 2).

| Id | Nivel | Ancla con cita | Hallazgo | Impacto si no se corrige | Dirección de la corrección |
| --- | --- | --- | --- | --- | --- |
| H01 | **P0** | E2: `00-Marco.md:183-184` («contra la rama principal del código un aviso programado detecta que el método que valida el largo […] cambió»); igual `Ejercicios.md:112-116` y `01-Mapa.md:68-70`. Contraste: `tools/docs-guard/semanal.sh:89-106` sólo cuenta commits (`git rev-list --count "$sha..HEAD"`); A1 (deriva por símbolo) corre sólo en `mini-demo-movilidad.yml:17-23` (`pull_request` con rutas y `workflow_dispatch`, sin `schedule`) | Dato falso sobre el ejemplo conductor: ningún carril programado detecta que el método cambió; sólo avisa que el SHA quedó N commits atrás | Un lector cree que la deriva de la regla 60/80 se descubre sola; un agente que diseña otro proyecto copia un control que no existe | Es **descripción**, no control (filtro de `MEP` §3.3): `TEM-06:101` nunca le atribuyó al carril la deriva por símbolo. Se corrige el texto contra el producto (P-18) |
| H02 | P1 | E1: `git grep -n -w deriva` y lectura: Glosario `:57` (lo que una pieza afirma frente al código); `MovilidadUrbana-Mini-Demo/README.md:45` (SHA fijado frente a `main`); `TEM-06:102` y `semanal.sh:14` («deriva» = copia fijada que cambió su SHA-256); `TEM-05:43` agrega «derivar» una página. El cuerpo ya tiene «atraso» para el segundo sentido (`TEM-06:101`, `Glosario.md:48`, `semanal.sh` control 3) y además usa «desfase» en 12 líneas de 8 archivos | «Deriva» tiene **tres** sentidos (contenido, atraso del ancla, huella de una copia) y el segundo tiene tres nombres | El aviso de «deriva» de un carril se lee como deriva de contenido; es la puerta de H01 | Un término por sentido (P-13) |
| H03 | P1 | E2: `TEM-01:283-284` «divergencia entre la **letra (el código)** y la intención»; `00-Marco.md:145` «entre lo que la especificación dice y lo que se quiso decir»; `01-Mapa.md:103` y `MovilidadUrbana-Mini-Demo/README.md:376` «entre letra e intención»; la ficha que ejecuta el caso: «La letra y la intención dicen 60; **el comportamiento** admite 80» (`RN-LOC-01.md:39`) con letra = «lo que la app promete» (`README.md:168`) | «Divergencia» se define de cuatro maneras y «letra» de dos (código / texto prometido). Además «letra» es un grado de certeza (`README.md:187`) | El acto de clase H que decide la analista (qué se compara con qué) depende del documento que se lea | Fijar letra, intención, comportamiento y divergencia con la definición de la ficha, que es la que tiene control (C4 de `verificar.sh`) (P-13) |
| H04 | P1 | E1: «compuerta» = un control (`00-Marco.md:44`, `Glosario.md:52`); = conjunto de controles (`TEM-03:47-48`); = hito de un escalón («una etiqueta por compuerta», `00-Marco.md:78`). «PR-7 referencias» (`TEM-03:50`, `Como-Intervenir.md:107`) frente a «PR-7 fijadas» del workflow (`docs-guard.yml:14`) y «fijadas y reflint» (`TEM-06:71`); «siete grupos» (`TEM-03:49`) frente a ocho pasos con `autoprueba` (`docs-guard.yml:15`) | Un término con tres sentidos y un grupo con dos nombres | Un criterio «la compuerta da verde» no dice qué se midió | P-13 |
| H05 | P1 | E1: `prefijos.txt:24` registra `PE` = «pregunta de evaluación»; `git grep -n -i 'pregunta de evaluaci'` en LD = **1** (esa línea). El cuerpo usa `PE-01` a `PE-12` como **patrón de ejemplo** (`Patrones-De-Ejemplos.md:32-43`) y el anexo lo registra así (`Esquema…:117`). El anexo dice que, si difieren, **manda el archivo** (`Esquema…:199-200`) | El sentido registrado, que es el que manda, es el único que nadie usa | La regla de precedencia vuelve «correcto» un sentido sin uso | P-14 |
| H06 | P1 | E2: `TEM-05:48` «Toda página de usuario traza a un `RD-`» frente a la tabla `TEM-05:84-89`: `ESC-SDEI-3` traza a «la fila `RD-` y el caso de uso de la unidad», `ESC-SDEI-4` a «la versión del paquete», `ESC-SDEI-1` a «—». E1: las páginas del ejemplo de `ESC-SDEI-3` trazan sólo a `CU-00026@1.1` (`Web/Ayuda/es/alumno/enviar-un-trabajo.md:6`) o no trazan (`Consola/Ayuda/**`); `N1` §2 midió sus 9 trazas como «no verificable» | La regla general no es atómica ni cierta en dos de cuatro escenarios, y el único ejemplo de `ESC-SDEI-3` no cumple ninguna de las dos mitades de su fila | El escenario con roles queda sin ningún ejemplo cuyas trazas resuelvan | P-15 |
| H07 | P1 | E1: `00-Marco.md:105`, fila «Clases activas», `ESC-SDEI-1` = CL-02, 03, 09, 10, 11, 12. En LD mismo (el ejemplo de ese escenario) existen `CHANGELOG.md` con la delegación (CL-13, `CHANGELOG.md:285`) y la ia-db de LDD que indexa LD (CL-08, `ia-db/indexes/11_Sistema-Documentador-SDEI.md:9`), mientras `TEM-04:86` dice «No hay índice interno». `ESC-SDEI-3`, «Fuente generada: OpenAPI y comentarios XML» (`00-Marco.md:107`); Geometría tiene `GenerateDocumentationFile` en `false` (`Lab-Geometria/Directory.Build.props:26`, `5f07b12`). El caso privado de `ESC-SDEI-4` tiene, según la bitácora privada de N5, piezas de CL-06 y CL-09 que la fila omite (no se transcribe) | La fila no se deriva de una regla: no dice si es el mínimo, el máximo o lo observado | El conocimiento la va a usar como default de su decisión D-02 (`N3` §5.3) y hereda los errores | P-16 |
| H08 | P1 | E2: `00-Marco.md:145`: la analista «acepta, rechaza o difiere **cada** requerimiento documental»; `00-Marco.md` fila `ACT-SDEI-5`: el docente «no decide el contenido normativo»; `TEM-02:166`: en `ESC-SDEI-1` decide «docente o responsable de la guía», en `ESC-SDEI-4` «PO»; clave de `EJR-SDEI-05` (`Ejercicios.md:126`): «la analista o el PO»; el caso real: «la mesa del expediente, por delegación del PO» (`TEM-02:202`) | Cuatro respuestas a «quién decide 1b», y la del Marco dice «cada» | `CQ-14` («un agente acepta su propio requerimiento», `TEM-02:269`) no se puede comprobar si no se sabe quién debía aceptar | P-17 |
| H09 | P1 | E1: `TEM-07:170-172`: «Ninguna de las dos [capas] existe todavía». IA.SDD en `bac7e48` (el commit que cita `TEM-07:164`) contiene `Conocimiento/Knowledge-Logica-De-Decision.md` (1.0, 2026-10-27, `git log` `38bf059`, ancestro de `bac7e48`) y una línea en `SDD/Devs/Orchestrator/Master-Prompt.md:1025` y en `SDD/Devs/Rules/Mesa-Rules.md:570` que manda correr ese conocimiento «antes de detener». La copia **no** es fiel: `sha256sum` difiere de `KB/Knowledges/Knowledge-Logica-De-Decision.md`. Su lección (`KB/…/Knowledge-Logica-De-Decision.md:259-267`) no tiene «nivel» ni «resultado», que la capa A pide (`TEM-07:176`). En Lab-Geometria no hay copia (`find PROG2 -iname '*Logica-De-Decision*'`: vacío) | La afirmación es falsa en IA.SDD y cierta en Lab-Geometria, y como está escrita («ninguna») no se puede verificar: la capa A se define por descripción, no por un alias | El libro y el conocimiento heredan un «no existe» con fecha vieja | P-21 |
| H10 | P1 | E1: `EXP2/actuaciones/290-compuerta-e1.md` (2026-10-28, `status: vigente`, §10): «E1 queda cerrado y E2 arranca». folio 259 del 0002, corrigenda del rescate (2026-10-29, §5): «Rige el `245`: **INSUFICIENTE** […] El `290` no rige». La regla del 0002: «Cada escalón tiene compuerta de dictamen» (`EXP2/actuaciones/001-providencia-apertura.md:131`, D1) | El estado del escalón 1 tiene dos respuestas foliadas; la que rige por fecha dice que no cerró | Nadie puede decidir si el escalón 2 empezó, que es la premisa de P-28 | Una corrigenda que pase el 290 a sustituido y asiente el estado de E1 (coincide con `N1-36`); P-28 |
| H11 | P1 | E1 (ensayo E2 de §6): una página que traza `@1.0` a una pieza con `version: 1.0` en el frontmatter resuelve, y con `version: 1.1` da `traza-version-desfasada` (rojo/verde visto); con el ID en el H1 da `id-duplicado`. E2: `00-Marco.md:161` y `Esquema…:66`: «`corpus_id` y `version` **sólo** en el README» | El conocimiento necesita `version` en el frontmatter para que su subida ponga en rojo a quien lo traza (`N3` §5.7), y la convención del cuerpo lo prohíbe con «sólo» | O el conocimiento viola la convención, o pierde la única forma medida de versionar sus trazas | P-23 |
| H12 | P1 | E2: `TP:18` («nuevos o ya existentes proyectos») frente a la tabla de casos de `N3` §5.6 (C0–C3, todos existentes); `TP:70` («material suficiente») sin instrumento en `N3` §5.6 ni en `N4` §7.3 | Falta probar la mitad «proyectos nuevos» del objetivo, y la incógnita de `TP:70` no tiene criterio | La mesa puede cerrar con el objetivo literal sin medir | Sumar un caso C4 «proyecto nuevo» a la reproducción y fijar CA-12 (§5) |

## 4. Dictamen por pregunta

Cada respuesta sale de `Cadena-De-Consecuencias` §2. Los pesos entre opciones no son de esta silla: aquí va la
posición desde univocidad, atomicidad y verificabilidad, y la evidencia que la sostendría.

### P-01 — Relación entre el libro y los documentos fuente

**Posición: una alternativa nueva, D — «edición ensamblada».** El libro se arma desde las fuentes con un guion,
y lo que es propio del libro (prólogo, fundamentos, introducciones de parte, «En la industria», referencias y casos
que pide `TP:56`) se escribe como fuentes del libro, no a mano en el archivo final. Las seis intervenciones
editoriales se aplican sobre las fuentes, y el libro se regenera en el mismo pull request. Un control compara el
libro versionado con el que produce el guion: diferencia vacía o rojo.

| Paso | A (edición de lectura, corrección doble) | B (libro canónico) | C (libro generado, sin piezas propias) | **D (ensamblada)** |
| --- | --- | --- | --- | --- |
| 1. ¿Dónde cae? | En cada mantenimiento futuro: cada dato se corrige dos veces | En la migración: re-apuntar enlaces y trazas, pasar fuentes a `obsoleto` | En el pedido: no hay lugar para los fundamentos ni las transiciones | En el guion (una herramienta nueva) y en una carpeta de fuentes del libro |
| 2. ¿Cuánto pesa? | 17 fuentes, 3628 líneas (`wc -l`) en dos copias; y la corrección doble **no tiene instrumento**: después de una ronda de estilo, libro y fuente dicen lo mismo con otras palabras y ningún comando lo decide | 17 enlaces de LD fuera del cuerpo, 2 desde `Examples/`, 108 citas en LDD (`git grep`, §6 E5); 24 trazas a IDs del cuerpo, 22 de ellas dentro del propio cuerpo | Cero tareas de redacción posibles en el libro | 256 enlaces relativos entre fuentes a convertir en anclas internas y 17 encabezados que declaran IDs a quitar (§6 E5) |
| 3. ¿Qué pierde la alternativa? | Pierde la fuente única que manda el Profile: «Un dato vive en un solo documento» (`RD:28`) | Pierde «Documentos por tema» (`PSG:47`); el pedido lo supera para el libro (`TP:48`), pero no para la ruta «agente» de documentos chicos | Pierde `TP:52` (sección de fundamentos) y `TP:56` | Nada de los tres requisitos: fuente única (`RD:28`), documentos por tema (`PSG:47`) y un documento que reúne (`TP:48`) |
| 4. ¿Es reversible? | Sí, pero la deriva acumulada no | Caro: volver a partir el libro | Sí | Sí: borrar el guion deja A |

**Fundamento.** Es la única alternativa que cumple a la vez `TP:48`, `RD:28` y `PSG:47`, y la única en la que «el
libro dice lo mismo que las fuentes» es **verificable por comando**. Es la práctica corriente de los sistemas que
arman libros desde archivos: mdBook arma el libro con un `SUMMARY.md` que dice «what chapters to include, in what
order […] and where the source files are» (§8, fuente 3); DITA reutiliza contenido por referencia, no por copia
(§8, fuente 4). Encaja con el catálogo del cuerpo: el libro pasa a ser una pieza de clase D, que «no se edita a
mano: se regenera» (`N3` I-12, `Como-Intervenir.md:96`).

**Lectura de `TP:42` que toma.** «que los editores editen un documento unificado»: lo editan **a través de sus
fuentes** y ven el resultado unificado en el mismo PR. Otra lectura (edición sobre el archivo final) es posible; es
la que obliga a A o B. Se declara: es la frase de dos lecturas de esta posición.

**Riesgos.** (a) El guion es una herramienta nueva: si va en `tools/docs-guard/` es archivo común (P-04, AG-4); si
vive en la carpeta del cuerpo, no. (b) La corrección de pruebas (`TP:65`) mira la «versión diagramada»: sus
correcciones vuelven a la fuente, no al libro. (c) El refutador puede sostener que A es la solución más chica hoy;
es cierto en el paso 2 de hoy y falso en el de cada corrección futura.

**Si la mesa descarta D por costo**, la que sigue desde esta silla es **A con dos condiciones** que la vuelven
verificable: el libro **no reformula** reglas, umbrales ni definiciones (las cita por ID y remite), y un control
de co-cambio exige que todo PR que toque una sección del libro con fila en el anexo de correspondencia toque
también su fuente. Sin esas dos condiciones, A deja la corrección doble sin instrumento.

**Evidencia que la sostendría.** Un peritaje: un guion mínimo que arme el libro de hoy desde las 17 fuentes y la
corrida de `scripts/ci-local.sh todo` y `tools/medios/mermaid.sh` sobre el resultado, con el conteo de enlaces
reescritos y de IDs quitados.

### P-13 — Términos con dos o más sentidos

**Posición: un término por sentido, con la definición que tiene control; el glosario es la fuente única y el
cuerpo, el libro y el conocimiento la citan.**

| Término | Sentido que queda | Los otros sentidos pasan a | Por qué ese |
| --- | --- | --- | --- |
| Letra | Lo que la app promete, textual (texto bajo el campo y mensajes) | — («el código» de `TEM-01:284` se corrige) | Es el de la ficha y del tutorial, y el que mide C4 (`RN-LOC-01.md:37-39`, `README.md:168`) |
| Intención · Comportamiento | Para qué existe la regla · lo que el código hace | — | Ídem |
| Divergencia | Diferencia entre letra o intención y comportamiento; leve o de fondo (`README.md:184`) | `00-Marco.md:145`, `01-Mapa.md:103`, `README.md:376` y `TEM-01:284` se alinean | Es la que tiene instrumento (C4) |
| Deriva | Distancia entre lo que una pieza afirma y lo que el código hace (`Glosario.md:57`) | SHA frente a `main` → **atraso** (ya en `TEM-06:101`, `semanal.sh` control 3); copia fijada que cambió → **huella cambiada** de la copia; «desfase» deja de usarse | «Atraso» ya existe en el cuerpo y en la herramienta |
| Compuerta | El conjunto de controles del carril PR (`docs-guard`) | Un control → **control**; el hito de un escalón → **compuerta de escalón**, definida aparte | Es el uso de `TEM-03:47-48`, `TEM-06` y del workflow |
| PR-7 | «PR-7 fijadas y referencias (`reflint`, `url-fecha`)»; «siete grupos más `autoprueba`» | — | Manda el workflow (`docs-guard.yml:14-15`) |

**Fundamento.** El Profile pide «la misma terminología […] en toda la guía» (`PSG:71`); la característica
«unambiguous» de la ingeniería de requisitos (§8, fuente 1). **Instrumento**: un `git grep -n -w` por término con
su salida en el PR de la reedición; no exige cambiar `dg.py`. **Riesgo**: renombrar «compuerta» en los folios del
expediente 0002 sería reescribir un registro; no se tocan. **Frontera** (condición K3 del folio 004): esta silla
fija la regla de univocidad; los cuantificadores son de `C-FORMAL` y la elección entre opciones, de `R-DECISIONES`.

### P-14 — Qué significa `PE`

**Posición: `PE` = patrón de ejemplo; se corrige `prefijos.txt:24` en el PR común, y los pendientes del
expediente usan otro prefijo (`PEND-`) desde el 0003.** El sentido «pregunta de evaluación» tiene 1 aparición en LD
(la línea del registro); el de patrón tiene 12 IDs y un anexo (H05). **Riesgo**: `prefijos.txt` es archivo común
con FRAMEWORK MAUI (P-04). Los `PE-1…PE-14` del folio 290 no se renombran: son registro. **Evidencia que la
sostiene**: la salida de `git grep` de §6 E6, ya corrida.

### P-15 — A qué traza una página de ayuda y cómo se corrige el ejemplo

**Posición: las dos correcciones, no una.** (1) `TEM-05:48` se reescribe para que remita a la tabla: «Una página de
ayuda traza a lo que pide la fila de su escenario» (deja de ser una regla general falsa en dos escenarios). (2) El
ejemplo `Prueba-Ayuda-Por-Rol` se retraza a los casos de uso de la unidad de la pantalla con su versión y suma su
fila `RD-` y un `source.lock`, para que sus trazas resuelvan. **Alternativa descartada desde esta silla**: declarar
el ejemplo «anterior a la regla»: deja `ESC-SDEI-3` con 0 ejemplos verificables (H06). **Riesgo**: retrazar exige
resolver contra el SDD de Geometría en un SHA fijo (`N4` H1 da los casos de uso de destino); es trabajo del ensayo
de N4. **Criterio**: CA-06 (§5). Frontera K4: el lado del usuario lo juzga `C-DOC-USR`.

### P-16 — Qué clases activa cada escenario

**Posición: la fila pasa a llamarse «Clases activas por defecto», con una regla de derivación, y se corrige con lo
medido.** Regla: una clase está en la fila si el ejemplo del escenario tiene al menos una pieza de ella; un proyecto
suma o quita clases en su ficha de diseño con motivo (la decisión D-02 de `N3` §5.3). Correcciones medidas:
`ESC-SDEI-1` suma CL-08 y CL-13 (H07) y `TEM-04:86` deja de decir «No hay índice interno»; en `ESC-SDEI-3` la fuente
XML se rotula «prevista» mientras Geometría la tenga apagada. Para `ESC-SDEI-4`, suma CL-06 y CL-09 sólo si la mesa
acepta generalizar desde un único caso privado; esta silla no lo puede verificar en público. **Escenarios
compuestos: no** (multiplica filas sin regla que las cierre; la suma con motivo cubre el caso). El ancla «sin
etiqueta» de N5 B7 entra como fila de ancla, no de clases. **Fundamento**: atomicidad de la celda; hoy una celda
es a la vez mínimo, máximo y observación. **Riesgo**: que la ficha de diseño se vuelva el lugar donde se ocultan
las excepciones; se mitiga con el motivo obligatorio.

### P-17 — Quién decide la fase 1b en `ESC-SDEI-1`

**Posición: decide siempre el **rol** analista (`ACT-SDEI-2`), y el Marco dice que en un corpus de guías lo
ejerce la persona responsable de la guía o quien el PO designe por delegación asentada.** Así las cuatro fuentes
quedan alineadas cambiando dos: `TEM-02:166` (la columna pasa a «quién ejerce el rol de analista») y la clave de
`EJR-SDEI-05` («la analista, o quien el PO designe por delegación»). El caso real de `TEM-02:202` (la mesa, por
delegación del PO) queda como ejemplo de la delegación, no como un cuarto decisor. **Fundamento**: los actores del
Marco son roles; una persona puede ejercer dos. **Riesgo**: que «docente» lea que ahora decide lo normativo; se
evita porque decide en su rol de analista, que el Marco ya define. **Criterio**: CA-08 (§5).

### P-18 — Qué dice el cuerpo del aviso programado

**Posición: reescribir ahora (alternativa 1); programar A1 queda como mejora aparte.** El texto describe el
producto y es falso (H01, P0): se corrige contra el producto. Programar A1 en el carril semanal toca un workflow
común (clase H, `N1-24`) y no corrige el texto que ya está mal. Redacción mínima: «el carril programado avisa que el
SHA de `source.lock` quedó N commits atrás de `main`; la deriva por símbolo la mide A1 cuando se corre la demo».
Afecta `00-Marco.md:183-184`, `01-Mapa.md:68-70` y `Ejercicios.md:112-116`, en el mismo cambio (la unidad de
aplicación es el documento, `MEP` §3.3). **Criterio**: CA-07.

### P-21 — «Las capas A y B no existen» en `TEM-07`

**Posición: reescribir con un hecho fechado y verificable, no dejar.** Medido (H09): en IA.SDD la función de la
capa A la cumple en parte `Logica-De-Decision` 1.0, copiada sin huella igual a la de la base, y la capa B existe
(`Master-Prompt.md:1025`, `Mesa-Rules.md:570`); en Lab-Geometria no hay copia. La frase nueva nombra la capa A
**por alias y versión** y dice, por SDD, qué existe y desde qué commit; las diferencias entre la lección de la
capa A (`TEM-07:176`) y la de `Logica-De-Decision` §5.3 se declaran. `TEM-07:95` (activación de CL-11 en
`ESC-SDEI-3`) se ajusta en el mismo cambio. **Frontera**: si la capa A **debe** ser `Logica-De-Decision` o una
pieza nueva es decisión de diseño, no de esta silla; lo que exijo es que la frase sea verificable. **Riesgo**: que
reescribir «describa lo construido» y absuelva un diseño distinto (`EJ` §3.4, regla 3); por eso se declaran las
diferencias en lugar de borrarlas.

### P-23 — Forma del conocimiento

**Posición: forma estricta de la base (§0–§10, once campos, §6 normativa) con doble cabecera, como mide
`N3` §3.4, más una excepción explícita en la convención del cuerpo para `version`.** La forma libre del
conocimiento de FRAMEWORK MAUI no tiene §6 normativa con niveles ni verificación automática (`N3` §3.3): es la
menos verificable. **Lo que falta** (H11): `00-Marco.md:161` y `Esquema…:66` dicen «`version` sólo en el README».
Medido: sin `version` en el frontmatter, la subida del conocimiento no pone en rojo a quien lo traza; con el ID en
el H1, `id-duplicado`. Dirección: la convención pasa a «`corpus_id` y la versión del cuerpo sólo en el README; una
pieza con versión propia trazable (ficha, conocimiento) la declara en `version`», en el mismo PR que publica el
conocimiento. **Criterio**: CA-10.

### P-24 — Neutralidad respecto de SDD

**Posición: neutral en todo el cuerpo de la pieza, apéndice incluido; lo propio de un marco SDD va al libro (el
capítulo de `TEM-07`) o a un perfil, no a un apéndice del conocimiento.** Medido (§6 E4): una sola línea con «SDD»
en una sección de apéndice hace fallar la neutralidad de la compuerta de la base (`FALLA - neutralidad (1)`,
rc=1). `RFC` §3.12 mide el cuerpo «línea por línea» y deja el vocabulario sólo «en los perfiles». La alternativa
`N3` M-3 («SDD sólo en el apéndice») no cumple su propio fin, que es que la pieza pueda viajar a la base.
**Riesgo**: perder ejemplos concretos de SDD; se compensa con la remisión al libro. **Criterio**: CA-11.

### P-28 — ¿El ensayo en Geometría es la primera mitad del escalón 2?

**Posición: no se mezclan.** Tres razones medibles: (1) el estado del escalón 1 tiene dos respuestas foliadas y la
que rige por fecha dice INSUFICIENTE (H10), y el 0002 pide dictamen antes de cada escalón (D1); (2) `TEM-07:25-26`
cierra el escalón 2 «con la compuerta corriendo en la CI de Lab-Geometria», y el ensayo de N4 vive en una rama
descartable sin merge y no toca el producto (`N4` §7.2): no puede cumplir esa condición; (3) mezclarlos haría que
un mismo folio valga para dos expedientes. El ensayo del 0003 entra al escalón 2 **como evidencia citada**, y el
0003 lo llama «escalón 2», nunca «G2» (`N4` §9). **Riesgo**: repetir trabajo en el escalón 2; se mitiga porque el
escalón 2 parte de las brechas que el ensayo deje. **Condición previa**: la corrigenda del estado de E1 (H10).

## 5. Criterios de aceptación propuestos

Instrumento entre corchetes. Son la forma verificable de las posiciones de §4.

| Id | Dado | Cuando | Entonces [instrumento] |
| --- | --- | --- | --- |
| CA-01 | El libro y sus fuentes en un PR | Corre la CI | El libro regenerado desde las fuentes es idéntico al versionado [`diff` del guion; o, con A, el control de co-cambio] |
| CA-02 | El glosario reeditado | Se busca cada término de P-13 | Cada uno tiene una entrada y ningún uso con otro sentido en `SDEI/`, libro y conocimiento [`git grep -n -w`, salida en el PR] |
| CA-03 | `prefijos.txt` y el anexo del esquema | Se comparan | Coinciden fila por fila y `PE` = patrón de ejemplo [`diff` de las dos listas] |
| CA-06 | El ejemplo de `ESC-SDEI-3` con su `source.lock` | Corre `dg.py trazas` con `--fuente` | 0 trazas «no verificable» en `Prueba-Ayuda-Por-Rol/` [`dg.py`] |
| CA-07 | `00-Marco.md`, `01-Mapa.md`, `Ejercicios.md` | Se busca qué detecta el carril programado | Ninguna frase le atribuye detectar un cambio de método [`git grep -n 'detecta'` y lectura de cada línea] |
| CA-08 | Una fila de RRD `aceptado` | Se audita | La columna de decisión nombra el rol `ACT-SDEI-2` o la delegación con su ruta [lectura de la columna; conteo] |
| CA-09 | `TEM-07` reeditado | Se lee la frase de las capas | Nombra alias, versión y commit por SDD [lectura con criterio cerrado] |
| CA-10 | El conocimiento con `version: X.Y` | Una página traza `@X.Y` y el conocimiento sube | La traza da rojo y vuelve a verde al actualizarla [par rojo/verde de `dg.py trazas`, como §6 E2] |
| CA-11 | El conocimiento copiado a una raíz parcial de la base | Corre `verificar.py --perfil nucleo --adoptante` | `neutralidad` sin fallas [la compuerta de la base] |
| CA-12 | El conocimiento, el libro y un repositorio **nuevo** con sólo un enunciado de producto | Un agente sin contexto diseña su sistema documentador | Produce la ficha de diseño y sus artefactos con la compuerta en verde, 0 invenciones y 0 preguntas que exijan salir del material [corrida ciega como `N3` §5.6, caso C4; registro de preguntas] |

## 6. Ensayos corridos

Todos el 2026-11-01, en `{host-de-pruebas}`, sobre copias en `{dir-de-trabajo}`; ningún repositorio se modificó.

| # | Qué | Comando | Salida (extracto) |
| --- | --- | --- | --- |
| E1 | ¿Los H1 de `TEM-04`…`TEM-06` declaran IDs? | Clon local de LD en `0bed863`, página de prueba con `traces: [TEM-04, TEM-05, TEM-06, CLA-01, ESC-SDEI-3]`; `python3 -I tools/docs-guard/dg.py trazas SDEI/` | Sólo `CLA-01: el ID no está declarado`; `trazas=126 resueltas=116 ids-duplicados=0`: `TEM-04`, `TEM-05` y `TEM-06` **resuelven** (señal para `C-DOC-SIS`, §9) |
| E2 | Versión de un conocimiento en el cuerpo | Repo de prueba con `tools/docs-guard/` copiado; pieza `doc_type: anexo` con `version: 1.0`, y otra con el ID en el H1 | Con `version`: resuelve; al pasar a `1.1`: `ERROR traza-version-desfasada … la declaración está en 1.1` (rojo), y verde al volver. Con ID en el H1: `ERROR id-duplicado` |
| E3 | Placeholders vacíos del libro y del conocimiento | Los dos archivos vacíos en la copia; `dg.py esquema SDEI/` | `ERROR sin-frontmatter` en los dos; `PR-2 esquema: ROJO (errores=2)` |
| E4 | Neutralidad con «SDD» en un apéndice | Copia de `Knowledge-Logica-De-Decision.md` a una raíz parcial; antes y después de sumar una sección «Apéndice por escenario» con una línea «En un proyecto con SDD…»; `python3 -I -B tools/compuerta/verificar.py --perfil nucleo --adoptante --raiz <raíz>` | Antes: `OK: las once verificaciones pasan`. Después: `FALLA - neutralidad (1): líneas con vocabulario del método=1`, rc=1 |
| E5 | Costo de B y de D | `git grep` de enlaces a fuentes del cuerpo desde fuera (LD y LDD), trazas a sus IDs, enlaces relativos entre fuentes y encabezados con ID | LD fuera del cuerpo: 17; desde `Examples/`: 2; LDD: 108; trazas a IDs del cuerpo: 24 (22 dentro del cuerpo, más `AGENTS.md` y ejemplos); enlaces entre fuentes: 256; encabezados con ID: 17 (8 `ESC`/`CTX` del Marco, 5 `EJR`, 3 `TEM-0n`, 1 en plantilla) |
| E6 | Usos de `PE` | `git grep -n -i 'pregunta de evaluaci'` y `git grep -n -E '\bPE-[0-9]+'` en LD | 1 y 12 IDs `PE-01`…`PE-12` más 3 citas en el cuerpo |

Los conteos de E5 por expresión regular son de orden de magnitud: pueden incluir algún enlace dentro de un bloque de
código.

## 7. Lo que revisé y está bien

1. **La ficha `RN-LOC-01`** es el texto más unívoco del cuerpo: letra, intención, comportamiento y divergencia
   separados, con control (C4). Por eso es la definición que propongo en P-13.
2. **La regla de bloqueo de `TEM-06`** (cinco condiciones) y su ejercicio en el workflow: atómica y verificable.
3. **La tabla de `TEM-05:84-89`** es correcta por escenario; el defecto es sólo la frase general de `:48`.

## 8. Fuentes externas

Mandato común (folio 004 §6). Base `N6`, como hipótesis.

| # | Fuente | URL | Consulta | Uso |
| --- | --- | --- | --- | --- |
| 1 | INCOSE, *Guide to Writing Requirements* (características unambiguous, singular, verifiable). Citada **sin apartado**: no se leyó el texto oficial; la referencia secundaria verificada es Wheaton y Herber, *Digital requirements engineering with an INCOSE-derived SysML meta-model*, cuyo resumen dice «extended to comply with the INCOSE Guide to Writing Requirements updated in 2023» y «Rules, Characteristics, and Attributes were defined […] according to the Guide». ISO/IEC/IEEE 29148:2018, sin apartado: la ficha de ISO devolvió 403 | https://arxiv.org/abs/2401.16330 ; https://www.iso.org/standard/72089.html (403) | 2026-11-01 | Definiciones de §1.1 |
| 2 | Cucumber, *Gherkin — Localisation*: `es` = «Dado/Dada/Dados/Dadas», «Cuando», «Entonces» | https://cucumber.io/docs/gherkin/languages/ | 2026-11-01 | Forma de §5 |
| 3 | mdBook, *SUMMARY.md*: «The summary file is used by mdBook to know what chapters to include, in what order they should appear, what their hierarchy is and where the source files are» | https://rust-lang.github.io/mdBook/format/summary.html | 2026-11-01 | P-01, alternativa D |
| 4 | OASIS, *DITA 1.3*, «The DITA conref attributes provide mechanisms for reusing content» | https://docs.oasis-open.org/dita/dita/v1.3/errata02/os/complete/part3-all-inclusive/archSpec/base/conref.html | 2026-11-01 | P-01: reutilizar por referencia, no por copia |
| 5 | Write the Docs, *Docs as Code*: «writing documentation with the same tools as code», incluidos «Automated Tests» | https://www.writethedocs.org/guide/docs-as-code/ | 2026-11-01 | P-01: el control de regeneración es una prueba automática |

## 9. Señales para otras sillas y solicitudes de convocatoria

| # | Señal y ubicación | Para | Por qué no es hallazgo mío |
| --- | --- | --- | --- |
| S-1 | `TEM-04:15`, `TEM-05:15` y `TEM-06:15` («# TEM-0n …») declaran los IDs `TEM-04`, `TEM-05` y `TEM-06` (E1), distintos de sus `doc_id` `TEM-SDEI-0n`, contra la convención de `TEM-03:88-90` y `Esquema…:137-139` | `C-DOC-SIS` | IDs y prefijos son su competencia |
| S-2 | Los archivos vacíos del libro y del conocimiento en el clon principal de LD ponen PR-2 en rojo si se commitean (E3) | `C-VER` y presidencia | Es de entrega, no de requisitos |
| S-3 | `N3` §5.6 y `N4` §7.3 fijan umbrales distintos para la misma prueba | `C-FORMAL`, `C-VER` (P-25) | Umbrales y pesos están fuera de mi competencia |

Sin solicitudes de convocatoria: las tres señales tienen silla en el panel.

## 10. Excepciones a conocimientos

**Ninguna.** La posición de P-23 (excepción a «`version` sólo en el README») cambia una convención **del cuerpo
SDEI**, que no está en el índice de la base: es un cambio propuesto, no una excepción a un conocimiento
(`MEP` §3.4). La alternativa D de P-01 no contradice ningún conocimiento.

## 11. Lo no verificado e incidencias

- **El texto oficial de la guía de INCOSE y de ISO/IEC/IEEE 29148:2018.** Citados sin apartado (§8).
- **Que D sea factible a costo razonable.** Medí el volumen (E5), no corrí un guion de armado: es el peritaje
  propuesto en P-01.
- **Las clases del caso privado** (P-16) salen de la bitácora privada de N5; no las reverifiqué en su repositorio.
- **Si la lección de la capa A debe coincidir con `Logica-De-Decision` §5.3** (P-21): es diseño, no requisito.
- **Ruta del pedido.** La carta da `PROMPTs/…/02-Ajuste-…md` en el worktree de LDD; ahí no existe (`sed`: «No existe
  el fichero»). Se leyó la copia del clon principal, cuya huella coincide con la del folio 001.
- **Mensajes de otra sesión**: no llegó ninguno a mitad de turno ni texto que cambiara el encargo.

## 12. Inventario de lo creado y lo borrado

| Qué | Dónde | Estado al cerrar |
| --- | --- | --- |
| Repositorio de prueba, clon local de LD y raíz parcial de la base (E1–E4) | `{dir-de-trabajo}`, carpeta de la sesión | Borrados al terminar |
| Este folio | `mesa/010-informe-c-req.md` | Queda |
| Contenedores | — | Ninguno |

Sin escrituras en repositorios, sin commits, sin PR.

## 13. Barrido de lo privado de este folio

| Campo | Valor |
| --- | --- |
| Comando | `grep -n -i -E -f <patrones> mesa/010-informe-c-req.md`, con una lista de patrones fuera del folio: rutas de home y del directorio de trabajo, el nombre del servicio privado y de los otros proyectos privados, los hosts del laboratorio, IPv4 y el usuario del host |
| Fecha | 2026-11-01 |
| Resultado | **vacío** después de redactar una mención: el nombre de archivo del folio 259 del 0002, que contiene un nombre de host, se reemplazó por «folio 259 del 0002» |

Sigue: refutador · análisis de decisiones · presidencia
