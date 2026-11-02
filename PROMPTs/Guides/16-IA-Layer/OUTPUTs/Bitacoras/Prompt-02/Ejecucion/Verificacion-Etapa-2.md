# Verificación independiente de la etapa 2 (E1, E2, E4, E5, E6)

> Plan: `../05-Plan-Integrado.md` §5 y §6. Fecha: 2026-11-01, -03. Registro de sólo agregado.
> El verificador no confió en los resúmenes: cada salida se abrió en su ruta y cada compuerta se volvió a correr.
> `{B}` es esta bitácora; `{G}` la carpeta de la guía en LD; `{geo}` el worktree g16 de Lab-Geometria;
> `<privado>` el worktree g16 del repo privado; `{trabajo}` la copia de trabajo `verif-etapa2`.

## Índice

1. [Definiciones](#1-definiciones)
2. [Tabla de criterios](#2-tabla-de-criterios)
3. [Compuertas corridas](#3-compuertas-corridas)
4. [Integridad: guía, push, ramas y territorios](#4-integridad-guía-push-ramas-y-territorios)
5. [Pendientes](#5-pendientes)
6. [Arreglos aplicados](#6-arreglos-aplicados)

## 1. Definiciones

- **Cumple:** el criterio del plan se comprobó con un comando de esta verificación.
- **Cumple con desvío:** el contenido está, pero en una ruta o forma distinta de la del plan.
- **Parcial:** una parte del criterio no se cumple; va a §5.

## 2. Tabla de criterios

| Etapa | Criterio del plan | Comprobación | Resultado |
|---|---|---|---|
| E1 | Salidas `E1/Matriz…`, `E1/Ensayos.md`, `E1/Cambios-Al-Libro.md`, README corregidos, `compuerta-referencias.sh` | `ls`; sha256 de los 7 README, del `.csproj` renombrado y de la compuerta coinciden con `Ejecucion/E1.md` §3 | Cumple |
| E1 | 100 % de afirmaciones con artefacto o marca | lectura de la matriz (85 filas de tabla) | Cumple |
| E1 | T-qwen ≥ 4/5 por ejemplo o decisión de la mesa registrada | 08, 09, 11, 13, 16: 5/5, IC95 [0,478; 1] (correcto para 5/5); `Evidencia/SHA256SUMS` verifica sin fallas | **Parcial**: 12 «no aplica» está *propuesto* a la mesa, no hay decisión registrada |
| E1 | T-3 con versión negociada | `2026-07-28` en `E1/Ensayos.md` | Cumple |
| E1 | `verificar.sh build` 561/561 | rebuild propio sobre copia con turno `build`: **rc 0, 561/561 en 18 suites**, R-PRIV 0; log sha256 `95120dbdeef5e17e9d238dd0a15e7a6a8a48e732fcf0f031d5f45f3a61ee6edb` | Cumple |
| E1 | Criterio R-LLM antes de correr | sha256 `c1d4979e…fede78` coincide; mtime 16:41, primera corrida 16:56 | Cumple |
| E1 | 22 menciones de `qwen2.5:0.5b` clasificadas | `grep -c` = 22 líneas (23 apariciones) en la guía; §4 de `Cambios-Al-Libro.md` | Cumple |
| E2 | Cinco salidas en `E2/` | `ls` | Cumple |
| E2 | 10/10 P-n con ancla resoluble, 0 inventados | `trazas.py <guía>`: 10 principios, 0 fallas | Cumple |
| E2 | Tope votado y registrado | `Medicion-Y-Tope.md` §7: T-a 4 · T-b 1 · T-c 0, tope 60.000 | Cumple (nota: el tope supera la medida actual 57.753) |
| E2 | 283 anclas con destino | 283 anclas únicas en la guía, todas presentes en `Anclas-Viejo-Nuevo.md` | Cumple |
| E2 | Borrador Parte I ≤ 1.500 palabras con mermaid | `contar.sh`: 1.085 (wc 1.300); mermaid ok | Cumple con desvío (en `Ejecucion/`) |
| E4 | ≤ 600 líneas | `wc -l` = 501 | Cumple con desvío de ruta (`Ejecucion/E4-*`, declarado en `E4.md`) |
| E4 | 0 contenido de la guía sin `[Guía §x]` | barrido de 12 palabras seguidas: 5 líneas coinciden, las 5 dentro de párrafos que llevan la remisión | Cumple |
| E4 | Mermaid validados | 2/2 ok | Cumple |
| E4 | 0 menciones del servicio privado salvo la fórmula | 1 «servicio privado», 0 del nombre | Cumple |
| E4 | `verificar-requisitos` | rc 0, 12 requisitos, 0 incompletos | Cumple |
| E5 | Expediente 0002 y `ai-layer/` en `{geo}` | rama `g16/ai-layer-v1`, commits `0f01e83`, `b4832d4`; diff contra `5f07b12` sólo en `ai-layer/` y `SDD/Expedientes/0002-…` (nada en `src/` ni en el intake) | Cumple |
| E5 | Checklist D-23 al 100 %, agente sin guía **y humano de la mesa** | 0 filas en NO; revisión humana ausente | **Parcial** |
| E5 | Hallazgos P0–P3 | 14 K-nn clasificados en `E5.md` §7 | Cumple con desvío (no hay `E5/Hallazgos-Del-Conocimiento.md`; declarado) |
| E5 | Compuertas del repo | evidencia E-006: 94 + 436 pruebas, rc 0; E2E y puertas f/g no corridas (sin cambio de código) | Cumple según su evidencia; no re-corrido |
| E6 | Especificación y expediente en `<privado>` | commit local `08b4850` sobre `fa047ff`; sólo `ai-layer/` y `su carpeta de expedientes` (la convención del repo) | Cumple |
| E6 | `E6/Reglas-Abstractas.md` con K-nn | K-01…K-10 en `E6.md` §2, sin archivo propio | Cumple con desvío (no declarado) |
| E6 | Checklist D-23 al 100 % | revisor agente sí; humano no | **Parcial** |
| E6 | Filtro U-7.1 con 0 coincidencias sobre LD y LDD | E6 lo corrió sólo sobre `E6.md`; re-corrido sobre LD y LDD: ver §5 | **Parcial** |

## 3. Compuertas corridas

| Compuerta | Alcance | rc | Resultado |
|---|---|---|---|
| `verificar.sh build` (turno `build`, copia en `{trabajo}`) | guía | 0 | 561/561, R-PRIV 0 |
| `compuerta-referencias.sh` | `{G}` | 0 | 0 rotas en 21 archivos (en la copia da 1 porque las rutas se resuelven desde la raíz del workspace) |
| `compuerta-ac7.sh`, `compuerta-ac8.sh` | `{G}` | 0, 0 | 0 coincidencias; 0 fuera de excepciones |
| `comparar-ac9.py bloques` | `{G}` | 0 | 57 bloques, 0 diferencias |
| `compuerta-rpriv.sh` | `{G}` | 0 | 0 hallazgos |
| `compuerta-rpriv.sh` | `{geo}/ai-layer`, `{geo}/SDD/Expedientes/0002-…` | 0 | 0 hallazgos |
| `compuerta-rpriv.sh` | `{B}/E1`, `{B}/E2`, `{B}/Ejecucion` | **1** | 8 hallazgos de las clases «turnos» e «identificadores» (§5) |
| `mermaid.sh` | 10 diagramas en 7 archivos (E1, E2 ×2, E4, `{geo}` ×2, `<privado>`) | 0 | 10/10 ok |
| grep `push.?dispatch` | `{B}` y `{G}` | — | `{G}`: 0. `{B}`: 3 archivos anteriores a la etapa 2 (§5) |

## 4. Integridad: guía, push, ramas y territorios

- **Guía:** sha256 `c8defd8324497c4279a3dfd57ce5d2757326ad966813a9f9797d0196d9b7ce3d`, el mismo de E1. Los únicos archivos de `{G}` modificados desde las 16:30 son los 10 que lista `E1.md` §3. `Conocimientos/` sin cambios (C-5.5).
- **Git:** `{G}` y `{B}` están en `.git/info/exclude` de LD y LDD, así que `git status` no los muestra: la integridad se comprobó por sha256 y fecha.
- **Push y ramas remotas:** `ls-remote` sin ramas `g16/*` en Geometría ni en el privado; ningún `push` en los reflogs; LD y LDD sin ramas g16.
- **Clones principales:** Lab-Geometria y el privado en `main`, limpios. LD y LDD en `main`, con cambios en `Guides/IA/Claude-Guide*`, `Guides/Documentacion-Tecnica/**`, `PROMPTs/Concepts/**` y `PROMPTs/Guides/14-*`: son de otras sesiones; ningún registro de E1–E6 los toca.

## 5. Pendientes

1. **Revisión humana del checklist D-23 en E5 y E6.** El plan la exige y ninguna etapa la tiene; E5 la elevó al PO (actuación 004).
2. **Decisión de la mesa sobre el ejemplo 12 en T-qwen.** E1 la propone; hasta que la mesa la registre, el criterio queda parcial.
3. **Filtro U-7.1 sobre LD y LDD.** Con la lista negra privada (26 términos):
   - En lo de la guía 16: un prefijo de ADR en `Ejecucion/E5.md:50` y en `{geo}/ai-layer` (es la convención propia de Geometría: el término de la lista es demasiado genérico); el número del expediente privado dentro de un `.jsonl` de `E1/Evidencia` (un número, ruido). Conviene afinar la lista.
   - El nombre del servicio privado en `00-Coordinacion-Entre-Sesiones.md` (archivo común), `Propuestas/P-01-Requisitos.md:276` y `Relevamiento/R5-Marco.md:87`. Son anteriores a la etapa 2 y citan el prompt del PO, que también lo nombra. La carpeta no está versionada, pero hay que resolverlo antes de publicar (E11).
   - Fuera del territorio (CHANGELOG, `tools/docs-guard`, guías de otras sesiones): son ajenos, no se tocaron.
4. **R-PRIV, clases «turnos» e «identificadores».** Nombres del gestor de turnos y del recurso de modelo en `E1/Criterio-R-LLM.md:23`, `E1/Ensayos.md:24,108,118`, `Ejecucion/E1.md:86` y `Ejecucion/E5.md:67`. No se reescribieron: son registros de sólo agregado y el criterio tiene un sha256 citado. Se reemplazan por marcadores en la redacción que se publique.
5. **Rutas del plan:** `E4/`, `E5/Hallazgos-Del-Conocimiento.md` y `E6/Reglas-Abstractas.md` no existen. El contenido está en `Ejecucion/` (E4 y E5 lo declaran; E6 no).
6. **Upstream de las ramas g16:** las dos ramas `g16/ai-layer-v1` siguen a `origin/main`. Hoy un `push` sería rechazado por `push.default simple`. Se recomienda `git branch --unset-upstream` antes de cualquier entrega.
7. **U-9.1 en el gestor compartido:** el gestor conserva el defecto de `OLLAMA_URL`. Está fuera del territorio y le toca al dueño.

## 6. Arreglos aplicados

Ninguno. Los fallos encontrados están en registros de sólo agregado, en archivos comunes o necesitan una decisión.
