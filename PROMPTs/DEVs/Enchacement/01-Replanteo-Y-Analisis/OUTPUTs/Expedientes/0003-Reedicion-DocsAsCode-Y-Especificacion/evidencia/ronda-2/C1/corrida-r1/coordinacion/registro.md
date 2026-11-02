# Registro del coordinador — C1-r1

| Ronda | id | Demanda (literal) | Fila | Respuesta | Fuente | ¿Debió cubrirlo el conocimiento? |
| --- | --- | --- | --- | --- | --- | --- |
| 1 | Q-1 | La compuerta de origen en un SHA fijo (`tools/docs-guard/` completo con `dg.py`, `prefijos.txt`, `esquemas/` y `excepciones.txt`; `scripts/ci-local.sh` y sus dos `docs-guard.*`; `.github/workflows/docs-guard.yml`) de `Lab-Documentos`, con ese SHA. | §1 patrón 1 y espacios de IDs; D-07; D-09; D-10 (líneas de base); A-02, A-03, A-07, A-08; §7 compuerta, par rojo/verde y autoprueba | no disponible: tratalo como dato faltante | — | dudoso: la compuerta de origen es material externo (conocimiento.md:455, §8) y no viene en el montaje; el conocimiento no dice qué hacer sin ella (par rojo/verde, autoprueba), así que la pregunta no era evitable con su texto |
| 1 | Q-2 | El archivo `{lista-privada}` (un patrón por línea) para el barrido de §3.6. | D-14; §7 barrido | no disponible: tratalo como dato faltante | — | no: el conocimiento declara que la lista vive fuera de lo versionado (conocimiento.md:319-320); es externa por diseño |
| 1 | Q-3 | La visibilidad (público o privado) de `LG` y de `LGD`, con su evidencia (configuración o respuesta de la API de la plataforma). | D-14 | no disponible: tratalo como dato faltante | — | no: requiere configuración o API de la plataforma, externa; el conocimiento prevé «pendiente» (conocimiento.md:255, :322-323) |
| 1 | Q-4 | El remoto `origin` de `LG` y de `LGD` (por ejemplo, la salida de `git remote -v` de cada uno) y la organización a la que pertenece el runner de la compuerta de origen. | D-01 · organización; D-09 | no disponible: tratalo como dato faltante | — | no: sin .git no hay remoto; el conocimiento prevé «pendiente: organización» (conocimiento.md:250) |
| 1 | Q-5 | Si la plataforma puede volver obligatorio un check antes del merge en la organización o el plan de `LG` y `LGD` (configuración de protección de rama o respuesta de la API). | D-10 | no disponible: tratalo como dato faltante | — | no: requiere configuración o API, externa; el conocimiento da el tratamiento sin ella (conocimiento.md:181, :251) |
| 1 | Q-6 | El SHA del commit de `LG` y de `LGD` de esta copia (la copia llegó sin `.git`) y, si es posible, la cuenta de commits de `LG` entre `4b114d7` y ese SHA. | Cabecera; D-06; D-17; A-09 (atraso del índice `LGD/ia-db`, anclado en `4b114d7`) | no disponible: tratalo como dato faltante | — | dudoso: la parte del SHA la cubre §3.1 (conocimiento.md:229-230, «SHA: pendiente» más huella del árbol); el atraso contra 4b114d7 en una copia sin .git no lo trata |
| 1 | Q-7 | El texto de la regla DK-14 (fronteras de CL-01, CL-07, CL-09 y CL-10), que el conocimiento cita y no transcribe. | §3 CL-01, CL-07, CL-09 (ubicación de `SDD/Docs/Audit/` y `SDD/Expedientes/`) | no disponible: tratalo como dato faltante | — | sí: el conocimiento remite las fronteras de CL-01, CL-07, CL-09 y CL-10 a DK-14 (conocimiento.md:122) sin transcribir la regla, y su fuente es externa (conocimiento.md:577) |
| 1 | Q-8 | El texto de `TEM-03-Topologia-Y-Versionado.md:109-123` (qué ubicación corresponde a cada respuesta de las tres preguntas de I-20). | D-05 | no disponible: tratalo como dato faltante | — | sí: D-05 da las opciones y «la primera que da sí ubica la pieza» (conocimiento.md:246, :147) pero no qué ubicación corresponde a cada pregunta; remite a TEM-03 externo |

Huellas de los insumos comprobadas antes de contestar (sha256sum): conocimiento.md, A-01-ficha-vacia.md y carta-aplicador-2.md coinciden con las entregadas.

## Cierre parcial (tras ronda 1)

- Rondas usadas: 1 de 3
- Demandas: 8
- Respuestas con material: 0
- Respuestas «no disponible»: 8
- Cuenta de **sí**: 2 (Q-7, Q-8); **dudoso**: 2 (Q-1, Q-6), a resolver por la presidencia

## Cierre del registro

- Rondas usadas: 1 de 3 (el aplicador retomó con las respuestas y terminó sin nuevas demandas)
- Demandas: 8 (Q-1…Q-8)
- Respuestas con material: 0
- Respuestas «no disponible»: 8
- Cuenta de **sí**: 2 (Q-7, Q-8); **no**: 4 (Q-2, Q-3, Q-4, Q-5); **dudoso**: 2 (Q-1, Q-6), a resolver por la presidencia
- Auditoría (`coordinacion/auditoria.md`): **DUDOSA**, entre VÁLIDA CON OBSERVACIÓN y ANULADA, a decidir por la
  presidencia. Motivo: en la ronda 2 el aplicador leyó este registro (r2 #2, `cat coordinacion/registro.md`), con los
  juicios «¿Debió cubrirlo?», antes de escribir §6 de la ficha. Por lo demás, todo quedó dentro del límite: sin red,
  escritura sólo en `salida/`, `repo/` intacto. El contexto heredado del entorno no aparece usado en ningún valor de
  `salida/A-01.md`.
