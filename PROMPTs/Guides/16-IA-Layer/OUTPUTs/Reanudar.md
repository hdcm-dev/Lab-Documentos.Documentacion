# Reanudar — Guía 16, integración de una capa de IA en .NET (tras la caída de equipo anterior)

> **Invocación** (en un chat nuevo, en estación 1):
> - ultracode leer y ejecutar `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Guides/16-IA-Layer/OUTPUTs/Reanudar.md`
>
> Escrito el 2026-10-28 desde estación 1. Rutas desde la raíz del workspace (`$WORKSPACE`; la ruta absoluta no se escribe, R-PRIV).

---

## 1. Qué pasó y dónde estás

- **equipo anterior murió el 2026-10-28 a las 00:50** (-03). Desde entonces la máquina principal es **estación 1** (esta notebook), con **estación 2** como respaldo y extensión de cómputo. Contexto completo: `<repo-privado-de-infraestructura>`.
- La carpeta de esta guía **existe sólo en estación 1**: nunca se commiteó ni está en GitHub (la convención de la bitácora es «sin commit»). La copia de estación 1 es la del **2026-10-26 a la mañana**; hay una foto de respaldo en `$FOTOS/rescate` (y en estación 2).
- **Lo que siguió en equipo anterior el 26 y el 27 se perdió.** Rastro en estación 1: el contenedor `<ollama>` (creado el 2026-10-27 16:03 por una sesión de equipo anterior que usaba estación 1 como cómputo) con `qwen2.5:0.5b` y `qwen3-embedding:0.6b`, lo que sugiere que ya se estaban armando ejemplos de RAG con embeddings. El directorio de trabajo intermedio que cita el sondeo, `{dir-de-trabajo}/`, estaba en equipo anterior y **no existe**. La guía final, `Examples/` y `Demos/` están **vacíos**. No reconstruyas de memoria lo que pudo haberse hecho en esa ventana: retomá desde lo que está escrito acá.

## 2. Lo que hay (leelo en este orden)

| Qué | Ruta (bajo `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Guides/16-IA-Layer/`) | Estado |
|---|---|---|
| Prompt del PO (sólo lectura) | `Crear-IA-Layer-Guide.md` | Vigente |
| Imagen de entrada | `INPUTs/AI-Layer.png` | — |
| Prompt reeditado sobre el marco de mesa (REED-16) | `OUTPUTs/Crear-IA-Layer-Guide-Reedicion.md` | Hecho |
| Índice y estado de la bitácora | `OUTPUTs/Bitacoras/README.md` | **Desactualizado**: dice «investigación por núcleo: pendiente» y está hecha |
| Fundación: contrato, descomposición, cohesión, marco de referencia (N0) | `OUTPUTs/Bitacoras/00-…` a `03-…` | Hecha (25-10) |
| Investigación por núcleo | `OUTPUTs/Bitacoras/Nucleos/N0b, N1, N1b, N2, N3, N3b, N4, N5, N6` (+ carpetas `N*-Evidencia/`) | Borradores **para el jurado**, con «Abierto / no verificado» y verificación adversarial (25 y 26-10) |
| Insumos y directiva del PO para la mesa | `OUTPUTs/Bitacoras/Mesa/I-01` a `I-06` | I-01…I-05 vigentes; **I-06 vinculante**: caso único Movilidad Urbana y medios móviles para la demo |
| Sondeo del entorno (Ollama, modelos, latencias) | `OUTPUTs/Bitacoras/Sondeo-Entorno.md` | **Desactualizado**: mide el servidor de la LAN de equipo anterior, que ya no existe |

Fases pendientes según la bitácora: **integración** (`04-Integracion.md`), **ciclos de mesa** (`Mesa/Ciclo-n/`), **redacción de la guía, ejemplos y demo**, **cierre** (`05-Cierre.md`).

## 3. El entorno cambió: qué usar ahora

