# Mesa evaluadora, ciclo 1: informe del núcleo Requisitos

**Fecha:** 2026-09-18
**Rol:** Requisitos (núcleo permanente, marco §4.1.1)
**Pregunta del mandato:** ¿cada pedido del prompt tiene en el plan de núcleos un núcleo que lo cubra y un criterio de aceptación verificable?
**Material leído:** prompt `03-Reedicion-Arquitectura.md`, `Bitacora/01-Contrato-De-Entrada.md`, `Nucleos/NC-00..NC-10`, `Mesa/01-Registro-Convocatoria.md`, `Base/Mesa-Evaluadora.md` §3 y §4.1.4, `Base/Estilo-Redaccion-Explicativo.md`, perfil `Study-Guide-Documentation.md` y la guía vigente (commit 063f4e9, solo su estructura).
**Trabajo a ciegas:** no leí otros informes de `Ciclo-1/`.

---

## Índice

1. [Matriz pedido → núcleo → criterio de aceptación](#1-matriz-pedido--núcleo--criterio-de-aceptación): los 17 pedidos del prompt y en qué estado los deja el plan.
2. [Hallazgos](#2-hallazgos): siete hallazgos con evidencia, severidad y la dirección que propongo.
3. [Revisado y correcto](#3-revisado-y-correcto): tres coberturas que quedan firmes.
4. [Solicitudes de convocatoria](#4-solicitudes-de-convocatoria): temas fuera de mi mandato.
5. [Posición sobre la estructura del entregable](#5-posición-sobre-la-estructura-del-entregable)

---

## 1. Matriz pedido → núcleo → criterio de aceptación

Cada pedido se tomó literal del prompt y se le asignó un ID provisorio (R-xx). La columna «Criterio en el plan» dice si el plan fija hoy una condición que un revisor pueda comprobar sin opinar. La columna «Criterio propuesto» dice cuál debería ser.

| ID | Pedido (ubicación en el prompt) | Núcleo | Criterio en el plan | Criterio de aceptación propuesto (verificable) |
|---|---|---|---|---|
| R-01 | Incorporar «esto último que escribiste» (l. 11) | NC-03 («Y además…», l. 17) | **Parcial.** El texto de origen no está archivado y falta el «término medio» (H-02) | Fuente literal archivada en `Bitacora/`; cada afirmación de la fuente se traza a una sección `§n.m` de la guía o se declara descartada con su motivo |
| R-02 | A cada pregunta de «Cada objeto responde una pregunta», una respuesta explicativa (l. 11) | NC-03 (l. 19-20) | **Sí, pero no se puede contar.** «Cada pregunta de la tabla recibe una respuesta explicativa», sin el número total de preguntas | Las 7 preguntas de la tabla de NC-03 (Entity, Value Object, Command/Query, Response DTO, ViewModel, Form model, Persistence model) tienen cada una un `###` con respuesta de una línea, el porqué y un par ✅/❌. Resultado esperado: 7 de 7 |
| R-03 | Reeditar el documento entero, autocontenido y no delta (l. 15, l. 25) | NC-00 §4 («se completa en la integración») | **No.** No hay inventario de las secciones vigentes. §12 no está asignada a ningún núcleo (H-07) | Tabla de las 13 secciones vigentes más «Resumen de decisiones», con su destino: `§n` nueva o «retirada porque…». Ninguna referencia a la versión anterior |
| R-04 | Lector sin conocimientos. Lenguaje claro y técnico, no coloquial (l. 15) | Ninguno. Queda para la mesa (didáctica y edición) | **No** | Lista del Estilo §7 aprobada: términos definidos antes de su primer uso, sin «simplemente», «basta con» ni «obviamente» (se comprueba con grep), ninguna negrita de más de una línea |
| R-05 | Definiciones, ejemplos y explicaciones (l. 15, l. 25) | NC-01 (orden de definiciones) y cada núcleo | **Parcial.** NC-01 fija el orden, los demás núcleos no | Cada capítulo sigue la estructura del perfil (definición → aplicación → ejemplos → preguntas guía → criterios de calidad) o declara qué parte no aplica y por qué |
| R-06 | Comandos que se puedan probar, con el resultado esperado y cómo analizarlo (l. 15) | NC-08 | **Sí** (ver §3.1) | Se mantiene: cada paso tiene objetivo, comando, salida real, cómo leerla y qué concepto confirma |
| R-07 | Relato que alterna entender el concepto y probarlo sobre el servicio (l. 15) | NC-00 (NC-08 «columna que acompaña a NC-01, NC-02, NC-04») y NC-04 (evidencia HTTP) | **Parcial.** NC-03 tiene E1 propias (CS0272, JSON) pero el grafo no conecta NC-08 con NC-03. No se sabe si el laboratorio va intercalado o en un capítulo aparte (T-01) | Cada concepto que tiene evidencia E1 en su núcleo remite a su paso de laboratorio (`§n.m ↔ Paso k`), y cada paso nombra el concepto que confirma |
| R-08 | Guía base para diseñar desde cero y consultar criterios ante un problema real (l. 17) | NC-09 | **Parcial.** Hay una lista de contenidos pero ningún criterio de consulta directa (H-04) | Un capítulo que se entiende abierto sin leer lo anterior: una tabla de entrada «situación → estructura recomendada → §», señales para subir de escalón y señales de sobreingeniería, y un caso resuelto |
| R-09 | Preguntas guía con respuestas explicativas, que formen criterio e indiquen en qué caso aplica cada concepto (l. 25) | NC-01, NC-02, NC-07 y la tabla de NC-03 | **No.** Faltan en NC-04, NC-05, NC-06, NC-08, NC-09 y NC-10 (H-03) | Cada concepto definido tiene al menos una pregunta de «cuándo sí y cuándo no» con respuesta de una línea |
| R-10 | Diagramas Mermaid cuando sean necesarios (l. 25) | Ninguno | **No** (H-06) | Lista de diagramas decidida por la mesa (como mínimo: dependencias entre proyectos, flujo página → API → dominio → base, escala de decisión de NC-09). Cada uno se renderiza sin error |
| R-11 | Secciones jerárquicas con índice (l. 25) | Ninguno | **No** (H-06) | Secciones numeradas, sin `#####`, índice solo de `##` con glosa, anclas comprobadas en el render |
| R-12 | Fragmentos de código representativos (l. 25) | NC-04 (X-03) | **Parcial.** El principio de NC-08 cubre las salidas, no los fragmentos de código (H-06) | Cada fragmento de C# pertenece a la solución de laboratorio que compila o lleva el rótulo «fragmento ilustrativo» |
| R-13 | No inventar. Toda afirmación con evidencia verificable (l. 41-42) | NC-08 (principio), NC-10 («a verificar») | **Parcial.** El plan ya afirma resultados sin captura, y uno es inexacto (H-05) | Cada salida remite a su archivo en `Laboratorio/`. Cada hecho externo (versión, licencia, autor, año) lleva URL. El texto distingue verificado, razonado y supuesto (Estilo §5.1) |
| R-14 | Mesa con expertos en didáctica, edición bibliográfica y arquitectura .NET, más el análisis de si falta alguno (l. 19) | Registro de convocatoria | **Sí** (ver §3.2) | — |
| R-15 | Que la mesa revise el documento terminado y corrija edición, comprensión y coherencia (l. 19) | Contrato §3, paso 5 | **Sí** | Informe del ciclo 2 sobre el entregable final |
| R-16 | Apuntes, borradores y debates en `06-Arquitectura/OUTPUTs` (l. 19) | Contrato §1.1 | **Sí** | Se cumple con las carpetas actuales |
| R-17 | Descomposición en núcleos, documento de cohesión, integración y bitácora (l. 27-39) | NC-00 y contrato §3 | **Sí** (ver §3.3). La trazabilidad hacia el entregable está pendiente, como se declaró | NC-00 §4 completo: núcleo → capítulo |

**Resumen:** 17 pedidos. 5 cubiertos con criterio (R-06, R-14, R-15, R-16, R-17). 7 cubiertos a medias (R-01, R-02, R-05, R-07, R-08, R-12, R-13). 5 sin criterio (R-03, R-04, R-09, R-10, R-11).

---

## 2. Hallazgos

### H-01 — Los pedidos del prompt no tienen ID ni criterio de aceptación: falta el registro de requisitos

- **Ubicación:** plan completo. `NC-00 §4` («Se completa en la fase de integración») y contrato `§1` (`restricciones_duras` sin ID).
- **Afirmación:** los pedidos del prompt figuran como restricciones sin identificador. Ningún documento del plan une pedido, núcleo, criterio y prueba. Según la matriz del §1, 12 de los 17 pedidos quedan sin criterio o con criterio parcial.
- **Evidencia:** E4 más E2. El marco, §3, «Coherencia», dice: «todo requisito tiene ID, criterio de aceptación y al menos una prueba que lo referencia […] si alguna falla, hay un S1 antes de que nadie opine». NC-00 l. 70 dice: «Se completa en la fase de integración (Bitácora 03)».
- **Severidad:** S1. Es la condición de base del marco. Sin ella, en el ciclo 2 no se puede decidir si el entregable cumple el prompt: cada revisor aplicaría su propio criterio.
- **Confianza:** 0,9.
- **Impacto si no se corrige:** el ciclo 2 revisaría el documento sin una vara común, y un pedido como R-10 (Mermaid) o R-09 (preguntas guía en cada concepto) podría quedar afuera sin que nadie lo detecte.
- **Dirección:** crear `Bitacora/02-Requisitos.md` con R-01..R-17 (esta matriz sirve como semilla), un criterio verificable por requisito y el chequeo que lo prueba (conteo, grep, archivo de captura, render). El ciclo 2 revisa contra ese registro.

### H-02 — La fuente de «esto último que escribiste» no está archivada y el plan omite parte de su contenido

- **Ubicación:** prompt l. 11, NC-03 l. 5-17, contrato l. 26-27.
- **Afirmación:** el pedido obliga a incorporar el contenido de un mensaje de la conversación. Ese mensaje no está guardado en `OUTPUTs/`: solo existe el resumen de NC-03. El resumen omite el cierre del mensaje, el «término medio que suele funcionar»: la entidad mapeada por EF por un lado y, por otro, lo que la página bindea (un DTO o un form model), para resolver el choque de los setters y el filtrado de campos «sin montar toda la cebolla». También omite que los disparadores del cambio (segundo cliente, reglas que se repiten) salen de ese mismo mensaje.
- **Evidencia:** E2. En el mensaje de origen, pasado al panel como contexto de esta corrida, dice: «Un término medio que suele funcionar: **la entidad mapeada por EF, por un lado, y lo que la página bindea (un DTO o un form model), por otro**». NC-03 l. 17 enumera «“la entidad es la que mapea la base”… por qué no alcanza una sola clase plana… cuándo la clase única es correcta» y no nombra el término medio. `grep -rn "responde una pregunta" OUTPUTs/` solo devuelve NC-00 y el contrato. No hay copia de la fuente.
- **Severidad:** S2. Se puede redactar igual, pero sin la fuente nadie puede comprobar después que se incorporó «esto último» completo. Además, el escalón intermedio es justamente el que más le sirve a R-08.
- **Confianza:** 0,85.
- **Dirección:** archivar el mensaje literal, junto con la tabla original de «Cada objeto responde una pregunta», en `Bitacora/00-Fuente-Conversacion.md`. Trazar cada afirmación a una sección de la guía y agregar el término medio como escalón explícito en NC-03 y en la escala de NC-09.

### H-03 — Las preguntas guía no tienen criterio de cobertura y faltan en seis de los diez núcleos

- **Ubicación:** prompt l. 25. NC-04, NC-05, NC-06, NC-08, NC-09 y NC-10 no tienen sección de preguntas guía.
- **Afirmación:** la regla pide preguntas guía con respuestas explicativas «que permitan… identificar en qué caso se aplica cada concepto vertido en el documento». El plan solo las prevé en NC-01, NC-02 y NC-07, más la tabla de NC-03. Justo los núcleos con más decisiones no las tienen: el backend (MediatR sí o no, validación), los clientes (Server o WASM, Refit o HttpClient), la estructura (Contracts) y los criterios.
- **Evidencia:** E2. El prompt, l. 25, dice: «preguntas guías acompañadas de respuestas explicativas que sean formadoras de criterios y que permitan o sirvan al lector identificar en que caso se aplica cada concepto». Una búsqueda de «Preguntas guía» encuentra el encabezado solo en NC-01 l. 15, NC-02 l. 12 y NC-07 l. 13.
- **Severidad:** S2. Quien redacte va a interpretar distinto qué conceptos llevan pregunta. El resultado previsible es un documento formativo en los fundamentos y enciclopédico en las decisiones.
- **Confianza:** 0,85.
- **Dirección:** fijar como criterio «cada concepto definido tiene al menos una pregunta de *cuándo sí y cuándo no*, con respuesta de una línea y un par ✅/❌». Aplicar la excepción del Estilo §2.6: las definiciones se declaran y no se convierten en pregunta.

### H-04 — El uso como guía de consulta ante un problema real no tiene criterio de aceptación, y el perfil pide piezas que el plan no incluye

- **Ubicación:** prompt l. 17, NC-09, contrato §2 T-01 y §1.1 («los núcleos del perfil se vuelven capítulos»).
- **Afirmación:** T-01 reconoce que el documento necesita «un capítulo de criterios de decisión que se pueda abrir directamente». NC-09 lista contenidos, pero no la condición que haría posible esa lectura salteada. El perfil declarado en el contrato exige un marco de referencia (escenarios, contextos, actores) y un mapa conceptual («estoy acá → qué aplico»). El plan no los instancia ni declara por qué no aplican.
- **Evidencia:** E4 más E2. El perfil, tabla «Objetivos específicos», pide «Mapa conceptual: Tablas de entrada por escenario, por contexto y por artefacto: “estoy acá → qué aplico”». NC-09 l. 6 enumera variables del problema («consumidores (una app / varias), reglas de negocio (pocas / muchas), persistencia (nueva / heredada)»), que son de hecho los contextos del perfil, pero no las convierte en una tabla de entrada.
- **Severidad:** S2. El prompt pone a este uso como finalidad del documento («pretende ser una guía base… debe ser de consulta»). Sin criterio, puede quedar reducido a un párrafo de recomendaciones.
- **Confianza:** 0,8.
- **Dirección:** aceptar NC-09 cuando cumpla tres condiciones: (a) una tabla de entrada con situación, estructura, referencia a `§` y señal para subir de escalón; (b) que cada fila remita a la sección donde está el fundamento; (c) un caso resuelto que empiece por el problema y no por la plantilla (Estilo §3.2, «razonar desde el requerimiento»). Declarar en el contrato cómo se instancian los ejes del perfil, o por qué no aplican.

### H-05 — «No inventar» no tiene criterio operativo, y el plan ya anticipa un resultado que la corrida desmiente

- **Ubicación:** NC-01 l. 18. También NC-04 l. 21 y NC-02 l. 6 y l. 19.
- **Afirmación:** NC-01 da por respuesta «¿Qué pasa si dos proyectos se referencian mutuamente? → el SDK lo rechaza». La corrida muestra otra cosa: el comando que agrega la referencia la acepta sin error, y el rechazo llega recién al compilar, desde el grafo de restauración de NuGet (MSB4006), no como un error de C#. Además, NC-04 deja el resultado esperado sin definir («400/422»), y NC-02 y NC-09 citan libros y artículos sin URL ni edición.
- **Evidencia:** E1. Contenedor `mcr.microsoft.com/dotnet/sdk:10.0`, guion igual a `Laboratorio/explora/explora.sh`, corrido en un directorio aparte:
  ```
  + dotnet add src/Tienda.Domain reference src/Tienda.Infrastructure
  Reference `..\Tienda.Infrastructure\Tienda.Infrastructure.csproj` added to the project.
  + dotnet build
  Build FAILED.
  /usr/share/dotnet/sdk/10.0.400/NuGet.targets(1298,5): error MSB4006: There is a circular dependency in the target dependency graph involving target "_GenerateRestoreProjectPathWalk". [/w/Tienda/src/Tienda.Infrastructure/Tienda.Infrastructure.csproj]
      0 Warning(s)
      1 Error(s)
  ```
  Después de la corrida, `Tienda.Domain.csproj` l. 4 contiene `<ProjectReference Include="..\Tienda.Infrastructure\Tienda.Infrastructure.csproj" />`.
- **Severidad:** S2. Para el lector novato, la diferencia entre «no te deja agregarla» y «la agrega y después no compila» es justamente lo que tiene que aprender a leer (R-06). Si la respuesta se escribe antes de capturar la salida, la guía enseña algo falso.
- **Confianza:** 0,9.
- **Dirección:** dar a R-13 tres criterios comprobables: (1) cada resultado esperado de la guía remite a un archivo de captura en `Laboratorio/` y las respuestas de los núcleos se reescriben después de capturar, no antes; (2) cada hecho externo (versión, licencia, año, autor) lleva una URL consultada; (3) cada afirmación se marca como verificada, razonada o supuesta (Estilo §5.1). En NC-04, elegir un único código de estado y justificarlo con la salida real.

### H-06 — Los requisitos de forma (Mermaid, índice jerárquico, fragmentos de código) no tienen núcleo ni criterio

- **Ubicación:** prompt l. 25. Ningún núcleo menciona diagramas. El principio de NC-08 (l. 6) solo abarca las salidas.
- **Afirmación:** la regla pide secciones jerárquicas con índices, Mermaid «cuando sea necesario» y fragmentos de código representativos. Ningún núcleo decide qué diagramas lleva la guía (la vigente tiene 5). Tampoco hay criterio de que los fragmentos de C# compilen, y la contradicción X-03 (`nameof(GetById)` sin la acción definida) muestra que la guía vigente ya falla en eso.
- **Evidencia:** E2. Un grep de `mermaid` en la guía vigente da 5 bloques (l. 164, 208, 256, 698, 915). En `Nucleos/` solo aparece el grafo de NC-00. NC-08 l. 6 dice: «Toda salida mostrada en la guía proviene de una corrida… Lo que no se ejecutó se rotula “fragmento ilustrativo”». Habla de salidas, no de código fuente.
- **Severidad:** S3. Pérdida acotada: la mesa de edición probablemente lo corrija, pero sin criterio no hay forma de exigirlo en el ciclo 2.
- **Confianza:** 0,75.
- **Dirección:** adoptar como criterios de R-10, R-11 y R-12 los ítems de «estructura» del Estilo §7. Fijar una lista mínima de diagramas con su propósito. Y definir que cada fragmento de C# pertenece a la solución de laboratorio que compila o lleva el rótulo «fragmento ilustrativo».

### H-07 — La reedición entera no tiene inventario: §12 de la guía vigente no tiene núcleo asignado

- **Ubicación:** NC-00 l. 12-23 (columna «Origen en la guía vigente»). Guía vigente l. 913.
- **Afirmación:** la tabla de segmentación asigna §1-§11, §13 y el «Resumen de decisiones», pero no §12, «Diagrama Final Completo». Tampoco hay un criterio que asegure que la reedición es entera y autocontenida, es decir, que ninguna sección vigente se pierde sin una decisión registrada.
- **Evidencia:** E2. Guía vigente l. 913: `## 12. Diagrama Final Completo`. NC-00 no menciona «§12» en ninguna fila.
- **Severidad:** S3.
- **Confianza:** 0,8.
- **Dirección:** agregar a la bitácora de integración un inventario con cada sección vigente, su destino (`§n` nueva o «retirada porque…») y el núcleo responsable. Asignar §12 (probablemente a NC-02 o NC-06, junto con R-10).

---

## 3. Revisado y correcto

### 3.1 NC-08 cubre el pedido de comandos con resultado esperado y análisis, con un criterio verificable por paso

NC-08 l. 22-23 dice: «Cada paso documenta objetivo, comando, salida real, cómo leerla, qué concepto confirma». Estas cinco partes responden punto por punto a «comandos que se puedan probar y de los resultados esperados el como analizarlos y entenderlos» (prompt l. 15). A esto se suma el principio de la l. 6: lo no ejecutado se rotula como tal.

### 3.2 La composición de la mesa cumple lo que pide el prompt

El registro de convocatoria convoca a didáctica, edición bibliográfica y arquitectura .NET (votación 5-0). Responde a «analiza si necesitas un experto mas» con un agente ad hoc que tiene carta de mandato (AH-001, ecosistema y licencias), y el contrato §3, paso 5, prevé que la mesa revise el documento terminado. Cubre R-14 y R-15.

### 3.3 La descomposición conceptual cumple la regla del prompt

NC-00 segmenta por pregunta del lector y no por extensión (l. 10), incluye un grafo de dependencias, lista las contradicciones X-01 a X-06 con sus núcleos y deja declarada la fase de integración. La desviación de la ruta de la bitácora (el prompt apunta a `07-Seguridad…`) está registrada como supuesto, con su fundamento, en el contrato §1.1. Cubre R-16 y R-17.

---

## 4. Solicitudes de convocatoria

- **A Verificación / QA (ya convocado):** fijar con qué versión del SDK se capturan las salidas y cómo se le avisa al lector que su salida puede diferir. La captura del H-05 incluye la ruta `/usr/share/dotnet/sdk/10.0.400/` y el formato del mensaje, que dependen de la versión (se cruza con DA-3). No es un tema de requisitos.
- **A E-Didáctica:** decidir si el laboratorio va intercalado con cada concepto o en un capítulo aparte con remisiones (R-07, T-01). Yo solo pido que la decisión quede con un criterio comprobable. Qué forma se aprende mejor le corresponde a didáctica.

---

## 5. Posición sobre la estructura del entregable

Sobre DA-1..DA-4 no opino: son decisiones de arquitectura y de ecosistema. Sobre la estructura del entregable, y dentro de mi mandato, propongo lo siguiente:

1. Que el jurado apruebe el índice del entregable **solo junto con** el registro de requisitos del H-01. Cada capítulo del índice tiene que declarar qué R-xx cubre, y ningún R-xx puede quedar sin capítulo.
2. Que NC-09 sea un capítulo que se pueda leer sin haber leído los anteriores, con su tabla de entrada al comienzo (H-04), y que los capítulos conceptuales remitan a esa tabla.
3. Que la estructura uniforme del perfil (definición → aplicación → ejemplos → preguntas guía → criterios) sea la plantilla de cada capítulo temático. Así R-05 y R-09 se comprueban capítulo por capítulo.
