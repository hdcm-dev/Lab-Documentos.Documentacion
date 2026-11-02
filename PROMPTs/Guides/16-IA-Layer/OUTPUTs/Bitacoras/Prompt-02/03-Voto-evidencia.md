# Voto del jurado · función: evidencia

Voto a ciegas sobre los ítems de `02-Consolidado.md`. Criterio rector: toda afirmación tiene que poder verificarse con algo que esté en el repositorio (script, corrida o referencia). Lo cotejado en el material: `tools/contar.sh` existe; §0.5 cita 57.234 palabras medidas el 2026-10-29, contra un tope de 44.330; el Anexo F concentra las versiones.

| Id | Voto | Fundamento |
|---|---|---|
| D-01 | a | Una cifra fija envejece con cada edición (§0.5 ya dice 57.234 y el consolidado, 57.753). Remitir a `contar.sh` deja la evidencia reproducible. |
| D-02 | c | Una excepción que sólo está en el texto no se verifica. Una prueba de arquitectura la vuelve comprobable, y un ADR consecuente la registra sin trabar lo aditivo. |
| D-03 | b | El grep es la evidencia de que el renombre no rompe nada. Sin él, lo honesto es declarar la divergencia. |
| D-04 | b | Es el único umbral con fundamento estadístico. Con 5 o 20 corridas sin IC, la cifra no prueba nada, y si no hay umbral no hay criterio verificable. |
| D-05 | b | Clasificar las menciones por capacidad conserva lo observado (humo y chat). Borrarlo perdería evidencia que ya existe. |
| D-06 | b | Ya hay una corrida registrada (Anexo F, 2026-10-29). Repetir el ensayo no agrega evidencia, y actualizar sólo REF-196/199 es mínimo y trazable. |
| D-07 | a | Es el cambio menor sobre una estructura ya verificada por compuertas (cabeceras, intervalos). Reordenar obliga a revalidar todo. |
| D-08 | a | Nombra lo que la parte contiene: arquitectura más el SDK que se cita con [REF]. |
| D-09 | a | Es el perfil vigente. El paso «Decisión» enlaza con los ADR, que son la evidencia de cada elección. |
| D-10 | a | La tabla deja la procedencia verificable desde el libro. Sacarla toda a la bitácora corta la trazabilidad. |
| D-11 | d | Objetivo, comando, salida esperada y enlace forman la unidad mínima que se puede reproducir. Un umbral de líneas no se puede verificar como criterio de contenido. |
| D-12 | c | Medir primero. El tope de 44.330 no está justificado frente a lo que se recorta, y votar sin medición sería inventar. |
| D-13 | c | Los fundamentos sostienen todo lo demás. Como parte propia se pueden citar por Id desde el resto. |
| D-14 | c | Diez principios sacados de ADR-01…10: cada uno tiene una fuente verificable. Las listas de 6, 7 u 8 no dicen de dónde salen. |
| D-15 | a | Es una aplicación de mínima agencia, no un principio con evidencia propia. |
| D-16 | b | 1.500 palabras alcanzan para diez principios con su fuente. Es el punto medio que propusieron dos panelistas. |
| D-17 | b | Un Conocimiento autocontenido necesita la regla, su razón y la fuente. Con el Id solo, depende de la guía. |
| D-18 | a | Tiene precedente verificable (el Conocimiento MAUI) y declara la divergencia. Es la opción de cinco panelistas. |
| D-19 | b | Que la ficha dependa de un dictamen la vuelve verificable: no se registra si no hay norma que rija. |
| D-20 | c | El 1 (objetivos) y el 9 (decisiones) son los que anclan los requisitos y los ADR. Siete secciones cubren la trazabilidad. |
| D-21 | b | Exigir el mínimo con criterio explícito (una ADR por capacidad agéntica) se puede comprobar. «Todas» ata el Conocimiento a la guía. |
| D-22 | b | Un Id único y estable simplifica la trazabilidad y el grep. Es la opción de tres panelistas. |
| D-23 | c | Un checklist binario aplicado por un agente sin la guía, más un humano, es la prueba más objetiva de completitud y de autocontención. |
| D-24 | b | El mapeo a OWASP LLM y Agentic da referencias externas verificables para cada riesgo. |
| D-25 | a | 600 líneas se miden directo (`wc -l`). Un porcentaje de la guía cambia cada vez que cambia la guía. |
| D-26 | c | Alcance mínimo: sólo V2, con evidencia completa. V3 y V4 quedan sin inventar. |
| D-27 | b | Un Example sólo existe si hay código que corre. Si el caso no se implementa, el Example sería una promesa sin evidencia. |
| D-28 | a | Lo que hoy se corre es un solo Ollama. Mantener dos papeles describiría un entorno que no se verifica. |
| D-29 | b | Con N-04 abierta no hay evidencia de cierre que justifique un rc. |
| D-30 | a | El PO fijó el nombre explícitamente. F-1 es una norma a dictaminar; mientras tanto se declara la divergencia y no se renombra. |
