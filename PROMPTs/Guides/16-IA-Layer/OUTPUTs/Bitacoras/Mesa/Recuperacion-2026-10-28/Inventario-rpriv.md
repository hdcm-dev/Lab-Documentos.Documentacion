---
doc_id: BIT-16-REC2-INV-rpriv
titulo: Inventario R-PRIV de la base restaurada (mesa de recuperación)
fecha: 2026-10-28
autor: inventariador «rpriv» de la mesa de recuperación
alcance: guía, Examples/, Demos/, tools/ y Compuertas/ de la guía 16; OUTPUTs/Bitacoras/; de paso, OUTPUTs/Reanudar.md y la reedición
estado: inventario (no aplica cambios)
traces: [Crear-IA-Layer-Guide-Reedicion R-PRIV, 04-Plan-De-Integracion v3 AC-7 y DEP-16, Evidencia/saneamiento-R-PRIV.md, compuerta v2 de la línea archivada (Ciclo-1/Ronda-2/aplicacion/rpriv.sh), plan de integración de la otra sesión (criterios §3 a §4)]
---

# Inventario R-PRIV de la base restaurada

## 0. Cómo se midió

- **Raíces.** La base restaurada en las rutas canónicas: la raíz de la guía (`Dot-Net-Integration-AI-Layer-Guide/`, con la guía 0.10.1, `Examples/`, `Demos/`, `tools/` y `Compuertas/`) y `OUTPUTs/Bitacoras/`. Además, de paso, `OUTPUTs/Reanudar.md` y `OUTPUTs/Crear-IA-Layer-Guide-Reedicion.md`, que están en `OUTPUTs/` y no en la línea archivada. No hay `bin/`, `obj/` ni `*.db` en la raíz de la guía.
- **Compuerta v2** de la línea archivada (`Linea-<fecha>/Bitacoras/Mesa/Ciclo-1/Ronda-2/aplicacion/rpriv.sh`), con sus sintéticos. Corrí sus 8 casos y los 8 dieron lo esperado.
- **Barrido S2 ampliado**, que escribí para esta mesa: [`evidencia-rpriv/rpriv-ampliado.sh`](evidencia-rpriv/rpriv-ampliado.sh). Suma las clases que la v2 no ve y que pide el plan de la otra sesión (R5 y A2): IP parcial y /16 de la red privada, `-home-<usuario>-`, usuario delante de una máscara, cualquier mención de la clave de cabeceras por pedido, contenedores y volúmenes del laboratorio, y herramienta y recursos de turnos. Pasa 7 casos positivos y 1 negativo (rango `100.64/10`, versiones `10.0.403`, `hit@3`, `127.0.0.1:11434`, `§10.4`).
- **Listas privadas, fuera del repo.** `{dir-de-trabajo}/rpriv-rec/rpriv-lista.txt` tiene 41 términos. Fusiona la lista DEP-16 de la base (rescatada de la máquina principal, 17 términos, autoprueba 17/17) con los de la línea archivada (equipos, usuario, contenedores, serie, apps y organización privadas, teléfono). También corrí las listas DEP-16 de la base tal como las usaba la base (`grep -rniF`).
- **Salidas guardadas** (sólo recuentos y rutas, nunca el texto): [`evidencia-rpriv/rpriv-v2-2026-10-28.txt`](evidencia-rpriv/rpriv-v2-2026-10-28.txt) y [`evidencia-rpriv/rpriv-ampliado-2026-10-28.txt`](evidencia-rpriv/rpriv-ampliado-2026-10-28.txt).
- **Cómo escribo los términos.** Acá van truncados (`ia-la…`, `oll…-l…`) para que este inventario no sume coincidencias. Sobre este archivo y su carpeta `evidencia-rpriv/`, el grep de la lista da 0.

## 1. Resumen de cifras (2026-10-28, 20:36–20:37)

