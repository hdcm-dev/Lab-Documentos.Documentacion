# M4 — Invenciones del caso C1, ronda 2: verificación del refutador

Este informe cubre el caso C1 de la ronda 2, corridas `C1-r1` y `C1-r2` (099 §5.5; folio 200 §7). La medida M4
define una invención como una cita `ruta:línea` que no existe o que no sostiene lo afirmado. La medida pasa con 0.
Todas las rutas de este informe son relativas al directorio de cada corrida (`repo/`, `salida/`, `conocimiento.md`).

## Resultado

| Corrida | Citas del aplicador (distintas) | Archivo o línea inexistente | Revisadas a mano | No sostiene | Invenciones | M4 |
| --- | --- | --- | --- | --- | --- | --- |
| C1-r1 | 725 (699) | 0 | 20 de muestra + todas las distintas fuera de `ids-h1-LG.tsv` | 0 | **0** | pasa |
| C1-r2 | 113 (74) | 0 | 20 de muestra + todas las distintas | 3 | **3** (1 en A-01) | no pasa |

En C1-r1, 634 de las 725 citas están en `salida/inventario/ids-h1-LG.tsv`. Un control aparte comprobó las 634: cada
línea citada empieza con `# <ID>` del ID de su fila.

### Invenciones de C1-r2

Las tres son citas desplazadas: el texto que sostiene la afirmación existe, pero en otra línea del mismo archivo.

| # | Dónde | Cita | Qué afirma | Qué dice la línea citada | Línea que lo sostiene |
| --- | --- | --- | --- | --- | --- |
| 1 | `salida/A-01.md:36` (§1, espacios de IDs) | `LGD/ia-db/indexes/12_Observaciones-Del-Indexado.md:228` | Origen de los prefijos de mesas y auditorías (`O-`, `R-`, `DD-`, `RN9-`, `RN10-`) | Fila O-64: la norma declara el namespace `…Infrastructure.Validation` y ese namespace no existe | `:232` (O-68: `RN9-`, `R-01…R-24`, `RN10-`) |
| 2 | `salida/LG/changelog.md.insercion.md:6` (A-11) | `LG/changelog.md:5` | La entrada va en la rama del PR, no después de la fusión | «…etapa, que es el punto de control bloqueante (`PRODUCT-INTAKE` §15).» | `:6` («**en la rama de la etapa, no después de la fusión**») |
| 3 | `salida/demandas.md:9` (Q-5) | `LG/.github/workflows/e2e.yml:58` | Ahí se usa la etiqueta de runner propia | Comentario: «dos corridas suyas a la vez compiten por la misma máquina» | `:69` y `:149` (`runs-on: [self-hosted, …]`). El coordinador lo corrigió en `salida/respuestas.md:9` |

La invención 3 está en un pedido, no en la evidencia de una fila de la ficha. Si el criterio cuenta sólo A-01, C1-r2
tiene 1 invención y M4 tampoco pasa.

## Instrumento

`citas.py` (en esta carpeta) recorre `salida/A-01.md` y después todos los artefactos de `salida/`. Extrae:

- cada cita `ruta:línea`;
- los rangos `a-b`;
- las listas con coma;
- las continuaciones `` `:N` ``, que heredan el archivo citado antes en la misma línea.

Resuelve `LG/` y `LGD/` contra `repo/LG` y `repo/LGD`. Una ruta relativa se busca en los dos repos y un nombre suelto
se busca en `repo/`. Para cada cita, comprueba que el archivo existe y que su número de líneas alcanza el final del
rango. Se partió del instrumento de la ronda 1, con tres agregados:

1. **Salidas crudas.** Los archivos `salida/inventario/*.txt` son salidas de comandos: líneas `ruta:N:texto` de grep,
   `N:texto` sobre `changelog.md`, listas de rutas y el árbol de directorios. Su texto viene del repo, no lo afirma el
   aplicador. El script comprueba su procedencia: cada línea `ruta:N:` debe coincidir byte a byte con la línea del repo,
   y cada ruta o directorio listado debe existir. En C1-r1 coinciden las 5252 líneas, sin ninguna falla. Las 4890 citas
   que aparecen dentro de ese texto se informan como `EMBEBIDA_EN_SALIDA_CRUDA` y no cuentan, porque son citas del
   corpus del proyecto. Algunas apuntan a líneas que no existen en el repo.
