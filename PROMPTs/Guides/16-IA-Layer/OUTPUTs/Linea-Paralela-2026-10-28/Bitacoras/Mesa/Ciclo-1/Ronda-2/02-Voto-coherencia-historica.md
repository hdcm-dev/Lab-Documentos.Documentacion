---
doc_id: BIT-16-C1-R2-02-COH
doc_type: voto
title: Voto del juez de coherencia histórica en la segunda ronda del ciclo 1
status: entregado
origin: agent
owner: juez de coherencia histórica (REED-16 §9.4)
last_review: 2026-10-28
audience: [presidencia, relator, cuerpo-auditor]
traces: [Ronda-2/00-Boleta.md, Ronda-2/Consulta-*.md, Mesa/Ciclo-1/07-Dictamen-Presidencia.md, Mesa/Ciclo-1/02-Revision-Homogeneidad.md, Mesa/Ciclo-1/02-Voto-coherencia-historica.md, Mesa/Ciclo-1/03-Parches.md (P-05, P-17, P-27, P-30, P-35), Mesa/Ciclo-1/05-Aplicacion.md, BIT-16-00 (DC-01…DC-08, SUP-05), BIT-16-03 §1 (ESC-01…ESC-05), BIT-16-04 §2 (tensiones 1, 6, 7), §4 (R-C02, R-C03, R-C07, R-C13, R-C16, R-C20), §6.2 (diagrama), Mesa/I-06]
---

# Voto de coherencia histórica — segunda ronda del ciclo 1

**Función fija.** ¿Es coherente con DC-01…DC-08, I-06, BIT-16-04, el ciclo 1 y el dictamen de presidencia? Voto una clave por ítem (dictamen §3.4). En los dependientes uso la opción «sigue al antecedente» cuando existe, que equivale a un voto condicionado (boleta §0.3). Mi cadena es C1-48 = C → C1-40 = A → C1-62 = A, C1-14 = A; C1-55 y C1-56 = A; C1-28 = A, con M13 en la demo.

**Qué cambio respecto de la ronda 1, y por qué.** En dos ítems me muevo: C1-38 (de B a A) y C1-37 (de «R-C07 salvo prueba» a doble capa). En los dos casos se cumplió la condición que yo mismo puse en la ronda 1: P-17 dejó la pieza fuera del árbol copiado, y PC-02 corrió la prueba de doble capa. No es un cambio de criterio: es aplicar el criterio que ya estaba escrito.

## Bloque del perímetro

