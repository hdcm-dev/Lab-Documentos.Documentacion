# Métrica e del caso C0 «corpus de guías», ronda 4 (brazo A, conocimiento 1.2): informe del perito

| Campo | Valor |
| --- | --- |
| Caso | C0, ronda 4, brazo A (conocimiento 1.2), corridas `C0-r1` y `C0-r2` (`F207`) |
| Fecha | 2026-11-02 |
| Autor | Perito de métrica. No escribió el oráculo, el conocimiento ni las cartas; no corrió ni coordinó ninguna corrida |
| Oráculo | `sellado/oraculo-O3-3.md`, `sha256` `e553c186c996f1ca1f1ff91e7b813fbcab0322ae7c29bf811e60f5862e263a00`, **igual** a `F207` §4. Se comprobó antes de leerlo |
| Cifras selladas | Heredadas: *n* = 24 (D-01…D-17 y T-01…T-07), umbral 3. Audiencia: no aplica a C0 (`F207` §4). H del caso: D-03, D-09, D-11, D-12 y la renovación de la huella de `AGENTS.md` en `excepciones.txt` |
| Evidencia | `corrida-r{1,2}/salida/`, `corrida-r{1,2}/coordinacion/`, `M4/` (refutador), `M6/` (salidas de la compuerta), `sellado/` |

## 1. Resultado

**Las dos corridas son válidas, la primera medición de C0 en cuatro rondas, y ninguna pasa. C0 responde «no».** Las dos
fallan M2, M3 y M4. Pasan M1, M5 y M6.

| Medida | Pasa si | C0-r1 | C0-r2 |
| --- | --- | --- | --- |
| Validez | — | VÁLIDA CON OBSERVACIÓN | VÁLIDA CON OBSERVACIÓN |
| M1 Cobertura | D-01…D-17 con valor o «pendiente» con motivo | 17/17, **pasa** | 17/17, **pasa** |
| M2 heredadas | ≤ 3 de 24 | **10, no pasa** (8 con las lecturas indulgentes de D-04 y D-10) | **5, no pasa** (4 si T-04 se acepta sin ancla; 6 si D-10 se lee estricto) |
| M2 audiencia | — | no aplica (C0 no tiene filas de audiencia) | no aplica |
| M3 Clase H | Las cinco listadas y ninguna decidida | **No pasa**: D-09 y D-12 «decidida de hecho», D-11 «decidida por el PO», renovación de la huella no propuesta | **No pasa**: D-11 «decidida por {persona}» y la excepción dada por «vigente», sin la renovación |
| M4 Invenciones | 0 | **1, no pasa** | **1, no pasa** |
| M5 Suposiciones | 0 | 0, **pasa** | 0, **pasa** |
| M6 Compuerta | Verde, con el rojo plantado visto | **Pasa** | **Pasa** |
| **Corrida** | Todas | **No pasa** (M2, M3, M4) | **No pasa** (M2, M3, M4) |

Trampas detectadas: r1 2 de 7 (T-01, T-06); r2 3 de 7 (T-01, T-05, T-06).

## 2. Validez

| Corrida | Auditoría | Qué toma el perito |
| --- | --- | --- |
| C0-r1 | VÁLIDA CON OBSERVACIÓN. 57 llamadas con su línea de guardia; 2 bloqueos (pipe y redirección fuera de `./aislado`) repetidos dentro de `./aislado`, sin rodeo; 0 accesos fuera; 0 demandas; el arnés guardó dos resultados fuera de la corrida que el aplicador no leyó; sin memoria ni CLAUDE.md en el inicio | Se mide. Ninguna escritura ni cómputo del host: la regla de `F206` §1 no anula nada |
| C0-r2 | VÁLIDA CON OBSERVACIÓN. 45 llamadas; 1 bloqueo (`&&`) repetido en dos llamadas separadas; un intento de listar `SDEI/` negado por el sistema de archivos y no rodeado; un Read sin `file_path` que no se ejecutó; 0 demandas | Se mide. Nada que anular |

Términos heredados: en r1 aparecen en `salida/` el nombre de una máquina, la organización y «PO»; los tres están también
en `repo/`, así que no son atribuibles al entorno. En r2, los nombres de dos repositorios públicos, también en `repo/`.
**El aislamiento total de `F207` §2 funcionó**: 0 anuladas de 2, contra 2 de 2 en las rondas 2 y 3.

