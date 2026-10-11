# Mesa · Ciclo 3 · 02 — Voto del juez de coherencia histórica

> Fecha: 2026-10-09. Rol: juez de coherencia histórica (marco `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §4.3 y §5.3).
> Función objetivo: ¿el ítem reabre una decisión cerrada o contradice otro veredicto?
> Decisiones consultadas: contrato `00-Contrato-De-Entrada.md` (DC-01…DC-07, `fuera_de_alcance`, severidades); `04-Integracion.md`; ciclo 1 (`01-Consolidado.md`, `03-Parches.md`, `05-Aplicacion.md`); ciclo 2 (`02-Voto-coherencia-historica.md`, `03-Parches.md` §1 y §9, `04-Aprobacion-coherencia-historica.md` §2, `05-Aplicacion.md` §6); `Ciclo-3/01-Consolidado.md`.
> Criterio (el mismo de los dos ciclos): reabrir es legítimo con evidencia E1/E2 nueva que muestre una contradicción, **siempre que la reapertura quede escrita como acotamiento** en la guía y en la capa donde vive la decisión; una deuda o un pendiente registrado (`Ciclo-2/05-Aplicacion.md` §6) se cumple, no se reabre; en las [CONTRADICCIÓN] voto la dirección que no contradice veredictos vigentes, o la síntesis cuando ambas caben.
> Veredictos vigentes que más pesan: C2-13 (A, 3-1: runner alojado admitido para 8a con la capa 4 declarada); `Ciclo-2/03-Parches.md` §9 (no se lee la versión de la imagen del runner: no hay fuente de primera mano); C2-36 (saldo de prosa ≤ 0; citas y evidencia se presupuestan aparte; sin meta dura); C1-03 (a), C1-10/CI-02, C2-12, C1-14, C1-21 (b), C1-18 (b), C1-39.

| Id | Voto | Fundamento |
|---|---|---|
| C3-01 | PROCEDE | Dirección A: una definición por capa en §8.2.2 y remisiones es la «misma redacción en un solo lugar» que pidió este juez en el ciclo 2 (`04-Aprobacion` §2) y respeta C2-36; la cláusula por sitio (AH-002) suma prosa en once lugares contra ese saldo. Una tabla de dos caminos cabe **dentro** de §8.2.2 si los otros sitios remiten a ella. Condición: escribirlo como acotamiento de C1-21 (b), C1-18 (b) y C2-13, con las notas O-5 y O-12 que `Ciclo-2/05-Aplicacion.md` §6.3 dejó pendientes. |
| C3-02 | PROCEDE | Síntesis A + (a) y, como opción, (b) rotulada **[observado]**: el runner alcanza para 8a (C2-13 A, 3-1, no se reabre), con `NO DECLARADA` y su motivo como valor admitido sólo con runner, y la retención del log declarada. La opción (c) reabre C2-13 sin E1 que lo refute: la retención es un costo, no una contradicción. «Versión del runner» leída de `/etc/environment` sigue siendo código y no contrato, así que no se automatiza como dato fijo (`Ciclo-2/03-Parches.md` §9). |
| C3-03 | PROCEDE | Dirección A. «Bit a bit» como motivo de la imagen propia entró por C2-13 (A); el E1 del abogado (misma DLL y PDB en tres bases, el control con SDK 10 cambia el hash) es evidencia nueva que lo refuta para lo gestionado. Reapertura legítima, acotada a lo medido (*framework-dependent*, linux/amd64); §9.6 conserva la imagen para lo nativo. Se registra como acotamiento de C2-13. |
| C3-04 | PROCEDE | Es el op 2 y la validación de 8a que este juez propuso en `Ciclo-2/04-Aprobacion` §2.3 y que quedaron en minoría; cumple C2-13 sin reabrir C1-18 (b) para la imagen propia. Condicionado a C3-02. |
| C3-05 | PROCEDE | En las opciones (a) y (b) de C3-02: declarar que el log caduca completa el «costo declarado» que C2-13 exigió. No en (c). |
| C3-06 | PROCEDE | Es el pendiente §6.1 del ciclo 2 (la única contradicción entre secciones que quedaba abierta); se cumple, no se reabre. Forma: remisiones a §8.2.2, por C3-01; en §8.6 y §8.7 basta la remisión, sin *No aplica* adicional. |
| C3-07 | PROCEDE | Reemplazar rótulos aún no definidos es coherente con C1-24 (dos velocidades). Cambiar la razón a «base compartida con el devcontainer» no contradice C1-14 (§11.3: imagen única para devcontainer y frontera A); se escribe como acotamiento del motivo de C2-13, y el «bit a bit» lo decide C3-03. |
| C3-08 | PROCEDE | Cumple C1-18 (b): 8a exige `SOURCE_DATE_EPOCH`, y la variante de A.12 que P-15 del ciclo 2 introdujo no lo conserva. No hay decisión en contra. |
| C3-09 | PROCEDE | Es el pendiente §6.2 del ciclo 2 (impacto, P-15/P-23); `WORKFLOW_FILE` que falle y el paso nuevo en EA-1 lo cumplen. Compatible con requisitos-01, como anota el relator. |
| C3-10 | PROCEDE | Arrastre del ciclo 2 sin disposición (adhoc-CAT-FORMAL-01); no hay veredicto sobre él. Precisar «mismo manifiesto / misma plataforma» no toca C1-21 (b): el digest sigue mandando. |
| C3-11 | PROCEDE | Fijar `sdk:8.0.425-bookworm-slim@sha256` mantiene el digest de C1-21 (b) y evita que el PR del bot choque con `rollForward: disable` de C1-03 (a); hace coherentes dos veredictos vigentes. Volver a correr EA-1 es la verificación que exige P-23. |
| C3-12 | PROCEDE | `ImagenDigest` entró con un parche del ciclo 1, pero el E1 (tres hashes) muestra que contradice «el digest se declara una vez» del ciclo 2 (C2-13, arquitecto-02) y C3-03. Reapertura con E1; nota de solo agregado en la capa de origen. |
| C3-13 | PROCEDE | Corrección factual con E1; es dato volátil (D-7, C2-04) y va al Anexo F como C2-04 hizo con el fin de soporte. No reabre nada. |
| C3-14 | PROCEDE | Coherente con C2-04 (8.0.425 queda como SDK del caso, con su fin de soporte declarado) y con SUP-06; la oración en §12 p.5 no cambia las plantillas. |
| C3-15 | PROCEDE | No reabre C1-03 (a): lock + `disable` sigue siendo el defecto; cambia el rótulo (**[criterio]** propio frente a condición del fabricante), que es lo que la evidencia [B56] sostiene. La mitigación `paths` entra con **[no verificado]** para Visual Studio, como C2-Q04. |
| C3-16 | PROCEDE | Mantiene los tres estados y la variante B de C1-10/CI-02 y C2-12; corrige las razones con E1 (`dotnet sln add` sobre `.slnx`, el `.razor`). Una fila propia para `.slnx` no contradice C2-12, que habló de `csproj`/`props`/`targets`. |
| C3-17 | PROCEDE | C2-12 ya extendió la variante B a `props`/`targets`; nombrar todos y sumar A.5 al paso 1c de EA-1 cumple ese veredicto. |
| C3-18 | PROCEDE | Preferir (b), repetir el límite y sumar X1 a EA-1: (a) es la misma familia que `Ciclo-2/03-Parches.md` §9 dejó fuera por costo y riesgo (aviso de ejecutable sin lock, hook que falla con lock sin marcar), y adoptarla sin experimento de los casos legítimos reabriría eso. |
| C3-19 | PROCEDE | No hay veredicto sobre la convivencia `pre-commit install` / `core.hooksPath`; C1-05 (compuerta única, local = CI) se cumple con cualquiera de las dos entradas si es una sola. Preferir `.githooks/pre-commit` como entrada única, que no toca A.9/§8.5 ya corregidos por C2-11. |
| C3-20 | PROCEDE | Primera dirección («entra en el commit 1, se activa en el paso 4»): conserva el orden de §12 que fijó C1-39. Llevar la compuerta al paso 2 movería ese orden. |
| C3-21 | PROCEDE | Coherente con C2-10 y C2-Q04: receta mínima de Windows con **[no verificado]**, sin afirmar lo no medido. |
| C3-22 | PROCEDE | Cumple C2-06 (a) (compuerta única, `tools/ci/compuerta.sh`); los tres «verificar.sh» son la ambigüedad que ese veredicto quiso cerrar. |
| C3-23 | PROCEDE | Alinea §8.2.4 con la tabla de C1-19/C2-19 («qué no impide») y con E7-5; el universal contradice veredictos vigentes. |
| C3-24 | PROCEDE | Corrección factual con E1 sobre un bloque de §7.5; sin decisión en contra. |
| C3-25 | PROCEDE | Corrección factual con E1; sin decisión en contra. |
| C3-26 | PROCEDE | Completa C1-19 (lo que protege la compuerta tiene que tener dueño) y C2-17 (el eslabón del digest con dueño). No reabre nada. |
| C3-27 | PROCEDE | Coherente con C1-17 (L1 exige `builder.id`) y C2-16; agregar `--signer-workflow` y `--source-ref` precisa la verificación del predicado que C1-32 pidió. Dentro del bloque comprimido de C2-15. |
| C3-28 | PROCEDE | C1-14 cerró que la imagen de la CI se decide por la variable de §11.2.7 (cantidad de artefactos) y C2-21 lo reforzó; las frases de §11.2.6 y §11.6 que deciden por la frontera contradicen ese veredicto y se reescriben a su favor. |
| C3-29 | PROCEDE | Preferir completar la respuesta con 8b y 9 rotulados «sin experimento» y **[no verificado]** en el YAML: C2-33 fijó «sin experimentos nuevos» y C1-23 las consignas por capítulo; acotar la consigna también cabe, pero no agregar experimentos. |
| C3-30 | PROCEDE | Completa el mapa de §3.6 que C2-38 dejó con su vuelta al mapa; tres celdas o enlaces no reabren nada. |
| C3-31 | PROCEDE | Corrección factual con E1 (E8-1, rc=2); sin decisión en contra. |
| C3-32 | PROCEDE | El README y el `run.sh` de N4 quedaron detrás de C2-01/C2-02 (`NU1603` como error, A.4 activa); corregirlos cumple esos veredictos. Declarar el cambio con nota de solo agregado (P-22). |
| C3-33 | PROCEDE | No contradice C1-56/C2-31 (un cp1252 cuyos bytes forman UTF-8 válido sale como UTF-8): la corrección vale para bytes inválidos con Python ≥ 3.15 y debe conservar esa salvedad en la misma celda. |
| C3-34 | PROCEDE | La regla de §0.3 (fecha de ejecución de cada salida) la fijó P-03 del ciclo 1 y C2-29/C2-49 la mantuvieron; dar las fechas en el Anexo E cumple la regla, no la reabre. |
| C3-35 | PROCEDE | Cumple DC-04 y C2-36 (saldo de prosa ≤ 0). La columna Δ medida con `wc -w` la deja C2-36 a cargo del autor del parche y ahora es medible. Condición: los recortes caen sobre prosa propia y repeticiones de tesis, nunca sobre citas verificadas ni evidencia (regla del PO, C1-17, C1-32, C1-43). |

## Dependencias de orden que este juez señala

- C3-03 decide antes que C3-01 (la definición por capa depende de qué decide la capa 2) y antes que C3-07.
- C3-01 decide antes que C3-06 y C3-07; C3-02 antes que C3-04 y C3-05. Los cinco van en el mismo parche que C3-08 y C3-09 (A.12, A.17, §12).
- C3-11 y C3-12 tocan A.10, A.4 y el laboratorio: volver a correr EA-1 una sola vez después de los dos.
- C3-35 fija la medición del lote; los parches que agregan texto (C3-21, C3-29, C3-33) cargan su Δ.
- Capa de origen con nota de solo agregado: O-5 y O-12 (pendientes de `Ciclo-2/05-Aplicacion.md` §6.3) más el acotamiento de C2-13 por C3-01, C3-02, C3-03 y C3-07; la nota de C1-05 en N7 L154 (C3-22); N4 (C3-32); el parche de ciclo 1 que introdujo `ImagenDigest` (C3-12).
- Decisiones que este voto **no** admite reabrir: C2-13 en lo que respecta a que el runner alcanza para 8a (opción (c) de C3-02); `Ciclo-2/03-Parches.md` §9 en el aviso de «sin lock» (C3-18 (a)); el orden de §12 de C1-39 (C3-20, segunda dirección). Decisiones que se acotan por E1 nuevo: el motivo «bit a bit» de C2-13 (C3-03) y el `ImagenDigest` del ciclo 1 (C3-12).
