# Aplicación de los parches de la relectura

## Lote 1 de 5 (P-01…P-08), 2026-10-29

Guía (`$DOC`) antes del lote: sha256 `eeede578a6b34e2f2f46124c0f36b1a11a8caf85fb2d4010b17a831011defa18`; `tools/contar.sh` Total 58.820/44.330 (133 %), Parte 0 2.065 (148 %), Anexos 14.261 (192 %), Anexo C 2.187.
Guía después del lote: sha256 `5290d9a33987ead4077795a0dd3022e38b6b1e28511608788bbb6e1a5b681147`; `tools/contar.sh` Total 57.234/44.330 (129 %), Parte 0 2.178 (156 %), Anexos 12.532 (169 %), Anexo C 452.
Los sha256 intermedios que no se tomaron se marcan «no capturado»; los parches se aplicaron en orden, cada uno sobre el resultado del anterior.

| id | ítem | estado | sha256 guía antes → después | nota / desvío |
|---|---|---|---|---|
| P-01 | RL-05 a | aplicado con desvío | `eeede578…a11a8` → `0e2c533a…bdb2a` | 9 de las 11 «otra composición» eran rótulos y pasaron a «Historia (hasta el 2026-10-28). …»; las 2 restantes (§10.4 «Existencia» y su fila en el Anexo de criterios) son la regla de evidencia, no un rótulo, y se dejaron. Se quitó además «línea archivada/paralela/de construcción» del banner, §9 (ADR de herramientas) y una fila del inventario de la demo (12 reemplazos exactos en total). |
| P-02 | RL-08 a | aplicado con desvío | `0e2c533a…bdb2a` → `e3524409…a401b` (más 2 ajustes de P-01, no capturado) | §0.4 fija «Historia (hasta el 2026-10-28). <detalle de la corrida>». Normalizadas 36 «, servidor retirado)», 1 «; oro v1…» y 10 «): …». Desvío: §0.4 amplía el alcance del rótulo a «servidores que ya no existen o una composición distinta de la de los ejemplos», porque P-01 lo aplica a corridas de la estación 1, que sigue vigente. |
| P-03 | RL-06 c | aplicado; deuda declarada | no capturado | §4.1 queda en «qué no es» y remite a §3.0 y al Anexo C; el Anexo C queda en término, alias y «Se define en» (sin «Definición breve» ni «Respaldo»; los REF siguen citados: verificar-markdown 180/180). Anexo C 2.187 → 452. Exceso medido y declarado en §0.5 como deuda, con plan de recorte: Total 57.234/44.330 (129 %), Parte 0 2.178/1.400 (156 %), Anexos 12.532/7.430 (169 %). |
| P-04 | RL-09 a | aplicado | no capturado | Ancla `anexo-a-14` junto a `anexo-a-props` (las dos quedan); el índice de §0.0 apunta a `anexo-a-14`; entrada del Anexo A: «A.n es la plantilla de §n». |
| P-05 | RL-35 a | aplicado | no capturado | Apertura de «Ejemplos de §5»: «`--con-modelo` es réplica exacta (versión y digests de la guía); con tu servidor, usá el `docker run` de E.5». |
| P-06 | RL-07 a | aplicado con desvío | no capturado | 16 «Presentación» → «Presentation» en la guía. La regla no está en `Examples/` sino en `Demos/MovilidadUrbana.Asistente/tests/…/Cableado/ArquitecturaTests.cs`: Description y método pasan a `Presentation_EntraAInfrastructureAI_SoloPorChat` (también en la guía); también el comentario de `Program.cs`, el README de la demo y el encabezado de `MutacionesTests.cs` (que decía «línea archivada»). Los helpers internos `TiposDePresentacion`/`ViolacionesDePresentacion` no se renombraron. |
| P-07 | RL-26 a | aplicado con desvío | no capturado | §4.3: «Otras tres reglas … (Application, el SDK del proveedor y las herramientas); la quinta …». §13.12: «Cuatro reglas cubren Domain, Application, el SDK y las herramientas; la quinta …». Desvío: con P-08 hay una sexta regla, así que el total que dice la guía es seis, no cinco (§4.3, §4 Ejemplos, §13.12, §14 evidencia). |
| P-08 | RL-23 a | aplicado | no capturado → `5290d9a3…1147` | Nueva regla `ComunAIyPruebas_SoloEnInfrastructureAIyProgram` (también falla si Infrastructure.AI y Program dejan de usar esos namespaces) y mutación `Mutantes/Comun.cs` con el caso `Comun_FueraDeInfrastructureAI_DaRojo`. Mutación roja comprobada en la copia: con un tipo de `Controllers/` que usa `Comun.AI`, 80/81 y falla la regla nueva; sin él, 81/81. Nombrada en §4.3 («Lo que la prueba no ve»: tres casos rojos) y §13.12 (seis reglas, tres mutaciones). Las cifras de pruebas de §4 Ejemplos y §14 pasaron de 79 a 81 con la corrida de este lote. |

