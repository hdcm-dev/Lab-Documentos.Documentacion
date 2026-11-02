# Panel de operación · relectura integral de la guía 0.11.0 (B-14)

Rol: operación (despliegue, observabilidad, presupuesto de §E.5, inventario y limpieza, turnos y reproducibilidad de los scripts). Trabajo a ciegas, sin leer otros paneles. La guía no se editó.

## operacion-01 · bloqueante · E.3 / E.1 frente a `tools/verificar.sh`
- Problema: el arnés exige en el segundo servidor el modelo y digest históricos, retirados el 2026-10-28; con las estaciones vigentes de F.4 las fases 2 y 4 no pueden correr.
- Evidencia: `tools/verificar.sh` líneas 77-79 (`OLLAMA_VERSION_PROPIO="0.40.11"`, `DIGEST_CHAT_PROPIO="a8b0c5157701"   # qwen2.5:0.5b`) y 452-460 (busca `qwen2.5:0.5b` y aborta si no coincide). F.4: las estaciones 1 y 2 sólo listan `qwen3.5:4b` `d8b0f5e9760c` y `qwen3-embedding:0.6b`. E.3: «El arnés no corre contra un segundo servidor cuya versión o cuyos digests no sean los de las corridas de la guía». La corrida R-15 de 15 usó `qwen3.5:4b` en la estación 2 (`Examples/15-…/ejemplo.json`, campo `estado`).
- Propuesta: alinear los valores esperados del arnés con las corridas vigentes, o decir en E.3 que el arnés todavía valida el servidor histórico y que la fase vigente se corrió fuera de él. La tabla E.1 (filas 02, 05 y 15) y la fila `OLLAMA_PROPIO_MODEL` de A.12 tienen que rotular `qwen2.5:0.5b` como historia.

## operacion-02 · mayor · E.5, párrafo del tope frente a `verificar.sh` y `Examples/README.md`
- Problema: la guía dice que el valor de `TOPE_COMPARTIDO_S` «lo fija quien opera el laboratorio y no se escribe en el repositorio», pero el repositorio tiene un valor por defecto.
- Evidencia: `tools/verificar.sh` línea 71 (`TOPE_COMPARTIDO_S="${TOPE_COMPARTIDO_S:-14400}"`) y línea 53 (comentario «default 14400 s = 4 h, §E.5»); `Examples/README.md` línea 69 («14.400 s»).
- Propuesta: o se quita el defecto del script (y la variable pasa a ser obligatoria en modo compartido), o la guía declara el defecto de 4 h y que el operador lo ajusta.

## operacion-03 · mayor · E.5, presupuesto de llamadas
- Problema: la tabla por clase no dice de qué corridas sale (no tiene registro R-LLM: k/n, turno o archivo), y mezcla rangos «de a» con medianas sin decir sobre qué subconjuntos se calcularon. «Con 45 minutos por turno» se da como dato del laboratorio, pero no hay variable ni fuente.
- Evidencia: el texto «Tiempo de reloj por llamada de `qwen3.5:4b`, observado en las corridas del 2026-10-29 … descriptivo» y filas como «chat corto (01, 17) | 4 | 12,1 a 45,0 s».
- Propuesta: atar cada fila al registro (`turnos.jsonl` o `RLLM_DIR/<ejemplo>.jsonl`) y explicar que el rango es entre ejemplos; presentar los 45 min como parámetro del operador, no como constante.

## operacion-04 · mayor · E.6 (sin inventario ni limpieza)
- Problema: ni la guía ni los scripts explican cómo inventariar y limpiar lo que crea el arnés: contenedores y volúmenes etiquetados con `ETIQUETA`, `VOLUMEN_NUGET` y `VOLUMEN_ARTEFACTOS`, `RLLM_DIR`, `seco/`, la marca `.concedido.*` y el `bin/`/`obj/` de un `docker run` manual.
- Evidencia: buscar `ETIQUETA|VOLUMEN_|limpi` en la guía no da ninguna coincidencia de operación. `verificar.sh` usa `--label "$ETIQUETA"` (línea 155) y `mktemp "$RLLM_DIR/.concedido.XXXXXX"` (línea 170). La receta manual de E.5 monta `$PWD/Examples` con permiso de escritura, así que deja `bin/` y `obj/` dentro del árbol.
- Propuesta: sumar a E.6, o a un E.6 bis, un inventario mínimo (`docker ps -a --filter label=…`, `docker volume ls`) y una limpieza que no borre registros. Además, advertir que el `docker run` manual ensucia el árbol y que conviene correrlo sobre una copia.

## operacion-05 · menor · `Examples/15-Pruebas-Y-Evaluacion/ejemplo.json`, campo `estado`
- Problema: el estado quedó viejo, porque dice que R-15b «no había cerrado».
- Evidencia: según 00-Preparacion, R-15b cerró con 41/52 interpretables, por debajo del criterio de 45/52, y quedó «no medido».
- Propuesta: actualizarlo a «R-15b cerrada: no medido (41/52 interpretables < 45/52)», con el rótulo `qwen3.5:4b`@`d8b0f5e9760c`, estación 2, Ollama 0.40.11, 2026-10-29.

## operacion-06 · menor · E.3, párrafo del SDK frente a F.4
- Problema: E.3 recomienda fijar `sdk:10.0.403`, pero `compose.yaml` (línea 19) y la receta manual de E.5 usan `sdk:10.0` sin fijar. Así, quien sigue el camino de §12.6 no reproduce la imagen de las corridas.
- Evidencia: «fijá la imagen: `export SDK_IMAGEN=…:10.0.403` (la usan `verificar.sh` y `demo.sh`)»; `compose.yaml` no lee `SDK_IMAGEN`.
- Propuesta: decir que el compose y el `docker run` manual no respetan `SDK_IMAGEN`, o parametrizar el compose con `${SDK_IMAGEN:-…}`.

## operacion-07 · menor · §12.8 y §12.1 (observabilidad de la demo)
- Problema: la demo usa `UseOpenTelemetry` sin exportador. Lo que emite no se observa en ningún lado, y la guía no lo verifica para la demo como sí lo hace para 17.
- Evidencia: «`UseOpenTelemetry` sólo en el chat, sin exportador» y «nada llama a `AddOpenTelemetry`».
- Propuesta: rotular la telemetría de la demo como «no observada» o «no ejecutada», sin que el lector infiera que se puede ver en un panel.
