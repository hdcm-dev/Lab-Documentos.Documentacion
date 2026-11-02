# Panel AH-01 · Seguridad de apps con LLM · mesa de recuperación (2026-10-28)

**Mandato.** Fronteras de confianza entre el modelo y el código: inyección (directa e indirecta), salida insegura hacia la persona o hacia el sistema, agencia excesiva y aprobación, aislamiento entre sesiones, credenciales, exposición del servidor, consumo sin límite, validación de lo que propone el modelo y privacidad (R-PRIV, agregados). Me abstengo en versión, estadística, didáctica, rendimiento y nomenclatura.

**Fuentes.** Matriz `01-Matriz.md` (esta carpeta). Guía base 0.10.1 y Examples en la ruta canónica. Verifiqué en la base, sin compilar ni correr contra el modelo:

- `Examples/03-Salida-Estructurada/Infrastructure/AI/GarantiaDelTexto.cs` (l. 22-47): descarta `CodigoPostal` y `Habitantes` si el número no aparece en el texto. Nombre y provincia no pasan por esa garantía.
- `Examples/11-Agente-Con-Aprobacion/Pruebas/AgenteConAprobacionTests.cs`: está `Aprobacion_ArgumentosAlterados_SeRechaza` (l. 110, el pedido alterado) y `BajaAprobada_EnDosPeticiones_ConLaAgentSessionSerializada` (l. 22). No hay ningún caso con la sesión guardada alterada.
- `Examples/17-Observabilidad-Y-Pipeline/Infrastructure/PipelineObservado.cs` (l. 65-66): `UseDistributedCache(cache)` usa la clave por defecto, sin sesión.
- Guía, E.3 (l. 4873 y siguientes): pide que el servidor «escuche fuera del *loopback*» y no advierte que Ollama no autentica.
- Guía, l. 141 y l. 1964: la sesión aísla pero no autentica. Ya está declarado, y es la base de mis votos sobre caché y ciclo de vida.

## Posiciones

