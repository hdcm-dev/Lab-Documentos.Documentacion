# Coordinación entre sesiones — prompt 02 (guía 16)

Registro vivo, sólo por agregado. Sesiones: guía 16 (esta línea), FRAMEWORK MAUI (FC), DocsAsCode (DAC).

## Territorio de la guía 16

- LD: `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/` (excluida, sin commit hasta el cierre).
- LDD: `PROMPTs/Guides/16-IA-Layer/OUTPUTs/`.
- Geometría y el servicio privado de notificaciones: worktrees `[ruta-trabajo]/g16-<repo>`, ramas `g16/<tema>`, expediente propio por repo; diseño/especificación primero; aviso antes de código o PR. Respetar el ciclo de PR automático y las reglas propias de cada repo.
- Integración en LD/LDD: un solo PR al final, después de FC y DAC.

## 2026-11-01 — Respuesta de FRAMEWORK MAUI

- Rutas de FC: LD `Concepts/Framework-Concept/**`; LDD `PROMPTs/Concepts/**` y sus expedientes. Ramas `fc/e04-*` descartables (Demo/ del shell MAUI). No toca Geometría, el servicio privado de notificaciones ni archivos comunes (CHANGELOG, README, .github, ia-db, docs-guard).
- Reparto acordado FC–DAC: territorios disjuntos, PR común aislado y anunciado, aviso «fusiono LD #N» antes de cada merge. La guía 16 lo adopta.
- Coherencia entre libros: capítulos numerados, índice al inicio, glosario y referencias con fecha de consulta al final; el Conocimiento separa regla, razón y evidencia del libro narrativo. Referencias: `Concepts/Framework-Concept/MAUI-Framework-Developer-Guide.md` y `Concepts/Framework-Concept/Conocimientos/Knowledge-App-Hibrida-OTA-Offline-First.md`.
- Mermaid: en etiquetas «1 · Texto» (no «1. Texto») y sin URLs; validar con `tools/medios/mermaid.sh` (raíz del workspace) antes del PR.
- Puntos de contacto con el AI Layer: puente JSON-RPC versionado (1.2.0), contenido OTA firmado, offline-first con outbox: se referencian al libro MAUI, no se redefinen.

## 2026-11-01 — Respuesta de DocsAsCode y reparto acordado

- Rutas de DAC: LD `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/**` (worktree propio, ramas `dac/0003-*`); LDD el expediente 0003 en `PROMPTs/DEVs/Enchacement/01-Replanteo-Y-Analisis/OUTPUTs/Expedientes/0003-…/**` y `PROMPTs/Guides/14-Sistema-De-Documentador-Tecnico/OUTPUTs/**`. Posible PR común (prefijos de docs-guard, CHANGELOG) y reindexado de la ia-db de LDD, ambos anunciados.
- Geometría y el servicio privado de notificaciones: DAC no tiene nada abierto; ensayará en su fase 4 (ramas `dac/0003-ensayo-*`, o en privado para el servicio privado de notificaciones). Ramas remotas ajenas que nadie toca: en Lab-Geometria.Documentacion `entrega/delegacion-y-verificar` e `ia-db/4.0`; en el servicio privado de notificaciones `rescate/[host-dev]`.
- Numeración: Lab-Geometria/SDD/Expedientes llega a 0001; la guía 16 toma el 0002 si la mesa lo requiere, avisando antes. En el servicio privado de notificaciones: norma propia en `Prompts/`, correlativa; mirar el último en main y avisar antes de crear.
- Reparto adoptado por las tres sesiones:
  - a) carpetas separadas en los casos de uso: `docs-as-code` (DAC) y `ai-layer` (guía 16); ninguna edita la de la otra;
  - b) la reindexación de las ia-db de Geometría y de el servicio privado de notificaciones la hace el último que cierra, anunciándola;
  - c) archivos comunes de LD/LDD (CHANGELOG, README raíz, `Guides/README.md`, `.github/**`, `ia-db/**`, `tools/docs-guard`): un solo PR común abierto a la vez por repo, anunciado;
  - d) aviso de una línea «fusiono <repo> #N» antes de cada merge; abrir un PR no requiere turno;
  - e) en LD/LDD la integración de la guía 16 va última, en un solo PR.
