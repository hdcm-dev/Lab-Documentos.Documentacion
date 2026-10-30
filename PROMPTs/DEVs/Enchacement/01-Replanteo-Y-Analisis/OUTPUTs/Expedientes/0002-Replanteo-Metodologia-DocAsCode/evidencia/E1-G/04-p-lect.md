# E1-G — P-LECT de la compuerta (G-e). Lector: claude -p --tools "" (sin herramientas ni repositorio), 2026-10-28

## Consigna común

Sos un lector sin contexto previo: estudiante avanzado de una carrera de sistemas que conoce Git, Markdown y lo básico de CI, pero no este proyecto. Recibís, más abajo, un conjunto de documentos de una guía (cada uno precedido por una línea "===== ARCHIVO: <ruta>"). No tenés acceso a ningún otro archivo ni a internet.

Tarea: hacé una prueba de lectura con la consigna real indicada al final. Leé los documentos como si tuvieras que cumplir la consigna, y listá CADA pregunta que el texto te dejó planteada mientras lo hacías (también las que el texto termina respondiendo). Para cada pregunta, en una lista numerada:
- Pregunta: en una línea.
- Dónde: documento y sección donde surgió.
- Clase: exactamente una de: "respondida" (el texto recibido la responde; decí dónde), "no alcanzada" (el texto dice dónde está la respuesta pero es un documento que no recibiste; decí cuál), "hueco" (ningún documento recibido la responde ni dice dónde buscarla).
- Gravedad (sólo para no alcanzada y hueco): alta (te impide cumplir la consigna), media (lo cumplís suponiendo algo), baja (curiosidad).

Al final, una tabla resumen: total de preguntas, respondidas, no alcanzadas, huecos, y cuántas altas. No propongas reescrituras largas; no inventes contenido de documentos que no recibiste.

## Lector 1 — tutorial de la mini demo (README, RRD, RN-LOC-02, ayuda de alta, README del cuerpo)

# Prueba de lectura: documentar el paso 1 de la Encuesta

Leí los cinco documentos para cumplir la consigna: documentar el paso 1 de la Encuesta (edad entre 16 y 110 y localidad obligatoria de una lista), decir qué archivos crear o cambiar, cómo validarlos y cómo proponer el cambio.

## Preguntas

1. **Pregunta:** ¿Qué es el «escalón 1» del sistema documentador?
   - **Dónde:** README de la demo, introducción.
   - **Clase:** hueco. El README de SDEI nombra «escalón» en §4 y §6, pero no dice qué es ni dónde se define.
   - **Gravedad:** baja.

2. **Pregunta:** ¿Tengo que leer *Deducción de reglas de negocio* §5.1 para escribir una ficha?
   - **Dónde:** README de la demo, §1 (Ficha).
   - **Clase:** respondida. En §5.2 dice que no se publica y que «todo lo que hace falta de él está acá».

3. **Pregunta:** ¿Cuándo se sube la parte MAYOR de una versión y cuándo la MENOR?
   - **Dónde:** README de la demo, §1 (Traza).
   - **Clase:** hueco. Sólo hay ejemplos de la menor (§6: 1.1 → 1.2). A una ficha nueva le alcanza con 1.0.
   - **Gravedad:** baja.

4. **Pregunta:** ¿Qué es CL-02 y qué otras clases de documento hay?
   - **Dónde:** README de la demo, §2 (tabla).
   - **Clase:** hueco. §1 sólo define CL-06 y CL-07.
   - **Gravedad:** baja.

5. **Pregunta:** ¿Qué controlan los grupos `contrato`, `fijadas` y `autoprueba` de la salida de ci-local?
   - **Dónde:** README de la demo, §5.4.
   - **Clase:** no alcanzada. Está en `tools/docs-guard/README.md` §4.
   - **Gravedad:** baja.

6. **Pregunta:** ¿El workflow `mini-demo-movilidad` corre en mi PR?
   - **Dónde:** README de la demo, §3.
   - **Clase:** respondida. Según la tabla de §3, corre en todo PR que toca la demo.

7. **Pregunta:** ¿Mis fichas necesitan una prueba negativa como la de C4, o tengo que tocar `verificar.sh` para que las lea?
   - **Dónde:** README de la demo, §3.
   - **Clase:** respondida. §5.5 dice que no se toca nada: C3 lee todas las fichas de `docs/fichas/`.

8. **Pregunta:** ¿Qué otros modos tiene `scripts/ci-local.sh` además de `todo`?
   - **Dónde:** README de la demo, §4.
   - **Clase:** hueco.
   - **Gravedad:** baja.

9. **Pregunta:** ¿Necesito .NET para validar?
   - **Dónde:** README de la demo, §4 (requisitos).
   - **Clase:** respondida. Para la validación completa sí (§4). Para revisar sólo trazas y anclas, no (§5.4, con `dg.py trazas`).

10. **Pregunta:** Si no exporté `TRABAJO`, ¿a qué ruta apunta `--fuente "$TRABAJO/sha"`?
    - **Dónde:** README de la demo, §5.4.
    - **Clase:** hueco. §5.2 da el valor por defecto que usa `verificar.sh` (`/tmp/mini-demo-movilidad`), pero el comando de shell usa la variable tal cual. Si no está definida, queda `/sha`.
    - **Gravedad:** media.

