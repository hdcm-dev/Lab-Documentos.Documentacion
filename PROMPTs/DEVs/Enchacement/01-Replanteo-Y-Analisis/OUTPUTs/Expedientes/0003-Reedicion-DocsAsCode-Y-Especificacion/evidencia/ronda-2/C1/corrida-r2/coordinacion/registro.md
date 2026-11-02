# Registro del coordinador · C1-r2

Huellas de `conocimiento.md`, `A-01-ficha-vacia.md` y `carta-aplicador-2.md` comprobadas con `sha256sum` antes de la
ronda 1: coinciden las tres.

| Ronda | id | Demanda (literal) | Fila | Respuesta | Fuente | ¿Debió cubrirlo el conocimiento? |
| --- | --- | --- | --- | --- | --- | --- |
| 1 | Q-1 | La compuerta de origen de `Lab-Documentos@{sha}`: `tools/docs-guard/` completo (con `dg.py`, `prefijos.txt`, `esquemas/`, `excepciones.txt`), `scripts/ci-local.sh` y sus dos `scripts/docs-guard.*`, `.github/workflows/docs-guard.yml`, y el `{sha}` de esa copia. | §1 patrón «ID declarado más de una vez» y «Espacios de IDs»; D-04, D-07, D-09, D-10; A-02, A-03, A-07, A-08; §7 (compuerta, par rojo/verde, autoprueba) | no disponible: tratalo como dato faltante | — | **no**: el conocimiento la declara insumo externo que el consumidor necesita y no vive en él (`conocimiento.md:563-566`); el montaje no la trae, así que demandarla era el camino correcto |
| 1 | Q-2 | El archivo `{lista-privada}` (un patrón por línea) para el barrido de §3.6. | D-14; §7 «Barrido por `{lista-privada}`» | no disponible: tratalo como dato faltante | — | **no**: la lista vive fuera de lo versionado por diseño (`conocimiento.md:319-320`, `:566`); no hay forma de llegar a ella desde el conocimiento |
| 1 | Q-3 | Para `LG` y `LGD`: salida de `git rev-parse HEAD`, `git remote get-url origin` y `git tag --list 'v*'` (la copia recibida no trae `.git`). | Cabecera (SHA); D-01 · organización; D-06 (líneas de versión y etiquetas); D-09 | no disponible: tratalo como dato faltante | — | **sí**: la copia sin `.git` está prevista (DK-18, `conocimiento.md:229-230`: «SHA: pendiente» más huella del árbol) y la organización no medible también (D-09, `conocimiento.md:250`: «pendiente: organización»); leído paso por paso, llevaba a esa decisión sin preguntar. Matiz: las etiquetas de D-06 sin `.git` no tienen regla explícita |
| 1 | Q-4 | La visibilidad (público o privado) de `LG` y `LGD` según la configuración o la API de la plataforma, y si el plan u organización permite volver obligatorio un check antes del merge (protección de rama o equivalente). | D-10; D-14 | no disponible: tratalo como dato faltante | — | **no**: el conocimiento exige evidencia de configuración o API (`conocimiento.md:251`, `:322-323`), material de la plataforma que un aplicador sin red sólo obtiene por el canal; el «pendiente» de D-14 es el desenlace, no una vía al dato |
| 1 | Q-5 | La organización dueña del runner de la compuerta de origen y la plataforma (Linux, Mac) de la etiqueta de runner propia que usa `LG/.github/workflows/e2e.yml:58`. | D-01 · organización; D-09; A-07 | Ubicación literal de la etiqueta: `runs-on: [self-hosted, {etiqueta-runner}]`; organización y plataforma: no disponible: tratalo como dato faltante | `repo/LG/.github/workflows/e2e.yml:69`, `:149` | **dudoso**: la ubicación de la etiqueta sale del paso 1 del inventario («workflows y su runner», `conocimiento.md:205`) y la organización no medible ya tiene desenlace (`:250`), lo que da **sí**; pero el conocimiento pide etiqueta por plataforma (`:250`) sin decir cómo se determina la plataforma de una etiqueta existente, lo que da **no**. Resuelve la presidencia |

## Cierre de la ronda 1

- Rondas usadas: 1 de 3.
- Demandas: 5 (Q-1…Q-5).
- Respuestas con material: 1 (Q-5, parcial: sólo la ubicación de la etiqueta).
- Respuestas «no disponible»: 4 completas (Q-1, Q-2, Q-3, Q-4) y 1 parcial (Q-5).
- Cuenta de **sí**: 1 (Q-3). **Dudoso**: 1 (Q-5). **No**: 3.
- Suposiciones (M5): se revisa al cierre de la corrida en `salida/A-01.md` §6 para la fila de Q-3.

## Cierre de la corrida

- Rondas usadas: 1 de 3. Demandas: 5. Respuestas con material: 1 (Q-5, parcial). Respuestas «no disponible»: 4
  completas y 1 parcial. Cuenta de **sí**: 1 (Q-3). **Dudoso**: 1 (Q-5, a la presidencia).
- M5 de Q-3: la fila no terminó en suposición. Cabecera: «SHA: pendiente» más huella del árbol; D-06: etiquetas leídas
  del texto del repo, rotuladas como evidencia secundaria, y su medición con git «pendiente».
- Auditoría (`coordinacion/auditoria.md`): **DUDOSA**. El aplicador leyó este registro en la ronda 2 (entrada B#10 de
  `agent-a29be4ca2ccf12a48.jsonl`), y dos filas de §6 de la ficha (D-06, D-09) repiten sus matices. Las lecturas
  VÁLIDA CON OBSERVACIÓN y ANULADA están anotadas; decide la presidencia. Además: dos lecturas de salidas propias
  guardadas por el entorno fuera del directorio y el contexto heredado (memoria e instrucciones), sin uso en ningún
  valor.
