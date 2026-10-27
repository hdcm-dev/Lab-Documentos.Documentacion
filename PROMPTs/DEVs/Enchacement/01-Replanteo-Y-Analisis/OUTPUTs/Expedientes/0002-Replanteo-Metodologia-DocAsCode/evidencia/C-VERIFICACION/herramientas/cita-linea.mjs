// Regla propuesta (C-VERIFICACION): toda cita a un archivo del workspace escrita como
// `/<RAIZ>/.../archivo.ext` (ruta desde la raíz, decisión D6) debe llevar :línea o :inicio-fin.
// Salida: una línea por infracción; exit 1 si hay alguna.
import { readFileSync, readdirSync, statSync } from 'node:fs';
import { join } from 'node:path';
const raices = /^\/(LAB|IA|PROG2|Ng|Repos-Docker|Host|Research)\//;
const re = /`(\/[^`\s]+\.(md|cs|csproj|yml|yaml|json|props|razor|sh|txt|ps1))(:[0-9][0-9,\-]*)?`/g;
function* walk(d){ for(const n of readdirSync(d)){ const p=join(d,n); const s=statSync(p); if(s.isDirectory()){ if(!['bin','obj','node_modules','.git'].includes(n)) yield* walk(p);} else if(p.endsWith('.md')) yield p; } }
let n=0, total=0;
for (const arg of process.argv.slice(2)) for (const f of (statSync(arg).isDirectory()? walk(arg):[arg])) {
  readFileSync(f,'utf8').split('\n').forEach((l,i)=>{ for(const m of l.matchAll(re)){ if(!raices.test(m[1])) continue; total++; if(!m[3]){ n++; console.log(`${f}:${i+1}: cita sin línea: ${m[1]}`);} } });
}
console.log(`citas-a-raiz=${total} sin-linea=${n}`);
process.exit(n?1:0);
