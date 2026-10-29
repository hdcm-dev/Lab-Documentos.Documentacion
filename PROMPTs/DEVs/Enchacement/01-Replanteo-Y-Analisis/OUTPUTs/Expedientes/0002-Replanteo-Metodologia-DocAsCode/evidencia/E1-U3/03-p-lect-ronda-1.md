# E1-U3 — P-LECT, ronda 1 (2026-10-27)

Lector: un agente sin contexto (claude -p, sesión nueva), sólo con Read/Glob/Grep, sin Bash ni escritura. Entrada: README de la
mini demo. Consigna de E1 (F012 §6): documentar una pantalla nueva (Encuesta, paso 1) y proponerla por PR simulado. Código del SHA
dado como carpeta de sólo lectura ($TRABAJO/sha). Consigna completa:

```text
Sos un lector sin contexto previo (prueba de lectura P-LECT). No podés hacer preguntas a nadie.
Entrada: el archivo Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Examples/MovilidadUrbana-Mini-Demo/README.md de este repositorio (directorio actual).
Consigna real: documentar una pantalla nueva de la mini demo (la pantalla «Encuesta», paso 1, para la persona usuaria) y proponerla por un PR simulado.
El código del SHA ya fue bajado con «verificar.sh fuente» y está en $TRABAJO/sha/ (sólo lectura).
No podés escribir archivos ni correr comandos: describí qué archivos crearías o cambiarías, con su contenido completo (frontmatter incluido), qué comandos correrías para validar y qué pondrías en el PR.
Leé sólo lo que el README y los enlaces que él da te lleven a leer, más el código del SHA.
Registrá CADA duda que tuviste mientras seguías el tutorial, con esta forma:
  - Duda: <qué no supiste>
  - Dónde: <archivo y sección>
  - Clase: «respondida» (el texto la responde y la encontraste), «con respuesta no alcanzada» (el texto la responde pero no te llevó a ella) o «hueco» (el texto no la responde)
  - Cómo la resolviste o qué supusiste
Al final, una tabla de conteo por clase y la lista de huecos y de dudas con respuesta no alcanzada. Respondé en español.
```

Resultado: 30 dudas; 15 respondidas, 1 con respuesta no alcanzada, 14 huecos. Umbral (cero dudas sin respuesta): NO cumple.
Acción: el README se corrigió (commit 44d2119) y se corrió una ronda 2 con un lector nuevo.

Comprobación adicional: las tres fichas (RN-ENC-01..03, 21 anclas), la página y la fila RD-05 que propuso el lector se copiaron a una
copia de la demo y se corrieron dg.py trazas --fuente $TRABAJO/sha y dg.py esquema: «trazas=27 resueltas=27 anclas=31
anclas-resueltas=31» y «PR-2 esquema: verde». El tutorial se puede operar sin el autor.

## Dudas registradas por el lector (texto recortado del informe)

1. **Duda:** ¿una ficha para todo el paso 1 o una por regla? El ejemplo traza sólo `RN-ENC-01@1.0`.
   - **Dónde:** README §5.1 y §5.2.
   - **Clase:** respondida.
   - **Cómo la resolví:** §5.2 dice «cada una lleva su ficha». Hice tres.
2. **Duda:** §5.1 nombra seis columnas obligatorias, pero el ejemplo tiene ocho (Fuente y «Decide y fecha»).
   - **Dónde:** README §5.1.
   - **Clase:** respondida.
   - **Cómo la resolví:** con la tabla real de `_requisitos.md` §2. Puse las ocho.
3. **Duda:** qué va en «Decide y fecha» si la fila está en `pendiente`. El ejemplo dice «PO, fecha».
   - **Dónde:** README §5.1; `_requisitos.md` §1.
   - **Clase:** hueco.
   - **Qué supuse:** «mesa, sin decidir (propuesta 2026-10-27)», porque §1 del RRD dice que decide la mesa.
4. **Duda:** ¿la Pieza va como texto o como enlace?
   - **Dónde:** README §5.1.
   - **Clase:** respondida.
   - **Cómo la resolví:** las filas del RRD usan enlace; lo copié.
5. **Duda:** ¿hay que agregar las fichas nuevas al `traces` del frontmatter del RRD? Hoy traza RN-LOC-01 y 02.
   - **Dónde:** `_requisitos.md`, frontmatter.
   - **Clase:** hueco.
   - **Qué supuse:** que sí, por analogía.
