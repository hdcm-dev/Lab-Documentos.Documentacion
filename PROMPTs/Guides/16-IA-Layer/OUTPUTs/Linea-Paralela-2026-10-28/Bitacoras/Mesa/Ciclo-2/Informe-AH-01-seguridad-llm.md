---
doc_id: BIT-16-C2-INF-AH-01-seguridad-llm
doc_type: informe-de-mesa
title: Informe AH-01 — Seguridad de aplicaciones con LLM (relectura integral, ciclo 2)
status: emitido
origin: ai-assisted
last_review: 2026-10-28
traces: [REED-16 §10, Mesa-Evaluadora, 06-Plan-De-Redaccion §10]
---

# Informe AH-01 — Seguridad de aplicaciones con LLM

**Mandato.** ¿Lo que la guía enseña a construir es seguro de copiar? Inyección directa e indirecta, agencia
excesiva, salida insegura, datos personales, MCP (Host/Origin/token), secretos; cada riesgo con fuente y
mitigación; la demo cumple CTRL-01…15. Lectura a ciegas (sin otros informes del ciclo).

**Qué se leyó.** La guía completa (4116 líneas, de punta a punta, por partes); de `Examples/`: 07 (aprobación,
guarda, almacenes), 08 (servidor y cliente MCP: perímetro, opciones, `servidor-mcp*.json`, pruebas), 09 (README,
composición); de la demo: `Program.cs`, `appsettings*.json`, middlewares de sesión, `AsistenteController`,
`OperacionesDeLocalidad`, `HerramientasDeLectura`, `ContenidoExterno`, `TextosDeInstruccion`,
`AdaptadoresDeModelo`, `PropuestasDeLocalidad`, `ComposicionDeIA`, la página y el README.

**Evidencia propia** (`evidencia-AH-01-seguridad-llm/`, rutas reemplazadas por `<guía>/`):

| Archivo | Qué muestra | Nivel |
|---|---|---|
| `01-imagen-ollama-env.txt` | `docker image inspect` de la imagen fijada por digest: `OLLAMA_HOST` apunta al comodín de todas las interfaces | ejecución |
| `02-sonda-bind.txt` | el servidor de esa imagen, levantado con `--network none`, registra «Listening on [::]:11434»; y las tres frases de la guía que dicen «loopback» | ejecución + grep |
| `03-owasp-llm01-rag.txt` | la fuente REF-046 dice «do not fully mitigate»; la guía cita «no mitiga» | consulta de fuente 2026-10-28 |
| `04-demo-extraer-baja.txt` | el extractor de bajas concatena `Localidad.Nombre` en el mensaje de sistema sin sobre ni recorte | lectura de código |
| `05-demo-despliegue-development.txt` | sólo Development arranca; Development enciende `EnableSensitiveData`; `-p` en todas las interfaces; `AllowedHosts: "*"` | lectura de código + grep |
| `06-mcp-sin-limitador.txt` | §8.2 atribuye a `Examples/08` un límite de concurrencia que no existe | grep |

No hubo pruebas contra el modelo (R-LLM no aplica); no se compiló nada.

## Hallazgos

### AH-01--01 · S2 · técnico/seguridad — La guía afirma que Ollama escucha en loopback, y la imagen que fija escucha en todas las interfaces

- **Ubicación.** Guía §8.12.1 (l. 3108: «escucha en `127.0.0.1:11434` (`OLLAMA_HOST`)»); Anexo E.2 (l. 3991: «escucha en loopback» y «`--network host`»); `Demos/MovilidadUrbana.Asistente/README.md` l. 119.
- **Evidencia.** `ollama/ollama:0.40.11@sha256:dea72d1e…` trae `OLLAMA_HOST` con el comodín IPv4 y `11434/tcp` expuesto (`01`); al arrancarla, el registro dice «Listening on [::]:11434» (`02`). El valor de loopback es el del binario fuera de la imagen [REF-079], no el de la imagen que la guía fija. La receta de E.2 es segura tal cual (red propia, sin `-p`), pero la variante que la misma guía sugiere («con Ollama en el mismo equipo, `--network host`») o el reflejo de publicar `-p 11434:11434` dejan un servidor de modelos **sin autenticación** abierto a la red, y el lector cree que el valor por defecto lo protege.
- **Propuesta.** En §8.12.1 reemplazar «escucha en `127.0.0.1:11434` (`OLLAMA_HOST`)» por: «el binario escucha en `127.0.0.1:11434`, pero la imagen `ollama/ollama` fija `OLLAMA_HOST` en todas las interfaces (verificado en la imagen de la receta, 2026-10-28): dentro de la red `ia-guia` no sale del anfitrión; si se publica el puerto, va sólo a loopback (`-p 127.0.0.1:11434:11434`), porque Ollama no tiene autenticación». En E.2 cambiar «escucha en loopback» por «la imagen escucha en todas las interfaces de su red (ver §8.12.1)» y la frase de `--network host` por: «Sin red propia: Ollama con `-p 127.0.0.1:11434:11434` y el contenedor de la aplicación con `--network host` y `OLLAMA_ENDPOINT` sin definir». Mismo cambio en el README de la demo, l. 119.

