# Verificación independiente de la etapa 4 (1): lente adversarial de contenido

> Fecha: 2026-11-02. Verificador independiente, sólo lectura: no se tocó el libro, el Conocimiento ni los ejemplos. Sin commit, push, PR ni merge.

## 0. Reanudación tras el corte de ssh

El PO avisó de otro corte de red. Al empezar, este archivo no existía y no había ninguna verificación de la etapa 4 a medias. El libro está en el sha256 que registra E11 (`5ebbfdbb2497b9e2e197851f453cb335311ca1d6a301548249e1a74db87b5e12`), así que nadie lo editó después de E10 F6 y E11.

## 1. Criterio

Se buscaron afirmaciones inventadas o sin fuente, citas que no dicen lo que se les atribuye y cifras que no coinciden con la evidencia. Cada vez se volvió a abrir la fuente primaria (registros R-LLM, oros, `ejemplo.json`, rama de Lab-Geometria) y no se dio por buena la bitácora de E10 ni la de E11. El muestreo fue dirigido a las cifras con IC95, a los conteos de conjuntos de oro y al cap. 16.

## 2. Comprobaciones sin hallazgo

| Afirmación (libro) | Fuente reabierta | Resultado |
|---|---|---|
| l.1132: 05 con `qwen3.5:4b`, 5/6 pares con 650 tokens de unos 1.670; `frio` en 13; `par-prefijo` 0/6 | `Evidencia/R-LLM-2026-10-28/estacion-1/R-05/…jsonl` (5 × `prompt_eval_cached_count:650`) y `PV-02/corrida-2026-11-01/…jsonl` | coincide |
| l.1326: con-prefijo ≈ 61 %, ≈ 42,5 s contra ≈ 70 s | `PV-02/corrida-2026-11-01`: `prompt_eval_duration_ms` 42.457–43.203 contra 69.764–72.004 | coincide |
| l.1480: 08 fuera de catálogo 10/10, estación 2 | `tools/recalcular-oraculos.sh estacion-2/R-08/fdc-*/*.jsonl` rc 0, 10/10 coinciden, 10 «pasa» | coincide |
| l.1658: 03 cp34 10/10, `faltan:codigoPostal` | `recalcular-oraculos.sh estacion-1/R-03/cp34-*` rc 0, 10 × pasa + `faltan:codigoPostal` | coincide |
| README 08 l.79: no-inventa 8/10 | `R-08/v1` + `ext`: recálculo rc 0, 8 pasa / 2 falla | coincide |
| IC95 de 5/6, 0/6, 10/10, 8/10, 4/4, 0/30 (l.1132, 1480, 1658, 2143, 2172, 3157) | recálculo Clopper-Pearson propio | los seis coinciden con 3 decimales |
| l.1452/1500/1501: oro 06 = 16 (12 + 4), calibración = 10 (5 no respondibles), oro v2 de 07 = 17 (5 no) | `Examples/06…/oro/*.json`, `Examples/07…/oro/conjunto-de-oro.v2.json` | coincide |
| l.3157: 26,8 s de mediana en A, cota 11,6 %, 24/30 («cuatro de cada cinco») | `[ruta-trabajo]/g16-geometria/ai-layer/ensayos/Resultado.md` l.25–48 | las cifras coinciden (ver H-2 sobre «se publicó») |
| 187 referencias | `grep "^- \[REF-"`: 187, todas distintas | coincide |
| E11, mermaid.sh 27/27 | 25 bloques en el libro + 2 en el Conocimiento = 27 | coincide |
| Terminología del acta | Conocimiento l.346: «contenedor nativo (*native shell*; en la jerga del proyecto, «cascarón»)»; 0 «App Shell» en `*.md` de la guía; el libro no habla de MAUI/OTA | conforme |

