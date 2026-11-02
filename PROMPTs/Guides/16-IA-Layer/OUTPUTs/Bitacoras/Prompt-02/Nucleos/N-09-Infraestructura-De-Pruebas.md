# N-09 · Infraestructura de pruebas contra modelos

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

Entorno para ejecutar ejemplos, demo y ensayos de los casos contra modelos reales. El prompt remite a las APIs de un gateway de IA compartido; R4 verificó que hoy no existe en la estación disponible y que lo usable es el Ollama propio de la guía.

## 2. Alcance

- Incluye: Ollama propio (API nativa y compatible OpenAI), modelos `qwen3.5:4b`, `qwen2.5:0.5b`, `qwen3-embedding:0.6b`; límites medidos (CPU, 1 pedido a la vez, 5 GiB, 4096 tokens efectivos).
- Incluye: uso del gestor de turnos para toda prueba.
- Incluye: defaults que apuntan al gateway muerto (`[gestor-de-turnos]` l. 47, `AIProviderFactory.cs:47`): pasar `OLLAMA_URL` explícito.
- Excluye: emuladores y KVM en la estación 2.

## 3. Entradas

- R4-Infra-Modelos (abstracto) y el informe privado.

## 4. Salidas esperadas

- Plan de mediciones pendientes: latencia y tool calling del 4b; acceso desde contenedores de la red de escenarios.
- Configuración documentada (sin hosts en lo público) para correr ejemplos.

## 5. Criterios de validación

- Toda medición con turno, comando y salida (E1).
- Ejemplos con herramientas corren contra un modelo que emite `tool_calls`.

## 6. Dependencias

- Soporte de N-01, N-06 y N-07.

## 7. Riesgos

- Capacidad limitada (CPU): pruebas lentas o imposibles con modelos mayores.
- La guía puede afirmar cosas del gateway compartido que hoy no se pueden verificar.

## 8. Preguntas para la mesa

1. ¿La guía sigue mencionando un gateway compartido o se limita al Ollama local?
2. ¿Se acepta el 4b como modelo de referencia si su latencia en CPU es alta?
