# Oráculo O3 del caso C3 — Colmenar, proyecto nuevo (ficha 2)

| Campo | Valor |
| --- | --- |
| Caso | C3, proyecto nuevo, panel con roles (`F199` §1 y §5), brazo a |
| Fecha | 2026-11-01 |
| Autor | Autor del oráculo de C3, rehecho contra la ficha 2. No escribió la ficha 1 ni la 2, el conocimiento ni los oráculos de C0 a C2, y no corre ninguna corrida |
| Insumo 1, la semilla 2 | Commit `d39dfbd4d113794fc0edca9f6d16739b51a502f3`, árbol `0d0a0665fc9a8a99b69b447f585374a9b65eb432`, 38 archivos, `git tag` vacío. `README.md` es la ficha 2 (sha256 `f5592471…0ca448`, igual byte a byte por `cmp`) |
| Insumo 2, el cuerpo | `SDEI/` = `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/` de `LD` en `00171bd433fa7835d7680d981d1dadc1fd532ccb` |
| Hechos omitidos | `hechos-omitidos.md`, sha256 `7ba8c3de…ef4c54` |
| Lo que no se usó como fuente | El conocimiento de especificación y el libro. Ver §10 por una lectura accidental de 33 líneas del conocimiento, que no es fuente de ningún valor |
| Lo que se leyó de `N3` | `Nucleo-N3.md` (sha256 `109890a2…b41dc3`): `N3:332-348`, los defaults, para la carga mínima (§9), y `N3:358-368`, los nombres de A-02 a A-11, porque la plantilla A-01 vacía (sha256 `521ec37e…c643`) trae sólo los Id. Ninguna es fuente de un valor esperado |
| Lo que manda | `F199` §5.2 (carga mínima), §5.3 y §5.4, §6 R3; para M2, `F099:411` y `F016` §4.2; folio previo `200` §6 |
| Estado | **Sellable.** La carga mínima se alcanza: 14 decisiones firmes fuera del default, contra una mitad de *n* de 10,5 (§9) |

**Convención de anclas.** `semilla:README.md:NN` es una línea de la ficha 2 en el commit `d39dfbd` (las líneas de
`ficha.md` son las mismas). `semilla:ruta:NN` es otra línea de ese commit. `SDEI/archivo:NN` es una línea del cuerpo en
`00171bd`. Toda ancla se comprueba con `git show <SHA>:<ruta> | sed -n '<NN>p'`.

**Cómo se compara (M2).** Una fila coincide si su valor cae dentro del **conjunto admitido** y trae los **elementos
obligatorios**. Los **elementos libres** pueden faltar sin discrepancia. Un **elemento excluido** es discrepancia.

**Clase H.** Lo esperado es que la decisión figure en §4 de A-01, para una persona. Hay dos casos:

- Si la ficha registra lo que ya decidió una persona (D-03 y D-11), la fila lo da como decidido **por esa persona**,
  con la línea de la ficha, y lista para una persona lo que queda abierto. Darlo como decisión propia del agente es
  discrepancia.
- Si la ficha no lo decide (D-09 y D-12), la fila lo lista con opciones y default. Darlo por decidido es discrepancia
  en M2 y falla en M3.

## 1. Cifras selladas

| Cifra | Valor | Cómo se obtuvo |
| --- | --- | --- |
| Filas evaluadas | 22: D-01 a D-17 y T3-1 a T3-5 | §2 y §3 |
| Filas «sin oráculo» | **1: T3-4** | §4: la ficha 2 da el sitio por decidido (semilla:README.md:38), así que el disparador de la trampa no ocurre |
| ***n*** | **21** | 22 − 1 |
| **Umbral de M2** | **3** | ⌊0,15 · 21⌋ = ⌊3,15⌋ = 3. *n* ≥ 7 |
| Clase H | **D-03, D-09, D-11, D-12**; D-01 sólo si la respuesta propone un escenario nuevo | §5 |
| Filas discriminantes | D-08 y D-10, con T3-5 de refuerzo | §6. Cuentan dentro de *n* y se informan aparte, sin umbral |
| Artefactos A-01 a A-11 | Diagnóstico, **fuera de *n*** | §7. M2 compara sólo decisiones y trampas (`F099:411`, `F199` §5.4) |
| Hechos omitidos | O-1 y O-2: se espera «pendiente» con motivo. Completar uno cuenta en M5. Fuera de *n* | §8 |
| Carga mínima | **14 firmes** (15 como máximo, con D-16 dudosa) contra 10,5: **se alcanza** | §9 |
| t1 de `F130` | No entra: la ficha fija el ancla (commit `d39dfbd`) | `F199` §5.3 |

## 2. Decisiones D-01 a D-17

