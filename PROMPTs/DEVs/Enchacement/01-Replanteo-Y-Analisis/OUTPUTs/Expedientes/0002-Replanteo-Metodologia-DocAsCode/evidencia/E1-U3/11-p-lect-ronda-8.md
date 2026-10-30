# E1-U3 — P-LECT, ronda 8 (2026-10-27)

Lector nuevo sobre el README del commit cf83441 (consigna de la ronda 3).

Resultado: 30 preguntas; 24 respondidas, 0 con respuesta no alcanzada, 6 huecos. El lector ubica tres (7, 11, 12) dentro de lo
declarado fuera de alcance en §8; los otros tres (ancla principal con dos declara, «Paso 1 de 3», divergencia leve en la ayuda)
se respondieron en 73871cc, que además amplía §8 a «qué cuenta como una regla» en los bordes.

## Preguntas registradas por el lector (texto recortado del informe)

1. **Pregunta:** qué cuenta como una regla (¿el mínimo y el máximo del nombre son una o dos? ¿el entero y el rango de la edad? ¿obligatoria y de la lista?)
   - **Dónde:** README §5.2, «Qué cuenta como una regla»
   - **Clase:** respondida
   - **Cómo:** una ficha por campo, con los caminos como filas de anclas. Salen tres fichas.
2. **Pregunta:** qué ID de área y qué número usar
   - **Dónde:** §5.1 (ejemplo `RN-ENC-01`), §5.2, §8
   - **Clase:** respondida
   - **Cómo:** `RN-ENC-01` a `03`, provisionales.
3. **Pregunta:** qué `doc_id` llevan la página y las fichas
   - **Dónde:** §5.3, comentario del frontmatter
   - **Clase:** respondida
   - **Cómo:** ayuda DEMO-MU-22; fichas DEMO-MU-13 a 15.
4. **Pregunta:** forma de la ficha (frontmatter, encabezado, versión, tablas)
   - **Dónde:** §5.2 y RN-LOC-02
   - **Clase:** respondida
   - **Cómo:** copié el modelo.
5. **Pregunta:** si el «nombre y apellido» del rótulo y del mensaje frente a una validación de 3 caracteres es divergencia
   - **Dónde:** §5.2, Valores cerrados, ¿Divergen?
   - **Clase:** respondida
   - **Cómo:** es el ejemplo de «Leve».
6. **Pregunta:** qué hacer con el máximo 80 que la letra no nombra
   - **Dónde:** §5.2, Silencio; §5.3, «Qué límites nombra la página»
   - **Clase:** respondida
   - **Cómo:** va como dato debajo de la tabla y la ayuda dice «hasta 80».
7. **Pregunta:** qué Momento lleva una regla con una parte comprobada al avanzar y otra que sólo impone el campo
   - **Dónde:** §5.2, Momento; §8
   - **Clase:** hueco (§8 lo declara fuera de alcance)
   - **Cómo:** puse los dos momentos y lo anoté como supuesto 1.
8. **Pregunta:** cuál es el ancla principal cuando hay dos `declara`
   - **Dónde:** §5.2, campo Ancla
   - **Clase:** hueco
   - **Cómo:** elegí el mínimo, supuesto 2.
9. **Pregunta:** qué Dueño lleva una regla que no declara ninguna clase del dominio
   - **Dónde:** §5.2, campo Dueño
   - **Clase:** respondida
   - **Cómo:** «ninguno en el dominio», termina en `ValidarPaso`, sin fila `declara`.
10. **Pregunta:** cómo se clasifica una regla que se comprueba al avanzar pero no al registrar
    - **Dónde:** §5.2, Momento
    - **Clase:** respondida
    - **Cómo:** Momento del acto donde se comprueba; «De fondo», porque se puede guardar la localidad vacía.
11. **Pregunta:** a qué ficha va un hueco que viene de un mecanismo de toda la pantalla (Registrar valida sólo el paso vigente)
    - **Dónde:** §5.2
    - **Clase:** hueco
    - **Cómo:** a RN-ENC-03, supuesto 3.
12. **Pregunta:** qué Grado de certeza poner cuando la regla está anclada y su hueco tiene un paso sin ancla
    - **Dónde:** §5.2, Grado de certeza; §8
    - **Clase:** hueco
    - **Cómo:** puse los dos, supuesto 4.
13. **Pregunta:** cómo anclar mensajes armados con valores interpolados
    - **Dónde:** §5.2, «Mensajes interpolados»
    - **Clase:** respondida
    - **Cómo:** `contiene` con las llaves, y los números con `=` sobre sus constantes.
14. **Pregunta:** si se puede anclar un atributo XAML con binding (`ItemsSource`) y por qué nombre
    - **Dónde:** §5.2, tabla de símbolos
    - **Clase:** respondida
    - **Cómo:** «cualquier atributo», con el elemento nombrado por `AutomationId` (`localidad`).
