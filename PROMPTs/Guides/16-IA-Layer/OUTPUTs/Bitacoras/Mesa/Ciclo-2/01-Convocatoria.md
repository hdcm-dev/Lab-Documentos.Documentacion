---
doc_id: BIT-16-MESA-C2-01
doc_type: convocatoria
title: Ciclo 2 · Convocatoria y composición del panel (M§4.1, M§5.1)
version: v1
status: cerrado (registro del ciclo 2)
origin: agent (secretaría de la mesa; sin voto)
last_review: 2026-10-26
traces: [BIT-16-MESA-C1-01, BIT-16-MESA-C1-08, BIT-16-00 DC-02, M§4.1, M§4.3, M§5.1, M§9, Mesa/Ciclo-2/02-Informes, Mesa/Ciclo-2/03-Consolidacion.md]
---

# Ciclo 2 · Convocatoria del panel

Objeto revisado: `../../04-Plan-De-Integracion.md` en su **ESTRUCTURA APROBADA v1** (1003 líneas; copia fiel en `../../04-Plan-De-Integracion.v1.md`). El ciclo traía cinco pendientes del cierre del ciclo 1 (`../Ciclo-1/08-Cierre.md`): ratificar AJ-01…AJ-08, la colisión «nivel A/B», la sospecha de homogeneidad del jurado (100 % unánime), la deuda declarada con las cinco preguntas de nivel C, y **convocar Operación y entrega**. Este registro lo escribe la secretaría al cerrar el ciclo, a partir de los informes que entraron en `02-Informes/` y de la consolidación.

## 1. Composición efectiva del panel

| # | Rol | Origen | Señal y ubicación | Informe | Hallazgos que llegaron a la consolidación | Ítems H2 en los que figura |
|---|---|---|---|---|---|---|
| 1 | Requisitos | Núcleo (M§4.1.1) | Siempre: S-01…S-17, insumos I-01…I-06 contra la matriz BIT-16-02 §6 | `requisitos.md` | 7 (REQ2-01…07) | 8 |
| 2 | Verificación / QA | Núcleo | Siempre: afirmaciones con fuente, oráculos, compuertas | `qa.md` | 7 | 7 |
| 3 | Implementador ingenuo | Núcleo | Siempre: reproducir sin preguntar | `ingenuo.md` | 7 | 9 |
| 4 | Abogado del diablo | Núcleo | Siempre; en este ciclo, además, revisión de los `NO_PROCEDE` (M§9) | `abogado-del-diablo.md` y `../00-Revision-Abogado-NO-PROCEDE.md` | 7 (panel) + 7 (revisión) | 9 |
| 5 | Didáctica | Pedido del PO (DC-02, E4) | Perfil impuesto: progresión, OA, preguntas guía | `didactica.md` | 6 | 6 |
| 6 | Edición de material bibliográfico | Pedido del PO (DC-02, E4) | Perfil impuesto: jerarquía, remisiones, familias de ID | `edicion.md` | 6 | 6 |
| 7 | Senior .NET | Pedido del PO (DC-02, E4) | Perfil impuesto: M.E.AI 10.11.0, OllamaSharp 5.5.0, Blazor, DI | `senior-net.md` | 7 | 8 |
| 8 | Experto en IA | Pedido del PO (DC-02, E4) | Perfil impuesto: escaleras, oráculos, juez | `ia.md` | 7 | 9 |
| 9 | Arquitectura de software | Pedido del PO (DC-02, E4) y catálogo con señal | Más de un componente: la demo funde dos hosts del caso base (plan v1 §F.2) | `arquitectura.md` | 7 | 8 |
| 10 | Desarrollador de código | Pedido del PO (DC-02, E4) | Perfil impuesto: arnés en contenedor, presupuesto contra el modelo | `desarrollo.md` | 6 | 7 |
| 11 | **Operación y entrega** (con Rendimiento y costo fusionados) | **Catálogo M§4.1.2, convocado en este ciclo** | Ver §2 | `operacion.md` | 6 (OP-01, OP-03…OP-07; OP-02 entró como insumo de RAT-AJ-01) | 7 |
| 12 | AH-01 Seguridad de aplicaciones con LLM | Ad hoc (M§4.1.3), carta de REED-16 §8.3 | Herramientas de escritura, `/mcp`, texto no confiable, repos públicos | `AH-01.md` | 5 (tope 5 de la carta, respetado) | 5 |
| 13 | AH-02 Evaluación de sistemas LLM y RAG | Ad hoc, carta de REED-16 §8.3 | «Probar todo contra Qwen» con M chico y juez local | `AH-02.md` | 7 | 8 |

