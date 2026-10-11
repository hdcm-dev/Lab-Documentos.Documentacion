# Mesa · Ciclo 1 · 00 — Convocatoria

> Fecha: 2026-10-07. Marco: `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §4.1.2–§4.1.4 y §5.1.b–c.
> Artefacto evaluado: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (versión 1.0.0-borrador, 3060 líneas). Las ubicaciones «L*n*» son números de línea de ese archivo en esta fecha.
> Antecedentes: `../../00-Contrato-De-Entrada.md` §4 (señales sobre el prompt del PO) y `../../02-Cohesion-Global.md` §8 (comisiones propuestas). Esta convocatoria las retoma sobre la **guía escrita**, no sobre el prompt.

## 1. Panel de partida (no se vota)

| Origen | Rol en esta mesa | Rol del marco al que corresponde |
|---|---|---|
| Núcleo permanente (§4.1.1) | requisitos | Requisitos |
| Núcleo permanente | verificacion-evidencia | Verificación / QA |
| Núcleo permanente | lector-sin-contexto | Implementador ingenuo |
| Núcleo permanente | abogado del diablo | Abogado del diablo (entra después de leer al resto) |
| PO, DC-03 (no removible) | didactica | — (fuera de catálogo; lo fija el PO) |
| PO, DC-03 | edicion-bibliografica | — (fuera de catálogo; lo fija el PO) |
| PO, DC-03 | senior-dotnet | — (especialidad de stack) |
| PO, DC-03 | arquitecto-software | Arquitectura (catálogo §4.1.2) |
| PO, DC-03 | desarrollador | — (perspectiva de estación; el contrato 00 §4 lo propuso con estación Windows + Visual Studio) |

El PO pidió además: «analiza si necesitas un experto más». Esta convocatoria responde esa pregunta.

## 2. Barrido de señales (relevador, sin voto)

Inventario, no juicio. Cada señal con ubicación en la guía.

| # | Señal observable | Ubicación | Especialidad que sugiere |
|---|---|---|---|
| S-01 | Dos de los tres contextos son Node.js y Python solos; el título y el alcance los nombran | L3 (front matter), L186–L188 (§2.2 CTX-NODE, CTX-PY) | Ecosistemas Node.js / Python |
| S-02 | Afirmaciones de comportamiento de herramientas Node: `.nvmrc`, `engines`, `devEngines`, Corepack retirado desde Node 25 | L889–L893 (§6.2.3) | Ecosistemas Node.js / Python |
| S-03 | Afirmaciones de comportamiento de herramientas Python: `requires-python`, `.python-version`, `required-version`, gestores de versión | L895–L910 (§6.2.4–§6.2.5) | Ecosistemas Node.js / Python |
| S-04 | Locks y modo estricto de npm, pnpm, Yarn, uv, Poetry, pip-tools; estado de PEP 751 | L1056–L1064 (§7.2.2–§7.2.3) | Ecosistemas Node.js / Python |
| S-05 | Metadatos y reproducibilidad de `npm pack`, ruedas de Python, PEP 740 y 770 | L1447–L1451 (§9.2.2) | Ecosistemas Node.js / Python; cadena de suministro |
| S-06 | Integración políglota: frontera MSBuild↔npm↔uv, `.esproj`, imágenes multi-runtime | L1836–L2165 (§11), L1917–L1941 (§11.2.5) | Arquitectura (ya en panel); Node.js / Python |
| S-07 | Garantías de integridad: hash del lock, mapeo de fuentes contra confusión de dependencias, «qué no protege» | L1076 (§7.3), L1140 (§7.6) | Cadena de suministro |
| S-08 | Etiqueta vs digest, CVE, cadencia de actualización de imágenes | L1221–L1234 (§8.2.2) | Cadena de suministro; Operación y entrega |
| S-09 | Niveles SLSA, firma, clave como secreto de la CI, «no es L2» | L1472–L1498 (§9.2.4), L1543–L1556 (§9.5) | Cadena de suministro; Seguridad (secretos: `cosign.key` L1554, `id-token: write` L1490/L1544) |
| S-10 | Acciones de CI fijadas por SHA; Dependabot y acciones fijadas | L1675–L1677 (§10.2.4) | Cadena de suministro; Operación y entrega |
| S-11 | Disponibilidad de ramas protegidas, *rulesets*, dueños requeridos por plan; `pre-receive` con presupuesto de 5 s; permisos de *bypass* | L1714–L1738 (§10.2.7–§10.2.8) | Operación y entrega (plataforma de CI) |
| S-12 | Workflow de CI, `dependabot.yml`, `CODEOWNERS` como plantillas «no ejecutadas» | L2502–L2590 (A.12–A.14); L3044–L3046 (Anexo F) | Operación y entrega; cadena de suministro |
| S-13 | Estación Windows + Visual Studio: escenario central del caso, sin ningún experimento ejecutado en Windows; hallazgo negativo «VS no abre .NET en devcontainer» | L94 (§0.4), L1247–L1266 (§8.2.4), L3033–L3042 (Anexo F) | Windows / Visual Studio |
| S-14 | Cuantificadores universales y umbrales numéricos en afirmaciones técnicas (147 apariciones de *nunca/siempre/todos/ninguno/único*; p. ej. «Node y Razor nunca», «`npm ci` … **nunca** escribe el lock», «12 horas», «5 segundos») | L474, L1058, L1223, L1727; conteo por `grep -o -i -w` (E1, abajo) | Formal / matemático (catálogo, **automático**) |
| S-15 | Caso disparador en un repositorio privado | L100–L110 (§1.1), L114 (§1.2) | Seguridad y privacidad (filtrado de identificadores) |
| S-16 | Despliegue y operación en producción declarados fuera de alcance | L59 (§0.1) | Operación y entrega (señal negativa) |
| S-17 | Rendimiento: bind mount desde Windows «no medido»; presupuesto de `pre-receive` | L1281 (§8.2.5), L1727 | Rendimiento y costo |
| S-18 | Nombre interno `RunNpmInstall` usado como punto de enganche, «no es un contrato» | L1937 (§11.2.5) | Interfaz / consumidor externo |

**Chequeo mecánico de privacidad (E1, 2026-10-07).**

```text
$ grep -rn -i -E "GDA|SGM|Notions|BotonPanico|oordenadaExtacta" Metodologia-Entorno-Desarrollo-Guide.md Examples | grep -v -E "/(bin|obj|node_modules|\.venv)/"
(sin salida)
$ grep -o -i -w -E "nunca|siempre|todos|todas|ninguno|ninguna|único|única" Metodologia-Entorno-Desarrollo-Guide.md | wc -l
147
```

## 3. Votación del catálogo variable (§4.1.2)

Votan los cinco jueces: J1 evidencia, J2 impacto, J3 costo/beneficio, J4 coherencia histórica, J5 riesgo e irreversibilidad. Mayoría simple; empate convoca.

| Rol del catálogo | Señal | Votos (J1–J5) | Decisión | Motivo |
|---|---|---|---|---|
| Arquitectura | S-06 | — | ya en panel (arquitecto-software, DC-03) | — |
| **Formal / matemático** | S-14 | — | **CONVOCAR (automático)** | §4.1.2: «si su señal aparece, entra sin discusión». Se le redacta carta para acotar su mandato a una guía (no a una especificación); ver CAT-FORMAL. |
| Datos y dominio | — | N N N N N | NO_CONVOCAR | La guía no modela entidades, estados ni persistencia de negocio; los locks y manifiestos son artefactos de build, cubiertos por senior-dotnet y AH-001. |
| Seguridad y privacidad | S-09, S-15 | N N N N S | NO_CONVOCAR como rol general | Los secretos que aparecen (S-09) son de firma de la cadena de suministro: entran en AH-002, que tiene la competencia específica. La privacidad (S-15) es un chequeo mecánico que dio limpio (E1 arriba) y que verificacion-evidencia repite al cierre. J5 votó convocar por irreversibilidad de una filtración; la mayoría lo da por cubierto por el chequeo mecánico. |
| Operación y entrega | S-08, S-10–S-12, S-16 | S S N S S | absorbido por AH-002 | El despliegue está fuera de alcance (S-16); lo que queda en la guía de «operación» es la plataforma de CI y su gobierno (§10, A.12–A.14), cuya pregunta es la misma que la de la cadena de suministro: **qué garantiza de verdad lo que la guía dice que garantiza**. Se instancia como parte de AH-002 con carta propia en vez de rol genérico. |
| Concurrencia / tiempo | — | N N N N N | NO_CONVOCAR | Sin colas, reintentos ni orden de eventos; la intermitencia de `CS2016` (L450) es un rótulo de interpretación ya declarado en Anexo F. |
| Rendimiento y costo | S-17 | N N N N N | NO_CONVOCAR | Marginal: la guía rotula el bind mount como «no medido» y el presupuesto de 5 s es un dato de documentación que verifica J1/verificacion-evidencia. |
| Interfaz / consumidor externo | S-18 | N N N N N | NO_CONVOCAR | Lo declara la propia guía; senior-dotnet y AH-001 cubren `.esproj` y npm. |
| Cumplimiento / normativa | — | N N N N N | NO_CONVOCAR | Sin obligaciones legales ni retención; SLSA L3 por «requisito externo» (L1570) es mención, no requisito. |
| Accesibilidad / uso | — | N N N N N | NO_CONVOCAR | No hay interfaz de usuario. |

## 4. Agentes ad hoc (§4.1.3) — se vota sobre la carta, no sobre la idea

### AH-001 · Ecosistemas Node.js y Python

```yaml
agente_ad_hoc:
  id: AH-001
  nombre: Especialista en ecosistemas Node.js y Python (toolchain, gestores, locks, empaquetado)
  señal_que_lo_justifica:
    descripción: "Dos de los cuatro contextos de la guía (CTX-NODE, CTX-PY) y la mitad de §6, §7, §9.2.2 y §11 afirman comportamientos de npm, pnpm, Yarn, Corepack, nvm/fnm, uv, Poetry, pip, pip-tools y PEP 751/740/770; el panel fijado por el PO no tiene a nadie con esa competencia (senior-dotnet cubre sólo .NET)."
    ubicación: "L186–L188 (§2.2); L889–L910 (§6.2.3–§6.2.5); L1056–L1064 (§7.2.2–§7.2.3); L1447–L1451 (§9.2.2); L1917–L1941 (§11.2.5)"
  pregunta_que_responde: "¿Lo que la guía afirma de cada herramienta de Node.js y de Python —qué declara, qué hace cumplir, cuál es su default y su estado vigente al 2026-10-07— es exacto, y la recomendación por ecosistema coincide con la que sostienen su fabricante o su PEP?"
  competencia: "Semántica y defaults de npm/pnpm/Yarn/Corepack, nvm/fnm/mise/asdf, uv/Poetry/pip/pip-tools; package.json (engines, devEngines, packageManager), .npmrc, pyproject.toml, .python-version, uv.lock, pylock.toml; estados de PEP 263/597/686/740/751/770; lectura de codificación por el cargador de Node y el compilador de Python; npm pack y ruedas. NO le corresponde: Roslyn, MSBuild, NuGet ni global.json (senior-dotnet); la arquitectura de la frontera políglota (arquitecto-software); garantías de integridad, firma o SLSA (AH-002); didáctica, forma o voz."
  evidencia_admisible: [E1, E2, E3]   # experimento ejecutado en contenedor; doc oficial (nodejs.org, docs.npmjs.com, pnpm.io, yarnpkg.com, docs.astral.sh, packaging.python.org, peps.python.org) con fecha; código fuente de la herramienta
  tope_hallazgos: 5
  se_disuelve_cuando: "Al cierre del ciclo 1 si no obtiene ningún PROCEDE; si obtiene alguno, al cierre del ciclo en que se verifiquen sus parches."
