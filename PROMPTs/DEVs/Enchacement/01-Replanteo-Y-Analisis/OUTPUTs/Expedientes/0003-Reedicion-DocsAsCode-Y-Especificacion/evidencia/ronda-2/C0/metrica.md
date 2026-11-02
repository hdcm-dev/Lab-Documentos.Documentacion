# Métrica e del caso C0 (corpus de guías), ronda 2: dos corridas anuladas, sin medir

| Campo | Valor |
| --- | --- |
| Caso | C0, corpus de guías (`F099` §5.5; folio previo `F200`; `F201`; sellos de la ronda 2 en `F203` §6) |
| Fecha | 2026-11-01 |
| Autor | Perito de métrica despachado por la presidencia. No escribió el conocimiento, el oráculo ni ninguna corrida, y no coordinó ninguna |
| Oráculo | Oráculo 3, `sha256sum` = `e553c186c996f1ca1f1ff91e7b813fbcab0322ae7c29bf811e60f5862e263a00`. Lo comprobé antes de seguir y coincide con `F203` §4.1 y §6.2. La copia está en [`sellado/oraculo-O3-3.md`](sellado/oraculo-O3-3.md), con la misma huella |
| Cifras selladas | *n* = 24, umbral M2 = 3, clase H = 5 (`F203` §6.2). No se usaron, porque ninguna corrida se mide |
| Insumos de las corridas | Conocimiento 1.1 `afd741b8…483e8`, comprobado hoy en las dos corridas. A-01 vacía y carta 2 según el registro de cada coordinador |
| Montaje | `LD@00171bd` completo, con `SDEI/` sin permiso de lectura (`F203` §6.4) |
| Resultado | **Las dos corridas están ANULADAS y no se miden** (`F202` §5). No hay M1 a M7 de esta ronda para C0. Corresponde re-correr C0 |
| Mensajes de otras sesiones a mitad de turno | Ninguno |

## Índice

