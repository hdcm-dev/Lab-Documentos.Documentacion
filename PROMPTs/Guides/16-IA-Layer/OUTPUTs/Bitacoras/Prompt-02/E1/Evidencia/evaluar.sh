#!/usr/bin/env bash
# Evalúa T-qwen según E1/Criterio-R-LLM.md §3.
W={dir-de-trabajo}
for e in $(ls $W); do k=0; n=0; det=""
  for s in 1 2 3 4 5; do d=$W/$e/s$s; [ -f $d/rc.txt ] || continue
    rc=$(sed -n 's/^rc=\([0-9]*\).*/\1/p' $d/rc.txt); dur=$(sed -n 's/.*dur_s=\([0-9]*\).*/\1/p' $d/rc.txt)
    j=$(ls $d/$e.jsonl 2>/dev/null); ll=0; lh=0; hh=""
    if [ -n "$j" ]; then ll=$(jq -s '[.[]|select(.tipo=="llamada" and .modelo=="qwen3.5:4b")]|length' $j); lh=$(jq -s '[.[]|select(.tipo=="llamada" and .modelo=="qwen3.5:4b" and ((.herramientas//[])|length)>0)]|length' $j); hh=$(jq -rs '[.[]|select(.tipo=="llamada")|.hash_herramientas[0:8]]|unique|join(",")' $j); pe=$(jq -s '[.[]|select(.tipo=="llamada")|.prompt_eval_count]|add/length|floor' $j); fi
    ok=0; [ "$rc" = 0 ] && [ "$lh" -gt 0 ] && ok=1; n=$((n+1)); k=$((k+ok))
    det="$det s$s(rc=$rc,${lh}/${ll},${dur}s,pe~$pe,hh=$hh)"
  done; echo "$e k=$k n=$n$det"; done
