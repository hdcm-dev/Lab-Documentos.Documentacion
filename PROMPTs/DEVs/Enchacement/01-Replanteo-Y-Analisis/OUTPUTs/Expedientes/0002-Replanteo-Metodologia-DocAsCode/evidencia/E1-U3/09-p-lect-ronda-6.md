# E1-U3 — P-LECT, ronda 6 (2026-10-27)

Lector nuevo sobre el README del commit a32c89b (consigna de la ronda 3).

Resultado: 28 preguntas; 22 respondidas, 0 con respuesta no alcanzada, 6 huecos. Las rondas 3 a 6 dan 0 con respuesta no
alcanzada; los huecos se estancan entre 5 y 11 porque cada lector abre bordes nuevos del método de clasificación de reglas.
Acción (LD-16): se responden los simples y §8 del README declara fuera de alcance la clasificación fina de una regla, que se
resuelve por §5.6 como supuesto en el PR. El criterio de E1 de F012 §6 admite huecos «declarados fuera de alcance en el cuerpo
». README en 2bb4712.

## Preguntas registradas por el lector (texto recortado del informe)

1. **Pregunta:** Dónde está el código para escribir las anclas y qué vale `TRABAJO`.
   - **Dónde:** README §5.2, «Tabla de anclas».
   - **Clase:** respondida.
   - **Cómo la resolví:** `$TRABAJO/sha/`, con `TRABAJO=…/cache-u3/trabajo`.
2. **Pregunta:** Cuántas fichas lleva el paso 1. El ejemplo de §5.1 nombra sólo RN-ENC-01 y 02.
   - **Dónde:** §5.1 (fila de ejemplo) y §5.2.
   - **Clase:** respondida.
   - **Cómo la resolví:** §5.2 pide ficha también para «obligatorio» y «de una lista». Por eso agregué RN-ENC-03.
3. **Pregunta:** ¿El mínimo y el máximo del nombre son una regla, si no «se comprueban juntos» (el máximo no lo comprueba nadie)?
   - **Dónde:** §5.2, «Qué cuenta como una regla».
   - **Clase:** hueco.
   - **Cómo la resolví:** una ficha, por analogía con RN-LOC-01 (supuesto 1).
4. **Pregunta:** «Obligatoria» y «de la lista» en el mismo campo, si una la comprueba el servicio y la otra la impone el selector: ¿una ficha o dos?
   - **Dónde:** §5.2, «Qué cuenta como una regla».
   - **Clase:** hueco.
   - **Cómo la resolví:** una ficha (supuesto 2).
5. **Pregunta:** ¿Lleva ficha que las localidades sean las de la sesión?
   - **Dónde:** §5.2.
   - **Clase:** respondida.
   - **Cómo la resolví:** no lleva ficha y va en «Antes de empezar».
6. **Pregunta:** En el campo Letra, ¿va el texto con las llaves del código o el que se ve en pantalla?
   - **Dónde:** §5.2, campos y «Mensajes interpolados».
   - **Clase:** respondida.
   - **Cómo la resolví:** la Letra es lo que la app promete, o sea el texto que se ve. Las llaves van sólo en las anclas `contiene`.
7. **Pregunta:** ¿«Nombre y apellido» en el rótulo y en el mensaje es una divergencia?
   - **Dónde:** §5.2, valores cerrados.
   - **Clase:** respondida.
   - **Cómo la resolví:** es leve. El texto usa ese mismo ejemplo.
8. **Pregunta:** El máximo de 80 que la letra no nombra.
   - **Dónde:** §5.2 («Silencio») y §5.3.
   - **Clase:** respondida.
   - **Cómo la resolví:** va como dato debajo de la tabla y la ayuda dice «hasta 80».
9. **Pregunta:** Se valida al avanzar y no al registrar: ¿qué Momento y qué grado de divergencia?
   - **Dónde:** §5.2, Momento.
   - **Clase:** respondida.
   - **Cómo la resolví:** Momento «Precondition de pasar al paso 2». Leve en 01 y 02, de fondo en 03 (la localidad sí se puede guardar vacía).
10. **Pregunta:** Ancla principal y Dueño cuando la regla no tiene clase en el dominio.
    - **Dónde:** §5.2, tabla de campos.
    - **Clase:** respondida.
    - **Cómo la resolví:** la ancla principal es la de `verifica`. Dueño: «ninguno en el dominio», y termina en `EncuestaService`.
11. **Pregunta:** Intención sin respaldo en el código.
    - **Dónde:** §5.2.
    - **Clase:** respondida.
    - **Cómo la resolví:** «Conjetura» en RN-ENC-02.
12. **Pregunta:** ¿Qué grado de certeza corresponde a una conclusión sacada de leer el flujo sin ejecutarlo: «código» o «inferencia»?
    - **Dónde:** §5.2, valores cerrados (los valores no se definen).
    - **Clase:** hueco.
    - **Cómo la resolví:** «Código» (supuesto 4).
