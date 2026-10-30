# E04 — Arranque superpuesto (dictamen 050)

| Campo | Valor |
| --- | --- |
| Fecha | 2026-10-29 |
| Código | Rama descartable `fc/e04-arranque-superpuesto` de Lab-Documentos (`e64f4fd`), no fusionada. La variante se elige con `-p:FcE04=V1\|V2`; sin la propiedad, el comportamiento de `main` |
| Método | El del folio 049: moto g42, APK Release, `scripts/guion.sh instalar` y `tpr` (5 arranques en frío, pantalla encendida), TPR escrito por el cascarón, máximo contra 5 000 ms. Candados del teléfono tomados; `adb uninstall` al final de cada serie |
| Sin cambios | Marca `primer-render`, reloj y contrato del puente |

## Qué hace cada variante

- **V1.** El HybridWebView se adjunta en la pantalla de arranque, debajo de una capa nativa opaca, y empieza a cargar
  enseguida. Si `puntero.json` ya tiene una versión instalada, la sirve por adelantado. El cascarón retiene la
  respuesta al saludo del puente hasta que el actualizador decide; si decide otra versión, recarga. La capa se retira
  con «Listo».
- **V2.** V1 más la sesión, las claves y el actualizador fuera del camino crítico. `InvariantGlobalization` no se
  aplicó, porque es la decisión 3 del PO.

## Resultados (ms)

| Serie | R1 (recién instalada) | R2 | R3 | R4 | R5 | Máximo |
| --- | --- | --- | --- | --- | --- | --- |
| Base (folio 049) | 9 152 | 7 309 | 6 940 | 6 928 | 6 874 | 9 152 |
| **V1** | 9 648 | 5 199 | 4 952 | 4 928 | 4 777 | 9 648 |
| V2 | 10 188 | 5 574 | 5 305 | 5 196 | 5 290 | 10 188 |

Evidencia: `e04-V1-{logcat,am-start}.txt` y `e04-V2-{logcat,am-start}.txt`.

## Lectura

- **V1 baja el régimen unos 2 s** (de 6,9–7,3 s a 4,8–5,2 s): tres de cuatro corridas quedan bajo el umbral y la
  cuarta lo pasa por 199 ms. En R2–R5 el WebView sirve la versión por adelantado: el saludo llega a los 4,2 s del
  inicio del proceso, contra unos 6,7 s de la base.
- **R1 no mejora.** Recién instalada no hay versión que adelantar (`especulada ninguna`): el WebView espera la
  decisión del actualizador, que en el primer arranque crea la base e instala la semilla. El saludo llega a los 9,1 s.
  R1 fija el máximo en las tres series.
- **V2 es peor que V1** en unos 300–400 ms en régimen. Sacar trabajo del camino crítico lo pone a competir por la CPU
  con el WebView y Mono en el mismo momento. No conviene.
- **Ninguna variante cumple el umbral** con R1 incluido, como lo pide P1.

## Lo que falta para cumplir

R1 sólo baja si el primer arranque tiene una versión servible sin esperar al actualizador: la «semilla de fábrica
firmada servida desde el APK» del dictamen 050 (decisión 2 del PO). Con esa semilla, R1 debería comportarse como R2–R5
(estimación, sin medir). Y el régimen de V1 queda en el borde: hace falta otra palanca de unos 200–300 ms para tener
margen.
