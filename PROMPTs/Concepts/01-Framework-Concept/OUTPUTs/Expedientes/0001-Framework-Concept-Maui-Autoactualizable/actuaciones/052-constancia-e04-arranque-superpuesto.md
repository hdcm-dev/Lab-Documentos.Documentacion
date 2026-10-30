| Campo | Valor |
| --- | --- |
| Tipo | constancia |
| Fecha | 2026-10-29 |
| Autor | Presidencia de la mesa |
| Sigue a | 050 (dictamen sobre la condición 2 de P1) |

# Constancia — E04 medido en el g42: V1 baja el régimen a unos 5 s; el primer arranque no cumple

## Hecho

- El PO aprobó el dictamen 050. La mesa implementó E04 (V1 y V2) en una rama descartable de la demo y lo midió en el
  moto g42 con el método del folio 049. Detalle y evidencia en `Ensayos/E04-Arranque-Superpuesto/INFORME.md`.
- **V1**: 9 648 · 5 199 · 4 952 · 4 928 · 4 777 ms. **V2**: 10 188 · 5 574 · 5 305 · 5 196 · 5 290 ms. Base (049):
  9 152 · 7 309 · 6 940 · 6 928 · 6 874 ms.
- V1 baja el régimen unos 2 s y queda en el borde del umbral. R1, el primer arranque después de instalar, no mejora
  porque no hay versión que servir por adelantado. V2 empeora a V1, porque la competencia por la CPU anula lo que se
  gana.

## Consecuencia

La condición (2) de P1 sigue abierta: con R1 incluido, ninguna variante cumple. El camino que queda bajo P1 es V1 más
la semilla de fábrica servida desde el APK.

## Lo que decide el PO

1. Si aprueba la semilla de fábrica firmada dentro del APK (decisión 2 del dictamen 050), para medir V1 + semilla.
2. Si V1 se incorpora a `main` como ajuste del anfitrión, aunque solo no alcance.
3. Si, sin semilla, se revisa el umbral o se mide el control C-min.

## Pase

Al PO. El expediente sigue ARCHIVADO.