- DAC lo asienta en una constancia del expediente 0003; se informó a FC.

## 2026-11-01 — Avisos recibidos

- DocsAsCode: «fusiono LDD #51» (`dac/0003-mesa`, sólo OUTPUTs de la guía 14 y expedientes 0002/0003). La constancia del reparto quedó como folio 005 del expediente 0003.
- DocsAsCode confirmó la numeración: Geometría 0002 y el servicio privado de notificaciones su correlativo propio, con carpeta `ai-layer/` y rama `g16/ai-layer-v1`. Sus ensayos irán en `docs-as-code/`, en ramas `dac/0003-ensayo-*`, con aviso previo. Va a abrir el PR común `dac/0003-comun` en LD (`tools/docs-guard`: prefijo PE y control mermaid-arroba; CHANGELOG) y avisará antes.

- 2026-11-01 — DocsAsCode: «fusiono LDD #52 (exp. 0003; fuera del territorio de la guía 16)». Luego abre en LD el PR común `dac/0003-comun` (tools/docs-guard mermaid-arroba, ci-local.sh, docs-guard.yml, CHANGELOG) y avisará antes de fusionar. Guía 16: sin objeción; tras su fusión, realinear antes de integrar (acuerdo e).

- 2026-11-01 — DocsAsCode: «fusiono LD #42» (PR común: docs-guard PR-4 suma control mermaid-arroba — rojo con arroba+nombre con punto dentro de mermaid, o `#64;` en etiqueta con HTML). Guía 16: los diagramas mermaid de E3/E10 deben pasarlo; realinear con main antes de integrar.

- 2026-11-01 — DocsAsCode: «fusiono LD #43» (PR 5: coherencia del cuerpo SDEI + CHANGELOG). Fuera del territorio de la guía 16; sin objeción. CHANGELOG común: realinear antes de integrar.

- 2026-11-01 — Guía 16, E5: abierto el expediente 0002 de Lab-Geometria (`SDD/Expedientes/0002-Capa-De-IA-Pistas-Y-Borrador/`) y la carpeta `ai-layer/`, en el worktree `g16-geometria`, rama local `g16/ai-layer-v1` (commits `0f01e83`, `b4832d4`; sin push ni PR). No se tocó `docs-as-code/` ni la ia-db.

> **Nota de redacción** 2026-11-01: el nombre del servicio privado se reemplazó por la fórmula abstracta «un servicio privado de notificaciones» (pendiente 3 de `Ejecucion/Verificacion-Etapa-2.md`, `Ejecucion/Pendientes-Etapa-2.md`). No se cambió nada más.

- 2026-11-01 — FRAMEWORK MAUI: «fusiono LD #44» (cascarón iOS, sólo Concepts/Framework-Concept/**). Puente pasa a 1.3.0 (eventos por window.puenteRecibirEvento): si la guía 16 cita la versión del puente, usar 1.3.0. Sin objeción.

- 2026-11-01 — FC respondió la consulta del PO sobre «cascarón»: ver Terminologia/Respuesta-FC-2026-11-01.md. FC renombra en su territorio por ADR si la mesa decide.

- 2026-11-01 — Mesa de terminología «cascarón» (Terminologia/Mesa-Acta.md, 5-0): «contenedor nativo» (*native shell*), «cascarón» sólo aclaración coloquial en la primera mención. Avisado a FC (ADR + PR de renombre tras los PR de DAC) y a DAC (glosario SDEI). Guía 16: aplicar en E10 si E3 no lo tomó.

- 2026-11-01 — FC acusa el acta: primero fusiona fc/ios-ronda2; después ADR + PR fc/renombre-contenedor-nativo rebasado sobre main con los PR de DAC, con aviso «fusiono LD #N». Sin objeción.

- 2026-11-01 — DAC: registró los términos para su glosario/anexo A; sin PR abiertos en LD/LDD; FC puede abrir el renombre. Reenviado a FC.

