# Mesa de aprobación, 2.ª vuelta: juez de costo-beneficio

> Fecha: 2026-10-09. Objeto: la «Revisión 2» de P-23 (capa de origen), en `03-Parches.md`, a partir de L1213. Pregunta del juez: ¿corregir (extensión, complejidad, riesgo de diluir) cuesta menos que el daño de no hacerlo? Vuelta 1 de 2 permitidas (marco §5.5).

## 1. Voto

| Parche | Voto | Fundamento |
|---|---|---|
| P-23 (Revisión 2) | **APLICAR** | En la primera vuelta pedí seis notas (`04-Aprobacion-costo-beneficio.md`, fila P-23). Las seis están: R2-01…R2-03, R2-06, R2-10, R2-16, R2-17 y R2-19. R2-10 y R2-17 se extienden a líneas vecinas que repiten la misma afirmación (N3 L174 y L252; N8 L491). En R2-19 se comprobó la condición que puse antes de agregar la nota. El costo sigue siendo bajo: son notas fechadas de solo agregado, en la bitácora y no en la guía, así que no la alargan ni la diluyen. Ninguna línea original se borra, y la verificación 2 lo controla con `wc -l` o con `git diff --numstat`. El daño de no aplicarla es concreto: la bitácora es el registro desde donde se retoma el trabajo (R-PO-5), y sin estas notas seguiría afirmando cosas que la guía ya corrigió. Por ejemplo, la rama «Windows con ACP UTF-8», contradicha por la prueba de #83320; el lock en `.props`, que no surte efecto; y el digest en el `devcontainer.json`. Las cuatro filas que agregó la pasada de `grep` (R2-04, R2-13, R2-18 y R2-20) agregan muy poco costo y cierran casos que yo no había encontrado. |

## 2. Cotejos hechos para este voto

| Qué | Contra qué | Resultado |
|---|---|---|
| Anclas de R2-01, R2-02, R2-03, R2-04 | `Nucleos/N1-…md` L75, L78, L328, L281 (`sed -n`) | La frase literal está en la línea citada |
| R2-05 | `04-Integracion.md` L245 | Coincide |
| R2-06, R2-07, R2-08 | `Nucleos/N2-…md` L90, L105, L288 | Coincide |
| R2-09, R2-16, R2-17, R2-18 | `Nucleos/N8-…md` L140, L230, L255, L228, L491, L225 | Coincide |
| R2-10 | `Nucleos/N3-…md` L82, L165, L174, L252 | Coincide |
| R2-11, R2-13, R2-14 | `Nucleos/N4-…md` L232, L331, L95 | Coincide. Las frases citadas están en la línea, salvo por la negrita (`**sin advertencia**`) |
| R2-12 | `Nucleos/N0-…md` L185–L190 | El comentario del *snippet* está en L186. Dentro del rango |
| R2-15 | `Nucleos/N5-…md` L107, L108, L318, L372 | Coincide |
| R2-19 | `Nucleos/N7-…md` L129, L152 | Coincide. L152 dice «el toolchain y el grafo no, porque son propiedades del repositorio entero» |
| R2-20 | `Nucleos/N6-…md` L427 | Coincide |
| Condición `Exe Or WinExe` (R2-11) | `evidencia-aprobacion-impacto/winexe-lock/salida-fix.txt` | SDK 8.0.425: WinExe y Web, rc=0, con `packages.lock.json` |

## 3. Observaciones (no bloquean)

- R2-11, R2-12 y R2-14 dependen de lo que digan al final las revisiones 2 de P-16 y P-10. La verificación 4 obliga a cotejarlas antes de aplicar. Basta con que el aplicador la cumpla. No hace falta otra vuelta.
- El límite del método de `grep` está declarado: no encuentra paráfrasis. Para ese riesgo, el costo de una búsqueda semántica completa sobre los nueve núcleos supera al daño. Las líneas que señalaron los jueces cubren los casos conocidos.

## 4. Resumen

- **APLICAR**: P-23 (Revisión 2).
- **NO_APLICAR**: ninguno.
