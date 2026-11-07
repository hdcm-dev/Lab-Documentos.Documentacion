Método: condensación fiel, con cita de regla y sección, de `Rule-Expediente.md` 1.0, `Rule-Escalas-De-Juicio.md` 1.2, `Rule-Mesa.md` 1.1 y `Rule-Detencion-Y-Lote.md` 1.1 (IA/IA.Knowledge.Base/Rules/), para que los roles de la mesa carguen esto en lugar de las reglas enteras
Fecha-hora: 2026-11-07 08:30 -0300
Quién: secretaría de la mesa

# Pliego operativo — expediente 0001, guía de estudio IA-Model

Este pliego transcribe o condensa; no opina. Ante cualquier duda manda el texto de la regla citada.

## 1. Forma del folio (Rule-Expediente)

**Nomenclatura** (§3.1): un archivo por folio en `actuaciones/`, nombre `NNN-<tipo>-<slug>.md`
(`<slug>` en minúsculas, dígitos y guiones). El folio son tres dígitos contiguos desde `001`,
asignados al incorporar: el siguiente libre, nunca uno reservado. La evidencia se nombra
`NNN-<slug>.<ext>`, por posición. El número de expediente y el de folio no se declaran en el texto:
se leen de la ruta.

**Cabecera** (§3.3): arriba, una tabla de dos columnas con cuatro filas, cada una una vez:
`Tipo` (uno de los seis de §3.4, igual al del nombre del archivo); `Fecha` (ISO 8601, `AAAA-MM-DD`);
`Autor` (un rol, nunca un nombre propio); `Corrige` (`—`, o el número de tres dígitos de un folio
anterior que corrige).

**Pase** (§3.3): como última línea no vacía, `Sigue: <acto> · <quién>`. Si el acto que sigue tiene un
evento observable que lo cierra: `Sigue: <acto> · <quién> · Cierra con: <artefacto §sección>`. Cuando el
folio despacha agentes, el pase nombra además los despachos abiertos, los insumos, qué se invalida si la
corrida se corta y las escaladas abiertas con lo que pasa si nadie responde. **Un folio `archivo` no
lleva pase.**

**Los seis tipos de actuación y el estado que derivan** (§3.4, conjunto cerrado):

| Tipo | Qué es | Estado en que deja el expediente |
| --- | --- | --- |
| `presentacion` | Una parte presenta el caso | **abierto**; **reabierto** si su `Corrige` nombra una `resolucion` o un `archivo` |
| `providencia` | Impulso del trámite: convoca, despacha, ordena | **en trámite** |
| `informe` | Comisión, refutador, jurado, auditor o quien coordina, verbatim y con autor | **en trámite** |
| `constancia` | Un hecho, una corrección propia, una incorporación de antecedentes, una redacción (§3.8) | **en trámite**; **suspendido** si lleva `Suspende hasta: <artefacto §sección>` |
| `resolucion` | Decide, motivada, con veredicto por criterio | **resuelto** |
| `archivo` | Cierra, con `Motivo: <aplicado y verificado \| cerrado por decisión, con lo abierto enumerado \| desistido>` | **archivado** |

**El estado se deriva de la secuencia, no del último folio a secas** (§3.4): (1) un folio con `Corrige`
distinto de `—` no cambia el estado, salvo la reapertura; (2) reabrir es una `presentacion` cuyo
`Corrige` nombra la `resolucion` o el `archivo` que reabre, y sólo con una contradicción anclada en un
resultado reproducible o una cita literal con archivo y línea; (3) después de un `archivo` sólo caben una
reapertura o una `constancia` con `Corrige` (errata); (4) `Suspende hasta:` rige hasta el folio
siguiente. El índice es el listado de `actuaciones/`; nada derivado se escribe a mano (§2).

**Verbatim** (§3.3): donde el adoptante no tiene otro registro para los actos de una mesa, cada informe
de comisión, de refutador, de jurado o de auditor entra como folio `informe` **sin editar**. Este caso no
tiene otro registro: el expediente es el registro.

