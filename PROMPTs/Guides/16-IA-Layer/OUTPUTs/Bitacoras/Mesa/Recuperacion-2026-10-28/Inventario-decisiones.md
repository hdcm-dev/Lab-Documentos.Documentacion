---
doc_id: BIT-16-REC2-INV-decisiones
doc_type: inventario-de-reconciliacion
title: Inventario de decisiones — base (línea <equipo-principal>) frente a la línea <equipo-de-contingencia>
status: borrador para la matriz de unidades
origin: agent (inventariador «decisiones», mesa de recuperación)
last_review: 2026-10-28
audience: [presidencia de la recuperación, matriz de unidades, panel, jurado]
traces:
  - "BASE: Bitacoras/04-Plan-De-Integracion.md (v3 FINAL), Mesa/Ciclo-1..3/08-Cierre.md, Mesa/Ciclo-2/09-Respuestas-De-La-Presidencia.md, 05-Cierre-Mesa-De-Estructuracion.md, 06-Construccion.md §7–§8, 07-Redaccion.md §8–§9, guía 0.10.1 §10.6, §13, Anexo C"
  - "INSUMO: Linea-*-2026-10-28/Bitacoras/04-Integracion.md, Mesa/Ciclo-1/06-Plan-De-Redaccion.md §10, Mesa/Ciclo-1/07-Dictamen-Presidencia.md, Mesa/Ciclo-1/Ronda-2/05-Aplicacion.md, guía de 4107 líneas"
---

# Inventario de decisiones: base frente a <equipo-de-contingencia>

Este inventario compara lo que decidió la **base** (la línea de <equipo-principal>, que el PO fijó como base) con lo que decidió la **línea de <equipo-de-contingencia>** (insumo, sólo lectura). Cada unidad lleva su id `DECI-NN`, dónde está la decisión de cada lado, un juicio con evidencia, una acción propuesta y una severidad. La matriz de unidades toma estas filas y las vuelve opciones: mantener la base, tomar <equipo-de-contingencia>, fusionar o descartar.

Rutas: «base» es relativa a `OUTPUTs/Bitacoras/` o a la carpeta de la guía; «<equipo-de-contingencia>» es relativa a `OUTPUTs/Linea-*-2026-10-28/`. No se corrió nada contra un modelo. No se escribió ningún endpoint.

**Severidad.** S1: la guía afirmaría algo falso o inseguro si no se resuelve. S2: hay una decisión de fondo en conflicto, o una cifra citada que el entorno vigente ya no sostiene. S3: hay que ajustar el contenido o la regla. S4: coincidencia o detalle de forma.

## 0. Hallazgo transversal: las cifras de <equipo-de-contingencia> se midieron en el entorno vigente

La base midió contra el «servidor Ollama de la LAN», que ya no existe. Ese servidor era compartido, corría Ollama 0.32.0-rc0 y tenía `qwen3.5:4b` con el digest `2a654d98e6fb`. <equipo-de-contingencia>, en cambio, midió contra un Ollama 0.40.11 en contenedor, sobre un anfitrión de 4 núcleos sin GPU, con `qwen3.5:4b@d8b0f5e9760c`, `qwen3.5:2b@0689d44085e0`, `qwen2.5:0.5b@a8b0c5157701` y `qwen3-embedding:0.6b@ac6da0dfba84` (<equipo-de-contingencia> `Bitacoras/Sondeo-Entorno.md` §R.0–§R.1). Esa descripción coincide con la «estación de laboratorio de 4 núcleos» vigente, que tiene los mismos cuatro modelos. El segundo servidor de <equipo-de-contingencia> (14 CPU / 34 GiB, `qwen3.5:35b-a3b`) coincide con la «estación de laboratorio con más núcleos».

**Consecuencia.** En las decisiones que dependen de una medición, la evidencia de <equipo-de-contingencia> es probablemente **vigente** y la de la base es **historia**. Hay que confirmarlo por digest con `GET /api/tags` en un turno del recurso, sin escribir la dirección. Si los digests coinciden, las cifras de <equipo-de-contingencia> pueden reemplazar a las de la base en la guía cuando sostienen la misma afirmación, con el rótulo de RV-01 ampliada de <equipo-de-contingencia>. Esto atraviesa DECI-13, DECI-14, DECI-20, DECI-21, DECI-22 y DECI-23.

## 1. Coincidencias (sin acción de fondo)

