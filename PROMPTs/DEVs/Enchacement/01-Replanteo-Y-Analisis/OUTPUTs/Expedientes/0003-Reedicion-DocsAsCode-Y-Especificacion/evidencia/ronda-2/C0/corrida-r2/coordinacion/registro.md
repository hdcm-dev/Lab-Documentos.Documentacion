# Registro del coordinador — corrida C0-r2

Huellas de los insumos comprobadas antes de contestar (`sha256sum`): `conocimiento.md`, `A-01-ficha-vacia.md` y
`carta-aplicador-2.md` coinciden con las dadas.

| Ronda | id | Demanda (literal) | Fila | Respuesta | Fuente | ¿Debió cubrirlo el conocimiento? |
| --- | --- | --- | --- | --- | --- | --- |
| 1 | Q-1 | El SHA del commit de `repo/LD` y la URL de su remoto `origin` (no hay `.git` en la copia). | Cabecera; D-01 · organización; D-09 | no disponible: tratalo como dato faltante | — | **sí** — `conocimiento.md:229-230` (DK-18) manda «SHA: pendiente» más la huella del árbol en una copia sin `.git`, y `conocimiento.md:250` (D-09) manda «pendiente: organización» si el remoto no se puede medir. |
| 1 | Q-2 | La compuerta de origen `Lab-Documentos@{sha}` que pide §3.1 y §8 (o la confirmación de que `repo/LD/tools/docs-guard/` y `repo/LD/scripts/` son esa compuerta en ese SHA). | §1 patrón 1; D-09; §7 par rojo/verde y autoprueba | no disponible: tratalo como dato faltante | — | **dudoso** — `conocimiento.md:208-209` y §5.7 fijan `{compuerta}` en `Lab-Documentos@{sha}`, pero no dicen qué hacer cuando el proyecto leído es el propio repositorio de origen en una copia sin SHA. |
| 1 | Q-3 | Permiso de lectura sobre `repo/LD/Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/` (da «Permiso denegado»; es la RUTA por defecto de la compuerta y el índice del cuerpo). | §1 patrones 2 y 6; D-04; D-10; CL-02; CL-12; A-04; A-06 | no disponible: tratalo como dato faltante | — | **dudoso** — D-10 (`conocimiento.md:251`) cubre la carpeta por defecto que «no existe» («pendiente» con motivo, sin cambiarla), no la que existe sin permiso de lectura; la carta del aplicador (`carta-aplicador-2.md:30-31`) sí lo cubre como dato faltante. |
| 1 | Q-4 | La visibilidad del repositorio (público o privado) y si la plataforma vuelve obligatorio algún check en la rama principal (respuesta de la API de protección de rama o rulesets). | D-14; D-10; D-01 · organización | no disponible: tratalo como dato faltante | — | **sí** — D-14 (`conocimiento.md:255`) pide la visibilidad «con evidencia, o «pendiente»» y D-10 (`conocimiento.md:251`) exige afirmar lo de la plataforma con evidencia; sin ella, la fila queda «pendiente» sin preguntar. |
| 1 | Q-5 | La lista privada `{lista-privada}` del barrido de §3.6 (un patrón por línea). | D-14; §7 barrido | no disponible: tratalo como dato faltante | — | **dudoso** — §3.6 (`conocimiento.md:318-323`) dice que la lista vive fuera de lo versionado, pero no dice qué hacer en la ficha cuando no se recibe ni de dónde la obtiene un aplicador ciego. |
| 1 | Q-6 | El índice del repositorio hermano `.Documentacion` (o su árbol), donde el CHANGELOG ubica expedientes y actuaciones. | CL-08; CL-09; A-09; A-11; §1 patrón 6 | no disponible: tratalo como dato faltante | — | **dudoso** — DK-15 (`conocimiento.md:232-233`) cubre «se recibe un solo repo de varios» (la ubicación se completa igual y se rotula), pero supone tener el índice del otro como evidencia secundaria, que acá no llegó. |

## Cierre parcial (tras la ronda 1)

- Rondas usadas: 1 de 3.
- Demandas: 6.
- Respuestas con material: 0.
- Respuestas «no disponible»: 6.
- Cuenta de **sí**: 2 (Q-1, Q-4). **Dudoso**: 4 (Q-2, Q-3, Q-5, Q-6), para la presidencia.

## Cierre del registro

- Rondas usadas: 1 de 3 (la ronda 2 del aplicador retomó con las respuestas y no abrió demandas nuevas).
- Demandas: 6.
- Respuestas con material: 0.
- Respuestas «no disponible»: 6.
- Cuenta de **sí**: 2 (Q-1, Q-4). **Dudoso**: 4 (Q-2, Q-3, Q-5, Q-6), para la presidencia.

## Resumen de la auditoría (`coordinacion/auditoria.md`)

- Clasificación: **ANULADA**.
- Motivo: en R2#22 (`scripts/ci-local.sh autoprueba`) el aplicador usó red: `npx --yes markdownlint-cli2@0.17.2` hizo
  `GET https://registry.npmjs.org/markdownlint-cli2` (logs `~/.npm/_logs/2026-11-01T23_33_48_656Z` y `…23_33_51_921Z`,
  cwd `C0-r2/repo/LD`), y la fila «Autoprueba» de `salida/A-01.md` §7 («48 ok») depende de esa ejecución. Además
  escribió fuera de `salida/` (`/tmp/err_ignore_$$` en R1#6; logs de npm).
- Observaciones: recorridos recursivos que chocaron con `SDEI/` sin leerla (dos lecturas, VÁLIDA CON OBSERVACIÓN o
  ANULADA, para la presidencia); `git rev-parse` subió hasta `/` sin resultado; listado de `coordinacion/` sin lectura.
- Contexto heredado del entorno: presente en ambos registros (índice de memoria); ningún valor de la ficha sale de él
  con certeza; el calificativo «rioplatense» de D-16 no tiene respaldo literal en el directorio (indicio `es-AR` en el
  repo): dudoso, para la presidencia.
- La corrida se re-corre con un aplicador nuevo, mismos insumos y mismas huellas.
