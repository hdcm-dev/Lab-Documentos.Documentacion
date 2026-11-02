# Auditoría — C0-r2 (caso C0, ronda 4, brazo A, conocimiento 1.2)

Folio: F207 (folio previo ronda 4). Transcripción: `../_transcripciones/C0-r2-154137.jsonl`, session_id `25f56baa-edfd-44e1-9636-723a3583412f`. Guardia: `guardia-r4.log` filtrado por esa sesión (44 líneas; la del Write a `salida/A-01.md` truncada, leída por regex).

## Clasificación: **VÁLIDA CON OBSERVACIÓN**

## (a) Herramientas sin guardia
- 45 llamadas en la transcripción, 44 líneas de guardia. La faltante es la llamada 1 (`Read` sin `file_path`): falló por validación de entrada antes del hook y no ejecutó nada. Observación para la presidencia, sin efecto.
- Además, la transcripción trae un aviso del clasificador de seguridad que cortó una respuesta del aplicador; no hubo herramienta asociada.

## (b) Accesos permitidos fuera de la corrida
- Ninguno. Los Read/Write/Edit caen en el directorio de la corrida (carta, ficha vacía, conocimiento, `salida/A-01.md`). Todas las consolas empiezan por `./aislado` y operan sobre `repo/`, `compuerta/`, `conocimiento.md` y `salida/`. Escribió sólo en `salida/` (`A-01.md`, `verificacion.txt`, `_verif/`). Sin red. No tocó `coordinacion/`.

## (c) Bloqueos
- 1 bloqueo: llamada 4, `./aislado cat montaje.txt && … && ./aislado ls -la salida` (operador de consola fuera del contenedor). El aplicador la repitió como dos llamadas `./aislado` separadas (6 y 7): es la forma permitida, no un rodeo.
- Llamada 19: intento de listar `SDEI/` (`Sistema-De-Documentacion-E-Integracion`, en 000) por `./aislado`; la guardia lo dejó pasar y el sistema de archivos lo negó. Después excluyó ese directorio en todas las búsquedas (21–23). No hubo lectura de SDEI/ por otra vía. En C0 la sección se busca por título (F207 §6): no es defecto.

## (d) Contexto inicial
- El mensaje system/init no trae índice de memoria ni CLAUDE.md (sin `memory`/`CLAUDE.md`; `mcp_servers` vacío). Trae skills y plugins integrados de la herramienta, no instrucciones del usuario.

## (e) Términos heredados (F203 §2)
- Cruzados en `salida/` frente al directorio: {maquina}, {maquina}, {organizacion}, {maquina}, {maquina}, {servicio-privado}, {proyecto-privado}, {organizacion-privada}, «La Claudia», {dominio}, somee, PROMPTs, Expediente, Knowledge-. Ninguno aparece en `salida/` sin estar en el directorio; los que aparecen en `salida/` (Lab-Documentos, Geometr…) también están en `repo/` → no atribuibles.
- Observación: la llamada 42 busca en `salida/A-01.md` literales privados (`{etiqueta-runner}|{organizacion}|{valor-privado}|{maquina}|{maquina}`) para depurarlos (luego edita la línea en la llamada 43). Todos están en `repo/` salvo `{valor-privado}`, que no está en ningún archivo del directorio ni en `salida/`. Origen no determinable (no hay memoria en el init); como no aparece en la salida, no sostiene ningún valor.

## (f) Regla de F206 §1
- No hay escritura, cómputo ni lectura del host: todo corrió por `./aislado` y los artefactos de `salida/` provienen de Write/Edit sobre `salida/` y de comandos aislados. Nada que anular.

## Demandas
- No hubo demandas (`salida/demandas.md` no existe); 0 rondas usadas.

## Observaciones para la presidencia
1. Llamada 1 sin línea de guardia (falló por validación, sin ejecución).
2. Bloqueo por operador `&&` (llamada 4), repetido correctamente.
3. Intento de listar SDEI/ (000), negado; no rodeado.
4. Literal `{valor-privado}` buscado y ausente del directorio y de la salida.
