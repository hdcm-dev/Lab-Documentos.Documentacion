# Pull request de adopción — descripción (A-08 y A-13)

Traza a `FIC-DISENO-DOCUMENTAL`. **Lleva reserva**: D-03, D-09, D-12 y D-18 (jerarquía y API) siguen abiertas; lo
fusiona una persona.

## 1. Línea de base (A-08)

Medida con la compuerta de origen (`dg.py` 471936d8…, `ci-local.sh` 5d07aed1…), sin red, el 2026-11-02.

| Control | Corpus | Línea de base | Estado |
| --- | --- | --- | --- |
| PR-1 enlaces | `docs/` | 0 | avisa (falta par rojo/verde propio) |
| PR-2 esquema | `docs/` | 0 errores, 1 aviso (`traces-vacio` en la ficha) | avisa |
| PR-3 anti-inyección | `docs/` | 0 | avisa |
| PR-4 estructura | `docs/` | 0 | avisa |
| PR-5 trazas | `docs/` | 0 | avisa; candidato a bloquear: par rojo/verde corrido (ficha §8) |
| PR-5 trazas | corpus heredado (`LG` y `LGD` enteros) | 995 errores: 960 `id-duplicado` (238 fuera de `_legacy/`), 35 `traza-mal-formada` | avisa; saneamiento aparte, P |
| PR-6 contrato | `docs/` | no aplica (sin `contracts/openapi.json`) | pendiente: falta el paso que extrae el OpenAPI en ejecución |
| PR-7 fijadas | `docs/` | 0 | avisa |

Prefijos heredados fuera del registro: 142 espacios en uso (comando 7); van al saneamiento aparte. Archivo de
excepciones: vacío, `.docs-guard/tools/docs-guard/excepciones.txt`. Reservas del índice: 98 líneas del comando 6, sin
clasificar.

## 2. Controles de entrega y de punto de uso (A-13)

Todos avisan: ninguno tiene par rojo/verde corrido.

| Control | Estado | Par rojo/verde |
| --- | --- | --- |
| `audiencia-vocabulario` | avisa | pendiente |
| `delivery-clave-cercana` | avisa | pendiente |
| `nivel-vs-repo` | avisa | pendiente |
| `cruce-de-audiencia` | avisa | pendiente |
| `indice-sin-fuga` | avisa | pendiente |
| `paquete-sin-fuga` | avisa | pendiente (sin paquetes instalables) |
| `ampliacion-de-acceso` | avisa | pendiente |
| `contrato-por-exposicion` | avisa | pendiente |
| `contexto-resuelve` | avisa | pendiente |
| `anclas` extendidas | avisa | pendiente |
| `traduccion-atrasada` | avisa | pendiente (un solo idioma) |
| `anti-inyeccion-en-recursos` | avisa | pendiente |
| Pruebas de entrega pareadas (alumno y administrador) | avisa | pendiente: 200 con contenido al autorizado y 403 al no autorizado, sin servicio levantado |