Verificación (copia `{dir-de-trabajo}/relectura-lote1`, turno build del gestor, SDK 10.0 con el volumen de NuGet del laboratorio, sin servidor de modelos):
- `tools/demo.sh pruebas`: rc 0, 81/81, AC-6 en verde. Con la mutación en `Controllers/`: rc 1, 80/81 (falla sólo la regla nueva). La mutación se borró de la copia.
- `tools/verificar.sh build`: rc 0; compuerta R-PRIV del build 0.
- `tools/verificar-markdown.py guia`: sin hallazgos; REF 180/180.
- Barrido R-PRIV ampliado (`evidencia-rpriv/rpriv-ampliado.sh`, lista de 41 términos fuera del repo) sobre la guía, `ArquitecturaTests.cs`, `MutacionesTests.cs`, `Mutantes/Comun.cs`, `Program.cs` y el README de la demo: 0 en todas las clases.
- `find` de bin/ obj/ *.db en la guía: vacío.

sha256 de código tocado (antes → después): `ArquitecturaTests.cs` `7ed5277e…50a4` → `a88a7676…064b`; `MutacionesTests.cs` `90e78aec…4191` → `96b350a1…2e64`; `Mutantes/Comun.cs` nuevo `ecf6b71e…398e`; `Program.cs` `15c1d90c…7302` → `5c9324d7…d77f7`; README de la demo `1409d500…55bb` → `ee26976a…ae44`.
Sin commit, push, PR ni ramas.

## Lote 2 de 5 (P-09…P-16), 2026-10-29/30

Guía (`$DOC`) antes del lote: sha256 `5290d9a33987ead4077795a0dd3022e38b6b1e28511608788bbb6e1a5b681147`; `tools/contar.sh` Total 57.234/44.330 (129 %), Parte 0 2.178 (156 %), Anexos 12.532 (169 %), Anexo C 452.
Guía después del lote: sha256 `8c0aacb1fd929ed3c729ed6ec665c7a98a4f00358c10681f58375bd6826ca537`; `tools/contar.sh` Total 57.466/44.330 (130 %), Parte 0 2.178 (156 %), Anexos 12.553 (169 %), Anexo C 452.
Parches aplicados en orden, cada uno sobre el resultado del anterior; reemplazos exactos con cuenta 1 verificada.

