# Voto del juez de riesgo (mesa de recuperación, 2026-10-28)

**Función:** riesgo e irreversibilidad. Miro tres cosas: pérdida de contenido, R-PRIV en un repo público y colisión con la mesa de integración. Tengo veto acotado.
**Insumos:** `01-Matriz.md` y los nueve `Panel-*.md` de esta carpeta.

**Criterio.** En esta mesa nada se commitea, así que casi todo cambio en el árbol se puede revertir: el rescate de <equipo-principal> está fuera del árbol y la línea <equipo-de-contingencia> está archivada. Hay dos cosas que no se revierten:
1. Que un dato privado llegue a un commit de un repo público.
2. Que se pierda evidencia o contenido que no tiene copia.

Por eso peso más esas dos que el riesgo de regresión. Una regresión se detecta con build, `--fake` y ArnesTests, y se puede deshacer.

**Condiciones transversales.** Valen para todo el plan:
- **T1.** Antes de tocar los `.log`, la bitácora o los Examples, se saca una copia previa fuera del árbol, en el directorio de trabajo de la mesa. Todo `sed` deja su diff guardado.
- **T2.** El barrido R-PRIV ampliado corre también sobre las capturas nuevas de REC-02. Esto incluye IPs parciales, rangos 100.x, nombres de recursos del gestor y de equipos, y rutas del home. Los endpoints viajan sólo como variable.
- **T3.** Ningún archivo de la guía 16 se commitea, se pushea ni se toma desde otro clon mientras dure la coordinación con la otra mesa. El commit lo hace la mesa de integración o el PO, y siempre con el barrido en 0.
- **T4.** Nada se escribe en `Linea-*-2026-10-28/` ni en <equipo-principal>.

## Votos

