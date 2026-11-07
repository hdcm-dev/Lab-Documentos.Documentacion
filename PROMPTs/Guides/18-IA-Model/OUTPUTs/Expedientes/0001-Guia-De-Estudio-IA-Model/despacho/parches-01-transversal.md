# Constancia de parches — lote «unificaciones transversales» (PA-04, PA-05, PA-06)

| Campo | Valor |
| --- | --- |
| Tipo | constancia de aplicación |
| Fecha | 2026-11-07 |
| Autor | cuerpo de parches (lote transversal) |
| Mandato | evidencia 019; direcciones del folio `despacho/r2-jurado-veredicto.md` §2 |

Todas las rutas son relativas a `Guides/IA/IA-Model/`. Unidad de aplicación: el documento —
cada pieza tocada quedó completa respecto de los tres parches del lote. Ninguna edición entra
en cercas de código ni toca salidas verificadas o marcas del verificador.

---

## PA-04 — Autoría única del Qwen3 Technical Report (arXiv:2505.09388)

Hallazgos que lo fundan: R2-FUN-04, R2-ENT-02, R2-SIS-08, R2-EDI-03.

| Documento | Qué cambió | Líneas (estado final) |
| --- | --- | --- |
| `Convenciones.md` | Nota de SIS-08 en §2.2, Reglas de borde: el informe técnico de equipo se cita por el autor colectivo «aunque el PDF liste autores nominales», con arXiv:2505.09388 como caso | 125–128 |
| `Marco-De-Referencia.md` | Tres filas del glosario (inferencia, motor de inferencia, tokens por segundo): fuente «Yang et al. (2025)» → «Qwen Team (2025)»; en §7 la entrada «Yang, A., et al.» se reemplazó por «Qwen Team. (2025). *Qwen3 Technical Report*. arXiv:2505.09388», reubicada en orden alfabético | 183, 184, 188, 269 |
| `03-Del-Modelo-Base-Al-Asistente.md` | Prosa §1 «(Yang et al., 2025)» → «(Qwen Team, 2025)»; entrada de Referencias reatribuida y reubicada en orden alfabético | 199, 738–739 |
| `06-Ajuste-Fino-Y-Alineacion.md` | Prosa «Un caso» de §1 (el pasaje que nombra el *Qwen3 Technical Report*) reatribuida a «(Qwen Team, 2025)»; entrada de Referencias reatribuida, ubicada junto a la del Qwen2.5 Technical Report | 141, 772 |
| `08-Inferencia-Local.md` | Prosa §1 «(Yang et al., 2025)» → «(Qwen Team, 2025)»; entrada de Referencias reatribuida y reubicada en orden alfabético | 55, 757 |

Verificación: `grep -n "Yang" *.md` ya no devuelve ninguna cita de arXiv:2505.09388 (el único
«Yang» restante es Yang, S., coautor del paper de AWQ en 08, ajeno al hallazgo).

## PA-05 — Parche normativo de frontmatter y pasada única por las 15 piezas

Hallazgos que lo fundan: R2-FUN-06, R2-ENT-07, R2-INF-02, R2-SIS-03, R2-SIS-07, R2-EDI-06,
R2-EDI-09, R2-EDI-10, R2-EDI-11, bajo la unidad de aplicación de R2-REF-09.

**Parche normativo en `Convenciones.md`:**

- §1.1: el bloque YAML fija `owner: ACT-NN` (sólo el ID) y remite la semántica de `traces` al
  texto nuevo; párrafo normativo agregado («Dos campos llevan forma fijada…», líneas 58–71):
  `owner` = sólo el ID del actor del catálogo de M1; `traces` en un temático = prerrequisitos del
  grafo de `Cohesion-Global.md` + siguiente de la ruta formativa, **sin** estructurales (IAM-M0 a
  IAM-M3, que son apoyo universal); en las piezas estructurales, `traces` lista sus pares
  estructurales (y en IAM-M0, el cuerpo que indexa). Resolución de la elección que SIS-03 dejó a
  la mesa: se adopta la propuesta de EDI-10 (los M* no se listan), que es la única que deja el
  campo derivable mecánicamente del grafo.
- §7 (plantilla): `owner: <ID del actor, ACT-NN (§1.1)>` y
  `traces: [<prerrequisitos del grafo y siguiente de la ruta, §1.1>]` (líneas 305, 308).
- §2.2: los dos ejemplares de cita pasados a la forma que el cuerpo usa de manera uniforme
  (EDI-11 b): «Vaswani, A., et al. (2017). Attention is all you need. arXiv:1706.03762» y
  «Qwen Team. (2025). *Qwen3 Technical Report*. arXiv:2505.09388» (líneas 119–120).

**Pasada única por los 15 frontmatters:**

