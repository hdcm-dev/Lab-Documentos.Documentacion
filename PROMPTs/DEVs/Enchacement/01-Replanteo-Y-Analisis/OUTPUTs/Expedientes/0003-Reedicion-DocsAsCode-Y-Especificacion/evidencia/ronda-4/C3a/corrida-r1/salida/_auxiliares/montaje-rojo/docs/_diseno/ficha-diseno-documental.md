---
doc_id: FIC-DISENO-DOCUMENTAL
doc_type: ficha
title: Ficha de diseño documental de Colmenar
description: Decisiones, catálogo activo, audiencias y artefactos del sistema documentador de Colmenar (A-01). Borrador.
status: borrador
origin: ia-assisted
confidence: media
owner: pendiente (D-11)
last_review: 2026-11-02
audience: [desarrollo, po, agente]
traces: []
---

# Ficha de diseño documental — Colmenar

Numeración fija: 1 Inventario, 2 Decisiones, 3 Catálogo activo, 4 Decisiones de clase H para una persona, 5 Audiencias
y entrega, 6 Artefactos A-02 a A-13, 7 Lo que el conocimiento no resolvió, 8 Verificación. Envoltorio de comandos:
`./aislado` (cada comando de §1 y §8 va tal como corrió, con el envoltorio). Las citas ruta:línea son relativas a la
raíz del repositorio leído (`repo/proyecto` en la corrida). Los auxiliares con la salida completa están en
`salida/_auxiliares/`, uno por comando (`inventario-NN.txt`); el guion del inventario es
`salida/_auxiliares/inventario.sh`, y se corrió así: `./aislado bash salida/_auxiliares/inventario.sh`.

| Campo | Valor |
| --- | --- |
| Proyecto y repositorios leídos, con SHA (sin `.git`: «SHA: pendiente» y huella del árbol con `LC_ALL=C`, comando 11, §2.4) | Colmenar, un repositorio (`repo/proyecto`), rama `main`, SHA `d39dfbd4d113794fc0edca9f6d16739b51a502f3`, árbol limpio (0 cambios). Huella del árbol (comando 11): `dba3b7dacbfa86751cb88e646769d910f171023885b6b5dcc363e3fe4c3c6cca`. Evidencia: `inventario-11.txt` (`git rev-parse HEAD`, `git status --short` con 0 líneas) y `./aislado bash -c 'cd repo/proyecto; git branch -a'` → `* main`, `remotes/origin/main`. Los repositorios hermanos que nombra el README (API privada, paquete, sitio) no llegaron |
| Carpetas excluidas o sin lectura (`{excluidas}`, nombres de carpeta a cualquier profundidad, separados por espacios) | ninguna (`{excluidas}` vacía: el árbol recibido no tiene carpetas excluidas ni sin permiso de lectura) |
| Fecha (salida de `date -u +%F`, comando 10) | 2026-11-02 (comando 10, `inventario-10.txt`; coincide con `montaje.txt`: «fecha del ensayo: 2026-11-02 — ronda 4») |
| Quién aplica (el rol, no un nombre) | aplicador |
| Conocimiento aplicado (alias, versión, huella) | DocsAsCode-Designing-Specification, 1.4, SHA-256 `cc489f3e84f53b869af4eb597c60f35fb801b383c3923d7856785e8cda51aede` (`./aislado bash -c '... sha256sum ... conocimiento.md'`) |

## 1. Inventario (paso 1)

Cada comando es una línea de `salida/_auxiliares/inventario.sh` (el bloque de §3.1 con `{excluidas}` vacía), corrido
desde `repo/proyecto` con `./aislado bash salida/_auxiliares/inventario.sh`; la salida completa, en el auxiliar.

