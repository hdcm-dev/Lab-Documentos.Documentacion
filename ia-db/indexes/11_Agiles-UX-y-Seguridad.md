# 11 · Métodos ágiles, UX/UI/DX y seguridad en Windows

> **Propósito**: inventario y destilado de tres carpetas de guías que **no** usan el aparato de las
> familias propias (salvo la de seguridad): `Guides/Metodologia-Agiles/` (Scrum + Jira),
> `Guides/UX-UI-Design/` (marco teórico UX/UI/DX + guía de documentación UX) y `Guides/Otros/`
> (auditoría de seguridad en un servidor Windows + cuaderno). Incluye `Guides/README.md` como
> **mapa de categorías** de todo `Guides/`.
> **Fuente primaria**: los encabezados «Documento / Versión / Fecha / Estado», índices internos y
> «Control de Cambios» de cada archivo; para la guía de seguridad y para `Guides/README.md`, su
> frontmatter YAML.
> **Base**: `Lab-Documentos` en `main` 34929f2. Todas las rutas son relativas a `Lab-Documentos/`.
> 10 archivos: 9 `.md` (7 914 líneas, `wc -l`) + 1 PDF.

## Advertencias de lectura

- **Sin `doc_id`** en Ágiles y UX: se identifican por ruta. Los IDs que aparecen (`US-xx`, `EP-xx`,
  `BT-xx`, `NB-xx`, `CU-xx`, `SA-xx`, `AG-xx`, `FU-xx`, `WF-xx`) son del **proyecto de origen**
  (Motor DSL / `Ejemplo_IA_SDD_Template`) o ilustrativos; no remiten a documentos de este repo.
- El archivo grande de Jira tiene un **espacio inicial** en el nombre:
  `Guides/Metodologia-Agiles/Scrum-Guide/ Metodologias-Agiles-Jira-Guide.md`. En la shell, citalo
  entre comillas (H-11.01).
- Las rutas `docs/NN_…` y `devs/…` que citan las guías ágiles son del template de origen y **no
  existen acá** (H-11.06).
- Las salidas de comandos de la guía de seguridad son **ilustrativas** (escenario ficticio
  `SRV-MADERA01`), no capturas reales (guía, «Aviso sobre las salidas mostradas»).

## Inventario

| Ruta | doc_id | Versión · fecha | Estado | Líneas | Qué es |
|---|---|---|---|---|---|
| `Guides/README.md` | `GUIAS-INDICE` (`indice`) | last_review 2026-10-28 | vigente | 31 | Índice de `Guides/` por categoría (tabla de 9 filas) |
| `Guides/Metodologia-Agiles/Scrum-Guide/ Metodologias-Agiles-Jira-Guide.md` | — | cabecera 1.0; control de cambios hasta 1.5 · 2026-04-13/14 | Activo | 2 836 | Referencia: métodos ágiles (Parte 1) + Jira (Parte 2) + §16 técnicas + §17 arranque |
| `Guides/Metodologia-Agiles/Scrum-Guide/Estudio-Guide.md` | — | cabecera 1.0; control de cambios 1.1 · 2026-04-15 | — | 594 | «Cómo arrancar un proyecto con Scrum», por ejemplos |
| `Guides/Metodologia-Agiles/Scrum-Guide/Caso-De-Estudio-1-Guide.md` | — | 1.0 · 2026-04-15 | — | 139 | Corrección de US de impresión de tickets desde una app MAUI híbrida |
| `Guides/Metodologia-Agiles/Scrum-Guide/guia-organizacion-proyecto-jira.md` | — | 1.0 · 2026-04-14 | — | 721 | Paso a paso para dar de alta y organizar un proyecto en Jira |
| `Guides/Metodologia-Agiles/Scrum-Guide/2020-Scrum-Guide-US.pdf` | — | 2020 | — | (binario) | Scrum Guide oficial en inglés. **Inventariado, no leído** |
| `Guides/UX-UI-Design/UX-UI-Guide/UX-UI-Guide.md` | — | 1.0 · 2026-04-25 | Aprobado | 1 714 | **Marco teórico UX/UI/DX** (12 capítulos + 3 apéndices, APA 7, audiencia UTN) |
| `Guides/UX-UI-Design/UX-UI-Guide/metodologia-uix-ux.md` | — | 1.0 · 2026-04-25 | **Borrador** | 324 | Qué documentar en la sección UX de un proyecto SDD (flujos, wireframes, guía de experiencia) |
| `Guides/Otros/Seguridad-Red-Windows-Guide/Beginning-Security-Windows-Network-Guide.md` | `GUIA-PRINCIPAL` (`guia-estudio`) | last_review 2026-09-18 | vigente | 1 292 | Auditoría de seguridad e investigación de intrusiones en un servidor Windows |
| `Guides/Otros/Seguridad-Red-Windows-Guide/Cuaderno-Ejercicios-Seguridad-Windows.md` | `CUADERNO` (`cuaderno-ejercicios`) | last_review 2026-09-18 | vigente | 263 | 9 bloques de ejercicios + proyecto integrador + soluciones |

