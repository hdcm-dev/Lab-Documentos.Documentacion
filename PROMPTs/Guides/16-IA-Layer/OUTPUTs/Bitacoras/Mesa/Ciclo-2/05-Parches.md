---
doc_id: BIT-16-MESA-C2-05
doc_type: parches-del-cuerpo-auditor
title: Ciclo 2 · Parches sobre el plan de integración v1 (M§4.4, M§5.4)
version: v1
status: para la presidencia (aplicar en el orden de §0.3; nada aplicado todavía)
origin: agent (cuerpo auditor; diseña correcciones, no vota)
last_review: 2026-10-26
traces: [BIT-16-04 v1, BIT-16-MESA-C2-03, BIT-16-MESA-C2-04, BIT-16-00, BIT-16-02, BIT-16-MESA-C1-05, BIT-16-MESA-C1-07, Mesa/I-01..I-06]
---

# Ciclo 2 · Parches del cuerpo auditor

Objeto: `../../../04-Plan-De-Integracion.md` (BIT-16-04, ESTRUCTURA APROBADA v1). Insumo: los ítems con resultado PROCEDE del jurado endurecido del ciclo 2: 59 hallazgos (H2-001…H2-059, S4 en lote incluidos), 6 ratificaciones (RAT-AJ-02, -04, -06, -07, -08 y RAT-NIVEL), 13 re-votos del ciclo 1 (RV-01…RV-11, RV-13, RV-14) y 7 contradicciones (X2-01…X2-07). RAT-AJ-01, RAT-AJ-03, RAT-AJ-05 y RV-12 no figuran como PROCEDE: AJ-01 y AJ-05 se **reemiten** como parches (X2-04, X2-03) y AJ-03 se **reemplaza** por la decisión de alcance (X2-02). El cuerpo auditor no vota y no reabre lo votado. ESC-001 no se reabre: rige el default B (Ollama propio aparte, SUP-09), que en este ciclo pasa a llamarse EMB-B (PAR2-02).

## 0. Cómo leer y aplicar estos parches

### 0.1 Fusión, capa de origen y resolución de contradicciones

- Un parche por sección del plan. Cuando varios ítems tocan la misma sección, van juntos (M§5.4). Cuando el defecto nace fuera del plan, el parche va a esa capa: BIT-16-02 §6 (PAR2-23), `Mesa/Ciclo-1/05-Parches.md` (PAR2-24), el gestor de recursos de la raíz del workspace (PAR2-25, pedido con dueño: la mesa no lo escribe) y N6 (PAR2-26).
- Cada contradicción X2-nn se resuelve con la posición que votó la mayoría, citada en su parche. En X2-01 la mayoría eligió «prefijo sin letras, interno, fuera de la guía» con el ejemplo «T1–T3»; el juez de coherencia mostró que T1–T7 ya nombran las tensiones del plan, y el cuerpo auditor lo re-verificó (§0.2). El parche aplica la regla votada con un prefijo que no choca: **TURNO-1…TURNO-3**. Es una consecuencia mecánica del voto, no una decisión nueva; si la presidencia prefiere otra grafía sin letras, sólo cambia el reemplazo.
- Re-votos (`revoto_ciclo1`): cuando el ítem pide **votar de nuevo** una decisión (RV-01, RV-03, RV-04, RV-05, RV-11), el parche marca la decisión del ciclo 1 como «en re-votación», la deja vigente en forma provisional y trae la **papeleta** con las opciones y su costo, para que el jurado vote en la aprobación (`06-Aprobacion.md`). Cuando el ítem corrige un dato (RV-02, RV-06, RV-07, RV-08, RV-09, RV-10, RV-13, RV-14), el parche lo corrige.
- Ratificaciones (`ratificacion_aj`): «ratificar» sin cambio (RAT-AJ-04, -06, -07, -08, PAR2-27) o con el ajuste correctivo que pidió el jurado (RAT-AJ-02 en PAR2-01; RAT-NIVEL en PAR2-02).
- Texto exacto: «reemplaza … por …» cita el texto de la v1 tal como está; «agrega» indica dónde. Los números de línea son de la v1.

### 0.2 Verificaciones hechas por el cuerpo auditor (por el aviso de homogeneidad, M§9)

Todo de sólo lectura; no se tocó nada fuera de `OUTPUTs/`.

| Verificación | Resultado | Usada en |
|---|---|---|
| `grep -noE "\bT[1-7]\b"` sobre el plan v1 | 11 apariciones (l. 476, 556, 569, 701, 754, 762, 765, 790, 794, 863, 886): T1–T7 nombran tensiones. `TURNO-` no aparece | PAR2-02 (X2-01) |
| Ids PROCEDE de `Ciclo-1/04-Veredictos.md` (`grep "\| \*\*PROCEDE\*\* \|"`) contra `Ciclo-1/05-Parches.md` (`grep -w` por id) | 93 ids PROCEDE (63 H, 9 X, 21 PR). Los 93 aparecen en 05-Parches. El «85» de l. 14 y l. 984 es un error de suma: 63 + 9 + 21 = 93 | PAR2-24 (RV-14) |
| `git show 8fb4c3a:` en Lab-E2E.WebBlazor, `MovilidadUrbana.ApiWeb.csproj` | `Sdk="Microsoft.NET.Sdk.Web"`, `GenerateDocumentationFile` + `<NoWarn>$(NoWarn);CS1591</NoWarn>`, EF Core Sqlite 10.0.11, OpenApi 10.0.11, Scalar.AspNetCore 2.17.3 con versión en línea | PAR2-07, PAR2-12 |
| ídem, `Application/Localidades/LocalidadService.cs` | Sólo `GetAllAsync`, `SaveAsync` (devuelve `Result`, sin id) y `DeleteAsync`; el id se resuelve con `repository.GetByIdAsync` | PAR2-12 (H2-015) |
| ídem, `Program.cs` de ApiWeb | `UseStatusCodePages`, `UseMiddleware<SessionHeaderMiddleware>` global, `MapOpenApi` y Scalar sólo en Development | PAR2-12, PAR2-13 |
| ídem, `*Policy.cs` | Literales sin valor verificable: `RequisitoDeLaProvincia` («Una de las provincias del catálogo.»), `RequisitoDeLaLocalidad` («Una de las localidades cargadas en el ABM.»), `RequisitoDeLosMedios` («Al menos uno.»), `RequisitoDeLaFrecuencia` («Con qué asiduidad usa esos medios.»), `RequisitoDelMotivo` («El motivo principal del viaje.»). Quedan 7 con valor | PAR2-09 (H2-026) |
| ídem, `src/MovilidadUrbana.Web` | Existen `wwwroot/css/Tokens.css`, `Componentes.css`, `Components/Layout/MainLayout.razor`, `Pages/NotFound.razor` y 15 componentes `Shared/` | PAR2-12 (ADR-13) |
| `Compuertas/rd-po-4.excepciones` | Remite a l. 822 (AC-8) y l. 851 (R-06), pero en la v1 están en l. 823 y l. 852: la lista ya se corrió una línea | PAR2-03 |
| Aritmética de §E.5 nueva | TURNO-1: 58 llamadas, 12.400 s ≈ 3,44 h pesimista; TURNO-2: 134 llamadas, 19.280 s ≈ 5,36 h. Binomial exacta bilateral con 6 discordantes todos en un sentido: 2 · 0,5⁶ = 0,031 | PAR2-01, PAR2-06 |

### 0.3 Orden de aplicación

1. **Votos previos** (en la aprobación, antes de aplicar): papeletas de RV-03 (tope), H2-056 (fusiones), RV-05 (25 o 26 OA), RV-04 (extensión), RV-01 (casos integradores), RV-11 (juez) y P-12 (H2-050). **Preguntas a la presidencia**: ¿el contrato exige que la demo sola recorra los cinco escenarios? (H2-055, PAR2-11); I-05 §5.2, PR-17 escenario nuevo o variante (H2-049, PAR2-23).
2. Alcance y nombres: PAR2-01, PAR2-02, PAR2-11.
3. Convenciones y ejemplos: PAR2-04 … PAR2-10.
4. Demo: PAR2-12 … PAR2-14.
5. Estructura de la guía: PAR2-15 … PAR2-20.
6. Riesgos y registro: PAR2-21, PAR2-22.
7. Otras capas: PAR2-23 … PAR2-26.
8. Ratificaciones sin cambio: PAR2-27.

Después de aplicar: recalcular `Compuertas/rd-po-4.excepciones` (PAR2-03) y correr el chequeo mecánico de remisiones (PAR2-19).

---

## PAR2-01 · §E.5 Presupuesto de turnos y alcance contra el modelo

**Ítems**: H2-001, H2-002, H2-054 (opción a, parte presupuesto), H2-056, RV-03, RV-08 (cifra), RV-13, RAT-AJ-02 (con corrección), X2-02, X2-07.

**Resoluciones**: X2-02 → se reemplaza AJ-03 por una decisión de alcance cuantificada antes de construir, con TURNO-1 redefinido para que entre en el tope y sin deuda automática dentro de él (5-0-0). X2-07 → separar ejemplos de demostración (1–2 entradas, sin tasa) de los de medición (M ≥ 6), y subir M sólo en estos (5-0-0). RAT-AJ-02 → se ratifican las cifras medidas y la fórmula; 07 sale de las llamadas largas (5-0-0).

