# Defectos del conocimiento — ronda 1 del expediente 0003

Conocimiento medido: `knowledge-DocsAsCode-Designing-Specification.md` 1.0 (borrador), en `{dir-de-trabajo}/conocimiento/`.
Casos: **C0** (el propio Lab-Documentos), **C1** (proyecto con panel y API), **C2** (`{servicio-privado}`; de él sólo
se toma la forma genérica del defecto). Dos corridas independientes por caso (r1, r2).

Fuente: los defectos de cada caso (C0 K-01..K-13, C1 DC1-01..DC1-16, C2 K-01..K-19), sus corridas (M2, M5, M6) y su
M7. Se deduplicó por sección del conocimiento y causa: 48 defectos de origen quedan en 27 consolidados.

## 1. Corridas

| Corrida | M2 discrepancias (umbral 3) | M5 suposiciones | M6 | M7 (diferencias r1/r2) |
| --- | --- | --- | --- | --- |
| C0-r1 | 6, no pasa | 6 | Rojo: IDs del RRD nuevo chocan con los de otro RRD del repo | 14 |
| C0-r2 | 3, pasa | 5 | Verde; rojo plantado visto | |
| C1-r1 | 9, no pasa | 6 | Rojo con la compuerta tal cual (prefijo interno fuera del registro de la compuerta); verde con el registro de la corrida | 14 |
| C1-r2 | 8, no pasa | 4 | Rojo: `doc_type` y `audience` fuera del vocabulario de la compuerta; el guion propio de la corrida da verde pero es más laxo | |
| C2-r1 | 9, no pasa | 4 | Rojo tal cual (vocabulario `doc_type`, traza externa, tabla rota); verde con su A-02/A-03, pero la autoprueba de la compuerta pasa a rojo | 23 |
| C2-r2 | 11, no pasa | 5 | Rojo tal cual (prefijo y `doc_type`); verde con su A-02/A-03; autoprueba en rojo | |

Ninguna corrida cumple a la vez M2, M5 y M6. Las 51 diferencias de M7 se reparten entre los DK de abajo.

## 2. Tabla consolidada

Familia **G**: defectos que salen de aplicar la compuerta del cuerpo de origen (docs-guard) a un proyecto ajeno. El
conocimiento tiene que decir **cómo se parametriza** la compuerta con el registro de prefijos y el vocabulario propios
del proyecto; copiar los de origen es el anti-patrón «Copiar los parámetros del laboratorio como norma» de §7.

