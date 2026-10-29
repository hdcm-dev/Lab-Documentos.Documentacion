# E1-U3 — P-LECT, ronda 9 y resumen (2026-10-27)

Lector nuevo sobre el README del commit 73871cc (consigna de la ronda 3).

Resultado: 34 preguntas; 30 respondidas, 0 con respuesta no alcanzada, 4 huecos: #10 dentro de lo declarado fuera de alcance
(§8, según el propio lector); #32 (si origin/main ya trae la demo) es un artefacto de leer antes del merge; #19 (homónimos) y #26
(requisitos previos de la pantalla) se respondieron en c8b3183 sin otra ronda.

## Resumen de las nueve rondas

| Ronda | README | Preguntas | Respondidas | No alcanzadas | Huecos |
| --- | --- | --- | --- | --- | --- |
| 1 | 8c75722 | 30 | 15 | 1 | 14 |
| 2 | 44d2119 | 25 | 17 | 1 | 7 |
| 3 | d841992 | 24 | 17 | 0 | 7 |
| 4 | 26e61fd | 36 | 25 | 0 | 11 |
| 5 | 8fc8b8d | 27 | 22 | 0 | 5 |
| 6 | a32c89b | 28 | 22 | 0 | 6 |
| 7 | 2bb4712 | 29 | 26 | 0 | 3 |
| 8 | cf83441 | 30 | 24 | 0 | 6 (3 dentro de §8) |
| 9 | 73871cc | 34 | 30 | 0 | 4 (1 dentro de §8, 1 artefacto, 2 respondidos después) |

Lectura: la navegación quedó resuelta desde la ronda 3 (0 con respuesta no alcanzada en siete rondas seguidas). Los huecos
no convergen a 0 porque cada lector nuevo abre bordes distintos del método de clasificación de reglas; por eso §8 los declara
fuera de alcance y §5.6 los canaliza como supuestos del PR (F012 §6, fila E1). El cero estricto sobre el texto final no se
midió: queda para la P-LECT de la compuerta E1-G (G-e), que lee el tutorial junto con la guía (LD-17).

## Preguntas registradas por el lector de la ronda 9 (texto recortado del informe)

1. **Pregunta:** qué número y qué columnas lleva la fila nueva del RRD.
   - **Dónde:** README §5.1.
   - **Clase:** respondida.
   - **Cómo la resolví:** RD-05, con las ocho columnas.
2. **Pregunta:** qué poner en Decisión y en «Decide y fecha».
   - **Dónde:** README §5.1.
   - **Clase:** respondida.
   - **Cómo la resolví:** `pendiente` y `PO, pendiente`.
3. **Pregunta:** qué cuenta como una regla (el mínimo y el máximo del nombre; la localidad obligatoria y de la lista).
   - **Dónde:** README §5.2, «Qué cuenta como una regla».
   - **Clase:** respondida.
   - **Cómo la resolví:** una ficha por campo, tres en total.
4. **Pregunta:** si «Paso 1 de 3», los títulos y los botones llevan ficha.
   - **Dónde:** README §5.2.
   - **Clase:** respondida.
   - **Cómo la resolví:** no llevan.
5. **Pregunta:** qué hacer con la regla de sesión («sólo tus localidades»).
   - **Dónde:** README §5.2, con enlace a alta-de-localidad §1.
   - **Clase:** respondida.
   - **Cómo la resolví:** la puse en «Antes de empezar».
6. **Pregunta:** qué área usar en el ID y qué `doc_id` dar a las fichas.
   - **Dónde:** README §5.1, ejemplo `RN-ENC`, y §5.3, «fichas 1x».
   - **Clase:** respondida.
   - **Cómo la resolví:** RN-ENC-01 a 03 y DEMO-MU-13 a 15.
7. **Pregunta:** cuáles son los campos de la ficha, en qué orden y con qué valores cerrados.
   - **Dónde:** README §5.2, tablas de campos y de valores cerrados.
   - **Clase:** respondida.
   - **Cómo la resolví:** los seguí tal cual.