2. **Externa declarada.** Una cita a un archivo que no está en el directorio y que `conocimiento.md` nombra como fuente
   se informa como `EXTERNA_DECLARADA`. Cuenta como invención sólo si aparece en A-01 como evidencia. Hubo una sola,
   `TEM-03-Topologia-Y-Versionado.md:109-123` en `salida/demandas.md:12` de C1-r1, y es un pedido de ese texto, no una
   afirmación.
3. **Respuestas del coordinador.** `salida/respuestas.md` se recorre como cualquier otro artefacto. Una respuesta vale
   como fuente sólo si cita un archivo del directorio y esa cita resuelve:
   - En C1-r1 las ocho respuestas son «no disponible», sin fuente. La ficha no usa ninguna como evidencia: las filas
     que dependían de ellas quedan «pendiente».
   - En C1-r2, la respuesta Q-5 cita `repo/LG/.github/workflows/e2e.yml:69` y `:149`, que resuelven. Las otras cuatro
     son «no disponible».

Comando: `python3 -I citas.py <corrida> --tsv citas-<corrida>.tsv`. Las tablas completas están en `citas-C1-r1.tsv`
y `citas-C1-r2.tsv`. La de C1-r1 no incluye las filas `EMBEBIDA_EN_SALIDA_CRUDA`, que el script regenera. La salida
del script está en `salida-script-C1-r1.txt` y `salida-script-C1-r2.txt`.

**Límite.** `repo/` no tiene `.git`, así que las citas se comprobaron contra la copia y no contra un SHA. Las dos
fichas declaran el SHA como pendiente y dan la huella del árbol.

## Muestra abierta (20 por corrida)

Para cada cita se leyó la línea citada y se comparó con lo que afirma la ficha. Además de la muestra, se abrieron
todas las citas distintas de las dos corridas. En C1-r1 quedaron fuera las de `ids-h1-LG.tsv`, que se comprobaron
con el control mecánico de arriba. Las tres invenciones de C1-r2 salieron de esa revisión completa, no de la muestra.

### C1-r1

| # | Cita | Afirmación | Sostiene |
| --- | --- | --- | --- |
| 1 | `LG/.github/workflows/ci.yml:39-47` | PR y push a `main`, `ubuntu-latest` | sí |
| 2 | `LG/.github/workflows/deploy-front-ftp.yml:38-39` | sólo manual | sí (`workflow_dispatch`) |
| 3 | `LGD/.github/workflows/verificar.yml:3-14` | PR y push a `main`, `ubuntu-latest` | sí |
| 4 | `LG/SDD/Docs/Producto/11-Documentacion/README.md:8`, `:22` | `version: "1.3"` frente a `**Versión:** 1.4` | sí, literal |
| 5 | `LG/changelog.md:1752-1754` | retiro de `evidencia/` | sí |
| 6 | `LG/changelog.md:1767` | `verify-stage-i.sh` sigue midiendo el FTP retirado | sí, literal |
| 7 | `LGD/ia-db/README.md:29` | 74 observaciones O-1…O-74 | sí |
| 8 | `LG/src/GeometriaFactory.Api/Endpoints/WorkEndpoints.cs:106`, `:358` | autorización por papel | sí |
| 9 | `LG/src/GeometriaFactory.Web/Components/Layout/WorkShell.razor:163-178` | menús restringidos por papel | sí |
| 10 | `LG/SDD/Docs/README.md:54-55` | unidades no redistribuibles | sí (columna `false`) |
| 11 | `LG/SDD/Docs/Unidades-Entrega/GeometriaFactory-Api/09-Devops/Estrategia-Versionado.md:125`, `:211-215` | prefijo `v`; etiqueta sólo si cambia código de producción | sí |
| 12 | `LG/Directory.Build.props:54-60` | MinVer con prefijo `v` | sí |
| 13 | `LGD/README.md:33-39`; `LGD/.github/workflows/verificar.yml:12-20` | control `Verificar`: enlaces y forma de la `ia-db` | sí |
| 14 | `LG/.github/workflows/e2e.yml:69`, `:70` | etiqueta propia; repo declarado público | sí |
| 15 | `LGD/README.md:14`, `:19` | ruta absoluta del equipo; persona nombrada (candidatos a alias) | sí |
| 16 | `LG/AGENTS.md:87`, `:90` | `samples/` son ejemplos del producto | sí |
| 17 | `LG/src/GeometriaFactory.Domain/Values/Role.cs:7-9`, `:15`, `:18` | conjunto cerrado por nombre, `Student`/`Administrator` | sí |
| 18 | `LG/SDD/Docs/Unidades-Entrega/GeometriaFactory-Api/05-Arquitectura-Tecnica/Contratos-REST.md:64`, `:107` | conjuntos por nombre; rutas `/v1/` | sí |
| 19 | `AGENTS.md:82`, `:83`, `:84` (en `salida/LG/docs/_requisitos.md`) | visión general, guía de inicio rápido de Web y guía de despliegue «no emitidas» | sí, literal |
| 20 | `LGD/ia-db/indexes/12_Observaciones-Del-Indexado.md:52` | estado y detalle desde ahí | sí (encabezado de la tabla de estado) |