**Testimonio** (§3.5): un folio que asienta palabras de una parte lleva un solo bloque: el literal byte a
byte entre `` ```testimonio `` y `` ``` ``, y tres filas: `Canal`, `Fecha-hora` con zona, y `Huella`
(SHA-256 del bloque tal como lo extrae E-8, entre acentos graves). La respuesta del PO a una escalada se
asienta así, sin editar la escalada (Rule-Mesa §3.6.1).

## 2. Escalas de juicio (Rule-Escalas-De-Juicio)

**Niveles P0–P3** (§3.1 — definición general; la lectura del caso la declara el encargo, §3.2):

| Nivel | Qué es | Qué se hace |
| --- | --- | --- |
| **P0** (bloqueante) | Lo que viola una restricción dura del encargo o hace imposible el objetivo | Detiene el trabajo: nada que dependa del objeto sigue hasta corregirlo o hasta que quien decide resuelva |
| **P1** (alto) | Lo que haría salir el resultado con retrabajo, o con interpretación divergente entre quienes lo aplican | El objeto no avanza hasta corregirlo |
| **P2** (medio) | Una pérdida acotada: algo que falta o queda parcial sin romper el objetivo | Se documenta y se sigue |
| **P3** (bajo) | Claridad: redacción, estilo, orden | Se anota y se decide al cierre si se corrige |

Una sola escala: ninguna pieza usa otra escala de severidad (§3.1). Todo hallazgo declara nivel y clase de
ancla, más las marcas *aguas arriba* (con su artefacto de origen) y de detectabilidad
(`enumerable` | `interpretativo`), que se declaran además del nivel y no lo cambian (§1, §3.5).

**Clases de ancla** (§3.3, transcripta):

| Ancla | Qué es | Qué puede fundar |
| --- | --- | --- |
| **E1** | Resultado ejecutable y reproducible: una verificación que falla, un enlace que no resuelve, un comando con su salida | Una corrección directa |
| **E2** | Cita literal del objeto, con archivo y línea, que muestra una contradicción, una ambigüedad o una omisión | Una corrección directa |
| **E3** | Contraejemplo construido o recorrido reproducible: un caso concreto que el objeto no resuelve | Una corrección directa |
| **E4** | Regla declarada: una obligación del conjunto normativo vigente, o una restricción dura o una decisión cerrada del encargo | Una corrección directa |
| **C** | Conjetura, experiencia general, «suele ser mejor», o un hallazgo heredado de un informe anterior que no se abrió | **Sólo una pregunta.** Nunca una corrección |

Un `C` que sobrevive dos ciclos de juicio sin subir de clase se descarta y se registra como descartado
(§3.3). Un testimonio no es E4 por sí mismo: pasa a E4 cuando queda asentado en el encargo como
restricción dura o decisión cerrada (§3.3).

**Reglas de anclaje** (§3.4):

1. **Un P0 anclado en una fuente declarativa se contrasta antes de proceder**: una fila de plan, una
   casilla, un campo de estado o un recuento en prosa son afirmaciones sobre el trabajo y no el trabajo;
   quien emite el hallazgo abre la fuente y la contrasta con su observable; sin contraste no llega a P0.
2. **Una afirmación de colisión o de no colisión de un término se ancla sólo en E1**: lleva el comando que
   localiza sus ocurrencias en el contexto de lectura, con su salida; sin él es `C`.
3. **Una cita de lo construido no funda una corrección sobre una decisión que el encargo declara
   cerrada**: muestra una deriva, no un defecto del documento; la corrección va a su origen o a una
   decisión nueva aprobada por quien puede decidirla (la delegación declarada; lo aditivo y reversible
   propio del destino lo decide quien trabaja y lo declara, `Rule-Detencion-Y-Lote.md` §3.2 clase 6).
4. **Un hallazgo heredado** de un informe anterior entra como `C` hasta que quien lo trae abre su fuente y
   le da una clase E. (Un hallazgo de clase `C` sólo funda una pregunta, §3.3.)

## 3. La mesa (Rule-Mesa)

