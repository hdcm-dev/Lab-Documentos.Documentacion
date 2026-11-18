# Bitácora 01 — Integración de la guía de diseño conversacional (2026-11-11)

- **Armado:** worktree `guia-conversacional/v1` desde `origin/main` (e766cb3). La guía se armó con cap-00 a cap-20 en el orden de `estructura.md`. Se agregaron el front matter (versión 1.0.0), el texto del prólogo y las cabeceras de Parte I, II, IV, V y del Cierre; la de Parte III ya venía en c7.
- **Correcciones de composición:** `#anexo-a3` pasó a `#anexo-a-3` y `#a-n` a `#anexo-a-n`. El tope de palabras subió de 30 000 a 60 000, porque la guía mide unas 55 600 palabras; el plan pide revisarlo en la relectura de compresión.
- **Comprobaciones:**
  - Anclas internas: ninguna rota y ninguna duplicada.
  - Vínculos a la guía 16: 9 de 9 resuelven.
  - Referencias: REF-001 a REF-013, completas en los dos sentidos.
  - Búsqueda de nombres privados: cero apariciones.
- **Mermaid:** los 25 diagramas quedaron NO EJECUTADOS, porque Chromium falló al arrancar en mermaid-cli.
- **README y CHANGELOG:** `Guides/README.md` lista carpetas, no guías, así que no se tocó. Se sumó una entrada al CHANGELOG.
- **Commit:** a0bbcbd en `guia-conversacional/v1`, con push hecho. Cuerpo del PR en `/vm/wt/PR-guia-conversacional.md`.

## 2026-11-11 · Integración de la guía reorientada (lector académico)

- **Encuadre.** Los capítulos 0 a 20 se reescribieron para estudiantes, docentes y profesionales. Movilidad Urbana, Geometría y PushDispatch (diseñado desde cero) quedan como casos ilustrativos. Lo específico de la integración real queda en las notas `para-el-tecnico-NN.md` del scratchpad, que van al documento técnico privado del producto.
- **Ensamblado.** La guía se armó en la rama `guia-conversacional/v1`, que se actualizó con `origin/main`:
  - Contenido: frontmatter 1.0.0, encabezados de Parte I a V y Cierre, y los anexos A a H.
  - Tamaño: 3859 líneas y unas 59 mil palabras, dentro del tope de 60 mil.
- **Correcciones.**
  - Anclas: `#a-N` y `#anexo-a3` pasaron a `#anexo-a-N`.
  - Texto: se corrigió el de un vínculo a §9 de la guía de capa de IA.
  - Frontmatter: `audience` y `description` se ajustaron al esquema.
- **Comprobaciones.**
  - Anclas internas: todas existen y ninguna está duplicada.
  - Vínculos a la guía de capa de IA: todos existen en `origin/main`.
  - Referencias: cada REF citada está en el Anexo D y cada una del anexo se cita.
  - Nombres privados: 0 coincidencias.
  - docs-guard: esquema y enlaces en verde. MD025 sigue en rojo por los encabezados de Parte; la guía de capa de IA da el mismo aviso.
- **Pendiente.** Contrastar con sus casos de origen los ejemplos de Movilidad Urbana y Geometría que se redactaron como ilustración en c1, c8, c15 y c17.

## 2026-11-11 · Correcciones de las lentes (commit 79027595)

- **Altos y medios corregidos:** rutas de lectura con la Parte II; coherencia de E0 con el caso PushDispatch; persona, voz y tono (§6.4.1, A.8); reparación del diálogo (§6.4.2); contexto entre turnos (§6.4.3); canal humano como destino (§3, A.4, A.7); autor de REF-008.
- **Bajos atendidos:** §1.4 apunta a c17 y c18; vínculos unificados «§N»; P-5 duplicada; REF-004 reemplazada por REF-016 en frases de activación; fecha de consulta en todas las REF; accesibilidad y entrada adversaria en c13.
- **Referencias nuevas verificadas con WebFetch:** REF-014 Google Errors (2024-09-18), REF-015 Google Create a persona (2024-09-18), REF-016 Copilot Studio Set topic triggers (ms.date 2026-11-09), REF-017 Copilot Studio Hand off to a live agent (ms.date 2026-04-30).
- **Comprobaciones:** check.py en verde; docs-guard verde con avisos; nombres privados 0; mermaid NO EJECUTADO (timeout). Tope de palabras 65 000 (60 714 palabras).
- **Pendiente:** contrastar los ejemplos de Movilidad Urbana y Geometría con la guía 16; roles del caso quedan como ilustrativos; MD025 igual que la guía 16.
