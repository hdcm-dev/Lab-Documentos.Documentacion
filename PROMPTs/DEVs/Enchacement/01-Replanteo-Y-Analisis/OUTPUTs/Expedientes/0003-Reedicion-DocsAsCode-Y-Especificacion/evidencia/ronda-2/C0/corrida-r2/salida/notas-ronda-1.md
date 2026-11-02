# Notas de trabajo, ronda 1 (estado para retomar)

Hecho: inventario en `inventario/` (0-arbol, 1-trazas, 2-version, 3-4-carpetas-y-roles, 5-changelog,
D-07-espacios-de-ids, linea-de-base/resumen.txt). Huella del árbol (sin .git; la carpeta del cuerpo SDEI da
«Permiso denegado» y queda fuera): 117ee288a52bebf72be5c7c313b985c2ab357ab4eff5729d3701d4ea37e73a62.
Huella de conocimiento.md: afd741b838ae2bf457f6d2a6143a079d1d65ee76f1ab55d134f560f7165483e8.

Borrador de decisiones (evidencia ruta:línea dentro de repo/LD):
- D-01 corpus de guías (README.md:17-18; AGENTS.md:45-46); demo FC dentro de CL-10 (Concepts/Framework-Concept/README.md).
  Sin roles con permisos distintos (inventario/3-4: una sola política RequireAuthenticatedUser+sub).
- sitio: no (AGENTS.md:45-46). marco de especificación: no hallado; registro propio doc_id + tools/docs-guard/prefijos.txt.
- topología: mismo repo + hermano `.Documentacion` (CHANGELOG.md:34, :322, :342; tools/docs-guard/arbol.tsv:55).
- organización: pendiente (sin .git): Q-1.
- D-09 existente: .github/workflows/docs-guard.yml:60, :72-81 (herramientas del propio repo al github.sha). El proyecto ES la compuerta de origen: §3.2 no lo resuelve.
- D-10 tabla existente: tools/docs-guard/README.md:148-157 manda. Línea de base medida en inventario/linea-de-base.
  Plataforma: framework-concept-demo.yml:5 dice «fw-ok es el único check requerido de main» (comentario, no API): Q-4.
- D-11 tres delegaciones: CHANGELOG.md:32-39 (exp 0003), :320-326 (exp 0002), :340-346 (exp 0001 FC).
- D-17 existente: docs-enlaces-semanal.yml:17-18 (lunes), tools/docs-guard/README.md:193-199 (qué vigila, 365 días).
- Patrón 5: README.md:11 y Guides/README.md:11 trazan DOC-SDT-0001, obsoleto según CHANGELOG.md:160; archivo no hallado en el árbol legible.

## Ronda 2 (cierre)

Respuestas Q-1…Q-6: «no disponible». Ficha cerrada en `A-01.md` con esos datos como pendientes; artefactos A-08
(`pr-adopcion/descripcion.md`) y A-11 (`CHANGELOG.md`); verificación en `verificacion/` (autoprueba, par rojo/verde,
chequeo de citas vacío). No se abren demandas nuevas.