| Id | Tema | Base | <equipo-de-contingencia> |
|---|---|---|---|
| DECI-01 | Principio rector | «El modelo propone; la aplicación ejecuta, autoriza y valida» (plan §A.4) | El mismo principio. La garantía es un invariante de código, no una tasa (P-24, R-LLM-3b) |
| DECI-02 | MCP fuera de la demo | PD-7 sale (P3-09, RC-1). Lo enseña 13: loopback, sólo lecturas, Host y `Origin` (§F.1, §F.5, ADR-06) | D7 fuera, en `Examples/08`: loopback, catálogo filtrado a lectura, middleware de `Origin` (403) (06-Plan §10.1, P2-07) |
| DECI-03 | Juez como tendencia, nunca como compuerta | ADR-10 (c); §10.6: los deterministas van antes | §10.2 (c): «nunca compuerta»; sin juez en la demo |
| DECI-04 | Herramientas sobre casos de uso; la sesión la pone el código; `X-Sesion-Id` no autentica | §A.4 2–3, §F.4, §F.5, ADR-06 | P-13/P2-03, RV-20 («el 404 por un id de otra sesión no es control de acceso») |
| DECI-05 | Inyección indirecta por `Localidad.Nombre` | P-12 del ciclo 3 (P3-08): 16 con la instrucción en `Nombre` | P2-12 (C1-67): entra `Localidad.Nombre` |
| DECI-06 | Estímulos sólo de Movilidad Urbana | §E.1 «Estímulo de prueba»: rótulo, SHA-256, «Persona 01…20» | I-06, regla 10, P-44 |
| DECI-07 | Comparación pareada con al menos 6 discordantes en el mismo sentido | §10.4 (2): binomial exacta sobre b + c, p = 0,031 | R-LLM-3e: signo o McNemar exacto, p = 0,031 |
| DECI-08 | Cobertura de ESC-01…05 sobre guía + ejemplos + demo, no sobre la demo sola | Ciclo-2/09 §1 (respuesta de la presidencia) | Fila N6 de `03-Marco` §4.1 (P2-02): la demo cubre ESC-01, 03 y 04 |
| DECI-09 | La boleta vota la opción, no «PROCEDE» | Ciclo 2: jurado endurecido, papeletas por opción, 14 re-votos | Dictamen §3.4 |

Dos casos que coinciden en el fondo y difieren en la forma:

- **«workflow».** Las dos líneas usan «workflow» a secas y «workflow de MAF». <equipo-de-contingencia> excluye explícitamente «flujo de trabajo» (ELV-01). El Anexo C de la base trae «flujo de trabajo» como equivalente del término (l. 4566). Se trata en DECI-16.
- **Capas como carpetas, con la prueba de arquitectura.** Base: ADR-11, con reflexión de cuatro reglas. <equipo-de-contingencia>: EA-3, con `grep`, más la regla de P-30. No hace falta acción.

## 2. Divergencias

### DECI-10 · Escrituras en la demo: herramienta con aprobación o `AccionPropuesta` (S2)

- **Base.** `agregar_localidad` y `eliminar_localidad(nombre, provincia)` son herramientas sobre casos de uso con `ApprovalRequiredAIFunction` (§F.4, H-012). El pedido de aprobación lo arma el código desde la `ToolCall` y el pedido pendiente vive en el circuito (ADR-12). Hay política de origen: después de leer texto no confiable, toda escritura pasa por aprobación. Evidencia: 70/70 pruebas de la demo; `Aprobacion_ArgumentosAlterados_SeRechaza`; `TodaEscritura_EsAprobable`; la sonda DEP-09 (dos peticiones, el pedido se conserva y se rechaza la aprobación alterada); PD-6 tiene humo con modelo. Las sondas y el humo se observaron en el servidor que ya no existe.
- **<equipo-de-contingencia>.** En la demo, **ninguna herramienta escribe** (C1-40 B 4-1, C1-62 B 3-2, C1-14 B 3-2; P2-03; RV-21). El modelo devuelve una `AccionPropuesta` tipada y validada (B1–B4), y la persona ejecuta la operación normal de la API. `ApprovalRequiredAIFunction` se enseña sólo en `Examples/07`, con el contrato A1–A5. La evidencia que lo motiva es X2: con N = 10, `qwen3.5:4b` «borra sin confirmar 10/10» y altera un CP inválido 10/10. D6 dio «ninguno confirma antes de borrar», 10/10 en el 4b y en el 2b.
- **Juicio.** X2 no contradice la base: muestra que el modelo pide borrar sin confirmar, y eso es justamente lo que `ApprovalRequiredAIFunction` resuelve en el código, porque la garantía no depende de que el modelo confirme. La opción de <equipo-de-contingencia> reduce superficie (una escritura menos dentro del bucle). La de la base enseña el patrón completo en el caso integrado, y lo pide la escalera de agencia (PD-5, PD-6, OA-D5, OA-S4). La base está construida y probada; <equipo-de-contingencia> no tiene la demo de escritura con aprobación. Además, X2 y D6 se midieron en la estación vigente, mientras que la sonda DEP-09 de la base se corrió en el servidor que ya no está.
- **Acción.** Mantener la base. En ADR-06 (§13.7), sumar la opción de <equipo-de-contingencia> («`AccionPropuesta` + operación normal, sin herramienta de escritura») como alternativa descartada, con su motivo. En §8.5 u §11.3, citar X2/D6 como evidencia de por qué la aprobación la impone el código, con rótulo de estación y estimando «este pedido». Volver a correr DEP-09 y el humo de PD-6 en la estación 1.

