#!/usr/bin/env python3
"""Guardia del aplicador de la ronda 4 (expediente 0003). PreToolUse: rechaza (exit 2) todo lo que no sea
consola por ./aislado de una corrida o archivo dentro de una corrida. Registra cada decisión."""
import json, os, re, shlex, sys, time
RAIZ = re.compile(r'^{area-de-ensayo}/(ensayos|privado)/corridas-r4/[A-Za-z0-9-]+(/|$)')
LOG = '{area-de-ensayo}/ensayos/guardia-r4.log'
d = json.load(sys.stdin); t = d.get('tool_name'); i = d.get('tool_input', {})
def fin(ok, motivo):
    with open(LOG, 'a') as f:
        f.write(json.dumps({'t': time.strftime('%H:%M:%S'), 'sesion': d.get('session_id'), 'tool': t, 'ok': ok, 'motivo': motivo, 'input': i})[:2000] + '\n')
    if not ok:
        print(f'GUARDIA: bloqueado ({motivo}). Sólo «cd <tu corrida> && ./aislado <comando>» y archivos de tu corrida.', file=sys.stderr); sys.exit(2)
    sys.exit(0)
_m = RAIZ.match(os.path.realpath(d.get('cwd') or '/') + '/')
PROPIA = _m.group(0).rstrip('/') if _m else None  # la corrida del aplicador, por su directorio de trabajo
def ruta_ok(p):
    if not p or not PROPIA: return False
    p = os.path.realpath(p)
    return (p == PROPIA or p.startswith(PROPIA + '/')) and not re.search(r'/coordinacion(/|$)', p[len(PROPIA):])
if t == 'Bash':
    c = i.get('command', '').strip()
    m = re.match(r'^(?:cd\s+(\S+)\s*&&\s*)?\./aislado\s+(.+)$', c, re.S)
    if not m or not ruta_ok(m.group(1) or d.get('cwd')): fin(False, 'consola fuera de ./aislado')
    resto = m.group(2)
    fuera = re.sub(r"'[^']*'", '', resto)  # lo que el host expande: todo lo que no está entre comillas simples
    if '`' in fuera or '$' in fuera: fin(False, 'expansión en el host (usá comillas simples)')
    try:
        lx = shlex.shlex(resto, posix=True, punctuation_chars=True); toks = list(lx)
    except ValueError: fin(False, 'comillas sin cerrar')
    if any(set(x) <= set(';&|<>()') for x in toks): fin(False, 'operador de consola fuera del contenedor')
    fin(True, 'aislado')
if t in ('Read', 'Write', 'Edit'): fin(ruta_ok(i.get('file_path')), 'archivo')
if t in ('Glob', 'Grep'): fin(ruta_ok(i.get('path')), 'búsqueda (path obligatorio)')
fin(False, 'herramienta no permitida')
