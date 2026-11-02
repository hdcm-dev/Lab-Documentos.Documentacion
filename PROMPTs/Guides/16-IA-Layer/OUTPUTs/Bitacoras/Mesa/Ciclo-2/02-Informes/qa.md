---
doc_id: BIT-16-MESA-C2-QA
doc_type: informe-de-especialista
title: Informe de Verificación/QA sobre la estructura aprobada v1
role: Verificación/QA (núcleo permanente)
objeto: ../../../04-Plan-De-Integracion.md (v1, ESTRUCTURA APROBADA v1)
modo: a ciegas (ver la nota de independencia al final)
fecha: 2026-10-26
---

# Informe de Verificación/QA — Ciclo 2

Mandato: oráculos y criterios de prueba de la v1, pruebas no deterministas, AC-1…AC-10 y los ajustes AJ que no se verificaron.

Las líneas citadas son las de `04-Plan-De-Integracion.md` v1 (1.003 líneas al 2026-10-26). No repito hallazgos del ciclo 1 ya corregidos. Todo lo que sigue es nuevo, o lo introdujo un parche o un ajuste AJ.

## Hallazgos

### QA-01 · S2 · E2 · confianza 0,85 — AJ-03 contradice AC-3b, y el conjunto que AJ-03 prioriza tampoco entra en el tope

- **Ubicación**: §E.5, línea de corte 1 (l. 671) y tabla (l. 666); §F.10 AC-3b (l. 818); §G.3 DEP-03 (l. 862).
- **Afirmación**: AJ-03 manda que, si después del recorte el pesimista de A sigue por encima de 4 h, «lo que exceda el tope pasa a "no ejecutado contra el modelo"». Pero AC-3b exige que **cada** ejemplo de nivel A tenga un registro R-LLM válido. Lo «no ejecutado» se admite sólo para el nivel B. Además, la misma l. 671 dice «Ningún ejemplo de A baja a "sólo cableado" sin que la mesa lo registre», y AJ-03 lo baja de forma automática. Con las cifras del propio plan, la línea de corte se dispara siempre:
  - Pesimista de A: ≈ 144 × 200 s = 8,0 h.
  - Después del recorte (estabilidad −15, 09 −6, 04 −3): ≈ 120 llamadas, unas 6,7 h.
  - El conjunto priorizado sólo, con los t de AJ-02: PD 12 + 07 16 a 475 s, más 08 16 + 09 15 a 200 s, son 19.500 s, unas 5,4 h. Ya pasa el tope de 4 h.
  - Encima, la tabla de A cuenta DEP-03 dentro de las sondas de `<recurso-compartido>` (l. 666), y §G.3 dice que DEP-03 es «sin `<recurso-compartido>`» (l. 862).
- **Ancla**: l. 671: «lo que exceda el tope pasa a "no ejecutado contra el modelo", sin cifras y como deuda, igual que el nivel B (AJ-03)». l. 818: «Cada PD-1…PD-6 y cada ejemplo de nivel A de §E.5 tiene **al menos un registro R-LLM válido** […] Los de nivel B tienen registro válido, o la guía los marca "no ejecutado"». l. 666: «sondas DEP-03, DEP-09, DEP-10 y DEP-13 (20)». l. 862: «Sonda corta, sin `<recurso-compartido>`».
- **Impacto**: si la corrida respeta el tope, AC-3b no se cumple y no hay cierre. Si se cierra igual, AC-3b se viola sin que nadie lo vea. El «no ejecutado» automático puede alcanzar incluso a PD-n, que la tesis de la guía necesita.
- **Dirección**: AC-3b y §E.5 tienen que decir lo mismo.
  - Definir qué subconjunto es obligatorio para el cierre.
  - Si el pesimista de ese subconjunto supera el tope, la mesa decide **antes** de construir: subir el tope o achicar el subconjunto. La degradación no queda implícita.
  - Sacar DEP-03 del conteo de `<recurso-compartido>`.
  - Ratificar el renombre T-A/T-B/T-C pendiente del ciclo 1. Así el script de AC-3b distingue «nivel de turno» de la columna «Nivel» de dificultad (l. 623: hoy 01 es Nivel B y Turno A).

### QA-02 · S2 · E2 · confianza 0,8 — El esquema R-LLM no deja medir el consumo de turno que §E.5 promete controlar

