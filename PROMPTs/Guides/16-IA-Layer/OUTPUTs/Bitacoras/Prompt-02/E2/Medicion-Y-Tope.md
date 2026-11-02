# E2 · Medición de recortes y tope votado

**Etapa:** E2 (E-A1, D-12 c, I-02) · **Fecha:** 2026-11-01 · **Dueño:** P-07 Editorial A · **Jurado:** Ev, Im, CB, CH, Ri · **Fuente:** guía 0.11.0, sha256 `c8defd8324497c4279a3dfd57ce5d2757326ad966813a9f9797d0196d9b7ce3d`.

## Índice

1. [Definiciones](#1-definiciones)
2. [Método](#2-método)
3. [Resultados](#3-resultados)
4. [Lo que entra](#4-lo-que-entra)
5. [Opciones sometidas al jurado](#5-opciones-sometidas-al-jurado)
6. [Votos razonados](#6-votos-razonados)
7. [Escrutinio y tope](#7-escrutinio-y-tope)
8. [Qué hace E3 con el tope](#8-qué-hace-e3-con-el-tope)

## 1. Definiciones

- **Palabras:** las que cuenta `tools/contar.sh` de la guía (prosa sin código, comentarios, anclas, separadores de tabla ni tablas del Anexo F). La 0.11.0 mide **57.753**; su tope informativo es 44.330 (130 %).
- **Recorte:** texto que sale del cuerpo por una decisión aprobada. **Entrada:** texto nuevo que otra decisión agrega.
- **Cota baja / alta:** el recorte de los bloques «Historia» no tiene un límite mecánico único (§2); se miden los dos extremos.

## 2. Método

Sobre una copia de la guía en el área de trabajo (nunca sobre el repo), `Evidencia/medir.py` genera variantes y `contar.sh` (copia idéntica a la de `{guía}/tools/`) las cuenta. Salida completa: `Evidencia/medicion-contar.txt`.

| Variante | Decisión | Qué quita o agrega la simulación |
|---|---|---|
| h | C-2.2, cota baja | Las líneas que empiezan con «Historia (hasta» |
| H | C-2.2, cota alta | Además, desde «Historia (hasta» hasta el fin de la línea cuando aparece a mitad de un párrafo (no en tablas). Exagera el recorte: algunos de esos tramos siguen con «Vigente: …», que E3 conserva |
| D | C-2.3 | Las tablas de §3.0 y §4.1 (sus términos pasan al glosario; supone que el glosario ya los tiene, cota optimista) |
| P | D-11 d | Las fichas de los ejemplos 01–04, 06–13 de «Ejemplos de §5, §7 y §8», reemplazadas por un resumen de 60 palabras cada una (objetivo, comando, salida, enlace) |
| A | D-10 a | Suma un Anexo H de 150 palabras (una tabla) |

C-2.7 (un solo mapa de ejemplos) no se simuló: también resta, así que las cifras de abajo son conservadoras respecto de ella.

## 3. Resultados

| Variante | Total | Diferencia con la 0.11.0 |
|---|---|---|
| 0.11.0 | 57.753 | — |
| h | 56.826 | −927 |
| H | 54.790 | −2.963 |
| D | 57.343 | −410 |
| P | 56.699 | −1.054 (sale el doble; entran 720 de resúmenes) |
| A | 57.906 | +153 |
| **h + D + P + A** | **55.887** | **−1.866** |
| **H + D + P + A** | **53.851** | **−3.902** |

Tabla 1. Medición con `contar.sh` (rc 0 en las ocho corridas).

## 4. Lo que entra

| Entrada | Presupuesto | Base |
|---|---|---|
| Parte I · Fundamentos | 1.500 | D-16 b (tope del capítulo) |
| Capítulo 16 · caso aplicado | 2.158 | el capítulo análogo de la 0.11.0, §14 (la demo), medido igual; E8 no lo puede superar sin volver a la mesa |
| **Suma** | **3.658** | |

Extensión prevista: **59.545** con la cota baja (55.887 + 3.658) y **57.509** con la alta (53.851 + 3.658).

## 5. Opciones sometidas al jurado

- **T-a · 60.000.** Cubre la cota baja con 455 palabras de margen (0,8 %).
- **T-b · 57.753 (la extensión actual).** Sólo entra con la cota alta (244 de margen), que exagera el recorte. En sustancia es la opción D-12 a, excluida por veto en `04-Aprobacion.md` §3.
- **T-c · 44.330 (el tope de `contar.sh`).** Exige recortar 15.215 palabras más que la cota baja, sin decisión aprobada que las saque. En sustancia es D-12 b, que perdió.

## 6. Votos razonados

| Jurado | Voto | Razón |
|---|---|---|
| Ev · evidencia | **T-a** | Es el único número que la medición sostiene en el escenario conservador. T-b se apoya en la cota alta, que el método declara exagerada; T-c no tiene medición que la respalde. |
| Im · impacto | **T-b** | El lector gana si el libro no crece aunque sume Fundamentos y caso; obliga a E3 a buscar recortes en C-2.7 y en duplicaciones que la medición no simuló. |
| CB · costo-beneficio | **T-a** | T-b obliga a recortes no medidos, de costo desconocido, en el archivo de la ruta crítica; T-c obliga a reescribir sin decisión. T-a se cumple aplicando sólo lo aprobado. |
| CH · coherencia histórica | **T-a** | El cierre del 2026-10-28 dejó `contar.sh` informativo; T-b repite D-12 a, excluida por veto, y T-c, D-12 b, que perdió. T-a es el primer tope votado con números, como pidió D-12 c. |
| Ri · riesgo | **T-a** | Ninguna opción es irreversible ni toca lo privado: no hay veto. T-c rompería la compuerta de extensión en cuanto pase a bloqueante; T-b deja 244 palabras de margen con una cota optimista. |

## 7. Escrutinio y tope

T-a 4 · T-b 1 · T-c 0. Sin veto, sin empate, sin decisión del PO. **Tope votado: 60.000 palabras de `contar.sh`.**

## 8. Qué hace E3 con el tope

- Declararlo en el front matter de la guía (p. ej. `tope_palabras: 60000`) y en `contar.sh`, con las partes nuevas (Prólogo, Partes I–VII, Cierre, Anexos) y topes por parte que sumen 60.000 (D-12 c, `04-Aprobacion.md` §3).
- Medir con `contar.sh` al cerrar cada parte y registrar antes/después en `E3/Registro-Por-Parte.md`.
- Si la extensión supera 60.000 al cerrar E3, el exceso vuelve a la mesa; no se eleva el tope sin votación.
