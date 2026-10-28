# E02 — Herramientas, receptor y guion de la demo

Fecha: 2026-10-26. Tramo: constructor de herramientas y receptor (plan A1–A5, folio 037).
Raíz de la demo: `LAB/Lab-Documentos/Lab-Documentos/Concepts/Framework-Concept/Demo/`.

Este tramo retomó un intento anterior que se había cortado por el límite de sesión el 2026-10-26 hacia la 01:30.
Ese intento ya había dejado completos los dos proyectos y `scripts/guion.sh`, y una corrida de humo con 46 OK.
Se conservó todo. En esta sesión se recompiló, se volvió a correr y se corrigieron tres defectos del guion
(ver «Cambios de esta sesión»).

## Qué hay

| Pieza | Archivos | Qué hace |
| --- | --- | --- |
| `tools/FrameworkConcept.Tools` (consola net10.0, sin NuGet) | `ClavesDeDemostracion.cs`, `Empaquetador.cs`, `PublicadorDeDefiniciones.cs`, `Indexador.cs`, `Retiros.cs`, `Verificador.cs`, `CarpetaDelCanal.cs`, `Argumentos.cs`, `Program.cs` | `claves`: genera el par ECDSA P-256 (`claves/privada-demo.pem` no se versiona; `claves/publica-demo.pem` sí). `empaquetar`: arma un zip plano sin `.br`/`.gz` con `manifiesto.json` (versión+commit, `compatibleConPuente`, capabilities `{requires, optional}`, motor mínimo, sha256 por archivo) y rechaza AOT (P1), pre-release (P7), versiones que no son mayores (P2), una identidad reutilizada con otros bytes (P7) y el uso de APIs web que piden permiso (P12). `publicar-definicion`: exige `--cambia-datos` (P6) y rechaza los cambios destructivos (P13.8) y la reutilización de una versión (P13.9). `firmar`: arma `indice.json` (expires = ahora + 30 días, retiradas, keyId, entradas de contenido y de definición con size y sha256) y escribe `indice.json.sig` (ES256). `retirar`: retira contenido, o una definición con 30 días de aviso como mínimo (P13.5). `firma-invalida`: altera el índice sin volver a firmarlo. `verificar`: repite las comprobaciones del teléfono. `contrato`: regenera la instantánea `contrato.json`. |
| `tools/FrameworkConcept.Receptor` (ASP.NET minimal API) | `Program.cs`, `CanalEstatico.cs`, `RecepcionDeRespuestas.cs`, `AlmacenDeRespuestas.cs`, `RegistroDeDefiniciones.cs`, `ValidacionDeValores.cs` | Sirve `/{canal}/puente-{mayor}/…` desde una carpeta. No sale de ella con `../` y no sirve archivos internos como `estado-de-publicacion.json`. `POST /respuestas` es idempotente por `claveIdempotencia`: un reenvío idéntico no duplica; con otro contenido exige `If-Match` (428 si falta, 412 si no coincide). Acepta las definiciones publicadas y no retiradas, y manda a carta muerta (422) las no publicadas, las retiradas y los valores inválidos. Acepta respuestas tomadas con un contenido retirado (P13.10). `GET /respuestas` muestra lo aceptado, la carta muerta y los reenvíos. `--ahora` fija el reloj. `/salud`. |
| `scripts/guion.sh` | — | Tiene los subcomandos `claves`, `build`, `test`, `publicar v1\|v2`, `definicion v1\|v2`, `firmar`, `verificar`, `firma-invalida`, `retirar`, `semilla`, `servir`, `tunel`, `parar`, `apk`, `dispositivo`, `instalar`, `demo`, `humo` y `limpiar`. Todo lo que es .NET corre por `scripts/contenedor.sh`. Cada tramo de adb corre dentro de `flock $FC_LOCK`: despierta la pantalla y, al terminar, hace `am force-stop com.frameworkconcept.demo`. El servidor adb se elige con `-H/-P/-s` y `FC_ADB_CONTENEDOR`. |

## Verificado (2026-10-26, contenedor `lab-e2e-maui-dev:net10`, SDK 10.0.400)

1. Compilación con avisos como error:

   ```text
   CI=true dotnet build tools/FrameworkConcept.Tools -c Release     → 0 Advertencia(s), 0 Errores
   CI=true dotnet build tools/FrameworkConcept.Receptor -c Release  → 0 Advertencia(s), 0 Errores
   ```