11. **Pregunta:** ¿La pantalla Encuesta existe en el SHA 8fb4c3a, y el rango 16–110 es real o sólo un ejemplo?
    - **Dónde:** README de la demo, §5 y la consigna.
    - **Clase:** no alcanzada. Está en el código del SHA, en `$TRABAJO/sha/`, que baja `verificar.sh fuente`.
    - **Gravedad:** alta. Sin el código puedo decir qué archivos crear, pero no escribir anclas que pasen C3, así que no puedo mostrar la validación en verde.

12. **Pregunta:** ¿Los símbolos del ejemplo son reales o ilustrativos? (`EncuestaRules.EdadMinima`, `EncuestaPolicy.RequisitoDeLaEdad`, `EncuestaPage.xaml#edad`)
    - **Dónde:** README de la demo, §5.2 (tabla de anclas y «Mensajes interpolados»).
    - **Clase:** no alcanzada. Hay que mirar el código del SHA.
    - **Gravedad:** media.

13. **Pregunta:** ¿Qué textos muestra la pantalla: la ayuda bajo cada campo y los mensajes de error? Los necesito para el campo Letra y para la página.
    - **Dónde:** README de la demo, §5.2 (Letra) y §5.3.
    - **Clase:** no alcanzada. Están en el código del SHA.
    - **Gravedad:** media.

14. **Pregunta:** ¿En qué acto se valida cada regla (al avanzar o al registrar), quién la verifica y qué clase la declara?
    - **Dónde:** README de la demo, §5.2 (Momento, Quién la verifica hoy, Dueño).
    - **Clase:** no alcanzada. Está en el código del SHA.
    - **Gravedad:** media.

15. **Pregunta:** ¿Qué número y qué columnas lleva la fila nueva del RRD?
    - **Dónde:** README de la demo, §5.1.
    - **Clase:** respondida. RD-05, con ocho columnas, y hay una fila de ejemplo.

16. **Pregunta:** ¿Quién decide la fila nueva: el PO o la mesa del expediente 0002?
    - **Dónde:** README §5.1 frente a `_requisitos.md` §1.
    - **Clase:** hueco. Los textos se contradicen: el tutorial dice «PO, pendiente», pero las filas existentes dicen «mesa» y `_requisitos.md` §1 dice que decide la mesa por delegación del PO.
    - **Gravedad:** media.

17. **Pregunta:** ¿La compuerta exige Dado, Cuando y Entonces con mayúscula?
    - **Dónde:** README de la demo, §5.1.
    - **Clase:** hueco. La regla las escribe con mayúscula, pero el ejemplo usa «cuando» y «entonces» en minúscula.
    - **Gravedad:** baja.

18. **Pregunta:** ¿El instrumento `traces-resolve` es lo mismo que el grupo `trazas` o que `dg.py trazas`?
    - **Dónde:** README §5.1 y `_requisitos.md`.
    - **Clase:** hueco.
    - **Gravedad:** baja.

19. **Pregunta:** ¿Cuántas fichas lleva la pantalla?
    - **Dónde:** README de la demo, §5.2.
    - **Clase:** respondida. Dos: una para la edad (entero entre 16 y 110) y otra para la localidad (obligatoria y de la lista). Los textos de navegación no llevan ficha.

20. **Pregunta:** ¿Qué ID les doy a las reglas y quién lo asigna?
    - **Dónde:** README de la demo, §5.2.
    - **Clase:** respondida. `RN-ENC-nn`, provisionales y asignados por la demo (§5.2 y §8).

21. **Pregunta:** ¿Qué `doc_id` del grupo 1x están ocupados?
    - **Dónde:** README de la demo, §5.3 (comentario de `doc_id`).
    - **Clase:** no alcanzada. Sé que RN-LOC-02 es 12; el de RN-LOC-01 estaría en `RN-LOC-01.md`, que no recibí. Supongo 11 y uso 13 y 14.
    - **Gravedad:** baja.

22. **Pregunta:** ¿Qué es el «apartamiento» que menciona RN-LOC-02, y lo copio en mis fichas?
    - **Dónde:** RN-LOC-02, §1.
    - **Clase:** no alcanzada. Está en `RN-LOC-01.md` §1.
    - **Gravedad:** media.

23. **Pregunta:** ¿Cómo anclo un Picker que no tiene `x:Name` ni `AutomationId`, o la lista de la que salen los valores (ItemsSource o binding)?
    - **Dónde:** README de la demo, §5.2 (tabla de anclas).
    - **Clase:** hueco. Sólo queda la salida genérica de §5.6: resolverlo y anotarlo como supuesto en el PR.
    - **Gravedad:** media.

24. **Pregunta:** ¿Qué rol uso si la regla se impone en un lugar que no es declara, muestra, verifica, aplica ni persiste?
    - **Dónde:** README de la demo, §5.2.
    - **Clase:** respondida. La compuerta no lee el Rol y se puede usar otro.

