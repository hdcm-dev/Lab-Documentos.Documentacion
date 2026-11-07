# Constancia de verificación técnica — Núcleo 09 (Bases vectoriales y RAG)

Documento: `Guides/IA/IA-Model/09-Bases-Vectoriales-Y-RAG.md` · Verificador técnico ·
2026-11-07

Entorno: contenedor `python:3.12.16-slim` (Python 3.12.16), venv propio;
torch 2.9.1+cpu, sentence-transformers 5.1.2, faiss-cpu 1.12.0, numpy 2.5.4 — idéntico al
declarado en `entorno_validado`. Banco: Ollama 0.32.0-rc0 por `$OLLAMA_HOST`,
generación con `qwen2.5:7b-instruct` (digest `845dbda0ea48…`, Q4_K_M, 7.6B).

**Hecho determinante**: el corpus sintético del redactor (`corpus/`, 3 archivos) no quedó
preservado en ningún worktree, de modo que las cifras pegadas de los labs 2 y 3 eran
irreproducibles. Sembré un corpus propio equivalente (misma estructura: reglamento, horarios,
talleres; 15 párrafos; las oraciones clave citadas por el texto se conservan), lo transcribí
**completo dentro del documento** (desplegable en §3.2, para que las cifras sean reproducibles
por el lector) y lo dejé también en `evidencia/local/verif-09-corpus/`. Todas las salidas
pegadas se reemplazaron por las de mi corrida real.

## Corridas

| # | Ejemplo | Comando | Log crudo (evidencia/local/) | SHA-256 | Veredicto |
|---|---|---|---|---|---|
| 1 | Nota previa §3: `/api/embed` no habilitado | `curl $OLLAMA_HOST/api/embed -d '{"model":"qwen3.5:4b","input":"hola"}'` | `verif-09-banco.log` | `f645ddae4b50…b4039` | **verificado** — error literal «This server does not support embeddings. Start it with \`--embeddings\`» idéntico al transcripto |
| 2 | Preparación común (venv + pips fijados) | `python3 -m venv … ; pip install torch==2.9.1 … sentence-transformers==5.1.2 faiss-cpu==1.12.0` | (versiones en logs de labs) | — | **verificado** — instala y resuelve exactamente las versiones declaradas |
| 3 | Lab 1 — embeddings y ranking | `python lab1_embeddings.py` | `verif-09-lab1.log` | `c0640592…68d8d` | **verificado** — salida bit a bit igual a la pegada (384 dim, norma 1.0000, ranking 0,396/0,366/0,295/0,062/0,044); determinismo confirmado |
| 4 | Lab 2 — mini-RAG con contexto (banco) | `python lab2_minirag.py "¿Cuántos libros…?"` | `verif-09-lab2-con-contexto.log` | `918a22e1…2f77b` | **corregido** — corre de punta a punta; placeholder `VERIFICAR` reemplazado por la respuesta real del banco (cita cifra y fuente correctas); similitudes del corpus sembrado (0,421/0,421/0,362) y narrativa ajustada: el top-1 real es el distractor, el pasaje correcto llega 2.º por <0,001 |
| 5 | Lab 2 — contraste sin contexto (banco) | `python lab2_minirag.py "…Alborada…" --sin-contexto` | `verif-09-lab2-sin-contexto.log` | `ed2d15e7…49bbc` | **corregido** — placeholder reemplazado; el modelo admite no conocer la política y rellena con rangos genéricos (3–5 libros, 15–30 días): el comportamiento que el texto exigía verificar |
| 6 | Lab 3 — chunking a dos tamaños | `python lab3_chunking.py` | `verif-09-lab3.log` | `e436fe09…8247c` | **corregido** — corre; cifras actualizadas al corpus sembrado (15 chunks/149 y 3/749; lluvia 0,633 vs 0,530; pregunta 1: distractor 0,421 en chico, pasaje correcto 0,512 en grande); la lección del texto se mantiene y sale reforzada |

Cifras con protocolo (M3): los tres bloques «Protocolo de la cifra» quedaron actualizados a las
corridas reales (motor, digest del generativo, fechas); el claim «~470 MB» de la descarga del
modelo de embeddings se midió: 458 MiB de caché HF — compatible con «unos 470 MB».

Afirmaciones ancladas con comando: `/api/embed` (corrida 1); `/api/chat` con
`options.temperature` y `stream:false` funciona como el código lo usa (corridas 4 y 5);
`IndexFlatIP` + vectores normalizados devuelve cosenos en [−1,1] coherentes.

## Totales

- Verificados sin cambio: **2** (nota previa `/api/embed`; lab 1 — reproducción exacta).
- Corregidos (texto/cifras al valor real, el código no cambió): **3** (lab 2 con contexto,
  lab 2 sin contexto, lab 3) + corpus transcripto en §3.2 + front matter `entorno_validado`.
- Ilustrativos: **0**. Bloqueos: **0**.

Ningún script del documento necesitó modificación: los tres corren tal cual están transcriptos.

## Dudas para el PO

Sin dudas. (Observación menor, no bloqueante: la salida «con contexto» del lab 2 muestra un
empate a tres decimales 0,421/0,421 entre distractor y pasaje correcto; el documento ahora lo
explota didácticamente, pero una futura corrida con otra versión del modelo de embeddings puede
invertir ese orden — el corpus transcripto fija la reproducibilidad con las versiones fijadas.)

> Nota: `evidencia/local/` no está versionada (gitignored); sus logs no se publican y se identifican por su huella SHA-256.
