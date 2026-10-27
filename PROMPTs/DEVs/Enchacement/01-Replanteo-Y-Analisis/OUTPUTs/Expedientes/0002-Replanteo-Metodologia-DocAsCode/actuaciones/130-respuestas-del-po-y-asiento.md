---
doc_id: EXP0002-F130
doc_type: providencia
title: Respuestas del PO al lote L1–L13 y su asiento (D08 FIRME por C2-5; L10 verificada; L11 pendiente del PO)
status: vigente
origin: agent
confidence: alta en los testimonios (literales) y en la verificación de L10 (archivos leídos); media en la lectura de alcance de L2 sobre los primeros merges, que cita el pedido explícito del PO
owner: presidencia de la mesa de Replanteo y análisis DocAsCode (despacho P30)
last_review: 2026-10-27
audience: [PO, presidencia, agentes que implementen E1, bitacorista]
traces: [EXP0002-F099, EXP0002-F100, EXP0002-F129, N10]
---

# 130 — Respuestas del PO y asiento

| Campo | Valor |
| --- | --- |
| Tipo | providencia (asiento de respuestas del PO) |
| Fecha | 2026-10-27 |
| Autor | Presidencia (despacho P30) |
| Corrige | `129` §3 (estado de D08) y §7 (lo que queda para el PO); `N10` §14 (conformación y L10). `129` no se edita |

## Índice

