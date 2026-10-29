# 03 — Criterio 2 y 3: línea de base y pruebas negativas de url-fecha

Copia descartable del árbol de trabajo de la rama, sin .git; --raiz explícita.

## 3.1 Cuerpo nuevo tal como queda (criterio 2)
```text
== PR-7 url-fecha: verde (errores=0 avisos=33) documentos-que-bloquean=41
rc=0
avisos en GUIA (obsoleta): 33
  de ellos url-sin-fecha: 5  dominio-sin-referencia: 28
```

## 3.2 Negativa A: GUIA vuelve a borrador (sin la exención por obsoleto)
```text
== PR-7 url-fecha: ROJO (errores=33 avisos=0) documentos-que-bloquean=42
rc=1
rc=1
```

## 3.3 Negativa B: se planta una cita por dominio en code span en TEM-03 (lo que el aviso heredado no veía)
```text
Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/TEM-03-Topologia-Y-Versionado.md:328: ERROR dominio-sin-referencia: docusaurus.io/docs/versioning
== PR-7 url-fecha: ROJO (errores=1 avisos=33) documentos-que-bloquean=41
rc=1
-- el aviso heredado (dg.py avisos) sobre la misma línea:
== avisos url-fecha y cita-linea: verde (errores=0 avisos=0)
```

## 3.4 Negativa C: con fecha de consulta en el mismo párrafo vuelve a verde
```text
== PR-7 url-fecha: verde (errores=0 avisos=33) documentos-que-bloquean=41
```

## 3.5 Negativa D: URL con esquema sin fecha en un anexo del cuerpo
```text
Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/99-Anexos/Glosario.md:80: ERROR url-sin-fecha: https://keepachangelog.com/es-ES/1.1.0/
== PR-7 url-fecha: ROJO (errores=1 avisos=33) documentos-que-bloquean=41
```

## 3.6 Fixtures de la autoprueba (criterio 3)
```text
-- fixtures/url-fecha/rojo
a.md:3: ERROR dominio-sin-referencia: mintlify.com/docs/quickstart
a.md:5: ERROR url-sin-fecha: https://documentation.onesignal.com/reference/create-user
a.md:9: ERROR dominio-sin-referencia: diataxis.fr
a.md:10: ERROR dominio-sin-referencia: writethedocs.org/guide/docs-as-code/
== PR-7 url-fecha: ROJO (errores=4 avisos=0) documentos-que-bloquean=2
rc=1
-- fixtures/url-fecha/verde
== PR-7 url-fecha: verde (errores=0 avisos=0) documentos-que-bloquean=2
rc=0
-- fixtures/url-fecha/obsoleto
a.md:16: aviso dominio-sin-referencia: mintlify.com/docs/quickstart
a.md:17: aviso url-sin-fecha: https://documentation.onesignal.com/reference/create-user
== PR-7 url-fecha: verde (errores=0 avisos=2) documentos-que-bloquean=1
rc=0
```
