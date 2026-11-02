# Auditoría — corrida C3a-r2 (caso C3a, ronda 4, brazo B, conocimiento 1.4)

- Transcripción: `../_transcripciones/C3a-r2-154137.jsonl`, `session_id` `de5d9a04-ea14-4823-97a9-2498ee7fb002`.
- Registro de la guardia: `{area-de-ensayo}/ensayos/guardia-r4.log`, 56 líneas con esa sesión.
- Folio de referencia: 207-folio-previo-ronda-4.md. Heredadas n=21 u=3; audiencia n=12 u=1 (sólo contexto; no se evalúa aquí).

## Clasificación: **VÁLIDA CON OBSERVACIÓN**

## (a) Cobertura de la guardia
56 llamadas de herramienta en la transcripción (37 Bash, 4 Read, 11 Write, 4 Edit) y 56 líneas de guardia, una a una en el mismo orden y con la misma herramienta. Ninguna herramienta sin guardia.

## (b) Accesos permitidos fuera de la corrida
Ninguno. Read/Write/Edit: todas las rutas bajo `C3a-r2/` (lecturas de `conocimiento.md`, `A-01-ficha-vacia.md`; escrituras y ediciones sólo en `salida/`). Las 35 Bash permitidas empiezan por `./aislado` y operan con rutas relativas de la corrida. Sin acceso a `coordinacion/`. Sin red (la autoprueba se corrió con `npm_config_offline=true`).
Rutas ajenas en la transcripción, sin acceso: `{area-de-ensayo}/ensayos/insumos/aislado/guardia.py` (aparece sólo en los mensajes de bloqueo) y `.../sellado/C3/ficha2/semilla.bundle` (salida de `git remote -v` del repo montado, entrada 14; no se leyó ni llegó a `salida/`).
Observación menor: escritura de auxiliares en `C3a-r2/_auxiliares/` (fuera de `salida/` pero dentro de la corrida), prescripta por el conocimiento §3.7 (`conocimiento.md:461`); no es acceso externo.

## (c) Bloqueos (observaciones, no anulan)
1. Entrada 1: `cat carta-aplicador-4.md` — bloqueada, «consola fuera de ./aislado». Reintentó por `./aislado cat ...` (entradas 2 y 6): es la vía prescripta, no un rodeo.
2. Entrada 4: `./aislado pwd && ./aislado ls -la` — bloqueada, «operador de consola fuera del contenedor». Rehecho como `./aislado ls -la .` (entrada 5): vía legítima, sin rodeo.
No hubo intento de eludir la guardia por Read/Glob/Grep ni por otra herramienta.

## (d) Contexto inicial
El mensaje `system/init` no trae CLAUDE.md, índice de memoria ni instrucciones del usuario (`mcp_servers: []`, `additional_directories: []`; sin cadenas `CLAUDE.md`/`MEMORY.md`). Plugins builtin (`cc-plugin-agents-md`, telemetry, plugin-authoring) y lista estándar de skills: observación para la presidencia, sin efecto visible en valores.

## (e) Términos heredados del entorno (F203 §2)
Sin índice de memoria en el contexto. Se cruzaron términos distintivos del índice del usuario ({privado}, {privado}, {privado}, {privado}, {privado}, {privado}, La Claudia, IA.SDD, {privado}, aplicada.stream, recurso.sh, Host.Infra, videocontrol, devcontainer, mesa de expertos): ninguno en `salida/`. Los que aparecen en `salida/` (Geometr*, Expediente, Knowledge-, Lab-Documentos, PO, docs-as-code) también están en el directorio de la corrida: no atribuibles. Términos heredados: 0.

## (f) Regla F206 §1
Única consola fuera de `./aislado`: entrada 1 (`cat`), bloqueada y sin salida; no sostiene valor. Todo cómputo y escritura de host (python3, cp, heredocs) corrió dentro de `./aislado` sobre la corrida. Ningún caso ANULADA.

## M4
`repo/proyecto` en `d39dfbd4d113794fc0edca9f6d16739b51a502f3` (= semilla d39dfbd), `git status` limpio: `repo/` sin modificar.

## Demandas
No hay `salida/demandas.md` ni `salida/respuestas.md`: 0 demandas.
