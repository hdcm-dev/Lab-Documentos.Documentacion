---
doc_id: EXP0002-F254
doc_type: corrigenda
title: Corrigenda del patrón S2 — parte pública por clase versionada y lista literal privada en el resguardo, con su medida de cobertura
status: vigente
origin: agent
confidence: alta en las medidas de §4, corridas sobre main de los dos repos con el comando que se transcribe; la forma de cada expresión pública es criterio propio de la presidencia
owner: presidencia de la mesa de Replanteo y análisis DocAsCode (vuelta de E1)
last_review: 2026-10-28T13:35:47-03:00
audience: [PO, presidencia, refutador, agentes que reparen E1, verificadores de E1-G2, bitacorista]
traces: [EXP0002-F099, EXP0002-F245, EXP0002-F250, EXP0002-F251, EXP0002-F253, R07]
---

# 254 — Corrigenda del patrón S2

| Campo | Valor |
| --- | --- |
| Tipo | corrigenda (sólo agregado, por referencia; estilo `125`) |
| Fecha | 2026-10-28T13:35:47-03:00 |
| Autor | Presidencia de la mesa (vuelta de E1), por la unidad U10 del acta `250`. Decisión DEC-07. Defecto DEF-68 |
| Corrige | `099` §11, fila «Comando» del barrido S2 (`099:419`); `R07` §5.13, VER-C02 (`R07:302`), en cuanto a su instrumento; el patrón de `evidencia/E1-U0c/01-barrido-s2.txt:3-4`, de `evidencia/E1-G/G-f-barrido-s2.txt` §1 y de `evidencia/E1-G/S2-folios.txt` §1. Ninguno se edita |
| Agrega | `evidencia/S2-patron/patron-publico.txt` (11 líneas) |

## Índice