| Raíz | v2: patrones / cabeceras | Lista DEP-16 de la base | IP parcial / home / usuario@máscara / cabeceras (mención) | Contenedores | Turnos | Identificadores (lista fusionada) |
|---|---|---|---|---|---|---|
| Guía (todo) | 0 / 0 | 0 (rd-po 0) | 0 / 0 / 0 / 0 | 11 líneas, 2 archivos | 52 líneas, 25 archivos | 75 líneas, 26 archivos |
| `Bitacoras/` sin `Recuperacion-2026-10-28/` | 0 / 0 | 0 (rd-po 1: I-06:10) | 0 / 0 / 2 falsos positivos / 0 | 84 líneas, 31 archivos | 571 líneas, 164 archivos | 548 líneas, 126 archivos |
| `Reanudar.md` | — | — | 0 / 1 / 0 / 0 | 5 | 0 | 16 |
| `Crear-…-Reedicion.md` | — | — | 0 | 0 | 0 | 1 (`<trabajo-fuera-del-repo>/ia-la…/`) |

**Lectura.** La base viene más limpia que la línea archivada. En toda la base no aparece ningún nombre de equipo, ni IP, ni ruta del home, ni usuario, ni la serie del teléfono, ni nombres de otros proyectos. La guía y `Bitacoras/` dan 0 en las cuatro clases de patrones; su `Evidencia/saneamiento-R-PRIV.md` ya había llevado la lista DEP-16 a 0. Lo que queda son tres clases que la base **no trató como privadas**: el recurso de turnos (`oll…-l…`), los nombres de contenedores y volúmenes (`ia-la…-*`) y la herramienta de turnos. A eso se suman la cita del PO de I-06:10, las menciones del teléfono en I-06 y en 06-Construccion, y `Reanudar.md`, que es de la línea archivada pero quedó suelto en `OUTPUTs/`. Los cuatro bloqueantes del plan de la otra sesión (ruta del home, usuario del rsync, /16 de la tailnet y app y organización en Reanudar) **no están en la base**, salvo el cuarto, que está en `Reanudar.md`. Los otros tres vuelven si se importan piezas de la línea archivada (RPRI-18).

**Aviso de esta mesa.** Las salidas de los otros inventariadores en `Mesa/Recuperacion-2026-10-28/` ya traen identificadores en claro: `Inventario-entorno.md` tiene 44 líneas y `Inventario-decisiones.md`, 59, sobre todo nombres de equipos (RPRI-20).

## 2. Unidades

### Guía, Examples, Demos y tools (repo público; dictamen: cero equipos, contenedores y recursos del laboratorio)

**RPRI-01 (S2). `tools/verificar.sh`: volúmenes y etiqueta del laboratorio escritos fijos.**
- `:65-88`: volúmenes `ia-la…-nuget` e `ia-la…-artefactos` y etiqueta `proyecto=ia-la…`, en `docker volume create` y en `-v`. El nombre del volumen de NuGet coincide con el volumen real del laboratorio, el mismo que usa el entorno de compilación vigente.
- Redacción propuesta: `NUGET_VOLUMEN="${NUGET_VOLUMEN:-guia-ia-nuget}"`, `ARTEFACTOS_VOLUMEN="${ARTEFACTOS_VOLUMEN:-guia-ia-artefactos}"` y `ETIQUETA="${ETIQUETA:-proyecto=guia-ia}"`, usados en `:65`, `:66-67`, `:70`, `:80`, `:83` y `:88`. Se documentan en la tabla de variables de `Examples/README.md:54-60`. El laboratorio exporta los nombres reales fuera del repo.
- Verificación: correr de nuevo `tools/verificar.sh` en seco (`--fake`), con el recurso `build`.

**RPRI-02 (S2). `Demos/MovilidadUrbana.Asistente/tools/demo.sh`: contenedor y volúmenes fijos.**
- `:34` (`VOL_ART=ia-la…-artefactos-demo`), `:37` (`CONTENEDOR=ia-la…-demo-asistente`), `:43-46`, `:56`, `:59`, `:63`, `:152` y `:154` (volumen de NuGet y etiqueta).
- Redacción: las mismas variables de RPRI-01, más `DEMO_CONTENEDOR="${DEMO_CONTENEDOR:-demo-asistente}"` y `DEMO_VOLUMEN="${DEMO_VOLUMEN:-guia-ia-artefactos-demo}"`.
- Verificación: `tools/demo.sh pruebas`.

