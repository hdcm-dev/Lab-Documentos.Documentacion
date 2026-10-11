# Mesa · Ciclo 3 · 04b — Aprobación, segunda vuelta: juez de costo-beneficio

> Fecha: 2026-10-09. Marco: `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §5.5 (aprobación). Insumo: «Revisión 2 · P-01 y P-19» de `03-Parches.md` (esta carpeta), que reemplaza a P-01 y P-19 de su §3. El resto del lote ya lo voté en `04-Aprobacion-costo-beneficio.md`, y ese voto no cambia.
> Función objetivo: ¿el costo de corregir (extensión, complejidad, riesgo de diluir) es menor que el daño de no hacerlo? Chequeo obligatorio: ¿corrige en la capa donde nació el defecto?
> Vara propia, la misma de la primera vuelta: la prosa que se agrega tiene que reparar un daño concreto (un registro falso, una afirmación refutada, un comando que falla).

## 1. Comprobaciones propias

| # | Qué | Cómo | Resultado |
|---|---|---|---|
| R1 | La guía sigue siendo la 1.0.0 sobre la que se escribieron las anclas | `sha256sum` de la guía real | `a2b78179…`, sin cambios. |
| R2 | La revisión 2 se aplica y da el Δ declarado | Copia de `evidencia-auditor/r2-p01-p19/` y `simulacion/` al scratchpad; `python3 -I r2.py simulacion/guia-parcheada.md out.md` (no toca el original) | Ninguna `FALLA`; sha256 `eb7d1673…`, igual al declarado; `wc -w` 55 241 → 55 279 (**+38**). |
| R3 | Las verificaciones de P-19 | `grep -c` sobre la copia | `'Práctica de §3'` → 0; `'cuatro marcas de juicio (§0.3)'` → 1. El párrafo 1.1.0 queda con «fila §3 en la ruta mínima, motivo por defecto de **[no verificado]**». |
| R4 | Que las ops 10 a 15 no interfieran con P-23 | `grep -c '**[no verificado]** (requiere Windows)'` sobre la copia | 0: el conteo de P-23 (8 → 0) no cambia. |
| R5 | Las marcas sin motivo que quedan | Lectura de `marcas-sin-motivo.txt` (20 entradas) | 3 de metatexto (definición y regla de §0.3, párrafo 1.1.0) y 17 en contexto de Windows, Visual Studio o Git Bash. Ninguna fuera de las dos clases. |
| R6 | El ancla de la op 14 en la guía real | `grep -n` de «No se ejercitó **[no verificado]**.» | Una sola aparición (L1706, cosign sin clave). La op saca una redundancia: la oración y la marca decían lo mismo. |

## 2. Votos

| Parche | Voto | Fundamento (costo vs. daño · capa) |
|---|---|---|
| P-01 (rev. 2) | APLICAR | Costo: +24 palabras de prosa sobre la revisión 1 (+52 en total), siete paréntesis cortos y una cláusula en §0.3. Daño que evita: la regla «sin motivo, **[no verificado]** = requiere Windows», tal como estaba en la revisión 1, le asignaba un motivo **falso** a siete marcas que no tratan de Windows (BOM en `.cs`, asdf, Renovate, GitLab, cosign, Dependabot). Ese es un registro falso que el propio lote introducía, el tipo de daño que mi vara pone primero. Las alternativas eran peores: volver a la regla de 1.0.0 (la del juez de riesgo) pierde el −16 de P-23 y repite la glosa ocho veces; dejar la regla sin las ops 10 a 15 aplica un motivo falso. Esta es la solución más barata que deja verdadera cada marca, y lo comprobé por sentido, no por glosa (R5). Los motivos reutilizan formas que la guía ya emplea, así que no se suma vocabulario. Elegir «(no ejercitado)» y no «(no documentado)» para asdf evita escribir una afirmación nueva sin fuente, y me parece correcto. El arrastre de P-16 sobre las cifras (223/224) se resuelve con `checks.py` antes de aplicar, sin prosa. Capa: guía, donde nació (§0.3 y las marcas). |
| P-19 (rev. 2) | APLICAR | Costo: +14 palabras de prosa sobre la revisión 1, con lo que el parche queda en Δ 0. Daño que evita: un control de cambios que anuncia una «Práctica de §3» que no entra (registro falso, R3), y que borra «cuatro marcas de juicio (§0.3)», el hecho histórico del que depende la regla nueva de P-01. Un control de cambios que miente sobre su propia versión anula su función, así que reparar el registro vale más que las 14 palabras. No restaurar los demás ítems comprimidos es lo correcto: ningún juez los objetó y restaurarlos sumaría prosa sin reparar ningún daño. Capa: guía (control de cambios). |

## 3. Observaciones que no cambian el voto

- **Saldo de prosa.** La revisión 2 lleva el saldo del lote de +493 a **+531**. Lo que dije en la primera vuelta (§3) vale igual: no se compensa recortando correcciones. El excedente va a P-26, que tiene que diseñarse con texto exacto y Δ medido; si no alcanza, queda como deuda declarada con su cifra. Si se diseña P-26, su meta tiene que partir de +531 y no de +493.
- **Una marca en el metatexto.** En el párrafo 1.1.0, «motivo por defecto de **[no verificado]**» usa la marca como nombre, no como juicio. Por eso R5 la cuenta en la clase (a), y está bien. No pido cambiarla: ponerla en código o entre comillas costaría otra excepción en §0.3 sin reparar ningún daño.
- **Orden.** La condición C-3 de mi primera vuelta se mantiene (P-24 → P-16 → P-25 → P-01…P-22 → P-23). Las ops 10 a 15 no dependen del orden, porque ningún parche de P-02 a P-22 toca sus anclas (R2). La verificación 2 de P-01 corre **después** de P-23, como dice el parche.

## 4. Resumen

- **APLICAR: 2 de 2** (P-01 y P-19, revisión 2). MEJORAR_PLAN: 0. NO_APLICAR: 0. ESCALAR: 0.
- **Capa de origen**: los dos corrigen en la guía, donde nació el defecto.
- **Δ**: +38 palabras de prosa, reproducidas (R2). Reparan un registro falso que creaba el propio lote, y el saldo total pasa a +531 (§3).
- **Supuestos**: fecha de trabajo 2026-10-09, la del sistema y la de la bitácora. No toqué la guía, `Examples/` ni el prompt del PO; la simulación corrió sobre una copia en el scratchpad.
