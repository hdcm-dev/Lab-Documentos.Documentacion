# Mesa · Ciclo 1 · 02 — Voto del juez de riesgo e irreversibilidad

> Fecha: 2026-10-07. Marco: `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §4.3 (juez 5) y §5.3. Insumo: `01-Consolidado.md` de esta carpeta.
> Función objetivo: ¿la corrección es reversible? ¿qué se rompe en la guía si sale mal? Veto sólo si la corrección es irreversible y la severidad S3 o menor.

## Criterio general

Todas las correcciones propuestas son ediciones de texto de un único `.md` y de archivos del laboratorio, sin publicación ni efectos externos: son reversibles. **No ejerzo veto sobre ningún ítem.** El riesgo que pondero es el radio de rotura dentro de la guía (referencias cruzadas, anexos, laboratorio que deja de coincidir con el texto) y el riesgo de introducir afirmaciones no verificadas al corregir. En las contradicciones voto `PROCEDE` (hay que decidir) e indico la dirección de menor radio de rotura.

Condición transversal a todo `PROCEDE`: cuando la corrección toca un comando o un archivo del laboratorio, el experimento afectado se vuelve a correr y su salida versionada se actualiza; cuando toca un ID, sección o línea citada en otro lugar (Anexo A, B.1, §12, Anexo E), se revisan las referencias cruzadas.

## Votos

| Id | Voto | Fundamento |
|---|---|---|
| C1-01 | PROCEDE | Reversible; el error actual induce a fijar `disable` creyendo que no bloquea estaciones. Rotura posible: §6.4, §6.2.2, §3.3, A.3 y B.1 deben cambiar juntos o quedan contradictorios. |
| C1-02 | PROCEDE | Reversible y acotado a una frase; corregirlo sólo restringe el alcance al caso medido. Rotura nula si E4-2 se amplía con las dos salidas ya obtenidas. |
| C1-03 | PROCEDE | Reversible. Dirección de menor riesgo: (a) lock por defecto con `disable` y costo declarado; (b) reescribe §6, §7, A.3, A.4 y §12 a la vez y multiplica la superficie de incoherencia (C1-01, C1-26 dependen de esto). |
| C1-04 | PROCEDE | Reversible. Riesgo: sin host Windows, la nueva frase no debe afirmar el comportamiento de VS más allá de lo leído en los targets; rótulo [no verificado en Visual Studio] obligatorio. |
| C1-05 | PROCEDE | Reversible. Riesgo medio: unificar `compuerta.sh`/`verificar.sh` puede romper N7, N8 y A.11; volver a correr ambos niveles y declarar el alcance antes de fusionar scripts. |
| C1-06 | PROCEDE | Reversible. Riesgo: los comandos para Git Bash/Windows no pueden ejecutarse aquí; deben ir con [no verificado en Windows] para no reemplazar un hueco por una afirmación falsa. Distinguir herramienta ausente de violación sí es verificable (E1). |
| C1-07 | PROCEDE | Reversible y de bajo radio: un esqueleto que salga 1 sólo cambia A-plantillas y A.11; hoy el daño es silencioso (acepta cp1252). |
| C1-08 | PROCEDE | Reversible. Dirección de menor riesgo: (a) conservar el script propio (C1-05/06/07) y sumar editorconfig-checker en §5.2.5 como alternativa con sus límites; (b) reescribe §5.2.5, §10, A.11, B.1 y el laboratorio, radio de rotura mayor. |
| C1-09 | PROCEDE | La corrección es reversible; lo irreversible es el defecto actual (pérdida de trabajo sin commitear en el lector). Prioridad alta; repetir en B.1. |
| C1-10 | PROCEDE | Reversible. Dirección de menor riesgo: (a) rama nueva + corregir `*.csproj` con E2-6, porque conserva la estructura que citan A.1, §11.2.2 y §12 paso 2; (b) obliga a reescribir esas tres piezas. |
| C1-11 | PROCEDE | Reversible, una frase y dos experimentos que suman un caso; rotura nula. |
| C1-12 | PROCEDE | Reversible. Rotura posible: la tabla de criterio de §11 y N8 deben cambiar juntas; re-medir E8-3. |
| C1-13 | PROCEDE | Reversible. Riesgo: cambiar la versión de Node de A.10 propaga a `.nvmrc`, A.9 y EA-1; correr EA-1 completo tras el cambio. |
| C1-14 | PROCEDE | Reversible. Riesgo: tocar el Dockerfile por componente invalida salidas de E8; reconstruir y versionar. |
| C1-15 | PROCEDE | Reversible y verificable de inmediato: el comando corregido se corre y se versiona su salida. |
| C1-16 | PROCEDE | Reversible; la corrección quita una promesa que el laboratorio no cumple, lo cual reduce riesgo. Coordinar con C1-18. |
| C1-17 | PROCEDE | Reversible; rebajar «L1 de inmediato» a lo que sí se cumple no rompe nada y elimina una afirmación falsa. |
| C1-18 | PROCEDE | Reversible. Dirección de menor riesgo: (b) §12 paso 8a/8b; (a) exige resolver C1-16, C1-32 y C1-Q07 (nivel C, sin verificar) antes de afirmar la firma en la ruta estándar. |
| C1-19 | PROCEDE | Reversible, aditivo (nota «qué no impide», Pro→Team, fila GitLab) con fuentes ya consultadas. |
| C1-20 | PROCEDE | Reversible; unificar el rótulo y sumar `docker` a A.13 alinea la plantilla con el laboratorio que ya lo tiene. |
| C1-21 | PROCEDE | Reversible. Dirección de menor riesgo: (b) etiqueta fija + `global.json` en dev, digest + bot en lo publicado; (a) depende de que un bot actualice la `image` del devcontainer, que la tabla oficial niega para privados. |
| C1-22 | PROCEDE | Reversible y aditivo (una línea *Aplica* por respuesta); riesgo sólo de IDs mal asignados, revisable. |
| C1-23 | PROCEDE | Reversible y aditivo; sobre experimentos existentes no introduce afirmaciones nuevas. |
| C1-24 | PROCEDE | Reversible. Prefiero señalizar dos velocidades: reubicar §3.3 rompe referencias desde §12 y otros capítulos. |
| C1-25 | PROCEDE | Reversible y aditivo; riesgo bajo (definiciones nuevas deben llevar fuente). |
| C1-26 | PROCEDE | Reversible; citar a [B83] con sus palabras sólo corrige. Resolver después de C1-03 para no editar A.4 dos veces. |
| C1-27 | PROCEDE | Reversible (`chmod +x`/`git update-index --chmod=+x` se deshace); rotura nula, y hoy los primeros comandos fallan. |
| C1-28 | PROCEDE | Reversible; el extracto pasa a coincidir con el script real. |
| C1-29 | PROCEDE | Reversible. Menor riesgo: acotar la afirmación a lo comprobable; la prueba de regresión en CI es opcional y no debe afirmarse sin correrla. |
| C1-30 | PROCEDE | Reversible, una atribución; ya verificado con pip-compile 7.6.2. |
| C1-31 | PROCEDE | Reversible; matiz con fuente y E1. |
| C1-32 | PROCEDE | Reversible y aditivo en lo que la firma con clave no protege. Riesgo: no afirmar `--policy` de cosign mientras C1-Q07 siga en nivel C; depende de C1-18. |
| C1-33 | PROCEDE | Reversible; una línea por ecosistema; los huecos no medidos (fuera de NuGet) deben ir rotulados. |
| C1-34 | PROCEDE | Reversible, corrección bibliográfica puntual. |
| C1-35 | PROCEDE | Reversible; bajar la rama a pregunta reduce una afirmación no sostenida. |
| C1-36 | PROCEDE | Reversible; cambia el argumento sin cambiar la plantilla A.2 salvo que se decida, y `text=auto` como opción válida no rompe nada. |
| C1-37 | PROCEDE | Reversible; evita una recomendación que pierde la atribución de blame. |
| C1-38 | PROCEDE | Reversible y mecánico; riesgo bajo de nombre corto inconsistente, revisable con grep. |
| C1-39 | PROCEDE | Reversible, una frase. |
| C1-40 | PROCEDE | Reversible pero de radio amplio (unas cien marcas): hacerlo con reemplazo revisado marca por marca, no con sustitución ciega, y dejar el conteo antes/después. |
| C1-41 | PROCEDE | Reversible. Riesgo: un SHA mal copiado rompe el enlace; verificar que cada permalink resuelva. |
| C1-42 | PROCEDE | Reversible; si se quitan las Partes del índice, verificar que nada enlace a ellas. |
| C1-43 | PROCEDE | Reversible; el entregable no puede dejar una decisión «de la mesa» pendiente. Dar criterio con condiciones es de menor riesgo que fijar un formato sin especialista. |
| C1-44 | PROCEDE | Reversible y aditivo. |
| C1-45 | PROCEDE | Reversible. Menor riesgo: declarar la exclusión en §0.1; una subsección comparativa hoy se apoyaría en C1-Q06, de vigencia no verificada. |
| C1-46 | PROCEDE | Reversible; cualquiera de las dos direcciones es segura. |
| C1-47 | PROCEDE | Reversible y aditivo; riesgo nulo si el bloque no contradice el procedimiento. |
| C1-48 | PROCEDE | Reversible: sólo registrar el apartamiento con la entrada propuesta para el PO; escribir en `ia-db` queda fuera del alcance y no debe hacerse. |

## Resumen

- 48 votos: 48 `PROCEDE`, 0 `NO_PROCEDE`, 0 `INSUFICIENTE`. Sin vetos (ninguna corrección es irreversible).
- Direcciones de menor riesgo en contradicciones: C1-03 (a), C1-08 (a), C1-10 (a), C1-18 (b), C1-21 (b).
- Orden sugerido por dependencia: C1-03 → C1-01, C1-26; C1-18 → C1-16, C1-17, C1-32; C1-08 → C1-05, C1-06, C1-07.
