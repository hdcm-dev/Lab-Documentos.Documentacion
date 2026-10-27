| Campo | Valor |
| --- | --- |
| Tipo | archivo |
| Fecha | 2026-10-27 |
| Autor | Presidencia de la mesa |
| Corrige | — |

# Archivo — cierre del expediente 0001

## Estado final

Expediente **ARCHIVADO**. La mesa cerró por decisión (folio 037); la guía y la demo están en `hdcm-dev/Lab-Documentos`
y el expediente con sus ensayos en `hdcm-dev/Lab-Documentos.Documentacion`. La redacción de las filtraciones S2
previas se fusionó (PR #13 en Lab-Documentos, PR #15 aquí), con las etiquetas del runner aceptadas como publicadas
(folio 039).

## Pruebas en móvil al cierre

Por instrucción del PO del 2026-10-27, las pruebas sobre móvil se priorizan en el emulador de hpdev.

- **Emulador `fc-android-emu-hpdev`:** 5 arranques en frío de la demo. El contenido no emitió `primer-render`, así
  que el **TPR no se obtuvo**. El WebView quedó agregado a ≤ 2 878 ms, y `am start -W` no informó `TotalTime`
  (`WaitTime` ≤ 3 032 ms). Detalle en `../../../Ensayos/E03-Red-Y-Autenticacion/P1-TPR-EN-EMULADOR.md`. La medición
  no sustituye al teléfono físico de gama media que fija el umbral de 5 s de P1. Al terminar se desinstaló la demo.
- **moto g42:** **seguía reservado** por ESCENARIOS (candado `escenarios.lock` tomado por procesos vivos de esa
  sesión). No se tocó: no se midió y no se desinstalaron las apps.

## Inventario de limpieza

| Recurso | Acción |
| --- | --- |
| Contenedores `fc-keycloak`, `fc-demo-receptor`, `fc-auth-receptor-prueba` | Ya no existían al cierre |
| Contenedor `fc-android-emu` y sus volúmenes (`fc-android-emu-home`) | Se conservan: no son de esta mesa |
| Volumen `fc-nuget` | Borrado |
| Imagen `lab-e2e-maui-dev:net10` | Se conserva |
| `fc-work`: `demo`, `demo-limpio`, `demo-limpio2`, `arq-e02r`, `r2`, `r2-ref`, `verificacion`, logs `rev-repro-*`, `lista-limpio.txt`, `strip.py` (~1,5 GB) | Borrados |
| `fc-work`: `destrabe`, `docascode`, `ia-layer` | Se conservan: son de otras sesiones (había una corrida viva en `ia-layer` y un worktree con commits sin publicar en `docascode`) |
| `bin/` y `obj/` de la demo en el clon local | No había |
| `com.frameworkconcept.demo` en el emulador | Desinstalada |
| Volúmenes `fc-demo-keystore` y `fc-npm` | Quedan: no estaban en el pedido de limpieza |

## Pendientes abiertos

| Pendiente | Dueño |
| --- | --- |
| Desinstalar `com.frameworkconcept.{demo,ensayo01,seguridad01}` del g42 cuando ESCENARIOS libere el candado | Presidencia (próxima sesión con el g42 libre) |
| TPR en el teléfono de gama media (umbral de 5 s de P1) | PO, que asigna el teléfono |
| El contenido no emite `primer-render` en un arranque en frío sin canal (hallazgo del 2026-10-27) | Mantenedor de la demo |
| Decidir si se borran los volúmenes `fc-demo-keystore` y `fc-npm` | PO |
| Los NO VERIFICADO del anexo §6 de la guía (iOS, `.wasm` ante las tiendas, M-13, clon limpio, entre otros) | Mantenedor de la guía |

## Pase

Archivo. Para reabrir el expediente hace falta una nueva providencia del PO.
