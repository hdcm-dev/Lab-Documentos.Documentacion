# Mesa evaluadora — Cierre del ciclo 2 (escenario testigo)

```yaml
cierre:
  artefacto: Beginning-Security-Windows-Network-Guide.md
  version_final: 1.2
  ciclos_ejecutados: 2 (acumulado)
  disparador_del_ciclo: >
    El usuario levantó la restricción "salidas ilustrativas sueltas" y pidió derivarlas
    de un escenario hipotético típico, coherente, auditado por la mesa (mecanismo de "no inventar":
    en vez de valores sueltos, un caso único internamente consistente del que todo se deduce).
  panel:
    convocados:
      - nucleo (requisitos, verificación, lector-novato, abogado)
      - E-SeguridadWin: coherencia técnica del ataque
      - E-Didactica: valor formativo del caso
      - Rol formal/matemático (NUEVO): consistencia de la línea de tiempo y relaciones causales
    no_reconvocados: [E-Edicion, AH-001]  # sin señal nueva
  hallazgos: { detectados: 6, procedentes: 6, aplicados: 6, revertidos: 0 }
  parches_aplicados:
    - P-07: §2.9 + reescritura del aviso de encabezado (H-15, H-16)   # verif: §2.9 y aviso presentes OK
    - P-08: §5.3 etiquetada como colector + nota log local vacío (H-11) # verif: "esta salida es del *colector*" OK
    - P-09: §5.5.1 distingue borrado total (RecordId reinicia) de parcial (H-12) # verif: presente OK
    - P-10: IPs externas a RFC 5737 203.0.113.14 (H-13)               # verif: 0 residuos 185.x/40.x OK
    - P-11: fechas a 15/09 y cuentas soporte/svc_update (H-14)         # verif: 0 residuos jperez/17-03:14 OK
    - P-12: Anexo D con línea de tiempo y mapa de salidas (H-15)       # verif: Apéndice D presente OK
  coherencia_del_escenario:
    linea_de_tiempo_sin_imposibles: OK (soporte admin local habilita 4720/4732)
    borrado_total_vs_salidas: OK (local vacío→colector; RecordId reinicia; 1102 primer evento)
    PID_9310_consistente: OK (procesos §6.1, servicio §6.4, conexión §7.2, mapa D.4)
    IPs: interno RFC1918 / externo RFC5737 OK
    bloques_de_codigo_balanceados: OK (82 fences, par)
  deuda_declarada:
    - Salida de svchost a 20.190.160.14 en §7.2 como "benigna": es rango real de Microsoft usado como ejemplo de tráfico legítimo; aceptable, se prefirió realismo del contraste sobre RFC5737 en la línea benigna.
  escaladas_pendientes: []
  nota_metodologica: >
    El escenario testigo es el mecanismo que satisface "no inventar": ninguna salida es un valor
    arbitrario aislado; todas se deducen de un único caso declarado (Escenario/Escenario-Testigo.md)
    cuya coherencia interna fue auditada. Es sintético y así se declara; su validez es la consistencia,
    no la procedencia de un sistema real.
```
