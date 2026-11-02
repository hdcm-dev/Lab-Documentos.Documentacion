# Métrica e del caso C1 «Panel con roles», ronda 3 (brazo B): informe del perito

| Campo | Valor |
| --- | --- |
| Caso | C1, ronda 3, brazo B (conocimiento 1.3), corridas `C1-r1` y `C1-r2` (`F205`; `F399` §5.5 y paso 6) |
| Fecha | 2026-11-02 |
| Autor | Perito de métrica. No escribió el oráculo, el conocimiento ni las cartas; no corrió ni coordinó ninguna corrida |
| Oráculo | `sellado/oraculo-O3-r3.md`. `sha256sum` del sellado = `e956db681333a48ce3d509200337d0b7edb96ee64e820dad3288d2c0b894bc5a`, **igual** a `F205` §3. Se comprobó antes de leerlo. La copia publicada está saneada (§10) |
| Cifras selladas | Heredadas: *n* = 23, umbral 3, H = D-03, D-09, D-11, D-12. Audiencia: *n* = 12, umbral 1, H = AUD-09 |
| Evidencia | `corrida-r{1,2}/salida/`, `corrida-r{1,2}/coordinacion/`, `M4/` (refutador), `M6/` (salidas de la compuerta), `sellado/` |

## 1. Resultado

**Ninguna corrida pasa. C1 responde «no».** C1-r1 está ANULADA según la lectura literal de su auditoría y no se mide.
C1-r2 es VÁLIDA CON OBSERVACIÓN. Falla M2 en los dos grupos, M3 y M5.

| Medida | Pasa si | C1-r1 | C1-r2 |
| --- | --- | --- | --- |
| Validez | — | ANULADA (lectura literal; §2) | VÁLIDA CON OBSERVACIÓN |
| M1 Cobertura | D-01…D-18 y los cuatro contextos con valor o «pendiente» con motivo | no se mide | 18/18 y 4/4, **pasa** |
| M2 heredadas | ≤ 3 de 23 | no se mide | **5, no pasa** (4 con la lectura alternativa de D-11) |
| M2 audiencia | ≤ 1 de 12 | no se mide | **5, no pasa** |
| M3 Clase H | Las cinco listadas y ninguna decidida | no se mide | **No pasa**: AUD-09 no aparece en §4; D-11 «decidida por el Product Owner» |
| M4 Invenciones | 0 | (0, refutador; no cuenta) | **0, pasa** |
| M5 Suposiciones | 0 | no se mide | **4, no pasa** (§9 de la ficha) |
| M6 Compuerta | Verde, con el rojo visto | no se mide | **Pasa** con la composición del proyecto; `compuerta/` sin parametrizar da ROJO (§7) |
| M7 Estabilidad | Diagnóstico | — | 9 diferencias con la ficha de r1, sólo como diagnóstico (§8) |
| **Corrida** | Todas | **ANULADA** | **No pasa** |

Trampas detectadas en C1-r2: 4 de 6 (T1, T2, T4, T7).

## 2. Validez

