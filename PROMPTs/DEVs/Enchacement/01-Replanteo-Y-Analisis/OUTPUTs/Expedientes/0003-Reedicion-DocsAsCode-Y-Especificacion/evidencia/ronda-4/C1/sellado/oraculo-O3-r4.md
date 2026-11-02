# Oráculo O3-r4 — caso C1 «Panel con roles» (ronda 4, brazo B)

## Correcciones de la revisión r4 (sólo las juzgadas en `F206` §6)

Parte de `oraculo-O3-r3.md`, huella `e956db681333a48ce3d509200337d0b7edb96ee64e820dad3288d2c0b894bc5a`, que **no** se modificó. Fuente del juicio:
`F206` (`…/0003-Reedicion-DocsAsCode-Y-Especificacion/actuaciones/206-resultado-ronda-3.md`) §6. Regla O-4: se corrige
sólo por error; ninguna corrección fusiona filas, así que *n* y umbral **no cambian** (Parte I: *n* = 23, umbral = 3;
Parte II: *n_audiencia* = 12, umbral = 1). Rige desde la ronda 4. Las M2 de la ronda 3 no se recalculan.

| Alegato | Juicio `F206` | Qué cambia en r4 |
| --- | --- | --- |
| E-1 | Procede | La regla H de «Comparación (M2)» y la nota de D-11 admiten que la ficha diga «decidida por {actor}» con ancla ruta:línea que resuelva, en el SHA del caso, a una decisión escrita de ese actor. Para D-11 resuelven: `LG@4b114d7:AGENTS.md:65` (fusión delegada por el PO, 2026-08-31 / 2026-09-14) y `LGD@b47d22b:README.md:17-19` (Decidió: el PO, 2026-10-26). Sin ancla, o con ancla que no resuelva, sigue siendo discrepancia |
| E-2 | Procede como **pregunta a la mesa** (CL-04: fuente o salida) | **Sin cambio.** Rige el oráculo (CL-04 en LG, `LG@4b114d7:Directory.Build.props:26`) hasta que decida la mesa. Pendiente anotado |
| E-3 | Procede | AUD-10: la nota cubre también el alcance (no sólo el OpenAPI) |

Es la única modificación respecto de r3 junto con este encabezado; el resto es copia literal de r3.

| Campo | Valor |
| --- | --- |
| Caso | C1, escenario «panel con roles»; **brazo B** de la ronda 3 (`F399` §5.5: corre con `K` 1.3) |
| Repositorios del caso (sólo lectura, `git archive`) | `LG` = Lab-Geometria en `4b114d74f823b380ca65b5c00aab13d34c0b86d7`; `LGD` = Lab-Geometria.Documentacion en `b47d22b78c153ffe2050b2e91211cbec59d12968` (sin cambio) |
| Parte de | `oraculo-O3.md` (revisión 2), huella `0fd3d463c875d53f5a1cc8724a03c2a4426c18c09ee7ccb114ece059ba461eac`; no se modificó |
| Cuerpo de referencia | Parte I: `LD@00171bd` (heredado, sin tocar). Parte II: `SDEI/` de `LD` en `ad8de01061f7da59710b12a03b978dc68fa183a7` (trae glosario de audiencias, `TEM-05` regla de entrega, anexo del esquema con `delivery:` y `AUD-`) |
| Rige | `F399` (`{dir-de-trabajo}`) §4 (D-18, ajustes de D-01, D-12, D-13; A-12 y A-13) y §5.5 (dos brazos; métrica por separado para filas heredadas y filas de audiencia) |
| Fecha | 2026-11-02 |
| Autor | Perito autor de oráculo (agente); no escribió `K` ni corre el caso (P-26 de `F099`) |
| Fuentes NO leídas | El conocimiento (`{dir-de-trabajo}`, salvo la plantilla A-01 vacía, leída sólo para nombres de filas) y el libro |
| Mensajes de otras sesiones | Ninguno recibido durante la redacción |

**Estructura.** Parte I = filas heredadas, copia **literal** de `oraculo-O3.md` §1–§5 (mismo *n* = 23, mismo umbral = 3,
mismas H). Parte II = bloque **separado** de filas de audiencia (D-18 y ajustes de D-01, D-12, D-13), con su propio *n*
y umbral. La métrica e se informa por grupo (`F399` §5.5, fila «Atribución dentro del brazo B»). Las anclas de la
Parte II usan `LD@ad8de01:SDEI/…` con el mismo `SDEI/` de la convención heredada.

---

# Parte I — Filas heredadas (copia literal de O3 rev. 2)

# Oráculo O3 — caso C1 «Panel con roles»

