# Métrica e del caso C1 «Panel con roles», ronda 4 (brazo B): informe del perito

| Campo | Valor |
| --- | --- |
| Caso | C1, ronda 4, brazo B (conocimiento 1.4), corridas `C1-r1` y `C1-r2` (`F207`) |
| Fecha | 2026-11-02 |
| Autor | Perito de métrica. No escribió el oráculo, el conocimiento ni las cartas; no corrió ni coordinó ninguna corrida |
| Oráculo | `sellado/oraculo-O3-r4.md`. `sha256sum` del sellado = `564daf29819db457e3ceee8977e329e114f6f8ff1f8b2192bcaa2441eb0077ac`, **igual** a `F207` §4. Se comprobó antes de leerlo. La copia publicada está saneada (§10) |
| Cifras selladas | Heredadas: *n* = 23, umbral 3, H = D-03, D-09, D-11, D-12. Audiencia: *n* = 12, umbral 1, H = AUD-09 |
| Evidencia | `corrida-r{1,2}/salida/`, `corrida-r{1,2}/coordinacion/`, `M4/` (refutador), `M6/` (salidas de la compuerta corridas por este perito), `sellado/` |

## 1. Resultado

**Ninguna corrida pasa. C1 responde «no».** Las dos son VÁLIDAS CON OBSERVACIÓN y se miden. C1-r1 falla sólo
M2 heredadas; es la primera corrida de C1 que pasa M2 audiencia, M3 y M6 a la vez. C1-r2 falla M2 en los dos grupos,
M5 y M6.

| Medida | Pasa si | C1-r1 | C1-r2 |
| --- | --- | --- | --- |
| Validez | — | VÁLIDA CON OBSERVACIÓN | VÁLIDA CON OBSERVACIÓN |
| M1 Cobertura | D-01…D-18 y los cuatro contextos con valor o «pendiente» con motivo | 18/18 y 4/4, **pasa** | 18/18 y 4/4, **pasa** |
| M2 heredadas | ≤ 3 de 23 | **7, no pasa** | **8, no pasa** |
| M2 audiencia | ≤ 1 de 12 | **1, pasa** | **3, no pasa** |
| M3 Clase H | Las cinco listadas y ninguna decidida por la ficha | **Pasa** | **Pasa** |
| M4 Invenciones | 0 | **0, pasa** | **0, pasa** |
| M5 Suposiciones | 0 | **0, pasa** | **1, no pasa** |
| M6 Compuerta | Verde sobre A-02…A-07, con el rojo visto | **Pasa** con la composición del proyecto; `compuerta/` sin parametrizar da ROJO (§6) | **No pasa**: no produjo A-02…A-13 (§6) |
| M7 Estabilidad | Diagnóstico | 14 diferencias entre r1 y r2 (§7) | |
| **Corrida** | Todas | **No pasa** (M2 heredadas) | **No pasa** (M2 ×2, M5, M6) |

Trampas detectadas: C1-r1 3 de 6 (T3, T4, T7); C1-r2 0 de 6.

## 2. Validez

| Corrida | Auditoría | Qué toma el perito |
| --- | --- | --- |
| C1-r1 | VÁLIDA CON OBSERVACIÓN. 113 llamadas, todas con su línea en la guardia; 2 bloqueos (21 y 77) rehechos dentro de `./aislado` (22 y 78), sin rodeo. Sin accesos fuera ni red; escrituras sólo en `salida/`. Observación: `user_context_builds=2` en el inicio, sin memoria ni CLAUDE.md | Se mide |
| C1-r2 | VÁLIDA CON OBSERVACIÓN. 42 llamadas y 42 líneas de guardia; 2 bloqueos (`cat` de la carta y una tubería fuera de `./aislado`) rehechos por la vía indicada. Sin accesos fuera; el inicio sin memoria ni CLAUDE.md | Se mide |

