# N-07 · Caso de uso del servicio privado de notificaciones

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

Aplicación del conocimiento de especificación al diseño de una capa de IA en «un servicio privado de notificaciones», como segundo caso de prueba. Su detalle vive fuera de los repos públicos; en lo público sólo aparece en abstracto.

## 2. Alcance

- Incluye (en abstracto): redacción asistida con validación sin IA, consultas en lenguaje natural con herramientas tipadas de sólo lectura y sin SQL libre, diagnóstico de fallos de entrega, segmentación propuesta y confirmada por una persona, búsqueda asistida sobre la documentación.
- Riesgos del dominio: envío masivo irreversible (confirmación humana), aislamiento por aplicación en cada herramienta, datos personales.
- Incluye: expediente correlativo según la norma propia del repo, aviso antes de crearlo.
- Excluye: nombres, rutas, hosts, versiones o cifras del servicio en cualquier repo público.

## 3. Entradas

- R3-Caso-Privado (abstracto, en la bitácora) y el informe privado en `<privado>`.
- Conocimiento v0 (N-05).

## 4. Salidas esperadas

- Especificación privada en el repo del servicio, bajo su norma.
- Lista de correcciones al conocimiento, redactadas en abstracto para lo público.

## 5. Criterios de validación

- Ninguna mención identificable en LD/LDD (grep de nombres y rutas antes de cualquier PR).
- Herramientas especificadas respetan sólo lectura y aislamiento.
- Ciclo de PR propio del repo respetado si hay entrega.

## 6. Dependencias

- Depende de N-05 v0 y N-10; alimenta N-05 v1.
- No alimenta ejemplos públicos (decisión del prompt).

## 7. Riesgos

- Filtración de datos privados al material público.
- Norma propia distinta (`Prompts/` del PO): no confundir con IA.SDD.

## 8. Preguntas para la mesa

1. ¿Qué valor se especifica?
2. ¿Qué forma tiene el aporte abstracto que vuelve al Conocimiento sin revelar el caso?
