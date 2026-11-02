# Métrica e del caso C3a «Colmenar, proyecto nuevo (ficha 2)», ronda 4 (brazo B): informe del perito

| Campo | Valor |
| --- | --- |
| Caso | C3a, ronda 4, brazo B (conocimiento 1.4), corridas `C3a-r1` y `C3a-r2` (`F207`) |
| Fecha | 2026-11-02 |
| Autor | Perito de métrica. No escribió el oráculo, el conocimiento ni las cartas; no corrió ni coordinó ninguna corrida |
| Oráculo | `sellado/oraculo-O3-r4.md`. `sha256sum` del sellado = `e0ae58f7a199667d3250f2307b39ba9176084b67492ea493d8dd223d7612913e`, **igual** a `F207` §4. Se comprobó antes de leerlo. La copia publicada está saneada (§10) |
| Cifras selladas | Heredadas: *n* = 21, umbral 3; H = D-03, D-09, D-11, D-12 (D-01 sólo en la lectura c). Audiencia: *n* = 12, umbral 1; H = AU-09, AU-10 (AU-05 sólo si se propone jerarquía). Por separado, como `F206` §2 |
| M4 | Contra la semilla `d39dfbd` (refutador, `M4/`) |
| Evidencia | `corrida-r{1,2}/salida/`, `corrida-r{1,2}/coordinacion/`, `M4/` (refutador), `M6/` (salidas de la compuerta), `sellado/` |

## 1. Resultado

**Ninguna corrida pasa. C3a responde «no» en la ronda 4.** Las dos corridas son válidas (VÁLIDA CON OBSERVACIÓN) y
se miden. Las dos fallan M2 audiencia en cualquier lectura, por la misma causa: el alcance por productor y las
extensiones de D-18 quedan «no activado» (§4). r2 falla además M2 heredadas en cualquier lectura.

| Medida | Pasa si | C3a-r1 | C3a-r2 |
| --- | --- | --- | --- |
| Validez | — | VÁLIDA CON OBSERVACIÓN | VÁLIDA CON OBSERVACIÓN |
| M1 Cobertura | D-01…D-18 con valor o «pendiente» con motivo | 18/18, **pasa** | 18/18, **pasa** |
| M2 heredadas | ≤ 3 de 21 | **5, no pasa** (2 con la lectura laxa) | **8, no pasa** (4 con la lectura laxa) |
| M2 audiencia | ≤ 1 de 12 | **2, no pasa** (2 en las dos lecturas) | **7, no pasa** (3 con la lectura laxa) |
| M3 Clase H | Las seis fijas en §4, ninguna decidida por el agente | **Pasa** | **Pasa**, con observación (D-03 «abierta», §5) |
| M4 Invenciones | 0 | **0, pasa** | **0, pasa** |
| M5 Suposiciones | 0 | **0, pasa** | **0, pasa** |
| M6 Compuerta | Verde, con el rojo visto | **Pasa** con la composición del proyecto (§6) | **Pasa** con la composición del proyecto (§6) |
| M7 Estabilidad | Diagnóstico | — | 13 diferencias (§7) |
| **Corrida** | Todas | **No pasa** (M2 heredadas y M2 audiencia) | **No pasa** (M2 heredadas y M2 audiencia) |

Demandas: 0 en las dos corridas (no hay `demandas.md`); «sí»: 0.

**Lectura estricta y laxa.** La cifra oficial es la estricta: una fila coincide sólo si trae **todos** sus elementos
obligatorios en A-01 o en los artefactos de la corrida (método del oráculo, «Cómo se compara»). La laxa acepta un
obligatorio que se deduce de otras filas sin estar escrito. El veredicto **no depende de la lectura**: en las dos, las
dos corridas fallan M2 audiencia (2 y 3 contra umbral 1).

## 2. Validez