### DECI-11 · Perímetro de la demo: RAG en la demo o contexto fijo (S3)

- **Base.** Hay seis pasos, PD-1…PD-6. PD-2 es ayuda con RAG (`AyudaConRecuperacion`, almacén `InMemory`) y está declarado «sube más de lo necesario» (§A.1, §F.1, ADR-04, ADR-05). Hay humo con modelo en PD-2, PD-3 y PD-6.
- **<equipo-de-contingencia>.** Seis pasos, D1–D6, firmes (C1-48 A 3-1-1). D5 usa el escalón 0, `AyudaContextoFijo` (C1-55 B 3-2, C1-56 B 3-2). `AyudaRag` y la comparación pareada van a `Examples/05`, y ESC-02 queda sólo en `Examples/04`. La página de streaming va a `Examples/02`, aunque la demo conserva `EventoDelAsistente` con `TextoParcial`.
- **Juicio.** Las dos posiciones tienen fundamento. La base ya declara la subida y la cubre ADR-04: el contexto fijo es la opción (b) para los requisitos, y el RAG se enseña en PD-2 sobre un corpus que no lo necesita. Las votaciones de <equipo-de-contingencia> fueron ajustadas (3-2). Cambiar el perímetro reabre la demo construida y el ADR sin evidencia nueva.
- **Acción.** Mantener la base. Tomar de <equipo-de-contingencia> la condición «ninguna frase comparativa contexto fijo / RAG sin corrida», que ya está en el §14.6 de la base. Comprobarlo con un barrido.

### DECI-12 · Normalizador y endurecimiento del dominio (S3)

- **Base.** `Infrastructure/AI/NormalizadorDeCatalogo.cs` va en el adaptador (ADR-08: «normalizar traduce la salida del modelo y va en el adaptador»). Las reglas del dominio se **endurecen** (H1–H5, columna «Modificado a causa de la IA» de §F.2).
- **<equipo-de-contingencia>.** `Agregado/Application/Normalizacion/NormalizadorDeCatalogos.cs` va en el núcleo y lo invoca el adaptador (C1-38 A 5-0, C1-53 A 5-0, P2-04). La copia es literal (`diff -r = 0`) y H1–H5 **no** se endurecen. La divergencia «piedra» se muestra sin decir que los dos caminos coinciden. El normalizador rechaza `Enum.IsDefined` falso y nombres de más de 60 caracteres en el camino de IA.
- **Juicio.** Las dos decisiones son coherentes con su delta: la base tiene una tabla de tres columnas con endurecimiento declarado, y <equipo-de-contingencia> una copia literal con una carpeta `Agregado/`. [host-dev], además, encontró una deuda real que **la base también tiene**: `LocalidadPolicy` anuncia «entre 3 y 60 caracteres», pero `LocalidadRules` sólo define `LargoMaximoDelNombre = 60` y no lo aplica. Lo comprobó este inventario con `grep`: la constante sólo aparece en `LocalidadRules.cs` l. 16 y en el texto de `LocalidadPolicy.cs` l. 18. Un nombre de 61 caracteres propuesto por el modelo pasa las reglas.
- **Acción.** Mantener la ubicación de la base. Sumar el largo máximo al endurecimiento de `LocalidadRules`, como fila «Modificado a causa de la IA», con una prueba de cableado: 61 caracteres se rechazan y no hay `SaveAsync`. Si no se endurece, declararlo en §14.1 y en la procedencia como «declarado, no aplicado» (RV-14 de <equipo-de-contingencia>).

