# Mesa · Ciclo 2 · 05 — Aplicación

> Fecha: 2026-10-09. Rol: editor de aplicación (marco `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §5.6).
> Insumos: `03-Parches.md` (P-01…P-23), los cinco `04-Aprobacion-*.md` y la forma ejecutable de los parches, `evidencia-auditor/simulacion/parches_guia.py`.
> Artefactos tocados: la guía `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (pasa de 1.0.0-rc.1 a **1.0.0**), su laboratorio `Examples/` y la capa de origen (`Bitcora/Nucleos/`, `Mesa/Ciclo-1/`).
> Todo lo que hizo la aplicación está en [`aplicacion/`](aplicacion/): scripts, instantáneas, registros de cada corrida y chequeos de cierre.

## 1. Resultado

- **Se aplicaron los 23 parches aprobados.** Ninguno quedó revertido al cierre. Cada uno tiene 3 o más votos `APLICAR` de 5 (§4).
- Hubo **dos ajustes de aplicación** (§3). Los dos salen del texto de un parche aprobado y ninguno agrega contenido:
  - AJ-1: los hashes de A.17 se tomaron de la salida regenerada de EA-1, como pide P-23 L4.
  - AJ-2: la fila «Escenario / contexto / actor» se movió a su lugar alfabético, como declara P-17.
- La guía queda en `version: 1.0.0` y `status: vigente`, con su fila en el control de cambios. Mide 3606 líneas y 54 267 palabras.
  - La prosa propia baja 46 palabras; evidencia y plantillas suman 950 (balance de `03-Parches.md` §2, reproducido).
  - `sha256` antes: `e7837762…52c4a1d9`. Después: `a2b78179…c48a691fd`.
- **Chequeos de cierre en verde (§5):**
  - 0 anclas rotas; índice = encabezados `##` (20 = 20).
  - 217 `[Bnn]` definidas = 217 citadas.
  - 39 rutas `Examples/…` y 3 enlaces relativos, todos existentes.
  - Los 11 diagramas mermaid renderizan con mermaid-cli 12.0.0; los 7 bloques YAML son válidos.
  - Privacidad: 0 apariciones de nombres privados.
  - Terminología: 0 apariciones de las cadenas retiradas.
- **Quedan abiertas, para el ciclo 3, las observaciones de los votos `MEJORAR_PLAN` en minoría (§6).** La más seria es la de coherencia: §8.2.2, §8.4, §8.6, §10.2.5, B.3 y B.4 siguen exigiendo digest donde P-10, P-14 y P-15 admiten el runner alojado para 8a. Ese juez condicionaba `vigente` a resolverla.
  - La versión 1.0.0 sale igual: la condición vinculante es la del juez de riesgo («los 23 parches entraron») y la instrucción de versionado del ciclo es ciclo 2 → 1.0.0.
  - La contradicción queda registrada aquí. El ciclo 3 (→ 1.0.1) es donde se resuelve.

## 2. Orden y condiciones de aplicación

Es el orden de `03-Parches.md` §8, con las cinco condiciones vinculantes del juez de riesgo (`04-Aprobacion-riesgo.md` §5).

| Paso | Qué se hizo | Evidencia |
|---|---|---|
| 1. Instantánea | Copia de la guía y de `Examples/` a `aplicacion/antes/`, antes del primer op. La guía coincide con la que juzgó la mesa: `sha256 e7837762…`. Hay 751 archivos de `Examples/` con hash. | `aplicacion/antes.sha256`, `aplicacion/antes-examples.sha256` |
| 2. P-22 | Once notas de solo agregado en diez archivos, con su instantánea previa. | `aplicacion/p22.py`, `aplicacion/instantanea-origen/` |
| 3. P-18 | Bibliografía B205–B217. Se aplica primero para que existan cuando las citen los demás parches. | `aplicacion/log-guia.txt` |
| 4. P-23 | L1–L8 en `Examples/`, cada uno con su corrida (§4.2). | salidas regeneradas en `Examples/` |
| 5. P-01…P-21 | Se aplican en orden sobre la guía real con `aplicacion/aplicar.py`, que usa los ops de `parches_guia.py` y falla si un ancla no es única. Después de cada parche corre su verificación inmediata (`aplicacion/verif.py`). | `aplicacion/log-guia.txt`, `aplicacion/verif-log.txt` |
| 6. Verificación final | Los criterios de cada parche se vuelven a correr sobre la guía completa: **96 comprobaciones, 96 OK**. | `aplicacion/verif-final.txt` |
| 7. Versión | `1.0.0` / `vigente` (P-01) y la fila del control de cambios (P-21). La condición del juez de riesgo («sólo si los 23 entraron») se cumple. | — |

**Gating por corrida** (condición 3 del juez de riesgo). Los parches que dependían de una corrida del laboratorio entraron después de que esa corrida diera lo esperado:

- P-07 (§5.5): EA-1 paso 1 da `25 archivo(s)`.
- P-12: N7 y el caso (d) reproducen X3 y X6.
- P-13: E8-6 da `https://slsa.dev/provenance/v1`.
- P-19: EA-1 tiene los pasos 1c, 2c, 8, 9 y 10.

**Equivalencia con la simulación.** Antes de tocar la guía, los 20 parches restantes se aplicaron a una copia ya parcheada con P-18. El resultado es igual byte a byte a `evidencia-auditor/simulacion/guia-parcheada.md`, así que adelantar P-18 no cambia nada. La guía real, después de P-01…P-21 y antes de los ajustes de §3, también dio igual a la simulación.

**Primer intento descartado.** El primer pase aplicaba cada parche y lo revertía si su verificación inmediata fallaba. Cinco criterios fallaron:

| Parche | Criterio que falló | Qué parche lo cierra |
|---|---|---|
| P-06 | `prevista para el 2026-10-09` | P-20 (Anexo F) |
| P-07 | bloque B de A.1 | P-15 |
| P-08 | `pnpm ≥ 11` | P-19 (Anexo E) |
| P-10 | `safe.directory` en A.9 | P-15 |
| P-11 | `ilustrativ` = 4 | P-15 (A.12) |

En los cinco casos, el criterio mide el estado final del lote y lo cierra un parche posterior. Revertir en ese punto habría sacado parches correctos. Por eso se volvió a partir del estado posterior a P-18 (`pre-P-01`) y se adoptó esta regla: se aplica todo en orden, y sólo se revierte lo que siga fallando en la verificación final. Ninguno siguió fallando. El intento descartado queda en `aplicacion/log-guia-intento1.txt` y `aplicacion/verif-log-intento1.txt`.

## 3. Ajustes de aplicación

| ID | Parche | Qué falló | Ajuste | Por qué no excede lo aprobado |
|---|---|---|---|---|
| AJ-1 | P-15 (A.17), por P-23 L4 | Verificación de P-15: el bloque `text` de A.17 trae `commit=6f6df869…` y `out/App.dll=2bcec512…`, que salen de `x7-ea1-propuesto/salida.txt` (corrida del auditor). La regeneración de `Examples/A-plantillas/salidas/EA-1-plantillas.txt` da `commit=9fc4bb38…` y `out/App.dll=d6cc63cb…`. El commit del repo de juguete cambia en cada corrida; las otras 114 líneas son iguales. | Se cambiaron esas dos cadenas por las de la salida versionada. | P-23 L4 dice: «Las líneas de A.17 (commit y hash de la DLL) se copian de esa salida», o sea la de `Examples/`. Y la verificación de P-15 exige que el bloque coincida con el paso 9 de EA-1. |
| AJ-2 | P-17 (Anexo C, op 0) | Verificación de P-17 («orden alfabético conservado»): el op 0 inserta «Escenario / contexto / actor» antes de «Enfriamiento». | **Revertido y reaplicado.** Es la misma fila, con el mismo texto, entre «Entorno de construcción» y «Etiqueta». «VS» antes de «Verificación…» se deja como está: sigue la convención del glosario de poner la sigla primero (ADR/Acto, BOM/Bind). | El parche declara «filas nuevas en orden alfabético». Lo que se corrigió es el ancla del op, no su contenido. |

Script: `aplicacion/ajustes.py`. Los dos ajustes son reversibles con `aplicacion/antes/`.

## 4. Changelog: hallazgo → veredicto → parche → verificación → versión

### 4.1 Parches sobre la guía

La columna «Inmediata» muestra la falla que tuvo la verificación justo después de aplicar el parche. «Final» muestra el resultado sobre la guía completa. Todos entran en la versión **1.0.0**.

| Parche | Hallazgos | Veredicto de aprobación | Ops | Inmediata | Final |
|---|---|---|---|---|---|
| P-01 | C2-56, C2-49, C2-34, C2-14, C2-53 | 5/5 APLICAR (riesgo: condicionado a la versión al final) | 7 | índice: 1 ancla rota (el título del Anexo F lo cambia P-20) | 4 OK |
| P-02 | C2-32, C2-33, C2-51, C2-49, C2-40, C2-27, C2-24, C2-10, C2-37 | 5/5 APLICAR | 10 | — | 6 OK; el comando de §0.4, corrido tal cual, da `buildx v0.35.0` |
| P-03 | C2-27 | 5/5 APLICAR | 4 | — | 2 OK (`grep -Fx` contra `e1-roslyn-sdk8.txt`) |
| P-04 | C2-22, C2-52 | 5/5 APLICAR | 4 | — | 3 OK |
| P-05 | C2-37, C2-38 | 5/5 APLICAR | 8 | — | 3 OK. `*Aplica*` 64 → 64; pasa a 63 recién con P-21, la pérdida aceptada por riesgo |
| P-06 | C2-49, C2-58, C2-31, C2-29 | 5/5 APLICAR | 13 | `prevista para el 2026-10-09` (la cierra P-20) | 5 OK |
| P-07 | C2-12, C2-05, C2-08, C2-50 | 5/5 APLICAR (riesgo: gating por EA-1) | 13 | §5.9.2 contra A.1 (la cierra P-15) | 4 OK; EA-1 1c: 2 → 0 violaciones; paso 1: 25 archivos |
| P-08 | C2-30, C2-41, C2-57, C2-01, C2-04, C2-23, C2-50, C2-51, C2-32 | 5/5 APLICAR | 18 | `pnpm ≥ 11` en el Anexo E (la cierra P-19) | 8 OK |
| P-09 | C2-01, C2-02, C2-03, C2-37, C2-42, C2-46, C2-47, C2-50 | 5/5 APLICAR | 19 | — | 6 OK; EA-1 paso 8 `pide [8.0.2, ) y resolvió 9.0.0`; 2c `packages.lock.json: SI` |
| P-10 | C2-13, C2-17, C2-11, C2-24, C2-37, C2-50 | 4/5 APLICAR (coherencia: MEJORAR_PLAN) | 9 | `safe.directory` en A.9 (la cierra P-15) | 5 OK; EA-1 paso 10 `"outcome":"success"` |
| P-11 | C2-15, C2-16, C2-45, C2-23, C2-54, C2-26, C2-39, C2-14, C2-32, C2-50 | 5/5 APLICAR | 17 | `ilustrativ` = 3 (la cierra P-15) | 8 OK; §9.2.4: 598 palabras |
| P-12 | C2-05, C2-06, C2-07, C2-03, C2-09, C2-19, C2-20, C2-44, C2-23, C2-25, C2-54, C2-37, C2-32, C2-38, C2-50, C2-35 | 4/5 APLICAR (coherencia: MEJORAR_PLAN; riesgo: gating) | 27 | — | 7 OK; `pre-commit validate-config` con 4.4.0: rc=0 |
| P-13 | C2-35, C2-43, C2-52, C2-21, C2-48, C2-06, C2-27, C2-28, C2-14, C2-32, C2-50 | 5/5 APLICAR (riesgo: gating por E8-6) | 30 | — | 7 OK |
| P-14 | C2-13, C2-14, C2-55, C2-33 | 4/5 APLICAR (coherencia: MEJORAR_PLAN) | 5 | — | 3 OK; YAML de §12 válido, 11 validaciones |
| P-15 | C2-12, C2-04, C2-57, C2-01, C2-02, C2-11, C2-07, C2-05, C2-06, C2-08, C2-13, C2-14, C2-17, C2-18, C2-26, C2-53 | 3/5 APLICAR (coherencia e impacto: MEJORAR_PLAN) | 15 | A.17 contra EA-1 paso 9 → **AJ-1** | 7 OK; `anexoA.py`: 22 de 22 bloques iguales a `A-plantillas/repo/` |
| P-16 | C2-12, C2-01, C2-02, C2-23, C2-08, C2-26, C2-14 | 4/5 APLICAR (coherencia: MEJORAR_PLAN) | 5 | — | 2 OK; B.4 con 8 ítems |
| P-17 | C2-35, C2-52 | 5/5 APLICAR | 5 | orden alfabético → **AJ-2** | 6 OK |
| P-18 | C2-49, C2-04, C2-10, C2-16, C2-17, C2-18, C2-20, C2-26, C2-29, C2-30, C2-41, C2-02, C2-13 | 5/5 APLICAR | 3 | 217 definidas; B205–B217 todavía sin citar (las citan los parches siguientes) | 217 = 217 (`checks.py`) |
| P-19 | C2-30, C2-02, C2-07, C2-11, C2-12, C2-14 | 5/5 APLICAR (riesgo: gating por EA-1) | 2 | — | 2 OK |
| P-20 | C2-34, C2-16, C2-29, C2-49, C2-42, C2-04 | 5/5 APLICAR | 10 | — | 5 OK |
| P-21 | C2-36, C2-37, C2-40, C2-56 | 5/5 APLICAR | 1 | — | 3 OK; la celda más larga tiene 21 palabras; la fila 1.0.0 coincide con `version:` |

### 4.2 Capa de origen y laboratorio

| Parche | Hallazgos | Veredicto | Qué se hizo | Verificación |
|---|---|---|---|---|
| P-22 | C2-01…C2-03, C2-05…C2-09, C2-11…C2-17, C2-23, C2-25, C2-26, C2-29, C2-30, C2-31, C2-40, C2-41, C2-48 | 3/5 APLICAR (coherencia y evidencia: MEJORAR_PLAN) | O-1…O-10 se insertan al pie del bloque ancla en N1–N8. O-11 va al final de `Mesa/Ciclo-1/03-Parches.md` y `05-Aplicacion.md`. | `diff` contra `aplicacion/instantanea-origen/`: 0 líneas `<` en los 10 archivos, sólo líneas `>`. Hay 11 notas «Corrección mesa ciclo 2» y 2 «Nota de solo agregado (ciclo 2». El grep de privacidad da 0. |
| P-23 L1 | C2-03, C2-05, C2-06 | 4/5 APLICAR (impacto: MEJORAR_PLAN) | `N7/compuerta/compuerta.sh` se reemplaza por la propuesta. `compuerta.diff` aplicado sobre el original da ese mismo archivo (`cmp`). | Se volvió a correr `bash correr-todo.sh` de N7 (2 min). Las líneas `resultado=`, `rc=` y `[FALLA]` de E7-01…E7-07 son iguales a las anteriores. Sólo cambian los hashes de los repos de juguete, los tiempos de V7-01 y una línea nueva `[ok] … requested = resolved` en E7-01. La guía no cita ninguno de esos hashes. |
| P-23 L2 | C2-07 | idem | Caso (d) en `probar-prerrequisitos.sh`. | `salidas/e7-prerrequisitos-de-la-compuerta.txt`: `falta el paquete EditorConfig de Python (EditorConfig==0.17.1; …)`, rc=1 |
| P-23 L3 | C2-01, C2-02, C2-08, C2-11, C2-12, C2-13, C2-14, C2-53 | idem | `A-plantillas/repo/` es igual a `x7-ea1-propuesto/repo/` (`diff -rq` vacío). `registrar-entorno.sh` queda con modo 755. | `anexoA.py`: 22/22 iguales a la guía |
| P-23 L4 | C2-02, C2-11, C2-14, C2-18, C2-26 | idem | `verificar.sh` de diez pasos. | `salidas/EA-1-plantillas.txt` (1 min 16 s, rc=0): 116 líneas, iguales a `x7-ea1-propuesto/salida.txt` salvo el commit y el hash de la DLL (AJ-1). |
| P-23 L5 | C2-48 | idem | Comentario de `ConstruirPoliglota` en `Saludo.csproj`. | Se volvió a correr E8-3: la DLL sigue siendo `4dd5d90f…`. La salida se regeneró porque el comentario corre una línea los números `Saludo.csproj(41,5)` → `(42,5)`; no hay otro cambio, y la guía no cita esos números. |
| P-23 L6 | C2-14 | idem | `imagen=${IMAGEN_DIGEST:-NO DECLARADA (…)}`. | `grep desconocida` en `solucion/`: 0 |
| P-23 L7 | C2-28 | idem | `--provenance=mode=max,version=v1`. | `salidas/E8-6-comando-de-la-guia.txt`: rc=0, `https://slsa.dev/provenance/v1`, `builder.id: ''`, cinco materiales. Corrió con un `DOCKER_CONFIG` temporal que enlaza `cli-plugins` (buildx v0.35.0). |
| P-23 L8 | C2-05, C2-06, C2-07 | idem | Sección «Ampliaciones de la revisión (ciclo 2, 2026-10-09)» en `Examples/README.md`, `A-plantillas/README.md` y N7. La fila de `compuerta.sh` en N7 dice ahora que busca en todo lo versionado. | Los README nombran sólo archivos que existen. |

En `A-plantillas/README.md` se cambió además una frase que remitía a «`verificar.sh` de N8 si los proyectos viven en subcarpetas». Ahora remite a la compuerta de N7, que los encuentra. Es la misma corrección que C2-06 (a) hizo en la guía (P-12, P-15), llevada al README que L8 actualiza.

Los archivos de `Examples/` que cambiaron están listados en `aplicacion/examples-cambiados.txt`: 30 archivos, 18 de ellos salidas o README.

## 5. Chequeos mecánicos de cierre (guía 1.0.0)

| Chequeo | Herramienta | Resultado |
|---|---|---|
| Índice ↔ encabezados, anclas | `aplicacion/checks.py` (el del ciclo 1) | 183 encabezados, 91 enlaces internos, 0 rotos, 0 slugs duplicados; índice en orden con los `##` (20 = 20) |
| Enlaces relativos y rutas `Examples/` | ídem | 3 enlaces relativos y 39 rutas citadas; 0 inexistentes |
| Bibliografía | ídem | 217 definidas = 217 citadas |
| Experimentos | ídem | 71 IDs en el cuerpo, todos con fila en el Anexo E |
| Bloques de código | ídem | todos cerrados |
| Mermaid | `minlag/mermaid-cli` 12.0.0, contenedor | 11 de 11 renderizan; ningún SVG contiene «Syntax error» (`aplicacion/cierre/mermaid.txt`) |
| YAML | PyYAML 6.0.3 en `python:3.12-slim` | 7 de 7 válidos; el `.pre-commit-config.yaml` de §10.5 pasa `pre-commit validate-config` con pre-commit 4.4.0 (`aplicacion/cierre/yaml-precommit.txt`) |
| Privacidad | `grep -ciE -f <patrón-R-PRIV>` | guía 0; `Examples/` 0 archivos; notas del ciclo 2 en la capa de origen 0 |
| Terminología: cadenas retiradas | `grep -cF` | 0 en cada una: `Windows + VS \|`, `pnpm ≥ 11`, `mismo diseño`, `únicas cinco`, `prevista para el 2026-10-09`, `Sólo Python falla siempre`, `Este comando no pide`, `cerrado de cinco`, `verificar.sh de N8` |
| Terminología: «registro de entorno» | `grep -c` | quedan 2, las dos dentro de bloques que copian archivos del laboratorio (A.16 y el extracto de `publicar.sh`), como prevé `03-Parches.md` §9 |
| Marcas de juicio fuera de código | script de `aplicacion/cierre/privacidad-terminologia.txt` | 132, como antes, todas en negrita. `[no verificado]` 38 → 34 y `[observado]` 3 → 7 (cuatro pasan a dato con versión) |
| Anexo A = laboratorio | `aplicacion/anexoA.py` (MAP ampliado a A.17 y A.18) | 22 de 22 bloques-archivo iguales byte a byte; dos bloques no son archivos (la variante de A.12 y la salida de A.17) |

## 6. Lo que no se aplicó y queda abierto

Los votos `MEJORAR_PLAN` quedaron en minoría: ningún parche tuvo menos de 3/5 `APLICAR`. Sus pedidos no se aplicaron, porque no forman parte del lote aprobado. Quedan como insumo del ciclo 3:

1. **Digest y runner alojado (coherencia, P-10, P-12, P-14, P-15 y P-16).** §8.2.2 dice «Digest en todo lo que construye artefactos publicados» y, en el mismo punto, admite el runner alojado para 8a. Lo mismo pasa en §8.4, §8.6, §10.2.5, B.3 y B.4. Además, el paso 8a de §12 pide el digest en el registro, que con runner sale `NO DECLARADA`. Hace falta escribirlo como acotamiento de C1-21 (b) y C1-18 (b), con **[criterio]**. Es la única contradicción entre secciones que queda abierta, y es la razón por la que ese juez no daba la guía por `vigente`.
2. **A.17 depende del nombre del workflow (impacto, P-15 y P-23).** Si el lector guarda A.12 como `compuerta.yml`, el registro escribe `imagen=NO DECLARADA (runner sin contenedor…)` aunque la build corra en el contenedor. La propuesta es una variable `WORKFLOW_FILE` que falle si el archivo no existe, más un comentario con el nombre del archivo. Como opción, en L1 usar `git ls-files -z` con `while read`, para no partir rutas con espacios.
3. **Capa de origen incompleta (coherencia y evidencia, P-22):**
   - O-12, en `Mesa/Ciclo-1/03-Parches.md`, para C2-19, C2-20 y C2-21.
   - Una nota en `04-Integracion.md` (C1-20/C1-21).
   - La nota de C1-05 en N7 L154, que sigue recomendando «un inventario explícito, como en `verificar.sh` de N8».
   - O-5, que debería decir que acota C1-21 (b) y C1-18 (b).
4. **Lo que `03-Parches.md` §9 deja fuera por decisión:**
   - el aviso de «ejecutable sin lock»;
   - editorconfig-checker por defecto;
   - el hook que falla con un lock sin marcar;
   - la versión de la imagen del runner en el registro;
   - el reemplazo global de «registro»;
   - un script para los mensajes de Yarn, pnpm, uv y Poetry;
   - la verificación en Windows (sigue **[no verificado]**).

## 7. Supuestos registrados

- La fecha de la aplicación es la del sistema, 2026-10-09: es la misma de `03-Parches.md` y de las aprobaciones. La «fecha de hoy» del contexto común (2026-10-07) es la de la primera versión integrada.
- Ningún criterio de verificación tiene un formato de «aprobado» explícito. Cuando el texto del criterio era ambiguo, `verif.py` mide lo verificable y lo deja escrito:
  - «67 de 67 preguntas con *Aplica*» de P-05 se midió como «el conteo de `*Aplica*` no baja».
  - «la fila EA-1 nombra los pasos» de P-19 se midió como «nombra lo que comprueba cada paso nuevo».
- Las salidas de N7 y E8-3 versionadas en `Examples/` se reemplazaron por las de esta corrida, con veredictos iguales. Las anteriores están en `aplicacion/antes/Examples/`.
- No se hizo `git commit` ni `push`. La carpeta de la guía sigue sin rastrear.
