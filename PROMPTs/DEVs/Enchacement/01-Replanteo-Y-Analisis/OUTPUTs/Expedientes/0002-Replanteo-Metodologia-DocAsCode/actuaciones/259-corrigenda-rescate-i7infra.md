---
doc_id: EXP0002-F259
doc_type: corrigenda
title: Corrigenda única por el rescate de i7infra — 240, 245, 249, 251 (DEC-15), 252 §4 y 256 leídos con lo que no se había perdido
status: vigente
origin: agent
confidence: alta en cada corrección (folio:línea de origen y ruta rescatada comprobadas en `main` 5dadc00); G-a entra como antecedente, sin veredicto, por decisión D05 del acta 257
owner: presidencia de la mesa de recuperación del expediente 0002
last_review: 2026-10-29
audience: [PO, presidencia, agentes de E1-R, mesa de la opción B, bitacorista]
traces: [EXP0002-F240, EXP0002-F245, EXP0002-F249, EXP0002-F251, EXP0002-F252, EXP0002-F256, EXP0002-F257, EXP0002-F258]
---

# 259 — Corrigenda por el rescate de i7infra

| Campo | Valor |
| --- | --- |
| Tipo | corrigenda (unidad K11 del acta `257`) |
| Fecha | 2026-10-29 |
| Autor | Presidencia de la mesa de recuperación |
| Corrige | `240`, `245`, `249`, `251` (DEC-15, `:101`), `252` §4 y `256`, por referencia |
| Decisiones | `257` D04, D05 y D10 |

## Índice