Compuertas que se corrieron otra vez: `contar.sh` rc 0 (59.373/60.000); `compuerta-intervalos.py <libro> R-LLM-2026-10-28 compuerta-intervalos.tsv` rc 0 (28/28, 21/21); `compuerta-referencias.sh` rc 0; `compuerta-rpriv.sh .` rc 0 (sólo clases genéricas, sin `COMPUERTAS_DIR`).

## 3. Hallazgos

**H-1 (P1, afirmación desactualizada que contradice la evidencia).** `Examples/08-Primera-Herramienta-Solo-Lectura/README.md:41` dice: «Contra el modelo no se corrió todavía: queda para la fase con modelo…». Lo contradicen el mismo README en la l.79 («fuera-de-catalogo afirma-sin-herramienta 10/10») y el libro en la l.1480, y la evidencia `estacion-2/R-08/fdc-01…10` da recálculo rc 0, 10/10. Ni F1 ni F6 de E10 lo detectaron.

**H-2 (P1, afirmación sin respaldo verificable).** En el libro, l.3157 dice «se fijó el criterio y se publicó el banco», y la l.3091 dice que la especificación vive «en una rama que todavía no se fusionó a `main`». Lo que se encontró:
- El banco, el criterio y los registros (`ai-layer/ensayos/banco.json`, `Criterio-R-LLM.md`, `corrida-2026-11-01/`) existen sólo en la rama local `g16/ai-layer-v1` (b4832d4) del worktree `[ruta-trabajo]/g16-geometria`.
- `git ls-remote origin 'refs/heads/g16/*'` no devuelve nada (rc 0), y ninguna rama remota contiene b4832d4.

Así que el banco no está publicado. Un lector no puede verificar la l.3157 y tampoco puede encontrar «la rama». Hay dos salidas: publicar la rama, o cambiar el texto (por ejemplo «se fijó el criterio y se versionó el banco en una rama local, todavía no publicada»). Es una decisión de coordinación (se trata de otro repo) o del PO.

**H-3 (P2, el ejemplo publicado apunta a la bitácora excluida).** E10 F1 dejó esto anotado como pendiente para E11, y E11 no lo registra como resuelto:
- `Examples/15-Pruebas-Y-Evaluacion/Application/CongeladorDeSalidas.cs:69` tiene `Registro = "/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Guides/16-IA-Layer/OUTPUTs/Bitacoras/Evidencia/R-LLM/07-RAG-Con-Citas.modelo.jsonl"`.
- `Examples/15-Pruebas-Y-Evaluacion/entradas/salidas-07.v1.json:13` tiene la misma ruta.

No es el libro, pero remite a una ruta que el lector no puede abrir, contra la regla «el libro no enlaza a la bitácora» que rige para lo público. Cambiar el `.json` cambia un insumo congelado y hay que ver si tiene SHA-256 en `ejemplo.json`.

**H-4 (P3, posible confusión, sin error).** El libro, l.1132, usa la corrida del 2026-10-29 (la del `estado` de `ejemplo.json` de 05), y la ficha, l.1326, usa la del 2026-11-01. Las dos corridas dan 650 × 5 en la evidencia, así que no hay contradicción, pero en la misma sección del libro conviven dos fechas para el ejemplo 05. Queda como observación, sin pedido de cambio.

## 4. Pendientes

1. H-1: corregir README 08 l.41 (es un archivo de la guía; lo hace el agente que tenga el turno de edición).
2. H-2: decidir si se publica la rama `g16/ai-layer-v1` de Lab-Geometria o se cambia el texto de las l.3091 y 3157 (coordinación o PO).
3. H-3: hacer neutra o quitar la ruta en `CongeladorDeSalidas.cs:69` y `salidas-07.v1.json:13`, cuidando el congelamiento.
4. Siguen abiertos los heredados de E11: los 256 hallazgos R-PRIV en la bitácora (PO), H-2 de la etapa 3 (`dominios.txt`, coordinación) y H-6 (PO).

sha256 del libro al cerrar: `5ebbfdbb2497b9e2e197851f453cb335311ca1d6a301548249e1a74db87b5e12` (no cambió).