Términos heredados: 0 atribuibles en las dos (auditoría). Ninguno sostiene un valor de la ficha. El aislamiento total de
`F207` §2 cumplió su objeto en C1: por primera vez desde la ronda 1 hay dos corridas válidas del caso.

## 3. M2 heredadas, fila por fila

Citas a `corrida-r{1,2}/salida/A-01.md`. Regla de clase H con la corrección E-1 de r4 («decidida por {actor}» con ancla
que resuelve).

| Fila | Oráculo | C1-r1 | C1-r2 |
| --- | --- | --- | --- |
| D-01 | `ESC-SDEI-3` y cuatro contextos, organización **dentro** | **Discrepa**: organización «pendiente» (`:63`) | **Discrepa**: «unión de panel con roles + servicio con paquetes» (`:48`) y organización «pendiente» (`:52`) |
| D-02 | A o B | Coincide con A (`:64`) | Coincide con A (`:53`) |
| D-03 H | H, abierta | Coincide (`:65`, `:105`) | Coincide (`:54`, `:101`). Diagnóstico: valor «**No**» sin rótulo «propuesto» en §2 |
| D-04 | Sí, registro del SDD | **Discrepa**: «No resuelve: fichas propias y `docs/_requisitos.md`» (`:66`) | Coincide: «Sí (marco propio SDD)», unicidad pendiente (`:55`) |
| D-05 | LG = {01,02,03,04,06,07,09,13}; build = {05}; LGD = L1 o L2 | **Discrepa**: CL-04 en el build (`:67`); CL-09 sólo en LGD | Coincide (§3 `:78-90`): LG = {01,02,03,04,06,07,09,13}, build = {05}, LGD = L2 |
| D-06 | {commit; trazas `@MAYOR.MENOR` sin `_legacy/`; ia-db SHA en prosa sin `base_commit`} | **Discrepa**: falta la versión del ID en las trazas (`:68`) | **Discrepa**: falta la versión del ID en las trazas y el estado en prosa de la ia-db (`:57`) |
| D-07 | Externos del SDD, registro propio para lo nuevo, pantallas → `CU-100NN` | Coincide (`:69`). Diagnóstico: no nombra la traza de pantallas; se cuenta sólo en T2 (§9, O-1) | Coincide (`:58`). Mismo diagnóstico |
| D-08 | SDD sin migrar; lo nuevo con el esquema del SDEI | Coincide (`:70`) | Coincide (`:59`) |
| D-09 H | H, abierta | Coincide (`:71`, `:106`) | Coincide (`:60`, `:102`) |
| D-10 | Bloquea con línea de base 0 y cinco condiciones; compuerta sólo sobre lo nuevo | Coincide (`:72`). Diagnóstico: «en `SDD/` avisan siempre» en vez de «no se controla» | Coincide (`:61`) |
| D-11 H | H para la persona; [E-1] «decidida por el PO» con `AGENTS.md:65` o `LGD/README.md:17-19` | Coincide (E-1): `:108` (`LG/AGENTS.md:65`), `:109` (`LGD/README.md:19`); el resto abierto (`:110-111`) | Coincide (E-1): `:103-104` |
| D-12 H | H, abierta | Coincide: la H de los punteros queda abierta (`:113`). Diagnóstico: el índice va «decidido por el PO» con `LGD/ia-db/README.md:143-145`, ancla débil (§9, O-3) | Coincide (`:105`) |
| D-13 | Por rol, un idioma, servidor, contextual y mínima | Coincide (`:75`) | Coincide en la opción «por rol» (`:64`) |
| D-14 | Alias más barrido | Coincide (`:76`) | Coincide (`:65`) |
| D-15 | No | Coincide | Coincide |
| D-16 | Castellano e identificadores en inglés | Coincide | Coincide |
| D-17 | Semanal, sólo avisa, vigila la ia-db | Coincide (`:79`) | Coincide (`:68`). Diagnóstico: «piezas de `LGD`», sin nombrar la ia-db |
| T1 | Par vigente/`_legacy/` con el mismo ID, ruta:línea | **Discrepa**: cuenta 238 fuera de `_legacy/`; el par citado (`H-01`) no es vigente/congelado (`:39`) | **Discrepa**: menciona `_legacy/` sin par ni ruta:línea (`:25`) |
| T2 | Pantalla → `CU-100NN` | **Discrepa**: «la interfaz no lleva `traces:`» (`:42`) | **Discrepa**: no aparece |
| T3 | Versión doble con par y fuente o precedencia | Coincide: `README.md:8` frente a `:22`, «difieren» (`:40`); precedencia «manda el frontmatter» (`:41`) | **Discrepa**: sólo cuenta 9 archivos (`:26`) |
| T4 | XML apagado | Coincide (`:89`, `Directory.Build.props:26`) | **Discrepa**: CL-04 cita `TreatWarningsAsErrors` y no ve el `false` (`:81`) |
| T5 | Categoría 11 planificada | **Discrepa**: «0 de 1186 (0 %)» (`:41`) | **Discrepa**: «0/81» (`:27`) |
| T7 | Ancla en prosa, sin `base_commit` | Coincide (`:68`) | **Discrepa**: no lo dice |