| Ítem | Clave | Fundamento |
|---|---|---|
| C1-48 | **C** | La demo no puede bajar de lo que ya está cerrado: SUP-05 (web Blazor y API), DC-05 (réplica de Web y ApiWeb), la tensión 7 (copia literal) e I-04 (capas a la vista). En BIT-16-04 hay además resoluciones de integración que ya ubican piezas en la demo: R-C02 (ESC-04 con `ApprovalRequiredAIFunction`), R-C13 (`IAyuda` con dos adaptadores elegidos por configuración), R-C16 (candidato de ESC-02) y el diagrama único de §6.2, que dibuja `/mcp: sólo lecturas`. La opción A las saca sin abrirlas formalmente. La B suma D7 pero deja afuera R-C13 y R-C16. La C es la única que conserva todo lo resuelto y exige que cada agregado pase el corte de la tensión 6 (P-27), que es la regla que la propia integración fijó para esto. La tabla de P-05 sigue valiendo como mapeo ESC/CTX; lo que cambia es la columna «En la demo». |
| C1-40 | **C** | Es el voto condicionado coherente: rama A con C1-48 = C, rama B con C1-48 = A o B. La revisión §3.1 demostró que la A de C1-48 (ABOGAD-05) ya trae adentro la B de C1-40: votarlas por separado reproduce la incoherencia del ciclo. Con C1-48 = C rige R-C02, que la integración resolvió con E1 (X2 D1 y D6). PC-13 no refuta R-C02: dice que las dos ramas son defendibles y fija A1–A5. La alteración de la sesión serializada (77 en lugar de 7) queda cubierta por A1 (almacén sólo en el servidor) y por A4 (la entidad se vuelve a leer). BIT-16-03 define ESC-04 como el escenario donde el modelo «puede escribir». |
| C1-62 | **D** | Sigue a C1-40, y en mi cadena eso da A, que es R-C02 tal como se escribió: ESC-03 propone sin persistir y ESC-04 usa la aprobación. La C (alta sin aprobación, N6 P6) es justamente lo que R-C02 corrigió, y contradice la parte común firme de P-35. La comparación 2b/4b (D1: CP inventado 10/10 con el 4b) confirma que ninguna rama puede soltar la confirmación. |
| C1-55 | **C** | Sigue al perímetro: A con C1-48 = C, porque R-C13 (= RA-6 = C-6) y C-9/D-04 ya resolvieron un puerto y dos adaptadores, con el mismo oro para los dos. B con C1-48 = A o B: ahí rige la regla de perímetro (boleta §0.4), y sumar RAG sería un cambio de alcance. La parte común de P-23 (contexto fijo por defecto, sin conclusión comparativa antes de correr) no cambia con ninguna rama. |
| C1-56 | **C** | Mismo razonamiento: R-C16 resolvió el candidato «buscar el requisito por significado», y BIT-16-03 declaraba los candidatos «a decidir en plan». Con C1-48 = C entra la propuesta, con las métricas de P-22. Con C1-48 = A o B, la regla de perímetro lo manda a `Examples/04`. |

## Ubicación de la normalización

| Ítem | Clave | Fundamento |
|---|---|---|
| C1-38 | **A** | En la ronda 1 voté B porque la A obligaba a meter una pieza dentro del árbol copiado y rompía el `diff -r` = 0 de la tensión 7 (EA-2/EA-3). P-17 (4), que aprobé, saca la pieza del árbol (`Agregado/Application/Normalizacion/`) y deja la invocación «dentro de la función .NET, antes del caso de uso» (R-C03, M2). Las dos resoluciones se cumplen a la vez. P-30 ya nombra `Agregado/Application` en la prueba de reflexión: la A es la única opción que no obliga a reescribir un parche aplicado. La B cumple R-C03 al pie de la letra, pero deja la regla en Infrastructure y no sirve para el endpoint normal de la prueba de cierre común. La C rompe la tensión 7 tal como se verificó (18 archivos, `diff -r` = 0 sobre lo copiado). |
| C1-53 | **A** | Con C1-38 = A, el criterio queda «`diff -r` = 0 sobre todo lo copiado», que es la tensión 7 sin cambios, coherente con DC-05 (procedencia: ruta y commit) y con C1-19. La B reimplementa el dominio y agrega un ESC-06: eso contradice el marco fijado una sola vez (R-PROF, BIT-16-03) y la copia literal. M2 queda, así que la condición de AH-01 se cumple. |

## Re-registros