| Id | Fam. | Casos | Sección | Problema | Tipo |
| --- | --- | --- | --- | --- | --- |
| DK-01 | G | C1, C2 | §5.6; §6 A-02; D-07 | A-02 sin ruta ni formato; la compuerta lee su propio registro y el prefijo interno del proyecto da rojo | fondo |
| DK-02 | G | C1, C2 | §5.2; §6 A-03 | `doc_type` y `audience` remiten a un vocabulario cerrado que el conocimiento no trae ni dice cómo declarar por proyecto | fondo |
| DK-03 | G | C1, C2 (C0) | §5.7; §6 DE-14; A-01 §7 | No fija con qué compuerta ni con qué configuración se corre el par rojo/verde; adaptar la compuerta rompe su autoprueba | fondo |
| DK-04 | G | C1, C2 | D-09; §5.7 | El default depende de la organización del runner sin decir cómo medirla; §5.7 trae el dueño y el repo de origen escritos | fondo |
| DK-05 | G | C0, C1, C2 | D-07; §5.3; §5.6; §3.1 paso 1 | No exige unicidad de IDs en todo el repo ni inventario de espacios de IDs; sin regla de prefijo interno ni prefijo por artefacto | fondo |
| DK-06 | G | C0 | D-07 (columna Clase) | «H si el prefijo es nuevo en un registro compartido» choca con la tabla P/H del proyecto; nada sobre prefijos heredados fuera del registro | fondo |
| DK-07 | | C1 | D-04; §2.3 fila Registro; §2.4 | «Registro de IDs que resuelve» sin definición operativa | fondo |
| DK-08 | | C1, C2 | §6 tabla de artefactos; §3.1 | No dice si un artefacto que depende de una decisión H abierta se produce o no | fondo |
| DK-09 | | C0, C1, C2 | §6 tabla (A-01..A-08, A-11); §5.1; §5.4 | Rutas, nombres y forma de entrega por defecto sin fijar; nada sobre una instancia que ya existe | forma |
| DK-10 | | C0, C1, C2 | D-10; §3.4; §2.4 | D-10 no se contesta por control y por carpeta; no manda leer la tabla del proyecto ni probar la restricción de plataforma | fondo |
| DK-11 | | C1, C2 | D-01; §3.1 paso 2 | D-01 no pide contextos ni dice cómo detectar roles con permisos distintos | fondo |
| DK-12 | | C2 | D-13 | Default «según D-01» circular si D-01 queda pendiente | forma |
| DK-13 | | C1 | §2.1 CL-04, CL-05; §2.3; I-20 | Clase con fuente presente pero generación apagada, o contrato generado en ejecución: sin regla | fondo |
| DK-14 | | C0, C1, C2 | §2.1 CL-01, CL-07, CL-09, CL-10; §2.3; D-15 | Fronteras de clase difusas: A-01 en un corpus, documentación de una demo, análisis previos, «enseña» | fondo |
| DK-15 | | C2 | §3.1 paso 1; D-02; D-05 | Sin regla para una clase repartida entre repos ni para cuando sólo se recibe un repo | fondo |
| DK-16 | | C0, C1, C2 | §3.1 paso 1; A-01 §1 | El inventario no tiene lista de patrones enumerables y deja trampas sin ver en las dos corridas | fondo |
| DK-17 | | C2 | D-06; §2.3 fila Ancla | D-06 no obliga a inventariar las líneas de versión vivas | fondo |
| DK-18 | | C0, C1, C2 | §1; §3.1 paso 1; §6 DE-2; cabecera A-01 | Sin regla para una copia sin `.git`; cada corrida improvisa su ancla | fondo |
| DK-19 | | C0 | D-11 | No distingue delegaciones acotadas de «sin delegación» | fondo |
| DK-20 | | C0 | D-17 | Las opciones no incluyen el modo del carril | forma |
| DK-21 | | C0, C1 | §3.5; §5.1 sección 6; DE-23 | §3.5 cuenta toda suposición como defecto, pero la plantilla las invita | fondo |
| DK-22 | | C2 | §3.5; §6 DE-24 | Búsquedas negativas sin comando reproducible; ruta:línea sin verificación mecánica | fondo |
| DK-23 | | C0, C1, C2 | §3.6; D-14 | Barrido: los patrones son privados, faltan alias canónicos, comando y visibilidad de cada repo | fondo |
| DK-24 | | C0, C2 | §5.1 sección 4; DE-22 | La lista de clase H no tiene composición fija | forma |
| DK-25 | | C1 | §3.3; DE-20 | No dice cuándo es obligatoria la matriz | forma |
| DK-26 | | C1, C2 | §5.1 | No advierte escapar `\|` dentro de una celda | forma |
| DK-27 | | C2 | D-16 | No pide relevar los términos del contrato que no se traducen | fondo |

Cuenta: 27 consolidados; 6 de la familia G; 21 de fondo y 6 de forma.

## 3. Arreglos (texto a cambiar)

### DK-01 · Registro de prefijos del proyecto (G)

Origen: C1 DC1-07; C2 K-08 (prefijo interno), K-17 (ruta). M7: C1 #4–#6; C2 #6–#8.

- **§5.6, debajo del fragmento**, agregar: «A-02 es el registro **del proyecto**: vive en `docs/_gobierno/prefijos.txt`
  (o donde A-06 lo declare), con una línea por prefijo en el formato que lee la compuerta: `PREFIJO ámbito descripción`.
  La compuerta lo recibe como parámetro (entrada del workflow o argumento del guion local). No se agregan prefijos del
  proyecto al registro de la compuerta de origen, ni se usa el registro de origen como registro del proyecto.»
