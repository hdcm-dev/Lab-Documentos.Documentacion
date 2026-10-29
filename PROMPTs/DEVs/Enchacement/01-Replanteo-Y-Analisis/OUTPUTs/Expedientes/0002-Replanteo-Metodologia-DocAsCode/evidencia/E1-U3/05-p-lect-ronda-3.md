# E1-U3 — P-LECT, ronda 3 (2026-10-27)

Lector nuevo sobre el README del commit d841992. Los dos primeros intentos con la consigna de las rondas 1 y 2 los cortó la API
(«safeguards flagged», reasoning_extraction) antes de leer nada. Se reformuló sólo la línea de registro: «listá cada pregunta
que el texto del tutorial dejó planteada al seguirlo» en lugar de «registrá cada duda que tuviste». La medida es la misma.

Resultado: 24 preguntas; 17 respondidas, 0 con respuesta no alcanzada, 7 huecos. Umbral: NO cumple. README corregido (26e61fd).

## Preguntas registradas por el lector (texto recortado del informe)

1. **Pregunta:** ¿Qué número y qué columnas lleva la fila nueva del RRD?
   - **Dónde:** README §5.1
   - **Clase:** respondida
   - **Cómo la resolví:** RD-05 y las ocho columnas, como en el ejemplo.

2. **Pregunta:** ¿Qué pongo en «Decisión» y en «Decide y fecha»?
   - **Dónde:** README §5.1
   - **Clase:** respondida
   - **Cómo la resolví:** `pendiente` y `PO, pendiente`.

3. **Pregunta:** ¿Hay que actualizar el frontmatter del RRD?
   - **Dónde:** README §5.1
   - **Clase:** respondida
   - **Cómo la resolví:** sumé las tres fichas, con versión, a `traces`.

4. **Pregunta:** ¿Cuántas fichas van? El ejemplo muestra dos y la pantalla tiene tres reglas.
   - **Dónde:** README §5.1 (ejemplo) y §5.2
   - **Clase:** respondida
   - **Cómo la resolví:** «cada regla lleva su ficha… que un campo sea obligatorio o que su valor tenga que salir de una lista». Van tres; la localidad tiene la suya.

5. **Pregunta:** ¿El mínimo y el máximo de un mismo campo van en una ficha o en dos?
   - **Dónde:** README §5.2
   - **Clase:** respondida
   - **Cómo la resolví:** con el modelo RN-LOC-01, que junta mínimo y máximo. Hice una ficha por campo.

6. **Pregunta:** ¿Qué área y qué `doc_id` llevan las fichas?
   - **Dónde:** README §5.1 (RN-ENC) y §5.3 (comentario «fichas 1x»)
   - **Clase:** respondida
   - **Cómo la resolví:** ENC; con el grep vi que 11 y 12 están ocupados y usé 13, 14 y 15.

7. **Pregunta:** ¿Qué campos lleva la ficha y en qué orden?
   - **Dónde:** README §5.2, «Campos de la ficha»
   - **Clase:** respondida
   - **Cómo la resolví:** la tabla dice «catorce» pero tiene trece filas, porque junta Especie y Momento. Las separé como en RN-LOC-02.

8. **Pregunta:** ¿Qué significan las especies (restricción, derivación, alcance, estructura) y el momento «completitud»?
   - **Dónde:** README §5.2, «Valores cerrados»
   - **Clase:** hueco
   - **Qué supuse:** el texto dice que trae todo lo necesario de la guía de deducción, pero sólo da los valores, no qué significan. Usé «restricción» en las tres, por analogía con las fichas modelo, aunque dudé con «alcance» para la localidad.

9. **Pregunta:** Si la letra no nombra un límite que el código aplica (el máximo de 80), ¿eso es divergencia?
   - **Dónde:** README §5.2 (definición de Leve y De fondo) y §5.3
   - **Clase:** hueco
   - **Qué supuse:** que el silencio no es divergencia. Lo dejé como dato en un párrafo bajo la tabla, y la ayuda dice «hasta 80».

10. **Pregunta:** El rótulo pide «nombre y apellido» pero el código acepta una sola palabra. ¿Es leve o de fondo?
    - **Dónde:** README §5.2, «¿Divergen?»
    - **Clase:** hueco
    - **Qué supuse:** el criterio («cambia qué se acepta») no dice si un rótulo cuenta como promesa. Lo marqué Leve, porque el requisito enunciado bajo el campo coincide con el código, y puse una propuesta opcional.

11. **Pregunta:** ¿Qué va en «Dueño» y en el rol `declara` cuando ninguna clase del dominio declara la regla (la localidad)?
    - **Dónde:** README §5.2 (Dueño: «la clase del dominio que la declara»)
    - **Clase:** hueco
    - **Qué supuse:** puse «Ninguna clase del dominio» y nombré `EncuestaService`. Omití la fila `declara`; el texto sólo dice que los roles no los lee la compuerta.