### DECI-13 · Modelo de chat: `qwen3.5:4b` con un digest que ya no existe (S2)

- **Base.** `qwen3.5:4b` digest `2a654d98e6fb`, «el residente del servidor compartido», con `qwen2.5:7b-instruct` como alternativa declarada (§E.1). La guía rotula 37 veces con «Ollama 0.32.0-rc0, sólo CPU, servidor compartido».
- **<equipo-de-contingencia>.** `qwen3.5:4b@d8b0f5e9760c` frente a `qwen3.5:2b@0689d44085e0` (Q8_0, 2,68 GB). Se eligió el 4b porque normaliza al catálogo (D3: el 4b falló 0/10 y el 2b 10/10). El 2b respeta mejor el dato inválido (D1: el 4b inventa el CP 10/10 y el 2b 1/10). Ninguno confirma antes de borrar (D6). Con N = 10 semillas por pedido. El 4b queda «provisional» (C1-41 A 4-1, C1-50 A 5-0, P2-10, RV-24). El 35b-a3b no es candidato por defecto: unas 4,2 veces más lento y no se separa en herramientas.
- **Juicio.** La elección del modelo coincide (4b) y la de <equipo-de-contingencia> tiene una comparación medida que la base no tiene. El digest de la base no corresponde a ningún servidor vigente: toda cifra de la guía con `2a654d98e6fb` es historia.
- **Acción.** Mantener el 4b. Fijar el digest vigente de la estación 1 (verificarlo por `/api/tags` en un turno). Llevar a §5 o al Anexo F la justificación medida de <equipo-de-contingencia> (D1, D3, D6) con su rótulo y estimando. Quitar o rotular la alternativa 7b, que no está en ningún servidor vigente. Volver a correr lo que la guía afirma como medido, o rotularlo como «historia: servidor dado de baja».

### DECI-14 · Juez de 15: `qwen2.5:0.5b` no calibrado frente a un juez en la estación 2 (S3)

- **Base.** RV-11 = B′: el juez es `qwen2.5:0.5b` en el Ollama propio. Resultado (§10.6): «no calibrado», 0/52 salidas interpretables, acuerdo no medido. La base declara que falta un juez de otra familia (§14.6).
- **<equipo-de-contingencia>.** Sin juez en la demo. En el segundo servidor, a demanda: 10 × 2 × 3, k/n con Wilson, nunca compuerta. Costo medido: unos 34 s por evaluación en la estación 2, y 1285 s por caso con 7 evaluadores en la estación 1 (N = 1). La estación 1 queda «no medido» (P2-11). E-B1: el 0.5b da 0/5 en tool calling, señal de que es un modelo débil.
- **Juicio.** El marco coincide (DECI-03). El resultado de la base es honesto, pero no informa nada sobre un juez utilizable. La estación 2 vigente tiene modelos mayores. Hay una incoherencia **interna** de la base para revisar: §10.6 dice 0/52 interpretables, y la salida `--fake` de l. 2992 dice 51/52. Es el guion, no el modelo, y está rotulada «prueban el cableado», pero un lector puede confundirlas.
- **Acción.** Mantener el protocolo de la base. Agendar una corrida del juez en la estación 2 con un modelo mayor (por ejemplo `qwen3.5:35b-a3b`), con el rótulo de esa estación y la advertencia de familia. Hasta entonces, el 0/52 queda como historia rotulada. Revisar que la salida `--fake` de §10.6 no se lea como medición.

### DECI-15 · Regla estadística: entrada distinta y Clopper-Pearson, o estimando y Wilson (S3)

