# ---------------- P-03 3f · normalización de marcas (pasada final, fuera de bloques de código) ----------------
begin("P-03-3f")
def fuera_de_codigo(fn):
    L = lines(); fence = False; n = 0
    for i, l in enumerate(L):
        if l.lstrip().startswith("```"):
            fence = not fence; continue
        if not fence:
            nl, k = fn(l)
            if k: L[i] = nl; n += k
    setlines(L); return n
MARK = r"\[(?:criterio|no verificado|observado|interpretación)\]"
def contar():
    L = lines(); fence = False; tot = neg = 0
    for l in L:
        if l.lstrip().startswith("```"): fence = not fence; continue
        if fence: continue
        tot += len(re.findall(MARK, l)); neg += len(re.findall(r"\*\*" + MARK, l))
    return tot, neg
antes = contar()
MAPA = [
    ("**[no verificado en Windows]**", "**[no verificado]** (requiere Windows)"),
    ("**[no verificado en Visual Studio]**", "**[no verificado]** (requiere Visual Studio)"),
    ("**[no verificado como ausencia]**", "**[no verificado]** (como ausencia)"),
    ("**[no verificado: no hubo runner Windows]**", "**[no verificado]** (no hubo runner Windows)"),
    ("**[no medido]**", "**[no verificado]** (no medido)"),
    ("**[no ejercitado en el laboratorio]**", "**[no verificado]** (no ejercitado en el laboratorio)"),
    ("**[hallazgo negativo, a revalidar]**", "**[no verificado]** (hallazgo negativo, a revalidar)"),
    ("**[criterio sobre base del fabricante]**", "**[criterio]** (sobre la base del fabricante)"),
    ("**[criterio, apoyado en E7-4 y en [B83]]**", "**[criterio]** (apoyado en E7-4 y [B83])"),
    ("**[criterio]** El ciclo típico de un commit de BOM", "**[interpretación]** El ciclo típico de un commit de BOM"),
]
for a, b in MAPA:
    k = fuera_de_codigo(lambda l, a=a, b=b: (l.replace(a, b), l.count(a)))
    LOG.append(("P-03", "3f " + a[:45], True, f"{k} reemplazo(s)"))
k = fuera_de_codigo(lambda l: (re.sub(r"(?<!\*\*)\[criterio\](?!\*\*)", "**[criterio]**", l), len(re.findall(r"(?<!\*\*)\[criterio\](?!\*\*)", l))))
LOG.append(("P-03", "3f [criterio] sin negrita → en negrita", True, f"{k} reemplazo(s)"))
despues = contar()
LOG.append(("P-03", "3f conteo marcas fuera de código (total, en negrita)", True, f"antes {antes} · después {despues}"))
MARK_COUNT = (antes, despues)

# ---------------- P-12 · «pieza» → «artefacto» fuera de §1.1 (ajuste para cumplir su verificación, C1-54) ----------------
begin("P-12-verif")
R("con qué entorno se construyó cada pieza.", "con qué entorno se construyó cada artefacto.")
R("| Saber con qué se construyó una pieza ya publicada |", "| Saber con qué se construyó un artefacto ya publicado |")
R("**¿Qué capas hay que registrar para afirmar con qué entorno se construyó una pieza?**", "**¿Qué capas hay que registrar para afirmar con qué entorno se construyó un artefacto?**")
R("Todo lo que se incrusta en la pieza tiene que ser reproducible", "Todo lo que se incrusta en el artefacto tiene que ser reproducible")
R("Ninguna pieza se construye sola", "Ninguna parte se construye sola")
R("«con qué entorno se ensambló la pieza»", "«con qué entorno se ensambló el artefacto»")
R("¿Qué se agrega a la pieza que el SDK no graba?", "¿Qué se agrega al artefacto que el SDK no graba?")

# ---------------- Derivado de P-22 L18: el extracto literal de EA-1 en §5.5 ----------------
begin("DER-EA1")
R("POLITICA-TEXTO: 21 archivo(s) revisado(s), 0 violación(es)", "POLITICA-TEXTO: 23 archivo(s) revisado(s), 0 violación(es)")

# ---------------- Versión y control de cambios ----------------
begin("VERSION")
R("version: 1.0.0-borrador", "version: 1.0.0-rc.1")
R("last_review: 2026-10-07", "last_review: 2026-10-09")
R("> **Versión 1.0.0-borrador.** Fecha: 2026-10-07.", "> **Versión 1.0.0-rc.1.** Fecha: 2026-10-09 (primera versión integrada: 2026-10-07; [control de cambios](#control-de-cambios)).")
AFTER("- **[Anexo F. Límites y lo que no se verificó](#anexo-f-límites-y-lo-que-no-se-verificó)**: hechos, interpretaciones y pendientes, separados.",
      "\n- **[Control de cambios](#control-de-cambios)**: qué cambió en cada versión de la guía.")
G["S"] = G["S"].rstrip("\n") + """

---

## Control de cambios

| Versión | Fecha | Cambios |
|---|---|---|
| 1.0.0-borrador | 2026-10-07 | Primera versión integrada: caso, marco, mapa de capas, capítulos 4 a 11, hoja de ruta y anexos A–F, con 71 experimentos. |
| 1.0.0-rc.1 | 2026-10-09 | Revisión integral, ciclo 1. **Corrige**: el *fallback* de Roslyn en Windows con ACP UTF-8 pasa a pregunta abierta (§4.2.1); Razor y Node fallan con un identificador cp1252 (§4.2.4); el BOM de la familia .NET es convención del equipo, con la rama «heredado todavía en cp1252» y `dotnet new console` con BOM (§5.2.3); la fusión por *squash* es compatible con `.git-blame-ignore-revs` si cada commit va en su PR (§5.2.6); el refresco del working tree exige árbol limpio (§5.2.6, paso 5); el compilador que usa Visual Studio depende del SDK (§6.2.2); `rollForward: disable` exige el SDK exacto en toda máquina, y §6.4 presenta las políticas con lock y sin lock; el lock calla `NU1603` (§7.2.1); `pip-compile` no tiene `--universal` (§7.2.3); pnpm hace cumplir `packageManager` sin Corepack (§6.2.3); digest y bot donde se construye lo publicado, y etiqueta fija o receta de la CI en el devcontainer (§8.2.2); una procedencia con `builder.id` vacío no alcanza SLSA L1 y la firmada se condiciona a un consumidor (§9.2.4, §12 pasos 8a y 8b); qué impide y qué no una rama protegida, y el mínimo de plan para una organización (§10.2.7); alcance de la compuerta y «falta herramienta ≠ violación» (§10.2.2); `devEngines` hace cumplir Node dentro de MSBuild, la igualdad A = B se prueba en la CI y la imagen única es la de la CI cuando el artefacto es uno (§11). **Agrega**: ruta mínima del Recorrido y una sección **Práctica** por capítulo; mapa «por contexto» (§3.6); una pregunta situada y su *Aplica* en cada capítulo; tabla de trazas (Anexo F); 23 términos nuevos en el glosario; fuentes B194–B204; experimentos E2-7 y E2-8 y ampliaciones de E1-04, E1-05, E1-13, E2-2, E3-2, E3-3, E4-2, E4-4, E8-3, E8-6 y EA-1. **Plantillas**: `Directory.Build.targets` con el lock sólo en los ejecutables, devcontainer con la receta de A.10, A.10 con Node 24, esqueleto de compuerta que falla a propósito, ecosistema `docker` en `dependabot.yml`. **Marcas**: un vocabulario cerrado de cinco (§0.3). |
"""
LOG.append(("VERSION", "control de cambios", True, ""))
