---
doc_id: BIT-16-MESA-C3-08
doc_type: cierre-de-mesa
title: Ciclo 3 · Cierre de la mesa de estructuración (M§7, tres ciclos)
version: v1
status: cerrado; la mesa termina por ciclos_max = 3
origin: agent (secretaría de la mesa)
last_review: 2026-10-26
traces: [BIT-16-MESA-C1-08, BIT-16-MESA-C2-08, BIT-16-MESA-C3-01…07, BIT-16-04 v3, M§6, M§7, M§9, <gestor-de-turnos>/PROTOCOLO.md]
---

# Ciclo 3 · Cierre de la mesa

La mesa cierra con la **ESTRUCTURA APROBADA v3 — FINAL** (`../../04-Plan-De-Integracion.md`, 2026-10-26, ciclo 3), que es la estructura de referencia para la construcción y la redacción. Las versiones anteriores están en `…v2.md`, `…v1.md` y `…v0.md`.

## 1. Criterio de parada (M§7)

| Criterio | Cuenta | ¿Se cumple? |
|---|---|---|
| Rendimientos decrecientes (< 20 % de válidos nuevos ≥ S3) | Ciclo 2: 57. Ciclo 3: 27 (S1 1, S2 15, S3 11). 27 / 57 = **47,4 %** | No |
| Sin hallazgos abiertos ≥ S2 | Los 27 tienen parche aplicado y verificado; P-12/DEP-15 (H2-050) quedó decidida | **Sí** |
| `ciclos_max` agotado | 3 de 3 | **Sí** |
| Escalada bloqueante sin responder | ESC-001 no bloquea: rige B, provisto por el gestor | No |

**Decisión: la mesa cierra por `ciclos_max`, sin hallazgos ≥ S2 abiertos.** Lo que queda va como deuda declarada.

## 2. Bloque de cierre de todo el proceso

