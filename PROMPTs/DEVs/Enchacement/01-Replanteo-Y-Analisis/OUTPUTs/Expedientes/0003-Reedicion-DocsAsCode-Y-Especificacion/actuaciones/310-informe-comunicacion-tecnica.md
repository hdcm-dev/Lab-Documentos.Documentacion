---
doc_id: EXP0003-F310
doc_type: informe
title: Informe de la comisión CA-1 (comunicación técnica y arquitectura de la información) — audiencia como categoría de comunicación separada de la entrega, registro de audiencias, perfiles de entrega por canal y microtexto de formulario como canal de la ayuda
status: vigente
origin: agent
confidence: alta en lo medido sobre el cuerpo (LD 00171bd, 2026-11-01) y en las fuentes abiertas hoy; media en las propuestas, rotuladas «criterio propio» donde no las funda una fuente; las normas ISO de pago se citan por su texto de vista previa (FDIS) o sin apartado
owner: comisión CA-1 del ciclo 3 de la mesa de la reedición DocsAsCode (expediente 0003)
last_review: 2026-11-01
audience: [presidencia, refutador, análisis de decisiones, jurado del ciclo 3, comisiones, PO]
traces: [EXP0003-F300, EXP0003-F099, EXP0003-F204]
---

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-01 |
| Autor | Comisión CA-1, titulada por una especialista en comunicación técnica y arquitectura de la información, a ciegas |
| Corrige | — |

| Cabecera de comisión | Valor |
| --- | --- |
| Rol | Comunicación técnica y arquitectura de la información: análisis de audiencia, publicación condicional y perfilado, *single-sourcing*, taxonomías de audiencia (`F300` §7) |
| Preguntas a cargo | A-01, A-02, A-03, A-13; B-04. Contesto además, desde mi especialidad, A-04 a A-12, A-14, A-15 y B-01 a B-03, B-05 a B-12 (`F300` §5) |
| No-competencia | La implementación de control de acceso (CA-3), los portales de API como producto (CA-2), el código .NET (CA-4), la medición de interfaces (CA-8). Donde entro, entro por la forma de la información, no por el mecanismo |
| Norma | `MEP` 3.1 (`Knowledge-Mesa-De-Expertos-A-Pedido`, base de conocimiento del PO) |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Cabecera y §0 (mapa de carga, fila «Sos una comisión»); §2.1; §2.2; §3.2; §3.3; §4; §5.2 (esqueleto de la carta) |
| Otros documentos cargados | `Cadena-De-Consecuencias` 2.0 §2 (`CC`); `Rule-Escalas-De-Juicio` 1.2 §3.3 (`EJ`); `Mesa-Consulta-A-Un-Tercero` 2.0, sólo índice (no rige: no hay tercero) |
| Insumos leídos | `F300` entero; `SDEI/00-Marco.md` §2.5 a §6; `TEM-04` (definición y §3.5); `TEM-05` entero; `99-Anexos/Glosario.md`; `99-Anexos/Esquema-Frontmatter-Y-Prefijos.md` §2; `99-Anexos/Como-Decidir.md` §2–§3; `Examples/Prueba-Ayuda-Por-Rol/` (README, `AyudaContextual.razor`, `HelpCatalog.cs`); `Examples/MovilidadUrbana-Mini-Demo/docs/fichas/RN-LOC-01.md`; `DG` (anclas, l. 560–680); esquemas `cuerpo.schema.json` y `ayuda.schema.json`; `K` §2.3, §3.2, §3.3, §5.2; `F099` §5.2; `F204` §2, §8, §9. No leí folios `31x`–`37x` |
| Medios propios | `grep`, `sed`, `git` sobre LD en `00171bd`; extracción de texto de la vista previa FDIS de ISO/IEC/IEEE 26514 con `pdftotext`; 14 consultas web del 2026-11-01 (§10) |

**Alias.** Los de `F300` (`SDEI/`, `K`, `MEP`, `{servicio-privado}`, `{dir-de-trabajo}`). Además: **LD** = Lab-Documentos;
**DG** = `tools/docs-guard/dg.py` de LD; **ESQ** = `SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md`; **PoC-R** =
`SDEI/Examples/Prueba-Ayuda-Por-Rol/`; **RN1** = `SDEI/Examples/MovilidadUrbana-Mini-Demo/docs/fichas/RN-LOC-01.md`;
**SDV2** = el conocimiento `Template-HTML-Sistema-De-Diseno-V2` de la base de conocimiento del PO.

**Lectura de P0–P3 para este caso** (la carta no me llegó; la fijo yo y la declaro): **P0**, lo que haría que el
sistema documentador entregue documentación a quien no corresponde, o que el libro o `K` afirmen un control que no
existe; **P1**, lo que impide contestar el pedido del PO (audiencias por rol, jerarquía, alcance, superficie y acceso;
ayuda en el formulario) con el cuerpo de hoy; **P2**, ambigüedad de término o vocabulario que no discrimina; **P3**,
forma.

# Informe de la comisión CA-1 — ciclo 3, expediente 0003

## Índice

