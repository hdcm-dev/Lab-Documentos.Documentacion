import { chromium } from 'playwright';
import fs from 'fs'; import path from 'path';
const dir='/bloques'; const files=fs.readdirSync(dir).filter(f=>f.endsWith('.mmd')).sort();
const browser=await chromium.launch(); const page=await browser.newPage();
await page.setContent('<html><body><div id="c"></div></body></html>');
await page.addScriptTag({path:'/run/node_modules/mermaid/dist/mermaid.min.js'});
await page.evaluate(()=>mermaid.initialize({startOnLoad:false}));
let ok=0;
for (const f of files){
  const src=fs.readFileSync(path.join(dir,f),'utf8');
  const r=await page.evaluate(async ({src,id})=>{ try{ await mermaid.parse(src); const {svg}=await mermaid.render(id,src); return {ok:true,len:svg.length}; }catch(e){ return {ok:false,err:String(e.message||e).slice(0,300)} } },{src,id:'m'+ok+Math.floor(Math.random()*1e6)});
  if(r.ok) ok++; console.log((r.ok?'VALIDO ':'INVALIDO ')+f+(r.ok?' svg='+r.len:' '+r.err));
}
console.log(`mermaid ${await page.evaluate(()=>mermaid.version?mermaid.version():'?')} válidos ${ok}/${files.length}`);
await browser.close();
