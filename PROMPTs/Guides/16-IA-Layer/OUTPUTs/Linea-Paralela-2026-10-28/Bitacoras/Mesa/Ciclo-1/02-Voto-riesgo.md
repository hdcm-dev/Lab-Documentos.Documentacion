---
doc_id: BIT-16-C1-02-riesgo
doc_type: voto-de-jurado
title: Voto del juez de riesgo e irreversibilidad — ciclo 1, ronda 1
status: entregado
origin: agent
owner: juez de riesgo e irreversibilidad (REED-16 §9.4; M§4.3)
last_review: 2026-10-28
audience: [presidencia, jurado, cuerpo-auditor, PO]
traces: [Mesa/Ciclo-1/01-Consolidado.md, REED-16 §9.4 §12 §13, M§4.3 M§5.3, BIT-16-00 R-PRIV R-ESCR, BIT-16-03 §2 ESC-04, BIT-16-04 §6.3 M1–M12, Reanudar.md §3]
---

# Voto del juez de riesgo e irreversibilidad — ciclo 1, ronda 1

**Función fija:** ¿hay riesgo o irreversibilidad? Para cada ítem pregunto dos cosas: qué se rompe si la corrección sale mal y se puede deshacer, y qué riesgo le queda al lector o al laboratorio si **no** se corrige. Veto acotado (M§5.3): sólo sobre un `PROCEDE` cuya corrección sea irreversible **y** de severidad ≤ S3; el veto no archiva, escala.

## 0. Verificaciones propias (E1, 2026-10-28)

- `git status --short` en `Lab-Documentos.Documentacion`: `?? PROMPTs/Guides/16-IA-Layer/` (sin seguimiento). El remoto `origin` es un repositorio de GitHub (público según AH-01 §12). Conclusión: **todavía no hay historia publicada**; el único acto irreversible a la vista es el primer commit + push de `OUTPUTs/`. Cualquier corrección local previa es reversible (copia fuera del repositorio).
- `Reanudar.md`: una línea con una dirección del rango <rango-cgnat> (conteo 1, coincide con G3 y con la sonda de AH-01). No la transcribo.
- R-PRIV (BIT-16-00) prohíbe en repos públicos IPs privadas, **hostnames de la LAN**, puertos, usuarios, credenciales y repos privados. R-ESCR: fuera de `OUTPUTs/` sólo se escribe en la carpeta de la guía; Lab-E2E.WebBlazor no se toca.
- REED-16 §12 fila 4 (irreversibilidad que escala al PO) habla del «servidor Ollama de la LAN», que Reanudar §3 da por muerto; el mismo §3 dice que un Ollama en estación 2 se decide «con la mesa». estación 2 es además el respaldo de contingencia de la estación caída.
- BIT-16-03 l. 37: ESC-04 «puede escribir»; BIT-16-04 §6.3: M1 (escrituras por el caso de uso), M3 (ninguna escritura sin confirmación).

## 1. Resultado

**Ningún veto.** Ninguna corrección propuesta es irreversible: el objeto es una guía que todavía no existe y una bitácora sin seguimiento. Lo irreversible está del lado **contrario**: publicar sin corregir C1-01/C1-39 o enseñar a copiar C1-27, C1-12 y C1-03. Por eso esos ítems los voto como bloqueantes de cualquier commit o redacción.

Condición transversal que pongo a todos los parches: **nada se borra ni se renombra en la bitácora salvo la redacción R-PRIV** (C1-01), que es la única excepción justificada a SÓLO AGREGADO; y **nada toca Lab-E2E.WebBlazor** (R-ESCR): la copia literal es copia.

## 2. Votos