**RPRI-03 (S4). `Demos/MovilidadUrbana.Asistente/compose.yaml`: `labels: [proyecto=ia-la…]`.**
- `:20`, `:56`, `:64`, `:68`, `:70` y `:72`. La etiqueta nombra el tema de la guía, no un equipo, pero la lista del laboratorio la cuenta igual.
- Propuesta: unificarla con la `ETIQUETA` de RPRI-01 (`proyecto=guia-ia`), para que la compuerta dé 0 sin excepciones. Si la presidencia la juzga pública, se declara por valor exacto en los sintéticos.

**RPRI-04 (S3). Nombre del recurso de turnos del servidor compartido (`oll…-l…`) en el protocolo del arnés.**
- Dónde aparece:
  - `tools/verificar.sh`: `:6`, `:19`, `:24`, `:37`, `:154`, `:159`, `:166`, `:171`, `:205`, `:264`, `:390`, `:392`, `:410`, `:413`, `:417`, `:419`, `:428`, `:461` y `:471`.
  - `demo.sh`: `:12`, `:123` y `:164`.
  - `Examples/README.md`: `:70`, `:82`, `:83` y `:102`.
  - `"recurso"` de `ejemplo.json` en 01, 03, 04, 07, 08, 09, 11, 12, 13, 16, 17 y la demo (`:2`).
  - READMEs: 03 `:22` y `:63`, 07 `:24`, 08 `:27` y `:72`, 09 `:97`, 11 `:100`, 12 `:33` y 13 `:33`.
  - Código: `07-RAG-Con-Citas/Program.cs:8` y `Infrastructure/TablaDeEmbeddings.cs:3`.
- La guía `.md` ya dice «servidor compartido» y da 0.
- Juicio: es el nombre de un recurso del gestor privado del laboratorio (criterio del plan: «generalizar»). Además el entorno cambió: el servidor que nombraba ya no existe, y el nombre lo heredó la estación de 4 núcleos.
- Redacción: el recurso pasa a llamarse `modelo-compartido` en `ejemplo.json`, en `verificar.sh` y en los READMEs. En prosa: «turno del servidor compartido». `verificar.sh` le pasa a `$TURNO_CMD` el valor de `REC_COMPARTIDO="${REC_COMPARTIDO:-modelo-compartido}"`, y el envoltorio del laboratorio hace el mapeo al recurso real. `TOPE_LAN_S` pasa a `TOPE_COMPARTIDO_S`.
- Es un cambio atómico (contrato `ejemplo.json` ↔ arnés). Para verificarlo hay que correr `verificar.sh` con `--fake` y las pruebas del arnés (`ArnesTests`).

**RPRI-05 (S4). `Examples/15-Pruebas-Y-Evaluacion/entradas/salidas-07.v1.json:10`: `turno_id` con el recurso y dos números de proceso.**
- El archivo está congelado: `ejemplo.json:6` fija su SHA-256, y según `README.md:43`, cambiarlo crea una `v2` y descarta las cifras de la `v1`.
- Juicio: no identifica ningún equipo; es un dato histórico de la corrida.
- Acción: dejarlo como está y declarar el valor exacto como histórico en la lista de sintéticos de la compuerta (por valor, nunca por archivo, como pide la regla de Ronda-2). Si RPRI-04 renombra el recurso, una nota en el README de 15 explica que el `turno_id` conserva el nombre viejo.

**RPRI-06 (S4). `RLLM_MAQUINA` es libre.**
- Aparece en `_Comun/Humo/Program.cs:43`, `01/Corrida.cs:67`, `03/Program.cs:66`, `05/Program.cs:97` y `11/Corrida.cs:214`.
- El campo `maquina` de los registros sale de una variable, y un lector puede poner ahí el nombre de su equipo. Los registros de la base sólo traen roles: `compartido` 126, `propio-remoto` 155 y `guion` 402.
- Redacción: en la tabla de variables de `Examples/README.md`, «`RLLM_MAQUINA`: un rol (`compartido`, `propio`), nunca el nombre del equipo». La compuerta sobre `OUTPUTs/` ya lo cubre a través de la lista.

