# Folio 004 — Providencia: el PO confirma el banco de pruebas my-ai en infravm

| Campo | Valor |
| --- | --- |
| Tipo | providencia |
| Fecha | 2026-11-07 |
| Autor | presidencia de la mesa |
| Corrige | — |

## Testimonio

> si tenes las apis myai en  infravm  para hacer pruebas

Canal: sesión interactiva con la presidencia · Fecha-hora: 2026-11-07 (mientras corría la ronda de
estructura) · Quién: el PO · Huella SHA-256 (texto con salto final, E-8): b69fbbab7fc12d2773c826dfa65f0040bf6f9b259f59ca9b808b7498ad41c8a5

## Clasificación y efecto

Es una confirmación dentro de la competencia de quien pidió: ratifica como banco de pruebas las APIs
de my-ai en infravm, que el contrato de entrada (folio 002, MEDIOS) ya usaba por verificación propia.
No toca el objetivo ni lo dado por fijo: no se rehace el enunciado ni se relanza ningún despacho.

Verificación del despacho que agrega esta providencia:
- API nativa de Ollama: `GET /api/tags` → 200; once modelos (qwen3-coder:30b, qwen3.5:35b-a3b,
  qwen2.5:14b/7b-instruct, qwen2.5-coder:14b/7b/3b-base, qwen2.5vl:7b, qwen3.5:4b, gpt-oss:20b,
  gemma4:e4b-it-qat); versión 0.32.0-rc0.
- Capa OpenAI-compatible del mismo Ollama: `GET /v1/models` → 200, sin clave.
- Open WebUI: `/api/models` → 401 (requiere clave de API; no se usa sin pedirla); su uso queda
  opcional y sólo si un ejemplo lo necesita, con credencial pedida al PO en el momento.
Los ejemplos de la guía pública usan `localhost`; el host real del banco no se versiona.

Sigue: veredicto de la ronda de estructura (despacho jurado-veredicto, en curso) · despachos
abiertos: workflow mesa-ronda-estructura (cinco comisiones, refutador, jurado, bitacorista) ·
insumos: folios 001–003 · si se corta acá, nada se invalida: esta providencia sólo suma medios.
