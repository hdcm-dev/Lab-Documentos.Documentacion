# Tool-Prompt — Lanzar el ejemplo de demostración

> **Invocación**:
> - Leer y ejecutar `PROMPTs/Guides/14-Sistema-De-Documentador-Tecnico/OUTPUTs/Tool-Prompts/Lanzar-Example.md` del
>   repositorio Lab-Documentos.Documentacion, con `$LD` apuntando a la raíz de un clon de Lab-Documentos.
> - Variantes: `… Lanzar-Example.md --bajar` (detener todo) · `… --estado` (sólo informar)
>
> Overview: levanta la prueba de concepto «ayuda por rol» en su devcontainer, la expone por un túnel público y entrega
> la URL para compartir.

---

## Contexto

La prueba de concepto vive en Lab-Documentos, en
`Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Examples/Prueba-Ayuda-Por-Rol/` (ver su
`README.md`): un panel Blazor .NET 10 con ingreso simulado por papel, ayuda contextual, 404 por rol, `llms.txt` y dos
idiomas. Lo que demuestra se explica en `TEM-05` §3.3 del mismo cuerpo
(`Sistema-De-Documentacion-E-Integracion/TEM-05-*.md`, «Ayuda por rol, con un cruce que nadie había plantado»).

Se ejecuta **dentro de su devcontainer** (`.devcontainer/devcontainer.json`, imagen
`mcr.microsoft.com/devcontainers/dotnet:1-10.0`, puerto `5190`) y se publica con un **túnel rápido de Cloudflare**
(`*.trycloudflare.com`), que no necesita cuenta ni DNS. La URL cambia cada vez que se recrea el túnel.

Variables, rutas y nombres fijos:

| Cosa | Valor |
|------|-------|
| Raíz del clon de Lab-Documentos (`$LD`) | La ruta donde quien ejecuta tiene clonado Lab-Documentos; se pregunta o se busca, no se supone |
| Carpeta del proyecto (`$P`) | `$LD/Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Examples/Prueba-Ayuda-Por-Rol` |
| Contenedor del devcontainer (`$CID`) | `containerId` de la salida del paso 1 |
| Workspace dentro del contenedor (`$W`) | `remoteWorkspaceFolder` de la salida del paso 1 |
| URL pública (`$U`) | La que da el log del túnel en el paso 4 |
| CLI de devcontainers | `@devcontainers/cli@0.89.0` |
| Imagen del túnel | `cloudflare/cloudflared:2026.10.5` |
| Proyecto web | `Web/AyudaDemo.Web.csproj` |
| Puerto local | `5190` |
| Contenedor del túnel | `demo-ayuda-por-rol-tunnel` |
| Log de la app (dentro del devcontainer) | `/tmp/ayuda-demo.log` |

---

## Procedimiento

Ejecutar en orden. Cada paso se verifica antes de pasar al siguiente; si uno falla, detenerse y reportar la causa.

### 1. Devcontainer

```bash
cd "$P"
npx -y @devcontainers/cli@0.89.0 up --workspace-folder .
```

Si ya existía **para esta misma carpeta**, el CLI lo reutiliza (`"outcome":"success"`). Guardar `containerId` como
`$CID` y `remoteWorkspaceFolder` como `$W`. Un devcontainer creado cuando la carpeta vivía en otra ruta no se
reutiliza: queda huérfano con la etiqueta `devcontainer.local_folder` vieja y hay que borrarlo
(`docker ps -a --filter label=devcontainer.local_folder`, luego `docker rm -f`).

### 2. Compilar

```bash
npx -y @devcontainers/cli@0.89.0 exec --workspace-folder . \
  dotnet build Web/AyudaDemo.Web.csproj -nologo -v q
```

Esperado: `0 Error(s)`.

### 3. Lanzar la app, desacoplada de la sesión

La app **no** se lanza como comando en segundo plano de la sesión del agente: al cerrarse la sesión, muere y el túnel
queda apuntando a nada (pasó el 2026-09-19). Se lanza con `setsid nohup` dentro del contenedor, y en `Production`
porque va a quedar expuesta:

```bash
docker exec "$CID" pkill -f AyudaDemo.Web || true
docker exec -d -u vscode -w "$W/Web" \
  -e ASPNETCORE_URLS=http://0.0.0.0:5190 -e ASPNETCORE_ENVIRONMENT=Production -e DOTNET_CLI_TELEMETRY_OPTOUT=1 \
  "$CID" sh -c 'setsid nohup dotnet run --no-build --project AyudaDemo.Web.csproj --no-launch-profile > /tmp/ayuda-demo.log 2>&1 &'
```

Verificar hasta 30 s:

