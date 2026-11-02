# Demandas — ronda 1

| id | Qué necesito | Para qué fila |
| --- | --- | --- |
| Q-1 | La compuerta de origen en un SHA fijo (`tools/docs-guard/` completo, `scripts/ci-local.sh` con sus dos `docs-guard.*` y `.github/workflows/docs-guard.yml` de `Lab-Documentos@{sha}`), con el valor de `{sha}`. | §1 patrón 1 y espacios de IDs; D-07; D-09; D-10; A-02, A-03, A-07, A-08; §7 compuerta, par rojo/verde y autoprueba |
| Q-2 | La lista privada del barrido (`{lista-privada}`, un patrón por línea) para este proyecto. | D-14; §7 barrido por `{lista-privada}` |
| Q-3 | El acta firmada por el dueño del producto que autoriza fusionar sin él: `README.md:61-64` dice que está guardada en el repositorio, pero no aparece en el árbol del SHA d39dfbd. | D-11; §4 |
| Q-4 | El repositorio del paquete del modelo de datos (o su índice) en un SHA fijo, que `README.md:48-50` describe como repo propio y público. | D-01 · topología; D-05; D-06; §3 (clases repartidas entre repos, DK-15) |
| Q-5 | Evidencia de plataforma: el remoto `origin` real del repo y su organización (el clon apunta a un bundle local), y la respuesta de la API o configuración sobre visibilidad del repo y checks obligatorios antes del merge. | D-01 · organización; D-09; D-10; D-14 |
