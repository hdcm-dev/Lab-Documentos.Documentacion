# Rondas editoriales del libro (reedición 04)

Archivo: `Concepts/Framework-Concept/MAUI-Framework-Developer-Guide.md` (rama `fc/libro-guia-desarrolladores`, sin commitear).

## Edición académica (2026-11-01)

Alcance: rigor, fuentes y consistencia. Se editó el archivo en el lugar.

### Método

1. **Citas `archivo:línea`**: un script extrajo las 349 citas con número de línea y comprobó que el archivo exista en el repo y que el rango no pase del largo del archivo. Resultado: todas existen y todos los rangos están dentro (las 8 del workflow, con prefijo `../../.github/`, se comprobaron a mano: 205 y 97 líneas).
2. **Bloques de código con cabecera `// archivo:a-b`**: se comparó cada línea del bloque con el rango citado (14 bloques). 11 coincidían; 3 no (ver cambios 3 a 5).
3. **Citas textuales «…» seguidas de `[archivo:línea]`**: se buscó el texto en el rango citado. Sólo dos falsos positivos (una nota interpolada de `Actualizador.cs:103`, con valores concretos en lugar de `{…}`, y una frase del propio libro).
4. **Cifras**: se buscaron todas las cifras con unidad (s, ms, MB, min, pruebas) y se contrastaron con su fuente (README de la demo, folios 049, 052 y 053, E01 y E04, `ParametrosDeProducto.cs`, `TransicionesDeRed.cs`, `SincronizadorDelOutbox.cs`, `Oidc.cs`, `contrato.json`).
5. **Referencias**: cruce entre las citas `[Rn]` del texto y las entradas del Anexo B; comprobación de que cada URL de R16 en adelante responda (curl, 51 URL).
6. **Números de sección**: cada `§n.n` y cada número de sección en las columnas «Dónde/Sección» de los anexos se cruzó con los encabezados reales.

### Cambios

1. **Tabla 3.4 → Tabla H.3** (pendiente 4 de la unión). La regla del libro dice que los datos fechados viven sólo en el Anexo H (Prólogo; §11.1). La tabla de TPR de §3.8 se movió al Anexo H como H.3; §3.8 remite a ella. No hay otras referencias a «Tabla 3.4».
2. **Cifras de TPR corregidas contra los folios:**
   - V1 (E04) se citaba con el folio 053; las corridas de V1 están en el **folio 052** (régimen 4 777–5 199 ms; primera corrida 9 648 ms).
   - V1S sólo traía el primer arranque; se sumó su régimen: **4,9–5,6 s** (folio 053:15-16; E04 `INFORME.md`, «El régimen queda como V1»).
   - Se definieron en la tabla «régimen», «primera corrida» y «recién instalado», porque el 9,2 s de `main` (folio 049, R1 de la serie) y el 7,9–8,8 s de V1S (instalación limpia) no miden lo mismo.
   - Fuente de «~8,2 s» ampliada a `Demo/README.md:246-248`.
   - El Anexo E apunta ahora a H.3 en las marcas HISTÓRICO y VARIANTE NO FUSIONADA, y esta última cita los folios 052 y 053.
3. **`App.cs`**: la cabecera decía `:25-33`; el código está en 26-34. Se corrigió y se aclara que se omitieron los comentarios de línea.
4. **`VerificacionDelIndice.cs:18-22`**: el libro transcribía `//`; el original usa `///`. Se corrigió a la letra.
5. **`SinTokensEnElPuenteTests.cs`**: la cabecera decía `:17-18`; el fragmento está en 16-17.
6. **Rollback en el cuarto arranque** (pendiente 3): se resolvió a favor de la Tabla 3.2 tal como está. El código (`Actualizador.cs:97-110`, condición `CargasSinListo >= 2`) y el README (`Demo/README.md:89`, «en el cuarto arranque vuelve a 1.1.0») coinciden: arranque 1 baja a staging, 2 activa y carga (1), 3 reintenta y carga (2), 4 hace el rollback. La recomendación H1 del núcleo N2 cuenta desde la activación («arranque 1 activa») porque supone el staging ya hecho; con el paso 7 de la demo, que publica y luego abre en frío, el staging ocurre en el primer arranque. No hay contradicción; no hubo cambio de texto.
7. **Números de sección del Anexo D** (pendiente 5): los 23 números citados existen como encabezados y sus títulos corresponden a los archivos listados. Los 20 archivos o carpetas del anexo existen. Sin cambios.
8. **Anexo E fusionado** (pendiente 2): se quitaron las filas genéricas de 9.3, 9.4 y 9.5, que repetían las detalladas, y se unieron los duplicados (WASM «interpretado»: 1.2.3, 3.1 y 12.4; cascarón iOS: Tabla 2.2 y 12.4; las dos filas de 6.7). Quedaron 19 filas, agrupadas por marca.
9. **Bibliografía:**
   - R5 (F-05, AOT) no se citaba en el texto: se citó en §3.1, donde se dice que el contenido se compila sin AOT.
   - R42 y R59 no se citan en ningún lugar: quedaron marcadas como «Bibliografía complementaria».
   - Se eliminó una cita duplicada `[R33; R33]` en §9.4.
   - La nota de cabecera del Anexo B ahora dice qué se comprobó: las 51 URL de R16 en adelante responden HTTP 200, salvo R48 (403 a clientes automáticos). El contenido no se contrastó, así que siguen «a verificar».