12. **Pregunta:** ¿Cómo se ancla un atributo de XAML?
    - **Dónde:** README §5.2, tabla de formas
    - **Clase:** respondida
    - **Cómo la resolví:** con el elemento nombrado por `AutomationId`: `nombre`, `edad`, `localidad`.

13. **Pregunta:** ¿Cómo se ancla un mensaje armado con valores?
    - **Dónde:** README §5.2, «Mensajes interpolados»
    - **Clase:** respondida
    - **Cómo la resolví:** `contiene` con el texto copiado tal como está en el código, con las llaves.

14. **Pregunta:** ¿Dónde está el código del SHA (`$TRABAJO`)?
    - **Dónde:** README §5.2
    - **Clase:** respondida
    - **Cómo la resolví:** `TRABAJO=$TRABAJO`.

15. **Pregunta:** ¿Hay que anclar el aviso general «Complete los datos del paso antes de continuar.», que no sale de una sola regla?
    - **Dónde:** README §5.3, «Qué tiene que estar en una ficha»
    - **Clase:** hueco
    - **Qué supuse:** el texto sólo cubre los mensajes que salen de una regla. Lo cité en la página y no lo anclé. Si el código lo cambia, nada da rojo.

16. **Pregunta:** ¿Qué hago con un dato que no es divergencia, como los homónimos en la lista o la limpieza de la elección?
    - **Dónde:** README §5.2
    - **Clase:** respondida
    - **Cómo la resolví:** lo puse en un párrafo bajo la tabla, como en RN-LOC-02.

17. **Pregunta:** ¿Qué estructura lleva la página y cómo se llama la sección de error en un paso que no guarda?
    - **Dónde:** README §5.3
    - **Clase:** respondida
    - **Cómo la resolví:** «Si la app no te deja seguir», con trato de vos.

18. **Pregunta:** ¿Qué límites nombra la ayuda?
    - **Dónde:** README §5.3
    - **Clase:** respondida
    - **Cómo la resolví:** los que aplica el código: 3 y 80; 16 y 110.

19. **Pregunta:** Al sumar filas a la tabla de arquitectura, ¿también se actualizan su `traces` y la columna Fuente de RD-03?
    - **Dónde:** README §5.5
    - **Clase:** hueco
    - **Qué supuse:** que sí, por coherencia con «una regla con versión por cada ficha que la página va a trazar». No sé si cambiar una fila ya «aceptada» obliga a volver a decidirla; lo dejé señalado en el PR.

20. **Pregunta:** ¿Qué subtítulo `###` lleva la entrada del CHANGELOG y con qué fecha?
    - **Dónde:** README §5.5
    - **Clase:** hueco
    - **Qué supuse:** el texto da el título de la entrada y «Añadido», pero no la línea `###` que llevan todas las entradas existentes (expediente y unidad). Puse una línea sin expediente. Usé la fecha de hoy y no la del ejemplo.

21. **Pregunta:** ¿Con qué comandos valido y qué salida espero?
    - **Dónde:** README §5.4 y §4
    - **Clase:** respondida
    - **Cómo la resolví:** los tres comandos y los agregadores en verde.

22. **Pregunta:** ¿Qué rama, qué commit, contra qué rama va el PR y qué va en su cuerpo?
    - **Dónde:** README §5.5
    - **Clase:** respondida
    - **Cómo la resolví:** como dice el texto. Las salidas reales quedan por pegar, porque no pude correr los comandos.

23. **Pregunta:** ¿Qué hago si el criterio del RRD tiene las palabras clave en minúscula?
    - **Dónde:** README §5.1
    - **Clase:** respondida
    - **Cómo la resolví:** seguí el ejemplo, que escribe «cuando» y «entonces» en minúscula.

24. **Pregunta:** Si no hay respaldo de la intención en el código (el porqué de 16 y 110), ¿qué escribo?
    - **Dónde:** README §5.2
    - **Clase:** respondida
    - **Cómo la resolví:** «Conjetura».

## Conteo

| Clase | Cantidad |
| --- | --- |
| Respondida | 17 |
| Con respuesta no alcanzada | 0 |
| Hueco | 7 |
| **Total** | **24** |

**Huecos:**
- 8: qué significan las especies y el momento «completitud».
- 9: si el silencio de la letra sobre un límite cuenta como divergencia.
- 10: si un rótulo («nombre y apellido») cuenta como promesa para decidir entre Leve y De fondo.
- 11: qué va en «Dueño» y en el rol `declara` cuando la regla no está en el dominio.
- 15: si se ancla un mensaje general que no sale de una sola regla.
- 19: si al sumar filas a arquitectura se actualizan su `traces` y la Fuente de RD-03, y si eso obliga a volver a decidir RD-03.
- 20: el subtítulo `###` y la fecha de la entrada del CHANGELOG.

**Dudas con respuesta no alcanzada:** ninguna. El README enlaza el README de docs-guard, que puede detallar los controles de esquema y estructura, pero el tutorial no me mandó a leerlo y no lo necesité para avanzar.