1. [Qué se corrige y qué no](#1-qué-se-corrige-y-qué-no)
2. [Correcciones](#2-correcciones)
3. [G-a: antecedente de i7infra](#3-g-a-antecedente-de-i7infra)
4. [DEC-15: ensayos originales, corrida nueva](#4-dec-15-ensayos-originales-corrida-nueva)
5. [Lo que sigue igual](#5-lo-que-sigue-igual)
6. [Pase](#6-pase)

## 1. Qué se corrige y qué no

Los folios `240`, `245`, `249` y `251`–`256` se escribieron cuando lo hecho en i7infra se daba por perdido. No se
había perdido: estaba sin publicar y entró con el PR #36 (merge `5dadc00`, 2026-10-29; constancia `258`). Ningún folio
se edita (`257` D04; la carátula tampoco, `252:73`, DEC-19). Este folio dice cómo se lee cada pasaje afectado.

Los folios que comparten número se citan por nombre completo (`258` §4).

## 2. Correcciones

| Lugar | Dice | Se lee | Ruta rescatada |
| --- | --- | --- | --- |
| `240-constancia-caida-i7infra-y-reconciliacion.md:70-79` (§4, título y tabla) | «Folios perdidos»: E1-U0c sólo por la cita a `230`; E1-U2…E1-U5 y la verificación de E1-G con «número desconocido»; la evidencia de E1-U4b/E1-U4c «no existe en ninguna rama» | **No publicados; rescatados** por el #36. Cada unidad tiene su folio (tabla de `258` §3) y su evidencia | `actuaciones/230-e1-u0c.md`, `212-e1-u2.md`, `213-e1-u3.md`, `214-e1-u4a.md`, `218-e1-u4b.md`, `252-e1-u4c.md`, `251-e1-u4d.md`, `250-e1-u4e.md`, `260-e1-u4f.md`, `270-e1-u5.md`, `290-compuerta-e1.md`; `evidencia/E1-U2/` … `evidencia/E1-U5/` |
| `240-constancia-caida-i7infra-y-reconciliacion.md:81-87` | «No se reconstruyen como si existieran»; `217`–`239` no se reutiliza | El principio se mantiene y se cumplió: nada se reconstruyó. Lo que entró son los originales de i7infra, con su número y su fecha, no folios escritos de nuevo | `258` §2 |
| `240-constancia-caida-i7infra-y-reconciliacion.md:102-111` (columna de folio) | «perdido» / «perdido (`230`)» | El folio de cada unidad, por nombre (`258` §3) | ídem |
| `240-constancia-caida-i7infra-y-reconciliacion.md:127`, `:166` y `245-resolucion-compuerta-e1.md:303` | E-F10, E-F13, E-F14 y el conteo de fuentes primarias de E1-U4b/c/d, «sólo con lo que dicen los PR» | Tienen salida versionada: E-F10 y E-F14 en `212-e1-u2.md:60`; E-F13 en `213-e1-u3.md:77`; fuentes primarias en `218-e1-u4b.md:65`, `252-e1-u4c.md:61` y `251-e1-u4d.md:58` | `evidencia/E1-U2/03-carril-semanal-local.md`, `04-runner-y-cierre.txt`; `evidencia/E1-U3/13-runner-corrida-final.txt`; `evidencia/E1-U4b/`, `E1-U4c/`, `E1-U4d/` |
| `240-constancia-caida-i7infra-y-reconciliacion.md:158-163` | Qué generador de sitio se usó «consta sólo en la descripción del #27» | MkDocs Material en una imagen armada fuera de los repos, por decisión propia de E1-G (`290-compuerta-e1.md:189`, `:217`, LD-E1G-05: versionar un `mkdocs.yml` adelantaría una decisión de E3) | `290-compuerta-e1.md` |
| `249-providencia-estado.md:37` | «Perdidos los de E1-U0c (citado como `230`), E1-U2…E1-U5 y la verificación previa de E1-G» | No publicados hasta el #36; hoy versionados (`258` §3). La verificación previa es el `290`, **sustituido** (`258` §5) | ídem |
| `249-providencia-estado.md:43` | «ese folio se perdió» | La cita de la carátula a `230` tiene destino: `230-e1-u0c.md` | `actuaciones/230-e1-u0c.md` |
| `249-providencia-estado.md:53-55` | `230` y las unidades sin número «perdidos con i7infra»; la verificación previa «perdido» | Versionados por el #36 con su número; el `290` entra como antecedente sin veredicto vigente | ídem |
| `245-resolucion-compuerta-e1.md:92-121` (G-a) | Medida sólo con `git log` y eventos de GitHub | Se agrega el antecedente de §3, **sin veredicto**. El INSUFICIENTE del `245` no cambia | §3 |
| `245-resolucion-compuerta-e1.md:254-256` (G-g, defecto principal) | `evidencia/E1-U4b/…` «no existe en `main`, en ninguna rama, en ningún PR ni en la historia» | Era cierto en GitHub el 2026-10-28; la causa era evidencia **no publicada**, no inexistente. Desde `5dadc00` las nueve líneas de Lab-Documentos que la citan (`256` §2) resuelven sin editar Lab-Documentos. El NO_CUMPLE de G-g para esta vuelta no cambia: se vuelve a medir en E1-G2 | `evidencia/E1-U4b/01-tem01-inventario.sh`, `02-tem02-rrd.sh`, `03-tem03-ancla.sh`, `04-adopciones.sh` |
| `245-resolucion-compuerta-e1.md:300` (§8) | «Lecciones de E1 a `DocsAsCode-Bitacoras/` (onda 8): no se emitieron» | **En parte.** Las bitácoras de las ondas 0–7 existían sin publicar y entraron con el #36. Las lecciones de E1 (onda 8) no se emitieron; las emite U35 | `PROMPTs/Guides/14-Sistema-De-Documentador-Tecnico/OUTPUTs/DocsAsCode-Bitacoras/` |
| `251-corrigenda-133-criterios-vuelta.md:101` (G-g, DEC-15) | Guiones nuevos por tema en `evidencia/E1-R/ensayos/TEM-0n/`, rotulados «el original … se perdió» | Se usan los **guiones originales** y se vuelven a correr (§4) | `evidencia/E1-U4b/`, `E1-U4c/`, `E1-U4d/` |
| `252-corrigenda-n10-y-caratula.md:73-80` (§4) | `230` «se perdió»; número **vacante**; rango `217`–`239` sin reutilizar; folios de E1-U2…E1-U5 «sin número conocido» | `230` es `230-e1-u0c.md`, el original. Los números de i7infra (`212`, `213`, `214`, `218`, `230` y los dobles `250`, `251`, `252`, `260`) son los originales, no reutilización. Los folios de E1-U2…E1-U5 tienen número (`258` §3). Lo demás del §4 (los dos `211`, citar por nombre) sigue | `258` §3–§4 |
| `256-corrigenda-cuenta-marcas-g-g.md` (§2–§3) | 9 líneas, 5 marcas, 4 guiones, 4 menciones en prosa, todas hacia rutas inexistentes | La cuenta es correcta como medida del 2026-10-28. Desde `5dadc00` las rutas existen; la cuenta se rehace cuando cierren U25 y U26 (§4), que pasan las marcas a URL + SHA del merge | `evidencia/E1-U4b/` |

## 3. G-a: antecedente de i7infra

Se asienta como **antecedente, no como veredicto** (`257` D05). G-a se mide en E1-G2 por U41-MED con los
instrumentos de `251` §2 (`%cI` y `created_at`), y su refutador decide si el antecedente suma.

| Dato | Valor | Fuente |
| --- | --- | --- |
| Nacimiento de `133` en el clon de i7infra | 2026-10-27 09:37:51 (−03), `stat` (birth = mtime = ctime) | Medida en i7infra: `290-compuerta-e1.md:98` |
| sha256 de ese archivo | `b148b17eb01f4822032f30f92068c86de692f8bb0d7b155e2d4142e0e62849a4` | Idéntico al versionado en `cc2bfd6` (`sha256sum` sobre `main` `5dadc00`) y al del manifiesto de i7infra (`258` §1) |
| Primera rama de E1 | `83542ab`, Lab-E2E.WebBlazor #12, 12:41:00Z (09:41:00 −03) | `245:96-99` |
| Diferencia | 3 min 9 s antes del primer commit de E1 | Resta de las dos horas |
| Corroboración | Transcripción del agente que escribió el `133` (primer evento a las 12:37:51.865Z) | **Privada; no se publica.** Queda en el `{resguardo-privado}` (`253`), citada por sha256 `fc38024876278aecfe9eddd86c187f5852d6e24b716370f8083aeb36ef07d9c7` |

Por qué no es veredicto: `251` §2 y DEC-10 ya dejaron G-a como defecto del plan, no P0; `251` §8 asigna la medida a
E1-G2; y `251` §6.4 (iii) haría P0 a un criterio que se apoye en evidencia no reproducible desde el repo.

## 4. DEC-15: ensayos originales, corrida nueva

`251:101` se lee así (`257` D10):

- **U25-ENS-LDD**: corrida nueva de los guiones originales sobre la punta de `main` de Lab-Documentos en hpdev,
  incluido `04-adopciones.sh`, que nunca se reprodujo, y los de TEM-04…07 (`evidencia/E1-U4c/02` a `04`,
  `evidencia/E1-U4d/02`). Salidas en `evidencia/E1-R/ensayos/`, rotuladas «guion original, corrida nueva», con el
  SHA de Lab-Documentos y cada diferencia con la salida original explicada.
- **U26-ENS-LD**: se reduce a lo que pide `251:101`: las cinco marcas `[Compilado]` y las cuatro menciones en prosa
  (`256` §2) pasan a URL + SHA del merge.
- El resto de `251:101` (lista VER cerrada, umbrales P-5) sigue.

## 5. Lo que sigue igual

- Rige el `245`: **INSUFICIENTE, una sola vuelta**. El `290` no rige (`258` §5).
- La carátula `README.md` no se edita.
- El `255` (etiquetas) lo ajusta `257` D06; no entra aquí.
- Las decisiones DEC-10 a DEC-14 y la lista VER cerrada de `251` §5.

## 6. Pase

| Pasa a | Qué |
| --- | --- |
| U25-ENS-LDD, U26-ENS-LD | §4 |
| U35 | Lecciones de E1 (onda 8) |
| U41-MED y su refutador | §3 |
| Presidencia | Cerrar la cuenta de `256` después de U25 y U26 |
