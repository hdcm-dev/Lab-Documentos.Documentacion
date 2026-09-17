# Mesa evaluadora — Cierre del ciclo 4 (cuaderno de ejercicios)

```yaml
cierre:
  artefacto: Cuaderno-Ejercicios-Seguridad-Windows.md
  version_final: 1.1
  ciclos_ejecutados: 4 (acumulado en la línea de trabajo)
  panel: { convocados: [nucleo, E-Didactica, E-SeguridadWin] }
  hallazgos: { detectados: 6, procedentes: 6, aplicados: 6, revertidos: 0 }
  parches_aplicados:
    - P-18: sección "Cómo autoevaluarte" con bandas de nivel y autodiagnóstico por módulo  # verif OK
    - P-19: nota de respuestas modelo (🔴 no únicas) + resoluble sin laboratorio            # verif OK
    - P-20: 6.2 marcado como ejercicio de reconocimiento y escalamiento                     # verif OK
    - P-21: estado -> Aprobado                                                              # verif OK
    - (H-23 ya cubierto en 4.3: "aislar de la red" != "reiniciar")
  estructura: { enunciados: 19, respuestas: 19, modulos: 7 }
  coherencia:
    respuestas_separadas_de_enunciados: OK
    respuestas_explican_porque: OK
    referencia_a_guia_en_cada_respuesta: OK
    consistencia_con_escenario_testigo: OK
    micro_casos_nuevos_declarados: OK (PC-VENTAS07, SRV-CONTA02, casos A/B)
    fences_balanceados: OK
  deuda_declarada: []
  escaladas_pendientes: []
```
