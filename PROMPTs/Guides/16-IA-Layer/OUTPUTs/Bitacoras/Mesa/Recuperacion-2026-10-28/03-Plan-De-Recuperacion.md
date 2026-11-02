---
doc_id: BIT-16-REC-03
doc_type: plan-de-aplicacion
title: Plan de recuperación — aplicar sobre la base las opciones ganadoras (mesa de recuperación, 2026-10-28)
status: aprobado; aplicado (B-00…B-15 cerrados el 2026-10-30; ajuste m-4 de §4.5)
origin: agent (cuerpo auditor)
last_review: 2026-10-30
---

# Plan de recuperación (guía 16, 2026-10-28)

> **Vuelta 2 (2026-10-28).** Este plan se corrigió con las cinco aprobaciones `04-Aprobacion-*.md`. Las filas marcadas «**[V2 …]**» ya están reescritas; las enmiendas y los pasos nuevos están en el **§4**. **Regla de precedencia:** si algo del §0–§2 discrepa con el §4, manda el §4.

Cuerpo auditor. Insumos: [`01-Matriz.md`](01-Matriz.md) (35 ítems REC-01…REC-35), las cinco boletas `02-Voto-*.md`, los nueve `Panel-*.md` y los seis `Inventario-*.md` de esta carpeta. Decisión del PO que manda: **la base es la línea restaurada** en las rutas canónicas; la línea archivada es **insumo de sólo lectura**.

Esta carpeta se escribe **sólo con roles** (RPRI-20): «base», «insumo», «estación 1» (estación de laboratorio de 4 núcleos), «estación 2» (estación de laboratorio con más núcleos), «gestor de turnos del laboratorio (privado)». Ningún endpoint, equipo, usuario ni ruta del home.

---

## 0. Convenciones de ejecución

### 0.1 Variables (se definen en el shell de la presidencia; ninguna se escribe en el repo)

```bash
W="<raíz del workspace>"                      # se define en el shell; las rutas del plan van desde /LAB/…
OUT=$W/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Guides/16-IA-Layer/OUTPUTs
BIT=$OUT/Bitacoras                            # bitácora de la BASE (sólo agregado)
REC=$BIT/Mesa/Recuperacion-2026-10-28         # esta carpeta
INSUMO=$(ls -d "$OUT"/Linea-*-2026-10-28)     # línea archivada (SÓLO LECTURA)
GUIA=$W/LAB/Lab-Documentos/Lab-Documentos/Guides/IA/Dot-Net-Integration-AI-Layer-Guide
DOC=$GUIA/Dot-Net-Integration-AI-Layer-Guide.md
TRABAJO="<directorio de trabajo, fuera del árbol>"   # copias de compilación (nunca bin/ obj/ *.db en $GUIA)
CR="<envoltorio del gestor de turnos del laboratorio (privado)>"   # «$CR build <etiqueta> "<motivo>" 30 -- <cmd>»; su variable de directorio la define la presidencia
FOTOS="<directorio de fotos, fuera del árbol>"
SDK="docker run --rm -v <volumen-nuget>:/root/.nuget/packages -v $TRABAJO/<etiqueta>:/src -w /src mcr.microsoft.com/dotnet/sdk:10.0"
```

`OLLAMA_ENDPOINT` (estación 1) y el endpoint de la estación 2 (se lee de `$ENDPOINT_E2_ARCHIVO` (archivo fuera del repo, en el directorio de trabajo; su nombre no se escribe acá) **dentro** del turno) se pasan sólo como variables. Nunca se copian a un archivo del repo ni de la bitácora.

### 0.2 Reglas que valen para todos los bloques

1. **Sin commit, push, PR ni ramas** (la otra mesa integra el repo). Nada se toca en el equipo que perdió la red ni en `$INSUMO`.
2. **Sólo agregado en la bitácora**, salvo lo que borra R-PRIV según el dictamen adoptado en REC-33 (§1: R-PRIV le gana a «sólo agregado», sólo para borrar lo prohibido).
3. **Traslado pieza por pieza** desde `$INSUMO` (RPRI-18): se copia el archivo, se adapta (nombres de proyecto y espacio de nombres de la base, remisiones por la tabla DECI-30), se pasa el barrido ampliado y recién entonces se registra en [`Procedencia.md`](Procedencia.md) con el sha256 de origen y de destino.
4. **Compilar siempre sobre copia**: `rsync -a --delete $GUIA/ $TRABAJO/<etiqueta>/` y `$CR build <etiqueta> "<motivo>" 30 -- $SDK <cmd>`. Al terminar: `find $GUIA \( -name bin -o -name obj -o -name '*.db' \)` vacío.
5. **Barrido R-PRIV ampliado** (`$REC/evidencia-rpriv/rpriv-ampliado.sh`, más la compuerta v2 de REC-06.1) en 0 sobre todo archivo tocado del repo, antes de cerrar cada bloque. Cero IPs (también parciales y rangos 100.x), hosts, nombres de equipos o contenedores del laboratorio, rutas del home, usuarios, la clave de cabeceras por pedido de OllamaSharp ni otros proyectos.
6. **La guía es un solo archivo**: un bloque por vez, nunca dos en paralelo sobre `$DOC`. Los números de línea que cita la matriz son de la 0.10.1 (sha256 `ee1e6ae2…0a16f`); cada bloque **ubica por ancla** (`<a id="sN-M">`) **y texto único** (`grep -n`), no por número de línea.
7. **Marcador de cifra pendiente.** Todo texto nuevo de la guía que depende de la re-corrida (REC-02) se escribe con el marcador `⟦REC-02:<id-corrida>⟧` en lugar de la cifra. Compuerta: `grep -c '⟦REC-02:' $DOC` = 0 antes de la relectura (B-14).
8. **Antes y después de cada bloque de la guía**: `tools/contar.sh` (repuesto en B-01) y `sha256sum $DOC`, anotados en `$REC/04-Aplicacion.md` (bitácora de aplicación, se crea en B-00).
9. **No se corre contra el modelo** hasta B-11. Toda prueba de B-01…B-10 es sin servidor (`Category!=LLM`, `--fake`).

### 0.3 Resultado de la votación que aplica este plan

| Ítem | Ganadora | Conteo | Bloque | Nota del auditor |
|---|---|---|---|---|
| REC-01 | A | 5/0 | B-13 | 0.11.0 al final, «en revisión» |
| REC-02 | A | 5/0 | B-11 | fase con modelo única |
| REC-03 | A | 5/0 | B-14 | relectura integral después de B-11/B-12 |
| REC-04 | A | 5/0 | B-14 | informes del insumo como insumo |
| REC-05 | A | 5/0 | B-02, B-08, B-10, B-11, B-15 | sin tocar el código de EMB |
| REC-06 | A | 5/0, **con veto** | B-01, B-02, B-12 | el veto cae sobre B («no aplicar»): el lote es obligatorio y completo |
| REC-07 | **C** | A 2 · C 3 | B-01, B-02 | renombre atómico en el repo + bitácora generalizada |
| REC-08 | A | 5/0 | B-01, B-06, B-11 | 8192 en la re-corrida + regla en la guía |
| REC-09…REC-14 | A | 5/0 | B-03…B-10 | |
| REC-15 | **B** | 5/0 | B-06, B-11 | sin citar la tabla 2b/4b del insumo |
| REC-16, REC-17 | A | 5/0 | B-03, B-04, B-08 | REC-17 condicionado a las pruebas |
| REC-18 | A | 4/1 | B-04, B-09, B-11 | |
| REC-19, REC-20 | A | 5/0 | B-01, B-09, B-11 | |
| REC-21 | **C** | A 1 · C 4 | B-06, B-11 | sin el detector que lanza |
| REC-22 | A | 5/0 | B-03, B-04, B-07 | |
| REC-23 | A | 3/2 (C) | B-09, B-11 | mayoría simple |
| REC-24…REC-34 | A | 5/0 | según tabla del §2 | |
| REC-35 | A | 4/1 | B-03 (último paso) | |

**Empates:** ninguno. **Vetos:** uno (REC-06), coincidente con la ganadora: no hay conflicto que resolver con la opción conservadora. **Opciones perdedoras que el plan no aplica** (quedan registradas, no son deuda): REC-21 A (detector que lanza), REC-25 C/D (Bearer, catálogo único migrado), REC-26 C, REC-15 A (tabla 2b/4b), REC-17 C, REC-19 D (Wilson en toda la guía), REC-20 D.

**Deuda declarada** (lo que el plan deja abierto a propósito, sin perder contenido):

| ID | Qué queda abierto | Dónde se declara |
|---|---|---|
| DEU-01 | REC-17: el endurecimiento de `LocalidadRules` se aplica **sólo si** fallan las dos pruebas de cableado; si pasan, se registra «verificado, no hizo falta». | §14.1 y `04-Aplicacion.md` |
| DEU-02 | REC-15: la re-medición del modelo provisional con la demo se hace **sólo si** la re-corrida de B-11 contradice al 4b; si no, el rótulo queda «provisional, no comparado». | §5.7, ADR-03 |
| DEU-03 | REC-34: la oración de NUnit 4.3.2 en §10.2 entra sólo si el build la confirma. | `04-Aplicacion.md` |
| DEU-04 | REC-06.8: los tres pedidos al gestor (sin dirección por defecto, salud de la estación 2, «nunca emuladores ni KVM») los hace la presidencia fuera del repo; esta mesa no los verifica. | `Bitacoras/README.md` (nota) |
| DEU-05 | REC-25: autorización MCP (Bearer / OAuth 2.1) fuera del alcance; catálogo único sólo como alternativa declarada. | §8 (MCP), Anexo F |
| DEU-06 | REC-26: los agujeros de la prueba de arquitectura se declaran, no se cierran. | §4, ADR-11 |
| DEU-07 | Publicación de la demo, commit y paso a «publicada»: decisiones del PO después de B-14 (REC-05, REC-01). | B-15 |

