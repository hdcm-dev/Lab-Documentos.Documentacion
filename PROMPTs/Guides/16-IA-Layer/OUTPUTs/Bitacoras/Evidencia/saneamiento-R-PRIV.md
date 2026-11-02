# Saneamiento R-PRIV y R-06 de la bitácora (2026-10-27)

Antes de cualquier commit, fase de construcción. Los términos de las listas no se reproducen acá. Las listas viven fuera del repo (`$R_PRIV_LISTA`, `$RD_PO_LISTA`, DEP-16).

## 1. R-PRIV sobre `OUTPUTs/`

Comando: `grep -rniF -f "$R_PRIV_LISTA" OUTPUTs`

| | Coincidencias | Archivos |
|---|---|---|
| Antes | 21 (todas de la misma clase: la ruta de inicio del usuario del sistema) | 11 |
| Después | **0** | 0 |

Arreglo (DEP-16, decisión de la presidencia): reescribir las rutas, sin exceptuarlas. Las rutas del workspace quedaron escritas desde su raíz (`/LAB/...`, `/tools/...`), y las del directorio de trabajo fuera del repo, como `{dir-de-trabajo}/...`. No hubo coincidencias de nombres de máquina, números de serie ni repos privados. Control de la lista: `grep -cF -f "$R_PRIV_LISTA" r-priv.positivos` da 17, una por cada línea del archivo de positivos, así que la lista detecta. Además se buscaron IPv4: sólo aparecen números de versión y la base del rango genérico 100.64/10 (escrita aquí en notación corta), ninguna dirección real.

Archivos tocados: `Sondeo-Entorno.md`, `00-Contrato-De-Entrada.md`, `../Crear-IA-Layer-Guide-Reedicion.md` (está en OUTPUTs, no es el prompt del PO), `Mesa/Ciclo-1/05-Parches.md`, `Mesa/Ciclo-1/02-Informes/ingenuo.md`, `Mesa/Ciclo-2/02-Informes/{desarrollo,operacion}.md` y `Nucleos/{N0b,N1,N1b,N3b}-*.md`.

## 2. R-06: dominios ajenos (los seis archivos de Ciclo-3/08-Cierre l. 76)

| Archivo | Tratamiento |
|---|---|
| `Nucleos/N2-Abstracciones-Y-Proveedores-NET.md` | **Reescrito** a Movilidad Urbana (respuestas de encuesta, localidad, `ConsultarRespuestas`, `MovilidadUrbanaMcp`). Eran 8 líneas; ninguna era evidencia ejecutada |
| `Nucleos/N5-Operacion-Calidad-Seguridad.md` | Se **reescribieron** las líneas de prosa y el nombre del escenario (4). Las salidas E3/E5 y el snippet §4.4 que verificó E3 quedaron **rotulados** (3) |
| `Nucleos/N4-Agentes-Y-Orquestacion.md` | **Rotulado** (§4 replica el proyecto compilado) |
| `Nucleos/N4-Evidencia/compilecheck/Program.cs` | **Rotulado** (evidencia compilada) |
| `Sondeo-Entorno.md` | Las salidas ejecutadas de §4 y §11 quedaron **rotuladas**. La prosa de la l. 92 se reescribió |
| `Mesa/Ciclo-1/02-Informes/qa.md` | Excepción: el hallazgo QA-06 nombra los términos del barrido |

Rótulo usado: «(dominio ilustrativo del dossier; la guía usa Movilidad Urbana)».

## 3. Barrido AC-8 (RD-PO-4) y lista de proyectos

| Control | Antes | Después |
|---|---|---|
| Coincidencias del barrido de dos patrones | 72 (suma por archivo, antes del arreglo, con `positivos` incluido) | 53 líneas únicas fuera de `Compuertas/` |
| Líneas marcadas sin excepción | todas las de los seis archivos de R-06 (31 coincidencias) | **0** |
| `rd-po-4.negativos` marcados | 0 | 0 (pasa) |
| `rd-po-4.positivos` marcados | 5/5 | 5/5 (pasa) |
| `grep -rniF -f "$RD_PO_LISTA"` sobre OUTPUTs | 1 | 1, como excepción escrita |

En `Compuertas/rd-po-4.excepciones` se agregaron 24 excepciones de R-06 y una de `$RD_PO_LISTA`. La de `$RD_PO_LISTA` es `Mesa/I-06-...:10` y es la cita textual de la directiva del PO, que no se toca. **Apartamiento declarado:** la «Regla» de ese archivo prohíbe exceptuar contenido que use un dominio ajeno. Las excepciones de evidencia ejecutada y rotulada se apartan de esa regla, y el propio archivo lo deja escrito. Se aceptan porque R-06 permite rotular en lugar de reescribir cuando reescribir alteraría la evidencia. Para cerrar esto del todo habría que volver a correr las sondas con datos de Movilidad Urbana.
