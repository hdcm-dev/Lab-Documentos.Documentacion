# Bitácora: conocimientos K6 y K7

## 2026-11-11 · Corrección tras las lentes y la prueba a ciegas

- **Encargo:** corregir los defectos altos y medios de las tres lentes y los 24 huecos de `prueba-ciega-k6-k7.md`.
- **Worktree:** `/vm/wt/ld-conocimientos-2`, rama `conocimientos/rag-funciones-testing`, commit `2faca0e` (pusheado). Cuerpo del PR en `/vm/wt/PR-conocimientos-2.md`.
- **Fuentes verificadas en PushDispatch (origin/main):**
  - `BuscadorDeAyudaLexico`: lista `Comunes` a mano, raíz de seis letras, `::: roles` separado por espacio o coma.
  - `PaginaDeAyuda`: una página sin `status:` cuenta como vigente; el campo admite también `retirado`.
  - `PoliticaDeLectura`: sin `roles`, la página la lee todo el panel.
  - Fixture `sin-audiencia.md`: es una página sin `delivery`, que queda fuera del catálogo.
  - `DefinicionDeDestino`: tiene una sola `Politica` y no tiene campo de instancia.
  - `RedaccionConAnclaje`: `UmbralCoseno` vale 0,62.
  - `MotivoDeConsultaApagada`: lista cerrada de seis motivos.
- **Decisiones:**
  - H-1: K7 pasa a `status:`.
  - H-15: queda una sola política (la de ver), fiel al producto. El hacer se revalida con el criterio único de K6 §16, y las dos políticas quedan como propuesta.
  - H-10, H-11 y H-13 (fechas, horas e instancia): quedan como extensiones rotuladas y listadas en Límites.
  - Los demás huecos se resolvieron en el texto.
  - K6 y K7 suben a 1.1 con una fila de historial; el README queda actualizado.
- **Comprobaciones:** `scripts/ci-local.sh` con enlaces, ai y estructura en verde. Queda un aviso AI-3 previo: es la frase adversa citada. La búsqueda de vocabulario prohibido dio cero resultados.
- **Pendiente:** abrir y fusionar el PR, con conformación automática.
