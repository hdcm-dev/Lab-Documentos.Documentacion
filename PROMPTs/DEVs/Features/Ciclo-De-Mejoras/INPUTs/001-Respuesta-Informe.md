## Respuesta a informes 

- Sobre
```
No se guardan. Tus conversaciones viven sólo mientras tenés la pestaña abierta, en la memoria de la sesión del servidor. Cuando la cerrás o se reinicia el servicio, se pierden. En la base queda únicamente el registro de consumo, con hora, modelo, tokens y latencia, pero sin el texto.
```
ok


```
**Cómo se hace en la industria.** Son dos cosas distintas que conviene no mezclar:
```
ok

- Sobre esto:
```
1. **Historial de conversaciones, pensado para el usuario.** Es lo que hacen ChatGPT o Intercom: cada conversación se guarda con sus mensajes y el usuario la retoma después. Es una función de producto, con tiempo de retención y opción de borrar.
```
Esto lo vi en onesignal, `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/DEVs/Features/Ciclo-De-Mejoras/INPUTs/001-Respuesta-Informe/Historial-Chat.png` , lo tenemos que incorporar en la planificación

- Sobre esto:
```
2. **Observabilidad, pensada para quien opera el sistema.** Cada interacción se registra como una «traza» con:
   - la pregunta;
   - la intención detectada;
   - los documentos que trajo la búsqueda;
   - el prompt enviado al modelo;
   - la respuesta y si salió de la IA o de la plantilla;
   - tiempos y tokens.

   Las herramientas habituales son Langfuse, LangSmith o Arize Phoenix. El formato estándar son las convenciones de OpenTelemetry para IA generativa, las mismas que ya usamos para el registro de consumo.

   Una regla común es que **guardar el contenido viene apagado por defecto**: OpenTelemetry lo trata como opcional porque contiene datos personales. Se enciende en desarrollo o pruebas, o en producción con aviso al usuario, retención acotada (30 a 90 días) y enmascarado de datos sensibles.
```
ok


Sobre esto:
```
**Qué propongo para PushDispatch:**
- **Para la escena, ya:** activar la captura del contenido de las trazas sólo en hpdev, con una tabla de conversaciones y mensajes que incluya lo técnico (intención, fuentes, plantilla o IA) y se purgue a los 30 días. Así puedo seguir en vivo lo que preguntás y ver por qué la consola respondió lo que respondió.
- **Para producción, después:** la observabilidad queda sin contenido, sólo métricas. Si se quiere historial para el usuario, se decide como función aparte, con aviso y opción de borrar.

Esto encaja en la mesa 141, en la parte de métricas y monitoreo (rebanadas M1–M4).
```
ok aprobado
