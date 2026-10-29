| Campo | Valor |
| --- | --- |
| Tipo | constancia |
| Fecha | 2026-10-29 |
| Autor | Presidencia de la mesa |
| Cierra | 047 (TPR del g42 no obtenido) y el pendiente «TPR en el g42 por su definición» de la 048 |

# Constancia — TPR del g42 medido por su definición: no cumple

## Hecho

- **Decisión del PO.** El PO pidió tomar la marca `primer-render` (2026-10-29). Se resolvió sin tocar el contrato del
  puente: al llegar «Listo», el cascarón lee del WebView la hora de la marca y la escribe en su bitácora con la
  etiqueta `FC` y el `tpr=` contado desde el inicio del proceso. `LectorDeTpr` usa ese valor cuando está. Va en el
  PR #36 de Lab-Documentos, con una prueba nueva en Gate (5/5 del lector en verde).
- **Medición en el moto g42.** Con el APK Release: 5 de 5 arranques `COLD` con marca; TPR de 9 152, 7 309, 6 940,
  6 928 y 6 874 ms. El máximo supera el umbral de 5 000 ms: **NO CUMPLE**. Con el APK Debug, de 8 092 a 14 062 ms.
  Detalle y evidencia en E03 `P1-TPR-G42.md`. Se usaron los dos candados del teléfono y la app se desinstaló al final.
- **Causa de la 047.** La consola del WebView llega al logcat con el APK Debug y no con el Release. En Debug, el TPR
  del cascarón y el de la consola difieren entre 8 y 11 ms.
- **La estimación de la 047 se confirma**: estaba en 6,7 a 7,7 s en régimen y 9,1 a 9,6 s en la primera corrida.

## Consecuencia

Se abre la **condición de revisión (2) de P1**: evaluar la alternativa «C-min» (renderizador compilado en el cascarón
y encuestas como datos). Es una decisión del PO.

## Pendientes abiertos que siguen

- **Condición (2) de P1** (PO): si se evalúa «C-min».
- **Historia del repositorio público** (PO).

## Pase

Archivo. El expediente sigue ARCHIVADO.
