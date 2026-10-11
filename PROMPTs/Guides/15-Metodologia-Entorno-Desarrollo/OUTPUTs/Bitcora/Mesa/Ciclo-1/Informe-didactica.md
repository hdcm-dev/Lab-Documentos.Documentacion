# Mesa evaluadora — Ciclo 1 — Informe del especialista en didáctica

- **Rol**: experto en didáctica (recorrido de aprendizaje, progresión general → particular, preguntas guía formadoras de criterio, ejemplos situados, carga cognitiva, actividades que falten).
- **Objeto**: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (3060 líneas, 43 605 palabras) y `Examples/README.md`.
- **Fecha**: 2026-10-07. Revisión a ciegas: no se leyeron informes de otros especialistas del ciclo.
- **Referencia normativa**: Profile `Study-Guide-Documentation.md` («recorrido de aprendizaje y no colección de fichas»; «lector sin conocimiento previo»; «formativo, no enciclopédico») y la regla del prompt del PO: «preguntas guía acompañadas de respuestas explicativas que sean formadoras de criterios y que permitan al lector identificar en qué caso se aplica cada concepto».

## Hallazgos

### didactica-01 — No hay ninguna actividad para el lector; el laboratorio sólo funciona como evidencia (S2, E1)

- **Ubicación**: toda la guía; §0.2 (línea 67), §0.4 (líneas 85–94), cierre de cada capítulo 4–11, Anexo E.
- **Ancla**: `grep -ci "ejercicio\|actividad\|autoevalu" Metodologia-Entorno-Desarrollo-Guide.md` → `0`. §0.2: «§1 → §12 en orden; correr los experimentos que cada capítulo cita» (71 experimentos, sin priorizar ni estimar tiempo salvo N0 «~1 minuto»).
- **Diagnóstico**: el lector del «Recorrido» recibe la indicación de correr todo, pero nunca una consigna: no se le pide predecir un resultado antes de verlo, ni diagnosticar, ni decidir. Los experimentos ya existen y son excelentes materiales de práctica; hoy sólo respaldan afirmaciones. Una guía de estudio sin actividades deja la formación de criterio librada a la lectura.
- **Dirección**: agregar al final de §4–§11 una subsección breve **«Práctica»** (2 consignas, con respuesta plegable o al pie), construida sobre experimentos existentes, sin experimentos nuevos. Ejemplos: §4 «antes de correr E1-01, predecí cuál de las tres variantes compila y qué imprime el literal»; §5 «corré `e1-diagnostico.sh` sobre `work/` y armá la tabla de violaciones»; §7 «leé el diff de E4-2 y decí qué comando lo habría detectado»; §10 «revisá el PR de E7-4 con la lista B.4: ¿aprobás?»; §11 «con BOM global, ¿cuántos lectores fallan y cuáles? Verificalo con E8-1». En §0.2 o Anexo E, una **ruta mínima** (un experimento por capítulo, con tiempo aproximado) para el Recorrido.

### didactica-02 — Las preguntas guía no siempre dicen «en qué caso aplica»; predominan las de recuerdo (S2, E1)

- **Ubicación**: §3.7, §4.6, §6.6, §7.6, §8.6, §9.6 (líneas 1562–1574), §10.6 (líneas 1802–1816).
- **Ancla** (conteo de preguntas vs. líneas con `*Aplica*`/`*No aplica*` por capítulo): §3 5/2 · §4 6/2 · §5 7/5 · §6 8/2 · §7 6/2 · §8 7/2 · §9 6/1 · §10 7/1 · §11 7/3. Ejemplos sin anclaje de aplicación: §9.6 «¿SBOM o procedencia? Los dos: …»; §10.6 «¿Alcanza con un hook? No: no viaja con el clon…».
- **Diagnóstico**: la regla del PO pide que cada pregunta permita identificar **en qué caso** se aplica el concepto. La guía declara el patrón (*Aplica* / *No aplica*) y lo cumple bien en §5, pero se diluye a medida que avanza: en §9 y §10 una de seis o siete. Además, casi todas las preguntas son del tipo «¿qué es / qué hace X?», que se contestan releyendo el capítulo; faltan preguntas **situadas** con una decisión («llega un PR que cambia `packages.lock.json` sin tocar `Directory.Packages.props` y la compuerta está en verde: ¿qué mirás y qué decidís?»).
- **Dirección**: completar *Aplica* / *No aplica* en todas las respuestas (una línea basta, referida a ESC/CTX/actor) y convertir al menos una pregunta por capítulo en un caso situado con decisión, preferentemente sobre el hilo del caso de §1.

### didactica-03 — §3 sobrecarga el primer tramo del recorrido con material de consulta que usa conceptos de capítulos posteriores (S2, E2)

