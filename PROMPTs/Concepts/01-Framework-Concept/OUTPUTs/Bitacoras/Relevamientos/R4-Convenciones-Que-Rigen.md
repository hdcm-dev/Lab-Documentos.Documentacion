# R4 — Convenciones que rigen el objeto (barrido del índice de conocimiento)

> Relevamiento del despacho, 2026-10-25. Rol: relevador de las convenciones de la base de conocimiento, sin
> voto y sin emitir hallazgos de mesa. Es un dato del contrato de entrada (`Mesa-De-Expertos-A-Pedido` §3.4 y
> §5.1, campo `CONVENCIONES QUE RIGEN`): cada alias va con su versión **medida por comando**, las secciones que
> rigen y lo que manda para este caso. Lo que es lectura propia del relevador va rotulado **[criterio propio]**.
> Lo que no se pudo verificar va rotulado **NO VERIFICADO** con su motivo.

## Índice

1. [Objeto y base que se barre](#1-objeto-y-base-que-se-barre)
2. [El barrido, con su comando y su salida](#2-el-barrido-con-su-comando-y-su-salida)
3. [Versiones medidas](#3-versiones-medidas)
4. [Clasificación de las 42 filas](#4-clasificación-de-las-42-filas)
5. [Convenciones que rigen el objeto: qué manda cada una](#5-convenciones-que-rigen-el-objeto-qué-manda-cada-una)
6. [Lo que la presidencia necesita para operar la mesa](#6-lo-que-la-presidencia-necesita-para-operar-la-mesa)
7. [Tensiones entre el borrador del PO y las convenciones](#7-tensiones-entre-el-borrador-del-po-y-las-convenciones)
8. [Descartes, con motivo](#8-descartes-con-motivo)
9. [Bloque listo para el contrato de entrada](#9-bloque-listo-para-el-contrato-de-entrada)
10. [No verificado](#10-no-verificado)

---

## 1. Objeto y base que se barre

**Objeto** (de `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Concepts/01-Framework-Concept/Crear-Framework-Concept.md`
y de la bitácora `01-Descomposicion-En-Nucleos.md`): un framework para apps .NET MAUI con páginas Blazor
híbridas actualizables desde un servidor propio sin tienda (N1, N2), procedimientos de PR, integración y
versionado para que un PR no rompa una rama estable (N3), estrategia de pruebas (N4), y una guía académica más
una demo basada en `MovilidadUrbana.MAUI` (N5); todo conducido por una mesa a pedido con expediente.

**Base barrida:** `<base de conocimiento>/Knowledges/Index-Knowledge.md`.

| Dato | Comando | Salida |
| --- | --- | --- |
| Generación del índice | `grep -n '^Generado:' Index-Knowledge.md` | `5:Generado: fecha 2026-10-24 · commit 081082a` |
| HEAD de la base | `git -C /IA/<base de conocimiento> log -1 --format='%h %ad' --date=short` | `1585af9 2026-10-25` |
| ¿Cambió algo de `Knowledges/` o `Rules/` desde el commit del índice? | `git diff --stat 081082a..HEAD -- Knowledges Rules` | Sólo `Index-Knowledge.md` (4 líneas) y `Rules/Rule-Forma-De-Conocimiento.md` (13 líneas). Ninguna pieza de las que rigen acá cambió: el índice vale para este barrido |
| Filas del índice | `grep -c '^\| \[' Index-Knowledge.md` | `42` |

---

## 2. El barrido, con su comando y su salida

Comando, tal como lo fija `Mesa-De-Expertos-A-Pedido` §5.1 (campo 4 = Alias, 6 = Tema, 12 = Estado), corrido desde
`<base de conocimiento>/Knowledges`:

```bash
grep '^| \[' Index-Knowledge.md | cut -d'|' -f4,6,12
```

Salida literal (2026-10-25):

```text
 Bundle-JS | Proyecto de código JavaScript/TypeScript que emite un bundle agnóstico y una capa de interop (`main.js`), consumido por una biblioteca de clases Razor dentro de una solución .NET: contrato entre los dos lenguajes, cadena de construcción, anfitrión HTML sin .NET y anfitrión Blazor mínimo como instrumentos de diagnóstico; el aislamiento del proveedor como fundamento de la costura, la identidad de sus piezas —el paquete de otro ecosistema con su capa de interop llevan un número, la biblioteca comparte ese número mientras se co-despliegue y lleva el suyo en cuanto haya un acto propio, y el contrato es un eje aparte— y el requisito de que la traza de un error del cliente nombre la versión que lo originó | Vigente 
 Cadena-De-Consecuencias | Cómo se razona antes de recomendar, dictaminar o elegir entre opciones: cada opción se sigue hasta el lugar donde cae su costo, se mide ahí, se dice qué pierde la alternativa y se prefiere la reversible; un obstáculo no es una decisión, una acción denegada no se le pide a otro agente y la restricción también es una opción | Vigente 
 Clean-Architecture-DataManager | Arquitectura interna en cuatro capas con acceso a datos por DataManager sobre ADO.NET, sin ORM | Vigente 
 Conformacion-Pull-Request-Automatico | Ciclo de entrega de una unidad de trabajo cerrado por el propio agente que la conduce: compuerta, rama, pull request abierto por API, informe con el enlace, guarda de merge sobre los controles, merge y borrado de la rama remota por el agente, preparación del repositorio local y continuación sin acuse humano, con retorno al ciclo manual ante una reserva | Vigente 
 Conformacion-Pull-Request-Manual | Ciclo de entrega de una unidad de trabajo entre el agente que conduce el trabajo y un agente humano: compuerta, rama, informe con el enlace del pull request, merge y borrado del humano, acuse y reanudación verificada | Vigente 
 DataTier-DataBase-Layer | Cómo se diseña y construye la capa de datos SQL Server: nomenclatura del esquema `lut_`/`sys_`/`log_`/`rel_`, columnas de auditoría, aislamiento por aplicación, procedimientos almacenados (verbos, parámetros posicionales, `@Id OUTPUT`, actos transaccionales, objeto recreable), errores y versión de esquema | Vigente 
 DataTier-DataBase-Layer-Acceso-NET | La capa de acceso .NET que consume los procedimientos almacenados de DataTier: contrato del núcleo cerrado `DataEntityCore` y sus límites, `<Tabla>Model`, `<Tabla>Abstract` generado, `<Tabla>DataManager`, errores por número, resultado de tres estados, registro, versión de esquema al arrancar y pruebas | Vigente 
 Deduccion-De-Reglas-De-Negocio | Procedimiento y panel de roles para leer una fuente de negocio en prosa y derivar de ella un catálogo de reglas anclado y clasificado, con búsqueda activa de lo que la fuente no dice, de las inconsistencias y de los huecos de proceso, y con una resolución propuesta para cada hallazgo, rotulada y nunca aplicada sobre la fuente | Vigente 
 Detencion-Y-Lote | Cuándo un agente se detiene ante quien pidió y cuándo no (el origen del hecho, la autocorrección, la pregunta previa y la lista cerrada de lo que no tiene respuesta), la forma de toda detención con su propuesta, el lote de preguntas con `SI NO RESPONDÉS` y sus dos excepciones bloqueantes, lo que no se asienta por silencio, el bloqueo de un paso prescripto y las fases irreversibles ante las que se detiene un trabajo | Vigente 
 Entorno-De-Ejecucion-Del-Agente | Clasificación verificada del origen de un texto que aparece en la conversación de un agente —pedido, framework, destino, entorno de ejecución, herramienta o subagente— y qué hacer con cada clase: obedecer, callar, relayar o registrar una preferencia, sin corregir el framework por lo que el framework no produce | Vigente 
 Escalas-De-Juicio | Las dos escalas con que la base juzga un hallazgo: el nivel P0–P3, que mide su impacto sobre el objeto juzgado y se lee para cada caso, y la clase de ancla E1–E4 o C, que dice qué lo sostiene y qué puede fundar; más las dos marcas que se declaran además del nivel y las reglas que impiden que una afirmación sin observable llegue a P0 o funde una corrección | Vigente 
 Excepcion-A-Un-Conocimiento | Excepción a un conocimiento que rige: se deja de seguir un documento de la base sólo por contradicción y no por conveniencia, con una ficha que trae la alternativa de cumplir y su costo, un análisis del camino de compromiso con criterios citados y uno o dos caminos, el default mientras quien pidió decide y el apartado de cierre; se carga al proponer, juzgar, analizar, votar o aplicar una excepción | Vigente 
 Expediente | La forma del expediente de un caso que atraviesa más de una corrida o más de un repositorio, o en el que entra material externo que funda una decisión: cuándo se abre, la carpeta y el número, los folios `NNN-<tipo>-<slug>.md` con cabecera `Tipo`/`Fecha`/`Autor`/`Corrige` y pase «Sigue:», los seis tipos y el estado derivado, el testimonio de una parte con su huella, la evidencia con tres líneas de cabecera, la evidencia cruda que queda local, lo publicado que no se reescribe y los datos que no se publican | Vigente 
 Forma-De-Conocimiento | La forma común de toda pieza de la base, que es lo que interopera entre espacios de trabajo distintos: las clases y su prefijo, los once campos de cabecera con su dominio neutral y el significado de `—`, las gramáticas del alias, de la sección, de la tabla «Dependencias» y de la fila «Origen», la parte normativa con niveles, la cláusula de conformidad, las unidades de versión, carga y búsqueda, los dos espacios de versión, la regla de falla y los límites de confianza | Vigente 
 Icono-Y-Ancla | Criterio de redacción para entregar una definición de modo que quien la lee pueda operar con ella sin haber leído la fuente: distinción entre el icono, que comprime un concepto en una fórmula memorable, y el ancla, que lo transporta con su operación | Vigente 
 Indexing | Construir y mantener una ia-db: índices semánticos para que un agente recupere contexto sin releer fuentes ni documentación completa | Vigente 
 Media-File-Service-DataTier | Realización sobre SQL Server de la fila de archivo de `Media-File-Service-SMB` sobre el patrón `DataTier-DataBase-Layer`: lectura del parámetro por `LutParametrosDataManager`, los tres comportamientos de los `_Insert` medidos, quién concatena carpeta y nombre por tabla, orden de parámetros del `_INSERT` de una tabla nueva, capa legado y registro en `Program.cs` | Vigente 
 Media-File-Service-EF | Realización con Entity Framework Core sobre SQL Server de la fila de archivo de `Media-File-Service-SMB`: entidad y configuración por tabla `sys_<Entidad>_Files`, lectura del parámetro del tenant por `DbContext`, alta que devuelve el id de la sesión, orden fila/archivo y baja, derivadas del contrato del padre | Vigente 
 Media-File-Service-SMB | Suba y descarga de archivos de usuario en servicios .NET sin endpoint de archivos: escritura por `System.IO` sobre un recurso compartido, lectura por URL de un sitio estático, dos parámetros de la instalación en `lut_Parametros` (convención `Parametros-De-Sistema`), y el contrato de la fila de archivo por entidad (ruta relativa, nunca el host) que todo medio de persistencia tiene que respetar | Vigente 
 Media-File-Service-SMB-Esqueletos | Esqueletos del mecanismo de suba y lectura de archivos de `Media-File-Service-SMB`: página Blazor con un adjunto por tipo, varias instancias del componente con una lista compartida, API REST que recibe base64, servicio de negocio con fotos de una app móvil y su lectura, armado de la URL según la forma de `Documento`, y el núcleo de nombrado y escritura del componente | Vigente 
 Mesa | La mecánica de una mesa de expertos que analiza, refuta y convierte en plan de cambios un corpus que ya existe, antes de que ese plan se apruebe: la condición que la convoca, el registro, los principios, el contrato de entrada, la composición del panel (núcleo permanente, catálogo variable por señal, ad hoc, techo), el trabajo a ciegas con convocatoria en caliente, el refutador, el jurado, el diseño de parches, la entrega, el cierre y la lista cerrada de escaladas | Vigente 
 Mesa-Consulta-A-Un-Tercero | Protocolo de conversación entre una mesa de expertos y una persona de afuera (cliente, jefe de proyecto, usuario): roles, ronda, forma del mensaje, espera, correlación de respuestas, registro y cortes. Vale para cualquier canal. | Vigente 
 Mesa-De-Expertos-A-Pedido | Mesa de expertos convocada por un pedido explícito y no por la condición de convocatoria de la regla de mesa: lectura del pedido como enunciado del problema, clase de objeto y variante del panel, convenciones que rigen medidas, despacho verificado, expediente de la mesa con el ciclo de vida de su evidencia y filtros de juicio medidos en su uso | Vigente 
 Migraciones-SQL-Versionadas | Mecanismo de evolución del esquema SQL Server por archivos de migración idempotentes numerados (`NNN_`) con clase de reversión declarada, prólogo y epílogo fijos, procedimientos recreables en un archivo por objeto que se reaplica por huella, registro en la base (`sys_Migracion`), escritura de la versión de esquema (`sys_Esquema`, `MAYOR.N`, con `MAYOR` en un archivo) y su rebase de línea, aplicador transaccional y compuerta de la cadena; qué es migración, qué es recreable y qué es herramienta | Vigente 
 Migraciones-SQL-Versionadas-Esqueletos | Esqueletos del mecanismo de migraciones SQL versionadas: una migración completa con clase de reversión, prólogo, epílogo y contramigración, el procedimiento recreable que la acompaña, la sonda retroactiva del registro, el núcleo del aplicador transaccional en PowerShell y la comprobación de versión de esquema al arrancar | Vigente 
 Parametros-De-Sistema | Dónde vive y cómo se lee un parámetro de sistema en una solución .NET con SQL Server: la tabla `lut_Parametros` como convención (qué es parámetro de sistema y qué queda en `appsettings`, forma de la tabla, nombres de los códigos, alta por migración, carga por herramienta, lectura por un único lector y estado «falta configurar»), y su creación cuando el producto no la tiene | Vigente 
 Parametros-De-Sistema-Esqueletos | Esqueletos de la convención de parámetros de sistema en `lut_Parametros`: el DDL de las dos variantes de la tabla, los procedimientos de lectura por código y de escritura del valor, la siembra idempotente de una fila, la herramienta de carga con `COLLATE` de los dos lados y su variante con auditoría, las constantes, el acceso y el lector de familia en C#, y la realización con Entity Framework Core | Vigente 
 Perfiles-Y-Extension | Reglas para crear un perfil de la base para un framework (fija valores, no campos; vive fuera del núcleo), la regla de extensión ignorable fuera de la cabecera de una pieza, el registro público de nombres de perfil, y dónde vive el perfil de un framework que es de un destino privado | Vigente 
 Red-Movil-Problematica | Simulación, en el espacio de red del contenedor de un emulador Android (QEMU/slirp), de fallas de una red móvil deficiente vistas desde el teléfono —NAT/CGNAT, DNS, cortes, filtrado de QUIC y fondo de latencia y pérdida—: el mecanismo, el catálogo de fallas con su estado de medición, el contrato de corrida (entrada, momento, validez, oráculos, evidencia), el contrato que le pide a cada escenario de app, la limpieza verificable y la plantilla para escribir una especialización. No emula el radio; no trae resultados de ninguna app como regla | Vigente 
 Release-Y-Despliegue-Versionado | Qué es un release de un producto con varias líneas de versión: la etiqueta, el manifiesto mecánico y el humano, el runbook con versiones, la vuelta atrás por clase de reversión, el registro de despliegues, y cómo un síntoma que reporta un QA o un usuario final se convierte en versiones exactas | Vigente 
 Template-Blazor-Interactive-Server-Panel-De-Control | Cómo se construye en .NET 10 Blazor Interactive Server una página o un ABM de un panel de administración servido por el mismo host que su API: render mode centralizado en el host, listado con el estado en la URL, ciclo acción → acuse, excepción SSR por acto, interop por módulo y pruebas bUnit; delta sobre la realización Blazor del sistema de diseño V2 | Vigente 
 Template-Blazor-Interactive-Server-SDD-Default | Realización del template HTML de maqueta como proyecto .NET Blazor Web App con render mode Interactive Server y sin librería de componentes: estructura, componentes propios por patrón, formularios, diálogos, asistentes y superficies de identidad fuera del circuito | Vigente 
 Template-Blazor-Interactive-Server-Sistema-De-Diseno-V2 | Realización en .NET Blazor Interactive Server del sistema de diseño V2 con bibliotecas de componentes compartidos: forma del proyecto, convención de componente, ciclo de vida, registro de servicios, interoperación con JavaScript, orquestación de asistentes multipaso con borrador y mecánica de sesión con sus mínimos de seguridad; delta sobre el template Blazor por defecto | Vigente 
 Template-Blazor-Interactive-Server-Sistema-De-Diseno-V2-Componentes | Contratos en C# de los componentes de la biblioteca genérica de interfaz del sistema de diseño V2: tipos y espacios de nombres, modal de confirmación, toast, mensaje de error, paginador, tabla en modal y controles de entrada, con la regla de `MarkupString` | Vigente 
 Template-HTML-Panel-De-Control | Delta sobre el sistema de diseño V2 para el panel de administración de un servicio con varias unidades de trabajo: cascada de siete capas, contexto de trabajo en la ruta, seis recorridos fijos, contrato de acuses, zonas del listado con el estado en la URL, y esqueletos de acceso, tablero de la unidad, listado, modal, formulario y tarjetas | Vigente 
 Template-HTML-Panel-De-Control-Recorridos | Recorrido y respuesta del panel de control sobre el sistema de diseño V2: contexto de trabajo en la ruta, mapa de navegación con rótulos literales, seis recorridos fijos, contrato de respuesta por tipo de acción con catálogo de acuses, e irreversibles con su guarda | Vigente 
 Template-HTML-SDD-Default | Forma constructiva de una maqueta HTML/CSS/JS sin proceso de build: layout de archivos, tokens, conmutador declarativo de estados, y los cuatro tipos de diálogo (ABM clásico, asistente de varios niveles, ventana modal y presentación de datos) | Vigente 
 Template-HTML-Sistema-De-Diseno-V2 | Delta sobre el template HTML por defecto: el contrato de un sistema de diseño HTML/CSS/JS distribuido como paquete de assets estáticos —tokens con un segundo eje de variables locales, tema claro-oscuro por atributo propio, cascarón de página, contrato entre el CSS y el JavaScript— y la anatomía de los diálogos de ABM, asistente multipaso, modal, retroalimentación, formulario y estados de superficie | Vigente 
 Versionado-Esquema-Base-De-Datos-EF-Layer | Cómo se realiza con Entity Framework Core Migrations la línea de versión del esquema que `Versionado-Producto-Integral` define como contrato: qué juega el papel del registro y del número declarado, cómo el servicio exige la versión al arrancar, qué compuerta reemplaza a cuál, y qué se gana y qué se pierde frente a la realización por archivos SQL numerados | Vigente 
 Versionado-Paquetes-NuGet | Cómo se numeran, se verifican y se publican los paquetes NuGet de un proyecto: lo que vale desde un solo paquete —una sola fuente del número, línea base de API pública por marco de destino que además clasifique, etiqueta propia separada de la del artefacto desplegable, nota de versión que no se desfasa y verificación contra el feed después de publicar— y lo que agrega el segundo: un mismo criterio y un mismo número para todos, heredado de un archivo de propiedades importado explícitamente, con orden de publicación topológico cuando hay aristas internas | Vigente 
 Versionado-Producto-Integral | Qué pieza de un producto multiartefacto lleva número propio y cuál no, cuál es el acto que lo incrementa, dónde vive la fuente única de cada número, cómo se deriva a los atributos del artefacto, dónde se expone para que se pueda leer sin abrir el código, y cómo cada pieza declara con qué versiones de las otras funciona, y la tabla de gobierno que dice regla por regla quién responde, desde qué fase rige y qué la pone en rojo —incluido el valor `nada`—, con el orden de implantación y los esqueletos de las compuertas y los flujos que la sostienen | Vigente 
 WhatsApp-Web-MCP | Conocimiento de canal: cómo el coordinador de una mesa de expertos abre WhatsApp Web en el Chrome sin ventana que expone el MCP `chrome` (chrome-devtools-mcp), lo vincula, verifica el destinatario, envía, lee la respuesta, baja adjuntos y se hace despertar sólo cuando la persona responde (vigía + Monitor) | Vigente 
```

Las 42 filas están `Vigente`.

---

## 3. Versiones medidas

Comando, corrido desde `/IA/<base de conocimiento>`, sobre cada pieza (para las reglas, el mismo `grep` sobre `Rules/`):

```bash
for f in Knowledges/Knowledge-*.md Rules/*.md; do
  echo "== $f: $(grep -m1 '^\*\*Versión' $f) | $(grep -m1 -i '^\*\*Alias' $f)"; done
```

Salida, recortada a las piezas que este relevamiento lista como rigentes o condicionales (la salida completa
cubre las 36 de `Knowledges/` y las 6 de `Rules/`; ninguna tiene alias distinto del nombre de archivo):

| Pieza (ruta desde la raíz del workspace) | Alias | Versión medida | `Condicion-de-carga` |
| --- | --- | --- | --- |
| `<base de conocimiento>/Knowledges/Knowledge-Versionado-Producto-Integral.md` | Versionado-Producto-Integral | **2.0** | Por tema (conjuntiva, ver §5.1) |
| `<base de conocimiento>/Knowledges/Knowledge-Release-Y-Despliegue-Versionado.md` | Release-Y-Despliegue-Versionado | **2.0** | `—` (actúa fuera: sólo por alias) |
| `<base de conocimiento>/Knowledges/Knowledge-Versionado-Paquetes-NuGet.md` | Versionado-Paquetes-NuGet | **2.0** | Por tema (N ≥ 1 paquetes) |
| `<base de conocimiento>/Knowledges/Knowledge-Versionado-Esquema-Base-De-Datos-EF-Layer.md` | Versionado-Esquema-Base-De-Datos-EF-Layer | **2.0** | Por tema (condicional a D-05) |
| `<base de conocimiento>/Knowledges/Knowledge-Conformacion-Pull-Request-Manual.md` | Conformacion-Pull-Request-Manual | **2.0** | Por tema |
| `<base de conocimiento>/Knowledges/Knowledge-Conformacion-Pull-Request-Automatico.md` | Conformacion-Pull-Request-Automatico | **2.0** | `—` (sólo por alias y con delegación asentada) |
| `<base de conocimiento>/Knowledges/Knowledge-Red-Movil-Problematica.md` | Red-Movil-Problematica | **2.0** | Por tema |
| `<base de conocimiento>/Knowledges/Knowledge-Icono-Y-Ancla.md` | Icono-Y-Ancla | **2.0** | Por tema |
| `<base de conocimiento>/Knowledges/Knowledge-Bundle-JS.md` | Bundle-JS | **2.0** | Por tema (condicional, ver §5.9) |
| `<base de conocimiento>/Knowledges/Knowledge-Entorno-De-Ejecucion-Del-Agente.md` | Entorno-De-Ejecucion-Del-Agente | **2.0** | Por tema |
| `<base de conocimiento>/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` | Mesa-De-Expertos-A-Pedido | **3.1** | Por tema (citada por el prompt) |
| `<base de conocimiento>/Knowledges/Knowledge-Mesa-Consulta-A-Un-Tercero.md` | Mesa-Consulta-A-Un-Tercero | **2.0** | `—` (citada por el prompt por ruta) |
| `<base de conocimiento>/Knowledges/Knowledge-Cadena-De-Consecuencias.md` | Cadena-De-Consecuencias | **2.0** | Por tema |
| `<base de conocimiento>/Knowledges/Knowledge-Excepcion-A-Un-Conocimiento.md` | Excepcion-A-Un-Conocimiento | **2.0** | Por tema |
| `<base de conocimiento>/Knowledges/Knowledge-WhatsApp-Web-MCP.md` | WhatsApp-Web-MCP | **2.1** | Condicional (canal) |
| `<base de conocimiento>/Rules/Rule-Mesa.md` | Mesa | **1.0** | Regla |
| `<base de conocimiento>/Rules/Rule-Expediente.md` | Expediente | **1.0** | Regla |
| `<base de conocimiento>/Rules/Rule-Escalas-De-Juicio.md` | Escalas-De-Juicio | **1.0** | Regla |
| `<base de conocimiento>/Rules/Rule-Detencion-Y-Lote.md` | Detencion-Y-Lote | **1.0** | Regla |

**Las tres piezas con `Condicion-de-carga: —`** (Release-Y-Despliegue-Versionado, Conformacion-Pull-Request-Automatico,
Mesa-Consulta-A-Un-Tercero) «actúan fuera» y no se cargan por tema (`Index-Knowledge.md`, «Límites», punto 3;
`Forma-De-Conocimiento` §3.1.1). Entran acá **porque el pedido o la carta las nombran por alias o por ruta**: la
carta de este despacho nombra las tres primeras, y el prompt nombra `Knowledge-Mesa-Consulta-A-Un-Tercero.md`
por ruta (`Crear-Framework-Concept.md`, sección «Solicitudes», viñeta de la mesa).

---

## 4. Clasificación de las 42 filas

| Clase | Alias |
| --- | --- |
| **Rigen el objeto** (§5) | Versionado-Producto-Integral · Release-Y-Despliegue-Versionado · Versionado-Paquetes-NuGet · Conformacion-Pull-Request-Manual · Conformacion-Pull-Request-Automatico · Red-Movil-Problematica · Icono-Y-Ancla · Entorno-De-Ejecucion-Del-Agente |
| **Rigen condicionadas a un supuesto** (§5, con el dato que lo verifica) | Versionado-Esquema-Base-De-Datos-EF-Layer (si D-05 cae en EF Core) · Bundle-JS (si D-01 cae en la opción A y el puente se arma como bundle + interop) · WhatsApp-Web-MCP (si la mesa consulta a un tercero por ese canal) |
| **Rigen la conducción de la mesa** (§6) | Mesa · Expediente · Escalas-De-Juicio · Detencion-Y-Lote · Mesa-De-Expertos-A-Pedido · Mesa-Consulta-A-Un-Tercero · Cadena-De-Consecuencias · Excepcion-A-Un-Conocimiento |
| **Descartadas** (§8) | Las 23 restantes, cada una con su motivo |

---

## 5. Convenciones que rigen el objeto: qué manda cada una

### 5.1 Versionado-Producto-Integral 2.0

- **Por qué rige.** El objeto publica o despliega por separado al menos tres piezas: el cascarón por tienda y el
  paquete de contenido por servidor propio (`Framework-APP.md`, líneas 47–48), más la API del negocio (línea 67).
  La condición de carga es conjuntiva: además exige «la necesidad de atribuir un error de producción a versiones
  exactas». **[criterio propio]** El prompt no lo dice con esas palabras; lo sostienen el riesgo «Deriva del
  puente» (línea 381) y el pedido de que un PR no rompa lo que funcionaba. Si la mesa no lo declara como
  requisito, la pieza rige igual por la segunda rama de §1 («productos … que quieren exportar sus reglas a
  otros»): un framework reutilizable lo es por definición. La presidencia lo declara en el contrato.
- **Secciones que rigen** (su «Mapa de carga», §0): §2.2–§2.5 (qué lleva número), §2.6 (compatibilidad entre
  piezas), §2.7 (línea del esquema), §2.8 (fase), §3.1 (lo que se declara por producto), §3.2–§3.4 (gobierno e
  implantación), §5.7 (integración en cada PR), §6–§7 para juzgar.
- **Qué manda para este caso.**
  1. **Inventario con dos mitades** (§2.2): cada pieza con número o sin número y de quién toma su identidad. La
     regla que decide es el **acto**: lleva número toda pieza con un acto declarado que lo incremente
     (distribuirse, o sustituirse entre realizaciones intercambiables). Cascarón y paquete de contenido se
     distribuyen por canales distintos: **llevan número cada uno**. El contrato del puente expuesto por ruta toma
     su identidad de su `vN` (§2.2, tabla de la segunda mitad); el borrador ya lo nombra `bridgeVersion` (línea 299).
  2. **Gramática por clase** (§2.3, línea 173 del conocimiento): «Aplicación de tienda: SemVer visible **más**
     contador monótono de build». Rige para el cascarón. El paquete de contenido **no tiene fila** en la tabla de
     §2.3: la mesa tiene que asignarle clase (ver §7, T-4).
  3. **Fuente única, contada literal** (§2.4) y número **declarado en el árbol**, con la etiqueta comparada por
     igualdad (§4, segunda fila).
  4. **Compatibilidad con piso y techo** (§2.6): `compatible-con-<servicio>: >=A.B.C <D.0.0`, verificable por
     regex. «**Nunca un piso a secas**» (línea 225 del conocimiento). Toca el `minShellVersion` del borrador (§7, T-1).
  5. **Línea base de API pública por marco de destino**, y detectar ≠ clasificar (§2.6, R13–R14). Toca al puente
     C#↔JS y al cascarón si se distribuye como biblioteca: `net10.0-android` y `net10.0-ios` son marcos distintos.
  6. **Fase declarada** en `<raiz>/versionado/rutas.json` (§2.8, R20): `diseño` | `candidata` | `operativa`; sin
     declarar se lee `operativa`. **[criterio propio]** El framework y la demo nacen en `diseño`.
  7. **Gobierno con cuatro valores** (`gate:`, `prueba:`, `manual: con registro`, `nada`) y `nada` **obligatorio de
     escribir** (§3.2).
  8. **Aviso no es impedimento** (§3.3, punto 1, línea 377 del conocimiento): una CI roja sin mecanismo que
     bloquee la fusión es un aviso; si la plataforma no ofrece el bloqueo en el plan contratado, **se declara**.
     Es el núcleo del problema del prompt («al no dispararse pruebas automatizadas puede romper funcionalidades»).
  9. **Implantación por tramos, primero lo que hace cumplir** (§3.4): T1 = integración mínima como control
     requerido sobre la rama principal y PR obligatorio, con **rojo provocado** (el botón de fusionar
     deshabilitado) y prueba de implantación; después T2 identidad, T3 compatibilidad, T4 la política dice la
     verdad, T5 ciclo completo. «Hasta que el ciclo corrió entero una vez, el sistema está diseñado, no implantado».
  10. **Costo medido**: si el número obligatorio de archivos que una compuerta exige para el cambio más frecuente
      pasa de cinco, «el problema es de diseño y no de disciplina» (§3.3).

### 5.2 Release-Y-Despliegue-Versionado 2.0 (por alias)

- **Por qué rige.** Publicar un paquete de contenido a los teléfonos es un release con efecto externo; la carta
  la nombra por alias. Hereda de Versionado-Producto-Integral.
- **Secciones que rigen:** §2.1 (cinco piezas), §2.2 (invariantes), §2.4 (premisas), §3.2 (vuelta atrás y clase
  de reversión), §3.3 (hotfix), §3.4 (registro de despliegues), §3.5 (atribución de un error), §5.1–§5.2
  (manifiestos).
- **Qué manda para este caso.**
  1. **Un release es un artefacto, no un acto**: construido una sola vez desde un commit etiquetado y promovido
     sin recompilar (invariante 1). Los canales `dev`/`beta`/`prod` del borrador (línea 132) promueven el mismo
     paquete, no lo reconstruyen.
  2. **Identidad = versión + commit, nunca reutilizada** (invariante 2): un número quemado no se reapunta.
  3. **Manifiesto mecánico dentro del artefacto** (invariante 3, §5.1), legible sin desplegar y sin red. El
     `manifest.json` del borrador vive **en el servidor** (línea 132): falta el que viaja adentro del paquete.
  4. **Integridad verificable donde se la necesita**: resumen publicado y verificado **sobre lo descargado,
     antes de desempaquetar** (invariante 12). Coincide con «descargar a `staging/`, verificar, descomprimir»
     (línea 138).
  5. **Después de arrancar, el artefacto se declara a sí mismo** (invariante 5). Coincide con el «arranqué bien»
     por el puente (línea 139).
  6. **Retención con número escrito, N ≥ 3** (invariante 10). Ver §7, T-2.
  7. **«Saltado» nunca pinta verde** (invariante 13); **el manifiesto humano se publica antes de desplegar**
     (invariante 14).
  8. **Atribución de un error** (§3.5): un observador que no es desarrollador produce un reporte atribuible a
     versiones exactas. **[criterio propio]** En el teléfono eso pide mostrar versión del cascarón, del contenido
     y del puente en una superficie visible (padre §2.5, «Pie de las superficies visibles»).
  9. **Naturaleza de la evidencia**: el documento rotula `[ensayado]`/`[medido]`/`[derivado]` y exige que quien lo
     adopte **ensaye el ciclo entero una vez** antes de darlo por implantado (§0). Su apéndice por destino (§2.3)
     no tiene columna para «paquete descargado por un cliente móvil»: es una realización a declarar.

### 5.3 Versionado-Paquetes-NuGet 2.0

- **Por qué rige.** **[criterio propio]** Un framework reutilizable por varias apps se consume, en .NET, como
  paquetes (cascarón, puente C#); la condición de carga se dispara con N ≥ 1. Si la mesa decide distribuir el
  framework sólo como plantilla de código y no como paquete, la fila pasa a descartada, con ese motivo.
- **Secciones que rigen:** §2.3 (una sola fuente: manda el repositorio o manda la etiqueta, y no hay tercera),
  §2.4 (archivo de propiedades importado explícitamente), §2.5 (etiqueta `nuget-v<version>` distinta de
  `v<version>`), §2.7 (línea base que detecta **y clasifica**, por marco de destino), §2.9 (verificación contra
  el feed después de publicar).
- **Qué manda para este caso.** Con N ≥ 2 paquetes, **mismo criterio y mismo número para todos** (§2.1). Y un
  límite medido que toca de lleno a MAUI: los analizadores de API pública corren por marco, así que «un marco
  que sólo compila en otro sistema operativo —el de un paquete de dispositivo— **no queda cubierto antes de
  fusionar** si la integración corre en uno solo. Eso se declara; no se supone cubierto» (§2.7, punto 3, líneas
  224–226). El runner `[self-hosted, i7infra-dev]` es Linux (bitácora `00-Registro.md`, entrada 4): el marco iOS
  queda sin cubrir en el PR y se declara.

### 5.4 Conformacion-Pull-Request-Manual 2.0

- **Por qué rige.** El prompt pide «procedimientos claros en los PR»; la guía tiene que enseñar el ciclo.
- **Secciones que rigen:** §1 (actores), §2 (los ocho turnos), §3 (obligaciones y prohibiciones), §6.
- **Qué manda para este caso.** Ocho turnos: compuerta de arranque publicada siempre, una unidad declarada por
  rama, rama-commit-push, cierre con el enlace del PR y «qué sigue después del merge», **merge y borrado del
  humano**, acuse, verificación por alcanzabilidad y continuación. La propiedad que sostiene todo: «el merge es
  el punto donde alguien que no escribió el cambio lo mira» (§1). **Lo que no declara**: protección de rama,
  revisores obligatorios, controles automáticos, convención de nombres de rama y commit — «no se inventa acá»
  (§0, «Qué queda explícitamente afuera»). Eso lo tiene que fijar la documentación de operación del producto,
  es decir, **el entregable N3**.

### 5.5 Conformacion-Pull-Request-Automatico 2.0 (por alias)

- **Por qué rige.** La carta la nombra; describe la guarda de merge que el problema del prompt pide.
- **Secciones que rigen:** §3.1 (delegación), §3.3 (guarda), §3.4 (reservas), §3.5 (prohibiciones).
- **Qué manda para este caso.** Sólo vale **con la delegación del merge asentada, con fecha y responsable, en un
  lugar versionado del repositorio destino**; sin ella rige el manual (§3.1). La **guarda G1–G4** (§3.3) es lo
  que la guía puede enseñar como «qué tiene que ser verdad para fusionar»: cabeza auditada igual al SHA, estado
  `clean`, **al menos una** corrida de controles para ese SHA y todas en éxito («Ninguna: reserva —no hubo
  controles»), sin reserva declarada. Prohíbe aplastar (`squash`) cuando la rama lleva un expediente (§3.5).
  **[criterio propio]** En esta corrida ningún subagente hace commits ni push (contexto común de la carta): para
  la ejecución actual rige como contenido de la guía, no como procedimiento del despacho.

### 5.6 Red-Movil-Problematica 2.0

- **Por qué rige.** El borrador pide estado de red, registro de actividad y política de acciones según la red
  (`Framework-APP.md` §6 y §7, líneas 208 y 242), y el autoactualizador decide con o sin red (línea 113). Probar
  eso en emulador es exactamente la condición de carga («diseñar una prueba de resiliencia de red de una app
  móvil»).
- **Secciones que rigen:** §1 (medio y límites), §2.2 (catálogo), §3.1 (ficha de entrada), §3.2 (contrato de
  escenario que cada app declara), §3.5 (validez VÁLIDA/INVÁLIDA/INCONCLUYENTE), §3.6 (oráculos), §3.8 (reglas
  para agentes).
- **Qué manda para este caso.** El contrato de escenario (§3.2) sirve «para **apps con WebView depurable**»: la
  demo lo cumple si el contenido corre en el WebView con DevTools habilitado. El **oráculo sale del requisito**,
  no de un umbral: el escenario declara el presupuesto de reintentos por falla y cuánto después de quitarla no
  debe llegar nada al servidor (§3.6). Resultados como «k de n válidas (m registradas)», nunca sí/no (§3.5).
  **Límites declarados**: «iOS sin medir» (línea 39 del conocimiento), «no emula el radio», y el fondo de red
  móvil es SUPUESTO calibrado (§0). Nunca producción; un teléfono real «pega en producción y se usa sólo con
  aviso al responsable del producto» (§3.8).

### 5.7 Icono-Y-Ancla 2.0

- **Por qué rige.** La guía es «para un desarrollador sin experiencia» (prompt, «Solicitudes»): es literalmente
  documentación para alguien que no participó de la discusión (condición de carga).
- **Secciones que rigen:** §2 (tres partes de una definición), §3.1 (dos pruebas), §3.2 (reparar un icono), §5
  (esqueleto de entrega), §6 (auditoría).
- **Qué manda para este caso.** Cada definición de la guía (cascarón, contenido, puente, manifiesto, canal,
  rollback, compuerta, fase…) se entrega con **texto + operación + escena con datos**; falta una y es icono.
  Prueba de la operación: si «qué hace el lector con esto» empieza con «entiende que», es icono. La escena sale
  **del caso** (la demo basada en `MovilidadUrbana.MAUI`), no del repertorio, y no se repite en cinco
  definiciones (§3.3). Una definición cuya operación no se puede reconstruir se declara como orientación (§3.2,
  paso 4; D-3).

### 5.8 Entorno-De-Ejecucion-Del-Agente 2.0

- **Por qué rige.** La corrida es un workflow con subagentes que relayan informes, esperan tareas en segundo
  plano y suplen herramientas ausentes en el host (el registro ya muestra que no hay `gh` y que el g42 no se ve
  por USB: `00-Registro.md`, entrada 4).
- **Secciones que rigen:** §2.1–§2.3 (clases de origen O1–O5 y qué hacer con O4), §3.3 (cuándo un tema de
  comportamiento amerita mesa), §3.4 (subagente, tarea en segundo plano, herramienta ausente, credencial).
- **Qué manda para este caso.** El informe de un subagente se relaya con conclusiones, rutas y lo no verificado
  —nunca «ver el informe»—; una herramienta ausente en el host se corre en contenedor efímero y «**no se concluye
  que no se puede**»; una credencial se usa sólo en memoria de proceso y nunca va a archivo, commit, informe ni
  bitácora (§3.4).

### 5.9 Condicionales

| Alias · versión | Supuesto | Dato que lo verifica | Qué manda si el supuesto se cumple |
| --- | --- | --- | --- |
| **Versionado-Esquema-Base-De-Datos-EF-Layer 2.0** | D-05 se resuelve por **EF Core** sobre SQLite | `Framework-APP.md` línea 372: «D-05 · sqlite-net-pcl vs EF Core · Inclinación: sqlite-net-pcl». La demo de base usa «EF Core 10 sobre SQLite» (`/LAB/Lab-E2E.WebBlazor/Lab-E2E.WebBlazor.Documentacion/ia-db/README.md`, línea 34) | Realiza el contrato de §2.7 del padre con el historial de migraciones de la herramienta; «sobre cualquier proveedor relacional soportado» (§1, línea 72). **Su evidencia es derivada, no medida** (§0). Si D-05 queda en sqlite-net-pcl, ninguna realización de la base cubre la línea del esquema local: el contrato de §2.7 del padre rige igual y la mesa declara su realización |
| **Bundle-JS 2.0** | D-01 en la opción A **y** el puente se arma como módulo JS + envoltorio C# (`bridge.js`, `Framework-APP.md` línea 299) | El stack verificado de Bundle-JS es Interactive Server; «WebAssembly y Auto **no están verificados**» (línea 100 del conocimiento) | §3.7: la traza de un error del cliente tiene que nombrar la versión del bundle/interop que lo originó (T-1 incrustada en el artefacto, T-2 alcanzable desde el navegador, T-3 coincidencia comprobable entre lo declarado y lo publicado); §3.4 procedimiento de cambio coordinado del contrato. Lo no verificado en WASM se declara |
| **WhatsApp-Web-MCP 2.1** | La mesa consulta a un tercero por WhatsApp | Que la carta de la mesa lo nombre | Conocimiento de canal de `Mesa-Consulta-A-Un-Tercero` §8.1. Con otro canal, no rige |

---

## 6. Lo que la presidencia necesita para operar la mesa

Resumen operativo, con sección citada. No reemplaza la lectura de las piezas: cada carta las nombra con su ruta y
versión.

### 6.1 Relación entre las dos normas de mesa

- **Mesa-De-Expertos-A-Pedido 3.1** rige porque el prompt la pide por nombre. Las tres cláusulas de `Mesa` §3.1
  (corpus previo, estado leído, plan o decisión de alcance sobre ese corpus) **se leen sobre el objeto**
  (`Mesa-De-Expertos-A-Pedido` §1, «Relación con la mesa normativa»). **[criterio propio]** El objeto es el diseño
  de un framework que todavía no existe: la tercera cláusula no la cumple un corpus de especificación, así que
  **`Mesa` se usa como forma** y las diferencias son las de su §2.2. La clase de objeto que corresponde es
  **«Diseño de una norma o decisión»** (§2.2): las comisiones de dominio citan fuentes externas con número o
  autor, **no inventan cláusulas**, y el refutador ataca **el costo de aplicarla**; cierra con **un dictamen que
  responde cada pregunta del pedido por separado, sin «depende»**. Si la mesa ensaya la demo en un emulador, suma
  roles de «interfaz en ejecución» sólo si una señal lo pide (§2.2, «Un objeto de dos clases»).

### 6.2 Roles

| Rol | Fuente | Lo que no hace |
| --- | --- | --- |
| **Presidente** | `Mesa-De-Expertos-A-Pedido` §1 | **No vota**; consolida sin juzgar (`Mesa` §3.5.3) |
| **Núcleo permanente**: Requisitos, Verificación, Lector sin contexto, Refutador | `Mesa` §3.4.1 | El refutador entra último y es el único que lee informes |
| **Catálogo variable por señal con ubicación** — para este objeto, señales visibles: Arquitectura (más de una unidad de entrega, líneas 47–48), Seguridad (biometría y firma, §4 y línea 137), Operación y entrega (versionado, canales), Concurrencia y tiempo (outbox, reintentos), Interfaz externa (contrato del puente, línea 297), Rendimiento (peso del WASM, línea 90), Datos y dominio (SQLite, §8) | `Mesa` §3.4.2 | Más señales que cupo → se prioriza y se registran los postergados |
| **Ad hoc con carta de mandato** (p. ej. edición académica de material bibliográfico, que el prompt pide y el catálogo no tiene) | `Mesa` §3.4.4, esqueleto en `Mesa` §5 | Sin carta, sus salidas se descartan |
| **Relevador de señales** (sin voto, sin hallazgos) | `Mesa` §3.5.2, punto 2 | — |
| **Análisis de decisiones** (si el refutador admite una ficha de excepción) | `Mesa-De-Expertos-A-Pedido` §1 y §2.1 paso 6 bis | No vota |
| **Jurado de cinco**: Evidencia, Impacto, Costo y beneficio, Coherencia histórica, Riesgo e irreversibilidad | `Mesa` §3.5.4 | Vota composición (Fase 0) y veredicto (Fase 2); empate en composición **convoca** |
| **Perito** | `Mesa` §3.5.4 | Responde y **no vota** |
| **Cuerpo de parches** | `Mesa` §3.5.5 | No vota su parche |
| **Quien aplica** | `Mesa-De-Expertos-A-Pedido` §4 | Nunca un rol del panel ni el jurado |
| **Entrevistador y coordinador (mensajero)**, si se consulta a un tercero | `Mesa-Consulta-A-Un-Tercero` §1 | **Una sola mano en el canal**; el entrevistador no inventa preguntas |

**Techo**: núcleo + **cinco** variables o ad hoc por ciclo (`Mesa` §3.4.5). **[criterio propio]** El prompt pide al
menos analistas en sistemas, arquitectos MAUI, especialistas en análisis de decisiones y académicos en edición de
material bibliográfico; con las señales de arriba se excede el techo: la composición la vota el jurado y los
postergados se registran (`Mesa` §3.5.2: «La composición nunca es motivo de escalada»).

### 6.3 Esqueleto de carta (despacho de una comisión)

Sale de `Mesa-De-Expertos-A-Pedido` §5.2. Toda carta, de cualquier rol, conserva (§5.2, último párrafo):

1. objeto y clase de objeto;
2. **pedido literal** (la presentación tal cual, no parafraseada, §3.1);
3. **objetivo con el origen de cada cláusula** — lo que da por fijo sin origen es el primer hallazgo;
4. la cláusula **`BLOQUEO: paso — salida — prueba de una variable`**;
5. competencia y no-competencia (fuera de mandato: solicitud de convocatoria, no hallazgo);
6. nivel P0–P3 con **la lectura del caso** y clase de ancla E1–E4 o C;
7. si la clase es diseño de norma: toda afirmación sobre la industria o la academia **con su fuente**, sin
   cláusulas inventadas;
8. **convenciones que rigen** (este relevamiento, §9) y la obligación de ficha de excepción si propone no
   seguir alguna; correr `Cadena-De-Consecuencias` §2 antes de recomendar entre opciones;
9. la norma con ruta y versión, lectura en dos pasos (líneas 1 a **111** de `Mesa-De-Expertos-A-Pedido`: medido
   `grep -n '^## 1\.'` → `112:## 1. Identidad del artefacto`) y la fila «Secciones … leídas» en la cabecera del folio;
10. tope de hallazgos, hasta tres ítems de «lo que revisé y está bien», y **la ruta del folio**
    (`<carpeta-del-caso>/despacho/<rol>.md`, §2.3) donde la comisión escribe verbatim.

Cada carta se archiva en `evidencia/` **antes** de despachar (§2.1, paso 2). Contrato de entrada: §5.1 (campos
`PEDIDO`, `ENUNCIADO`, `CLASE DE OBJETO`, `OBJETIVO`, `PREGUNTAS DEL CASO`, `LECTURA P0–P3`, `RESTRICCIONES DURAS`,
`DECISIONES CERRADAS`, `CONVENCIONES QUE RIGEN`, `FUERA DE ALCANCE`, `MEDIOS`, `EXPEDIENTE`, `QUIÉN APLICA`,
`PRESUPUESTO`, `DESPACHO VERIFICADO`). **Ningún despacho sale antes del enunciado** (§2.1, paso 1).

### 6.4 Escalas

- **P0–P3, una sola escala** (`Escalas-De-Juicio` §3.1); la presidencia declara **la lectura del caso** en el
  contrato y en cada carta (§3.2). Forma de referencia (`Mesa-De-Expertos-A-Pedido` §5.1): P0 viola una
  restricción dura o hace imposible el objetivo; P1 haría salir el plan con retrabajo o interpretación
  divergente; P2 pérdida acotada; P3 claridad.
- **Ancla** E1 (comando y salida) · E2 (cita con archivo y línea) · E3 (contraejemplo reproducible) · E4 (regla
  declarada) · **C sólo funda una pregunta** (`Escalas-De-Juicio` §3.3). Un testimonio no es E4 por sí mismo.
  Una afirmación de colisión de término, sólo con E1 (§3.4, regla 2). Un hallazgo heredado entra como C (§3.4,
  regla 4).

### 6.5 Expediente

- **Se abre** si el caso atraviesa más de una corrida o repositorio, o entra material externo que funda una
  decisión (`Expediente` §1). Ya está abierto: `OUTPUTs/Expedientes/0001-Framework-Concept-Maui-Autoactualizable/`
  (`00-Registro.md`, entrada 3).
- **Folios** `actuaciones/NNN-<tipo>-<slug>.md`, número asignado **al incorporar** (el siguiente libre, nunca
  reservado); cabecera de cuatro filas `Tipo · Fecha · Autor · Corrige`; última línea no vacía, el pase
  `Sigue: <acto> · <quién>` (`Expediente` §3.1 y §3.3). **Seis tipos**: `presentacion`, `providencia`, `informe`,
  `constancia`, `resolucion`, `archivo`; el estado se deriva de la secuencia (§3.4).
- **Correspondencia de la mesa** (`Mesa-De-Expertos-A-Pedido` §2.3): pedido literal → `presentacion` con
  testimonio; contrato y verificación del despacho → `providencia`; cartas → `evidencia/`; informes de comisiones,
  refutador, perito, análisis y los dos del jurado → `informe` verbatim, escritos por cada rol en su ruta de
  trabajo; cada ficha de excepción → `informe` propio (`XC-<n>`); plan y cierre → `resolucion`. «Vive en la sesión
  del coordinador» **no es un estado admisible**.
- **Evidencia cruda** (capturas, ndjson, videos) queda local por `.gitignore` con su huella SHA-256 en el folio
  (§2.3 y §5.3). Antes de versionar, **se barre** de secretos y datos personales y el cierre lo declara.

### 6.6 Cierre, cuenta de folios y criterio de corte

- **Cuenta de folios** (`Mesa-De-Expertos-A-Pedido` §2.1, paso 10): comisiones convocadas + refutador + análisis
  de decisiones (si se convocó) + perito (si lo hubo) + roles de interfaz en ejecución (si se convocaron) + **los
  dos del jurado** (composición y veredicto); las fichas se listan aparte. **Si no da, la mesa no está cerrada.**
  Se cruza la fila «Secciones leídas» de cada folio contra el «Mapa de carga».
- **Bloque de cierre** de `Mesa` §5 (PANEL, HALLAZGOS, COMPUERTA, ENTREGA, CIERRE) más la fila `Reintegra`, el
  apartado «Excepciones a conocimientos» (`Excepcion-A-Un-Conocimiento` §5.2), la deuda declarada con su evento de
  cierre y las preguntas sobrevivientes **en lote con `SI NO RESPONDÉS`**.
- **Criterio de corte** (`Mesa` §3.5.7; `Mesa-De-Expertos-A-Pedido` §4): **por criterio** sólo con dos rondas
  seguidas sin hallazgos interpretativos; una ronda es un ciclo completo (base mecánica → panel → comisiones →
  refutación → veredicto). Con una sola ronda se cierra **por decisión**, sin que sea falta, **y se dice**. Ni la
  regla propia de la clase ni el presupuesto son criterio de corte. Con cuatro rondas sin alcanzarlo, la decisión
  sube a quien pidió. Se mide y declara el rendimiento por especialista (procedentes / especialistas).
- **La mesa no aplica** (`Mesa` §3.5.6); la verificación de cada parche la corre quien lo aplica.

### 6.7 Escaladas, detenciones y bloqueo

- **La mesa decide sola** salvo la lista cerrada de `Mesa` §3.6: ambigüedad irresoluble (lote), conflicto de
  restricciones duras (**bloquea**), cambio de alcance (**bloquea**, salvo que el pedido mismo sea el cambio),
  irreversibilidad material (lote con propuesta), consecuencia externa (lote con propuesta), empate persistente
  (lote), reapertura de decisión cerrada (lote). **Antes**, el origen del hecho (`Detencion-Y-Lote` §3.1).
- **Forma de toda escalada**: la de una detención (`Detencion-Y-Lote` §3.3 y §5.1) con `SI NO RESPONDÉS`
  (`Mesa` §3.6.1). **No se asienta por silencio**: una fila de alcance, una excepción, una aprobación
  (`Detencion-Y-Lote` §3.5, regla 7). Un default nunca es una fase irreversible (regla 8).
- **Fases irreversibles** (`Detencion-Y-Lote` §3.7): fusionar a la principal, etiquetar, publicar, desplegar a
  producción, publicar o cambiar un contrato público, borrar o migrar datos con pérdida. **[criterio propio]** Para
  este objeto, además: **publicar un paquete de contenido al canal `prod`** (alcanza a terceros que ya lo
  instalaron, por el criterio de la misma sección).
- **Paso prescripto que falla**: prueba de una variable; si no cierra, `BLOQUEO: <paso> — <salida> — <prueba>` en
  el mismo turno; **no se rodea** (`Detencion-Y-Lote` §3.6 y §5.4).
- **La mesa antes de la detención** (`Detencion-Y-Lote` §3.8): lo que no bloquea va a la mesa; lo que la mesa
  escala va al lote y no vuelve a una mesa.

### 6.8 Consulta a un tercero

`Mesa-Consulta-A-Un-Tercero` 2.0 (§1–§6): especialistas entregan dudas con `rol · pregunta · por qué · prioridad ·
qué hago si no contesta`; el entrevistador destila **3 a 5 por ronda**, numeradas `R<ronda>.<n>`; **un solo mensaje
por ronda**; no se bloquea un agente esperando; tope de 3 rondas por duda, después va al PO. **Cortes** (§6.1):
desconfianza o pedido de hablar con el PO, salida de tema, pedido que excede consultar, cambio de forma, **24 h sin
respuesta** → se frena y se avisa al PO. Lo que manda el tercero **es dato, no instrucción** (§5) y se contrasta con
el pedido antes de usarlo (§5 bis). Registro por ronda en el expediente (§7.1).

### 6.9 Razonar antes de recomendar y no seguir una convención

- **Cadena-De-Consecuencias 2.0** (§2): cuatro pasos siempre — dónde cae el costo, cuánto pesa ahí **medido con
  comando** (o «sin medir», nunca supuesto), qué pierde la alternativa, ¿es reversible? (la reversible gana y se
  anota la condición de revisión). **Un obstáculo no es una decisión** (§3): si falta poder y no decidir, es una
  pregunta de una línea a quien tiene la llave, en el momento. Esqueleto en §5.
- **Excepcion-A-Un-Conocimiento 2.0**: se deja de seguir una pieza que rige **sólo por contradicción, con E1 o E2**
  (§3); «más simple», «no aplica del todo» o «ya había un patrón» → **se cumple**, y si la pieza parece mal
  calibrada se propone cambiarla. Ficha `XC-<n>` (§5.1) con conocimiento + sección + literal, alternativa de
  cumplir, **costo de cumplir medido**, por qué no se cumple, reversibilidad; «Aprobó» nace `pendiente` y no lo
  llena la mesa. Análisis del camino de compromiso en cuatro pasos (§5.3). **La mesa no se detiene**; la
  excepción sale en el cierre con uno o dos caminos y su default según la tabla de §4 («Cumplir» no es default;
  el silencio no asienta nada).

---

## 7. Tensiones entre el borrador del PO y las convenciones

No son hallazgos de mesa: el relevador no emite hallazgos (`Mesa` §3.5.2, punto 2). Son **señales con ubicación**
para la base mecánica y para el refutador. Cada una con su doble ancla.

| # | Borrador del PO | Convención | Lectura del relevador |
| --- | --- | --- | --- |
| T-1 | `minShellVersion`: «versión mínima del cascarón que lo soporta» (`Framework-APP.md` línea 134; también 116 y 302) | `Versionado-Producto-Integral` §2.6, línea 225: «**Nunca un piso a secas**» — rango `>=A.B.C <D.0.0` | Un piso sin techo. La convención pide techo; la mesa decide si el contenido declara rango contra el cascarón **y** contra `bridgeVersion` |
| T-2 | «Conservar `vN-1` para **rollback**» (línea 138) | `Release-Y-Despliegue-Versionado` §2.2, invariante 10 (línea 142): retención «con un número escrito (N ≥ 3)» | Retención N = 2 en el teléfono. **[criterio propio]** La premisa del invariante es un servidor con espacio; en un teléfono el espacio pesa. Si se sostiene N = 2, es candidata a ficha de excepción **sólo con contradicción medida**; si no, se cumple |
| T-3 | «**Migraciones:** tabla `SchemaVersion` + scripts numerados que corre el cascarón **al arrancar**» (línea 291) | `Versionado-Producto-Integral` §2.7, cláusula 2 (línea 265): «Aplicar migraciones al arrancar **se rechaza**: carreras entre instancias, permisos de DDL en el proceso, ninguna vuelta atrás ni respaldo previo» | **[criterio propio]** Las tres premisas del rechazo son de servidor; en una base local de un teléfono no hay otro actor que aplique la migración. Es el caso típico de excepción **por contradicción** (E2 sobre esta línea + E1 si se mide), con ficha `XC-<n>` y camino de compromiso; no se resuelve por silencio |
| T-4 | Paquete de contenido versionado (`version` del paquete, línea 133) | `Versionado-Producto-Integral` §2.3: la tabla de gramática no tiene fila para un paquete de contenido descargado por un cliente | Hueco de la convención para este objeto: la mesa asigna clase y gramática y lo declara (`Mesa-De-Expertos-A-Pedido` §3.4: «Una fila cuyo Tema toca el objeto sólo con cierto stack se lista condicional») |
| T-5 | `manifest.json` **en el servidor** (línea 132) | `Release-Y-Despliegue-Versionado` invariante 3: el manifiesto mecánico va **adentro del artefacto** | El borrador tiene el índice de canal; falta el manifiesto interno del paquete. No se contradicen: son dos piezas |
| T-6 | El problema del prompt: un PR sobre rama estable rompe lo que funcionaba «al no dispararse pruebas automatizadas» | `Versionado-Producto-Integral` §3.3 punto 1 (línea 377) y §3.4 tramo T1 | Sin control que **impida** fusionar en rojo, la integración es un aviso. Si la plataforma no lo ofrece en el plan contratado, se declara (ver §10, NV-1) |
| T-7 | Runner `[self-hosted, i7infra-dev]` (prompt) — Linux | `Versionado-Paquetes-NuGet` §2.7, punto 3 (líneas 224–226) | El marco iOS no queda cubierto antes de fusionar con un solo runner Linux: se declara, no se supone |

---

## 8. Descartes, con motivo

| Alias | Motivo |
| --- | --- |
| Clean-Architecture-DataManager | Persistencia SQL Server por ADO.NET sin ORM, para API REST o monolito web (condición de carga). El objeto persiste en SQLite local y la demo usa EF Core |
| DataTier-DataBase-Layer | Capa de datos SQL Server con procedimientos almacenados; el objeto no tiene SQL Server |
| DataTier-DataBase-Layer-Acceso-NET | Consume los procedimientos de DataTier; mismo motivo |
| Deduccion-De-Reglas-De-Negocio | Deriva reglas de negocio de una fuente en prosa; el objeto es un framework técnico, no una fuente de negocio. **[criterio propio]** Reconsiderar si la mesa tiene que extraer reglas de la política de acciones offline (`Framework-APP.md` §7) |
| Forma-De-Conocimiento | Rige la forma de las piezas de la base; ningún entregable de este prompt es una pieza de la base. Se cita sólo como fuente de §3.1.1 (piezas con `—`) |
| Indexing | Construir o actualizar una ia-db; el prompt sólo **lee** la ia-db de Lab-E2E.WebBlazor |
| Media-File-Service-DataTier | Realización SQL Server del servicio de archivos; sin SQL Server |
| Media-File-Service-EF | Realización EF Core **sobre SQL Server** del servicio de archivos; la persistencia del objeto es SQLite local |
| Media-File-Service-SMB | Servicio de archivos del **servidor** por recurso compartido SMB. **[criterio propio]** La cámara del borrador sube fotos «según la política de red» (línea 206) a la API del negocio, que el prompt no pide diseñar; si la mesa incorpora el lado servidor de la suba, la fila pasa a condicional |
| Media-File-Service-SMB-Esqueletos | Sólo se carga con el padre adoptado; mismo motivo |
| Migraciones-SQL-Versionadas | SQL Server con procedimientos y DataManager (condición de carga). Su tabla de clases de reversión es útil como referencia de T-3, pero la realización no aplica a SQLite |
| Migraciones-SQL-Versionadas-Esqueletos | Mismo motivo |
| Parametros-De-Sistema | Tabla `lut_Parametros` en SQL Server; el objeto no tiene SQL Server |
| Parametros-De-Sistema-Esqueletos | Mismo motivo |
| Perfiles-Y-Extension | Crear un perfil de la base para un framework; el prompt aplica un perfil existente del PromptFramework, no crea uno de la base |
| Template-Blazor-Interactive-Server-Panel-De-Control | Render mode Interactive Server servido por el host; el contenido del objeto es Blazor híbrido/WASM en WebView (`Framework-APP.md` líneas 85–90). Sin panel de administración en el pedido |
| Template-Blazor-Interactive-Server-SDD-Default | Interactive Server; mismo motivo. La web de la demo base lo usa, pero el prompt toma de base sólo `MovilidadUrbana.MAUI` |
| Template-Blazor-Interactive-Server-Sistema-De-Diseno-V2 | Interactive Server; mismo motivo |
| Template-Blazor-Interactive-Server-Sistema-De-Diseno-V2-Componentes | Mismo motivo |
| Template-HTML-Panel-De-Control | Maqueta de panel de administración; no está en el pedido |
| Template-HTML-Panel-De-Control-Recorridos | Mismo motivo |
| Template-HTML-SDD-Default | Maqueta HTML sin build; el pedido no pide maqueta |
| Template-HTML-Sistema-De-Diseno-V2 | Mismo motivo |

Total: 8 rigen + 3 condicionales + 8 de conducción + 23 descartadas = **42**, igual al recuento del índice (§1).

---

## 9. Bloque listo para el contrato de entrada

```text
CONVENCIONES QUE RIGEN:
  Índice:   <base de conocimiento>/Knowledges/Index-Knowledge.md (generado 2026-10-24 · 081082a; HEAD 1585af9, sin cambios en piezas que rigen)
  Barrido:  grep '^| \[' Index-Knowledge.md | cut -d'|' -f4,6,12   → 42 filas, todas Vigente (salida en R4 §2)
  Versión:  grep -m1 '^\*\*Versión' <documento>

  Objeto:
    Versionado-Producto-Integral 2.0              §2.2–§2.8, §3.1–§3.4, §5.7, §6–§7
    Release-Y-Despliegue-Versionado 2.0 (alias)   §2.1, §2.2, §2.4, §3.2–§3.5, §5.1–§5.2
    Versionado-Paquetes-NuGet 2.0                 §2.1, §2.3–§2.5, §2.7, §2.9   (si el framework se distribuye como paquete)
    Conformacion-Pull-Request-Manual 2.0          §1–§3, §6
    Conformacion-Pull-Request-Automatico 2.0 (alias) §3.1, §3.3–§3.5   (sólo con delegación asentada)
    Red-Movil-Problematica 2.0                    §1, §2.2, §3.1, §3.2, §3.5, §3.6, §3.8
    Icono-Y-Ancla 2.0                             §2, §3.1–§3.4, §5, §6
    Entorno-De-Ejecucion-Del-Agente 2.0           §2.1–§2.3, §3.3, §3.4
  Condicionales:
    Versionado-Esquema-Base-De-Datos-EF-Layer 2.0 si D-05 = EF Core (hoy «Inclinación: sqlite-net-pcl», Framework-APP.md:372)
    Bundle-JS 2.0                                 si D-01 = A y el puente es bundle + interop (WASM no verificado en Bundle-JS §1)
    WhatsApp-Web-MCP 2.1                          si la consulta a un tercero va por WhatsApp
  Conducción:
    Mesa 1.0 (como forma) · Expediente 1.0 · Escalas-De-Juicio 1.0 · Detencion-Y-Lote 1.0
    Mesa-De-Expertos-A-Pedido 3.1 (clase: diseño de una norma o decisión)
    Mesa-Consulta-A-Un-Tercero 2.0 (alias, citada por el prompt) · Cadena-De-Consecuencias 2.0 · Excepcion-A-Un-Conocimiento 2.0
  Descartes: 23, con motivo en R4 §8.
```

---

## 10. No verificado

| Id | Qué | Motivo |
| --- | --- | --- |
| NV-1 | Si el repositorio donde vivirá la demo y su CI tiene un control que **impida** fusionar con la CI en rojo (protección de rama o reglas de repositorio) | Fuera del alcance de este relevamiento (no se consultó la API de la plataforma; no hay `gh` en el host según `00-Registro.md`). Es dato del núcleo N3 y del relevamiento de entorno |
| NV-2 | Si existe en algún repositorio destino una **delegación del merge asentada** que habilite `Conformacion-Pull-Request-Automatico` | No se buscó en los repositorios destino; la pieza exige encontrarla, no suponerla (§3.1) |
| NV-3 | Que el contenido WASM corra en el WebView con DevTools depurable, que es lo que pide el contrato de escenario de `Red-Movil-Problematica` §3.2 | Depende del ensayo E01 del workflow 1, que no es de este relevamiento |
| NV-4 | Si la necesidad de «atribuir un error de producción a versiones exactas» (condición conjuntiva de `Versionado-Producto-Integral`) queda declarada como requisito | El prompt no lo dice con esas palabras; lo tiene que declarar la presidencia en el contrato (§5.1 de este relevamiento) |
