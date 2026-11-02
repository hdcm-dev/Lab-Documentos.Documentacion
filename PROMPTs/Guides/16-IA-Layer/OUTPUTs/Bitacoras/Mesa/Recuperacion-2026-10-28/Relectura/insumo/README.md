# Insumo de la relectura integral (REC-04)

Esta carpeta guarda **insumo de lectura**. **No son hallazgos de esta mesa**. Son los 13 `Informe-*.md` del ciclo 1 de la mesa de la línea archivada (`$INSUMO/Bitacoras/Mesa/Ciclo-1/`), copiados pieza por pieza en B-14 paso 2 (plan [`../../03-Plan-De-Recuperacion.md`](../../03-Plan-De-Recuperacion.md), B-14 punto 4; matriz REC-04 A).

## Qué revisaron y por qué no aplican tal cual

- Revisan **la guía de la línea archivada**, no la 0.11.0 de la base. Esa guía tiene otra numeración de secciones, otro texto y otras carpetas de `Examples/`. Las líneas (`L…`, `l. …`), los ID de núcleo (N0…N6, BIT-16-04, REED-16) y las rutas que citan son de esa línea.
- Cada lector de la relectura **traduce la numeración** con la tabla de correspondencia **DECI-30** y **descarta lo que no aplica a la base**. Si un hallazgo sigue vigente en la 0.11.0, lo vuelve a escribir con su ubicación en la base (ancla y texto único) y su propia evidencia. Citar el informe del insumo no alcanza.
- Las remisiones relativas de los informes (`evidencia-…/`, `Ronda-2/…`) apuntan a carpetas del insumo que **no se copiaron**. Para verlas hay que ir a `$INSUMO/Bitacoras/Mesa/Ciclo-1/`, sólo lectura.

## Tabla DECI-30 (dónde está)

Está en [`../../Inventario-decisiones.md`](../../Inventario-decisiones.md), §4 «Correspondencia de ejemplos para trasladar contenido de <equipo-de-contingencia>». Traduce carpetas de `Examples/` del insumo a carpetas de la base. Ejemplos: 04-Embeddings → 06, 05-RAG → 07, 06-Tool-Calling → 08 y 09, 09-Pruebas-Con-Cliente-Falso → 15 (caché y pipeline: 17), 13-Prueba-De-Arquitectura → `Cableado/ArquitecturaTests.cs` de la demo. Las secciones de la guía del insumo no tienen tabla: se ubican por tema en la 0.11.0.

## Redacciones (RPRI-18) y barrido

| Original | En la copia |
|---|---|
| equipo de la línea archivada | `<equipo-de-contingencia>` |
| equipo principal | `<equipo-principal>` |
| estación 2 (por su nombre de equipo) | `<estación-2>` |
| teléfono de prueba | `<teléfono-de-prueba>` |
| recurso de turnos del modelo | `modelo-compartido` (RPRI-04) |
| herramienta de turnos | `<gestor-de-turnos>` |
| directorio de trabajo del laboratorio | `$TRABAJO/` |
| ruta de un directorio del home | `{dir-de-trabajo}` |
| rango de direcciones de la red privada | `<rango-de-la-red-privada>` |
| clave de cabeceras por pedido del adaptador | `<clave-de-cabeceras-por-pedido>` |

No hay ningún otro cambio. Arquitectura y didáctica se copiaron sin tocar. La lista de cada pieza, con el sha256 de origen y de destino, está en [`../../Procedencia.md`](../../Procedencia.md), filas PI-01…PI-13 de la §6.

Barrido ampliado (`evidencia-rpriv/rpriv-ampliado.sh`, lista de identificadores fuera del repo) sobre las 13 copias: **0** en las siete clases. La compuerta R-PRIV del repo (`tools/compuerta-rpriv.sh`) da 2 en «ip-privada», y los dos son la cadena de versión `10.11.0.0` (AH-01 l. 128, verificación/QA l. 37), que es un falso positivo conocido (RPRI-19). Se dejaron como están porque son texto del informe y no una dirección.
