---
doc_id: BIT-16-MESA-C2-08
doc_type: cierre-de-ciclo
title: Ciclo 2 · Cierre (M§7)
version: v1
status: cerrado; abre el ciclo 3 (último por ciclos_max)
origin: agent (secretaría de la mesa)
last_review: 2026-10-26
traces: [BIT-16-MESA-C2-00, -01, -03, -04, -05, -06, -07, BIT-16-MESA-C1-08, BIT-16-04 v2, BIT-16-00, M§6, M§7, M§9]
---

# Ciclo 2 · Cierre

El ciclo 2 cierra con la **ESTRUCTURA APROBADA v2** del cuerpo de conocimiento (`../../04-Plan-De-Integracion.md`, 2026-10-26; la v1 en `../../04-Plan-De-Integracion.v1.md`). **No es el cierre de la mesa**: corresponde un **ciclo 3**, que es el último que admite el contrato (`ciclos_max: 3`).

## 1. Criterio de parada (M§7)

| Criterio | Cuenta | ¿Se cumple? |
|---|---|---|
| Rendimientos decrecientes: hallazgos válidos nuevos (≥ S3, `PROCEDE`) del ciclo N < 20 % de los del ciclo N-1 | Ciclo 1: **63** (S2 39, S3 24; todos `PROCEDE`). Ciclo 2: **57** (H2-001…H2-057: S1 2, S2 32, S3 23; H2-058 y H2-059 son S4 y no cuentan). 57 / 63 = **90,5 %** | **No** (90,5 % ≥ 20 %) |
| No quedan hallazgos abiertos por encima del umbral (S1 y S2 bloquean) | Los 57 tienen parche aplicado, pero queda **abierto H2-050 (S2)**: P-12 debía decidirse en la aprobación de este ciclo y no se votó (DEP-15 abierta, condición previa de 04, PD-4, 05, 12, 16 y PD-1). H2-001 (S1) queda cerrado sólo en forma provisional: su tope depende de la papeleta de RV-03, sin votar. Además, la objeción de J4 a PAR2-21 muestra una dependencia huérfana nueva (DEP-12 sigue exigiendo SSE en un controller que ya no existe) | **No** |
| Se agotó `ciclos_max` | 2 de 3 ejecutados | **No** |
| Escalada bloqueante sin responder | ESC-001 (embeddings) sigue sin respuesta, pero no bloquea: rige el default EMB-B (SUP-09). No hay escaladas nuevas | **No** |

**Decisión: se abre el ciclo 3**, último por contrato. Su objeto es la v2, con un alcance acotado a lo que este ciclo dejó sin votar o sin resolver (§3). Si el ciclo 3 no cierra por umbral, cierra por `ciclos_max` con la deuda declarada.

## 2. Bloque de cierre