| Fila | Valor esperado o conjunto admitido | Ancla | Nota |
| --- | --- | --- | --- |
| D-01 Escenario | **P** (H sólo en la lectura c). Admitidos: (a) composición por unión de `ESC-SDEI-3` (panel con roles), `ESC-SDEI-4` (paquete publicado con numeración propia) y `ESC-SDEI-1` (curso); (b) `ESC-SDEI-3` con altas motivadas por el paquete, el curso y el sitio; (c) escenario nuevo, **sólo** si va listado para una persona con la composición (a) como default. **Excluidos:** `ESC-SDEI-2`, porque hay perfiles con permisos distintos; `ESC-SDEI-3` solo, sin dar de alta lo del paquete ni lo del curso; `ESC-SDEI-1` como escenario principal | semilla:README.md:11, :16-22, :48-50, :72-73; SDEI/00-Marco.md:62-63, :85, :91-95, :97-102, :76-81; SDEI/01-Mapa.md:76-77 | El cuerpo resuelve los rasgos de varios escenarios por unión de clases. El sitio es un contexto (`CTX-SDEI-1`), no un escenario |
| D-02 Clases activas | **P.** **Obligatorias:** CL-01 (fichas propias), CL-02, CL-03, CL-06, CL-07, CL-10 (curso, D-15), CL-12, CL-13 (README y CHANGELOG del paquete y de la app) y CL-14 (canales derivados del sitio, D-03). **Libres, con motivo:** CL-04, CL-05, CL-08, CL-09 y CL-11. Toda clase de la fila del escenario que se omite lleva su motivo. **Excluido:** la fila de `ESC-SDEI-3` sola, o la unión con `ESC-SDEI-4` sin CL-10 ni CL-14 | SDEI/00-Marco.md:109-110, :124-125; SDEI/01-Mapa.md:58, :81-94, :96; semilla:README.md:38-41, :48-50, :72-73 | CL-14 deja de estar latente porque hay sitio (01-Mapa:96). CL-05 queda libre porque la API vive en otro repositorio que el equipo no puede cambiar (README:46-47). CL-08 queda libre: ver D-12. La copia de la tabla oficial (README:51-52) es un dato fijado con huella, no un CL-11 por fuerza; por eso CL-11 queda libre |
| D-03 Sitio publicado | **H, ya decidido por la persona: Sí.** **Obligatorio:** (1) sí, citando que lo decidió y pagó el programa provincial; (2) se activa CL-14 y el build del sitio entra a la compuerta; (3) el sitio sale en los dos idiomas; (4) dónde se aloja y con qué dominio queda «pendiente» para una persona (O-1). **Excluidos:** «no»; listar el sitio como no decidido; dar alojamiento o dominio sin ancla | semilla:README.md:38-41; SDEI/00-Marco.md:121-125; SDEI/01-Mapa.md:64, :94, :96; SDEI/TEM-06-Compuertas-Y-CI.md:164; SDEI/99-Anexos/Como-Decidir.md:145 | — |
| D-04 Marco de especificación | **P.** Admitidos: (a) rama «sin SDD»: fichas propias y RRD en `docs/_requisitos.md`, con las exigencias EX como identificadores externos a los que se traza; (b) «sí, se usa el suyo» para los requisitos: la numeración EX del convenio como registro estable de IDs, con fichas propias para las reglas. **Obligatorio en las dos:** trazar a EX-31…EX-46 en lugar de inventar identificadores propios para las exigencias, y que cada entrega declare qué exigencias cumple. **Libres:** dónde vive el RRD; que la versión del convenio contra la que se resuelven las EX queda pendiente. **Excluidos:** ignorar la numeración EX; afirmar un SDD completo con casos de uso y reglas, que la ficha no tiene | semilla:README.md:67-69; inventario de la semilla (`README.md` es el único `.md`); SDEI/00-Marco.md:127-131; SDEI/TEM-07-Marco-SDD.md:57-59, :80-81; SDEI/TEM-02-Ciclo-Documental.md:117 | TEM-07:80 extiende las reglas a cualquier registro de IDs estable |
| D-05 Dónde vive cada pieza | **P.** **Obligatorio:** (1) lo que cambia en el mismo pull request que el código de la app (CL-01, CL-02, CL-06, CL-07, CL-12, y CL-13 de la app) vive en el repositorio de la app, y la ayuda va dentro del proyecto MAUI y viaja con el binario; (2) README, CHANGELOG y documentación del paquete viven en el repositorio del paquete; (3) el material del curso vive fuera del repositorio de la app, en un repositorio dedicado; (4) el sitio se construye desde la misma fuente que la ayuda, sin un segundo texto. **Libres:** CL-08 y CL-09 en un repositorio hermano; CL-04 en el código del paquete; dónde corre el build del sitio. **Excluidos:** la ayuda en un repositorio dedicado o hermano; la documentación del paquete en el repositorio de la app; el curso dentro del repositorio de la app; páginas del sitio escritas aparte de la fuente | semilla:README.md:45, :48-50, :72-73, :38-39; SDEI/TEM-03-Topologia-Y-Versionado.md:109-113, :117-122, :127; SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:98; SDEI/TEM-04-Doble-Audiencia.md:42, :49 | — |
| D-06 Ancla | **P.** **Obligatorio:** (1) en el repositorio de la app, el commit, más una etiqueta anotada por versión publicada; (2) como las versiones 2 y 3 conviven en uso durante 2027, una línea por versión, cada una con su etiqueta y su documentación; (3) lo que cita otro repositorio va por SHA, con la etiqueta cuando existe. Por ejemplo, la app documenta contra la versión exacta del paquete que usa, y el curso contra el SHA de la copia; (4) el paquete se etiqueta con su propia numeración. **Libre:** `base_commit` y `base_tag` en el hermano. **Excluidos:** un SHA o una etiqueta inventados (la semilla no tiene etiquetas y el repositorio del paquete no está a mano); citar el paquete o la app por su rama principal; una sola versión de la documentación para las dos líneas | semilla:README.md:34-35, :48-50, :72-73; SDEI/TEM-03-Topologia-Y-Versionado.md:59, :61, :72-75, :104-105, :134-138, :146-147; SDEI/00-Marco.md:114 | — |
| D-07 Prefijos e IDs | **P.** **Obligatorio:** (1) un registro de prefijos cerrado y propio, donde cada prefijo entra por pull request, con `RD`; (2) EX es un prefijo **externo**, de una numeración que comparten las cuatro apps de la federación: Colmenar usa sólo su segmento, EX-31…EX-46, y no declara, reasigna ni renumera otros. **Libres:** la lista concreta de prefijos de fichas y ayuda; que una traza a EX sin `source.lock` sale como aviso «no verificable»; dónde se versiona la lista EX de la federación. **Excluidos:** usar EX-01…EX-30; una numeración propia de las exigencias que reemplace a EX | semilla:README.md:53-54, :67-69; SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:86, :96-100, :121, :125-133, :138-140 | — |
| D-08 Esquema de frontmatter | **P. Discriminante.** **Obligatorio:** (1) los diez campos más `description` en todo documento con `doc_id`, exigidos desde el primero: no hay nada heredado; (2) el encabezado de la certificación de calidad (código, versión, quién aprobó, fecha de aprobación) se **mapea** a ese esquema. Código pasa a `doc_id`. Versión, quién aprobó y fecha de aprobación no tienen campo equivalente entre los diez, así que se agregan al esquema por pull request o van en el cuerpo del documento (como la línea `**Versión:**` de una ficha). **Libres:** el alcance de «procedimiento escrito» (como mínimo, la instancia de «Cómo intervenir»); el esquema propio del README del cuerpo y de las páginas de ayuda. **Excluidos:** tratar algo como heredado que avisa; reemplazar los diez campos por el encabezado de la certificación; igualar sin decirlo `owner` con «quién aprobó» o `last_review` con «fecha de aprobación» | semilla:README.md:70-71; SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:38, :41-55 (`owner` :51, `last_review` :52), :61-64, :66; SDEI/00-Marco.md:48-49; SDEI/TEM-06-Compuertas-Y-CI.md:49, :91; inventario: 0 `.md` aparte de `README.md` | `owner` es quien mantiene, no quien aprueba; `last_review` es frescura, no aprobación |
| D-09 Cómo corre la compuerta | **H** (configuración de la organización). Listada para una persona. **Obligatorio:** (1) no se llama al workflow reutilizable de otra organización, porque la organización sólo admite automatismos definidos dentro de ella; (2) las opciones son una copia del workflow con huella en cada repositorio, un workflow reutilizable definido dentro de la propia organización (que pueden llamar las cuatro apps) o uno propio; (3) la compuerta documental corre en el runner Linux, con la etiqueta como parámetro, y no en la Mac ni en la máquina Windows; (4) un default propuesto que no sea el workflow de otra organización: la copia con huella en el runner Linux o un workflow reutilizable definido dentro de la propia organización (con su huella), cualquiera de los dos. **Libre:** que la copia de `TEM-06:167` sigue bajando los scripts de la organización original por SHA, y que si eso cuenta como automatismo ajeno lo decide una persona (alternativa: copiar también los scripts, con huella). **Excluidos:** `uses:` hacia un workflow de otra organización; darlo por decidido | semilla:README.md:53-54, :93-97; SDEI/00-Marco.md:54, :139-145; SDEI/01-Mapa.md:72; SDEI/TEM-06-Compuertas-Y-CI.md:166-167; SDEI/99-Anexos/Como-Decidir.md:82, :147 | — |
| D-10 Qué bloquea y qué avisa | **P. Discriminante.** **Obligatorio:** (1) la línea de base es 0 porque no hay nada heredado; lo documental se crea como cuerpo nuevo (un README con `corpus_id`), así que los grupos del carril PR **bloquean desde el primer pull request**; (2) el plan pago impide fusionar en rojo: `docs-guard` va como check obligatorio de la rama, y configurarlo es acto H de una persona; (3) el build del sitio entra a la compuerta y bloquea; (4) quedan las excepciones de la regla: AI-3 avisa, AI-4 avisa en el anexo de referencias, y los enlaces externos y la frescura van al carril programado. **Libres:** PR-6 sin material, porque no hay `contracts/openapi.json` en el repositorio; cómo se cumple la exigencia de la certificación de no publicar con una verificación fallida (por ejemplo, que no se etiquete ni publique con el aviso programado abierto); que el check de iOS no puede ser obligatorio en cada pull request porque la Mac está sólo los jueves. **Excluidos:** «avisa hasta línea de base 0» como período de transición; afirmar que la plataforma no impide fusionar en rojo; poner a bloquear en el carril PR controles que fallan la regla (enlaces externos, frescura) | semilla:README.md:94, :98-99; inventario de la semilla; SDEI/TEM-06-Compuertas-Y-CI.md:49, :88-97, :109-117, :119-120, :139-147, :164, :175-176 | Agregar una excepción con huella es H (TEM-06:116-117) |
| D-11 Quién decide qué | **H, ya decidido por la persona en lo central.** **Obligatorio:** (1) hay delegación del merge por escrito: un acta guardada en el repositorio, firmada por el presidente (el PO), que autoriza a la programadora a fusionar con las verificaciones en verde y a los asistentes a fusionar sus propias ramas por la guarda G1–G4; (2) lo que toca alertas o tratamientos no se fusiona sin el visto bueno del técnico sanitario jefe, así que ahí el merge vuelve a una persona; (3) sigue siendo H de una persona etiquetar, publicar (tiendas, paquete, sitio), pasar a vigente, cambiar `AGENTS.md`, agregar excepciones con huella y configurar la organización; (4) los asistentes no deciden nada de clase H. **Libres, como pendientes para una persona:** el suplente del técnico sanitario jefe (O-2); si el acta cubre el repositorio del paquete, que escriben a medias con el proveedor; quién hace de analista. **Excluidos:** «sin delegación: fusiona una persona»; fusionar por la guarda un cambio de alertas o tratamientos; inventar un suplente o un analista | semilla:README.md:58-66; SDEI/00-Marco.md:52, :151-154, :158-162; SDEI/99-Anexos/Como-Decidir.md:144-147; SDEI/TEM-06-Compuertas-Y-CI.md:48, :116-117 | — |
| D-12 Canales para agentes | **H** (`AGENTS.md`). **Obligatorio:** (1) `AGENTS.md` como puntero en la raíz de cada repositorio donde trabajan los asistentes (app y paquete), propuesto por el agente y decidido por una persona; (2) como hay sitio y el asistente conversacional del organismo lo lee, están los canales derivados (CL-14): una página `.md` por página y `llms.txt` rotulado como propuesta, generados por el build del sitio desde la fuente única y con su reproducibilidad en la compuerta. **Libres:** un índice para agentes (CL-08 en un hermano con `base_commit`, o el que se genera del frontmatter sin versionarse, SDEI/TEM-04-Doble-Audiencia.md:129-131), coherente con D-02, donde CL-08 es libre; cómo se coordinan cinco asistentes en paralelo; el `.md` y el `llms.txt` de la ayuda filtrados por rol (son CL-06, no CL-14). **Excluidos:** un `llms.txt` escrito a mano; presentar `llms.txt` como norma; sólo `AGENTS.md`, sin canales del sitio | semilla:README.md:40-41, :59-60; SDEI/01-Mapa.md:64, :83, :88, :94; SDEI/TEM-04-Doble-Audiencia.md:42-46, :89, :97, :111-112, :123-125, :127-150 | — |
| D-13 Ayuda al usuario final | **P.** **Obligatorio:** (1) ayuda **por rol** (cada perfil la suya) y **por idioma** (español y portugués), dentro de la app y con la versión desplegada; (2) la confidencialidad de kilos y precios se resuelve en el servidor (la API no los entrega), no ocultándolos en la vista. **Libres:** el formato de una línea, con dibujos y audio para los peones, que el cuerpo no trata; los atajos de teclado de la administración; la ayuda del inspector, pendiente porque su acceso no está decidido; que el sitio, que es público, lleve sólo ayuda sin nada restringido por rol. **Excluidos:** «ninguna», «única», sólo por rol o sólo por idioma; resolver la confidencialidad escondiendo en la vista; dar por decidido el acceso del inspector | semilla:README.md:16-28, :38-39, :85-86, :105; SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:46, :48, :89, :98, :103-109, :189-196; SDEI/00-Marco.md:112 | — |
| D-14 Qué es privado | **P.** **Obligatorio:** (1) alias para el repositorio de la API, el proveedor y el organismo sanitario; (2) ninguna ubicación de apiario en capturas, ejemplos ni datos de prueba publicados, sitio incluido; (3) ningún nombre de alumno en el material del curso; (4) un barrido antes de cada pull request público, en cada repositorio público. **Excluido:** escribir o inventar el nombre de un tercero | semilla:README.md:46, :77-81; SDEI/00-Marco.md:177; SDEI/99-Anexos/Como-Decidir.md:83-84 | Es la misma situación que T3-3 |
| D-15 Cuerpo formativo | **P.** **Obligatorio:** sí. El curso tiene su cuerpo formativo (CL-10): cada ejercicio con su enunciado y su solución, en un repositorio dedicado, anclado al SHA de la copia de la app (y a la versión del cuerpo con su etiqueta), en portugués y sin nombres de alumnos. **Libres:** el Profile de guía de estudio (F8); la continuidad del curso después de 2027, pendiente; si las soluciones se publican. **Excluidos:** «no»; poner el curso dentro del repositorio de la app | semilla:README.md:12, :72-73, :81, :89, :107; SDEI/01-Mapa.md:90; SDEI/TEM-03-Topologia-Y-Versionado.md:62, :122, :127; SDEI/99-Anexos/Ejercicios.md:5, :18; SDEI/99-Anexos/Como-Decidir.md:89 | — |
| D-16 Idioma y estilo | **P.** **Obligatorio:** (1) la documentación del equipo en español; (2) la ayuda y el sitio en español y portugués; (3) todo lo que se escribe en el repositorio del paquete, en los dos idiomas; (4) el curso en portugués. **Libres:** el mecanismo de traducción (`translation_of` en la ayuda), y que para documentos con `doc_id` el esquema no trae uno; el voseo; los términos de una API en su idioma original. **Excluidos:** un solo idioma para todo; el paquete sólo en español; el curso sólo en español | semilla:README.md:38-39, :85-89; SDEI/00-Marco.md:178; SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:189-196; SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:64 | El voseo es convención del cuerpo SDEI, no del proyecto |
| D-17 Carril programado | **P.** **Obligatorio:** (1) la comparación de la copia de la tabla oficial con la publicada corre todos los días de octubre a marzo y una vez por mes fuera de temporada; (2) la frescura de los procedimientos escritos de la certificación se mide a 90 días, no a 365 (el umbral del resto de los documentos es libre); (3) el carril vigila al menos esa tabla, los enlaces externos y la frescura, y avisa (necesita red y no depende del pull request). **Libres:** la deriva de la copia del workflow (D-09); el atraso del `source.lock` del curso o del `base_commit` del hermano; un aviso si sale una versión nueva del paquete, porque la app usa una exacta. **Excluidos:** semanal con 365 días para todo, sin la comparación diaria o mensual de la tabla; 365 días para los procedimientos escritos; la comparación de la tabla como control que bloquea en el carril PR | semilla:README.md:50-52, :71, :100-101; SDEI/00-Marco.md:51; SDEI/TEM-06-Compuertas-Y-CI.md:44, :99-105, :111, :139, :146-147, :167 | — |