| id | ítem | estado | sha256 guía antes → después | nota / desvío |
|---|---|---|---|---|
| P-09 | RL-22 a | aplicado | `5290d9a3…1147` → `ae174e98…229e` | Existe el registro R-LLM de 01 (estación 1, 2026-10-29, R-01). Antes de la Historia se agrega «Salida vigente» con rótulo completo (`qwen3.5:4b` digest `d8b0f5e9760c`, Ollama 0.40.11, estación 1, servidor compartido, `num_ctx` 8.192; 2 entradas, 2 de 2 pasan `campos-pedidos`, recuento sin tasa) y la respuesta de e01 copiada del registro. La Historia queda. |
| P-10 | RL-10 a | aplicado | `ae174e98…229e` → `c962f12e…1d55` | §5.4: el par 5.114/5.134 es «un estímulo propio, con su propia composición»; no es el prompt de 5.397 ni el de 5.714, y la comparación de tokenizadores vale sólo dentro del par. «el mismo prompt» no figuraba para 5.397/5.714; en §5.7 el 5.714 pasa a «un prompt de esa sonda, con otro estímulo y otra composición que el de 5.397». |
| P-11 | RL-11 a | aplicado | `c962f12e…1d55` → `a3d965b1…8c99` | Rótulo de la sonda de `num_ctx` completado desde su registro (DEP-03, estación 2: digest `d8b0f5e9760c`, Ollama 0.40.11, una entrada en tres variantes). Frase agregada: «El largo que queda lo decide el motor y no es igual a `num_ctx`; observado: 2.050 tokens, mecanismo no explicado». |
| P-12 | RL-12 a | aplicado | `a3d965b1…8c99` → `87f5937e…caaa` | §5.7: «frio» = reutilizado < mitad del prompt, no «nada reutilizado»; por qué se reutilizó menos que el prefijo: no explicado. §6.3, tras la salida `--fake` de 05: «El «cacheado» de p02 es del simulador: la corrida real de §5.7 no reprodujo ese estado». |
| P-13 | RL-25 a | aplicado con desvío | `87f5937e…caaa` → `a545ea6c…2e18` | Nombrado en la fila `EMB_PLAN` (A.12): `GeneradorDeEmbeddingsEstable` (`MovilidadUrbana.Asistente.Comun.Pruebas`), doble de pruebas, «modo de demostración, no patrón para CTX-PROD». Desvío: §5.5 no menciona embeddings ni `EMB-C`; no se agregó texto allí (la propuesta del panel admite fila «o» §5.5). |
| P-14 | RL-14 a | aplicado con desvío | `a545ea6c…2e18` → `a4762321…07b8` | Preguntas de §6 (08, 2026-10-27): «4 de 4» y «digest no registrado» (sin registro accesible fuera del insumo archivado). §8.2: `qwen2.5:0.5b` digest `a8b0c5157701` desde el Sondeo del entorno. §8.5 (Historia «3400» 8 de 10): «digest no registrado, versión de Ollama no registrada». §11.7: rótulo completado desde R-16 (digest `d8b0f5e9760c`, Ollama 0.40.11, estación 2, 6 variantes × 10 repeticiones). Desvío: en §11.7 no se agregó k/n ni IC95 de «repitió el nombre», porque el registro no tiene oráculo para eso (sólo `inyeccion-indirecta`, 60 de 60 pasa); se rotula «recuento sin oráculo, sin tasa». |
| P-15 | RL-13 a | aplicado | `a4762321…07b8` → `8c0aacb1…a537` | §7.1: «en 17 entradas × 2 corridas = 34 consultas». |
| P-16 | RL-27 a | aplicado | guía sin cambio | `ClienteMcp.cs` (resumen de `PoliticaDeMontaje`, líneas 14-16): «En las dos, la descripción de la herramienta es la del cliente; el esquema y las descripciones de sus parámetros siguen siendo del servidor y son no confiables». sha256 `8980f629…deeb` → `86e43f86…9814`. |

Verificación (copia `{dir-de-trabajo}/relectura-lote2`, turno build del gestor, SDK 10.0 con el volumen de NuGet del laboratorio, sin servidor de modelos):
- `tools/verificar.sh build`: rc 0; compuerta R-PRIV del build 0. No se tocó la demo: `demo.sh pruebas` no se corrió.
- `tools/verificar-markdown.py guia`: sin hallazgos; REF 180/180.
- Barrido R-PRIV ampliado (`evidencia-rpriv/rpriv-ampliado.sh`, listas fuera del repo) sobre la guía, `ClienteMcp.cs` y esta bitácora: 0 en todas las clases.
- `find` de bin/ obj/ *.db en la guía: vacío.
Sin commit, push, PR ni ramas.

## Tramo P-17…P-24 (continuación, 2026-10-30)

Continuación tras el corte por límite de uso. La corrida anterior del tramo se cortó sin registrar nada; se comprobó cada parche contra el texto actual antes de tocar. Resultado: los ocho ya estaban aplicados enteros por la corrida cortada; esta continuación no editó la guía ni el repo (nada se aplicó dos veces).
Guía (`$DOC`) al cierre del lote 2: sha256 `8c0aacb1fd929ed3c729ed6ec665c7a98a4f00358c10681f58375bd6826ca537`. Guía al empezar esta continuación (ya con las ediciones de la corrida cortada): sha256 `5b4a24f6fafa77c5a71a24800b4b83f4d06c3b7404844dc12881f950e67bd95b`; después: el mismo. `tools/contar.sh` antes y después: Total 57.606/44.330 (130 %), Anexos 12.556 (169 %), Anexo C 452.
No hay sha256 por parche: la corrida cortada no los dejó; el par `8c0aacb1…a537` → `5b4a24f6…b95b` cubre el tramo entero.