```

| Juez | Voto | Fundamento |
|---|---|---|
| J1 evidencia | INSTANCIAR | Las afirmaciones de S-02–S-05 son volátiles (Corepack, PEP 751, npm 12) y sólo alguien del ecosistema distingue un default de una opción. |
| J2 impacto | INSTANCIAR | Un dato erróneo en `npm ci`/`uv --locked` invalida la compuerta de §7 y §10 para dos de tres ecosistemas. |
| J3 costo/beneficio | INSTANCIAR | Un informe de ≤5 hallazgos contra ~40 % del contenido técnico sin revisor de dominio. |
| J4 coherencia histórica | INSTANCIAR | Ya propuesto en 00 §4 y 02 §8; el PO pidió explícitamente .NET, Node.js y Python. |
| J5 riesgo | INSTANCIAR | Sin él, el punto ciego es estructural: ningún otro rol puede refutar a la guía en Node o Python. |

**Decisión: INSTANCIAR (5–0).**

### AH-002 · Cadena de suministro y gobierno de la CI

```yaml
agente_ad_hoc:
  id: AH-002
  nombre: Especialista en cadena de suministro de software y gobierno de la CI (integridad, procedencia, compuertas de plataforma)
  señal_que_lo_justifica:
    descripción: "La guía atribuye garantías concretas a mecanismos de integridad y de plataforma —hash del lock, mapeo de fuentes, digest de imagen, acciones por SHA, SBOM, firma cosign, niveles SLSA, ramas protegidas por plan, pre-receive, bots— y rotula como no verificados varios de ellos (attest, Dependabot, matriz con Windows). Ningún rol del panel tiene competencia en SLSA/in-toto/Sigstore ni en los límites de plan de las plataformas de CI. Absorbe las señales de Seguridad (secretos de firma) y de Operación y entrega (plataforma de CI) del catálogo."
    ubicación: "L1076, L1140 (§7.3, §7.6); L1221–L1234 (§8.2.2); L1472–L1498, L1543–L1556 (§9.2.4, §9.5); L1675–L1677 (§10.2.4); L1714–L1738 (§10.2.7–§10.2.8); L2502–L2590 (A.12–A.14); L3044–L3046 (Anexo F)"
  pregunta_que_responde: "¿Cada garantía que la guía atribuye a un mecanismo de integridad, procedencia o compuerta de plataforma (impedir, verificar, atestiguar) es la que su especificación o su plataforma —con el plan que la guía nombra— realmente otorga, y está dicho lo que ese mecanismo NO protege?"
  competencia: "SLSA v1.x (niveles de Build, requisitos de procedencia y verificación), in-toto/DSSE, Sigstore/cosign, SBOM (SPDX, CycloneDX) y su alcance; confusión de dependencias y mapeo de fuentes (NuGet, npm scopes, índices de uv) en cuanto a qué ataque cubren; digest vs etiqueta y cadencia de parches; fijación de acciones por SHA; ramas protegidas, rulesets, CODEOWNERS, bypass y pre-receive en GitHub, GitLab y Azure DevOps; Dependabot/Renovate. NO le corresponde: la semántica de restauración de cada gestor (senior-dotnet, AH-001), la codificación y la política de texto, la arquitectura de la frontera políglota, didáctica, forma o voz; tampoco el despliegue en producción (fuera de alcance, §0.1)."
  evidencia_admisible: [E1, E2, E3]   # experimento en contenedor (cosign, BuildKit, git pre-receive); doc oficial (slsa.dev, docs.github.com, docs.gitlab.com, learn.microsoft.com, docs.docker.com, spdx.dev, cyclonedx.org, sigstore.dev) con fecha
  tope_hallazgos: 5
  se_disuelve_cuando: "Al cierre del ciclo 1 si no obtiene ningún PROCEDE; si obtiene alguno, al cierre del ciclo en que se verifiquen sus parches."
