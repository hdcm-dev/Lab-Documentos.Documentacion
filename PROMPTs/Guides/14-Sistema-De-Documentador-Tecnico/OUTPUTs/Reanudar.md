# Reanudar — Guía 14: sistema documentador técnico (expediente 0002, DocAsCode)

> **Invocación** (en un chat nuevo, en hpdev):
> - ultracode leer y ejecutar `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Guides/14-Sistema-De-Documentador-Tecnico/OUTPUTs/Reanudar.md`
>
> Escrito el 2026-10-28 desde hpdev. Rutas desde la raíz del workspace (`$WORKSPACE`; la ruta absoluta no se escribe).

---

## 1. Qué pasó y dónde estás

- **i7infra murió el 2026-10-28 a las 00:50** (-03), en plena compuerta E1-G de este trabajo. La máquina principal es ahora **hpdev**, con **infravm** como respaldo y cómputo. Contexto: `/Repos-Hosts/Infra-hpdev/Host.Infra.hpdev.Documentacion/Analisis/Contingencia-Caida-i7infra/Plan-Operativo-hpdev.md`.
- A diferencia de otras líneas, **esta casi no se perdió: vive en GitHub.** Los dos repos (`hdcm-dev/Lab-Documentos` y `hdcm-dev/Lab-Documentos.Documentacion`, **públicos**) están en hpdev al día con `origin/main`.
- La carpeta de este prompt tiene sólo el prompt original y este archivo: **el trabajo no se hizo acá**, se mudó. Cómo:
  1. El prompt `../Crear-Analizar-Sistema-De-Documentador-Tecnico-Guide.md` (investigación: ¿la documentación tipo OneSignal sale de markdown renderizado?, ¿es el estándar de la industria?) produjo una guía de un solo archivo.
  2. Commit `23e60d8` de este repo: «el encargo 14 apunta su salida a Lab-Documentos; se retira la prueba de concepto de este repo».
  3. El PO abrió el **expediente 0002 «Replanteo-Metodologia-DocAsCode»** (2026-10-26): `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/DEVs/Enchacement/01-Replanteo-Y-Analisis/OUTPUTs/Expedientes/0002-Replanteo-Metodologia-DocAsCode/`. Es una mesa que define una metodología DocAsCode común y la arquitectura del sistema documentador, y decide por **escalones con compuerta**: E1 (mini demo MovilidadUrbana + cuerpo documental + CI en el runner), E2 (piloto en Lab-Geometria) y E3 (un SDD privado y los orquestadores).
  4. El producto de lectura es el **cuerpo SDEI** (Sistema de Documentación e Integración): `/LAB/Lab-Documentos/Lab-Documentos/Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/` (README, Marco, Mapa, `TEM-01` a `TEM-07`, `Examples/`). La guía de un solo archivo, `Sistema-Documentador-Tecnico-Guide.md`, quedó **obsoleta** (E1-U4f).

## 2. Lo que hay (leelo en este orden)

| Qué | Dónde | Estado |
|---|---|---|
| Carátula y estado del expediente | `EXP/README.md` (EXP = la carpeta del expediente 0002) | Dice «sigue: implementación E1» (27-10): **desactualizado** |
| Decisiones | Folios `099` y `129` (resoluciones), `120` (acta del jurado del ciclo 2), `130`–`133` (respuestas del PO, decisiones delegadas, opción B, criterios de E1) | Vigentes |
| Plan de unidades E1, E2, E3 | `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/DEVs/Enchacement/01-Replanteo-Y-Analisis/OUTPUTs/Bitacoras/N10-Plan-De-Implementacion.md` (§5 PRE, §6 E1, §7 E2, §8 E3, §9 resumen, §10 ensayos abiertos) | Vigente |
| Paquete de criterios de la compuerta (G-a a G-g) | `…/Bitacoras/N09-…` §9.2 | Vigente |
| Folios de las unidades en GitHub | `210` (E1-U0a), `211` (E1-U0b y E1-U1), `216` (E1-U6) | Hay. **No hay folios de E1-U2 a E1-U5 ni de la verificación E1-G**: si se escribieron en i7infra, se perdieron. Su contenido está en las descripciones de los PR (tabla de abajo) |
| Delegación del merge (clases P y H, techo, intervalo) | Sección «Delegación del merge» de `CHANGELOG.md`/`README.md` de cada repo; memoria `pr-siempre-conformacion-automatica` | Vigente |

### Estado de E1 al morir i7infra

