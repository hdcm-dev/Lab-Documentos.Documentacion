# Mesa · Ciclo 3 · 04 — Aprobación: juez de evidencia

> Fecha: 2026-10-09. Rol: juez de evidencia de la mesa de aprobación (marco `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §5.5). La pregunta que respondo es si cada parche está probado al nivel que declara. Abrí el ancla en la guía, revisé la evidencia y volví a consultar las URL nuevas.
> Insumo: `03-Parches.md` (P-01…P-25). Guía bajo revisión: 1.0.0, sha256 `a2b78179…` (coincide con la que declara el auditor).
> Vocabulario: `APLICAR` | `MEJORAR_PLAN` (el hallazgo vale y el parche no, con una objeción concreta) | `NO_APLICAR` | `ESCALAR` (sólo ante los 7 disparadores de §6).

## 1. Qué verifiqué por mi cuenta

**Simulación reproducida.** Copié `gen.py` y `parches.py` al scratchpad y los corrí sobre la guía real (`GUIA=… python3 -I gen.py`). Resultado: `fallas=0`. La guía parcheada sale con el mismo sha256 `e65a650b…` que la del auditor, y los Δ son idénticos (prosa +493, evidencia +481, `wc -w` 54 267 → 55 241). El texto de §3 de `03-Parches.md` coincide con `parches-md.txt` y sólo difiere en líneas en blanco. **Lo que se lee en el documento es lo que se aplica.**

**Experimentos del auditor y de los informes, leídos en sus salidas:**

| Ítem | Archivo | Lo que comprobé |
|---|---|---|
| X1 EA-1 propuesto | `evidencia-auditor/x1-ea1-propuesto/salida.txt` | paso 1c `3 violación(es)` → `0`; paso 8 `[n/a] grafo npm/uv`, `VERDE`, rc=0; paso 9 `commit=ab2a6d36…`, `sha256 out/App.dll=fa6a50ec…`; 9b `registro: no existe .github/workflows/ci.yml`, rc=1; rc final 0 |
| X2 E2-6 ampliado | `x2-e2-6-ampliado/salida.txt` | SDK 10.0.400: `s.slnx con BOM` → `sin BOM` después de `dotnet sln add`; `.csproj` conserva el BOM; `Items/Clase.cs`, `IFace.cs` y `Comp.razor` con BOM; `Comp.razor sin BOM` después de `dotnet format whitespace` |
| X3 Node | `x3-shebang-node/salida.txt` | Node v24.21.0, `spawnSync`: `con-bom.sh` da `"status":0` y `﻿#!/bin/sh: not found`; `crlf.sh` da `ENOENT` |
| X4 guardián | `x4-guardian/salida.txt` | con el árbol sucio, el aviso y `la terminal sigue abierta`; con el árbol limpio sin remoto, `git pull` falla y no corre lo que sigue |
| X5 E5-8 + imagetools | `x5-e5-8-capa4/salida.txt`, `imagetools.txt` | `dll 9815b804e89acc33 pdb 39c56299b47eef9f` en Debian 12, Ubuntu 24.04.5 y Debian 13 (glibc 2.36/2.39/2.41) con 8.0.425; control 10.0.400 `7cd2a836…`; `sdk:8.0.425-bookworm-slim` es un índice `ec9c0a0d…` con amd64, arm/v7 y arm64; `78235e09…` también es un índice de tres plataformas |
| X6 CODEOWNERS | `x6-codeowners/salida.txt` | locks, `Directory.Build.*`, `nuget.config`, `.npmrc`, `pyproject.toml`, `.nvmrc` y `.python-version` → `@org/arquitectura`; `.githooks/`, `.pre-commit-config.yaml`, `imagen/` y `tools/ci/` → `@org/plataforma` |
| X7 fechas | `x7-fechas/salida.txt` | 46 salidas del 2026-10-07 y 39 del 2026-10-09; la lista coincide con la línea nueva del Anexo E (P-17) |
| `CheckSdkVulnerabilities` | `evidencia-senior-dotnet/checksdkvuln.txt` | en 8.0.425 y 10.0.400, `MSB4057: The target "_CheckForSdkVulnerabilities" does not exist`; en 11.0.100-rc.1 el target existe |
| `dotnet sdk check` | `evidencia-abogado-del-diablo/03-sdk8-eol/salida.txt` | `8.0.425 … .NET 8.0 is going out of support soon.`; índice: `8.0 … eol: 2026-11-10`, `10.0 latest-sdk: 10.0.401` |
| E8-1 | `Examples/N8-…/salidas/E8-1-choque-de-convenciones.txt` L21 | `saluda.py` con BOM: `FALLA rc=2` |
| Python 3.15 | `Informe-adhoc-AH-001.md` | `-X utf8` en 3.12.14: `UnicodeDecodeError: 'utf-8' codec can't decode byte 0xf1` |
| N8 frente a A.10 | `diff` entre el Dockerfile de N8 y el de `x1/repo/imagen` | cambian `NODE_IMAGE` y la referencia del SDK, y N8 no instala `EditorConfig`. Las salidas de N8 dan `sdk 8.0.425`. P-13 op. 9 lo describe bien |
| Anclas de P-24 | `Nucleos/N1…N8`, `04-Integracion.md` | las nueve anclas de nota existen una sola vez (N5 L114, N7 L154, N2 L145, N6 L352, N8 L177, N1 L181, N4 L101, N3 L93, 04 L119) |

**Fuentes vueltas a consultar el 2026-10-09:**

| Fuente | Resultado |
|---|---|
| B218 GitHub, retención | Confirmada: «retained for 90 days»; públicos entre 1 y 90 días; privados entre 1 y 400 |
| B219 Python en Windows | Confirmada: `python3` «is not meant to be widely used or recommended»; para varias versiones, «the recommended command is `py`» |
| B220 `os`, modo UTF-8 | Confirmada: «they still use the strict error handler by default»; «Changed in version 3.15: Python UTF-8 mode is now enabled by default» |
| B221 `gh attestation verify` | Confirmada para `--signer-workflow`, `--source-ref` y la obligación con *reusable workflows*. Que `-R` solo «acepta cualquier workflow y rama» es una lectura razonable de «for stronger security guarantees… validate the signer workflow», no una frase literal |
| B222 `dotnet/aspire` `.editorconfig` | Confirmada: `[*.{razor,cshtml}] charset = utf-8-bom` y `[*] charset = utf-8` |
| B223 uv 0.13.0 | Confirmada: publicada el 2026-10-09; «The default stable Python version has changed from 3.14 to 3.15» |
| B56 `global.json` | Confirmada: «In CI… you typically want to specify an acceptable range»; con lock files, `disable`; `paths` y `errorMessage` disponibles desde el SDK de .NET 10, con el ejemplo `[ ".dotnet", "$host$" ]` |
| B58 «Select the .NET version» | **No dice desde qué SDK existe `CheckSdkVulnerabilities`**: sólo describe la propiedad y NETSDK1238/1239/1240 |
| NETSDK1238 (learn.microsoft.com/en-us/dotnet/core/tools/sdk-errors/netsdk1238) | Es la fuente oficial que falta: «This check is available in .NET 11 Preview 5 and later versions» |
| B29 PEP 686 | No habla del manejador estricto. Eso lo dice B220 |

## 2. Defectos de evidencia en los parches

1. **B224 repite la URL de B62** (`…/release-metadata/releases-index.json`). La verificación de P-16 promete «0 URL repetidas entre filas distintas», que es justamente la regla que P-16 aplica a B217 (C3-50). En la guía parcheada hay una URL duplicada (`uniq -d`). La promesa de P-16 no se cumple.
2. **«Desde el SDK 11» se apoya en [B58], que no lo dice** (P-06 op. 1 y P-10 op. 5). El dato es correcto y la evidencia E1 lo sostiene, pero la guía cita una fuente que no lo contiene. NETSDK1238 sí lo dice.
3. **«UTF-8 estricto» se apoya en [B29][B205]** (P-11 op. 2), y ninguna de las dos lo dice. B220, que P-04 ya cita para lo mismo, sí lo dice.
4. **«En tres sistemas operativos»** (P-08 op. 3) exagera lo que mide E5-8. Son tres distribuciones Linux (Debian 12, Ubuntu 24.04, Debian 13). Windows y macOS no se midieron. La nota O-1 de P-24 lo dice bien; el texto de la guía no.
5. **La fila 1.1.0 del control de cambios anuncia una «Práctica de §3»** (P-19 op. 3), y el propio `03-Parches.md` §1.2 y §8 dice que esa Práctica **no entra**. En la guía parcheada no existe. El registro de cambios afirma algo que no ocurrió.

## 3. Votos

| Parche | Voto | Fundamento |
|---|---|---|
| P-01 | APLICAR | Las cifras 224 y 74 salen de `checks.py` sobre la guía parcheada, que reproduje. La fila E0-6 existe. La regla de que «[no verificado]» sin motivo quiere decir Windows es un cambio de convención y no pide evidencia. Capa: la guía. Con el remedio de P-16 que propongo, el 224 sigue valiendo. |
| P-02 | APLICAR | La fila remite a pasos de §12 cuyo responsable es ACT-OPS. Es un dato estructural que se comprueba con la tabla de §12. |
| P-03 | APLICAR | Es compresión. Lo quitado vive en §8.2.1, con su evidencia, y el ancla `#821-…` resuelve (0 enlaces rotos). Las filas A.17 y A.18 existen en el Anexo A. |
| P-04 | APLICAR | `UnicodeDecodeError` ≥ 3.15 queda probado por B220 (frase literal, re-consultada) y por el E1 de AH-001 con `-X utf8`. La E8-1 de rc=2 está en la salida versionada (L21). El `child_process`/E1-11 Node queda con X3. La fila nueva en la tabla de E1-11 depende de L-04: la salida tiene que versionarse antes de aplicar, como pide la condición de §8 del auditor. |
| P-05 | APLICAR | Lo sostiene X2 (`.slnx` sin BOM con 10.0.400; ítems con BOM; `format` no repone el BOM del `.razor`), B222 (aspire confirmada; aspnetcore ya estaba citada) y X4 (el guardián sin `exit`). «Las de Visual Studio, [no verificado]» está bien rotulado. Depende de L-03 (E2-6 versionado). |
| P-06 | MEJORAR_PLAN | Objeción concreta: «desde el SDK 11» cita [B58], que no lo dice (lo confirmé el 2026-10-09). Remedio: citar NETSDK1238 («available in .NET 11 Preview 5 and later»), consultada el 2026-10-09, en el lugar que libera el remedio de P-16 (ver P-16). La celda queda así: «desde .NET 11 (Preview 5) [B224]». El resto del parche está probado: B56 re-consultada (rango en CI, `disable` con lock, `paths`/`errorMessage` desde .NET 10, «$host$»), «[observado]» 8.0.425/10.0.400 por `checksdkvuln.txt` y lo de uv frente a pip. |
| P-07 | APLICAR | `restore src/App --locked-mode` rc=0 (desarrollador-04), y la falla en la raíz (MSB1003) es coherente con no tener `.sln` en la raíz. La pregunta acortada remite a §3.5. |
| P-08 | MEJORAR_PLAN | Objeción concreta: «en tres sistemas operativos y tres rutas» exagera E5-8, que midió tres **distribuciones Linux**. Un lector puede extenderlo a una estación Windows, que no se midió (y donde además entra la capa 1 por `autocrlf`). Remedio: «en tres distribuciones Linux (Debian 12 y 13, Ubuntu 24.04) y tres rutas», igual que O-1. Lo demás está probado: imagetools (X5) para el índice multiplataforma, B218 re-consultada para la retención (90 días; 1–400 en privados) y «detecta/impide» con remisión a §10.2.7. El rótulo «[interpretación]» para lo nativo es correcto: nadie lo midió. |
| P-09 | APLICAR | Que un `AssemblyMetadata` con el digest cambia el hash lo prueba `evidencia-senior-dotnet/imagendigest.txt` (tres hashes) y es «[observado] (SDK 8.0.425)». `--signer-workflow`, `--source-ref` y la obligación con *reusable workflows* están literales en B221. «Sólo con -R acepta cualquier workflow y rama» es una lectura fiel de que esas banderas son opcionales («Enforce that…»), no una frase textual. No bloqueo, pero el aplicador puede escribir «-R solo no fija workflow ni rama». «Mismo SDK (E5-8)» y lo nativo como [interpretación], bien. |
| P-10 | MEJORAR_PLAN | Objeción concreta: la op. 5 (tabla de §10.3) vuelve a citar [B58] para «desde el SDK 11». Remedio: el mismo de P-06, [B224] = NETSDK1238. El resto está probado: E3-7 para la etiqueta flotante; `going out of support soon` en `03-sdk8-eol`; el límite «sin lock» con EA-1 paso 8 (X1); `Cowardly refusing…` con pre-commit 4.6.2 (voto de evidencia del ciclo 3); los dueños con X6. |
| P-11 | MEJORAR_PLAN | Objeción concreta: la op. 2 afirma «desde 3.15 usa UTF-8 estricto [B29][B205]». PEP 686 (B29) no habla del manejador de errores y B205 es la página de la release. Remedio: citar [B220], como P-04: «…desde 3.15 usa UTF-8 estricto [B220][B205]». Lo demás es reestructuración o remisión. El acotamiento de C# a identificador o literal coincide con la fila Roslyn de §4.2.4 (E1-01). |
| P-12 | APLICAR | La fecha de fin de .NET 8 (2026-11-10) está en el índice (`03-sdk8-eol`, `eol: 2026-11-10`) y en B61. Las 11 validaciones quedan nombradas (las conté). 8b y 9 llevan `# [no verificado]` con su motivo. `NO DECLARADA` sólo con runner coincide con A.17 y X1 9b. |
| P-13 | APLICAR | 22 de 22 bloques del Anexo A iguales byte a byte contra `x1/repo` (`anexoA-salida.txt`). Digest `ec9c0a0d…` confirmado por imagetools (X5). La diferencia con N8 la verifiqué con `diff`. La receta de Windows lleva [no verificado] y B219 está confirmada. El CODEOWNERS lo prueba X6. Commit y hash de A.17 salen de X1, con la condición del auditor de copiarlos de la corrida que se versione. |
| P-14 | APLICAR | Sólo remisiones a §8.2.2 y a A.11. No agrega afirmaciones técnicas nuevas. |
| P-15 | APLICAR | Remisiones del glosario y alias. Las secciones nombradas contienen el término (script de edición bibliográfica-02). |
| P-16 | MEJORAR_PLAN | Objeción concreta: la fila B224 usa la misma URL que B62 (`releases-index.json`), y la verificación del parche («0 URL repetidas») es falsa en la guía parcheada. Remedio sin cambiar la cuenta de 224: (a) **B224 pasa a ser NETSDK1238**: `Microsoft Learn — NETSDK1238 (CheckSdkVulnerabilities; «available in .NET 11 Preview 5 and later»)`, https://learn.microsoft.com/en-us/dotnet/core/tools/sdk-errors/netsdk1238, 2026-10-09; (b) la re-consulta del índice se anota en B62 («reconsultado el 2026-10-09: 8.0 `eol-date` 2026-11-10; 10.0 `latest-sdk` 10.0.401»), en la misma fila. B218–B223 están confirmadas por mí (§1); B63/B64/B150 v12 las sostiene la re-consulta del auditor (HTTP 200). |
| P-17 | APLICAR | La línea de fechas coincide con las 39 salidas del 2026-10-09 de X7. La fecha de modificación como indicador del día de la corrida es débil, pero está declarada y cruzada con las aplicaciones de los ciclos 1 y 2. E1-11 Node, E2-6 y E5-8 piden versionar L-02, L-03 y L-04 antes de aplicar (condición ya escrita). |
| P-18 | MEJORAR_PLAN | Objeción concreta: «Datos volátiles» cita [B224] para «10.0.401 vigente» y para el fin de soporte. Con el remedio de P-16, esos datos se citan [B62] (re-consultada) y [B61]. Y «`CheckSdkVulnerabilities` sólo desde el SDK 11 (§6.3)» puede llevar [B224] (NETSDK1238). Las trazas y la línea de «Set up job»/retención como no observadas están bien rotuladas. |
| P-19 | MEJORAR_PLAN | Objeción concreta: el párrafo 1.1.0 dice «§3.5 comprimida, Práctica de §3», y esa Práctica no se agrega (`03-Parches.md` §1.2 y §8; `grep` → no existe en la guía parcheada). Remedio: «§3.5 comprimida, fila §3 de la ruta mínima». Con el remedio de P-16, «B218–B224» sigue siendo cierto. |
| P-20 | APLICAR | Compresión. Lo quitado está en §0.4 y en la fila EA-1 del Anexo E. 0 enlaces rotos. |
| P-21 | APLICAR | Compresión. Que la integración de git de Visual Studio con `core.hooksPath` queda [no verificado] se conserva en §10.4 (ESC-01) y en el Anexo F, aunque la remisión diga §8.2.4. «Nunca `latest`» sigue en §6.3 [B57]. No se pierde evidencia. |
| P-22 | APLICAR | Fusión de preguntas sin pérdida: cada *Aplica* se conserva y remite a la sección que desarrolla el tema. |
| P-23 | APLICAR | Depende de P-01 (la regla del motivo por defecto). El `grep` da 0 después del parche. Va último, como declara el auditor. |
| P-24 | APLICAR | Corrige en la capa de origen (los núcleos y la bitácora), con notas de solo agregado. Las nueve anclas existen una sola vez (las verifiqué). Las notas citan evidencia existente: O-8 con `checksdkvuln.txt` (E1, que alcanza en la bitácora) y O-6 con B220. Antes de insertar se toma una instantánea y después se hace `diff` sólo con `>`. |
| P-25 | APLICAR | Cada cambio del laboratorio tiene su fuente ya corrida en `evidencia-auditor/` (X1 rc=0, X2, X3, X5). Condición de evidencia: L-02 (E5-8) describe en su README y en su fila «tres bases Linux», no «sistemas operativos» (P-08). E5-8, E2-6 y E1-11 Node se versionan antes de aplicar los parches de la guía que los citan. EA-1 se corre una sola vez después de L-01/L-01b. |

## 4. Saldo de prosa (+493)

No es una cuestión de evidencia y no condiciono ningún voto a eso. Desde mi rol sólo constato dos cosas. Los Δ están medidos, no estimados, y los reproduje. Ninguno de los recortes P-20 a P-23 quita evidencia ni una marca de juicio. Que entre la pasada del editor de cierre (C3-Q09) lo deciden los jueces de costo-beneficio y de impacto.

## 5. Escaladas

Ninguna. Los siete defectos son de citas o de alcance de la afirmación y tienen un remedio mecánico. No hay ambigüedad de intención, conflicto de restricciones, cambio de alcance, irreversibilidad, consecuencia externa, empate ni reapertura de una decisión cerrada.

## 6. Resumen

- APLICAR (18): P-01, P-02, P-03, P-04, P-05, P-07, P-09, P-12, P-13, P-14, P-15, P-17, P-20, P-21, P-22, P-23, P-24, P-25.
- MEJORAR_PLAN (7): P-06, P-08, P-10, P-11, P-16, P-18, P-19. Las siete objeciones son de cita o de alcance, con el remedio escrito arriba. Ninguna cambia la estructura del lote ni la cuenta de fuentes (224).
- NO_APLICAR: ninguno. ESCALAR: ninguno.
