---
doc_id: BIT-16-MESA-C1-08
doc_type: cierre-de-ciclo
title: Ciclo 1 · Cierre (M§7)
version: v1
status: cerrado; abre el ciclo 2 (relectura de la estructura v1)
origin: agent (secretaría de la mesa)
last_review: 2026-10-26
traces: [BIT-16-MESA-C1-01, -03, -04, -05, -06, -07, BIT-16-04 v1, M§6, M§7, M§9]
---

# Ciclo 1 · Cierre

El ciclo 1 cierra con la **estructura aprobada v1** del cuerpo de conocimiento (`../../04-Plan-De-Integracion.md`, 2026-10-26). No es el cierre de la mesa: el criterio de parada de M§7 no se cumple todavía, porque quedan ítems abiertos por encima del umbral (la colisión «nivel A/B», los ajustes AJ-01…AJ-08 a ratificar y las verificaciones diferidas) y no hay un ciclo N-1 contra el cual medir rendimientos decrecientes. Sigue el ciclo 2 sobre la v1.

```yaml
cierre:
  ciclo: 1
  fecha: 2026-10-26
  version_final: "BIT-16-04 v1 (04-Plan-De-Integracion.md) — ESTRUCTURA APROBADA v1; v0 conservada en 04-Plan-De-Integracion.v0.md"
  ciclos_ejecutados: 1
  panel:
    convocados:
      # hallazgos emitidos / ítems consolidados PROCEDE en los que figura como origen
      - "requisitos (núcleo): 7 / 12"
      - "verificación-QA (núcleo): 7 / 16"
      - "implementador ingenuo (núcleo): 7 / 10"
      - "abogado del diablo (núcleo): 7 / 13"
      - "didáctica (pedido del PO, E4): 7 / 8"
      - "edición de material bibliográfico (pedido del PO, E4): 7 / 10"
      - "senior .NET (pedido del PO, E4): 7 / 9"
      - "experto en IA (pedido del PO, E4): 7 / 9"
      - "arquitectura de software (pedido del PO, E4; también rol de catálogo con señal): 7 / 9"
      - "desarrollador de código (pedido del PO, E4): 7 / 10"
    descartados:
      - "Datos y dominio: NO_CONVOCAR; lo cubren senior .NET (EF Core) e IA (almacén vectorial)"
      - "AH-03 Ecosistema LangChain/LangGraph: NO_CONVOCAR; LangGraph queda como snippet no ejecutado (P-09)"
    ad_hoc:
      - "AH-01 Seguridad de aplicaciones con LLM: ¿lo que la guía enseña es seguro de copiar? Aportó H-010, H-012, H-013 y H-053 (pedido de aprobación con argumentos resueltos, escrituras con contexto no confiable, MCP sin control de acceso, compuerta R-PRIV sobre la bitácora). 5 hallazgos / 6 ítems"
      - "AH-02 Evaluación LLM/RAG: ¿las pruebas demuestran lo que la guía afirma? Aportó H-001, H-003, H-028, H-029, H-030 (entrada distinta como unidad, cierre separado de CI, hit rate con línea base, oráculo de la afirmación central, conjunto de oro). 7 hallazgos / 10 ítems; excedió su tope de 5 (apartamiento de la carta)"
    postergados_por_cupo:
      - "Operación y entrega (con Rendimiento y costo): seis solicitudes de convocatoria en caliente; se recomienda convocarlo en el ciclo 2"
      - "Formal / matemático: señal presente (intervalos, Fisher, líneas base); cubierto por AH-02 y QA en el ciclo 1"
    aporte_nulo: []
  apartamientos_del_marco:
    - "Techo del panel (M§4.1.4) excedido por pedido explícito del PO: núcleo 4 + 8 variables/ad hoc (6 perfiles del PO por DC-02 + AH-01 + AH-02), 3 sobre el techo de 5. Declarado en REED-16 §8.5; registrado en 01-Convocatoria.md §3"
    - "AH-02 emitió 7 hallazgos con tope_hallazgos 5 en su carta; la consolidación los tomó todos"
    - "La convocatoria se registró al cierre (01-Convocatoria.md) y no antes del panel (00-Convocatoria.md previsto en REED-16 §8.6)"
  homogeneidad:
    sospecha: true
    jurado: "94 de 94 ítems votados por unanimidad (100 %; 93 PROCEDE 5-0, 1 NO_PROCEDE 0-5); umbral de M§9: 80 %"
    aprobacion: "21 de 24 parches por unanimidad (88 %)"
    contramedidas: "re-verificación de anclas por el cuerpo auditor (05-Parches.md §0.2); objeciones minoritarias en PAR-13, PAR-15 y PAR-19 aplicadas como ajustes declarados; pendiente: revisión del único NO_PROCEDE (PR-07) por el abogado del diablo y un juez con función adversarial sobre los unánimes S2 en el ciclo 2"
  hallazgos:
    detectados: 82          # hallazgos brutos en los 12 informes, consolidados en 63
    consolidados: 63
    contradicciones: 9
    propuestas_pr: 22
    items_votados: 94
    procedentes: 93          # 63 H + 9 X + 21 PR
    no_procedentes: 1        # PR-07 (se mantiene el NA del plan)
    aplicados: 93            # por 24 parches, 24 APLICAR
    revertidos: 0
    ajustes_de_aplicacion: 8 # AJ-01…AJ-08, a ratificar en el ciclo 2
  coherencia:
    contradicciones: 0       # después de AJ-01, AJ-03 y AJ-04
    terminos_con_dos_sentidos: 1   # «nivel A/B» (dificultad del ejemplo frente a nivel de turno de §E.5)
    requisitos_sin_criterio: 0     # S-01…S-17 con criterio en BIT-16-02 §6 (S-15 es de proceso y no lo necesita)
    requisitos_sin_prueba: 0       # 17 ejemplos con oráculo y criterio ejecutable; PD-1…PD-7 con AC-3b/AC-4
    tareas_huerfanas: 0            # 25 OA con sección y ruta; toda sección de §C con fuente y escenario
    secciones_sin_fuente_o_escenario: 0  # después de AJ-07
    barrido_rd_po: "plan v1: 3 ocurrencias, todas excepciones listadas; Examples/, Demos/ y guía vacíos; dossiers con dominios ajenos pendientes (R-06)"
    barrido_r_priv: "0 reales en OUTPUTs/ después de redactar un nombre de host en 02-Informes/desarrollo.md; 1 falso positivo (número de versión)"
  deuda_declarada:
    # No hubo NO_APLICAR. Se declara como deuda consciente:
    - "Colisión «nivel A/B» (S3, nueva): no se corrige en el ciclo 1 porque toca texto aprobado de PAR-14, PAR-15 y PAR-19; propuesta para el ciclo 2: niveles de turno T-A, T-B, T-C"
    - "AJ-01…AJ-08: ajustes de la secretaría sin voto del jurado; los OA de AJ-05 son criterio de la secretaría"
    - "Verificaciones diferidas a la guía redactada: PAR-05 (1)–(4), PAR-06 (1)–(3), PAR-09 (1)"
    - "Verificaciones diferidas a la construcción: PAR-03 (3), PAR-13 (2), (6), (7), PAR-15 (3), PAR-16 (3), PAR-17 (3), PAR-18 (3)"
    - "Horas de <recurso-compartido> de §E.5 sin recalcular con el t por ejemplo de AJ-02 hasta la sonda DEP-13"
    - "Dominios ajenos en Sondeo-Entorno, N2, N5, N4-Evidencia/compilecheck y el informe de QA: reescribir o rotular antes de cualquier commit (R-06)"
    - "Listas fuera del repo $R_PRIV_LISTA y $RD_PO_LISTA por crear; AC-7 sin mecanismo de excepciones para números de versión"
    - "Conteo «85 ítems» de 05-Parches.md: es 93 (error aritmético sin efecto en los parches)"
    - "Preguntas de nivel C abiertas: KeepAlive por RawRepresentationFactory (H-SN-02), reintentos del SDK OpenAI (H-SN-05), PublishContainer (DEP-05), ToolCallAccuracyEvaluator en 15 (H-SN-07), ChatOptions de los evaluadores (desarrollo H4)"
  escaladas_pendientes:
    - escalada:
        id: ESC-001
        disparador: "4 — irreversibilidad con impacto real (instalar un modelo en el servidor del PO, compartido con otros clientes; la mesa no lo toca)"
        pregunta: "¿Instalás un modelo de embeddings (qwen3-embedding:0.6b) en el servidor Ollama de la LAN, o la mesa usa un Ollama aparte en contenedor?"
        contexto: >-
          El servidor de la LAN no tiene modelo de embeddings (responde 501, Sondeo §5) y corre sólo en CPU, compartido.
          Sin embeddings no corren los ejemplos 06, 07 y 16 ni el paso PD-2 de la demo (RAG con citas).
          La mesa no instala nada en tu servidor. Un modelo más en un servidor compartido puede obligar a descargar
          qwen3.5:4b y perjudicar a los otros clientes (R-04). La alternativa compite por RAM y CPU en la máquina
          de la corrida, que está al límite.
        opciones:
          - id: A
            descripción: "Instalás qwen3-embedding:0.6b (639 MB) en el servidor de la LAN y se usa por OLLAMA_ENDPOINT"
            consecuencia: "No hace falta un Ollama propio ni el recurso DEP-14; riesgo de recargas de qwen3.5:4b si el servidor no mantiene los dos modelos cargados"
          - id: B
            descripción: "Ollama propio en contenedor ollama/ollama:0.40.11 (la imagen con la que corrieron los embeddings en N3 E3) con qwen3-embedding:0.6b, por OLLAMA_EMBED_ENDPOINT, con turno del gestor de recursos (DEP-14)"
            consecuencia: "No toca tu servidor; suma ~0,6 GB de modelo y un contenedor por turnos en la máquina al límite (R-02)"
          - id: C
            descripción: "Sin embeddings reales: generador de hash estable sólo para el cableado"
            consecuencia: "06, 07, 16 y PD-2 quedan «no ejecutado contra el modelo», sin cifras y como deuda en §14.6"
        recomendación_de_la_mesa: "B: no toca un recurso compartido y ya tiene evidencia de ejecución (N3 E3); queda fijado así en el plan v1 (SUP-09, §F.6, PAR-18 y PAR-20 aprobados 5-0)"
        si_no_respondés: "Se aplica B por defecto (SUP-09, concreción de SUP-06). Queda bloqueado sólo si el gestor de recursos no da el recurso [recurso-modelo-propio] (DEP-14); en ese caso se pasa a C y se declara"
  capas_a_revalidar:
    - "BIT-16-00 SUP-06 y SUP-09 (SUP-09 queda como concreción de SUP-06, sin cambio de texto)"
    - "BIT-16-02 §7 (estructura prevista de la guía), §9 (referencias cruzadas con la numeración vieja) y §10 (pendientes): §5 y §6 ya se actualizaron (PAR-21)"
    - "REED-16 §9.1 (compuertas C4/C5, AC-7, AC-8, AC-9) y §8.6 (registro de convocatoria en 01-Convocatoria.md)"
    - "N0b §3.3.4, §3.4 y §3.4.11 (nota de revisión agregada; el texto original queda como antecedente)"
    - "N6 Anexo A (orden de pasos y puertos), Anexo B (ejemplos), §1.3, §4.2, §4.5 y P6 (nota de revisión agregada)"
    - "N5 §2.7 (condición de origen), §4.6 (juez con OllamaApiClient propio) y control mínimo en prototipo"
    - "N3b §6 (nombre de la variante de servicio: «contexto completo con prefijo estable»)"
    - "Sondeo-Entorno §5 (imagen del plan B: 0.40.11)"
    - "Guía (0 bytes): todas las fichas de §C, en especial la plantilla de §5 como sección de muestra, el Anexo A (10 plantillas), el Anexo C (glosario canónico) y el Anexo F (única tabla de versiones)"
    - "Examples/ y Demos/ (vacíos): las 17 filas de §E.2, §E.5 y §F completas"
    - "Rule-Markdown y README de Bitacoras/ (índice de versiones: actualizado en este cierre)"
```

## Qué sigue

1. **Ciclo 2** sobre la v1: relectura de la estructura con el panel del ciclo 1 más **Operación y entrega**; ratificación de AJ-01…AJ-08; la colisión «nivel A/B»; revisión adversarial de los unánimes por la sospecha de homogeneidad.
2. **Antes de construir**: las sondas cortas DEP-03 y DEP-09 a DEP-13, el recurso `[recurso-modelo-propio]` (DEP-14) y las dos listas fuera del repo.
3. **Escalada al PO**: ESC-001 (embeddings). Si no responde, rige B.
