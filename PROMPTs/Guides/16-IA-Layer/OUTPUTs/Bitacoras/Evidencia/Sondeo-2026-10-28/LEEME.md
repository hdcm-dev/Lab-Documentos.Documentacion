# Crudos del sondeo del 2026-10-28 (copia del insumo)

> **2026-10-29 — Recuperación (B-02, paso 2.6, REC-06.4; procedencia PB-03).** Copia de `$INSUMO/Bitacoras/Sondeo-Evidencia/2026-10-28/`, después de la compuerta R-PRIV (0 direcciones y 0 endpoints: el endpoint siempre salió de `OLLAMA_ENDPOINT` y nunca se imprimió). Único cambio: la línea 2 de `sondeo.py` nombra la estación por su rol («estación 1»), no por el equipo; por eso su sha256 difiere del original (los dos están en `Procedencia.md`). Los `salidas/*.jsonl`, `cifras.py` y `cifras-2026-10-28.md` son idénticos al origen. Lo explica el §R de [`../../Sondeo-Entorno.md`](../../Sondeo-Entorno.md).
>
> **`cifras.py` corre desde `$INSUMO/Bitacoras/`, no desde acá:** 8 de sus 13 fuentes (`Integracion-Evidencia/…`, `Mesa/Ciclo-1/evidencia-*`) viven sólo en el insumo. Regenerado allí el 2026-10-29 (`python3 -I -B Sondeo-Evidencia/2026-10-28/cifras.py`), da byte por byte `cifras-2026-10-28.md`.
