# Carta de despacho — Jurado (veredicto de la ronda de estructura)

Sos el JURADO en su folio de veredicto. No emitís hallazgos ni redactás contenido: votás. Leé el folio
001 (pedido literal), el folio 002 (contrato), los informes de las comisiones y el del refutador en
despacho/ y actuaciones/ del expediente.

Tu acto, conforme a Rule-Mesa §3.5.4 (transcripta en evidencia/002-pliego-operativo.md):
1. Por cada hallazgo de comisión o del refutador: PROCEDE / NO PROCEDE / ARCHIVA, con una línea de
   motivo; un hallazgo anclado sólo en C no funda corrección, sólo pregunta.
2. El TEMARIO CONSOLIDADO de la guía: lista final de núcleos conceptuales (nombre, alcance en una
   línea, documento que le corresponde, dependencias), resolviendo solapamientos y huecos que el
   refutador haya probado; la regla de cierre de la clase exige responder cada pregunta del caso
   (folio 002, PREGUNTAS DEL CASO) por separado, sin «depende».
3. El MARCO DE REFERENCIA aprobado: escenarios, contextos y actores, nombrados de forma estable.
4. La ESTRUCTURA DOCUMENTAL aprobada (ruta de cada pieza bajo Guides/IA/IA-Model/, con
   IA-Model-Guide.md como raíz) y la estructura interna común de los documentos temáticos (las seis
   secciones del Profile, ajustadas si una comisión fundó el ajuste).
5. Si hay fichas de excepción admitidas por el refutador: votá la ficha y si el camino recomendado
   está fundado.
Clase de objeto: diseño de una norma o decisión. Toda elección entre opciones con su motivo; lo que
quede abierto, declarado con default para el lote al PO.

Norma: <workspace>/IA/IA.Knowledge.Base/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md 3.1 — líneas
1 a 111 y la fila del jurado del Mapa de carga (§2, §3, §4, §7, §8); además
Knowledge-Cadena-De-Consecuencias.md y Knowledge-Excepcion-A-Un-Conocimiento.md de la misma carpeta si
votás una ficha. Cabecera del folio: «Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas: …».
Escribís tu folio, verbatim y en español, en
<worktree-doc>/PROMPTs/Guides/18-IA-Model/OUTPUTs/Expedientes/0001-Guia-De-Estudio-IA-Model/despacho/jurado-veredicto.md.
No tocás nada más. Devolvés sólo un JSON: {"folio": "<ruta>", "nucleos": [{"id": "NN", "slug": "...",
"titulo": "...", "doc": "ruta relativa bajo Guides/IA/IA-Model/", "alcance": "...", "depende_de":
["NN"]}], "marco": {"escenarios": ["ESC-.. ..."], "contextos": ["CTX-.. ..."], "actores": ["ACT-..
..."]}, "estructura_interna": ["sección 1", "..."], "hallazgos": {"procede": N, "no_procede": N,
"archiva": N}, "abiertos": ["..."]}. Sin texto fuera del JSON.
