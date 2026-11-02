# N-06 · Caso de uso Geometría (público)

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

Aplicación del conocimiento de especificación al diseño de una capa de IA en Lab-Geometria, para probar su efectividad, corregirlo y, por ser público, enriquecer la guía y los ejemplos con lo desarrollado.

## 2. Alcance

- Incluye: especificación de los valores V1 (explicar observaciones con pistas sin corregir el JSON), V2 (borrador de comentario del docente en `ResolveWorkUseCase`), V3 (resumen de errores frecuentes), V4 (consultas sobre el formato), como puerto nuevo asíncrono separado de `IFigureValidator` (G-6 sincrónico sin red, G-7).
- Respeta exclusiones: X-4 (no corregir/editar el JSON), sin calificación con nota, la IA no genera `Describir()`.
- Incluye: expediente 0002 en `SDD/Expedientes/` (avisando antes), worktree `[ruta-trabajo]/g16-…`, rama `g16/<tema>`, carpeta `ai-layer`.
- Excluye: tocar el visor, el navegador, `PROMPTs/`, `_legacy/`, el intake, el despliegue del PO o la ia-db a mano.

## 3. Entradas

- R2-Geometria (arquitectura, superficie HTTP con A-18 `POST /v1/interpretaciones`, scripts, restricciones).
- Conocimiento v0 (N-05).

## 4. Salidas esperadas

- Especificación de la capa de IA de Geometría producida con el conocimiento.
- ADR nueva y elevación al PO sobre el intake (documento humano: se eleva, no se corrige).
- Lista de correcciones al conocimiento.
- Propuesta de capítulo/ejemplo para la guía basado en el caso.

## 5. Criterios de validación

- La especificación respeta G-6, G-7, X-4 y las demás exclusiones (revisión contra R2).
- Cada requisito tiene criterio de aceptación y prueba ejecutable con los scripts del repo (`build.sh` sin advertencias, `test.sh`, `pruebas-e2e.sh`).
- Diseño antes que código; cualquier código o PR, con aviso previo y ciclo de PR del repo.

## 6. Dependencias

- Depende de N-05 v0 y de N-09 (pruebas con modelo).
- Alimenta N-05 v1, N-02 (capítulo de caso) y N-01 (si nace un ejemplo nuevo).
- Gobernado por N-10 (expediente, ramas, aviso).

## 7. Riesgos

- Que el intake no contemple IA: requiere decisión del PO.
- Tentación pedagógica de que la IA resuelva por el alumno (contra la memoria «Describir() es didáctico»).
- Coordinación con DAC, que ensaya también en Geometría (carpetas separadas).

## 8. Preguntas para la mesa

1. ¿Qué valor (V1–V4) se especifica primero como caso piloto?
2. ¿Se implementa algo en esta pasada o sólo especificación?
3. ¿Cómo entra el caso a la guía: capítulo, ejemplo 18, o variante de la demo?
