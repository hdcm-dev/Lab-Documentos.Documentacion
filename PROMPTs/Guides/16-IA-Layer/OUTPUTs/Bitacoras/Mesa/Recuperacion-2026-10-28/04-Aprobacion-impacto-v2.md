---
doc_id: BIT-16-REC-04-IMPACTO-V2
doc_type: aprobacion-de-plan
title: Aprobación del plan de recuperación, vuelta 2 — juez de impacto (mesa de recuperación, 2026-10-28)
status: APROBAR
origin: agent (jurado, juez de impacto)
last_review: 2026-10-29
---

# Aprobación del plan, vuelta 2 · juez de impacto (2026-10-28, re-verificada el 2026-10-29)

**Qué revisé.** El §4 de [`03-Plan-De-Recuperacion.md`](03-Plan-De-Recuperacion.md) (Vuelta 2) y las filas del §2 marcadas «[V2 …]» (B-01 1.5 y 1.9, B-06 6.6 y 6.9, B-08 8.1, B-11 R-06 y Lectura), frente a mi aprobación de la vuelta 1 ([`04-Aprobacion-impacto.md`](04-Aprobacion-impacto.md): M-1…M-4 obligatorias, P-1…P-7 precisiones). El criterio es el mismo: qué le llega al lector de la guía (el que copia los ejemplos, el que reproduce lo rotulado como medido, el que busca un término y el que llega al repo público).

**Comprobaciones hechas (sólo lectura, re-corridas el 2026-10-29).**
- El sha256 de la guía sigue siendo `ee1e6ae2…0a16f` (0.10.1): el plan se aplica sobre la base que dice.
- `grep -c tool_choice` en la guía da 7, igual que el conteo de M-B/6.12.
- `grep -c OLLAMA_PROPIO_ENDPOINT` en la guía da 7. Fuera de los `.md`, la variable la usan siete archivos: `_Comun/…/AI/ConfiguracionDelModelo.cs`, `_Comun/…Pruebas/CapaDeOpcionesTests.cs`, `05/Program.cs`, `15/Program.cs`, `tools/verificar.sh` y, en la demo, `tools/demo.sh` y `ApiWebApplicationFactory.cs`.
- `⟦REC-02:F4-servidores⟧` aparece en 6.2 (§4.2, «donde va la tabla de tres servidores»), en 10.14 (F.4) y en la plantilla de 6.0 (M-J), donde ocupa el lugar de la **versión** de Ollama. Es el origen de P-9.
- Según `Inventario-entorno.md` §0, las dos estaciones vigentes corren Ollama 0.40.11 con el 4b `d8b0f5e9760c`. Por eso el patrón `0\.32\.0` de la compuerta de M-J no choca con ninguna mención legítima en presente, y el digest esperado de M-K es el digest público de un modelo, no un dato privado.

## Correspondencia con mis condiciones

| Mi pedido (v1) | Dónde quedó en la v2 | Estado |
|---|---|---|
| M-1 `tool_choice` | M-B y fila 6.9 [V2], con el paso 6.12 para las 7 apariciones, §8 y ADR en B-09 y B-10, y la compuerta en §4.6 | Incorporado, como texto del paso |
| M-2 variables sin defecto | M-A (todos los modos con modelo; `sin-servidor` sólo en `build` y `--fake`; rc ≠ 0 sin llamada HTTP; casos en `ArnesTests`). M-K lo amplía con la versión y los digests esperados | Incorporado y mejorado |
| M-3 plantilla de rótulo de §0.4 | M-J, paso 6.0, con forma corta idéntica a la de 12.1 y verificada por `diff` | Incorporado (ver P-9 y P-10) |
| M-4 «Ollama propio» y servidor retirado en §0.3 | M-J, pasos 6.0b y 6.13 con sus pares en B-07, B-09 y B-10; compuerta de los cinco patrones en 10.16 y 12.3 | Incorporado. Falta la línea sobre el nombre de la variable (ver P-8) |
| P-1 salida de REC-13 | M-E (10/10 seguidas, REC-13 C, DEU-08) | Incorporado |
| P-2 fracción mínima en R-15 | M-G, con «no es validación» verificable por `grep` | Incorporado |
| P-3 una estación por tasa | M-D, que además cubre partición, reintento, caída y exentas | Incorporado y mejorado |
| P-4 lector de prefijo | M-I (no persiste cuerpos, compuerta de cabeceras, rebuild n/n y `ArnesTests`) | Incorporado |
| P-5 tokenizador | M-F (prueba sin modelo, sin el detector que lanza, DEU-09 si no entra) | Incorporado |
| P-6 `estado_cache` | M-M | Incorporado |
| P-7 texto inyectado sintético | M-H | Incorporado |

