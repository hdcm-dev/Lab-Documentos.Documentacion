# Informe — Agente ad hoc CAT-FORMAL (alcance lógico de las afirmaciones) — Ciclo 2

- Fecha: 2026-10-09
- Objeto: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (3391 líneas), revisado a ciegas como obra finalizada; no se leyeron informes del ciclo 2.
- Pregunta: ¿el alcance de cada afirmación universal o numérica es igual o menor que el de la evidencia que la respalda?
- Método: `grep -n -i -w` de cuantificadores (`nunca|siempre|ningún|nadie|jamás|cualquier|todos|sólo`; 396 apariciones con `sólo/único`) y de umbrales numéricos; para cada candidato, lectura de la salida del laboratorio citada y búsqueda de un contraejemplo ejecutable. Se verificó primero el destino de mis cuatro ítems del ciclo 1: C1-11 aplicado (L516, tabla L499–L501), C1-57 aplicado en §9.2.2 (L1611); C1-Q02 y C1-Q04 no recibieron respuesta.

## Hallazgos

### adhoc-CAT-FORMAL-01 — «El mismo digest es siempre la misma imagen»: el digest que fija la guía es de un índice multiplataforma (S3, E1)

- Ubicación: §8.1, tabla de definiciones, L1319 («Hash `sha256:` del manifiesto de la imagen: el mismo digest es siempre la misma imagen»); repetido en §8.2.2, L1366 («fijar por digest garantiza la misma imagen»).
- Alcance de la evidencia: [B113] y las corridas del laboratorio, todas en linux/amd64. La afirmación cuantifica sobre toda máquina que use el digest.
- Contraejemplo (E1, 2026-10-09, `docker buildx imagetools inspect` sobre el digest que fija el propio laboratorio en `Examples/N6-procedencia-y-trazabilidad/salidas/e2-determinismo-dotnet.txt` L1):
  ```
  $ docker buildx imagetools inspect mcr.microsoft.com/dotnet/sdk@sha256:78235e09001f52b6592c458ac010775ebac6725422e80cd0c1650590f67b2743
  MediaType: application/vnd.docker.distribution.manifest.list.v2+json
    Platform:  linux/amd64
    Platform:  linux/arm/v7
    Platform:  linux/arm64
  ```
  Lo mismo con `python:3.12-slim` (índice OCI `sha256:a6e34c59…` → `linux/amd64` `sha256:2b4f19da…`, otra plataforma `sha256:46067146…`). Un digest de índice es la misma **lista**; cada arquitectura recibe otra imagen, con otros binarios. La guía no menciona índices ni plataformas (`grep -i -E "multi-?plataforma|arm64|linux/amd64"` → 0 resultados).
- Dirección: acotar la definición: «el mismo digest es siempre el mismo manifiesto; si es un índice multiplataforma —como los de las imágenes oficiales—, cada arquitectura resuelve su propia imagen». En L1366, «la misma imagen **para la misma plataforma**». Si se quiere la igualdad entre estaciones de distinta arquitectura, decir que hace falta fijar `--platform` o el digest del manifiesto por plataforma **[criterio]**.

### adhoc-CAT-FORMAL-02 — «Sólo Python falla siempre ante cp1252»: el resumen pierde la condición de plataforma y el «siempre» tiene contraejemplo (S3, E1 + E2)