| id | ítem | estado | nota / desvío |
|---|---|---|---|
| P-17 | RL-34 | ya aplicado por la corrida cortada | Primera línea del bloque `--fake` de §10: «[guion] salida simulada (--fake), no es medición». |
| P-18 | RL-02 | ya aplicado por la corrida cortada | Pregunta «¿Puedo usar un modelo para evaluar a otro?», §13.11 ADR-10 y §14.6 separan Historia (`qwen2.5:0.5b`, 0/52) de vigente (`qwen3.5:4b`, no medido, 41/52 < 45/52, 2026-10-29, ver §10.6). E.1 fila 15: «vigente `qwen3.5:4b` … (Historia: `qwen2.5:0.5b`)». |
| P-19 | RL-01 | ya aplicado por la corrida cortada | §10.6 «Lo que vio el laboratorio después» con el texto aprobado y rótulo `qwen3.5:4b`@`d8b0f5e9760c`, Ollama 0.40.11, 41/52, aviso de juez de la misma familia; sin 0,788 ni acuerdo. `ejemplo.json` («estado») con el mismo texto; JSON válido. sha256 actual `70261c90…b866`. |
| P-20 | RL-03 | ya aplicado por la corrida cortada | §10.6: «en la corrida del 2026-10-29 (no medida, ver abajo) juez y generador son el mismo modelo…»; «ser distintos…» sólo en la Historia. README de 15 (línea 13): misma corrección; «distinto del generador» queda sólo dentro de la Historia. sha256 actual `6b5f53d6…d862`. |
| P-21 | RL-04 | ya aplicado por la corrida cortada | §10.6 «Resultado: no calibrado»: «Acuerdo no medido: 0 de 10 salidas de calibración legibles (recuento, no tasa)»; sin IC. |
| P-22 | RL-28 | ya aplicado por la corrida cortada | §11.2: salidas distintas por entrada contadas en el registro (4, 1, 3, 2, 2 y 4 de 10; e02, 1 muestra); no se informa IC. Sin corrida nueva. |
| P-23 | RL-30 | ya aplicado por la corrida cortada; desvío de ubicación | La aclaración («13 no ejerce la regla 2 … `DelEjemplo` no monta escrituras; la regla la muestra 16») está en el «Lado servidor» de §11.5; la frase ancla «no confiables por procedencia» no figura textual en §11.5. Se deja. |
| P-24 | RL-31 | ya aplicado por la corrida cortada | §11.6 «Ollama no autentica» y §12.6 «Advertencia»: «…, y entonces lo alcanza todo contenedor de esa red». |

Verificación (sin copia ni turno build: no se tocó código ni scripts; `ejemplo.json` y el README no se compilan):
- `tools/verificar-markdown.py guia`: rc 0; REF 180/180.
- Barrido R-PRIV ampliado (`evidencia-rpriv/rpriv-ampliado.sh`, lista de 41 términos fuera del repo) sobre la guía, `ejemplo.json` y el README de 15: 0 en todas las clases.
- `find` de bin/ obj/ *.db en la guía: vacío.
Sin commit, push, PR ni ramas.

## Tramo P-25…P-30 (continuación, 2026-10-30)

Continuación tras el corte por límite de uso. Antes de tocar se comprobó cada parche contra el texto actual: ninguno de los seis estaba aplicado (ni entero ni en parte) por la corrida cortada, salvo un fragmento de P-28 (ver tabla). Se aplicaron uno por uno, por ancla y texto único.
Guía (`$DOC`) antes del tramo: sha256 `5b4a24f6fafa77c5a71a24800b4b83f4d06c3b7404844dc12881f950e67bd95b`; después: `5981e22323816149f5d698c7b21128f40de6cdecfc458968494e154da15de484`. `tools/contar.sh` antes: Total 57.606/44.330 (130 %); después: 57.718/44.330 (130 %).

