// Regla propuesta (Q16): en lo que se publica para agentes no hay comentarios HTML
// ni caracteres invisibles o de control bidireccional. exit 1 si aparece alguno.
import { readFileSync, readdirSync, statSync } from 'node:fs';
import { join } from 'node:path';
const reglas = [
  ['comentario-html', /<!--[\s\S]*?-->/g],
  ['ancho-cero', /[​-‍⁠﻿]/g],
  ['bidi', /[‪-‮⁦-⁩]/g],
  ['etiqueta-unicode', /[\u{E0000}-\u{E007F}]/gu],
];
function* walk(d){ for(const n of readdirSync(d)){ const p=join(d,n); const s=statSync(p); if(s.isDirectory()){ if(!['bin','obj','node_modules','.git'].includes(n)) yield* walk(p);} else if(p.endsWith('.md')) yield p; } }
let n=0;
for (const arg of process.argv.slice(2)) for (const f of (statSync(arg).isDirectory()? walk(arg):[arg])) {
  const t=readFileSync(f,'utf8');
  for (const [id,re] of reglas) for (const m of t.matchAll(re)) { n++; const ln=t.slice(0,m.index).split('\n').length; console.log(`${f}:${ln}: ${id}: ${JSON.stringify(m[0].slice(0,60))}`); }
}
console.log(`ocultos=${n}`); process.exit(n?1:0);
