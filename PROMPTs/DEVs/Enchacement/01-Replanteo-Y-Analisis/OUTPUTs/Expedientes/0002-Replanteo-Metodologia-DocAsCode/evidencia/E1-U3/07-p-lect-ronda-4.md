# E1-U3 — P-LECT, ronda 4 (2026-10-27)

Lector nuevo sobre el README del commit 26e61fd (consigna de la ronda 3).

Resultado: 36 preguntas; 25 respondidas, 0 con respuesta no alcanzada, 11 huecos. Umbral: NO cumple. Los huecos son casos de borde
nuevos (reglas sin dueño ni verificación, propuesta con divergencia leve, qué no se toca, cuerpo del PR). README corregido
(8fc8b8d), que además suma §5.6, la regla para los casos que el tutorial no prevé (LD-15).

## Preguntas registradas por el lector (texto recortado del informe)

1. **Pregunta:** Qué número lleva la fila nueva del RRD.
   - **Dónde:** README §5.1
   - **Clase:** respondida
   - **Cómo la resolví:** «el número siguiente»: RD-05.

2. **Pregunta:** Qué columnas lleva la fila y cuáles exige la compuerta.
   - **Dónde:** README §5.1
   - **Clase:** respondida
   - **Cómo la resolví:** las ocho columnas; la compuerta exige seis.

3. **Pregunta:** Qué decisión y qué «Decide y fecha» pongo.
   - **Dónde:** README §5.1
   - **Clase:** respondida
   - **Cómo la resolví:** `pendiente` y `PO, pendiente`.

4. **Pregunta:** Cuántas fichas lleva el paso 1. El ejemplo del RRD trae dos y el de CHANGELOG, tres.
   - **Dónde:** README §5.1, §5.2 y §5.5
   - **Clase:** respondida
   - **Cómo la resolví:** el criterio de §5.2 («cada regla… obligatorio o de una lista») me llevó a cuatro. Los ejemplos se contradicen entre sí y con ese criterio; los tomé como ilustración.

5. **Pregunta:** Si un rango (mínimo y máximo) es una ficha o dos.
   - **Dónde:** README §5.2
   - **Clase:** respondida
   - **Cómo la resolví:** «un rango» aparece como una regla, y RN-LOC-01 sirve de modelo: una ficha.

6. **Pregunta:** Qué `doc_id` llevan las fichas y la página.
   - **Dónde:** README §5.3 (comentario del frontmatter)
   - **Clase:** respondida
   - **Cómo la resolví:** fichas 1x → 13 a 16; ayuda 2x → 22. Lo confirmé buscando los `doc_id` existentes.

7. **Pregunta:** Qué forma tiene la ficha: frontmatter, encabezado, versión.
   - **Dónde:** README §5.2, con RN-LOC-02 como modelo
   - **Clase:** respondida
   - **Cómo la resolví:** copié el modelo.

8. **Pregunta:** Qué valores admiten Divergen, Especie, Momento y Grado de certeza.
   - **Dónde:** README §5.2, «Valores cerrados»
   - **Clase:** respondida
   - **Cómo la resolví:** usé los valores de esa tabla.

9. **Pregunta:** Si el rótulo «Nombre y apellido» contra una sola palabra válida es una divergencia.
   - **Dónde:** README §5.2, ¿Divergen?
   - **Clase:** respondida
   - **Cómo la resolví:** el texto trae ese mismo ejemplo como «Leve».

10. **Pregunta:** Qué hago con el máximo de 80, que la letra no nombra.
    - **Dónde:** README §5.2 (Silencio) y §5.3
    - **Clase:** respondida
    - **Cómo la resolví:** lo puse como dato debajo de la tabla y la ayuda dice «hasta 80».

11. **Pregunta:** Quién es el dueño cuando ninguna clase del dominio declara la regla.
    - **Dónde:** README §5.2, campo Dueño
    - **Clase:** respondida
    - **Cómo la resolví:** «ninguno en el dominio», sin fila `declara`.