## Decisión: APROBAR

Las cuatro correcciones obligatorias de mi vuelta 1 entraron como texto de paso, cada una con su verificación, no como nota. Las siete precisiones también entraron, y varias con más rigor del que pedí (M-D, M-K). Lo que recibe el lector queda protegido en los cuatro frentes que me importaban:

- No va a encontrar como hecho algo que nadie midió (`tool_choice`).
- No va a ver una cifra rotulada con un servidor que no la midió: las variables no tienen defecto y el digest se verifica dentro del turno.
- La plantilla que imita en toda la guía ya no remite a un artefacto retirado.
- Los servidores pasan a nombrarse por su papel.

Ningún punto cae en REED-16 §12. Las ganadoras no cambian, el §4 no contradice ninguna boleta y los otros cuatro jueces también aprobaron la vuelta 2. Cumplo la condición que dejé escrita («con M-1…M-4 incorporados, APROBAR sin otra revisión»): el voto pasa a **APROBAR**.

### Precisiones (no bloquean; se aplican en el paso indicado y se anotan en `04-Aplicacion.md`)

| # | Paso | Qué agregar | Por qué |
|---|---|---|---|
| P-8 | B-06 6.0b, y su par en A.12 (B-10) | Al nombrar los papeles EMB-A y EMB-B, agregar una línea: la variable `OLLAMA_PROPIO_ENDPOINT` conserva su nombre histórico porque la usan el código y los guiones (7 archivos), y hoy designa el papel «servidor aparte para embeddings y juez». La variable **no** se renombra, por la misma razón por la que m-2 no renombra la fase `lan`. | Era la última cláusula de mi M-4 y no llegó al texto. Sin esa línea, el lector ve «servidor aparte» en la prosa y `PROPIO` en el código, y no tiene cómo unirlos. Cuesta una oración. |
| P-9 | B-06 6.0 y B-12 12.1 | En la plantilla de §0.4, la versión de Ollama lleva su propio marcador (p. ej. `⟦REC-02:version-ollama⟧`), distinto de `⟦REC-02:F4-servidores⟧`, que en 6.2 y 10.14 marca el lugar de una **tabla**. La otra salida es que 12.1 deje escrito que en §0.4 ese marcador se llena sólo con la versión. | Evita que el relleno de B-12 meta la tabla de servidores dentro de la frase modelo o deje la versión vacía. |
| P-10 | B-12 12.1 y compuerta `diff` de M-J | La forma corta de 12.1 lleva **la fecha real del turno** (AAAA-MM-DD), no el literal «2026-10-2x». El `diff` de M-J compara la **forma** de las dos cadenas (campos y orden) después del relleno, no los valores. | Las corridas con modelo pueden caer el 2026-10-30 o después. Un literal «2026-10-2x» le daría al lector una fecha que no corresponde, y un `diff` de valores daría falso rojo entre la plantilla y una cifra concreta. |

## Lo que sigo aprobando sin cambios

Todo lo que aprobé en la vuelta 1: el orden B-00…B-15, el lote R-PRIV con el veto respetado, REC-07 C, REC-15 B, las deudas declaradas y las decisiones de B-15 en manos del PO (commit, publicación de la demo, paso a «publicada»). También la tabla de compuertas del §4.6 como lista de control de `04-Aplicacion.md`, y las deudas condicionales DEU-08 y DEU-09.
