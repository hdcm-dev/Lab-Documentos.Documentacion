---
doc_id: MESA-03-CIERRE
doc_type: mesa
title: Registro de cierre del ciclo
status: vigente
origin: ia-assisted
audience: [humano, agente]
traces: [MESA-01-CONVOCATORIA, MESA-02-VEREDICTOS, GUIA-PRINCIPAL, CUADERNO]
---

# Mesa evaluadora — Registro de cierre

```yaml
cierre:
  version_final:
    guia: Beginning-Security-Windows-Network-Guide.md (post-ciclo-1)
    cuaderno: Cuaderno-Ejercicios-Seguridad-Windows.md (post-ciclo-1)
  ciclos_ejecutados: 2   # ciclo 1: panel + parches; ciclo 2: verificación adversarial de los parches
  panel:
    convocados:
      - Didáctica: 6 hallazgos procedentes
      - Edición bibliográfica: 6 procedentes
      - Seguridad en redes Windows: 3 procedentes
      - Lector sin conocimientos: 4 procedentes (1 elevado a prioridad máxima)
      - Verificación / ética de doble uso: 5 procedentes
    descartados:
      - Formal/matemático: sin señal (no hay umbrales ni cálculos)
      - Datos/ciclo de vida: sin modelo de datos
      - Arquitectura: no hay sistema a diseñar
    ad_hoc: []
    aporte_nulo: []
  hallazgos: { detectados: 33, deduplicados_a: 22, procedentes: 21, no_aplicar: 1, aplicados: 21, revertidos: 0 }
  coherencia:
    salidas_ilustrativas_rotuladas: true
    datos_del_escenario_consistentes: true   # IP, LogonIDs, PID, horas verificados entre ambos documentos
    indice_vs_encabezados: alineado
    mermaid_valido: true   # timeline reparado
  deuda_declarada:
    - D-04: las «Notas de rigor» de sourcing se conservan en el flujo (dos especialistas y Rule-Evidences las respaldan); segregarlas a nota al margen queda para una edición con maquetación, no en Markdown plano.
  no_verificado_declarado_en_el_producto:
    - 0xC0000133 (NTSTATUS de Kerberos, no listado en el 4625)
    - patrón exacto de pass-the-hash (consenso de industria, a confirmar)
    - duración de la ISO de evaluación de Windows Server (verificar en Evaluation Center)
  escaladas_pendientes: []
  capas_a_revalidar: []
```

## Síntesis para el Product Owner

El material salió técnicamente muy sólido: el especialista de seguridad no halló ningún error S1 y confirmó contra la fuente viva de Microsoft el rigor de los subestados del 4625, la tabla de Logon Types y el mapeo ofensivo/forense. Los dos únicos S2 de fondo eran un exceso de confianza sobre el evento 1102 (se matizó, alineándolo con el «puede» de MITRE) y un error puntual sobre el Logon Type 8 (se corrigió: la contraseña **no** viaja en claro por la red). El resto fueron mejoras de exactitud, coherencia editorial y —el bloque más voluminoso— **andamiaje para el principiante**: cómo leer y correr un comando, cómo construir la línea de base de un servidor real, y un apéndice de laboratorio ejecutable paso a paso. Se reemplazó una IP real por rango de documentación (RFC 5737) por disciplina de datos en material público.

Sin escaladas al PO: ningún hallazgo tocó decisiones cerradas, restricciones duras en conflicto ni dominios de consecuencia externa. La mesa resolvió todo dentro de su autonomía, conforme al marco.
