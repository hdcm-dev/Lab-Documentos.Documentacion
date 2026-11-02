# Voto del jurado: costo-beneficio

Mesa del Prompt 02 de la guía 16. Voto a ciegas sobre los ítems de `02-Consolidado.md`. Elijo una opción por id. Criterio: el menor costo de hacerlo y de mantenerlo que todavía resuelve el problema y deja evidencia que se pueda verificar.

| Id | Opción | Fundamento |
|----|--------|------------|
| D-01 | a | Quitar la cifra y remitir a `contar.sh` cuesta cero de mantenimiento. Una cifra recalculada vuelve a quedar vieja en el próximo cambio, y una compuerta nueva es costo sin beneficio proporcional. |
| D-02 | a | Con texto alcanza para declarar la excepción. Un ADR más una prueba de arquitectura agregan piezas que hay que mantener, y no hay código que se mueva. |
| D-03 | b | El grep es barato y evita romper la compilación de Examples. Si el grep da riesgo, se declara la divergencia. |
| D-04 | c | 4 de 5 corridas es barato de ejecutar con el turno del gestor. Si falla, la mesa decide sin degradar el camino en silencio. 20 llamadas o un IC 95 % cuestan más turno de modelo que lo que aportan. |
| D-05 | b | Reclasificar las menciones es más barato que reescribir. Además el modelo sigue sirviendo para el humo y el chat simple. |
| D-06 | b | La corrida del Anexo F ya existe y es reciente. Repetir el ensayo duplica el costo sin información nueva. |
| D-07 | a | Es el cambio mínimo sobre la estructura vigente. Renumerar todo en capítulos o reordenar (A2) multiplica enlaces rotos y el trabajo de revisión. |
| D-08 | a | Es el nombre fiel al contenido actual, que combina arquitectura y SDK, y no obliga a mover secciones. |
| D-09 | a | Reutiliza el patrón del perfil y le agrega un solo paso. Mapear el patrón actual a las seis subsecciones obliga a retocar cada tema. |
| D-10 | a | Una tabla corta da trazabilidad al lector a costo bajo, y el detalle queda en la bitácora. |
| D-11 | d | El criterio es estable (secciones fijas) y no depende de contar líneas. El README queda útil: objetivo, comando, salida y enlace. |
| D-12 | a | Es un tope que se verifica ya y que impide crecer. Llegar a 44.330 exige recortes caros antes de medirlos. La opción c posterga y suma otra ronda. |
| D-13 | c | Es coherente con D-07 a, sin costo extra de encaje. |
| D-14 | d | Seis principios cuestan menos de redactar y de justificar con evidencia. Se pueden ampliar si la mesa encuentra un hueco. |
| D-15 | a | Como criterio dentro de otro principio no agrega un principio que haya que sostener. |
| D-16 | b | 1.500 palabras alcanzan para seis principios con ejemplo y entran en el tope de D-12. |
| D-17 | b | El Conocimiento tiene que ser autocontenido. Reproducir la lista condensada evita idas y vueltas a la guía, a cambio de un costo de sincronización bajo. |
| D-18 | a | Reutiliza una forma ya probada (MAUI). Declarar la divergencia es barato. |
| D-19 | b | Se registra sólo si N-10 dictamina que Rule-Forma rige en Lab-Documentos, así que no hay trabajo especulativo. |
| D-20 | b | Seis secciones cubren el contexto, los bloques, los conceptos, las decisiones, la calidad y los riesgos. La 1 y la 6 suman poco para una capa de IA. |
| D-21 | b | Un mínimo más una ADR por capacidad agéntica escala con el caso. Exigir todas encarece cada especificación. |
| D-22 | b | Un solo esquema de Id es más simple de buscar y de validar. |
| D-23 | c | Un checklist binario es barato de aplicar y reproducible. El agente sin la guía prueba la autocontención. |
| D-24 | a | Limita las fichas a los riesgos que el nivel de agencia activa. Se paga sólo por lo que aplica. |
| D-25 | a | 600 líneas es un tope concreto y verificable. Un 15 % de la guía depende de una base móvil. |
| D-26 | c | Hacer sólo V2 después del piloto acota esta pasada. V3 y V4 quedan para cuando haya evidencia del piloto. |
| D-27 | b | El Example 18 se hace sólo si el caso se implementa, así no se mantiene código sin uso. |
| D-28 | a | Un solo Ollama es lo que hay. Prometer dos papeles crea una deuda de verificación. |
| D-29 | b | Seguir en 0.x hasta cerrar N-04. Declarar un rc antes de esa ronda invita a un rc.2 y a más ciclos. |
| D-30 | a | Respetar lo que fijó el PO no cuesta nada. Renombrar toca enlaces y requiere su decisión. |