- **Base.** La unidad de muestra es la **entrada distinta** (M entradas congeladas, `temperature` 0, varía sólo la entrada). El intervalo es Clopper-Pearson al 95 %. Con M ≤ 12 la tasa es descriptiva (§E.1, §10.4; regla AC-9: 365/365 registros recalculados).
- **<equipo-de-contingencia>.** R-LLM-1…5 (P2-13, C1-72): estimando «este pedido» (semillas, T 0,7) o «la tarea» (K ≥ 10 pedidos, m ≥ 3), Wilson al 95 %, cabecera R-LLM-4 y presupuesto R-LLM-5. «Nunca intervalo normal.»
- **Juicio.** La evidencia de <equipo-de-contingencia> **respalda la unidad de la base**: en el experimento de AH-02, la heterogeneidad entre pedidos dio p = 0,018, ICC 0,29 y efecto de diseño 3,0, con Cochran Q de la semilla p = 1,00. Las semillas de un mismo pedido no son ensayos independientes de la tarea, y la base nunca las usó como tales. Las dos reglas no pueden convivir en la guía: mezclar Clopper-Pearson y Wilson violaría la compuerta C5 y la homogeneidad de las cifras. Las cifras de <equipo-de-contingencia> (D1, D3, D6, tensión 1) son «este pedido» con semillas.
- **Acción.** Mantener la regla de la base. Una cifra de <equipo-de-contingencia> que entre a la guía se recalcula con Clopper-Pearson y se rotula «una entrada, N semillas: describe este pedido, no la tarea». Tomar de <equipo-de-contingencia> sólo la etiqueta del estimando y la advertencia sobre las semillas, como precisión de §10.4.

### DECI-16 · «workflow» y el equivalente «flujo de trabajo» en el glosario (S4)

- **Base.** «workflow» a secas (42 apariciones) y «workflow de MAF». El Anexo C, l. 4566, da «flujo de trabajo» como equivalente.
- **<equipo-de-contingencia>.** ELV-01, opción A: «workflow» a secas. Se excluyen «agentic workflow», «flujo agéntico» y «flujo de trabajo» (RV-23, barrido de §10.4).
- **Juicio.** El término coincide. El equivalente del glosario es inocuo si se rotula «no se usa en la guía», pero contradice la exclusión que decidió <equipo-de-contingencia>.
- **Acción.** En el Anexo C, cambiar la celda «flujo de trabajo» por «— (no se traduce: es el término de MAF y de la literatura citada)», o rotularla como forma excluida. Correr el barrido de las tres formas.

### DECI-17 · Definición de agente: escalón 3 o «agente mínimo» (S3)

- **Base.** Agente: el modelo dirige su propio proceso (Anexo C). Un `AIAgent` puede estar en el escalón 1. Escalera: −1 función, 0 llamada única, 1 llamada con herramientas, 2 workflow, 3 agente (ADR-07). El escalón 3 queda conceptual.
- **<equipo-de-contingencia>.** P2-14: agente es «el modelo decide, en un bucle, qué herramienta pedir a continuación y cuándo terminar». El **agente mínimo** es un `IChatClient` con `UseFunctionInvocation` (16 apariciones en la guía de <equipo-de-contingencia>). La organización va por mecanismo: herramienta → agente mínimo → agente de MAF → workflow de MAF → multiagente. MCP es transporte.
- **Juicio.** Las definiciones son incompatibles: con la de <equipo-de-contingencia>, el escalón 1 de la base (PD-1, PD-5, PD-6) es un «agente». La compuerta C5 exige un solo sentido, y la base es coherente de punta a punta con su escalera (OA-D6, ADR-07, §8). Tomar la de <equipo-de-contingencia> reescribe §3, §8 y ADR-07.
- **Acción.** Mantener la definición de la base. Sumar en §8.1 o en el Anexo C una nota de una línea: «hay fuentes que llaman agente a todo bucle de herramientas; en esta guía ese bucle es el escalón 1». Tomar de <equipo-de-contingencia> «MCP es transporte, no un nivel de orquestación» si la base no lo dice.

### DECI-18 · Pipeline y caché (S4)

- **Base.** ADR-09: una capa `ConfigureOptions` pegada al adaptador. La caché se usa sólo para pedidos idénticos y **no** en la demo. Hay telemetría en el chat y 17 comprueba el orden.
- **<equipo-de-contingencia>.** P2-06, vuelta 2. El orden es caché → `UseFunctionInvocation` → `UseOpenTelemetry` → cliente, con contador `movilidadurbana.ai.cache.aciertos`, clave con `SessionId` y `VersionDeDatos`. La doble capa queda descartada (doble conteo de tokens, 48 frente a 24). El limitador va en la entrada HTTP. En la demo no hay caché para pedidos con herramientas. Un acierto no vuelve a ejecutar las herramientas.
- **Juicio.** Las dos coinciden en que la demo no usa caché. <equipo-de-contingencia> agrega hechos medidos que sirven para §12, pero las cinco pruebas de <equipo-de-contingencia> viven en otro ejemplo (09) y se corrieron sin modelo.
- **Acción.** Mantener la base. Evaluar si se suman a §12, como texto, «un acierto no vuelve a ejecutar las herramientas» y la clave con versión de datos, sólo con una prueba de cableado en 17 que lo sostenga.

