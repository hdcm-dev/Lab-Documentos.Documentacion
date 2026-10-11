---
doc_id: BIT-15-README
doc_type: indice-de-bitacora
title: Bitácora de la mesa — Metodología del entorno de desarrollo
status: vigente
origin: agent
last_review: 2026-10-09
audience: [PO, próxima corrida de la mesa]
traces: [PROMPT-15, BIT-15-00, BIT-15-05]
---

# Bitácora — Metodología del entorno de desarrollo

Este es el cuaderno de trabajo de la mesa evaluadora que produjo la guía [`Metodologia-Entorno-Desarrollo-Guide.md`](../../../../../../Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md) (1.1.0, vigente). Ese archivo, `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md`, es el único entregable. Su laboratorio está en `…/Metodologia-Entorno-Desarrollo/Examples/`.

La guía no remite a la bitácora, porque es autocontenida. La bitácora, en cambio, sí remite a la guía y al laboratorio. Lo que hay acá son borradores, apuntes, debates e informes verbatim. Sirven para retomar el trabajo o auditar cómo se llegó a cada decisión. No son material de estudio.

- **Prompt del PO** (sólo lectura): `../../Crear-Analizar-Metodlogia-Entorno-Desarrollo.md`.
- **Prompt reeditado** sobre el marco de mesa: [`../Metodlogia-Entorno-Desarrollo.md`](../Metodlogia-Entorno-Desarrollo.md).
- **Marco**: `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md`.

## Si tenés poco tiempo

1. [`05-Cierre.md`](05-Cierre.md): versión final, cifras, deuda declarada, capas a revalidar y la trazabilidad de cada solicitud del PO a su sección de la guía.
2. [`00-Contrato-De-Entrada.md`](00-Contrato-De-Entrada.md): qué se prometió, con qué restricciones y con qué supuestos.
3. El `05-Aplicacion.md` del último ciclo ([`Mesa/Ciclo-3/05-Aplicacion.md`](Mesa/Ciclo-3/05-Aplicacion.md)): qué entró, qué se revirtió y qué quedó abierto.

## Orden de lectura completo

La bitácora sigue el orden en que se trabajó. Primero el análisis del pedido (00–04), después los tres ciclos de la mesa y al final el cierre (05).

### Fase 1 · Análisis y construcción (2026-10-07)

| Archivo | Qué es |
|---|---|
| [`00-Contrato-De-Entrada.md`](00-Contrato-De-Entrada.md) | Contrato de la mesa (marco §2): objeto, objetivo, restricciones duras (R-PO-*, R-PRIV, R-EVID…), decisiones cerradas DC-01…DC-07, fuera de alcance, umbral (S1 y S2 bloquean), `ciclos_max: 3`, escala de evidencia aplicada a una guía y supuestos SUP-01…SUP-06. |
| [`01-Descomposicion-Conceptual.md`](01-Descomposicion-Conceptual.md) | Descomposición del pedido en los núcleos N0…N8 y por qué se agrupó así. |
| [`02-Cohesion-Global.md`](02-Cohesion-Global.md) | Grafo de dependencias entre núcleos, lo que cada uno le entrega a los demás, las contradicciones previsibles, la trazabilidad pedido → núcleo → sección, la estructura prevista de la guía y las comisiones propuestas. |
| [`03-Marco-De-Referencia.md`](03-Marco-De-Referencia.md) | Escenarios ESC-01…05, contextos CTX-NET/NODE/PY/POLI y actores ACT-DEV/ARQ/OPS/REV. Pasaron a §2 de la guía. |
| [`Nucleos/`](Nucleos/) | Un registro por núcleo, con definición, investigación, fuentes y experimentos: [N0 capas](Nucleos/N0-modelo-de-capas-y-reproducibilidad.md), [N1 codificación y EOL](Nucleos/N1-codificacion-y-finales-de-linea.md), [N2 política de texto](Nucleos/N2-politica-de-texto-y-remediacion.md), [N3 toolchain](Nucleos/N3-fijacion-del-toolchain.md), [N4 dependencias](Nucleos/N4-congelamiento-de-dependencias.md) (con `N4-salidas/`), [N5 contenedores](Nucleos/N5-entornos-en-contenedores.md), [N6 procedencia](Nucleos/N6-procedencia-y-trazabilidad.md), [N7 compuertas](Nucleos/N7-compuertas-y-gobierno.md) y [N8 solución políglota](Nucleos/N8-integracion-poliglota.md). Cada núcleo es un capítulo de la guía (N0 → §3 … N8 → §11). Las «Correcciones mesa ciclo n» al pie de los bloques son notas de solo agregado que la mesa dejó en la capa de origen. |
| [`04-Integracion.md`](04-Integracion.md) | Integración de los núcleos en la guía 1.0.0-borrador: dependencias resueltas, contradicciones entre núcleos, reparaciones en origen, modelo reconstruido, unificación de IDs y trazabilidad pedido → sección. |

