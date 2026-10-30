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

## V1S — semilla del APK servida en el primer arranque (2026-10-30, folio 053)

El PO aprobó la semilla de fábrica firmada dentro del APK. La rama descartable `fc/e04-semilla-apk` (`a6cc5e5`) agrega
`-p:FcE04=V1S`: en el primer arranque, sin `puntero.json`, el cascarón verifica la semilla del APK (firma ES256 del
índice, tamaño y sha256 del zip) y la sirve desde memoria mientras el actualizador la instala como siempre.

| Serie | Corridas (ms) |
| --- | --- |
| `guion.sh tpr` (R1 + 4 en régimen) | R1 sin datos (el búfer del logcat rotó durante la instalación, como en la 047) · 5 554 · 5 064 · 4 893 · 4 953 |
| Primer arranque recién instalado, 3 veces, búfer de 16 MB | 8 783 · 7 930 · 8 572 |

Evidencia: `e04-V1S-{logcat,am-start}.txt` y `e04-V1S-primer-arranque-{1,2,3}-logcat.txt`.

- **La semilla se sirve desde el primer momento**: `req#1 GET /index.html (semilla del APK)` entre los 3,5 y los
  4,2 s, y el último `_framework` entre los 4,1 y los 4,9 s.
- **El primer arranque solo baja de unos 9,6 s a 7,9–8,8 s**, por dos causas:
  1. El saludo del contenido llega recién entre los 6,4 y los 7,7 s. Mono arranca más lento en el primer uso, con
     las cachés del WebView vacías tras la instalación.
  2. El cascarón retiene el saludo hasta que el actualizador decide (`ContenidoListo` entre los 7,5 y los 8,3 s),
     porque en el primer arranque sigue creando la base e instalando la semilla en disco.
- **El régimen queda como V1**: de 4,9 a 5,6 s.

**Lectura.** Aunque se adelantara la respuesta al saludo, el primer arranque quedaría por encima de unos 6,5 s, porque
el propio arranque de Mono en el primer uso ya lo supera. Con este modelo, la corrida recién instalada no baja de 5 s
en el g42. Ojo: el método de P1 (035:325-337) dice «con el contenido ya instalado». Si la corrida recién instalada no
cuenta, el veredicto depende sólo del régimen, que con V1 está en el borde: 4,8 a 5,2 s, o 4,9 a 5,6 s según la serie.
