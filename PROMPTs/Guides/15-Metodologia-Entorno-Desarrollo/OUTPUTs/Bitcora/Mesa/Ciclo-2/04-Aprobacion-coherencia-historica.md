# Mesa · Ciclo 2 · 04 — Aprobación: juez de coherencia histórica

> Fecha: 2026-10-09. Rol: mesa de aprobación, juez de coherencia histórica (marco `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §5.5 y §6).
> Insumo: `03-Parches.md` de esta carpeta (P-01…P-23) y la simulación `evidencia-auditor/simulacion/guia-parcheada.md` (la guía con P-01…P-21 aplicados), que es donde se ve si un parche contradice a otro o a un veredicto cerrado.
> Pregunta: ¿el parche reabre una decisión cerrada (contrato DC-01…DC-07; `04-Integracion.md` CI-01…CI-12 y tensiones; ciclo 1: direcciones C1-03 (a), C1-08 (a), C1-10 síntesis, C1-18 (b), C1-21 (b), deudas D-1…D-7) o contradice otro veredicto, incluido mi voto `02-Voto-coherencia-historica.md` y las direcciones de §1 de `03-Parches.md`?
> Criterio, el mismo de los dos ciclos: reabrir es legítimo con evidencia nueva o con una mayoría del jurado del ciclo, **siempre que la reapertura quede escrita como tal** en la guía y en la capa donde vive la decisión; una deuda registrada se cumple; un parche que deja dos reglas incompatibles en la guía no corrige en la capa de origen y va a MEJORAR_PLAN.

## Veredicto

| Parche | Voto | Fundamento |
|---|---|---|
| P-01 | APLICAR | `version: 1.0.0` y `status: vigente` no reabren nada: P-01 del ciclo 1 dejó `borrador` hasta la relectura (DC-04), y el auditor ya condiciona el cambio a que el lote esté aprobado (§8 punto 7). Condición de orden: va al final, **después** de que se rehagan los parches en MEJORAR_PLAN de este voto; con una contradicción entre secciones abierta (S1 por el contrato) la guía no puede declararse vigente (`umbral_de_calidad`). |
| P-02 | APLICAR | Paga D-3 con fuente del fabricante [B209] y conserva el **[no verificado]** de Windows (C1-06). «Cuatro marcas de juicio» cumple C1-40 y corrige el error que el propio ciclo 1 introdujo (C2-40). «O el criterio para evaluarla» es la síntesis de C2-32 votada en §1.2; no toca el orden de §12 (C1-39). |
| P-03 | APLICAR | Aplica la regla de §0.3 («extracto literal; nunca altera una línea mostrada») que el ajuste A-2 del ciclo 1 ya hizo cumplir. |
| P-04 | APLICAR | Completa C1-49 con la nota decide/lidera, como voté en C2-22; «pasos 1–3, 5–7, 9 y 10» para ACT-ARQ es coherente con P-14, que suma ACT-ARQ al paso 7. |
| P-05 | APLICAR | Completa C1-24 (dos velocidades dentro de §3, sin reubicar §3.3). «Manifiestos de capas» queda alineado con la entrada que P-17 agrega al glosario. |
| P-06 | APLICAR | La excepción del cp1252 que forma UTF-8 válido cumple C1-56; la condición de plataforma pasa a Roslyn, como pidió evidencia (PEP 3120), sin contradecir la tabla de la misma sección. Python 3.15.0 calificado por versión es la dirección A 4-0 de C2-29. |
| P-07 | APLICAR | **Acepto la síntesis de C2-05.** No reabre C1-08 (a): la compuerta propia sigue siendo la de A.11 y por defecto; editorconfig-checker pasa de «alternativa» a «reemplazo del paso de texto **dentro de la misma** compuerta», que es lo que C1-08 (a) ya admitía («alternativa con sus límites») sin romper C1-05 («compuerta única») ni CI-11. Era mi dirección B; con esta lectura el empate no pasa a `INSUFICIENTE` por este juez. Variante B ampliada: coherente con R2-07 y CI-02. Observación no bloqueante en §3 (D-6). |
| P-08 | APLICAR | Corrige el texto de C1-31 con un E1 nuevo (pnpm 10.18.0) que su evidencia no tuvo: reapertura legítima y anotada en N3 (O-3). Conserva C1-03 (a): el costo de `disable` sigue declarado, ahora en un solo lugar (§6.4), y la tabla de dos políticas sigue entera (CI-05). La fila «con lock» suma `NU1603` y la compuerta: es C2-01 A + B. ESC-04 sin digest cumple C1-21 (b) (C2-23). |
| P-09 | APLICAR | Paga D-1 (`Exe Or WinExe`, la condición que R2-11 dejó escrita) y D-2 (compuerta `requested` = `resolved`, con su límite **[criterio]**). La nota de pruebas no cambia la regla «lock sólo en los ejecutables» de C1-26. |
| P-10 | MEJORAR_PLAN | **Deja dos reglas incompatibles en el mismo punto de §8.2.2 y reabre C1-21 (b) sin decirlo.** En la simulación, L1414: «**Digest en todo lo que construye artefactos publicados** … Para 8a también vale el runner alojado …». Y 8a publica artefactos («Artefacto, registro del entorno y SBOM publicados juntos», §12). La mayoría de C2-13 (A, 3-1) puede acotar C1-21 (b) 4-0, pero tiene que quedar escrito como acotamiento; no puede convivir con la regla vieja intacta en §8.2.2, §8.4 (L1539), §8.6 (L1563), §10.2.5 (L1937), B.3 (L3121) y B.4 (L3136). Además «también vale» / «alcanza para 8a» es juicio propio sin **[criterio]** (§0.3). Plan en §2. |
| P-11 | APLICAR | La compresión de §9.2.4 conserva lo que fijaron C1-17 («`builder.id` vacío … no alcanza L1»; «único determinante») y C1-32 (vía sin clave y su costo, clave en un job aislado detrás de aprobación, predicado verificado aparte [B10]), y suma C2-16 en dos oraciones: es la síntesis que voté en C2-15. Abre con el registro del entorno para el caso: C1-18 (b). ESC-04 sin digest: C1-21 (b). |
| P-12 | MEJORAR_PLAN | Todo el parche es coherente (C1-05 con descubrimiento por `git ls-files`, que C1-05 admitía; C2-05 síntesis; límite de `--staged` declarado, C2-09; pre-receive [B214] completa C1-19; `minimum_pre_commit_version` restituido), **salvo una fila**: el op de §10.2.5 escribe «¿Lo que construye artefactos publicados sigue por digest?», que contradice el runner alojado de P-10/P-14/P-15. Se alinea con la redacción de §2; el resto queda aprobado por este juez. |
| P-13 | APLICAR | (a)+(b)+(c) cumple C1-16; `version=v1` explícito resuelve D-4 a favor del **[criterio]** vigente de §9.2.4; §11.9 con E8-1 cumple C2-32 y la ruta mínima de §0.2; `verificar.sh` como compuerta propia de la solución, con A.11 para otros repos, cumple C2-06 (a). Al rehacer P-10, revisar que el (b) «digest de la imagen del job» no se lea como obligatorio con runner alojado (§11 pide imagen propia para la frontera A, así que hoy es coherente). |
| P-14 | MEJORAR_PLAN | Contradice a C1-18 (b) dentro de la misma tabla: el paso 7 dice que el runner alojado «alcanza para 8a» y el paso 8a, tal como lo deja el op 2, exige «digest de la imagen» en el registro, que con runner sale `imagen=NO DECLARADA` (A.17). La validación «registro del entorno sin campos vacíos» queda ambigua para ese camino. El contrato YAML completo (pasos 9 y 10) y la Práctica integradora sin experimentos nuevos son coherentes con C1-23, C1-39 y C2-33. Plan en §2. |
| P-15 | MEJORAR_PLAN | A.1, A.3, A.4, A.4b, A.9, A.10, A.11, A.17 y A.18 cumplen C1-10/CI-02, D-7 (C2-04), D-2, D-1, C1-21 (b) en el devcontainer, C1-07 y C1-27, y DC-06. Sólo la frase de la variante de A.12 («que alcanza para 8a») repite el defecto de P-10: va con **[criterio]** y con el costo declarado (capa 4 flota; A.17 escribe `NO DECLARADA` y su versión queda en el log «Set up job» [B216]). Los bloques no cambian, así que P-23 L3 sigue valiendo. |
| P-16 | MEJORAR_PLAN | Ops 1–4 aprobados (tres estados del repo de C1-10, las dos defensas, `GITHUB_ENV`, A.17). El op 5 repite en B.4 la pregunta «¿Lo que construye artefactos publicados sigue por digest?» y deja B.3 L3121 («Toda imagen que construye artefactos publicados va por digest») sin tocar: las dos chocan con el runner alojado. La verificación del propio parche («cada ítem remite a una sección que dice lo mismo») no se cumple en la simulación. |
| P-17 | APLICAR | Extiende C1-25 a «registro» y «manifiesto» sin reemplazo global (la restricción de riesgo de C2-35). |
| P-18 | APLICAR | Agrega fuentes; [B213] con «mover el digest» **[no verificado]** mantiene CI-06. Ninguna fila existente se borra. |
| P-19 | APLICAR | E3-3 nombra la versión que corrió el experimento; no contradice O-3 (la 10 ya hace cumplir `packageManager`; la 11 unifica en `pmOnFail`). EA-1 con los pasos nuevos acompaña a P-15 y P-23. |
| P-20 | APLICAR | C1-46 (trazas resueltas dentro de la guía) y C1-43 (fuera la decisión pendiente de SBOM) se cumplen; `builder.id` pendiente se levanta con E1 (C2-16), sin contradecir C1-17. |
| P-21 | APLICAR | La historia de rc.1 («digest y bot donde se construye lo publicado») queda como historia, que es lo correcto. Sugerencia no bloqueante, al rehacer P-10: que el detalle de 1.0.0 diga «acota el digest a la imagen propia (runner alojado para 8a)» en lugar de «los dos caminos de CI», para que el lector vea que la regla de rc.1 cambió. |
| P-22 | MEJORAR_PLAN | Las notas O-1…O-4, O-6, O-7, O-9…O-11 son correctas y de solo agregado. Faltan tres cosas para que la capa de origen no diga distinto que la guía: (1) O-5 no dice que acota C1-21 (b) y el 8a de C1-18 (b); (2) la decisión cerrada vive también en `04-Integracion.md` (nota C1-20/C1-21, L119) y no recibe nota; (3) la nota de C1-05 en N7 L154 sigue recomendando «para otra disposición, un inventario explícito, como en `verificar.sh` de N8», que el ciclo 2 retira (C2-06 (a)); O-8 está anclada en otra tabla (L335) y no la alcanza. Plan en §2. |
| P-23 | APLICAR | Laboratorio coherente con los parches aprobados (D-1, D-2, C2-05 síntesis, C2-06 (a), C2-12, C2-28 = D-4). Depende de que P-15 rehecho no toque los bloques (este voto sólo pide prosa fuera de bloque). Se mantiene la condición de riesgo: instantánea de `Examples/` antes. |

Resumen: 17 APLICAR, 6 MEJORAR_PLAN (P-10, P-12, P-14, P-15, P-16, P-22), 0 NO_APLICAR, 0 ESCALAR. Las seis MEJORAR_PLAN son un solo defecto visto desde seis lugares, y se resuelven con el mismo cambio de redacción.

## 1. Por qué no escalo

El defecto central (runner alojado frente a «digest en todo lo que construye artefactos publicados») no activa ningún disparador de §6:

- **No es el 7.** C1-21 (b) es un veredicto de la mesa del ciclo 1, no una entrada de `decisiones_cerradas` del contrato (DC-01…DC-07). Ningún DC habla de dónde corre la CI.
- **No es el 2.** Las dos lecturas caben juntas sin violar ninguna restricción dura: la regla de digest rige para la imagen propia, y el runner alojado queda como camino de 8a con su costo declarado.
- **No es el 3.** La guía no promete otra cosa: sigue contestando «con qué entorno se ensambló» con el registro del entorno (C1-18 (b)). Cambia cuánto de la capa 4 se fija en ese camino, y eso se declara.
- **No es el 6.** El jurado resolvió C2-13 en la primera ronda, 3-1.

Mi disidencia en C2-13 (dirección B) queda registrada en `02-Voto-coherencia-historica.md` y **no la reabro acá**: la mayoría decidió A. Lo que pide este voto es que A se aplique como acotamiento escrito y no como una segunda regla que convive con la vieja.

## 2. Plan de mejora (texto concreto)

Una sola redacción, que el auditor aplica en los seis parches. Las líneas son las de `simulacion/guia-parcheada.md`.

**2.1 Regla de §8.2.2 punto 1 (P-10, op 1).** El encabezado en negrita y la frase nueva quedan así:

> 1. **Digest en toda imagen propia que construye artefactos publicados**: el `FROM` de la imagen de CI y de los Dockerfile de build, y `container.image` de la CI. Se escribe `repo:etiqueta@sha256:…`: la etiqueta queda como referencia humana y manda el digest. **[criterio]** Para 8a también sirve un runner alojado, sin imagen propia, con acciones de *setup* por SHA que leen `global.json`, `.nvmrc` y `.python-version` [B181]. Su costo es que la imagen del runner (capa 4) flota: el registro del entorno la declara `NO DECLARADA` (A.17) y su versión queda sólo en el log «Set up job» [B216]. La imagen propia hace falta para 8b, para la reconstrucción bit a bit o para la frontera A en la CI (§11.2.5).

**2.2 Mismo alcance en el resto de la guía.** Reemplazar «Digest en todo lo que construye artefactos publicados» o «toda imagen que construye artefactos publicados» por «toda imagen **propia** que construye artefactos publicados (con runner alojado en 8a, §8.2.2)» en:

- §8.4, L1539 (op nuevo en P-10);
- §8.6, L1563 (op nuevo en P-10);
- B.3, L3121 (op nuevo en P-16).

La pregunta del revisor de §10.2.5 (L1937, P-12) y de B.4 (L3136, P-16 op 5) queda así: «¿Lo que construye artefactos publicados en una imagen propia sigue por digest, o el runner alojado está declarado en el registro? ¿El devcontainer usa etiqueta fija o la receta de la CI, y su SDK coincide con `global.json`?».

**2.3 §12 (P-14).**

- Op 1: «(alcanza para 8a)» pasa a «(alcanza para 8a **[criterio]**, con la capa 4 declarada en el registro)».
- Op 2: «digest de la imagen» pasa a «digest de la imagen propia o, con runner alojado, `imagen=NO DECLARADA` y la versión del runner tomada del log».
- Validación de 8a: «registro del entorno junto al artefacto, sin campos vacíos; con runner alojado, la imagen declarada como tal (A.17)».

**2.4 A.12 (P-15, op 14).** «Variante con runner alojado, que alcanza para 8a (§8.2.2)» pasa a «Variante con runner alojado, para 8a **[criterio]** (§8.2.2): la capa 4 flota y A.17 la declara `NO DECLARADA`». Los bloques no cambian.

**2.5 Capa de origen (P-22).**

- **O-5** suma al principio: «Acota C1-21 (b) (`Mesa/Ciclo-1/03-Parches.md` §1) y el contenido de 8a de C1-18 (b): el digest rige para la imagen propia; el runner alojado para 8a lo decidió C2-13 (A, 3-1, con coherencia en disidencia), con la capa 4 declarada como no fijada.»
- **O-12, nueva**, en `04-Integracion.md`, al pie de la nota `> **Corrección mesa ciclo 1 (2026-10-09, C1-20, C1-21).**` (L119): `> **Corrección mesa ciclo 2 (2026-10-09, C2-13, C2-01).** «Digest + bot en lo que construye lo publicado» se acota a la imagen propia; para 8a vale también el runner alojado con acciones de *setup* por SHA, con la capa 4 declarada en el registro [B216] (C2-13, A 3-1). La tensión «digest vs. parches de seguridad» sigue resuelta igual para la imagen propia. CI-05: \`NU1603\` como error pasa a las dos políticas, más la compuerta \`requested\` = \`resolved\` (C2-01). Guía §6.4, §8.2.2, §12 (Ciclo-2, P-08, P-10, P-14).`
- **O-8, segunda ancla**, en `Nucleos/N7-compuertas-y-gobierno.md`, al pie de la nota `> **Corrección mesa ciclo 1 (2026-10-09, C1-05).**` (L154): `> **Corrección mesa ciclo 2 (2026-10-09, C2-05, C2-06).** El alcance de arriba ya no vale: \`compuerta.sh\` busca \`.python-version\` y los locks en todo lo versionado (\`git ls-files\`) y sirve con proyectos en subcarpetas. \`verificar.sh\` de N8 deja de ofrecerse como pieza copiable para otra disposición (C2-06 (a)). Guía §10.2.2, A.11 (Ciclo-2, P-12, P-15).`
- **Verificación nueva** para el conjunto: en la guía parcheada, `grep -n 'construye artefactos publicados'` → cada coincidencia dice «propia» o remite a §8.2.2; `grep -c 'alcanza para 8a'` fuera de una marca **[criterio]** → 0. En la bitácora, `diff` contra la instantánea → sólo líneas `>` en `04-Integracion.md` y N7.

## 3. Observaciones no bloqueantes (deudas del ciclo 1)

- **D-5 sigue abierta.** Ningún parche agrega las tres notas de origen pendientes: N7 L332 y N8 L558 (C1-06, ESC-01) y N8 L474 (bloque `docker buildx`, C1-15). O las suma P-22, o `05-Aplicacion.md` del ciclo 2 las arrastra como deuda con ese ID.
- **D-6 sigue abierta.** El bloque del paso 5 de §5.2.6 conserva `|| { …; exit 1; }` (simulación, L783): pegado en una terminal interactiva, la cierra. P-07 toca §5.2.6 sin cerrarla. Como D-5: o se cambia por `if …; then …; fi`, o se registra.
- **D-7 se cumplió**: C2-04 (fin de soporte de .NET 8 en A.3) y el SHA de `actions/attest` resuelto el 2026-10-09 (§9.5). D-1…D-4 se pagan en P-09, P-02 y P-13.

Ninguna de las dos bloquea, porque eran observaciones minoritarias del ciclo 1. Pero la guía pasa a `1.0.0 vigente` (P-01), así que su destino tiene que quedar escrito en la aplicación del ciclo 2: una deuda que nadie nombra se pierde.

## 4. Registro para el cierre

- Decisiones del ciclo 1 que este lote **cumple**: C1-03 (a), C1-05, C1-08 (a) (vía la síntesis de C2-05), C1-10/CI-02 (ampliada), C1-16, C1-17, C1-24, C1-25, C1-32, C1-40, C1-43, C1-46, C1-56, y las deudas D-1…D-4 y D-7.
- Decisiones **acotadas por mayoría del ciclo 2**, que deben quedar escritas como tales (§2): C1-21 (b) y el contenido de 8a de C1-18 (b), por C2-13 (A, 3-1). La única disidencia es la de este juez.
- Decisiones **corregidas por E1 nuevo**: el texto de C1-31 (C2-30, O-3) y el `builder.id` pendiente de C1-Q07 (C2-16, O-6).
- Síntesis de C2-05: **aceptada** por este juez.
- No hay disparador de §6: no hay escalada al PO por coherencia histórica.