| Corrida | Auditoría | Qué toma el perito |
| --- | --- | --- |
| C3a-r1 | VÁLIDA CON OBSERVACIÓN: 49/49 herramientas en la guardia; un bloqueo (un `&&` fuera del contenedor), rehecho en dos llamadas por `./aislado`; 0 accesos fuera; init sin CLAUDE.md ni memoria; 0 términos heredados | **Se mide.** Por `F206` §1, el bloqueo no produjo salida ni valor: lectura indulgente sin objeto |
| C3a-r2 | VÁLIDA CON OBSERVACIÓN: 56/56 herramientas en la guardia; dos bloqueos (un `cat` fuera de `./aislado` y un `&&`), los dos sin salida y rehechos por `./aislado`; 0 accesos fuera; init limpio; 0 términos heredados | **Se mide.** La única consola fuera de `./aislado` (entrada 1) fue rechazada y no dio salida |

Es la primera ronda en que las dos corridas de C3a son válidas. El aislamiento total de `F207` §2 cerró la causa de
anulación de la ronda 3 (cómputo del host): 0 accesos fuera, 0 rodeos.

## 3. M2 heredadas, fila por fila

Citas a `corrida-r{1,2}/salida/A-01.md`. «D» = discrepa; «D (estricta)» = discrepa sólo en la lectura estricta.