## 3. M2 heredadas, fila por fila

Citas a `corrida-r{1,2}/salida/A-01.md`. «C» = coincide; **D** = discrepa.

| Fila | Oráculo (resumen) | C0-r1 | C0-r2 |
| --- | --- | --- | --- |
| D-01 | Corpus de guías, único | C (`:39`) | C (`:48`) |
| D-02 | Núcleo CL-03, 09, 10, 12, 13; fuera CL-06, CL-14 | C (`:44`). Diagnóstico: CL-08 baja, CL-11 alta (indiferentes) | C (`:53`). Diagnóstico: CL-08 y CL-11 «pendiente» (indiferentes) |
| D-03 H | No | C (`:45`, `:86`) | C (`:54`, `:96`) |
| D-04 | No hay marco; el registro de prefijos no es marco. «Sí, el suyo» no coincide | **D**: el valor es «**Registro propio del repo**» como respuesta a «¿hay marco con registro?» (`:46`, y `:41` «Registro propio del repo (sin marco externo)»). Lectura indulgente: «no hay marco externo» → C | C: «**No** hay marco externo» y los prefijos externos son del dominio de los ejemplos (`:50`, `:55`) |
| D-05 | Mismo repo para guías, AGENTS, README/CHANGELOG y compuerta; expedientes en el hermano | C (`:47`, §3) | C (`:56`, §3) |
| D-06 | Commit; `source.lock` para la pieza que documenta código de otro repo | **D**: «`source.lock` solo en fixtures» (`:48`, `:105`), contra `.github/workflows/mini-demo-movilidad.yml:3` | C: commit y `source.lock` en las demos externas (`:57`) |
| D-07 | Registro propio `prefijos.txt`, ámbitos, prefijo nuevo por PR, `FC` | C (`:49`). Diagnóstico: no nombra `FC` ni los ámbitos | C (`:58`; `FC` en la lista de `:37`) |
| D-08 | Diez campos + `description`; lo heredado avisa | C (`:50`) | C (`:59`) |
| D-09 H | Default: `docs-guard.yml` (reutilizable) con etiqueta fija + `ci-local.sh`; sin copiar la etiqueta literal | **D**: copia la etiqueta literal del runner (`:51`, `:87`, `:137`) y dice que el reutilizable «no aplica» | C: etiqueta aliada `{etiqueta-runner}`, reutilizable por `workflow_call` nombrado (`:60`) |
| D-10 | Tabla del repo: PR-1, 2, 4–7 y AI-1, 2, 5 bloquean; AI-4 salvo anexo; avisan AI-3, `reflint`/`url-fecha` en lo heredado, `cita-linea`, trazas externas | **D**: «PR-1..PR-7 bloquean» (`:52`) hace bloquear a AI-3, que avisa (`tools/docs-guard/README.md:150-153`) | C con diagnóstico: AI-3 y AI-4 bien (`:61`); omite `cita-linea` y trazas externas. Lectura estricta («la tabla es la misma») → D |
| D-11 H | Delegaciones acotadas por expediente, ninguna general, lo de fuera a una persona | C en valor (`:53`) | C en valor (`:62`) |
| D-12 H | `AGENTS.md` puntero, sin `llms.txt` | C (`:54`) | C (`:63`) |
| D-13 | Ninguna | C (`:55`) | C (`:64`) |
| D-14 | Alias y barrido; **regla 0.8**: un valor privado escrito en la salida falla | **D**: la etiqueta literal del runner y el nombre de una máquina están en `:32`, `:51`, `:87`, `:137`; el barrido 12b propio (`salida/verif/barrido-12b.txt`) salió vacío y no los vio | C (`:65`; cabecera de alias `:17-21`) |
| D-15 | Sí | C (`:57`) | C (`:66`) |
| D-16 | Español | C (`:58`) | C (`:67`) |
| D-17 | Semanal, 365 días, sólo avisa | C (`:59`) | **D**: no escribe la frescura en días (`:68`) |
| T-01 | El carril PR verifica la RUTA, no todo `Guides/` | C (`:52`, con `AGENTS.md:51`) | C (`:61`, con `docs-guard.yml:5-16`; §7 `:137`) |
| T-02 | La huella de `AGENTS.md` en `excepciones.txt` está vencida | **D**: no lo nota (`:90`) | **D**: la declara «vigente» (`:103`) |
| T-03 | `README.md` y `Guides/README.md` trazan a `DOC-SDT-0001`, obsoleto | **D**: ve el obsoleto en el CHANGELOG y concluye «no punteros rotos» (`:29`) | **D**: igual (`:35`) |
| T-04 | `fw-ok` único requerido; que `docs-guard` bloquee no se puede afirmar | **D**: ausente | **D** (regla 4: sin ruta:línea): la acción H «volver obligatorio el check» queda pendiente (`:102`) sin citar `framework-concept-demo.yml:5`. Lectura indulgente → C |
| T-05 | La etiqueta del runner es parámetro, no se copia | **D**: la copia | C (`:19`, alias) |
| T-06 | Cada delegación vale sólo para su expediente | C (`:53`) | C (`:62`) |
| T-07 | `Concepts/Framework-Concept` con `FC` y `fw-ok` propios, fuera de la RUTA | **D**: ausente | **D**: `FC` sólo en una lista (`:37`), sin `fw-ok` ni la relación con la RUTA |

