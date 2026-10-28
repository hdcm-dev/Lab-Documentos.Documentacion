---
doc_id: EXP0002-F256
doc_type: corrigenda
title: Corrigenda de la cuenta de marcas de G-g — cinco marcas `[Compilado]` hacia `E1-U4b`, tres menciones en prosa en los temas y una en Referencias
status: vigente
origin: agent
confidence: alta (re-medición con `git grep` sobre los dos árboles citados, §2)
owner: presidencia de la mesa de Replanteo y análisis DocAsCode (vuelta de E1)
last_review: 2026-10-28
audience: [PO, presidencia, refutador, agentes que reparen E1, bitacorista]
traces: [EXP0002-F245, EXP0002-F250]
---

# 256 — Corrigenda: cuenta de marcas de G-g

| Campo | Valor |
| --- | --- |
| Tipo | corrigenda (sólo agregado) |
| Fecha | 2026-10-28 |
| Autor | Presidencia de la mesa (vuelta de E1), por la unidad U01 del acta `250` (DEC-04, ajuste §7.1). Defecto DEF-76 |
| Corrige | Las cuentas de `evidencia/E1-G/G-g-lista-ver.md` filas VER-E02 (línea 77) y VER-A06 (línea 130). Ni la evidencia ni `245` se editan |

## Índice

1. [Qué se corrige](#1-qué-se-corrige)
2. [Medida](#2-medida)
3. [Efecto](#3-efecto)
4. [Pase](#4-pase)

## 1. Qué se corrige

| Lugar | Dice | Debe decir |
| --- | --- | --- |
| `G-g-lista-ver.md:77` (VER-E02) | «cuatro marcas `[Compilado: evidencia/E1-U4b/…]` apuntan a archivos inexistentes» | **cinco** marcas, que citan cuatro guiones (`04-adopciones.sh` se cita dos veces) |
| `G-g-lista-ver.md:130` (VER-A06) | «4 de 15 marcas `[Compilado…]` citan rutas que no existen» | **5 de 15** |
| `245` §4, G-g, y `G-g-lista-ver.md` §8 | «5 marcas … más 3 menciones en prosa» | Correcto para los temas. Falta una cuarta mención en prosa, fuera de los temas: `99-Anexos/Referencias.md:132` |

`245` y la refutación de `G-g-lista-ver.md` §8 ya traían la cuenta correcta de las marcas. Lo que quedaba mal eran las
dos filas de la tabla VER-*.

## 2. Medida

Comando, sobre Lab-Documentos en `490646b` (el árbol que midió G-g) y en `origin/main` = `227954a`, con el mismo
resultado en los dos:

```bash
git grep -n "E1-U4b" <árbol> -- Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/
```

| Archivo (relativo al cuerpo) | Línea | Tipo |
| --- | --- | --- |
| `TEM-01-Sistema-Documentador.md` | 217 | marca `[Compilado]` (`01-tem01-inventario.sh`) |
| `TEM-01-Sistema-Documentador.md` | 246 | marca `[Compilado]` (`04-adopciones.sh`) |
| `TEM-02-Ciclo-Documental.md` | 217 | marca `[Compilado]` (`02-tem02-rrd.sh`) |
| `TEM-03-Topologia-Y-Versionado.md` | 193 | marca `[Compilado]` (`04-adopciones.sh`) |
| `TEM-03-Topologia-Y-Versionado.md` | 221 | marca `[Compilado]` (`03-tem03-ancla.sh`) |
| `TEM-01-Sistema-Documentador.md` | 213 | prosa |
| `TEM-02-Ciclo-Documental.md` | 214 | prosa |
| `TEM-03-Topologia-Y-Versionado.md` | 213 | prosa |
| `99-Anexos/Referencias.md` | 132 | prosa (fuera de los temas) |

Total: 9 líneas, 5 marcas, 4 guiones distintos, 4 menciones en prosa. `git grep -o "\[Compilado"` sobre el mismo
cuerpo da 15 apariciones, como dice VER-M09 (`G-g-lista-ver.md:108`).

## 3. Efecto

- El veredicto de G-g no cambia: NO_CUMPLE, 43 de 51 obligatorios (84,3 %). VER-E02, VER-E03 y VER-A06 seguían en
  «No» con cualquiera de las dos cuentas.
- La reparación de D1 en la vuelta tiene que cubrir las 9 líneas de §2, incluida `Referencias.md:132`, que la lista
  de D1 (`G-g-lista-ver.md:59`) no nombra.
- La re-verificación E1-G2 usa la cuenta de este folio.

## 4. Pase

A las unidades que reparen D1 (guiones de `E1-U4b`) y a la re-verificación E1-G2 · presidencia.
