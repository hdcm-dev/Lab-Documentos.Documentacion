# Rojos provocados de la compuerta (Gate.Tests, ci-local.sh, workflow)

Fecha: 2026-10-26. Corrida en contenedor `lab-e2e-maui-dev:net10` (SDK 10.0.400, maui-android 10.0.20), con el volumen
NuGet `fc-nuget`. Se trabajó sobre una **copia git** de la demo (`~/fc-work/demo/repo-gate`, commit `base` =
la demo tal como estaba el 2026-10-26 a las 09:55). El original no se tocó.

Exigencia que se cumple acá: «cada suite obligatoria entra con su rojo provocado medido» (P8; VPI §3.4, T2).

## Cómo se armó

- La **base del PR** es la propia copia en `HEAD`, extraída por `scripts/ci-local.sh` (paso 0, `git archive`) en
  `salida/compuerta/base`. Así cada caso compara «lo publicado» (la demo en verde) contra «el PR» (la demo con un
  solo cambio).
- Cada caso: `git checkout -- . && git clean -fd` → un cambio → `dotnet test tests/FrameworkConcept.Gate.Tests -c Release`
  con `CI=true` y `FC_GATE_BASE=salida/compuerta/base`.
- Guion: `~/fc-work/demo/rojos.sh`. Registros: `~/fc-work/demo/rojos/*.log`. Resumen:
  `~/fc-work/demo/rojos-resumen.txt`. Están fuera del repositorio porque son intermedios.

## Verde de partida

`scripts/ci-local.sh` completo en la copia (`FC_BASE_REF=HEAD`), 6 min 40 s, rc=0:

| Paso | Resultado |
| --- | --- |
| 0. Base del PR | `HEAD:Concepts/Framework-Concept/Demo → salida/compuerta/base` |
| 1. Build del `.slnf`, avisos como error | 0 avisos, 0 errores |
| 2. Core.Tests | 65/65 |
| 3. Update.Tests | 96/96 |
| 4. Gate.Tests | 46/46 |
| 5. Publish del contenido y empaquetado | `contenido-1.0.0+7d72278`, zip plano |
| 6. APK del cascarón (android-arm64) | 0 avisos, 0 errores; `com.frameworkconcept.demo-Signed.apk` (20 MB). No se instaló |

## Rojos de Gate.Tests (19 casos, todos en rojo; verde final 46/46)

| # | Cambio provocado | Decisión | Prueba que falla | Mensaje (extracto) |
| --- | --- | --- | --- | --- |
| r01 | `documents.get`: parámetro `id` de `string` a `int`, sin subir la versión del puente | P3 | `ElCodigoCoincideConContratoJson` | «el contrato cambió y la versión del puente sigue en 1.0.0; corresponde subir el MAYOR (P3). [Mayor] «documents.get», parámetros: «id» cambió de tipo string → int» |
| r02 | `ContratoDelPuente.Version` 1.0.0 → 1.1.0 sin cambiar la tabla | P3, P7 | `ElCodigoCoincideConContratoJson`, `LasFuentesDeLaVersionDelPuenteCoinciden` | «la versión del puente subió (1.0.0 → 1.1.0) pero el contrato no cambió (P3: «si la versión subió y no difieren, rojo»)» |
| r03 | Versión 1.1.0 en el código, `puente.json` y `contrato.json`, sin cambio de contrato (coherente adentro, mal frente a lo publicado) | P3 | `LaVersionSubeSegunLaClasificacionFrenteALaBase` | «Base del PR (1.0.0) frente a este PR (1.1.0): la versión del puente subió … pero el contrato no cambió» |
| r04 | Método nuevo `encuestas.list` (cambio MENOR) con subida a 2.0.0 y `contrato.json` regenerado | P3 | `LaVersionSubeSegunLaClasificacionFrenteALaBase` | «el contrato tiene un cambio MENOR y la versión subió el MAYOR (1.0.0 → 2.0.0) (P3). [Menor] método nuevo «encuestas.list»» |
| r05 | `MauiVersion` 10.0.20 → 11.0.0 sin subir el puente | P3 cond. 2, P6.8 | `ElCodigoCoincideConContratoJson` | «[Mayor] cambió el transporte: … MauiMayor = 10 → … MauiMayor = 11» |
| r06 | `versionado/puente.json` 1.0.0 → 1.0.1 (sólo ese archivo) | P7 | `LasFuentesDeLaVersionDelPuenteCoinciden` | «versionado/puente.json frente a ContratoDelPuente.Version» |
| r07 | **Editar una pregunta sin subir `version`** (etiqueta de `edad` en v1) | P8, P13.9 | `FrenteALaBaseDelPr` | «v1.json cambió respecto de la base: la versión no es estrictamente mayor (1 → 1) (P13.9)» |
| r08 | v2: tipo `fecha` (fuera del enumerado del esquema) | P8 | `ValidaContraSuEsquema(v2)`, `SeLeeConElContrato(v2)`, `LasVersionesDelRepositorioEvolucionanBien`, `FrenteALaBaseDelPr` | «v2.json no valida contra esquema.json»; `JsonException … $.pasos[0].preguntas[1].tipo` |
| r09 | v2 borra la pregunta publicada `motivo` | P13.8 | `FrenteALaBaseDelPr`, `LasVersionesDelRepositorioEvolucionanBien` | «se borró la pregunta publicada «motivo» (P13.8)» |
| r10 | v2 cambia `edad` de `entero` a `decimal` | P13.8 | `FrenteALaBaseDelPr`, `LasVersionesDelRepositorioEvolucionanBien` | «la pregunta publicada «edad» cambió de tipo Entero → Decimal (P13.8)» |
| r11 | Se borra `v2.json` (publicada en la base) | P13.5 | `FrenteALaBaseDelPr` | «la definición publicada se borró del repositorio (retirarla es un acto explícito, P13.5)» |
| r12 | **Capacidad del catálogo sin su permiso**: se quita `ACCESS_NETWORK_STATE` del AndroidManifest | P8, P12 | `CadaCapacidadTieneSuPermiso` | ««network.status» necesita android.permission.ACCESS_NETWORK_STATE» |
| r13 | Permiso `CAMERA` sin entrada del catálogo | P12 | `NoHayPermisosSinCapacidad` | «declara permisos que ninguna entrada del catálogo implementa» |
| r14 | `uses-feature android.hardware.camera` | P12 | `NoHayFeaturesNiQueriesSinCatalogo` | «declara uses-feature android.hardware.camera, y EntradaDelCatalogo no tiene dónde declararlo» |
| r15 | Se borra el `AndroidManifest.xml` fuente | P12 | las tres pruebas del manifiesto | «No existe src/FrameworkConcept.Shell/Platforms/Android/AndroidManifest.xml. El cascarón tiene que traer su manifiesto fuente…» |
| r16 | **`RunAOTCompilation=true`** en el `.csproj` del contenido | P1, P8 | `ElContenidoNoUsaAot` | «FrameworkConcept.Content.csproj: RunAOTCompilation = «true»» |
| r17 | **`navigator.geolocation`** en `wwwroot/js/puente.js` | P8, P12 | `ElContenidoNoUsaApiWebQuePidenPermisos` | «src/FrameworkConcept.Content/wwwroot/js/puente.js:86: navigator.geolocation» |
| r18 | `CI=true` sin `FC_GATE_BASE` | P6.3 (nada se omite en silencio) | `LaVersionSubeSegunLaClasificacionFrenteALaBase`, `FrenteALaBaseDelPr` | «CI=true y falta FC_GATE_BASE: sin la base del PR no se puede comparar con lo publicado» |
| r19 | Un `Info.plist` fuente con `NSCameraUsageDescription` sin entrada del catálogo | P8, P9 | `InfoPlistFuenteSiExiste` | «Claves de uso de …/iOS/Info.plist que ninguna entrada del catálogo implementa» |