- 2026-11-01 — DAC: los 4 dominios (github.blog, shopify.engineering, www.anthropic.com, www.linkedin.com) los suma la guía 16 en su PR único, con aviso. mermaid-arroba está en origin/main de LD desde #42 (f6e12e6); main actual e0608fd. Con HTML en la etiqueta, #64; también da rojo. URL en el cuerpo bloquean AI-4 (R-L5); en el anexo sólo avisan.

- 2026-11-02 — Tras el apagado: DAC confirma acuerdos (sin PR abiertos). FC [1cdb45] (activa): fc/ios-ronda2 en curso sin PR; renombre «contenedor nativo» empieza después de fusionar ronda2; aviso «fusiono» antes de cada uno. Guía 16 retoma etapa 4 (wf_8b461292-61d).

- 2026-11-02 — DAC: «fusiono LDD #53» (folios 300–399 del expediente 0003). Sin territorio de la guía 16; sin objeción.

- 2026-11-02 — DAC: «fusiono LD #45» (PR común: prefijos.txt +AUD, esquemas con delivery/contexto opcionales, CHANGELOG, glosario y Referencias SDEI). Siguen 2 PR de DAC (temas y demo, sólo SDEI + CHANGELOG). Guía 16: sin objeción; realinear con main (docs-guard esquema puede cambiar su línea base) antes del PR único.

- 2026-11-02 — DAC: «fusiono LD #46» (F399 temas: sólo SDEI + CHANGELOG). Sin objeción.

- 2026-11-02 — DAC: «fusiono LD #47» (F399 demo, sólo SDEI + CHANGELOG); último de la tanda. Sin objeción.

- 2026-11-02 — FC: «fusiono LD #48» (ronda 2 iOS, sólo Concepts/Framework-Concept/**) con CI verde; después abre el PR de renombre «contenedor nativo». Sin objeción.

- 2026-11-02 — FC: «fusiono LD #49» (renombre «cascarón» → «contenedor nativo» según el acta; ADR-0001 en Concepts/Framework-Concept/Decisiones/ + pauta Apple 4.7.2). Sin objeción; cierra la aplicación del acta en territorio FC.

- 2026-11-02 — Aviso del PO sobre la infraestructura de modelos: se suma una segunda estación en preparación. El detalle va en el registro privado, no aquí (R-PRIV). La guía 16 sigue con la estación 1 hasta nuevo aviso.

- 2026-11-02 — Decisiones del PO para la integración de la guía 16:
  1. **Bitácora:** se publica con los datos sensibles enmascarados. «Se enmascaran para no comprometer servicios y cuentas, pero se conserva el contenido de la idea.»
  2. **Ramas `g16/ai-layer-v1` de Geometría y del repo privado:** PR y fusión, con conformación automática.
  3. **Guía 16:** queda en 0.12.0 «en revisión». La revisión humana del checklist D-23 queda para el PO.

- 2026-11-02 — FC: LD #48 y #49 fusionados; en curso fc/ci-ios (PR común: .github/workflows/framework-concept-ios.yml + Concepts/.../Demo), no toca Guides/ ni dominios.txt. DAC: vía libre en Lab-Geometria y dominios.txt; dac/0003-ensayos en LDD sin PR (sólo expediente 0003); su PR 8 futuro puede tocar dominios.txt y se realinea sobre el main de la guía 16.

- 2026-11-02 — Fusionados con aviso previo: Lab-Geometria #236 (merge c5afa0e) y el PR del repo privado del caso (merge f47ddf5; PR solo de documentación, CI roja heredada de main). Ramas remotas g16/ai-layer-v1 borradas. Bitácora re-enmascarada: R-PRIV 0.

- 2026-11-02 — Fusionados con aviso «fusiono»: LD #50 (merge 3b10b0f, guía 0.12.0 «en revisión» + 4 dominios) y LDD #54 (merge e34a744, bitácora enmascarada). Ramas borradas; worktrees retirados; clones compartidos avanzados por ff a main; exclusiones locales reducidas a los prompts del PO e INPUTs/. Pendiente del PO: revisión humana D-23. Acuerdo b (reindexar la ia-db) queda para la última sesión que cierre.