15. **Pregunta:** qué Rol usar para la conversión a entero y para las filas del hueco
    - **Dónde:** §5.2, Rol
    - **Clase:** respondida
    - **Cómo:** «se puede usar otro»: `convierte` y `hueco`.
16. **Pregunta:** si `contiene` sirve sobre métodos de una clase con constructor primario
    - **Dónde:** §5.2, tabla de símbolos y `contiene`
    - **Clase:** respondida
    - **Cómo:** el límite es para los parámetros como símbolo. `contiene` mira el texto de la declaración del método.
17. **Pregunta:** dónde está el código y qué es `$TRABAJO`
    - **Dónde:** §5.2, «Tabla de anclas»
    - **Clase:** respondida
    - **Cómo:** `TRABAJO=$TRABAJO`.
18. **Pregunta:** qué hacer con la regla de toda la app de que cada sesión ve sólo sus datos
    - **Dónde:** §5.2
    - **Clase:** respondida
    - **Cómo:** sin ficha; va en «Antes de empezar».
19. **Pregunta:** si los nombres de localidad repetidos en el selector son divergencia
    - **Dónde:** §5.2, último párrafo
    - **Clase:** respondida
    - **Cómo:** no lo son; van como dato debajo de la tabla.
20. **Pregunta:** cómo tratar el aviso general «Complete los datos del paso…»
    - **Dónde:** §5.3, «Qué tiene que estar en una ficha»
    - **Clase:** respondida
    - **Cómo:** se cita sin ficha y sin ancla.
21. **Pregunta:** qué hacer con la jerga «ABM» de la letra
    - **Dónde:** §5.3, «Qué divergencias cuenta la página»
    - **Clase:** respondida
    - **Cómo:** se cita textual y se explica.
22. **Pregunta:** cómo se llama la sección de errores si el paso no guarda
    - **Dónde:** §5.3
    - **Clase:** respondida
    - **Cómo:** «Si la app no te deja seguir».
23. **Pregunta:** si «Paso 1 de 3» (de `TotalDePasos`) necesita ficha
    - **Dónde:** §5.3, «Qué tiene que estar en una ficha»
    - **Clase:** hueco
    - **Cómo:** lo traté como rótulo, supuesto 5.
24. **Pregunta:** si la ayuda cuenta una divergencia leve
    - **Dónde:** §5.3, «Qué divergencias cuenta la página» (sólo habla de las de fondo)
    - **Clase:** hueco
    - **Cómo:** una frase en la tabla, supuesto 6.
25. **Pregunta:** cómo se escribe la fila de arquitectura para una regla sin dueño y qué Estado lleva
    - **Dónde:** §5.5
    - **Clase:** respondida
    - **Cómo:** «ninguno en el dominio» en Declara; Estado con los tres valores dados.
26. **Pregunta:** si sumar fuentes a RD-03, que ya está decidida, la reabre
    - **Dónde:** §5.5
    - **Clase:** respondida
    - **Cómo:** no la reabre.
27. **Pregunta:** qué hacer en el CHANGELOG si ya hay una entrada con la misma fecha
    - **Dónde:** §5.5
    - **Clase:** respondida
    - **Cómo:** entrada nueva arriba con título propio.
28. **Pregunta:** qué no se toca y cuándo cambian `last_review` y `description`
    - **Dónde:** §5.5, último párrafo
    - **Clase:** respondida
    - **Cómo:** el README conserva su `traces`; arquitectura ajusta su `description`.
29. **Pregunta:** qué lleva el cuerpo del PR
    - **Dónde:** §5.5 y §5.6
    - **Clase:** respondida
    - **Cómo:** pantalla, piezas, divergencias, supuestos y salidas.
30. **Pregunta:** si la compuerta reconoce los IDs `RN-ENC-nn` nuevos para que las trazas resuelvan
    - **Dónde:** README de docs-guard §4 (PR-5 y «Trazas a otro sistema»), enlazado desde §5.4
    - **Clase:** respondida
    - **Cómo:** el registro toma los encabezados que empiezan con un ID; por eso el encabezado tiene la forma `# RN-ENC-nn — …`.

### Conteo

| Clase | Cantidad |
| --- | --- |
| Respondida | 24 |
| Con respuesta no alcanzada | 0 |
| Hueco | 6 |
| **Total** | **30** |

**Huecos (seis):**
- 7: Momento mixto de una regla.
- 8: ancla principal cuando hay dos `declara`.
- 11: ficha a la que va un hueco común a toda la pantalla.
- 12: Grado de certeza mixto.
- 23: si «Paso 1 de 3» lleva ficha.
- 24: si la ayuda cuenta una divergencia leve.

Los huecos 7, 11 y 12 caen en lo que §8 declara fuera de alcance, y los seis quedaron como supuestos en el PR.

**Dudas con respuesta no alcanzada:** ninguna.
