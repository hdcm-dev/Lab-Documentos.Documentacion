---
doc_id: BIT-16-REC-04-RIESGO-V2
doc_type: aprobacion-de-plan
title: Aprobación del plan de recuperación, vuelta 2 — juez de riesgo (mesa de recuperación, 2026-10-28)
status: APROBAR
origin: agent (jurado, juez de riesgo)
last_review: 2026-10-28
---

# Aprobación del plan de recuperación, vuelta 2: juez de riesgo

**Objeto:** [`03-Plan-De-Recuperacion.md`](03-Plan-De-Recuperacion.md), vuelta 2 (sha256 `2756415c01fea5016b0768f4a457ef7d41935346ab3e8f31e5aa76c23df0540e`), revisada contra mi boleta de la vuelta 1, [`04-Aprobacion-riesgo.md`](04-Aprobacion-riesgo.md) (M-1 a M-9 y tres menores).
**Función:** riesgo e irreversibilidad. Miro tres cosas: que ningún dato privado llegue a un commit de un repo público, que no se pierda evidencia sin copia y que la fase con modelo no salga contaminada.

**Decisión: APROBAR.** Las nueve correcciones obligatorias que pedí están en el §4. En dos casos el plan va más lejos de lo que pedí (M-F y M-K). Lo que queda son observaciones de forma que no bloquean y se pueden resolver mientras se aplica. No hay nada que escalar: no hay conflicto con REED-16 §12, y los actos irreversibles (commit, publicación de la demo, paso a «publicada») siguen reservados al PO en B-15 (DEU-07).

## 1. Cotejo de mis correcciones

| Mía (v1) | En la v2 | Estado | Comentario |
|---|---|---|---|
| M-1 variables sin defecto | M-A (+ fila 1.5 reescrita, §4.3 regla 2) | **Cubierta** | Cubre todos los modos con modelo y `demo.sh embeddings`. Exige rc ≠ 0 sin llamada HTTP y un caso en `ArnesTests` por variable. Suma `RLLM_MAQUINA_PROPIO`. |
| M-2 frase de `tool_choice` | M-B (+ 6.9 reescrita, paso 6.12) | **Cubierta** | Lista las 7 apariciones y alinea §8 y ADR en B-09/B-10. La compuerta tiene un criterio verificable. |
| M-3 caída de REC-13 | M-E + DEU-08 | **Cubierta** | Es la caída que preví, así que no cambia la ganadora por otra causa. La condición de mi firma se cumple y no hace falta otra vuelta. La compuerta `grep LimitadorDelModelo = 0` evita que quede código a medias. |
| M-4 lector sin cuerpos | M-I | **Cubierta** | La prueba confirma que no hay cuerpo en `RLLM_DIR`. Se suman `compuerta-cabeceras.sh`, el rebuild n/n y `ArnesTests`. |
| M-5 fracción de interpretables, misma familia | M-G | **Cubierta** | La fracción va en el criterio con sha256 antes del turno. Hay `grep 'no es validación'` ≥ 1. |
| M-6 texto inyectado sintético, oráculo | M-H | **Cubierta** | Lo del insumo entra sólo como existencia rotulada, nunca como tasa. Hay barrido sobre las citas. |
| M-7 partir el turno en la misma estación | M-D | **Cubierta** | Tiene cinco reglas, y la exención de R-DG y R-E5 está justificada porque son descriptivas y no se agregan. La verificación con `jq` (un solo `servidor` por corrida) es mecánica. |
| M-8 calibración por modelo | M-F + DEU-09 | **Cubierta, más fuerte** | La v2 suma una prueba sin modelo y permite corregir `GuardaDeTruncado`. Lo acepto: es código sin modelo, sobre copia, reversible y verificado por build n/n. Pongo una condición en §2.1. |
| M-9 rótulo modelo de §0.4 | M-J (6.0, 6.0b, 6.13, compuerta en 10.16 y 12.3) | **Cubierta, más fuerte** | Pasa de un párrafo a una compuerta de cinco patrones con lista clasificada, y exige que la forma corta de §0.4 sea idéntica a la de 12.1. |
| menor: N de R-06 | R-06 reescrita, §4.3 regla 4 | **Cubierta** | 17 de evaluación y 10 de calibración, disjuntos. |
| menor: nombre de fase `lan` | m-2 | **Cubierta** | Coincido con no renombrarla, porque está en capturas fijadas por hash. La nota de 2.7 la declara. |
| menor: clon limpio y AC-7/AC-8 | m-3 | **Cubierta** | — |

