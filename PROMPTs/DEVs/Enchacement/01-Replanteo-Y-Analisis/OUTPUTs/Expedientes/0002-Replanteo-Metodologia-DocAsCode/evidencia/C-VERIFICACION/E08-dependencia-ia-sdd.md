# E08 — Clon limpio del repo de código del SDD-B y la dependencia no vendorizada de IA.SDD (d4035aa = origin/main)
Método: comandos git/find locales y curl · Fecha-hora: 2026-10-26 (tarde, -03:00) · Quién: comisión C-VERIFICACION

Privacidad: el repo del SDD-B no se nombra; se clonó desde su copia local a <intermedios>/q35/clon (git clone --no-hardlinks) y se borró al terminar.

## 1. Qué cita el SDD-B del framework (git grep de nombres de reglas, por apariciones)
```text
Mesa-Rules.md 202 · Rules-Base-Conocimiento.md 51 · Expediente-Rules.md 47 · Root-Rules.md 20 · Maqueta-Rules.md 15 · Rules-Devops.md 12 · Deriva-Rules.md 12 · Rules-Examples.md 8 · Rules-Arquitectura-Tecnica.md 6 · Rules-UX-UI-DX.md 3 · Rules-Backlog-Tecnico.md 3 · Intake-Rules.md 3 · Rules-Especificacion-Funcional.md 2 · Rules-Calidad-Y-Pruebas.md 2
Forma de la cita: por nombre de archivo y §, sin ruta ni versión (p. ej. «`Root-Rules.md` §14 (reintegración)», _convenciones_comunes.md:74-75 del SDD-B)
```
## 2. Resolución (columnas: nombre · archivos en el clon limpio · archivos homónimos en IA.SDD · ruta canónica)
```text
Mesa-Rules.md                      0  16  SDD/Devs/Rules/Mesa-Rules.md
Rules-Base-Conocimiento.md         0  25  SDD/Devs/Rules/Rules-Base-Conocimiento.md
Expediente-Rules.md                0  5   SDD/Devs/Rules/Expediente-Rules.md
Root-Rules.md                      0  73  SDD/Devs/Rules/Root-Rules.md
Maqueta-Rules.md                   0  73  SDD/Devs/Rules/Maqueta-Rules.md
Rules-Devops.md                    0  73  SDD/Devs/Rules/Rules-Devops.md
Deriva-Rules.md                    0  73  SDD/Devs/Rules/Deriva-Rules.md
Rules-Examples.md                  0  73  SDD/Devs/Rules/Rules-Examples.md
Rules-Arquitectura-Tecnica.md      0  73  SDD/Devs/Rules/Rules-Arquitectura-Tecnica.md
Rules-UX-UI-DX.md                  0  73  SDD/Devs/Rules/Rules-UX-UI-DX.md
Rules-Backlog-Tecnico.md           0  73  SDD/Devs/Rules/Rules-Backlog-Tecnico.md
Intake-Rules.md                    0  73  SDD/Devs/Rules/Intake-Rules.md
Rules-Especificacion-Funcional.md  0  73  SDD/Devs/Rules/Rules-Especificacion-Funcional.md
Rules-Calidad-Y-Pruebas.md         0  73  SDD/Devs/Rules/Rules-Calidad-Y-Pruebas.md
```
Homónimos de Root-Rules.md en IA.SDD: 1 en SDD/Devs/Rules y 72 en _legacy/<versión>/ (git ls-files | grep -c 'Root-Rules.md$' = 73): sin ruta y versión, el nombre es ambiguo aun con IA.SDD al lado.

## 3. Alternativas probadas (una variable: cómo llega la dependencia)
```text
A  submódulo fijado en d4035aa (vendor/IA.SDD): clon sin --recurse-submodules resuelve 0/14; con --recurse-submodules 14/14; .git/modules = 21M
B  copia del subconjunto SDD/Devs/Rules (22 archivos, 1,2M) + MANIFIESTO (origen, commit, sha256): 14/14 sin red
   deriva-vendor.sh contra el upstream: verde exit=0; tras tocar Root-Rules.md: «DERIVA SDD/Devs/Rules/Root-Rules.md» exit=1
   cierre de dependencias del subconjunto: de 36 referencias internas de SDD/Devs/Rules, 15+ caen fuera del subconjunto (Templates/, References/Design/, Docs/…)
C  copia de SDD/ + Templates/ + Conocimiento/ + README.md por git archive d4035aa (125 archivos, 3,6M): 14/14 sin red; cierre 27/36
   las 9 restantes no son dependencias faltantes: 7 son artefactos del proyecto destino (SDD/Docs/CHANGELOG.md, …) o subcadenas de Design-Rules-*.md (presentes),
   y 2 (Template-Sprint-Review.md, Template-Sprint-Retrospectiva.md) no existen tampoco en el upstream (Rules-Plan-Sprint.md:59, :174 los nombran)
Permalink https://github.com/hdcm-dev/IA.SDD/blob/<sha>/SDD/Devs/Rules/Root-Rules.md → HTTP 200; API: private=false, size=4288 KB
```
