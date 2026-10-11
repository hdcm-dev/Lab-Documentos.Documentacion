# Mesa · Ciclo 3 · 04 — Aprobación: juez de riesgo e irreversibilidad

> Fecha: 2026-10-09. Rol: juez de riesgo de la mesa de aprobación (marco `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §5.3, §5.5 y §6).
> Insumos: `03-Parches.md` de esta carpeta (P-01 a P-25), la guía 1.0.0 (`LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md`, sha256 `a2b78179b250…`, sin cambios) y la simulación del auditor (`evidencia-auditor/simulacion/guia-parcheada.md`, `gen-salida.txt`: 23 parches, `fallas=0`).
> Preguntas que me tocan: ¿la corrección se puede revertir? ¿Qué se rompe en la guía si sale mal? Veto sólo si es irreversible y S3 o menor.

## 1. Criterio general

- **Reversibilidad.** Todos los parches son ediciones de un `.md`, notas de solo agregado en la bitácora o cambios del laboratorio con instantánea previa. Se revierten con una edición inversa o restaurando la instantánea. Ninguno es irreversible, así que **no hay veto** en esta mesa.
- **Radio de impacto.** El riesgo real está en tres lugares: (a) los parches que mueven el laboratorio (P-13 con P-25) cambian digests y hashes que la guía cita; (b) los que cambian una regla de lectura de toda la guía (P-01 en §0.3, P-23) alteran el sentido de marcas que no tocan; (c) las cifras de la apertura (P-01) dependen de que P-16 y P-17 entren completos.
- **Capa de origen.** Los parches P-01 a P-23 corrigen la guía, donde vive el texto que falla, y P-24 agrega las notas en los núcleos y en la bitácora de los ciclos 1 y 2, donde nacieron las reglas que se acotan (O-1 a O-11). P-25 corrige el laboratorio, que es la capa de las plantillas y las salidas. Ningún parche corrige sólo el síntoma dejando el origen intacto.
- **Escalada.** Ningún parche dispara alguno de los siete casos de §6. El saldo de prosa (+493 contra el ≤ 0 de C2-36) es una regla que la mesa se dio en el ciclo 2, no una restricción dura del contrato del PO, y no hay conflicto entre restricciones (§6, caso 2): se decide acá (§4).

## 2. Lo que encontré al verificar

**La marca por defecto de P-01 y P-23 vuelve falsas a tres marcas que esos parches no tocan.** P-01 escribe en §0.3: «Sin motivo escrito, **[no verificado]** quiere decir «requiere Windows» (§0.4)», y P-23 quita la glosa de las ocho apariciones que sí eran de Windows. Pero en la guía parcheada hay **[no verificado]** sin motivo escrito que no tienen que ver con Windows:

- L1027, tabla de gestores de versiones, fila `asdf` (dos celdas): no se probó asdf, que no corre en Windows.
- L1411, §8: «Renovate lo reconoce [B213], pero que mueva su digest **[no verificado]**»: falta una plataforma alojada, no Windows.
- L539, §4: «no se encontró un documento de .NET que recomiende o desaconseje el BOM en `.cs` **[no verificado]**»: es una ausencia de fuente.

Con la regla nueva, un lector o un agente que aplique §0.3 al pie de la letra lee «requiere Windows» en esas tres. El chequeo de P-23 (`grep -c '(requiere Windows)'` → 0) no lo detecta, porque mide la glosa y no el sentido. Es reversible y de severidad baja (S3: una marca que dice un motivo equivocado). Por eso no es veto, sino `MEJORAR_PLAN`. La corrección es chica: antes de la regla, a cada **[no verificado]** sin motivo que no sea de Windows se le agrega el suyo, o la regla se reemplaza por la de 1.0.0 («se dice qué faltaría para verificarla»). El criterio de verificación tiene que listar todas las marcas sin motivo de la guía parcheada y clasificarlas, no contar la glosa.

**El resto de las condiciones que dejé en el voto del ciclo 3 (`02-Voto-riesgo.md`) está cumplido:**

- C3-01: hay una definición única en §8.2.2, y la cobertura de §7 del documento de parches muestra que las remisiones salen de P-08 a P-14.
- C3-03: lo nativo se conserva como **[interpretación]** en §9.6 (P-09, op. 6).
- C3-15: `paths` va con **[no verificado]** para Visual Studio (P-06, op. 3).
- C3-26: `owners.py` se re-corrió sobre el CODEOWNERS nuevo (X6).
- C3-27: la línea del consumidor sigue «Ilustrativo» (P-09).
- C3-34: las fechas salen de la medición X7, no de una estimación.
- C3-35: Δ medido con `wc -w`, 183 anclas, 0 enlaces rotos. La tesis de Visual Studio sale del cierre de §12 y queda como advertencia en §8.2.4 y en las filas ESC-01 de §10.3 y §11.3, con su **[no verificado]**.

## 3. Votos por parche

| Parche | Voto | Fundamento (riesgo) |
|---|---|---|
| P-01 | MEJORAR_PLAN | Versión 1.1.0, cifras, fecha del Anexo E, §0.2 y ruta mínima: se aprueban como están. La objeción es una sola oración, la de §0.3: «Sin motivo escrito, **[no verificado]** quiere decir «requiere Windows»» deja con un motivo falso las marcas de L539, L1027 (dos) y L1411 (§2). Reformular: dar su motivo a esas marcas, o volver a la regla de 1.0.0. Si P-16 o P-17 no entran, se vuelven a contar «224» y «74». |
| P-02 | APLICAR | Una celda; se revierte sin costo y no mueve ninguna ancla. |
| P-03 | APLICAR | Compresión con el ancla nueva `#821-…` verificada (0 enlaces rotos). La fila de capa 6 apunta a A.17 y A.18, que existen. Si sale mal, sólo se pierde una tabla de consulta que §8.2.1 conserva. |
| P-04 | APLICAR | Acota tres afirmaciones con evidencia ([B220], E8-1 rc=2, X3). Condición de §8 del auditor: E1-11 con Node (L-04) se versiona antes de aplicar. |
| P-05 | APLICAR | Corrige un snippet que cerraba la terminal del lector. El guardián nuevo se probó en `bash -i` (X4) y la tabla de BOM se apoya en X2 y [B222]. Condición: E2-6 ampliado (L-03) versionado antes. |
| P-06 | APLICAR | Corrige una recomendación que en los SDK de la guía no hace nada (MSB4057 en 8.0.425 y 10.0.400; el target existe en 11.0.100-rc.1, según `evidencia-senior-dotnet/checksdkvuln.txt`). `paths` va con **[no verificado]** y se puede retirar sin rastro. No reabre C1-03: el lock por defecto queda rotulado **[criterio]**. |
| P-07 | APLICAR | Un destino explícito (`src/App`) que evita MSB1003, probado por desarrollador-04. |
| P-08 | APLICAR | Es el parche con mayor radio: cambia la definición de la que dependen quince remisiones. Las remisiones salen todas de este mismo lote, se revierten en bloque y la simulación no deja anclas fallidas. «Detecta», no «garantiza», reduce una promesa. Condición: E5-8 (L-02) versionado antes de aplicar, porque la definición lo cita. |
| P-09 | APLICAR | Quitar el `AssemblyMetadata` es lo más fácil de revertir. La verificación de `gh` endurece una línea marcada «Ilustrativo». El metadato (4) con runner remite a la retención de §8.2.2 en vez de prometer un dato permanente. |
| P-10 | APLICAR | Reversible. Declara un límite (manifiesto sin lock → `n/a`, VERDE) en lugar de cambiar la conducta de la compuerta, que era la opción con más radio (C3-18 a). La exclusión entre pre-commit y `core.hooksPath` tiene E1 (`Cowardly refusing…`). Los dueños de la compuerta se verificaron con X6. |
| P-11 | APLICAR | Alinea §11 con la compuerta real (`tools/ci/compuerta.sh`) y con la decisión del ciclo 2. Partir párrafos no mueve anclas (183/183). |
| P-12 | APLICAR | El YAML de §12 sigue válido y con sus 11 validaciones (`yaml-salida.txt`). 8b y 9 llevan `# [no verificado]` con su motivo escrito («requiere plataforma alojada»), así que no dependen de la regla por defecto de P-01. La fecha de fin de soporte de .NET 8 es un dato volátil con fuente [B224] y figura en el Anexo F. |
| P-13 | APLICAR | Es el parche que más rompe si se aplica sin el laboratorio: A.10 cambia de etiqueta y digest (`ec9c0a0d…`) y A.4 cambia el hash de la DLL. Mitigación ya diseñada: `anexoA.py` da 22 de 22 iguales contra `x1-ea1-propuesto/repo/`, y EA-1 rc=0. Condiciones: aplicarlo **junto** con P-25 (L-01, L-01b), correr EA-1 **una vez** después de L-01/L-01b y copiar al extracto de A.17 el commit y el hash de esa corrida. Si el registro rehízo la etiqueta, va el digest del día (supuesto del auditor). |
| P-14 | APLICAR | Son remisiones; se revierten en bloque. |
| P-15 | APLICAR | Son glosario y alias, sin efecto sobre anclas ni laboratorio. |
| P-16 | APLICAR | Agrega filas al Anexo D con su frase verificada (§6.2 del documento de parches). Riesgo bajo: el chequeo «224 definidas, 224 citadas» lo cubre. Es prerrequisito de las cifras de P-01. |
| P-17 | APLICAR | Las fechas salen de X7 (46 salidas del 2026-10-07 y 39 del 2026-10-09), no de una estimación: cumple la condición que puse en C3-34. La fila E5-8 depende de L-02. |
| P-18 | APLICAR | Declara lo no verificado y los datos volátiles con su fuente. Reduce el riesgo de que el lector tome por permanente un dato que caduca. |
| P-19 | APLICAR | Control de cambios. Condición: si P-01 o P-23 vuelven reformulados, la fila 1.1.0 los describe tal como entren. |
| P-20 | APLICAR | Los recortes remiten a §0.4 y a la fila EA-1, que siguen existiendo. El recuadro de §5.2.6 conserva el **[no verificado]** de las vías de Windows. |
| P-21 | APLICAR | Lo que se quita figura en §3.2, A.11, §8.2.4 y el comentario de A.4. La tesis de Visual Studio se queda donde funciona como advertencia (§8.2.4 y las filas ESC-01 de §10.3 y §11.3), que era mi condición de C3-35. «Nunca `latest`» sobrevive en §6.3 ([B57]). |
| P-22 | APLICAR | Fusiona preguntas sin perder el *Aplica* y remite a la sección que las desarrolla. Si sale mal, lo único que se pierde es una repetición. |
| P-23 | MEJORAR_PLAN | Depende de la regla por defecto de P-01, y su verificación (contar la glosa) no detecta el defecto de §2. Reformular junto con P-01: o se quita la glosa sólo después de que cada **[no verificado]** sin motivo que no sea de Windows tenga el suyo, con un criterio de verificación que liste y clasifique todas las marcas sin motivo de la guía parcheada; o no se aplica y se conserva la glosa (−16 palabras menos de ahorro). Sigue yendo último. |
| P-24 | APLICAR | Son notas de solo agregado, con instantánea y `diff` sin líneas `<`. Corrige en la capa de origen (núcleos, `04-Integracion.md`, bitácora de los ciclos 1 y 2) y cierra pendientes del ciclo 2 (O-5, O-12, C1-05). Las notas no nombran nada privado. Condición: R-PRIV → 0, como declara el parche. |
| P-25 | APLICAR | Es reversible con la instantánea de `Examples/`. El laboratorio va **antes** que la guía: E5-8, E2-6 y E1-11 (Node) se corren y se versionan antes de aplicar P-08, P-05 y P-04. EA-1 corre una sola vez, después de L-01 y L-01b. N8 no se toca, lo que evita regenerar E8-3, E8-5 y E8-6. L-05 declara en el README que no regenera las salidas, en vez de reescribirlas. |

## 4. El saldo de prosa (+493) y la propuesta del editor de cierre (C3-Q09)

Desde el riesgo, lo peligroso no es el +1,1 %. Lo peligroso es una pasada de compresión de ≈ 500 palabras hecha **por juicio editorial y fuera de la simulación**, sobre párrafos que, según el propio auditor, «tocan prosa con información». P-20 a P-22 son seguros porque tienen el ancla literal, la medición y los chequeos; una pasada ad hoc no tiene ninguna de las tres cosas.

Mi voto:

- Si el editor de cierre comprime, lo hace como **un parche más (P-26)**, con el mismo formato: ancla literal, Δ medido, `gen.py` sin fallas, 0 enlaces rotos, Anexo A igual y YAML válido. Va antes de P-23 en el orden y no toca bloques de código, filas `[Bnn]` ni el Anexo E.
- Si no se puede hacer así en este ciclo, el +493 queda como **deuda declarada** (marco §5.5, `NO_APLICAR` consciente del ≤ 0), escrito en la fila 1.1.0 del control de cambios y en el cierre del ciclo, y entra al ciclo siguiente.

No es una escalada: ninguno de los siete disparadores se cumple.

## 5. Resumen

- APLICAR: P-02 a P-22, P-24 y P-25 (23 parches), con las condiciones de orden de §3: el laboratorio va antes que los parches que lo citan, P-13 va junto con P-25 y EA-1 corre una sola vez.
- MEJORAR_PLAN: P-01 (sólo la oración de la marca por defecto en §0.3) y P-23. La objeción es la misma para los dos (§2) y la vuelta es una sola.
- NO_APLICAR: ninguno.
- ESCALAR: ninguno.
- Vetos: ninguno. Ninguna corrección es irreversible.
