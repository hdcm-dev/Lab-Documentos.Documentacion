# Ejemplo 12: los comandos del README tal cual, en copia limpia y sin caché NuGet compartida
# Fecha: 2026-10-28. Imagen: mcr.microsoft.com/dotnet/sdk@sha256:de4fe90a98845d75910b9769662465c84de1a934665c431279d1382b2bddc02b (SDK 10.0.403). Sin modelo: no corresponde cabecera R-LLM (el ejemplo no corre contra el servidor de prueba).
# Comando: ver README.md §Comandos

CONCEDIDO build a ex12 hasta 2026-10-28T16:40:42-0300 (renová con: <gestor-de-turnos> renovar build ex12)
### README build
Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:34.46
rc=0
### README test
Test run for /ex/tests/MovilidadUrbana.Ejemplos.AnotacionesPareadas.Tests/bin/Debug/net10.0/MovilidadUrbana.Ejemplos.AnotacionesPareadas.Tests.dll (.NETCoreApp,Version=v10.0)
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:    18, Skipped:     0, Total:    18, Duration: 977 ms - MovilidadUrbana.Ejemplos.AnotacionesPareadas.Tests.dll (net10.0)
rc=0
### README run
== Declaración que ve el modelo
Semantic Kernel: KernelFunctionFromMethod; Name «Encuesta_resultados_por_medio»; JsonSchema {"type":"object","condition":"Cuenta las respuestas de la encuesta
Agent Framework: ReflectionAIFunction; Name «resultados_por_medio»; JsonSchema {"type":"object","properties":{"localidad":{"description":"Localidad de la encu
== Invocación directa con {"localidad":"Corrientes"}
Semantic Kernel: {"localidad":"Corrientes","totalDeRespuestas":2,"porMedio":[{"medio":"colectivo","etiqueta":"Colectivo","respuestas":2},{"medio":"auto","etique
Agent Framework: {"localidad":"Corrientes","totalDeRespuestas":2,"porMedio":[{"medio":"colectivo","etiqueta":"Colectivo","respuestas":2},{"medio":"auto","etique
== Agente con cliente guionado: «¿Qué medios usa la gente de Corrientes?»
ChatCompletionAgent: pidió «Encuesta_resultados_por_medio»; llamadas al cliente 2; resultado recibido como ResultadosPorMedio
  (sin modelo) {"Localidad":"Corrientes","TotalDeRespuestas":2,"PorMedio":[{"Medio":"colectivo","Etiqueta":"Colectivo","Respuestas":2},{"Medio":"auto","Etiqueta
AsAIAgent: pidió «resultados_por_medio»; llamadas al cliente 2; resultado recibido como JsonElement
  (sin modelo) {"localidad": "Corrientes","totalDeRespuestas": 2,"porMedio": [{"medio": "colectivo","etiqueta": "Colectivo","respuestas": 2},{"medio": "auto","e
rc=0
LIBERADO build por ex12
