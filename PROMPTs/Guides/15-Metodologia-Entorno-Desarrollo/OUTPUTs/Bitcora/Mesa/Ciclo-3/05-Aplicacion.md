# Mesa · Ciclo 3 · 05 — Aplicación

> Fecha: 2026-10-09. Rol: editor de aplicación (marco `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §5.6).
> Insumos: `03-Parches.md` (P-02…P-25 de §3–§5, más P-01 y P-19 de la «Revisión 2»), los diez `04-Aprobacion-*.md` / `04b-Aprobacion-*.md` y la forma ejecutable de los parches (`evidencia-auditor/simulacion/parches.py` y `evidencia-auditor/r2-p01-p19/r2.py`).
> Artefactos tocados: la guía `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (pasa de 1.0.0 a **1.1.0**), su laboratorio `Examples/` y la capa de origen (`Bitcora/Nucleos/`, `Bitcora/04-Integracion.md`, `Mesa/Ciclo-1/03-Parches.md`, `Mesa/Ciclo-2/01-Consolidado.md`).
> Todo lo que hizo la aplicación está en [`aplicacion/`](aplicacion/): scripts, instantáneas, registros de cada corrida y chequeos de cierre. No se tocó el prompt del PO ni `OUTPUTs/Metodlogia-Entorno-Desarrollo.md`. No hubo `git commit` ni `push`.

## 1. Resultado

- **Entraron los 25 parches aprobados** (P-01 y P-19 en su revisión 2). Hay **una regresión parcial**: la fila B224 de P-16 se revirtió (R-1, §3), y sus consecuencias se resolvieron con el arrastre que la revisión 2 de P-01 y P-19 ya preveía.
- Hay **dos ajustes de aplicación** que salen de condiciones de votos aprobatorios (§3):
  - AJ-1: commit y hash de la DLL del extracto de A.17, tomados de la corrida versionada de EA-1.
  - AJ-2: la cita [B220] en §11.2.2, que es la condición C-1 del voto de costo-beneficio sobre P-11.
- La guía queda en `version: 1.1.0`, `status: vigente`, con su fila en el control de cambios. Mide 3637 líneas y 55 261 palabras (`wc -w`; antes, 3605 y 54 267).
  - `sha256` antes: `a2b78179…c48a691fd`, la guía que juzgó la mesa. Después del lote, y antes de los ajustes: `eb7d1673…`, igual byte a byte a la simulación de la revisión 2. Final: ver `aplicacion/despues.sha256`.
- **Chequeos de cierre (§5)**: 87 comprobaciones de verificación, 86 OK y 1 FALLA derivada de R-1, declarada en §3. Además:
  - 0 anclas rotas; índice igual a los encabezados `##` (20 = 20).
  - 223 `[Bnn]` definidas, 223 citadas; 0 URL repetidas entre filas distintas.
  - 39 rutas `Examples/…` y 3 enlaces relativos, todos existentes.
  - 11 de 11 mermaid renderizan con mermaid-cli 12.0.0; 7 de 7 YAML válidos.
  - Privacidad: 0. Terminología: 0 apariciones de las cadenas retiradas.
- **Versión: 1.1.0, no 1.0.1.** La instrucción de versionado del ciclo pedía «ciclo 3 → 1.0.1». La mesa aprobó por unanimidad 1.1.0: P-01 y P-19 (revisión 2), 5/5, y el voto explícito de costo-beneficio, que acepta el **[criterio]** del auditor (`03-Parches.md` §9): el lote agrega un experimento (E5-8), fuentes nuevas y una fila de la ruta mínima, así que no es sólo un parche de erratas. Apliqué lo aprobado y dejo registrada la diferencia con la convención del ciclo. Si se quiere 1.0.1, el cambio toca tres lugares: el front matter, el recuadro de apertura y el control de cambios. **[criterio]**

## 2. Orden y condiciones de aplicación

El orden es el de la condición C-3 de costo-beneficio (`04-Aprobacion-costo-beneficio.md` §4). Encima van las condiciones de los votos aprobatorios.

| Paso | Qué se hizo | Evidencia |
|---|---|---|
| 1. Instantánea | Copia de la guía (`sha256 a2b78179…`, la que juzgó la mesa) y de `Examples/` (753 archivos con hash) antes del primer cambio. | `aplicacion/antes/`, `antes.sha256`, `antes-examples.sha256` |
| 2. P-24 | Once notas de solo agregado (O-1…O-11), cada una al pie del bloque que contiene su frase ancla. Antes se tomó una instantánea de los once archivos. | `aplicacion/p24.py`, `instantanea-origen/`, `p24-verif.txt` |
| 3. P-25 | L-01…L-07 en `Examples/`, cada uno con su corrida (§4.3). Los experimentos E5-8, E2-6 y E1-11 (Node) se corrieron y versionaron **antes** de aplicar P-08, P-05 y P-04, que los citan (condición C-2). EA-1 se corrió **una sola vez**, después de L-01 y L-01b. | salidas regeneradas en `Examples/` |
| 4. P-16 → P-01…P-22 → P-23 | Se aplicaron en ese orden sobre la guía real con `aplicacion/aplicar.py`, que usa `aplicacion/lote.py` (los ops de `parches.py` con P-01 y P-19 reemplazados por su revisión 2) y falla sin escribir si un ancla no aparece las veces declaradas. Después de cada parche corrió su verificación (`verif-inmediata.txt`). | `aplicacion/log-guia.txt` |
| 5. Verificación final | Los criterios de los 23 parches de la guía, otra vez, sobre la guía completa (`verif-final-antes-de-ajustes.txt`): 83 de 85 OK. Las dos fallas son A.17 y la URL de B224. | §3 |
| 6. Ajustes y regresión | AJ-1, R-1 y AJ-2 (§3), con `aplicacion/ajustes.py`. Verificación final: 87 comprobaciones, 86 OK (`verif-final.txt`). | §3 |
| 7. Cierre | Chequeos mecánicos (§5) y hashes de cierre. | `aplicacion/cierre/`, `despues.sha256`, `despues-examples.sha256`, `examples-cambiados.txt` |

Dos desviaciones de orden, sin efecto sobre el resultado:

- **P-25 antes que P-16.** C-3 pedía P-16 → P-25. P-16 sólo toca el Anexo D de la guía y P-25 sólo toca `Examples/`, así que no comparten nada.
- **Un solo pase, como en el ciclo 2.** Se aplicó todo en orden y sólo se tocó lo que siguió fallando en la verificación final. Las fallas inmediatas las cerraba siempre un parche posterior:

| Falla inmediata | La cierra |
|---|---|
| P-16: [B218]–[B223] sin citar | P-04, P-05, P-08, P-09, P-13, P-14, que las citan |
| P-01: fila vigente del control de cambios | P-19 |
| P-01: la segunda aparición de «las ampliaciones de la revisión» (Anexo E) | P-17 |
| P-06: `CheckSdkVulnerabilities` sin «SDK 11» en §10.2.6 y §10.3 | P-10 |
| P-08: «reconstrucción bit a bit» en §12 | P-12 |
| P-09: `ImagenDigest` en A.4 | P-13 |

Revertir en el momento habría sacado parches correctos (`verif-inmediata.txt`).

**Equivalencia con lo aprobado.** El mismo lote aplicado a una copia de la guía 1.0.0 en el scratchpad dio `sha256 eb7d1673…`, 55 279 palabras. Es el hash que declara la revisión 2 y que reprodujeron los cinco jueces en `04b`. La guía real, después del lote y antes de §3, dio el mismo hash (`aplicacion/despues-lote.sha256`).

**Condiciones de los votos aprobatorios, cumplidas:**

- C-2 (costo-beneficio y auditor): laboratorio antes que guía; EA-1 una sola vez; commit y DLL de A.17 desde esa corrida (AJ-1).
- C-4 (costo-beneficio): el digest de `sdk:8.0.425-bookworm-slim` siguió siendo `ec9c0a0d…` el día de la aplicación (`docker buildx imagetools inspect`, 2026-10-09 18:32 -03), así que A.10, O-1 y el Anexo F no cambian.
- Riesgo, P-01: el listado clasificado de **todas** las `**[no verificado]**` sin motivo se corrió sobre la guía real después de P-23. Da 20 marcas: 3 de metatexto, 17 de Windows/Visual Studio/Git Bash/ESC-01 y 0 fuera de clase. Quedó como chequeo permanente en `verif.py` (P-01).
- Riesgo, P-19: el arrastre 224/223 sigue la decisión de `checks.py` (R-1).
- Evidencia, P-25: el experimento y la fila de E5-8 dicen «tres bases Linux».
- C-1 (costo-beneficio, P-11): AJ-2.

## 3. Ajustes de aplicación y regresión

| ID | Parche | Qué falló | Qué se hizo | Por qué no excede lo aprobado |
|---|---|---|---|---|
| AJ-1 | P-13 (A.17) | El extracto de A.17 trae `commit=ab2a6d36…` y `out/App.dll=fa6a50ec…`, que son de la corrida del auditor (`x1-ea1-propuesto/salida.txt`). La corrida versionada de EA-1 da `commit=386d768e…` y `out/App.dll=c7ab264a…`. El commit del repo de juguete cambia en cada corrida y la DLL lo incrusta (Source Link). Las demás líneas de la salida son iguales a las de X1. | Se reemplazaron esas dos cadenas por las de `Examples/A-plantillas/salidas/EA-1-plantillas.txt`. | Lo piden la verificación de P-13 («commit y hash de la DLL se copian de esa corrida»), la condición C-2 y la tabla L-01b de P-25. |
| R-1 | P-16 (fila B224), **regresión parcial** | Verificación de P-16: «0 URL repetidas entre filas distintas». La fila B224 repite la URL de B62 (`…/release-metadata/releases-index.json`). Es el defecto que señalaron los jueces de evidencia (§2.1) y de impacto (J-I6) en minoría. | Se revirtió la fila B224. Se aplicó el **arrastre** que la revisión 2 escribe para «P-16 sin B224»: «223 fuentes» y «B194–B223» (P-01, ops 2 y 5) y «B218–B223» (P-19). El mismo arrastre se extendió a la op 1 de P-16 (la apertura del Anexo D: «B194–B223») y a las dos citas `[B224]` de P-18 op 5, que quedan como `[B62]` y `[B61]`. Esas dos fuentes ya respaldaban el dato. | La revisión 2 (aprobada 5/5) prevé esta rama y la deja a «el conteo de `checks.py` sobre la guía real, después de P-16». Las dos extensiones son la misma regla aplicada a texto del propio lote, y coinciden con el remedio del juez de impacto (`04-Aprobacion-impacto.md`, P-16 y P-18). No se agregó contenido: la propuesta del juez de evidencia (B224 = NETSDK1238) **no** se aplicó. |
| — | P-18 (derivada de R-1) | La verificación numérica de P-18 (≥ 12 citas `[Bnn]` en «Datos volátiles») da 11. Antes de R-1 daba 13: las dos citas que faltan son las de B224. | **No se revierte P-18.** Se agregó una comprobación sustantiva: los 13 datos volátiles tienen cada uno su fuente (`[Bnn]`, experimento o sección), y da OK. | El umbral ≥ 12 lo midió el auditor contando B224 dos veces. Revertir P-18 op 5 dejaría los datos volátiles sin fuente, que es justamente lo que el parche corrige. La falla queda registrada con R-1, no oculta. **[criterio]** |
| AJ-2 | P-11 (§11.2.2) | — (no es una falla). La condición C-1 del voto APLICAR de costo-beneficio pide citar [B220] en «desde 3.15 usa UTF-8 estricto [B29][B205]». El juez de evidencia pidió lo mismo. | «…estricto [B29][B205][B220]». | Es una cita, sin prosa. Sin ella, uno de los tres votos que aprueban P-11 quedaba sin su condición. Verificación: `grep -c 'estricto \[B29\]\[B205\]\[B220\]'` → 1. |

Script: `aplicacion/ajustes.py` (AJ-1 y R-1 en una corrida; AJ-2 con `--aj2`). Todo se revierte con `aplicacion/antes/`.

**La regresión vuelve a auditoría.** El hallazgo que P-16 cerraba con la fila B224 (la reconsulta del índice de versiones de .NET del 2026-10-09; parte de C3-05 y C3-50) queda **abierto como `regresión`** para el ciclo siguiente. Hay dos remedios propuestos en minoría:

- **Evidencia**: B224 pasa a ser NETSDK1238 («available in .NET 11 Preview 5 and later»), la fuente que hoy falta para «desde el SDK 11», y la reconsulta se anota en la fila de B62.
- **Impacto**: no hay B224, y la fila de B62 lleva «reconsultado el 2026-10-09 (8.0: `eol-date` 2026-11-10; 10.0: `latest-sdk` 10.0.401)».

Mientras tanto, la guía no afirma nada sin fuente: los datos del índice se citan a [B62] (consultada el 2026-10-07) y la fecha de fin de soporte a [B61].

## 4. Changelog: hallazgo → veredicto → parche → verificación → versión

### 4.1 Parches sobre la guía

«Votos» cuenta los `APLICAR` de la primera vuelta (`04-Aprobacion-*.md`; jueces: coherencia histórica, costo-beneficio, evidencia, impacto y riesgo) y, para P-01 y P-19, los de la segunda (`04b-*`). «Inmediata» es la verificación justo después del parche; «Final», sobre la guía completa (`verif-final.txt`). Todos entran en la versión **1.1.0**.

| Parche | Hallazgos | Votos | Ops | Inmediata | Final |
|---|---|---|---|---|---|
| P-01 (rev. 2) | C3-34, C3-35, C3-40, C3-41, C3-01 | 5/5 (2.ª vuelta) | 15 | 2 fallas, que cierran P-19 y P-17 | 8 OK (cifras con el arrastre de R-1: 223/74) |
| P-02 | C3-46 | 5/5 | 1 | OK | 1 OK |
| P-03 | C3-35, C3-30 | 5/5 | 3 | OK | 3 OK |
| P-04 | C3-53, C3-33, C3-31, C3-37 | 5/5 | 3 | OK | 5 OK |
| P-05 | C3-16, C3-20, C3-25, C3-48 | 4/5 (impacto: MEJORAR, op 6) | 9 | OK | 7 OK |
| P-06 | C3-13, C3-15, C3-49 | 4/5 (evidencia: MEJORAR, cita [B58]) | 4 | 1 falla, que cierra P-10 | 4 OK |
| P-07 | C3-24, C3-35 | 5/5 | 2 | OK | 2 OK |
| P-08 | C3-01, 02, 03, 05, 06, 07, 10, 23, 35 | 3/5 (evidencia e impacto: «tres sistemas operativos») | 14 | 1 falla, que cierra P-12 | 6 OK |
| P-09 | C3-12, C3-03, C3-06, C3-05, C3-27, C3-51, C3-30 | 5/5 | 9 | 1 falla, que cierra P-13 | 5 OK |
| P-10 | C3-11, 13, 15, 18, 19, 26, 06, 40 | 4/5 (evidencia: MEJORAR, cita [B58]) | 11 | OK | 5 OK |
| P-11 | C3-06, 16, 18, 22, 28, 42, 48, 52 | 3/5 (costo-beneficio con C-1; evidencia y coherencia: MEJORAR) | 17 | OK | 4 OK (incluye C-1, AJ-2) |
| P-12 | C3-02, 03, 04, 05, 07, 14, 20, 29 | 4/5 (impacto: MEJORAR, E3-1/E0-2) | 6 | OK | 3 OK; YAML 7/7 en contenedor (§5) |
| P-13 | C3-02, 05, 08, 09, 11, 12, 16, 17, 19, 21, 22, 26, 39, 44, 47 | 5/5 | 21 | 1 falla (A.17) | 4 OK, después de AJ-1 |
| P-14 | C3-06, C3-21 | 5/5 | 3 | OK | 3 OK |
| P-15 | C3-43 | 5/5 | 5 | OK | 1 OK |
| P-16 | C3-05, 16, 21, 27, 33, 38, 45, 50 | 3/5 (evidencia e impacto: B224) | 5 | 8 fallas: 7 las cierran citas posteriores, 1 es la URL de B224 | 9 OK, después de **R-1 (regresión parcial)** |
| P-17 | C3-01, 16, 34, 37 | 4/5 (impacto: MEJORAR, E4-4 y §1.2) | 4 | OK | 3 OK |
| P-18 | C3-05, 13, 36, 38, 45 | 4/5 (evidencia: MEJORAR, [B224]) | 5 | OK | 2 OK, 1 FALLA derivada de R-1 (§3) |
| P-19 (rev. 2) | C3-01…C3-53 | 5/5 (2.ª vuelta) | 3 | OK | 5 OK (rango B218–B223, arrastre de R-1) |
| P-20 | C3-35 | 4/5 (impacto: MEJORAR, op 2) | 2 | OK | 2 OK |
| P-21 | C3-35 | 4/5 (impacto: MEJORAR, op 2) | 5 | OK | 2 OK |
| P-22 | C3-35 | 5/5 | 4 | OK | 1 OK |
| P-23 | C3-35 | 3/5 (coherencia y riesgo: MEJORAR en la 1.ª vuelta; riesgo da la objeción por atendida con P-01 rev. 2, `04b-Aprobacion-riesgo.md` §3) | 1 | OK | 1 OK |

### 4.2 Capa de origen (P-24)

Votos: 4/5 (coherencia: MEJORAR, rótulo de O-9). Formato: párrafo citado al pie del bloque de la frase ancla. Para O-4, el ancla está dentro de un bloque `xml`, y la nota va después de su cierre.

| Nota | Archivo | Línea de la nota | Verificación |
|---|---|---|---|
| O-1 | `Nucleos/N5-entornos-en-contenedores.md` | 116 | `diff` contra la instantánea: 2 líneas `>`, 0 `<` |
| O-2 | `Nucleos/N7-compuertas-y-gobierno.md` | 156 | ídem |
| O-3 | `Nucleos/N2-politica-de-texto-y-remediacion.md` | 147 | ídem |
| O-4 | `Nucleos/N6-procedencia-y-trazabilidad.md` | 357 | ídem |
| O-5 | `Nucleos/N8-integracion-poliglota.md` | 179 | ídem |
| O-6 | `Nucleos/N1-codificacion-y-finales-de-linea.md` | 183 | ídem |
| O-7 | `Nucleos/N4-congelamiento-de-dependencias.md` | 103 | ídem |
| O-8 | `Nucleos/N3-fijacion-del-toolchain.md` | 95 | ídem |
| O-9 | `04-Integracion.md` | 121 | ídem |
| O-10 | `Mesa/Ciclo-1/03-Parches.md` | 1308 (al final) | ídem |
| O-11 | `Mesa/Ciclo-2/01-Consolidado.md` | 146 (al final) | ídem |

Notas encontradas por `Corrección mesa ciclo 3`, `Corrección mesa ciclo 2 y 3` o `Nota de solo agregado (ciclo 3`: **11**. R-PRIV en las notas: **0** (`aplicacion/p24-verif.txt`). La nota O-1 dice «tres distribuciones» y no «tres sistemas operativos», así que R-1 y la objeción de alcance de P-08 no la alcanzan. La objeción de coherencia sobre el rótulo de O-9 («ciclo 2 y 3») no tuvo mayoría y queda como observación (§6).

### 4.3 Laboratorio (P-25)

Votos: 4/5 (coherencia: MEJORAR, por el saldo de prosa; impacto: APLICAR con la condición del saldo, §6). Corridas del 2026-10-09.

| # | Cambio | Corrida | Resultado |
|---|---|---|---|
| L-01 | Seis plantillas de `A-plantillas/repo/` (`Directory.Build.props`, `imagen/Dockerfile`, `.github/CODEOWNERS`, `.github/workflows/ci.yml`, `tools/ci/registrar-entorno.sh`, `.editorconfig`), copiadas de `x1-ea1-propuesto/repo/` | `diff -rq` contra X1 y `anexoA.py` contra la guía final | `diff` vacío; **TODO IGUAL**, 22 de 22 bloques (`cierre/anexoA-salida.txt`) |
| L-01b | `A-plantillas/verificar.sh` = `x1-ea1-propuesto/verificar.sh` | `bash verificar.sh > salidas/EA-1-plantillas.txt`, rc=0, una sola vez | 1c: `3 violación(es)` → `0`; 8, sin locks: `[n/a]` npm y uv, `VERDE`, rc=0; 9: `commit=386d768e…`, `out/App.dll=c7ab264a…`; 9b: `registro: no existe .github/workflows/ci.yml`, rc=1, y con `WORKFLOW_FILE`, la línea `imagen=`; 10: `"outcome":"success"`. Frente a `x1/salida.txt` sólo difieren el commit y la DLL (AJ-1) |
| L-02 | `N5-…/e8-capa4-y-artefacto/` (nuevo: `experimento.sh` con el encabezado del laboratorio y «tres bases Linux», `build-en.sh`, `proy/`); fila E5-8 y comando en el README de N5 | `sh e8-capa4-y-artefacto/experimento.sh > salidas/E5-8-capa4-y-artefacto.txt` | `dll 9815b804e89acc33   pdb 39c56299b47eef9f` en Debian 12, Ubuntu 24.04.5 y Debian 13 con 8.0.425; control 10.0.400: `dll 7cd2a836de83b37e`; rc=0. Igual a X5 |
| L-03 | `N2-…/e6-plantillas-dotnet/run.sh` + el bloque de `x2/bloque-e6.sh` (el resultado es igual byte a byte a `run-propuesto.sh`) | Sólo el bloque E2-6 de `correr-todo.sh` (los dos SDK por los digests de N2), para no regenerar E2-1…E2-5 y E2-7 | `diff` contra la salida previa: **sólo agrega** 14 renglones por SDK. SDK 10: `s.slnx con BOM` → `sin BOM`; ítems con BOM; `Comp.razor sin BOM` después de `dotnet format whitespace` |
| L-03b | Fila E2-6 del README de N2, con el texto del parche | — | El README nombra lo que muestra la salida |
| L-04 | `N1-…/e1-shebang-node.mjs` (nuevo), `salidas/e1-shebang-node.txt` y su línea en `correr-todo.sh` | Sólo esa línea, con `node:24-bookworm-slim` | Node v24.21.0: `con-bom.sh` da `"status":0` y `not found` en stderr; `crlf.sh` da `ENOENT`. Igual a X3 |
| L-05 | README de N4, fila E2: «con `NU1603`; con lock, sin aviso» y la declaración de que las salidas conservan el rótulo anterior; `e2-…/run.sh` l.42: «la línea de A.4» | — | `grep -c 'sin advertir' README.md` → 0 |
| L-06 | `N7-…/compuerta/ci-compuerta.yml` l.1 y la fila del hook en el README de N7 | — | Los README nombran sólo archivos que existen |
| L-07 | `Examples/README.md`, sección «Ampliaciones del ciclo 3 (2026-10-09)» | — | Nombra sólo archivos que existen |

N8 no se tocó. En total cambiaron 25 archivos de `Examples/`: 7 nuevos y 18 modificados, ninguno borrado (`aplicacion/examples-cambiados.txt`). `Examples/.gitignore` (bin/, obj/, node_modules/, .venv/, __pycache__/) no cambió. Los `bin/` y `obj/` que existen están bajo los `work/` de N2, que ya ignoraba el laboratorio.

## 5. Chequeos de cierre

| Chequeo | Herramienta | Resultado |
|---|---|---|
| Índice ↔ encabezados, anclas | `aplicacion/checks.py` (el del ciclo 2) | 183 encabezados, 183 anclas, 92 enlaces internos, **0 rotos**; índice en orden (20 = 20) |
| Enlaces relativos y rutas `Examples/` | `checks.py` | 3 enlaces relativos, todos existentes; 39 rutas `Examples/…`, 0 inexistentes |
| Bibliografía | `checks.py` y `verif.py` (P-16) | 223 definidas = 223 citadas; 0 URL repetidas entre filas distintas |
| Experimentos | `checks.py` | 72 IDs en el cuerpo, todos con fila; 66 filas en el Anexo E, que se expanden a 74 |
| Bloques de código | `checks.py` | todos cerrados; 11 mermaid, 7 YAML |
| Mermaid | `minlag/mermaid-cli` 12.0.0 en contenedor | 11 de 11 renderizan con rc=0; ningún SVG contiene «Syntax error» (`cierre/mermaid.txt`) |
| YAML | PyYAML 6.0.3 en `python:3.12-slim` | 7 de 7 válidos (`cierre/yaml.txt`) |
| Anexo A ↔ laboratorio | `anexoA.py` | TODO IGUAL, 22 bloques (`cierre/anexoA-salida.txt`) |
| Privacidad | `grep -ciE 'GDA\|SGM\|{organización-del-SDD-B}\|BotonPanico\|oordenada'` | guía 0; `Examples/` 0 archivos; notas de P-24 0 |
| Terminología | `grep -cF` de las cadenas retiradas | `ImagenDigest`, `**[no verificado]** (requiere Windows)`, `npm y pip`, `reconstrucción bit a bit`, `Práctica de §3`, `las ampliaciones de la revisión`, `CheckSdkVulnerabilities=true`, «porque las herramientas del SDK lo reponen», `B224`: **0** cada una. `verificar.sh` aparece en §0.4, §10.2, §11.1 (el árbol de la solución de N8), §11.2, §11.5, Anexo A y Anexo E; no en §11.2.9 ni en §11.4 |
| Marcas | conteo fuera de código | `[criterio]` 85, `[no verificado]` 36, `[observado]` 12, `[interpretación]` 5; *Aplica* 61 |
| Verificación de los parches | `aplicacion/verif.py` | 87 comprobaciones, 86 OK, 1 FALLA (P-18, ≥ 12 citas; derivada de R-1, §3) |

Todo en `aplicacion/cierre/` (`checks.txt`, `mermaid.txt`, `yaml.txt`, `anexoA-salida.txt`, `privacidad-terminologia.txt`) y en `aplicacion/verif-final.txt`.

## 6. Saldo de prosa y deuda que queda

**Saldo de prosa.** Medido con la misma función de `simulacion/gen.py` sobre la guía 1.0.0 y la final:

- Prosa propia: 43 604 → 44 135, **+531** (+1,2 %).
- Evidencia y plantillas: 10 663 → 11 126, +463.
- `wc -w`: 54 267 → 55 261.

Es el +531 que previeron la revisión 2 y el juez de costo-beneficio. R-1 y AJ-2 no mueven la prosa. Como pidió el juez de coherencia histórica, lo registro con estas palabras: **la mayoría de la mesa (4 de 5 votos `APLICAR` sobre P-25, el parche que declara el cierre del lote, y 25 de 25 de costo-beneficio) admitió el saldo positivo como voto explícito frente a C2-36. No es un «costo aceptado» sin nombre.** El párrafo 1.1.0 del control de cambios no dice que la versión comprime.

**Lo que queda abierto para el ciclo siguiente:**

1. **Regresión R-1** (§3): la reconsulta del índice de .NET sin fila propia. Los remedios en minoría son los de evidencia (NETSDK1238 como fuente nueva) y de impacto.
2. **Pasada de compresión del editor de cierre (C3-Q09).** Es la condición de cierre de ciclo que puso el juez de impacto: llevar la prosa a ≤ 0 respecto de 1.0.0 (≈ 531 palabras), empezando por los candidatos medidos de `03-Parches.md` §2. No la hace este rol, porque no estaba en el lote aprobado. Si no alcanza sin quitar información, el resto se declara como deuda con su cifra.
3. **Observaciones de los votos `MEJORAR_PLAN` en minoría que no entraron** (el lote se aplicó como fue aprobado):
   - Evidencia: «desde el SDK 11» se cita a [B58], que no lo dice (P-06, P-10); la fuente es NETSDK1238.
   - Evidencia e impacto: «en tres sistemas operativos» en la definición de §8.2.2 (P-08); E5-8 midió tres distribuciones Linux. La guía no dice en ese párrafo que Windows no se midió. El laboratorio y la nota O-1 sí lo dicen.
   - Impacto: la op 6 de P-05 y la línea `salidas` del contrato de §12, sobre el workflow que se activa al llegar a `main` (J-I3).
   - Impacto: la respuesta de la Práctica de §12 atribuye a E3-1 un mensaje que está en E0-2 (J-I2, deuda desde el ciclo 2).
   - Impacto: dos IDs de la línea de fechas del Anexo E (E4-4 y «§1.2», J-I8).
   - Impacto: la apertura del Anexo A dice «cada plantilla dice qué paso la comprueba», y A.14–A.16 no lo dicen (J-I5).
   - Impacto: la respuesta de §10.6 perdió «sin `python3` el verificador no corre» (J-I9).
   - Coherencia: P-11 op 14, la frontera A con runner frente a C3-07.
   - Coherencia: el rótulo «ciclo 2 y 3» de O-9.
4. **Sin host Windows**: la receta de A.11 y `paths` en Visual Studio siguen **[no verificado]**.

## 7. Supuestos registrados

- Fecha de trabajo: 2026-10-09, la del sistema, la misma de los votos y de las corridas del laboratorio. La línea de fechas del Anexo E (P-17) sigue siendo cierta, porque E5-8, E2-6 ampliado, E1-11 con Node y EA-1 corrieron ese mismo día.
- «Aprobado» = el conjunto que pasó la orquestación del ciclo: P-02…P-25 de §3–§5 y la revisión 2 de P-01 y P-19. Las condiciones que acompañan votos `APLICAR` (C-1…C-4 de costo-beneficio y las de riesgo y evidencia) se cumplieron como parte de la aplicación. Los remedios de votos `MEJORAR_PLAN` en minoría no se aplicaron (§6).
- La versión es la que fijó la mesa (1.1.0), no la de la convención del ciclo (1.0.1). Ver §1.
