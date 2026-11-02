#!/usr/bin/env python3
"""PC-07: resumen 4b frente a 35b-a3b en estación 2. Uso (desde evidencia-{estación-2}-ollama/): python3 -I pc07/resumen.py"""
import json, statistics as st
def rd(f): return [json.loads(l) for l in open(f) if l.strip()]
def fila(nombre, f, modelo, paso="tools"):
    rs = [r for r in rd(f) if r.get("paso") == paso and r.get("modelo") == modelo]
    w = [r["wall_s"] for r in rs]; ok = sum(r.get("ok", False) for r in rs)
    cal = w[1:]
    print(f"| {nombre} | {modelo} | {f} | {len(w)} | {ok if paso=='tools' else '—'} | {w[0]:.2f} | {st.median(cal):.2f}; {min(cal):.2f}–{max(cal):.2f} | {sum(w):.1f} |")
print("| Operación | Modelo | Fuente | N | Éxitos | 1.ª llamada s | Siguientes s (mediana; rango) | Suma s |")
print("|---|---|---|---|---|---|---|---|")
fila("herramienta «bicicleta»", "sondeo/salidas/04-tools.jsonl", "qwen3.5:4b")
fila("herramienta «bicicleta»", "pc07/05-tools-35b.jsonl", "qwen3.5:35b-a3b")
fila("herramienta «a pie»", "sondeo/salidas/05-tools-apie.jsonl", "qwen3.5:4b")
fila("herramienta «a pie»", "pc07/06-tools-apie-35b.jsonl", "qwen3.5:35b-a3b")
fila("prompt largo 3503 tok", "pc07/01-largo-4b.jsonl", "qwen3.5:4b", "largo")
fila("prompt largo 3503 tok", "pc07/07-largo-35b.jsonl", "qwen3.5:35b-a3b", "largo")
print()
for f, m in (("pc07/01-largo-4b.jsonl", "qwen3.5:4b"), ("pc07/07-largo-35b.jsonl", "qwen3.5:35b-a3b")):
    rs = [r for r in rd(f) if r.get("paso") == "largo"]
    print(f"{m}: lectura tok/s {[r['lectura_tok_s'] for r in rs]}, generación tok/s {[r['gen_tok_s'] for r in rs]}, carga s {[r['load_s'] for r in rs]}")
for f, m in (("sondeo/salidas/02-chat.jsonl", "qwen3.5:4b"), ("pc07/03-chat-35b.jsonl", "qwen3.5:35b-a3b")):
    r = [r for r in rd(f) if r.get("paso") == "chat" and r.get("modelo") == m][0]
    print(f"chat corto en frío {m}: pared {r['wall_s']} s, carga {r['load_s']} s, generación {r['eval_tok_s']} tok/s ({r['eval_count']} tok)")