---

## 1. Orden de aplicación (bloques secuenciales)

```text
B-00 Preparación y foto de la base
B-01 Repo: tools/ y arnés (REC-06.1 y .6, REC-07 C, REC-08, REC-19 script, REC-11 compuerta)
B-02 Bitácora (REC-06.2/.4/.5, REC-07 bitácora, REC-33, REC-05 ESC-001, REC-08 PC-06)
B-03 Examples/_Comun + Directory.*.props (REC-22 lector, REC-17 pruebas, REC-35)
B-04 Examples 01–07 (REC-09, REC-10, REC-11, REC-16, REC-28, REC-05 comentarios)
B-05 Examples 08–17 (REC-14, REC-29, REC-30, REC-27, REC-25, REC-18, REC-12)
B-06 Guía · Parte 0 + I + II (§0–§5)
B-07 Guía · Parte III (§6–§7)
B-08 Demo (REC-13, REC-26, REC-17 copia, REC-14 fábrica, REC-05 comentarios)
B-09 Guía · Parte IV + V (§8–§12)
B-10 Guía · Parte VI + Cierre + Anexos (§13–§15, A–G)
B-11 Fase con modelo única (REC-02) — estaciones 1 y 2
B-12 Guía · relleno de cifras ⟦REC-02⟧, F.4, §4.2, §E.5 (REC-06.3)
B-13 Encabezado 0.11.0 (REC-01) y verificación integral
B-14 Relectura integral (REC-03, REC-04)
B-15 Cierre: presentación al PO
```

Dependencias: B-01 antes que todo lo que compila o corre; B-03 antes de B-04/B-05/B-08 (el lector y el dominio viven en `_Comun`); los bloques de guía van después del código que citan (B-06 tras B-04, B-07 tras B-03/B-04, B-09 tras B-05/B-08); B-11 sólo con B-01…B-10 cerrados y build verde; B-12 sólo con B-11 cerrado.

---

## 2. Bloques

### B-00 · Preparación y foto de la base

| Paso | Operación | Verificación |
|---|---|---|
| 0.1 | Foto de la base antes de tocar nada: `tar czf $FOTOS/base-pre-recuperacion-$(date +%F-%H%M).tgz -C $W LAB/Lab-Documentos/Lab-Documentos/Guides/IA/Dot-Net-Integration-AI-Layer-Guide LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Guides/16-IA-Layer/OUTPUTs/Bitacoras` | `tar tzf … \| wc -l` > 0; sha256 del tgz anotado |
| 0.2 | Crear `$REC/04-Aplicacion.md` (encabezado + tabla «bloque · inicio · fin · sha256 guía antes/después · contar.sh antes/después · build n/n · barrido · observaciones») | existe |
| 0.3 | Fijar el sha256 de `$DOC` = `ee1e6ae23001b7fbd60acbbd8b7477415ef0624c12c42fbb3689a7fe7e60a16f` (0.10.1). Si no coincide, **parar**: alguien tocó la base | `sha256sum $DOC` |
| 0.4 | Verificar que `$INSUMO` no cambió: `find $INSUMO -type f -newer $INSUMO/README.md` vacío (o cotejar contra la foto `$FOTOS/linea-*-2026-10-28-2040.tgz`) | listado vacío |
| 0.5 | Copiar [`Procedencia.md`](Procedencia.md) como registro vivo: se completa en cada bloque | — |

### B-01 · Repo: `tools/`, arnés y README (REC-06.1, REC-06.6, REC-07 C, REC-08, REC-11, REC-19)

Destinos: `$GUIA/tools/*`, `$GUIA/Compuertas/`, `$GUIA/Examples/*/ejemplo.json`, `$GUIA/Examples/README.md`, `$GUIA/Examples/05-*/README.md`, `$GUIA/Examples/15-*/README.md`, `$GUIA/Demos/MovilidadUrbana.Asistente/{tools/demo.sh,compose.yaml,README.md,ejemplo.json}`, `_Comun/MovilidadUrbana.Asistente.Comun.Pruebas/ArnesTests.cs`. Origen: base (salvo 1.9, del insumo).

| Paso | Origen | Operación exacta | Verificación |
|---|---|---|---|
| 1.1 | base | **R-PRIV del arnés** (RPRI-01…03): en `tools/verificar.sh`, `demo.sh` y `compose.yaml`, volúmenes, contenedor, etiqueta y red pasan a variables con valor neutro por defecto (`${VOLUMEN_NUGET:-nuget}`, `${CONTENEDOR:-asistente}`, `${ETIQUETA:-proyecto=guia-ia}`). | barrido ampliado (clase «contenedores») = 0 sobre `tools/`, `Demos/*/tools` y `Demos/*/compose.yaml` |
| 1.2 | base | **AC-7 sin rangos literales** (ESTA-27): `tools/compuerta-ac7.sh` arma el patrón en ejecución (concatenación de octetos), comentario sin rangos. | barrido ampliado = 0 sobre el script; AC-7 sigue detectando un positivo de prueba |
| 1.3 | base | **Listas de AC-7/AC-8 fuera del repo** (ESTA-21): `Compuertas/localidades-permitidas.txt` y `rd-po-4.*` se leen de `${COMPUERTAS_DIR:?}` (fuera del árbol, ampliadas con los términos de RPRI-17/19); en el repo queda sólo el formato. | `ls $GUIA/Compuertas` sin listas con términos privados; AC-7/AC-8 dan el mismo resultado con `COMPUERTAS_DIR` apuntando a la copia ampliada |
| 1.4 | base | **Compuerta v2** (RPRI-17/19): patrón usuario@máscara afinado; se integra a `verificar.sh` como paso del build. | corre en el build; 0 hallazgos |
| 1.5 | base | **REC-07 C — renombre atómico de papeles**: un solo cambio en `verificar.sh` (19 líneas), `demo.sh`, los `ejemplo.json` que liste `grep -rl` sobre `$GUIA` (en la 0.10.1 hay 19 archivos: 17 Examples, la demo y `_Comun/Humo`; se anota la lista real en `04-Aplicacion.md`), la demo y los README: recurso `<recurso-compartido>` → `modelo-compartido`, `<recurso-propio>` → `modelo-propio` (mapa exacto en `$TRABAJO/rpriv/mapa.tsv`, fuera del repo), `TOPE_LAN_S` → `TOPE_COMPARTIDO_S`; **[V2 M-A]** `OLLAMA_SERVIDOR`, `RLLM_MAQUINA` y `RLLM_MAQUINA_PROPIO` se leen del entorno **sin defecto en todo modo con modelo** (`${OLLAMA_SERVIDOR:?}`, `${RLLM_MAQUINA:?}`): si falta alguna, la fase aborta con rc ≠ 0 y mensaje. Sólo `build` y `--fake` aceptan el defecto neutro `sin-servidor` y escriben el rótulo «guion» (fin del rótulo fijo «compartido», verificar.sh l. 406/496/503, demo.sh l. 138). `RLLM_MAQUINA` documentado como **rol** (RPRI-06). **No cambian** los sha256 de entradas. | barrido ampliado (clase «turnos») y `grep -rn TOPE_LAN_S $GUIA --exclude=*.md` = 0 (los .md se tratan en B-06…B-10); `verificar.sh build` n/n; `verificar.sh extension 03 04 08 --fake`, `estabilidad 07 --fake`, `embeddings 07 --fake` rc 0; **[V2 M-A]** `verificar.sh fase lan`, `fase propio`, `extension`, `estabilidad`, `embeddings` (con modelo) y `demo.sh embeddings` sin `OLLAMA_SERVIDOR` → rc ≠ 0 con mensaje, ídem sin `RLLM_MAQUINA`, sin llamar al servidor; casos nuevos en `ArnesTests` que lo cubren; `ArnesTests` verde |
| 1.6 | base | **Adaptador TURNO_CMD fuera del repo** (REC-07 A, incluido en C): script en `$TRABAJO/arnes/turno-estaciones.sh` (recuperado del rescate al directorio de trabajo) que traduce `modelo-compartido`/`modelo-propio` a los recursos del gestor de las dos estaciones; `OLLAMA_PROPIO_URL_CMD` lee el endpoint de la estación 2 dentro del turno. | `bash -n`; en seco con `--fake` imprime el recurso traducido y no un endpoint |
| 1.7 | base | **REC-08 en el arnés**: `num_ctx_compartido()` y `propio()` fijan `OLLAMA_NUM_CTX=8192` y cargan el modelo con ese valor **dentro** del turno (una llamada de calentamiento) antes de la primera medición; registran el valor que informa `/api/ps`. Descarga con `keep_alive: 0` al cerrar cada fase (ENTO-10/19). `RLLM_DIR` sin defecto dentro del árbol: si falta, el arnés aborta (ENTO-19). | `verificar.sh fase lan` sin `RLLM_DIR` → rc ≠ 0 con mensaje; en seco, el registro trae `num_ctx_origen=arnes-ps-tras-carga` |
| 1.8 | base | **Herramientas faltantes** (ESTA-07, ESTA-20, ESTA-10, ESTA-11, ESTA-06): reponer en `tools/` el comparador de AC-9 (bloques y cifras), escribir `tools/contar.sh` con la regla del plan §C (`04-Plan-De-Integracion.md`), `ac6()` vacía `paquetes/` al entrar, `recalcular-oraculos.sh` acepta un segundo directorio de oráculos, `verificar-markdown.py` admite un archivo de excepciones (`tools/verificar-markdown.excepciones`, rutas completas de la demo). | `contar.sh $DOC` reproduce el conteo de `07-Redaccion.md`; `verificar-markdown.py` sobre 0.10.1 = 0 falsos positivos (eran 5 de 104) |
| 1.9 | `$INSUMO/Bitacoras/Mesa/Ciclo-1/evidencia-AH-02-evaluacion-llm-rag/intervalos.py` | **REC-19**: adaptar a Clopper-Pearson (el de `verificar.sh tasa`) y a la unidad de la base; queda como `tools/compuerta-intervalos.py`: recalcula cada cifra «k/M, IC95 [a; b]» y «k de M» de la guía desde los registros R-LLM y falla si no coincide. | **[V2 M-C]** sobre la 0.10.1 = n/n, con n = las cifras que la compuerta reconozca (hoy ~16 líneas con IC95 y ~25 formas «k de M»; la lista exacta, con línea y registro de origen, se anota en `04-Aplicacion.md`); positivo de prueba: una cifra alterada en una copia → rc 1. (El 365/365 es de AC-3b y sólo vale en 2.3.) |
| 1.10 | base | **REC-11 compuerta «cabeceras=0»**: `tools/compuerta-cabeceras.sh` busca claves de cabecera serializadas en los cuerpos capturados (`RLLM_DIR/**/cuerpo*.json`, capturas de 02). | sobre un cuerpo de prueba con cabecera → rc 1; sin → rc 0 |
| 1.11 | base | **README** (ESTA-13, ESTA-16, ESTA-26, ENTO-14, ENTO-18, RPRI-05, ENTO-04): README de 15 usa el contenedor (R-HOST) y declara `entradas/salidas-07.v1.json` **por valor exacto como histórico** («estímulo del 2026-10-27, de un servidor de laboratorio retirado»), sin tocar el archivo; `Examples/README` suma el párrafo de E.5 y aclara que el tope es para servidores ajenos; README de 05 neutral (sin emuladores ni sesiones) y dice «corrida 1». | `sha256sum Examples/15-*/entradas/salidas-07.v1.json` sin cambio; barrido = 0 |
| 1.12 | — | **Cierre de B-01**: copia a `$TRABAJO/rec-b01/`, `verificar.sh build` (443/443 o el nuevo n/n declarado), `demo.sh pruebas` (70/70), `diff-base.sh`, `diff-dominio.sh`, AC-6, AC-7, AC-8, barrido. | todo verde; anotar en `04-Aplicacion.md` |

