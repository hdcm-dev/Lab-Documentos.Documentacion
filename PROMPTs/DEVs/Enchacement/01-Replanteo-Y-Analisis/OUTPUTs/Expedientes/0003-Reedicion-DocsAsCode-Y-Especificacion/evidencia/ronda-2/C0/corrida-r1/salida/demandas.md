# Demandas — corrida C0-r1, ronda 1

| id | Qué necesito | Para qué fila |
| --- | --- | --- |
| Q-1 | Lectura de `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/` (en `repo/LD` tiene modo `d---------` y no se puede leer), o una copia de esa carpeta en este directorio. | Cabecera (huella), §1 patrones 1, 4, 6 y espacios de IDs; D-04, D-07, D-10 (RUTA por defecto); §3 CL-02, CL-11, CL-12; §5 A-04, A-06 |
| Q-2 | El SHA del commit de `repo/LD`, la URL de su remoto `origin` y la lista de sus etiquetas (salida de `git rev-parse HEAD`, `git remote get-url origin` y `git tag`). | Cabecera (SHA); D-01 · organización; D-06; D-09; §5 A-09 |
| Q-3 | El archivo `{lista-privada}` del barrido de §3.6 (un patrón por línea). | D-14; §7 barrido por `{lista-privada}` |
| Q-4 | La respuesta de la API (o la configuración) que diga la visibilidad del repositorio y si la plataforma puede volver obligatorio un check antes del merge (protección de rama o ruleset de `main`), y la organización del runner. | D-01 · organización; D-10; D-14 |
| Q-5 | Una copia del repo hermano `Lab-Documentos.Documentacion` en un SHA fijo, o al menos su índice para agentes y la ruta de los expedientes. | §1 advertencias del índice; D-05, D-06, D-12; §3 CL-08, CL-09; §5 A-09, A-11 |
| Q-6 | Las herramientas de la compuerta ya bajadas dentro de este directorio (lychee 0.18.1 y el `node_modules` de `tools/docs-guard/mermaid/package-lock.json`), para correr PR-1 y PR-4 sin red. | §7 compuerta sobre los artefactos y autoprueba de origen; A-08 (línea de base de PR-1 y PR-4) |