- **§5.7**, agregar: «Si la compuerta no acepta el registro como parámetro, se usa la copia con huella con el registro
  del proyecto en lugar del de origen y la sustitución se anota en A-06 (excepciones a la plantilla).»
- **§6 tabla, A-02, columna Dónde**: «`docs/_gobierno/prefijos.txt`, salvo que A-06 diga otra cosa».

### DK-02 · Vocabulario de `doc_type` y `audience` (G)

Origen: C1 DC1-06; C2 K-08. M6 rojo de esquema en C1-r2, C2-r1 y C2-r2.

- **§5.2**, después del fragmento: «El vocabulario de `doc_type` y de `audience` es del proyecto y se declara en A-03.
  Arranca de esta lista: `ficha`, `anexo`, `rrd`, `proceso`, `tema`, `indice`, `guia`, `referencia`. Un valor nuevo se
  agrega en A-03, nunca en la configuración de la compuerta de origen. `audience` lleva audiencias del escenario (§2.3);
  los roles de un panel van en `roles` del esquema de ayuda, no en `audience`.» (La lista concreta se copia del anexo de
  esquema del cuerpo, con su ruta:línea, al redactar.)
- **§5.2**, tabla nueva «`doc_type` por artefacto»: A-01 `ficha`; A-02, A-03, A-08 `anexo`; A-04 `rrd`; A-06 `proceso`.

### DK-03 · Par rojo/verde y autoprueba de la compuerta (G)

Origen: C1 DC1-16; C2 K-18. M7: C1 #13; C2 #21. En C0 el rojo plantado salió de la misma compuerta y se vio.

- **§6 DE-14**, reemplazar por: «Par rojo/verde de referencia: con la compuerta que fija D-09 (la de origen o su copia
  con huella, nunca un guion escrito por el aplicador), con la configuración del proyecto (A-02, A-03) y sobre A-02…A-07
  montados, una traza a un ID inexistente plantada da rojo en el control de trazas y, sin ella, la compuerta da verde.
  La salida textual de las dos corridas va en A-01 §7.»
- **§5.7**, agregar: «La configuración del proyecto (registro, vocabulario, excepciones) se separa de los fixtures de
  la autoprueba de la compuerta: la autoprueba corre con su configuración de origen y la compuerta del proyecto con la
  de A-02 y A-03. Si cambiar la configuración pone en rojo la autoprueba, la configuración se pasó mal.»

### DK-04 · D-09 y organización del runner (G)

Origen: C1 DC1-08; C2 K-10. M7: C1 #8; C2 #10.

- **D-09, Criterio**: «La organización se mide: remoto `origin` del repo y líneas `uses:` de sus workflows. Si no se
  puede medir, el valor queda "pendiente: organización".»
- **D-09, Default**: «Copia con huella del guion local de la compuerta de origen, en el runner del proyecto. El
  reutilizable sólo si la medición prueba que el repo está en la organización del runner. Nunca una compuerta escrita
  de cero.» D-17 sigue esa elección.
- **§5.7**, en el YAML: `uses: {dueño}/Lab-Documentos/...` pasa a `uses: {organizacion-de-la-compuerta}/{repo-de-la-compuerta}/.github/workflows/docs-guard.yml@{sha}`.

### DK-05 · Unicidad de IDs, colisiones y prefijo por artefacto (G)

Origen: C0 K-03, K-11 (segundo espacio de IDs); C1 DC1-07 (regla del prefijo interno); C2 K-11. M6 C0-r1 rojo por
`id-duplicado`.

- **D-07, Criterio**: «Antes de fijar un ID: correr el control de trazas de la compuerta sobre la raíz entera del repo
  (y de los hermanos leídos), listar cada espacio de IDs en uso con su origen (registro, expedientes, marco de
  especificación) y comprobar que ningún ID nuevo choca. El prefijo interno nuevo no está en uso ni en el registro de
  la compuerta de origen.»
