# E02 — Correcciones de la revisión adversarial

Fecha: 2026-10-26. Tramo: corrector, después de A3. Rigen el dictamen de la ronda 2 (folio 035, P1–P13) y las
aprobaciones del PO (folios 023 y 036).

Rutas: la demo es `LAB/Lab-Documentos/Lab-Documentos/Concepts/Framework-Concept/Demo/` (abajo, `Demo/`). Los logs
copiados están en `correcciones-evidencia/`, junto a este archivo. Los logcats y las capturas del emulador siguen la
convención de A3: `logcat-hpdev-corr-*.txt` y `local/hpdev-corr-*.png`.

No se discutió ninguna brecha: las ocho eran reales. Dos se corrigieron sólo en parte, porque su verificación necesita
el moto g42, que en esta sesión quedó reservado para otra. Son la 1 y la 2, y se dice abajo qué falta.

## Resumen

| # | Brecha | Nivel | Estado |
| --- | --- | --- | --- |
| 1 | TPR del g42 fuera del umbral (P1) | P1 | Corregido el arranque; **TPR en el g42 NO VERIFICADO** |
| 2 | Camino de red del g42 contra P11 | P1 | Desvío declarado y túnel arreglado; **A3 en el g42 NO VERIFICADO** |
| 3 | Faltaban tres rojos de P8 | P1 | Corregido y medido |
| 4 | Rojo local de `ci-local.sh` sin M-13 | P1 | Corregido y medido; el PR en el runner queda para A5 |
| 5 | Plantilla de PR ausente (P6.6) | P1 | Corregido |
| 6 | El rollback marcaba versiones sanas como fallidas | P1 | Corregido y medido (pruebas y emulador) |
| 7 | Sin receta de contenedor versionada (P11) | P0 | Corregido y medido en una copia limpia |
| 8 | `claves` y `humo` pisaban la pública versionada | P1 | Corregido y medido |

## 1. P1, umbral TPR: la semilla en cada arranque

**Brecha.** `ProveedorDelActualizador.ObtenerAsync` leía y verificaba la semilla del APK en cada arranque en frío,
antes de mostrar. `Actualizador.PrepararAsync` además volvía a guardar sus definiciones.

**Corrección.**

| Archivo (`Demo/…`) | Cambio |
| --- | --- |
| `src/FrameworkConcept.Core/Update/Abstracciones.cs` | `IFuenteDeSemilla` (`Huella` + `CargarAsync`) y `FuenteDeSemillaFija` para las pruebas |
| `src/FrameworkConcept.Core/Update/IAlmacenDeContenido.cs` | `PunteroDeContenido.SemillaRevisada`: la huella de la instalación cuya semilla ya se revisó |
| `src/FrameworkConcept.Core/Update/Actualizador.cs` | Recibe `IFuenteDeSemilla?`. Carga la semilla sólo en el primer arranque o si cambió la huella. Anota la revisión sólo si quedó algo instalado: si la semilla falló, el próximo arranque la reintenta |
| `src/FrameworkConcept.Shell/Actualizacion/SemillaEmbebida.cs` | `FuenteDeSemillaEmbebida`. Huella = `VersionString+BuildString@LastUpdateTime` del paquete, sin abrir archivos |
| `src/FrameworkConcept.Shell/Actualizacion/ProveedorDelActualizador.cs` | Ya no carga la semilla; arma la fuente |
| `src/FrameworkConcept.Shell/Pages/DiagnosticoPage.xaml.cs` | Muestra la semilla cargada o «revisada para <huella>» |
| `tests/FrameworkConcept.Update.Tests/ArranqueTests.cs` | `SemillaYaRevisada_NoSeCargaDeNuevo`, `OtraInstalacion_RevisaLaSemilla`, `SemillaQueNoSeInstalo_SeReintenta` |

**Verificación.**

- `Update.Tests` 102/102. Rojo provocado: con la carga en cada arranque (se quita la condición de la huella),
  `SemillaYaRevisada_NoSeCargaDeNuevo` falla (`correcciones-evidencia/6-update-semilla-siempre.log`, rc 1).
- Emulador `fc-android-emu-hpdev`, APK x64 instalado de cero. En el primer arranque, `semilla: contenido
  1.0.0+5d5c2b4` y `activada la semilla` (`logcat-hpdev-corr-01-…`). En los 15 arranques siguientes,
  `semilla: ya revisada para esta instalación del cascarón; no se carga` (`logcat-hpdev-corr-02-…` a `-12-…`).
