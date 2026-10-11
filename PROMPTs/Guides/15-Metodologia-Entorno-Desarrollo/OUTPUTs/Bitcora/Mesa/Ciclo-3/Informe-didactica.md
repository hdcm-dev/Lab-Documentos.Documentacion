# Mesa evaluadora, ciclo 3: informe del especialista en didáctica

- **Rol**: experto en didáctica. Mira el recorrido de aprendizaje, la progresión de lo general a lo particular, las preguntas guía que forman criterio, los ejemplos situados, la carga cognitiva y las actividades que faltan.
- **Objeto**: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md`, versión 1.0.0 (3605 líneas, 54 267 palabras según `wc -w`). Donde la guía los cita, también se revisaron `Examples/A-plantillas/salidas/EA-1-plantillas.txt`, `Examples/N7-…/salidas/E7-04-descongelamiento-controlado.txt` y `Examples/N0-…/salidas/E0-6-capa6-procedencia.txt`.
- **Fecha**: 2026-10-09. La revisión fue a ciegas: no se leyó ningún informe de otro especialista de este ciclo. Del ciclo 2 se leyeron `Informe-didactica.md`, `01-Consolidado.md` y `05-Aplicacion.md`, para no volver a discutir lo que ya se cerró: C2-32, C2-33, C2-36/37, C2-38, C2-50, C2-51 y la cuenta de 63 *Aplica* aceptada.
- **Foco del ciclo**: la guía se revisa como obra terminada, con atención a la edición, la compresión y la coherencia global. Sólo se marcan los lugares donde lo aplicado quedó incompleto o donde el recorrido enseña algo que la propia guía después contradice.

## Hallazgos

### didactica-01: la Práctica integradora de §12 pide «cada validación», pero la respuesta esperada cubre 5 de 11 (S3, E1)

- **Ubicación**: §12, «Práctica integradora», consigna 1 (L2515). Se contrasta con el contrato YAML de §12 (bloque `validaciones`, 11 entradas).
- **Ancla**: la consigna dice «Para cada validación del contrato, nombrá el experimento que la mostró y predecí el mensaje». La respuesta esperada es: «paso 3, E2-2 (`0 con cambio de contenido`); 4, E2-3 (`¿cp1252?`); 5, E3-1 (…); 6, E4-1 y E4-4 (…); 7, E7-4 (rojo en la imagen vieja)». El YAML trae los pasos 1, 2, 3, 4, 5, 6, 7, 8a, 8b, 9 y 10. Comprobación: `grep -ril codeowners --include=*.txt Examples/` no devuelve nada, así que el paso 9 no tiene experimento. En cambio, `EA-1-plantillas.txt` sí trae el paso 1 de resolución por extensión y el paso 9 del registro del entorno (`commit=… arbol_limpio=si … dotnet_sdk=8.0.425 …`).
- **Diagnóstico**: es la única actividad de síntesis de toda la guía y la que cierra el recorrido. El lector que la hace en serio llega a la validación 8a, 8b, 9 o 10 sin saber si su respuesta es correcta. Además, tres de esas seis validaciones no tienen experimento, y eso es justamente lo que conviene aprender: qué parte de la hoja de ruta no se puede verificar en el laboratorio. La consigna en su forma actual lo oculta.
- **Dirección** (completar, sin experimentos nuevos):
  - paso 1 → E1-09 (`e1-diagnostico.sh`);
  - paso 2 → EA-1, paso 1;
  - paso 8a → EA-1, paso 9 (A.17);
  - paso 8b → no hay experimento con firma de plataforma: E6-5 muestra una procedencia sin firma de plataforma y con `builder.id` vacío (**[no verificado]**, requiere la plataforma);
  - paso 9 → sin experimento (requiere la plataforma);
  - paso 10 → E8-1, columna A.

  Si se prefiere no agregar texto, la alternativa es acotar la consigna a «las validaciones de los pasos 3 a 7».

### didactica-02: §8.2.2 enseña su criterio con «8a», «8b» y «frontera A», que se definen en §11 y §12, y la pregunta guía de §8.6 da la regla sin la excepción (S3, E1)

- **Ubicación**: §8.2.2, política recomendada, punto 1 (L1414); §8.6, «¿Etiqueta o digest?» (L1538); §8.7, criterio 1.
- **Ancla**:
  - L1414: «Para 8a también vale el runner alojado con acciones de *setup* por SHA […] La imagen propia hace falta para 8b, la reconstrucción bit a bit o la frontera A en la CI (§11.2.5)».
  - `grep -n "\b8[ab]\b"` limitado a las líneas anteriores a §12 da L1414, L1686, L1721, L1793 y L2331. La primera aparición es L1414, y «8a» no se explica en ninguna de ellas. «Frontera A» se define recién en §11.2.5.
  - §8.6 responde: «Digest en todo lo que construye artefactos publicados, con un bot que proponga el digest nuevo». No dice cuándo alcanza el runner alojado.
- **Diagnóstico**: el lector del Recorrido llega a §8 sin saber qué son 8a, 8b ni la frontera A. La excepción del runner queda escrita en un código que todavía no puede leer. La pregunta guía, que es lo que se lleva como criterio, enuncia la regla sin excepción, y §12 (paso 7) la relaja. El resultado es un criterio que la propia guía contradice cuatro capítulos después. El ciclo 2 dejó abierta esta incoherencia (`05-Aplicacion.md` §6.1). Este hallazgo se limita a su efecto didáctico; la decisión de fondo le corresponde al arquitecto (ver Solicitudes).
- **Dirección**:
  - En L1414, reemplazar los rótulos por su contenido: «para registrar con qué se construyó (registro del entorno sin firma, §9) alcanza el runner alojado […]; la imagen propia por digest hace falta cuando un tercero verifica la procedencia, cuando se exige reconstrucción bit a bit o cuando MSBuild llama a npm y uv en la CI (frontera A, §11.2.5)».
  - En §8.6, agregar a la respuesta un *No aplica*: «a la CI que sólo registra el entorno: ahí basta el runner alojado con acciones por SHA (§8.2.2)».
  - Alinear el criterio 1 de §8.7 con esa misma redacción.

### didactica-03: la consigna «Volver al mapa» pide un dato que está a la vista en la misma fila, y tres filas no tienen experimento (S4, E1)

- **Ubicación**: cierre de §10.9 (L2109); tabla de §3.3 (L322–L340); §0.2 (L65).
- **Ancla**:
  - L2109: «Releé §3.3 desde "Qué deja libre", y §3.5: para cada fila, nombrá el experimento que lo mostró; si no podés, volvé a su capítulo».
  - La tabla de §3.3 tiene una columna «Evidencia» que ya nombra el experimento. Tres filas no tienen ninguno: `PackageReference Version` ([B83][B84]), `requires-python` ([B71][B73]) y `SOURCE_DATE_EPOCH` ([B03]).
  - §0.2 manda volver a «3.3, 3.5 y 3.6»; la consigna cubre 3.3 y 3.5.
- **Diagnóstico**: la consigna debía ser el momento de recuperación del recorrido (C2-38 b). Tal como quedó, se resuelve copiando la columna de al lado, y en tres filas manda al lector a buscar un experimento que no existe. Se pierde el efecto de recuperar de memoria, y no hay respuesta ni criterio de corrección.
- **Dirección**: pedir que se reconstruya lo que la tabla no muestra a la vista. Por ejemplo: «Tapá las columnas "Qué deja libre" y "Evidencia" de §3.3. Para cada mecanismo, escribí qué deja libre y qué lo mostró (un experimento, o una fuente si no hubo experimento), y compará. Hacé lo mismo con la columna "Matiz" de §3.5». *Criterio de corrección*: lo escrito coincide con la tabla, y las filas sin experimento se reconocen como respaldadas sólo por una fuente. Ajustar §0.2 a «3.3 y 3.5», o sumar 3.6 a la consigna.

### didactica-04: §3, el modelo de capas que ordena toda la guía, es el único capítulo conceptual sin actividad, aunque §0.4 hace correr N0 primero (S4, E1)

- **Ubicación**: §0.2, ruta mínima (L72–L82, empieza en §4); §0.4 (L106); §3.7.
- **Ancla**:
  - §0.4 abre el laboratorio con `( cd Examples/N0-modelo-de-capas-y-reproducibilidad && bash correr-todo.sh )` y dice «Sólo N0 tiene tiempo medido». Sin embargo, la ruta mínima no tiene fila para §3, y ninguna Práctica usa una salida de N0.
  - §3 cita 18 apariciones de `E0-` (`awk 'NR>=262&&NR<439' | grep -c E0-` → 18).
  - `E0-6-capa6-procedencia.txt` termina con un `diff` de dos manifiestos de capas que difieren en `capa2_toolchain` (`"dotnet_sdk": "ERROR: 'dotnet --version' falló (código 155)"`) y en `capa4_so_imagen`.
- **Diagnóstico**: el lector corre N0 como primer contacto con el laboratorio y no hace nada con lo que obtiene. La herramienta de diagnóstico que §3.7 enseña («buscar la primera capa, de abajo hacia arriba, donde difieren») no se practica nunca, aunque la salida está lista para eso. Es la actividad más general de la guía y la que, en una progresión de lo general a lo particular, correspondería hacer primero.
- **Dirección**:
  - Agregar en §3 una Práctica breve, sin experimento nuevo: «Antes de mirar el diff de E0-6, predecí cuál es la primera capa, de abajo hacia arriba, en la que difieren los manifiestos de `sdk:8.0` y `sdk:10.0`, y por qué». *Respuesta esperada*: la capa 2. `global.json` pide 8.0.425 y la imagen 10.0 no lo tiene (`dotnet --version` falla con código 155). La capa 4 también difiere (Debian 12 frente a Ubuntu 24.04). Las capas 1 y 3 coinciden, porque el commit y los locks son los mismos.
  - Sumar a la ruta mínima una fila «§3 | E0-6 | La primera capa que difiere explica el "en mi máquina anda"».

### didactica-05: el capítulo central concentra la prosa más densa de la guía (S4, E1)

- **Ubicación**: §11.2.5, el párrafo de `.esproj` (L2207); §11.2.7 (L2248); §11.2.8, el párrafo «La lección es de alcance» (L2258).
- **Ancla**:
  - Un script que salta bloques de código, filas de tabla y encabezados encuentra 7 párrafos de 150 palabras o más. El ciclo 2 había contado 15. Tres de los siete están en §11: L2207 (181 palabras), L2248 (169) y L2258 (196).
  - Prosa por capítulo, sin tablas ni código: §11 tiene 3840 palabras; le sigue §5 con 2900.
  - L2258 mete en un solo párrafo los tres alcances de SBOM, el criterio de cuáles hacen falta, la procedencia de BuildKit sin firma, el predicado de `actions/attest` y el esquema (a)+(b)+(c).
- **Diagnóstico**: la reorganización del ciclo 2 bajó a la mitad los párrafos sobrecargados, pero dejó los del capítulo que la guía llama «central». En L2258, la regla que el lector tiene que llevarse («para contestar con qué entorno se ensambló hacen falta tres partes») queda en la quinta oración.
- **Dirección**: aplicar a esos tres párrafos el patrón ya adoptado, una regla por párrafo con la regla en negrita al principio.
  - L2258: dividirlo en «alcance» y «las tres partes», y pasar (a), (b) y (c) a una lista.
  - L2207: separar el comportamiento medido de la advertencia sobre `RunNpmInstall`.
  - L2248: separar la imagen única o la matriz por versión de la matriz por sistema operativo.
  - Saldo de palabras neutro, compatible con C2-36.

## Revisado y bien

1. **Las respuestas esperadas de la Práctica coinciden con las salidas versionadas.**
   - §11.9.2 anuncia `no es UTF-8 válido (byte 0xc7 …; ¿cp1252?)` y sólo el paso de texto en rojo. `EA-1-plantillas.txt` trae `src/App/Alarma.cs: no es UTF-8 válido (byte 0xc7 en offset 22; ¿cp1252?)` y `resultado=ROJO (1 paso/s)`.
   - §12, paso 7, anuncia «rojo en la imagen vieja». `E7-04-…txt` B1 da `[FALLA] toolchain .NET: global.json pide 10.0.400` y `ROJO (2 paso/s)`.
   - §8.9.1 coincide con lo que §8.2.2 cita de E5-2.
2. **El caso funciona como hilo conductor.** Cada apertura de §6 a §10 vuelve a la pregunta del caso en sus propias palabras («El caso pide congelar "versiones de compiladores, sdk"…», «El caso pregunta si congelar […] "se puede hacer mediante contenedores"», «la pregunta que el caso marca como la más importante», «El caso pide además "una mecánica"»). Con eso, cada capítulo responde a algo que el lector ya trae, y se cumple la promesa de §1.4.
3. **Lo cerrado en el ciclo 2 está aplicado y bien resuelto.**
   - §11.9 tiene dos consignas, y la primera usa la columna B de E8-1 con la respuesta corregida (cinco lectores fallan, `hola.sh` da OK con error en stderr).
   - §6.9.2 y §10.9.2 traen *Criterio de corrección*.
   - La pregunta 2 de §3.7 quedó sólo con el concepto.
   - Las «Señales de una versión pobre» están en viñetas con su remisión, y en §10.7 se agrupan por quién las ve. Así funcionan como lista de control y entrenan el paso del síntoma al criterio.

## Solicitudes de convocatoria

- **Arquitecto de software / coherencia**: la decisión de fondo sobre digest o runner alojado, que el ciclo 2 dejó abierta (`05-Aplicacion.md` §6.1). Comprende la regla de §8.2.2 punto 5 («nunca en la CI que publica artefactos»), §8.4, §10.2.5, B.3 y B.4, y el paso 8a de §12, que pide el digest en el registro. didactica-02 trata sólo cómo se enseña; no decide la regla.
- **Edición bibliográfica / verificación de evidencia**: la apertura dice «73 experimentos ejecutables (Anexo E)». El control de cambios de 1.0.0-borrador dice «71 experimentos», y la aplicación del ciclo 2 contó «71 IDs en el cuerpo». Hay que unificar la cifra y decir qué se cuenta: las variantes `b` y `a/b/c`, y `V7-01`.