### AH-01--02 · S3 · seguridad — El extractor de bajas de la demo mete `Localidad.Nombre` en el mensaje de sistema, sin sobre JSON ni recorte

- **Ubicación.** `Demos/MovilidadUrbana.Asistente/src/MovilidadUrbana.Asistente/Agregado/Infrastructure/AI/TextosDeInstruccion.cs` l. 35–44 (`ExtraerBaja`), consumido por `AdaptadoresDeModelo.cs` l. 62–69 como `ChatRole.System`; guía §6.6.4, §8.3.1 (CTRL-14, CTRL-15), §9.4.
- **Evidencia (`04`).** `texto.AppendLine($"- id {l.Id}: {l.Nombre} ({l.Provincia})")` para **todas** las localidades de la sesión, con el aviso como línea suelta. `LocalidadRules.NombreValido` copiada sólo exige largo ≥ 3: un nombre con saltos de línea puede inventar renglones («- id 7: Resistencia (Chaco)») o instrucciones nuevas **con el rol de sistema**, y uno largo, sin tope por la API copiada, empuja el prompt fuera de `num_ctx` (la guía mide que Ollama recorta el principio sin error, §6.5, y la demo no tiene detector de truncado). La guía enseña lo contrario: §6.6.4 «el JSON no se rompe», CTRL-15 «la salida de una herramienta se recorta», y las tres herramientas de la demo sí usan `ContenidoExterno.Envolver`. La invariante (0 bajas hasta el clic, entidad releída por el servidor) se sostiene; lo que falla es el patrón que se copia.
- **Propuesta.** En `ExtraerBaja` dejar en el sistema sólo la instrucción fija y mandar la lista como contenido externo en el mensaje del usuario: `Extraer<AccionSugerida>(TextosDeInstruccion.ExtraerBaja, ContenidoExterno.Envolver(disponibles.Select(l => new { l.Id, l.Nombre, l.Provincia }), opciones.Value.LargoMaximoDeEntrada) + "\n\nTexto: " + texto, …)` (con `ExtraerBaja` como propiedad sin parámetros), más una prueba de `Cableado/` que mande un nombre con `\n- id 99:` y verifique que el mensaje de sistema no lo contiene. Si no se cambia el código, la fila CTRL-14 de §8.3.1 tiene que decir: «en el extractor de bajas, la lista va concatenada en el mensaje de sistema, sin sobre ni recorte (deuda declarada)».

### AH-01--03 · S3 · seguridad — La receta de «despliegue» sólo arranca en Development, que enciende el contenido en la telemetría, y publica en todas las interfaces

- **Ubicación.** Guía §8.12.2 l. 3114–3124 y §9.8 l. 3460; `Demos/MovilidadUrbana.Asistente/README.md` l. 105; `Examples/09-Pruebas-Con-Cliente-Falso/README.md` l. 154; `appsettings.json` de la demo (`"AllowedHosts": "*"`).
- **Evidencia (`05`).** `TimeoutSegundos` existe sólo en `appsettings.Development.json`, así que la única configuración que arranca es Development; en Development, `ComposicionDeIA` pone `EnableSensitiveData = true` y `Program.cs` exporta por OTLP si se define la variable. O sea: la configuración documentada de la demo, con un colector, manda prompts e historial (datos de la persona) a las trazas, lo que §8.5.4 y §8.13.2 enseñan a evitar. Además `-p 5260:8080` y `-p 8080:8080` publican en todas las interfaces una API sin autenticación cuya sesión elige el cliente (`X-Sesion-Id: prueba`), con `AllowedHosts: "*"`, cuando §7.8.2 enseña a cerrarlo.
- **Propuesta.** En los tres comandos, `-p 127.0.0.1:5260:8080` y `-p 127.0.0.1:8080:8080`. En §8.12.2, agregar después del comando: «Es una receta de laboratorio: Development enciende `EnableSensitiveData` (§8.5.4) y la API no tiene autenticación (§8.3.2). Por eso el puerto se publica sólo en loopback. Para otro entorno no se usa Development: se declara `AI__TimeoutSegundos` como variable de ese entorno». Opcional: `"AllowedHosts": "localhost;127.0.0.1"` en el `appsettings.json` de la demo, como en `Examples/08` y `09`.