**El registro y sus partes** (§2): la mesa produce un artefacto, el registro de mesa; acá el expediente es
el registro, con sus partes repartidas en folios. Se escribe siempre, aunque la mesa no encuentre nada.
El plan de cambios es una sección del registro, no un artefacto aparte. Partes, en este orden:

1. **Cabecera**: objeto, fecha, desde dónde se convocó, el contrato de entrada de §3.3 transcripto, y el
   prefijo de familia que el ciclo usa para sus hallazgos (propio del ciclo, no reusa familias presentes);
   nombra la carpeta del expediente.
2. **Registro de convocatoria**: convocados con su señal y ubicación, descartados con su motivo,
   postergados por cupo, y agentes ad hoc con su carta de mandato.
3. **Resultado de la compuerta mecánica** (§3.5.2), con el alcance que declaró no haber mirado.
4. **Informes del panel**, uno por especialista, con sus hallazgos y su bloque «lo que revisé y está bien»
   (hasta tres ítems, §3.4.3).
5. **Tabla de veredictos**, un hallazgo por fila, con el reparto de votos y el fundamento de cada uno.
6. **Parches aprobados**, con texto exacto, capa de origen, derivados a revalidar y criterio de verificación.
7. **Deuda declarada**: los hallazgos reales que se decidió no corregir, con su motivo.
8. **Escaladas**, agrupadas, con la forma de §3.6.1.
9. **Bloque de cierre** (§3.5.7; esqueleto abajo).

**Contrato de entrada** (§3.3): lo aporta quien convoca; la mesa no arranca sin esto y no lo releva ella.
Si un campo falta, ése es el primer hallazgo del registro, y la mesa sigue con un supuesto declarado, sin
preguntar. Siete campos:

| Campo | Qué lleva |
| --- | --- |
| `objeto` | Qué corpus se evalúa, con su ubicación y su volumen |
| `estado` | El estado leído del corpus, con sus divergencias declaradas |
| `diff_normativo` | Qué cambió en las normas que rigen el objeto entre la versión de la que procede y la vigente, artefacto por artefacto |
| `restricciones_duras` | Lo no negociable del objeto: reglas declaradas de su dominio, apartamientos vigentes |
| `decisiones_cerradas` | Lo ya decidido que no se reabre salvo contradicción demostrada (con ancla E1 o E2, no «mejorable») |
| `fuera_de_alcance` | Lo que la mesa no toca |
| `pendientes_declarados` | Hallazgos abiertos, filas de plan sin resolver e ítems diferidos, con su evento de cierre; entran como clase `C` hasta anclarse |

**Composición del panel** (§3.4). Núcleo permanente (§3.4.1), se convoca siempre:

| Rol | La pregunta que responde |
| --- | --- |
| **Requisitos** | ¿Cada afirmación del corpus es unívoca, atómica y verificable? ¿Qué falta? |
| **Verificación** | ¿Cómo se prueba cada afirmación? ¿Qué quedó declarado sin criterio de aceptación posible? |
| **Lector sin contexto** | ¿Alguien que no participó puede trabajar con esto sin preguntar nada? Cada pregunta que necesita hacer es un hallazgo |
| **Refutador** | Ataca la lectura dominante del corpus y lo que los demás sostienen. Entra último, después de leer al resto (única excepción a la ceguera) |

Catálogo variable (§3.4.2): cada especialidad se activa por una señal observable en el corpus, citada con
su ubicación; sin ubicación no hay convocatoria. Roles: Arquitectura; Formal (convocatoria automática si
aparece su señal: umbrales, pesos, cuantificadores); Datos y dominio; Seguridad; Operación y entrega;
Concurrencia y tiempo; Rendimiento y costo; Interfaz externa; Cumplimiento; Uso y accesibilidad;
Trazabilidad documental. No se duplican roles que el espacio ya tiene. Ad hoc (§3.4.4): lo que ni núcleo
ni catálogo cubren entra con carta de mandato (señal con ubicación, pregunta única, competencia y
no-competencia, tope de hallazgos, disolución); sin carta, sus salidas se descartan.

