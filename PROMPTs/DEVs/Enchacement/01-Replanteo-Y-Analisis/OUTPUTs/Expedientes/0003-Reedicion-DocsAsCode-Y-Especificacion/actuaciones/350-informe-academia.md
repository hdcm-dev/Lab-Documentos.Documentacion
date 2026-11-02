---
doc_id: EXP0003-F350
doc_type: informe
title: Informe de la comisión CA-5 (academia — retórica, comunicación técnica y estudios de documentación) sobre audiencias y ayuda en el punto de uso
status: vigente
origin: agent
confidence: alta en lo medido sobre el cuerpo (comandos del 2026-11-01 con su salida) y en las referencias bibliográficas verificadas en registro el 2026-11-01; media en las posiciones de diseño, rotuladas «criterio propio» donde no hay fuente; las referencias marcadas «sin verificar» no sostienen ninguna posición por sí solas
owner: comisión CA-5 del ciclo 3 de la mesa de la reedición DocsAsCode (expediente 0003); se disuelve al veredicto
last_review: 2026-11-01
audience: [presidencia, refutador, análisis de decisiones, jurado del ciclo 3, PO]
traces: [EXP0003-F300, EXP0003-F099, EXP0003-F204]
---

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-01 |
| Autor | Comisión CA-5, academia: retórica y comunicación técnica, estudios de documentación. A ciegas |
| Corrige | — |

| Cabecera de comisión | Valor |
| --- | --- |
| Preguntas a cargo | A-01, A-02, A-03, A-04 (`F300` §7). Contesto además las demás A-nn y B-nn desde la especialidad, más corto, y remito a la comisión dueña donde no es mi competencia |
| No-competencia | Implementación .NET, control de acceso como mecanismo, portales comerciales y sistemas de diseño como producto: lo que vi ahí va como remisión, no como hallazgo |
| Norma | `IA.Knowledge.Base/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` 3.1 |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Líneas 1-111 (cabecera y §0, fila «Sos una comisión»); §2.2; §3.3; §5.2 (esqueleto de la carta). §3.2 y §4 leídas sólo en la porción que listan sus encabezados |
| Otros documentos cargados | `Cadena-De-Consecuencias` 2.0 §2; `SDEI/99-Anexos/Como-Decidir.md` §1-§4 (criterios K1-K7, escala anclada y pesos) |
| Insumos leídos | `F300` entero; `SDEI/00-Marco.md` §2.5 y §4; `SDEI/TEM-04` Definición y Aplicación por escenario (l. 33-101) y §3.5; `SDEI/TEM-05` Definición, Aplicación por escenario, §3.3, §3.4 y Anexo; `SDEI/99-Anexos/Glosario.md` (filas Actor, Rol, RRD); `SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md` l. 53; `SDEI/99-Anexos/Referencias.md` (Aghajani, Carroll, van der Meij, ISO 26514); `tools/docs-guard/esquemas/ayuda.schema.json`; frontmatter de `Examples/Prueba-Ayuda-Por-Rol/`; `K` 1.2 §2.3 y D-01 a D-17; `F099` §5.2.1; `F204` índice y §7. No leí informes de otras comisiones |
| Medios | `grep`, `sed`, `wc` de sólo lectura sobre `LD` en `00171bd`; WebSearch y WebFetch el 2026-11-01 (§8) |

**Convención de citas.** Como en `F300`: `SDEI/` = el cuerpo en `00171bd`; `K` = el conocimiento 1.2; lo privado,
por alias. Fecha de consulta de toda URL de este folio: 2026-11-01. «V» = verificado en registro bibliográfico o en
la fuente; «S» = sólo por fuente secundaria; «sin verificar» = no lo pude confirmar hoy.

**Lectura P0–P3 para este caso.** P0: la decisión haría que se entregue documentación restringida, o que la norma
defina «audiencia» de un modo que su propio control contradiga. P1: el concepto queda mal partido y obliga a rehacer
cuerpo, conocimiento u oráculos después de `F399`. P2: imprecisión que confunde al lector o a quien adopta. P3:
estilo o referencia incompleta.

## Índice

