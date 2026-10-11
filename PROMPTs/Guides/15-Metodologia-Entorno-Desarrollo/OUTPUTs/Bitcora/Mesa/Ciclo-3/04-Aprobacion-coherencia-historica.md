# Mesa · Ciclo 3 · 04 — Aprobación: juez de coherencia histórica

> Fecha: 2026-10-09. Rol: mesa de aprobación, juez de coherencia histórica (marco `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §5.5 y §6).
> Insumo: `03-Parches.md` de esta carpeta (P-01…P-25) y la simulación `evidencia-auditor/simulacion/guia-parcheada.md` (la guía con P-01…P-23 aplicados). En la simulación se ve si un parche contradice a otro o a un veredicto vigente. «L*n*» es una línea de esa simulación, salvo que se diga otra cosa.
> Pregunta: ¿el parche reabre una decisión cerrada o contradice otro veredicto? Las decisiones que se consultan son el contrato (DC-01…DC-07 y `fuera_de_alcance`), `04-Integracion.md`, los ciclos 1 y 2 y mi voto `02-Voto-coherencia-historica.md` de este ciclo. En los ciclos 1 y 2: C1-03 (a), C1-05, C1-14, C1-18 (b), C1-21 (b), C1-39, C2-13, C2-36 y `Ciclo-2/03-Parches.md` §9. Del ciclo 3 pesan los 35 PROCEDE y las direcciones de §1 de `03-Parches.md`.
> Criterio (el mismo de los tres ciclos):
> - Reabrir es legítimo con evidencia nueva o con una mayoría del jurado del ciclo, **siempre que la reapertura quede escrita como tal** en la guía y en la capa donde vive la decisión.
> - Una deuda o un pendiente registrado se cumple, no se reabre.
> - Si un parche deja en la guía dos reglas incompatibles, o deja en la bitácora un registro que dice algo distinto de lo que pasó, no corrige en la capa de origen y va a MEJORAR_PLAN.

## Veredicto

| Parche | Voto | Fundamento |
|---|---|---|
| P-01 | MEJORAR_PLAN | Las operaciones 1 a 8 no tienen objeción. La versión 1.1.0, las cifras 224/74 y la fecha remitida al Anexo E cumplen la regla de §0.3 (P-03 del ciclo 1, C2-29), como voté en C3-34. La fila §3/E0-6 es la parte de C3-41 que la mesa admitió. La **operación 9** deja una regla que contradice a la propia guía. Dice: «Sin motivo escrito, **[no verificado]** quiere decir "requiere Windows"». Pero quedan marcas sin motivo que no tratan de Windows: L539 (ningún documento de .NET sobre el BOM en `.cs`), L1027 (columna «¿Hace cumplir?» de asdf), L1411 (Renovate y el digest de `container:`), L1482 (Dependabot y los digests) y L1953 (Dependabot con gestores nuevos). Además, la definición de §0.3 (L93) dice que siempre «se dice qué faltaría para verificarla». Con P-23 aplicado, esas cinco marcas pasarían a leerse como «requiere Windows». El texto de la mejora está en §2.1. |
| P-02 | APLICAR | Alinea §2.4 con los responsables que ya figuran en la tabla de §12 (pasos 4–9, ACT-OPS). No toca el orden de §12 (C1-39). |
| P-03 | APLICAR | Es el recorte 1 de C3-35 y completa el mapa de §3.6 (C3-30), que C2-38 dejó con su vuelta al mapa. §3.5 remite a §8.2.1 y no pierde ninguna fuente. P-10 op. 11 rehace en coherencia la consigna «Volver al mapa», que ya no nombra §3.5. |
| P-04 | APLICAR | Cumple la condición que puse en C3-33: la celda conserva la salvedad «salvo bytes que formen UTF-8 válido», así que no contradice C1-56 ni C2-31. Con E8-1 (rc=2) y E1-11 con Node (X3), la frase sobre el `child_process` pasa a estar respaldada; no se reabre nada. |
| P-05 | APLICAR | Conserva los tres estados y la variante B (C1-10/CI-02, C2-12). Corrige las razones con E1 (X2, [B222]), sin cambiar la convención. «La compuerta entra en el commit 1 y se activa en el paso 4» es la primera dirección de C3-20: el commit 1 es el paso 2 de §12 (L2478), así que el orden de C1-39 queda intacto. |
| P-06 | APLICAR | No reabre C1-03 (a): lock + `disable` sigue siendo el valor por defecto. Lo que cambia es el rótulo, que pasa a **[criterio]**, y eso es lo que [B56] sostiene (C3-15). `paths` va con **[no verificado]** para Visual Studio (C3-Q04). «npm y uv (pip, sólo al instalar)» corrige un hecho y no toca ninguna decisión. |
| P-07 | APLICAR | Corrige un hecho con E1 (MSB1003). «La compuerta de A.11 los busca» es coherente con C2-06, porque los proyectos se encuentran con `git ls-files`. |
| P-08 | APLICAR | Es la dirección A de C3-01 (5-0): una definición en §8.2.2 y remisiones, la «misma redacción en un solo lugar» que pedí en el ciclo 2. Incluye C3-03 (sale «bit a bit», lo nativo va como **[interpretación]**) y C3-07: la frontera A sale de los motivos de la imagen propia y entra la base compartida con el devcontainer. «Nunca etiqueta flotante» se acota a lo que el repo nombra, y así cumple el pendiente §6.1 del ciclo 2 sin reabrir C2-13: el runner sigue alcanzando para 8a. Lo único que falta está en la capa de origen y se resuelve en P-24 (§2.4). |
| P-09 | APLICAR | Sacar el `AssemblyMetadata` es la reapertura con E1 que voté en C3-12: tres hashes distintos contra «el digest se declara una vez» (C2-13). ESC-04 sin «procedencia válida» y `--signer-workflow`/`--source-ref` precisan C1-17/C1-32 dentro del bloque comprimido de C2-15. |
| P-10 | APLICAR | Etiqueta fija + digest: hace compatibles C1-21 (b) y C1-03 (a), como voté en C3-11. «Sin lock» → `n/a` declarado es la dirección (b) de C3-18; la (a), rojo con excepciones, **no** entra, y así respeta `Ciclo-2/03-Parches.md` §9. Las dos entradas de hook se excluyen y la plantilla queda en `.githooks/`, como pide C3-19, sin tocar A.9 ni §8.5 (C2-11). Que haya dueños de lo que desarma la compuerta completa C1-19 y C2-17. |
| P-11 | MEJORAR_PLAN | Las operaciones 1–13 y 15–17 cumplen C3-22 (C2-06), C3-28 (C1-14, C2-21), C3-18 (b) y C3-52. La **operación 14** contradice a P-08 y al veredicto C3-07 dentro del mismo lote. Su texto: «si MSBuild llama a npm y uv (frontera A), los tres runtimes tienen que estar en la misma imagen (E8-3)». C3-07 (E1+E2, PROCEDE en los cinco votos) fijó otra cosa: con el runner y los tres *setup-*, la frontera A corre igual, y la imagen propia se justifica por la base compartida. La op. 6 de este mismo parche ya lo dice: «el runner alojado con los tres *setup-* también sirve». Así, §11.6 diría «tienen que estar en la misma imagen» y §8.2.2 y §11.2.7, que no hace falta. Texto en §2.2. |
| P-12 | APLICAR | La compuerta activada en el paso 4 y commiteada en el 2 conserva C1-39. 8a con `NO DECLARADA` sólo con runner es la síntesis A + (a) de C3-02, sin reabrir C2-13. «Elegir un SDK con soporte» no cambia las plantillas: el 8.0.425 sigue como SDK del caso, con su fin de soporte declarado (C2-04, C3-14). Las validaciones 8b y 9 llevan **[no verificado]** con motivo («requiere plataforma alojada»), así que no dependen del valor por defecto de P-01. La Práctica se completa sin experimentos nuevos (C2-33, C3-29). |
| P-13 | APLICAR | A.4 sin `ImagenDigest` (C3-12). A.10 con etiqueta fija y digest (C3-11). A.12 recupera `SOURCE_DATE_EPOCH` en la variante, como exige C1-18 (b) (C3-08). A.17 con `WORKFLOW_FILE` que falla cumple el pendiente §6.2 del ciclo 2 (C3-09). A.11 con la receta de Windows **[no verificado]** es coherente con C2-10 y C2-Q04. N8 no se toca (desarrollador-06) y la guía declara la diferencia: no se reabre la decisión del ciclo 2 sobre las salidas de N8. |
| P-14 | APLICAR | Remisiones de B.3 y B.4 a §8.2.2 (C3-06). B.1 remite a la receta de A.11 sin repetirla. |
| P-15 | APLICAR | El glosario precisa «registro» con su complemento. **No** es el reemplazo global de «registro» que `Ciclo-2/03-Parches.md` §9 dejó fuera, así que no lo reabre. |
| P-16 | APLICAR | Son fuentes nuevas con fecha y frase verificada (§6.2 de `03-Parches.md`). Pasar a npm v12 actualiza la consulta sin cambiar lo que dicen B63, B64 y B150 («advisory only» se mantiene). |
| P-17 | APLICAR | Cumple la regla de §0.3 con fechas tomadas de las salidas (X7), no estimadas: es la condición de riesgo que se puso en C3-34. E5-8 entra como experimento de laboratorio, que es lo que pidió C3-01. |
| P-18 | APLICAR | Anexo F: trazas completas y datos volátiles con su fuente (C2-04, D-7). El log del runner como no verificado es coherente con `Ciclo-2/03-Parches.md` §9: la versión de la imagen del runner no se lee como contrato. |
| P-19 | MEJORAR_PLAN | La fila 1.1.0 y la compresión de las celdas cumplen C2-37. Pero el párrafo **1.1.0** dice «Práctica de §3», y esa Práctica **no se aplica**: `03-Parches.md` §1.2 y §8 la dejan fuera por el saldo de C3-35, y la simulación no tiene `### 3.9 Práctica` (L263–L433). El control de cambios afirmaría algo que no ocurrió. Además, la compresión del párrafo **1.0.0-rc.1** quita «fija cuatro marcas de juicio (§0.3)». Es un hecho histórico, y P-01 op. 9 apoya justamente en ese vocabulario cerrado la regla nueva. Texto en §2.3. |
| P-20 | APLICAR | Recortes de C3-35. Lo quitado está en §0.4 y en la fila EA-1. La glosa que queda en la op. 1 la retira después P-23. |
| P-21 | APLICAR | Cumple la condición de riesgo de C3-35: la tesis de Visual Studio se queda en §8.2.4, donde funciona como advertencia, y sale de §12 con remisión. «Nunca `latest`» sigue en §6.3 [B57]. No toca citas ni marcas: el **[no verificado]** de L2044 desaparece junto con la frase que lo llevaba, y la misma afirmación sigue marcada en §8.2.4. |
| P-22 | APLICAR | Fusionar preguntas guía es el recorte 2 de C3-35, ampliado. Cada respuesta conserva su *Aplica* y su remisión. La baja del conteo de *Aplica* queda declarada, como en el ciclo 2. |
| P-23 | MEJORAR_PLAN | La dirección es la (5) de C3-35, votada, y retirar la glosa es correcto. Pero P-23 es la operación que vuelve falsa la regla de P-01 op. 9 en las cinco marcas sin motivo que no tratan de Windows (ver P-01). Como es el parche transversal de **[no verificado]**, es el lugar natural para escribir esos cinco motivos. Va último, como ya está. Texto en §2.1. |
| P-24 | MEJORAR_PLAN | Cumple los pendientes del ciclo 2 (`05-Aplicacion.md` §6.3: O-5 como acotamiento, la nota en `04-Integracion.md`, la nota de C1-05 en N7, la de `Ciclo-1/03-Parches.md`) y deja la reapertura de C2-13 escrita como acotamiento, como pedí. Hay dos defectos en el registro histórico, que es de solo agregado y, por eso, difícil de corregir después. (1) **O-9** empieza con «Corrección mesa ciclo 2 y 3», pero la nota se escribe en el ciclo 3. Además se presenta como «pendiente O-12 del ciclo 2», cuando `Ciclo-2/05-Aplicacion.md` §6.3 llama O-12 a la nota de `Mesa/Ciclo-1/03-Parches.md`, que aquí es O-10. El rótulo O-12 fue ambiguo en el ciclo 2: yo lo usé para `04-Integracion.md` (`Ciclo-2/04-Aprobacion-coherencia-historica.md` L76) y evidencia, para `Ciclo-1/03-Parches.md`. La aplicación del ciclo 2 adoptó el segundo uso, así que las notas tienen que nombrar cada pendiente por su archivo y no por ese rótulo. (2) **O-1** declara que acota C2-13 por C3-07, pero sólo escribe la caída de «bit a bit». No escribe que «la frontera A en la CI» deja de ser motivo de la imagen propia, que fue el texto de C2-13 en la guía. Texto en §2.4. |
| P-25 | MEJORAR_PLAN | Los cambios del laboratorio, L-01 a L-07, son coherentes. EA-1 se corre una sola vez después de L-01/L-01b, como pedí. N8 queda intacto. L-05 declara que las salidas no se regeneran (C3-32). El `.gitignore` de DC-06 no se toca. Lo que no es coherente es el **cierre del lote** que declara este parche: un saldo de prosa de **+493**. C2-36 fijó «saldo de prosa propia ≤ 0, salvo voto explícito», y C3-35 lo reafirmó en este mismo ciclo (S2, PROCEDE en los cinco votos, el mío con la condición «C2-36: saldo ≤ 0»). Cerrar en +493 como «costo aceptado» contradice un veredicto vigente del mismo ciclo, y no hay E1 que lo muestre contradictorio, sólo costoso. Además, la vía que propone el auditor tiene un problema propio: una pasada del «editor de cierre» **después** de la aprobación aplicaría texto que nadie votó (marco §4, separación de funciones; §5.5). Texto en §2.5. |

**Recuento:** 19 APLICAR, 6 MEJORAR_PLAN (P-01, P-11, P-19, P-23, P-24 y P-25; P-01 y P-23 se arreglan juntos, en §2.1), 0 NO_APLICAR, 0 ESCALAR. Los MEJORAR_PLAN no rechazan la dirección de ningún parche: en todos el defecto es de texto o de registro, y el texto de reemplazo está en §2.

## 1. Por qué no escalo

Reviso los siete disparadores de §6 del marco:

1. **Ambigüedad de intención:** no la hay. Las direcciones en disputa (C3-01, C3-02, C3-03) se votaron 5-0.
2. **Conflicto entre restricciones duras:** no lo hay. El saldo de prosa no es una restricción del contrato: es un veredicto de mesa (C2-36) con una salida prevista, el voto explícito o la compresión.
3. **Cambio de alcance:** no lo hay. Nada agrega ecosistemas (DC-02) ni sale de la guía hacia despliegue (`fuera_de_alcance`).
4. **Irreversibilidad:** no la hay. Todo se revierte con la instantánea, y las notas de origen son de solo agregado. Justamente por eso, en P-24 pido que el texto sea exacto **antes** de insertarlo.
5. **Consecuencia externa:** no la hay. La privacidad (R-PRIV) se verifica en P-24 con el `grep` del contrato.
6. **Empate:** no lo hay.
7. **Reapertura de decisión cerrada:** ningún parche reabre DC-01…DC-07. Las reaperturas de veredictos de ciclo (el motivo «bit a bit» y la frontera A de C2-13, y el `ImagenDigest` del ciclo 1) tienen E1 nuevo y quedan escritas como acotamiento.

## 2. Plan de mejora (texto concreto)

### 2.1 P-01 op. 9 y P-23: la marca sin motivo

Se mantiene la op. 9 de P-01 tal como está. A P-23 se le agrega una **operación 2**, que se aplica antes del reemplazo de las ocho glosas y da motivo a las marcas sin motivo que no tratan de Windows. Los anclajes son los de la simulación:

| Línea | Ancla (literal) | Pasa a |
|---|---|---|
| L539 | `recomiende o desaconseje el BOM en `.cs` **[no verificado]**.` | `… **[no verificado]** (sin fuente que lo trate).` |
| L1027 | `| **[no verificado]** | **[no verificado]** |` (fila asdf) | `| **[no verificado]** (no documentado) | **[no verificado]** (no probado) |` |
| L1411 | `pero que mueva su digest **[no verificado]**:` | `pero que mueva su digest **[no verificado]** (requiere la plataforma):` |
| L1482 | `y no GitHub [B107] **[no verificado]** (§8.2.2)` | `y no GitHub [B107] **[no verificado]** (requiere la plataforma; §8.2.2)` |
| L1953 | `cómo se comporta con las más nuevas **[no verificado]**.` | `… **[no verificado]** (requiere la plataforma).` |

L1698 («No se ejercitó **[no verificado]**») ya tiene el motivo escrito en la misma oración. Lo dejo así; si el auditor prefiere uniformar, `(no ejercitado)`.

Verificación: después de P-23, cada `**[no verificado]**` sin paréntesis detrás está en una fila, un párrafo o un recuadro sobre Windows, Visual Studio o ESC-01. Esto se comprueba con un listado de contexto, como el `python3` de §3 de este voto. Δ prosa ≈ +14 (se suma a P-23).

### 2.2 P-11 op. 14: la frontera A con runner

Reemplazar el texto nuevo de la op. 14 por:

~~~~text
La frontera dice qué tiene que haber en un mismo entorno: si MSBuild llama a npm y uv (frontera A), los tres runtimes, en la imagen única o, en la CI, en el runner con los tres *setup-* (§8.2.2) (E8-3). La cantidad de artefactos dice si la CI puede partirse (§11.2.7). Con las mismas versiones, las dos dan la misma DLL (E8-5).
~~~~

Δ ≈ +12 sobre la op. 14 propuesta. Verificación: en la guía parcheada, `grep -n "tienen que estar en la misma imagen"` → 0.

### 2.3 P-19: el control de cambios dice lo que pasó

- Párrafo **1.1.0**: en lugar de «§3.5 comprimida, Práctica de §3, B218–B224», escribir «§3.5 comprimida, fila §3 en la ruta mínima, B218–B224».
- Párrafo **1.0.0-rc.1**: conservar al final «; fija cuatro marcas de juicio (§0.3)». Si para compensar las tres palabras hace falta un recorte, que salga de otra parte del mismo párrafo, no de un hecho.

Verificación: cada ítem del párrafo 1.1.0 tiene un parche aplicado que lo produce (tabla §7 de `03-Parches.md`); `grep -c "Práctica de §3"` → 0. Δ ≈ +4.

### 2.4 P-24: rótulos y alcance de las notas de origen

- **O-9**: el encabezado pasa a `> **Corrección mesa ciclo 3 (2026-10-09, C2-13, C3-01, C3-07; pendiente del ciclo 2 en `Mesa/Ciclo-2/05-Aplicacion.md` §6.3: nota en este archivo).**`. El resto del texto queda igual.
- **O-10**: en el encabezado, `pendiente de P-22 del ciclo 2` pasa a `pendiente O-12 de `Mesa/Ciclo-2/05-Aplicacion.md` §6.3 (P-22 del ciclo 2)`.
- **O-1**: después de «"Reconstrucción bit a bit" deja de ser motivo de la imagen propia.», insertar: `Tampoco lo es «la frontera A en la CI», que corre igual en el runner con los tres *setup-* (C3-07): el motivo es la base compartida con el devcontainer.`
- Verificación adicional: `grep -c "ciclo 2 y 3"` → 0 en las notas nuevas; ninguna nota de ciclo 3 empieza con «Corrección mesa ciclo 2».

### 2.5 P-25: el saldo del lote

Antes de la aplicación, y no después, el cuerpo auditor entrega un **P-26 · Compresión de cierre**. Puede escribirlo el «editor de cierre con presupuesto» (C3-Q09) si se lo convoca, pero como autor del parche y no como pasada libre. Condiciones:

- Los candidatos son los que ya midió el auditor (§2 de `03-Parches.md`): los párrafos de ≥ 150 palabras de §6.2.2, §6.2.3, §7.2.1 y §10.2.6 «Bots», y las «Señales de una versión pobre» que repiten negaciones de su propia lista de criterios.
- Δ de prosa ≤ −(493 + lo que agreguen §2.1–§2.4 de este voto), medido con el mismo `gen.py`.
- Se aplica la misma vara de P-20 a P-22. No se tocan citas `[Bnn]`, IDs de experimento ni marcas de juicio (C2-36, C1-17, C1-32, C1-43). Verificación: conteo de `[Bnn]`, de IDs y de las cuatro marcas igual antes y después.
- P-26 pasa por una ronda breve de aprobación (`04b-…`), como en el ciclo 1.

Si la mayoría de la mesa vota APLICAR el lote con +493, ese voto es el «voto explícito» que admite C2-36. Lo que no corresponde es dejarlo como «costo aceptado» sin nombre. En ese caso, `05-Aplicacion.md` tiene que registrarlo con esas palabras, y el párrafo 1.1.0 del control de cambios no debe decir que la versión comprime.

## 3. Respuesta a C3-Q11 (pregunta de proceso para este juez)

¿Quedaron otros hallazgos del ciclo 2, además de CAT-FORMAL-01, sin fila en `Ciclo-2/01-Consolidado.md`? **No.** Lo verifiqué así (E1, 2026-10-09):

1. Extraje los encabezados `### <especialista>-NN` de los doce `Ciclo-2/Informe-*.md`. Son 70 identificadores. A ellos se suman `requisitos-01…06`, que usan otro formato de encabezado.
2. Busqué cada uno, literal, en `Ciclo-2/01-Consolidado.md`. Resultado: `SIN FILA: adhoc-CAT-FORMAL-01`, y ningún otro. Los seis de requisitos aparecen todos.

La nota O-11 de P-24 queda así completa. Propongo agregarle al final: `C3-Q11: verificado por el juez de coherencia histórica; ningún otro hallazgo del ciclo 2 quedó sin fila (Ciclo-3/04-Aprobacion-coherencia-historica.md §3).`

## 4. Registro para el cierre

- **Reaperturas que este lote deja escritas, y dónde:**
  - el motivo «bit a bit» de C2-13 (O-1, guía §8.2.2, §9.6, §12 p.7);
  - la frontera A como motivo de la imagen propia (O-1 con §2.4 de este voto, guía §8.2.2, §12 p.7);
  - el `ImagenDigest` del ciclo 1 (O-4, O-10, guía §9.2.1, A.4).

  Las tres tienen E1 nuevo (E5-8, X5, `evidencia-senior-dotnet/imagendigest.txt`).
- **Decisiones que el lote respeta y que no admito reabrir en la aplicación:**
  - C2-13: el runner alcanza para 8a;
  - `Ciclo-2/03-Parches.md` §9: el aviso de «sin lock» y la versión de la imagen del runner como dato fijo;
  - C1-39: el orden de §12;
  - C1-03 (a): lock + `disable` por defecto;
  - DC-06: el `.gitignore` del laboratorio.
- **Orden de aplicación que pido:**
  1. Instantánea.
  2. P-24, con §2.4.
  3. Laboratorio P-25: E5-8, E2-6 y E1-11 corridos y versionados **antes** de P-08, P-05 y P-04, que los citan.
  4. P-01…P-22, con §2.2 y §2.3.
  5. P-26, si se aprueba.
  6. P-23 al final, con §2.1.
  7. EA-1 una sola vez, después de L-01/L-01b.
- **Lo que la guía no puede afirmar al cerrar:** que la versión 1.1.0 comprime, si el saldo de prosa queda positivo.
