# Ciclo 3 · 03 — Consolidación del relator

Objeto: `Bitacoras/04-Plan-De-Integracion.md` (estructura aprobada v2). Ciclo 3 de 3 (último): lo que no se resuelva queda como deuda declarada.
Insumos: ocho informes de `02-Informes/` (didáctica, edición, arquitectura, desarrollo, operación, AH-02, requisitos, QA, abogado del diablo).
Nota de redacción: los nombres de máquina que aparecen en algunos informes se reemplazan acá por roles («máquina del Ollama propio», «host de la corrida»), según R-PRIV.

## 1. Contradicción previa (se resuelve antes de votar)

**C3-01 — Estado de DEP-14.** Didáctica y Operación votan con DEP-14 pendiente y EMB-C vigente («`<gestor-de-turnos> estado` no lista [recurso-modelo-propio]»). Arquitectura, Desarrollo, AH-02, Requisitos, QA y el abogado del diablo registran el mismo día (2026-10-26) `[[recurso-modelo-propio]] cupo 1`, con salud rc=0, versión 0.40.11, qwen2.5:0.5b y qwen3-embedding:0.6b (capacidad embedding). Opciones: **A** rige EMB-B; las posiciones fundadas sólo en EMB-C (OP3-04, OP3-06, posición DEP-14 de didáctica) se tratan como no emitidas en lo que dependan de eso · **B** rige EMB-C hasta que la presidencia vuelva a verificar. Lo que dice el relator: seis lecturas E1 coincidentes frente a dos, que serían anteriores al alta; la presidencia lo confirma con `<gestor-de-turnos> estado` en el cierre.

**C3-02 — Fusión F1 (01 + 02).** Requisitos: sí (conserva OA-D1, 0 llamadas). Didáctica, Arquitectura, Desarrollo, QA y el abogado del diablo: no (un recurso por ejemplo, l. 636–638). Se resuelve en P3-02.

**C3-03 — RV-03.** Desarrollo, Operación y Requisitos: 6 h. QA, el abogado del diablo y AH-02 (este último condicionado a b′): 4 h. Se resuelve en P3-01, junto con P3-06 y P3-09.

## 2. Papeletas