| Fila | Oráculo (resumen) | C3a-r1 | C3a-r2 |
| --- | --- | --- | --- |
| D-01 | Unión ESC-3+ESC-4+ESC-1, o ESC-3 con altas por paquete, curso y sitio | Coincide: unión «panel con roles» + «servicio con paquetes»; curso por D-15 (alta CL-10) y sitio por D-03 (alta CL-14) (`:65`, `:101`, `:105`) | Coincide: misma unión (`:53`); CL-10 y CL-14 dadas de alta (`:89`, `:93`) |
| D-02 | Obligatorias CL-01,02,03,06,07,10,12,13,14 | Coincide (`:70`, §3) | Coincide (`:58`, §3) |
| D-03 H | Sí, decidido por la persona; CL-14; dos idiomas; O-1 pendiente | **D (estricta)**: «decidida por el programa provincial» (`:111`) y CL-14 (`:105`); alojamiento pendiente (`:71`), pero no dice que el sitio salga en los dos idiomas ni deja el dominio pendiente | **D**: en §4 figura «abierta» con default «Sí (propuesto)» (`:99`): excluido «listar el sitio como no decidido». Sin O-1 |
| D-04 | Sin SDD; trazar a EX-31…EX-46; cada entrega declara las EX | Coincide (`:72`; RD-04 en `docs/_requisitos.md:25`; `CHANGELOG.md:6` declara las EX) | **D**: ningún lugar dice que cada entrega declare las exigencias que cumple; no hay CHANGELOG (A-11 no producido, `:145`) |
| D-05 | App en su repo, ayuda en el binario; paquete en su repo; curso dedicado; sitio desde la misma fuente | **D (estricta)**: CL-06 en «carpeta de ayuda de la app; sitio público» (`:97`) sin decir que el sitio sale de la misma fuente; del paquete sólo `AGENTS.md` y su referencia (`:73`) | **D (estricta)**: ídem: sin misma fuente para el sitio ni ayuda que viaja con el binario (`:61`, `:85`) |
| D-06 | Commit + etiqueta anotada por versión; una línea por versión; externos por SHA; paquete con su numeración | **D**: «las dos sin etiqueta (0 etiquetas) → por SHA» (`:74`): no propone etiqueta por versión | **D**: «sin etiqueta en el repo → por SHA» (`:62`) |
| D-07 | Registro propio con RD; EX externo, sólo EX-31…46 | Coincide (`:75`; `prefijos.txt`: «a Colmenar le tocan EX-31 a EX-46») | Coincide (`:63`; `prefijos.txt`) |
| D-08 | Diez + `description`; mapeo del encabezado; sin igualar `owner`/`last_review` | Coincide: `version`, `aprobado_por`, `fecha_aprobacion`, no igualados (`:76`) | **D**: sólo `aprobado_por` y `fecha_aprobacion` (`:64`); la versión del encabezado no se mapea; la nota de A-03 dice «lo heredado sin frontmatter avisa» en un proyecto sin nada heredado |
| D-09 H | Abierta; no reutilizable de otra organización; Linux; default copia o reutilizable propio | Coincide (`:77`, `:112`) | Coincide (`:65`, `:100`; A-07 en el runner Linux) |
| D-10 | Bloquea desde el primer PR; check obligatorio H; build del sitio bloquea; AI-3 avisa | **D**: bloqueo desde el primer PR y check obligatorio H (`:78`, `:113`), pero el build del sitio no entra a la compuerta | Coincide: línea de base 0 y bloqueo (`:66`), check obligatorio H (`:104`); el build del sitio «entra a la compuerta» está en `:59` (ver E-O3) |
| D-11 H | Delegación dada como decisión del PO; visto bueno del técnico; O-2 pendiente | Coincide: «decidida por el dueño del producto — citada, no versionada» (`:79`, `:114`); suplente pendiente | Coincide (`:67`, `:101-102`). Suplente sin mencionar: es libre |
| D-12 H | `AGENTS.md` propuesto; canales del sitio (CL-14) | Coincide (`:80`, `:115`) | Coincide (`:68`, `:103`) |
| D-13 | Por rol y por idioma, en la app; confidencialidad en el servidor | Coincide (`:81`; kilos y precios en la API, `:48`) | **D (estricta)**: por rol y es/pt (`:69`), pero kilos y precios no aparecen; sólo «punto de cumplimiento: servidor» genérico en §5 |
| D-14 | Alias de API, proveedor y organismo; sin ubicaciones ni alumnos; barrido | Coincide (`:82`) | Coincide (`:70`) |
| D-15 | Sí: curso en repo dedicado, SHA, portugués | Coincide (`:83`, CL-10, A-09) | Coincide (`:71`, CL-10, A-09) |
| D-16 | Equipo es; ayuda y sitio es/pt; paquete en dos idiomas; curso pt | **D (estricta)**: la app en es/pt, pero el sitio no se nombra (`:84`) | **D (estricta)**: «Español y portugués» para todo (`:72`): no separa la documentación del equipo en español ni nombra el sitio |
| D-17 | Diario/mensual; 90 días a procedimientos; vigila tabla y frescura | Coincide (`:85`; A-10 con los dos `cron`) | Coincide (`:73`). El A-10 corre diario todo el año además del mensual: diagnóstico, no cuenta |
| T3-1 | Plataformas por condición del `.csproj`; runner por plataforma | Coincide (`:46`, `:77`) | Coincide (`:42`) |
| T3-2 | A-01 declara el límite de la letra localizada | Coincide (`:81`) | **D (estricta)**: el límite sólo está en A-13 (`docs/_gobierno/controles-entrega.md:32`), no en A-01 (ver E-O4) |
| T3-3 | Alias de proveedor y organismo; barrido | Coincide (`:82`) | Coincide (`:70`) |
| T3-4 | Sin oráculo | — | — |
| T3-5 | Todo bloquea desde el primer PR | Coincide (`:78`) | Coincide (`:66`) |

**C3a-r1: 5** (D-03, D-05, D-06, D-10, D-16) contra 3: **no pasa**. Laxa: **2** (D-06, D-10).
**C3a-r2: 8** (D-03, D-04, D-05, D-06, D-08, D-13, D-16, T3-2) contra 3: **no pasa**. Laxa: **4** (D-03, D-04, D-06,
D-08), y tampoco pasa.

Discriminantes (sin umbral): D-08 coincide en r1 y discrepa en r2; D-10 discrepa en r1 sólo por el build del sitio y
coincide en r2.

## 4. M2 audiencia

