# Mesa evaluadora, ciclo 2: informe del especialista en didáctica

- **Rol**: experto en didáctica. Mira el recorrido de aprendizaje, la progresión de lo general a lo particular, las preguntas guía que forman criterio, los ejemplos situados, la carga cognitiva y las actividades que falten.
- **Objeto**: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md`, versión 1.0.0-rc.1 (3391 líneas, 53 363 palabras). También se revisaron, donde la guía los cita, `Examples/N3-…/README.md`, `Examples/N6-…/salidas/e5-procedencia-slsa-firmada.txt` y `Examples/N8-…/salidas/E8-1-choque-de-convenciones.txt`.
- **Fecha**: 2026-10-09. La revisión fue a ciegas: no se leyó ningún informe de otro especialista de este ciclo. Del ciclo 1 se leyeron sólo `Informe-didactica.md`, `01-Consolidado.md` (filas C1-22, 23, 24, 27, 38, 39 y 55) y `05-Aplicacion.md`, para no volver a discutir lo que ya se cerró.
- **Foco del ciclo**: la guía se revisa como obra terminada. Interesan la edición, la compresión y la coherencia global. Lo que ya se cerró (Práctica en §4–§11, *Aplica* en las preguntas, las «dos velocidades» de §3, la frase de §12 sobre el orden de lectura) no se vuelve a discutir. Sólo se marca dónde lo aplicado quedó incompleto o contradice lo que la propia guía promete.
- **Referencia normativa**: el Profile `Study-Guide-Documentation.md` pide un texto «formativo, no enciclopédico» y una guía «interconectada», que es un recorrido y no una colección de fichas. El prompt del PO pide «preguntas guía acompañadas de respuestas explicativas que sean formadoras de criterios».

## Hallazgos

### didactica-01: §11, el capítulo central, tiene una sola consigna de Práctica y ninguna usa E8-1, el experimento de su ruta mínima (S3, E1)

- **Ubicación**: §11.9 (L2374–L2376). Se contrasta con §0.2 (L68 y L81).
- **Ancla**: §0.2 dice: «**Práctica** (dos consignas sobre experimentos que ya existen, con la respuesta esperada)», y en la ruta mínima: «| §11 | E8-1 | Qué se rompe primero en un repo con los tres ecosistemas |». §11.9 tiene una sola consigna, que trabaja sobre las compuertas de N7 y N8. Comprobación: `awk '/^### B/,/^### C/' Examples/N8-integracion-poliglota/salidas/E8-1-choque-de-convenciones.txt | grep -c FALLA` → `5`.
- **Diagnóstico**: es la deuda D-4 del ciclo 1. Allí se revirtió la consigna 1 porque decía «cinco» y enumeraba seis lectores, y no se la reemplazó. El costo didáctico es alto. §11 es el capítulo que la guía llama «central» y el único que enfrenta la tesis «el BOM se decide por extensión y por lector» (§4.6) contra un repositorio real. Sin esa consigna, el lector del Recorrido nunca predice qué rompe el «BOM para todo», que es justamente la generalización a ciegas de la corrección del caso.
- **Dirección**: reponer la consigna con la redacción corregida que ya está en `Ciclo-1/04-Aprobacion-costo-beneficio.md` (fila P-14). La versión sugerida es: «Antes de mirar la columna B de E8-1 ("UTF-8 con BOM para todo"), predecí qué lectores fallan». La respuesta esperada es que fallan cinco: el shebang de `saluda.py`, `json.load`, `tomllib`, `JSON.parse` y la comparación de `.nvmrc`. `hola.sh` da OK, con el error en stderr, y ése es el daño silencioso de §4.2.4. La consigna actual pasa a ser la 2.

### didactica-02: tres respuestas esperadas faltan o están incompletas, contra la promesa de §0.2 (S3, E1)

- **Ubicación**: §6.9 consigna 2 (L1134), §10.9 consigna 2 (L2034) y §9.9 consigna 2 (L1770).
- **Ancla**:
  - §6.9.2: «Escribí el ADR de `rollForward` de tu equipo…». No trae *Respuesta esperada*.
  - §10.9.2: «escribí qué impide y qué no impide la configuración de tu plataforma…». No trae *Respuesta esperada*.
  - §9.9.2: «marcá cuáles de los seis metadatos de §9.6 trae y cuáles faltan. *Respuesta esperada*: trae el digest del artefacto, el commit y la imagen del SDK por digest; faltan la identidad de la plataforma (`builder.id` vacío) y el toolchain efectivo». Así clasifica 1, 2, 4, 6 a medias y 3, y deja sin clasificar el (5), «grafo resuelto, como SBOM», y el «cuándo» del (6). Pero la salida de E6-5 trae `runDetails.metadata: … startedOn=2026-10-07T14:55:54…` y `SBOM de la imagen: https://spdx.dev/Document - 2 paquetes`.