```bash
curl -s -o /dev/null -w '%{http_code}\n' http://localhost:5190/ingresar     # 200
docker exec "$CID" grep -E 'Catálogo de ayuda|Hosting environment' /tmp/ayuda-demo.log
```

Esperado: `Catálogo de ayuda: 9 páginas, validador con 0 fallas` y `Hosting environment: Production`.

### 4. Túnel público

```bash
docker rm -f demo-ayuda-por-rol-tunnel 2>/dev/null
docker run -d --name demo-ayuda-por-rol-tunnel --network host \
  cloudflare/cloudflared:2026.10.5 tunnel --no-autoupdate --url http://localhost:5190
```

Leer la URL del log (aparece en pocos segundos):

```bash
docker logs demo-ayuda-por-rol-tunnel 2>&1 | grep -oE 'https://[a-z0-9-]+\.trycloudflare\.com' | head -1
```

**No tocar** otros contenedores ni túneles que ya corran en el host: no forman parte de esta demo.

### 5. Verificación de punta a punta por la URL pública

Con la URL `$U`, todo en una sesión de alumno (cookie):

| Petición | Esperado |
|----------|----------|
| `GET $U/ingresar` | `200` |
| `GET $U/entrar/Student` (guardar cookie) | `302` |
| `GET $U/ayuda/alumno/enviar-un-trabajo` | `200` |
| `GET $U/ayuda/administrador/gobernar-las-cuentas` | `404` |
| `GET $U/ayuda/llms.txt` | `200`, cuatro entradas, ninguna de administrador |

Un nombre nuevo de `trycloudflare.com` es **intermitente durante sus primeros minutos** (medido el 2026-09-20:
respuestas `000` «could not connect» alternadas con `200`, mientras `cloudflare.com` respondía siempre). No es la app
ni el túnel: es la propagación del nombre. Por eso cada petición de esta tabla se reintenta hasta cinco veces con 3 s
de espera, y una petición que devuelve `000` no cuenta como fallo hasta agotar los reintentos. Conviene además avisarle
al usuario que los primeros minutos pueden fallar para quien reciba el enlace.

### 6. Entregar

Reportar al usuario, en este orden: la URL pública, que el ingreso es simulado y sin datos reales, que la URL vive
mientras sigan arriba el devcontainer y el contenedor del túnel, y cómo bajarla:

```bash
docker rm -f demo-ayuda-por-rol-tunnel
docker exec "$CID" pkill -f AyudaDemo.Web
```

---

## Variantes

**`--estado`**: no cambiar nada. Informar si el devcontainer existe
(`docker ps --filter label=devcontainer.local_folder=$P`), si la app responde en `5190`, si el túnel está arriba y
cuál es su URL, y si esa URL responde `200` en `/ingresar`.

**`--bajar`**: ejecutar los dos comandos del paso 6 y, si el usuario lo pide expresamente, también `docker rm -f` del
devcontainer. Por defecto el devcontainer se conserva: recrearlo cuesta minutos y no ocupa nada mientras está parado.

---

## Reglas

- No modificar el código ni el contenido de `Prueba-Ayuda-Por-Rol/`: este prompt lanza, no desarrolla. Si algo no
  compila, reportarlo.
- La app se expone sólo en `Production`. Nunca publicar una URL con `ASPNETCORE_ENVIRONMENT=Development`.
- Toda afirmación del reporte sale de una verificación ejecutada en esa corrida: no reportar «arriba» sin el `200`
  correspondiente.
- No dejar procesos atados a la sesión del agente; sólo el `docker exec -d` del paso 3 y el contenedor del paso 4.

---

## Procedencia

Expediente 0003, resolución P-06 (SPLIT), §5.6 PR 4. Es el tool-prompt de
`Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Examples/Lanzar-Example.md` de Lab-Documentos
en el commit `0bed863`, con el mismo procedimiento operativo (pasos 1 a 6, variantes y reglas) y saneado de los datos
del entorno: la ruta absoluta del espacio de trabajo pasa a la variable `$LD`; los nombres de los túneles del usuario,
a una regla general; las versiones `latest` del CLI y de la imagen del túnel, a versiones fijas; `$CID` y `$W` se
definen antes de usarse; la remisión a la guía obsoleta pasa a `TEM-05` §3.3, y la regla de evidencia se enuncia sin
nombrar un archivo que no está en el repositorio. Se quitó el frontmatter de `guia-practica`: esto es un tool-prompt,
no una pieza del cuerpo. En Lab-Documentos, el original se reescribe como guía práctica genérica (AC-31).

Corrida de comprobación del 2026-11-01 (condición de P-06): ver
[`evidencia/P-06/`](../../../../DEVs/Enchacement/01-Replanteo-Y-Analisis/OUTPUTs/Expedientes/0003-Reedicion-DocsAsCode-Y-Especificacion/evidencia/P-06/README.md).