- TPR en el emulador, 5 arranques en frío con el contenido instalado (`corr-02-tpr-1…5`): 17 570, 32 868, 29 009,
  25 664 y 26 391 ms; el máximo es 32 868. Con el mismo método, A3 midió de 29 a 36 s. El emulador varía mucho de una
  corrida a otra: entre `claves` y el fin del actualizador pasan de 3 a 7 s, aun sin semilla. **No sirve para el
  umbral.**

**NO VERIFICADO.** El máximo de 5 corridas en el g42 en la condición declarada. Según el desglose del intento
anterior en el g42 (A3, §4.3), la semilla costaba unos 0,7 s (de 3,2 a 3,9 s) de un TPR de 8,2 s. Si ese desglose
vale, el TPR quedaría cerca de 7,5 s, **todavía por encima de 5 000 ms**. Es una estimación, no una medida. Si la
medida lo confirma, se cumple la condición de revisión (2) de P1 (evaluar C-min con E02-B como base). Lo que queda
antes del WebView en el g42 es la base (1,6 s) y las claves (0,3 s). Después del WebView, el runtime de Blazor tarda
3,6 s. El APK medido era Debug: medir el cascarón en Release es un candidato a reducir la primera parte, **NO
VERIFICADO**.

## 2. P11, camino de red del g42

**Brecha.** El README y `guion.sh` daban la IP de Tailscale como único camino, «sin túnel». Ese camino se midió sólo
en el emulador, y el g42 no alcanza i7infra. Además, `tunel` apuntaba a `http://` aunque el receptor estuviera en
HTTPS.

**Corrección.**

| Archivo | Cambio |
| --- | --- |
| `Demo/README.md` («Qué hace falta» y «Cómo se corre la demo») | Desvío declarado de P11. Con el g42, el único medio es `guion.sh tunel`, como medio de laboratorio. El reenvío inverso de adb sigue NO VERIFICADO, y el README dice por qué |
| `Demo/scripts/guion.sh` (cabecera P11, `cmd_tunel`) | La misma declaración. Si existe `claves/tls/receptor.crt`, el túnel va a `https://127.0.0.1:$PUERTO` con `--no-tls-verify` (tramo local; el teléfono ve el certificado público de trycloudflare) |

**Verificación.** `bash -n scripts/guion.sh` sin errores.

**NO VERIFICADO.** El túnel corregido no se levantó: sin el g42 no había a quién servirle. Tampoco se corrió A3 en el
g42 (reservado) ni se midió el reenvío inverso de adb.

## 3. P8, los rojos que faltaban

**Corrección.** Carpeta nueva `Demo/etapas/`, con un `README.md` y tres parches (`patch -p1` desde `Demo/`; se
deshacen con `-R`):

- `M-13-codigo-postal-cinco-digitos.patch`: el `GeneratedRegex` de `LocalidadRules.cs` pasa de `\d{4}` a `\d{5}`.
- `aviso-promovido-a-error.patch`: agrega una variable sin usar, que da el aviso CS0219.
- `error-de-compilacion-en-el-cascaron.patch`: agrega CS0029 en `Shell/App.cs`.

**Verificación**, en una copia de la demo (`~/fc-work/demo/corrector/copia`):

| Rojo | Resultado | Log |
| --- | --- | --- |
| M-13 en `Core.Tests` | `Con error: 6, Superado: 59, Total: 65`, rc 1. Fallan `CodigoPostal("3400",True)`, `CodigoPostal(" 3400 ",True)`, `CodigoPostal("34000",False)`, `GuardarNuevaAvisa`, `ModificarActualiza` y `RechazaDuplicada` | `1-m13-core-tests.log` |
| Aviso, `CI=true` | `error CS0219 … LocalidadRules.cs(23,13)`, `0 Advertencia(s) 1 Errores`, rc 1 | `3-aviso-build-ci.log` |
| Aviso, sin `CI` | `warning CS0219`, `1 Advertencia(s) 0 Errores`, rc 0: el aviso sólo se vuelve error en la compuerta | `3b-aviso-build-sin-ci.log` |
| APK del cascarón | `error CS0029 … App.cs(18,34)`, `1 Errores`, rc 1 | `4-error-apk.log` |

