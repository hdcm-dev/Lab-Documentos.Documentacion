# Métrica e del caso C3a «Colmenar, proyecto nuevo (ficha 2)», ronda 3 (brazo B): informe del perito

| Campo | Valor |
| --- | --- |
| Caso | C3a, ronda 3, brazo B (conocimiento 1.3), corridas `C3a-r1` y `C3a-r2` (`F205`; `F399` §5.5 y paso 6) |
| Fecha | 2026-11-02 |
| Autor | Perito de métrica. No escribió el oráculo, el conocimiento ni las cartas; no corrió ni coordinó ninguna corrida |
| Oráculo | `sellado/oraculo-O3-r3.md`. `sha256sum` del sellado = `84ba6248c01fc3d7ea64ceaf6541f1c4d227ecaa3e110670beb94a760035f8c3`, **igual** a `F205` §3. Se comprobó antes de leerlo. La copia publicada está saneada (§10) |
| Cifras selladas | Heredadas: *n* = 21, umbral 3, H = D-03, D-09, D-11, D-12 (D-01 sólo en la lectura c). Audiencia: *n* = 12, umbral 1, H = AU-09, AU-10 (AU-05 sólo si se propone jerarquía) |
| M4 | Contra la semilla `d39dfbd` (refutador, `M4/`) |
| Evidencia | `corrida-r{1,2}/salida/`, `corrida-r{1,2}/coordinacion/`, `M4/` (refutador), `M6/` (salidas de la compuerta), `sellado/` |

## 1. Resultado

**Ninguna corrida pasa. C3a responde «no».** C3a-r1 está ANULADA según su auditoría y no se mide; su columna es
diagnóstico bajo la segunda lectura (VÁLIDA CON OBSERVACIÓN), por si la presidencia la toma. C3a-r2 es DUDOSA: se
mide bajo VÁLIDA CON OBSERVACIÓN. Si la presidencia la anula, tampoco se mide y el resultado del caso no cambia.

| Medida | Pasa si | C3a-r1 (diagnóstico) | C3a-r2 |
| --- | --- | --- | --- |
| Validez | — | ANULADA (2.ª lectura: VÁLIDA CON OBSERVACIÓN) | DUDOSA; medida como VÁLIDA CON OBSERVACIÓN |
| M1 Cobertura | D-01…D-18 con valor o «pendiente» con motivo | 18/18, pasaría | 18/18, **pasa** |
| M2 heredadas | ≤ 3 de 21 | 11, no pasaría | **8, no pasa** (5 con la lectura más laxa) |
| M2 audiencia | ≤ 1 de 12 | 3, no pasaría | **6, no pasa** |
| M3 Clase H | Las seis fijas en §4, ninguna decidida por el agente | No pasaría: faltan AU-09 y AU-10 | **No pasa**: falta AU-10 en §4 y el inspector recibe nivel `restringido` |
| M4 Invenciones | 0 | 0 (refutador; no cuenta) | **0, pasa** |
| M5 Suposiciones | 0 | 0 | **0, pasa** |
| M6 Compuerta | Verde, con el rojo visto | Pasaría (composición del proyecto) | **Pasa** con la composición del proyecto; `compuerta/` sin parametrizar da ROJO (§6) |
| M7 Estabilidad | Diagnóstico | — | 12 diferencias (§7) |
| **Corrida** | Todas | **ANULADA** | **No pasa** |

Demandas: 0 en las dos corridas (no hay `salida/demandas.md`); «sí»: 0.

## 2. Validez

