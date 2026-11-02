# E8 · Guía y ejemplos con Geometría — registro

> Etapa E8 del plan integrado (`../05-Plan-Integrado.md` §5 E8). Fecha: 2026-11-01. Registro de sólo agregado.
> `{guía}` = carpeta de la guía 16 en Lab-Documentos; `{wt}` = worktree de E5 en Lab-Geometria (rama local `g16/ai-layer-v1`, sin push).

## Índice

- [1. Resumen](#1-resumen)
- [2. Entradas](#2-entradas)
- [3. Cambios](#3-cambios)
- [4. Criterios de aceptación](#4-criterios-de-aceptación)
- [5. Compuertas](#5-compuertas)
- [6. Decisiones de redacción](#6-decisiones-de-redacción)
- [7. Pendientes y avisos](#7-pendientes-y-avisos)

## 1. Resumen

El esqueleto del capítulo 16 que dejó E3 se reemplazó por el capítulo completo «Caso aplicado: Geometría» (16.1–16.7, patrón D-09 a con Decisión, una tabla por sección, un mermaid). No hay Example 18 (D-27 b: nada se construyó en Geometría). El vínculo Conocimiento → caso → capítulo quedó explícito en las dos direcciones.

## 2. Entradas

| Entrada | Valor |
|---|---|
| Libro al empezar | sha256 `425ed9b27704f95ffdfdbae02fcf67aee8099b089068ded7e36e0b676fc3b680` (cierre de E3) |
| Expediente 0002 y `ai-layer/` | `{wt}` en `b4832d4` (sobre `origin/main` `5f07b12`); leídos V1, V2, ADR, `ensayos/Resultado.md`, actuación 004 |
| E5 | `../Ejecucion/E5.md` (K-01…K-14, ensayo) |
| Conocimiento v1 | sha256 `a19d8d29…f2b3` (E7), §13 [Caso G] y R-02, R-04 |
| Decisiones | D-26 c, D-27 b, C-6.1…C-6.7, U-6.1…U-6.3 |

## 3. Cambios

| Archivo | Cambio | sha256 final |
|---|---|---|
| `{guía}/Dot-Net-Integration-AI-Layer-Guide.md` | cap. 16 completo; índice 0.0 sin «(en redacción)»; REF-207 (Lab-Geometria, commit `5f07b12`) | `7d88e28f94eed658592e254cf98f558acbc554ff7c86c8a782e4ce93d334aa1d` |
| `{guía}/Conocimientos/knowledge-AI-Layer-Integration-Designing-Specification.md` | fila [Caso G] de §13: «recorrido inverso en el capítulo "Caso aplicado: Geometría" de la guía» (misma línea; 599 líneas) | `0eca9c5516f1ce2d7cfb7e5bf35ba2bb19c604e5b6fd5e96ef2b5d6db2d3206c` |

Contenido del capítulo: 16.1 dominio, V1/V2 (tabla 16.1), cuatro preguntas, figura 16.1, minimización, endpoint propio; 16.2 el caso frente a ESC-01…05 (tabla 16.2) y contextos; 16.3 sin Example 18, mapa pieza → ejemplos 01, 02, 03, 15, 16 (tabla 16.3) y el ensayo de V1 como conducta; 16.4 ADR-IA-01…06 frente a ADR-01, 02, 07, 08, 11 (tabla 16.4) y dos aportes (prueba que nombra el SDK; *rechazado* cae a plantilla); 16.5 tres preguntas guía; 16.6 criterios y dos antipatrones; 16.7 Conocimiento → caso → capítulo.

## 4. Criterios de aceptación

| Criterio | Resultado |
|---|---|
| Extensión dentro del tope votado | Parte VII 7.131 / 7.600; total 59.096 / 60.000; todas las Partes bajo su tope (`Evidencia/contar.final`) |
| Todo enlace a Lab-Geometria resoluble | 5/5 URL con HTTP 200, fijadas al commit `5f07b12` de `main`. La carpeta `ai-layer/` y el expediente 0002 **no** se enlazan: siguen en la rama local sin push; el texto lo dice |
| 0 menciones del caso privado | 0 en el capítulo (grep de nombres de servicio, hosts, IP, rutas); el capítulo no lo cita ni en abstracto |
| Vínculo Conocimiento → caso → capítulo | 16.7 enlaza al Conocimiento y nombra [Caso G]; el Conocimiento remite al capítulo |

## 5. Compuertas

| Compuerta | rc | Resultado |
|---|---|---|
| `tools/verificar-markdown.py guia` | 0 | 0 rotos (una REF-202 duplicada detectada y corregida a REF-207) |
| `tools/verificar-markdown.py ejemplos Examples` | 0 | 18 archivos |
| `tools/compuerta-referencias.sh` | 0 | 0 rotas en 21 archivos (dos code spans corregidos) |
| `tools/compuerta-rpriv.sh` (libro y Conocimiento) | 0 | 0 hallazgos, clases genéricas |
| `tools/compuerta-intervalos.py` | 0 | 28/28 en el mapa, 21/21 filas; las cifras nuevas se escribieron sin forma k/M (criterio de E3) |
| `tools/compuerta-cabeceras.sh` (`Bitacoras/Evidencia`) | 0 | 0 en 2 cuerpos |
| `tools/medios/mermaid.sh` (cap. 16 y Conocimiento) | 0 | 1/1 y ok |
| mermaid-arroba (a mano: `dg.py` no tiene el subcomando, rc 2) | — | 0 arrobas, 0 `#64;` |
| docs-guard `fuera` | 0 | verde |
| docs-guard `esquema`, `ai` | 1 | 12 y 83 errores, iguales a la línea base del libro anterior (comparado sobre copia) |
| anclas | — | conjunto de ids idéntico al de E3; 0 repetidas |
| `tools/contar.sh` | 0 | ver §4 |
| `tools/verificar.sh build`, turno `build` (`[gestor-de-turnos]`, dueño `g16-e8`) | 0 | `Evidencia/verificar-build.log` |

Sumas: `Evidencia/SHA256SUMS`. Rutas locales de los logs reemplazadas por «[ruta local]».

## 6. Decisiones de redacción

- Sin Example 18 y sin variante del Example 10 (D-27 b; lo de c quedó fuera de la pasada).
- El ensayo se cuenta como conducta (P-10) y sin forma k/M para no sumar filas al mapa de intervalos; la proporción 24 de 30 se escribe «cuatro de cada cinco» (exacta).
- ESC-GEO-01/02 se presentan como códigos propios del caso, frente a la tabla del libro (K-01).
- Ningún texto de la especificación se transcribe: sólo las decisiones, con remisión a lo publicado.

## 7. Pendientes y avisos

- Al fusionar la rama `g16/ai-layer-v1` en Lab-Geometria (E-04, PO), conviene sumar al capítulo los enlaces a `ai-layer/` y al expediente 0002.
- El Conocimiento usa la numeración de secciones de la 0.11.0 en sus `[Guía §x]` (p. ej. §13.2 = hoy §14.2): para E9/E10.
- Utilidad docente (REQ-IA-13) sigue NO EJECUTADO.
- Mensajes ajenos durante la etapa: ninguno.