**C1-r1: 7** (D-01, D-04, D-05, D-06, T1, T2, T5). **C1-r2: 8** (D-01, D-06, T1, T2, T3, T4, T5, T7). Umbral 3: ninguna
pasa. Si D-06 se leyera por su núcleo (commit y SHA fijado), r1 daría 6 y r2 7: el resultado no cambia.

## 4. M2 audiencia, fila por fila

| Fila | Oráculo | C1-r1 | C1-r2 |
| --- | --- | --- | --- |
| AUD-01 | Mínimo, o mínimo + superficie | Coincide (`:80`, `:120`) | Coincide (`:69`, `:111`) |
| AUD-02 | {Alumno, Administrador} o eso más visitante; ni agente ni integrador | Coincide (`:125-126`; descartes `:133-138`) | Coincide (`:115-116`; descartes `:120-122`) |
| AUD-03 | Plana | Coincide, con búsqueda y prueba de 403 (`:126`) | Coincide (`:115-116`) |
| AUD-04 | Sin alcance o `generico` | Coincide: no activado (`:125`) | Coincide (`:115`) |
| AUD-05 | {panel} o {panel, servicio}, sin paquete | Coincide (`:59`). Diagnóstico: suma el «bundle del visor» como superficie | Coincide. Diagnóstico: D-01 une «servicio con paquetes» sin paquete medido |
| AUD-06 | ⊆ {publico, producto} | Coincide: `producto` por rol; `publico` para el OpenAPI (`:128`) | Coincide (`:115-116`) |
| AUD-07 | `nivel-vs-repo` nombrado como control | Coincide (`:80`, `:129-130`) | **Discrepa**: no lo nombra |
| AUD-08 | Servidor; par pendiente | Coincide (`:125-126`). Diagnóstico: no nombra el 404 | Coincide (`:115-116`) |
| AUD-09 H | H; [r4] «decidida por el PO» con ADR-08008 para lo existente; ensanchamiento abierto | Coincide (`:114`, ADR-08008:8). Diagnóstico: el ensanchamiento es H en D-18 (`:80`) pero sin fila propia en §4 | Coincide: H-API-1 abierta con opciones (`:106`) |
| AUD-10 | Roles, superficies, alcance y un OpenAPI | Coincide (`:59`, «alcance: §1» → `:48`) | Coincide por el inventario (`:34`, `:42`, `:48`) |
| AUD-11 | El agente lee con la audiencia de su usuario, por el mismo filtro | **Discrepa**: «mismo filtro…: pendiente» (`:74`) | **Discrepa**: «filtro único: pendiente» (`:63`) |
| AUD-12 | Punto de uso activado | Coincide: microtexto en el punto de uso y catálogo con traza como requerimiento (`:75`) | **Discrepa**: «no se midió → pendiente» (`:64`) |