- Ubicación: §4.2.4, «Tres lecturas que forman criterio», L516: «**Sólo Python falla siempre ante cp1252.** Roslyn, Razor y Node fallan sólo si el carácter cae en un identificador (`CS1056`, `RZ1005`, `SyntaxError`); en literales y en HTML corrompen sin error (E1-01, E1-04, E1-05).»
- Problema 1 (E2, contradicción interna): la tabla de la misma sección separa «Roslyn (C#), Linux/macOS» (L498) de «Roslyn (C#), Windows con ACP 1252 — cp1252 sin BOM: **correcto**» (L499), y el diagrama de §4.2.1 tiene la rama «Windows, ACP 1252 → cp1252 ✔». El resumen enuncia sin condición que Roslyn corrompe en literales: vale sólo en Linux/macOS, la plataforma de E1-01. El caso entero de la guía es justamente que en Windows no pasa nada.
- Problema 2 (E1, Python 3.13.5 en el host): el «siempre» falla cuando los bytes del cp1252 forman UTF-8 válido (el mojibake heredado que ya aceptó C1-56 para `file`):
  ```
  $ printf 'print("Atenci\xc3\xb3n")\n' > moji.py && python3 moji.py; echo rc=$?
  Atención
  rc=0
  $ iconv -f cp1252 -t utf-8 moji.py
  print("AtenciÃ³n")
  ```
  El archivo, leído como cp1252, dice `AtenciÃ³n`; Python lo ejecuta sin error y con otro texto. Además, la fila «Python `open()` sin `encoding=` → según *locale*» (L506) de la misma tabla muestra un Python que no falla; el «siempre» vale para el **código fuente**, no para Python en general. (Que un byte inválido en un comentario también falla es cierto: `# se\xf1al` → `SyntaxError: Non-UTF-8 code`, rc=1.)
- Dirección: «**En Linux y macOS, sólo Python falla con el fuente en cp1252** ante cualquier byte inválido como UTF-8, también en un comentario; Roslyn, Razor y Node fallan sólo si el carácter cae en un identificador… En Windows con ACP 1252, Roslyn lo lee bien (§4.2.1).» Si se quiere conservar «siempre», agregar la excepción: un cp1252 cuyos bytes forman UTF-8 válido pasa sin error.

### adhoc-CAT-FORMAL-03 — La tabla de §9.3 repite el `[observado]` de `npm pack` sin la versión y con un «sí» incondicional (S4, E2)

- Ubicación: §9.3, fila «Determinismo del paquete», L1672: «`npm pack`: sí, `mtime` fijo **[observado]**».
- Ancla del contrato: §0.3, L92: «**[observado]** … se dice **siempre** con qué versión se observó, porque puede cambiar sin aviso».
- Problema: es una de las tres apariciones de la marca en la guía (L92 la define, L1611 y L1672 la usan). L1611 quedó acotada por C1-57 («Con npm 11.19.0… no se probaron otro usuario, otro *umask* ni otra versión de npm»); la tabla que la resume vuelve al alcance universal («sí») y viola el contrato de la marca. Las otras celdas de la fila sí condicionan («no en SDK 8/10; sí en SDK 11 con la fecha fijada»).
- Dirección: «`npm pack`: sí con npm 11.19.0 (E6-3), `mtime` fijo **[observado]**».

### adhoc-CAT-FORMAL-04 — Pendiente C1-Q04: «activan el modo estricto **sólo** cuando detectan CI» choca con la tabla y con la recomendación de la misma frase (S4, E2)

- Ubicación: §7.2.2, L1189: «pnpm (`--frozen-lockfile`) y Yarn (`--immutable`) activan el modo estricto **sólo cuando detectan CI** [B95][B96]; **[criterio]** en la compuerta, pedirlo explícitamente…».
- Ancla: §7.3, L1202: «`--frozen-lockfile` (default en CI)» y «`--immutable` (default en CI)».
- Problema: el «sólo» excluye la activación explícita, que la misma oración recomienda y que la tabla L1149 lista como forma de restauración estricta. La tabla de L1202 dice lo correcto («default»); el texto lo convierte en condición necesaria. Lo había planteado como C1-Q04 y quedó sin respuesta.
- Dirección: «lo activan **por defecto** cuando detectan CI».

### adhoc-CAT-FORMAL-05 — «Empaquetado dos veces con SDK 8 **o 10** da `.nupkg` con hash distinto (E4-3, E6-2)»: la mitad SDK 10 no tiene corrida (S4, E1)

- Ubicación: §7.2.1, L1259.
- Alcance de la evidencia (salidas del laboratorio): `Examples/N6-procedencia-y-trazabilidad/salidas/e2-determinismo-dotnet.txt` empaqueta dos veces con SDK 8.0.425 (casos 1–4, 6) y con SDK 11 (casos 7–8); con SDK 10.0.400 sólo el caso 5, «SDK 8 frente a SDK 10», que difiere por el SDK, no por el empaquetado. `Examples/N4-congelamiento-de-dependencias/salidas/` (E4-3, `NU1403`) corre con SDK 8.0.425. Nadie empaquetó dos veces con SDK 10.
- Problema: la afirmación atribuye a E4-3/E6-2 un alcance (SDK 10) que sólo sostiene [B147] por inferencia («desde .NET 11…» implica «no antes»). Es verosímil, pero la etiqueta de evidencia es mayor que la corrida.
- Dirección: «con SDK 8 (E4-3, E6-2); con SDK 10, según [B147]» o agregar a E6-2 un par SDK 10 / SDK 10.

## Revisadas y bien

1. §9.2.2, L1611 (corrección C1-57): «Con npm 11.19.0… las dos entradas del paquete de prueba… no se probaron otro usuario, otro *umask* ni otra versión de npm». El alcance de la afirmación coincide con el de E6-3 y declara lo no probado.
2. §10, L1912, «presupuesto acumulado de **5 segundos**» [B188] y la medición propia «1,5–2,3 s en un repo de juguete (E7-5b), lo que no se generaliza a un repo real»: umbral atribuido a la fuente y muestra propia acotada explícitamente.
3. §6.2.2, L992, «Los *targets* del SDK 8.0.425 no traen **ninguna** selección automática»: el universal negativo está acotado a la versión inspeccionada. Igual L604 «con BOM se lee UTF-8 … con cualquier `CodePage`»: lo respalda el código ([B14]: la detección del BOM precede a la rama `CodePage`) y E1 (`e1-roslyn-sdk10.txt` L60, «el BOM manda sobre CodePage»).

## Solicitudes de convocatoria

- Fuera de mandato: C1-Q02 («Sólo Python permite declarar la codificación por archivo», L517) sigue sin respuesta; la misma oración dice que git «la declara por ruta», y una ruta puede ser un archivo. Es pregunta de definición (C) para requisitos o didáctica, no corrección.
- A verificacion-evidencia: L604 «Para Node es … dañino en datos (`fs` lo conserva, `JSON.parse` falla)»; E8-1 caso B muestra `node: require(datos.json) OK` con BOM. Conviene que confirme si «dañino en datos» debe acotarse a `readFileSync` + `JSON.parse`.
