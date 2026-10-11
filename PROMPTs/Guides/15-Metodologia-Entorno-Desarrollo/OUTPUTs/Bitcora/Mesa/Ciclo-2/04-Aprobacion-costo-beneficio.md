# Mesa · Ciclo 2 · 04 — Aprobación: juez de costo-beneficio

> Fecha: 2026-10-09. Marco: `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §5.5 (aprobación) y §6 (escalada). Insumo: `03-Parches.md` de esta carpeta y la guía 1.0.0-rc.1 (`LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md`, 3391 líneas, 53 363 palabras, sha256 `e7837762…52c4a1d9`).
> Función objetivo: ¿el costo de corregir (extensión, complejidad, riesgo de diluir) es menor al daño de no hacerlo? Chequeo obligatorio por parche: ¿corrige en la capa donde nació el defecto?

## 1. Comprobaciones propias antes de votar

| # | Qué | Cómo | Resultado |
|---|---|---|---|
| K1 | Los 21 parches de guía se aplican sobre la guía **actual** y el balance es el declarado | Copié `simulacion/gen.py` y `parches_guia.py` al scratchpad y los corrí con `GUIA=<guía real> python3 -I gen.py` (no toca el original) | `errores: []`; Δ por parche idéntico a §2 de `03-Parches.md`; **prosa −46, evidencia +950**, 53 363 → 54 267 palabras. La guía no cambió desde que el auditor midió. |
| K2 | La premisa más volátil del lote: Python 3.15.0 publicada (C2-29, P-06, P-18, P-20, O-10) | WebFetch a https://www.python.org/downloads/release/python-3150/ (consulta 2026-10-09) | «Release date: Oct. 9, 2026», «This is the stable release of Python 3.15.0», «PEP 686: Python now uses UTF-8 as the default encoding». [B205] se sostiene. |
| K3 | IDs de experimento que cita la Práctica integradora nueva (P-14) | `grep` sobre `guia-parcheada.md` | E2-2, E2-3, E3-1, E4-1, E4-4, E5-1, E5-6, E7-4 y E8-1 existen en el Anexo E; no se inventan experimentos. |
| K4 | Capa de origen de los hallazgos que **no** figuran en P-22 (C2-04, C2-10, C2-18, C2-19, C2-20, C2-22, C2-24, C2-27, C2-32…C2-39, lote S4 editorial) | `grep` en `Bitcora/Nucleos/` de `pre-receive`, `no impide`, `MSYS`, `2026-11-10` | Nacieron en la guía: los núcleos no tienen `pre-receive` ni `MSYS_NO_PATHCONV`, y N1 ya trae el fin de soporte de .NET 8 (EV1-33), que la guía omitió en A.3. Corregirlos en la guía es corregir en origen. |

## 2. Votos

| Parche | Voto | Fundamento (costo vs. daño · capa) |
|---|---|---|
| P-01 | APLICAR | Siete ops de metadatos, +11 de prosa; sin ellos la banda dice 204 fuentes con 217 definidas y el índice apunta a un Anexo F retitulado (ancla rota). Capa: guía. `version: 1.0.0` sólo al final y con el lote aprobado (§8 paso 7 de `03-Parches.md`): lo sostengo como condición. |
| P-02 | APLICAR | +72 de prosa en la puerta de entrada, pero cada op repara algo que el lector toca primero: los comandos de Windows se rompen sin `MSYS_NO_PATHCONV=1` [B209], el `DOCKER_CONFIG` vacío cambia `buildx` (X0) y «cinco marcas» contradice la tabla de cuatro. La regla de recorte con `…` es una línea y evita el defecto de C2-27 en adelante. Capa: guía. |
| P-03 | APLICAR | Resta 28 palabras y saca una línea `$ docker run` que no salió del experimento: daño de credibilidad alto, costo negativo. Capa: guía. |
| P-04 | APLICAR | +24 por una nota «decide / lidera» y un rótulo único; no reestructura la matriz (el alcance mínimo que voté en C2-22). Capa: guía. |
| P-05 | APLICAR | −115: quita la instrucción repetida y deja §3.7 P2/P5 en el concepto con remisión a §6.4; cierra C1-24 restando texto. Capa: guía. |
| P-06 | APLICAR | −74 y corrige dos afirmaciones falsas (cuantificador «siempre» de Python con contraejemplo; 3.15 como futuro, K2). La excepción del cp1252 que forma UTF-8 válido tiene E1 (CAT-FORMAL-02). Capa: guía; el origen en N1 lo cubre O-10. |
| P-07 | APLICAR | −26. La variante B ampliada evita que el caso heredado quede en violación al copiar A.1 (X5: 4 → 0); `chmod +x` desde Windows es una línea que hace que el hook exista. Capa: guía, con O-4 en N2. |
| P-08 | APLICAR | −93 y corrige la frase de pnpm, falsa para la 10 con E1 (AH-001-01) [B206]; concentra el costo de `disable` en §6.4 (dedup). Capa: guía, con O-3 en N3. |
| P-09 | APLICAR | +36 justificado: el lock se perdía en `WinExe`, el tipo de proyecto del caso, con CI verde [B215]. Voté «bajar el tono» en C2-03; el jurado fue 3-1 por la compuerta y el auditor la acota a «sólo si `--locked-mode` pasó» con su límite **[criterio]** y X3 sin regresión, así que el costo de mantenimiento que temía queda medido. Capa: guía, con O-1 y O-2 en N4 y L1 en el laboratorio. |
| P-10 | APLICAR | −9 de prosa; abre el camino barato para 8a (runner alojado, [B216]) y declara con honestidad lo no verificado (Renovate y el digest de `container:`) en vez de afirmarlo. `safe.directory` acotado a `${containerWorkspaceFolder}` tiene E1 (X4). Capa: guía, con O-5 en N5. |
| P-11 | APLICAR | −167: §9.2.4 baja de 931 a 599 palabras sin perder la tabla (va intacta a §9.3) y reemplaza un **[no verificado]** por `builder-id=` [B208] con E1 (AH-002). `GITHUB_ENV` [B212] arregla un paso que no surtía efecto. Es la mejor relación costo-beneficio del lote. Capa: guía, con O-6 y O-7 en N6. |
| P-12 | APLICAR | 27 ops pero −34 de prosa. **C2-05 por síntesis**: la acepto. Yo había votado A (editorconfig-checker por defecto); la síntesis toma lo barato de A (retirar `verificar.sh` como copiable, editorconfig-checker como reemplazo declarado) sin reabrir C1-08 —evita el disparador 7— y la compuerta reparada pasa X2 y X3 sin cambio de veredicto. El empate no persiste tras esta propuesta, así que no hay disparador 6. Corrige además dos afirmaciones absolutas falsas (qué no impiden un chequeo requerido [B177] y un `pre-receive` [B214]). Capa: guía, con O-8 y O-9. |
| P-13 | APLICAR | −110. `--provenance=…,version=v1` vuelve verdadera la promesa SLSA v1 (X5, rc=0); el extracto literal de `verificar.sh` reemplaza uno parafraseado. Respeta la prohibición del reemplazo global de «registro» (§9 de `03-Parches.md`). Capa: guía, con L5–L7 en el laboratorio. |
| P-14 | APLICAR | +128 de prosa, el segundo crecimiento del lote, pero compensado por el saldo total (−46) y sin experimentos nuevos (K3). El daño de no hacerlo es alto: el paso 7 de la hoja de ruta exigía imagen propia aunque 8a no la necesita, y el contrato no validaba los pasos 1, 2, 8–10. Capa: guía. |
| P-15 | APLICAR | Mayor costo (+278 prosa, +506 plantillas), pero son plantillas **copiables** que hoy fallan al copiarse: A.12 sin `packages: read`/`credentials` no baja una imagen privada (default de GHCR [B210]), A.4b deja fuera a `WinExe`, A.10 no instala `EditorConfig` (CI siempre roja), A.11 traía un `verificar.sh` que da «texto: OK» ante cp1252. Cada bloque coincide byte a byte con el `repo/` de X7, que corre EA-1 de diez pasos con rc=0. La variante de runner alojado va rotulada Ilustrativo **[no verificado]**: correcto. Capa: guía + laboratorio (P-23 L3). |
| P-16 | APLICAR | +78 en listas por actor; repara el lugar donde cada actor busca su tarea (dos defensas, `GITHUB_ENV`, modo `100755`, sin digest en el devcontainer). Saca del Anexo B una contradicción con la decisión C1-21 ya aplicada. Capa: guía. |
| P-17 | APLICAR | +92 de glosario es el alcance mínimo de C2-35 (fijar términos sin renombrado masivo); evita reescribir 99 apariciones con riesgo de romper anclas. Capa: guía. |
| P-18 | APLICAR | Trece filas de bibliografía sin las cuales las afirmaciones nuevas de los otros parches quedarían sin evidencia; prosa +8. Verifiqué la más volátil (K2). Capa: guía. Va antes que los demás (orden de §8). |
| P-19 | APLICAR | +12; alinea el Anexo E con lo que los experimentos realmente prueban (pnpm 12/`pmOnFail`, EA-1 ampliado). Capa: guía. |
| P-20 | APLICAR | +36; trazas que no resolvían (R-03, P-09) anulaban el anexo, y quita del pendiente lo que ya se verificó (`builder.id`, Python 3.15.0). Capa: guía. |
| P-21 | APLICAR | −165, el mayor ahorro: celdas breves con detalle debajo. Sólo con el lote aprobado. Capa: guía. |
| P-22 | APLICAR | Es el parche de capa de origen: once notas de solo agregado, Δ 0 en la guía, reversible por instantánea, con evidencia citada. Sin él, el próximo ciclo re-derivaría desde núcleos que siguen diciendo lo que se corrigió. Observación menor, no bloqueante: O-5 dice que el digest de `container:` lo mueve el workflow que publica **[criterio]**; la guía (P-10) agrega «Renovate lo reconoce [B213], que lo mueva **[no verificado]**». Son compatibles; conviene que O-5 nombre [B213] al aplicarse, sin cambiar el voto. |
| P-23 | APLICAR | Costo alto (re-correr N7, EA-1 y E8-6), pero el laboratorio **es** la capa de origen de varios defectos (`registrar-entorno.sh` con `desconocida`, `compuerta.sh` ciega a subcarpetas, comando sin `version=v1`), y la guía cita sus salidas: aplicar la guía sin el laboratorio dejaría citas a salidas que no existen. Riesgo acotado por las condiciones que sostengo: instantánea de `Examples/` con `sha256sum` antes de tocar (no está bajo git) y, si una corrida no da lo esperado, el op de guía que la cita no se aplica y vuelve como `regresión` (marco §5.6). |

## 3. Resumen

- **APLICAR: 23 de 23.** MEJORAR_PLAN: 0. NO_APLICAR: 0. ESCALAR: 0.
- **Capa de origen**: todos corrigen donde nació el defecto; los que nacieron en núcleos o en la bitácora del ciclo 1 llevan su nota en P-22, y los del laboratorio, su op en P-23 (K4).
- **Presupuesto (C2-36)**: saldo de prosa −46, reproducido (K1); lo que crece son plantillas probadas y fuentes. Cumple el criterio votado (Δ por parche y saldo de prosa ≤ 0, sin tope duro).
- **Sin escalada**: ningún parche cambia el alcance de la guía (disparador 3), reabre una decisión cerrada (7: la síntesis de C2-05 la preserva) ni toca consecuencias externas (5). El empate de C2-05 se resuelve con la síntesis, no persiste tras dos rondas (6).
- **Condiciones que acompañan el voto** (no cambian ningún APLICAR): orden de §8 de `03-Parches.md` (instantánea → P-22 → P-18 → P-23 → resto → P-01/P-21 al final); re-correr sobre la guía real los chequeos mecánicos de §8 paso 6; O-5 con [B213].
- **Supuesto registrado**: la fecha de trabajo es 2026-10-09 (la de la bitácora y del sistema); la consulta de K2 es de ese día.