- **Diagnóstico**: una consigna de autoevaluación sin criterio de corrección no le dice al lector si formó el criterio, y §0.2 promete la respuesta en todas. Las dos consignas abiertas («de tu equipo») son buenas actividades de transferencia. Lo que les falta es la vara para evaluarlas. La de §9.9 es más delicada: su respuesta pasa por alto justamente el metadato cuyo alcance la guía enseña a cuestionar (§3.2 y §9.2.3 sobre qué describe un SBOM).
- **Dirección**:
  - §6.9.2 y §10.9.2: en lugar de una respuesta única, agregar un *Criterio de corrección* de dos o tres líneas. Para §6.9.2: el ADR nombra una fila de la tabla de §6.4, dice qué se pierde y quién instala el SDK exacto en ESC-01. Para §10.9.2: cada fila dice «impide / sólo avisa» y nombra el control compensatorio de §10.2.7. Otra opción es reformular §0.2: «con la respuesta esperada o el criterio para evaluarla».
  - §9.9.2: completar la clasificación de los seis metadatos. (6) está a medias: hay `startedOn`, falta quién. (5) está presente como SBOM, y el lector tiene que juzgar si su alcance («2 paquetes») cubre el grafo.

### didactica-03: las «dos velocidades» de §3 quedaron a medias, porque lo que se recomienda leer primero usa conceptos posteriores y la vuelta al mapa no tiene señal (S3, E1)

- **Ubicación**: §0.2 (L65), apertura de §3 (L258), §3.4 (L338), §3.7 pregunta 2 (L418–L419) y pregunta 5 (L427–L428), cierre de §10 (L2031–L2036) y apertura de §11.
- **Ancla**: §0.2 dice: «En §3, las secciones 3.1, 3.2, 3.4 y 3.7 (las tablas de 3.3, 3.5 y 3.6 son de consulta: se vuelve a ellas al terminar §10)». Pero §3.7, que se recomienda leer ya, responde con «CPM fija las directas en un lugar y `packages.lock.json` congela el grafo (E4-2: CPM pidió 8.0.2 … sin lock lo avisa con `NU1603`, y con lock … `requested [8.0.2, )` con `resolved 9.0.0`, §7.2.1)» y con «la política de §6.4». §3.4 usa `ContinuousIntegrationBuild=true` y la ruta del `.pdb`. Conteo en §3.4 y §3.7: `CPM` 2, `packages.lock.json` 1, `NU1603` 1, `requested` 1, `ContinuousIntegrationBuild` 1, `§6.4` 1, `§7.2.1` 1, `§8.2.2` 1. En la vuelta: `grep -n "§3.3\|#33-" Guide.md` sólo encuentra L258 (la apertura de §3). Ni §10 ni §11 le dicen al lector del Recorrido que vuelva al mapa.
- **Diagnóstico**: la decisión C1-24 separó bien las tablas, pero no revisó las secciones que quedaron en la lectura rápida, y dejó la vuelta a cargo de la memoria del lector. La consecuencia es doble. Una de las preguntas guía de §3.7 no se puede contestar con lo leído hasta ahí. Y el momento de recapitulación, que es releer §3.3 «Qué deja libre» con todo ya visto (la mejor actividad de síntesis que tiene la guía), no ocurre.
- **Dirección**:
  - (a) En §3.7, dejar en la pregunta 2 sólo el concepto: fijar elige una versión para una entrada; congelar guarda la resolución completa, con las transitivas. La cifra de E4-2 pasa a §7.6, donde ya está explicada (§7.2.1). En la pregunta 5, cambiar «la política de §6.4» por «(se decide en §6.4)».
  - (b) Al final de §10.9, o como primera línea de §11, agregar una señal con consigna: «**Volver al mapa.** Releé §3.3 empezando por la columna "Qué deja libre" y §3.5. Para cada fila, nombrá el experimento que lo mostró. Si alguna fila no la podés justificar, volvé al capítulo que indica».

### didactica-04: §12, el capítulo que integra todo, es el único sin actividad, y el lector nunca recorre la hoja de ruta de punta a punta (S3, E1)