**Techo** (§3.4.5): núcleo más **cinco** variables o ad hoc por ciclo; las postergadas se registran y
entran en el ciclo siguiente. El empate en la convocatoria convoca. El panel trabaja a ciegas y en
paralelo, con tope de hallazgos declarado en el contrato; una sola ronda de convocatoria en caliente por
ciclo (§3.4.3).

**Jurado y veredicto** (§3.5.4): cinco jueces con funciones objetivo fijas — **Evidencia** (¿anclado al
nivel que declara?), **Impacto** (¿qué pasa si no se corrige, sobre qué artefacto?), **Costo y beneficio**
(¿corregir cuesta menos que no hacerlo?), **Coherencia histórica** (¿reabre una decisión cerrada?
¿contradice un veredicto del ciclo?), **Riesgo e irreversibilidad** (¿la corrección es reversible? ¿qué
se rompe si sale mal?). El jurado **vota cada hallazgo consolidado** (y, en fase de parches, la
aprobación del parche). Reglas: quórum de cinco; mayoría simple entre `PROCEDE`, `NO_PROCEDE` con su
motivo, e `INSUFICIENTE` (vuelve al especialista con pedido concreto una sola vez; a la segunda se
archiva); empate → `INSUFICIENTE` en la primera ronda, si reincide es escalada (disparador 6); veto del
juez de riesgo sólo sobre un `PROCEDE` irreversible P2/P3, y convierte el ítem en escalada; todo voto
lleva una línea de fundamento o no cuenta para el quórum; cinco a cero en más del 80 % de los ítems marca
el ciclo como sospechoso de homogeneidad y el refutador revisa los `NO_PROCEDE`. Perito: quien emitió el
hallazgo responde preguntas y no vota. El presidente no emite hallazgos ni vota (§1).

**Bloque de cierre** (§5, esqueleto):

```text
CIERRE DE MESA — {{objeto}}, {{fecha}}

  PANEL
    Convocados:     {{rol: hallazgos procedentes}}
    Descartados:    {{rol: motivo}}
    Ad hoc:         {{id: qué pregunta respondió y qué aportó}}
    Postergados:    {{rol, por cupo}}
    Aporte nulo:    {{roles a no reconvocar}}

  HALLAZGOS
    Detectados: {{n}}   Procedentes: {{n}}   Con parche: {{n}}   Descartados por C: {{n}}

  COMPUERTA
    Resultado:      {{salida}}
    No mirado:      {{recortes declarados}}

  ENTREGA A QUIEN CONVOCÓ
    Parches:            {{n}}, en {{lista de capas}}
    Deuda declarada:    {{n}}, con su evento de cierre
    Capas a revalidar:  {{artefactos derivados}}
    Escaladas:          {{n}}, agrupadas

  CIERRE
    Por criterio (dos rondas seguidas sin hallazgos interpretativos) | por decisión, con lo que quedó abierto: {{lista}}
    Contador:       {{el de este ciclo}}
```

**Disparadores de escalada, lista cerrada** (§3.6; regla general: la mesa decide sola; antes de la lista,
la prueba de materialidad de `Rule-Detencion-Y-Lote.md` §3.2 — lo aditivo, reversible, sin riesgo para el
objetivo y sin efecto externo no entra en los disparadores 3 ni 7 — y el origen del hecho de §3.1 de esa
regla, que calcula el presidente contra la base de la corrida):

| # | Disparador | Efecto |
| --- | --- | --- |
| 1 | Ambigüedad de intención irresoluble por evidencia: dos lecturas legítimas y ninguna ancla desempata | Al lote |
| 2 | Conflicto entre restricciones duras: nada satisface todas las del contrato de entrada | **Bloquea el ciclo** |
| 3 | Cambio de alcance estructural: la corrección quita o redefine lo que el objeto promete, o agrega algo estructural o que pone en riesgo el objetivo; un agregado aditivo y reversible no lo es | **Bloquea el ciclo**, salvo que el pedido foliado de quien decide sea el propio cambio de alcance |
| 4 | Irreversibilidad con impacto material | Al lote, con propuesta |
| 5 | Dominio con consecuencia externa: dinero, datos personales, obligaciones legales o de terceros | Al lote, con propuesta |
| 6 | Empate persistente del jurado tras dos rondas entre dos opciones irreversibles (entre reversible e irreversible rige la reversible; entre dos reversibles decide la presidencia y lo registra) | Al lote, con propuesta |
| 7 | Reapertura de una decisión cerrada: el panel sostiene con ancla E1 o E2 que es contradictoria, no mejorable | Al lote |