25. **Pregunta:** ¿La ficha de la localidad dice que «Depende de» RN-LOC-01 o RN-LOC-02?
    - **Dónde:** README de la demo, §5.2 (Depende de).
    - **Clase:** hueco.
    - **Gravedad:** baja.

26. **Pregunta:** ¿Dónde explico que para elegir una localidad tiene que haber alguna cargada?
    - **Dónde:** README de la demo, §5.2.
    - **Clase:** respondida. En «Antes de empezar», junto con qué ve la persona si no hay ninguna.

27. **Pregunta:** ¿La página de la encuesta traza RN-LOC-* porque habla de localidades?
    - **Dónde:** README de la demo, §5.3 (`traces`).
    - **Clase:** hueco.
    - **Gravedad:** baja.

28. **Pregunta:** ¿Con qué criterio elijo `confidence: alta`, `media` o `baja`?
    - **Dónde:** README de la demo, §5.3.
    - **Clase:** no alcanzada. El README de SDEI dice que los vocabularios están en el anexo `Esquema-Frontmatter-Y-Prefijos.md`.
    - **Gravedad:** baja.

29. **Pregunta:** ¿Qué `last_review` llevan los archivos nuevos: 2026-10-27, como la plantilla, o la fecha del PR?
    - **Dónde:** README §5.3 frente a §5.5.
    - **Clase:** hueco. §5.5 sólo habla de los archivos que se cambiaron.
    - **Gravedad:** baja.

30. **Pregunta:** ¿Qué secciones lleva el cuerpo de la página, y cómo se llama la de errores si la pantalla no guarda?
    - **Dónde:** README de la demo, §5.3.
    - **Clase:** respondida. Las enumera §5.3, y la de errores se llama «Si la app no te deja seguir».

31. **Pregunta:** ¿La página tiene que llevar un diagrama Mermaid, como la del alta?
    - **Dónde:** README §5.3 y `alta-de-localidad.md`.
    - **Clase:** hueco.
    - **Gravedad:** baja.

32. **Pregunta:** ¿Cómo cito un mensaje general como «Complete los datos del paso…»?
    - **Dónde:** README de la demo, §5.3.
    - **Clase:** respondida. Se cita textual, sin ficha ni ancla.

33. **Pregunta:** ¿Qué columnas tiene la tabla §3 de `arquitectura.md`, para escribir la fila de cada regla nueva?
    - **Dónde:** README de la demo, §5.5.
    - **Clase:** no alcanzada. Están en `docs/tecnica/arquitectura.md`. Del texto sólo sé que hay una columna Declara y otra Estado.
    - **Gravedad:** media.

34. **Pregunta:** ¿Qué fila agrego en la tabla §2 del README?
    - **Dónde:** README de la demo, §5.5.
    - **Clase:** respondida. Por analogía con las filas de §2: las fichas como anexo para analista y la página como CL-06 para persona usuaria.

35. **Pregunta:** Si agrego fuentes a RD-03, ¿su decisión vuelve a `pendiente`?
    - **Dónde:** README de la demo, §5.5.
    - **Clase:** respondida. No: agregar una fuente no reabre la fila.

36. **Pregunta:** En el CHANGELOG, ¿los archivos que cambié (README, RRD, `arquitectura.md`) van bajo otro título, como «Cambiado»?
    - **Dónde:** README de la demo, §5.5.
    - **Clase:** hueco. El texto sólo muestra «Añadido».
    - **Gravedad:** media.

37. **Pregunta:** ¿Cómo nombro la rama, el commit y el PR?
    - **Dónde:** README de la demo, §5.5.
    - **Clase:** respondida.

38. **Pregunta:** ¿Hago push directo al repositorio o tengo que usar un fork?
    - **Dónde:** README de la demo, §5.5.
    - **Clase:** hueco.
    - **Gravedad:** baja.

39. **Pregunta:** ¿Qué lleva el cuerpo del PR?
    - **Dónde:** README de la demo, §5.5.
    - **Clase:** respondida.

40. **Pregunta:** ¿Quién revisa el PR y decide los supuestos?
    - **Dónde:** README de la demo, §5.5 y §5.6.
    - **Clase:** hueco.
    - **Gravedad:** baja.

41. **Pregunta:** ¿Qué hago si la pantalla existe en `main` del código pero no en el SHA fijado? No puedo tocar `source.lock`.
    - **Dónde:** README de la demo, §5.5 y §6.
    - **Clase:** hueco.
    - **Gravedad:** media.

42. **Pregunta:** ¿También tengo que seguir «Cómo intervenir» y la Lista de verificación de la ruta «intervenir»?
    - **Dónde:** README de SDEI, §3.
    - **Clase:** no alcanzada. Están en `Como-Intervenir-Lab-Documentos.md` y `Lista-De-Verificacion.md`.
    - **Gravedad:** media.

43. **Pregunta:** Si `ci-local.sh` corre sólo sobre `$DEMO`, ¿alguien valida el CHANGELOG?
    - **Dónde:** README de la demo, §5.4 y §5.5.
    - **Clase:** hueco.
    - **Gravedad:** baja.

