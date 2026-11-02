---
doc_id: BIT-16-REC-PANEL-EDICION
doc_type: posicion-de-especialista
title: Mesa de recuperación — posición de Edición bibliográfica (estructura, extensión, voz, referencias)
origin: agent
last_review: 2026-10-28
traces: [01-Matriz.md, Bitacoras/07-Redaccion*.md §1 §5, guía 0.10.1 Anexos C y D, Linea-*-2026-10-28/README.md]
---

# Posición de Edición bibliográfica

Mandato: jerarquía e índices, autocontención, voz única, aparato de referencias con versión y fecha, compresión (REED-16, tabla de especialistas). No opino sobre corrección técnica, estadística ni seguridad de fondo.

## Mediciones propias sobre la base (2026-10-28)

- Guía 0.10.1: 5.128 líneas y 66.827 palabras (`wc -lw`), igual a lo que registra `07-Redaccion` tras los pendientes del 28-10. Encabezado YAML y bloque de versión dicen 0.10.1 / 2026-10-27 / «en revisión».
- Estructura: §0–§15 y Anexos A–G (`grep '^## '`). El índice §0.0 ocupa unas 900 palabras de §0.
- Referencias: todo `REF-nn` citado en el cuerpo está en el Anexo D (comparación de los conjuntos únicos: diferencia vacía). El Anexo D declara forma con URL, versión o fecha y «consultado AAAA-MM-DD».
- Extensión: `07-Redaccion` §5 registra la regla del plan en 49.991 palabras sobre un tope de 44.330 (Parte 0 1.860/1.400; Anexos 12.277/7.430), y la compresión 0.10.1 sacó sólo −631 palabras. `tools/contar.sh` no existe (lo arregla REC-06 punto 6).
- Glosario (Anexo C, l. 4566): `workflow` → alias «flujo de trabajo»; `agente` con definición única (l. 4567) y el mapa de §3 (l. 408) en el mismo sentido.
- IC95: Clopper-Pearson en las cuatro apariciones (l. 168, 2829, 4597, 4952/4971). Un solo método.
- Insumo: los 13 informes de relectura (Ciclo-1 y Ciclo-2) revisan la guía de 4107 líneas, con otra numeración de secciones.

## Regla transversal de extensión (para todo ítem que suma prosa)

La base ya está por encima del tope, y casi todas las opciones A de contenido agregan párrafos. Pido como condición del plan: (1) cada traslado entra en la sección de destino reemplazando o comprimiendo, no sólo sumando; (2) un balance de palabras por sección antes y después de la integración, con `contar.sh` arreglado; (3) cifras importadas con un rótulo de formato uniforme (servidor / estación, fecha, N) y no con prosa explicativa repetida; (4) si el total crece más de un 3 % sobre 66.827, la relectura de REC-03 incluye una pasada de compresión dirigida a Parte 0 y Anexos.

## Posiciones

| Ítem | Opción | Fundamento |
|---|---|---|
| REC-01 | A | Cambio de contenido, no parche: semver menor (0.11.0). Un solo salto evita la cadena de 0.10.x por lote (C), que ensucia el registro de versiones sin dar al lector nada útil. B deja un encabezado falso (0.10.1 del 27-10 con contenido del 28-10+). Encabezado YAML, bloque «Versión» y `Redaccion/00-Versiones.md` se actualizan juntos. |
| REC-02 | abstención | Fuera de mandato (laboratorio y estadística). Sólo pido que la columna «servidor» use el mismo rótulo en la guía y en F.4. |
| REC-03 | A | La voz única y la jerarquía sólo se pueden juzgar sobre el texto final; releer antes de la re-corrida (B) obliga a releer otra vez lo que cambie con las cifras, y releer sólo lo tocado (C) no ve remisiones rotas ni duplicaciones entre secciones (las §§ que reciben traslados remiten a otras). Sumar la pasada de compresión de la regla transversal. |
| REC-04 | A | Revisan otra guía y otra numeración (README del insumo): mapearlos uno por uno acá (B) duplica lo que ya entró por los inventarios de aportes. Descartarlos (C) pierde observaciones de edición que siguen valiendo (el informe de edición del insumo). Entran como insumo de REC-03, con DECI-30 para traducir la numeración y redacción R-PRIV pieza por pieza. |
| REC-05 | abstención | Fuera de mandato. |
| REC-06 | A | El punto 7 (Anexo D y procedencia) y el arreglo de `contar.sh` y de los README son de mi mandato y no tienen alternativa razonable: sin `contar.sh` no hay medición de extensión, y la procedencia es parte del aparato de referencias. |
| REC-07 a REC-18 | abstención | Fondo técnico. Para todos: aplicar la regla transversal de extensión y citar con `[REF-nn]` existente o nuevo en el Anexo D con fecha de consulta. |
| REC-19 | A (sólo por coherencia) | La guía usa un único método de intervalo en sus cuatro apariciones; mezclar Wilson del insumo rompería la voz única (C5). D obliga a reescribir cientos de cifras y el glosario. Sobre el estimando y la existencia me abstengo (estadística). |
| REC-20 a REC-29 | abstención | Fondo técnico. |
| REC-30 | A (en lo del glosario) | El glosario hoy traduce `workflow` como «flujo de trabajo» (l. 4566); si el término queda en inglés, la columna de alias pasa a «— (no se traduce)» y hace falta el barrido de «flujo de trabajo» en el cuerpo para que no queden dos nombres para el mismo concepto. Los casos rojos, fuera de mandato. |
| REC-31 | A | Las referencias nuevas (Ley 25.326, ResDAC) van a D.9 con la forma del Anexo D. El control en el ejemplo (C) es técnico: me abstengo de esa parte. |
| REC-32 | A | Voz única: la base tiene una sola definición, coherente entre §3 (l. 408) y el Anexo C (l. 4567). Adoptar la del insumo (C) obliga a reescribir la escalera y el glosario, y cambia de sentido a PD-1, PD-5 y PD-6. La nota de uso amplio ayuda al lector que llega con la acepción corriente. |
| REC-33 | abstención | Régimen de bitácora; no es estructura de la guía. |
| REC-34 | A | Sin observaciones de edición; DECI-30 es justamente la tabla que necesitan REC-03 y REC-04. |
| REC-35 | abstención | Técnico; sólo F.1 y el hash deben quedar iguales a los `.csproj`. |
