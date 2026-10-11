# Mesa · Ciclo 3 · 04b — Aprobación, 2.ª vuelta: juez de riesgo e irreversibilidad

> Fecha: 2026-10-09. Rol: juez de riesgo de la mesa de aprobación, segunda vuelta (marco `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §5.3, §5.5 y §6).
> Objeto: la «Revisión 2 · P-01 y P-19» de `03-Parches.md`, que reemplaza a P-01 y P-19 de su §3 en respuesta a los `04-Aprobacion-*.md`. Mi voto de la primera vuelta está en `04-Aprobacion-riesgo.md` (P-01 y P-23 en `MEJORAR_PLAN`, P-19 en `APLICAR` con condición).
> Preguntas que me tocan: ¿la corrección se puede revertir? ¿Qué se rompe en la guía si sale mal? Veto sólo si es irreversible y S3 o menor.

## 1. Qué verifiqué (E1, 2026-10-09)

No me quedé con lo que declara el auditor: repetí la prueba y escribí un detector propio de marcas sin motivo.

1. **La guía de base es la que dice la revisión.** `sha256sum` de la guía 1.0.0 → `a2b78179b2507f0a…`, igual al declarado.
2. **Las anclas de la revisión 2 son únicas en la guía 1.0.0.** `grep -cF` de cada ancla (op 9 y ops 10 a 15) → `1` en los siete casos.
3. **La prueba del auditor se reproduce.** `python3 -I r2-p01-p19/r2.py simulacion/guia-parcheada.md <copia>` no imprime ninguna `FALLA`; la copia da sha256 `eb7d1673b3ff5d7e…` y 55 279 palabras (`wc -w`), lo mismo que declara la revisión.
4. **Los chequeos de texto dan lo prometido** sobre la copia: `grep -c '(requiere Windows)'` → 0 (P-23 no cambia); `grep -c 'Práctica de §3'` → 0; `grep -c 'cuatro marcas de juicio (§0.3)'` → 1.
5. **Clasificación de todas las marcas sin motivo, con un detector independiente.** Recorrí cada `**[no verificado]**` y conté como «sin motivo» la que no tiene detrás un paréntesis o tiene uno que empieza con `§` (la misma definición de la revisión). Resultado: **20**, en las mismas líneas que `marcas-sin-motivo.txt`. Clase (a), metatexto: L93 (definición), L97 (la regla) y L3638 (párrafo 1.1.0). Clase (b), Windows, Visual Studio, Git Bash o ESC-01: L113, L385, L483, L498, L530, L690, L713, L812, L832, L1046, L1056, L1119, L1243, L2000, L2333, L2868, L2870. Miré el contexto de las dos menos obvias: L483 trata de «la estación Windows con la opción beta de UTF-8», y L1119 es la fila de Visual Studio que cierra con «*Aplica* a ESC-01 (Windows con Visual Studio)». Fuera de clase: **0**.

Las tres marcas que objeté en la primera vuelta (L539, las dos celdas de L1027 y L1411) quedan cubiertas por las ops 10, 11 y 12. Las ops 13 a 15 cubren además tres casos que yo no había listado (L1482, L1698, L1953). El defecto de §2 de mi primer voto ya no se reproduce.

## 2. Votos

### P-01 (revisión 2): APLICAR

- **Reversibilidad.** Son quince reemplazos literales de una sola aparición en un `.md`. Cada uno se revierte con el reemplazo inverso, que también es único. No es irreversible, así que no hay veto posible.
- **Qué se rompe si sale mal.** El único modo de falla que me preocupaba era semántico: una marca leída como «requiere Windows» sin serlo. La verificación nueva (listar y clasificar **todas** las marcas sin motivo) es la que pedí, y da 0 fuera de clase en la simulación. Los motivos agregados («(requiere la plataforma)», «(no ejercitado en el laboratorio)», «(sin documento del fabricante)») ya los usa la guía o describen la ausencia de evidencia sin afirmar nada nuevo. La elección de «(no ejercitado)» para asdf, en lugar de «(no documentado)», baja el riesgo, porque no agrega una afirmación sin fuente. Severidad del peor caso que queda: S3 y local.
- **Arrastre de P-16.** La regla 224/223 sobre las ops 2 y 5 está escrita, y la decide `checks.py` sobre la guía real después de P-16. Esto cumple la condición que puse en la primera vuelta («si P-16 o P-17 no entran, se vuelven a contar»).
- **Riesgo residual, que no bloquea.** La regla por defecto es frágil frente a ediciones futuras: un `**[no verificado]**` nuevo sin motivo va a leerse como «requiere Windows». **[criterio]** Condición: el listado clasificado de la verificación 2 se corre en la guía real después de P-23, no sólo en la simulación, y conviene sumarlo como chequeo permanente (a `checks.py` o a la integración), para que una marca futura fuera de clase haga fallar el chequeo.
- **Orden.** Sin cambios: el laboratorio va antes que los parches que lo citan, P-16 antes de P-01, y P-23 al final.

### P-19 (revisión 2): APLICAR

- **Reversibilidad.** Son dos párrafos del control de cambios. Se revierten con una edición y no mueven anclas ni tocan el laboratorio.
- **Qué se rompe si sale mal.** Lo peor sería un historial que describe algo que no entró. La revisión saca la «Práctica de §3», que no entra (C3-41), y cada ítem del párrafo 1.1.0 queda atado a un parche aplicado (P-01 op 7, P-01 op 9 con P-23, P-03). Conservar «cuatro marcas de juicio (§0.3)» en rc.1 preserva el hecho histórico en el que se apoya la regla nueva.
- **Mi condición de la primera vuelta** («si P-01 o P-23 vuelven reformulados, la fila 1.1.0 los describe tal como entren») queda cumplida: el párrafo nombra el cambio de convención, «motivo por defecto de **[no verificado]**», y la revisión 2 de P-01 conserva esa regla.
- **Condición de arrastre.** «B218–B224» se ajusta a «B218–B223» con la misma decisión de `checks.py` que P-01. Si P-01 o P-23 llegaran a no aplicarse, hay que quitar del párrafo 1.1.0 «motivo por defecto de **[no verificado]**».

## 3. Efecto sobre P-23

No me toca votarlo en esta vuelta, pero dejo escrito el efecto de riesgo: con P-01 revisión 2 aplicado **antes**, el defecto que motivó mi `MEJORAR_PLAN` sobre P-23 desaparece. Cuando P-23 quita la glosa, ya no queda ninguna marca ajena a Windows sin su motivo (verificación 5 de §1). Mi objeción a P-23 queda atendida si el orden se respeta.

## 4. Resumen

| Parche | Voto | Reversible | Peor caso si sale mal | Condición |
|---|---|---|---|---|
| P-01 (rev. 2) | APLICAR | Sí | Una marca con un motivo equivocado (S3, local) | Listado clasificado sobre la guía real después de P-23, con 0 fuera de clase; arrastre de P-16 por `checks.py` |
| P-19 (rev. 2) | APLICAR | Sí | Una línea de historial desalineada | Mismo arrastre 224/223; si P-01 o P-23 no entran, se quita «motivo por defecto…» |

Vetos: ninguno. Escaladas: ninguna (no se cumple ninguno de los siete disparadores de §6).
