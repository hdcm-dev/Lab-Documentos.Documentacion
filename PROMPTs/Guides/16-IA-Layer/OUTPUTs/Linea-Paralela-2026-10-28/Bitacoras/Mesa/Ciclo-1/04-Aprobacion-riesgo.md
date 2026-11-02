---
doc_id: BIT-16-C1-04-riesgo
doc_type: aprobacion-de-parches
title: Aprobación del juez de riesgo e irreversibilidad — ciclo 1, vuelta 1
status: entregado
origin: agent
owner: juez de riesgo e irreversibilidad (REED-16 §9.6; M§5.5)
last_review: 2026-10-28
audience: [presidencia, cuerpo-auditor, aplicación, PO]
traces: [Mesa/Ciclo-1/03-Parches.md, Mesa/Ciclo-1/02-Voto-riesgo.md, Mesa/Ciclo-1/02-Revision-Homogeneidad.md, REED-16 §9.6 §12, M§5.5 M§6, BIT-16-00 R-PRIV R-ESCR DC-05]
---

# Aprobación del juez de riesgo — ciclo 1, vuelta 1

**Qué pregunto en cada parche:** (1) si sale mal, ¿se puede deshacer?; (2) ¿qué riesgo le queda al lector o al laboratorio si no se aplica?; (3) el chequeo obligatorio de M§5.5: **¿corrige en la capa donde nació el defecto?** Una condición de esta aprobación no es un rediseño: es una restricción de ejecución que la aplicación cumple sin volver al cuerpo auditor. Si una condición no se puede cumplir, el parche vuelve como `MEJORAR_PLAN`.

## 0. Verificaciones propias (E1, 2026-10-28)

