# E2 · Anclas de la 0.11.0 → libro nuevo

**Etapa:** E2 · **Fecha:** 2026-11-01 · **Dueño:** P-06 Doc. técnica (U-2.1) · **Fuente:** guía 0.11.0, sha256 `c8defd8324497c4279a3dfd57ce5d2757326ad966813a9f9797d0196d9b7ce3d`.

## Índice

1. [Regla](#1-regla)
2. [Cómo se generó y se comprueba](#2-cómo-se-generó-y-se-comprueba)
3. [Resumen](#3-resumen)
4. [Tabla completa](#4-tabla-completa)

## 1. Regla

- Cada ancla de la 0.11.0 queda en el libro nuevo como **alias** (`<a id="sN-k"></a>` junto al encabezado de destino) o se **conserva** tal cual (`oa-*`, `anexo-*`, `cierre`). Ningún enlace que apunte a la 0.11.0 se rompe (U-2.1).
- Capítulo nuevo = capítulo viejo + 1 (Fundamentos es el 1), salvo el Prólogo (§0 → 0) y la Autoevaluación (§15 → 17, porque el 16 es el caso aplicado).
- Varios alias pueden caer en el mismo destino (p. ej. `s3-0` y `s4-1` en `anexo-c`).
- E3 aplica la tabla; E10 comprueba que cada destino existe en el libro y que cada enlace interno resuelve.

## 2. Cómo se generó y se comprueba

`python3 -I Evidencia/anclas.py` sobre una copia de la guía en el área de trabajo: extrae todo `<a id="…">` (283), aplica la regla y comprueba que no hay ids repetidos ni choques entre un destino nuevo y un ancla vieja con otro sentido. Salida: `283 filas; 283 únicas; choques []`. Tabla: `Evidencia/anclas-tabla.md`, sha256 `3adf21fc505b8dee6459f021455e6305bbc67d532839be342882716499f893e2`.

## 3. Resumen

| Tratamiento | Cantidad |
|---|---|
| Alias (199 `s…` y 7 `parte-…`) a capítulo, sección, paso del patrón, glosario o Prólogo | 206 |
| Se conserva (27 `oa-*`, 49 `anexo-*`, `cierre`) | 77 |
| **Total con destino** | **283 / 283** |

## 4. Tabla completa

Columnas: número, ancla de la 0.11.0, línea en la 0.11.0, encabezado o fila que sigue al ancla, ancla de destino y tratamiento.

| # | Ancla 0.11.0 | Línea | Encabezado o fila | Ancla nueva | Tratamiento |
|---|---|---|---|---|---|
| 1 | `parte-0` | 22 | # Parte 0 · Cómo usar esta guía | `prologo` | alias |
| 2 | `s0` | 25 | ## §0 Cómo usar esta guía | `c0` | alias |
| 3 | `s0-0` | 30 | ### §0.0 Tabla de contenido | `c0-0` | alias |
| 4 | `s0-1` | 80 | ### §0.1 Qué vas a poder hacer al terminar | `c0-1` | alias |
| 5 | `oa-0-1` | 87 | / OA-0.1 / Dado un pedido sobre Movilidad Urbana, responder las cuatro | `oa-0-1` | se conserva |
| 6 | `oa-0-2` | 88 | / OA-0.2 / Ubicar cada pieza de la diapositiva de [§1](#s1) en Present | `oa-0-2` | se conserva |
| 7 | `oa-0-3` | 89 | / OA-0.3 / Ubicar un caso en las dos escaleras y nombrar el escalón má | `oa-0-3` | se conserva |
| 8 | `oa-d1` | 90 | / OA-D1 / Consumir un modelo con `IChatClient` y cambiar de adaptador  | `oa-d1` | se conserva |
| 9 | `oa-d2` | 91 | / OA-D2 / Obtener salida estructurada con `TryGetResult`, con campos a | `oa-d2` | se conserva |
| 10 | `oa-d3` | 92 | / OA-D3 / Elegir entre contexto fijo, contexto completo con prefijo es | `oa-d3` | se conserva |
| 11 | `oa-d4` | 93 | / OA-D4 / Armar un RAG con citas validadas en código y medir el hit ra | `oa-d4` | se conserva |
| 12 | `oa-d5` | 94 | / OA-D5 / Exponer un caso de uso como herramienta, con pruebas negativ | `oa-d5` | se conserva |
| 13 | `oa-d6` | 95 | / OA-D6 / Elegir entre función, llamada con herramientas, workflow y a | `oa-d6` | se conserva |
| 14 | `oa-d7` | 96 | / OA-D7 / Decidir si una tarea necesita uno o varios agentes y medir e | `oa-d7` | se conserva |
| 15 | `oa-d8` | 97 | / OA-D8 / Exponer lecturas por MCP en loopback y consumir herramientas | `oa-d8` | se conserva |
| 16 | `oa-d9` | 98 | / OA-D9 / Escribir pruebas de cableado con un cliente guionado, separa | `oa-d9` | se conserva |
| 17 | `oa-a1` | 99 | / OA-A1 / Registrar una decisión de la capa como ADR con alternativas, | `oa-a1` | se conserva |
| 18 | `oa-a2` | 100 | / OA-A2 / Fijar para un escenario la métrica, los tipos de error, el u | `oa-a2` | se conserva |
| 19 | `oa-a3` | 101 | / OA-A3 / Elegir estrategia de conocimiento y almacén según tamaño, fr | `oa-a3` | se conserva |
| 20 | `oa-a4` | 102 | / OA-A4 / Elegir marco (M.E.AI, MAF, SK sólo como migración) y explica | `oa-a4` | se conserva |
| 21 | `oa-a5` | 103 | / OA-A5 / Decidir, para una capacidad, si el contrato es un puerto pro | `oa-a5` | se conserva |
| 22 | `oa-a6` | 104 | / OA-A6 / Dado un cambio de la capa de IA sobre una aplicación existen | `oa-a6` | se conserva |
| 23 | `oa-o1` | 105 | / OA-O1 / Configurar `UseOpenTelemetry` y comprobar con un exportador  | `oa-o1` | se conserva |
| 24 | `oa-o2` | 106 | / OA-O2 / Configurar endpoint, modelo y `num_ctx` por variable, sin ni | `oa-o2` | se conserva |
| 25 | `oa-o3` | 107 | / OA-O3 / Leer un puntaje de LLM juez: decir si está calibrado y qué s | `oa-o3` | se conserva |
| 26 | `oa-o4` | 108 | / OA-O4 / Elegir entre modelo local, un servidor que comparten varias  | `oa-o4` | se conserva |
| 27 | `oa-s1` | 109 | / OA-S1 / Para un escenario, nombrar los riesgos OWASP que aplican y s | `oa-s1` | se conserva |
| 28 | `oa-s2` | 110 | / OA-S2 / Decidir qué herramientas piden aprobación, cuáles no se mont | `oa-s2` | se conserva |
| 29 | `oa-s3` | 111 | / OA-S3 / Aplicar el filtro por permiso en la recuperación y no despué | `oa-s3` | se conserva |
| 30 | `oa-s4` | 112 | / OA-S4 / Armar el pedido de aprobación con los argumentos que resolvi | `oa-s4` | se conserva |
| 31 | `oa-sk1` | 113 | / OA-SK1 / Pasar una herramienta `[KernelFunction]` a `[Description]`  | `oa-sk1` | se conserva |
| 32 | `s0-2` | 119 | ### §0.2 Rutas de lectura | `c0-2` | alias |
| 33 | `s0-3` | 134 | ### §0.3 Qué necesitás | `c0-3` | alias |
| 34 | `s0-4` | 143 | ### §0.4 Cómo leer cada sección y la evidencia | `c0-4` | alias |
| 35 | `s0-5` | 174 | ### §0.5 Dónde está el mapa de los ejemplos y la demo | `c0-5` | alias; remite a anexo-e-1 (C-2.7) |
| 36 | `parte-i` | 181 | # Parte I · Marco | `parte-2` | alias |
| 37 | `s1` | 184 | ## §1 «IA ya es parte del stack»: de la diapositiva a una solución | `c2` | alias |
| 38 | `s2` | 261 | ## §2 Marco de referencia: escenarios, contextos y actores | `c3` | alias |
| 39 | `s2-1` | 268 | ### §2.1 Escenarios | `c3-1` | alias |
| 40 | `s2-2` | 283 | ### §2.2 Contextos de uso | `c3-2` | alias |
| 41 | `s2-3` | 315 | ### §2.3 Actores | `c3-3` | alias |
| 42 | `s2-4` | 332 | ### §2.4 ¿Vale la pena? Valor, error y éxito | `c3-4` | alias |
| 43 | `s2-5` | 352 | ### §2.5 Diseñar para respuestas que pueden estar mal | `c3-5` | alias |
| 44 | `s2-preguntas` | 370 | ### Preguntas guía de §2 | `c3-preguntas` | alias; paso del patrón (D-09 a) |
| 45 | `s3` | 387 | ## §3 Marco conceptual y mapa: «estoy acá → qué aplico» | `c4` | alias |
| 46 | `s3-0` | 394 | ### §3.0 Doce términos en una línea | `anexo-c` | alias; definiciones fusionadas en el glosario (C-2.3) |
| 47 | `s3-1` | 412 | ### §3.1 Las capas | `c4-1` | alias |
| 48 | `s3-2` | 436 | ### §3.2 Las dos escaleras | `c4-2` | alias |
| 49 | `s3-3` | 486 | ### §3.3 Tabla por escenario y cobertura | `c4-3` | alias |
| 50 | `s3-4` | 542 | ### §3.4 Tabla por artefacto | `c4-4` | alias |
| 51 | `s3-5` | 561 | ### §3.5 Mapa de la demo | `c4-5` | alias |
| 52 | `s3-preguntas` | 586 | ### Preguntas guía de §3 | `c4-preguntas` | alias; paso del patrón (D-09 a) |
| 53 | `parte-ii` | 601 | # Parte II · Fundamentos | `parte-3` | alias |
| 54 | `s4` | 604 | ## §4 La capa de IA en la arquitectura de la aplicación | `c5` | alias |
| 55 | `s4-1` | 611 | ### §4.1 Vocabulario | `anexo-c` | alias; definiciones fusionadas en el glosario (C-2.3) |
| 56 | `s4-2` | 629 | ### §4.2 Por qué ahora: de la arquitectura al componente con contrato | `c5-2` | alias |
| 57 | `s4-3` | 663 | ### §4.3 Dónde vive la capa | `c5-3` | alias |
| 58 | `s4-4` | 714 | ### §4.4 Dos contratos: el puerto propio y el `IChatClient` | `c5-4` | alias |
| 59 | `s4-5` | 802 | ### §4.5 Antipatrones de ubicación | `c5-5` | alias |
| 60 | `s4-practica` | 815 | ### Práctica de §4 | `c5-escenarios` | alias; el rótulo «Práctica» desaparece (D-09 a) |
| 61 | `s4-escenarios` | 818 | #### Aplicación por escenario de §4 | `c5-escenarios` | alias; paso del patrón (D-09 a) |
| 62 | `s4-ejemplos` | 828 | #### Ejemplos de §4 | `c5-ejemplos` | alias; paso del patrón (D-09 a) |
| 63 | `s4-preguntas` | 840 | #### Preguntas guía de §4 | `c5-preguntas` | alias; paso del patrón (D-09 a) |
| 64 | `s4-calidad` | 862 | #### Criterios de calidad y antipatrones de §4 | `c5-calidad` | alias; paso del patrón (D-09 a) |
| 65 | `s4-6` | 869 | ### §4.6 Decisión en curso: ADR-01 | `c5-decision` | alias; paso «Decisión» del patrón (D-09 a) |
| 66 | `s5` | 874 | ## §5 Hablar con un modelo desde .NET: Microsoft.Extensions.AI y prove | `c6` | alias |
| 67 | `s5-1` | 881 | ### §5.1 `IChatClient`, `ChatMessage` y `ChatOptions` | `c6-1` | alias |
| 68 | `s5-2` | 890 | ### §5.2 Historial y streaming | `c6-2` | alias |
| 69 | `s5-3` | 899 | ### §5.3 Salida estructurada y campos anulables | `c6-3` | alias |
| 70 | `s5-4` | 908 | ### §5.4 El pipeline y las opciones del proveedor en una sola capa | `c6-4` | alias |
| 71 | `s5-5` | 974 | ### §5.5 Registro en DI y variables | `c6-5` | alias |
| 72 | `s5-6` | 1007 | ### §5.6 Cambiar de adaptador no es cambiar de proveedor | `c6-6` | alias |
| 73 | `s5-7` | 1026 | ### §5.7 En este laboratorio | `c6-7` | alias |
| 74 | `s5-practica` | 1037 | ### Práctica de §5 | `c6-escenarios` | alias; el rótulo «Práctica» desaparece (D-09 a) |
| 75 | `s5-escenarios` | 1040 | #### Aplicación por escenario de §5 | `c6-escenarios` | alias; paso del patrón (D-09 a) |
| 76 | `s5-ejemplos` | 1049 | #### Ejemplos de §5 | `c6-ejemplos` | alias; prácticas al README, quedan objetivo, comando, salida y enlace (D-11 d) |
| 77 | `s5-preguntas` | 1312 | #### Preguntas guía de §5 | `c6-preguntas` | alias; paso del patrón (D-09 a) |
| 78 | `s5-calidad` | 1334 | #### Criterios de calidad y antipatrones de §5 | `c6-calidad` | alias; paso del patrón (D-09 a) |
| 79 | `s5-8` | 1343 | ### §5.8 Decisión en curso: ADR-02 | `c6-decision` | alias; paso «Decisión» del patrón (D-09 a) |
| 80 | `parte-iii` | 1348 | # Parte III · Conocimiento: ¿qué sabe el modelo? | `parte-4` | alias |
| 81 | `s6` | 1351 | ## §6 Estrategias de conocimiento: de contexto fijo a RAG agéntico | `c7` | alias |
| 82 | `s6-1` | 1358 | ### §6.1 El carril aparte: un dato exacto se consulta | `c7-1` | alias |
| 83 | `s6-2` | 1387 | ### §6.2 Escalón 0: contexto fijo | `c7-2` | alias |
| 84 | `s6-3` | 1415 | ### §6.3 Escalón 1: contexto completo con prefijo estable | `c7-3` | alias |
| 85 | `s6-4` | 1438 | ### §6.4 Tres cachés y un «sin caché» | `c7-4` | alias |
| 86 | `s6-5` | 1450 | ### §6.5 Ventana declarada, efectiva y configurada | `c7-5` | alias |
| 87 | `s6-6` | 1459 | ### §6.6 Escalones 2 y 3: cuándo saltar a RAG y a RAG agéntico | `c7-6` | alias |
| 88 | `s6-practica` | 1468 | ### Práctica de §6 | `c7-escenarios` | alias; el rótulo «Práctica» desaparece (D-09 a) |
| 89 | `s6-escenarios` | 1471 | #### Aplicación por escenario de §6 | `c7-escenarios` | alias; paso del patrón (D-09 a) |
| 90 | `s6-ejemplos` | 1483 | #### Ejemplos de §6 | `c7-ejemplos` | alias; paso del patrón (D-09 a) |
| 91 | `s6-preguntas` | 1569 | #### Preguntas guía de §6 | `c7-preguntas` | alias; paso del patrón (D-09 a) |
| 92 | `s6-calidad` | 1591 | #### Criterios de calidad y antipatrones de §6 | `c7-calidad` | alias; paso del patrón (D-09 a) |
| 93 | `s6-7` | 1599 | ### §6.7 Qué decisión toca: ADR-04 | `c7-decision` | alias; paso «Decisión» del patrón (D-09 a) |
| 94 | `s7` | 1604 | ## §7 RAG en .NET: embeddings, ingesta, almacén vectorial y recuperaci | `c8` | alias |
| 95 | `s7-1` | 1634 | ### §7.1 Embedding y modelo de embeddings | `c8-1` | alias |
| 96 | `s7-2` | 1659 | ### §7.2 Ingesta y fragmentación | `c8-2` | alias |
| 97 | `s7-3` | 1668 | ### §7.3 `VectorStore`, colecciones y atributos | `c8-3` | alias |
| 98 | `s7-4` | 1692 | ### §7.4 Consulta, filtros, contexto y citas | `c8-4` | alias |
| 99 | `s7-5` | 1701 | ### §7.5 Medir la recuperación antes que la respuesta | `c8-5` | alias |
| 100 | `s7-6` | 1710 | ### §7.6 Riesgos de la recuperación | `c8-6` | alias |
| 101 | `s7-7` | 1720 | ### §7.7 Preparar los datos propios | `c8-7` | alias |
| 102 | `s7-practica` | 1729 | ### Práctica de §7 | `c8-escenarios` | alias; el rótulo «Práctica» desaparece (D-09 a) |
| 103 | `s7-escenarios` | 1732 | #### Aplicación por escenario de §7 | `c8-escenarios` | alias; paso del patrón (D-09 a) |
| 104 | `s7-ejemplos` | 1741 | #### Ejemplos de §7 | `c8-ejemplos` | alias; prácticas al README, quedan objetivo, comando, salida y enlace (D-11 d) |
| 105 | `s7-preguntas` | 1915 | #### Preguntas guía de §7 | `c8-preguntas` | alias; paso del patrón (D-09 a) |
| 106 | `s7-calidad` | 1939 | #### Criterios de calidad y antipatrones de §7 | `c8-calidad` | alias; paso del patrón (D-09 a) |
| 107 | `s7-8` | 1948 | ### §7.8 Qué decisión toca: ADR-04 y ADR-05 | `c8-decision` | alias; paso «Decisión» del patrón (D-09 a) |
| 108 | `parte-iv` | 1953 | # Parte IV · Agencia: ¿qué puede hacer el modelo? | `parte-5` | alias |
| 109 | `s8` | 1956 | ## §8 Herramientas, agentes y orquestación | `c9` | alias |
| 110 | `s8-1` | 1963 | ### §8.1 La escalera de agencia y el criterio de salto | `c9-1` | alias |
| 111 | `s8-2` | 1976 | ### §8.2 Llamada con herramientas | `c9-2` | alias |
| 112 | `s8-3` | 2010 | ### §8.3 Primer ejercicio: sólo lectura, negativas y sesión | `c9-3` | alias |
| 113 | `s8-4` | 2021 | ### §8.4 Caso de uso como herramienta | `c9-4` | alias |
| 114 | `s8-5` | 2030 | ### §8.5 Aprobación humana desde el escalón 1 | `c9-5` | alias |
| 115 | `s8-6` | 2072 | ### §8.6 Workflows | `c9-6` | alias |
| 116 | `s8-7` | 2095 | ### §8.7 Agentes de MAF y el escalón 3 | `c9-7` | alias |
| 117 | `s8-8` | 2120 | ### §8.8 ¿Uno o varios agentes? | `c9-8` | alias |
| 118 | `s8-9` | 2127 | ### §8.9 MCP: exponer y consumir herramientas | `c9-9` | alias |
| 119 | `s8-practica` | 2155 | ### Práctica de §8 | `c9-escenarios` | alias; el rótulo «Práctica» desaparece (D-09 a) |
| 120 | `s8-escenarios` | 2158 | #### Aplicación por escenario de §8 | `c9-escenarios` | alias; paso del patrón (D-09 a) |
| 121 | `s8-ejemplos` | 2167 | #### Ejemplos de §8 | `c9-ejemplos` | alias; prácticas al README, quedan objetivo, comando, salida y enlace (D-11 d) |
| 122 | `s8-preguntas` | 2509 | #### Preguntas guía de §8 | `c9-preguntas` | alias; paso del patrón (D-09 a) |
| 123 | `s8-calidad` | 2531 | #### Criterios de calidad y antipatrones de §8 | `c9-calidad` | alias; paso del patrón (D-09 a) |
| 124 | `s8-10` | 2540 | ### §8.10 Qué decisión toca: ADR-06, ADR-07 y ADR-12 | `c9-decision` | alias; paso «Decisión» del patrón (D-09 a) |
| 125 | `s9` | 2545 | ## §9 Métodos y marcos comparados | `c10` | alias |
| 126 | `s9-1` | 2552 | ### §9.1 Cuadro comparativo | `c10-1` | alias |
| 127 | `s9-2` | 2567 | ### §9.2 Ecosistemas | `c10-2` | alias |
| 128 | `s9-3` | 2604 | ### §9.3 Formas de construir y familias de anotaciones | `c10-3` | alias |
| 129 | `s9-4` | 2620 | ### §9.4 LangGraph en .NET | `c10-4` | alias |
| 130 | `s9-5` | 2641 | ### §9.5 Aclaración de nombres | `c10-5` | alias |
| 131 | `s9-6` | 2653 | ### §9.6 ¿Integrar un marco de agentes o construir uno propio? | `c10-6` | alias |
| 132 | `s9-7` | 2670 | ### §9.7 Si venís de Semantic Kernel | `c10-7` | alias |
| 133 | `s9-8` | 2747 | ### §9.8 La fecha de un tutorial es un dato técnico | `c10-8` | alias |
| 134 | `s9-criterio` | 2759 | ### Criterio de elección | `c10-decision` | alias; paso «Decisión» del patrón (D-09 a) |
| 135 | `s9-preguntas` | 2773 | ### Preguntas guía de §9 | `c10-preguntas` | alias; paso del patrón (D-09 a) |
| 136 | `parte-v` | 2795 | # Parte V · Producción | `parte-6` | alias |
| 137 | `s10` | 2798 | ## §10 Probar y evaluar una capa de IA | `c11` | alias |
| 138 | `s10-1` | 2805 | ### §10.1 Qué puede y qué no puede afirmar una prueba sobre un sistema | `c11-1` | alias |
| 139 | `s10-2` | 2820 | ### §10.2 Doble de `IChatClient` | `c11-2` | alias |
| 140 | `s10-3` | 2852 | ### §10.3 Contrato de la salida estructurada | `c11-3` | alias |
| 141 | `s10-4` | 2882 | ### §10.4 Corridas contra el modelo | `c11-4` | alias |
| 142 | `s10-5` | 2935 | ### §10.5 `Microsoft.Extensions.AI.Evaluation` | `c11-5` | alias |
| 143 | `s10-6` | 2963 | ### §10.6 El LLM juez y sus sesgos | `c11-6` | alias |
| 144 | `s10-7` | 2976 | ### §10.7 Conjunto de oro | `c11-7` | alias |
| 145 | `s10-practica` | 2997 | ### Práctica de §10 | `c11-escenarios` | alias; el rótulo «Práctica» desaparece (D-09 a) |
| 146 | `s10-escenarios` | 3000 | #### Aplicación por escenario de §10 | `c11-escenarios` | alias; paso del patrón (D-09 a) |
| 147 | `s10-ejemplos` | 3010 | #### Ejemplos de §10 | `c11-ejemplos` | alias; paso del patrón (D-09 a) |
| 148 | `s10-preguntas` | 3074 | #### Preguntas guía de §10 | `c11-preguntas` | alias; paso del patrón (D-09 a) |
| 149 | `s10-calidad` | 3096 | #### Criterios de calidad y antipatrones de §10 | `c11-calidad` | alias; paso del patrón (D-09 a) |
| 150 | `s10-8` | 3105 | ### §10.8 Qué decisión toca: ADR-10 | `c11-decision` | alias; paso «Decisión» del patrón (D-09 a) |
| 151 | `s11` | 3110 | ## §11 Asegurar la capa de IA | `c12` | alias |
| 152 | `s11-1` | 3117 | ### §11.1 Mapa de riesgos por escenario | `c12-1` | alias |
| 153 | `s11-2` | 3167 | ### §11.2 Inyección directa e indirecta | `c12-2` | alias |
| 154 | `s11-3` | 3180 | ### §11.3 Agencia excesiva | `c12-3` | alias |
| 155 | `s11-4` | 3192 | ### §11.4 Datos personales | `c12-4` | alias |
| 156 | `s11-5` | 3220 | ### §11.5 Exponer por MCP | `c12-5` | alias |
| 157 | `s11-6` | 3229 | ### §11.6 Secretos y repositorios públicos | `c12-6` | alias |
| 158 | `s11-7` | 3240 | ### §11.7 Escenario construido: una localidad con instrucciones en el  | `c12-7` | alias |
| 159 | `s11-practica` | 3251 | ### Práctica de §11 | `c12-escenarios` | alias; el rótulo «Práctica» desaparece (D-09 a) |
| 160 | `s11-escenarios` | 3254 | #### Aplicación por escenario de §11 | `c12-escenarios` | alias; paso del patrón (D-09 a) |
| 161 | `s11-ejemplos` | 3264 | #### Ejemplos de §11 | `c12-ejemplos` | alias; paso del patrón (D-09 a) |
| 162 | `s11-preguntas` | 3376 | #### Preguntas guía de §11 | `c12-preguntas` | alias; paso del patrón (D-09 a) |
| 163 | `s11-calidad` | 3398 | #### Criterios de calidad y antipatrones de §11 | `c12-calidad` | alias; paso del patrón (D-09 a) |
| 164 | `s11-8` | 3406 | ### §11.8 Qué decisión toca: ADR-06 | `c12-decision` | alias; paso «Decisión» del patrón (D-09 a) |
| 165 | `s12` | 3411 | ## §12 Operar y desplegar | `c13` | alias |
| 166 | `s12-1` | 3418 | ### §12.1 Observar con OpenTelemetry | `c13-1` | alias |
| 167 | `s12-2` | 3425 | ### §12.2 Contenido en la telemetría sólo por ambiente | `c13-2` | alias |
| 168 | `s12-3` | 3432 | ### §12.3 Costo y latencia | `c13-3` | alias |
| 169 | `s12-4` | 3461 | ### §12.4 Local, servidor de varias aplicaciones o nube | `c13-4` | alias |
| 170 | `s12-5` | 3473 | ### §12.5 Configuración y secretos por ambiente | `c13-5` | alias |
| 171 | `s12-6` | 3480 | ### §12.6 El camino mínimo: contenedor con endpoint configurable | `c13-6` | alias |
| 172 | `s12-7` | 3530 | ### §12.7 Aspire como orquestador de desarrollo | `c13-7` | alias |
| 173 | `s12-8` | 3537 | ### §12.8 Del prototipo a producción | `c13-8` | alias |
| 174 | `s12-9` | 3553 | ### §12.9 Realimentación del usuario | `c13-9` | alias |
| 175 | `s12-practica` | 3560 | ### Práctica de §12 | `c13-escenarios` | alias; el rótulo «Práctica» desaparece (D-09 a) |
| 176 | `s12-escenarios` | 3563 | #### Aplicación por escenario de §12 | `c13-escenarios` | alias; paso del patrón (D-09 a) |
| 177 | `s12-ejemplos` | 3572 | #### Ejemplos de §12 | `c13-ejemplos` | alias; paso del patrón (D-09 a) |
| 178 | `s12-preguntas` | 3648 | #### Preguntas guía de §12 | `c13-preguntas` | alias; paso del patrón (D-09 a) |
| 179 | `s12-calidad` | 3662 | #### Criterios de calidad y antipatrones de §12 | `c13-calidad` | alias; paso del patrón (D-09 a) |
| 180 | `s12-10` | 3670 | ### §12.10 Qué decisión toca: ADR-03 y ADR-09 | `c13-decision` | alias; paso «Decisión» del patrón (D-09 a) |
| 181 | `parte-vi` | 3675 | # Parte VI · Integración | `parte-7` | alias |
| 182 | `s13` | 3678 | ## §13 Decisiones de arquitectura de la capa de IA | `c14` | alias |
| 183 | `s13-1` | 3685 | ### §13.1 Cómo leer un ADR | `c14-1` | alias |
| 184 | `s13-2` | 3696 | ### §13.2 ADR-01 Dónde vive la llamada al modelo | `c14-2` | alias |
| 185 | `s13-3` | 3708 | ### §13.3 ADR-02 Contrato de acceso y adaptador del proveedor | `c14-3` | alias |
| 186 | `s13-4` | 3720 | ### §13.4 ADR-03 Local, servidor de varias aplicaciones o nube | `c14-4` | alias |
| 187 | `s13-5` | 3732 | ### §13.5 ADR-04 Herramienta, contexto fijo, contexto completo con pre | `c14-5` | alias |
| 188 | `s13-6` | 3744 | ### §13.6 ADR-05 Almacén vectorial | `c14-6` | alias |
| 189 | `s13-7` | 3756 | ### §13.7 ADR-06 Herramientas sobre casos de uso y aprobación | `c14-7` | alias |
| 190 | `s13-8` | 3768 | ### §13.8 ADR-07 Escalón de agencia | `c14-8` | alias |
| 191 | `s13-9` | 3780 | ### §13.9 ADR-08 La salida del modelo es una propuesta | `c14-9` | alias |
| 192 | `s13-10` | 3792 | ### §13.10 ADR-09 Pipeline transversal | `c14-10` | alias |
| 193 | `s13-11` | 3804 | ### §13.11 ADR-10 Pruebas y evaluación | `c14-11` | alias |
| 194 | `s13-12` | 3816 | ### §13.12 ADR-11 Capas como carpetas o como proyectos | `c14-12` | alias |
| 195 | `s13-13` | 3828 | ### §13.13 ADR-12 Estado del pedido de aprobación y ciclo de vida del  | `c14-13` | alias |
| 196 | `s13-14` | 3840 | ### §13.14 ADR-13 Un host para la demo | `c14-14` | alias |
| 197 | `s13-15` | 3852 | ### §13.15 Decisiones que este registro no toma | `c14-15` | alias |
| 198 | `s14` | 3857 | ## §14 Movilidad Urbana con capa de IA: la demo | `c15` | alias |
| 199 | `s14-1` | 3864 | ### §14.1 El punto de partida y la tabla de delta | `c15-1` | alias |
| 200 | `s14-2` | 3885 | ### §14.2 La imagen redibujada con los componentes reales | `c15-2` | alias |
| 201 | `s14-3` | 3943 | ### §14.3 Recorrido PD-1…PD-6 | `c15-3` | alias |
| 202 | `s14-4` | 4032 | ### §14.4 Siete tensiones de integración | `c15-4` | alias |
| 203 | `s14-5` | 4047 | ### §14.5 Cómo se corre y qué evidencia produjo | `c15-5` | alias |
| 204 | `s14-6` | 4064 | ### §14.6 Qué no hace la demo y qué haría falta en producción | `c15-6` | alias |
| 205 | `s14-preguntas` | 4076 | ### Preguntas guía de §14 | `c15-preguntas` | alias; paso del patrón (D-09 a) |
| 206 | `cierre` | 4091 | # Cierre | `cierre` | se conserva |
| 207 | `s15` | 4094 | ## §15 Autoevaluación | `c17` | alias |
| 208 | `s15-i01` | 4133 | **Ítem 1** · [OA-0.1](#oa-0-1) · caso | `c17-i01` | alias |
| 209 | `s15-i02` | 4140 | **Ítem 2** · [OA-0.2](#oa-0-2) · caso | `c17-i02` | alias |
| 210 | `s15-i03` | 4147 | **Ítem 3** · [OA-0.3](#oa-0-3) · caso | `c17-i03` | alias |
| 211 | `s15-i04` | 4156 | **Ítem 4** · [OA-D1](#oa-d1) · tarea sobre 02 | `c17-i04` | alias |
| 212 | `s15-i05` | 4163 | **Ítem 5** · [OA-D2](#oa-d2) · tarea sobre 03 | `c17-i05` | alias |
| 213 | `s15-i06` | 4170 | **Ítem 6** · [OA-D3](#oa-d3) · caso | `c17-i06` | alias |
| 214 | `s15-i07` | 4177 | **Ítem 7** · [OA-D4](#oa-d4) · tarea sobre 06 y 07 | `c17-i07` | alias |
| 215 | `s15-i08` | 4184 | **Ítem 8** · [OA-D5](#oa-d5) · tarea sobre 08 y 09 | `c17-i08` | alias |
| 216 | `s15-i09` | 4191 | **Ítem 9** · [OA-D6](#oa-d6) · caso | `c17-i09` | alias |
| 217 | `s15-i10` | 4198 | **Ítem 10** · [OA-D7](#oa-d7) · caso | `c17-i10` | alias |
| 218 | `s15-i11` | 4205 | **Ítem 11** · [OA-D8](#oa-d8) · tarea sobre 13 | `c17-i11` | alias |
| 219 | `s15-i12` | 4212 | **Ítem 12** · [OA-D9](#oa-d9) · tarea sobre 15 | `c17-i12` | alias |
| 220 | `s15-i13` | 4221 | **Ítem 13** · [OA-A1](#oa-a1) · tarea sobre el Anexo A | `c17-i13` | alias |
| 221 | `s15-i14` | 4228 | **Ítem 14** · [OA-A2](#oa-a2) · caso | `c17-i14` | alias |
| 222 | `s15-i15` | 4235 | **Ítem 15** · [OA-A3](#oa-a3) · caso | `c17-i15` | alias |
| 223 | `s15-i16` | 4242 | **Ítem 16** · [OA-A4](#oa-a4) · caso | `c17-i16` | alias |
| 224 | `s15-i17` | 4249 | **Ítem 17** · [OA-A5](#oa-a5) · caso | `c17-i17` | alias |
| 225 | `s15-i18` | 4256 | **Ítem 18** · [OA-A6](#oa-a6) · caso | `c17-i18` | alias |
| 226 | `s15-i19` | 4265 | **Ítem 19** · [OA-O1](#oa-o1) · tarea sobre 17 | `c17-i19` | alias |
| 227 | `s15-i20` | 4272 | **Ítem 20** · [OA-O2](#oa-o2) · tarea sobre la demo | `c17-i20` | alias |
| 228 | `s15-i21` | 4279 | **Ítem 21** · [OA-O3](#oa-o3) · caso | `c17-i21` | alias |
| 229 | `s15-i22` | 4286 | **Ítem 22** · [OA-O4](#oa-o4) · caso | `c17-i22` | alias |
| 230 | `s15-i23` | 4295 | **Ítem 23** · [OA-S1](#oa-s1) · caso | `c17-i23` | alias |
| 231 | `s15-i24` | 4302 | **Ítem 24** · [OA-S2](#oa-s2) · caso | `c17-i24` | alias |
| 232 | `s15-i25` | 4309 | **Ítem 25** · [OA-S3](#oa-s3) · caso | `c17-i25` | alias |
| 233 | `s15-i26` | 4316 | **Ítem 26** · [OA-S4](#oa-s4) · tarea sobre la demo y 11 | `c17-i26` | alias |
| 234 | `s15-i27` | 4325 | **Ítem 27** · [OA-SK1](#oa-sk1) · tarea sobre 14 | `c17-i27` | alias |
| 235 | `anexo-a` | 4332 | ## Anexo A · Plantillas comentadas | `anexo-a` | se conserva |
| 236 | `anexo-a-4` | 4339 | ### A.4 Puerto y adaptador, para §4 | `anexo-a-4` | se conserva |
| 237 | `anexo-a-5` | 4355 | ### A.5 Cliente y pipeline, para §5 | `anexo-a-5` | se conserva |
| 238 | `anexo-a-6` | 4372 | ### A.6 Ficha de decisión: contexto fijo, prefijo estable o RAG, para  | `anexo-a-6` | se conserva |
| 239 | `anexo-a-7` | 4388 | ### A.7 Ingesta y recuperación con `Fuente`, para §7 | `anexo-a-7` | se conserva |
| 240 | `anexo-a-8` | 4407 | ### A.8 Herramienta sobre un caso de uso, con aprobación, para §8 | `anexo-a-8` | se conserva |
| 241 | `anexo-a-10` | 4424 | ### A.10 Conjunto de oro y registro de una corrida, para §10 | `anexo-a-10` | se conserva |
| 242 | `anexo-a-11` | 4448 | ### A.11 Ficha de riesgo, para §11 | `anexo-a-11` | se conserva |
| 243 | `anexo-a-12` | 4467 | ### A.12 Configuración por ambiente, para §12 | `anexo-a-12` | se conserva |
| 244 | `anexo-a-13` | 4487 | ### A.13 Registro de una decisión de arquitectura, para §13 | `anexo-a-13` | se conserva |
| 245 | `anexo-a-14` | 4504 | <a id="anexo-a-props"></a> | `anexo-a-14` | se conserva |
| 246 | `anexo-a-props` | 4505 | ### A.14 `Directory.Packages.props` comentado | `anexo-a-props` | se conserva |
| 247 | `anexo-b` | 4548 | ## Anexo B · Listas de verificación por actor | `anexo-b` | se conserva |
| 248 | `anexo-b-dev` | 4555 | ### B.1 Desarrollador .NET (ACT-DEV) | `anexo-b-dev` | se conserva |
| 249 | `anexo-b-arq` | 4569 | ### B.2 Arquitecto o líder técnico (ACT-ARQ) | `anexo-b-arq` | se conserva |
| 250 | `anexo-b-ops` | 4583 | ### B.3 Operador o DevOps (ACT-OPS) | `anexo-b-ops` | se conserva |
| 251 | `anexo-b-sec` | 4598 | ### B.4 Responsable de datos y seguridad (ACT-SEC) | `anexo-b-sec` | se conserva |
| 252 | `anexo-b-herramientas` | 4612 | ### B.5 Lista de seguridad para herramientas | `anexo-b-herramientas` | se conserva |
| 253 | `anexo-c` | 4631 | ## Anexo C · Glosario | `anexo-c` | se conserva; absorbe §3.0 y §4.1 (C-2.3) |
| 254 | `anexo-d` | 4700 | ## Anexo D · Referencias | `anexo-d` | se conserva |
| 255 | `anexo-d-1` | 4707 | ### D.1 Marco, producto y diseño de la interacción | `anexo-d-1` | se conserva |
| 256 | `anexo-d-2` | 4720 | ### D.2 Fundamentos y «por qué ahora» | `anexo-d-2` | se conserva |
| 257 | `anexo-d-3` | 4755 | ### D.3 Microsoft.Extensions.AI y adaptadores | `anexo-d-3` | se conserva |
| 258 | `anexo-d-4` | 4783 | ### D.4 Estrategias de conocimiento y cachés | `anexo-d-4` | se conserva |
| 259 | `anexo-d-5` | 4803 | ### D.5 RAG, embeddings y almacenes vectoriales | `anexo-d-5` | se conserva |
| 260 | `anexo-d-6` | 4831 | ### D.6 Agentes, workflows y MCP | `anexo-d-6` | se conserva |
| 261 | `anexo-d-7` | 4855 | ### D.7 Marcos comparados: Semantic Kernel, AutoGen, LangGraph | `anexo-d-7` | se conserva |
| 262 | `anexo-d-8` | 4874 | ### D.8 Pruebas y evaluación | `anexo-d-8` | se conserva |
| 263 | `anexo-d-9` | 4883 | ### D.9 Seguridad | `anexo-d-9` | se conserva |
| 264 | `anexo-d-10` | 4897 | ### D.10 Operación, observabilidad y despliegue | `anexo-d-10` | se conserva |
| 265 | `anexo-d-11` | 4914 | ### D.11 Decisiones de arquitectura | `anexo-d-11` | se conserva |
| 266 | `anexo-d-12` | 4925 | ### D.12 Caso base y registros de paquetes | `anexo-d-12` | se conserva |
| 267 | `anexo-e` | 4935 | ## Anexo E · Laboratorio | `anexo-e` | se conserva |
| 268 | `anexo-e-1` | 4940 | ### E.1 Mapa de los ejemplos | `anexo-e-1` | se conserva; único mapa de ejemplos (C-2.7) |
| 269 | `anexo-e-2` | 4969 | ### E.2 Mapa de la demo | `anexo-e-2` | se conserva |
| 270 | `anexo-e-3` | 4974 | ### E.3 Qué hace falta y dónde corre cada cosa | `anexo-e-3` | se conserva |
| 271 | `anexo-e-4` | 5000 | ### E.4 El modo `--fake` | `anexo-e-4` | se conserva |
| 272 | `anexo-e-5` | 5022 | ### E.5 Reproducir un ejemplo y la demo | `anexo-e-5` | se conserva |
| 273 | `anexo-e-6` | 5048 | ### E.6 Registrar una corrida contra el modelo | `anexo-e-6` | se conserva |
| 274 | `anexo-e-7` | 5100 | ### E.7 Lo no ejecutado contra el modelo | `anexo-e-7` | se conserva |
| 275 | `anexo-f` | 5118 | ## Anexo F · Versiones verificadas y señales de obsolescencia | `anexo-f` | se conserva |
| 276 | `anexo-f-1` | 5123 | ### F.1 Paquetes que usan los ejemplos y la demo | `anexo-f-1` | se conserva |
| 277 | `anexo-f-2` | 5162 | ### F.2 Filas de estado: lo que la guía no usa y por qué | `anexo-f-2` | se conserva |
| 278 | `anexo-f-3` | 5188 | ### F.3 Invariante de versiones y su excepción | `anexo-f-3` | se conserva |
| 279 | `anexo-f-4` | 5197 | ### F.4 Entorno de las corridas | `anexo-f-4` | se conserva |
| 280 | `anexo-g` | 5226 | ## Anexo G · Lecturas para seguir | `anexo-g` | se conserva |
| 281 | `anexo-g-1` | 5231 | ### G.1 Cachés KV en el servidor de inferencia | `anexo-g-1` | se conserva |
| 282 | `anexo-g-2` | 5245 | ### G.2 Gobierno de IA responsable | `anexo-g-2` | se conserva |
| 283 | `anexo-g-3` | 5259 | ### G.3 Orquestación de varios agentes en el escalón 3 | `anexo-g-3` | se conserva |
