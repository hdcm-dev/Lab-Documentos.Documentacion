---
doc_id: BIT-16-MESA-C3-07
doc_type: aplicacion-y-verificacion
title: Ciclo 3 · Aplicación literal y verificación (M§4.6)
version: v1
status: cerrado
origin: agent (secretaría de la mesa)
last_review: 2026-10-26
traces: [BIT-16-MESA-C3-05, BIT-16-MESA-C3-06, BIT-16-04 v3, BIT-16-02, BIT-16-03, Compuertas/]
---

# Ciclo 3 · Aplicación y verificación

## 1. Cómo se aplicó

1. La v2 se copió **antes** de aplicar a `../../04-Plan-De-Integracion.v2.md` (1236 líneas, idéntica a la v2).
2. Cada «reemplaza … por …» de `05-Parches.md` se aplicó con un script que **exige exactamente una ocurrencia** del texto viejo y, si no la encuentra, falla sin escribir. Los párrafos largos se ubicaron por su comienzo y su final, en la misma línea. Hubo 159 operaciones y 0 fallas. El script vive en el scratchpad de la sesión, fuera del repo.
3. La única operación fuera del orden de §0.4 es el prefijo «plan §» de las remisiones de las fichas (PAR3-03 ítem 2). Va al final para no romper los textos viejos que citaban «§E.2» sin prefijo. Se prefijaron 31 remisiones, no las 33 que mide la v2, porque otros parches ya habían reemplazado dos con su texto nuevo. Después de aplicar, la compuerta da 0.
4. No hubo **ajustes propios**: el texto que se aplicó es el de los parches. Las tres excepciones son mecánicas y se declaran:
   - (a) «clases provisionales» de §E.5 (l. 697 de la v2) se reescribió como «clases, a medir en DEP-13», como manda PAR3-20 en sus derivados.
   - (b) En la tabla nueva de clases del Ollama propio, «Provisionales hasta DEP-03» se escribió «A medir en DEP-03», con el mismo motivo.
   - (c) En la consolidación, una frase de `desarrollo.md` decía, después de redactar los nombres por roles, «el propio está en la máquina del Ollama propio». Se reescribió como «la máquina del Ollama propio aloja además» para que no quede tautológica.
5. Resultado: `04-Plan-De-Integracion.md` **v3** tiene 1329 líneas; §H pasa a la l. 1053.

## 2. Verificación por parche