| id | ítem | estado | sha256 de la guía antes → después | nota / desvío |
|---|---|---|---|---|
| P-25 | RL-29 | aplicado | `5b4a24f6…d95b` → `a7637f91…c95d` | §11, pregunta «¿La aprobación humana reemplaza la autorización?»: tras «quien conoce el id ve los datos [REF-186].» se agregó el texto aprobado con enlace a §14.6. |
| P-26 | RL-18 | aplicado; desvío menor | `a7637f91…95d` → `ebe5b083…1502` | `"${SDK_IMAGEN:-mcr.microsoft.com/dotnet/sdk:10.0}"` en el `docker run` de E.5, en `Examples/README.md` y en `compose.yaml:19`. Desvío: también en el extracto del compose de §12.6, para que la guía cite el archivo tal como queda. Defecto igual al actual (`docker compose config` resuelve `sdk:10.0`). |
| P-27 | RL-20 | aplicado | `ebe5b083…1502` → `47c07e8b…e4a` | §12.8, fila «Telemetría (no observada: se emite sin exportador)». |
| P-28 | RL-32 | aplicado; en parte ya estaba | `47c07e8b…e4a` → `0f30e061…85d` | ADR-06 «Confianza»: «Alta» → «Media» y se agrega que la demo aplica sólo la regla 2 (`SesionDeChat.cs:73`, `Crear()` por defecto; comprobado en el código), no medida con la composición vigente: el 0/6 es Historia. B.5 fila 4 ya decía «aplica la regla 2» (texto anterior al tramo); se completó con «sólo», la línea de código y el rótulo Historia. |
| P-29 | RL-24 | aplicado | `0f30e061…85d` → `a709560e…eb0` | §14.2: nodo `CO` «biblioteca común (_Comun) / FabricaDeClientes» y flecha `AIL → CO` rotulada «DependencyInjection.cs → FabricaDeClientes» (comprobado en el `DependencyInjection.cs` de la demo). |
| P-30 | RL-15 | aplicado en código y guía; corrida con modelo no hecha (desvío) | `a709560e…eb0` → `5981e223…484` | `tools/verificar.sh`: `DIGEST_CHAT_PROPIO="d8b0f5e9760c"` (qwen3.5:4b; Historia `a8b0c5157701`), selección y registro de digest por `qwen3.5:4b`, Ollama 0.40.11 sin cambio. Desvío: el defecto de `OLLAMA_PROPIO_MODEL` se cambió a `qwen3.5:4b` en las cuatro apariciones del script (460 y también 588, 661, 672), para que el esperado y el modelo cargado coincidan. Guía: E.3 nombra los esperados vigentes y rotula el digest del 0.5b como Historia; E.1 filas 02 y 05 «vigente `qwen3.5:4b` (Historia: `qwen2.5:0.5b`)» (15 ya lo estaba por P-18); A.12 rotula el defecto `qwen2.5:0.5b` como Historia. **No se corrió** `verificar.sh` contra la estación vigente: el defecto de `_Comun` sigue en 0.5b hasta P-31, que va en el mismo turno; esa corrida y su registro R-LLM quedan para el tramo de P-31. Sin cifras nuevas. |

Verificación (copia `{dir-de-trabajo}/relectura-lote4`, turno build del gestor, SDK 10.0 con el volumen de NuGet del laboratorio, sin servidor de modelos):
- `bash -n tools/verificar.sh`: ok. `tools/verificar.sh build`: rc 0; compuerta R-PRIV del build 0.
- `tools/demo.sh pruebas` (se tocó `compose.yaml`): rc 0; 81 pruebas superadas.
- `tools/verificar-markdown.py guia`: rc 0; REF 180/180.
- Barrido R-PRIV ampliado (`evidencia-rpriv/rpriv-ampliado.sh`, lista de 41 términos fuera del repo) sobre la guía, `Examples/README.md`, `compose.yaml`, `tools/verificar.sh` y esta bitácora: 0 en todas las clases.
- `find` de bin/ obj/ *.db en la guía: vacío.
Sin commit, push, PR ni ramas.

## Tramo P-31…P-34 (continuación, 2026-10-30)