| Antes (equipo anterior) | Ahora (estación 1) |
|---|---|
| «El servidor Ollama de la LAN del laboratorio» (CPU, `qwen3.5:4b`, `qwen2.5:7b-instruct` y otros) | **Muerto.** Reemplazo: el contenedor `<ollama>` de estación 1, publicado en la tailnet en el puerto 11434 (dirección: no se escribe, R-PRIV; se pasa por `OLLAMA_ENDPOINT`). Hoy tiene `qwen2.5:0.5b` y `qwen3-embedding:0.6b`. Para chat con tools hace falta bajar un modelo mayor (`docker exec <ollama> ollama pull qwen3.5:4b`): la estación 1 tiene 4 núcleos y no tiene GPU, así que será lento. Si no alcanza, levantar un Ollama en la estación 2 (más núcleos) y decidirlo con la mesa |
| `{dir-de-trabajo}/` (sondeos, `SondeoIChatClient`, caché NuGet en el volumen `<volumen-nuget>`) | No existe. Recrear el trabajo intermedio **fuera del workspace** (p. ej. `{dir-de-trabajo}/`); hay un `SondeoIChatClient` en la raíz del workspace, verificá si es el mismo antes de usarlo |
| .NET sólo en devcontainers | estación 1 tiene .NET 10 y 8 en el anfitrión y Docker; el feed `<feed-privado>` está configurado |
| Emuladores para la demo móvil (I-06) | **Nunca en estación 2**: es una VM de VirtualBox y el emulador con KVM anidado la cuelga (le pasó el 25-10 y otra vez el 28-10 a las 18:03 con `<contenedor-emulador>`; decisión del PO: sin QEMU en estación 2). estación 2 sirve sólo para Ollama y cómputo sin virtualización. En estación 1 están creados y detenidos: `<contenedor-ajeno>`, `<contenedor-ajeno>`, `<contenedor-ajeno>`. estación 1 tiene KVM sobre hierro. El teléfono de pruebas sigue accesible por adb remoto (ver la memoria del equipo) |
| Ejemplo base Movilidad Urbana | `/LAB/Lab-E2E.WebBlazor/` (`MovilidadUrbana.Web`, `MovilidadUrbana.ApiWeb`), al día con GitHub |

## 4. Qué hacer, en orden

1. **Reconciliar antes de avanzar** (sin reescribir: la bitácora es «sólo agregado»):
   - Agregar a `OUTPUTs/Bitacoras/README.md` una nota fechada «2026-10-28 — Reanudación tras la caída de equipo anterior» con el estado real: fundación hecha, núcleos N0b…N6 en borrador para el jurado, trabajo del 26–27 perdido, entorno nuevo.
   - Agregar a `Sondeo-Entorno.md` una nota fechada: el servidor medido ya no existe; correr un sondeo corto contra `<ollama>` (versión, `api/tags`, `api/show` de cada modelo, una latencia de chat y una de embeddings) y registrarlo como evidencia E1 nueva.
   - Revisar las secciones «Abierto / no verificado» de cada núcleo: lo que dependía del servidor viejo pasa a pendiente de re-verificación.
2. **Fase de integración** (`04-Integracion.md`): resolver las tensiones de `02-Cohesion-Global.md` §5 y las contradicciones entre núcleos; reconstruir el modelo completo.
3. **Mesa** según REED-16 y `/IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md`: convocatoria (ciclo 1), informes a ciegas, consolidado, votos, parches, aprobación, aplicación. Panel pedido por el PO: didáctica, edición de material bibliográfico, senior .NET, IA, arquitectura de software, desarrollo de código; analizar si hace falta otro experto.
4. **Redactar la guía** en `/LAB/Lab-Documentos/Lab-Documentos/Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Dot-Net-Integration-AI-Layer-Guide.md` (autocontenida, con índice, definiciones, snippets, mermaid, preguntas guía con respuestas), los **ejemplos** en `…/Examples` y la **demo** en `…/Demos`, sobre el caso único Movilidad Urbana (I-06). **Probar todo** contra el Ollama vigente.
5. **Relectura integral de la mesa** sobre el documento terminado y correcciones de edición y coherencia.
6. **Cierre** (`05-Cierre.md`, REED-16 §13).