La primera corrida del rojo del APK dio **3** errores en lugar de uno: CS0029 y dos CS0103 en
`DiagnosticoPage.xaml.cs`. Los CS0103 eran un defecto real de esta corrección (`Actualizador` sin calificar). Se
arregló (`Core.Update.Actualizador`) y se volvió a medir: queda sólo CS0029. La compuerta verde (más abajo) incluye
ese arreglo.

## 4. P11, el rojo local con M-13

**Verificación.** `scripts/ci-local.sh --hasta 4` con M-13 aplicado: el build sin MAUI pasa (0/0) y el paso 2,
`Core.Tests`, termina con `Con error: 6 … Total: 65` y `rc=1` (`correcciones-evidencia/2-m13-ci-local.log`).

**Pendiente de A5.** Falta el PR en rojo con M-13 en `i7infra-dev`, con su `run_id` y la captura del botón de
fusionar deshabilitado. Este tramo no hace commits ni push.

## 5. P6.6, plantilla de PR

**Corrección.** Nuevo `Lab-Documentos/.github/pull_request_template.md`. Lleva cuatro campos obligatorios: «Unidad
declarada», «Qué sigue después del merge» (con la prueba en dispositivo de P6.8), «¿Cambia el propósito declarado en
la ficha de tienda?» (P1, función nueva de peso: si es sí, sale también por tienda) y «¿Cambia los datos que se
recogen o se comparten?» (si es sí, se actualiza Data safety o la privacidad de App Store Connect antes de promover a
`prod`). Para un PR que no toca la demo, los dos campos de tienda tienen la opción «No aplica».

**Verificación.** Revisión del archivo. GitHub lo toma recién cuando está en la rama por defecto: **NO VERIFICADO**
en un PR real (A5).

## 6. Rollback sólo cuando el contenido falla de verdad (P2)

**Brecha.** La marca «pendiente» se consumía en el primer arranque siguiente, aunque el contenido no hubiera llegado
a cargar. Si la persona cerraba la app mientras cargaba, una versión sana quedaba como fallida para siempre. Si eso
pasaba dos veces, la app caía en el estado terminal.

**Criterio adoptado.** Es una combinación de las dos salidas que proponía la revisión:

- **Evidencia de carga.** El servidor de contenido avisa una vez por proceso cuando el WebView pide
  `_framework/dotnet.js`. El cascarón llama entonces a `IActualizador.AnotarCargaIniciadaAsync(version)`, que suma 1 a
  `PunteroDeContenido.CargasSinListo` si esa versión es la pendiente.
- **Contador.** El arranque da la versión por fallida sólo cuando `CargasSinListo ≥
  Actualizador.CargasSinListoParaFallar` (2). Si no, la reintenta. `Listo`, una activación o una vuelta a `previous`
  ponen el contador en 0.
- **Staging en espera.** Mientras current espera su `Listo`, lo que hay en `staging/` no se activa, para que
  `previous` nunca sea una versión sin confirmar. Lo mismo vale para una semilla más nueva.

El 2 es **criterio de este tramo**, no un valor de producto del folio 036. Se propone a la presidencia para ratificar.
Con 1, el TPR del g42 (más de 8 s) hacía que cerrar la app en plena carga marcara una versión sana. El dictamen
(P2, «Temporizador de rollback: no hay») se respeta: no se agregó ningún temporizador.

| Archivo (`Demo/…`) | Cambio |
| --- | --- |
| `src/FrameworkConcept.Core/Update/Actualizador.cs` | Pasos 3, 5, 6 y 7 de `PrepararAsync`; `ActivarAsync` y `ConfirmarListoAsync` ponen el contador en 0; nuevo `AnotarCargaIniciadaAsync`; constante `CargasSinListoParaFallar` |
| `src/FrameworkConcept.Core/Update/IActualizador.cs`, `IAlmacenDeContenido.cs` | El método nuevo y `PunteroDeContenido.CargasSinListo` |
| `src/FrameworkConcept.Shell/Hosting/ServidorDeContenido.cs` | Evento `CargaIniciada` al servir `_framework/dotnet.js` |
| `src/FrameworkConcept.Shell/Pages/ContenidoPage.xaml.cs` | Anota la carga iniciada (fuera del hilo de la interfaz) |
| `src/FrameworkConcept.Shell/Pages/DiagnosticoPage.xaml.cs` | Fila «Cargas sin Listo» |
| `tests/FrameworkConcept.Update.Tests/{Banco,ArranqueTests,CortesTests,DefinicionesTests,AlmacenEnDiscoTests}.cs` | `Banco.ArrancarYCargarSinListo`. Pruebas nuevas: `UnaCargaSinListo_SeReintenta`, `ArranquesSinCarga_NoSonFalla`, `ConPendiente_StagingEspera`. Dos casos cambian de resultado esperado, porque el corte ocurre antes de cargar: `CorteTrasVolverAPrevious_SeReintenta` (antes «doble falla») y «Corte entre el puntero y la retención: la nueva no llegó a cargar, se reintenta» |
| `scripts/guion.sh` (`demo`, paso 7) y `README.md` | Cuatro arranques en lugar de tres; el criterio, escrito en el README; aviso sobre `FC_ESPERA` |