| Patrón de §3.1 | Comando | Cuenta | Salida o ruta a la salida |
| --- | --- | --- | --- |
| ID declarado más de una vez | 1: `python3 /corrida/compuerta/tools/docs-guard/dg.py trazas --raiz . .`; 1b: `command grep -rIhoE "${X[@]}" --include="*.md" -e "^doc_id: *[A-Z][A-Z0-9]*(-[A-Z0-9]+)+" -e "^#{1,6} +…" . \| sed -E … \| sort \| uniq -cd` | 0 | 1: `== PR-5 traces-resolve: verde (errores=0 avisos=0) trazas=0 resueltas=0 ids-duplicados=0`, rc=0 (`inventario-01.txt`); 1b: salida vacía, rc=0 (`inventario-01b.txt`) |
| Versión declarada dos veces | 2: `command grep -rlE "${X[@]}" "^version:" --include="*.md" . \| xargs -r grep -l "Versión:\*\*"` | 0 | salida vacía, rc=0 (`inventario-02.txt`) |
| Estado «planificado» o equivalente (y la proporción planificada, con ruta:línea) | 3: `command grep -rniE "${X[@]}" -e planificad -e previst -e "a implementar" -e TODO docs/tecnica; echo "rc=$?"` | 0 | `grep: docs/tecnica: No such file or directory`, rc=2: carpeta ausente (`inventario-03.txt`). Proporción planificada: no aplica, 0 documentos técnicos; el único Markdown del árbol es `README.md`, sin frontmatter ni fila «Estado» (`inventario-fuentes.txt`) |
| Traza de la interfaz a una unidad que no le corresponde | 4: `command grep -rn "${X[@]}" "^traces:" Colmenar/Resources/Ayuda; echo "rc=$?"` (adaptado: `{carpeta-ayuda}` sin ubicación en el árbol; se usó la carpeta de recursos de la app, informada junto al literal) | 0 | `grep: Colmenar/Resources/Ayuda: No such file or directory`, rc=2: carpeta ausente (`inventario-04.txt`) |
| Puntero a un documento obsoleto o ausente (sin CHANGELOG: «archivo ausente», cuenta 0 y su rc) | 5: `find . -maxdepth 1 -iname "changelog*" \| wc -l` y `find . -maxdepth 1 -iname "changelog*" -exec grep -niE -e obsolet -e retirad -e elimin -e renombr {} + </dev/null; echo "rc=$?"` | 0 | `0` y rc=0: archivo ausente (`inventario-05.txt`) |
| Advertencia del índice del proyecto (cuenta y lista del comando 6; cada una pasa a reserva, con su estado) | 6: `command grep -niE -e advertencia -e aviso -e warning -e pendiente -e "sin implementar" -e "no ejercid" AGENTS.md` (lista) y `command grep -ciE … AGENTS.md` (cuenta) | 0 | `grep: AGENTS.md: No such file or directory`, rc=2 en las dos: el proyecto no tiene índice (`inventario-06.txt`). Sin advertencias, no hay reservas que pasar |
| Espacios de IDs en uso, con su origen y sus choques con los Id de esta ficha (D-07) | 7: `command grep -rIhoE "${X[@]}" --include="*.md" "\b[A-Z][A-Z0-9]*-[A-Z0-9]+" . \| sed -E "s/-.*//" \| sort \| uniq -c \| sort -rn` | 1 espacio | `4 EX` (`inventario-07.txt`): `EX`, convenio externo con el programa provincial (README.md:67-69), sin registro en el repositorio. No choca con `D-`, `CL-`, `A-`, `DE-`, `I-` ni con `RD`, `FIC`, `PRC`, `AUD`. Colisiones internas (1b): ninguna |
| Plataformas que compila cada máquina (D-09) | 8: `command grep -rhoE "${X[@]}" --include="*.csproj" "<TargetFrameworks?>[^<]+" . \| sort \| uniq -c`, más `command grep -rnE "${X[@]}" --include="*.csproj" "<TargetFrameworks?" .` para ver las condiciones | 3 líneas | `net10.0-android` siempre; `net10.0-ios` y `net10.0-maccatalyst` fuera de Linux; `net10.0-windows10.0.19041.0` en Windows (Colmenar/Colmenar.csproj:4-6; `inventario-08.txt`). Plataforma → máquina: Android → Linux (README.md:93); iOS y Mac Catalyst → Mac (README.md:94); Windows → Windows (README.md:95) |
| Prefijos nuevos libres (comando 9, uno por prefijo, `AUD` incluido) | 9: `for PREFIJO in RD FIC PRC AUD; do printf "%s " $PREFIJO; command grep -rIlwE "${X[@]}" "$PREFIJO-[0-9]+" . \| wc -l; done` | 4 libres | `RD 0`, `FIC 0`, `PRC 0`, `AUD 0` (`inventario-09.txt`) |
| ¿El producto filtra por alcance? («sólo lo suyo» o inventario de alcances, con ruta:línea; o búsqueda negativa) | `./aislado bash -c 'cd repo/proyecto; … grep -rnIE --exclude-dir=.git -e "\.Where\(" -e ProductorId -e AplicacionId -e TenantId -e scope -e openapi -e swagger --include=*.cs --include=*.xaml --include=*.json --include=*.csproj .'` | 0 en el código | Búsqueda negativa: salida vacía, rc=1 (`inventario-alcance.txt`). La descripción declara «sólo lo suyo» para el productor (README.md:18) y que la API no entrega kilos ni precios a quien no debe verlos (README.md:24-25), pero el punto que lo hace cumplir vive en la API privada, que no llegó (README.md:46-47) |
| Organización del runner: medida, o archivo que la nombra (evidencia secundaria declarada) | `./aislado bash -c 'cd repo/proyecto; git remote -v'` (ruta del remoto sustituida por `{dir-de-trabajo}` en `inventario-anclas-y-actas.txt`) | 0 organizaciones medidas | El remoto `origin` es una ruta local del montaje, no una organización. Ningún archivo nombra la organización; el README dice que la organización «sólo permite ejecutar automatismos definidos dentro de ella misma» (README.md:96-97) y que la federación tiene otras tres apps en la misma organización (README.md:53-54): evidencia secundaria declarada. Organización: pendiente |