44. **Pregunta:** ¿El PR se puede fusionar con RD-05 en `pendiente`, y quién la pasa a `aceptado`, y cuándo?
    - **Dónde:** README de la demo, §5.1.
    - **Clase:** hueco.
    - **Gravedad:** baja.

45. **Pregunta:** Si una ficha tiene una divergencia de fondo, ¿la compuerta bloquea el PR?
    - **Dónde:** README de la demo, §5.2 y §7.
    - **Clase:** respondida. No bloquea: la ficha dice lo que el código hace, deja la propuesta y la compuerta verifica sólo eso.

## Resumen

| Concepto | Cantidad |
| --- | --- |
| Total de preguntas | 45 |
| Respondidas | 16 |
| No alcanzadas | 10 |
| Huecos | 19 |
| Gravedad alta | 1 (la 11) |
| Gravedad media | 11 |
| Gravedad baja | 17 |

Con lo que recibí puedo decir exactamente qué archivos crear o cambiar, y cómo validar y proponer el cambio:

- **Archivos nuevos:** dos fichas `RN-ENC` y `docs/ayuda/encuesta.md`.
- **Archivos que cambian:** la fila RD-05 y el frontmatter de `_requisitos.md`, la Fuente de RD-03, la tabla §2 del README de la demo, la tabla §3 y el `traces` de `arquitectura.md`, y el `CHANGELOG.md`.

Lo que no puedo es escribir el contenido de las fichas y las anclas sin suponer, porque depende del código del SHA, que no está entre los documentos recibidos. Por eso no puedo asegurar que la validación quede en verde.

## Lector 2 — ruta de la guía, ronda 1 (README, Marco, Mapa, Glosario, AGENTS.md)

# Prueba de lectura: guía SDEI, ruta de la persona nueva del equipo

## Cómo respondí la consigna con lo que recibí

1. **Escenario para un repositorio de código con su documentación al lado:** ningún escenario describe ese caso. Tener la documentación al lado del código es una topología, y eso es el contexto `CTX-SDEI-3` («mismo repositorio», el ancla es el commit). El escenario depende del tipo de sistema: `ESC-SDEI-2`, `-3` o `-4`. `ESC-SDEI-1` queda afuera porque es un repositorio dedicado a guías.
2. **Qué aplicar cuando un cambio de código deja desactualizada una página:** está en el Mapa §3, fila «El código cambió…, en el **mismo** repositorio». Quien cambia el código sube la ficha de 1.0 a 1.1. `traces-resolve` da rojo en ese pull request hasta que la página traza a `@1.1`. La página la revisa quien propone el cambio (clase P). Si cambia lo que promete la regla, decide la analista. Si la página vive en otro repositorio, se aplica la fila siguiente.
3. **Campos del frontmatter y control que rechaza la página:** los deduje de los frontmatter que recibí, pero no los pude confirmar: `doc_id`, `doc_type`, `title`, `status`, `origin`, `confidence`, `owner`, `last_review`, `audience`, `traces` y además `description`. El control que la rechazaría sería el grupo «frontmatter», que por el orden de la lista del Marco parece ser PR-2. AGENTS.md lo llama «esquema». Esta parte se responde suponiendo cosas.
4. **Tema para entender cómo se verifica una página en CI:** `TEM-06` (Compuertas de calidad y CI).

## Preguntas que me dejó el texto

1. **Pregunta:** ¿Qué ruta sigue una persona nueva del equipo: Aprender o Intervenir?
   - **Dónde:** README §3.
   - **Clase:** hueco. Intervenir sirve para cambiar documentación y Aprender, para estudiar. La consigna mezcla las dos y la ruta Intervenir no pasa por los temas, que hacen falta para el punto (4).
   - **Gravedad:** media.
2. **Pregunta:** ¿Qué son los grupos PR-1 a PR-7?
   - **Dónde:** README, tabla inicial.
   - **Clase:** respondida (Marco §1 «Compuerta» y Glosario §1).
3. **Pregunta:** ¿Qué es el «escalón» (la «revisión del escalón» y el «hasta el escalón 2» de TEM-07)?
   - **Dónde:** README §4 y §6.
   - **Clase:** hueco.
   - **Gravedad:** baja.
4. **Pregunta:** ¿Los temas ya están escritos o siguen en redacción?
   - **Dónde:** Mapa §1, que dice «mientras estén en redacción».
   - **Clase:** respondida (README §3 y §4: están escritos y en borrador).
5. **Pregunta:** ¿Cómo ubico mi escenario si la ruta Intervenir arranca en el Mapa sin pasar por el Marco?
   - **Dónde:** README §3.
   - **Clase:** respondida (la introducción del Mapa remite al Marco, y su §1 permite entrar por artefacto o por actor).
6. **Pregunta:** ¿Hay un escenario para «código con su documentación al lado»?
   - **Dónde:** Marco §2.
   - **Clase:** respondida (Marco §1: el escenario es el tipo de sistema; Marco §3 y `CTX-SDEI-3`: la topología es un contexto).
