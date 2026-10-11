# Mesa · Ciclo 1 · 02 — Voto del juez de costo-beneficio

> Fecha: 2026-10-07. Marco: `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §4.3 (función 3) y §5.3. Insumo: `01-Consolidado.md` de esta carpeta.
> Función objetivo: ¿el costo de corregir (extensión, complejidad, riesgo de diluir) es menor al daño de no hacerlo? Voto por ítem, no en bloque.
> Criterio transversal de este juez: en las [CONTRADICCIÓN] elijo la dirección que repara el daño con menos texto nuevo y menos superficie para mantener. Cuando un ítem procede pero su dirección completa es cara, el voto acota el alcance mínimo.

| Id | Voto | Fundamento |
|---|---|---|
| C1-01 | PROCEDE | Afirmación falsa con E1 (exit 145) que bloquea estaciones; se corrige reescribiendo una frase y alineando cuatro remisiones: costo bajo, daño alto. |
| C1-02 | PROCEDE | Acotar la frase al caso medido y citar `NU1603` cuesta una oración; dejarla generaliza un comportamiento que el lector verá contradicho en su consola. |
| C1-03 | PROCEDE | Dirección (a): lock por defecto con `disable` y su costo declarado (SDK exacto en toda estación), más un párrafo con la alternativa sin lock (`latestPatch` + `NU1603` como error); la (b) duplica la política en §6, §7, A.3, A.4 y §12 y diluye la ruta estándar. |
| C1-04 | PROCEDE | «En la CLI sí; en VS depende del SDK» es un cambio de una línea más un rótulo; el «Sí» rotundo es falso en el entorno donde nace el caso. |
| C1-05 | PROCEDE | Alcance mínimo: declarar el alcance de la compuerta de N7 y que falle ante un proyecto no listado, y nombrar la relación `compuerta.sh`/`verificar.sh`; un `n/a` silencioso es exactamente la señal falsa que la guía combate. |
| C1-06 | PROCEDE | Lista de prerrequisitos, recuadro «Desde Windows» rotulado [no verificado en Windows] y distinguir «falta herramienta» de «violación» son pocas líneas; sin ellas el escenario disparador no tiene camino ejecutable. |
| C1-07 | PROCEDE | Que el esqueleto salga 1 con mensaje es un cambio trivial; hoy las plantillas «verificadas» aceptan el defecto que la guía existe para impedir. |
| C1-08 | PROCEDE | Dirección (a): reparar el script propio (ya cubierto por C1-05/06/07) y sumar editorconfig-checker en §5.2.5 como alternativa con sus límites; la (b) reescribe §10, A.11, B.1 y el laboratorio, costo desproporcionado para el mismo resultado. |
| C1-09 | PROCEDE | Pérdida de trabajo medida; la precondición y el `git diff --quiet` son dos líneas en §5.2.6 y B.1. |
| C1-10 | PROCEDE | Dirección (b): separar «lo decide un lector» de «convención del equipo» achica la tabla en vez de agregarle ramas, y sumar `dotnet new console` a EA-1 resuelve las dos violaciones medidas con A.1. |
| C1-11 | PROCEDE | Acotar «nunca» al condicional de identificador es una frase; el error se reproduce (SyntaxError, RZ1005/CS1056) y el cuantificador es falso. |
| C1-12 | PROCEDE | Reescribir un punto y alinear una tabla; hoy contradice a §6.2.3 y a la doc de npm con E1. |
| C1-13 | PROCEDE | El Anexo A es lo que se copia: una plantilla que falla en su propio EA-1 tiene daño directo; alinear versiones y remisiones es barato. |
| C1-14 | PROCEDE | Hacer depender §11.3/§11.6 P2 de la variable de §11.2.7 es texto corto; la etapa con compuerta e igualar el origen de Python cierran una contradicción que lleva a armar mal la CI. |
| C1-15 | PROCEDE | Comando que falla copiado; agregar `buildx create`, corregir `PY_IMAGE` y mostrar lo ejecutado cuesta minutos. |
| C1-16 | PROCEDE | Corregir P4 y el diagrama para no prometer lo que ningún camino da es barato; el alcance de lo que se agrega lo fija C1-18 (b), así que basta separar los tres conceptos. |
| C1-17 | PROCEDE | Declarar que E6-5 no alcanza L1 es una oración; dejar «L1 de inmediato» induce a afirmar un nivel SLSA falso ante un tercero. |
| C1-18 | PROCEDE | Dirección (b): §12 paso 8a (registro del entorno + SBOM, estándar) y 8b (firma si hay consumidor externo); la (a) arrastra C1-16 y C1-32 completos a la ruta estándar y es coherente con lo que la propia §3.4 ya dice. |
| C1-19 | PROCEDE | Nota «qué no impide», «Pro→Team» y una fila GitLab son pocas líneas; sin ellas se vende como control lo que el PR puede saltear. |
| C1-20 | PROCEDE | Unificar un rótulo y agregar el ecosistema `docker` a A.13 (que el laboratorio ya tiene) es casi gratis. |
| C1-21 | PROCEDE | Dirección (b): etiqueta fija + `global.json` en el devcontainer y digest + bot en lo publicado; la (a) obliga a un `build.dockerfile` más que mantener y la propia guía advierte que digest sin bot congela vulnerabilidades. |
| C1-22 | PROCEDE | Una línea *Aplica* por respuesta y una pregunta situada por capítulo es extensión acotada y la exige la regla del PO; acotado a eso, sin reescribir las preguntas existentes. |
| C1-23 | PROCEDE | Alcance mínimo: ruta mínima (un experimento existente por capítulo, con tiempo) en §0.2 o Anexo E y un «Práctica» de 2–3 líneas por capítulo que remita a esos experimentos; no escribir ejercicios nuevos para no inflar la guía. |
| C1-24 | PROCEDE | Opción barata: señalizar dos velocidades en §3 (Recorrido vs consulta) con una nota; reubicar §3.3 cuesta más y arrastra remisiones, no lo voto. |
| C1-25 | PROCEDE | Agregar filas al glosario y expandir siglas en primera aparición es mecánico y de bajo riesgo; distinguir los tres «índice» evita una confusión real. |
| C1-26 | PROCEDE | Citar [B83] con sus palabras y alinear A.4 cuesta poco; una cita mal transcripta es defecto de evidencia. Se aplica después de C1-03. |
| C1-27 | PROCEDE | Los primeros comandos fallan copiados; `cd`, subshells y `chmod +x`/`sh` son correcciones triviales con daño alto a la primera impresión. |
| C1-28 | PROCEDE | Dos líneas en el extracto; omitir el clon limpio enseña lo contrario de la regla que el script implementa. |
| C1-29 | PROCEDE | Reformular como prueba de regresión del `.csproj` en CI es una oración; hoy el criterio no es comprobable donde se aplica. |
| C1-30 | PROCEDE | Opción inexistente en pip-tools (exit 2); atribuir a uv y decir «por entorno» es corrección de pocas palabras. |
| C1-31 | PROCEDE | Matizar el criterio y citar `pmOnFail` es una frase; el criterio actual es falso para pnpm ≥ 11. |
| C1-32 | PROCEDE | Acotado por C1-18 (b): dentro de la rama 8b, un párrafo con la vía sin clave y su costo de privacidad y una línea sobre que `verify-blob-attestation` no verifica `builder.id`; no más que eso. |
| C1-33 | PROCEDE | Una línea por ecosistema con su hueco; hoy se presentan como equivalentes mecanismos que no lo son. |
| C1-34 | PROCEDE | Separar versión vigente de estatus ISO es una celda; error factual verificable. |
| C1-35 | PROCEDE | Describir #83320 como arreglo y bajar la rama ACP UTF-8 a pregunta es barato; mantenerla en el diagrama afirma algo que la propia prueba de Roslyn contradice. |
| C1-36 | PROCEDE | Cambiar un argumento y presentar `text=auto` como opción válida es corto; el argumento actual se contradice con la propia guía. |
| C1-37 | PROCEDE | Reemplazar una señal pobre por otra correcta; el E1 muestra que la regla actual prohíbe algo que funciona. |
| C1-38 | PROCEDE | Nombre corto junto al ID la primera vez por sección en prosa (no en tablas): mecánico, mejora la lectura sin cambiar contenido. |
| C1-39 | PROCEDE | Una oración en §12 elimina la contradicción con §0.2/§3.2. |
| C1-40 | PROCEDE | Cerrar el vocabulario de marcas es mecánico (buscar y reemplazar) y hace verificable el sistema de procedencia que la guía promete. |
| C1-41 | PROCEDE | Dos permalinks; costo mínimo y cumple lo que el Anexo D promete. |
| C1-42 | PROCEDE | Reescribir una frase y quitar las «Partes» del índice (opción más barata que agregar separadores). |
| C1-43 | PROCEDE | El entregable no puede dejar una decisión pendiente ni hablar de un actor interno; dar un criterio de elección de SBOM en §9.2.3 y limpiar el `status` es corto. |
| C1-44 | PROCEDE | Alcance mínimo: una tabla «Por contexto» en §3.6; párrafos en §5.4–§8.4 sólo donde el contexto cambia algo, para no agregar relleno. |
| C1-45 | PROCEDE | Opción barata: declarar la exclusión en §0.1 con motivo; una subsección comparativa exige investigar vigencia (C1-Q06 en nivel C) y diluye el foco. |
| C1-46 | PROCEDE | Quitar `traces` o agregar una tabla pedido→sección de pocas filas; trazas sin resolver son ruido en el entregable. |
| C1-47 | PROCEDE | Bloques YAML breves sólo en §5.2.6 y §12 con datos que ya están en la prosa; lo pide Rule-Dual-Audience y el costo es bajo. |
| C1-48 | PROCEDE | Costo nulo sobre la guía: registrar el apartamiento y la entrada propuesta en la bitácora para el PO, sin escribir la ia-db. |

## Resumen

- 48 PROCEDE, 0 NO_PROCEDE, 0 INSUFICIENTE.
- Direcciones elegidas en las contradicciones: C1-03 (a), C1-08 (a), C1-10 (b), C1-18 (b), C1-21 (b).
- Ítems con alcance acotado por costo: C1-05, C1-22, C1-23, C1-24, C1-32, C1-44, C1-45, C1-47.
