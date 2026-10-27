# E01 — lychee 0.24.2 --offline sobre la guía y Examples/ (Lab-Documentos 5d5c2b4 + árbol de trabajo)
Método: comando en contenedor efímero (--rm) · Fecha-hora: 2026-10-26 (tarde, -03:00) · Quién: comisión C-VERIFICACION

Comando: docker run --rm -v <Lab-Documentos>:/repo:ro -w /repo lycheeverse/lychee:0.24.2 --offline --no-progress --include-fragments --exclude-path <Web/bin> --exclude-path <Web/obj> --format detailed "Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/**/*.md"
Salida (código 2 = hay errores):
```text
📝 Summary
---------------------
🔍 Total...........27
🔗 Unique..........23
✅ Successful......15
⏳ Timeouts.........0
🔀 Redirected.......0
👻 Excluded.........1
❓ Unknown..........0
🚫 Errors..........11
⛔ Unsupported.....11

Errors in Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Examples/Prueba-Ayuda-Por-Rol/Consola/Ayuda/administrador/habilitar-cuentas.md
[ERROR] file:///repo/Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Examples/Prueba-Ayuda-Por-Rol/Consola/Ayuda/comun/no-existe.md (at 14:48) | File not found. Check if file exists and path is correct

Errors in Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Examples/Prueba-Ayuda-Por-Rol/Web/Ayuda/en/alumno/enviar-un-trabajo.md
[ERROR] file:///repo/Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Examples/Prueba-Ayuda-Por-Rol/Web/Ayuda/en/alumno/consultar-mis-trabajos.md (at 28:77) | File not found. Check if file exists and path is correct

Errors in Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Examples/Prueba-Ayuda-Por-Rol/Web/Ayuda/en/comun/ingresar.md
[ERROR] file:///repo/Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Examples/Prueba-Ayuda-Por-Rol/Web/Ayuda/en/comun/cambiar-la-contrasena.md (at 13:122) | File not found. Check if file exists and path is correct

Errors in Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Sistema-Documentador-Tecnico-Guide.md
[ERROR] file:///repo/Guides/Documentacion-Tecnica/Documentacion-Tecnica/30-Arquitectura/ADR.md (at 203:161) | File not found. Check if file exists and path is correct
[ERROR] file:///repo/Guides/Documentacion-Tecnica/Documentacion-Tecnica/30-Arquitectura/SAD.md (at 203:218) | File not found. Check if file exists and path is correct
[ERROR] file:///repo/Guides/Documentacion-Tecnica/Documentacion-Tecnica/60-Desarrollo/Change-Log.md (at 590:224) | File not found. Check if file exists and path is correct
[ERROR] file:///repo/Guides/Documentacion-Tecnica/Documentacion-Tecnica/60-Desarrollo/Change-Log.md (at 625:225) | File not found. Check if file exists and path is correct
[ERROR] file:///repo/Guides/Documentacion-Tecnica/Documentacion-Tecnica/95-Transversales/Spec-Driven-Development.md (at 203:941) | File not found. Check if file exists and path is correct
[ERROR] file:///repo/Guides/Documentacion-Tecnica/Documentacion-Tecnica/README.md (at 189:86) | File not found. Check if file exists and path is correct
[ERROR] file:///repo/Guides/Documentacion-Tecnica/Documentacion-Tecnica/README.md (at 432:120) | File not found. Check if file exists and path is correct
[ERROR] file:///repo/Guides/Documentacion-Tecnica/Documentacion-Tecnica/README.md (at 633:9) | File not found. Check if file exists and path is correct

```