### DECI-19 · Forma de la copia del caso base (S4)

- **Base.** Una copia con el namespace renombrado (`MovilidadUrbana.Asistente`, H2-008) y una tabla de delta de tres columnas, con procedencia por archivo (§F.2). Un solo host para API y Blazor (ADR-13).
- **<equipo-de-contingencia>.** Una copia literal más la carpeta `Agregado/` (Domain, Application, Infrastructure y Presentation agregados), `diff -r = 0` sobre lo copiado y `PROCEDENCIA.md`.
- **Juicio.** Las dos documentan el delta. La de la base está construida y la mide AC-10.
- **Acción.** Mantener la base, sin cambios.

### DECI-20 · Servidores, ESC-001 y variables de entorno (S2)

- **Base.** Hay tres planes de embeddings (EMB-A, B y C), con EMB-B vigente: Ollama propio con el 0.5b y los embeddings. La escalada ESC-001 sigue abierta: «¿instalás embeddings en el servidor de la LAN?». `OLLAMA_SERVIDOR` vale `compartido`, `propio` o `nube`; en modo `compartido`, el arnés lee `/api/ps` y la configuración se rechaza sin `OLLAMA_NUM_CTX` (ADR-03). La guía usa «servidor compartido» 53 veces.
- **<equipo-de-contingencia>.** El servidor de la LAN quedó dado de baja y es historia. Hay dos servidores de prueba: la «estación de laboratorio» y la «estación de laboratorio con más núcleos» (dictamen §4, ELV-02, RV-01 ampliada). Las cifras de las dos nunca se mezclan sin decir de cuál es cada una. El segundo servidor se apaga al cierre.
- **Juicio.** El entorno vigente le da la razón a <equipo-de-contingencia>. ESC-001 perdió su objeto, porque el servidor por el que pregunta no existe. La estación 1 tiene chat, embeddings y el 0.5b, así que la separación chat/propio de la base deja de ser necesaria, aunque sigue siendo válida como diseño para el lector. Lo que la guía describe como «servidor compartido» (`/api/ps`, recargas de modelos ajenos) ya no lo puede observar ningún laboratorio vigente.
- **Acción.** Cerrar ESC-001 como obsoleta, con una nota fechada en la bitácora. Asignar el recurso `<recurso-compartido>` (estación 1) a `OLLAMA_ENDPOINT` y `OLLAMA_EMBED_ENDPOINT`/`OLLAMA_PROPIO_ENDPOINT`, y el recurso `<recurso-estación-2>` (estación 2) a lo que la estación 1 no cubre, siempre por variable. Conservar en la guía el concepto de servidor compartido (ADR-03 b) como alternativa explicada, sin presentarlo como el laboratorio actual. Reemplazar los rótulos «servidor compartido» de las cifras por el de la estación donde se vuelva a medir, o por «historia».

### DECI-21 · Presupuesto de turnos (S3)

- **Base.** RV-03: tope de 4 h, con TURNO-1 (≈ 2,1 h del servidor de la LAN) y TURNO-3 (≈ 1,5 h del propio), y clases de tiempo K/H/L/M calibradas en el servidor compartido (§E.5).
- **<equipo-de-contingencia>.** R-LLM-5: una mediana de 27 s por llamada del 4b en la estación, y un turno de 45 min para unas 90 llamadas. Las corridas del segundo servidor llevan su rótulo.
- **Juicio.** Las clases de tiempo de la base se calibraron en un servidor con dispersión de 68,8 s a más de 600 s, bajo carga ajena. En una estación dedicada no aplican. La medición de <equipo-de-contingencia> es vigente.
- **Acción.** Antes de volver a correr, recalcular §E.5 con las mediciones de <equipo-de-contingencia> como punto de partida y declarar el tope nuevo. La decisión del tope es de la presidencia.

### DECI-22 · Ventana de contexto y `num_ctx` (S4)