| Campo | Valor |
| --- | --- |
| Caso | C1, escenario «panel con roles» (`F099` §5.5) |
| Repositorios del caso (sólo lectura, `git archive`) | `LG` = Lab-Geometria en `4b114d74f823b380ca65b5c00aab13d34c0b86d7`; `LGD` = Lab-Geometria.Documentacion en `b47d22b78c153ffe2050b2e91211cbec59d12968` |
| O-6 | `LGD@b47d22b:ia-db/README.md:38` declara «revisión `4b114d7` … etiquetada `v1.2.0`»: la ia-db indexa el SHA del caso. Cumple |
| Cuerpo de referencia | `SDEI/` de `LD` en `00171bd433fa7835d7680d981d1dadc1fd532ccb` (Lab-Documentos) |
| Fecha | 2026-11-01 |
| Revisión | 2 (antes de sellar): corrige D-05 (comparación por repositorio; LGD con o sin CL-03, que depende de la H de D-12), D-08 (esquema anclado en el anexo del SDEI), anclas de D-01 y D-02, y deja dicho de dónde sale *n*. Reemplaza la versión de huella `790188d5…6f420df1e20`, que no se selló |
| Autor | Perito autor de oráculo O3 (agente); no escribió el conocimiento ni corre el caso |
| Fuentes NO leídas | El archivo del conocimiento de especificación, el libro y la carpeta del conocimiento del expediente (regla O3). Los nombres de D-01…D-17 salen de la plantilla A-01 vacía; los de A-01…A-11, de `N3` §5.4, porque la plantilla sólo trae sus IDs |
| O-3 | El oráculo **no** copia la columna «Panel con roles» de `00-Marco.md:106-115`: cada valor sale del repositorio del caso en su SHA; el cuerpo `SDEI/` se cita sólo como vocabulario y regla |

**Convención de anclas.** `LG@4b114d7:ruta:línea`, `LGD@b47d22b:ruta:línea`, `LD@00171bd:SDEI/ruta:línea` (con
`SDEI/` = `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/`). Una ausencia se ancla con el
comando de sólo lectura que la mide sobre el SHA y su resultado.

**Comparación (M2).** Una fila «coincide» si el valor de la ficha cae en el valor o conjunto admitido. En las filas
de varios valores (D-02, D-05, D-06) coincide sólo si el **conjunto** es igual a uno de los admitidos; las
diferencias por elemento se listan como diagnóstico. D-05 se compara **por repositorio** (LG, LGD, build): coincide
si cada clase cae en el repositorio admitido; la carpeta dentro del repositorio es diagnóstico. En una fila de clase H, coincide si la ficha la marca H, la
lista para una persona con opciones y **no** la da por decidida; el default anotado es diagnóstico. **[r4, E-1]** También coincide si la ficha la deja a la persona como «decidida por {actor}» con ancla ruta:línea que resuelva en el SHA del caso a una decisión escrita de ese actor.

## 1. Decisiones D-01…D-17

