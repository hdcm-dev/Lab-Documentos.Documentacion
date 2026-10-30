# E1-U2 — carril programado corrido en local (semanal.sh): E-F14/E-F11 (§1) y E-F10 (§6). Detalle de enlaces recortado.

# Carril programado de docs-guard — informe

Corrida del 2026-10-27 a las 15:14 UTC. Sólo avisa (N09 §8.2); ningún hallazgo bloquea.

## 1. Árbol del workspace (E-F14, E-F11)

| Repo | Ruta | Commit de main | Segundos | Tamaño |
| --- | --- | --- | --- | --- |
| `hdcm-dev/Lab-Documentos` | `/LAB/Lab-Documentos/Lab-Documentos` | `ad71e47` | 3,3 | 28M |
| `hdcm-dev/Lab-Documentos.Documentacion` | `/LAB/Lab-Documentos/Lab-Documentos.Documentacion` | `60d94f3` | 4,5 | 44M |
| `hdcm-dev/Lab-E2E.WebBlazor` | `/LAB/Lab-E2E.WebBlazor/Lab-E2E.WebBlazor` | `59399ba` | 2,6 | 11M |
| `hdcm-dev/Lab-Geometria` | `/PROG2/Geometria/Lab-Geometria` | `5f07b12` | 6,1 | 55M |

Armado completo: **16,5 s**. Tamaño del árbol: 136M.

## 2. Enlaces entre repos y externos (lychee --root-dir)

Sobre `Guides` de Lab-Documentos, 34,9 s, código de salida 2.

```text
[ERROR] file:///LAB/Lab-Documentos/Lab-Documentos/Guides/Despliegue/DevOps-Guide/guia-flujo-trabajo-versionado.md#cheat-sheet-resumen-de-una-p%C3%A1gina | Cannot find fragment
[ERROR] file:///LAB/Lab-Documentos/Lab-Documentos/Guides/Metodologia-Agiles/Scrum-Guide/guia-de-estudio.md | Cannot find file
   [WARN ] There were issues with GitHub URLs. You could try setting a GitHub token and running lychee again.
```

<details><summary>Detalle de enlaces rotos</summary>

[... detalle de enlaces rotos recortado ...]
## 3. Atraso de base_commit y source.lock

| Archivo | Ancla | Repo | Commits detrás de main |
| --- | --- | --- | --- |
| — | — | — | no hay anclas base_commit ni source.lock en el árbol |

## 4. Deriva de piezas fijadas (BASE-FIJADA.md)

```text
no aplica: la ruta no tiene piezas fijadas (BASE-FIJADA.md)
== PR-7 fijadas: verde (errores=0 avisos=0) piezas=0
```

## 5. Frescura (last_review con más de 365 días)

```text
== frescura last_review > 365 días: verde (errores=0 avisos=0) con-last_review=208
```

## 6. Línea de base de AI-3 (E-F10)

AI-3 avisa y no bloquea. Pasa a bloquear cuando esta cuenta, con las excepciones vigentes, sea 0 en el cuerpo nuevo.

```text
Guides/IA/references/agentes-especialidades/AG-04-ingeniero-prompts.md:20: aviso AI-3 frase-dirigida-al-agente: System prompt
Guides/IA/references/agentes-especialidades/AG-04-ingeniero-prompts.md:47: aviso AI-3 frase-dirigida-al-agente: system prompt
Guides/IA/references/agentes-especialidades/AG-04-ingeniero-prompts.md:60: aviso AI-3 frase-dirigida-al-agente: System prompt
Guides/IA/references/agentes-especialidades/AG-04-ingeniero-prompts.md:72: aviso AI-3 frase-dirigida-al-agente: system prompt
Guides/IA/references/agentes-especialidades/AG-04-ingeniero-prompts.md:89: aviso AI-3 frase-dirigida-al-agente: system prompt
Guides/IA/references/agentes-especialidades/AG-04-ingeniero-prompts.md:106: aviso AI-3 frase-dirigida-al-agente: ignore previous instructions
Guides/IA/references/agentes-especialidades/AG-04-ingeniero-prompts.md:150: aviso AI-3 frase-dirigida-al-agente: System Prompt
Guides/IA/references/agentes-especialidades/AG-04-ingeniero-prompts.md:153: aviso AI-3 frase-dirigida-al-agente: system prompt
Guides/IA/references/agentes-especialidades/AG-04-ingeniero-prompts.md:160: aviso AI-3 frase-dirigida-al-agente: system prompt
Guides/IA/references/agentes-especialidades/AG-04-ingeniero-prompts.md:240: aviso AI-3 frase-dirigida-al-agente: system prompt
Guides/IA/references/refinamiento_docs/agentes-refinamiento-docs.md:146: aviso AI-3 frase-dirigida-al-agente: system prompt
Guides/IA/references/refinamiento_docs/agentes-refinamiento-docs.md:407: aviso AI-3 frase-dirigida-al-agente: system prompt
Guides/IA/references/refinamiento_docs/prompt_refinanmiento.md:84: aviso AI-3 frase-dirigida-al-agente: system prompt
== PR-3 anti-inyeccion: ROJO (errores=824 avisos=100) AI-1=354 AI-2=3 AI-3=13 AI-4=552 AI-5=2
```
