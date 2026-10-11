import re,sys
src,dst=sys.argv[1],sys.argv[2]
t=open(src,encoding='utf-8').read()
ops=[
("Sin motivo escrito, **[no verificado]** quiere decir «requiere Windows» (§0.4).",
 "Sin motivo escrito, **[no verificado]** quiere decir «requiere Windows» (§0.4); todo otro motivo se escribe."),
("que recomiende o desaconseje el BOM en `.cs` **[no verificado]**.",
 "que recomiende o desaconseje el BOM en `.cs` **[no verificado]** (sin documento del fabricante)."),
("[B80] | **[no verificado]** | **[no verificado]** |",
 "[B80] | **[no verificado]** (no ejercitado) | **[no verificado]** (no ejercitado) |"),
("pero que mueva su digest **[no verificado]**:",
 "pero que mueva su digest **[no verificado]** (requiere la plataforma):"),
("y no GitHub [B107] **[no verificado]** (§8.2.2)",
 "y no GitHub [B107] **[no verificado]** (requiere la plataforma; §8.2.2)"),
("No se ejercitó **[no verificado]**.",
 "**[no verificado]** (no ejercitado en el laboratorio)."),
("cómo se comporta con las más nuevas **[no verificado]**.",
 "cómo se comporta con las más nuevas **[no verificado]** (requiere la plataforma)."),
# P-19 Rev 2 sobre la simulación (que ya trae P-19 Rev 1)
("**1.0.0-rc.1.** *Fallback* de Roslyn, BOM de .NET, migración con *squash*, costo de `disable`, `NU1603` con lock, digest y bot, SLSA sin `builder.id`, ramas protegidas, frontera políglota; ruta mínima, Prácticas, mapa, glosario, trazas, B194–B204, E2-7, E2-8.",
 "**1.0.0-rc.1.** *Fallback* de Roslyn, BOM de .NET, migración con *squash*, costo de `disable`, `NU1603` con lock, digest y bot, SLSA sin `builder.id`, ramas protegidas, frontera políglota; ruta mínima, Prácticas, mapa, glosario, trazas, B194–B204, E2-7, E2-8; cuatro marcas de juicio (§0.3)."),
#("**1.0.0.** Dos defensas contra `NU1603`, lock de `WinExe`, compuerta en subcarpetas, devcontainer en Linux, variante B, pnpm 10, Python 3.15.0, procedencia para 8b, dos caminos de CI, `pre-receive`; A.17, A.18, Prácticas de §11 y §12, B205–B217.",
# X
("§3.5 comprimida, Práctica de §3, B218–B224.",
 "§3.5 comprimida, fila §3 en la ruta mínima, motivo por defecto de **[no verificado]**, B218–B224."),
]
for a,b in ops:
    c=t.count(a)
    if c!=1: print("FALLA",c,a[:60]); continue
    t=t.replace(a,b)
open(dst,'w',encoding='utf-8').write(t)