| Fila | Valor o conjunto admitido | Ancla | Nota |
| --- | --- | --- | --- |
| D-01 Escenario | `ESC-SDEI-3` panel con roles; contextos: `CTX-SDEI-1` **sin** sitio de documentación; `CTX-SDEI-2` **con** marco de especificación (SDD); `CTX-SDEI-3` mismo repositorio **y** repositorio hermano; `CTX-SDEI-4` **dentro** de la organización del runner. Los cinco tienen que coincidir. Clase P | `LG@4b114d7:src/GeometriaFactory.Domain/Values/Role.cs:12-19` (dos roles, Alumno y Administrador); `LG@4b114d7:AGENTS.md:9,13`; `LGD@b47d22b:README.md:3-5`; `LG@4b114d7:SDD/Docs/Audit/Estado-Del-Destino-2026-09-12.md:33` (`{organizacion}/Lab-Geometria`) y `LD@00171bd:.github/workflows/docs-guard.yml:75` (`repository: {organizacion}/Lab-Documentos`): misma organización; vocabulario: `LD@00171bd:SDEI/00-Marco.md:91,121-145` (nombre del escenario y definición de los contextos) | Escenario conocido: no es H. El valor sale sólo de la evidencia de LG, LGD y el remoto de LD; la frase del Marco que atribuye el ejemplo (`00-Marco.md:93`) no se usa como ancla |
| D-02 Clases activas | Conjunto A = {CL-01, CL-02, CL-03, CL-04, CL-05, CL-06, CL-07, CL-08, CL-09, CL-12, CL-13}; conjunto B = A ∪ {CL-11}. Omitidas con motivo: CL-10 (no es guía de estudio), CL-14 (sin sitio, latente) | CL-01 `LG@4b114d7:AGENTS.md:13`; CL-02 (brecha) `LD@00171bd:SDEI/TEM-07-Marco-SDD.md:140` (el RRD va con la especificación del proyecto destino); CL-03 `LG@4b114d7:AGENTS.md:1`; CL-06 (brecha) `LD@00171bd:SDEI/TEM-07-Marco-SDD.md:263-266` (el SDD deja fuera al usuario final; el hueco lo cubre CL-06); CL-12 (brecha) `LD@00171bd:SDEI/01-Mapa.md:92` (una instancia por proyecto); CL-04 `LG@4b114d7:Directory.Build.props:26`; CL-05 `LG@4b114d7:src/GeometriaFactory.Api/Composition/ApiDocumentation.cs:58,117`; CL-07 `LG@4b114d7:SDD/Docs/Producto/11-Documentacion/README.md:105-113`; CL-08 `LGD@b47d22b:ia-db/README.md:38`; CL-09 `LG@4b114d7:SDD/Docs/README.md:176` (expediente 0001) y `LGD@b47d22b:README.md:5` (`PROMPTs/`); CL-11 `LGD@b47d22b:README.md:13-15`; CL-13 `LG@4b114d7:changelog.md:1`, `LGD@b47d22b:changelog.md:1`; CL-14 `LD@00171bd:SDEI/01-Mapa.md:96` | **[r4, E-2: pendiente de la mesa; rige este oráculo]** CL-02, CL-06 y CL-12 se activan sin pieza existente (brecha, no baja). CL-04 sigue activa aunque el XML esté apagado (ver T4). CL-11 admitida en los dos sentidos: el proyecto cita conocimiento compartido por ruta, sin copia con huella |
| D-03 ¿Sitio publicado? | Clase **H**. Hecho: no hay sitio de documentación; lo publicado es el producto (front y API) y su explorador de API en ejecución. Default: No | `LG@4b114d7:.github/workflows/deploy-front-ftp.yml:1-2` (publica el front); `LG@4b114d7:src/GeometriaFactory.Api/Composition/ApiDocumentation.cs:40,119` (explorador en ejecución); `git ls-tree -r --name-only 4b114d7 \| grep -ci llms.txt` → 0 | Confundir el sitio del producto o el explorador con un sitio de documentación es diagnóstico de D-03 |
| D-04 ¿Marco con registro de IDs? | Sí: se usa el registro del SDD del proyecto (encabezado `# ID — …` con `**Versión:**`); no fichas propias ni `docs/_requisitos.md` | `LG@4b114d7:AGENTS.md:13`; `LG@4b114d7:SDD/Docs/README.md:176` (procedencia SDD 13.16); `LG@4b114d7:SDD/Docs/Unidades-Entrega/GeometriaFactory-Web/02-Especificacion-Funcional/Casos-De-Uso/CU-10005-Enviar-Un-Trabajo-Y-Ver-El-Resultado-De-La-Interpretacion.md:1,5` | — |
| D-05 ¿Dónde vive cada pieza? | Comparación por repositorio (ver «Comparación (M2)»). **LG** = {CL-01, CL-02, CL-03, CL-04, CL-06, CL-07, CL-09, CL-13}; **build** = {CL-05}; **LGD** admite dos conjuntos: L1 = {CL-08, CL-09, CL-13} y L2 = L1 ∪ {CL-03} | CL-01 `LG@4b114d7:AGENTS.md:13`; CL-02 `LD@00171bd:SDEI/TEM-07-Marco-SDD.md:140` (con la especificación, contenido del proyecto destino); CL-03 en LG `LG@4b114d7:AGENTS.md:1`; CL-04 `LG@4b114d7:Directory.Build.props:26`; CL-05 `LD@00171bd:SDEI/01-Mapa.md:85` (emitido en el build); CL-06 `LD@00171bd:SDEI/TEM-03-Topologia-Y-Versionado.md:252-253` (el manual del panel por rol va en el repositorio del código) y `LD@00171bd:SDEI/01-Mapa.md:86` (repo de la interfaz); CL-07 `LD@00171bd:SDEI/01-Mapa.md:87` (`docs/tecnica/` del código) y `LG@4b114d7:SDD/Docs/Producto/11-Documentacion/README.md:105-113`; CL-08 `LGD@b47d22b:ia-db/README.md:38`; CL-09 `LG@4b114d7:SDD/Docs/README.md:176` (expediente 0001 en LG) y `LGD@b47d22b:README.md:3-5` (`PROMPTs/` en LGD); CL-13 `LG@4b114d7:changelog.md:1`, `LGD@b47d22b:changelog.md:1`; reparto código/hermano `LD@00171bd:SDEI/TEM-03-Topologia-Y-Versionado.md:252-254` | L2 sólo agrega CL-03 en LGD, que hoy no tiene `AGENTS.md` (`git ls-tree -r --name-only b47d22b \| grep -c '^AGENTS.md$'` → 0): ponerlo depende de la H de D-12, así que con o sin ese elemento coincide. Las carpetas (categoría 11 o `docs/tecnica/` para CL-07; proyecto web para CL-06; carpeta del RRD, que fija el escalón 2 según `TEM-07:140`) son diagnóstico. CL-11 y CL-12 no entran en la comparación: CL-11 vive en la base común, y el lugar de CL-12 no lo fija el repositorio |
| D-06 ¿Contra qué ancla? | Conjunto: {LG: el commit (la etiqueta `v1.2.0` sólo nombra el SHA); trazas con `@MAYOR.MENOR` del `**Versión:**` del ID, sin las copias de `_legacy/`; LGD `ia-db`: SHA fijado `4b114d7`, declarado en prosa, **sin** `base_commit`} | `LGD@b47d22b:ia-db/README.md:38,115-116`; `LG@4b114d7:SDD/Docs/Unidades-Entrega/GeometriaFactory-Web/02-Especificacion-Funcional/Casos-De-Uso/CU-10005-Enviar-Un-Trabajo-Y-Ver-El-Resultado-De-La-Interpretacion.md:5`; `LD@00171bd:SDEI/TEM-07-Marco-SDD.md:133` | Ver T1 y T7 |
| D-07 ¿Prefijos e IDs? | Prefijos externos del SDD (`CU-`, `RN-`, `ADR-`), que resuelven contra el propio repositorio; las pantallas trazan a `CU-100NN` de la unidad Web; registro mínimo propio sólo para las piezas nuevas. Clase P | `LG@4b114d7:SDD/Docs/Unidades-Entrega/GeometriaFactory-Web/02-Especificacion-Funcional/Casos-De-Uso/CU-10005-Enviar-Un-Trabajo-Y-Ver-El-Resultado-De-La-Interpretacion.md:1,3`; `LD@00171bd:SDEI/TEM-07-Marco-SDD.md:140,266-267` | Un prefijo nuevo en un registro compartido sería H; no aparece en este caso |
| D-08 ¿Esquema de frontmatter? | El SDD conserva su encabezado propio y **no** se migra: su frontmatter no se controla y lo que no lo tiene sólo avisa; las piezas nuevas llevan el frontmatter del anexo de esquema del SDEI (el RRD con los diez campos más `description` y `doc_type: rrd`; la página de ayuda, su esquema propio con `title` y `roles`). Coincide si la ficha deja el SDD sin migrar y somete las piezas nuevas al esquema del SDEI; el detalle de campos por pieza es diagnóstico | `LG@4b114d7:SDD/Docs/Unidades-Entrega/GeometriaFactory-Web/02-Especificacion-Funcional/Casos-De-Uso/CU-10005-Enviar-Un-Trabajo-Y-Ver-El-Resultado-De-La-Interpretacion.md:1-8` (encabezado en prosa); sólo 5 de 560 `.md` vigentes de `SDD/Docs` abren con `---` (conteo de primera línea, fuera de `_legacy/`); `LD@00171bd:SDEI/TEM-07-Marco-SDD.md:256-259` (la compuerta recibe sólo las carpetas nuevas; el SDD no se controla); `LD@00171bd:SDEI/TEM-07-Marco-SDD.md:140` (el RRD es un archivo `doc_type: rrd`); `LD@00171bd:SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:41-55` (diez campos más `description`, `rrd` en `doc_type`:46) y `:64` (página de ayuda: `title` y `roles`) | Ver T3 (versión doble en uno de los cinco) |
| D-09 ¿Cómo corre la compuerta? | Clase **H** (configuración de la organización). Hecho: LG no tiene control documental; LGD tiene `Verificar` en `ubuntu-latest`. Default: llamar al workflow reutilizable `docs-guard` de `LD` (misma organización), sólo sobre las carpetas nuevas | `LG@4b114d7:.github/workflows/ci.yml:47`, `e2e.yml:69`, `deploy-front-ftp.yml:50`; `git grep -l docs-guard 4b114d7` → 0; `LGD@b47d22b:.github/workflows/verificar.yml:1-20`; `LD@00171bd:SDEI/00-Marco.md:139-145`; `LD@00171bd:SDEI/TEM-07-Marco-SDD.md:246` | `TEM-07:246` declara dos cambios pendientes de `dg.py` para un SDD en el mismo repositorio: marcarlo «pendiente» no es discrepancia |
| D-10 ¿Qué bloquea y qué avisa? | Bloquea sólo el control que cumple las cinco condiciones, con línea de base medida antes; hasta que la línea de base sea 0, avisa. La compuerta recibe sólo las carpetas nuevas (ayuda, RRD); los documentos del SDD sirven de registro y no se controlan | `git grep -l docs-guard 4b114d7` → 0 (no hay línea de base previa); `LD@00171bd:SDEI/TEM-06-Compuertas-Y-CI.md:109-120`; `LD@00171bd:SDEI/TEM-07-Marco-SDD.md:256-259` | — |
| D-11 ¿Quién decide qué? | Clase **H**. Hecho: delegación del merge asentada por escrito en los dos repositorios (LG desde el PO; LGD con techo de 20 min); lo de clase H del producto es del PO | `LG@4b114d7:AGENTS.md:55-65`; `LGD@b47d22b:README.md:11-31`; `LD@00171bd:SDEI/00-Marco.md:151-162` | La ficha no puede «decidir» la delegación: la describe y la deja a la persona. **[r4, E-1]** Coincide también «decidida por el PO» con ancla que resuelva: `LG@4b114d7:AGENTS.md:65` o `LGD@b47d22b:README.md:17-19` |
| D-12 ¿Canales para agentes? | Clase **H** (`AGENTS.md`). Hecho: `AGENTS.md` en LG (derivado del contrato de agentes, no se edita a mano); LGD sin `AGENTS.md`; índice interno `ia-db/` en LGD; sin `llms.txt` (no hay sitio). Default: `AGENTS.md` puntero en cada repositorio más la ia-db existente | `LG@4b114d7:AGENTS.md:1-5`; `git ls-tree -r --name-only b47d22b \| grep -c '^AGENTS.md$'` → 0; `LGD@b47d22b:ia-db/README.md:38`; `LD@00171bd:SDEI/TEM-04-Doble-Audiencia.md:89` | — |
| D-13 ¿Ayuda al usuario final? | Por rol (Alumno, Administrador), en un solo idioma (castellano), con la confidencialidad por rol resuelta en el servidor; contextual y mínima, sin manual | `LG@4b114d7:src/GeometriaFactory.Domain/Values/Role.cs:12-19`; `LG@4b114d7:src/GeometriaFactory.Api/Endpoints/WorkEndpoints.cs:106`; `git grep -c -E 'AddLocalization\|IStringLocalizer' 4b114d7 -- src` → 0 archivos y 0 `.resx`; `LG@4b114d7:SDD/Docs/Unidades-Entrega/GeometriaFactory-Web/03-UX-UI-DX/Experiencia-De-Uso.md:100` | Hoy no hay ayuda construida: «ninguna» como estado es diagnóstico, no el valor de diseño |
| D-14 ¿Qué es privado y cómo se nombra? | Alias por destino privado más barrido antes de cada PR público. Destinos que el barrido encuentra en el caso: una ruta absoluta a la base de conocimientos de la organización y una etiqueta de runner con nombre de máquina | `LGD@b47d22b:ia-db/README.md:40` (público de consulta); `LGD@b47d22b:README.md:14` (ruta absoluta fuera del repositorio); `LG@4b114d7:.github/workflows/e2e.yml:69` (etiqueta de runner); `LD@00171bd:SDEI/00-Marco.md:177` | La lista concreta de destinos es diagnóstico; coincide si la ficha fija alias más barrido |
| D-15 ¿Cuerpo formativo? | No | `git ls-tree -r --name-only b47d22b -- PROMPTs/Guides` → sólo `.gitkeep`; `LG@4b114d7:AGENTS.md:9-11` (producto con dos unidades de entrega, no corpus de guías); `LD@00171bd:SDEI/00-Marco.md:76-81` | Los `samples/` son ejemplos ejecutables del producto, no un cuerpo formativo |
| D-16 ¿Idioma y estilo? | Castellano rioplatense para el texto; identificadores de código en inglés; nombres según la norma de nomenclatura del proyecto | `LG@4b114d7:AGENTS.md:36`; `LG@4b114d7:SDD/Docs/Unidades-Entrega/GeometriaFactory-Web/03-UX-UI-DX/Glosario-UX.md:207` | — |
| D-17 ¿Carril programado? | Sí: semanal, sólo avisa; vigila el atraso de la revisión indexada de la ia-db (`4b114d7`) frente a la rama principal de LG, enlaces externos y frescura de 365 días | `git grep -n -E 'schedule:\|cron:' 4b114d7 -- .github` y `… b47d22b -- .github` → 0 (no existe); `LGD@b47d22b:ia-db/README.md:38,115-116`; `LD@00171bd:SDEI/00-Marco.md:51`; `LD@00171bd:SDEI/TEM-06-Compuertas-Y-CI.md:44,104` | Coincide si nombra la ia-db como pieza con ancla fijada a vigilar; frecuencia distinta de semanal es discrepancia |

