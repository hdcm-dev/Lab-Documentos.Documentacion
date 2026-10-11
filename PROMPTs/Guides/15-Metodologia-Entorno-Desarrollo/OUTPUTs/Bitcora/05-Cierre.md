---
doc_id: BIT-15-05
doc_type: cierre-de-mesa
title: Cierre de la mesa — Metodología del entorno de desarrollo
status: vigente
origin: agent
confidence: 0.85
owner: registro de cierre (sin voto en la mesa)
last_review: 2026-10-09
audience: [PO, mesa-evaluadora, próxima corrida]
traces: [PROMPT-15, MARCO-MESA-§7, BIT-15-00, BIT-15-02, BIT-15-04, MESA-C1, MESA-C2, MESA-C3]
---

# Bitácora 05 — Cierre de la mesa

**Fecha del cierre:** 2026-10-09 (la fecha de sistema de las tres aplicaciones; la primera versión integrada de la guía es del 2026-10-07).
**Norma de forma:** `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §7 (bloque `cierre`), ampliado con los campos que pide el prompt reeditado (`OUTPUTs/Metodlogia-Entorno-Desarrollo.md` §13).
**Insumos:** `00-Contrato-De-Entrada.md`, `02-Cohesion-Global.md`, `04-Integracion.md`, todo `Mesa/Ciclo-1/` a `Mesa/Ciclo-3/` y la guía final. Las cifras de hallazgos salen del historial del orquestador y de los consolidados; las de la guía, de la medición de este cierre (§4).

## Índice

- [1. Por qué cierra la mesa](#1-por-qué-cierra-la-mesa)
- [2. Bloque de cierre](#2-bloque-de-cierre)
- [3. Lectura del bloque](#3-lectura-del-bloque)
- [4. Verificación final de este cierre](#4-verificación-final-de-este-cierre)
- [5. Trazabilidad final: solicitud del PO → sección de la guía](#5-trazabilidad-final-solicitud-del-po--sección-de-la-guía)
- [6. Para el PO: apartamientos y pendientes que no son escaladas](#6-para-el-po-apartamientos-y-pendientes-que-no-son-escaladas)

## 1. Por qué cierra la mesa

El marco cierra cuando se cumple **cualquiera** de cuatro criterios (§7). Contra el contrato de entrada (`umbral_de_calidad: S1 y S2 bloquean`, `ciclos_max: 3`):

| Criterio | Estado al cierre del ciclo 3 | ¿Se cumple? |
|---|---|---|
| Sin hallazgos abiertos por encima del umbral | Los 10 ítems S2 del ciclo 3 recibieron parche y se aplicaron. Queda abierta la regresión R-1 (fila B224, parte de C3-05/C3-50); la guía no afirma nada sin fuente mientras tanto (cita [B62] y [B61]). No hubo ningún S1 en los tres ciclos | En lo sustantivo sí, con R-1 como deuda declarada |
| Rendimientos decrecientes (< 20 % de válidos nuevos respecto del ciclo anterior) | Ciclo 3: 35 válidos frente a 40 del ciclo 2 (87,5 %) | No |
| `ciclos_max` agotado | 3 de 3 | **Sí: es el criterio que cierra** |
| Escalada bloqueante sin responder | Ninguna escalada en los tres ciclos | No |

La relectura integral que exige DC-04 está cumplida: los tres ciclos juzgaron la guía completa, después de la integración (1.0.0-borrador → 1.0.0-rc.1 → 1.0.0 → 1.1.0).

## 2. Bloque de cierre

```yaml
cierre:
  version_final:
    guia: LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md
    version: 1.1.0
    status: vigente
    guia_sha256: 4f7e589616370df0a477ed87b580aed54cf1e698f6e22f2be1ffe60d12ddfa57   # = Mesa/Ciclo-3/aplicacion/despues.sha256
    lineas: 3637
    palabras_wc: 55261
    fecha: 2026-10-09
    linaje: "1.0.0-borrador (2026-10-07, 3060 l.) → 1.0.0-rc.1 (C1, 3391 l.) → 1.0.0 (C2, 3606 l.) → 1.1.0 (C3, 3637 l.)"
  ciclos_ejecutados: 3          # los tres sobre el documento completo (relectura integral, DC-04)
  criterio_de_parada: ciclos_max   # rendimientos decrecientes no se cumplió (35/40 = 87,5 %)

  nucleos:
    validados: [N0, N1, N2, N3, N4, N5, N6, N7, N8]   # capítulos §3–§11; cada uno con su carpeta en Examples/
    a_revalidar:
      - "N7 y N8: deuda D-5 del ciclo 1 sigue abierta (tres coincidencias de texto viejo sin nota de origen: N7 fila ESC-01 de §12, N8 fila ESC-01 de §11.4 por C1-06, N8 bloque docker buildx de §11.5 por C1-15)"

  panel:
    nucleo_permanente:   # ítems de jurado (todos PROCEDE) en que figura como origen, C1/C2/C3
      - "requisitos: 7/5/8"
      - "verificacion-evidencia: 4/4/2"
      - "lector-sin-contexto (implementador ingenuo, estación Windows + VS): 8/5/4"
      - "abogado del diablo: 10/18/11 (incluye los lados de contradicción)"
    perfiles_del_po:     # DC-03, no removibles
      - "didactica: 6/5/6"
      - "edicion-bibliografica: 5/7/2"
      - "senior-dotnet: 6/5/5"
      - "arquitecto-software: 9/9/8"
      - "desarrollador: 4/6/5"
    convocados_por_señal:
      - "CAT-FORMAL (formal/matemático, convocatoria automática por S-14, con carta): 1/1/2; además 2/3/2 en el lote S4"
    ad_hoc:
      - "AH-001 · Ecosistemas Node.js y Python: ¿lo que la guía afirma de npm/pnpm/Yarn/Corepack/uv/Poetry/PEP es exacto y vigente? Aportó 3/2/1 ítems de jurado y 1/3/3 de S4: devEngines y engine-strict, multiplataforma de los locks de pnpm/Yarn, pmOnFail de pnpm, npm 12, uv y Python 3.15"
      - "AH-002 · Cadena de suministro y gobierno de la CI: ¿cada garantía atribuida (lock, digest, SHA, SBOM, firma, SLSA, ramas protegidas) es la que su especificación o plataforma otorga? Aportó 7/7/4 ítems: SLSA sin builder.id, ramas protegidas por plan, credenciales y packages: read en A.12, builder-id, retención del log del runner, gh attestation verify con firmante"
    descartados:
      - "Windows / Visual Studio: NO_INSTANCIAR (3–2) por falta de host Windows; pedido cuatro veces (C1, C2-Q04, C3-Q10). Se resolvió como límite estructural declarado en el Anexo F y en el motivo por defecto de [no verificado]"
      - "Seguridad y privacidad (general): secretos de firma cubiertos por AH-002; privacidad, por el chequeo mecánico (0 en los tres ciclos)"
      - "Operación y entrega: absorbido por AH-002; despliegue fuera de alcance"
      - "Datos y dominio, Concurrencia, Rendimiento y costo, Interfaz/consumidor externo, Cumplimiento, Accesibilidad: sin señal suficiente (5–0 o 4–1 en contra)"
      - "Contenedores/devcontainers y Unicode como ad hoc: cubiertos por roles del panel y por E1/E5"
      - "Node.js y Python como dos agentes: una carta común alcanzaba"
      - "Editor de cierre con presupuesto (C2-Q10, C3-Q09): no convocado; el jurado del ciclo 3 lo condicionó a un parche P-26 con texto exacto, que no se diseñó"
    postergados_por_cupo: []      # el techo ya estaba excedido (núcleo 4 + 8); nadie quedó fuera por cupo
    aporte_nulo: []               # todos los roles tuvieron al menos un PROCEDE en cada ciclo
    aporte_decreciente:           # señal para una corrida futura, no veto
      - "AH-001: 3 → 2 → 1 ítems de jurado"
      - "verificacion-evidencia: 4 → 4 → 2 (su función de muestreo sigue siendo la compuerta de evidencia)"
      - "edicion-bibliografica: 5 → 7 → 2"

  hallazgos:
    detectados: 199          # 72 + 70 + 57 (informes de origen)
    items_de_jurado: 123     # 48 + 40 + 35
    procedentes: 123         # 100 % en los tres ciclos
    lote_S4: 46              # 10 + 18 + 18, aplicados por el auditor (C3-41 sólo en parte)
    nivel_C: 30              # 9 + 10 + 11 preguntas, no van a jurado
    parches: { disenados: 72, aprobados: 72, aplicados: 72 }   # 24 + 23 + 25
    revertidos: 4            # C1: P-08 ítem 3 y P-14 ítem 24 (consigna 1 de §11.9); C3: fila B224 de P-16 (R-1) y la verificación derivada de P-18 (registrada, el parche se conservó)
    severidad_por_ciclo: { C1: "25 S2 / 23 S3", C2: "14 S2 / 26 S3", C3: "10 S2 / 25 S3", S1: 0 }
    votos_no_unanimes: { C1: "C1-46, C1-47 (4-1)", C2: "C2-36 (NO_PROCEDE del juez de riesgo sobre el tope duro)", C3: ninguno }

  coherencia:
    contradicciones: 1             # §11.6 «los tres runtimes tienen que estar en la misma imagen (E8-3)» frente a C3-07, §8.2.2 y §11.2.7 (runner con los tres setup-*); señalada en minoría por coherencia histórica (P-11 op. 14), no entró al lote
    solicitudes_sin_seccion: 0     # §5 de este documento
    afirmaciones_sin_evidencia: 0  # conocidas; «desde el SDK 11» cita [B58], que no lo dice (fuente correcta: NETSDK1238), queda con R-1
    secciones_huerfanas: 0         # las 20 entradas del índice tienen traza en el Anexo F
    terminos_ambiguos: 0           # cadenas retiradas en 0 (C3 §5); glosario alineado
    requisitos_sin_prueba: 0       # cada P-nn tiene experimento o fuente; lo de Windows va rotulado [no verificado]

  compuertas:
    indice: "20 entradas = 20 encabezados ## en el mismo orden"
    enlaces_internos_rotos: 0      # 92 enlaces
    mermaid_invalidos: 0           # 11 de 11 renderizan (mermaid-cli 12.0.0, ciclo 3)
    yaml_invalidos: 0              # 7 de 7
    bibliografia: "223 [Bnn] definidas = 223 citadas, 0 URL repetidas"
    identificadores_privados: 0    # guía y Examples/ (re-medido en este cierre)
    readme_por_experimento: "10 carpetas (N0–N8, A-plantillas) + README raíz; las 75 subcarpetas aparecen en el README de su carpeta"
    gitignore_examples: ok         # bin/, obj/, node_modules/, .venv/, __pycache__/
    anexo_A_igual_al_laboratorio: "22 de 22 bloques-archivo, byte a byte"

  experimentos:   # 74 IDs en 66 filas del Anexo E; salidas versionadas en cada salidas/
    - "N0-modelo-de-capas-y-reproducibilidad/: bash correr-todo.sh → E0-1…E0-6, E0-2b, E0-5b"
    - "N1-codificacion-y-finales-de-linea/: sh correr-todo.sh → E1-01…E1-13 (E1-01: el .cs en cp1252 da literal corrupto e identificador que no compila en Linux)"
    - "N2-politica-de-texto-y-remediacion/: bash correr-todo.sh → E2-1…E2-8 (E2-8, relevamiento fechado, no se re-corre)"
    - "N3-fijacion-del-toolchain/: sh correr.sh por subcarpeta → E3-1…E3-7"
    - "N4-congelamiento-de-dependencias/: según su README → E4-1…E4-5"
    - "N5-entornos-en-contenedores/: bash eN-…/experimento.sh → E5-1…E5-8, E5-5b (E5-8: mismo SDK, misma DLL en tres bases Linux)"
    - "N6-procedencia-y-trazabilidad/: bash eN-…/experimento.sh → E6-1…E6-6, E6-2b"
    - "N7-compuertas-y-gobierno/: bash correr-todo.sh → E7-1…E7-7, E7-5b"
    - "N8-integracion-poliglota/: bash eN-…/experimento.sh → E8-1…E8-6"
    - "A-plantillas/: bash verificar.sh → EA-1 rc=0 (114 de 116 líneas iguales al re-correrlo en C3)"

  relectura_integral:
    ejecutada: true
    ciclos: 3
    parches_aplicados: 72
    saldo_de_prosa: "C2: −46 palabras de prosa propia (+950 de evidencia y plantillas); C3: +531 de prosa (+463 de evidencia), admitido por voto explícito frente a C2-36"
    clasificacion_edicion_compresion_coherencia: "no se registró por tipo; no se reconstruye a posteriori"

  apartamientos_del_marco:
    - "Techo del panel (§4.1.4, §5.1.c): núcleo 4 + 8 en vez de núcleo + 5, porque el PO fijó cinco perfiles no removibles y pidió evaluar expertos extra; mitigado con tope de hallazgos y disolución temprana"
    - "Versión 1.1.0 y no 1.0.1 en el ciclo 3: unanimidad del jurado (el lote agrega un experimento, fuentes y una fila de la ruta mínima)"
    - "Rule-Indexing: la entrada de la ia-db y el índice de la colección (LAB/Lab-Documentos/Guides/README.md) no se escribieron, fuera del alcance de escritura (C1 P-24, C3-Q07)"
    - "Nombres de archivo de la bitácora distintos de los que prevé el prompt reeditado §11 (correspondencia en README.md)"
    - "Salvaguarda de consenso vacío (§9): la unanimidad del jurado superó el 80 % en los tres ciclos (46/48, 39/40, 35/35) y no quedó registrada la revisión de homogeneidad; el desacuerdo apareció en la aprobación (votos MEJORAR_PLAN en minoría)"

  supuestos: [SUP-01, SUP-02, SUP-03, SUP-04, SUP-05, SUP-06, SUP-07, "fecha de trabajo 2026-10-09 = fecha de sistema de las aplicaciones", "«aprobado» = lote que pasó la orquestación; los remedios de votos MEJORAR_PLAN en minoría no se aplicaron"]

  deuda_declarada:   # ningún parche recibió NO_APLICAR; esto es lo que quedó sin aplicar, con su motivo
    - "R-1 (C3, regresión): la reconsulta del índice de versiones de .NET del 2026-10-09 no tiene fila propia; se revirtió B224 porque repetía la URL de B62. Remedios en minoría: NETSDK1238 como B224 (evidencia) o anotar la reconsulta en B62 (impacto)"
    - "«Desde el SDK 11» (CheckSdkVulnerabilities, §6.3, §10.2.6) cita [B58], que no lo dice; la fuente es NETSDK1238. Minoría de evidencia, no entró al lote"
    - "Saldo de prosa +531 frente a la meta ≤ 0 de C2-36: admitido por voto explícito; la pasada de compresión (P-26, editor de cierre) no se diseñó"
    - "Contradicción §11.6 frente a C3-07 (P-11 op. 14): minoría de coherencia histórica"
    - "§8.2.2 dice «tres sistemas operativos» y E5-8 midió tres distribuciones Linux; el laboratorio y la nota O-1 lo aclaran, el párrafo no"
    - "Minorías del juez de impacto: Práctica de §12 atribuye a E3-1 un mensaje de E0-2 (J-I2, desde C2); workflow que se activa al llegar a main en el contrato de §12 (J-I3); apertura del Anexo A promete un paso de verificación por plantilla que A.14–A.16 no dicen (J-I5); dos IDs de la línea de fechas del Anexo E (J-I8); respuesta de §10.6 sin «sin python3 el verificador no corre» (J-I9)"
    - "Rótulo de la nota O-9 en la capa de origen (coherencia histórica)"
    - "D-5 (C1): tres notas de origen faltantes en N7 y N8"
    - "Excluido por decisión en C2 §9 y C3: aviso de ejecutable sin lock; editorconfig-checker por defecto; hook que falla con lock sin marcar; versión de la imagen del runner en el registro; archivar el log «Set up job»; reemplazo global de «registro»; script de mensajes de Yarn/pnpm/uv/Poetry; tabla de ocho repos sobre global.json; Práctica nueva de §3 (C3-41)"
    - "Límite estructural: nada se corrió en Windows, WSL 2 ni Docker Desktop; 36 marcas [no verificado] en la guía; de las 20 sin motivo propio, 17 son de Windows/VS/Git Bash/ESC-01 (C3 §2). Preguntas abiertas C3-Q01…C3-Q05"

  escaladas_pendientes: []

  capas_a_revalidar:
    - "OUTPUTs/Metodlogia-Entorno-Desarrollo.md (prompt reeditado): §11 prevé archivos BIT/10-…/29-Cierre.md y carpetas Examples/<NN>-<núcleo>-<tema>/; la corrida usó Nucleos/, Mesa/Ciclo-n/, 05-Cierre.md y Examples/N<n>-<núcleo>/"
    - "Bitcora/Nucleos/N7 y N8 (D-5)"
    - "Anexo D de la guía, filas B58/B61/B62 (R-1)"
    - "Datos volátiles del Anexo F antes de aplicar la guía: fin de soporte de .NET 8 y 9 el 2026-11-10 (A.3 y el laboratorio usan SDK 8.0.425), Python 3.15.0 y uv 0.13.0 publicados el 2026-10-09, SDK 10.0.401"
    - "Índice de la colección (LAB/Lab-Documentos/Guides/README.md) y la ia-db de Lab-Documentos.Documentacion: entrada propuesta en Mesa/Ciclo-1/05-Aplicacion.md §9, con cifras viejas (~3400 líneas, 73 experimentos, B204): hoy 3637 líneas, 74 experimentos, 223 fuentes"
    - "Examples/: si se corrige R-1 o la contradicción de §11.6, ningún experimento cambia; si se agrega la verificación en Windows, se suma una carpeta y su fila en el Anexo E"