- **Base.** DEP-03: con la capa, el servidor procesa 5.714 tokens; sin ella, 2.050 (recorte silencioso). Hay una capa única de opciones y `num_ctx` sólo por la vía nativa. Pregunta abierta: «¿`/v1` sin `num_ctx` recarga el compartido?».
- **<equipo-de-contingencia>.** X3/PC-06 en 0.40.11: sin `num_ctx`, recarga a 4096 y trunca a 2050 (5/5 con el 0.5b). La regla es usar el mismo `num_ctx` en todos los clientes del mismo modelo, porque alternar recarga en 10 a 16 s con el 4b. Lo automático depende de la configuración del servidor, no de su estado (P2-09).
- **Juicio.** El hecho (2050) coincide. <equipo-de-contingencia> **cierra** en buena parte la pregunta abierta de la base: por `/v1` el `num_ctx` no llega, y lo que hace el servidor depende de su configuración. <equipo-de-contingencia> también suma la regla de las recargas.
- **Acción.** Sumar a §5.5/§5.7 de la base la regla «mismo `num_ctx` en todos los clientes», con el rótulo de la estación. Cerrar la pregunta abierta con la evidencia de PC-06.

### DECI-23 · Vía nativa frente a `/v1`: `tool_choice`, `TopK`, `MaxOutputTokens` y «clave de cabeceras por pedido» (S3)

- **Base.** «`/v1` no admite `tool_choice`» y «no hay `tool_choice`» ([REF-51]; guía l. 1000, 1027, 1300, 2107). No hay una tabla medida de diferencias y «clave de cabeceras por pedido» no aparece.
- **<equipo-de-contingencia>.** E-B2b: por `/v1`, el cliente **envía** `tool_choice`, `reasoning_effort:none` y `response_format: json_schema`. La tabla medida (P2-08, RV-22) dice: `TopK` sólo por la vía nativa; `MaxOutputTokens` no acota la salida por `/v1` (pedidos 3, salieron 57); `ChatRequest.clave de cabeceras por pedido` se serializa en el cuerpo, así que las credenciales van en un `DelegatingHandler` (RV-01 ampliada).
- **Juicio.** No es necesariamente una contradicción: la base habla de lo que el servidor admite según la documentación, y <equipo-de-contingencia> de lo que el cliente manda. Pero la frase «no hay `tool_choice`» puede leerse como falsa en el lado del cliente. La tabla de <equipo-de-contingencia> se midió en la estación vigente y le agrega a la base un antipatrón de seguridad (credenciales en el cuerpo).
- **Acción.** Precisar en la base «el cliente lo envía; el servidor no lo honra según [REF-51]», y no afirmar que lo honra sin una prueba. Llevar la tabla de <equipo-de-contingencia> a §5, una sola vez, con su rótulo. Sumar el antipatrón de «clave de cabeceras por pedido» a §11 y a la compuerta R-PRIV (patrón `cabeceras`).

### DECI-24 · Ciclo de vida y cruce de sesiones (S4)

- **Base.** ADR-12: el `IChatClient` base es singleton y las herramientas se arman por circuito. Prueba `Composicion_ValidateScopes`.
- **<equipo-de-contingencia>.** P2-05 (D-06): con `ValidateScopes = false`, la sesión B ve y borra lo de A sin error. Con `true` y sin `ValidateOnBuild`, falla en cada llamada a la herramienta, no al construir el contenedor. Cita de .NET DI overview §«Scope validation».
- **Juicio.** La regla coincide. <equipo-de-contingencia> precisa la consecuencia con un experimento.
- **Acción.** Sumar en §12 o §11 la frase medida de <equipo-de-contingencia>, con su cita, si la base dice algo menos preciso. Sin cambio de diseño.

## 3. Lo que la base dejó abierto y <equipo-de-contingencia> cerró

