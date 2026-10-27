# Relevamiento R3 — Reglas de documentación aplicables a la guía del framework

> Bitácora de relevamiento normativo de la corrida de `Crear-Framework-Concept.md` (workflow 1, «Fundación»).
> Fecha: 2026-10-25. Rol: relevador normativo de la documentación.
> Destino de lo que se norma acá: el conjunto documental de `/LAB/Lab-Documentos/Lab-Documentos/Concepts/Framework-Concept/`
> (`Developer-Guide.md` y lo que lo acompañe) y, por extensión, los dossiers de núcleo N1–N5.
> Este documento no decide: convierte las reglas en obligaciones comprobables y deja a la mesa las tensiones que
> encontró (§10).

## Índice

1. [Alcance, método y precedencia](#1-alcance-método-y-precedencia)
2. [Fuentes relevadas](#2-fuentes-relevadas)
3. [Cómo leer las obligaciones](#3-cómo-leer-las-obligaciones)
4. [Estructura del conjunto documental](#4-estructura-del-conjunto-documental)
5. [Forma Markdown](#5-forma-markdown)
6. [Evidencias y citas](#6-evidencias-y-citas)
7. [Voz narrativa y entrega de definiciones](#7-voz-narrativa-y-entrega-de-definiciones)
8. [Doble audiencia](#8-doble-audiencia)
9. [Indexado](#9-indexado)
10. [Convenciones de Lab-Documentos](#10-convenciones-de-lab-documentos)
11. [Herramientas de comprobación y su ensayo](#11-herramientas-de-comprobación-y-su-ensayo)
12. [Observaciones (hechos e interpretaciones)](#12-observaciones-hechos-e-interpretaciones)
13. [Plantilla de documento temático](#13-plantilla-de-documento-temático)

---

## 1. Alcance, método y precedencia

El prompt aplica el perfil `Study-Guide-Documentation`. Lo cita como `/IA/IA.Prompts/PromptFramework/Profiles/…`; la ruta
real tiene un segmento más: `/IA/PROMPTs/IA.Prompts/PromptFramework/Profiles/Study-Guide-Documentation.md` (verificado con
`ls`, ya registrado en la entrada 2 de `00-Registro.md`). El perfil remite a `RuleSet-Study-Guide`, que suma a las siete
reglas de `RuleSet-Documentation` las dos de redacción (`Rule-Dual-Audience`, `Rule-Narrative-Voice`)
(`RuleSet-Study-Guide.md:13`). El orquestador agregó como lectura el conocimiento `Knowledge-Icono-Y-Ancla`.

Método: se leyeron enteros el perfil, los dos RuleSets, las nueve reglas y el conocimiento; se tomaron como modelo de
forma dos guías de Lab-Documentos que declaran el mismo perfil —la del informe de solución
(`Guides/Despliegue/Documentacion-Informe-Despliegue/`, en adelante **IS**) y la de documentación técnica
(`Guides/Documentacion-Tecnica/Creacion-Guias-Tecnicas/`, en adelante **DT**)— y se contrastaron con el índice de
convenciones de la ia-db del repositorio. Cada obligación se ensayó, cuando era mecanizable, sobre IS y DT (§11).

Precedencia que se aplica en este relevamiento:

| Conflicto | Qué prevalece | Origen |
|---|---|---|
| Voz narrativa vs. zonas estructuradas (frontmatter, IDs, tablas, diagramas) | La regla estructural | `Rule-Narrative-Voice.md:7` y `:41` |
| Índice de la ia-db vs. evidencia | La evidencia | `Rule-Indexing.md:27` |
| `Knowledge-Icono-Y-Ancla` vs. reglas del framework | Lo dice el perfil; el perfil **no** lo nombra | `Knowledge-Icono-Y-Ancla.md:250-251`; perfil sin mención (`grep -c Icono` → 0) |
| Pedido del prompt vs. perfil | El prompt fija temática, alcance y destino; el perfil, la forma | `Study-Guide-Documentation.md:7` |

Para el tercer caso, **criterio propio** de este relevamiento: el conocimiento se adopta como consultivo (él mismo lo
declara en su §8, `:234`) y ninguna de sus obligaciones desplaza a una regla del framework.

---

## 2. Fuentes relevadas

Rutas desde la raíz del workspace.

| ID | Fuente | Qué aporta |
|---|---|---|
| PRF | `/IA/PROMPTs/IA.Prompts/PromptFramework/Profiles/Study-Guide-Documentation.md` | Ejes, piezas del conjunto, 6 apartados del documento temático, criterios de calidad |
| RS-SG | `/IA/PROMPTs/IA.Prompts/PromptFramework/RuleSets/RuleSet-Study-Guide.md` | Lista de nueve reglas |
| RS-DOC | `/IA/PROMPTs/IA.Prompts/PromptFramework/RuleSets/RuleSet-Documentation.md` | Base de siete reglas |
| R-ALL | `…/Rules/Rule-All.md` | Veracidad, alcance, transparencia, finalización |
| R-WF | `…/Rules/Rule-Workflow.md` | Ciclo y estructura del reporte |
| R-EV | `…/Rules/Rule-Evidences.md` | Marcas «No verificado», trazabilidad, observaciones |
| R-MD | `…/Rules/Rule-Markdown.md` | Encabezados, elementos, validación |
| R-DOC | `…/Rules/Rule-Documentation.md` | Estado real, procedimientos, única fuente de verdad |
| R-IDX | `…/Rules/Rule-Indexing.md` | Recuperación y sincronización de la ia-db |
| R-AG | `…/Rules/Rule-Agents.md` | Delegación (no genera obligaciones sobre el documento) |
| R-DA | `…/Rules/Rule-Dual-Audience.md` | Cara humana y cara agente |
| R-NV | `…/Rules/Rule-Narrative-Voice.md` | Voz, ritmo, muletillas |
| K-IA | `<base de conocimiento>/Knowledges/Knowledge-Icono-Y-Ancla.md` (v2.0, 2026-10-24) | Tres partes de una definición, dos pruebas, §6 criterios |
| IS | `/LAB/Lab-Documentos/Lab-Documentos/Guides/Despliegue/Documentacion-Informe-Despliegue/` | Modelo de forma 1 (30 `.md`) |
| DT | `/LAB/Lab-Documentos/Lab-Documentos/Guides/Documentacion-Tecnica/Creacion-Guias-Tecnicas/` | Modelo de forma 2 (59 `.md`) |
| NET | `/LAB/Lab-Documentos/Lab-Documentos/Guides/Dot-NET-Arquitectura-Guide/Dot-NET-Arquitectura-Guide.md` | Modelo de guía de un solo archivo con `version` y CHANGELOG |
| CHL | `/LAB/Lab-Documentos/Lab-Documentos/CHANGELOG.md` | Formato de registro de versiones |
| IDB | `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/ia-db/` (`README.md`, `indexes/10_Convenciones-y-Glosario.md`) | Convenciones relevadas sobre los 295 `.md` |

---

## 3. Cómo leer las obligaciones

Cada obligación lleva un ID estable `OB-<grupo>-nn`, su origen como `fuente:línea` (o `fuente §sección`), el modo de
comprobación y su tipo:

- **[E] enumerable**: se comprueba con un comando; los `V-nn` remiten a las comprobaciones del §11.
- **[I] interpretativo**: requiere lectura; se indica qué buscar.

Las marcadas **(criterio propio)** no salen de una regla: son la forma que este relevamiento propone para cumplir una
regla abierta, y la mesa puede cambiarlas.

---

## 4. Estructura del conjunto documental

### 4.1 Piezas del conjunto

| ID | Obligación | Origen | Cómo se comprueba | Tipo |
|---|---|---|---|---|
| OB-EST-01 | Existe un **README** con la tabla de contenido de todo lo generado y la **ruta de lectura sugerida** | PRF:50, PRF:85 | `test -s README.md`; todo `.md` del conjunto aparece enlazado desde el README: `comm -23 <(find . -name '*.md' ! -name README.md \| sed 's#^\./##' \| sort) <(grep -o '](\([^)#]*\.md\)' README.md \| sed 's/](//' \| sort -u)` debe salir vacío (en IS los temas se enlazan desde el README raíz) | E |
| OB-EST-02 | Existe un **mapa conceptual** con tablas de entrada por escenario, por contexto y por artefacto («estoy acá → qué aplico») | PRF:46 | `grep -c '^## ' 01-Mapa-Conceptual/Mapa-Conceptual.md` ≥ 3 y encabezados «Por escenario», «Por contexto», «Por artefacto» | E+I |
| OB-EST-03 | Los tres **ejes** (escenarios, contextos, actores) se definen **una sola vez, en documentos propios**, y el resto los referencia | PRF:33, PRF:45 | `ls 00-Marco-de-Referencia/{Escenarios,Contextos,Actores}.md`; las definiciones (`### \`ESC-`) sólo aparecen en su archivo: `grep -rl '^### .ESC-' . ` → un archivo | E |
| OB-EST-04 | Cada documento temático se cruza con al menos un escenario o contexto; si no, sobra o está mal delimitado | PRF:33 | `grep -L 'ESC-\|CTX-' $(grep -l '^doc_type: tema' -r .)` debe salir vacío | E |
| OB-EST-05 | **Un documento por unidad temática**, todos con la misma estructura interna | PRF:47, R-DOC:29 | V-03 | E |
| OB-EST-06 | Documento de **métodos y marcos**: enfoques alternativos, en qué difieren, criterios para elegir (para esta guía: opciones de contenido A/B/C del borrador, estrategias de rama y versionado) | PRF:48 | Existe al menos un tema con tabla comparativa y sección de criterios de elección | I |
| OB-EST-07 | **Anexos**: plantillas comentadas, listas de verificación y **glosario** | PRF:49 | `ls 99-Anexos/{Glosario,Lista-de-Verificacion,Plantillas}.md` (nombres de IS/OEP; ver OB-LAB-02) | E |
| OB-EST-08 | Orden de lo general a lo particular: mapa → ejes → temas → anexos | PRF:35 | Prefijos numéricos de carpeta crecientes en ese orden (`00-`, `01-`, `10-`…`90-`, `99-`) | E |
| OB-EST-09 | **Interconectado**: cada documento enlaza al que lo precede y al que lo continúa; ninguno queda huérfano del mapa | PRF:72 | Todo `doc_id` del conjunto figura en los `traces` del mapa o del README: `comm -23 <(grep -h '^doc_id:' -r . \| sort -u) <(grep -h '^traces:' README.md 01-Mapa-Conceptual/*.md \| tr ',[]' '\n' \| sed 's/traces://;s/ //g' \| sed 's/^/doc_id: /' \| sort -u)` | E |
| OB-EST-10 | **Verificación de cierre**: revisar la guía completa contra el mapa buscando huecos, solapamientos y contradicciones, y corregir | PRF:73, R-ALL:46 | Existe un anexo de revisión de consistencia (DT lo tiene: `99-Anexos/Revision-de-Consistencia.md`) con fecha y hallazgos | I |
| OB-EST-11 | La documentación es **autocontenida y no delta**, con índices | Prompt §Reglas, viñeta 1 | Ningún documento remite a «la versión anterior» para entenderse; V-12 (índice) | I+E |
| OB-EST-12 | Diagramas típicos presentes cuando aportan: mapa del dominio, escenarios ↔ artefactos, flujos por rol, líneas de tiempo, taxonomías | PRF:79 | `grep -c '```mermaid' -r .` > 0 en mapa y en los temas de flujo | E+I |

### 4.2 Apartados del documento temático

El perfil fija seis apartados (PRF:58-63); `Rule-Dual-Audience` agrega un **resumen ejecutivo** al comienzo (R-DA:11).
IS y DT los numeran como siete secciones (IS `Convenciones.md` §Estructura de un documento temático; IDB
`10_Convenciones-y-Glosario.md` §4).

| ID | Apartado | Qué debe contener | Origen | Cómo se comprueba | Tipo |
|---|---|---|---|---|---|
| OB-TEM-00 | Resumen ejecutivo | Qué es, para qué sirve, a quién le sirve; prosa, no viñetas | R-DA:11 | V-03 | E |
| OB-TEM-01 | Definición | Qué es, qué problema resuelve, **qué no es** (y con qué se confunde) | PRF:58 | V-03 + subtítulos «Qué es», «Qué problema resuelve», «Qué NO es» | E |
| OB-TEM-02 | Aplicación por escenario | Qué aporta en **cada** escenario del marco y qué cambia según el contexto; la fila de un escenario que no aplica se conserva y se explica | PRF:59; IS `Convenciones.md` §Estructura (criterio heredado) | V-03; cantidad de `### \`ESC-` igual a la cantidad de escenarios del marco | E |
| OB-TEM-03 | Ejemplos concretos | Casos reales del dominio, no descripciones abstractas; los ilustrativos se rotulan | PRF:60, R-MD:32 | V-03; I: cada ejemplo dice qué demuestra, precondición, resultado (R-DA:15) | E+I |
| OB-TEM-04 | Preguntas guía | Las que el lector debe poder responder para producir o evaluar el artefacto | PRF:61, R-DA:14 | V-03; al menos una lista numerada bajo el encabezado | E |
| OB-TEM-05 | Criterios de calidad | Cómo se distingue una versión buena de una pobre (con antipatrones) | PRF:62 | V-03 + subtítulos «bueno»/«pobre» | E |
| OB-TEM-06 | Anexo | Plantilla comentada con las preguntas que guían cada campo | PRF:63 | V-03; bloque de plantilla con comentarios por campo | E+I |

Variantes admitidas: IS declara una sola desviación —la familia de redacción reemplaza «Ejemplos concretos» por «frases
de referencia» (IS `00-Marco-de-Referencia/Convenciones.md:78-80`)—. **Criterio propio**: toda variante que la guía del
framework necesite (por ejemplo, un tema procedimental de PR) se declara en su `Convenciones.md` antes de usarse, y V-03 la
exceptúa por nombre.

---

## 5. Forma Markdown

| ID | Obligación | Origen | Cómo se comprueba | Tipo |
|---|---|---|---|---|
| OB-MD-01 | Encabezados jerárquicos **sin saltar niveles**; un solo H1 | R-MD:11 | V-04 | E |
| OB-MD-02 | **Sin secciones vacías ni decorativas** | R-MD:13, R-MD:39 | V-06 | E |
| OB-MD-03 | **Sin títulos duplicados** | R-MD:39 | V-05 (ver observación H-07) | E |
| OB-MD-04 | **Tabla de contenidos** cuando el tamaño lo justifique; el prompt la exige siempre («Debe tener índices») | R-MD:12; Prompt §Reglas | V-12 | E |
| OB-MD-05 | Bloques de código **con lenguaje indicado**, mínimos y con contexto | R-MD:30 | V-07 | E |
| OB-MD-06 | Diagramas en **Mermaid** (preferido sobre ASCII) y **sintácticamente correctos** | R-MD:31, R-MD:39, R-DA:24 | V-10 | E |
| OB-MD-07 | Tablas para resumir o comparar, **sin celdas de texto largo** | R-MD:29 | (criterio propio) celdas > 300 caracteres: `grep -n '^|' -r . \| awk -F'\|' '{for(i=2;i<NF;i++) if(length($i)>300){print FILENAME": "$0; break}}'` | E+I |
| OB-MD-08 | **Enlaces válidos**, con **rutas relativas** entre documentos relacionados | R-MD:33, R-MD:39 | V-11 | E |
| OB-MD-09 | Referenciar en lugar de duplicar | R-MD:33, R-DOC:28 | I: un mismo concepto se desarrolla en un documento; `grep -rl '<frase definitoria>'` sobre términos del glosario → un archivo | E+I |
| OB-MD-10 | Comprensible sin información externa innecesaria | R-MD:39, R-DOC:15 | I: un lector que sólo tiene el conjunto puede seguir cada tema | I |
| OB-MD-11 | Misma estructura, terminología y estilo en todo el conjunto | R-MD:21 | V-03 + glosario único | E+I |
| OB-MD-12 | Sin rutas del host en los documentos finales | Orquestador (contexto común) | V-08 | E |

---

## 6. Evidencias y citas

| ID | Obligación | Origen | Cómo se comprueba | Tipo |
|---|---|---|---|---|
| OB-EV-01 | **No inventar**; toda afirmación respaldada en evidencia, documentación o datos del usuario | R-ALL:19, Prompt §Reglas | I: muestreo de afirmaciones contra `Referencias.md` | I |
| OB-EV-02 | Lo no verificado se marca: «No verificado», «Requiere verificación manual», «Información no disponible»; el orquestador fija **«NO VERIFICADO» con el motivo** | R-EV:11; contexto común | `grep -rn 'NO VERIFICADO' . \| grep -v -- '—\|:'` debe salir vacío (toda marca lleva motivo) | E |
| OB-EV-03 | Trazabilidad por tipo de fuente: comando (comando, propósito, resultado), archivo (ruta y elemento), documentación (referencia y **fecha de obtención**) | R-EV:21-25 | Cada fila de `99-Anexos/Referencias.md` tiene columna de fecha AAAA-MM-DD: `grep '^| ' Referencias.md \| grep -vc '20[0-9][0-9]-[01][0-9]-[0-3][0-9]'` → sólo encabezados | E |
| OB-EV-04 | Lo que es **criterio propio** se declara como tal | PRF:70, contexto común; IS `Convenciones.md:93` («esta guía recomienda») | `grep -rc 'esta guía recomienda\|Criterio de esta guía' .` > 0 en temas con recomendaciones; I: ninguna recomendación sin esa marca | E+I |
| OB-EV-05 | **Niveles de autoridad**: normativo / marco de organización / convención de facto / criterio propio, explícitos en el texto, con catálogo `N-/G-/F-/O-/P-` | IS `Convenciones.md` §Los cuatro niveles; IDB `10_…` §3.1 (convención del corpus, no regla del framework) | Toda cita `N-xx`/`G-xx`/… resuelve a una fila de `Referencias.md`: `comm -23 <(grep -rhoE '\b[NGFOP]-[0-9]{2}\b' . \| sort -u) <(grep -oE '^\| `?[NGFOP]-[0-9]{2}' 99-Anexos/Referencias.md \| grep -oE '[NGFOP]-[0-9]{2}' \| sort -u)` vacío | E |
| OB-EV-06 | Las conclusiones surgen de las evidencias; no omitir ni reinterpretar evidencia | R-EV:12 | I | I |
| OB-EV-07 | Ejemplos **reales, obtenidos en la ejecución**; los ilustrativos se marcan | R-MD:32, R-DOC:11 | Los fragmentos de la demo citan ruta + rango + versión (OB-DA-06); `grep -rn 'ilustrativo' .` en los no ejecutados | E+I |
| OB-EV-08 | Sección de **observaciones** que diferencia hechos de interpretaciones | R-EV:33 | `grep -l '^## .*Observaciones' -r .` en documentos con hallazgos | E |
| OB-EV-09 | **Cita de un mecanismo**: texto de la fuente + qué implica para quien diseña + código que lo materializa; una cita va sola sólo si habla del método de la guía | K-IA §6 (`:204-205`); misma norma en NET §0.5 y CHL:26 | I: cada bloque `>` de cita externa va seguido de explicación y de un bloque de código o remite a la demo | I |
| OB-EV-10 | Normas y documentación citadas por designación exacta y año/versión; fecha de consulta en lo volátil (versiones de .NET, políticas de tiendas) | IS `Convenciones.md` §Trazabilidad y fuentes; NET Anexo C | I + OB-EV-03 | I |
| OB-EV-11 | Limitaciones, decisiones y supuestos descartados quedan escritos | R-ALL:34, R-EV:39 | Anexo «Pendientes» (IS `99-Anexos/Pendientes.md`) | E |

---

## 7. Voz narrativa y entrega de definiciones

### 7.1 Voz

| ID | Obligación | Origen | Cómo se comprueba | Tipo |
|---|---|---|---|---|
| OB-VOZ-01 | Sin muletillas: «Es importante destacar/señalar/mencionar que», «Cabe destacar», «En resumen», «En conclusión», «Como se puede observar», «Vale la pena mencionar» | R-NV:30 | V-09 (candidatos; descartar las que aparecen citadas como contraejemplo) | E+I |
| OB-VOZ-02 | Sin conectores decorativos encadenados («Además», «Asimismo», «Por otro lado», «Por consiguiente») | R-NV:31 | (criterio propio) densidad: `grep -oicE '\b(además|asimismo|por otro lado|por consiguiente)\b' archivo` por cada 100 líneas; revisar los > 3 | E+I |
| OB-VOZ-03 | Ninguna sección abre reformulando su título ni anunciando lo que «va a» tratar | R-NV:24, R-NV:33 | `grep -n -A2 '^## ' archivo \| grep -iE 'en esta sección|a continuación se|este apartado'` vacío; resto I | E+I |
| OB-VOZ-04 | Longitud de frase variada; prosa donde corresponde prosa; listas sólo para enumeraciones reales | R-NV:21-22 | I | I |
| OB-VOZ-05 | Sin paralelismo forzado en viñetas | R-NV:23 | I | I |
| OB-VOZ-06 | Cierres que aportan algo; ningún párrafo borrable sin pérdida | R-NV:32, R-NV:47 | I | I |
| OB-VOZ-07 | Una sola voz en todo el conjunto | R-NV:40, PRF:71 | I | I |
| OB-VOZ-08 | Español rioplatense neutro, sin voseo exagerado; términos técnicos con designación inglesa establecida se mantienen y van al glosario | Contexto común; IS `Convenciones.md` §Idioma | I; términos en cursiva presentes en `Glosario.md` | E+I |
| OB-VOZ-09 | Estilo técnico, claro y didáctico; sin texto telegráfico ni comandos sin contexto | R-MD:19 | I | I |

### 7.2 Definiciones (Icono y ancla)

| ID | Obligación | Origen | Cómo se comprueba | Tipo |
|---|---|---|---|---|
| OB-DEF-01 | Toda definición pasa la **prueba de la operación**: se puede nombrar el verbo de acción que ejecuta el lector | K-IA:201-202 | I: anotar el verbo junto a cada definición; donde no hay verbo, es icono | I |
| OB-DEF-02 | Toda definición lleva **texto + operación + escena** (esqueleto de K-IA §5), o declara cuál falta y por qué | K-IA:203, K-IA:170-178 | (criterio propio) definiciones con el esqueleto: `grep -c '^\*\*Cómo se aplica\.\*\*' archivo` = `grep -c '^\*\*Un caso\.\*\*' archivo` | E+I |
| OB-DEF-03 | Las escenas varían: ninguna se repite en más de dos definiciones del mismo documento | K-IA:206 | I | I |
| OB-DEF-04 | Si la operación no se puede reconstruir, la definición se **rotula como orientación**, no se simula | K-IA:208-209, D-3 | `grep -n 'orientación' archivo` en esas definiciones | E+I |
| OB-DEF-05 | Al resumir para entrar en un techo, se audita qué operaciones se cayeron | K-IA:210-211 | I: entrada en el CHANGELOG o en Pendientes | I |
| OB-DEF-06 | Cada término se define en su primer uso y se registra en el glosario (término canónico, definición, alias, fuente) | R-DA:13, R-DA:33; IS `99-Anexos/Glosario.md` | Cada término en negrita definido en un tema figura como fila del glosario | E+I |

---

## 8. Doble audiencia

| ID | Obligación | Origen | Cómo se comprueba | Tipo |
|---|---|---|---|---|
| OB-DA-01 | **Frontmatter YAML** en todo documento: `doc_id`, `doc_type`, `title`, `status`, `origin`, `confidence` (si `origin != human`), `owner`, `last_review`, `audience`, `traces` | R-DA:21 | V-01, V-02 | E |
| OB-DA-02 | **IDs estables con prefijo**; los enlaces y las trazas apuntan al ID, no a la ruta | R-DA:22 | Todo enlace interno muestra el ID entre backticks (patrón de IS): `grep -rhoE '\[`[A-Z]+-[A-Z0-9-]+`\]\(' .` ; `doc_id` únicos: `grep -rh '^doc_id:' . \| sort \| uniq -d` vacío | E |
| OB-DA-03 | Encabezados y anclas **predecibles**: los documentos del mismo tipo comparten secciones | R-DA:23 | V-03 | E |
| OB-DA-04 | Diagramas y modelos **como código** (Mermaid); binarios sólo sin alternativa | R-DA:24 | `find . -name '*.png' -o -name '*.jpg'` justificado en el texto | E+I |
| OB-DA-05 | **Bloques para agentes** (`entradas` / `salidas` / `validaciones`) en documentos que definen un proceso que un agente debe ejecutar o verificar — aplica a los procedimientos de PR, integración, versionado y publicación de actualizaciones | R-DA:25 | `grep -l '^### Entradas\|^### Salidas\|^### Validaciones' -r .` incluye cada tema procedimental | E |
| OB-DA-06 | **Snippets con procedencia** (ruta + rango + versión de la fuente); nunca copias sin origen | R-DA:26 | Línea de procedencia bajo cada bloque de código tomado de la demo: (criterio propio) formato `*Fuente: \`Demo/<ruta>\` L<a>–L<b>, <commit o versión>*`; `grep -c '^\*Fuente: ' archivo` ≥ bloques tomados de la demo | E+I |
| OB-DA-07 | Flujos importantes **narrados de punta a punta con un caso concreto**, datos sintéticos realistas; la narración complementa al diagrama | R-DA:12 | I: el flujo «el usuario abre la app → descarga actualización → aplica o revierte» narrado con un caso | I |
| OB-DA-08 | Ejemplos y snippets contextualizados: qué demuestran, precondiciones, resultado esperado | R-DA:15 | I | I |
| OB-DA-09 | Las dos caras describen el mismo hecho; vocabulario narrativo y máquina-legible comparten glosario; sinónimos como alias del término canónico | R-DA:32-33 | Columna «Alias» en el glosario | E+I |
| OB-DA-10 | Preguntas guía al cierre de las secciones densas | R-DA:14 | Coincide con OB-TEM-04 | E |

---

## 9. Indexado

| ID | Obligación | Origen | Cómo se comprueba | Tipo |
|---|---|---|---|---|
| OB-IDX-01 | Antes de trabajar, recuperar contexto desde la ia-db: punto de entrada → índice relevante → fuentes sólo ante insuficiencia | R-IDX:13-18, R-WF:15 | La ia-db de Lab-Documentos está en `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/ia-db/README.md` (resuelta por búsqueda, R-IDX:7); los índices pertinentes son `08_Ramas-CI-CD-y-DevOps.md`, `07_Testing-E2E.md` y `10_Convenciones-y-Glosario.md` | E |
| OB-IDX-02 | Si la ejecución genera documentos nuevos o relaciones, **actualizar la ia-db antes de finalizar**, de forma incremental | R-IDX:26, R-IDX:28 | `grep -rl 'Framework-Concept' …/ia-db/` no vacío al cierre (hoy vacío: H-05) | E |
| OB-IDX-03 | Si la evidencia contradice el índice, corregir el índice | R-IDX:27 | I | I |
| OB-IDX-04 | No duplicar conocimiento entre índices | R-IDX:29 | I | I |

---

## 10. Convenciones de Lab-Documentos

Lo que sigue no es regla del framework: es la forma que el repositorio ya usa (convención de facto, relevada) y que el
conjunto nuevo debería seguir para «percibirse como una única obra» (R-MD:21).

### 10.1 Estructura y nombres

| ID | Convención | Evidencia | Cómo se comprueba | Tipo |
|---|---|---|---|---|
| OB-LAB-01 | Carpetas con **prefijo numérico de dos dígitos** + nombre en Title-Case con guiones: `00-Marco-de-Referencia`, `01-Mapa-Conceptual`, familias `10-`…`90-`, `95-Transversales`, `99-Anexos` | `find Guides -type d -regex '.*/[0-9][0-9]-.*'`: `00-Marco-de-Referencia` ×4, `99-Anexos` ×4, `01-Mapa-Conceptual` ×3, `95-Transversales` ×2 | `find . -mindepth 1 -maxdepth 1 -type d ! -regex './[0-9][0-9]-[A-Za-z0-9-]*' ! -name Demo` vacío | E |
| OB-LAB-02 | Archivos `.md` en **Title-Case con guiones, sin espacios ni acentos ni ñ**; nombres de marco fijos: `Escenarios.md`, `Contextos.md`, `Actores.md`, `Convenciones.md`, `Mapa-Conceptual.md`, `Glosario.md`, `Referencias.md`, `Lista-de-Verificacion.md`, `Plantillas.md`, `Pendientes.md`; un `README.md` por familia | Árbol de IS y de OEP; excepciones en el repo: 2 con espacio y 1 con ñ (H-08) | `find . -name '*.md' \| grep -P '[^\x00-\x7F]\| '` vacío | E |
| OB-LAB-03 | Prefijos de `doc_id` de las guías estructuradas: `GUIA-INDICE`, `MARCO-*`, `MAPA-CONCEPTUAL`, `FAM-*`, `TEM-*`, `ANEXO-*`; ejes `ESC-n`, `CTX-n`, `ACT-nn` | IS `Convenciones.md` §Identificadores | `grep -rh '^doc_id:' . \| grep -vE '(GUIA|MARCO|MAPA|FAM|TEM|ANEXO)-'` vacío | E |
| OB-LAB-04 | Los prefijos de marco **colisionan entre guías** (`ESC-2` significa otra cosa en cada una): al citar un eje de otra guía, nombrar la guía | IDB `10_…` §5 | I | I |
| OB-LAB-05 | Valores de frontmatter normados: `doc_type: tema \| marco-de-referencia \| familia \| mapa \| anexo \| indice`; `status: vigente \| borrador \| obsoleto`; `origin: human \| ia-assisted \| ia-generated`; `audience: [humano, agente]` | IS `Convenciones.md` §Frontmatter obligatorio; en la práctica conviven `ia-assisted` ×184, `agente` ×19, `ai-assisted` ×3, `agent` ×1 (`grep -rh '^origin:'`) | `grep -rh '^origin:' . \| sort -u` ⊆ valores normados | E |

### 10.2 Versión y CHANGELOG

| ID | Convención | Evidencia | Cómo se comprueba | Tipo |
|---|---|---|---|---|
| OB-LAB-06 | Las guías **de un solo archivo** llevan `version:` SemVer en el frontmatter (NET `2.5.0`); las **multiarchivo** no tienen versión y su vigencia se lee en `last_review` | NET:5; IDB `10_…` §1.1 («El bloque no prevé `version`») | `grep -h '^version:' Developer-Guide.md` | E |
| OB-LAB-07 | Cada versión publicada se registra en `/LAB/Lab-Documentos/Lab-Documentos/CHANGELOG.md`, formato **Keep a Changelog 1.1.0 (es-ES)**: `## AAAA-MM-DD (motivo)` → `### <ruta> — vX.Y.Z` → `#### Añadido / Cambiado / Corregido / Eliminado`; el repositorio agrega `#### Deuda declarada` | CHL:3; recuento de `####`: Añadido 8, Cambiado 8, Corregido 1, Eliminado 1, Deuda declarada 1 | `grep -n "Concepts/Framework-Concept" CHANGELOG.md` no vacío al publicar | E |
| OB-LAB-08 | Un cambio de ubicación también se registra (precedente: «reubicación» de Git-Flow-Guides) | CHL:7-11 | I | I |

**Propuesta para el conjunto del framework (criterio propio, a decidir por la mesa).** `Developer-Guide.md` es el punto
de entrada que fija el prompt; si el conjunto se arma en varias carpetas, `Developer-Guide.md` cumple el papel de README
(`doc_type: indice`, `doc_id: GUIA-INDICE`) y lleva `version:` SemVer, porque el prompt pide versionado del producto y la
guía documenta un producto que cambia. La entrada del CHANGELOG raíz queda fuera de la ruta que el prompt autoriza
(«Toda la documentación generarla en … Framework-Concept»): ver H-04.

---

## 11. Herramientas de comprobación y su ensayo

### 11.1 Comprobaciones `V-nn`

| ID | Qué comprueba | Cómo |
|---|---|---|
| V-01 | Frontmatter presente y con los nueve campos fijos | `verificar.sh` |
| V-02 | `confidence` cuando `origin != human` | `verificar.sh` |
| V-03 | Siete encabezados `##` del documento temático (`doc_type: tema`) | `verificar.sh` |
| V-04 | Un solo H1 y sin saltos de nivel | `verificar.sh` |
| V-05 | Títulos duplicados en un documento | `verificar.sh` |
| V-06 | Secciones vacías (encabezado seguido, sin texto ni bloque, de otro de igual o mayor jerarquía) | `verificar.sh` |
| V-07 | Bloque de código sin lenguaje | `verificar.sh` |
| V-08 | Rutas del host (`/home/`) | `verificar.sh` |
| V-09 | Candidatos a muletilla (revisión manual) | `verificar.sh` |
| V-10 | Sintaxis Mermaid | `mermaid.sh` (mermaid-cli 12.0.0 en contenedor) |
| V-11 | Enlaces rotos | `markdown-link-check` 3.13.7 en contenedor `node:22-alpine` |
| V-12 | Índice al comienzo | `grep -m1 -n '^## Índice\|^## Tabla de contenido' archivo` con línea < 40 en documentos > 150 líneas (umbral: criterio propio) |

`markdownlint-cli2` y `markdown-link-check` **no están instalados** en el host (`npx --no-install` → «npx canceled due to
missing packages»); se usan en contenedor. Las imágenes `node:22-alpine` y `minlag/mermaid-cli:latest` están locales
(`docker images`).

### 11.2 `verificar.sh` (V-01 a V-09)

```bash
#!/usr/bin/env bash
# Uso: verificar.sh <carpeta-de-la-guia>
D="${1:?carpeta}"; cd "$D" || exit 2
mapfile -t MD < <(find . -name '*.md' -not -path '*/Demo/*' | sort)
falla(){ echo "FALLA $1"; }
for x in "${MD[@]}"; do
  head -1 "$x" | grep -qx -- '---' || { falla "V-01 sin frontmatter: $x"; continue; }
  fm=$(awk 'NR==1{next} /^---$/{exit} {print}' "$x")
  for k in doc_id doc_type title status origin owner last_review audience traces; do
    grep -q "^$k:" <<<"$fm" || falla "V-01 falta $k: $x"; done
  grep -q '^origin: human' <<<"$fm" || grep -q '^confidence:' <<<"$fm" || falla "V-02 falta confidence: $x"
  if grep -qx 'doc_type: tema' <<<"$fm"; then
    for s in 'Resumen ejecutivo' 'Definición' 'Aplicación por escenario' 'Ejemplos concretos' 'Preguntas guía' 'Criterios de calidad' 'Anexo'; do
      grep -Eq "^## ([0-9]+\. )?$s" "$x" || falla "V-03 falta «$s»: $x"; done
  fi
  body=$(awk 'NR==1&&/^---$/{fm=1;next} fm&&/^---$/{fm=0;next} fm{next} /^```/{c=!c; if(c) print "[bloque]"; next} !c{print}' "$x")
  [ "$(grep -c '^# ' <<<"$body")" -eq 1 ] || falla "V-04 H1 != 1: $x"
  awk -v F="$x" '/^#+ /{n=length($1); if(p && n>p+1) print "FALLA V-04 salto H"p"->H"n": "F": "$0; p=n}' <<<"$body"
  grep '^#' <<<"$body" | sort | uniq -d | sed "s|^|FALLA V-05 título duplicado ($x): |"
  awk -v F="$x" '/^#+ /{n=length($1); if(h!="" && !t && n<=hn) print "FALLA V-06 sección vacía: "F": "h; h=$0; hn=n; t=0; next} NF && !/^---$/{t=1} END{if(h!="" && !t) print "FALLA V-06 sección vacía al final: "F": "h}' <<<"$body"
  awk -v F="$x" '/^```/{ if(!c && $0=="```") print "FALLA V-07 bloque sin lenguaje: "F":"NR; c=!c }' "$x"
  grep -n '/home/' "$x" | sed "s|^|FALLA V-08 ruta del host: $x:|"
  grep -n -i -E 'es importante (destacar|señalar|mencionar)|cabe destacar|en resumen,|en conclusión|como se puede observar|vale la pena mencionar' <<<"$body" | sed "s|^|REVISAR V-09 muletilla ($x): |"
done
echo "Documentos: ${#MD[@]}"
```

### 11.3 `mermaid.sh` (V-10) y comprobación de enlaces (V-11)

```bash
#!/usr/bin/env bash
# Uso: mermaid.sh <carpeta-de-la-guia> — extrae cada bloque mermaid y lo renderiza con mermaid-cli
D="$(cd "${1:?carpeta}" && pwd)"; T=$(mktemp -d -p "${TMPDIR:-/tmp}"); n=0
while IFS= read -r f; do
  awk -v out="$T" -v base="$(echo "$f" | sed "s#^$D/##" | tr "/." "__")" '/^```mermaid/{c=1;i++;fn=out"/"base"__"i".mmd";next} c&&/^```/{c=0;next} c{print > fn}' "$f"
done < <(find "$D" -name "*.md" | sort)
chmod -R a+rwx "$T"
for m in "$T"/*.mmd; do n=$((n+1))
  docker run --rm -u "$(id -u):$(id -g)" -v "$T":/data minlag/mermaid-cli:latest -q -i "/data/$(basename "$m")" -o "/data/$(basename "$m").svg" >/dev/null 2>"$m.err" || echo "FALLA V-10 mermaid: $(basename "$m")"
done; echo "Bloques mermaid: $n"; rm -rf "$T"
```

```bash
# V-11: montar la raíz del repositorio (no sólo la guía), para que los enlaces relativos que salen de la carpeta resuelvan
R=<raíz de Lab-Documentos>; G=Concepts/Framework-Concept
docker run --rm -v "$R":/w:ro -w "/w/$G" node:22-alpine \
  sh -c 'find . -name "*.md" -not -path "./Demo/*" | xargs npx -y markdown-link-check@3.13.7 -q'
```

Los dos scripts se guardaron durante el ensayo en el scratchpad de la sesión; la copia canónica es la de este documento.

### 11.4 Ensayo sobre las guías modelo (2026-10-25)

| Comprobación | IS (30 `.md`) | DT (59 `.md`) | Lectura |
|---|---|---|---|
| V-01/V-02 | 0 fallas (los diez campos en 30/30) | 0 fallas | Frontmatter completo en ambas |
| V-03 | 3 fallas: «Ejemplos concretos» en `50-Redaccion/{Criterio-de-Redaccion,Errores-Frecuentes,Estructura-del-Documento}.md` | 7 fallas (p. ej. `40-Diseno/API-Specification.md`, `50-Operativa/Runbook.md`) | En IS son la variante declarada (`Convenciones.md:78-80`): la comprobación funciona y la excepción debe nombrarse. En DT son desvíos (coincide con IDB `10_…` §4) |
| V-04 | 0 | 0 | — |
| V-05 | 0 | 11 (p. ej. `### Definición` repetido en `00-Marco-de-Referencia/Escenarios.md`, uno por escenario) | Ver H-07 |
| V-06 | 0 | 0 | La primera versión de V-06 daba falsos positivos (encabezado seguido de subencabezado, o sección con sólo un bloque); corregida |
| V-07 | 4 (`50-Redaccion/Estructura-del-Documento.md:133,143,168,178`) | 12 | Bloques de plantilla sin lenguaje: usar `text` o `markdown` |
| V-09 | 2 candidatos en `50-Redaccion/Criterio-de-Redaccion.md:62,163` | 0 | Falsos positivos: las muletillas aparecen **citadas** como contraejemplo. Por eso V-09 es «REVISAR», no «FALLA» |
| V-10 | 23 bloques; 1 falla: `30-Despliegue/Operacion-y-Resiliencia.md`, primer bloque (`sequenceDiagram`), «Parse error on line 20 … Wrk->>FS: HEAD · consulta offset actual» | no corrido | Mermaid-cli 12.0.0 rechaza el bloque. **NO VERIFICADO** si el renderizador de GitHub lo acepta: no se probó |
| V-11 | `README.md`: 1 enlace roto (`../Documentacion-Tecnica/README.md`); `00-Marco-de-Referencia/Convenciones.md`: 6 rotos (5 a la guía hermana, 1 a `Rule-Narrative-Voice.md` fuera del repositorio) | no corrido | Ver H-03 |

---

## 12. Observaciones (hechos e interpretaciones)

| ID | Hecho | Evidencia | Interpretación / impacto |
|---|---|---|---|
| H-01 | El prompt cita el perfil sin el segmento `PROMPTs/` | Prompt §Framework; `ls /IA/PROMPTs/IA.Prompts/PromptFramework/Profiles/` | Las referencias a reglas desde la guía deben usar la ruta real |
| H-02 | `README.md` raíz de Lab-Documentos y `Guides/README.md` están **vacíos** (0 bytes) | `wc -c` → `0 README.md`, `0 Guides/README.md` | No hay convención de README de repositorio que copiar; el modelo de README es el de cada guía (IS `README.md`: resumen, cómo usar, tabla de contenido con ID, ruta de lectura con Mermaid, rutas por rol, alcance y límites, estado y verificación) |
| H-03 | IS tiene enlaces rotos tras la reorganización de `Guides/` por categoría (commit `9162e07`, 2026-09-28): `../Documentacion-Tecnica/` ya no es hermana | V-11; `ls Guides/Despliegue/Documentacion-Tecnica` → «No existe» | El ensayo confirma que OB-MD-08 hay que correrla siempre. Los enlaces a reglas del framework (fuera del repositorio) se rompen por diseño: **criterio propio**, citar recursos de fuera del repositorio con su ruta desde la raíz del workspace en `código`, no como enlace |
| H-04 | El `CHANGELOG.md` raíz termina en 2026-09-21; no registra la v2.5.0 de NET (commit `8218f97`, 2026-09-26) ni la reorganización de `Guides/` (`9162e07`, 2026-09-28) | `git log --format='%h %ad'` del repositorio y del `CHANGELOG.md` | La convención existe pero no se cumple al día. Además, escribir en el CHANGELOG raíz sale de la ruta que el prompt autoriza: **decisión para la mesa** |
| H-05 | `Concepts/` es una carpeta **sin seguimiento** en git y la ia-db no la menciona | `git status --short` → `?? Concepts/`; `grep -rl 'Framework-Concept' ia-db` vacío | OB-IDX-02 queda pendiente para el cierre de la corrida |
| H-06 | `Developer-Guide.md` existe vacío (0 líneas); el prompt pide «una guía» en ese archivo y el perfil pide un **conjunto documental** con README, ejes, temas y anexos | `wc -l`; PRF:39-50 | Dos lecturas posibles: guía de un archivo con secciones-tema (modelo NET) o conjunto multiarchivo con `Developer-Guide.md` como índice (modelo IS). **Decisión para la mesa**; la propuesta del §10.2 es criterio propio |
| H-07 | `Rule-Markdown` prohíbe títulos duplicados (R-MD:39) y DT repite subtítulos bajo padres distintos (`### Definición` por escenario) | V-05 en DT | **Criterio propio**: desambiguar con el ID (`### \`ESC-1\` — Definición`), lo que además vuelve únicas las anclas |
| H-08 | En `Guides/` hay nombres con espacio y con ñ: `IA/SDD-Guide/Spec-Driven Development-SDD.md`, `Metodologia-Agiles/Scrum-Guide/ Metodologias-Agiles-Jira-Guide.md`, `…/Actividad-3-Diseñar-Modelo-De-Dominio.md` | `find Guides -name '* *'`; `grep -P '[^\x00-\x7F]'` | Son excepciones; la convención dominante es ASCII con guiones (OB-LAB-02) |
| H-09 | `origin` tiene cuatro grafías en el repositorio | §10.1 OB-LAB-05 | Usar sólo los valores normados de IS/DT |
| H-10 | El perfil no nombra `Knowledge-Icono-Y-Ancla`; el conocimiento dice que la precedencia la fija el perfil | K-IA:250-251 | Se adoptó como consultivo (§1) |
| H-11 | `Rule-Agents` no impone obligaciones sobre el documento | R-AG completo | No genera filas en este relevamiento |

---

## 13. Plantilla de documento temático

Lista para copiar. Los comentarios `<!-- -->` dicen qué pregunta responde cada campo y se borran al completar. Los IDs
`ESC-n`, `CTX-n` y `ACT-nn` son marcadores: se reemplazan por los del marco de referencia de la guía.

````markdown
---
doc_id: TEM-XXX                      # ID estable con prefijo TEM- (OB-DA-02); único en la guía
doc_type: tema
title: <Nombre del tema>
status: borrador                     # vigente | borrador | obsoleto
origin: ia-assisted                  # human | ia-assisted | ia-generated
confidence: media                    # alta | media | baja — obligatorio si origin != human
owner: <Guía o actor responsable>
last_review: AAAA-MM-DD
audience: [humano, agente]
traces: [FAM-XXX, MARCO-ESCENARIOS, MARCO-CONTEXTOS, MARCO-ACTORES, TEM-ANTERIOR, TEM-SIGUIENTE, ANEXO-REFERENCIAS]
---

# <Nombre del tema> — `TEM-XXX`

> Anterior: [`TEM-ANTERIOR`](ruta-relativa.md) · Siguiente: [`TEM-SIGUIENTE`](ruta-relativa.md) · Mapa: [`MAPA-CONCEPTUAL`](../01-Mapa-Conceptual/Mapa-Conceptual.md)

## Índice

1. [Resumen ejecutivo](#resumen-ejecutivo)
2. [Definición](#definición)
3. [Aplicación por escenario](#aplicación-por-escenario)
4. [Ejemplos concretos](#ejemplos-concretos)
5. [Preguntas guía](#preguntas-guía)
6. [Criterios de calidad](#criterios-de-calidad)
7. [Anexo — Plantilla comentada](#anexo--plantilla-comentada)
8. [Observaciones](#observaciones)
9. [Referencias](#referencias)

## Resumen ejecutivo

<!-- Prosa, no viñetas. ¿Qué es? ¿Para qué sirve? ¿A quién le sirve (ACT-nn)? La primera frase aporta un hecho,
no reformula el título (R-NV:24). -->

## Definición

### Qué es

**<Concepto>.** <El texto: una o dos oraciones citables.>

**Cómo se aplica.** <La operación: procedimiento, prueba o pregunta que se contesta. Empieza con un verbo de acción.>

**Un caso.** <La escena: datos concretos y el resultado de aplicar la operación. No repetir la escena de otra definición.>

<!-- Si la operación no se puede reconstruir: «Orientación, no criterio: <motivo>» (K-IA D-3). -->

### Qué problema resuelve

<!-- ¿Qué falla o qué cuesta sin esto? Anclar a la evidencia: N-xx / G-xx / F-xx, o «esta guía recomienda». -->

### Qué NO es, y con qué se lo confunde

| Se confunde con | Diferencia | Fuente |
|---|---|---|
| <concepto vecino> | <en una frase> | `N-xx` / criterio propio |

## Aplicación por escenario

### `ESC-1` — <nombre del escenario>

<!-- ¿Qué aporta el tema en este escenario? ¿Qué decide cada actor? Si no aplica, se conserva y se dice por qué. -->

### `ESC-2` — <nombre del escenario>

<!-- Ídem. Una subsección por escenario del marco, todas presentes. -->

### Qué cambia según el contexto

| Contexto | Qué cambia | Por qué |
|---|---|---|
| `CTX-1` <nombre> | | |
| `CTX-2` <nombre> | | |

## Ejemplos concretos

### <Ejemplo 1: qué demuestra>

<!-- Precondiciones, pasos y resultado esperado (R-DA:15). Caso real tomado de la demo o ilustrativo rotulado. -->

```csharp
// fragmento mínimo
```

*Fuente: `Demo/<ruta>` L<a>–L<b>, <commit o versión>.*

<!-- Si el tema define un proceso que un agente ejecuta o verifica (PR, integración, publicación de una
actualización), agregar el bloque de agentes (OB-DA-05): -->

### Entradas

- <qué necesita el proceso>

### Salidas

- <qué produce>

### Validaciones

- <cómo se comprueba que salió bien; comando y resultado esperado>

## Preguntas guía

1. <Pregunta que el lector debe poder responder para producir el artefacto.>
2. <Pregunta para evaluarlo.>
3. <Pregunta que obliga a elegir entre alternativas.>

## Criterios de calidad

### Versión buena

- <rasgo observable, comprobable>

### Versión pobre y antipatrones

| Antipatrón | Síntoma | Corrección |
|---|---|---|
| | | |

## Anexo — Plantilla comentada

```text
<Campo 1>:   <!-- ¿Qué pregunta responde este campo? -->
<Campo 2>:   <!-- ¿Qué evidencia lo respalda? -->
```

## Observaciones

| Hecho | Evidencia | Interpretación |
|---|---|---|
| | | |

<!-- Lo no verificado: «NO VERIFICADO — <motivo>». Se omite la sección si no hay observaciones: no se deja vacía. -->

## Referencias

| ID | Fuente | Nivel | Consultada |
|---|---|---|---|
| `N-xx` | <designación exacta y año / URL oficial> | Normativo | AAAA-MM-DD |
````

Comprobación de la plantilla misma: una vez completada, el documento debe pasar V-01 a V-08 y V-10 a V-12 sin fallas y
V-09 sin candidatos que no sean citas. Ensayo del 2026-10-25: la plantilla, extraída tal cual a un archivo y pasada por
`verificar.sh`, termina con `Documentos: 1` y ninguna línea `FALLA` ni `REVISAR`.
