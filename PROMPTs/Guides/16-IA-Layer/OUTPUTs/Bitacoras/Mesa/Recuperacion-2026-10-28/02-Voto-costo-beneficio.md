# Voto del jurado: costo-beneficio (mesa de recuperación, 2026-10-28)

**Función.** Preguntar, en cada ítem, cuánto cuesta frente a lo que gana el lector de la guía. Pongo el costo en horas de trabajo, en recompilar y volver a probar, en turnos de modelo en las dos estaciones y en el riesgo de abrir piezas que ya pasan (443/443 y 70/70). Pongo el beneficio en defectos cerrados, cifras honestas y garantías demostradas. Criterio general: una prueba determinista sin modelo es barata y vale mucho. Reabrir lo construido, o recalcular en masa, cuesta mucho y vale poco. Importar cifras de otra composición tiene un costo oculto: habría que defenderlas en la relectura.

Fuentes: `01-Matriz.md` y los nueve `Panel-*.md` de esta carpeta. Los paneles coinciden en A en casi todo. Las divergencias son REC-07 (operación: C), REC-15 (B, cuatro paneles), REC-18 (senior: C) y REC-21 (C, tres paneles).

## Votos

| Ítem | Opción | Fundamento (costo frente a beneficio) |
|---|---|---|
| REC-01 | A | Cuesta un cambio de encabezado y avisa al lector de un cambio de contenido real. La B esconde la recuperación. La C multiplica las versiones sin que nadie las consuma. |
| REC-02 | A | Es el ítem más caro, y cada turno se paga una sola vez: una fase única, después de integrar y antes de la relectura, evita volver a correr si la integración cambia las piezas. Repartir la carga entre las dos estaciones baja el tiempo de reloj. La D concentra todo en una estación y desperdicia la otra. La C ahorra poco, porque DEP-03, DEP-09 y DEP-13 son cortas y sostienen garantías. La B es gratis, pero deja la guía sin una sola cifra vigente, y ese costo lo paga su credibilidad. |
| REC-03 | A | Una sola relectura completa, sobre la guía ya re-corrida, evita releer dos veces (B). La C ahorra lectores, pero con más de 5.100 líneas que crecen, una revisión parcial deja sin ver las remisiones cruzadas. |
| REC-04 | A | Reusar el trabajo ya hecho como insumo cuesta casi nada. Mapearlos uno por uno (B) es caro y mete otra numeración. Descartarlos (C) tira valor. |
| REC-05 | A | Notas fechadas y una redefinición en prosa, sin tocar el código. La B obliga a recompilar y volver a probar para quitar algo que no molesta. La C eleva al PO una pregunta que ya no tiene objeto. |
| REC-06 | A | Es obligatorio: R-PRIV en un repo público no admite que se omita. Cuesta poco frente al riesgo de publicar una fuga, y la verificación final ya se paga en REC-02. |
| REC-07 | A | Dos líneas de entorno y un adaptador fuera del repo destraban la re-corrida al menor costo posible. El renombre atómico (C/D) toca repo y bitácora, y obliga a re-verificar con --fake y ArnesTests por un beneficio de nombre. Una nota de equivalencia da el mismo resultado. Si la relectura muestra fuga por el nombre, se renombra entonces. |
| REC-08 | A | La regla cuesta un párrafo y evita recargas de 10 a 16 s por turno, que en REC-02 se multiplican por cientos de llamadas. Con eso se paga sola. |
| REC-09 | A | Es un defecto real con un arreglo de pocas líneas y dos pruebas sin modelo. La relación entre costo y beneficio es de las mejores de la matriz. |
| REC-10 | A | La captura del cuerpo es determinista y barata, y corrige una tabla que hoy induce a error. La redacción de tool_choice va enmendada como pide el abogado del diablo, sin costo extra. |
| REC-11 | A | Una regla y una compuerta mecánica sobre capturas que ya existen. Evita que una credencial termine en una evidencia publicada. Costo bajo, beneficio alto. |
| REC-12 | A | Un cambio de clave y dos casos rojos sin modelo cierran una fuga entre sesiones en CTX-SENS. La C deja al código de 17 enseñando lo contrario de la prosa. |
| REC-13 | A, con la condición del abogado del diablo | La pieza ya existe y está probada, y portarla salda una deuda declarada. El costo extra está en volver determinista la prueba. Si eso no sale en un tiempo razonable, cae a C. |
| REC-14 | A | La prueba roja la decide el contenedor de DI: es barata y reproducible, y convierte una afirmación de ADR-12 en algo demostrado. |
| REC-15 | B | Citar la tabla del insumo (A) obliga a recalcularla y a defender su trasladabilidad en la relectura. Es un costo alto por cifras que el propio insumo declara no trasladables. La B fija el digest y quita la 7b, que es barato, y deja la re-medición dentro de REC-02, que ya se paga. |
| REC-16 | A | Una prueba sin modelo decide si la garantía cubre el CP, y las re-corridas ya entran en REC-02. Mucho beneficio con poco costo marginal. |
| REC-17 | A | Dos pruebas de cableado, primero. Endurecer sólo si fallan, en el lugar donde ya se endureció la provincia. Volver a correr AC-5 y AC-10 es barato. La B deja la guía contradiciendo su propio dominio. |
| REC-18 | A | Sumar un evaluador con oro cuesta poco y cambia un juez que no mide nada (0/52) por uno que mide corrección. La corrida en la estación 2 ya está dentro de REC-02. La C ahorra un evaluador y pierde el beneficio principal. |
| REC-19 | A | Agregar el estimando y «caída = no medido» cuesta un par de párrafos y un script como compuerta. La D (recalcular 365 cifras) cuesta muchísimo sin beneficio, porque AH-02 respalda el método de la base. |
| REC-20 | A | No reabrir una demo que pasa 70/70. La D sería lo más caro de la matriz. Las re-corridas entran en REC-02 y las citas rotuladas cuestan una frase. |
| REC-21 | C | Re-correr y sumar la fila y la frase es barato. El detector suma una segunda pieza, con su calibración y su mantenimiento, para un beneficio que una frase sobre GuardaDeTruncado cubre igual. |
| REC-22 | A | El lector es un DelegatingHandler chico, con su prueba, y convierte un «desconocido» en un dato. La re-corrida de 05 ya está en REC-02. Sólo entra la existencia, no la cifra de tiempo. |
| REC-23 | A | La re-corrida de 16 ya se paga en REC-02. Sumar la observación rotulada y la frase única cuesta un párrafo. |
| REC-24 | A | Tres advertencias en prosa, con costo casi nulo, frente a enseñar a exponer un servidor sin autenticación. |
| REC-25 | A | Registrar la versión negociada y extender la garantía a las escrituras son cambios acotados con pruebas sin modelo. El Bearer (C) y la migración de 13 (D) suman superficie y pruebas por un beneficio que la guía no necesita para su caso. |
| REC-26 | A | Cumplir la promesa de ADR-11 con una regla y dos mutaciones es barato. La C importa reglas que la arquitectura de la base no pide. La D deja sin mostrar la debilidad de AC-5. |
| REC-27 | A | Primero verificar, que cuesta casi nada. El caso rojo y la guarda sólo se pagan si falta la cobertura. |
| REC-28 | A | Las re-corridas entran en REC-02, el barrido es sin corrida y el oro suma una sola entrada. El perímetro de la demo no se toca. |
| REC-29 | A | Un estímulo con oráculo en un ejemplo que ya existe. Expone una falla silenciosa que la prosa sola (C) no deja verificar. |
| REC-30 | A | Casos rojos acotados en 14 y 10, más una frase y el glosario. Sin BuildSequential, el costo queda contenido. |
| REC-31 | A | Un párrafo y referencias. Sumar un control al ejemplo (C) agrega código y pruebas por un caso que la guía trata como regla. |
| REC-32 | A | Una nota cuesta una frase. Reescribir la escalera (C) es caro y rompe C5. |
| REC-33 | A | Un sed por mapa con diff es barato y verificable, y deja el barrido en 0 sin tocar las capturas fijadas por hash. La C deja fugas en los .log. La B posterga sin ganar nada. |
| REC-34 | A | Registrar no cuesta nada. Reabrir sin nombrar qué no tiene beneficio. |
| REC-35 | A | Retirar tres líneas, volver a correr build y AC-6 y actualizar el hash es barato, y limpia F.1 justo ahora que el hash igual cambia con la recuperación. |