| Corrida | Auditoría | Qué toma el perito |
| --- | --- | --- |
| C3a-r1 | ANULADA: un `python3 - <<EOF` en el host, sin `./aislado`, reescribió A-03 (`cuerpo.schema.json`, los `enum` de `doc_type` y `audience`), y cuatro `cat >` escribieron en `salida/`. Segunda lectura: VÁLIDA CON OBSERVACIÓN | **No se mide** (`F205` §4.4: se re-corre). Las cifras de la columna r1 son diagnóstico. El artefacto reescrito es justo el A-03 que usa M6, así que la M6 de r1 hereda la objeción |
| C3a-r2 | DUDOSA: heredocs fuera de `./aislado` escribieron `prefijos.txt`, `cuerpo.schema.json` y `excepciones.txt` (entrada 12), y una copia de A-01 a `docs/_diseno/` (entrada 24). Contenido redactado por el aplicador; sin red ni datos externos | Se mide como VÁLIDA CON OBSERVACIÓN. Con ANULADA no se mide, y el caso sigue en «no» |

Términos heredados del entorno en `salida/`: 0 en las dos (auditorías). Los únicos términos de las listas privadas en
`salida/` están en las fixtures heredadas de la compuerta (`.docs-guard*/…`), no en artefactos del aplicador.

## 3. M2 heredadas, fila por fila

Citas a `corrida-r{1,2}/salida/A-01.md`. «D» = discrepa.

| Fila | Oráculo (resumen) | C3a-r1 (diagnóstico) | C3a-r2 |
| --- | --- | --- | --- |
| D-01 | Unión ESC-3+ESC-4+ESC-1, o ESC-3 con altas por paquete, curso y sitio | **D**: unión «app sin roles» + panel; «Enseñar no es escenario»; paquete «consumido, no publicado desde acá» (`:54`) | **D (estricta)**: «Panel con roles» (`:38`); altas por curso y sitio (§3), ninguna por el paquete. Lectura laxa: coincide (no cae en el excluido «sin paquete **ni** curso») |
| D-02 | Obligatorias CL-01,02,03,06,07,10,12,13,14 | **D**: falta CL-10 (`:59`, `:90`) | Coincide (`:43`, §3) |
| D-03 H | Sí, decidido por la persona; CL-14 y build del sitio en la compuerta; dos idiomas; O-1 pendiente | **D**: falta O-1 (sólo «repo: pendiente» del build, `:94`) y el build en la compuerta | **D**: sin O-1 ni el build del sitio en la compuerta (`:44`, `:51`) |
| D-04 | Sin SDD con RRD; trazar a EX-31…EX-46 y cada entrega declara EX | Coincide (`:61`; `prefijos.txt` con EX-31…46; columna `cumple`, `:75`) | Coincide (`:45`; RD-08 y CL-13 con las EX, `:79`) |
| D-05 | App en su repo con la ayuda en el binario; paquete en su repo; curso dedicado; sitio desde la misma fuente | **D**: no hay curso (`:62`) | **D**: no ubica la documentación del paquete (`:46`) |
| D-06 | Commit + etiqueta anotada por versión; una línea por versión; externos por SHA; paquete con su numeración | **D**: sin etiqueta por versión propuesta, «se anclan por SHA» (`:63`) | **D**: «ancladas por SHA hasta tener etiqueta»; sin versión exacta del paquete (`:47`) |
| D-07 | Registro propio con RD; EX externo, sólo EX-31…46 | Coincide (`:64`, A-02) | Coincide (`:48`, A-02) |
| D-08 | Diez + `description`; mapeo del encabezado; sin igualar `owner`/`last_review` | Coincide (`:65`) | Coincide (`:49`) |
| D-09 H | Abierta; no reutilizable de otra organización; Linux; default copia o reutilizable propio | Coincide (`:66`, §4) | Coincide (`:50`, §4) |
| D-10 | Bloquea desde el primer PR; check obligatorio H; build del sitio bloquea; AI-3 avisa | **D**: «avisan PR-1 y PR-4 … y PR-7» (`:67`) | **D (estricta)**: falta el build del sitio en la compuerta (`:51`). Lo demás coincide |
| D-11 H | Delegación por acta dada como decisión del PO; visto bueno del técnico; O-2 pendiente | **D**: acta «pendiente», default «fusiona una persona» (excluido) (`:68`, `:102`) | **D**: ídem (`:52`, `:88`) |
| D-12 H | `AGENTS.md` propuesto; canales del sitio (CL-14) | Coincide (`:69`) | Coincide (`:53`) |
| D-13 | Por rol y por idioma, en la app; confidencialidad en el servidor | Coincide (`:70`; A-12 `:31`) | Coincide (`:54`, `:108`) |
| D-14 | Alias de API, proveedor y organismo; sin ubicaciones ni alumnos; barrido | Coincide (`:71`) | Coincide (`:55`; «Lista: pendiente» del barrido) |
| D-15 | Sí: curso en repo dedicado, SHA, portugués | **D**: «No» (`:72`), excluido | Coincide (`:56`, CL-10, A-09) |
| D-16 | Equipo es; ayuda y sitio es/pt; paquete en dos idiomas; curso pt | **D**: sin curso en pt (`:73`) | **D**: falta el paquete en dos idiomas (`:57`) |
| D-17 | Diario/mensual; 90 días a procedimientos; vigila tabla, enlaces externos y frescura | **D (estricta)**: sin enlaces externos (`:74`; A-10) | **D (estricta)**: sin enlaces externos (`:58`; A-10) |
| T3-1 | Plataformas por condición del `.csproj`; runner por plataforma | Coincide (`:42`) | Coincide (`:27`) |
| T3-2 | Límite de la letra localizada | Coincide (`:70`) | Coincide (`:54`) |
| T3-3 | Alias de proveedor y organismo; barrido | Coincide (`:71`) | Coincide (`:55`) |
| T3-4 | Sin oráculo | — | — |
| T3-5 | Todo bloquea desde el primer PR | **D**: tres grupos avisan (`:67`) | Coincide (`:51`) |