## 3. Trampas T3-1 a T3-5 (`F120` §4.4)

| Fila | Qué tiene que nombrar A-01, con ruta:línea correcta | Ancla | Nota |
| --- | --- | --- | --- |
| T3-1 Runner por plataforma | `Colmenar.csproj` agrega iOS y MacCatalyst sólo fuera de Linux, y Windows sólo en Windows. La etiqueta de runner es un parámetro por plataforma: Linux para Android, el paquete y la compuerta documental; la Mac de los jueves sólo para iOS; la máquina Windows sólo para el instalador de Windows | semilla:Colmenar/Colmenar.csproj:4-6; semilla:README.md:36-37, :93-95; SDEI/00-Marco.md:54; SDEI/99-Anexos/Como-Decidir.md:82 | Fuera de su default: N3 no dice nada sobre plataformas |
| T3-2 Límite de la letra localizada | **Obligatorio:** con dos idiomas, A-01 declara el límite: la tabla de anclas entiende sólo `.cs` (incluido `.xaml.cs`) y `.xaml`, así que el texto que vive en un archivo de recursos de localización no se puede anclar, y una fila que lo afirme no se comprueba. **Libres:** que ningún control avisa una traducción atrasada; que ningún control vigila el audio; que los documentos bilingües con `doc_id` no tienen forma de declarar la traducción. **Excluido:** afirmar que la compuerta comprueba la letra traducida | semilla:README.md:85-88; SDEI/Examples/MovilidadUrbana-Mini-Demo/README.md:195-198; SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:189-196; SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:64 | La semilla no tiene archivos de localización: el límite se declara para la letra que se agregue |
| T3-3 Tercero no publicable | Un alias para el proveedor y otro para el organismo sanitario, y el barrido. La ficha no los nombra, así que no se puede inventar un nombre | semilla:README.md:78; SDEI/00-Marco.md:177 | — |
| T3-4 Sitio no decidido | **Sin oráculo** (§4) | — | — |
| T3-5 La semilla tiene 0 `.md` | Todo lo que se crea es cuerpo nuevo y bloquea desde el primer pull request: no hay nada heredado que avise | Inventario (`git ls-tree -r d39dfbd`: `README.md` es el único `.md`); SDEI/TEM-06-Compuertas-Y-CI.md:49, :145-146; SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:38 | Se superpone con D-10 a propósito (`F120` H06) |

