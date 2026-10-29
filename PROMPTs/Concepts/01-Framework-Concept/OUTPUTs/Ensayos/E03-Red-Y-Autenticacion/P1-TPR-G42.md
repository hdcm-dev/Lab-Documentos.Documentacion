# P1 — TPR en el moto g42

| Campo | Valor |
| --- | --- |
| Fecha | 2026-10-28 20:28–20:31 (-03) |
| Dispositivo | moto g42 (Android 13, API 33, arm64-v8a, Android System WebView 155.0.8059.43), por `adb` remoto en la PC del PO, que lo conectó para esta medición |
| APK | `com.frameworkconcept.demo` 1.0.0, Release arm64 sin depuración (26 991 621 B, `sha256 8389bafc…6a0c1e`). Se compiló el 2026-10-28 a las 00:20 sobre `fe10086`; la demo no cambió entre ese commit y `0989a15` (`git diff fe10086 0989a15 -- Concepts/Framework-Concept/Demo` vacío). Contenido de la semilla `1.0.0+5d5c2b4` |
| Procedimiento | `scripts/guion.sh instalar` y `scripts/guion.sh tpr` de `main` (`0989a15`): 5 arranques en frío con la pantalla encendida y sin bloqueo, 20 s de espera por corrida. Después, `adb uninstall`. Para el cálculo final se usó `FC_SIN_BUILD=1`, con `FrameworkConcept.Tools` compilado antes en la imagen `dotnet/sdk:10.0` (no hace falta Android). La APK Release se copió a la ruta Debug que espera `guion.sh instalar` Con los candados del teléfono de hpdev tomados todo el tiempo |
| Registros | `p1-tpr-g42-am-start.txt` y `p1-tpr-g42-logcat.txt` |

## Resultados

Las 5 corridas fueron `LaunchState: COLD`. `TotalTime` fue de 1 710 ms en la primera y de 965 a 1 013 ms en las demás.
Los tiempos de la tabla se miden desde el inicio del proceso (el `t=` que escribe el cascarón):

| Corrida | «pantalla visible» (ms) | «carga iniciada» (ms) | «puente Listo» (ms) | Marca `primer-render` |
| --- | --- | --- | --- | --- |
| 1 (activa la semilla y crea la base) | 901 | 7 113 | 9 661 | no llegó al logcat |
| 2 | 566 | 4 677 | 7 715 | no llegó al logcat |
| 3 | 544 | 4 510 | 7 345 | no llegó al logcat |
| 4 | 550 | 4 522 | 7 320 | no llegó al logcat |
| 5 | 540 | 4 438 | 7 308 | no llegó al logcat |

`FrameworkConcept.Tools tpr` dio **TPR NO OBTENIDO**: ninguna corrida tiene `primer-render`.

## Por qué no hay marca

El contenido sí cargó en las 5 corridas: el WebView pidió los recursos (hasta 47 pedidos) y el contenido llegó a
`puente Listo`. Lo que falta es la vía por la que viaja la marca. `puente.js` la escribe con `console.log`, y en el
emulador del folio 042 el WebView la reenviaba al logcat como `I/chromium … [INFO:CONSOLE:83] "FC-MARCA primer-render…"`.
El registro del instrumento sólo guarda las líneas `I/FC` y `FC-MARCA`, así que no muestra qué pasó con la consola. En
una lectura aparte del logcat completo del g42, que por la rotación del búfer sólo alcanzó las corridas 4 y 5 (no se
publica porque nombra otras apps del teléfono), hay 8 líneas `chromium` del motor y ninguna `[INFO:CONSOLE]`. El WebView
del g42 no reenvió al logcat los mensajes de consola del contenido, y con la APK Release el instrumento de
`guion.sh tpr` no ve la marca en este teléfono.

## Lo que sí se puede decir

En el emulador, con el mismo contenido (`1.0.0+5d5c2b4`, en la APK x64), la marca llegó entre 38 y 578 ms **antes** de «puente Listo», y entre
2,3 y 2,8 s después de «carga iniciada» (`p1-tpr-emulador-2-logcat.txt`). Si el orden es el mismo en el g42:

- el TPR queda acotado entre «carga iniciada» y «puente Listo»: de 4 438 a 7 715 ms en las corridas 2 a 5 y de 7 113 a
  9 661 ms en la primera;
- con la distancia del emulador entre la marca y «puente Listo», el TPR estimado sería de unos 6,7 a 7,7 s en régimen y
  de unos 9,1 a 9,6 s en la primera corrida.

**Interpretación.** Es un indicio fuerte de que el umbral de 5 000 ms de P1 no se cumple en el g42, y coincide con el
estimado previo de unos 7,5 s (E02 §5, H-A). Pero es una estimación: la cota inferior medida (4,4 s) está por debajo del
umbral. La condición de revisión (2) de P1 **sigue abierta**, ahora con estas cotas.

**Para medirlo por su definición** hay que llevar la marca por una vía que el cascarón registre: por ejemplo, que
`puente.js` la mande por el puente y el cascarón la escriba con su etiqueta `FC`. Es un cambio en `Demo/`, pendiente
de decisión.