- **Ubicación**: §3.3 (líneas 285–307), §3.5 (322–333), §3.6 (335–373); §3 completo suma 3 261 palabras.
- **Ancla**: la tabla de §3.3 tiene 16 filas y usa, antes de que se expliquen, `--locked-mode`, `devEngines`, CPM, `devcontainer-lock.json`, `ContinuousIntegrationBuild`, `SourceRoot`, `SOURCE_DATE_EPOCH` y remite a E3-1, E4-1, E4-2, E5-2, E5-5, E0-5b. A eso se suman 15 definiciones (§3.1), seis capas (§3.2), una tabla de 6 filas sobre contenedores (§3.5) y tres mapas de entrada (§3.6).
- **Diagnóstico**: el ordenamiento general → particular es correcto (mapa → capas → integración) y el Profile pide el mapa al principio. El problema es de **dosificación**: un lector del Recorrido llega a §4 habiendo recibido ~30 nombres de mecanismos que todavía no puede anclar; el mapa sirve al lector de Consulta, no al que aprende.
- **Dirección**: sin mover contenido, señalizar dos velocidades. En §0.2 y al abrir §3.3/§3.5/§3.6: «En el Recorrido, leé §3.1, §3.2, §3.4 y §3.7; las tablas §3.3, §3.5 y §3.6 son de consulta: volvé a ellas al terminar §10». Alternativa más fuerte: reubicar §3.3 como recapitulación al cierre de §10 o en §12, dejando en §3 sólo su primera y última fila como anticipo.

### didactica-04 — Los identificadores ESC/CTX/ACT aparecen solos en la prosa y obligan a volver a §2 (S3, E1)

- **Ubicación**: 62 apariciones de `ESC-0n`; por ejemplo §7.6, línea 1137.
- **Ancla**: «*Aplica* siempre que ESC-01 conviva con ESC-02/04/05: generar el lock de forma independiente de la máquina…».
- **Diagnóstico**: los IDs son útiles para el lector agente (Rule-Dual-Audience) y para las tablas, pero en la prosa son 13 códigos opacos que el lector humano tiene que retener; la frase de la línea 1137 es ininteligible sin volver a §2.1.
- **Dirección**: en el texto corrido, acompañar cada ID con su nombre corto la primera vez en cada sección («ESC-01 Windows + VS conviva con Linux, devcontainer o CI (ESC-02/04/05)»); en tablas pueden quedar solos.

### didactica-05 — §12 contradice la indicación de lectura de §0.2 y §3.2 (S3, E1)

- **Ubicación**: §12, línea 2168; §0.2, línea 67; §3.2, línea 258.
- **Ancla**: §12: «Los capítulos anteriores se pueden leer en cualquier orden; adoptarlos, no.» frente a §0.2: «**Recorrido** | §1 → §12 en orden» y §3.2: «cada capa consume a la anterior, y la falla de una capa inferior no se arregla en una superior».
- **Diagnóstico**: el lector recibe dos instrucciones opuestas sobre el orden; la de §12 es la que queda al final.
- **Dirección**: «Los capítulos anteriores se pueden **consultar** en cualquier orden; para aprenderlos conviene el orden de §0.2, y para adoptarlos, el de esta tabla».

### didactica-06 — El primer bloque práctico de la guía falla si se copia tal cual (S3, E1)

- **Ubicación**: §0.4, líneas 89–92.
- **Ancla**: los dos `cd` son relativos a la carpeta de la guía; corridos en secuencia en el mismo shell, el segundo falla. Comprobado: `cd Examples/N0-modelo-de-capas-y-reproducibilidad && test -d Examples/A-plantillas` → `Examples/A-plantillas: no existe desde N0-modelo-de-capas-y-reproducibilidad`.
- **Diagnóstico**: es la primera acción que la guía le pide al lector; un fallo ahí cuesta confianza en todo el laboratorio.
- **Dirección**: usar subshells, `(cd Examples/N0-… && ./correr-todo.sh)`, o aclarar «desde la carpeta de la guía, cada línea por separado».

### didactica-07 — La forma de las preguntas guía y de los IDs de experimento no es uniforme, aunque §0.2 promete «una sola forma de leer» (S4, E1)

- **Ubicación**: §3.7/§4.6 (pregunta en negrita y respuesta en línea aparte), §5.6/§9.6/§10.6 (pregunta y respuesta en el mismo párrafo), §7.6/§11.6 (numeradas); IDs de experimento: `E1-01` (dos dígitos) frente a `E2-1`, `E4-2` (uno), y `Examples/README.md`: «E1-01 … E1-13 (en los scripts, `E1-N1-01` …)», «E7-5b (… en los archivos, `V7-01`)».
- **Diagnóstico**: son variaciones menores, pero la guía hace de la uniformidad un recurso didáctico explícito (§0.2), y el lector que va de la guía al script tiene que traducir identificadores.
- **Dirección**: un solo formato de pregunta guía en todos los capítulos (sugerido: pregunta en negrita en línea propia, respuesta, línea *Aplica*); unificar los IDs de experimento a un dígito o a dos en la guía y anotar la equivalencia en cada `README` de carpeta.

## Revisado y bien

1. **El hilo del caso como organizador**: §1.4 anuncia dónde se explica, resuelve, previene y generaliza el caso (§4, §5, §10, §11), y §12 cierra asignando los pasos a las tres preguntas originales. El ejemplo situado no se abandona después de la introducción.
2. **La estructura uniforme de los capítulos 4–11** con «Criterios de calidad» y «Señales de una versión pobre»: contrastar la versión buena con la pobre forma criterio de evaluación, no sólo de reconocimiento (p. ej. §4.7, §5.7).
3. **Las entradas por síntoma de §3.6**: parten de lo que el lector ve (`CS1056`, `bash\r`, `NU1004`) y no del nombre del concepto; es la puerta correcta para quien llega con el problema.

## Solicitudes de convocatoria

Ninguna.
