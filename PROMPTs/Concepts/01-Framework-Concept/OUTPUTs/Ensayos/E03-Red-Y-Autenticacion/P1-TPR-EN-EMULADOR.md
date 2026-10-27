# P1 — TPR en emulador (fc-android-emu-hpdev)

| Campo | Valor |
| --- | --- |
| Fecha | 2026-10-27 13:15–13:18 (hora del emulador) |
| Dispositivo | `fc-android-emu-hpdev` (`sdk_gphone64_x86_64`, Android 13, API 33), por `adb` remoto |
| APK | `com.frameworkconcept.demo`, x64, la del corrector de E03 (`sha256 ca427988…48a3b4`); contenido `1.0.0+5d5c2b4` |
| Procedimiento | `am force-stop` + 3 s + `logcat -c` + `am start -W`; 5 repeticiones; logcat con etiqueta `FC` a los 15 s (una sexta corrida a los 45 s) |
| Registro | `p1-tpr-emulador-logcat.txt` |

> **Alcance.** Es una medición en emulador sobre un host x86. **No sustituye** al teléfono físico de gama media que P1
> fija para el umbral de 5 000 ms: el moto g42 siguió reservado por ESCENARIOS durante el cierre y no se usó.

## Resultados

| Corrida | `WaitTime` (ms) | `TotalTime` | «pantalla visible» (ms) | «ContenidoListo» (ms) | «hybridwebview agregado» (ms) | Marca `primer-render` |
| --- | --- | --- | --- | --- | --- | --- |
| 1 | 3 028 | no informado | 746 | 2 627 | 2 817 | no llegó |
| 2 | 3 024 | no informado | 774 | 2 719 | 2 878 | no llegó |
| 3 | 3 014 | no informado | 852 | 2 662 | 2 811 | no llegó |
| 4 | 3 009 | no informado | 747 | 2 477 | 2 626 | no llegó |
| 5 | 3 032 | no informado | 786 | 2 627 | 2 814 | no llegó |
| Máximo | 3 032 | — | 852 | 2 719 | 2 878 | — |

Los tiempos `t=` del log de la app se cuentan desde el inicio del proceso (`Process.StartElapsedRealtime`), el mismo
reloj que P1 usa para el TPR.

## Lectura

- **Hecho.** `am start -W` devolvió `LaunchState: UNKNOWN (0)` y no informó `TotalTime` en ninguna corrida; sólo
  `WaitTime` (~3,0 s), que incluye una espera del sistema («Activity pause timeout») y no mide el primer render.
- **Hecho.** El cascarón llega a pantalla en < 0,9 s y entrega el contenido local (`ContenidoListo`, WebView agregado)
  en < 2,9 s en las 5 corridas.
- **Hecho.** La marca `primer-render` del contenido **no llegó** en ninguna corrida: a los 10 s la app registra
  «sin Listo a los 10 s» y lanza la consulta del arranque en frío; en la corrida de 45 s la consulta al canal cae por
  el timeout de 30 s. La app se declaró `SinRed` aunque el emulador tenía la red Wi-Fi `VALIDATED`, y el servidor de
  canal de la demo ya no estaba levantado.
- **Conclusión.** **TPR NO OBTENIDO en el emulador.** La cota inferior medida (WebView agregado, ≤ 2 878 ms) no es el
  TPR. Queda abierto por qué el contenido no emite `Listo` en este arranque (sin canal y con la red dada por caída): es
  un hallazgo nuevo, distinto del TPR del g42.
- Al terminar se desinstaló `com.frameworkconcept.demo` del emulador.

## Causa y nueva medición (folio 042, 2026-10-27)

| Campo | Valor |
| --- | --- |
| Fecha | 2026-10-27 16:02–16:35 (hora del emulador, UTC) |
| Dispositivo | `fc-android-emu-hpdev` (Android 13, WebView 155), recién reiniciado |
| APK | `com.frameworkconcept.demo`, Release x64 sin depuración (`flags` sin `DEBUGGABLE`), de la rama del folio 042; `sha256 5e224ac9…a40ca`; contenido `1.0.0+5d5c2b4` (semilla) |
| Procedimiento | `scripts/guion.sh tpr`: pantalla encendida y sin bloqueo comprobados, y por corrida `KEYCODE_WAKEUP` + `am force-stop` + `am start -W` + 20 s; TPR con `FrameworkConcept.Tools tpr` |
| Registros | `p1-tpr-reproduccion-pantalla-apagada.txt`, `p1-tpr-emulador-2-am-start.txt`, `p1-tpr-emulador-2-logcat.txt` |

**Causa.** La pantalla del emulador estaba apagada en las 5 corridas del cierre:

- **Hecho.** Con `input keyevent KEYCODE_SLEEP` antes del arranque, el registro es idéntico al del cierre:
  `LaunchState: UNKNOWN (0)`, `WaitTime` ~3 000 ms, «Activity pause timeout», «hybridwebview agregado» y nada más; ni un
  pedido del WebView, ni «carga iniciada», ni marca; a los 10 s, «sin Listo a los 10 s».
- **Hecho.** Al encender la pantalla, el mismo proceso pide el contenido, registra la marca y avisa «Listo».
- **Hecho.** Con la pantalla encendida, el mismo APK de `main` arrancó `COLD` y cargó el contenido.
- **Interpretación.** La marca y su camino en el contenido estaban bien: sin actividad al frente, el WebView no carga.
  Lo que faltaba era que la medición comprobara la pantalla y que el registro dijera por qué no hubo marca.

**Arreglo** (PR del folio 042 en la demo): `guion.sh tpr` (pantalla encendida, sin bloqueo, `LaunchState` guardado),
`FrameworkConcept.Tools tpr` (TPR por proceso desde el inicio del proceso hasta la línea `FC-MARCA primer-render`, con
diagnóstico de la corrida sin marca), una línea del cascarón a los 10 s si el WebView no pidió el contenido, y
`Gate.Tests/Medicion/LectorDeTprTests.cs` (4 pruebas).

| Corrida | `LaunchState` | `TotalTime` (ms) | TPR (ms) |
| --- | --- | --- | --- |
| 1 | COLD | 2 829 | 12 451 |
| 2 | COLD | 2 625 | 9 780 |
| 3 | COLD | 2 626 | 10 505 |
| 4 | COLD | 2 486 | 11 256 |
| 5 | COLD | 2 300 | 9 641 |
| Máximo | — | 2 829 | **12 451** |

- **Hecho.** 5 de 5 corridas con marca. Desglose de la corrida 2: pantalla visible 907 ms, `ContenidoListo` 5 091 ms,
  WebView agregado 5 978 ms, primer pedido 6 697 ms, marca 9 780 ms.
- **Conclusión.** **TPR OBTENIDO en el emulador: máximo 12 451 ms.** Como dice el alcance de arriba, no juzga el umbral
  de P1; el emulador recién reiniciado estaba más lento que en la medición del cierre (`ContenidoListo` ~5,1 s contra
  ~2,6 s).
- Al terminar se desinstaló `com.frameworkconcept.demo`, el emulador quedó en la pantalla de inicio y se liberó su
  reserva.

**Moto g42 — NO MEDIDO.** El candado de escenarios estuvo tomado por otra sesión de mayor prioridad de 12:16 a 14:20
(-03), con un intento por minuto en los últimos 45 minutos; el teléfono no se tocó. La condición de revisión (2) de P1
sigue abierta, sin número nuevo (folio 042).