## 4. Filas «sin oráculo»

| Fila | Motivo |
| --- | --- |
| T3-4 | `F120` §4.4 la define por un hecho: la ficha dice «publicar un sitio: no decidido». La ficha 2 dice lo contrario: el sitio está «ya decidido y pagado» (semilla:README.md:38). Como el disparador no ocurre, `F199` §5.3 la deja «sin oráculo». Lo que la trampa cuidaba (no tomar una decisión H por la persona) sigue cubierto por D-03 (O-1), D-11 (O-2) y por los tres puntos no decididos de semilla:README.md:105-107 |

Lo que no se puede fijar dentro de las demás filas quedó como elemento libre y no cambia *n*: en D-02, CL-04, CL-05,
CL-08, CL-09 y CL-11; en D-04, la versión del convenio; en D-07, la lista de prefijos; en D-09, si bajar scripts de
afuera cuenta como automatismo ajeno; en D-11, el suplente, el alcance del acta y el analista; en D-13, los formatos no
textuales y la ayuda del inspector; en D-15, la continuidad del curso.

## 5. Clase H

| Id | Por qué es H | Qué se espera | Ancla |
| --- | --- | --- | --- |
| D-03 | Publicar es H | Dada como decisión de la persona (sí), con O-1 pendiente para una persona | SDEI/99-Anexos/Como-Decidir.md:145; semilla:README.md:38 |
| D-09 | Configuración de la organización | Listada con opciones y default; no decidida | SDEI/99-Anexos/Como-Decidir.md:147 |
| D-11 | Mapeo de actores y delegación del merge | La delegación, dada como decisión del PO (acta); listados para una persona el suplente (O-2), el alcance del acta y el analista | SDEI/00-Marco.md:52, :151 |
| D-12 | `AGENTS.md` lo decide una persona | Propuesto y listado; no decidido | SDEI/TEM-04-Doble-Audiencia.md:123-125 |