- **Ubicación**: §E.1, esquema R-LLM (l. 618); §E.5, tope (l. 670); verificación (3) de PAR-15, diferida a la construcción.
- **Afirmación**: la verificación diferida de PAR-15 (3) es «la suma de las duraciones del registro R-LLM con `servidor = compartido` es ≤ 4 h». Pero el esquema sólo trae `load_duration_ms` y `prompt_eval_duration_ms`. No tiene `eval_duration`, ni `total_duration`, ni tiempo de reloj de la llamada, ni el tiempo de turno tomado. Las llamadas que superan los 600 s sin respuesta (Sondeo §0, que el plan cita) no tienen ninguna duración del servidor y no quedan en ninguna suma. Son justamente las que más turno consumen.
- **Ancla**: l. 618: «`prompt_eval_count`, `eval_count`, `load_duration_ms`, `prompt_eval_duration_ms`, `truncado_posible` …» (no hay otro campo de tiempo). l. 662: «bajo carga, más de 600 s sin respuesta». 05-Parches.md l. 676: «(3) Al cerrar la construcción, la suma de las duraciones del registro R-LLM con `servidor = compartido` es ≤ 4 h».
- **Impacto**: el tope de 4 h y la recalibración de DEP-13 no se pueden comprobar con el registro. La sonda DEP-13 tampoco puede medir t si sólo guarda la parte de prompt.
- **Dirección**:
  - Que cada línea R-LLM traiga el tiempo de reloj de la llamada, medido por el arnés (inicio y fin), y el `eval_duration` del servidor.
  - Que un timeout o un corte quede como línea `excluida` con su motivo y su tiempo consumido.
  - Que `<gestor-de-turnos>` deje un asiento por turno (tomado, renovado, liberado) para sumar contra el tope.

### QA-03 · S2 · E1 · confianza 0,85 — El «oráculo de la afirmación central» de 07 no está definido para 5 de los 12 literales

- **Ubicación**: §E.2, fila 07 (l. 633); §F.6 (l. 790).
- **Afirmación**: el oráculo es «el valor que fija el literal de la `*Policy` citada […] aparece en la respuesta y no aparece otro valor del mismo tipo». En `8fb4c3a` hay cinco literales sin ningún valor que extraer:
  - `LocalidadPolicy.RequisitoDeLaProvincia`: «Una de las provincias del catálogo.»
  - `EncuestaPolicy.RequisitoDeLaLocalidad`, `RequisitoDeLosMedios` («Al menos uno.»), `RequisitoDeLaFrecuencia` y `RequisitoDelMotivo`.

  En los que sí tienen valor, el literal lo trae en dígitos («{DigitosDelCodigoPostal} dígitos.»). Si el modelo contesta «cuatro dígitos», el oráculo, que busca el número, da falla aunque la respuesta sea correcta.
- **Ancla**: `cat src/MovilidadUrbana.ApiWeb/Application/{Localidades/LocalidadPolicy,Encuestas/EncuestaPolicy}.cs` en Lab-E2E.WebBlazor (HEAD `8fb4c3a`). Siete propiedades interpolan un valor de `*Rules`. Las cinco de arriba son texto fijo sin cifra. Plan l. 633: «Tasas k/12 de afirmación correcta».
- **Impacto**: el denominador k/12 mezcla preguntas sin oráculo con preguntas que sí lo tienen. Cada constructor va a resolver ese hueco a su manera, y la tasa que la guía muestre en §7 no va a ser reproducible.
- **Dirección**:
  - Que `conjunto-de-oro.v1.json` declare, por cada pregunta respondible, el valor esperado y sus formas aceptadas, incluidos los numerales en palabras.
  - Para los literales sin valor, un oráculo propio (por ejemplo, que la respuesta remita al catálogo y no invente un valor), o sacarlos del denominador de la afirmación central con el k/7 declarado.

### QA-04 · S3 · E3 · confianza 0,75 — Los oráculos de 08 y 12 pasan sin mirar nada: números en palabras, ids y respuestas sin cifras

- **Ubicación**: §E.2, fila 08 (l. 634) y fila 12 (l. 638).
- **Afirmación**: el oráculo «no inventa» de 08 compara los números de la respuesta (regex `\d+`) con los que devolvieron las herramientas. Tres contraejemplos lo pasan mal:
  - (a) «Tenés dos localidades en Corrientes», cuando hay tres: `\d+` no ve «dos» y el oráculo da «pasa».
  - (b) `listar_localidades` devuelve ids (l. 760). Un conteo inventado que coincida con un id también da «pasa».
  - (c) Una respuesta sin cifras siempre pasa, porque el conjunto vacío está contenido en cualquiera.

  En 12, «los porcentajes del texto coinciden (±1 punto)» se cumple igual con un resumen que no trae ningún porcentaje.
