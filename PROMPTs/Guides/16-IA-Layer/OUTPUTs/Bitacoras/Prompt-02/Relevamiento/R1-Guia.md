# R1 · Relevamiento de la guía (prompt 02, guía 16)

> Fecha: 2026-11-01 · Tarea R1-guia · Etapa de planificación: no se editó la guía ni su repo. Rutas relativas a `{guia}` = `Lab-Documentos/Guides/IA/Dot-Net-Integration-AI-Layer-Guide/`. Líneas de `{guia}/Dot-Net-Integration-AI-Layer-Guide.md` (sha del estado relevado: el de 0.11.0, ver `05-Cierre.md` de la mesa de recuperación).

## Índice

1. [Estructura actual](#1-estructura-actual)
2. [Conceptos y dónde se definen](#2-conceptos-y-dónde-se-definen)
3. [Inventario de ejemplos y demo](#3-inventario-de-ejemplos-y-demo)
4. [Incoherencias visibles](#4-incoherencias-visibles)
5. [Repeticiones](#5-repeticiones)
6. [Faltantes frente al prompt 02](#6-faltantes-frente-al-prompt-02)
7. [Extensión medida](#7-extensión-medida)
8. [Insumos para la mesa](#8-insumos-para-la-mesa)

## 1. Estructura actual

Archivo único: 5.268 líneas, 72.364 palabras (`wc`), frontmatter `version: 0.11.0`, `status: en revisión`, `last_review: 2026-10-29` (l. 1-13). 229 encabezados y 283 anclas según la compuerta `verificar-markdown.py` (05-Cierre). 23 bloques mermaid. 574 apariciones de `REF-` (180 referencias distintas según la compuerta).

| Bloque | Línea | Secciones (ancla) |
|---|---|---|
| Parte 0 · Cómo usar esta guía | 23 | §0 (`s0`): §0.0 Tabla de contenido (`s0-0`, mermaid), §0.1 Objetivos por actor (27 OA), §0.2 Rutas, §0.3 Requisitos, §0.4 Lectura y evidencia (plantilla de sección), §0.5 Mapa de ejemplos (remite al Anexo E) |
| Parte I · Marco | 182 | §1 Diapositiva «IA ya es parte del stack» (l. 185); §2 Marco de referencia: escenarios ESC, contextos CTX, actores ACT, valor, diseño para el error (l. 262); §3 Mapa conceptual: §3.0 doce términos, §3.1 capas, §3.2 dos escaleras, §3.3-§3.5 tablas (l. 388) |
| Parte II · Fundamentos | 602 | §4 La capa en la arquitectura (vocabulario §4.1, «por qué ahora» §4.2, ubicación, dos contratos, antipatrones, ADR-01) (l. 605); §5 Microsoft.Extensions.AI (l. 875) |
| Parte III · Conocimiento | 1349 | §6 Estrategias de conocimiento (carril aparte, escalones 0-3, cachés, ventana) (l. 1352); §7 RAG en .NET (l. 1605) |
| Parte IV · Agencia | 1954 | §8 Herramientas, agentes, workflows, MCP (l. 1957); §9 Marcos comparados (SK, AutoGen, LangGraph, MAF) (l. 2546) |
| Parte V · Producción | 2796 | §10 Pruebas y evaluación (l. 2799); §11 Seguridad (l. 3111); §12 Operación y despliegue (l. 3412) |
| Parte VI · Integración | 3676 | §13 ADR-01…ADR-13 (l. 3679-3858); §14 Demo Movilidad Urbana PD-1…PD-6 (l. 3858) |
| Cierre | 4092 | §15 Autoevaluación (27 ítems, uno por OA) (l. 4095) |
| Anexo A Plantillas | 4333 | A.4-A.8, A.10-A.14 (`anexo-a-n`; no hay A.1-A.3 ni A.9, declarado l. 4335) |
| Anexo B Listas por actor | 4549 | B.1-B.5 |
| Anexo C Glosario | 4632 | remite a «Se define en» |
| Anexo D Referencias | 4701 | D.1-D.12 por tema |
| Anexo E Laboratorio | 4936 | E.1 mapa de ejemplos, E.2 demo, E.3-E.7 reproducción, `--fake`, registros, lo no ejecutado |
| Anexo F Versiones | 5119 | F.1-F.4 |
| Anexo G Lecturas | 5227 | G.1-G.3 |

Patrón por sección (§0.4, l. 149-158): Definición → subsecciones → «En este laboratorio» → «Práctica de §N» → «Qué decisión toca» (ADR). Las Prácticas son largas: §5 l. 1038-1344, §7 l. 1730-1949, §8 l. 2156-2541.

## 2. Conceptos y dónde se definen

| Concepto | Definición principal | También aparece |
|---|---|---|
| Doce términos base (modelo, prompt, contexto, herramienta, llamada con herramientas, salida estructurada, embedding, RAG, RAG agéntico, contexto completo con prefijo estable, workflow, agente) | §3.0 (l. 395, una línea c/u) | §4.1 «qué no es» (l. 612); Anexo C (l. 4632); desarrollo en §5-§8 |
| Capas (Presentation/Application/Domain/Infrastructure/AI/Host) | §3.1 (l. 413) | §4.3, §14.2, ADR-01, ADR-11 |
| Dos escaleras (saber / hacer) | §3.2 (l. 437) | §6 (escalones 0-3), §8.1 (agencia) |
| Escenarios ESC, contextos CTX, actores ACT | §2.1-§2.3 | §3.3, §11.1, Anexo B |
| Puerto propio vs `IChatClient` | §4.4 (l. 715) | A.4, ADR-02 |
| Pipeline / capa única de opciones | §5.4 (l. 909) | §12.1-§12.3, ADR-09, `_Comun` |
| Cachés y ventanas | §6.4-§6.5 | Anexo G.1 |
| Aprobación humana | §8.5 | §11.3, ADR-06, ADR-12, ejemplos 09/11 |
| «La salida del modelo es una propuesta» | ADR-08 (§13.9) | §3.0, §5.3 |
| Evidencia (conducta, tasa, criterio de la guía, Historia) | §0.4 | todo el texto |

Hecho: el contenido conceptual que el prompt llama «fundamentos del framework» está repartido entre §1, §3, §4.1-§4.2 y §13; no hay una sección que los reúna con ese nombre. La Parte II se llama «Fundamentos» pero trata ubicación arquitectónica y MEAI (l. 602-1349).

## 3. Inventario de ejemplos y demo

Mapa de la guía: Anexo E.1 (l. 4941-4966). Verificado contra el árbol `{guia}/Examples/`: las 17 carpetas existen con `README.md`, `ejemplo.json`, `entradas.v1.json`, `Program.cs` y `Pruebas/`.

| Ejemplo | Sección que lo usa (E.1) | Modelo |
|---|---|---|
| 01 Chat y streaming | §5.1, §5.2 | chat |
| 02 Cambio de adaptador | §5.6 | segundo servidor |
| 03 Salida estructurada | §5.3 | chat |
| 04 Normalización contra catálogo | §5.3 | chat |
| 05 Contexto completo con prefijo | §6.3-§6.5 | segundo servidor |
| 06 Embeddings y búsqueda | §7.1, §7.2, §7.5 | embeddings |
| 07 RAG con citas | §7.3-§7.5 | chat + embeddings |
| 08 Primera herramienta sólo lectura | §8.2, §8.3 | chat |
| 09 Caso de uso como herramienta | §8.4, §8.5 | chat |
| 10 Workflow y contraejemplo | §8.6 | sin modelo |
| 11 Agente con aprobación | §8.5, §8.7 | chat |
| 12 Uno o varios agentes | §8.6, §8.8 | chat |
| 13 Servidor y cliente MCP | §8.9, §11.5 | chat |
| 14 Anotaciones SK vs MEAI | §9.7 | sin modelo |
| 15 Pruebas y evaluación | §10.2-§10.6 | segundo servidor (juez) |
| 16 Inyección indirecta | §11.2, §11.3, §11.7 | chat |
| 17 Observabilidad y pipeline | §12.1-§12.3 | chat |

Sin ejemplo propio: §4 (lo cubre la demo), §6.1-§6.2, §6.6 (RAG agéntico), §7.6-§7.7, §8.7 escalón 3 (declarado l. 177-179), §12.4-§12.9, §13.
Compartido: `Examples/_Comun/` (Dominio, Persistencia, Asistente.Comun, pruebas, Humo).
Demo: `Demos/MovilidadUrbana.Asistente/` (`src`, `tests` con `Cableado/` y `ConModelo/`, `tools/demo.sh`, `diff-base.sh`, `compose.yaml`); la usa §14 (PD-1…PD-6) y es la ubicación de referencia de §4 (E.1, l. 4947). Estado: demo 81/81, build 561/561 (05-Cierre).
Tools: `verificar.sh` (arnés), `contar.sh`, `verificar-markdown.py`, compuertas `ac7`, `ac8`, `rpriv`, `cabeceras`, `intervalos`, `comparar-ac9.py`, `recalcular-oraculos.sh` y 24 oráculos `.jq`; `Compuertas/` (formato y `ac6.excepciones`).
`Conocimientos/knowledge-AI-Layer-Integration-Designing-Specification.md`: 0 bytes; la guía no lo menciona.

## 4. Incoherencias visibles

| # | Evidencia | Qué choca |
|---|---|---|
| I-1 | §0.5 (l. ~177): «la prosa suma 57.234 palabras … (129 %)… Anexos 12.532 (169 %)»; `tools/contar.sh` hoy: 57.753, 130 %, Anexos 12.641 (170 %) | Cifra autodeclarada desactualizada respecto de la herramienta |
| I-2 | `Examples/README.md` l. 17 nombra `comparar-bloques.py`; en `tools/` existe `comparar-ac9.py` y no `comparar-bloques.py` | README apunta a un archivo inexistente |
| I-3 | `Examples/README.md` usa «propio 3a / compartido / propio 3b»; la guía E.3 usa «servidor de chat / segundo servidor» y aclara que «compartido» y `OLLAMA_PROPIO_*` son nombres históricos (l. 1005, E.3) | Vocabulario distinto entre guía y README para lo mismo |
| I-4 | `Examples/03-Salida-Estructurada/SalidaEstructurada.csproj`; los otros 16 se llaman `NN-Nombre.csproj` | Convención de nombre rota en un ejemplo |
| I-5 | E.1 (l. 4947): los ejemplos ponen `IChatClient`, herramientas, almacén o workflow bajo `Application/`, lo que ADR-01 «admite sólo en un prototipo y como deuda» | El texto normativo (§4, ADR-01) y los ejemplos divergen; declarado, pero es la incoherencia texto-ejemplo central |
| I-6 | Parte II rotulada «Fundamentos» (l. 602) con contenido de arquitectura y SDK | El nombre no coincide con lo que el prompt pide como «fundamentos» |
| I-7 | §3.1 (l. 413) y §4.3: invariante «ninguna flecha va del modelo al repositorio… salvo dos excepciones rotuladas en §14.2»; demo README l. 153: la quinta regla de arquitectura admite `Pages/Chat.razor` entrando a `Infrastructure.AI` | Coherente pero sólo si se lee §14.2: excepción a una regla de §3 definida 3.400 líneas después |
| I-8 | Anexo A (l. 4335): «A.14 sirve para el Anexo F y conserva su número por las remisiones» | Numeración atada a remisiones, no a contenido |
| I-9 | §4.2: el modelo de laboratorio `qwen3.5:4b` «no tiene fila: no se registró una fuente primaria» | Afirmación sin fuente sobre la pieza más usada (conforme a la regla «no inventar», pero es un hueco de evidencia) |

No se detectaron ejemplos citados en E.1 sin carpeta ni carpetas sin fila.

## 5. Repeticiones

- Definiciones en tres niveles: §3.0 (qué es), §4.1 (qué no es), Anexo C (dónde), más la sección temática. Glosario ya deduplicado (declarado, l. 4632-4640).
- Mapa de ejemplos: §0.5, §3.4/§3.5, Anexo E.1/E.2 y los «En este laboratorio» de cada sección.
- Servidores, versiones y digests: §4.2 (tabla), §5.5 (l. 1005), E.3, F.4, y párrafos «Historia (hasta el 2026-10-28)» — 62 apariciones de «Historia (hasta»; `qwen2.5:0.5b` aparece 22 veces aunque está retirado.
- ADR: «Decisión en curso / Qué decisión toca» al final de cada §4-§12 y nuevamente §13.2-§13.14 y A.13.
- Objetivos: §0.1 (27 OA) y §15 (27 ítems), más Anexo B por actor.
- Reproducción: §0.4, Prácticas de cada sección, E.3-E.6, `Examples/README.md`, `Demos/.../README.md`.

## 6. Faltantes frente al prompt 02

| Pedido (prompt 02, Solicitudes/Reglas) | Estado relevado |
|---|---|
| Sección inicial de fundamentos del framework | No existe como tal; los principios están dispersos (§1, §3, §4.1-§4.2, ADR-08). Falta un capítulo inicial que los enuncie (capa con contrato, propuesta vs autoridad, dos escaleras, evidencia) |
| Índice | Existe §0.0 con mermaid de 8 bloques y lista; cumple |
| Autocontenida y no delta | No cumple del todo: 62 bloques «Historia (hasta el 2026-10-28)», nombres «históricos» de variables, referencias a mesas/planes («plan §C», «H2-047» en `tools/contar.sh`), «era `MovilidadUrbana.ApiWeb`» en el README de la demo. Requiere `Examples/` y la demo para varias afirmaciones |
| Definiciones, explicaciones, ejemplos, mermaid | Cumple: cada sección abre con «Definición»; 23 mermaid |
| Coherencia con ejemplos | Ver §4 (I-1…I-5) |
| Unificar documentos individuales | Ya es un solo archivo; no se hallaron documentos individuales vivos en `{guia}` |
| Conocimiento de especificación | Archivo vacío (0 bytes) |
| Referencias y casos de la industria (Solicitud 4) | Anexo D (180 REF) y G; no hay casos de uso aplicados (Geometría ni servicio privado): 0 menciones |
| Revisión editorial «como libro» | Pendiente: prosa densa con fechas, digests y cifras de laboratorio intercaladas en el texto conceptual |

## 7. Extensión medida

`bash {guia}/tools/contar.sh` (2026-11-01):

| Parte | Palabras | Tope | % |
|---|---|---|---|
| 0 | 2.178 | 1.400 | 156 |
| I | 3.670 | 3.500 | 105 |
| II | 6.693 | 5.000 | 134 |
| III | 6.409 | 5.500 | 117 |
| IV | 8.716 | 7.500 | 116 |
| V | 8.895 | 6.500 | 137 |
| VI | 5.475 | 4.500 | 122 |
| Cierre | 3.076 | 3.000 | 103 |
| Anexos | 12.641 | 7.430 | 170 (A 2.689, B 1.713, C 452, D 3.706, E 2.454, F 533, G 1.094) |
| Total | 57.753 | 44.330 | 130 |

Todas las partes exceden el tope; la carta pide tratar el 130 % como dato de partida. Mayores excesos: Anexos (+5.211), Parte V (+2.395), Parte II (+1.693). Sumar un capítulo de fundamentos sin recortar aumenta el exceso.

## 8. Insumos para la mesa

1. Núcleos candidatos (por afinidad): N-Fundamentos (§1, §3, §4.1-4.2, ADR-08); N-Arquitectura (§4, §5, ADR-01/02/09/11); N-Conocimiento (§6-§7); N-Agencia (§8-§9); N-Producción (§10-§12); N-Integración (§13-§14); N-Laboratorio (Anexos E/F, tools); N-Especificación (Conocimiento nuevo, derivado de §13 + Anexos A/B).
2. Sacar lo histórico («Historia…», digests retirados) a la bitácora o a un anexo único de procedencia para cumplir «no delta».
3. Corregir I-1…I-4 (mecánicos) y decidir I-5 (alinear ejemplos o rotularlos en cada sección).
4. El Conocimiento de especificación puede nacer de §13 (ADR), Anexo A (plantillas) y Anexo B (listas), separando regla, razón y evidencia (criterio acordado con FC en `00-Coordinacion-Entre-Sesiones.md`).
