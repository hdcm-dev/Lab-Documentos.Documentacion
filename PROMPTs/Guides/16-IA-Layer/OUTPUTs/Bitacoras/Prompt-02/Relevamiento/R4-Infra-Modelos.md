# R4 — Infraestructura de modelos de prueba

Relevamiento del prompt 02, 2026-11-01. Versión abstracta: sin hosts, puertos, IP ni usuarios (el detalle queda en un informe privado, <privado>).

## 1. Qué hay

| Estación | Tipo de servidor | Estado al 2026-11-01 |
|---|---|---|
| Pasarela de IA de la casa (nginx delante de Ollama) | proxy inverso + Ollama | **No disponible**: vivía en el host caído; no se replicó. La documentación del host vigente lo registra como ausente. |
| Estación 1 (la de la guía) | Ollama 0.40.11 en contenedor, solo CPU | Activa desde hace 4 días; accesible sólo por red privada. |
| Estación 2 | Ollama en máquina virtual | Apagada a propósito; no se tocó. |

## 2. Compatibilidad de API (estación 1)

- API nativa de Ollama: `/api/version`, `/api/tags`, `/api/ps`, `/api/show`, `/api/generate`, `/api/embed`.
- API compatible con OpenAI: `/v1/models`, `/v1/chat/completions` (con `usage` y `cached_tokens`), `/v1/embeddings`.
- Sin autenticación.

## 3. Modelos expuestos

| Modelo | Parámetros | Cuantización | Capacidades declaradas | Contexto nativo |
|---|---|---|---|---|
| `qwen3.5:4b` | 4,2 B | Q4_K_M | completion, vision, tools, thinking | 262 144 |
| `qwen2.5:0.5b` | 494 M | Q4_K_M | completion, tools | 32 768 |
| `qwen3-embedding:0.6b` | 596 M | Q8_0 | embedding (1024 dimensiones) | — |

Contexto efectivo al cargar: 4096 tokens (valor por omisión del servidor).

## 4. Mediciones (2026-11-01 16:15 -03, con turno del gestor de recursos)

| Pedido | Resultado |
|---|---|
| `generate`, `qwen2.5:0.5b`, 8 tokens, en frío | 2,14 s (carga 1,84 s) |
| ídem, en caliente | 0,164 s; 8 tokens en 0,138 s (≈ 58 tok/s) |
| `/v1/chat/completions`, en caliente | 0,162 s |
| `/api/embed`, `qwen3-embedding:0.6b`, en frío | 2,62 s |
| `/v1/embeddings`, en caliente | 0,036 s |
| `/v1/chat/completions` con una herramienta, `qwen2.5:0.5b` | 1,55 s, respuesta vacía y **sin `tool_calls`** |

No se cargó `qwen3.5:4b` (fuera del alcance de una prueba trivial); su latencia y su tool calling quedan por medir.

## 5. Límites de la estación 1

- Un pedido a la vez (`OLLAMA_NUM_PARALLEL=1`): los pedidos concurrentes se serializan.
- Hasta dos modelos cargados (`OLLAMA_MAX_LOADED_MODELS=2`); se descargan a los 10 min sin uso.
- Tope de 5 GiB de memoria del contenedor; sin GPU.

## 6. Consecuencias para la guía

1. Lo que la guía diga de una pasarela de IA compartida no se puede verificar hoy: las pruebas usan Ollama directo.
2. Para ejemplos de herramientas (tool calling) el modelo de 0,5 B no alcanza; usar el de 4 B y medirlo.
3. Las herramientas de turno tienen por omisión la dirección de la pasarela vieja: hay que pasar la URL de la estación 1 explícitamente.