## 2. Trampas de `N4` §7.3 (siete)

«Despliegue del PO intocable» no es fila: pasa a **restricción** (ver §4).

| Fila | Valor admitido (la ficha la nombra con ruta:línea correcta) | Ancla | Nota |
| --- | --- | --- | --- |
| T1 `_legacy/` duplica IDs | `_legacy/` repite IDs vigentes: excluirlo del registro o la traza da ambigua | `LG@4b114d7:SDD/Docs/Producto/Contratos-Inter-Unidad/CU-08002-Contrato-De-Administracion-De-Cuentas.md:1,5` (1.11) frente a `…/_legacy/2026-09-13/CU-08002-Contrato-De-Administracion-De-Cuentas-v1.9.md:1,5` y `…/_legacy/2026-09-14/CU-08002-Contrato-De-Administracion-De-Cuentas-v1.10.md:1,5`; 679 archivos bajo `_legacy/` (`git ls-tree`) | Vale cualquier par vigente/congelado con el mismo ID |
| T2 Pantalla → `CU-100NN` | La ayuda de una pantalla traza al caso de uso de la unidad Web (`CU-100NN`), no al de la Api (`CU-000NN`) ni al inter-unidad (`CU-080NN`) | `LG@4b114d7:SDD/Docs/Unidades-Entrega/GeometriaFactory-Web/02-Especificacion-Funcional/Casos-De-Uso/CU-10005-Enviar-Un-Trabajo-Y-Ver-El-Resultado-De-La-Interpretacion.md:1,3`; `LD@00171bd:SDEI/TEM-07-Marco-SDD.md:266-267` | — |
| T3 Versión doble (caso R) | Un documento declara la versión dos veces y no coinciden: una sola fuente de versión, o regla de precedencia | `LG@4b114d7:SDD/Docs/Producto/11-Documentacion/README.md:8` (`version: "1.3"`) frente a `:22` (`**Versión:** 1.4`) | — |
| T4 XML apagado | La referencia .NET (CL-04) no se genera: `GenerateDocumentationFile` en `false` | `LG@4b114d7:Directory.Build.props:26` | — |
| T5 Categoría 11 planificada | La documentación técnica de entrega es un plan: casi todo en `Planificado`; vigentes sólo los README, la bitácora, el contrato de agentes y `AGENTS.md` | `LG@4b114d7:SDD/Docs/Producto/11-Documentacion/README.md:75,99,108-113` | — |
| T6 Límite de ADR-10010 | **Sin oráculo** | — | Motivo: el ADR-10010 no existe en `4b114d7` (`git diff --stat 4b114d7 5f07b12` lo muestra como archivo agregado después; `find -name 'ADR-10010*'` sobre el árbol del caso → nada). La trampa no es detectable en el SHA del insumo. Lo más cercano en `4b114d7`, «la ayuda es contextual y mínima, sin manual» (`Experiencia-De-Uso.md:100`), ya cuenta en D-13 |
| T7 ia-db sin `base_commit` | La ia-db ancla la revisión en prosa y no usa `base_commit` | `LGD@b47d22b:ia-db/README.md:38`; `git grep -c base_commit b47d22b` → 0 | — |