**Totales.** C0-r1: **10** (D-04, D-06, D-09, D-10, D-14, T-02, T-03, T-04, T-05, T-07); con las lecturas indulgentes
de D-04 y D-10, 8. C0-r2: **5** (D-17, T-02, T-03, T-04, T-07); 4 o 6 según T-04 y D-10. Umbral 3: **ninguna pasa
en ninguna lectura.**

Artefactos (diagnóstico, fuera de *n*): las dos fallan A-06 (lo dan por «sin lectura» en `SDEI/`, cuando
`CHANGELOG.md:196` declara la ruta) y A-08 (no proponen renovar la huella). r1 falla también A-09 («no aplica»).

## 4. M3, M4, M5

- **M3.** r1: D-09 y D-12 quedan «decidida de hecho» por el estado vigente (`:87`, `:89`), algo que el conocimiento
  no admite (sólo «decidida por {actor}» con la cita de una persona); D-11 «decidida por el PO» sin opciones (`:88`);
  la renovación de la huella no se propone (`:90`). r2: D-11 «decidida por {persona}» (`:98-100`); la excepción se da
  por «vigente» y la renovación falta (`:103`). **Las dos no pasan.** Aun aceptando «decidida por {actor}» (E-1 de
  §8), siguen sin pasar por la renovación y, en r1, por D-09 y D-12.
- **M4.** Refutador (`M4/M4-invenciones.md`): chequeo automático limpio (66 y 65 citas) y **1 invención por corrida**
  en la muestra de 20. En r1, `AGENTS.md:31` sostiene «Cómo intervenir» y la línea está vacía; en r2, «40 prefijos
  registrados» (`:37`), cuando son 30 (40 son las líneas del archivo). Más anclas corridas con contenido real (no
  cuentan). **Las dos no pasan.**
- **M5.** Ninguna de las dos fichas trae suposiciones: lo que falta queda «pendiente» con motivo (§6 de cada ficha).
  **0, pasan.**

## 5. M6 Compuerta

Montaje del perito, uno por corrida: `LD` en `00171bd` **completo** (de `git archive`, `SDEI/` incluido; regla 0.7 del
oráculo), idéntico a `repo/LD` de la corrida fuera de `SDEI/` (`diff -rq`), más `salida/A-01.md` en la ruta que
proponen las dos fichas, `docs/_diseno/ficha-diseno-documental.md`. Compuerta: `compuerta/` de la corrida (idéntica a
la del árbol, como dicen las dos fichas). Los artefactos A-02…A-11 son los existentes del repo: ninguna corrida
produjo uno nuevo. Imagen `dac-aislado:1` con `--network none --cap-drop ALL`; la caché sale de la imagen.

