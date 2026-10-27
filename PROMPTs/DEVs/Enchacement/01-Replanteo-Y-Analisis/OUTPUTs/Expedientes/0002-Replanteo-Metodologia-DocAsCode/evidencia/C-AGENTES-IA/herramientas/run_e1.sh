#!/bin/bash
# Uso: run_e1.sh <condicion> <modelo> <rep>
set -u
B=<ensayo>
C=$1; M=$2; N=$3
P='Respondé en español, breve, usando SOLO los archivos de este directorio (no uses conocimiento previo). Para cada respuesta citá el archivo del que sale. Si no lo encontrás, decí "no encontrado".
1) ¿Qué código HTTP y tipo de contenido devolvió el llms.txt de OneSignal, y cuántas entradas tenía?
2) En el recorrido de punta a punta de una página de ayuda, ¿qué traza declara la página alumno/enviar-un-trabajo.md y por qué falla el validador de CI?
3) En la propuesta de ayuda por rol, ¿qué deben compartir la navegación, el .md crudo y el llms.txt, y qué se filtraría si no lo comparten?'
cd $B/runs/e1/$C
timeout 600 claude -p "$P" --model $M --setting-sources project --allowedTools Read Glob Grep --disallowedTools Bash Write Edit WebFetch WebSearch --output-format json > $B/runs/e1-$C-$M-$N.json 2>$B/runs/e1-$C-$M-$N.err
python3 -I - $B/runs/e1-$C-$M-$N.json <<'PY'
import json,sys
d=json.load(open(sys.argv[1]))
u=d.get("usage",{})
print(json.dumps({"cond":sys.argv[1].split("/")[-1],"cost":round(d.get("total_cost_usd",0),4),"turns":d.get("num_turns"),
 "in":u.get("input_tokens",0)+u.get("cache_read_input_tokens",0)+u.get("cache_creation_input_tokens",0),"out":u.get("output_tokens"),"ms":d.get("duration_ms")}))
PY
