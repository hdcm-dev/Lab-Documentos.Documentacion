# Mesa · Ciclo 1 · 04b — Aprobación, 2.ª vuelta: juez de impacto

> Fecha: 2026-10-09. Rol: juez de impacto en la mesa de aprobación (marco `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §5.5), segunda vuelta. Objeto: la «Revisión 2» de P-23 en `03-Parches.md` (L1213–L1304). Función objetivo: si esto no se corrige, ¿qué le pasa concretamente al lector de la guía, en el criterio que se forma y en los errores que comete al aplicarla?
> Insumos: `03-Parches.md` (Revisión 2), mi voto de la primera vuelta (`04-Aprobacion-impacto.md`), los núcleos de `Bitcora/Nucleos/`, `04-Integracion.md` y `evidencia-aprobacion-impacto/winexe-lock/`.

## 1. Qué había pedido y si está

En la primera vuelta voté APLICAR a P-23 y pedí que los ajustes de P-10 y P-16 dejaran nota en N4 y en N3/N0 con el mismo formato.

| Pedido | Fila | Juicio |
|---|---|---|
| Ajuste de P-16 (lock sólo en ejecutables, en `.targets`, **con `WinExe`**) en N4 | R2-11 | Cumplido. La condición `'$(OutputType)' == 'Exe' Or '$(OutputType)' == 'WinExe'` es la que medí en J-I1 (`salida-fix.txt`: WinExe y Web generan `packages.lock.json`, rc=0, SDK 8.0.425). |
| Ajuste de P-16 en N0 | R2-12 | Cumplido. Separa bien lo que depende de `OutputType` (lock, a `.targets`) de lo que no (`RestoreLockedMode`, `ContinuousIntegrationBuild`, quedan en `.props`). |
| Ajuste de P-16 en N3 | Tabla de cobertura | Justificación aceptada: P-16 no corrige nada que nazca en N3. |
| Ajuste de P-10 en N4 (falsa seguridad ante `NU1603` con lock) | R2-14 (y R2-13) | Cumplido por la vía (b): la nota dice que **ninguna compuerta compara `requested` con `resolved`** y que la defensa es revisar el diff del lock. Es la misma frase que evita la falsa cobertura en la guía, ahora también en el origen. |

## 2. Comprobaciones propias

| ID | Qué | Resultado |
|---|---|---|
| J-I6 | Las frases ancla de las filas, buscadas con `grep -F` en los núcleos | Aparecen en la línea citada (o dentro del rango citado): N1 L75, L78, L281, L328; N2 L90, L105, L288; N3 L82, L174; N4 L232, L331; N0 L185–L190; N5 L107, L108; N6 L427; N7 L131 y L152 (dentro de L129–L152); N8 L140, L225, L228, L230, L255; `04-Integracion.md` L245. La única que no coincide byte a byte es R2-14 (N4 L95): el archivo tiene `**sin advertencia**` en negrita. El punto 3 de la revisión dice «sin marcas», así que se encuentra igual. No bloquea. |
| J-I7 | ¿Las notas ya están aplicadas? | `grep -c "Corrección mesa ciclo 1"` da 0 en todos los núcleos y en `00`…`04`. Es lo esperado: P-23 se aplica después de la aprobación y antes que los parches de la guía. |

## 3. Impacto en el lector

Si la revisión 2 no se aplica, la bitácora conserva afirmaciones que ya se corrigieron en la guía: la rama «Windows con ACP UTF-8» como deducción plausible, «`.csproj` sin BOM porque la CLI no se lo agrega», el digest en el `image` del devcontainer, el lock en `.props` para todos los proyectos y una A = B que se compara en la estación. Cualquier regeneración o ampliación de la guía desde los núcleos las vuelve a meter. El lector de una edición futura volvería a activar la ACP UTF-8 como falsa solución, a dejar una WinForms sin lock sin enterarse y a fijar por digest una imagen que ningún bot actualiza en un repositorio privado. Esos son justo los errores de aplicación que esta mesa cerró.

La revisión además mejora lo que yo había aprobado en la primera vuelta:

- **Anclaje por frase.** Evita que una nota termine bajo el párrafo equivocado cuando se corra la numeración.
- **Pasada de `grep` con destino de cada coincidencia.** Hace que la afirmación «el origen quedó corregido» se pueda auditar, y declara su límite: no encuentra paráfrasis.
- **R2-04 (`file` no detecta cp1252).** Evita que el lector tome a `file` como diagnóstico cuando el archivo ya tenía mojibake.

## 4. Voto

**APLICAR.**

Observaciones no bloqueantes, que se resuelven al aplicar y no justifican otra vuelta:

1. R2-11, R2-12 y R2-14 dependen del texto final de las revisiones 2 de P-16 y P-10, que todavía no están en `03-Parches.md`. El punto 4 de la verificación ya obliga a cotejarlas antes de aplicar. Si P-16 cambiara la condición de `WinExe`, la nota R2-11 se ajusta en la misma pasada, como la fila prevé.
2. En R2-14, la frase ancla tiene que buscarse sin la negrita de `**sin advertencia**`.
