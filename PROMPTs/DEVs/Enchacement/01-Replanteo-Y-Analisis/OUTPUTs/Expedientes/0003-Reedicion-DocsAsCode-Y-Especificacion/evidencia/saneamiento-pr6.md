# Saneamiento de la rama antes del PR (expediente 0003)

Barrido sobre los archivos que la rama cambia respecto de `main`. Los términos buscados viven en el área privada; aquí sólo van cantidades.

| Tipo | Ronda 1 (antes) | Ronda 2 (después) | Marcador aplicado |
|---|---|---|---|
| (a) Lista de barrido privada | 7 coincidencias en 6 archivos | 0 | `{servicio-privado}` (4, en tres informes de actuaciones), `{ruta-local}` (3, en evidencia de la ronda 2) |
| (b) Máquinas, rutas de área y rutas locales | 0 | 0 | — |
| (c) IP privadas | 15 en un inventario de la ronda 3 | 0 | `{ip-privada}` |
| (d) Servicio privado y dominios | incluido en (a) | 0 | — |

Admitidas sin cambio, porque no son direcciones privadas reales: `10.0.2.2` (alias del emulador de Android, explicado así en el texto citado; 15 apariciones) y números de versión con forma de IP (SDK de Windows y *workload set* de .NET; 21 apariciones).

No se borró ningún archivo.

## Huellas

Se modificaron archivos de evidencia (la ronda 2 y un inventario de la ronda 3). Sus huellas sha256 publicadas ya no coinciden con estas copias: los sellos refieren a los originales, que se conservan en el área privada.