```yaml
cierre:
  ciclo: 2
  fecha: 2026-10-26
  version_final: "BIT-16-04 v2 (04-Plan-De-Integracion.md) — ESTRUCTURA APROBADA v2; v1 en 04-Plan-De-Integracion.v1.md y v0 en 04-Plan-De-Integracion.v0.md"
  ciclos_ejecutados: 2
  decision: "ciclo 3 (último por ciclos_max = 3): 57/63 = 90,5 % de hallazgos válidos nuevos y H2-050 (S2) abierto"
  panel:
    convocados:
      # hallazgos que llegaron a la consolidación / ítems H2 en los que figura como origen
      - "requisitos (núcleo): 7 / 8"
      - "verificación-QA (núcleo): 7 / 7"
      - "implementador ingenuo (núcleo): 7 / 9"
      - "abogado del diablo (núcleo): 7 en el panel + 7 en la revisión de los NO_PROCEDE / 9"
      - "didáctica (pedido del PO, DC-02): 6 / 6"
      - "edición de material bibliográfico (pedido del PO): 6 / 6"
      - "senior .NET (pedido del PO): 7 / 8"
      - "experto en IA (pedido del PO): 7 / 9"
      - "arquitectura de software (pedido del PO y catálogo con señal): 7 / 8"
      - "desarrollador de código (pedido del PO): 6 / 7"
      - "Operación y entrega (catálogo M§4.1.2, convocado en este ciclo; señal: plan v1 §E.5 tope de turnos, §E.1 arnés con turnos, §F.9 contenedor, §G.3 DEP-14): 6 / 7"
    descartados:
      - "Datos y dominio: NO_CONVOCAR; lo cubren senior .NET e IA"
      - "AH-03 Ecosistema LangChain/LangGraph: NO_CONVOCAR; P-09 vigente"
    ad_hoc:
      - "AH-01 Seguridad de aplicaciones con LLM: ¿lo que la v1 enseña es seguro de copiar? Aportó H2-009, H2-012, H2-013, H2-014 y H2-052 (aprobación sin MAF, texto no confiable a mitad del bucle, Host y Origin en /mcp, MCP cliente, datos de personas en el registro). 5 / 5, dentro del tope de su carta"
      - "AH-02 Evaluación LLM/RAG: ¿qué conclusiones se pueden sostener con M chico y juez local? Aportó H2-022, H2-023, H2-026, H2-027, H2-029, H2-030, H2-031 y parte de H2-002. 7 / 8; su carta dice tope 5: el apartamiento del ciclo 1 se repite"
      - "Auditor de homogeneidad (M§9, sin voto): diagnóstico «mixto» del jurado del ciclo 1; motivó el jurado endurecido y los 14 re-votos"
    postergados_por_cupo:
      - "Formal / matemático: señal presente (Clopper-Pearson, binomial pareada, umbrales de calibración); cubierto por AH-02, QA y el cuerpo auditor. Se recomienda para el ciclo 3 si se vota la regla de §10.4 y las clases de t"
    aporte_nulo: []
  homogeneidad:
    sospecha: false
    jurado: "unánimes 70 de 89 ítems (78,7 %), bajo el umbral de M§9 (80 %); 85 PROCEDE y 4 NO_PROCEDE (RAT-AJ-01, RAT-AJ-03, RAT-AJ-05, RV-12); 5 votos INSUFICIENTE (0 en el ciclo 1); 0 vetos de riesgo"
    aprobacion: "19 de 27 parches por unanimidad (70 %); 8 con objeción concreta en minoría (PAR2-01, -06, -07, -09, -17, -21, -24, -25)"
    comparacion_ciclo_1: "ciclo 1: 94 de 94 unánimes (100 %) y 21 de 24 parches A5; ciclo 2: siete contradicciones explícitas en el panel, minorías fundadas en 19 ítems, J3 midiendo en llamadas y segundos"
    nota: "70/89 queda 1,3 puntos bajo el umbral: margen chico. La mejora se apoya en las minorías fundadas (J2 y J3 sobre todo), no sólo en el porcentaje"
  hallazgos:
    detectados: 96             # 12 informes × 7 + AH-01 5 + revisión de NO_PROCEDE 7
    consolidados: 59           # H2-001…H2-059 (S1 2, S2 32, S3 23, S4 2)
    items_votados: 89          # 59 H2 + 9 ratificaciones + 14 re-votos + 7 contradicciones
    procedentes: 85
    no_procedentes: 4
    validos_nuevos_ge_S3: 57
    parches: 27
    aplicados: 27              # 27 APLICAR, 0 MEJORAR_PLAN por mayoría, 0 NO_APLICAR, 0 ESCALAR
    revertidos: 0
    ajustes_de_aplicacion: 0   # la única completación (R-02 «plan B» → «EMB-B») la exige la verificación de PAR2-02
  coherencia:
    contradicciones: 1         # DEP-12 sigue exigiendo SSE en un controller que PAR2-11 sacó (objeción de J4 a PAR2-21)
    terminos_con_dos_sentidos: 0     # «nivel A/B» resuelta: dificultad B/I/A para el lector, TURNO-1…3 interno; EMB-A/B/C; variantes con nombre
    requisitos_sin_criterio: 0       # BIT-16-02 §6 con 33 filas de contenido; S-15 es de proceso
    requisitos_sin_prueba: 0         # 17 ejemplos con oráculo; PD-1…PD-6 con ejemplo hermano; PD-7 sin modelo
    tareas_huerfanas: 0              # toda remisión §N.k de §C apunta a una subsección definida
    secciones_sin_fuente_o_escenario: 0
    barrido_rd_po: "patrones nuevos de AC-8 con 5/5 positivos; plan v2 sólo con excepciones listadas; Nucleos/N4-Agentes-Y-Orquestacion.md suma a los pendientes de R-06 (identificadores compuestos que el patrón viejo no veía)"
    barrido_r_priv: "0 reales en OUTPUTs/; 2 falsos positivos conocidos (números de versión) y un modelo de teléfono en la directiva I-06, que no es host ni dirección"
  deuda_declarada:
    # No hubo NO_APLICAR. Se declara como deuda consciente:
    - "Papeletas sin votar (rigen en forma provisional): RV-03 (tope 4/6/9 h; vigente 4 h), H2-056 (fusiones F1–F3; vigente: ninguna), RV-05 (25 o 26 OA; vigente: v1 + OA-A5), RV-04 (extensión; vigentes los topes de la v1), RV-01 (casos integradores; vigente: ninguno), RV-11 (juez; vigente: sesgo declarado), criterio de dificultad B/I/A del cuerpo auditor"
    - "P-12 / DEP-15 sin decidir (H2-050, S2): condición previa de 04, PD-4, 05, 12, 16 y PD-1"
    - "Objeciones en minoría de la aprobación, no aplicadas (06-Aprobacion §2): t de la clase M (131,4 s con s = 100) y las piezas que dependen de 07 bajo EMB-C (PAR2-01, J1); repetición por truncado fuera de §E.5 (PAR2-06, J3); namespace de _Comun frente al nombre de su proyecto (PAR2-07, J4); compuerta 15a/15b y reproducción con --fake entre variantes de 16 (PAR2-09, J3); compensación de palabras ~+625 y no ~+220, y unificar los scripts de verificación (PAR2-17, J3); DEP-12 huérfana y DEP-15 sin AC-7 (PAR2-21, J4); fe de erratas en lugar de reemplazo en el registro del ciclo 1 (PAR2-24, J2 y J4); el pedido al gestor no cumple su propio criterio contra el script (PAR2-25, J5)"
    - "§B.4 conserva «Agente por código» en el escalón 3 con el estado entre sus motivos (PAR2-16, verificación 3 con observación)"
    - "Fundamentos falsos de la fila PR-07 de §D (RV-12: Catalogos es public static class; MCP 2.3.0 está sondeado); el NO_PROCEDE se mantiene"
    - "Comparación de calidad entre contexto completo y RAG no ejecutada por costo (RV-02), declarada en §14.6"
    - "Verificaciones diferidas a la construcción: PAR2-01 (5), PAR2-04, PAR2-05, PAR2-06 (1)(2), PAR2-07 (3)(4), PAR2-08, PAR2-12, PAR2-13 (1)(4), PAR2-14 (3)"
    - "Verificaciones diferidas a la guía redactada: PAR2-02 (5), PAR2-15 (script en los dos sentidos), PAR2-17 (1)–(3), PAR2-19 (cotejo de tema de las remisiones y (4))"
    - "Gestor de recursos: PAR2-25 sin respuesta del dueño; si no se resuelve antes de construir, rige EMB-C y 02, 05, 06, 07 (embeddings), 16 y PD-2 quedan «no ejecutado contra el modelo»"
    - "Dominios ajenos por reescribir o rotular antes de cualquier commit (R-06): Sondeo-Entorno, N2, N5, N4 (nuevo con el patrón de AC-8), N4-Evidencia/compilecheck y el informe de QA del ciclo 1"
    - "Listas fuera del repo $R_PRIV_LISTA y $RD_PO_LISTA todavía sin crear"
    - "Apartamiento de la carta de AH-02 (tope 5, entregó 7) por segundo ciclo"
    - "De las cinco preguntas de nivel C del ciclo 1, tres se cerraron por alcance (ToolCallAccuracy, PublishContainer, KeepAlive: H2-057) y dos quedaron atadas a sus filas (reintentos de 02 y ChatOptions del juez de 15). Siguen como preguntas: ¿/v1 sin num_ctx recarga el compartido?; ¿un handoff mínimo entra en TURNO-2 si DEP-10 sale bien?; ¿la demo referencia _Comun en lugar de copiarlo?"
  escaladas_pendientes:
    - escalada:
        id: ESC-001
        disparador: "4 — irreversibilidad con impacto real (instalar un modelo en el servidor compartido del PO)"
        pregunta: "¿Instalás un modelo de embeddings (qwen3-embedding:0.6b) en el servidor Ollama de la LAN, o la mesa usa un Ollama aparte en contenedor?"
        contexto: >-
          Sin cambio desde el ciclo 1 (no se reabre). En el ciclo 2 los planes pasan a llamarse EMB-A, EMB-B y EMB-C.
          EMB-B necesita el recurso [recurso-modelo-propio] del gestor (DEP-14), y el gestor actual aborta al darlo de alta
          (PAR2-25, pedido a su dueño). Si eso no se resuelve antes de construir, rige EMB-C.
        opciones:
          - id: A
            descripción: "EMB-A: instalás qwen3-embedding:0.6b en el servidor de la LAN"
            consecuencia: "No hace falta el Ollama propio ni DEP-14; riesgo de recargas del modelo de chat compartido"
          - id: B
            descripción: "EMB-B: Ollama propio en contenedor ollama/ollama:0.40.11, por OLLAMA_EMBED_ENDPOINT, con turno [recurso-modelo-propio]"
            consecuencia: "No toca tu servidor; depende de DEP-14"
          - id: C
            descripción: "EMB-C: generador estable sin modelo, sólo cableado"
            consecuencia: "06, 07, 16 y PD-2 quedan «no ejecutado contra un modelo de embeddings»"
        recomendación_de_la_mesa: "B (sin cambio desde el ciclo 1; SUP-09)"
        si_no_respondés: "Rige B; si DEP-14 no se resuelve antes de construir, C, declarado"
    # Sin escaladas nuevas en formato M§6: las dos preguntas abiertas (¿la demo sola recorre los cinco escenarios?, H2-055; ¿PR-17 abre un escenario nuevo?, I-05 §5.2) son de la presidencia y el contrato alcanza para responderlas (SUP-05). Ningún parche activó un disparador.
  capas_a_revalidar:
    - "BIT-16-02 §6 (actualizada por PAR2-23; queda la fila I-05 §5.2 pendiente de la presidencia), §7 (estructura prevista: ADR-13, §4.1/§4.2 renumeradas, §11.8, §13.15) y §9 (remisiones con la numeración v2)"
    - "BIT-16-00 SUP-05 y SUP-09 (EMB-B como nombre del default; sin cambio de contenido)"
    - "Ciclo-1/05-Parches.md (corregido por PAR2-24; la minoría pide fe de erratas)"
    - "N6 (nota de RV-06 agregada); N6 Anexo A frente a la demo de un host (ADR-13) y sin ruta de chat por la API"
    - "N4 (dominios ajenos detectados por el patrón nuevo de AC-8)"
    - "Gestor de recursos de la raíz del workspace: <gestor-de-turnos>/ (pedido PAR2-25, con dueño)"
    - "Compuertas/rd-po-4.excepciones (recalculado) y rd-po-4.positivos (nuevo)"
    - "Plan v2 §B.4 (fila «Agente por código» y la escalera), §G.3 DEP-12, §E.5 clase M y lista de EMB-C, §E.1 regla de Domain"
    - "Guía (0 bytes), Examples/ y Demos/ (vacíos): se construyen sobre la v2 después del ciclo 3"
```