- **§5.3**: «Las filas del RRD se numeran en un rango libre, comprobado con el comando anterior.»
- **§5.6**: «Prefijo por artefacto: A-04 `RD`, A-06 el de procesos del proyecto, A-02/A-03/A-08 el de anexos del
  proyecto.» (Prefijos del registro del proyecto, no los del cuerpo de origen.)

### DK-06 · Clase de un prefijo nuevo y prefijos heredados (G)

Origen: C0 K-02. M7 C0 D-2.

- **D-07, columna Clase**: «La que fije la tabla P/H escrita del proyecto. Sin tabla: P para un prefijo en el registro
  propio; H para un alta en un registro ajeno (por ejemplo, el de la compuerta de origen).»
- **D-07, Criterio**, agregar: «Los prefijos heredados fuera del registro no se resuelven en la adopción: se cuentan en
  A-08 y van a un saneamiento aparte, P.»

### DK-07 · Registro de IDs que resuelve

Origen: C1 DC1-02. M2 D-04 y D-07 discrepan en las dos corridas de C1.

- **D-04, Criterio**: «Un registro resuelve si cada ID se declara una sola vez, con versión, en un encabezado del repo
  (por ejemplo `# ID — título` más `**Versión:**`), aunque el marco viva afuera. Se comprueba con un comando que lista
  IDs declarados y duplicados. Los IDs externos de la especificación resuelven contra el propio repo.»

### DK-08 · Artefacto que depende de una decisión H abierta

Origen: C1 DC1-09; C2 K-09. M7: C1 #3, #11; C2 #18–#20, #23. M3 de C1-r2 lo señala como diagnóstico.

- **§6, antes de la tabla de artefactos**: «Un artefacto que depende de una decisión H abierta se produce con el
  default, en borrador, en la salida del aplicador (no en el repo), rotulado "propuesta sujeta a D-nn". La misma regla
  vale para la ubicación de CL-03 y CL-12 en D-05.»

### DK-09 · Rutas y forma de entrega por defecto

Origen: C0 K-04, K-12; C1 DC1-07 (ruta de A-02); C2 K-17. M7: C0 D-4, D-5, D-13; C2 #4–#6.

- **§6 tabla, columna Dónde**: A-01 `docs/_diseno/ficha-diseno-documental.md`; A-02 y A-03 `docs/_gobierno/`; A-06
  `docs/_gobierno/como-intervenir.md`; A-08 informe en la descripción del pull request más `excepciones.txt` en la ruta
  que use la compuerta.
- **§6, debajo de la tabla**: «Si el repo ya tiene la instancia de un artefacto, se actualiza en su ruta y no se
  produce una segunda. A-11 se entrega como la entrada y su punto de inserción, no como el archivo entero.»

### DK-10 · D-10 por control y por carpeta

Origen: C0 K-05; C1 DC1-10; C2 K-06. M7: C0 D-6, D-7; C1 #9; C2 #11.

- **D-10, Opciones**: «Tabla control × carpeta: bloquea o avisa, con la línea de base medida.»
- **D-10, Criterio**, agregar: «Si el proyecto ya tiene una tabla de bloqueo, se lee primero y manda. En un proyecto
  existente la compuerta recibe sólo las carpetas nuevas; lo heredado avisa. Si la carpeta por defecto no existe,
  queda "pendiente" con motivo, sin cambiarla. La restricción de plataforma es del plan u organización: se afirma con
  evidencia (configuración o respuesta de la API) y vale para los repos hermanos de la misma organización.»
- **§2.4, fila I-01/I-15/I-16, Premisa**: agregar «(propiedad del plan u organización, no del repo)».

### DK-11 · Contextos y roles en D-01

Origen: C1 DC1-01; C2 K-01. M2 D-01 discrepa en las cuatro corridas.

- **D-01**: la pregunta pasa a «¿Escenario y contextos?». Contextos con vocabulario cerrado: sitio, marco de
  especificación, topología, organización del runner; cada uno con valor y evidencia o «pendiente».
- **D-01, Criterio**, agregar: «Roles con permisos distintos se detectan con un inventario de autorización
  (políticas, claims, menús restringidos), no con una búsqueda léxica de "rol".»
