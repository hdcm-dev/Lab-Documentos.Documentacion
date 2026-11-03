| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-03 |
| Autor | Comisión C-DAC-IND |
| Corrige | — |

Incorporado verbatim desde la ruta de trabajo del rol. Lo que sigue a esta línea, hasta el pase, es la pieza.

---
doc_type: informe-comision
title: Informe de la comisión C-DAC-IND — Docs as Code como práctica de la industria (expediente 0004)
status: borrador
origin: ia-generated
owner: comisión C-DAC-IND de la mesa conjunta del expediente 0004
last_review: 2026-11-03
audience: [mesa conjunta del expediente 0004, jurado, refutador, PO]
---

# Informe de la comisión C-DAC-IND

**Secciones de `Knowledge-Mesa-De-Expertos-A-Pedido.md` leídas: §0, §2.2, §3.2, §3.3 y §4.**
Clase de objeto tomada: **diseño de una norma o decisión** (§2.2). Consecuencias que aplico: cito fuentes
externas con autor y año, sin cláusulas inventadas; respondo cada pregunta por separado y sin «depende»;
todo hallazgo declara su ancla (E1 = comando con salida; E2 = cita de documento; C = criterio de la
comisión, que sólo funda una pregunta, §3.2).

**Mandato.** Docs as Code como práctica de la industria: qué es, qué controla y dónde termina.
**No-competencia.** No opino sobre seguridad de modelos (OWASP LLM), estadística de evaluación, elección de
modelo, didáctica ni operación del servidor. Donde una pregunta cruza a esos terrenos, respondo sólo la
parte documental y lo digo.

**Convención de citas.** Uso las de los dos folios de posición (`LD`, `LDD`, `K`, `EXP2/`, `EXP3/`, `G16`,
`KIA`, `DG`, `LG`, `AIL`). El servicio privado va como `{servicio-privado}`.

## 1. Cómo resuelve la industria la cuestión, desde Docs as Code

### 1.1 Qué es

Docs as Code es tratar la documentación con **las mismas herramientas y el mismo flujo que el código**:
texto plano versionado en el control de versiones (habitualmente junto al código), cambios por *pull
request* con revisión, pruebas automáticas en integración continua y publicación automática desde la rama
principal. Lo formulan así:

- **Write the Docs**, guía «Docs as Code» (s. f.): issue tracker, control de versiones, marcado en texto
  plano, revisión de código y pruebas automáticas aplicadas a la documentación, con el fin de que los
  redactores y los desarrolladores trabajen en el mismo circuito.
- **Anne Gentle, *Docs Like Code* (2017; ediciones posteriores revisadas)**: el repositorio y el PR como
  unidad de colaboración, la compilación continua de la documentación, y la tesis de que la documentación
  vive mejor **cerca del código que describe** y con sus mismos revisores.
- **Google**: la práctica interna de documentación en el repositorio junto al código, renderizada por la
  herramienta interna conocida como g3doc, con dueños por directorio y revisión como cualquier cambio. La
  fuente pública citable es **Winters, Manshreck y Wright, *Software Engineering at Google* (O'Reilly,
  2020), capítulo «Documentation»**: la documentación como código, con dueño, revisión, pruebas y
  frescura (revisión periódica de vigencia).
- **GitLab**: su documentación de producto vive en los repositorios del producto, se cambia por merge
  request, la revisa un redactor técnico y la valida la CI con linters de prosa y de marcado (Vale,
  markdownlint) y con chequeo de enlaces (GitLab, *Documentation Style Guide* y guías de contribución a la
  documentación, s. f.). Agrega una regla de proceso: la documentación de una funcionalidad entra **en el
  mismo merge request** o antes de liberarla.

**Diátaxis (Daniele Procida, s. f.)** no es Docs as Code: es un **marco de arquitectura de contenido** que
separa cuatro tipos (tutorial, guía de tareas, referencia, explicación) según la necesidad del lector. La
industria lo combina con Docs as Code porque la carpeta y el tipo de documento se vuelven verificables,
pero uno es *cómo se gobierna el texto* y el otro *cómo se organiza para quien lee*.

