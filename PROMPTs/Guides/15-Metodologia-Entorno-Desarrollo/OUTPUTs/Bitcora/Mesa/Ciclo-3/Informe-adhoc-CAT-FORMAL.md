# Informe — Agente ad hoc CAT-FORMAL (alcance lógico de las afirmaciones) — Ciclo 3

- Fecha: 2026-10-09
- Objeto: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (3605 líneas), revisado a ciegas como obra finalizada; no se leyeron informes del ciclo 3.
- Pregunta: ¿el alcance de cada afirmación universal o numérica es igual o menor que el de la evidencia que la respalda?
- Método: `grep -n -i -w -E 'nunca|siempre|jamás|ningún|ninguna|nadie|garantiza'` (93 líneas), lectura de cada candidato contra su evidencia citada; relectura de las salidas del laboratorio que sostienen los resúmenes (`N8-…/salidas/E8-1-choque-de-convenciones.txt`, `N8-…/e1-choque-de-convenciones/experimento.sh`, `N8-…/solucion/src/Saludo/Program.cs`); una corrida E1 nueva de `docker buildx imagetools inspect`. Antes, el destino de mis cinco ítems del ciclo 2 en `Mesa/Ciclo-2/01-Consolidado.md`, `03-Parches.md` y `05-Aplicacion.md`: C2-31, C2-45, C2-46 y C2-47 están aplicados (L522, L1716, L1219, L1291/L1657). **CAT-FORMAL-01 del ciclo 2 (digest) no aparece en el consolidado**: no se decidió ni se descartó; por eso no es re-litigar lo cerrado (ver hallazgo 01).

## Hallazgos

### adhoc-CAT-FORMAL-01 — «El mismo digest es siempre la misma imagen»: el digest que fija la guía es de un índice multiplataforma (S3, E1) — arrastre del ciclo 2 sin disposición

- Ubicación: §8.1, tabla de definiciones, L1361 («Hash `sha256:` del manifiesto de la imagen: el mismo digest es siempre la misma imagen»); §8.2.2, L1408 («fijar por digest garantiza la misma imagen»).
- Alcance de la evidencia: [B113] y todas las corridas del laboratorio, en linux/amd64. La afirmación cuantifica sobre cualquier máquina que use el digest, y la guía apunta a estaciones heterogéneas (ESC-01…ESC-05).
- Contraejemplo (E1, 2026-10-09), sobre el digest que la propia guía fija en la plantilla del Anexo A (L2800):
  ```
  $ docker buildx imagetools inspect mcr.microsoft.com/dotnet/sdk@sha256:78235e09001f52b6592c458ac010775ebac6725422e80cd0c1650590f67b2743
  MediaType: application/vnd.docker.distribution.manifest.list.v2+json
    Name: …@sha256:7ff19b09…  Platform: linux/amd64
    Name: …@sha256:4e00e1ac…  Platform: linux/arm/v7
    Name: …@sha256:499ef150…  Platform: linux/arm64
  ```
  Un digest de índice fija la **lista**; cada arquitectura resuelve otra imagen, con otros binarios. La guía no menciona índices ni plataformas de imagen (`grep -i -E 'arm64|linux/amd64|--platform'` → 0 apariciones fuera de RID/locks).
- Estado: planteado como CAT-FORMAL-01 en el ciclo 2 con la misma evidencia; el consolidado del ciclo 2 no lo registra (ni C2-nn ni descarte). Lo reitero para que tenga disposición.
- Dirección: L1361: «el mismo digest es siempre el mismo manifiesto; si es un índice multiplataforma —como los de las imágenes oficiales—, cada arquitectura resuelve su propia imagen». L1408: «garantiza la misma imagen **para la misma plataforma**». **[criterio]** Si se quiere igualdad entre estaciones de distinta arquitectura, decir que hace falta `--platform` o el digest del manifiesto por plataforma.

### adhoc-CAT-FORMAL-02 — «La compuerta de CI garantiza que su commit cumple»: universal que la propia guía refuta en §10.2.2 y §10.2.7 (S3, E2)

- Ubicación: §8.2.4, «Reglas de convivencia», regla 2, L1449: «Quien no puede o no quiere usarlo trabaja nativo; la compuerta de CI **garantiza** que su commit cumple.»
- Anclas que acotan el alcance real:
  - §10.2.7, L1967: «E7-5 muestra qué significa "la CI avisa pero no impide": un commit con cp1252, hecho con `--no-verify`, se empuja a `main` y se acepta; la CI corre **después**, da rojo, y `main` ya quedó roto.»
  - §10.7, L2098 (criterios de calidad): «documentar "la CI bloquea el merge" sin protección de rama».
  - §10.2.2, L1916: «un manifiesto sin lock queda para la revisión».