Otros comandos del inventario, para D-01, D-06, D-11 y D-14:

| Para | Comando | Cuenta | Salida |
| --- | --- | --- | --- |
| Inventario de autorización (D-01, D-18) | `./aislado bash -c 'cd repo/proyecto; … grep -rnIiE --exclude-dir=.git -e Authorize -e Policy -e RequireRole -e Claim -e AuthenticationScheme -e IsInRole -e Roles -e token -e login .'` | 0 políticas | Una sola línea, homónima: `$targetnametoken$` en Colmenar/Platforms/Windows/Package.appxmanifest:29 (`inventario-autorizacion.txt`). La app no autentica a nadie |
| Fuentes documentales y contratos (D-01, D-04) | `./aislado bash -c 'cd repo/proyecto; find . -name .git -prune -o \( -iname "*.resx" -o -iname "*openapi*" -o -name "*.md" -o -name "*.yml" -o -name "*.yaml" \) -print'` | 1 | `./README.md` (`inventario-fuentes.txt`): ni OpenAPI, ni recursos localizados, ni workflows |
| Anclas, actas y etiquetas (D-06, D-11) | `./aislado bash -c 'cd repo/proyecto; find . -name .git -prune -o \( -name source.lock -o -name "*.lock" -o -name CODEOWNERS -o -iname "*acta*" \) -print; git tag -l \| wc -l; git log --all --oneline \| wc -l; grep -n GenerateDocumentationFile Colmenar/Colmenar.csproj'` | 0 | Sin `source.lock`, sin CODEOWNERS, sin acta; 0 etiquetas; 1 commit; generación de documentación apagada (rc=1) (`inventario-anclas-y-actas.txt`) |
| Barrido sin lista (D-14) | 12b: `command grep -rnIiE "${X[@]}" -e "[0-9]{1,3}(\.[0-9]{1,3}){3}" -e "/(home\|Users)/[a-z]" -e "$(hostname -s)" .` | 2 | Dos números de versión de cuatro partes, no IP: Colmenar/Platforms/Windows/Package.appxmanifest:9 y Colmenar/Platforms/Windows/app.manifest:3 (`inventario-12b.txt`). Falsos positivos |
| Visibilidad (D-14) | 13: `command grep -rniE -e privad -e "públic" -e private -e public -e visibility README* AGENTS.md .github` | 12 líneas | «Este repositorio es público. El repositorio de la API es privado. El del paquete es público.» (README.md:77); `AGENTS.md` y `.github` ausentes (`inventario-13.txt`) |

## 2. Decisiones

