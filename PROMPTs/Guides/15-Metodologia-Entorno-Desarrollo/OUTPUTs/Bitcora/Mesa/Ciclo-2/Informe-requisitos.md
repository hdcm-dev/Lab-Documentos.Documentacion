# Mesa · Ciclo 2 · Informe de Requisitos

> Fecha: 2026-10-09. Rol: Requisitos (núcleo permanente). Marco: `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md`.
> Artefacto: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md`, **1.0.0-rc.1** (3391 líneas). «L*n*» = línea de ese archivo en esta fecha.
> Revisión a ciegas: no se leyeron informes de otros especialistas del ciclo 2. Se leyeron el prompt del PO, el Profile, Rule-Dual-Audience, y del ciclo 1 sólo lo cerrado (`Informe-requisitos.md`, `01-Consolidado.md`, `03-Parches.md`, `05-Aplicacion.md`) para no re-litigar.
> Lo cerrado que no se reabre: exclusión de «métodos y marcos» declarada en §0.1 (C1-45); `traces` se conserva y se resuelve en la guía (C1-46); ia-db fuera de alcance de escritura, registrada para el PO (P-24); contrato agente sólo en §5.2.6 y §12 (C1-47, alcance mínimo).

## 1. Matriz solicitud → sección (estado en rc.1)

### 1.1 Pedidos de contenido del PO

| ID | Pedido | Sección | Estado |
|---|---|---|---|
| P-01 | Caso cp1252 → falla en Linux, acentos con `?`, Windows lo tapa | §1.1–§1.4, §4.2.1–§4.2.2, E1-01 | Cumple |
| P-02 | VS en Windows + Linux + devcontainers a la vez | §2.1, §8.2.4, §8.2.5 | Cumple |
| P-03 | Criterio de codificación unificado, sin commits de BOM | §5, §10.2.5, A.1, A.2, A.15 | Cumple |
| P-04 | Congelar NuGet | §7.2.1, A.5, A.6 | Cumple |
| P-05 | Congelar compilador y SDK | §6.2.2, §6.4, A.3 | Cumple |
| P-06 | ¿Con contenedores? | §3.5, §8 | Cumple |
| P-07 | Integración con Windows y Linux | §0.4 «Desde Windows», §8.2.4, §10.4, §12 | Cumple (rotulado [no verificado], Anexo F) |
| P-08 | Saber con qué entorno se ensambló | §3.2 capa 6, §9, §11.2.8 | Cumple |
| P-09 | Estrategias de la industria .NET/Node/Python | n.3 de §4–§11 | Cumple; la tabla de trazas omite §11.3 (requisitos-02) |
| P-10 | Integrarlos en una única solución | §11 | Cumple |

### 1.2 Reglas del PO y del Profile

| Regla | Exigencia | Sección / evidencia | Estado |
|---|---|---|---|
| R-PO | Jerarquía con índice | Índice L28–L49 (20 entradas = 20 `##`) | Cumple |
| R-PO | Definiciones + glosario | n.1 de §3–§11; Anexo C. Cruce de términos en negrita de las tablas n.1 contra el Anexo C (E1): 0 faltantes salvo 3 sinónimos ya declarados (ACP, Rango, Fijar) | Cumple |
| R-PO | Mermaid cuando hace falta | 11 bloques `mermaid` | Cumple |
| R-PO | Autocontenida | Toda la guía; trazas resueltas en el Anexo F | Cumple |
| R-PO | Snippets representativos | n.5 de §4–§11 | Cumple; un snippet no ejecutado sin rótulo (requisitos-03) |
| R-PO | Preguntas guía con respuesta | n.6 de §3–§11 | Cumple |
| R-PO | … que permitan identificar en qué caso aplica | *Aplica* en todas las preguntas: §3.7 6/6, §4.6 6, §5.6 7, §6.6 7, §7.6 6, §8.6 6, §9.6 6, §10.6 7, §11.6 7 (conteo E1; en cada sección hay ≥ un *Aplica* por pregunta) | **Cumple** (cerrado el requisitos-01 del ciclo 1) |
| Profile | Marco de referencia | §2.1–§2.4 | Cumple |
| Profile | Mapa por escenario, por contexto y por artefacto | §3.6: síntoma, escenario, **contexto**, artefacto | Cumple |
| Profile | Aplicación por escenario y qué cambia según contexto | §4.4–§8.4 con los cuatro CTX; §9.4, §10.4, §11.4 sólo CTX-POLI | Parcial (requisitos-04) |
| Profile | Métodos y marcos | Excluido y motivado en §0.1 | Cumple por exclusión declarada (cerrado) |
| Profile | Estructura común + anexo con preguntas por campo | n.1–n.9 en §4–§11; Anexo A | Cumple; la n.9 no cumple lo que §0.2 promete (requisitos-01) |
| Profile | README con ruta de lectura | Índice + §0.2 + ruta mínima | Cumple (decisión de contrato) |
| Profile | «Verificable: al cerrar, revisar contra el mapa» | Este ciclo | En curso; el estado del documento no lo refleja (requisitos-06) |
| Dual-Audience | Front matter con `traces` | L1–L18; tabla en Anexo F | Cumple con imprecisiones de la tabla (requisitos-02) |
| Dual-Audience | Bloques `entradas`/`salidas`/`validaciones` | §5.2.6 L792–L810, §12 L2401–L2418 | Cumple; §12 incompleto (requisitos-05) |
| Rule-Indexing | ia-db | Fuera de alcance, registrado (P-24) | Cerrado, no se reabre |
| R-PRIV | Sin identificadores privados | `grep -rn -i -E -f <patrón-R-PRIV>` sobre guía y `Examples/` → sin salida | Cumple |
| Encargo | `.gitignore` del laboratorio | `Examples/.gitignore`: bin/, obj/, node_modules/, .venv/, __pycache__/ | Cumple |

