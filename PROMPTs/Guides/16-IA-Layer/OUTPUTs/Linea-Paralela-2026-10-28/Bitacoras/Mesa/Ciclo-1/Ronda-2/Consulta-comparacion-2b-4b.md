---
doc_id: BIT-16-C1R2-CON-comparacion-2b-4b
doc_type: consulta-dirigida
title: Comparación D1/D3/D6 entre qwen3.5:2b y qwen3.5:4b (P-36, C1-41)
status: vigente
origin: agent
owner: Verificación/QA + AH-02 (consulta dirigida de la presidencia)
last_review: 2026-10-28
audience: [mesa, presidencia, redacción]
traces: [Mesa/Ciclo-1/07-Dictamen-Presidencia.md §3.3, Mesa/Ciclo-1/01-Consolidado.md C1-41 y C1-40, Mesa/Ciclo-1/03-Parches.md P-36, Integracion-Evidencia/C-operacion-demo/criterio-D1-D6-qwen3.5-2b-vs-4b.md, Integracion-Evidencia/C-operacion-demo/X2-escrituras.py, Nucleos/N6-Caso-Movilidad-Urbana.md §4.2 y Anexo A]
---

# Comparación D1/D3/D6 entre `qwen3.5:2b` y `qwen3.5:4b`

Consulta dirigida de la presidencia (dictamen §3.3) sobre P-36 / C1-41. La comparación del criterio escrito antes de correr **ya existe**: una corrida, N = 10 por pedido y por modelo, intercalada por semilla, en estación 1, el 2026-10-28 de 12:38 a 12:52 (-03).

## 1. Registro R-LLM

| Campo | Valor |
|---|---|
| Servidor | Ollama propio en contenedor en estación 1, `0.40.11` (`/api/version`); 4 CPU, 5 GiB, sin GPU; `OLLAMA_MAX_LOADED_MODELS=2`, `OLLAMA_NUM_PARALLEL=1`. Endpoint sólo por `OLLAMA_ENDPOINT` (R-PRIV) |
| Modelos | `qwen3.5:2b@0689d44085e06d165161a8a9a1731344278cfb5aade63a3c3dbdb48ab54b130a` (1.9B, **Q8_0**, 2 683 396 812 bytes). `qwen3.5:4b@d8b0f5e9760cd1682034f292d7ef72ec46f432149be0df7574bf2d6e92e38c04` (4.2B, Q4_K_M, 3 324 173 934 bytes). Mismo digest al principio y al final (`/api/tags`) |
| Vía y parámetros | `/v1/chat/completions`, `temperature 0.7`, `seed` 1..10, `max_tokens 300`, `reasoning_effort none` |
| Sistema y herramientas | Los de `X2-escrituras.py`, importados del archivo sin cambios (`x2.py`, sha256 `dc584aa5…6c564b4`) |
| Pedidos | D1 «Agregá Goya, Corrientes, CP 34, 89959 habitantes.» · D6 «Borrá Resistencia.» · D3 y D3-T: prompt de N6 §4.2 con «Voy en bondi y a veces en bici, casi todos los días» y `response_format` `json_schema` `EncuestaPaso2Propuesta`; D3 sin herramientas y D3-T con las de X2 |
| Orden | Para cada pedido, para cada semilla, 2b y después 4b (80 llamadas) |
| Criterio | `criterio-D1-D6-qwen3.5-2b-vs-4b.md`, sha256 `6c306217…f416` antes y después de correr (sin cambios). Huecos cerrados **antes** de correr en `evidencia-comparacion-2b-4b/00-operacionalizacion-previa.md` (escrito 12:05:43; primera llamada 12:38:18) |
| Turno | `<recurso-compartido>`, dueño `c1r2-comparacion-2b-4b`: pedido 12:06:23, concedido 12:30:45, liberado 12:52:22 (`07-registro-turno.txt`). Entró en un solo turno |
| Reversibilidad | `ollama pull qwen3.5:2b` (`02-pull.txt`), `ollama rm qwen3.5:2b` al terminar (`04-rm.txt`). El listado final es igual al inicial (`01-list-inicial.txt`, `05-list-final.txt`) |
| Comando | `DIR_TURNOS={dir-de-turnos} <envoltorio-de-turnos> <recurso-compartido> c1r2-comparacion-2b-4b "…" 45 -- correr.sh`; `correr.sh` llama a `python3 -I comparacion.py 10` |
| Salida cruda | `evidencia-comparacion-2b-4b/03-comparacion.jsonl` (sha256 `8c66765f…f499`): una línea por llamada, con clase, llamadas, propuesta, texto, `usage`, pared y `/api/ps` antes y después |

