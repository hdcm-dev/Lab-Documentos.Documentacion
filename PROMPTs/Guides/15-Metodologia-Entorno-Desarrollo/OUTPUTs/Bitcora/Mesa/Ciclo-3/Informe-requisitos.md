# Mesa · Ciclo 3 · Informe de Requisitos

> Fecha: 2026-10-09. Rol: Requisitos (núcleo permanente). Marco: `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md`.
> Artefacto: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md`, **1.0.0 / vigente** (3605 líneas, 54 267 palabras, `sha256 a2b78179b2507f0a…`, el mismo que deja `Ciclo-2/05-Aplicacion.md`). «L*n*» = línea de ese archivo en esta fecha.
> Revisión a ciegas: no se leyeron informes de otros especialistas del ciclo 3. Se leyeron el prompt del PO, el Profile y su RuleSet, y del ciclo 2 sólo lo cerrado (`Informe-requisitos.md`, `01-Consolidado.md`, `05-Aplicacion.md`, el voto de C2-36 en `02-Voto-*.md` y `03-Parches.md`).
> Lo cerrado que no se reabre: exclusión de «métodos y marcos» (C1-45); `traces` en Anexo F (C1-46, C2-34); ia-db fuera de alcance (P-24); presupuesto de compresión sin tope duro, saldo de prosa ≤ 0 (C2-36); la pérdida de *Aplica* aceptada por riesgo en P-05/P-21 (§4.6 y §6.6 cierran con *Criterio*); README = Índice + §0.2.

## 1. Matriz solicitud → sección (estado en 1.0.0)

### 1.1 Pedidos de contenido del PO

| ID | Pedido | Sección | Estado |
|---|---|---|---|
| P-01 | Caso cp1252 → falla en Linux, acentos con `?`, Windows lo tapa | §1.1–§1.4, §4.2.1–§4.2.2, E1-01 | Cumple |
| P-02 | VS en Windows + Linux + devcontainers a la vez | §2.1, §8.2.4, §8.2.5, §0.4 «Desde Windows» | Cumple |
| P-03 | Criterio de codificación unificado, sin commits de BOM | §5, §10.2.5, A.1, A.2, A.15 | Cumple (la traza omite A.15: requisitos-04) |
| P-04 | Congelar NuGet | §7.2.1, A.5, A.6 | Cumple |
| P-05 | Congelar compilador y SDK | §6.2.2, §6.4, A.3 | Cumple |
| P-06 | ¿Con contenedores? | §3.5, §8 | Cumple |
| P-07 | Integración Windows y Linux | §0.4, §8.2.4, §10.4, §11.4 ESC-01, §12 | Cumple, rotulado **[no verificado]** (la traza omite §0.4 y §11.4: requisitos-04) |
| P-08 | Saber con qué entorno se ensambló | §3.2 capa 6, §9, A.17, §12 8a/8b | Cumple en contenido; **la navegación no lleva a A.17** (requisitos-03); el contrato 8a se contradice con el camino de runner alojado (requisitos-01) |
| P-09 | Estrategias de la industria .NET/Node/Python | n.3 de §4–§11 | Cumple (traza corregida en ciclo 2) |
| P-10 | Integrarlos en una única solución | §11 | Cumple |
| P-11 | La mesa vuelve a analizar el documento terminado y corrige edición y compresión | Ciclo 3 (este) | En curso; párrafos ≥ 150 palabras bajaron de 15 a 7 y celdas ≥ 60 palabras a 5 (E1, abajo) |

### 1.2 Reglas del PO y del Profile

| Regla | Exigencia | Sección / evidencia | Estado |
|---|---|---|---|
| R-PO | Jerarquía con índice | Índice L30–L49: 20 entradas = 20 `##` | Cumple |
| R-PO | Definiciones + glosario | n.1 de §3–§11; Anexo C (87 entradas). Cruce de negritas de tablas n.1 contra Anexo C: faltan sólo los sinónimos ya declarados y los ESC-nn (definidos en §2) | Cumple |
| R-PO | Mermaid cuando hace falta | `grep -c '```mermaid'` → 11 | Cumple |
| R-PO | Autocontenida | Toda la guía; trazas en Anexo F | Cumple; una plantilla remite a un archivo que no existe en el repo de plantillas (requisitos-05) |
| R-PO | Snippets representativos | n.5 de §4–§11; Anexo A | Cumple; §9.5 y A.12 ya rotulan **Ilustrativo** (L1775, L2908, L2927) |
| R-PO | Preguntas guía con respuesta que forman criterio | §3.7 (6), §4.6 (7), §5.6 (8), §6.6 (8), §7.6 (7), §8.6 (8), §9.6 (7), §10.6 (8), §11.6 (8): 67 preguntas; 63 con *Aplica* en la respuesta; §4.6 L609 y §6.6 L1110 con *Criterio*, §8.6 L1535 con *Aplica cuando*, L1550 con *No aplica* | Cumple (pérdida aceptada en ciclo 2) |
| R-PO | Práctica con respuesta | n.9 de §4–§11 con dos consignas cada una; §6.9.2 y §10.9.2 con *Criterio de corrección*; §11.9 con dos | Cumple en §4–§11; **la Práctica integradora de §12 no** (requisitos-02) |
| Profile | Marco de referencia | §2.1–§2.4 | Cumple |
| Profile | Mapa por escenario, contexto y artefacto | §3.6, cuatro puertas | Cumple; la puerta «por artefacto» no tiene fila de capa 6 (requisitos-03) |
| Profile | Aplicación por escenario y qué cambia según contexto | §4.4–§9.4 con los cuatro CTX; §10.4 con frase «Por contexto»; §11 es CTX-POLI | Cumple (C2-54 cerrado) |
| Profile | Estructura común n.1–n.9 + plantilla con preguntas por campo | `grep '^### '`: §4–§11 con n.1…n.9; A.1–A.18 todos con «Preguntas:» | Cumple |
| Profile | «Verificable: revisar contra el mapa, huecos y contradicciones» | Ciclo 3 | Queda abierta la contradicción 8a/runner alojado que el ciclo 2 difirió (requisitos-01) |
| Dual-Audience | Front matter con `traces` | L1–L18; tabla en Anexo F L3544–L3561 | Cumple con imprecisiones (requisitos-04) |
| Dual-Audience | `entradas`/`salidas`/`validaciones` | §5.2.6, §12 L2487–L2512 (11 validaciones) | Cumple en forma; dos validaciones sin experimento ni rótulo (requisitos-02) |
| R-PO | No inventar; evidencia | 217 `[Bnn]` definidas = citadas; 73 experimentos (65 filas en Anexo E con subvariantes) = cifra de L26 | Cumple |
| R-PRIV | Sin identificadores privados | `grep -ciE -f <patrón-R-PRIV>` guía → 0; `grep -rliE` sobre `Examples/` → sin salida | Cumple |
| Encargo | `.gitignore` del laboratorio | `Examples/.gitignore`: bin/, obj/, node_modules/, .venv/, __pycache__/ | Cumple |
| Versión | Estado de obra finalizada | L5 `version: 1.0.0`, L6 `status: vigente`, Control de cambios L3601 | Cumple (C2-56 cerrado) |

