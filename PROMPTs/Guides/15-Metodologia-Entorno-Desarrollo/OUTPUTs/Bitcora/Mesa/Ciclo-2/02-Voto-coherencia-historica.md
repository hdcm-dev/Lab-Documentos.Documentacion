# Mesa · Ciclo 2 · 02 — Voto del juez de coherencia histórica

> Fecha: 2026-10-09. Rol: juez de coherencia histórica (marco `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §4.3 y §5.3).
> Función objetivo: ¿el ítem reabre una decisión cerrada o contradice otro veredicto?
> Decisiones cerradas consultadas: contrato `00-Contrato-De-Entrada.md` (DC-01…DC-07, SUP-01…SUP-06, `fuera_de_alcance`, severidades); `02-Cohesion-Global.md` §4 (tensiones); `04-Integracion.md` (CI-01…CI-12 y tabla de tensiones resueltas, con sus notas del ciclo 1); ciclo 1: `01-Consolidado.md`, `02-Voto-*.md`, `03-Parches.md` §1 (direcciones de C1-03 (a) 3-1, C1-08 (a) 3-1, C1-10 síntesis, C1-18 (b) 4-0, C1-21 (b) 4-0), `05-Aplicacion.md` (deudas D-1…D-7, ajustes A-1…A-7, notas R2-nn).
> Criterio (el mismo del ciclo 1): reabrir una decisión cerrada es legítimo sólo con evidencia E1/E4 nueva que la refute; una deuda registrada (D-n) o una decisión aplicada a medias se cumple, no se reabre; en las [CONTRADICCIÓN] voto la dirección que no contradice veredictos vigentes, o la síntesis cuando ambas caben.
> Regla vigente del PO que también se consulta: en las guías de esta colección una cita verificada no se recorta por presupuesto; si algo cede, cede prosa propia (pesa en C2-36 y C2-37).

| Id | Voto | Fundamento |
|---|---|---|
| C2-01 | PROCEDE | Ambas defensas: ninguna reabre C1-03 (a) (lock por defecto con `disable`), y C1-02 ya había dejado como dirección «`NU1603` como error **y/o** `requested` vs `resolved`»; A cubre a los proyectos que C1-26 dejó sin lock (bibliotecas, pruebas) y B paga D-2, porque el E1 del abogado muestra que con lock `NU1603` no se dispara. La fila «sin lock» de §6.4 conserva `NU1603` como defensa principal (CI-05). |
| C2-02 | PROCEDE | Es la deuda D-1 y la nota R2-11 ya fijó la condición `Exe Or WinExe` como texto pendiente; aplicarla cumple C1-26 y deja de contradecir la capa de origen. |
| C2-03 | PROCEDE | Es la deuda D-2; R2-14 previó completarse con el ID del experimento que falle ante 8.0.2 → 9.0.0, y §7.9.1 hoy pide como respuesta algo que la compuerta no hace. Dirección B de C2-01. |
| C2-04 | PROCEDE | Dato volátil (D-7) con fuente fechada; no toca SUP-06 (8.0 y 10.0 siguen siendo las versiones del laboratorio): 8.0.425 queda como SDK del caso con su fin de soporte declarado. |
| C2-05 | PROCEDE | Dirección B: la reapertura de C1-08 no se admite, porque la capacidad de editorconfig-checker ya estaba en la evidencia del ciclo 1 y lo nuevo son defectos locales del script (C2-06, C2-07) o que la herramienta tampoco resuelve (C2-08, C2-09, alcance `--staged`); nada refuta N7 ni CI-11. Sigue como alternativa en §5.2.5, como se decidió. |
| C2-06 | PROCEDE | Preferir (a): C1-05 cerró «compuerta única», y un segundo programa copiable que da `texto: OK` ante cp1252 la contradice; si la compuerta de N7 no cubre subcarpetas por inventario (C1-05), entonces (b) con paso en EA-1. Sale «el mismo diseño». |
| C2-07 | PROCEDE | (a) y (b): C1-06 (P-13, L13) cerró que la compuerta distinga «falta herramienta» de «violación»; el módulo `editorconfig` es un prerrequisito más que quedó afuera. Vale en la dirección B de C2-05. |
| C2-08 | PROCEDE | Extiende a las plantillas lo que C1-27 (P-22 L1, `git update-index --chmod=+x`) ya aplicó al laboratorio; es independiente de C2-05 y coherente con SUP-05. |
| C2-09 | PROCEDE | C1-05 cerró «local = CI» para la compuerta; declarar el límite de `--staged` o hacer fallar el hook ante un lock sin stage lo cumple. Corregir ESC-04 no contradice ningún veredicto. |
| C2-10 | PROCEDE | Es la deuda D-3; trae fuentes del fabricante y conserva el [no verificado] de las cosas de Windows (C1-06, C2-Q04). Cambiar `MSYS2_ARG_CONV_EXCL` por `MSYS_NO_PATHCONV` o WSL 2 no reabre nada. |
| C2-11 | PROCEDE | La guía ya cerró la causa (§8.2.5, E5-3) y C1-21 (b) dejó el devcontainer como comodidad que debe funcionar con su receta; corregir A.9 aplica lo cerrado. |
| C2-12 | PROCEDE | Aplica en lo copiable la síntesis aprobada de C1-10 y CI-02 (tres estados, variante B para el heredado con BOM) sin tocar la tabla. Ampliar la variante B a `csproj`/`props`/`targets` es coherente con R2-07 (la familia .NET comparte convención); normalizar sin BOM sería la variante A, no la del caso. |
| C2-13 | PROCEDE | Dirección B. A reabre C1-21 (b) 4-0 («digest + bot donde se construye lo publicado»), la tensión cerrada de 02 §4/04 («digest en CI con actualización por PR») y la 8a de C1-18 («digest de la imagen» en el registro), con evidencia E4 de tutoriales y un registro de la capa 4 que el propio abogado deja sin verificar (C2-Q07). El runner alojado puede mencionarse con su costo declarado (capa 4 flota), no con igual rango. |
| C2-14 | PROCEDE | C1-18 (b) 4-0 hizo de 8a la respuesta para todo equipo y la guía no la materializa; completar A.12 (o corregir §11.8) cumple ese veredicto. Forma del job según la dirección B de C2-13. |
| C2-15 | PROCEDE | Síntesis: C1-18 (b) subordinó la firma a 8b, así que comprimir §9.2.4 a un bloque «Para 8b» es coherente; pero el bloque debe conservar lo que fijaron C1-17 (L1 exige `builder.id`) y C1-32 (vía sin clave y su costo, aislamiento de la clave, verificación del predicado), y sumar C2-16 en una línea. Presupuesto según C2-36. |
| C2-16 | PROCEDE | Cierra C1-Q07 con E1 y E4, y es coherente con C1-17; reemplaza un [no verificado] que la evidencia nueva levanta. Extensión de una o dos oraciones, por C2-15. |
| C2-17 | PROCEDE | En la dirección B de C2-13, el eslabón tiene que tener dueño; es coherente con CI-06 (la actualización de digests por Dependabot no está verificada) y con C1-20. |
| C2-18 | PROCEDE | Repara el camino de imagen que C1-21 (b) sostiene; sin `packages: read` y `credentials`, A.12 no corre. Dirección B de C2-13. |
| C2-19 | PROCEDE | Completa la columna «qué no impide» que C1-19 creó; agrega una fuente, no reabre nada. |
| C2-20 | PROCEDE | Precisión de la misma tabla de C1-19 con E4; alinear §10.2.8 evita una contradicción interna nueva. |
| C2-21 | PROCEDE | C1-16 cerró que la procedencia se arma con tres partes (§11.2.8) y C1-14 que la imagen depende de la variable de §11.2.7; el diagrama y la tabla de §11 que ofrecen «BuildKit» para imagen única contradicen esos dos veredictos. |
| C2-22 | PROCEDE | Completa C1-49 (P-05): estrategia de imagen en ACT-ARQ, mantenimiento y digest en ACT-OPS. La forma coherente es la nota decide/lidera; pasar §8 y §9 enteros a ACT-ARQ contradiría la separación que se aprobó. |
| C2-23 | PROCEDE | C1-21 (b) quedó aplicada a medias: las cuatro filas que piden digest en el devcontainer contradicen §8.2.2 punto 2. Se cumple, no se reabre. |
| C2-24 | PROCEDE | Corrección factual con E1; ningún veredicto sobre `DOCKER_CONFIG` (L16 del ciclo 1 sólo lo usó por credenciales vencidas). |
| C2-25 | PROCEDE | Ningún parche del ciclo 1 decidió quitar `minimum_pre_commit_version` (no aparece en `03-Parches.md`); restituirlo deja el bloque igual al archivo ejecutado en E7-2. |
| C2-26 | PROCEDE | Corrección factual con E4; no hay decisión sobre el paso. |
| C2-27 | PROCEDE | Aplica la regla de §0.3 («extracto literal; nunca altera una línea mostrada») que el ajuste A-2 del ciclo 1 ya hizo cumplir; se cumple, no se reabre. |
| C2-28 | PROCEDE | Es la deuda D-4: se resuelve a favor del **[criterio]** ya aprobado en §9.2.4 (pedir `version=v1` explícito), que es el veredicto vigente. |
| C2-29 | PROCEDE | La guía declara fuentes al 2026-10-09 (P-01: `fuentes_consultadas` con dos fechas, `last_review` 2026-10-09); mantener «prevista» contradice ese esquema. Calificar por versión y fecha, en la misma pasada que C2-49. |
| C2-30 | PROCEDE | Corrige el texto aplicado por C1-31 con un E1 nuevo (pnpm 10.18.0) que su evidencia (pnpm 12.10.1) no tuvo; reabrir un dato con E1 que lo refuta es legítimo. |
| C2-31 | PROCEDE | La frase contradice C1-56, que aceptó que un cp1252 cuyos bytes forman UTF-8 válido sale como UTF-8, y la tabla de la misma sección (Windows con ACP 1252). |
| C2-32 | PROCEDE | C1-23 cerró dos consignas por capítulo y D-4 registró la de §11.9. Usar E8-1, porque §0.2 (P-03 3d) fija E8-1 como ruta mínima de §11; X1 contradiría esa tabla. |
| C2-33 | PROCEDE | Extiende C1-23 sin quitar piezas, como se aceptó en el ciclo 1 para §4–§11, y no altera el orden que C1-39 fijó para §12. Sin experimentos nuevos y dentro de C2-36. |
| C2-34 | PROCEDE | C1-46 decidió resolver las trazas dentro de la guía (no quitarlas): corregir filas e IDs lo cumple. Borrar «Formato de SBOM» aplica C1-43, que sacó la decisión pendiente del Anexo F. |
| C2-35 | PROCEDE | Extiende C1-25 (glosario, «índice» con tres sentidos) a «registro» y «manifiesto»; no hay decisión en contra. |
| C2-36 | PROCEDE | Síntesis: DC-04 (pedido literal del PO de corregir compresión) justifica un control de Δ palabras por parche y saldo no positivo en prosa propia; la meta dura ≤ 48 000 no, porque obligaría a recortar citas y evidencia, contra la regla del PO y contra lo que fijaron C1-17, C1-32 y C1-43. Citas y evidencia se presupuestan aparte. |
| C2-37 | PROCEDE | Compresión por reorganización (listas, una regla por párrafo, «Detalle de versión») sin quitar fuente; es coherente con 04 («texto que forma criterio + Anexo A + `Examples/`»). Magnitud según C2-36. |
| C2-38 | PROCEDE | Completa la decisión de C1-24 («dos velocidades» dentro de §3, sin reubicar §3.3, como votó este juez). Simplificar §3.7 y agregar la vuelta al mapa no la reabre. |
| C2-39 | PROCEDE | Aplica §0.3 («un snippet sin experimento se marca como ilustrativo») y C1-51; no hay decisión en contra. |
| C2-40 | PROCEDE | El error lo introdujo P-03 3e («Son las únicas cinco marcas») y lo repitió `05-Aplicacion.md` §7; corregir a cuatro marcas de juicio cumple C1-40 (vocabulario cerrado). La bitácora del ciclo 1 se corrige con nota de solo agregado. |

## Dependencias de orden que este juez señala

- C2-13 (dirección B) decide antes que C2-14, C2-17 y C2-18.
- C2-05 (dirección B) decide antes que C2-06 y C2-07; C2-08 y C2-09 no dependen de C2-05.
- C2-01 (ambas) va con C2-02 y C2-03 en el mismo parche (A.4, A.4b, compuerta, §6.4, §7.2.1); la nota R2-14 de N4 se completa con el ID del experimento nuevo y R2-11 queda confirmada.
- C2-36 fija el presupuesto antes de C2-15, C2-33 y C2-37; C2-16 entra en el bloque comprimido de C2-15.
- C2-29 se aplica junto con C2-49 (fechas de §0.3 y del Anexo F).
- Capa de origen a reparar con nota de solo agregado: N4 (C2-01…C2-03), N2 (C2-12), N5 (C2-23), N6 (C2-15, C2-16) y la propia bitácora del ciclo 1 (C2-40).
- Decisiones del ciclo 1 que este voto **no** admite reabrir: C1-08 (a) y C1-21 (b) (vía C2-05 y C2-13). Decisiones que se corrigen por E1 nuevo: el texto de C1-31 (C2-30).