| Unidad | Repo | PR | Estado |
|---|---|---|---|
| E1-U0a delegación y `docs-guard` mínimo | Lab-Documentos | #11 | Fusionado 27-10 |
| E1-U0b delegación y llamador | Lab-Documentos.Documentacion | #17 | Fusionado 27-10 |
| E1-U0c expediente y bitácoras versionados | Lab-Documentos.Documentacion | #20 | Fusionado 27-10 |
| E1-U1 saneamiento de la guía | Lab-Documentos | #15 | Fusionado 27-10 |
| E1-U2 `docs-guard` completo | Lab-Documentos | #16 | Fusionado 27-10 |
| E1-U3 mini demo MovilidadUrbana | Lab-Documentos | #19 | Fusionado 27-10 |
| E1-U4a esqueleto del cuerpo SDEI | Lab-Documentos | #20 | Fusionado 27-10 |
| E1-U4b/c/d temas 01–07 y proceso | Lab-Documentos | #22, #24, #23 | Fusionados 27-10 |
| E1-U4e `AGENTS.md` | Lab-Documentos | #21 | Fusionado 27-10 |
| E1-U4f guía vieja obsoleta | Lab-Documentos | #25 | Fusionado 27-10 |
| E1-U5 reindexado de la ia-db (v4.1) | Lab-Documentos.Documentacion | #22 | Fusionado 27-10 |
| E1-U6 propuesta de expediente a Lab-E2E (condicionada) | Lab-E2E.WebBlazor | — | Folio `216` |
| **E1-G** reparaciones de la verificación | Lab-Documentos | #26 | Fusionado **28-10 00:40** |
| **E1-G** frontmatter que un lector YAML acepta (regla `frontmatter-no-yaml` en `dg.py`, 5 archivos corregidos) | Lab-Documentos | **#27** | **ABIERTO**. CI en verde (corrida por `hpdev-runner-dev` el 28-10), `mergeable_state: clean`. Clase P: entra en la delegación |
| **E1-G** `AGENTS.md`: `description` entre comillas y huella AK-3 renovada | Lab-Documentos | **#28** | **ABIERTO**. CI en verde, `clean`. **Clase H: espera la aprobación del PO**; el agente no lo fusiona |
| Folio `resolucion` de E1-G (paquete G-a a G-g sobre los SHA de merge de E1-U0a…E1-U5) | Expediente 0002 | — | **No existe**: era el siguiente acto |

Fuera de este expediente, en el mismo repo: **#14** `cierre/0001-tpr-emulador` (expediente 0001, Framework Concept) sigue abierto y quedó `behind`.

## 3. El entorno cambió

| Antes (i7infra) | Ahora (hpdev) |
|---|---|
| Runner `i7infra-runner-dev` | `hpdev-runner-dev` (hdcm-dev), con las mismas etiquetas (`i7infra`, `i7infra-dev`, …) más `hpdev`. **Ojo con E-F12** (el criterio que verifica el nombre del runner en el registro del job): ahora el registro dirá `hpdev-runner-dev`; anotarlo en el folio como cambio de entorno, no como falla |
| Worktrees de trabajo en `{dir-de-trabajo}/wt/…` en i7infra | Perdidos. Crear los nuevos fuera de `{tmp-de-sesiones}` y fuera del workspace (p. ej. `{raíz-de-worktrees}/`) |
| Generador de sitio usado en la verificación de E1-G (render del cuerpo SDEI) | No hay rastro en hpdev de cuál era ni de su salida: si G-x lo exige, rehacer la demostración |
| `scripts/ci-local.sh` | Sigue en el repo; corre igual en hpdev (Docker, Python, Node 22 y .NET 10/8 instalados) |

**Ramas locales que NO se publican nunca:** en los dos repos hay una rama `rescate/hpdev-2026-10-28` con borradores del 26 que GitHub ya superó; en Lab-Documentos.Documentacion además trae salidas sin redactar y APKs. Los repos son públicos: no se pushean ni se usan como base.

## 4. Qué hacer, en orden

1. **Reconciliar el expediente** (sólo agregado, folios nuevos):
   - Una `constancia` que asiente la caída de i7infra, el cambio de runner y que los folios de E1-U2…E1-U5 y la verificación de E1-G no llegaron a GitHub; incorporar como antecedente el contenido de los PR #16, #19–#25 y #26–#28 (descripciones y SHA de merge).
2. **Cerrar E1-G:**
   - Fusionar **#27** por conformación automática (guarda `clean` + CI en verde, merge atado al SHA, borrar la rama), si al relanzar sigue en verde y `clean`.
   - Pedir al PO la aprobación de **#28** (clase H). Con su ok, fusionarlo igual.
   - Re-ejecutar la verificación de la compuerta con el paquete G-a…G-g (`N09` §9.2) sobre los SHA de merge, con `docs-guard` sobre el `main` resultante (corre en `push` a `main` desde #26).
   - Escribir el folio `resolucion` de E1-G, con veredicto por criterio.
   - Actualizar el «Estado» de `EXP/README.md` con un folio, no editando la carátula.
3. **Escalón 2**, según `N10` §7: `E2-U0` folio de criterios (antes de cualquier rama), y después `E2-U1` (migración de Lab-Geometria a IA.SDD 13.22) ∥ `E2-U3` (conocimiento DocAsCode en KB-privada), `E2-U2` (ADR de D23), `E2-U4`, `E2-U5`, `E2-U6`, `E2-G`.
4. **E3** queda para después de E2-G (`N10` §8).

## 5. Reglas que siguen rigiendo

- Las del expediente 0002 (`Expediente`, `Mesa-De-Expertos-A-Pedido`, `Escalas-De-Juicio` de la base de conocimiento) y las del prompt del PO: no inventar; toda afirmación con evidencia.
- **Repos públicos:** nada sin redactar (rutas del host, usuario, nombre del servicio privado y su organización: alias `KB-privada` y los demás de la carátula). Barrido S2 antes de cada PR (comando del folio `099` §11).
- **Conformación de PR:** clase P por `Knowledge-Conformacion-Pull-Request-Automatico` (sin acuse del PO); clase H (workflows, excepciones con huella) espera al PO.
- `Crear-Analizar-Sistema-De-Documentador-Tecnico-Guide.md` es del PO: sólo lectura.
- Si te llega un mensaje del PO a mitad de un workflow, lo atiende la presidencia; los subagentes terminan su tarea.