### Fase 2 · Mesa evaluadora: tres ciclos sobre la guía completa (2026-10-07 a 2026-10-09)

Los tres ciclos tienen las mismas piezas, en este orden:

| Paso | Archivo en `Mesa/Ciclo-n/` | Qué es |
|---|---|---|
| 0 | `00-Convocatoria.md` (sólo ciclo 1) | Barrido de señales, votación del catálogo, cartas de AH-001 (Node.js y Python), AH-002 (cadena de suministro y CI) y CAT-FORMAL, descartados y apartamiento del techo del panel. Los ciclos 2 y 3 reconvocaron el mismo panel. |
| 1 | `Informe-<rol>.md` y `evidencia-<rol>/` | Informes verbatim de los doce especialistas: requisitos, verificacion-evidencia, lector-sin-contexto, didactica, edicion-bibliografica, senior-dotnet, arquitecto-software, desarrollador, adhoc-AH-001, adhoc-AH-002, adhoc-CAT-FORMAL y abogado-del-diablo. Cada uno trabajó a ciegas respecto de los demás. |
| 2 | `01-Consolidado.md` | El relator deduplica y agrupa: ítems para el jurado (C*n*-NN), contradicciones, lote S4, preguntas de nivel C y solicitudes de convocatoria. |
| 3 | `02-Voto-<juez>.md` | Veredicto por ítem de los cinco jueces (evidencia, impacto, costo-beneficio, coherencia histórica, riesgo), cada uno con su fundamento. |
| 4 | `03-Parches.md` y `evidencia-auditor/` | Parches del cuerpo auditor, con texto exacto, Δ de palabras, capa de origen y criterio de verificación. La forma ejecutable está en `evidencia-auditor/simulacion/`. |
| 5 | `04-Aprobacion-<juez>.md`, `04b-…` (2.ª vuelta, ciclos 1 y 3) y `evidencia-aprobacion-*/` | Mesa de decisión sobre los parches: `APLICAR`, `MEJORAR_PLAN`, `NO_APLICAR` o `ESCALAR`. |
| 6 | `05-Aplicacion.md` y `aplicacion/` | Aplicación y verificación: changelog hallazgo → parche → versión, regresiones revertidas, chequeos mecánicos, deuda que queda y supuestos. En `aplicacion/` están los guiones, las instantáneas previas y los registros de cada corrida. |

| Ciclo | Versión resultante | Hallazgos / ítems / parches | Lo que conviene leer primero |
|---|---|---|---|
| [`Mesa/Ciclo-1/`](Mesa/Ciclo-1/) | 1.0.0-borrador → 1.0.0-rc.1 | 72 / 48 / 24 (2 ítems revertidos) | [`00-Convocatoria.md`](Mesa/Ciclo-1/00-Convocatoria.md), [`05-Aplicacion.md`](Mesa/Ciclo-1/05-Aplicacion.md) §8 (deudas D-1…D-7) |
| [`Mesa/Ciclo-2/`](Mesa/Ciclo-2/) | 1.0.0-rc.1 → 1.0.0 (vigente) | 70 / 40 / 23 | [`05-Aplicacion.md`](Mesa/Ciclo-2/05-Aplicacion.md) §6 (lo que no se aplicó) |
| [`Mesa/Ciclo-3/`](Mesa/Ciclo-3/) | 1.0.0 → 1.1.0 (vigente) | 57 / 35 / 25 (R-1 revertida) | [`05-Aplicacion.md`](Mesa/Ciclo-3/05-Aplicacion.md) §3 y §6 |