| Ítem | Opción | Fundamento (resumen) |
|---|---|---|
| REC-01 | abstención | Versión y estado editorial, fuera de mi mandato. |
| REC-02 | A | Las cifras de seguridad (DEP-09, PD-6, 16, DEP-03) son de un servidor retirado. Tienen que entrar sí o sí en la fase con modelo, con criterio previo y «caída = no medido». |
| REC-03 | A | La relectura tiene que incluir seguridad y la compuerta R-PRIV sobre la guía ya integrada y re-corrida. |
| REC-04 | A | Los informes traen fugas R-PRIV (RPRI-18). Sólo pueden pasar pieza por pieza, redactados y con el barrido en 0. |
| REC-05 | abstención | Embeddings y publicación: decisión de entorno y del PO. |
| REC-06 | A | El lote cierra exposición real en un repo público (RPRI-01 a 03, 16, ESTA-27). Aplicarlo a medias deja fugas. |
| REC-07 | abstención | Sobre el arnés me inclino por A, que mantiene los nombres de recursos fuera del repo, pero es un tema de arnés y de evidencia. |
| REC-08 | abstención | Rendimiento y entorno. |
| REC-09 | A | Si un parcial cortado entra al historial como completo, el estado de la conversación queda corrupto, y la vuelta siguiente lo toma como dicho por el asistente. Con pruebas de cableado alcanza. |
| REC-10 | abstención | Fidelidad del protocolo. La frase de tool_choice se discute en REC-15 y REC-20. |
| REC-11 | A | Una credencial en el cuerpo termina en las capturas que la guía enseña a guardar. Hace falta la regla y además la compuerta «cabeceras=0», porque la prosa sola no se verifica. |
| REC-12 | A | Sin la sesión en la clave, B recibe la respuesta de A. Es una fuga entre sesiones en CTX-SENS, y la sesión es la única frontera del caso (l. 1964). |
| REC-13 | A | Consumo sin límite (OWASP LLM10). Un limitador en la entrada HTTP cubre la API y Blazor y falla cerrado con 503 y Retry-After. |
| REC-14 | A | Un Singleton con estado cruza sesiones en silencio. Hace falta la prueba roja, porque ValidateScopes=true recién falla en la llamada. |
| REC-15 | abstención | Elección del modelo. Para seguridad alcanza con que D6 entre por REC-20. |
| REC-16 | A | 3400 pasa las reglas del dominio. La garantía del texto lo descarta (l. 27-31), pero ninguna prueba lo muestra. Sumar la prueba sin modelo y el caso a §8.5. |
| REC-17 | A | La validación tiene que vivir en Domain. Esas entradas también llegan por la API sin pasar por el modelo. |
| REC-18 | abstención | Evaluación. |
| REC-19 | abstención | Estadística. |
| REC-20 | A | La aprobación impuesta por el código es el control correcto contra la agencia excesiva. X2 y D6 del insumo muestran por qué. DEP-09 y PD-6 se re-corren. |
| REC-21 | A | El truncado silencioso puede sacar las instrucciones del sistema. Un detector que lanza falla cerrado y complementa la guarda. |
| REC-22 | abstención | Rendimiento. |
| REC-23 | A | Repetir el texto inyectado es salida insegura hacia la persona (LLM05). Hay que mostrarlo, rotulado, y la garantía en una frase es verificable. |
| REC-24 | A | La imagen escucha en todas las interfaces y Ollama no autentica. E.3 empuja hoy a esa exposición sin advertirla. |
| REC-25 | A | Extender la garantía a las escrituras y el caso ReadOnly que no decide. Sin el token, que sería una autenticación a medias. |
| REC-26 | A | La quinta regla es la que acota la frontera real: Presentación sólo llega a la IA por Chat.razor. AC-5 no se presenta como suficiente. |
| REC-27 | A | Verificado: no hay caso de sesión guardada alterada. Corresponde un caso rojo, la guarda y el límite en §8.7. |
| REC-28 | abstención | RAG y didáctica. |
| REC-29 | A | Ollama no impone el enum. La salida del modelo se valida en el código. La afirmación sin consulta es un caso observable. |
| REC-30 | abstención | Migración. |
| REC-31 | A | El párrafo y las referencias van en §11.4. Prefiero A sobre C porque en el caso cada sesión ve sólo sus datos, y el control le hace falta a CTX-PROD con datos compartidos, no a la demo. |
| REC-32 | abstención | Terminología. |
| REC-33 | A | Adoptar el dictamen §1–§2. Un sed acotado por mapa con diff en los .log no fijados, y barrido en 0 antes del commit. |
| REC-34 | abstención | Sin objeciones de seguridad a las coincidencias. |
| REC-35 | abstención | Mantenimiento de paquetes. |

## Fundamentos por ítem

**REC-02 (A).** De la base, DEP-09, el humo de PD-6, la pieza 16 (0/6 de inyección) y DEP-03 son evidencia de seguridad medida en el servidor compartido retirado. Si se rotulan como historia y no se re-corren (B), la guía afirma controles sin medición vigente. C deja afuera DEP-09 y DEP-03. D es aceptable, pero el reparto de A ya cuida el cupo. Condición: los registros de la re-corrida van fuera del árbol y pasan por la compuerta «cabeceras=0» (REC-11) antes de citarse.

**REC-03 (A) y REC-04 (A).** B relee antes de que existan las cifras vigentes de seguridad. C achica el panel y deja sin mirar remisiones de §8 y §11 que cambian por REC-12, 14, 16, 20, 23 y 27. Los 13 informes del insumo no pueden entrar en bloque, porque traen fugas (RPRI-18). Por eso, pieza por pieza con DECI-30.