**Verificación.**

- `Update.Tests` 102/102. Rojo provocado con `CargasSinListoParaFallar = 1`: fallan `UnaCargaSinListo_SeReintenta` y
  `ConPendiente_StagingEspera` (`5-update-umbral-1.log`, rc 1).
- Emulador, con el contenido defectuoso 1.2.0 (`publicar sin-listo`):

| Arranque | Qué se hizo | Qué anotó el actualizador (logcat) |
| --- | --- | --- |
| `corr-07` | completo | 1.1.0 con Listo; consulta `Preparado`: 1.2.0 en staging |
| `corr-08` | cortado al ver `arranque: ContenidoListo`, antes de cargar | `activada 1.2.0`; sin `carga iniciada` |
| `corr-09` | el corte llegó tarde: la carga ya había empezado a los 6,2 s | `1.2.0 sigue pendiente de Listo (0 de 2 cargas sin Listo); se reintenta` → el corte de `corr-08` no contó; `carga iniciada` |
| `corr-10` | completo | `(1 de 2 cargas sin Listo); se reintenta`; `carga iniciada`; sin Listo |
| `corr-11` | completo | `rollback: 1.2.0 empezó a cargar 2 veces sin confirmar Listo; queda como fallida`, `vuelve a previous 1.1.0`, `puente Listo(1.1.0)`; consulta `Rechazado FallidaLocal` |
| `corr-12` | completo | 1.1.0 con Listo; 1.2.0 no se reinstala |

- Antes, con una versión sana (1.1.0): `corr-04` intentó cortar antes de la carga, pero el contenido avisó Listo a los
  13,6 s, antes del `force-stop`, así que no prueba el corte. `corr-05` se cortó con la carga ya empezada y `corr-06`
  terminó con `Listo(1.1.0)`. 1.1.0 nunca quedó como fallida.

## 7. P11, receta de contenedor versionada (P0)

**Corrección.**

| Archivo (`Demo/…`) | Cambio |
| --- | --- |
| `contenedor/Dockerfile` | Nuevo. `mcr.microsoft.com/dotnet/sdk:10.0.400-noble@sha256:4beef5b8…`; JDK 17, `libicu`, `locales` (es_AR), `python3`, `openssl`; SDK de Android con cmdline-tools 13114758, plataformas 35 y 36 y build-tools 35.0.0 y 36.0.0; `dotnet workload install maui-android --version 10.0.400.1`. Es la receta de `lab-e2e-maui-dev` sin Appium, Node.js, sudo ni usuario propio |
| `scripts/imagen.sh` | Nuevo. Etiqueta `fc-demo-build:<12 caracteres del sha256 de la receta>`; si no existe, la construye |
| `scripts/contenedor.sh` | Toma la imagen de `imagen.sh` (`FC_IMAGEN` sigue sirviendo para pruebas) |
| `scripts/guion.sh` (`apk`) | El `chown` del volumen de la clave de depuración usa la misma imagen, en lugar de `lab-e2e-maui-dev:net10` |
| `README.md` («Qué hace falta», carpetas, pendiente de A1) | Explica cómo se obtiene la imagen |

**Verificación.**

- Construcción desde cero: 7 pasos, rc 0, unos 4 min (`imagen-construccion-desde-cero.log`). La imagen trae SDK
  10.0.400 y el workload set 10.0.400.1.
