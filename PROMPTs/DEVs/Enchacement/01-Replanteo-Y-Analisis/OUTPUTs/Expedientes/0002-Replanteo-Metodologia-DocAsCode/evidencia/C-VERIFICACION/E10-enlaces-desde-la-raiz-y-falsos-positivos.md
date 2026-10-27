# E10 — Enlaces desde la raíz del workspace con `--root-dir`, y falsos positivos de E01
Método: comando en contenedor efímero (--rm) y lectura de fuentes · Fecha-hora: 2026-10-26 (noche, -03:00) · Quién: comisión C-VERIFICACION

## 1. `--root-dir` resuelve la forma D6 (una variable: la opción)
Comando: docker run --rm -v <workspace>:/ws:ro -w /ws/LAB/Lab-E2E.WebBlazor/Lab-E2E.WebBlazor.Documentacion lycheeverse/lychee:0.24.2 --offline --no-progress [--root-dir /ws] --format detailed README.md
```text
sin --root-dir: Total 39 · Successful 12 · Errors 26 · incluye «[ERROR] error: (at 104:1) | Cannot resolve root-relative link 'KB-privada/Knowledges/Knowledge-Conformacion-Pull-Request-Automatico.md'» · exit=2
con --root-dir: Total 39 · Successful 13 · Errors 25 · el enlace de 104:1 resuelve · exit=2 (quedan los rotos de topología vieja, E03)
```
Prueba negativa (dos archivos sintéticos, una línea cada uno):
```text
ok.md   [k](KB-privada/Knowledges/Knowledge-Conformacion-Pull-Request-Automatico.md)  --root-dir con el workspace montado → exit=0
roto.md [k](KB-privada/Knowledges/No-Existe.md)                                       --root-dir con el workspace montado → exit=2
ok.md   con --root-dir apuntando a una carpeta SIN el workspace (como un checkout de CI)           → exit=2
```
Lectura: la cita desde la raíz (D6) es verificable sólo donde está el árbol del workspace (runner con los repos hermanos, o equipo del autor); en un checkout aislado da rojo aunque el enlace sea bueno.

## 2. Los 3 errores de Examples/ en E01 no son deuda
```text
Examples/Prueba-Ayuda-Por-Rol/README.md:59 → «Enlace a una página inexistente | administrador/habilitar-cuentas.md → comun/no-existe.md | Sí» (defecto PLANTADO a propósito)
Sistema-Documentador-Tecnico-Guide.md:455 → «Si la página no está traducida, se sirve la del idioma fuente con un aviso visible … nunca un 404»
Web/HelpCatalog.cs:25 → record HelpResult(..., bool IsFallback)
```
Los dos rotos de `Web/Ayuda/en/` apuntan a páginas que sólo existen en `es/` y que el catálogo sirve por respaldo de cultura: lychee los marca porque no conoce el respaldo. Deuda real de enlaces en el alcance de E01: los 8 de la guía hacia `../Documentacion-Tecnica/…` (profundidad equivocada).