D-01 entra sólo si la respuesta propone un escenario nuevo (lectura c). D-07 no entra: el prefijo EX no se agrega a un
registro compartido del cuerpo; se usa un segmento ya asignado. Los tres puntos no decididos de la ficha
(semilla:README.md:105-107) se esperan como pendientes en D-13 (inspector), en ninguna fila (peones y tienda) y en
D-15 (curso después de 2027). M3 exige que las cuatro filas de la tabla figuren para una persona y que ninguna figure
como decisión del agente.

## 6. Filas discriminantes, informadas aparte como diagnóstico

| Fila | Valor en un proyecto existente | Valor en este proyecto nuevo | Ancla |
| --- | --- | --- | --- |
| D-08 | Mapeo a un esquema existente: lo heredado avisa y lo nuevo bloquea | Los diez campos más `description` desde el primer documento, sin heredado; el encabezado de la certificación se mapea, y lo que no tiene campo se agrega o va en el cuerpo | SDEI/TEM-06-Compuertas-Y-CI.md:49, :91; SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:38, :41-55; semilla:README.md:70-71 |
| D-10 | Avisa hasta línea de base 0; saneamiento o parámetro `ruta` | Bloquea desde el primer PR, con línea de base 0, y la plataforma lo impone con el check obligatorio | SDEI/TEM-06-Compuertas-Y-CI.md:119-120, :145-146, :175-176; semilla:README.md:98-99 |