| Ítem | Voto | Opción | Fundamento desde el riesgo |
|---|---|---|---|
| C1-01 | PROCEDE | redacción in situ antes del primer commit | Publicar es lo único irreversible del ciclo (repo público; un push deja la dirección y el usuario en la historia aunque después se borren). Una nota agregada no saca la fuga. Como `16-IA-Layer/` está sin seguimiento, redactar in situ es reversible (copia previa fuera del repo, p. ej. bajo `{dir-de-trabajo}/`) y no destruye historia publicada; la nota fechada deja constancia. La compuerta extendida (/home/, <rango-cgnat>, usuario@IP, hostnames) debe ser **bloqueante** del commit, no informativa. |
| C1-02 | PROCEDE | — | Sin definición estable, un umbral sobre «falso aceptado» se convierte en una garantía falsa que el lector copia. Escribir «no medido» es reversible y elimina el riesgo. |
| C1-03 | PROCEDE | — | Una cola sin techo rotulada «responde a LLM10» enseña lo contrario del control: con 9–112 s por pedido es un agotamiento de recursos que el lector copia tal cual. La corrección es texto + prueba de cableado, reversible. |
| C1-04 | PROCEDE | — | Riesgo de no corregir: secciones que no dicen en qué contexto valen (CTX) y se copian fuera de él. Notas fechadas, reversibles. |
| C1-05 | PROCEDE | — | Sin mapeo D→ESC→CTX no se puede saber qué control aplica a qué pieza de la demo. Reversible. |
| C1-06 | PROCEDE | — | Una propuesta del PO sin decisión es un cambio de alcance silencioso (REED-16 §12 fila 3 al revés). La tabla agrega, no borra. |
| C1-07 | PROCEDE | — | La guía no existe: es el momento más barato y reversible para fijar estructura; después cuesta retrabajo (S2). |
| C1-08 | PROCEDE | — | Evidencia que sólo vive en la bitácora se pierde si la bitácora no se publica por R-PRIV (C1-01): la guía quedaría con afirmaciones sin respaldo. Reversible. |
| C1-09 | PROCEDE | — | Dos respuestas vigentes a la misma pregunta es contradicción publicada. Plan previo, reversible. |
| C1-10 | PROCEDE | — | Condición: la receta usa `localhost`/variable, imagen con versión **y digest**, red Docker propia; pasa la compuerta R-PRIV (una receta es el lugar más probable de una fuga de dirección o puerto). |
| C1-11 | PROCEDE | — | `localhost` por defecto y `ValidateOnStart` reducen el riesgo de enviar datos a un endpoint no querido o de truncar en silencio. Reversible. |
| C1-12 | PROCEDE | — | Singleton que mezcla sesiones sin fallar es una fuga de datos entre usuarios en un dominio con datos personales (CTX-SENS), invisible en Development. Es de los riesgos más altos del lote. Exijo la prueba con `ValidateScopes=false`; PC-11 queda como criterio de verificación del parche. |
| C1-13 | PROCEDE | — | Condición: valor finito y declarado + cancelación; **nunca** `Timeout.Infinite` (cambia un error visible por un recurso colgado). |
| C1-14 | PROCEDE | — | El ADR del estado procede siempre. El contrato de aprobación por id depende de C1-40: si gana B, se reduce. Si queda algún endpoint de aprobación, PC-12 (aprobar una baja ajena con `X-Sesion-Id` no autenticado) debe cerrarse **antes** de implementarlo. |
| C1-15 | PROCEDE | — | Salida codificada (LLM05) es control de seguridad, no estética. Topología: decisión reversible; que se registre como desvío si no hereda la sesión. |
| C1-16 | PROCEDE | — | Ubicar herramientas como adaptador de entrada hace que pasen por el caso de uso (M1); la ubicación errónea enseña a saltearlo. Reversible. |
| C1-17 | PROCEDE | — | Condición: se corrige el **texto** (núcleos, corpus de C4 por agregado), nunca el código de Lab-E2E.WebBlazor (R-ESCR; el código es la verdad). Afirmar reglas que el código no cumple es una garantía falsa. |
| C1-18 | PROCEDE | — | «Validar y devolver sin persistir» reduce la superficie de escritura. Reversible. |
| C1-19 | PROCEDE | — | Condición: `diff -r` contra el original sin escribir en él; `LocalidadesController` (saltea el caso de uso) como deuda declarada y advertida, porque copiarlo sin aviso viola M1. |
| C1-20 | PROCEDE | — | El filtro por `SessionId` en servidor es la parte crítica (aislamiento). Declarar que la agregación en memoria es de demo, no de CTX-PROD. |
| C1-21 | PROCEDE | — | Cifras de otro modelo inducen decisiones de costo falsas. Reversible. |
| C1-22 | PROCEDE | — | Truncamiento silencioso descarta instrucciones del sistema (riesgo de seguridad, no sólo de calidad). Reversible. |
| C1-23 | PROCEDE | — | Condición: rotular el entorno con el nombre neutro que resuelva C1-39, no con el hostname. |
| C1-24 | PROCEDE | — | Sin no respondibles ni abstención la guía enseña un RAG que inventa con confianza. Reversible. |
| C1-25 | PROCEDE | — | Clave para mi función: una garantía de seguridad expresada como tasa con N chico es una garantía falsa; las invariantes deben ser deterministas (`Cableado/`). |
| C1-26 | PROCEDE | — | Salteo silencioso = verde falso: el riesgo de que la evidencia publicada no exista. Reversible. |
| C1-27 | PROCEDE | — | `npx -y` sin versión es cadena de suministro abierta y aprobación cableada en `true` anula M3: ambos son copiables tal cual por el lector. Riesgo alto, corrección barata y reversible. |
| C1-28 | PROCEDE | — | MCP HTTP expuesto sin M13 amplía la superficie; M14 y el largo máximo son baratos. Condición: PC-01 (AllowedHosts/`RequireAuthorization` en 2.3.0) se verifica E1 antes de afirmarlo. Si C1-48 saca el MCP HTTP de la demo, M13 sigue valiendo donde quede. |
| C1-29 | PROCEDE | — | Bajo riesgo; la ingesta es por donde entra el texto no controlado (inyección indirecta), conviene que esté en el diagrama. |
| C1-30 | PROCEDE | — | Sólo como notas; no reescribe la fundación. Reversible. |
| C1-31 | PROCEDE | — | Que nada entre como «ejecutado» sin compilar reduce el riesgo de snippet que no corre. Reversible. |
| C1-32 | PROCEDE | — | Condición: el esquema de ids nuevo vale para la guía; **no** se renombran ids de la bitácora (rompería la trazabilidad de los informes ya escritos). Así no hay nada irreversible y no corresponde veto. |
| C1-33 | PROCEDE | — | Cadena de suministro: avisos NU1902/NU1903 transitivos. Propongo exigir cero NU19xx en el camino por defecto o excepción declarada con el aviso y su fecha. Re-consulta el día de la publicación. |
| C1-34 | PROCEDE | — | Bajo riesgo, reversible; evita parámetros que el fabricante desaconseja. |
| C1-35 | PROCEDE | — | Bajo riesgo; evita que el lector migre creyendo que el modelo de programación es el mismo. |
| C1-36 | PROCEDE | no bloquea el ciclo; bloquea declarar «validado» | La falta de §4/§6 no causa daño irreversible; sí impide marcar un núcleo como validado en `05-Cierre` (REED-16 §13). Propongo: se redacta, pero ningún núcleo pasa a `validados` sin esas secciones. |
| C1-37 | PROCEDE | A (SENIOR), condicionada | Para riesgo pesa más ver la ejecución de herramientas (auditar qué hizo el agente) que ver aciertos de caché. Condiciones: (1) cerrar PC-02 (doble capa) antes de fijar M8; (2) con la caché por fuera de `UseFunctionInvocation`, **la clave de caché debe incluir la sesión** o la caché no se aplica a pedidos con herramientas que leen `SessionContext`: si no, una respuesta de la sesión A se sirve a la B. R-C07 no es DC-0n: reabrirlo no es §12 fila 7. |
| C1-38 | PROCEDE | A (núcleo) | En el adaptador, la normalización protege sólo la entrada por IA; controllers y MCP la saltean. En una pieza nueva del núcleo vale para todas las entradas y sigue siendo agregado (no altera lo copiado). M2 se re-ancla a esa pieza, así la condición de AH-01 en MI-05 se mantiene (el control existe y es más fuerte). |
| C1-39 | PROCEDE | A (AH-01) | R-PRIV prohíbe hostnames de la LAN en repos públicos; B reemplaza una fuga por otra. Nombre neutro en guía, `Examples/` y `Demos/` (p. ej. «estación de laboratorio sin GPU»), hostnames en la compuerta. Para la bitácora, que también está en el repo público: redacción o dejar `OUTPUTs/` fuera del commit hasta pasar la compuerta. Lo irreversible es publicar. |
| C1-40 | PROCEDE | B (ABOGAD) en la demo; A enseñada en `Examples/07` | El riesgo nace de ofrecer la herramienta (X2 D6: baja llamada 10/10 sin preguntar). Sin herramientas de escritura en la demo, M1 y M3 se cumplen por diseño y desaparece la exposición de PC-12. ESC-04 «puede escribir» (BIT-16-03 l. 37): la guía lo enseña con `ApprovalRequiredAIFunction` en el ejemplo, con PC-12 y PC-13 cerrados antes. |
| C1-41 | PROCEDE | B (4b provisional) | Ningún riesgo en fijar 4b por variable; sí en afirmar que la evidencia lo separa del 2b. Elección reversible por `OLLAMA_MODEL`. |
| C1-42 | PROCEDE | B (CAT-OP/ABOGAD), con resguardo de estación 2 | «No se midió» es lo único sostenido. Vía mesa (no §12 fila 4: el servidor de esa fila está muerto y un contenedor propio es reversible). Resguardo: estación 2 es el respaldo de contingencia; el Ollama allí va **bajo demanda**, con límites de memoria/CPU, apagado al terminar y sin tocar la configuración del anfitrión. El MoE de 22 GB, no hasta cerrar PC-07. |
| C1-43 | PROCEDE | B | Sostener una regla con una tasa de N = 1 es garantía falsa; el argumento de diseño no tiene ese riesgo. |
| C1-44 | PROCEDE | B (AH-02) | Un juez no calibrado como compuerta da seguridad falsa (aprueba lo que no debería). Como método, con k/n e intervalo, nunca compuerta. |
| C1-45 | PROCEDE | B (ejemplos 01 y 06) | Un selector por defecto que va por `/v1` deja sin `num_ctx` y anula M10 y MI-18: truncamiento silencioso en la demo. Como variante declarada, sin riesgo. |
| C1-46 | PROCEDE | B (dentro de D-06) | S3, reversible en ambos sentidos; no hay mérito de veto. Lo que importa para riesgo es el contenido obligatorio de C1-12, que B exige. |
| C1-47 | PROCEDE | otra: A + eventos de etapa | Para riesgo la pieza clave es la cancelación (libera el modelo con `NUM_PARALLEL=1`), que está en A. Los eventos de etapa de B no la contradicen y cubren el bucle de herramientas sin texto. Compatibles. |
| C1-48 | PROCEDE | A (demo mínima D1–D6 + ejemplos), votada antes que los parches | Cada pieza sumada a la demo es superficie de ataque y un control más que puede fallar sin prueba; la demo actual ya contradice CTX-PROTO. Reducir es reversible (lo quitado vive en `Examples/`); sumar sin tope no lo es en costo. Los controles M13/M14 siguen valiendo donde quede cada pieza. |
| C1-49 | PROCEDE | otra: A y B en §5, C en §6; «A por defecto» con argumento de diseño | Bajo riesgo. Sólo exijo que la regla no se respalde con EA-6 (C1-43) y que C no figure como ejecutada con modelo (sólo corrió con un doble). |
| C1-50 | PROCEDE | propuesta, con 4b provisional | Modelos por variable y modelo@digest en cada salida: reversible y trazable. Bajar modelos al contenedor propio es reversible. |
| C1-51 | PROCEDE | otra (Operación) | Vía mesa, sólo P-03 y P-07, contenedor bajo demanda en estación 2 sin comprometer la contingencia, dirección sólo por variable; si no prospera, «no medido» visible. |
| C1-52 | PROCEDE | propuesta, con test por reflexión que falla (Verificación/Arquitectura) | El `grep` da verde falso (R4); una prueba que no puede fallar es peor que no tenerla porque certifica. |
| C1-53 | PROCEDE | propuesta, con condiciones de C1-19 y C1-38 A | Copia literal verificable por `diff`, sin escribir en el original (R-ESCR); `LocalidadesController` advertido; normalización como pieza agregada del núcleo. |
| C1-54 | PROCEDE | propuesta | Sin riesgo propio; evita filtrar tipos de MEAI al núcleo. Unánime. |
| C1-55 | PROCEDE | alternativa (escalón 0 en la demo, RAG en `Examples/05`) | Coherente con C1-48 A: el RAG suma inyección indirecta y 25–70 s por pregunta; fuera de la demo no se pierde nada didáctico. Si C1-48 queda en B, voto la propuesta con el oro de AH-02. |
| C1-56 | PROCEDE | propuesta | Búsqueda de lectura sobre enunciados de requisitos, sin datos personales ni escritura: no amplía la superficie de riesgo. Condición: métricas definidas por C1-24. |
| C1-57 | PROCEDE | propuesta | Sin riesgo; RD-PO-3 vinculante. |
| C1-58 | PROCEDE | propuesta | Condición: LangGraph se rotula «no ejecutado» si no se levanta; ejecutarlo dispara AH-03 y Python en contenedor (no en el anfitrión). |
| C1-59 | PROCEDE | otra: M1–M12 + M13, M14, largo de entrada, M11 reformulado, corte definido | Controles acumulables y baratos; el orden del abogado (perímetro primero) se respeta votando C1-48 antes. |
| C1-60 | PROCEDE | propuesta | Preview por defecto es riesgo de cadena de suministro y de ruptura; GA reduce ambos. Unánime. |
| C1-61 | PROCEDE | alternativa (sólo ejemplos 01 y 06) | Mismo fundamento que C1-45. |
| C1-62 | PROCEDE | otra: toda escritura la confirma la persona, sin herramientas de escritura en la demo; `ApprovalRequiredAIFunction` en `Examples/07` | Coherente con C1-40 B; nadie votó «alta sin aprobación», que sería el único camino riesgoso. |
| C1-63 | PROCEDE | propuesta | Constante única evita telemetría huérfana (fuente que no se escucha = control invisible). Condición de Senior por C1-37. |
| C1-64 | PROCEDE | alternativa (demo sin juez; método, k/n con intervalo) | Mismo fundamento que C1-44. |
| C1-65 | PROCEDE | propuesta, forma de Senior/Formal | Fallar al arrancar evita vectores incomparables sin error (corrupción silenciosa del índice, difícil de revertir una vez cargado). |
| C1-66 | PROCEDE | propuesta | Convierte el truncamiento silencioso en error visible. |
| C1-67 | PROCEDE | alternativa (conceptual sin ejemplo) hasta cerrar PC-14 | Un campo inventado contradice la copia literal; la variante de Didáctica es mejor sólo si AH-01 la valida (PC-14). Reversible. |
| C1-68 | PROCEDE | propuesta, condicionada a C1-15 | Salida codificada obligatoria; la vía móvil queda para el ciclo de demo (este ciclo no usa emuladores) y sin dirección escrita. |
| C1-69 | PROCEDE | propuesta, extendida a `EncuestaMcpTools` y con advertencia de celda mínima | La exposición de datos personales es el daño más irreversible del dominio (no se des-publica). PC-15 como criterio de verificación. |
| C1-70 | PROCEDE | propuesta | Dueño explícito + plantilla R-LLM = evidencia trazable. Unánime. |
| C1-71 | PROCEDE | alternativa (dentro de D-06) | Igual que C1-46. |
| C1-72 | PROCEDE | otra, en dos partes | (a) sincrónico con streaming, cancelación y eventos de etapa (C1-47); (b) no fijar umbral hasta C1-02; la guía dice «no medido». Fijar hoy un umbral con 2/10 es garantía falsa. |
| C1-S4 | PROCEDE | — | Pura forma, reversible. Condición en el punto 4: **copiar** los scripts con el nombre registrado, no renombrar en el lugar (los informes citan las rutas actuales; SÓLO AGREGADO). El punto 5 ya dice «sin tocar el archivo». |

## 3. Ítems que, a mi juicio, bloquean

- **Antes de cualquier commit:** C1-01 y C1-39 (fuga R-PRIV; la publicación es irreversible). La compuerta extendida tiene que salir en cero.
- **Antes de redactar las secciones afectadas:** C1-27, C1-12, C1-03 (fragmentos peligrosos de copiar), C1-48 (perímetro, del que dependen ocho ítems) y C1-37 con su condición de caché por sesión.