2. `scripts/guion.sh humo` (sin teléfono; canal, datos, puerto 8098 y contenedor propios) da **46 OK, 0 MAL**,
   con salida 0. Hubo dos corridas completas con este resultado. Lo que cubre:
   - claves: si el par ya existe, no se regenera;
   - empaquetar: el zip sale plano y con `manifiesto.json` primero, sin `.br`/`.gz`, con sha256 de 64 hex. Volver
     a empaquetar lo mismo da el mismo sha256. Hay cuatro rojos y los cuatro se rechazan: pre-release (P7), una
     versión no mayor (P2), AOT (P1) y `navigator.geolocation` (P12);
   - definiciones: sin `--cambia-datos` sale 2. Se publican v1 y v2. Los rojos «tipo de una pregunta cambiado»
     (P13.8) y «republicar v2 con otro contenido» (P13.9) se rechazan;
   - firmar y verificar: un índice vigente pasa. Con el reloj en 2099 sale `IndiceVencido`. Después de
     `firma-invalida` sale `FirmaInvalida`. Al volver a firmar, pasa de nuevo;
   - retiros: el retiro de una definición con 10 días de aviso se rechaza y con 31 días se acepta. El contenido
     1.1.0 se retira. El índice firmado lleva `retiradas` y `definicionesRetiradas`;
   - receptor: 200 para el índice, la firma y el zip, y el zip servido es idéntico byte a byte. Da 404 para un
     archivo interno, para un `../` y para un canal desconocido. Las respuestas dan 201 (nueva), 200 con
     `duplicada: true` (reenvío), 428 (sin If-Match), 412 (If-Match viejo), 200 (If-Match correcto, versión 2),
     412 (If-Match sobre una clave inexistente), 422 (definición v7 no publicada), 422 (valores fuera de v1),
     201 (contenido 1.1.0 retirado, P13.10) y 400 (JSON mal formado). Con el reloj a +32 días: v1 retirada → 422
     carta muerta, y v2 → 201. Resumen de `GET /respuestas`:

     ```text
     aceptadas: [('humo-0001', 2), ('humo-0004', 1), ('humo-0006', 1)]
     cartaMuerta: [('humo-0002', 'la definición encuesta-movilidad v7 no está publicada'),
                   ('humo-0003', 'los valores no cumplen la definición v1'),
                   ('humo-0005', 'la definición encuesta-movilidad v1 se retiró el 2026-11-26 (P13.5)')]
     reenviosQueNoSeDuplicaron: 1
     ```

3. `servir` + `tunel` + `parar` sobre el canal real de la demo (`salida/canal/dev/puente-1`). Un cloudflared
   efímero dio `https://attachments-hormone-founder-envelope.trycloudflare.com`, por el que `GET
   /dev/puente-1/indice.json` devolvió 200 y `/salud` respondió. Lo único expuesto fue el contenido de la demo, sin
   secretos. El túnel estuvo abierto menos de un minuto. `parar` bajó `fc-demo-receptor` y `fc-demo-tunel`.
4. `dispositivo` sobre el Moto g42, con `FC_ADB_CONTENEDOR=adb-contenedor`, `-H 203.0.113.30 -P 5037 -s
   <serie-del-g42>` y el candado compartido. Devolvió `moto g42`, Android 13, WebView `com.google.android.webview
   155.0.8059.43` y los paquetes `com.frameworkconcept.ensayo01` y `com.frameworkconcept.seguridad01`, sin la demo
   instalada. No se tocó ninguna otra app.

Del intento anterior, según su log de 2026-10-26 02:13Z: con el contenido Blazor real publicado,
`contenido-1.1.0.zip` salió con 47 archivos (9 707 874 B sin comprimir, 3 757 482 B en zip). `firmar` y
`verificar` dieron OK con 2 contenidos y 2 definiciones. Una segunda publicación de 1.0.0 con otros bytes se
rechazó (P7, la identidad no se reutiliza). Esto no se repitió en esta sesión: el canal `salida/canal` lo usan
otros tramos.

## NO VERIFICADO

- `apk`, `instalar` y `demo` (el recorrido v1 → v2 en el teléfono) no se corrieron. Dependen del cascarón (tramo
  A2 del Shell, que estaba compilando en paralelo) y la corrida en el teléfono es de A3.
- `semilla`, `build` y `test` como subcomandos de este guion no se corrieron en esta sesión: lo hicieron o lo
  hacen otros tramos.
- `publicar v1|v2` con el contenido Blazor real en esta sesión. Hay evidencia sólo del intento anterior.
- El reenvío inverso de puertos de adb como camino de red sin túnel (nota P11 en la cabecera del guion).

## Cambios de esta sesión

- `humo` usaba la carpeta de datos del receptor de la demo (`salida/receptor`). Por eso las respuestas de una
  corrida anterior hacían fallar 7 casos en la siguiente (39 OK, 7 MAL). Ahora usa `salida/humo/receptor`, el
  contenedor `fc-demo-receptor-humo` y el puerto 8098, y ya no puede pisar un receptor de la demo en marcha.
- `parar` borra `salida/url-del-canal.txt`. Antes la URL de un túnel ya cerrado quedaba guardada y `apk` la habría
  usado.
- Se corrigió la etiqueta del rojo P13.9: lo que se prueba es republicar v2 con otro contenido.

## Uso con el teléfono compartido del laboratorio

```bash
export FC_ADB_CONTENEDOR=adb-contenedor
export FC_LOCK={dir-de-trabajo}/escenarios.lock
scripts/guion.sh dispositivo -H 203.0.113.30 -P 5037 -s <serie-del-g42>
scripts/guion.sh demo        -H 203.0.113.30 -P 5037 -s <serie-del-g42>   # NO VERIFICADO
```

Logs completos fuera del repositorio, en `~/fc-work/demo/`: `humo-2.log` y `humo-3.log` (las dos
corridas en verde), `dispositivo-2.log`, y `humo-1.log` y `real-1.log` (del intento anterior).