1. [Definiciones de este informe](#1-definiciones-de-este-informe)
2. [Hallazgos sobre el cuerpo](#2-hallazgos-sobre-el-cuerpo)
3. [Estado del arte desde la comunicación técnica](#3-estado-del-arte-desde-la-comunicación-técnica)
4. [Dictamen por pregunta](#4-dictamen-por-pregunta)
5. [Propuesta concreta](#5-propuesta-concreta)
6. [Puntuación de la hipótesis y de las alternativas](#6-puntuación-de-la-hipótesis-y-de-las-alternativas)
7. [Qué rehacer (tabla de §5.3 de F300)](#7-qué-rehacer-tabla-de-53-de-f300)
8. [Riesgos](#8-riesgos)
9. [Lo que revisé y está bien](#9-lo-que-revisé-y-está-bien)
10. [Fuentes externas](#10-fuentes-externas)
11. [Solicitudes de convocatoria, excepciones e incidencias](#11-solicitudes-de-convocatoria-excepciones-e-incidencias)
12. [Barrido de lo privado](#12-barrido-de-lo-privado)

---

## 1. Definiciones de este informe

| Término | Definición en este informe | Fuente |
| --- | --- | --- |
| **Audiencia** | Categoría de personas usuarias (o de agentes que actúan por ellas) que comparten características y necesidades —propósito, tareas, formación, experiencia— que determinan el contenido, la estructura y el uso de la información | ISO/IEC/IEEE 26514, 3.1.7, en su texto FDIS (vista previa abierta hoy, §10): «category of users sharing the same or similar characteristics and needs … that determine the content, structure, and use of the intended information» |
| **Entrega** (perfil de entrega) | La regla que decide, por canal, qué contenido recibe quién: incluir o excluir según atributos (rol, alcance, superficie, idioma). Es el *profiling* o procesamiento condicional | DITA 1.3, procesamiento condicional y DITAVAL `<prop action="include\|exclude\|flag\|passthrough">` (§10) |
| **Acreditación** | Cómo prueba un lector que pertenece a una audiencia: ninguna (público), sesión en el producto, credencial o invitación, pertenencia al equipo (interno) | **[criterio propio]**, sobre la distinción visibilidad/acceso de `TEM-05:48` |
| **Punto de cumplimiento** | Dónde se aplica la exclusión: build (no se compila), servidor del producto, portal, repositorio privado | `TEM-05:103-109`; **[criterio propio]** en el nombre |
| **Canal** | Forma en que un lector recibe la fuente (`TEM-04:39`). Sumo los canales de **punto de uso**: ayuda de pantalla, texto de pista de campo, mensaje de validación, recorrido guiado | `TEM-04:39`; ISO/IEC/IEEE 26514, 3.1.14 y 3.1.22 (FDIS) |
| **Microtexto de formulario** | Etiqueta, pista, marcador, mensaje de validación y ayuda emergente de un campo | ISO/IEC/IEEE 26514, 3.1.22: «embedded information for users … EXAMPLE Pop-up help and help text on a screen» |
| **Identificador de contexto** | ID estable que la interfaz usa para pedir el tema o el microtexto que le corresponde a una pantalla o un campo | DITA 1.3 `<resourceid>` (`@appid`, `@ux-context-string`); MadCap Flare, *header* y *alias files* (§10) |

**Tesis de la comisión.** La palabra que el PO eligió es la correcta, pero «audiencia» en la norma y en la
tradición de la comunicación técnica designa **para quién se escribe**, no **a quién se le entrega**. El pedido del
PO tiene las dos cosas: «necesidades documentales diferentes» (audiencia) y «no quiera hacer pública … usuarios
específicos» (entrega y acreditación). La retórica las separa con nombre propio: audiencia *invocada* (la que el
texto construye) y audiencia *dirigida* (los lectores reales) (Ede y Lunsford, 1984, §10). DITA las separa en la
sintaxis: el elemento de metadatos `<audience>` (tipo, trabajo, experiencia) describe; el atributo condicional
`@audience` más DITAVAL filtra. El cuerpo SDEI hoy no separa ni una ni otra (H01). Recomiendo **un concepto, dos
capas**: la audiencia como categoría de comunicación, y la entrega como regla por canal con su acreditación y su
punto de cumplimiento.

## 2. Hallazgos sobre el cuerpo

| Id | Nivel | Ancla | Hallazgo | Impacto si no se corrige | Dirección |
| --- | --- | --- | --- | --- | --- |
| H01 | P1 | E2: `ESQ:53`; `tools/docs-guard/esquemas/cuerpo.schema.json:18`; `tools/docs-guard/esquemas/ayuda.schema.json:10`; `K:438-445` | El campo `audience` mezcla tres ejes en un solo vocabulario cerrado: modo de lectura (`humano`, `agente`), rol del equipo (`desarrollo`, `qa`, `devops`, `po`, `analista`) y audiencia del producto (`persona-usuaria`). Los roles del producto van en otro campo (`roles`, con otra forma: `^[A-Z][A-Za-z]+$`), sin vínculo con `audience`. No hay dónde declarar alcance, superficie ni acceso | El pedido del PO (rol, jerarquía, alcance, superficie, acceso) no se puede expresar en el frontmatter; cada proyecto inventará su campo | Separar los ejes (§5.2) |
| H02 | P2 | E1: `grep -rh '^audience:'` sobre LD en `00171bd`: 283 archivos con `audience`; `agente` aparece 290 veces y `humano` 283 | `humano` y `agente` están en prácticamente todos los documentos: como valor de audiencia no discriminan nada. Es coherente con la invariante de doble audiencia (`TEM-04:35-38`: toda pieza sirve a los dos), y por eso mismo sobra en `audience` | Un filtro o un índice por audiencia que los use devuelve todo | Sacar el modo de lectura de `audience`: es propiedad del canal (A-04) |
| H03 | P2 | E1: `grep -n -i '^\| *audiencia' SDEI/99-Anexos/Glosario.md` → 0 filas; el glosario sí define «Actor» (`Glosario.md:43`) y «Rol» (`:86`) | El término central del ciclo no tiene entrada en el glosario, aunque es campo obligatorio de todo documento (`ESQ:53`), criterio K5 de decisión (`Como-Decidir.md`, §2) y título de la Parte III del libro (`F099:200`) | Cada capítulo lo usará con otro sentido | Entrada «Audiencia» y «Entrega», con su diferencia con rol, actor y persona (A-01) |
| H04 | P1 | E2: `SDEI/00-Marco.md:108`; `K:170` | La fila «Audiencias» de §2.5 es una enumeración por escenario que mezcla equipo («desarrollo») y producto («persona usuaria»), y en el panel con roles dice «Lo anterior más los roles del panel»: los roles del producto entran como apéndice, sin jerarquía ni alcance | `K` hereda la lista y la aplicadora deduce audiencias del escenario en lugar de inventariarlas | La fila pasa a remitir a un registro de audiencias del proyecto (A-03, §5) |
| H05 | P1 | E2: `TEM-05:90`; `00-Marco.md:112` | En `ESC-SDEI-4` (servicio con paquetes) la tabla dice que el rol «Nada» decide y la confidencialidad va «en el build y en los secretos». El caso de `{servicio-privado}` (`F300` §2.3) es justamente un servicio con documentación de integrador que no todos deben ver | El escenario que más se parece al caso real del PO no admite audiencias restringidas | Agregar acreditación y punto de cumplimiento a `ESC-SDEI-4` (A-07) |
| H06 | P1 | E2: `00-Marco.md:183`; `RN1:37` («Letra: «Entre 3 y 60 caracteres, único por provincia.» (texto de ayuda bajo el campo Nombre)»); `RN1:59` (ancla de rol `muestra`); `DG:571`, `:610`, `:660` | **El caso fundante del cuerpo ya es microtexto de formulario**: el 60/80 es un texto de pista bajo un campo. La ficha lo ancla con rol `muestra` sobre el símbolo de código que produce la pista, y DG resuelve anclas a C# y a XAML (con atributo: `Nombre.Atributo`). Pero `TEM-05` no nombra la pista como canal de la ayuda, y `K` D-13 dice que «el texto localizado en archivos de recursos no se ancla» (`K:281`): es un límite de DG (no hay resolvedor para `.resx`), no del concepto | B-03 y B-05 se contestarían como si hubiera que inventar un mecanismo que el cuerpo ya tiene a medias | Microtexto = canal de punto de uso de `CL-06`; ancla de rol `muestra` extendida a recursos (B-03, B-04, B-05) |
| H07 | P1 | E2: `00-Marco.md:153` (`ACT-SDEI-3`, Desarrollo, «No decide: El texto de la ayuda al usuario final»); `RN1:59` (el texto vive en `LocalidadPolicy.cs`) | El microtexto vive en el código o en recursos que escribe Desarrollo, y el Marco le quita a Desarrollo la decisión sobre el texto de la ayuda. Nada dice quién decide la letra de una pista | Conflicto de actores en cada formulario; o la pista queda sin dueño documental | Regla: la ubicación es del código, la letra es de la ayuda (B-04) |
| H08 | P1 | E3: contraejemplo sobre `ayuda.schema.json:10` | Con `roles` como lista plana, una jerarquía (administrador raíz ⊃ administrador de aplicación ⊃ usuario) obliga a listar en cada página común todos los roles que la ven. Agregar un nivel intermedio («operador de aplicación») obliga a editar cada página que debería heredarlo; olvidar una deja al nuevo rol sin ayuda, sin que ningún control lo vea | Escala mal y falla en silencio | Jerarquía declarada una vez, en el registro, como inclusión (A-05) |
| H09 | P2 | E2: `TEM-05:180-185` | El «cruce de rol» se detectó en la PoC pero no es control de DG: queda en el validador del producto. Para generalizarlo (alcance, superficie) DG necesitaría saber la entrega de cada página, y hoy sólo tiene `roles` en las páginas de ayuda | La propuesta de «cruce de alcance» de cualquier comisión no tiene de dónde leer | Que la entrega sea legible por DG (§5.3, C-AUD-2) |
| H10 | P2 | E2: `F099:200` | La Parte III se titula «Audiencias y canales» pero su único capítulo de audiencia es «7. Doble audiencia» (humano/agente) | El libro promete en el título lo que no trata | Capítulo nuevo de audiencias (A-13) |

## 3. Estado del arte desde la comunicación técnica

| Fuente | Qué dice, en lo que importa | Qué toma el cuerpo |
| --- | --- | --- |
| ISO/IEC/IEEE 26514:2022, *Design and development of information for users* (texto FDIS de la vista previa) | 3.1.7 define **audiencia** (categoría de usuarios con necesidades que determinan contenido, estructura y uso; nota 1: «There may be different audiences», p. ej. «management, data entry, maintenance, engineering»). 3.1.14 **context-sensitive help**: el material mostrado depende del estado del software y del avance de la tarea. 3.1.15 **customize**: adaptar un producto de información a una audiencia. 3.1.22 **embedded information for users**: «accessed as an integral part of software», ejemplo «Pop-up help and help text on a screen». El índice tiene 6.2.2 *Audience analysis*, 6.2.3 *Task analysis* y 9.4 *Context-sensitive information*; no leí su texto normativo | La definición de A-01; el microtexto como información para usuarios (B-04) |
| ISO/IEC/IEEE 26511:2018, *Requirements for managers of information for users of systems, software, and services* | Requisitos para planificar y gestionar la información para usuarios, incluida la traducción y la calidad (resumen de la página de ISO, vía buscador; la página devolvió 403 a la descarga directa) | La gestión del registro de audiencias como pieza planificada: **sin apartado** |
| ISO/IEC/IEEE 26512:2017, *Requirements for acquirers and suppliers of information for users* | Título confirmado sólo por catálogo de biblioteca | Nada específico de audiencia: **sin verificar** el contenido |
| ISO/IEC/IEEE 26515:2018, *Developing information for users in an agile environment* | Cláusula 6 planificación, 7 diseño, desarrollo y entrega en ágil; confirmada en 2024 (resumen de ISO vía buscador) | La audiencia como requisito del *backlog*: encaja con el RRD (`CL-02`), **sin apartado** |
| OASIS DITA 1.3, *Conditional processing* | `@audience`, `@deliveryTarget`, `@otherprops`, `@platform`, `@props` asignan condiciones; un perfil decide incluir, excluir o marcar | Ejes de entrega como atributos separados (A-02) |
| OASIS DITA 1.3, elemento `<audience>` | Metadato que describe la audiencia del tema: `@type` (user, purchaser, administrator, programmer…), `@job` (installing, administering, programming, using, troubleshooting…), `@experiencelevel`, y `@name` para enlazarlo con los valores de `@audience` | La capa de comunicación del registro: tarea y experiencia por audiencia |
| OASIS DITA 1.3, DITAVAL `<prop>` | `include` es el comportamiento por defecto; `exclude` excluye «if all values in the particular attribute are excluded»; `flag`; `passthrough` conserva el valor en la salida | Semántica de la entrega: por defecto incluye, y por eso todo lo restringido tiene que declararse (riesgo R1) |
| OASIS DITA 1.3, *Processing controlled attribute values* (esquema de sujetos) | Valores controlados en jerarquía; al filtrar, si el valor no tiene regla se sube a su padre hasta encontrar una: excluir «therapist» excluye por defecto a «novice-therapist» y «expert-therapist» | Vocabulario cerrado con jerarquía «es un tipo de». **No** es la jerarquía de privilegio (A-05) |
| DITA 1.3, `<resourceid>` | «provides an identifier for applications that must use their own identifier scheme»; `@appid`, `@ux-context-string`; permite generar los archivos de mapa y alias de la ayuda contextual | El identificador de contexto pantalla/campo → tema (B-07) |
| S1000D, aplicabilidad (documentación de proveedores: Adobe FrameMaker S1000D; PTC Windchill) | Aplicabilidad global (módulo) o en línea (elemento); tablas ACT/CCT de atributos del producto y condiciones, y PCT con los productos y sus valores, de las que se resuelve qué aplica | La idea de **declarar los atributos una vez en una tabla** y referirlos desde cada pieza, en lugar de repetir listas (H08). **Sin verificar** en la especificación S1000D misma |
| MadCap Flare, *Header files* y *Micro content* (ayuda en línea de Flare 2025 y 2026) | Cada ID del archivo de cabecera es «a specific area of the interface that is linked to a corresponding topic or micro content response»; el microcontenido «can also be used to create field-level context-sensitive Help» | Industria de autoría que ya trata la ayuda de campo como contenido de la misma fuente que los temas, con ID por área de la interfaz |
| Sphinx, directiva `only` | «Include the content … only if the expression is true»; advierte: «designed to control only content of document. It could not control sections, labels and so on» | Un filtro de build que no filtra títulos ni etiquetas filtra visibilidad, no acceso (riesgo R2) |
| Diátaxis | «a systematic approach to understanding the needs of documentation users»: cuatro tipos por cuatro necesidades | Ortogonal a la audiencia: una audiencia necesita los cuatro tipos; no se confunden |
| Ede, L. y Lunsford, A. (1984) | Audiencia *dirigida* (lectores reales, fuera del texto) e *invocada* (la que el texto construye) | Entrega/acreditación = dirigida; tono, saberes supuestos y tarea = invocada (A-01) |
| Hackos, J. T. y Redish, J. C. (1998), *User and Task Analysis for Interface Design*, Wiley, ISBN 0-471-17831-4 | Referencia clásica del análisis de usuarios y tareas para interfaz (datos bibliográficos verificados hoy; contenido no releído) | Respaldo del análisis por tarea del registro; **contenido sin verificar hoy** |

**Lo que se usa hoy para la ayuda en el punto de uso**, en lo que cae en mi especialidad (la medición de patrones de
interfaz es de CA-8 y CA-6): GOV.UK Design System pide texto de pista sólo «for help that's relevant to the majority of
users», en una oración corta, sin enlaces, y prohíbe el marcador en lugar de etiqueta o pista; su ejemplo asocia
pista y error por `aria-describedby="event-name-hint event-name-error"`. .NET trae en `DisplayAttribute` los campos
`Name`, `ShortName`, `Prompt` («watermark for prompts in the UI»), `Description` («display a description in the UI»)
y `ResourceType` para localizarlos. JSON Schema tiene `title` y `description` como anotaciones que «aren't strictly
used for validation». El sistema de diseño del PO ya tiene la pieza: `form-hint` con `aria-describedby`
(`SDV2:1305-1307`) y, en la vitrina, una pista con un límite escrito a mano, «Máximo 500 caracteres.» (`SDV2:1339`):
el mismo defecto que el 60/80 si el límite cambia.

## 4. Dictamen por pregunta

### A-01 — Definición y término (a cargo)

**Dictamen.** El término es **audiencia**, con la definición de ISO/IEC/IEEE 26514, 3.1.7, adaptada: «categoría de
personas usuarias, o de agentes que actúan en su nombre, que comparten necesidades, tareas y saberes que determinan el
contenido, la estructura y el canal de la documentación». Distinciones para el glosario:

| Término | Qué es | Diferencia con audiencia |
| --- | --- | --- |
| Lector | Una persona o un agente concreto que lee | La audiencia es una categoría; el lector es una instancia |
| Público destinatario | Sinónimo coloquial de audiencia | Se desaconseja en el cuerpo: un solo término (H03) |
| Persona (UX) | Arquetipo narrativo de un usuario, para diseñar | La persona ilustra una audiencia; no se usa para filtrar |
| Rol | Perfil del producto con permisos (`Glosario.md:86`) | Es **un atributo de entrega**: varias audiencias pueden compartir rol (el administrador de la aplicación A y el de la B) y una audiencia puede abarcar varios roles |
| Actor | Quien interviene en el sistema documentador (`Glosario.md:43`) | Actores escriben y deciden; audiencias leen. Desarrollo es actor y, a la vez, audiencia de la documentación técnica |
| Entrega | La regla por canal que incluye o excluye | La audiencia dice para quién se escribe; la entrega, quién lo recibe |

### A-02 — Dimensiones (a cargo)

| Dimensión | Capa | Obligatoria | Ortogonal o derivada | Por qué |
| --- | --- | --- | --- | --- |
| Tarea o trabajo (`job`) y experiencia | Comunicación | Sí, en toda audiencia | Ortogonal | ISO 26514 6.2.2–6.2.3 y DITA `<audience @job @experiencelevel>`: es lo que cambia el texto |
| Rol del producto | Entrega | Sí en `ESC-SDEI-3`; opcional en los demás | Ortogonal | Es lo que el servidor conoce (claim) |
| Jerarquía de privilegio | Entrega | Sólo si hay roles anidados | **Derivada** del rol: se declara como inclusión entre roles, no como dimensión propia | H08 |
| Alcance (inquilino, aplicación) | Entrega | Sólo si un mismo rol administra cosas distintas | Ortogonal al rol | E-04 de `F300`: «incluso alcances diferentes» |
| Superficie (panel, móvil, API, servicio) | Entrega | Sí si hay más de una | Ortogonal; equivale a `@platform` / `@deliveryTarget` | E-02, E-03 |
| Idioma | Entrega | Sí si hay más de uno | Ortogonal; con fallback (nunca 404, `TEM-05:189`) | — |
| Acreditación (público, sesión, credencial o invitación, interno) | Entrega | Sí, siempre | Ortogonal | E-05: la documentación de API «no … pública» |
| Punto de cumplimiento | Entrega | Sí, por cada acreditación distinta de público | Derivada de acreditación y canal | `TEM-05:103-109` |
| Modo de lectura (humano, agente) | **Canal**, no audiencia | — | Ortogonal; invariante | H02; `TEM-04:35-38` |

### A-03 — Relación con rol, persona y escenario (a cargo)

La audiencia **se suma como decisión nueva** y la fila «Audiencias» de `SDEI/00-Marco.md` §2.5 deja de ser una lista:
pasa a decir «registro de audiencias del proyecto; mínimo: …» con las audiencias **típicas** por escenario como
punto de partida, igual que las clases activas por defecto (`00-Marco.md:110`). El escenario sigue decidiendo clases;
las audiencias se **inventarían** (análisis de audiencia de ISO 26514 6.2.2) a partir del inventario de autorización
que `K` D-01 ya pide (`K:269`). Un rol del producto se mapea a una o más audiencias; una persona de UX ilustra una
audiencia y no entra al registro.

### A-04 — Doble audiencia

Queda como **tema propio sobre canales** (`TEM-04` sigue) y sale del vocabulario de `audience` (H02): humano y agente
no son audiencias, son modos de lectura de la **misma** audiencia. Lo que cambia: el cap. 7 del libro se titula
«Canales para personas y agentes» o se conserva «Doble audiencia» con una frase que diga que es una propiedad del
canal y no una audiencia; la regla «el agente recibe lo que recibe su usuario» (`TEM-04` §3.5) pasa a ser regla
general de entrega.

### A-05 — Jerarquía de privilegio

DITA trae la jerarquía «es un tipo de» con herencia de la **exclusión** hacia abajo (§3). La jerarquía de privilegio
es otra relación: el administrador raíz **incluye** lo que ve el administrador de aplicación. Propuesta: en el
registro, cada audiencia declara `incluye: [AUD-…]`; DG calcula el cierre y escribe el conjunto efectivo de cada
página. Una página exclusiva del nivel alto se marca en la audiencia alta; una común se marca en la más baja y la
heredan las altas. El cruce se juzga contra el conjunto efectivo (C-AUD-2).

### A-06 — Acceso vs visibilidad

Mi aporte es de forma: cada audiencia con acreditación distinta de «público» declara su **punto de cumplimiento**, y
la página que le pertenece no puede aparecer en un canal cuyo punto de cumplimiento sea más débil (C-AUD-3). Cómo se
prueba el 404 en el servidor es de CA-3 y CA-4.

### A-07 — Documentación de API restringida

Desde la información: la referencia generada (`CL-05`) y la guía del integrador (`CL-13`, README del paquete) son
contenido de **una audiencia con acreditación por credencial o invitación**. Exponerla al público es una decisión
de clase **H**, de una persona, porque es irreversible para quien ya la leyó (`CC` §2, paso 4). El mecanismo (grupos de
portal, OpenAPI filtrado) es de CA-2.

### A-08 — Alcance por inquilino o aplicación

El alcance es un atributo de entrega con **parámetro**: `alcance: aplicacion` en la audiencia, y el contenido que
depende de una aplicación concreta declara `alcance: {app}`. El texto de ayuda no cambia por inquilino salvo datos
(nombres, límites contratados), que se resuelven en el servidor, no en la fuente. Cruce de alcance = enlace de una
página genérica a una página que sólo existe para un inquilino.

### A-09 — Varias superficies

**Una fuente con salidas por superficie** (*single-sourcing*): `superficie` es atributo de entrega, como
`@platform`. Lo que viaja en el paquete móvil es visible para quien lo instala (`00-Marco.md:112`): por eso el punto
de cumplimiento «build» es el único válido para lo que no puede ver la persona usuaria del móvil; lo restringido se
pide al servidor.

### A-10 — Agente por audiencia

`llms.txt` y `.md` crudos se derivan **con el mismo perfil de entrega** que la página (ya es así en la PoC, `TEM-04`
§3.5). `llms.txt` no es control de acceso (fuente semilla de `F300` §8). El resto es de CA-7.

### A-11 — Controles en CI

Ver §5.3. Van a DG: vocabulario de audiencias, cruce de audiencia, fuga a canal público, ancla `muestra` del
microtexto, traducción atrasada (aviso). Quedan en las pruebas del producto: el 404 por sesión, la asociación
accesible de la pista (`aria-describedby`).

### A-12 — Ficha A-01 y oráculos

Decisión nueva **D-18 «Audiencias y entrega»** en `K` §3.2, y **D-13 ampliada** con los canales de punto de uso.
Artefacto nuevo: el **registro de audiencias** (A-12 en la numeración de artefactos de `K`, si está libre; si no, el
siguiente libre), del que lee DG. El vocabulario de `audience` de A-03 pasa a ser la lista de IDs de ese registro. Los
oráculos: ver A-14.

### A-13 — Impacto en el libro (a cargo)

| Capítulo de `F099` §5.2 | Cambio |
| --- | --- |
| Cap. 1, sección 1.4 «Tipos de documentación y lectores» y 1.5 «Dos audiencias» | 1.5 pasa a «Audiencias, entrega y canales» con la tesis de §1 |
| Parte III, **capítulo nuevo 7 «Audiencias»** (el actual 7 pasa a 8 y así) | 7.1 Definición (ISO 26514 3.1.7) y términos vecinos · 7.2 Dimensiones y capas · 7.3 Registro de audiencias y jerarquía · 7.4 Entrega por canal y acreditación · 7.5 Por escenario · 7.6 Ejemplo trabajado con el caso por alias · 7.7 Controles · 7.8 Plantilla (→ G nueva) |
| Cap. «Doble audiencia» (hoy 7) | Pasa a 8 «Canales para personas y agentes», con la regla general «el agente recibe lo que recibe su usuario» |
| Cap. «Ayuda al usuario final» (hoy 8) | Pasa a 9; suma 9.x «Ayuda en el punto de uso: pantalla, campo y validación» (B-04) |
| Cap. 3 «Marco de referencia» | 3.2 escenarios con la fila de audiencias reescrita (A-03) |
| Cap. 14 «Caso de estudio: ayuda por rol» | Extendido a audiencias (A-15) |
| Cap. 18 «Industria» | 18.4 normas suma ISO 26514/26511/26515, DITA, S1000D; 18.x patrones de microtexto (CA-6/CA-8) |
| Anexo A, glosario; anexo C, esquema; anexo G, plantillas | Entradas nuevas; esquema del registro; plantilla del registro |

### A-14 — Impacto en los ensayos

Si `K` suma D-18, los oráculos de los casos con roles (`ESC-SDEI-3`) y con paquetes restringidos tienen que llevar la
fila de D-18; sin ella, una aplicadora que conteste D-18 bien suma discrepancias en M2 (`F204` §2) que no son error.
**Se re-sellan** los oráculos afectados. El criterio de caso de `F204` §8 no cambia. Lo concreto (qué casos) es de
la presidencia: en lo público sólo puedo decir que `ESC-SDEI-3` está en juego.

### A-15 — Demo

Extender PoC-R, no armar otra: ya tiene catálogo, filtro, `llms.txt`, 404, `topic` y dos idiomas (`TEM-05:160-196`).
Suma: un tercer rol en jerarquía (administrador raíz ⊃ administrador), dos alcances (dos «laboratorios»), una
superficie más (salida para móvil empaquetada sin lo restringido) y una página de «integrador» con acreditación
por credencial. Y un formulario (B-12).

### B-01 — Mecanismos de microtexto

Fuera de mi núcleo (CA-8). Desde la información: etiqueta y pista son información para usuarios embebida (ISO 26514
3.1.22); GOV.UK la limita a lo que sirve «a la mayoría» y sin enlaces, y desaconseja el marcador. Consecuencia para el
sistema documentador: **lo que no cabe en una oración va al tema de ayuda enlazado por identificador de contexto**,
no a la pista.

### B-02 — Fuente única entre regla, validación y texto

Sí, en dos formas que no hay que confundir: **derivar** (la pista se escribe en la voz del usuario a partir de la
regla, y su número sale del mismo símbolo, como `LocalidadPolicy.RequisitoDelNombre` que contiene
`LargoMaximoDelNombre`, `RN1:59`) y **generar** (el texto lo compone el código desde la anotación). La generación es
buena para los **valores** (límites, obligatoriedad) y mala para la **letra** (`TEM-05:44`). Regla propuesta: los
números de una pista se interpolan desde la constante de la regla; la letra la escribe la autora de ayuda.

### B-03 — Traza del texto de campo

**La traza va de la ficha al texto, no del texto a la ficha.** Un recurso no tiene frontmatter; la ficha sí, y ya
admite anclas de rol `muestra` (`RN1:55-60`). Propuesta: extender los resolvedores de DG de C# y XAML (`DG:571`,
`:610`) a `.resx` (`ruta.resx#Clave@SHA`, afirma `contiene` sobre el valor) y a JSON Schema (`ruta.json#/puntero`).
Así la versión es la de la ficha y DG da rojo cuando la regla cambia y la pista no (C-AUD-4). El «no se ancla» de
`K:281` deja de ser cierto con ese cambio de herramienta.

### B-04 — Clase de pieza (a cargo)

**Dictamen: variante de `CL-06`, no clase nueva.** El microtexto es «embedded information for users» (ISO 26514
3.1.22): información para usuarios, como la ayuda, no código de interfaz. Lo que lo distingue es la **ubicación** y el
**ancla**, no la clase, igual que `CL-06` ya admite dos ubicaciones (`01-Mapa.md:86`).

| Atributo de la pieza | Ayuda de página (hoy) | Microtexto (canal de punto de uso de `CL-06`) |
| --- | --- | --- |
| Dónde vive | Repo de la interfaz, `.md` con frontmatter | En el código o en el recurso de la interfaz (`.resx`, XAML, atributo, JSON Schema) |
| Quién escribe la letra | Autora de ayuda (P) | Autora de ayuda (P); Desarrollo decide la ubicación y la clave (resuelve H07) |
| Ancla | `traces: ID@versión` en la página | Fila de rol `muestra` en la ficha de la regla, `ruta#Clave@SHA` |
| Audiencia | `audience:` de la página | La de la pantalla, por defecto; si la pista cambia por audiencia, una clave por audiencia y la entrega la resuelve el servidor |
| Control | `traces-resolve` | `anclas` (C-AUD-4), y el identificador de contexto resuelve (C-AUD-5) |
| Enlace a ayuda larga | — | Identificador de contexto (`topic` de `ayuda.schema.json:12`, ya usado por `AyudaContextual.razor:12-19`) |

Una clase nueva costaría una fila del catálogo, un tema y un control sin ganar nada que la variante no tenga; la
variante reusa el ancla que ya existe.

### B-05 — Control de desfase

El par rojo/verde ya existe para C#: `RN1` con el 60/80 (`TEM-05:143-154` para trazas). Para microtexto: una ficha
con fila `muestra` sobre una clave `.resx` que afirma `contiene «60»`; rojo si el recurso dice «80». Condición de
bloqueo: la de las anclas hoy (bloquea en lo nuevo).

### B-06 — Por audiencia y por idioma

Una clave por (campo, audiencia) **sólo si el texto cambia**; si no, una. La traducción de un recurso no tiene
`translation_of`: el control de atraso se hace sobre el recurso fuente por commit (`TEM-05:189-196`), **aviso**, no
bloqueo.

### B-07 — Paneles y portales

El patrón industrial es el **identificador de contexto** (DITA `<resourceid>`; Flare *header* y *alias files*): la
interfaz pide «tema para `alta-localidad`» y el sistema de ayuda resuelve tema o microcontenido. La PoC ya lo hace
con `topic` y filtra por rol (`AyudaContextual.razor:18-19`). Propuesta: los identificadores de contexto se registran
como IDs con prefijo propio en el registro de prefijos del proyecto, y DG comprueba que cada uno resuelva, para cada
audiencia que puede ver la pantalla, a un tema o declare «sin ayuda» (C-AUD-5). La integración con un portal de
desarrolladores es de CA-2 y CA-9.

### B-08 — Plataformas de guía en producto

Fuera de mi núcleo (CA-6). Desde la información: el contenido vive en el editor de la plataforma, fuera del
repositorio, sin `traces` ni revisión por PR; para el sistema documentador es una **copia fijada** de contenido
externo que, si se usa, se trata como `CL-11` (vigilada por el carril programado). Sin verificar más allá de la
fuente semilla de Pendo.

### B-09 — Accesibilidad

Es de CA-8. Dato que aporto: el sistema de diseño del PO ya asocia pista y error por `aria-describedby`
(`SDV2:1305-1307`, `:1329-1330`), y la verificación va en las pruebas de la interfaz, no en DG.

### B-10 — Agente en el formulario

Regla de entrega general (A-04): el asistente recibe sólo los temas y el microtexto de la audiencia de su usuario, y
el texto de ayuda es dato, nunca instrucción (`TEM-04` §3.4). El resto es de CA-7.

### B-11 — Implementación .NET

Es de CA-4. Lo que aporto: `DisplayAttribute` ya separa `Name`, `Prompt` y `Description` con `ResourceType`, que es
justo la tríada etiqueta / marcador / pista; si el proyecto los usa, la clave del recurso es el ancla de la fila
`muestra`.

### B-12 — Demo

En PoC-R: un formulario con un campo cuya pista sale de un `.resx` con el límite interpolado desde la constante de la
regla; dos audiencias (alumno y administrador) con pistas distintas; una ficha con filas `muestra` hacia las dos
claves; el par rojo/verde cambiando la constante. Es el 60/80 trasladado a la PoC con roles.

## 5. Propuesta concreta

### 5.1 Definición (para el glosario y el cap. 7 nuevo)

> **Audiencia.** Categoría de personas usuarias, o de agentes que actúan en su nombre, que comparten necesidades,
> tareas y saberes que determinan el contenido, la estructura y el canal de la documentación (ISO/IEC/IEEE 26514,
> 3.1.7, adaptada). No es un permiso: a quién se **entrega** cada pieza lo decide la regla de entrega, y cómo prueba
> el lector que pertenece a una audiencia lo dice su **acreditación**.

### 5.2 Registro de audiencias (artefacto) y campos de frontmatter

Un archivo por proyecto, `docs/_audiencias.md` (`doc_type: registro`, o el que fije A-03), tabla con una fila por
audiencia **[criterio propio, sobre DITA `<audience>` y S1000D ACT/PCT]**:

| Columna | Contenido | Ejemplo |
| --- | --- | --- |
| ID | Prefijo `AUD-` del registro de prefijos | `AUD-ADM-RAIZ` |
| Nombre | En la voz del producto | Administración raíz del panel |
| Tarea y experiencia | Lo que necesita lograr y qué sabe (ISO 26514 6.2.2–6.2.3; DITA `@job`, `@experiencelevel`) | Dar de alta aplicaciones y administradores; experto |
| Roles del producto | Claims tal como los guarda el producto | `RootAdmin` |
| Incluye | Audiencias cuyo contenido hereda (jerarquía de privilegio) | `AUD-ADM-APP` |
| Alcance | `ninguno` · `aplicacion` · `inquilino` (parámetro) | `ninguno` |
| Superficies | `panel` · `movil` · `api` · `servicio` | `panel` |
| Acreditación | `publico` · `sesion` · `credencial` · `interno` | `sesion` |
| Punto de cumplimiento | `build` · `servidor` · `portal` · `repo-privado` | `servidor` |
| Decidió | Persona y fecha; exponer al público una audiencia no pública es H | PO, 2026-11-01 |

Frontmatter (cambia `audience` y suma un campo opcional):

```yaml
[Fragmento ilustrativo: propuesta; los valores son del caso por alias]
audience: [AUD-ADM-APP]        # IDs del registro; antes: humano, agente, roles del equipo
alcance: "{app}"               # opcional: sólo si el contenido depende de una aplicación concreta
superficie: [panel]            # opcional: por defecto, todas las de la audiencia
```

En los documentos del **corpus** (que no son producto) las audiencias son las del equipo (`AUD-DESARROLLO`,
`AUD-ANALISTA`, `AUD-ESTUDIANTE`…), del mismo registro: un solo mecanismo. `roles` de las páginas de ayuda queda como
alias que avisa durante la migración.

### 5.3 Controles verificables en CI

| Control | Qué comprueba | Condición de bloqueo | Par rojo/verde |
| --- | --- | --- | --- |
| C-AUD-1 `audiencia-vocabulario` | Todo valor de `audience` es un ID del registro; toda audiencia del registro tiene acreditación y, si no es pública, punto de cumplimiento | Bloquea en lo nuevo; lo heredado avisa hasta línea de base 0 (`K` D-10) | Rojo: `audience: [admin]` sin fila; verde: `[AUD-ADM-APP]` |
| C-AUD-2 `cruce-de-audiencia` | Si P enlaza a Q, todo lector que recibe P recibe Q: entrega(P) ⊆ entrega(Q), con jerarquía resuelta, alcance y superficie | Bloquea | Rojo: el defecto plantado de PoC-R (`alumno/entregar-trabajo.md` → `administrador/…`); verde: el enlace quitado |
| C-AUD-3 `fuga-a-canal-debil` | Ninguna pieza de una audiencia con acreditación ≠ `publico` aparece en un canal cuyo punto de cumplimiento es más débil (índice público, `llms.txt` público, paquete móvil si la audiencia no es la del móvil) | Bloquea | Rojo: página `AUD-INTEGRADOR` listada en el `llms.txt` público; verde: excluida |
| C-AUD-4 `anclas` extendido a recursos | Las filas `muestra` de una ficha resuelven en `.resx` y JSON Schema, y su valor contiene lo que la ficha afirma | Bloquea, como las anclas de hoy | Rojo: recurso con «80» y ficha que afirma «60»; verde: «60» |
| C-AUD-5 `contexto-resuelve` | Cada identificador de contexto que la interfaz usa resuelve a un tema para cada audiencia que ve esa pantalla, o declara «sin ayuda» | Avisa (depende de leer el código de la interfaz) | Rojo: `topic` sin página; verde: con página |
| C-AUD-6 `traduccion-atrasada` | Traducción o recurso traducido con fuente cambiada después de su commit | Avisa | El de `TEM-05:189-196` |

Quedan en las pruebas del producto: 404 por audiencia y alcance con sesión real; asociación accesible de la pista.

### 5.4 Ejemplo, con el caso por alias

`{servicio-privado}`: `AUD-ADM-RAIZ` (incluye `AUD-ADM-APP`, sesión, servidor), `AUD-ADM-APP` (alcance
`aplicacion`, sesión, servidor), `AUD-USR-MOVIL` (superficie `movil`, sesión, build: el paquete lleva sólo lo suyo),
`AUD-INTEGRADOR` (superficie `api`, credencial, portal; exponerla al público es H), `AUD-OPERADOR` (interno,
repo-privado). Un formulario del panel «Nueva aplicación» con el campo «Nombre»: la pista sale de un recurso con el
límite interpolado de la constante; la ficha de la regla tiene una fila `muestra` a esa clave; `AUD-ADM-RAIZ` y
`AUD-ADM-APP` ven la misma pista; el enlace «¿Cómo se hace?» resuelve por identificador de contexto al tema de
`AUD-ADM-RAIZ` (sólo raíz da de alta aplicaciones), y C-AUD-2 da rojo si un tema de `AUD-ADM-APP` enlaza a él.

## 6. Puntuación de la hipótesis y de las alternativas

Escala anclada y criterios de `Como-Decidir.md` §2–§3; pesos por defecto (`K:296`). Recibí la hipótesis de §6
de `F300` en mi encargo, aunque `F300` §7 dice que las comisiones la reciben en la refutación: lo declaro en §11.

| Opción | Descripción |
| --- | --- |
| **H** (presidencia) | D-18 «Matriz de audiencias y acceso», una fila por audiencia con superficie, rol, alcance, canal, lector y acceso; tabla en el repo; control de cruce de alcance; exposición de API como H; ayuda de campo como canal de `CL-06` con traza en el recurso |
| **A1** (CA-1) | D-18 «Audiencias y entrega» con **dos capas** (comunicación: tarea y experiencia; entrega: rol, jerarquía como inclusión, alcance, superficie, acreditación, punto de cumplimiento); `audience` pasa a IDs del registro y sale el modo de lectura; microtexto como variante de `CL-06` anclado desde la ficha (`muestra`), con DG extendido a recursos; C-AUD-1 a C-AUD-6 |
| **A2** (mínima) | Sin decisión nueva: ampliar D-01 y D-13 con columnas de alcance y acceso en la tabla de §2.3, `alcance` en el esquema de ayuda, y cruce de rol en DG |

| K | H | A1 | A2 |
| --- | --- | --- | --- |
| K1 Simplicidad | 3: decisión, tabla y control (tres piezas) | 3: decisión, registro y extensión de DG (tres piezas; los controles son reglas de una pieza) | 4: un campo y un control |
| K2 Practicidad | 3: paso sin medir; la traza «en el recurso» no tiene mecanismo en DG | 4: medido en copia lo que reusa (filtro de PoC-R, anclas C#/XAML en `DG:571-660`); lo nuevo, sin medir | 3: paso sin medir |
| K3 Escalabilidad | 4: una configuración (tabla) por sistema | 4: una configuración por sistema; la jerarquía como inclusión evita editar páginas (H08) | 2: con listas planas, un nivel nuevo obliga a rehacer páginas (H08) |
| K4 Costo | 3: migración de muchos archivos si `audience` cambia | 3: migración de 283 archivos con `audience` en LD (E1, §2 H02), mecánica | 4: un PR mecánico |
| K5 Doble audiencia | 4: el lector es columna; la entrega a agente no se verifica por control propio | 5: misma fuente, mismo perfil a `llms.txt` y `.md`, con C-AUD-3 | 3: sirve bien a la persona; el agente depende del producto |
| K6 Coherencia | 4: compatible; agrega un sitio para la traza (recurso) que la norma no tiene | 5: reusa tal cual el ancla de ficha de rol `muestra` (`RN1:55-60`) y el `topic` de PoC-R | 4: compatible |
| K7 Deriva | 4: el cruce se detecta en el PR; el desfase regla↔pista, sin mecanismo | 5: cruce, fuga y desfase de la pista deterministas en el PR | 3: cruce sí; pista, a mano |
| **Total ponderado** | 0,15·(3+3+4+4+4+4)+0,10·3 = **3,60** | 0,15·(3+4+4+5+5+5)+0,10·3 = **4,20** | 0,15·(4+3+2+3+4+3)+0,10·4 = **3,25** |

Margen A1 − H = 0,60 (≥ 0,30). Con ±10 % en cada peso el orden no cambia (A1 empata con H en K1 y K4 y lo supera en los otros cinco;
ningún criterio le da ventaja a H). **FIRME** a favor de A1, con la salvedad de que H y A1 comparten casi todo: la
diferencia está en (a) separar comunicación de entrega, (b) la jerarquía como inclusión, (c) sacar el modo de lectura
de `audience`, (d) anclar la pista desde la ficha y no en el recurso.

**Cadena de consecuencias (`CC` §2).** *Dónde cae* A1: en 283 archivos de LD (migración de `audience`) y en DG (un
resolvedor de `.resx` y cuatro reglas). *Cuánto pesa*: la migración es un reemplazo por tabla (valor viejo → ID) en
un PR mecánico; los resolvedores nuevos se miden por el par rojo/verde. *Qué pierde* A2: la jerarquía y la fuga a canal
débil, que son el pedido literal (E-01, E-05). *Qué pierde* H: que «acceso» como propiedad de la audiencia confunde
para quién se escribe con quién recibe, y la traza en el recurso exige un formato que el recurso no tiene.
*Reversibilidad*: A1 es reversible (los IDs se pueden mapear de vuelta); exponer una audiencia restringida no lo es,
y por eso queda H. Condición para revisar el modo de lectura fuera de `audience`: si un proyecto mide un documento
sólo para agentes (no hay ninguno en LD, E1 H02), se reabre.

## 7. Qué rehacer (tabla de §5.3 de F300)

| Pieza | Cambio | Motivo | Costo | Orden |
| --- | --- | --- | --- | --- |
| `SDEI/99-Anexos/Glosario.md` | Entradas «Audiencia», «Entrega», «Acreditación», «Punto de cumplimiento», «Identificador de contexto», «Microtexto»; «Rol» remite a audiencia | H03; A-01 | Bajo | 1 |
| `K` D-01, §2.3, A-03 | D-01 inventaría audiencias (no las deduce); §2.3 cambia la fila «Audiencias» por «Registro de audiencias; típicas: …»; A-03 declara el vocabulario como IDs del registro | H04; A-03 | Medio | 2 |
| `K` D-13 y D-18 nueva | D-18 «Audiencias y entrega» (§5); D-13 suma canales de punto de uso y quita «no se ancla» cuando exista C-AUD-4 | A-12, B-03 | Medio | 2 |
| `K` A-01 (ficha) | Sección de audiencias con el registro y las decisiones H de exposición | A-12 | Bajo | 2 |
| `SDEI/00-Marco.md` §2.5 y §4 | Fila «Audiencias» reescrita; fila «Confidencialidad» de `ESC-SDEI-4` con acreditación; `ACT-SDEI-3` aclara que decide ubicación y clave del microtexto, no su letra | H04, H05, H07 | Bajo | 3 |
| `TEM-04` | Doble audiencia como propiedad del canal; la regla «el agente recibe lo que recibe su usuario» se generaliza | A-04, H02 | Bajo | 3 |
| `TEM-05` | Suma el canal de punto de uso (pista, validación, identificador de contexto) y la jerarquía; el cruce de rol pasa a DG; `ESC-SDEI-4` deja de decir «Nada» | H05, H06, H09, B-04 | Medio | 3 |
| `TEM-06` | C-AUD-1 a C-AUD-6 con su condición de bloqueo y par | A-11 | Medio | 4 |
| `99-Anexos/Esquema-Frontmatter-Y-Prefijos.md` y esquemas de DG | `audience` como IDs; `alcance`, `superficie`; prefijo `AUD-`; registro | H01 | Medio (migración de 283 archivos) | 4 |
| DG | Resolvedor `.resx` y JSON Schema; reglas C-AUD-1 a C-AUD-6 con fixtures | B-03, B-05 | Medio | 4 (expediente de herramienta) |
| `Examples/` | PoC-R extendida (A-15, B-12) | A-15, B-12 | Medio | 5 |
| Libro (`F099` §5.2) | Cap. 7 nuevo «Audiencias»; renumeración; 1.5; 9.x punto de uso; anexos A, C, G (A-13) | H10 | Alto (un lote de redacción) | 6 |
| Oráculos y criterio de caso (`F204`) | Fila de D-18 en los oráculos de los casos afectados; **re-sellar**; criterio de caso sin cambio | A-14 | Medio | Antes del sello de la ronda 3 |

## 8. Riesgos

| Id | Riesgo | Mitigación |
| --- | --- | --- |
| R1 | **Inclusión por defecto.** En DITAVAL lo no declarado se incluye; si la entrega copia esa semántica, toda página sin `audience` restringida se entrega a todos | Por defecto, una página sin audiencia válida no se publica (C-AUD-1 bloquea) |
| R2 | **Filtrar visibilidad creyendo filtrar acceso.** Un filtro de build que deja títulos, etiquetas, índice de búsqueda o mapa del sitio (la advertencia de Sphinx `only`) revela que la página existe | C-AUD-3 mira las salidas, no la fuente |
| R3 | Explosión combinatoria (rol × alcance × superficie × idioma) | Atributos sólo donde el texto cambia; los datos variables (nombre del inquilino, límites contratados) se resuelven en el servidor |
| R4 | La pista larga que reemplaza al tema de ayuda | Regla de una oración (GOV.UK) y el resto por identificador de contexto |
| R5 | Migración de `audience` que cambia 283 archivos y choca con las sesiones que conviven en LD | Un PR mecánico, alias que avisa, línea de base |
| R6 | Normas ISO de pago leídas en su FDIS: el texto publicado puede diferir | Citar la definición con la marca «FDIS» hasta tener la edición publicada |

## 9. Lo que revisé y está bien

1. **Visibilidad y acceso** (`TEM-05:48`, `:103-109`): la distinción y el 404 en lugar del 403 son correctos y son
   la base de la acreditación que propongo.
2. **El mismo filtro para página, `.md` y `llms.txt`** (`TEM-04` §3.5; PoC-R): es lo que la industria del
   *single-sourcing* llama aplicar el mismo perfil a todas las salidas, y está probado.
3. **El ancla de ficha de rol `muestra`** (`RN1:55-60`, `DG:610-680`): ya resuelve, para C# y XAML, el problema que
   el eje B plantea como nuevo.

## 10. Fuentes externas

Todas consultadas el **2026-11-01**.

| Fuente | URL o referencia | Estado |
| --- | --- | --- |
| ISO/IEC/IEEE FDIS 26514, vista previa (definiciones 3.1.7, 3.1.14, 3.1.15, 3.1.22; índice 6.2, 9.4) | https://cdn.standards.iteh.ai/samples/77451/a9685ab90b274ecc9019e7bebe7839e7/ISO-IEC-IEEE-FDIS-26514.pdf | Abierta; texto extraído con `pdftotext`. Es el FDIS, no la edición publicada |
| ISO/IEC/IEEE 26514:2022, ficha de catálogo | https://standards.iteh.ai/catalog/standards/iso/63708794-272a-42ae-be3d-cbdfc0315f7f/iso-iec-ieee-26514-2022 | Por buscador; la página de ISO (https://www.iso.org/standard/77451.html) devolvió 403 |
| ISO/IEC/IEEE 26511:2018 | https://www.iso.org/standard/70879.html | Por resumen del buscador; título y alcance |
| ISO/IEC/IEEE 26512:2017 | https://ebooks.mpdl.mpg.de/ebooks/Record/EB000353258 | Título por catálogo; **contenido sin verificar** |
| ISO/IEC/IEEE 26515:2018 | https://www.iso.org/standard/70880.html | Por resumen del buscador; título, cláusulas, confirmada en 2024 |
| OASIS DITA 1.3, *Conditional processing (profiling)* | https://docs.oasis-open.org/dita/dita/v1.3/os/part1-base/archSpec/base/condproc.html | Abierta |
| OASIS DITA 1.3, `<audience>` | https://docs.oasis-open.org/dita/dita/v1.3/os/part1-base/langRef/base/audience.html | Abierta |
| OASIS DITA 1.3, DITAVAL `<prop>` | https://docs.oasis-open.org/dita/dita/v1.3/os/part1-base/langRef/ditaval/ditaval-prop.html | Abierta |
| OASIS DITA 1.3, *Processing controlled attribute values* | https://docs.oasis-open.org/dita/dita/v1.3/os/part1-base/archSpec/base/processing-controlled-attribute-values.html | Abierta |
| OASIS DITA 1.3, `<resourceid>` | https://docs.oasis-open.org/dita/dita/v1.3/os/part1-base/langRef/base/resourceid.html | Abierta |
| Adobe, FrameMaker S1000D, *Applicability and S1000D Common Source Data* | https://help.adobe.com/en_US/framemaker/s1000d/WS9ad62b8fb4f8a997-577b0a7d12e234e8c0d-8000.html | Abierta; documentación de proveedor, no la especificación |
| PTC, Windchill, *S1000D applicability* | https://support.ptc.com/help/wnc/r11.2.0.0/en/Windchill_Help_Center/s1000d_solution_applicability_dm.html | Por buscador; proveedor |
| MadCap Flare 2026, *Header Files* | https://help.madcapsoftware.com/flare2026/Content/Flare/Step2-Authoring/CSH/General-Information/Header-Files.htm | Abierta |
| MadCap Flare 2025, *Micro Content Editor* | https://help.madcapsoftware.com/flare2025/Content/Flare/Interface-Files/Editors/Micro-Content-Editor/Micro-Content-Editor.htm | Abierta |
| Sphinx, *Directives* (`only`) | https://www.sphinx-doc.org/en/master/usage/restructuredtext/directives.html | Abierta |
| Diátaxis | https://diataxis.fr/ | Abierta |
| GOV.UK Design System, *Text input* | https://design-system.service.gov.uk/components/text-input/ | Abierta (fuente semilla de `F300`, reabierta) |
| Microsoft Learn, `DisplayAttribute` | https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.displayattribute | Abierta (actualizada 2026-05-27) |
| JSON Schema, *Annotations* | https://json-schema.org/understanding-json-schema/reference/annotations | Abierta |
| Ede, L. y Lunsford, A. (1984). Audience Addressed/Audience Invoked: The Role of Audience in Composition Theory and Pedagogy. *College Composition and Communication*, 35(2), 155–171 | Datos bibliográficos confirmados por fuentes secundarias (buscador); **texto original no leído** | Parcial |
| Hackos, J. T. y Redish, J. C. (1998). *User and Task Analysis for Interface Design*. Wiley. ISBN 0-471-17831-4 | Datos de catálogo de biblioteca | Datos verificados; contenido no |
| Pendo, *Take a tour of Pendo* | https://support.pendo.io/hc/en-us/articles/20826000368411-Take-a-tour-of-Pendo | **No reabierta** por esta comisión: fuente semilla de `F300` §8 |
| llmstxt.org | https://llmstxt.org/ | **No reabierta**: fuente semilla de `F300` §8 |

## 11. Solicitudes de convocatoria, excepciones e incidencias

**Solicitudes de convocatoria.** Ninguna nueva: lo que no es mío ya tiene comisión (CA-2 portales, CA-3 acceso,
CA-4 .NET, CA-6 y CA-8 microtexto y guías, CA-7 agentes, CA-9 integración).

**Excepciones a conocimientos.** Ninguna: no propongo dejar de seguir una convención que rige.

**Incidencias.**

- **La hipótesis me llegó antes de la refutación.** `F300` §7 dice que las comisiones no leen la propuesta de §6 antes
  de entregar; mi encargo me pidió puntuarla. Lo hice, y lo declaro para que la refutación pese la coincidencia o
  diferencia con ese conocimiento previo.
- **Carta no recibida.** No tuve la carta de `MEP` §5.2 archivada en `evidencia/`; trabajé con el encargo de la
  presidencia y fijé la lectura de P0–P3 en la cabecera.
- **Normas ISO de pago.** 26514 por su FDIS; 26511, 26512 y 26515 por resúmenes o catálogos. Ninguna cláusula
  normativa citada con número de apartado salvo las definiciones de 26514 que leí.
- **S1000D** sólo por documentación de proveedores.
- **`K` cambió mientras trabajaba.** Lo leí con 649 líneas y al cerrar tenía 698 (versión 1.2, SHA-256 que empieza
  con `cd9eec3fd22df594`). Rehíce las citas `K:` de D-01, D-13 y los pesos contra la versión de 698 líneas; §2.3
  (`K:170`) y el vocabulario (`K:438-445`) no se movieron.
- Mensajes de otras sesiones durante el trabajo: ninguno.

## 12. Barrido de lo privado

Se buscaron en este folio nombres de máquina, rutas absolutas del sistema de archivos y el nombre real del servicio
privado. El servicio va como `{servicio-privado}`; los repositorios y archivos, por alias (`SDEI/`, `K`, LD, DG,
PoC-R, RN1, SDV2) o por ruta relativa al repositorio. Resultado esperado del comando de barrido sobre este archivo:
0 coincidencias.