## 2. Hallazgos

### requisitos-01 · El contrato de §12 exige en 8a un dato que el camino de runner alojado, que la misma guía declara suficiente para 8a, no produce — S2 · E1

- **Ubicación**: §12 tabla, paso 7 (L2477) y paso 8a (L2478); contrato YAML L2507; §8.2.2 L1414; A.12 L2910; A.17 L3046–L3047.
- **Ancla**:
  - L1414: «Para 8a también vale el runner alojado con acciones de *setup* por SHA…: la imagen del runner (capa 4) flota».
  - L2910: «Variante con runner alojado, que alcanza para 8a (§8.2.2)».
  - L2478 (paso 8a): «registro del entorno (SDK, compilador y runtimes efectivos, **digest de la imagen**, commit y árbol limpio; A.17)».
  - L2507: `"paso 8a: registro del entorno sin campos vacíos junto al artefacto (A.17)"`.
  - A.17 L3047: `echo "imagen=${img:-NO DECLARADA (runner sin contenedor: capa 4 en el log «Set up job»)}"`.
  - Con la variante de L2910 (sin `container:`), el registro escribe `imagen=NO DECLARADA…`. El equipo que sigue el camino que la guía le ofrece para 8a no cumple su propia validación 8a. Es la contradicción que `Ciclo-2/05-Aplicacion.md` §6.1 dejó abierta «para el ciclo 3». El juez de coherencia condicionaba `vigente` a resolverla.
