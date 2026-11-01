---
doc_id: EXP0003-F015
doc_type: informe
title: Informe de la comisión de Uso y accesibilidad — la ayuda al usuario final y por rol que prescribe y ejemplifica el cuerpo SDEI, frente a su regla de traza
status: vigente
origin: agent
confidence: alta en lo medido (ensayos E1 a E5, con comando y salida del 2026-11-01); media en las posiciones, rotuladas «criterio propio» donde no salen de una fuente
owner: comisión C-DOC-USR (silla variable «Uso y accesibilidad») de la mesa de la reedición DocsAsCode
last_review: 2026-11-01
audience: [presidencia, refutador, análisis de decisiones, jurado de veredicto, editores]
traces: [DB-R02-02, DAC0003-N1, DB-R02-N4, DAC0003-N5, DB-R02-N6, TEM-SDEI-05, MARCO-SDEI, MAPA-SDEI]
---

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-01 |
| Autor | Comisión C-DOC-USR, silla «Uso y accesibilidad» (variable V3 de la composición A, `02-Propuesta-De-Panel.md` §6.2), titular: especialista en documentación técnica de usuario. A ciegas |
| Corrige | — |

| Cabecera de comisión | Valor |
| --- | --- |
| Pregunta única de la silla | ¿La ayuda al usuario final y por rol que el cuerpo prescribe y ejemplifica sirve a quien la usa y es coherente con su regla de traza? |
| Preguntas de la mesa a cargo | P-03, P-05, P-07, P-15, P-16 (`02-Propuesta-De-Panel.md` §7) |
| No competencia | IDs fuera de la ayuda; CI; arquitectura de la app. Lo que encontré ahí va como solicitud de convocatoria (§9) |
| Tope de hallazgos | La carta dice «Tope: 10» y, más abajo, «hasta 12 hallazgos propios». Tomo la lectura que menos agrega: **10** |
| Norma | `IA.Knowledge.Base/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` 3.1 |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Líneas 1-111 (cabecera y §0, con el Mapa de carga); §2.2 (l. 155-190); §3.2 (l. 264-280); §3.3 (l. 281-294); §4 (l. 322-334); §5.2 (l. 375-414) |
| Otros documentos cargados | `Cadena-De-Consecuencias` 2.0 §2; `Rule-Escalas-De-Juicio` 1.2 §3.3; `Mesa-Consulta-A-Un-Tercero` 2.0, cabecera, §0 y §1 (no aplica: esta comisión no consultó a nadie de afuera) |
| Insumos leídos | Contrato de entrada `02-Propuesta-De-Panel.md` (§1-§9); núcleos N1 (filas N1-21, N1-23), N2 (§7, §8.6, §9.3, §10.1), N4 (§3.6, §5-§7), N5 (§5 y tabla B), N6 (§3.1, §3.4, §5), `01-Cohesion-Global.md` (fila de la regla de traza); el núcleo privado de N5, leído y no transcripto. No leí informes de otras comisiones |
| Objeto leído directamente | Cuerpo SDEI en Lab-Documentos, base `0bed863`: `TEM-05` entero, `00-Marco.md` §2-§5, `01-Mapa.md` §3-§4, `99-Anexos/Esquema-Frontmatter-Y-Prefijos.md` §3-§4, `Criterios-De-Calidad.md`, `Lista-De-Verificacion.md` (estructura), `Examples/Prueba-Ayuda-Por-Rol/` (README, las 12 páginas, `Ayuda.razor`, `App.razor`, `HelpCatalog.cs`, una captura), la mini demo (`alta-de-localidad.md`, `_requisitos.md`, `source.lock`), `Sistema-Documentador-Tecnico-Guide.md` (§1, §7) y `tools/docs-guard/dg.py` (`trazas`, `esquema`, `prefijos.txt`). Lab-Geometria en `5f07b12` (ADR-10010, casos de uso de la unidad Web) |
| Medios propios | Lectura con `sed`, `grep` y `git`; cinco ensayos con `dg.py` sobre copias descartables en un directorio de ensayos de `{dir-de-trabajo}` (§6); siete consultas web con `curl` (§7) |

## Índice