7. **Pregunta:** Entonces, ¿qué escenario le toca a ese repositorio?
   - **Dónde:** Marco §2.
   - **Clase:** respondida (las descripciones de `ESC-SDEI-2` a `ESC-SDEI-4`, según el tipo de sistema).
8. **Pregunta:** En una app `ESC-SDEI-2` con la documentación en el mismo repositorio, ¿el ancla es el SHA en `source.lock` (Marco §2.5 y Mapa §2) o el commit (`CTX-SDEI-3`)?
   - **Dónde:** Marco §2.5 comparado con §3.
   - **Clase:** hueco. La tabla parece fijar el ancla por escenario, cuando sale de la topología del ejemplo.
   - **Gravedad:** media.
9. **Pregunta:** ¿El «repositorio dedicado» de `CTX-SDEI-3` es lo mismo que el de `ESC-SDEI-1` y CL-10?
   - **Dónde:** Marco §3.
   - **Clase:** hueco.
   - **Gravedad:** baja.
10. **Pregunta:** ¿Dónde busco un caso de página desactualizada: en la tabla por escenario o en la tabla por contexto?
    - **Dónde:** Mapa §1 y §2.
    - **Clase:** respondida (Mapa §3, filas «El código cambió…»). Esas filas no tienen identificador `CTX`, así que cuesta encontrarlas.
11. **Pregunta:** ¿Qué aplico si la página está en el mismo repositorio que el código?
    - **Dónde:** Mapa §3.
    - **Clase:** respondida (Mapa §3).
12. **Pregunta:** ¿Y si la página está en otro repositorio?
    - **Dónde:** Mapa §3.
    - **Clase:** respondida (Mapa §3 y Marco §6).
13. **Pregunta:** ¿Cómo se «sube la versión» de una ficha?
    - **Dónde:** Mapa §3.
    - **Clase:** respondida (Marco §1 «Traza»: la línea `**Versión:** 1.0`).
14. **Pregunta:** ¿En qué archivo o carpeta vive una ficha cuando el proyecto no tiene SDD?
    - **Dónde:** Marco §1 «Ficha» y `CTX-SDEI-2`.
    - **Clase:** hueco.
    - **Gravedad:** baja.
15. **Pregunta:** Si la página traza sin versión (`traces: [ID]`), ¿la subida de la ficha a 1.1 la pone en rojo?
    - **Dónde:** Marco §1 «Traza» y Mapa §3.
    - **Clase:** hueco.
    - **Gravedad:** media.
16. **Pregunta:** ¿Qué aplico si la página desactualizada no traza a ninguna ficha? Por ejemplo, una CL-07 (documentación técnica), cuyo control no incluye `traces-resolve`.
    - **Dónde:** Mapa §3 y §4.
    - **Clase:** hueco.
    - **Gravedad:** media.
17. **Pregunta:** Que la página «la revisa quien propone el cambio», ¿no choca con la regla de que quien verifica no es quien redactó?
    - **Dónde:** Mapa §3.
    - **Clase:** respondida (Marco §4, último párrafo: verifican los controles de la compuerta).
18. **Pregunta:** Si nadie sube la versión de la ficha, ¿qué mira la revisión del pull request y por qué `CQ-03` es parcial?
    - **Dónde:** Mapa §3.
    - **Clase:** no alcanzada (Criterios de calidad).
    - **Gravedad:** baja.
19. **Pregunta:** En un repositorio de proyecto sin README con `corpus_id`, ¿`traces-resolve` da rojo o sólo avisa?
    - **Dónde:** README §5 comparado con Mapa §3.
    - **Clase:** hueco.
    - **Gravedad:** media.
20. **Pregunta:** ¿Quién decide si el límite correcto es 60 u 80?
    - **Dónde:** Marco §6.
    - **Clase:** respondida (Marco §6: `ACT-SDEI-2`).
21. **Pregunta:** ¿Cuáles son exactamente los «diez campos»?
    - **Dónde:** README OBJ-02 y Marco §5.
    - **Clase:** no alcanzada (Esquema §2). Los deduje de los frontmatter que recibí.
    - **Gravedad:** media.
22. **Pregunta:** ¿Qué valores admiten `doc_type`, `origin`, `confidence` y `audience`?
    - **Dónde:** Marco §5.
    - **Clase:** no alcanzada (Esquema, vocabularios).
    - **Gravedad:** media.
23. **Pregunta:** ¿Qué prefijo lleva el `doc_id` de una página nueva?
    - **Dónde:** Marco §5 y AGENTS §7.
    - **Clase:** no alcanzada (Esquema §5).
    - **Gravedad:** media.
24. **Pregunta:** ¿El grupo «frontmatter» es PR-2, y es el mismo control que AGENTS.md llama «esquema»?
    - **Dónde:** Marco §1 y AGENTS §7.
    - **Clase:** no alcanzada (README de `tools/docs-guard`, §5). El número sólo se infiere por el orden de la lista.
    - **Gravedad:** media.
