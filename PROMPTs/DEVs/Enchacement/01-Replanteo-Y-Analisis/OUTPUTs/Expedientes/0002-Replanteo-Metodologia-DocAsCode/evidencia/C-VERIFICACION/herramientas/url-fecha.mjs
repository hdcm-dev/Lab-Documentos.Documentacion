// Regla propuesta (Q44, CQ-11): toda URL externa citada lleva en la misma línea
// «consultad[oa] el AAAA-MM-DD». Fuera de bloques de código. exit 1 si falta alguna.
import { readFileSync, readdirSync, statSync } from 'node:fs';
import { join } from 'node:path';
function* walk(d){ for(const n of readdirSync(d)){ const p=join(d,n); const s=statSync(p); if(s.isDirectory()){ if(!['bin','obj','node_modules','.git'].includes(n)) yield* walk(p);} else if(p.endsWith('.md')) yield p; } }
let n=0,t=0;
for (const arg of process.argv.slice(2)) for (const f of (statSync(arg).isDirectory()? walk(arg):[arg])) {
  let code=false;
  readFileSync(f,'utf8').split('\n').forEach((l,i)=>{ if(/^\s*```/.test(l)){code=!code;return;} if(code) return;
    const urls=[...l.matchAll(/https?:\/\/[^\s)>\]`|]+/g)]; if(!urls.length) return; t+=urls.length;
    if(!/consultad[oa]s? el \d{4}-\d{2}-\d{2}/i.test(l)){ n+=urls.length; console.log(`${f}:${i+1}: URL sin fecha de consulta: ${urls[0][0]}`);} });
}
console.log(`urls=${t} sin-fecha=${n}`); process.exit(n?1:0);