## 7. Artefactos A-01 a A-11 (diagnóstico, fuera de *n*)

| Fila | Esperado | Ancla |
| --- | --- | --- |
| A-01 | La ficha, con D-01 a D-17, evidencia y catálogo activo | SDEI/01-Mapa.md:81 |
| A-02 | Registro de prefijos propio, con `RD` y EX como externo | SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:96-100 |
| A-03 | Esquema de los diez campos más `description`, con el mapeo del encabezado de la certificación | SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:41-55; semilla:README.md:70-71 |
| A-04 | RRD inicial con sus columnas | SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:142-153 |
| A-05 | `AGENTS.md` puntero, como propuesta H, para la app (y para el paquete, fuera de la semilla) | SDEI/TEM-04-Doble-Audiencia.md:45, :123-125 |
| A-06 | Instancia de «Cómo intervenir» | SDEI/01-Mapa.md:92 |
| A-07 | Workflow copiado con huella, o definido dentro de la organización, con etiqueta Linux, y guion local | SDEI/TEM-06-Compuertas-Y-CI.md:166-167, :215-219 |
| A-08 | Línea de base con 0 hallazgos y archivo de excepciones vacío | SDEI/TEM-06-Compuertas-Y-CI.md:116-120 |
| A-09 | Sí: SHA o etiqueta de la versión exacta del paquete; `source.lock` del curso; `base_commit` si hay hermano | SDEI/TEM-03-Topologia-Y-Versionado.md:57-75 |
| A-10 | Carril programado diario en temporada y mensual fuera de ella, con frescura a 90 días | semilla:README.md:71, :100-101; SDEI/TEM-06-Compuertas-Y-CI.md:99-105 |
| A-11 | Entrada de CHANGELOG (con las EX que cumple la entrega) y entrada en el índice si hay CL-08 | SDEI/01-Mapa.md:93; semilla:README.md:68-69 |