10. **Formato de citas uniforme:** en 21 filas de tabla, las citas `` `archivo:línea` `` pasaron al formato del libro `[archivo:línea]`. En la Tabla 6.3, la reanudación cita la constante (`ParametrosDeProducto.cs:21-22`) además del anexo, y la sesión SSO de ensayo pasó de «§2.4.1» a `[07-Red-Y-Autenticacion.md:144-150]`.
11. **§9.3.2:** las tres hipótesis de BNA+ se presentaban «de más a menos probable», sin evidencia para ese orden. Ahora dice que no hay evidencia para ordenarlas.

### Comprobado sin cambios

- Parámetros de producto (30 d, 7 d, 15 min, 3 paquetes, 2 versiones, WebView 94, 1 arranque) = `ParametrosDeProducto.cs`.
- Tiempos de red (3 s, 10 s, 5–60 s, 30 s, 5 s–10 min, 5 min, 30 s) = `TransicionesDeRed.cs`, `SincronizadorDelOutbox.cs`, `Oidc.cs`.
- 9,13 MB por versión retenida = E01 `INFORME.md` (tabla del paquete sin comprimir).
- Contrato 1.2.0: 21 métodos, 4 eventos, 3 entradas de catálogo = `contrato.json` (leído con un parser).
- Folios citados: 023, 035, 036, 048, 049, 051, 052, 053 y 058; todos existen (≤ 058).
- Búsqueda de datos privados (rutas del home, IP de tailnet, serie o modelo del teléfono, hosts, nombre personal): cero resultados.

### Pendientes

- **P-2:** contrastar el contenido de las URL de R16 a R62 (por ahora sólo se sabe que responden).
- **Anexo H.2:** los conteos (220/102/56+2) no se volvieron a correr en esta ronda. Requieren `dotnet test` y negociar recursos.
- Los solapamientos entre capítulos y las transiciones entre partes siguen pendientes. Le tocan a la ronda de estilo.
- El texto «relato del responsable del producto, sin folio» (BNA+ y Mercado Libre) sigue sin fuente documental. Si el PO lo quiere sustentado, falta asentarlo en un folio.

## Corrección de estilo

Fecha: 2026-11-01. Archivo: `Concepts/Framework-Concept/MAUI-Framework-Developer-Guide.md` (2857 líneas, sin cambio de longitud).

Método: búsqueda de oraciones de más de 38 palabras en prosa (fuera de tablas, código y títulos): 7 casos; búsqueda de pasivas perifrásticas con agente («fue/es … por»): 0; búsqueda de tratamiento de usted o tuteo: 0 (voseo coherente); términos del Glosario (Anexo A) contra sus variantes en el cuerpo.

Cambios:
1. §3.1: oración de 45 palabras sobre Google Play dividida en dos («La excepción es…»).
2. §6.3 (Modo Formulario): pasiva «ROPC está desaconsejado por el BCP» pasada a activa («el BCP … desaconseja ROPC»); sujeto explícito «la demo lo usa».
3. Entrada de la Parte III: enumeración de capítulos 7–9 en una sola oración partida en oraciones cortas.
4. Anexo (TUF): oración de 39 palabras dividida en dos.
5. §4.3: el segundo recuadro «Blazor Hybrid no es esto» (duplicado del de §1.2.2) se reemplazó por una oración que remite a §1.2.2 y dice sólo lo propio del transporte.
6. §4.3: «deja pasar» → «acepta» (registro técnico).
7. §7.2: equivalente inglés del check agregador alineado con el Glosario (*required aggregate check*).
8. Término único «outbox»: se eliminó la única «bandeja de salida»; la glosa redundante «(*transactional outbox*, outbox)» de §5.1 pasó a remitir a §1.4.2.

