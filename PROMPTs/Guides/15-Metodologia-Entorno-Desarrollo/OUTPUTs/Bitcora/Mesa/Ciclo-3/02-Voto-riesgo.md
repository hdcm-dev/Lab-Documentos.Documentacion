# Mesa · Ciclo 3 · 02 — Voto del juez de riesgo e irreversibilidad

> Fecha: 2026-10-09. Rol: juez 5 del jurado (marco `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §4.3, §5.3). Función objetivo: ¿la corrección se puede revertir? ¿qué se rompe en la guía si sale mal?
> Base: `01-Consolidado.md` de esta carpeta y la guía 1.0.0 (`a2b78179…`).
> Criterio general: todas las correcciones son ediciones de texto en un `.md` y de archivos del laboratorio, así que se revierten con una edición inversa. **No hay veto en este ciclo**: ninguna corrección es irreversible. El riesgo real está en el **radio de impacto**: los parches que cambian el laboratorio (Dockerfile, `Directory.Build.props`, scripts) desplazan hashes y salidas versionadas, y los que tocan muchos sitios pueden dejar el modelo a medias. Cuando una dirección rompe menos que otra, la elijo y lo digo.

| Id | Voto | Fundamento |
|---|---|---|
| C3-01 | PROCEDE (dirección A) | Reversible; la definición única en §8.2.2 con remisiones cambia la regla en un sitio y deja los otros diez apuntando ahí, mientras que las cláusulas por sitio (B) multiplican los puntos que pueden quedar desalineados en el próximo cambio. Condición: verificar con `grep` el inventario de once lugares después del parche, y sumar el E1 como E5-8. |
| C3-02 | PROCEDE (dirección A + B(a)) | Reversible; el registro lleva «digest o versión del runner, nunca vacío» y además se declara que la capa 4 del runner sólo se consulta mientras dure la retención. Afirmar que el runner alcanza sin decir que el log caduca es lo que se rompe en silencio a los 90 días; reservar 8a a la imagen propia (c) contradiría el E1 de C3-03. |
| C3-03 | PROCEDE (dirección A, acotada) | El E1 sostiene que, para un artefacto gestionado y *framework-dependent*, alcanza el SDK exacto. Para no romper nada fuera de lo medido (C3-Q05), §9.6 conserva «la misma imagen» para lo nativo, *self-contained*, ReadyToRun y AOT. |
| C3-04 | PROCEDE | Reversible y de alcance chico (una frase de 8a y una línea del YAML). Si no se corrige, un agente que valide por el YAML rechaza la CI que la cara humana aprueba. Queda condicionado a C3-02. |
| C3-05 | PROCEDE (dirección (a)) | Lo más barato y reversible es declarar la retención y citar la fuente en el Anexo D. (b) agrega un paso nuevo a A.17 y al laboratorio, con más superficie de rotura y la dependencia de `ImageOS`, que no es un contrato. |
| C3-06 | PROCEDE (vía remisiones, según C3-01) | Hoy quien sigue A.12 con el runner rompe §8.2.6 sin enterarse. Las remisiones se revierten en bloque, cosa que no pasa con once cláusulas distintas. |
| C3-07 | PROCEDE | Cambia una sola oración, que deja de depender de rótulos sin definir. El riesgo es nulo. |
| C3-08 | PROCEDE | Una línea. Si no se agrega, quien copia la variante incumple 8a sin aviso. |
| C3-09 | PROCEDE | Hoy el registro miente con rc=0. Que A.17 falle cuando falta el archivo es justo la señal que hace falta. Cambia un script del laboratorio, así que hay que volver a correr EA-1 en el mismo parche y sumarle el paso con rc≠0. |
| C3-10 | PROCEDE | Es una corrección de texto en tres frases, sin efecto sobre el laboratorio. |
| C3-11 | PROCEDE (con condición) | Reversible, pero el Dockerfile de `A-plantillas` cambia de etiqueta y de digest. Condición: volver a correr EA-1 y actualizar su salida en el mismo cambio. Si eso no se hace, la guía cita una salida que ya no corresponde a la plantilla. |
| C3-12 | PROCEDE (con condición) | Quitar texto es lo más fácil de revertir. Al cambiar `A-plantillas/repo/Directory.Build.props` cambian los hashes que EA-1 pueda registrar: hay que volver a correrlo. E6-1 queda como demostración, con su nota, para no perder la evidencia. |
| C3-13 | PROCEDE | Hoy la guía recomienda una propiedad que no hace nada en sus propios SDK; el error es S2 y se corrige con texto reversible. El dato volátil va al Anexo F. |
| C3-14 | PROCEDE | Una oración. Las plantillas quedan en 8.0.425 rotuladas como «el del caso», así que el laboratorio no se toca. |
| C3-15 | PROCEDE | Cambia el rótulo, no la decisión C1-03. La oración sobre `paths` para Visual Studio entra marcada [no verificado] y se puede retirar sin dejar rastro si C3-Q04 sale negativa. |
| C3-16 | PROCEDE | Reversible. Toca la tabla de §5.2.3, A.1 y el README de N2. Condición: E2-6 con el caso con BOM ejecutado, y la parte (c) sobre Visual Studio marcada [no verificado] (C3-Q03). |
| C3-17 | PROCEDE | Hoy el primer commit sale en rojo. La corrección es un comentario de A.1 y un paso de EA-1. |
| C3-18 | PROCEDE (dirección (b)) | (a) cambia la conducta de la compuerta, que es la pieza central del laboratorio: puede poner en rojo EA-1, N8 y otras corridas versionadas, y obliga a mantener una lista de excepciones. (b) es texto más un paso X1 en EA-1, con menos radio de impacto. (a) puede quedar para un ciclo con su propio E1. |
| C3-19 | PROCEDE | Declarar que las dos vías se excluyen no rompe nada. Hoy la guía arma un conflicto con rc=1. |
| C3-20 | PROCEDE (primera opción) | «La compuerta entra en el commit 1 y se activa en el paso 4» no deja `main` en rojo. La segunda opción introduce un rojo transitorio que alguien puede tomar por falla y apagar la compuerta. |
| C3-21 | PROCEDE (mínima) | La receta va rotulada [no verificado] y se puede retirar sin costo. Sin ella, el rojo «falta python3» empuja a apagar el hook, que es una rotura peor. |
| C3-22 | PROCEDE | Reversible. Condición: regenerar `anexoA.py` y EA-1 en el mismo cambio, porque el Dockerfile del laboratorio cambia de comentario. |
| C3-23 | PROCEDE | Una frase. El universal actual contradice §10.2.7 y §10.7. |
| C3-24 | PROCEDE | Un destino explícito. Hoy el lector confunde MSB1003 con la señal NU1004. |
| C3-25 | PROCEDE | El snippet actual cierra la terminal del lector. `if/else` o un subshell no cambian el YAML. |
| C3-26 | PROCEDE (con condición) | Reversible. Como «gana el último patrón» [B178], un orden mal puesto deja todo igual que hoy sin que se note. Condición: volver a correr `owners.py` de AH-002 sobre el CODEOWNERS nuevo y versionar la salida. |
| C3-27 | PROCEDE | Agregar flags a una línea ilustrativa se revierte sin costo. Hay que mantener el rótulo «Ilustrativo»: no se corrió contra una atestación real. |
| C3-28 | PROCEDE | Reescribe dos frases para que coincidan con la decisión del ciclo 2. Hoy, si se encadenan, dan la conclusión opuesta. |
| C3-29 | PROCEDE (completar + [no verificado] en 8b y 9) | Completar la respuesta y rotular el YAML no quita nada. Acotar la consigna reduciría el alcance de una práctica que ya está publicada. |
| C3-30 | PROCEDE | Tres celdas o enlaces, sin prosa nueva. |
| C3-31 | PROCEDE | Acota una oración con evidencia propia (E8-1). |
| C3-32 | PROCEDE | Corrige dos textos del laboratorio. Condición: regenerar la salida o declarar el cambio de rótulo, para que el README no vuelva a desalinearse. |
| C3-33 | PROCEDE | Corrige una celda y suma la fuente. Si no se corrige, la guía promete una lectura que falla al subir a 3.15. |
| C3-34 | PROCEDE (con condición) | Reversible. El riesgo es escribir fechas falsas: cada fecha que se declare tiene que salir de `Ciclo-2/05-Aplicacion.md` §4.2 o de la propia salida, nunca estimarse. |
| C3-35 | PROCEDE (con condiciones) | Recortar es reversible, pero es lo que más puede romper: 183 anclas, remisiones cruzadas y avisos operativos que hoy se repiten donde hacen falta. Condiciones: columna «Δ palabras» medida con `wc -w`; volver a medir 0 enlaces rotos y 0 anclas huérfanas después del lote; la tesis de Visual Studio puede salir de las explicaciones repetidas, pero se queda donde funciona como advertencia en una receta. |

## Cierre del voto

- Vetos: **ninguno**. Ninguna corrección es irreversible y el veto acotado de §5.3 no se aplica.
- Parches que obligan a volver a correr el laboratorio en el mismo cambio: C3-09, C3-11, C3-12, C3-16 (E2-6), C3-17, C3-18 (X1), C3-22, C3-26 y C3-32. Recomiendo agruparlos y correr EA-1 una sola vez al final, con su salida versionada.
- Mi lectura de las tres contradicciones: C3-01 → A; C3-02 → A + B(a); C3-03 → A acotada a lo gestionado.
