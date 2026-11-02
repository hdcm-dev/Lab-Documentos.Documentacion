# Panel AH-01 · seguridad · relectura integral de la guía 0.11.0

Rol: inyección de prompt, credenciales, R-PRIV, superficie de herramientas y MCP. Lectura centrada en §8.9, §11 completa, §12.5–§12.6 y el código de 13, 16 y la demo. Trabajé a ciegas, sin leer los paneles de otros. No edité la guía.

## AH-01-seguridad-01 · mayor · comentario de 13 contradice §8.9
- Ancla: `Examples/13-Servidor-Y-Cliente-MCP/Infrastructure/AI/ClienteMcp.cs`, líneas 15-16, frente a §8.9 («Cliente: lo que anuncia el servidor no decide»).
- Evidencia: el comentario dice «la del servidor no llega al modelo ni en una lectura ni en una escritura». §8.9 dice que «el esquema de los parámetros sigue siendo el que anunció el servidor, y sus descripciones llegan al modelo». `WithDescription` cambia sólo la descripción de la herramienta, no el esquema.
- Propuesta: corregir el comentario para que diga «la descripción de la herramienta es la del cliente; el esquema y las descripciones de sus parámetros siguen siendo del servidor y son no confiables».

## AH-01-seguridad-02 · mayor · las 10 repeticiones con semilla fija no son ensayos independientes
- Ancla: §11.2, párrafo «Repetir el texto inyectado es otra salida insegura», y §11.7, último párrafo.
- Evidencia: «10 de 10 repeticiones … IC95 [0,692; 1] por entrada … 0/10 por entrada, IC95 [0; 0,308] … 10 repeticiones con la semilla 42 fija». Clopper-Pearson supone ensayos independientes. Con la semilla y el pedido fijos, las 10 salidas pueden ser la misma muestra repetida. La aritmética del intervalo está bien, pero lo que el intervalo afirma no está justificado.
- Propuesta: decir cuántas salidas distintas hubo en cada entrada, según el registro R-LLM. Si son idénticas, reportar «1 muestra por entrada, repetida» y quitar el IC, o variar la semilla. No agregar cifras nuevas sin su registro.

## AH-01-seguridad-03 · mayor · el id de sesión lo elige el cliente
- Ancla: §11 Preguntas guía, «¿La aprobación humana reemplaza la autorización?»; código en `Demos/MovilidadUrbana.Asistente/src/MovilidadUrbana.Asistente/Sessions/SessionHeaderMiddleware.cs:18-19` y `Infrastructure/Sessions/SessionContext.cs` (`IsValid`: no vacío y de 64 caracteres o menos).
- Evidencia: la guía dice «`X-Sesion-Id` no autentica: quien conoce el id ve los datos». El código acepta cualquier valor que mande el cliente, por ejemplo «1». Por eso no hace falta «conocer» un id secreto: alcanza con elegir uno trivial para compartir o pisar un espacio de datos. Esto vale también para la cookie.
- Propuesta: agregar una línea que diga que el id lo elige el cliente y no se verifica, así que en CTX-PROD lo emite el servidor (aleatorio y firmado) o se reemplaza por una identidad autenticada (§14.6). La demo puede quedar como está, rotulada CTX-PROTO.

## AH-01-seguridad-04 · menor · en 13 los resultados MCP no marcan el pedido
- Ancla: §11.3 (política de origen: los «resultados MCP» son no confiables) y §11.5, «sus resultados son no confiables por procedencia»; código en `Examples/13-Servidor-Y-Cliente-MCP/Infrastructure/AI/AsistenteConMcp.cs`.
- Evidencia: 13 no aplica la regla 2 a los resultados de `listar_localidades` por MCP: no hay `EstadoDelPedido` ni aviso en el pedido de aprobación. Hoy no hay ninguna escritura montada, así que no hay riesgo. Pero el texto puede leerse como si 13 ejerciera la política.
- Propuesta: aclarar en §11.5 que 13 no ejerce la regla 2 porque no monta escrituras, y que la regla la muestra 16.

## AH-01-seguridad-05 · menor · ¿bridge es «no exponer»?
- Ancla: §11.6, «Ollama no autentica», y §12.6, «Advertencia».
- Evidencia: «Publicalo sólo en 127.0.0.1 o en la interfaz de la red bridge». Si se publica en la interfaz del bridge, cualquier contenedor del host en esa red puede llegar al modelo sin credencial.
- Propuesta: agregar «… y entonces lo alcanza todo contenedor de esa red».

## Sin hallazgo
- R-PRIV: en el árbol de la guía no encontré IPs fuera del loopback, hosts ni nombres de equipos del laboratorio, rutas del home ni usuarios. La procedencia que citan los archivos de la demo es un repositorio público con su REF-186. En `CuerpoDelPedidoTests.cs:226`, `Bearer ollama` es el valor de relleno documentado (REF-51) y no un secreto.
- §11.5 y §11.6 distinguen bien entre loopback, `AllowedHosts` y `Origin`, y no los presentan como control de acceso. `EscrituraVigilada` no lee nada del modelo.
- Mensajes ajenos a la carta durante el trabajo: ninguno.