```

## 3. Lectura del bloque

**Panel.** Ningún rol tuvo aporte nulo: todos tuvieron al menos un `PROCEDE` en cada ciclo, y por eso ningún ad hoc se disolvió antes de tiempo. Los conteos son ítems de jurado (todos `PROCEDE`) en cuya columna «Orígenes» figura el rol. Se contaron con un guion sobre los tres `01-Consolidado.md`; un ítem con varios orígenes cuenta para cada uno, y en el abogado del diablo se incluyen los lados de contradicción. No son hallazgos únicos, y la suma es mayor que 123.

**Lo que aportaron los ad hoc y la convocatoria automática.**

- AH-001 sacó de la guía afirmaciones de Node.js y Python que ningún otro rol podía refutar. Por ejemplo, que `devEngines` falla por defecto, que los locks de pnpm y Yarn registran todas las variantes de plataforma y la vigencia de npm 12 y de Python 3.15.
- AH-002 corrigió el alcance de las garantías: SLSA sin `builder.id`, ramas protegidas según el plan, permisos de la CI, la retención del log del runner y la verificación de atestaciones con firmante y rama.
- CAT-FORMAL entró poco al jurado, pero acotó cuantificadores y versiones observadas. Su hallazgo de digest de índice (C2) se perdió en el consolidado y se recuperó en C3-10.

**El punto ciego que se sabía.** El especialista Windows/Visual Studio se pidió cuatro veces. La razón para no instanciarlo fue siempre la misma: sin host Windows no produce evidencia E1. La mesa eligió declararlo como límite en el Anexo F y en el motivo por defecto de **[no verificado]** antes que simular una verificación. Es el riesgo más alto que queda para un lector del escenario ESC-01.

**Revertidos.** El orquestador cuenta 2 en el ciclo 1 y 2 en el ciclo 3. Los dos del ciclo 1 son ítems de parche cuya propia evidencia los contradecía. En el ciclo 3, `05-Aplicacion.md` registra una regresión (R-1). La segunda es la verificación de P-18 que cayó por R-1: se registró, pero P-18 se conservó porque revertirlo dejaba datos volátiles sin fuente.

## 4. Verificación final de este cierre

Corrida el 2026-10-09 sobre la guía final y el laboratorio.

| Chequeo | Comando o método | Resultado |
|---|---|---|
| Integridad | `sha256sum` de la guía frente a `Mesa/Ciclo-3/aplicacion/despues.sha256` | iguales (`4f7e5896…`): nada cambió después de la aplicación del ciclo 3 |
| Índice | lista de `](#…)` del bloque «Índice» frente a los `##` fuera de código | 20 = 20, mismo orden |
| Anclas | todos los `](#…)` frente a los slugs de los encabezados | 92 enlaces, 0 rotos |
| Privacidad | el patrón de identificadores del caso privado del contrato (R-PRIV, `00-Contrato-De-Entrada.md`), sin distinguir mayúsculas | guía: 0 líneas; `Examples/` (sin `bin/`, `obj/`, `node_modules/`, `.venv/`): 0 archivos. En la bitácora sólo aparece dentro de los comandos de chequeo, nunca como dato |
| README por experimento | `README.md` en cada carpeta de primer nivel de `Examples/`, y cada subcarpeta nombrada en el README de su carpeta | 10 de 10 carpetas con README, más el README raíz; 0 subcarpetas sin mención |
| `.gitignore` | lectura de `Examples/.gitignore` | `bin/`, `obj/`, `node_modules/`, `.venv/`, `__pycache__/` |
| Extensión | `wc -lw` | 3637 líneas, 55 261 palabras |

Para N3 a N8, los experimentos se documentan en el README de la carpeta del núcleo, no en un README por subcarpeta. Así lo pidió el contrato («el `README.md` del laboratorio indica cómo correr todos») y así lo verificaron los tres ciclos. **[criterio]**

## 5. Trazabilidad final: solicitud del PO → sección de la guía

Cada elemento del prompt del PO, dónde quedó en la guía 1.1.0 y qué lo respalda. Los ID P-nn y R-nn son los del Anexo F de la guía. Las tres últimas filas son pedidos de proceso, que no van a la guía sino a la bitácora.

| Solicitud del PO | ID | Sección de la guía | Respaldo |
|---|---|---|---|
| El fix: `.cs`/`.razor` en cp1252 que en Linux no compilan y muestran `?`; en Windows no cambia nada | P-01 | §1 (caso sintético), §4.2.1–§4.2.2 | E1-01, E1-11; [B15], [B19] |
| Se desarrolla con Visual Studio en Windows, en Linux y en devcontainers | P-02 | §2.1 (ESC-01…ESC-05), §8.2.4 | Anexo F (límite: sin Windows) |
| Criterio unificado de codificación («setcode», SUP-01) sin commits de BOM | P-03 | §5, §10.2.5, A.1, A.2, A.15 | E2-1…E2-8 |
| Congelar NuGet | P-04 | §7, A.5, A.6 | E4-1…E4-3 |
| Congelar compiladores y SDK | P-05 | §6, A.3 | E3-1…E3-7 |
| ¿Se puede con contenedores? | P-06 | §3.5, §8 | E5-1…E5-8 |
| Integrarlo donde se usan herramientas en Windows y Linux | P-07 | §0.4, §3.6, §8.2.4, §10.4, §11.4, §12, Anexo B | E7-1…E7-7; Anexo F |
| Saber con qué entorno se ensambló cada artefacto | P-08 | §3.2 (capa 6), §9, A.17 | E6-1…E6-6, EA-1 |
| Estrategias de la industria para .NET, Node.js y Python | P-09 | apartado n.3 («Qué propone la industria») de §4–§11 | Anexo D (223 fuentes) |
| En especial, qué pasa al integrarlos en una única solución | P-10 | §11 (capítulo central) | E8-1…E8-6 |
| Secciones jerárquicas con índices, definiciones, explicaciones, ejemplos, mermaid | R-01 | Índice (20 entradas); n.1–n.2 de cada capítulo; 11 mermaid | Compuertas de §4 |
| Autocontenido, no delta | R-02 | toda la guía; Anexo C (glosario) | La guía no remite a la bitácora |
| Ejemplos, snippets y preguntas guía con respuestas que forman criterio y dicen cuándo se aplica cada concepto | R-03 | §3.7; n.5, n.6 y n.9 (Práctica) de §4–§11; Anexo A | 61 respuestas con *Aplica*; A.1–A.18 verificadas por EA-1 |
| Descomposición conceptual por núcleos, cohesión global e integración | R-04 | §3 a §11 = N0 a N8 | `01-Descomposicion-Conceptual.md`, `Nucleos/`, `02-Cohesion-Global.md`, `04-Integracion.md` |
| No inventar; toda afirmación con evidencia verificable | R-06, R-07 | §0.3 (marcas), Anexos D, E y F | 223 fuentes con fecha; 74 experimentos |
| Profile Study-Guide-Documentation | R-PROF | §2 (marco), §3.6 (mapa), estructura n.1–n.9, Anexos A–C | `03-Marco-De-Referencia.md` |
| Caso privado sin identificadores (regla de la corrida) | R-PRIV | §1 | Chequeo de §4: 0 |
| Reeditar el prompt sobre el marco de mesa | — | (no va a la guía) | `OUTPUTs/Metodlogia-Entorno-Desarrollo.md` |
| Mesa con didáctica, edición, senior .NET, arquitectura, desarrolladores; analizar si falta un experto | — | (no va a la guía) | `Mesa/Ciclo-1/00-Convocatoria.md`: AH-001, AH-002, CAT-FORMAL |
| Relectura del documento terminado: edición, compresión, coherencia | — | Control de cambios de la guía | `Mesa/Ciclo-1/` a `Mesa/Ciclo-3/`; este cierre |
| Apuntes, borradores, debates y precompilaciones de la mesa | R-05 | (no van a la guía) | Toda la bitácora; índice en `README.md` |

`solicitudes_sin_seccion: 0`.

## 6. Para el PO: apartamientos y pendientes que no son escaladas

Ninguno de estos puntos activó un disparador de escalada del marco (§6), así que la mesa decidió sola. Se informan porque son decisiones que el PO puede querer revisar:

1. **Panel más grande que el techo del marco** (núcleo 4 + 8). Se debió a la consigna «analiza si necesitas un experto más».
2. **Versión 1.1.0 en lugar de 1.0.1.** Si se prefiere 1.0.1, hay que cambiar tres lugares: el front matter, el recuadro de apertura y el control de cambios.
3. **Indexación pendiente** (Rule-Indexing). La guía no figura en `LAB/Lab-Documentos/Guides/README.md` ni en la ia-db. La entrada propuesta está en `Mesa/Ciclo-1/05-Aplicacion.md` §9, con cifras que hay que actualizar (§2, `capas_a_revalidar`).
4. **Verificación en Windows.** Es el único camino para bajar las 36 marcas **[no verificado]**: una estación con Visual Studio y una corrida de A.11, §5.2.6 y `global.json` con `paths`.
5. **Saldo de prosa positivo (+531) en la 1.1.0.** La mesa lo aceptó por voto explícito. Si se quiere la compresión, el próximo paso es un P-26 con texto exacto.