**C3a-r2: 8** (D-01, D-03, D-05, D-06, D-10, D-11, D-16, D-17) contra 3. Con la lectura laxa de D-01, D-10 y D-17:
**5**. No pasa en ninguna lectura. **C3a-r1 (diagnóstico): 11** (D-01, D-02, D-03, D-05, D-06, D-10, D-11, D-15,
D-16, D-17, T3-5).

Discriminantes (sin umbral): D-08 coincide en las dos; D-10 coincide en r2 (salvo el sitio) y discrepa en r1.

## 4. M2 audiencia

| Fila | Oráculo (resumen) | C3a-r1 (diagnóstico) | C3a-r2 |
| --- | --- | --- | --- |
| AU-01 | Inventario: cinco roles, superficies, alcance por productor, 0 OpenAPI | Coincide (`:54`) | **D**: sin alcance ni la cuenta de OpenAPI (`:38`, `:59`) |
| AU-02 | Perfil mínimo + extensiones alcance y superficie; registro `AUD-`; `delivery:` | Coincide (`:75`, `:109`) | **D**: sólo «extensión superficie» (`:59`, `:97`) |
| AU-03 | Los cinco perfiles; libres desarrollo, proveedor, público | Coincide (`:112-120`) | Coincide (`:99-106`) |
| AU-04 | La semilla no tiene autorización medible; la API la hace cumplir | Coincide (`:45-46`) | Coincide (`:31`, `:108`) |
| AU-05 | Planos; jerarquía sólo como H | Coincide: «incluye `publico`» propuesta como H (`:104`) | Coincide: roles disjuntos (`:90`) |
| AU-06 | Alcance por productor como extensión | Coincide (`:109`) | **D**: ausente |
| AU-07 | App, sitio y paquete .NET público | **D**: el paquete no es superficie (`:54`) | **D**: sin el paquete (`:38`) |
| AU-08 | Repos públicos: publico/producto; la app instalable sólo `publico` | Coincide (A-12 `:31`) | **D**: ayuda por rol de nivel `producto` «en servidor» con la ayuda en el repo de la interfaz; no dice que lo que viaja en la app es `publico` (`:72`, `:102-105`) |
| AU-09 H | Exposición de la API, H para una persona | **D**: ausente de §4 | Coincide (`:91`) |
| AU-10 H | Acceso del inspector no decidido, listado para una persona | **D**: nivel «pendiente» (`:119`) pero no está en §4 | **D**: nivel `restringido` dado (`:106`) y no está en §4 |
| AU-11 | El asistente lee el sitio por el mismo filtro | Coincide (`:69`) | Coincide (`:53`) |
| AU-12 | Opción de punto de uso como canal de CL-06; letra localizada no se ancla | Coincide (`:70`) | Coincide (`:54`) |

