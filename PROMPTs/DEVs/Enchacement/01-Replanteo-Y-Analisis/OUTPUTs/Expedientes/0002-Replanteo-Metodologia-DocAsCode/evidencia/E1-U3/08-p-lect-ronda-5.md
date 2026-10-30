# E1-U3 — P-LECT, ronda 5 (2026-10-27)

Lector nuevo sobre el README del commit 8fc8b8d (consigna de la ronda 3).

Resultado: 27 preguntas; 22 respondidas, 0 con respuesta no alcanzada, 5 huecos. Umbral: NO cumple. El lector usó §5.6 (supuestos
en el PR) para avanzar en los cinco. README corregido (commit siguiente, integrado con origin/main en a32c89b).

## Preguntas registradas por el lector (texto recortado del informe)

1. **Pregunta:** qué es la pantalla Encuesta y dónde está su código.
   - **Dónde:** README §5, y §5.2 en la tabla de anclas.
   - **Clase:** respondida.
   - **Cómo la resolví:** los ejemplos nombran `EncuestaRules.cs` y `EncuestaPage.xaml`. Desde ahí seguí al servicio y al modelo de vista.
2. **Pregunta:** dónde está el código bajado.
   - **Dónde:** §5.2, en «Tabla de anclas».
   - **Clase:** respondida.
   - **Cómo la resolví:** `$TRABAJO/sha/`, con `TRABAJO=…/cache-u3/trabajo`.
3. **Pregunta:** qué número lleva la fila nueva del RRD y qué columnas tiene.
   - **Dónde:** §5.1.
   - **Clase:** respondida.
   - **Cómo la resolví:** RD-05, con las ocho columnas del ejemplo.
4. **Pregunta:** cómo se registra quién decide una fila nueva.
   - **Dónde:** §5.1, en «Decisión».
   - **Clase:** respondida.
   - **Cómo la resolví:** `pendiente` y `PO, pendiente`. El RRD §1 nombra a la mesa, pero seguí el tutorial.
5. **Pregunta:** qué cuenta como regla y cuántas fichas hacen falta.
   - **Dónde:** §5.2, primer párrafo.
   - **Clase:** respondida.
   - **Cómo la resolví:** salieron cuatro fichas. Mínimo y máximo del nombre van juntos, como en RN-LOC-01.
6. **Pregunta:** qué ID de regla usar.
   - **Dónde:** §5.1 (ejemplo) y §5.2.
   - **Clase:** respondida.
   - **Cómo la resolví:** `RN-ENC-nn`.
7. **Pregunta:** qué `doc_id` llevan la página y las fichas.
   - **Dónde:** §5.3, en el comentario del frontmatter, y §2 para ver los números usados.
   - **Clase:** respondida.
   - **Cómo la resolví:** 22 para la página y 13 a 16 para las fichas.
8. **Pregunta:** qué forma y qué campos tiene una ficha.
   - **Dónde:** §5.2, en la tabla de campos y en el modelo RN-LOC-02.
   - **Clase:** respondida.
9. **Pregunta:** qué se pone en «Dueño» y en el ancla principal cuando ninguna clase del dominio declara la regla.
   - **Dónde:** §5.2, en las filas Dueño y Ancla.
   - **Clase:** respondida.
   - **Cómo la resolví:** en RN-ENC-03 y RN-ENC-04 no hay fila `declara`; la principal es la de `verifica` o la de `aplica`.
10. **Pregunta:** qué Momento lleva una validación por paso.
    - **Dónde:** §5.2, en «Valores cerrados» (Momento).
    - **Clase:** respondida.
    - **Cómo la resolví:** «Precondition de pasar al paso 2».
11. **Pregunta:** qué valor de «¿Divergen?» lleva el hueco «se valida al avanzar y no al registrar».
    - **Dónde:** §5.2, en Momento.
    - **Clase:** hueco. El texto dice dónde va, pero no con qué valor.
    - **Qué supuse:** lo clasifiqué por su efecto en lo que se guarda (supuesto 3).
12. **Pregunta:** cómo tratar un límite que la letra no nombra (el 80 del nombre).
    - **Dónde:** §5.2 («Silencio») y §5.3 («Qué límites nombra»).
    - **Clase:** respondida.
