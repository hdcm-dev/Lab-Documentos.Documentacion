# Ciclo 3 · Aprobación, 2.ª vuelta · Juez de evidencia

> Fecha: 2026-10-09. Rol: juez de evidencia (¿cada hallazgo está probado al nivel que declara?).
> Insumo: `03-Parches.md`, sección «Revisión 2 · P-01 y P-19». Guía bajo revisión: 1.0.0, sha256 `a2b78179b2507f0aed0648d8e02d05bbd5797e1f0376efcc2b29f74c48a691fd`, la misma que declara el auditor (verificado con `sha256sum`).
> No se tocó la guía, ni `Examples/`, ni el prompt del PO. Lo reproducido corrió sobre copias en el scratchpad de la sesión.

## 1. Qué reproduje (E1, 2026-10-09)

1. **Anclas sobre la guía 1.0.0.** `grep -cF` de cada ancla de las ops 9 a 15 de P-01: las siete dan **1**. Están en L96 (op 9), L546 (op 10), L1031 (op 11), L1416 (op 12), L1487 (op 13), L1706 (op 14) y L1959 (op 15).
2. **Simulación.** Copié `simulacion/guia-parcheada.md` (sha256 `e65a650b…`, 55 241 palabras con `wc -w`) y corrí `python3 -I r2-p01-p19/r2.py`. No hubo ninguna `FALLA`. La copia resultante tiene sha256 `eb7d1673b3ff…` y **55 279** palabras: coinciden el hash y el +38 que declara el auditor.
3. **Verificación de P-19 sobre la copia.** `version: 1.1.0` en L5 y fila `| 1.1.0 |` en el control de cambios: coinciden. La celda tiene 7 palabras (≤ 21). `grep -c 'Práctica de §3'` → 0. `grep -c 'cuatro marcas de juicio (§0.3)'` → 1. `**[no verificado]** (requiere Windows)` → 0 antes y 0 después de r2, así que el conteo de P-23 no cambia.
4. **Clasificación de las marcas, con un clasificador propio** (no el del auditor). Toma cada `**[no verificado]**` y lo cuenta como «sin motivo» si no lo sigue un paréntesis o si el paréntesis empieza con `§`. Resultado sobre la copia r2: **36 marcas, 20 sin motivo**. Antes de r2, sobre la simulación, eran 35 y 26. La cuenta cierra: 26 − 7 (las siete marcas de las ops 10 a 15; la op 11 tiene dos) + 1 (la mención nueva del párrafo 1.1.0) = 20.
   - Clase (a), metatexto: L93 (definición), L97 (regla), L3638 (párrafo 1.1.0). Son 3.
   - Clase (b), Windows, Visual Studio, Git Bash o ESC-01: L113, L385, L483, L498, L530, L690, L713, L812, L832, L1046, L1056, L1119, L1243, L2000, L2333, L2868, L2870. Son 17. Abrí el contexto de cada una. L483 es la estación Windows con la opción beta de UTF-8. L1119 está bajo «¿Qué respeta y qué ignora una estación Windows con Visual Studio?». Las demás nombran Windows, Visual Studio, Git Bash o ESC-01 en la misma oración o en la misma fila.
   - Fuera de clase: **0**. Coincide con `marcas-sin-motivo.txt`.
5. **Hechos históricos.** El párrafo rc.1 de la guía 1.0.0 (L3603) termina en «fija cuatro marcas de juicio (§0.3)». La restauración de P-19 conserva un hecho que ya figuraba y no inventa uno nuevo. El ítem «Práctica de §3» que objeté en la 1.ª vuelta ya no aparece, y cada ítem del párrafo 1.1.0 tiene un parche que lo produce: P-01 op 7, P-01 op 9 con P-23, y P-03.

## 2. ¿El motivo nuevo es verdadero en cada marca?

Ésta es la pregunta propia de este juez: con la regla por defecto, un motivo escrito tiene que ser cierto, porque de lo contrario reaparece el defecto que la revisión quiere cerrar.