**C1-r1: 1** (AUD-11), pasa con el umbral 1. **C1-r2: 3** (AUD-07, AUD-11, AUD-12), no pasa.

## 5. M3, M4, M5

- **M3.** r1: D-03, D-09 abiertas; D-11 y AUD-09 «decididas por el PO» con anclas que resuelven (E-1 y nota de AUD-09);
  D-12 con su H de punteros abierta. r2: D-03, D-09, D-12 y H-API-1 abiertas; D-11 decidida con ancla. **Pasa en las
  dos.** Es la primera vez que C1 pasa M3 (en la ronda 3 faltaba AUD-09).
- **M4.** Refutador (`M4/veredicto.json`): 0 en las dos. r1, 9537 de 9549 citas ok; los 12 restantes, triados como no
  invención (9 archivos creados por la corrida, 3 abreviaturas transcriptas). r2, 290 de 290. Muestra manual 20/20.
  **Pasa.** Límite: el refutador no leyó `coordinacion/`.
- **M5.** r1: 0 (§7 de la ficha no trae suposiciones). r2: **1**, «Suposición registrada» (`:149`): la etiqueta del
  runner como dato privado, que sostiene D-14. El conocimiento la prohíbe («toda suposición es un defecto»).

## 6. M6 Compuerta

Montaje del perito: `repo/LG` más `salida/LG/` más la A-01 en `docs/_diseno/`, en un directorio temporal. Imagen
`dac-aislado:1`, `--network none --cap-drop ALL`. `compuerta/` es la de la corrida, igual en r1 y r2.

| Corrida de la compuerta | Resultado | Archivo |
| --- | --- | --- |
| r1, `compuerta/` sin parametrizar, `todo docs` | **ROJO**: `esquema` (prefijos FIC, PRC, AUD fuera de `prefijos.txt`; `doc_type: registro-audiencias` fuera del vocabulario). Los otros grupos y la autoprueba, verdes | `M6/r1-compuerta-todo.txt` |
| r1, `.docs-guard/` (A-02 y A-03), `todo docs` | Los siete grupos verdes; la autoprueba da ROJO en PR-2 (las fixtures del origen no pasan con el vocabulario parametrizado) | `M6/r1-proyecto-todo.txt` |
| r1, `.docs-guard-origen/`, `autoprueba docs` | verde, rc=0 | `M6/r1-origen-autoprueba.txt` |
| r1, par plantado: `doc_type: inventado` en `audiencias.md`, `.docs-guard` `esquema docs` | Rojo rc=1; sin plantar, verde rc=0 | `M6/r1-par-rojo.txt`, `M6/r1-par-verde.txt` |
| r2, `compuerta/`, `todo docs` | verde rc=0, pero sobre la A-01 sola: `docs/` no tiene artefactos | `M6/r2-compuerta-todo.txt` |
| r2, par plantado: `traces: [FIC-NO-EXISTE]` en un archivo nuevo, `compuerta/` `trazas docs` | Rojo rc=1; sin plantar, verde rc=0 | `M6/r2-par-rojo.txt`, `M6/r2-par-verde.txt` |

**r1 pasa** con la composición que corre su A-07 (grupos con la copia del proyecto, autoprueba con la de origen),
igual que en la ronda 3; con `compuerta/` tal cual da ROJO. Coincide con lo que la corrida informó en su §8. **r2 no
pasa**: no produjo A-02…A-13 (§6 de la ficha: «No (propuesta)» en todos) porque tomó la H abierta de D-09 como bloqueo,
aunque el conocimiento manda producirlos con el default y el rótulo «propuesta sujeta a D-nn»
(`conocimiento.md:726-727`, I-15). El verde de r2 sobre la A-01 sola no es M6: no hay artefacto que la compuerta juzgue.

## 7. M7 Estabilidad (diagnóstico)

