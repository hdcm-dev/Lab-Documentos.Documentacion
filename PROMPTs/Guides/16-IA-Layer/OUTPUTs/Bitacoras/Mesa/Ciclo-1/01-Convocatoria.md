---
doc_id: BIT-16-MESA-C1-01
doc_type: convocatoria
title: Ciclo 1 · Convocatoria y composición del panel (M§4.1, M§5.1)
version: v1
status: cerrado (registro del ciclo 1)
origin: agent (secretaría de la mesa; sin voto)
last_review: 2026-10-26
traces: [REED-16 §8, BIT-16-00 DC-02, M§4.1, M§5.1, Mesa/Ciclo-1/02-Informes, Mesa/Ciclo-1/03-Consolidacion.md]
---

# Ciclo 1 · Convocatoria del panel

Objeto revisado: `../../04-Plan-De-Integracion.v0.md` (BIT-16-04 v0, 763 líneas). Este registro reemplaza al `00-Convocatoria.md` que preveía REED-16 §8.6 y que no llegó a escribirse antes del panel. Lo reconstruye la secretaría al cerrar el ciclo, a partir de REED-16 §8, el contrato (DC-02) y los informes que efectivamente entraron en `02-Informes/`. La matriz BIT-16-02 §6 (fila S-12) remite a este archivo.

## 1. Composición efectiva

| # | Rol | Origen | Motivo de la convocatoria (señal y ubicación) | Informe | Hallazgos emitidos | Ítems procedentes en los que figura |
|---|---|---|---|---|---|---|
| 1 | Requisitos | Núcleo permanente (M§4.1.1) | Siempre. ¿Cada S-01…S-17 y cada pregunta de REED-16 §7 tiene sección? | `requisitos.md` | 7 | 12 |
| 2 | Verificación / QA | Núcleo permanente | Siempre. Afirmaciones con fuente, ejemplos que corren, R-LLM | `qa.md` | 7 | 16 |
| 3 | Implementador ingenuo | Núcleo permanente | Siempre. Reproducibilidad sin preguntar | `ingenuo.md` | 7 | 10 |
| 4 | Abogado del diablo | Núcleo permanente | Siempre. Ataca la propuesta dominante; entró después de leer al resto | `abogado-del-diablo.md` | 7 | 13 |
| 5 | Didáctica | Pedido del PO (DC-02, E4) | Perfil impuesto: progresión, marco de referencia, preguntas guía | `didactica.md` | 7 | 8 |
| 6 | Edición de material bibliográfico | Pedido del PO (DC-02, E4) | Perfil impuesto: jerarquía, voz única, aparato de referencias | `edicion.md` | 7 | 10 |
| 7 | Senior .NET | Pedido del PO (DC-02, E4) | Perfil impuesto: .NET 10 idiomático, paquetes, Blazor, EF Core | `senior-net.md` | 7 | 9 |
| 8 | Experto en IA | Pedido del PO (DC-02, E4) | Perfil impuesto: conceptos de IA, Qwen, RAG, agentes, LangGraph | `ia.md` | 7 | 9 |
| 9 | Arquitectura de software | Pedido del PO (DC-02, E4); además rol de catálogo con señal | Más de un componente e integración entre capas (imagen de entrada; prompt §Contexto) | `arquitectura.md` | 7 | 9 |
| 10 | Desarrollador de código | Pedido del PO (DC-02, E4) | Perfil impuesto: Linux con Docker, sin SDK en el host. REED-16 §8.2 lo fundía con el implementador ingenuo; en el ciclo 1 entró con informe propio | `desarrollo.md` | 7 | 10 |
| 11 | AH-01 Seguridad de aplicaciones con LLM | Ad hoc (M§4.1.3), carta en REED-16 §8.3 | Agentes que actúan sobre casos de uso; RAG con texto externo; `Nombre`/`Edad` en el caso base; repos públicos (imagen AI LAYER; prompt §Solicitudes párr. 1; ia-db 02 §2; R-PRIV) | `AH-01.md` | 5 (tope 5) | 6 |
| 12 | AH-02 Evaluación de sistemas LLM y RAG | Ad hoc, carta en REED-16 §8.3 | «Probar todo contra Qwen» con un modelo no determinista (prompt §Solicitudes párr. 2) | `AH-02.md` | 7 | 10 |