**RPRI-07 (S4, informa). Clases limpias en la guía.**
- Dan 0: IP completa, IP parcial, `/home/`, `-home-<usuario>-`, `~/`, usuario, correos, MAC, tokens, clave de cabeceras (objeto y mención) y nombres de otros proyectos.
- Las URL son públicas, o bien `localhost`, `127.0.0.1`, `*.invalid` y `*.example`.
- Las 30 cabeceras `// Procedencia: Lab-E2E.WebBlazor/… @ 8fb4c3a` y `tools/diff-base.sh` nombran el repo **público** del caso único (`hdcm-dev/Lab-E2E.WebBlazor`, REF-186): quedan.
- Los rótulos «servidor compartido» y «Ollama propio» son roles. El rótulo de la corrida vieja como historia lo decide otra unidad (entorno), no R-PRIV.

### Bitácora `OUTPUTs/Bitacoras/`

**RPRI-08 (S2). `Mesa/I-06-Directiva-Del-PO-Caso-Unico-Y-Medios.md:10`: la cita literal del PO nombra el dominio de otro proyecto privado.**
- Es la única coincidencia de la lista RD-PO de la base. La base la dejó como excepción escrita en `Compuertas/rd-po-4.excepciones` («cita textual que no se toca»).
- Criterio del plan de la otra sesión: parafrasear, porque contradice RD-PO-2 del mismo archivo (`:15`).
- Redacción: «Palabras del PO, en paráfrasis: el borrador de agentes viene de otro proyecto privado y no se mezcla; el caso es Movilidad Urbana.» Después se quita la excepción de `rd-po-4.excepciones` y se corre `grep -rniF -f $RD_PO_LISTA`, que debe dar 0.

**RPRI-09 (S2). Teléfono del PO y herramienta del laboratorio en I-06 y en 06-Construccion.**
- I-06:
  - `:27`: marca y modelo del teléfono, y «por adb remoto».
  - `:28`: el apodo del teléfono y la ruta `/tools/medios/recur…/` del gestor privado.
  - `:29`: «aplicaciones de producción del PO».
- `06-Construccion.md:123`: el apodo del teléfono, en la lista de recursos ajenos que no se tocaron.
- Redacción:
  - `:27`: «un teléfono Android de prueba del PO (`<teléfono-de-prueba>`), por acceso remoto».
  - `:28`: «(`<teléfono-de-prueba>`, emulador, servidor compartido, compilaciones pesadas) … a través del gestor de turnos del laboratorio (privado)».
  - `:29`: «sólo se instalan o desinstalan paquetes propios del ensayo; las demás aplicaciones del teléfono no se tocan».
  - `06-Construccion.md:123`: «emuladores, `<teléfono-de-prueba>`, imágenes…».

**RPRI-10 (S3). Contenedores, volúmenes, red y etiquetas de turno del laboratorio: 84 líneas en 31 archivos.**
- Por nombre:
  - `ia-la…-ollama`: 26.
  - `ia-la…-nuget`: 24.
  - `ia-la…-red`: 12.
  - `ia-la…-artefactos*`: 20.
  - `ia-la…-redac-cierre`: 6.
  - `ia-la…-arnes`: 3.
  - `ia-la…-[recurso-modelo-propio]`: 1.
  - `n3b-oll…`: 7.
  - `n3-oll…` y `n3-nu…`.
- Dónde, en prosa y planes:
  - `04-Plan-De-Integracion.md:679`, `:820`; v2 `:613`, `:652`, `:773-777`; v1 `:619`; v0 `:535`.
  - `06-Construccion.md:128-132`, `:146`, `:149`.
  - `07-Redaccion.md:228`.
  - `Sondeo-Entorno.md:129`, `:174`.
  - `Nucleos/N3b-…md:383`, `:444-463`.
  - `Mesa/Ciclo-1/05-Parches.md:586`.
  - `Mesa/Ciclo-2/`: `03-Consolidacion.md:117`, `04-Veredictos.md:62`, `05-Parches.md:253`, `:351-355`, `02-Informes/operacion.md:63`, `:70-71`.
  - `Mesa/Ciclo-3/`: `02-Informes/{desarrollo:82, AH-02:87, requisitos:78, :89, operacion:47, :80}`, `05-Parches.md:254`, `:372-373`, `:383`, `07-Aplicacion-Y-Verificacion.md:35`, `:39`.