| Ítem | Opción | Veto | Fundamento desde el riesgo |
|---|---|---|---|
| REC-01 | A | no | Subir de versión una sola vez y mantener «en revisión» no afirma nada que no esté verificado. B deja un encabezado del 27-10 sobre contenido posterior, y eso induce a error. C genera versiones que nunca se entregan. Pasar a publicada queda en manos del PO, porque es irreversible frente a los lectores. |
| REC-02 | A | no | B deja la guía afirmando cosas de un artefacto que ya no se puede descargar, y C lo deja a medias. D concentra todo en la estación 2, que tiene cupo 1 y se apaga al cierre, y con eso la fase queda frágil. Condiciones: cada pieza corre entera en una sola estación. En la estación 2 no hay emuladores ni KVM. Los registros quedan fuera del árbol, con columna servidor. Una caída del entorno se informa como «no medido» y nunca se rellena. Aplica T2. |
| REC-03 | A | no | Releer antes de las cifras definitivas (B) deja sin mirar las remisiones de §8 y §11, que cambian. C achica justo el panel que cuida R-PRIV y la seguridad. |
| REC-04 | A | no | Traen fugas (RPRI-18). Sólo se aceptan pieza por pieza, redactadas y con el barrido en 0. B arrastra numeración rota y fugas al cuerpo de hallazgos. C no pierde nada irreversible, porque quedan archivados, pero desperdicia insumo. |
| REC-05 | A | no | B toca código sin ganancia y abre un riesgo de regresión. C eleva al PO una pregunta que ya no tiene objeto. Publicar la demo es irreversible y queda para el PO después de REC-03. |
| REC-06 | A | **sí, sobre B** | Hay puntos S1 en un repo público: volúmenes, contenedor, etiqueta, rangos, `Reanudar.md` y el pedido al gestor. B dejaría una fuga conocida a un commit de distancia, así que no es admisible. Pido el orden 1 a 8 y verificar al final: build n/n, demo, diffs, AC-6, AC-7, AC-8 y barrido en 0. Aplican T1 y T2. |
| REC-07 | C | no (condición) | A arregla la medición, pero deja el nombre del recurso privado del gestor en el repo público: 19 líneas de `verificar.sh`, `demo.sh`, 12 `ejemplo.json` más la demo, README y dos archivos de código (RPRI-04). Ese nombre hoy es el de un recurso **vigente**, el de la estación 1, así que no es historia. Una regresión del renombre se detecta con `--fake` y ArnesTests y se revierte. Una fuga, una vez pusheada, no se revierte. Hago mía la enmienda de AH-02: en la fase con modelo, `OLLAMA_SERVIDOR` y `RLLM_MAQUINA` no tienen valor por defecto y la fase aborta si faltan. En la bitácora, las capturas fijadas por hash no se reescriben: se declaran históricas por valor (alineado con REC-33). **Condición si gana A:** el renombre queda como requisito bloqueante de cualquier commit de la guía, no como deuda abierta. |
| REC-08 | A | no | Con 4096 (B) hay truncado silencioso: la evidencia sale mal y nadie lo ve. C mide bien pero no le advierte al lector. |
| REC-09 | A | no | Es un cambio chico y probado sin modelo. Mantener 01 deja un ejemplo que enseña un defecto. |
| REC-10 | A | no | La prueba de captura es determinista. «3 → 57» se afirma sólo después de re-medirlo. Las capturas pasan por T2. |
| REC-11 | A | no | La guía enseña a guardar los cuerpos de los pedidos. Sin la compuerta cabeceras=0, una credencial terminaría en un archivo commiteable, y eso es irreversible. La propiedad no se nombra, como pide R-PRIV. C no hace cumplir nada. |
| REC-12 | A | no | Una clave sin sesión es una fuga entre visitantes en CTX-SENS. B y C dejan publicado el patrón inseguro. |
| REC-13 | A | no | Con la prueba determinista de 4 simultáneos (AH-02-07). El riesgo de regresión en la demo queda cubierto por 70/70 más la prueba nueva. |
| REC-14 | A | no | Un Singleton que cruza sesiones sin dar error es el peor caso, porque falla en silencio. La prueba roja lo deja fijo. |
| REC-15 | B | no | Citar una tabla medida por `/v1` y con una herramienta de baja (A) traslada una composición distinta, y eso es un riesgo de afirmación falsa. Si hace falta, se re-mide con la demo de la base. La alternativa 7b se quita o se rotula. |
| REC-16 | A | no | La prueba sin modelo de 3400 demuestra la garantía. Sin ella, §8.5 apoya la defensa en algo que no alcanza. |
| REC-17 | A | no | Primero las pruebas, y sólo si fallan se toca Domain. Después se vuelve a correr AC-5 y AC-10. C deja abierta la vía sin IA. B deja la guía afirmando una regla falsa (l. 1075). |
| REC-18 | A | no | Si la salida `--fake` de 51/52 no se rotula, se puede leer como medición. Una prueba que pasa con todo Inconclusive es una compuerta vacía. |
| REC-19 | A | no | D recalcula 365 cifras en plena recuperación: mucho riesgo de error y nada que lo justifique. Mezclar métodos rompe C5. A conserva Clopper-Pearson y suma «caída = no medido», que protege contra rellenar huecos. |
| REC-20 | A | no | D reabre la demo y AC-4, y es el cambio más grande y menos reversible de la matriz. B deja DEP-09 y PD-6 apoyados en un servidor retirado. |
| REC-21 | C | no | Re-correr y sumar la fila del 4b, sí. El detector que lanza suma una segunda estimación que puede divergir de GuardaDeTruncado (abogado del diablo). Es superficie nueva en plena recuperación. Se puede sumar después. |
| REC-22 | A | no | `_Comun` lo comparten todos los ejemplos. Condición: rebuild completo (443/443) y ArnesTests después de portar el lector. El lector no puede guardar cuerpos completos en disco (aplica T2). |
| REC-23 | A | no | El texto inyectado que se cite en la guía tiene que ser sintético y pasar el barrido. |
| REC-24 | A | no | Ollama no autentica y la imagen escucha en todas las interfaces, así que la advertencia es obligatoria. La redacción sólo puede nombrar `127.0.0.1` o «la interfaz del bridge», nunca direcciones ni rangos del laboratorio. |
| REC-25 | A | no | C da una falsa sensación de autorización, y una vez publicada se copia. D migra 13 sin motivo de seguridad. |
| REC-26 | A | no | Las mutaciones y los agujeros declarados evitan presentar AC-5 como suficiente. Afirmar esa suficiencia es el riesgo. |
| REC-27 | A | no | Es un caso rojo sin modelo. Si falta la guarda, es una brecha real. |
| REC-28 | A | no | El perímetro de la demo no cambia. El barrido de comparaciones no exige corrida. |
| REC-29 | A | no | Es un oráculo determinista. Rotular por estación evita mezclar servidores. |
| REC-30 | A | no | Casos rojos sin modelo, y sólo los que dan rojo con la versión fijada. El barrido del glosario es mecánico. |
| REC-31 | A | no | Es prosa más referencias, con riesgo mínimo. C suma código y pruebas a un ejemplo y no lo pide ninguna fuga. |
| REC-32 | A | no | C reescribe la escalera, con riesgo alto de inconsistencia (C5) sin necesidad. |
| REC-33 | A | no | Es el único camino para que la bitácora sea commiteable. Lo considero reversible por T1: copia previa fuera del árbol, `sed` por mapa de valor exacto y diff guardado. Las capturas fijadas por hash no se tocan, y así no se pierden los recálculos. C deja en los `.log` nombres que se pueden limpiar sin costo. B posterga una fuga conocida hasta otra mesa, y eso es un riesgo de colisión. |
| REC-34 | A | no | No hay acción, así que no hay riesgo. Toda copia desde el insumo pasa por DECI-30 y el barrido. |
| REC-35 | A | no | Va dentro de la pasada de verificación de REC-06 y antes de REC-02, para que haya un solo cambio de `paquetes_hash` y la fase con modelo registre el definitivo. Antes hay que confirmar el transitivo de Agents.AI.Abstractions con el build. |

## Veto

Uso el veto acotado una sola vez: **REC-06, opción B**. No lo uso en REC-07: si gana A, pido que el renombre de RPRI-04 quede como **condición bloqueante de commit** de la guía.
