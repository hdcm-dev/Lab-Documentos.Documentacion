# Registro del coordinador — corrida C0-r1

Huellas comprobadas antes de contestar (`sha256sum`), las tres coinciden con la lista recibida:
`conocimiento.md` afd741b8…483e8; `A-01-ficha-vacia.md` 0fa85977…2bc; `carta-aplicador-2.md` ca263a77…19a.

Búsqueda del material pedido, sólo en los insumos sellados (sin abrir ni intentar `SDEI/`, podado del `find` y
excluido del `grep`): no hay `.git` en `repo/LD`; no hay archivo `{lista-privada}`; no hay copia de
`Lab-Documentos.Documentacion`; de las herramientas sólo están la configuración (`repo/LD/scripts/docs-guard.lychee.toml`)
y `repo/LD/tools/docs-guard/mermaid/package-lock.json`, sin binario de lychee ni `node_modules`.

| Ronda | id | Demanda (literal) | Fila | Respuesta | Fuente | ¿Debió cubrirlo el conocimiento? |
| --- | --- | --- | --- | --- | --- | --- |
| 1 | Q-1 | Lectura de `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/` (en `repo/LD` tiene modo `d---------` y no se puede leer), o una copia de esa carpeta en este directorio. | Cabecera (huella), §1 patrones 1, 4, 6 y espacios de IDs; D-04, D-07, D-10 (RUTA por defecto); §3 CL-02, CL-11, CL-12; §5 A-04, A-06 | no disponible: tratalo como dato faltante | — | **no**: material vedado por la carta del coordinador; el conocimiento ya pide lectura del repo como requisito (`conocimiento.md:563-564`) y su regla de falla (`conocimiento.md:299-301`) dice qué hacer si falta |
| 1 | Q-2 | El SHA del commit de `repo/LD`, la URL de su remoto `origin` y la lista de sus etiquetas (salida de `git rev-parse HEAD`, `git remote get-url origin` y `git tag`). | Cabecera (SHA); D-01 · organización; D-06; D-09; §5 A-09 | no disponible: tratalo como dato faltante | — | **dudoso**: el dato no está en el directorio (sin `.git`), pero el conocimiento ya fija la decisión sin preguntar: «Copia sin `.git`» → «SHA: pendiente» más huella del árbol (`conocimiento.md:229-230`) y «pendiente: organización» si no se mide (`conocimiento.md:250`). Lectura A: pedir el dato faltante es uso legítimo del canal → no. Lectura B: el conocimiento lo resolvía y no se siguió → sí. Decide la presidencia |
| 1 | Q-3 | El archivo `{lista-privada}` del barrido de §3.6 (un patrón por línea). | D-14; §7 barrido por `{lista-privada}` | no disponible: tratalo como dato faltante | — | **no**: es un insumo externo que el conocimiento declara que no vive en él (`conocimiento.md:566`); no puede cubrirlo |
| 1 | Q-4 | La respuesta de la API (o la configuración) que diga la visibilidad del repositorio y si la plataforma puede volver obligatorio un check antes del merge (protección de rama o ruleset de `main`), y la organización del runner. | D-01 · organización; D-10; D-14 | no disponible: tratalo como dato faltante | — | **no**: evidencia de plataforma externa al directorio; el conocimiento ya prevé «pendiente» (`conocimiento.md:255`) y la rama «avisa» (`conocimiento.md:181`) |
| 1 | Q-5 | Una copia del repo hermano `Lab-Documentos.Documentacion` en un SHA fijo, o al menos su índice para agentes y la ruta de los expedientes. | §1 advertencias del índice; D-05, D-06, D-12; §3 CL-08, CL-09; §5 A-09, A-11 | no disponible: tratalo como dato faltante | — | **no**: otro repositorio, fuera del montaje; el conocimiento cubre el caso de un solo repo recibido (`conocimiento.md:232-233`) |
| 1 | Q-6 | Las herramientas de la compuerta ya bajadas dentro de este directorio (lychee 0.18.1 y el `node_modules` de `tools/docs-guard/mermaid/package-lock.json`), para correr PR-1 y PR-4 sin red. | §7 compuerta sobre los artefactos y autoprueba de origen; A-08 (línea de base de PR-1 y PR-4) | no disponible: tratalo como dato faltante | — | **no**: dependencia de entorno sin red, no de diseño; la regla de falla (`conocimiento.md:299-301`) lleva a «pendiente» |

## Cierre (parcial, tras la ronda 1 de 3)

- Rondas usadas: 1
- Demandas: 6
- Respuestas con material: 0
- Respuestas «no disponible»: 6
- Cuenta de **sí**: 0 (1 **dudoso**: Q-2, para la presidencia)

## Cierre definitivo (tras la auditoría)

- Rondas usadas: 1 de 3 (el aplicador retomó tras la ronda 1 y no abrió otra)
- Demandas: 6
- Respuestas con material: 0
- Respuestas «no disponible»: 6
- Cuenta de **sí**: 0 (1 **dudoso**: Q-2, para la presidencia)
- Auditoría (`coordinacion/auditoria.md`): **ANULADA** — la autoprueba de la compuerta de origen (ronda 0, #46) llamó
  a `npx markdownlint-cli2@0.17.2`, que hizo GET a `registry.npmjs.org` (logs de npm 23:31:14Z y 23:31:15Z) y corrió
  un paquete de `~/.npm/_npx`; el resultado entra en `salida/A-01.md:144`. Intentos fallidos sobre `SDEI/` (stat y
  recorridos recursivos, sin contenido) anotados con dos lecturas para la presidencia. Contexto heredado del entorno:
  presente en el registro, no usado en ningún valor de A-01. Corresponde re-correr C0 sin red.
