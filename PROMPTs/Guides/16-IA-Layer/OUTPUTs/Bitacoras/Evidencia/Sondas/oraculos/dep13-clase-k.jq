# Oráculo de la sonda DEP-13: la llamada de clase K (p <= 500, sin herramientas) entra en su pesimista (80 s de reloj).
(.llamadas[0]) as $l
| if $l == null then "excluida"
  elif $l.truncado_posible == true then "excluida"
  elif ($l.duracion_reloj_ms <= 80000) and ($l.prompt_eval_count <= 500) and (($l.herramientas | length) == 0) then "pasa"
  else "falla" end