12. **Pregunta:** Dónde «termina» una regla cuando ninguna clase la declara y nadie la verifica (RN-ENC-04).
    - **Dónde:** README §5.2, campo Dueño
    - **Clase:** hueco
    - **Qué supuse:** el texto sólo prevé «la clase que la verifica». Puse el selector de la página y `LoadAsync`.

13. **Pregunta:** Qué Momento lleva una regla que la pantalla impone sin comprobarla en ningún acto.
    - **Dónde:** README §5.2, Momento
    - **Clase:** hueco
    - **Qué supuse:** «ninguno», con la explicación.

14. **Pregunta:** Si una regla que se comprueba al avanzar y se puede saltear al registrar es una divergencia de fondo, y si su Momento cambia.
    - **Dónde:** README §5.2, ¿Divergen? y Momento
    - **Clase:** hueco
    - **Qué supuse:** el mensaje es letra que promete obligatoriedad y lo guardado cambia → «De fondo», con propuesta y sin decidirla.

15. **Pregunta:** Cuál es «el ancla principal».
    - **Dónde:** README §5.2, campo Ancla
    - **Clase:** hueco
    - **Qué supuse:** la declaración; si no hay, la verificación o lo que aplica.

16. **Pregunta:** Qué escribo en Propuesta cuando la divergencia es leve y no quiero proponer nada.
    - **Dónde:** README §5.2, Propuesta
    - **Clase:** hueco (menor)
    - **Qué supuse:** escribí una propuesta opcional y la dejé para el dueño.

17. **Pregunta:** Dónde está el código del SHA y qué vale `TRABAJO`.
    - **Dónde:** README §5.2
    - **Clase:** respondida
    - **Cómo la resolví:** `TRABAJO=$TRABAJO`, también dado en la consigna.

18. **Pregunta:** Cómo anclar un atributo XAML y cómo afirmar el valor `Numeric`.
    - **Dónde:** README §5.2, tabla de anclas
    - **Clase:** respondida
    - **Cómo la resolví:** `edad.Keyboard` por `AutomationId`.

19. **Pregunta:** Si `= {Binding Localidades}` (un valor con llaves) se compara bien.
    - **Dónde:** README §5.2
    - **Clase:** respondida
    - **Cómo la resolví:** «el valor se compara como texto». No lo pude comprobar.

20. **Pregunta:** Cómo afirmar los mensajes interpolados.
    - **Dónde:** README §5.2, «Mensajes interpolados»
    - **Clase:** respondida
    - **Cómo la resolví:** copié el texto con las llaves y anclé los números con `=`.

21. **Pregunta:** Si se puede anclar un método de una clase con constructor primario (`EncuestaViewModel`) o un método con `[RelayCommand]`.
    - **Dónde:** README §5.2, tabla de anclas
    - **Clase:** respondida
    - **Cómo la resolví:** la restricción vale para los parámetros, no para los miembros; los atributos se entienden.

22. **Pregunta:** Si puedo usar un rol que no está en la lista (`registra`).
    - **Dónde:** README §5.2
    - **Clase:** respondida
    - **Cómo la resolví:** «se puede usar otro».

23. **Pregunta:** Dónde va un dato que no es divergencia.
    - **Dónde:** README §5.2
    - **Clase:** respondida
    - **Cómo la resolví:** en un párrafo debajo de la tabla.

24. **Pregunta:** Qué frontmatter y qué secciones lleva la página, y cómo se llama la sección de errores en un paso intermedio.
    - **Dónde:** README §5.3
    - **Clase:** respondida
    - **Cómo la resolví:** «Si la app no te deja seguir».

25. **Pregunta:** Qué hago con el mensaje general «Complete los datos del paso…».
    - **Dónde:** README §5.3
    - **Clase:** respondida
    - **Cómo la resolví:** lo cito sin ficha y sin ancla.