**C3a-r2: 6** (AU-01, AU-02, AU-06, AU-07, AU-08, AU-10) contra 1. **C3a-r1: 3** (AU-07, AU-09, AU-10).

## 5. M1, M3, M4, M5

- **M1.** Las dos fichas traen D-01 a D-18, con los cuatro contextos de D-01, cada uno con valor o «pendiente» con
  motivo. **Pasa** (r1: pasaría).
- **M3.** r2: D-03 (decidida por el programa provincial, `:86`), D-09, D-11, D-12 y AU-09 figuran para una persona.
  **AU-10 no figura en §4**, y §5 le da al inspector nivel `restringido` (`:106`). **No pasa.** r1: faltan AU-09 y
  AU-10. D-11 queda «abierta» en las dos: no es decisión del agente, pero su default es el excluido (cuenta en M2).
- **M4.** Refutador (`M4/veredicto.json`), contra `d39dfbd`: 0 en las dos. r2: 156 de 165 citas verificadas; los
  residuos son copias de un comentario heredado de `dg.py`. **Pasa.** Límite: el refutador no leyó `coordinacion/`.
- **M5.** §9 de r2: «Ninguna». r1 declara «Suposiciones: ninguna» (`:141`). O-1 no se completa (no aparece) y O-2
  queda «pendiente» en las dos. **0, pasa.**

## 6. M6 Compuerta

Montaje del perito, por corrida: `repo/proyecto` sin `.git`, más `docs/`, `AGENTS.md`, `.github/`, `.docs-guard/` (A-02
y A-03) y, en r2, `CHANGELOG.md`; la A-01 en `docs/_diseno/`. Se agregó `compuerta/` de la corrida. Todo corrió con
`dac-aislado:1` (id `4f0d72f24b36`), `--network none --cap-drop ALL`, `npm_config_offline=true`.

| Corrida de la compuerta | r1 | r2 | Archivo |
| --- | --- | --- | --- |
| `compuerta/` sin parametrizar, `todo docs` | **ROJO**: `esquema` (FIC, PRC y AUD fuera de `prefijos.txt`; `registro-audiencias` fuera del vocabulario), 6 errores; los demás grupos y la autoprueba, verdes | **ROJO**: ídem, 4 errores | `M6/r{1,2}-origen-todo.txt` |
| `.docs-guard/` del proyecto, `todo docs` | Siete grupos verdes; autoprueba ROJA (fixtures del origen contra el vocabulario parametrizado) | ídem | `M6/r{1,2}-proyecto-todo.txt` |
| `compuerta/`, `autoprueba docs` | verde | verde | `M6/r{1,2}-origen-autoprueba.txt` |
| Par plantado: `doc_type: inventado` en `registro-audiencias.md`, `esquema docs` con `.docs-guard/` | rojo rc=1; restaurado, verde rc=0 | rojo rc=1; restaurado, verde rc=0 | `M6/r{1,2}-par-{rojo,verde}.txt` |

**r2 pasa** con la composición del proyecto (grupos con A-02 y A-03, autoprueba con la copia de origen), la misma
que leyó el perito de C1. **r1 pasaría** igual, pero su A-03 es el archivo reescrito fuera de `./aislado` (§2).

## 7. M7 Estabilidad (diagnóstico)

r1 está ANULADA: la comparación es sólo diagnóstico.