- Problema: «garantiza» cuantifica sobre todo commit y toda plataforma; la evidencia de la guía (E7-5) muestra que sin protección de rama la CI sólo **detecta** después, y el alcance declarado de la compuerta deja fuera los manifiestos sin lock. La regla repite el antipatrón que la guía enumera en L2098.
- Dirección: «la compuerta de CI **detecta** si su commit no cumple; lo **impide** sólo con protección de rama o con la compuerta en la publicación (§10.2.7)».

### adhoc-CAT-FORMAL-03 — «Con cp1252 falla C# en Linux»: generaliza desde una muestra cuyo carácter cae en un identificador (S4, E1 + E2)

- Ubicación: §11.6 (pregunta «¿qué se rompe primero…?»), L2409: «con cp1252 falla C# en Linux, falla Python y Node corrompe sin error los datos que lee (un identificador cp1252 en su propio código sí lo haría fallar, §4.2.4) (E8-1)».
- Alcance de la evidencia (E1, archivos del laboratorio): el caso D de E8-1 convierte a cp1252 `src/Saludo/Program.cs`, cuyo único no-ASCII está en un identificador: `solucion/src/Saludo/Program.cs:6: var añoDeConstrucción = new {…}`; la salida da `Program.cs(6,6): error CS1056: Unexpected character '�'`.
- Ancla de la regla general: §4.2.4, L522: «Roslyn, Razor y Node, en Linux y macOS, fallan sólo con el carácter en un identificador (`CS1056`…) y corrompen sin error literales y HTML (E1-01…)».
- Problema: la frase da a C# un «falla» incondicional y a Node la salvedad del identificador; es la misma condición para los dos y la muestra de E8-1 cayó del lado que falla. Un `.cs` heredado con la `ó` sólo en literales —el caso típico de textos de interfaz— compila y corrompe sin error en Linux.
- Dirección: «con cp1252, C# en Linux falla si el carácter está en un identificador (como en E8-1) y corrompe sin error si está en un literal; falla Python; Node corrompe sin error los datos que lee (§4.2.4)».

### adhoc-CAT-FORMAL-04 — La apertura de §4 conserva los universales que la tabla de §4.2.4 ya acotó (S4, E2)

- Ubicación: §4, párrafo de entrada, L443: «Node.js decodifica **siempre** como UTF-8 y reemplaza lo que no entiende; Python exige UTF-8 o una declaración explícita y, si no la encuentra, **se niega a compilar**».
- Anclas en la misma sección:
  - L507 (Node `require`/`import`, cp1252): «identificador → `SyntaxError`» (no reemplaza: falla); L508: «`TextDecoder({fatal:true})` rechaza bytes inválidos» y la decodificación es «por llamada» (no «siempre» UTF-8).
  - L522 (aplicación de C2-31): «salvo un cp1252 cuyos bytes forman UTF-8 válido, que se lee con otro texto» — Python no se niega a compilar en ese caso.
- Problema: el resumen de entrada es lo primero que lee quien llega al capítulo y queda más fuerte que la tabla y que la corrección de C2-31; es coherencia global, no un hecho nuevo.
- Dirección: «Node.js lee sus módulos como UTF-8: reemplaza lo que no entiende en literales y falla en un identificador; Python exige UTF-8 o una declaración explícita en el fuente y, ante un byte inválido, se niega a compilar». (La excepción del mojibake puede quedar en §4.2.4.)

## Revisadas y bien

1. **Contrato de la marca [observado] (§0.3, L93: «se dice siempre con qué versión se observó»)**: las cinco apariciones de uso llevan versión — L110 (buildx v0.35.0 → 0.13.1), L1209 (SDK 8.0.425), L1240 (Yarn 4.10.3, pnpm 10.18.0, uv 0.12.23, Poetry 2.5.1), L1661/L1716 (npm 11.19.0, ahora también en la tabla por C2-45), L1914 (git 2.39.5, SDK 8.0.425).
2. **§7.2.1 L1291 y §9.2.1 L1657 (C2-47)**: «con SDK 8 … (E6-2), y con SDK 10 también, según [B147]» y «**[criterio]** En SDK 8 o 10 se compara por contenido»: el alcance de cada mitad coincide con su respaldo (corrida para SDK 8, documentación para SDK 10).
3. **Umbrales numéricos atribuidos**: L1408 «dentro de las 12 horas … una vez por mes, típicamente el segundo martes [B115]» y L1980 «presupuesto acumulado de 5 segundos [B188]; la compuerta del laboratorio tardó 1,5–2,3 s en un repo de juguete (E7-5b), que no se generaliza»: cifras de fuente atribuidas a la fuente y la medición propia acotada explícitamente.

## Solicitudes de convocatoria

- Al consolidador / coherencia histórica: CAT-FORMAL-01 del ciclo 2 (digest de índice) no tiene fila en `Mesa/Ciclo-2/01-Consolidado.md`; conviene verificar si otros ítems de informes del ciclo 2 quedaron igualmente sin disposición.
