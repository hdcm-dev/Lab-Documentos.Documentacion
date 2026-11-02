# Evidencia del implementador ingenuo / desarrollador de código (ciclo 1, 2026-10-28, estación 1)

Fuentes de las sondas propias (sin bin/obj) y salidas crudas citadas como K1…K10 en `../Informe-implementador-desarrollador.md` §2.

- `build.sh`, `run.sh`, `runnet.sh`: compilan y corren cada sonda en `mcr.microsoft.com/dotnet/sdk:10.0` (SDK 10.0.403) con la caché NuGet en `<TRABAJO>/nuget`. `<TRABAJO>` es el directorio de intermedios fuera del workspace. Se corrieron por `<envoltorio-de-turnos> build` y, las que llaman al modelo, por `<envoltorio-de-turnos> <recurso-compartido>`. `runnet.sh` toma el endpoint sólo de `OLLAMA_ENDPOINT` y lo borra de la salida (R-PRIV).
- `snippetsN6/`: N6 §4.1–§4.4 literales (K1). `numctx/`: `num_ctx` y `Usage` con HTTP falso (K8). `numctxreal/`: lo mismo contra `qwen2.5:0.5b` (K9; `LINEAS=300` y `LINEAS=100`). `dimconfig/`: sonda negativa CS0182 (K7).
- `build-1.txt`…`build-4.txt`, `run-1.txt`, `numctx-real.txt`, `numctx-real-100.txt`, `api-ps.txt`, `localhost-simulacion.txt`: salidas.
- Las sondas de la bitácora (sonda B, X1, exp-capas, compilecheck de N4, V1 de N3) se compilaron desde copias de sus carpetas; no se duplican acá.
