# E1-U3 — P-LECT, ronda 7 (2026-10-27)

Lector nuevo sobre el README del commit 2bb4712 (consigna de la ronda 3).

Resultado: 29 preguntas; 26 respondidas, 0 con respuesta no alcanzada, 3 huecos. Dos (11, grado de certeza con el motor de base
de datos; 17, si los homónimos son regla o dato) caen en la clasificación fina declarada fuera de alcance en §8. El 18 (si
«contiene» incluye los comentarios ///) es de la herramienta: se respondió en cf83441, con el enlace a docs-guard desde §5.4.

## Preguntas registradas por el lector (texto recortado del informe)

1. - Pregunta: qué número y qué columnas lleva la fila del RRD.
   - Dónde: README §5.1
   - Clase: respondida
   - Cómo la resolví: RD-05, con las ocho columnas.
2. - Pregunta: qué va en Decisión y en «Decide y fecha».
   - Dónde: §5.1
   - Clase: respondida
   - Cómo la resolví: `pendiente` y `PO, pendiente`.
3. - Pregunta: qué cuenta como una regla, para saber cuántas fichas escribir.
   - Dónde: §5.2 «Qué cuenta como una regla»
   - Clase: respondida
   - Cómo la resolví: una ficha por campo, tres en total.
4. - Pregunta: si la regla «cada sesión ve sólo sus datos» lleva ficha.
   - Dónde: §5.2
   - Clase: respondida
   - Cómo la resolví: no lleva; va en «Antes de empezar».
5. - Pregunta: qué `doc_id` llevan las fichas.
   - Dónde: §5.3, comentario del yaml («fichas 1x»)
   - Clase: respondida
   - Cómo la resolví: 13 a 15. El dato está una sección después de §5.2, que es donde se escriben las fichas.
6. - Pregunta: qué prefijo de área usar (`ENC`).
   - Dónde: ejemplos de §5.1 y §5.3
   - Clase: respondida
7. - Pregunta: si «Nombre y apellido» en el rótulo y en el mensaje es una divergencia.
   - Dónde: §5.2, valores cerrados de «¿Divergen?» y campo «Letra»
   - Clase: respondida
   - Cómo la resolví: leve.
8. - Pregunta: qué hacer con el máximo de 80, que la pantalla no nombra.
   - Dónde: §5.2 «Silencio» y §5.3 «Qué límites nombra»
   - Clase: respondida
9. - Pregunta: cómo clasificar una regla que se valida al avanzar y no al registrar.
   - Dónde: §5.2, Momento
   - Clase: respondida
   - Cómo la resolví: Precondition de pasar al paso 2, divergencia de fondo.
10. - Pregunta: Dueño y ancla principal cuando no hay `declara`.
    - Dónde: §5.2, campos «Dueño» y «Ancla»
    - Clase: respondida
11. - Pregunta: qué grado de certeza corresponde cuando un paso depende del motor de base de datos y no tiene ancla.
    - Dónde: §5.2 «Grado de certeza», §8 y §5.6
    - Clase: hueco (el texto da el procedimiento, no el valor)
    - Cómo la resolví: «Código» por analogía con RN-LOC-01, anotado como supuesto 1.
12. - Pregunta: qué rol poner a los lugares que arman el hueco.
    - Dónde: §5.2, columna Rol («se puede usar otro»)
    - Clase: respondida
13. - Pregunta: qué formas de símbolo entiende la compuerta (`[RelayCommand]` asíncrono, `.xaml.cs`, `AutomationId`).
    - Dónde: §5.2, tabla de archivos
    - Clase: respondida
    - Cómo la resolví: supuse que `override async void` y una lambda dentro de un método también entran.
14. - Pregunta: si un atributo XAML con valor `{Binding …}` se puede afirmar con `=`.
    - Dónde: §5.2 («cualquier atributo; texto»)
    - Clase: respondida
15. - Pregunta: cómo anclar mensajes interpolados.
    - Dónde: §5.2 «Mensajes interpolados»
    - Clase: respondida
16. - Pregunta: si «entero» es parte de la regla de la edad y dónde se ancla.
    - Dónde: §5.2 (ejemplo de la edad)
    - Clase: respondida en el qué; el dónde lo elegí por analogía (`ToModel`).
17. - Pregunta: si los nombres de localidad repetidos son una regla de estructura, un dato o nada.
    - Dónde: §5.2 (especie «estructura» y «dato que no es divergencia»)
    - Clase: hueco
    - Cómo la resolví: dato debajo de la tabla, anotado como supuesto 2.
18. - Pregunta: si la «declaración completa» que mira `contiene` incluye el comentario `///` (lo quería para anclar la Intención).
    - Dónde: §5.2, columna Afirma
    - Clase: hueco
    - Cómo la resolví: no lo anclé.
19. - Pregunta: qué hacer con el aviso general «Complete los datos del paso…».
    - Dónde: §5.3
    - Clase: respondida
    - Cómo la resolví: se cita sin ficha.
20. - Pregunta: qué hacer con la jerga «ABM» de la letra.
    - Dónde: §5.3
    - Clase: respondida
21. - Pregunta: cómo se llama la sección de errores en un paso que no guarda.
    - Dónde: §5.3
    - Clase: respondida
22. - Pregunta: si la página cuenta la divergencia de la localidad, que pasa por otra pestaña.
    - Dónde: §5.3 «Qué divergencias cuenta»
    - Clase: respondida
23. - Pregunta: qué comprueba el control `estructura` (por ejemplo, si exige índice).
    - Dónde: §5.4 no lo dice; lo dice `tools/docs-guard/README.md`, enlazado desde §1
    - Clase: respondida
    - Cómo la resolví: fui al enlace por mi cuenta (markdownlint y mermaid); §5.4 no lo enlaza.
24. - Pregunta: qué valor tiene `$TRABAJO`.
    - Dónde: §5.2, tabla de anclas
    - Clase: respondida
25. - Pregunta: qué fecha usar en el CHANGELOG cuando ya hay una entrada de ese día.
    - Dónde: §5.5
    - Clase: respondida
26. - Pregunta: qué cambia en `arquitectura.md` y en RD-03, y si la fila RD-03 se reabre.
    - Dónde: §5.5
    - Clase: respondida
27. - Pregunta: qué no se toca (RD-04, el `traces` del README, `last_review`, `description`).
    - Dónde: §5.2 y §5.5
    - Clase: respondida
28. - Pregunta: qué lleva el cuerpo del PR.
    - Dónde: §5.5
    - Clase: respondida
29. - Pregunta: qué propuesta escribir para la divergencia de fondo sin decidirla.
    - Dónde: §5.2 y §7
    - Clase: respondida

### Conteo por clase

| Clase | Cantidad |
| --- | --- |
| respondida | 26 |
| con respuesta no alcanzada | 0 |
| hueco | 3 |
| **Total** | **29** |

**Huecos:**
- (11) Qué grado de certeza corresponde cuando un paso depende del motor de base de datos.
- (17) Si los nombres de localidad repetidos son una regla de estructura con ficha o un dato.
- (18) Si la afirmación `contiene` incluye los comentarios de documentación del símbolo.

**Con respuesta no alcanzada:** ninguna. La que más se acercó es la (23): la respuesta existe en el README de docs-guard, pero el tutorial no lleva a ella desde §5.4; la encontré por el enlace de §1.
