# Panel · didáctica (relectura integral, guía 0.11.0)

Rol: progresión, ejercicios, reproducibilidad por un alumno. A ciegas respecto de los demás paneles. Sin ediciones a la guía.

## didactica-01 · mayor · §5 «Ejemplos de §5» (y los 43 `tools/verificar.sh correr …` del texto) frente a §E.3/§E.5
- Problema: cada bloque de ejemplo ofrece `tools/verificar.sh correr NN --con-modelo` como segundo comando, sin aviso; §E.3 y §E.5 dicen que «Con otro Ollama u otro modelo, el arnés no corre, y es a propósito» y que exige `OLLAMA_VERSION_ESPERADA`, `DIGEST_4B_ESPERADO`, `OLLAMA_SERVIDOR`, `RLLM_MAQUINA` sin defecto. Un alumno con su propio servidor copia el comando y obtiene rc 2.
- Evidencia: guía, §5 «01 · Chat y streaming», bloque con `--con-modelo`; §E.5 «Con otro Ollama u otro modelo, el arnés no corre»; `tools/verificar.sh` cabecera, «estas variables NO tienen defecto; si falta una, el arnés sale con 2».
- Propuesta: en §0.3 o al abrir «Ejemplos de §5», una línea: «`--con-modelo` reproduce las corridas de la guía y sólo corre con su versión y digests; con tu servidor, usá el `docker run` de [E.5]». O rotular el segundo comando como «(sólo réplica exacta)».

## didactica-02 · mayor · §E.5, párrafo «Con 45 minutos por turno…»
- Problema: llama a `TOPE_COMPARTIDO_S` «tope de espera por llamada» que «va por encima del p90»; el arnés lo define como tope de uso del recurso compartido en el ciclo (defecto 14400 s = 4 h) y sí tiene valor por defecto en el repositorio. Contradice el código y confunde al lector que quiera ajustarlo.
- Evidencia: guía §E.5, «El tope de espera por llamada (`TOPE_COMPARTIDO_S`) … su valor … no se escribe en el repositorio»; `tools/verificar.sh` líneas 53 y 71 (`TOPE_COMPARTIDO_S="${TOPE_COMPARTIDO_S:-14400}"`).
- Propuesta: alinear el texto con el script («tope de uso del servidor compartido en el ciclo; defecto 4 h, ajustable por variable») o quitar la frase.

## didactica-03 · mayor · §15 Ítem 4 (`id="s15-i04"`)
- Problema: la tarea («Cambiá de adaptador en 02 tocando sólo `Program.cs`») tiene un criterio que ya se cumple sin hacer nada: el `grep` lista sólo `Program.cs`, la prueba `SoloProgramCs_NombraLosAdaptadores` y el oráculo «dos-adaptadores» pasan sobre el repositorio tal como viene. El alumno no puede comprobar que hizo el cambio.
- Evidencia: Ítem 4, «*Criterio.* … `grep -lE "OllamaSharp|using OpenAI" *.cs` lista sólo `Program.cs` …»; `Examples/02-Cambio-De-Adaptador/` ya trae las dos vías armadas en `RaizDeComposicion`.
- Propuesta: pedir un cambio observable (p. ej., invertir la vía por defecto o agregar una tercera vía guionada) y un criterio que lo detecte (la salida nombra el adaptador elegido), manteniendo el grep como chequeo de no filtración.

## didactica-04 · menor · §E.5, tabla de tiempo por llamada y presupuesto por turno
- Problema: la tabla por estación, «45 minutos por turno» y el presupuesto por clase son operación del laboratorio, no un paso que el alumno reproduzca; además la frase «el presupuesto de la estación 1 lo deciden el prefijo y los prompts largos» no casa con la tabla, donde los prompts de más de 5.000 tokens corrieron en la estación 2. Suma peso a una guía que ya está en 133 % del tope de palabras (`contar.sh`, 00-Preparacion).
- Evidencia: §E.5, tabla «Estación | Clase de corrida…», fila «2 | prompt de más de 5.000 tokens».
- Propuesta: dejar en §E.5 sólo qué hace el alumno; mover la tabla a §F.4 o a la bitácora, y corregir «prompts largos» → estación 2 (o quitarlo). Cifras sin cambio: ya llevan rótulo.

## didactica-05 · menor · §E.3 (`SDK_IMAGEN`) frente a §E.5 (`docker run` manual)
- Problema: §E.3 recomienda fijar `mcr.microsoft.com/dotnet/sdk:10.0.403` porque un SDK más nuevo puede romper `-warnaserror`; el `docker run` manual de §E.5 (y de `Examples/README.md`) usa `sdk:10.0` sin fijar. El alumno que sigue E.5 no reproduce el SDK de las corridas.
- Evidencia: §E.3, «fijá la imagen: `export SDK_IMAGEN=…10.0.403`»; §E.5, bloque `docker run … mcr.microsoft.com/dotnet/sdk:10.0 dotnet run -- --fake`.
- Propuesta: usar `"${SDK_IMAGEN:-mcr.microsoft.com/dotnet/sdk:10.0}"` en ambos bloques.

## didactica-06 · menor · §5 «01 · Chat y streaming», salida mostrada
- Problema: el primer ejemplo de la guía muestra como única salida con modelo una «Historia (hasta el 2026-10-28, servidor retirado)» con otro digest y otra versión de Ollama; el alumno que compara su primera corrida no tiene una referencia del entorno vigente (digest `d8b0f5e9760c`, Ollama 0.40.11), aunque §E.5 cuenta llamadas de 01 el 2026-10-29.
- Evidencia: §5, «Historia … `qwen3.5:4b` (digest `2a654d98e6fb`), Ollama 0.32.0-rc0 …»; §E.5, fila «1 | chat corto (01, 17) | 4».
- Propuesta: si existe el registro R-LLM del 2026-10-29 para 01, mostrar esa salida con rótulo completo; si no, decir explícitamente «salida vigente: no mostrada» y apuntar a la salida `--fake` de §E.4 como referencia de forma.
