---
doc_id: MESA-01-CONVOCATORIA
doc_type: mesa
title: Registro de convocatoria del panel
status: vigente
origin: ia-assisted
audience: [humano, agente]
traces: [BIT-01-CONTRATO, GUIA-PRINCIPAL, MESA-02-VEREDICTOS]
---

# Mesa evaluadora — Registro de convocatoria

**Fecha:** 2026-09-18
**Marco:** `/IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md`
**Objeto bajo revisión:** los dos entregables (`GUIA-PRINCIPAL`, `CUADERNO`) contra el objetivo del contrato de entrada (`BIT-01-CONTRATO`).

## 1. Barrido de señales (§5.1.b del marco)

| Señal observable en el artefacto | Ubicación | Especialidad que activa |
|---|---|---|
| Material formativo para lector sin experiencia | Todo el objeto | Didáctica |
| Obra bibliográfica con índice, citas, glosario | §12, §13, índices | Edición de material bibliográfico |
| Dominio técnico: eventos, comandos, AD | §4–§9 | Seguridad en redes Windows |
| Ejecutabilidad por un principiante | Comandos y ejercicios | Implementador ingenuo (lector sin conocimientos) |
| Contenido de doble uso (pentesting, herramientas ofensivas) | §10–§11, cuaderno §9 | Verificación/evidencia + ética (Rule-Security-Testing) |

## 2. Composición decidida (la mesa dirime, no se eleva al usuario)

El prompt nombró tres especialidades (didáctica, edición bibliográfica, seguridad Windows) y pidió «analiza si necesitas un experto más». La mesa convoca esas tres y **suma dos** por señales observables:

| Rol | Tipo | Justificación |
|---|---|---|
| **E1 Didáctica** | Nombrado por el prompt | Objetivo formativo para principiante absoluto |
| **E2 Edición bibliográfica** | Nombrado por el prompt | Coherencia de obra, citación, terminología |
| **E3 Seguridad en redes Windows** | Nombrado por el prompt | Exactitud técnica (Event IDs, comandos, ATT&CK) |
| **E4 Lector sin conocimientos** | Núcleo permanente (implementador ingenuo, §4.1.1) | Es el destinatario declarado; su función no depende del dominio |
| **E5 Verificación / ética de doble uso** | Catálogo variable (Seguridad y privacidad, §4.1.2) + Rule-Security-Testing | Señal de pentesting y herramientas ofensivas; verifica encuadre y evidencia |

**Descartados con motivo:** rol formal/matemático (no hay umbrales ni cálculos), rol de datos/ciclos de vida (no hay modelo de datos), arquitectura (no hay sistema a diseñar). Se registran por si un defecto en esas áreas apareciera después.

## 3. Reglas de trabajo aplicadas

- Panel **a ciegas y en paralelo**: cada especialista produjo su informe sin ver los de los pares (evita anclaje).
- Tope de 7 hallazgos por especialista; se pidió además declarar aciertos (para distinguir «no lo miró» de «lo miró y está bien»).
- Nivel de evidencia exigido: cita literal del documento (E2) o fuente oficial.
- Segundo ciclo: la mesa revalida el objeto tras aplicar las correcciones (§ del prompt: «la mesa debe volver a analizar el documento una vez finalizado»).

El panel de veredictos y el cierre se registran en `MESA-02-VEREDICTOS` y `MESA-03-CIERRE`.