8. **Pregunta:** qué Dueño y qué ancla principal poner si ninguna clase del dominio declara la regla (la localidad).
   - **Dónde:** README §5.2, filas Dueño y Ancla.
   - **Clase:** respondida.
   - **Cómo la resolví:** «Ninguno en el dominio» y, como ancla principal, la primera fila `verifica`.
9. **Pregunta:** qué Momento y qué divergencia corresponden a una regla que se valida al avanzar pero no al registrar.
   - **Dónde:** README §5.2, valores cerrados de Momento.
   - **Clase:** respondida.
   - **Cómo la resolví:** Precondition de pasar al paso 2, y «De fondo».
10. **Pregunta:** qué Momento corresponde a una regla con una parte verificada y otra sólo impuesta por el campo (el nombre).
    - **Dónde:** README §5.2 y §8, que lo declara fuera de alcance.
    - **Clase:** hueco.
    - **Cómo la resolví:** por analogía con RN-LOC-01; quedó como supuesto 1.
11. **Pregunta:** si «Nombre y apellido» cuando alcanza una palabra es una divergencia.
    - **Dónde:** README §5.2, «¿Divergen?».
    - **Clase:** respondida.
    - **Cómo la resolví:** es leve; es justamente el ejemplo del texto.
12. **Pregunta:** qué hacer con un máximo (80) que la letra no nombra.
    - **Dónde:** README §5.2, «Silencio», y §5.3, «Qué límites nombra».
    - **Clase:** respondida.
    - **Cómo la resolví:** lo dejé como dato debajo de la tabla, y la ayuda dice «hasta 80».
13. **Pregunta:** cómo anclar los mensajes interpolados.
    - **Dónde:** README §5.2, «Mensajes interpolados».
    - **Clase:** respondida.
    - **Cómo la resolví:** con `contiene`, copiando el texto con las llaves.
14. **Pregunta:** cómo anclar en `.xaml` un elemento sin `x:Name`.
    - **Dónde:** README §5.2, tabla de símbolos.
    - **Clase:** respondida.
    - **Cómo la resolví:** por `AutomationId` (`nombre`, `edad`, `localidad`).
15. **Pregunta:** si se pueden anclar miembros de una clase con constructor primario.
    - **Dónde:** README §5.2, «No entiende parámetros de constructores primarios».
    - **Clase:** respondida.
    - **Cómo la resolví:** entendí que los miembros sí se pueden anclar; lo marqué como riesgo a revisar.
16. **Pregunta:** cómo anclar una ausencia (que el servicio no revalida, que la columna no es obligatoria).
    - **Dónde:** README §5.2, `no contiene`.
    - **Clase:** respondida.
    - **Cómo la resolví:** con `no contiene`.
17. **Pregunta:** qué rol usar para los lugares del hueco (recarga, singleton, registro).
    - **Dónde:** README §5.2, «se puede usar otro».
    - **Clase:** respondida.
    - **Cómo la resolví:** con roles propios.
18. **Pregunta:** qué grado de certeza dar cuando la cadena no se ejecutó.
    - **Dónde:** README §5.2, «código … aunque no se haya ejecutado».
    - **Clase:** respondida.
    - **Cómo la resolví:** anclé cada paso y puse «código».
19. **Pregunta:** si un par de localidades con el mismo nombre en distintas provincias (la encuesta guarda sólo el nombre) es divergencia o dato.
    - **Dónde:** README §5.2, «¿Divergen?»; no encaja ni en Leve ni en De fondo.
    - **Clase:** hueco.
    - **Cómo la resolví:** lo traté como dato; supuesto 4.
20. **Pregunta:** dónde está `$TRABAJO/sha` y si se le agrega `/mini-demo-movilidad` cuando la variable está definida.
    - **Dónde:** README §5.2, «Tabla de anclas».
    - **Clase:** respondida.
    - **Cómo la resolví:** leí que el sufijo va sólo con los valores por defecto, y la ruta dada lo confirma.
21. **Pregunta:** si el mensaje general «Complete los datos del paso…» lleva ficha.
    - **Dónde:** README §5.3, «Qué tiene que estar en una ficha».
    - **Clase:** respondida.
    - **Cómo la resolví:** lo cité sin ficha y sin ancla.
