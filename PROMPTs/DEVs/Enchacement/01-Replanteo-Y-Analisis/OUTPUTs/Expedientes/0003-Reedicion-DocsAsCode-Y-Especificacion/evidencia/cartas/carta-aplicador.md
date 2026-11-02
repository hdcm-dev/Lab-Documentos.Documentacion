# Carta del aplicador

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

## Al terminar

Devolvé la lista de archivos que escribiste en `salida/` y, en una línea, cuántas filas quedaron «pendiente».