### 1.2 Qué controla

En la práctica de la industria, Docs as Code controla cinco cosas, todas sobre **el texto y su ciclo**:

1. **Procedencia y cambio**: quién cambió qué, cuándo, con qué revisión (historia del VCS y PR).
2. **Forma**: estilo, terminología, marcado, metadatos (linters de prosa, esquemas de frontmatter).
3. **Integridad**: enlaces, referencias cruzadas, compilación sin errores, ejemplos de código que
   compilan o corren (pruebas de documentación).
4. **Concordancia con el artefacto**: referencia generada desde la fuente (OpenAPI, docstrings) y diffs
   que muestran cuando el contrato cambió.
5. **Publicación**: qué se compila, a qué sitio sale y desde qué rama; y **frescura** (dueño y revisión
   periódica; Winters et al., 2020).

### 1.3 Dónde termina

Docs as Code **no** controla:

- **El comportamiento en ejecución** de lo que el documento describe. Un documento verde dice que el texto
  es coherente consigo mismo y con lo que se pudo generar; no que el sistema hace lo que dice.
- **El control de acceso.** La industria publica por sitio o por compilación (sitio interno y sitio
  público); el permiso de lectura lo da el servidor o la plataforma de identidad, no el frontmatter. Un
  campo de audiencia es metadato que *alimenta* un filtro de compilación, no un permiso.
- **La verdad del contenido.** Revisión de pares y pruebas de ejemplos reducen el error; ningún linter
  detecta que una afirmación técnica es falsa.
- **La decisión de puesta en uso** de una funcionalidad. Docs as Code publica la documentación; si la
  funcionalidad se enciende es otra decisión (en la industria, *feature flags* y gestión de cambios).

Consecuencia para la pregunta del PO: **la industria no tiene una metodología establecida y nombrada que
integre Docs as Code «dentro» de una capa de IA**. Lo que existe es la extensión natural del mismo
principio —«si es texto que gobierna el sistema, va al repo, por PR, con prueba»— a artefactos nuevos:
prompts versionados, conjuntos de evaluación versionados, *model cards* (Mitchell et al., 2019) y ADR
(Nygard, 2011). Y en el otro sentido, la documentación como **fuente** de un asistente (RAG, `llms.txt`,
propuesta de Jeremy Howard, 2024) es un **destino de publicación más**, que hereda las mismas reglas de
compilación. Ambas lecturas son prácticas emergentes, no norma consolidada; lo digo como C.

**Tesis de la comisión.** Docs as Code se integra a una capa de IA **en dos puntos y sólo en dos**: (a)
como **gobierno de los artefactos textuales de la capa** (prompt, banco, rúbrica, métrica, ficha, ADR),
que pasan a tener versión, PR, revisión y prueba de concordancia con el código; y (b) como **canal de
publicación hacia los consumidores máquina** (índice de recuperación, `llms.txt`, herramientas), que es
una salida más del mismo filtro de compilación. Fuera de esos dos puntos —calidad de la respuesta del
modelo, permiso del usuario en tiempo de ejecución, puesta en uso— Docs as Code termina, y lo que sigue es
ingeniería de evaluación, seguridad y operación.

## 2. Qué coincide, qué falta y qué sobra en lo que hicieron las sesiones

### 2.1 Coincide con la industria

