# E04 — Matriz de pruebas negativas: un defecto plantado por variante, siete validadores
Método: comando en contenedor efímero (--rm) · Fecha-hora: 2026-10-26 (tarde, -03:00) · Quién: comisión C-VERIFICACION

Corpus mínimo de dos documentos que pasa todo (limpio). Cada variante cambia UNA cosa (diff de 1 a 3 líneas). Celda = código de salida del validador: 0 verde, ≠0 rojo (lychee usa 2).

Validadores: enlaces = lychee 0.24.2 --offline --include-fragments; fm-esq = remark-cli 12.0.1 + remark-frontmatter 5.0.0 + remark-lint-frontmatter-schema 3.15.4 --frail con herramientas/cuerpo.schema.json; cita-ln = herramientas/cita-linea.mjs; ocultos = herramientas/ocultos.mjs; url-fch = herramientas/url-fecha.mjs; mdlint = markdownlint-cli2 0.18.1 con herramientas/.markdownlint-cli2.jsonc; mermaid = herramientas/mermaid-parse.mjs (mermaid 11.4.1 + jsdom 25.0.1). Node 24.21.0.
```text
corpus               enlaces fm-esq  cita-ln ocultos url-fch mdlint  mermaid
limpio               0       0       0       0       0       0       0      
v1-enlace-roto       2       0       0       0       0       0       0      
v2-sin-doc-id        0       1       0       0       0       0       0      
v3-cita-sin-linea    0       0       1       0       0       0       0      
v4-inyeccion         0       0       0       1       0       0       0      
v5-url-sin-fecha     0       0       0       0       1       0       0      
v6-ancla-rota        2       0       0       0       0       0       0      
v7-salto-de-nivel    0       0       0       0       0       1       0      
limpio-mermaid       0       0       0       0       0       0       0      
v8-mermaid-roto      0       0       0       0       0       0       1      
```

Defectos plantados: v1 enlace a no-existe.md; v2 sin doc_id; v3 cita /IA/... sin :línea; v4 comentario HTML con instrucción + carácter de ancho cero; v5 URL sin «consultado el»; v6 ancla inexistente; v7 salto ## → ####; v8 corchete sin cerrar en un nodo mermaid.