1. [Definiciones](#1-definiciones)
2. [Testimonios literales](#2-testimonios-literales)
3. [Asiento por fila](#3-asiento-por-fila)
4. [D08 pasa a FIRME](#4-d08-pasa-a-firme)
5. [Verificación de L10](#5-verificación-de-l10)
6. [L11: pendiente del PO](#6-l11-pendiente-del-po)
7. [Lecciones de decisión](#7-lecciones-de-decisión)
8. [Lo no verificado](#8-lo-no-verificado)

## 1. Definiciones

- **Testimonio**: texto del PO transcripto sin corregir, con su fecha; es la fuente de la que nace cada asiento.
- **Asiento**: registro de la presidencia que da efecto a un testimonio sobre una fila del lote (`099` §9; `129` §4.2).
- **C2-5**: condición de paso a FIRME de D08 (`129` §3): el PO asienta por escrito la delegación de L2.
- **CPA**: `Knowledge-Conformacion-Pull-Request-Automatico` (guarda G1–G4, merge atado al SHA).

## 2. Testimonios literales

Fecha de todos: 2026-10-27. Se transcriben sin corrección ortográfica.

| Fila | Testimonio |
| --- | --- |
| L2 | «esto surgió porque despues de un avance surgia preguntas y confirmaciones tontas … Mi objetivo es que se enriquesca de tal forma el conocimiento analitico que los subagentes con este conocimiento puedan orquestar de forma automatica todo el proceso de desarrollo» |
| L3, L4 | «si hay un ADR que te traba, tenes permiso de modificarlo … la documentación es un aditicional … podría darse una ADR Consecuente que ratifique esa decisión … no debiste caer en preguntarme» |
| L7 | «estoy de acuerdo en "Sí"» |
| L10 | «[SDD-B] creo que esta dentro de la organizacion de [organización del SDD-B] - esa organizacion tiene sus runner, creo que se llama {runner-del-SDD-B}, y creo que tienen acceso a la api de IA que tenemos funcionando en i7infra - revisa esto» |
| L1, L5, L6, L8, L9, L12, L13 | «que la mesa evalue y tome la mejor decisión» |
| L11 | El PO pidió instrucciones; se le dieron (§6) |

**Objetivo de fondo declarado**: autonomía. No se eleva al PO lo que un análisis resuelve; sólo lo irreversible con
consecuencia externa, con sugerencias y default.

## 3. Asiento por fila

| Fila | Asiento | Efecto |
| --- | --- | --- |
| L2 | Delegación del merge **asentada por escrito**; alcanza a P por la guarda (D08 alternativa_2) y al primer merge de cada repo (U0a, U0b, U2, U4e, U6), por pedido explícito del PO | Todo PR de E1 se fusiona por `CPA`; cada PR de primer merge cita este folio §2 como testimonio |
| L3, L4 | Permiso de modificar ADR propios que traben; preferencia por **ADR consecuente** que ratifique o supere la decisión | D23 deja de depender de respuesta; E2-U2 redacta el ADR consecuente y lo acepta por su delegación |
| L7 | Sí | E1-U6 abre la propuesta de expediente en Lab-E2E.WebBlazor; D25 sigue con la demo en `Examples/` hasta que ese expediente autorice tocar código |
| L10 | Sí, con dato del PO verificado (§5) | E3-U4 usa `runs-on: [self-hosted, {runner-del-SDD-B}, ...]` |
| L11 | Pendiente, acto del PO | Rigen las mitigaciones de §6 |
| L1, L5, L6, L8, L9, L12, L13 | Delegadas a la mesa | Folio `131` |

## 4. D08 pasa a FIRME

La condición C2-5 (`129` §3) se cumple por la primera rama: el PO asentó por escrito la delegación (§2, L2). D08 pasa
de CON REVISIÓN a **FIRME** desde esta fecha. La condición alternativa (E1-G sin objeción) queda sin objeto. La lista H
de D08 (C2-2) se reduce a lo irreversible con consecuencia externa: configuración de organización (L11), publicación de
paquetes o tags de producto ajenos al caso y compras (L9).

## 5. Verificación de L10

Verificada por la presidencia el 2026-10-27 con lectura directa:

| Hecho | Evidencia |
| --- | --- |
| El SDD-B pertenece a la organización del PO indicada | Remoto del clon local: `{organización-del-SDD-B}/<repo del SDD-B>` |
| Sus workflows usan el runner de esa organización | `runs-on: [self-hosted, {runner-del-SDD-B}, dotnet]` en el workflow de CI del repo |
| El runner existe y está registrado en esa organización | README del repo de servicios de runners, tabla de instancias: instancia `ng`, contenedor `{contenedor-del-runner-del-SDD-B}`, organización `{organización-del-SDD-B}`, etiqueta `{runner-del-SDD-B}` |
| El runner alcanza la IA local | `docker-compose.yml` de `{contenedor-del-runner-del-SDD-B}`: dos redes, una de ellas la macvlan de infraestructura «la LAN de la infraestructura, la IA local» |

**Conclusión**: para E3 la etiqueta es `{runner-del-SDD-B}`. G-b de E3 se mide en ese runner. El hecho de alcanzar la IA local
habilita, si E3 lo necesita, controles con modelo local; no es requisito de E1.

## 6. L11: pendiente del PO

Instrucciones dadas al PO (acto H, configuración de la organización):

1. Activar la aprobación obligatoria de corridas de workflows desde forks (Settings → Actions → General).
2. Fijar los permisos por defecto del `GITHUB_TOKEN` en *read*.
3. Crear un runner group acotado a los repos elegidos y declararlo en la variable `RUNNER_GROUP` del `.env` de la
   instancia del runner.

**Mientras tanto** (mitigación vigente en todo workflow del caso): guarda
`if: github.event.pull_request.head.repo.full_name == github.repository`, sin `pull_request_target`, actions fijadas
por SHA, `permissions: contents: read`. El riesgo residual (el runner no queda protegido por la guarda) sigue declarado.

## 7. Lecciones de decisión

| Id | Decisión | Nivel | Criterio | Lección |
| --- | --- | --- | --- | --- |
| LD-01 | Leer L2 como delegación también del primer merge | N1 análisis | Testimonio §2 y objetivo de autonomía | Cuando el PO declara un objetivo de autonomía, se aplica a toda la clase de actos reversibles que nombra, no sólo a la fila literal |
| LD-02 | Verificar L10 antes de asentarla | N1 | «revisa esto» del PO; evidencia antes de declarar | Un dato del PO con «creo» se verifica con archivos y se asienta con la evidencia, no se vuelve a preguntar |
| LD-03 | ADR consecuente en lugar de consulta | N1 | Testimonio L3/L4 | Un ADR propio que choca se resuelve con un ADR consecuente; no es materia de lote |

## 8. Lo no verificado

- La configuración real de la organización (L11) no se pudo leer sin credencial de administración.
- El acceso efectivo del runner a la API de IA se infiere de la red declarada; no se hizo una corrida de prueba.
