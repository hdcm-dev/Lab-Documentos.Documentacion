# U25 — Corrida vigente de los guiones que cita el cuerpo SDEI

Unidad U25 del expediente 0003 (resolución, P-12 y P-10). Se vuelven a correr los guiones de
`../../../0002-Replanteo-Metodologia-DocAsCode/evidencia/E1-U4b/` que el cuerpo SDEI de Lab-Documentos cita como
evidencia, contra el Lab-Documentos actual, y se compara cada salida con la histórica.

- **Fecha de la corrida:** 2026-11-01 (19:37 UTC para 01 a 03; 04 a continuación).
- **Lab-Documentos actual:** `main` en `0bed863` (PR #41).
- **Equivalencias de P-10:** la salida histórica se tomó sobre `080f158`, que tras la reescritura de la historia se
  lee como «PR #19, merge `e3841b6`»; `fe10086` se lee como «PR #25, merge `6878568`». Para comprobar la equivalencia,
  los guiones 01 a 03 se corrieron también sobre `e3841b6` en un clon temporal (borrado al terminar).
- **Entorno:** Python 3 del host, `bash`, `curl`, `jq` y `git`; sin credenciales (API pública de GitHub, anónima).

## Índice

| Guion | Lo cita | Salida vigente | Contra el equivalente | `diff` frente a la histórica | Estado |
| --- | --- | --- | --- | --- | --- |
| `01-tem01-inventario.sh` | `TEM-01` (ensayo de inventario) | [`01-tem01-inventario.salida-0bed863.txt`](01-tem01-inventario.salida-0bed863.txt) | [`01-tem01-inventario.salida-e3841b6.txt`](01-tem01-inventario.salida-e3841b6.txt) | [`01-tem01-inventario.diff`](01-tem01-inventario.diff), [`01-tem01-inventario.equivalente.diff`](01-tem01-inventario.equivalente.diff) | Reproducido; cambian los conteos (ver abajo) |
| `02-tem02-rrd.sh` | `TEM-02` (ensayo del RRD) | [`02-tem02-rrd.salida-0bed863.txt`](02-tem02-rrd.salida-0bed863.txt) | [`02-tem02-rrd.salida-e3841b6.txt`](02-tem02-rrd.salida-e3841b6.txt) | [`02-tem02-rrd.diff`](02-tem02-rrd.diff), [`02-tem02-rrd.equivalente.diff`](02-tem02-rrd.equivalente.diff) | Reproducido: rojo y verde |
| `03-tem03-ancla.sh` | `TEM-03` (traza desfasada e ID ambiguo) | [`03-tem03-ancla.salida-0bed863.txt`](03-tem03-ancla.salida-0bed863.txt) | [`03-tem03-ancla.salida-e3841b6.txt`](03-tem03-ancla.salida-e3841b6.txt) | [`03-tem03-ancla.diff`](03-tem03-ancla.diff), [`03-tem03-ancla.equivalente.diff`](03-tem03-ancla.equivalente.diff) | Reproducido: rojo, verde, rojo |
| `04-adopciones.sh` | `TEM-01` y `TEM-03` (adopciones con fecha), `99-Anexos/Referencias.md` §7 | [`04-adopciones.salida-2026-11-01.txt`](04-adopciones.salida-2026-11-01.txt) | No aplica: consulta la API de GitHub, no Lab-Documentos | [`04-adopciones.diff`](04-adopciones.diff) | Corrió; reproducido en parte: 16 de 17 filas (ver abajo) |

Los guiones `00` y `05` de la misma carpeta no los cita el cuerpo; no se corrieron.

## Comandos

```bash
E=PROMPTs/DEVs/Enchacement/01-Replanteo-Y-Analisis/OUTPUTs/Expedientes/0002-Replanteo-Metodologia-DocAsCode/evidencia/E1-U4b
LD=<clon de Lab-Documentos en 0bed863>
bash $E/01-tem01-inventario.sh "$LD" > 01-tem01-inventario.salida-0bed863.txt
bash $E/02-tem02-rrd.sh        "$LD" > 02-tem02-rrd.salida-0bed863.txt
bash $E/03-tem03-ancla.sh      "$LD" > 03-tem03-ancla.salida-0bed863.txt
bash $E/04-adopciones.sh             > 04-adopciones.salida-2026-11-01.txt   # corte: hoy

# Equivalente de P-10: clon temporal en e3841b6
git clone <Lab-Documentos> ld-e3841b6 && git -C ld-e3841b6 checkout e3841b6
bash $E/01-tem01-inventario.sh ld-e3841b6 > 01-tem01-inventario.salida-e3841b6.txt   # ídem 02 y 03

# Diferencias (la histórica es NN-salida.txt de E1-U4b)
diff -u $E/01-salida.txt 01-tem01-inventario.salida-0bed863.txt > 01-tem01-inventario.diff   # ídem el resto
```

Los cuatro guiones terminaron con código 0 (02 y 03 imprimen el `rc` de cada caso dentro de la salida).

## Diferencias explicadas

### Equivalencia de P-10 (`080f158` → `e3841b6`)

Sobre `e3841b6`, las salidas de 01, 02 y 03 son idénticas a las históricas; la única línea distinta es
`commit: 080f158` → `commit: e3841b6` en 01. Queda comprobado que la salida histórica se reproduce con el SHA
equivalente.

### `01-tem01-inventario.sh` (sobre `0bed863`)

- `commit:` pasa a `0bed863`.
- Aparecen `tema 7` y `proceso 2`. La salida histórica es anterior a los temas: se corrió sobre la base del PR que
  los agregó, y en `e3841b6` el cuerpo no tenía ningún `TEM-*` (`git ls-tree e3841b6`). Los `tema` son `TEM-01` a
  `TEM-07` (PR #22, #24 y #23); los `proceso` son `Examples/Como-Intervenir.md` y
  `Examples/Como-Intervenir-Lab-Documentos.md` (PR #23).
- Sin cambios: los otros once conteos, las piezas que no son prosa y los cuatro workflows.
- Para el libro: el bloque de `TEM-01` y su lectura («el cuerpo de estudio (`indice`, `marco-de-referencia`, `mapa`,
  `anexo`) es CL-10») no mencionan `tema` ni `proceso`; si el libro cita la corrida vigente, la lectura tiene que
  ubicarlos (P-12 a).

### `02-tem02-rrd.sh`

Mismos errores, mismo resultado (rojo con `rc=1`, verde con `rc=0`). La línea de resumen suma el contador
`readme-del-cuerpo-sin-frontmatter=0`, que agregó a `dg.py` el commit `4750354` (PR #31). El bloque citado en `TEM-02`
muestra la línea de resumen vieja: si se cita la corrida vigente, esa línea cambia.

### `03-tem03-ancla.sh`

El resultado esperado se mantiene: rojo, verde, rojo. Cambia el detalle del caso 3:

- La compuerta agrega dos errores `id-duplicado` (`fichas.md:17` y `otra-guia.md:17`): el control de IDs duplicados
  entró con el commit `4750354` (PR #31). El caso 3 pasa de `errores=3` a `errores=5`.
- Las tres líneas de resumen suman el contador `ids-duplicados` (0, 0 y 2).
- Para el libro: el bloque recortado de `TEM-03` muestra `errores=3`; con la compuerta vigente son `errores=5`. Es
  una cita a corregir en el PR del libro (P-12 a), y el texto que sigue («un identificador repetido…») queda reforzado
  por el error nuevo.

### `04-adopciones.sh`

Corre (`rc=0`), pero no reproduce una fila:

- **Fila P6 `facebook/docusaurus`: «no reproducido».** La API responde `301 Moved Permanently`: el repositorio se
  mudó a `meta/docusaurus`, y el guion llama a `curl -fsS` sin `-L`, así que no sigue la redirección; `jq` falla
  («Cannot index object with number») y la fila sale `SIN COMMITS`. La consulta manual siguiendo la redirección
  ([`04-diagnostico-docusaurus.txt`](04-diagnostico-docusaurus.txt)) da `c5bc92e92849`, 2026-10-29, dentro de la
  ventana, y `website/versioned_docs/` con doce carpetas, de `version-2.x` a `version-3.10.2`: lo que afirma la tabla
  de `TEM-03` («doce versiones de la 2.x a la 3.10») sigue en pie. El guion histórico no se modifica (es evidencia del
  expediente 0002); el arreglo (`curl -L` o el nombre nuevo del repositorio) y la cita de `TEM-03` quedan para el PR
  que reescriba esa cita (P-12 a).
- **Las otras 16 filas reproducen** la práctica, el repositorio, la ruta y el veredicto «≤24m: sí». Cambian, como es
  de esperar en una consulta fechada, el commit y la fecha de las rutas con actividad posterior al 2026-10-27 (github/docs,
  kubernetes/website, azure-docs, rest-api-description, stripe/openapi, backstage, grafana/docs, istio.io). Quedan
  iguales los tres `.vale.ini` de P3, el workflow de enlaces de github/docs, jest y el conteo de ramas `release-1.*`
  (33 y 33, últimas `release-1.36` y `release-1.31`).
- La ventana es la del corte: `2026-11-01` → desde `2024-11-01`.

## Qué cambia en las citas

| Cita en el cuerpo | Salida vigente | Acción (P-12 a) |
| --- | --- | --- |
| `TEM-01`, inventario, «sobre el commit `080f158`» | Equivalente `e3841b6` idéntico; en `0bed863` suma `tema 7` y `proceso 2` | P-10: «PR #19, merge `e3841b6`»; si se cita la vigente, actualizar bloque y lectura |
| `TEM-02`, RRD, «sobre el commit `080f158`» | Idéntico en `e3841b6`; en `0bed863`, contador nuevo en el resumen | P-10; actualizar la línea de resumen si se cita la vigente |
| `TEM-03`, ancla, «sobre el commit `080f158`» | Idéntico en `e3841b6`; en `0bed863`, caso 3 con `errores=5` e `id-duplicado` | P-10; corregir el bloque si se cita la vigente |
| `TEM-01` y `TEM-03`, adopciones del 2026-10-27 | 16 de 17 filas reproducen; P6 Docusaurus no, por la mudanza a `meta/docusaurus` | Rotular la fila Docusaurus «no reproducido» hasta que el guion siga redirecciones; la afirmación de la tabla sigue en pie |
