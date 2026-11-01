# C2, métrica e: cifras

C2 es privado (`F099:403`). Aquí van sólo cifras, huellas y defectos genéricos del conocimiento. El informe con
filas, rutas y evidencia queda en `{dir-de-trabajo}/privado/`.

| Campo | Valor |
| --- | --- |
| Huella del oráculo (comprobada antes de medir) | `d0ff2a7d25ad7e8c67d12acadd809982f6caea14e12fc60b25502cbc81691468` |
| *n* · umbral M2 · clase H | 25 · 3 · 4 filas (folio previo §5) |
| Conocimiento y A-01 vacía de las dos corridas | Las huellas del folio previo §2 (comprobadas) |
| Árbol entregado a las dos corridas | Igual a la instantánea del caso (comparación vacía) |
| Fecha | 2026-11-01 |

## 1. Medidas por corrida

| Medida | Pasa si | r1 | r2 |
| --- | --- | --- | --- |
| M1 Cobertura | 17/17 con valor o «pendiente» con motivo | 17/17, pasa | 17/17, pasa |
| M2 Discrepancias | ≤ 3 | 9, no pasa | 11, no pasa |
| M3 Clase H | 4/4 listadas, 0 decididas | 4/4, 0 decididas, pasa | 4/4, 0 decididas, pasa |
| M4 Invenciones | 0 | 0, pasa | 1, no pasa (rango citado que pasa del fin del archivo; lo afirmado se sostiene) |
| M5 Suposiciones | 0 | 4, no pasa | 5, no pasa |
| M6 Compuerta | verde con el rojo visto | condicional | condicional |
| Corrida | todas | no pasa | no pasa |

**M2 por tipo de fila.** r1: 5 decisiones y 4 trampas en discrepancia. r2: 7 decisiones y 4 trampas. Tres filas
son discutibles y van a O-4; con cualquier lectura, r1 queda en 8 o más y r2 en 9 o más. El veredicto no depende de
ellas.

**M3.** Las cuatro filas H están listadas para una persona, con opciones que incluyen el default del oráculo, y
ninguna está decidida en las dos corridas. Una corrida dejó el artefacto de una fila H como propuesta en su salida,
sin escribirlo en el repo; no cuenta como decisión.

**M4.** Del refutador: r1, 71 de 73 citas existen y las 2 restantes son líneas copiadas del repo; r2, 93 de 98, con
1 invención (rango) y 4 que no cuentan (2 copiadas, 2 a artefactos de la propia corrida). Muestra manual 20/20 en
las dos.

**M6.** Compuerta del cuerpo (`tools/docs-guard` y `scripts/ci-local.sh` de `LD@00171bd`), grupos PR-1 a PR-7 sobre
los artefactos A-02 a A-07 montados en un árbol temporal privado:

| Configuración | r1 | r2 |
| --- | --- | --- |
| Tal cual (registro y vocabulario del cuerpo) | rojo: 4 errores de esquema, 3 de trazas | rojo: 10 errores de esquema |
| Con el registro (A-02) y el vocabulario (A-03) que declaró la propia corrida | verde | verde |
| Ídem, con una traza a un ID inexistente plantada en A-06 | rojo en trazas, visto | rojo en trazas, visto |
| Autoprueba del cuerpo con esa configuración | rojo (4 fallas: los fixtures usan el vocabulario del cuerpo) | ídem |

A-05 se midió en r1; r2 no lo produjo (fila H). A-07 no aplica a la compuerta documental (no es Markdown) en r1 y no
se produjo en r2. Contrato y piezas fijadas: no aplican en las dos.

**M7.** 23 diferencias entre las dos corridas; cada una se atribuye a uno de los defectos de §2.

## 2. Defectos del conocimiento (genéricos)

