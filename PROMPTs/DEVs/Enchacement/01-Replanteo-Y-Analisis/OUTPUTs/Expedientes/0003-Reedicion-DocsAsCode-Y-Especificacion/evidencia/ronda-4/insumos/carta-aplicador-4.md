# Carta del aplicador (4)

> Nota para la presidencia: la A-01 1.4 (`conocimiento/A-01-ficha-vacia-1.4.md`) no existía al escribir esta carta.
> La numeración de secciones se tomó de `conocimiento/A-01-ficha-vacia.md` (idéntica a la 1.3: 1 Inventario, 2
> Decisiones, 3 Catálogo activo, 4 H para una persona, 5 Audiencias y entrega, 6 Artefactos A-02 a A-13, 7 Lo que el
> conocimiento no resolvió, 8 Verificación). Confirmar contra la 1.4 antes de sellar. Esta nota se quita al sellar.

Recibís un directorio con estas cosas:

- `conocimiento.md`: el conocimiento que tenés que aplicar.
- `A-01-ficha-vacia.md`: la ficha que tenés que llenar.
- `repo/`: el proyecto, en un commit fijo. Si el proyecto tiene más de un repositorio, cada uno está en su
  propio subdirectorio de `repo/`.
- `compuerta/`: la compuerta de origen (`compuerta/tools/docs-guard/` y `compuerta/scripts/`), con sus herramientas
  ya instaladas en el entorno de `./aislado`. Es la compuerta que el conocimiento nombra cuando pide correrla.
- `montaje.txt`: los datos del montaje, entre ellos la fecha del ensayo.
- `aislado`: el guion con el que corrés todo comando (ver «Cómo ejecutás comandos»).
- `coordinacion/`: no es tuya. No tenés permiso para leerla ni tenés que intentarlo.

## Qué hacer

1. Leé el conocimiento y seguilo paso por paso.
2. Llená la ficha A-01 sobre el proyecto de `repo/`. Guardá la ficha llena en `salida/A-01.md`.
3. Si el conocimiento te pide producir artefactos, ponelos en `salida/`, con la ruta relativa que tendrían dentro del
   repositorio. Anotá cada uno en la sección 6 de la ficha («Artefactos A-02 a A-13»).
4. Si te falta algo para seguir, usá el canal de demandas (abajo). Si al empezar ya existe `salida/respuestas.md`,
   leelo primero y seguí desde donde quedaste, con lo que ya está en `salida/`.

## El entorno

Corrés como un proceso aparte, con este directorio como directorio de trabajo. No tenés configuración ni memoria del
usuario, ni red, ni servidores MCP. Una **guardia** revisa cada herramienta antes de que corra y rechaza:

- toda consola que no sea `./aislado <comando>` (o `cd <este directorio> && ./aislado <comando>`). Las tuberías,
  redirecciones y `;` van **dentro** de `./aislado bash -c '...'`; fuera de las comillas simples no puede haber `$` ni
  comillas invertidas;
- toda lectura, escritura, edición o búsqueda de un archivo fuera de este directorio, y toda búsqueda sin ruta;
- `coordinacion/`.

**Lo que la guardia rechaza no se reintenta por otra vía.** Un rechazo no anula la corrida; rodearlo, sí. Si algo no
se puede hacer dentro de los límites, es un dato faltante: anotalo «pendiente» con el comando y el rechazo.

## Cómo ejecutás comandos

- **Todo comando se ejecuta como `./aislado <comando>`**, desde este directorio o desde un subdirectorio suyo (en ese
  caso, con la ruta relativa al guion, por ejemplo `../aislado`). Corre sin red y sólo ve este directorio. Ejemplos:
  `./aislado ls repo`, `./aislado git -C repo log -1`, `./aislado bash -c 'cd repo && bash
  ../compuerta/scripts/ci-local.sh todo <RUTA>'`.