## 2. Riesgos nuevos que mira la v2

- **M-K, precondición de digest en la fase compartida.** Reduce riesgo: hoy la fase compartida podría medir contra otro artefacto sin enterarse. La comparación con `2a654d98e6fb` como «otro artefacto, nunca equivalente» cierra la confusión entre la base y el entorno vigente. Las variables de lo esperado van sin defecto y viven sólo en el shell. Los digests de modelos públicos no son datos privados.
- **R-PRIV del propio plan v2.** Barrí el plan buscando IPs, también parciales y del rango 100.x, rutas del home, usuario, equipos del laboratorio, recursos del gestor y la clave de cabeceras. **Encontré 0.** Las únicas direcciones son `127.0.0.1` y «la interfaz del bridge». Los números con puntos son versiones (0.10.1, 0.32.0, 0.40.11 y otras).
- **Irreversibles.** No cambió nada respecto de la v1. Están la foto previa (B-00 0.1), el diff de cada `sed` (2.3), las capturas fijadas por hash sin tocar y el insumo de sólo lectura con su verificación (0.4). Ningún commit, push, PR ni rama.

### 2.1 Condiciones de aplicación (no reabren el voto)

1. **M-F, si se corrige `GuardaDeTruncado`.** El delta tiene que quedar acotado a esa pieza. Hay que anotar `diff-base.sh` y `diff-dominio.sh` en `04-Aplicacion.md`, y la demo tiene que seguir pasando `demo.sh pruebas`. Si el delta toca el dominio o la demo más allá de esa guarda, se aplica DEU-09 y no se corrige en esta mesa.
2. **M-J, compuerta de cinco patrones.** `0\.32\.0` puede coincidir con menciones legítimas (fichas de referencias, historia de versiones). La lista clasificada de `04-Aplicacion.md` tiene que dar una razón por cada aparición que se conserve. No vale una excepción en bloque.

## 3. Observaciones de forma (no bloquean)

- **§2 B-11, preparación 6**, todavía dice «un turno que no cabe se parte» sin «en la misma estación». Lo salva la regla de precedencia (§4 manda). Conviene, de todos modos, agregar «(ver M-D)» en esa línea, para que quien aplique leyendo sólo el §2 no lo pase por alto.
- **Encabezado.** Dice «aprobado al incorporar §4, pendiente de aplicar», y m-4 dice que el `status` refleje «votado; Vuelta 2 consolidada» hasta B-15. No hay riesgo, pero sí una inconsistencia que la presidencia puede alinear.
- **B-11, preparación 4**, remite a «B-01 1.5» por las variables sin decir «sin defecto». La regla 2 del §4.3 lo cubre. Es la misma situación que la primera observación.

## 4. Firma

Juez de riesgo, mesa de recuperación de la guía 16, 2026-10-28. **APROBAR** la vuelta 2, con las dos condiciones de aplicación de §2.1, que se verifican en `04-Aplicacion.md` y no reabren el voto. No ejerzo veto.

## 5. Re-verificación (2026-10-29)

Volví a revisar el plan. El sha256 sigue siendo `2756415c…540e`, el mismo que se revisó arriba, así que el plan no cambió. Repetí el barrido R-PRIV (IPs, también parciales y del rango 100.x, rutas del home, usuario, equipos, recursos del gestor y la clave de cabeceras) y dio 0. Los únicos números con puntos que aparecen son versiones y `127.0.0.1`. La línea 294 (B-11, preparación 6) todavía no dice «en la misma estación». La cubre M-D por la regla de precedencia, y la observación de §3 sigue en pie. **Mantengo APROBAR**, con las condiciones de §2.1.