| Ítem | Clave | Fundamento |
|---|---|---|
| C1-67 | **A** | Es lo que pidió la revisión §2.1, con la evidencia nueva de PC-14. La variante `Localidad.Nombre` ilustra el patrón con un campo real del caso único (I-06, RD-PO-1), en lugar de un `Comentario` hipotético. La B tira un ejemplo validado sin ningún motivo de coherencia. `Examples/11` sale en las dos opciones (P-44). |
| C1-72 | **A** | (a) ya está resuelta por C1-47 (P-40). Para (b), R-C20 la dejó afuera por falta de fuente, y R-PO-7 impide afirmar un umbral sin métrica definida: corresponde «no medido». Que R-LLM-3d reemplace al N ≥ 96 es una corrección con fuente (AH-02, PC-10), no una reapertura de lo resuelto. La B abre una investigación dentro del ciclo que los cinco rechazaron en sustancia. |
| C1-61 | **A** | Es P-39, votada 5/5. La tabla de PC-05 (`TopK` descartado, `max_completion_tokens` ignorado, sin `num_ctx` por pedido) refuerza que la vía `/v1` no se puede mostrar en la demo sin rebajar lo que la demo afirma. |
| C1-64 | **A** | Es P-38, y es coherente con la tensión 6, que deja la evaluación continua con umbral en CTX-PROD. Las cifras de PC-08 se suman como dato de costo. La B mete al ciclo de demo una corrida que la tensión 6 no pide. |
| C1-42 | **A** | Es P-37, votada 5/5. El hecho medido del 35b-a3b (21 GiB) es E1 y confirma la causa «límite del contenedor». La B atribuye una causa que nadie midió para un denso de 7–9B. |
| C1-43 | **A** | Coincide con mi voto de la ronda 1 (C1-49 con fundamento de diseño). La réplica de PC-10 da P0 12/16 y 40/40 en los otros cinco pedidos: es una tasa de un pedido y no respalda una regla general. La tensión 1 se reescribe con nota fechada, sin tocar «A por defecto por diseño». |
| C1-44 | **A** | Es el mismo objeto que C1-64. |
| C1-45 | **A** | Es el mismo objeto que C1-61. |
| C1-46 | **A** | R-C20/PR-13 mantiene D-01…D-10 «actualizados»; D-06 ya trata las herramientas con alcance por petición. P-13 tomó D-11 para el estado de la conversación, así que un ADR nuevo para el ciclo de vida duplicaría el objeto de D-06. El contenido es el de C1-12. |
| C1-50 | **A** | DC-06 fija sólo «Qwen»; la tensión 4 dejó al 4b como «propuesto». El rótulo nuevo describe la corrida 2b/4b sin decir más de lo que mide (R-PO-7), y corrige el 2b a Q8_0 con su digest. La B contradice CTX-LOCAL × CTX-PROTO de BIT-16-03 y el dictamen §4, que ubica el segundo servidor como apoyo de la mesa, no como el entorno de la demo. |
| C1-51 | **A** | El dictamen §4 lo autoriza «para lo que estación 1 no cubre», reversible y medido con el mismo `sondeo.py`. El texto de Operación, votado 5/5, es la lectura acotada de esa autorización. La B amplía el alcance a la concurrencia y al contexto grande, que la ronda 1 dejó en «no medido». Cuándo se apaga lo decide la presidencia (boleta §6). |
| C1-59 | **A** | Es P-27 (M1–M15), que extiende la tensión 6 con su mismo corte y con la nota de coherencia de BIT-16-04 («pruebas adversariales **extendidas**»). La forma de M13 sale de C1-28, y la prueba concurrente de M6 tiene E1 en PC-11. La B volvería a abrir la contradicción entre M14 y la lista CTX-PROD, que ya se resolvió. |
| C1-71 | **A** | Es el mismo objeto que C1-46. |

## Precisiones