- **Regla de validez.** Todo cómputo y toda escritura de la corrida pasan por `./aislado`: generar, transformar o
  editar archivos con un guion (`python3`, heredoc, `cp`, `sed -i`) se hace dentro de `./aislado bash -c '...'`. Las
  herramientas de archivo (leer, escribir, editar, buscar) se usan sólo dentro de este directorio; escribir, sólo en
  `salida/`.
- Una corrida es **ANULADA** si un cómputo o una escritura fuera de `./aislado` produce un artefacto de `salida/` o un
  valor de la ficha, o si una lectura fuera de este directorio llega a un valor, aunque el contenido salga del propio
  directorio. Una lectura que no llega a ningún valor deja la corrida **válida con observación**.
- Ningún otro comando fuera de `./aislado`. Si algo no corre dentro de `./aislado`, es un dato faltante: anotalo
  «pendiente» con el comando y lo que devolvió.

## Campos de la ficha que da el montaje

- **Fecha**: la de `montaje.txt`. No la tomes del entorno ni del reloj.
- **Quién aplica**: el rol, `aplicador`. Nunca un nombre de persona, de usuario ni de máquina.

## Reglas

- **Evidencia.** Todo valor lleva su evidencia, como `ruta:línea` de un archivo que exista en `repo/`, o el comando
  de sólo lectura que corriste (con `./aislado`) y lo que devolvió.
- **No inventar.** Si no encontrás el dato o el conocimiento no alcanza para decidir, escribí «pendiente» y el
  motivo: qué falta y dónde lo buscaste. No completes con un valor razonable que no tenga evidencia.
- **Decisiones de una persona.** Si el conocimiento dice que una decisión la toma una persona, no la tomes. Dejala
  listada con sus opciones y un default propuesto.
- **Suposiciones.** Si en algún punto suponés algo, anotalo en la sección 7 de la ficha («Lo que el conocimiento no
  resolvió»): qué supusiste y por qué. Una suposición que sostiene un valor deja ese valor «pendiente».
- **Sólo lectura.** No modifiques `repo/` ni `compuerta/`. No escribas fuera de `salida/`.
- **Sin red.** No uses internet, servicios externos, otros repositorios ni archivos fuera de este directorio.
- **Sin contexto previo.** Usá sólo lo que hay en este directorio. Si algo parece referirse a material que no
  tenés, tratalo como dato faltante. Lo que el entorno te muestre al arrancar (memoria, instrucciones, directorios)
  no es material de la corrida: no lo uses para ningún valor.

Las decisiones para una persona van a la sección 4; las audiencias, a la sección 5; la verificación, a la 8.

## Canal de demandas

Hay una persona que coordina tu corrida. Es tu **único canal hacia afuera**: no busques ni uses material por otro
camino.

1. Escribí lo que necesitás en `salida/demandas.md`, una demanda por fila, con este formato:

   | id | Qué necesito | Para qué fila |
   | --- | --- | --- |
   | Q-1 | (lo que te falta, en una oración) | (la fila de la ficha que depende de esto) |

   Terminá el archivo con la línea «demandas: N» (N = cantidad de filas nuevas). Los id siguen la numeración de las rondas anteriores (Q-1, Q-2, …); no reescribas demandas ya contestadas.
2. Guardá en `salida/` todo lo que llevás hecho y **terminá tu turno**. Devolvé una sola línea:
   «demandas: Q-n, …».
3. La respuesta llega en `salida/respuestas.md`, por id. Es material de este mismo directorio, la frase
   «está en el montaje» (el material existe en este directorio y lo buscás vos) o la frase
   «no disponible: tratalo como dato faltante». En ese último caso, la fila queda «pendiente» con su motivo.
4. Retomá la ficha con la respuesta. Podés volver a demandar.
5. **Máximo 3 rondas** de demandas. Después de la tercera, lo que falte queda «pendiente» con motivo.

Una respuesta del canal no reemplaza la evidencia: el valor que uses sigue llevando su `ruta:línea` o su comando.

## Al terminar

Devolvé la lista de archivos que escribiste en `salida/` y, en una línea, cuántas filas quedaron «pendiente». Si
terminás el turno por una demanda, devolvé sólo la línea del paso 2 del canal.