### B-02 · Bitácora de la base (REC-06.2/.4/.5, REC-07 C bitácora, REC-33, REC-05, REC-08)

Destino: `$BIT/**`. Sólo notas fechadas «2026-10-28 — Recuperación …», salvo las redacciones R-PRIV del dictamen.

| Paso | Origen | Operación exacta | Verificación |
|---|---|---|---|
| 2.1 | `$INSUMO/Bitacoras/Mesa/Ciclo-1/07-Dictamen-Presidencia.md` §1–§2 | **REC-33**: copiar el dictamen (barrido en 0) a `$REC/Dictamen-R-PRIV-Bitacora.md` y citarlo en `Bitacoras/README.md` §Convenciones con una nota fechada. | archivo existe; Procedencia anotada |
| 2.2 | base | **Marcadores en prosa y planes**: `<ollama>`, `<volumen-nuget>`, `<red-del-arnés>`, «gestor de turnos del laboratorio (privado)», `{dir-de-trabajo}`, `{dir-de-sesion}` (RPRI-12). Mapa valor→marcador en `$TRABAJO/rpriv/mapa.tsv` (fuera del repo). | barrido sobre `.md` de `$BIT` = 0 |
| 2.3 | base | **.log no fijados por hash**: `sed` por mapa de valor exacto; guardar `diff` antes/después en `$TRABAJO/rpriv/diff-logs.txt`; el diff sólo muestra los tokens del mapa. **Capturas que alimentan recálculos** (`Evidencia/R-LLM/*.jsonl`, `*.tsv`) **no se tocan**: nota fechada que declara sus valores históricos (RPRI-11). | `recalcular-oraculos.sh` sobre `R-LLM/` sigue 365/365; `git diff --stat` imposible (sin git): cotejo con la foto de B-00 |
| 2.4 | base | **RPRI-08/09/14**: I-06:10 en paráfrasis y fuera de `rd-po-4.excepciones`; teléfono y gestor del PO por marcadores en I-06:27-29 y 06:123; nombre del curso genérico, transcripciones resumidas y los tres PNG de terceros excluidos del futuro commit (lista en `04-Aplicacion.md`). | barrido = 0 |
| 2.5 | base | **RPRI-16**: `OUTPUTs/Reanudar.md` fuera de todo commit; lo mueve la presidencia a la línea archivada **después** de la nota de recuperación de este plan. | listado en `04-Aplicacion.md` |
| 2.6 | `$INSUMO/Bitacoras/Sondeo-Entorno.md` §R (R.0–R.7) y `$INSUMO/Bitacoras/Sondeo-Evidencia/2026-10-28/` | **REC-06.4**: en `$BIT/Sondeo-Entorno.md`, nota fechada «§0–§8 son historia (servidor de laboratorio retirado)» y agregado del §R completo con procedencia; los crudos se copian a `$BIT/Evidencia/Sondeo-2026-10-28/` **después** de pasar la compuerta R-PRIV (los endpoints se sustituyen por rol). | barrido = 0; cifras de R.6 iguales al origen |
| 2.7 | base | **REC-07 C en la bitácora**: nota fechada en `Bitacoras/README.md` §Convenciones: los dos roles vigentes, equivalencia de papeles (`<recurso-compartido>` ≡ `modelo-compartido`, `<recurso-propio>` ≡ `modelo-propio`) y del recurso de la estación 1 antes y después del 2026-10-28; los valores de las capturas son históricos. Dictamen fechado sobre la clase (C1-39). | nota presente |
| 2.8 | base | **REC-06.5**: en `07-Redaccion.md`, notas fechadas de las tres deudas cerradas de §8.1/§8.2 (ESTA-17) y de la cifra corregida de §6 (104 rutas, 5 falsos positivos; ESTA-06); en `Bitacoras/README.md`, 08 y AC-6 resueltas en `06-Construccion.md` §2.1 (APOR-L-19, ESTA-09/10); en `Redaccion/secciones/` una línea «histórico; la fuente es la guía» (ESTA-23). | notas presentes |
| 2.9 | base | **REC-06.3 (bitácora)**: nota sobre RV-11 y el caso e5 de 07 (respuesta guionada de un servidor retirado; ENTO-15). | nota presente |
| 2.10 | base | **REC-05**: cerrar ESC-001 «sin objeto» con notas fechadas en `Mesa/Ciclo-3/08-Cierre*` y en `07-Redaccion.md` §9; sacarla de los pendientes del PO. | `grep -n ESC-001` muestra la nota de cierre |
| 2.11 | `$INSUMO/Bitacoras/Mesa/Ciclo-1/Ronda-2/` (consulta PC-06) | **REC-08**: nota fechada que cierra la pregunta «¿/v1 sin num_ctx recarga?» citando PC-06 (recarga a 4096 según configuración del servidor; 10,5–16,1 s, N=5, estación 1). | nota presente; Procedencia |
| 2.12 | — | Barrido ampliado sobre `$BIT` y `$REC` = 0 (salvo las rutas canónicas desde la raíz del workspace, que son públicas, RPRI-13). | log en `$REC/evidencia-rpriv/` |

### B-03 · `Examples/_Comun` y `Directory.*.props` (REC-22, REC-17, REC-35)

| Paso | Origen | Operación exacta | Verificación |
|---|---|---|---|
| 3.1 | `$INSUMO/Guia/Examples/09-*/src/*/Infrastructure/AI/LectorDePrefijoCacheado.cs` + `…/Cableado/LecturaDelUsoTests.cs` | **REC-22**: portar el `DelegatingHandler` a `_Comun/MovilidadUrbana.Asistente.Comun/` (espacio de nombres de la base) y su prueba sobre NDJSON fijo a `_Comun/…Comun.Pruebas/`; el registro R-LLM llena `estado_cache` con el valor observado (`prompt_eval_cached_count`) en vez de «desconocido». | prueba verde sin servidor; `--fake` de 05 escribe `estado_cache` ≠ «desconocido» |
| 3.2 | base | **REC-17 (pruebas primero)**: en `_Comun/MovilidadUrbana.Dominio` (pruebas del dominio o de 03/04), dos pruebas de cableado: CP «٣٤٥٠» y nombre de 61 caracteres propuestos por el modelo → rechazados **sin** `SaveAsync`. | correr: **si pasan**, DEU-01 «verificado, no hizo falta» y fin; **si fallan**, 3.3 |
| 3.3 | base | (condicional) endurecer `LocalidadRules`: CP `^[0-9]{4}$` (no `\d`) y aplicar `LargoMaximoDelNombre`; registrar la fila «Modificado a causa de la IA» (se escribe en B-10, §14.1). Replicar en la copia de dominio de la demo en B-08. | pruebas 3.2 verdes; AC-5 y AC-10 (`diff-base.sh`, `diff-dominio.sh`) muestran sólo ese delta |
| 3.4 | base | **REC-35**: retirar de `Examples/Directory.Packages.props` las tres `PackageVersion` sin referencia; confirmar que `Agents.AI.Abstractions` sigue llegando como transitivo (`dotnet list package --include-transitive`); anotar el `paquetes_hash` nuevo. | build n/n; AC-6 verde; hash anotado para F.1 (B-10) |
| 3.5 | — | Cierre: build sobre copia `rec-b03`, barrido, Procedencia. | verde |