| ID | Tema | Opciones | Costo / consecuencia |
|---|---|---|---|
| P3-01 | RV-03 tope de horas | **A** 4 h · **B** 6 h · **C** 9 h | A: con PD-1 corregido (H-01) y la carga en frío (H-02), TURNO-1 = 13.430 s y pasa el 90 % (12.960 s): salen la estabilidad y DEP-10, salvo que P3-09 recorte humos. B: TURNO-1 completo y TURNO-2 hasta 15a; entran 13, 16, 17, 12 y 03 ext. si se reordena (REQ3-06). C: no agrega piezas (OP3-04, H-01). En las tres: M = 131,4 s (o 135 s, E3) y la regla de cola «salta a la siguiente pieza que entra entera» (H-05). |
| P3-02 | H2-056 fusiones | **A** F1 no, F2 no, F3 sí · **B** F1 sí, F2 no, F3 sí · **C** ninguna | A: mayoría; 0 llamadas; 14 queda opcional. B: obliga a dos manifiestos o a pasar 01 a TURNO-3 (H-DID3-05). C: sin cambios. |
| P3-03 | RV-05 OA | **A** 26 OA · **B** 25 OA (fundir OA-S3) · **C** 26 + OA-A6 = 27 (si se aprueba CTX-EXISTENTE) | B ahorra ~90 palabras, pero deja OA-S2 con cuatro decisiones y obliga a rehacer las remisiones de PAR2-19. C cubre §14 (H-DID3-02). |
| P3-04 | RV-04 presupuesto de palabras | **A** enmendada (§0.5 al Anexo E; Parte 0 ≤ 1.400; Anexos ≤ 7.430; total ≤ 44.330) · **B** Parte 0 ≤ 1.500 y Anexos ≤ 6.700, con la compensación recalculada · **C** topes de la v1, sin +625; lo que sobre sale de la Parte VI | Requisito previo de las tres: adoptar la regla de conteo por token alfanumérico (ED3-02) y reemplazar el párrafo de compensación por una tabla por Parte (ED3-01). El saldo real es +625, no +220. |
| P3-05 | RV-01 casos integradores | **A** ninguno · **B** optativos, sólo el caso 3 (CTX-EXISTENTE), fuera del conteo de ítems · **C** tres casos (ESC-03, ESC-02, CTX-EXISTENTE) | C: ~+300 palabras (2.900 ≤ 3.000 del Cierre). B necesita una excepción en contar.sh. A: 0. |
| P3-06 | RV-11 juez de 15 | **A** sesgo declarado con calibración propia · **B′** juez qwen2.5:0.5b en el Ollama propio, TURNO-3, misma familia declarada · (la opción b «otra familia» sale: no hay modelo, y PROTOCOLO prohíbe el pull) | B′ saca 52 llamadas M (6.240–6.832 s) de <recurso-compartido> y habilita 4 h. Pregunta abierta: ¿el 0,5B produce una salida interpretable? Si no, el juez queda «no calibrado». En las dos: calibración con perturbaciones controladas y anotador nombrado (H3-002). |
| P3-07 | Criterio de dificultad B/I/A | **A** ratificar el texto actual · **B** nivel de PR-3 por tema + regla residual (I, o A con MAF o juez LLM); 08→B, 17→A; desvíos de 06 y 11 declarados · **C** A definido sobre columnas (paquetes Agents.AI*/Evaluation*, entrada adversarial o cruce de las dos escaleras); 13→A | A no es decidible (QA3-06, H-DID3-01). Enmienda de grafía compatible con B y C: en la guía se escribe con palabras (ED). ~50 palabras de §D. |
| P3-08 | P-12 / DEP-15 contenido escrito para el ejemplo | **A** cumple, como regla general de «estímulo de prueba» (sólo valores de Catalogos/*Policy/SessionSeeder, rótulo, hash, «mismo autor»), y 05 en la variante intermedia · **B** como A, pero 05 pasa a padrón de 70 LocalidadModel y 16 a inyección en Localidad.Nombre (sin variante intermedia) · **C** cumple en bloque, como está · **D** no cumple: 12, 16 y la encuesta de PD-1 pasan a --fake | REQ3-03 dice que la variante intermedia no llega a 4.441 tokens con 2 localidades; AH-02 y Desarrollo la calculan con 72 u 84 combinaciones: está en disputa (va a la verificación del cierre). B exige además el parche de política de origen (H3-008). D anula la medición de casi toda la guía (H3-001). |
| P3-09 | Recorte de la demo (H2-054) | **A** sacar PD-4 y PD-7; PD-2 → ayuda en el escalón 0 (o sacarlo) · **B** RC-1: humo con modelo sólo en PD-2, PD-3 y PD-6; PD-1/4/5 cableado; PD-7 sale (su prueba pasa a 13) · **C** humo con modelo en PD-1, PD-5 y PD-6; PD-2/3/4 cableado; PD-7 sin modelo · **D** contra el modelo sólo PD-1; PD-5/PD-6 reutilizan el registro de 09/11 | Ahorro en TURNO-1: B ~1.980 s; C ~240 s; D ~1.425 s + 240 s. En todas: barrido de las 81 referencias PD-n (REQ3-05/QA3-05), y §F.1 «cinco escenarios / siete pasos» y la ficha de §14 en el mismo parche; tabla de cobertura ESC × {guía, ejemplo, demo}; PD-2 se rotula ESC-01 (H3-011). |
| P3-10 | Par CTX-NUEVA / CTX-EXISTENTE | **A** aplicar en 03 §2, §4.2 y §2 de la guía, con la grafía única CTX-EXISTENTE, CTX-NUEVA «sin ejecución», las cinco respuestas que cambian, «contexto de uso» como término N0, P-05 y la fila I-05 §5.2 cerradas · **B** aplicar sólo en 03 §2 y en la guía, sin columna nueva en las matrices · **C** no aplicar | A toca §F.1, §14, §2, §3.3, ADR-11/13 y el Anexo C. B es más barata, pero deja vacía una columna que §4.1 de 03 exige llena. Con A conviene P3-03 C. |

## 3. Hallazgos nuevos deduplicados

| ID | Sev. | Hallazgo | Fuentes |
|---|---|---|---|
| H3-001 | S1 | 09 l. 31 tiene nombres de host de la LAN y la red superpuesta; se escribió después del barrido R-PRIV del ciclo 2 | OP3-01, QA3-02, REQ3-04 |
| H3-002 | S2 | AC-7 y AC-8 pasan en vacío con la lista vacía o inexistente; motor ugrep; falta el rango 100.64/10; las listas no tienen dueño (DEP-16) | OP3-02, QA3-02 |
| H3-003 | S2 | DEP-12 huérfana (SSE en un controller inexistente, bloquea PD-1); ADR-13 sin criterio: AC-11 «humo del host» | ARQ3-01, desarrollo, REQ3-05, QA, AD |
| H3-004 | S2 | La provisión del Ollama propio (§E.1, §E.6, R-02) supone un contenedor local del arnés; el recurso es del gestor, en otra máquina, sin pull ni borrado | ARQ3-04, H-03, OP3-03, H3-04 (AH-02), REQ3-04, QA3-04 |
| H3-005 | S2 | TURNO-3 sin tabla ni línea de corte; las clases de t no valen para qwen2.5:0.5b; AC-3b sin excepción | QA3-04, H3-AD-05, OP3-06 |
| H3-006 | S2 | PD-1 cuesta 2 entradas / 4 llamadas L (1.900 s), no 950 s | H-01 |
| H3-007 | S2 | Con /api/ps vacío el arnés aborta; falta el precalentamiento y una carga K presupuestada | H-02 |
| H3-008 | S2 | La política de origen (regla 2) bloquea listar → eliminar de 11 y PD-6, por Localidad.Nombre | REQ3-02 |
| H3-009 | S2 | La compensación de palabras no cierra (760/285; saldo +625) y la regla de conteo no trata «\|» ni los tokens sin letras (desvío de 25,6 %) | ED3-01, ED3-02, QA |
| H3-010 | S2 | La compuerta de familias de ID marca OA-S2, QA y PC | ED3-03 |
| H3-011 | S3 | PD-2 rotulado ESC-02, pero genera; la única pieza de ESC-02 es 06 | ARQ3-03 |
| H3-012 | S2 | Unas 20 subsecciones fuera del criterio de inclusión de §A.3; §14 sin OA | H-DID3-02 |
| H3-013 | S3 | OA-S1 sin ejemplo ni pregunta guía | H-DID3-03 |
| H3-014 | S2 | «Contexto» con tres sentidos; el Anexo C con una sola entrada | ED3-04 |
| H3-015 | S3 | §B.4 «Agente por código» en el escalón 3, y agrupador de §8.7 | ED3-05, ARQ, QA |
| H3-016 | S3 | Residuos de los parches del ciclo 2 (líneas v1, 33 remisiones sin «plan §», 58/25, CTX-EXIST, R-04/R-07) | ED3-06 |
| H3-017 | S3 | AC-5 sólo cubre Domain; faltan tres reglas de capa | ARQ3-05 |
| H3-018 | S2 | La calibración de 15 no se puede obtener (sin llamadas, anotador sin nombre) | H3-02 (AH-02), H3-06 |
| H3-019 | S2 | 05: M = 5 con la regla pareada de ≥ 6 discordantes; discordante sin definir para tiempos | QA3-03 |
| H3-020 | S3 | 16: un solo ataque del mismo autor; la comparación «origen» es trivial por construcción | H3-05 (AH-02) |
| H3-021 | S3 | Tiempos de 05 contaminables por carga ajena en la máquina del propio; comparar sólo duraciones del servidor | H-06, H3-04 (AH-02) |
| H3-022 | S3 | Falso positivo de AC-8 en «coincidente» | QA3-01 |
| H3-023 | S3 | docker pull falla con la configuración del usuario (credencial vencida) | OP3-05 |
| H3-024 | S3 | El orden de TURNO-2 no tiene criterio declarado (por OA sin evidencia en --fake o por cobertura de requisito) | H-DID3-06, REQ3-06 |
| H3-025 | S3 | La papeleta F1 oculta el costo de dos recursos | H-DID3-05 |
| H3-026 | S2 | Plan sobredimensionado frente al «iniciar» del prompt; no converge | H3-AD-01 |
| H3-027 | S3 | DEP-10 consume 2.850 s cuando ya hay un contrato alternativo escrito | H3-AD-03 |

Cada hallazgo se vota PROCEDE / NO_PROCEDE.
