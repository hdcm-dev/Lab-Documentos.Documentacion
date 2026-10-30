---
doc_id: EXP0002-F257
doc_type: acta
title: Acta de la mesa de recuperación de lo hecho en i7infra — propuestas, refutación, fallo y plan por olas
status: vigente
origin: agent
confidence: alta en las citas verificadas por el refutador (comando y salida en su §0) y por el jurado; media en el orden de las olas, que es criterio del jurado
owner: presidencia de la mesa de recuperación del expediente 0002
last_review: 2026-10-28
audience: [PO, presidencia, agentes de E1-R, mesa de la opción B, bitacorista, línea Framework-Concept]
traces: [EXP0002-F133, EXP0002-F240, EXP0002-F245, EXP0002-F249, EXP0002-F250, EXP0002-F251, EXP0002-F252, EXP0002-F254, EXP0002-F256]
---

| Campo | Valor |
| --- | --- |
| Tipo | acta (mesa con tres comisiones, refutador y jurado) |
| Fecha | 2026-10-28 |
| Autor | Jurado de la mesa de recuperación. Elige, injerta y corrige; no redacta reparaciones |
| Objeto | Terminar E1 recuperando lo hecho en i7infra, sin perder ni reescribir lo fusionado desde hpdev |
| Número | 257 (D02); entra en el mismo PR que el rescate (K10) |
| Corrige | Nada. Las correcciones van por el `259` |

# 257 — Acta de la mesa de recuperación de i7infra

## Índice