Continuación tras el corte por límite de uso. Antes de tocar se comprobó cada parche contra el texto actual: ninguno de los cuatro estaba aplicado, ni entero ni en parte, por la corrida cortada. Se aplicaron uno por uno, por ancla y texto único.
Guía (`$DOC`) antes del tramo: sha256 `5981e22323816149f5d698c7b21128f40de6cdecfc458968494e154da15de484`; después: `c8defd8324497c4279a3dfd57ce5d2757326ad966813a9f9797d0196d9b7ce3d`. `tools/contar.sh` antes: Total 57.718/44.330 (130 %); después: 57.753/44.330 (130 %).

| id | ítem | estado | sha256 de la guía antes → después | nota / desvío |
|---|---|---|---|---|
| P-31 | RL-33 | aplicado en código y guía; corrida con modelo no hecha (desvío) | `5981e223…484` → `a8fce32e…19d9` | `ConfiguracionDelModelo.cs` (36 y 72) y `CapaDeOpcionesTests.cs:78`: defecto de `OLLAMA_PROPIO_MODEL` → `qwen3.5:4b`. A.12: «`qwen3.5:4b` (Historia (hasta el 2026-10-28): `qwen2.5:0.5b`)». Desvío: la corrida de `verificar.sh` contra la estación vigente (pendiente de P-30) **no se hizo**: este tramo no tenía turno de modelo ni servidor asignado. Queda «no medido», sin registro R-LLM y sin cifras nuevas. |
| P-32 | RL-17 | aplicado | `a8fce32e…19d9` → `b53d9f6e…88cc` | La tabla de E.5 pasa a F.4, con una columna «Registro» (R-05, R-D13, R-03/R-04, R-01/R-17, R-09/R-D9, R-15/R-15b parcial, R-D3, R-07/R-08/R-11/R-12/R-13/R-16/R-PD, según la bitácora 04-Aplicacion de B-11). Se aclara que el rango «a» va entre ejemplos y no es un intervalo. Los 45 min quedan como parámetro del operador. Todas las filas tienen registro, así que no hubo que rotular ninguna «no medido» (la regla quedó escrita). En E.5 queda una remisión a F.4, y «los prompts largos» de la estación 1 pasa a «la sonda de clase K»: la fila de más de 5.000 tokens es de la estación 2. |
| P-33 | RL-16 | aplicado | `b53d9f6e…88cc` → `59c360e6…29c2` | E.5: «`TOPE_COMPARTIDO_S`: tope de uso del ciclo en modo compartido; defecto 14.400 s (4 h), que el operador ajusta.». Se quitaron «tope de espera por llamada» y «no se escribe en el repositorio». El defecto se comprobó en `tools/verificar.sh:71`. |
| P-34 | RL-19 | aplicado | `59c360e6…29c2` → `c8defd83…3d` | E.6, tras «Qué mirar…»: bloque «Inventario y limpieza» con `docker ps -a` y `docker volume ls` filtrados por `label=${ETIQUETA}` (defecto `proyecto=guia-ia`, `verificar.sh:74`), `RLLM_DIR`, `RLLM_DIR/seco` y las marcas `.concedido.*`. Agrega una limpieza que conserva los `.jsonl` (prune de contenedores con la etiqueta y borrado de marcas) y el aviso de correr el `docker run` de E.5 sobre una copia de `Examples/`. |

Verificación (copia `{dir-de-trabajo}/relectura-lote5`, turno build del gestor, SDK 10.0 con el volumen de NuGet del laboratorio, sin servidor de modelos):
- `tools/verificar.sh build`: rc 0, todas las suites con 0 fallas (`Comun.Pruebas` 73/73, que incluye `CapaDeOpcionesTests`); compuerta R-PRIV del build en 0.
- No se corrió `tools/demo.sh pruebas` porque no se tocó la demo.
- `tools/verificar-markdown.py guia`: rc 0; REF 180/180.
- Barrido R-PRIV ampliado sobre la guía, los dos `.cs` y esta bitácora: ver la línea siguiente.
- `find` de bin/ obj/ *.db en la guía: vacío.
Sin commit, push, PR ni ramas. No llegaron mensajes ajenos a la carta.
- Barrido R-PRIV ampliado (`evidencia-rpriv/rpriv-ampliado.sh`, lista fuera del repo) sobre la guía, `ConfiguracionDelModelo.cs`, `CapaDeOpcionesTests.cs` y esta bitácora: 0 en todas las clases.
