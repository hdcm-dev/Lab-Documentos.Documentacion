# N-01 · Coherencia texto ↔ ejemplos y demo

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

Correspondencia verificable entre lo que la guía afirma y lo que hacen `Examples/01…17`, `Demos/MovilidadUrbana.Asistente`, `_Comun/`, los oráculos `.jq` y las compuertas de `tools/`. Es la solicitud 1 del prompt («coherente y congruente con las ejemplificaciones»).

## 2. Alcance

- Incluye: las incoherencias I-1…I-7 de R1 (cifras de §0.5, `comparar-bloques.py` inexistente, vocabulario «propio/compartido» vs «servidor de chat/segundo servidor», `SalidaEstructurada.csproj`, ubicación de `IChatClient` bajo `Application/` frente a ADR-01, nombre de la Parte II, excepción al invariante de §3.1 recién en §14.2).
- Incluye: la tabla E.1 (17 carpetas 1:1) y los PD-1…PD-6 de la demo.
- Incluye: modelos citados por la guía frente a los realmente servidos (`qwen2.5:0.5b` aparece 22 veces; R4 mide que el 0.5b no emite `tool_calls`).
- Excluye: reescritura editorial (N-02/N-04) y contenido nuevo de casos (N-06).

## 3. Entradas

- R1-Guia §Incoherencias, §Ejemplos y demo.
- R4-Infra-Modelos (modelos disponibles y medición de tool calling).
- Repo de la guía: `Examples/`, `Demos/`, `tools/` (compuertas y `contar.sh`).

## 4. Salidas esperadas

- Matriz afirmación↔artefacto (sección de la guía, archivo, comando que lo prueba, resultado).
- Lista de correcciones clasificadas: «corrige texto» / «corrige ejemplo» / «declara divergencia».
- Decisión explícita sobre I-5 (mantener la excepción declarada en E.1 o mover a `Infrastructure/`).

## 5. Criterios de validación

- Cada fila de la matriz con evidencia E1 (comando y salida) o E2 (cita literal con línea).
- Compuertas de `tools/` en verde tras las correcciones; `contar.sh` coincide con la cifra publicada.
- Cero referencias a archivos inexistentes (grep de nombres de archivo citados vs `find`).

## 6. Dependencias

- Usa N-09 para re-ejecutar ejemplos contra un modelo real.
- Alimenta N-02 (qué texto queda) y N-05 (la evidencia del Conocimiento sale de ejemplos verificados).
- Lo gobierna N-10 (turnos, no tocar rutas ajenas).

## 7. Riesgos

- Corregir ejemplos implica editar código: en esta etapa sólo se planifica.
- Re-ejecutar contra el 4b puede no ser posible (CPU, 5 GiB, 4096 tokens efectivos; R4).
- I-5 es una decisión de arquitectura, no un error tipográfico: requiere ADR.

## 8. Preguntas para la mesa

1. ¿I-5 se resuelve moviendo código o reafirmando la excepción didáctica en el texto principal (no sólo en E.1)?
2. ¿Qué modelo pasa a ser el de referencia de los ejemplos con herramientas, si el 0.5b no las soporta?
3. ¿La matriz afirmación↔artefacto se publica como anexo o queda en la bitácora?
