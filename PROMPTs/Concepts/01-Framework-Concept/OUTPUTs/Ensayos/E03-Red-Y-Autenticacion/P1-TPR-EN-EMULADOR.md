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
