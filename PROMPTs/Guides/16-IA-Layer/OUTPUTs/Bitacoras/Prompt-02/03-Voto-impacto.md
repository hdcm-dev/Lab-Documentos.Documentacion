# Voto del jurado: impacto (a ciegas)

Criterio: el mayor beneficio para el lector, con el menor costo de reedición y de mantenimiento a futuro.

| Id | Opción | Fundamento |
|---|---|---|
| D-01 | a | Quitar la cifra evita que el texto se desactualice; la única fuente queda en `contar.sh`, sin agregar compuertas. |
| D-02 | a | Alcanza con declararla en el texto, que es donde la lee el alumno; ADR y prueba agregan costo sin beneficio para el lector. |
| D-03 | b | Un grep previo es barato y evita romper los enlaces y las compuertas. |
| D-04 | c | Es un umbral simple y verificable; si falla, vuelve a la mesa y no se degrada en silencio. |
| D-05 | b | Sigue siendo útil para hacer humo en hardware chico, siempre que se acote por capacidad. |
| D-06 | b | La corrida del Anexo F (2026-10-29) ya es evidencia; con dos REF se resuelve. |
| D-07 | a | Es el cambio mínimo que agrega Fundamentos sin reordenar todo el libro. |
| D-08 | a | El nombre describe el contenido real (arquitectura más SDK). |
| D-09 | a | Se alinea con el perfil, y «Decisión» aporta lo propio de la guía. |
| D-10 | a | Una tabla corta le da al lector la trazabilidad mínima; el detalle va a la bitácora. |
| D-11 | d | Elige un criterio por sección, con una forma útil y ejecutable (objetivo, comando, salida y enlace). |
| D-12 | c | Hay que medir antes de fijar el tope; un número a priori puede forzar recortes dañinos. |
| D-13 | c | Es coherente con D-07a: los fundamentos van antes del marco. |
| D-14 | b | Tiene el respaldo de dos propuestas; queda en un punto medio, sin inflar el capítulo. |
| D-15 | a | Es un criterio y no un principio; así no se multiplican los principios. |
| D-16 | b | Es un tope compatible con ocho principios, con ejemplos. |
| D-17 | b | El Conocimiento debe ser autocontenido (regla del prompt), y citar sólo por Id no alcanza. |
| D-18 | a | Reusa una forma probada; la divergencia queda declarada. |
| D-19 | b | Es condicional al dictamen de N-10, así que no se trabaja de más. |
| D-20 | c | Incluye contexto (1) y decisiones (9), que la especificación necesita. |
| D-21 | b | Un mínimo exigible hace que la especificación sea aplicable a otros casos. |
| D-22 | a | El prefijo por documento sigue la trazabilidad entre la guía, Geometría y el caso privado. |
| D-23 | c | Un checklist binario con un agente sin la guía prueba la autocontención de forma verificable. |
| D-24 | a | Sólo se documentan los riesgos que se activan, así que tiene menos volumen y más pertinencia. |
| D-25 | a | Es un tope concreto; el mapa de carga sirve a los agentes. |
| D-26 | c | Acota la pasada; V3 y V4 quedan para después del piloto. |
| D-27 | b | No se promete un Example sin implementación (no inventar). |
| D-28 | a | Ofrece una sola promesa verificable con la infraestructura real. |
| D-29 | b | Una rc sin N-04 cerrado sería una señal falsa de madurez. |
| D-30 | a | El PO lo fijó así; renombrarlo rompe sus referencias. Se le eleva sólo como duda. |