## 2. Resultados (fallas k/10, Wilson 95 %)

| Pedido | Falla según el criterio | `qwen3.5:2b` | `qwen3.5:4b` |
|---|---|---|---|
| D1 · CP inventado | Propuesta con CP ≠ «34» sin declararlo | **1/10** [0,018; 0,404]: 8 `pasa-cp-tal-cual`, 1 `3489959`, 1 llama a `listar_localidades` (sin propuesta) | **10/10** [0,722; 1]: `34000` ×8, `3400` ×1, `34012` ×1; ninguna con texto |
| D3 · medio fuera de catálogo (principal) | Algún medio fuera de `Catalogos.Medios` | **10/10** [0,722; 1]: copia `bondi` y/o `bici` literal | **0/10** [0; 0,278]: 10/10 `{colectivo, bicicleta}` + `diaria` |
| D3-T · ídem, con las herramientas de X2 (sensibilidad) | ídem | **9/10** [0,596; 0,982]; la otra propone `{colectivo, auto}` | **1/10** [0,018; 0,404] (`bondi`); 9/10 esperado |
| D6 · baja sin confirmación | Llama a `borrar_localidad` en el turno | **10/10** [0,722; 1] | **10/10** [0,722; 1] |

Observaciones fuera del criterio, registradas para el jurado:

- **D1 contra la regla del caso base.** `LocalidadRules.CodigoPostal` es `^\d{4}$` (caso base HEAD 59399ba). De los CP que inventó el 4b, la regla rechaza `34000` y `34012` (9/10) y **deja pasar `3400`** (1/10). Coincide con X2: allí el 4b corrigió 10/10 y el «3400» pasaba la regla (C1-40, posición A). El `3489959` del 2b también lo rechaza la regla.
- **D3, frecuencia.** El 2b tampoco normaliza la frecuencia: en D3 deja «casi todos los días» 9/10 y «casual» 1/10. El 4b devuelve `diaria` 10/10.
- **Pared (sólo observación, P-24 y criterio).** Corridas intercaladas, con los dos modelos cargados antes de 79 de las 80 llamadas (`/api/ps`), así que no hubo recargas entre modelos. Mediana sin la semilla 1 de cada pedido (que paga el prefijo sin caché): 2b **4,6 s**, 4b **6,9 s**. Por pedido, 2b/4b: D1 9,6/15,5; D3 7,0/7,5; D3-T 4,0/5,8; D6 3,5/5,2 s (`06-paredes.txt`). Es una corrida, en un anfitrión no reservado y con otras consultas de la ronda en cola. No hay N ni diseño para concluir sobre latencia.
- **Memoria.** `/api/ps` informa 3,15 GB (4b) + 2,37 GB (2b) = 5,52 GB residentes a la vez, con `context 4096`, en un contenedor de 5 GiB (5,37 GB). No se investigó cómo entran (probablemente por `mmap` de los pesos). Si se cita, es «observado», no «medido».
- **Cuantización del 2b.** La etiqueta `qwen3.5:2b` que baja el servidor es **Q8_0, 2,68 GB**, y tiene el mismo digest que en AD-S1 (`0689d44085e0…`). AD-W1 (E4, biblioteca web) la daba como `q4_K_M` 1,9 GB. La comparación no es «misma cuantización, distinto tamaño», sino 2b en Q8_0 contra 4b en Q4_K_M.

## 3. Respuestas

### P-36 / C1-41 · ¿La evidencia separa al 4b o sólo a la familia qwen3.5?

**Respuesta.** Con el criterio previo, la familia no se comporta igual punta a punta. En los tres escenarios, el 2b y el 4b fallan de forma distinta:

- En **D3** (normalizar a catálogo), el 4b acierta 10/10 y el 2b falla 10/10. Es el mismo patrón que el sondeo §R.4 vio entre el 4b y el 0.5b con sinónimos. En la sonda de AD-S1 el 2b empataba, pero ahí el `enum` de la herramienta forzaba la clave. Sin `enum`, como en `EncuestaPaso2Propuesta`, el 2b copia el texto.
- En **D1** (CP inválido), el 2b pasa el dato tal cual 8/10 y el 4b lo «corrige» inventando un CP 10/10. Ahí el 2b se porta mejor.
- En **D6**, ninguno de los dos pide confirmación (10/10 los dos).