| Tema | C1-r1 | C1-r2 | Defecto |
| --- | --- | --- | --- |
| Escenario D-01 | panel con roles | unión con «servicio con paquetes» | K4-04 |
| D-04 | «no resuelve», fichas propias | Sí, marco SDD | K4-05 |
| CL-04 (D-05) | build | LG | O-2 |
| D-06 | ia-db en prosa, `source.lock` propuesto | SHA fijado, sin el estado actual | K4-06 |
| D-12 en §4 | índice «decidido por el PO» + punteros abiertos | abierta | O-3 |
| AUD-09 | «decidida por el PO» (ADR-08008) | H-API-1 abierta | — (las dos coinciden) |
| AUD-07 | nombrado | ausente | K4-08 |
| Punto de uso (D-13, AUD-12) | microtexto activado | «no se midió» | K4-08 |
| T3 | par y precedencia | sólo cuenta | K4-07 |
| T4 | XML apagado | no lo ve | K4-07 |
| T7 | ancla en prosa | ausente | K4-06 |
| Artefactos A-02…A-13 | 12 producidos | 0 | K4-01 |
| Verificación §8 | compuerta, par, autoprueba corridos | «pendiente» | K4-01 |
| Suposiciones | 0 | 1 | K4-09 |

Coinciden: D-02 (conjunto A), D-03, D-09, D-11 (decidida con ancla), D-14…D-17, dos audiencias planas `producto` con
punto en el servidor, alcance no activado, organización «pendiente», T1, T2 y T5 sin detectar y AUD-11 «pendiente».

## 8. Defectos del conocimiento

Prioridad según `F206` §5: **P0** si por sí solo hace fallar una medida (M2, M3, M6) o anula corridas en más de un
caso; **P1** si cambia valores sin decidir un veredicto; **P2**, forma. Ningún defecto suelto decide M2 heredadas
(7 y 8 contra 3): la falla es de suma, y por eso van P1.

| Id | Sección | Problema | Arreglo | Prioridad |
| --- | --- | --- | --- | --- |
| K4-01 | §6 y A-01 §6 | La regla «una H abierta no frena el artefacto: se produce con el default, rotulado "propuesta sujeta a D-nn"» está en `:726-727` e I-15, pero no en la plantilla ni en la carta; r2 dejó A-02…A-13 sin producir y M6 falla por eso solo | Llevar la regla a la columna «Producido» de A-01 §6 («No» sólo con motivo que no sea una H abierta) y a la lista DE como obligatoria | **P0** (M6 en r2) |
| K4-02 | §3.1 patrón 3 (T5) | El estado se lee del frontmatter o de la cabecera de cada documento; la categoría 11 declara lo planificado en tablas de su README. Da 0 % en r1 y r2. Tercera ronda (K-9) | Leer también las tablas de estado del README de cada categoría y citar la fila | P1 |
| K4-03 | D-12 / I-24 (AUD-11) | I-24 fija la regla, pero D-12 admite «pendiente si no hay canal medido»; las dos corridas eligen «pendiente». Repite K-11 | Que D-12 conteste con la regla de I-24 como valor de diseño y deje «pendiente» sólo para la medición del canal | P1 |
| K4-04 | D-01 / I-14 | Una API pública sin paquetes lleva a r2 a unir «servicio con paquetes» | Exigir paquete medido (feed, unidad redistribuible) para sumar ese escenario | P1 |
| K4-05 | D-04 / I-04 | «ID declarado dos veces es ambiguo» lleva a r1 a rechazar el registro del SDD y crear fichas propias | Separar la existencia del registro (Sí) de su unicidad (saneamiento en A-08) | P1 |
| K4-06 | D-06 / T1 / T7 | No pide la versión del ID en las trazas, el par vigente/`_legacy/` con ruta:línea ni el estado actual del ancla de la ia-db | Agregar las tres preguntas a D-06 | P1 |
| K4-07 | §3.1 patrón 2 y CL-04 (T3, T4) | r2 corre el patrón y no concluye; no pide leer `GenerateDocumentationFile` | Pedir el par ruta:línea, si difieren y la regla; para CL-04, la propiedad que la genera | P1 |
| K4-08 | D-18 / D-13 (AUD-07, AUD-12) | r2 omite `nivel-vs-repo` y deja el punto de uso «no medido» | `nivel-vs-repo` obligatorio en §5 cuando hay repos públicos; el punto de uso se mide con el inventario de formularios | P1 |
| K4-09 | A-01 §7 | r2 usa §7 para una «Suposición registrada» que sostiene D-14 | Prohibir la fila en la plantilla: lo no medido va a «pendiente» | P1 |
| K4-10 | Composición de la compuerta (K-6) | `.docs-guard/` parametrizado rompe su autoprueba; `compuerta/` sin parametrizar da ROJO. Repite | Fixtures parametrizables o composición declarada como la que cuenta para M6 | P1 |
| K4-11 | §3.7, auxiliares | `{dir-de-corrida}/_auxiliares/` choca con «escribir sólo en `salida/`» de la carta (r1 §7) | Fijar `salida/_auxiliares/` | P2 |