| Id | Abierto en la base | Dónde | Cómo lo cerró <equipo-de-contingencia> | Acción |
|---|---|---|---|---|
| DECI-25 | «¿`/v1` sin `num_ctx` recarga el modelo del servidor compartido?» | plan §E.1; Ciclo-2/08 deuda | PC-06: `num_ctx` no llega por `/v1`; el servidor recarga a 4096 según su configuración | Ver DECI-22: cerrar la pregunta, con el rótulo de la estación |
| DECI-26 | Datos privados en la bitácora: «rutas absolutas con el usuario del sistema en `OUTPUTs/`» (DEP-16, pregunta abierta); las redacciones R-PRIV in situ chocan con la regla de sólo agregado | Ciclo-3/08 deuda | Dictamen §1: R-PRIV le gana a «sólo agregado», sólo para borrar lo prohibido. Dictamen §2: identificadores permitidos en la bitácora mientras no se commitee; antes del primer commit, barrido con `identificadores=0`. Compuerta `rpriv.sh` v2 con `cabeceras` | Adoptar el dictamen §1–§2 como regla de la base recuperada y correr la compuerta v2 (o una equivalente) antes de cualquier commit |
| DECI-27 | Gestión del segundo servidor (no existía en la base) | — | ELV-02: sigue arriba durante la redacción y las pruebas, con el recurso `<recurso-estación-2>` de cupo 1; se apaga al cierre, con inventario; toda cifra lleva su rótulo | Tomarlo tal cual para la recuperación |
| DECI-28 | Elección del modelo sin comparación medida (sólo «el residente») | plan §E.1 | P2-10: comparación 2b/4b (D1, D3, D6) | Ver DECI-13 |
| DECI-29 | Cuánto cuesta el juez (no medido en un servidor utilizable) | §10.6; deuda del ciclo 3 | P2-11: unos 34 s por evaluación (estación 2); 1285 s por caso (estación 1, N = 1) | Ver DECI-14: usar el costo para presupuestar la corrida |

Lo que **siguió abierto en las dos** líneas, sin cierre de ningún lado: la comparación de calidad entre contexto completo y RAG (base §14.6, <equipo-de-contingencia> §10.8); un juez de otra familia; la autorización real; las tareas de varios pasos (base sin DEP-10; <equipo-de-contingencia> D6 sólo mide la confirmación). Quedan como deuda declarada en §14.6 de la base.

## 4. Correspondencia de ejemplos para trasladar contenido de <equipo-de-contingencia>

Toda remisión de <equipo-de-contingencia> que se lleve a la base se renumera. Las carpetas de <equipo-de-contingencia> no siguen el orden de la base:

| <equipo-de-contingencia> | Base |
|---|---|
| 01-Chat-Basico, 02-Streaming | 01-Chat-Y-Streaming (selector de proveedor: 02-Cambio-De-Adaptador) |
| 03-Salida-Estructurada | 03 (y 04, normalización) |
| 04-Embeddings-Y-Busqueda | 06-Embeddings-Y-Busqueda-Semantica |
| 05-RAG-En-Memoria | 07-RAG-Con-Citas |
| 06-Tool-Calling | 08 y 09 |
| 07-Agente-Con-Aprobacion | 11-Agente-Con-Aprobacion |
| 08-Servidor-Y-Cliente-MCP | 13-Servidor-Y-Cliente-MCP |
| 09-Pruebas-Con-Cliente-Falso | 15-Pruebas-Y-Evaluacion (caché y pipeline: 17) |
| 10-Workflow | 10-Workflow-Y-Contraejemplo |
| 12-Anotaciones-Pareadas | 14-Anotaciones-SK-vs-MEAI |
| 13-Prueba-De-Arquitectura | `Cableado/ArquitecturaTests.cs` de la demo (ADR-11) |

(DECI-30, S4: sin decisión de fondo. Hace falta para aplicar DECI-10, DECI-18, DECI-22 y DECI-23 sin remisiones rotas.)

## 5. Resumen para la matriz

- **Decisiones de fondo en conflicto:** DECI-10 (escrituras en la demo), DECI-11 (perímetro), DECI-12 (normalizador y dominio), DECI-15 (regla estadística) y DECI-17 (definición de agente). En las cinco, el juicio es **mantener la base**, que está construida, probada y es coherente consigo misma. De <equipo-de-contingencia> se toma la evidencia que la respalda o la precisa: X2/D6, el largo de 60, el ICC de AH-02 y «MCP es transporte».
- **Decisiones que cambia el entorno:** DECI-13, DECI-14, DECI-20, DECI-21, DECI-22 y DECI-23. Acá **<equipo-de-contingencia> le gana a la base en vigencia**: probablemente midió en la estación 1 vigente (§0, a confirmar por digest). Las cifras de la base pasan a ser historia o se vuelven a correr.
- **Deuda real de la base que encontró <equipo-de-contingencia>:** el largo máximo del nombre no se aplica (DECI-12), y la frase sobre `tool_choice` es ambigua (DECI-23).
- **Incoherencia interna de la base, para la relectura:** el 0/52 de §10.6 frente al 51/52 de la salida `--fake` (DECI-14). La salida está rotulada como cableado, pero conviene que no se lea como medición.