## 3. Artefactos A-01…A-11

**Sin oráculo de valor, fuera de *n*.** Motivo: M2 compara sólo decisiones y trampas (`F099` §5.5, M2); lo que el
aplicador produce lo miden M6 (compuerta sobre A-02…A-07) y M4 (rutas citadas). Abajo, los hechos del SHA que el
refutador puede usar.

| Fila | Valor | Hecho verificable en el SHA |
| --- | --- | --- |
| A-01 Ficha de diseño | Sin oráculo: es la salida comparada en §1 y §2 | — |
| A-02 Registro de prefijos | Sin oráculo | No hay registro de prefijos documental en LG ni LGD; los prefijos del SDD están en sus encabezados (`CU-10005…md:1`) |
| A-03 Esquema de frontmatter | Sin oráculo | 5 de 560 `.md` vigentes de `SDD/Docs` con frontmatter YAML |
| A-04 RRD inicial | Sin oráculo | No existe; su carpeta la fija el escalón 2 (`LD@00171bd:SDEI/TEM-07-Marco-SDD.md:140`) |
| A-05 `AGENTS.md` puntero | Sin oráculo | LG lo tiene, derivado y «No editar acá» (`LG@4b114d7:AGENTS.md:3-5`); LGD no lo tiene |
| A-06 Instancia de «Cómo intervenir» | Sin oráculo | No existe en ninguno de los dos repositorios |
| A-07 Workflow de la compuerta y guion local | Sin oráculo | LG sin control documental; LGD con `Verificar` (`LGD@b47d22b:.github/workflows/verificar.yml:1-20`) |
| A-08 Línea de base y excepciones | Sin oráculo | No hay línea de base previa (`git grep -l docs-guard 4b114d7` → 0) |
| A-09 `source.lock` o `base_commit` | Sin oráculo | La ia-db ancla en prosa (`LGD@b47d22b:ia-db/README.md:38`) |
| A-10 Carril programado | Sin oráculo | No hay workflow programado en ninguno de los dos repositorios |
| A-11 Entrada en índice y CHANGELOG | Sin oráculo | `LG@4b114d7:changelog.md:1`; `LGD@b47d22b:changelog.md:1-8` |