```

| Juez | Voto | Fundamento |
|---|---|---|
| J1 evidencia | INSTANCIAR | §9 hace distinciones finas («no es L2», «L3 con reusable workflows») que exigen leer la especificación SLSA y las docs de plataforma, no sólo comprobar que haya una cita. |
| J2 impacto | INSTANCIAR | Un lector que crea que su CI «bloquea» o que su firma «es L2» cuando no lo es toma decisiones de riesgo equivocadas; es la tercera pregunta del caso («con qué se ensambló»). |
| J3 costo/beneficio | INSTANCIAR | Una sola carta cubre tres señales del catálogo (Seguridad, Operación y entrega, parte de Interfaz) sin abrir tres roles. |
| J4 coherencia histórica | INSTANCIAR | Coincide con la comisión «DevOps / cadena de suministro» propuesta en 00 §4 y 02 §8. |
| J5 riesgo | INSTANCIAR | La sobreafirmación de garantías es el error menos reversible una vez adoptada la guía. Advierte el riesgo de mandato ancho: la carta lo acota a «garantía declarada vs. garantía real». |

**Decisión: INSTANCIAR (5–0).**

### CAT-FORMAL · Formal / matemático (catálogo, convocatoria automática, con carta)

No es ad hoc: es rol del catálogo y su señal (S-14) lo hace entrar sin votación. Se le redacta carta igual, porque el catálogo lo pensó para especificaciones (condiciones, pesos, umbrales) y en una guía su aporte útil es otro.

```yaml
agente_catalogo_con_carta:
  id: CAT-FORMAL
  nombre: Formal / matemático — alcance lógico de las afirmaciones
  señal_que_lo_justifica:
    descripción: "147 cuantificadores universales en la guía y umbrales numéricos tomados de documentación o de una sola medición; varios afirman un 'nunca'/'siempre' sobre una herramienta a partir de un experimento con una versión."
    ubicación: "L474 («Node y Razor nunca»), L1058 («nunca escribe el lock»), L1223 («12 horas»), L1449 (mtime fijo, [observado]), L1727 («5 segundos»); conteo E1 en §2"
  pregunta_que_responde: "¿El alcance de cada afirmación universal o numérica de la guía (todas las versiones, plataformas y configuraciones) es igual o menor que el alcance de la evidencia que la respalda (una versión, una plataforma, una corrida)?"
  competencia: "Cuantificadores, condiciones compuestas, generalización desde una muestra, umbrales y rangos; consistencia entre una afirmación y su rótulo ([criterio], [observado], [no verificado]). NO le corresponde: decidir si el hecho es verdadero (verificacion-evidencia y especialistas de dominio), estilo ni didáctica."
  evidencia_admisible: [E1, E2]
  tope_hallazgos: 5
  se_disuelve_cuando: "Al cierre del ciclo 1 si no obtiene ningún PROCEDE."