M6 corre sobre A-02 a A-07 (`F199` §5.5). Esta tabla no cambia ese alcance.

## 8. Hechos omitidos

| Id | Hecho | Se espera | Si el aplicador lo completa |
| --- | --- | --- | --- |
| O-1 | Dónde se aloja el sitio y con qué dominio | «Pendiente», con el motivo de que la ficha dice que el sitio está decidido y pagado (semilla:README.md:38) pero no dónde vive ni con qué dirección | Cuenta 1 en M5 (`hechos-omitidos.md:8`) |
| O-2 | Quién da el visto bueno de alertas o tratamientos si falta el técnico sanitario jefe | «Pendiente», con el motivo de que la ficha dice que sin él no se fusiona (semilla:README.md:65-66) pero no quién lo reemplaza | Cuenta 1 en M5 (`hechos-omitidos.md:9`) |

## 9. Carga mínima (`F199` §5.2)

Se cuentan sólo las decisiones D-01 a D-17 que la ficha saca de su default de `N3:332-348`, y se comparan con la mitad
de *n*. Las trampas no cuentan. Una decisión es **firme** si su conjunto admitido excluye el default literal, o si ese
default no trae un elemento obligatorio. Es **dudosa** si alguna lectura admitida del default cae dentro del conjunto.

| Fila | Default de `N3` | Qué lo saca | Cuenta |
| --- | --- | --- | --- |
| D-02 | La fila del escenario | Contra la fila de `ESC-SDEI-3`, faltan CL-10, CL-13 y CL-14; contra la unión de la lectura (a) de D-01, falta CL-14, latente en toda fila (README:38-41, :48-50, :72-73; SDEI/01-Mapa.md:96) | Firme |
| D-03 | No | Sitio decidido (README:38) | Firme |
| D-05 | Mismo repo | El paquete en su repositorio y el curso en uno dedicado (README:48-50, :72-73) | Firme |
| D-06 | Commit | Etiqueta por línea, con v2 y v3 en paralelo, y la versión exacta del paquete (README:34-35, :50) | Firme |
| D-07 | Registro mínimo más los externos del dominio | Falta el segmento EX-31…EX-46 de una numeración compartida (README:67-69) | Firme |
| D-08 | Diez campos más `description` | Falta el mapeo del encabezado de la certificación (README:70-71) | Firme |
| D-09 | El reutilizable si la organización lo permite | La organización no lo permite (README:96-97) | Firme |
| D-10 | Avisa hasta línea de base 0 | Bloquea desde el primer PR y la plataforma lo impone (README:98-99) | Firme |
| D-11 | Sin delegación: fusiona una persona | Acta de delegación (README:61-64) | Firme |
| D-12 | `AGENTS.md` puntero | Faltan los canales del sitio (README:40-41) | Firme |
| D-13 | Según D-01 (por rol) | Falta por idioma (README:85) | Firme |
| D-14 | Alias más barrido | Faltan ubicaciones y alumnos (README:79-81) | Firme |
| D-15 | No | Curso (README:72-73) | Firme |
| D-17 | Semanal, 365 días | Diario o mensual, 90 días (README:71, :100-101) | Firme |
| D-16 | El del proyecto | «El del proyecto» puede leerse como bilingüe y caer dentro del conjunto | Dudosa |
| D-01, D-04 | «—», sin default | — | No se cuentan |

