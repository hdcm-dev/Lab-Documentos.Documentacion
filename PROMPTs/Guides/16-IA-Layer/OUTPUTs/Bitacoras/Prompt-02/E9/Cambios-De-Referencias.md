# E9 · Cambios de referencias y casos de industria

Etapa E9 del plan integrado del prompt 02 (guía 16), cumplida el 2026-11-01. Dueño: P-09, Revisión bibliográfica. Entradas: el Anexo D, `Relevamiento/R6-Industria.md` (F5, F19 a F22 y F24), las reglas U-8.1 a U-8.5 y el resultado de T-3 (`E1/Ensayos.md` §5).

## Índice

1. [Definiciones](#1-definiciones)
2. [Criterio](#2-criterio)
3. [Tabla de cambios](#3-tabla-de-cambios)
4. [Casos de industria](#4-casos-de-industria)
5. [Decisión sobre los comentarios que citan «MCP 2025-06-18»](#5-decisión-sobre-los-comentarios-que-citan-mcp-2025-06-18)
6. [Compuertas](#6-compuertas)
7. [Extensión](#7-extensión)
8. [Pendientes](#8-pendientes)

## 1. Definiciones

- **Referencia tocada:** una entrada del Anexo D que cambió de URL, de versión o de anotación, o una entrada nueva.
- **Fecha de consulta de la ronda:** 2026-11-01. Es la única fecha de esta ronda (U-8.4) y la llevan todas las referencias tocadas. Las referencias que no se tocaron conservan su fecha.
- **Fuente leída:** una página que se abrió en esta etapa y de la que se tomó el texto citado. No cuenta un fragmento de un buscador ni una fuente secundaria.

## 2. Criterio

- No se renumera ningún Id. Las entradas nuevas toman Id desde el primero libre: REF-200 a REF-207 ya estaban ocupados, así que las nuevas van de REF-208 a REF-213.
- Cada referencia nueva se cita en el cuerpo del libro. `verificar-markdown.py` marca como defecto una referencia que no se cita en ninguna parte.
- El capítulo MCP no se reescribe (U-8.3). Se cambian las citas y se suma una sola oración sobre la versión del protocolo, que remite a la página de versionado.
- La lección de cada caso es la que publica su autor, leída en la fuente primaria. Las cifras se atribuyen al autor y se escriben sin la forma k/M, así la compuerta de intervalos no las toma por mediciones de la guía.

## 3. Tabla de cambios

| Id | Antes | Después | Fuente leída (2026-11-01) | Dónde se cita |
|---|---|---|---|---|
| REF-196 | «Transports», versión 2025-06-18 (Security Warning) | «Streamable HTTP», versión 2026-07-28, «Security & Endpoint», puntos 1 a 3 | `…/specification/2026-07-28/basic/transports/streamable-http`: los servidores MUST validar `Origin`; SHOULD escuchar sólo en localhost; SHOULD autenticar toda conexión | §12.5 (dos lugares), §13 (demo), Anexo B fila 8, regla de §12.5 |
| REF-197 | consultado 2026-10-28, con una nota sobre la ruta `basic/transports` | la misma URL, consultado 2026-11-01; la nota se quitó porque REF-196 ya apunta a la misma página | la misma página: «If the `Origin` header is present and invalid, servers MUST respond with HTTP 403» | §12.5. La oración cambió: decía «la revisión 2026-07-28 agrega que…» y ahora dice «un `Origin` presente e inválido recibe 403». Ya no compara con 2025-06-18, porque el libro no describe deltas |
| REF-198 | «Tools», versión 2025-06-18 | «Tools», versión 2026-07-28; la nota «sin cambios en la 2026-07-28» se quitó | las anotaciones se tratan como no confiables salvo de un servidor confiable (MUST); debe haber un humano que pueda negar la invocación (SHOULD); validar los resultados antes de pasarlos al modelo (SHOULD) | §9.9, §12.5, Anexo B fila 9 |
| REF-199 | «Authorization», versión 2025-06-18 | «Authorization», versión 2026-07-28 | «Authorization is OPTIONAL»; se aplica a los transportes HTTP; se basa en OAuth 2.1 (draft-ietf-oauth-v2-1-13) | §12.5, ESC-05, Anexo B fila 8 |
| REF-208 (nueva) | — | «Versioning» | `…/specification/versioning`: la versión vigente («current») es 2026-07-28; cada pedido la declara en `_meta` y, en Streamable HTTP, en `MCP-Protocol-Version`; las revisiones hasta 2025-11-25 se basaban en un saludo inicial | §9.9 (oración nueva «Versión del protocolo»), fila MCP del Anexo F |
| REF-209 a REF-213 (nuevas) | — | sección D.13 «Casos de industria» | ver §4 | tabla nueva en §14.1 |

Lo que confirma T-3 (E1, sin repetir el ensayo): el SDK 2.3.0 negocia 2026-07-28, y los 6 pedidos HTTP capturados llevan `MCP-Protocol-Version: 2026-07-28`. Por eso las cuatro citas de la especificación pasan a la revisión 2026-07-28, que es la que efectivamente habla el ejemplo 13.

Un hecho leído que el libro **no** incorpora (U-8.3): la revisión 2026-07-28 quitó las sesiones a nivel de protocolo y el endpoint GET de Streamable HTTP. La «sesión fija» de 13 es de la aplicación y no tiene relación con esas sesiones. Evaluar si conviene explicarlo queda para E10, Comisión A.

## 4. Casos de industria

U-8.2 prevé cinco casos: LinkedIn, Shopify Sidekick, el sistema multiagente de Anthropic, GitHub Copilot (histórico) y eShopSupport. Uber no entra: su fuente primaria dio 404 en el relevamiento.

| Id | Caso | Lo que se leyó en la fuente primaria y se cita | Decisión del libro que respalda |
|---|---|---|---|
| REF-209 | LinkedIn, 2024-04-25 | los errores de formato, cerca del 10 %, bajaron a cerca del 0,01 % con un analizador YAML defensivo y pistas en el prompt | ADR-08, §6.3 |
| REF-210 | Shopify, 2025-08-26 | el kappa de Cohen del juez pasó de 0,02 a 0,61, frente a 0,69 entre personas (cita literal) | ADR-10, §11.6 |
| REF-211 | Anthropic, 2025-06-13 | el juez de una sola llamada, con puntaje de 0,0 a 1,0 y aprobado o desaprobado, fue el más consistente; la evaluación humana sigue haciendo falta; las trazas no miran el contenido de las conversaciones | ADR-10, §13.2 |
| REF-212 | GitHub, 2023-05-17, actualizado 2024-02-07 | los modelos procesaban unos 6.000 caracteres por vez, así que el contexto se elegía y se ordenaba | ADR-04, §7.3 |
| REF-213 | dotnet/eShopSupport | aplicación .NET de referencia para tickets de soporte: clasificación, sentimiento, resumen, datos sintéticos, chatbot y evaluación con preguntas y respuestas fundamentadas | capítulo 15 |

Ubicación: los casos van como tabla en §14.1, «Cómo leer un ADR», bajo el título «Las mismas decisiones en casos públicos». No se abrió una sección nueva, porque cambiaría la numeración de §14.16 y de las siguientes. Se eligió la Parte VII porque es la única con margen de palabras: 469 antes de E9. D.13 lista sólo las referencias.

Cosas que se leyeron y se dejaron afuera:
- Shopify dice que pasadas las 50 herramientas el sistema se vuelve difícil de razonar. No entra porque ningún ADR del libro decide sobre la cantidad de herramientas.
- Las mejoras de Copilot del 5 % y del 10 % relativo no entran porque no respaldan ninguna decisión del libro.

## 5. Decisión sobre los comentarios que citan «MCP 2025-06-18»

**Decisión: se actualizan a 2026-07-28 las cinco citas en prosa del ejemplo 13 y se deja como está la carga de prueba de `Garantias.cs`.**

| Archivo | Cambio |
|---|---|
| `Examples/13-Servidor-Y-Cliente-MCP/Infrastructure/AI/ClienteMcp.cs` (comentario de la línea 3) | `MCP 2025-06-18, Tools` → `MCP 2026-07-28, Tools` |
| `Examples/13-Servidor-Y-Cliente-MCP/Infrastructure/Mcp/ServidorMcp.cs` (comentario de la línea 7) | `MCP 2025-06-18, Transports` → `MCP 2026-07-28, Streamable HTTP` |
| `Examples/13-Servidor-Y-Cliente-MCP/Infrastructure/Mcp/LecturasMcp.cs` (comentario XML de la línea 38) | `MCP 2025-06-18, Tools` → `MCP 2026-07-28, Tools` |
| `Examples/13-Servidor-Y-Cliente-MCP/README.md` (líneas 14 y 18) | lo mismo, en prosa |
| `Examples/13-Servidor-Y-Cliente-MCP/Garantias.cs` (línea 145) | **sin cambio** |

Por qué:
1. **El código es la verdad.** T-3 muestra que el ejemplo negocia 2026-07-28. Si un comentario cita otra revisión, manda al lector a una especificación que el ejemplo no habla.
2. **Las reglas citadas siguen iguales en 2026-07-28**, y se leyeron hoy (§3): validar `Origin` es MUST, con 403 si el `Origin` presente es inválido; las anotaciones de las herramientas no son confiables. Con 2026-07-28, el comentario de `ServidorMcp.cs` («rechaza con 403») coincide literalmente con la especificación.
3. **El libro ya las cita así** (REF-196 a REF-199 en 2026-07-28), y el README no puede contradecir al libro.
4. **`Garantias.cs` no cita la especificación: es un dato de prueba.** Es el cuerpo JSON de un `initialize` que manda la prueba de Host y `Origin`. Cambiar su `protocolVersion` cambiaría el estímulo de una prueba, y eso no le corresponde a una etapa de referencias. Que esa prueba deba usar el saludo inicial o el pedido de 2026-07-28 se deriva a E10 y E11 como observación.

Riesgo: los tres `.cs` cambian sólo en comentarios. La compilación no se volvió a correr en E9: queda **NO EJECUTADO** y lo cubre `verificar.sh build` en E11.

## 6. Compuertas

Todas corrieron sobre la guía final, sha256 `ec4185d448aef67a446a86b3241d0da955f28457845887e9576fb77f1e19d82d`.

| Compuerta | rc | Resultado |
|---|---|---|
| `tools/compuerta-referencias.sh` | 0 | 0 rotas en 21 archivos |
| `tools/verificar-markdown.py guia Dot-Net-Integration-AI-Layer-Guide.md` | 0 | 187 referencias definidas y todas citadas. La primera pasada marcó REF-209 a REF-213 como no citadas; se resolvió con la tabla de §14.1 |
| `tools/verificar-markdown.py ejemplos Examples` | 0 | 18 archivos |
| `tools/compuerta-intervalos.py` (libro + `Bitacoras/Evidencia/R-LLM`) | 0 | 28 figuras, 28 en el mapa; 21 de 21 filas. Las cifras nuevas no tienen forma k/M |
| `tools/compuerta-rpriv.sh` (libro y README de 13) | 0 | 0 hallazgos, clases genéricas |
| URL de las 9 referencias tocadas (curl -L) | — | 9 de 9 responden HTTP 200 |
| mermaid y mermaid-arroba | — | no aplica: E9 no agrega diagramas y ninguna línea nueva lleva arroba |
| `compuerta-ac7.sh` y `compuerta-ac8.sh` | 2 | cerradas sin `COMPUERTAS_DIR`, igual que en las etapas anteriores; no aplican a E9 |

Evidencia: `Evidencia/guia.diff`, `Evidencia/ejemplo13.diff`, `Evidencia/contar.final` y `Evidencia/SHA256SUMS`.

## 7. Extensión

| Parte | Antes de E9 | Después | Tope |
|---|---|---|---|
| Parte V | 8.242 | 8.278 | 8.300 |
| Parte VI | 8.754 | 8.749 | 8.800 |
| Parte VII | 7.131 | 7.297 | 7.600 |
| Anexos | 12.874 | **12.956** | 12.900 |
| Total | 59.096 | 59.375 | 60.000 |

Los Anexos pasan su tope por 56 palabras (100,4 %). La causa son seis entradas nuevas del Anexo D que U-8.1 y U-8.4 exigen. Para compensar se acortaron las anotaciones de REF-196 a REF-199 y D.13 quedó sólo con referencias. `contar.sh` informa los topes pero no bloquea. Queda como pendiente P-E9-1.

## 8. Pendientes

- **P-E9-1 (P2, para E10 o E11):** los Anexos tienen 56 palabras sobre su tope. Hay dos salidas: recortar en el Anexo D o en el G durante la ronda de estilo (Comisión B), o que el jurado reasigne el tope entre partes. El total sigue por debajo de 60.000.
- **P-E9-2 (P3, para E10, Comisión A):** decidir si §9.9 explica que la revisión 2026-07-28 quitó las sesiones de protocolo, para que el lector no las confunda con la sesión fija de 13.
- **P-E9-3 (P3, para E11):** el `initialize` con `protocolVersion` 2025-06-18 de `Garantias.cs`. Correr `verificar.sh build` con turno para cerrar el NO EJECUTADO de §5.
- Mensajes ajenos a mitad de turno: no llegó ninguno.
