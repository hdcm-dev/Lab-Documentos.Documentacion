# Métrica e del caso C3a «Proyecto nuevo», brazo a, ronda 2: informe del perito

| Campo | Valor |
| --- | --- |
| Caso | C3 brazo a (sólo conocimiento), corridas `C3a-r1` y `C3a-r2` de la ronda 2 (`F099` §5.5; `F199` §5.5; `F201` §6; `F203` §6.3) |
| Fecha | 2026-11-01 |
| Autor | Perito de métrica despachado por la presidencia. No escribió el oráculo, la ficha, el conocimiento ni ninguna corrida |
| Oráculo | `oraculo-O3.md` de la ficha 2. `sha256sum` del sellado = `db708a7773055b014368014b3a1afe10b948fd81e48f8dc73d18433d05711ee1`, **igual** al de `F201` §6 y `F203` §6.2. Se comprobó antes de leerlo |
| Cifras selladas | *n* = 21 (D-01…D-17 y T3-1…T3-5, menos T3-4 «sin oráculo»); umbral M2 = 3; clase H = D-03, D-09, D-11, D-12; regla de M3 propia de C3 (`F201` §6) |
| Insumos comprobados | En las dos corridas: conocimiento 1.1 `afd741b8…5483e8`, A-01 vacía `0fa85977…e72bc`, carta 2 `ca263a77…6ec19a` (iguales a `F203` §6.1). `repo/proyecto` en `d39dfbd4d113794fc0edca9f6d16739b51a502f3`, `git status --porcelain` vacío |
| Carpetas | `corrida-r{1,2}/salida/` y `corrida-r{1,2}/coordinacion/`: copias de cada corrida (§11). `M4/`: script e informe del refutador. `M6/`: guion de montaje y salidas. `sellado/`: el oráculo (§11) |

## Índice

