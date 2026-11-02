# C — Operación y demo: evidencia de la integración (X0…X5)

> Creado el 2026-10-28 por la aplicación del ciclo 1 de la mesa (Parche P-25, C1-26 y C1-S4 (4)). Las salidas crudas no se tocan: las cabeceras R-LLM que no registraron se completan acá, sin re-correr. Toda cifra lleva el rótulo «medido en la estación de laboratorio (CPU de 4 núcleos sin GPU; contenedor limitado a 4 CPU / 5 GB; Ollama 0.40.11), 2026-10-28». El servidor se alcanza sólo por `OLLAMA_ENDPOINT` (R-PRIV).

## Archivos

| Id | Qué | Contra el modelo | Archivos |
|---|---|---|---|
| X0 | Versiones en nuget.org (24 paquetes) | no | `X0-nuget-consultar.sh`, `X0-nuget-salida.tsv` |
| X1 | OTel `sourceName` y ciclo de vida (T1), con cliente falso | no (recurso `build`) | `X1-sonda-otel-t1.csproj`, `X1-sonda-otel-t1-Program.cs`, `X1-sonda-otel-t1-salida.txt` |
| X2 | Escrituras propuestas por el modelo (D1, D2, D6) | sí | `X2-correr.sh`, `X2-escrituras.py` (copia con el nombre que invoca el script: `escrituras.py`), `X2-escrituras-qwen3.5-4b.jsonl`, `X2-fecha.txt` |
| X3 | Ventana de contexto (truncado) | sí | `X3-correr.sh`, `X3-ventana.py` (copia: `ventana.py`), `X3-ventana-qwen2.5-0.5b.jsonl`, `X3-logs-truncado.txt`, `X3-fecha.txt` (copiado el 2026-10-28 del intermedio de la corrida) |
| X4 | Variables `OLLAMA_*` del contenedor (sin host) | no | `X4-env-contenedor.txt` |
| X5 | Caso base: commit, marco de pruebas, persistencia | no | `X5-caso-base.txt` |

`X2-X3-correr-ollama.sh` llama a dos scripts del intermedio, fuera de la bitácora (`tools/correr-x2.sh`, `ctx/correr-x3.sh`): queda como historia. Para re-correr desde acá: `X2-correr.sh` y `X3-correr.sh`, que invocan `escrituras.py` y `ventana.py` (copias idénticas a `X2-escrituras.py` y `X3-ventana.py`, verificadas con `diff` el 2026-10-28) y escriben en `salidas/`.

## Cabeceras R-LLM (plantilla de VERIFI-05 y Parche P-25)

| Campo | X2 | X3 |
|---|---|---|
| Fecha ISO | 2026-10-28T08:59:58-03:00 → 09:11:26-03:00 (`X2-fecha.txt`) | 2026-10-28T09:11:26-03:00 → 09:15:25-03:00 (`X3-fecha.txt`) |
| `/api/version` | 0.40.11 (registrada por el sondeo del mismo día, `Sondeo-Entorno.md` §R.0; la corrida no la registró) | ídem |
| modelo@digest (`/api/tags`) | `qwen3.5:4b@d8b0f5e9760cd1682034f292d7ef72ec46f432149be0df7574bf2d6e92e38c04` (de `Sondeo-Evidencia/2026-10-28/salidas/01-info.jsonl`; la corrida registró sólo el nombre) | `qwen2.5:0.5b@a8b0c51577010a279d933d14c2a8ab4b268079d44c5c8830c0a93900f1827c67` (ídem) |
| Parámetros | `/v1/chat/completions`, `temperature 0.7`, `seed` 1..N, `max_tokens 300`, `reasoning_effort none` (`X2-escrituras.py` l. 5 y 74) | `/api/generate`, `temperature 0`, `num_predict 8`; un caso sin `num_ctx` y otro con `num_ctx 8192` (`X3-ventana.py` l. 17–18) |
| N | 10 por pedido, tres pedidos (30 llamadas) | 1 por caso, dos casos |
| Entrada exacta | los tres textos de pedido de `X2-escrituras.py` | 320 líneas sintéticas (`X3-ventana.py` l. 15) con el dato en la zona descartada |
| Criterio escrito antes | las clases de resultado de la función `clasificar` de `X2-escrituras.py` (l. 77), fijadas en el script antes de correr; lectura en BIT-16-04 §1 (X2) | la pregunta de `X3-ventana.py` l. 2 («¿trunca en silencio sin `num_ctx`?») |

Cifras agregadas de X2 y X3: tabla única de `Sondeo-Entorno.md` §R.6 (Parche P-21).