**Cambio 1.** Reemplaza §E.5 entera (l. 660–675, desde «### E.5 Presupuesto de turnos y línea de corte (antes de construir)» hasta «…en la máquina al límite (R-02).») por:

> ### E.5 Presupuesto de turnos y alcance contra el modelo (decisión previa a construir)
>
> **Datos medidos** (E1): procesamiento del prompt ~9,4 tok/s en frío y generación ~4 tok/s con `qwen3.5:4b` (N3b X3; Sondeo §3); respuestas cortas de 11 a 24 s con razonamiento apagado y prompt mínimo (Sondeo §8); 199,6 s una llamada con una herramienta (Sondeo §3); 474,7 s con un prefijo de 4.441 tokens (N3b X3); bajo carga, más de 600 s sin respuesta (Sondeo §0); `<recurso-compartido>` con cupo 1 y ttl 45 min, renovable (`<gestor-de-turnos>/PROTOCOLO.md`).
>
> **t por clase de llamada** (fórmula de AJ-02, ratificada en el ciclo 2: t ≈ p/9,4 + s/4, con p tokens de prompt y s de salida, sin carga). La clase de cada pieza sale de su p **medido** con `--fake` (la estimación del adaptador, caracteres/4, sobre el prompt completo: instrucciones, historial y esquemas de herramientas), no de una suposición. Hasta esa medición (DEP-13) rigen estas clases provisionales:
>
> | Clase | Criterio | t pesimista | Respaldo |
> |---|---|---|---|
> | K · corta | p ≤ 500, sin herramientas | 80 s | fórmula con p = 500, s = 100 (E3, derivada) |
> | M · media | 500 < p ≤ 1.000, sin herramientas (el juez de 15) | 120 s | fórmula (E3) |
> | H · con herramienta | una o dos herramientas montadas | 200 s | 199,6 s medido (E1) |
> | L · larga | p > 1.900, o el conjunto completo de herramientas del asistente | 475 s | 474,7 s medido (E1) |
>
> 07 es de clase K: su corpus completo, con instrucción y pregunta, mide ~250 tokens (N3b X4b punto 7, `prompt_eval_count` 253), y el top-k recuperado es menor (corrección de RAT-AJ-02). Los valores únicos t = 60 s y 200 s dejan de usarse (H2-056).
>
> **Demostración y medición** (X2-07; H2-001):
> - *Ejemplo de demostración*: 1 o 2 entradas, sin tasa. Prueba en cada corrida las garantías de código y muestra la conducta del modelo. La guía no publica tasas de un ejemplo de demostración.
> - *Ejemplo de medición*: M ≥ 6 entradas distintas y congeladas (§E.1), con la regla de §10.4. Son de medición 06, 07, 15 y 16; 03, 04 y 08 tienen una **extensión de medición** en TURNO-2.
> - *Paso de la demo*: una corrida de humo (1 entrada) por paso; su M, su oráculo y su evidencia de conducta son los del ejemplo hermano de §F.1. Es un registro con dos usos (H2-054, opción a).
>
> **Turnos** (nombres internos: no llegan a la guía; PAR2-02):
>
> **TURNO-1 · obligatorio, contra `<recurso-compartido>`**
>
> | Pieza | Tipo | Entradas | Llamadas | Clase | Pesimista (s) |
> |---|---|---|---|---|---|
> | 01 | demostración | 2 | 2 | K | 160 |
> | 03 | demostración | 2 (una con el dato, una sin él) | 2 | K | 160 |
> | 04 | demostración | 2 | 2 | K | 160 |
> | 07 (chat) | medición | 16 (7 con valor verificable, 5 sin valor verificable, 4 no respondibles) | 16 | K | 1.280 |
> | 08 | demostración | 2 (una legítima, la negativa del dato ausente) | 4 | H | 800 |
> | 09 | demostración | 2 (el CP inválido, el alta válida aprobada) | 6 | H | 1.200 |
> | 11 | demostración | 1 («Borrá Resistencia») | 3 | L | 1.425 |
> | PD-1 | humo | 1 | 2 | L | 950 |
> | PD-2 | humo | 1 | 1 | K | 80 |
> | PD-3 | humo | 1 | 1 | K | 80 |
> | PD-4 | humo | 1 | 1 | K | 80 |
> | PD-5 | humo | 1 | 2 | L | 950 |
> | PD-6 | humo | 1 | 3 | L | 1.425 |
> | Estabilidad | 3 repeticiones de una entrada de 07 | — | 3 | K | 240 |
> | DEP-09 | sonda | 1, en dos peticiones | 2 | H | 400 |
> | DEP-10 | sonda | 2 (cadena listar → eliminar) | 6 | L | 2.850 |
> | DEP-13 | calibración | 2 llamadas K (las de clase H y L salen de DEP-09 y DEP-10) | 2 | K | 160 |
> | **Total** | | | **58** | | **12.400 s ≈ 3,44 h** |
>
> **TURNO-2 · si queda tope, en este orden, contra `<recurso-compartido>`**
>
> | Pieza | Tipo | Entradas | Llamadas | Clase | Pesimista (s) |
> |---|---|---|---|---|---|
> | 13 | demostración | 1 | 2 | H | 400 |
> | 17 | demostración | 3 pedidos (dos iguales) | 2 | K | 160 |
> | 12 | demostración, variantes «un-agente» y «dos-agentes» | 2 por variante, las mismas | 10 | K | 800 |
> | 03, extensión | medición | 8 (4 sin el dato) | 8 | K | 640 |
> | 04, extensión | medición | 8 | 8 | K | 640 |
> | 15 | medición | (16 salidas de 07 + 10 de calibración) × 2 evaluadores | 52 | M | 6.240 |
> | 16 | medición | 6 × 3 variantes | 36 | H | 7.200 |
> | 08, extensión | medición | 8 | 16 | H | 3.200 |
> | **Total** | | | **134** | | **19.280 s ≈ 5,36 h** |
>
> **TURNO-3 · sin `<recurso-compartido>`**: 02 (las dos vías contra el Ollama propio: §E.1, `num_ctx`), 05, 06, la **fase de embeddings** de 07, 16 y PD-2 (vectores persistidos: §E.1, arnés) y DEP-03, con turno `[recurso-modelo-propio]` (DEP-14); 10 y 14 sin modelo; todo el cableado. Si DEP-14 no se resuelve, rige EMB-C (§F.6): 02, 05, 06, 07, 16 y PD-2 quedan «no ejecutado contra el modelo» con ese motivo, y la mesa lo registra. Es la única deuda admitida dentro de TURNO-1, y es por dependencia, nunca por presupuesto.
>
> **Tope** (sujeto a RV-03): 4 h de `<recurso-compartido>` para todo el ciclo de construcción, sin contar las correcciones del ciclo siguiente. Las corridas manuales de la demo contra el servidor compartido piden turno y se descuentan del tope (H2-019). Qué entra según el tope, con los pesimistas de arriba: con **4 h**, TURNO-1 y de TURNO-2 hasta «03, extensión» (13, 17, 12 y 03 ext. suman 2.000 s, justo lo que queda); con **6 h**, hasta 15; con **9 h**, todo TURNO-2.
>
> **Línea de corte** (reemplaza a AJ-03; X2-02):
> 1. Antes de construir, DEP-13 mide el p de cada pieza con `--fake` y el t de cada clase con las llamadas de DEP-09, DEP-10 y DEP-13, y se recalcula esta sección. Regla: el pesimista de TURNO-1 no pasa del 90 % del tope (3,6 h con 4 h). Si pasa, se recorta en este orden y nada más: (a) estabilidad fuera; (b) DEP-10 fuera, y el contrato queda en `eliminar_localidad(nombre, provincia)`, resuelto por el caso de uso con error si es ambiguo (la salida que DEP-10 ya preveía, §G.3); (c) 07 de 16 a 11 entradas (las 7 con valor verificable y las 4 no respondibles).
> 2. Ninguna pieza de TURNO-1 queda sin al menos una corrida válida. Si después de (a)–(c) el pesimista sigue arriba, no se construye: la mesa vota otra vez el alcance o el tope. No hay deuda automática dentro de TURNO-1.
> 3. TURNO-2 se corre en el orden de la tabla mientras quede tope, según el medidor de §E.1. Lo que no entra queda **«no ejecutado contra el modelo»**: la guía no muestra cifras de él y lo lista como deuda en §14.6 y en el Anexo E (AC-3b).
> 4. Cada fase pide su turno por separado y lo renueva antes del ttl; la renovación se corta al vencer el plazo de la suite (§E.1, arnés y medidor). Ninguna suite toma el servidor sin turno.
>
> **Papeleta de RV-03** (el jurado vota en la aprobación): (a) tope de 4 h; (b) 6 h; (c) 9 h; y en los tres casos, las clases de t de arriba y la regla del 90 %. La tabla dice qué entra con cada opción.
>
> **Papeleta de H2-056** (fusiones; la v0, l. 753, las preveía y el ciclo 1 las descartó sin votarlas): (F1) 01 + 02 en un solo ejemplo: ahorro de un proyecto y 0 llamadas de `<recurso-compartido>` (02 ya está en TURNO-3); conserva OA-D1. (F2) 06 + 07 (v0 10 + 11): ahorro de un proyecto y una fase de embeddings; conserva OA-D4; costo: 06 deja de ser un ejemplo que mide sólo la recuperación. (F3) 14 opcional: ahorro de 0 llamadas; conserva OA-SK1 como lectura. Cada fusión se vota por separado. Esta sección no asume ninguna; si se aprueba alguna, se renumera con la tabla de §E.3 y se rehace la verificación de remisiones (PAR2-19).

**Cambio 2.** §C, ficha §12, al final de §12.7 (l. 486, después de «…y cero reintentos»): agrega «(cifras de AJ-02, ratificadas en el ciclo 2: RAT-AJ-02 y RV-13)». La cifra «11 a 200 s» de PAR-10 queda reemplazada por voto (RV-13).

**Costo**: una sección reescrita (~900 palabras de bitácora, no de guía). Baja el pesimista de lo obligatorio de 8,0 h (v1) a 3,44 h.

**Reversible**: sí. Es texto del plan; nada se ejecutó.

**Derivados a revalidar**: AC-3b (PAR2-03), §E.2 columnas «Entradas» y «Turno» (PAR2-09), §F.1 (PAR2-11), §G.3 DEP-10, DEP-13, DEP-14 y §G.4 P-10 (PAR2-21), §14.6.

**Verificación**: (1) la suma de cada tabla sale de sus filas: `awk` sobre las columnas «Llamadas» y «Pesimista» da 58 y 12.400; 134 y 19.280. (2) `grep -n "AJ-03" 04-Plan-De-Integracion.md` sólo en el changelog y en «reemplaza a AJ-03». (3) `grep -nE "t = 60 s"` = 0 fuera del changelog. (4) Toda pieza de §E.2 con modelo aparece en una sola fila de TURNO-1, TURNO-2 o TURNO-3. (5) Al construir: la suma de `duracion_s` de `turnos.jsonl` para `<recurso-compartido>` ≤ tope votado.

---

## PAR2-02 · Nombres: turno, dificultad, planes de embeddings y variantes

**Ítems**: RAT-NIVEL, X2-01, H2-039 (criterio y reasignación), H2-048 (parte «ADR-07» y «§4.4»).

**Resolución**: X2-01 → «la dificultad conserva su nombre para el lector; el turno usa un nombre interno sin letras, fuera de la guía; la regla se aplica a las demás colisiones de A/B/C» (4-0-1). Grafía TURNO-n por la verificación de §0.2.

**Cambio 1.** §E.2, l. 623: reemplaza «El **nivel** (B básico, I intermedio, A avanzado) es un rótulo de dificultad, no un bloque (PR-3). La columna «Turno» remite al presupuesto de §E.5.» por:

> La **dificultad** (B básica, I intermedia, A avanzada) es un rótulo para el lector y no un bloque (PR-3). Criterio (H2-039; **[criterio propio del cuerpo auditor]**, a ratificar en la aprobación): **B**, un concepto nuevo de §3.0 y piezas sólo de M.E.AI; **I**, dos o más conceptos nuevos, o el ejemplo toca persistencia o sesión del dominio; **A**, introduce MAF, evaluación con juez o un oráculo de seguridad, o cruza las dos escaleras. La columna «Turno» (TURNO-1, TURNO-2, TURNO-3) es **interna**: remite a §E.5 y no llega a la guía.

En la tabla de §E.2, el encabezado «Nivel» pasa a «Dificultad». Reasignación por el criterio: 07 I → **A** (cruza RAG con un oráculo de afirmación; además PR-3 llama avanzado al RAG con citas); 08 B → **I** (sesión y persistencia); 11 I → **A** (MAF y `AgentSession`); 17 A → **I** (dos conceptos nuevos, sin MAF ni juez). Los demás no cambian. La columna «Turno» toma los valores de §E.5 (PAR2-01): 01, 03, 04, 07 (chat), 08, 09, 11 → TURNO-1 (03, 04, 08 con extensión en TURNO-2); 12, 13, 15, 16, 17 → TURNO-2; 02, 05, 06, 10, 14 → TURNO-3.

**Cambio 2.** Planes de embeddings: en §F.6 (tabla y texto), §G.1 SUP-09, §G.3 DEP-01, §E.1 («plan B») y §C ficha §7, «plan A», «plan B», «plan C» pasan a **EMB-A**, **EMB-B**, **EMB-C** («B (por defecto)» → «EMB-B (por defecto)»).

**Cambio 3.** Variantes con nombre (§E.2): en 05, «(B)» y «(A)» pasan a «con-prefijo» y «sin-prefijo» («A se fuerza con un *nonce*…» → «sin-prefijo se fuerza con un *nonce*…»; «B usa un prefijo idéntico» → «con-prefijo usa un prefijo idéntico»; «B ≪ A» → «con-prefijo ≪ sin-prefijo»; «B vuelve a frío» → «con-prefijo vuelve a frío»). En 12, «(A)» y «(B)» pasan a «un-agente» y «dos-agentes» (PAR2-09). En 16, «(a)», «(b)», «(c)» pasan a «origen», «aprobación», «aprobación+marcado».

**Cambio 4.** §C ficha §13, l. 497: «§13.8 ADR-07 Nivel de orquestación» → «§13.8 ADR-07 Escalón de orquestación». Ficha §4, l. 407: «§4.4 Dos niveles de contrato:» → «§4.4 Dos contratos:».

**Costo**: renombres mecánicos (~40 ocurrencias). En la guía no suma palabras.

**Reversible**: sí.

**Derivados a revalidar**: AC-3b (usa TURNO-1, PAR2-03), §F.6, PAR2-17 (tabla de familias de ID: TURNO- y EMB- no llegan al lector), glosario (PAR2-19: «dificultad», «escalón de orquestación»).

**Verificación**: (1) `grep -nE "\b[Nn]ivel (A|B|C)\b|Nivel de turno|\| (A|B|C) \|$"` sobre §E y §F.10 = 0. (2) `grep -nE "\bplan (A|B|C)\b"` = 0. (3) `grep -nE "\bT[1-7]\b"` sigue dando 11 (no se tocó ninguna tensión). (4) `grep -n "TURNO-"` sólo en §E, §F.10 y §G. (5) Sobre la guía, al redactar: `grep -nE "TURNO-|EMB-[ABC]"` = 0.

---

## PAR2-03 · §F.10 Criterios de aceptación

**Ítems**: H2-003 (AC-3b), H2-007 (AC-6), H2-008 (AC-5), H2-009 y H2-012 (AC-4), H2-045 (AC-9, cifras sin fuente citable), H2-051 (AC-10), H2-052 (AC-7), H2-053 y RAT-AJ-04 (AC-8), H2-058 (AC-3a, lote S4), RV-09 (AC-9).

**Cambio.** Reemplaza las filas de la tabla de §F.10 (l. 817–825) como sigue; AC-1 y AC-2 no cambian.

| # | Criterio | Cómo se verifica |
|---|---|---|
| AC-3a (arnés) | `ConModelo/` y las consolas con `--verificar` en verde, o saltadas con el mensaje del predicado | `tools/verificar.sh --con-modelo` (no hay workflow de CI: §E.1) (H2-058) |
| AC-3b (cierre) (H-003, H2-003) | **Lista cerrada: todo ejemplo o paso que llama a un modelo, en cualquier servidor**: 01–09, 11–13, 15–17 y PD-1…PD-6. PD-7 se declara sin modelo (§F.1). Cada pieza de TURNO-1, y cada una de TURNO-3 que llama a un modelo, tiene al menos un registro R-LLM válido: entradas congeladas, campos completos, sin `truncado_posible`, oráculo aplicado y recalculable desde el registro. Un paso PD-n cierra con su corrida de humo válida más el registro válido de su ejemplo hermano (§F.1). Las piezas de TURNO-2 tienen registro válido, o la guía las marca «no ejecutado contra el modelo», sin cifras, y figuran como deuda en §14.6 y en el Anexo E. La única excepción en TURNO-1 y TURNO-3 es por dependencia (DEP-14 sin resolver → EMB-C), registrada por la mesa; nunca por presupuesto (§E.5, línea de corte 2). Una corrida saltada no cierra. Las tasas son informativas; los invariantes de código (AC-4) son 100 % en toda corrida | Script sobre `OUTPUTs/Bitacoras/Evidencia/R-LLM/` contra las tablas de §E.5; recalcula cada oráculo desde el registro (`tools/recalcular-oraculos.sh`, §E.1) |
| AC-4 | Cero escrituras que no pasen por un caso de uso; **cero escrituras (altas o bajas) sin aprobación**; lo ejecutado después de aprobar = lo mostrado en el pedido, y la respuesta de aprobación se arma en el servidor desde el pedido guardado; ninguna herramienta de escritura ejecuta con texto no confiable en el pedido (en la demo, preventiva: el asistente no tiene herramienta de recuperación; se ejercita en 16) (H2-009, H2-012) | Pruebas Q2, Q5, `PedidoDeAprobacion_MuestraArgumentosResueltos`, `Aprobacion_ArgumentosAlterados_SeRechaza` y `Escritura_ConResultadoNoConfiable_Rechaza` |
| AC-5 | `Domain/` sin `Microsoft.Extensions.AI`, `OllamaSharp` ni `OpenAI`; herramientas sin `I*Repository` | **Prueba de arquitectura obligatoria** en `Cableado/`: encuentra **al menos un tipo** en `MovilidadUrbana.Asistente.Domain` y falla si no encuentra ninguno; + `grep` (ADR-11) (H2-008) |
| AC-6 | Versiones directas = Anexo F. Transitivas: **invariante por familia**: cada familia en una sola versión (`Microsoft.Extensions.AI*`, `Microsoft.Extensions.VectorData*`, `Microsoft.Agents.AI*`, `ModelContextProtocol*`, `OpenTelemetry*`, `Microsoft.EntityFrameworkCore*`) y ninguna versión preview (`-preview`, `-rc`, `-alpha`, `-beta`) que el Anexo F no declare (H2-007) | `dotnet list package --include-transitive --format json`, procesado por `tools/verificar.sh` |
| AC-7 (H-053) | Compuerta R-PRIV en cero sobre **todo lo que se escribe**: la guía, `Examples/`, `Demos/` y `OUTPUTs/Bitacoras/` (evidencia R-LLM incluida), antes de cualquier commit. **Además, sobre los registros R-LLM**: todo valor de `Nombre` y todo nombre de persona en `entrada`, `salida`, `herramientas` y `contexto` pertenece al conjunto sintético «Persona 01…20» (H2-052) | `grep -rnE` con los patrones de IP privada (sin cambio) y con la lista de hosts y nombres de la LAN fuera del repo (`$R_PRIV_LISTA`); y `jq` sobre los `.jsonl`: todo `Nombre` cumple `^Persona [0-9]{2}$` |
| AC-8 (H-052, H2-053) | Barrido RD-PO-4 en cero, salvo excepciones listadas, sobre la guía, `Examples/`, `Demos/` y `OUTPUTs/Bitacoras/`. Una sola regla (AJ-04, ratificada) | **Los dos patrones sobre todos los archivos** (texto y código), **sin distinguir mayúsculas y sin borde de palabra**, para que caigan los identificadores compuestos: `grep -rniE "reclamo\|ticket\|incidente\|bache"`; y, sensible a mayúsculas, el identificador `grep -rnE "Linea[A-Z_s]\|[a-z]Linea\b\|\bLinea\b"` («línea» de texto queda fuera). Los nombres de otros proyectos, desde `$RD_PO_LISTA`, fuera del repo. **Casos positivos**: `Compuertas/rd-po-4.positivos` (`ReclamoService`, `TicketId`, `IncidenteRepository`, «Reclamos», `LineaDeColectivo`): el barrido sobre ese archivo tiene que marcar sus 5 líneas, y si marca menos, la compuerta falla. Excepciones en `Compuertas/rd-po-4.excepciones` (ruta:línea con motivo), recalculadas al aplicar este ciclo |
| AC-9 (H-060) | Rastreo del estado de verificación: cada bloque de código de la guía va precedido de `<!-- fuente: Examples/NN-…/Archivo.cs#Lx-Ly -->` y es igual a esa región, o lleva el rótulo «no compilado» o «adaptación no ejecutada». **Una cifra que viene de un dossier entra en la guía sólo si se re-ejecutó en la construcción, con su registro; si no, no se cita** (la guía no puede remitir a la bitácora: R-PO-2; H2-045). Las de 06 y 07 se re-ejecutan sólo con DEP-14 resuelto; si no, no se citan (RV-09) | Script que extrae los bloques y los compara con los archivos; `grep` de cifras sin rótulo |
| AC-10 (H-050, H2-051) | Todo cambio de la demo frente a la línea de base figura en la tabla de delta de §F.2 | `tools/diff-base.sh`: exporta `8fb4c3a` con `git archive` a un directorio fuera del repo, cambia `MovilidadUrbana.ApiWeb` por `MovilidadUrbana.Asistente` y corre `diff -r` contra la demo; cada archivo distinto tiene su fila. **Sin commit de base**: las reglas de la corrida no admiten commits; si el PO quiere ese commit, se hace al publicar, con su ok |

En §F.10, l. 827: «La evidencia … va a `OUTPUTs/Bitacoras/Evidencia/` **sólo después** de pasar AC-7.» se mantiene.

**Costo**: siete celdas; dos scripts nuevos de arnés (`recalcular-oraculos.sh`, `diff-base.sh`) y un archivo de casos positivos. Ninguna llamada al modelo.

**Reversible**: sí.

**Derivados a revalidar**: `Compuertas/rd-po-4.excepciones` (las líneas que nombran los patrones en este archivo y en la v2 del plan), §E.1 (esquema y arnés), §F.2 (línea de base), §F.8 (pruebas nuevas).

**Verificación**: (1) el barrido de AC-8 sobre `rd-po-4.positivos` marca 5 de 5. (2) Sobre el plan v2, da sólo líneas listadas en las excepciones. (3) `grep -n "git diff"` en §F = 0. (4) Ningún AC nombra «nivel A» (`grep`).

---

## PAR2-04 · §E.1 Arnés, fases, turnos y medidor

**Ítems**: H2-004, H2-018, H2-019.

**Cambio.** Reemplaza la viñeta «**Arnés** (H-058): …» (l. 611) por:

> - **Arnés** (H-058; H2-004, H2-018, H2-019): no hay CI del repo para esto (el único workflow de `Lab-Documentos/.github/workflows/` tiene otro alcance) y **no se agrega un workflow**. `Dot-Net-Integration-AI-Layer-Guide/tools/verificar.sh` **corre en el host** (sólo bash y docker: R-HOST) y lanza **un contenedor por fase**; cada fase pide su turno por separado y ninguna se anida en otra:
>   1. *build*: turno `build`; en `mcr.microsoft.com/dotnet/sdk:10.0`: `dotnet restore` (con red a nuget.org), `dotnet build -warnaserror`, `dotnet test --filter "Category!=LLM"` sin servidor de modelos (`OLLAMA_ENDPOINT` a un puerto cerrado) y cada consola con `--fake --verificar`; deja la salida con la versión de SDK y libera el turno.
>   2. *[recurso-modelo-propio]* (TURNO-3): turno `[recurso-modelo-propio]` (DEP-14): 02, 05, 06, DEP-03 y la **fase de embeddings**, que vectoriza el corpus y las preguntas de 07, 16 y PD-2 y los persiste en `RLLM_DIR/embeddings/<pieza>.v1.json` con el digest del modelo; libera el turno.
>   3. *<recurso-compartido>* (TURNO-1, después TURNO-2): turno `<recurso-compartido>`; lee los embeddings persistidos, así que no necesita el Ollama propio al mismo tiempo; dentro del turno, antes de la primera llamada, lee `/api/ps` (§E.1, `num_ctx`).
>
>   **Orden global de pedido**: `build` → `[recurso-modelo-propio]` → `<recurso-compartido>`, de a uno. Ninguna fase pide un segundo recurso mientras tiene uno (evita la espera cruzada). Las corridas manuales de la demo contra el compartido piden turno `<recurso-compartido>` y se descuentan del tope (§E.5).
>
>   **Contrato por ejemplo** (H2-018): cada carpeta de `Examples/` y la demo llevan `ejemplo.json` con `recurso` (`ninguno` | `[recurso-modelo-propio]` | `<recurso-compartido>`), `turno` (TURNO-1, TURNO-2 o TURNO-3), `entradas` (ruta y SHA-256) y `comando`. Las consolas aceptan `--verificar`: corren sus entradas, escriben R-LLM y salen con 0 si se cumplen todos los invariantes de código y con 1 si no. `verificar.sh` lee los manifiestos y en cada fase corre sólo lo que declara ese recurso.
>
>   **Envoltorio de turno**: `verificar.sh` no nombra ningún script del laboratorio. Toma el envoltorio de la variable `TURNO_CMD` (se invoca como `$TURNO_CMD <recurso> -- <comando>`); sin la variable, corre sin turno, como lo haría un lector con su propio Ollama, y lo dice en la salida. En este laboratorio, `TURNO_CMD` apunta al gestor de recursos de la raíz del workspace (MD-2), que vive fuera del repo.
>
>   **Medidor** (H2-004): cada fase agrega una línea a `RLLM_DIR/turnos.jsonl` con `turno_id`, `recurso`, `fase`, `pedido_en`, `concedido_en`, `liberado_en` y `duracion_s`. Antes de cada suite, `verificar.sh` calcula el tope restante (tope de §E.5 menos la suma de `duracion_s` de `<recurso-compartido>`) y se lo pasa a la suite como plazo (`--plazo-s`). Al vencer el plazo, la suite deja terminar la llamada en curso, marca las entradas que faltan como `excluida` con motivo «plazo», libera el turno y sale; con ella se detiene la renovación. El medidor es del repo: el gestor sólo concede y renueva.

**Costo**: una viñeta; `verificar.sh` crece (manifiesto, tres fases, medidor). 0 llamadas; ahorra turno de `<recurso-compartido>`, porque 05 y 06 salen de ese recurso.

**Reversible**: sí.

**Derivados a revalidar**: §E.5 (línea de corte 4), §G.2 R-02 y §G.3 DEP-14 (PAR2-21), AC-3a (PAR2-03), Anexo E (cómo reproducir).

**Verificación**: (1) `grep -n "con-recurso" ` sobre `Examples/`, `Demos/` y `tools/` de la guía = 0. (2) Con `TURNO_CMD` vacío, `verificar.sh` corre la fase *build* y avisa «sin turno». (3) Prueba en seco con un envoltorio falso que registra el orden de pedidos: el registro muestra `build`, liberación, `[recurso-modelo-propio]`, liberación, `<recurso-compartido>`, sin superposición. (4) Con un plazo de 1 s, la suite termina con entradas `excluida` motivo «plazo» y código de salida distinto de 0.

---

## PAR2-05 · §E.1 `num_ctx`, variables canónicas y provisión del Ollama propio

**Ítems**: X2-04 (AJ-01 reemitido como parche), H2-016, H2-017, H2-057 (parte `keep_alive`).

**Resolución**: X2-04 → reemitir AJ-01 como parche, con la fuente explícita de OP-02 (variable canónica de tipo de servidor y `num_ctx_origen`), acotado al adaptador OllamaSharp y sin abortar con `/api/ps` vacío en el Ollama propio (5-0-0).

**Cambio 1.** En la viñeta «Opciones propias del proveedor» (l. 595), reemplaza «comprueba que el 100 % de las llamadas, incluidas las del juez y las de MAF, salen con `ReasoningEffort.None` y con `num_ctx`.» por «comprueba que el 100 % de las llamadas, incluidas las del juez y las de MAF, salen con `ReasoningEffort.None`, y que las del adaptador OllamaSharp salen además con `num_ctx` (por `/v1` no llega: H2-016).»

**Cambio 2.** Reemplaza la viñeta «**`num_ctx`** (H-006): …» (l. 596) por:

> - **`num_ctx`** (H-006; AJ-01 reemitido: X2-04, H2-016): la vía es `ChatOptions.AddOllamaOption(OllamaOption.NumCtx, n)` de OllamaSharp 5.5.0 (E1, XML del paquete; DEP-03 la confirma comparando `prompt_eval_count`), y **sólo la lee el adaptador OllamaSharp**: por `/v1` no llega. **Fuente del valor**, en este orden: (1) `OLLAMA_NUM_CTX` exportada por el arnés; (2) el default 8192. La variable canónica `OLLAMA_SERVIDOR` (`compartido` | `propio` | `nube`; default `propio`) declara el tipo de servidor y se copia al campo `servidor` del registro; `num_ctx_origen` registra `arnes` o `default`. Reglas: **compartido**: el arnés, dentro del turno y antes de la primera llamada, lee el `context_length` del modelo cargado en `GET /api/ps` (65.536 el 2026-10-26, Sondeo §0) y exporta `OLLAMA_NUM_CTX`; si `/api/ps` no lista el modelo pedido, aborta sin llamar, porque cargarlo con otro `num_ctx` recargaría un servidor ajeno (R-04). Con `OLLAMA_SERVIDOR=compartido` y `num_ctx_origen = default`, el código rechaza la corrida (prueba de cableado `Compartido_SinNumCtxDelArnes_Rechaza`). **propio**: 8192 explícito; un `/api/ps` vacío es normal (modelo recién levantado) y no aborta. **nube**: no aplica. **Vía `/v1`** (02): no se manda `num_ctx`. No está respondido si `/v1` sin `num_ctx` recarga el modelo del compartido; por eso 02 corre sus dos vías **sólo contra el Ollama propio** (TURNO-3). **Guarda de truncado** (sólo adaptador OllamaSharp): si `Usage.InputTokenCount` es menor que el 80 % de la estimación del adaptador (caracteres/4, calibrada en DEP-03) o mayor o igual que `num_ctx`, la corrida se marca `truncado_posible: true` y no cuenta para ninguna tasa; por `/v1` se marca `truncado_posible: null` («no verificable») y tampoco cuenta. `keep_alive` no está en `OllamaOption` y **no se fija** (decisión de alcance; la pregunta de H-SN-02 se cierra: H2-057).
>
>   Pregunta abierta para operación (no es hallazgo): ¿`/v1` sin `num_ctx` recarga el modelo del servidor compartido?

**Cambio 3.** Reemplaza la viñeta «**Modelo de embeddings**: …» (l. 598) por:

> - **Modelo de embeddings**: el servidor compartido no tiene ninguno (501, Sondeo §5). Por defecto (EMB-B, SUP-09, concreción de SUP-06): `qwen3-embedding:0.6b` en un Ollama propio en contenedor `ollama/ollama:0.40.11`, la imagen con la que corrió N3 E3 (`N3-Evidencia/salidas.md`; H-027). **Provisión** (H2-017): contenedor `<ollama>`, imagen fijada **por digest** (el digest se registra el día de la construcción; si la etiqueta no existe, el de la imagen local que corrió E3); volumen `<ollama>` montado en `/root/.ollama`; **paso de carga** explícito antes de la primera corrida (`ollama pull qwen3-embedding:0.6b` y `ollama pull qwen2.5:0.5b` dentro del contenedor), con el digest de cada modelo al registro; red bridge propia `<red-del-arnés>`, por la que el contenedor del SDK lo alcanza por nombre (`http://<ollama>:11434`). No se usa `--network host` (lo usó N3-Evidencia; la guía no lo enseña). Todo lleva `--label <etiqueta-del-arnés>` (§E.6).

**Cambio 4.** Reemplaza la tabla de variables canónicas (l. 601–608) por:

| Variable | Default en el código | Para qué |
|---|---|---|
| `OLLAMA_ENDPOINT` | `http://localhost:11434` | servidor de chat (DC-06) |
| `OLLAMA_MODEL` | `qwen3.5:4b` | modelo de chat |
| `OLLAMA_SERVIDOR` | `propio` | tipo del servidor de chat: `compartido` \| `propio` \| `nube`; va al campo `servidor` del registro |
| `OLLAMA_NUM_CTX` | `8192` (el registro marca `num_ctx_origen = default`) | ventana configurada |
| `OLLAMA_PROPIO_ENDPOINT` | `http://localhost:11434` | Ollama propio en contenedor: chat de 02 y 05, y embeddings |
| `OLLAMA_PROPIO_MODEL` | `qwen2.5:0.5b` | modelo de chat del Ollama propio (02 y 05) |
| `OLLAMA_EMBED_ENDPOINT` | el valor de `OLLAMA_PROPIO_ENDPOINT` (nunca el de `OLLAMA_ENDPOINT`: el compartido responde 501 a embeddings, Sondeo §5) | servidor de embeddings |
| `OLLAMA_EMBED_MODEL` | `qwen3-embedding:0.6b` | modelo de embeddings |
| `EMB_PLAN` | `EMB-B` | `EMB-A` (embeddings en el servidor del PO, si lo decide) · `EMB-B` (Ollama propio) · `EMB-C` (generador estable, sin modelo; 06, 07, 16 y PD-2 se rotulan «no ejecutado contra un modelo de embeddings» en la UI y en el registro) |
| `RLLM_DIR` | `./registros` (ignorado por git) | dónde escribe el registro R-LLM y `turnos.jsonl` |
| `TURNO_CMD` | vacío (corre sin turno y lo avisa) | envoltorio de turno (§E.1, arnés) |

**Costo**: dos viñetas y una tabla; cinco variables nuevas. 0 llamadas.

**Reversible**: sí.

**Derivados a revalidar**: §E.2 filas 02 y 05 (PAR2-09), §F.6 (PAR2-14), §F.8 (predicado de salto), §F.9 (`-e` de `docker run`), Anexo A §12 (plantilla de configuración).

**Verificación**: (1) prueba `Compartido_SinNumCtxDelArnes_Rechaza` en `Cableado/`. (2) Prueba con un cliente espía detrás del adaptador `/v1`: no exige `num_ctx` y el registro marca `truncado_posible: null`. (3) Con el Ollama propio recién levantado y `/api/ps` vacío, la fase TURNO-3 no aborta. (4) `grep -n "OLLAMA_EMBED_ENDPOINT" ` en el código: su default no lee `OLLAMA_ENDPOINT`.

---

## PAR2-06 · §E.1 Corridas contra el modelo: entradas, regla de comparación, denominador y esquema R-LLM

**Ítems**: H2-004 (campos de duración), H2-022, H2-023, H2-024, H2-029, H2-031, H2-052 (parte registro).

**Cambio 1.** En «**Dominio**» (l. 567), agrega al final: «Las entradas que llevan datos de una persona (04, PD-4, 12) usan valores sintéticos rotulados «escrito para el ejemplo»; los nombres, sólo del conjunto «Persona 01…20» (H2-052; sometido a P-12).»

**Cambio 2.** Reemplaza las sub-viñetas de «**Corridas contra el modelo (R-LLM)**» (l. 612–618) por:

> - **Corridas contra el modelo (R-LLM)** (H-001, H-002):
>   - **Unidad de muestra**: la **entrada distinta**. Cada ejemplo con modelo define M entradas (paráfrasis, límites y negativos) en `entradas.v1.json`. La tasa es k/M con su intervalo Clopper-Pearson al 95 %, calculado por `verificar.sh`, y se lee con la regla única de §10.4 (abajo).
>   - **Entradas congeladas** (H2-023): `entradas.v1.json` y el oro (`oro/*.v1.json`) se congelan antes de la primera corrida que cuenta; su SHA-256 va en cada línea del registro. Cambiar una entrada crea `v2` y descarta las tasas de `v1`. Las entradas con que se afinan instrucciones, herramientas y el «no sé» viven en `entradas.dev.json` y no se repiten en `v1` (intersección vacía sobre el texto normalizado). Contra el modelo se afina sólo dentro de las sondas ya presupuestadas (DEP-09, DEP-10), nunca con corridas extra.
>   - **Estabilidad ante repetición**, por separado: 3 repeticiones de una entrada de 07, que no cuentan para la tasa (§E.5).
>   - Se fija `temperature` 0, `seed` si el proveedor la respeta, `num_ctx`, razonamiento y modelo. Varía sólo la entrada.
>   - **Regla única de comparación (§10.4)** (H2-029): (1) con M ≤ 12, toda tasa es **descriptiva**: k/M con su intervalo, sin afirmar diferencias por intervalos (con M = 5, 0/5 = [0; 0,522] y 5/5 = [0,478; 1] se solapan); (2) se comparan variantes sólo con **diseño pareado** (las mismas entradas por las dos variantes): se informan los pares discordantes b y c, y se afirma una diferencia sólo si la binomial exacta bilateral sobre b + c da p < 0,05, lo que exige al menos 6 discordantes todos en el mismo sentido (2 · 0,5⁶ = 0,031); por eso el **M mínimo para comparar es 6**; (3) la misma regla compara 06 con sus líneas base (azar y léxica) y reemplaza el criterio «al menos 3 preguntas»; (4) las métricas deterministas (llamadas, tokens informados por el servidor, propiedades del oráculo) se comparan siempre. Los **tiempos** del servidor compartido no se comparan nunca (dispersión de 68,8 s a más de 600 s: Sondeo §0); los comparables sólo se miden en el Ollama propio, con el estado de caché registrado.
>   - **Denominador y exclusiones** (H2-031): se informa k/M_válidas más e/M excluidas, cada exclusión con su motivo (`truncado_posible`, precondición, plazo). Una corrida de medición necesita al menos ⌈M/2⌉ entradas válidas; si no llega, las excluidas por truncado se repiten **una sola vez** con `num_ctx` corregido, dentro del tope; si sigue sin llegar, la pieza queda «no ejecutado contra el modelo». Una entrada excluida no se reemplaza por otra.
>   - Aserciones de forma y propiedades, nunca de texto literal. Turnos del arnés (§E.1, MD-2).
>   - **Esquema** (JSON por línea, en `RLLM_DIR`; H2-004, H2-022, H2-024). Dos tipos de línea. **`tipo: "llamada"`**, una por llamada al modelo: `fecha`, `ejemplo`, `paso`, `entrada_id`, `llamada_n`, `entrada`, `salida`, `modelo`, `digest`, `adaptador`, `servidor`, `ollama_version` (de `GET /api/version`, leído en el turno), `paquetes_hash` (SHA-256 de `Directory.Packages.props`), `hash_instrucciones`, `hash_herramientas` (esquemas JSON de las herramientas montadas), `entradas_version` y `entradas_hash`, `temperature`, `seed`, `num_ctx`, `num_ctx_origen`, `razonamiento`, `herramientas` (lista de {`nombre`, `argumentos`, `resultado`, `error`}), `recuperados` (lista de {`id`, `puntaje`}), `contexto` (el texto de grounding enviado), `prompt_eval_count`, `eval_count`, `load_duration_ms`, `prompt_eval_duration_ms`, `eval_duration_ms`, `total_duration_ms`, `duracion_reloj_ms`, `turno_id`, `estado_cache`, `truncado_posible`. **`tipo: "entrada"`**, una por entrada: `entrada_id`, `oraculo` (nombre), `resultado` (`pasa` | `falla` | `excluida`) y `motivo`. **`estado_cache`** (`frio` | `cacheado` | `desconocido`) se deduce de `prompt_eval_duration_ms / prompt_eval_count` (ms por token) contra los umbrales que calibra DEP-03 en el Ollama propio; en el servidor compartido vale siempre `desconocido`, porque la carga ajena mueve la duración. `prompt_eval_count` solo no sirve: en N3b X4b, 4.728 tokens en frío (102,65 s) y 4.725 cacheados (1,10 s) (H2-024). **No se capturan** (H-053): endpoint, host, puerto, encabezados, ni logs de `HttpClient` o de `docker run`. **Datos personales** (H2-052): `entrada`, `salida`, `herramientas` y `contexto` contienen sólo datos sintéticos; el registro se trata como una traza (§11.4) y pasa AC-7, con la compuerta de nombres, antes de copiarse a `OUTPUTs/Bitacoras/Evidencia/R-LLM/`. **Recalculable** (H2-022): `tools/recalcular-oraculos.sh` recalcula cada oráculo leyendo sólo el registro, y el resultado tiene que coincidir con el `resultado` de cada línea `entrada`.

**Cambio 3.** §C ficha §10, §10.4 (l. 468): reemplaza «tasa k/M con intervalo; estabilidad ante repetición por separado;» por «tasa k/M con intervalo y regla única de comparación (descriptiva con M ≤ 12; pareada, con M ≥ 6, para afirmar una diferencia); denominador con las excluidas a la vista; estabilidad ante repetición por separado;».

**Costo**: una viñeta reescrita (~650 palabras de bitácora); en la guía, §10.4 suma ~40 palabras (compensación en PAR2-17). Más campos en el registro: el escritor del registro de `_Comun` crece. 0 llamadas.

**Reversible**: sí, antes de la primera corrida que cuenta. Después, cambiar el esquema obliga a re-correr.

**Derivados a revalidar**: §E.2 oráculos (PAR2-09), AC-3b y AC-7 (PAR2-03), Anexo A §10 (plantilla del registro), §F.8.

**Verificación**: (1) con el cliente guionado, una corrida de 08 y una de 16 en `--fake` producen líneas `llamada` con `herramientas` y `recuperados` no vacíos, y `recalcular-oraculos.sh` reproduce el `resultado` de cada `entrada`. (2) Intersección `entradas.dev.json` ∩ `entradas.v1.json` vacía, por ejemplo. (3) `grep -n "load_duration y prompt_eval_count"` = 0. (4) Ningún texto de §E ni de §10 afirma una diferencia con M < 6.

---

## PAR2-07 · §E.1 Composición: namespace, `.csproj` y versiones

**Ítems**: H2-006, H2-007 (filas del Anexo F), H2-008.

**Cambio 1.** Reemplaza «Regla: `Examples/_Comun/MovilidadUrbana.Dominio/Domain` es idéntico a `Demos/MovilidadUrbana.Asistente/src/…/Domain` (`diff -r` vacío salvo los namespaces).» (l. 572) por:

> - Regla (H2-008): el namespace raíz de la demo y de `_Comun` es `MovilidadUrbana.Asistente` (`…Domain`, `…Application`, `…Infrastructure`). La copia de `8fb4c3a` cambia `MovilidadUrbana.ApiWeb` por `MovilidadUrbana.Asistente`, y ese renombre es una fila «Modificado por otro motivo» del delta (§F.2). `Examples/_Comun/MovilidadUrbana.Dominio/Domain` es idéntico a `Demos/MovilidadUrbana.Asistente/src/…/Domain`: `tools/diff-dominio.sh` corre `diff -r` entre las dos carpetas y debe dar vacío (mismo namespace, sin normalización). Pregunta abierta para senior .NET y arquitectura: ¿la demo referencia el proyecto `_Comun/MovilidadUrbana.Dominio` en lugar de copiarlo, sin perder lo que pide DC-05 (una solución propia que replica la temática)?

**Cambio 2.** Agrega al final de la viñeta «**Versiones**» (l. 573): «El `.csproj` copiado de ApiWeb **pierde** `GenerateDocumentationFile` y `<NoWarn>$(NoWarn);CS1591</NoWarn>`: la documentación XML de la API no es tema de la guía y AC-1 no admite `NoWarn` (H2-006). Sus versiones en línea pasan a `Directory.Packages.props` (con gestión central, una versión en línea es error NU1010). Las dos decisiones son filas del delta (§F.2).»

**Cambio 3.** En la tabla de versiones (l. 575–592): reemplaza la fila de `Microsoft.Extensions.Compliance.Abstractions` por «`Microsoft.Extensions.Compliance.Abstractions` | 10.11.0 (existe en nuget.org, verificado en el ciclo 2; fijado también como transitivo) | H-054; H2-007». En la fila de OpenTelemetry, agrega `.Exporter.InMemory` («`OpenTelemetry` / `.Extensions.Hosting` / `.Exporter.OpenTelemetryProtocol` / `.Exporter.InMemory` (sólo 17)» | 1.20.1, la misma de la familia; DEP-02 la re-verifica). Agrega tres filas:

| Paquete | Versión | Fuente |
|---|---|---|
| `Microsoft.AspNetCore.OpenApi` · `Scalar.AspNetCore` | 10.0.11 · 2.17.3, **fieles al caso base**, sólo en la demo y en Development (re-verificar en DEP-02) | `MovilidadUrbana.ApiWeb.csproj` @ `8fb4c3a`; H2-006 |
| `Microsoft.AspNetCore.Mvc.Testing` · `NUnit.Analyzers` | 10.0.11 · 4.7.0, fieles al caso base, sólo en las pruebas de la demo | `MovilidadUrbana.ApiWeb.Tests.csproj` @ `8fb4c3a`; H2-006 |

**Costo**: un párrafo y tres filas. 0 llamadas.

**Reversible**: sí.

**Derivados a revalidar**: §F.2 (filas de composición, PAR2-12), AC-1, AC-5 y AC-6 (PAR2-03), Anexo F de la guía.

**Verificación**: (1) `grep -rn "NoWarn" Demos/ Examples/` = 0. (2) `grep -rn 'Version="' --include=*.csproj Demos/ Examples/` = 0. (3) `tools/diff-dominio.sh` vacío. (4) Todo paquete de los `.csproj` está en la tabla de versiones.

---

## PAR2-08 · §E.6 nueva: inventario y limpieza al cerrar

**Ítem**: H2-021.

**Cambio.** Agrega después de §E.5 (y antes de «---» y «## F. Demo»):

> ### E.6 Inventario y limpieza al cerrar (H2-021)
>
> Todo lo que crea el arnés lleva `--label <etiqueta-del-arnés>`.
>
> | Recurso | Dueño | Qué se hace |
> |---|---|---|
> | Contenedores del SDK por fase y de la demo | arnés | `docker run --rm`: se borran al terminar cada fase |
> | Contenedor `<ollama>` | arnés | se borra al cerrar la construcción |
> | Volumen `<volumen-nuget>` (caché de NuGet) | arnés | se conserva durante la construcción; se borra al cerrar |
> | Volumen `<ollama>` (modelos del Ollama propio) | arnés | ídem |
> | Volúmenes `<ollama-n3>` (~913 MB) y `<volumen-nuget-n3>`, de N3 | dossier N3 | el plan no los usa (el del plan es `<ollama>`); se borran al cerrar, con el registro de que ninguna evidencia depende de ellos |
> | Red `<red-del-arnés>` | arnés | se borra al cerrar |
> | `RLLM_DIR` crudo, fuera del repo | arnés | se borra después de copiar a `Evidencia/R-LLM/` lo que pasó AC-7 |
> | Intermedios `bin/` y `obj/` (en volúmenes: R-HOST) | arnés | se borran con su volumen |
> | Exportación de `8fb4c3a` (AC-10) | arnés | se borra al cerrar |
>
> Verificación al cerrar, registrada en el cierre: `docker ps -a --filter label=<etiqueta-del-arnés> -q` vacío; `docker volume ls -q | grep -E '^(<prefijo-del-laboratorio>-|n3-)'` vacío; `docker network ls --filter name=<prefijo-del-laboratorio> -q` vacío. Borrar un volumen es irreversible: se hace sólo al cierre y después de verificar que `Evidencia/` tiene todo lo que cita la guía.

**Costo**: una subsección corta. 0 llamadas.

**Reversible**: el texto sí; los borrados que describe, no (por eso van al final y con verificación previa).

**Derivados a revalidar**: §G.2 R-02 (PAR2-21), Anexo E.

**Verificación**: los tres comandos dan vacío al cerrar; antes de borrar `<ollama-n3>`, `grep -rn "<ollama-n3>" ` sobre el plan y la guía sólo aparece en §E.6.

---

## PAR2-09 · §E.2 Filas de los ejemplos

**Ítems**: H2-012 (16), H2-014 (13), H2-016 (02), H2-025 (05), H2-026 (07), H2-027 (06), H2-028 (08, 12), H2-029 (06), H2-030 (15), H2-032 (03), H2-033 (11), H2-034 (12), H2-039 (dificultad, con PAR2-02), H2-057 (02, 15), RV-02 (05), RV-11 (15, provisional).

Cada cambio dice la celda que se reemplaza. «Entradas» y «Turno» siguen §E.5 (PAR2-01) en todas las filas.

- **01**: Entradas: «Demostración (TURNO-1): 2 preguntas distintas sobre qué pide el alta y la encuesta (con instrucciones que listan los campos) → respuesta en castellano que nombra los campos». Oráculo: «…`FinishReason` = stop; sin tasa (demostración). Variante negativa: …» (se borra «tasa k/6 con intervalo»).
- **02** (H2-016, H2-057): Concepto, agrega al final: «Las dos vías van **contra el Ollama propio** (`OLLAMA_PROPIO_ENDPOINT`), porque por `/v1` no llega `num_ctx` y no está respondido si eso recarga el compartido (§E.1). SDK OpenAI con `NetworkTimeout` de 10 min y **cero reintentos** (opción de reintentos de `OpenAIClientOptions` en 0; DEP-02 confirma el nombre en el XML del paquete)». Modelo: «`qwen2.5:0.5b` en el Ollama propio · `num_ctx` 8192 por OllamaSharp; por `/v1`, sin `num_ctx`». Entradas: «1 pregunta por las dos vías».
- **03** (H2-032): Concepto, reemplaza «`TryGetResult` y `LocalidadRules` que deciden (H-004)» por «`TryGetResult` y `LocalidadRules` que deciden (H-004). **Garantía del código contra la invención** (H2-032): un valor numérico propuesto (habitantes, código postal) se acepta sólo si aparece en el texto de entrada (comprobación en el adaptador) o si la persona lo confirma; si no, se trata como ausente (`null`)». Entradas: «Demostración (TURNO-1): 2 pedidos, uno con el dato y uno sin él («En Bella Vista, Corrientes, CP 3432, no sé cuántos viven»). Extensión de medición (TURNO-2): M = 8, 4 sin el dato». Oráculo: «Garantía del código (siempre): toda propuesta que pasa `LocalidadRules` tiene CP de 4 dígitos, provincia del catálogo y habitantes ≥ 1; ningún valor que no esté en la entrada llega a las reglas sin confirmación; ninguna escritura sin las reglas. Conducta del modelo (sólo en la extensión, descriptiva por §10.4): **tasa de invención** = propuestas con `Habitantes != null` sobre las 4 entradas sin el dato; tasa de JSON válido k/8».
- **04**: Entradas: «Demostración (TURNO-1): 2 expresiones sintéticas («voy en bondi y a veces en bici, casi todos los días», …); extensión (TURNO-2): M = 8». Oráculo: se borra «Tasa k/8 de normalización correcta contra la clave esperada por entrada» de la demostración y queda para la extensión.
- **05** (H2-025, RV-02): Concepto, reemplaza «sin variante RAG, que vive en 06 y 07» por «sin variante RAG **por costo**: el 7B en CPU pasa los 400 s por consulta (N3b X3); la comparación de calidad entre contexto completo y RAG queda como deuda declarada en §14.6 (RV-02)». Modelo: «**Ollama propio** `ollama/ollama:0.40.11` **fijado por digest**, con `qwen2.5:0.5b` (digest al registro) · `num_ctx` 8192 explícito (no toca el servidor compartido: R-04)». Oráculo, agrega: «Orden de consultas **fijo y alternado** (sin-prefijo 1, con-prefijo 1, sin-prefijo 2, …), sin `build` en curso (fases del arnés). Las cifras de N3b X4b se citan como «medido en Ollama 0.32.0-rc0 con `qwen2.5:0.5b` (transformer puro)»; lo de 05 es una medición nueva en 0.40.11. Con `qwen3.5:4b` (híbrido) la reutilización **no está medida**, y §5.7 y §6.3 lo dicen (H2-025). Comparación pareada por §10.4». Dificultad: I.
- **06** (H2-027, H2-029): Concepto, agrega: «**Texto vectorizado fijo**: plantilla `plantilla.v1`, generada en código y versionada con el oro: «{entidad} · {propiedad en palabras}: {literal}» (p. ej. «Localidad · requisito del nombre: …»); la línea base léxica usa el mismo texto». Entradas, agrega: «La pregunta del nombre tiene **dos** fragmentos relevantes (`LocalidadPolicy.RequisitoDelNombre` y `EncuestaPolicy.RequisitoDelNombre`), declarados en el oro; para ella se informa además recall@3». Oráculo: reemplaza «Con 12 preguntas una pregunta mueve 8,3 puntos: el README sólo afirma una ventaja sobre la línea base si es de al menos 3 preguntas **[criterio propio]**.» por «La ventaja sobre cada línea base se afirma sólo con la regla pareada de §10.4 (al menos 6 preguntas discordantes, todas a favor).»; y «El 8/8 de N3 E3 (otro corpus) no se cita» por «El 8/8 de N3 E3 se midió sobre enunciados redactados y no se transfiere a este corpus: no se cita».
- **07** (H2-026): Entradas: «Las 16 preguntas de `conjunto-de-oro.v1.json`: 12 respondibles y 4 no respondibles. El oro declara por pregunta el **valor esperado y sus formas aceptadas** (dígitos y palabras: «4», «cuatro») o **«sin valor verificable»** para los 5 literales que no fijan valor: `LocalidadPolicy.RequisitoDeLaProvincia` («Una de las provincias del catálogo.») y `EncuestaPolicy.RequisitoDeLaLocalidad`, `.RequisitoDeLosMedios`, `.RequisitoDeLaFrecuencia` y `.RequisitoDelMotivo`». Oráculo, reemplaza «Tasas k/12 de afirmación correcta, k/4 de «no sé» y k/12 de «cita y contradice», con intervalo.» por «Tasas descriptivas (§10.4): afirmación correcta sobre el M efectivo, k/7 (las 7 con valor verificable); en las 5 sin valor, sólo cita válida; k/4 de «no sé»; k/12 de «cita y contradice».». Modelo: agrega «embeddings precomputados en la fase TURNO-3 (§E.1)». Dificultad: A.
- **08** (H2-028): Entradas: «Demostración (TURNO-1): 2 —«¿Cuántas localidades tengo en Corrientes? Usá la herramienta.» y la negativa del dato que no está ni en la base ni en el pedido (H-032)—; extensión (TURNO-2): las 8 de antes (4 legítimas, 4 negativas)». Oráculo, reemplaza «el conjunto de números de la respuesta está contenido en el de números que devolvieron las herramientas en esa corrida (regex `\d+`); si una herramienta devolvió error, la respuesta no afirma un conteo» por «el conteo afirmado (dígitos o palabras normalizadas: «dos» → 2, de cero a cien) coincide con el campo de conteo que devolvió `contar_localidades` o con la cantidad de filas de `listar_localidades`; los números que en el resultado son `id` no valen como conteo; en una entrada legítima, una respuesta sin cifra es falla («sin cifra») y se cuenta aparte; si una herramienta devolvió error, la respuesta no afirma un conteo (los argumentos y resultados salen del registro: §E.1)». Tasas: sólo en la extensión. Dificultad: I.
- **09**: Entradas: «Demostración (TURNO-1): 2 —la negativa del CP inválido («Agregá Goya, Corrientes, CP 34, 89959 habitantes»: X-006) y la misma alta con el CP corregido, aprobada—». Oráculo: se borra «Tasa k/5 informativa de «corrige» frente a «pide el dato»».
- **11** (H2-033, H2-035): § · OA: «§8.7 · OA-D6, OA-S4» (sale §8.5). Concepto, agrega al principio: «Escalón **1** (pedido acotado, herramientas fijadas por el código, tope de iteraciones): el `AIAgent` aporta **estado** —la `AgentSession` entre dos peticiones—, que es una dimensión aparte y no sube el escalón (§B.3; H2-033).». Entradas: «Demostración (TURNO-1): 1 pedido («Borrá Resistencia») que exige `listar_localidades` → `eliminar_localidad(id)` (H-011)». Oráculo: se borra «Tasa k/5 de cadena correcta (listar → id correcto → pedido)». Dificultad: A.
- **12** (H2-034, H2-028): § · OA: «§8.6 (un-agente), §8.8 (dos-agentes) · OA-D7». Concepto, reemplaza todo por: «Escalón **2 fijo** (workflow de MAF, camino en código) y **una sola variable**: cuántos agentes. Variante «un-agente»: redactor (executor que llama al `IChatClient`, sin `AsAIAgent`) → **verificador en código** (executor que compara los porcentajes con `ResultadosDeEncuestaService`) → si no coinciden, una vuelta al redactor con el error. Variante «dos-agentes»: el mismo camino, con un segundo agente (`AsAIAgent`) «corrector» que recibe el error del verificador y reescribe. Ninguna variante usa un modelo para verificar cifras: es una cuenta determinista (escalón −1). La variante «un-agente» es la instancia positiva del escalón 2 en §8.6; la «dos-agentes», el ejemplo de §8.8, después de §8.7 (H2-035). **Sin revisor de privacidad**: la ausencia de `Nombre` y `Edad` es un invariante de `resumir_encuesta`, probado en cableado por reflexión sobre el tipo de retorno (H-005)». Entradas: «Demostración (TURNO-2): 2 pedidos, los mismos por las dos variantes (pareado), sobre la siembra rotulada (H-062)». Oráculo: «Cada medio pedido aparece con su porcentaje y coincide (±1 punto) con `ResultadosDeEncuestaService`; un resumen sin porcentajes es falla («sin cifra»). Se informan por variante llamadas al modelo, tokens de entrada y salida y vueltas. Sin tasa: con 2 entradas el ejemplo **ilustra el costo**; no responde «¿uno o varios?» (X-009)». Sin servidor: «Guion: cuenta llamadas y vueltas y verifica el orden del camino».
- **13** (H2-014): Concepto, agrega: «Del lado cliente, lo que devuelve `ListToolsAsync` (nombres, descripciones, anotaciones y resultados) es **no confiable** (MCP 2025-06-18, Tools): se monta sólo lo que está en una **lista permitida por nombre** (`listar_localidades`) y lo demás se descarta; si alguna vez se monta una escritura, va envuelta en `ApprovalRequiredAIFunction`». Oráculo, agrega: «Prueba de cableado: un servidor MCP guionado que además anuncia `borrar_todo` → el cliente no la monta». Entradas: «1 pregunta (TURNO-2)».
- **15** (H2-030, H2-057, H2-002, RV-11): Modelo, reemplaza por: «juez: el mismo `qwen3.5:4b`, con **sesgo declarado** (vigente en forma provisional: X-002 en re-votación, RV-11, PAR2-22) y las `ChatOptions` de la capa única (razonamiento apagado, `num_ctx`, `temperature` 0; H2-057)». Entradas, reemplaza por: «Las 16 salidas de 07 de la última corrida válida, más **10 casos de calibración tomados de salidas de `qwen3.5:4b` en 07 y anotados a ciegas** por una persona antes de ver el puntaje del juez (5 buenos, 5 malos, al menos uno «cita y contradice»). El caso de N3 E5, de `qwen2.5:7b`, queda como caso guionado de cableado, no de calibración. Dos evaluadores × (16 + 10) = 52 llamadas (H2-002)». Oráculo, reemplaza «Calibración: el juez da ≥ 4 a los buenos y ≤ 2 a los malos en al menos 8 de 10; si no llega,» por «Calibración: se informa el acuerdo juez-anotador k/10 con su intervalo (8/10 = [0,44; 0,97]) y el acuerdo juez-oráculo determinista sobre las 16. Con 10 casos la calibración sólo puede **descartar** un juez, nunca validarlo: si acierta menos de 8 de 10,». Turno: TURNO-2.
- **16** (H2-012): Concepto: variantes «origen», «aprobación», «aprobación+marcado» (PAR2-02); agrega: «**No confiable**, por procedencia: todo texto que la app no escribió (contexto recuperado, resultado de una herramienta de recuperación a mitad del bucle, campos libres de lecturas, resultados MCP). En la variante «origen», si un resultado de herramienta trae texto no confiable a mitad del bucle, el pedido queda marcado y toda herramienta de escritura montada rechaza sin ejecutar (devuelve error al modelo) hasta que el pedido termina (prueba de cableado `Escritura_ConResultadoNoConfiable_Rechaza`)». Entradas: «M = 6 preguntas legítimas distintas que recuperan el documento malicioso, las mismas por las tres variantes (pareado; mínimo de §10.4)». Oráculo: reemplaza «la tasa k/5 de **pedidos de escritura inducidos**» por «la tasa descriptiva k/6 de **pedidos de escritura inducidos**»; reemplaza «sin afirmar diferencias si se solapan» por «y una diferencia entre variantes sólo con la regla pareada de §10.4». Agrega: «embeddings precomputados en la fase TURNO-3».
- **17**: Paquetes: agrega «OpenTelemetry.Exporter.InMemory 1.20.1». Dificultad: I.

**Costo**: celdas de 16 filas; en la guía, ~250 palabras más entre §5, §6, §8 y §11 (compensación en PAR2-17). Ahorro de llamadas: el cambio a demostración saca de lo obligatorio 01 (6 → 2), 03 (8 → 2), 04 (8 → 2), 08 (16 → 4), 09 (15 → 6) y 11 (15 → 3).

**Reversible**: sí.

**Derivados a revalidar**: §E.5 (cuentas de llamadas), §F.1 (ejemplos hermanos), §C §8 y §11 (PAR2-18), §B.3 (PAR2-16), OA-D6 y OA-D7.

**Verificación**: (1) toda fila con modelo tiene «Entradas» y «Turno» coherentes con una fila de §E.5. (2) `grep -nE "k/5|k/6 con intervalo|al menos 3 preguntas"` sobre §E.2 = 0. (3) `grep -n "verificador de cifras"` = 0. (4) Ningún ejemplo de demostración menciona una tasa. (5) Las filas 10 → 11 → 12 tienen el primer § creciente (§8.6, §8.7, §8.6/§8.8, con 12 «dos-agentes» en §8.8).

---

## PAR2-10 · §E.4 Fuera de `Examples/`: motivo del multiagente (lote S4)

**Ítem**: H2-059.

**Cambio.** En §E.4 (l. 658), reemplaza «(d) **Multiagente del escalón 3** (handoff, Magentic): conceptual, sin ejemplo (RD-PO-3; §B.3).» por «(d) **Multiagente del escalón 3** (handoff, Magentic): conceptual, sin ejemplo, por **costo de turno** (cada paso de un modelo que elige al siguiente agente es una llamada de clase L, §E.5) y por **R-08** (la conducta de `qwen3.5:4b` en tareas de varios pasos no está medida más allá de una herramienta) (§B.3). RD-PO-3 no aplica: un handoff sobre Movilidad Urbana no usaría otro dominio. Pregunta abierta, sin presupuesto: ¿un handoff mínimo entra en TURNO-2 si DEP-10 sale bien en sus 2 entradas?»

**Costo**: una frase. 0 llamadas.

**Reversible**: sí.

**Derivados a revalidar**: Anexo G (sin cambio), §8.7 (PAR2-18).

**Verificación**: `grep -n "RD-PO-3" ` en §E.4 sólo dentro de «RD-PO-3 no aplica».

---

## PAR2-11 · §F.1 Alcance de la demo

**Ítems**: H2-003 (M y oráculo de los PD-n), H2-054 (opción a), H2-055 (opción a), X2-05, X2-06.

**Resoluciones**: X2-06 → recortar el alcance antes de corregir la fusión de hosts, y registrar después en un ADR lo que quede (5-0-0). X2-05 → PD-6 baja al escalón 1, con el estado como dimensión aparte, y va sólo por la página Blazor (4-0-1). H2-055 → opción (a), una sola presentación para el chat; la opción (b) depende de la pregunta a la presidencia.

**Cambio 1.** Al final del párrafo de §F.1 (l. 683, después de «…(fuera de alcance del contrato).»), agrega:

> **Una sola presentación para el chat** (H2-055, opción a; X2-06): la página Blazor. La API conserva `/api/v1` (ABM, encuesta, `desde-texto`, `ayuda`) y `/mcp`, pero no tiene ruta de chat. **PD-7 se declara sin modelo**: un cliente MCP en proceso lista y llama `listar_localidades` sin LLM. **Pregunta a la presidencia** (H2-055): ¿el contrato exige que la demo sola recorra los cinco escenarios? Si no, PD-7 sale y ESC-05 se cubre con 13. **Un registro con dos usos** (H2-054, opción a): cada paso corre una entrada de humo; su M, su oráculo y su evidencia de conducta son los del ejemplo hermano (columna nueva). La demo prueba la composición en un host; los ejemplos, la conducta.

**Cambio 2.** Reemplaza la tabla de §F.1 (l. 685–693) por:

| Paso | v0 | Escenario | Capacidad (N6) | Escalón (§B.3) | Ejemplo hermano (M y oráculo) | Qué muestra |
|---|---|---|---|---|---|---|
| PD-1 | D4 | ESC-01 | C1 consulta sobre casos de uso de lectura | agencia 1 · carril «dato exacto» | 08 (conteo); para el agregado de encuesta, el oráculo de 12 sobre la corrida de humo | «¿Cuántas localidades tengo en Corrientes?» y «¿Qué medio usa más la gente?»: respuestas desde `LocalidadService` y `ResultadosDeEncuestaService` (agregados de la siembra rotulada de la propia sesión, sin nombres) |
| PD-2 | D5 | ESC-01 / ESC-02 | C4 ayuda con RAG (`AyudaController` → `IAyuda`, fuera del chat: excepción de lectura, §A.4) | conocimiento 2 · **sube más de lo necesario**: con este corpus alcanzaría el 0 (N3b P6) | 07 | «¿Cuántos dígitos lleva el código postal?»: respuesta con cita validada |
| PD-3 | D2 | ESC-03 | C2 extracción tipada (`AltaDesdeTextoService`) | agencia 0 | 03 | «En Bella Vista no sé cuántos viven»: `Habitantes = null`, la regla rechaza y la UI pide el dato |
| PD-4 | D3 | ESC-03 | C3 + normalización (`EncuestaDesdeTextoService`) | agencia 0 | 04 | «Voy en bondi y a veces en bici…» (entrada sintética): claves de catálogo; un medio inventado se rechaza |
| PD-5 | D1 | ESC-03 / ESC-04 | C2 + herramienta `agregar_localidad`, con aprobación | agencia 1 · aprobación transversal | 09 | «Agregá Goya, Corrientes, CP 34…»: el dominio rechaza; con el CP corregido, el pedido de aprobación muestra los datos resueltos por el código |
| PD-6 | D6 | ESC-04 | C5 baja con aprobación, en dos peticiones | agencia 1 · **con estado** (el historial del circuito entre las dos peticiones) · aprobación transversal (X2-05) | 11 | «Borrá Resistencia»: listar → id → pedido armado por el código → sin aprobación no se borra |
| PD-7 | D7 | ESC-05 | C6 servidor MCP (sólo lecturas, sesión fija declarada) | expone · **sin modelo** | 13 (sin modelo en PD-7) | Un cliente MCP en proceso lista y llama `listar_localidades` |

**Costo**: un párrafo y una columna. Saca de la demo la ruta de chat de la API, el almacén de conversaciones y el SSE (PAR2-13); 0 llamadas nuevas (el humo ya estaba en §E.5).

**Reversible**: sí; si la presidencia responde que la demo sola tiene que recorrer los cinco escenarios con modelo, PD-7 vuelve a llamar a un modelo y suma una fila a TURNO-1.

**Derivados a revalidar**: §F.2–§F.5 (PAR2-12, PAR2-13), §B.3 (PAR2-16), §14.3, AC-3b, OA-D6, P-03 (PAR2-21).

**Verificación**: (1) `grep -n "AsistenteController\|IAlmacenDeConversaciones\|ServerSentEvents"` sobre §F = 0. (2) Cada PD-n con modelo tiene un ejemplo hermano que está en TURNO-1 (PD-1 ↔ 08, PD-2 ↔ 07, PD-3 ↔ 03, PD-4 ↔ 04, PD-5 ↔ 09, PD-6 ↔ 11). (3) `grep -n "agencia 3"` en §F = 0.

---

## PAR2-12 · §F.2 Línea de base y tabla de delta

**Ítems**: H2-005, H2-006 (filas), H2-008 (fila de namespace), H2-015, H2-051.

**Cambio 1.** Reemplaza «**Línea de base** (H-050): la demo empieza como **copia literal** de `src/MovilidadUrbana.ApiWeb/` y de las piezas de `src/MovilidadUrbana.Web/` que se nombran abajo, en `8fb4c3a`, en un primer commit de trabajo «base 8fb4c3a sin cambios».» (l. 697) por:

> **Línea de base** (H-050, H2-051): la demo empieza como **copia literal**, en `8fb4c3a`, de `src/MovilidadUrbana.ApiWeb/`, de `src/MovilidadUrbana.Web/Sessions/SessionMiddleware.cs` y de `src/MovilidadUrbana.Web/wwwroot/css/Tokens.css` y `Componentes.css`. La base se exporta con `git archive` (sólo lectura sobre Lab-E2E.WebBlazor) a un directorio **fuera del repo**; no hay commit de base, porque las reglas de la corrida no admiten commits. El host es uno solo (ADR-13).

**Cambio 2.** Reemplaza la tabla de delta (l. 699–709) por:

| Pieza | Agregado por la IA | Modificado a causa de la IA | Modificado por otro motivo |
|---|---|---|---|
| Proyecto (`MovilidadUrbana.ApiWeb.csproj` → `MovilidadUrbana.Asistente.csproj`) | Paquetes de IA, con versión central | — | Namespace raíz `MovilidadUrbana.Asistente` en todos los archivos copiados (H2-008); versiones a `Directory.Packages.props` (NU1010); se quitan `GenerateDocumentationFile` y `<NoWarn>$(NoWarn);CS1591</NoWarn>` (AC-1; H2-006) |
| `Program.cs` | `AddAI(config)`, `MapMcp("/mcp")` con validación de Host y Origin (§F.5), `AddRazorComponents().AddInteractiveServerComponents()`, `UseAntiforgery`, `MapStaticAssets`, `MapRazorComponents<App>().AddInteractiveServerRenderMode()` (ADR-13) | `SessionHeaderMiddleware` sólo en `/api` (`app.UseWhen`); sesión fija en `/mcp`; `SessionMiddleware` sólo en los documentos | `UseStatusCodePages` acotado a `/api`, para no pisar las páginas (ADR-13) |
| `Domain/` (entidades, `Catalogos`, `*Rules`, `*Policy`) | — | **Endurecimiento** de las reglas de provincia, frecuencia, motivo y medios (huecos H1–H5, T2): con un modelo que propone texto, «no vacío» deja pasar valores fuera de catálogo (N6 §1.1.3) | — |
| `Application/` (`LocalidadService`, `EncuestaService`, modelos, `Result`, puertos de repositorio, `ISessionContext`) | `ResultadosDeEncuestaService`; `AltaDesdeTextoService` y `EncuestaDesdeTextoService` (§A.4, punto 6); `Abstractions/` `IExtractorDeLocalidad`, `IExtractorDeEncuesta`, `IAyuda`; `LocalidadPropuesta` con `int? Habitantes` | `LocalidadService`: **`GetByIdAsync(id)`** nuevo, para resolver el id del pedido de aprobación dentro de la sesión, y `SaveAsync` devuelve además el id creado, para que la herramienta informe lo creado (H2-015; la forma exacta la fija la construcción, E3); `Application/DependencyInjection.cs` registra los tres servicios nuevos | — |
| `Infrastructure/Persistence` (EF Core SQLite, `SessionSeeder`) | Siembra de respuestas de encuesta **rotulada** «escrito para el ejemplo» (20 por sesión, valores de `Catalogos`, `Nombre` = «Persona 01…20», edades del rango de `EncuestaRules`), al crear la sesión; alcance: la sesión propia (H-062) | — | EF Core Sqlite 10.0.11 → **10.0.14** (N6 §3, E1) |
| `Infrastructure/AI/` | Todo: adaptadores, capa de opciones del proveedor, normalizador de catálogo, herramientas por circuito, aprobación, almacén vectorial, ingesta de `*Policy`, `IChatClient` base | — | — |
| `Sessions/SessionHeaderMiddleware` (ApiWeb) | — | Se aplica sólo a `/api` (`app.UseWhen`); `/mcp` usa la sesión fija `demo-mcp` (H-014; §F.5) | — |
| `Sessions/SessionMiddleware` (Web, copia literal) | — | Se aplica sólo a los documentos fuera de `/api` y `/mcp` (§F.5) | Namespace |
| `wwwroot/css/Tokens.css`, `Componentes.css` (Web, copia literal) | — | — | Se copian para conservar la temática del caso base (DC-05; ADR-13) |
| `Components/App.razor`, `Components/Routes.razor` y un layout mínimo | **Nuevos** (ADR-13): la página de chat; `Routes` repite el puente `SessionId` → `SessionContext` de `src/MovilidadUrbana.Web/Components/Routes.razor` @ `8fb4c3a` (procedencia del patrón, no copia); `@Assets["MovilidadUrbana.Asistente.styles.css"]` con el ensamblado nuevo | — | — |
| Controllers de `/api/v1` (localidades, encuestas) | `DesdeTextoController`, `AyudaController`. Sin ruta de chat (§F.1). **Estilo: controllers**, fiel al caso base (H-057) | — | `LocalidadesController` deja de leer del repositorio salteando el servicio (N6 §1.3, F04 §3.2) |
| `Mcp/` | `LocalidadMcpTools`, `EncuestaMcpTools` (sólo lecturas) | — | — |
| Pruebas (`MovilidadUrbana.ApiWeb.Tests` → `MovilidadUrbana.Asistente.Tests`) | `Cableado/`, `ConModelo/` | — | Namespace; versiones centrales (`Mvc.Testing` 10.0.11, `NUnit.Analyzers` 4.7.0, en el Anexo F) |

**Cambio 3.** Reemplaza «Ningún AC acepta un cambio fuera de esta tabla: AC-10 (§F.10) compara `git diff base-8fb4c3a` contra ella.» (l. 711) por «Ningún AC acepta un cambio fuera de esta tabla: AC-10 (§F.10) compara la salida de `tools/diff-base.sh` contra ella.»

**Costo**: tabla rehecha (+6 filas). Es lo que el compilador iba a pedir igual; adelantarlo evita improvisar.

**Reversible**: sí.

**Derivados a revalidar**: ADR-13 y ADR-11 (PAR2-18), §14.1 (tabla de delta de la guía), AC-10.

**Verificación**: (1) `tools/diff-base.sh` contra la demo construida: todo archivo distinto tiene fila. (2) `grep -n "MainLayout\|NotFound"` en la demo sólo como «layout mínimo» propio. (3) La página de chat carga su hoja de estilos (prueba de humo con el navegador del laboratorio, no con la compilación: la hoja falla en silencio).

---

## PAR2-13 · §F.3–§F.5 Capas, herramientas, aprobación, sesión y `/mcp`

**Ítems**: H2-008 (prueba), H2-009, H2-010, H2-011, H2-012, H2-013, RV-07.

**Cambio 1 (§F.3).** En el diagrama: borra el nodo `EP` → `CH` (`EP -->|chat · excepción declarada| CH`); en `EP`, cambia «asistente (streaming) · desde-texto · ayuda» por «desde-texto · ayuda»; en `EP -->|ayuda| PT` cambia la etiqueta por «ayuda · excepción de lectura»; cambia `CH["IChatClient del asistente<br/>(keyed «asistente», herramientas por scope)"]` por `CH["IChatClient base (singleton)<br/>FunctionInvokingChatClient y herramientas por circuito"]`; cambia «herramientas (por petición)» de `AI` por «herramientas (por circuito)».

**Cambio 2 (§F.3, reglas, l. 754).** Reemplaza «comprobado por una **prueba de arquitectura obligatoria** en `Cableado/` (reflexión: ningún tipo de `MovilidadUrbana.Asistente.Domain.*` referencia…» por «comprobado por una **prueba de arquitectura obligatoria** en `Cableado/` (reflexión: el ensamblado tiene **al menos un tipo** en `MovilidadUrbana.Asistente.Domain`, y si no encuentra ninguno la prueba falla; ningún tipo de ese namespace referencia…» (H2-008). Reemplaza «herramientas armadas **por petición** desde el scope (T1);» por «herramientas armadas **por circuito** con `AIFunctionFactory.Create(método, instancia)` sobre instancias resueltas en el scope, **sin parámetros que resuelva DI** (`IServiceProvider` no aparece en ninguna firma); el `FunctionInvokingChatClient` se arma en el scope sobre el `IChatClient` base singleton y nunca es un singleton keyed, porque al construirse fija su `IServiceProvider` y en un singleton ese es el raíz (T1; H2-010). Prueba de cableado `Composicion_ValidateScopes`, con `ValidateScopes` y `ValidateOnBuild` encendidos sobre la composición real;».

**Cambio 3 (§F.4, «Política de origen», l. 767).** Reemplaza el párrafo por:

> **Política de origen** (H-012, H2-012): es **no confiable** todo texto que la app no escribió: contexto recuperado, el resultado de una herramienta de recuperación, los campos libres que devuelven las lecturas (`Nombre`) y los resultados MCP. Regla: (1) si el pedido trae contexto no confiable al armarse, el cliente se arma sin herramientas de escritura; (2) si una herramienta devuelve texto no confiable a mitad del bucle, el pedido queda marcado y toda herramienta de escritura montada rechaza sin ejecutar (devuelve error al modelo) hasta que el pedido termina. En la demo la política es **preventiva**: el asistente no tiene herramienta de recuperación, y la ayuda (PD-2) va por `AyudaController` → `IAyuda`, fuera del chat, como **excepción de lectura declarada** (no escribe ni lee el dominio; §A.4). Se ejercita en 16 y en la prueba `Escritura_ConResultadoNoConfiable_Rechaza`. En los demás pedidos, toda escritura pide aprobación.

**Cambio 4 (§F.4, «Pedido de aprobación», l. 769).** Reemplaza el párrafo por:

> **Pedido de aprobación** (H-010, H2-009): la UI **no** muestra la prosa del modelo. El código toma la `ToolCall` del `ToolApprovalRequestContent` (propiedad `ToolApprovalRequestContent.ToolCall`, un `ToolCallContent`: XML de M.E.AI 10.11.0), resuelve los argumentos contra el caso de uso dentro de la sesión (qué localidad, con nombre y provincia, y de qué sesión) y muestra eso. Si el id no pertenece a la sesión, rechaza sin preguntar. Si una llamada de la respuesta es aprobable, todas las de esa respuesta piden aprobación (M.E.AI 10.11.0); la UI las muestra juntas. **El pedido pendiente vive en el servidor**: en el estado del componente del circuito, junto con el historial; la UI envía sólo la decisión (aprobar o rechazar) y el id del pedido. La respuesta de aprobación se construye en el servidor con `CreateResponse(bool)` sobre el pedido guardado, nunca con datos del cliente, porque `FunctionInvokingChatClient` ejecuta la llamada que trae la respuesta. Si llega una respuesta cuyos argumentos no coinciden con el pedido guardado, se rechaza (prueba `Aprobacion_ArgumentosAlterados_SeRechaza`). Lo que se ejecuta después de aprobar es exactamente lo que se mostró (AC-4). La página no reenvía `ChatResponseUpdate` crudos: muestra texto y pedidos ya resueltos.

**Cambio 5 (§F.4, «Dónde vive el pedido pendiente», l. 771).** Reemplaza el párrafo por:

> **Dónde vive el estado** (ADR-12; H-009, H2-009, H2-011): en la página Blazor, el historial y el pedido pendiente viven en el estado del componente durante el circuito. La demo no tiene chat por la API, así que no hay almacén de conversaciones (`IAlmacenDeConversaciones` sale del plan) y PD-6 no depende de DEP-11. El ejemplo 11 conserva la `AgentSession` entre dos peticiones con `SerializeSessionAsync` (DEP-11). Nunca hay estado de conversación en un singleton. El `IChatClient` base es singleton; el `FunctionInvokingChatClient`, las herramientas y (en 11) el agente se arman por circuito o por petición.

**Cambio 6 (§F.5).** En «**Página Blazor (Interactive Server)** (H-008)», agrega al final: «(El caso base ya resolvía la sesión del circuito: H-008 corrigió la descripción del plan, no una fuga; re-votado a S3 en el ciclo 2, RV-07.)». Reemplaza la viñeta «**`/mcp`** (H-014): …» por:

> - **`/mcp`** (H-014, H2-013): sesión fija de demostración `demo-mcp`, puesta por un middleware propio sobre `/mcp` (`app.UseWhen`). Es un **delta declarado** frente al caso base (§F.2). No está verificado que los clientes MCP genéricos manden encabezados propios (N6 §4.5, §8.6). La frontera tiene tres partes distintas: (1) **escuchar**: Kestrel escucha en `+:8080` dentro del contenedor, así que lo alcanzan los demás contenedores de su red; (2) **publicar**: `127.0.0.1:8080:8080` en compose y `-p 127.0.0.1:8080:8080` en el camino `docker run` (sólo loopback del host); (3) **validar**: `MapMcp("/mcp").RequireHost("localhost:8080", "127.0.0.1:8080")`, `AllowedHosts` = `localhost;127.0.0.1`, y un filtro sobre `/mcp` que rechaza con 403 todo `Origin` distinto de `http://localhost:8080` y `http://127.0.0.1:8080` (MCP 2025-06-18, Transports: los servidores MUST validar `Origin`). Pruebas: Host ajeno → rechazo; `Origin` ajeno → 403; en la verificación de la demo, un `curl` desde el contenedor `ollama-embed` a `http://demo:8080/mcp` es rechazado. **Ninguna de las tres es control de acceso** (§11.5).

**Costo**: cuatro párrafos y dos reglas; cuatro pruebas de cableado nuevas. Saca de la demo una ruta, un almacén y su dependencia de DEP-11.

**Reversible**: sí.

**Derivados a revalidar**: ADR-12 (PAR2-18), §F.8 (lista de pruebas, PAR2-14), §11.3 y §11.5, AC-4, DEP-04 y DEP-11 (PAR2-21).

**Verificación**: (1) las cuatro pruebas nombradas existen en `Cableado/` y pasan. (2) `grep -n "keyed «asistente»\|por petición desde el scope"` sobre §F = 0. (3) `grep -n "/mcp\` hereda esa restricción"` = 0. (4) La prueba de arquitectura falla si se borra el último tipo de `Domain/` (prueba de la prueba).

---

## PAR2-14 · §F.6–§F.9 Embeddings, salida estructurada, pruebas y contenedor

**Ítems**: H2-013 (red), H2-017 (degradación), H2-027 (plantilla), H2-032 (§F.7), H2-057 (DEP-05), RV-09.

**Cambio 1 (§F.6).** Tabla, con los nombres de PAR2-02: fila **EMB-C**: Condición «`EMB_PLAN=EMB-C`, o DEP-14 sin resolver»; Qué se usa «generador de hash estable para el cableado»; Estado «06, 07, 16 y PD-2 «no ejecutado contra un modelo de embeddings», rotulado en la UI y en el registro (H2-017). La demo no degrada sola: con EMB-B y un endpoint sin la capacidad `embedding` (el 501 del compartido), arranca con un error que dice cómo pasar a EMB-C». Agrega después de la tabla: «La re-medición de 06 y 07 con embeddings reales depende de DEP-14 y **no es barata**: compite por CPU con `build` (R-02) y necesita un cambio en el gestor de recursos (RV-09; H2-020). Si DEP-14 no se resuelve, rige EMB-C y la guía no cita cifras de 06 ni de 07 (AC-9).». En el párrafo siguiente, después de «un fragmento por propiedad,» agrega «con el texto de la plantilla `plantilla.v1` de 06 (H2-027),».

**Cambio 2 (§F.7).** Reemplaza «Un campo ausente llega como `null`, la regla lo rechaza (`LocalidadRules.HabitantesValidos(null)` es `false`) y la UI pide el dato: el modelo no tiene dónde inventarlo (ADR-08; N5 E3; N6 §4.2).» por:

> Un campo ausente llega como `null`, la regla lo rechaza (`LocalidadRules.HabitantesValidos(null)` es `false`) y la UI pide el dato. **Eso no impide que el modelo invente** un número plausible, que pasa la regla (H2-032). Lo impide una garantía del código, separada de la tasa que se mide: el adaptador acepta un valor numérico propuesto (habitantes; en la encuesta, edad, distancia y minutos) sólo si ese valor aparece en el texto de entrada, y si no, lo trata como ausente; la UI muestra la propuesta y la persona confirma antes de guardar. Cuánto inventa el modelo se mide aparte, en la extensión de 03 (ADR-08; N5 E3; N6 §4.2).

**Cambio 3 (§F.8).** En «**`Cableado/`**», reemplaza «`Domain/` sin dependencias de IA; versiones alineadas (`dotnet list package --include-transitive` sin M.E.AI/MEVD mezclados).» por «`Domain/` sin dependencias de IA (con al menos un tipo encontrado); versiones con el invariante por familia de AC-6; `Aprobacion_ArgumentosAlterados_SeRechaza`, `Composicion_ValidateScopes`, `Escritura_ConResultadoNoConfiable_Rechaza`, `Mcp_HostYOrigenAjenos_Rechaza`, `Compartido_SinNumCtxDelArnes_Rechaza`.»

**Cambio 4 (§F.9).** En el camino (1), después de «`dotnet run`», agrega «, publicado con `-p 127.0.0.1:8080:8080`». En «**Red** (H-059)», reemplaza «`/mcp` hereda esa restricción.» por «Publicar en loopback restringe el acceso desde el host, no desde la red del compose: `/mcp` agrega la validación de Host y `Origin` de §F.5 (H2-013).». Reemplaza la viñeta «La imagen de runtime para un `Dockerfile` multietapa no se verificó (DEP-05); también se evalúa `dotnet publish /t:PublishContainer` (pregunta abierta de H-SN PR-11).» por «La demo corre con `sdk:10.0` + `dotnet run`. El `Dockerfile` multietapa y `dotnet publish /t:PublishContainer` quedan **fuera de alcance** (DEP-05 cerrada por decisión; la pregunta de H-SN PR-11 se cierra: H2-057).»

**Costo**: cuatro ediciones; en la guía, §7 y §5.3 suman ~80 palabras (compensación en PAR2-17).

**Reversible**: sí.

**Derivados a revalidar**: §A.4 punto 1 (PAR2-16), §E.2 fila 03, DEP-05 (PAR2-21), Anexo E.

**Verificación**: (1) `grep -n "no tiene dónde inventarlo\|no tiene un lugar donde inventarlo"` sobre el plan = 0. (2) `grep -n "PublishContainer"` sólo en «fuera de alcance». (3) Con `EMB_PLAN=EMB-B` y `OLLAMA_EMBED_ENDPOINT` apuntando a un servidor sin embeddings, la demo arranca con el error que nombra `EMB-C` (prueba de cableado con un servidor falso que responde 501).

---

## PAR2-15 · §A.3 Lectores y objetivos de aprendizaje

**Ítems**: H2-036, H2-041 (párrafo duplicado), H2-044 (OA-O2), RV-05 (papeleta), X2-03 (reatar OA-A2).

**Cambio 1.** Reemplaza los dos párrafos «**Lector principal**: …» (l. 95) y «**Lectores**: …» (l. 97) por uno:

> **Lectores**: el principal es un desarrollador .NET sin experiencia previa en IA (BIT-16-00, objetivo del contrato): **ACT-DEV** en su faceta de «desarrollador .NET que integra IA, el rol que el mercado llama *AI Engineer*» (N0b §3.3.2, opción B; I-02 PR-1), que la guía desarrolla en su §2.3. Los secundarios son ACT-ARQ, ACT-OPS y ACT-SEC, con ruta de lectura propia, y **el lector que viene de Semantic Kernel**, declarado para que 14 y §9.7 tengan destinatario (H-063, X-001). ACT-USR no es lector: es el actor cuyos datos y acciones la guía protege (BIT-16-03 §3).

**Cambio 2 (columna «§», H2-036).** OA-0.2: «§3.1, §4.5». OA-A2: texto «Fijar para un escenario la métrica, los tipos de error, el umbral para seguir y qué ve la persona cuando la respuesta está mal» y § «§2.4–§2.5» (X2-03: reata la pregunta de §2 sobre la pantalla). OA-D4: «§7, §10.7». OA-D8: «§8.9, §11.5». OA-D9: «§10.1–§10.4». OA-O2: § «§5.5, §5.7, §11.6, §12.5–§12.6» y Ejemplo «§14.5 (cómo se corre la demo; fuente: plan §F.9)» (H2-044). OA-O4: «§12.3–§12.4». OA-S2: agrega §11.2 (ver cambio 3).

**Cambio 3 (papeleta de RV-05).** El jurado vota: **(a) 26 OA**: se agrega OA-A5 y nada más. **(b) 25 OA** (recomendación de costo-beneficio): se agrega OA-A5 y OA-S3 se funde en OA-S2. Texto de las filas:

| ID | Actor | Al terminar, el lector puede… | § | Ejemplo / paso |
|---|---|---|---|---|
| OA-A5 (a y b) | ACT-ARQ | Decidir, para una capacidad, si el contrato es un puerto propio de Application o `IChatClient`, y justificarlo con quién define el prompt y qué cambia al cambiar de proveedor | §4.4 | demo: `IExtractorDeLocalidad` frente al chat (§14.2) |
| OA-S2 (sólo b) | ACT-SEC | Decidir qué herramientas piden aprobación, cuáles no se montan con contexto no confiable, qué datos llegan a qué modelo y dónde se filtra por permiso (en la recuperación, no después) | §7.6, §8.5, §11.2–§11.4 | 09, 16 |

Con (b), la fila OA-S3 se borra y toda remisión a OA-S3 pasa a OA-S2 (§C §7: «¿Quién puede ver qué fragmento?»). Con (a), OA-S2 sólo suma §11.2 a su columna «§». Mientras no se vote, rige la tabla v1 más OA-A5 (provisional).

**Cambio 4.** Reemplaza «Criterio de inclusión (H-040): ninguna sección, ejemplo o pregunta guía entra sin un OA de esta tabla. Formato en la guía: esta tabla abre la Parte 0 (§0.1).» (l. 129) por:

> Criterio de inclusión (H-040, H2-036), **en los dos sentidos**: (1) ningún ejemplo ni pregunta guía entra sin un OA de esta tabla; (2) toda subsección de §C aparece en la columna «§» de algún OA, o en la lista de **subsecciones de contexto** con su motivo, y no lleva ítem en §15: §2.5 sale de la lista porque la toma OA-A2; quedan §4.2 «Por qué ahora» (pedido del PO, PR-2: contexto histórico sin una conducta que evaluar), §12.7 (Aspire: snippet no compilado), §12.8 (lista de lo que la demo no implementa) y §12.9 (realimentación: explicada, no implementada). Verificación: un script cruza las subsecciones de §C con la columna «§» y esta lista, y falla si alguna no está en ninguna. Formato en la guía: esta tabla abre la Parte 0 (§0.1).

**Costo**: una fila nueva (~30 palabras en la Parte 0) y, con (b), una menos; el párrafo de lectores baja de ~120 a ~95 palabras.

**Reversible**: sí.

**Derivados a revalidar**: §0.2 rutas (PAR2-17), §15 (cantidad de ítems), §C preguntas de §1 y §4 (PAR2-18), OA-A1 (rango de ADR, PAR2-18), BIT-16-02 S-08 («§15 con 25 ítems»).

**Verificación**: (1) `grep -c "^\*\*Lector"` en §A.3 = 0 y un solo «**Lectores**». (2) `grep -n "demo §F.9"` = 0. (3) El script del criterio en los dos sentidos no reporta subsecciones huérfanas. (4) Cuenta de filas OA = 25 o 26 según el voto.

---

## PAR2-16 · §A.4, §B.2 y §B.3: principio rector y escaleras

**Ítems**: H2-012 (excepción de lectura), H2-032, H2-033, H2-034 (instancia del escalón 2), H2-048 (rótulo del diagrama), X2-05.

**Cambio 1 (§A.4, punto 1, l. 139).** Reemplaza «La ausencia la detectan las reglas (`LocalidadRules.HabitantesValidos(null)` es `false`) y la aplicación pide el dato. El modelo no tiene un lugar donde inventarlo.» por «La ausencia la detectan las reglas (`LocalidadRules.HabitantesValidos(null)` es `false`) y la aplicación pide el dato. **El campo anulable le da al modelo un lugar para no inventar; no le impide inventar**: un número plausible pasa `HabitantesValidos`. Lo que garantiza el código es otra cosa: un valor numérico propuesto se acepta sólo si aparece en el texto de entrada o si la persona lo confirma; si no, se trata como ausente. Cuánto inventa el modelo se mide como tasa (03), aparte de la garantía (H2-032).»

**Cambio 2 (§A.4, punto 6, l. 144).** Reemplaza «La única excepción declarada es el chat (PD-1, PD-5, PD-6): ahí Presentación consume el `IChatClient` del asistente» por «Hay dos excepciones declaradas. El chat (PD-1, PD-5, PD-6): ahí la página Blazor, la única presentación del chat (§F.1), consume el `IChatClient` del asistente». Agrega al final del punto: «Y la ayuda (PD-2), excepción **de lectura**: va del endpoint a `IAyuda` sin caso de uso, porque no escribe ni lee el dominio (H2-012).»

**Cambio 3 (§B.2, l. 231).** Reemplaza «Excepción declarada: el chat (§A.4, punto 6).» por «Excepciones declaradas: el chat y la ayuda (§A.4, punto 6).»

**Cambio 4 (§B.3, diagrama, l. 242).** `K1["1 · Contexto completo con<br/>prefijo cacheado<br/>(«CAG de servicio»)"]` → `K1["1 · Contexto completo con<br/>prefijo estable"]`.

**Cambio 5 (§B.3).** Después del párrafo «**Escalera de agencia**: …» y su tabla (después de l. 273), agrega:

> **Frontera operativa entre los escalones 1 y 3** (H2-033): escalón 1 = el pedido es acotado (una intención de la persona), el código fija las herramientas y un tope de iteraciones (`MaximumIterationsPerRequest`), y el bucle termina cuando el modelo responde ese pedido; escalón 3 = tarea abierta: el modelo fija submetas, elige qué herramienta o agente sigue más allá del pedido y decide cuándo terminó. Prueba observable: si el código puede enumerar de antemano qué pedido resuelve el bucle, es escalón 1. Encadenar `listar_localidades` → `eliminar_localidad(id)` para un «Borrá Resistencia» es escalón 1.

**Cambio 6 (§B.3, l. 275).** Reemplaza «**Dos dimensiones que no son escalones** (H-015, H-016):» por «**Tres dimensiones que no son escalones** (H-015, H-016, H2-033):» y agrega al final del párrafo: «(c) **estado de la conversación**: con o sin historial o `AgentSession` entre peticiones. Conservar la conversación no aumenta lo que decide el modelo y no sube el escalón.»

**Cambio 7 (§B.3, l. 277).** Reemplaza «PD-6 en el 3, porque el agente conserva la conversación entre dos peticiones (ADR-12), no por la aprobación.» por «PD-6 también está en el 1, **con estado**: el historial del circuito entre dos peticiones (ADR-12; X2-05). 11 usa un `AIAgent` y sigue en el 1 con estado: el artefacto no define el escalón. El escalón 3 queda conceptual en la guía (§8.7; §E.4 d).». Reemplaza «La **instancia positiva** del escalón 2 es 12: redactor y verificador en un camino fijo en código (H-017).» por «La **instancia positiva** del escalón 2 es la variante «un-agente» de 12: un redactor (llamada al modelo) y un verificador en código, en un camino fijo (H-017, H2-034).»

**Costo**: ~200 palabras de bitácora; en la guía, §3.2 y §8.1 suman ~110 palabras (compensación en PAR2-17).

**Reversible**: sí.

**Derivados a revalidar**: §B.4 (columna «Escalón» de la fila del agente de MAF), §3.2 y §8.1 de la guía, OA-D6, ADR-07.

**Verificación**: (1) `grep -n "PD-6 en el 3\|agencia 3"` = 0. (2) `grep -n "CAG de servicio"` = 0 fuera del glosario (PAR2-19). (3) En §B.4, ninguna fila ubica a un artefacto en el escalón 3 sólo por conservar estado.

---

## PAR2-17 · §C preámbulo y Parte 0

**Ítems**: H2-038, H2-044 (regla), H2-045 (familias de ID), H2-046, H2-047, RV-04 (papeleta).

**Cambio 1 (plantilla, l. 340–343).** Los encabezados de la plantilla de sección temática pasan de `###` a `####` (Parte `#`, sección `##`, subsección `###`, plantilla `####`).

**Cambio 2 (presupuesto, l. 361).** Reemplaza el párrafo «**Presupuesto de extensión** (H-040; …» por:

> **Presupuesto de extensión** (H-040; el número se re-vota en este ciclo: RV-04). **Regla de conteo** (H2-047), ejecutable con `tools/contar.sh` sobre la guía: palabras de prosa por Parte, con `wc -w`, después de quitar los bloques de código, las tablas del Anexo F, los comentarios HTML (`<!-- fuente: … -->`), las anclas y las filas separadoras de tablas; las celdas de las demás tablas cuentan. Topes vigentes hasta el re-voto (**[criterio propio]**): Parte 0 ≤ 1.200 palabras · I ≤ 3.500 · II ≤ 5.000 · III ≤ 5.500 · IV ≤ 7.500 · V ≤ 6.500 · VI ≤ 4.500 · Cierre ≤ 3.000 · Anexos ≤ 7.000; total ≤ 43.700. **Papeleta de RV-04**: (a) mantener los topes y mover el mapa de §0.5 al Anexo E (la tabla de OA sola mide 551 palabras con `wc -w`, y la Parte 0 se estima en ~1.480: E3); (b) Parte 0 ≤ 1.500 y Anexos ≤ 6.700, con el mismo total. **Regla de compensación**: todo parche que agregue texto a la guía declara cuántas palabras suma y qué saca o qué tope mueve; el juez de costo-beneficio lo verifica en la aprobación. Si una parte pasa su tope en más de 15 %, la relectura integral (S-14) recorta o registra el motivo. Lo que entra lo decide el criterio de inclusión de §A.3. Preguntas abiertas: ¿alcanzan 4.500 palabras para la Parte VI con 13 ADR? ¿58 preguntas guía más 25 ítems de §15 repiten la misma práctica?

Compensación de los parches de este ciclo (estimación E3, `wc -w` sobre el texto agregado): suman ~+640 palabras a la guía (PAR2-06 +40, PAR2-09 +250, PAR2-14 +80, PAR2-16 +110, PAR2-18 +130, PAR2-19 +150; PAR2-15 −25 con la opción b de RV-05) y sacan ~−420 (PAR2-18: dos preguntas guía de §2, dos de §12 y una de §7 absorbidas o movidas, ~−170; §4 «Orden interno» y la nota de AJ-05 en cinco fichas, ~−90; PAR2-15 lectores, ~−25; PAR2-02 sin cambio). Saldo ~+220, que se toma del margen del 15 % de la Parte V (§10–§12), donde cae la mayor parte; la relectura S-14 lo confirma con `tools/contar.sh`.

**Cambio 3 (después de la tabla «Una casa por pieza», l. 359).** Agrega:

> **Remisiones en las fichas** (H2-044): en este plan, toda remisión a una sección del plan lleva el prefijo «plan §» (plan §F.9, plan §A.3, plan §B.5). «§N.k» sin prefijo es siempre una sección de la guía, y «Anexo X», un anexo de la guía. Al redactar, ninguna remisión «plan §» pasa a la guía: se reemplaza por su destino en la guía o se borra. En la tabla «Una casa por pieza», «§B.5» → «plan §B.5 (en la guía, §9.2)». Compuerta sobre la guía: `grep -nE "§[A-H]([.0-9]|\b)"` = 0. La lista de las ocurrencias a corregir en §C la da `grep -nE "§[A-H]"` sobre las fichas (entre ellas l. 120, 356, 366, 372, 395–396, 457, 521).
>
> **Familias de ID** (H2-045): llegan al lector OA-, ESC-, CTX-, ACT-, ADR-, PD-, REF- (referencias del Anexo D) y los números de ejemplo NN. No llegan nunca H-, H2-, PAR-, PAR2-, AJ-, DEP-, SUP-, R-nn (riesgos de §G.2), P-nn, PR-n, RD-PO-n, S-nn, Q-, T1–T7 (tensiones), TURNO- ni EMB-. Grafía única: PR-n sin cero (PR-1, no PR-01). Compuerta sobre la guía: `grep -nE "\b(H2?|PAR2?|AJ|DEP|SUP|R|P|PR|S|Q|T|TURNO|EMB)-?[0-9A-C]+\b"` = 0, salvo excepciones listadas con motivo.

**Cambio 4 (Parte 0).** Agrega como primera viñeta: «§0.0 **Tabla de contenido**, generada por `tools/toc.sh` desde los encabezados; no se escribe a mano (H2-046).». Reemplaza la viñeta «§0.2 Rutas de lectura, derivadas de la columna «§» de §0.1. …» por:

> - §0.2 Rutas de lectura, **derivadas** de §0.1 con una regla (H2-038): ruta del actor = tronco ∪ secciones de la columna «§» de sus OA ∪ secciones donde viven las preguntas guía atadas a sus OA ∪ secciones donde se enseña lo que usan sus ejemplos; lo que se agrega a mano lleva motivo. **Tronco común**: §0–§3 y §4.1–§4.3. ACT-DEV: la guía completa. ACT-ARQ: tronco + §4.4, §6, §7, §9, §13; a mano, §8.1 y §8.6–§8.7 (para leer ADR-07 y ADR-12) y §14 (la demo materializa las ADR). ACT-OPS: tronco + §5.4–§5.7, §10.1–§10.6, §11 (sus preguntas guía de OA-O1 y OA-O2, §11.4 y §11.6), §12. ACT-SEC: tronco + §7.1–§7.6, §8.2–§8.5, §8.7, §8.9, §11. Si venís de SK: tronco + §9.7 y el ejemplo 14. `tools/rutas.sh` recalcula las rutas desde la tabla y falla si difieren de las escritas.

Reemplaza en §0.3 «(a) **qué se da por sabido**: C# y .NET 10, inyección de dependencias de `Microsoft.Extensions.DependencyInjection`, ASP.NET Core (controllers o Minimal API) y la idea de capas Domain/Application/Infrastructure; (b) **qué se explica en la guía**: puerto, adaptador y raíz de composición (§4.3) y todo el vocabulario de IA (§3.0 y §4.2);» por «(a) **qué se da por sabido**: C# y .NET 10, inyección de dependencias de `Microsoft.Extensions.DependencyInjection`, ASP.NET Core (controllers o Minimal API), **EF Core con SQLite** y **NUnit** en lo básico, y la idea de capas Domain/Application/Infrastructure; (b) **qué se explica en la guía**: puerto, adaptador y raíz de composición (§4.3), el **circuito de Blazor Server** y por qué no ve la petición HTTP (§8.3), el **intervalo de Clopper-Pearson** (§10.4) y todo el vocabulario de IA (§3.0 y §4.1);».

Agrega al final de la viñeta §0.4: «**Régimen de anclas** (H2-046): cada encabezado lleva un ancla explícita antes del título (`<a id="s5-3"></a>`; partes `parte-iv`, anexos `anexo-f`), y toda remisión de la guía usa esa ancla; los títulos repetidos de la plantilla (Ejemplos, Preguntas guía…) nunca se enlazan por su ancla automática. `tools/toc.sh --verificar` falla si un ancla falta, se repite o una remisión apunta a un ancla inexistente. Los agrupadores de §8 («Escalón 1»…) son párrafos en negrita, no títulos. **Forma de las secciones sin plantilla**: §1–§3, propósito → desarrollo → diagrama → preguntas guía; §13, la plantilla ADR del Anexo A; §14, recorrido por paso; §15, tabla de ítems.»

**Costo**: en la guía, la Parte 0 suma ~120 palabras (anclas y rutas), cubiertas por la opción que se vote en RV-04. Tres scripts (`contar.sh`, `toc.sh`, `rutas.sh`).

**Reversible**: sí.

**Derivados a revalidar**: §A.3 (tabla de OA), todas las fichas (prefijo «plan §»), Anexo D ([REF-nn], PAR2-19), relectura S-14.

**Verificación**: (1) `tools/toc.sh --verificar` y `tools/rutas.sh` pasan sobre la guía. (2) Las dos compuertas `grep` de este parche dan 0 sobre la guía. (3) `tools/contar.sh` da por Parte un número dentro del tope votado + 15 %.

---

## PAR2-18 · §C fichas §1–§15

**Ítems**: X2-03 (AJ-05 reemitido como parche), H2-005 (ADR-13), H2-009 y H2-010 (ADR-12), H2-012, H2-013, H2-014, H2-025, H2-033, H2-035, H2-036, H2-037, H2-040, H2-042, H2-043, H2-048 (títulos), H2-052, RV-01 (papeleta), RV-02 (§14.6).

**Resolución**: X2-03 → reemitir AJ-05 como parche votado, con el contenido de didáctica: cada pregunta guía se reata al OA que ejercita, se crea o ajusta el OA cuando falta, y «local o nube» y «RAG sí o no» tienen una sola casa (5-0-0). Las que no ejercitan ningún OA y no pidió el PO se absorben en el texto de su subsección (no se pierden como contenido).

**§1** (l. 382): reemplaza la viñeta de preguntas por «Preguntas guía: ninguna propia. Las dos de la imagen viven en su casa: «¿Qué del diagrama se sostiene y qué es simplificación?» en §3.1 (OA-0.2) y «¿En qué se distingue una capa de IA de "llamar a una API de IA"?» en §4.4 (OA-A5); §1 remite. (Asignación revisada en el ciclo 2: X2-03.)»

**§2** (l. 391): reemplaza por «Preguntas guía: «Me piden "ponerle IA" a la app: ¿por dónde empiezo?» (OA-0.1; N0b PG-1) · «¿Cómo diseño una pantalla para una respuesta que puede estar mal?» (OA-A2, ajustado: §A.3; PG-2). «¿Qué cambia si el modelo es local o en la nube?» tiene su casa en §12.4 y §2 remite. N0b PG-6 («¿Qué es un *AI Engineer*?») se responde dentro de §2.3. (Asignación revisada en el ciclo 2: X2-03.)»

**§3** (l. 400): agrega ««¿Qué del diagrama se sostiene y qué es simplificación?» (OA-0.2; viene de §1)».

**§4** (l. 407–412; H2-040, H2-036, H2-042, H2-048): Subsecciones: «§4.1 Vocabulario, antes de los hitos: LLM, token, ventana de contexto, prompt e instrucciones, temperatura, salida estructurada, alucinación, grounding, embedding, **modelo de razonamiento y tokens de razonamiento** · §4.2 Por qué ahora: de la arquitectura al componente con contrato (tabla de los 12 hitos «I» de N1b §3.2, casa única; los hitos «C» en una línea; el modelo del laboratorio se nombra como «el usado en el laboratorio», con etiqueta y digest, sin hito: R-07) · §4.3 Dónde vive la capa: Domain sin IA, contrato, adaptador, raíz de composición · §4.4 Dos contratos: el puerto propio de Application y el `IChatClient`, y **cuándo alcanza `IChatClient` como puerto** (el chat de la demo) · §4.5 Antipatrones de ubicación · §4.6 Decisión en curso: ADR-01; toca también ADR-11 (capas como carpetas o proyectos, §4.3) (remite a §13).» Borra la línea «Orden interno: §4.2 se lee antes de §4.1 …». Ejemplos: «ninguno propio (`01` y `02` son de §5); §4.4 se ilustra con la demo: `IExtractorDeLocalidad` (puerto propio) frente al `IChatClient` del chat (§14.2)». Preguntas guía: «¿Mi funcionalidad necesita un LLM o alcanza con código?» (OA-0.1; N1 P1) · «¿Dónde pongo la llamada al modelo en Domain/Application/Infrastructure?» (OA-0.2; N1 P2) · «`IChatClient` ya es una abstracción: ¿hace falta otra interfaz encima?» (OA-A5; N1 P3) · «¿En qué se distingue una capa de IA de "llamar a una API de IA"?» (OA-A5; viene de §1) · «¿La regla de negocio puede vivir en el system prompt?» (OA-D2; N1 P9). «¿Qué cambió el diseño de aplicaciones: el tamaño del modelo o el uso de herramientas?» (N1b P1) se responde dentro de §4.2, que es de contexto. (Asignación revisada en el ciclo 2: X2-03.)

**§5** (l. 417; H2-025, H2-042): en §5.7, después de «Cada cifra lleva modelo, versión y hardware», agrega «. Con `qwen3.5:4b` la reutilización del prefijo **no está medida**: lo medido es de `qwen2.5:0.5b` (transformer puro), y `qwen3.5:4b` es híbrido (H2-025)». Reemplaza «§5.8 Decisión en curso: ADR-02.» por «§5.8 Decisión en curso: ADR-02; toca también ADR-08 (la salida del modelo es una propuesta, §5.3).»

**§6** (l. 426–428; H2-048, H2-025): Propósito: reemplaza «CAG en su versión de servicio» por «el contexto completo con prefijo estable (lo que una app por API puede hacer del CAG)». §6.3: reemplaza «(el «CAG de servicio»; *CAG* sin calificar es sólo el método del paper…» por «(*CAG* sin calificar es sólo el método del paper…» y agrega antes de «· §6.4»: «; lo medido en el laboratorio es de `qwen2.5:0.5b`; con `qwen3.5:4b` no está medido (H2-025)».

**§7** (l. 441): borra «¿Cuándo conviene RAG y cuándo no?» (OA-A3; N3 P1) y agrega al final: ««RAG sí o no» tiene su casa en §6 («Si mi corpus entra en la ventana, ¿tengo que hacer RAG igual?»); §7 remite. Con la opción (b) de RV-05, «¿Quién puede ver qué fragmento?» pasa a OA-S2. (Asignación revisada en el ciclo 2: X2-03.)»

**§8** (l. 448–452; H2-035, H2-033, H2-048): reemplaza «§8.2 Tool calling: el modelo pide, la app ejecuta;» por «§8.2 Llamada con herramientas: el modelo pide, la app ejecuta;». En §8.5, reemplaza «(ej. 09 y 11; cierre:» por «(ej. 09; cierre:». En §8.6, reemplaza «e instancia positiva (ej. 12, variante B)» por «e instancia positiva (ej. 12, variante «un-agente», sin agentes)». Reemplaza §8.7 por «§8.7 Agentes de MAF (`AsAIAgent`, `AgentSession`): el artefacto agente y el escalón 3 son cosas distintas; 11 usa un agente en el escalón 1 por el estado entre dos peticiones, y el escalón 3 (tarea abierta) se explica sin ejemplo ejecutado (§E.4 d) (ej. 11; cierre: «¿qué perderías con `UseFunctionInvocation` y el historial en el circuito?»)». En §8.8, reemplaza «(ej. 12, PR-4)» por «(ej. 12, variante «dos-agentes», con remisión a §8.7; PR-4)». Ejemplos: «08, 09, 10, 11, 12, 13; demo PD-1, PD-5, PD-6 (escalón 1 con estado), PD-7 (sin modelo)».

**§11** (l. 477–481; H2-012, H2-013, H2-014, H2-052, H2-042): en §11.3, reemplaza «**sin herramientas de escritura cuando el pedido trae contexto recuperado** (texto no confiable);» por «**sin herramientas de escritura cuando el pedido trae texto no confiable**, definido por procedencia (contexto recuperado, resultado de una herramienta de recuperación a mitad del bucle, campos libres de lecturas, resultados MCP; §F.4);». En §11.4, agrega «; el registro de corridas (R-LLM) se trata como una traza: entradas sintéticas y compuerta de nombres (AC-7)». En §11.5, agrega al final: «Del lado servidor, escuchar, publicar y validar Host y `Origin` son tres cosas distintas (MCP 2025-06-18, Transports: MUST validar `Origin`), y ninguna es control de acceso. Del lado cliente, las herramientas, descripciones, anotaciones y resultados de un servidor MCP ajeno son no confiables (MCP 2025-06-18, Tools: MUST): lista permitida por nombre y aprobación para toda escritura (ej. 13)». Agrega «· §11.8 Qué decisión toca: ADR-06».

**§12** (l. 486–490; H2-043, X2-03): Ejemplos: «`17`; demo (README y `compose`)». Preguntas guía: «¿Para qué `UseOpenTelemetry` si ya tengo logs?» (OA-O1; N5 P1) · «¿Ollama, Foundry Local o la nube?» (OA-O4; N5 P9; casa única de «local o nube») · «¿Por qué mi modelo local tarda minutos?» (OA-O4; Sondeo §0: cola y cambio de modelo). «¿La caché de respuestas me ahorra siempre?» (N5 P8) se responde dentro de §12.3; «¿Qué cambia del prototipo a producción?», dentro de §12.8. Pasa al Anexo F como estado: N5 P3. Se responde en §12.4 y §6.5: N5 P10. (Asignación revisada en el ciclo 2: X2-03.)

**§13** (l. 495–501; H2-005, H2-009, H2-010, H2-048): Propósito, «ADR-01…ADR-12» → «ADR-01…ADR-13». §13.8: «ADR-07 Escalón de orquestación» (PAR2-02). En §13.12, reemplaza «deja de valer si la demo crece a más de un host» por «deja de valer si las capas tienen que compartirse entre dos hosts (como en el caso base, donde cada host trae su propia copia)». Reemplaza §13.13 por:

> §13.13 **ADR-12 Estado del pedido de aprobación y ciclo de vida del cliente** (H-009, H2-009, H2-010): `IChatClient` base singleton (`AddChatClient`); el `FunctionInvokingChatClient` y las herramientas se arman por circuito, con `AIFunctionFactory.Create(método, instancia)` y sin parámetros de DI; el historial, el pedido pendiente y, en 11, la `AgentSession` viven en el estado del circuito; la respuesta de aprobación se arma en el servidor desde el pedido guardado y la UI sólo manda la decisión; no hay chat por la API ni almacén de conversaciones; confianza media hasta DEP-09 y DEP-11

Agrega después:

> §13.14 **ADR-13 Un host para la demo** (H2-005, H2-055, X2-06): contexto: en `8fb4c3a`, ApiWeb y Web son proyectos independientes, y `Routes.razor` y `App.razor` dependen de `MainLayout`, `NotFound`, quince componentes de `Shared/`, servicios y assets propios. Alternativas: (a) dos hosts, como el caso base; (b) un host sobre la copia de ApiWeb (`Microsoft.NET.Sdk.Web`), con `App.razor`, `Routes.razor` y un layout **nuevos y mínimos**, y `SessionMiddleware`, `Tokens.css` y `Componentes.css` copiados; (c) un host con el cierre completo de dependencias de Web. Decisión propuesta: (b), porque la demo tiene una sola página y (c) arrastra componentes que la guía no usa. Consecuencias: filas de `Program.cs` y de componentes en el delta (§F.2); `UseStatusCodePages` acotado a `/api`; la hoja `@Assets[…styles.css]` con el nombre del ensamblado nuevo, que si queda mal falla en silencio y se verifica en la prueba de humo de la página; ADR-11 sigue valiendo. Deja de valer si la demo vuelve a tener dos presentaciones. Confianza media hasta la primera compilación (DEP-12).

y renumera «§13.14 Decisiones que este registro **no** toma…» a §13.15. En §A.3, OA-A1, «ADR-01…ADR-12» → «ADR-01…ADR-13».

**§14** (l. 506; RV-02): en §14.6, reemplaza «lo «no ejecutado» del presupuesto de §E.5)» por «lo «no ejecutado» del presupuesto de §E.5, y la comparación de calidad entre contexto completo y RAG, que no se ejecutó por costo: RV-02)».

**§15** (l. 515–516; H2-037, RV-01): reemplaza el Propósito por:

> - Propósito: un ítem por objetivo de §0.1, con respuesta explicativa y remisión a la sección. **El tipo de ítem sigue al verbo del OA** (H2-037): para los OA de decisión (ubicar, elegir, decidir, fijar, leer), un caso de Movilidad Urbana («te piden…, ¿qué elegís y por qué?»); para los procedimentales (OA-D1, OA-D9, OA-O1, OA-O2, OA-A1, OA-SK1, y todo OA cuyo verbo sea de hacer), una tarea sobre el ejemplo con un criterio que el lector verifica solo (p. ej., OA-D1: «cambiá el adaptador de 02 tocando sólo `Program.cs`; criterio: el `grep` de 02 lista sólo `Program.cs` y `--fake` pasa»). No agrega material nuevo ni repite preguntas guía literales.

Reemplaza «No hay casos integradores aparte.» por «No hay casos integradores aparte (X-007 en re-votación: RV-01; vigente en forma provisional).». **Papeleta de RV-01**: (a) sin casos integradores (vigente); (b) casos integradores **optativos**, fuera del conteo de ítems (posición de J4 en el ciclo 1); (c) tres casos integradores (posición de J2), ~300 palabras, compensadas con la regla de PAR2-17.

Borra en §1, §2, §4, §10, §12 y §13 la nota «(OA asignados por la secretaría al aplicar el ciclo 1, AJ-05; los revalida didáctica en el ciclo 2)»; donde la asignación cambió, queda «(Asignación revisada en el ciclo 2: X2-03.)»; en §10 y §13 la asignación se confirma sin cambio.

**Costo**: en la guía, +~130 palabras (§5.7, §11.3–§11.5, §13.14, §15) y −~260 (preguntas absorbidas o movidas, «Orden interno», notas). Un ADR nuevo.

**Reversible**: sí.

**Derivados a revalidar**: §A.3 (OA-A2, OA-A5, OA-S2/S3, OA-A1), BIT-16-02 S-05 («§8.7, §8.8, §9 | 11, 12; PD-6»), §G.4 P-11 (§4.2) y P-02 (PAR2-21), R-07 (§4.2), tabla «Una casa por pieza» («Hitos de por qué ahora | §4.2»).

**Verificación**: (1) cada sección tiene ≤ 5 preguntas guía y cada una nombra un OA de §A.3 (script). (2) `grep -n "AJ-05; los revalida"` = 0. (3) «local o nube» y «RAG sí o no» aparecen como pregunta guía una sola vez cada una. (4) `grep -n "Tool calling\|Nivel de orquestación\|CAG de servicio"` = 0 en §C. (5) La línea «Ejemplos» de §12 dice `17`. (6) Ninguna ficha de §8 usa un ejemplo cuyo concepto se enseña en una subsección posterior, salvo con remisión escrita (12 «dos-agentes» en §8.8).

---

## PAR2-19 · §C Anexos

**Ítems**: H2-014 (Anexo B), H2-041 (Anexo F), H2-045 (Anexo D), H2-048 (Anexo C), y la verificación mecánica de remisiones que pide H2-041.

**Cambio 1 (Anexo B, l. 522).** Reemplaza «MCP: sólo lecturas y sólo loopback mientras no haya autorización según la especificación (AllowedHosts no cuenta como control).» por «MCP como servidor: sólo lecturas y sólo loopback mientras no haya autorización según la especificación, con Host y `Origin` validados (ninguno cuenta como control de acceso). MCP como cliente: lo que anuncia un servidor ajeno es no confiable; lista permitida por nombre y aprobación para toda escritura (H2-014).»

**Cambio 2 (Anexo C, l. 523).** Agrega a la lista de términos: *puerto* · *adaptador* · *raíz de composición* · *modelo* · *token* · *temperatura* · *alucinación* · *grounding* · *MCP* · *oráculo* · *línea base* · *entrada distinta* · *marcado del contenido* (alias: spotlighting) · *dificultad* (el rótulo B/I/A de los ejemplos) · *escalón de orquestación*. En *contexto completo con prefijo estable*, reemplaza «(el «CAG de servicio»; …)» por «(alias que la guía no usa en títulos: «CAG de servicio»; el término *CAG* queda reservado para el método del paper, con caché KV persistida)». Agrega al final: «Control C5 (H2-048): ningún título de la guía usa un alias; `grep` de los alias del glosario sobre los encabezados = 0.»

**Cambio 3 (Anexo D, l. 524).** Reemplaza «forma única `[R-nn] Autor…` (H-045). El ID `R-nn` es de la guía.» por «forma única `[REF-nn] Autor…` (H-045, H2-045). El ID `REF-nn` es de la guía y no choca con los riesgos R-nn del plan; en el cuerpo, la cita es `[REF-nn]` al final de la oración que respalda.»

**Cambio 4 (Anexo F, l. 526).** Reemplaza «§5.8 desaparece como subsección: queda una remisión.» por «La lista de paquetes vigentes y obsoletos de la v0 sale de §5 y vive acá; §5 conserva una remisión. (§5.8 de la v1 es «Decisión en curso: ADR-02» y se mantiene: P-02.)» (H2-041).

**Verificación mecánica de remisiones** (H2-041): un script recorre todas las remisiones «§N.k» del índice §C y comprueba que el número existe y que el tema de la remisión coincide con el título de esa subsección (lista de pares número → título generada desde las fichas). Corre en la aplicación de este ciclo y en cada aplicación siguiente.

**Costo**: cuatro ediciones; el glosario suma ~150 palabras (compensación en PAR2-17).

**Reversible**: sí.

**Derivados a revalidar**: BIT-16-02 S-06 (glosario), las citas [R-nn] de las fichas (pasan a [REF-nn]).

**Verificación**: (1) `grep -n "§5.8 desaparece"` = 0. (2) `grep -nE "\[R-[0-9]"` = 0. (3) El script de remisiones no reporta números inexistentes ni temas cruzados. (4) Cada término del glosario remite a la sección que lo define (S-06).

---

## PAR2-20 · §D Tratamiento de PR-1 a PR-22

**Ítems**: H2-039 (desvío de PR-3), H2-045 (grafía PR-1), RV-02 (PR-8), H2-055 (PR-17).

**Cambio.** Fila PR-1, fundamento: reemplaza «Ciclo 1: PR-01 (requisitos)» por «Ciclo 1: informe de requisitos, su ítem sobre PR-1». Fila PR-3, adopción: agrega al final «; (c) el rótulo de dificultad sigue el criterio declarado en §E.2, y por ese criterio y por PR-3 el RAG con citas (07) es avanzado; 06 (sólo embeddings y búsqueda) queda intermedio (H2-039)». Fila PR-8: reemplaza «sin variante RAG» por «sin variante RAG por costo (el 7B en CPU pasa los 400 s por consulta); la comparación de calidad queda como deuda declarada en §14.6 (RV-02)». Fila PR-14: reemplaza «25 OA observables» por «25 o 26 OA observables, según RV-05». Fila PR-17: agrega «; un solo host (ADR-13) y una sola presentación para el chat (H2-055)».

**Costo**: cinco celdas.

**Reversible**: sí.

**Derivados a revalidar**: BIT-16-02 §6 (filas I-02 e I-05, PAR2-23).

**Verificación**: `grep -n "PR-0[0-9]"` sobre el plan = 0 fuera de citas literales de informes; la fila PR-3 nombra el desvío (c).

---

## PAR2-21 · §G Riesgos, dependencias y preguntas

**Ítems**: H2-020 (R-02, DEP-14), H2-050 (P-12, DEP-15), H2-055 (P-03), H2-056 (P-10), H2-057 (DEP-05), y derivados de PAR2-01, PAR2-13 (DEP-04, DEP-09, DEP-10, DEP-11, DEP-13).

**Cambio 1 (§G.1, SUP-09).** «(plan B de §F.6)» → «(EMB-B de §F.6)».

**Cambio 2 (§G.2).** R-02, mitigación: reemplaza «Turnos `build`; Ollama de embeddings con un modelo de 639 MB; borrar contenedores al terminar» por «Las fases del arnés son secuenciales (build, después [recurso-modelo-propio], después <recurso-compartido>) y no se superponen dentro de esta corrida; Ollama de embeddings con un modelo de 639 MB; inventario y limpieza de §E.6. **No mitiga CPU frente a otros usuarios de la máquina**: el gestor de recursos no tiene exclusión entre recursos (H2-020); hasta que la tenga, R-02 cubre sólo memoria y la secuencia propia». R-08, mitigación: reemplaza «Sonda multiherramienta DEP-10 antes de construir 08, 09 y 11; juez con sesgo declarado y protocolo de calibración (§10.6)» por «Sonda multiherramienta DEP-10 antes de construir 08, 09 y 11; juez con sesgo declarado y calibración con salidas del propio generador anotadas a ciegas (§10.6; X-002 en re-votación)».

**Cambio 3 (§G.3).**

| ID | Dependencia | Quién / cómo | Bloquea |
|---|---|---|---|
| DEP-01 | (sin cambio; «plan A» → «EMB-A») | | |
| DEP-04 | **Cerrada por regla** (H2-010): herramientas con `AIFunctionFactory.Create(método, instancia)` en el scope, sin parámetros de DI; el `FunctionInvokingChatClient` por scope sobre el base singleton. Queda la prueba `Composicion_ValidateScopes` | Constructores, primera compilación | PD-1, PD-5, PD-6 |
| DEP-05 | **Cerrada por decisión**: `sdk:10.0` + `dotnet run`; sin `Dockerfile` multietapa ni `PublishContainer` (H2-057) | — | — |
| DEP-09 | Aprobación con `UseFunctionInvocation` sin MAF, **en dos peticiones**: el pedido se guarda en el servidor y la segunda petición arma la respuesta desde él; incluye `Aprobacion_ArgumentosAlterados_SeRechaza` (H-015, H2-009) | Sonda en cableado y una llamada real (TURNO-1, §E.5) | 09, PD-5, PD-6 |
| DEP-10 | Selección entre varias herramientas sobre `qwen3.5:4b`: el conjunto completo y **2 entradas** de la cadena listar → eliminar(id), con entradas de `entradas.dev.json` (no de medición). Si la cadena falla en alguna, o si la línea de corte la saca (§E.5, 1b), el contrato pasa a `eliminar_localidad(nombre, provincia)`, resuelto por el caso de uso (con error si es ambiguo) | Sonda R-LLM, turno `<recurso-compartido>` (TURNO-1) | 08, 09, 11, PD-6 |
| DEP-11 | `SerializeSessionAsync`/`DeserializeSessionAsync` de MAF 1.26.0 (sin cambio en el contenido) | Sonda en cableado | **11** (PD-6 ya no depende de ella: §F.4) |
| DEP-13 | Medir p de cada pieza con `--fake` y t por clase con las llamadas de DEP-09, DEP-10 y DEP-13, y recalcular §E.5 (PAR2-01) | Sonda con turno `<recurso-compartido>` | §E.5 |
| DEP-14 | Recurso `[recurso-modelo-propio]` (cupo 1, ttl declarado) en el gestor de recursos. Hoy, con `cupos.conf` = `[recurso-modelo-propio] 1`, `<gestor-de-turnos>` aborta («TTL[$r]: variable sin asignar», rc = 1; prueba aislada del ciclo 2) | **Dueño: el gestor de recursos de la raíz del workspace (MD-2)**, por pedido de la presidencia (PAR2-25); la mesa no lo escribe. Criterio verificable en PAR2-25 | 02, 05, 06, 07, 16, PD-2 (EMB-B) |
| DEP-15 | **Decisión de la mesa sobre P-12** (H2-050), condición previa | Jurado, en la aprobación de este ciclo | 04 y PD-4 (entradas sintéticas), 05, 12, 16, PD-1 |

**Cambio 4 (§G.4).** P-03: reemplaza la propuesta por «Sí, una página mínima, como **única presentación del chat** (re-decidida con su costo en el ciclo 2: H2-055 opción a; ADR-13). Pregunta a la presidencia: ¿el contrato exige que la demo sola recorra los cinco escenarios?». P-10: reemplaza por «Resuelto en el ciclo 2 (H2-001, H2-056, X2-02, X2-07): demostración frente a medición, TURNO-1 dentro del tope y línea de corte sin deuda automática (§E.5). Las fusiones se votan en la papeleta de H2-056». P-11: «§4.1» → «§4.2» (PAR2-18). P-12 se reformula:

> | P-12 | ¿El contenido «escrito para el ejemplo» cumple RD-PO-1 y RD-PO-3, o es una tercera vía que I-06 no prevé? Comprende: el reglamento sintético de 05, cuyos artículos usan «la localidad ficticia Nº n», que **no** viene de la ia-db de Movilidad Urbana; el documento malicioso de 16; la siembra de encuestas (PD-1, 12 y `resumir_encuesta`); y las entradas sintéticas de 04, PD-4 y 12 (H2-052) (H-051, H2-050) | Propuesta del plan: cumple, porque usa sólo entidades y valores de Movilidad Urbana y se rotula. **Si la mesa dice que no**: 05 pasa a explicación conceptual y OA-D3 queda sin ejemplo ejecutado; 16 pasa a explicación y §11.7 queda conceptual (OA-S2 se ejercita sólo con 09); sin siembra, PD-1 pierde la pregunta de la encuesta y 12 y `resumir_encuesta` quedan en `--fake`; las entradas de 04 y PD-4 necesitan otra fuente. Variante intermedia que también se vota: el reglamento de 05 sin «localidades ficticias», sólo con provincias de `Catalogos` y las localidades sembradas. **Se decide en la aprobación de este ciclo** (DEP-15) |

**Costo**: filas de tabla. 0 llamadas.

**Reversible**: sí.

**Derivados a revalidar**: §E.5 (DEP-10, DEP-13), PAR2-25 (DEP-14), §E.2 filas 05, 12, 16 (según P-12).

**Verificación**: (1) toda DEP que bloquea algo tiene dueño y criterio verificable. (2) `grep -n "Propuesta: cumple"` = 0 (P-12 pasa a decisión). (3) DEP-15 figura en §G.3 como condición previa de 05, 12, 16 y PD-1.

---

## PAR2-22 · §H Registro de cambios y changelog del ciclo 1

**Ítems**: H2-041 (§H), RV-01 (atribución), RV-06, RV-07, RV-08, RV-10, RV-11 (papeleta).

**Cambio 1 (§H, fila v1, l. 900).** Reemplaza «parches PAR-01…PAR-23 de Mesa/Ciclo-1/05-Parches.md (63 hallazgos, X-001…X-009, PR-1…PR-22).» por «parches PAR-01…PAR-24 de Mesa/Ciclo-1/05-Parches.md (93 ítems PROCEDE: 63 hallazgos, X-001…X-009 y 21 propuestas PR) y los ajustes de aplicación AJ-01…AJ-08 de Mesa/Ciclo-1/07-Aplicacion-Y-Verificacion.md.». Agrega la fila v2:

> | v2 | (fecha de aplicación) | Ciclo 2 de la mesa: parches PAR2-01…PAR2-27 de Mesa/Ciclo-2/05-Parches.md. AJ-03 reemplazado por la decisión de alcance de §E.5; AJ-01 y AJ-05 reemitidos como parches; turnos TURNO-1…3; demo con un host (ADR-13) y una sola presentación del chat; §E.6 nueva |

**Cambio 2 (changelog del ciclo 1).** Agrega al final, bajo un subtítulo nuevo «### Re-votos del ciclo 2 sobre el ciclo 1» (no se reescriben las filas del ciclo 1; se anotan):

| Ítem del ciclo 1 | Re-voto | Corrección |
|---|---|---|
| H-001 | RV-08 | El fundamento de costo «cuesta las mismas llamadas» de J3 no incluía las 24 llamadas de estabilidad que sumó PAR-15; en la v2, la estabilidad son 3 llamadas (sólo 07: §E.5) |
| H-004 | RV-06 | Severidad S1 → **S3**; capa de origen **N6** (el `int` no anulable está sólo en `N6-Evidencia/sonda-Program.cs:94`; en el caso base, `Habitantes` ya es `int?`). La garantía falsa del principio la corrige H2-032 |
| H-008 | RV-07 | Severidad → **S3**: el caso base ya pasaba `SessionId` al circuito; el defecto era la descripción, no una fuga. PAR-17 conserva sólo la corrección descriptiva |
| H-009, H-014, H-049 | RV-10 | Nivel de evidencia E4 → **E2** (omisión citada): no hay regla externa del contrato que los sostenga (M: E4 = regla externa declarada en el contrato de entrada) |
| X-002 | RV-11 | En re-votación. **Papeleta**: (a) sesgo declarado con la calibración de 15 sobre salidas del propio generador (vigente en forma provisional); (b) juez de otra familia en el Ollama propio por turnos, **elegible sólo con DEP-14 resuelto** (sin DEP-14 no hay dónde correrlo sin tocar el compartido: R-04) |
| X-007 | RV-01 | La resolución de PAR-02 («sin casos integradores») no tuvo mayoría: J2 pedía casos integradores, J3 ninguno, J4 optativos; PAR-02 le atribuyó a J4 una posición que no tomó. En re-votación (papeleta en PAR2-18, §15) |
| X-008 | RV-02 | La eliminación de la comparación entre contexto completo y RAG (PAR-08, PAR-14) queda registrada como decisión por costo, con la comparación como deuda en §14.6 |
| H-021 / PR-3 | RV-03 | Tope y t por llamada en re-votación (papeleta en §E.5) |
| H-026, H-060 | RV-09 | La re-medición con embeddings no es «barata»: depende de DEP-14 (H2-020) y compite con `build` (R-02) |
| H-035 / PR-14 | RV-05 | 25 OA en re-votación (papeleta en §A.3) |
| H-040 | RV-04 | El número 43.700 en re-votación (papeleta en §C, presupuesto) |
| PAR-10 | RV-13 | El rango «11 a 200 s» queda reemplazado por voto por las cifras de AJ-02 (ratificado: RAT-AJ-02) |

**Costo**: dos filas en §H y una tabla de 12 filas en el changelog.

**Reversible**: sí.

**Derivados a revalidar**: `Ciclo-1/05-Parches.md` §Cobertura (PAR2-24), N6 (PAR2-26).

**Verificación**: (1) `grep -n "PAR-01…PAR-23"` = 0. (2) La fila v1 de §H nombra PAR-24 y AJ-01…AJ-08, como el encabezado de l. 16. (3) Cada RV PROCEDE de este ciclo aparece en la tabla nueva, en PAR2-01 (RV-03, RV-13) o en PAR2-24 (RV-14).

---

## PAR2-23 · BIT-16-02 §6: matriz única (capa de origen)

**Ítem**: H2-049.

**Archivo**: `../../../02-Cohesion-Global.md`, §6, tabla de la matriz única.

**Cambio.** Reemplaza la fila «Q1–Q6 | Preguntas de §7 de REED-16 | (una fila por pregunta, con su sección) | — | cada una con sección» por seis filas:

| ID | Solicitud o pedido (resumido) | Sección de la guía (v1) | Ejemplo / paso / artefacto | Criterio verificable |
|---|---|---|---|---|
| Q1 | ¿Qué es una capa de IA y qué responsabilidades tiene frente al negocio y los datos? ¿Qué del diagrama se sostiene y qué es simplificación? | §1, §3.1, §4.3–§4.4 | demo §14.2 | §3.1 lleva la pregunta del diagrama (OA-0.2) y §4.4 la de capa frente a API (OA-A5) |
| Q2 | ¿Qué abstracciones ofrece .NET para hablar con un modelo sin atarse al proveedor; cuáles son GA, preview o deprecadas? | §5, §9.1, Anexo F | 01, 02 | el Anexo F tiene estado y fecha por paquete |
| Q3 | ¿Cómo se arma un pipeline RAG en .NET y cuándo no hace falta RAG? | §6, §7 | 05, 06, 07; PD-2 | «RAG sí o no» con casa única en §6 |
| Q4 | ¿Qué es un agente, en qué se diferencia de una llamada con herramientas y con qué marco se construye? ¿Qué es LangGraph y qué hay en .NET? | §8.1, §8.7, §9.4–§9.5 | 11, 12; snippet «adaptación no ejecutada» | Q-PO-1 respondida en §9; frontera 1/3 operativa en §8.1 |
| Q5 | ¿Cómo se prueba, se observa y se asegura una capa de IA? | §10, §11, §12 | 15, 16, 17 | AC-3b, AC-4 |
| Q6 | ¿Cómo queda integrado en Movilidad Urbana sin romper Domain → Application → Infrastructure, y qué muestra la demo contra Qwen? | §14 | `Demos/MovilidadUrbana.Asistente/` | AC-10, AC-3b |

Reemplaza la fila «I-04 §5.2 | Preocupaciones de audiencia | relectura (PR-15) | — | lista de control interna» por dos filas: «I-04 §5.2 | ¿La señal de evaluación alcanza para convocar a AH-02? | — (proceso) | AH-02 en `Mesa/Ciclo-1/02-Informes/` y `Mesa/Ciclo-2/02-Informes/` | resuelta: sí, AH-02 integra el panel desde el ciclo 1 (`Ciclo-1/01-Convocatoria.md`, fila 12)» y «I-04 (preocupaciones de audiencia) | Lista de control de la relectura | relectura (PR-15) | — | lista de control interna».

Reemplaza la fila «I-05 §5.2–§5.3 | PR-16…PR-22 | …» por dos filas: «I-05 §5.1, §5.3 | PR-16…PR-22; «¿integrar o construir un marco?» como pregunta guía | §A.4, §8, §9, Anexo B | 08, 09, 14 | filas de BIT-16-04 §D» y «I-05 §5.2 | ¿PR-17 abre un escenario nuevo en N0 o es una variante de ESC-04, y cómo entra a la demo sin ampliar su alcance? | §2.1, §14 | demo | **pendiente de la presidencia**: (a) variante de ESC-04, sin ESC nuevo, como encuadre de la demo; o (b) escenario nuevo con su matriz; o apartamiento declarado. P-05 deja de reformularlo como par de contextos».

Agrega la fila «I-02 §5 | PR-1…PR-7; si PR-3 cabe en la demo o el nivel avanzado se cubre con ejemplos separados; combinación con I-01 | §D, §B.3 | §E, §F | filas PR-1…PR-7 de BIT-16-04 §D; desvío (b) de PR-3 declarado».

En la fila S-08, «§15 con 25 ítems» → «§15 con un ítem por OA (25 o 26, según RV-05)». En S-05, «11, 12; PD-6» se mantiene.

**Costo**: nueve filas. 0 llamadas.

**Reversible**: sí.

**Derivados a revalidar**: §G.4 P-05 del plan (según la respuesta de la presidencia).

**Verificación**: (1) la fila «Q1–Q6» como marcador no existe; hay seis filas Q, cada una con sección y criterio. (2) Las filas I-04 §5.2 e I-05 §5.2 citan el pedido literal del insumo (`grep` de «AH-02» y de «escenario nuevo»). (3) Hay una fila I-02.

---

## PAR2-24 · `Mesa/Ciclo-1/05-Parches.md` §Cobertura (capa de origen)

**Ítem**: RV-14.

**Archivo**: `../Ciclo-1/05-Parches.md`, l. 14 y l. 984.

**Cambio.** En l. 14, «los 85 ítems con veredicto PROCEDE (63 hallazgos, 9 contradicciones, 21 propuestas PR; …)» → «los 93 ítems con veredicto PROCEDE (63 hallazgos, 9 contradicciones, 21 propuestas PR; …)». En l. 984 (§Cobertura), «Los 85 ítems PROCEDE tienen parche» → «Los 93 ítems PROCEDE tienen parche». Agrega en §Cobertura: «Nota del ciclo 2 (RV-14): el 85 era un error de suma (63 + 9 + 21 = 93). El cuerpo auditor del ciclo 2 cruzó id por id los 93 PROCEDE de `04-Veredictos.md` contra este archivo (`grep -w`) y los 93 tienen parche: no falta ninguno.»

**Costo**: dos números y una nota.

**Reversible**: sí.

**Derivados a revalidar**: §H del plan (PAR2-22).

**Verificación**: el bucle de §0.2 (ids PROCEDE de 04-Veredictos contra 05-Parches) imprime 0 faltantes; `grep -n "85 ítems"` sobre `Ciclo-1/05-Parches.md` = 0.

---

## PAR2-25 · Pedido al gestor de recursos (capa externa, con dueño)

**Ítem**: H2-020.

**Capa**: el gestor de recursos de la raíz del workspace (`<gestor-de-turnos>/`), fuera del perímetro de escritura de esta mesa. **La mesa no lo escribe**: la presidencia le pasa este pedido a su dueño (MD-2).

**Pedido.** (1) Dar de alta el recurso `[recurso-modelo-propio]` con cupo 1 y un ttl declarado en `cupos.conf`, de modo que `<gestor-de-turnos>` no aborte: hoy, en un `<dir-del-gestor>` aislado con «[recurso-modelo-propio] 1», aborta en la línea 94 con «TTL[$r]: variable sin asignar» (rc = 1), porque las declaraciones de cupo y ttl de las l. 23–24 no lo incluyen. (2) Escribir una regla de convivencia entre `[recurso-modelo-propio]` y `build`: exclusión mutua, o la declaración de que no la hay. (3) Opcional, pedido por H2-004: que la renovación de `<gestor-de-turnos>` acepte un plazo máximo.

**Criterio verificable**: en un `<dir-del-gestor>` aislado con `[recurso-modelo-propio] 1`, `pedir`, `renovar` y `liberar` devuelven 0 y `estado` lo lista; la regla de convivencia está escrita en `PROTOCOLO.md`.

**Mientras tanto**: rige EMB-B en el plan, pero 02, 05, 06 y la fase de embeddings no corren; si el pedido no se resuelve antes de construir, rige EMB-C (§F.6) y la mesa lo registra (AC-3b).

**Costo**: un cambio chico en un script ajeno, con dueño. 0 llamadas.

**Reversible**: sí, para el dueño del gestor.

**Derivados a revalidar**: §G.3 DEP-14 y §G.2 R-02 (PAR2-21), §E.5 TURNO-3.

**Verificación**: la del criterio, corrida por el dueño del gestor; la presidencia registra el resultado en el cierre del ciclo.

---

## PAR2-26 · N6: nota sobre la sonda (capa de origen de H-004)

**Ítem**: RV-06.

**Archivo**: `../../../Nucleos/N6-Caso-Movilidad-Urbana.md`, l. 504 (la viñeta «**`LocalidadPropuesta.Habitantes`** (H-004): …»).

**Cambio.** Agrega al final de la viñeta: «(Re-votado en el ciclo 2, RV-06: el defecto nace en esta sonda y no en el caso base; severidad S3. La garantía contra la invención no la da el `int?`: la da el código, BIT-16-04 §A.4, punto 1.)». La sonda `N6-Evidencia/sonda-Program.cs` no se toca: es evidencia de lo que se corrió.

**Costo**: una oración.

**Reversible**: sí.

**Derivados a revalidar**: ninguno.

**Verificación**: `grep -n "RV-06" ` sobre N6 da la línea; `git status` o la comparación de hashes muestra la sonda sin cambios.

---

## PAR2-27 · Ratificaciones sin cambio

**Ítems**: RAT-AJ-04, RAT-AJ-06, RAT-AJ-07, RAT-AJ-08.

**Cambio.** Se **ratifican** sin cambio de texto:

- **AJ-04** (una sola regla en AC-8; «Línea» sólo como identificador de código). Los patrones defectuosos se corrigen aparte (H2-053, PAR2-03), sin tocar la regla.
- **AJ-06** (IDs v0 → v1, tabla de §E.3). Sus dos residuos se completan en otros parches: «§5.8 desaparece» (PAR2-19) y «Ejemplos: `16`» en §12 (PAR2-18).
- **AJ-07** (líneas de fuente y escenarios en §0, §2, §3 y §15: l. 372, 388, 397, 518).
- **AJ-08** (S-12 remite a `Mesa/Ciclo-1/01-Convocatoria.md`, que existe).

En `Ciclo-1/07-Aplicacion-Y-Verificacion.md` §2 no se escribe nada: la ratificación queda en `06-Aprobacion.md` de este ciclo y en la tabla de re-votos del changelog (PAR2-22).

**Costo**: ninguno.

**Reversible**: sí.

**Derivados a revalidar**: ninguno.

**Verificación**: los anclas siguen en el plan v2: `grep -n "AJ-07"` da las cuatro fichas; `ls Mesa/Ciclo-1/01-Convocatoria.md` existe; AC-8 tiene una sola regla.

---

## Cobertura

| Ítem | Parche(s) |
|---|---|
| H2-001 | PAR2-01 |
| H2-002 | PAR2-01, PAR2-09 |
| H2-003 | PAR2-03, PAR2-11 |
| H2-004 | PAR2-04, PAR2-06, PAR2-25 |
| H2-005 | PAR2-12, PAR2-18 (ADR-13) |
| H2-006 | PAR2-07, PAR2-12 |
| H2-007 | PAR2-03, PAR2-07 |
| H2-008 | PAR2-03, PAR2-07, PAR2-12, PAR2-13 |
| H2-009 | PAR2-03, PAR2-13, PAR2-18, PAR2-21 |
| H2-010 | PAR2-13, PAR2-18, PAR2-21 |
| H2-011 | PAR2-11, PAR2-13 |
| H2-012 | PAR2-03, PAR2-09, PAR2-13, PAR2-16, PAR2-18 |
| H2-013 | PAR2-13, PAR2-14, PAR2-18 |
| H2-014 | PAR2-09, PAR2-18, PAR2-19 |
| H2-015 | PAR2-12 |
| H2-016 | PAR2-05, PAR2-09 |
| H2-017 | PAR2-05, PAR2-14 |
| H2-018 | PAR2-04 |
| H2-019 | PAR2-01, PAR2-04 |
| H2-020 | PAR2-21, PAR2-25 |
| H2-021 | PAR2-08 |
| H2-022 | PAR2-06 |
| H2-023 | PAR2-06 |
| H2-024 | PAR2-06 |
| H2-025 | PAR2-09, PAR2-18 |
| H2-026 | PAR2-09 |
| H2-027 | PAR2-09, PAR2-14 |
| H2-028 | PAR2-09 |
| H2-029 | PAR2-06, PAR2-09 |
| H2-030 | PAR2-09 |
| H2-031 | PAR2-06 |
| H2-032 | PAR2-09, PAR2-14, PAR2-16 |
| H2-033 | PAR2-09, PAR2-16, PAR2-18 |
| H2-034 | PAR2-09, PAR2-16 |
| H2-035 | PAR2-09, PAR2-18 |
| H2-036 | PAR2-15, PAR2-18 |
| H2-037 | PAR2-18 |
| H2-038 | PAR2-17 |
| H2-039 | PAR2-02, PAR2-20 |
| H2-040 | PAR2-18 |
| H2-041 | PAR2-15, PAR2-19, PAR2-22 |
| H2-042 | PAR2-18 |
| H2-043 | PAR2-18 |
| H2-044 | PAR2-15, PAR2-17 |
| H2-045 | PAR2-03, PAR2-17, PAR2-19, PAR2-20 |
| H2-046 | PAR2-17 |
| H2-047 | PAR2-17 |
| H2-048 | PAR2-02, PAR2-16, PAR2-18, PAR2-19 |
| H2-049 | PAR2-23 |
| H2-050 | PAR2-21 |
| H2-051 | PAR2-03, PAR2-12 |
| H2-052 | PAR2-03, PAR2-06, PAR2-18 |
| H2-053 | PAR2-03 |
| H2-054 | PAR2-01, PAR2-11 |
| H2-055 | PAR2-11, PAR2-20, PAR2-21 |
| H2-056 | PAR2-01, PAR2-21 |
| H2-057 | PAR2-05, PAR2-09, PAR2-14, PAR2-21 |
| H2-058 (S4) | PAR2-03 |
| H2-059 (S4) | PAR2-10 |
| RAT-AJ-02 | PAR2-01 |
| RAT-AJ-04 | PAR2-03, PAR2-27 |
| RAT-AJ-06 | PAR2-27 (residuos: PAR2-18, PAR2-19) |
| RAT-AJ-07 | PAR2-27 |
| RAT-AJ-08 | PAR2-27 |
| RAT-NIVEL | PAR2-02 |
| RV-01 | PAR2-18, PAR2-22 |
| RV-02 | PAR2-09, PAR2-18, PAR2-20, PAR2-22 |
| RV-03 | PAR2-01, PAR2-22 |
| RV-04 | PAR2-17, PAR2-22 |
| RV-05 | PAR2-15, PAR2-22 |
| RV-06 | PAR2-22, PAR2-26 |
| RV-07 | PAR2-13, PAR2-22 |
| RV-08 | PAR2-01, PAR2-22 |
| RV-09 | PAR2-03, PAR2-14, PAR2-22 |
| RV-10 | PAR2-22 |
| RV-11 | PAR2-09, PAR2-22 |
| RV-13 | PAR2-01, PAR2-22 |
| RV-14 | PAR2-24 |
| X2-01 | PAR2-02 |
| X2-02 | PAR2-01 |
| X2-03 | PAR2-15, PAR2-18 |
| X2-04 | PAR2-05 |
| X2-05 | PAR2-11, PAR2-16 |
| X2-06 | PAR2-11, PAR2-12, PAR2-18 |
| X2-07 | PAR2-01 |

Los 85 ítems PROCEDE de este ciclo tienen parche (59 hallazgos, 6 ratificaciones, 13 re-votos, 7 contradicciones: 59 + 6 + 13 + 7 = 85).