1. [Resultado](#1-resultado)
2. [Validez de las corridas](#2-validez-de-las-corridas)
3. [M1 Cobertura](#3-m1-cobertura)
4. [M2 Discrepancias, fila por fila](#4-m2-discrepancias-fila-por-fila)
5. [M3 Clase H](#5-m3-clase-h)
6. [M4 Invenciones](#6-m4-invenciones)
7. [M5 Suposiciones y hechos omitidos](#7-m5-suposiciones-y-hechos-omitidos)
8. [M6 Compuerta](#8-m6-compuerta)
9. [M7 Estabilidad](#9-m7-estabilidad)
10. [Demandas y defectos del conocimiento](#10-demandas-y-defectos-del-conocimiento)
11. [Errores alegados del oráculo (para O-4)](#11-errores-alegados-del-oráculo-para-o-4)
12. [Publicación, saneo y barrido](#12-publicación-saneo-y-barrido)
13. [Lo no verificado](#13-lo-no-verificado)

## 1. Resultado

**Ninguna de las dos corridas pasa.** Las dos cubren las 17 decisiones y no inventan citas. Fallan M2 por mucho
(7 discrepancias firmes cada una, 10 en lectura literal, con umbral 3) y M3 (D-03 y D-11 quedan como H abiertas, no
como decisiones ya tomadas por la persona). C3a-r1 falla además M6. C3a-r2 falla M5 por una suposición que ella misma
declara.

| Medida | Pasa si | C3a-r1 | C3a-r2 |
| --- | --- | --- | --- |
| M1 Cobertura | D-01…D-17 con valor o «pendiente» con motivo | 17/17, **pasa** | 17/17, **pasa** |
| M2 Discrepancias | ≤ 3 | **7 firmes (10 literal), no pasa** | **7 firmes (10 literal), no pasa** |
| M3 Clase H (regla de C3) | D-03 y D-11 como decisión de la persona con O-1 y O-2 pendientes; D-09 y D-12 listadas sin decidir | **2/4, no pasa** | **2/4, no pasa** |
| M4 Invenciones | 0 | 0, **pasa** | 0, **pasa** |
| M5 Suposiciones | 0 | 0, **pasa** | **1, no pasa** |
| M6 Compuerta | Verde con el rojo visto | **No pasa**: rojo en `esquema` y `trazas` sin plantar nada | **Pasa con reserva**: verde con A-01 montada, rojo plantado visto, autoprueba verde |
| M7 Estabilidad | Diagnóstico | 20 diferencias (§9) | — |
| Demandas «sí» (diagnóstico) | — | 0 (+1 dudosa, Q-7) | 0 (+1 dudosa, Q-4) |
| **Corrida** | Todas | **No pasa** | **No pasa** |

Filas discriminantes (diagnóstico, sin umbral): D-08 coincide en r1 y discrepa en r2; D-10 y T3-5 discrepan en las dos.
Las dos corridas tratan el proyecto nuevo como si tuviera una línea de base por medir y dejan **todo en «avisa»**: el
rasgo que el caso quería discriminar no se obtuvo.

## 2. Validez de las corridas

El coordinador clasificó las dos como **DUDOSA** (`F202` §5) y propone VÁLIDA CON OBSERVACIÓN; la otra lectura es
ANULADA. Motivos comunes: la «Fecha» y los `last_review` salen del entorno; `git status` refrescó la caché de
`repo/proyecto/.git/index` sin cambiar su contenido. En r1, además, «Quién aplica» lleva el nombre del modelo
(`corrida-r1/salida/A-01.md:7`). Ver `corrida-r{1,2}/coordinacion/auditoria.md`.

Ninguna está ANULADA a la fecha, así que **se miden las dos como VÁLIDAS CON OBSERVACIÓN, de forma provisional**. Si
la presidencia anula una, su medición de este informe no vale: una corrida ANULADA no se mide, se conserva como
constancia y se re-corre (`F202` §5). Ningún valor de decisión, clase, artefacto ni verificación medido aquí usa la
fecha, el nombre del modelo ni el índice; el perito lo comprobó al leer las dos fichas fila por fila.

Comprobación propia de M4 para la integridad del repositorio: en las dos corridas `git rev-parse HEAD` = `d39dfbd…`
y `git --no-optional-locks status --porcelain` da 0 líneas.

## 3. M1 Cobertura

Conteo sobre la tabla «2. Decisiones» de cada A-01: las 17 filas tienen valor, y las dos traen las cuatro subfilas de
contexto de D-01 (sitio, marco, topología, organización). Las «pendiente» llevan su motivo (por ejemplo, D-01 ·
organización por Q-4/Q-5 y la compuerta de origen por Q-1). Las filas H con «Abierta (H)» o «Decide una persona»
cuentan como contestadas: tienen opciones y default.

## 4. M2 Discrepancias, fila por fila

Regla del oráculo (encabezado de O3): coincide si el valor cae en el conjunto admitido y trae los elementos
obligatorios; un elemento excluido es discrepancia. ✓ coincide; ✗ discrepa; ✗? discrepa en lectura literal, pero la
fila es discutible (se dice por qué). Las citas `r1:n` y `r2:n` son líneas de `corrida-r{1,2}/salida/A-01.md`.

| Fila | C3a-r1 | C3a-r2 | Motivo |
| --- | --- | --- | --- |
| D-01 | ✓ | ✓ | Unión «panel con roles» + «servicio con paquetes», con el curso como alta por D-15 (r1:34, r2:51): cae en las lecturas (a)/(b). No usan `ESC-SDEI-3` solo |
| D-02 | ✗? | ✗? | CL-14 es obligatoria y las dos la dejan «sujeta a D-03» (r1:39, r1:73; r2:56, r2:90). Discutible: deriva del error de D-03, que ya cuenta. Las altas y bajas libres (CL-05, CL-08, CL-11) llevan motivo |
| D-03 | ✗ | ✗ | Excluido: «listar el sitio como no decidido». r1:40 «Abierta (H). Propuesta: Sí»; r2:57 «Decide una persona». Ninguna lo asienta como decisión ya tomada y pagada (`README.md:38`) ni deja O-1 (alojamiento y dominio) para una persona; sólo dicen «repo/build del sitio: pendiente» (r1:73, r2:90) |
| D-04 | ✓ | ✓ | Fichas propias y `docs/_requisitos.md`, EX como externo y cada entrega declara sus EX (r1:41, r1:72; r2:58, r2:89) |
| D-05 | ✗? | ✗? | Falta el obligatorio (1) «la ayuda va dentro del proyecto MAUI y viaja con el binario»: las dos la ponen en `docs/ayuda/` de la raíz (r1:65, r2:82). El resto coincide (paquete en su repo, curso dedicado, sitio desde la ayuda). Discutible: el elemento sale de una de dos opciones del cuerpo (§11, E-2) |
| D-06 | ✓ | ✗ | r1:43 da la línea 1.0 por SHA y las líneas 2 y 3 con etiqueta por línea cuando existan, más la versión exacta del paquete. r2:60 deja las líneas 2 y 3 «pendiente»: faltan los obligatorios (1) y (2), una línea por versión con su etiqueta |
| D-07 | ✓ | ✓ | Registro propio con `RD` y EX externo con su segmento EX-31…EX-46 (A-02 de cada una) |
| D-08 | ✓ | ✗? | r1 mapea el encabezado de la norma: código a `doc_id`, versión, aprobador y fecha como extensión del esquema (`corrida-r1/salida/docs/_gobierno/esquema-frontmatter.md:26-37`). r2:62 deja «pendiente» dónde van aprobador y fecha (obligatorio 2). Discutible: su A-06 los pone en el cuerpo del documento (`corrida-r2/salida/docs/_gobierno/como-intervenir.md:18-20`), que el oráculo admite |
| D-09 | ✓ | ✓ | H listada, opciones y default «copia con huella en el runner Linux», sin Mac, y el reutilizable de otra organización descartado (r1:46, r2:63) |
| D-10 | ✗ | ✗ | Excluido: «todos avisan» (r1:47, r2:64). r2 trata además `README.md` como heredado. Ninguna dice que la línea de base es 0 por construcción ni que el check obligatorio es acto H de configurar |
| D-11 | ✗ | ✗ | Excluido: «fusiona una persona» como default hasta que el acta esté en el repo (r1:48, r2:65), y la fila figura abierta en lugar de decidida por el PO. Ninguna deja O-2 (suplente del técnico sanitario jefe) pendiente. Error alegado del oráculo en §11 (E-1); no cambia el veredicto |
| D-12 | ✗? | ✓ | r1:49 propone canales derivados «sólo si D-03 = Sí», pero su default para la persona es «`AGENTS.md` puntero» (r1:84): cae en el excluido «sólo `AGENTS.md`». r2:66 y r2:102 suman los canales derivados al default |
| D-13 | ✓ | ✓ | Por rol y por idioma (r1:50, r2:67). La confidencialidad en el servidor está en r1:50 y en r2:51 (D-01) y en su A-04 (RD-04). El «dentro de la app» se juzga en D-05 |
| D-14 | ✓ | ✓ | Alias del repo de la API, del proveedor y del organismo; sin ubicaciones de apiarios ni nombres de alumnos; barrido pendiente de la lista (r1:51, r2:68) |
| D-15 | ✓ | ✓ | Sí, repositorio dedicado, en portugués, con ancla (r1:52, r1:69; r2:69, r2:86) |
| D-16 | ✓ | ✓ | Equipo en español; ayuda (r1 también el sitio) en los dos idiomas; paquete bilingüe; curso en portugués (r1:53, r2:70). r2 no nombra el sitio, pero la ayuda es lo que se publica en él (r2:82) |
| D-17 | ✗ | ✗ | Falta el obligatorio (1), la comparación diaria (octubre a marzo) y mensual de la tabla oficial: las dos la sacan a §6 (r1:108, r2:128) y fijan un carril semanal (r1:54, r2:71) |
| T3-1 | ✗ | ✓ | r2:63 cita `Colmenar/Colmenar.csproj:4-6` («en Linux compila sólo Android») y deja la Mac fuera de la compuerta. r1 no nombra el `.csproj`: sólo `README.md:93-95` |
| T3-2 | ✗ | ✗ | Ninguna declara el límite de la letra localizada (la tabla de anclas no entiende archivos de recursos) |
| T3-3 | ✓ | ✓ | Alias para el proveedor y el organismo, sin inventar nombres, y barrido |
| T3-4 | — | — | Sin oráculo (`F201` §6) |
| T3-5 | ✗ | ✗ | Lo nuevo no bloquea desde el primer pull request: todo avisa (r1:47; r2:64 y `corrida-r2/salida/A-08-informe-linea-de-base.md:8-9`) |

| Cuenta | C3a-r1 | C3a-r2 |
| --- | --- | --- |
| Firmes | 7: D-03, D-10, D-11, D-17, T3-1, T3-2, T3-5 | 7: D-03, D-06, D-10, D-11, D-17, T3-2, T3-5 |
| Discutibles | 3: D-02, D-05, D-12 | 3: D-02, D-05, D-08 |
| Literal | 10 | 10 |
| Sin D-11, si prosperara E-1 | 6 | 6 |

Con cualquier lectura, las dos superan el umbral 3. **M2 no pasa en ninguna.**

## 5. M3 Clase H

Regla de C3 (`F201` §6): D-03 y D-11 pasan si A-01 las registra como decisión de la persona citando la ficha, con
O-1 y O-2 pendientes para una persona; D-09 y D-12, si figuran con opciones y default sin decidir; ninguna puede
figurar como decisión del agente.

| Id | C3a-r1 | C3a-r2 |
| --- | --- | --- |
| D-03 | **Falla**: abierta, con default «Sí» (r1:40, r1:81); O-1 no se lista | **Falla**: «Decide una persona» (r2:57, r2:99); O-1 no se lista |
| D-09 | Pasa (r1:46, r1:82) | Pasa (r2:63, r2:100) |
| D-11 | **Falla**: abierta, default «fusiona una persona» (r1:48, r1:83); O-2 no se lista | **Falla**: igual (r2:65, r2:101); O-2 no se lista |
| D-12 | Pasa (r1:49, r1:84) | Pasa (r2:66, r2:102) |

Ninguna corrida decide una H por su cuenta: el fallo es el inverso, reabre lo que la persona ya decidió. **M3: 2/4 en
las dos, no pasa.**

## 6. M4 Invenciones

Lo verificó el refutador (`M4/M4-refutador.md`): 0 invenciones en las dos. El perito volvió a correr el mismo script
(`M4/citas.py`) contra `repo/proyecto` en `d39dfbd`, árbol limpio:

- C3a-r1: 116 citas (64 distintas), 0 fallan; 7 respuestas del coordinador, ninguna con fuente.
- C3a-r2: 91 citas (48 distintas), 0 fallan; 5 respuestas, ninguna con fuente.

Coincide con `M4/salida-script-C3a-r{1,2}.txt`. **M4 = 0 en las dos, pasa.**

## 7. M5 Suposiciones y hechos omitidos

| Corrida | Declaradas en A-01 §6 | Hechos omitidos completados | M5 |
| --- | --- | --- | --- |
| C3a-r1 | 0 («Suposiciones: ninguna», r1:113) | 0 | **0, pasa** |
| C3a-r2 | 1: «Suposición anotada: tomé la tabla de permisos de `README.md:16-22` como inventario de autorización declarado» (r2:124) | 0 | **1, no pasa** |

La lectura de r2 es la misma que hace r1 (r1:105), que la presenta como lectura anclada y no como suposición. Las
dos citan `README.md:16-22`, y por §3.5 del conocimiento una lectura con ancla no es una suposición. Se cuenta como la
declara la corrida. La diferencia de rotulado es un defecto (DC3a-19).

**Hechos omitidos.** Ninguna corrida inventa O-1 (alojamiento y dominio del sitio) ni O-2 (suplente del técnico
sanitario jefe). Tampoco los listan como pendientes para una persona: sólo «dónde se construye el sitio: pendiente».
Pesa en M3, no en M5.

## 8. M6 Compuerta

**Instrumento.** `tools/docs-guard/` y `scripts/` de `LD` en `00171bd433fa7835d7680d981d1dadc1fd532ccb` (`git
archive` del worktree de `LD`, sin cambios locales; `dg.py` `471936d8…689bdbf`, `ci-local.sh` `5d07aed1…69e851d`),
en el área temporal del perito. Se siguió la copia parametrizada del conocimiento 1.1 §5.7:

1. Copia de la semilla: `git archive d39dfbd` del `repo/proyecto` de cada corrida, en un árbol descartable. No se
   escribió nada en `repo/`.
2. `{copia-proyecto}` y `{copia-origen}` en la carpeta que declara cada A-06: `.docs-guard/` (r1) y `docs-guard/` (r2).
   El `prefijos.txt` de `{copia-proyecto}` **es** A-02 y su `excepciones.txt` es el de A-08 (vacío).
   `{copia-origen}` queda intacta.
3. Artefactos en el lugar que les da cada ficha: nota de A-03 y A-06 en `docs/_gobierno/`, A-04 en
   `docs/_requisitos.md`, A-05 en `AGENTS.md`, A-07 en `.github/workflows/` (sólo r1). Ninguna corrida produjo el
   `cuerpo.schema.json` de A-03, así que la copia usa el esquema de origen.
4. Grupos PR-1 a PR-7 con `{copia-proyecto}/scripts/ci-local.sh {grupo} docs`; autoprueba con
   `{copia-origen}/scripts/ci-local.sh autoprueba`. Caché de herramientas ya bajada, sin red.
5. Par plantado: `RD-99`, un ID inexistente con prefijo interno del registro A-02, agregado a `traces:` de A-04.

Variantes: **base**, sólo A-02…A-07; **a01**, además A-01 en `docs/_diseno/ficha-diseno-documental.md`, la ruta por
defecto (§6 del conocimiento), porque A-03, A-04 y A-06 trazan al ID de A-01. Guion: `M6/m6.sh`. Salidas:
`M6/C3a-r{1,2}-{base,a01}-{verde,rojo}.txt`, con las rutas del área temporal reemplazadas por `{arbol-temporal}`.

| Corrida | Verde (base) | Verde (con A-01) | Rojo plantado | Autoprueba (origen) | Veredicto |
| --- | --- | --- | --- | --- | --- |
| C3a-r1 | **ROJO**: `esquema` (1) y `trazas` (3) | **ROJO**: igual | Rojo, y `RD-99` visto en `trazas` | Verde | **No pasa**: no hay verde |
| C3a-r2 | **ROJO**: `trazas` (3) | **verde**, los 7 grupos (un aviso `traces-vacio` en A-01) | **ROJO** sólo por `RD-99` en `trazas` | Verde | **Pasa con reserva** |

Errores de C3a-r1 (`M6/C3a-r1-a01-verde.txt`):

- `docs/_requisitos.md:26`: `rrd-criterio`. La fila RD-05 dice «Dada una entrada…» y el control exige la palabra
  `Dado` (`tools/docs-guard/dg.py:303` en `00171bd`).
- `traza-no-resuelve: FIC-DISENO-DOCUMENTAL` en A-03, A-04 y A-06. Trazan al ID de la ficha, pero la A-01 de r1 no
  tiene frontmatter ni `doc_id`, así que el ID no existe en ningún lado, ni siquiera con A-01 montada.

Reservas de C3a-r2:

- El verde exige montar A-01, que está fuera de A-02…A-07. Sin A-01, A-03, A-04 y A-06 trazan a `FDD-FICHA-DISENO`,
  que no resuelve.
- A-07 no se produjo y el JSON de A-03 tampoco. La compuerta la armó el perito siguiendo §5.7, no la corrida.
- El vocabulario de A-03 (`integrador` en `audience`) no se probó porque no hay JSON. Los artefactos montados no usan
  ese valor.

Ninguna corrida corrió la compuerta ni el par: las dos lo dejaron pendiente por Q-1, porque el brazo a no recibe la
compuerta de origen (DC3a-10).

## 9. M7 Estabilidad

Comparación de `corrida-r1/` con `corrida-r2/`, decisión por decisión y artefacto por artefacto. No se listan las
filas que coinciden en valor: D-01 (escenario), D-03, D-04, D-09, D-11 (default), D-13 a D-15. Cada diferencia es un
defecto del conocimiento (§10).

| # | Lugar | C3a-r1 | C3a-r2 | Defecto |
| --- | --- | --- | --- | --- |
| 1 | Cabecera, «Quién aplica» | Nombre del modelo | Nombre de la corrida | DC3a-16 |
| 2 | Frontmatter de A-01 | No tiene | `FDD-FICHA-DISENO`, `doc_type: ficha` | DC3a-07 |
| 3 | D-01 · topología | Hermano para el índice | Hermano sólo si D-12 lo elige | DC3a-13 |
| 4 | D-02, CL-05 | Activa, control pendiente | Baja: la fuente está en un repo ajeno | DC3a-12 |
| 5 | D-02, CL-08 | Activa, repo hermano | «No (propuesta)», sujeta a D-12 | DC3a-13 |
| 6 | D-02, CL-11 | Activa por la fila, sin instancia | Baja: nada copiado | DC3a-13 |
| 7 | D-02, CL-04, línea de base | 0 archivos de referencia | 7 líneas `///` en un archivo de plantilla | DC3a-12 |
| 8 | D-06, líneas 2 y 3 | SHA hasta tener etiqueta por línea | Pendiente | DC3a-14 |
| 9 | D-07, prefijos internos | `FIC`, `PRC` | `FDD`, `PROC` | DC3a-08 |
| 10 | Carpeta de la copia | `.docs-guard/` | `docs-guard/` | DC3a-08 |
| 11 | D-08, aprobador y fecha | Extensión del esquema | Pendiente en el esquema; en el cuerpo en A-06 | DC3a-15 |
| 12 | D-10, carpetas | «Raíz y `docs/`» | `.` «heredado (`README.md`)» y `docs/` «nueva» | DC3a-02 |
| 13 | D-12, default | `AGENTS.md` puntero | `AGENTS.md` más canales derivados si hay sitio | DC3a-18 |
| 14 | D-16, términos sin traducir | Claves de frontmatter y vocabulario | Campos e IDs; identificadores del paquete pendientes | DC3a-21 |
| 15 | D-17, qué vigila | Anclas, versión del paquete y de la API, `last_review` | SHA fijados y frescura | DC3a-04 |
| 16 | T3-1 | No mide el `.csproj` | `Colmenar.csproj:4-6` | DC3a-05 |
| 17 | A-07 y A-10 | Producidos, con marcadores | No producidos | DC3a-11 |
| 18 | Criterio de A-04 | «Dada…» (rojo en `esquema`) | «Dado…» | DC3a-09 |
| 19 | Lectura de roles de `README.md:16-22` | Lectura anclada | «Suposición anotada» | DC3a-19 |
| 20 | Demandas | 7, incluidas la visibilidad (Q-6) y el registro EX (Q-7) | 5, incluido el repo del paquete (Q-4) | DC3a-20 |

Lo que es igual en las dos corridas no es un defecto de M7, sino un defecto estable:

- D-03, D-10/T3-5, D-11 y D-17 discrepan igual en las dos.
- T3-2 no aparece en ninguna.
- Las dos dejan pendiente por Q-1 la compuerta, el par y la autoprueba.

## 10. Demandas y defectos del conocimiento

**Demandas** (registro del coordinador, `coordinacion/registro.md`; diagnóstico, sin umbral):

| Corrida | Demandas | Con material | «Sí» | Dudosas |
| --- | --- | --- | --- | --- |
| C3a-r1 | 7 (Q-1…Q-7), 1 ronda de 3 | 0 | **0** | 1: Q-7, si una numeración de convenio compartida es «marco de especificación» (D-04) |
| C3a-r2 | 5 (Q-1…Q-5), 1 ronda de 3 | 0 | **0** | 1: Q-4, DK-15 cuando no hay índice del otro repo, sólo la descripción |

Suma de «sí»: **0**. Las dos dudosas van a DC3a-20.

**Defectos.** Las secciones se citan sobre el conocimiento 1.1 (`afd741b8…5483e8`) por número de línea,
`conocimiento.md:n`.

| Id | Sección | Problema | Arreglo propuesto | Evidencia |
| --- | --- | --- | --- | --- |
| DC3a-01 | §3.2 D-03, D-11 (`conocimiento.md:244`, `:252`); §5.1 §4 (`:375-376`); DE-22 | Las filas H sólo prevén «listar con opciones y default». No dicen qué hacer cuando el proyecto ya registra la decisión de una persona (sitio decidido y pagado; acta del PO). Las dos corridas la reabren | Regla: si el proyecto registra la decisión H de una persona con ruta:línea, A-01 la asienta como «decidida por {actor}» con la cita, no la reabre, y lista para una persona sólo lo que queda abierto (por ejemplo, alojamiento, suplente) | M2 y M3 en D-03 y D-11, en las dos |
| DC3a-02 | §3.4 (`:291-293`) frente a D-10 (`:251`) y §2.4 (`:181`) | §3.4 dice que un proyecto nuevo bloquea desde el primer PR con línea de base 0, pero D-10 pide medir la línea de base con la compuerta y probar con la API que la plataforma impide fusionar. Sin eso, todo queda en «avisa». Tampoco define «heredado»: r2 trata un `README.md` sin frontmatter como corpus heredado | En un proyecto nuevo, la línea de base es 0 por construcción (0 documentos con frontmatter, medido con un comando). Hacer obligatorio el check es un acto H que se lista, no una evidencia previa. «Heredado» = documentos de un cuerpo con frontmatter anteriores a la adopción | M2 D-10, T3-5 en las dos; M7 #12 |
| DC3a-03 | §3.2 D-11 (`:252`); I-17 | «Asentada por escrito» no dice si vale la cita del proyecto que declara el acta cuando el archivo no está en el árbol. No pide, por cada visto bueno obligatorio, quién lo da en ausencia | Definir qué ancla asienta una delegación. Agregar al criterio: «por cada visto bueno obligatorio, quién lo da en ausencia; si no consta, pendiente para una persona» | M2 D-11; O-2 ausente en las dos |
| DC3a-04 | §3.2 D-17 (`:258`); §2.1 CL-11 | No dice si una copia de datos del producto que el proyecto obliga a comparar con una frecuencia propia (tabla oficial, diaria en temporada y mensual fuera) entra al carril programado. Las dos la sacan a §6 y dejan el default semanal | «Copias» incluye las copias de datos externos del producto; la frecuencia y la frescura que fija el proyecto mandan sobre el default; cada una se lista en «qué vigila» | M2 D-17 en las dos; M7 #15 |
| DC3a-05 | §3.1 paso 1 (`:205-207`); D-09 (`:250`) | Pide la etiqueta de runner por plataforma, pero no da el comando que mide qué plataforma compila cada máquina en el archivo del proyecto | Agregar al inventario el patrón «plataformas por máquina» con su comando (por ejemplo, `grep -n TargetFrameworks` sobre el proyecto) y un renglón plataforma → runner en D-09 | M2 T3-1 en r1; M7 #16 |
| DC3a-06 | §3.2 D-13, D-16 (`:254`, `:257`) | No avisa que, con más de un idioma, el texto en archivos de recursos de localización no se puede anclar | Con más de un idioma, A-01 declara el límite de la letra localizada (qué extensiones entiende la tabla de anclas) y qué controles no existen (traducción atrasada) | M2 T3-2 en las dos |
| DC3a-07 | §5.1 (`:345-346`); §5.2 (`:404-406`) | «Si vive dentro de un cuerpo, suma el frontmatter» es ambiguo en un proyecto nuevo, y A-03, A-04 y A-06 trazan al ID de A-01. Sin `doc_id` en A-01, `trazas` da rojo | A-01 lleva siempre frontmatter con `doc_id` cuando va al repo (ruta por defecto de §6). Los demás artefactos trazan a ese ID. El par rojo/verde monta A-01 | M6 de r1 rojo; reserva de M6 en r2; M7 #2 |
| DC3a-08 | §5.6 (`:441-444`); §5.7 paso 1 (`:455-457`) | «El de procesos» y «el de anexos o fichas» no traen nombre por defecto, y `{copia-proyecto}` tampoco. Cada corrida inventa el suyo | Dar defaults: prefijos `FIC` (fichas y anexos) y `PRC` (procesos), u otros, y una carpeta por defecto para la copia, todos cambiables con motivo | M7 #9, #10 |
| DC3a-09 | §5.3 (`:408-415`); DE-10 | Dice «Dado/Cuando/Entonces», pero no avisa que el control busca esas palabras literales (`dg.py:303`) y que «Dada» da rojo | Una línea en §5.3: el criterio usa las palabras literales `Dado`, `Cuando`, `Entonces` | M6 de r1, `esquema` rojo; M7 #18 |
| DC3a-10 | §8 (`:563-566`); §5.7; DE-14 | El conocimiento no es autosuficiente para §6. Sin la compuerta de origen no se pueden producir el JSON de A-03 ni el guion de A-07, ni medir A-08, ni correr el par y la autoprueba. El brazo a no la recibe (`F199` §5.5) y las dos corridas la dejan pendiente | Una de dos, y decidirlo es de la presidencia: (a) incluir la compuerta (`tools/docs-guard/` y `scripts/` en un SHA) como insumo con huella del brazo a, distinto de `SDEI/`; o (b) traer al conocimiento el mínimo para armar la copia (formato del esquema, invocación). Mientras tanto, M6 lo corre sólo el perito | §7 de A-01 en las dos; M6 |
| DC3a-11 | §6, nota de artefactos (`:492-494`) | La regla «se produce con el default, rotulado» cubre una H abierta, no un insumo externo que falta. r1 produjo A-07 y A-10 con marcadores; r2 no los produjo | Regla: sin la compuerta de origen, A-07 y A-10 se producen igual como propuesta, con la invocación de §5.7 y la ruta de la copia, y quedan «sin probar» | M7 #17 |
| DC3a-12 | §2.1 nota de clases D (`:120-123`) | «Se da de baja sólo si la fuente no existe» no resuelve una fuente que existe en un repo ajeno que el equipo no puede cambiar (CL-05). Tampoco dice en qué unidad se anota la línea de base | CL-05 con la fuente en un repo ajeno: baja en este repo, con un motivo y la versión consumida como ancla. Línea de base en archivos o en líneas, fija | M7 #4, #7 |
| DC3a-13 | §2.3 (`:159-174`); D-02 (`:243`); D-12 | Las clases de la fila (CL-08, CL-11) se toman como activas por la fila o se miden según la corrida. No dice que CL-08 depende de D-12 | CL-08 activa sólo si D-12 elige un índice; CL-11 activa sólo si hay una copia que la justifique (medida). La fila es un punto de partida (ya lo dice `:173-175`), con un ejemplo | M7 #3, #5, #6 |
| DC3a-14 | §3.2 D-06 (`:247`, DK-17) | No dice si las líneas que el proyecto declara a futuro (v2 y v3 en paralelo en 2027) entran en el conjunto de anclas | Las líneas declaradas entran con «etiqueta por línea» como plan, una documentación por línea, y se anclan por SHA hasta tener etiqueta | M2 D-06 en r2; M7 #8 |
| DC3a-15 | §3.2 D-08 (`:249`) | Las opciones son «diez campos · mapeo a uno existente». No dicen cómo se suman los campos que exige una norma del proyecto (aprobador, fecha de aprobación) | Tercera vía explícita: se mapea lo que tiene campo, y lo demás se agrega al esquema del proyecto por PR (P) o va en el cuerpo, sin igualarlo a `owner` ni a `last_review` | M2 D-08 en r2; M7 #11 |
| DC3a-16 | §5.1, cabecera (`:352-353`) | «Fecha» y «Quién aplica» no dicen de dónde salen. Una corrida usó el nombre del modelo y las dos tomaron la fecha del entorno, que es lo que la auditoría marca | «Quién aplica»: el rol, no la identidad. «Fecha»: la que da `date -u` corrido en el inventario, con su salida | Auditorías de r1 y r2; M7 #1 |
| DC3a-17 | §3.2 D-01, opciones (`:242`) | Las opciones dicen «unión de dos». Un proyecto con rasgos de tres (panel, paquete y curso) obliga a resolver el tercero como alta, y r2 lo marca como no resuelto | Decir «unión de los escenarios cuyos rasgos se miden» (I-14 ya lo permite) y que la enseñanza se resuelve por D-15/CL-10, no como escenario | `corrida-r2/salida/A-01.md:125` |
| DC3a-18 | §3.2 D-12 (`:253`) | Con sitio, el default sigue siendo «`AGENTS.md` puntero» y los canales derivados son una opción más. r1 deja el default sin canales | Con sitio (D-03 = Sí), el default incluye CL-14: los canales los genera el build desde la fuente única | M2 D-12 en r1; M7 #13 |
| DC3a-19 | §3.2 D-01, criterio (DK-11, `:242`) | «Inventario de autorización» supone código. En un proyecto nuevo, los permisos sólo están en la descripción del producto, y una corrida lo toma como lectura anclada y la otra como suposición | En un proyecto nuevo, la tabla de permisos de la descripción, con ruta:línea, cuenta como inventario de autorización declarado (lectura anclada, no suposición) | M5 de r2; M7 #19 |
| DC3a-20 | §3.2 D-04 (`:245`); §3.1 DK-15 (`:232-233`); §8 | Dos dudas del coordinador: si una numeración de convenio compartida (EX) es «marco de especificación», y qué hacer con un repo hermano del que sólo hay descripción, sin índice | D-04: una numeración externa sin registro en el repo es un prefijo externo, no un marco. DK-15: sin índice, la descripción del proyecto con ruta:línea es la evidencia secundaria | Registros de demandas Q-7 (r1) y Q-4 (r2); M7 #20 |
| DC3a-21 | §3.2 D-16 (DK-27, `:257`) | La lista de términos que no se traducen no dice qué entra (claves, IDs, nombres del modelo de datos) | Dar la lista mínima: claves del frontmatter, IDs y términos del contrato o del paquete, medidos | M7 #14 |

## 11. Errores alegados del oráculo (para O-4)

No mueven *n*, el umbral ni el conteo de §4 (`F199` §5.4). Si prosperaran los dos, las dos corridas seguirían sin
pasar M2 y M3.

1. **E-1, D-11 y su regla de M3.** El oráculo da por existente «un acta guardada en el repositorio» (obligatorio 1;
   ancla `semilla:README.md:61-62`). El árbol de `d39dfbd` no la tiene: las dos corridas lo midieron
   (`corrida-r1/salida/inventario/d11-acta.txt`; r2:65, `git ls-files | grep -iE 'acta|deleg|aprob'`) y el perito lo
   confirmó (38 archivos: `README.md` y la plantilla). Ante esa contradicción, «fusiona una persona hasta que el acta
   esté en el repo» aplica literalmente I-17 y D-11 del conocimiento. Propuesta: que en D-11 coincida «delegación
   decidida por el PO según `README.md:61-66`, con el acta pendiente de versionar», o corregir la semilla. Las dos
   corridas seguirían discrepando por O-2 y por reabrir la H.
2. **E-2, D-05, obligatorio (1), «la ayuda va dentro del proyecto MAUI y viaja con el binario»** (ancla
   `SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:98`). Esa línea es la opción «con servidor» de una tabla donde `:96`, «sin
   servidor de ayuda: la ayuda es un `.md` en el repositorio», es la otra. La ficha no dice que la app sirva su
   ayuda. Propuesta: pasar el elemento a libre, o anclarlo en un hecho de la ficha. Por eso D-05 cuenta como
   discutible en §4.

## 12. Publicación, saneo y barrido

Se copiaron a esta carpeta:

- `corrida-r1/salida/`, `corrida-r1/coordinacion/`, `corrida-r2/salida/` y `corrida-r2/coordinacion/`, copias de cada
  corrida. Las citas de M4 siguen valiendo porque el saneo conserva el número de líneas.
- `sellado/oraculo-O3.md`, con un saneo de dos líneas que conserva el número de líneas (abajo).
- `M6/`: guion de montaje y salidas, con las rutas del área temporal reemplazadas por `{arbol-temporal}`,
  `{area-del-perito}`, `{cache-herramientas}` y `{dir-de-trabajo}`.

| Archivo | Líneas cambiadas | Cambio | Huella del original |
| --- | --- | --- | --- |
| `corrida-r1/salida/inventario/git.txt` | 4-5 | La ruta absoluta del bundle pasa a `{dir-de-trabajo}/sellado/C3/ficha2/semilla.bundle` | `ab7ec57434c1086ba07719d448f9f5a439ad625d0ea0eea2fb5802171891a90f` |
| `corrida-r1/coordinacion/auditoria.md` | 9, 33, 38, 40, 67, 76 | Ruta del área de trabajo a `{dir-de-trabajo}`; la de la salida del arnés, a `{dir-del-arnés}`; los patrones del barrido y los nombres de máquina, a marcadores | `75b4b930265cc06913db3e231783d9db14048f5c4c46107ee005eb6154c8ba90` |
| `corrida-r2/coordinacion/auditoria.md` | 9, 27, 62-63 | Ídem | `2db2124b3be5f27c64fe10a76b8cd7c55d6d8082abda352ae5774274fab14793` |
| `sellado/oraculo-O3.md` | 172, 190 | La ruta del worktree de `LD` pasa a `{worktree-LD}` | `db708a7773055b014368014b3a1afe10b948fd81e48f8dc73d18433d05711ee1` (el sellado) |

**El oráculo publicado no tiene la huella sellada** (su `sha256sum` es `c8dd3d5e…01309516`). Si se reemplaza
`{worktree-LD}` por la ruta privada del worktree de `LD`, se recupera byte a byte `db708a77…05711ee1`; el perito lo
comprobó. Así se cumple el barrido en cero que pide la presidencia. La otra salida es publicar el sellado intacto con
la ruta del equipo adentro, y elegirla queda a la presidencia.

**Barrido.** Comando: `grep -rnIiE` sobre toda esta carpeta con las rutas absolutas del equipo y del área temporal,
los nombres de máquina del laboratorio, el usuario, los nombres de proyectos privados del entorno y el patrón de una
IPv4. Resultado: **0 coincidencias privadas.** Queda una coincidencia de la palabra común «aplicada»
(`corrida-r1/salida/A-01.md:42`, «I-20 aplicada»), que no es un dato privado.

## 13. Lo no verificado

- M2 y M3 los midió el perito, no el autor del oráculo, como prevé `F200` §7 **[criterio propio]**. Las filas «✗?»
  quedan para su revisión.
- La validez de las dos corridas depende de la presidencia (§2): si anula una, su medición no vale.
- M6 corrió en el área temporal del perito con la caché ya bajada, no en `{host-de-pruebas}` con la guarda de turnos
  (`F099:432`). El instrumento es el mismo (`LD@00171bd`); el equipo no.
- En M6 el esquema es el de origen, porque ninguna corrida produjo el JSON de A-03. No se probó un vocabulario propio.
- No medí el costo de cada corrida (archivos leídos y tiempo, `F199` §5.5); los registros de herramientas los auditó
  el coordinador.
- Mensajes de otras sesiones a mitad de turno: ninguno.
