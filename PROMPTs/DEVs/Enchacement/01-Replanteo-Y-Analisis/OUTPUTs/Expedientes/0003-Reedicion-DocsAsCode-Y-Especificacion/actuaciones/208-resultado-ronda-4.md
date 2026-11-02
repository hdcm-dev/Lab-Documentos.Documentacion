---
doc_id: EXP0003-F208
doc_type: resultado-ronda
title: Resultado de la ronda 4 de los ensayos — validez bajo aislamiento total, métrica e por grupo de filas, defectos del conocimiento 1.2 y 1.4, juicio de oráculos, respuesta a TP:20 y publicación del conocimiento en el PR 7 como borrador ensayado
status: vigente
origin: agent
confidence: alta en las cifras (copiadas de las métricas de los peritos, de las auditorías de los coordinadores y del recuento del registro de la guardia); media en la clasificación de defectos cerrados y repetidos de §5 y en el juicio de C2-r2 de §1, rotulados [criterio propio]
owner: presidencia de la mesa de la reedición DocsAsCode (expediente 0003)
last_review: 2026-11-02
audience: [presidencia, coordinador, autores de oráculo, autor del conocimiento, peritos, refutador, PO]
traces: [TP:18, TP:20, TP:70, EXP0003-F099, EXP0003-F205, EXP0003-F206, EXP0003-F207, EXP0003-F399]
---

| Campo | Valor |
| --- | --- |
| Tipo | folio de resultado |
| Fecha | 2026-11-02 |
| Autor | Presidencia. No escribió ningún oráculo ni el conocimiento, y no corrió ni coordinó ninguna corrida |
| Cumple | `F207` (ronda 4 sellada), `F206` §1 (regla de validez) y §9 (criterio de aptitud), decisión del PO del 2026-11-02 (publicar tras la ronda 4 en cualquier caso) |
| Resultado | **Las ocho corridas son válidas** (todas VÁLIDAS CON OBSERVACIÓN) y **ninguna pasa**. Ningún caso del brazo B tiene una corrida que pase y quedan abiertos cuatro defectos P0 de la 1.4. **El conocimiento 1.4 se publica en el PR 7 como «borrador ensayado, no probado»** (§9) |
| Rama | `dac/0003-ensayos` |

## Índice