«Hallazgos emitidos» cuenta las entradas de la sección 1 de cada informe; «ítems procedentes» cuenta en cuántos de los 63 hallazgos consolidados (todos `PROCEDE`) figura el rol como origen (`03-Consolidacion.md` §1). Total emitido: 82 hallazgos, que el relator consolidó en 63 (más 9 contradicciones y 22 propuestas PR).

**Observación sobre AH-02**: su carta fija `tope_hallazgos: 5` y el informe trae 7 entradas. La consolidación las tomó todas. Queda registrado como apartamiento de la carta (M§4.1.3) para el ciclo 2: si se reconvoca, el tope se respeta o la carta se enmienda antes del panel.

## 2. Mesa de convocatoria: catálogo variable (REED-16 §8.3)

| Especialidad | Señal | Decisión | Motivo |
|---|---|---|---|
| AH-01 Seguridad de aplicaciones con LLM | Presente (ver fila 11) | `INSTANCIAR_AD_HOC` | Ningún perfil del PO juzga si lo que la guía enseña es seguro de copiar. Aportó 6 ítems procedentes, entre ellos H-010, H-012 y H-013, que cambiaron §F.4, §11 y el Anexo B |
| AH-02 Evaluación LLM/RAG | Presente (ver fila 12) | `INSTANCIAR_AD_HOC` | Sin él, S-17 se cumple con pruebas que pasan por azar. Aportó H-001, H-003, H-028 a H-030: la unidad de muestra y los oráculos de §E |
| Operación y entrega (con Rendimiento y costo) | Presente: capas INFRASTRUCTURE y Cache de la imagen | **Postergado por cupo** | Con los seis perfiles del PO y dos ad hoc el panel ya pasaba el techo. Seis informes pidieron su convocatoria en caliente (senior .NET, IA, desarrollo, QA, AH-02 y abogado del diablo: `03-Consolidacion.md` §6) por timeouts, turnos y medición de tiempos; esos temas los cubrieron H-021, H-056 y H-059. **Se recomienda convocarlo en el ciclo 2** |
| Formal / matemático | Presente: umbrales y cuantificadores (intervalos, Fisher, hit rate, líneas base) | **Postergado por cupo** | La aritmética la hicieron AH-02 y QA, y el cuerpo auditor la recalculó (`05-Parches.md` §0.2). Se reconvoca si el ciclo 2 introduce umbrales nuevos |
| Datos y dominio | Presente («Vector DB», «SQL DB») | `NO_CONVOCAR` | Lo cubren senior .NET (EF Core) e IA (almacén vectorial) |
| AH-03 Ecosistema LangChain/LangGraph | Condicional | `NO_CONVOCAR` | El experto en IA no detectó necesidad de E1 en Python; LangGraph queda como snippet «adaptación no ejecutada» (P-09) |

## 3. Techo del panel excedido por pedido explícito del PO

El marco fija **núcleo + hasta 5 variables o ad hoc por ciclo** (M§4.1.4). El ciclo 1 corrió con núcleo (4) + **8** variables o ad hoc: los seis perfiles que el PO pidió de forma explícita (didáctica, edición, senior .NET, experto en IA, arquitectura y desarrollo de código; DC-02, evidencia E4) más AH-01 y AH-02. Exceso: 3 sobre el techo.

- **Motivo**: los perfiles del PO son restricción dura del contrato (DC-02) y la mesa no puede descartarlos. REED-16 §8.5 lo declaró como apartamiento: no consumen cupo, y el techo de 5 rige para los que entran por señal (AH-01, AH-02: 2 de 5).
- **Efecto observado**: panel de 12 voces y 82 hallazgos brutos. La consolidación redujo la redundancia (63 ítems, varios con 3 a 5 orígenes). No hubo hallazgos fuera de mandato que debieran descartarse.
- **Registro**: `apartamientos_del_marco` en `08-Cierre.md`.

## 4. Contraste con los hallazgos reales (M§5.1.c, M§9 «panel armado por costumbre»)

- Todos los convocados aportaron ítems procedentes; ninguno queda como «aporte nulo».
- El rol con más presencia fue QA (16), seguido por el abogado del diablo (13) y requisitos (12). AH-01 tiene la menor cuenta (6), pero con los ítems de mayor riesgo irreversible (H-053 lo señala el juez de riesgo como el más grave del lote; H-012 y H-010).
- La especialidad postergada que más falta hizo es **Operación y entrega**: seis solicitudes de convocatoria en caliente apuntan a ella.