### B-04 · Examples 01–07 (por carpeta, en orden)

| Carpeta | REC | Origen | Operación exacta | Verificación |
|---|---|---|---|---|
| 01-Chat-Y-Streaming | REC-09 | `$INSUMO/Guia/Examples/02-Streaming/src/MovilidadUrbana.Streaming/AsistenteDeLaEncuesta.cs` (patrón) | En `AsistenteDeAyuda.cs` (l. 46-70 de la base): después del `await foreach`, `if (ct.IsCancellationRequested)` → no agregar el parcial al historial y devolver la vuelta marcada «cancelada». Dos pruebas de cableado con `GuionChatClient`: proveedor que lanza `OperationCanceledException` y proveedor que termina en silencio. | 2 pruebas nuevas verdes; las previas siguen verdes |
| 02-Cambio-De-Adaptador | REC-10, REC-11 | `$INSUMO/Guia/Examples/01-Chat-Basico/tests/…/Cableado/CuerpoDelPedidoTests.cs`, `$INSUMO/Guia/Examples/06-Tool-Calling/tests/…/Cableado/ProveedorTests.cs` | Prueba de cableado que captura el cuerpo por vía nativa y por `/v1` con un servidor falso en memoria: TopK (presente/descartado), MaxOutputTokens (`num_predict` / `max_completion_tokens`), `tool_choice` (lo envía el cliente), formato del mensaje tool. La captura se escribe al `RLLM_DIR` y pasa la compuerta «cabeceras=0» (B-01 1.10). | prueba verde; compuerta rc 0 |
| 03-Salida-Estructurada | REC-16 | base (+ cifra rotulada del insumo, sólo en la guía) | Verificar que el descarte «no está en el texto» (`GarantiaDelTexto`) cubre **todos** los campos, en particular el CP; si no, extenderlo. Prueba sin modelo: entrada «CP 34», modelo guionado propone 3400 → descartado. Estímulo nuevo `entradas.cp34.v1.json` (una entrada) con su sha256 en `ejemplo.json` para B-11. | prueba verde; `ejemplo.json` con el sha256 nuevo |
| 05-Contexto-Completo | REC-22 | lector de B-03 | Cablear el lector en la composición de 05; README sin la frase «estado_cache desconocido». | `--fake` verde |
| 06-Embeddings | REC-28 | base | Conjunto de calibración aparte `oro/calibracion.v1.json` (no se mezcla con el oro de evaluación) para el umbral; sin cambios de código de EMB (REC-05). | sha256 en `ejemplo.json` |
| 07-RAG-Con-Citas | REC-28, REC-05 | base | Revisar las instrucciones: si traen un ejemplo de cita, anotarlo (lección «el formato sale del ejemplo»). Agregar al oro una pregunta **no respondible cercana** a una regla real → `conjunto-de-oro.v2.json` (el v1 queda, histórico) y actualizar 06/07 `ejemplo.json`. Actualizar comentarios de `ConfiguracionDelModelo.cs` y `PredicadoDeSalto.cs`: EMB-A = «mismo servidor del chat», EMB-B = «servidor aparte»; la razón es «papeles separados y recarga» (el 501 es historia). | build; `--fake` verde; `entradas_congeladas` acepta v2 |
| Cierre B-04 | — | — | build n/n sobre copia `rec-b04`; barrido; Procedencia. | verde |

### B-05 · Examples 08–17 (por carpeta, en orden)

| Carpeta | REC | Origen | Operación exacta | Verificación |
|---|---|---|---|---|
| 08-Primera-Herramienta | REC-14, REC-29 | `$INSUMO/Guia/Examples/09-*/tests/…/Cableado/CicloDeVidaDelClienteTests.cs`; `$INSUMO/Guia/Examples/08-*/tests/…/Cableado/ConcurrenciaTests.cs` | Prueba roja concurrente con barrera: casos (a) Singleton + `ValidateScopes=false` → B ve y borra lo de A sin error; (b) Singleton + `true` → falla en cada llamada a la herramienta, no al construir; (c) Scoped por sesión → aislado. Estímulo nuevo «provincia fuera del catálogo» (`entradas.fuera-de-catalogo.v1.json`) con oráculo «afirma un número sin pedir herramienta» en `tools/oraculos/`. | (a)(b) rojos esperados, (c) verde; oráculo probado con dos salidas guionadas |
| 10-Workflow | REC-30 | `$INSUMO/Guia/Examples/10-Workflow/tests/…/Cableado/TrampasDeExecutorsTests.cs` | Caso rojo: `YieldOutputAsync` sin declarar el tipo de salida lanza en ejecución. Sin `BuildSequential`. | verde |
| 11-Agente-Con-Aprobacion | REC-27 | `$INSUMO/Guia/Examples/07-Agente-Con-Aprobacion/tests/…/Cableado/AprobacionTests.cs` | Verificar en `AgenteConAprobacionTests.cs` si hay caso de **sesión serializada alterada**. Si falta: caso rojo (MAF 1.26.0 ejecuta lo que dice la sesión deserializada) y guarda que compara con la copia aprobada. | verde o «ya cubierto» anotado |
| 13-Servidor-Y-Cliente-MCP | REC-25 | `$INSUMO/Guia/Examples/08-Servidor-Y-Cliente-MCP/src/…Cliente/Mcp/ConexionMcp.cs`, `…/Cableado/ToolsListTests.cs` | Registrar `NegotiatedProtocolVersion` en la salida y en el registro; extender `Garantias.DescripcionDelCliente` a las escrituras con prueba sin modelo; caso «herramienta peligrosa marcada ReadOnly no decide la lista blanca»; prueba `tools/list` = esquema del bucle. **Sin token.** | verde |
| 14-Anotaciones-SK-vs-MEAI | REC-30 | `$INSUMO/Guia/Examples/12-Anotaciones-Pareadas/tests/…/Cableado/AgentesTests.cs` | Dos o tres casos rojos sin modelo: sin `UseKernelFunctionInvocation` la llamada no se ejecuta; `AIFunctionFactory` no lee `[KernelFunction]`; un `KernelFunction` en MAF da «Function failed.». | verde |
| 15-Pruebas-Y-Evaluacion | REC-18 | `$INSUMO/Guia/Examples/09-*/tests/…/ConModelo/EvaluacionConJuezTests.cs`, `…/Cableado/SalidaEstructuradaYEvaluacionTests.cs` | Sumar `EquivalenceEvaluator` con el oro. Verificar que una métrica sin `Interpretation` o con diagnóstico Error cuente como **no interpretable** (prueba sin modelo: todas Inconclusive → la prueba **no** pasa en verde). Verificar que el juez pase por la capa de opciones (razonamiento apagado, `num_ctx` ≥ 8192). La salida `--fake` (51/52) se rotula «cableado» en el README. | verde |
| 17-Observabilidad-Y-Pipeline | REC-12 | base (insumo: patrón de APOR-L-06) | Clave de caché `[SessionId, VersionDeDatos]` leídos en cada pedido; caso rojo de dos sesiones (B no recibe lo de A); caso rojo escritura → acierto viejo; contador de aciertos por los dos caminos de lectura (`ReadCacheAsync` y streaming con `CoalesceStreamingUpdates=false`). | 2 rojos esperados demostrados con la clave por defecto, verdes con la nueva |
| 09, 12, 16 | — | — | Sin cambio de código (16 se re-corre en B-11). | — |
| Cierre B-05 | — | — | build n/n sobre `rec-b05`; ArnesTests; barrido; Procedencia. | verde |

### B-06 · Guía, Parte 0 + I + II (§0–§5)