## 4. Restricción (no es fila)

**0 escrituras fuera del lugar del ensayo.** Ni en LG, ni en LGD, ni en el despliegue real. Anclas: los contenedores
del despliegue son del PO (`LG@4b114d7:AGENTS.md:64`; `LGD@b47d22b:ia-db/README.md:103-105`); `PROMPTs/` es del PO
(`LG@4b114d7:AGENTS.md:59`; `LGD@b47d22b:README.md:5`). Una escritura fuera del lugar del ensayo invalida la corrida.

## 5. Valores sellados

| Valor | Cifra |
| --- | --- |
| *n* (filas con oráculo) | **23** = 17 decisiones (D-01…D-17) + 6 trampas (T1–T5, T7). *n* sigue a `F099` §5.5, fila M2 («decisiones `D-01…D-17` y trampas»), que manda sobre `F016` §4.2 («decisiones P»): incluye las cuatro filas H, que se juzgan con la regla de clase H de «Comparación (M2)» |
| Umbral M2 | **3** = ⌊0,15 · 23⌋ |
| Clase H (M3) | **D-03, D-09, D-11, D-12** |
| Sin oráculo | T6 (no existe en el SHA del caso); A-01…A-11 (fuera de M2) |
| Trampas con oráculo | 6 de 7; el criterio T de `F016` §4.2 («≥ 6 de 7») queda con denominador 6 en este SHA: lo recalcula la mesa, no este oráculo |

