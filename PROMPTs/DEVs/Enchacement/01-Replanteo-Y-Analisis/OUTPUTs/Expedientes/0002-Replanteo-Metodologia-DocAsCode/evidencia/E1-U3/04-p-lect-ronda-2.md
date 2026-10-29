# E1-U3 — P-LECT, ronda 2 (2026-10-27)

Lector nuevo (otra sesión sin contexto, mismas restricciones y misma consigna que la ronda 1) sobre el README del commit 44d2119.

Resultado: 25 dudas; 17 respondidas, 1 con respuesta no alcanzada, 7 huecos. Umbral: NO cumple (8 sin respuesta, contra 15 de la ronda 1).
Acción: README corregido (commit d841992) y ronda 3 con otro lector nuevo.

## Dudas registradas por el lector (texto recortado del informe)

1. **Duda:** si había que documentar el proyecto MAUI o la ApiWeb, porque las dos tienen `EncuestaRules`.
   - Dónde: README §5.2, tabla de anclas.
   - Clase: respondida.
   - Cómo la resolví: los ejemplos de ruta son de `src/MovilidadUrbana.MAUI/` y la pantalla es de la app móvil.

2. **Duda:** dónde estaba el código del SHA.
   - Dónde: README §5.2.
   - Clase: respondida.
   - Cómo la resolví: en `$TRABAJO/sha/`.

3. **Duda:** qué valor usar en `TRABAJO` para no volver a bajar el código a `/tmp`.
   - Dónde: README §5.2.
   - Clase: respondida.
   - Cómo la resolví: se exporta `TRABAJO` con la carpeta de la consigna, sin `/mini-demo-movilidad`, porque el subdirectorio `sha/` ya cuelga de ella.

4. **Duda:** qué área usar en el ID de las reglas.
   - Dónde: README §5.2.
   - Clase: respondida.
   - Cómo la resolví: el ejemplo de §5.1 usa `RN-ENC-01` y `RN-ENC-02`.

5. **Duda:** qué reglas del paso 1 llevan ficha. La localidad es obligatoria y tiene que ser una de las cargadas, pero no tiene número.
   - Dónde: README §5.2 («un mínimo, un rango, un formato, una unicidad») y §5.3 («qué tiene que estar en una ficha»).
   - Clase: hueco.
   - Qué supuse: sin número no hay ficha (la obligatoriedad y la pertenencia a una lista no figuran en esa enumeración), y el mensaje se cita textual. Coincide con las dos fichas del ejemplo de §5.1.

6. **Duda:** con qué criterio una divergencia es «Leve» y no «De fondo». §5.2 dice que si el código diverge de lo que la pantalla promete hay que marcar «De fondo», pero la lista incluye «Leve».
   - Dónde: README §5.2, tabla de valores y párrafo final.
   - Clase: hueco.
   - Qué supuse: «Leve» para «nombre y apellido» contra una sola palabra (no hay número en juego y no cambia qué se guarda), sin propuesta.

7. **Duda:** si la ayuda tenía que nombrar el máximo de 80, que la pantalla no promete.
   - Dónde: README §5.3.
   - Clase: hueco.
   - Qué supuse: sí, porque es lo que el código hace (regla de §7). Por eso el 80 también va anclado en RN-ENC-01.

8. **Duda:** cómo anclar un mensaje interpolado. En el código no está el texto «… entre 16 y 110 años.», sino `{EncuestaRules.EdadMinima}`.
   - Dónde: README §5.3 («la ficha de esa regla ya lo ancla en su fila `verifica`»).
   - Clase: hueco.
   - Qué supuse: anclar con `contiene` el fragmento literal del mensaje y los números con `=` sobre las constantes.

9. **Duda:** qué número de `doc_id` usar para la página y para las fichas.
   - Dónde: README §5.3, comentario del frontmatter.
   - Clase: respondida.
   - Cómo la resolví: ayuda `DEMO-MU-22`; fichas `DEMO-MU-13` y `14` (las existentes son 11 y 12).

10. **Duda:** qué frontmatter y qué campos lleva una ficha.
    - Dónde: README §5.2.
    - Clase: respondida.
    - Cómo la resolví: copiando RN-LOC-02, como indica el README.

11. **Duda:** qué exige la forma de *Deducción de reglas de negocio* §5.1 en los campos abiertos (Intención, Prueba, Dueño, Depende de).
    - Dónde: README §1 y §5.2.
    - Clase: con respuesta no alcanzada.
    - Cómo la resolví: el README cita ese documento pero no da enlace ni ruta. Me guié por las fichas modelo.

