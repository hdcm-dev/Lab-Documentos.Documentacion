# Carta del aplicador (2)

Recibís un directorio con tres cosas:

- `conocimiento.md`: el conocimiento que tenés que aplicar.
- `A-01-ficha-vacia.md`: la ficha que tenés que llenar.
- `repo/`: el proyecto, en un commit fijo. Si el proyecto tiene más de un repositorio, cada uno está en su
  propio subdirectorio de `repo/`.

## Qué hacer

1. Leé el conocimiento y seguilo paso por paso.
2. Llená la ficha A-01 sobre el proyecto de `repo/`. Guardá la ficha llena en `salida/A-01.md`.
3. Si el conocimiento te pide producir artefactos, ponelos en `salida/`, con la ruta relativa que tendrían dentro del
   repositorio. Anotá cada uno en la sección 5 de la ficha.
4. Si te falta algo para seguir, usá el canal de demandas (abajo). Si al empezar ya existe `salida/respuestas.md`,
   leelo primero y seguí desde donde quedaste, con lo que ya está en `salida/`.

## Reglas

- **Evidencia.** Todo valor lleva su evidencia, como `ruta:línea` de un archivo que exista en `repo/`, o el comando
  de sólo lectura que corriste y lo que devolvió.
- **No inventar.** Si no encontrás el dato o el conocimiento no alcanza para decidir, escribí «pendiente» y el
  motivo: qué falta y dónde lo buscaste. No completes con un valor razonable que no tenga evidencia.
- **Decisiones de una persona.** Si el conocimiento dice que una decisión la toma una persona, no la tomes. Dejala
  listada con sus opciones y un default propuesto.
- **Suposiciones.** Si en algún punto suponés algo, anotalo en la sección 6 de la ficha: qué supusiste y por qué.
- **Sólo lectura.** No modifiques `repo/`. No escribas fuera de `salida/`.
- **Sin red.** No uses internet, servicios externos, otros repositorios ni archivos fuera de este directorio.
- **Sin contexto previo.** Usá sólo lo que hay en este directorio. Si algo parece referirse a material que no
  tenés, tratalo como dato faltante.

## Canal de demandas

Hay una persona que coordina tu corrida. Es tu **único canal hacia afuera**: no busques ni uses material por otro
camino.

1. Escribí lo que necesitás en `salida/demandas.md`, una demanda por fila, con este formato:

   | id | Qué necesito | Para qué fila |
   | --- | --- | --- |
   | Q-1 | (lo que te falta, en una oración) | (la fila de la ficha que depende de esto) |

   Los id siguen la numeración de las rondas anteriores (Q-1, Q-2, …); no reescribas demandas ya contestadas.
2. Guardá en `salida/` todo lo que llevás hecho y **terminá tu turno**. Devolvé una sola línea:
   «demandas: Q-n, …».
3. La respuesta llega en `salida/respuestas.md`, por id. Es material de este mismo directorio o la frase
   «no disponible: tratalo como dato faltante». En ese caso, la fila queda «pendiente» con su motivo.
4. Retomá la ficha con la respuesta. Podés volver a demandar.
5. **Máximo 3 rondas** de demandas. Después de la tercera, lo que falte queda «pendiente» con motivo.

Una respuesta del canal no reemplaza la evidencia: el valor que uses sigue llevando su `ruta:línea` o su comando.

## Al terminar

Devolvé la lista de archivos que escribiste en `salida/` y, en una línea, cuántas filas quedaron «pendiente». Si
terminás el turno por una demanda, devolvé sólo la línea del paso 2 del canal.
