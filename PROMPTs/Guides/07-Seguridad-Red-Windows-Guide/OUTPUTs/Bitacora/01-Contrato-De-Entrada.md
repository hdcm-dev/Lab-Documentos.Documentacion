---
doc_id: BIT-01-CONTRATO
doc_type: bitacora
title: Contrato de entrada y encuadre del ciclo
status: vigente
origin: ia-assisted
confidence: alta
owner: Guía de estudio — Seguridad en red Windows
last_review: 2026-09-18
audience: [humano, agente]
traces: [BIT-02-NUCLEOS, ESC-TESTIGO, MESA-01-CONVOCATORIA]
---

# Bitácora 01 — Contrato de entrada y encuadre

**Fecha:** 2026-09-18
**Prompt de origen:** `/LAB/Lab-Documentos.Documentacion/PROMPTs/Guides/07-Seguridad-Red-Windows-Guide/Crear-Seguridad-Red-Windows-Guide.md`
**Marco del ciclo de revisión:** `/IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md`
**Profile aplicado:** `/IA/IA.Prompts/PromptFramework/Profiles/Study-Guide-Documentation.md`
**RuleSet:** `RuleSet-Study-Guide` (Rule-All, Rule-Workflow, Rule-Evidences, Rule-Markdown, Rule-Documentation, Rule-Indexing, Rule-Agents, Rule-Dual-Audience, Rule-Narrative-Voice) + `Rule-Security-Testing`.

---

## 1. Contrato de entrada (§2 del marco)

```yaml
objeto:
  artefacto: documentación (guía de estudio + cuadernillo de ejercicios)
  entregables:
    - /LAB/Lab-Documentos/Guides/Seguridad-Red-Windows-Guide/Beginning-Security-Windows-Network-Guide.md
    - /LAB/Lab-Documentos/Guides/Seguridad-Red-Windows-Guide/Cuaderno-Ejercicios-Seguridad-Windows.md
  version: 0 (regeneración; los entregables previos fueron eliminados en el árbol de trabajo)
  capas_derivadas: []
objetivo: >
  Que una persona sin conocimientos previos de redes ni de sistemas operativos pueda auditar
  un servidor Windows dentro de una red Windows administrada con vicios, reconocer síntomas y
  rastros de intrusión con las herramientas nativas del sistema, entender los resultados de las
  pruebas que ejecuta, y comprender de forma metodológica cómo se reproduce un pentesting.
restricciones_duras:
  - Lector sin experiencia previa: todo término se define antes de usarse.
  - Lenguaje claro sin perder el tecnicismo; prohibido el registro coloquial.
  - Documentos autocontenidos, no delta.
  - Estructura jerárquica con índice, definiciones, ejemplos, snippets y gráficos mermaid donde aporten.
  - Preguntas guía con respuestas explicativas, formadoras de criterio.
  - Cada comando declara qué se espera ver y cómo interpretarlo.
  - No inventar información; toda afirmación respaldada por evidencia verificable (Rule-Evidences).
  - Prioridad a las herramientas nativas del sistema; el tooling ofensivo se presenta después, con encuadre de autorización (Rule-Security-Testing).
  - Escenario base documentado sobre Windows Server 2019, revisado antes de redactar la guía.
decisiones_cerradas:
  - Idioma español.
  - Sistema objetivo del escenario: Windows Server 2019 (Datacenter/Standard, PowerShell 5.1).
  - Un documento-guía principal + un cuadernillo de ejercicios, ambos en la carpeta indicada.
  - Herramientas nativas primero; tooling externo de la industria en las secciones finales.
  - Toda salida de comando mostrada se rotula como ILUSTRATIVA (no hay un Windows real donde capturarla).
fuera_de_alcance:
  - Respuesta a incidentes contractual o legal en una jurisdicción concreta.
  - Configuración productiva de un SIEM comercial.
  - Desarrollo de exploits propios.
umbral_de_calidad: bloquean el cierre S1 y S2.
presupuesto: { ciclos_max: 2, hallazgos_max_por_especialista: 7 }
```

### 1.1 Campos ausentes en el prompt y supuestos declarados

El marco (§10.1) obliga a resolver los faltantes con **supuestos declarados**, no con preguntas al usuario.

| Campo ausente | Supuesto adoptado | Fundamento |
|---|---|---|
| Versión exacta de Windows Server | Windows Server 2019; se señala lo que cambia hacia 2016 y 2022 | El prompt fija 2019 como base del escenario |
| Perfil del lector | Persona técnica adyacente (estudiante, administrativo o soporte con acceso al servidor) sin formación en redes ni SO | El prompt pide «sin conocimientos» pero le hace ejecutar comandos en un servidor |
| Disponibilidad de laboratorio | El lector puede montar máquinas virtuales aisladas | Sin laboratorio no puede practicar sin riesgo; se agrega capítulo de laboratorio |
| Autorización para pentesting | El lector opera sobre infraestructura propia o con autorización escrita | Sin ese supuesto la sección ofensiva sería inadmisible (Rule-Security-Testing) |
| Idioma de la interfaz de Windows | Se documentan nombres en español e inglés cuando difieren | El entorno del lector puede estar en cualquiera de los dos |

---

## 2. Tensiones detectadas en el contrato (para elevar a la mesa)

**T-01 — Lector sin conocimientos frente a un servidor productivo comprometido.** El prompt pide una guía para alguien sin experiencia, aplicada a un servidor con sospecha de intrusión activa. Que un principiante explore un sistema comprometido puede destruir evidencia y alertar al intruso. La guía necesita una sección de «reglas de no daño» y orden de volatilidad antes del primer comando, y debe canalizar la práctica a un laboratorio.

**T-02 — «No inventar» frente a «resultados esperados».** No hay un Windows disponible en el entorno de redacción para capturar salidas reales. Toda salida mostrada se rotula como ilustrativa —forma de la salida y significado de cada columna—, y no se presenta como captura de una corrida real. La restricción se declara dentro del propio entregable.

**T-03 — Pentesting en una guía para principiantes.** Las herramientas ofensivas son de doble uso. El tratamiento es metodológico y reproducible en laboratorio, con el encuadre de autorización por delante; no un recetario aplicable a la red de producción del lector.

**T-04 — El escenario testigo como fuente de verdad.** Para respetar «no inventar» sin un Windows real, se construye y documenta un **escenario testigo** (ESC-TESTIGO): un Windows Server 2019 ficticio pero coherente, con inventario, línea de base y una cronología de intrusión. Las salidas ilustrativas de la guía derivan de ese escenario, lo que las hace consistentes entre sí y auditables contra un modelo único.

---

## 3. Plan de trabajo (Rule-Workflow)

1. **Escenario testigo** documentado (`OUTPUTs/Escenario/`) y revisado: inventario, línea de base, cronología de intrusión y corpus de evidencia. Base de todas las salidas ilustrativas.
2. **Descomposición conceptual** en núcleos + documento de cohesión (`OUTPUTs/Nucleos/`).
3. **Redacción** de la guía y del cuadernillo (entregables en `Lab-Documentos`).
4. **Mesa evaluadora** (`OUTPUTs/Mesa/`): convocatoria, panel a ciegas, jurado, parches, aplicación y cierre.
5. **Verificación** contra el mapa conceptual, aplicación de correcciones y entrega por PR.

**Estado:** en ejecución. Este documento cierra la Fase 0.