26. **Pregunta:** Si una página puede cubrir sólo una parte de la pantalla.
    - **Dónde:** README §5.3
    - **Clase:** respondida
    - **Cómo la resolví:** sí; el título y la tarea lo dicen.

27. **Pregunta:** Si tengo que tocar `verificar.sh` o el workflow para que C3 lea las fichas nuevas.
    - **Dónde:** README §5.4 y §5.5
    - **Clase:** hueco
    - **Qué supuse:** la lista de §5.5 no los nombra; supuse que no hace falta.

28. **Pregunta:** Qué hay que actualizar además de las piezas nuevas.
    - **Dónde:** README §5.5
    - **Clase:** respondida
    - **Cómo la resolví:** README §2, arquitectura §3 y su `traces`, Fuente de RD-03, CHANGELOG.

29. **Pregunta:** Si sumar fuentes a RD-03 lo reabre.
    - **Dónde:** README §5.5
    - **Clase:** respondida
    - **Cómo la resolví:** no.

30. **Pregunta:** Si se actualiza la `description` de `arquitectura.md`, que dice «reglas de localidades».
    - **Dónde:** README §5.5
    - **Clase:** hueco
    - **Qué supuse:** sí, sin tocar la tarea ni el criterio de RD-03.

31. **Pregunta:** Si el `traces` del README (RD-01 a RD-04) suma RD-05.
    - **Dónde:** README §5.5
    - **Clase:** hueco
    - **Qué supuse:** no lo toqué, porque §5.5 sólo pide filas en §2.

32. **Pregunta:** Si se actualiza `last_review` en los archivos modificados.
    - **Dónde:** README §5.5
    - **Clase:** hueco
    - **Qué supuse:** sin efecto en este caso: ya dicen 2026-10-27.

33. **Pregunta:** Qué fecha lleva el CHANGELOG (el ejemplo dice 28).
    - **Dónde:** README §5.5
    - **Clase:** respondida
    - **Cómo la resolví:** «la del día del PR»: 2026-10-27, en una entrada propia.

34. **Pregunta:** Cómo se llama la rama, qué dice el commit y contra qué va el PR.
    - **Dónde:** README §5.5
    - **Clase:** respondida
    - **Cómo la resolví:** `demo-mu/encuesta-paso-1`, «Mini demo: ayuda del paso 1 de la encuesta», contra `main`.

35. **Pregunta:** Qué lleva el cuerpo del PR además de las salidas.
    - **Dónde:** README §5.5
    - **Clase:** hueco (menor)
    - **Qué supuse:** un resumen y las divergencias para decidir.

36. **Pregunta:** De dónde sale `$DEMO` en §5.4.
    - **Dónde:** README §5.4 → §4
    - **Clase:** respondida
    - **Cómo la resolví:** está definido en §4.

### Conteo

| Clase | Cantidad |
| --- | --- |
| respondida | 25 |
| con respuesta no alcanzada | 0 |
| hueco | 11 |
| **Total** | **36** |

**Huecos:**
- 12: dónde termina una regla que nadie declara ni verifica.
- 13: qué Momento lleva una regla que la pantalla impone sin comprobarla.
- 14: si una regla que se puede saltear al registrar es divergencia de fondo y si cambia su Momento.
- 15: cuál es el ancla principal.
- 16: qué va en Propuesta con una divergencia leve.
- 27: si hay que tocar `verificar.sh` o el workflow.
- 30: si se actualiza la `description` de arquitectura.
- 31: si el `traces` del README suma RD-05.
- 32: si se actualiza `last_review`.
- 35: qué más lleva el cuerpo del PR.

Además, aunque no es un hueco, conviene alinear los ejemplos del tutorial (pregunta 4): dos fichas en el RRD, tres en CHANGELOG.

**Con respuesta no alcanzada:** ninguna. No abrí `tools/docs-guard/README.md`, que §1 enlaza, porque ningún paso me mandó a leerlo. Si ahí se responde alguno de los huecos (por ejemplo, el 27), pasaría a esta clase.
