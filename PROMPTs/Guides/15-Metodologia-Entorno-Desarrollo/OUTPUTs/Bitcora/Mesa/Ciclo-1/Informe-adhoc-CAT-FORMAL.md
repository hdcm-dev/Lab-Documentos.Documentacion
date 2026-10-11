# Informe — Agente ad hoc CAT-FORMAL (alcance lógico de las afirmaciones) — Ciclo 1

- Fecha: 2026-10-07
- Objeto: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (3060 líneas), revisado a ciegas.
- Pregunta: ¿el alcance de cada afirmación universal o numérica es igual o menor que el de la evidencia que la respalda?
- Método: grep de cuantificadores (`nunca|siempre|ningún|nadie|todos|cualquier…`) con número de línea; para cada uno, lectura de la evidencia citada (salida del laboratorio o fuente) y búsqueda de un contraejemplo ejecutable.

## Hallazgos

### adhoc-CAT-FORMAL-01 — «Node y Razor nunca» fallan ante cp1252: generaliza desde literales a todo el fuente (S2, E1)

- Ubicación: §4.2.4, L474 («**Nadie falla ruidosamente ante cp1252 salvo Python.** Roslyn falla sólo si cae en un identificador; Node y Razor nunca.»); se repite en la tabla L457 (Razor: «U+FFFD en HTML y en `@code`»), L459 (Node: «U+FFFD, sin error») y en §11, L2127 («con cp1252 … Node corrompe sin error»).
- Alcance de la evidencia: E1-04 (`e1-razor.sh`) y E1-05 (`e1-node.mjs`) sólo prueban **literales** (`generar.py` L18: `LITERAL = "Atención: señal…"  # sólo un literal`; el `.razor` de prueba tiene acentos sólo en texto HTML y en un string de `@code`). La afirmación cubre cualquier archivo.
- Contraejemplo Node (E1, Node v22.23.2 en el host):
  ```
  $ printf 'const a\xf1o = 2026;\nconsole.log(a\xf1o);\n' > id.js && node id.js; echo rc=$?
  const a�o = 2026;
        ^
  SyntaxError: Missing initializer in const declaration
  rc=1
  ```
- Contraejemplo Razor (E1, `mcr.microsoft.com/dotnet/sdk:8.0`, SDK 8.0.425, mismo `Lib.csproj` del laboratorio, `.razor` en cp1252 con `<p>@Çaudal</p>` y `public int Çaudal {get;set;}` en `@code`):
  ```
  /w/Aviso.razor(1,5): error RZ1005: "�" is not valid at the start of a code block. ...
  /w/Aviso.razor(3,16): error CS1056: Unexpected character '�'
  ```
  Además, el propio diagrama de §4.2.1 dice «Roslyn abre un .cs (o Razor genera un .g.cs)» → identificador = CS1056: la guía se contradice.
- Dirección: acotar al mismo condicional que Roslyn: «Node y Razor fallan sólo si el carácter cae en un identificador (`SyntaxError`, `RZ1005`/`CS1056`); en literales y en HTML corrompen sin error». Ajustar L457, L459, L474 y L2127, y sumar el caso «identificador» a E1-04 y E1-05 para que la tabla tenga evidencia de ambas ramas.

### adhoc-CAT-FORMAL-02 — Regla de `file` enunciada como bicondicional desde una sola muestra (S4, E1)

- Ubicación: §4.3, L533: «`file` … informa «ISO-8859 text» para cp1252 y Latin-1 mientras no aparezca ningún byte `80–9F`, y «Non-ISO extended-ASCII text» si aparece (E1-13)».
- Problema: la frase se lee como regla general («para cp1252… mientras…»), pero E1-13 midió un archivo de muestra y la versión de `file` no se declara. Contraejemplo: un archivo cp1252 válido cuyo contenido no ASCII forma secuencias UTF-8 válidas (texto con mojibake heredado, frecuente justo en código migrado a medias) es clasificado como UTF-8, sin bytes `80–9F`:
  ```
  $ file --version | head -1
  file-5.46
  $ printf 'Texto de prueba con acentuaci\xc3\xb3n mal le\xc3\xadda en cp1252\n' > moji.txt; file moji.txt
  moji.txt: Unicode text, UTF-8 text
  $ iconv -f cp1252 -t utf-8 moji.txt
  Texto de prueba con acentuaciÃ³n mal leÃ­da en cp1252
  ```
