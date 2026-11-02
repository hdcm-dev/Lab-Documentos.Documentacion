# Registro del coordinador — C3a-r2

Huellas de los insumos comprobadas antes de contestar (`sha256sum`): `conocimiento.md` afd741b8…83e8,
`A-01-ficha-vacia.md` 0fa85977…2bc, `carta-aplicador-2.md` ca263a77…19a. Coinciden con las recibidas.

Búsqueda del material pedido dentro del directorio de la corrida (fuera de `.git` y en todo el historial de
`repo/proyecto`, un solo commit d39dfbd): no hay `tools/docs-guard/`, `scripts/`, `.github/`, lista privada, acta
ni repositorio del paquete; el remoto `origin` es un bundle local, sin organización ni respuesta de API.

| Ronda | id | Demanda (literal) | Fila | Respuesta | Fuente | ¿Debió cubrirlo el conocimiento? |
| --- | --- | --- | --- | --- | --- | --- |
| 1 | Q-1 | La compuerta de origen en un SHA fijo (`tools/docs-guard/` completo, `scripts/ci-local.sh` con sus dos `docs-guard.*` y `.github/workflows/docs-guard.yml` de `Lab-Documentos@{sha}`), con el valor de `{sha}`. | §1 patrón 1 y espacios de IDs; D-07; D-09; D-10; A-02, A-03, A-07, A-08; §7 compuerta, par rojo/verde y autoprueba | no disponible: tratalo como dato faltante | — | **no**: `conocimiento.md:564-565` la declara insumo externo que el consumidor necesita; pedirla es el camino previsto y el montaje no la trae |
| 1 | Q-2 | La lista privada del barrido (`{lista-privada}`, un patrón por línea) para este proyecto. | D-14; §7 barrido por `{lista-privada}` | no disponible: tratalo como dato faltante | — | **no**: `conocimiento.md:566` y `:319-320` la ponen fuera de lo versionado como insumo externo; pedirla es correcto |
| 1 | Q-3 | El acta firmada por el dueño del producto que autoriza fusionar sin él: `README.md:61-64` dice que está guardada en el repositorio, pero no aparece en el árbol del SHA d39dfbd. | D-11; §4 | no disponible: tratalo como dato faltante | — | **no**: falta un dato del proyecto, no una regla; D-11 (`conocimiento.md:252`) y §3.5 (`:298-301`) ya llevan a «pendiente» si la delegación no está asentada |
| 1 | Q-4 | El repositorio del paquete del modelo de datos (o su índice) en un SHA fijo, que `README.md:48-50` describe como repo propio y público. | D-01 · topología; D-05; D-06; §3 (clases repartidas entre repos, DK-15) | no disponible: tratalo como dato faltante | — | **dudoso**: DK-15 (`conocimiento.md:232-233`) dice que la ubicación se completa igual con el índice del otro repo como evidencia secundaria, pero no dice qué hacer si sólo existe la descripción del README y no el índice |
| 1 | Q-5 | Evidencia de plataforma: el remoto `origin` real del repo y su organización (el clon apunta a un bundle local), y la respuesta de la API o configuración sobre visibilidad del repo y checks obligatorios antes del merge. | D-01 · organización; D-09; D-10; D-14 | no disponible: tratalo como dato faltante | — | **no**: el conocimiento ya define la salida sin preguntar: D-09 «si no se puede medir, "pendiente: organización"» (`conocimiento.md:250`), D-14 visibilidad «con evidencia, o "pendiente"» (`:255`); la demanda era legítima pero no hace falta |

## Cierre de la ronda 1

- Rondas usadas: 1 de 3.
- Demandas: 5 (Q-1 a Q-5).
- Respuestas con material: 0.
- Respuestas «no disponible»: 5.
- Cuenta de **sí**: 0 (más 1 **dudoso**, Q-4, para la presidencia).

## Cierre

- Rondas usadas: 1 de 3. En la ronda 2 el aplicador retomó con las respuestas y cerró sin demandas nuevas.
- Demandas: 5 (Q-1…Q-5).
- Respuestas con material: 0.
- Respuestas «no disponible»: 5.
- Cuenta de **sí**: 0. Más 1 **dudoso** (Q-4) para la presidencia.
- Auditoría (`coordinacion/auditoria.md`): **DUDOSA**, con dos lecturas para la presidencia. El coordinador propone
  VÁLIDA CON OBSERVACIÓN; la otra lectura es ANULADA. Motivos: la «Fecha» y los `last_review` de `salida/A-01.md:10,20`
  y de tres artefactos no se midieron y coinciden con la del entorno; `git status` refrescó la caché de
  `repo/proyecto/.git/index` sin cambiar su contenido (huella igual al árbol de d39dfbd). Una lectura fuera del
  directorio (R2-#7) fue la salida persistida de un comando propio, idéntica a `conocimiento.md:250-700`. Sin red, sin
  material prohibido, escrituras sólo en `salida/`. Ningún valor de decisión, clase o artefacto usa contexto heredado
  (instrucciones generales ni índice de memoria). M6: sin par rojo/verde ni copia de la semilla (pendiente por Q-1).