| Fila | Oráculo (resumen) | C3a-r1 | C3a-r2 |
| --- | --- | --- | --- |
| AU-01 | Inventario: cinco roles, superficies, alcance por productor, 0 OpenAPI | Coincide (`:48`, `:65`): el alcance queda registrado como declarado | **D (estricta)**: D-01 no lista las superficies ni la cuenta de OpenAPI (`:53`) |
| AU-02 | Perfil mínimo + extensiones alcance y superficie; registro `AUD-`; `delivery:` | **D**: «Perfil mínimo, sin extensiones» (`:126`) | **D**: ídem (`:115`); el registro no lleva IDs `AUD-` |
| AU-03 | Los cinco perfiles | Coincide (`:132-136`) | Coincide (`:123-127`) |
| AU-04 | La semilla no tiene autorización medible; la API la hace cumplir | Coincide (`:55`, `:132`) | Coincide (`:47`, `:116`) |
| AU-05 | Planos; jerarquía sólo como H | Coincide (`:122`) | Coincide (`:111`) |
| AU-06 | Alcance por productor como extensión | **D**: «no activado» (`:132`; §7 `:173`) | **D**: «no activado» (`:123`) |
| AU-07 | App, sitio y paquete .NET público | Coincide (`:65`) | **D (estricta)**: las superficies no se enumeran en ningún lugar |
| AU-08 | Repos públicos: publico/producto; la app instalable sólo `publico`; kilos y precios en el servidor | Coincide (`:81`; `nivel-vs-repo` en `docs/_gobierno/registro-audiencias.md`) | **D**: sin `nivel-vs-repo`, sin decir que lo que viaja en la app es `publico`, sin kilos y precios |
| AU-09 H | Exposición de la API, H para una persona | Coincide (`:116`) | Coincide (`:105`) |
| AU-10 H | Acceso del inspector no decidido, para una persona | Coincide (`:121`) | Coincide (`:110`): default propuesto «reporte mensual», sin nivel |
| AU-11 | El asistente lee el sitio por el mismo filtro | Coincide (`:80`, `:139-140`) | **D (estricta)**: sólo «CL-14 por el sitio» (`:68`); nada sobre el filtro ni el nivel `publico` |
| AU-12 | Opción de punto de uso como canal de CL-06; letra localizada no se ancla | Coincide (`:81`: «ninguno por ahora», con motivo) | **D (estricta)**: «en el punto de uso» sin elegir opción (`:69`); el límite de la letra localizada sólo en A-13 |

**C3a-r1: 2** (AU-02, AU-06) contra 1: **no pasa** (igual en las dos lecturas). **C3a-r2: 7** (AU-01, AU-02, AU-06,
AU-07, AU-08, AU-11, AU-12) contra 1: **no pasa**. Laxa: 3 (AU-02, AU-06, AU-08).

AU-02 y AU-06 discrepan en las dos corridas por la misma regla: el conocimiento 1.4, §3.2.1 regla 4, activa el alcance
sólo si el código lo restringe o hay inventario de alcances, y r1 lo dice como no resuelto (`:173`). Es el defecto
K4-01 (§8), que por sí solo hace fallar M2 audiencia.

## 5. M1, M3, M4, M5

- **M1.** Las dos fichas traen D-01 a D-18, con los cuatro contextos de D-01, cada uno con valor o «pendiente» con
  motivo. **Pasa** en las dos.
- **M3.** r1: D-03 «decidida por el programa provincial», D-09 abierta, D-11 «decidida por el dueño del producto —
  citada, no versionada», D-12 abierta, la API (AU-09) y el inspector (AU-10) abiertas, la jerarquía abierta con default
  plana. Ninguna decidida por el agente; D-11 ya no está abierta con el default excluido. **Pasa.** r2: las seis
  figuran en §4 para una persona, ninguna como decisión del agente. D-03 figura «abierta» con default «Sí»: el default
  no cae en los excluidos, así que E-5 no la lleva a M3. **Pasa, con observación**; la falla cuenta en M2 (E-O5).
