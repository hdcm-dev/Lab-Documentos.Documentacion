| Campo | Valor |
| --- | --- |
| Tipo | constancia |
| Fecha | 2026-10-28 |
| Autor | Presidencia de la mesa |
| Corrige | — |

# Constancia — TPR en el moto g42

El 2026-10-28 a la noche el PO conectó el moto g42 a su PC para medir. Era el pendiente que dejaron abierto los folios
040 y 042: el TPR en el teléfono de gama media que fija el umbral de P1.

## Hecho

- **Candado.** En hpdev se tomaron los dos candados del teléfono durante toda la operación: el de las escenas y el del
  directorio de reservas compartido. Antes de usar el adb remoto se comprobó que la versión del servidor coincidiera con
  la del cliente. Se tocó sólo `com.frameworkconcept.demo`: se instaló, se midió y se desinstaló. Al terminar no quedó
  ningún paquete `com.frameworkconcept.*` en el teléfono.
- **APK.** Es la Release arm64 sin depuración que se compiló en i7infra la madrugada del 28 (folio 046). La demo no
  cambió entre ese commit y `main`, y el sha256 coincide.
- **Medición.** `scripts/guion.sh tpr`, con 5 arranques en frío (`COLD`). El contenido cargó y llegó a «puente Listo» en
  todas las corridas: de 7 308 a 7 715 ms en régimen y 9 661 ms en la primera, que activa la semilla. La marca
  `primer-render` no llegó al logcat. Viaja por la consola del WebView, y en una lectura aparte del logcat completo (que
  alcanzó las corridas 4 y 5) no hay ningún mensaje de consola del contenido, sólo avisos del motor. El instrumento dio **TPR NO OBTENIDO**.
- **Cotas.** Por la marca del emulador, que llega antes que «puente Listo», el TPR del g42 queda entre «carga iniciada»
  y «puente Listo»: de 4,4 a 7,7 s en régimen. Con la distancia que se midió en el emulador, el estimado es de unos 6,7 a
  7,7 s, y de unos 9,1 a 9,6 s en la primera corrida. El detalle está en `Ensayos/E03-Red-Y-Autenticacion/P1-TPR-G42.md`.

## Conclusión

La condición de revisión (2) de P1 **sigue abierta**. Hay un indicio fuerte de que el umbral de 5 000 ms no se cumple
en el g42, coherente con el estimado de unos 7,5 s de E02. No es una medición por la definición del TPR, porque la cota
inferior medida está por debajo del umbral. Para cerrar la condición hace falta que la marca viaje por una vía que el
cascarón registre. Ese cambio en la demo queda pendiente de la decisión del PO.

## Pase

Archivo. El expediente sigue ARCHIVADO.