| Práctica | Evidencia | Ancla |
| --- | --- | --- |
| Compuerta determinista en CI antes de la revisión humana y aprobación en el PR | `EXP2/290-compuerta-e1.md` y `EXP2/017-informe-c-agentes-ia.md` existen en `LDD` (verificado con `ls`) | E1 de existencia; contenido E2 del folio DocsAsCode |
| Metadatos de procedencia en el frontmatter (`origin`: `human`, `ia-assisted`, `ia-generated`) | `DG/esquemas/cuerpo.schema.json` de `LD` contiene `ia-assisted` e `ia-generated` (grep) | E1 |
| Linters con niveles («avisa» / «bloquea») y excepciones explícitas, como Vale en GitLab | `DG/README.md` líneas 151–153: AI-1, AI-2, AI-5 bloquean; AI-4 avisa en el anexo; AI-3 sólo avisa por falsos positivos | E1 |
| Referencia generada desde la fuente y diff de contrato (OpenAPI regenerada en push a main) | Folio DocsAsCode §1, mesa de Geometría (`LG`, PR #248–#250) | E2 |
| Frescura como campo (`last_review`) | Esquema y folios lo usan; propuesta 4 del folio DocsAsCode | E2 |
| «Audiencia orienta la escritura y no es un permiso» | `EXP3/399-resolucion-ciclo-3-audiencias.md` existe (`ls`); tesis en el folio DocsAsCode §1 | E1 de existencia; E2 |
| Prompt como recurso versionado con prueba de igualdad prompt = ficha | Folio Capa de IA §2.1 | E2 |
| ADR con condición de caducidad («Deja de valer si») | Folio Capa de IA §2.3 | E2 |
| Fuentes de industria del conocimiento DocsAsCode con fecha de consulta: Write the Docs, Winters et al. 2020, Böckeler 2025, Backstage | `K` 1.4 en `origin/main` de `LD`, línea 845; el anexo `99-Anexos/Referencias.md` nombra Diátaxis/Procida y GitLab | E1 |

### 2.2 Falta

1. **Diátaxis aplicado a la capa de IA.** Ninguna de las dos sesiones clasifica los artefactos de la capa
   por tipo de contenido. El prompt de sistema es **referencia normativa para el modelo**, la ficha de
   capacidad es **referencia para personas**, el criterio de encendido es **guía de tareas** del PO, y el
   ADR es **explicación**. Sin esa separación, un mismo archivo mezcla instrucción al modelo con
   explicación para el lector humano y el AI-3 de `DG` lo marca con razón (C).
2. **Prueba de la documentación contra el sistema en ejecución** (lo que la industria llama *doc tests* o
   ejemplos ejecutables). El especialista externo del folio DocsAsCode mostró que «con todo en avisa, un
   main que contradice su contrato sale verde» y que en `{servicio-privado}` el único control bloqueante
   no corre en ningún workflow (E2). Es el mismo hueco que la industria cierra corriendo los ejemplos en CI.
3. **Dueño por documento** (Winters et al., 2020: dueño y revisión periódica). Hay `owner` en el
   frontmatter, pero ninguna sesión liga la caducidad de `last_review` a un aviso al dueño. La propuesta 6
   de DocsAsCode (carril programado con fecha) lo cubre a medias.
4. **Coherencia entre folios y repo.** El folio de la Capa de IA dice que el checklist D-23 «no está al
   100 %» y que la revisión humana está pendiente (`B16/Ejecucion/Verificacion-Etapa-4-3.md` H-6). Pero
   en `origin/main` de `LD` el commit `b0bd052` se titula «guía 16: pasa a vigente con D-23 cerrado (15 SÍ,
   1 NO APLICA, 0 NO medido)» y `2112bff` la publica como 1.0.0 (E1, `git log`). La mesa debe saber cuál de
   los dos estados es el vigente antes de usar D-23 como argumento (P1, documental).
5. **Copia de trabajo local desalineada.** En la copia local de `LD` el archivo `K` está **vacío (0 bytes)
   y sin seguimiento**, mientras `origin/main` tiene la versión 1.4; y `EXP3/208` no está en la copia local
   de `LDD` aunque sí en `origin/main` (commit `2904ca2`). Quien verifique contra el árbol de trabajo y no
   contra la rama principal verá otra cosa (E1). Es, de paso, el riesgo que el folio DocsAsCode llama
   «vigencia» aplicado a la propia mesa.

### 2.3 Sobra (o va más allá de Docs as Code)

1. **Llamar «Docs as Code» a lo que es control de acceso.** Las propuestas 1 y 2 del folio DocsAsCode
   («`delivery` como filtro obligatorio del recuperador», canario de contexto) son correctas, pero el
   filtro del recuperador y la identidad en tiempo de recuperación son **seguridad de la aplicación**.
   Docs as Code aporta el metadato y el corpus compilado por audiencia; la prueba de que el modelo no lo
   revela es de otra disciplina. Mantener la frontera evita que un verde de `DG` se lea como garantía de
   no fuga (C).
2. **Marcar `lee-ia` / `escribe-ia` en cada pieza** (propuesta 3 de DocsAsCode). La industria resuelve la
   procedencia con el historial del VCS y un campo de origen, que ya existe (`origin`). Un segundo eje
   por pieza duplica `origin` y obliga a mantener dos verdades (C). Lo que sí hace falta es la regla
   «lo `ia-generated` sin revisión humana no entra como fuente», que es una regla de compilación, no un
   campo nuevo.
3. **Una familia AIL-n con cinco controles de una vez** (folio Capa de IA §2.5). Los controles (1) y (2)
   son Docs as Code puro (concordancia y existencia). Los (3), (4) y (5) son reglas de evaluación,
   registro y privacidad de la capa: no pertenecen a un linter documental común a todo el corpus (C).
4. **El ensayo con aplicador ciego como requisito general.** No tiene equivalente en la industria de Docs
   as Code; es un método de validación del *conocimiento para agentes*, valioso y propio. No lo descarto:
   digo que no debe venderse como práctica estándar (C).

## 3. Respuestas propias

### 3.1 Las siete preguntas de DocsAsCode

1. **¿Dónde vive el filtro por `delivery`?** La **fuente de verdad es el sistema documentador**: compila un
   corpus por audiencia y cada destino máquina (índice, `llms.txt`, MCP) consume **sólo** su corpus
   compilado, nunca el repositorio crudo. La capa de IA no filtra para decidir qué existe; a lo sumo vuelve
   a comprobar, y esa comprobación es de seguridad, no documental. Así lo hace la industria con sitios
   públicos e internos: el filtro está en la compilación, el permiso en el servidor.
2. **¿Qué identidad usa la capa para recuperar?** Fuera de mi mandato en su parte de autorización. Desde
   Docs as Code: el documentador entrega un índice **por audiencia** y la capa elige el índice con la
   identidad **del usuario**; no hay índice global que filtrar después. La prueba de no ampliación la
   diseña seguridad.
3. **¿Lo escrito por un agente cuenta como fuente antes de la aprobación humana?** **No.** En Docs as Code
   lo que no se fusionó con revisión no se publica, y un índice es una publicación. Rótulo: `origin:
   ia-generated` en la rama; sólo entra al corpus compilado tras el PR aprobado por una persona.
4. **¿`AGENTS.md` y equivalentes son documentación o configuración?** **Son documentación** —texto en el
   repo, versionado, revisado por PR, con dueño y `last_review`— de tipo **referencia** (Diátaxis), cuyo
   lector es una máquina. Que la lea una máquina no la saca del circuito; la saca de la publicación a
   personas. No son control de acceso (coincido con `EXP3/370`).
5. **¿Qué bloquea desde el principio?** Desde mi mandato, tres: (a) la prueba de no publicación (lo
   restringido no aparece en ningún artefacto compilado ni en el corpus de ningún índice no autorizado),
   **conectada a un workflow**; (b) la concordancia prompt del código = ficha; (c) el esquema de
   frontmatter. Son deterministas y sin falsos positivos conocidos. El canario frente al modelo lo dejo a
   seguridad: no es determinista.
6. **¿Cómo se ensaya con aplicador ciego cuando el resultado son respuestas?** Fuera de mi mandato en el
   oráculo y el umbral. Desde Docs as Code: el aplicador ciego ensaya **el documento** (¿alcanza para que
   un agente sin contexto produzca la especificación?), no al modelo de producción. Mantengan esa
   separación; la evaluación del modelo es otra cosa y lleva su propio banco.
7. **¿Se cierran los cuatro P0 de K 1.4 antes de integrar la capa?** **Se integra sobre el borrador,
   rotulado, y los P0 se cierran antes de que K pase de `borrador` a vigente.** Es lo que hace la
   industria con documentación preliminar (rótulo visible, sin publicarla como estable). Condición: lo que
   se integre no puede citar como regla una sección afectada por un P0 abierto (`EXP3/208` §5), y el rótulo
   «borrador ensayado, no probado» se hereda.

### 3.2 Las preguntas de la Capa de IA que tocan mi mandato

1. **¿La ficha de capacidad es un `doc_type` nuevo con esquema en `DG`?** **Sí.** Un artefacto que gobierna
   una decisión y se reutiliza entre proyectos merece tipo y esquema; la forma libre es la que la industria
   abandonó con las *model cards* (Mitchell et al., 2019), que justamente fijan secciones. El esquema
   admite modelo por nombre o por código.
2. **¿Quién es dueño del arnés?** **La capa, como código**, con pruebas contra la implementación. El
   expediente guarda la **corrida** (salida congelada con su huella), no el arnés. Es la separación código
   / artefacto de compilación de toda CI.
3. **¿Una corrida rotulada es documento o evidencia?** **Evidencia**: inmutable, con huella y sin
   `last_review`. El documento es el **resumen** que la cita y se recalcula; ése sí lleva frontmatter.
4. **¿Cómo se firma la revisión humana cuando el PO delegó en mesas?** Docs as Code no tiene revisión humana
   sustituible: la aprobación del PR por una persona es la firma. Si el PO delegó, la firma es **su
   aprobación del PR o del merge**, registrada; un «revisor no humano» declarado deja la casilla en
   «Parcial», no en «SÍ». Verifiquen primero el estado real de D-23 (§2.2, punto 4).
5. **¿El nombre del modelo en un repo público junto a una decisión de un producto privado?** Fuera de mi
   mandato (privacidad).
6. **¿AIL-n se suma a `DG` o vive en la guía 16?** **En `DG` van sólo los controles documentales
   genéricos** —concordancia artefacto = ficha y existencia de lo citado—; los controles propios de
   evaluación y registro van en `tools/` de la guía 16. Un linter común no debe conocer el dominio de una
   capa.
7. **Carga cruzada de un servidor compartido.** Fuera de mi mandato (operación).

## 4. Lo que revisé y está bien

- `DG` de `LD`: AI-1 a AI-5 documentados con su nivel y su criterio de promoción (`README.md` 27, 85,
  151–153); el esquema de cuerpo exige `origin` con los valores de IA (E1). Es exactamente el patrón de
  linters con severidad de la industria.
- `K` 1.4 en `origin/main` de `LD`: `status: borrador`, `origin: ia-assisted`, `last_review: 2026-11-02`;
  cita fuentes de industria con fecha de consulta y su anexo de referencias nombra Diátaxis y GitLab (E1).
  El rótulo honesto coincide con `EXP3/208` §9 y `EXP3/209`, presentes en `origin/main` de `LDD`
  (commits `2904ca2` y `645f24c`) (E1).
- `EXP2/017`, `EXP2/290`, `EXP3/370` y `EXP3/399` existen donde los cita el folio DocsAsCode (E1).
- `G16` publicada en `origin/main` de `LD` (commit `2112bff`, versión 1.0.0) (E1).
- La separación «la documentación y el código se fusionan; la puesta en uso es otra decisión» (folio Capa
  de IA §2.7) es la frontera correcta de Docs as Code, y coincide con §1.3 de este informe.
- La tesis de CA-7, «el agente no es una audiencia: actúa por una», es consistente con que la audiencia sea
  metadato de compilación y no permiso.

## 5. Fuentes externas

- Write the Docs. «Docs as Code». Guía de la comunidad, s. f.
- Gentle, A. (2017). *Docs Like Code*. Just Write Click.
- Procida, D. *Diátaxis: a systematic approach to technical documentation authoring*, s. f.
- Winters, T., Manshreck, T. y Wright, H. (2020). *Software Engineering at Google: Lessons Learned from
  Programming Over Time*. O'Reilly. Capítulo «Documentation».
- GitLab. *Documentation Style Guide* y guías de contribución a la documentación, s. f.
- Mitchell, M. et al. (2019). «Model Cards for Model Reporting». *Proceedings of FAT* 2019*.
- Nygard, M. (2011). «Documenting Architecture Decisions».
- Howard, J. (2024). Propuesta `llms.txt`.

Sigue: incorporar el informe siguiente · presidencia de la mesa