Todo lo demás se resuelve sin consultar: redacción, estructura, trazabilidad faltante, criterios de
aceptación ausentes, nombres, orden de tareas y elección técnica dentro de las restricciones dadas (§3.6).
La composición del panel nunca es motivo de escalada (§3.5.2). Las escaladas se entregan agrupadas al
cierre del ciclo; sólo las de los disparadores 2 y 3 salen en el momento (§3.6.1). Ante duda sobre si
escalar, la mesa aplica el criterio por defecto y lo registra en la deuda declarada (§3.6).

## 4. El lote de preguntas (Rule-Detencion-Y-Lote §3.5; §1 y §3.1 en lo que la mesa usa)

Forma (§5.2): una tabla, una fila por pregunta:

```text
| # | Pregunta | SI NO RESPONDÉS |
| --- | --- | --- |
| 1 | <la decisión, con su contexto en una o dos líneas y la propuesta> | <qué rige por defecto y qué queda bloqueado> |
```

Reglas de §3.5:

1. Lo que no bloquea espera al lote; el agente sigue con lo que puede avanzar.
2. Lo bloqueante son dos casos, y sólo dos: el arbitraje de las clases 2, 3 y 4 de §3.2, y la detención
   sin cuya respuesta ninguna otra unidad de la fase puede avanzar; salen en el momento.
3. El lote sale al cerrar la fase, o cuando la fase ya no puede avanzar sin respuesta, lo que ocurra primero.
4. Antes de salir, el lote se mira entero: se calcula el origen del hecho de cada detención y se aplica la
   autocorrección sobre el lote; la que se contesta con otra del mismo lote se resuelve y no sale.
5. Cada pregunta del lote lleva `SI NO RESPONDÉS`, con qué rige por defecto y qué queda bloqueado.
6. Lo que no se contesta entra al registro con su `SI NO RESPONDÉS` como «qué rige mientras tanto»: un
   default por silencio se trata como decisión vigente más un ítem diferido con un evento de cierre que se
   pueda abrir, nunca «cuando quien pidió lo pida».
7. **No se asienta por silencio**: una fila de alcance propuesta (clase 4), una excepción a una pieza que
   rige y una aprobación. Quedan propuestas o «sin aprobar», y lo que depende de ellas no se da por
   aprobado. No es esta regla lo que pasó la prueba de materialidad de §3.2.
   7 bis. Antes de salir, el lote se filtra: cada fila repasa la prueba de materialidad; la que da «se
   resuelve» sale del lote y se decide. Al lote sólo llega lo que cae en la lista cerrada de §3.2.
8. Un default no puede ser una fase irreversible: el `SI NO RESPONDÉS` dice «se espera» y lo que depende
   de esa respuesta no avanza; el resto sigue.
9. La respuesta de quien pidió se asienta con su literal: texto byte a byte, canal, fecha y hora con zona,
   y huella SHA-256; dentro del expediente, con la forma de testimonio de `Rule-Expediente.md` §3.5.
10. Las preguntas salen en un solo lote por fase, no de a una, salvo las bloqueantes de la regla 2.

Origen del hecho (§3.1, lo que la mesa necesita): se calcula contra la base de la corrida, no se declara;
lo calcula quien despacha, no quien tropezó; si no se puede calcular se trata como «de la corrida» y se
dice por qué; un hecho de la corrida va primero a la autocorrección sobre el conjunto y sólo sale
declarando por qué ella no alcanzaba.