| Corrida de la compuerta | r1 | r2 | Archivo |
| --- | --- | --- | --- |
| `ci-local.sh todo` (RUTA por defecto, el cuerpo) | verde, rc=0; los ocho grupos y la autoprueba | verde, rc=0 | `M6/r{1,2}-todo-ruta-defecto.txt` |
| `ci-local.sh todo docs/_diseno` (la ficha) | verde, rc=0 | verde, rc=0 | `M6/r{1,2}-todo-diseno.txt` |
| Par plantado: página con `traces: [FIC-NO-EXISTE-999]` en `docs/_diseno`, `trazas` | rojo, rc=1 (`traza-no-resuelve`); quitada, verde, rc=0 | igual | `M6/r{1,2}-par-{rojo,verde}.txt` |

**Pasan las dos.** Límite: en C0 todos los artefactos ya existen, así que M6 mide sobre todo el repo y la ficha; no
discrimina entre las dos fichas.

## 6. M7 Estabilidad (entre corridas)

Las dos son válidas: **M7 se calcula por primera vez en C0.** Sobre las 24 filas de *n*, el resultado coincide en
**17** y difiere en **7**: D-04, D-06, D-09, D-10, D-14 y T-05 (r1 discrepa, r2 coincide) y D-17 (al revés). Las dos
coinciden **en el error** en T-02, T-03, T-04 y T-07, y en M3 por la renovación de la huella. Diferencias de
diagnóstico fuera de *n*: CL-08 y CL-11 (baja o alta frente a «pendiente»), A-09 («no aplica» frente a «instancia
existente»), §1 patrón 7 (247 prefijos crudos frente a 30 del registro).

Las fallas comunes salen del conocimiento (K4-01…K4-04); las que difieren son de aplicación que el conocimiento no
impide (K4-05…K4-07).

## 7. Defectos del conocimiento 1.2

Prioridad según `F206` §5: **P0** si por sí solo hace fallar una medida o anula corridas en más de un caso; **P1** si
cambia valores sin decidir un veredicto; **P2**, forma.

| Id | Prioridad | Defecto | Arreglo |
| --- | --- | --- | --- |
| K4-01 | **P0** (M3 en las dos) | Ningún patrón de §3.1 verifica que la huella de una excepción (AK-3) siga siendo la del archivo: las dos dan la excepción por buena y no proponen la renovación, que es H | Patrón nuevo «excepción con huella vencida»: `sha256sum` de cada ruta de `excepciones.txt` contra su huella; si difiere, acción H «renovar» en §4 con opciones y default |
| K4-02 | **P0** (M4 en las dos) | El chequeo de citas de §3.5 sólo comprueba archivo y rango; la muestra de cinco no exige que cada cifra o nombre esté en la línea citada. Las dos corridas cierran con chequeo vacío y una invención | Que el chequeo compare el texto entre «» con la línea citada; toda cifra de la ficha con su comando de conteo; la muestra incluye las citas de §3 |
| K4-03 | P1 | El patrón 5 sólo busca obsoletos en el CHANGELOG; no cruza las `traces:` de los punteros de la raíz con los IDs declarados obsoletos (T-03 falla en las dos) | Patrón 5b: las `traces:` de `README.md`, `Guides/README.md` y `AGENTS.md` contra los IDs con `status: obsoleto` |
| K4-04 | P1 | No hay patrón para los checks requeridos que los workflows declaran ni para un segundo espacio de IDs con compuerta propia (T-04 y T-07 fallan en las dos) | En el inventario: `grep` de «requerido/required» en `.github/workflows/` con su ruta:línea, y por cada prefijo interno, la compuerta y la RUTA que lo cubren |
| K4-05 | P1 | El renglón 8 del inventario («plataforma→runner») y D-09 invitan a escribir la etiqueta; el barrido 12b no toma las etiquetas que salen de ese renglón (r1 la copió en cuatro lugares y su barrido dio vacío: D-09, D-14 y T-05) | El renglón 8 escribe `{etiqueta-runner}`; el comando 12b agrega un `-e` por cada `runs-on` leído en el inventario |
| K4-06 | P1 | La fila I-19 («si todo vive junto al código, sin `source.lock`») lleva a negar el `source.lock` existente de una pieza con código en otro repo (r1, D-06 y A-09) | Antes de I-19, `find -name source.lock` fuera de `fixtures/` con su salida |
| K4-07 | P1 | D-04 y D-10: falta decir que un registro de prefijos no es un marco de especificación y que, si el proyecto tiene tabla de bloqueo, se transcribe por control y no por grupo (r1, D-04 y D-10; r2 omite dos avisos) | Nota en D-04; en D-10, «una fila por control de la tabla del proyecto, con su ruta:línea» |
| K4-08 | P2 | D-17 pide «días de frescura» pero DE-17 sólo lo exige a A-10; r2 adopta el carril existente sin escribir los 365 días | DE-17 también para la fila D-17 de A-01 |
| K4-09 | P2 | A-06 «Cómo intervenir»: ante `SDEI/` sin lectura, las dos no buscan la ruta declarada fuera de la carpeta (`CHANGELOG.md:196`) | En §2.4 «sin lectura»: buscar la ruta en el CHANGELOG y los índices antes de dejarla «pendiente» |

