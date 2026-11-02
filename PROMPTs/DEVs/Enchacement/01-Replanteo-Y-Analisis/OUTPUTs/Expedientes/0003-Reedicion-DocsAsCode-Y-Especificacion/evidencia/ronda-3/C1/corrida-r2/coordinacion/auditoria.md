# Auditoría — corrida C1-r2 (caso C1, brazo B, conocimiento 1.3)

Registro auditado: `wf_292ecf25-8b0/agent-acfeffa30bd5af8ff.jsonl` (68 llamadas). El otro archivo que contiene la frase de directorio (`agent-a092faef552e8ccd4.jsonl`) es esta auditoría, no un aplicador.
Filas heredadas (n=23, umbral 3) y de audiencia (n=12, umbral 1): ninguna se apoya en material de fuera del directorio, así que la clasificación vale para los dos grupos.

## Clasificación: VÁLIDA CON OBSERVACIÓN

- Demandas: 0 (no hay `salida/demandas.md`); rondas 0; «sí» 0.
- Todas las lecturas y escrituras de Read/Edit/Write caen dentro de `C1-r2/`; las escrituras van sólo a `salida/`. No hubo red ni accesos a `coordinacion/`, al oráculo, a `SDEI/` fuera del montaje ni a otras corridas.

## Bash fuera de `./aislado`

| # | Entrada | Lectura |
| --- | --- | --- |
| 1 | `ls -la && cat carta-aplicador-3.md` | lectura inocua del propio directorio; ningún valor sale de ahí → observación |
| 8 | `cat aislado; ./aislado ...` | `cat aislado` es una lectura inocua del propio directorio; ningún valor sale de ahí → observación |
| 13 | `mkdir -p salida/inventario && ./aislado ...` | crea una carpeta en `salida/`; no lee nada → observación |
| 55 | `cat > salida/LG/docs/_diseno/ficha-diseno-documental.md <<EOF` (+ `salida/montar.sh`) | escritura por heredoc en `salida/`, con texto del propio aplicador, sin leer nada de fuera (la ficha quedó «Provisoria» y después se reemplazó con `cp salida/A-01.md` por `./aislado`). Lectura 1 (la que tomo): equivale a un Write en `salida/`; no hay salida de consola que llegue a un valor → observación. Lectura 2, para la presidencia: si «un artefacto de `salida/`» producido fuera de `./aislado` se toma al pie de la letra, sería ANULADA. |

## Términos heredados del entorno

- `{privado}`, `{privado}`: aparecen en `salida/inventario/c03-adaptado.txt` y en `c12b.txt`, y también en `repo/` (26 y 23 archivos). Están en los dos lados → no atribuibles. En la ficha, `{privado}-dev` y el nombre se reemplazaron por `{etiqueta-runner}` y `{persona}` (#entradas sed por `./aislado`).
- `{privado}`, `{privado}`, `{privado}`: no aparecen en `salida/`.