- `git status --short` en `Lab-Documentos.Documentacion`: la carpeta `16-IA-Layer/` sigue **sin seguimiento** y sin historia (`git log` vacío sobre esa ruta). Todo lo que se toque antes del primer commit es reversible; el primer commit + push al remoto público es el único acto irreversible a la vista.
- Barrido con los tres patrones de P-01 (ruta del home, host del rango de la tailnet con último octeto ≠ 0, `usuario@IP`) sobre `OUTPUTs/`: **31 líneas en 12 archivos** (la prueba de diseño de las 11:07 dio 30 + 1 + 1). Archivos: `Reanudar.md` (4), `Crear-IA-Layer-Guide-Reedicion.md` (1), `Bitacoras/00-Contrato-De-Entrada.md` (1), `Bitacoras/Sondeo-Entorno.md` (2), `Mesa/Ciclo-1/00-Convocatoria.md` (2), `Mesa/Ciclo-1/evidencia-arquitectura/` (8 entre salida y script), `Integracion-Evidencia/A-arquitectura/exp-capas/verificar-capas.sh` (1), N0b (3), N1 (4), N1b (2), N3b (3). La cifra cambió desde la prueba de diseño: la verificación de P-01 tiene que tomar el «antes» al momento de aplicar, no reutilizar la de las 11:07. Este archivo no suma coincidencias.
- Digest de P-10: la API de Docker Hub devuelve para `ollama/ollama:0.40.11` el índice `sha256:dea72d1e22270fe095b68fdf756d2b489d615643c5a2eaebbc5f569181e322d8`, `last_updated` 2026-10-24T17:09:46Z (consulta https://hub.docker.com/v2/repositories/ollama/ollama/tags/0.40.11, 2026-10-28). Coincide con el parche.
- «Sólo agregado» es una regla de trabajo de `Reanudar.md` §1, no una DC-0n del contrato (DC-01…DC-08). La excepción de P-01 no reabre una decisión cerrada: no es REED-16 §12 fila 7.
- Caso base: en `Lab-E2E.WebBlazor`, `8fb4c3a..59399ba` son 2 commits sin diff de código en las capas copiadas (EA-1 de BIT-16-04). P-16 y P-17 citan `59399ba` y la procedencia sigue en `8fb4c3a` (DC-05): no hay contradicción.

## 1. Resultado

**44 parches: 44 `APLICAR`, 0 `MEJORAR_PLAN`, 0 `NO_APLICAR`, 0 `ESCALAR`.** Ninguno es irreversible en el sentido de M§6.4 (la guía no existe y la bitácora no tiene historia), ninguno toca `Lab-E2E.WebBlazor`, ninguno manda datos afuera ni usa un proveedor con costo, y ninguno dispara REED-16 §12. Siete llevan condiciones de ejecución (§2). Los cuatro condicionados por la segunda ronda (P-05, P-17, P-23, P-35) y los parciales (P-03, P-13, P-22, P-27) se aprueban **en su parte común ahora y en la rama que gane después**: el cuerpo auditor ya dejó las dos ramas escritas, así que la aplicación no necesita otro diseño. La rama A de P-13 y de P-35 tiene una precondición de riesgo (PC-12 y PC-13 cerradas antes de implementar).

Chequeo de capa: en los 44 el destino incluye la capa de origen que declara el parche. En P-29 el origen (los snippets de N1 compilados con un SDK 11 rc) está en N1 y el destino sólo nombra BIT-16-04; la condición de §2 suma la remisión en N1 §4.

## 2. Condiciones de ejecución

| Parche | Condición | Por qué, desde el riesgo |
|---|---|---|
| P-01 | (a) Antes de redactar in situ, copia de los 12 archivos afectados en `{dir-de-trabajo}/<etiqueta>/`, fuera del repositorio; se borra cuando la compuerta da `patrones=0` y la aplicación verifica que no cambió ninguna afirmación (diff palabra por palabra salvo las rutas). La copia nunca entra en `OUTPUTs/`. (b) El «antes» de la compuerta se toma al aplicar (hoy 31 líneas). (c) **Ningún commit de `OUTPUTs/`** mientras `identificadores > 0`, salvo un dictamen fechado de la presidencia que declare esos identificadores no R-PRIV en la bitácora: el «informa y no bloquea» vale para el ciclo, no para el push. (d) La redacción alcanza también `Crear-IA-Layer-Guide-Reedicion.md` y `Mesa/Ciclo-1/evidencia-*`. | Redactar sin copia previa es lo único irreversible del parche (un reemplazo mal hecho borra texto sin vuelta). Y el push es irreversible: si los hostnames resultan R-PRIV después de publicarlos, ya no se des-publican (R-PRIV prohíbe hostnames de la LAN en repos públicos). |
| P-37 | El texto que se agrega no lleva el nombre del equipo de respaldo entre paréntesis ni el de la estación: «el equipo de respaldo», «la estación de laboratorio». El contenedor se levanta sólo si el equipo de respaldo está disponible sin comprometer la contingencia (memoria y disco libres registrados antes), con límites de CPU y memoria, sin tocar la configuración del anfitrión, y se apaga y se registra la baja al terminar. Los modelos bajados se borran o se dejan declarados. | Una nota nueva que nombra equipos crea deuda R-PRIV que P-01 después tiene que redactar. El equipo de respaldo es la contingencia de la estación caída: ocuparlo sin límite es el riesgo real del parche. |
| P-21 | La columna «fuente» de la tabla de cifras y `cifras.py` nombran la estación con la forma de RV-01, sin hostnames ni nombres de contenedor. | Misma razón: la tabla se reutiliza en la guía. |
| P-25 | Los scripts de `C-operacion-demo/` **se copian** con el nombre que quedó en las salidas; el original queda en su lugar. No se renombra. | Los informes del panel citan las rutas actuales; renombrar rompe la trazabilidad de un registro sólo agregado (condición ya puesta en mi voto de C1-S4). |
| P-13 | La rama A (endpoint de aprobación) no se implementa sin PC-12 respondida como E3. Mientras el `SessionId` no esté autenticado, la guía declara que el 404 por sesión distinta no es control de acceso. | Aprobar una baja ajena es una escritura irreversible sobre datos de otra persona. |
| P-35 | La rama A no se aplica sin PC-12 y PC-13 cerradas. La parte común (M3 invariante, ESC-03 no escribe, P6 reescrita) se aplica ya. | Igual que P-13: el riesgo nace de ofrecer la herramienta (X2 D6). |
| P-29 | Nota de una línea en N1 §4.1 que remite a P-15/P-29 de BIT-16-04: el defecto (snippet «compilado» con un SDK rc) nació en N1. | Chequeo de capa de M§5.5. |

Condiciones transversales que siguen vigentes desde mi voto: nada se borra ni se renombra en la bitácora salvo la redacción R-PRIV de P-01; nada escribe en `Lab-E2E.WebBlazor` (P-14, P-16, P-17 y P-30 trabajan sobre la copia); toda prueba nueva de comportamiento heredado (P-16) vive en `Cableado/` de la copia.

## 3. Decisiones por parche

| Parche | Decisión | Capa correcta | Fundamento desde el riesgo |
|---|---|---|---|
| P-01 | APLICAR (§2) | sí: `Reanudar.md` y los registros donde se escribió la fuga; la compuerta en REED-16 §9.1, donde faltaba | Es el S1 que bloquea el único acto irreversible. Redacción in situ, rama alternativa y compuerta con caso rojo son suficientes con la copia previa y el bloqueo del push. |
| P-02 | APLICAR | sí: N0b, donde nació el triple sentido, y propagación | «No medido» elimina una garantía falsa; nota fechada, reversible. |
| P-03 | APLICAR (parte firme ya; orden tras PC-02) | sí: N5 §4.2 (fragmento) e integración (R-C07, M8) | Cola acotada + 503 es el control real de LLM10. La clave de caché con `SessionId` cierra la fuga entre sesiones que yo había condicionado. M8 neutral mientras no se elija rama: revertir no deja una afirmación falsa. |
| P-04 | APLICAR | sí | Tabla agregada; «no aplica: motivo» evita que se copie fuera de contexto. |
| P-05 | APLICAR (mapeo ya; columna «en la demo» tras la segunda ronda) | sí | La regla «una pieza entra sólo si tiene afirmación E1 y todos sus controles» reduce superficie; reversible. |
| P-06 | APLICAR | sí | Cierra cambios de alcance silenciosos; PR-7 descartada con motivo. |
| P-07 | APLICAR | sí | Fijar estructura antes de redactar es lo más barato; ±20 % sin recortar evidencia. |
| P-08 | APLICAR | sí | Evita que la guía dependa de una bitácora que puede no publicarse. |
| P-09 | APLICAR | sí | Una respuesta vigente por pregunta. |
| P-10 | APLICAR | sí | Digest verificado E1 hoy (§0); red y volumen propios, endpoint por nombre de servicio, sin direcciones. Bajar modelos al contenedor del lector es reversible. |
| P-11 | APLICAR | sí | Timeout finito sin valor por defecto en código + `ValidateOnStart` + cancelación: cumple mi condición (nunca `Timeout.Infinite`). 400 antes del modelo. |
| P-12 | APLICAR | sí: D-06 en N0b y R-C04 | El riesgo más alto del lote (sesión perdida sin error). La prueba con `ValidateScopes` true y false es la que pedí; «no probado» para el cruce mientras PC-11 siga abierta. |
| P-13 | APLICAR (ADR ya; ramas tras la segunda ronda) (§2) | sí | El puerto sin MEAI y el vencimiento son reversibles; la rama A sólo con PC-12. |
| P-14 | APLICAR | sí | Salida codificada sin `MarkupString` es control de LLM05; cookie y `Routes` como desvío declarado, tomados por copia (DC-05). |
| P-15 | APLICAR | sí: el defecto nació en N1/N4/N6 y se remite | Herramientas como entrada obligan a pasar por el caso de uso (M1); 0 `SaveAsync` en ESC-03. |
| P-16 | APLICAR | sí: corrige el texto, no el código (R-ESCR) | Enunciar lo que el código hace cumplir quita garantías falsas. |
| P-17 | APLICAR (rama que gane la segunda ronda de C1-38) | sí | Cierre de compilación + `diff -r = 0` sin escribir en el original; la normalización vive fuera del árbol copiado. Mi voto fue la rama A; la B queda escrita. |
| P-18 | APLICAR | sí: N6 | Filtro por `SessionId` en servidor y sin campos de la persona; advertencia de celda chica (PC-15). Exposición de datos personales es lo menos reversible del dominio. |
| P-19 | APLICAR | sí: N3b/N5 | Saca una cifra de otro modelo que induciría decisiones falsas. |
| P-20 | APLICAR | sí | Truncamiento silencioso pasa a error visible. |
| P-21 | APLICAR (§2) | sí: Sondeo, donde nacieron las cifras | Tabla reproducible por script. |
| P-22 | APLICAR (definiciones ya; candidato en la demo según P-05) | sí: N3 | Abstención y no respondibles evitan un RAG que inventa con confianza. |
| P-23 | APLICAR (rama que gane) | sí | «No se suma pieza que el perímetro no tenga» es la regla que pedí. |
| P-24 | APLICAR | sí | Tasa con N chico no sostiene garantías; invariantes en `Cableado/`. |
| P-25 | APLICAR (§2) | sí | `Inconclusive` en vez de verde silencioso; cabeceras R-LLM sólo agregan. |
| P-26 | APLICAR | sí: N4 | Saca `npx -y` sin versión y la aprobación cableada en `true`; prueba de 0 ejecuciones. |
| P-27 | APLICAR (M13 donde quede el servidor MCP) | sí | M14 con 0 bajas, M15 con 400, M13 con prueba de `Host`; lo caro va a CTX-PROD con motivo, no se pierde. |
| P-28 | APLICAR | sí: fundación por notas | No reescribe la fundación; corrige las anclas de REED-16 C2. |
| P-29 | APLICAR (§2) | sí, con la remisión en N1 | Nada «ejecutado» sin compilar con `sdk:10.0`. |
| P-30 | APLICAR | sí | Reemplaza una prueba que no puede fallar (el `grep`) por una con caso rojo; la mutación va sobre la copia. |
| P-31 | APLICAR | sí | Los ids nuevos valen para la guía; los de la bitácora no se renombran (mi condición de C1-32 se cumple). |
| P-32 | APLICAR | sí: compuerta en REED-16 y tensión 8 | Cero NU19xx en el camino por defecto o aviso declarado con GHSA; consulta el día de publicar. Reduce riesgo de cadena de suministro. |
| P-33 | APLICAR | sí: N1/N1b | Parámetros del fabricante por configuración; no afirma lo que PC-05 no cerró. |
| P-34 | APLICAR | sí: pedido (REED-16 §6.2) y núcleos | Bloquea sólo lo necesario (secciones con S1 abierto, «validado», cierre). |
| P-35 | APLICAR (común ya; rama tras PC-13 y la segunda ronda) (§2) | sí | La invariante M3 protege los datos en las dos ramas; mi voto era la B. |
| P-36 | APLICAR | sí | Elección reversible por variable; rótulo provisional evita afirmar lo no comparado. |
| P-37 | APLICAR (§2) | sí: laboratorio | Contenedor propio bajo demanda: reversible, no es §12 fila 4 (ese servidor está dado de baja). El riesgo es la contingencia, cubierto por la condición. |
| P-38 | APLICAR | sí: N5 | Un juez no calibrado como compuerta da seguridad falsa; queda como método y «no medido». |
| P-39 | APLICAR | sí | El selector por `/v1` sin `num_ctx` queda fuera de la demo: evita truncamiento silencioso. |
| P-40 | APLICAR | sí | La cancelación libera el modelo; eventos de etapa compatibles. |
| P-41 | APLICAR | sí | Evita filtrar MEAI a Application. |
| P-42 | APLICAR | sí | Fuente única evita telemetría huérfana (control invisible). |
| P-43 | APLICAR | sí | Fallar al arrancar evita un índice con vectores incomparables, difícil de limpiar una vez cargado. |
| P-44 | APLICAR | sí: N5 | No inventa un campo que contradice la copia literal; PC-14 registrada. |

## 4. Escalada

Ninguna. Revisé los siete disparadores de REED-16 §12 contra los 44 parches: no hay ambigüedad de intención (1), ni conflicto entre restricciones duras (2: el servidor de pruebas está disponible por variable y turno), ni cambio de alcance (3: nada toca `Lab-E2E.WebBlazor` ni la nube), ni irreversibilidad con impacto real (4: lo único irreversible es el push, que P-01 bloquea), ni consecuencia externa (5), ni empate persistente (6: la segunda ronda todavía no se votó), ni reapertura de una DC-0n (7: «sólo agregado» no es DC).