**REC-06 (A).** La opción B deja en un repo público volúmenes, contenedores, etiquetas y rangos literales (RPRI-01 a 03, ESTA-27) y `Reanudar.md` (RPRI-16, S1). El orden 1 a 8 con verificación final está bien. Pido que el barrido ampliado corra también sobre las capturas nuevas de REC-02.

**REC-09 (A).** En la base, `AsistenteDeAyuda.cs` l. 46-70 agrega la respuesta sin mirar el token. El insumo midió 10/10 «no cancelada» con OllamaSharp 5.5.0. Un parcial guardado como completo puede ser una negativa a medio armar o un dato a medio decir, y el modelo lo va a tomar como contexto propio. C declara el antipatrón y deja el código que lo comete, lo que contradice el principio de que la garantía la pone el código.

**REC-11 (A).** Una credencial que viaja en el cuerpo queda en las capturas que la guía enseña a guardar, y se vuelve una fuga persistente. C confía en la prosa. A suma la compuerta mecánica, que también protege las capturas de REC-02. La propiedad no se nombra (R-PRIV); alcanza con «las cabeceras que se agregan al pedido».

**REC-12 (A).** `PipelineObservado.cs` l. 65-66 usa la clave por defecto. La sesión es la única frontera entre visitantes (l. 141, l. 1964), y una caché sin sesión en la clave la anula: B recibe la respuesta de A. Con herramientas sobre datos mutables, además, un acierto sirve datos viejos después de una escritura. Eso choca con la presentación actual de §12.3 y ADR-09 («un acierto no vuelve a ejecutar las herramientas») como ventaja. C deja el ejemplo 17 enseñando el patrón inseguro.

**REC-13 (A).** NUM_PARALLEL=1 y pedidos de 167 s: sin límite, un solo cliente satura el modelo para todos. El ConcurrencyLimiter en la entrada HTTP es la capa correcta, porque cubre la API y Blazor y responde 503 con Retry-After en vez de encolar sin fin. La prueba tiene que ser determinista (AH-02-07). La capa del cliente queda como alternativa.

**REC-14 (A).** El insumo midió que, con Singleton y ValidateScopes=false, B ve y borra lo de A sin error, y que con true falla recién en la llamada a la herramienta. Por eso la prosa (C) no alcanza: el error no aparece al construir y un lector no lo descubre. En Blazor, Scoped es el circuito, y el DbContext necesita la fábrica.

**REC-16 (A).** Verifiqué que `GarantiaDelTexto.Aplicar` descarta el CP si no está entre los números del texto. Con «CP 34», el número del texto es «34», y «3400» se descarta. La defensa existe, pero no está probada. §8.5 apoya la defensa en SaveAsync, y 3400 pasa SaveAsync. A suma la prueba sin modelo que lo muestra y corrige el argumento. También hay que declarar que nombre y provincia no pasan por esa garantía, y que los cubren los catálogos y las reglas.

**REC-17 (A).** Un CP con dígitos arábigo-índicos y un nombre de 61 caracteres también entran por la API sin pasar por el modelo. Endurecer sólo el normalizador de IA (C) deja la otra vía abierta y además vuelve falsa la frase de l. 1075. Las pruebas van primero, y el cambio a Domain queda en la fila «Modificado a causa de la IA» que ya existe.

**REC-20 (A).** El 70/70 de la base prueba que la aprobación la impone el código, que es el control contra la agencia excesiva (OWASP LLM06). La evidencia vigente del insumo (X2: el 4b borra sin confirmar en 10/10, y D6) es justamente el argumento para no confiar en que el modelo confirme. Citarla rotulada fortalece ADR-06. D reabre una demo sana sin ganancia de seguridad. B deja DEP-09 y PD-6 sin medición vigente.

**REC-21 (A).** Con 4096, el 4b recibe 2.050 de 5.114 tokens en silencio. Lo que se pierde puede ser el prompt del sistema o la delimitación del contenido no confiable, así que el truncado también es un riesgo de seguridad, no sólo de calidad. Un detector que lanza falla cerrado y complementa la GuardaDeTruncado, que sólo marca el registro.