- Dónde, en capturas:
  - `Evidencia/Cierre-Redaccion/{limpieza.redac.log:5,8-10; verificar-build.redac.log:2,776; demo-pruebas.redac.log:2,626}`.
  - `Evidencia/Cierre-Construccion/limpieza.saneo.log:4,14,18`.
  - `Evidencia/08-…/pruebas-reanudacion.log:1,13`.
  - `Evidencia/Arnes/{04-…reverificacion.log:2; 09-…fake.log:2}`.
- Criterio del plan: redactar.
- Redacción:
  - En prosa y en planes: `<ollama>`, `<volumen-nuget>`, `<volumen-artefactos>`, `<red-del-arnés>` y `<etiqueta-de-turno>`.
  - En los scripts citados: `$OLLAMA_CONTENEDOR` y `$NUGET_VOLUMEN`.
  - En las capturas `.log`, que nada fija por hash, un `sed` por mapa de valor exacto (cada nombre a su marcador), con un diff que muestre que sólo cambian esos tokens.
- Los límites de CPU y memoria y `/root/.nuget` pueden quedar.

**RPRI-11 (S3). Herramienta y recurso de turnos: 571 líneas en 164 archivos.**
- Recurso del servidor compartido: unas 500 líneas en 107 archivos. Los que más tienen:
  - `Evidencia/R-LLM/16-…modelo.jsonl` (24), `16-…interrumpida-1.jsonl` (16), `07-…modelo.jsonl` (16) y `08-…modelo-ext.jsonl` (14).
  - `04-Plan-De-Integracion.md` (20), su v2 (18) y su v1 (12).
  - `Evidencia/Cierre-Construccion/medidor-gestor.cierre.tsv` (19) y `Evidencia/P4-Corridas-Modelo/turnos-gestor.p4.tsv` (15).
  - `Mesa/Ciclo-2/05-Parches.md` (18), `Ciclo-3/05-Parches.md` (15) y `Ciclo-1/05-Parches.md` (13).
- `con-recur…`/`recur…sh`: 93 archivos.
- Ruta `tools/medios/recur…`:
  - `Mesa/Ciclo-1/05-Parches.md:39`.
  - `Mesa/Ciclo-2/{08-Cierre:129; 05-Parches:871; 09-Respuestas-De-La-Presidencia:31; 02-Informes/operacion:13}`.
  - `Mesa/Ciclo-3/{05-Parches:54,549; 08-Cierre:9,112,126; 02-Informes/AH-02:17; arquitectura:18; didactica:17; operacion:19}`.
  - I-06:28 (ver RPRI-09).
- Juicio: la lista DEP-16 de la base no incluye estos nombres, así que la base los tomó por públicos. El plan de la otra sesión los pone en «revisar» con la dirección «generalizar». No identifican equipos ni personas, pero describen la herramienta privada del laboratorio.
- Acción:
  - En prosa: «gestor de turnos del laboratorio (privado)» y «turno del servidor compartido», con el mismo nombre de recurso que RPRI-04.
  - En capturas que alimentan recálculos (`R-LLM/*.jsonl`, `*.tsv` del gestor): se dejan y se declaran por valor exacto como históricas, porque reescribirlas invalida los recálculos de los oráculos y los hashes citados.
  - La presidencia decide si la clase entra en la lista, con dictamen fechado (C1-39).

**RPRI-12 (S4). Marcadores de rutas: dos convenciones conviven.**
- La base usa `<trabajo-fuera-del-repo>/ia-la…/…` en 19 lugares de 13 archivos:
  - `Sondeo-Entorno.md:5`, `:197`.
  - `00-Contrato-De-Entrada.md:70`.
  - `06-Construccion.md:129`, `:134`.
  - `Nucleos/N0b:428,464`, `N1:433,434,514`, `N1b:284,351` y `N3b:378,504`.
  - `Mesa/Ciclo-1/02-Informes/ingenuo.md:53` y `Mesa/Ciclo-2/02-Informes/operacion.md:39`.
  - `Evidencia/saneamiento-R-PRIV.md:14`, `Evidencia/Cierre-Redaccion/limpieza.redac.log:14` y `Evidencia/Cierre-Construccion/limpieza.saneo.log:5`.
  - Además, `../Crear-IA-Layer-Guide-Reedicion.md:116`.