`Mesa/Ciclo-1/instantanea-origen-2026-10-09/` y las carpetas `aplicacion/instantanea-origen/` son copias de la capa de origen tomadas antes de escribirle notas. Se guardan para poder revertir. No se leen como estado vigente.

### Fase 3 · Cierre (2026-10-09)

| Archivo | Qué es |
|---|---|
| [`05-Cierre.md`](05-Cierre.md) | Bloque `cierre` del marco (§7), ampliado con los campos del prompt reeditado (§13). Incluye la verificación final, la trazabilidad solicitud del PO → sección de la guía y los apartamientos que se informan al PO. |

## Correspondencia con los nombres que preveía el prompt reeditado

El prompt reeditado (§11) proponía una numeración `BIT/10-…` a `BIT/29-Cierre.md`. La corrida usó carpetas por núcleo y por ciclo. Esta tabla da la equivalencia:

| Salida del prompt reeditado §11 | Dónde quedó |
|---|---|
| `10-N0-…` … `18-N8-…` (registro por núcleo) | `Nucleos/N0-…md` … `Nucleos/N8-…md` |
| `19-Integracion.md` | `04-Integracion.md` |
| `20-Convocatoria.md` | `Mesa/Ciclo-1/00-Convocatoria.md` |
| `21-Informes-Panel-Ciclo-<n>.md` | `Mesa/Ciclo-<n>/Informe-<rol>.md` (uno por rol) |
| `22-Relatoria-Ciclo-<n>.md` | `Mesa/Ciclo-<n>/01-Consolidado.md` |
| `23-Veredictos-Ciclo-<n>.md` | `Mesa/Ciclo-<n>/02-Voto-<juez>.md` y `04*-Aprobacion-<juez>.md` |
| `24-Parches-Ciclo-<n>.md` | `Mesa/Ciclo-<n>/03-Parches.md` |
| `25-Changelog.md` | §2 o §4 de cada `Mesa/Ciclo-<n>/05-Aplicacion.md`, y el «Control de cambios» de la guía |
| `26-Relectura-Integral.md` | Los tres ciclos de `Mesa/`, cada uno sobre la guía completa |
| `27-Debates-y-Apuntes.md` | Contradicciones de cada `01-Consolidado.md`, los votos con fundamento y las carpetas `evidencia-*/` |
| `28-Escaladas.md` | No existe: no hubo escaladas |
| `29-Cierre.md` | `05-Cierre.md` |

## Convenciones

- **Evidencia.** Niveles E1–E4 y C, y severidades S1–S4, como las define `00-Contrato-De-Entrada.md` §3. «L*n*» es el número de línea de la guía **en la versión que juzgaba ese ciclo**, no en la final.
- **IDs estables.** `C<ciclo>-NN` son ítems de jurado; `C<ciclo>-Qnn`, preguntas de nivel C; `P-NN`, parches (la numeración vuelve a empezar en cada ciclo); `D-n`, la deuda del ciclo 1; `R-1`, la regresión del ciclo 3.
- **Solo agregado.** Las correcciones a documentos de ciclos anteriores se agregan como notas fechadas («Corrección mesa ciclo n» o «Nota de solo agregado») y no reescriben el texto original.
- **Privacidad.** El caso disparador viene de un repositorio privado. Acá se describe de forma genérica y se reproduce con un ejemplo sintético. Los identificadores privados sólo aparecen dentro de los comandos `grep` que los buscan.
- **Sin commit.** Nada de esto se commiteó ni se subió.