13. **Pregunta:** Qué forma de símbolo entiende la compuerta para métodos con `[RelayCommand]` en una clase con constructor primario, y para XAML por `AutomationId`.
    - **Dónde:** §5.2, tabla de archivos.
    - **Clase:** respondida.
14. **Pregunta:** ¿Sirve `=` con un valor que tiene llaves (`{Binding Localidades}`)?
    - **Dónde:** §5.2 («cualquier atributo, como texto»).
    - **Clase:** respondida.
    - **Cómo la resolví:** supuse que se compara como texto literal.
15. **Pregunta:** Qué rol usar para las anclas que muestran el hueco.
    - **Dónde:** §5.2, columna Rol.
    - **Clase:** respondida.
    - **Cómo la resolví:** la compuerta no lee el rol y se puede usar otro. Usé roles nuevos (supuesto 8).
16. **Pregunta:** Qué `doc_id` llevan las fichas y la página.
    - **Dónde:** §5.3.
    - **Clase:** respondida.
    - **Cómo la resolví:** 13, 14, 15 y 22.
17. **Pregunta:** Cómo citar para la persona usuaria una letra con jerga («ABM»).
    - **Dónde:** §5.3.
    - **Clase:** hueco.
    - **Cómo la resolví:** la cité textual y la aclaré (supuesto 6).
18. **Pregunta:** ¿La ayuda cuenta una divergencia de fondo que no es «límite contra promesa» sino un hueco de validación?
    - **Dónde:** §5.3, «Qué límites nombra la página».
    - **Clase:** hueco.
    - **Cómo la resolví:** la conté por analogía con alta §3 (supuesto 5).
19. **Pregunta:** Qué hacer con el aviso general «Complete los datos del paso antes de continuar.»
    - **Dónde:** §5.3.
    - **Clase:** respondida.
    - **Cómo la resolví:** se cita sin ficha.
20. **Pregunta:** Cómo se llama la sección de errores en un paso intermedio.
    - **Dónde:** §5.3.
    - **Clase:** respondida.
    - **Cómo la resolví:** «Si la app no te deja seguir».
21. **Pregunta:** Qué poner en la columna Estado de arquitectura cuando la divergencia es leve.
    - **Dónde:** §5.5.
    - **Clase:** hueco.
    - **Cómo la resolví:** «Divergencia leve» (supuesto 7).
22. **Pregunta:** Qué fecha llevan el CHANGELOG y `last_review`, si el ejemplo dice 2026-10-28.
    - **Dónde:** §5.5.
    - **Clase:** respondida.
    - **Cómo la resolví:** la fecha del día del PR, hoy 2026-10-27.
23. **Pregunta:** ¿Cambian `last_review` y `traces` del README y del RRD?
    - **Dónde:** §5.1 y §5.5.
    - **Clase:** respondida.
24. **Pregunta:** ¿Agregar una fuente a RD-03 la reabre?
    - **Dónde:** §5.5.
    - **Clase:** respondida.
    - **Cómo la resolví:** no la reabre.
25. **Pregunta:** ¿La divergencia de fondo nueva necesita una prueba negativa como C4, o tocar el workflow?
    - **Dónde:** §5.5 («lo que no se toca»).
    - **Clase:** respondida.
    - **Cómo la resolví:** no. C3 lee todas las fichas solo.
26. **Pregunta:** Qué lleva el cuerpo del PR y cómo se abre.
    - **Dónde:** §5.5.
    - **Clase:** respondida.
27. **Pregunta:** «Depende de» en RN-ENC-03: ¿depende de las reglas RN-LOC?
    - **Dónde:** §5.2.
    - **Clase:** respondida.
    - **Cómo la resolví:** «Ninguna». La regla no supone nada de las reglas de localidad.
28. **Pregunta:** ¿El campo Prueba describe lo que la app hace hoy o lo que debería hacer?
    - **Dónde:** §5.2 y la ficha RN-LOC-01.
    - **Clase:** respondida.
    - **Cómo la resolví:** describe lo que debería hacer, como el modelo.

### Conteo

| Clase | Cantidad |
| --- | --- |
| Respondida | 22 |
| Con respuesta no alcanzada | 0 |
| Hueco | 6 |

**Huecos:**
- 3: mínimo y máximo del nombre, comprobados por caminos distintos.
- 4: obligatoria y «de la lista» en el mismo campo.
- 12: «código» o «inferencia» en el grado de certeza.
- 17: letra con jerga en la ayuda.
- 18: divergencia que no es «límite contra promesa» en la ayuda.
- 21: valor de Estado para una divergencia leve.

**Dudas con respuesta no alcanzada:** ninguna.

Una nota sobre la pregunta 2: el texto la responde, pero la fila de ejemplo de §5.1 con dos fichas empuja a dejar afuera la localidad.