| Ítem | Clave | Fundamento |
|---|---|---|
| C1-12 | **A** | En la ronda 1 acepté reabrir R-C04 con evidencia nueva. PC-11 cerró la pregunta C con E1 (sonda D2): con Singleton, la sesión B leyó y borró lo que escribió A, y con `ValidateScopes=true` la falla aparece en cada llamada, no al arrancar. Un título tiene que decir lo que se probó. La B quedó refutada por esa evidencia, y la C la esconde. |
| C1-37 | **A** | En la ronda 1 condicioné la reapertura de R-C07 a una prueba de que la doble capa conserva lo que R-C07 aseguraba (los aciertos de caché a la vista desde afuera, N5 E2/V2/V3) y además muestra los spans de herramientas. PC-02 lo mostró en la misma traza. Con eso la reapertura queda fundada, y la doble capa es la única rama que conserva las dos propiedades. La B pierde el acierto en la traza y lo reemplaza por un contador. La C pierde `execute_tool`. El doble conteo de tokens queda advertido en M8, que es lo que dice la opción. |
| C1-37-clave | **A** | Es una condición de aislamiento (CTX-SENS), y vale en cualquier orden porque la caché queda fuera de `UseFunctionInvocation`. La caché por scope es coherente con P-12. PC-02 dio la prueba de dos sesiones. La B deja una clave que PC-02 mostró que filtra la respuesta de A a B. |
| C1-41 | **A** | En la ronda 1 la di por obligatoria: era la comparación D1–D6 con criterio escrito antes de correr, y se corrió con salida cruda y hash. Lo pendiente se cumplió. Exigir ahora una comparación de tarea (B) es un requisito nuevo, que no estaba en la tensión 4 ni en P-24. Va bien para CTX-PROD, pero no es la condición que se votó. La C repite la medición sin agregar alcance. El 4b sigue provisional (P-24). |
| C1-49 | **A** | Es la tensión 1 (C sólo con agente MAF) tal como la aplicó P-24, y la consulta de definiciones fija «agente de MAF» en la sección de agentes. El rótulo «corrida sólo con un doble» es honesto (nadie corrió C con el modelo). La B mezcla en la sección de conocimiento una vía que depende del agente. La C no es incoherente, pero no es la resolución vigente. |
| C1-36 | **A** | Afina mi lectura de la ronda 1 sin contradecirla: no bloquea la redacción en general, pero un S1 abierto bloquea lo que deriva de él (N0b por P-02, N5 §4.2 por P-03), y eso es lo que significa S1 en M§. Bloquea «validado» y el cierre, como pide REED-16 §6.2. Con C1-37 decidido, la parte de P-03 que dependía del orden queda lista para verificarse. |
| C1-01 | **A** | El dictamen §1 deja firme la redacción in situ, y el §2 hace del barrido la condición del primer commit. Por lo tanto, la exclusión del commit no cierra la compuerta: la C contradice el dictamen. Sumar el patrón de `<clave-de-cabeceras>` (PC-03, OllamaSharp 5.5.0) amplía R-PRIV a una fuga de credenciales medida, y no cambia el cierre fijado por P-01 («el comando guardado da 0»). |

## Suspensos parciales

| Ítem | Clave | Fundamento |
|---|---|---|
| C1-14 | **C** | Sigue a C1-40, y en mi cadena eso da A: el contrato de P-13 rama A con A1–A5 de AH-01. El ADR D-11 es firme en las dos ramas. El 404 por sesión distinta no es control de acceso en ninguna (AH-01). Si C1-40 sale B, rige B, y el contrato va a `Examples/07`. |
| C1-28 | **A** | La forma completa es coherente con ESC-05 de BIT-16-03, cuyo riesgo dominante es «exposición sin control de acceso». También lo es con la especificación MCP 2025-06-18 (Origin es un MUST, PC-01) y con P-15 (MCP es un adaptador de entrada más, que no merece una segunda definición de las herramientas). Pasa el corte de la tensión 6: el daño se observó (el SDK 2.3.0 no valida Origin) y el middleware probado son pocas líneas. La B deja una brecha conocida contra un MUST, y la C duplica definiciones sin necesidad. Con C1-48 = C, M13 va en la demo; si gana A, va en `Examples/08`, con la misma forma. |

## Nota para la aplicación

- Si C1-48 sale C, la columna «En la demo» de P-05 se reemplaza con una nota fechada que lista las resoluciones que la sostienen (R-C02, R-C13, R-C16, §6.2) y el corte de P-27 para cada agregado. El mapeo D1–D7 → ESC → CTX no se toca (sólo agregado).
- Las dos reaperturas que esta ronda funda con evidencia, R-C07 (C1-37, PC-02) y R-C04 (C1-12, PC-11), tienen que quedar como notas fechadas en BIT-16-04 que digan qué cambia y con qué evidencia. Así lo pedí en la ronda 1, §2.
