# N-03 · Sección inicial de fundamentos

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

Capítulo inicial que explica los fundamentos sobre los que se basó el framework, pedido explícito del prompt («Es importante que tenga una sección inicial que explique estos fundamentos»). Hoy no existe: los principios están dispersos en §1, §3 (doce términos, capas, «dos escaleras»), §4.1–§4.2 y ADR-08 (la salida del modelo es una propuesta).

## 2. Alcance

- Incluye: inventario de principios ya presentes en la guía, consolidados con su fuente interna (sección/ADR) y externa (Anexo D).
- Incluye: renombrar o redefinir la Parte II «Fundamentos» (I-6) para evitar dos «fundamentos».
- Incluye: marco de escenarios, contextos y actores (perfil Study-Guide, T7 de R5) si es fundamento.
- Excluye: principios nuevos sin evidencia (regla «no inventar»).

## 3. Entradas

- R1-Guia §Conceptos, §Faltantes.
- Guía 0.11.0: §1, §3.0–§3.2, §4.1–§4.2, §13.9 (ADR-08), Anexo C.
- R6-Industria (regla de Agent Framework «si alcanza una función, no usar un agente»; OWASP; NIST).

## 4. Salidas esperadas

- Lista cerrada de principios P-n, cada uno con enunciado, razón y fuente.
- Diagrama mermaid de relación entre principios, capas y escaleras.
- Propuesta de ubicación (Parte 0 o Parte I) y de qué se quita de §3/§4 para no duplicar.

## 5. Criterios de validación

- Cada principio rastreable a una sección de la 0.11.0 o a una referencia del Anexo D/R6 (E2).
- Ningún principio aparece definido en dos lugares tras la integración.
- Un lector sin contexto (rol de la mesa) puede enunciar los principios tras leer sólo esa sección.

## 6. Dependencias

- Base conceptual de N-05 (el Conocimiento deriva sus reglas de estos principios).
- Se ubica dentro de la arquitectura de N-02.
- Toma referencias de N-08.

## 7. Riesgos

- Inflar el capítulo con resúmenes de toda la guía.
- Confundir fundamentos del framework con fundamentos de la tecnología (Microsoft.Extensions.AI), que es lo que hoy titula la Parte II.

## 8. Preguntas para la mesa

1. ¿Qué es «fundamento» y qué es «arquitectura»? ¿Dónde está la frontera?
2. ¿Los principios del libro y los P-n del Conocimiento (N-05) son la misma lista?
3. ¿La regla de Agent Framework entra como principio o como criterio de decisión?
