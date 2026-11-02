# N-04 · Ronda de revisión tipo libro

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

Aplicación, sobre el libro unificado, de las seis intervenciones editoriales de la tabla del prompt: edición de contenido (ideas, estructura, argumentos), edición académica (rigor, fuentes, consistencia), corrección de estilo, corrección ortotipográfica, diseño editorial (presentación visual y diagramación) y corrección de pruebas (errores de la versión diagramada).

## 2. Alcance

- Incluye: orden de las intervenciones, responsable por intervención (rol de la mesa), lista de control y registro de hallazgos P0–P3.
- Incluye: validación de mermaid con `tools/medios/mermaid.sh` y convenciones de etiquetas acordadas («1 · Texto», sin URLs).
- Excluye: cambios de arquitectura (vuelven a N-02).

## 3. Entradas

- Prompt 02, tabla de intervenciones.
- Libro de N-02 ya integrado.
- R5-Marco (P0–P3, roles, cierre por criterio/por decisión).
- 00-Coordinacion (convenciones mermaid).

## 4. Salidas esperadas

- Informe por intervención con hallazgos y parches.
- Versión del libro lista para el PR de integración.
- Hoja de estilo (términos, mayúsculas, cifras, citas) reutilizable.

## 5. Criterios de validación

- Las seis intervenciones registradas con su informe.
- Mermaid: todos los diagramas renderizan (salida del validador).
- Enlaces internos y anclas sin rotos (verificación mecánica).
- Cifras de palabras/secciones declaradas coinciden con `contar.sh`.

## 6. Dependencias

- Depende de N-02 (y por él de N-01, N-03, N-06, N-08) terminados.
- Roles editoriales y académicos los compone N-10.

## 7. Riesgos

- Exceder el techo de cinco roles variables (T2 de R5): agrupar intervenciones.
- Ciclo de vuelta: un hallazgo de contenido reabre N-02.

## 8. Preguntas para la mesa

1. ¿Qué intervenciones se fusionan en un mismo rol para respetar el techo de cinco?
2. ¿La corrección de pruebas se hace sobre el render de GitHub o sobre otra salida diagramada?
3. ¿Qué hallazgo bloquea la publicación (umbral P0/P1)?