```yaml
cierre:
  proceso: "mesa de estructuración, guía 16 IA Layer"
  fecha: 2026-10-26
  ciclos_ejecutados: 3
  decision: "cierre por ciclos_max = 3; ningún hallazgo ≥ S2 abierto; 27/57 = 47,4 % de válidos nuevos en el ciclo 3"
  version_final: "BIT-16-04 v3 (04-Plan-De-Integracion.md) — ESTRUCTURA APROBADA v3 — FINAL; v2, v1 y v0 conservadas"
  panel:
    ciclo_1:
      # hallazgos emitidos / ítems PROCEDE en los que figura como origen
      convocados: ["requisitos 7/12", "QA 7/16", "implementador ingenuo 7/10", "abogado del diablo 7/13", "didáctica 7/8", "edición 7/10", "senior .NET 7/9", "experto en IA 7/9", "arquitectura 7/9", "desarrollo 7/10", "AH-01 5/6", "AH-02 7/10"]
      aporte_nulo: []
    ciclo_2:
      convocados: ["requisitos 7/8", "QA 7/7", "implementador ingenuo 7/9", "abogado del diablo 7+7/9", "didáctica 6/6", "edición 6/6", "senior .NET 7/8", "experto en IA 7/9", "arquitectura 7/8", "desarrollo 6/7", "Operación y entrega 6/7", "AH-01 5/5", "AH-02 7/8", "auditor de homogeneidad (sin voto)"]
      aporte_nulo: []
    ciclo_3:
      # hallazgos emitidos / H3 PROCEDE en los que figura como fuente (03-Consolidacion §3)
      convocados: ["requisitos 6/5 (H3-001, -003, -004, -008, -024)", "QA 6/9 (H3-001, -002, -003, -004, -005, -009, -015, -019, -022)", "abogado del diablo 5/4 (H3-003, -005, -026, -027)", "desarrollo / implementador ingenuo 6/5 (H3-003, -004, -006, -007, -021)", "didáctica 6/4 (H3-012, -013, -024, -025)", "edición 6/5 (H3-009, -010, -014, -015, -016)", "arquitectura 6/5 (H3-003, -004, -011, -015, -017)", "Operación y entrega 6/5 (H3-001, -002, -004, -005, -023)", "AH-02 6/4 (H3-004, -018, -020, -021)"]
      no_convocados: ["senior .NET y experto en IA (apartamiento de DC-02 declarado en 01-Convocatoria §3)", "AH-01", "Formal/matemático (postergado; lo cubrieron AH-02 y QA)"]
      aporte_nulo: []
  hallazgos:
    ciclo_1: {detectados: 82, consolidados: 63, items_votados: 94, procedentes: 93, aplicados: 93, parches: 24, revertidos: 0, ajustes: 8}
    ciclo_2: {detectados: 96, consolidados: 59, items_votados: 89, procedentes: 85, validos_nuevos_ge_S3: 57, parches: 27, aplicados: 27, revertidos: 0, ajustes: 0}
    ciclo_3: {detectados: 53, consolidados: 27, items_votados: 40, procedentes: 27, papeletas_decididas: 10, contradicciones_resueltas: 3, validos_nuevos_ge_S3: 27, parches: 20, aplicados: 20, revertidos: 0, ajustes: 0}
    total: {detectados: 231, items_votados: 223, parches: 71, revertidos: 0}
  homogeneidad:
    ciclo_1: "sospecha: true — 94/94 unánimes (100 %); 21/24 parches unánimes"
    ciclo_2: "sospecha: false — 70/89 unánimes (78,7 %); 19/27 parches unánimes; 5 INSUFICIENTE"
    ciclo_3: "sospecha: false — 31/40 unánimes (77,5 %), contando como coincidente el voto rotulado del juez de riesgo; 3 INSUFICIENTE; 1 NO_PROCEDE en minoría; 18/20 parches unánimes; 0 vetos. Las minorías están fundadas en costo o en reversibilidad, no son de forma"
  coherencia:
    contradicciones: 0          # DEP-12 partida (H3-003); C3-01…C3-03 resueltas
    terminos_con_dos_sentidos: 0      # «contexto» frente a «contexto de uso» (H3-014); dificultad en palabras
    requisitos_sin_criterio: 0        # BIT-16-02 §6: 31 filas sin celdas vacías
    requisitos_sin_prueba: 0          # 17 ejemplos con oráculo; PD-1…PD-6 con ejemplo hermano y humo o cableado
    tareas_huerfanas: 0               # DEP-10 retirada; DEP-12 sin SSE; DEP-16 con dueño
    secciones_sin_fuente_o_escenario: 0   # 16 fichas de §C con fuente y escenarios
    barrido_rd_po: "patrón nuevo con lookbehind: 0 en rd-po-4.negativos; sólo excepciones listadas y los seis archivos pendientes de R-06"
    barrido_r_priv: "corrido después del último archivo escrito: 0 en OUTPUTs/ con la lista de la secretaría (fuera del repo); 0 IP reales"
  deuda_declarada:
    - "Casos integradores (P3-05 A): ninguno; el caso 3 optativo quedó en minoría (valor didáctico no medido)"
    - "Con el tope de 4 h quedan «no ejecutado contra el modelo» 04 ext., 08 ext. y 17 (S-17 cumplido en parte); TURNO-2 es extensión (alcance mínimo = TURNO-1 + TURNO-3)"
    - "Mediciones de la construcción: clases K/H/L (DEP-13) y P-* (DEP-03); tamaño real del prefijo de 05; si el juez 0,5B da una salida interpretable; si el gestor expone carga_1min (puede quedar null)"
    - "§14.6 de la guía: autorización real; exponer /mcp en la demo; MCP fuera de loopback; comparación de calidad contexto completo frente a RAG (RV-02); varios textos de ataque para 16; juez de otra familia; conducta en tareas de varios pasos (sin DEP-10: minoría INSUFICIENTE de H3-027); handoff mínimo"
    - "DEP-16: las listas $R_PRIV_LISTA y $RD_PO_LISTA no existen; dueño: la presidencia, antes de construir. Hasta entonces AC-7 y AC-8 fallan cerrados. La objeción de riesgo a PAR3-15 (usar la lista de la secretaría en el texto de AC-7) no se aplicó. Pregunta abierta: rutas absolutas con el usuario del sistema en OUTPUTs/"
    - "Objeción de riesgo a PAR3-19 (3): falta la nota «redactado en ciclo 3 por R-PRIV» en Ciclo-2/09 l. 31; la trazabilidad está en 06 y 07"
    - "Residuos que ningún parche cubría: §G.4 P-12, columna pregunta, todavía cita «el reglamento sintético de 05 … localidad ficticia»; §A.1 (l. 60) dice que PD-6 usa un agente de MAF (es un IChatClient con historial); la ficha de Parte 0 dice «plan §A.3 de este plan» (redundancia que dejó el prefijo)"
    - "Verificaciones de los parches que su propio texto contradice (no son regresiones): PD-7 aparece en 5 líneas que anuncian su retiro; «provisional» en el encabezado de PAR3-20; R-07/R-04 marcan ADR-07/ADR-04"
    - "Dominios ajenos por reescribir o rotular antes de cualquier commit (R-06): Sondeo-Entorno, N2, N4, N4-Evidencia/compilecheck, N5 e informe QA del ciclo 1"
    - "BIT-16-02 §7 y §9 con la numeración anterior al plan: se revalidan al redactar la guía"
    - "Herramientas que el plan da por existentes y no existen todavía: tools/inclusion.sh, tools/contar.sh, tools/rutas.sh, tools/toc.sh, el script de AC-7; se construyen con la guía"
    - "Consecuencias mecánicas de 05-Parches §0.2 (16 en I, fase 3b, «origen» sin corrida): aplicadas; cada una se revierte en una celda si la presidencia no las acepta"
    - "Apartamientos acumulados: la convocatoria se registra al cierre (tres ciclos); AH-02 por encima de su tope de hallazgos en los ciclos 1 y 2; en el ciclo 3 no se convocaron senior .NET ni el experto en IA"
  escaladas_pendientes:
    - escalada:
        id: ESC-001
        disparador: "4 — irreversibilidad con impacto real (instalar un modelo en el servidor compartido del PO)"
        estado: "sin respuesta del PO, no bloqueante y sin efecto práctico: el default B quedó realizado por el gestor"
        pregunta: "¿Instalás un modelo de embeddings (qwen3-embedding:0.6b) en el servidor Ollama de la LAN, o la mesa usa un Ollama aparte?"
        contexto: >-
          Desde el ciclo 1 rige EMB-B. En el ciclo 3, DEP-14 quedó resuelta: el gestor de recursos provee
          el recurso [recurso-modelo-propio] en otra máquina del laboratorio, con qwen3-embedding:0.6b y qwen2.5:0.5b.
          La secretaría lo verificó al cierre (§4). Sólo hace falta la respuesta si el PO prefiere EMB-A.
        opciones:
          - id: A
            descripción: "EMB-A: instalás qwen3-embedding:0.6b en el servidor de la LAN"
            consecuencia: "Libera el recurso del gestor; riesgo de recargas del modelo de chat compartido"
          - id: B
            descripción: "EMB-B: Ollama propio del gestor, con turno [recurso-modelo-propio]"
            consecuencia: "No toca tu servidor; ya está provisto y verificado"
          - id: C
            descripción: "EMB-C: generador estable sin modelo, sólo cableado"
            consecuencia: "02, 05, 06, 07 (embeddings), 15 y PD-2 quedan «no ejecutado contra el modelo»"
        recomendación_de_la_mesa: "B (ya realizada)"
        si_no_respondés: "Rige B; si `<gestor-de-turnos> salud [recurso-modelo-propio]` falla al empezar la construcción, C, registrado por el arnés"
    # EMPATE_PERSISTENTE: ninguno. ESCALAR en la aprobación: ninguno. No hay escaladas nuevas en este ciclo.
  capas_a_revalidar:
    - "Guía (0 bytes), Examples/ y Demos/ (vacíos): se construyen sobre la v3"
    - "BIT-16-02 §7 y §9 (numeración de la guía) contra la v3"
    - "BIT-16-03 §2 y §4.2 (PAR3-17) frente a §2.2, §3.3 y §14 de la guía cuando se redacten"
    - "BIT-16-00 SUP-09 (realizado) y DEP-14 (cerrada) frente al contrato de entrada"
    - "N6 Anexo A frente a la demo sin /mcp y sin PD-7"
    - "Los seis archivos pendientes de R-06"
    - "Compuertas/: rd-po-4.excepciones recalculado; familias-id.{positivos,negativos} y rd-po-4.negativos nuevos"
    - "Gestor de recursos (<gestor-de-turnos>/, tiene dueño): salud de [recurso-modelo-propio] antes del primer turno build"
  dep_14:
    estado: "resuelta — rige EMB-B"
    evidencia_E1: "<gestor-de-turnos> estado (2026-10-26, cierre): [[recurso-modelo-propio]] cupo 1 · en uso 0; <gestor-de-turnos> salud [recurso-modelo-propio]: rc = 0, Ollama 0.40.11, qwen2.5:0.5b@a8b0c5157701, qwen3-embedding:0.6b@ac6da0dfba84, con capacidad de embedding (salida filtrada, sin direcciones)"
    fuente: "PROTOCOLO.md: [recurso-modelo-propio] con cupo 1 y ttl 60, en una máquina distinta de la de build; sin pull ni borrado de modelos"
    punto_de_decision: "el arnés corre salud antes del primer turno build; con rc ≠ 0 pasa a EMB-C y lo registra"
```

