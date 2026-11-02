# E2 · Hoja de estilo HE-01…HE-11 (cerrada)

**Etapa:** E2 (C-4.4) · **Fecha:** 2026-11-01 · **Dueños:** P-07 Editorial A y P-08 Editorial B · **Origen de las reglas:** `../Propuestas/P-08-Comision-Editorial-B.md` §HE · **Estado:** cerrada; rige en E3 y en la ronda de E10.

## Índice

1. [Definiciones](#1-definiciones)
2. [Reglas](#2-reglas)
3. [Línea base de la 0.11.0](#3-línea-base-de-la-0110)
4. [Convenciones complementarias](#4-convenciones-complementarias)
5. [Lo que queda abierto](#5-lo-que-queda-abierto)

## 1. Definiciones

- **Prosa:** texto fuera de bloques de código, de código en línea, de comentarios HTML, de destinos de enlaces y de URL. Es lo que miden las comprobaciones.
- **Comprobación mecánica:** expresión que `Evidencia/barrido.py` aplica sobre la prosa; cuenta líneas con hallazgo.

## 2. Reglas

| Id | Tema | Regla | Comprobación | Meta al cerrar E3 |
|---|---|---|---|---|
| HE-01 | Comillas | Latinas «» en prosa; anidadas “”; rectas sólo en código | `"` en prosa | 0 |
| HE-02 | Términos técnicos | Identificadores, rutas y comandos en código; nombres de producto en redonda | revisión contra el glosario (Anexo C) | 0 P1 en E10 |
| HE-03 | Extranjerismos | Patrón en inglés, dominio en español; extranjerismo no técnico en cursiva la primera vez, con su equivalente | revisión humana | 0 P1 en E10 |
| HE-04 | Fechas | ISO `AAAA-MM-DD` en todo el libro | `\d{1,2}/\d{1,2}/\d{2,4}` | 0 |
| HE-05 | Cifras | Miles con punto en prosa (57.753), decimal con coma; en código, como lo imprime la herramienta | `\d{1,3},\d{3}` (da candidatos: también caza decimales de tres cifras como 0,459, que son correctos) | 0 miles con coma tras revisar candidatos |
| HE-06 | Mayúsculas | Encabezados en mayúscula de oración; nombres propios y de producto conservan la suya | encabezados con ≥ 3 palabras capitalizadas | revisados uno a uno |
| HE-07 | Abreviaturas | «p. ej.», «etc.»; sin «e.g.» ni «i.e.» | `e.g.`, `i.e.` | 0 |
| HE-08 | Rayas y guiones | Raya (—) para incisos, semirraya (–) en intervalos (P0–P3, 01–17), guion en compuestos | « - » en prosa | 0 fuera del Anexo D |
| HE-09 | Voz | Impersonal en la explicación, como la 0.11.0; segunda persona (voseo) sólo para indicar al lector qué hacer (objetivos, preguntas guía, pasos) | muestra de 20 párrafos por parte en E10 | 0 mezclas dentro de un párrafo |
| HE-10 | Referencias | `[REF-n]` como única forma de cita externa; la fecha de consulta va en el Anexo D | `verificar-markdown.py` | rc 0 |
| HE-11 | No delta | Prohibidas «Historia (hasta…», «antes era», «versión anterior», «era ApiWeb» en el cuerpo | grep sobre la prosa | 0 fuera del Anexo H |

Tabla 1. Reglas cerradas. HE-09 queda cerrada con la voz que la 0.11.0 ya usa (la pregunta E-08 de P-08 proponía impersonal; la 0.11.0 usa voseo en objetivos y preguntas, p. ej. «Qué vas a poder hacer al terminar»), así que no obliga a reescribir.

## 3. Línea base de la 0.11.0

`python3 -I Evidencia/barrido.py <copia de la 0.11.0>` (salida en `Evidencia/barrido-HE.txt`, líneas con hallazgo):

| Regla | Líneas | Primeras líneas de la 0.11.0 |
|---|---|---|
| HE-01 | 3 | 259, 2559, 3688 |
| HE-04 | 0 | — |
| HE-05 | 17 candidatos | 1034, 1263, 1308, 1589, 1706, 1727 |
| HE-06 | 2 | 875, 4856 (nombres de producto: «Microsoft.Extensions.AI», «Semantic Kernel»; no son hallazgos) |
| HE-07 | 0 | — |
| HE-08 | 5 | 4829, 4844, 4845, 4878, 4879 (todas en el Anexo D) |
| HE-11 | 63 | 163, 661, 712, 972, 1031, 1032 (62 con «Historia (hasta», incluida la 163, que explica la marca en §0.4; y la 3423, «versión anterior» en una explicación técnica de M.E.AI) |

Tabla 2. Línea base. HE-02, HE-03 y HE-09 no tienen comprobación mecánica: se revisan en E10.

## 4. Convenciones complementarias

No son reglas HE nuevas: vienen de acuerdos ya aprobados y se comprueban con sus propias herramientas.

- Mermaid: etiquetas «1 · Texto» (no «1. Texto»), sin URL, ~15 nodos como máximo, validado con `mermaid.sh` y con el control mermaid-arroba de docs-guard (C-2.6, U-4.3, `00-Coordinacion-Entre-Sesiones.md`).
- «Tabla N.m» y «Figura N.m» numeradas por capítulo (C-2.6, U-4.3).
- Marcas de estado NO VERIFICADO y NO EJECUTADO (C-2.6).
- Lo privado: ningún nombre, host, IP, puerto, usuario, ruta del home ni credencial; `compuerta-rpriv.sh` (R-PRIV).

## 5. Lo que queda abierto

- La norma RAE-ASALE como fuente de HE-01, HE-05 y HE-08 sigue NO VERIFICADO (P-08 §fuentes); las reglas se aplican como convención de la casa.
- `barrido.py` vive en la bitácora; si E10 lo quiere como compuerta de la guía, se propone en `{guía}/tools/` en esa etapa.