12. **Duda:** si podía usar un rol que no está en la lista, como `convierte` para `int.TryParse`.
    - Dónde: README §5.2.
    - Clase: respondida.
    - Cómo la resolví: el README dice que se puede usar otro rol.

13. **Duda:** si un `.xaml` sin `x:Name` se puede anclar.
    - Dónde: README §5.2.
    - Clase: respondida.
    - Cómo la resolví: vale el `AutomationId` (`nombre`, `edad`).

14. **Duda:** si en el RRD «Dado/Cuando/Entonces» tienen que ir con mayúscula.
    - Dónde: README §5.1.
    - Clase: respondida.
    - Cómo la resolví: el ejemplo y las filas existentes los escriben en minúscula.

15. **Duda:** qué poner en Decisión y en Decide y fecha.
    - Dónde: README §5.1.
    - Clase: respondida.
    - Cómo la resolví: `pendiente` y `PO, pendiente`.

16. **Duda:** qué cambiar en el frontmatter del RRD.
    - Dónde: README §5.1.
    - Clase: respondida.
    - Cómo la resolví: agregar las fichas nuevas con su versión a `traces`.

17. **Duda:** si la fila RD-04 (Pieza: anexo de fichas) cambia al sumar fichas.
    - Dónde: README §5.2 y RRD §2.
    - Clase: hueco.
    - Qué supuse: no cambia, porque apunta a la carpeta `docs/fichas/` y las fichas trazan a RD-04.

18. **Duda:** si la página tiene que trazar RN-LOC-*, ya que enlaza a la ayuda de alta de localidad.
    - Dónde: README §1 (definición de Traza).
    - Clase: respondida.
    - Cómo la resolví: no, porque la página no afirma ningún número de esas reglas.

19. **Duda:** cómo se llama la sección de errores en un paso que no guarda.
    - Dónde: README §5.3.
    - Clase: respondida.
    - Cómo la resolví: «Si la app no te deja seguir».

20. **Duda:** si una página puede cubrir sólo un paso de la pantalla.
    - Dónde: README §5.3.
    - Clase: respondida.
    - Cómo la resolví: sí, siempre que el título y la tarea lo digan.

21. **Duda:** qué trato usar en la ayuda, porque la app trata de usted.
    - Dónde: README §5.3.
    - Clase: respondida.
    - Cómo la resolví: la ayuda trata de vos.

22. **Duda:** qué valor de «Momento» usar en una validación por paso.
    - Dónde: README §5.2.
    - Clase: respondida.
    - Cómo la resolví: «Precondition de ‹acto›», con el acto «pasar al paso 2».

23. **Duda:** en qué entrada del CHANGELOG va la línea. Hay varias del 2026-10-27, y la de la mini demo pertenece a otra unidad (E1-U3).
    - Dónde: README §5.5.
    - Clase: hueco.
    - Qué supuse: en la entrada «2026-10-27 (mini demo MovilidadUrbana)», bajo «Añadido».

24. **Duda:** cómo correr sólo C3 (las anclas) sin compilar la ApiWeb ni tener .NET, ya que el código estaba bajado.
    - Dónde: README §4 y §5.4.
    - Clase: hueco.
    - Cómo la resolví: el README sólo da `verificar.sh`, que con `todo` vuelve a bajar y compila. Saqué el comando `dg.py trazas` de la línea 140 de `verificar.sh`.

25. **Duda:** si había que actualizar `docs/tecnica/arquitectura.md` (RD-03, «dónde vive cada regla») con las reglas nuevas.
    - Dónde: README §5.5.
    - Clase: hueco.
    - Qué supuse: no hace falta para la tarea de la persona usuaria. Lo dejé dicho en el PR.

## 5. Conteo

| Clase | Cantidad |
| --- | --- |
| respondida | 17 |
| con respuesta no alcanzada | 1 |
| hueco | 7 |
| **Total** | **25** |

**Huecos (7):**
- 5: qué reglas sin número llevan ficha (obligatoriedad, pertenencia a una lista).
- 6: el criterio entre «Leve» y «De fondo».
- 7: si la ayuda nombra un límite que la pantalla no promete.
- 8: cómo anclar mensajes interpolados.
- 17: si cambia la fila RD-04 al sumar fichas.
- 23: en qué entrada del CHANGELOG va la línea cuando hay varias del mismo día.
- 24: cómo correr sólo el control C3 con el código ya bajado.
- 25: si `arquitectura.md` (RD-03) tiene que sumar las reglas nuevas.

**Con respuesta no alcanzada (1):**
- 11: la forma de *Deducción de reglas de negocio* §5.1 se cita sin enlace ni ruta.
