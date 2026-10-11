# Mesa · Ciclo 1 · 04b — Aprobación, 2.ª vuelta: juez de riesgo e irreversibilidad

> Fecha: 2026-10-09. Marco: `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §5.5 (mesa de aprobación, vuelta 1 de 2 de mejora).
> Objeto: la «Revisión 2» de P-23 en `03-Parches.md` (sección `## Revisión 2`). El resto de los parches ya tenía mi APLICAR en `04-Aprobacion-riesgo.md` y no se vuelve a votar.
> Función objetivo: ¿la corrección es reversible? ¿qué se rompe en la guía si sale mal? Veto sólo si es irreversible y de severidad S3 o menor.
> Decisiones en esta vuelta: APLICAR | NO_APLICAR.

## Qué pedí en la 1.ª vuelta y qué trae la revisión

Mi MEJORAR_PLAN sobre P-23 pedía cinco grupos de notas en la capa de origen y una pasada de `grep`. Uno por uno:

| Pedido (04-Aprobacion-riesgo.md, fila P-23) | Fila de la revisión 2 | ¿Cubierto? |
|---|---|---|
| N1 L75/L78 (C1-35: la rama «Windows con ACP UTF-8» pasa a pregunta abierta) | R2-01, R2-02 (y R2-03, precisión sobre #83320) | Sí |
| `04-Integracion.md` L245 (ídem) | R2-05 | Sí |
| N2 L105 y L288 (C1-10: en .NET el BOM es convención; `dotnet new console` crea con BOM, E2-6) | R2-07, R2-08 | Sí |
| N5 L107, L108 y L372 (C1-20/C1-21: digest + bot en lo que construye lo publicado) | R2-15 (suma L318) | Sí |
| N8 L140 (C1-10) | R2-09 | Sí |
| N8 L230 (C1-29: A = B como prueba de regresión en la CI) | R2-16 | Sí |
| Pasada de `grep` de las frases que reemplazan P-03…P-17 | Punto 3, tabla «Destino de las 19 coincidencias», R2-04, R2-13, R2-18, R2-20 | Sí, con el límite del método declarado |

## Lo que comprobé

1. **Anclas.** Con `sed -n` sobre cada archivo de la bitácora (versión del 2026-10-09) confirmé que la frase citada está en la línea indicada en: N1 L75, L78, L281 y L328; `04-Integracion.md` L245; N2 L90, L105 y L288; N3 L82, L165, L174 y L252; N4 L95, L232 y L331; N0 L185–L190; N5 L107, L108, L318 y L372; N6 L427; N7 L129 y L152; N8 L140, L225, L228, L230, L255 y L491. Todas coinciden. Aunque la numeración se corra al insertar notas, la revisión fija que manda la frase. Así se elimina el riesgo de anclar una nota en el lugar equivocado.
2. **Estado previo.** `grep -c "Corrección mesa ciclo 1"` da 0 en los diez archivos de origen. No hay notas aplicadas a medias que puedan quedar duplicadas.
3. **Versionado.** La carpeta `Bitcora/` está **sin seguimiento** en git (`git status`: `??`). La verificación 2 de la revisión prevé este caso y compara `wc -l` antes y después. Cuando una nota sale mal, se revierte de forma determinista por su prefijo único (`> **Corrección mesa ciclo 1 (2026-10-09, C1-nn).**`), porque el registro es de solo agregado y no se borra ninguna línea original.

## Análisis de riesgo

- **Reversibilidad: total.** Son notas insertadas en archivos de trabajo, que no se publican ni migran nada y no tienen consumidores externos. No ejerzo veto.
- **Radio de rotura sobre la guía: nulo.** P-23 no edita la guía. Su efecto sobre ella es indirecto y favorable: deja de haber núcleos que contradigan lo que P-07, P-08, P-10, P-11, P-14 y P-16 escriben en la guía. Ese riesgo de reapertura en un ciclo posterior era justamente el motivo del MEJORAR_PLAN.
- **Afirmaciones nuevas sin evidencia.** Cada nota remite a un E1 (E1-13, E2-5, E2-6, E4-2, AH-001, `evidencia-auditor/…`, `evidencia-aprobacion-impacto/winexe-lock/`) o a una fuente con ID ([B83], [B113], [B196], [B202], [EV1-02], [EV5-26]). Lo que no se puede ejecutar acá (ACP UTF-8 en Windows y Dependabot sobre digests en un repo privado) queda rotulado **[no verificado]** con su motivo.
- **Dependencia abierta (riesgo residual bajo).** R2-11, R2-12 y R2-14 dependen del texto final de las revisiones 2 de P-16 y P-10: la condición `Exe Or WinExe` y que las compuertas comparen o no `requested` con `resolved`. La verificación 4 obliga a revisarlas contra ese texto antes de aplicarlas. R2-11 y R2-14 traen además su variante de ajuste. Si eso sale mal, el daño es una nota de bitácora desalineada, que se corrige en la misma pasada. No afecta a la guía.
- **Privacidad.** Las filas nuevas no nombran repositorios ni identificadores privados. Las referencias externas que aparecen (dotnet/roslyn, `dotnet/*`, GitHub, GitLab, Docker) son públicas.

## Condiciones (no bloquean el voto)

1. Antes de aplicar, hay que copiar los diez archivos de origen a una instantánea fechada dentro de `Bitcora/Mesa/Ciclo-1/`. Como la bitácora no está versionada, esa copia es lo que reemplaza a `git diff`. Después, la verificación 2 se corre contra esa copia (`diff` sólo con líneas `>`).
2. El orden se mantiene: P-23 (las 16 filas de la revisión 1 más las R2-01…R2-20) va antes que cualquier parche de la guía. R2-11, R2-12 y R2-14 se aplican al final, cuando ya esté cerrado el texto de P-10 y P-16 (verificación 4).
3. La verificación 3 (repetir el `grep` después de aplicar P-03…P-17) se registra con su salida en la bitácora.

## Voto

| Id | Voto | Fundamento |
|---|---|---|
| P-23 (Revisión 2) | APLICAR | Cubre todos los orígenes que señalé (N1 L75/L78, `04-Integracion.md` L245, N2 L105/L288, N5 L107/L108/L372, N8 L140/L230) y suma la pasada de `grep` con el destino de cada una de las 19 coincidencias y el límite del método declarado. Comprobé con `sed -n` las anclas de las 20 filas: coinciden. Sólo agrega notas de prefijo único sobre archivos de trabajo sin consumidores externos, así que es reversible por completo y no toca la guía. Cada nota se apoya en un E1 o en una fuente con ID, y lo que no se ejecutó lleva [no verificado]. Riesgo residual: R2-11, R2-12 y R2-14 dependen del texto final de P-10 y P-16, y eso lo cubre la verificación 4. Condiciones: instantánea previa (la bitácora no está versionada), orden de aplicación y registro del `grep` posterior. |

## Resumen

- APLICAR: P-23 (Revisión 2), con las tres condiciones.
- NO_APLICAR: ninguno. Veto: ninguno (todo es reversible). ESCALAR: no corresponde (ninguno de los disparadores de §6).