| Id | Pregunta | Valor | Evidencia (ruta:línea en el SHA leído, o «pendiente: qué falta») | Clase (P o H) | Si es H: opciones y default para la persona |
| --- | --- | --- | --- | --- | --- |
| D-01 | ¿Escenario y contextos? | Unión de «panel con roles» y «servicio con paquetes» (I-14). Superficies: app MAUI para Android, iOS y Windows, panel de la cooperativa, sitio público (futuro), API (repositorio ajeno) y paquete .NET público. Roles: cinco perfiles con permisos distintos, por la tabla de permisos de la descripción del producto (inventario declarado; el código no autentica a nadie). Documentos OpenAPI: 0 en el árbol. Filtro por alcance: declarado para el productor, sin punto de cumplimiento en el árbol (§1). Curso declarado en el propósito: va a D-15 | Perfiles y permisos: README.md:16-22; panel: README.md:9-11; plataformas: README.md:32-37 y Colmenar/Colmenar.csproj:4-6; sitio: README.md:38-39; API: README.md:46-47; paquete que el equipo publica: README.md:48-50; curso: README.md:12 y README.md:72-73; autorización: `inventario-autorizacion.txt` (0 políticas) | P | — |
| D-01 · sitio | ¿Hay sitio publicado? | Sí, a futuro: remite a D-03 (decidida) | README.md:38-39 | H (de D-03) | Ver D-03 en §4 |
| D-01 · marco | ¿Hay marco de especificación? | No. `EX-nn` es una numeración de convenio sin registro en el repositorio: prefijo externo, no marco | README.md:67-69; comandos 1b y 2 vacíos (`inventario-01b.txt`, `inventario-02.txt`) | P | — |
| D-01 · topología | ¿Mismo repo, hermano o dedicado? | Mismo repo (app) para lo que cambia con el código; repos ajenos para la API y el paquete; repositorio dedicado para el curso (propuesto); sitio: pendiente (alojamiento y build sin evidencia) | App en este repositorio: README.md:45; API: README.md:46-47; paquete en su propio repositorio: README.md:48-50; sin índice de los hermanos: sin verificar en el hermano | P | — |
| D-01 · organización | ¿Dentro o fuera de la organización del runner (medido)? | pendiente: organización (ningún archivo la nombra; el remoto es una ruta local). Evidencia secundaria declarada: la organización sólo ejecuta automatismos definidos dentro de ella | README.md:96-97; `git remote -v` en `inventario-anclas-y-actas.txt` | P | — |
| D-02 | ¿Qué clases de pieza se activan? | Activas: CL-01, CL-02, CL-03, CL-04, CL-06, CL-07, CL-10, CL-12, CL-13, CL-14. De baja: CL-05, CL-08, CL-09, CL-11. Altas y bajas frente a la unión, en §3 | §3 de esta ficha | P | — |
| D-03 | ¿Hay sitio publicado? | Sí: «un sitio web público, ya decidido y pagado por el programa provincial». Alojamiento y build del sitio: pendiente | README.md:38-39 | H | Decidida por el programa provincial (README.md:38-39); opciones Sí · No; ver §4 |
| D-04 | ¿Hay marco de especificación con registro de IDs? | No: fichas propias y `docs/_requisitos.md`. `EX` va como prefijo externo en A-02 | README.md:67-69; comandos 1, 1b y 2 en 0 (§1) | P | — |
| D-05 | ¿Dónde vive cada pieza? | Por clase, en §3: mismo repo para CL-01, CL-02, CL-03, CL-06 (parte), CL-07, CL-12 y CL-13; build para CL-04 y CL-14; repo dedicado para CL-10; el paquete lleva su propio `AGENTS.md` y su referencia | README.md:45, README.md:48-50, README.md:72-73; ubicaciones de CL-03 y CL-12: propuesta sujeta a D-12 y D-11 | P | — |
| D-06 | ¿Contra qué ancla vale cada pieza? | Commit para lo que vive en este repositorio; SHA fijado (`source.lock`) para el curso; versión exacta consumida para el paquete y versión publicada para la API; sitio: pendiente. Líneas de versión vivas: 2 y 3 en paralelo durante 2027, las dos sin etiqueta (0 etiquetas) → por SHA; la 3 entra como plan. Mecanismo actual: ninguno (sin `source.lock` ni `base_commit`). El proyecto declara versión 1.0, distinta de las líneas 2 y 3: hallazgo | README.md:34-35; README.md:47; README.md:50; Colmenar/Colmenar.csproj:37; `inventario-anclas-y-actas.txt` (0 etiquetas, sin `source.lock`) | P | — |
| D-07 | ¿Qué prefijos e IDs? | Registro del proyecto (A-02): `RD`, `FIC`, `PRC`, `AUD` internos; `EX` externo. Unicidad: control de trazas en 0 duplicados | Comando 9 en 0 para los cuatro (`inventario-09.txt`); comando 7: sólo `EX` (`inventario-07.txt`); README.md:67-69 | P | — |
| D-08 | ¿Qué esquema de frontmatter? | Diez campos más `description`, con vocabulario del proyecto, más `version`, `aprobado_por` y `fecha_aprobacion` para los procedimientos escritos (norma de calidad), sumados al esquema y no igualados a `owner` ni a `last_review` | README.md:70-71 | P | — |
| D-09 | ¿Cómo corre la compuerta? | Abierta. Propuesto: copia con huella del guion local de la compuerta de origen en `.docs-guard/` (más `.docs-guard-origen/` intacta), en el runner Linux del proyecto. El reutilizable queda excluido: la organización no ejecuta automatismos de otras organizaciones y el proyecto declara prefijos y vocabulario propios. Plataforma → runner: Android → Linux; iOS y Mac Catalyst → Mac (sólo jueves); Windows → Windows; la compuerta → Linux | README.md:93-97; Colmenar/Colmenar.csproj:4-6; huellas de la copia en §8 | H | Copia con huella en runner propio · reutilizable; default propuesto: copia con huella (§4) |
| D-10 | ¿Qué controles bloquean y cuáles avisan, en qué carpeta? | Proyecto nuevo: la carpeta nueva es `docs` (más `AGENTS.md` y `README.md` como punteros). Con línea de base 0 medida (§8), bloquean PR-1, PR-2, PR-3 (AI-3 avisa), PR-4, PR-5 y PR-7; PR-6 avisa (no hay contrato); los controles de A-13 avisan hasta su par. La plataforma impide fusionar con verificaciones fallidas (evidencia secundaria declarada, sin configuración ni respuesta de la API); volver obligatorio el check de la compuerta es un acto H (§4) | README.md:98-99; línea de base en §8 | P | — |
| D-11 | ¿Quién decide qué? | Decidida por el dueño del producto — citada, no versionada: la programadora fusiona sin él todo cambio con las verificaciones en verde; los asistentes automáticos fusionan sus propias ramas en las mismas condiciones; salvo lo que toca alertas o tratamientos, que no se fusiona sin el visto bueno del técnico sanitario jefe. Visto bueno en ausencia del titular: pendiente. Lo demás lo fusiona una persona; el pull request de adopción, con H abiertas, lleva reserva y lo fusiona una persona | README.md:61-66; acta ausente del árbol (`inventario-anclas-y-actas.txt`) | H | Ver §4 |
| D-12 | ¿Qué canales hay para agentes? | Abierta. Propuesto: `AGENTS.md` puntero en este repositorio y en el del paquete; con D-03 = Sí, también CL-14 generada por el build del sitio. ¿El canal para agentes usa el mismo filtro que la página, con el token del usuario?: pendiente, no hay canal medido. El asistente del organismo sanitario lee sólo el sitio público | Cinco asistentes en ramas propias: README.md:59-60; asistente externo: README.md:40-41 | H | `AGENTS.md` puntero · índice para agentes · canales derivados; default propuesto: puntero más CL-14 (§4) |
| D-13 | ¿Cómo es la ayuda al usuario final? | Estado actual: ninguna (la app es la plantilla, sin ayuda ni recursos localizados; búsqueda negativa en `inventario-fuentes.txt` e `inventario-04.txt`). Opción de diseño, propuesta: por rol y por idioma (español y portugués), con instrucciones de una línea, dibujos y audio para los peones. En el punto de uso: ninguno por ahora (no hay formularios con reglas en el árbol). El texto localizado en archivos de recursos no se ancla; faltan `traduccion-atrasada` y `anti-inyeccion-en-recursos` (A-13). La ayuda compilada en la app es `publico`; una variante de mayor nivel se sirve por la API con el token | README.md:26; README.md:28; README.md:85-86; Colmenar/MainPage.xaml.cs:1-17 | P | — |
| D-14 | ¿Qué es privado y cómo se nombra? | Este repositorio y el del paquete, públicos; el de la API, privado (evidencia secundaria declarada). Alias: `{servicio-privado}` (repositorio de la API), `{proveedor-api}` (nombre del proveedor), `{organismo-sanitario}` (nombre del organismo). No van en lo versionado: ubicaciones de apiarios ni nombres de alumnos. Lista: pendiente (sin `{lista-privada}`; barrido 12b) | README.md:77-81; `inventario-13.txt`; `inventario-12b.txt` | P | — |
| D-15 | ¿Hay un cuerpo formativo? | Sí: la escuela agrotécnica usa la app para enseñar y dicta un curso anual con ejercicios (enunciado y solución) sobre una copia del repositorio, en portugués. Perfil de guía de estudio: pendiente (no se toma el de origen). Continuidad después de 2027: no decidida | README.md:12; README.md:72-73; README.md:89; README.md:107 | P | — |
| D-16 | ¿Idioma y estilo? | Español en este repositorio; la app, en español y portugués; el repositorio del paquete, en los dos; el curso, en portugués. No se traducen: claves del frontmatter, IDs (`EX-nn`, `RD-nn`, `FIC-`, `PRC-`, `AUD-`) y los términos del modelo del paquete `apiario`, `colmena`, `visita`, `tambor` (según el README, sin verificar en el hermano) | README.md:85; README.md:87-89; README.md:48 | P | — |
| D-17 | ¿Cómo es el carril programado? | Frecuencia: diaria de octubre a marzo y mensual el resto del año (la fija el proyecto). Frescura: 90 días para los procedimientos escritos; 365 para el resto (default). Qué vigila: frescura de `last_review`, atraso del `source.lock` del curso y la copia de la tabla de productos veterinarios autorizados frente a la publicada (ruta de la copia y dirección de la publicación: pendiente). Enlaces externos: ninguno anclado, nota. Modo: sólo avisa, con issue | README.md:100-101; README.md:70-71; README.md:51-52 | P | — |
| D-18 | ¿Audiencias y entrega? | Perfil mínimo. Cinco candidatos de la tabla de perfiles; ninguno con acceso propio probado en el árbol: acceso, jerarquía y nivel «pendiente», sin nivel, y sus filas H en §4. Jerarquía: plana. Alcance: no activado. Detalle en §5 | README.md:16-22; README.md:105; `inventario-autorizacion.txt` | P; H para exponer o ensanchar la API y cambiar la jerarquía | Ver §4 |

