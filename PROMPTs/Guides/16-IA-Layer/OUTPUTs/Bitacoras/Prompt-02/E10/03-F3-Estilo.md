# E10 · Fase 3 de 6 — Corrección de estilo (Comisión B, P-08)

**Fecha:** 2026-11-02 · **Alcance:** libro, Conocimiento y README de `Examples/` · **Contenido congelado** desde F2 (C-4.3): sólo se toca la expresión.

## 1. Criterios

Español claro rioplatense; voz según HE-09 (impersonal en la explicación, voseo para indicar qué hacer); frases de longitud manejable (barrido de oraciones de ≥ 45 palabras en prosa); términos: HE-02/HE-03 (patrón en inglés, dominio en español) y acta de terminología.

## 2. Barridos

| Control | Resultado |
|---|---|
| Tuteo (`puedes`, `tienes`, `debes`, …) | 1 coincidencia: README 01, l. 108, «debes cargar», dentro de un bloque `text` con la salida literal del modelo. No se toca (es evidencia). |
| Voseo en el libro (HE-09) | En objetivos (§0.1, §0.3), tablas de decisión, ejercicios del Anexo B y respuestas de preguntas formuladas en primera persona («¿Cómo pruebo…?», «¿Por qué mi modelo…?»). Coherente con HE-09: 0 mezclas dentro de un párrafo explicativo. |
| Oraciones ≥ 45 palabras | 7 en libro + Conocimiento; se partieron 3 (ver §3). Las otras 4 (l. 1478, 2104, 4402 y la primera de 2315) son definiciones con cita textual y traducción: partirlas separa la cita de su glosa. Quedan como P2. |
| Dominio en inglés (Locality, Survey, Province…) | 0 en prosa (la única, «Survey», es título de REF-15). |
| Terminología del acta | Conocimiento l. 346–347 ya conforme; libro y README no hablan del contenedor nativo. |

## 3. Cambios (libro)

1. §(l. 801) «Lo que la prueba no ve»: antes «…(`Cableado/MutacionesTests.cs`): un tipo … no se ve leyendo la firma y sí leyendo el IL, uno nombrado…» → después «…(`Cableado/MutacionesTests.cs`). Un tipo … no se ve en la firma, pero sí en el IL; uno nombrado…».
2. ADR-02 (l. 1165): antes «el libro usa la segunda, muestra la tercera…» → después «el libro usa la segunda. Muestra la tercera…».
3. Inyección de prompt (l. 2315): antes «la indirecta llega por el `Nombre` … (en CTX-PROD …, también por lo que cargó otra persona), por la ayuda o por un resultado MCP.» → después «la indirecta llega por la ayuda, por un resultado MCP o por el `Nombre` … : texto que escribió una persona y no la aplicación (en CTX-PROD …, también otra persona).»

Conocimiento y README: sin cambios. sha256 del libro: `8e208c61043f92b3d2bf8d7f224a74f0b64597404e5f03a31c59ec034c97a316`.

## 4. Compuertas (después del cambio)

| Compuerta | rc | Resultado |
|---|---|---|
| `tools/contar.sh` | 0 | 59.334/60.000 (−4); Anexos 12.998/13.000 |
| `verificar-markdown.py` guia · ejemplos · arbol | 0 · 0 · 0 | — |
| `compuerta-referencias.sh` | 0 | 0 rotas en 21 archivos |
| `compuerta-intervalos.py <libro> Bitacoras/Evidencia/R-LLM` | 0 | 28/28; 21/21 |
| `compuerta-cabeceras.sh Bitacoras/Evidencia` | 0 | 0 en 2 cuerpos |
| `compuerta-rpriv.sh` libro, Examples, Conocimientos | 0 | 0 hallazgos |
| `mermaid.sh` / docs-guard | — | no corresponde: ningún bloque mermaid tocado; va en F5 |

## 5. Para fases siguientes (P2)

1. **F4 (HE-01):** Conocimiento l. 346 lleva comillas rectas en "cascarón" (texto del acta); en prosa correspondería «cascarón». No se cambia en F3 porque es ortotipografía; F4 decide sin reabrir el acta.
2. **F4:** formato de IC dispar (`[0,692; 1]` vs `[0,590; 1,000]`), ya anotado en F2.
3. README 10 (l. 33) y 04 (l. 68): enumeraciones de 57–61 palabras en una oración; legibles como lista, se dejan. Si F5 las quiere en viñetas, no cambia contenido.
4. Oraciones largas con cita textual (l. 1478, 2104, 2315, 4402): sin partir para no separar cita y traducción.

## 6. Mensajes ajenos

Ninguno.
