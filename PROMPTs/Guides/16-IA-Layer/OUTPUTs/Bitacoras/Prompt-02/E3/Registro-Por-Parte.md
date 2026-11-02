# E3 · Registro por parte

Etapa E3 del plan integrado (`../05-Plan-Integrado.md` §5). Registro de sólo agregado: cada tramo suma su sección. Palabras medidas con `tools/contar.sh` de la guía; compuertas con su código de salida (rc).

## Índice

1. [Definiciones](#1-definiciones)
2. [Tramo 1 · Front matter, Prólogo y Parte I](#2-tramo-1--front-matter-prólogo-y-parte-i)
3. [Tramo 2 · Parte II · Marco](#3-tramo-2--parte-ii--marco)
4. [Tramo 3 · Parte III · Arquitectura y SDK](#4-tramo-3--parte-iii--arquitectura-y-sdk)
5. [Tramo 4 · Partes IV y V · Conocimiento y Agencia](#5-tramo-4--partes-iv-y-v--conocimiento-y-agencia)
6. [Tramo 5 · Parte VI · Producción](#6-tramo-5--parte-vi--producción)

## 1. Definiciones

- **Tramo:** porción del libro que un editor reescribe con el archivo abierto en exclusiva (I-09).
- **Antes / después:** recuento de `contar.sh` sobre la 0.11.0 (sha256 `c8defd8324497c4279a3dfd57ce5d2757326ad966813a9f9797d0196d9b7ce3d`) y sobre el libro al cerrar el tramo.
- **Tope por parte:** el que fija `tools/contar.sh` para que la suma dé el tope votado (60.000, `../E2/Medicion-Y-Tope.md` §7).

## 2. Tramo 1 · Front matter, Prólogo y Parte I

**Fecha:** 2026-11-01 · **Guía al cerrar:** sha256 `95d8b0d35cc9be999ada788ed7e4b90fac59e5b68d2e41859b5efdaf898d94c9` · **Bitácora del tramo:** `Tramo-1-Prologo-Parte-I.md`.

### 2.1 Palabras

| Parte | Antes (0.11.0) | Después | Tope nuevo |
|---|---|---|---|
| Encabezado (fuera del total) | 192 | 177 | — |
| Prólogo (ex Parte 0) | 2.178 | 2.199 | 2.200 |
| Parte I · Fundamentos (nueva) | 0 | 1.091 | 1.100 |
| Parte II · Marco (ex I, sin tocar) | 3.670 | 3.670 | 3.700 |
| Parte III · Arquitectura y SDK (ex II; sólo el rótulo) | 6.693 | 6.695 | 6.500 |
| Parte IV (ex III, sin tocar) | 6.409 | 6.409 | 6.300 |
| Parte V (ex IV, sin tocar) | 8.716 | 8.716 | 8.600 |
| Parte VI (ex V, sin tocar) | 8.895 | 8.895 | 8.800 |
| Parte VII (ex VI, sin tocar; suma el cap. 16 en E8) | 5.475 | 5.475 | 7.600 |
| Cierre | 3.076 | 3.076 | 3.100 |
| Anexos | 12.641 | 12.641 | 12.100 |
| **Total** | **57.753** | **58.867** | **60.000** |

Tabla 1. Recuento del tramo 1. El Prólogo creció 21 palabras pese a los recortes porque suma el patrón D-09 a, 0.6 (Conocimiento, U-2.3) y 0.7 (anclas); Fundamentos entra con 1.091 de las 1.500 presupuestadas (D-16 b), y las 409 que sobran se pasaron al tope del Prólogo. Las partes III a VI y los Anexos quedan sobre su tope nuevo: son los recortes (C-2.2, C-2.3, D-11 d, C-2.7) que les tocan a los tramos 2 a 6.

### 2.2 Compuertas

| Compuerta | Alcance | rc | Resultado |
|---|---|---|---|
| `tools/verificar-markdown.py guia` | libro entero | 0 | 318 anclas, 1.505 enlaces internos, 180/180 REF; 0 rotos |
| `tools/compuerta-referencias.sh` | carpeta de la guía | 0 | 0 referencias rotas en 21 archivos |
| `tools/compuerta-rpriv.sh` | libro (clases genéricas) | 0 | 0 hallazgos |
| `tools/compuerta-intervalos.py` | libro + `Evidencia/R-LLM` | 0 | 81 figuras, 81 en el mapa; 57/57 filas |
| `tools/compuerta-cabeceras.sh` | `Bitacoras/Evidencia` | 0 | 0 en 2 cuerpos (no lee el libro; sin cambios) |
| `tools/medios/mermaid.sh` | Prólogo y Parte I (3 diagramas) | 0 | 3/3 ok |
| control mermaid-arroba | los mismos 3 diagramas | — | 0 arrobas, 0 `#64;` |
| `tools/contar.sh` | libro | 0 | 58.867 / 60.000 (98 %) |
| anclas 0.11.0 conservadas | 283 ids de la 0.11.0 | — | 0 faltan; 0 ids repetidos; 35 nuevas |
| docs-guard `fuera` | libro | 0 | verde |
| docs-guard `esquema`, `ai` | libro | 1 | 12 y 83 errores, **los mismos que la 0.11.0** (línea base medida sobre una copia); ninguno en el tramo. `tope_palabras` no genera error |
| `tools/verificar.sh` completo | — | — | NO EJECUTADO: el plan lo pide al final de E3 |
| filtro U-7.1 (lista negra privada) | — | — | NO EJECUTADO: la lista vive sólo en el repo privado; R-PRIV genérica en 0 y el texto nuevo no nombra servicios, hosts ni rutas |

## 3. Tramo 2 · Parte II · Marco

**Fecha:** 2026-11-01 · **Guía al cerrar:** sha256 `e182b1458b936fa422ef6d34890d355c76f0ecc0705f9643140bcc7a70f155b9` · **Bitácora del tramo:** `Tramo-2-Parte-II-Marco.md`.

### 3.1 Palabras

| Parte | Antes (cierre del tramo 1) | Después | Tope |
|---|---|---|---|
| Parte II · Marco (caps. 2–4) | 3.670 | 3.687 | 3.700 |
| Anexos (recibe la Tabla C.1, ex §3.0) | 12.641 | 12.886 | 12.100 |
| Resto | sin cambios | sin cambios | — |
| **Total** | **58.867** | **59.129** | **60.000** |

Tabla 2. Recuento del tramo 2. La Parte II pierde §3.0 (≈ 250 palabras) y suma leyendas de tablas y figuras, citas a P-n y la frase de CL-02; queda bajo su tope. Los Anexos suben por la Tabla C.1, que el tramo de Anexos fusiona con el glosario (C-2.3).

### 3.2 Compuertas

| Compuerta | Alcance | rc | Resultado |
|---|---|---|---|
| `tools/verificar-markdown.py guia` | libro entero | 0 | 335 anclas, 1.513 enlaces internos, 180/180 REF; 0 rotos |
| `tools/compuerta-referencias.sh` | carpeta de la guía | 0 | 0 rotas en 21 archivos |
| `tools/compuerta-rpriv.sh` | libro (clases genéricas) | 0 | 0 hallazgos |
| `tools/compuerta-intervalos.py` | libro + `Evidencia/R-LLM` | 0 | 81 figuras, 81 en el mapa; 57/57 filas |
| `tools/compuerta-cabeceras.sh` | `Bitacoras/Evidencia` | 0 | 0 en 2 cuerpos (no lee el libro) |
| `tools/medios/mermaid.sh` | Parte II (5 diagramas) | 0 | 5/5 ok |
| control mermaid-arroba (a mano) | los mismos 5 | — | 0 arrobas, 0 `#64;` |
| `tools/contar.sh` | libro | 0 | 59.129 / 60.000 (99 %); Parte II 3.687 / 3.700 |
| anclas de la 0.11.0 + tramo 1 | 318 ids previos | — | 0 faltan; 0 repetidos; 17 nuevas |
| HE-11 / HE-01 en la Parte II | prosa | — | 0 / 0 |
| docs-guard `fuera` | libro | 0 | verde |
| docs-guard `esquema`, `ai` | libro | 1 | mismos mensajes que la línea base (diff vacío) |
| `tools/verificar.sh` completo | — | — | NO EJECUTADO: al final de E3 |

## 4. Tramo 3 · Parte III · Arquitectura y SDK

**Fecha:** 2026-11-01 · **Guía al cerrar:** sha256 `40a43163d0f7cd31657061f41e7630bf26b36ef62c9cf89a50032c2d509a9607` · **Bitácora del tramo:** `Tramo-3-Parte-III-Arquitectura-SDK.md`.

### 4.1 Palabras

| Parte | Antes (cierre del tramo 2) | Después | Tope |
|---|---|---|---|
| Parte III · Arquitectura y SDK (caps. 5–6) | 6.695 | 6.183 | 6.500 |
| Anexos (recibe la Tabla C.2, ex §4.1) | 12.886 | 13.083 | 12.100 |
| Resto | sin cambios | sin cambios | — |
| **Total** | **59.129** | **58.814** | **60.000** |

Tabla 3. Recuento del tramo 3. La Parte III pierde las Prácticas de §5 (al README), los 12 bloques Historia (al Anexo H) y §4.1 (al glosario), y suma el patrón D-09 a, las fichas, la excepción I-5 y leyendas; queda 317 bajo su tope.

### 4.2 Compuertas

| Compuerta | Alcance | rc | Resultado |
|---|---|---|---|
| `tools/verificar-markdown.py guia` | libro entero | 0 | 359 anclas, 1.514 enlaces internos, 180/180 REF; 0 rotos |
| `tools/compuerta-referencias.sh` | carpeta de la guía (incluye los README) | 0 | 0 rotas en 21 archivos |
| `tools/compuerta-rpriv.sh` | libro + README 01–04 (clases genéricas) | 0 | 0 hallazgos |
| `tools/compuerta-intervalos.py` | libro + `Evidencia/R-LLM` | 0 | 75 figuras, 75 en el mapa; 53/53 filas (salen I01–I04 con sus figuras Historia) |
| `tools/compuerta-cabeceras.sh` | `Bitacoras/Evidencia` | 0 | 0 en 2 cuerpos (no lee el libro) |
| `tools/medios/mermaid.sh` | Parte III (2 diagramas) | 0 | 2/2 ok |
| control mermaid-arroba (a mano) | los mismos 2 | — | 0 arrobas, 0 `#64;` |
| `tools/contar.sh` | libro | 0 | 58.814 / 60.000 (98 %); Parte III 6.183 / 6.500 |
| anclas previas | 335 ids al cierre del tramo 2 | — | 0 faltan; 0 repetidos; 24 nuevas |
| HE-11 en la Parte III | prosa | — | 0 |
| docs-guard `fuera` | libro | 0 | verde |
| docs-guard `esquema`, `ai` | libro | 1 | mismos mensajes que antes del tramo (diff vacío) |
| `tools/verificar.sh` completo | — | — | NO EJECUTADO: al final de E3 |

## 5. Tramo 4 · Partes IV y V · Conocimiento y Agencia

**Fecha:** 2026-11-01 · **Guía al cerrar:** sha256 `481260a6d307c897131ed8da17f025b62f5f8bae55eef4d5bf5b6efaad0f84c4` · **Bitácora del tramo:** `Tramo-4-Partes-IV-V-Conocimiento-Agencia.md`.

### 5.1 Palabras

| Parte | Antes (cierre del tramo 3) | Después | Tope |
|---|---|---|---|
| Parte IV · Conocimiento (caps. 7–8) | 6.409 | 5.861 | 6.300 |
| Parte V · Agencia (caps. 9–10) | 8.716 | 8.242 | 8.600 |
| Resto | sin cambios | sin cambios | — |
| **Total** | **58.814** | **57.792** | **60.000** |

Tabla 4. Recuento del tramo 4. Las Partes IV y V pierden las Prácticas de 05–13 (al README) y los 20 bloques Historia (al Anexo H), y suman el patrón D-09 a, las fichas, CL-06, CL-08, leyendas y citas a P-n; quedan 439 y 358 bajo su tope.

### 5.2 Compuertas

| Compuerta | Alcance | rc | Resultado |
|---|---|---|---|
| `tools/verificar-markdown.py guia` | libro entero | 0 | 410 anclas, 1.518 enlaces internos, 180/180 REF; 0 rotos |
| `tools/compuerta-referencias.sh` | carpeta de la guía (incluye los README) | 0 | 0 rotas en 21 archivos |
| `tools/compuerta-rpriv.sh` | libro + README 05–13 (clases genéricas) | 0 | 0 hallazgos |
| `tools/compuerta-intervalos.py` | libro + `Evidencia/R-LLM` | 0 | 47 figuras, 47 en el mapa; 36/36 filas (salen 17 filas con sus figuras Historia) |
| `tools/compuerta-cabeceras.sh` | `Bitacoras/Evidencia` | 0 | 0 en 2 cuerpos (no lee el libro) |
| `tools/medios/mermaid.sh` | Partes IV–V (8 diagramas) | 0 | 8/8 ok |
| control mermaid-arroba (a mano; `dg.py mermaid-arroba` da rc 2, subcomando inexistente en el repo) | los mismos 8 | — | 0 arrobas, 0 `#64;` |
| `tools/contar.sh` | libro | 0 | 57.792 / 60.000 (96 %); IV 5.861 / 6.300; V 8.242 / 8.600 |
| anclas previas | 359 ids al cierre del tramo 3 | — | 0 faltan; 0 repetidos; 51 nuevas |
| HE-11 en las Partes IV–V | prosa | — | 0 |
| docs-guard `fuera` | libro | 0 | verde |
| docs-guard `esquema`, `ai` | libro | 1 | mismos mensajes que antes del tramo (diff vacío, sin números de línea) |
| `tools/verificar.sh` completo | — | — | NO EJECUTADO: al final de E3 |

## 6. Tramo 5 · Parte VI · Producción

**Fecha:** 2026-11-01 · **Guía al cerrar:** sha256 `5fc013c4239c3bc30f9a10ea9070881f4c976256df2ae39d0be7c0af7e821b67` · **Bitácora del tramo:** `Tramo-5-Parte-VI-Produccion.md`.

### 6.1 Palabras

| Parte | Antes (cierre del tramo 4) | Después | Tope |
|---|---|---|---|
| Parte VI · Producción (caps. 11–13) | 8.895 | 8.754 | 8.800 |
| Resto | sin cambios | sin cambios | — |
| **Total** | **57.792** | **57.651** | **60.000** |

Tabla 5. Recuento del tramo 5. La Parte VI pierde los 13 bloques Historia y la apertura del capítulo 13 (al Anexo H) y el código de los ejemplos (a los README; el código no cuenta en `contar.sh`), y suma el patrón D-09 a, las fichas, la prosa que reemplaza a cada bloque de código, leyendas y citas a P-n. La primera versión dio 9.129 y se recortó (bitácora §2.8). Queda 46 bajo su tope. Por capítulo (cuenta aproximada, sin código): 11 ≈ 2.830, 12 ≈ 3.370, 13 ≈ 3.000.

### 6.2 Compuertas

| Compuerta | Alcance | rc | Resultado |
|---|---|---|---|
| `tools/verificar-markdown.py guia` | libro entero | 0 | 451 anclas, 1.521 enlaces internos, 180/180 REF; 0 rotos |
| `tools/verificar-markdown.py ejemplos Examples` | README de ejemplos | 0 | 18 archivos; 0 enlaces rotos |
| `tools/compuerta-referencias.sh` | carpeta de la guía (incluye los README) | 0 | 0 rotas en 21 archivos |
| `tools/compuerta-rpriv.sh` | libro + README 03, 06, 08, 13, 15, 16, 17 + bitácora del tramo (clases genéricas) | 0 | 0 hallazgos |
| `tools/compuerta-intervalos.py` | libro + `Evidencia/R-LLM` | 0 | 42 figuras, 42 en el mapa; 32/32 filas (salen I22, I23, I24 y PV01-05a; PV01-05b/c con ancla nueva) |
| `tools/compuerta-cabeceras.sh` | `Bitacoras/Evidencia` | 0 | 0 en 2 cuerpos (no lee el libro) |
| `tools/medios/mermaid.sh` | Parte VI (4 diagramas) | 0 | 4/4 ok |
| control mermaid-arroba (a mano; `dg.py mermaid-arroba` da rc 2, subcomando inexistente en el repo) | los mismos 4 | — | 0 arrobas, 0 `#64;` |
| `tools/contar.sh` | libro | 0 | 57.651 / 60.000 (96 %); VI 8.754 / 8.800 |
| anclas previas | 410 ids al cierre del tramo 4 | — | 0 faltan; 0 repetidos; 41 nuevas |
| HE-11 / C-2.2 en la Parte VI | prosa | — | 0 «Historia», 0 «servidor compartido», 0 «Servidor retirado», 0 `qwen2.5` |
| Partes I–V y VII–Anexos | diff contra la copia al abrir el tramo | — | idénticas |
| docs-guard `fuera` | libro | 0 | verde |
| docs-guard `esquema` | libro | 1 | mismos mensajes que antes del tramo (diff vacío, sin números de línea) |
| docs-guard `ai` | libro | 1 | mismos 83 errores; avisos AI-3 de 6 a 5 (sale la frase del ataque que estaba en una salida Historia) |
| `tools/verificar.sh` completo | — | — | NO EJECUTADO: al final de E3 |

## 7. Tramo 6 · Parte VII, Cierre y Anexos

**Fecha:** 2026-11-01 · **Guía al cerrar:** sha256 `425ed9b27704f95ffdfdbae02fcf67aee8099b089068ded7e36e0b676fc3b680` · **Bitácora del tramo:** `Tramo-6-Parte-VII-Cierre-Anexos.md`.

### 7.1 Palabras

| Parte | Antes (cierre del tramo 5) | Después | Tope |
|---|---|---|---|
| Prólogo | 2.199 | 2.197 | 2.200 |
| Parte VII · Integración (caps. 14–16) | 5.475 | 5.520 | 7.600 |
| Cierre (cap. 17) | 3.076 | 3.078 | 3.100 |
| Anexos A–H | 13.083 | 12.853 | 12.900 (antes 12.100) |
| Partes III, IV, V | 6.183 · 5.861 · 8.242 | sin cambios | 6.300 · 6.000 · 8.300 (antes 6.500 · 6.300 · 8.600) |
| **Total** | **57.651** | **57.466** | **60.000** |

Tabla 6. Recuento del tramo 6. Los Anexos pierden los bloques Historia y condensan E.3, E.5, E.6 y G, y suman el Anexo H (262), E.8 y la columna ADR-01; la Parte VII suma el esqueleto del capítulo 16 y las citas a P-n. Redistribución de topes dentro de los 60.000: bitácora §4.

### 7.2 Compuertas

| Compuerta | Alcance | rc | Resultado |
|---|---|---|---|
| `tools/verificar-markdown.py guia` | libro entero | 0 | 516 anclas, 1.555 enlaces internos, 180/180 REF; 0 rotos |
| `tools/verificar-markdown.py ejemplos Examples` | README | 0 | 18 archivos, 0 rotos |
| `tools/compuerta-referencias.sh` | carpeta de la guía | 0 | 0 rotas en 21 archivos |
| `tools/compuerta-rpriv.sh` | libro, tools tocadas, bitácora y evidencia del tramo | 0 | 0 hallazgos (clases genéricas) |
| `tools/compuerta-intervalos.py` | libro + `Evidencia/R-LLM` | 0 | 28 figuras, 28 en el mapa; 21/21 filas (salen 11) |
| `tools/compuerta-cabeceras.sh` | `Bitacoras/Evidencia` | 0 | 0 en 2 cuerpos |
| `tools/medios/mermaid.sh` | Parte VII y Anexos (3 diagramas) | 0 | 3/3 ok |
| mermaid-arroba (a mano) | los mismos 3 | — | 0 arrobas, 0 `#64;` |
| docs-guard `fuera` | libro | 0 | verde |
| docs-guard `esquema`, `ai` | libro | 1 | mismos mensajes que antes del tramo (12 y 83 errores) |
| `tools/contar.sh` | libro | 0 | 57.466 / 60.000 (96 %); todas las partes bajo su tope |
| anclas previas | 451 ids | — | 0 faltan, 0 repetidas, 65 nuevas |
| HE-11 / C-2.2 | región del tramo | — | 0 «Historia»; «servidor retirado», `qwen2.5` sólo en el Anexo H |
| `tools/verificar.sh build` completo, con turno `build` del gestor (`[gestor-de-turnos]`), SDK 10.0.403 | todo `Examples/` | 0 | compila con -warnaserror, pruebas sin servidor y consolas `--fake --verificar` en verde; log en `Evidencia-Tramo-6/verificar-build.log` |