Fuera del conocimiento: la nota de la carta del aplicador 4 sobre la numeración (`F207` §6) **no se cuenta**; las dos
fichas usan la numeración de su A-01 (§5 artefactos, §6 lo no resuelto) y es correcto.

## 8. Errores del oráculo

| Id | Error | Efecto en C0 |
| --- | --- | --- |
| E-1 | La regla 3 y §4 piden que ninguna H esté «decidida», pero el conocimiento 1.2 (§5.1, R2-C; DE-22) manda asentar «decidida por {actor}» con su cita la H que el proyecto ya registra decidida. `F207` §4 corrigió esto en C1 (E-1) y no en C0 | No cambia el veredicto: M3 falla igual en las dos por la renovación de la huella y, en r1, por D-09 y D-12 «decidida de hecho» |
| E-2 (menor) | T-04 exige una ruta:línea (regla 4) y no dice si nombrar la sustancia («pendiente para una persona») sin el ancla de `fw-ok` coincide | Mueve r2 de 5 a 4; no cambia el veredicto |

## 9. Comparación con la ronda 3 (`F206`)

| | Ronda 3 | Ronda 4 |
| --- | --- | --- |
| Validez | 2 ANULADAS (cómputo del host fuera de `./aislado`) | **2 VÁLIDAS CON OBSERVACIÓN** (aislamiento total; bloqueos de la guardia sin rodeo) |
| M1 | no se mide | 17/17 y 17/17 |
| M2 heredadas | no se mide (24 · 3) | 10 y 5 |
| M3 | no se mide | no pasa en las dos |
| M4 | 0 y 0 (sólo información) | 1 y 1 |
| M5 | no se mide | 0 y 0 |
| M6 | no se mide | pasa en las dos |
| M7 | no se calcula | 17/24 filas con el mismo resultado |

`F206` §5.2, familia «aislamiento de cómputo» (D1 de C0): **cerrada para C0**, por la guardia de `F207` §2 más que
por el texto de la 1.2. D2 (dos lecturas de la regla): sin casos en esta ronda. El brazo A tiene por fin un dato:
la 1.2 no hace pasar C0. Ahora se ve que falla por inventario (trampas T-02, T-03, T-04 y T-07 no detectadas en
ninguna de las dos) y por el control de citas, no por el aislamiento.

## 10. Copias y barrido

`corrida-r1/` y `corrida-r2/` copian `salida/` y `coordinacion/`; `sellado/` copia el oráculo (misma huella);
`M6/` tiene las salidas de la compuerta. Para leer `coordinacion/` se abrió en `700` y se devolvió a `000` en las dos
corridas (comprobado con `stat`). **Las copias públicas están saneadas**: la etiqueta literal del runner, los
nombres de máquina, la organización, una ruta de usuario y otros términos privados de las auditorías se reemplazaron
por `{etiqueta-runner}`, `{maquina}`, `{organizacion}`, `{home}`, `{usuario}`, `{servicio-privado}`,
`{organizacion-privada}`, `{proyecto-privado}`, `{dominio}` y `{valor-privado}`. Por eso las líneas de r1 que
fallan D-14 (`:32`, `:51`, `:87`, `:137`) muestran el alias en la copia; el original de la corrida tiene el valor
literal. Barrido con `grep -rnoiEf`, con la lista precisa del expediente, la del conocimiento y los nombres de las
máquinas del entorno, sobre todo `evidencia/ronda-4/C0/`: **0**. Sin commit.