## 3. Qué sigue: alcance del ciclo 3

1. **Votos pendientes, en el primer bloque**: las siete papeletas (RV-03, H2-056, RV-05, RV-04, RV-01, RV-11, criterio de dificultad) y **P-12/DEP-15** (H2-050), cada una con el costo que trae su parche.
2. **Las ocho objeciones en minoría** de `06-Aprobacion.md` §2, como ítems del ciclo 3 (no se aplicaron: la mayoría votó `APLICAR`). La de PAR2-21 (DEP-12 huérfana) y la de PAR2-01 (t de la clase M) tocan cifras y dependencias del alcance.
3. **Preguntas a la presidencia**: H2-055 (la demo sola y los cinco escenarios) e I-05 §5.2 (PR-17 escenario nuevo o variante).
4. **Panel acotado** sobre la v2: núcleo, los seis perfiles del PO (DC-02), Operación y entrega y AH-02; Formal/matemático si se votan la regla de §10.4 y las clases de t.
5. **Fuera de la mesa, antes de construir**: el pedido PAR2-25 al dueño del gestor; las sondas DEP-03, DEP-09, DEP-10 y DEP-13; las listas `$R_PRIV_LISTA` y `$RD_PO_LISTA`.
6. **ESC-001** sigue abierta y no se reabre: si el PO no responde, rige EMB-B.
