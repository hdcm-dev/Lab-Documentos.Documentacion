# Mesa · Ciclo 1 · 04 — Aprobación: juez de coherencia histórica

> Fecha: 2026-10-09. Rol: mesa de aprobación, juez de coherencia histórica (marco `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §5.5 y §6).
> Insumo: `03-Parches.md` (P-01…P-24). Contrastado contra: contrato `00-Contrato-De-Entrada.md` (DC-01…DC-07, R-*, `fuera_de_alcance`); `02-Cohesion-Global.md` §4 y §6; `03-Marco-De-Referencia.md` (N6 «sólo CI»); `04-Integracion.md` CI-01…CI-12, §4 («gana E1 o la fuente primaria; nunca una regla global») y §10 («Pendiente de la mesa»); los núcleos N2, N3, N4, N5; mi voto `02-Voto-coherencia-historica.md` y las direcciones de §1 de `03-Parches.md`.
> Pregunta de este juez: ¿el parche reabre una decisión cerrada sin evidencia nueva, o contradice otro veredicto del ciclo? Chequeo obligatorio (§5.5): ¿corrige en la capa de origen?

## Resumen

- **APLICAR**: 23 parches (P-01…P-22, P-24).
- **MEJORAR_PLAN**: 1 (P-23, capa de origen incompleta). Como P-23 va primero en el orden de aplicación, P-08, P-11 y P-16 se aplican **después** de la versión corregida de P-23; su veredicto no cambia.
- **NO_APLICAR**: 0. **ESCALAR**: 0.

Ninguna decisión del contrato (DC-01…DC-07) se toca. Lo que se reabre es de la integración y se reabre con evidencia nueva E1/E4 que la decisión no tuvo, como pide 04 §4: **CI-05** (E1 exit 145; voto de evidencia V1) y la decisión N6 «sólo CI» de `03-Marco-De-Referencia.md`, que nació como criterio propio sometido a la mesa. CI-02 se extiende; CI-06, CI-08, CI-10 y CI-11 se aplican sin reabrirse. El pendiente SBOM de 04 §10 estaba delegado explícitamente a la mesa y se cierra. No se cumple ningún disparador de §6: el empate 2-2 de C1-10 no es «persistente» (no hubo dos rondas) y la síntesis lo resuelve.

## Veredictos

| Parche | Veredicto | Fundamento |
|---|---|---|
| P-01 | APLICAR | Quitar «de la mesa» aplica R-PO-2 y 02 §6 («la guía no remite a la bitácora»); conservar `traces` coincide con el veredicto de C1-46 (procede, resuelto por definición). Los conteos 204 = 193 + B194–B204 y 73 = 71 + E2-7/E2-8 cuadran con P-19, P-20 y P-22. |
| P-02 | APLICAR | 02 §6 nunca definió «Partes»: quitarlas repara el índice contra la estructura cerrada sin cambiarla (mi voto de C1-42). «corrección» por «fix» aplica la univocidad de N0. |
| P-03 | APLICAR | La exclusión de los enfoques de entorno completo va con fuente ([B04]) y como **[criterio]**, la condición que puse en C1-45. No quita contenido de §8 (02 §6 fila 8 sigue cubierta) y no viola DC-02, porque Bazel entra como contraste de una línea con fuente. El enlace a Despliegue respeta `fuera_de_alcance` (enlazar sí, editar no). Las dos velocidades mantienen §3 como mapa de N0 (C1-24). |
| P-04 | APLICAR | Comandos corregidos con E1 del auditor y términos unificados. No hay decisión en juego. R-PRIV: el caso sigue genérico (DC-05). |
| P-05 | APLICAR | Reformula N6 «sólo CI», que 03 dejó como criterio sometido a la mesa: «se produce sólo en CI» con usos ○ en ESC-01/02/03 coincide con la dirección (b) de C1-18 (4-0). Separar estrategia de imagen (ACT-ARQ) y digest (ACT-OPS) es coherente con P-13 y P-14. Su origen en 03 lo registra P-23. |
| P-06 | APLICAR | «`disable` en toda máquina» aplica CI-05 reabierta por E1. ESC-04 con etiqueta fija o receta de CI es la dirección (b) de C1-21 (4-0). La fila NU1603 coincide con P-10. Ninguna fila de §3 contradice los capítulos parcheados. |
| P-07 | APLICAR | #83320 como arreglo y su prueba coinciden con P-05 y P-19 ([B15]). Bajar la rama ACP UTF-8 a pregunta es coherente con 04 §10, que ya la tenía como «revalidar en Windows». No reabre la resolución de N1 (C1-35). La nota de N1 sobre identificadores está en P-23. |
| P-08 | APLICAR | `text=auto` como opción válida no reabre la tensión cerrada «`eol` gana a `core.autocrlf`» y las plantillas (A.2) mantienen la segunda (C1-36). La síntesis de C1-10 conserva entera la dirección (a) que voté: tabla, remisiones y ramas de CI-02. Le suma la columna «Lo decide» de (b) sin quitar nada de (a). Por eso **extiende** CI-02 y no la reabre, y la acepto como resolución del empate (no hace falta segunda ronda). editorconfig-checker como alternativa cumple CI-11, y la compuerta propia sostiene N7 (C1-08 (a) 3-1). Condición de orden: el origen en N2 (ver P-23) se corrige antes. |
| P-09 | APLICAR | Aplica el veredicto (a) 3-1 de C1-03 sin violar 04 §4. La tabla de §6.4 escribe completas las dos políticas, la de por defecto lleva **[criterio]** con su costo y hay un «Por contexto». Así se cumple también lo que CI-05 cerró: «la guía presenta la elección». Mi voto (b) queda contenido en esa tabla. El compilador «CLI sí / VS según SDK» corrige N3 con E1 (C1-04), con origen en P-23. |
| P-10 | APLICAR | Mismo fundamento que P-09: el lock por defecto con alternativa completa es la dirección votada y no una regla global. El «Por contexto» de §7.4 lo deja como decisión por escenario. La cita de [B83] corrige N0 y el alcance del lock sólo en ejecutables se redacta después de C1-03, el orden que pedí. CI-01 (condición única de CI) queda intacta en A.4. Observación menor, no bloqueante: en el punto 2, «esta guía lo adopta por defecto» va mejor con su marca **[criterio]**, para no leerse como regla del fabricante. |
| P-11 | APLICAR | Aplica CI-06 sin reabrirla. El rótulo sigue **[no verificado]** para lo que GitHub no documenta y sólo cita lo que Docker sí documenta [B113], que era la condición de mi voto en C1-20. La política sigue la dirección (b) de C1-21 (4-0) y es coherente con P-06, P-16 y P-17. Condición de orden: N5 corregido en P-23 antes de aplicarlo. |
| P-12 | APLICAR | El criterio SBOM («CycloneDX salvo pedido del consumidor») cierra el pendiente de 04 §10, que estaba delegado a la mesa. No contradice `fuera_de_alcance`: es un formato condicionado al consumidor, no una herramienta «para todo». El paso 8a/8b sigue la dirección (b) 4-0 de C1-18, y C1-16, C1-17 y C1-32 van dentro de la rama de firma, en el orden que pedí. Fijar `attest` por SHA aplica CI-08. |
| P-13 | APLICAR | Hace cumplir N7 en lugar de reabrirlo: «compuerta única» se define como un programa por repositorio, y `compuerta.sh` y `verificar.sh` son dos disposiciones de un mismo diseño. Era la contradicción que señalé en C1-05. La fila de GitLab está dentro de lo que la guía ya usa (CI-01, C1-19). Los roles coinciden con P-05. |
| P-14 | APLICAR | La imagen única para un artefacto y por componente con compuerta previa aplica la tensión cerrada «criterio por contexto» (02 §4, E8-5) de C1-14. A=B como prueba de regresión en CI respeta el alcance de E8-5 (C1-29). `devEngines` corrige N8 L207 con E1. WSL «sólo capas 1 y 3» limita la decisión «WSL dentro de N5» sin reabrirla (C1-06). |
| P-15 | APLICAR | «Consultar en cualquier orden, aprender en el orden de §0.2» repara la contradicción a favor de la ruta de lectura (C1-39, DC-01). Los pasos 2, 3, 4, 6, 7, 8a y 8b repiten las decisiones de P-08…P-12 sin agregar ninguna. |
| P-16 | APLICAR | A.4 conserva la condición única de CI-01. El lock sólo en `Exe` va en `.targets`, verificado con E1 (en `.props` no funciona), y es coherente con C1-03 y C1-26. A.10 en Node 24 aplica CI-10 y A.13 con `docker` aplica CI-06. Sin `LangVersion` fijo no hay decisión cerrada en contra. Condición de orden: el origen de N4 en P-23. |
| P-17 | APLICAR | B.1 a B.3 repiten literalmente las políticas de §6.4, §7 y §8.2.2 ya aprobadas. Sin contradicciones. |
| P-18 | APLICAR | Aplica R-PO-2 y la univocidad de N0 (C1-25, C1-54). No reabre nada. |
| P-19 | APLICAR | Los permalinks y [B15] como arreglo son coherentes con P-05 y P-07. Quitar el estatus ISO de B155 coincide con P-12 ([B194] = SPDX 2.2.1). Las B194–B204 cuadran con P-01. |
| P-20 | APLICAR | Los IDs se mantienen estables y se agregan correspondencias (C1-38: «los IDs son estables»). E2-7 y E2-8 cuadran con P-01 y P-22. |
| P-21 | APLICAR | Definir las trazas dentro de la guía es la resolución de C1-46 que acepté y respeta «la guía no remite a la bitácora». ACP UTF-8, Dependabot y SBOM coinciden con P-07, P-11 y P-12. |
| P-22 | APLICAR | El laboratorio sigue los parches de la guía. L7 copia un relevamiento de repositorios públicos, sin conflicto con R-PRIV. Respeta DC-06 (`.gitignore`) y la regla «plantillas = bloques del Anexo A» (EA-1). |
| P-23 | MEJORAR_PLAN | Está bien encaminado: notas de solo agregado y aplicado primero. Pero **no corrige todos los orígenes que declara**, y la bitácora quedaría contradiciendo a la guía aprobada. Faltan tres notas. (1) **N5** L107 («digest en todo lo versionado… `image` del `devcontainer.json`»), L108 y L372 (Dependabot `docker`/`devcontainers` para digests) y L318. El encabezado de P-23 atribuye C1-20/C1-21 a «CI-06, N5», pero la tabla sólo anota CI-06. (2) **N2** L105 y L288 («`*.csproj` … UTF-8 sin BOM»): es el origen del error de C1-10 corregido con E2-6, y P-23 sólo anota CI-02. (3) **N4** L228–L240 (`Directory.Build.props`: lock en todos los proyectos): es el origen de C1-26, porque el lock sólo en `Exe` funciona en `.targets` y no en `.props` (evidencia-auditor/lock-solo-ejecutables). Basta agregar esas tres filas con el mismo formato `> **Corrección mesa ciclo 1 (2026-10-09, C1-nn).**`. Es una vuelta (de dos posibles) y no requiere otra evidencia. |
| P-24 | APLICAR | Respeta R-ESCR (la ia-db no se escribe). Registra el apartamiento para el PO con la fila propuesta, como previó mi voto de C1-48 y la regla de avisar al PO. |

## Registro para el cierre

- Decisiones reabiertas con evidencia nueva y reparadas en su origen: CI-05 (C1-01, C1-03) y N6 «sólo CI» (C1-18).
- Decisiones extendidas: CI-02 (C1-10, síntesis aceptada por este juez).
- Decisiones aplicadas sin reabrir: CI-01, CI-06, CI-08, CI-10, CI-11.
- Pendiente cerrado: el formato de SBOM (04 §10).
- Ninguna escalada al PO por coherencia histórica. P-24 sólo deja un **aviso** del apartamiento de Rule-Indexing.
