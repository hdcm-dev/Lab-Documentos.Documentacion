# Mesa · Ciclo 3 · 04b — Aprobación, 2.ª vuelta · Juez de impacto

> Fecha: 2026-10-09. Rol: juez de impacto. Pregunta: si no se corrige, ¿qué le pasa concretamente al lector de la guía, en lo que entiende o en lo que hace al aplicarla?
> Objeto: la «Revisión 2 · P-01 y P-19» de `03-Parches.md` (desde la L2307). Mis objeciones de la primera vuelta están en `04-Aprobacion-impacto.md`: J-I1 (P-01 op 9) y J-I7 (P-19).
> Vocabulario: `APLICAR` | `NO_APLICAR`.

## 1. Reproducción (E1, 2026-10-09)

- `python3 -I evidencia-auditor/r2-p01-p19/r2.py evidencia-auditor/simulacion/guia-parcheada.md <scratch>/g2.md` no imprime ninguna `FALLA`, así que cada ancla aparece una vez. El resultado tiene sha256 `eb7d1673b3ff…` y 55 279 palabras (`wc -w`), frente a 55 241 de la copia. Es lo mismo que declara el auditor.
- Listé con un script propio todas las `**[no verificado]**` que no tienen detrás un paréntesis de motivo, contando también como «sin motivo» los paréntesis que empiezan con `§`. Salen **20**, las mismas de `marcas-sin-motivo.txt`. Las clasifico así:
  - **Metatexto (3):** L93 es la definición, L97 la regla y L3638 el párrafo 1.1.0.
  - **Windows, Visual Studio, Git Bash o ESC-01 (17):** L113, L385, L483, L498, L530, L690, L713, L812, L832, L1046, L1056, L1119, L1243, L2000, L2333, L2868 y L2870. Leí cada contexto. L483 corresponde a la fila de Roslyn con ACP 1252 y L1119 a la fila del IDE (Visual Studio). En las dos, lo que falta para verificar es un Windows.
  - **Fuera de clase:** 0.
- Las cinco marcas de mi J-I1, más L1482 (la que agregó coherencia histórica) y la segunda celda de asdf, ya tienen motivo escrito: L539, L1027 (las dos celdas), L1411, L1482, L1698 y L1953.
- P-19: `grep -c 'Práctica de §3'` da 0 y `grep -c 'cuatro marcas de juicio (§0.3)'` da 1. La fila de la tabla es `| 1.1.0 | 2026-10-09 | Revisión integral, ciclo 3; versión vigente (abajo). |`, y `version: 1.1.0` (L5) coincide con ella.

## 2. Votos

| Parche | Voto | Fundamento (impacto en el lector) |
|---|---|---|
| P-01 (rev. 2) | **APLICAR** | El defecto que marqué en J-I1 desaparece. Con la regla «sin motivo = requiere Windows», el lector habría atribuido a Windows lo que en realidad necesita una plataforma alojada (Renovate y Dependabot con digests, Dependabot con gestores nuevos) o lo que no tiene fuente (BOM en `.cs`). Por eso habría dejado de buscar la verificación donde sí puede hacerla, que es la CI. Ahora cada una de esas marcas dice qué le falta, y el listado reproducido no deja ninguna fuera de clase. La cláusula «todo otro motivo se escribe» le da al lector una regla de lectura cerrada: si ve una marca sin paréntesis, sabe que es de Windows y no tiene que adivinar. Las ops 1 a 8 siguen siendo las que aprobé en sustancia: cifras y versión que no mienten, y §0.2 sin remitir a una tabla que P-03 elimina. El arrastre de P-16 (223 o 224) queda en manos del conteo de `checks.py` y no del texto, así que la apertura no puede prometer una cifra distinta de la del Anexo D. |
| P-19 (rev. 2) | **APLICAR** | Corrige J-I7. El párrafo 1.1.0 ya no manda a buscar una «Práctica de §3» que no existe. Ahora anuncia lo que sí entra: la fila §3 de la ruta mínima y el cambio de convención de §0.3. Este último le importa a quien ya leyó la 1.0.0, porque es el único cambio que modifica cómo se leen marcas que el lote no toca. Restituir «cuatro marcas de juicio (§0.3)» conserva el hecho del que depende esa regla, a cambio de 5 palabras. |

## 3. Observaciones que no cambian el voto

1. **Motivos que dicen por qué no se verificó, pero no qué faltaría.** L1027 «(no ejercitado)» y L1698 «(no ejercitado en el laboratorio)» explican por qué falta la verificación. La definición de §0.3 (L93) pide además «qué faltaría para verificarla». En L1698 eso sería un OIDC de una plataforma alojada, como propuse en la primera vuelta. Ninguna de las dos marcas le induce al lector una conclusión falsa, y son mejores que leer ahí «requiere Windows». Acepto el argumento del auditor de no escribir «(no documentado)» sin haber consultado la fuente. El ajuste fino queda como sugerencia para un ciclo siguiente, sin deuda declarada. **[criterio]**
2. **Dos formas para el mismo motivo.** El ejemplo de §0.3 dice «(requiere una plataforma alojada)», y las ops 12, 13 y 15 dicen «(requiere la plataforma)». La guía ya usaba las dos (L1401 y L2978). No le cambian el sentido al lector y no justifican otra vuelta.
3. **Orden de aplicación.** P-01 entra después de P-16, y P-23 va último (condición C-3 de costo-beneficio). Si después de aplicar sobre la guía real el listado de §1 da algo fuera de clase, la op correspondiente vuelve como `regresión` (marco §5.6). No tiene que darlo, porque las ops 10 a 15 no comparten anclas con P-02 a P-22.

## 4. Recuento

- APLICAR: P-01 (revisión 2) y P-19 (revisión 2).
- NO_APLICAR: ninguno.