| Op | Marca | Motivo propuesto | Juicio |
|---|---|---|---|
| 10 | BOM en `.cs`, sin documento de .NET | (sin documento del fabricante) | Cierto en sentido estricto, porque la misma oración dice «no se encontró». Leído suelto, el motivo afirma un poco más que el texto (que no existe, contra que no se encontró). No bloquea: hubo búsqueda, a diferencia de asdf. |
| 11 | asdf, columnas «Windows nativo» y «¿Hace cumplir?» | (no ejercitado) | Cierto. `asdf` no aparece en `Examples/` (`grep -rli` vacío), y §12 (L3575) ya lo deja pendiente («asdf en Windows»). Que se descarte «(no documentado)» está bien fundado. |
| 12 | Renovate y el digest del `container:` | (requiere la plataforma) | Defendible. La plataforma `local` de Renovate hace *dry runs* contra el sistema de archivos, sin servicio git alojado, pero «branch creation is not supported» y no abre PR (https://docs.renovatebot.com/modules/platform/local/, consultada el 2026-10-09). Con eso se puede verificar la **búsqueda** del digest nuevo, no el **movimiento**, que es lo que la oración afirma. Nota no bloqueante: si se quiere el motivo inatacable, «(no ejercitado)» también es cierto. |
| 13 | Dependabot y digests, «(§8.2.2)» | (requiere la plataforma; §8.2.2) | Cierto: Dependabot corre sólo en GitHub. Además, la remisión deja de pasar por motivo. |
| 14 | cosign sin clave | (no ejercitado en el laboratorio) | Cierto. Lo dice el propio texto y no hay experimento de cosign *keyless* en el Anexo E. Quita además la redundancia. |
| 15 | Dependabot con gestores nuevos | (requiere la plataforma) | Cierto, por la misma razón que la op 13. |

Op 9: el texto nuevo de la regla («Sin motivo escrito… quiere decir "requiere Windows" (§0.4); todo otro motivo se escribe») es un cambio de convención y no pide evidencia externa. Lo que sí pedía evidencia era que ninguna marca quedara con un motivo implícito falso, y eso queda probado en §1.4.

## 3. Observaciones no bloqueantes

- **Números de línea.** La tabla de objeciones y la «Sección» de P-01 dicen L539, L1411, L1482, L1698 y L1953 «de 1.0.0». En la guía con sha `a2b78179…` las marcas están en L546, L1416, L1487, L1706 y L1959; L1031 sí coincide. No afecta la aplicación, porque las ops anclan en texto literal y cada ancla aparece una vez, pero conviene corregir esos números en el registro de aplicación.
- **Arrastre de P-16.** La regla («224» o «223» según cuántas filas `| Bnn |` cuente `checks.py` sobre la guía real, después de P-16) es verificable y no deja la cifra sin dueño. Se cumple si el orden C-3 se respeta.

## 4. Votos

| Parche | Voto | Fundamento |
|---|---|---|
| P-01 (rev. 2) | APLICAR | Las siete anclas nuevas aparecen una vez en 1.0.0. r2.py reproduce el sha `eb7d1673…` y las 55 279 palabras. Mi clasificador propio da 20 marcas sin motivo, 3 de metatexto y 17 de Windows/VS/Git Bash/ESC-01, ninguna fuera de clase. Los seis motivos nuevos son ciertos; el de la op 12 es defendible, porque el *dry run* local de Renovate no mueve digests. |
| P-19 (rev. 2) | APLICAR | Mi objeción de la 1.ª vuelta está atendida: «Práctica de §3» → 0 y «fila §3 en la ruta mínima» la produce la op 7 de P-01. «cuatro marcas de juicio (§0.3)» es un hecho que ya estaba en L3603 de 1.0.0. La celda tiene 7 palabras y coincide con `version:`. El ítem del motivo por defecto describe lo que hacen P-01 op 9 y P-23. |
