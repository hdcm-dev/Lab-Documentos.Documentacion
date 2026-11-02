# E4 · Checklist binario de completitud de una especificación de capa de IA

> Versión tachable del §11 de `E4-Conocimiento-v0.md` (D-23 c). Se copia una vez por especificación y por
> revisor: un agente sin la guía y un humano de la mesa. Fecha de la plantilla: 2026-11-01.

## Índice

- [1. Cómo se usa](#1-cómo-se-usa)
- [2. Datos de la revisión](#2-datos-de-la-revisión)
- [3. Ítems](#3-ítems)
- [4. Veredicto](#4-veredicto)

## 1. Cómo se usa

1. Se elige la columna según el contexto del proyecto: PROTO (CTX-PROTO) o PROD (CTX-PROD).
2. Cada ítem tiene exactamente un resultado: **SÍ** con la fuente dentro de la especificación (sección o
   archivo), o **NO APLICA** con motivo, o **NO**.
3. Un ítem DEBE con **NO** hace la especificación incompleta. Un ítem DEBERÍA con **NO** exige motivo escrito.
   PUEDE no cuenta.
4. **Completa** = 100 % de los DEBE en **SÍ** o **NO APLICA** con motivo.

## 2. Datos de la revisión

| Campo | Valor |
|---|---|
| Especificación revisada | |
| Contexto (PROTO / PROD) | |
| Revisor (agente sin guía / humano de la mesa) | |
| Fecha | |
| Salida de `E4-verificar-requisitos.py` (rc) | |

## 3. Ítems

| # | Ítem | PROTO | PROD | Resultado | Fuente o motivo |
|---|---|---|---|---|---|
| C-01 | Las cuatro preguntas de §1 tienen respuesta escrita | DEBE | DEBE | | |
| C-02 | El resultado del árbol está registrado; si es «no», hay ADR «sin IA» | DEBE | DEBE | | |
| C-03 | ESC-, CTX- y ACT- fijados | DEBE | DEBE | | |
| C-04 | Cada capacidad tiene escalón de conocimiento y nivel de agencia con criterio de salto | DEBE | DEBE | | |
| C-05 | C4 de contexto y de contenedores en mermaid, validados | DEBERÍA | DEBE | | |
| C-06 | Ninguna flecha del C4 va del modelo al dominio ni a los datos | DEBE | DEBE | | |
| C-07 | Una ficha A.4 por capacidad con prompt propio | DEBE | DEBE | | |
| C-08 | ADR-01, ADR-02 y ADR-11, con «ASR que lo origina» | DEBE | DEBE | | |
| C-09 | ADR-06 y ADR-07 si algún nivel es A1 o más | DEBE | DEBE | | |
| C-10 | Todo `REQ-IA-nn` con criterio y prueba (script con salida 0) | DEBE | DEBE | | |
| C-11 | Cada requisito dice si su prueba es garantía del código o conducta del modelo | DEBERÍA | DEBE | | |
| C-12 | Matriz OWASP con las filas activadas por el nivel de agencia y su ficha | DEBERÍA | DEBE | | |
| C-13 | Qué datos salen hacia qué servidor de modelos, decidido por ACT-SEC | DEBE | DEBE | | |
| C-14 | Ningún valor de infraestructura ni secreto en el repositorio | DEBE | DEBE | | |
| C-15 | Si hay MCP, quién consume, en qué dirección y con qué control | DEBE | DEBE | | |
| C-16 | Si hay clientes, la frontera citada del libro MAUI | PUEDE | DEBERÍA | | |
| C-17 | Métrica, umbral y error caro del escenario, con quien fija el umbral | DEBE | DEBE | | |

## 4. Veredicto

| Conteo | Valor |
|---|---|
| DEBE en SÍ | |
| DEBE en NO APLICA con motivo | |
| DEBE en NO | |
| DEBERÍA en NO, con motivo | |
| **Completa (sí/no)** | |
