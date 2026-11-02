# 04 · Aprobación de la relectura (Vuelta 2, presidencia y auditoría)

Fecha: 2026-10-29. Insumo: 35 ítems (RL-01 a RL-35) y los votos de cinco jurados: evidencia, impacto, costo-beneficio, coherencia-historica y riesgo.
Marco: Mesa-Evaluadora (auditoría de parches; APLICAR / MEJORAR_PLAN / NO_APLICAR / ESCALAR).

## 1. Recuento por ítem

| Ítem | a | b | c | d | Vetos (riesgo) | Ganadora | Dictamen |
|---|---|---|---|---|---|---|---|
| RL-01 | 5 | | | | c | a | APLICAR |
| RL-02 | 4 | 1 | | | c | a | APLICAR |
| RL-03 | 5 | | | | c | a | APLICAR |
| RL-04 | 5 | | | | b | a | APLICAR |
| RL-05 | 5 | | | | — | a | APLICAR |
| RL-06 | | | 5 | | — | c | APLICAR |
| RL-07 | 5 | | | | — | a | APLICAR (con la prueba, ver RL-26) |
| RL-08 | 5 | | | | — | a | APLICAR |
| RL-09 | 4 | 1 | | | — | a | APLICAR |
| RL-10 | 4 | 1 | | | c | a | APLICAR |
| RL-11 | 5 | | | | — | a | APLICAR |
| RL-12 | 5 | | | | b | a | APLICAR |
| RL-13 | 5 | | | | — | a | APLICAR |
| RL-14 | 5 | | | | c | a | APLICAR |
| RL-15 | 5 | | | | c | a | APLICAR (y volver a verificar) |
| RL-16 | 5 | | | | d | a | APLICAR |
| RL-17 | | 1 | 4 | | d | c | APLICAR |
| RL-18 | 5 | | | | — | a | APLICAR |
| RL-19 | 4 | 1 | | | — | a | APLICAR |
| RL-20 | 5 | | | | — | a | APLICAR |
| RL-21 | 4 | | 1 | | a, b | c (por veto) | NO_APLICAR en esta vuelta; MEJORAR_PLAN para la siguiente |
| RL-22 | 5 | | | | — | a | APLICAR |
| RL-23 | 3 | 2 | | | — | a | APLICAR (con mutación roja y compilación) |
| RL-24 | 4 | 1 | | | — | a | APLICAR |
| RL-25 | 5 | | | | — | a | APLICAR |
| RL-26 | 5 | | | | c | a | APLICAR |
| RL-27 | 5 | | | | b | a | APLICAR |
| RL-28 | 5 | | | | — | a | APLICAR |
| RL-29 | 5 | | | | c | a | APLICAR |
| RL-30 | 5 | | | | — | a | APLICAR |
| RL-31 | 5 | | | | — | a | APLICAR |
| RL-32 | 5 | | | | c | a | APLICAR |
| RL-33 | 5 | | | | — | a | APLICAR (junto con RL-15) |
| RL-34 | 5 | | | | — | a | APLICAR |
| RL-35 | 5 | | | | — | a | APLICAR |

## 2. Vetos

- Todos los vetos los presentó el jurado de riesgo. Recaen sobre «no cambiar» cuando hay una afirmación falsa (RL-01, 02, 03, 10, 14, 15, 16, 17, 26, 27, 29, 32) o sobre opciones que agregan cifras o estados sin registro (RL-04 b, RL-12 b). Cumplen las causales acotadas. Ninguno recae sobre la opción ganadora, así que no cambian el resultado.
- RL-21: hay veto a «a» y a «b». El fundamento es que una prueba que falla de fábrica dentro de la suite rompe las compuertas de verde. La causal es fundada, porque las compuertas exigen la suite en verde. Las dos opciones de cambio quedan excluidas y sólo queda «c». No se aplica nada en esta vuelta. Queda como MEJORAR_PLAN para la siguiente: el criterio del ítem 4 de §15 tiene que fallar de fábrica fuera de la suite (por ejemplo, un chequeo propio del ejercicio que las compuertas no corran). No es decisión del PO y no se escala.

## 3. Homogeneidad

Hay 27 de 35 ítems unánimes (77 %), por debajo del umbral del 80 %. Además, la opción unánime no es siempre la primera, porque RL-06 eligió «c». No se marca sospecha. Queda anotado que el valor está cerca del umbral, y la revisión a mano no es obligatoria. La sostienen los fundamentos con citas de código verificables (verificar.sh:53,71,78; ConfiguracionDelModelo.cs:36,72).