- **Ubicación**: §12 (L2380–L2420) y la tabla de la ruta mínima de §0.2 (L72–L81).
- **Ancla**: §12 no tiene subsecciones ni consigna (`grep -n "^### 12" Guide.md` → nada). La ruta mínima termina en §11. El contrato YAML de §12 ya enumera cinco validaciones con su mensaje esperado. Por ejemplo: «paso 5: un SDK distinto del de global.json -> A compatible .NET SDK was not found», y «paso 6: manifiesto cambiado sin regenerar el lock -> NU1004 / EUSAGE / needs to be updated».
- **Diagnóstico**: el Profile pide que el lector termine «con criterio para intervenir», no sólo para reconocer términos. La hoja de ruta es la síntesis del recorrido, pero se lee como una tabla. No hay ningún momento en el que el lector ordene los pasos, justifique una dependencia entre capas o asocie cada validación con lo que ya vio fallar. Las piezas existen. Cada validación del YAML corresponde a un experimento versionado.
- **Dirección**: agregar un cierre breve, «Práctica integradora», sin experimentos nuevos.
  - (1) Para cada validación del contrato, nombrar el experimento que la mostró y predecir el mensaje: paso 3 → E2-2; paso 4 → E2-3; paso 5 → E3-1; paso 6 → E4-1 y E4-4; paso 7 → E7-4. Se compara con las salidas.
  - (2) Una consigna situada sobre el orden: «el equipo quiere empezar por el devcontainer (paso 7) antes de fijar el toolchain (paso 5): ¿qué deja sin detectar?». La respuesta esperada es que con una imagen por etiqueta y sin `global.json` el SDK cambia sin que el repo se entere (E5-6, §3.5), y que la capa 1 sigue rota adentro (E5-1).
  - Agregar también una fila «§12» en la ruta mínima de §0.2 que remita a esa práctica.

### didactica-05: los párrafos de «Cómo funciona» acumulan varias reglas por bloque, y la guía creció un 22 % (S3, E1)

- **Ubicación**: 15 párrafos de prosa de 150 palabras o más, sin contar tablas ni código: L59 (160), L456 (152), L492 (171), L990 (194), L992 (166), L998 (179), L1181 (214), L1193 (153), L1366 (162), L1646 (200), L1648 (167), L2093 (155), L2132 (202), L2173 (188) y L2183 (209).
- **Ancla**: el recuento sale de un script que recorre la guía, salta los bloques de código y las filas de tabla y cuenta las palabras por línea (`>=150` → 15). En la L1181 (§7.2.1) entran en un solo párrafo la activación del lock, la reescritura sin modo estricto (E4-1), `NU1004`, `NU1403`, «tres reglas del fabricante» en línea, la poda de paquetes del SDK 10 y el RID como parte del lock. Tamaño: el ciclo 1 midió 43 605 palabras y la guía tiene hoy 53 363.
- **Diagnóstico**: la evidencia está bien y no hay que recortarla, porque la guía exige que las citas entren explicadas. Lo que falla es la dosificación. Cuando un párrafo lleva cinco o más reglas con sus versiones y sus errores, el lector del Recorrido no distingue la regla que tiene que llevarse del dato de versión que lo respalda. En L1181, la regla del RID, que tiene consecuencia práctica en un equipo Windows+Linux, queda en la séptima oración. Las ampliaciones del ciclo 1 se insertaron casi todas como oraciones dentro de párrafos que ya existían, y por eso la densidad creció más que la longitud.
- **Dirección**: reorganizar sin recortar.
  - (a) Una regla por párrafo, con la regla en negrita al principio y la evidencia después, que es el patrón que ya usa §7.2.1 en «**CPM y lock no son alternativas**».
  - (b) Las enumeraciones en línea pasan a lista. Ejemplo: «Tres reglas del fabricante» en L1181 se convierte en una lista de tres viñetas, y el RID va en su propio párrafo.
  - (c) La historia de versiones y defectos (§4.2.1, la regresión de abril de 2026; §4.2.3, el estado del `VBCSCompiler`; §9.2.4, los planes) va en un bloque citado «Detalle de versión», debajo de la regla, para que el lector del Recorrido pueda saltearlo. La marca **[observado]** se mantiene.
  - Empezar por los cinco párrafos de 200 palabras o más: L1181, L1646, L2132, L2183 y L990.

### didactica-06: «Señales de una versión pobre» son enumeraciones de hasta 14 ítems en una sola oración, justo debajo de criterios presentados en viñetas (S4, E1)

