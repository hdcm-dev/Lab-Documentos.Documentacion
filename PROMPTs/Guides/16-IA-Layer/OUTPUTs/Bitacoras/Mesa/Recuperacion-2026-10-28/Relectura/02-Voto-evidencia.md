# Voto del jurado de evidencia (relectura, a ciegas)

Cotejado con la guía 0.11.0, tools/verificar.sh, ejemplo.json del 15 y ConfiguracionDelModelo.cs.

| Ítem | Opción | Fundamento |
|---|---|---|
| RL-01 | a | §10.6 y ejemplo.json traen todavía «no había cerrado»; los dos están viejos. |
| RL-02 | a | Un pasaje que habla del 0.5b sin rótulo afirma algo vigente que no lo es; hay que separar. |
| RL-03 | a | La frase sobre la composición contradice el mismo párrafo; corregir también el README. |
| RL-04 | a | §10.6 trae «0/10, IC95 [0; 0,308]» y después «no se midió». Es una contradicción literal. |
| RL-05 | a | Hay 11 apariciones de un rótulo que §0.4 no define; Historia ya está definido. |
| RL-06 | c | Recortar lo triplicado y medir con contar.sh; el exceso que quede se declara con la cifra medida. |
| RL-07 | a | La regla es nombrar los patrones en inglés. |
| RL-08 | a | Una forma fija se puede verificar. |
| RL-09 | a | El alias no rompe los enlaces que ya existen. |
| RL-10 | a | Son tres registros distintos; «el mismo prompt» no se sostiene. |
| RL-11 | a | Lo que el registro no dice se declara. |
| RL-12 | a | Se explica con lo que ya está registrado, sin una corrida nueva. |
| RL-13 | a | Es aritmética explícita. |
| RL-14 | a | «digest no registrado» es honesto; borrar la cifra pierde evidencia. |
| RL-15 | a | verificar.sh:78 fija a8b0c5157701 (0.5b); el arnés tiene que reproducir la composición vigente. |
| RL-16 | a | verificar.sh:53,71 lo dicen: tope del ciclo con defecto 14400. |
| RL-17 | c | Mover la tabla y conservar la trazabilidad por registro. |
| RL-18 | a | La variable se aplica donde se recomienda. |
| RL-19 | a | Se inventaría lo que el arnés crea. |
| RL-20 | a | Nada la observa. |
| RL-21 | a | La prueba roja de fábrica da la evidencia de lo que hizo el alumno. |
| RL-22 | a | Condicionado a que exista el registro. |
| RL-23 | b | Declarar ya lo comprobable; la regla nueva exige compilar y mutar. |
| RL-24 | a | Refleja el DependencyInjection.cs real. |
| RL-25 | a | |
| RL-26 | a | |
| RL-27 | a | ClienteMcp.cs:48 dice «La descripción que ve el modelo es la del cliente»; el esquema sigue siendo del servidor. |
| RL-28 | a | Se resuelve con el registro existente. |
| RL-29 | a | |
| RL-30 | a | |
| RL-31 | a | |
| RL-32 | a | La regla 2 sólo tiene un 0/6 de Historia. |
| RL-33 | a | ConfiguracionDelModelo.cs:36,72 y CapaDeOpcionesTests.cs:78 dan qwen2.5:0.5b; va con RL-15 a. |
| RL-34 | a | |
| RL-35 | a | |
