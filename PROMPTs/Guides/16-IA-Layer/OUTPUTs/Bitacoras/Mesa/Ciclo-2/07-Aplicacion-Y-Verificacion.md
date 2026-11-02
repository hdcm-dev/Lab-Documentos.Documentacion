---
doc_id: BIT-16-MESA-C2-07
doc_type: aplicacion-y-verificacion
title: Ciclo 2 · Aplicación de los parches y verificación (M§5.6)
version: v1
status: cerrado
origin: agent (secretaría; aplica lo aprobado, no agrega decisiones)
last_review: 2026-10-26
traces: [BIT-16-MESA-C2-05, BIT-16-MESA-C2-06, BIT-16-04 v1, BIT-16-04 v2, M§5.1, M§5.6]
---

# Ciclo 2 · Aplicación y verificación

## 1. Qué se hizo

1. **Copia de la v1**: `../../04-Plan-De-Integracion.v1.md`, idéntica a la v1 aprobada (SHA-256 `e11066b5c15c9099672546b48e4a6fa8e15154aa6fd080590fe1bd899c4f0754` en los dos archivos antes de aplicar).
2. **Aplicación** de los 27 parches aprobados, en el orden de `05-Parches.md` §0.3 (alcance y nombres → convenciones y ejemplos → demo → estructura de la guía → riesgos y registro → otras capas → ratificaciones). El texto nuevo se tomó **literal** de los bloques y tablas de `05-Parches.md` con un script de sólo reemplazo exacto, que falla si el texto viejo no aparece exactamente una vez. Hubo dos tropiezos del script, corregidos antes de guardar (una fila de tabla que no se insertó y tres filas DEP-09, DEP-10 y DEP-13 que también aparecen en la tabla de TURNO-1 de §E.5); ninguno llegó al archivo.
3. **Capas fuera del plan**: `../../02-Cohesion-Global.md` §6 (PAR2-23), `../Ciclo-1/05-Parches.md` l. 14 y §Cobertura (PAR2-24), `../../Nucleos/N6-Caso-Movilidad-Urbana.md` l. 504 (PAR2-26). PAR2-25 es un pedido al dueño del gestor de recursos de la raíz del workspace: **la mesa no escribió nada fuera de `OUTPUTs/`** (R-ESCR).
4. **Resultado**: `../../04-Plan-De-Integracion.md` pasa a **ESTRUCTURA APROBADA v2** (encabezado v2, 2026-10-26, ciclo 2), con la fila v2 en §H, la tabla «Re-votos del ciclo 2 sobre el ciclo 1» y el **changelog del ciclo 2** (89 filas: ítem → veredicto → parche → verificación) al final.
5. **Ningún parche se revirtió**: ninguna verificación mostró una regresión.

## 2. Cómo se aplicó cada parche

Sin ajustes propios de la secretaría. Donde la redacción del parche admitía más de una lectura, se eligió la literal y se dice acá:

| Parche | Nota de aplicación |
|---|---|
| PAR2-01 | §E.5 reemplazada entera por el bloque del parche; la nota de §12.7 se agregó al final del paso de Aspire |
| PAR2-02 | Cambio 2 (EMB-A/B/C) aplicado en los lugares que nombra el parche y en R-02 («El plan B» → «EMB-B»), que no estaba en la lista pero lo exige la verificación (2) del propio parche (`plan (A\|B\|C)` = 0). La columna «Turno» de §E.2 toma los valores de §E.5; donde un ejemplo tiene dos turnos se escriben los dos (03, 04, 08 con extensión en TURNO-2; 07 y 16 con embeddings en TURNO-3) |
| PAR2-05 | Tabla de variables reemplazada entera |
| PAR2-07 | Las «tres filas» del parche son dos filas de tabla con dos paquetes cada una; se insertaron después de la fila de NUnit |
| PAR2-09 | Celda por celda, con las variantes con nombre de PAR2-02 (05: con-prefijo y sin-prefijo, también en «Entradas»; 16: origen, aprobación, aprobación+marcado) |
| PAR2-11 | El agregado de §F.1 va como párrafo propio a continuación del de alcance |
| PAR2-15 | Régimen provisional del parche: tabla v1 + OA-A5 (26 filas) y §11.2 sumada a OA-S2; la papeleta de RV-05 queda escrita en §A.3 |
| PAR2-17 | El párrafo de compensación de palabras, que en el parche sigue al bloque del presupuesto, entró al plan con sus cifras (objetadas por J3, `06-Aprobacion.md` §2.5) |
| PAR2-18 | §13 propósito: se agregó «(ADR-01…ADR-13)», porque el propósito no traía la lista; la papeleta de RV-01 quedó en §15; las notas «AJ-05» se borraron en §1, §2, §4, §10, §12 y §13 |
| PAR2-21 | DEP-01 sólo cambió «plan A» por «EMB-A», como dice la fila; DEP-11 conserva su descripción («sin cambio en el contenido») y cambia sólo «Bloquea» |
| PAR2-22 | La fecha de la fila v2 es la de aplicación, 2026-10-26 |
| PAR2-24 | Aplicado como lo aprobó la mayoría (reemplazo y nota); la fe de erratas que pedía la minoría queda como deuda |

## 3. Verificación por parche

