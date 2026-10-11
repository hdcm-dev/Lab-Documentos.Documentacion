# Mesa · Ciclo 2 · 04 — Aprobación: juez de riesgo e irreversibilidad

> Fecha: 2026-10-09. Marco: `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §5.5 (aprobación) y §6 (escalada). Insumo: `03-Parches.md` de esta carpeta, la guía 1.0.0-rc.1 (3391 líneas, `sha256 e7837762…52c4a1d9`) y `evidencia-auditor/`.
> Función objetivo: ¿la corrección es reversible? ¿qué se rompe en la guía si sale mal? Veto sólo si es irreversible y la severidad es S3 o menor.
> Resultados posibles por parche: `APLICAR` · `MEJORAR_PLAN` · `NO_APLICAR` · `ESCALAR`. Chequeo obligatorio: ¿corrige en la capa de origen?

## 1. Lo que verifiqué yo, no lo que dice el auditor

No tomé los chequeos de `03-Parches.md` §8 por buenos: los volví a correr sobre una copia, en el scratchpad de la sesión, sin tocar la guía ni el laboratorio.

| # | Qué | Comando (resumido) | Resultado |
|---|---|---|---|
| R1 | Los 21 parches aplican sin anclas ambiguas y dan la misma guía que la simulación del auditor | `GUIA=<copia> python3 -I gen.py` y `cmp` contra `evidencia-auditor/simulacion/guia-parcheada.md` | `errores: []`; Δ prosa −46, evidencia +950; 53 363 → 54 267 palabras; **IGUAL** byte a byte |
| R2 | Bibliografía | `[Bnn]` definidas vs. citadas, antes y después | 204 = 204 → 217 = 217; ninguna citada sin definir ni definida sin citar |
| R3 | Anclas internas | slugs de encabezados vs. `](#…)` | 91 vínculos, 0 rotos, antes y después |
| R4 | Experimentos | IDs `E*-*` y `EA-*` únicos | 79 antes, 79 después; 0 perdidos |
| R5 | Marcas de juicio | `**[criterio]**`, `**[no verificado]**`, `**[observado]**`, `**[interpretación]**` | 125 → 125; `[no verificado]` 38 → 34 (cuatro pasan a dato con fuente) |
| R6 | YAML | `yaml.safe_load_all` (PyYAML 6.0.3, `python:3.12-slim`) | 6/6 → 7/7 bloques válidos |
| R7 | Recorte de §9.2.4 (P-11) | palabras de la sección; filas de su tabla presentes en la guía parcheada; `[Bnn]` y E-IDs de la sección presentes | 592 palabras (≤ 600); 12/12 filas intactas; 0 referencias perdidas; vínculos a §9.2.4: 14 → 17 |
| R8 | Pines de acciones (P-15, A.12 variante) | `git ls-remote https://github.com/<repo> refs/tags/<v>` | `setup-dotnet` v6.0.0 `a98b5685…`, `setup-node` v7.1.0 `949feb24…`, `setup-python` v7.0.0 `5fda3b95…`, `setup-uv` v10.2.0 `c18668ad…`, `checkout` v7.0.1 `3d3c42e5…`: **5/5 coinciden** con la guía |
| R9 | Python 3.15.0 publicada (P-06, P-18, P-20) | `curl https://www.python.org/downloads/release/python-3150/` y `…/ftp/python/3.15.0/` | «Release date: Oct. 9, 2026»; «This is the stable release of Python 3.15.0»; «PEP 686: Python now uses UTF-8 as the default encoding»; existe `Python-3.15.0.tgz` |
| R10 | Plantillas de A.12, A.17 y A.18 = laboratorio propuesto (P-15, P-23) | bloque del Anexo A parcheado vs. archivo de `x7-ea1-propuesto/repo/` | 3/3 iguales byte a byte |
| R11 | Corridas que sostienen P-12, P-15 y P-23 | `tail` de `x7-ea1-propuesto/salida.txt` y `x3-regresion-n7/salida.txt` | EA-1 de diez pasos `rc=0`, paso 10 `"outcome":"success"`; E7-03 y E7-07 (Node y Python) «veredictos y códigos iguales» |
| R12 | Privacidad | `grep -ciE 'GDA\|SGM\|Notions\|BotonPanico\|Coordenada'` | 0 antes, 0 después |
| R13 | Digest en ESC-04 (C2-23) | filas `ESC-04` con «digest», antes y después | §6.4 y §9.4 dejan de pedirlo; queda en §11.4 «bases por digest» de la imagen de la CI (receta de A.10), que es donde corresponde |
| R14 | `safe.directory` (C2-11) | `grep` | acotado a `${containerWorkspaceFolder}`; ninguna aparición de `'*'` |
| R15 | `MSYS_NO_PATHCONV` (C2-10) | `grep` | «con `MSYS_NO_PATHCONV=1` delante»: prefijo por comando, no variable global, como pedí en el voto |

Una diferencia, encontrada y juzgada: `*Aplica*` pasa de 64 a 63. La que falta no es de una pregunta guía: está en la celda vieja de 1.0.0-rc.1 del control de cambios («una pregunta situada y su *Aplica* en cada capítulo»), que P-21 resume. Las preguntas de §3.7 conservan las cuatro (P-05 no deja ninguna sin *Aplica*).

## 2. Estado de reversibilidad

- La carpeta `Guides/Metodologia-Entorno-Desarrollo/` sigue **sin rastrear** en git (`git status --short` → `??`), y `Ciclo-2/aplicacion/` todavía no existe. No hay commit al que volver.
- Por eso la condición previa del voto (`02-Voto-riesgo.md`) sigue en pie y es la que vuelve reversible a **todo** el lote: antes del primer op, copiar la guía y `Examples/` a `Ciclo-2/aplicacion/antes/` con `sha256sum` (la guía hoy: `e7837762f3bafa5428cac969cd67a0d490d31f364732936f1878276752c4a1d9`). `03-Parches.md` §8 paso 1 la incorpora; la doy por **condición de aplicación**, no por recomendación.
- Con esa copia, todos los parches son ediciones de texto o de archivos del laboratorio, sin publicación ni efecto externo. Ninguno es irreversible. **No hay veto.**

## 3. Capa de origen

- P-01…P-21 corrigen la guía, que es donde está cada defecto de redacción, de plantilla o de cita.
- Los defectos que nacieron en los núcleos o en la bitácora del ciclo 1 se corrigen allí, en P-22, con notas de solo agregado.
- Los que nacieron en el laboratorio se corrigen allí, en P-23.
- Ningún parche maquilla en la guía un defecto que vive en otra capa. El chequeo pasa en los 23.

## 4. Veredictos

| Parche | Voto | Fundamento (riesgo) |
|---|---|---|
| P-01 | APLICAR, condicionado | El índice y `traces` cambian en la misma edición que el título del Anexo F (R3: 0 anclas rotas). `version: 1.0.0` y `status: vigente` son lo único del lote que **afirma** algo sobre el resto: se aplican al final y sólo si todos los demás parches entraron con su verificación en verde. Si alguno queda en regresión (marco §5.6), la guía sale como `1.0.0-rc.2` / `borrador`. |
| P-02 | APLICAR | Reversible y local a §0. El `DOCKER_CONFIG` temporal conserva `cli-plugins`, así que no rompe §8.5 ni E5-2 (X0: v0.35.0 con el enlace, 0.13.1 sin él). `MSYS_NO_PATHCONV=1` va como prefijo y queda **[no verificado]** (R15). «Cuatro marcas de juicio» coincide con la tabla de §0.3. |
| P-03 | APLICAR | Reemplaza una salida reconstruida por la literal de E1-01, con omisiones marcadas. Baja el riesgo de que el lector compare contra una línea que nunca existió. Sin cambios de comando. |
| P-04 | APLICAR | Local a la matriz de §2.4 y a las filas ESC-01. El rótulo único se reemplaza por fila (R1 no encontró anclas ambiguas) y las celdas *Aplica* citan pasos de §12 que existen. |
| P-05 | APLICAR | Recorte de −115 palabras sin pérdida de *Aplica* en §3.7 (§1, nota final) ni de referencias (R2, R4). P2 remite a §7.2.1 en lugar de repetir E4-2, que sigue completo allí. |
| P-06 | APLICAR | La afirmación más expuesta del parche, Python 3.15.0 publicada el 2026-10-09, la confirmé en la fuente (R9). La condición de plataforma pasa a Roslyn y Python lleva su excepción, con E1 (CAT-FORMAL-02). Se califica por versión, sin volver a fechar la guía, como voté en C2-29. |
| P-07 | APLICAR, condicionado | La variante B ampliada está probada (X5: 4 → 0 violaciones con los `Directory.Build.*` con BOM). El `chmod +x` desde Windows queda **[no verificado]**. Condición: el op de §5.5 «25 archivo(s)» entra sólo si EA-1 paso 1 rehecho en el laboratorio (P-23 L4) vuelve a dar 25. |
| P-08 | APLICAR | Las afirmaciones nuevas tienen fuente de primera mano (B206, B207, B56) o E1 (AH-001-01). El costo de `disable` queda en un solo lugar, §6.4: menos superficie para contradicciones futuras. ESC-04 deja el digest sólo donde se construye lo publicado (R13). |
| P-09 | APLICAR | Las dos defensas contra `NU1603` cambian juntas en §6.4, §7.2.1, A.4 y A.4b, que era la condición de mi voto en C2-01. `WinExe` tiene fuente (B215) y E1 (EA-1 paso 2c). Los mensajes de §7.3 van **[observado]** con versión y el Anexo F los declara sin script. Es deuda, pero declarada. |
| P-10 | APLICAR | Renovate queda **[no verificado]** (B213 no documenta mover el digest): no se cambia un defecto por una afirmación sin probar. El camino del runner alojado va rotulado. buildx v0.35.0 queda declarado. |
| P-11 | APLICAR | Era el recorte de mayor riesgo del lote (931 → 599 palabras). Lo medí: 592 palabras, la tabla de plataformas pasa intacta a §9.3, 0 referencias perdidas y 0 anclas rotas (R3, R7). `builder-id=` tiene E1 y fuente (B208). `GITHUB_ENV` tiene fuente (B212). `actions/attest` queda **Ilustrativo**. |
| P-12 | APLICAR, condicionado | Retirar `verificar.sh` como pieza copiable es la salida de menor radio de rotura. Reparar la compuerta propia sigue la dirección B que voté en C2-05. Acepto la **síntesis** de §1.1: no reabre C1-08, deja editorconfig-checker como reemplazo declarado y no cambia el veredicto de ningún experimento de N7 (R11). Con eso, el empate 2-2 queda resuelto y no es persistente (marco §6.6). Condición: los ops de compuerta (descubrimiento con `git ls-files`, `requested` = `resolved`, «falta el paquete EditorConfig») entran sólo después de que P-23 L1 y L2 corran en `Examples/` y reproduzcan X3 y X6. |
| P-13 | APLICAR, condicionado | Sin renombrado global de «registro» (era mi condición en C2-35): sólo las ocurrencias señaladas. Los bloques que copian archivos del laboratorio no se tocan. `version=v1` tiene E1 (X5). Condición: el op de §11.5 entra sólo si `comando-de-la-guia.sh` del laboratorio (P-23 L7) vuelve a dar `https://slsa.dev/provenance/v1`; si no, la frase baja a **[no verificado]**. |
| P-14 | APLICAR | §12 es el lugar de mayor radio de rotura de la guía, porque todo remite allí. El contrato YAML nuevo valida (R6). No abre experimentos nuevos. El camino 8a por runner alojado queda rotulado como no ejecutado (requiere GitHub). |
| P-15 | APLICAR | Es la pieza copiable con más riesgo: lo que el lector pega en su repo. Lo que el laboratorio puede probar está probado: EA-1 de diez pasos `rc=0`, y A.12, A.17 y A.18 iguales byte a byte al repo de X7 (R10, R11). Lo que no puede probar está rotulado: `packages: read` y `credentials` sin corrida en GitHub, y la variante de runner alojado como **Ilustrativo [no verificado]**. Sus cinco pines por SHA los comprobé (R8). |
| P-16 | APLICAR | B.2 y B.4 sólo repiten lo que ya aplican P-07, P-09 y P-15, sin afirmaciones propias. Si uno de esos parches no entra, el ítem correspondiente de B se retira con él. |
| P-17 | APLICAR | Es aditivo: entradas nuevas del glosario. No hay renombrado. Rotura nula. |
| P-18 | APLICAR | Va primero en el orden (§8 paso 3), así que ninguna `[B2nn]` queda citada sin definir (R2). Las fuentes son oficiales y fueron consultadas el 2026-10-09. Comprobé de nuevo B205 (R9) y B217 (R8). |
| P-19 | APLICAR, condicionado | Las filas del Anexo E describen EA-1 con los pasos 1c, 2c, 8, 9 y 10: entran cuando P-23 L4 deje `salidas/EA-1-plantillas.txt` con esos pasos. Antes, el anexo describiría un experimento que el laboratorio no tiene. |
| P-20 | APLICAR | Corrige R-03 y P-09 de la tabla de trazas. Los datos volátiles declaran sus dos fechas. Quitar el pendiente de `builder.id` está respaldado por E1. Rotura nula: R3. |
| P-21 | APLICAR | Resumir la celda de 1.0.0-rc.1 pierde detalle por sección del ciclo 1, y con él una mención de *Aplica* (§1). No es evidencia ni cita: ese detalle sigue completo y versionado en `Mesa/Ciclo-1/` (`03-Parches.md`, `05-Aplicacion.md`). Lo acepto como pérdida reversible y recuperable. No es el recorte de evidencia que vetaría (C2-36). |
| P-22 | APLICAR | Son notas de solo agregado sobre una instantánea previa. La verificación es `diff` con 0 líneas `<`. Es la corrección en la capa de origen que pide el marco §5.5. La nota O-8 cita la síntesis de C2-05, que apruebo en P-12; si la mesa la rechazara, O-8 no se inserta. |
| P-23 | APLICAR, condicionado | Tiene el costo más alto del lote: hay que volver a correr EA-1 completo, N7 y E8-6. Es reversible con la copia de `Examples/` (§2). Cada cambio llega con su fuente probada en `evidencia-auditor/` (R10, R11). Condición, que ya figura en §8 paso 4: si una corrida no da lo esperado, el op de la guía que la cita no se aplica y vuelve a auditoría como `regresión`. El `registrar-entorno.sh` de A.17 se versiona con modo `100755` (`git update-index --chmod=+x`), no con el bit del sistema de archivos. |

## 5. Condiciones de aplicación (vinculantes)

1. **Instantánea** de la guía y de `Examples/`, con su `sha256sum`, antes del primer op (§2). Sin ella no se aplica nada.
2. **Orden** de `03-Parches.md` §8: P-22 → P-18 → P-23 (con sus corridas) → P-01…P-21 → control de cambios y `version` al final.
3. **Gating por corrida**: P-07 (§5.5), P-12 (compuerta), P-13 (§11.5) y P-19 entran sólo si la corrida de P-23 que los sostiene da lo esperado.
4. **Versión**: `1.0.0` / `vigente` sólo si los 23 parches entraron. Si no, `1.0.0-rc.2` / `borrador`, y el control de cambios lo dice.
5. **Re-correr sobre la guía real** los chequeos R1–R7, R12 y R13 después de aplicar. El resultado tiene que coincidir con el de la copia.

## 6. Escaladas

Ninguna. Ninguno de los siete disparadores de §6 aparece:

- El único empate (C2-05) lo resuelve la síntesis, que no reabre una decisión cerrada.
- No hay cambio de alcance.
- Ninguna corrección es irreversible.
- No hay dominio con consecuencia externa: no se publica ni se commitea.

## 7. Resumen

| Voto | Parches |
|---|---|
| APLICAR | P-02, P-03, P-04, P-05, P-06, P-08, P-09, P-10, P-11, P-14, P-15, P-16, P-17, P-18, P-20, P-21, P-22 |
| APLICAR, condicionado | P-01 (versión al final), P-07, P-12, P-13, P-19, P-23 (gating por corrida) |
| MEJORAR_PLAN | — |
| NO_APLICAR | — |
| ESCALAR | — |