- `origin/main` fijó `{dir-de-trabajo}`, `{dir-de-sesion}` y `{tmp-de-sesiones}` (PR #25).
- Redacción: `<trabajo-fuera-del-repo>/ia-la…/X` pasa a `{dir-de-trabajo}/X`. Donde se habla de un lugar concreto del scratchpad de la sesión, va `{dir-de-sesion}`: `06-Construccion.md:147`, `limpieza.saneo.log:15` y `limpieza.redac.log:16`. La mención genérica «scratchpad de la sesión» en informes (13 archivos) puede quedar.

**RPRI-13 (S4, informa). Rutas desde la raíz del workspace (`/LAB/…`, `/IA/…`): 33 líneas en 11 archivos.**
- Están, por ejemplo, en `README.md:132`, `00-Contrato-De-Entrada.md` y los planes v0, v1 y v2.
- Quedan: `origin/main` ya publica los `Crear-*.md` con las mismas rutas (plan de la otra sesión, §3).
- Excepción: `/tools/medios/recur…`, que va por RPRI-11.

**RPRI-14 (S3). Material de terceros y nombre comercial del curso.**
- Nombre del curso: `README.md:34-35` y `02-Cohesion-Global.md:16`, `:18`.
- Transcripciones «no citables»: I-02, I-03 e I-04.
- PNG de terceros: `Mesa/I-02…png`, `I-03…png` e `I-04…png`.
- Criterio del plan: redactar el nombre («índice de un curso en línea de terceros»), resumir las transcripciones y excluir los PNG.
- No es R-PRIV estricto; lo dejo para la unidad de contenido y propiedad, con este cruce.

**RPRI-15 (S4, informa). Huella del entorno viejo.**
- `Sondeo-Entorno.md:25-31` lista los modelos instalados en el ex servidor de la LAN. Ese servidor lo operaba otra persona.
- `N3b` y `Ciclo-2/02-Informes/operacion.md:47` dicen «CPU de 8 núcleos». La base no trae modelo de CPU ni RAM: la huella de hardware del plan sólo aplica a la línea archivada.
- `<servidor-lan>` (`Nucleos/N3-Evidencia/salidas.md:35-64`) es un marcador y está bien.
- Acción: nada por R-PRIV. Que se rotulen como historia lo decide la unidad de entorno (el servidor ya no existe).

**RPRI-16 (S1). `OUTPUTs/Reanudar.md`: nota de reanudación de la línea archivada, suelta en `OUTPUTs/`.**
- Fecha de modificación: 18:19. Tiene 16 líneas con identificadores:
  - Nombres de los tres equipos: `:1`, `:3`, `:6`, `:12-14`, `:27`, `:33`, `:35-38`, `:44`, `:60`.
  - Contenedor y volumen: `:14`, `:35`, `:36`, `:45`.
  - Ruta bajo `~`: `:13`.
  - **El feed de una organización privada**: `:37`.
  - **Emuladores con el nombre de una app privada**: `:38`.
- El plan de la otra sesión marca `:37-38` como bloqueantes.
- Acción:
  - Mover la nota a `Linea-<fecha>/` (es de esa línea; la base no la tiene) o dejarla fuera de todo commit.
  - Si se conserva una nota de reanudación de la base, se escribe con roles (`<equipo-principal>`, `<equipo-respaldo>`), con «feed privado configurado» y con «un emulador Android en contenedor».

**RPRI-17 (S2). La base no tiene compuerta R-PRIV ejecutable con patrones.**
- La base sólo tenía `grep -rniF -f $R_PRIV_LISTA` (DEP-16, `saneamiento-R-PRIV.md`), y AC-7 del plan v3 (`04-Plan-De-Integracion.md:979`) exige R-PRIV en cero sobre todo lo escrito.
- Propuesta:
  - Adoptar en la base la compuerta v2 de la línea archivada (los 8 casos verificados hoy) más el barrido ampliado de esta mesa (`evidencia-rpriv/rpriv-ampliado.sh`, 7+1 casos).
  - La lista fusionada se queda fuera del repo (`{dir-de-trabajo}/rpriv-rec/`). Hay que retocar la clase `usuario-mascara` para que no tome `paquete@versión` (falsos positivos en `Nucleos/N2:488` y `N1b:356`).
- Criterio de cierre propuesto:
  - Raíz de la guía: v2 `patrones=0 identificadores=0 cabeceras=0`, y ampliado en 0 en todas las clases.
  - `OUTPUTs/`: `patrones=0`, `cabeceras=0` y las cuatro clases nuevas en 0. Los identificadores y los turnos se informan hasta que haya dictamen.
  - Salida guardada con fecha.

**RPRI-18 (S3). Criterio de importación desde la línea archivada.**
- Toda pieza de `Linea-<fecha>/` que entre a la base trae los bloqueantes que el plan de la otra sesión encontró ahí:
  - La ruta del home con el usuario en `Ronda-2/evidencia-AH-01-seguridad/README.md`.
  - El usuario del rsync y el /16 de la tailnet en `evidencia-AH-01-seguridad-llm/sonda-salida.txt`.
  - El directorio con el nombre del equipo de respaldo, `Ronda-2/evidencia-<equipo>-ollama/`.
  - La huella de CPU y RAM.
  - La localidad ajena de `E-DEF-1/Program.cs:18`.
  - Los nombres de equipos en 62 a 68 archivos.
  - Esto incluye los 13 `Informe-*.md` de relectura y `evidencia-examples/`.
- Acción: se copia aplicando las redacciones del plan (marcadores de su §4), se renombra el directorio y se corre el barrido ampliado sobre lo copiado antes de darlo por integrado. Nada se trae a granel.

**RPRI-19 (S4, informa). Falsos positivos del barrido.**
- `usuario-mascara`: 2 líneas (`paquete@versión`).
- La «IP parcial» con `10.` no se busca, porque choca con versiones (`10.0.403`, `10.11.0`) y con secciones (`§10.4`).
- Los recuentos `@` de la línea archivada (`hit@1`, `recall@3`) no son direcciones.
- Nada que hacer.

**RPRI-20 (S3). Las salidas de esta mesa ya traen identificadores en claro.**
- En `Mesa/Recuperacion-2026-10-28/`, `Inventario-entorno.md` tiene 44 líneas e `Inventario-decisiones.md`, 59. Son nombres de equipos (medido a las 20:37; ver `evidencia-rpriv/rpriv-v2-2026-10-28.txt`).
- Esta carpeta va a `Bitacoras/`, que es bitácora del repo público.
- Acción: la presidencia pide que los inventarios usen roles (`<equipo-principal>`, `<equipo-respaldo>`, «estación de laboratorio de 4 núcleos», «estación con más núcleos»), o los redacta al consolidar. Antes de cerrar la mesa, el barrido ampliado sobre la carpeta tiene que dar 0 identificadores.

## 3. Marcadores (los del plan de la otra sesión, sin convenciones nuevas)

`{dir-de-trabajo}`, `{dir-de-sesion}`, `{tmp-de-sesiones}`; `<usuario>`; `203.0.113.x` para IP; `<privado>`; `<equipo-principal>`, `<equipo-respaldo>` y `<teléfono-de-prueba>`; `$OLLAMA_CONTENEDOR` y `$NUGET_VOLUMEN` en scripts; `<ollama>`, `<volumen-nuget>` y `<volumen-artefactos>` en salidas. Uno solo es nuevo: `modelo-compartido`, el nombre público del recurso de turnos (RPRI-04).

## 4. Qué no hice

No modifiqué nada de la base, de la guía ni de la línea archivada. Sólo agregué esta carpeta `evidencia-rpriv/` y este archivo. No compilé ni corrí nada contra el modelo. No toqué la máquina principal: sólo leí, en la copia de rescate, las listas DEP-16 de la base, y no reproduzco su contenido.
