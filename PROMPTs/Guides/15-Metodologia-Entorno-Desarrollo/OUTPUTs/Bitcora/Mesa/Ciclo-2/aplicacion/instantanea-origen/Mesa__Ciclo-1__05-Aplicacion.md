# Mesa · Ciclo 1 · 05 — Aplicación de los parches aprobados

> Fecha: 2026-10-09. Rol: editor de aplicación (marco `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §5.6).
> Insumo: `03-Parches.md` (P-01…P-22 y P-24 de la revisión 1; P-23 en su **Revisión 2**), aprobados en `04-Aprobacion-*.md` y `04b-Aprobacion-*.md`.
> Artefacto: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md`, de **1.0.0-borrador** (3060 líneas) a **1.0.0-rc.1** (3391 líneas).
> Laboratorio: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Examples/`. Capa de origen: `Bitcora/Nucleos/`, `03-Marco-De-Referencia.md`, `04-Integracion.md`.
> Reproducibilidad: los guiones de aplicación y de chequeo, y el registro operación por operación (`log.json`, 339 operaciones), están en [`aplicacion/`](aplicacion/). Se aplican siempre sobre la copia de la 1.0.0-borrador, de modo que la corrida se repite desde cero.

## 1. Resumen

| Concepto | Resultado |
|---|---|
| Parches aplicados | 24 de 24: P-01…P-22, P-23 (Revisión 2) y P-24 (registro de proceso, §6) |
| Operaciones sobre la guía | 339, ninguna fallida (anclas literales únicas; cada una con su resultado en `aplicacion/log.json`) |
| Ítems revertidos por verificación fallida (regresiones) | 2: **P-08 ítem 3** y **P-14 ítem 24, consigna 1 de §11.9** (§3) |
| Ajustes derivados, sin decisión nueva | 7 (§4) |
| Notas de origen (P-23) | 36 notas de solo agregado: 16 de la revisión 1 y 20 de la revisión 2 (R2-01…R2-20), en 11 archivos; 0 líneas originales borradas |
| Experimentos re-corridos o nuevos | E1-04, E1-05, E1-13, §1.2 de la guía, E2-2, E2-7, E2-8 (copia fechada), E3-1…E3-6, E4-2 (SDK 8 y 10), E4-4, E7 (regresión), E8-3, E8-5, E8-6 (§11.5 literal), EA-1; regresión sin cambios en E8-1 y E8-2 |
| Versión | 1.0.0-rc.1, con control de cambios al final de la guía y entrada en el índice |

Orden seguido, el del §0 de `03-Parches.md` y las condiciones de `04-Aprobacion-riesgo.md`: instantánea de la capa de origen → P-23 → P-19 → P-22 (laboratorio) → P-01…P-18 → P-20, P-21 → P-03 3f (pasada final de marcas) → P-24.

## 2. Changelog: hallazgo → veredicto → parche → verificación → versión

Veredictos de la mesa de aprobación (`04-…`, primera vuelta; `04b-…`, segunda): A = APLICAR, M = MEJORAR_PLAN. Orden de los jueces: coherencia histórica · costo-beneficio · evidencia · impacto · riesgo.

| Parche | Hallazgos | Veredicto | Qué se aplicó | Verificación (criterio del parche) | Resultado |
|---|---|---|---|---|---|
| P-23 (Rev. 2) | C1-01…C1-04, C1-09…C1-12, C1-14, C1-16…C1-21, C1-26, C1-29, C1-30, C1-34, C1-35, C1-36, C1-56 | Rev. 1: A·M·A·A·M → Rev. 2: A·A·A·A·A | 36 notas `> **Corrección mesa ciclo 1 (2026-10-09, C1-nn).**` al pie del bloque que contiene la frase ancla; antes, instantánea de los 11 archivos en `instantanea-origen-2026-10-09/` (condición 1 de riesgo) | Cada fila con su nota; `diff` contra la instantánea: 0 líneas `<`, sólo `>`; anclas por línea **y** frase, las 36 coincidieron | ✔ (R2-11, R2-12 y R2-14 ajustadas en la misma pasada: §5) |
| P-19 | C1-34, C1-35, C1-41; fuentes nuevas | A·A·A·A·A | Fechas de consulta; B14 y B49 por permalink; B15 y B155 redescriptas; B194–B204 | 204 `[Bnn]` definidas y 204 citadas, ninguna colgante | ✔ |
| P-22 | L1–L18 | A·A·A·A·A (condiciones: L11 con `requested`/`resolved`; corrida de P-04 versionada) | Laboratorio: ver §6 | Cada fila con su salida versionada (§6) | ✔ |
| P-01 | C1-43, C1-46, C1-40 | A·A·A·A·A | `status`, `fuentes_consultadas`, fechas, 204 fuentes y 73 experimentos | `de la mesa` → 0; `^traces:` → 1; `204 fuentes` → 1; 73 IDs distintos en el Anexo E | ✔ |
| P-02 | C1-42, C1-54 | A·A·A·A·A | Sin «Partes»; «corrección»; «compuerta única y su alcance» | `Parte I` → 0; índice ↔ `##` en orden (20 = 20) | ✔ |
| P-03 | C1-45, C1-55, C1-24, C1-23, C1-40, C1-27, C1-06 | A·M·A·M·A (3 de 5) | 3a–3e, 3g, 3h; 3f como pasada final (las marcas viejas eran ancla de P-07, P-10, P-11 y P-13) | Marcas no canónicas `\[(no verificado|criterio)[^]]+\]` → 0; fuera de código, marcas totales/en negrita: antes 127/107, después 132/132; `../Despliegue/` existe; los dos comandos de §0.4, copiados tal cual y corridos seguidos en un mismo shell sobre una copia de `Examples/`, dan N0 rc=0 y A-plantillas rc=0 (las salidas versionadas de N0 no se tocaron) | ✔ (deuda D-3) |
| P-04 | C1-27, C1-54 | A·A·A·A·A (condición: versionar la corrida) | Comandos de reproducción de §1.2; «corrección»; «artefacto» | Corrida literal en copia limpia, no root: `N1-…/salidas/e1-reproduccion-guia-1.2.txt` (`CS1056`, `U+     : FFFD 006E 003A`, `work/` del usuario) | ✔ |
| P-05 | C1-35, C1-38, C1-49 | A·A·A·A·A | macOS, decisiones de ACT-ARQ/ACT-OPS, §9 en la matriz, párrafo de §2.4 | Ninguna celda `—` en §2.4 para un capítulo con fila de aplicación en ese escenario | ✔ |
| P-06 | C1-01, C1-02, C1-04, C1-06, C1-21, C1-22, C1-24, C1-25, C1-40, C1-42, C1-44, C1-54 | A·A·A·A·A | 13 ítems: mapa, fuentes de Fijar/Congelar, filas de §3.3 y §3.6, «Por contexto», *Aplica* y pregunta situada | `fabricantes |` → 0; `capítulos 4 a 10 desarrollan` → 0; `Por contexto.**` → 1; §3.3 y §6.4 dicen lo mismo de `disable` | ✔ |
| P-07 | C1-11, C1-22, C1-23, C1-35, C1-38, C1-40, C1-52, C1-56 | A·A·A·A·A | 13 ítems; diagrama con la rama ACP UTF-8 punteada | `Node y Razor nunca` → 0; E1-04/E1-05 re-corridos con las dos ramas; diagrama renderiza (mermaid-cli 12.0.0) | ✔ |
| P-08 | C1-06, C1-08, C1-09, C1-10, C1-22, C1-23, C1-36, C1-37, C1-38, C1-44, C1-47, C1-54, C1-55 | A·A·**M**·A·A (4 de 5) | 21 de 22 ítems | E2-2, E2-7, E2-8 con rc=0 y salidas versionadas; grep de squash → 0; YAML válido; **ítem 3 contradicho por E2-8** | ✔ con **ítem 3 revertido** (§3) |
| P-09 | C1-01, C1-03, C1-04, C1-22, C1-23, C1-31, C1-38, C1-44, C1-50, C1-55 | A·A·A·A·A | 14 ítems; tabla de las dos políticas en §6.4 | `no queda bloqueada` → 0; `Corepack, si está` → 0; E3-2 y E3-3 re-corridos con las ampliaciones; §6.4 = §3.3 = A.3 = B.1 sobre `disable` | ✔ |
| P-10 | C1-02, C1-03, C1-22, C1-23, C1-25, C1-26, C1-30, C1-33, C1-38, C1-40, C1-44, C1-55, C1-58 | A·M·A·M·A (3 de 5; condición: salida con `requested`/`resolved`) | 20 ítems | `sin advertencia|sin advertir` → 0; ``pip-compile` sin `--universal`` → 0; sin `[no verificado]` en pnpm/Yarn multiplataforma; E4-2 paso 5 en cuatro variantes, SDK 8 y 10, con la entrada completa del lock; E4-4 con pnpm y Yarn | ✔ (deuda D-2) |
| P-11 | C1-20, C1-21, C1-22, C1-23, C1-38, C1-40, C1-44, C1-55 | A·A·A·A·A | 13 ítems | `Digest en todo lo versionado` → 0; §8.5 JSONC válido; la etiqueta `sdk:8.0.425-bookworm-slim` está en el registro (comprobada por el juez de evidencia, J5) | ✔ |
| P-12 | C1-04, C1-16, C1-17, C1-18, C1-22, C1-23, C1-32, C1-34, C1-38, C1-43, C1-51, C1-54, C1-55, C1-57 | A·A·A·A·A (ancla del ítem 16: «para el repo») | 19 ítems | `L1 de inmediato` → 0; `actions/attest@v4$` → 0; `5962` con «2.2.1»; `pieza` sólo en §1.1 (pregunta 3), en nombres de archivo y en la definición del glosario | ✔ (ajuste A-3) |
| P-13 | C1-05, C1-06, C1-08, C1-19, C1-22, C1-23, C1-28, C1-38, C1-40, C1-49, C1-55 | A·A·A·A·A | 13 ítems; tabla «qué impide / qué no impide» | Sin `python3`, la compuerta nombra la herramienta y no dice «política» (`N7-…/salidas/e7-prerrequisitos-de-la-compuerta.txt`); `sólo con Pro, Team o Enterprise` → 0; `publicar.sh` con `git clone` | ✔ |
| P-14 | C1-06, C1-11…C1-16, C1-18, C1-21, C1-22, C1-23, C1-29, C1-33, C1-38, C1-55 | A·**M**·A·A·A (4 de 5) | 23 de 24 ítems, más la consigna 2 del ítem 24 | Bloque de §11.5 corrido literal sin el builder: rc=0 (`E8-6-comando-de-la-guia.txt`); E8-3 con `EBADDEVENGINES`; `lo único que hace cumplir` → 0; diagrama renderiza; **consigna 1 de §11.9 contradicha por E8-1** | ✔ con **consigna 1 revertida** (§3; deuda D-4) |
| P-15 | C1-03, C1-06, C1-10, C1-18, C1-21, C1-37, C1-39, C1-40, C1-47, C1-54 | A·A·A·A·A | 9 ítems; filas 8a y 8b; YAML de contrato | `se pueden leer en cualquier orden` → 0; filas 8a y 8b presentes; YAML válido | ✔ |
| P-16 | C1-01, C1-02, C1-03, C1-06…C1-08, C1-10, C1-13, C1-19…C1-21, C1-26, C1-36, C1-37, C1-53 | A·A·A·**M**·A (4 de 5) | 14 ítems; A.4b `Directory.Build.targets`; A.9 con la receta de A.10; A.10 con Node 24; esqueleto que falla | `diff` byte a byte Anexo A ↔ `A-plantillas/repo/`: 20 de 20 iguales; EA-1 rc=0 con pasos 1b, 2b, 6 y 7; el hook con el esqueleto rechaza el `.cs` cp1252 (rc=1); `dependabot.yml` válido con `docker` | ✔ (deuda D-1) |
| P-17 | C1-01, C1-03, C1-06, C1-09, C1-18, C1-21, C1-26 | A·A·A·A·A | 6 ítems de B.1–B.3 | Cada ítem remite a una sección que, tras P-06…P-15, dice lo mismo (cotejado: §6.4, A.11, §5.2.6 paso 5, §8.2.2, §9.2.4, §12) | ✔ |
| P-18 | C1-25, C1-54 | A·A·A·A·A | «Fin de línea», «Índice (git)», «Artefacto»; 25 filas (23 términos nuevos); SLSA y SBOM expandidos en su primera aparición | Términos en negrita de las tablas de §3.1…§11.1 contra el Anexo C: 0 faltantes (3 por sinónimo: «Página de códigos ANSI» = ACP, «Rango declarado» y «Fijación exacta / rango / piso» = Rango, Fijar); `Supply-chain Levels` → 2 | ✔ (ajuste A-4) |
| P-20 | C1-55 | A·A·A·A·A (criterio: «73 IDs», no «73 filas») | Intro, salidas de E3, filas ampliadas, E2-7 y E2-8 | Cada ID del cuerpo tiene fila (72 citados, 0 sin fila); 73 IDs distintos; 144 rutas de la tabla comprobadas, todas existen (2 escritas abreviadas, `E0-3a…c` y `-sdk10.txt`, verificadas a mano) | ✔ |
| P-21 | C1-20, C1-35, C1-43, C1-46, Q09 | A·A·A·A·A | Tabla de trazas; «No verificado» y «Interpretaciones»; SBOM sin «pendiente» | `de la mesa` → 0; los 17 IDs de `traces:` están en la tabla | ✔ |
| P-24 | C1-48 | A·A·A·A·A | No se escribe la ia-db; se registra el apartamiento para el PO (§7) | Entrada propuesta en §7 de este archivo, para el cierre del ciclo | ✔ |

## 3. Regresiones: ítems revertidos por su verificación

El encargo pide revertir lo que falla su verificación. Los dos casos son afirmaciones que el parche agregaba y que **su propia evidencia** contradice; se revirtió sólo el ítem, no el parche entero, y quedó registrado en `aplicacion/log.json`.

| Ítem | Qué decía | Qué muestra la evidencia | Estado de la guía | Para el ciclo 2 |
|---|---|---|---|---|
| P-08 ítem 3 (§5.2.2) | Los seis repos `dotnet/*` declaran `eol` «sólo para `.sh` y, en algunos, `.cmd`, `.bat` y `.sln`» | E2-8 (`N2-…/salidas/e8-repos-de-referencia.txt`): también `gradlew`, `jquery*.js`, `jquery*.map`, `bootstrap*.js` (`aspnetcore`), `*.in` (`runtime`) y `*.verified.*` (`sdk`, `msbuild`). Es la objeción del juez de evidencia | Queda el texto original: «(la de `dotnet/runtime` y la base que propone GitHub [B41])» | Texto propuesto por el juez de evidencia en `04-Aprobacion-evidencia.md` (fila P-08) |
| P-14 ítem 24, consigna 1 de §11.9 | «cinco —los dos shebangs, `json.load`, `tomllib`, `JSON.parse` y la comparación de `.nvmrc`—» | E8-1, columna B: `hola.sh` da OK (con error en stderr); fallan cinco y son `saluda.py`, `json.load`, `tomllib`, `JSON.parse` y `.nvmrc`. Seis nombres bajo «cinco». Es la objeción del juez de costo-beneficio | §11.9 conserva la consigna 2, renumerada como 1. **§11 queda con una sola consigna**, contra las dos que anuncia §0.2 | Texto propuesto en `04-Aprobacion-costo-beneficio.md` (fila P-14, punto 2) |

## 4. Ajustes derivados (sin decisión nueva)

| ID | Dónde | Qué y por qué |
|---|---|---|
| A-1 | §8.2.2 | P-11 inserta un punto 2 y renumera los siguientes; la frase «no tiene el punto 2» pasa a «el punto 3», que es el mismo punto (actualización como PR). |
| A-2 | §5.5 | El extracto literal de EA-1 decía «21 archivo(s)»; tras P-16/P-22 L17 (dos plantillas nuevas) EA-1 informa 23. Se actualizó el número para respetar la regla de §0.3 (un bloque de salida es un extracto literal). |
| A-3 | §0, §3.4, §3.7, §9.2.2, §11.1, §11.2.8, A.4 | La verificación de P-12 pide `pieza` sólo en §1.1: siete apariciones fuera de §9 pasaron a «artefacto» (y «Ninguna pieza se construye sola» → «Ninguna parte…», donde «pieza» era «componente»). Mismo hallazgo, C1-54. |
| A-4 | Anexo C | Las filas renombradas por P-18 («Fin de línea (EOL)», «Artefacto») y las 23 nuevas se ubicaron en orden alfabético. |
| A-5 | Laboratorio, E8-3 | P-22 L15 agrega `devEngines` a `web/package.json`; con eso el caso «sin `engine-strict`» dejaba de mostrar el bundle construido con Node 24 que §11.2.5 sigue citando. La sección 3 quedó en tres casos (sin `devEngines` con y sin `engine-strict`, y el repo tal cual) y respalda las dos afirmaciones. |
| A-6 | Laboratorio, E8-5 | P-22 L14 cambia el `PY_IMAGE` por defecto a 3.12.15; el paso 3 de E8-5, que muestra la falla con la copia local 3.12.14, ahora la pasa con `--build-arg` explícito. La construcción sin `--build-arg` queda en `E8-5-por-componente-sin-build-arg.txt` (rc=0, la misma DLL `cf57904b…`). |
| A-7 | Laboratorio, N7 | Se volvieron a correr los siete experimentos de N7 con la compuerta modificada (L13): mismos resultados; sólo cambiaron los tiempos de V7-01 (1,57–2,55 s frente a 1,52–2,31 s). Se conservaron las salidas del 2026-10-07, que la guía cita (§10.2.7, «1,5–2,3 s»). |

## 5. Capa de origen: ajuste de R2-11, R2-12 y R2-14

La verificación 4 de la Revisión 2 manda cotejarlas con el texto final de las revisiones 2 de P-10 y P-16, y la condición de coherencia histórica dice que ninguna nota de origen puede quedar distinta del parche aprobado. No hubo revisión 2 de P-10 ni de P-16 (el encargo aprobó P-10 y P-16 de la revisión 1), así que:

- **R2-11** (N4) dice que la guía quedó con `'$(OutputType)' == 'Exe'`, que `WinExe` queda fuera sin aviso (J-I1) y que incorporarlo es pendiente del ciclo 2 (deuda D-1).
- **R2-12** (N0) remite a esa nota para `WinExe`.
- **R2-14** (N4) aclara que P-10 se aplicó sin revisión 2 y que la comparación `requested`/`resolved` figura en la guía como **[criterio]**, no como algo implementado (deuda D-2).

**Pasada de `grep` repetida (verificación 3 de la Revisión 2).** Con segmentos de 28 o más caracteres de cada texto viejo de P-03…P-17, buscados sin marcas en la capa de origen: 34 coincidencias. 15 tienen nota a menos de 25 líneas. Otras 16 son texto que el parche conserva (por ejemplo «Cada desarrollador lo hace una vez», la fila ESC-05 de N2 y de N4), vocabulario de la guía y no defecto del núcleo («pieza», el número de un punto de lista), o quedan cubiertas por una nota anclada en otra línea de la misma fila (R2-15 para N5 L237/L320, R2-17 para N8 L278/L503, R1-06 para N2 L235). Quedan **3 residuales sin nota**, que P-23 no incluye y que no se agregaron por no estar aprobadas: N7 L332 (ESC-01 y `core.hooksPath`, C1-06), N8 L558 (fila ESC-01 de §11.4, C1-06) y N8 L474 (bloque `docker buildx` de §11.5, C1-15). Pasan como deuda D-5. Guion: `aplicacion/grepsrc.py`.

## 6. Laboratorio (P-22)

| Fila | Cambio | Verificación | Resultado |
|---|---|---|---|
| L1 | `chmod +x` en los 20 `.sh` sin bit | `find Examples -name '*.sh' ! -perm -u+x` → 0 | ✔ |
| L2 | `Examples/README.md`: `bash correr-todo.sh` (N0, N2), `sh correr-todo.sh` (N1), `bash verificar.sh`, `bash eN-…/experimento.sh`; E2-1…E2-8 | Comandos coherentes con el shebang de cada script | ✔ |
| L3 | Identificador cp1252 en Node (`const año`) y en Razor (`@Çaudal`) | `e1-node*.txt`: `SyntaxError` (Node 20, 22, 24); `e1-razor-sdk8.txt`: `RZ1005` y `CS1056`; `e1-razor-sdk10.txt`: `RZ1005` y `CS0246` | ✔ |
| L4 | `moji.txt` en `e1-file.sh` | `file-5.46`: `Unicode text, UTF-8 text` | ✔ |
| L5 | `e2-migracion/squash-y-blame.sh`, llamado desde `run.sh` (caso 11) | `blame` vuelve a la autora con el SHA del squash: git 2.39.5 (imagen) y 2.47.3 (host, `e2-squash-y-blame-host.txt`) | ✔ |
| L6 | `e7-editorconfig-checker/run.sh` (E2-7) | 6 errores, rc=1, igual a la evidencia | ✔ |
| L7 | `e8-repos-de-referencia/relevar.sh` y su salida fechada (E2-8) | Seis repos con su SHA corto; no se re-corre | ✔ |
| L8 | `02-…/inspeccion-targets.sh` | `BuildWithNetFrameworkHostedCompiler`, `_IsDisjointMSBuildVersion … 18.9`, 94 versiones y 0 `8.*` | ✔ |
| L9 | Caso `pnpm-pm-on-fail/` en `03-…/correr.sh` | `10.18.0`, rc=0; con `--pm-on-fail=error`, `ERR_PNPM_BAD_PM_VERSION`, rc=1 | ✔ |
| L10 | `N3/correr-todo.sh` → `salidas/E3-1.txt` … `E3-6.txt` | 6 archivos | ✔ |
| L11 | E4-2 paso 5 en cuatro variantes, SDK 8 y 10 | Sin lock: `NU1603` (rc=1 como error); con lock: rc=0, `requested [8.0.2, )`, `resolved 9.0.0`, entrada completa con `contentHash` (condición del juez de evidencia) | ✔ |
| L12 | `e4-npm-lock/multiplataforma-pnpm-yarn.sh` | 26 variantes en cada lock (52 líneas en pnpm por packages + snapshots), una instalada | ✔ |
| L13 | `compuerta.sh`: `python3` y `check_text_policy.py` como prerrequisitos | `probar-prerrequisitos.sh`: el mensaje nombra la herramienta; N7 completo sin regresión (A-7) | ✔ |
| L14 | `PY_IMAGE` por defecto 3.12.15 por digest | Sin `--build-arg`: rc=0 (A-6) | ✔ |
| L15 | `devEngines.runtime` en `web/package.json` | E8-3 caso c: `EBADDEVENGINES` con Node 24 antepuesto (A-5); E8-1 y E8-2 sin cambios de resultado | ✔ |
| L16 | `e6-sbom-unificado/comando-de-la-guia.sh` | `E8-6-comando-de-la-guia.txt`: rc=0, `https://slsa.dev/provenance/v1`, `builder.id` vacío, materiales por digest (con `DOCKER_CONFIG` vacío: las credenciales del host están vencidas) | ✔ |
| L17 | `A-plantillas/repo/` desde el Anexo A | `aplicacion/anexoA.py`: 20 de 20 bloques iguales byte a byte (nuevos: `Directory.Build.targets`, `imagen/Dockerfile`) | ✔ |
| L18 | `A-plantillas/verificar.sh`: pasos 1b, 2b, 6 y 7; paso 5 adaptado a `build.dockerfile` | EA-1 rc=0, salida en `salidas/EA-1-plantillas.txt` | ✔ |

Además se actualizaron los `README.md` de N1, N2, N3, N4, N7, N8 y A-plantillas con una sección «Ampliaciones de la revisión (2026-10-09)». El `.gitignore` de `Examples/` ya excluía `bin/`, `obj/`, `node_modules/`, `.venv/` y `__pycache__/`.

## 7. Chequeos mecánicos finales (marco §5.6)

| Chequeo | Resultado |
|---|---|
| Índice ↔ encabezados | 20 entradas = 20 encabezados `##` en el mismo orden (incluye «Control de cambios»); 181 encabezados, 0 slugs duplicados |
| Anclas internas | 91 enlaces `](#…)`, 0 rotos |
| Enlaces relativos | 3 (`../Despliegue/`, `Examples/`, `Examples/README.md`), todos existen; 39 rutas `Examples/…` citadas, todas existen |
| Bloques de código y mermaid | Todos cerrados. Los 11 mermaid renderizan con `minlag/mermaid-cli` 12.0.0, sin «Syntax error» en el SVG |
| YAML y JSONC | 6 bloques YAML válidos (PyYAML 6.0.3), entre ellos los dos contratos nuevos; el `devcontainer.json` de §8.5 es JSONC válido |
| `[Bnn]` | 204 definidas, 204 citadas |
| IDs de experimento | 72 citados en el cuerpo, todos con fila; 73 IDs distintos en el Anexo E |
| Marcas | Sólo las cinco de §0.3, todas en negrita: fuera de código, 132 de 132 |
| Preguntas guía | 67 de 67 con *Aplica*, *No aplica* o *Criterio* en su respuesta |
| Privacidad | El `grep` de identificadores privados del contrato (R-PRIV, `00-Contrato-De-Entrada.md`) → 0 en la guía, en `Examples/` y en las notas nuevas de la bitácora |
| Terminología | `fix` → 0; `Final de línea` → 0; `pieza` sólo donde se dijo (A-3); vocabulario de marcas cerrado |

## 8. Deuda para el ciclo 2 (objeciones minoritarias no aprobadas y residuos)

| ID | Qué | Origen |
|---|---|---|
| D-1 | A.4b deja afuera, sin aviso, a los ejecutables `WinExe` (WinForms/WPF): restore rc=0 sin `packages.lock.json`. La condición medida que lo resuelve es `'$(OutputType)' == 'Exe' Or '$(OutputType)' == 'WinExe'`. | Juez de impacto (P-16, J-I1); nota R2-11 |
| D-2 | Con la política por defecto (con lock), `NU1603` desaparece y ninguna compuerta del laboratorio compara `requested` con `resolved`; la guía lo deja como **[criterio]** (§7.2.1) y la práctica §7.9.1 lo da como respuesta. | Jueces de costo-beneficio e impacto (P-10); nota R2-14 |
| D-3 | El recuadro «Desde Windows» de §0.4 propone correr los `docker run` desde Git Bash; MSYS puede reescribir `-v …:/w` y `-w /w`. Propuesta: WSL 2 para `docker run`, o `MSYS2_ARG_CONV_EXCL='*'` con su fuente. | Jueces de costo-beneficio e impacto (P-03, 3h) |
| D-4 | §11.5 dice que el comando «no pide `version=v1`» porque el default ya es v1 (lo confirma L16: `provenance/v1`), mientras §9.2.4 recomienda como **[criterio]** pedirlo explícito. Además, §11.9 tiene una sola consigna (§3). | Juez de costo-beneficio (P-14) |
| D-5 | Tres coincidencias de la pasada de `grep` sin nota de origen: N7 L332, N8 L558 (C1-06) y N8 L474 (C1-15). | §5 |
| D-6 | El bloque del paso 5 de §5.2.6 termina en `exit 1`: pegado en una terminal interactiva, la cierra. Propuesta: `if …; then …; fi`. | Juez de impacto (P-08, observación no bloqueante) |
| D-7 | Datos volátiles a re-resolver al cerrar la guía: `actions/attest` v4.2.2 por SHA, la etiqueta `sdk:8.0.425-bookworm-slim`, Node 24.21.0 en A.10. | `03-Parches.md` §5 |

## 9. P-24 · Apartamiento de Rule-Indexing, para el PO

No se escribió la ia-db (está fuera del alcance de escritura de esta corrida). Entrada propuesta para `LAB/Lab-Documentos.Documentacion/ia-db/indexes/00_MASTER-INDEX.md`, tabla «Inventario de guías»:

```markdown
| 16 | `Metodologia-Entorno-Desarrollo/` | Guía de estudio en un documento: caso + marco + mapa + 8 capítulos temáticos (estructura n.1–n.9) + hoja de ruta + anexos A–F, con laboratorio `Examples/` (73 experimentos) | 1 | ~3 400 | `GUIA-ENT-DEV` · 2026-10-09 | [10](10_Entorno-de-Desarrollo.md) |
```

En «Dos linajes», «Guías propias con aparato común (1–9)» pasa a «(1–9, 16)». Índice nuevo propuesto `10_Entorno-de-Desarrollo.md`: propósito (fijar, hacer cumplir y registrar el entorno por capas en .NET, Node.js y Python y su combinación), mapa de secciones (§1 caso; §2 ESC/CTX/ACT; §3 seis capas; §4–§11 por capa; §12 hoja de ruta), IDs estables (ESC-01…05, CTX-NET/NODE/PY/POLI, ACT-DEV/ARQ/OPS/REV, E0-1…EA-1, B01…B204), plantillas (Anexo A ↔ `Examples/A-plantillas/repo/`) y límites (Anexo F: nada corrido en Windows). La única corrección respecto de `03-Parches.md` es el tamaño: la guía tiene ahora 3391 líneas.

## 10. Versión

`version: 1.0.0-rc.1`, `last_review: 2026-10-09`; la apertura remite al **Control de cambios**, sección nueva al final de la guía con su entrada en el índice. `status` quedó en `borrador`, como manda P-01; el cambio a un estado de versión candidata no estaba en ningún parche aprobado y se deja al cierre del ciclo.