## 3. Decisiones de las papeletas (resumen)

RV-03 = 4 h · H2-056 = F1 no, F2 no, F3 sí · RV-05 = 27 OA · RV-04 = enmendada (total ≤ 44.330) · RV-01 = sin casos integradores · RV-11 = B′ (juez `qwen2.5:0.5b` en el Ollama propio) · dificultad = nivel de PR-3 más regla residual · P-12 = regla general de estímulo, 05 con padrón y 16 con inyección en `Nombre` · demo = RC-1 (PD-7 sale) · par CTX-EXISTENTE / CTX-NUEVA aplicado completo.

## 4. Verificación de DEP-14 por la secretaría (atiende la minoría de C3-01)

`<gestor-de-turnos> estado` y `<gestor-de-turnos> salud [recurso-modelo-propio]`, corridos en el cierre, sólo en lectura y sin tocar `<gestor-de-turnos>/`. La salida se filtró para que no quedaran direcciones. Resultado: el recurso existe y está sano, así que **rige EMB-B**.

> **2026-10-29 — Recuperación (B-02, paso 2.10; REC-05 opción A). ESC-001 cerrada «sin objeto».** La escalada preguntaba si se instalaba `qwen3-embedding:0.6b` en el servidor Ollama de la LAN. Ese servidor se retiró el 2026-10-28, y las dos estaciones vigentes (estación 1, de 4 núcleos; estación 2, con más núcleos) ya tienen `qwen3-embedding:0.6b@ac6da0dfba84` (`Sondeo-Entorno.md` §R.3 y §R.7). La escalada **sale de los pendientes del PO**. EMB-A se lee desde ahora «en el mismo servidor del chat» y EMB-B «en un servidor aparte», sin cambiar el código. Las cifras de 06, 07 y PD-2 se re-miden en la re-corrida de la recuperación (REC-02). Nota par en `07-Redaccion.md` («Notas de la recuperación»).