Los rojos que P8 nombra para la compuerta están en negrita: r01 («cambiar la forma de un método sin subir la versión del
puente»), r07, r12, r16 y r17. La otra mitad de la fila del catálogo de P8, «una capacidad sin su clave de uso»
en Info.plist, **NO VERIFICADO**: el catálogo de la demo no pide claves de iOS y no hay Info.plist (P9). r19 prueba la
dirección inversa.

Las pruebas del clasificador (`ClasificadorDeCambiosTests`, 23 casos sobre una instantánea de ejemplo fija) cubren
cada fila de la clasificación de P3 sin depender del contrato real.

Un intento anterior de este despacho (2026-10-26 ~01:30) corrió los mismos casos cuando el clasificador comparaba contra
la tabla real: r01 y r04 rompían también `CambioDeTipoEsMayor` y `MetodoNuevoEsMenor`. Esas pruebas ahora usan una
instantánea fija; esta corrida reemplaza a la anterior.

## Rojo de ci-local.sh

Con r07 aplicado en la copia, `scripts/ci-local.sh --hasta 4` terminó con **rc=1**: pasos 1 a 3 en verde y Gate.Tests
1/46 en rojo. Registro: `~/fc-work/demo/ci-local-rojo.log`.

## Workflow `.github/workflows/framework-concept-demo.yml`

- `actionlint` 1.7.12 (imagen local `rhysd/actionlint`, con shellcheck): **sin errores**. Sólo marca la etiqueta propia
  `i7infra-dev` como desconocida, que es lo esperable para un runner propio. `shellcheck` sobre `ci-local.sh`: sin hallazgos.
- **Agregador `fw-ok`**: se extrajo su `run:` del YAML y se corrió con cada combinación de resultados.

  | alcance | demo | compuerta | apk | fw-ok |
  | --- | --- | --- | --- | --- |
  | success | true | success | success | verde |
  | success | false | skipped | skipped | verde (omisión declarada, con motivo) |
  | skipped (PR desde un fork) | — | skipped | skipped | **rojo** |
  | failure | — | skipped | skipped | **rojo** |
  | success | true | success | skipped | **rojo** |
  | success | true | failure | skipped | **rojo** |
  | success | true | cancelled | cancelled | **rojo** |
  | success | true | skipped | skipped | **rojo** |
  | success | false | success | skipped | **rojo** (incoherente con el alcance) |

- **Paso de alcance**: se extrajo del YAML y se corrió en un repositorio de prueba. Un PR que sólo toca `Guides/` da
  `demo=false`. Uno que toca la demo da `demo=true`. Uno que toca `Demo/global.json` da `demo=true` y además el aviso
  de P6.8. `workflow_dispatch` da `demo=true`.

## NO VERIFICADO

- **Una corrida real del workflow en `i7infra-runner-dev`** (criterio de aceptación 1 de P11): no hay PR abierto, y
  este despacho no hace commit ni push.
- **`global.json` con `workloadVersion: 10.0.400.1` en el runner**: el runner trae SDK 10.0.402 y manifiestos
  maui-android 10.0.110 (R2 §5). En el contenedor, el SDK acepta la fijación aunque informa «Se encontró un problema
  al comprobar las cargas de trabajo». No está medido si en el runner corta el build o lo deja pasar. `rollForward:
  latestPatch` admite 10.0.402.
- **APK con `MauiVersion` 10.0.20 sobre el workload 10.0.110 del runner y con JDK 21**: sólo se compiló con el
  workload 10.0.20 y JDK 17 del contenedor.
- **Firma del APK de Debug en el runner** (keystore de depuración): no medida.