- **M4.** Refutador (`M4/resultado.md`), contra `d39dfbd`: r1 150 citas, 13 marcadas, **0** invenciones; r2 106
  citas, 4 marcadas, **0**. **Pasa** en las dos.
- **M5.** r1 no completa O-1 (alojamiento «pendiente») ni O-2 (suplente «pendiente») y no declara suposiciones. r2
  declara «Suposiciones: ninguna que sostenga un valor» (`:158`) y no completa O-1 ni O-2. **0, pasa** en las dos.
  Observación: el A-07 y el A-10 de r2 usan la etiqueta de runner `colmenar`, que la ficha no da; es un artefacto, no
  un valor de la ficha, y no se cuenta.

## 6. M6 Compuerta

Montaje del perito, por corrida: el árbol de `d39dfbd` sin `.git` (`git archive`), más `docs/`, `AGENTS.md`,
`.github/`, `.docs-guard/` (A-02 y A-03), `.docs-guard-origen/` y, en r1, `CHANGELOG.md`; en r2, `source.lock`; la
A-01 en `docs/_diseno/ficha-diseno-documental.md`. Se agregó `compuerta/` de la corrida como `.compuerta-corrida/`.
Todo corrió con `dac-aislado:1` (id `4f0d72f24b36`), `--network none --cap-drop ALL`, `npm_config_offline=true`.

| Corrida de la compuerta | r1 | r2 | Archivo |
| --- | --- | --- | --- |
| `compuerta/` sin parametrizar, `todo docs` | **ROJO**: `esquema` (FIC, PRC y AUD fuera de su `prefijos.txt`; `registro-audiencias` fuera del vocabulario), 5 errores; los demás grupos y la autoprueba, verdes | **ROJO**: ídem, 8 errores | `M6/r{1,2}-origen-todo.txt` |
| `.docs-guard/` del proyecto, por grupo (`enlaces`, `esquema`, `ai`, `estructura`, `trazas`, `contrato`, `fijadas`) | Siete verdes, rc=0 (esquema con 1 aviso `traces-vacio`) | Siete verdes, rc=0 | `M6/r{1,2}-proyecto-<grupo>.txt` |
| `.docs-guard/` del proyecto, `todo docs` | Grupos verdes; autoprueba ROJA (4 fallas de PR-2: fixtures del origen contra el vocabulario parametrizado); agregador ROJO | ídem | `M6/r{1,2}-proyecto-todo.txt` |
| `compuerta/`, `autoprueba docs` | verde, 50 casos `ok` | verde | `M6/r{1,2}-origen-autoprueba.txt` |
| Par plantado: `doc_type: inventado` en el registro de audiencias, `esquema docs` con `.docs-guard/` | rojo rc=1; sin plantar, verde rc=0 | rojo rc=1; sin plantar, verde rc=0 | `M6/r{1,2}-par-{rojo,verde}.txt` |

**Las dos pasan** con la composición del proyecto (grupos con A-02 y A-03, autoprueba con la copia de origen), la
misma que en la ronda 3. El par que plantó cada aplicador (una traza a `FIC-NO-EXISTE`) también da rojo y verde en su
`§8`. El agregador `todo` de una sola copia sigue sin poder dar verde: K-8 de la ronda 3, sin cerrar (K4-07).

## 7. M7 Estabilidad (diagnóstico)

Las dos corridas son válidas: es la primera M7 real de C3a.