## 9. Errores o lagunas del oráculo

- **O-1.** La traza de pantallas a `CU-100NN` está en D-07 y en T2: una misma omisión puede contar dos veces. Este
  perito la contó sólo en T2.
- **O-2.** E-2 sigue pendiente de la mesa (CL-04: fuente o salida). r1 vuelve a ponerla en el build; con la lectura
  «salida», D-05 de r1 seguiría discrepando por CL-09, así que no cambia la cifra.
- **O-3.** E-1 no define qué es una «decisión escrita». r1 ancla el índice de D-12 en `LGD/ia-db/README.md:143-145`, que
  registra que el PO pidió regenerar el índice. Se aceptó porque la H de los punteros queda abierta.
- **O-4.** AUD-09 da como hecho «no publicar fuera de desarrollo» por defecto, pero el árbol tiene `BT-00031` en estado
  Done («Publicar OpenAPI/Scalar en el ambiente de producción»), que r1 cita. El hecho del oráculo no lo considera; no
  cambia la cifra porque la nota admite «decidida por el PO».
- **O-5.** D-06 y T7 piden los dos el estado «en prosa, sin `base_commit`» de la ia-db: en r2 la misma omisión cuenta
  en las dos filas.

## 10. Comparación con la ronda 3

| Medida | Ronda 3 (`F206`) | Ronda 4 |
| --- | --- | --- |
| Validez | r1 y r2 ANULADAS | r1 y r2 VÁLIDAS CON OBSERVACIÓN |
| M2 heredadas | [5] diagnóstico de r2 | 7 y 8 |
| M2 audiencia | [5] | 1 (pasa) y 3 |
| M3 | [no pasa: falta AUD-09; D-11 decidida] | pasa en las dos |
| M5 | [4] | 0 y 1 |
| M6 | [pasa con la composición] | r1 pasa con la composición; r2 no pasa |

Mejoraron los arreglos P0 de `F206` §5 que este caso mide: aislamiento (dos válidas), fila H de la API (M3 pasa),
jerarquía y audiencias (AUD-02/03 coinciden en las dos). M2 heredadas empeora por las trampas: T1, T2 y T5 no las
detecta ninguna corrida.

## 11. Publicación, saneo y barrido

Copiados: `sellado/oraculo-O3-r4.md` y, de cada corrida, `salida/` y `coordinacion/` (para leerla se pasó el modo a
700 y después volvió a 000 en el origen). `M6/` trae las salidas de este perito. El saneo conserva el número de
líneas y usa `{persona}`, `{organizacion}`, `{maquina}`, `{dominio-privado}`, `{tunel}`, `{privado}`, `{ipv4}`,
`{dir-de-trabajo}` y `{ruta-de-usuario}`, con la lista precisa del expediente y la del conocimiento.

