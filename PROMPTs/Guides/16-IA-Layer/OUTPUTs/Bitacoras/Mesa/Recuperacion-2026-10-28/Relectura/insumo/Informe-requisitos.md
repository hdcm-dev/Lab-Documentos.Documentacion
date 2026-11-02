---
doc_id: BIT-16-C1-INF-requisitos
doc_type: informe-de-especialista
title: Informe del especialista Requisitos — ciclo 1
status: entregado
origin: agent
owner: especialista Requisitos (núcleo permanente, M§4.1.1; comisión N0)
last_review: 2026-10-28
audience: [relatoría, jurado, presidencia]
traces: [REED-16 §2, §7, §8.1, §9.1 C2, §15; BIT-16-00 §3, §5; BIT-16-02 §6, §7, §9, §10; BIT-16-03 §4–§5; BIT-16-04 §5, §7, §8; Nucleos/N0b…N6; Mesa/I-02…I-06]
---

# Informe del especialista Requisitos — ciclo 1

Escrito a ciegas (no leí otros `Informe-*.md`). Mandato (REED-16 §8.1; convocatoria §9, asiento 1): ¿cada solicitud S-01…S-17 y cada pregunta de REED-16 §7 tiene una sección que la responde?, ¿cada sección declara escenario y contexto (ESC-/CTX-)?, ¿el plan de la guía y de `Examples/`/`Demos/` cubre todo? No juzgo corrección técnica.

Evidencia propia: [`evidencia-requisitos/sonda-cobertura.sh`](evidencia-requisitos/sonda-cobertura.sh) (sólo lectura, `grep`/`sed` sobre la bitácora) y su salida [`evidencia-requisitos/sonda-cobertura-salida.txt`](evidencia-requisitos/sonda-cobertura-salida.txt), corrida el 2026-10-28 en <equipo-de-contingencia>. Los conteos citados abajo salen de ahí (bloques [1]…[7]).

## Índice

