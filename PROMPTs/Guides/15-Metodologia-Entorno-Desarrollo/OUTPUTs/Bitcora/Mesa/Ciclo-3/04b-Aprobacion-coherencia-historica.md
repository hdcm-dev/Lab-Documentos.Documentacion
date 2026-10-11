# Mesa · Ciclo 3 · 04b — Aprobación, 2.ª vuelta: juez de coherencia histórica

> Fecha: 2026-10-09. Rol: mesa de aprobación, segunda vuelta (marco `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §5.5), juez de coherencia histórica.
> Insumo: «Revisión 2 · P-01 y P-19» de `03-Parches.md` (desde la L2307) y su prueba `evidencia-auditor/r2-p01-p19/` (`r2.py`, `marcas-sin-motivo.txt`).
> Pregunta: ¿la revisión 2 reabre una decisión cerrada o contradice otro veredicto? Las decisiones que consulto son el contrato (DC-01…DC-07), los ciclos 1 y 2, los 35 PROCEDE del ciclo 3 y los `04-Aprobacion-*.md` de este ciclo, incluido el mío (§2.1 y §2.3).

## Veredicto

| Parche | Voto | Fundamento |
|---|---|---|
| P-01 (rev. 2) | APLICAR | Atiende la objeción que dejé en `04-Aprobacion-coherencia-historica.md` §2.1, y también las de riesgo e impacto. La regla de la op 9 («sin motivo escrito, **[no verificado]** quiere decir "requiere Windows"») sigue siendo la que votaron coherencia histórica, impacto y evidencia. Las ops 10 a 15 le escriben el motivo a las siete marcas ajenas a Windows **en el mismo parche**, así que la regla ya no deja dos lecturas incompatibles en la guía. El listado clasificado de todas las marcas sin motivo da 20: 3 de metatexto y 17 de Windows/VS/Git Bash, y ninguna fuera de clase. Reemplaza al conteo de la glosa, que era lo que pedía el riesgo. Las ops 1 a 8 no cambian y no tenían objeción. Las diferencias con el texto que propuse yo no reabren nada. Para L539 se eligió «(sin documento del fabricante)», que es lo que la oración ya afirma. Para asdf, «(no ejercitado)» en lugar de mi «(no documentado)»; es más fiel, porque no se consultó la documentación de asdf y no corresponde afirmar una ausencia sin evidencia. En L1698 queda una sola mención, como admití («si el auditor prefiere uniformar»). Cambiar el ejemplo de §0.3 a «(requiere una plataforma alojada)» evita que el ejemplo use la glosa que P-23 retira. Mover la corrección de P-23 a P-01 sólo cambia el lugar, no el orden efectivo: P-23 sigue último (C-3 de costo-beneficio y el orden de mi §4) y, cuando corre, ya no queda ninguna marca ajena a Windows sin motivo. El arrastre «B194–B224 / 224» o «B194–B223 / 223» no elige entre los remedios de P-16 de evidencia e impacto. Lo deja al conteo de `checks.py` sobre la guía real, después de P-16, así que no contradice ninguno de los dos veredictos. Reproducido (E1, abajo). |
| P-19 (rev. 2) | APLICAR | Toma literalmente el texto de mi §2.3. El párrafo 1.1.0 dice «fila §3 en la ruta mínima» y ya no dice «Práctica de §3», que §1.2 y §8 de `03-Parches.md` dejan fuera por C3-35/C3-41: el control de cambios ya no afirma algo que no ocurrió. El párrafo 1.0.0-rc.1 recupera «cuatro marcas de juicio (§0.3)», el hecho histórico en que se apoya la regla de P-01. «Motivo por defecto de **[no verificado]**» describe P-01 tal como entra, que era la condición del riesgo. El párrafo 1.1.0 no dice que la versión comprime, así que respeta lo que la guía no puede afirmar al cerrar mientras el saldo de prosa sea positivo (mi §4). No restaurar los otros ítems resumidos en 1.0.0 es coherente: ningún juez los reclamó, e impacto dejó escrito que la información se conserva. |

**Recuento:** 2 APLICAR, 0 NO_APLICAR.

## Verificación (E1, 2026-10-09)

Sobre la simulación con P-01…P-23 de la revisión 1, en una copia en el scratchpad:

```text
$ python3 -I r2-p01-p19/r2.py simulacion/guia-parcheada.md <scratch>/r2.md   # sin líneas FALLA
sha256 (8)                          → eb7d1673   (el que declara la revisión 2)
wc -w antes / después               → 55241 / 55279   (+38)
grep -c "Práctica de §3"            → 0
grep -c "cuatro marcas de juicio (§0.3)" → 1
grep -c "(requiere Windows)"        → 0
version: (L5)                       → 1.1.0, igual a la fila **1.1.0.** (L3638)
```

En `marcas-sin-motivo.txt` revisé las 17 líneas de la clase (b). Todas están en un párrafo, una fila o un recuadro sobre Windows, Visual Studio, Git Bash o la página ANSI del compilador en Windows. La guía real sigue en 1.0.0 (sha256 `a2b78179…`): nada se aplicó todavía.

## Observaciones que no cambian el voto

- **Saldo de prosa.** La revisión 2 suma +38 palabras al lote. No reabre C2-36, porque deja la decisión sobre el saldo a la mesa (P-25/P-26) y el párrafo 1.1.0 no dice que la versión comprime. Lo que sostuve en `04-Aprobacion-coherencia-historica.md` §2.5 sigue en pie: si el lote cierra con saldo positivo, `05-Aplicacion.md` tiene que registrarlo como el voto explícito que admite C2-36, y no como un «costo aceptado» sin nombre.
- **Líneas de referencia.** La revisión cita «L1698 de 1.0.0» para cosign, pero en la guía 1.0.0 esa oración está en la L1706. Las anclas son literales y aparecen una vez, así que la aplicación no depende del número de línea. Conviene que `05-Aplicacion.md` cite por ancla.
- **Formas del motivo.** Conviven «(requiere la plataforma)», «(requiere una plataforma alojada)» (ejemplo de §0.3) y «(requiere plataforma alojada)» (P-12). Las tres dicen lo mismo y ninguna contradice una decisión. Si se uniforman, que sea en otro ciclo y como parche propio.
