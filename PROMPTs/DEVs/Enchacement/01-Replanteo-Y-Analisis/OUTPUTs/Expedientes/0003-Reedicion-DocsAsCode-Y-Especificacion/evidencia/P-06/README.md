# P-06 — Corrida del tool-prompt saneado

Condición de revisión de P-06 (resolución del expediente 0003): «si saneado deja de correr, se descarta (RWs) y el PR
lo dice». Esta carpeta guarda la corrida que la comprueba, en el PR 4 de §5.6 (U25 y P-06).

- **Tool-prompt corrido:**
  [`Lanzar-Example.md`](../../../../../../../../Guides/14-Sistema-De-Documentador-Tecnico/OUTPUTs/Tool-Prompts/Lanzar-Example.md),
  la versión saneada.
- **Fecha:** 2026-11-01, 20:10 a 20:12 UTC.
- **`$LD`:** clon temporal de Lab-Documentos en `0bed863` (borrado al terminar), así que la corrida no escribió en
  ningún clon de trabajo.
- **Versiones fijadas que se usaron:** `@devcontainers/cli@0.89.0` (Node.js 22) y `cloudflare/cloudflared:2026.10.5`.
- **Salida:** [`corrida-2026-11-01.txt`](corrida-2026-11-01.txt), con las rutas del host reemplazadas por `<tmp>`.

## Resultado

| Paso | Esperado por el tool-prompt | Obtenido |
| --- | --- | --- |
| 1. Devcontainer | `"outcome":"success"`, `containerId`, `remoteWorkspaceFolder` | Igual |
| 2. Compilar | `0 Error(s)` | `0 Warning(s)`, `0 Error(s)` |
| 3. Lanzar en `Production` | `200` en `/ingresar` antes de 30 s; «Catálogo de ayuda: 9 páginas, validador con 0 fallas»; «Hosting environment: Production» | `200` al cuarto intento; las dos líneas, iguales |
| 4. Túnel público | URL `*.trycloudflare.com` | **No se corrió**: publicaría la app en una URL abierta. Sólo se comprobó que la imagen fijada existe y arranca (`cloudflared version 2026.10.5`) |
| 5. Verificación (con `U=http://localhost:5190`, sin túnel) | `200`, `302`, `200`, `404`, `200`; `llms.txt` con cuatro entradas, ninguna de administrador | `200`, `302`, `200`, `404`, `200`; cuatro entradas, ninguna de administrador |
| `--estado` | Informar devcontainer, app y túnel | Devcontainer arriba, app `200`, túnel ausente (no se levantó) |
| 6. Entregar / `--bajar` | Baja el túnel y la app | `pkill` con código 0; `/ingresar` pasa a `000` |

Conclusión: saneado, el tool-prompt corre en los pasos 1 a 3, 5 y 6 y en las dos variantes; se conserva (SPLIT) y no
se aplica RWs. El paso 4 queda sin medir por la misma razón que en las corridas de la mesa (F012, F013 E4).

## Incidencias

- Un primer intento (19:50 UTC) cortó por tiempo en el paso 1 mientras la imagen
  `mcr.microsoft.com/devcontainers/dotnet:1-10.0` bajaba por una red lenta. Con la imagen ya bajada (`docker pull`
  aparte), el paso 1 terminó en `success`. No es un defecto del tool-prompt: la primera vez que se levanta el
  devcontainer tarda lo que tarde bajar la imagen.
- `npx` usó una caché de npm temporal y un tiempo de espera de red largo; el comando es el del tool-prompt.
- Al terminar se borraron el devcontainer, el clon temporal y la caché de npm.