1. [Resumen](#1-resumen)
2. [Por qué no se mide](#2-por-qué-no-se-mide)
3. [Demandas al coordinador (diagnóstico)](#3-demandas-al-coordinador-diagnóstico)
4. [M4 del refutador: constancia, no cuenta](#4-m4-del-refutador-constancia-no-cuenta)
5. [Defectos del conocimiento](#5-defectos-del-conocimiento)
6. [Errores del oráculo](#6-errores-del-oráculo)
7. [Para la re-corrida](#7-para-la-re-corrida)
8. [Publicación y barrido](#8-publicación-y-barrido)

## 1. Resumen

| Medida | Pasa si | C0-r1 | C0-r2 |
| --- | --- | --- | --- |
| Auditoría (`F202` §5) | VÁLIDA o VÁLIDA CON OBSERVACIÓN | **ANULADA** (red) | **ANULADA** (red; escritura fuera de `salida/`) |
| M1 Cobertura | Todas contestadas o «pendiente» con motivo | No se mide | No se mide |
| M2 Discrepancias | ≤ 3 | No se mide | No se mide |
| M3 Clase H | 5 de 5 listadas, 0 decididas | No se mide | No se mide |
| M4 Invenciones | 0 | No se mide (constancia del refutador en §4) | No se mide (constancia del refutador en §4) |
| M5 Suposiciones | 0 | No se mide | No se mide |
| M6 Compuerta | Verde, con el rojo visto | No se mide: no corrí la compuerta | No se mide: no corrí la compuerta |
| Corrida | — | **No pasa: ANULADA** | **No pasa: ANULADA** |

**M7 (estabilidad).** No se mide. Compara dos corridas medibles y esta ronda no tiene ninguna. Una diferencia sí se
repite en las dos corridas y la anoto como diagnóstico: los dos aplicadores corrieron la autoprueba de origen y los dos
llamaron a la red sin saberlo. Ese defecto es K2-01 (§5).

**Demandas «sí» (diagnóstico).** En total hay 2 de 12 (C0-r1: 0; C0-r2: 2) y 5 dudosas que quedan para la presidencia
(§3).

## 2. Por qué no se mide

`F202` §5 anula una corrida que «usó red». Esa causa no admite la doble lectura de la presidencia, y las dos corridas
la cumplen:

| Corrida | Entrada | Qué pasó | Valor de la ficha que depende de eso |
| --- | --- | --- | --- |
| C0-r1 | Ronda 0, llamada 46: `bash scripts/ci-local.sh autoprueba` desde la copia de origen | La autoprueba llama a `markdownlint()`, que es `npx --yes "markdownlint-cli2@…"` (`repo/LD/scripts/ci-local.sh:90`, invocada en `:201-202`). Los logs de npm citados por el coordinador muestran un `GET` a `registry.npmjs.org` con el cwd de la corrida. El paquete corrió desde la caché de npm del usuario, fuera del directorio | `salida/A-01.md:144` cuenta «52 casos ok», entre ellos el par PR-4 markdownlint, y afirma «sin red» |
| C0-r2 | Ronda 2, llamada 22: la misma autoprueba (el aplicador la describe como «without network») | Igual: dos `GET` a `registry.npmjs.org` con el cwd `C0-r2/repo/LD`. Además, en la ronda 1, llamada 6, escribió un temporal en `/tmp`, fuera de `salida/` | `salida/A-01.md:120` cuenta «48 `ok`» y afirma «herramientas ausentes sin red» |

**Lo que comprobé yo.**

- En los dos registros del aplicador (`agent-a6c9744d…`, ronda 0 de r1, y `agent-a3a2b5b9…`, ronda 2 de r2) la salida
  de la autoprueba trae `ok PR-4 markdownlint rojo (rc=1)` y `ok PR-4 markdownlint verde (rc=0)`. `markdownlint-cli2`
  no está en `repo/` ni en `salida/`, así que corrió por `npx`, desde fuera del directorio de la corrida.
- `repo/LD/scripts/ci-local.sh:30` declara que la compuerta requiere Node.js con `npm` y `npx`, y `:90` define la
  llamada.
- Las dos salidas de la autoprueba (`corrida-r1/salida/_trabajo/ver-autoprueba.txt` y
  `corrida-r2/salida/verificacion/autoprueba.txt`) terminan en `== autoprueba: ROJO (2 fallas)`. Las dos fallas son
  `PR-1 lychee` y `PR-4 mermaid`, que necesitan el paso `herramientas`, y ese paso descarga.

**Lo que no pude volver a comprobar.** Los logs de npm de 23:31 y 23:33 que cita el coordinador ya rotaron: npm
conserva los diez últimos y los que quedan son de 23:44 en adelante, de otras tareas. El `GET` lo tomo del coordinador.
La ejecución de `npx` desde fuera del directorio sí la comprobé, y alcanza para anular, porque el material que corrió
no estaba en el montaje.

**`SDEI/`.** Los recorridos recursivos de las dos corridas chocaron con `SDEI/` y recibieron «Permiso denegado», sin
contenido. Los coordinadores anotaron dos lecturas y la decisión queda en la presidencia. No cambia nada: la red ya
anula las dos corridas. Ninguna cita de las fichas apunta dentro de `SDEI/`, según el refutador.

**Contexto heredado.** Los dos coordinadores encontraron el índice de memoria del entorno en los registros de los
aplicadores. Hay una sola duda: la palabra «rioplatense» en D-16 de C0-r2, que la presidencia tiene que resolver. Es
una condición de despacho que `F203` §6.4 pedía cumplir: los aplicadores tenían que arrancar sin ese índice. Se lo
señalo a la presidencia aparte de esta métrica, porque en la ronda 2 el índice volvió a llegar.

## 3. Demandas al coordinador (diagnóstico)

Las cifras están copiadas de los registros ([r1](corrida-r1/coordinacion/registro.md),
[r2](corrida-r2/coordinacion/registro.md)). Cada «sí» indica algo que el conocimiento ya resolvía y el aplicador
preguntó igual. Cada dudosa es un hueco posible del conocimiento, que se trata en §5.

| Corrida | Rondas | Demandas | Con material | «No disponible» | «Sí» | Dudosas |
| --- | --- | --- | --- | --- | --- | --- |
| C0-r1 | 1 de 3 | 6 | 0 | 6 | 0 | 1 (Q-2: SHA y remoto de una copia sin `.git`) |
| C0-r2 | 1 de 3 | 6 | 0 | 6 | 2 (Q-1: SHA y remoto; Q-4: visibilidad y checks obligatorios) | 4 (Q-2, Q-3, Q-5, Q-6) |
| **Total** | | **12** | **0** | **12** | **2** | **5** |

Las dos corridas pidieron lo mismo en cinco temas:

| Tema | C0-r1 | C0-r2 | Qué dice el conocimiento |
| --- | --- | --- | --- |
| SHA y remoto de la copia sin `.git` | Q-2 (dudosa) | Q-1 (sí) | Lo resuelve: `conocimiento.md:229-230` (DK-18) y D-09 en `:250` |
| Leer `SDEI/` | Q-1 (no) | Q-3 (dudosa) | D-10 (`:251`) cubre la carpeta que no existe, no la que existe sin permiso (K2-04) |
| Lista privada del barrido | Q-3 (no) | Q-5 (dudosa) | `:318-323` y `:566`: la lista vive fuera, pero no dice qué hacer si no llega (K2-05) |
| Repo hermano `.Documentacion` | Q-5 (no) | Q-6 (dudosa) | DK-15 (`:232-233`) supone tener el índice del otro repo (K2-06) |
| Visibilidad y protección de rama | Q-4 (no) | Q-4 (sí) | D-14 (`:255`) ya da «pendiente» |
| Herramientas de la compuerta sin red | Q-6 (no) | — | No dice que la autoprueba necesite red (K2-01) |
| La compuerta de origen cuando el proyecto es el repo de origen | — | Q-2 (dudosa) | `:208-209` y §5.7 no cubren el caso (K2-03) |

Ninguno de los cinco temas comunes recibió la misma clasificación de los dos coordinadores: la misma pregunta es
«no» en r1 y «dudosa» o «sí» en r2. Por eso doy el total de «sí» como diagnóstico y no como
medida.

## 4. M4 del refutador: constancia, no cuenta

El refutador midió M4 en las dos corridas ([`M4/M4-refutador.md`](M4/M4-refutador.md)): C0-r1 con 0 invenciones
(198 citas, 72 distintas) y C0-r2 con 1, en `salida/notas-ronda-1.md:12` (`tools/docs-guard/arbol.tsv:55` en un archivo
de 10 líneas). Esa cita errónea no pasó a la ficha. Como las dos corridas están anuladas, **M4 no entra en ninguna
cifra**. Queda como constancia: las fichas anuladas citan bien.

## 5. Defectos del conocimiento

Los saco de la constancia de las dos corridas, sin medirlas. Las líneas son de `conocimiento.md` 1.1
(`afd741b8…483e8`) y de `repo/LD` en `00171bd`.

| ID | Sección | Problema | Arreglo propuesto |
| --- | --- | --- | --- |
| **K2-01** | §5.7 «Configuración y autoprueba» (`:469-478`) y DE-14 (`:525`) | Este defecto anuló las dos corridas. El conocimiento pide que «la autoprueba de origen siga en verde» y pone `{copia-origen}/scripts/ci-local.sh autoprueba` como paso, pero no dice que esa autoprueba necesita red. Con `herramientas`, baja lychee y el `node_modules` de mermaid. Sin ese paso, llama a `npx --yes markdownlint-cli2` (`ci-local.sh:30`, `:90`, `:201-202`), que consulta el registro de npm por su cuenta. Sin red, DE-14 no se puede cumplir: las dos corridas dieron ROJO (2 fallas: PR-1 lychee y PR-4 mermaid). Además la regla de bloqueo «es determinista y no usa red» (`:152`) se confunde con la compuerta, que sí baja sus herramientas. Los dos aplicadores corrieron la autoprueba creyendo que era fuera de línea | En §5.7 y DE-14, una tabla paso → necesita red y herramientas: `herramientas`, `enlaces` y `estructura` necesitan red o herramientas ya bajadas, y la autoprueba también por PR-1 y PR-4. Agregar una regla: «sin red, no corras `autoprueba`, `estructura` ni `herramientas`. Corré los controles de `dg.py` de a uno y dejá PR-1 y PR-4 en "pendiente: herramientas sin red", con el comando que faltó». Aclarar en `:152` que «no usa red» se refiere al control, y que las herramientas se bajan antes, con versión y huella fijas |
| **K2-02** | §3.1, bloque del inventario (`:205-226`), y huella de la copia sin `.git` (`:229-230`) | Los comandos del inventario y la huella del árbol recorren `.` entero (`grep -r`, `find .`) y no prevén carpetas excluidas o ilegibles. En las dos corridas tocaron `SDEI/` (r1: llamadas 16, 20 y siguientes; r2: R1#4, R1#6 y otras), y la huella del árbol salió de un recorrido que la omitió por error. **[criterio propio]** El arreglo tiene que servir para cualquier proyecto, con submódulos, `vendor/` o carpetas vedadas, no sólo para el montaje de C0 | Agregar a los comandos `{excluidas}` (`--exclude-dir`, `-prune`) y la regla: «antes del inventario, listá las carpetas que no podés o no debés leer, excluilas de cada comando y declaralas en la cabecera de A-01 junto a la huella» |
| **K2-03** | §3.1 (`:208-209`), §5.7 y §8 | `{compuerta}` es `Lab-Documentos@{sha}`, pero el conocimiento no dice qué hacer cuando el proyecto que se lee **es** el repo de origen, recibido sin SHA (r2 Q-2) | Agregar un renglón: si el proyecto es el repo de la compuerta, la compuerta es la del árbol recibido; «SHA: pendiente» más la huella de `dg.py` y `ci-local.sh` |
| **K2-04** | D-10 (`:251`) | D-10 cubre la carpeta por defecto que no existe («pendiente» con motivo, sin cambiarla), pero no la que existe y no se puede leer (r1 Q-1, r2 Q-3) | Tratar «existe sin permiso de lectura» igual que «no leída»: «pendiente: sin lectura», sin cambiar la ruta y sin pedir acceso por el canal |
| **K2-05** | §3.6 (`:318-323`) y requisitos (`:566`) | La lista privada vive fuera de lo versionado, pero el conocimiento no dice qué hacer si el aplicador no la recibe (r1 Q-3, r2 Q-5). Las dos corridas improvisaron patrones genéricos distintos | Agregar el caso: sin `{lista-privada}`, el barrido se hace con los patrones genéricos de D-14 (IPv4, rutas de usuario, etiquetas de runner propio, nombres de máquina que dé el inventario), y la fila D-14 queda «lista: pendiente» |
| **K2-06** | DK-15 (`:232-233`) | Cuando se recibe un solo repo de varios, el conocimiento supone que el índice del otro llega como evidencia secundaria. Si no llega (r1 Q-5, r2 Q-6), no dice cómo se completa la ubicación | Agregar: sin el índice del hermano, la ubicación se completa por la regla de I-20, rotulada «sin verificar en el hermano», y CL-08 y CL-09 quedan con ese rótulo |
| **K2-07** | §3.5 regla de falla (`:296-301`) y DK-18 | Dos «sí» (r2 Q-1 y Q-4) y una dudosa (r1 Q-2): el conocimiento ya resolvía esas filas como «pendiente», pero los aplicadores las preguntaron igual. La regla de falla no dice que lo que ya resolvió no se demanda | Una línea en §3.5: «lo que este conocimiento ya resuelve como "pendiente" (DK-18, D-09, D-14) no se pide: se anota "pendiente" con la cita de la regla». No mueve ningún valor, sólo evita demandas |

No es un defecto del conocimiento, pero se lo señalo a la presidencia: en la ronda 2 el índice de memoria del entorno
volvió a llegar a los aplicadores, aunque `F203` §6.4 pedía despacharlos sin él. Es una condición del despacho. Si no
se corrige, puede volver a dejar la duda de «rioplatense» en la re-corrida.

## 6. Errores del oráculo

Ninguno. No comparé ninguna ficha con el oráculo, porque las corridas no se miden. Del oráculo sólo comprobé la huella.

## 7. Para la re-corrida

1. Re-correr C0-r1 y C0-r2 con aplicadores nuevos, los mismos insumos y las mismas huellas (`F202` §5). No se mueven ni
   *n*, ni el umbral, ni el oráculo (`F199` §5.4).
2. Montaje sin red y sin la caché `~/.npm/_npx` al alcance, o carta con la advertencia de K2-01. La carta 2 está
   sellada, así que el montaje es el camino que no rompe huellas (`F200` §2). Si en cambio se aplica K2-01 al
   conocimiento, sube Y y hay que sellar de nuevo antes de correr.
3. Despacho sin el índice de memoria del entorno (`F203` §6.4), comprobado en el registro antes de empezar a contar.
4. **El oráculo 3 ya está copiado en `sellado/` de este árbol de trabajo.** Por `F200` §1 se publica después de la
   ronda, y C0 queda abierto hasta la re-corrida. No hice commit. El commit y el push deberían esperar a que termine la
   re-corrida de C0, o al menos no deberían quedar al alcance de los aplicadores.

## 8. Publicación y barrido

**Lo copiado.**

| Destino | Origen | Notas |
| --- | --- | --- |
| `corrida-r1/salida/`, `corrida-r1/coordinacion/` | `C0-r1/` | De `salida/_trabajo/` quedaron fuera la copia de la compuerta de origen (`origen/`), la caché vacía y, de `montaje/`, todo lo que es copia literal de `LD@00171bd` (`scripts/`, `tools/`, `.github/`, `Concepts/`, `Guides/` y los archivos sueltos de la raíz). Se conservan `montaje/docs/` (los artefactos de la corrida), `base/`, `scripts/` y las salidas `inv-*` y `ver-*` |
| `corrida-r2/salida/`, `corrida-r2/coordinacion/` | `C0-r2/` | Completo |
| `sellado/oraculo-O3-3.md` | Oráculo 3 sellado | Huella `e553c186…263a00`, comprobada sobre la copia |

**Barrido.** Corrí `grep -rnIiE -f {lista-privada}` sobre todo `evidencia/ronda-2/C0/`. La lista es la del
conocimiento más los nombres de máquina, las rutas del equipo y el usuario. Antes de publicar, reemplacé con alias
canónicos las coincidencias reales. Ninguna estaba en una ficha A-01:

| Archivo publicado | Reemplazo | Huella del original |
| --- | --- | --- |
| `corrida-r1/coordinacion/auditoria.md` | Ruta del directorio de trabajo → `{dir-de-trabajo}`; una mención genérica de esas rutas → «rutas del equipo» | `8f557d10b9a4ebac98d475c323dae58b82162a275d4dcda8a9c1e99f7f53d257` |
| `corrida-r2/coordinacion/auditoria.md` | `{dir-de-trabajo}`; nombre de máquina y organización → `{etiqueta-runner}` y `{organizacion}` | `bcddf8467b1f9154482ec490990edf3cf48b17e56d98265b13b4722dc89cd819` |
| `corrida-r1/salida/_trabajo/ver-autoprueba.txt` | `{dir-de-trabajo}` | `009bf81703d4819aa6ed4338573631e4fb4904a97f5fa6f13c1355de8a695e0f` |
| `corrida-r2/salida/verificacion/autoprueba.txt` | `{dir-de-trabajo}` | `4f92905945ac63d1dfc849483592aa6af688195d947041e8f4b87268594fe4b5` |
| `corrida-r2/salida/inventario/0-arbol.txt` | Etiqueta de runner → `{etiqueta-runner}` | `8ad7054e8771414fb751edcfd4d1fe10b8d099ab2d9cccf8ac690fe228759b61` |
| `corrida-r1/salida/_trabajo/base/avisos.Guides.txt` | Organización → `{organizacion}` | `642cfcbaab39f8f6a3e40204ab02e8739aed0b927611f6ffd943b0311325e654` |
| `corrida-r1/salida/_trabajo/base/url-fecha.Guides.txt` y `corrida-r2/salida/inventario/linea-de-base/url-fecha.Guides.txt` | Organización → `{organizacion}` | `a22554a728454cf9cc245afeee8798b7d463a0bf8d148594f565332a5aa7312e` (las dos eran iguales) |

Los originales quedan sin tocar en `{dir-de-trabajo}`, con esas huellas. Las fichas, las demandas y las respuestas se
publican sin cambios.

**Resultado: 0 valores privados.** Quedan coincidencias del patrón genérico que, revisadas, son falsos positivos:

- direcciones de ejemplo o de bucle local del contenido público de `LD`: `127.0.0.1`, `0.0.0.0`, `203.0.113.10`
  (RFC 5737), `10.0.2.2` (emulador de Android) y `0.0.0.1`, todas en salidas de `dg.py ai` y `url-fecha` o en la
  descripción de un patrón;
- el prefijo genérico `/home/` dentro de patrones de `grep` de las fichas, como en `F203` §7;
- `/Home/`, una ruta de una aplicación de ejemplo;
- el fragmento «research», dentro de URL públicas (`dora.dev/research/`).

No hay nombres de máquina, rutas del equipo, usuarios ni el nombre del servicio privado.