1. [Testimonio del mandato](#1-testimonio-del-mandato)
2. [Composición](#2-composición)
3. [Propuestas](#3-propuestas)
4. [Refutación](#4-refutación)
5. [Fallo](#5-fallo)
6. [Diagnóstico](#6-diagnóstico)
7. [Decisiones](#7-decisiones)
8. [Corte de E1](#8-corte-de-e1)
9. [Plan por olas](#9-plan-por-olas)
10. [Lo de hpdev](#10-lo-de-hpdev)
11. [Lo que sale al PO](#11-lo-que-sale-al-po)
12. [Riesgos](#12-riesgos)
13. [Pase](#13-pase)

## 1. Testimonio del mandato

> «fijate que volvio a la vida i7infra, revisa lo que tenees aquí /LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Guides/14-Sistema-De-Documentador-Tecnico, /LAB/Lab-Documentos/Lab-Documentos/Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion - revisa lo que se ha avanzado en i7infra - toma como base i7infra, en esto estaba mejor que lo que tenia aquí - fijate que otros agentes trabajando en el repositorio, convoca una mesa para analizar como terminar este trabajo recuperando lo hecho en i7infra»

Hecho de contexto: i7infra perdió la red el 2026-10-28 cerca de las 00:50 −03 y volvió a la noche sin haberse apagado. Su sesión DocAsCode quedó cortada después de escribir el folio 290. hpdev trabajó todo el día dándola por perdida (`240`).

## 2. Composición

| Rol | Quién | Insumo |
| --- | --- | --- |
| Relevadores | R1 expediente, R2 Guía 14, R3 SDEI, R4 dictámenes, R5 estado | `{mesa-i7}/R1…R5`, foto `{resguardo-i7}` (sólo lectura) |
| Comisión 1 | C-RECUPERACION | Propuesta P1 |
| Comisión 2 | C-RECONCILIACION | Propuesta P2 |
| Comisión 3 | C-CIERRE | Propuesta P3 |
| Refutador | — | `{mesa-i7}/refutacion.md`: 51 citas comprobadas con comando |
| Jurado | este folio | Fallo e injertos; una verificación propia (runners, §6.7) |

Nadie escribió en ningún repo ni en i7infra; nadie leyó `h.cfg` (PE-10).

## 3. Propuestas

| Propuesta | Tesis | Lo mejor | Lo peor (según la refutación) |
| --- | --- | --- | --- |
| P1 C-RECUPERACION | Rescatar los 90 archivos literales por folios nuevos; rige el 245 | Base por pieza (D01), PR H con merge y no rebase (D05), aceptación de privacidad por clases (D10), IDs `K` sin choque | G-a «cumple» en la corrigenda; 245:300 corregido a falso; edita la carátula; deja U25/U26 sin corrida nueva; el 290 publicado una ola antes que su constancia |
| P2 C-RECONCILIACION | Una sola historia (GitHub) y un árbol sin versionar; i7infra mejor en sustancia, peor en el corte | Diagnóstico más preciso; el 257 en el mismo PR que el rescate; corrida nueva de los originales (U25-ENS-ORIG); conserva el umbral de G-e de 251 | Rebasa LDD #32 (reescribe un PR publicado); «245 §11 sí se emitieron»; olas incoherentes |
| P3 C-CIERRE | Camino más corto a E2 | Tabla de destino por folio; `redact2.py` con patrones fuera del repo; sitio regenerado fuera del repo | Baja el umbral de G-e a PE-1; rebasa LD #31; excluye la carpeta que necesitan sus propias unidades; IDs que chocan con `plan-final.json` |

## 4. Refutación

El refutador comprobó 18 citas de P1, 16 de P2 y 17 de P3 (su §0). Objeciones que el jurado acoge, todas:

| Id | Objeción | Efecto en este fallo |
| --- | --- | --- |
| C1 | `245:300` dice la verdad: la onda 8 nunca se emitió (`00-Indice.md:57`) | D04 y D12: la 259 sólo corrige que 0–7 existían sin publicar |
| C2 | G-a no puede «cumplir» en una corrigenda con evidencia privada | D05: antecedente, se mide en U41 |
| C3 | i7infra volvió con runners de los mismos nombres y etiquetas | D09; el jurado lo confirmó (§6.7) |
| C4 | La carátula no se edita (`252:73`, DEC-19) | D04: la tabla de folios va en el 258 |
| C5 | «grep = 0» no se puede cumplir sin editar literal | D11: «0 sin clasificar y 0 reales» con las dos partes de 254 |
| C6 | El protocolo de P-LECT es del PO (DEC-16, `250:218`) | D13 al PO con default |
| C7 | «Cuarto resultado» es simétrico; falta avisar el apartamiento | D03 lo descarta y avisa |
| C8 | Liberar el 260 deja `251:98` y `250:297` sin corregir | D02: el 260 se mantiene y se cita por nombre |
| C9 | FC 88/88 contradice DEC-14 | D14: ≥ 83/89 |
| C10 | Líneas del token mal citadas | D08 con las líneas correctas |
| P2-1, P3-2 | Rebase de PR publicados | D06: commits nuevos y merge de main |
| P3-1 | Umbral de G-e rebajado | D13: rige `133:45` y `250:308` |
| P3-5 | IDs de unidad chocan con el plan de hpdev | D15: se conservan los IDs de hpdev; lo nuevo con prefijo K |
| Cita 2, 13, 17 | Primer padre falso; «byte a byte» sólo para `01`; renumerar no rompe citas | Diagnóstico y D02/D10 corregidos |
| Cita 18 | Quién fusionó #28 ya está en `240:142-146` | No se pregunta al PO |

## 5. Fallo

Gana **P1 (C-RECUPERACION)** como columna: tiene la base por pieza más precisa, es la única que ajusta los PR H sin reescribir historia, la mejor aceptación de privacidad y unidades con IDs que no chocan. Se injerta:

- de **P2**: el diagnóstico de git (#26 desde i7infra a las 00:40 antes de la caída), el acta y la constancia en el mismo PR que el rescate, la corrida nueva de los guiones originales (U25) y las marcas URL+SHA (U26), el umbral de G-e de 251;
- de **P3**: la tabla de destino por folio, `redact2.py` con patrones privados fuera del repo, el sitio regenerado fuera del repo y la exclusión de lo que no se publica.

Y se corrige lo que la refutación tumbó (§4). El corte INSUFICIENTE del 245 se sostiene por sus fundamentos sólidos.


## 6. Diagnóstico

Hay una sola historia de git, la de GitHub. Lo que falta de i7infra es árbol de trabajo que nunca se versionó.

1. Ningún commit del expediente vive sólo en i7infra: `git log --branches --not --remotes` da sólo `5f1e0b4` (FC) en LD y nada en LDD (refutación §0 cita 1). `e83f373` entró por LD #26 (merge `56ea2d3`, 00:40:30 −03, desde i7infra antes de la caída) y `9b49337` por LD #27 (merge `75043a5`, 08:44:10 −03, desde hpdev). Los primeros padres de esos merges son `fe10086` y `56ea2d3`, no `0989a15` (cita 2).
2. Sólo en i7infra hay 90 archivos del expediente: 11 folios (212-e1-u2, 213-e1-u3, 214-e1-u4a, 218-e1-u4b, 230-e1-u0c, 250-e1-u4e, 251-e1-u4d, 252-e1-u4c, 260-e1-u4f, 270-e1-u5, 290-compuerta-e1) y 79 de evidencia, incluidos `E1-U0c/02-redact.py` y `local/001` (`{mesa-i7}/only-i7.lst`, cita 5). Más 14 DocsAsCode-Bitacoras de la Guía 14 (00 y 03–15) y la ia-db v4.0, que no está en ningún commit (R5 §2). Los 178 archivos comunes son iguales o mejores en GitHub (120 iguales, 58 que sólo difieren en la redacción de `cc2bfd6`/`3040665`): copiar la foto encima reintroduce F4–F8.
3. El cuerpo SDEI de LD main `0989a15` ya contiene todo lo de i7infra (`diff -rq` contra `e1g-rep` vacío, cita 11). Ahí no hay nada que recuperar: «base i7infra» rige para el expediente, la Guía 14 y los instrumentos, no para SDEI.
4. GitHub da por perdido lo que i7infra conserva: el 230 (`252:77-78` lo declara vacante), los guiones y salidas de E1-U4b que hoy citan rotos TEM-01:213,217,246, TEM-02:214,217, TEM-03:193,213,221 y Referencias:132 (todas a `E1-U4b`, ninguna a `E1-U4c`, cita 6), las salidas de E-F10/13/14 (`E1-U2/03`, `E1-U2/04`, `E1-U3/13`), el Anexo L6 (`290:264-276`) y el generador del sitio (MkDocs 1.6.1, Material 9.5.44). No conserva, en cambio, las lecciones de la onda 8: `00-Indice.md:57` la deja en «Siguiente», así que `245:300` dice la verdad (cita 14). De los guiones, sólo `01` se reprodujo byte a byte; `02`, `03` y `05` coinciden salvo la línea del commit y `04-adopciones.sh` nunca se volvió a correr (cita 13).
5. Los cortes se contradicen: 245 INSUFICIENTE (fusionado, ratificado por 251 DEC-11) frente a 290 PROCEDE CON RESERVA. El 290 no se sostiene: G-d PASA es falso en su propia base (`dg.py` sobre `git archive fe10086`: `PR-5 traces-resolve: ROJO (errores=2) trazas=12 resueltas=10`, cita 10), G-c es autoprueba local y no par en el runner, G-f mide sólo lo agregado y afirma que #27 lo fusionó la CPA cuando se fusionó a las 08:44 −03 desde hpdev (el 290 tiene mtime 00:47:06 −03).
6. Choques de numeración: 250, 251 y 252 dobles; 260-e1-u4f frente a la reserva del 260 para el Registro de E1-R (`252:93`, `251:98`, `250:297`); 230 «vacante» que existe. Los nombres de archivo no chocan. Ni LD ni LDD citan los nombres de i7infra (cita 17): no renumerar se sostiene por «no reescribir», no por citas.
7. Riesgo vivo (§6.7) que ninguna comisión vio (refutación C3, confirmado por el jurado con `docker ps` de lectura): i7infra volvió con `runner-github-dev`, `-ng` y `-ap25` en pie desde hace 2 horas, los mismos nombres que en hpdev; Verificar de LDD corre en `[self-hosted, i7infra-dev]` y `Reanudar.md:56-58` dice que el runner de hpdev lleva las mismas etiquetas. Cualquier despacho puede caer en i7infra. Además: la sesión DocAsCode de i7infra sigue viva, hubo un fetch ajeno a las 20:21, `docascode-demo` (:8090) lleva 20 horas arriba, hay dos copias de `h.cfg` y 434 archivos sin seguimiento de la Guía 16 en el clon de LD de i7infra.

Conclusión del jurado: i7infra estaba mejor en sustancia (evidencia, ensayos, protocolos, medidas) y peor en el corte. Se rescata su contenido por folios nuevos sin tocar lo fusionado, y el plan de hpdev sigue siendo la columna de E1-R con menos trabajo.


## 7. Decisiones

| Id | Pregunta | Decisión | Fundamento | Al PO |
| --- | --- | --- | --- | --- |
| D01 | ¿Qué base rige para cada pieza? | Expediente: los 90 archivos sólo-i7infra entran desde la foto con su contenido literal y sólo redacción mecánica (K02); los 178 comunes quedan como en GitHub. Cuerpo SDEI: LD main `0989a15` (excepción justificada a «base i7infra»). Guía 14: prompt de main (idéntico); `DocsAsCode-Bitacoras` desde la foto, redactada; `Analista-Dediciones-Bitacoras` y `Analistas-Bitacoras` no se publican. Instrumentos de E1-R/E1-G2 (guiones de E1-U4b/c/d, `e1g/plect`, `yamlcheck.py`, Dockerfile de `demo-site`): los de i7infra. Plan de unidades: `plan-final.json` de hpdev, adaptado por esta acta. | R1 (120 iguales, 58 sólo redacción); R5 §0 (copiar encima reintroduce F4–F8); R3 y cita 11 (`diff -rq` SDEI vacío); R2 §1 (md5 `450d4070…` del prompt igual en las tres copias). Toma P1 D01, que la refutación juzgó la más precisa. | No |
| D02 | ¿Cómo se numeran los folios de i7infra y cómo se resuelven los choques 230/250/251/252/260? | Los 11 folios de i7infra entran con su nombre de archivo original, sin renumerar. Regla de cita desde esta acta: los números 211, 250, 251, 252 y 260 se citan siempre por nombre completo (`250-e1-u4e` frente a `250-acta-mesa-organizacion-y-vuelta-e1`), extendiendo el precedente del 211 doble (`252:79`). El 230 deja de ser vacante: es el original rescatado, no una reutilización. La reserva del 260 para el Registro de E1-R SE MANTIENE (archivo `260-registro-e1r.md`) y convive con `260-e1-u4f` por la misma regla: así no hay que corregir `250:297`, `251:98` ni `252:93`. Numeración nueva: 257 = esta acta; 258 = constancia de rescate (inventario, MANIFIESTO, tabla de folios con nombres completos, el 290 como antecedente sustituido); 259 = corrigenda única (D04); 255 sigue para LDD #33; 261, 262 y 264 quedan libres para la vuelta. | Decisión del PO de hoy: no reescribir historia. Renumerar cambiaría la autoidentificación (frontmatter, H1) de 11 archivos y `00-Indice:148`; el fundamento «rompe citas del 270/290» es falso (cita 17) y se descarta. Mantener el 260 es la alternativa más barata de la refutación C8. `252:97` deja los números entre 250 y 265 para la vuelta. | No |
| D03 | ¿Qué corte de E1 rige y cómo se asienta? | Rige el 245: INSUFICIENTE, una sola vuelta (E1-R y E1-G2, resolución en 265), ratificado por 251 §6 (DEC-11). El 290 entra literal (redactado) como antecedente en el mismo PR que el 257 y el 258, que lo declaran sustituido por cuatro razones: G-d PASA falso en `fe10086` (ROJO 12/10 por `GUIA-INDICE`), G-c apoyado en autoprueba local, G-f parcial y la afirmación de que #27 estaba fusionado por CPA (`290:22,139`), que era anticipada. Lo de #28 «abierto» era cierto a las 00:47 y no se le imputa. Se descarta el argumento del «cuarto resultado» por simétrico (251 §6 también completó 133 §5). El apartamiento del veredicto de i7infra frente al mandato «base i7infra» se avisa al PO en una línea del lote (no se le pregunta: el corte ya está fusionado). | 245 y 249 fusionados; 251 DEC-11; cita 10 (dg.py ROJO sobre `git archive fe10086`, reproducido por el refutador); cita 4 (merges 08:44:10 y 08:52:45 −03 frente al mtime 00:47:06 −03 del 290); refutación C7; regla «apartamientos: avisar al PO». | No |
| D04 | ¿Qué pasa con los folios 240, 245, 249, 250–256 fusionados desde hpdev? | Ninguno se edita; todos siguen vigentes. La carátula `README.md` tampoco se edita (`252:73`, DEC-19): la tabla de folios con nombres completos va en el 258. La corrigenda única 259 corrige por referencia: 240:76-83 y 249:37,53 («perdido» pasa a «no publicado; rescatado el 2026-10-28» para el 230, los folios de U2–U5, E1-U4b/c/d, E-F10/13/14 y el generador); 245 G-a (se agrega la medida de i7infra como antecedente, sin veredicto, ver D05) y causa de G-g (evidencia no publicada, ahora rescatada); 245:300 (§8) sólo en parte: «las bitácoras de las ondas 0–7 existían sin publicar; las lecciones de E1 (onda 8) no se emitieron y las emite U35»; 251 DEC-15 (ver D10); 252 §4 (230 y rango 217–239: los folios de i7infra son los originales, no reutilización; los folios de E1-U2…E1-U5 tienen número); 256 (la cuenta de marcas se rehace cuando U25/U26 cierren). El 255 lo ajusta D06. | Decisión del PO; `252:73` y DEC-19 (la carátula no se edita, `git log -- README.md` da sólo `cc2bfd6`); refutación C1 (cita 14: `00-Indice.md:57` deja la onda 8 en «Siguiente») y C4. Tabla de destinos por folio de P3 D04. | No |
| D05 | ¿Cómo entra G-a con la medida de i7infra? | Como antecedente, no como veredicto. El 259 asienta la hora de nacimiento del 133 (09:37:51 −03) y su sha256 `b148b17e…`, idéntico al versionado, 3 min 9 s antes de `83542ab` (Lab-E2E.WebBlazor #12). La transcripción del agente que lo corrobora es de clase privada y no se publica: queda en el `{resguardo-privado}` citada por sha256. G-a se mide en E1-G2 por U41-MED con los instrumentos de 251 §2 (`%cI` y `created_at`), y su refutador decide si el antecedente suma. | 251 §2 y DEC-10 (`250:212`) ya dejaron G-a como defecto del plan, no P0; 251 §8 asigna la medida a E1-G2; 251 §6.4 (iii) haría P0 a un criterio con evidencia no reproducible; R4:59-61 lo condicionaba. Refutación C2. | No |
| D06 | ¿Qué destino tienen los 4 PR clase H abiertos? | Los cuatro siguen y van al PO en un solo lote. Se ajustan sólo con commits nuevos y merge de main en su rama; nunca rebase ni force-push. LDD #33 (255): commit que corrige la premisa: el tag `docs-guard-v1.0.0` sobre `c0766dc` tiene asiento en `212-e1-u2.md:61,75` (acto de E1-U2) aunque no tiene autorización del PO (N10:222); se hace después del rescate para que la cita resuelva. LDD #32 (`verificar.yml`): commit con la opción (b), el expediente fuera de la matriz de docs-guard, porque si no los archivos rescatados lo ponen en rojo. LD #31 (CI de trazas, `dg.py`): merge de main y nota de conciliación en la descripción, sin tocar la semántica de `dg.py`: la regla `traces-vacio` choca con LD-07 (`218:124`) y con PE-2 (`290:229`, el anexo admite `traces: []`); recomendación al PO: que `traces-vacio` exceptúe el anexo o sea aviso; decide el PO (clase H por `251:98`). LD #32 (`AGENTS.md:54`): opcional, PE-13 ya cerrado por #28; recomendación: fusionar por coherencia. | R5 §1 y `{mesa-i7}/pr-*.json`; `218:125` (LD-08, «integrar main, no rebase»); decisión del PO de no reescribir; refutación P2-1 y P3-2. #28 lo aprobó el PO (`240:142-146`): no se pregunta. | **Sí** |
| D07 | ¿Cómo se preservan los cambios sin commitear en i7infra? | Primero el resguardo, sólo por lectura (ssh) y escritura en el `{resguardo-privado}`: manifiesto sha256 remoto de las carpetas fotografiadas (excluido `h.cfg`) comparado con la foto, y copia de la ia-db v4.0 (README e índices 00, 01, 06, 08, 09, 10) con su manifiesto. La Guía 16 sin seguimiento (434 archivos) NO se copia: se avisa a su línea y al PO, que decide; la limpieza de i7infra espera esa respuesta. Después actúa el PO en i7infra: stash -u o descarte y `pull --ff-only` en LD y LDD. Prompts de la Guía 14 y Guía 06, `PROMPTs/Indexado`, `CHANGELOG` y `Lanzar-Example` ya están en main (R2, R5). | R5 §2 y §3; R3 §5; regla de la mesa (no escribir en i7infra); refutación P3 menor (territorio ajeno de la Guía 16). | **Sí** |
| D08 | ¿Qué se hace con la credencial `h.cfg` (PE-10)? | Acto del PO: rotar el token y borrar las dos copias (i7infra `{dir-de-trabajo}` y la foto en hpdev). Un agente lo asienta sin el valor en el registro 260. Toda copia desde `fc-work-docascode/` excluye sólo `h.cfg` (no la carpeta entera: U40-U42 y K40 necesitan `e1g/plect`, `yamlcheck.py` y `demo-site`). En las bitácoras se neutraliza la mención del tipo de credencial, no su existencia: `00-Indice:110,115,120,147-148`, `13-Onda5:130` y `14-Onda6:101` pasan a «credencial local (PE-10)»; las menciones de existencia de `h.cfg` en 230, 260-e1-u4f, 270 y 290 quedan (PE-10 las permite). | R5 §6 (dos copias, modo 600, 71 bytes, fuera de todo repo); refutación cita 15 (líneas corregidas) y P3 grave 3. | **Sí** |
| D09 | ¿Qué se hace con los runners duplicados (i7infra volvió con los mismos runners que hpdev)? | Va al PO en el lote, en primer lugar: parar o reetiquetar los runners de i7infra (`runner-github-dev`, `-ng`, `-ap25`) antes de cualquier despacho con valor de evidencia (G-b, pares de G-c, medidas de E1-G2). Afecta también a otros repos y organizaciones que usan esos runners. Mientras no responda, las corridas de conformación de los PR de rescate pueden correr, pero toda corrida que se cite como evidencia registra `runner_name` (API `actions/jobs`), y una corrida que haya caído en i7infra no cuenta como evidencia de E1-R. | Refutación C3; confirmado por el jurado: `ssh … docker ps` en i7infra muestra `runner-github-ap25/dev/ng Up 2 hours` y `Runner.Listener` vivo; en hpdev corren contenedores con los mismos nombres; Verificar corre en `[self-hosted, i7infra-dev]`; `Reanudar.md:56-58`. | **Sí** |
| D10 | ¿Se escriben guiones de ensayo nuevos (251 DEC-15) o se usan los originales? | Se usan los originales y se vuelven a correr. El rescate versiona `evidencia/E1-U4b/` (01–05, salidas y P-LECT), `E1-U4c/` y `E1-U4d/` en la ruta que LD ya cita (las nueve citas rotas vuelven a resolver sin editar LD). U25-ENS-LDD se reorienta: corrida nueva de los originales sobre la punta de LD main en hpdev (incluido `04-adopciones.sh`, que nunca se reprodujo, y los de TEM-04…07: `E1-U4c/02-04`, `E1-U4d/02`), con la salida en `evidencia/E1-R/ensayos/` rotulada «guion original, corrida nueva» y cada diferencia con la salida original explicada. U26-ENS-LD se reduce a la exigencia de `251:101`: las cinco marcas `[Compilado]` y las cuatro menciones pasan a URL + SHA del merge. El 259 modifica DEC-15 en ese sentido. | Cita 13 (sólo `01` byte a byte; `04` sin reproducir; es el que citan TEM-01:246, TEM-03:193 y Referencias:132); cita 6; `251:101`; 251 §6.4 (iii). Injerto de P2 U25-ENS-ORIG y U26; refutación P1-4 y P3-4. | No |
| D11 | ¿Cómo se trata lo privado del rescate y cuál es la aceptación del barrido? | `evidencia/local/001` no se publica (Resguardo, citado por sha256). `E1-U0c/02-redact.py` entra en una versión que lee sus patrones privados de un archivo fuera de todo repo (`redact2.py`), para que `230-e1-u0c.md:50` siga resolviendo. `E1-G/05` entra con los tokens S2 enmascarados. Todo lo demás pasa por `redact.py` más la regla nueva (carpeta de trabajo sin prefijo, 35 casos; `{tmp-de-sesiones}`). Aceptación (la de 251 G-f): «0 sin clasificar y 0 reales propias» con las dos partes de `254` (patrón público y lista privada corrida localmente); los falsos positivos ya clasificados por R1 §6 (correos `…@MAYOR.MENOR`, `{…}/wt/`, la descripción del patrón en `E1-G/05`, p4/p10 de las P-LECT) se listan en un archivo de clasificación versionado. Nunca «grep = 0» que obligue a editar contenido literal. El MANIFIESTO del 258 registra dos hashes por archivo (original y publicado). | R1 §6; R4 (G-f); refutación C5 (conteo por archivo sobre los 88 a publicar); 251 §6.4 (i): una fuga del rescate sería P0 de E1-G2. Injerto de P3 U10 (`redact2.py`) y P1 D10. | No |
| D12 | ¿Qué se hace con las bitácoras de la Guía 14 y con `Reanudar.md`? | U35-LECC importa `DocsAsCode-Bitacoras` (00-Indice y 03–15) redactada (`fc-work` → `{dir-de-trabajo}`, D08 para la credencial) y escribe dos entradas nuevas: 16-Onda8-E1-G y 17-Caida-i7infra-E1-R. `OUTPUTs/Reanudar.md` recibe un addendum (no se reescribe) que corrige §2:28 (folios de U2–U5) y §3:59-60 (worktrees y generador rescatados) y señala el riesgo de runners de D09; §1:14 sigue siendo cierto y no se toca. `Analista-Dediciones-Bitacoras` y `Analistas-Bitacoras` no se publican (nombran conocimiento privado y rutas de memoria). El ensayo de `ARTIFACTs/` con dos versiones distintas es zona del PO y de otra línea: sólo se avisa. | R2 §3–§7; `100:40-42` pide la bitácora; refutación C1 y P1 menor (Reanudar §1:14). | No |
| D13 | ¿Qué protocolo de P-LECT y qué umbral de G-e rigen en E1-G2? | El umbral NO cambia: G-e es «cero dudas sin respuesta» (`133:45`) y, para U42, «0 sin respuesta y 0 no alcanzadas» (`250:308`); se descarta el PE-1 del 290 (`290:228`). El protocolo es decisión del PO por DEC-16 (`250:218`): va en el lote como recomendación con default «lector sin contexto identificado, tres lectores con las clases de 012 §6 (protocolo de i7infra) y PR simulado cerrado sin merge». Si el PO no responde antes de U42, rige lo ya aprobado en DEC-16 (un lector identificado, tres clases y PR simulado) y los tres lectores se corren como refuerzo, sin bajar el umbral. | Refutación C6 y P3 grave 1; `133:45`; `250:218`, `250:308`. | **Sí** |
| D14 | ¿Con qué base se mide la regresión ajena en FC (G-d)? | La de DEC-14: ≥ 83/89 en FC, sin regresión ajena. No 88/88. Si FC baja por trabajo de «Cascaron APP», eso es ajeno y va como reserva, no como falla de E1-R. | `250:216` (DEC-14); refutación C9; reglas R1–R8 (territorio de FC). | No |
| D15 | ¿Qué máquina queda como principal y cómo se convive con las otras líneas? | hpdev es la principal de esta línea hasta el 265. i7infra queda de sólo lectura hasta que el PO: cierre las sesiones de VS Code/Claude de i7infra (la de DocAsCode, viva desde las 04:21Z, y la de FC), resuelva los runners (D09), haga `pull --ff-only` tras D07 y el manifiesto esté verificado. Nadie retoma ni escribe en esas sesiones. Rigen R1–R8: clones principales sólo `pull --ff-only`, worktrees en `{worktrees}/rec-*`, un PR de clase P por vez y por repo (coordinado con FC en LD), territorios de FC y de la Guía 16 intactos. U34 (ia-db) arranca sólo si ninguna sesión de Indexado está activa sobre la ia-db. Las unidades conservan los IDs de `plan-final.json` de hpdev cuando adaptan una unidad suya (el 252 §5 fusionado las cita); las nuevas llevan prefijo K. Volver la línea a i7infra lo decide el PO al cerrar E1. | R3 y R5 (clones de i7infra 56 commits atrás, `OUTPUTs/` sin seguimiento, fetch ajeno a las 20:21); memoria de contingencia; refutación P3 grave 5 (choque de IDs). | **Sí** |

Las decisiones con «No» quedan aprobadas por delegación de la mesa. Las de «Sí» van en el lote (K01).


## 8. Corte de E1

Rige el 245: INSUFICIENTE, una sola vuelta (E1-R y luego E1-G2, resuelta en el 265), ratificado por 251 §6 (DEC-11). No cambia.

El 290 de i7infra («PROCEDE CON RESERVA de G-e y AGENTS.md») entra literal y redactado como `290-compuerta-e1.md`, en el mismo PR que el acta 257 y la constancia 258, que lo declaran sustituido porque: su G-d PASA es falso en su propia base `fe10086` (`dg.py`: ROJO 12/10 por `GUIA-INDICE`); su G-c es autoprueba local y no par en el runner; su G-f mide sólo lo agregado; y su afirmación de que #27 estaba fusionado por CPA era anticipada (merge `75043a5` a las 08:44 −03 desde hpdev; el 290 es de las 00:47 −03). No se usa el argumento del «cuarto resultado». El apartamiento frente a «base i7infra» se avisa al PO.

Lo que i7infra aporta entra por la corrigenda 259 como antecedente, sin veredicto: la hora y el hash del 133 para G-a (se mide en U41), la autoprueba de la mini demo para G-c, y la causa de G-g (evidencia no publicada, ya rescatada). El Anexo L6 del 290 §14 es la base del L6 del 265.

Queda para E1-G2: G-a (U41), G-b (despacho sobre `34bdd44` y `60d94f3`), G-c (pares en un runner de hpdev), G-d (`GUIA-INDICE`, FC ≥ 83/89), G-e (P-LECT con 0 sin respuesta y 0 no alcanzadas, protocolo según el PO), G-f (barrido completo, 0 sin clasificar y 0 reales) y G-g (G08, E07 y corrida nueva de los guiones originales con marcas URL+SHA). La entrada a E2 la aprueba el PO.


## 9. Plan por olas

`$E` = `PROMPTs/DEVs/Enchacement/01-Replanteo-Y-Analisis/OUTPUTs/Expedientes/0002-Replanteo-Metodologia-DocAsCode`. Los IDs `U*` son los de `plan-final.json` de la mesa de organización (`250` §8), adaptados; los `K*` son nuevos.


### Ola 0 — resguardo, lote y preparación (sin publicar)

| Id | Unidad | Clase | Repo / rama | Origen | Archivos | Aceptación | Depende |
| --- | --- | --- | --- | --- | --- | --- | --- |
| K00-MANIF | Manifiesto sha256 de i7infra contra la foto y resguardo de la ia-db v4.0 | P (local) | ninguno (`{resguardo-privado}`; i7infra sólo lectura por ssh)<br>`—` | i7infra por ssh de lectura: OUTPUTs del expediente, `PROMPTs/Guides/14-*`, `{dir-de-trabajo}` (sin `h.cfg`) e ia-db v4.0 de LDD | `{resguardo-i7}/MANIFIESTO-remoto.sha256`, `ldd-iadb-v4.0/` y su `MANIFIESTO.sha256` | Para cada carpeta, `diff <(ssh … 'cd <ruta> && find . -type f ! -name h.cfg -print0 \| sort -z \| xargs -0 sha256sum') <(cd <foto>/<carpeta> && find . -type f ! -name h.cfg -print0 \| sort -z \| xargs -0 sha256sum)` vacío. `sha256sum -c ldd-iadb-v4.0/MANIFIESTO.sha256` OK en los 7 archivos (contados con `find -type f`, no `ls`). Ningún `h.cfg` nuevo: `find {resguardo-privado} -name h.cfg -newer <foto>` vacío. | — |
| K01-LOTE | Lote al PO y avisos a las líneas ajenas | H | — (mensaje de la presidencia)<br>`—` | nuevo: D03 (aviso de apartamiento), D06, D07, D08, D09, D13, D15 | `{mesa-i7}/lote-po.md` | El lote trae, en este orden: (1) runners duplicados de i7infra (D09); (2) cerrar las sesiones de i7infra; (3) `h.cfg`: rotar y borrar dos copias; (4) los 4 PR H con su nota (D06); (5) protocolo P-LECT con default (D13); (6) aviso de apartamiento del veredicto del 290; (7) stash y `pull --ff-only` en i7infra, después de la respuesta de la línea de la Guía 16; (8) contenedor `docascode-demo` en :8090; (9) ensayo con dos versiones en `ARTIFACTs/`; (10) qué sesión de Indexado reindexa. Avisos enviados a «Cascaron APP» (`5f1e0b4` y entrada sin commitear del CHANGELOG de FC en i7infra) y a «Documentar AI Layer» (434 archivos de la Guía 16 sin seguimiento en i7infra). Constancia de envío en la bitácora de la mesa. | K00-MANIF |
| K02-REDACT | Redactor extendido (`redact2.py`) y árbol de rescate preparado en worktree, sin publicar | P (local) | hdcm-dev/Lab-Documentos.Documentacion (worktree local, sin push)<br>`exp0002/rescate-i7infra (local)` | foto `ldd-enchacement-01-outputs/` (sólo `only-i7.lst`) y `ldd-guia14/OUTPUTs/DocsAsCode-Bitacoras`; `redact.py` de main y `E1-U0c/02-redact.py` sin copiar sus literales privados | `{mesa-i7}/tools/redact2.py` (patrones privados leídos de un archivo fuera de todo repo); `{worktrees}/rec-ldd/` con 89 archivos del expediente (sin `local/001`) y las bitácoras; `{mesa-i7}/k02/clasificacion-s2.tsv` | `comm -12 <(lista del árbol) gh.lst` vacío (no pisa ningún archivo común). Barrido con las dos partes de `254`: 0 coincidencias sin clasificar y 0 reales propias; cada falso positivo en `clasificacion-s2.tsv` con su clase de R1 §6. `git status --porcelain \| grep -c h.cfg` = 0 (como archivo). `diff` de cada archivo contra la foto: sólo líneas de alias o redacción. `02-redact.py` publicado sin nombres de repos privados ni de la KB privada. | K00-MANIF |

### Ola 1 — rescate y corrigenda

| Id | Unidad | Clase | Repo / rama | Origen | Archivos | Aceptación | Depende |
| --- | --- | --- | --- | --- | --- | --- | --- |
| K10-RESCATE | Rescate en LDD: 11 folios y 78 de evidencia de i7infra, más el acta 257 y la constancia 258, en un solo PR | P | hdcm-dev/Lab-Documentos.Documentacion<br>`exp0002/rescate-i7infra` | i7infra (foto, redactada en K02); 257 = esta acta redactada; 258 nuevo | `$E/actuaciones/{212-e1-u2,213-e1-u3,214-e1-u4a,218-e1-u4b,230-e1-u0c,250-e1-u4e,251-e1-u4d,252-e1-u4c,260-e1-u4f,270-e1-u5,290-compuerta-e1}.md`; `$E/evidencia/{E1-U0b,E1-U2,E1-U3,E1-U4a,E1-U4b,E1-U4c,E1-U4d,E1-U4e,E1-U4f,E1-U5}/**`, `E1-G/01-05` (05 enmascarado), `E1-U0c/02-redact.py` (versión `redact2`); `$E/actuaciones/257-acta-mesa-recuperacion-i7infra.md`; `$E/actuaciones/258-constancia-rescate-i7infra.md` (inventario, tabla de folios con nombres completos, regla de cita, el 290 sustituido, nota sobre `h.cfg` sin valor); `$E/evidencia/rescate-i7infra/{MANIFIESTO.tsv,clasificacion-s2.tsv}`. NO se toca `README.md` de la carátula. | `git diff --name-status origin/main...HEAD` sólo con `A` (cero `M`). Las nueve citas de LD resuelven: `for p in $(git -C <LD> grep -ohE 'evidencia/E1-U4b/[^ )`]+' origin/main \| sort -u); do git ls-tree HEAD $E/$p \| grep -q . \|\| echo FALTA $p; done` no imprime nada. `230-e1-u0c.md:50` resuelve. Barrido: 0 sin clasificar y 0 reales (dos partes de 254). `cita-linea.mjs` sin rotas en 257 y 258. Verificar en verde sobre el SHA del merge, con `runner_name` registrado. Ciclo de conformación automática (merge al SHA, rama borrada). | K02-REDACT |
| K11-CORR | Folio 259: corrigenda única a 240, 245, 249, 251 DEC-15 y :101, 252 §4 y 256 | P | hdcm-dev/Lab-Documentos.Documentacion<br>`exp0002/corrigenda-259` | nuevo, con D04, D05 y D10 y los hechos de R1, R4, R5 y la refutación | `$E/actuaciones/259-corrigenda-rescate-i7infra.md` | Cada corrección cita folio:línea de origen y la ruta rescatada. Sobre `245:300` dice que las ondas 0–7 existían sin publicar y que la onda 8 no se emitió. G-a aparece como antecedente, sin veredicto. `git diff --name-status origin/main...HEAD` = una sola `A`. `cita-linea.mjs` sin rotas. Barrido S2 como en K10. Verificar en verde. | K10-RESCATE |
| K12-H-AJUSTE | Ajuste de los 4 PR H (U11-H-A…U14-H-D de hpdev) con commits nuevos y merge de main | P (ajuste de ramas H; el merge es H) | hdcm-dev/Lab-Documentos.Documentacion (#32, #33) y hdcm-dev/Lab-Documentos (#31, #32)<br>`ramas existentes: exp0002/e1r-h-verificar, -h-ci-trazas, -h-agents, -h-politicas` | PR abiertos de hpdev; `212-e1-u2.md:61,75` y `290:229` de i7infra | LDD #33: `255-propuesta-etiquetas-y-owner.md` (premisa del tag corregida); LDD #32: `verificar.yml` con la opción (b); LD #31: merge de main y nota de conciliación en la descripción del PR (sin cambiar `dg.py`); LD #32: merge de main | `git rev-list --count <cabeza-anterior>..<cabeza-nueva>` ≥ 1 y `git merge-base --is-ancestor <cabeza-anterior> <cabeza-nueva>` = verdadero en las cuatro ramas (nada reescrito). `git show <rama33>:…/255-*.md \| grep -c 212-e1-u2` ≥ 1. En LDD #32, el expediente fuera de la matriz y Verificar en verde. Los cuatro en `mergeable_state: clean` (GET pulls/N). Ninguno se fusiona: esperan al PO. | K10-RESCATE |

### Ola 2 — E1-R

| Id | Unidad | Clase | Repo / rama | Origen | Archivos | Aceptación | Depende |
| --- | --- | --- | --- | --- | --- | --- | --- |
| U20-TRZ | E1-R: `GUIA-INDICE` de los dos índices y H1 de TEM-04, 05 y 06 | P | hdcm-dev/Lab-Documentos<br>`exp0002/e1r-trazas` | plan de hpdev; medida de la refutación (cita 10) | `README.md`, `Guides/README.md`, TEM-04…06 de SDEI | `python3 -I tools/docs-guard/dg.py trazas AGENTS.md README.md Guides/README.md` sobre el merge: `traces-resolve` VERDE, sin `GUIA-INDICE` ambiguo. FC ≥ 83/89 (DEC-14). docs-guard en CI en verde. | K11-CORR |
| U21-TXT-A | E1-R: Marco, TEM-01…03 y 99-Anexos con las dudas del P-LECT de i7infra y la contradicción del ancla | P | hdcm-dev/Lab-Documentos<br>`exp0002/e1r-texto-marco` | LD main + `e1g/plect` (tres rondas) de i7infra + R3 | `00-Marco.md` (ancla de ESC-SDEI-2 en las líneas 85, 108, 129 y 183), TEM-01…03, 99-Anexos | Una sola definición del ancla (`grep -n 'ancla' 00-Marco.md` coherente). Cada duda del P-LECT anotada como resuelta o «por diseño» en `evidencia/E1-R/`. docs-guard en verde. | U20-TRZ |
| U22-TXT-B | E1-R: TEM-04…07, Ejercicios y Lista-De-Verificacion; G08 y E07 | P | hdcm-dev/Lab-Documentos<br>`exp0002/e1r-texto-temas` | plan de hpdev + medida G-g de R4 | TEM-04…07, `Ejercicios.md`, `Lista-De-Verificacion` | Lista VER de 251 §5 aplicada a la rama: G08 y E07 PASA en estos archivos. docs-guard en verde. | U21-TXT-A |
| U23-TXT-C | E1-R: tutorial de la mini demo, Como-Intervenir y README (fila del RRD, `TRABAJO`, «Intervenir») | P | hdcm-dev/Lab-Documentos<br>`exp0002/e1r-texto-tutorial` | plan de hpdev + R3 | README de la mini demo (l. 131, 137 y 286), `_requisitos.md:38`, los dos `Como-Intervenir`, README de SDEI | Una sola autoridad para la fila nueva del RRD. `bash verificar.sh todo` corre sin `TRABAJO` exportado. G08 PASA en el tutorial y en Como-Intervenir. docs-guard en verde. | U22-TXT-B |
| U24-1B | E1-R: fase 1b y delegación en un solo texto | P | hdcm-dev/Lab-Documentos<br>`exp0002/e1r-fase-1b` | plan de hpdev | según `plan-final.json` de hpdev | Según el plan de hpdev; docs-guard en verde. | U23-TXT-C, K01-LOTE |
| U25-ENS-LDD | E1-R: corrida nueva de los guiones originales (E1-U4b 01–05, E1-U4c 02–04, E1-U4d 02) sobre la punta de LD main | P | hdcm-dev/Lab-Documentos.Documentacion<br>`exp0002/e1r-ensayos` | i7infra (guiones rescatados en K10); reorienta U25 de hpdev | `$E/evidencia/E1-R/ensayos/TEM-0n/`: salida, SHA de LD y rótulo «guion original de E1-U4x, corrida nueva el AAAA-MM-DD en hpdev» | Cada guion termina con exit 0, incluido `04-adopciones.sh`. `diff` contra la salida original: cada diferencia explicada por el avance de main. Al menos un ensayo por TEM-01…07. Las salidas originales quedan intactas. | K11-CORR, U23-TXT-C |
| U26-ENS-LD | E1-R: marcas `[Compilado]` a URL + SHA del merge (exigencia de 251:101) | P | hdcm-dev/Lab-Documentos<br>`exp0002/e1r-remisiones-ensayo` | plan de hpdev, reducido | las cinco marcas y las cuatro menciones en prosa que cuenta 256 §2 | `git grep -n '\[Compilado' origin/main -- <SDEI>`: 0, o cada marca con URL y SHA que resuelven. Las citas a `evidencia/E1-U4b/` resuelven (K10). docs-guard en verde. | U25-ENS-LDD, U22-TXT-B |
| U29-RV | Pares rojo/verde en el runner para los controles bloqueantes de 251 G-c | P | hdcm-dev/Lab-Documentos y hdcm-dev/Lab-Documentos.Documentacion<br>`exp0002/e1r-rojo-*` | plan de hpdev; la autoprueba de i7infra (`E1-G/02`) sólo como antecedente | ramas `exp0002/e1r-rojo-*` que no se fusionan, ancladas en `refs/resguardo/*` | Por cada control, una corrida roja y una verde con URL, SHA y `runner_name` de un runner de hpdev (API `actions/jobs`). Ninguna corrida de evidencia en i7infra. | K11-CORR, K01-LOTE |
| U30-GB | G-b: despacho de Verificar sobre `34bdd44` y `60d94f3` | P | hdcm-dev/Lab-Documentos.Documentacion (refs)<br>`exp0002/e1r-gb-u0b, exp0002/e1r-gb-u0c` | plan de hpdev | refs efímeras `exp0002/e1r-gb-u0b` y `-u0c` | API de runs: Verificar con `head_sha` igual a cada SHA, `conclusion` registrada y `runner_name` de hpdev. | K11-CORR, K01-LOTE |
| U31-MED | Medidas que faltan: E-F4 y fuentes primarias (E-F10, E-F13 y E-F14 vienen del rescate) | P | hdcm-dev/Lab-Documentos.Documentacion<br>`exp0002/e1r-medidas` | plan de hpdev, reducido; `E1-U2/03`, `E1-U2/04`, `E1-U3/13` rescatados | `$E/evidencia/E1-R/medidas/` | Cada E-F con salida, comando, SHA y fecha; las tres rescatadas citadas por ruta. `cita-linea.mjs` sin rotas. | K10-RESCATE, U23-TXT-C |

### Ola 3 — registro, CHANGELOG, ia-db y lecciones

| Id | Unidad | Clase | Repo / rama | Origen | Archivos | Aceptación | Depende |
| --- | --- | --- | --- | --- | --- | --- | --- |
| U32-REG | Registro de E1-R (folio 260, `260-registro-e1r.md`) | P | hdcm-dev/Lab-Documentos.Documentacion<br>`exp0002/e1r-registro` | plan de hpdev, número sin cambio | `$E/actuaciones/260-registro-e1r.md` y `evidencia/E1-R/` | Cita PR → merge SHA → corrida (URL, `runner_name`) de cada unidad de la ola 2 y las respuestas del PO al lote, incluido el asiento de `h.cfg` sin valor. `git merge-base --is-ancestor` verdadero para cada merge. Cita el `260-e1-u4f` por nombre completo. | U20-TRZ, U21-TXT-A, U22-TXT-B, U23-TXT-C, U24-1B, U26-ENS-LD, U29-RV, U30-GB, U31-MED |
| U33-CHLOG | CHANGELOG único de la vuelta por repo | P | hdcm-dev/Lab-Documentos y hdcm-dev/Lab-Documentos.Documentacion<br>`exp0002/e1r-changelog` | plan de hpdev | `CHANGELOG.md` de cada repo | Una entrada por merge de E1-R y del rescate; FC intacto. | U32-REG |
| U34-IADB | ia-db v4.2 sobre la punta de LD | P | hdcm-dev/Lab-Documentos.Documentacion<br>`exp0002/e1r-iadb` | plan de hpdev; cita la v4.0 resguardada en K00 | ia-db de LDD | Ninguna sesión de Indexado activa sobre la ia-db (ListAgents y respuesta del PO al lote). Los índices apuntan al SHA de la punta de LD. Verificar en verde. | U32-REG, K01-LOTE |
| U35-LECC | Bitácoras DocsAsCode de la Guía 14 desde i7infra, Onda 8 y Caída, y addendum a `Reanudar.md` | P | hdcm-dev/Lab-Documentos.Documentacion<br>`exp0002/e1r-lecciones` | i7infra: `ldd-guia14/OUTPUTs/DocsAsCode-Bitacoras` (00 y 03–15) redactado en K02; nuevas 16-Onda8-E1-G y 17-Caida-i7infra-E1-R | `PROMPTs/Guides/14-Sistema-De-Documentador-Tecnico/OUTPUTs/DocsAsCode-Bitacoras/**` y addendum en `OUTPUTs/Reanudar.md` | 16 archivos en `DocsAsCode-Bitacoras/`. `grep -rn 'fc-work\\|token de GitHub\\|en texto plano'` = 0; las menciones de existencia de `h.cfg` quedan. Barrido S2 como en K10. No entran `Analista*`, `ARTIFACTs/` ni el prompt. `git diff --name-only` sin nada fuera de la Guía 14. | K10-RESCATE |

### Ola 4 — E1-G2

| Id | Unidad | Clase | Repo / rama | Origen | Archivos | Aceptación | Depende |
| --- | --- | --- | --- | --- | --- | --- | --- |
| U40-SWEEP | E1-G2: barrido S2 de los tres repos públicos sobre la punta de main | P | LDD (versionado); LD y Lab-E2E.WebBlazor sólo lectura<br>`exp0002/e1g2-barrido` | plan de hpdev | `$E/evidencia/E1-G2/barrido/` | 0 sin clasificar, 0 reales propias; lo ajeno con dueño (dos partes de 254). Incluye los archivos rescatados. | U32-REG, U33-CHLOG, U34-IADB, U35-LECC |
| U41-MED | E1-G2: medición de G-a…G-g con verificador y refutador por criterio | P | hdcm-dev/Lab-Documentos.Documentacion<br>`exp0002/e1g2-medidas` | plan de hpdev; antecedentes de i7infra: G-a (259), autoprueba de la mini demo (G-c), `yamlcheck.py` (G-g YAML) | `$E/evidencia/E1-G2/medidas/` | Instrumentos de 251; G-a por `%cI` y `created_at`, con el antecedente de i7infra evaluado por el refutador. G-d: `dg.py` VERDE y FC ≥ 83/89. Una ficha por criterio con comando, SHA y veredicto. | U40-SWEEP |
| U42-PLECT | E1-G2: P-LECT nuevo con PR simulado, según la respuesta del PO (D13) | P | hdcm-dev/Lab-Documentos (PR simulado) y hdcm-dev/Lab-Documentos.Documentacion (acta)<br>`exp0002/e1g2-plect-pr-simulado, exp0002/e1g2-plect-acta` | plan de hpdev; protocolo de tres lectores de i7infra si el PO lo aprueba | PR en borrador «NO FUSIONAR» (se cierra) y `$E/evidencia/E1-G2/plect/` | 0 dudas sin respuesta y 0 no alcanzadas (`133:45`, `250:308`). PR simulado cerrado sin merge. Lectores identificados. | U32-REG, K01-LOTE |
| K40-SITIO | Sitio de demostración regenerado desde LD main con el generador fijado de i7infra | P | ninguno (evidencia en LDD)<br>`—` | i7infra: Dockerfile de `e1g/demo-site` (MkDocs 1.6.1, Material 9.5.44, pymdown 10.12), con `src` = punta de LD main | sitio local en `{worktrees}/` (fuera del repo); `$E/evidencia/E1-G2/sitio-estado.md` | `docker build` y `run` en hpdev; `curl -s -o /dev/null -w '%{http_code}'` a `index.html`, `estado.html` y `raw/AGENTS.txt` → 200; `estado.md` cita el SHA de main. | U32-REG |
| U43-RES | Mesa B (263) y resolución de E1-G2 (265) con Anexo L6 tomado del 290 §14 | presidencia | hdcm-dev/Lab-Documentos.Documentacion<br>`exp0002/e1g2-resolucion` | plan de hpdev; `290:264-276` de i7infra como base del L6 | `$E/actuaciones/263-*.md`, `265-resolucion-e1g2.md` | Resultado por criterio dentro de los previstos por 133 §5 y 251 §6; L6 completo (A-1…A-6); `cita-linea.mjs` sin rotas; Verificar en verde. Lo H pendiente va como reserva y no cuenta como falla (251 §6.5). | U41-MED, U42-PLECT, K40-SITIO |

### Ola 5 — cierre

| Id | Unidad | Clase | Repo / rama | Origen | Archivos | Aceptación | Depende |
| --- | --- | --- | --- | --- | --- | --- | --- |
| U44-CIERRE | Cierre: worktrees, ramas e inventario del `{resguardo-privado}` | D | LD y LDD (local)<br>`—` | plan de hpdev | `{worktrees}/*`, ramas `exp0002/*`, inventario del `{resguardo-privado}` | `git worktree list` sin `rec-*` ni `exp0002`; `git fetch --prune && git branch -r \| grep exp0002` sólo con ramas H abiertas o rescates en `refs/resguardo/*`; MANIFIESTO del `{resguardo-privado}` OK. | U43-RES |
| K50-I7 | Actos del PO en i7infra y vuelta de la línea | H | i7infra (actos del PO) y LDD (asiento)<br>`—` | D07, D08, D09, D15 | asiento en el folio siguiente libre | El PO confirma la rotación del token; `test ! -e` en las dos rutas de `h.cfg`. Por ssh de lectura, después del acto del PO: `git -C <LD> status --porcelain` y `git -C <LDD> status --porcelain` sin nada de 0002 y HEAD = origin/main en los dos. Runners de i7infra parados o reetiquetados. Decisión del PO sobre la máquina principal y la entrada a E2, asentada. | U43-RES, K01-LOTE |

Numeración: `255` LDD #33 (H); `257` esta acta; `258` constancia de rescate; `259` corrigenda única; `260-registro-e1r` (U32), que convive con `260-e1-u4f`; `263` y `265` (U43). Libres: `261`, `262`, `264`.


## 10. Lo de hpdev

Todo lo fusionado hoy desde hpdev queda vigente y no se reescribe: LD #26–#30 y #33; LDD #23–#31 (folios 240, 245, 249, 250–254 y 256, `evidencia/E1-G/G-*`, `S2-patron`). Su redacción (F1–F8, alias) gana sobre la foto en los 178 archivos comunes. `E1-G/G-*` convive con `E1-G/01-05` de i7infra sin choque de nombres. La carátula no se edita.

Se corrige sólo por folios nuevos: el 258 da la tabla de folios con nombres completos y sustituye al 290; el 259 corrige 240:76-83, 245 (G-a como antecedente, causa de G-g y §8:300 en parte: la onda 8 no se emitió), 249:37,53, 251 DEC-15 y :101, 252 §4 (230 y rango 217–239) y 256. La reserva del 260 para el Registro de E1-R se mantiene: no hay que corregir 250:297, 251:98 ni 252:93.

Los 4 PR H siguen abiertos; se ajustan con commits nuevos y merge de main (nunca rebase) y van al PO en un lote.

`plan-final.json` de hpdev sigue siendo la columna de E1-R, con sus IDs: cumplidas U00, U01, U03, U10, U27 y U28; U02 se reemplaza por K01-LOTE; U11–U14 pasan por K12; U25 se reorienta a corrida nueva de los originales; U26 se reduce a las marcas URL+SHA; U31 se recorta a E-F4 y fuentes primarias; U29/U30 registran `runner_name` y esperan la decisión de runners; U35 importa las bitácoras de i7infra; U42 sigue el protocolo que decida el PO sin bajar el umbral; U43 parte del L6 del 290; se agregan K00, K02, K10, K11, K40 y K50. El `{resguardo-privado}` () se conserva entero; hpdev queda como principal hasta el 265.


## 11. Lo que sale al PO

Un solo lote (K01), en este orden:

1. **Runners de i7infra** (D09): pararlos o reetiquetarlos antes de cualquier despacho con valor de evidencia. Afecta también a otros repos que usan esos runners.
2. **Sesiones de i7infra** (D15): cerrar la de DocAsCode y la de FC; nadie las retoma.
3. **`h.cfg`** (D08): rotar el token y borrar las dos copias.
4. **Los 4 PR H** (D06), ya ajustados sin reescribir: LDD #33 con la premisa del tag corregida; LDD #32 con la opción (b); LD #31 con la conciliación con LD-07 y PE-2 como recomendación; LD #32 opcional.
5. **Protocolo de P-LECT** (D13), con default; el umbral no cambia.
6. **Aviso de apartamiento** (D03): el veredicto del 290 no rige pese a «base i7infra»; si el PO lo quiere, va por un folio nuevo de resolución.
7. **Limpieza de i7infra** (D07): stash y `pull --ff-only`, después de que la línea de la Guía 16 responda.
8. **Contenedor `docascode-demo`** en :8090 de i7infra: pararlo o mantenerlo.
9. **Ensayo de `ARTIFACTs/` con dos versiones**: zona del PO y de otra línea.
10. **Indexado**: qué sesión reindexa antes de U34.
11. **Máquina principal y entrada a E2** (D15, K50): al cerrar E1.

Avisos a las otras líneas: a «Cascaron APP» por `5f1e0b4` y la entrada sin commitear del CHANGELOG de FC en i7infra; a «Documentar AI Layer» por los 434 archivos sin seguimiento de la Guía 16 en i7infra.


## 12. Riesgos

1. Runners duplicados: i7infra volvió con `runner-github-dev/-ng/-ap25` con los mismos nombres y etiquetas que hpdev; cualquier despacho (de esta línea y de otros repos) puede caer en i7infra y volver ambigua la evidencia. Mitigación: primer punto del lote (D09); `runner_name` en toda corrida citada; ninguna corrida de evidencia en i7infra.
2. Fuga en repo público con el rescate: 35 casos de la carpeta de trabajo sin prefijo, `{tmp-de-sesiones}`, nombres privados en `02-redact.py`, tokens S2 en `E1-G/05`. Una fuga sería P0 (i) de E1-G2 y daría NO_PROCEDE sin tercera vuelta. Mitigación: K02 antes de todo push, aceptación «0 sin clasificar y 0 reales» con las dos partes de 254, `local/001` sólo en el `{resguardo-privado}`.
3. Reintroducir F4–F8 si se copia la foto entera. Mitigación: sólo `only-i7.lst`; `comm -12` contra `gh.lst` vacío y `git diff --name-status` sólo con `A`.
4. Lectura equivocada del veredicto: el 290 dice PROCEDE CON RESERVA. Mitigación: el 257 y el 258 en el mismo PR que el 290, sin ventana.
5. Citas ambiguas por números dobles (211, 250, 251, 252, 260). Mitigación: regla de cita por nombre completo en el 257/258 y control en `cita-linea.mjs` para esos números en folios nuevos.
6. La sesión DocAsCode de i7infra, viva, o un agente que la retome, escribe sobre clones 56 commits atrás. Mitigación: el PO la cierra (K01); nadie la retoma (D15).
7. Pérdida de trabajo ajeno sin commitear en i7infra (Guía 16, ia-db v4.0, ensayo de ARTIFACTs, entrada del CHANGELOG de FC) si se limpia antes. Mitigación: K00 copia la ia-db; avisos a las líneas dueñas; la limpieza espera sus respuestas.
8. Credencial `h.cfg` en dos máquinas hasta que el PO la rote. Mitigación: exclusión explícita en toda copia y `git status` sin `h.cfg` antes de cada commit.
9. Corrida nueva de los guiones originales distinta de la salida original por el avance de main (y `04-adopciones.sh` nunca reproducido): puede leerse como regresión. Mitigación: conservar la salida original intacta y explicar cada diferencia (U25).
10. Carrera con «Cascaron APP» al fusionar en LD y con las sesiones de Indexado sobre la ia-db. Mitigación: un PR P por vez por repo, coordinado; U34 sólo sin Indexado activo; G-d con la base de DEC-14 (≥ 83/89) para no atar E1-R al trabajo de FC.
11. LDD #32 fusionado sin la opción (b) pone Verificar en rojo con los archivos rescatados y frena la conformación automática. Mitigación: K12 antes del lote y orden explicado al PO.
12. El PO puede preferir el corte del 290 (pidió «base i7infra»). Mitigación: aviso explícito del apartamiento; si lo pide, va por un folio nuevo de resolución, nunca editando 245.

## 13. Pase

A la presidencia, para: enviar el lote K01; ejecutar la ola 0; versionar esta acta como `257` (redactada con los alias del README del expediente) en el PR de K10, junto con el `258`.

