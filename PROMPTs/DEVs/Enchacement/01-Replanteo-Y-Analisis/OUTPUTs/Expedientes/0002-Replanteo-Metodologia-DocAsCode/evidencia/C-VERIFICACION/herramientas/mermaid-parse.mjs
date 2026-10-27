// Valida la sintaxis de cada bloque ```mermaid con el parser oficial (mermaid.parse), sin navegador.
import { JSDOM } from 'jsdom';
const dom = new JSDOM('<!doctype html><html><body></body></html>');
globalThis.window = dom.window; globalThis.document = dom.window.document;
for (const k of ['Element','HTMLElement','Node','SVGElement','DocumentFragment','DOMParser','MutationObserver']) globalThis[k]=dom.window[k];
const { default: mermaid } = await import('mermaid');
import { readFileSync, readdirSync, statSync } from 'node:fs';
import { join } from 'node:path';
function* walk(d){ for(const n of readdirSync(d)){ const p=join(d,n); const s=statSync(p); if(s.isDirectory()){ if(!['bin','obj','node_modules','.git'].includes(n)) yield* walk(p);} else if(p.endsWith('.md')) yield p; } }
let n=0,t=0;
for (const arg of process.argv.slice(2)) for (const f of (statSync(arg).isDirectory()? walk(arg):[arg])) {
  const lines=readFileSync(f,'utf8').split('\n'); let buf=null, start=0;
  for (let i=0;i<lines.length;i++){ const l=lines[i];
    if(buf===null && /^\s*```mermaid\s*$/.test(l)){ buf=[]; start=i+1; continue; }
    if(buf!==null && /^\s*```\s*$/.test(l)){ t++; try{ await mermaid.parse(buf.join('\n')); } catch(e){ n++; console.log(`${f}:${start}: mermaid inválido: ${String(e.message||e).split('\n')[0].slice(0,120)}`);} buf=null; continue; }
    if(buf!==null) buf.push(l);
  }
}
console.log(`bloques=${t} invalidos=${n}`); process.exit(n?1:0);
