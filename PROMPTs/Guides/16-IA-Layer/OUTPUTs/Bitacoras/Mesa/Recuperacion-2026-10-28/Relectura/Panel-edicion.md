# Panel de edición · relectura integral de la guía 0.11.0 (B-14)

Rol: editor. Me ocupo del estilo, la coherencia terminológica (patrón en inglés, dominio en español), la extensión, las redundancias, las anclas y las remisiones. Trabajé a ciegas, sin leer los paneles de otros. La guía no se editó.

## Controles mecánicos que pasan (sin hallazgo)

- Anclas: todos los `](#…)` de la guía resuelven a un `<a id>` y no hay ids duplicados.
- Remisiones `§N.k`: todas apuntan a un encabezado que existe, y el texto de cada enlace coincide con su destino.
- Referencias: todo `[REF-nn]` citado existe en el Anexo D (180 entradas), y ninguna entrada queda sin citar.
- Conteos declarados: «Ocho bloques» en §0.0, «Doce términos» en §3.0 y «Diez términos» en §4.1 coinciden con las filas de cada tabla. Los «diecisiete ejemplos» coinciden con las carpetas 01–17.

## Hallazgos

### edicion-01 · mayor · §10.6, párrafo «Lo que vio el laboratorio después»
- **Problema.** El párrafo quedó desactualizado: dice que la repetición del juez «no había cerrado al escribir esta sección». R-15b ya cerró, y su resultado es «no medido».
- **Evidencia.** El texto dice: «su repetición, con criterio propio, no había cerrado al escribir esta sección». Según 00-Preparacion, R-15b terminó con rc 0 y dio 41/52 interpretables, 0,788, IC95 Clopper-Pearson [0,653; 0,889]. Rótulo: `qwen3.5:4b`@`d8b0f5e9760c`, estación 2, Ollama 0.40.11, 2026-10-29. El mínimo del criterio es 45/52.
- **Propuesta.** Reemplazar la frase por: «no medido: 41/52 salidas interpretables, por debajo del mínimo de 45/52 fijado en el criterio antes de la corrida», con ese rótulo R-LLM. No hay que agregar ninguna afirmación sobre el acuerdo.

### edicion-02 · mayor · §13.11 ADR-10 (Consecuencias), §14.6 «LLM juez» y fila 15 del Anexo E.1
- **Problema.** Estos tres pasajes describen la composición retirada como si fuera la vigente.
- **Evidencia.**
  - ADR-10, en presente: «ninguna de sus salidas se pudo leer». En R-15b sí se leyeron 41/52.
  - La fila 15 de E.1 dice «`qwen2.5:0.5b` como LLM juez», sin el rótulo «Historia».
  - El README del ejemplo 15 sigue igual: default `OLLAMA_PROPIO_MODEL` = `qwen2.5:0.5b`.
- **Propuesta.** En ADR-10, cambiar a «no calibrado: hasta el 2026-10-28 ninguna salida fue legible; en 2026-10-29, no medido (41/52 < 45/52)», remitiendo a §10.6. En E.1, rotular la composición como historia o nombrar la vigente.

### edicion-03 · mayor · §10.6, segundo párrafo («En el laboratorio, el LLM juez y el modelo evaluado…»)
- **Problema.** El párrafo se contradice. Primero dice que en la corrida del 2026-10-29 «juez y generador fueron el mismo `qwen3.5:4b`». Después razona como si fueran distintos: «ser distintos reduce el autofavorecimiento sin eliminarlo». El README del ejemplo 15 insiste en «distinto del generador».
- **Evidencia.** Las dos frases están en el mismo párrafo de §10.6. El README de 15 lo dice en la línea 13.
- **Propuesta.** Decir explícitamente que en 2026-10-29 el juez es el mismo modelo que el generador, que es el caso de mayor riesgo de autofavorecimiento. Dejar el «ser distintos…» sólo para la composición histórica.

