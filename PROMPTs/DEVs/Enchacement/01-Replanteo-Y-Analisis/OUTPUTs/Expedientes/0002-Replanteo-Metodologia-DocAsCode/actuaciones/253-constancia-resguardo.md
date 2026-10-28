---
doc_id: EXP0002-F253
doc_type: constancia
title: Constancia del resguardo privado de la vuelta de E1 — inventario por clase, bundles con sha256, inalcanzables anclados, piezas de E01, copia de la guía 16 y manifiesto en dos copias
status: vigente
origin: agent
confidence: alta (cada cifra sale de un comando corrido al ejecutar U00 y, para §7, al ejecutar U10; el manifiesto se verificó en las dos copias)
owner: presidencia de la mesa de Replanteo y análisis DocAsCode (vuelta de E1)
last_review: 2026-10-28T13:35:47-03:00
audience: [PO, presidencia, refutador, mesa de la opción B, bitacorista]
traces: [EXP0002-F240, EXP0002-F250, EXP0002-F252, EXP0002-F254]
---

# 253 — Constancia del resguardo privado

| Campo | Valor |
| --- | --- |
| Tipo | constancia |
| Fecha | 2026-10-28T13:35:47-03:00 (resguardo armado el 2026-10-28 por U00-RESG; agregado de §7 por U10) |
| Autor | Presidencia de la mesa (vuelta de E1), por las unidades U00 y U10 del acta `250`. Decisiones DEC-01, DEC-02, DEC-03 y DEC-07 |
| Ubicación | `{resguardo-privado}`: carpeta privada de hpdev, fuera de los dos repos y de `{dir-de-trabajo}`, con permisos 0700 y réplica en infravm, la máquina de respaldo de la contingencia. Esta constancia no da rutas ni valores |

## Índice