| Tema | C3a-r1 | C3a-r2 | Defecto |
| --- | --- | --- | --- |
| D-03 en §4 | «decidida por el programa provincial» | «abierta», default «Sí» | K4-04 |
| D-04, EX por entrega | `CHANGELOG.md` y RD-04 declaran las EX | Ausente | K4-05 |
| A-11 | `CHANGELOG.md` producido | No producido | K4-05 |
| D-08, campos del encabezado | `version`, `aprobado_por`, `fecha_aprobacion` | Sólo `aprobado_por`, `fecha_aprobacion` | K4-06 |
| D-10, build del sitio | Ausente | En la compuerta (`:59`) | K4-03 |
| D-16, idioma del equipo | Español en el repositorio | «Español y portugués» para todo | K4-03 |
| CL-11 | Baja (la tabla es dato de D-17) | Activa (copia con huella) | — (libre) |
| CL-08 y CL-09 | Baja | «Sujetas» a D-12 y al hermano | — (libres) |
| Default de AU-10 | No entregar hasta que se decida | Reporte mensual | — (los dos admitidos) |
| IDs del registro de audiencias | `AUD-01`…`AUD-05` | Sin IDs | K4-01 |
| AU-08 y AU-11 (nivel `publico` en la app y en el sitio) | Dichos | Ausentes | K4-01 |
| A-09 | `_otros-repos/curso/source.lock` | `source.lock` en la raíz | K4-08 |
| Lugar de los auxiliares | `salida/_auxiliares/` (declarado en §7 contra §3.7) | `_auxiliares/` de la corrida, citado como `salida/_auxiliares/` | K4-08 |

Coinciden en las dos: D-01 (unión panel + servicio con paquetes, curso y sitio dados de alta), D-02 obligatorias,
D-06 «por SHA» sin etiqueta, D-07, D-09, D-11 «citada, no versionada», D-12, D-15 «Sí», D-17, D-18 con perfil
mínimo sin extensiones y las cinco audiencias «pendiente» y planas, AU-09 y AU-10 en §4, O-1 y O-2 sin completar.

## 8. Defectos del conocimiento (1.4)

Prioridad según `F206` §5: **P0** si por sí solo hace fallar una medida o anula corridas en más de un caso; **P1** si
cambia valores sin decidir un veredicto; **P2**, forma.

| Id | Prioridad | Sección | Problema | Arreglo |
| --- | --- | --- | --- | --- |
| K4-01 | **P0** | §3.2.1 regla 4 y extensiones de D-18 | Con la autorización en un repositorio ajeno, el alcance «sólo lo suyo» que declara la ficha y la extensión de superficie quedan «no activado» y D-18 baja a perfil mínimo sin extensiones. AU-02 y AU-06 discrepan en las dos corridas (2 > umbral 1): por sí solo hace fallar M2 audiencia. r2, además, sin nivel para ninguna audiencia, deja de decir que lo que viaja en la app y en el sitio es `publico` (AU-08, AU-11) | Activar la extensión de alcance cuando la descripción del producto declara «sólo lo suyo», con el tipo en el repositorio y el punto de cumplimiento «pendiente: repositorio ajeno»; activar la de superficie cuando hay más de una. Separar el nivel por **pieza** (lo que viaja en el binario y en el sitio es `publico`, siempre) del nivel por audiencia, que puede quedar pendiente |
| K4-02 | P1 | §3.2 D-06 | Sin etiquetas en la semilla, las dos corridas anclan «por SHA» y no proponen una etiqueta anotada por versión publicada, aunque conviven las líneas 2 y 3 | Regla: con versiones publicadas o líneas paralelas, proponer etiqueta anotada por versión y una línea de documentación por versión; «por SHA» sólo para lo que cita otro repositorio |
| K4-03 | P1 | §3.2 D-03, D-05, D-10, D-16 (bloque del sitio) | Repite K-6 de la ronda 3, a medias: con sitio decidido no pide que salga en los idiomas de la ayuda, desde la misma fuente, con su build dentro de la compuerta, ni alojamiento y dominio como pendientes. r1 suma ahí 3 discrepancias | Lista de comprobación del sitio decidido: idiomas, fuente única con la ayuda, build en la compuerta (bloquea), alojamiento y dominio «pendiente» |
| K4-04 | P1 | §3.2 estado «decidida por {actor}» | La regla quedó firme para D-11 (las dos corridas) pero no para D-03: r2 deja «abierta» una H que la ficha da por decidida y pagada | Extender el ejemplo de «decidida por {actor} — citada» a toda H cuya decisión la ficha atribuye a una persona u organismo, con D-03 como segundo ejemplo |
| K4-05 | P1 | §3.2 D-04 y A-11 | No exige que, con una numeración externa de exigencias, cada entrega declare las que cumple (CHANGELOG o RRD). r2 lo omite y no produce A-11 | Agregar la pregunta a D-04 y hacer A-11 obligatorio cuando la ficha impone declarar exigencias por entrega |
| K4-06 | P1 | §3.2 D-08 | El mapeo de un encabezado externo (código, versión, aprobó, fecha) no se pide campo por campo; r2 deja afuera la versión y dice que lo heredado avisa en un proyecto sin heredado | Tabla de mapeo obligatoria: cada campo del encabezado → campo del esquema, campo agregado o cuerpo; con línea de base 0, no hay «heredado que avisa» |
| K4-07 | P1 | §5.7 A-02/A-03 y A-07 | K-8 de la ronda 3, tercera vez: con el vocabulario parametrizado, `todo` de una sola copia da ROJO (autoprueba). M6 pasa sólo con la composición «grupos con la copia, autoprueba con el origen» | Documentar la composición como la forma válida en A-07 y en §8 de A-01, o parametrizar las fixtures |
| K4-08 | P2 | §3.7 y A-09 | `{dir-de-corrida}/_auxiliares/` choca con la carta, que sólo deja escribir en `salida/` (r1 lo anota en §7); r2 cita `salida/_auxiliares/` y los dejó en la corrida. A-09 del curso cae en lugares distintos | Alinear §3.7 con la carta y fijar dónde va el `source.lock` de un repositorio no recibido |

