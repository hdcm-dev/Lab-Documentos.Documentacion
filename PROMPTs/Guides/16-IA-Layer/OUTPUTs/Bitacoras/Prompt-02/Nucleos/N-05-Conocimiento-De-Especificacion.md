# N-05 · Conocimiento de especificación

> Núcleo conceptual del prompt 02 de la guía 16. Etapa: planificación (nadie aplica). Cohesión: [00-Cohesion.md](00-Cohesion.md).

## Índice

1. [Definición](#1-definición)
2. [Alcance](#2-alcance)
3. [Entradas](#3-entradas)
4. [Salidas esperadas](#4-salidas-esperadas)
5. [Criterios de validación](#5-criterios-de-validación)
6. [Dependencias](#6-dependencias)
7. [Riesgos](#7-riesgos)
8. [Preguntas para la mesa](#8-preguntas-para-la-mesa)

## 1. Definición

Diseño de `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Conocimientos/knowledge-AI-Layer-Integration-Designing-Specification.md` (hoy 0 bytes), un conocimiento aplicable por agentes o humanos «en otro contexto» para especificar la integración de una capa de IA en proyectos nuevos o existentes (solicitud 3).

## 2. Alcance

- Incluye: forma del documento (cabecera, §0–§13 al estilo del Conocimiento MAUI, que separa regla/razón/evidencia en Principio P-n · Criterio · Fuente y cierra con «Límites»; R5).
- Incluye: sección de especificación con requisitos con Id, criterio de aceptación y prueba; casos de uso.
- Incluye: propuesta de R6 (arc42, C4 en mermaid, ADR, riesgos mapeados a OWASP LLM/Agentic, escenarios de calidad medidos con evaluadores .NET).
- Incluye: corrección del conocimiento con lo aprendido en N-06/N-07.
- Excluye: el caso privado con nombres (sólo en abstracto).

## 3. Entradas

- Guía 0.11.0 §13 (ADR) y Anexos A y B (R1 propone derivar de ahí).
- R5-Marco §Libro MAUI y §Plantilla propuesta; T3 (Rule-Forma-De-Conocimiento vs forma MAUI).
- R6-Industria §Propuesta.
- Resultados de N-03, N-06, N-07.

## 4. Salidas esperadas

- Plantilla del conocimiento (borrador v0 en la bitácora, no en el repo durante esta etapa).
- Lista de reglas P-n con criterio y fuente.
- Procedimiento de aplicación paso a paso con entregables (ADR, C4, matriz de riesgos, escenarios de calidad).
- v1 corregida tras los dos casos de uso, con registro de cambios en la bitácora (el documento final es no delta).

## 5. Criterios de validación

- Toda regla con fuente verificable (sección de la guía, ejemplo o referencia).
- Aplicado a N-06 y N-07 produce especificaciones completas sin consultar la guía (prueba de autocontención).
- Cada corrección surgida de un caso queda trazada caso→regla.
- Decisión sobre T3 documentada (forma elegida o ficha de excepción).

## 6. Dependencias

- Depende de N-03 (principios) y N-01 (evidencia sana); usa N-08.
- Ciclo con N-06 y N-07: v0 → aplicación → v1.
- La guía debe mencionarlo (hoy no lo hace; R1): enlace desde N-02.

## 7. Riesgos

- Duplicar la guía en vez de destilarla.
- Sobreajuste a los dos casos.
- Choque de normas de forma (T3).

## 8. Preguntas para la mesa

1. ¿Forma del Conocimiento MAUI o Rule-Forma-De-Conocimiento (§0–§10)?
2. ¿arc42 completo o subconjunto mínimo? (simplicidad pedida en el prompt).
3. ¿Cómo se prueba la efectividad: criterio de «especificación completa» y quién la juzga?
