# Reanudar — Framework Concept (expediente 0001, MAUI autoactualizable)

> **Invocación** (en un chat nuevo, en hpdev):
> - ultracode leer y ejecutar `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Concepts/01-Framework-Concept/OUTPUTs/Reanudar.md`
>
> Escrito el 2026-10-28 desde hpdev. Rutas desde la raíz del workspace (`$WORKSPACE`; la ruta absoluta no se escribe).

---

## 1. Qué pasó y dónde estás

- **i7infra murió el 2026-10-28 a las 00:50** (-03). La máquina principal es ahora **hpdev**, con **infravm** como respaldo y cómputo. Contexto: `/Repos-Hosts/Infra-hpdev/Host.Infra.hpdev.Documentacion/Analisis/Contingencia-Caida-i7infra/Plan-Operativo-hpdev.md`.
- Esta línea **no perdió trabajo**: el último acto fue el 2026-10-27 a las 14:22 (constancia `042`) y está todo en GitHub (`hdcm-dev/Lab-Documentos` y `hdcm-dev/Lab-Documentos.Documentacion`, **públicos**), al día en hpdev.
- **El expediente 0001 está ARCHIVADO** (folio `040`, 2026-10-27), con las constancias `041` (g42 liberado y apps retiradas) y `042` (marca `primer-render` y nueva medición del TPR). Lo que queda son **pendientes chicos**, no una corrida abierta.

## 2. Lo que hay

| Qué | Dónde |
|---|---|
| Prompt del PO (sólo lectura; sin cambios desde el 26-10) | `../Crear-Framework-Concept.md` |
| Expediente | `Expedientes/0001-Framework-Concept-Maui-Autoactualizable/` (README con el estado; folios `001`–`042`) |
| Bitácoras de la mesa (núcleos, investigación, relevamientos) | `Bitacoras/` |
| Ensayos | `Ensayos/E01-WASM-Descargado-En-WebView`, `E02-Demo-Integracion`, `E03-Red-Y-Autenticacion` (con `P1-TPR-EN-EMULADOR.md`) |
| Guía y demo (el producto) | `/LAB/Lab-Documentos/Lab-Documentos/Concepts/Framework-Concept/`: `README.md`, `Developer-Guide.md`, `Framework-APP.md`, temas `00`–`08`, `99-Anexos.md`, `Demo/` |
| Compuerta de CI | Workflow `framework-concept-demo` de Lab-Documentos: produce el check **`fw-ok`**, que es **obligatorio** para fusionar en `main` |

## 3. Pendientes que siguen abiertos

| # | Pendiente | Origen | Qué hacer ahora |
|---|---|---|---|
| 1 | **PR #14** (`cierre/0001-tpr-emulador`, abierto y `behind`) dice que el TPR en el emulador «no se obtuvo» porque no llegó la marca `primer-render`. **Quedó desactualizado**: la constancia `042` encontró la causa (pantalla del emulador apagada) y midió **5/5 corridas `COLD` con marca, TPR máximo 12 451 ms (9 641–12 451)**. Toca `99-Anexos.md` §6, `Developer-Guide.md`, `01-Actualizacion-Sin-Tienda.md` y `Demo/README.md` | Folios 040 y 042 | No fusionar #14 tal cual. Actualizar su rama con `main` y reescribir el dato con la medición de `042` (o cerrarlo y abrir uno nuevo que la cite). Conformación automática de clase P; el check `fw-ok` tiene que dar verde |
| 2 | **TPR en el moto g42** (teléfono de gama media): la condición de revisión (2) de P1 sigue abierta, sin número | `042` | APK Release arm64 + `scripts/guion.sh tpr`. El g42 está en la PC del PO y se alcanza por adb remoto (memoria `g42-por-adb-remoto`; sólo paquetes propios). **El candado de escenarios (`flock`) vivía en i7infra**: definir uno en hpdev antes de tocar el teléfono, y avisar al PO |
| 3 | Volúmenes `fc-demo-keystore` y `fc-npm` (decisión del PO) | `040` | **Estaban en i7infra y se perdieron**: la keystore de la demo ya no existe. Para firmar una APK nueva hay que generar otra y documentarlo (folio nuevo); `fc-npm` es caché, se recrea sola |
| 4 | Ítems «NO VERIFICADO» del anexo §6 | `040` | Revisarlos uno por uno; los que dependían de i7infra (red, escenarios) pasan a pendientes de re-verificación en hpdev |

## 4. El entorno cambió

| Antes (i7infra) | Ahora (hpdev) |
|---|---|
| Runner `i7infra-runner-dev` | `hpdev-runner-dev` (hdcm-dev), mismas etiquetas más `hpdev`; ya corrió `framework-concept-demo` y `docs-guard` el 28-10 |
| Emulador `fc-android-emu-hpdev` (ya estaba en hpdev) | Sigue en hpdev, **detenido**, con su volumen `fc-android-emu-hpdev-home`. Encenderlo con la pantalla prendida (lección de `042`) |
| Candado de escenarios y del teléfono (`flock` en i7infra) | No existe: definir uno en hpdev |
| Keystore de la demo (`fc-demo-keystore`) | Perdida (pendiente 3) |

**Otra sesión trabaja en el mismo repo** (expediente 0002, DocAsCode: `Guides/`, `tools/docs-guard/`, `AGENTS.md`). Esta línea toca `Concepts/Framework-Concept/`: no se pisan, pero coordiná antes de cambiar workflows compartidos (`docs-guard`, `framework-concept-demo`).

**Ramas que NO se publican nunca:** `rescate/hpdev-2026-10-28` en los dos repos (borradores del 26 ya superados; en Lab-Documentos.Documentacion además salidas sin redactar y APKs).

## 5. Qué hacer, en orden

1. Leer el README del expediente y los folios `040`, `041` y `042`.
2. Agregar una `constancia` al expediente (el archivo admite constancias): caída de i7infra, cambio de runner, pérdida de `fc-demo-keystore` y del candado; el expediente sigue ARCHIVADO.
3. Resolver el **pendiente 1** (PR #14 con el dato de `042`).
4. Si el PO lo pide, el **pendiente 2** (TPR en el g42), con candado nuevo y aviso previo.
5. Pendientes 3 y 4 según decida el PO.

## 6. Reglas que siguen rigiendo

- Las del prompt del PO y del expediente (`Expediente`, `Mesa-De-Expertos-A-Pedido`): no inventar; toda afirmación con evidencia; un expediente archivado sólo recibe constancias o una reapertura fundada.
- **Repos públicos:** barrido de redacción antes de cada PR (sin rutas del home, IPs de la tailnet, serie del g42 ni nombres de apps privadas).
- **Conformación de PR** por `Knowledge-Conformacion-Pull-Request-Automatico`: guarda `clean` + CI en verde (incluido `fw-ok`), merge atado al SHA y, **sólo si el merge salió bien**, borrar la rama.
- El moto g42 es del PO: sólo paquetes propios, nunca sus apps de producción.
- Si te llega un mensaje del PO a mitad de un workflow, lo atiende la presidencia; los subagentes terminan su tarea.