- **Impacto**: P-08 es la pregunta central del caso. La versión `vigente` publica un contrato (cara de agente, Rule-Dual-Audience) que da rojo en un camino que la cara humana aprueba. Un agente que valide por el YAML rechaza una CI que la guía declara correcta.
- **Dirección**: acotar 8a y su validación con **[criterio]**. «Digest de la imagen» pasa a «digest de la imagen, o la versión de la imagen del runner tomada del log», y «sin campos vacíos» pasa a «sin campos vacíos; `imagen=NO DECLARADA` sólo con runner alojado». Escribirlo como acotamiento de C1-21 (b) y C1-18 (b), como pidió el voto en minoría del ciclo 2. Alinear §8.2.2 L1414, §8.6 L1539, B.3 y B.4 con la misma frase. No hace falta tocar el script de A.17.
- **Confianza**: 0,85.

### requisitos-02 · La Práctica integradora de §12 pide un experimento para cada validación del contrato y responde 5 de 11; dos validaciones no tienen experimento ni rótulo — S3 · E1

- **Ubicación**: §12, contrato `validaciones` L2499–L2510; Práctica integradora L2513–L2516; §0.2 L82 (ruta mínima: «§12 | los de cada paso | … (Práctica integradora)»); §0.3 L98.
- **Ancla**:
  - L2515: «Para cada validación del contrato, nombrá el experimento que la mostró y predecí el mensaje. *Respuesta esperada*: paso 3, E2-2…; 4, E2-3…; 5, E3-1…; 6, E4-1 y E4-4…; 7, E7-4».
  - El contrato tiene once validaciones (pasos 1, 2, 3, 4, 5, 6, 7, 8a, 8b, 9 y 10). P-14 del ciclo 2 lo amplió y la respuesta no se actualizó. Faltan:
    - 1: `e1-diagnostico.sh`, E1-0x.
    - 2: EA-1 paso 1, que la validación misma cita.
    - 8a: EA-1 paso 9 / A.17.
    - 10: E8-1 columna A. `E8-1-choque-de-convenciones.txt`, bloque A: 15 lectores `OK`.
  - Además, 8b («la procedencia verifica con su par firmante/`builder.id`») y 9 («un PR que toca la compuerta pide la aprobación de su dueño (CODEOWNERS)») no tienen experimento. E6-5 y E8-6 dan `builder.id` vacío. `CODEOWNERS` no se ejecutó (Anexo F: «requieren una plataforma alojada»). El YAML no los rotula **[no verificado]**, como pide §0.3.
  - La respuesta de 6 omite el mensaje de uv («needs to be updated»), que la validación sí nombra.
