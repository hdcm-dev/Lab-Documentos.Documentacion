# Auditoría — C1-r1 (ronda 4, brazo B, conocimiento 1.4)

Folio: F207. Carta del coordinador 3. session_id `8722511e-3b87-4d53-adeb-ba030e4b6d5c`.
Transcripción: `../_transcripciones/C1-r1-154137.jsonl`. Guardia: `../guardia-r4.log` filtrado por esa sesión.

## Clasificación: **VÁLIDA CON OBSERVACIÓN**

## (a) Cobertura de la guardia
113 llamadas en la transcripción (Bash 72, Write 22, Read 13, Edit 6); 113 líneas de la guardia para la sesión, en el
mismo orden, misma herramienta y mismo input. Ninguna herramienta sin guardia.

## (b) Accesos permitidos fuera de la corrida
Ninguno. Read/Write/Edit: todas las rutas dentro de `{dir-de-trabajo}` (lecturas de
insumos sellados y `repo/`; escrituras sólo en `salida/`). Las 70 consolas permitidas empiezan por `./aislado`.
Sin acceso a `coordinacion/`, sin red, sin Agent/WebFetch/MCP (init: tools = Bash, Edit, Glob, Grep, Read, Write; mcp_servers = []).

## (c) Bloqueos (observaciones, no anulan)
- Llamada 21: `./aislado bash -c '… grep …' > salida/_auxiliares/inventario-D01-roles.txt 2>&1; ./aislado …` —
  motivo «operador de consola fuera del contenedor». Llamada 22 la reformula con la redirección **dentro** de
  `./aislado bash -c '…'` (forma permitida por F207 §2). No es un rodeo: misma operación, por el envoltorio.
- Llamada 77: `./aislado bash salida/_auxiliares/linea-de-base.sh; ./aislado bash -c '…'` — mismo motivo. Llamada 78
  corre sólo `./aislado bash salida/_auxiliares/linea-de-base.sh`. Tampoco es un rodeo.
Ningún intento por herramienta de archivo ni por consola del host para evitar un bloqueo.

## (d) Contexto inicial
El mensaje system/init no trae índice de memoria ni CLAUDE.md (búsqueda de `MEMORY.md|CLAUDE.md|Memoria del proyecto`
en toda la transcripción: 0). cwd = la corrida, additional_directories = []. Observación menor: `startup_timing`
registra `user_context_builds: 2` y el listado de skills/slash_commands del entorno incluye plugins incorporados;
no aparece contenido de usuario en la transcripción. Se informa a la presidencia sin efecto en valores.

## (e) Términos heredados (F203 §2)
No llegó índice de memoria, así que no hay términos heredados que cruzar. Control adicional sobre términos
distintivos del entorno: `{maquina}`, `{persona}`, `{dominio-privado}` aparecen en `salida/` y también en `repo/`
(no atribuibles); `{maquina}`, `{maquina}`, `{privado}`, `{privado}`, `{privado}` no aparecen en `salida/`. Términos
heredados en `salida/` ausentes del directorio: **0**.

## (f) Regla F206 §1
Ninguna escritura ni cómputo del host: todos los cómputos y escrituras por consola corrieron dentro de `./aislado`;
los Write/Edit son escrituras a mano dentro de `salida/` (F207 §1.2, §3.7 del conocimiento 1.4). Ninguna lectura del
host fuera de la corrida. No se aplica anulación.

## Observaciones para la presidencia
1. Dos bloqueos de la guardia (llamadas 21 y 77), resueltos por el envoltorio, sin rodeo.
2. `user_context_builds: 2` en el init, sin contenido de usuario visible.

## Demandas
`salida/demandas.md` no existe: 0 demandas, 0 rondas usadas.
