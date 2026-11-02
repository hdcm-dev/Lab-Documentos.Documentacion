# N-02 · Libro unificado y arquitectura editorial

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

Estructura del documento único `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Dot-Net-Integration-AI-Layer-Guide.md` según la regla del prompt: secciones jerárquicas, definiciones, explicaciones, ejemplos, mermaid cuando haga falta, autocontenido, **no delta**, con índice; y según el perfil Study-Guide (escenarios, contextos y actores primero; por tema: definición, aplicación por escenario, ejemplos, preguntas guía, criterios de calidad, anexo con plantilla).

## 2. Alcance

- Incluye: plan de partes/capítulos, índice, glosario único, referencias con fecha de consulta al final (coherencia entre libros acordada con FC en 00-Coordinacion).
- Incluye: eliminar lo delta (62 bloques «Historia (hasta el 2026-10-28)», nombres «históricos», «era ApiWeb») y trasladar la procedencia a un anexo o a la bitácora.
- Incluye: deduplicar (definiciones en tres niveles §3.0/§4.1/Anexo C; mapa de ejemplos en cuatro lugares; ADR repetidas en cada sección, §13 y A.13).
- Incluye: presupuesto de extensión (hoy 130 %, Anexos 170 %).
- Excluye: el contenido de la sección de fundamentos (N-03) y la ronda de revisión (N-04).

## 3. Entradas

- R1-Guia (estructura, repeticiones, extensión, faltantes).
- R5-Marco §Perfil Study-Guide y §Libro MAUI.
- Perfil `Study-Guide-Documentation.md` y `RuleSet-Study-Guide.md`.
- `Concepts/Framework-Concept/MAUI-Framework-Developer-Guide.md` como referencia de forma (sólo lectura).

## 4. Salidas esperadas

- Esqueleto del libro (índice objetivo) con trazabilidad sección vieja → sección nueva.
- Política de procedencia (dónde va la historia) y de unicidad (cada concepto definido en un solo lugar).
- Presupuesto de palabras por parte, con criterio de qué se recorta.

## 5. Criterios de validación

- Todo encabezado de la 0.11.0 tiene destino (mapa sin huérfanos).
- Ningún bloque «Historia» ni referencia a versiones previas en el cuerpo (grep).
- Cada término del glosario se define una sola vez; las demás apariciones enlazan.
- Cumple las 9 reglas del RuleSet Study-Guide (lista de control).
- Extensión dentro del presupuesto acordado por la mesa.

## 6. Dependencias

- Recibe de N-01 el texto corregido, de N-03 la Parte inicial, de N-08 las referencias, de N-06 el capítulo de caso aplicado.
- Precede a N-04 (no se revisa como libro algo sin arquitectura final).

## 7. Riesgos

- Sumar fundamentos y caso Geometría sin recortar agrava el exceso (R1 §Extensión).
- Perder trazabilidad al quitar la historia (mitigación: anexo de procedencia o bitácora).
- Divergencia de forma con el libro MAUI (T3 de R5).

## 8. Preguntas para la mesa

1. ¿La procedencia histórica va a un anexo del libro o sale del libro a la bitácora?
2. ¿Se mantiene el patrón «En este laboratorio / Práctica / Qué decisión toca» o se adopta el patrón del perfil Study-Guide?
3. ¿Las Prácticas largas (§5 ~300 líneas, §8 ~380) pasan a los README de cada ejemplo?
4. ¿Qué tope de extensión rige y quién lo fija?
