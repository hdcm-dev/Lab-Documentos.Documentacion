# Demandas

| id | Qué necesito | Para qué fila |
| --- | --- | --- |
| Q-1 | La compuerta de origen de `Lab-Documentos@{sha}`: `tools/docs-guard/` completo (con `dg.py`, `prefijos.txt`, `esquemas/`, `excepciones.txt`), `scripts/ci-local.sh` y sus dos `scripts/docs-guard.*`, `.github/workflows/docs-guard.yml`, y el `{sha}` de esa copia. | §1 patrón «ID declarado más de una vez» y «Espacios de IDs»; D-04, D-07, D-09, D-10; A-02, A-03, A-07, A-08; §7 (compuerta, par rojo/verde, autoprueba) |
| Q-2 | El archivo `{lista-privada}` (un patrón por línea) para el barrido de §3.6. | D-14; §7 «Barrido por `{lista-privada}`» |
| Q-3 | Para `LG` y `LGD`: salida de `git rev-parse HEAD`, `git remote get-url origin` y `git tag --list 'v*'` (la copia recibida no trae `.git`). | Cabecera (SHA); D-01 · organización; D-06 (líneas de versión y etiquetas); D-09 |
| Q-4 | La visibilidad (público o privado) de `LG` y `LGD` según la configuración o la API de la plataforma, y si el plan u organización permite volver obligatorio un check antes del merge (protección de rama o equivalente). | D-10; D-14 |
| Q-5 | La organización dueña del runner de la compuerta de origen y la plataforma (Linux, Mac) de la etiqueta de runner propia que usa `LG/.github/workflows/e2e.yml:58`. | D-01 · organización; D-09; A-07 |