- **Impacto**: la consigna no tiene respuesta correcta completa. El lector que la resuelve bien (nombrando 8b y 9 como «sin experimento») no puede compararse con la clave. Rompe el contrato de §0.2 («con la respuesta esperada») en la única práctica que integra toda la guía.
- **Dirección**: (a) completar la respuesta con 1, 2, 8a y 10, y decir de 8b y 9 «sin experimento: requiere plataforma alojada (Anexo F)»; o (b) acotar la consigna a «las validaciones de los pasos 3 a 7». En los dos casos, marcar en el YAML las líneas 8b y 9 con `# [no verificado] requiere plataforma alojada` y agregar uv a la respuesta de 6.
- **Confianza**: 0,9.

### requisitos-03 · La entrada a «saber con qué se construyó» no lleva a su plantilla: §3.6 «por artefacto» no tiene capa 6 y §9.8 no remite a A.17 — S3 · E1

- **Ubicación**: §3.6, tabla «Por artefacto que se va a tocar» L410–L417; §9.8 Plantilla L1832; A.17 L3035; A.18 L3074.
- **Ancla**:
  - La tabla de L410–L417 lista las capas 1, 2, 3, 4, 5 y «gobierno». No hay fila para la capa 6 (§3.2: «Capa 6 · Metadatos y procedencia… versión+SHA · SBOM · atestación»).
  - §9.8 (L1832): «[A.4 …] (trazabilidad .NET), [A.12 workflow de CI] (`SOURCE_DATE_EPOCH`). Los guiones completos de SBOM y procedencia están en `Examples/N6-…`». No nombra A.17.
  - El encabezado de A.17 dice «(guía 9.6; 12, paso 8a)». `grep -n 'A\.17'` sólo la encuentra en §11.8, §12, A.12, B.3 y el glosario.
  - A.18 (`.gitignore`, nueva en 1.0.0) no figura en ninguna tabla del mapa ni en ninguna n.8.