- Dirección: declarar la versión de `file` y bajar el cuantificador: «en E1-13 (file 5.x), un cp1252 típico salió como…; no es un detector: un cp1252 cuyos bytes casualmente forman UTF-8 válido sale como UTF-8». Ya está la palabra «heurístico»; falta que la regla no se enuncie como condición necesaria y suficiente.

### adhoc-CAT-FORMAL-03 — `[observado]` sin la versión observada: «`npm pack` dio el mismo tarball» (S4, E2)

- Ubicación: §9.2.2, L1449: «**`npm pack` dio el mismo tarball** desde dos rutas con fechas distintas: todas las entradas llevan `mtime` fijo 1985-10-26T08:15:00Z (E6-3) **[observado]**».
- Problema: la marca `[observado]` se define (L81) como comportamiento «que puede cambiar sin aviso»; la afirmación, sin versión, se lee para todo npm. La salida de E6-3 lo acota: `node v24.21.0 / npm 11.19.0`, un tarball de **dos** entradas (`package/index.js`, `package/package.json`) y una sola imagen (`node@sha256:ebfe2f…`). «Todas las entradas» es cierto para dos entradas; la variación probada es ruta y mtime, no umask/uid ni otra versión de npm.
- Dirección: escribir «con npm 11.19.0 (E6-3)…» y decir qué variaciones se probaron (ruta y fecha de archivo). Coherente con la recomendación ya presente de que la compuerta lo compruebe.

### adhoc-CAT-FORMAL-04 — «Sólo Python permite declarar la codificación por archivo» choca con la línea anterior (S4, C)

- Ubicación: §4.2.4, L473–L475.
- Ancla: L473 «Roslyn y los editores lo usan [el BOM] como firma»; L432 (diagrama) «¿Empieza con BOM? sí → UTF-8 (el BOM manda)»; L475 «**Sólo Python** permite declarar la codificación por archivo. C# la declara para toda la compilación…».
- Problema: el BOM es, para Roslyn, una marca **por archivo** que decide la decodificación aun con `CodePage` presente; el universal «sólo Python» depende de que «declarar» excluya la firma. Es pregunta de definición (nivel C), no corrección.
- Dirección (pregunta): ¿se quiere decir «declarar una codificación arbitraria por archivo»? Si es así, decirlo («sólo Python permite declarar por archivo una codificación distinta de UTF-8; en C# y Node el BOM sólo puede señalar UTF-8/UTF-16»).

## Revisadas y bien

1. L1727 «5 segundos» (GHES `pre-receive`): número atribuido a la fuente [B188] y la medición propia (1,5–2,3 s, E7-5b) se acota explícitamente («repo de juguete … no se generaliza a un repo real»). Alcance de la afirmación = alcance de la evidencia.
2. L1058 «`npm ci` … **nunca** escribe el lock ni `package.json`»: el «nunca» es el de la fuente. docs.npmjs.com/cli/v11/commands/npm-ci (consultada 2026-10-07): «It will never write to `package.json` or any of the package-locks: installs are essentially frozen.» y «If a `node_modules` is already present, it will be automatically removed…». No hay generalización más allá de la documentación.
3. L1223 «dentro de las 12 horas … típicamente el segundo martes» y L1124 «Desde .NET 11 … deterministas por defecto **si** se fija la fecha»: los números y condicionales se atribuyen a la fuente con su calificador («típicamente», «si»), y la medición propia (E5-2) se presenta como caso, con fechas y versiones concretas.

## Solicitudes de convocatoria

- Ninguna fuera de mandato. (La verdad de «pnpm/Yarn activan el modo estricto **sólo** cuando detectan CI», L1058, corresponde a verificación-evidencia; desde lo lógico el «sólo» excluye la configuración explícita que la propia frase recomienda después — conviene que ese especialista confirme el alcance.)
