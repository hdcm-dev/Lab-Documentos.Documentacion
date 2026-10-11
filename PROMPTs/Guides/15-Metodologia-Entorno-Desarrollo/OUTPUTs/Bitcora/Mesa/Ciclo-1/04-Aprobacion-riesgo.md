# Mesa · Ciclo 1 · 04 — Aprobación: juez de riesgo e irreversibilidad

> Fecha: 2026-10-09. Marco: `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §5.5 (mesa de aprobación) y §6 (escalada). Insumo: `03-Parches.md` de esta carpeta, la guía `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (1.0.0-borrador, 3060 líneas), `evidencia-auditor/` y los núcleos de `Bitcora/Nucleos/`.
> Función objetivo: ¿la corrección es reversible? ¿qué se rompe en la guía si sale mal? Veto sólo si la corrección es irreversible y la severidad S3 o menor.
> Decisiones posibles: APLICAR | MEJORAR_PLAN | NO_APLICAR | ESCALAR. Chequeo obligatorio por parche: ¿corrige en la capa de origen?

## Criterio general

Los 24 parches son ediciones de texto sobre un único `.md`, sobre archivos del laboratorio `Examples/` y sobre la bitácora (con notas de solo agregado). No hay publicación, migración de datos, contrato público ni efecto externo: **todo es reversible** y **no ejerzo veto**. El riesgo que pondero es el radio de rotura dentro de la guía (referencias cruzadas, anexos, conteos, laboratorio que deja de coincidir con el texto) y la introducción de afirmaciones nuevas sin evidencia.

Lo que revisé además de leer los parches:

- La evidencia nueva del auditor (`evidencia-auditor/`): `lock-solo-ejecutables/salida.txt` (variante `.targets`: App con lock, Lib sin; modo CI rc=0; cambio sin regenerar → `NU1004` rc=1), `nu1603-sdk10/salida.txt` (con lock rc=0), `locks-multiplataforma/salida.txt` (26 plataformas en el lock, una instalada, pnpm y Yarn) y `a10-node24/salida.txt` (Node 24 sobre bookworm, glibc 2.36 igual que `sdk:8.0`). Sostienen lo que P-10, P-16 y P-22 afirman.
- `decisiones_cerradas` de `00-Contrato-De-Entrada.md` (DC-01…DC-07): ningún parche reabre una. La decisión N6 «sólo CI» de `03-Marco-De-Referencia.md` no está entre ellas; P-23 la matiza con una nota, sin disparador 7.
- La capa de origen, con `grep` sobre `Bitcora/Nucleos/` y `04-Integracion.md` de las frases que los parches reemplazan en la guía. Ahí aparecen huecos de P-23 (ver su fila).

Ningún parche cae en los siete disparadores de §6: no hay ambigüedad de intención (el pedido del PO y el contrato desempatan), ni conflicto insalvable entre restricciones duras (P-24 lo resuelve registrando el apartamiento), ni cambio de alcance (C1-45 se resuelve con una exclusión declarada, que es lo que el contrato ya dejaba fuera: «despliegue y operación en producción»), ni irreversibilidad, ni consecuencia externa, ni empate persistente (ver C1-10), ni reapertura de decisión cerrada. **No escalo nada.**

### Sobre la síntesis de C1-10 (empate de dirección 2-2)

La acepto. Mi voto de dirección en el ciclo fue (a) por radio de rotura: conservar la tabla de §5.2.3 que citan A.1, §11.2.2 y §12 paso 2. La síntesis conserva la tabla y sus remisiones, y suma una columna «Lo decide» y una rama nueva: el radio de rotura es el de (a), y la corrección de fondo (el `.csproj` no es «sin BOM por la CLI»; `dotnet new console` lo crea con BOM, E2-6) es la que pedían costo e impacto. Desde riesgo no hay motivo para devolverla a segunda ronda. La condición es que su capa de origen también se corrija (N2 y N8 todavía afirman `.csproj` «sin BOM» por regla de lector: ver P-23).

### Condiciones transversales a todo APLICAR

1. **Orden**: el de §0 de `03-Parches.md` (P-23 → P-19 → P-22 → P-01…P-18 → P-20, P-21 → P-24). Ningún parche de la guía antes de P-23 corregido según este voto.
2. **Conteos derivados, no tecleados**: «204 fuentes» (P-01, P-19) y «73 experimentos» (P-01, P-20, P-24) se recalculan al final de P-22/P-20 contando filas de los Anexos D y E; si el número difiere, se corrige en los tres lugares. P-22 suma salidas nuevas (L8, L9, L11, L12, L16) que podrían o no tomar ID propio: el número tiene que salir del Anexo E, no del parche.
3. **Laboratorio**: todo experimento tocado por P-22 se vuelve a correr y su salida versionada se reemplaza; EA-1 rc=0 antes de aplicar P-16 (el Anexo A tiene que coincidir byte a byte con `A-plantillas/repo/`, verificación L17).
4. **Marcas**: el reemplazo del vocabulario cerrado (C1-40, unas cien marcas) se hace marca por marca con conteo antes/después, no con sustitución ciega (ya pedido en mi voto del ciclo; el chequeo global 5 de `03-Parches.md` lo cubre).
5. **Rótulos de Windows**: toda afirmación nueva sobre Git Bash, Visual Studio, Docker Desktop o firma sin clave lleva **[no verificado]** con motivo (los parches lo cumplen; se revisa al aplicar).
6. **Datos volátiles** (`actions/attest` v4.2.2 por SHA, `sdk:8.0.425-bookworm-slim`, `python:3.12.15-slim@sha256:…`): se re-resuelven al cerrar la guía, como declara el auditor en su §5.