- **Ancla**: l. 634: «el conjunto de números de la respuesta está contenido en el de números que devolvieron las herramientas en esa corrida (regex `\d+`)». l. 760: «devuelve **id, nombre y provincia**». l. 638: «los porcentajes del texto coinciden (±1 punto) con `ResultadosDeEncuestaService`».
- **Impacto**: la tasa «negativas sin invención» y la de «cifras correctas» salen infladas justo en los casos que la guía usa para enseñar que el modelo no inventa.
- **Dirección**:
  - Normalizar los numerales en palabras antes de comparar.
  - Comparar los conteos sólo contra las salidas de conteo y de agregado, no contra los ids.
  - Exigir que, en las entradas legítimas, la respuesta afirme la cifra esperada. En 12, que traiga un porcentaje por cada medio del resultado.
  - La ausencia de cifra queda como un resultado aparte, no como «pasa».

### QA-05 · S2 · E1 · confianza 0,85 — Con M = 5, la regla «intervalos que no se solapan» no puede afirmar ninguna diferencia, y 16 compara variantes con M = 5

- **Ubicación**: §E.1 «Comparar variantes» (l. 616); §E.2, fila 16 (l. 642); §G.4 P-07 (l. 885).
- **Afirmación**: con Clopper-Pearson al 95 % (el del plan), 0/5 da [0; 52,2 %] y 5/5 da [47,8 %; 100 %]. Se solapan incluso en el caso extremo. Ningún par de resultados con M = 5 cumple la regla. El primer M en el que puede no solaparse es 6. Con 8, 0/8 da como máximo 36,9 % y 8/8 da como mínimo 63,1 %. Para 12 el plan ya lo declara («no responde "¿uno o varios?"»). Para 16, en cambio, informa «la tasa k/5 de pedidos de escritura inducidos, con intervalo y sin afirmar diferencias si se solapan», como si el resultado pudiera discriminar entre las variantes (a), (b) y (c). Además, las tres variantes usan las mismas 5 entradas. El diseño es pareado y la comparación de intervalos independientes lo desaprovecha.
- **Ancla**: cálculo exacto con `python3`: `1-0.025**(1/5)` = 0,5218 y `0.025**(1/5)` = 0,4782; `1-0.025**(1/8)` = 0,3694 y `0.025**(1/8)` = 0,6306. Plan l. 616: «Una diferencia de tasas se afirma sólo si los intervalos no se solapan». l. 642: «M = 5 preguntas legítimas distintas».
- **Impacto**: el ejemplo de seguridad corre 30 llamadas de B (l. 667) para un resultado que está decidido de antemano («sin diferencia detectable»). El lector puede leer «sin diferencia» como «las defensas valen lo mismo».
- **Dirección**:
  - Que §E.1 declare el M mínimo con el que la regla puede afirmar algo.
  - Que 16 diga de entrada, como 12, que con M = 5 ilustra la garantía del código (cero escrituras sin aprobación) y no compara defensas.
  - O que use una comparación pareada por entrada, declarada antes de correr, o suba M a por lo menos 6 por variante. Cualquiera de las dos tiene que cuadrar con el presupuesto de QA-01.

### QA-06 · S2 · E1 · confianza 0,8 — El barrido AC-8 no detecta identificadores compuestos ni mayúsculas en el texto

- **Ubicación**: §F.10 AC-8 (l. 823), el texto que dejó AJ-04.
- **Afirmación**: el patrón de código `\b(Reclamo|Ticket|Incidente|Linea)s?\b` exige un límite de palabra después del término. En C#, los nombres de dominio ajeno aparecen como compuestos (`ReclamoService`, `TicketId`, `IncidenteRepository`), y ninguno da positivo. El patrón de texto `\breclamos?\b` es sensible a mayúsculas y no detecta «Reclamos» al principio de una oración, ni el «Reclamo ciudadano» que R-06 ya identifica en el Sondeo (l. 852). Tampoco se dice si los patrones de texto y de código se corren sobre todos los archivos o sobre un conjunto de cada clase. «Probado contra el plan v1» sólo prueba la ausencia de falsos positivos en un texto sin código.
- **Ancla**: archivo de prueba en el scratchpad con `public class ReclamoService {}`, `new TicketId()`, `IncidenteRepository r;`, `Reclamo x;` y «Reclamos del barrio». `grep -nE '\b(Reclamo|Ticket|Incidente|Linea)s?\b'` sólo da las líneas 4 y 5. `grep -nE '\breclamos?\b'` da 0 líneas.
- **Impacto**: la compuerta de I-06 (RD-PO-4) da cero en `Examples/` y `Demos/` justo en la forma en que el código de otro proyecto entraría, y no protege la restricción dura del PO.
- **Dirección**:
  - Que el patrón de código busque el término dentro del identificador.
  - Que el de texto no distinga mayúsculas.
  - Que los dos se corran sobre todos los archivos.
  - Que AC-8 se pruebe contra un archivo de casos positivos conocidos (que tienen que dar positivo), además de contra el plan (que tiene que dar sólo excepciones).