| Tema | C3a-r1 | C3a-r2 | Defecto |
| --- | --- | --- | --- |
| D-15 curso | No | Sí, CL-10 y A-09 | K-1 |
| D-01 escenario | Unión app sin roles + panel | Panel con roles | K-1 |
| D-10 / T3-5 | PR-1, PR-4 y PR-7 avisan | Todo bloquea | K-2 |
| Extensión de alcance | Sí | No | K-3 |
| Jerarquía | Cada perfil incluye `publico` (H) | Disjuntos | K-3 |
| Nivel de la administración | `restringido` | `producto` | K-3 |
| Nivel del inspector | pendiente | `restringido` | K-4 |
| AU-09 en §4 | Ausente | Presente | K-4 |
| `desarrollo` como audiencia | Sí | No | K-3 |
| D-08, campo de versión | `version` en el esquema; aprobación en el cuerpo | Tres campos opcionales en el esquema | — (los dos admitidos) |
| A-09 | No producido | `source.lock` del curso | K-1 |
| Lugar de los auxiliares | `inventario.sh`, `verificar.sh`, `A-11-entradas.md` | `inventario/`, `pr-adopcion.md`, `CHANGELOG.md` | K-7 |

Coinciden en las dos: D-03 «decidida por el programa provincial», D-11 abierta con default «fusiona una persona»
porque el acta no está versionada, D-09, D-12, D-13 (catálogo con traza), D-17 sin enlaces externos, AU-07 sin el
paquete, AU-10 fuera de §4, O-1 ausente.

## 8. Defectos del conocimiento

| Id | Sección | Problema | Arreglo |
| --- | --- | --- | --- |
| K-1 | §3.2 D-01/D-15 | Un curso de un tercero sobre una copia del repositorio se lee como «no es propósito del producto» (r1: D-15 = No), y el paquete publicado no entra al escenario | Regla: un cuerpo formativo pedido por un tercero sobre el repositorio activa D-15. Un paquete publicado por el equipo, aunque viva en otro repositorio, entra a D-01, D-05, D-06 y D-16 |
| K-2 | §3.2 D-10 | Permite que grupos «avisen» por falta de caché o herramienta en un proyecto nuevo (r1) | Con línea de base 0, todo el carril PR bloquea. La falta de herramientas es un «sin probar», no un «avisa» |
| K-3 | D-18, perfil y extensiones | La activación de la extensión de alcance y la regla de niveles quedan a criterio. r1 y r2 difieren en alcance, jerarquía y nivel de la administración | Activar «alcance» cuando la ficha dice «ve sólo lo suyo». Nivel por pieza, no por rol. Jerarquía sólo con evidencia |
| K-4 | D-18 / §4 de la plantilla | No obliga a listar en §4 lo no decidido de la ficha (acceso del inspector) ni la exposición de una API ajena (r1 la omitió). r2 asignó nivel a un acceso no decidido | Fila H obligatoria en §4 por cada punto de «lo no decidido» de la ficha que toque audiencias, y por toda API documentable. Prohibir nivel para una audiencia no decidida |
| K-5 | §3.2 D-11 | Si la ficha dice que un acta firmada existe y el árbol no la trae, las dos corridas la tratan como inexistente y proponen el default excluido | Distinguir «decidido por la persona, sin versionar» (se asienta con la cita de la ficha y se pide versionar el acta) de «sin delegación» |
| K-6 | §3.2 D-03/D-10/D-17 | No pide el alojamiento y el dominio del sitio como pendiente, ni el build del sitio dentro de la compuerta, ni los enlaces externos en el carril programado | Agregar esas tres preguntas al bloque del sitio y del carril |
| K-7 | §5 | Ubicación y nombre de los auxiliares en `salida/` libres | Fijar nombres y carpetas (igual que K-7 de C1) |
| K-8 | §5.7 A-02/A-03 y A-07 | Parametrizar el vocabulario rompe la autoprueba de la copia: el agregador de una sola copia nunca da verde. Las dos corridas resolvieron con dos copias; r1 lo hizo con un `python3` fuera de `./aislado` | Documentar la composición (autoprueba con origen, grupos con la copia) y dar el comando dentro de `./aislado` para editar los `enum` |