13. **Pregunta:** si un mensaje que pide «nombre y apellido» cuando alcanza una palabra es divergencia.
    - **Dónde:** §5.2, en «¿Divergen?».
    - **Clase:** respondida.
    - **Cómo la resolví:** leve, porque el mensaje cuenta como letra.
14. **Pregunta:** cómo anclar un control XAML sin `x:Name`.
    - **Dónde:** §5.2, en la tabla de archivos.
    - **Clase:** respondida.
    - **Cómo la resolví:** por `AutomationId`.
15. **Pregunta:** cómo afirmar un mensaje interpolado.
    - **Dónde:** §5.2, en «Mensajes interpolados».
    - **Clase:** respondida.
16. **Pregunta:** qué rol usar para un lugar que no es ninguno de los cinco.
    - **Dónde:** §5.2, en la columna Rol.
    - **Clase:** respondida.
    - **Cómo la resolví:** `registra` y `vacía`.
17. **Pregunta:** si «entero» es una regla de formato con ficha propia.
    - **Dónde:** §5.2 menciona «un formato».
    - **Clase:** hueco.
    - **Qué supuse:** lo puse dentro de RN-ENC-02 (supuesto 2).
18. **Pregunta:** si el alcance por sesión de la lista de localidades lleva ficha en esta pantalla.
    - **Dónde:** §5.2, en «Especie» (alcance).
    - **Clase:** hueco.
    - **Qué supuse:** sin ficha y sin ancla (supuesto 5).
19. **Pregunta:** cómo se titula la sección de errores y cómo se trata a quien lee.
    - **Dónde:** §5.3.
    - **Clase:** respondida.
    - **Cómo la resolví:** «Si la app no te deja seguir», tratando de vos.
20. **Pregunta:** si el aviso general del paso lleva ficha.
    - **Dónde:** §5.3, en «Qué tiene que estar en una ficha».
    - **Clase:** respondida.
    - **Cómo la resolví:** se cita sin ficha.
21. **Pregunta:** cómo contar una divergencia de fondo a la persona usuaria.
    - **Dónde:** §5.3 y alta-de-localidad §3.
    - **Clase:** respondida.
22. **Pregunta:** qué otras piezas cambian en el mismo PR.
    - **Dónde:** §5.5.
    - **Clase:** respondida.
    - **Cómo la resolví:** README §2, arquitectura §3, RD-03 y CHANGELOG.
23. **Pregunta:** qué se pone en «Declara» de arquitectura §3 cuando la regla no tiene dueño en el dominio.
    - **Dónde:** §5.5.
    - **Clase:** hueco.
    - **Qué supuse:** «Ninguno en el dominio» (supuesto 6).
24. **Pregunta:** qué fecha va en el CHANGELOG y en `last_review`.
    - **Dónde:** §5.5.
    - **Clase:** respondida.
    - **Cómo la resolví:** la del día del PR, 2026-10-27. El ejemplo dice 2026-10-28, pero manda la regla.
25. **Pregunta:** si RD-04 o el `traces` del README cambian.
    - **Dónde:** §5.2 y §5.5.
    - **Clase:** respondida.
    - **Cómo la resolví:** no cambian.
26. **Pregunta:** con qué comandos se crean la rama y el PR.
    - **Dónde:** §5.5.
    - **Clase:** hueco. Da el nombre de la rama y el mensaje, no los comandos.
    - **Qué supuse:** `git` y `gh pr create`.
27. **Pregunta:** desde dónde se corren los comandos y de dónde sale `$DEMO`.
    - **Dónde:** §4 y §5.4.
    - **Clase:** respondida.

## Conteo

| Clase | Cantidad |
| --- | --- |
| Respondida | 22 |
| Con respuesta no alcanzada | 0 |
| Hueco | 5 |

**Huecos:**
- 11: el valor de «¿Divergen?» para un acto no comprobado.
- 17: si «entero» es un formato con ficha propia.
- 18: si el alcance por sesión lleva ficha.
- 23: qué va en «Declara» de arquitectura §3 cuando no hay dueño en el dominio.
- 26: los comandos para crear la rama y el PR.

**Con respuesta no alcanzada:** ninguna detectada. No abrí `tools/docs-guard/README.md`, que §1 enlaza; si respondía algo de esto, no lo vi.
