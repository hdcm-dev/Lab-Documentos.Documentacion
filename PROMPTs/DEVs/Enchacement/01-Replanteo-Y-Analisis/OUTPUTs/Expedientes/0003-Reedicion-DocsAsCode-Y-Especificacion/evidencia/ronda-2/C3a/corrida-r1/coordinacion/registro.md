# Registro del coordinador — corrida C3a-r1

Huellas de los insumos comprobadas antes de contestar (`sha256sum`): `conocimiento.md` afd741b8…83e8,
`A-01-ficha-vacia.md` 0fa85977…2bc, `carta-aplicador-2.md` ca263a77…19a. Coinciden las tres.

| Ronda | id | Demanda (literal) | Fila | Respuesta | Fuente | ¿Debió cubrirlo el conocimiento? |
| --- | --- | --- | --- | --- | --- | --- |
| 1 | Q-1 | La compuerta de origen `tools/docs-guard/` (con `dg.py`, `prefijos.txt`, `esquemas/`, `excepciones.txt`) y `scripts/` (`ci-local.sh` y sus dos `docs-guard.*`) de Lab-Documentos en un SHA fijo, con ese SHA. | §1 «ID declarado más de una vez» (comando 1); D-07; D-09; A-02, A-03, A-07, A-08; §7 compuerta, par rojo/verde y autoprueba | no disponible: tratalo como dato faltante | — | **no**: el conocimiento la declara insumo externo que no vive en él (`conocimiento.md:563-565`); no está en el directorio de la corrida y es material del laboratorio que el coordinador no entrega |
| 1 | Q-2 | La `{lista-privada}` de patrones para el barrido de §3.6 (un patrón por línea). | D-14; §7 «Barrido por `{lista-privada}`» | no disponible: tratalo como dato faltante | — | **no**: el conocimiento la define como valor privado fuera de lo versionado y como insumo externo (`conocimiento.md:318-320`, `:566`); no está en el directorio |
| 1 | Q-3 | El acta firmada por el dueño del producto que delega el merge, que `README.md:61-62` dice «guardada en el repositorio» pero no está en el árbol leído (`salida/inventario/d11-acta.txt`). | D-11; §4 | no disponible: tratalo como dato faltante | — | **no**: es un dato del proyecto ausente del SHA leído (`git ls-tree` de d39dfbd sólo trae `README.md` y `Colmenar/`); ningún conocimiento puede suplirlo; §3.5 lo deja «pendiente» |
| 1 | Q-4 | El remoto `origin` real del repositorio (organización y nombre) y la configuración de la organización sobre qué workflows/acciones admite; el remoto leído es un bundle local (`salida/inventario/git.txt`). | D-01 · organización; D-09 | no disponible: tratalo como dato faltante | — | **no**: el conocimiento ya fija qué hacer si no se mide («pendiente: organización», `conocimiento.md:250`); la demanda busca el dato, no un criterio faltante |
| 1 | Q-5 | La configuración del plan/rama (protección de rama, checks obligatorios) o la respuesta de la API que la muestre; hoy sólo la afirma `README.md:98-99`. | D-10; §2.4 I-15/I-16 | no disponible: tratalo como dato faltante | — | **no**: el conocimiento exige esa evidencia y da la conducta sin ella (`conocimiento.md:181`, `:251`); el dato es externo al directorio |
| 1 | Q-6 | La visibilidad de este repositorio, del de la API y del del paquete medida por configuración o respuesta de la API; hoy sólo la afirma `README.md:77`. | D-14; D-01 · topología | no disponible: tratalo como dato faltante | — | **no**: el conocimiento pide la evidencia o «pendiente» (`conocimiento.md:255`, `:322-323`); el dato es externo al directorio |
| 1 | Q-7 | El registro de las exigencias EX-01…EX-46 del convenio (dónde vive, con versión o SHA), o confirmación de que no hay marco de especificación con registro de IDs. | D-01 · marco; D-04; D-07; A-04 | no disponible: tratalo como dato faltante | — | **dudoso**: el registro en sí es externo (`conocimiento.md:565-566`), pero la segunda mitad pide decidir si una numeración de convenio compartida entre cuatro apps (`README.md:67-69`) es «marco de especificación» en el sentido de D-04 (`conocimiento.md:245`), y el conocimiento no lo define; lo resuelve la presidencia |

## Cierre parcial (tras la ronda 1)

- Rondas usadas: 1 de 3.
- Demandas: 7 (Q-1…Q-7).
- Respuestas con material: 0.
- Respuestas «no disponible»: 7.
- Cuenta de **sí**: 0 (más 1 **dudoso**: Q-7, para la presidencia).

## Cierre

- Rondas usadas: 1 de 3. En la ronda 2 el aplicador retomó con las respuestas y cerró sin demandas nuevas.
- Demandas: 7 (Q-1…Q-7).
- Respuestas con material: 0.
- Respuestas «no disponible»: 7.
- Cuenta de **sí**: 0. Más 1 **dudoso** (Q-7) para la presidencia.
- Auditoría (`coordinacion/auditoria.md`): **DUDOSA**, con dos lecturas para la presidencia. El coordinador propone
  VÁLIDA CON OBSERVACIÓN; la otra lectura es ANULADA. Motivos: «Quién aplica» y «Fecha» de `salida/A-01.md:6-7`
  vienen del entorno (nombre del modelo y fecha), y `git status` refrescó la caché de `repo/proyecto/.git/index` sin
  cambiar su contenido. No hubo red, no se abrió material prohibido y todas las escrituras quedaron en `salida/`.
  Ningún valor de decisión, clase o artefacto usa contexto heredado.