## 2. Hallazgos

### requisitos-01 · La subsección «Práctica» no cumple el contrato que §0.2 le fija — S2 · E1

- **Ubicación**: §0.2 L68 (contrato); §6.9 L1134; §9.9 L1770; §10.9 L2034; §11.9 L2374–L2376.
- **Ancla**: §0.2: «→ **Práctica** (dos consignas sobre experimentos que ya existen, con la respuesta esperada)». Lo que hay:
  - §11.9 tiene **una** consigna (la 1 se revirtió en la aplicación del ciclo 1 y quedó como deuda D-4, sin cerrar). §11 es «el capítulo central».
  - §6.9 consigna 2 («Escribí el ADR de `rollForward`…») y §10.9 consigna 2 («escribí qué impide y qué no impide la configuración de tu plataforma…») no son sobre un experimento y no tienen *Respuesta esperada*.
  - §9.9 consigna 2 pide marcar «cuáles de los seis metadatos de §9.6 trae y cuáles faltan»; la respuesta clasifica cinco (digest, commit, imagen / `builder.id`, toolchain) y no dice nada del (5) grafo resuelto ni de «árbol limpio» y «cuándo» de (2) y (6) (§9.6 L1731: «Seis: (1)… (6) quién la construyó y cuándo»).
  - El texto correcto de la consigna 1 de §11.9 está sostenido por la salida versionada: `Examples/N8-integracion-poliglota/salidas/E8-1-choque-de-convenciones.txt`, bloque B: `sh: ./tools/hola.sh (shebang) OK`; `FALLA` en `saluda.py (shebang)`, `json.load`, `tomllib`, `JSON.parse` y `compuerta N3: .nvmrc` → cinco.
- **Impacto**: la pieza formativa que el PO pide («formadoras de criterios») promete una forma y entrega otra; el lector que practica §11 tiene la mitad de la práctica, y en §6/§10 no puede autoevaluarse.
- **Dirección**: (a) restituir §11.9.1 con el texto del juez de costo-beneficio (`Ciclo-1/04-Aprobacion-costo-beneficio.md`, fila P-14 punto 2): «Con E8-1, columna B, predecí qué lectores fallan… *Respuesta esperada*: cinco —el shebang de `saluda.py`, `json.load`, `tomllib`, `JSON.parse` y la comparación de `.nvmrc`—; `hola.sh` corre»; (b) en §6.9.2 y §10.9.2 agregar *Criterio de corrección* (qué debe contener el ADR / la tabla para estar bien) o reescribir §0.2 como «dos consignas; las de diseño, con criterio de corrección en lugar de respuesta»; (c) completar la respuesta de §9.9.2 con los seis puntos.
- **Confianza**: 0,9.

