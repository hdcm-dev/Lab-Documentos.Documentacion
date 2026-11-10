# Constancia de verificación técnica — Núcleo 09, cierre de deuda PD-02 (revisión del modelo de embeddings)

Documento: `Guides/IA/IA-Model/09-Bases-Vectoriales-Y-RAG.md` · Verificador técnico ·
2026-11-10 · Folio de habilitación: 022 (providencia de reapertura, decisión 3)

## Entorno

Contenedor `python:3.12.16-slim` (Python 3.12.16) sobre Docker, venv propio dentro del área de
trabajo `<area-agentes>/g18-pd02`; único paquete instalado: `huggingface_hub==0.36.0` (alcanza
para la observación: descarga del snapshot y consulta de la revisión; no hace falta cargar el
modelo). Nada instalado en el host. Caché HF fresco y descartable dentro del área.

## Comando

```
docker run --rm -v <area-agentes>/g18-pd02:/trabajo -w /trabajo python:3.12.16-slim \
  bash -c "python -m venv /trabajo/venv-c && /trabajo/venv-c/bin/pip install -q huggingface_hub==0.36.0 \
           && /trabajo/venv-c/bin/python -I observar_revision.py"
```

`observar_revision.py` consulta `model_info("sentence-transformers/paraphrase-multilingual-MiniLM-L12-v2").sha`
y hace `snapshot_download` a un caché vacío, imprimiendo el nombre del directorio de snapshot.

## Revisión observada (dato observado, no citado)

- `model_info().sha` = `e8f8c211226b894fcb81acc59f3b34ba3efd5f42`
- Directorio de snapshot del caché: `.../snapshots/e8f8c211226b894fcb81acc59f3b34ba3efd5f42`
- **Coinciden** (el script lo verifica e imprime `COINCIDEN`). Descarga fresca: 28 archivos.

## Evidencia

Log crudo: `evidencia/local/verif-09b-revision.log` (gitignored, no se publica)
SHA-256: `364d30a72c8364d3f1975a9f0611da79189889b891a02b7b5d02b9df08762477`

## Cambios al documento

En `<worktree-guia>/Guides/IA/IA-Model/09-Bases-Vectoriales-Y-RAG.md`:

1. En cada uno de los TRES bloques «Protocolo de la cifra» (§3.1, §3.2 y el del lab 3 de chunking)
   se agregó, debajo de la línea **Modelo**, la línea:
   `- **Revisión del modelo**: e8f8c211226b894fcb81acc59f3b34ba3efd5f42 (observada en descarga del 2026-11-10)`
2. Descargo de vigencia de §3.1: «la revisión del modelo con que se corrió la verificación» →
   «la revisión fijada en el protocolo».
3. Descargo de §3.2: «la revisión del modelo de *embeddings* con que se verificó la corrida» →
   «la revisión del modelo de *embeddings* fijada en el protocolo».

No se tocaron salidas verificadas, cifras, código ni el eje del documento (biblioteca local); la
disponibilidad nueva de embeddings en el banco quedó asentada en el folio 022, no acá.

## Veredicto

PD-02 **cerrada**: revisión fijada con dato observado en los tres protocolos; descargos ahora
remiten a una revisión concreta.

> Nota: `evidencia/local/` no está versionada (gitignored); sus logs se identifican por su huella SHA-256.