1. [Validez de las corridas](#1-validez-de-las-corridas)
2. [Métrica e de la ronda 4](#2-métrica-e-de-la-ronda-4)
3. [M7 por caso](#3-m7-por-caso)
4. [Comparación con las rondas 1 a 3](#4-comparación-con-las-rondas-1-a-3)
5. [Defectos del conocimiento](#5-defectos-del-conocimiento)
6. [Juicio de los errores del oráculo](#6-juicio-de-los-errores-del-oráculo)
7. [Respuesta a TP:20 y la mitad «nuevos»](#7-respuesta-a-tp20-y-la-mitad-nuevos)
8. [Evidencia publicada y barrido](#8-evidencia-publicada-y-barrido)
9. [Veredicto y rótulo del PR 7](#9-veredicto-y-rótulo-del-pr-7)

## 1. Validez de las corridas

Ocho corridas (`F207`): brazo A (C0, conocimiento 1.2) y brazo B (C1, C2, C3a, conocimiento 1.4), dos por caso, con
el aplicador en **aislamiento total** (`F207` §2): proceso aparte, sin memoria ni configuración del usuario, sin MCP y
con la guardia PreToolUse sobre toda herramienta.

**Registro de la guardia** (`evidencia/ronda-4/guardia.md`): 442 llamadas, **429 permitidas** y **13 bloqueadas**
(9 por un operador fuera del contenedor, 4 por consola fuera de `./aislado`). Las 301 consolas permitidas corrieron
por `./aislado` y las 128 llamadas de archivo permitidas quedaron dentro de la corrida propia. Los 13 bloqueos se
rehicieron por la vía prescrita, sin rodeo. **0 demandas.**

| Corrida | Auditoría | Bloqueos | Accesos fuera | Términos heredados atribuibles | Decisión |
| --- | --- | --- | --- | --- | --- |
| C0-r1 | VÁLIDA CON OBSERVACIÓN | 2 | 0 | 0 | **VÁLIDA CON OBSERVACIÓN**. Observación: el arnés guardó dos resultados de Bash fuera de la corrida; el aplicador no los leyó |
| C0-r2 | VÁLIDA CON OBSERVACIÓN | 1 | 0 | 0 | **VÁLIDA CON OBSERVACIÓN**. Un Read sin ruta falló por validación; un `ls` de `SDEI/` negado por el sistema de archivos y no rodeado |
| C1-r1 | VÁLIDA CON OBSERVACIÓN | 2 | 0 | 0 | **VÁLIDA CON OBSERVACIÓN**. El init registra `user_context_builds=2` sin memoria ni CLAUDE.md |
| C1-r2 | VÁLIDA CON OBSERVACIÓN | 2 | 0 | 0 | **VÁLIDA CON OBSERVACIÓN** |
| C2-r1 | VÁLIDA CON OBSERVACIÓN | 2 | 0 | 0 | **VÁLIDA CON OBSERVACIÓN** |
| C2-r2 | VÁLIDA CON OBSERVACIÓN; lectura alternativa ANULADA, a juicio de la presidencia | 1 | 0 | 3 de 25 no atribuibles | **VÁLIDA CON OBSERVACIÓN** [criterio propio], ver abajo |
| C3a-r1 | VÁLIDA CON OBSERVACIÓN | 1 | 0 | 0 | **VÁLIDA CON OBSERVACIÓN** |
| C3a-r2 | VÁLIDA CON OBSERVACIÓN | 2 | 0 | 0 | **VÁLIDA CON OBSERVACIÓN** |

**C2-r2** **[criterio propio]**. La duda es que el aplicador escribió, por `./aislado`, en `_auxiliares/` de la
corrida y no en `salida/`. La regla de `F206` §1 anula por escritura o cómputo **en el host**; esto ocurrió dentro del
contenedor y dentro de la corrida. Además, el conocimiento §3.7 prescribe `{dir-de-corrida}/_auxiliares/`, y es la
carta la que sólo admite `salida/`: el choque es de los insumos (C1 K4-11, C3a K4-08, C2 F-2), no del aplicador.
**Se decide VÁLIDA CON OBSERVACIÓN.** Los 3 términos no atribuibles quedan como observación: ninguno sostiene un valor
medido, y el veredicto no depende de esta corrida (no pasa con ninguna lectura).

**Válidas: 8 de 8.** Primera ronda sin anuladas.

**Límites de la ronda 3.** El aislamiento total cerró los tres:

| Límite | Ronda 3 | Ronda 4 |
| --- | --- | --- |
| L-1: el índice de memoria del entorno llega al aplicador | Declarado, sin quitar | **Cerrado.** Ningún init trae memoria ni CLAUDE.md, y 0 términos heredados atribuibles en siete corridas (C2-r2: 3 no atribuibles, sin valor) |
| L-2: lectura fuera de `./aislado` | Declarado | **Cerrado en lo que importa.** Las lecturas por Read quedan acotadas a la corrida propia; 0 accesos fuera |
| L-3: consola sin `./aislado` no se puede impedir | Causa de 5 anulaciones | **Cerrado.** La guardia rechazó las 4 consolas del host y los 9 operadores; ninguna se ejecutó |

## 2. Métrica e de la ronda 4

*n* y umbral (`F207` §4): C0 heredadas 24 · 3; C1 23 · 3 y audiencia 12 · 1; C2 25 · 3 y 16 · 2; C3a 21 · 3 y 12 · 1.

| Corrida | M1 | M2 heredadas | M2 audiencia | M3 | M4 | M5 | M6 | Pasa |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| C0-r1 | 17/17 | **10** ✘ | n/a (0 es relleno) | ✘ D-09 y D-12 «decidida de hecho», D-11 sin opciones, falta la renovación de la huella | **1** ✘ | 0 | ✔ | **No** |
| C0-r2 | 17/17 | **5** ✘ | n/a | ✘ D-11 «decidida por {persona}», AI-3 dada por vigente sin renovación | **1** ✘ | 0 | ✔ | **No** |
| C1-r1 | 18/18 y 4/4 | **7** ✘ | 1 ✔ | ✔ | 0 | 0 | ✔ con la composición del proyecto | **No** (sólo M2 heredadas) |
| C1-r2 | 18/18 y 4/4 | **8** ✘ | **3** ✘ | ✔ | 0 | **1** ✘ | ✘ no produjo A-02…A-13 | **No** |
| C2-r1 | 18/18 | **10** ✘ | **15** ✘ | ✘ 4/5, fila H de API con default «pendiente» | 0 | **1** ✘ | ✔ | **No** |
| C2-r2 | 18/18 | **9** ✘ | **11** ✘ | ✔ 5/5 | 0 | **1** ✘ | ✔ | **No** |
| C3a-r1 | 18/18 | **5** ✘ (2 con la lectura laxa) | **2** ✘ | ✔ | 0 | 0 | ✔ con la composición del proyecto | **No** |
| C3a-r2 | 18/18 | **8** ✘ (4 laxa) | **7** ✘ | ✔ con observación | 0 | 0 | ✔ con la composición del proyecto | **No** |

**Ninguna de las ocho pasa.** La más cercana es **C1-r1**: falla sólo M2 heredadas (7 > 3). **C3a-r1**, con la lectura
laxa de su perito, pasaría heredadas (2) pero falla igual audiencia (2 > 1). M1 pasa en las ocho y M6 en siete.

Las métricas completas están en `evidencia/ronda-4/{C0,C1,C3a}/metrica.md`; las de C2 son privadas y sus cifras están
en `evidencia/ronda-4/C2/cifras.md`.

## 3. M7 por caso

M7 se calcula por primera vez en los cuatro casos, porque todas las corridas son válidas.

| Caso | Concordancia | Lo que coincide en el error | Lo que diverge |
| --- | --- | --- | --- |
| C0 | 17 de 24 filas | T-02, T-03, T-04, T-07; las dos fallan M3 por la renovación de la huella | D-04, D-06, D-09, D-10, D-14, T-05 (sólo r1); D-17 (sólo r2); CL-08, CL-11, A-09, conteo de prefijos |
| C1 | 14 diferencias de diagnóstico | Dos audiencias planas, alcance no activado, organización pendiente, T1/T2/T5 sin detectar, AUD-11 pendiente | D-01 (r2 suma «servicio con paquetes»), D-04, CL-04, D-06, D-12, AUD-09, AUD-07, punto de uso, T3, T4, T7, artefactos (12 frente a 0), verificación §8, suposiciones (0 frente a 1) |
| C2 | 32/41 (78 %): heredadas 20/25 (80 %), audiencia 12/16 (75 %) | D-04/D-07, D-05/T-8, visibilidad en D-14 y AU-06, T-7, T-9, AU-01, AU-04, AU-05, AU-09, AU-10, TA-1…TA-3, TA-5 | D-02, D-06, T-2 (✘ sólo r1); T-1, T-4 (✘ sólo r2); AU-07, AU-08, AU-11, TA-4 (✔ sólo r2) |
| C3a | 13 diferencias | D-18 con perfil mínimo sin extensiones; D-06 «por SHA» sin etiqueta | D-03, EX por entrega y A-11, campos de D-08, build del sitio, idioma, CL-08/09/11, default de AU-10, IDs AUD-, AU-08/AU-11, lugar de source.lock y de auxiliares |

Lectura: **el error es estable y la variación está en los márgenes.** Las dos corridas de cada caso fallan por las
mismas filas centrales (huella vencida en C0; audiencia en C2 y C3a; T-patrones en C1). La varianza entre corridas
no explica el resultado; lo explican defectos del conocimiento, que es lo que mide la ronda.

## 4. Comparación con las rondas 1 a 3

| Ronda | Corridas | Anuladas | Pasan | Casos con ≥1 que pasa | Causa dominante |
| --- | --- | --- | --- | --- | --- |
| 1 (`F203`) | 6 | 0 | 0 | 0 | M2 y M6 |
| 2 (`F204`) | 8 | 2 (red, C0) | 1 con reserva (C2-r2) | 1 (C2, con reserva) | M2, M3, M6 |
| 3 (`F206`) | 8 | 5 (host fuera de `./aislado`) | 0 | 0 | M2 audiencia, M3, aislamiento |
| 4 (este folio) | 8 | **0** | 0 | 0 | **M2 heredadas y audiencia**; M3 sólo en C0 y C2-r1 |

- **El aislamiento quedó resuelto**: de 5 anuladas a 0. La ronda 4 es la primera que mide limpio los ocho casos.
- **C0** tiene por fin medida válida de la 1.2: heredadas 10 y 5 (umbral 3), M3 y M4 fallan en las dos.
- **C1**: heredadas 7 y 8 (ronda 3: 5 de diagnóstico). Audiencia baja a 1 en r1, la primera fila de audiencia que pasa
  en el brazo B. M3 pasa en las dos (falló en la ronda 3).
- **C2**: heredadas 10 y 9 (ronda 3: 6); audiencia 15 y 11 (ronda 3: 12). M3 pasa por primera vez (r2). M6 se sostiene.
- **C3a**: heredadas 5 y 8 (ronda 3: 11 y 8 de diagnóstico); audiencia 2 y 7. M3 pasa en las dos: D-11 quedó
  «decidida por su actor» (cierra DC3a-01 y C3a K-5).
- **M3 mejoró en el brazo B** (5 de 6 pasan); **M2 no**: heredadas no baja del umbral en ninguna corrida.

## 5. Defectos del conocimiento

Prioridad como en `F206` §5. Los defectos de C0 son de la 1.2; los de C1, C2 y C3a, de la 1.4.

### 5.1 Familias P0 de `F206`: estado

| Familia (`F206` §5.2) | Estado en la ronda 4 | Evidencia |
| --- | --- | --- |
| Aislamiento de cómputo | **Cerrada** | 0 anuladas; 0 consolas del host ejecutadas (§1) |
| Fila H obligatoria en §4 para audiencias y API | **Cerrada a medias** | M3 pasa en C1 (2/2), C3a (2/2) y C2-r2; sigue abierta en C2-r1 por el default «pendiente» → C2 K4-02 |
| Jerarquía, nivel y alcance de D-18 | **Abierta** | Audiencia falla en 5 de 6 corridas del brazo B → C2 K4-01, C3a K4-01 |
| D-11 con acta no versionada (C3a K-5) | **Cerrada** | D-11 «decidida por {actor}, citada» en las dos C3a; la regla se extiende a D-03 → C3a K4-04 (P1) |

### 5.2 Repetidos (P1 y P2 de rondas anteriores)

| Familia | Ids de la ronda 4 | Repite | Prioridad |
| --- | --- | --- | --- |
| Composición de la compuerta | C1 K4-10, C3a K4-07 | K-6 / K-8, tercera ronda | P1 |
| Auxiliares: §3.7 frente a la carta | C1 K4-11, C3a K4-08, C2 F-2 | K-7, ahora como contradicción entre insumos | P2 |
| Patrones de §3.1 (estado desde tablas, par ruta:línea, colisiones de IDs) | C1 K4-02, K4-07; C2 K4-07, K4-08 | K-9, K-10, K3-04, tercera ronda en T5 | P1 |
| Repos no recibidos y visibilidad desde el índice | C2 K4-03, K4-04, K4-05 | K3-01, K3-02, K3-05 (tercera ronda) | P1 |
| Punto de uso, filtro único, homónimos | C1 K4-08, C2 K4-09 | K-3, K3-10, K3-11 | P1 |
| D-12 «pendiente» pese a la regla I-24 | C1 K4-03 | K-11 | P1 |

### 5.3 Nuevos

| Id | Caso | Defecto | Prioridad |
| --- | --- | --- | --- |
| C0 K4-01 | C0 (1.2) | Ningún patrón comprueba la huella de una excepción AK-3; las dos corridas dan por buena una excepción vencida y M3 falla | **P0** de la 1.2 |
| C0 K4-02 | C0 (1.2) | El chequeo de citas compara archivo y rango, no contenido; 1 invención por corrida, M4 falla | **P0** de la 1.2 |
| C1 K4-01 | C1 | La regla «con H abierta se produce con el default, rotulado propuesta» está sólo en el cuerpo, no en la plantilla ni la carta; r2 no produce A-02…A-13 y falla M6 | **P0** |
| C2 K4-01 | C2 | Con el repo del código ausente, «sin acceso propio probado no hay nivel» deja D-18 entero pendiente; audiencia 15 y 11 | **P0** |
| C2 K4-02 | C2 | La fila H de exponer documentación de API admite default «pendiente»; M3 falla en r1 | **P0** |
| C3a K4-01 | C3a | El alcance «sólo lo suyo» con autorización en repo ajeno queda «no activado» y D-18 baja a perfil mínimo; AU-02 y AU-06 fallan en las dos | **P0** |
| C2 K4-06 | C2 | No prohíbe transcribir valores privados: r1 copió usuario, clave y túnel en su A-01 | P1 (seguridad: se recomienda tratarlo con el P0) |
| C0 K4-03…K4-07 | C0 (1.2) | Traces de la raíz frente a IDs obsoletos; checks requeridos de workflows; etiqueta del runner literal; I-19 y source.lock existente; registro de prefijos frente a marco | P1 |
| C1 K4-04, K4-05, K4-09 | C1 | «Servicio con paquetes» sin paquete medido; I-04 rechaza el registro; fila «Suposición registrada» en §7 | P1 |
| C3a K4-02, K4-03, K4-05, K4-06 | C3a | Etiqueta anotada por versión; lista del sitio decidido; EX por entrega y A-11; mapeo del encabezado campo por campo | P1 |
| C3a K4-04 | C3a | «decidida por {actor}» extendida a D-03 | P1 |
| C1 K4-06 | C1 | D-06 sin versión del ID en trazas, par vigente/_legacy ni estado del ancla | P1 |
| C0 K4-08, K4-09; C2 K4-10 | C0, C2 | Frescura de DE-17 en D-17; ruta del CHANGELOG antes de «pendiente»; criterio de CL-11 | P2 |

**P0 abiertos de la 1.4: cuatro** (C1 K4-01, C2 K4-01, C2 K4-02, C3a K4-01). Los dos P0 de C0 son de la 1.2; si la
1.4 hereda los mismos patrones (huella AK-3 y citas por contenido) aplican también a ella, cosa que su autor debe
contrastar **[criterio propio]**. C2 K4-01 y C3a K4-01 son la misma familia (nivel y alcance de D-18 sin acceso
propio probado).

### 5.4 Fuera del conocimiento

| Id | Hecho | Corrección |
| --- | --- | --- |
| C2 F-1 | Las dos corridas declararon la autoprueba «sin red» aunque la imagen trae las herramientas | La carta o §5.7 dice cómo se invoca la autoprueba en `dac-aislado` |
| C2 F-2 | §3.7 y la carta se contradicen sobre los auxiliares | Se corrige junto con C1 K4-11 y C3a K4-08 |
| C2 F-3 | El autochequeo de §8 no detecta desplazamientos de línea | Cotejar texto, igual que C0 K4-02 |
| Arnés | Dos resultados de Bash guardados por el arnés fuera de la corrida (C0-r1) | Sin efecto: no se leyeron. Se anota para el aislamiento |

## 6. Juicio de los errores del oráculo

Por O-4 (`F016` §4.3): se corrige sólo por error; *n* y umbral no se mueven; ninguna M2 se recalcula. **Ningún
veredicto depende de un alegato**: en todos, la corrida falla igual por otra medida.

| Caso | Alegato | Juicio |
| --- | --- | --- |
| C0 | E-1: la regla 3 y §4 piden que ninguna H quede «decidida», contra DE-22 de la 1.2 («decidida por {actor}» con cita) | **Procede.** Se corrige en el oráculo de C0 como se hizo en C1 en `F207`. M3 falla igual (renovación faltante) |
| C0 | E-2: T-04 sin regla para la sustancia nombrada sin ancla | **Procede como aclaración.** r2 bajaría de 5 a 4; no cambia |
| C1 | O-1: traza de pantallas en D-07 y T2 | **Procede** (doble conteo); ya se contó una vez |
| C1 | O-2: CL-04 fuente o salida | **Sigue pendiente de la mesa** (`F206` §6); rige el oráculo |
| C1 | O-3: qué es una «decisión escrita» | **Procede**: el oráculo define el ancla mínima |
| C1 | O-4: AUD-09 ignora BT-00031 en Done | **Procede**: el hecho de AUD-09 se reescribe con BT-00031 |
| C1 | O-5: D-06 y T7 cuentan la misma omisión | **Procede**: una sola cuenta desde la ronda 5 |
| C2 | E-1, E-2, E-3 | **No proceden como error**: se aclaran en la nota del oráculo (registro propio con prefijos externos, audiencias separadas sin `incluye:`, caso mixto de D-04). Contados ✘; la lectura indulgente no cambia el veredicto |
| C3a | E-O1: D-03 (3) y D-16 (2) piden los mismos idiomas | **Procede** (como E-2 de la ronda 3): se cuenta una vez |
| C3a | E-O2: alcance por productor en AU-01 y AU-06 | **Procede como aclaración**: «declarado, no activado» satisface AU-01 y no AU-06, como contó el perito |
| C3a | E-O3: build del sitio en D-03 o D-10 | **Procede**: cuenta donde esté escrito |
| C3a | E-O4: T3-2 con un artefacto | **Procede como aclaración**: basta nombrarlo en un artefacto citado por A-01 |
| C3a | E-O5: H decidida dada por abierta con default admitido | **Procede**: cuenta sólo en M2, como contó el perito |

Los oráculos de C0, C1 y C3a se publican con este folio en `evidencia/ronda-4/{C0,C1,C3a}/sellado/`. El de C2 no se
publica (sólo huella).

## 7. Respuesta a TP:20 y la mitad «nuevos»

**Pregunta** (`F099:381`): ¿alcanza el conocimiento, solo, para que alguien sin contexto diseñe el sistema
documentador como lo haría quien conoce el cuerpo?

| Caso | Brazo | Respuesta | Por qué |
| --- | --- | --- | --- |
| C0 | A (1.2) | **No** | Primera medida válida en cuatro rondas: las dos fallan M2, M3 y M4 |
| C1 | B (1.4) | **No, cerca** | r1 falla sólo M2 heredadas (7 > 3); es la corrida más próxima a pasar de las cuatro rondas |
| C2 | B (1.4) | **No** | Las dos fallan M2 en los dos grupos y M5; M3 pasa en r2 |
| C3a | B (1.4) | **No** | Las dos fallan M2 audiencia por D-18; r1 pasaría heredadas con la lectura laxa |

**Respuesta de la ronda 4: el conocimiento 1.4 no alcanza solo.** Mejora frente a la 1.3 en M3 y en las decisiones
heredadas ya tomadas por un actor; no mejora en M2. La comparación de brazos es posible por primera vez: la 1.2 (C0)
falla en M3 y M4, donde la 1.4 pasa en casi todo el brazo B; las dos fallan M2 heredadas.

**La mitad «nuevos» de `TP:18` (C3a).** Tercera ronda ejercitada, primera medida limpia, **no probada**: D-11 quedó
resuelta y M3 pasa, pero D-18 falla en las dos. Sigue `F199` §7 en su forma parcial: el libro no afirma que el
material alcance para un proyecto nuevo sin la marca «sin probar» del anexo J.

## 8. Evidencia publicada y barrido

En `evidencia/ronda-4/`: C0, C1 y C3a con `corrida-r1/` y `corrida-r2/` (salida y auditoría), `M4/`, `M6/`,
`metrica.md` y `sellado/`; `insumos/` (cartas, `aplicar.sh`, guardia y su configuración); y `guardia.md`, el recuento
del registro de la guardia por corrida, sin rutas del área de ensayo (`{area-de-ensayo}`). C2: sólo `cifras.md`;
métrica, oráculo, M6 y auditorías quedan en el área privada del expediente.

Barrido de lo privado sobre este folio y `evidencia/ronda-4/**` con la lista precisa del expediente, más los nombres
de host del entorno y los prefijos de ruta del área de trabajo y del usuario: **0 coincidencias**.

## 9. Veredicto y rótulo del PR 7

**Criterio de aptitud** (`F206` §9, sin cambio en `F207` §5): apto cuando cada caso del brazo B tiene al menos una
corrida válida que pasa y no queda abierto ningún P0.

| Condición | Estado |
| --- | --- |
| C1 con ≥1 corrida válida que pasa | No (0 de 2 válidas) |
| C2 con ≥1 corrida válida que pasa | No (0 de 2 válidas) |
| C3a con ≥1 corrida válida que pasa | No (0 de 2 válidas) |
| Defectos P0 abiertos de la 1.4 | 4: C1 K4-01, C2 K4-01, C2 K4-02, C3a K4-01 |

**Veredicto: el conocimiento 1.4 no cumple el criterio.** Por la decisión del PO del 2026-11-02, el conocimiento se
publica igual en el PR 7, **como «borrador ensayado, no probado»**, no como «probado en la ronda 4». Rótulo exacto
para su cabecera:

> **Borrador ensayado, no probado.** Conocimiento 1.4, ensayado en la ronda 4 del expediente 0003 (`EXP0003-F208`,
> 2026-11-02): ocho corridas válidas bajo aislamiento total, ninguna pasa la métrica e. Ningún caso del brazo B
> (C1, C2, C3a) tiene una corrida que pase. P0 abiertos:
>
> - **C1 K4-01**: con una H abierta, los artefactos se producen con el default y el rótulo «propuesta sujeta a
>   D-nn»; la regla no está en la plantilla A-01 §6 ni es DE obligatoria.
> - **C2 K4-01**: sin el repo del código, la regla de acceso propio deja D-18 entero pendiente; falta admitir la
>   ruta:línea del índice como prueba, rotulada «según el índice».
> - **C2 K4-02**: la fila H de exponer documentación de API admite default «pendiente»; falta exigir un default
>   concreto y una fila por API documentable.
> - **C3a K4-01**: el alcance «sólo lo suyo» con autorización en repo ajeno queda «no activado»; falta activar las
>   extensiones de alcance y superficie y separar el nivel por pieza del nivel por audiencia.
>
> Úsese como guía con criterio, no como procedimiento validado.

Sigue: el autor del conocimiento escribe la 1.5 con los cuatro P0 (y contrasta los dos P0 de la 1.2, C0 K4-01 y
K4-02); los autores de oráculo aplican §6; la carta del aplicador alinea los auxiliares con §3.7 y la autoprueba
(F-1, F-2). Una ronda 5, si se abre, se sella en un folio previo propio.