### requisitos-02 · La tabla de trazas tiene filas que no resuelven y está ubicada bajo un título que la contradice — S3 · E1

- **Ubicación**: Anexo F L3325–L3348.
- **Ancla**: el Anexo F abre con «esta lista reúne lo que la guía **no** afirma como hecho» (L3327) y lo primero que lista es «Qué pedido cubre cada sección» (L3329), que sí es un hecho del documento. Filas inexactas: R-03 → «n.5, n.6 y n.9 de §3–§11» (L3345), pero §3 no tiene n.5/n.6/n.9 con ese sentido (§3.5 es «¿Lo resuelve un contenedor?», §3.6 el mapa, no existe §3.9; las preguntas de §3 son §3.7); P-09 → «“Qué propone la industria” de §4–§10» (L3341) deja fuera §11.3, que es justamente la estrategia de industria para la solución integrada (P-10 la cita y P-09 no).
- **Impacto**: la trazabilidad pedida (Profile «Trazable»; Rule-Dual-Audience: «las trazas apuntan al ID») lleva a secciones que no existen o que no incluyen lo central; un agente que valide por la tabla falla en §3.
- **Dirección**: mover la tabla a §0 (p. ej. §0.5 «Qué pedido cubre cada sección») o titular el Anexo F «Trazas, límites y lo que no se verificó» y ajustar su primera oración; corregir R-03 a «§3.7; n.5, n.6 y n.9 de §4–§11; Anexo A» y P-09 a «n.3 de §4–§11».
- **Confianza**: 0,85.

### requisitos-03 · Un snippet no ejecutado no lleva el rótulo que §0.3 exige — S3 · E1

- **Ubicación**: §9.5 L1708–L1716 (bloque YAML de `actions/attest`); §0.3 L97.
- **Ancla**: §0.3: «Un snippet sin experimento asociado se marca como ilustrativo». `grep -n -i ilustrativ` → sólo L97 (la regla) y L2789 (A.12). El bloque de §9.5 no se corrió («`actions/attest` … requieren una plataforma alojada», Anexo F, «No verificado») y no lleva **Ilustrativo** ni **[no verificado]**; los otros bloques de §9.5 sí remiten a E6-4/E6-5 o al Anexo A.4.
- **Impacto**: incumple la regla de evidencia que la propia guía se impone y la regla del PO «toda afirmación respaldada por evidencia verificable»; el lector no distingue ese YAML de los ejecutados.
- **Dirección**: agregar debajo del bloque, como en A.12: «**Ilustrativo**: no ejecutado (requiere GitHub); SHA resuelto con `git ls-remote` el 2026-10-09 [Bnn]», o la marca **[no verificado]** con el motivo.
- **Confianza**: 0,85.

### requisitos-04 · §9.4 y §10.4 sólo dicen qué cambia en CTX-POLI — S4 · E1 + E2

- **Ubicación**: §9.4 L1677–L1686; §10.4 L1934–L1944.
- **Ancla**: conteo de `CTX-` por sección n.4 (E1): §4.4–§8.4 = 4 contextos cada una con «Por contexto»; §9.4 = 1 (L1686 «En CTX-POLI…»); §10.4 = 1. Profile, estructura temática: «Aplicación por escenario — … y qué cambia según el contexto». La guía sí trata la diferencia por ecosistema en §9.2.1 (.NET) y §9.2.2 (Node.js y Python), pero no la lleva a la n.4.
- **Impacto**: el lector que entra por la tabla «Por contexto» de §3.6 (CTX-NODE → §9.2.2) no encuentra en la sección de aplicación de §9/§10 qué le toca; inconsistencia de forma frente a §4.4–§8.4.
- **Dirección**: una línea «Por contexto» en §9.4 (CTX-NET: metadatos del SDK y `ContinuousIntegrationBuild`; CTX-NODE: `npm sbom`/procedencia de npm; CTX-PY: ruedas con `SOURCE_DATE_EPOCH` y PEP 770) y en §10.4 (qué pasos de la compuerta corren en cada uno), remitiendo a lo ya escrito; o declarar «no cambia salvo en CTX-POLI».
- **Confianza**: 0,7.