## Votos

| Id | Voto | Fundamento |
|---|---|---|
| P-01 | APLICAR | Reversible, cinco reemplazos literales. Rotura posible: conteos 204/73 desalineados con los anexos (condición 2). `fuentes_consultadas` pasa a una cadena entre comillas, YAML válido. Origen: guía. |
| P-02 | APLICAR | Reversible; quitar las tres «Partes» no rompe anclas (el parche lo verifica: nada enlaza a ellas). Origen: guía. |
| P-03 | APLICAR | Reversible, radio amplio por el vocabulario de marcas (condición 4). La exclusión de enfoques de entorno completo y el enlace a Despliegue no cambian alcance: enlazar otras guías está permitido por el contrato. Comandos de Windows rotulados [no verificado]. Origen: guía. |
| P-04 | APLICAR | Reversible; los comandos de §1.2 los corrió el auditor y hoy los primeros comandos fallan, así que corregir baja riesgo. Origen: guía + laboratorio (P-22 L1–L2). |
| P-05 | APLICAR | Reversible. Rotura posible: la reasignación de actividades (ACT-ARQ/ACT-OPS) y los ○ de §9 tienen que coincidir con §11.4 (P-14 punto 12) y §12 (P-15); los parches ya lo hacen. Origen de la decisión «sólo CI» en `03-Marco-De-Referencia.md`, corregida por P-23. |
| P-06 | APLICAR | Reversible. Es el parche con más referencias cruzadas (§3 alimenta §6, §7, §8, §12): verificar anclas y los IDs ESC/CTX/ACT con el chequeo global 1. La fila «disable en toda máquina» depende de CI-05 reabierta (P-23, cubierto). |
| P-07 | APLICAR | Reversible; describir #83320 como arreglo y bajar la rama ACP UTF-8 a pregunta **quita** una afirmación no sostenida (reduce riesgo). Capa de origen incompleta: la rama «Windows con ACP UTF-8» nace en N1 (diagrama L75 y L78) y en `04-Integracion.md` L245; P-23 sólo trae la nota de C1-11 para N1. Se aplica después de P-23 mejorado. |
| P-08 | APLICAR | Reversible. Riesgo propio: el paso 5 de la migración (árbol limpio, `git diff --quiet`) corrige un defecto que sí es irreversible para el lector (pérdida de trabajo sin commitear): prioridad alta. Acepto la síntesis de C1-10 (arriba). Capa de origen incompleta: N2 L105 y L288 y N8 L140 afirman `.csproj` sin BOM por regla de lector; P-23 no los anota. Se aplica después de P-23 mejorado. |
| P-09 | APLICAR | Reversible. El costo de `disable` y el «CLI sí, VS según SDK» se apoyan en E1 (exit 145) y en la inspección de targets que P-22 L8 versiona; lo no ejecutado queda [no verificado]. pnpm `pmOnFail` con E1 (P-22 L9). Origen en N3 y CI-05: cubierto por P-23. |
| P-10 | APLICAR | Reversible; dirección (a) de C1-03, la de menor radio que voté. NU1603 con/sin lock en SDK 8 y 10 respaldado por `nu1603-sdk10/salida.txt`; pnpm/Yarn por `locks-multiplataforma/`. Origen en N4 y N0: cubierto por P-23. |
| P-11 | APLICAR | Reversible; dirección (b) de C1-21, 4-0. Rotura posible: A.9, A.13, B.3 y §12 paso 7 deben cambiar juntos (P-15, P-16, P-17 lo hacen). Capa de origen incompleta: N5 L107 («digest en todo lo versionado… `image` del devcontainer»), L108 y L372 sostienen la política que el parche reemplaza; P-23 declara «C1-20/C1-21 (CI-06, N5)» pero su tabla no trae fila de N5. Se aplica después de P-23 mejorado. |
| P-12 | APLICAR | Reversible. Baja afirmaciones (L1 de inmediato, verificación del predicado) y condiciona la firma: reduce riesgo. Keyless y `builder.id` en BuildKit rotulados [no verificado]. SHA de `actions/attest` volátil (condición 6). Origen en N6 y `03-Marco-De-Referencia.md`: cubierto por P-23. |
| P-13 | APLICAR | Reversible. Riesgo medio ya señalado en mi voto del ciclo (C1-05): `compuerta.sh`/`verificar.sh` quedan como dos ejemplos de un diseño, sin fusionarse, lo que evita romper N7, N8 y A.11. «Falta de herramienta ≠ violación» respaldado por P-22 L13. Origen en N7: cubierto por P-23. |
| P-14 | APLICAR | Reversible, costo alto (reconstruir E8-3/E8-6, P-22 L14–L16). La igualdad A = B como prueba de regresión en CI se afirma como criterio y no como hecho medido: correcto. Capa de origen incompleta: N8 L230 («la comparación A = B se hace con la configuración de publicación explícita», C1-29) no tiene nota en P-23. Se aplica después de P-23 mejorado. |
| P-15 | APLICAR | Reversible; partir el paso 8 en 8a/8b es la dirección 4-0 de C1-18. Rotura posible: los pasos de §12 se citan desde §5–§11 y el Anexo B; verificar anclas «paso 8b». |
| P-16 | APLICAR | Reversible. El cambio de mayor radio del lote en el laboratorio (A-plantillas, EA-1). Respaldado: lock sólo en `Exe` vía `Directory.Build.targets` (`lock-solo-ejecutables/`), Node 24 por digest (`a10-node24/`). El esqueleto con `exit 1` cambia un daño silencioso por un fallo visible: reduce riesgo. Condición 3 (EA-1 rc=0 y diff vacío con el Anexo A). |
| P-17 | APLICAR | Reversible; alinea B.1–B.3 con P-08, P-10 y P-11. Sin afirmaciones nuevas fuera de las de esos parches. |
| P-18 | APLICAR | Reversible y aditivo. Riesgo: definiciones nuevas sin fuente; cada entrada debe remitir a su `[Bnn]` o a la sección donde se define. |
| P-19 | APLICAR | Reversible. El riesgo de los permalinks (un SHA mal copiado) está cubierto: el auditor los verificó con 200. B194–B204 tienen fecha 2026-10-09. |
| P-20 | APLICAR | Reversible. Condición 2: el total de experimentos sale del Anexo E después de P-22. |
| P-21 | APLICAR | Reversible. La tabla de trazas cubre todos los IDs de `traces:` del front matter (P-01…P-10, R-01, R-02, R-03, R-06, R-07, R-PROF, R-PRIV; verificado contra la línea 15 de la guía). Quita el «pendiente de la mesa» del entregable. |
| P-22 | APLICAR | Reversible (`chmod`, archivos nuevos, salidas regeneradas). Costo alto, no riesgo alto: cada fila trae su verificación. Observación menor: en L3 conviene un identificador de ejemplo que no se parezca a identificadores del caso privado (p. ej. `Año` en lugar de uno que empiece con `Ç`); el `grep` de R-PRIV del cierre lo controla. |
| P-23 | MEJORAR_PLAN | Es el vehículo de la capa de origen y le faltan filas. Las correcciones de la guía de P-07, P-08, P-11 y P-14 quedarían contradichas por el núcleo que las originó. Agregar, con el mismo formato de nota fechada de solo agregado: **N1** L75/L78 (C1-35: la rama «Windows con ACP UTF-8» es pregunta abierta; la prueba de #83320 contradice la deducción) y `04-Integracion.md` L245 (ídem); **N2** L105 y L288 (C1-10: en la familia .NET el BOM es convención; `dotnet new console` crea `.csproj` con BOM, E2-6); **N5** L107, L108 y L372 (C1-20/C1-21: digest + bot en lo que construye lo publicado; devcontainer con etiqueta fija o la receta de la CI; Docker documenta el digest en los PR de Dependabot [B113], GitHub no lo menciona); **N8** L140 (C1-10, ídem N2) y L230 (C1-29: igualdad A = B como prueba de regresión en la CI). Además, una pasada de `grep` en `Nucleos/` y `04-Integracion.md` de cada frase que los parches P-03…P-17 reemplazan, para listar cualquier otro origen sin nota. El resto de P-23 se aplica como está. |
| P-24 | APLICAR | Reversible y de costo nulo sobre la guía. No escribir la ia-db respeta la restricción de escritura de la corrida; registrar el apartamiento con la fila propuesta para el PO satisface Rule-Indexing por la vía que el proyecto prevé (avisar todo apartamiento). No es disparador 2: existe una salida que respeta las dos restricciones. Condición: el cierre del ciclo lo lista en «pendientes para el PO». |

## Resumen

- APLICAR: 23 (P-01…P-22, P-24), con las condiciones transversales 1–6.
- MEJORAR_PLAN: 1 (P-23, capa de origen incompleta para C1-10, C1-20/C1-21, C1-29 y C1-35).
- NO_APLICAR: 0. ESCALAR: 0. Veto: ninguno (todo reversible).
- Síntesis de C1-10: aceptada; no pasa a segunda ronda.
