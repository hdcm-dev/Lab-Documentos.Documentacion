# E06 — Resolución de trazas ID@versión de la ayuda de Examples/ contra el SDD de Lab-Geometria (4b114d7)
Método: comando local o en contenedor efímero (--rm) · Fecha-hora: 2026-10-26 (tarde, -03:00) · Quién: comisión C-VERIFICACION

Comando: herramientas/traces-resolve.sh <corpus>/Examples/Prueba-Ayuda-Por-Rol/Web/Ayuda <workspace>/PROG2/Geometria/Lab-Geometria/SDD
```text
Examples/Prueba-Ayuda-Por-Rol/Web/Ayuda/es/comun/cambiar-la-contrasena.md: CU-00022@1.1 → unidad GeometriaFactory-Api, versión 1.1: UNIDAD NO ES DE PANTALLA
Examples/Prueba-Ayuda-Por-Rol/Web/Ayuda/es/comun/cambiar-la-contrasena.md: CU-00024@1.1 → unidad GeometriaFactory-Api, versión 1.1: UNIDAD NO ES DE PANTALLA
Examples/Prueba-Ayuda-Por-Rol/Web/Ayuda/es/comun/ingresar.md: CU-00022@1.1 → unidad GeometriaFactory-Api, versión 1.1: UNIDAD NO ES DE PANTALLA
Examples/Prueba-Ayuda-Por-Rol/Web/Ayuda/es/alumno/consultar-mis-trabajos.md: CU-00028@1.1 → unidad GeometriaFactory-Api, versión 1.1: UNIDAD NO ES DE PANTALLA
Examples/Prueba-Ayuda-Por-Rol/Web/Ayuda/es/alumno/consultar-mis-trabajos.md: CU-00029@1.1 → unidad GeometriaFactory-Api, versión 1.1: UNIDAD NO ES DE PANTALLA
Examples/Prueba-Ayuda-Por-Rol/Web/Ayuda/es/alumno/enviar-un-trabajo.md: CU-00026@1.1 → unidad GeometriaFactory-Api, versión 1.1: UNIDAD NO ES DE PANTALLA
Examples/Prueba-Ayuda-Por-Rol/Web/Ayuda/es/administrador/gobernar-las-cuentas.md: CU-00023@1.1 → unidad GeometriaFactory-Api, versión 1.1: UNIDAD NO ES DE PANTALLA
Examples/Prueba-Ayuda-Por-Rol/Web/Ayuda/es/administrador/dar-desenlace.md: CU-00029@1.1 → unidad GeometriaFactory-Api, versión 1.1: UNIDAD NO ES DE PANTALLA
Examples/Prueba-Ayuda-Por-Rol/Web/Ayuda/es/administrador/resetear-una-contrasena.md: CU-00024@1.1 → unidad GeometriaFactory-Api, versión 1.1: UNIDAD NO ES DE PANTALLA
exit=1  (el script sale 1 si alguna traza falla)
```

Pruebas negativas (página sintética con una traza; CU-10005 tiene «**Versión:** 1.2»):
```text
ok (CU-10005@1.2) exit=0
desfase (CU-10005@0.9) exit=1
inexistente (CU-19999@1.2) exit=1
```