## 3. Catálogo activo

| Clase | Activa (sí o no) | Alta o baja frente al escenario, con motivo | Dónde vive (todas las ubicaciones) | Ancla | Evidencia |
| --- | --- | --- | --- | --- | --- |
| CL-01 | sí | En la unión; A-01 y las fichas propias (D-04 = No) | `docs/_diseno/` de este repositorio | Commit | README.md:45 |
| CL-02 | sí | En la unión | `docs/_requisitos.md` | Commit | A-04 |
| CL-03 | sí | En la unión; hay cinco asistentes automáticos | Raíz de este repositorio y raíz del repositorio del paquete (según el README, sin verificar en el hermano); propuesta sujeta a D-12 | Commit | README.md:59-60 |
| CL-04 | sí | En la unión; fuente presente (código C#) con la generación apagada: control «pendiente», línea de base sin medir. La referencia del paquete vive en el build de su repositorio | Build de la app; build del repositorio del paquete (sin verificar en el hermano) | Commit; versión exacta del paquete | Colmenar/MauiProgram.cs:1-24; `inventario-anclas-y-actas.txt` (sin `GenerateDocumentationFile`); README.md:48-50 |
| CL-05 | no | Baja: el contrato REST es de la API, que vive en un repositorio ajeno y se consume por versión publicada; la versión consumida es el ancla | Repositorio privado del proveedor | Versión publicada de la API | README.md:46-47 |
| CL-06 | sí | En la unión; cada perfil necesita su ayuda | Carpeta de ayuda de la app (pendiente, aún no existe); sitio público (pendiente) | Commit; sitio: pendiente | README.md:26-28; README.md:38-39 |
| CL-07 | sí | En la unión | `docs/tecnica/` (carpeta ausente, se crea) | Commit | `inventario-03.txt` |
| CL-08 | no | Baja: sólo existe si D-12 elige un índice; el default propuesto es `AGENTS.md` puntero (propuesta sujeta a D-12) | — | — | README.md:59-60 |
| CL-09 | no | Fuera de la unión; no hay expedientes ni bitácoras previos (un solo commit) | — | — | `inventario-anclas-y-actas.txt` (1 commit) |
| CL-10 | sí | Alta por D-15: curso anual con ejercicios, enunciado y solución | Repositorio dedicado del curso (pendiente) | SHA fijado de la app (`source.lock`) y etiqueta del curso | README.md:72-73; README.md:89 |
| CL-11 | no | Baja frente a «servicio con paquetes»: no hay conocimiento compartido copiado en el árbol. La copia de la tabla de productos autorizados es un dato del producto que vigila D-17 (ver §7) | — | — | `inventario-fuentes.txt`; README.md:51-52 |
| CL-12 | sí | En la unión | `docs/_gobierno/como-intervenir.md`; propuesta sujeta a D-11 | Versión de la plantilla | A-06 |
| CL-13 | sí | En la unión («servicio con paquetes»); README presente, CHANGELOG ausente | Raíz de este repositorio | Fecha o versión del paquete de la app | README.md:1; `inventario-05.txt` |
| CL-14 | sí | Alta por D-03 = Sí | Build del sitio (pendiente) | Versión del build | README.md:38-41 |

## 4. Decisiones de clase H para una persona

| Id | Estado (abierta, «decidida por {actor}» con ruta:línea, o «decidida por {actor} — citada, no versionada») | Opciones | Default propuesto | Quién decide |
| --- | --- | --- | --- | --- |
| D-03 sitio | decidida por el programa provincial (README.md:38-39) | Sí · No | Sí (decidida; no se reabre) | Programa provincial |
| D-09 compuerta | abierta | Copia con huella en el runner Linux propio · workflow reutilizable | propuesto: copia con huella en `.docs-guard/`, con `.docs-guard-origen/` para la autoprueba | Persona responsable del repositorio (pendiente de nombrar) |
| D-10 check obligatorio | abierta | Volver obligatorio el check `docs-guard` antes del merge · dejarlo como aviso | propuesto: obligatorio, sobre `docs` | Persona responsable del repositorio |
| D-11 fusión | decidida por el dueño del producto — citada, no versionada (README.md:61-66) | Mapa del acta (programadora y asistentes con verificaciones en verde; alertas y tratamientos con visto bueno del técnico sanitario jefe) · fusiona siempre una persona | El mapa del acta (no se reabre). Suplente del visto bueno: pendiente | Dueño del producto |
| D-12 canales | abierta (incluye A-05, `AGENTS.md`) | `AGENTS.md` puntero · índice para agentes · canales derivados | propuesto: `AGENTS.md` puntero aquí y en el paquete, más CL-14 del build del sitio | Persona responsable del repositorio |
| API de datos | abierta: exponer o ensanchar su documentación es H por cambio (README.md:46-47) | No exponer · exponer `restringido` por credencial · sólo al equipo (`interno`) | propuesto: no exponer | Dueño del producto, con el proveedor |
| AUD-01 productor | abierta: acceso propio y nivel sin punto de cumplimiento en el árbol (README.md:18) | Probar el punto que autentica en la API y fijar nivel · no entregar | propuesto: no entregar hasta probar el acceso | Dueño del producto |
| AUD-02 peón de campo | abierta: acceso propio y nivel sin punto de cumplimiento en el árbol (README.md:19) | Probar el punto que autentica en la API y fijar nivel · no entregar | propuesto: no entregar hasta probar el acceso | Dueño del producto |
| AUD-03 técnico sanitario | abierta: acceso propio y nivel sin punto de cumplimiento en el árbol (README.md:20) | Probar el punto que autentica en la API y fijar nivel · no entregar | propuesto: no entregar hasta probar el acceso | Dueño del producto |
| AUD-04 administración | abierta: acceso propio y nivel sin punto de cumplimiento en el árbol (README.md:21) | Probar el punto que autentica en la API y fijar nivel · no entregar | propuesto: no entregar hasta probar el acceso | Dueño del producto |
| AUD-05 inspector sanitario | abierta: acceso no decidido por el proyecto (README.md:105) y sin punto que lo autentique (README.md:22) | Acceso a la app con nivel propio · reporte mensual sin acceso · no entregar | propuesto: no entregar hasta que se decida | Dueño del producto |
| Jerarquía | abierta: `incluye:` sin evidencia de autorización (0 políticas en el árbol) | Plana · jerarquía con `incluye:` probada por la API | propuesto: plana | Dueño del producto |

## 5. Audiencias y entrega (D-18)

Perfil mínimo, sin extensiones: D-01 no registra tipo de alcance probado, superficie con política ni identificador de
contexto (§1, filas de alcance y de autorización). Inventario de autorización: `inventario-autorizacion.txt`, 0
políticas.

| Audiencia (fila de A-12) | Acceso propio (ruta:línea que la autentica) | Incluye (búsqueda de todas las políticas de la menor y ruta:línea de cada una, todas con la mayor; o «plana» con el punto que falta) | Nivel de acceso (`publico`, `producto`, `restringido`, `interno`) | Punto de aplicación y de cumplimiento (repositorio, build, servidor; ruta:línea) | Alcance (`por-aplicacion` con ruta:línea, o no activado) | Par de entrega (200 con contenido / distinto de 200 sin contenido) o «pendiente» |
| --- | --- | --- | --- | --- | --- | --- |
| AUD-01 productor | pendiente: el árbol no lo autentica; el perfil está declarado en README.md:18 | plana: la búsqueda de autorización no da políticas | pendiente (sin nivel) | pendiente: el cumplimiento declarado vive en la API, que no llegó (README.md:24-25) | no activado: «sólo lo suyo» declarado (README.md:18) sin punto de cumplimiento; búsqueda negativa en §1 | pendiente |
| AUD-02 peon-de-campo | pendiente: declarado en README.md:19 | plana | pendiente (sin nivel) | pendiente | no activado | pendiente |
| AUD-03 tecnico-sanitario | pendiente: declarado en README.md:20 | plana | pendiente (sin nivel) | pendiente | no activado | pendiente |
| AUD-04 administracion | pendiente: declarado en README.md:21 | plana | pendiente (sin nivel) | pendiente | no activado | pendiente |
| AUD-05 inspector-sanitario | pendiente: declarado en README.md:22; su acceso no está decidido (README.md:105) | plana | pendiente (sin nivel) | pendiente | no activado | pendiente |

Descartados (homónimos, agente, valores de `audience:` que sólo orientan), cada uno con su ruta:línea y motivo:
el asistente conversacional del organismo sanitario (README.md:40-41), agente: hereda la audiencia de su usuario y
lee sólo lo `publico` del sitio; los cinco asistentes automáticos de programación (README.md:59-60), agentes; el
docente y los alumnos del curso (README.md:72-73), no se autentican en el producto: van a CL-10 y D-15; quien lee el
sitio público para aprender (README.md:38-39), sin identidad propia: el sitio es `publico`; `$targetnametoken$`
(Colmenar/Platforms/Windows/Package.appxmanifest:29), homónimo de «token»; `desarrollo`, `po` y `agente` en
`audience:` de los artefactos, que sólo orientan.

## 6. Artefactos A-02 a A-13

Las rutas son relativas a la raíz del repositorio, dentro de `salida/`. A-01 se entrega en `salida/A-01.md`; en el
repositorio va en `docs/_diseno/ficha-diseno-documental.md`, con su `doc_id`.

| Id | Producido (sí o no) | Ruta | Motivo si no se produce | Propuesta sujeta a (D-nn), si depende de una H abierta | «Sin probar», si falta la compuerta |
| --- | --- | --- | --- | --- | --- |
| A-02 | sí | `.docs-guard/tools/docs-guard/prefijos.txt` | — | D-09 (ubicación de la copia) | probado (§8) |
| A-03 | sí | `.docs-guard/tools/docs-guard/esquemas/cuerpo.schema.json` | — | D-09 (ubicación de la copia) | probado (§8) |
| A-04 | sí | `docs/_requisitos.md` | — | — | probado (§8) |
| A-05 | sí | `AGENTS.md` | — | D-12 | probado (§8) |
| A-06 | sí | `docs/_gobierno/como-intervenir.md` | — | D-09, D-11, D-12 | probado (§8) |
| A-07 | sí | `.github/workflows/docs-guard.yml`; guion en `.docs-guard/scripts/ci-local.sh` y `.docs-guard-origen/scripts/ci-local.sh` | — | D-09 | guion probado en local (§8); el workflow, sin probar en la CI |
| A-08 | sí | Informe: `_pr-adopcion/linea-de-base.md` (descripción del pull request, no va al repositorio); `.docs-guard/tools/docs-guard/excepciones.txt`, vacío | — | D-10 | probado (§8) |
| A-09 | sí | `_otros-repos/curso/source.lock` (raíz del repositorio dedicado del curso) | El del sitio: no se produce, alojamiento y build pendientes | — | sin probar (el repositorio del curso no existe) |
| A-10 | sí | `.github/workflows/docs-programado.yml` | — | — | sin probar en la CI |
| A-11 | sí | `CHANGELOG.md`, línea 3 (archivo nuevo); el punto de entrada de D-12 es A-05 | Índice para agentes: CL-08 de baja | D-12 | — |
| A-12 | sí | `docs/_gobierno/registro-audiencias.md` | — | D-18 (filas AUD de §4) | probado (§8) |
| A-13 | sí | `docs/_gobierno/controles-de-entrega.md` | — | D-10, D-18 | todos sus controles, pendientes |

## 7. Lo que el conocimiento no resolvió

| Sección o decisión | Cita textual de lo que no resuelve | Qué quedó sin hacer |
| --- | --- | --- |
| §3.7 y la carta | `DocsAsCode-Designing-Specification §3.7` pide los auxiliares «en `{dir-de-corrida}/_auxiliares/`»; la carta sólo deja escribir en `salida/` | Se usaron `salida/_auxiliares/`. No son artefactos ni van al repositorio |
| D-11 | `DocsAsCode-Designing-Specification §3.2`, D-11: «si un archivo del árbol cita un acta, minuta o resolución que decide algo (con fecha, número o nombre)». El acta del README no tiene fecha, número ni nombre | Se asentó «citada, no versionada» con README.md:61-64. Acción que deja: versionar el acta. Suplente del visto bueno del técnico sanitario jefe: pendiente |
| CL-11 y D-17 | `DocsAsCode-Designing-Specification §2.1`, CL-11: «Conocimiento compartido copiado, medido y con huella declarada»; no dice en qué clase va la copia de datos externos que la app trae adentro (README.md:51-52) | CL-11 de baja; la copia queda en «qué vigila» de D-17 con ruta y dirección de la publicación pendientes |
| D-18, regla 4 | `DocsAsCode-Designing-Specification §3.2.1`, regla 4: el alcance entra si «el código restringe a cada sesión lo de su aplicación o inquilino» o hay «inventario de alcances»; no dice qué hacer con un «sólo lo suyo» declarado en la descripción cuyo código vive en un repositorio ajeno que no llegó | Alcance no activado; queda para cuando se pruebe en la API |
| D-15 | `DocsAsCode-Designing-Specification §3.2`, D-15: «Sí, con un perfil de guía de estudio»; el perfil del curso no está en el árbol y el de origen no es norma | Perfil del curso: pendiente; A-09 del curso producido, sin repositorio todavía |
| D-06 | El proyecto declara versión 1.0 (Colmenar/Colmenar.csproj:37) y el README habla de las versiones 2 y 3 (README.md:34-35) | Hallazgo anotado; las anclas por SHA no dependen de él |
| D-09 | La plantilla compila Mac Catalyst (Colmenar/Colmenar.csproj:5), que no figura entre las plataformas distribuidas (README.md:30-37) | Hallazgo anotado; no cambia la compuerta, que corre en Linux |
| D-11 | `DocsAsCode-Designing-Specification §3.2` no da el mecanismo para hacer cumplir el visto bueno obligatorio del técnico sanitario jefe (README.md:65-66) | No se produjo un archivo de dueños de código; queda para una persona |
| Carta, nota inicial | La carta nombra `conocimiento/A-01-ficha-vacia-1.4.md`, que no está en el directorio | Se usó `A-01-ficha-vacia.md`, con la numeración que la carta da |
| Lista privada | §3.6: «Sin la lista, el comando 12b usa patrones genéricos» | D-14 «lista: pendiente» |

## 8. Verificación (§6)

| Comprobación | Comando | Resultado (salida textual) |
| --- | --- | --- |
| Compuerta sobre los artefactos, con A-02 y A-03 (copia de §5.7 y su huella) | pendiente | pendiente |
| Par rojo/verde plantado, con la compuerta de D-09 | pendiente | pendiente |
| Autoprueba de la compuerta de origen (sin red ni caché: «pendiente», con el comando, §5.7) | pendiente | pendiente |
| Chequeo de citas ruta:línea (§3.5; cada cita repite el archivo, sin `:n` sueltas) | pendiente | pendiente |
| Muestra de cinco citas releídas contra lo que afirman (§3.5) | pendiente | pendiente |
| Barrido por `{lista-privada}` (§3.6; sin la lista, comando 12b y «lista: pendiente») | pendiente | pendiente |