25. **Pregunta:** Si falta un solo campo, ¿la página queda en rojo o sólo da aviso? README §5 sólo nombra el caso «archivo sin frontmatter», y la regla de la línea de base también podría influir.
    - **Dónde:** README §5 y Glosario «Línea de base».
    - **Clase:** no alcanzada (Criterios de calidad §2).
    - **Gravedad:** media.
26. **Pregunta:** ¿Por qué se dice «diez campos más `description`» y no «once campos»?
    - **Dónde:** README OBJ-02.
    - **Clase:** hueco.
    - **Gravedad:** baja.
27. **Pregunta:** ¿Qué tema explica la verificación en CI?
    - **Dónde:** README §4.
    - **Clase:** respondida (README §4: TEM-06; Mapa §2, fila de `ESC-SDEI-1`).
28. **Pregunta:** ¿Puedo ir directo a TEM-06, o la ruta Aprender exige leer TEM-01 a TEM-07 en orden?
    - **Dónde:** README §3 y el final del Mapa.
    - **Clase:** hueco.
    - **Gravedad:** baja.
29. **Pregunta:** ¿`traces-resolve` lo explica TEM-06 o lo explican TEM-03 y TEM-05, como dice la fila de `ESC-SDEI-2` del Mapa?
    - **Dónde:** Mapa §2.
    - **Clase:** hueco.
    - **Gravedad:** baja.
30. **Pregunta:** ¿Qué son AK-1 a AK-7 y G1 a G4, que el Marco no menciona?
    - **Dónde:** Glosario §1.
    - **Clase:** respondida (Glosario §1 y §2, en forma resumida).
31. **Pregunta:** ¿Qué dicen el expediente 0002, la unidad E1-U4a y la decisión D09?
    - **Dónde:** README §7.
    - **Clase:** no alcanzada (repositorio Lab-Documentos.Documentacion).
    - **Gravedad:** baja.
32. **Pregunta:** ¿Cómo corro la compuerta en local?
    - **Dónde:** README, tabla inicial.
    - **Clase:** respondida (README, tabla inicial, y AGENTS §4).
33. **Pregunta:** ¿Qué nombres de grupo acepta `scripts/ci-local.sh` (por ejemplo, `ai`)?
    - **Dónde:** AGENTS §4.
    - **Clase:** no alcanzada (README de `tools/docs-guard`).
    - **Gravedad:** baja.
34. **Pregunta:** ¿Qué clases activa `ESC-SDEI-2`: CL-02 a CL-07 y CL-12 (Marco §2.5), o sólo CL-02, CL-05, CL-06 y CL-07 (Mapa §2)?
    - **Dónde:** Marco §2.5 comparado con Mapa §2.
    - **Clase:** hueco.
    - **Gravedad:** baja.

## Resumen

| Total | Respondidas | No alcanzadas | Huecos | Altas |
| --- | --- | --- | --- | --- |
| 34 | 14 | 8 | 12 | 0 |

Hay 10 preguntas de gravedad media: los huecos 1, 8, 15, 16 y 19, y las no alcanzadas 21 a 25. Todas tocan los puntos (2) y (3) de la consigna. Esos puntos se pueden cumplir, pero sólo suponiendo cosas: qué controles bloquean fuera de un cuerpo nuevo y cuáles son exactamente los campos del esquema.

## Lector 3 — ruta de la guía, ronda 2 tras e83f373 (más el anexo del esquema)

# Prueba de lectura: guía SDEI, ruta «intervenir»

Leí los seis documentos como una persona nueva del equipo. Según README §3, la ruta que me toca es la de «intervenir». Las cuatro partes de la consigna se pueden cumplir: la (1) suponiendo algo y la (3) dando por buena la tabla del anexo. No encontré ninguna duda de gravedad alta.

## Preguntas

1. **Pregunta:** ¿Qué ruta sigo si soy nuevo en el equipo?
   **Dónde:** README §3. **Clase:** respondida. La fila «Intervenir» dice que quien recién llega hace su primer cambio por esa ruta.

2. **Pregunta:** ¿La ruta «intervenir» pasa por el Marco, o empieza directamente en el Mapa?
   **Dónde:** README §3. **Clase:** respondida. El párrafo inicial y el diagrama dicen que las tres rutas «comparten el Marco». La tabla de la misma sección, en cambio, empieza el recorrido en el Mapa y no lo nombra.

3. **Pregunta:** ¿Qué es un escenario y con qué criterio se elige?
   **Dónde:** 00-Marco §1 y §2. **Clase:** respondida. Un escenario es el tipo de sistema que se documenta; la tabla §2.5 muestra qué cambia entre los cuatro.

4. **Pregunta:** Que la documentación esté al lado del código, ¿define un escenario o un contexto?
   **Dónde:** 00-Marco §1 y §3. **Clase:** respondida. Es un contexto: `CTX-SDEI-3`, en la variante «mismo repositorio». El escenario lo fija el tipo de sistema.

5. **Pregunta:** «Al lado», ¿quiere decir en el mismo repositorio o en el repositorio hermano `.Documentacion`?
   **Dónde:** 00-Marco §1 («Repositorio hermano») y §3. **Clase:** respondida. `CTX-SDEI-3` separa los tres casos: mismo repositorio, hermano o dedicado.

