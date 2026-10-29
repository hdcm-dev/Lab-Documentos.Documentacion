---
doc_id: EXP0002-F258
doc_type: constancia
title: Constancia del rescate de lo hecho en i7infra — folios y evidencia no publicados, tabla de folios con nombre completo y sustitución del 290
status: vigente
origin: agent
confidence: alta en el inventario (manifiesto sha256 de i7infra contra la foto, sin diferencias); alta en la sustitución del 290 (cuatro razones medidas, acta 257 D03)
owner: presidencia de la mesa de recuperación del expediente 0002
last_review: 2026-10-29
audience: [PO, presidencia, agentes de E1-R, mesa de la opción B, bitacorista]
traces: [EXP0002-F240, EXP0002-F245, EXP0002-F249, EXP0002-F252, EXP0002-F253, EXP0002-F257]
---

# 258 — Constancia del rescate de i7infra

| Campo | Valor |
| --- | --- |
| Tipo | constancia (unidad K10 del acta `257`) |
| Fecha | 2026-10-29 |
| Autor | Presidencia de la mesa de recuperación |
| Corrige | Nada. Las correcciones por referencia van en el `259` |

## Índice

1. [Qué se asienta](#1-qué-se-asienta)
2. [Qué entra en este PR](#2-qué-entra-en-este-pr)
3. [Tabla de folios con nombre completo](#3-tabla-de-folios-con-nombre-completo)
4. [Regla de cita](#4-regla-de-cita)
5. [Sustitución del 290](#5-sustitución-del-290)
6. [Lo que no entra](#6-lo-que-no-entra)

## 1. Qué se asienta

i7infra no se apagó el 2026-10-28: perdió la red cerca de las 00:50 (−03) y volvió a la noche, con 16 días de
encendido. Lo que la constancia `240` dio por perdido (el folio `230`, los folios de E1-U2…E1-U5, la evidencia de cada
unidad y la verificación de E1-G) existía en el árbol de trabajo de i7infra, sin publicar. No había commits del
expediente sólo en i7infra: la única historia es la de GitHub (acta `257`, diagnóstico 1).

El mandato del PO para esta recuperación, literal: «toma como base i7infra, en esto estaba mejor que lo que tenia
aquí». El acta `257` (D01) lo aplica pieza por pieza: los archivos que sólo existían en i7infra entran con su contenido
literal y redacción mecánica; los 178 archivos que existen en los dos lados quedan como en GitHub, que ya tiene las
redacciones F4–F8 (`254`).

Foto de i7infra tomada por lectura y verificada por manifiesto sha256 contra el equipo en vivo: sin diferencias en las
carpetas del expediente, de la Guía 14 y del cuerpo SDEI (unidad K00). El manifiesto y la ia-db v4.0 sin publicar
quedan en el `{resguardo-privado}` (`253`).

## 2. Qué entra en este PR

Sólo archivos nuevos (estado `A`); ningún archivo existente cambia.

| Grupo | Archivos |
| --- | --- |
| Folios de i7infra | `212-e1-u2.md`, `213-e1-u3.md`, `214-e1-u4a.md`, `218-e1-u4b.md`, `230-e1-u0c.md`, `250-e1-u4e.md`, `251-e1-u4d.md`, `252-e1-u4c.md`, `260-e1-u4f.md`, `270-e1-u5.md`, `290-compuerta-e1.md` |
| Evidencia de i7infra | `evidencia/E1-U2/` … `evidencia/E1-U5/`, `evidencia/E1-G/01` a `05`, `evidencia/E1-U0c/02-redact.py` (versión publicable, sin literales: los pares se leen de un archivo fuera de todo repo) |
| Bitácoras de la Guía 14 | `PROMPTs/Guides/14-Sistema-De-Documentador-Tecnico/OUTPUTs/DocsAsCode-Bitacoras/` |
| Folios de la recuperación | `257-acta-mesa-recuperacion-i7infra.md`, este `258` |

Barrido S2 sobre todo lo agregado: 0 literales privados, 0 rutas del anfitrión, 0 IP privadas o del tailnet. Los
folios de i7infra mencionan la existencia de una credencial local (PE-10 del `290`) sin su valor.

## 3. Tabla de folios con nombre completo

Folios de la serie 2xx después de este PR. «Origen» dice en qué equipo se escribió.

| Archivo | Origen | Qué es |
| --- | --- | --- |
| `210-e1-u0a.md` | i7infra (publicado) | Unidad E1-U0a |
| `211-e1-u0b.md` | i7infra (publicado) | Unidad E1-U0b |
| `211-e1-u1.md` | i7infra (publicado) | Unidad E1-U1 |
| `212-e1-u2.md` | i7infra (rescatado) | Unidad E1-U2 |
| `213-e1-u3.md` | i7infra (rescatado) | Unidad E1-U3 |
| `214-e1-u4a.md` | i7infra (rescatado) | Unidad E1-U4a |
| `216-e1-u6.md` | i7infra (publicado) | Unidad E1-U6 |
| `218-e1-u4b.md` | i7infra (rescatado) | Unidad E1-U4b |
| `230-e1-u0c.md` | i7infra (rescatado) | Unidad E1-U0c; es el «230» que cita la carátula |
| `240-constancia-caida-i7infra-y-reconciliacion.md` | hpdev | Constancia de la caída |
| `245-resolucion-compuerta-e1.md` | hpdev | Resolución de E1-G: **INSUFICIENTE, rige** |
| `249-providencia-estado.md` | hpdev | Estado al 2026-10-28 |
| `250-acta-mesa-organizacion-y-vuelta-e1.md` | hpdev | Acta de la mesa de organización |
| `250-e1-u4e.md` | i7infra (rescatado) | Unidad E1-U4e |
| `251-corrigenda-133-criterios-vuelta.md` | hpdev | Corrigenda a 133 |
| `251-e1-u4d.md` | i7infra (rescatado) | Unidad E1-U4d |
| `252-corrigenda-n10-y-caratula.md` | hpdev | Corrigenda a N10 y a la carátula |
| `252-e1-u4c.md` | i7infra (rescatado) | Unidad E1-U4c |
| `253-constancia-resguardo.md` | hpdev | Constancia del resguardo |
| `254-corrigenda-patron-s2.md` | hpdev | Corrigenda del patrón S2 |
| `256-corrigenda-cuenta-marcas-g-g.md` | hpdev | Corrigenda de la cuenta de G-g |
| `257-acta-mesa-recuperacion-i7infra.md` | hpdev | Acta de la mesa de recuperación |
| `258-constancia-rescate-i7infra.md` | hpdev | Este folio |
| `260-e1-u4f.md` | i7infra (rescatado) | Unidad E1-U4f |
| `270-e1-u5.md` | i7infra (rescatado) | Unidad E1-U5 |
| `290-compuerta-e1.md` | i7infra (rescatado) | Compuerta E1-G de i7infra: **sustituida** (§5) |

Reservados por el plan: `255` (PR abierto de etiquetas), `259` (corrigenda única), `260-registro-e1r.md` (convive con
`260-e1-u4f.md`), `261`–`265` (vuelta y E1-G2).

## 4. Regla de cita

Los números `211`, `250`, `251`, `252` y `260` están usados dos veces. Desde este folio se citan **siempre por el nombre
completo del archivo** (precedente: `252:79`). Ningún folio se renumera: el PO decidió no reescribir, y ninguna cita
existente usa los nombres de i7infra.

## 5. Sustitución del 290

El `290-compuerta-e1.md` entra literal, redactado, como antecedente. Su corte («PROCEDE CON RESERVA») **no rige**: rige
el `245` (INSUFICIENTE, una sola vuelta), ratificado por `251` §6 (DEC-11). Razones (acta `257`, D03):

1. Su G-d («PASA») es falso en su propia base: `dg.py` sobre `git archive fe10086` da rojo por `GUIA-INDICE`.
2. Su G-c se apoya en la autoprueba local, no en pares rojo/verde en el runner.
3. Su G-f es parcial (barrido sólo sobre las líneas que E1 agregó).
4. Da por fusionado el #27 por conformación automática, pero ese merge (`75043a5`) se hizo a las 08:44 (−03) desde
   hpdev, horas después de escrito el folio.

Lo que el `290` sí aporta y se usa: la medida de G-a como antecedente (`259`), el Anexo L6 (`290` §14, para la
resolución de E1-G2), los pendientes PE-1…PE-14 y el generador del sitio de la demo.

## 6. Lo que no entra

- `evidencia/local/` del expediente: no se publica (sigue en el `{resguardo-privado}`).
- La ia-db v4.0 de i7infra: no estaba versionada; queda en el `{resguardo-privado}` y la cita el reindexado único (U34).
- Las bitácoras `Analista-Dediciones-Bitacoras` y `Analistas-Bitacoras` de la Guía 14: no se publican (acta `257`, D12).
- La credencial local de i7infra (PE-10): ni su valor ni el archivo.
