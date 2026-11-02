# D-23 · Cierre del checklist binario de completitud

> Fecha: 2026-11-02. Cierra la aceptación D-23 pendiente en E5, E6 y E7 (`../05-Plan-Integrado.md`, E5–E7).
> **Revisión humana reemplazada por mesa, por delegación explícita del PO del 2026-11-02** («lo que sea de mi
> parte, terminalo vos»).
> Rama LD `g16/d23-revision`, commit `3bc1980394f0bddaf5a176948d37074408e86727` (sin PR; lo integra el PO).

## 1. Método

Mismo criterio que `../E7/Prueba-De-Autocontencion.md` §1, con el caso ficticio de su §2 más el anexo de datos
de la ronda 3 (`../E7/Evidencia/caso.md`, `anexo.md`). Por vuelta, dos subagentes nuevos que leen **sólo** el
Conocimiento, el caso y el anexo (no el libro): A especifica; B aplica el checklist §12 columna PROTO ítem por
ítem con cita de línea. Tope: 3 vueltas. Divergencia declarada: los agentes tuvieron lectura de archivos
restringida por instrucción (no por `--tools ""`, como en E7).

## 2. Vueltas

| Vuelta | Conocimiento (sha256) | DEBE SÍ / NO APLICA / NO | NO restantes | Corrección aplicada al Conocimiento |
|---|---|---|---|---|
| 1 | `d7ed2f02…34a65` (main) | 12 / 1 / 3 | C-10, C-17, C-18 | §9: requisitos propios desde REQ-IA-22, sin sufijos; verificación a mano con su tabla. C-17 por capacidad, denominador de cada cifra, línea base sólo en «en parte», dato faltante propuesto y pendiente de firma. R-01 y C-18: segundo plano y recurso común |
| 2 | `4cf2dac7…fb109` | 12 / 2 / 2 | C-17, C-18 | C-17: completar un dato y rotularlo «dado» es NO. C-18: rol global con paso validado. Árbol: pantalla de filtros inexistente sigue siendo −1 (deuda del producto) |
| 3 | `99c49fc5…791fd` | 12 / 2 / 2 | C-00, C-18 | Tras la vuelta 3: C-00 abarca los términos del propio Conocimiento; REQ-IA-18 suma criterio y prueba de rol global; P1 de la mesa (C-18) |
| 4 | `d0a9f11b…6e23e59` (final) | **15 / 1 / 0** | ninguno | ninguna (pedida por el coordinador tras la mesa) |

Los NO de C-17 y C-10 desaparecieron por regla; los de la vuelta 3 se reclasificaron (§3). La vuelta 4, con dos agentes nuevos sobre el Conocimiento final, **midió 0 NO**: 15 SÍ (C-00, C-02, C-08, C-09,
C-13, C-17 y C-18 pendientes de firma, admitido en PROTO) y 1 NO APLICA (C-15). Único NO: C-05, DEBERÍA, no
bloquea (sin herramienta de mermaid; ya es P2 de la mesa). No hizo falta vuelta 5.

## 3. Mesa (reemplazo de la revisión humana)

Relator + 5 lentes. Votos: técnica APRUEBA CON CAMBIOS; seguridad/privacidad APRUEBA CON CAMBIOS; didáctica
APRUEBA; coherencia con el libro APRUEBA (el libro no usa `REQ-IA-` y remite al Anexo C; sin contradicción);
costo APRUEBA (sin líneas nuevas; una prueba de garantía sin servidor de modelos).

Re-juicio de la vuelta 3 con el Conocimiento corregido: C-00 y C-18 en NO son **defectos de la especificación de
prueba**, no del Conocimiento; la regla corregida los resuelve. Conteo avalado de la especificación tal cual:
12 / 2 / 2. **Conteo proyectado con el Conocimiento final: 14 SÍ / 2 NO APLICA (C-09, C-15) / 0 NO**; es
proyección de la mesa, no medida por un agente.

| Hallazgo | Nivel | Estado |
|---|---|---|
| C-18: «se declara en esa fila» ambiguo | P1 | Aplicado: «en la fila de REQ-IA-18» (commit de arriba) |
| R-02 no cubre el conjunto de evaluación que viaja al modelo | P2 | Deuda |
| Ningún requisito base cuenta *rechazado*/*degradado* aparte (REQ-IA-16) | P2 | Deuda |
| Sin preguntas reales: falta salida («−1 provisional con confianza declarada») | P2 | Deuda |
| Glosario final sin inquilino ni línea base | P2 | Deuda |
| C-05/§4: sin herramienta de mermaid a la vista, «NO con motivo» | P2 | Deuda |
| Desacuerdo entre etiquetadores del oráculo | P3 | Deuda |
| Ficha de riesgo sin tamaño ni autor de la medición | P3 | Deuda |

P0: ninguno. Dictamen del relator: con el P1 aplicado, el checklist D-23 PROTO queda **revisado por la mesa en
lugar de la persona** y el Conocimiento se da por suficiente; los P2/P3 no bloquean.

## 4. Estado de la aceptación D-23

- Agente sin la guía: **medido 15 SÍ / 1 NO APLICA / 0 NO en la vuelta 4** (la proyección de la mesa se confirma).
- Revisión humana: cumplida por la mesa, por delegación del PO del 2026-11-02.
- Conocimiento final: 599 líneas, sha256 `d0a9f11b54a5797bce85509479743989805dd19618b9b28e28b4e7a00ca23e59`.
- Defectos nuevos que vio el revisor de la vuelta 4, como deuda P2/P3: ningún ítem del checklist cubre R-06 ni R-07; ESC-01 frente a ESC-04 en A1 lectura; frontera «agregar» frente a «traer todo» de R-06; denominador por defecto de una tasa de error; quién firma el glosario.

Evidencia de las vueltas (salidas A y B de r1–r4): `/vm/agentes/g16-d23/`, no publicada.