---

# Parte II — Filas de audiencia (D-18 y ajustes de `F399`)

**Comparación.** Rige la regla M2 de la Parte I (conjunto igual a uno admitido; clase H: la ficha la marca H, la lista
con opciones para una persona y no la da por decidida). Lo que la ficha nombre de A-12/A-13 es **diagnóstico** (§II.3).

**Hechos del caso que valen para todo el bloque.** Dos papeles cerrados, `Student` («Alumno») y `Administrator`
(`LG@4b114d7:src/GeometriaFactory.Domain/Values/Role.cs:12-19`); la credencial lleva el papel como reclamo
`ClaimTypes.Role` (`LG@4b114d7:src/GeometriaFactory.Infrastructure/Security/AccessTokenIssuer.cs:25,62`); no hay
tercera identidad ni credencial de aplicación (`LG@4b114d7:SDD/Docs/Unidades-Entrega/GeometriaFactory-Api/05-Arquitectura-Tecnica/Adrs/ADR-00009-La-Api-Autentica-Personas-No-Aplicaciones.md:33-35`).
No hay políticas de autorización con nombre: los puntos piden sólo `RequireAuthorization()` y el papel se exige dentro
del punto o del caso de uso (`LG@4b114d7:src/GeometriaFactory.Api/Endpoints/WorkEndpoints.cs:106,146,497-501`;
`LG@4b114d7:src/GeometriaFactory.Application/Accounts/GovernCommissionAccountsUseCase.cs:61`). Menús disjuntos por
papel (`LG@4b114d7:src/GeometriaFactory.Web/Components/Layout/WorkShell.razor:163-175`).

## II.1 Filas con oráculo