Revisado sin cambios: cascarón/contenido/puente/staging/paquete/índice del canal se usan como en el Glosario; «Shell» aparece sólo en rutas de código.

Pendientes: oraciones largas restantes que son listas de preguntas o de estados (§6.7 l. ~1364, Anexo H l. ~2716) y la viñeta especulativa de §9.3 (l. ~1965), dejadas así por ser enumeraciones; transiciones entre partes (no tocadas en esta ronda); conteos del Anexo H.2 sin reconfirmar; contenido de R16–R62 sin contrastar; observaciones de BNA+ y Mercado Libre sin folio; `docs-guard` y render de mermaid en GitHub sin probar.

## Corrección ortotipográfica y diseño editorial

Fecha: 2026-11-01. Archivo: `Concepts/Framework-Concept/MAUI-Framework-Developer-Guide.md` (sigue en 2857 líneas, sin commitear).

Verificaciones (script de chequeo propio, fuera del repo):
- Jerarquía de títulos fuera de bloques de código: sin saltos de nivel (H1 título, H2 partes/anexos, H3 capítulos, H4–H5 secciones).
- Índice general: las 27 entradas coinciden con los títulos H2/H3; todas las anclas internas `](#…)` del libro resuelven contra el slug de GitHub.
- Comillas: prosa en «»; sólo una comilla recta en prosa, anidada dentro de «» (línea 269).
- Miles y unidades: no hay separador de miles con coma ni número pegado a unidad en la prosa (`5 s`, `10 min` con espacio).
- «sólo»/«solo»: «solo» aparece sólo como adjetivo («un solo método»), correcto.
- Tablas: todas las filas tienen la misma cantidad de columnas que su encabezado.
- Mermaid: 27 bloques (15 flowchart, 7 sequenceDiagram, 5 stateDiagram-v2); revisión heurística de etiquetas sin comillas con paréntesis/llaves y de `;`/`#` en mensajes.

Cambios:
1. Línea 269: comillas rectas anidadas dentro de «» pasan a “ ” (orden «“ ”»).
2. Línea 1057 (sequenceDiagram de integración): el mensaje `verde, PR; rojo, corregir` tenía `;`, que Mermaid toma como fin de sentencia y rompe el diagrama; ahora `verde, PR — rojo, corregir`.

Pendientes:
- No se renderizaron los mermaid con mermaid-cli ni en GitHub (requiere Chromium en contenedor: negociar recursos).
- `docs-guard` sin correr.

## Corrección de pruebas

Fecha: 2026-11-01. Archivo: `Concepts/Framework-Concept/MAUI-Framework-Developer-Guide.md` (2857 líneas, sin commitear).

Chequeos (script fuera del repo):
- Fugas: grep de `/home/`, `/vm/`, `claude-tmp`, `trycloudflare`, 100.64/10, 192.168, series de teléfono, nombres de hosts y correo: sin resultados.
- Enlaces markdown relativos: todos existen. Anclas del índice: todas resuelven.
- Rutas de la tabla 2.4 y del mapa de carpetas: existen relativas a `Demo/` (sólo faltan los marcadores `definiciones/<id>/vN.json`, que son plantillas).
- 289 citas `[archivo:líneas]`: todos los archivos existen y ninguna línea citada excede el largo del archivo. 101 citas usan sólo el nombre del archivo; todos son únicos en `Demo/` salvo `network_security_config.xml` (dos variantes).

Cambios:
1. Línea 97: la convención de citas declara que la ruta se omite cuando el nombre es único dentro de `Demo/`.
2. Línea 1984: `[network_security_config.xml:3-13]` → `[Red/ConCaDeDemo/network_security_config.xml:3-13]` (la variante SinCa tiene 6 líneas).
3. Línea 2338: `[.github/workflows/docs-enlaces-semanal.yml:1-6]` → `[../../.github/...]`, coherente con la regla de rutas de la parte III (línea 1509).

Pendientes: no se verificó que el contenido de cada rango citado respalde la afirmación (sólo existencia y rango); mermaid sin renderizar; `docs-guard` sin correr; pendientes de rondas anteriores siguen abiertos.