Historia (`git log`): las tres carpetas tomaron su ubicación actual en 82b2fe1 (2026-09-28,
«reorganización de Guides/ por categoría»). La guía de seguridad entró en 9401ad5 (2026-09-17,
PR #5) y se regeneró en 85e6099 (2026-09-18, «escenario 2019, mesa»). `Guides/README.md` se
retocó en 69c80c7 (2026-10-29, saca una traza ambigua a `GUIA-INDICE`) y por última vez en 4510b22
(2026-11-04, cambia la traza `DOC-SDT-0001` por `IDX-SDEI`).

## Estructura de carpetas

```text
Guides/
├── README.md                         ← GUIAS-INDICE: mapa de categorías
├── Metodologia-Agiles/
│   └── Scrum-Guide/
│       ├── " Metodologias-Agiles-Jira-Guide.md"   (espacio inicial)
│       ├── Estudio-Guide.md
│       ├── Caso-De-Estudio-1-Guide.md
│       ├── guia-organizacion-proyecto-jira.md
│       └── 2020-Scrum-Guide-US.pdf
├── UX-UI-Design/
│   └── UX-UI-Guide/
│       ├── UX-UI-Guide.md
│       └── metodologia-uix-ux.md
└── Otros/
    └── Seguridad-Red-Windows-Guide/
        ├── Beginning-Security-Windows-Network-Guide.md
        └── Cuaderno-Ejercicios-Seguridad-Windows.md
```

Ninguna de las tres carpetas tiene `README.md` propio (H-11.10).

## 1. `Guides/README.md` — mapa de categorías

Frontmatter: `doc_id: GUIAS-INDICE`, `doc_type: indice`, `origin: ia-generated`, `owner: ACT-09
Technical Writer`, `traces: [LAB-DOCUMENTOS-README, IDX-SDEI]` (ambas resuelven: `README.md` raíz y
`Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/README.md`). Remite a la ruta
de lectura del README del repositorio.

| Categoría | Destinos que enlaza |
|---|---|
| Documentación técnica | `Documentacion-Tecnica/Creacion-Guias-Tecnicas/README.md` · `Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/README.md` (únicos enlaces a archivo) |
| Arquitectura | `Arquitectura/` · `Dot-NET-Arquitectura-Guide/` (carpeta hermana, no hija de `Arquitectura/`) |
| Despliegue | `Despliegue/` |
| Control de versiones | `GitFlow/` |
| IA | `IA/` |
| Metodologías | `Metodologia-Agiles/` · `Metodologia-Entorno-Desarrollo/` |
| Pruebas | `Testing/` |
| UX/UI | `UX-UI-Design/` |
| Otros | `Otros/` |

Todos los enlaces resuelven en 34929f2. Salvo la primera fila, enlazan **carpetas** sin README
propio: en GitHub se ve el listado de archivos, no una portada (H-11.10). No cubre `Concepts/`
(está fuera de `Guides/`).

## 2. Métodos ágiles y Jira (`Guides/Metodologia-Agiles/Scrum-Guide/`)

### 2.1 Orden de lectura sugerido

| Paso | Archivo | Para qué |
|---|---|---|
| 1 | `Estudio-Guide.md` | Arrancar un backlog desde cero con ejemplos completos |
| 2 | `Caso-De-Estudio-1-Guide.md` | Ejercitar la corrección de US mal escritas (antes/después) |
| 3 | `guia-organizacion-proyecto-jira.md` | Llevarlo a Jira paso a paso |
| 4 | ` Metodologias-Agiles-Jira-Guide.md` | Consulta de referencia (teoría, Jira a fondo, técnicas) |
| — | `2020-Scrum-Guide-US.pdf` | Fuente normativa de Scrum (no enlazada desde ningún `.md`) |

El orden es una propuesta de este índice (sin verificar como intención de los autores): ningún
archivo declara secuencia entre ellos.

### 2.2 ` Metodologias-Agiles-Jira-Guide.md` — mapa (2 836 líneas)

| Parte · § | Tema | Qué responde |
|---|---|---|
| P1 · §1 | Propósito; §1.3 relación con la cadena SDD | Las metodologías gobiernan **cómo** se ejecuta desde el Product Backlog hacia abajo |
| P1 · §2 | Manifiesto: 4 valores, 12 principios, historia, Waterfall vs Ágil | |
| P1 · §3 | Scrum: pilares, valores, roles (PO, SM, Dev Team), artefactos, eventos, sprint, diagrama del ciclo | |
| P1 · §4 | Kanban: principios, tablero, métricas, Scrum vs Kanban (§4.5), cuándo elegirlo (§4.6) | |
| P1 · §5 | XP, SAFe, LeSS, Scrumban + tabla comparativa (§5.5) | |
| P1 · §6 | US, épicas y tareas: vocabulario, formato estándar, INVEST, Given/When/Then, jerarquía, estimación, priorización | ¿Cómo redacto y ordeno una US? |
| P1 · §7–§8 | Métricas ágiles (velocity, burndown, burnup, CFD, lead/cycle time) · anti-patrones | |
| P2 · §9–§10 | Jira: conceptos, tipos de proyecto (§9.3), Jira vs alternativas (§9.4), tipos de issue, campos, **prioridades ↔ MoSCoW** (§10.3), workflow, nomenclatura (§10.5) | |
| P2 · §11 | Alta de proyecto Scrum: board, backlog, sprints, epics, Fix Versions, componentes | |
| P2 · §12 | Flujo diario: planning, daily, review, retro, refinamiento + diagrama (§12.7) | |
| P2 · §13 | Reportes: velocity, burndown, sprint report, CFD, control chart, dashboards, **JQL** (§13.7) | |
| P2 · §14 | Fix Versions como hitos, Release Hub, release notes; **§14.6 mapeo SDD → Jira** | ¿Dónde va cada artefacto SDD en Jira? |
| P2 · §15 | Integraciones: Git, CI/CD, Confluence, Slack/Teams, automatizaciones | |
| §16 | Técnicas: vertical slicing, walking skeleton, thin slice/tracer bullet, story mapping, example mapping, spike, ATDD, mob programming, Shape Up, impact mapping, dual-track; **§16.13 tabla situación → técnica** | ¿Qué técnica uso en esta situación? |
| §17 | Arranque: diagnóstico (§17.1), elección de metodología (§17.2), checklist Sprint 0 (§17.3), **§17.4 orden de artefactos**, errores frecuentes (§17.5) | ¿Por dónde empiezo? |

Cada técnica de §16 trae un ejemplo del **Motor DSL** y otro «en contexto web» (e-commerce,
SaaS, fintech, delivery).

**§14.6 Mapeo SDD → Jira** (destilado): fase del roadmap → Fix Version · Épica → Epic ·
US → Story · BT → Sub-task/Task · Sprint Plan → Sprint · NB → Initiative/Theme (o Label) ·
CU → linked issue o Label · DoR → checklist en la Story · DoD → condiciones de transición a Done ·
review → Sprint Report · retro → issues de mejora · velocity → Velocity Chart.

**§17.4 Orden de construcción**: Visión → Épicas → Story Map (MVP = capa mínima) → US priorizadas
MoSCoW → DoR y DoD → … (cada artefacto depende del anterior).

### 2.3 Las otras tres piezas

| Archivo | Estructura | Idea central |
|---|---|---|
| `Estudio-Guide.md` | §1 cuándo estás listo (3 insumos ↔ AG-00 / AG-01 / AG-02-03) · §2 Product Backlog en 4 pasos (visión, épicas, US + MoSCoW, DoR/DoD) · §3 ejemplos A clínica / B ferretería / C cursos online, con criterios de aceptación por US · §4 agrupar el backlog en épicas (`EP-01…05`) · §5 criterios de épica · §6 el patrón que se repite | Una épica es una **capacidad funcional completa**; tres criterios formales: independencia, tamaño mayor a un sprint, cohesión (§5). Primero la capacidad, después quién la usa |
| `Caso-De-Estudio-1-Guide.md` | §1 caso · §2 US y escenarios originales · §3 cuatro problemas · §4 reescritura con criterios de aceptación US-01…03 · §5 resumen | Errores típicos: actor técnico en vez de rol de usuario, US que mezclan implementación con necesidad, escenarios sueltos sin US, falta de estructura |
| `guia-organizacion-proyecto-jira.md` | P1 elementos de Jira (conceptos, tipos de issue, jerarquía, campos, MoSCoW, workflow, métricas, JQL) · P2 metodologías que propone Jira + técnicas de descomposición · P3 alta paso a paso (3.1–3.10) · P4 ejemplos: e-commerce, app de delivery, SaaS CRM, Motor DSL · anti-patrones | Versión operativa y resumida de la guía grande; declara basarse en `devs/metodos-agiles/metodologias-agiles-jira.md` del template |

Anti-patrones de Jira (tabla final de `guia-organizacion-proyecto-jira.md`): todo «Must»,
épicas sin descomponer, board fantasma, sprint elástico, refinamiento inexistente, daily
eterna, velocity como KPI individual, US redactada como tarea técnica.

## 3. UX/UI/DX (`Guides/UX-UI-Design/UX-UI-Guide/`)

### 3.1 `UX-UI-Guide.md` — Marco teórico (1 714 líneas)

Postura (§1.2): UX, UI y DX son **un continuo**; DX es UX cuando el humano es un desarrollador y la
interfaz es código, contratos, errores y documentación. Rutas de lectura (§1.3) por perfil:
diseñador, desarrollador/integrador de APIs, auditor académico.

| § | Tema | Cuadro |
|---|---|---|
| 1 | Encuadre; preguntas guía de redacción (§1.4, retomadas en el checklist §12.2) | |
| 2 | Nueve disciplinas: HCI, usabilidad, UX, UI, IxD, arquitectura de información, accesibilidad, service design, DX | C1 §2.10 |
| 3 | Procesos: Garrett (5 planos), Doble Diamante, Design Thinking, Lean UX, Design Sprint; criterios de selección (§3.7) | C2 §3.6 |
| 4 | 10 heurísticas de Nielsen, 8 reglas de oro de Shneiderman, leyes psicológicas y de interacción | C3 §4.4 |
| 5 | ISO 9241-210:2019, ISO 9241-11:2018, **WCAG 2.2**, WAI-ARIA 1.2, IEEE 1063 / ISO/IEC 26514 | C4 (en §5.3) |
| 6 | Sistemas de diseño: Atomic Design, ITCSS, Material 3 / HIG / Carbon / Polaris | C5 §6.4 |
| 7 | Investigación cualitativa y cuantitativa, métricas estandarizadas | C6 §7.4 |
| 8 | Web: paradigmas de respuesta, Core Web Vitals, IA aplicada, patrones UI, CSS, accesibilidad, forms inline vs on-submit, microinteracciones, casos, antipatrones | C7 §8.7.1 |
| 9 | Móvil: mobile first, tipos de app, Material 3 vs HIG, ergonomía táctil, navegación, inputs, performance, accesibilidad, notificaciones, antipatrones | C8 §9.5.1 |
| 10 | **DX en REST APIs**: métricas, estándares, modelos de error, patrones, versionado URL vs header, Diátaxis | C9 §10.4.2, C10 §10.6.1 |
| 11 | Caso Motor DSL multi-target: mapa de usuarios, renderizado, WCAG 2.2 AA en el preview, **tolerancia formal preview ↔ output físico** | |
| 12 | Tabla maestra pilar × proceso × norma × métrica (§12.1); checklist verificativo (§12.2) | |
| A–C | Glosario · Bibliografía (B.1–B.10, APA 7) · Índice de cuadros | |

Decisiones y criterios que conviene recordar:

- **Versionado de API** (§10.6): URL path para APIs públicas con breaking changes poco
  frecuentes; header con fecha (estilo Stripe) para SaaS con cambios frecuentes; query `?v=`
  desaconsejado.
- **Tolerancias formales en vez de buenas intenciones** (§11.5–§11.6): el preview no es WYSIWYG
  estricto y eso se declara con tolerancias medibles.
- **Validación de formularios** (§8.7): inline vs on-submit, con variante híbrida (Cuadro 7).
- **Documentación como interfaz** (§10.7): Diátaxis aplicado a la DX.

### 3.2 `metodologia-uix-ux.md` — Qué documentar en la sección UX (Borrador)

| § | Contenido |
|---|---|
| 1 | Los tres artefactos de la sección: `flujos-de-usuario_v1.0.md` · `wireframes-descripcion_v1.0.md` · `guia-experiencia_v1.0.md` |
| 2 | Inputs: los que vienen de los CU del análisis funcional (`SA-02`) y los que hay que pedir al cliente; preguntas concretas antes de empezar |
| 3 | Plantillas normalizadas: flujos `FU-xx` (estilo Nielsen Norman Group: happy path, alternativos, error paths, diagrama textual), wireframes `WF-xx` (propósito, layout, componentes, estados vacío/carga/datos/error, notas, captura), guía de experiencia (principios, patrones, tono y voz, accesibilidad mínima, identidad visual) |
| 4 | Articulación en la cadena: la arquitectura no puede diseñar la API sin los flujos |

Llama `SA-03` a la sección UX; cita un `rules.md` que no está en el repo (H-11.07).

## 4. Seguridad en red Windows (`Guides/Otros/Seguridad-Red-Windows-Guide/`)

Única pieza de este índice con **frontmatter YAML** de guía (`doc_id`, `doc_type`, `title`,
`status`, `origin: ia-assisted`, `confidence: alta`, `owner`, `last_review`, `audience`, `traces`).
`traces` de la guía: `[ESC-TESTIGO, ESC-CORPUS, CUADERNO]`; del cuaderno: `[GUIA-PRINCIPAL,
ESC-TESTIGO]`. `ESC-TESTIGO` y `ESC-CORPUS` **no** resuelven dentro de `Lab-Documentos` (H-11.08).

### 4.1 Guía (`GUIA-PRINCIPAL`)

Para quien sospecha que su servidor Windows fue intervenido y **no** tiene formación en redes ni en
sistemas operativos: cada término se define antes de usarse y cada comando dice qué se espera ver.
Recorrido: entender → preservar evidencia → leer registros → reconstruir → reproducir el ataque en
laboratorio.

| § | Tema | Clave |
|---|---|---|
| 1 | Qué vas a auditar: red/IP/puerto, AD y DC, **escenario `SRV-MADERA01`** (§1.4), cuentas y privilegios, tipos de logon, línea de base | Escenario ficticio: Windows Server 2019, DC + archivos + facturación, dominio `maderasur.local`, RDP publicado a internet |
| 2 | Modelo de seguridad en cinco ideas: todo puede registrarse, Event ID, SID, correlación, el atacante también lo sabe | |
| 3 | **Reglas de no daño**: problema del observador, orden de volatilidad (RFC 3227), mínima alteración, NIST SP 800-61, cuándo no seguir solo | |
| 4 | Registro de eventos: anatomía, cómo leer los comandos, Visor / `Get-WinEvent` / `wevtutil`, reloj y zona horaria | |
| 5 | Accesos: **4624** (logon y Logon Types), **4625** (fallos, fuerza bruta), **1102** (borrado del log), el silencio como evidencia | |
| 6 | Persistencia: cuentas, servicios, tareas programadas, Autoruns | |
| 7 | Lo vivo ahora: conexiones, procesos, sesiones | |
| 8 | Hacer que el sistema registre lo que hoy no registra (auditoría avanzada, Sysmon, WEF) | |
| 9 | Método de caza: juntar todo en un relato con evidencia | |
| 10 | Pentesting I: encuadre, ética, laboratorio aislado | Autorización escrita o laboratorio propio |
| 11 | Pentesting II: herramientas de la industria y la huella que dejan | «Atacar para aprender a defender» |
| A | Montar y usar el laboratorio paso a paso | Generar la evidencia como atacante, investigar como defensor |
| 12–13 | Referencias (documentación oficial) · Glosario | Glosario: DCSync, Kerberos, NTLM, LSASS, SID, Sysmon, WEF, MITRE ATT&CK… |

Orden físico: el **Apéndice A** (l. 1140) está **antes** de §12 y §13 en el archivo, aunque el
índice interno lo lista al final (H-11.09).

### 4.2 Cuaderno (`CUADERNO`)

9 bloques alineados con la guía (§1–2, §3, §4, §5, §6, §7, §8, §9, §10–11), dos tipos de
ejercicio: **lectura** (sobre `SRV-MADERA01`, sin Windows) y **laboratorio** (marcados 🧪, sobre el
laboratorio del Apéndice A). Cierra con **proyecto integrador** y **Soluciones** explicadas por
bloque. Regla de oro: laboratorio aislado o autorización escrita, nunca sistemas ajenos.

## Ejemplos y laboratorios del dominio

No hay código ejecutable en estas tres carpetas. Lo práctico es:

| Material | Cómo se usa |
|---|---|
| Ejemplos A/B/C de `Estudio-Guide.md` | Backlogs completos (visión, épicas, MoSCoW, DoR, DoD, criterios) en tres dominios |
| P4 de `guia-organizacion-proyecto-jira.md` | Proyectos Jira de referencia: e-commerce, delivery, CRM, Motor DSL |
| `Caso-De-Estudio-1-Guide.md` | Ejercicio de corrección de US (antes/después) |
| Plantillas §3 de `metodologia-uix-ux.md` | Esqueletos `FU-xx` / `WF-xx` / guía de experiencia para copiar |
| Laboratorio de seguridad (guía §10 y Apéndice A; cuaderno) | VMs aisladas; generar la evidencia como atacante y reconstruirla como defensor |

## Relaciones con otras guías del repo

| Tema de este dominio | Dónde lo trata el corpus propio |
|---|---|
| Scrum, Kanban, Canvas como productores de documentación | `Guides/Documentacion-Tecnica/Creacion-Guias-Tecnicas/80-Metodos-Agiles/` (`MET-SCRUM` en `Scrum.md`, más `Kanban.md`, `Canvas.md`, `Comparativa-y-Criterios.md`, `Manifiesto-y-Documentacion.md`, `README.md`) |
| Perfil de agente Scrum Master (AG-06) | `Guides/IA/references/agentes-especialidades/AG-06-scrum-master.md` |
| UX y flujo de usuario como sección documental | `Guides/Documentacion-Tecnica/Creacion-Guias-Tecnicas/95-Transversales/UX-UI-y-Flujo-de-Usuario.md` (`DOC-UX`) |
| DX de APIs (cap. 10 del marco UX) | `Guides/Arquitectura/Organizacion-Estilo-Rest-API/95-Transversales/Experiencia-del-Consumidor.md` (`TEM-DX`) |
| Seguridad de aplicaciones (no de servidor) | `Guides/Arquitectura/Organizacion-Estilo-Rest-API/70-Seguridad-y-Robustez/` (`FAM-SEG`) · `Guides/Documentacion-Tecnica/Creacion-Guias-Tecnicas/30-Arquitectura/Arquitectura-de-Seguridad.md` (`DOC-SECARQ`) |
| Mapa general de lectura | `README.md` raíz (`LAB-DOCUMENTOS-README`) |

La guía de seguridad Windows es **operativa/forense** (servidor, eventos, persistencia); las de
`70-Seguridad-y-Robustez/` y `DOC-SECARQ` son de **diseño** de aplicaciones. No se enlazan entre sí.

## Estado y vigencia

| Pieza | Vigencia |
|---|---|
| Guía de seguridad + cuaderno | `status: vigente`, la más reciente del dominio (2026-09-18) |
| `Guides/README.md` | `vigente`, revisado 2026-10-28 |
| `UX-UI-Guide.md` | «Aprobado» (abril 2026), sin revisión posterior |
| `metodologia-uix-ux.md` | «Borrador»; depende de un `rules.md` ausente |
| Guías ágiles | «Activo» o sin estado; abril 2026; atadas al template Motor DSL |
| Solapamiento | `guia-organizacion-proyecto-jira.md` resume la P2 de la guía grande (no es copia literal) |

## Hallazgos del dominio

| ID | Tipo | Ruta | Detalle |
|---|---|---|---|
| H-11.01 | nombre-raro | `Guides/Metodologia-Agiles/Scrum-Guide/ Metodologias-Agiles-Jira-Guide.md` | Espacio **inicial** en el nombre; la cabecera lo declara sin espacio |
| H-11.02 | version-contradictoria | ` Metodologias-Agiles-Jira-Guide.md`, `Estudio-Guide.md` | Cabecera «Versión 1.0», pero el control de cambios llega a 1.5 y 1.1 |
| H-11.03 | nombre-declarado-distinto | `Estudio-Guide.md`, `Caso-De-Estudio-1-Guide.md`, `UX-UI-Guide.md`, `metodologia-uix-ux.md` | Nombre declarado ≠ archivo: `guia-de-estudio.md`, `caso-de-estudio-1.md`; pie de `UX-UI-Guide.md` → `marco-teorico-ux-ui_v1.0.md`; pie de `metodologia-uix-ux.md` → `SA-03_guia-documentacion-ux-ui_v1.0.md` |
| H-11.04 | enlace-roto | `Guides/Metodologia-Agiles/Scrum-Guide/Caso-De-Estudio-1-Guide.md` (l. 7) | `guia-de-estudio.md` no existe; hoy es `Estudio-Guide.md`. Único enlace relativo roto del dominio (chequeo de todos los `](…)`) |
| H-11.05 | nombre-raro | `Guides/UX-UI-Design/UX-UI-Guide/metodologia-uix-ux.md` | «uix-ux» (errata probable de «ui-ux»); el título es «Guía de Documentación UX/UI» |
| H-11.06 | rutas-de-origen | ` Metodologias-Agiles-Jira-Guide.md` §1.3 (l. 172–186); `guia-organizacion-proyecto-jira.md` (cabecera «Basado en») | Rutas `docs/00_contexto/…`, `docs/06_backlog-tecnico/…`, `devs/metodos-agiles/…` del template de origen; no resuelven acá (son texto, no enlaces) |
| H-11.07 | referencia-ausente | `metodologia-uix-ux.md` §1 (l. 21) | «Los tres artefactos que define el `rules.md`»: no hay ningún `rules.md` en el repo. Además `SA-03`/`SA-02` son numeración del proyecto de origen |
| H-11.08 | traza-externa | frontmatter de las dos piezas de seguridad | `ESC-TESTIGO` y `ESC-CORPUS` no son `doc_id` de ningún archivo de `Lab-Documentos`; según la ia-db anterior viven en los `OUTPUTs/` del prompt generador en el repo de documentación (sin verificar en esta corrida) |
| H-11.09 | orden-fisico | `Beginning-Security-Windows-Network-Guide.md` | Apéndice A (l. 1140) va antes de §12 Referencias (l. 1192) y §13 Glosario (l. 1254) |
| H-11.10 | sin-readme | `Guides/Metodologia-Agiles/`, `Guides/UX-UI-Design/`, `Guides/Otros/` | Sin `README.md` propio; `Guides/README.md` enlaza esas carpetas a secas. (Corrige a la ia-db v1.x: `Guides/README.md` ya **no** está vacío; tiene frontmatter e índice) |
| H-11.11 | doc_id-generico | `Guides/Otros/Seguridad-Red-Windows-Guide/*` | `GUIA-PRINCIPAL` y `CUADERNO` sin prefijo de dominio; hoy no colisionan, pero son candidatos |
| H-11.12 | sin-metadatos | `Guides/Metodologia-Agiles/**`, `Guides/UX-UI-Design/**` | Sin frontmatter ni `doc_id`; dos piezas ágiles sin campo de estado |
| H-11.13 | binario-no-enlazado | `Guides/Metodologia-Agiles/Scrum-Guide/2020-Scrum-Guide-US.pdf` | Ningún `.md` del repo lo enlaza; contenido no leído en esta corrida |
| H-11.14 | categoria-vs-carpeta | `Guides/README.md`, fila «Arquitectura» | Agrupa `Dot-NET-Arquitectura-Guide/`, que está en la raíz de `Guides/` y no dentro de `Arquitectura/`: la categoría no coincide con el árbol |
| H-11.15 | origen-no-hallado | `UX-UI-Guide.md` | Autor «Equipo de documentación técnica»; prompt o fuente de generación no identificable desde este repo (sin verificar) |

## Para preguntas X → leé fuente Y

| Necesitás saber… | Leé |
|---|---|
| Qué categorías de guías hay y dónde está cada una | `Guides/README.md` |
| Por dónde arrancar un proyecto Scrum | `Guides/Metodologia-Agiles/Scrum-Guide/Estudio-Guide.md` §1–§2 · ` Metodologias-Agiles-Jira-Guide.md` §17 |
| Qué es una épica y cómo agrupar US | `Estudio-Guide.md` §4–§5 |
| Cómo redactar una US (INVEST, Given/When/Then) | ` Metodologias-Agiles-Jira-Guide.md` §6 · `Caso-De-Estudio-1-Guide.md` §3–§4 |
| Scrum vs Kanban vs otros | ` Metodologias-Agiles-Jira-Guide.md` §4.5, §5.5 |
| Cómo dar de alta un proyecto en Jira | `guia-organizacion-proyecto-jira.md` P3 · ` Metodologias-Agiles-Jira-Guide.md` §11 |
| Prioridades Jira ↔ MoSCoW, JQL | ` Metodologias-Agiles-Jira-Guide.md` §10.3, §13.7 |
| Dónde va cada artefacto SDD en Jira | ` Metodologias-Agiles-Jira-Guide.md` §14.6 |
| Qué técnica de descomposición usar | ` Metodologias-Agiles-Jira-Guide.md` §16.13 |
| Heurísticas de Nielsen / reglas de Shneiderman | `Guides/UX-UI-Design/UX-UI-Guide/UX-UI-Guide.md` §4 |
| WCAG 2.2, WAI-ARIA, ISO 9241 | `UX-UI-Guide.md` §5 |
| Material 3 vs HIG, patrones móviles | `UX-UI-Guide.md` §6.4, §9 |
| DX de una API REST (errores, versionado) | `UX-UI-Guide.md` §10 · `TEM-DX` |
| Qué documentos produce la sección UX | `Guides/UX-UI-Design/UX-UI-Guide/metodologia-uix-ux.md` §1, §3 |
| Investigar una intrusión en Windows | `Guides/Otros/Seguridad-Red-Windows-Guide/Beginning-Security-Windows-Network-Guide.md` §3–§9 |
| Qué significan 4624 / 4625 / 1102 | Guía de seguridad §5 |
| Montar el laboratorio de pentesting | Guía de seguridad §10 y Apéndice A |
| Practicar | `Cuaderno-Ejercicios-Seguridad-Windows.md` |

## Fuentes

- `Guides/README.md`
- `Guides/Metodologia-Agiles/Scrum-Guide/` (cinco archivos; el PDF sólo inventariado)
- `Guides/UX-UI-Design/UX-UI-Guide/UX-UI-Guide.md`, `metodologia-uix-ux.md`
- `Guides/Otros/Seguridad-Red-Windows-Guide/Beginning-Security-Windows-Network-Guide.md`,
  `Cuaderno-Ejercicios-Seguridad-Windows.md`
- `git log` de las tres carpetas (82b2fe1, 9401ad5, 85e6099, 69c80c7, 4510b22)
- Referencia de hallazgos previos: ia-db v1.x, índice `09_IA-Agiles-UX-y-Otros.md` (re-verificado)

**Vigencia**: 2026-11-16 · fuente `Lab-Documentos` `main` 34929f2.