**Fuera del conocimiento.** La carta del aplicador 4 nombra `conocimiento/A-01-ficha-vacia-1.4.md`, que no está en el
directorio (r1, §7 `:178`); el aplicador usó `A-01-ficha-vacia.md`. Es la nota conocida de `F207` §6; no afectó
valores.

## 9. Errores o lagunas del oráculo

- **E-O1.** D-03 (3) «el sitio sale en los dos idiomas» y D-16 (2) «la ayuda y el sitio en español y portugués» piden
  lo mismo: una omisión cuenta dos veces (como E-2 de la ronda 3). En r1 son 2 de sus 5.
- **E-O2.** AU-01 (3) pide «un alcance por productor» en el inventario y AU-06 lo pide como extensión. No está dicho
  si registrarlo como «declarado, no activado» satisface AU-01. El perito lo tomó como sí para AU-01 y como no para
  AU-06.
- **E-O3.** Después de E-2, el build del sitio en la compuerta se evalúa «sólo en D-10». r2 lo escribe en la fila de
  D-03 (`:59`), no en la de D-10. No está dicho si cuenta. El perito lo contó a favor de D-10.
- **E-O4.** T3-2 dice «qué tiene que nombrar A-01», pero no aclara si alcanza con que lo nombre un artefacto (r2 lo
  pone sólo en A-13). El perito lo contó como discrepancia estricta.
- **E-O5.** E-5 lleva a M3 una H decidida que se da por abierta **con un default excluido**. No dice qué pasa en M3 si
  el default es el admitido (r2: D-03 abierta con «Sí»). El perito la contó sólo en M2.

## 10. Comparación con la ronda 3 (`F206`)

| Medida | Ronda 3 r1 | Ronda 3 r2 | Ronda 4 r1 | Ronda 4 r2 |
| --- | --- | --- | --- | --- |
| Validez | ANULADA | ANULADA (medida como diagnóstico) | **VCO** | **VCO** |
| M2 heredadas (umbral 3) | [11] | [8] | 5 (laxa 2) | 8 (laxa 4) |
| M2 audiencia (umbral 1) | [3] | [6] | 2 | 7 (laxa 3) |
| M3 | [no pasa] | [no pasa] | **pasa** | **pasa** |
| M4 / M5 | [0] / [0] | [0] / [0] | 0 / 0 | 0 / 0 |
| M6 | [pasaría] | [pasa] | pasa | pasa |