## 5. Reglas que siguen rigiendo

- Las del prompt del PO y de REED-16: no inventar; toda afirmación con evidencia verificable (E1–E4 y C del contrato); R-LLM para las pruebas contra el modelo; R-PRIV (nunca dirección, puerto, usuarios ni credenciales del servidor de IA).
- `Crear-IA-Layer-Guide.md` e `INPUTs/` son del PO: sólo lectura. Los borradores, debates y evidencia de la mesa van a `OUTPUTs/Bitacoras/`.
- **Caso único** (I-06 y memoria `caso-unico-sin-mezclar-proyectos`): los insumos con ejemplos de otros proyectos aportan ideas generales; nunca se transcriben ni se mezclan con Movilidad Urbana.
- **Repo público** (`hdcm-dev/Lab-Documentos*`): nada sin redactar (rutas del home, IPs de la tailnet, serie del teléfono de pruebas, nombres de apps privadas). La guía no se publica sin un barrido de redacción.
- Si te llega un mensaje del PO a mitad de un workflow, lo atiende la presidencia; los subagentes terminan su tarea.
- **Respaldo:** estación 1 es la única máquina principal. Al cerrar cada fase, copiar la carpeta `16-IA-Layer` y la guía al equipo de respaldo con `rsync -a … "$RESPALDO_DESTINO"/16-IA-Layer/`. `RESPALDO_DESTINO` (usuario, equipo y carpeta) vive sólo en la memoria privada del PO y no se escribe en este repositorio (R-PRIV).

> **2026-10-28 — Parche P-01 (ciclo 1).** Redacción in situ por R-PRIV (C1-01): se sacaron una dirección de la tailnet con usuario (§5) y las rutas absolutas del home (encabezado, §1, §3). Las reemplazan `RESPALDO_DESTINO` y rutas desde la raíz del workspace. El texto quitado no se reproduce en ninguna parte de `OUTPUTs/`.
> Aplicado el 2026-10-28 (aplicación del ciclo 1). Las rutas se reemplazaron por `$WORKSPACE` y `$FC_WORK`; la viñeta «Respaldo» de §5 lleva el texto exacto de Parche P-01 (a).

---

> **2026-10-28 — Recuperación de la línea de equipo anterior como base.** Nota agregada; **reemplaza como punto de partida** a las §1–§4 de arriba, que describen la reanudación desde la foto del 26-10.
>
> - **La base ya no es la de esta reanudación.** equipo anterior volvió a las 20:20 (había perdido la red, no los datos) con la línea más avanzada: plan de integración v3, mesa ciclos 1–3, construcción de `Examples/` 01–17 + demo, y redacción de la guía 0.10.1 con relectura. Por decisión del PO («tomá como base los avances que estaban en equipo anterior y recuperalos acá»), esa línea está **restaurada en las rutas canónicas**: `OUTPUTs/Bitacoras/` y `/LAB/Lab-Documentos/Lab-Documentos/Guides/IA/Dot-Net-Integration-AI-Layer-Guide/`. Origen: la copia de sólo lectura tomada de equipo anterior el 2026-10-28 a las 20:25; en equipo anterior no se tocó nada.
> - **Lo que se hizo en estación 1 entre las 00:50 y las 20:20** quedó archivado, **sólo lectura**, en `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Guides/16-IA-Layer/OUTPUTs/Linea-{estación-1}-2026-10-28/` (su `README.md` lo explica: bitácora de reanudación, integración, sondeo de las estaciones vigentes, mesa ciclo 1 con ronda 2 y dictamen, ciclo 2, 13 informes de relectura, y `Guia/` con la guía de 4.107 líneas, 12 ejemplos y la demo). Es insumo, no base.
> - **Foto completa previa al cambio:** `$FOTOS/linea-{estación-1}-2026-10-28-2040.tgz` (copia en la estación de respaldo).
> - **Para retomar:** seguir `OUTPUTs/Bitacoras/Mesa/Recuperacion-2026-10-28/03-Plan-De-Recuperacion.md` por bloques (B-00 → B-15), anotando cada bloque en `04-Aplicacion.md` y cada pieza traída del insumo en `Procedencia.md`. La guía termina en 0.11.0 «en revisión»; la fase con modelo corre contra las dos estaciones vigentes (el servidor de la LAN y el «Ollama propio» de §3 ya no existen); la relectura integral va después.
> - **Este archivo** queda fuera de todo commit (RPRI-16); la presidencia lo mueve a la línea archivada cuando cierre la recuperación.