- [1. Hallazgos](#1-hallazgos)
- [2. Lo que revisé y está bien](#2-lo-que-revisé-y-está-bien)
- [3. Posición sobre los MI de mi mandato](#3-posición-sobre-los-mi-de-mi-mandato)
- [4. Solicitudes de convocatoria](#4-solicitudes-de-convocatoria)

---

## 1. Hallazgos

Esquema M§8. Ordenados por severidad.

### REQUIS-01 — Los borradores de N1, N2, N3, N4 y N5 no declaran escenario ni contexto

- **Capa de origen:** núcleo.
- **Ubicación:** `Nucleos/N1-Capa-IA-En-El-Stack.md`, `N2-…`, `N3-RAG-En-NET.md`, `N4-…`, `N5-…`, todo el cuerpo (§1–§8 y las notas del 2026-10-28).
- **Afirmación:** cinco de los nueve registros de núcleo, justamente los que alimentan las secciones temáticas §3–§7 de la guía, no usan ni una vez el vocabulario ESC-/CTX- ni tienen la subsección «Aplicación por escenario» que exigen el Profile y el marco N0.
- **Evidencia (E1 + E2):** bloque [1] de la sonda: N1 `ESC=0 CTX=0 escenario=0`; N2 `0/0/0`; N3 `0/0/0`; N4 `ESC=0 CTX=0`; N5 `ESC=0 CTX=1` (un único CTX-PROD); ninguno tiene «Aplicación por escenario» (sólo N3b, con 2). La exigencia: BIT-16-02 §7, «Cada sección temática §3–§7 sigue el Profile: Definición → Aplicación por escenario (y qué cambia por contexto) → …»; BIT-16-03 §5, «Cada sección temática tiene una subsección "Aplicación por escenario" que recorre ESC-01…ESC-05». N4 §1 (línea 49) hasta declara que recibe de N0 el «Vocabulario ESC/CTX/ACT» y después no lo usa.
- **Severidad:** S2. El contrato (BIT-16-00 §3) tipifica como S2 la «recomendación sin escenario o contexto».
- **Confianza:** 0.9.
- **Impacto si no se corrige:** la guía se redacta desde estos borradores y sale con recomendaciones de abstracciones, RAG, agentes y operación que no le dicen al lector en qué ESC-xx × CTX-yy valen. Se pierde la pieza de R-PO-3 («identificar en qué caso se aplica cada concepto») y queda inutilizable el mapa «estoy en ESC-xx con CTX-yy → qué estrategia» de BIT-16-03 §5.
- **Propuesta de dirección:** antes de redactar, cada núcleo N1–N5 recibe (como nota fechada, sólo agregado) una tabla «Aplicación por escenario» con las filas ESC-01…ESC-05, tomando como esqueleto la matriz BIT-16-03 §4.1/§4.2. Cada recomendación de §6 (criterios y antipatrones) se ata al menos a un ESC y un CTX, o se declara «vale para todos». La plantilla ya existe: es la de N3b. En la relectura integral corre una compuerta mecánica: «Aplicación por escenario» al menos una vez en cada §3–§7 de la guía, y ninguna celda `●` de 03 §4.1 sin texto en la sección.

### REQUIS-02 — Ninguna decisión ni destino para diez propuestas del PO (PR-3…PR-7, PR-18…PR-22)

- **Capa de origen:** integración.
- **Ubicación:** `04-Integracion.md` §5 (MI-01…MI-24) y §8; `Mesa/Ciclo-1/00-Convocatoria.md`. Origen de las propuestas: `Mesa/I-02` (PR-1…PR-7), `I-03` (PR-8…PR-12), `I-04` (PR-13…PR-15), `I-05` (PR-16…PR-22).
- **Afirmación:** cada insumo del PO cierra preguntándole a la mesa «qué propuestas se aplican» (I-02 §«a la mesa» 1, I-03 2, I-04 1, I-05 1). BIT-16-04 da destino a doce (PR-1, 2, 8–17), pero diez no aparecen ni en el cuaderno de integración ni en la convocatoria: PR-3 (ejemplos y demo en tres niveles), PR-4 («¿un agente o varios?»), PR-5 (escalera de complejidad), PR-6 (autoevaluación por escenario), PR-7 (primer agente sobre un sistema familiar), PR-18 («¿framework o propio?»), PR-19 (cuadro M.E.AI/MAF/SK/OpenAI), PR-20 (primer ejercicio con pruebas negativas), PR-21 (anexo de seguridad de herramientas) y PR-22 (ejemplo pareado `[KernelFunction]`/`AIFunctionFactory`).
- **Evidencia (E1 + E2):** bloque [2] de la sonda: `PR-3…PR-7 | 04=0 | 00-Convocatoria=0` y `PR-18…PR-22 | 04=0 | 00-Convocatoria=0`. BIT-16-04 §5 afirma «Lo que no está acá ya no requiere voto: es unificación de nombres, consecuencia directa de E1 o asignación de trabajo», y estas diez no son ninguna de las tres cosas. R-C20 aclara además, sobre las de N0b, que «No se votan acá». Sólo PR-12, PR-13 y PR-14 quedan «a ratificar por la mesa» (§8).
- **Severidad:** S2. Son pedidos del PO, explícitos y dirigidos a la mesa, que hoy pueden quedar fuera sin decisión ni registro. Algunos (PR-6, PR-20, PR-22) cambian el índice o la lista de `Examples/`.
- **Confianza:** 0.85.
- **Impacto si no se corrige:** la guía se redacta sin autoevaluación (PR-6: `autoevaluaci` = 0 en todos los núcleos), sin el ejemplo pareado de migración SK → MEAI (PR-22) y sin las pruebas negativas del primer ejercicio (PR-20), y nadie puede decir si eso fue una decisión o un olvido.
- **Propuesta de dirección:** una tabla única PR-1…PR-22 → decisión (aplicar / aplicar con ajuste / descartar con motivo / postergar) → sección de la guía o carpeta de `Examples/`, votada en este ciclo como bloque y agregada a BIT-16-04 como nota fechada. Donde ya hay aplicación de hecho (PR-5 coincide con el «por mecanismo: herramienta → agente → workflow → MCP» de MI-10; PR-21 con el Anexo B), se registra así y no se vota de nuevo.

### REQUIS-03 — El recorrido de la demo (D1–D7) no está mapeado a ESC/CTX y la fila N6 del marco quedó en «candidato»

- **Capa de origen:** integración.
- **Ubicación:** `03-Marco-De-Referencia.md` §4.1 (fila N6); `Nucleos/N6-Caso-Movilidad-Urbana.md` Anexo A (tabla D1–D7) y nota de reanudación (fila §8.8); `02-Cohesion-Global.md` §9 (fila «§8 → §2») y §10 (primer pendiente); `04-Integracion.md` (sin el mapeo).
- **Afirmación:** el plan exige que cada parte de la demo nombre su escenario y su contexto. N6 delegó ese mapeo a la integración y BIT-16-04 no lo hizo, así que la demo no tiene declaración ESC/CTX trazable.
- **Evidencia (E1 + E2):** bloque [6] de la sonda: la fila N6 de 03 §4.1 sigue `candidato | candidato | candidato | candidato | candidato` (03 §4.1: «La fila N6 se completa en la fase de plan»); el Anexo A de N6 tiene 0 apariciones de `ESC-0` (su columna «Escenario» trae la frase del usuario, no el ID); N6 L573: «El mapeo de §1.5 a esos IDs queda para la integración». En BIT-16-04, ESC aparece sólo en tensiones puntuales (ESC-01 en T3, ESC-02 en MI-08, ESC-03/04 en MI-14), y ningún CTX-LOCAL/PROTO/SENS se asigna a D1–D7. BIT-16-02 §9: «§8 → §2: cada parte de la demo nombra su escenario y contexto»; §10: «Elegir los escenarios que cubre la demo (fila N6…)».
- **Severidad:** S3. Hay escenarios implícitos y el riesgo es de trazabilidad; no hay una recomendación falsa.
- **Confianza:** 0.85.
- **Impacto si no se corrige:** §8 de la guía se narra como lista de funciones y no como recorrido por escenarios. CTX-SENS (D4: encuesta con `Nombre` y `Edad`) no queda declarado donde aplica, y no hay forma mecánica de comprobar que la demo cubre los cinco ESC.
- **Propuesta de dirección:** una tabla D1–D7 → ESC → CTX, agregada como nota a BIT-16-04 y a la fila N6 de 03 §4.1. Propuesta a ratificar (criterio propio, sobre N6 Anexo A y la reparación de 04): D1 ESC-03→ESC-04 (alta propuesta y confirmada, MI-14); D2 y D3 ESC-03; D4 ESC-01 × CTX-SENS (agregados, MI-21); D5 ESC-01 con recuperación, más ESC-02 si se aprueba MI-08; D6 ESC-04; D7 ESC-05. En todas, CTX-LOCAL × CTX-PROTO, con la columna «qué cambia en CTX-NUBE/PROD» que pide 03 §5.

### REQUIS-04 — La trazabilidad no se actualizó tras la integración y no cubre las preguntas de §7 ni la directiva I-06

- **Capa de origen:** integración (y el pedido reeditado, por el método de C2).
- **Ubicación:** `02-Cohesion-Global.md` §6; `04-Integracion.md` §8 (párrafo inicial); REED-16 §9.1 fila C2 y §15; `00-Contrato-De-Entrada.md`.
- **Afirmación:** la única tabla solicitud → núcleo → sección (02 §6) es anterior a los insumos del PO y no la tocó nadie. No incluye los núcleos N0b, N1b y N3b, ni el Anexo F nuevo, ni el cambio de título de §5. No tiene filas para las seis preguntas de REED-16 §7 ni para RD-PO-1…4 y MD-1 (I-06, vinculante). Encima, el método de verificación de C2 apunta a otra sección.
- **Evidencia (E1 + E2):** bloque [4]: `N0b/N1b/N3b/Anexo F en 02 §6 = 0`, sin ninguna fila de pregunta. BIT-16-04 §8: «§6 es la trazabilidad, que no cambia salvo por las secciones nuevas», pero esas filas nuevas no se escribieron. REED-16 §9.1 C2: «Toda S-01…S-17 y toda pregunta de §7 tiene sección», con método «Tabla de trazabilidad de BIT-16-02 §5», que es la de tensiones (la trazabilidad es §6). REED-16 §15 traza las preguntas 1–4 y no tiene fila para la 5 ni para la 6. Bloque [3]: `RD-PO|I-06` en el contrato = 0, aunque I-06 se declara «restricción dura del contrato de entrada».
- **Severidad:** S3. El contenido existe (ver §2, ítem 3) y lo que falta es la tabla que lo demuestra. Sin ella, C2 no se puede ejecutar como compuerta.
- **Confianza:** 0.9.
- **Impacto si no se corrige:** la compuerta C2 de cierre no es mecánica, y RD-PO-4 (barrido de dominio) y MD-1 (prueba móvil) dependen de que alguien se acuerde.
- **Propuesta de dirección:** una tabla de trazabilidad nueva, como nota fechada en BIT-16-04 (02 es fundación y no se reescribe), con cuatro bloques de filas: S-01…S-17, preguntas §7.1–§7.6, PR-1…PR-22 (enlazada con REQUIS-02) y RD-PO-1…4 / MD-1…3. Columnas: núcleo, sección de la guía según BIT-16-04 §8, carpeta de `Examples/` o paso D de la demo, y estado. Además: corregir en la aplicación la referencia «§5» de C2 por «§6 o su sucesora», y sumar una nota al contrato que incorpore I-06.

### REQUIS-05 — La cobertura de MovilidadUrbana.Web (S-09, SUP-05) depende de una decisión opcional

- **Capa de origen:** núcleo (N6 Anexo A).
- **Ubicación:** `Nucleos/N6-Caso-Movilidad-Urbana.md` Anexo A («página de chat Blazor opcional», decisión (a)) y reparación R-C19; `04-Integracion.md` MI-20; `00-Contrato-De-Entrada.md` SUP-05 y DC-05.
- **Afirmación:** S-09 pide una demo basada en MovilidadUrbana.Web **y** MovilidadUrbana.ApiWeb, y SUP-05 asienta que «la demo cubre la web (Blazor Interactive Server) y la API REST». El plan copia sólo ApiWeb (MI-05), y la parte web queda reducida a una página de chat «opcional», sujeta a MI-20, cuya alternativa es «Sólo API».
- **Evidencia (E2):** bloque [7]: SUP-05 citado literal. N6 Anexo A: «ASP.NET Core net10.0 (API + página de chat Blazor opcional)». BIT-16-04 MI-20: alternativa «Sólo API, sin prueba móvil». Ninguna sección del plan dice qué toma la demo de MovilidadUrbana.Web, si no es la temática.
- **Severidad:** S3. Pasa a S2 si gana la alternativa de MI-20 sin registrar el desvío de SUP-05.
- **Confianza:** 0.8.
- **Impacto si no se corrige:** se incumple en silencio la mitad web del pedido S-09 y la vía móvil de I-06 MD-1.
- **Propuesta de dirección:** que la decisión de MI-20 se tome sabiendo que de ella depende S-09/SUP-05. Si gana «Sólo API», se registra el desvío con motivo. En los dos casos, §8 de la guía declara qué se toma de MovilidadUrbana.Web (temática, Blazor Interactive Server) y qué no.

### REQUIS-06 — «Probar todo» (S-17) no tiene la matriz completa snippet → prueba: faltan N1, N3, N3b y N6

- **Capa de origen:** integración.
- **Ubicación:** `04-Integracion.md` §7 (P-01…P-14); `Nucleos/N1-Capa-IA-En-El-Stack.md` nota de reanudación, fila 3.
- **Afirmación:** los pendientes de re-verificación cubren los snippets de N2, N4 y N5 (P-14) y piezas sueltas de N3/N6, pero no recogen el pendiente que N1 dejó escrito (sus snippets 4.1, 4.3, 4.4 y 4.6 «nunca se corrieron»). Tampoco hay un inventario que diga, para cada snippet de cada núcleo, en qué ejemplo o prueba queda probado.
- **Evidencia (E1 + E2):** bloque [5]: `P-14 | Snippets de N2, N4 y N5 …`; `menciones de N1 en 04 §7 = 0`; N1 L532: «Nunca se corrieron, tampoco contra la LAN. Correr 4.1, 4.3, 4.4 y 4.6 contra <equipo-de-contingencia>…». Conteo de bloques C# por núcleo: N1 7, N3 8, N3b 1, N6 6; ninguno tiene un pendiente que los nombre uno por uno.
- **Severidad:** S3.
- **Confianza:** 0.75 (parte de N3/N6 queda cubierta de hecho por EA-5/EA-6 y por la suite `ConModelo/`, pero eso no está trazado).
- **Impacto si no se corrige:** algún snippet de la guía llega a publicarse sin haberse probado, contra S-17 («probar todo»), y nadie lo detecta porque no hay lista contra la cual cotejar.
- **Propuesta de dirección:** agregar P-15 (snippets de N1 4.1/4.3/4.4/4.6 contra el Ollama propio en contenedor (<equipo-de-contingencia>)) y un inventario en el plan del Anexo E: cada snippet de la guía → ejemplo, prueba o registro R-LLM, con estado «compila» / «corrió con modelo (N, tasa)» / «conceptual, no ejecutable (declarado)».

### REQUIS-07 — La lista de `Examples/` no deja lugar para lo que el propio plan propone (MI-04, PR-20, PR-22)

- **Capa de origen:** integración.
- **Ubicación:** `04-Integracion.md` §8 (último párrafo) y MI-04; `Nucleos/N6-Caso-Movilidad-Urbana.md` Anexo B.
- **Afirmación:** BIT-16-04 §8 congela la lista de N6 Anexo B (01–09, más 10 y 11) «con tres ajustes», y ninguno de esos ajustes da lugar a la prueba de arquitectura que MI-04 propone «como ejemplo en `Examples/`», al ejemplo pareado SK/MEAI de PR-22 ni a las pruebas negativas del primer ejercicio (PR-20). Si la mesa los aprueba, no tienen carpeta ni núcleo dueño.
- **Evidencia (E1 + E2):** bloque [7]: en N6 Anexo B, `arquitectura = 0`, `KernelFunction = 0`, `negativ = 0`. MI-04: «Prueba de arquitectura (`grep` o test) como ejemplo en `Examples/` y en la demo». BIT-16-04 §8: «se mantiene la lista de N6 Anexo B (01–09 más 10 y 11 opcionales), con tres ajustes» (01 selector, 05 comparativo, 07 diff).
- **Severidad:** S3.
- **Confianza:** 0.8.
- **Impacto si no se corrige:** un MI aprobado no se materializa, o se materializa en una carpeta improvisada que rompe la numeración `NN-<núcleo>-<tema>` de REED-16 §11. En los dos casos falta evidencia para la pregunta §7.6 («sin romper su arquitectura»).
- **Propuesta de dirección:** al aprobar MI-04 y decidir PR-20/PR-22 (REQUIS-02), fijar en la misma nota su carpeta de `Examples/` (o su lugar en `tests/Cableado/` de la demo) y su núcleo dueño. Así la lista de §8 queda cerrada contra lo votado.

---

## 2. Lo que revisé y está bien

1. **Toda solicitud tiene destino.** S-01…S-17 tienen núcleo y sección prevista, o el artefacto de proceso que las cumple (BIT-16-02 §6; REED-16 §15). Las de contenido (S-01…S-10, S-17) tienen sección en la estructura ajustada de BIT-16-04 §8, y las de proceso (S-11…S-16) tienen archivo en REED-16 §11 (S-13 en §8.3; S-14 en §10; S-16 con las rutas exactas). No encontré ninguna solicitud huérfana. Lo que falta es actualizar la tabla (REQUIS-04), no contenido.
2. **Cada escenario tiene al menos un artefacto ejecutable previsto.** ESC-01: `Examples/05`, `06` y D4/D5. ESC-02: `Examples/04` (similitud sobre los requisitos, que ya coincide con el candidato nuevo de MI-08). ESC-03: `Examples/03` y D2/D3. ESC-04: `Examples/06` y `07`, D1/D6. ESC-05: `Examples/08` y D7. La matriz BIT-16-03 §4.1 no tiene fila ni columna vacía. CTX-NUBE no se ejecuta, y el plan lo resuelve como corresponde: lo declara («qué cambiaría», 03 §5) y muestra el cambio de proveedor por `/v1` (MI-13).
3. **Las seis preguntas de REED-16 §7 tienen material en los núcleos.** §7.1: N1, más la tensión 1 de BIT-16-04 (qué del diagrama se sostiene). §7.2: N2 §3, que incluye la deprecación de `Microsoft.Extensions.AI.Ollama` [E2] y la tabla GA/preview (tensión 8). §7.3: N3, más N3b y la tabla de decisión de BIT-16-04 §6.3, que responde «cuándo no hace falta RAG». §7.4: N4 §2.13 y E-B6 para LangGraph. §7.5: N5 G1–G5 (costo y tokens incluidos) y M1–M12. §7.6: tensión 7, EA-3 y N6. Lo único que falta es la tabla que lo demuestre (REQUIS-04).

---

## 3. Posición sobre los MI de mi mandato

Tomo posición sólo donde la decisión cambia la **cobertura** de una solicitud, de una pregunta de §7, de un escenario o del plan de `Examples/`/`Demos/`. No voto la corrección técnica.

| MI | Posición | Fundamento (desde Requisitos) |
|---|---|---|
| MI-03 | propuesta | S-17 pide «probar todo», y PR-8 (I-03) pide el comparativo CAG/RAG «con tiempos medidos». Sin otro servidor, N3b §3.7 y el juez (P-03) quedan sin evidencia. Condición: si el pedido no prospera, cada punto se rotula «no medido» en la guía y se registra, en lugar de desaparecer. |
| MI-04 | propuesta | Es la única evidencia mecánica para la pregunta §7.6 («sin romper su arquitectura»). Requiere fijar su carpeta (REQUIS-07). |
| MI-05 | propuesta | PR-17 como variante de ESC-04 deja cerrado el conjunto ESC-01…05, que es lo que permite el control de completitud de 03 §4.1, y responde §7.6 con un `diff` verificable. Un ESC-06 obligaría a rehacer las matrices de N0. |
| MI-07 | propuesta | Con los dos adaptadores, la demo cubre a la vez «cuándo no hace falta RAG» (contexto fijo) y el pipeline RAG (S-01: RAG Pipeline/Vector DB; §7.3). La alternativa deja RAG fuera de la demo. |
| MI-08 | propuesta | Sin candidato, ESC-02 no tiene paso en la demo y la fila N6 de 03 §4.1 queda con un hueco. `Examples/04` ya trabaja sobre los requisitos. |
| MI-09 | propuesta | RD-PO-3 (I-06, vinculante) obliga: todo ejemplo usa entidades de Movilidad Urbana, o queda como explicación conceptual declarada. El diff 4.1 → 4.2 cubre S-05 (creación de agentes) dentro del caso único. |
| MI-10 | propuesta | Ordenar por mecanismo coincide con PR-5 (escalera de complejidad) y deja registrado de hecho que se aplica (REQUIS-02). S-10 queda cubierto por fuentes aunque el consumo HTTP sea «no ejecutado», siempre que se lo rotule así. |
| MI-13 | propuesta | Mostrar el selector en la composición de la demo, además de en el ejemplo 01, hace visible en el caso integrado lo que cambia entre CTX-LOCAL y un proveedor compatible con OpenAI (S-04, estrategias de integración). |
| MI-19 | abstención | Las dos opciones cumplen R-PO-3 y RD-PO-3 (la pregunta se responde, con o sin ejemplo). Elegir entre ellas es didáctica y dominio, no cobertura. |
| MI-20 | propuesta | Es la única pieza del plan que cubre la mitad web de S-09 y SUP-05, y la vía móvil de I-06 MD-1 (REQUIS-05). Si gana la alternativa, hay que registrar el desvío de SUP-05. |
| MI-24 | propuesta (investigar) | PR-13 (I-04) nombra literalmente «sincrónico o en segundo plano» entre las decisiones de arquitectura que pide hacer explícitas. Sin investigarlo, esa fila del Anexo F queda sin evidencia. El umbral de C2 se fija junto con AH-02. |

---

## 4. Solicitudes de convocatoria

Fuera de mi mandato; sólo dejo la señal con su ubicación.

- **A la presidencia y a Verificación/QA:** ninguno de los nueve registros de núcleo tiene las secciones 4 («Marcas [C] resueltas») ni 6 («Validación del núcleo» y veredicto de la mesa) que exige REED-16 §6.2. El conteo de «validación del núcleo» da 0 en todos (comando en `evidencia-requisitos/`, mismo patrón). La definición de «núcleo validado» (§6.2, último párrafo) no tiene dónde registrarse. Que se juzgue si eso bloquea la redacción.
- **A Edición de material bibliográfico:** la referencia «BIT-16-02 §6» del despacho y la «§5» de C2 (REED-16 §9.1) apuntan a secciones corridas de BIT-16-02 (BIT-16-04 §8 ya lo advierte para §6/§7). Conviene una pasada de anclas entre REED-16 y la fundación antes de redactar.