1. [Qué se corrige](#1-qué-se-corrige)
2. [Parte pública](#2-parte-pública)
3. [Parte privada](#3-parte-privada)
4. [Medida](#4-medida)
5. [Cómo se corre](#5-cómo-se-corre)
6. [Efecto](#6-efecto)
7. [Pase](#7-pase)

## 1. Qué se corrige

El patrón S2 canónico describía en prosa el directorio personal, el usuario del host, el servicio privado y su
organización (`099:419`). No cubría los identificadores del control R-PRIV, la app privada, el correo, la serie del
teléfono de pruebas, la carpeta local de INFRA-privada ni la raíz de máquinas: por eso pasaron DEF-59 y DEF-60. La
variante ampliada que usó la compuerta (`S2-folios.txt` §1, 28 líneas) los cubría, pero el archivo de patrones mezclaba
expresiones por clase con valores reales, así que no se podía versionar.

**Se lee (DEC-07):** el patrón S2 tiene dos partes que se corren juntas.

| Parte | Qué lleva | Dónde vive |
| --- | --- | --- |
| Pública | Sólo expresiones por clase, sin ningún valor real | `evidencia/S2-patron/patron-publico.txt`, versionado por este folio |
| Privada | La lista literal: nombres de app, organización, servicio, usuario e identificadores | `{resguardo-privado}` (folio `253` §7). La evidencia la cita por sha256 y número de líneas |

## 2. Parte pública

Se corre **distinguiendo mayúsculas** (`grep -E`): las clases que lo necesitan ya traen las dos formas.

| Línea | Clase |
| --- | --- |
| 1 | Directorio personal de Linux, en ruta (`/home/…`) o aplanado con guiones |
| 2 | Directorio personal de macOS |
| 3 | Directorio personal de Windows |
| 4 | Raíz de primer nivel de dos letras minúsculas, fuera de las del FHS (forma de `{raíz-de-máquinas}`) |
| 5 | IPv4 privada 10/8 (RFC 1918) |
| 6 | IPv4 privada 192.168/16 (RFC 1918) |
| 7 | IPv4 privada 172.16/12 (RFC 1918) |
| 8 | IPv4 CGNAT 100.64/10 (RFC 6598), la del tailnet |
| 9 | Forma de serie de dispositivo: dos letras, dos dígitos y seis alfanuméricos en mayúscula |
| 10 | Correo electrónico |
| 11 | `usuario@host` de prompt de shell o de ssh |

La línea 4 es la que más falsos positivos da (rutas web como `/js/`); se clasifican caso por caso, como manda S2.

## 3. Parte privada

| Dato | Valor |
| --- | --- |
| Ubicación | `{resguardo-privado}`, valores de la mesa |
| Líneas | 26 |
| sha256 | `8e3a15e15742aa647db86f659662116eff014008eb971c67e60d4bb1f66012da` |
| Clases que cubre (por alias) | `{raíz-de-máquinas}`, `{usuario-del-host}`, `{apellido-del-PO}`, `{id-numérico-de-cuenta}`, `{organización-del-SDD-B}`, `{servicio-del-SDD-B}`, `{org-de-INFRA-privada}`, `INFRA-privada` (dos formas), `KB-privada`, `{dir-de-trabajo}`, `{memoria-del-agente}`, `{proyecto-privado}`, los identificadores del control R-PRIV y de la app privada, el dominio del correo personal del PO, la serie del teléfono de pruebas y la carpeta local de INFRA-privada |
| Se corre | Sin distinguir mayúsculas (`grep -iE`) |

Sale de las líneas literales del patrón privado de la mesa (relevamiento R4), ya resguardado por U00. Las líneas de
clase de ese patrón (directorio personal y rangos de IP) pasaron a la parte pública.

## 4. Medida

Medido el 2026-10-28 en hpdev, con GNU grep, sobre `main` de Lab-Documentos (`227954a`) y de
Lab-Documentos.Documentacion (`009d266`). El archivo de la parte pública se excluye del barrido de sí mismo.

| Medida | Comando | Resultado |
| --- | --- | --- |
| La parte pública no contiene ningún literal privado | `grep -Ff <lista privada> patron-publico.txt` y `grep -iEf <lista privada> patron-publico.txt` | **Vacío** en los dos (0 líneas) |
| La parte pública no se encuentra a sí misma | `grep -nEf patron-publico.txt patron-publico.txt` | 0 |
| Las dos partes cubren todo lo que cubría el patrón de la compuerta, en Lab-Documentos | Líneas (`archivo:línea`) que da el patrón de 33 líneas de R4 con `-i`, contra la unión de las dos partes | 98 contra 167; **0 perdidas** |
| Lo mismo en Lab-Documentos.Documentacion | Ídem | 213 contra 365; **0 perdidas** |

Coincidencias por línea de la parte pública en Lab-Documentos.Documentacion (`grep -IcE`, sumadas sobre los archivos
versionados):

| Línea | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Coincidencias | 98 | 4 | 16 | 73 | 24 | 3 | 21 | 0 | 6 | 37 | 44 |

Son coincidencias sin clasificar, no fugas. La clasificación (real propia, falso positivo, ajena con dueño) es la tarea
de G-f en E1-G2 (`251` §4) y del barrido U40.

## 5. Cómo se corre

```bash
PUB=PROMPTs/DEVs/Enchacement/01-Replanteo-Y-Analisis/OUTPUTs/Expedientes/0002-Replanteo-Metodologia-DocAsCode/evidencia/S2-patron/patron-publico.txt
PRIV=<lista privada>   # en {resguardo-privado}; verificar antes su sha256 contra §3
sha256sum "$PRIV"
git ls-files -z | grep -zv "^$PUB\$" | xargs -0 grep -nIE  -f "$PUB"   # parte pública
git ls-files -z                      | xargs -0 grep -nIiE -f "$PRIV"  # parte privada
```

- En Lab-Documentos.Documentacion el barrido corre las dos partes y se informa **por clase**: la salida de la parte
  privada no se versiona; la evidencia transcribe sólo la clase (por alias), el archivo y la línea.
- Si la lista privada no está disponible, el barrido corre sólo la parte pública y lo declara. Para G-f de E1-G2 hacen
  falta las dos.
- La lista privada se cita siempre por sha256 y número de líneas, nunca por ruta.

## 6. Efecto

- VER-C02 (`R07:302`) se verifica con las dos partes (`251` §5).
- Los barridos de la compuerta ya versionados (`G-f-barrido-s2.txt`, `S2-folios.txt`, `E1-U0c/01-barrido-s2.txt`) no
  se rehacen: valen para lo que midieron. Desde la vuelta, todo barrido nuevo usa este patrón.
- Convertir el barrido en control de CI es clase H y queda propuesto para E2.
- Las redacciones hacia adelante de DEC-06 (F4: `R07:304` y los folios `014:93` y `090:213`, con edición mínima en la
  que sólo el valor pasa a alias) las ejecuta U28 en su rama `exp0002/e1r-fugas-ldd` y las declara en una sección que
  agrega a este folio en ese mismo PR.

## 7. Pase

A la presidencia, con `251`, `252` y `253`, para fusionar antes de abrir cualquier rama `exp0002/e1r-*`; a U28, U40 y
U41 para el uso del patrón · presidencia.