**REC-23 (A).** El modelo repitió el texto inyectado en 10/10. No escribe, pero es salida insegura hacia la persona (OWASP LLM05), y la guía tiene que mostrarlo. La frase única («ninguna escritura depende del texto: o no hay herramienta que escriba, o toda escritura espera aprobación con su contrato») es verificable contra el código y no depende de una tasa del modelo. La cifra vigente sale de re-correr 16.

**REC-24 (A).** E.3 pide escuchar fuera del loopback sin advertir nada. La imagen trae el comodín en OLLAMA_HOST, y Ollama no tiene autenticación: cualquiera en la red puede usar el modelo, bajar o borrar modelos. Hay que advertir que se publique sólo a la interfaz del bridge o a 127.0.0.1. El compose de la base ya lo hace bien, así que el cambio es de prosa y no rompe nada.

**REC-25 (A).** Extender `DescripcionDelCliente` a las escrituras cierra una brecha real: hoy una escritura podría describirse distinta de lo que hace. El caso ReadOnly muestra que una anotación no decide nada. Rechazo C porque un Bearer sobre loopback, que la propia opción declara «no es OAuth 2.1», enseña una autenticación a medias y puede dar una falsa sensación de seguridad. Es mejor que la guía diga explícitamente que el ejemplo no autentica y remita a la especificación. D no aporta seguridad.

**REC-26 (A).** §13.12 reconoce que nada acota la excepción de Presentación a Chat.razor. Esa es la frontera por donde la interfaz llega al modelo, y es la regla que más protege. Las mutaciones prueban que las reglas detectan algo, y el grep de AC-5 no detecta R4. Tiene que quedar dicho.

**REC-27 (A).** Verificado: 11 cubre el pedido alterado (l. 110) y la sesión serializada en dos peticiones (l. 22), pero no una sesión guardada y alterada antes de deserializar. MAF 1.26.0 ejecuta lo que dice esa sesión. Corresponde el caso rojo, la guarda contra la copia aprobada y el límite declarado: si se comprometen los dos almacenes, la guarda no alcanza.

**REC-29 (A).** Ollama no impone el enum (6/10 fuera de catálogo con el 0.5b). Eso confirma que la validación de la salida estructurada es tarea del código, no del formato pedido. Afirmar «cero» sin consultar la herramienta es un dato inventado presentado como hecho. El oráculo tiene que detectarlo, y la regex no lo hace.

**REC-31 (A).** La celda mínima, la supresión complementaria y el límite de cruces son necesarios en CTX-PROD por la Ley 25.326. En el caso, cada sesión ve sólo sus datos (l. 141), así que un control en código dentro de la demo o del ejemplo de agregados (`ResultadosDeEncuestaService`, `FuenteDeResultados`) no protegería a nadie y reabriría piezas sanas. Por eso, prosa en §11.4 y referencias en D.9.

**REC-33 (A).** El dictamen resuelve el conflicto en el único sentido seguro: R-PRIV le gana a «sólo agregado», y sólo para borrar lo prohibido. Un sed por mapa de valor exacto, con diff, es auditable. Las capturas fijadas por hash quedan con sus valores declarados históricos y no se reescriben. C deja en los .log no fijados nombres que no hace falta conservar. B posterga una fuga conocida.

## Condiciones transversales de seguridad (para el plan de integración)

1. Todo registro o captura nueva de REC-02 pasa por el barrido R-PRIV ampliado y por la compuerta «cabeceras=0» antes de citarse o de entrar al árbol.
2. Ninguna cifra del insumo se cita sin el rótulo de estación, el estimando y «una entrada, N semillas». Esto es por REC-19, en el que me abstengo en lo metodológico.
3. Los casos rojos nuevos (REC-12, 14, 16, 17, 27) corren sin modelo y entran a la verificación de build. Un control de seguridad que sólo se prueba con el modelo no cuenta como probado.
