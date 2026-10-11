# Evidencia del cuerpo auditor (ciclo 1)

Experimentos que el auditor corrió el 2026-10-09 para respaldar afirmaciones nuevas de `03-Parches.md`. Corren fuera del laboratorio de la guía; los parches dicen qué se incorpora a `Examples/`.

| Carpeta | Parche | Qué muestra |
|---|---|---|
| `lock-solo-ejecutables/` | P-16 (C1-26) | La condición `'$(OutputType)' == 'Exe'` no surte efecto en `Directory.Build.props` (OutputType aún vacío) y sí en `Directory.Build.targets` (SDK 8.0.425). |
| `nu1603-sdk10/` | P-10 (C1-02, C1-03; cierra C1-Q09) | El E1 del abogado del diablo repetido con SDK 10.0.400: sin lock, `NU1603` como error corta (rc=1); con lock, rc=0 y el lock congela 9.0.0. |
| `locks-multiplataforma/` | P-10 (C1-58) | `pnpm-lock.yaml` (pnpm 10.18.0) y `yarn.lock` (Yarn 4.10.3) registran las 26 variantes de `@esbuild/*` con `cpu`/`os` e instalan sólo `linux-x64`. |
| `a10-node24/` | P-16 (C1-13) | A.10 con `node:24-bookworm-slim` por digest construye; misma glibc 2.36 que `sdk:8.0`; la plantilla `web/` pasa `devEngines`. |