## 4. Escalados al PO

Ninguno. No hay empates. Ningún ítem toca publicar, commitear, el estado «publicada» ni el alcance. Todos son correcciones aditivas o reversibles, así que la mesa decide y queda aprobado.

## 5. Parches aprobados (en orden de la guía)

Condiciones comunes:
- La guía se edita con un solo agente a la vez, ubicando cada cambio por ancla y texto único.
- El código se compila sólo sobre la copia con turno.
- Al cierre, el find de bin/, obj/ y *.db en la guía tiene que quedar vacío.
- R-PRIV: estaciones por rol y endpoints por variable.
- Ninguna cifra sin su registro R-LLM.

| Id | Ítem | Destino | Ancla | Cambio |
|---|---|---|---|---|
| P-01 | RL-05 | guía | banner (línea 18), §4.3, §5.4, §7.4, §7.7, §10.6, §11.7, §13 | Reescribir las 11 apariciones de «existencia, otra composición: línea archivada del laboratorio» como «Historia (hasta el 2026-10-28)». Quitar «línea archivada/paralela/de construcción» del texto al lector. |
| P-02 | RL-08 | guía | §0.4 y las apariciones del rótulo Historia en §5, §6.3, §7, §11.7 | Fijar en §0.4 la forma «Historia (hasta el 2026-10-28). <detalle de la corrida>» y normalizar las variantes («servidor retirado», «oro v1…», a secas). Se hace después de P-01. |
| P-03 | RL-06 | guía | §3.0 «Doce términos», §4.1 «Vocabulario», Anexo C, Parte 0 | Recortar: §4.1 deja sólo el «qué no es» y remite al Anexo C, y el Anexo C queda en término, alias y «Se define en». Después medir con tools/contar.sh. Si sigue por encima del tope REC-21, declarar en la Parte 0 la deuda con la cifra medida y un plan de recorte. Sin cifra inventada. |
| P-04 | RL-09 | guía | §0.0 índice; entrada del Anexo A | Agregar el ancla alias anexo-a-14 sin quitar anexo-a-props, y la línea «A.n es la plantilla de §n». |
| P-05 | RL-35 | guía | apertura de los Ejemplos de §5 | Agregar «--con-modelo es réplica exacta (versión y digests de la guía); con tu servidor, usá el docker run de E.5». |
| P-06 | RL-07 | guía + Examples/ (ArquitecturaTests) | OA-0.2, diagramas de §1, §3.1, §4.3, §4.5 | Cambiar «Presentación» por «Presentation» en las 16 apariciones y en la regla de ArquitecturaTests que lo nombra. Compilar y probar en la copia. |
| P-07 | RL-26 | guía | §4.3 «Otras cuatro reglas»; §13.12 Consecuencias | Dejar en §4.3 «otras tres reglas…; la quinta…» y en §13.12 enumerar «Domain, Application, el SDK y las herramientas» más Presentation: cinco reglas en total. |
| P-08 | RL-23 | Examples/ (ArquitecturaTests.cs) + guía | §4.3 «Lo que la prueba no ve»; §13.12 ADR-11 | Agregar una regla que prohíba Comun.AI y Comun.Pruebas fuera de Infrastructure.AI y Program. Comprobar la mutación roja: rojo con la violación, verde sin ella. Nombrar la regla en §4.3 y §13.12. Si la mutación no da roja, se cae a declarar el agujero (opción b) y se anota. |
| P-09 | RL-22 | guía | §5 «01 · Chat y streaming», salida mostrada | Si existe el registro R-LLM vigente de 01, mostrarlo con su rótulo completo. Si no existe, escribir «salida vigente: no mostrada» y remitir a la salida --fake de E.4. |
| P-10 | RL-10 | guía | §5.4 «Ventana y truncado»; §5.7 «num_ctx recorta en silencio» | Aclarar que el par 5.114/5.134 viene de su propio estímulo y composición, y que la comparación de tokenizadores vale sólo dentro de ese par. Quitar «el mismo prompt» para 5.397 y 5.714. Sin cifras nuevas. |
| P-11 | RL-11 | guía | §5.7 viñeta «num_ctx recorta en silencio» | Completar el rótulo con el digest y la versión de Ollama desde el registro, o escribir «rótulo incompleto». Agregar «el largo que queda lo decide el motor y no es igual a num_ctx; observado: 2.050 tokens, mecanismo no explicado». |
| P-12 | RL-12 | guía | §5.7 «Reutilización del prefijo»; §6.3 ejemplo 05, salida --fake | En §5.7, explicar que «frio» significa reutilizado < mitad del prompt y declarar «no explicado» por qué se reutilizó menos que el prefijo. En §6.3, agregar «la corrida real de §5.7 no reprodujo ese estado». |
| P-13 | RL-25 | guía | §5.5; fila EMB_PLAN del anexo de variables | Nombrar el doble GeneradorDeEmbeddingsEstable (Comun.Pruebas) y aclarar «modo de demostración, no patrón para CTX-PROD». |
| P-14 | RL-14 | guía | preguntas de §6 «IC95 [0,398; 1]»; §8.2 «piedra … 6 de 10»; §8.5 «3400 en 8 de 10»; §11.7 «lo repitió en las 10…» | Completar cada rótulo R-LLM desde su registro y escribir «digest no registrado» donde falte. En §11.7, sumar k/n e IC si el registro los da; si no, aplicar P-19. |
| P-15 | RL-13 | guía | §7.1 reproducibilidad de embeddings | Escribir «17 entradas × 2 corridas = 34 consultas». |
| P-16 | RL-27 | Examples/13-Servidor-Y-Cliente-MCP/Infrastructure/AI/ClienteMcp.cs:15-16 (y la línea 48 si repite el texto) | comentario sobre WithDescription | Cambiar por «la descripción de la herramienta es la del cliente; el esquema y las descripciones de sus parámetros siguen siendo del servidor y son no confiables». Es un comentario: no cambia el comportamiento, pero se compila igual en la copia. |
| P-17 | RL-34 | guía | bloque --fake de §10 «salidas interpretables: 51/52» | Agregar como primera línea dentro del bloque «[guion] salida simulada (--fake), no es medición». |
| P-18 | RL-02 | guía | pregunta guía de §10 «¿Puedo usar un modelo para evaluar a otro?»; §13.11 ADR-10; §14.6; Anexo E.1 fila 15 | Separar «Historia (hasta el 2026-10-28): qwen2.5:0.5b, 0/52 legibles» de «vigente: qwen3.5:4b, no medido (41/52 < 45/52, 2026-10-29), ver §10.6». En E.1 fila 15, rotular el 0.5b como Historia y nombrar el vigente. |
| P-19 | RL-01 | guía + Examples/15-Pruebas-Y-Evaluacion/ejemplo.json | §10.6 «Lo que vio el laboratorio después»; campo de estado de ejemplo.json | Reemplazar «su repetición, con criterio propio, no había cerrado al escribir esta sección» por «la repetición del 2026-10-29 (estación 2) dio 41/52 salidas interpretables, por debajo del mínimo fijado antes de correr (45/52): no medido». Llevar el rótulo R-LLM completo (qwen3.5:4b@d8b0f5e9760c, Ollama 0.40.11, k/n=41/52) y el aviso de juez de la misma familia. Sin 0,788 ni acuerdo. Poner el mismo texto en el estado de ejemplo.json. |
| P-20 | RL-03 | guía + Examples/15-Pruebas-Y-Evaluacion/README.md:13 | §10.6, párrafo «En el laboratorio, el LLM juez y el modelo evaluado…» | Reescribir: «en la corrida del 2026-10-29 (no medida, ver abajo) juez y generador son el mismo modelo, el caso de mayor riesgo de autofavorecimiento». Dejar «ser distintos…» sólo para la composición Historia. En el README, corregir «distinto del generador». |
| P-21 | RL-04 | guía | §10.6 «Resultado: no calibrado» | Reemplazar «Acuerdo con la anotación: 0/10, IC95 [0; 0,308]… El acuerdo no se midió» por «acuerdo no medido: 0 de 10 salidas de calibración legibles (recuento, no tasa)». |
| P-22 | RL-28 | guía | §11.2 «Repetir el texto inyectado…»; §11.7 último párrafo | Contar en el registro R-LLM las salidas distintas por entrada. Si son idénticas, informar «1 muestra por entrada» y quitar el IC. Si son distintas, conservar la cifra con el recuento. Sin corrida nueva. |
| P-23 | RL-30 | guía | §11.5 «sus resultados son no confiables por procedencia» | Aclarar que 13 no ejerce la regla 2 porque PoliticaDeMontaje.DelEjemplo no monta escrituras, y que la regla la muestra 16. |
| P-24 | RL-31 | guía | §11.6 «Ollama no autentica»; §12.6 «Advertencia» | Agregar «…, y entonces lo alcanza todo contenedor de esa red». |
| P-25 | RL-29 | guía | §11, pregunta «¿La aprobación humana reemplaza la autorización?» | Agregar «el id lo elige el cliente y no se verifica; en CTX-PROD lo emite el servidor (aleatorio y firmado) o se usa identidad autenticada (§14.6); la demo es CTX-PROTO». |
| P-26 | RL-18 | guía + Examples/README.md + Demos/MovilidadUrbana.Asistente/compose.yaml:19 | §E.5 docker run; README; compose | Usar "${SDK_IMAGEN:-mcr.microsoft.com/dotnet/sdk:10.0}". El defecto queda igual al actual. |
| P-27 | RL-20 | guía | §12.8 tabla, fila Telemetría | Rotular la fila como «no observada: se emite sin exportador». |
| P-28 | RL-32 | guía | §13.7 ADR-06 Confianza; Anexo B.5 fila 4 | Bajar la confianza a «media» y declarar que la demo aplica sólo la regla 2 (SesionDeChat.cs:73 llama a Crear() con los valores por defecto), no medida con la composición vigente: el 0/6 es Historia. |
| P-29 | RL-24 | guía | §14.2 diagrama | Agregar el nodo «biblioteca común (_Comun)» y la flecha desde Infrastructure/AI (DependencyInjection.cs → FabricaDeClientes). |
| P-30 | RL-15 | tools/verificar.sh:77-79, 452-460 + guía | Anexo E.3; E.1 filas 02, 05, 15; A.12 | Alinear los esperados con qwen3.5:4b@d8b0f5e9760c y Ollama 0.40.11, en lugar del DIGEST_CHAT_PROPIO del 0.5b. Rotular qwen2.5:0.5b como Historia en E.1 (02, 05, 15) y en A.12. Volver a correr verificar.sh contra la estación vigente con turno y registrar el resultado. |
| P-31 | RL-33 | Examples/_Comun ConfiguracionDelModelo.cs:36,72 + CapaDeOpcionesTests.cs:78 + guía A.12 | defecto de OLLAMA_PROPIO_MODEL | Cambiar el defecto a qwen3.5:4b en el código y en la prueba, y actualizar A.12. Va en el mismo turno de compilación que P-30. |
| P-32 | RL-17 | guía | §E.5 tabla de tiempo por llamada → Anexo F.4 | Mover la tabla a F.4 y atar cada fila a su registro. Aclarar que el rango es entre ejemplos, poner los 45 min como parámetro del operador y marcar «no medido» lo que no tenga registro. Quitar «prompts largos» de la frase sobre la estación 1 y dejar en E.5 una remisión a F.4. |
| P-33 | RL-16 | guía | §E.5 «Con 45 minutos por turno…» | Corregir: «TOPE_COMPARTIDO_S: tope de uso del ciclo en modo compartido; defecto 14.400 s (4 h), que el operador ajusta». Quitar «tope de espera por llamada» y «no se escribe en el repositorio». |
| P-34 | RL-19 | guía | Anexo E.6 | Agregar un inventario con docker ps -a y docker volume ls filtrados por label ETIQUETA, más RLLM_DIR, seco/ y .concedido. Agregar una limpieza que conserve los registros y el aviso de correr el docker run de E.5 sobre una copia, no sobre el árbol de la guía. |

Ítem sin parche: RL-21 (veto fundado; MEJORAR_PLAN en la vuelta siguiente).

## 6. Auditoría de los parches

- Ningún parche introduce cifras sin registro. Las únicas cifras nuevas (41/52, 45/52) vienen del registro de R-15b.
- Los parches de código (P-06, P-08, P-16, P-30, P-31) se compilan y prueban sólo sobre la copia con turno. P-30 y P-31 exigen volver a correr verificar.sh.
- Hay dependencias de orden: P-01 antes de P-02, y P-06 junto con P-07 y P-08 (misma suite de ArquitecturaTests).
- R-PRIV: los parches nombran estaciones por rol y no llevan IPs, hosts ni rutas.

## 7. Anotaciones

- El jurado coherencia-historica avisó que su archivo 02-Voto-coherencia-historica.md quedó en 0 bytes porque el disco estaba lleno. Al escribir esta aprobación había 2,7 GB libres. El voto se tomó del insumo de la presidencia y el archivo debe reescribirse por agregado.
- No llegaron mensajes ajenos a la carta durante el trabajo.