| Documento | owner | traces | otros |
| --- | --- | --- | --- |
| `IA-Model-Guide.md` | «Mantenedor de la guía (ACT-06)» → `ACT-06` | sin cambio (índice: cuerpo completo, conforme a la norma nueva) | — |
| `Marco-De-Referencia.md` | `Lab-Documentos` → `ACT-06` (SIS-07; dirección del jurado «M1 incluido: ACT-06») | sin cambio (pares estructurales) | — |
| `Cohesion-Global.md` | → `ACT-06` | sin cambio | — |
| `Convenciones.md` | → `ACT-06` | sin cambio | parche normativo de arriba |
| `01` | → `ACT-06` | `[IAM-M1, IAM-M2, IAM-M3, IAM-02]` → `[IAM-02]` | — |
| `02` | ya `ACT-06` | ya conforme | `entorno_validado` completado con motor+versión y etiquetas del lab 2, de verif-02: «ollama 0.32.0-rc0 · qwen3.5:4b y qwen3.5:35b-a3b · CTX-03» (línea 12); bloque didáctico §4 pasado a negrita: `*Criterio que forma*:`/`*Respuesta*:`/`*Reenvío*:` → `**…**:` (5+5+5 ocurrencias, líneas 517–565) |
| `03` | ya `ACT-06` | quitados IAM-M1/M2/M3 → `[IAM-02, IAM-08]` | — |
| `04` | «Curador de datos (ACT-05)» → `ACT-05` | ya conforme | — |
| `05` | ya `ACT-06` | ya conforme | — |
| `06` | → `ACT-06` | ya conforme | — |
| `07` | ya `ACT-04` | quitados IAM-M1/M2/M3 → `[IAM-03, IAM-06, IAM-09]` | — |
| `08` | ya `ACT-06` | quitados IAM-M1/M2/M3 → `[IAM-02, IAM-03, IAM-04]` | `entorno_validado`: agregado `qwen3.5:4b` como segundo modelo (línea 12; su uso en §1.3 lo cotejó verif-08 vía `/api/show`) |
| `09` | → `ACT-06` | quitados IAM-M1/M2/M3 → `[IAM-01, IAM-08, IAM-10]` | — |
| `10` | ya `ACT-06` | quitados IAM-08 (la entrada sin criterio de SIS-03) e IAM-M1/M2/M3 → `[IAM-02, IAM-03, IAM-11]` | — |
| `11` | → `ACT-06` | quitado IAM-M0 → `[IAM-05 … IAM-10]` | — |

Verificación corrida: `grep '^owner:'` sobre las 15 piezas devuelve una sola forma (`ACT-NN`);
`grep '^traces:'` devuelve en todos los temáticos exactamente prerrequisitos del grafo de M2 §2
más el siguiente de la ruta formativa; 02 y 08 declaran motor+versión y sus modelos;
`grep -c '\*\*Criterio que forma'` en 02 → 5.

## PA-06 — Apartamiento de extensión declarado al abrir en 03, 06 y 08

Hallazgos que lo fundan: R2-SIS-02, R2-EDI-05. Forma: la de 09 (motivo + eje de partición,
citando `Convenciones.md` §5 y el grafo de `Cohesion-Global.md`); no se parte ninguna pieza.

| Documento | Qué se declaró | Líneas |
| --- | --- | --- |
| `03` | Motivo: los labs 03-A/B/C transcriben completos comandos y salidas reales; eje de partición: base y alineación / muestreo y *prompting* | 29–33 |
| `06` | Motivo: los labs 6.A y 6.B transcriben completos corredores, comandos y salidas reales; eje: ajuste fino supervisado operable / alineación por preferencias | 26–31 |
| `08` | Motivo: los labs 08-A/B/C transcriben completos comandos y salidas reales; eje: motores, formatos y cuantización / operación del banco y métricas de servicio | 32–36 |

Verificación: `grep -ci 'apartamiento' 03-… 06-… 08-…` → 1 en cada uno (antes 0); los de 07 y 09
quedan intactos.

---

## Parches devueltos

Ninguno: ningún parche del lote exigía tocar salidas verificadas ni marcas del verificador.

## Observaciones (exceden la dirección votada; no se aplicaron)

1. **Dos entradas «Qwen Team. (2025)» en las Referencias del 06** (Qwen2.5 TR y Qwen3 TR tras la
   unificación de PA-04). APA pediría 2025a/2025b, y el 06 ya usa ese recurso con Hugging Face
   (2026a/b/c); pero asignar a/b obliga a atribuir una a una las cinco citas en prosa
   «(Qwen Team, 2025)» del 06 (líneas 55, 208, 232, 413, 440) al informe correcto — decisión de
   contenido que excede la dirección votada de PA-04. Donde la prosa nombra el informe (línea
   140–141) la cita es inequívoca; las demás quedan como estaban.
2. **Referencias §8 de `Convenciones.md`** (líneas 362–365): las entradas de Vaswani y Qwen Team
   conservan las comillas españolas que EDI-11 (b) corrigió en los ejemplares de §2.2; la
   dirección votada alcanza sólo a «los dos ejemplares de M3 §2.2», así que §8 quedó igual y
   ahora diverge de §2.2 en estilo.
3. **Celdas del glosario de M1** (183, 184, 188): PA-04 las reatribuyó a «Qwen Team (2025)» para
   no dejar la autoría dividida dentro de M1, pero PA-02 (otro lote) manda copiar en esas mismas
   filas la fuente normativa del documento dueño («documentación oficial + fecha de consulta»):
   al aplicar PA-02 estas celdas se reescriben de nuevo; no hay conflicto, sólo orden.
4. **Prosa de M3 §6.2** conserva «el mantenedor de la guía (ACT-06 del marco de referencia)»: es
   prosa, no frontmatter; la norma nueva de §1.1 aplica al campo `owner`, no al texto corrido.