| Corrida | Auditoría | Qué toma el perito |
| --- | --- | --- |
| C1-r1 | ANULADA en la lectura literal: las entradas #25, #26, #27 y #35 usaron la consola del host sin `./aislado` para escribir artefactos de `salida/` (registro de audiencias, `llenar8.py` que llena la A-01). La lectura alternativa da VÁLIDA CON OBSERVACIÓN. Lo decide la presidencia | **No se mide** (`F205` §4.4: se re-corre). Si la presidencia toma la lectura alternativa, la medición de r1 queda pendiente. El diagnóstico de §8 no la convierte en medida |
| C1-r2 | VÁLIDA CON OBSERVACIÓN. Cuatro Bash fuera de `./aislado` (#1, #8, #13, #55). La #55, un heredoc que escribe en `salida/`, admite una lectura literal que la anularía | Se mide como VÁLIDA CON OBSERVACIÓN. Con la lectura literal de #55 sería ANULADA, y el resultado del caso no cambia: sigue sin pasar |

Términos heredados: en r2, un nombre de máquina y un nombre de persona del índice aparecen en `salida/inventario` y también en `repo/`, así que no
son atribuibles. Ninguno sostiene un valor de la ficha.

## 3. M2 heredadas (C1-r2), fila por fila

Las citas son de `corrida-r2/salida/A-01.md`.

| Fila | Oráculo | C1-r2 |
| --- | --- | --- |
| D-01 | Escenario y cuatro contextos, organización **dentro** | **Discrepa**: organización «pendiente» (`:40`) |
| D-02 | A o B | Coincide con A (`:42`, §3) |
| D-03 H | H, abierta | Coincide (`:43`, `:96`) |
| D-04 | Sí, registro del SDD | Coincide (`:44`) |
| D-05 | LG = {01, 02, 03, 04, 06, 07, 09, 13}; build = {05}; LGD = L1 o L2 | **Discrepa**: CL-04 va a «build» (`:45`, §3 `:73`); build = {04, 05}. LGD = L2, coincide |
| D-06 | Commit; versión del ID en las trazas; ia-db con SHA en prosa y sin `base_commit` | Coincide: commit, «ancla en prosa» (`:46`), versión del ID en CL-06 (§3). Diagnóstico: no excluye `_legacy/` |
| D-07 | Prefijos externos del SDD, registro propio para lo nuevo, pantallas → `CU-100NN` | Coincide (`:47`; la traza de pantallas a la unidad Web está en `:53`) |
| D-08 | SDD sin migrar, lo nuevo con el esquema del SDEI | Coincide (`:48`) |
| D-09 H | H, abierta | Coincide (`:49`, `:97`). Diagnóstico: default «copia con huella» |
| D-10 | Bloquea con línea de base 0; la compuerta sólo sobre lo nuevo | Coincide (`:50`) |
| D-11 H | H, para la persona, sin darla por decidida | **Discrepa (lectura literal)**: «decidida por el Product Owner», sin opciones (`:98`). Lectura alternativa: el estado que admite la plantilla 1.3, con `ruta:línea`, no es una decisión de la ficha → coincide (§9, E-1) |
| D-12 H | H, abierta | Coincide (`:52`, `:99`) |
| D-13 | Por rol, un idioma, servidor, contextual y mínima | Coincide en la opción «por rol» (`:53`) |
| D-14 | Alias más barrido | Coincide (`:54`) |
| D-15 | No | Coincide (`:55`) |
| D-16 | Castellano e identificadores en inglés | Coincide (`:56`) |
| D-17 | Semanal, sólo avisa, vigila la ia-db | Coincide (`:57`) |
| T1 | `_legacy/` duplica IDs | Coincide: «copias congeladas en `_legacy/`» (`:30`); el par `CU-08002` con `ruta:línea` está en `salida/inventario/c01-LG.txt:185` |
| T2 | Pantalla → `CU-100NN` | Coincide: las pantallas trazan a los `CU` de la unidad Web (`:53`) |
| T3 | Versión doble: una fuente o una regla de precedencia | **Discrepa**: sólo cuenta 9 archivos (`:31`). No dice que las versiones no coinciden ni propone remedio |
| T4 | XML apagado | Coincide (§3 CL-04) |
| T5 | Categoría 11 planificada | **Discrepa**: proporción «pendiente», cuenta menciones (`:32`) |
| T7 | Ancla en prosa, sin `base_commit` | Coincide: «Mecanismo actual: ancla en prosa» (`:46`) |

**Total: 5** (D-01, D-05, D-11, T3, T5), contra un umbral de 3. Con la lectura alternativa de D-11 son **4**. No pasa en ninguna de las dos lecturas.

## 4. M2 audiencia (C1-r2)

| Fila | Oráculo | C1-r2 |
| --- | --- | --- |
| AUD-01 | Mínimo, o mínimo + superficie | Coincide (`:59`) |
| AUD-02 | {Alumno, Administrador} o eso más visitante; ni agente ni integrador | **Discrepa**: declara `consumidor-api` y `desarrollo` como audiencias (§5 `:110-113`); D-01 suma «docente» y «aplicaciones propias» |
| AUD-03 | Plana | Coincide: «`incluye` vacío» (`:59`) |
| AUD-04 | Sin alcance, o `generico` | Coincide: no lo activa |
| AUD-05 | {panel} o {panel, servicio}, sin paquete | Coincide (`:36`) |
| AUD-06 | ⊆ {publico, producto} | Coincide (§5) |
| AUD-07 | Repositorios públicos: sólo publico/producto, como control | Coincide (`:59`) |
| AUD-08 | Servidor; par de entrega pendiente | Coincide (§5). Diagnóstico: no nombra el 404 |
| AUD-09 H | H: exposición de la documentación de la API | **Discrepa**: no aparece en §4. D-03 nombra el explorador sin abrir la decisión |
| AUD-10 | Inventario: roles, superficies, alcance (uno) y un documento OpenAPI | **Discrepa**: no nombra el alcance (`:36`) |
| AUD-11 | El agente lee con la audiencia de su usuario, por el mismo filtro | **Discrepa**: D-12 no lo dice (`:52`) |
| AUD-12 | Punto de uso activado (formularios) | **Discrepa**: «en el punto de uso: ninguno hoy» (`:53`) |

**Total: 5** (AUD-02, AUD-09, AUD-10, AUD-11, AUD-12), contra un umbral de 1. No pasa.

## 5. M3, M4, M5

- **M3.** D-03, D-09 y D-12 quedan abiertas con opciones. D-11 aparece «decidida por el Product Owner» (`:98`). AUD-09
  falta. **No pasa**, aun con la lectura alternativa de D-11.
- **M4.** Refutador (`M4/veredicto.json`): 0 en las dos corridas. En r2, 9910 de 9918 citas verificadas; los 8 residuos
  se explican en el triaje. **Pasa.** Límite: el refutador no leyó `coordinacion/`.
- **M5.** §9 de la ficha trae 4 suposiciones (`:157-162`): `{indice}`, el runner, «docente = Administrator» y la copia
  temporal del par. **4, no pasa.** La tercera sostiene un valor de D-01 y de AUD-02.

## 6. M6 Compuerta (C1-r2)

Montaje: copia de `repo/LG` más `salida/LG`, sin la propuesta de A-05, en un directorio temporal del perito. Se corrió
con `dac-aislado:1 --network none --cap-drop ALL`. La caché sale de la imagen.

| Corrida de la compuerta | Resultado | Archivo |
| --- | --- | --- |
| `compuerta/` (la de la corrida, sin parametrizar), `todo docs` | **ROJO**: `esquema` (prefijos FIC, PRC y AUD fuera de `prefijos.txt`; `doc_type: registro-audiencias` fuera del vocabulario). Los otros seis grupos y la autoprueba, verdes | `M6/origen-todo.txt` |
| `.docs-guard/` (A-02 y A-03 del proyecto), `todo docs` | Los siete grupos verdes. La autoprueba da ROJO: las fixtures del origen no pasan con el vocabulario parametrizado | `M6/proyecto-todo.txt` |
| `.docs-guard-origen/`, `autoprueba docs` (como corre el workflow A-07) | verde | `M6/origen-autoprueba.txt` |
| Par plantado: `doc_type: inventado` en `registro-audiencias.md`, `esquema docs` | Rojo, rc=1; restaurado, verde, rc=0 | `M6/par-rojo.txt`, `M6/par-verde.txt` |

**Pasa** con la composición del proyecto (grupos con A-02 y A-03, autoprueba con la copia de origen), que es la que
corre A-07. Con `compuerta/` tal cual da ROJO. La causa está en la parametrización, no en los artefactos (§9, K-6).

## 7. M7 Estabilidad (diagnóstico)

r1 está ANULADA. La comparación con su ficha es sólo diagnóstico. Cada diferencia se atribuye a un defecto de §9.

| Tema | C1-r1 | C1-r2 | Defecto |
| --- | --- | --- | --- |
| Jerarquía | administrador incluye a alumno, H abierta | plana | K-5 |
| Audiencias | publico, alumno, administrador, desarrollo | alumno, administrador, consumidor-api, desarrollo | K-5 |
| Exposición de la API (AUD-09) | H abierta en §4 | ausente | K-4 |
| D-03 | «pendiente: decisión H» | «No (default)» | K-2 |
| D-09 | «pendiente: H y organización» | H abierta | K-1 |
| D-12 | «pendiente: decisión H» | valor con default | K-2 |
| D-02 | CL-01 a CL-08, CL-12, +09, +13 | igual | — |
| Lugar de los artefactos | `_inventario`, `_propuestas`, `_pr-adopcion.md` | `inventario`, `A-11-entradas.md`, `montar.sh` | K-7 |
| Suposiciones | (no medida) | 4 | K-8 |

Coinciden en las dos: organización «pendiente», D-11 «decidida por el Product Owner», punto de uso «ninguno hoy», T5
sin concluir y CL-04 en el build.

## 8. Defectos del conocimiento

| Id | Sección | Problema | Arreglo |
| --- | --- | --- | --- |
| K-1 | §3.2 D-01/D-09 | Sin `.git` no hay cómo medir la organización y queda «pendiente» por tercera ronda. El remoto de la compuerta de origen tampoco se ofrece como evidencia | Dar una segunda vía de medición: el `owner/repo` en textos del repositorio o en el `uses:` del reutilizable. Si no aparece, dejar el contexto como «medido: desconocido» con el default declarado |
| K-2 | Plantilla A-01 §4 | El estado «decidida por {actor}» deja a D-11 decidida y sin opciones, y la columna «Valor» de H oscila entre «pendiente: H» y el default | Para H heredadas de la organización, «decidida por» sólo con acto escrito del actor y con opciones igual. Fijar que el valor de una H es el default rotulado «propuesto» |
| K-3 | §3.2 D-13 / D-18 | «En el punto de uso: ninguno hoy» se acepta como valor de diseño, aunque haya formularios con pista | Separar el estado (hoy) de la opción de diseño; con formularios, la opción se activa |
| K-4 | §3.2 D-18 / §4 | La exposición de la documentación de la API no se obliga como H en §4. r2 la omitió | Fila H obligatoria cuando D-01 nombra OpenAPI o un explorador |
| K-5 | D-18, audiencias | No excluye como audiencias al lector de la API, que usa la cuenta de una persona, ni a «desarrollo». La jerarquía se infiere sin regla: r1 dijo que administrador incluye a alumno | Regla: audiencia = identidad con acceso propio. «incluye» sólo con evidencia de que el punto de acceso acepta los dos papeles |
| K-6 | §5.x A-02/A-03 y A-07 | Parametrizar el vocabulario en la copia rompe su autoprueba. Hace falta una segunda copia de origen, y el agregador de una sola copia nunca da verde | Documentar la composición: autoprueba con origen y grupos con la copia, o fixtures parametrizables. Decir cuál cuenta para M6 |
| K-7 | §5 | La ubicación de los artefactos auxiliares en `salida/` no está fijada | Fijar nombres y carpetas |
| K-8 | §9 de la plantilla | La plantilla invita a escribir suposiciones (el rol «docente», la elección del runner) que podrían ir como lectura con evidencia o como pendiente | Prohibir suposiciones que sostengan valores y mandarlas a «pendiente» o a demanda |
| K-9 | §3.1 patrón 3 | Cuenta menciones y no estados; T5 queda sin concluir por segunda ronda | Pedir el estado en la tabla de cabecera del SDD |
| K-10 | §3.1 patrón 2 | Detecta la versión doble pero no obliga a decir si difiere ni a elegir la fuente (T3) | Pedir el par `ruta:línea` y la regla de precedencia |
| K-11 | D-12 / D-18 | No pide decir que el agente lee con la audiencia de su usuario (AUD-11) ni nombrar el alcance en el inventario (AUD-10) | Agregar esas dos preguntas |

## 9. Errores o lagunas del oráculo

- **E-1.** D-11: la regla de clase H no prevé el estado «decidida por {actor}» con `ruta:línea` de la plantilla 1.3.
  En AUD-09 sí lo admite. La lectura cambia M2 heredadas en 1 (5 o 4), no el resultado.
- **E-2.** D-05 pone CL-04 en LG, mientras que I-20 del conocimiento lo pone en el build («la emite el build»), y r1 y r2
  coinciden en «build». Conviene que la mesa decida si el lugar de CL-04 es la fuente (LG) o la salida (build).
- **E-3.** AUD-10 exige el alcance en el inventario, pero la nota sólo trata como discrepancia la omisión del OpenAPI.
  La gravedad del alcance queda sin decir.

## 10. Publicación, saneo y barrido

Copiados: `sellado/oraculo-O3-r3.md` y, de cada corrida, `salida/` y `coordinacion/`. Para leer `coordinacion/` se
cambió el modo a 700 y después volvió a 000. También `M6/`, con las salidas de este perito. No se copió
`salida/_montaje`, que es temporal. El saneo conserva el número de líneas y usa los alias `{privado}`,
`{dir-de-trabajo}`, `{ruta-de-usuario}` e `{ipv4}`, con la lista precisa de la ronda 2.

| Archivo | Líneas | Huella del original |
| --- | --- | --- |
| `sellado/oraculo-O3-r3.md` | 2 (rutas del directorio de trabajo) | `e956db681333a48ce3d509200337d0b7edb96ee64e820dad3288d2c0b894bc5a` |
| `corrida-r1/coordinacion/auditoria.md` | 1 | `62c5ffa21a5ae9cc7998db848d03128daaae262de963c8428f39b48ff95d43e6` |
| `corrida-r1/salida/_inventario/c12b.txt` | 94 | `21ad71521779d8756b638ba1e5ddedac67fe60bb26710d8b0f108d5e307b92f9` |
| `corrida-r1/salida/_inventario/c03.txt` | 1 | `73de9a4491c4f973dd508f522ad245ce24e6e7ef38f5f22ce53751a8e0875591` |
| `corrida-r2/coordinacion/auditoria.md` | 2 | `ee9a05b2278fedc46bc6750b93e90051b32b89874a79733366b1ec7a63df7e11` |
| `corrida-r2/salida/inventario/c12b.txt` | 47 | `0712dae8ba7b82a5b7dd5fc06e67878835e1568268619c852a6838107de84294` |
| `corrida-r2/salida/inventario/c03-adaptado.txt` | 2 | `1bc7a2919473d799a5ab2835c4defb408a48a55133d0939e7b14aa4e6e9e57f2` |
| `corrida-r{1,2}/salida/LG/.docs-guard{,-origen}/…/fixtures/url-fecha/verde/a.md` (4 copias) | 1 cada una | `54b98e0d450c3376a77444e471dc90c5cbd42ede41ef755eaf040cd70d7ac76b` |

**Barrido:** `grep -rnoIiEf` con la lista precisa de la ronda 2 sobre toda `evidencia/ronda-3/C1/`, más los nombres
de máquina, de persona y de organización privada. Resultado: **0**.

## 11. Lo no verificado

- La medición de C1-r1 bajo la lectura alternativa.
- Si los artefactos de r2 pasan la compuerta del proyecto `LGD`, que no tiene copia de la compuerta.
- La CI real de A-07, que necesita red.