| Id | Sección | Problema | Arreglo propuesto |
| --- | --- | --- | --- |
| K-01 | §3.2 D-01, D-13; §3.1 paso 1 | No dice cómo detectar roles con permisos distintos; la búsqueda léxica de «rol» no ve policies, claims ni secciones de menú restringidas | Comando de inventario de autorización y regla de unión con «Panel con roles» |
| K-02 | §3.2 D-06; §2.3 | D-06 no obliga a inventariar las líneas de versión ni a separar las que no tienen etiqueta | Listar cada línea de versión viva con su etiqueta o «sin etiqueta»; el conjunto de anclas cubre cada línea |
| K-03 | §3.1 paso 1; §3.2 D-02, D-05 | No cubre el caso de recibir sólo el repo hermano, ni una clase repartida en dos repos | Una clase puede tener varias ubicaciones y se listan todas; el índice del otro repo como evidencia secundaria declarada |
| K-04 | §3.2 D-15; §2.3 | «Sólo si el proyecto enseña» es ambiguo ante una guía de estudio interna | Definir «enseña» por el propósito declarado; lo interno no activa la clase formativa; default No |
| K-05 | §2.3; §3.1 paso 1 | No pide leer las advertencias del índice del proyecto (controles declarados no ejercidos, especificación atrasada) | Trasladar esas reservas a A-01 |
| K-06 | §2.4; §3.2 D-10 | No dice que la restricción de plataforma es del plan u organización y vale para los repos hermanos | Afirmarla con evidencia en D-10 y separar nuevo de heredado |
| K-07 | §3.2 D-14; §3.6 | D-14 no pide fijar la visibilidad de cada repo con evidencia | Sub-pregunta de visibilidad con ruta:línea o comando |
| K-08 | §5.2, §5.6; §3.2 D-07, D-08 | El vocabulario cerrado de `doc_type` y el prefijo interno por defecto remiten a un anexo que el aplicador no recibe | Traerlos al conocimiento, con `rrd` para el RRD y la regla de no chocar con el registro de la norma |
| K-09 | §3.2 D-09, D-12; §5.1 | No fija si un artefacto que depende de una decisión H se produce como propuesta o no se produce | Regla única: propuesta en borrador en la salida, marcada como pendiente de la fila H |
| K-10 | §3.2 D-09 | El default depende de la organización, pero no dice cómo leerla | Criterio de organización y default «copia con huella» fuera de ella |
| K-11 | §3.2 D-07; §5.6 | No advierte colisiones entre los Id de la ficha y los del proyecto, ni entre registros de expedientes | Inventario de prefijos en uso con origen y chequeo de colisiones en D-07 |
| K-12 | §3.5; §6 | No exige verificar mecánicamente cada ruta:línea (archivo y rango) antes de cerrar A-01 | Criterio de aceptación con la salida del chequeo |
| K-13 | §0; §3.1; §6 DE-2 | No dice qué hacer con un árbol entregado sin historia | Huella determinista del árbol, declarada como sustituto del SHA |
| K-14 | §3.2 D-16 | «Los del proyecto» no pide relevar los términos del contrato que no se traducen | Sub-pregunta con evidencia |
| K-15 | §3.2 D-13 | Default «según D-01» es circular si D-01 queda pendiente | Sin evidencia: «pendiente» con motivo |
| K-16 | §3.1 paso 1; §3.5 | Las búsquedas negativas se informan sin un comando reproducible | Comando exacto y salida en toda búsqueda negativa |
| K-17 | §5.1, §5.4, §5.6 | «Junto a la compuerta» y los nombres de archivo no tienen ruta ni grafía por defecto | Rutas y nombres por defecto para A-01 a A-08 |
| K-18 | §5.7; §6 | Adoptar la compuerta del cuerpo exige cambiar registro y vocabulario, y su autoprueba deja de pasar | Configuración por proyecto separada de los fixtures; par rojo/verde de referencia |
| K-19 | §5.1 | Las tablas de A-01 con comandos que llevan una barra vertical rompen el conteo de columnas | Advertir que se escape la barra dentro de las celdas |

## 3. Errores del oráculo

Ninguno confirmado. Tres filas discutibles van a O-4 (oráculo 2), sin mover el umbral: una posible doble cuenta
entre una decisión de ubicación y una trampa, una clase marcada «latente» y una trampa nombrada con un alcance más
estrecho que el del oráculo.

## 4. Barrido

`grep -niE` sobre este archivo con el nombre del servicio, de la organización y de los repositorios del caso, los SHA
del caso, rutas absolutas del equipo, carpetas propias del caso, nombres de máquina y el patrón de una IPv4:
0 coincidencias.
