# Mesa evaluadora — Cierre del ciclo 3 (corpus de logs + intencionalidad)

```yaml
cierre:
  artefacto: Beginning-Security-Windows-Network-Guide.md
  version_final: 1.3
  ciclos_ejecutados: 3 (acumulado)
  disparador_del_ciclo: >
    El usuario pidió ejemplos de logs "como se ven" con qué leer en cada uno, y una sección
    sobre qué mirar cuando el sistema está comprometido, qué pasa cuando borran los logs y
    cómo saber que el borrado fue intencional.
  panel:
    convocados: [nucleo, E-SeguridadWin, E-Didactica]
    ad_hoc: [AH-002 (analista forense DFIR): fidelidad de renders y criterios de intencionalidad]
  hallazgos: { detectados: 6, procedentes: 6, aplicados: 6, revertidos: 0 }
  parches_aplicados:
    - P-13: §5.5.3 "Cómo saber que el borrado fue intencional" (1102/104 acción explícita + tabla + causas legítimas)  # verif OK
    - P-14: §5.4 lectura de subestados del 4625 (spraying vs brute force)   # verif: 0xC000006A/0xC0000064 presentes
    - P-15: §4.6 checklist "primeros 10 minutos"                            # verif: §4.6 presente, numeración 4.1-4.7 OK
    - P-16: Anexo E galería de logs comentados (4625,4624,4720/4732,7045,1102,log sano)  # verif OK
    - P-17: índice + versión 1.3 + refcruz §5.5→Anexo E                     # verif OK
  fixture_nuevo: Escenario/Corpus-Logs.md (renders completos con "qué leer")
  coherencia:
    renders_fieles_al_formato_windows: OK (AH-002)
    valores_consistentes_con_escenario: OK (svc_update/soporte/203.0.113.14/0x3E9A11)
    intencionalidad_sin_falsos_positivos: OK (se declaran causas legítimas a descartar)
    fences_balanceados: OK (par)
    numeracion_secciones: OK (4.1..4.7; preguntas guía al final)
  deuda_declarada: []
  escaladas_pendientes: []
  respuesta_a_las_preguntas_del_usuario:
    que_mirar_cuando_esta_comprometido: §4.6 (checklist de 8 pasos)
    que_ver_en_cada_log: Anexo E + Corpus-Logs.md (campo por campo)
    que_pasa_cuando_borran_los_logs: §5.5 (detección), §5.6 (colector), Anexo D.5 (moraleja)
    como_saber_que_fue_intencional: §5.5.3 (1102/104 = acción explícita + señales + descarte de causas legítimas)
```
