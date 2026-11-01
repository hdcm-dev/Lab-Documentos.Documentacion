# Registro de la reedición 04 — estado final

**Fecha:** 2026-11-01 · **Rama:** `fc/libro-guia-desarrolladores` (sin commitear)

## Entregables
| Entregable | Archivo (relativo a `Concepts/Framework-Concept/`) | Estado |
|---|---|---|
| Libro unificado | `MAUI-Framework-Developer-Guide.md` (≈2860 líneas, front matter `FC-GUIA-LIBRO`) | listo como borrador |
| Conocimiento | `Conocimientos/Knowledge-App-Hibrida-OTA-Offline-First.md` v1.0 + `Conocimientos/README.md` | listo |
| Bitácoras | `00-Acta…`, `01-Nucleos`, `02-Cohesion-Global`, `03-Plan`, `04-Rondas`, `05-Conocimiento`, `Nucleo-N1…N9` | completas |

## Verificación adversarial final
- 30 citas `Demo/archivo:líneas` del libro muestreadas al azar y contrastadas con el código: todas respaldan lo dicho (contrato del puente, vigencia 30/7 días, `CargasSinListoParaFallar = 2`, cinco tablas, sin AOT, backoff 5 s–10 min, Keystore con timeout 0, etc.).
- 207 citas a `Demo/` del libro y 15 del Conocimiento: rutas existentes y rangos de líneas dentro del archivo (un falso positivo por ruta abreviada, verificado).
- 53 referencias `[Libro §x]` del Conocimiento: todas las secciones existen. Anclas del índice y enlaces relativos: sin rotos.
- Propuesta vs. hecho: E04/V1/V1S marcados VARIANTE NO FUSIONADA; dictámenes 050, 054, 055, 058 presentados como dictamen; porcentaje, pool, rotación de claves y economía por tipo de red marcados **propuesta** o NO VERIFICADO.
- Fugas: sin rutas del home, IPs de tailnet, series de teléfono ni proyectos privados.

## Correcciones de esta pasada
1. Libro §9.5 y tabla de paradigmas: «Mercado Libre usa SDUI» pasaba de observación ([OBS] en folio 058) a hecho; ahora dice «según lo observado».
2. Conocimiento §8: la cifra del arranque superpuesto (4,8–5,6 s) omitía que es en régimen; se agregó la primera corrida o recién instalado (7,9–9,6 s).

## Pendientes (no bloquean)
- Mermaid sin renderizar (requiere Chromium en contenedor; negociar recursos).
- Fechas de consulta de R16–R62 sin reverificar.
- La mesa fue de una sola pasada, sin subagentes separados.
- Las propuestas del pool (§7.1 del Conocimiento) necesitan una mesa del producto.

**Veredicto:** listo para PR como borrador.