6. **Duda:** qué valores admiten los campos de la ficha (Especie, Momento, Grado de certeza).
   - **Dónde:** README §1 y §5.2; RN-LOC-01 §1. Remiten a *Deducción de reglas de negocio* §5.1, sin enlace.
   - **Clase:** con respuesta no alcanzada.
   - **Qué supuse:** copié los valores de las fichas modelo.
7. **Duda:** ¿la afirmación se escribe `= 16` (como en el README) o `` = `16` `` (como en la ficha)?
   - **Dónde:** README §5.2.
   - **Clase:** respondida.
   - **Cómo la resolví:** RN-LOC-01 §2 y el §4 del README de docs-guard usan la forma con comillas invertidas.
8. **Duda:** ¿«contiene» mira sólo la firma o también el cuerpo del método o la propiedad?
   - **Dónde:** README §5.2.
   - **Clase:** respondida.
   - **Cómo la resolví:** las anclas de RN-LOC-01 y 02 buscan textos que están en el cuerpo.
9. **Duda:** dónde queda el código bajado. El README dice `/tmp/mini-demo-movilidad`, pero el código está en otra carpeta.
   - **Dónde:** README §5.2.
   - **Clase:** respondida.
   - **Cómo la resolví:** con `verificar.sh`: usa `$TRABAJO` o, si no está, `$RUNNER_TEMP`, `$TMPDIR` o `/tmp`. El README simplifica.
10. **Duda:** ¿cómo valido contra el árbol ya bajado sin volver a bajarlo?
    - **Dónde:** README §5.4.
    - **Clase:** respondida.
    - **Cómo la resolví:** con la línea de C3 en `verificar.sh` (enlazado en §2).
11. **Duda:** ¿hay que registrar el prefijo `RN-ENC`?
    - **Dónde:** README §5.4 (error `prefijo`).
    - **Clase:** respondida.
    - **Cómo la resolví:** el README de docs-guard dice que `RN-` es un prefijo externo.
12. **Duda:** ¿el lector de anclas entiende `.xaml.cs`, los constructores primarios y los métodos con `[RelayCommand]`?
    - **Dónde:** README §5.2, tabla de formas de ancla.
    - **Clase:** hueco.
    - **Qué supuse:** que sí. No usé `.xaml.cs`; `EncuestaViewModel.LoadAsync` y `ToModel` quedan como riesgo si C3 da `ancla-sin-simbolo`.
13. **Duda:** ¿se puede afirmar un valor que no es número en `.xaml` (por ejemplo, `Keyboard = Numeric`)?
    - **Dónde:** README §5.2.
    - **Clase:** hueco.
    - **Qué supuse:** nada; lo evité.
14. **Duda:** qué alcanza «cada número que la página nombra»: ¿también los ejemplos (34) y la cantidad de pasos?
    - **Dónde:** README §5.3.
    - **Clase:** hueco.
    - **Qué supuse:** que sólo los límites de las reglas, porque la ayuda modelo usa 3450 y 89959 sin ficha. No escribí la cantidad de pasos.
15. **Duda:** el máximo de 80 no se valida en el servicio. ¿Es una divergencia?
    - **Dónde:** README §5.2 y §7.
    - **Clase:** respondida.
    - **Cómo la resolví:** sólo hay divergencia si el código difiere de lo que la pantalla promete, y la pantalla no promete un máximo. Marqué «No».
16. **Duda:** cómo registrar un dato que no es divergencia (la localidad guardada sólo por nombre).
    - **Dónde:** RN-LOC-02 §1.
    - **Clase:** respondida.
    - **Cómo la resolví:** RN-LOC-02 lo hace con un párrafo debajo de la tabla; usé la misma forma.
17. **Duda:** ¿dejo los comentarios `#` del frontmatter de ejemplo?
    - **Dónde:** README §5.3.
    - **Clase:** hueco.
    - **Qué supuse:** que no; los quité, como en la página modelo.
18. **Duda:** cómo titular y acotar una página que cubre un solo paso. El ejemplo dice «Completar la encuesta».
    - **Dónde:** README §5.1 y §5.3.
    - **Clase:** hueco.
    - **Qué supuse:** «(paso 1)» en el título y en la tarea de RD-05.
