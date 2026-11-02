# Corrida 1 (antecedente)

Revela un defecto del ejemplo, no del modelo: en el pedido «modificacion», el modelo devolvió `Tipo = Modificacion`, `Id = 2` y sólo los habitantes (10/10), y `RevisorDePropuesta` armaba el formulario sólo con la propuesta, así que el CP vacío daba error. Corregido después de esta corrida: en una modificación, los campos que la propuesta deja en null se toman de la entidad que resuelve el servidor (la de la sesión). Los criterios previos no cambian; la corrida 2 repite las semillas 1..10 (reproducción, R-LLM-2) con el código corregido.