- **Ubicación**: §10.7 (L2025), §11.7 (L2368), §9.7 (L1761), §7.7 (L1296), §5.7 (L923), §6.7 (L1125) y §8.7 (L1526).
- **Ancla**: el recuento cuenta las palabras e ítems separados por «;» de cada línea que empieza con `Señales de una versión pobre`. §10.7: 132 palabras y 14 ítems. §11.7: 93 y 12. §9.7: 83 y 11. §7.7: 97 y 11. §4.7, en cambio, tiene 31 palabras y 4 ítems.
- **Diagnóstico**: el contraste entre la versión buena y la pobre es uno de los mejores recursos de la guía (lo valoró el ciclo 1). Pero en §7 a §11 la lista de señales se volvió una oración de un párrafo que no se puede recorrer como lista de control. Además, ninguna señal remite al criterio que viola, y por eso el lector no entrena el paso de síntoma a criterio.
- **Dirección**: pasar las señales a viñetas, con el mismo formato que «Criterios de calidad». Si pasan de ocho, agruparlas por actor (lo que ve el revisor, lo que ve OPS) o por capa. Para el lector que ya conoce el criterio, alcanza con que cada viñeta termine con la sección que la explica, por ejemplo «(§10.2.7)».

### didactica-07: §0.2 dice que la Práctica se hace «sobre la ruta mínima», pero en §10 y §11 no es así, y una respuesta remite a una sección que no existe con ese nombre (S4, E1)

- **Ubicación**: §0.2 (L65 y L80–L81), §10.9 (L2033) y §6.9 consigna 1 (L1133).
- **Ancla**: §0.2 dice: «Al cierre de cada capítulo, su **Práctica**, sobre la ruta mínima de abajo». La ruta de §10 es E7-1 («El hook se saltea; la CI no») y §10.9 trabaja con E7-4 y con la tabla de §10.2.7. La ruta de §11 es E8-1 y §11.9 trabaja con las compuertas de N7 y N8. §6.9.1 dice: «*Respuesta esperada*: la de `Examples/N3-fijacion-del-toolchain/README.md`, sección E3-1». Pero `grep -n "E3-1" Examples/N3-fijacion-del-toolchain/README.md` → nada, y la sección se titula «## 01 — `global.json` y `rollForward`».
- **Diagnóstico**: son desajustes menores, pero rompen el contrato de lectura que §0.2 presenta como recurso didáctico. El lector que corrió E7-1 no lo vuelve a usar, y el que busca «E3-1» en el README no lo encuentra.
- **Dirección**: §11 se resuelve con didactica-01. En §10.9, o una consigna toma E7-1 (por ejemplo, «predecí qué pasa con `git commit --no-verify` y qué hace la CI con el mismo commit»), o §0.2 dice «sobre la ruta mínima o un experimento vecino». En §6.9.1, cambiar a «sección "01 — `global.json` y `rollForward`" (E3-1)», o agregar el ID al título del README.

## Revisado y bien

1. **Las preguntas guía cierran C1-22.** En §3.7–§11.6 hay 67 preguntas: 64 terminan con *Aplica* / *No aplica* y cada capítulo tiene exactamente una pregunta situada que pide una decisión. Ejemplos: §7.6, «Llega un PR que cambia `packages.lock.json` sin tocar `Directory.Packages.props`… ¿Qué mirás y qué decidís?», y §9.6, «Un cliente pide "procedencia SLSA L2"… ¿Qué le contestás?». Además, el formato quedó uniforme: la pregunta en negrita en su propia línea y la respuesta debajo.
2. **«Predecí antes de correr» como forma de práctica.** §4.9.1, §5.9.1, §6.9.1 y §8.9.2 piden una predicción y la contrastan con una salida versionada. Es práctica de recuperación con retroalimentación inmediata, construida sobre experimentos que ya existen y sin agregar carga al laboratorio.
3. **La ruta mínima de §0.2.** Asigna un experimento por capítulo y una columna «Qué tiene que quedar claro» redactada como idea central, no como nombre de herramienta. Con eso, el lector del Recorrido pasa de 73 experimentos a 8, y cada uno queda ligado a la tesis del capítulo.

## Solicitudes de convocatoria

- **Desarrollador o lector sin contexto**: el bloque de salida de §1.2 (L142) muestra `$ docker run --rm -v "$PWD":/w -w /w mcr.microsoft.com/dotnet/sdk:8.0 sh e1-roslyn.sh`, que es un comando distinto del que la guía le pide correr dos líneas antes (L138, con `-u "$(id -u):$(id -g)" -e HOME=/tmp`). Que alguien con ese mandato juzgue si eso confunde al lector o si corresponde aclarar que la salida se registró con la invocación anterior.