- **§5.1, tabla de decisiones**: una subfila por contexto bajo D-01.

### DK-12 · Default circular de D-13

Origen: C2 K-15. M7 C2 #12.

- **D-13, Default**: «Si D-01 da roles con permisos distintos, por rol; si D-01 queda pendiente, "pendiente" con el
  mismo motivo.»

### DK-13 · Clase con fuente presente y generación apagada o en ejecución

Origen: C1 DC1-03, DC1-04. M7 C1 #2.

- **§2.1, debajo del catálogo**: «Si la fuente de una clase D existe y la generación está apagada, la clase queda
  activa con su control "pendiente" y la línea de base anotada; se da de baja sólo si la fuente no existe.»
- **CL-05, Dónde vive**: «Build; si el contrato se genera en ejecución, sigue en build con un paso de la CI que
  levanta el servicio y lo extrae; mientras falte, el diff del contrato queda pendiente.»

### DK-14 · Fronteras de clase

Origen: C0 K-01; C1 DC1-15; C2 K-04. M7: C0 D-1; C2 #2, #14. M5 en C1 (las dos corridas suponen CL-09).

- **§2.3, fila Corpus de guías**: sumar CL-01 cuando hay A-01, o decir que A-01 en un corpus es CL-09.
- **CL-07**: «La documentación de una demo que ilustra una guía es CL-10, no CL-07.»
- **CL-09**: «Incluye los análisis de trabajo previos al intake.»
- **D-15, Criterio**: «"Enseña" se mide por el propósito declarado del proyecto (README, descripción del repo). Una
  guía de estudio interna del equipo no activa CL-10. Default: No.»

### DK-15 · Clase repartida entre repos

Origen: C2 K-03. M7 C2 #2, #3, #16; las dos corridas lo citan como «no resuelve».

- **D-05, Opciones**, agregar: «Una clase puede tener varias ubicaciones; se listan todas en A-01 §3.»
- **§3.1 paso 1**, agregar: «Si se recibe un solo repo de varios, el índice del otro sirve como evidencia secundaria
  declarada; la ubicación se completa igual y se rotula.»

### DK-16 · Inventario con patrones enumerables

Origen: C0 K-11 (punteros a documentos obsoletos); C1 DC1-05; C2 K-05. M2: trampas no vistas en las dos corridas de
cada caso.

- **§3.1 paso 1**, agregar una lista cerrada, cada ítem con su comando y un renglón en A-01 §1: IDs declarados más de
  una vez (incluidas copias congeladas); versión declarada dos veces (`version:` frente a `**Versión:**`); estados
  «planificado» o equivalentes en la documentación técnica; trazas de la interfaz a la unidad que corresponde;
  punteros que trazan a un documento obsoleto o ausente según el CHANGELOG; advertencias del índice del proyecto
  (controles declarados y no ejercidos, especificación atrasada), que pasan a A-01 como reservas.

### DK-17 · Líneas de versión en D-06

Origen: C2 K-02. M2 D-06 y la trampa de líneas de versión discrepan en las dos corridas.

- **D-06, Criterio**: «Listar cada línea de versión viva con su etiqueta o "sin etiqueta". El conjunto de anclas cubre
  todas las líneas; una línea sin etiqueta se ancla por SHA.»

### DK-18 · Copia sin `.git`

Origen: C0 K-09; C1 DC1-11; C2 K-13. M7: C0 D-10; C1 #1; C2 #22.

- **§3.1 paso 1 y DE-2**: «Sin historia de Git, la cabecera de A-01 dice "SHA: pendiente" más la huella del árbol:
  `find . -type f -not -path './.git/*' -print0 | sort -z | xargs -0 sha256sum | sha256sum`. Las citas ruta:línea
  valen contra esa huella.»

### DK-19 · Delegaciones acotadas en D-11

Origen: C0 K-07. M2 D-11 igual en las dos corridas de C0.

