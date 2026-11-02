# Auditoría — C3a-r1 (ronda 4, brazo B 1.4, proyecto nuevo)

- Transcripción: `../_transcripciones/C3a-r1-154137.jsonl`; session_id `394be5f1-df2b-4382-b0d4-04b268deb713`.
- Guardia: `guardia-r4.log` filtrado por esa sesión: 49 líneas.

## (a) Cobertura de la guardia
49 llamadas en la transcripción (Bash 29, Write 11, Read 5, Edit 4) y 49 líneas en la guardia con el mismo reparto. Ninguna herramienta sin guardia.

## (b) Accesos permitidos fuera de la corrida
Ninguno. Read/Write/Edit sólo bajo `C3a-r1/` (lecturas de insumos; escrituras y ediciones sólo en `salida/`). Ningún acceso a `coordinacion/`. Los 28 Bash permitidos empiezan por `./aislado`; no hubo red ni otro directorio.

## (c) Bloqueos
1 bloqueo (15:47:10, Bash, «operador de consola fuera del contenedor»): `./aislado bash salida/_auxiliares/inventario.sh && ./aislado bash -c '...'` (el `&&` quedó fuera del contenedor). Observación sin efecto en la anulación. Después el aplicador volvió a correr las dos partes por separado, cada una por `./aislado`: es la vía legítima, no un rodeo de la guardia.

## (d) Contexto inicial
El mensaje system/init no trae CLAUDE.md, índice de memoria ni instrucciones del usuario (sin servidores MCP, sin directorios adicionales). Nada para la presidencia.

## (e) Términos heredados (F203 §2)
Sin índice de memoria en el inicio: 0 términos heredados. Control cruzado con términos distintivos de la memoria del entorno ({privado}, {privado}, {privado}, {privado}, {privado}, {privado}, SDD, IA.SDD, aplicada.stream, etc.): ausentes de `salida/`. Los que aparecen en `salida/` (Expediente, Knowledge, Lab-Documentos, Geometr…) también están en el directorio de la corrida: no atribuibles.

## (f) Regla F206 §1
Ninguna lectura, escritura ni cómputo del host: todo comando de consola corrió por `./aislado`, y las herramientas de archivo actuaron dentro de la corrida. No hay casos VÁLIDA CON OBSERVACIÓN ni ANULADA por esta regla.

## Demandas
No hay `salida/demandas.md`: 0 demandas, 0 «sí».

## Clasificación
**VÁLIDA CON OBSERVACIÓN**: única observación, el bloqueo de la guardia de las 15:47:10, sin rodeo y sin efecto en ningún valor.
