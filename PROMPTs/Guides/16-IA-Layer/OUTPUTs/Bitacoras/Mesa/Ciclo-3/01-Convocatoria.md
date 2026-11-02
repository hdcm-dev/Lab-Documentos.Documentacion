---
doc_id: BIT-16-MESA-C3-01
doc_type: convocatoria
title: Ciclo 3 · Convocatoria del panel (M§4.1)
version: v1
status: cerrado
origin: agent (secretaría de la mesa)
last_review: 2026-10-26
traces: [BIT-16-MESA-C2-08, BIT-16-MESA-C2-09, BIT-16-04 v2, M§4.1, M§9]
---

# Ciclo 3 · Convocatoria

Objeto: `../../04-Plan-De-Integracion.md`, ESTRUCTURA APROBADA v2 (1236 líneas). Ciclo 3 de 3: último por `ciclos_max`. Lo que no se resuelva acá queda como deuda declarada.

Se registra al cierre, igual que en los ciclos 1 y 2 (apartamiento de REED-16 §8.6, ya declarado).

## 1. Agenda obligatoria (del cierre del ciclo 2)

1. Las papeletas que regían en forma provisional: RV-03, H2-056, RV-05, RV-04, RV-01, RV-11 y el criterio de dificultad B/I/A.
2. P-12 / DEP-15 (H2-050): ¿el contenido «escrito para el ejemplo» cumple RD-PO-1 y RD-PO-3 de I-06?
3. El recorte de alcance: H2-054 (seis de siete pasos de la demo repiten un ejemplo) y H2-056, que habilita la respuesta 1 de la presidencia.
4. El par CTX-NUEVA / CTX-EXISTENTE (respuesta 2 de la presidencia), como parche sobre BIT-16-03 §2 y sobre la §2 de la guía.
5. Las objeciones en minoría del ciclo 2 que no se aplicaron (DEP-12 huérfana, clase M de 131,4 s, compensación de +625, §B.4, dominios ajenos, AC-8 en «coincidente», listas inexistentes).
6. DEP-14 (Ollama propio): el pedido al gestor estaba en curso.

## 2. Composición efectiva del panel

| Rol | Tipo | Motivo | Informe |
|---|---|---|---|
| Requisitos | núcleo | M§4.1.1 | `02-Informes/requisitos.md` |
| Verificación-QA | núcleo | M§4.1.1 | `02-Informes/qa.md` |
| Abogado del diablo | núcleo | M§4.1.1 | `02-Informes/abogado-del-diablo.md` |
| Implementador ingenuo, en el rol de desarrollador de código | núcleo y pedido del PO | M§4.1.1 y DC-02 | `02-Informes/desarrollo.md` |
| Didáctica | pedido del PO | DC-02 | `02-Informes/didactica.md` |
| Edición de material bibliográfico | pedido del PO | DC-02 | `02-Informes/edicion.md` |
| Arquitectura de software | pedido del PO, catálogo con señal | DC-02 | `02-Informes/arquitectura.md` |
| Operación y entrega | catálogo M§4.1.2 | señal: §E.5, §E.1 arnés, DEP-14 | `02-Informes/operacion.md` |
| AH-02 Evaluación LLM/RAG | ad hoc | ¿qué se puede afirmar con M chico y juez local? (RV-11, §10.4) | `02-Informes/AH-02.md` |

Nueve informes, todos a ciegas.

## 3. Descartados y postergados

- **Senior .NET y experto en IA** (perfiles del PO): no se convocan en este ciclo. La agenda es de votación y alcance, y sus temas técnicos los cubren desarrollo, arquitectura y AH-02. Es un apartamiento de DC-02 y queda registrado.
- **AH-01 Seguridad**: la política de origen (H3-008) la levantó requisitos, y la inyección de 16 la levantaron AH-02 y requisitos. No se convoca.
- **Formal / matemático**: el ciclo 2 lo recomendaba para votar la regla de §10.4 y las clases de t. Lo cubrieron AH-02 (regla pareada, M = 6) y QA (H3-019). Queda postergado, sin aporte perdido.
- **Datos y dominio** y **AH-03 LangChain/LangGraph**: NO_CONVOCAR, igual que en los ciclos anteriores.

## 4. Techo del panel

Núcleo 4 (el implementador ingenuo ocupa el rol de desarrollo) más 5 variables y ad hoc (didáctica, edición, arquitectura, operación, AH-02). Es el techo de M§4.1.4, sin exceso.

## 5. Contraste con los hallazgos reales (M§9)

Todos los roles aportaron hallazgos procedentes (ver `08-Cierre.md`, panel). No hay rol con aporte nulo. Los 27 hallazgos se reparten entre los nueve informes, y el que más aportó fue QA (9 de 27 como fuente). El panel no se armó por costumbre: Operación y AH-02 entraron con señal en el plan, y los dos aportaron S1 o S2 (H3-001, H3-004, H3-018).