6. **Pregunta:** Si no sé qué tipo de sistema es el repositorio, o si es algo que no entra en los cuatro escenarios (una biblioteca, una herramienta de línea de comandos), ¿qué escenario le corresponde?
   **Dónde:** 00-Marco §2; 01-Mapa §1 y §4. **Clase:** hueco. **Gravedad:** media. El Mapa prevé abrir una clase de pieza nueva por expediente, pero no dice nada sobre un escenario nuevo.

7. **Pregunta:** Lab-Documentos tiene código en `Examples/`. ¿Eso lo hace un repositorio de código?
   **Dónde:** 00-Marco, `ESC-SDEI-1`. **Clase:** respondida. No: ese código sólo existe para ilustrar las guías.

8. **Pregunta:** En `ESC-SDEI-2` con la documentación en el mismo repositorio, ¿el ancla es el SHA en `source.lock` o el commit?
   **Dónde:** 00-Marco §2.5 y 01-Mapa §2 dicen `source.lock`; 00-Marco `CTX-SDEI-3` dice «en el mismo repositorio, el ancla es el commit». **Clase:** hueco. **Gravedad:** media. Ningún documento resuelve la contradicción.

9. **Pregunta:** Para `ESC-SDEI-2`, el Marco activa las clases CL-02 a CL-07 y CL-12, pero el Mapa nombra sólo CL-02, 05, 06 y 07. ¿Es un subconjunto a propósito?
   **Dónde:** 00-Marco §2.5 frente a 01-Mapa §2. **Clase:** hueco. **Gravedad:** baja.

10. **Pregunta:** El diagrama del Mapa me manda primero a §2, §4 o §5. ¿Dónde está entonces la situación «una página quedó desactualizada»?
    **Dónde:** 01-Mapa §1. **Clase:** respondida. Está en §3 «Por contexto», en tres filas. Cuesta encontrarla siguiendo el diagrama.

11. **Pregunta:** Si un cambio de código deja desactualizada una página del mismo repositorio, ¿qué aplico?
    **Dónde:** 01-Mapa §3. **Clase:** respondida. Quien cambia el código sube la versión de la ficha. `traces-resolve` da rojo hasta que la página se revisa y pasa a trazar a `@1.1`. Hay otras dos filas para cuando la página está en otro repositorio y para cuando no traza a ninguna ficha.

12. **Pregunta:** ¿Qué es una ficha y cómo se declara su versión?
    **Dónde:** 00-Marco §1 («Ficha» y «Traza»). **Clase:** respondida. Se declara con un encabezado que empieza con el ID y una línea `**Versión:** 1.0`.

13. **Pregunta:** ¿Qué pasa si la página traza a la ficha sin indicar versión?
    **Dónde:** 00-Marco §1 («Traza»). **Clase:** respondida. Sólo se comprueba que el ID exista; la subida de versión no la pone en rojo.

14. **Pregunta:** ¿Quién revisa la página y quién decide si cambió lo que la regla promete?
    **Dónde:** 01-Mapa §3. **Clase:** respondida. La revisa quien propone el cambio (clase P); si cambia lo que la regla promete, decide la analista (`ACT-SDEI-2`). D/P/H y los actores están en 00-Marco §1 y §4.

15. **Pregunta:** ¿Qué dice `CQ-03` y por qué es «parcial» en este punto?
    **Dónde:** 01-Mapa §3. **Clase:** no alcanzada (está en `99-Anexos/Criterios-De-Calidad.md`). **Gravedad:** baja.

16. **Pregunta:** Si la página vive en otro repositorio, ¿cada cuánto avisa el carril programado?
    **Dónde:** 01-Mapa §3. **Clase:** respondida. Es semanal (00-Marco §1) y lo corre `docs-enlaces-semanal` (Glosario).

17. **Pregunta:** En un proyecto sin SDD, ¿dónde viven las fichas propias?
    **Dónde:** 00-Marco `CTX-SDEI-2`. **Clase:** hueco. **Gravedad:** baja. Sólo se da el lugar del registro de requerimientos (`docs/_requisitos.md`), no el de las fichas.

18. **Pregunta:** Una vez encontrada la fila, ¿cuáles son los pasos concretos (ubicar, derivar, validar, proponer, mantener)?
    **Dónde:** README §3 y §4. **Clase:** no alcanzada (está en `Examples/Como-Intervenir.md` y su instancia para Lab-Documentos). **Gravedad:** baja, porque la consigna sólo pregunta qué aplicar.

19. **Pregunta:** La Lista de verificación cierra la ruta «intervenir», pero README §4 dice que se revisa «antes de pasarla a vigente». ¿Se aplica también a un pull request en borrador?
    **Dónde:** README §3 y §4. **Clase:** hueco. **Gravedad:** baja.

20. **Pregunta:** ¿Qué campos lleva el frontmatter de una página nueva?
    **Dónde:** README §2 (`OBJ-SDEI-02`). **Clase:** respondida en Esquema §2: `doc_id`, `doc_type`, `title`, `status`, `origin`, `confidence`, `owner`, `last_review`, `audience` y `traces`, más `description`.