Lo que cerró la 1.4: **D-11** (K-5, P0 de la ronda 3) ya se asienta «decidida — citada, no versionada» en las dos;
**M3** pasa por primera vez en C3a (AU-09 y AU-10 en §4, sin nivel para el inspector, K-4); **D-15** «Sí» y el
paquete en D-01 en las dos (K-1); todo bloquea desde el primer PR (K-2); el aislamiento de cómputo (validez 2/2).
Lo que sigue abierto: **M2 audiencia** (K-3 de la ronda 3 se convirtió en K4-01: la 1.4 resolvió la jerarquía y el
nivel del inspector, pero su regla de alcance lleva a «no activado»), el bloque del sitio (K-6 → K4-03), la
composición de la compuerta (K-8 → K4-07). C3a sigue sin una corrida que pase.

## 11. Publicación, saneo y barrido

Copiados: `sellado/oraculo-O3-r4.md` y, de cada corrida, `salida/` y `coordinacion/`. Para leer `coordinacion/` se
cambió el modo a 700 y volvió a 000 (comprobado con `stat`). También `M6/`. El saneo conserva el número de líneas y
usa `{area-de-ensayo}`, `{dir-de-trabajo}` y `{privado}`, con la lista precisa del expediente, la del conocimiento y
los nombres de las máquinas del entorno.

| Archivo | Líneas | Huella del original |
| --- | --- | --- |
| `sellado/oraculo-O3-r4.md` | 4 (rutas del área de ensayo y del directorio de trabajo) | `e0ae58f7a199667d3250f2307b39ba9176084b67492ea493d8dd223d7612913e` |
| `corrida-r1/coordinacion/auditoria.md` | 1 (lista de términos del entorno buscados) | `f0cba5d3e114c0ac0141c4bb40352afbbad16ff942fe342b525b05d9eb2a6ef5` |
| `corrida-r2/coordinacion/auditoria.md` | 3 (rutas y lista de términos buscados) | `b6eb21e347974e5c139d87831153478ebafa332f4f3b05ad8d449ab7dd5bf876` |
| `corrida-r1/salida/A-01.md` y su copia en `_auxiliares/montaje/docs/_diseno/` | 1 (`:190`, patrón del barrido 12b) | `c1a67536e955352c335a59d7c9835e06ee1f8e7d7b4d1f11e04e00efbb28c3e5` |
| `corrida-r1/salida/_auxiliares/barrido-12b-salida.txt` | 1 | `7b0c4985f50e52a9922890c3e5443ba9b4f00df7481dcb168688e001aa4e8964` |
| `…/.docs-guard{,-origen}/tools/docs-guard/{arbol.tsv, fixtures/anclas/real-rn-loc-01/source.lock, fixtures/url-fecha/verde/a.md}` (copias heredadas de la compuerta, en las dos corridas y en los montajes de r1) | 1–4 cada uno | `1968067c…`, `4517af64…`, `54b98e0d…` |

`M4/` es del refutador y no se tocó (0 coincidencias).

**Barrido:** `grep -rnoIiEf` con la lista precisa, `grep -rnoIiFf` con la del conocimiento, y rutas de usuario, de
trabajo y nombres de máquinas, sobre toda `evidencia/ronda-4/C3a/`, este informe incluido. Resultado: **0**.

## 12. Lo no verificado

- La CI real de A-07 y A-10, que necesita red y runner.
- Que el repositorio del paquete, el del curso y el del sitio (no recibidos) admitan lo que las fichas proponen.
- Las transcripciones: se toman de las auditorías (M4 y validez); el perito no las releyó.