- **D-11, Opciones y Default**: «El valor es el mapa de delegaciones existentes, cada una con su alcance. Lo que cae
  fuera de todas lo fusiona una persona; eso no es "sin delegación".»

### DK-20 · Modo del carril programado

Origen: C0 K-10. M7 C0 D-9.

- **D-17, Opciones**: «Frecuencia; días de frescura; qué vigila; modo (sólo avisa, con issue).» **Default**: «Semanal;
  frescura de 365 días; sólo avisa, con issue.»

### DK-21 · Suposiciones

Origen: C0 K-08; C1 DC1-15 (como síntoma). M5 entre 4 y 6 en las seis corridas.

- **§3.5**, segundo párrafo: «Una lectura con ancla (ruta:línea que la sostiene) va en su fila con la cita; no es
  suposición. Lo que no tiene ancla queda "pendiente". No hay tercera vía.»
- **§5.1, sección 6 de A-01**: «Lo que el conocimiento no resolvió (cita textual)». Se quita «y suposiciones» y la
  columna «Por qué no se marcó pendiente».
- **DE-23**: «0 suposiciones.»

### DK-22 · Evidencia reproducible

Origen: C2 K-12, K-16. M4 de C2-r2 = 1 (rango fuera del archivo).

- **§3.5**, agregar: «Toda búsqueda negativa ("no hay X") se informa con el comando exacto y su salida.»
- **§6, nuevo DE**: «`[obligatorio]` `[enumerable]` Antes de cerrar A-01, cada ruta:línea citada pasa un chequeo
  mecánico de existencia del archivo y del rango; la salida va en A-01 §7.»

### DK-23 · Barrido de lo privado

Origen: C0 K-06; C1 DC1-13; C2 K-07. M7: C0 D-8; C1 #10; C2 #13.

- **§3.6**, agregar: «Los patrones del barrido son valores privados: el barrido se describe por su lista
  (`{lista-privada}`), nunca por sus valores, y la propia A-01 lo pasa. Alias canónicos: `{servicio-privado}`,
  `{host-de-pruebas}`, `{etiqueta-runner}`, `{usuario}`, `{dir-de-trabajo}`, `{organizacion}`.»
- **D-14, Criterio**, agregar: «Visibilidad de cada repo (público o privado) con evidencia (configuración o comando);
  sin ella, "pendiente". El inventario de destinos privados sale de un comando dado.»

### DK-24 · Composición de la lista H

Origen: C0 K-13; C2 M7 #23. M7: C0 D-12.

- **§5.1, sección 4 de A-01**: «Las filas H de §3.2 (D-03, D-09, D-11, D-12 y las que se vuelvan H por su columna
  Clase) más las acciones H de la tabla P/H del proyecto que la adopción toca. Nada más.»

### DK-25 · Cuándo es obligatoria la matriz

Origen: C1 DC1-12. M7 C1 #7.

- **§3.3, primer párrafo**: «Es obligatoria cuando la fila tiene más de una opción admisible y el default no aplica o
  se descarta; en cualquier otro caso basta el default con su razón.» DE-20 pasa a citar esa condición.

### DK-26 · Barra vertical en celdas

Origen: C1 DC1-14; C2 K-19. M1 de C1-r2 y MD056 en C2-r1.

- **§5.1**, debajo del esqueleto: «Dentro de una celda, una barra vertical se escribe `\|`.»

### DK-27 · Términos que no se traducen

Origen: C2 K-14. M7 C2 #15.

- **D-16, Criterio**, agregar: «Lista de términos del contrato (API, esquema) que no se traducen, con evidencia.»

## 4. Errores del oráculo (no son defectos del conocimiento)

C0 informa cuatro (el oráculo supone carpetas que el montaje no trae; D-11 contradictorio; D-14 sin regla para valores
privados en comandos; D-17 sin decir si adoptar el modo existente cuenta como igual). C1 informa dos filas discutibles
que no cambian el veredicto. C2 no confirma ninguno y deja tres filas discutibles. Van a la revisión del oráculo, no al
conocimiento.

## 5. Mensajes durante la consolidación

No llegaron mensajes de otras sesiones.