### QA-07 · S3 · E2 · confianza 0,7 — El presupuesto de 15 cuenta 10 llamadas y los evaluadores con juez necesitan al menos 52

- **Ubicación**: §E.2, fila 15 (l. 641); §E.5, nivel B (l. 667).
- **Afirmación**: 15 corre dos evaluadores con LLM como juez (`RelevanceEvaluator` y `GroundednessEvaluator`) sobre una «entrada fija»: el registro R-LLM de 07 (16 entradas) y los 10 casos de calibración. Cada evaluador consulta al juez por cada respuesta, así que son al menos 2 × 26 = 52 llamadas. §E.5 le asigna 10. Esas llamadas llevan pregunta, contexto y respuesta: caen en el régimen largo que AJ-02 estima en 475 s o más, no en los 200 s del pesimista general. La etiqueta «B (sólo calibración)» tampoco aclara si el registro de 07 se juzga. Si no se juzga, §10.6 no tiene resultados sobre 07.
- **Ancla**: l. 641: «después `RelevanceEvaluator` y `GroundednessEvaluator` con juez local […] **Entrada fija**: el registro R-LLM de 07 […] más los 10 casos de calibración». l. 667: «15 (10 de calibración)». N3 l. 130: «Ambos están en `Microsoft.Extensions.AI.Evaluation.Quality` y usan un LLM como juez [F25]».
- **Impacto**: el nivel B queda subestimado en unas 42 llamadas, unas 2,3 h pesimistas a 200 s cada una. O 15 queda medio corrido sin que se declare qué parte.
- **Dirección**: que la fila de 15 diga qué se juzga (calibración, 07 o las dos cosas) y que §E.5 cuente llamadas por evaluador y por entrada, con el t del régimen largo. Si no entra, el corte se decide antes de construir, como en QA-01.

## Revisado y bien

1. **Cifras de intervalos y líneas base**: 10/10 compatible con 69 % (`0.025**0.1` = 0,6915) y 5/5 con 48 % (§E.1, l. 613). Azar de 06: hit@1 = 8,3 %, hit@3 = 25 % y MRR = H₁₂/12 = 0,2586 ≈ 0,259 (l. 632). Las tres cifras son correctas.
2. **AJ-02 es consistente con su fuente**: t ≈ p/9,4 + s/4 reproduce el 474,7 s de N3b X3 (4.441/9,4 = 472,4 s más la generación). El umbral de «~1.900 tokens» es el p al que p/9,4 llega a 200 s. Las sumas de §E.5 recalculadas desde las M de §E.2 dan A = 140 (≈ 144) y B = 91. Lo que AJ-02 no resuelve es el tope (QA-01).
3. **AJ-08 verificado**: BIT-16-02 §6, fila S-12 (l. 166), remite a `Mesa/Ciclo-1/01-Convocatoria.md`, y el archivo existe.

## Ajustes AJ: estado desde QA

| AJ | Estado desde QA |
|---|---|
| AJ-01 | No verificable tal como está escrito (ver la nota de independencia) |
| AJ-02 | Bien en la cifra; insuficiente para el tope (QA-01, QA-02) |
| AJ-03 | Contradice AC-3b (QA-01) |
| AJ-04 | Arregla la incompatibilidad, pero deja el hueco de QA-06 |
| AJ-05 | Los OA asignados son de didáctica, fuera de mi mandato |
| AJ-06 y AJ-07 | Sin observación de QA |
| AJ-08 | Bien |

## Solicitudes de convocatoria

- **Operación y entrega**: la contabilidad de turnos de `<gestor-de-turnos>` (QA-02) y la decisión sobre el tope de 4 h (QA-01) son de operación, no de QA.
- **Didáctica**: la ratificación de los OA de AJ-05 y el criterio de T-A/T-B/T-C para el lector.

## Nota de independencia

Un `grep -rn` que corrí sobre toda la carpeta `Bitacoras/` para descartar repeticiones del ciclo 1 devolvió, sin que yo lo buscara, dos líneas de los informes de este ciclo (`Ciclo-2/02-Informes/desarrollo.md` y `operacion.md`). Las dos tratan el mismo defecto de AJ-01: ni el tipo de servidor ni el origen de `OLLAMA_NUM_CTX` tienen variable ni fuente (l. 596, l. 601–608, l. 618). Yo lo había anotado antes de verlas, pero ya no es una observación independiente. **No lo emito como hallazgo**, para no inflar el conteo ni contaminar la medición de homogeneidad. Lo dejo registrado para la secretaría. No leí nada más de esa carpeta.
