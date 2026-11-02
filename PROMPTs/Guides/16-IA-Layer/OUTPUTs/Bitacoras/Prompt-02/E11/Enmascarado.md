# E11 — Enmascarado de la bitácora de la guía 16

- **Fecha:** 2026-11-02. **Decisión del PO:** la bitácora se publica enmascarada (ver `../00-Coordinacion-Entre-Sesiones.md`).
- **Alcance:** todo `OUTPUTs/` (2743 archivos). No se tocaron los prompts del PO (`01-Crear-IA-Layer-Guide.md`, `02-*.md`, `INPUTs/`).
- **Resguardo previo:** copia íntegra sin enmascarar fuera de git, con `SHA256SUMS` (2743 líneas, sha256 del índice `2baf4428a452260f71cb95f5b14582742db7dc645e2042301c28943112aefe75`). Ubicación privada, no se cita.

## Qué se hizo

1. Sustitución por reglas fijas (texto UTF-8; binarios intactos): 132 archivos, 661 reemplazos. Tabla de marcadores en [`../../README.md`](../../README.md) (nota 2026-11-02), sin valores reales.
2. Renombres: la carpeta de la línea paralela → `Linea-Paralela-2026-10-28/` (y su `doc_id` → `BIT-16-LINEA-PARALELA`); en `Ronda-2/` de su ciclo 1, `Consulta-host-ia-ollama.md`, `evidencia-host-ia-ollama/` y `pc08/eval-host-dev.jsonl`, `eval-host-ia.jsonl`, `eval-host-ia-razonando.jsonl`. No había referencias por ruta al nombre viejo fuera del texto ya enmascarado.
3. Mapa de huellas: [`Enmascarado-Mapa-sha256.tsv`](Enmascarado-Mapa-sha256.tsv) — ruta, sha256 anterior, sha256 enmascarado, reemplazos y archivos que citaban el sha anterior (6 con cita, entre ellos dos `SHA256SUMS` de evidencia, que quedan desfasados a propósito: valen contra el resguardo).

## Compuerta R-PRIV (`tools/compuerta-rpriv.sh` con las listas privadas)

| Corrida | rc | Hallazgos |
|---|---|---|
| Antes | 1 | 263 (ip-privada 41, host-lab 6, identificadores 216) |
| Después, listas tal cual | 1 | 41, todos `ip-privada` = versiones de ensamblado `10.11.0.0` / `10.0.0.0` (falso positivo RPRI-19); clases privadas 0 |
| Después, con esas dos versiones declaradas históricas (copia local de las listas) | **0** | 0 |

Filtro de términos privados sin distinguir mayúsculas (lista completa, más el servicio privado de notificaciones y la API de modelos): 0. Nombres de archivo con nombres de equipos: 0.