| Fila | Valor o conjunto admitido | Ancla | Nota |
| --- | --- | --- | --- |
| AUD-01 D-18 · perfil | Perfil **mínimo** (roles planos con jerarquía declarada, nivel, `nivel-vs-repo`), o mínimo **más la extensión superficie**. Clase P. No admite «sin audiencias declaradas» (D-01 da roles) | Roles: `Role.cs:12-19`; perfil y obligatoriedad: `LD@ad8de01:SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:104-109` | Activar alcance, `canal_agente`, `cumple`, localizador por audiencia o identificador de contexto sin fila de D-01 que los registre es discrepancia |
| AUD-02 Audiencias detectables | Conjunto A = {Alumno, Administrador}; conjunto B = A ∪ {visitante sin sesión (nivel `publico`)}. Ni «agente» ni «integrador/cliente externo» como audiencia con acceso propio | `Role.cs:12-19`; `ADR-00009…md:33-35` (dos identidades; cliente = aplicación que actúa por una persona); sin sesión: `LG@4b114d7:src/GeometriaFactory.Api/Endpoints/AccountEndpoints.cs:79,123` (registro `AllowAnonymous`); agente lector: `LD@ad8de01:SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:63-64` | Quien lee la documentación de la API usa la cuenta de una persona: es lector/canal, no audiencia |
| AUD-03 Jerarquía | **Plana**: Administrador **no** incluye a Alumno (ningún `incluye:` entre los dos) | `WorkEndpoints.cs:106` (punto de alumno rechaza al administrador: `StudentOnly`); `WorkShell.razor:163-175` (destinos disjuntos); jerarquía y clase H de su cambio: `LD@ad8de01:SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:111-113` | Declarar Administrador ⊃ Alumno es discrepancia |
| AUD-04 Alcance | No activado, o tipo `generico`. **No** `por-aplicacion` | Un solo administrador por despliegue: `LG@4b114d7:src/GeometriaFactory.Infrastructure/Persistence/Configurations/AccountConfiguration.cs:68-71` (`UX_Account_SingleAdministrator`); una comisión: `LG@4b114d7:src/GeometriaFactory.Domain/Entities/Account.cs:7`; `LD@ad8de01:SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:114-116` | — |
| AUD-05 Superficies | Conjunto {panel} o {panel, servicio}. **Sin** paquete instalable (no hay app móvil ni WebAssembly): `paquete-sin-fuga` no aplica | Panel Blazor Interactive Server: `LGD@b47d22b:ia-db/README.md:41`, `LG@4b114d7:src/GeometriaFactory.Web/App.razor:13`; servicio HTTP: `LG@4b114d7:AGENTS.md:11`; `LD@ad8de01:SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:117-119` | Declarar app móvil, SDK o WebAssembly es discrepancia |
| AUD-06 Nivel por pieza | Niveles usados ⊆ {`publico`, `producto`}: ayuda por rol (Alumno, Administrador) = `producto`; ayuda de ingreso/registro, si la hay = `publico`. Ninguna fuente `restringido` ni `interno` | `LD@ad8de01:SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:121-131`; ver AUD-07 | — |
| AUD-07 `nivel-vs-repo` | Los dos repositorios son públicos de consulta: sólo admiten fuentes `publico` o `producto`; la regla se nombra como control | `LG@4b114d7:README.md:3`; `LGD@b47d22b:ia-db/README.md:40`; `LD@ad8de01:SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:121-124` | — |
| AUD-08 Punto de aplicación | **Servidor** (y build para `publico`): la entrega por papel se decide con el reclamo del token en el servidor; el menú no protege. Par de entrega: **pendiente** (no hay ayuda construida), con no autorizado = **404** sin contenido, coherente con la regla del caso | Papel en servidor: `WorkEndpoints.cs:106,497-501`, `GovernCommissionAccountsUseCase.cs:61`; 404 de seguridad: `WorkEndpoints.cs:31-34`; `LD@ad8de01:SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:133-136,146-148` | Declarar el par «verde» sin prueba es discrepancia; 403 en vez de 404 es diagnóstico |
| AUD-09 Exposición de documentación de API | Clase **H**. Hecho: **un** documento OpenAPI (`/openapi/v1.json`) con todos los puntos, sin grupo por exposición, y el explorador Scalar (`/documentacion`), anónimos; siempre en desarrollo, fuera de desarrollo sólo con `Documentacion__Publicada=true`. Opciones: no publicar fuera de desarrollo · un documento público · documentos por exposición. Default: no publicar fuera de desarrollo | `LG@4b114d7:src/GeometriaFactory.Api/Composition/ApiDocumentation.cs:37-43,58,101-117`; `LG@4b114d7:changelog.md:488-491` (decisión de quien despliega); `LG@4b114d7:SDD/Docs/Producto/Adrs/ADR-08008-La-Superficie-HTTP-Se-Describe-Y-El-Explorador-No-Se-Publica-Solo.md:6`; `LD@ad8de01:SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:141-144` | La ficha puede anotarla «decidida por el PO» con `ADR-08008` en lo existente; todo **ensanchamiento** queda H abierta. Darla por decidida por la ficha es discrepancia |
| AUD-10 D-01 ajustado (inventario) | El inventario nombra roles (2), superficies (panel y servicio), alcance (uno, sin inquilinos) y **un** documento OpenAPI | `Role.cs:12-19`; `AccountConfiguration.cs:68-71`; `ApiDocumentation.cs:37,58`; `F399` §4 fila D-01 | **[r4, E-3]** Omitir del inventario el documento OpenAPI **o el alcance** (uno, sin inquilinos) es discrepancia; cada uno cuenta en la misma fila |
| AUD-11 D-12 ajustado | El agente lee con la audiencia y el alcance de su usuario, por el **mismo** filtro que la página; sin acceso ni audiencia propios | `ADR-00009…md:35` (no hay identidad de aplicación); `LD@ad8de01:SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:63-64`; `LD@ad8de01:SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:63,79` | — |
| AUD-12 D-13 ajustado (punto de uso) | Hay formularios: la opción «en el punto de uso» se **activa** con «recursos con anclas desde la ficha» o «catálogo con traza» (no «ninguno»); etiqueta y error iguales para los dos papeles; sin variante por audiencia en el cliente | Formularios con pista ligada: `LG@4b114d7:src/GeometriaFactory.Web/Components/Pages/WorkSubmission.razor:306,336-339`, `AccountRegistration.razor:125,152-153`; microtexto literal en `.razor`, 0 `.resx` (`git ls-tree -r --name-only 4b114d7 \| grep -c '\.resx$'` → 0); `LG@4b114d7:SDD/Docs/Unidades-Entrega/GeometriaFactory-Web/03-UX-UI-DX/Experiencia-De-Uso.md:100`; `LD@ad8de01:SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:251-275` | Capas y traza `ID@versión` por campo son diagnóstico |

## II.2 Clase H del bloque

**AUD-09** (exposición y todo ensanchamiento de la documentación de API). Cambio de jerarquía: ninguno propuesto en el
caso; si la ficha propone uno, es H (`TEM-05:113`).

## II.3 A-12 y A-13 (diagnóstico, fuera de *n*)

| Id | Hecho en el SHA | Uso |
| --- | --- | --- |
| A-12 Registro de audiencias (`AUD-`) | No existe en LG ni LGD (`git grep -E 'AUD-[0-9]\|delivery:'` sin coincidencias propias); por DE-28 debería producirse con perfil mínimo: dos filas planas y nivel | Diagnóstico de AUD-01…AUD-07 |
| A-13 Tabla de controles | No existe; controles esperables: `nivel-vs-repo`, `audiencia-vocabulario`, `delivery-clave-cercana`, `cruce-de-audiencia`, `contrato-por-exposicion`, todos en «avisa» hasta su par (DE-30) | Diagnóstico de AUD-07 y AUD-09 |

## II.4 Valores sellados del bloque

| Valor | Cifra |
| --- | --- |
| *n_audiencia* | **12** (AUD-01…AUD-12) |
| Umbral | **1** = ⌊0,15 · 12⌋ |
| Clase H (M3) del bloque | **AUD-09** |
| Heredado (Parte I, sin cambio) | *n* = 23, umbral = 3, H = D-03, D-09, D-11, D-12 |