1. [Inventario por clase](#1-inventario-por-clase)
2. [Bundles e inalcanzables](#2-bundles-e-inalcanzables)
3. [Piezas (c) de E01](#3-piezas-c-de-e01)
4. [Copia de la guía 16](#4-copia-de-la-guía-16)
5. [Otras clases guardadas](#5-otras-clases-guardadas)
6. [Verificación](#6-verificación)
7. [Agregado de U10: lista privada del patrón S2](#7-agregado-de-u10-lista-privada-del-patrón-s2)
8. [Lo que queda pendiente](#8-lo-que-queda-pendiente)
9. [Pase](#9-pase)

## 1. Inventario por clase

Clases de DEC-01; las cantidades son las de los relevamientos R2 y R3 (`250` §12: no se volvieron a contar).

| Clase | Lab-Documentos | Lab-Documentos.Documentacion | Destino |
| --- | --- | --- | --- |
| (a) ya en `main` o superado | 179 | 341 | No se integra. Queda dentro del bundle de rescate |
| (b) único y publicable | 0 | 0 | No hay. Ningún PR nace del rescate |
| (c) privado o binario | — | 4 piezas de E01 (2 APK y 2 zip) | Extraídas con `git show` desde el rescate y verificadas por sha256 (§3) |
| (d) reproducible | 4 | 283 | No se integra. Queda dentro del bundle de rescate |

## 2. Bundles e inalcanzables

| Bundle | Contenido | Refs | `git bundle verify` | sha256 |
| --- | --- | --- | --- | --- |
| ld-rescate | rama `rescate/hpdev-2026-10-28` de Lab-Documentos (`674466c`) | 1 | exit 0 en el clon y en un repo vacío | `ad5944b034f0a4903edce698f1b64d0d096e03a6ae17913a629969bc96b85f18` |
| ldd-rescate | rama `rescate/hpdev-2026-10-28` de Lab-Documentos.Documentacion (`20cd8bb`) | 1 | exit 0 en el clon y en un repo vacío | `21a8c396bc9386947b4d9d14c464bc1526f625c2602d97aa8f5b35a0daabf3aa` |
| ld-inalcanzables | los 63 commits inalcanzables de Lab-Documentos | 63 | exit 0 en el clon y en un repo vacío | `a67afb6ba196aa1894a6152c829bf8c6b3de283cd4f550a573f09f3808be43f3` |
| ldd-inalcanzables | los 9 commits inalcanzables de Lab-Documentos.Documentacion | 9 | exit 0 en el clon y en un repo vacío | `f33de918e4a3dfbf9db6a6acda5cf5011d9b1ad73ddb2eea20c4454b231f4bfa` |

Inalcanzables medidos al ejecutar, con `git fsck --unreachable --no-reflogs`:

| Repo | Commits | Trees | Blobs |
| --- | --- | --- | --- |
| Lab-Documentos | 63 | 109 | 28 |
| Lab-Documentos.Documentacion | 9 | 11 | 4 |

Los commits coinciden con la medida del jurado (`250` §4.1: 63 y 9).

Cada commit quedó anclado con una ref local `refs/resguardo/<repo>/<sha>`. Después de anclarlos quedaron objetos que
ningún commit alcanza (4 blobs y 4 trees en Lab-Documentos; 3 blobs en Lab-Documentos.Documentacion): se anclaron con
`refs/resguardo/<repo>/obj/<sha>` y se volcaron crudos con `git cat-file`, porque un bundle sólo lleva lo que alcanzan
sus commits. Después de anclar todo, `git fsck --unreachable --no-reflogs` da **0 objetos** en los dos clones.

Las refs `refs/resguardo/*` son sólo locales: `git ls-remote origin` da 0 coincidencias en los dos repos y no hay
refspec de push que las incluya.

## 3. Piezas (c) de E01

Coinciden byte a byte con la tabla de `INFORME.md` del ensayo E01 en `main` (líneas 301 a 304):

| Pieza | sha256 | Bytes | ¿Coincide? |
| --- | --- | --- | --- |
| apk x64 | `3a7d2e351b585d1ddb013655d170039a4f1412a536de4689b284c08b0baf6628` | 18 607 649 | Sí |
| apk arm64 | `eb6250e06de4585b76edab2c7858cc4c64cc2a47a278d262369993848b264f9c` | 18 492 132 | Sí |
| contenido-v1.zip | `b7828d721900ad3a689cfff5e6b22a89f4b52f934290c3cc4bd982939cfa4416` | 3 394 811 | Sí |
| contenido-v2.zip | `b7fb650c6b9fd81901c01a71daa59acb76609386c5959ed8c9bf01fdbee253a3` | 3 394 807 | Sí |

## 4. Copia de la guía 16

`PROMPTs/Guides/16-IA-Layer` no tiene seguimiento en Lab-Documentos.Documentacion y su sesión dueña sigue escribiendo.
La copia es un tar.gz con su manifest sha256, hecha sólo leyendo: no se tocó la carpeta ni se usó git sobre ella.

- `find -type f` dio **403 archivos** antes y después del tar, en el mismo minuto. El tar tiene 403 entradas que no
  son directorios y el manifest, 403 líneas.
- El manifest verifica contra el árbol vivo y contra el tar extraído.
- La cifra cambió desde las anteriores (390 del jurado, 373 de R1), como preveía `250` §4.1.
- sha256 del tar: `54a9551344d7982e52b3989820b213b044a690652f5451d8a55d4f1eb161657e`.
- sha256 del manifest: `a12fdf913eece952ea90eb40c4438e1c90c5a28f20fc8c5c65db5373e6f92601`.

## 5. Otras clases guardadas

| Clase | Archivos |
| --- | --- |
| Originales de `evidencia/E1-G` (los 10 archivos, más el commit de origen) | 11 |
| Valores reales de la mesa (lista de valores de fugas, patrón S2, clasificaciones e `*.hits`) | 9 |
| Notas de trabajo de la mesa (R1–R5, sus crudos, propuestas, plan, borrador del acta 250, medidas de fsck y status) | 33 |
| Bundles y objetos sueltos (4 bundles y 11 objetos crudos) | 15 |
| Piezas de E01 | 4 |
| Guía 16 (tar y manifest) | 2 |
| **Total cubierto por el manifiesto al cerrar U00** | **74** |

El total ocupa unos 138 MB.

## 6. Verificación

- `sha256sum -c MANIFIESTO.sha256` da OK en hpdev y en la réplica de infravm. Al cerrar U00 el manifiesto tenía el
  mismo sha256 en las dos copias: `b752d4f3301a44f8611a0250be3530d1834dbdf2775ef972dc43d42dea27bf8b`.
- En infravm, los 4 bundles se verificaron en repos vacíos, con exit 0.
- `git status --porcelain` de los dos clones da exactamente lo mismo antes y después. En Lab-Documentos.Documentacion
  sigue figurando sólo la guía 16 sin seguimiento.
- No se corrieron `gc`, `prune` ni `fetch --prune`.
- No se borró ninguna rama de rescate ni ninguna ref.

## 7. Agregado de U10: lista privada del patrón S2

DEC-07 separa el patrón S2 en una parte pública por clase (folio `254`) y una **lista literal privada** que vive acá.
U10 la armó a partir del patrón privado ya resguardado, con las líneas que son literales (nombres, identificadores y la
raíz de máquinas), y la agregó al resguardo:

| Dato | Valor |
| --- | --- |
| Archivo | lista privada del patrón S2, en los valores de la mesa |
| Líneas | 26 |
| sha256 | `8e3a15e15742aa647db86f659662116eff014008eb971c67e60d4bb1f66012da` |
| Manifiesto | Regenerado: 75 archivos (los 74 de §5 sin cambios más este). `sha256sum -c` OK en hpdev y en infravm |
| sha256 del manifiesto | `90e5a021ac33ab96582a10e30d3491d2f64fa74447191d59d4ebae6171273ef8`, igual en las dos copias |

## 8. Lo que queda pendiente

- Borrar las ramas de rescate y las refs `refs/resguardo/*` requiere el ok del PO (DEC-02, `250` §10 ítem 2). Quedan
  hasta que cierre E1-G2.
- Ítem 8 del resguardo (`250` §9): las refs de las ramas rojo/verde, de los despachos de G-b y del PR simulado se
  agregan cuando se citen. Cada agregado regenera el manifiesto y repite la réplica en infravm.
- El lugar del resguardo se informa al PO (DEC-03, `250` §10 ítem 8); puede pedir otro destino, por ejemplo un repo
  privado.

## 9. Pase

A la presidencia, para el lote al PO de `250` §10, y a U29, U30 y U42, que agregan el ítem 8 cuando citen sus refs ·
presidencia.