### C1-r2

| # | Cita | Afirmación | Sostiene |
| --- | --- | --- | --- |
| 1 | `LG/src/GeometriaFactory.Api/Endpoints/WorkEndpoints.cs:146` | exige acceso firmado | sí (`.RequireAuthorization()`) |
| 2 | `LG/src/GeometriaFactory.Api/Endpoints/WorkEndpoints.cs:106-108` | filtra por papel | sí |
| 3 | `LG/src/GeometriaFactory.Api/Endpoints/CommissionAccountEndpoints.cs:274` | filtra por papel | sí (documenta que `Student` no puede ejercer esas operaciones) |
| 4 | `LG/src/GeometriaFactory.Web/Components/Layout/WorkShell.razor:181` | etiqueta de papel en el menú | sí |
| 5 | `LG/SDD/Intake/PRODUCT-MANIFEST-Fabrica-De-Geometria.md:127` | ningún proyecto redistribuible | sí, literal |
| 6 | `LG/src/GeometriaFactory.Api/Composition/ApiDocumentation.cs:37`, `:40` | `/openapi/v1.json`; explorador en ejecución | sí |
| 7 | `LG/.github/workflows/ci.yml:55`; `LGD/.github/workflows/verificar.yml:16` | `uses:` sólo de acciones públicas | sí (`actions/checkout@v4`) |
| 8 | `LG/Directory.Build.props:35-41` | MinVer y prefijo `v` | sí |
| 9 | `LGD/ia-db/indexes/00_MASTER-INDEX.md:10` | fecha de verificación del índice | sí (2026-10-26, `4b114d7`) |
| 10 | `LGD/ia-db/indexes/12_Observaciones-Del-Indexado.md:64-118`, `:136-242` | O-1…O-7 de la base anterior; nuevas O-10…O-74 | sí (§2 y §3 del índice) |
| 11 | `LGD/ia-db/indexes/12_Observaciones-Del-Indexado.md:228` | origen de los prefijos `O-`, `R-`, `DD-`, `RN9-`, `RN10-` | **no**: la línea es O-64; el dato está en `:232` |
| 12 | `LG/.github/workflows/deploy-front-ftp.yml:50` | `ubuntu-latest` | sí |
| 13 | `LG/pruebas-e2e.runsettings:52` | todavía cita `evidencia/` | sí |
| 14 | `LG/SDD/Docs/Unidades-Entrega/GeometriaFactory-Web/11-Documentacion/README.md:8`, `:22`, `:77` | `"1.1"` frente a `2.0`; «Planificado» | sí, literal |
| 15 | `LG/SDD/Docs/Producto/11-Documentacion/_legacy/2026-08-17/README-v1.1.md:2`; `…/_legacy/2026-09-14/Contrato-Agentes-v1.0.md:2` | `doc_id` repetidos en copias congeladas | sí |
| 16 | `LG/SDD/Docs/Unidades-Entrega/GeometriaFactory-Api/02-Especificacion-Funcional/Casos-De-Uso/CU-00021-Dar-De-Alta-Una-Cuenta-De-Alumno.md:1`, `:6` | `# ID — título` y `**Versión:**` | sí |
| 17 | `LG/AGENTS.md:55-65` | tabla de límites del proyecto; sólo el merge toca la adopción | sí |
| 18 | `LG/changelog.md:9-10` | cita `Estrategia-Versionado.md` de `09-Devops` | sí |
| 19 | `LG/changelog.md:5` (en `salida/LG/changelog.md.insercion.md`) | va en la rama, no después de la fusión | **no**: está en `:6` |
| 20 | `LG/.github/workflows/e2e.yml:58` (en `salida/demandas.md`) | ahí se usa la etiqueta propia | **no**: está en `:69` y `:149` |