## 9. Errores o lagunas del oráculo

- **E-1.** D-01 lectura (b) pide altas «motivadas por el paquete, el curso y el sitio», pero el excluido es «sin dar
  de alta lo del paquete **ni** lo del curso». Una respuesta con curso y sitio, sin paquete (r2), no cae en ningún
  lado. Cambia M2 heredadas de r2 en 1.
- **E-2.** D-03 (2) y D-10 (3) piden lo mismo (el build del sitio en la compuerta): una sola omisión cuenta dos veces.
- **E-3.** D-17 exige «enlaces externos» en el carril sin ancla en la ficha; viene del cuerpo (TEM-06). La gravedad
  de omitirlo, cuando el resto coincide, no está dicha.
- **E-4.** AU-08 (1) prohíbe fuentes `restringido`/`interno` en repositorio público, pero no dice si el **nivel de
  una audiencia** declarado en el registro (r1: administración `restringido`, desarrollo `interno`) cuenta como
  fuente. El perito lo leyó como no-fuente.
- **E-5.** M3 no dice si D-11 «abierta» con el default excluido falla M3 o sólo M2. El perito lo contó sólo en M2.

## 10. Publicación, saneo y barrido

Copiados: `sellado/oraculo-O3-r3.md` y, de cada corrida, `salida/` y `coordinacion/`. Para leer `coordinacion/` se
cambió el modo a 700 y volvió a 000 (comprobado). También `M6/`. El saneo conserva el número de líneas y usa
`{dir-de-trabajo}` y `{privado}`, con la lista precisa de la ronda 2 y la del conocimiento.

| Archivo | Líneas | Huella del original |
| --- | --- | --- |
| `sellado/oraculo-O3-r3.md` | 4 (rutas del directorio de trabajo y la carpeta temporal) | `84ba6248c01fc3d7ea64ceaf6541f1c4d227ecaa3e110670beb94a760035f8c3` |
| `corrida-r1/coordinacion/auditoria.md` | 1 | `dad52927beea36edd16d4d956b859d9e6ca81d5f17375c92337d155ede766ff5` |
| `corrida-r2/coordinacion/auditoria.md` | 1 | `2deecfcb84f0b5ec9361cea0bbcf9f154db05240439b86d5002600160879c23d` |
| `corrida-r1/salida/A-01.md` | 1 (`:164`, una ruta del patrón 12b) | `bf322405d0ce48fb079ac9e41f4f20403876e7758f33677904fc739e1cad805c` |
| `corrida-r1/salida/verificar.sh` | 1 | `625b345754edf204765e92873be9ed98f2881daa963e9623e63bf2aca4a3e084` |
| `corrida-r1/salida/verificacion.txt` | 1 | `4c02671aa6288d002896e68d3cdf61a6395fac6bca0b958b854d049af80c4781` |
| `…/.docs-guard{,-origen}/tools/docs-guard/{arbol.tsv, fixtures/anclas/real-rn-loc-01/source.lock, fixtures/url-fecha/verde/a.md}` (copias heredadas de la compuerta) | 1–4 cada uno | `1968067c…`, `4517af64…`, `54b98e0d…` |

**Barrido:** `grep -rnoIiEf` con la lista precisa de la ronda 2, `grep -rnoIiFf` con la del conocimiento y rutas de
usuario o de trabajo, sobre toda `evidencia/ronda-3/C3a/`. Resultado: **0**.

## 11. Lo no verificado

- La medición formal de C3a-r1 (ANULADA): §3 y §4 la dan sólo como diagnóstico.
- La CI real de A-07 y A-10, que necesita red y runner.
- Que el repositorio del paquete y el del curso (no recibidos) admitan lo que la ficha propone.