```

## 5. Candidatos ad hoc descartados

| Candidato | Señal | Votos (J1–J5) | Decisión y motivo |
|---|---|---|---|
| Windows / Visual Studio | S-13 | N N S N S | **NO_INSTANCIAR.** No hay host Windows: el agente sólo podría releer documentación de Microsoft, y no produciría E1 donde la guía ya rotula [no verificado]. La lectura de docs de Visual Studio/MSBuild la cubre senior-dotnet y la honestidad del rótulo la cubre verificacion-evidencia; la perspectiva de estación Windows la cubre desarrollador (propuesta 00 §4). Empate no hubo (3–2). **Encargo explícito** a senior-dotnet: revalidar el hallazgo negativo de L1247–L1266 y Anexo F L3039. **Cola priorizada #1** para el ciclo 2 si alguna solicitud de convocatoria lo pide. |
| Seguridad y privacidad (rol general) | S-09, S-15 | N N N N S | NO_CONVOCAR: secretos de firma → AH-002; privacidad → chequeo mecánico E1 limpio, repetido al cierre por verificacion-evidencia. |
| Operación y entrega (rol separado) | S-08, S-10–S-12, S-16 | (ver §3) | Absorbido por AH-002: el despliegue está fuera de alcance (L59) y lo restante es gobierno de CI, que comparte la pregunta de AH-002. Abrirlo aparte duplicaría mandato. |
| Contenedores / devcontainers | §8 entero | N N N N N | NO_INSTANCIAR: §8 se apoya en E5-1…E5-6 ejecutados; lo cubren arquitecto-software (modelo de capas, imagen dev vs CI), desarrollador (montaje, permisos) y AH-002 (digest, actualización). |
| Unicode / codificación de texto | §4–§5 | N N N N N | NO_INSTANCIAR: el núcleo del caso ya tiene a senior-dotnet (Roslyn), AH-001 (lectores Node/Python) y verificacion-evidencia (normas Unicode citadas [B12][B13]); la política de texto está respaldada por E1/E2. |
| Node.js y Python como dos agentes separados | S-01–S-05 | N N N S N | NO: una carta con una pregunta común alcanza; dos agentes duplicarían el cupo ya excedido (§6). |

## 6. Techo de panel: apartamiento declarado

El marco (§4.1.4, §5.1.c) fija **núcleo + hasta 5 variables/ad hoc por ciclo**. El PO fijó cinco roles no removibles fuera del núcleo (DC-03), así que el techo se llena antes de evaluar nada; con AH-001, AH-002 y CAT-FORMAL el panel queda en **núcleo (4) + 8**.

- **Apartamiento**: se excede el techo en 3. Fundamento: la consigna del PO («analiza si necesitas un experto más») presupone poder sumar, y el propio marco prefiere el error por exceso (§5.1.c: «el costo de un especialista de más es un informe descartable, el de uno de menos es un punto ciego»). CAT-FORMAL entra por regla automática.
- **Mitigación**: tope de 5 hallazgos por agente y disolución al cierre del **ciclo 1** si no obtienen ningún `PROCEDE` (más estricto que los dos ciclos de §4.1.4).
- **Para el PO**: este apartamiento del marco se informa en el cierre del ciclo, no se da por aprobado en silencio.

## 7. Registro para el aprendizaje del marco (§5.1, al cierre)

| Agente | Señales que lo convocaron | A completar al cierre: hallazgos emitidos / PROCEDE |
|---|---|---|
| AH-001 | S-01–S-06 | |
| AH-002 | S-07–S-12 (absorbe S-09 Seguridad y S-11/S-12 Operación) | |
| CAT-FORMAL | S-14 | |
| Windows/VS (descartado) | S-13 | ¿algún hallazgo de otro rol cayó en ESC-01/ESC-03 sin evidencia? |
| Seguridad general (descartado) | S-09, S-15 | ¿apareció alguna filtración o secreto fuera de §9? |
