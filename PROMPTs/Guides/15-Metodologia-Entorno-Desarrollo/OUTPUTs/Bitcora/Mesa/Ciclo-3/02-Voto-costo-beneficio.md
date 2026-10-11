# Mesa · Ciclo 3 · 02 — Voto del juez de costo-beneficio

> Fecha: 2026-10-09. Marco: `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §4.3 (3) y §5.3. Función objetivo: ¿el costo de corregir (extensión, complejidad, riesgo de diluir) es menor al daño de no hacerlo?
> Insumos: `01-Consolidado.md` de este ciclo y la guía 1.0.0 (54 267 palabras). Voto por ítem, no en bloque.
> Criterio transversal, propio: C2-36 fijó un saldo de prosa ≤ 0 y el PO pidió compresión. Por eso, entre dos direcciones que corrigen el mismo daño, voto la que agrega menos palabras. Una corrección que agrega texto procede sólo si el daño es concreto: un comando que falla, un registro falso o una afirmación refutada por un E1.

| Id | Voto | Fundamento |
|---|---|---|
| C3-01 | PROCEDE (dirección A) | Una definición por capa en §8.2.2, con remisiones, cierra los once lugares por ≈ una línea cada uno. La tabla de dos caminos y las cláusulas por sitio cuestan ≈ +300 palabras para el mismo efecto (C3-35 p.4). El E1 del abogado (misma DLL en tres bases) sostiene la definición. Se suma una sola fila en §11.3, porque §11 es el capítulo central. |
| C3-02 | PROCEDE (A + B.a) | Que el registro diga «digest o versión del runner, nunca vacío», más una oración que declare la retención con su fuente, cuesta dos líneas y hace honesto el camino del runner. Archivar «Set up job» (b) o reservar 8a (c) suma mecanismo o contradice el E1 de C3-03, y el daño no lo justifica. |
| C3-03 | PROCEDE (dirección A) | Hay un E1 directo de que, para lo gestionado, alcanza con el mismo SDK. Conservar «bit a bit» como motivo enseña algo refutado. Acotar §9.6 a los artefactos nativos cuesta un paréntesis, y ese límite queda abierto en C3-Q05. |
| C3-04 | PROCEDE | Es consecuencia directa de C3-02 A. Cuesta editar dos líneas (L2478, L2507). Sin el cambio, un agente que valide por el YAML rechaza la CI que la guía aprueba. |
| C3-05 | PROCEDE (opción a) | Basta la oración de retención de C3-02, con la fuente en el Anexo D: es lo más barato. Callar que la capa 4 caduca contradice la tesis propia de la capa 6. |
| C3-06 | PROCEDE (por remisiones, según C3-01 A) | El daño es S2: quien sigue A.12 rompe §8.2.6 sin enterarse. Con remisiones a la definición, cada sitio cuesta una referencia y no una cláusula. Los *No aplica* de §8.6 y §8.7 entran sólo si salen más cortos que la remisión. |
| C3-07 | PROCEDE | Reemplazar los rótulos todavía no definidos (8a, 8b, frontera A) por su contenido sale con saldo ≈ neutro. Corrige además una razón equivocada: la que vale es la base compartida con el devcontainer. |
| C3-08 | PROCEDE | Es una línea de YAML o una aclaración. Sin ella, la variante pierde un requisito que 8a exige. |
| C3-09 | PROCEDE | El daño es grave, porque el registro afirma algo falso y sale con 0. La corrección son un comentario en A.12, un default con falla en A.17 y un paso en EA-1, y toca código, no prosa. |
| C3-10 | PROCEDE | Se cambian unas palabras («mismo manifiesto», «para la misma plataforma»). La afirmación tal como está es falsa con el digest que fija la propia guía. El `--platform` va sólo como [criterio], en una línea. |
| C3-11 | PROCEDE (acotado) | Hay que cambiar la etiqueta en A.10 y en el Dockerfile y volver a correr EA-1. Es costo de ejecución, no de prosa, y alinea A.10 con A.9 y con la regla de §10.2.6. La línea nueva en §10.2.6 entra sólo si no la cubre ya la remisión a la regla. |
| C3-12 | PROCEDE | Quita texto: es la única dirección del panel con saldo negativo. Retira una plantilla muerta que, conectada, rompe la reconstrucción. |
| C3-13 | PROCEDE | La guía recomienda algo que en sus SDK no hace nada y no avisa (E1, MSB4057). El daño es S2 de falsa seguridad, y la corrección son tres acotaciones y un comando. |
| C3-14 | PROCEDE | Es una oración en §12 p.5. La hoja de ruta fija un SDK al que le quedan 32 días de soporte. El daño es concreto y el costo, mínimo. |
| C3-15 | PROCEDE (acotado) | El rótulo «fabricante» es incorrecto según [B56] y corregirlo no cuesta nada. La mitigación `paths` entra en una sola línea con [no verificado]. La tabla de ocho repos va al Anexo F y no al cuerpo, para no engordar §6. |
| C3-16 | PROCEDE | Las partes (a) y (b) son afirmaciones refutadas por E1, que a nivel de capítulo cuesta poco corregir (una fila, una razón). La parte (c) se resuelve con una cláusula. Si no se corrige, el lector aplica una política de BOM con razones falsas. |
| C3-17 | PROCEDE | Si no se corrige, el primer commit sale en rojo siguiendo la propia plantilla. Alcanza con nombrar un archivo y ajustar un paso de EA-1. |
| C3-18 | PROCEDE (dirección b, sin repetir) | Las promesas de §10.4, §11.7 y §11.8 se corrigen para que no digan más de lo que hace la compuerta, y X1 se suma a EA-1. Cambiar el código de la compuerta (a) cuesta más y abre una lista de excepciones. La señal «`n/a` con manifiesto versionado» entra como una línea en §11.7. |
| C3-19 | PROCEDE | Son dos líneas. Hoy las dos vías que da la guía se excluyen en la práctica (rc=1) y el lector se lo encuentra sin aviso. |
| C3-20 | PROCEDE | Una frase alinea dos secciones que hoy dan órdenes incompatibles, con saldo ≈ neutro. |
| C3-21 | PROCEDE (acotado) | Basta una receta de dos o tres líneas en A.11, rotulada [no verificado], y una remisión desde B.1. El caso disparador es Windows, y sin receta el hook se apaga. Las alternativas no se desarrollan. |
| C3-22 | PROCEDE | Se cambia el nombre en tres sitios y se regenera `anexoA.py` y EA-1. Hoy la pieza central manda a un archivo que no se copia o que no existe. |
| C3-23 | PROCEDE | Se cambia un verbo y se agrega una remisión. El universal está refutado por la propia guía (E7-5). |
| C3-24 | PROCEDE | Es un argumento más y un comentario. El snippet falla tal cual (MSB1003) y puede confundirse con la señal que enseña. |
| C3-25 | PROCEDE | Es un cambio de forma del bloque (if/else o subshell). Hoy el snippet cierra la terminal en la que se pega. |
| C3-26 | PROCEDE | El daño es S2 de seguridad: cualquier par puede desarmar la compuerta, contra lo que dice §10.2.7. Se resuelve con líneas de CODEOWNERS y un paréntesis en L1978, sin prosa. |
| C3-27 | PROCEDE | Son dos flags y una oración en §9.3, tomados de la ayuda oficial de gh. La línea actual acepta cualquier workflow y no verifica el L3 que la guía promete. |
| C3-28 | PROCEDE | Se reescriben dos frases con saldo neutro. Hoy el encadenamiento de las secciones da lo opuesto de lo decidido en el ciclo 2. |
| C3-29 | PROCEDE (completar en una línea) | La evidencia de 1, 2, 8a y 10 ya existe, así que completar la respuesta cuesta una línea y no hace falta acotar la consigna. 8b y 9 se marcan [no verificado] en el YAML. |
| C3-30 | PROCEDE | Son tres celdas o enlaces, sin prosa. Hoy el lector no llega a la plantilla de la capa 6. |
| C3-31 | PROCEDE | Se acota una cláusula. La generalización la refuta el propio E8-1 (rc=2). |
| C3-32 | PROCEDE | Se corrigen dos textos del laboratorio que contradicen su propia salida. Se declara el cambio de rótulo en lugar de regenerar, que es lo más barato. |
| C3-33 | PROCEDE | Es una celda con un dato falso para Python ≥ 3.15 (E1 y documentación oficial). Se corrige la celda y se agrega una fuente. |
| C3-34 | PROCEDE (una línea, sin columna) | Una línea antes de la tabla del Anexo E cumple lo que promete §0.3. La columna «Fecha» en 65 filas no agrega nada a esa línea. |
| C3-35 | PROCEDE | La función objetivo del PO es la compresión y el saldo vigente (C2-36) lo exige. Se aprueban los recortes 1, 2, 3 y 5, con la columna «Δ palabras» medida con `wc -w` en cada parche. El punto 4 ya queda cubierto por C3-01 A. Riesgo de diluir: los recortes sacan repeticiones (de 9 a 14 apariciones), no tesis, y cada tesis se conserva una vez con remisión. |
