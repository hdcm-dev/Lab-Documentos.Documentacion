# Mesa · Ciclo 2 · 02 — Voto del juez de riesgo e irreversibilidad

> Fecha: 2026-10-09. Marco: `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §4.3 (juez 5) y §5.3. Insumo: `01-Consolidado.md` de esta carpeta, los informes y la guía (1.0.0-rc.1, 3391 líneas).
> Función objetivo: ¿la corrección es reversible? ¿qué se rompe en la guía si sale mal? Veto sólo si la corrección es irreversible y la severidad es S3 o menor.

## Criterio general

Todas las correcciones son ediciones de texto de un único `.md` y de archivos del laboratorio, sin publicación ni efectos externos. Son reversibles. **No ejerzo veto sobre ningún ítem.**

Hay una salvedad de reversibilidad que este ciclo no tenía el anterior: `git status` en `LAB/Lab-Documentos` muestra `Guides/Metodologia-Entorno-Desarrollo/` como **no rastreado** (`??`). No hay commit al que volver. **Condición previa a aplicar el lote**: copiar la guía y `Examples/` tal como están a la bitácora (`Ciclo-2/aplicacion/antes/`) y dejar registrada su suma de comprobación. Sin esa copia, la reversión depende de la memoria del auditor.

Pondero tres riesgos:

1. El radio de rotura dentro de la guía: referencias cruzadas, Anexo A, B.1, §12 y un laboratorio que deja de coincidir con el texto.
2. El riesgo de reemplazar un defecto probado por una afirmación no verificada.
3. El riesgo de que una pieza copiable deje de funcionar en la máquina del lector.

En las contradicciones voto `PROCEDE` (hay que decidir) e indico la dirección de menor radio de rotura. Mantengo coherencia con mi voto de C1-08 en el ciclo 1.

Condición transversal a todo `PROCEDE`:

- Si la corrección toca un comando, una plantilla o un script del laboratorio, el experimento afectado se vuelve a correr y su salida versionada se actualiza.
- Si toca un ID, una sección o una línea citada en otro lugar, se revisan las referencias cruzadas con `grep`.

## Votos

| Id | Voto | Fundamento |
|---|---|---|
| C2-01 | PROCEDE | Adoptar A y B a la vez. Es reversible: es una línea comentada en A.4. El E1 del abogado muestra que con lock queda rc=0 incluso con caché fría, así que A no rompe la consola. Lo que se rompe si sale mal son §6.4, §7.2.1, §7.7 y A.4b, que deben cambiar juntos. B depende de que C2-03 entre con experimento. |
| C2-02 | PROCEDE | La corrección es reversible; el defecto actual es silencioso (CI en verde sin lock). La condición `Exe Or WinExe` cubre las dos órdenes de inferencia (C2-Q06 sigue sin verificar). Riesgo: no extender el lock a los proyectos de prueba sin experimento; ahí basta una nota. EA-1 con WinExe es obligatorio antes de cerrar. |
| C2-03 | PROCEDE | Reversible. Hay riesgo de falsos positivos: un rango flotante declarado a propósito daría rojo. El paso de la compuerta lleva su límite marcado como [criterio], el experimento `requested-vs-resolved` versionado y una forma de excepción. Si no llega a la compuerta con E1, la frase baja de tono; no se deja la promesa sin pieza. |
| C2-04 | PROCEDE | Es aditivo y tiene fuente oficial (`releases.json`, eol 2026-11-10). No cambia ningún comando. Rotura nula si el Anexo F y A.3 citan la misma fecha. |
| C2-05 | PROCEDE | Dirección B: reparar la compuerta propia (C2-06 y C2-07) y dejar editorconfig-checker en §5.2.5 como alternativa con sus límites. Así lo voté en C1-08. A reescribe §5.2.5, §10.2.2, A.11, B.1 y §12 paso 4, suma una dependencia binaria nueva y su trato del BOM no está contrastado con los tres estados de C2-12. Su radio de rotura es mayor. |
| C2-06 | PROCEDE | Reversible. Lo que hoy se rompe es lo peor posible: da «texto: OK» con cp1252. Retirar `verificar.sh` como pieza copiable tiene el menor radio de rotura; repararlo obliga a sumar el paso a EA-1 y a correr X1/X2 de nuevo. Depende de C2-05. |
| C2-07 | PROCEDE | Reversible y acotado a A.10, más el prerrequisito `import editorconfig`. Sin la corrección, la CI de A.12 siempre da rojo y culpa a una política que no se violó. EA-1 con la compuerta completa es obligatorio. |
| C2-08 | PROCEDE | Reversible y de bajo radio: `git update-index --chmod=+x` en A.11, `bash` explícito en A.12 y un ítem en B.4. El defecto actual deja entrar cp1252 sin aviso. Que Git for Windows registre ese modo sigue sin verificar (C2-Q04a); hay que rotularlo así. |
| C2-09 | PROCEDE | Dirección de menor riesgo: declarar el límite y corregir ESC-04. Hacer que el hook falle cuando el manifiesto está en stage y el lock no puede bloquear commits legítimos; si se adopta, va con experimento de los dos casos. |
| C2-10 | PROCEDE | Reversible. Mantener [no verificado]. Recomendar `MSYS_NO_PATHCONV=1` como prefijo de cada comando y no como variable global, porque global altera otras rutas en Git Bash. Citar las dos fuentes del fabricante. |
| C2-11 | PROCEDE | Reversible. Riesgo de seguridad si se escribe `safe.directory '*'`: se acota a la carpeta del workspace o se pasa a `remoteUser` no root. Volver a correr `devcontainer up` en EA-1. |
| C2-12 | PROCEDE | Reversible. Dirección de menor riesgo: ampliar la variante B a csproj/props/targets. Normalizar los `.csproj` sin BOM choca con el SDK, que los crea con BOM, y quizá con Visual Studio (C2-Q04c, sin verificar). B.2 y §5.9 P2 pasan a tres estados en la misma edición. |
| C2-13 | PROCEDE | Dirección A: condicionar la imagen propia a 8b y a la frontera, con runner alojado + `setup-*` por SHA como camino de 8a. Hoy el camino de la imagen no funciona copiado: no baja una imagen privada (C2-18) y nadie mueve el digest (C2-17). Completarlo (B) agrega tres piezas sin E1. Aun así, C2-18 entra como arreglo mínimo para quien elija la imagen. El camino alojado también es E2/E4 y va rotulado. |
| C2-14 | PROCEDE | Reversible. Corregir `imagen=desconocida` y dar la plantilla de registro con su salida. No inventar un job de build+registro+SBOM sin E1. Si no se ejecuta, corregir §11.8 para que no lo prometa. |
| C2-15 | PROCEDE | Comprimir §9.2.4 a un bloque «Para 8b», con la precisión de C2-16 adentro. Bajar texto reduce la superficie de afirmaciones a mantener. Riesgo: no perder anclas citadas desde §11.2.8 y el Anexo F, así que se hace un `grep` de los vínculos a §9.2.4 tras el recorte. |
| C2-16 | PROCEDE | Reversible. Reemplaza un [no verificado] por E1 (`e1-builder-id.txt`) más una fuente oficial: baja el riesgo. Se aplica dentro del presupuesto de C2-15. |
| C2-17 | PROCEDE | Reversible y de una frase. Riesgo: afirmar que Renovate lo resuelve sin probarlo. Hay que nombrar quién mueve el digest o dejar [no verificado]. Depende de C2-13. |
| C2-18 | PROCEDE | Reversible. Sin la corrección, A.12 falla en el primer uso con imagen privada. `packages: read` más `credentials` va rotulado [no verificado] mientras no haya corrida. Depende de C2-13, pero aplica en cualquier dirección. |
| C2-19 | PROCEDE | Aditivo, con fuente [B177]. Rotura nula: suma una fila de la tabla y un ítem de la lista de L1910. |
| C2-20 | PROCEDE | Reversible y de una frase, con fuente GHES 3.22. Hay que alinear §10.2.8 en la misma edición para que no quede una contradicción. |
| C2-21 | PROCEDE | Reversible. Alinea el diagrama y la tabla con §11.2.8, que ya está bien. Riesgo: el diagrama de §11.2.9 se cita en §11.6, así que hay que revisar ese renglón. Depende de C2-15. |
| C2-22 | PROCEDE | Reversible y local a la matriz de §2.4. Rotura nula si las celdas «Aplica» citan secciones existentes. |
| C2-23 | PROCEDE | Reversible. Riesgo: el reemplazo mecánico no debe quitar el digest donde sí corresponde (CI, imagen de 8b). Se hace fila por fila en las cuatro filas y luego `grep digest` de control. |
| C2-24 | PROCEDE | Reversible. Hoy el comando de §0.4 rompe silenciosamente §8.5 y E5-2. La alternativa debe conservar `cli-plugins` y declarar la versión de buildx; hay que volver a correr E5-2. |
| C2-25 | PROCEDE | Reversible y de una línea, con E1 (4.3.0 falla y 4.4.0 pasa). Rotura nula. |
| C2-26 | PROCEDE | Reversible y local. El defecto actual da un SBOM o una procedencia sin fecha fija en el paso siguiente. La forma con `$GITHUB_ENV` tiene fuente oficial. |
| C2-27 | PROCEDE | Reversible. Pegar literal reduce el riesgo de que un lector compare contra una salida que nunca existió. La regla de recorte de §0.3 es aditiva. El chequeo mecánico es opcional y no condiciona el cierre. |
| C2-28 | PROCEDE | Sólo si `comando-de-la-guia.sh` vuelve a correr con `,version=v1` y la salida confirma v1. Si la corrida falla, no se aplica y la frase baja a [no verificado]: no se cambia un defecto por otro. |
| C2-29 | PROCEDE | Dirección de menor riesgo: calificar por versión en las cinco ubicaciones («desde 3.15.0, publicada el 2026-10-09 [fuente]») sin cambiar la fecha global del documento. Volver a fechar todo obliga a revalidar cada dato «vigente al 2026-10-07»; es un radio de rotura desproporcionado. |
| C2-30 | PROCEDE | Reversible y con E1 (pnpm 10.18.0). Riesgo: el diagrama de L968 y la bibliografía cambian en la misma edición; si se agrega una entrada `[Bnn]`, se mantiene el conteo definidas = citadas. |
| C2-31 | PROCEDE | Reversible y de una oración. La forma acotada (Linux/macOS, fuente) es más segura que listar excepciones, que obliga a probar cada una. |
| C2-32 | PROCEDE | Reversible. Riesgo: un criterio de corrección nuevo no puede apoyarse en salidas que no existen. Se repone §11.9.1 sobre E8-1, que ya está corrido, y se completa §9.9.2 con E6-5. No se abren experimentos nuevos en esta edición. |
| C2-33 | PROCEDE | Aditivo. Sin experimentos nuevos el riesgo es bajo. Se cuida que la práctica no prometa validaciones del YAML que no estén ligadas a un experimento. |
| C2-34 | PROCEDE | Reversible. Corregir R-03 y P-09 y retitular tiene bajo radio. Mover la tabla obliga a actualizar el índice (L48) y `traces` (L15) en la misma edición. |
| C2-35 | PROCEDE | Acotado: fijar los términos en el Anexo C y corregir sólo las ocurrencias ambiguas señaladas. Renombrar en masa 72 «registro» y 27 «manifiesto» tiene el mayor radio de rotura del lote (anclas, citas literales, cambio de sentido); está prohibido como reemplazo global. |
| C2-36 | NO_PROCEDE | No adoptar un tope duro (≤48 000) que rechace lotes con saldo positivo. Forzaría a recortar evidencia materializada que exigen Rule-Evidences y el criterio del PO (las citas entran con explicación y snippet). Esa pérdida es la menos reversible del ciclo, porque nadie la detecta después. La Δ de palabras por parche sí puede informarse a título informativo, sin compuerta. |
| C2-37 | PROCEDE | Se reorganiza sin perder contenido: celda breve más lista, una regla por párrafo, bloques «Detalle de versión». Riesgo: los párrafos que se parten pierden anclas o citas. Se hace un `grep` de los `[Bnn]` y las marcas antes y después; los conteos tienen que coincidir. La magnitud la fija C2-36. |
| C2-38 | PROCEDE | Reversible y local a §3.4, §3.7 y al cierre de §10. Agregar «Volver al mapa» es aditivo. Simplificar P2/P5 no debe dejar preguntas sin *Aplica* (64/67 hoy). |
| C2-39 | PROCEDE | Reversible y de un rótulo. Baja el riesgo de que el lector tome por ejecutado un YAML que no se corrió. |
| C2-40 | PROCEDE | Reversible y de una palabra en §0.3, más la celda del control de cambios. Rotura nula. |

## Resumen

- Vetos: ninguno. No hay corrección irreversible.
- `NO_PROCEDE`: C2-36, el tope duro de palabras. Es el único ítem cuya aplicación arriesga una pérdida difícil de detectar y de revertir: evidencia recortada.
- Direcciones de menor riesgo en las contradicciones:
  - C2-01: A y B a la vez.
  - C2-05: B (reparar la compuerta propia).
  - C2-13: A (condicionar la imagen, con C2-18 como arreglo mínimo).
  - C2-15: comprimir, con C2-16 adentro.
  - C2-29: calificar por versión sin volver a fechar el documento.
  - C2-36: sin tope duro.
- Condición previa: copiar la guía y `Examples/` a la bitácora antes de aplicar, porque el árbol no está rastreado por git.