Además del panel actuaron, sin voto sobre los hallazgos: el **auditor de homogeneidad** (`../00-Auditoria-Homogeneidad.md`, M§9, sobre el jurado del ciclo 1), el **relator** (`../03-Consolidacion.md`), el **cuerpo auditor** (`../05-Parches.md`) y la secretaría (este archivo, 04, 06, 07 y 08). El **jurado** fue de cinco jueces con función objetivo propia (evidencia, impacto, costo-beneficio, coherencia, riesgo), endurecido por el diagnóstico de la auditoría: cada voto ancla en el texto y la salida `INSUFICIENTE` se usó (cinco votos en cinco ítems).

«Hallazgos que llegaron a la consolidación» cuenta los IDs de cada familia citados como origen en `03-Consolidacion.md` §1; la consolidación los fusionó en **59 hallazgos** H2-001…H2-059, más 9 ratificaciones, 14 re-votos del ciclo 1 y 7 contradicciones (89 ítems votados).

## 2. Operación y entrega: señal y aporte

**Señal observable en el objeto** (M§4.1.2, «despliegue, ambientes, disponibilidad, observabilidad, versionado» y «límites de consumo»): plan v1 §E.5 (tope de 4 h de `<recurso-compartido>`, turnos con ttl renovable), §E.1 viñeta «Arnés» (`verificar.sh` con turnos `build` y `<recurso-compartido>`), §F.9 (contenedor, red de compose, `/mcp` en loopback), §G.2 R-01/R-02 (servidor compartido sólo CPU; máquina al límite), §G.3 DEP-14 (recurso `[recurso-modelo-propio]`). En el ciclo 1 seis informes pidieron su convocatoria en caliente (`../Ciclo-1/03-Consolidacion.md` §6) y el cierre la recomendó (`../Ciclo-1/08-Cierre.md`, `postergados_por_cupo`).

**Aporte** (E1 en tres de sus seis hallazgos, con prueba aislada del gestor de recursos): H2-020 (DEP-14 imposible con el gestor actual: `<gestor-de-turnos>` aborta en la l. 94), H2-019 (orden de turnos y anidación de `build` con `<recurso-compartido>`), H2-004 (tope sin medidor), H2-017 (provisión del Ollama propio), H2-021 (inventario de limpieza), parte de H2-022 y H2-025, y el insumo principal de RAT-AJ-01 (OP-02, la variable de tipo de servidor que faltaba). Lo que corrigió quedó en PAR2-04, PAR2-05, PAR2-08, PAR2-21 y PAR2-25.

## 3. Mesa de convocatoria: catálogo variable

| Especialidad | Señal | Decisión | Motivo |
|---|---|---|---|
| Operación y entrega | Presente (§2) | **CONVOCAR** | Pendiente del cierre del ciclo 1; aportó 7 ítems procedentes |
| AH-01 Seguridad | Presente (aprobación sin MAF, `/mcp`, MCP cliente) | `INSTANCIAR_AD_HOC` (reconvocado) | Aportó H2-009, H2-012, H2-013, H2-014, H2-052 |
| AH-02 Evaluación LLM/RAG | Presente (M = 4 o 5, juez local, oráculos) | `INSTANCIAR_AD_HOC` (reconvocado) | Aportó H2-022, H2-023, H2-026, H2-027, H2-029, H2-030, H2-031 y parte de H2-002. En el ciclo 1 se pasó de su tope; en este, 7 dentro del tope de 7 del contrato (su carta dice 5: el apartamiento se repite y queda registrado) |
| Formal / matemático | Presente: Clopper-Pearson, binomial pareada, umbrales de calibración (plan v1 l. 616, 641) | **Postergado por cupo** | Cubierto por AH-02 y QA; el cuerpo auditor recalculó la aritmética (`05-Parches.md` §0.2). Desarrollo lo pidió como opcional (H2-029). Se recomienda para el ciclo 3 si se vota la regla de §10.4 |
| Datos y dominio | Presente («Vector DB», «SQL DB») | `NO_CONVOCAR` | Lo cubren senior .NET e IA, como en el ciclo 1 |
| AH-03 Ecosistema LangChain/LangGraph | Condicional | `NO_CONVOCAR` | Sin necesidad de E1 en Python (P-09 vigente) |

## 4. Techo del panel

Núcleo (4) + seis perfiles del PO (DC-02, no consumen cupo: REED-16 §8.5) + 3 por señal (Operación y entrega, AH-01, AH-02): 3 de 5. **Dentro del techo** (M§4.1.4) contando como en el ciclo 1.

## 5. Contraste con los hallazgos reales (M§9, «panel armado por costumbre»)

- Todos los convocados aportaron ítems procedentes; `aporte_nulo` vacío.
- Más presencia: IA, ingenuo y abogado del diablo (9 cada uno). La especialidad nueva, Operación y entrega, aportó los dos únicos E1 sobre el entorno de ejecución (H2-020 y la parte de H2-004 sobre `<gestor-de-turnos>`).
- El panel no convergió: siete contradicciones explícitas entre especialistas (X2-01…X2-07), lo que es la señal contraria al consenso vacío del ciclo 1.