### AH-01--04 · S3 · evidencia — OWASP dice que RAG «no mitiga por completo» la inyección; la guía cita «no mitiga»

- **Ubicación.** Guía §6.1 l. 1358 («aclara que RAG no la mitiga»), §8.1.6 l. 2664 («Que RAG «no mitiga» la inyección también lo dice OWASP», entre comillas, como cita), Anexo D, REF-046 l. 3815.
- **Evidencia (`03`).** La fuente, consultada el 2026-10-28, dice «research shows that they [RAG and fine-tuning] do not fully mitigate prompt injection vulnerabilities». Las comillas de §8.1.6 presentan como cita una frase que la fuente no tiene, y la versión de la guía es más fuerte que la original.
- **Propuesta.** §6.1: «…y aclara que RAG y el ajuste fino «do not fully mitigate» la inyección [REF-046]». §8.1.6: «Que RAG no la mitiga por completo («do not fully mitigate») también lo dice OWASP [REF-046]». REF-046: «(inyección indirecta; RAG no la mitiga por completo)».

### AH-01--05 · S3 · coherencia — §8.2 le atribuye a `Examples/08` un límite de concurrencia que no tiene

- **Ubicación.** Guía §8.2, fila ESC-05 (l. 2686).
- **Evidencia (`06`).** Ningún `.cs` de `Examples/08` usa `RateLimit` ni `ConcurrencyLimiter`; lo que hay es `ConcurrenciaTests`, que prueba el aislamiento por sesión (CTRL-06), no un límite. Un lector de ACT-SEC daría por cubierto el consumo sin límite (LLM10) en el servidor MCP.
- **Propuesta.** Reemplazar «límite de concurrencia» por «herramientas por sesión probadas en concurrencia (CTRL-06); sin límite de pedidos (sus herramientas no llaman al modelo)», y sumar a la columna CTX-PROD: «límite de pedidos por identidad».

### AH-01--06 · S4 · coherencia — §6.1 da una sola garantía contra la inyección y §7.5 y §8.10.1 dan dos

- **Ubicación.** Guía §6.1 l. 1358: «La garantía es que el modelo no tenga herramientas que escriban (§8)».
- **Evidencia.** §8.10.1 y §8.13.7 dicen «que no haya herramienta de escritura disponible (la demo) o que toda escritura espere una aprobación (`Examples/07`)». La frase de §6.1 deja afuera la forma que la propia guía enseña en §7.5.
- **Propuesta.** «La garantía es que ninguna escritura dependa del texto: o el modelo no tiene herramientas que escriban (la demo), o toda escritura espera la aprobación de la persona con el contrato de §7.5».

## Revisado y bien

1. **El contrato de aprobación de `Examples/07` resiste lo que la guía dice que resiste.** `PedirAprobacionAsync` responde que no cuando no hay respuesta o vence el plazo. El id es aleatorio, de 128 bits y atado a sesión y conversación. Se consume una sola vez. La entidad se relee al ejecutar. La guarda `AutorizacionDeEscritura` es por ámbito, deja pasar una sola llamada y sólo si coinciden nombre y argumentos canónicos. Además, la guía declara el límite (dos almacenes comprometidos).
2. **El perímetro MCP de `Examples/08` es copiable.** Valida `Origin` antes que el token. El HostFiltering usa `AllowedHosts` cerrado, y el arranque falla con «*» o con una dirección que no es de loopback (`ReglasDelPerimetro`). El token se compara con `CryptographicOperations.FixedTimeEquals`, es obligatorio fuera de Development y viaja por `DelegatingHandler`. El cliente filtra por lista blanca y desconfía de `readOnlyHint` [REF-110]. La sesión fija está declarada como camino de inyección (§8.10.1).
3. **Salida, datos personales y sesión, bien enseñados en la guía y aplicados en la demo.** La salida se muestra con la codificación de Razor, sin `MarkupString` [REF-136]. Los agregados no llevan `Nombre` ni `Edad`, y la celda chica queda como diseño para CTX-PROD con supresión complementaria (§8.10.3). `EnableSensitiveData` va atado al entorno. La guía repite que el 404 por sesión «no es control de acceso» en §3.3, §7.3.2, §8.3.2, §8.7 y §9.6. La cookie de la página la asigna el servidor (`HttpOnly`, `SameSite=Lax`).

**CTRL-01…15 en la demo.** Por lectura de código cumplen, con dos matices: CTRL-14 y CTRL-15 no cubren la lista del extractor de bajas (AH-01--02), y CTRL-08 se cumple en la letra, pero la demo sólo arranca en Development (AH-01--03).