| Parche | Verificación del parche | Resultado |
|---|---|---|
| PAR3-01 | `grep -c '^\| OA'` = 27; sin «pendiente de voto»; «subsecciones de contexto» = 0 | **pasa** (27; 0; 0). `tools/inclusion.sh` no existe todavía: se verifica en la construcción |
| PAR3-02 | «Agente por código» sin `\| 3 \|`; `eliminar_localidad(id)` antes de §H = 0 | **pasa** (0; 0) |
| PAR3-03 | regex de familias: 10/10 positivos y 0/11 negativos con `/usr/bin/grep`; sin «re-vota en este ciclo» ni la lista de líneas; remisiones sin prefijo = 0 | **pasa** (corrido sobre `Compuertas/familias-id.{positivos,negativos}`, archivos nuevos) |
| PAR3-04 | fichas sin PD-7, R-07, R-04 ni «Escalón 3** — §8.7»; «contexto de uso» ≥ 3 en §C | **pasa en sustancia**: el grep da 3 y son falsos positivos de su propio patrón («ADR-07» y «ADR-04» contienen «R-07» y «R-04»). Ningún PD-7 ni R-0n suelto. «Contexto de uso»: 6 |
| PAR3-05 | §10.6 sin «N3 E5);»; sin «Papeleta de RV-01»; §13.14 sin «DEP-12).»; la tríada en §14 y §F.1 | **pasa** (0; 0; 0; 2) |
| PAR3-06 | «25 o 26 OA» = 0; PR-3 nombra 06 y 11 | **pasa** |
| PAR3-07 | §E.1 sin `<ollama>`, `ollama pull` ni `<red-del-arnés>`; sin «sometido a P-12»; sin direcciones | **pasa** (0; 0; barrido de IP = 0) |
| PAR3-08 | «reglamento-sintetico\|localidad ficticia\|89959» = 0; dificultad 08 = B, 16 = I, 17 = A | **pasa en §E.2** (B, I, A). Queda **1** ocurrencia en §G.4, en la columna «pregunta» de la fila P-12, que PAR3-16 no reescribe (sólo reemplaza la celda de propuesta). Va a deuda y no se revierte: es la pregunta histórica, y la decisión de la fila dice lo contrario |
| PAR3-09 | «DEP-10 sale bien» = 0 | **pasa** |
| PAR3-10 | sumas fila por fila: 7.650 / 6.720 dentro del tope / 5.275; sin papeletas; humos = §F.1 | **pasa**: el script da TURNO-1 = 48 llamadas y 7.650 s; TURNO-2 = 71 y 10.720 s (con la regla de cola entran 6.720 s); TURNO-3 = ≤ 158 y 5.275 s. Los humos de TURNO-1 (PD-2, PD-3, PD-6) coinciden con la columna «Humo con modelo = sí» de §F.1 y con AC-3b |
| PAR3-11 | §E.6 sin `<ollama>` ni `<red-del-arnés>` | **pasa** |
| PAR3-12 | PD-7 antes de §H = 0, también en 02 §6 y 03; sin «cinco escenarios con siete pasos»; humo ↔ §E.5 ↔ AC-3b | **pasa en sustancia**: en 02 y 03 da 0. En el plan quedan **5 líneas antes de §H**, todas escritas por los parches para enunciar el retiro («PD-7 sale», «PD-7 salió», la fila de compensación de PAR3-03, la fila 13 de §E.2 y la respuesta de P-03). No queda ninguna referencia viva a PD-7 como paso. Es una contradicción entre el texto de los parches y su propia verificación, y se registra; no se revierte |
| PAR3-13 | §F.2–§F.5 sin `MapMcp("/mcp")` ni `demo-mcp`; `eliminar_localidad(id)` = 0 | **pasa** (0; 0) |
| PAR3-14 | §F.6–§F.9 sin `http://ollama-embed:11434`, PD-1…PD-7 ni `Mcp_HostYOrigenAjenos_Rechaza` | **pasa** |
| PAR3-15 | PCRE 3 aciertos y 0 en «coincidente»; patrón 100.64/10; AC-7 con lista vacía sale con error | **pasa en lo verificable**. PCRE: `rd-po-4.negativos` (nuevo) = 0 y `rd-po-4.positivos` = 4/5 con el patrón 1; la quinta línea es un nombre de otro proyecto y depende de `$RD_PO_LISTA` (DEP-16). El patrón 100.64/10 se probó en el ciclo 3 (§0.3 de 05) y está en AC-7. El script de AC-7 no existe todavía: su «falla cerrada» se verifica en la construcción. Barrido RD-PO-4 sobre la bitácora sin Ciclo-3 ni Compuertas: 55 → 53 líneas con el patrón nuevo (05 preveía 56 → 54: la base de hoy tiene una línea menos; la diferencia, −2, coincide) |
| PAR3-16 | sin «aborta («TTL»», «X-002 en re-votación» ni «CTX-EXIST/»; DEP-16 en §G.3 y en AC-7/AC-8 | **pasa** (0; 0; 0; DEP-16 en l. 977, 978 y 1031) |
| PAR3-17 | CTX-EXISTENTE ≥ 3 en 03; CTX-EXIST suelto = 0; columna sin celdas vacías | **pasa** (4; 0; 7 filas con 7 campos) |
| PAR3-18 | §6 de 02 sin PD-7 ni «pendiente de la presidencia» | **pasa** (0) |
| PAR3-19 | conteo con la lista de la secretaría = 0 en los tres archivos y en `OUTPUTs/` | **pasa**: antes eran 1, 5 y 3 líneas; después, 0 en todo `OUTPUTs/`. La lista vive fuera del repo y no se imprime |
| PAR3-20 | `awk 'NR<1010'` sin «provisional\|re-votaci\|papeleta de»; existe la v2 con 1236 líneas | **pasa en sustancia**: la v2 existe con 1236 líneas. En el cuerpo (antes de §H) queda **1** coincidencia, en el encabezado que escribe el propio PAR3-20 («régimen provisional … ninguna decisión de este plan es provisional»). Es autorreferencial y no hay ninguna decisión provisional |

**Revertidos: 0.** Ningún parche produjo una regresión: las cuatro «pasa en sustancia» son falsos positivos de la verificación misma (patrón sin borde de palabra, o texto del propio parche) o residuos fuera del alcance de los parches. Van a deuda en `08-Cierre.md`.

## 3. Capa de compuertas

| Archivo | Cambio |
|---|---|
| `Compuertas/familias-id.positivos` | nuevo (10 líneas: PAR3-03) |
| `Compuertas/familias-id.negativos` | nuevo (11 líneas: PAR3-03) |
| `Compuertas/rd-po-4.negativos` | nuevo (3 líneas: PAR3-15) |
| `Compuertas/rd-po-4.excepciones` | se borró la l. 25 (adjetivo «coincidente»), **después** de comprobar que el patrón nuevo no la marca (objeción de riesgo); las líneas del plan pasaron a la v3 (AC-8 l. 978, R-06 l. 1008); se sumaron la copia v2 (l. 26, 937, 966) y cuatro citas del patrón en el ciclo 3 (`Ciclo-3/02-Informes/qa.md` l. 27 y 29; `Ciclo-3/05-Parches.md` l. 56 y 466). Las líneas restantes sin excepción son sólo los seis archivos pendientes de R-06 |

## 4. Chequeos mecánicos finales

| Chequeo | Resultado |
|---|---|
| Ninguna decisión provisional sin resolver | Las siete papeletas del ciclo 2 y las tres del ciclo 3 quedaron decididas en el plan con su conteo; en el cuerpo no queda ninguna «papeleta de». Lo no resuelto va a la deuda declarada (§14.6 del plan, changelog del ciclo 3, `08-Cierre.md`) |
| Trazabilidad S-xx/I-xx → sección/ejemplo | BIT-16-02 §6: 31 filas S-, I- y Q, sin celdas vacías; S-03, S-05, Q6 e I-05 §5.2 actualizadas |
| Toda sección con fuente y escenario o contexto de uso N0 | Las 16 fichas de §C tienen «Fuente» y «Escenarios» (la Parte 0, en la misma línea); §14 declara CTX-EXISTENTE × CTX-LOCAL × CTX-PROTO |
| Todo ejemplo y paso de demo con criterio de prueba | Las 17 filas de §E.2 tienen oráculo y prueba sin servidor. Los 6 pasos de §F.1 tienen ejemplo hermano y columna «Humo con modelo»; los 3 «no» cierran con prueba de cableado |
| Términos canónicos | «contexto de uso» frente a *contexto* (Anexo C); CTX-EXIST suelto = 0 en 02, 03 y 04; «nivel A/B» = 0; EMB-A/B/C; la dificultad se escribe con palabras en la guía (P3-07) |
| Barrido RD-PO (AC-8, patrón nuevo) | Bitácora completa: sólo excepciones listadas y los seis archivos pendientes de R-06 (Sondeo, N2, N4, N4-Evidencia, N5, informe QA del ciclo 1) |
| Barrido R-PRIV, **después del último archivo escrito** (incluye este y `08`, `05-Cierre`, README y 02) | Lista de la secretaría: 0 en `OUTPUTs/`. Patrones de IP privada y 100.64/10: 0 reales (dos falsos positivos conocidos, números de versión, y una cita del rango 100.64/10 en `operacion.md`, que es un rango y no una dirección) |