### requisitos-05 · El contrato YAML de §12 no cubre los pasos 8a–10 que la tabla sí hace verificables — S4 · E1

- **Ubicación**: §12, tabla L2384–L2397 y bloque L2400–L2418.
- **Ancla**: la tabla da «Lo que queda verificable» para 1–10 (8a: «Artefacto, registro del entorno y SBOM publicados juntos»; 9: «Ningún cambio de versión sin PR»; 10: «EA-1 y E8-1…E8-6»). El bloque `salidas` llega hasta 8a/8b y omite 9 (`CODEOWNERS`, bots, ADR) y 10; `validaciones` cubre 3–7 y omite 1, 2, 8a, 8b, 9 y 10. Rule-Dual-Audience: las dos caras describen el mismo hecho, «ante divergencia, corregir».
- **Dirección**: agregar a `salidas` «CODEOWNERS, configuración de bots, ADR de descongelamiento (paso 9)» y «política por extensión revisada para los tres lectores (paso 10)»; a `validaciones`, una línea por paso restante tomada de la columna «Lo que queda verificable».
- **Confianza**: 0,75.

### requisitos-06 · El documento sigue en `status: borrador` y rc.1 cuando el ciclo 2 lo trata como obra finalizada — S4 · E2

- **Ubicación**: front matter L5–L6; banda de versión L26; Control de cambios L3387–L3391.
- **Ancla**: PO: «La mesa debe volver a analizar el documento una vez finalizado y hacer las correcciones pertinentes»; L5 `version: 1.0.0-rc.1`, L6 `status: borrador`. `05-Aplicacion.md` L150: «el cambio a un estado de versión candidata no estaba en ningún parche aprobado y se deja al cierre del ciclo».
- **Impacto**: el único entregable queda rotulado como borrador; un lector o agente lo toma como no apto para aplicar.
- **Dirección**: al cierre del ciclo 2, fijar `status` (p. ej. `vigente`) y `version: 1.0.0`, con su fila en el Control de cambios y la banda de L26 actualizada. Es decisión de cierre, no de edición.
- **Confianza**: 0,7.

## 3. Revisado y bien

1. **Criterio de aplicación en las preguntas guía**: todas las preguntas de §3.7 y de §4.6–§11.6 cierran con *Aplica* (conteo E1 por sección; ninguna sección con menos rótulos que preguntas), incluida una pregunta situada en el caso por capítulo. El pedido central del PO («identificar en qué caso se aplica cada concepto») queda cumplido.
2. **Mapa y glosario**: §3.6 tiene las cuatro puertas (síntoma, escenario, contexto, artefacto) con enlaces; el cruce automático de los términos en negrita de las tablas de definición contra el Anexo C da 0 faltantes, salvo los tres sinónimos que el glosario declara.
3. **Trazas y alcance**: los 17 IDs de `traces:` tienen fila en la guía (Anexo F) y §0.1 declara y motiva la exclusión de los enfoques de entorno completo; la privacidad está limpia (grep de identificadores privados sobre guía y `Examples/` sin salida) y `Examples/.gitignore` cubre lo pedido.

## 4. Solicitudes de convocatoria

- **Verificación de evidencia**: Anexo F, «Datos volátiles al 2026-10-07» (L3380) dice «Python 3.15.0 prevista para el 2026-10-09» y la guía tiene `last_review: 2026-10-09`; además, el bloque se fecha el 07 mientras la revisión es del 09. Fuera de mi mandato juzgar el dato; pido que se revalide al cierre.
- **Edición bibliográfica**: la fila 1.0.0-rc.1 del Control de cambios (L3391) es un párrafo de ~350 palabras en una celda; no opino sobre la forma.
