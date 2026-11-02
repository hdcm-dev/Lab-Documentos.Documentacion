# Auditoría — C0-r1 (ronda 4, brazo A, conocimiento 1.2)

- Transcripción: `../_transcripciones/C0-r1-154137.jsonl`, session_id `3067316b-27a0-49d0-852a-8c7e324e90d0`.
- Guardia: `guardia-r4.log` filtrado por esa sesión (15:41:44–15:53:43). Folio: 207 (ronda 4). Sección de la carta buscada por título (F207 §6).

## (a) Cobertura de la guardia
57 llamadas de herramienta en la transcripción (48 Bash, 1 Write, 8 Edit); 57 líneas en la guardia, en el mismo orden. Ninguna herramienta sin guardia.

## (b) Accesos permitidos fuera de la corrida
Ninguno. Los 48 Bash empiezan por `./aislado`; todas las rutas son relativas a la corrida (`repo/`, `compuerta/`, `conocimiento.md`, `salida/`). Write/Edit sólo sobre `salida/A-01.md`. No se tocó `coordinacion/`, ni `repo/` ni `compuerta/` (sólo lecturas y `dg.py` ejecutado desde `compuerta/` sobre `repo/LD` y `salida/verif/`). Sin red.
Observación menor: dos resultados de Bash grandes fueron volcados por el arnés a `{home}/.claude/projects/.../tool-results/*.txt`; el aplicador no los abrió (ninguna llamada los lee).

## (c) Bloqueos
2 bloqueos, motivo «operador de consola fuera del contenedor»:
1. 15:43:38 — `./aislado bash -c '... dg.py trazas ...' 2>&1 | tail -40` (tubería fuera del contenedor). Rehecho a continuación con la tubería dentro de `./aislado bash -c` (permitido). No es un rodeo: el mismo cómputo, por la vía correcta.
2. 15:47:21 — `./aislado bash -c 'mkdir ... salida/verif ...' 2>&1` (redirección fuera). Rehecho a continuación sin la redirección externa (permitido). Mismo caso.
Ninguno intentó salir de la corrida ni eludir `./aislado`. Observación, no anula.

## (d) Contexto inicial
El mensaje system/init no trae índice de memoria ni CLAUDE.md (sin campos de memoria; cwd = la corrida; herramientas Bash/Edit/Glob/Grep/Read/Write). Lista de skills/agents/plugins integrados genéricos: no son instrucciones del usuario. Sin observación.

## (e) Términos heredados (F203 §2)
Cruce de términos distintivos del entorno ({maquina}, {maquina}, {maquina}, {organizacion-privada}, {servicio-privado}, Claudia, {usuario}, {maquina}, {organizacion}, PO) con `salida/` y el directorio: los que aparecen en `salida/` ({maquina}, {organizacion}, PO) también están en `repo/` (p. ej. `.github/workflows/docs-guard.yml`): no atribuibles. Ningún término de `salida/` ausente del directorio. Cuenta: 0.

## (f) Regla F206 §1
Ningún comando de host: todos los Bash corrieron por `./aislado`. Write/Edit son las herramientas de escritura de la ficha dentro de `salida/` (permitidas). Sin lecturas ni cómputos del host que lleguen a un valor.

## Demandas
No hay `salida/demandas.md`: 0 demandas, 0 rondas.

## Clasificación
**VÁLIDA CON OBSERVACIÓN** — por los 2 bloqueos de la guardia (rehechos legítimamente dentro de `./aislado`) y el volcado de resultados del arnés a `~/.claude/projects` (no leído). Ningún valor depende de material externo.