21. **Pregunta:** ¿El anexo del Esquema forma parte de la ruta «intervenir»?
    **Dónde:** README §3. **Clase:** respondida. Se llega desde la columna «Anexo» de la fila `ESC-SDEI-1` (01-Mapa §2) y desde 01-Mapa §6.

22. **Pregunta:** ¿`confidence` es siempre obligatorio?
    **Dónde:** Esquema §2. **Clase:** respondida. Sólo cuando `origin` no es `human`.

23. **Pregunta:** ¿Por qué se cuenta como «diez campos más `description`» y no como once?
    **Dónde:** README §2; Esquema §2. **Clase:** hueco. **Gravedad:** baja.

24. **Pregunta:** ¿Qué control rechaza la página si le falta un campo?
    **Dónde:** README §2 (`OBJ-SDEI-02`). **Clase:** respondida. Es `esquema-cuerpo`, del grupo PR-2; si falta el bloque entero, `sin-frontmatter` (Esquema §7). AGENTS §7.5 agrega que el mensaje nombra el campo. El ejemplo sólo muestra el caso de `confidence`, y para los demás campos hay que generalizarlo.

25. **Pregunta:** Un campo faltante, ¿bloquea o sólo avisa?
    **Dónde:** README §5. **Clase:** respondida. En un cuerpo nuevo da rojo; en las guías heredadas sólo avisa. La regla general de bloqueo queda en un anexo que no recibí (ver 35).

26. **Pregunta:** Si lo que falta es `doc_id`, ¿la compuerta trata la página como ayuda al usuario o falla `esquema-cuerpo`?
    **Dónde:** Esquema §3. **Clase:** hueco. **Gravedad:** baja.

27. **Pregunta:** ¿La tabla de campos del anexo coincide con lo que la compuerta lee de verdad?
    **Dónde:** Esquema §8 («manda el archivo»). **Clase:** no alcanzada (está en `tools/docs-guard/esquemas/cuerpo.schema.json`). **Gravedad:** media.

28. **Pregunta:** ¿PR-7 es «referencias», como dice el Marco, o la verificación de la copia fijada, como dice el Glosario?
    **Dónde:** 00-Marco §1 («Compuerta») frente a Glosario («Copia fijada»). **Clase:** hueco. **Gravedad:** baja.

29. **Pregunta:** ¿Cómo corro la compuerta en mi máquina?
    **Dónde:** cabecera del README. **Clase:** respondida. Con `scripts/ci-local.sh`, también según AGENTS §4.

30. **Pregunta:** ¿Qué tema sigo para entender cómo se verifica una página en la CI?
    **Dónde:** README §3. **Clase:** respondida. `TEM-06`, según la fila «Intervenir», la fila `ESC-SDEI-1` del Mapa §2 y la tabla de README §4.

31. **Pregunta:** ¿`TEM-06` ya está escrito?
    **Dónde:** README §3 y §4. **Clase:** respondida. Sí, «los siete temas están escritos». Pero dos frases quedaron viejas: la cabecera del README («los siete temas se agregan») y 01-Mapa §1 («mientras estén en redacción»).

32. **Pregunta:** ¿Qué es un «escalón»?
    **Dónde:** README §4 (`TEM-07`, «hasta el escalón 2») y §6. **Clase:** hueco. **Gravedad:** baja.

33. **Pregunta:** ¿Qué son el «Profile de guía de estudio» y la unidad «E1-U4a»?
    **Dónde:** README §7. **Clase:** hueco. **Gravedad:** baja.

34. **Pregunta:** ¿Qué significa «una etiqueta por compuerta»?
    **Dónde:** 00-Marco, `ESC-SDEI-1`. **Clase:** hueco. **Gravedad:** baja.

35. **Pregunta:** ¿Qué bloquea y qué sólo avisa cada grupo de la compuerta?
    **Dónde:** 00-Marco §1; AGENTS §4. **Clase:** no alcanzada (está en `99-Anexos/Criterios-De-Calidad.md` §2 y `tools/docs-guard/README.md` §5). **Gravedad:** baja.

36. **Pregunta:** El prefijo `RN` es «externo» y se resuelve contra el `source.lock`. Si la ficha vive en el mismo repositorio que la página, ¿cómo se resuelve?
    **Dónde:** Esquema §4 y §5. **Clase:** hueco. **Gravedad:** baja.

37. **Pregunta:** ¿Hay que enlazar la página nueva desde el Mapa y desde el README?
    **Dónde:** README §4. **Clase:** respondida en AGENTS §7, que es parte de la ruta «agente», no de la ruta «intervenir».

## Resumen

| Total | Respondidas | No alcanzadas | Huecos | Altas |
| --- | --- | --- | --- | --- |
| 37 | 21 | 4 | 12 | 0 |

Las tres de gravedad media son la 6, la 8 y la 27. La 6 y la 8 afectan la parte (1) de la consigna: la 6 por un escenario que no encaja en los cuatro, la 8 por el ancla en el mismo repositorio. La 27 afecta la parte (3): hay que confiar en que la tabla del anexo coincide con el esquema real.