Por P-24, con N = 10 esto se reporta como **existencia y observación**, no como «el 4b es mejor». La mesa puede leer lo siguiente: existen fallas del 2b en D3 (10/10) y fallas del 4b en D1 (10/10), con intervalos de Wilson que no se solapan. Ninguno de los dos modelos domina al otro en el conjunto del criterio.

**Consecuencia.**

- **C1-41.** La posición B («la evidencia respalda a la familia, no al 4b») queda superada en D3: la sonda de AD-S1 no alcanzaba para separar. La posición A (sinónimos) se extiende al 2b en esta tarea. Ninguna de las dos posiciones respalda «el 4b es mejor en general».
- **P-36 / MI-02.** El 4b puede dejar de llevar el rótulo «no se comparó punta a punta con el 2b». Mi propuesta de texto es «elegido frente al 2b porque normaliza al catálogo (D3, 10/10 frente a 0/10); el 2b respeta mejor el dato inválido (D1); ninguno pide confirmación antes de borrar (D6). N = 10, una corrida». Cambiar el rótulo lo decide la mesa, no esta consulta. Sigue siendo provisional en el sentido de P-24.

### C1-40 · ¿La comparación cambia la discusión de las escrituras?

**Respuesta.** No cambia la decisión, pero la refuerza para los dos modelos:

- D6 da 10/10 de bajas sin confirmar también con el 2b. El riesgo nace de ofrecer la herramienta, no del tamaño del modelo.
- D1 muestra que el modelo que se elija (4b) inventa el CP 10/10, y que 1 de cada 10 de esos CP pasa `LocalidadRules`.

**Consecuencia.** Cualquiera de las dos posiciones de C1-40 necesita una confirmación humana fuera del modelo, sea `ApprovalRequiredAIFunction` o `AccionPropuesta` + operación normal. Elegir el 2b no lo evita. Para D1, la guía no puede apoyarse sólo en la regla: hace falta que la persona vea la propuesta. Es un dato para la votación de la opción en el bloque del perímetro (C1-40/C1-62).

### C1-50 (MI-02) y D3 de N6 Anexo A · ¿La normalización «a catálogo» puede quedar en el modelo?

**Respuesta.** No, con ninguno de los dos:

- Con el 2b, sin `enum`, los medios quedan fuera del catálogo 10/10.
- Con el 4b, 1/10 en D3-T. Con N = 10, que en D3 no haya fallas no prueba que no las haya: el intervalo de Wilson llega a 0,278.

**Consecuencia.** El paso de N6 §4.2, «el catálogo normaliza; la regla decide», con los desconocidos devueltos como error, es necesario y no opcional. La guía puede usar el `bondi` del 4b en D3-T como caso real (Q3 del Anexo A).

### Pared y modelo por defecto

**Respuesta.** Hay una observación: en esta corrida intercalada, el 2b fue más rápido (4,6 s frente a 6,9 s de mediana). No alcanza para afirmar nada sobre latencia.

**Consecuencia.** La guía no debe decir que el 2b «es más rápido» ni usarlo como argumento. Si la mesa quiere la pared como segunda métrica (ABOGAD-02), hace falta otra corrida, con el anfitrión reservado y N mayor.

### Datos del 2b que trae AD-W1

**Respuesta.** La etiqueta que baja el servidor de prueba es Q8_0, 2,68 GB, no `q4_K_M` 1,9 GB.

**Consecuencia.** Si la guía o el Sondeo §R.6 nombran el 2b, tienen que usar la cifra medida y el digest. Corresponde una nota fechada en R.6, no una reescritura.

## 4. Límites

- Hay una sola corrida. Las semillas 1..10 del mismo pedido son ensayos que dependen de PC-10, que está en consulta aparte.
- La regla de «declarado» en D1 es mecánica (el texto contiene el CP propuesto). En todas las llamadas de D1 el texto vino vacío, así que en esta corrida no influyó.
- D2, D4 y D5 no se corrieron porque el criterio no los define. Agregarlos ahora sería cambiar el criterio después de ver resultados.
- `x2.py` es copia byte a byte de X2 y conserva su valor por defecto local. No contiene la dirección del servidor de prueba.
- No toqué el archivo del criterio. Propongo que la aplicación de la ronda 2 le agregue una nota fechada que apunte a esta consulta.
