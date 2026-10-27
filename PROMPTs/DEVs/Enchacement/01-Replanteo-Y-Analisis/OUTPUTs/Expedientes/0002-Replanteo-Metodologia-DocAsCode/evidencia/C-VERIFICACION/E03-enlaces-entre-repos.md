# E03 — Enlaces entre repositorios: checkout aislado frente a árbol del workspace (Lab-E2E.WebBlazor.Documentacion c63b571)
Método: comando en contenedor efímero (--rm) · Fecha-hora: 2026-10-26 (tarde, -03:00) · Quién: comisión C-VERIFICACION

Variable única: qué se monta. A = sólo el repo (como un checkout de CI). B = carpeta LAB/ del workspace (repos hermanos visibles).
Comando: docker run --rm -v <repo|LAB>:...:ro lycheeverse/lychee:0.24.2 --offline --no-progress --exclude-path bin --exclude-path obj --exclude-path node_modules --format detailed "**/*.md"
```text
A (sólo repo):
🔍 Total..........520
✅ Successful.....485
🚫 Errors..........33
B (workspace):
🔍 Total..........520
✅ Successful.....488
🚫 Errors..........30

Archivos con errores (A):
Errors in PROMPTs/Analisis/02-Paginas-Authorized/OUTPUTs/Notas.md
Errors in README.md

Destinos rotos en A y no en B (resuelven sólo con el repo hermano al lado): 3 apariciones
Lab-E2E.WebBlazor

Rotos en A y en B (la ruta relativa supone una topología que ya no existe; 29 apariciones). Ejemplos:
Lab-Documentos.Documentacion/Guides/E2E-Guide/Beginner-Guide.md
Lab-Documentos.Documentacion/Guides/E2E-Guide/Quick-Guide-ABM.md
Lab-Documentos/Guides/Testing/Lab-E2E.WebBlazor-Guides
Lab-Documentos/Guides/Testing/Lab-E2E.WebBlazor-Guides/E2E-Guide
Lab-Documentos/Guides/Testing/Lab-E2E.WebBlazor-Guides/E2E-Guide/Beginner-Guide.md
```

La entrada restante de A, «error:», es un enlace desde la raíz del workspace (forma de D6) que lychee no puede resolver en un checkout:
```text
[ERROR] error: (at 104:1) | Cannot resolve root-relative link 'KB-privada/Knowledges/Knowledge-Conformacion-Pull-Request-Automatico.md': To resolve root-relative links in local files, provide a root dir
```