- **Impacto**: P-08 es una de las tres preguntas del PO. El lector que entra por el mapa (lectura de **Consulta**, §0.2) o por la plantilla del capítulo 9 no llega a la pieza concreta que la responde para todo equipo (8a). Incumple el Profile («Mapa conceptual… por artefacto»; «Interconectado: ningún documento queda huérfano del mapa»).
- **Dirección**:
  - Agregar en §3.6 la fila «Registro del entorno, SBOM, atestación | 6 | §9 | A.17» y sumar `.gitignore` a la fila de capa 1 o de gobierno con «A.18».
  - En §9.8, anteponer «[A.17 Registro del entorno](#a17-registro-del-entorno)».
  - Son tres celdas o enlaces. No agrega prosa.
- **Confianza**: 0,85.

### requisitos-04 · La tabla de trazas del Anexo F omite secciones que cubren su pedido — S4 · E1

- **Ubicación**: Anexo F L3546 (P-03), L3547 (P-04), L3550 (P-07).
- **Ancla**:
  - P-03 («sin commits de BOM») → «§5, §10.2.5, A.1, A.2». Omite A.15 `.git-blame-ignore-revs`, que §3.6 L412 y §5.8 sí asocian a la capa 1.
  - P-07 («Integrarlo con herramientas en Windows y Linux») → «§8.2.4, §10, §12». Omite §0.4 «Desde Windows» (L112), la fila ESC-01 de §11.4 (L2327) y §3.6 «Por escenario», que son las piezas operativas para Windows.
  - P-04 → «§7». Las plantillas A.5 y A.6 no figuran, aunque P-03 sí lista sus plantillas.
- **Impacto**: la trazabilidad pedida (Profile «Trazable») es incompleta e inconsistente entre filas. Algunas filas nombran plantillas y otras no. Un agente que valide cobertura por la tabla subestima lo cubierto.
- **Dirección**: P-03 → «§5, §10.2.5, A.1, A.2, A.15»; P-04 → «§7, A.5, A.6»; P-07 → «§0.4, §3.6, §8.2.4, §10.4, §11.4, §12».
- **Confianza**: 0,8.

### requisitos-05 · La plantilla A.10 remite a un `verificar.sh` que no existe en el repositorio de plantillas — S4 · E1

- **Ubicación**: A.10 L2798; `Examples/A-plantillas/repo/imagen/Dockerfile` L4.
- **Ancla**:
  - L2798: `# (global.json, .nvmrc, tools/gen/.python-version): lo comprueba verificar.sh, no esta imagen.`
  - `find Examples/A-plantillas/repo -name '*.sh'` → sólo `tools/ci/compuerta.sh` y `tools/ci/registrar-entorno.sh`. La comprobación `.nvmrc` contra `node --version` la hace la compuerta completa (`Examples/N7-compuertas-y-gobierno/compuerta/compuerta.sh` L64–L66), que A.11 manda copiar.
  - `verificar.sh` es el nombre de la compuerta de N8 (`solucion/verificar.sh`, §11.5) y del arnés EA-1. El comentario se heredó de la imagen de N8, como admite la primera línea de L2795.
- **Impacto**: quien copia el Anexo A a su repo (lo que pide «autocontenida» y «plantilla comentada») busca un archivo que no tiene. Es menor, pero confunde dos compuertas en el anexo que la guía presenta como una sola.
- **Dirección**: en A.10 y en el Dockerfile del laboratorio, «lo comprueba la compuerta (A.11, `tools/ci/compuerta.sh`)». Hay que regenerar la verificación `anexoA.py`, porque es un bloque-archivo igualado byte a byte.
- **Confianza**: 0,8.

## 3. Revisado y bien

1. **Prácticas de §4–§11**: las ocho n.9 tienen dos consignas, todas sobre experimentos existentes o con *Criterio de corrección* en las de diseño (§6.9.2, §10.9.2), como promete ahora §0.2 L68. §11.9.1 usa E8-1 y su respuesta coincide con el bloque B de la salida versionada: cinco `FALLA` (shebang de `saluda.py`, `json.load`, `tomllib`, `JSON.parse`, `.nvmrc`); `hola.sh` `OK`. §11.9.2 coincide con EA-1 L88 (`no es UTF-8 válido (byte 0xc7 …; ¿cp1252?)`). §9.9.2 cubre ahora los seis metadatos. Se cierran C2-32 y C2-39.
2. **Estructura y cifras del aparato**: índice = 20 `##`; §4–§11 con n.1…n.9; A.1–A.18 con «Preguntas:»; 11 mermaid; las cifras de L26 (217 fuentes, 73 experimentos) coinciden con el Anexo D y con las 65 filas del Anexo E desplegadas en subvariantes (E0-3a/b/c, E0-5b, E1-06/07, E1-12/13, E5-5b, E6-2b, E7-5b). §9.4 cubre los cuatro contextos y §10.4 declara «Por contexto» (C2-54 cerrado).
3. **Estado de entrega y privacidad**: `version: 1.0.0`, `status: vigente`, banda L26 y Control de cambios alineados. El Control de cambios quedó en celdas breves con detalle debajo. Privacidad limpia en guía y `Examples/`, y `Examples/.gitignore` cubre lo pedido.

## 4. Solicitudes de convocatoria

- **Arquitecto de software / senior .NET**: §11.4 ESC-01 (L2327) recomienda «correr `verificar.sh` desde Git Bash» y §3.6 CTX-POLI (L406) pide «una compuerta con inventario de proyectos». Desde el ciclo 2, la compuerta de A.11 encuentra los proyectos sola. Conviven dos compuertas (A.11/N7 `compuerta.sh` y N8 `verificar.sh`) y no me toca juzgar si la guía debe decir cuál recomienda para CTX-POLI.
- **Edición bibliográfica**: quedan 7 párrafos de 150 palabras o más (L498, L1006, L1014, L1201, L2207, L2248, L2258) y 5 celdas de 60 o más (L548, L711, L826, L1060, L2477). La medición es E1, con el mismo criterio del ciclo 2. No opino sobre si es suficiente para la «compresión» que pide el PO.
