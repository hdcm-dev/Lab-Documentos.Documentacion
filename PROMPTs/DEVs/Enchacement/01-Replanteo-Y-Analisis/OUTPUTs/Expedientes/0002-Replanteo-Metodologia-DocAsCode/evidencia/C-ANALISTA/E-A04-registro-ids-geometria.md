# E-A04 — Registro de identificadores CU/RN en Lab-Geometria y trazas que no resuelven

Fecha-hora: 2026-10-26T15:09-03:00 · Quién: comisión C-ANALISTA · Raíz: /PROG2/Geometria/Lab-Geometria/ · sólo lectura
```
$ git log --oneline -1; git tag | tail -3
4b114d7 Merge pull request #233 from hdcm-dev/mesa/2026-09-15-decisiones-delegadas
v1.1.1
v1.1.2
v1.2.0
$ find SDD -name 'CU-*' -not -path '*_legacy*' | prefijo de dos dígitos | uniq -c
     13 00
     10 06
      8 08
     10 10
      7 12
$ find SDD -name 'RN-*' -not -path '*_legacy*' | sed id
RN-02001 RN-02002 RN-02003 RN-02004 RN-02005 RN-02006 RN-02007 RN-02008 RN-02009 RN-02010 RN-02011 RN-02012 RN-02013 RN-02014 RN-02015 RN-02016 
$ ¿existe documento para los ids citados por la guía y por CU-10005?
CU-00026 documentos=1
CU-10005 documentos=1
RN-02005 documentos=1
RN-10003 documentos=0
$ grep -c 'RN-100' SDD/Intake/PRODUCT-INTAKE-Fabrica-De-Geometria.md
0
$ citas a RN-100NN en el árbol SDD vigente (sin _legacy)
     26 RN-10001      15 RN-10002      17 RN-10003      20 RN-10004      19 RN-10005      23 RN-10006      16 RN-10007      24 RN-10008      23 RN-10009      13 RN-10010      26 RN-10011      24 RN-10012      63 RN-10013      12 RN-10014      10 RN-10015      69 RN-10016 
$ archivos .cs de src/ y tests/ que citan RN-100 / RN-020
RN-100: 0  RN-020: 10
$ grep -n 'Versión' de los dos CU
CU-10005:5:**Versión:** 1.2
CU-00026:6:**Versión:** 1.1
$ Experiencia-De-Uso.md:456 (recorte)
| Reglas de negocio relevantes | `RN-10001` a `RN-10016`, que viven en `GeometriaFactory-Domain` y se referencian por identificador. Condicionan la presentación `RN-10003`, `RN-10004`, `RN-10005`, `R
$ git log --oneline -S'RN-10003' -- SDD | tail -1   # primer commit que lo introduce
841cd5b docs(sdd): pasada de renumeración de identificadores, migración 6.0 a 8.2
```

Guía: /LAB/Lab-Documentos/Lab-Documentos/Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Sistema-Documentador-Tecnico-Guide.md:11 declara 'traces: [DOC-ADR, DOC-ADR, DOC-SAD, DOC-SRS, DOC-MANUAL, DOC-SDD]' (tipos, no instancias; DOC-ADR repetido) y :407 el ejemplo '[CU-00026@1.1, RN-02005]'.

## Correspondencia por título RN-100NN (citado en la unidad Web) ↔ RN-020NN (documento en la unidad Api)
```
RN-10001` (administrador único y papeles fijos)  <->  RN-02001-Administrador-Unico-Y-Papeles-Fijos.md
RN-10002` (correo único)  <->  RN-02002-Correo-Del-Alumno-Unico.md
RN-10003` (trabajo ajeno indistinguible de inexistente)  <->  RN-02003-Trabajo-Ajeno-Indistinguible-De-Inexistente.md
RN-10004` (eliminación acotada al borrador)  <->  RN-02004-Eliminacion-Acotada-Al-Borrador.md
RN-10005` (sin errores de validación no hay paso a estado `Pendiente`; corta hoy en el envío)  <->  RN-02005-Finalizacion-Sin-Errores-De-Validacion.md
RN-10008` (texto conservado íntegro)  <->  RN-02008-Texto-Original-Conservado-Integro.md
```
Lectura (criterio propio, verificado en 6 de 16): es la misma regla con dos identificadores; el de la unidad Web no tiene documento.
