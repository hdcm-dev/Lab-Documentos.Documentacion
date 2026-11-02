# Demandas — ronda 1

| id | Qué necesito | Para qué fila |
| --- | --- | --- |
| Q-1 | La compuerta de origen en un SHA fijo (`tools/docs-guard/` completo con `dg.py`, `prefijos.txt`, `esquemas/` y `excepciones.txt`; `scripts/ci-local.sh` y sus dos `docs-guard.*`; `.github/workflows/docs-guard.yml`) de `Lab-Documentos`, con ese SHA. | §1 patrón 1 y espacios de IDs; D-07; D-09; D-10 (líneas de base); A-02, A-03, A-07, A-08; §7 compuerta, par rojo/verde y autoprueba |
| Q-2 | El archivo `{lista-privada}` (un patrón por línea) para el barrido de §3.6. | D-14; §7 barrido |
| Q-3 | La visibilidad (público o privado) de `LG` y de `LGD`, con su evidencia (configuración o respuesta de la API de la plataforma). | D-14 |
| Q-4 | El remoto `origin` de `LG` y de `LGD` (por ejemplo, la salida de `git remote -v` de cada uno) y la organización a la que pertenece el runner de la compuerta de origen. | D-01 · organización; D-09 |
| Q-5 | Si la plataforma puede volver obligatorio un check antes del merge en la organización o el plan de `LG` y `LGD` (configuración de protección de rama o respuesta de la API). | D-10 |
| Q-6 | El SHA del commit de `LG` y de `LGD` de esta copia (la copia llegó sin `.git`) y, si es posible, la cuenta de commits de `LG` entre `4b114d7` y ese SHA. | Cabecera; D-06; D-17; A-09 (atraso del índice `LGD/ia-db`, anclado en `4b114d7`) |
| Q-7 | El texto de la regla DK-14 (fronteras de CL-01, CL-07, CL-09 y CL-10), que el conocimiento cita y no transcribe. | §3 CL-01, CL-07, CL-09 (ubicación de `SDD/Docs/Audit/` y `SDD/Expedientes/`) |
| Q-8 | El texto de `TEM-03-Topologia-Y-Versionado.md:109-123` (qué ubicación corresponde a cada respuesta de las tres preguntas de I-20). | D-05 |
