# Constancia de verificación técnica — núcleo 01 (Representación del lenguaje)

- Documento: `Guides/IA/IA-Model/01-Representacion-Del-Lenguaje.md` (worktree de la guía)
- Verificador técnico, 2026-11-07
- Entorno de corrida: contenedor `python:3.12.16-slim` (Python 3.12.16), venv propio,
  `tiktoken==0.9.0` — idéntico al `entorno_validado` declarado por el documento.
- Los tres laboratorios son CTX-01 (CPU, biblioteca local); no usan el banco de inferencia, por lo
  que no hubo corridas contra Ollama.

## Evidencia cruda

| Log | SHA-256 |
| --- | --- |
| `evidencia/local/verif-01-corrida-completa.log` (labs 1–3 + verificaciones extra) | `df32952eee45bfbda67742d4f106be2c2cfc1511fb46818fe24a626657d20f94` |
| `evidencia/local/verif-01-cl100k.log` (contraste o200k_base vs cl100k_base) | `74b0515731a0c5ce5c878471f4aff046942f5276baefdb209f12124e75d5731f` |

## Corridas y veredictos

### Ejemplo 1 — lab1_tokenizar.py — VERIFICADO
Comando: `python lab1_tokenizar.py` (script transcripto tal cual del documento).
Salida idéntica byte a byte a la pegada en §3.1: 9/9 tokens, IDs
`[4422, 23255, 860, 89465, 43619, 25, 89465, 20290, 13]` y
`[39, 315, 44083, 27833, 2120, 10274, 467, 8100, 1603]`, piezas y «Ida y vuelta exacta: True»
en ambos casos.

### Ejemplo 2 — lab2_conteo.py — VERIFICADO (incluye cifra con protocolo, M3)
Comando: `python lab2_conteo.py`.
Salida idéntica a la pegada: castellano 20/24/1.20, inglés 19/20/1.05, código 9/23/2.56,
raro 2/15/7.50. Las cuatro cifras del bloque «Protocolo de la cifra» coinciden con la corrida;
motor y versión del protocolo (tiktoken 0.9.0 / Python 3.12.16) coinciden con el entorno usado.

### Ejemplo 3 — lab3_coseno.py — VERIFICADO
Comando: `python lab3_coseno.py`.
Salida idéntica: perro 0.972, elefante 0.743, notebook 0.024, servidor 0.061.
La verificación manual del texto también se recomputó: producto punto 0,84; normas² 0,82 y 0,91;
resultado 0,97241… ≈ 0,972. Correcta.

### Afirmaciones ancladas con comando — verificadas
- §4 (bloque didáctico, pregunta 2): piezas de «electroencefalografista» con o200k_base =
  `['elect', 'ro', 'ence', 'fal', 'ograf', 'ista']` — coincide con el texto.
- §1.2: piezas de «Hidroelectricidad» (`'H'`, `'id'`, `'roe'`, `'lectric'`, `'idad'`) — coinciden.
- §1.2: «El modelo no lee palabras: lee tokens.» = 7 palabras por `split()`, 9 tokens — coincide.
- §1.2: `o200k_base` «alude a su tamaño»: `n_vocab` = 200 019 ≈ 200k — sostiene la afirmación.

### Corrección aplicada — CORREGIDO (hallazgo adversarial)
Afirmación original de §3.1: «Un vocabulario distinto (`cl100k_base`, por ejemplo) da otros IDs y
otra cantidad», y reenvío de §4: «[Ejemplo 1] (cambiar `o200k_base` por `cl100k_base` y ver
moverse el conteo)». La corrida (`verif-01-cl100k.log`) muestra que con las DOS frases del
ejemplo 1 cl100k_base cambia todos los IDs pero el conteo queda en 9 y 9: el lector que siguiera
el reenvío no vería moverse nada. Con las muestras del ejemplo 2 el conteo sí se mueve
(castellano 24→27, inglés 20→22). Se corrigió el texto de §3.1 (conteo «según el texto», con los
dos contrastes medidos) y el reenvío de §4 ahora apunta al ejemplo 2 con la cifra 24→27.

## Resumen

- Verificados: 3 ejemplos (labs 1–3) + 1 cifra con protocolo (M3) + 4 afirmaciones ancladas.
- Corregidos: 2 pasajes (§3.1 y reenvío de §4), misma causa raíz, con evidencia.
- Ilustrativos: 0. Bloqueos: 0.
- Nota de alcance: el documento menciona `prompt_eval_count`/`eval_count` de la API del banco,
  pero declara dueño del laboratorio al doc 08; no se corrió acá por no ser ejemplo operable de
  este documento.

Sin dudas para el PO.

> Nota: `evidencia/local/` no está versionada (gitignored); sus logs no se publican y se identifican por su huella SHA-256.
