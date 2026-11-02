# Oráculo de la sonda DEP-03: con la capa única (num_ctx 8192) el servidor procesa el prompt entero
# (truncado_posible = false) y sin la opción procesa menos tokens que con ella.
([ .llamadas[] | select(.paso == "con-opcion") ][0]) as $con
| ([ .llamadas[] | select(.paso == "sin-opcion") ][0]) as $sin
| if $con == null or $sin == null then "excluida"
  elif $con.num_ctx == 8192 and $con.truncado_posible == false and ($sin.prompt_eval_count < $con.prompt_eval_count) then "pasa"
  else "falla" end
