# Constancia de verificación técnica — Núcleo 10 (Multimodalidad y generación no textual)

- **Documento**: `Guides/IA/IA-Model/10-Multimodalidad-Y-Generacion-No-Textual.md` (worktree guía)
- **Fecha**: 2026-11-07 · **Banco**: Ollama del banco de ensayo (en el texto, `$OLLAMA_HOST`/`localhost`)
- **Evidencia cruda**: `evidencia/local/verif-10-*.{log,png}` (este expediente; fuera del versionado)

## Corridas

### 1. Paso 0 — banco accesible (§3) — VERIFICADO
- Comando: el `curl` de §3 tal cual (con `OLLAMA_HOST` apuntando al banco).
- Salida: `banco accesible`.
- Evidencia: incluida en `verif-10-banco.log` (versión y ficha).

### 2. Entorno declarado (§3, front matter, protocolos M3) — VERIFICADO
- Comando: `GET /api/version`, `POST /api/show {"model":"qwen2.5vl:7b"}`, `GET /api/tags`.
- Extracto: `{"version":"0.32.0-rc0"}`; details `parameter_size: 8.3B`, `quantization_level: Q4_K_M`;
  digest `5ced39dfa4bac325dc183dd1e4febaa1c46b3ea28bce48896c8e69c1e79611cc`;
  `capabilities: ["completion","vision"]` (confirma también el caso de §1.1 y el ítem del anexo §6).
- Log: `verif-10-banco.log` — SHA-256 `44bc9932db7e4233fcfda0d978cc2de3ae981ac9c3867b950266e68da706c3b4`.
- Veredicto: todas las cifras del doc (motor, digest, parámetros, cuantización) coinciden.

### 3. Script `escena.py` (§3.1, primer paso) — VERIFICADO
- Comando: el script del doc, sin cambios, Python 3.11.2 en venv-less stdlib.
- Salida: `escena.png: 480x320, 1946 bytes` — **idéntica byte a byte a la pegada en el doc**.
- Inspección visual del PNG: círculo rojo, cuadrado azul, dos triángulos verdes arriba a la
  derecha con vértice hacia abajo — la verdad sembrada es la declarada.
- Log: `verif-10-escena.log` — SHA-256 `9919cf6900020beebf198920b501050bb582ef0ed299e75d1020efec6838a64c`.
- PNG: `verif-10-escena.png` — SHA-256 `2f3368e82244933c2fc54159730e95ef50b3f4f75018f86df1f32a2cc7b40587`.

### 4. Lab 10-A — describir la escena sembrada (§3.1) — VERIFICADO (salida pegada)
- Comando: el script del doc, `qwen2.5vl:7b`, temperature 0.2, seed 42, contra el banco.
- Extracto: «La imagen contiene tres figuras geométricas: 1. Un círculo rojo. 2. Un cuadrado
  azul. 3. Dos triángulos verdes (uno arriba del otro).» · `eval_count: 45` · 46,2 s totales.
- Log: `verif-10-lab10a.log` — SHA-256 `2f2a0a65a4257fdf1d19461b116404e10677c7f0f6adaf6e0109a6aaee00cada`.
- Nota: la salida enumera las 4 figuras bien y declara «tres» en el encabezado (contó formas,
  no figuras): es el conteo frágil que el propio doc anticipa; agregué dos oraciones en el paso
  tres leyendo ese desajuste. Protocolo M3 completado (CTX-03, fecha, duración).

### 5. Lab 10-B — preguntas capciosas (§3.2) — VERIFICADO (salida pegada)
- Comando: el script del doc, mismas opciones, contra el banco.
- Extracto: ambas respuestas son negaciones correctas («La imagen no contiene una estrella…»,
  «No hay círculos amarillos…»); el modelo pasó la prueba en esta escena y corrida.
- Log: `verif-10-lab10b.log` — SHA-256 `f7e475b6a42cffd5f7df9e36a50ca2cf699eca4fca3f4cc03ecacdb8bdaafa8c`.
- Nota: agregué una oración en «Cómo se lee el resultado» con el hecho de la corrida de
  referencia, manteniendo la advertencia de no generalizar. Protocolo M3 completado.

### 6. §3.3 Difusión — ILUSTRATIVO (correcto como está)
- Marcado `**[ilustrativo]**` con motivo (el banco no sirve difusión; alcance §1.5, folio 011).
  Sin comando operable; no requiere corrida. Sin cambios.

## Ediciones al documento
1. Front matter `entorno_validado`: «corrida completa pendiente…» → corridas verificadas 2026-11-07.
2. §3.1: salida real pegada + protocolo completado + 2 oraciones de lectura de la corrida.
3. §3.2: salida real pegada + protocolo completado + 1 oración con el hecho de la corrida.
4. Sin otros cambios de fondo; ningún marcador `VERIFICAR` queda en el doc; sin rutas de host ni
   URL del banco en el texto versionado.

## Resumen
- Verificados: 5 (paso 0, entorno/cifras, escena.py, lab 10-A, lab 10-B)
- Corregidos: 0 · Ilustrativos: 1 (§3.3) · BLOQUEO: 0

## Dudas para el PO
Sin dudas.