1. [Lectura del objetivo desde la academia](#1-lectura-del-objetivo-desde-la-academia)
2. [Estado del arte académico](#2-estado-del-arte-académico)
3. [Hallazgos](#3-hallazgos)
4. [Dictamen por pregunta — eje A](#4-dictamen-por-pregunta--eje-a)
5. [Dictamen por pregunta — eje B](#5-dictamen-por-pregunta--eje-b)
6. [Puntuación de la hipótesis y de las alternativas](#6-puntuación-de-la-hipótesis-y-de-las-alternativas)
7. [Qué rehacer (tabla de §5.3)](#7-qué-rehacer-tabla-de-53)
8. [Fuentes](#8-fuentes)
9. [Lo que revisé y está bien](#9-lo-que-revisé-y-está-bien)
10. [Remisiones, excepciones, lo no verificado e incidencias](#10-remisiones-excepciones-lo-no-verificado-e-incidencias)
11. [Barrido de lo privado](#11-barrido-de-lo-privado)

---

## 1. Lectura del objetivo desde la academia

El PO encontró «el término correcto» (`F300` §2.1). La academia le da la razón en el término y le advierte sobre el
alcance: en retórica y comunicación técnica, **audiencia** nombra a quién está dirigido un texto y cómo el texto
construye a ese lector; **no** nombra quién tiene derecho a recibirlo. Lo segundo es una política de entrega. El
pedido del PO trae las dos cosas juntas («todos ven documentación diferente — incluso alcances diferentes»; «no
quiera hacer pública por razones de seguridad»), y el cuerpo SDEI **ya las separa de hecho** en dos campos
(`audience` y `roles`, §3 H-02). Mi lectura: el ciclo tiene que nombrar las dos y relacionarlas, no fundirlas en una
fila.

**Lo que se da por fijo sin origen** (primer hallazgo exigido por la carta): que el nivel de acceso es una dimensión
de la audiencia. No sale del pedido (el PO lo plantea como razón de seguridad, no como rasgo del lector) ni de la
literatura de audiencia; entra en la hipótesis de `F300` §6.1 como columna de la misma fila. Lo trato en H-03.

## 2. Estado del arte académico

### 2.1 La audiencia en retórica y comunicación técnica

| Fuente | Qué aporta al ciclo | V/S |
| --- | --- | --- |
| Ong (1975) | «El público del escritor es siempre una ficción»: quien escribe construye un papel para el lector y el lector real se ficcionaliza para encajar en él. En documentación: la página **invoca** un lector (lo que sabe, lo que quiere hacer, cómo se le habla) aunque la entregue un servidor a otra persona | V (registro y resumen de Cambridge Core) |
| Ede y Lunsford (1984) | Dos tradiciones: **audiencia dirigida** (*addressed*), la realidad concreta de los lectores, que se analiza; y **audiencia invocada** (*invoked*), la que el texto construye con sus marcas. Piden sostener las dos a la vez | V (registro; contenido por fuentes secundarias concordantes) |
| Porter (1992) | La audiencia como comunidad discursiva: un grupo que comparte convenciones y conocimientos, no un individuo | V (registro de catálogo) |
| Johnson (1997) | Tercera figura, **audiencia involucrada**: el usuario participa en la producción (pruebas de usabilidad, devoluciones). Es la que justifica el canal de devolución de la ayuda | V (registro y resumen de ScienceDirect por fuentes) |
| Mathes y Stevenson (1976) | Audiencias **primaria** (actúa o decide), **secundaria** (la afectan) e **inmediata** (la que hace circular el texto); «la persona a la que se dirige no siempre es la audiencia real» | S (catálogo de la obra y diapositivas de curso que la siguen) |
| Schriver (1997) | Diseño documental centrado en el lector; la evidencia de cómo leen las personas reales como insumo del diseño. La tipología de tres modelos de análisis de audiencia (por clasificación, por intuición, por devolución) se le atribuye a menudo | V la obra (ISBN 0-471-30636-3); **sin verificar** la atribución de la tipología: la encontré sin nombre de autor |
| Hackos y Redish (1998) | Análisis de usuarios, de tareas y del **entorno** como tres insumos del diseño. El entorno es la base académica de la dimensión «superficie» | V (registro de Wiley y catálogos) |
| Redish (2012) | Contenido como conversación; planificación por propósitos, *personas* y conversaciones (cap. 2) | V (tabla de contenido en catálogo) |
| ISO/IEC/IEEE 26514:2022 | Ya citada en el cuerpo (`SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:37-39`): la información para usuarios se diseña con análisis de audiencia y de tareas | V en `Referencias.md:84` (2026-10-26); la página de ISO devolvió 403 hoy |

### 2.2 *Personas* y su límite

| Fuente | Qué aporta | V/S |
| --- | --- | --- |
| Pruitt y Grudin (2003) | El valor mayor de las *personas* es dar una base compartida para la comunicación del equipo | V (Microsoft Research) |
| Matthews, Judge y Whittaker (2012) | 14 profesionales con experiencia: usaban las *personas* «casi exclusivamente para comunicar, no para diseñar»; las encontraron abstractas, impersonales, engañosas y distractoras; «no pueden reemplazar la inmersión en datos reales de usuarios» | V (texto completo, resumen leído) |

Consecuencia: una *persona* no sirve como clave de filtrado ni como dimensión; sirve, si acaso, para explicar una
audiencia al equipo.

### 2.3 El lector activo y la ayuda en el punto de uso

| Fuente | Qué aporta | V/S |
| --- | --- | --- |
| Carroll y Rosson (1987) | **Paradoja del usuario activo**: se pone a trabajar sin leer, aunque aprender primero le ahorraría tiempo | V (registro; pp. 80-111) |
| Carroll y Carrithers (1984) | «Rueditas»: bloquear estados de error del novato; el grupo con la interfaz reducida fue 21 % más rápido. Antecedente de la divulgación progresiva por **pericia** | V (CACM 27(8), 800-806, doi 10.1145/358198.358218) |
| Carroll (1990); Carroll, ed. (1998) | Minimalismo: orientarse a la acción, anclarse en la tarea, apoyar el reconocimiento y la recuperación del error | 1990: P en `Referencias.md:76`; 1998: V (registro, MIT Press) |
| van der Meij y Carroll (1995) | Principios y heurísticas del minimalismo, entre ellos dar información de error que sirva para detectar, diagnosticar y recuperar | P en `Referencias.md:78`; heurísticas S |
| Novick y Ward (2006) | 25 entrevistas: la gente evita el manual en papel y la ayuda en línea; resuelve preguntando a un colega o probando | V (registro de la UTEP; doi 10.1145/1166324.1166329 por IxDF, **sin verificar en ACM**) |
| Ellison (2007) | **Ayuda incrustada** (*embedded user assistance*): sus beneficios los mostraron las pruebas de usabilidad desde hace años, pero se implementaba poco | V (ACM *interactions* 14(1), 30-31, extracto) |
| Grayling (2002) | Prueba de usabilidad de dos sistemas de ayuda incrustada en navegador | V la referencia (*Technical Communication* 49(2), 193-209); **sin verificar** sus resultados |
| Seckler, Heinz, Bargas-Avila, Opwis y Tuch (2014) | 65 participantes con seguimiento ocular: los formularios mejorados con 20 pautas (contenido, disposición, tipos de campo, manejo de errores, envío) se completaron más rápido, con menos intentos y más satisfacción | V (CHI 2014, 1275-1284, doi 10.1145/2556288.2557265) |
| Spinuzzi (2003) | **Ecologías de géneros**: los trabajadores inventan géneros no oficiales (notas, atajos) alrededor del sistema; el análisis tiene que seguirlos | V (MIT Press; reseñas concordantes) |

### 2.4 Necesidades del lector y *docs as code*

| Fuente | Qué aporta | V/S |
| --- | --- | --- |
| Diátaxis (Procida, s. f.) | Cuatro necesidades: aprender («¿me enseñás a…?»), lograr un objetivo («¿cómo hago…?»), informarse («¿qué es…?»), entender («¿por qué…?»); fases de aprendizaje y de trabajo | V (diataxis.fr y /map/) |
| Gentle (2017; 3.ª ed. 2022) | Libro de práctica de *docs as code*; Lulu; licencia CC BY-SA 4.0 en la 1.ª ed. | V (catálogos); autoría de la 3.ª ed. **sin verificar** |
| Cadavid, Andrikopoulos y Avgeriou (2022) | Investigación-acción técnica: un *pipeline* de documentación como código para documentos de control de interfaces en un sistema de sistemas, evaluado por practicantes (ECSA) | V (arXiv 2206.11668) |
| Aghajani et al. (2019; 2020) | Ya en el cuerpo: desactualización, incorrección e incompletitud entre los problemas del contenido | V en `Referencias.md:56-58` |

**Hueco de la literatura.** No encontré hoy ningún trabajo académico sobre *docs as code* con entrega diferenciada
por audiencia ni sobre microtexto de formulario versionado con la especificación (búsqueda del 2026-11-01:
«docs-as-code academic paper documentation as code empirical study»; los resultados fueron Cadavid et al., un
artículo de revista sobre la industria automotriz y un relevamiento en ruso). Es «sin evidencia hallada», no
«no existe». Lo que la academia sí sostiene, y con fuerza, es el **porqué** del eje B: la gente no lee el manual
(Carroll y Rosson; Novick y Ward), así que la documentación que se lee es la que está en el punto de uso (Ellison;
Seckler et al.).

## 3. Hallazgos

| Id | Nivel | Ancla | Hallazgo | Impacto si no se corrige | Dirección |
| --- | --- | --- | --- | --- | --- |
| H-01 | P1 | E1: `SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:53`; `grep -rhoE '^audience: \[.*\]'` sobre `SDEI/` da 30 archivos y 7 de ellos listan `[humano, agente, estudiante, docente, desarrollo, analista, po]` | El campo `audience` mezcla tres ejes: modo de lectura (`humano`, `agente`), destinatario (`estudiante`, `persona-usuaria`) y actor del sistema documentador (`po`, `analista`), que el glosario manda no confundir con un rol (`Glosario.md:43`). Con siete valores en la cuarta parte de los archivos, no discrimina | Si la decisión de audiencias se monta sobre este campo, hereda la mezcla y el control de «vocabulario cerrado» pasa en verde sin decir nada | Partir el campo: el modo de lectura sale a un campo propio o se da por defecto; `audience` lista audiencias del registro del proyecto |
| H-02 | P1 | E1: `tools/docs-guard/esquemas/ayuda.schema.json:10`, `:16`; `Examples/Prueba-Ayuda-Por-Rol/Web/Ayuda/es/administrador/gobernar-las-cuentas.md:4`; `SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:48` | El cuerpo ya tiene **dos planos** de hecho: `audience` («a quién sirve; ordena las rutas de lectura») y `roles` (qué entrega el servidor). Las páginas de ayuda de la prueba de concepto llevan `roles` y no `audience` | La hipótesis de `F300` §6.1 pone destino y acceso en la misma fila; sin nombrar los dos planos, «el raíz puede leerla» se confunde con «está escrita para el raíz» | Formalizar los dos planos que ya existen (§4, A-01 y A-05) |
| H-03 | P1 | E2: Ong (1975); Ede y Lunsford (1984) | En la literatura, audiencia es destinatario (dirigido o invocado); el derecho a recibir no es un rasgo del lector sino una política. El nivel de acceso entra en la hipótesis como dimensión sin origen | Una definición que mete el acceso en la audiencia no se puede verificar con lectura (P-LECT) ni con control de acceso a la vez | Definición en dos términos: **audiencia** y **regla de entrega** |
| H-04 | P2 | E1: `SDEI/TEM-04-Doble-Audiencia.md:35`; `F099` §5.2.1, Parte III, cap. 7 | «Doble audiencia» nombra el modo de lectura (persona o agente), no una audiencia. Con el ciclo 3, el término queda ambiguo: el administrador raíz y su agente son una audiencia leída de dos modos | El lector del libro buscará «audiencias» y encontrará sólo humano/agente | El modo de lectura pasa a dimensión; el tema se renombra (A-04) |
| H-05 | P2 | E1: `Glosario.md` no tiene fila «Persona» (`grep -n Persona Glosario.md` da 0 líneas); E2: Matthews et al. (2012) | Si el ciclo introduce *personas* sin definir su papel, alguien las usará como clave de filtrado | Filtrado por un arquetipo narrativo, no por atributos verificables | Fila de glosario: la *persona* explica una audiencia; nunca la filtra |
| H-06 | P1 | E1: `SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:271-277` | La plantilla de ayuda ya trae «Qué pide cada campo» (campo, qué escribir, ejemplo) y «Si algo sale mal» con el **mensaje literal**: el microtexto del formulario ya se copia en la página. Con el eje B, ese texto vive en dos fuentes (recurso del formulario y página) | Deriva entre la ayuda del campo y la página; es la misma clase de defecto que `TEM-05` §3.2 detecta para la regla | Que la tabla de la página se **derive** de la misma fuente que el campo (B-02, B-04) |
| H-07 | P2 | E1: `SDEI/99-Anexos/Como-Decidir.md`, tabla de §2, fila K5 «Doble audiencia» | La escala de decisión mide sólo el eje humano/agente; no tiene un observable para «la alternativa distingue destino de entrega» | Las alternativas del ciclo 3 empatan en K1-K7 aunque difieran en lo que el PO pidió (§6) | Ampliar K5 a «Audiencias» con anclas nuevas, o declarar el empate como decisión con revisión |
| H-08 | P2 | E2: Carroll y Carrithers (1984); Carroll y Rosson (1987) | La **pericia** (novato, habitual, experto) es la dimensión de audiencia con más evidencia en ayuda incrustada, y no figura en el pedido ni en la hipótesis | El texto de campo escrito para el experto deja al novato sin guía, y al revés | Dimensión **opcional**, marcada como agregado (no sale del pedido) |

## 4. Dictamen por pregunta — eje A

### A-01 Definición y término (a cargo)

**Término:** «audiencia», en singular para la clase y en plural para el registro. Lo sostiene la tradición
retórica (Ong; Ede y Lunsford) y la norma de información para usuarios (ISO/IEC/IEEE 26514, análisis de audiencia).
«Público destinatario» queda como sinónimo de lectura, no como término.

**Definición propuesta** [criterio propio, construido sobre Ede y Lunsford, Hackos y Redish, y `TEM-05` l. 48]:

> **Audiencia**: grupo de lectores para el que una pieza está escrita, caracterizado por los atributos que comparten
> frente a la documentación (rol con su nivel, alcance, superficie desde la que leen, modo de lectura e idioma). Se
> nombra con un identificador del registro de audiencias del proyecto. **No es un permiso.**
>
> **Regla de entrega**: qué audiencias pueden **recibir** una pieza, con qué nivel de acceso y en qué lugar se hace
> cumplir (servidor, portal, repositorio, build). Una pieza tiene una audiencia primaria y puede tener audiencias
> secundarias que la reciben sin ser su destino.

| Término | Qué es | Diferencia con «audiencia» | Fuente |
| --- | --- | --- | --- |
| Lector | Una persona o un agente concreto que lee | La audiencia es la clase; el lector, un miembro (la «audiencia dirigida» de Ede y Lunsford en su caso individual) | Ede y Lunsford (1984) |
| Audiencia invocada | El lector que el texto construye: qué presupone, cómo le habla | Es la audiencia vista desde el texto; se verifica leyendo (P-LECT), no con un control | Ong (1975); Ede y Lunsford (1984) |
| *Persona* | Arquetipo narrativo de UX | Explica una audiencia al equipo; no se filtra por ella | Pruitt y Grudin (2003); Matthews et al. (2012) |
| Rol | Perfil de permisos del producto (`Glosario.md:86`) | Es **una coordenada** de la audiencia, no la audiencia | `TEM-05` l. 46 |
| Actor | Quien interviene en el sistema documentador (`ACT-SDEI-1..6`) | Un actor puede ser lector de algunas piezas, pero no es una audiencia del producto | `Glosario.md:43` |
| Escenario | Tipo de proyecto (`ESC-SDEI-1..4`) | Sugiere audiencias típicas; no las fija | `00-Marco.md:108` |

### A-02 Dimensiones (a cargo)

| Dimensión | Clase | Obligatoria cuando | Fuente o razón |
| --- | --- | --- | --- |
| Rol, con su nivel en la jerarquía | Ortogonal | El producto tiene más de un rol con permisos distintos (`ESC-SDEI-3`, `{servicio-privado}`) | Pedido del PO (E-01); `TEM-05` l. 46 |
| Alcance (aplicación, inquilino) | Ortogonal | El mismo rol administra cosas distintas (E-04) | Pedido del PO |
| Superficie (panel, móvil, API, servicio) | Ortogonal | Hay más de una superficie (E-02, E-03) | Hackos y Redish (1998): el entorno del usuario |
| Modo de lectura (persona, agente) | Ortogonal; por defecto, los dos | Siempre; sólo se declara si una pieza excluye uno | `TEM-04` |
| Pericia (novato, habitual, experto) | Ortogonal, **opcional** | Sólo si el proyecto escribe ayuda distinta por pericia | Carroll y Carrithers (1984). **Agregado**: no sale del pedido |
| Idioma | Derivada: la fija la sesión, no la audiencia | — | `TEM-05` §3.4 |
| Canal (página, campo, portal, `llms.txt`, paquete) | Derivada: superficie × modo de lectura | — | `TEM-04` l. 41 |
| Nivel de acceso | **No es dimensión**: lo fija la regla de entrega | Siempre que una pieza no sea pública | H-03 |
| Necesidad (aprender, lograr, consultar, entender) | **No es de la audiencia**: es de la pieza | — | Diátaxis: la misma audiencia tiene las cuatro necesidades en momentos distintos |

### A-03 Relación con rol, *persona* y escenario (a cargo)

- El rol es una coordenada; la audiencia es la combinación que el proyecto **decide documentar**. No toda
  combinación de rol × alcance × superficie es una audiencia: lo es la que tiene una necesidad documental propia
  (criterio del PO: «cada uno con necesidades documentales diferentes»).
- La *persona* se admite como anexo explicativo de una audiencia, nunca en el frontmatter.
- La fila «Audiencias» de `00-Marco.md:108` **no se reemplaza**: pasa a llamarse «Audiencias típicas» y queda como
  punto de partida, igual que las clases activas por defecto (`K` §2.3). La decisión del proyecto es nueva (A-12).

### A-04 Doble audiencia (a cargo)

- El modo de lectura pasa a **dimensión de toda audiencia**. Con Ong: el agente que lee por una persona se
  ficcionaliza en el lector que la página invoca; por eso **hereda la audiencia y la entrega de su usuario, nunca
  más** (lo mismo que hoy hace la prueba de concepto con el `llms.txt`, `TEM-04` §3.5).
- `TEM-04` sigue como tema, porque lo que trata (canales para agentes, anti-inyección) no cabe en una dimensión. Se
  renombra «Lectura por agentes» [criterio propio]; «doble audiencia» queda en el glosario como nombre anterior.
- Capítulo 7 del libro: «Audiencias» (nuevo, A-13); el actual pasa a 8 «Lectura por agentes».

### A-05 Jerarquía de privilegio

Con Mathes y Stevenson: la página para el administrador de aplicación tiene a ese administrador como audiencia
**primaria**; el raíz es audiencia **secundaria**: puede recibirla, no es su destino. Regla [criterio propio]:
**la entrega se hereda hacia arriba; el destino no**. Consecuencias verificables: (1) cada página declara una sola
audiencia primaria; (2) un enlace de una página a otra es válido si toda audiencia que recibe la de origen también
recibe la de destino (generalización del cruce de rol de `TEM-05` l. 181). El mecanismo de herencia es de CA-3.

### A-06 Acceso y visibilidad

Lo académico ya está en el cuerpo y está bien (`TEM-05` l. 48). Aporte: el nivel de acceso pertenece a la regla de
entrega (A-01). Cómo se prueba la no entrega: CA-3 y CA-4.

### A-07 Documentación de API restringida

Desde la retórica: la documentación para integradores invoca a otro lector (desarrollador ajeno); su exposición es
decisión de una persona (clase H), coincido con `F300` §6.4. El mecanismo de portal: CA-2.

### A-08 Alcance

El alcance distingue entrega, rara vez destino: dos administradores de aplicaciones distintas son la misma audiencia
invocada (mismo texto) con **datos** distintos. Recomendación [criterio propio]: el alcance va en la regla de entrega y
en los ejemplos, no multiplica páginas salvo que la necesidad documental cambie.

### A-09 Varias superficies

Una sola fuente con salidas por superficie (Hackos y Redish: el entorno cambia la presentación, no la tarea). Lo que
viaja en el paquete móvil: CA-4 y CA-9.

### A-10 Agente por audiencia

Ver A-04: el agente hereda la audiencia y la entrega de su usuario. Mecanismo: CA-7.

### A-11 Controles en CI

Desde la especialidad propongo tres, con su par rojo/verde [criterio propio]:

| Control | Rojo | Verde | Bloquea |
| --- | --- | --- | --- |
| `audiencia-vocabulario` | Una página lista en `audience` un valor que no está en el registro del proyecto | Todos los valores resuelven | Sí, en carpetas nuevas; avisa en lo heredado (como `K` D-08) |
| `audiencia-primaria` | Una página de producto no declara audiencia primaria, o declara más de una | Una sola | Sí en ayuda (`CL-06`) |
| `cruce-de-entrega` | Un enlace lleva a una página que alguna audiencia de origen no recibe | Ninguno | Sí; generaliza el cruce de rol |

La audiencia invocada (que el texto le hable al lector correcto) **no** es controlable por CI: se verifica con
P-LECT por audiencia primaria (`Glosario.md:80`), y la devolución de usuarios reales es la «audiencia involucrada»
de Johnson (1997).

### A-12 Ficha A-01 y oráculos

Decisión nueva en `K` (D-18 «Audiencias y entrega»), con dos tablas: el registro de audiencias (identificador,
rol y nivel, alcance, superficie, modo de lectura, pericia opcional) y las reglas de entrega (audiencia, nivel de
acceso, dónde se hace cumplir). D-13 pasa a remitir a D-18. El vocabulario de A-03 se cierra con el registro.

### A-13 Libro

Parte III «Audiencias y canales»: cap. 7 nuevo «Audiencias» (definición y distinciones de A-01, dimensiones, registro y
entrega, jerarquía, ejemplo del `{servicio-privado}` por su forma); cap. 8 «Lectura por agentes» (ex-7); cap. 9 «Ayuda
al usuario final y en el punto de uso» (ex-8, con formularios). Renumeración del resto.

### A-14 Ensayos

Sólo los oráculos de casos cuyo proyecto tiene roles o más de una superficie necesitan filas de D-18; esos se
re-sellan. El criterio de caso de `F204` no cambia por esto [criterio propio; no medí qué casos tienen roles].

### A-15 Ejemplo

Extender `Prueba-Ayuda-Por-Rol` (es el caso que funciona, `F300` §3): sumar un segundo nivel de administrador, dos
alcances y un formulario (B-12). Armar otro duplica el andamiaje.

## 5. Dictamen por pregunta — eje B

### B-01 Mecanismos de microtexto

La academia explica por qué importan: el usuario activo no abre el manual (Carroll y Rosson, 1987; Novick y Ward,
2006), la ayuda incrustada se lee donde está la tarea (Ellison, 2007), y mejorar el formulario —incluido el manejo
de errores— se mide en tiempo, intentos y satisfacción (Seckler et al., 2014). El mensaje de validación es, para el
minimalismo, la pieza más valiosa: apoya el reconocimiento y la recuperación del error (van der Meij y Carroll,
1995). Recomendaciones de sistemas de diseño (pista, marcador, error): CA-8.

### B-02 Fuente única regla ↔ texto

Principio [criterio propio, desde `TEM-05` «derivar no es generar»]: **los números se interpolan, la prosa se
escribe**. El límite, el formato y la obligatoriedad salen de la regla por parámetro (no se copian); la frase que
le explica al usuario qué escribir se escribe para la audiencia invocada, con traza a la regla. Generar la prosa de
la anotación de validación produce texto dirigido al sistema, no al lector (Ong: el texto invoca a quien no lee).

### B-03 Traza del texto de campo

Mecanismo: CA-4 y CA-8. Condición académica: la traza tiene que llegar al texto que lee la persona, no sólo a la
regla, porque lo que se desactualiza es la frase (Aghajani et al., 2019).

### B-04 Clase de pieza

Variante de `CL-06`, canal «punto de uso»; no clase nueva. Con Spinuzzi (2003): ayuda de página, ayuda de campo y
mensaje de error son géneros de una misma ecología alrededor de la tarea; separarlos en clases distintas rompe la
traza común. Vive con la interfaz; su ancla es la traza a la regla; su control, el de B-05. La tabla «Qué pide cada
campo» de la página (`TEM-05` l. 271) pasa a **derivarse** del mismo recurso (H-06).

### B-05 Control de desfase

Con B-02, el desfase numérico desaparece por construcción; queda el de la prosa, que detecta la traza con versión
como hoy (`TEM-05` §3.2). Par rojo/verde: CA-4 y CA-8.

### B-06 Por audiencia y por idioma

Advertencia académica: la gente resuelve preguntando a un colega (Novick y Ward, 2006). Si el mismo campo dice cosas
distintas a dos roles, la ayuda entre pares se rompe. Recomendación [criterio propio]: **etiqueta y mensaje de error
iguales para todas las audiencias**; sólo la ayuda ampliada puede variar, y sólo si la necesidad cambia. Idioma:
`TEM-05` §3.4.

### B-07 Paneles y portales

La ayuda incrustada (Ellison, 2007) es la forma académica del patrón. Identificadores de contexto, portales y
*widgets*: CA-6 y CA-9.

### B-08 Plataformas de guía en producto

Lo que ganan, en términos académicos, es la audiencia involucrada (Johnson, 1997): miden qué se usa. Lo que pierden
frente a *docs as code*: traza, revisión por PR y versión. No verifiqué hoy dónde vive su contenido: CA-6.

### B-09, B-10, B-11, B-12

B-09 (accesibilidad): CA-8. B-10 (agente en el formulario): vale A-04, el agente hereda la audiencia del usuario;
riesgos y control, CA-7. B-11 (.NET): CA-4. B-12: un formulario en la prueba de concepto extendida (A-15), con una
regla cuyo límite se interpola en la pista, en el mensaje y en la tabla de la página, y un rojo cuando la regla sube
de versión.

## 6. Puntuación de la hipótesis y de las alternativas

Escala, pesos y filtros de `SDEI/99-Anexos/Como-Decidir.md` §2-§4 (K1, K2, K3, K5, K6, K7: 0,15; K4: 0,10). Ninguna
alternativa cae en un filtro duro.

| Alternativa | Qué es |
| --- | --- |
| H | Hipótesis de `F300` §6: matriz con acceso en la misma fila, D-18, control de cruce de alcance, API como H, ayuda de campo como canal de `CL-06` |
| A1 | **H enmendada en dos planos** (propia): D-18 con registro de audiencias y reglas de entrega separados; `audience` cerrado al registro (lo heredado avisa), modo de lectura por defecto; audiencia primaria única; entrega hereda hacia arriba, destino no |
| A2 | Mínima (propia): ampliar D-13 y la fila del Marco con las dimensiones, sin decisión nueva ni registro |
| A3 | Perfilado condicional al estilo DITA (`@audience` y DITAVAL, OASIS DITA 1.3): un build por audiencia y acceso por despliegue |

| K | H | A1 | A2 | A3 |
| --- | --- | --- | --- | --- |
| K1 Simplicidad | 3: tabla, `doc_type` y control | 3: la misma tabla en dos secciones, un campo cerrado, dos controles | 4: un campo más en D-13 | 2: herramienta de perfilado nueva |
| K2 Practicidad | 3: el filtro por rol está medido en la prueba de concepto; la matriz, no | 3: igual | 4: lo que amplía está medido | 3: sin medir |
| K3 Escalabilidad | 5: una audiencia nueva = una fila | 5: igual | 3: cada sistema adapta D-13 en prosa | 4: una configuración por audiencia |
| K4 Costo | 4: un PR mecánico | 4: lo heredado avisa, sin migración forzada | 4 | 2: *toolchain* nuevo |
| K5 Doble audiencia | 4: columna de lector, sin verificación del alcance para el agente | 4: igual | 3: sirve bien a una audiencia | 4 |
| K6 Coherencia | 4: decisión nueva compatible | 4: igual, y formaliza `audience` y `roles`, que ya existen | 5: reusa D-13 | 3: neutral |
| K7 Deriva | 4: cruce de alcance determinista; la audiencia invocada, a mano | 4: igual, más P-LECT por audiencia primaria | 3: a mano | 4: build reproducible |
| **Ponderado** | **3,85** | **3,85** | **3,70** | **3,20** |

**Lectura.** H y A1 empatan en K1-K7: la escala no mide lo que las separa (H-07). Margen con A2: 0,15, menor que
0,30: **decisión con revisión** (`Como-Decidir.md` §1). Cadena de consecuencias (`Cadena-De-Consecuencias` §2):
1. **Dónde cae.** H: en quien escribe la ayuda del administrador de aplicación, que no sabe si escribir para el raíz
   también; y en el control, que no distingue destino de entrega. A1: en quien adopta, que llena dos tablas.
2. **Cuánto pesa.** A1 agrega una sección de tabla y dos controles; H, ninguno de esos. No lo medí en un proyecto.
3. **Qué pierde.** H pierde la audiencia primaria (y con ella la P-LECT por audiencia); A1 pierde una fila única.
4. **Reversible.** Las dos lo son: partir una fila en dos secciones o juntarlas es un PR mecánico.

**Recomendación:** A1, como enmienda de H y no como rival. Condición de revisión comprobable: si en la ronda 3 ningún
caso con roles usa la distinción primaria/secundaria (cero páginas con audiencia secundaria declarada), se vuelve a
una sola tabla.

## 7. Qué rehacer (tabla de §5.3)

| Pieza | Cambio | Motivo | Costo | Orden |
| --- | --- | --- | --- | --- |
| `SDEI/99-Anexos/Glosario.md` | Filas nuevas: Audiencia, Regla de entrega, Audiencia primaria y secundaria, Audiencia invocada, *Persona*, Modo de lectura; «Doble audiencia» pasa a nombre anterior | A-01, H-04, H-05 | Bajo | 1 |
| `SDEI/00-Marco.md` §2.5 y §4 | Fila «Audiencias» → «Audiencias típicas», con remisión a la decisión; §4 aclara actor ≠ audiencia | A-03 | Bajo | 2 |
| `K` D-01, D-13, §2.3, A-01, A-03 | D-18 nueva (dos tablas); D-13 remite; §2.3 «típicas»; A-01 suma la sección; A-03 cierra `audience` al registro | A-12 | Medio | 3 |
| `SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:53` | `audience` = identificadores del registro; modo de lectura aparte o por defecto | H-01 | Medio (lo heredado avisa) | 4 |
| `TEM-04` | Renombre a «Lectura por agentes»; el agente hereda la audiencia de su usuario | A-04 | Bajo | 5 |
| `TEM-05` | Audiencia primaria; entrega hereda hacia arriba; canal «punto de uso»; tabla «Qué pide cada campo» derivada | A-05, B-04, H-06 | Medio | 6 |
| `TEM-06` | Controles `audiencia-vocabulario`, `audiencia-primaria`, `cruce-de-entrega`, con par rojo/verde | A-11 | Medio | 7 |
| `SDEI/99-Anexos/Como-Decidir.md` | K5 «Audiencias», con anclas que distingan destino y entrega | H-07 | Bajo | 8 |
| `SDEI/99-Anexos/Referencias.md` | Sumar Ong, Ede y Lunsford, Johnson, Mathes y Stevenson, Hackos y Redish, Pruitt y Grudin, Matthews et al., Carroll y Rosson, Novick y Ward, Ellison, Seckler et al., Spinuzzi | §2 | Bajo | 8 |
| `Examples/` | Extender `Prueba-Ayuda-Por-Rol` (A-15, B-12) | Caso que funciona | Alto | 9 |
| Libro (`F099` §5.2) | Parte III: cap. 7 «Audiencias» nuevo; 8 «Lectura por agentes»; 9 «Ayuda al usuario final y en el punto de uso»; renumeración | A-13 | Medio | Después de 1-7 |
| Oráculos y criterio de caso (`F204`) | Filas de D-18 sólo en casos con roles o varias superficies, re-sellados; criterio sin cambios | A-14 | Medio | Después de `K` 1.3 |

## 8. Fuentes

Todas consultadas el 2026-11-01, salvo las que ya estaban en el cuerpo.

- Carroll, J. M. (Ed.). (1998). *Minimalism beyond the Nurnberg funnel*. MIT Press. ISBN 9780262512954. V (catálogo).
- Carroll, J. M., y Carrithers, C. (1984). Training wheels in a user interface. *Communications of the ACM*, 27(8),
  800-806. https://doi.org/10.1145/358198.358218. V.
- Carroll, J. M., y Rosson, M. B. (1987). Paradox of the active user. En J. M. Carroll (Ed.), *Interfacing
  thought: Cognitive aspects of human-computer interaction* (pp. 80-111). MIT Press. V.
- Cadavid, H., Andrikopoulos, V., y Avgeriou, P. (2022). Documentation-as-code for interface control document
  management in systems of systems: A technical action research study. ECSA 2022 (preimpresión).
  https://arxiv.org/abs/2206.11668. V.
- Ede, L., y Lunsford, A. (1984). Audience addressed/audience invoked: The role of audience in composition theory
  and pedagogy. *College Composition and Communication*, 35(2), 155-171. V (registro; una bibliografía da 156-171).
- Ellison, M. (2007). Embedded user assistance: The future for software help? *interactions*, 14(1), 30-31.
  https://doi.org/10.1145/1189976.1189997. V (extracto).
- Gentle, A. (2022). *Docs like code: Collaborate and automate to improve technical documentation* (3.ª ed.).
  Lulu. ISBN 9781387531493. V (catálogo); coautoría **sin verificar**.
- Grayling, T. (2002). If we build it, will they come? A usability test of two browser-based embedded help systems.
  *Technical Communication*, 49(2), 193-209. V la referencia; contenido **sin verificar**.
- Hackos, J. T., y Redish, J. C. (1998). *User and task analysis for interface design*. Wiley. ISBN
  978-0-471-17831-6. V.
- Johnson, R. R. (1997). Audience involved: Toward a participatory model of writing. *Computers and
  Composition*, 14(3), 361-376. https://doi.org/10.1016/S8755-4615(97)90006-2. V.
- Mathes, J. C., y Stevenson, D. W. (1976). *Designing technical reports: Writing for audiences in
  organizations*. Bobbs-Merrill. S (catálogo y diapositivas de curso; editorial y año por catálogo).
- Matthews, T., Judge, T., y Whittaker, S. (2012). How do designers and user experience professionals actually
  perceive and use personas? En *Proceedings of CHI 2012* (pp. 1219-1228). ACM. V (texto completo).
- Novick, D. G., y Ward, K. (2006). Why don't people read the manual? En *Proceedings of SIGDOC 2006* (pp. 11-18).
  ACM. https://scholarworks.utep.edu/cs_papers/15. V; DOI 10.1145/1166324.1166329 **sin verificar en ACM**.
- OASIS. (2016). *DITA 1.3, Conditional processing (profiling)*.
  https://docs.oasis-open.org/dita/dita/v1.3/os/part1-base/archSpec/base/condproc.html. V (incluir, excluir o
  marcar por atributos; la página no dice que sea un mecanismo de seguridad). Año por la versión «os», **sin
  verificar** en la página.
- Ong, W. J. (1975). The writer's audience is always a fiction. *PMLA*, 90(1), 9-21.
  https://doi.org/10.2307/461344. V.
- Porter, J. E. (1992). *Audience and rhetoric: An archaeological composition of the discourse community*.
  Prentice Hall. V (catálogo).
- Procida, D. (s. f.). *Diátaxis*. https://diataxis.fr/ y https://diataxis.fr/map/. V.
- Pruitt, J., y Grudin, J. (2003). Personas: Practice and theory. En *Proceedings of DUX 2003*. ACM.
  https://doi.org/10.1145/997078.997089. V.
- Redish, J. (2012). *Letting go of the words: Writing web content that works* (2.ª ed.). Morgan Kaufmann. ISBN
  9780123859303. V.
- Schriver, K. A. (1997). *Dynamics in document design: Creating texts for readers*. Wiley. ISBN 0-471-30636-3. V.
- Seckler, M., Heinz, S., Bargas-Avila, J. A., Opwis, K., y Tuch, A. N. (2014). Designing usable web forms:
  Empirical evaluation of web form improvement guidelines. En *Proceedings of CHI 2014* (pp. 1275-1284). ACM.
  https://doi.org/10.1145/2556288.2557265. V.
- Spinuzzi, C. (2003). *Tracing genres through organizations: A sociocultural approach to information design*. MIT
  Press. V.
- Ya en el cuerpo y no reabiertas hoy: Aghajani et al. (2019, 2020); Carroll (1990); van der Meij y Carroll (1995);
  ISO/IEC/IEEE 26514:2022 (`SDEI/99-Anexos/Referencias.md:56`, `:58`, `:76`, `:78`, `:84`).

## 9. Lo que revisé y está bien

1. `SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:48`: «ocultar es visibilidad; no entregar es acceso». Es la distinción que
   la retórica no hace y la seguridad sí; está bien puesta y es la base de la regla de entrega.
2. `SDEI/TEM-04-Doble-Audiencia.md:57`: «No es escribir para el agente. La prosa sigue siendo para personas». Coincide
   con Ong: la audiencia invocada es humana; el agente se ficcionaliza en ella.
3. `SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:134-135` y `Criterios-De-Calidad.md:39` (CQ-09): el minimalismo ya está
   citado como criterio de la ayuda; el eje B lo extiende al campo sin contradecirlo.

## 10. Remisiones, excepciones, lo no verificado e incidencias

- **Remisiones** (no hallazgos): mecanismo de herencia y prueba de no entrega (CA-3); portales y OpenAPI filtrado
  (CA-2); recursos, anotaciones y MAUI (CA-4); pistas, marcadores, `aria-describedby` y WCAG (CA-8); plataformas de
  guía en producto (CA-6); agente en el formulario (CA-7); identificadores de contexto (CA-9).
- **Excepciones a conocimientos:** ninguna.
- **Sin verificar:** atribución a Schriver de la tipología de tres modelos de análisis de audiencia; resultados de
  Grayling (2002); DOI de Novick y Ward en ACM; coautoría de la 3.ª ed. de Gentle; año de la página de DITA; los
  números de página de Ede y Lunsford tienen una variante (155 o 156). Ninguna posición descansa sólo en ellas.
- **No medido:** qué casos de los ensayos tienen roles o varias superficies (A-14).
- **Mensajes de otras sesiones durante el encargo:** ninguno.

## 11. Barrido de lo privado

Se buscaron en este archivo rutas absolutas del sistema de archivos, nombres de máquina y el nombre real del servicio
privado; el servicio va como `{servicio-privado}` y el cuerpo por alias (`SDEI/`, `K`). Resultado esperado: 0
coincidencias.