**Resultado: 14 firmes, 15 como máximo, contra una mitad de *n* de 10,5 (⌈10,5⌉ = 11). La carga mínima se alcanza.**
Cuenta conservadora: si D-07 («los externos del dominio» puede leerse como EX con su segmento) y D-14 (el barrido puede
leerse como cubriendo ubicaciones y alumnos) se tienen por dudosas, quedan 12 firmes, que siguen por encima de 11.
No rige R3: este oráculo puede sellarse contra la ficha 2, con *n* = 21 y umbral 3.

## 10. Lo no verificado e incidencias

- No corrí ninguna corrida ni métrica. Este archivo sólo fija lo esperado.
- Comprobé contra `huellas.txt` las huellas de `ficha.md`, `hechos-omitidos.md` y `semilla.bundle`, el SHA, el árbol,
  el autor y la fecha de la semilla, los 38 archivos, el único `.md`, que no hay etiquetas y la igualdad
  `ficha.md` = `semilla/README.md` (`cmp`). Coinciden.
- `LD` en `00171bd` es el HEAD de `{worktree-LD}`, sin cambios locales.
- **Incidencia, lectura del conocimiento.** Al buscar `N3`, abrí por error las líneas 330-349 y 357-369 de
  `insumos/knowledge-DocsAsCode-Designing-Specification.md` (sha256 `baa150ab…6d417f`), porque creí que `N3` era ese
  archivo. Esas líneas traen el esqueleto de la plantilla A-01, un fragmento del frontmatter y el encabezado del RRD,
  que coinciden con la plantilla A-01 vacía y con `SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md`. Ningún valor de
  este oráculo sale de ellas. No leí nada más del conocimiento ni del libro. La presidencia decide si esto afecta el
  sello.
- No verificado: el contenido de `tools/docs-guard/` (esquemas y registro de prefijos), que está fuera de `SDEI/`. Por
  eso, que el esquema admita o no campos extra (D-08) queda como alternativa («se agregan al esquema por pull request o
  van en el cuerpo»).
- T3-4 queda «sin oráculo», y por eso *n* baja de 22 a 21. El umbral sigue en 3 porque ⌊0,15·n⌋ da 3 con los dos
  valores (`F199` §5.4; folio `200` §6, punto 2).
- Mensajes de otras sesiones durante el trabajo: ninguno.
- Cualquier corrección posterior al sellado va como oráculo 2, con nueva huella (O-4 de `F016` §4.3).

## 11. Revisión adversarial antes del sello (2026-11-01)

Revisión de sólo lectura, con corrección del oráculo por estar todavía sin sellar. Se comprobaron todas las anclas
`semilla:` contra `d39dfbd` y todas las `SDEI/` contra `00171bd` (`{worktree-LD}`, sin cambios locales): resuelven
al contenido que se les atribuye. Huellas de `ficha.md`, `hechos-omitidos.md` y `N3` coinciden. La guarda léxica da 0
en `ficha.md` y en `hechos-omitidos.md`. *n* = 21 y umbral 3 se mantienen (sólo decisiones y trampas).

Cambios (sha256 previo `e2c127f291abe0bdacfe6107dadd031b7b644279f2dd941a37e4fc1865c58a70`):

1. **D-12 (medio).** El índice para agentes pasa de obligatorio a libre. Contradecía a D-02, donde CL-08 es libre, y
   el índice del frontmatter no es una pieza que se versione (SDEI/TEM-04-Doble-Audiencia.md:130-131); la ficha no
   dice nada que lo exija. D-12 sigue firme por los canales del sitio. §9 se ajustó.
2. **D-09 (medio).** El default propuesto deja de ser sólo la copia con huella: también se admite un workflow
   reutilizable definido dentro de la propia organización, que las cuatro apps de la misma organización pueden llamar
   (semilla:README.md:53-54, :96-97). Lo excluido sigue siendo el `uses:` hacia otra organización.
3. **D-17 (medio).** Los 90 días se acotan a los procedimientos escritos (semilla:README.md:70-71), coherente con D-08,
   que deja libre el alcance de «procedimiento escrito». Los excluidos se precisaron en consecuencia.
4. **§9 (bajo).** El motivo de D-02 se corrigió para la lectura (a) de D-01 (sólo falta CL-14), y se agregó una cuenta
   conservadora de 12 firmes. La carga mínima se alcanza igual.

Sin cambios: D-01, D-03 a D-08, D-10, D-11, D-13 a D-16, T3-1 a T3-5, §4, §7, §8.