Destino `$DOC`, desde `<a id="parte-0">` hasta antes de `<a id="parte-iii">` (o el ancla equivalente de «# Parte III»).

| Paso | REC | Operación exacta (ubicar por ancla + texto) |
|---|---|---|
| 6.1 | REC-06.3 | §2 (l. ~288): la frase que presenta el servidor compartido como entorno actual pasa a historia («hasta el 2026-10-28, …»). |
| 6.2 | REC-06.3 | §4.2: insertar `⟦REC-02:F4-servidores⟧` donde va la tabla de tres servidores (se llena en B-12). |
| 6.3 | REC-26 | §4 (prueba de arquitectura): declarar los agujeros y que el grep de AC-5 no es prueba suficiente. |
| 6.4 | REC-09 | §5 (streaming): párrafo «la cancelación puede terminar sin excepción; mirar el token después del foreach», con remisión a 01 y cifra `⟦REC-02:01-cancelacion⟧` (o rotulada como del insumo si no se re-mide). |
| 6.5 | REC-08 | §5.4/§5.5: regla «el mismo `num_ctx` en todos los clientes de un modelo»; recarga 10,5–16,1 s rotulada «N=5, estación 1, 2026-10-28». |
| 6.6 | REC-21 C | §5.4 (y §6.5 en B-07): fila del 4b `⟦REC-02:DEP-03⟧` y la frase «el largo truncado depende del tokenizador; la calibración de caracteres por token es por modelo, y `GuardaDeTruncado` estima con el modelo de la llamada» (rotulada, insumo; **[V2 M-F]**). l. ~1013: regla «4096 → 2.050» con `⟦REC-02:DEP-03⟧`. Sin el detector que lanza. |
| 6.7 | REC-12 | §5.4: matizar el diagrama de la caché (la clave lleva sesión y versión de datos). |
| 6.8 | REC-14 | §5.5: párrafo del circuito en Blazor Interactive Server (Scoped = circuito; DbContext por `AddDbContextFactory`) con sus referencias (DI overview §Scope validation; documentación de Blazor). |
| 6.9 | REC-10 | §5.6: filas TopK, MaxOutputTokens (`⟦REC-02:02-max-tokens⟧` para el «3 → …»), formato del mensaje tool; **[V2 M-B]** fila de tool_choice: «el cliente envía `tool_choice`; la documentación de `/v1` no lo lista [REF-51]; que el servidor lo cumpla no está medido». Alinear en el mismo sentido las demás menciones (paso 6.12 del §4). |
| 6.10 | REC-06.3, REC-15 B | §5.7 l. ~1012 a historia con la fila de §R.4 al lado, rotulada; elección del modelo: 4b con digest `⟦REC-02:digest-4b⟧` (verificado en turno), rótulo «provisional, no comparado»; quitar la alternativa qwen2.5:7b-instruct o rotularla «historia: no existe en ningún servidor vigente». **No** se cita la tabla 2b/4b del insumo. |
| 6.11 | — | Cierre: `contar.sh` antes/después, `verificar-markdown.py`, anclas, barrido; sha256 en `04-Aplicacion.md`. |

### B-07 · Guía, Parte III (§6–§7)

| Paso | REC | Operación exacta |
|---|---|---|
| 7.1 | REC-22 | §6.3/§6.4: reemplazar «si el adaptador lo informa» por el hecho (OllamaSharp 5.5.0 no expone `prompt_eval_cached_count`) y el camino (lector en `_Comun`); l. ~1395: cifra `⟦REC-02:05-prefijo⟧`. |
| 7.2 | REC-21 C | §6.5: frase del tokenizador (si no quedó en §5.4). |
| 7.3 | REC-05 | l. ~1596 (y A.12 en B-10): la razón pasa a «papeles separados y recarga»; el 501 queda como historia; EMB-A/EMB-B redefinidos. |
| 7.4 | REC-28 | §6 y §7: lecciones rotuladas «no abstenerse por umbral salvo calibración separable», «citar no es fundamentar», «el formato sale del ejemplo»; determinismo de embeddings `⟦REC-02:06-determinismo⟧`. Barrido de frases que comparan contexto fijo y RAG sin corrida: cada una se rotula o se quita. |
| 7.5 | REC-29 | §7: lección «el modelo afirma un dato sin consultar» con `⟦REC-02:08-fuera-de-catalogo⟧`. |
| 7.6 | REC-06.7 | §7.6: «del todo» se mantiene (APOR-G-26). |
| 7.7 | — | Cierre como 6.11. |

### B-08 · Demo `Demos/MovilidadUrbana.Asistente/`

| Paso | REC | Origen | Operación exacta | Verificación |
|---|---|---|---|---|
| 8.1 | REC-13 | `$INSUMO/Guia/Demos/MovilidadUrbana.Asistente/src/MovilidadUrbana.Asistente/Agregado/Presentation/LimitadorDelModelo.cs` | Portar el `ConcurrencyLimiter` singleton en la entrada HTTP, compartido por la API y la página Blazor, 503 con `Retry-After`, con sus opciones. Prueba de 4 simultáneos **determinista** (barrera; no depende del orden; AH-02-07): 3×200 y 1×503 con permiso 3, cola 0. | prueba verde 10 veces seguidas; **[V2 M-E]** si no sale 10/10, caída a REC-13 C (§4.3) |
| 8.2 | REC-26 A | `$INSUMO/Guia/Examples/13-*/tests/…/Cableado/{CasosRojosTests,ReglaDeCapas}.cs` | Quinta regla de ADR-11: Presentación → `Infrastructure/AI` sólo desde `Chat.razor`. Mutaciones «Cuerpo» y «Atributo» que dan rojo. | 5 reglas verdes; 2 mutaciones rojas |
| 8.3 | REC-17 | B-03 3.3 | Si se endureció `LocalidadRules`, replicar en la copia del dominio de la demo. | `diff-dominio.sh` sólo con ese delta |
| 8.4 | REC-14 | base | Verificar que la demo registra `AddDbContextFactory`; si no, registrarla. | grep + prueba de composición |
| 8.5 | REC-05 | base | Comentarios de EMB en la demo como en 07. | — |
| 8.6 | — | — | `demo.sh build`, `demo.sh pruebas` (70 + nuevas), `diff-base.sh`, AC-4/AC-5/AC-10, barrido; Procedencia. | verde |

### B-09 · Guía, Parte IV + V (§8–§12)

| Paso | REC | Operación exacta |
|---|---|---|
| 9.1 | REC-32 | §8.1 (y Anexo C en B-10): una línea sobre el uso amplio del término «agente» y «MCP es transporte, no un nivel de orquestación» si falta. Se mantiene la definición de la base. |
| 9.2 | REC-29 | §8.2: Ollama no hace cumplir el enum, rotulado «estación 1, 0.40.11, 2026-10-28» (6/10 con el 0.5b, recalculado con Clopper-Pearson, «una entrada, N semillas»). |
| 9.3 | REC-16, REC-20 | §8.5: caso «CP 34 → 3400» (`⟦REC-02:03-cp34⟧`), la `GarantiaDelTexto` como defensa (no `SaveAsync`, l. ~2010); X2 y D6 del insumo rotulados por estación y con estimando «este pedido», recalculados con Clopper-Pearson. |
| 9.4 | REC-27 | §8.7: el hecho, la condición y el límite (si se comprometen los dos almacenes, la guarda no alcanza). |
| 9.5 | REC-30 | §8.8: «con el gestor que trae el paquete, por turnos (código)»; §9.7: una línea con las trampas de SK. |
| 9.6 | REC-19 | §10.4: etiqueta del estimando, aserción de existencia y «caída de red = no medido». |
| 9.7 | REC-18 | §10.5: `EquivalenceEvaluator` con el oro; §10.6: lo que vio el laboratorio como existencia (N=1, rotulado), «no interpretable» y `⟦REC-02:15-juez⟧`; l. ~2992: salida `--fake` rotulada «cableado, no medición»; 0/52 como historia. |
| 9.8 | REC-23 | §11.2: garantía en una sola frase («ninguna escritura depende del texto: o no hay herramienta que escriba, o toda escritura espera aprobación con su contrato»), con remisión a §8.5; §11.2/§11.7: «repitió el texto inyectado», rotulada, sin negaciones dobles, cifra `⟦REC-02:16-inyeccion⟧`. |
| 9.9 | REC-20 | §11.3: remisión a X2/D6 como en 9.3. |
| 9.10 | REC-31 | §11.4: párrafo de celda mínima, supresión complementaria y límite de cruces, sin código (texto de origen: `$INSUMO/Guia/Dot-Net-Integration-AI-Layer-Guide.md`, párrafo de CTRL-07/`TamanoMinimoDeCelda`, adaptado con DECI-30). |
| 9.11 | REC-11, REC-24 | §11.6: credenciales en el `HttpClient` o en un `DelegatingHandler`, nunca en las cabeceras del pedido (sin nombrar la propiedad); Ollama no autentica: publicar sólo a la interfaz del bridge o a 127.0.0.1. |
| 9.12 | REC-12, REC-13 | §12.3: sesión y versión de datos en la clave; no cachear con herramientas sobre datos mutables; límite de concurrencia recomendado en la entrada HTTP (demo), capa del cliente como alternativa; l. ~3463: deuda cerrada. |
| 9.13 | REC-08 | §12.4: regla del `num_ctx` (remisión a §5.5). |
| 9.14 | REC-24 | §12.6: advertencia de interfaz y autenticación. |
| 9.15 | REC-06.3 | l. ~3383: frase del compartido como entorno actual → historia. |
| 9.16 | — | Cierre como 6.11. |

### B-10 · Guía, Parte VI + Cierre + Anexos (§13–§15, A–G)

| Paso | REC | Operación exacta |
|---|---|---|
| 10.1 | REC-15 B | ADR-03: modelo provisional con digest `⟦REC-02:digest-4b⟧`; alternativa 7b quitada o rotulada. |
| 10.2 | REC-20 | ADR-06: `AccionPropuesta` como alternativa descartada, con su motivo. |
| 10.3 | REC-12, REC-13 | ADR-09: las dos reglas de caché y el limitador en la entrada HTTP; tabla de delta de §14.1 con la fila del limitador y procedencia. |
| 10.4 | REC-26 | ADR-11 y §13.12: cinco reglas, agujeros declarados (DEU-06). |
| 10.5 | REC-14 | ADR-12, §13.13: citar la prueba roja de 08; párrafo del circuito. |
| 10.6 | REC-17 | §14.1: fila «Modificado a causa de la IA» (si 3.3 aplicó) o «verificado, no hizo falta» (DEU-01); l. ~1075 «entre 3 y 60» coherente con el resultado. |
| 10.7 | REC-13 | Anexo B l. ~4495: deuda del límite cerrada; REC-14 en la lista del Anexo B. |
| 10.8 | REC-19 | A.10 y E.6: estimando, existencia, «caída = no medido». |
| 10.9 | REC-05, REC-11 | A.12: EMB-A/EMB-B redefinidos, razón «papeles separados y recarga», 501 como historia; regla de credenciales. |
| 10.10 | REC-30, REC-32 | Anexo C: «workflow — (no se traduce)» con barrido de las tres formas («flujo de trabajo», «flujo», «workflow» en cursiva); línea del uso amplio de «agente». |
| 10.11 | REC-31, REC-06.7 | Anexo D/D.9: Ley 25.326 (arts. 2 y 28, InfoLEG) y ResDAC como práctica, en el formato de la base; REF-142 y autores faltantes consultados (sin datos de memoria, ESTA-19); referencias del insumo sólo con la unidad que las usa (APOR-G-28). Todo lo portado apunta su procedencia a 8fb4c3a; no entra el muestreo de la ficha del modelo (APOR-L-24). |
| 10.12 | REC-24, REC-06.3 | E.3: advertencia de interfaz/autenticación y «la imagen se verificó por digest»; l. ~4877 y ~4890: compartido → historia; §E.5: `⟦REC-02:E5-presupuesto⟧`. |
| 10.13 | REC-35 | F.1: sin los tres paquetes retirados; `paquetes_hash` nuevo. |
| 10.14 | REC-25 | Anexo F l. ~5061: negociación 2026-07-28 de «inferencia» a «registrada» con `⟦REC-02:13-negociada⟧`; catálogo único como alternativa (DEU-05). F.4: `⟦REC-02:F4-servidores⟧`. |
| 10.15 | REC-34 | Sin acción; DECI-30 aplicado en todas las remisiones. Oración NUnit sólo si el build la confirmó (DEU-03). |
| 10.16 | — | Cierre como 6.11 + `verificar.sh build`, `demo.sh pruebas` y compuertas AC-5…AC-10 sobre copia `rec-b10`. **Fin de la integración sin modelo.** |

### B-11 · Fase con modelo única (REC-02, con REC-07, REC-08, REC-15, REC-16, REC-18…REC-23, REC-28, REC-29)

**Preparación (antes del primer turno).**

1. **Criterio previo con sha256**: por corrida, `$REC/Recorrida/criterio-<id>.md` con hipótesis, oráculo, N, umbral de lectura y estimando («una entrada, N semillas» o «N entradas distintas»); `sha256sum` de cada criterio anotado en `04-Aplicacion.md` **antes** de pedir el turno. No se edita después.
2. **Registros fuera del árbol**: `RLLM_DIR=$TRABAJO/rec02/registros/<estacion>/`; al cerrar, la copia a `$BIT/Evidencia/R-LLM-2026-10-28/` pasa el barrido.
3. **Salud y digests en cada turno**: versión de Ollama, `/api/tags`, digest del 4b (`d8b0f5e9760c`) y del embedding (`ac6da0dfba84`); si no coinciden, la corrida es «no medido».
4. **Columna «servidor»** en todo registro: `estacion-1` / `estacion-2` (rótulo fijado por la presidencia; `RLLM_MAQUINA` y `OLLAMA_SERVIDOR` desde el entorno, B-01 1.5).
5. **Ventana**: `num_ctx=8192` cargado dentro del turno; `/api/ps` registrado (REC-08).
6. **Presupuesto §E.5 recalculado** desde R-LLM-5 (≈ 27 s por llamada del 4b, ≈ 90 llamadas por turno de 45 min en la estación 2) para cada estación; `TOPE_COMPARTIDO_S` fijado por la presidencia por estación. Un turno que no cabe se parte, no se recorta N.
7. **Estación 2**: nunca emuladores ni KVM; cupo 1 (ELV-02); se apaga al cierre con inventario.
8. **Fallas del entorno** (timeout, red, recarga a mitad): la corrida es «no medido», sin reintento silencioso; un reintento es una corrida nueva con su propio criterio.
9. `keep_alive: 0` al terminar cada fase.

**Corridas.**

| ID | Pieza | Qué | Estación | N | Destino en la guía |
|---|---|---|---|---|---|
| R-01 | 01 | ConModelo + cancelación (`01-cancelacion`) | 1 | 2 entradas (v1) ; cancelación 10 semillas | §5 |
| R-02 | 02 | ConModelo + captura de cuerpo `/v1` (`02-max-tokens`: MaxOutputTokens=3) | 1 | 1 entrada (v1); max-tokens 10 semillas | §5.6 |
| R-03 | 03 | v1 + extensión + `cp34` | 1 | 2 + 8 (ext.) + 10 semillas sobre 1 entrada | §8.5 |
| R-04 | 04 | v1 + extensión | 1 | 2 + 8 | §8 |
| R-05 | 05 | prefijo (`05-prefijo`, `estado_cache`) | 1 | 6 entradas, orden del plan | §6.3/§6.4, l. ~1395 |
| R-06 | 06 | embeddings, calibración aparte, determinismo | 1 | **[V2]** evaluación = oro v2 completo (17); calibración = 10 casos de `oro/calibracion.v1.json`, disjuntos del oro; determinismo 2 corridas idénticas | §6, §7 |
| R-07 | 07 | RAG + estabilidad + vía embeddings (oro v2) | 2 | 17 (oro v2) ; estabilidad según `ejemplo.json` | §7, §10 |
| R-08 | 08 | v1 + extensión + `fuera-de-catalogo` | 2 | 2 + 8 + 10 semillas | §7, §8 |
| R-09 | 09 | ConModelo | 1 | 2 | §8 |
| R-11 | 11 | ConModelo | 2 | 1 entrada, 10 semillas | §8.7 |
| R-12 | 12 | ConModelo | 2 | 2 | §8.8 |
| R-13 | 13 | ConModelo + `NegotiatedProtocolVersion` (`13-negociada`) | 2 | 1 | Anexo F |
| R-15 | 15 | juez (`15-juez`) con el 4b, razonamiento apagado, `num_ctx` ≥ 8192; advertencia de familia | 2 | 52 evaluaciones (≈ 34 s c/u, ≈ 30 min; DECI-29) | §10.6 |
| R-16 | 16 | inyección indirecta con estimando (`16-inyeccion`) | 2 | 6 variantes × 10 semillas | §11.2/§11.7 |
| R-17 | 17 | ConModelo + contador de caché | 1 | 1 | §12.3 |
| R-D3 | sonda DEP-03 | truncado con el 4b (`DEP-03`) | 2 | 3 | §5.4, l. ~1013 |
| R-D9 | sonda DEP-09 | escrituras con aprobación | 1 | según `Sondas/` | §8.5/§11.3 |
| R-D13 | sonda DEP-13 | según `Sondas/` | 1 | según `Sondas/` | — |
| R-PD | demo | humo PD-2, PD-3 (con «CP 34»), PD-6; `demo.sh embeddings` | 2 | 3 humos; 9 entradas (v1) | §14, PD-2/3/6 |
| R-DG | — | digests y versión de ambas estaciones (`digest-4b`, `F4-servidores`) | 1 y 2 | 1 | F.4, §4.2, §5.7 |
| R-E5 | — | tiempos reales por llamada y por estación (`E5-presupuesto`) | 1 y 2 | todas las anteriores | §E.5 |

**Lectura.** Toda tasa con Clopper-Pearson 95 % (`verificar.sh tasa`) y la etiqueta del estimando; `tools/compuerta-intervalos.py` sobre los registros nuevos; `recalcular-oraculos.sh` (con el segundo directorio) en 0 discrepancias. **[V2 M-D]** Ninguna tasa ni pareado combina corridas de las dos estaciones, ni siquiera con la columna «servidor» (regla en §4.3).

**Verificación de cierre de B-11:** cada R-* con registro, criterio con sha256 previo, resultado o «no medido»; inventario de modelos cargados y descargados por estación; estación 2 apagada o devuelta según ELV-02.

### B-12 · Guía, relleno de cifras (REC-02, REC-06.3)

| Paso | Operación | Verificación |
|---|---|---|
| 12.1 | Reemplazar cada `⟦REC-02:<id>⟧` por la cifra de su R-*, con rótulo «estación N, Ollama x.y.z, digest, 2026-10-2x, estimando». Si la corrida quedó «no medido», el texto lo dice así y la frase que dependía de la cifra se reformula sin afirmarla. | `grep -c '⟦REC-02:' $DOC` = 0 |
| 12.2 | F.4 y §4.2: tabla de tres servidores (compartido retirado — historia; estación 1; estación 2) con digests vigentes (ENTO-07). | tabla presente; barrido = 0 (sin endpoints ni nombres) |
| 12.3 | §E.5 recalculado; F.4 reescrito; las 29 menciones «Observado» del servidor retirado: cada una re-medida o rotulada «historia» (`grep -n 'Observado'`). | cero «Observado» sin rótulo de servidor |
| 12.4 | Actualizar `estado` de cada `ejemplo.json` con la corrida nueva y los README re-rotulados (REC-08). | `jq` sobre los 17 |
| 12.5 | Cierre como 6.11 + `compuerta-intervalos.py` sobre `$DOC`. | verde |

### B-13 · Encabezado y versión resultante (REC-01)

- `version: 0.11.0`, `status: en revisión`, `last_review: <fecha de cierre de B-12>`; la línea de versión bajo el título: «**Versión** 0.11.0 · **Fecha** <misma> · **Estado**: en revisión. Recupera como base la línea de construcción y redacción del 2026-10-27, integra los aportes de la línea paralela del 2026-10-28 y re-mide lo observado en los dos servidores de laboratorio vigentes.» Las cifras de líneas y palabras salen de `contar.sh`, no se escriben a mano.
- Registro de versiones de `$BIT/Redaccion/`: nota fechada 0.10.1 → 0.11.0 con el resumen por REC.
- Verificación integral: `verificar.sh build`, `demo.sh pruebas`, `diff-base.sh`, `diff-dominio.sh`, AC-5…AC-10, `verificar-markdown.py`, anclas, mermaid, barrido ampliado y compuerta v2 en 0, `find $GUIA \( -name bin -o -name obj -o -name '*.db' \)` vacío.

### B-14 · Relectura integral (REC-03, REC-04)

1. **Sobre la guía 0.11.0 ya re-corrida** (después de B-12/B-13), no antes.
2. **Panel completo**: los 8 especialistas de esta mesa (didáctica, edición, senior .NET, experto en IA, arquitectura, operación, AH-01 seguridad, AH-02 evaluación) más el abogado del diablo, y el jurado de 5 (coherencia histórica, costo-beneficio, evidencia, impacto, riesgo), según `/IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md`.
3. **Compuertas mecánicas**: AC-5…AC-10, `verificar-markdown.py`, barrido R-PRIV ampliado, conteo de REC-21, `compuerta-intervalos.py`, `compuerta-cabeceras.sh`.
4. **Insumo de la relectura (REC-04)**: los 13 `Informe-*.md` de `$INSUMO/Bitacoras/Mesa/Ciclo-1/` se copian **pieza por pieza** a `$REC/Relectura/insumo/`, con las redacciones de RPRI-18 y barrido en 0; cada lector usa la tabla DECI-30 para traducir la numeración y descarta lo que no aplica a la base. No se tratan como hallazgos de esta mesa.
5. Salidas en `$REC/Relectura/`; parches con el ciclo normal (consolidado → votos → parches → aplicación); cada parche vuelve a pasar las compuertas.

### B-15 · Cierre y presentación al PO

- Estado al PO (DEU-07): publicación de la demo, commit de la guía y AC-10, y paso de 0.11.0 a «publicada». Ninguno se ejecuta en esta mesa.
- Barrido de datos privados final sobre todo lo que entraría en un commit (lista de exclusiones de B-02 2.4/2.5).
- Inventario y limpieza (§E.6): contenedores, volúmenes de trabajo, `$TRABAJO/rec-*`, modelos cargados en las estaciones.
- `Procedencia.md` cerrado: toda fila con sha256 de destino.

---

## 3. Registro de procedencia

[`Procedencia.md`](Procedencia.md) lista cada pieza traída del insumo: destino, origen en `$INSUMO`, REC, operación (portar / adaptar / citar rotulado / copiar como insumo), sha256 de origen (calculado el 2026-10-28) y sha256 de destino (al aplicar). Lo que no está en esa tabla no vino del insumo.

---

## 4. Vuelta 2 — plan consolidado (aprobaciones del jurado, 2026-10-28)

### 4.0 Qué se resolvió y cómo se lee

Los cinco jueces (`04-Aprobacion-evidencia.md`, `-impacto.md`, `-costo-beneficio.md`, `-coherencia-historica.md`, `-riesgo.md`) votaron **MEJORAR_PLAN**. Los cinco confirmaron los conteos de §0.3, el veto único de REC-06 sobre B y el sha256 de la 0.10.1. Ninguno escala: nada toca REED-16 §12. Lo que pidieron son condiciones que las boletas votaron junto con la opción ganadora y que la vuelta 1 dejó afuera, o en tres casos contradijo (REC-07, REC-10, REC-21 C).

- **Precedencia:** el §4 manda sobre el §0–§2. Las filas del §2 marcadas «[V2 …]» ya están reescritas. Los pasos nuevos (1.7b, 6.0, 6.0b, 6.12, 6.13) se ejecutan en el orden que les da su número, dentro de su bloque.
- **Cierre de la aprobación:** cuatro jueces dejaron escrito que con sus enmiendas incorporadas «queda aprobado sin otra votación» (impacto: con M-1…M-4; costo-beneficio y coherencia histórica: con todo). Evidencia y riesgo no pusieron condición de voto. Las enmiendas A–J de abajo cubren la unión de lo que pidieron los cinco, así que el plan pasa a **aprobado**. Sólo una contradicción nueva entre el §4 y una boleta reabriría el voto.
- **Correspondencia:** cada enmienda lleva los ID de origen: Ev = evidencia, Im = impacto, CB = costo-beneficio, CH = coherencia histórica, Ri = riesgo.

### 4.1 Enmiendas obligatorias (bloquean la aplicación del bloque que tocan)

| ID | Ítem | Paso | Texto consolidado (lo que se hace) | Verificación | Origen |
|---|---|---|---|---|---|
| **M-A** | REC-07 C | B-01 1.5; B-11 prep. 4 | Rige en **todos** los modos con modelo: `fase` (lan y propio), `extension`, `estabilidad`, `embeddings` y `demo.sh embeddings` usan `${OLLAMA_SERVIDOR:?}`, `${RLLM_MAQUINA:?}` y `${RLLM_MAQUINA_PROPIO:?}`, **sin defecto**. Sólo `build` y `--fake` aceptan el valor neutro `sin-servidor`, con el rótulo «guion». La presidencia fija los valores por estación en el shell, antes de pedir el turno. | Sin cada variable: rc ≠ 0, con mensaje y sin ninguna llamada HTTP. Casos nuevos en `ArnesTests` (uno por variable y modo). | Ev M-1, Im M-2, CB M-1, CH M-1, Ri M-1 |
| **M-B** | REC-10 | B-06 6.9 y paso nuevo 6.12 | La fila de §5.6 dice: «el cliente envía `tool_choice`; la documentación de `/v1` no lo lista [REF-51]; que el servidor lo cumpla no está medido». **6.12:** con `grep -n 'tool_choice' $DOC` (7 apariciones en la 0.10.1: l. ~1000, 1027, 1279, 1300, 2107, 3625 y la ficha de REF-51 en ~4666), cada frase que diga que `/v1` «no admite» o «no tiene» `tool_choice` se alinea a «no lo lista la documentación; no medido». Las de §8 (l. ~2107) y ADR (l. ~3625) se alinean en B-09/B-10 con el mismo criterio. La ficha de REF-51 describe la fuente y queda como está. | `grep -n 'tool_choice' $DOC`: ninguna aparición afirma que el servidor lo ignora o lo rechaza. Lista anotada en `04-Aplicacion.md`. | Im M-1, CB M-2, CH M-2, Ri M-2 |
| **M-C** | REC-19 | B-01 1.9 | Ya reescrito en el §2. El criterio es n/n, con n igual a lo que reconoce la compuerta en la 0.10.1. La lista va con línea y registro de origen. El positivo de prueba es una cifra alterada en la copia, que da rc 1. «365/365» queda **sólo** en 2.3 (AC-3b). | Igual que la fila 1.9. | Ev M-3 |
| **M-D** | REC-02 | B-11 prep. 6, prep. 8 y Lectura | **Regla de estación:** (1) cada tasa y cada pareado se miden **enteros en una sola estación**, y ninguno cruza estaciones, aunque esté la columna «servidor». (2) Un turno que no entra se parte en la **misma** estación. (3) Un reintento corre en la misma estación, como corrida nueva con criterio nuevo. (4) El estimando queda fijado en el criterio con sha256 antes del primer pedido. (5) Si la estación se cae, lo que falta queda «no medido» y no se completa en la otra. **Exentas:** R-DG y R-E5, que son descriptivas y se informan por estación, sin agregarse. | Cada `criterio-<id>.md` nombra una sola estación. En los registros de R-* (menos R-DG y R-E5), `jq` da un único valor de `servidor` por corrida. | Ev M-4, CB P-3, CH M-7, Ri M-7 |
| **M-E** | REC-13 | B-08 8.1; B-09 9.12; B-10 10.3, 10.7 | Si la prueba de 4 simultáneos con barrera no queda verde **10 de 10 seguidas**, no se porta el limitador: se aplica **REC-13 C** y se abre **DEU-08**. §12.3 queda en prosa (recomendación con alternativa y sin la cifra de la demo). ADR-09 y la tabla de §14.1 no llevan la fila del limitador. Anexo B (l. ~4495) mantiene la deuda abierta y remite a DEU-08. | Resultado (10/10 o caída) anotado en `04-Aplicacion.md`. Si hubo caída, `grep -n LimitadorDelModelo $GUIA -r` = 0 y DEU-08 aparece en la tabla de deuda (§4.4). | Ev M-6, Im P-1, CB M-3, CH M-6, Ri M-3 |
| **M-F** | REC-21 C | B-06 6.6; B-07 7.2; B-11 R-D3 | La frase de 6.6 ya está reescrita. Además, una **verificación sin modelo**: una prueba en `_Comun` confirma que `GuardaDeTruncado` recibe y usa el modelo de la llamada. Si no lo usa, se corrige **esa pieza** sin sumar el detector que lanza (REC-21 A sigue perdedora). Si la corrección no entra en B-03, se declara deuda en `04-Aplicacion.md` y la frase de la guía se escribe «no lo hace todavía». R-D3 registra la estimación de la guarda junto al conteo real del servidor. | Prueba verde, o deuda declarada. En R-D3 cada fila trae `estimado` y `real`. | Im P-5, CB M-4, CH M-3, Ri M-8 |
| **M-G** | REC-18 | B-05 (15); B-11 R-15; B-09 9.7 | `criterio-15.md` fija **antes** del turno la fracción mínima de evaluaciones interpretables. Si no se alcanza, R-15 es «no medido» y §10.6 lo dice así. La guía declara que el juez y el modelo evaluado son **de la misma familia** y que «el acuerdo con un juez de la misma familia no es validación». | El criterio tiene la fracción y su sha256 está anotado. `grep -n 'no es validación' $DOC` ≥ 1 en §10.6. | Ev M-5, Im P-2, CB M-5, CH M-4, Ri M-5 |
| **M-H** | REC-23 | B-11 R-16; B-09 9.8 | `criterio-16.md` incluye el oráculo «reproduce el texto inyectado». Si R-16 lo observa con la composición de la base, esa medición reemplaza la cita del insumo. Si no lo observa, lo del insumo entra sólo como **existencia rotulada** («otra composición, sin escritura»). Todo texto inyectado que cite la guía es **sintético** y pasa el barrido ampliado. | Oráculo presente en el criterio. Barrido = 0 sobre las citas de §11.2 y §11.7. | Ev M-10, Im P-7, CB M-6, CH M-5, Ri M-6 |
| **M-I** | REC-22 | B-03 3.1 y 3.5; B-04 (05) | El `DelegatingHandler` lector **no persiste** en disco el NDJSON ni los cuerpos completos. Sólo deja en el registro R-LLM los contadores (`prompt_eval_cached_count` y duraciones). Una prueba lo comprueba: después de un pedido guionado, ningún archivo nuevo en `RLLM_DIR` contiene el cuerpo, y `compuerta-cabeceras.sh` da rc 0. En 3.5, rebuild completo n/n y `ArnesTests` en verde. | Prueba verde, compuerta en 0, build n/n y `ArnesTests` anotados. | Ev M-7, Im P-4, CB M-7, CH M-9, Ri M-4 |
| **M-J** | REC-01/02/05/06.3 | B-06, pasos nuevos **6.0** y **6.0b**, y compuerta de cierre en 10.16 | **6.0:** la plantilla de rótulo de §0.4 (l. ~163, la que el lector imita en toda la guía) se reescribe así: «estación N, Ollama `⟦REC-02:F4-servidores⟧`, digest `⟦REC-02:digest-4b⟧`, fecha, estimando». El digest 2a654d98e6fb, la versión 0.32.0-rc0 y el «compartido» salen de la plantilla. Es la **misma forma corta** que usa B-12 12.1. **6.0b:** §0.3 (l. ~139) nombra los servidores por **papel** (EMB-A = el mismo servidor del chat; EMB-B = un servidor aparte), no por un equipo retirado. **Paso 6.13 (y su par en B-07, B-09 y B-10):** cada mención en presente de «Ollama propio» (28 en la 0.10.1), «servidor compartido» (53), `2a654d98e6fb` (13) y `0.32.0` (17) pasa a papel o a historia («hasta el 2026-10-28, …»). | **Compuerta en 10.16 y 12.3:** `grep -nE 'Ollama propio\|servidor compartido\|2a654d98e6fb\|0\.32\.0\|TOPE_LAN_S' $DOC`. Cada aparición que quede lleva rótulo de historia en su párrafo (lista clasificada en `04-Aplicacion.md`), con 0 sin rótulo. La forma corta de §0.4 es idéntica a la de 12.1 (`diff` de las dos cadenas). | Ev M-8, Im M-3, Im M-4, CB (a), CH M-8, Ri M-9 |

### 4.2 Enmiendas de evidencia que agregan pasos al arnés y a la lectura

| ID | Ítem | Paso | Texto consolidado | Verificación | Origen |
|---|---|---|---|---|---|
| **M-K** | REC-02/15 | B-01, paso nuevo **1.7b** | La fase compartida (`num_ctx_compartido()` y la fase `lan`, verificar.sh l. ~264–284) recibe la **misma precondición mecánica** que ya tiene `_propio()` (l. ~285–301). Dentro del turno lee `/api/version` y `/api/tags`, compara la versión y el digest del 4b (y del embedding cuando corresponde) contra los valores esperados, que la presidencia pasa por variable (`OLLAMA_VERSION_ESPERADA`, `DIGEST_4B_ESPERADO`, `DIGEST_EMB_ESPERADO`, **sin defecto**, como en M-A), y escribe una fila `{tipo:"servidor-compartido", …}` en `turnos.jsonl`. Si algo no coincide: rc ≠ 0, ninguna medición y «no medido». El digest esperado del 4b es el vigente (`d8b0f5e9760c`). El de la base (`2a654d98e6fb`) es **otro artefacto** y nunca se acepta como equivalente. | Prueba en seco con `/api/tags` guionado con otro digest → rc ≠ 0 y fila con `coincide:false`. Con el digest correcto → rc 0. Caso nuevo en `ArnesTests`. | Ev M-2 |
| **M-L** | REC-29/16/20 | B-09 9.2, 9.3 y 9.9; criterio E2 | El 6/10 del enum con el 0.5b (9.2) y X2/D6 del insumo (9.3 y 9.9) se rotulan **«existencia, otra composición (modelo, vía)»**, nunca como tasa de la tarea de la base. Si R-03 o R-08 miden lo mismo con la composición de la base, **se prefiere esa cifra** y la del insumo queda sólo como existencia. | Cada cita del insumo en §8.2, §8.5 y §11.3 lleva el rótulo, o fue reemplazada por R-03/R-08. | Ev M-9 |
| **M-M** | REC-05/22 | B-06 6.10; B-07 7.1 | §5.7 y §6.3 dicen **lo mismo** sobre `estado_cache`. Del insumo entra sólo la **existencia** del lector y del contador. La cifra sale de R-05 (`⟦REC-02:05-prefijo⟧`). | Las dos secciones remiten a una única formulación (texto idéntico o remisión explícita). | Im P-6 |

### 4.3 Reglas de B-11 consolidadas (sustituyen la preparación donde discrepan)

1. **Criterio previo con sha256** (sin cambio), y además: la regla de estación de M-D, la fracción mínima de M-G en R-15, el oráculo de M-H en R-16 y el par estimación/real de M-F en R-D3.
2. **Variables sin defecto** (M-A y M-K): `OLLAMA_SERVIDOR`, `RLLM_MAQUINA`, `RLLM_MAQUINA_PROPIO`, `OLLAMA_VERSION_ESPERADA`, `DIGEST_4B_ESPERADO`, `DIGEST_EMB_ESPERADO` y `RLLM_DIR` se definen en el shell de la presidencia. Ninguna se escribe en un archivo del repo ni de la bitácora.
3. **Presupuesto antes del primer turno** (CB d): suma de llamadas por estación desde la tabla de corridas. Con R-LLM-5 (≈ 27 s por llamada del 4b, ≈ 90 por turno de 45 min), la estación 2 necesita ≈ 180 llamadas o más, es decir 2 o 3 turnos. La suma por estación se anota en `04-Aplicacion.md`. **Orden de prioridad:** garantías (R-PD con PD-6, R-D9, R-16, R-15), después lecciones (R-03, R-05, R-06, R-08, R-D3 y las de §5/§7) y por último existencia (el resto). Lo que no entra en los turnos asignados queda «no medido»: **nunca se recorta N**.
4. **R-06** (ya reescrito en la tabla): la evaluación es el oro v2 completo y la calibración son 10 casos disjuntos.
5. **R-15 y R-16** se leen con M-G y M-H. Si el criterio no se cumple, «no medido», y la guía lo dice sin reformular a favor.
6. Lo demás del §2 B-11 rige como está.

### 4.4 Deuda declarada (agregado a la tabla de §0.3)

| ID | Qué queda abierto | Dónde se declara |
|---|---|---|
| DEU-08 | (sólo si M-E cae) REC-13 C: el límite de concurrencia queda como recomendación en prosa, sin el limitador portado. | §12.3, Anexo B, `04-Aplicacion.md` |
| DEU-09 | (sólo si M-F no entra en B-03) `GuardaDeTruncado` no estima todavía con el modelo de la llamada. | §5.4, `04-Aplicacion.md` |

### 4.5 Ajustes menores (no bloquean; se aplican en el paso que se indica)

| ID | Paso | Ajuste | Origen |
|---|---|---|---|
| m-1 | B-01 1.5 | Lista de `ejemplo.json` por `grep -rl`, no por número fijo (ya reescrito: 19 archivos en la 0.10.1). | CB (b), CH menor |
| m-2 | B-02 2.7 | El nombre de fase `lan` del arnés **no se renombra**, porque cambiaría rótulos de capturas fijadas por hash. La nota de 2.7 lo declara como nombre histórico del rol «estación 1 / modelo compartido». | Ri menor |
| m-3 | B-01 1.3 | El README de `Compuertas/` explica cómo un clon limpio arma las listas de AC-7 y AC-8: el formato, la variable `COMPUERTAS_DIR` y de dónde salen los términos, todo sin nombrarlos. Pasa el barrido. | Ri menor |
| m-4 | — | El `status` del encabezado refleja la vuelta («votado; Vuelta 2 consolidada»). Pasa a «aprobado; aplicado» sólo al cerrar B-15. | CH menor |

### 4.6 Compuertas añadidas por la Vuelta 2 (resumen para `04-Aplicacion.md`)

| Bloque | Compuerta | Criterio |
|---|---|---|
| B-01 | Variables sin defecto (M-A, M-K) | rc ≠ 0 sin cada variable; `ArnesTests` con los casos nuevos en verde |
| B-01 | Digest en la fase compartida (M-K) | Prueba en seco con otro digest → rc ≠ 0 |
| B-01 | `compuerta-intervalos.py` (M-C) | n/n con lista anotada; la cifra alterada da rc 1 |
| B-03 | Lector sin cuerpos (M-I) | Prueba verde; `compuerta-cabeceras.sh` rc 0; rebuild n/n y `ArnesTests` |
| B-06…B-10 | `tool_choice` (M-B) | Ninguna afirmación de que el servidor lo ignora o lo rechaza |
| B-10 / B-12 | Servidores retirados (M-J) | 0 apariciones de los cinco patrones sin rótulo de historia; plantilla de §0.4 = forma de 12.1 |
| B-11 | Estación única (M-D) | Un solo `servidor` por corrida (menos R-DG y R-E5) |
| B-11 | Criterios (M-G, M-H, M-F) | Fracción mínima, oráculo y par estimación/real presentes antes del turno |