### edicion-04 · mayor · §10.6 «Resultado: no calibrado»
- **Problema.** El párrafo da una tasa con intervalo para algo que él mismo declara no medido. Eso contradice la regla de §0.4: una tasa es k/M con IC.
- **Evidencia.** El texto dice: «Acuerdo con la anotación: 0/10, IC95 [0; 0,308], pero sólo porque ninguna de las 10 de calibración dio una salida interpretable. El acuerdo no se midió».
- **Propuesta.** Quitar «0/10, IC95 [0; 0,308]» y dejar «acuerdo no medido: 0 de 10 salidas de calibración legibles (recuento, no tasa)».

### edicion-05 · mayor · rótulo «existencia, otra composición: línea archivada del laboratorio» (11 apariciones: §4.3, §5.4, §7.4, §7.7, §10.6, §11.7, §13.x…) y banner de versión
- **Problema.** La guía usa un rótulo de evidencia que §0.4 no define: §0.4 define conducta, tasa e «Historia (hasta…)», pero no «existencia» ni «otra composición». Además mete en la guía jerga del proceso: «línea archivada», «línea de construcción», «línea paralela» (banner, línea 18).
- **Evidencia.** `grep -c 'otra composición'` da 11. «línea archivada» no tiene definición en ninguna parte de la guía.
- **Propuesta.** Hay dos caminos. Uno es definir el rótulo en la lista de §0.4 («Existencia: se vio al menos una vez en una composición distinta de la de los ejemplos; no es conducta reproducible con este repo»). El otro es reescribir cada aparición en la forma «Historia (hasta el 2026-10-28)». En los dos casos, quitar «línea archivada/paralela/de construcción» del texto al lector.

### edicion-06 · mayor (extensión) · §3.0, §4.1 y Anexo C
- **Problema.** Los mismos términos se definen tres veces: modelo, prompt, embedding, salida estructurada y temperatura, entre otros. La prosa está al 133 % del tope; los Anexos están al 192 % y la Parte 0 al 148 %.
- **Evidencia.**
  - `contar.sh`: total 58.820/44.330, Anexos 14.261/7.430 (Anexo C, 2.187), Parte 0 2.065/1.400, Parte II 6.517/5.000.
  - La definición de «modelo» de §3.0 («Predice el siguiente token; no conoce los datos propios salvo que viajen en el contexto») se repite casi textual en §4.1 y en el Anexo C.
- **Propuesta.** §4.1 conserva sólo lo que agrega «qué no es» y remite al Anexo C, sin repetir las filas de §3.0. El Anexo C deja de repetir las definiciones y conserva término, alias y «Se define en». Los ahorros no están medidos: hay que medirlos con `contar.sh` después del recorte.

### edicion-07 · menor · «Presentación» frente a Application/Domain/Infrastructure (16 apariciones: §0.1 OA-0.2, §1 diagramas, §3.1, §4.3, §4.5…)
- **Problema.** Es la única capa nombrada en español. Rompe la regla «patrón en inglés, dominio en español».
- **Evidencia.** OA-0.2 dice: «en Presentación, Application, Domain o Infrastructure». El diagrama de §1 dice «Presentación · DesdeTextoController».
- **Propuesta.** Usar «Presentation» (o «Host/Presentation») en las 16 apariciones.

### edicion-08 · menor · variantes del rótulo «Historia»
- **Problema.** §0.4 fija la forma «Historia (hasta el 2026-10-28)», pero el texto usa al menos tres variantes.
- **Evidencia.**
  - «Historia (hasta el 2026-10-28, servidor retirado)».
  - «Historia (hasta el 2026-10-28, servidor retirado; oro v1, 16 preguntas, sin n05)», en §7.
  - «Historia (hasta el 2026-10-28)» a secas, en §6.3.
- **Propuesta.** Elegir una sola forma y declararla en §0.4. Lo propio de cada corrida va después del punto.

### edicion-09 · menor · ancla `anexo-a-props`
- **Problema.** A.14 usa el id `anexo-a-props`. Los demás de su anexo siguen el patrón `anexo-a-N`, y el Anexo A empieza en A.4 sin decir en el índice que la numeración sigue a la sección.
- **Evidencia.** El índice de §0.0 dice «[A.14](#anexo-a-props)».
- **Propuesta.** Agregar el alias `anexo-a-14` (sin romper el viejo) y una línea en la entrada del Anexo A: «A.n es la plantilla de §n».
