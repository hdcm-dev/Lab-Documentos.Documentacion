# Mesa · Ciclo 1 · 04b — Aprobación (2.ª vuelta): juez de coherencia histórica

> Fecha: 2026-10-09. Rol: mesa de aprobación, juez de coherencia histórica (marco `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §5.5 y §6). Vuelta 2 de 2.
> Insumo: `03-Parches.md`, sección «Revisión 2» (P-23, R2-01 a R2-20). Contrastado contra: mi veredicto `04-Aprobacion-coherencia-historica.md` (MEJORAR_PLAN de P-23, tres filas faltantes), los otros cuatro `04-Aprobacion-*.md`, `04-Integracion.md` (CI-01…CI-12, §4, §10), `00-Contrato-De-Entrada.md` (DC-01…DC-07) y las anclas en `Nucleos/*.md`.
> Pregunta: ¿la revisión reabre una decisión cerrada sin evidencia nueva, o contradice otro veredicto del ciclo?

## Veredicto

**P-23 (Revisión 2): APLICAR.**

## Fundamento

1. **Mis tres pedidos están cubiertos, con anclas que verifiqué con `sed -n`.**
   - (1) N5: R2-15 anota L107 («**Digest en todo lo versionado** que nombra una imagen…»), L108, L318 y L372. La política que escribe es la dirección (b) 4-0 de C1-21, y sólo cita lo que Docker documenta [B113], con el resto **[no verificado]**. Era la condición de mi voto en C1-20, y respeta CI-06.
   - (2) N2: R2-07 (L105, «`*.slnx`, `*.csproj`, `*.props`, `*.targets` | UTF-8 sin BOM») y R2-08 (L288). Extienden CI-02 en los mismos términos de la síntesis de C1-10 que acepté en P-08: convención y no lector, `dotnet new console` con BOM (E2-6) y la rama cp1252. No la reabren.
   - (3) N4: R2-11 (L232, `Directory.Build.props (raíz): lock en todos los proyectos`), más R2-12 sobre N0 L185–L190, que no había pedido y que tiene el mismo origen. `RestoreLockedMode` y `ContinuousIntegrationBuild` quedan en `.props`, así que **CI-01** (condición única de CI) sigue intacta.

2. **Ninguna fila nueva reabre una decisión cerrada.**
   - R2-01, R2-02 y R2-05 bajan la rama ACP UTF-8 a pregunta abierta. Tocan `04-Integracion.md` §10, que era «pendiente / revalidar», no una decisión. Es lo mismo que aprobé en P-07.
   - R2-06 cambia el argumento de C1-36, pero conserva en A.2 la opción «la segunda» como **[criterio]**. La tensión cerrada «`eol` gana a `core.autocrlf`» no se toca.
   - R2-10 (pnpm ≥ 11 con `pmOnFail`) se apoya en E1 (AH-001) y [B196]. No hay ninguna CI cerrada sobre Corepack: CI-10 sólo fija la versión de Node.
   - R2-13 repite la lectura de [B83] que la revisión 1 ya puso en N0 L160. Las dos son consistentes.
   - R2-16, R2-17, R2-18 y R2-19 copian a la capa de origen las resoluciones de C1-29, C1-14, C1-12 y C1-05 que aprobé en P-13 y P-14. R2-17 conserva el «criterio por contexto» de 02 §4 / E8-5.
   - R2-20 es coherente con las notas de N6 L433 y N8 L321 de la revisión 1 (BuildKit nombra las bases, sin firma y con `builder.id` vacío).

3. **No contradice otros veredictos.**
   - Evidencia ya había aprobado P-23, y la revisión conserva las 16 filas originales tal cual.
   - Se cubren los pedidos de costo-beneficio (seis) y de riesgo (incluida la pasada de `grep`, con destino declarado para las 19 coincidencias y el límite del método escrito).
   - También el de impacto: hay notas de origen para P-10 y P-16 (R2-11, R2-12, R2-14), y el «en N3 no hace falta» está justificado.
   - R2-14 repite la objeción de costo-beneficio e impacto a P-10 («ninguna compuerta compara `requested` con `resolved`») sin adelantarse a cuál de sus dos opciones se elija.

4. **Se mantiene el mecanismo de solo agregado.** Las notas son fechadas, no se borra ninguna línea, y la verificación pide `git diff --numstat` o `wc -l`. El registro histórico queda auditable.

## Observación de orden (no bloqueante)

R2-11 y R2-14 dependen de que P-16 y P-10 tengan su revisión 2, que todavía no figura en `03-Parches.md`. R2-11 ya da por hecha la condición `Exe Or WinExe` que pidió impacto. Su punto 4 de verificación («se revisan contra el texto final… antes de aplicarse») evita que la bitácora afirme algo que la guía no adopte.

Condición de aplicación: P-23 se aplica **después** de cerrar las revisiones 2 de P-10 y P-16, o bien se aplica primero y R2-11 y R2-14 se ajustan en la misma pasada, como dice la propia fila. En ningún caso una nota de origen debe quedar diciendo distinto que el parche aprobado de la guía.

## Registro para el cierre

- La capa de origen queda completa para CI-02 (extendida), CI-05 y CI-06 y para la decisión N6 «sólo CI», con las notas de la revisión 1.
- No se reabre ninguna decisión del contrato ni de la integración sin evidencia nueva.
- No hay disparador de §6: no hay escalada al PO por coherencia histórica.