1. [Definiciones y forma de este informe](#1-definiciones-y-forma-de-este-informe)
2. [Lectura de la pregunta de la silla](#2-lectura-de-la-pregunta-de-la-silla)
3. [Hallazgos](#3-hallazgos)
4. [Dictamen por pregunta](#4-dictamen-por-pregunta)
5. [Lo que revisé y está bien](#5-lo-que-revisé-y-está-bien)
6. [Ensayos corridos](#6-ensayos-corridos)
7. [Fuentes externas](#7-fuentes-externas)
8. [Excepciones a conocimientos](#8-excepciones-a-conocimientos)
9. [Solicitudes de convocatoria](#9-solicitudes-de-convocatoria)
10. [Lo no verificado](#10-lo-no-verificado)
11. [Inventario de lo creado y lo borrado](#11-inventario-de-lo-creado-y-lo-borrado)
12. [Barrido de lo privado en este folio](#12-barrido-de-lo-privado-en-este-folio)

---

## 1. Definiciones y forma de este informe

### 1.1 Definiciones

| Término | Definición en este informe | Fuente |
| --- | --- | --- |
| **Regla de traza de la ayuda** | Lo que el cuerpo exige que declare `traces` de una página de ayuda. Es **compuesta**: una fila `RD-` del registro **y** el caso de uso o la regla de la unidad que contiene la pantalla, con versión | `SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:48` y `:88`; `SDEI/TEM-07-Marco-SDD.md:255-260` |
| **Unidad de la pantalla** | En un proyecto con SDD, el módulo de la especificación al que pertenece la pantalla (en Lab-Geometria, la unidad Web, casos `CU-100NN`); no la unidad de la API que la pantalla llama (`CU-000NN`) | `TEM-05:46`; `TEM-07:258-260` |
| **Sirve a quien la usa** | La persona usuaria logra la tarea con la página: los pasos son los que ve en pantalla, lo irreversible está avisado, los errores llevan el mensaje literal, y la página se puede leer con tecnología de asistencia | `TEM-05:203-221` (preguntas para producir y evaluar); `CQ-09` (`Criterios-De-Calidad.md:39`); WCAG 2.2 (§7, fuente 5) |
| **Página de rol** | Página de ayuda con el esquema liviano (`title` y `roles` o `translation_of`, sin `doc_id`) | `99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:64` |

Prefijos de ruta: `SDEI/` es `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/` de Lab-Documentos;
`PAR/` es `SDEI/Examples/Prueba-Ayuda-Por-Rol/`; `LG/` es la raíz de Lab-Geometria. Lab-Documentos y Lab-Geometria
son públicos.

### 1.2 Lectura P0–P3 aplicada

La del contrato (`02-Propuesta-De-Panel.md` §8): **P0** viola una restricción dura o hace imposible el objetivo;
**P1** retrabajo o lectura divergente entre lectores o aplicadores; **P2** pérdida acotada; **P3** claridad. Aplicada a
la ayuda: una regla que el ejemplo contradice y que un aplicador va a copiar es P1; una página de ejemplo que omite un
paso o un aviso es P2 (el ejemplo conductor del cuerpo es la mini demo, no la prueba de ayuda por rol, `00-Marco.md`
§6); una errata es P3.

## 2. Lectura de la pregunta de la silla

La pregunta tiene dos mitades y las dos tienen respuesta medida:

1. **¿Es coherente con su regla de traza?** No en el escenario con roles. La regla es una sola y es compuesta
   (`TEM-05:48`, `:88`; `TEM-07:258-260`). Las siete páginas en castellano de la prueba de ayuda por rol trazan a casos
   de uso de la unidad Api y a ninguna fila `RD-` (`PAR/Web/Ayuda/es/**`, línea `traces`). La compuerta no lo ve: da
   verde con la traza a la unidad equivocada y con la correcta (E1, §6). En el escenario sin roles, la mini demo cumple
   (`alta-de-localidad.md:11`: `traces: [RD-01, RN-LOC-01@1.1, RN-LOC-02@1.0]`).
2. **¿Sirve a quien la usa?** La plantilla y la página de la mini demo sí (§5). Las páginas de la prueba de ayuda por
   rol tienen tres faltas que una persona usuaria nota: un paso que la pantalla tiene y la página no (H01), una acción
   irreversible sin aviso (H06) y contenido en castellano marcado como inglés para un lector de pantalla (H07). Las dos
   primeras salen, justamente, de no haber leído el caso de uso de la unidad de la pantalla.

## 3. Hallazgos

Tope: 10. Ancla según `Rule-Escalas-De-Juicio` 1.2 §3.3.

| Id | Nivel | Ancla con cita | Hallazgo | Impacto si no se corrige | Dirección de la corrección |
| --- | --- | --- | --- | --- | --- |
| H01 | P1 | E2: `TEM-05:48` («Toda página de usuario traza a un `RD-`») y `:88` («La fila `RD-` y el caso de uso de la unidad de la pantalla»); `PAR/Web/Ayuda/es/alumno/enviar-un-trabajo.md:6` (`traces: [CU-00026@1.1]`); `LG/SDD/Docs/Unidades-Entrega/GeometriaFactory-Web/02-Especificacion-Funcional/Casos-De-Uso/CU-10005-…md:52-54` («El alumno pide previsualizar») frente a los pasos de la página (`enviar-un-trabajo.md:13-18`, sin previsualizar) | El único ejemplo del escenario `ESC-SDEI-3` viola las dos mitades de la regla, y la violación tiene un costo para quien usa la ayuda: la página derivada del caso de la API omite el paso de previsualizar que tiene la pantalla | El libro (capítulos 8 y 14, N2 §7.2) enseña con un ejemplo que contradice la regla del mismo capítulo; un aplicador la copia; la persona usuaria no encuentra en la ayuda un paso que ve en pantalla | Retrazar las páginas al caso de uso de la unidad Web con su versión actual, sumarles una fila `RD-` y **releer el texto** contra el caso nuevo (P-15) |
| H02 | P1 | E1: E1 de §6 (las mismas páginas dan `verde … trazas=9 resueltas=9` trazadas a la API y `verde … trazas=8 resueltas=8` trazadas a la unidad Web); E2: `TEM-05:215-221` (las cuatro preguntas para evaluar no preguntan por la unidad) | La mitad «caso de uso de la unidad de la pantalla» no es un control: `traces-resolve` resuelve cualquier `CU-` y ninguna pregunta de evaluación lo pide | El defecto de H01 vuelve a entrar en cualquier proyecto, con la compuerta en verde | Una pregunta de evaluación en `TEM-05` («¿El caso trazado es el de la unidad que contiene la pantalla?») y la columna «Fuente» del RRD con ese caso, para que la revisión lo vea. Sumar ahí los límites que el proyecto fije para su ayuda: Lab-Geometria tiene uno escrito y verificable, «la ayuda no entrega el JSON ni las clases resueltas» (`LG/…/Adrs/ADR-10010-…md`, §2 punto 3 y §8), que `SDEI` no cita (`grep -rn ADR-10010 SDEI/` → nada) |
| H03 | P1 | E1: E2 de §6 (páginas retrazadas con un `source.lock` en su carpeta y sin `--fuente`: `ROJO (errores=8 …)`, `traza-no-resuelve`; sin `source.lock`: `verde (errores=0 avisos=8)`); E2: `TEM-05:205-207` («Si el caso de uso vive en otro repositorio y la carpeta no tiene `source.lock`, la traza no se puede verificar y la compuerta sólo avisa») y `TEM-05:100` | `TEM-05` presenta el `source.lock` como lo que vuelve verificable la traza, pero no dice que además hace falta un trabajo de la CI que baje el código en ese SHA y lo pase por `--fuente` (como `mini-demo-movilidad.yml` para la mini demo). Agregar sólo el `source.lock` pone la compuerta en rojo | Quien aplique la opción «sumarle `source.lock`» de P-15, o siga `TEM-05` en un proyecto propio, deja la compuerta en rojo (restricción dura del contrato) | Decir en `TEM-05` §2 que el `source.lock` va con su trabajo de verificación, o no va. El trabajo de CI no es de esta silla (SC-1, §9) |
| H04 | P2 | E1: E3 de §6 (un RRD de la prueba de ayuda por rol con `RD-01`: `ROJO (errores=5 …)`, `id-duplicado: RD-01: también declarado en …/MovilidadUrbana-Mini-Demo/docs/_requisitos.md:44` y `traza-ambigua` en la página de la mini demo; con `RD-21`: `verde`); E2: `prefijos.txt:27` (`RD interno`) | Los `RD-` son únicos en todo el repositorio y el cuerpo no lo dice: un segundo ejemplo que numere su registro desde `RD-01` rompe la traza del primero | Al aplicar P-15 se rompe la página conductora de la mini demo | Para P-15: numerar el registro del segundo ejemplo en un rango propio. Si los IDs pasan a ser locales por carpeta es decisión de trazabilidad (SC-2, §9) |
| H05 | P2 | E2: `TEM-05:189-190` (`translation_of: es/alumno/enviar-un-trabajo.md@a1b2c3d`, la revisión de la página fuente) frente a `PAR/Web/Ayuda/en/alumno/enviar-un-trabajo.md:4` y `en/comun/ingresar.md:4` (`…@CU-00026@1.1`, la versión del caso de uso); la desviación sólo está explicada en `Sistema-Documentador-Tecnico-Guide.md:486`, que está `obsoleto` y se archiva (`:6`, `:25`). Además `TEM-05:183-184` remite a esa misma guía para «la derivación del caso de uso a la página sección por sección» | Dos piezas de la ayuda dependen de la guía obsoleta: la explicación de por qué el ejemplo ancla la traducción a otra cosa, y la derivación detallada | Al archivarse la guía, el libro hereda un ejemplo que contradice su regla sin explicación. Y el ancla del ejemplo no detecta lo que la regla quiere detectar: si la página fuente cambia sin que cambie el caso de uso, la traducción no queda marcada como atrasada y quien lee en inglés recibe texto viejo | Alinear el ejemplo con `TEM-05:190` o declarar la desviación en `TEM-05` §3.4; traer al tema (o al capítulo 8 del libro) lo que siga vivo de la derivación de la guía §7.4 |
| H06 | P2 | E2: `PAR/Web/Ayuda/es/administrador/gobernar-las-cuentas.md:3` (`description: Habilitar, bloquear, rehabilitar y dar de baja …`) frente al cuerpo (`:11-23`: sólo «Habilitar una cuenta» y «Qué no vas a poder hacer»); `LG/…/CU-10004-…md:33` («dar de baja con una confirmación escrita que declara que la baja elimina también los trabajos de esa cuenta»); `TEM-05:261` (plantilla: «¿Hay algo que no puede deshacer?») | La página promete en su descripción cuatro tareas y explica una; la acción irreversible (la baja borra los trabajos del alumno) no aparece | Un administrador que busca cómo dar de baja no encuentra nada, y nada le avisa que pierde los trabajos. El ejemplo enseña a omitir justo lo que la plantilla pide | Completar la página o acotar su `description` a lo que cubre; en cualquier caso, el aviso de lo irreversible. Mismo origen que H01: se derivó del caso de la API |
| H07 | P2 | E1: `grep -rniE 'accesib\|wcag\|lector de pantalla\|texto alternativo' SDEI --include=*.md` → ninguna coincidencia normativa (sólo `aria-hidden` y `lang=` en dos `.razor`); E2: `PAR/Web/Components/App.razor:2` (`<html lang="@CultureInfo.CurrentUICulture…">`) y `PAR/Web/Components/Pages/Ayuda.razor:31-35` (la página sin traducir se pinta en castellano dentro de ese `html`, sin `lang` propio); captura `PAR/capturas/ayuda-05-alumno-en-sin-traducir.png` (interfaz en inglés, cuerpo en castellano) | La accesibilidad no figura en `TEM-05` ni en `CQ-01` a `CQ-14`. El ejemplo de idiomas sirve contenido en castellano marcado como inglés | Un lector de pantalla lee la página con la pronunciación del inglés: incumple WCAG 2.2, criterio 3.1.2 «Language of Parts» (nivel AA) (§7, fuente 5). La política de respaldo de idioma, buena en sí (§5), pierde a quien usa tecnología de asistencia | Un criterio de accesibilidad de la ayuda en `TEM-05` (idioma de las partes, texto de los enlaces, estructura de encabezados), con WCAG 2.2 como norma; en el ejemplo, `lang="es"` en el artículo de respaldo. Cómo se implementa en la app no es de esta silla |
| H08 | P2 | E2: `SDEI/Examples/MovilidadUrbana-Mini-Demo/docs/_requisitos.md:44` (criterio de `RD-01`: «cada número coincide con el de la ficha; instrumento: `traces-resolve`») frente a `TEM-05:215-218` («el verde se consigue con sólo cambiar el número»); `TEM-05:220` («¿Una persona sin conocimiento del sistema hace la tarea sin ayuda (prueba de lectura)?») sin instrumento ni ejemplo en el cuerpo | El criterio de la única fila `RD-` de ayuda declara medir lo que su instrumento no mide (compara versiones, no números), y la pregunta de uso del tema no tiene instrumento | Ninguna pieza del cuerpo comprueba que la ayuda sirva a quien la usa; sólo que no esté atrasada respecto de su regla | Partir el criterio: versión al día (`traces-resolve`), relectura declarada en el pull request (`TEM-05:216-218`) y, cuando lo decida una persona, una prueba de lectura con un procedimiento citado (§7, fuente 7) |
| H09 | P3 | E2: `PAR/Web/Components/Pages/Ayuda.razor:36-39` (bloque «Deriva de», «Visible para», «Fuente»); captura `ayuda-05` («Derived from CU-00028@1.1, CU-00029@1.1», «Visible to Student»); `TEM-05:59-60` (la ayuda no es el caso de uso publicado; los códigos internos no van) | La prueba muestra a la persona usuaria los IDs de la especificación y el nombre interno del rol (`Student`, en inglés también en la interfaz en castellano) | Quien copie la prueba lleva vocabulario del equipo a la ayuda | Declarar en el README de la prueba que ese bloque es un diagnóstico de la demostración y no va en un producto |
| H10 | P3 | E1: `grep -rnoE '\b[a-zñ]+[áéí](lo\|la\|los\|las\|le\|les\|me\|te\|nos)\b' SDEI --include=*.md` → `PAR/Web/Ayuda/es/comun/ingresar.md:11: enviálo` (además de tres «cuáles», correctos); E2: «papel» en `PAR/README.md:8`, `ingresar.md:11`, `Ayuda.razor:27` frente a «Rol» definido en `TEM-05:45`; títulos «Mis trabajos» y «Gobernar las cuentas» frente a `TEM-05:247` («Verbo + objeto»; «¿Nombra la tarea, no la pantalla?») | Una errata de tilde en un imperativo con voseo («enviálo» por «envialo»), dos palabras para el mismo concepto y títulos que nombran una pantalla o usan jerga del equipo | Menor; pero es la forma que el libro va a copiar en el capítulo 14 | Ronda ortotipográfica con la base de P-05; un solo término («rol») en las páginas; títulos con verbo y objeto en el vocabulario de la persona usuaria |

## 4. Dictamen por pregunta

Cada respuesta pasa por `Cadena-De-Consecuencias` 2.0 §2: dónde cae, cuánto pesa (medido), qué pierde la alternativa
y si es reversible.

### P-15 — ¿A qué traza una página de ayuda y cómo se corrige el ejemplo?

**Posición.** La regla queda como está, compuesta, y se escribe **una sola vez y entera** en la definición; el ejemplo
se corrige en dos tiempos. Es una combinación de la opción 1 sin `source.lock`, con un agregado.

1. **La regla.** `TEM-05:48` y `:88` no se contradicen: `:88` es `:48` más el caso de la unidad. Se reescribe `:48`
   para que diga las dos mitades, y `:88` y `:98` remiten a ella. **No** se rebaja la regla para que el ejemplo pase:
   eso es la opción 3 leída como «reescribir para no contradecir», y el filtro «Descripción o control»
   (Mesa-De-Expertos-A-Pedido §3.3) lo prohíbe: `:48` declara un control que el ejemplo no ejerce, y reescribirlo lo
   absuelve sin que nadie vote la derogación.
2. **Ahora, en la reedición.** Retrazar las siete páginas en castellano al caso de uso de la unidad Web con su versión
   actual en `5f07b12` (E1 de §6: `CU-10002@1.5`, `CU-10003@1.5`, `CU-10004@1.9`, `CU-10005@1.2`, `CU-10006@1.1`,
   `CU-10007@1.3`, `CU-10009@1.1`; el mapeo página→caso es propuesta y lo revisa quien aplica), sumar un registro
   `doc_type: rrd` en la carpeta de la prueba con un rango `RD-` propio (H04), **releer el texto** contra cada caso
   nuevo (corrige H01 y H06; es lo que pide `TEM-05:215-218`), y actualizar `translation_of` de las dos traducciones
   (H05). Sin `source.lock`: las trazas siguen «no verificables», con aviso, como ya explica `TEM-05:155-157` (pasan
   de 9 a 8 avisos, y ese número se corrige en `:143` y `:155`).
3. **Cuando haya con qué verificarlo.** `source.lock` más un trabajo de CI que baje Lab-Geometria en ese SHA y pase
   `--fuente`, como la mini demo. Condición comprobable para revisarlo: que exista ese trabajo en la CI de
   Lab-Documentos o que el escalón 2 lleve la compuerta a la CI de Lab-Geometria (`TEM-07:25-28`). No antes: H03.
4. Las páginas de `PAR/Consola/Ayuda/` no trazan y están bien así: son el banco de prueba del validador, con defectos
   plantados (`PAR/README.md:55-63`). Se declara que quedan fuera de la regla.

| Paso de la cadena | Retrazar y releer, sin `source.lock` (recomendada) | Declarar el ejemplo anterior a la regla | Reescribir `:48` para que no contradiga a `:88` |
| --- | --- | --- | --- |
| ¿Dónde cae? | En quien aplica: 7 líneas `traces`, 2 `translation_of`, un RRD nuevo, la relectura de 7 páginas, `PAR/README.md:12` y dos números de `TEM-05` | En la persona usuaria del ejemplo y en el lector del libro: la página sigue sin el paso de previsualizar ni el aviso de la baja | En el cuerpo: la regla pierde su mitad verificable por revisión |
| ¿Cuánto pesa? | `grep -c '^traces' PAR/Web/Ayuda/es/*/*.md` → 7 archivos; la compuerta queda verde (E1, E3 con rango propio) | Una oración; pero `ESC-SDEI-3` sigue sin ningún ejemplo que cumpla (N1-21, verificado: E1 de §6) | Una oración; deja el defecto de H01 sin señal |
| ¿Qué pierde? | Nada de lo que hoy funciona; la verificación mecánica de la traza queda para después (paso 3) | El ejemplo deja de enseñar la regla; el capítulo 14 del libro enseña lo contrario del 8 | La regla de `TEM-07:258-260`, que explica por qué la página traza al front y no a la API |
| ¿Reversible? | Sí: es texto en un repositorio, sin terceros | Sí | Sí, pero absuelve un control sin voto (§3.3) |

**Fuentes externas.** ISO/IEC/IEEE 26514:2022 trata la información para usuarios con análisis de audiencia y de tareas
(ya citada en `TEM-05:36-39`, `Referencias.md:84`): la tarea es la de la pantalla, no la del servicio. Diátaxis define
la guía práctica como «goal-oriented», orientada a lo que la persona hace (§7, fuente 1).
**Riesgo.** Que la relectura se saltee y sólo se cambie el número: es el riesgo que `TEM-05:215-218` ya nombra. Lo
cubre la línea «releída contra la versión nueva» en la descripción del pull request.
**Evidencia que la sostendría.** La corrida E1 repetida sobre el resultado (verde con `CU-100NN`), un `diff` que muestre
el paso de previsualizar y el aviso de la baja, y la corrida completa del cuerpo en verde (E3).

### P-16 — ¿Qué clases activa cada escenario?

**Posición (sólo la parte de la ayuda, CL-06).** **Admitir escenarios compuestos** y no sumar CL-06 a la fila de
`ESC-SDEI-4`. Una oración en `00-Marco.md` §2: un sistema que reúne rasgos de dos escenarios activa la unión de sus
clases; la ayuda al usuario final la activa el panel con usuarios, no el servicio. El ejemplo de `ESC-SDEI-4` tiene un
panel con roles (N5, tabla B, fila B1; lo confirmé en el núcleo privado, sin transcribirlo): queda como `ESC-SDEI-4` +
`ESC-SDEI-3`.

| Paso de la cadena | Escenarios compuestos (recomendada) | Sumar CL-06 a la fila de `ESC-SDEI-4` |
| --- | --- | --- |
| ¿Dónde cae? | Una oración en el Marco §2 y una nota en la fila de `TEM-05:89` | En la fila `00-Marco.md:105`, en `TEM-05:89` y en `01-Mapa.md:58` |
| ¿Cuánto pesa? | Dos ediciones; ninguna contradicción nueva | Contradice el mismo cuerpo: `TEM-05:89` dice que en `ESC-SDEI-4` «la persona usuaria es quien integra» y su ayuda son `CL-05` y `CL-13`. Hay que reescribir esa fila |
| ¿Qué pierde? | Nada | El arquetipo deja de servir: un servicio de paquetes sin panel (el caso puro) pasa a «exigir» ayuda de usuario final y empuja a escribirla para quien integra, que necesita referencia y README |
| ¿Reversible? | Sí | Sí |

**Fuente externa.** El caso público de P-07 es exactamente uno compuesto: el índice para agentes del proveedor describe
el producto como «a single API, Journey Builder, and a dashboard» y mezcla referencia de la API (`/reference/`, 71
entradas) con guías (`/docs/`, 86 entradas) (§7, fuente 3, 2026-11-01).
**Riesgo.** Que «compuesto» se use para no decidir. Se acota: la composición se declara con los escenarios que la
forman y con la pieza que activa cada clase.
**Evidencia.** `grep -rn -i 'compuest\|más de un escenario' SDEI --include=*.md` hoy no devuelve nada fuera de la guía
obsoleta: el cuerpo no lo prohíbe ni lo prevé.
**Fuera de mi competencia:** CL-08 y CL-13 en `ESC-SDEI-1`, CL-09 en `ESC-SDEI-4`, la fuente XML «prevista» de
`ESC-SDEI-3` y el ancla por familia. No tomo posición.

### P-15 y P-16 no son independientes

`01-Cohesion-Global.md:242` pone P-15 y P-16 resueltas como condición de los oráculos de los ensayos. Desde esta silla:
el oráculo de la ayuda en el ensayo de Geometría tiene que pedir la traza a la unidad Web y la revisión contra el límite
de ADR-10010 (N4 §7.1 punto 7 ya lo propone; verificado el ADR en `5f07b12`).

### P-07 — ¿Cómo entra el caso del portal de notificaciones?

**Posición.** **Reverificado**, con la fecha de consulta 2026-11-01, y una línea que diga cuándo se verificó por
primera vez. La reverificación es barata y ya la corrí (§7, fuentes 2 a 4):

| Afirmación de la guía obsoleta (§1.1-§1.4) | Hoy, 2026-11-01 |
| --- | --- |
| `<meta name="generator" content="Mintlify"/>` | Sigue (`grep -o` sobre el HTML) |
| 1.133 ocurrencias de `mintlify` en el HTML | **206** |
| `create-user.md` → 200 `text/markdown`, 920 líneas | 200 `text/markdown`, **834** líneas; ahora abre con un aviso que remite a `llms.txt` |
| Bloque `openapi: 3.1.0`, versión `'11.6'`, en la línea 60 | Igual, línea 60 |
| `llms.txt` → 200 `text/plain`, índice de 170 páginas | 200 `text/plain`, **179** entradas `- [` |

| Paso de la cadena | Reverificado (recomendada) | HISTÓRICO con fecha original | Excluido y declarado |
| --- | --- | --- | --- |
| ¿Dónde cae? | En quien redacta 18.1: tres `curl` | En el lector: cifras que ya no son las del sitio | En el capítulo 18 y en el 8: se pierde el caso |
| ¿Cuánto pesa? | Minutos; hecho en este informe | Tres de cinco cifras cambiaron en siete semanas | El único caso de industria que muestra la ayuda servida como HTML, `.md` y `llms.txt` desde la misma fuente, que es el patrón que la prueba de ayuda por rol traduce (`Sistema-Documentador-Tecnico-Guide.md:406-410`; diagrama de `TEM-05:65-74`) |
| ¿Reversible? | Sí | Sí | Sí, pero el capítulo de industria pierde su único caso verificado de punta a punta |

**Dos agregados desde la silla.** Primero, el caso es la documentación de **quien integra** (referencia de una API y
SDK), no ayuda al usuario final: en el libro va como ejemplo del patrón de entrega (`.md` y `llms.txt`), no como modelo
de página de ayuda. Segundo, el caso no tiene entrada en las referencias: `grep -ni onesignal SDEI/99-Anexos/Referencias.md`
→ nada, aunque `TEM-01:171` y `TEM-04:105` lo citan; `00-Marco.md:165` pide APA con fecha de consulta **siempre**. Al
nombrarlo, conviene decir que es un proveedor público y externo, para que el lector no lo confunda con el servicio
privado de notificaciones de `ESC-SDEI-4`, que el cuerpo nombra sólo por alias.
**Riesgo.** Que el sitio cambie otra vez antes de publicar el libro. **[criterio propio]** Condición comprobable: se
reverifica en el mismo pull request que publica el libro si la fecha de consulta tiene más de 90 días.
**Evidencia.** Las salidas de §7, fuentes 2 a 4.

### P-05 — ¿Qué guía de estilo de base usan las rondas de estilo y ortotipografía?

**Posición.** Tres niveles, en este orden de precedencia, con **una** guía externa y no dos:

1. Las convenciones del cuerpo (`00-Marco.md` §5) mandan, incluido el voseo (`:171`).
2. Para la lengua (ortografía, ortotipografía, gramática): las obras de la RAE y la ASALE, *Ortografía de la lengua
   española* (2010) y *Diccionario panhispánico de dudas*. Son las que la propia guía de Microsoft en español pone como
   base (§7, fuente 6, «Recommended reference material»).
3. Para la forma de los procedimientos y del texto de interfaz: **Microsoft Writing Style Guide**, con su guía
   *Spanish (Neutral)* como consulta. Donde choque con 1 (por ejemplo, Microsoft usa «tú» o «usted»; el cuerpo usa
   «vos»), manda 1.

| Paso de la cadena | Cuerpo + RAE/ASALE + Microsoft (recomendada) | Sólo convenciones del cuerpo | Cuerpo + Google |
| --- | --- | --- | --- |
| ¿Dónde cae? | En los editores de estilo y ortotipografía: una fila en P.4 del libro y en `00-Marco.md` §5 | En los mismos editores, sin árbitro para lo que el cuerpo no dice | En los mismos |
| ¿Cuánto pesa? | Una fila | Cero filas; pero el cuerpo no tiene regla de tildes y la errata de H10 pasó todas las rondas anteriores | Una fila |
| ¿Qué pierde? | Nada de lo que rige: la precedencia es la que la industria recomienda («Refer to project-specific guidelines first», §7, fuente 8) | Arbitraje de las dudas de lengua y de procedimientos | Cubre la parte de desarrollo, pero su alcance declarado es «technical documentation for software developers and other technical practitioners» (§7, fuente 8): no cubre a la persona usuaria final que lee `CL-06`, y sus referencias de terceros son en inglés. No tiene guía de localización al castellano en la página consultada |
| ¿Reversible? | Sí | Sí | Sí |

**Por qué Microsoft y no Google, desde esta silla.** El cuerpo tiene una clase de pieza para personas usuarias (CL-06)
y la ayuda es procedimiento. La guía de Microsoft trata procedimientos paso a paso («Use a numbered list», «Use a
separate step for each instruction») con consejos de accesibilidad incorporados («Accessibility tip: Screen readers
might skip over brackets…») (§7, fuente 9), y tiene edición en castellano neutro. **Riesgo.** La guía *Spanish
(Neutral)* es un PDF de 2021 (`pdfinfo`: `CreationDate … 2021`); se cita con su fecha. **Evidencia.** Las fuentes 6, 8 y
9 de §7, abiertas el 2026-11-01.

### P-03 — ¿Qué partes, orden y anexos tiene el libro?

**Posición.** Se adopta la estructura de N2 §7 (prólogo, partes I a VI, capítulos 1-18, anexos A-J) con tres ajustes
desde la ayuda; las otras dos variantes no son de esta silla.

1. **Diátaxis por capítulo, no por parte.** La variante de N6 §5 punto 6 rotula cada parte. La parte V mezcla formas
   (N2 §7.2: el capítulo 11 es consulta, el 12 procedimiento, el 13 caso guiado, el 15 explicación y método, el 16
   ejercicios): un rótulo por parte sería falso para ella. Un rótulo por capítulo en la tabla de rutas del prólogo
   (P.3) cuesta una columna. Fuente: Diátaxis, «four distinct needs, and four corresponding forms» (§7, fuente 1).
2. **Ruta de lectura «escribo la ayuda de un producto»** en P.3: capítulos 8 y 14, anexo C (esquema) y G.9. Hoy la
   única pieza para personas usuarias del cuerpo no tiene ruta propia; quien la escribe es, por el Marco, un agente que
   propone y una analista que decide (`00-Marco.md` §4, `ACT-SDEI-2` y `ACT-SDEI-4`).
3. **G.9 con dos variantes**: la página completa con los diez campos (la de la mini demo, `TEM-05:242-273`) y la página
   de rol con el esquema liviano (`Esquema-Frontmatter-Y-Prefijos.md:64`). Hoy `TEM-05:275-276` dice «se suma el campo
   `roles`» a la primera, y el esquema reconoce como página de ayuda a la que **no** tiene `doc_id`. Las dos pasan la
   compuerta (E4 de §6), pero el lector no sabe cuál elegir.

**Fuera de mi competencia:** el anexo de herramientas con versión (N6 §5 punto 1) y la sección «de la explicación al
conocimiento» (N3 §7). Sin posición.
**Cadena.** Cae en el bloque B1 (prólogo) y B6 (anexos) del reparto de N2 §7.5; pesa una columna, una fila y una
plantilla más; la alternativa «por parte» pierde exactitud en la parte V; todo es reversible.
**Riesgo.** Que el rótulo Diátaxis se lea como clasificación normativa. Va como orientación de lectura.

## 5. Lo que revisé y está bien

1. **La confidencialidad por rol está bien pensada y bien ejemplificada.** `TEM-05:102-108` decide en el servidor,
   devuelve 404 y no 403, y aplica el mismo filtro al `.md` y al `llms.txt`; `PAR/Web/HelpCatalog.cs:66` niega la
   página si el rol de la sesión no está en `roles` de la fuente, y `PAR/Consola/salida.txt` (citado en `TEM-05:167-176`)
   muestra el 404 del alumno y el 200 del administrador.
2. **La página de la mini demo es un buen modelo de ayuda.** `alta-de-localidad.md` sigue la tarea y no el código,
   da el mensaje literal, y declara la divergencia 60/80 sin decidirla, con qué hacer mientras tanto (`TEM-05:126-134`).
   Cumple la regla de traza entera (`:11`).
3. **La falta de traducción no deja a nadie sin ayuda.** `TEM-05:188` (idioma fuente con aviso, nunca 404) y
   `HelpCatalog.cs:66-70` lo implementan. Lo que falta es marcar el idioma de esa parte (H07), no la política.

## 6. Ensayos corridos

Todos con `python3 -I tools/docs-guard/dg.py` de Lab-Documentos (`dg.py` en `b3916b8`, árbol en `0bed863`), sobre
copias descartables en un directorio de ensayos de `{dir-de-trabajo}`; el SDD de Lab-Geometria se bajó con
`git archive 5f07b12 SDD/Docs/Unidades-Entrega` y sin `_legacy/`. Rutas abreviadas como `{e1}`, `{e3}`.

| Ensayo | Qué se hizo | Salida (2026-11-01) | Sostiene |
| --- | --- | --- | --- |
| E1 | Las 7 páginas `PAR/Web/Ayuda/es/**` tal como están, y retrazadas a la unidad Web; `trazas … --fuente <SDD>` | Actual: `verde (errores=0 avisos=0) trazas=9 resueltas=9`, rc=0. Retrazadas: `verde (errores=0 avisos=0) trazas=8 resueltas=8`, rc=0. Con `CU-10005@1.1`: `ERROR traza-version-desfasada: CU-10005@1.1: la declaración está en 1.2`, `ROJO`, rc=1 | H01, H02, P-15 (la traza nueva resuelve y la compuerta la vigila) |
| E2 | Las retrazadas con un `source.lock` en su carpeta, sin `--fuente`; después sin `source.lock` | Con lock: `ERROR traza-no-resuelve: CU-10003@1.5 …`, `ROJO (errores=8 avisos=0) trazas=8 resueltas=0`, rc=1. Sin lock: `aviso traza-no-verificable …`, `verde (errores=0 avisos=8)`, rc=0 | H03; paso 2 y 3 de P-15. El código: `dg.py:686-690` (el aviso sólo si no hay `source.lock` ni `--fuente`) |
| E3 | Copia completa de Lab-Documentos (`git archive HEAD`) con un RRD en `PAR/` que declara `RD-01` y la página «Enviar un trabajo» trazada a él; después con `RD-21` | Con `RD-01`: `ERROR id-duplicado: RD-01: también declarado en …/MovilidadUrbana-Mini-Demo/docs/_requisitos.md:44`, `ERROR traza-ambigua` en `alta-de-localidad.md` y en la página, `ROJO (errores=5 avisos=9)`, rc=1. Con `RD-21`: `verde (errores=0 avisos=9) trazas=122 resueltas=113`, rc=0 | H04; P-15 (la opción recomendada deja la compuerta en verde) |
| E4 | Una página con los diez campos más `roles: [Student]`; `esquema` | `verde (errores=0 avisos=1)`, rc=0 (el aviso es `traces-vacio`) | P-03, punto 3 (las dos variantes pasan) |
| E5 | `grep` de accesibilidad y de imperativos con tilde sobre `SDEI` | Ver H07 y H10 | H07, H10 |

## 7. Fuentes externas

| # | Fuente | URL | Consulta | Uso |
| --- | --- | --- | --- | --- |
| 1 | Procida, D. (s. f.). *Diátaxis*, página «How-to guides»: «How-to guides are directions that guide the reader through a problem or towards a result. How-to guides are goal-oriented» | https://diataxis.fr/how-to-guides/ (y https://diataxis.fr/) | 2026-11-01, `curl` 200 | P-03, P-15 |
| 2 | OneSignal, página de referencia «Create user» (HTML y `.md`) | https://documentation.onesignal.com/reference/create-user y `…/create-user.md` | 2026-11-01 18:28 UTC: HTML 200; `.md` 200 `text/markdown; charset=utf-8`, 834 líneas; `generator" content="Mintlify"`; 206 ocurrencias de `mintlify`; `openapi: 3.1.0` y `version: '11.6'` en las líneas 60-63 | P-07 |
| 3 | OneSignal, índice para agentes | https://documentation.onesignal.com/llms.txt | 2026-11-01: 200 `text/plain`; 179 entradas `- [`; 71 con `reference/`, 86 con `/docs/`; descripción «via a single API, Journey Builder, and a dashboard» | P-07, P-16 |
| 4 | Guía obsoleta del cuerpo, §1.1-§1.4, como punto de comparación | `SDEI/Sistema-Documentador-Tecnico-Guide.md:99-172` | Lectura del repositorio | P-07 |
| 5 | W3C. (2024). *Web Content Accessibility Guidelines (WCAG) 2.2*, W3C Recommendation, 12 de diciembre de 2024; SC 3.1.1 «Language of Page» (A) y SC 3.1.2 «Language of Parts» (AA): «The human language of each passage or phrase in the content can be programmatically determined…» | https://www.w3.org/TR/WCAG22/ | 2026-11-01, `curl` 200 | H07 |
| 6 | Microsoft. *Spanish (Neutral) Style Guide*, PDF de 56 páginas, creado el 2021-04-29; §2.1 «Recommended reference material» (DPD, DLE, *Nueva gramática*, *Ortografía de la lengua española* 2010); §3.3 «Tú/usted usage» | https://aka.ms/spanish-neutral-styleguide → `download.microsoft.com/…/spa-neu-StyleGuide.pdf`, listado en https://learn.microsoft.com/en-us/globalization/reference/microsoft-style-guides | 2026-11-01, `curl` 200, `pdftotext` | P-05 |
| 7 | Nielsen Norman Group, «Usability Testing 101»: «In a usability-testing session, a researcher … asks a participant to perform tasks…»; «we recommend using five participants to uncover the majority of the most common problems» | https://www.nngroup.com/articles/usability-testing-101/ | 2026-11-01, `curl` 200 | H08 |
| 8 | Google, *Google developer documentation style guide*: «helps you write clear and consistent technical documentation for software developers and other technical practitioners. Refer to project-specific guidelines first, then this guide, and finally third-party references like Merriam-Webster or the Chicago Manual of Style» | https://developers.google.com/style | 2026-11-01, `curl` 200 | P-05 |
| 9 | Microsoft, *Writing step-by-step instructions*, Microsoft Writing Style Guide: «Use a numbered list»; «Use a separate step for each instruction»; «Accessibility tip: Screen readers might skip over brackets…» | https://learn.microsoft.com/en-us/style-guide/procedures-instructions/writing-step-by-step-instructions | 2026-11-01, `curl` 200 | P-05 |
| 10 | ISO/IEC/IEEE 26514:2022, ya citada por el cuerpo (`Referencias.md:84`); no la reabrí | https://committee.iso.org/standard/77451.html | Cita del cuerpo (2026-10-26) | P-15 |

## 8. Excepciones a conocimientos

**Ninguna.** Ninguna posición propone dejar de seguir una convención que rige. La de P-05 respeta la precedencia del
cuerpo (`00-Marco.md` §5) y la de P-15 conserva la regla de `TEM-05`.

## 9. Solicitudes de convocatoria

| # | Señal y ubicación | Qué no puedo afirmar sin esa especialidad | A quién |
| --- | --- | --- | --- |
| SC-1 | H03: `TEM-05:100`, `:205-207`; `dg.py:686-690`; el patrón existente `mini-demo-movilidad.yml` | Si conviene un trabajo de CI que baje Lab-Geometria en un SHA fijo para la prueba de ayuda por rol, en qué carril y con qué costo | Verificación (CI y compuertas) |
| SC-2 | H04: `prefijos.txt:27`; `id-duplicado` de E3 | Si los `RD-` deben ser locales a una carpeta o a un registro (relaciona con P-04 B, N5 B2-B3) | Trazabilidad documental |
| SC-3 | H07: `App.razor:2`, `Ayuda.razor:31-35` | Cómo marcar el idioma de la parte en el componente sin romper el resto del render | Arquitectura (si la mesa lo considera necesario; la dirección del contenido ya está en H07) |

## 10. Lo no verificado

- **El mapeo página→caso de uso de P-15** (por ejemplo, «Mis trabajos» → `CU-10006` y `CU-10007`). Lo hice por título y
  por lectura parcial de los casos; lo revisa quien aplica, con la relectura.
- **Que la prueba de ayuda por rol corra hoy.** No la levanté: H07 y H09 salen de la lectura del código y de una captura
  del 2026-09-19. La «prueba de ayuda por rol levantada» figura como medio sin observar en el contrato (§8).
- **El texto normativo de ISO/IEC/IEEE 26514:2022.** No lo reabrí; uso la cita del cuerpo.
- **Si la guía *Spanish (Neutral)* tiene una edición posterior a 2021.** Seguí el enlace oficial del listado de
  Microsoft; no busqué otras.
- **Si Google tiene guía de localización al castellano.** La página consultada se ofrece traducida (menú de idiomas),
  pero no encontré una guía para escribir en castellano; lo afirmo sólo sobre esa página.

## 11. Inventario de lo creado y lo borrado

| Qué | Dónde | Estado al cerrar |
| --- | --- | --- |
| Descargas de E2-E3 de §7 (HTML, `.md`, `llms.txt`, PDF) y copias de E1-E4 de §6 (SDD de Lab-Geometria, páginas, árbol de Lab-Documentos) | Directorio de ensayos en `{dir-de-trabajo}` | **Borrado** al terminar |
| Este folio | Carpeta de la mesa del expediente 0003, `015-informe-c-doc-usr.md` | Queda |
| Contenedores | — | Ninguno |

No escribí en ningún repositorio. Sin `git` de escritura, sin pull requests.

## 12. Barrido de lo privado en este folio

| Campo | Valor |
| --- | --- |
| Comando | `grep -nIiE` sobre este archivo con: rutas de home y de la máquina de trabajo, direcciones IP, nombres de hosts y de runners del laboratorio, el nombre del servicio privado y de los proyectos privados que nombra la carta |
| Fecha | 2026-11-01 |
| Resultado | **vacío** (código de salida 1 de `grep`) |

No se nombra el servicio privado de notificaciones ni su repositorio; el proveedor público del caso de P-07 se nombra
porque ya lo nombra el cuerpo público (`TEM-01:171`, `TEM-04:105`). No llegó ningún mensaje de otra sesión ni texto a
mitad de turno que cambiara el encargo.

Sigue: refutador · análisis de decisiones · jurado