22. **Pregunta:** si la página cuenta la divergencia leve.
    - **Dónde:** README §5.3, «Qué divergencias cuenta».
    - **Clase:** respondida.
    - **Cómo la resolví:** el criterio está («si la persona la va a notar»); aplicarlo fue un juicio mío, supuesto 5.
23. **Pregunta:** si la página del paso 1 cuenta una divergencia de fondo que se manifiesta al registrar, en el paso 3.
    - **Dónde:** README §5.3, «un paso que deja avanzar sin un dato».
    - **Clase:** respondida.
    - **Cómo la resolví:** sí, la cuenta en lenguaje llano.
24. **Pregunta:** cómo tratar la jerga «ABM» de la letra.
    - **Dónde:** README §5.3.
    - **Clase:** respondida.
    - **Cómo la resolví:** la cité textual y la expliqué.
25. **Pregunta:** cómo se llama la sección de errores si la pantalla no guarda, y si se trata de vos o de usted.
    - **Dónde:** README §5.3.
    - **Clase:** respondida.
    - **Cómo la resolví:** «Si la app no te deja seguir», y de vos.
26. **Pregunta:** qué hacer si la lista de localidades está vacía.
    - **Dónde:** README §5.3 (estructura del cuerpo).
    - **Clase:** hueco.
    - **Cómo la resolví:** lo puse en «Antes de empezar», por analogía; supuesto 6.
27. **Pregunta:** cómo resuelve la compuerta las trazas `RN-ENC-nn@1.0` (prefijo externo).
    - **Dónde:** README §5.2 (línea de Versión) y README de docs-guard §4 (PR-5, encabezados con un ID).
    - **Clase:** respondida.
    - **Cómo la resolví:** con el encabezado `# RN-ENC-nn —` y la línea Versión.
28. **Pregunta:** cómo validar y qué salida esperar.
    - **Dónde:** README §5.4 y §4.
    - **Clase:** respondida.
    - **Cómo la resolví:** con los tres comandos de la sección 2.
29. **Pregunta:** qué cambiar en `arquitectura.md` y en RD-03, y si eso reabre RD-03.
    - **Dónde:** README §5.5.
    - **Clase:** respondida.
    - **Cómo la resolví:** filas nuevas, `traces` y Fuente; no la reabre.
30. **Pregunta:** si cambia RD-04.
    - **Dónde:** README §5.2.
    - **Clase:** respondida.
    - **Cómo la resolví:** no cambia.
31. **Pregunta:** qué fecha poner en el CHANGELOG y en `last_review`, y si se ajustan las `description`.
    - **Dónde:** README §5.5.
    - **Clase:** respondida.
    - **Cómo la resolví:** la del PR (hoy), entrada aparte; ajusté sólo la `description` de `arquitectura.md`.
32. **Pregunta:** si `origin/main` ya contiene la demo, porque el `git switch` parte de ahí.
    - **Dónde:** README §5.5.
    - **Clase:** hueco.
    - **Cómo la resolví:** supuse que sí; supuesto 8.
33. **Pregunta:** qué lleva el cuerpo del PR.
    - **Dónde:** README §5.5 y §5.6.
    - **Clase:** respondida.
    - **Cómo la resolví:** seguí la lista del texto.
34. **Pregunta:** qué poner en «Quién la verifica hoy» cuando la regla del dominio la invoca el servicio (las fichas modelo difieren).
    - **Dónde:** README §5.2 y las fichas RN-LOC.
    - **Clase:** respondida.
    - **Cómo la resolví:** «el método que la comprueba»; puse los dos.

## Conteo

| Clase | Cantidad |
| --- | --- |
| respondida | 30 |
| con respuesta no alcanzada | 0 |
| hueco | 4 |
| **Total** | 34 |

## Huecos

- **#10:** Momento de una regla con una parte verificada en un acto y otra impuesta sólo por el campo. §8 lo declara fuera de alcance y lo manda a §5.6.
- **#19:** si las localidades homónimas en provincias distintas (la encuesta guarda sólo el nombre) son divergencia o dato.
- **#26:** dónde dice la ayuda que hacen falta localidades cargadas, o qué pasa si la lista está vacía.
- **#32:** si la rama base `origin/main` ya contiene la demo.

## Dudas con respuesta no alcanzada

Ninguna.