---

> **2026-10-29/30 — Recuperación aplicada y relectura cerrada.** Nota agregada. Reemplaza como punto de partida a la nota del 2026-10-28.
>
> - **Estado.** Los bloques B-00 a B-15 del plan de recuperación están aplicados, y el plan figura como «aprobado; aplicado». La guía es la 0.11.0, «en revisión»: build 561/561 y demo 81/81, sobre copia y con turno. La relectura (B-14) aprobó 34 parches (P-01…P-34) y no escaló ninguno. El resumen está en `OUTPUTs/Bitacoras/Mesa/Recuperacion-2026-10-28/05-Cierre.md`; el detalle, en `04-Aplicacion.md` (sección «B-15 · Cierre») y en `Relectura/06-Verificacion.md`.
> - **R-PRIV.** El barrido final da 0 sobre los dos repos y sobre el insumo archivado, salvo las excepciones declaradas por valor exacto (04-Aplicacion, B-15). El insumo se redactó en su contenido, con una foto previa en `$FOTOS`. Los nombres de algunas de sus rutas todavía llevan el de un equipo (DEU-15).
> - **Entorno.** La estación 1 tiene su Ollama corriendo y sin modelos cargados. El Ollama de la estación 2 está detenido, y su volumen de modelos se conserva. Las copias de trabajo ya verificadas se borraron (hay un tgz sin binarios en `$FOTOS`). Los registros R-LLM que todavía no están en la evidencia siguen en `{dir-de-trabajo}`.
> - **Qué falta (mesa).** DEU-10 (PV-01): sumar a `tools/compuerta-intervalos.tsv` las 18 cifras nuevas y reescribir la fila I22, hasta que la compuerta dé rc 0. DEU-11 (PV-02): correr `tools/verificar.sh` contra la estación vigente con turno y registrar el R-LLM. DEU-12: RL-21. DEU-13: reponer el voto de coherencia histórica de la relectura. DEU-14: consolidar los registros R-LLM que faltan en la evidencia.
> - **Qué falta (PO).** Decidir si se publica la demo; si se commitean la guía y la bitácora (antes, DEU-10 y DEU-15); si la 0.11.0 pasa a «publicada»; cómo se integra por PR con la otra sesión, y cuándo se hace la prueba móvil MD-1 en los emuladores de la estación 1 (nunca en la estación 2).
> - **Este archivo** sigue fuera de todo commit (RPRI-16). Su traslado al insumo queda para la presidencia que integre.
>
> - **2026-11-01 — Deudas DEU-10, 11, 13 y 14 cerradas.** Todas las compuertas pasan, `compuerta-intervalos.py` incluida (rc 0), y la guía no cambió (sha256 `c8defd83…7ce3d`). Detalle en `05-Cierre.md`, sección «Actualización 2026-10-30». Quedan DEU-12, DEU-15 y DEU-16, y las decisiones del PO.