- Copia limpia: los 185 archivos que versionaría git (`git ls-files --others --exclude-standard`), sin la privada. Se
  borró la etiqueta por huella y `imagen.sh` la reconstruyó: `imagen: no existe fc-demo-build:f327f6144f9b; se
  construye…`, rc 0. Usó la caché de capas de la construcción anterior (`limpio-0-imagen.log`).
- Sobre esa copia, todo con la imagen de la receta: `humo` 47 OK, 0 MAL; `ci-local.sh --hasta 4` rc 0 (65/102/47).
  En la demo, `ci-local.sh` completo dio rc 0: build 0/0, 65/65, 102/102, 47/47, contenido empaquetado y APK arm64
  0/0 (`ci-local-verde.log`).

**NO VERIFICADO.** Que la imagen se construya en otra máquina: depende de que respondan mcr.microsoft.com,
dl.google.com y los feeds de NuGet. El workflow del runner no usa la receta, porque el runner no tiene `docker.sock`;
corre `dotnet` directo, como antes.

## 8. Las claves en un clon limpio

**Corrección.**

| Archivo (`Demo/…`) | Cambio |
| --- | --- |
| `tools/FrameworkConcept.Tools/ClavesDeDemostracion.cs`, `Program.cs` | Si existe `publica-demo.pem` y falta la privada, `claves` sin `--forzar` sale con 1 y dice qué rehacer |
| `scripts/guion.sh` (`humo`) | Claves propias en `salida/humo/claves/`; `firmar --clave` y `verificar --publica` apuntan ahí. Rojo nuevo: verificar con la pública versionada da `FirmaInvalida` (47 comprobaciones) |
| `scripts/guion.sh` (`demo`) | Sin privada, `claves --forzar`; después rehace la semilla y el APK, como antes |
| `tests/FrameworkConcept.Gate.Tests/Semilla/SemillaTests.cs` | Nueva. `semilla/indice.json.sig` verifica con `claves/publica-demo.pem` usando el verificador del cascarón. Comprueba también el size y el sha256 de cada archivo |
| `README.md` | «Las claves en un clon nuevo» |

**Verificación.**

- Copia limpia: `guion.sh claves` da rc 1 con «existe claves/publica-demo.pem (versionada) y falta su privada». La
  huella sigue en `b6833f20…` antes y después de `humo` (`limpio-1-claves.log`, `limpio-2-humo.log`). En la demo,
  después de `humo`, también sigue en `b6833f20…`.
- Rojo de `Gate.Tests`: con una pública nueva y la semilla vieja, `LaSemillaVerificaConLaClaveVersionada` falla con
  «no verifica … (FirmaInvalida)» (`7-gate-semilla-otra-clave.log`, rc 1).
- Camino completo en la copia limpia: `claves --forzar`, `publicar v1`, `definicion v1`, `firmar` y `semilla`. La
  huella pasa a `ea97d50f…` y `SemillaTests` queda en verde (`limpio-4-…`, `limpio-5-…`).

## Limpieza

- Se bajó `fc-demo-receptor`. No quedó ningún contenedor `fc-` del tramo; `fc-android-emu` no es de este tramo.
- Se borraron `bin/`, `obj/` y `salida/` de la demo y las copias de trabajo en `~/fc-work/demo/corrector/`.
- Se quitó la etiqueta `fc-demo-build:prueba`. Queda `fc-demo-build:f327f6144f9b`, la imagen de la receta, que reusan
  los tramos siguientes.
- En el emulador, `com.frameworkconcept.demo` quedó instalada (APK x64 de esta corrección, current 1.1.0, fallida
  1.2.0) y detenida.

## Reanudación (después del corte por límite de sesión)

El intento anterior había completado las ocho correcciones, sus verificaciones y este registro. Se cortó durante la
limpieza: quedaban `bin/`, `obj/` y `salida/` en la demo, las copias de `~/fc-work/demo/corrector/` y la
etiqueta `fc-demo-build:prueba`. Ningún archivo de la demo cambió después de la compuerta verde de las 09:42, salvo
`README.md`. Aun así, se volvió a correr `scripts/ci-local.sh` completo sobre el estado final: rc 0, con build 0/0,
Core.Tests 65/65, Update.Tests 102/102, Gate.Tests 47/47, contenido empaquetado y APK arm64 0/0
(`correcciones-evidencia/ci-local-reanudacion.log`). Después se terminó la limpieza descrita arriba.