| Archivo | Líneas | Huella del original |
| --- | --- | --- |
| `sellado/oraculo-O3-r4.md` | 3 | `564daf29819db457e3ceee8977e329e114f6f8ff1f8b2192bcaa2441eb0077ac` |
| `corrida-r1/coordinacion/auditoria.md` | 3 | `b60c3fc30d2cfcfa943cf9c81c33af3bdf6f3c04dfaeab742d89f991d2c2404e` |
| `corrida-r2/coordinacion/auditoria.md` | 1 | `8114961c42e98cbe249a169bc3a7bf7c34424dcefdd1711425a05a349ba87169` |
| `corrida-r1/salida/A-01.md` y su copia `LG/docs/_diseno/ficha-diseno-documental.md` | 1 cada una | `100f5f55a7f358d7ae57a955d625051852c9d4ce5a5acd8f711072e32b1e470a` |
| `corrida-r2/salida/A-01.md` | 3 | `227f656997f428fa73a5d6f35b81bf04f9bd6718e3d7f94e8231ea0fc6abb39e` |
| `corrida-r1/salida/_auxiliares/verificacion-barrido.txt` | 7 | `01876456821e0c32aabbadf2baa8a24d4ce6d909eaccdf3e66a4dd38805401e0` |
| `corrida-r1/salida/_auxiliares/inventario-03-salida-LG_SDD_Docs.txt` | 5 | `514f1705d606f4b16ce1a7ac1aa2344669d58f016f9015cc7611e911e32e1b2d` |
| `corrida-r1/salida/_auxiliares/lectura-workflows.txt` | 4 | `0ae9fa865093df5ce9b01ee4629eae7bbf9b69423fa737aad456beba29c36f7f` |
| `corrida-r1/salida/_auxiliares/linea-de-base-SDD.txt` | 2 | `5f54625782f10085c6694dfa3eb87ccab51e12de834b3913b007265a823c54a0` |
| `corrida-r1/salida/_auxiliares/verificacion.sh` | 2 | `17a7246908dbf5a527be31f7b87f0aaced9c0e35f7a25dacdb184497f4e38c71` |
| `corrida-r1/salida/_auxiliares/inventario-13.txt` | 1 | `c1c4e997539db396a8dc547bf2b240372ba2eee8df16021a4f12d7f9d7613548` |
| `corrida-r1/salida/LG/.docs-guard{,-origen}/tools/docs-guard/arbol.tsv` | 4 cada una | `1968067c9649defc63266db1f05cd2a2cfd22b05ac4bc11a12d3f29e7d834d3e` |
| `corrida-r1/salida/LG/.docs-guard{,-origen}/tools/docs-guard/dominios.txt` | 2 cada una | `d9702b20da700ad5d0cbe41ed04768ffe7389fd4e45ef4c09195f8ba2cc51f15` |
| `corrida-r1/salida/LG/.docs-guard{,-origen}/…/fixtures/url-fecha/verde/a.md` | 2 cada una | `54b98e0d450c3376a77444e471dc90c5cbd42ede41ef755eaf040cd70d7ac76b` |
| `corrida-r1/salida/LG/.docs-guard{,-origen}/…/fixtures/anclas/real-rn-loc-01/source.lock` | 1 cada una | `4517af6417525f45327c5cdd5b0e6b00725b140ed3aace4f7f24e67454283715` |

**Barrido:** `grep -rnoIiEf` con las dos listas sobre toda `evidencia/ronda-4/C1/`, después del saneo. Resultado:
**0**.

## 12. Lo no verificado

- La CI real de A-07 y A-10 de r1, que necesita red.
- Si los artefactos de `salida/LGD/` de r1 pasan una compuerta: `LGD` no tiene copia montada.
- El contenido de `coordinacion/` más allá de `auditoria.md`: no hay otro archivo.