19. **Duda:** la sección «qué hacer si la app no guarda» no aplica, porque en el paso 1 no se guarda nada.
    - **Dónde:** README §5.3.
    - **Clase:** hueco.
    - **Qué supuse:** la adapté como «Si la app no te deja seguir».
20. **Duda:** ¿hay que actualizar el inventario del §2 del README?
    - **Dónde:** README §2 y §5.
    - **Clase:** hueco.
    - **Qué supuse:** que sí.
21. **Duda:** ¿hay que tocar el CHANGELOG?
    - **Dónde:** README §5.5.
    - **Clase:** hueco.
    - **Qué supuse:** que no.
22. **Duda:** cómo nombrar la rama y el mensaje del commit.
    - **Dónde:** README §5.5.
    - **Clase:** hueco.
    - **Qué supuse:** imité el estilo de los commits recientes del repositorio.
23. **Duda:** cómo es «el final» de la salida de `ci-local.sh`. El README sólo muestra el de `verificar.sh`.
    - **Dónde:** README §4 y §5.5.
    - **Clase:** hueco.
    - **Qué supuse:** dejé un lugar marcado para pegarlo.
24. **Duda:** ¿a qué fila trazan las fichas nuevas: RD-04 o RD-05?
    - **Dónde:** README §5.2.
    - **Clase:** respondida.
    - **Cómo la resolví:** las fichas modelo trazan RD-04, y la pieza de RD-04 es el anexo de fichas.
25. **Duda:** qué `doc_id` les toca a las fichas.
    - **Dónde:** README §5.3.
    - **Clase:** respondida.
    - **Cómo la resolví:** el comentario dice que las fichas van en 1x; las libres son 13, 14 y 15.
26. **Duda:** ¿«persona usuaria» o `persona-usuaria`?
    - **Dónde:** README §5.1 y §5.3.
    - **Clase:** respondida.
    - **Cómo la resolví:** con espacio en el RRD y con guion en el frontmatter.
27. **Duda:** ¿la ayuda va con vos o con usted? La app usa usted.
    - **Dónde:** README §5.3.
    - **Clase:** respondida.
    - **Cómo la resolví:** la página modelo usa vos.
28. **Duda:** el aviso general «Complete los datos del paso…» no tiene números. ¿Necesita ancla?
    - **Dónde:** README §5.3 frente a la regla de §7.
    - **Clase:** hueco.
    - **Qué supuse:** lo cité en la página sin ancla.
29. **Duda:** ¿los roles de ancla (declara, muestra, verifica, aplica, persiste) son una lista cerrada?
    - **Dónde:** README §5.2; README de docs-guard §4.
    - **Clase:** hueco.
    - **Qué supuse:** usé sólo los que aparecen en las fichas modelo.
30. **Duda:** ¿los IDs `RN-ENC-nn` los puedo inventar yo?
    - **Dónde:** README §5.1.
    - **Clase:** respondida.
    - **Cómo la resolví:** §8 dice que los IDs son provisionales y los asigna la demo.

### Conteo

| Clase | Cantidad |
| --- | --- |
| Respondida | 15 |
| Con respuesta no alcanzada | 1 |
| Hueco | 14 |
| **Total** | **30** |

**Con respuesta no alcanzada**
- 6: los valores de los campos de la ficha. El texto cita *Deducción de reglas de negocio* §5.1, pero no la enlaza.

**Huecos**
- 3: qué va en «Decide y fecha» si la fila está en `pendiente`.
- 5: si hay que agregar las fichas nuevas al `traces` del RRD.
- 12: qué construcciones de C# entiende el lector de anclas.
- 13: si se puede afirmar un valor que no es número en `.xaml`.
- 14: qué alcanza «cada número que la página nombra».
- 17: si se dejan los comentarios del frontmatter de ejemplo.
- 18: cómo acotar una página que cubre un solo paso.
- 19: «si la app no guarda» en un paso donde no se guarda nada.
- 20: si hay que actualizar el inventario del §2.
- 21: si hay que tocar el CHANGELOG.
- 22: cómo nombrar la rama y el commit.
- 23: cómo es el final de la salida de `ci-local.sh`.
- 28: si un mensaje sin números necesita ancla.
- 29: si la lista de roles de ancla es cerrada.

Además, una imprecisión del README que no frenó el trabajo: §5.2 da `/tmp/mini-demo-movilidad` como carpeta de trabajo, pero el script la elige de otra forma (duda 9).