| Parche | Resultado |
|---|---|
| PAR2-01 | **pasa**. `awk` sobre las tablas: TURNO-1 = 17 filas, 58 llamadas, 12.400 s (3,44 h); TURNO-2 = 8 filas, 134 llamadas, 19.280 s (5,36 h). «AJ-03» sólo en «reemplaza a AJ-03», en §H v2 y en filas del changelog del ciclo 1. «t = 60 s» sólo en la frase del propio parche que lo retira. (4) cada pieza con modelo en una sola fila de TURNO-1/2/3 (las extensiones de 03, 04 y 08 son filas propias, como define el parche). (5) diferida a la construcción |
| PAR2-02 | **pasa**. «nivel A/B/C», «Nivel de turno» y `\| (A\|B\|C) \|$` = 0 en §E y §F.10; «plan A/B/C» = 0. T1–T7: 12 líneas en lugar de 11; ninguna tensión se tocó: la diferencia la explican la tabla de familias de ID (PAR2-17, que nombra «T1–T7») y DEP-04 reescrita por PAR2-21, que ya no nombra T1. «TURNO-» fuera de §E/§F.10/§G sólo en la tabla de familias de ID (que dice que no llega a la guía) y en §H v2. (5) diferida a la guía |
| PAR2-03 | **pasa**. El barrido nuevo de AC-8 marca **5 de 5** líneas de `../../Compuertas/rd-po-4.positivos` (creado); sobre el plan v2 da sólo líneas listadas en `rd-po-4.excepciones` (recalculado, §5). «git diff» en §F = 0; ningún AC dice «nivel A» |
| PAR2-04 | aplicado; verificación diferida a la construcción (`verificar.sh`, `TURNO_CMD` y `turnos.jsonl` no existen todavía) |
| PAR2-05 | aplicado; verificación diferida a la construcción (pruebas de cableado y cliente espía detrás de `/v1`) |
| PAR2-06 | **pasa (3) y (4)**: «load_duration y prompt_eval_count» = 0; ningún texto de §E ni de §10 afirma una diferencia con M < 6. (1) y (2) diferidas a la construcción |
| PAR2-07 | aplicado; (1) y (2) dan 0 por vacío (`Demos/` y `Examples/` existen y están vacíos); (3) y (4) diferidas |
| PAR2-08 | aplicado; «<ollama-n3>» sólo en §E.6. Los tres comandos de cierre se corren al terminar la construcción |
| PAR2-09 | **pasa**. En §E.2, «k/5\|k/6 con intervalo\|al menos 3 preguntas» = 0 (la única ocurrencia está en la regla de §E.1 que dice que la reemplaza); «verificador de cifras» = 0; ningún ejemplo de demostración publica tasa. (5) 10 §8.6 → 11 §8.7 → 12 §8.6/§8.8, que es exactamente lo que el parche define como resultado esperado (no es estrictamente creciente: la variante «un-agente» de 12 vuelve a §8.6) |
| PAR2-10 | **pasa**: en §E.4, «RD-PO-3» sólo en «RD-PO-3 no aplica» |
| PAR2-11 | **pasa en sustancia**. «AsistenteController\|ServerSentEvents» = 0 en §F. «IAlmacenDeConversaciones» queda una vez, en el texto de PAR2-13 que dice que sale del plan. Cada PD-n con modelo tiene su hermano en TURNO-1. «agencia 3» = 0 |
| PAR2-12 | aplicado; verificación diferida a la construcción (`diff-base.sh`; prueba de humo de la hoja de estilos con navegador) |
| PAR2-13 | **pasa (2) y (3)**: «keyed «asistente»\|por petición desde el scope» = 0 en §F; «/mcp\` hereda esa restricción» = 0. (1) y (4) diferidas a la construcción |
| PAR2-14 | **pasa (1) y (2)**: «no tiene dónde inventarlo\|no tiene un lugar donde inventarlo» = 0; «PublishContainer» sólo como fuera de alcance (§F.9 y DEP-05). (3) diferida |
| PAR2-15 | **pasa**: un solo párrafo «**Lectores**» (el `grep "^\*\*Lector"` del parche lo cuenta, porque «Lectores» empieza igual: la condición que importa, un solo párrafo, se cumple); «demo §F.9» = 0; 26 filas OA, que es el régimen provisional (v1 + OA-A5) hasta el voto de RV-05. El script del criterio en los dos sentidos queda para la guía |
| PAR2-16 | **pasa (1) y (2)**: «PD-6 en el 3\|agencia 3» = 0; «CAG de servicio» sólo en el glosario. **(3) con observación**: §B.4 conserva la fila «Agente por código» en el escalón 3, con «estado de conversación» entre sus motivos; el parche la lista como derivado a revalidar y no la cambia. Queda como capa a revalidar |
| PAR2-17 | aplicado; (1)–(3) diferidas a la guía (`toc.sh`, `rutas.sh`, `contar.sh`). La compensación de palabras queda con la objeción de J3 |
| PAR2-18 | **pasa**: ≤ 5 preguntas guía por sección (§1 ninguna propia, §4 cinco); «AJ-05; los revalida» = 0; «local o nube» y «RAG sí o no» con una sola casa; «Tool calling\|Nivel de orquestación» = 0 en §C y «CAG de servicio» sólo en el Anexo C (el glosario que lo conserva como alias, por PAR2-19); §12 dice `17`; 12 «dos-agentes» en §8.8 con remisión a §8.7 |
| PAR2-19 | **pasa (1) y (2)**: «§5.8 desaparece» = 0; `\[R-[0-9]` = 0. (3) chequeo mecánico de existencia: toda remisión «§N.k» de §C a la guía apunta a una subsección definida en las fichas (0 inexistentes); el cotejo de tema contra título queda para la guía redactada. (4) diferida |
| PAR2-20 | **pasa**: «PR-0n» sólo en filas del changelog del ciclo 1, que no se reescriben (PAR2-22); la fila PR-3 nombra el desvío (c) |
| PAR2-21 | **pasa**: toda DEP que bloquea tiene dueño y criterio; «Propuesta: cumple» = 0; DEP-15 es condición previa de 04, PD-4, 05, 12, 16 y PD-1 |
| PAR2-22 | **pasa**: «PAR-01…PAR-23» = 0; la fila v1 de §H nombra PAR-24 y AJ-01…AJ-08, como el encabezado; cada RV PROCEDE está en la tabla nueva, en PAR2-01 (RV-03, RV-13) o en PAR2-24 (RV-14) |
| PAR2-23 | **pasa**: no queda la fila marcador «Q1–Q6»; seis filas Q con sección y criterio; I-04 §5.2 nombra a AH-02 e I-05 §5.2 el «escenario nuevo»; existe la fila I-02 |
| PAR2-24 | **pasa**: el bucle `grep -w` sobre los 93 ids PROCEDE de `Ciclo-1/04-Veredictos.md` da 0 faltantes en `Ciclo-1/05-Parches.md`; «85 ítems» = 0 |
| PAR2-25 | pedido registrado; la verificación la corre el dueño del gestor. Estado al cierre: sin respuesta, rige EMB-B en el texto y, si no se resuelve antes de construir, EMB-C |
| PAR2-26 | **pasa**: «RV-06» aparece en N6; `N6-Evidencia/sonda-Program.cs` con el mismo SHA-256 antes y después |
| PAR2-27 | **pasa**: «AJ-07» en las cuatro fichas; `Ciclo-1/01-Convocatoria.md` existe; AC-8 con una sola regla |

## 4. Chequeos mecánicos (M§5.1)

| Chequeo | Resultado |
|---|---|
| Trazabilidad S-xx / I-xx / Q / RD-PO → sección | BIT-16-02 §6: 33 filas de contenido, todas con sección o artefacto y criterio; S-15 es de proceso y no lo necesita (como en el ciclo 1). Queda una fila **pendiente de la presidencia** (I-05 §5.2) |
| Toda sección con fuente y escenario N0 | §0–§15 del índice §C: las dieciséis fichas tienen «Fuente» y «Escenarios» |
| Todo ejemplo con criterio de prueba | 17 de 17 filas de §E.2 con oráculo y criterio ejecutable; PD-1…PD-7 con ejemplo hermano (M y oráculo) en §F.1; PD-7 declarado sin modelo |
| Términos canónicos sin doble sentido | **Colisión «nivel A/B» resuelta**: «dificultad» (B/I/A, para el lector) y TURNO-1…3 (interno); EMB-A/B/C; variantes con nombre; «nivel A/B/C» y «Nivel de turno» = 0 en el plan. «Escalón de orquestación» reemplaza «Nivel de orquestación». Residuo: §B.4 ubica «Agente por código» en el escalón 3 (PAR2-16 (3)) |
| Barrido RD-PO (I-06, AC-8 con los patrones nuevos) | Positivos 5/5. En el plan v2, sólo las tres líneas que nombran la prohibición (l. 26, AC-8, R-06). En toda la bitácora: excepciones listadas en `rd-po-4.excepciones` (recalculado) más los pendientes de R-06. **El patrón nuevo encontró un pendiente que el viejo no veía**: `Nucleos/N4-Agentes-Y-Orquestacion.md` (identificadores compuestos en snippets), que se suma a la lista de reescritura |
| R-PRIV (IPs privadas, hosts de la LAN) | **0 reales** en `OUTPUTs/`. Dos falsos positivos conocidos (números de versión de cuatro componentes en `Ciclo-1/07` y N5) y un modelo de teléfono nombrado en la directiva I-06 del PO, que no es host ni dirección. `$R_PRIV_LISTA` sigue sin crear: el barrido de nombres de host se hizo con los nombres que la secretaría conoce, sin escribirlos |

## 5. Compuertas recalculadas

- `../../Compuertas/rd-po-4.excepciones`: las líneas de AC-8 y R-06 del plan se movieron (v1 l. 823 y 852; v2, ver el archivo) y se suman la copia `04-Plan-De-Integracion.v1.md`, las líneas del ciclo 2 que nombran el barrido y el archivo de positivos.
- `../../Compuertas/rd-po-4.positivos`: nuevo, cinco líneas, una por patrón compuesto (PAR2-03).
