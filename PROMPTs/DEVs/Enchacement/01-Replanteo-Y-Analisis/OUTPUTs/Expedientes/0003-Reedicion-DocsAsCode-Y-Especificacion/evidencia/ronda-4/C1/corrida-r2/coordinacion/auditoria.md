# Auditoría — C1-r2 (caso C1, ronda 4, brazo B 1.4)

Folio previo: `207-folio-previo-ronda-4.md`. Heredadas n=23 u=3; audiencia n=12 u=1.
Transcripción: `../_transcripciones/C1-r2-154137.jsonl`, session_id `3dd811d9-fecf-4c09-9d94-43e470360210`.
Guardia: `guardia-r4.log` filtrado por esa sesión (42 líneas; 2 Write truncadas, leídas por regex).

## Clasificación: **VÁLIDA CON OBSERVACIÓN**

## (a) Cobertura de la guardia
42 llamadas de herramienta en la transcripción (31 Bash, 4 Read, 2 Write, 5 Edit) y 42 líneas en la guardia, en el mismo orden y con el mismo input. Ninguna herramienta sin guardia.

## (b) Accesos permitidos fuera de la corrida
Ninguno. Los Read/Write/Edit permitidos (`motivo: archivo`) caen en `C1-r2/` (lecturas de `A-01-ficha-vacia.md` y `conocimiento.md`; escrituras sólo en `salida/A-01.md`). Las 29 Bash permitidas corrieron por `./aislado`; las escrituras desde el contenedor van a `salida/_auxiliares/`. Sin red, sin acceso a `coordinacion/`, sin cambios en `repo/` ni `compuerta/`.

## (c) Bloqueos (observaciones, no anulan)
1. Entrada 1, Bash `cat .../C1-r2/carta-aplicador-4.md` — `ok:false`, «consola fuera de ./aislado». No se ejecutó. El aplicador repitió la lectura por `./aislado` (entradas 2 y 5): es la vía prescrita y sobre un archivo de la corrida, no un rodeo.
2. Entrada 18, Bash `./aislado bash -c '…' 2>&1 | head -60` — `ok:false`, «operador de consola fuera del contenedor» (la tubería `| head` corría en el host). No se ejecutó. La entrada 19 rehízo el mismo cómputo con `head` dentro del contenedor: corrección hacia la vía prescrita, no un rodeo.

## (d) Contexto inicial
El mensaje `system/init` no trae memoria ni CLAUDE.md (sin `claudeMd`, sin índice de memoria; la transcripción no contiene «MEMORY.md» ni «Memoria del proyecto»). cwd = directorio de la corrida, `additional_directories: []`, sin servidores MCP. Lista de skills/plugins genérica del producto: observación menor, ningún valor la usa.

## (e) Términos heredados (F203 §2)
No llegó índice: se cruzaron términos distintivos del entorno del usuario ({maquina}, {maquina}, {maquina}, {maquina}, {privado}, {privado}, somee, {dominio-privado}, Lab-Geometria, {privado}, {maquina}, Parana, Expediente, Knowledge-, Issue699, {privado}, recurso.sh, VideoControl, SDEI…). En `salida/` sólo aparecen «Lab-Geometria» y «Expediente», ambos presentes en el directorio de la corrida: no atribuibles. «{maquina}-dev» figuró en un borrador y el aplicador lo reemplazó por `{etiqueta-runner}`; el término está en `repo/` (26 archivos). Términos heredados en `salida/` y ausentes del directorio: **0**.

## (f) Regla F206 §1
Ninguna escritura ni cómputo del host: todo `python3`/`find`/`grep`/`tee` corrió dentro de `./aislado`; las escrituras con Write/Edit van a `salida/A-01.md`. Las dos órdenes del host fueron bloqueadas y no produjeron salida. Ninguna lectura del host llegó a un valor. Sin causal de anulación.

## Demandas
No hay `salida/demandas.md`: 0 demandas, 0 rondas.
