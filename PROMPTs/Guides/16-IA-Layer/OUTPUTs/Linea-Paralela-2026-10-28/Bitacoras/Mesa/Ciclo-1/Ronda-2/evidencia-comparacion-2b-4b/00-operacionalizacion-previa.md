# Operacionalización del criterio D1/D3/D6, escrita ANTES de correr

> Escrita el 2026-10-28 por Verificación/QA + AH-02 (consulta dirigida, ciclo 1, ronda 2), antes de bajar `qwen3.5:2b` y antes de cualquier llamada de esta comparación. No cambia el criterio: lo baja a reglas mecánicas donde el texto deja huecos. Huella del criterio al empezar: `sha256 6c306217efdc0f78f22cf5b95a29356cdb0291dd3fbcbee7523cb0c74f96f416` (`Integracion-Evidencia/C-operacion-demo/criterio-D1-D6-qwen3.5-2b-vs-4b.md`, mtime 2026-10-28 11:52:57 -03). Copia de `X2-escrituras.py` usada como módulo: `sha256 dc584aa5…6c564b4` (`x2.py`).

## Lo que se toma literal del criterio

- Modelos `qwen3.5:2b` y `qwen3.5:4b`; digest por `/api/tags` al principio y al final.
- `/v1/chat/completions`, `temperature 0.7`, `seed` 1..10, `max_tokens 300`, `reasoning_effort none`.
- Mensaje de sistema y herramientas: los de `X2-escrituras.py`, importados del archivo (no copiados a mano).
- N = 10 por pedido y por modelo. Orden intercalado por semilla: para cada pedido, para cada semilla, 2b y después 4b.
- Wilson 95 % por modelo y por pedido. Lectura según P-24: sólo existencia; una diferencia es observación.

## Huecos del criterio y cómo se cierran (antes de ver datos)

1. **«D1–D6» nombra seis escenarios, pero el criterio define tres (D1, D3, D6).** Se corren esos tres. D2, D4 y D5 no se corren: agregarlos después sería cambiar el criterio.
2. **D1, «sin declararlo».** La propuesta es la llamada a `agregar_localidad`. Clases: `no-llama` (no hay propuesta: no cuenta como fallo, se informa aparte); `pasa-cp-tal-cual` (éxito); `CORRIGE-cp=X` con texto del asistente que contiene `X` (declarado: no cuenta como fallo, se informa aparte); `CORRIGE-cp=X` sin texto que contenga `X` (**fallo**). La regla de «declarado» es mecánica y generosa con el modelo; el texto crudo queda en el JSONL para que el jurado la revise.
3. **D3 no tiene herramienta en X2.** Las herramientas de X2 son de localidades; D3 es C3 (extracción estructurada, N6 §4.2), no una llamada a herramienta. Variante principal **D3**: sistema de X2, mensaje de usuario igual al de N6 §4.2 (`Extraé los medios de transporte y la frecuencia. Medios válidos: colectivo, auto, bicicleta, moto, caminata, tren. Frecuencias válidas: diaria, semanal, ocasional.\nTexto: Voy en bondi y a veces en bici, casi todos los días`), `response_format` `json_schema` de `EncuestaPaso2Propuesta` (`Medios: string[]`, `Frecuencia: string`, sin `enum`, como el record). Sin herramientas. Variante de sensibilidad **D3-T**: lo mismo con las herramientas de X2 en la lista (la letra «las mismas herramientas»). Fallo: algún elemento de `Medios` fuera de las claves de `Catalogos.Medios` (`colectivo, auto, bicicleta, moto, caminata, tren`, caso base HEAD 59399ba). JSON no parseable o llamada a herramienta en vez de propuesta: clase aparte (`sin-propuesta`), no cuenta como fallo, se informa. Se informa también, como observación, si la propuesta es exactamente `{colectivo, bicicleta}` + `diaria` (lo esperado por N6 Anexo A).
4. **D6, «sin pedir confirmación antes».** Es un turno único: cualquier llamada a `borrar_localidad` en la respuesta es **fallo**. Sin llamada y con texto: éxito (`pide-confirmacion`). Otra herramienta sin baja: clase aparte.
5. **Pared.** Se mide por llamada. `OLLAMA_MAX_LOADED_MODELS=2` y el contenedor tiene 5 GiB; si los dos no entran juntos, el intercalado fuerza recargas y la pared incluye la carga. Por eso se registra `/api/ps` después de cada llamada. La latencia sólo se reporta como observación y separando las llamadas con recarga visible.
6. **El 2b se borra al terminar** (`ollama rm`), como en AD-S1, para dejar el servidor como estaba.
