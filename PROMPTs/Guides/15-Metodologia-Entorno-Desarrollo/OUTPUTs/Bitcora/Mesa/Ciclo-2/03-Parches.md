# Mesa · Ciclo 2 · 03 — Parches del cuerpo auditor

> Fecha: 2026-10-09. Rol: cuerpo auditor (marco `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §4.4 y §5.4). **No vota sus propios parches**: los somete a la mesa de aprobación (§5.5).
> Artefacto: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (1.0.0-rc.1, 3391 líneas, 53 363 palabras). «L*n*» = línea de esa versión. Insumos: `01-Consolidado.md`, los cinco `02-Voto-*.md` y los doce `Informe-*.md` de esta carpeta, con sus `evidencia-*/`.
> Alcance: los 40 ítems con veredicto PROCEDE (C2-01 a C2-40) y el lote S4 completo (C2-41 a C2-58), que el auditor decide aplicar.
> Evidencia nueva del auditor: [`evidencia-auditor/`](evidencia-auditor/) (§6). Fuentes nuevas consultadas el **2026-10-09** (B205–B217).

## 0. Cómo leer este documento

- Cada parche agrupa los hallazgos que tocan **la misma sección** de la guía (marco §5.4). Un hallazgo que toca varias secciones aparece en varios parches; la tabla de cobertura (§7) dice dónde.
- **Texto exacto.** Cada op de §3 cita su ancla literal y el texto nuevo completo, entre `~~~~`. El mismo contenido está en forma ejecutable en [`evidencia-auditor/simulacion/parches_guia.py`](evidencia-auditor/simulacion/parches_guia.py): `GUIA=<ruta> python3 gen.py` aplica los 21 parches, en orden, a una **copia** de la guía (no toca el original), falla si un ancla no es única, mide el Δ de palabras y deja el resultado en `guia-parcheada.md`. La copia de esta revisión está ahí mismo y pasó los chequeos de §8.
- **Capa de origen.** Si el defecto nació en un núcleo o en la bitácora del ciclo 1, P-22 lo corrige allí con notas de solo agregado (marco §5.5).
- **Laboratorio.** P-23 lista los cambios de `Examples/`, cada uno con su fuente ya probada en `evidencia-auditor/` y el experimento que hay que volver a correr.
- **Marcas.** Todo texto nuevo usa el vocabulario cerrado de §0.3: `**[criterio]**`, `**[no verificado]**` (motivo), `**[observado]**` (con versión), `**[interpretación]**`.
- **Presupuesto.** Cada parche declara su Δ de palabras, en dos cubos (§2).

## 1. Decisiones de dirección

### 1.1 Las seis contradicciones

Votos de dirección leídos en el fundamento de cada juez. El de evidencia no vota dirección: juzga la prueba de las premisas, y sus salvedades se aplican.

| Ítem | Coherencia | Costo-beneficio | Impacto | Riesgo | Evidencia (salvedad) | Resultado | Lo que aplica el auditor |
|---|---|---|---|---|---|---|---|
| C2-01 | A + B | A (B «baja el tono») | A + B | A + B | las dos premisas probadas, no se excluyen | **A + B, 3-1** | `NU1603` como error **activo** en A.4 para las dos políticas, y el chequeo `requested` = `resolved` en la compuerta, con E1 (C2-03). La fila «sin lock» de §6.4 lo conserva; la «con lock» lo suma junto con la compuerta. |
| C2-05 | B | A | A | B | «la evidencia nueva justifica admitir la reapertura» | **Empate 2-2** | **Síntesis**, como en C1-10: no se reabre C1-08 (la compuerta propia sigue siendo la de A.11, y se repara: C2-07, C2-08), y de A se toma lo que no la contradice: editorconfig-checker queda como **reemplazo del paso de texto dentro de la misma compuerta** (§5.2.5) y `verificar.sh` deja de ofrecerse como pieza copiable (C2-06 (a), lo que pedían A, coherencia y riesgo). Para que (a) no deje sin compuerta a los proyectos en subcarpetas, la compuerta de N7 los **descubre** con `git ls-files` (evidencia X2, X3). **Se marca para la mesa de aprobación**: si la síntesis no se acepta, el empate pasa a `INSUFICIENTE` y a segunda ronda (marco §5.3). |
| C2-13 | B | A | A | A | la alternativa existe; «igual rango para 8a» sin probar (registro del runner) | **A, 3-1** | §12 paso 7 y §8.2.2 con dos caminos: imagen propia por digest (8b, reconstrucción bit a bit, frontera A en la CI) o runner alojado con acciones de *setup* por SHA (alcanza para 8a). Salvedad de evidencia: la capa 4 del runner queda en el log «Set up job» [B216], no en un dato que el registro lea; se declara así (A.17 escribe `imagen=NO DECLARADA (…)`). C2-14, C2-17 y C2-18 se aplican igual al camino de imagen (riesgo e impacto). |
| C2-15 | síntesis: comprimir conservando C1-17, C1-32 y C2-16 | comprimir | comprimir | comprimir | las dos premisas probadas | **Comprimir, 4-0** | §9.2.4 baja de 931 a 599 palabras, con C2-16 en dos oraciones; la tabla de plataformas pasa **intacta** a §9.3, donde está «qué propone la industria». |
| C2-29 | calificar por versión | A | A | calificar sin re-fechar | lado B sólo si la guía fijara sus datos al 2026-10-07 | **A, 4-0** | Calificar por versión con la fuente nueva [B205]; las fechas de §0.3 y del Anexo F se dicen por fuente (C2-49), sin re-fechar la guía. |
| C2-36 | Δ por parche y saldo de prosa ≤ 0, sin meta dura | Δ y saldo ≤ 0; 48 000 orientativa | saldo negativo, compensando con C2-37 | NO_PROCEDE el tope duro; Δ informativa | — | **Δ por parche y saldo de prosa propia ≤ 0; sin tope de 48 000** | Las citas y la evidencia se presupuestan aparte (coherencia, riesgo). Resultado en §2: prosa −46, evidencia y plantillas +950. |

### 1.2 Direcciones dentro de ítems no contradictorios

| Ítem | Opciones en el consolidado | Votos | Lo que aplica el auditor |
|---|---|---|---|
| C2-02 | condición `Exe Or WinExe`; nota de pruebas; aviso de la compuerta; EA-1 con WinExe | todos por la condición; riesgo: EA-1 obligatorio | Condición, nota y EA-1 paso 2c. El aviso de «ejecutable sin lock» en la compuerta **no** se agrega: exige evaluar cada proyecto con MSBuild en cada corrida, y la regla queda cubierta por A.4b, EA-1 y B.2 (§9). |
| C2-03 | compuerta con E1, o bajar el tono | costo: bajar el tono; los otros tres: compuerta | Compuerta, sólo si `--locked-mode` pasó (así E7-03 no cambia), con su límite **[criterio]** y el remedio (subir la `PackageVersion`). |
| C2-06 | (a) retirar `verificar.sh`; (b) repararlo | coherencia, costo, riesgo: (a) | (a), con la compuerta de N7 que descubre subcarpetas. |
| C2-07 | (a) instalar el paquete en A.10; (b) chequear `import editorconfig` | coherencia: (a)+(b) | (a)+(b). |
| C2-09 | declarar el límite; o fallar si hay manifiesto sin lock marcado | costo y riesgo: declarar | Declarar el límite (§10.2.2, §10.4). |
| C2-11 | `safe.directory`; o `remoteUser` no root; EA-1 con `devcontainer up` | riesgo: acotar a la carpeta y EA-1; costo: no alargar EA-1 | `safe.directory ${containerWorkspaceFolder}` (no `'*'`) y EA-1 paso 10 (≈ 1 min con la imagen en caché, X4). |
| C2-12 | B ampliada; dos bloques activos; normalizar sin BOM | coherencia, riesgo: B ampliada; costo: no duplicar bloques | B ampliada, con el aviso de que los `Directory.Build.*` del anexo se guardan con BOM (X5); A.1 sigue con un solo bloque activo. |
| C2-14 | A.x de registro + job completo; o corregir `registrar-entorno.sh` y §11.8 | riesgo: no inventar un job de SBOM sin E1 | A.17 con su salida (X2), pasos de build y registro en A.12 corridos en la imagen (EA-1 paso 9), §11.8 corregido; el SBOM queda a cargo del equipo (§9.2.3). |
| C2-31 | acotar a Linux/macOS; o agregar la excepción | evidencia: acotar sería un error nuevo (PEP 3120) | La condición de plataforma va a Roslyn, no a Python; Python lleva la excepción del cp1252 que forma UTF-8 válido. |
| C2-32 | reponer §11.9.1 con E8-1 (o X1); criterio corto o reformular §0.2 | coherencia: E8-1; costo: reformular §0.2 | Las dos: §0.2 dice «o, en las de diseño, el criterio para evaluarla», y §6.9.2 y §10.9.2 llevan un criterio de una línea; §11.9 con E8-1 y una segunda consigna sobre EA-1. |
| C2-35 | fijar términos y glosario; sin renombrado masivo | riesgo: prohibido el reemplazo global | Sólo las ocurrencias señaladas, las cinco «registro de entorno» de prosa (no las de bloques que copian archivos del laboratorio) y cuatro entradas en el Anexo C. |
| C2-56 | `1.0.0` y `status` acorde, al cierre | — (lote S4) | `version: 1.0.0`, `status: vigente` (el valor que usan 14 guías de la colección), condicionado a la aprobación de este lote. |

Lote S4: el auditor aplica los 18 (C2-41 a C2-58).

## 2. Balance de palabras (C2-36)

Medido por `simulacion/gen.py` sobre la guía 1.0.0-rc.1 (53 363 palabras con `wc -w`), aplicando los parches P-01…P-21 en orden. «Prosa» cuenta las palabras fuera de bloques de código, de filas de la bibliografía y de líneas de contrato YAML; «evidencia y plantillas», el resto (código, salidas, filas `[Bnn]`, contrato). Un op marcado como evidencia que no contiene un bloque completo se imputa entero a ese cubo.

| Parche | Δ prosa | Δ evidencia y plantillas |
|---|---|---|
| P-01 | +11 | +0 |
| P-02 | +72 | +0 |
| P-03 | -28 | -7 |
| P-04 | +24 | +0 |
| P-05 | -115 | +0 |
| P-06 | -74 | -2 |
| P-07 | -26 | +0 |
| P-08 | -93 | +0 |
| P-09 | +36 | +1 |
| P-10 | -9 | +25 |
| P-11 | -167 | +37 |
| P-12 | -34 | +21 |
| P-13 | -110 | +7 |
| P-14 | +128 | +111 |
| P-15 | +278 | +506 |
| P-16 | +78 | +0 |
| P-17 | +92 | +0 |
| P-18 | +8 | +251 |
| P-19 | +12 | +0 |
| P-20 | +36 | +0 |
| P-21 | -165 | +0 |
| **Total** | **-46** | **+950** |

Resultado: la guía pasa de 53 363 a 54 267 palabras; la **prosa propia baja 46** y lo que crece es evidencia y plantillas copiables (trece fuentes nuevas, A.12 completo con su variante, A.17, A.18, el contrato de §12). El presupuesto se cumple como lo votó el jurado (§1): saldo de prosa no positivo, sin tope duro y sin recortar ninguna cita (las `[Bnn]` pasan de 204 a 217; ninguna desaparece).

## 3. Parches sobre la guía

Operaciones: **Reemplazar** (fragmento único, búsqueda literal) · **Reemplazar todas** · **Reemplazar la línea** (la única línea que empieza con el prefijo dado; se cita la línea vieja) · **Reemplazar el rango** (desde el marcador inicial, incluido, hasta justo antes del final; los dos únicos). El orden de los ops dentro de cada parche es el de aplicación; `simulacion/gen.py` los aplica en este orden y falla si un ancla no es única.

### P-01 · Front matter, banda de versión e índice

- **Hallazgos**: C2-56, C2-49, C2-34, C2-14, C2-53.
- **Sección**: Front matter L5–L15; banda L26; índice L43, L48.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras**: prosa +11, evidencia y plantillas +0.
- **Verificación**: `grep -c '^version: 1.0.0$'` → 1; `grep -c '^status: vigente'` → 1; `grep -c '217 fuentes'` → 1; slugs del índice = encabezados `##` (script de anclas del ciclo 1, `aplicacion/`): 20 = 20, 0 rotos.

1. Reemplazar

~~~~text
version: 1.0.0-rc.1
status: borrador
~~~~

por

~~~~text
version: 1.0.0
status: vigente
~~~~

2. Reemplazar

~~~~text
fuentes_consultadas: "2026-10-07; B194–B204: 2026-10-09"
~~~~

por

~~~~text
fuentes_consultadas: "2026-10-07; B194–B217: 2026-10-09"
~~~~

3. Reemplazar

~~~~text
> **Versión 1.0.0-rc.1.** Fecha: 2026-10-09
~~~~

por

~~~~text
> **Versión 1.0.0.** Fecha: 2026-10-09
~~~~

4. Reemplazar

~~~~text
(204 fuentes, Anexo D), más 73 experimentos ejecutables (Anexo E).
~~~~

por

~~~~text
(217 fuentes, Anexo D), más 73 experimentos ejecutables (Anexo E).
~~~~

5. Reemplazar

~~~~text
Dockerfile, hook, CI, bots, `CODEOWNERS`, ADR; verificadas juntas.
~~~~

por

~~~~text
Dockerfile, hook, CI, bots, `CODEOWNERS`, ADR, registro del entorno y `.gitignore`; verificadas juntas.
~~~~

6. Reemplazar **todas** las apariciones de

~~~~text
#anexo-f-límites-y-lo-que-no-se-verificó
~~~~

por

~~~~text
#anexo-f-trazas-límites-y-lo-que-no-se-verificó
~~~~

7. Reemplazar

~~~~text
- **[Anexo F. Límites y lo que no se verificó](#anexo-f-trazas-límites-y-lo-que-no-se-verificó)**: hechos, interpretaciones y pendientes, separados.
~~~~

por

~~~~text
- **[Anexo F. Trazas, límites y lo que no se verificó](#anexo-f-trazas-límites-y-lo-que-no-se-verificó)**: qué pedido cubre cada sección; hechos, interpretaciones y pendientes, separados.
~~~~


### P-02 · §0 Cómo usar esta guía

- **Hallazgos**: C2-32, C2-33, C2-51, C2-49, C2-40, C2-27, C2-24, C2-10, C2-37.
- **Sección**: §0.2 L65–L81; §0.3 L87–L97; §0.4 L109–L111.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras**: prosa +72, evidencia y plantillas +0.
- **Verificación**: `grep -c 'únicas cinco'` → 0; `grep -c 'consultada el 2026-10-07\.'` → 0; `grep -c 'MSYS_NO_PATHCONV=1'` → 1 en §0.4; `grep -c 'cli-plugins'` → 1; la tabla de la ruta mínima tiene 9 filas; el comando de §0.4 corrido tal cual da `buildx v0.35.0` (evidencia-auditor/x0-docker-config/salida.txt).

1. Reemplazar

~~~~text
Al cierre de cada capítulo, su **Práctica**, sobre la ruta mínima de abajo |
~~~~

por

~~~~text
Al cierre de cada capítulo, su **Práctica**, sobre la ruta mínima de abajo o un experimento vecino |
~~~~

2. Reemplazar

~~~~text
→ **Práctica** (dos consignas sobre experimentos que ya existen, con la respuesta esperada).
~~~~

por

~~~~text
→ **Práctica** (dos consignas sobre experimentos que ya existen, con la respuesta esperada o, en las de diseño, el criterio para evaluarla).
~~~~

3. Reemplazar

~~~~text
| §11 | E8-1 | Qué se rompe primero en un repo con los tres ecosistemas |
~~~~

por

~~~~text
| §11 | E8-1 | Qué se rompe primero en un repo con los tres ecosistemas |
| §12 | los de cada paso | La hoja de ruta, validación por validación (Práctica integradora) |
~~~~

4. Reemplazar

~~~~text
Afirmación respaldada por la fuente B12 del [Anexo D](#anexo-d-bibliografía), consultada el 2026-10-07. |
~~~~

por

~~~~text
Afirmación respaldada por la fuente B12 del [Anexo D](#anexo-d-bibliografía), consultada en la fecha que indica su fila. |
~~~~

5. Reemplazar

~~~~text
Resultado del experimento E4-2, ejecutado el 2026-10-07; la carpeta,
~~~~

por

~~~~text
Resultado del experimento E4-2, ejecutado en la fecha de su salida; la carpeta,
~~~~

6. Reemplazar

~~~~text
Son las únicas cinco marcas, siempre en negrita.
~~~~

por

~~~~text
Son las únicas cuatro marcas de juicio, siempre en negrita; `[Bnn]`, IDs y rutas no la llevan.
~~~~

7. Reemplazar

~~~~text
puede omitir líneas que no hacen al punto (se marca con `...`) pero nunca altera una línea mostrada.
~~~~

por

~~~~text
puede omitir líneas que no hacen al punto (se marca con `...`) o acortar una línea (con `…`), pero nunca altera lo que muestra.
~~~~

8. Reemplazar

~~~~text
Si las credenciales de Docker Hub guardadas en la máquina están vencidas, `export DOCKER_CONFIG=$(mktemp -d)` permite descargar las imágenes en modo anónimo.
~~~~

por

~~~~text
Si las credenciales de Docker Hub guardadas en la máquina están vencidas, un `DOCKER_CONFIG` temporal descarga en modo anónimo, con los *plugins* enlazados para que `buildx` no cambie de versión (con uno vacío, el v0.35.0 del usuario cae al 0.13.1 del sistema **[observado]**, §8.5): `D=$(mktemp -d); ln -s ~/.docker/cli-plugins "$D/"; export DOCKER_CONFIG=$D`.
~~~~

9. Reemplazar

~~~~text
Docker Desktop con contenedores Linux, corriendo los mismos `docker run` desde Git Bash o desde una terminal de WSL 2 con el clon en el sistema de archivos de WSL [B130][B132];
~~~~

por

~~~~text
Docker Desktop con contenedores Linux, corriendo los mismos `docker run` desde una terminal de WSL 2 con el clon en el sistema de archivos de WSL [B130][B132], o desde Git Bash con `MSYS_NO_PATHCONV=1` delante, porque convierte en ruta de Windows argumentos como `-w /w` [B209];
~~~~

10. Reemplazar la línea que empieza con «Quedan fuera: el despliegue y la operación en producción» (hoy:)

~~~~text
Quedan fuera: el despliegue y la operación en producción (la guía termina en el artefacto construido y su procedencia; el procedimiento de verificar antes de instalar corresponde a la [guía de Despliegue](../Despliegue/) de esta misma colección), otros ecosistemas (Java, Go, Rust), las comparativas comerciales de productos de CI y la recomendación de una herramienta única «para todo». Tampoco compara los enfoques que reemplazan el entorno completo: sistemas de build herméticos que gestionan las herramientas como fuente (la definición de §3.1 se toma de uno de ellos, Bazel [B04]) o gestores declarativos del entorno de todo el sistema. **[criterio]** La guía parte de un repositorio que se edita con Visual Studio en Windows y se construye con las CLI nativas de cada ecosistema, y adopta un enfoque que conserva esas herramientas: archivos nativos de cada ecosistema, una compuerta y una imagen por digest. Quien evalúe un enfoque de entorno completo necesita otra comparación, con su propia evidencia; ésta no la hizo.
~~~~

por

~~~~text
Quedan fuera: el despliegue y la operación en producción (la guía termina en el artefacto y su procedencia; verificar antes de instalar es tema de la [guía de Despliegue](../Despliegue/)), otros ecosistemas (Java, Go, Rust), las comparativas comerciales de productos de CI, la herramienta única «para todo» y los enfoques que reemplazan el entorno completo: sistemas de build herméticos que gestionan las herramientas como fuente (Bazel, de donde sale la definición de §3.1 [B04]) o gestores declarativos de todo el sistema. **[criterio]** La guía parte de un repositorio que se edita con Visual Studio en Windows y se construye con las CLI de cada ecosistema, y conserva esas herramientas: archivos nativos, una compuerta y, donde hace falta, una imagen por digest; comparar un enfoque de entorno completo pide otra evidencia, que ésta no reunió.
~~~~


### P-03 · §1.2 Extracto literal de E1-01

- **Hallazgos**: C2-27, C2-37.
- **Sección**: §1.2 L141–L158.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras**: prosa -28, evidencia y plantillas -7.
- **Verificación**: Cada línea del bloque `text` de §1.2, salvo `...`, aparece tal cual en `Examples/N1-codificacion-y-finales-de-linea/salidas/e1-roslyn-sdk8.txt` (`grep -Fxf`); `grep -c '^\$ docker run --rm -v' GUIA` → 0.

1. Reemplazar el rango que va desde «```text⏎$ docker run --rm -v "$PWD":/w -w /w mcr.microsoft.com/dotnet/sdk:8.0 sh e1-roslyn.sh» (incluido; ⏎ = salto de línea) hasta justo antes de «*Extracto de E1-01» por:

~~~~text
```text
== cp1252-lf | sólo literal
  build OK
  Texto  : Atenci�n: se�al recibida en �andubay
...
  U+     : FFFD 006E 003A
...
== cp1252-lf | con identificador no ASCII
  Alarma.cs(4,23): error CS1056: Unexpected character '�' [/w/work/dotnet/cp1252-lf/App.csproj]
...
== utf8-lf | con identificador no ASCII
  build OK
  Texto  : Atención: señal recibida en Ñandubay
...
  U+     : 00F3 006E 003A
...
== cp1252-lf | el mismo programa con una consola no UTF-8 (LC_ALL=es_AR.ISO-8859-1): U+FFFD se ve como '?'
  Texto  : Atenci?n: se?al recibida en ?andubay
```

~~~~

2. Reemplazar la línea que empieza con «Esas líneas contienen todo el caso.» (hoy:)

~~~~text
Esas líneas contienen todo el caso. El compilador no «lee cp1252 como UTF-8» a secas: intenta UTF-8, falla, y vuelve a leer con la **página de códigos ANSI del sistema**, que en un Windows en español es 1252 y en Linux es UTF-8 tolerante [B14][B19]. En Linux cada byte inválido se vuelve el carácter de reemplazo U+FFFD (`�`). Un identificador no puede contener U+FFFD —no es una letra— y la compilación falla; un literal sí, y la corrupción pasa sin aviso hasta que alguien la ve en pantalla. El `?` que vio el equipo es, probablemente, ese mismo U+FFFD pasado por una salida que no es UTF-8 (la última línea lo muestra; es una interpretación compatible con el caso, no una observación del sistema original). El [§4](#4-codificación-y-finales-de-línea) explica el mecanismo en detalle.
~~~~

por

~~~~text
Esas líneas contienen todo el caso. El compilador no «lee cp1252 como UTF-8» a secas: intenta UTF-8, falla y vuelve a leer con la **página de códigos ANSI del sistema**, 1252 en un Windows en español y UTF-8 tolerante en Linux [B14][B19], donde cada byte inválido se vuelve el carácter de reemplazo U+FFFD (`�`). Un identificador no puede contener U+FFFD —no es una letra— y la compilación falla; un literal sí, y la corrupción pasa sin aviso hasta que alguien la ve. El `?` que vio el equipo es, probablemente, ese U+FFFD pasado por una salida que no es UTF-8, como en la última línea (interpretación compatible con el caso, no observada en el sistema original). El [§4](#4-codificación-y-finales-de-línea) explica el mecanismo.
~~~~

3. Reemplazar la línea que empieza con «Linux no «rompió» el código: lo hizo visible.» (hoy:)

~~~~text
Linux no «rompió» el código: lo hizo visible. Un contenedor, que fija el sistema operativo, hace lo mismo y además lo vuelve **reproducible** —todos ven el mismo error—, pero no lo arregla: el archivo en cp1252 falla igual adentro (E5-1). El arreglo está en los bytes del archivo, no en la máquina.
~~~~

por

~~~~text
Linux no «rompió» el código: lo hizo visible. Un contenedor, que fija el sistema operativo, además lo vuelve **reproducible** —todos ven el mismo error—, pero no lo arregla: el cp1252 falla igual adentro (E5-1). El arreglo está en los bytes del archivo.
~~~~

4. Reemplazar la línea que empieza con «Un equipo mantiene un sistema .NET heredado de una organización.» (hoy:)

~~~~text
Un equipo mantiene un sistema .NET heredado de una organización. Lo desarrolla con Visual Studio en Windows y, a la vez, lo compila en Linux y en contenedores de desarrollo (devcontainers) Linux. Unos cien archivos `.cs` y `.razor` estaban guardados en Windows-1252 (cp1252). En Windows compilaban y se veían bien. En Linux, un proyecto de servicios no compilaba: un identificador que empezaba con una letra acentuada mayúscula producía un error del compilador; y en los proyectos que sí compilaban, los textos con acentos aparecían con `?`. La corrección fue convertir los cien archivos a UTF-8 con BOM. En Windows eso no cambió nada visible.
~~~~

por

~~~~text
Un equipo mantiene un sistema .NET heredado de una organización: lo desarrolla con Visual Studio en Windows y lo compila también en Linux y en contenedores de desarrollo (devcontainers) Linux. Unos cien archivos `.cs` y `.razor` estaban guardados en Windows-1252 (cp1252). En Windows compilaban y se veían bien. En Linux, un proyecto de servicios no compilaba —un identificador que empezaba con una mayúscula acentuada daba un error del compilador— y, en los que compilaban, los acentos aparecían como `?`. La corrección fue convertir los cien archivos a UTF-8 con BOM, que en Windows no cambió nada visible.
~~~~


### P-04 · §2.4 Matriz de actores y rótulo de ESC-01

- **Hallazgos**: C2-22, C2-52.
- **Sección**: §2.4 L233, L247–L252; filas ESC-01 de §4.4–§11.4.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras**: prosa +24, evidencia y plantillas +0.
- **Verificación**: `grep -c 'Windows + VS |'` → 0; `grep -c 'Windows+VS'` → 0; la celda «Aplica» de ACT-ARQ cita pasos que existen en §12.

1. Reemplazar

~~~~text
| Capítulo | ESC-01 Windows+VS |
~~~~

por

~~~~text
| Capítulo | ESC-01 Windows + Visual Studio |
~~~~

2. Reemplazar **todas** las apariciones de

~~~~text
| ESC-01 Windows + VS |
~~~~

por

~~~~text
| ESC-01 Windows + Visual Studio |
~~~~

3. Reemplazar

~~~~text
| ACT-ARQ | §3, §5, §6, §7, §11 | — | coherencia entre capítulos |
| ACT-OPS | §8, §9, §10 | — | compuertas y procedencia |
| ACT-REV | — | §10 (lista del revisor) | diffs de §5, §6, §7, §8 |
~~~~

por

~~~~text
| ACT-ARQ | §3, §5, §6, §7, §11 | §12, pasos 1–3, 5–7, 9 y 10 | coherencia entre capítulos |
| ACT-OPS | §8, §9, §10 | — | compuertas y procedencia |
| ACT-REV | — | §10 (lista del revisor) | diffs de §5, §6, §7, §8 |

ACT-ARQ decide además la imagen (§8) y el alcance de SBOM y procedencia (§9), que implementa ACT-OPS (§11.4).
~~~~

4. Reemplazar la línea que empieza con «La procedencia (§9) se **produce** sólo en la CI» (hoy:)

~~~~text
La procedencia (§9) se **produce** sólo en la CI por una decisión de esta guía **[criterio]**: la que vale es la del artefacto que se publica, y ese sale de la CI. En las estaciones y el devcontainer, §9 sirve para diagnosticar (metadatos embebidos) y para reconstruir un artefacto publicado y comparar hashes; una build local no demuestra nada ante un tercero.
~~~~

por

~~~~text
La procedencia (§9) se **produce** sólo en la CI **[criterio]**: vale la del artefacto que se publica, que sale de ahí. En las estaciones y el devcontainer, §9 sirve para diagnosticar (metadatos embebidos) y para reconstruir un artefacto publicado y comparar hashes; una build local no demuestra nada ante un tercero.
~~~~


### P-05 · §3 Instrucción de lectura y §3.7

- **Hallazgos**: C2-37, C2-38.
- **Sección**: §3 L258; §3.7 L419, L428.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras**: prosa -115, evidencia y plantillas +0.
- **Verificación**: `grep -c 'En el Recorrido, leé ahora'` → 0; §3.7 P2 no contiene `NU1603` ni `requested`; 67 de 67 preguntas siguen con *Aplica*.

1. Reemplazar

~~~~text
 En el Recorrido, leé ahora §3.1, §3.2, §3.4 y §3.7; las tablas de §3.3, §3.5 y §3.6 usan mecanismos que se explican recién en §6 a §10 y son de consulta.
~~~~

por

~~~~text

~~~~

2. Reemplazar

~~~~text
No. Fijar es elegir una versión para una entrada; congelar es guardar el resultado completo de una resolución, transitivas incluidas. En NuGet conviven: CPM fija las directas en un lugar y `packages.lock.json` congela el grafo (E4-2: CPM pidió 8.0.2, que no existe, y NuGet resolvió 9.0.0; sin lock lo avisa con `NU1603`, y con lock el aviso desaparece y el lock registra `requested [8.0.2, )` con `resolved 9.0.0`, §7.2.1).
~~~~

por

~~~~text
No. Fijar es elegir una versión para una entrada; congelar es guardar el resultado completo de una resolución, transitivas incluidas. No se reemplazan: lo fijado puede no existir, y el lock registra lo que se resolvió en su lugar (§7.2.1).
~~~~

3. Reemplazar

~~~~text
rango en el manifiesto y lock con modo estricto en la CI; para .NET sin lock, la política de §6.4.
~~~~

por

~~~~text
rango en el manifiesto y lock con modo estricto en la CI; para .NET, lo que se decide en §6.4.
~~~~

4. Reemplazar la línea que empieza con «Las tres palabras describen objetos distintos» (hoy:)

~~~~text
Las tres palabras describen objetos distintos y no se implican en el orden que suele suponerse. E0-5 muestra la distancia entre las dos primeras: con el mismo SDK y el mismo directorio, dos compilaciones del mismo proyecto dieron el mismo hash, incluso en dos contenedores distintos; con el mismo SDK y **otro directorio**, el hash cambió, porque la DLL guarda la ruta del `.pdb`. El compilador era determinista y la build no era reproducible entre máquinas. Recién con `ContinuousIntegrationBuild=true` dentro de un repo git la ruta quedó normalizada (`/_/obj/…`) y los hashes coincidieron.
~~~~

por

~~~~text
Las tres palabras describen objetos distintos y no se implican como suele suponerse. E0-5 muestra la distancia entre las dos primeras: con el mismo SDK y el mismo directorio, dos compilaciones dieron el mismo hash, aun en dos contenedores; con **otro directorio**, cambió, porque la DLL guarda la ruta del `.pdb`: compilador determinista, build no reproducible entre máquinas. Recién con `ContinuousIntegrationBuild=true` en un repo git la ruta quedó normalizada (`/_/obj/…`) y los hashes coincidieron.
~~~~

5. Reemplazar la línea que empieza con «Las seis, de dos formas.» (hoy:)

~~~~text
Las seis, de dos formas. Las capas 1 a 4 se registran sobre todo **por referencia**: el commit identifica los archivos que las declaran (`.gitattributes`, `global.json`, locks, `FROM` con digest), siempre que existan y que el árbol esté limpio. Lo que el repo no declara —el SDK efectivamente usado, el digest real de la imagen, la ruta, las variables— hay que **grabarlo** en el momento de la build, porque después no se puede reconstruir [B02]. Si el destinatario es un tercero, además hay que firmarlo (§9). *Aplica* a todo artefacto que salga de la CI; para builds locales alcanza con que el repo declare.
~~~~

por

~~~~text
Las seis, de dos formas. Las capas 1 a 4 se registran sobre todo **por referencia**: el commit identifica los archivos que las declaran (`.gitattributes`, `global.json`, locks, `FROM` con digest), si existen y el árbol está limpio. Lo que el repo no declara —el SDK usado, el digest real de la imagen, la ruta, las variables— se **graba** durante la build, porque después no se puede reconstruir [B02] (A.17); ante un tercero, además, se firma (§9). *Aplica* a todo artefacto que salga de la CI; para builds locales alcanza con que el repo declare.
~~~~

6. Reemplazar la línea que empieza con «Porque el commit fija los archivos que el repo versiona y nada más.» (hoy:)

~~~~text
Porque el commit fija los archivos que el repo versiona y nada más. Lo que no está declarado lo aporta la máquina. El diagnóstico práctico es comparar registros por capa (E0-6 lo hace con un `diff` de dos manifiestos) y buscar la **primera capa, de abajo hacia arriba**, donde difieren: es inútil comparar locks si los bytes del fuente ya son distintos. *Aplica* al primer diagnóstico de todo «en mi máquina anda»: entre dos estaciones, entre la estación y la CI o entre dos corridas de la CI.
~~~~

por

~~~~text
Porque el commit fija sólo lo que el repo versiona; lo demás lo aporta la máquina. El diagnóstico es comparar registros por capa (E0-6, con un `diff` de dos manifiestos de capas) y buscar la **primera capa, de abajo hacia arriba**, donde difieren: si los bytes del fuente ya difieren, comparar locks es inútil. *Aplica* al primer diagnóstico de todo «en mi máquina anda»: entre dos estaciones, entre la estación y la CI o entre dos corridas de la CI.
~~~~

7. Reemplazar la línea que empieza con «La flecha punteada es la única excepción al apilamiento:» (hoy:)

~~~~text
La flecha punteada es la única excepción al apilamiento: una imagen de contenedor suele **traer** el toolchain, de modo que la capa 4 termina aportando el valor de la capa 2. Eso no convierte a la imagen en la fuente de verdad del toolchain: si el repo no lo declara, lo decide quien eligió la imagen, y dos imágenes oficiales dan dos compiladores distintos (E0-2).
~~~~

por

~~~~text
La flecha punteada es la única excepción al apilamiento: la imagen suele **traer** el toolchain, y la capa 4 aporta el valor de la capa 2. No por eso es su fuente de verdad: si el repo no lo declara, lo decide quien eligió la imagen, y dos imágenes oficiales dan dos compiladores distintos (E0-2).
~~~~

8. Reemplazar la línea que empieza con «La pregunta del caso se contesta leyendo esta tabla por filas:» (hoy:)

~~~~text
La pregunta del caso se contesta leyendo esta tabla por filas: ningún mecanismo fija más de una o dos capas, y casi todos dejan libre algo que el usuario cree cubierto. La regla para usarla es leer la columna «Qué deja libre» antes que «Qué fija».
~~~~

por

~~~~text
La pregunta del caso se contesta por filas: ningún mecanismo fija más de una o dos capas y casi todos dejan libre algo que se cree cubierto; por eso se lee «Qué deja libre» antes que «Qué fija».
~~~~


### P-06 · §4 Codificación: snippet de Roslyn, `CS2016`, lecturas de §4.2.4 y Python 3.15

- **Hallazgos**: C2-49, C2-58, C2-31, C2-29, C2-37.
- **Sección**: §4.2.1 L459; §4.2.3 L492; §4.2.4 L506, L516; §4.3 L542.
- **Capa de origen**: guía + N1 (P-22). **Costo**: bajo. **Reversible**: sí. **Δ palabras**: prosa -74, evidencia y plantillas -2.
- **Verificación**: `grep -c 'rama main al'` → 0; `grep -c 'Sólo Python falla siempre'` → 0; `grep -c 'prevista para el 2026-10-09'` → 0; `grep -c 'E1-03). En E1-03'` → 0; [B205] definida y citada.

1. Reemplazar

~~~~text
// Roslyn, EncodedStringText.cs (rama main al 2026-10-07 [B14]), recortado y comentado.
~~~~

por

~~~~text
// Roslyn, EncodedStringText.cs (commit 9c298328ef91 [B14]), recortado y comentado.
~~~~

2. Reemplazar

~~~~text
Segunda trampa: con SDK 8.0.425 la build con `CodePage=1252` falla con `CS2016: Code page '1252' is invalid or not installed` según el estado del servidor de compilación, y con SDK 10.0.400 compila (E1-03). En E1-03 la falla aparece con el servidor de compilación (`VBCSCompiler`) recién arrancado, desaparece si el servidor ya compiló antes un archivo con *fallback*, y no aparece con `-p:UseSharedCompilation=false`, que compila sin servidor; el mismo
~~~~

por

~~~~text
Segunda trampa: con SDK 8.0.425, `CodePage=1252` falla con `CS2016: Code page '1252' is invalid or not installed` cuando el servidor de compilación (`VBCSCompiler`) recién arrancó, y no falla si ya compiló un archivo con *fallback* ni con `-p:UseSharedCompilation=false`, que compila sin servidor; con SDK 10.0.400 compila (E1-03). El mismo
~~~~

3. Reemplazar

~~~~text
| Python `open()` sin `encoding=` | según *locale* | según *locale* |
~~~~

por

~~~~text
| Python `open()` sin `encoding=` | ≤ 3.14: según *locale*; ≥ 3.15: UTF-8 [B29] | ≤ 3.14: según *locale*; ≥ 3.15: se lee como UTF-8 [B29] |
~~~~

4. Reemplazar

~~~~text
- **Sólo Python falla siempre ante cp1252.** Roslyn, Razor y Node fallan sólo si el carácter cae en un identificador (`CS1056`, `RZ1005`, `SyntaxError`); en literales y en HTML corrompen sin error (E1-01, E1-04, E1-05).
~~~~

por

~~~~text
- **Sólo Python rechaza el fuente en cp1252 en toda plataforma**, aun con el byte en un comentario [B33], salvo un cp1252 cuyos bytes forman UTF-8 válido, que se lee con otro texto. Roslyn, Razor y Node, en Linux y macOS, fallan sólo con el carácter en un identificador (`CS1056`, `RZ1005`, `SyntaxError`) y corrompen sin error literales y HTML (E1-01, E1-04, E1-05); en Windows con ACP 1252, Roslyn lo lee bien (§4.2.1).
~~~~

5. Reemplazar

~~~~text
PEP 686 (*Final*) activa el modo UTF-8 por defecto desde Python 3.15 [B29], cuya versión final está prevista para el 2026-10-09 [B32]: al 2026-10-07 ninguna versión estable lo tiene activo.
~~~~

por

~~~~text
PEP 686 (*Final*) activa el modo UTF-8 por defecto desde Python 3.15 [B29], publicada el 2026-10-09 [B205] según el calendario de [B32]; en 3.14 y anteriores, como el 3.12 del laboratorio, `open()` sigue dependiendo del *locale*.
~~~~

6. Reemplazar la línea que empieza con «El compilador lee cada fuente con `EncodedStringText.Create`.» (hoy:)

~~~~text
El compilador lee cada fuente con `EncodedStringText.Create`. Si el proyecto **no** indica página de códigos, intenta UTF-8 en modo estricto; si falla, decodifica con un *fallback* que el código define como «la página ANSI por defecto; si no, 1252; si no, Latin-1». Si el archivo empieza con BOM, el BOM manda y nada de lo anterior se aplica [B14]. En Linux, `GetEncoding(0)` devuelve UTF-8 [B19] (E1-02), así que el segundo intento vuelve a ser UTF-8, ahora tolerante, y cada byte de cp1252 se convierte en U+FFFD. En abril de 2026 el equipo del compilador corrigió una regresión que había hecho que `GetEncoding(0)` devolviera UTF-8 en .NET aunque el sistema tuviera otra página ANSI; la prueba que agregó afirma que en Windows el *fallback* es la página ANSI real «aun cuando la opción de configuración regional UTF-8 está activada», y que en Linux y macOS, donde no hay página ANSI, es UTF-8 [B15].
~~~~

por

~~~~text
El compilador lee cada fuente con `EncodedStringText.Create`: si el archivo empieza con BOM, el BOM manda; si no, y el proyecto **no** indica página de códigos, intenta UTF-8 estricto y, si falla, decodifica con un *fallback* que el código define como «la página ANSI por defecto; si no, 1252; si no, Latin-1» [B14]. En Linux, `GetEncoding(0)` devuelve UTF-8 [B19] (E1-02): el segundo intento vuelve a ser UTF-8, ahora tolerante, y cada byte de cp1252 se convierte en U+FFFD. La prueba con que el equipo del compilador corrigió en abril de 2026 una regresión de ese *fallback* afirma que en Windows es la página ANSI real «aun cuando la opción de configuración regional UTF-8 está activada», y en Linux y macOS, donde no hay página ANSI, UTF-8 [B15].
~~~~

7. Reemplazar la línea que empieza con «Experimentos del capítulo: E1-01 (» (hoy:)

~~~~text
Experimentos del capítulo: E1-01 (Roslyn con cp1252, UTF-8, BOM, CRLF y `CodePage`), E1-02 (`GetEncoding(0)` en Linux), E1-03 (`CS2016` según SDK), E1-04 (Razor), E1-05 (Node), E1-06/07 (Python y *locale*), E1-08 (git), E1-09 (diagnóstico), E1-10 (plantillas del SDK), E1-11 (shebang), E1-12 (categorías Unicode), E1-13 (`file`).
~~~~

por

~~~~text
Experimentos del capítulo: E1-01 a E1-13 (Anexo E).
~~~~

8. Reemplazar la línea que empieza con «El BOM en un script merece un párrafo aparte,» (hoy:)

~~~~text
El BOM en un script merece un párrafo aparte, porque su daño es silencioso. El kernel sólo reconoce un script si empieza con `#!` [B173]; con el BOM delante, `execve` devuelve `ENOEXEC`. Si el script lo lanzó un shell (bash, dash) o una función de la familia `execvp` (como hace el `child_process` de Node), se reintenta con `/bin/sh`: la primera línea falla, el resto corre **con ese shell** aunque el shebang pidiera otro intérprete, y el código de salida es 0. Si lo lanzó un programa que llama a `execve` directo, como `subprocess.run` de Python, falla con `Exec format error` (E1-11, E8-1). El mismo archivo «anda» o no según el orquestador.
~~~~

por

~~~~text
El BOM en un script daña en silencio. El kernel sólo reconoce un script si empieza con `#!` [B173]; con el BOM delante, `execve` devuelve `ENOEXEC`. Si lo lanzó un shell (bash, dash) o una función de la familia `execvp` (como el `child_process` de Node), se reintenta con `/bin/sh`: la primera línea falla, el resto corre **con ese shell** aunque el shebang pidiera otro intérprete, y sale con 0. Si lo lanzó un programa que llama a `execve` directo, como `subprocess.run` de Python, falla con `Exec format error` (E1-11, E8-1). El mismo archivo «anda» o no según el orquestador.
~~~~

9. Reemplazar la línea que empieza con «En casi todo el código CRLF y LF son equivalentes:» (hoy:)

~~~~text
En casi todo el código CRLF y LF son equivalentes: el diff cambia y el programa no. JavaScript y Python normalizan su fuente (ECMA-262 en los template literals [B24]; Python para todo el fuente [B28]). C# **no**: los literales verbatim y crudos incluyen los saltos de línea del archivo, y la especificación advierte que una herramienta que traduzca `\n` ↔ `\r\n` «cambia el comportamiento de la aplicación» [B21]. Un `@"a⏎b"` compila a `61-0A-62` con LF y a `61-0D-0A-62` con CRLF (E2-1): con `core.autocrlf=true` en Windows y LF en Linux, **el mismo commit produce dos binarios distintos**. Las otras dos excepciones son los scripts de shell (un CR tras el shebang impide ejecutarlos) y los datos leídos sin traducción (`fs.readFileSync`, Python con `newline=""`).
~~~~

por

~~~~text
En casi todo el código CRLF y LF son equivalentes: cambia el diff, no el programa. JavaScript y Python normalizan su fuente (ECMA-262 en los template literals [B24]; Python, todo el fuente [B28]). C# **no**: los literales verbatim y crudos incluyen los saltos de línea del archivo, y la especificación advierte que traducir `\n` ↔ `\r\n` «cambia el comportamiento de la aplicación» [B21]. Un `@"a⏎b"` compila a `61-0A-62` con LF y a `61-0D-0A-62` con CRLF (E2-1): con `core.autocrlf=true` en Windows y LF en Linux, **el mismo commit produce dos binarios distintos**. Las otras excepciones son los scripts de shell (un CR tras el shebang impide ejecutarlos) y los datos leídos sin traducción (`fs.readFileSync`, Python con `newline=""`).
~~~~

10. Reemplazar la línea que empieza con «La especificación de C# admite en un identificador» (hoy:)

~~~~text
La especificación de C# admite en un identificador cualquier letra Unicode (`\p{L}`, `\p{Nl}`) [B21]. `Ç` es una letra mayúscula (categoría `Lu`); U+FFFD es un símbolo (`So`) (E1-12). Después de la decodificación tolerante el compilador ve U+FFFD, no puede formar un token y emite `CS1056`. Dentro de un literal cualquier carácter es válido: U+FFFD entra al string y la compilación termina bien. **Un build verde en Linux no prueba que la codificación esté bien; prueba que no hay identificadores no ASCII** **[criterio]**. Si el código heredado del caso no hubiera tenido un identificador acentuado, los textos corruptos habrían llegado a producción.
~~~~

por

~~~~text
La especificación de C# admite en un identificador cualquier letra Unicode (`\p{L}`, `\p{Nl}`) [B21]. `Ç` es una letra mayúscula (`Lu`); U+FFFD, un símbolo (`So`) (E1-12). Tras la decodificación tolerante el compilador ve U+FFFD, no puede formar un token y emite `CS1056`; en un literal cualquier carácter vale, y la compilación termina bien. **Un build verde en Linux no prueba que la codificación esté bien; prueba que no hay identificadores no ASCII** **[criterio]**: sin un identificador acentuado, los textos corruptos del caso habrían llegado a producción.
~~~~

11. Reemplazar la línea que empieza con «**[interpretación]** El ciclo típico de un commit de BOM» (hoy:)

~~~~text
**[interpretación]** El ciclo típico de un commit de BOM en un equipo mixto: una plantilla crea el archivo con BOM, alguien lo edita en VS Code (que conserva el BOM), y el BOM aparece o desaparece cuando una herramienta **reescribe el archivo entero** con su propio default: una conversión masiva, un formateador, un generador, un hook genérico. La política (§5) tiene que declarar la codificación en un lugar que todos esos programas lean, y una compuerta tiene que verificarla.
~~~~

por

~~~~text
**[interpretación]** El ciclo típico de un commit de BOM en un equipo mixto: una plantilla crea el archivo con BOM, alguien lo edita en VS Code, que lo conserva, y el BOM aparece o desaparece cuando una herramienta **reescribe el archivo entero** con su default: una conversión masiva, un formateador, un generador, un hook genérico. La política (§5) declara la codificación donde todos esos programas la lean, y una compuerta la verifica.
~~~~

12. Reemplazar la línea que empieza con «`file` ayuda, pero es heurístico.» (hoy:)

~~~~text
`file` ayuda, pero es heurístico. En E1-13, con `file` 5.46, un cp1252 sin bytes `80–9F` salió como «ISO-8859 text» y uno con esos bytes como «Non-ISO extended-ASCII text»; y un cp1252 cuyos bytes no ASCII forman por casualidad UTF-8 válido —texto que ya tenía mojibake— sale como UTF-8 (E1-13). No es un detector de cp1252. Un editor que «muestra bien» el archivo no es diagnóstico: ya adivinó.
~~~~

por

~~~~text
`file` ayuda, pero es heurístico: en E1-13, con `file` 5.46, un cp1252 sin bytes `80–9F` salió como «ISO-8859 text», uno con esos bytes como «Non-ISO extended-ASCII text», y uno cuyos bytes no ASCII forman por casualidad UTF-8 válido —texto que ya tenía mojibake—, como UTF-8. No detecta cp1252. Y un editor que «muestra bien» el archivo ya adivinó: no es diagnóstico.
~~~~

13. Reemplazar la línea que empieza con «Para Roslyn es decisivo: con BOM se lee UTF-8» (hoy:)

~~~~text
Para Roslyn es decisivo: con BOM se lee UTF-8 en cualquier plataforma y con cualquier `CodePage`. Para Node es inocuo en módulos y dañino en datos (`fs` lo conserva, `JSON.parse` falla). Para Python es inocuo en el fuente y visible en datos si no se abre con `utf-8-sig`. Para git es un cambio invisible en la línea 1. Para un script es peor que fatal: puede correr con otro intérprete y salir con 0. *Criterio*: el BOM se decide **por extensión y por lector**, nunca globalmente.
~~~~

por

~~~~text
Para Roslyn es decisivo: con BOM se lee UTF-8 en cualquier plataforma y con cualquier `CodePage`. Para Node, inocuo en módulos y dañino en datos (`fs` lo conserva, `JSON.parse` falla); para Python, inocuo en el fuente y visible en datos sin `utf-8-sig`; para git, un cambio invisible en la línea 1; para un script, peor que fatal: puede correr con otro intérprete y salir con 0. *Criterio*: el BOM se decide **por extensión y por lector**, nunca globalmente.
~~~~


### P-07 · §5 Política de texto: variante B, compuerta de texto, scripts desde Windows, Práctica y señales

- **Hallazgos**: C2-12, C2-05, C2-08, C2-50, C2-37.
- **Sección**: §5.2.3 L715; §5.2.5 L742; §5.2.6 recuadro L810; §5.5 L862; §5.6 L890; §5.7 L923; §5.9 P2 L932.
- **Capa de origen**: guía + N2 (P-22). **Costo**: medio. **Reversible**: sí. **Δ palabras**: prosa -26, evidencia y plantillas +0.
- **Verificación**: EA-1 paso 1c (nuevo, P-23 L3) da 0 violaciones con la variante B sobre la solución que crea el SDK convertida con BOM (evidencia-auditor/x5-variante-b/salida.txt: A tal cual 4; B ampliada 2 sin BOM en `Directory.Build.*`, 0 con BOM); `grep -c '^- ' ` en §5.7 tras «Señales» → 6; la respuesta de §5.9.2 coincide con el bloque B de A.1.

1. Reemplazar

~~~~text
- **Heredado ya convertido a UTF-8 con BOM**, como el del caso: `utf-8-bom` para `*.cs` (variante B).
~~~~

por

~~~~text
- **Heredado ya convertido a UTF-8 con BOM**, como el del caso: `utf-8-bom` para `*.cs` y los archivos de proyecto (variante B).
~~~~

2. Reemplazar

~~~~text
**[criterio]** La guía mantiene su verificador porque mira el **índice** —lo que se commitea— y da el diagnóstico «¿cp1252?». Necesita `python3` y el paquete `EditorConfig==0.17.1` en cada lugar donde corre (A.11). Un equipo que prefiera no mantener un script puede armar el paso de texto con editorconfig-checker sobre un clon limpio en la CI y `dotnet format whitespace --verify-no-changes` para los `.cs`, con la misma regla de una sola compuerta en hook y CI (§10.2.2).
~~~~

por

~~~~text
**[criterio]** La guía mantiene su verificador porque mira el **índice** —lo que se commitea— y da el diagnóstico «¿cp1252?». Necesita `python3` y el paquete `EditorConfig==0.17.1` donde corre, y la compuerta dice cuál falta (A.11). Sin Python, el paso de texto de la **misma** compuerta puede ser editorconfig-checker, fijado por versión, más `dotnet format whitespace --verify-no-changes` para los `.cs`, con los límites de la tabla; la regla de una sola compuerta en hook y CI no cambia (§10.2.2).
~~~~

3. Reemplazar

~~~~text
Desde Windows: esa imagen con Docker Desktop montando el clon, o Git Bash con Python, el paquete y un `iconv` disponible **[no verificado]** (requiere Windows).
~~~~

por

~~~~text
Desde Windows: esa imagen con Docker Desktop montando el clon, o Git Bash con Python, el paquete y un `iconv` disponible **[no verificado]** (requiere Windows). Un `.sh` agregado desde Windows entra sin bit de ejecución: `git update-index --chmod=+x` antes del commit (§8.2.5).
~~~~

4. Reemplazar

~~~~text
[*.{razor,cshtml,sln}]
charset = utf-8-bom
```

```gitattributes
# .gitattributes — lo lee git;
~~~~

por

~~~~text
[*.{razor,cshtml,sln}]
charset = utf-8-bom

# Heredado ya convertido con BOM, como el del caso: variante B de A.1,
# [*.{cs,csproj,props,targets}] con charset = utf-8-bom.
```

```gitattributes
# .gitattributes — lo lee git;
~~~~

5. Reemplazar

~~~~text
heredado ya convertido con BOM, como el del caso → `utf-8-bom` para `*.cs` y no tocar más.
~~~~

por

~~~~text
heredado ya convertido con BOM, como el del caso → `utf-8-bom` para `*.cs` y los archivos de proyecto, y no tocar más.
~~~~

6. Reemplazar

~~~~text
Señales de una versión pobre: la política vive en una wiki o en `core.autocrlf`; `* text=auto` sin renormalizar; `*.{cmd,bat}` en `.gitattributes`; un hook genérico que quita todos los BOM; la conversión mezclada con cambios funcionales; un `.git-blame-ignore-revs` con un SHA que no está en `main`; política, migración e ignore-revs aplastados en un solo *squash*; comentarios al final de una línea del `.editorconfig`; el `.editorconfig` de `dotnet new` (SDK 8) commiteado sin revisar su `end_of_line = crlf`.
~~~~

por

~~~~text
Señales de una versión pobre:

- la política vive en una wiki o en `core.autocrlf` (§5.2.1);
- `* text=auto` sin renormalizar, o `*.{cmd,bat}` en `.gitattributes` (§5.2.4);
- un hook genérico que quita todos los BOM (§5.2.5);
- la conversión mezclada con cambios funcionales, un `.git-blame-ignore-revs` con un SHA que no está en `main`, o política, migración e ignore-revs en un solo *squash* (§5.2.6);
- comentarios al final de una línea del `.editorconfig` (§5.2.4);
- el `.editorconfig` de `dotnet new` (SDK 8) commiteado sin revisar su `end_of_line = crlf` (§5.3).
~~~~

7. Reemplazar

~~~~text
Con la tabla de §5.2.3, escribí la política de un repo con `.sh`, `appsettings.json`, `.razor` y `.cs` heredados ya convertidos con BOM. Compará con A.1, variante B. *Respuesta esperada*: `[*]` sin BOM y LF; `.razor` y `.cs` con `utf-8-bom`;
~~~~

por

~~~~text
Con la tabla de §5.2.3, escribí la política de un repo con `.sh`, `appsettings.json`, `.razor`, `.cs` y `.csproj` heredados ya convertidos con BOM. Compará con A.1, variante B. *Respuesta esperada*: `[*]` sin BOM y LF; `.razor`, `.cs`, `.csproj`, `.props` y `.targets` con `utf-8-bom`;
~~~~

8. Reemplazar la línea que empieza con «Experimentos del capítulo: E2-1 (» (hoy:)

~~~~text
Experimentos del capítulo: E2-1 (precedencia de `.gitattributes`, `core.autocrlf` y `.editorconfig`; EOL que entra en el binario), E2-2 (migración en tres commits, verificación mecánica, `blame`), E2-3 (compuerta en PR y hook; `--no-verify`), E2-4 (`working-tree-encoding`), E2-5 (BOM frente a cada lector), E2-6 (plantillas del SDK 8 y 10; `dotnet format`), E5-7 (llaves en `.gitattributes`), EA-1.
~~~~

por

~~~~text
Experimentos del capítulo: E2-1 a E2-8, E5-7 y EA-1 (Anexo E).
~~~~

9. Reemplazar la línea que empieza con «**[criterio]** Las dos dejan el índice en LF,» (hoy:)

~~~~text
**[criterio]** Las dos dejan el índice en LF, así que ninguna produce commits de EOL (E2-1); lo que cambia es el disco de Windows. La segunda conviene cuando el equipo tiene literales multilínea de C# o datos leídos sin traducción cuyo contenido importa en las pruebas: con CRLF en la estación y LF en la CI, **la misma prueba da distinto** en las dos (§4.2.5). Si no los tiene, la primera es igual de válida, y es la que usan los repositorios del fabricante relevados. En las dos, las excepciones las exige el consumidor del archivo: `*.cmd` y `*.bat` con CRLF para `cmd.exe`, `*.sh` con LF obligatorio. Visual Studio declara soportar `end_of_line` [B45], así que trabajar con LF en Windows no debería requerir configuración local **[no verificado]** (requiere Windows). Las plantillas de esta guía (A.2) usan la segunda.
~~~~

por

~~~~text
**[criterio]** Las dos dejan el índice en LF y ninguna produce commits de EOL (E2-1); cambia el disco de Windows. La segunda conviene si hay literales multilínea de C# o datos leídos sin traducción cuyo contenido importa en las pruebas: con CRLF en la estación y LF en la CI, **la misma prueba da distinto** (§4.2.5). Si no, la primera vale igual, y es la de los repositorios del fabricante relevados. En las dos, las excepciones las exige el consumidor: `*.cmd` y `*.bat` con CRLF para `cmd.exe`, `*.sh` con LF. Visual Studio declara soportar `end_of_line` [B45], así que LF en Windows no debería requerir configuración local **[no verificado]** (requiere Windows). A.2 usa la segunda.
~~~~

10. Reemplazar la línea que empieza con «6. **Aislar de `blame`** en un commit **posterior**,» (hoy:)

~~~~text
6. **Aislar de `blame`** en un commit **posterior**, porque el SHA no existe hasta que se crea. Sin el archivo, `git blame` atribuye todas las líneas al migrador; con él, vuelven a sus autores (E2-2). `git config blame.ignoreRevsFile .git-blame-ignore-revs` lo activa en local [B39]; GitHub lo aplica solo si el archivo está en la raíz [B42]. El SHA listado tiene que ser el que quedó en `main`: un `--amend` o un rebase posteriores lo cambian. La fusión por *squash* funciona si cada commit va en su propio PR —política, migración, `.git-blame-ignore-revs`— y el SHA se toma del *squash* ya fusionado: con git 2.47.3, `blame` vuelve a atribuir las líneas a sus autores (E2-2). Lo que el *squash* rompe es juntar los tres en un PR: los aplasta en uno y la verificación mecánica deja de aplicarse a un commit sólo mecánico **[criterio]**.
~~~~

por

~~~~text
6. **Aislar de `blame`** en un commit **posterior**, porque el SHA no existe hasta que se crea: sin el archivo, `git blame` atribuye todas las líneas al migrador; con él, vuelven a sus autores (E2-2). `git config blame.ignoreRevsFile .git-blame-ignore-revs` lo activa en local [B39]; GitHub lo aplica solo si el archivo está en la raíz [B42]. El SHA listado es el que quedó en `main`, que un `--amend` o un rebase cambian. La fusión por *squash* funciona con un PR por commit —política, migración, `.git-blame-ignore-revs`— y el SHA del *squash* ya fusionado: con git 2.47.3, `blame` vuelve a los autores (E2-2). Juntar los tres en un PR los aplasta en uno, y la verificación mecánica deja de aplicarse a un commit sólo mecánico **[criterio]**.
~~~~

11. Reemplazar la línea que empieza con «Corre en tres alcances: todos los archivos,» (hoy:)

~~~~text
Corre en tres alcances: todos los archivos, `--staged` para el hook y `--base <rama>` para un PR. En E2-3, un PR con un `.cs` en cp1252, dos BOM indebidos y un heredado editado con CRLF da cuatro violaciones y sale con código 1; el hook rechaza el commit; `git commit --no-verify` lo saltea. Por eso la misma compuerta corre en la CI: el hook es comodidad, la CI es el árbitro ([§10](#10-compuertas-y-gobierno-del-entorno)).
~~~~

por

~~~~text
Corre en tres alcances: todo, `--staged` para el hook y `--base <rama>` para un PR. En E2-3, un PR con un `.cs` en cp1252, dos BOM indebidos y un heredado editado con CRLF da cuatro violaciones y código 1; el hook rechaza el commit y `git commit --no-verify` lo saltea. Por eso la misma compuerta corre en la CI: el hook es comodidad, la CI es el árbitro ([§10](#10-compuertas-y-gobierno-del-entorno)).
~~~~

12. Reemplazar la línea que empieza con «`working-tree-encoding` resuelve otro problema.» (hoy:)

~~~~text
`working-tree-encoding` resuelve otro problema. git lo documenta para archivos que **no pueden** guardarse en UTF-8, advierte que JGit y libgit2 no lo soportan, que la conversión puede no ser reversible y que cuesta en cada checkout, y recomienda usarlo «sólo si no se puede guardar el archivo en UTF-8» [B36]. Sobre el caso no sirve: un `.cs` en cp1252 con `working-tree-encoding=CP1252` queda UTF-8 en el índice pero vuelve a cp1252 en el disco, que es lo que lee el compilador, y la build en Linux falla con el mismo `CS1056` (E2-4). Para fuentes que un compilador o intérprete lee en UTF-8: **convertir una vez**.
~~~~

por

~~~~text
`working-tree-encoding` resuelve otro problema: git lo documenta para archivos que **no pueden** guardarse en UTF-8, advierte que JGit y libgit2 no lo soportan, que la conversión puede no ser reversible y que cuesta en cada checkout, y lo recomienda «sólo si no se puede guardar el archivo en UTF-8» [B36]. Para el caso no sirve: un `.cs` en cp1252 con `working-tree-encoding=CP1252` queda UTF-8 en el índice y vuelve a cp1252 en el disco, que es lo que lee el compilador, y Linux falla con el mismo `CS1056` (E2-4). Un fuente que se lee en UTF-8 se **convierte una vez**.
~~~~

13. Reemplazar

~~~~text
POLITICA-TEXTO: 23 archivo(s) revisado(s), 0 violación(es)
~~~~

por

~~~~text
POLITICA-TEXTO: 25 archivo(s) revisado(s), 0 violación(es)
~~~~


### P-08 · §6 Toolchain: pnpm y Yarn, costo de `disable`, política por defecto, ESC-04, Práctica y señales

- **Hallazgos**: C2-30, C2-41, C2-57, C2-01, C2-04, C2-23, C2-50, C2-51, C2-32, C2-37.
- **Sección**: §6.2.1 diagrama L968; §6.2.2 L990; §6.2.3 L1000; §6.4 L1037, L1044; §6.6 L1095, L1104; §6.7 L1125; §6.9 L1133–L1134.
- **Capa de origen**: guía + N3, N4 (P-22). **Costo**: medio. **Reversible**: sí. **Δ palabras**: prosa -93, evidencia y plantillas +0.
- **Verificación**: `grep -c 'pnpm ≥ 11'` → 0; `grep -c 'desde la 11, lo hace cumplir'` → 0; [B206] y [B207] definidas y citadas; §6.2.2 cita `A compatible .NET SDK was not found` una sola vez y §6.6 P2 y A.3 remiten a §6.4 para el costo; la fila ESC-04 de §6.4 no contiene `digest`; la celda «Qué cuesta» cita [B56]. E1 de pnpm 10.18.0: `Informe-adhoc-AH-001.md` (AH-001-01).

1. Reemplazar

~~~~text
        PM["packageManager"] -- "pnpm ≥ 11 (pmOnFail) · Yarn con Corepack" --> PMV["pnpm / yarn"]
~~~~

por

~~~~text
        PM["packageManager"] -- "pnpm (solo) · Yarn con Corepack o yarnPath" --> PMV["pnpm / yarn"]
~~~~

2. Reemplazar

~~~~text
Esa recomendación tiene un costo que conviene escribir: con `disable`, **toda** máquina —cada estación, la imagen del devcontainer y la de CI— necesita exactamente ese SDK, y `dotnet` falla con `A compatible .NET SDK was not found` en la que tenga otro parche (E3-1). §6.4 pone las dos políticas lado a lado.
~~~~

por

~~~~text
Esa recomendación tiene un costo —el SDK exacto en **toda** máquina—, que §6.4 pone al lado de la alternativa.
~~~~

3. Reemplazar

~~~~text
pnpm, desde la 11, lo hace cumplir por sí mismo con el ajuste `pmOnFail` —por defecto `download`, que cambia a la versión declarada; con `error`, falla—, que gobierna también `devEngines.packageManager` [B196] (E3-3: pnpm 12.10.1 sin Corepack, con `pmOnFail=error`, `ERR_PNPM_BAD_PM_VERSION`). Yarn depende de Corepack o de instalarlo explícitamente [B81]. En la compuerta, pnpm con `pmOnFail=error`;
~~~~

por

~~~~text
pnpm lo hace cumplir por sí mismo [B81]: en la 10 descarga la versión declarada y, con `packageManagerStrictVersion=true`, falla [B206]; desde la 11 esos ajustes se unifican en `pmOnFail` —por defecto `download`; con `error`, falla—, que gobierna también `devEngines.packageManager` [B196] (E3-3: pnpm 12.10.1 sin Corepack, con `pmOnFail=error`, `ERR_PNPM_BAD_PM_VERSION`). Yarn depende de Corepack o de `yarnPath`, el binario versionado en el repo que deja `yarn set version --yarn-path` [B207]. En la compuerta, pnpm con `pmOnFail=error` (en la 10, `packageManagerStrictVersion=true`);
~~~~

4. Reemplazar

~~~~text
| ESC-04 Devcontainer | La imagen trae el toolchain | Imagen por etiqueta que cambia de parche y hasta de banda (E3-7) | Imagen construida desde los archivos nativos y fijada por digest (§8) |
~~~~

por

~~~~text
| ESC-04 Devcontainer | La imagen trae el toolchain | Imagen por etiqueta que cambia de parche y hasta de banda (E3-7) | Etiqueta fija de SDK y SO verificada por `global.json`, o la receta de la imagen de CI (§8.2.2) |
~~~~

5. Reemplazar

~~~~text
| **Con lock** (por defecto): `disable` + `packages.lock.json` en los ejecutables + `RestoreLockedMode` en CI |
~~~~

por

~~~~text
| **Con lock** (por defecto): `disable` + `packages.lock.json` en los ejecutables + `RestoreLockedMode` en CI + `NU1603` como error + la compuerta que compara `requested` con `resolved` |
~~~~

6. Reemplazar

~~~~text
| Una estación con otro parche **no compila** (`A compatible .NET SDK was not found`, E3-1) hasta instalar el exacto; cada actualización de Visual Studio puede reemplazar su SDK [B59]; subir el SDK es un PR que mueve `global.json`, las imágenes y los locks (§10.2.6) | El SDK, el grafo completo y el `contentHash` |
~~~~

por

~~~~text
| Una estación con otro parche **no compila** (`A compatible .NET SDK was not found`, E3-1) hasta instalar el exacto; cada actualización de Visual Studio puede reemplazar su SDK [B59], y el SDK independiente ya no se actualiza con Visual Studio: su parche mensual es un PR del equipo [B56]; subir el SDK es un PR que mueve `global.json`, las imágenes y los locks (§10.2.6) | El SDK, el grafo completo y el `contentHash`; la aproximación de una versión inexistente, en la compuerta (§7.2.1) |
~~~~

7. Reemplazar

~~~~text
*Criterio*: `disable` con lock files, aceptando su costo (el SDK exacto en cada estación); `latestPatch` sin lock files, con `NU1603` como error y la versión real registrada en la CI (§6.4).
~~~~

por

~~~~text
*Criterio*: §6.4.
~~~~

8. Reemplazar

~~~~text
`packageManager` lo hace cumplir pnpm ≥ 11 por sí mismo (`pmOnFail`, [B196]); con Yarn, Corepack o una instalación explícita.
~~~~

por

~~~~text
`packageManager` lo hace cumplir pnpm por sí mismo (10: `packageManagerStrictVersion` [B206]; ≥ 11: `pmOnFail` [B196]); con Yarn, Corepack o `yarnPath` [B207].
~~~~

9. Reemplazar

~~~~text
Señales de una versión pobre: `global.json` sin `rollForward` creyendo que fija la versión exacta; `"version": "8.0"`; `latestMajor` como «fijación»; confiar en que `engines` bloquea; `corepack enable` en una imagen de Node 26; `.nvmrc` que nada verifica; la CI que descarga «la última 3.x» de Python; subir el SDK con lock files activos y `rollForward` permisivo.
~~~~

por

~~~~text
Señales de una versión pobre:

- `global.json` sin `rollForward` creyendo que fija la versión exacta, `"version": "8.0"` o `latestMajor` como «fijación» (§6.2.2);
- confiar en que `engines` bloquea, o un `.nvmrc` que nada verifica (§6.2.3);
- `corepack enable` en una imagen de Node 26 (§6.2.3);
- la CI que descarga «la última 3.x» de Python (§6.2.4);
- subir el SDK con lock files activos y `rollForward` permisivo (§6.4).
~~~~

10. Reemplazar

~~~~text
*Respuesta esperada*: la de `Examples/N3-fijacion-del-toolchain/README.md`, sección E3-1;
~~~~

por

~~~~text
*Respuesta esperada*: la de `Examples/N3-fijacion-del-toolchain/README.md`, sección «01 — `global.json` y `rollForward`» (E3-1);
~~~~

11. Reemplazar

~~~~text
política elegida de la tabla de §6.4, costo aceptado y quién instala qué en cada estación.
~~~~

por

~~~~text
política elegida de la tabla de §6.4, costo aceptado y quién instala qué en cada estación. *Criterio de corrección*: nombra una fila de §6.4, dice qué se pierde con ella y quién instala el SDK exacto en cada estación Windows.
~~~~

12. Reemplazar la línea que empieza con «**¿Fijar el SDK fija el compilador?** En la CLI, sí:» (hoy:)

~~~~text
**¿Fijar el SDK fija el compilador?** En la CLI, sí: `dotnet build` compila con el Roslyn que viaja dentro del SDK (E3-2). En Visual Studio la build corre con el MSBuild del IDE y la respuesta depende de la versión del SDK. Los *targets* del SDK 8.0.425 no traen ninguna selección automática —sólo la opción `BuildWithNetFrameworkHostedCompiler`, y el paquete `Microsoft.Net.Sdk.Compilers.Toolset` no tiene versiones 8.x [B60]—, así que con el SDK 8 Visual Studio compila con su propio Roslyn. Los del SDK 10.0.400 usan el Roslyn del SDK cuando hay `DOTNET_HOST_PATH`, descargan el paquete *toolset* sólo si el MSBuild es anterior a 18.9 y, si no, caen en el compilador del IDE (E3-2, inspección de los *targets* de las imágenes oficiales). Qué compilador corre efectivamente en un Visual Studio real **[no verificado]** (requiere Visual Studio). Por eso el binario que vale es el de la CI, que compila con `dotnet build`, y el registro del entorno incluye la versión del compilador, no sólo la del SDK (§9.6).
~~~~

por

~~~~text
**¿Fijar el SDK fija el compilador?** En la CLI, sí: `dotnet build` compila con el Roslyn del SDK (E3-2). En Visual Studio la build corre con el MSBuild del IDE y depende del SDK: los *targets* del 8.0.425 no traen selección automática —sólo `BuildWithNetFrameworkHostedCompiler`, y `Microsoft.Net.Sdk.Compilers.Toolset` no tiene versiones 8.x [B60]—, así que compila el Roslyn del IDE; los del 10.0.400 usan el del SDK si hay `DOTNET_HOST_PATH`, descargan el *toolset* si el MSBuild es anterior a 18.9 y, si no, caen en el del IDE (E3-2, inspección de los *targets* de las imágenes oficiales). Qué corre en un Visual Studio real **[no verificado]** (requiere Visual Studio): el binario que vale es el de la CI, y el registro del entorno incluye la versión del compilador, no sólo la del SDK (§9.6).
~~~~

13. Reemplazar la línea que empieza con «Node no tiene un archivo propio para fijar su versión.» (hoy:)

~~~~text
Node no tiene un archivo propio para fijar su versión. **`.nvmrc`** es la convención de nvm, que no cambia de versión solo al entrar al directorio y no soporta Windows nativo [B69]; fnm lee `.nvmrc` y `.node-version` y, en su defecto, `engines.node` [B70]. Ni `node` ni `npm` lo leen: con `.nvmrc` = 24 en Node 22, `npm install` termina sin aviso (E3-3). **`engines`** es, según npm, «sólo un aviso» salvo `engine-strict` [B63][B64]; E3-3 lo confirma: advertencia `EBADENGINE` con código 0, error con código 1 si `engine-strict=true`. **`devEngines`** es el campo que npm documenta para alinear las herramientas de quienes **desarrollan** el proyecto (runtime, gestor, SO, CPU), con `onFail` por defecto `error`, evaluado antes de `install`, `ci` y `run` [B63]; E3-3 y EA-1 lo muestran fallando con `EBADDEVENGINES` sin tocar `.npmrc`. **`packageManager`** lo lee Corepack, que con él rechaza otro gestor y descarga la versión exacta [B67] (E3-3); pero Corepack figura como experimental en la documentación de Node 24 [B65] y **dejó de distribuirse con Node desde la 25.0.0** [B66][B67] (E3-3: Node 22 y 24 lo traen, Node 26 no).
~~~~

por

~~~~text
Node no tiene un archivo propio para fijar su versión. **`.nvmrc`** es la convención de nvm, que no cambia de versión solo al entrar al directorio ni soporta Windows nativo [B69]; fnm lee `.nvmrc`, `.node-version` y, en su defecto, `engines.node` [B70]. Ni `node` ni `npm` lo leen: con `.nvmrc` = 24 en Node 22, `npm install` termina sin aviso (E3-3). **`engines`** es «sólo un aviso» salvo `engine-strict` [B63][B64]: `EBADENGINE` con código 0, o 1 con `engine-strict=true` (E3-3). **`devEngines`** alinea las herramientas de quienes **desarrollan** el proyecto (runtime, gestor, SO, CPU), con `onFail` por defecto `error`, evaluado antes de `install`, `ci` y `run` [B63]: falla con `EBADDEVENGINES` sin tocar `.npmrc` (E3-3, EA-1). **`packageManager`** lo lee Corepack, que rechaza otro gestor y descarga la versión exacta [B67] (E3-3); pero Corepack figura como experimental en Node 24 [B65] y **dejó de distribuirse con Node desde la 25.0.0** [B66][B67] (E3-3: Node 22 y 24 lo traen, Node 26 no).
~~~~

14. Reemplazar la línea que empieza con «Experimentos del capítulo: E3-1 (» (hoy:)

~~~~text
Experimentos del capítulo: E3-1 (siete `global.json` contra dos SDK), E3-2 (SDK → compilador, TFM → C#, runtime al ejecutar, `LangVersion=latest`), E3-3 (`engines`, `engine-strict`, `devEngines`, Corepack en Node 22/24/26), E3-4 (`requires-python` y `.python-version` con pip y uv), E3-5 (chequeo común), E3-6 (otro SDK rompe el lock de NuGet), E3-7 (deriva de las etiquetas `sdk:8.0` y `sdk:10.0` en el host: 8.0.424 → 8.0.425 y 10.0.302 → 10.0.400, un cambio de **banda**).
~~~~

por

~~~~text
Experimentos del capítulo: E3-1 a E3-7 (Anexo E); en E3-7, las etiquetas `sdk:8.0` y `sdk:10.0` del host derivaron de 8.0.424 a 8.0.425 y de 10.0.302 a 10.0.400, un cambio de **banda**.
~~~~

15. Reemplazar la línea que empieza con ««Estamos en .NET 8» puede responder tres cosas distintas,» (hoy:)

~~~~text
«Estamos en .NET 8» puede responder tres cosas distintas, cada una fijada en otro archivo. **Con qué herramienta se compila**: el SDK, que elige `global.json`; sin ese archivo, `dotnet` usa el SDK más alto instalado aunque el proyecto apunte a una versión anterior [B58]. **Contra qué API y con qué lenguaje**: el TFM del `.csproj`. **Con qué runtime corre**: se decide en la máquina que ejecuta. E3-2 las separa con un mismo proyecto `net8.0`: con SDK 8.0.425 compila el compilador C# 4.11.0 y con SDK 10.0.400 el 5.9.0, ambos en C# 12.0 porque lo fija el TFM; el binario del SDK 10 pide runtime 8.0 y **no arranca** donde sólo hay runtime 10. En Node y Python las tres preguntas se aplastan en una (el intérprete es herramienta y runtime); lo que se separa ahí es el **runtime** y el **gestor de paquetes**.
~~~~

por

~~~~text
«Estamos en .NET 8» responde tres preguntas, cada una fijada en otro archivo. **Con qué herramienta se compila**: el SDK, que elige `global.json`; sin él, `dotnet` usa el más alto instalado aunque el proyecto apunte a una versión anterior [B58]. **Contra qué API y con qué lenguaje**: el TFM del `.csproj`. **Con qué runtime corre**: lo decide la máquina que ejecuta. E3-2 las separa con un proyecto `net8.0`: con SDK 8.0.425 compila C# 4.11.0 y con 10.0.400 el 5.9.0, ambos en C# 12.0 por el TFM, y el binario del SDK 10 pide runtime 8.0 y **no arranca** donde sólo hay runtime 10. En Node y Python el intérprete es herramienta y runtime; lo que se separa es el **runtime** del **gestor de paquetes**.
~~~~

16. Reemplazar la línea que empieza con «**Visual Studio en Windows (ESC-01).**» (hoy:)

~~~~text
**Visual Studio en Windows (ESC-01).** Visual Studio instala **una sola copia** del SDK y la reemplaza al actualizarse; si `global.json` pide la anterior, la build deja de encontrarla, y Microsoft recomienda instalar el SDK independiente para conservarla [B56][B59]. Cada banda de SDK exige una versión mínima de Visual Studio (10.0.100 → VS 17.14; 10.0.2xx–4xx → VS 18.0) [B59]: fijar una banda nueva obliga a todo el equipo a actualizar el IDE. Que Visual Studio respete `global.json` es una inferencia documentada (la build pasa por el resolvedor de MSBuild, y `allowPrerelease` describe un comportamiento «si estás en Visual Studio» [B56]); ninguna página lo dice en una frase directa. Las dos recomendaciones de Microsoft —usar el SDK que trae el IDE y fijar uno exacto con lock files— tiran en direcciones opuestas; la guía presenta la elección en §6.4 en vez de esconderla.
~~~~

por

~~~~text
**Visual Studio en Windows (ESC-01).** Visual Studio instala **una sola copia** del SDK y la reemplaza al actualizarse; si `global.json` pide la anterior, la build deja de encontrarla, y Microsoft recomienda el SDK independiente para conservarla [B56][B59]. Cada banda exige un Visual Studio mínimo (10.0.100 → VS 17.14; 10.0.2xx–4xx → VS 18.0) [B59]: fijar una banda nueva obliga a todo el equipo a actualizar el IDE. Que Visual Studio respete `global.json` es una inferencia documentada (la build pasa por el resolvedor de MSBuild, y `allowPrerelease` describe un comportamiento «si estás en Visual Studio» [B56]), no una frase directa. Usar el SDK del IDE y fijar uno exacto con lock files, las dos recomendaciones de Microsoft, tiran en direcciones opuestas: §6.4 presenta la elección.
~~~~

17. Reemplazar la línea que empieza con «**`requires-python`** pertenece al **paquete**:» (hoy:)

~~~~text
**`requires-python`** pertenece al **paquete**: se publica como metadato y lo validan los instaladores [B71][B72]; pip falla si el intérprete no coincide y lo saltea con `--ignore-requires-python` [B73][B74] (E3-4). En uv además acota la resolución del lock, que se calcula para todo el rango [B77]. **`.python-version`** es una preferencia **del entorno**, convención de pyenv que también lee uv [B78][B75]: uv lo busca en el directorio y sus padres **sin pasar el límite del proyecto**, y por defecto **descarga** el intérprete si no está (`python-downloads = "automatic"`) [B75][B76]. E3-4 muestra los tres comportamientos: `3.13` descargó 3.13.16 («la 3.13 más reciente», no una fijación exacta); `3.11` contra `requires-python >=3.13` falla; con descargas prohibidas y sin 3.13 instalado, falla. **`[tool.uv] required-version`** hace fallar uv si su propia versión no coincide [B76] (E3-4): es el equivalente de `devEngines.packageManager`.
~~~~

por

~~~~text
**`requires-python`** pertenece al **paquete**: se publica como metadato y lo validan los instaladores [B71][B72]; pip falla si el intérprete no coincide, salvo `--ignore-requires-python` [B73][B74] (E3-4), y en uv acota la resolución del lock, calculada para todo el rango [B77]. **`.python-version`** es una preferencia **del entorno**, convención de pyenv que también lee uv [B78][B75]: uv lo busca en el directorio y sus padres **sin pasar el límite del proyecto**, y por defecto **descarga** el intérprete que falte (`python-downloads = "automatic"`) [B75][B76]. En E3-4, `3.13` descargó 3.13.16 («la 3.13 más reciente», no una fijación exacta); `3.11` contra `requires-python >=3.13` falla, y también falla sin 3.13 instalado y con descargas prohibidas. **`[tool.uv] required-version`** hace fallar uv si su versión no coincide [B76] (E3-4): el equivalente de `devEngines.packageManager`.
~~~~

18. Reemplazar la línea que empieza con «Tres choques de integración que conviene conocer de antemano:» (hoy:)

~~~~text
Tres choques de integración que conviene conocer de antemano: `global.json` exige versión completa y `.nvmrc`/`.python-version` aceptan una línea (`3.12` = «la más reciente»): **[criterio]** en CI, fijar el parche donde el ecosistema lo permite. `allowPrerelease` vale `true` fuera de Visual Studio y depende del IDE adentro: declararlo `false` evita que terminal e IDE elijan SDK distintos [B56]. Y si la build .NET invoca `npm` o `python`, usa los del `PATH`: `global.json` no los cubre (E8-3).
~~~~

por

~~~~text
Tres choques de integración: `global.json` exige versión completa y `.nvmrc`/`.python-version` aceptan una línea (`3.12` = «la más reciente»): **[criterio]** en CI, el parche fijado donde el ecosistema lo permite. `allowPrerelease` vale `true` fuera de Visual Studio y depende del IDE adentro: `false` evita que terminal e IDE elijan SDK distintos [B56]. Y la build .NET que invoca `npm` o `python` usa los del `PATH`, que `global.json` no cubre (E8-3).
~~~~


### P-09 · §7 Dependencias: las dos defensas contra `NU1603`, `WinExe`, tabla de §7.3, `.nupkg` y señales

- **Hallazgos**: C2-01, C2-02, C2-03, C2-37, C2-42, C2-46, C2-47, C2-50.
- **Sección**: §7.2.1 L1179, L1181; §7.2.2 L1189; §7.3 L1204–L1205; §7.4 L1224; §7.5 L1259; §7.6 L1266; §7.7 L1296; §7.9 L1304.
- **Capa de origen**: guía + N4 (P-22). **Costo**: medio. **Reversible**: sí. **Δ palabras**: prosa +36, evidencia y plantillas +1.
- **Verificación**: EA-1 paso 8 (P-23 L3): con `Microsoft.Extensions.Primitives 8.0.2` el restore con lock no emite `NU1603` y la compuerta da `pide [8.0.2, ) y resolvió 9.0.0` y `resultado=ROJO`; paso 2c: el `WinExe` tiene `packages.lock.json` (evidencia-auditor/x2-compuerta-propuesta/salida.txt, secciones 4 y 5). `grep -c 'sólo cuando detectan CI'` → 0; `grep -c '\*\*\[no verificado\]\*\* |' ` en §7.3 → 0; [B215] definida y citada; conteo de `[B83]` en §7.2.1 sin cambio.

1. Reemplazar

~~~~text
Con `NU1603` tratado como error, el restore sin lock se detiene y el restore con lock termina con 0: en este caso, activar el lock desarma esa defensa (E4-2). **[criterio]** Con lock, la compuerta compara `requested` con `resolved` en las entradas `Direct` y `CentralTransitive` del lock; sin lock, `NU1603` va en `WarningsAsErrors` (A.4).
~~~~

por

~~~~text
Con `NU1603` tratado como error, el restore sin lock se detiene y el restore con lock termina con 0: el lock desarma esa defensa (E4-2). **[criterio]** Por eso van las dos: `NU1603` como error en todo proyecto (A.4), que corta a los que no tienen lock, y una compuerta que compara la cota inferior de `requested` con `resolved` en las entradas `Direct` y `CentralTransitive` de los que lo tienen (A.11; EA-1: `pide [8.0.2, ) y resolvió 9.0.0`). También marca una subida legítima, que se resuelve subiendo la `PackageVersion`.
~~~~

2. Reemplazar

~~~~text
Tres reglas del fabricante: el lock que gobierna es el del proyecto en la punta de la cadena, y el de una biblioteca que no se distribuye o de un proyecto de código común del que dependen otros «no debería» versionarse —conservarlo «no hace daño», pero no fija lo que resuelve quien lo referencia— [B83]; fijar el SDK porque aporta paquetes implícitos (§6, E3-6) [B83]; y saber que la poda de paquetes del SDK 10 (`PrunePackageReference`) cambia el grafo la próxima vez que se regenera [B83]. Además, **el conjunto de RID
~~~~

por

~~~~text
Tres reglas del fabricante:

- el lock que gobierna es el del proyecto en la punta de la cadena; el de una biblioteca que no se distribuye o de un proyecto común del que dependen otros «no debería» versionarse —conservarlo «no hace daño», pero no fija lo que resuelve quien lo referencia— [B83];
- el SDK se fija porque aporta paquetes implícitos (§6, E3-6) [B83];
- la poda de paquetes del SDK 10 (`PrunePackageReference`) cambia el grafo la próxima vez que se regenera [B83].

**Ejecutable quiere decir `Exe` o `WinExe`**, el tipo de las apps WinForms y WPF [B215]: una regla que mire sólo `Exe` las deja sin lock y con la CI en verde (A.4b, EA-1). Un proyecto de prueba no recibe lock por esa regla: su `OutputType=Exe` llega de un paquete que el restore no evalúa (SDK 8.0.425 **[observado]**).

**El conjunto de RID
~~~~

3. Reemplazar

~~~~text
activan el modo estricto **sólo cuando detectan CI** [B95][B96]
~~~~

por

~~~~text
activan el modo estricto **por defecto** cuando detectan CI [B95][B96]
~~~~

4. Reemplazar

~~~~text
| Error de deriva | `NU1004` | `EUSAGE` | `ERR_PNPM_OUTDATED_LOCKFILE` | **[no verificado]** | «needs to be updated» | «changed significantly» | — |
~~~~

por

~~~~text
| Error de deriva | `NU1004` | `EUSAGE` | `ERR_PNPM_OUTDATED_LOCKFILE` | `YN0028` | «needs to be updated» | «changed significantly» | — |
~~~~

5. Reemplazar

~~~~text
| Error de integridad | `NU1403` | `EINTEGRITY` | **[no verificado]** | **[no verificado]** | **[no verificado]** | **[no verificado]** | «DO NOT MATCH THE HASHES» |
~~~~

por

~~~~text
| Error de integridad | `NU1403` | `EINTEGRITY` | `ERR_PNPM_TARBALL_INTEGRITY` | `YN0018` | «Hash mismatch» | «did not match any known checksums» | «DO NOT MATCH THE HASHES» |
~~~~

6. Reemplazar

~~~~text
El riesgo de confusión de dependencias está en el momento de bloquear o actualizar:
~~~~

por

~~~~text
Los cinco mensajes nuevos de esas dos filas son **[observado]** (Yarn 4.10.3, pnpm 10.18.0, uv 0.12.23, Poetry 2.5.1; Anexo F).

El riesgo de confusión de dependencias está en el momento de bloquear o actualizar:
~~~~

7. Reemplazar

~~~~text
en CTX-NET la decisión es lock sí o no (§6.4) y, con lock, sólo en los ejecutables (A.4);
~~~~

por

~~~~text
en CTX-NET la decisión es lock sí o no (§6.4) y, con lock, sólo en los ejecutables, `Exe` y `WinExe` (A.4);
~~~~

8. Reemplazar

~~~~text
Un mismo código empaquetado dos veces con SDK 8 o 10 da `.nupkg` con hash distinto (fechas y un nombre aleatorio dentro del zip); si un feed interno re-empaqueta «la misma versión», los locks de sus consumidores fallan con `NU1403` (E4-3, E6-2).
~~~~

por

~~~~text
Un mismo código empaquetado dos veces con SDK 8 da `.nupkg` con hash distinto (fechas y un nombre aleatorio dentro del zip, E6-2), y con SDK 10 también, según [B147]; si un feed interno re-empaqueta «la misma versión», los locks de sus consumidores fallan con `NU1403` (E4-3).
~~~~

9. Reemplazar

~~~~text
detiene la aproximación de E4-2 que el lock deja pasar en silencio,
~~~~

por

~~~~text
detiene la aproximación de E4-2 que el lock por sí solo deja pasar en silencio,
~~~~

10. Reemplazar

~~~~text
Señales de una versión pobre: lock commiteado y CI con `dotnet restore`, `npm install` o `uv sync` a secas; `Version="X"` leído como exacto; `requirements.txt` compilado en Linux usado en Windows; lock sin RID y CI que restaura con `-r`; SDK subido sin regenerar el lock; el lock de una biblioteca o de un proyecto común tratado como garantía para quien la referencia; .NET sin lock y con `NU1603` como simple advertencia; mapeo de fuentes con caché compartida como única defensa; un conflicto de lock «arreglado» a mano; `uv sync --frozen` en CI; `pip lock` como mecanismo estable.
~~~~

por

~~~~text
Señales de una versión pobre:

- lock commiteado y CI con `dotnet restore`, `npm install`, `uv sync` a secas o `uv sync --frozen` (§7.2);
- `Version="X"` leído como exacto (§7.1);
- `requirements.txt` compilado en Linux usado en Windows, o lock sin RID y CI que restaura con `-r` (§7.2.1, §7.2.3);
- SDK subido sin regenerar el lock (§6.2.2);
- el lock de una biblioteca o de un proyecto común tratado como garantía para quien la referencia, o una app `WinExe` sin lock (§7.2.1);
- `NU1603` como simple advertencia, o un lock sin la compuerta que compara `requested` con `resolved` (§7.2.1);
- mapeo de fuentes con caché compartida como única defensa (§7.2.1);
- un conflicto de lock «arreglado» a mano (§7.6);
- `pip lock` como mecanismo estable (§7.2.3).
~~~~

11. Reemplazar

~~~~text
con lock, una compuerta que compare `requested` con `resolved` (§7.2.1).
~~~~

por

~~~~text
con lock, la compuerta de A.11, que compara `requested` con `resolved` (§7.2.1).
~~~~

12. Reemplazar la línea que empieza con «`uv.lock` es TOML, lo administra uv,» (hoy:)

~~~~text
`uv.lock` es TOML, lo administra uv, se commitea y es **universal**: en E4-5 incluyó `colorama` con `marker = "sys_platform == 'win32'"`, una dependencia que sólo existe en Windows [B98][B99]. `uv run` y `uv sync` bloquean y sincronizan automáticamente: en desarrollo, un cambio en `pyproject.toml` reescribe el lock sin pedirlo (E4-5). `--locked` falla si el lock no está al día; `--frozen` lo usa **sin verificar** [B97]: **[criterio]** en CI, `--locked`. Poetry: `install` con lock desactualizado falla y `check --lock` lo verifica [B105] (E4-5). `uv pip compile` produce un `requirements.txt` **por plataforma** salvo `--universal` [B98]; `pip-compile` (pip-tools) no tiene esa opción, y su README pide compilar en cada entorno de destino [B104]. En E4-5, `uv pip compile` sin `--universal` —usado como sustituto del estilo pip-tools— corrido en Linux **omitió** `colorama`: el modo de falla «funciona en Linux, en Windows falta un paquete». El modo hash de pip es todo o nada y exige `==` [B102].
~~~~

por

~~~~text
`uv.lock` es TOML, lo administra uv, se commitea y es **universal**: en E4-5 incluyó `colorama` con `marker = "sys_platform == 'win32'"`, una dependencia que sólo existe en Windows [B98][B99]. `uv run` y `uv sync` bloquean y sincronizan solos: en desarrollo, un cambio en `pyproject.toml` reescribe el lock (E4-5). `--locked` falla si el lock no está al día; `--frozen` lo usa **sin verificar** [B97]: **[criterio]** en CI, `--locked`. Poetry: `install` con lock desactualizado falla y `check --lock` lo verifica [B105] (E4-5). `uv pip compile` da un `requirements.txt` **por plataforma** salvo `--universal` [B98]; `pip-compile` no tiene esa opción y su README pide compilar en cada entorno de destino [B104]. En E4-5, `uv pip compile` sin `--universal`, corrido en Linux, **omitió** `colorama`: «funciona en Linux, en Windows falta un paquete». El modo hash de pip es todo o nada y exige `==` [B102].
~~~~

13. Reemplazar la línea que empieza con «Experimentos del capítulo: E4-1 (» (hoy:)

~~~~text
Experimentos del capítulo: E4-1 (lock de NuGet: estricto, reescritura silenciosa, `contentHash`, RID), E4-2 (CPM y *transitive pinning*), E4-3 (mapeo de fuentes, caché caliente, impostor), E4-4 (npm y pnpm), E4-5 (uv, pip-tools, modo hash, `pylock.toml`, Poetry); salidas en `Examples/N4-congelamiento-de-dependencias/salidas/`.
~~~~

por

~~~~text
Experimentos del capítulo: E4-1 a E4-5 (Anexo E; salidas en `Examples/N4-congelamiento-de-dependencias/salidas/`).
~~~~

14. Reemplazar la línea que empieza con «**`nuget.config` en la raíz con `<clear />`**» (hoy:)

~~~~text
**`nuget.config` en la raíz con `<clear />`** evita que la configuración del usuario o de la máquina agregue fuentes [B87]: es el equivalente, para los registros, de no depender de `core.autocrlf`. El mapeo de fuentes exige que **todo** paquete, transitivas incluidas, coincida con un patrón (`NU1100` si no) [B86] (E4-3). Tiene dos huecos documentados: si el paquete ya está en la carpeta global, no se consulta ninguna fuente y el mapeo se ignora; y no aplica a consultas de metadatos [B86]. E4-3 reproduce el primero: con la caché caliente, un impostor se coló y el programa imprimió `IMPOSTOR`; el `contentHash` del lock, en cambio, lo detectó (`NU1403`). Las dos defensas son complementarias.
~~~~

por

~~~~text
**`nuget.config` en la raíz con `<clear />`** evita que la configuración del usuario o de la máquina agregue fuentes [B87], como `.gitattributes` evita depender de `core.autocrlf`. El mapeo de fuentes exige que **todo** paquete, transitivas incluidas, coincida con un patrón (`NU1100` si no) [B86] (E4-3), con dos huecos documentados: un paquete ya presente en la carpeta global no consulta ninguna fuente, y el mapeo no aplica a consultas de metadatos [B86]. En E4-3, con la caché caliente, un impostor se coló e imprimió `IMPOSTOR`; el `contentHash` del lock lo detectó (`NU1403`): defensas complementarias.
~~~~

15. Reemplazar la línea que empieza con «Declarar una versión no congela nada.» (hoy:)

~~~~text
Declarar una versión no congela nada. Lo que congela es un **lock file** con el grafo completo y sus hashes, más un **comando de restauración que falle** cuando el lock no coincide con lo declarado. Sin ese comando, el lock es una sugerencia que la herramienta reescribe en silencio. En npm y uv el fabricante pide versionar el lock [B93][B99]; en NuGet es *opt-in* [B83], y esta guía lo adopta por defecto con su costo declarado y una alternativa sin lock para quien no quiera pagarlo (§6.4, §7.2.1). Los experimentos de este capítulo lo confirman en los tres ecosistemas.
~~~~

por

~~~~text
Declarar una versión no congela nada. Congela un **lock file** con el grafo completo y sus hashes, más un **comando de restauración que falle** si el lock no coincide con lo declarado; sin ese comando, el lock es una sugerencia que la herramienta reescribe. En npm y uv el fabricante pide versionar el lock [B93][B99]; en NuGet es *opt-in* [B83], y esta guía lo adopta por defecto, con su costo y una alternativa sin lock (§6.4, §7.2.1).
~~~~

16. Reemplazar la línea que empieza con «**Integración en una solución** (el detalle es de» (hoy:)

~~~~text
**Integración en una solución** (el detalle es de [§11](#11-una-sola-solución-con-net-nodejs-y-python)): no hay lock común. **[criterio]** Un lock por ecosistema junto a su manifiesto; una sola compuerta que llama a los tres comandos estrictos; los registros de los tres declarados en el repo; el toolchain fijado antes que el lock (la versión de npm decide `lockfileVersion`, la de uv el formato de `uv.lock`); y un bot de actualización que entienda los tres locks. Dependabot soporta NuGet, npm, pnpm, Yarn, pip, Poetry y uv, pero su tabla declara versiones máximas (npm ≤ v11, pnpm ≤ v10, uv v0.11) por debajo de las vigentes al 2026-10-07 (npm 12, pnpm 12, uv 0.12) [B107]; Renovate tiene `lockFileMaintenance`, deshabilitado por defecto [B108].
~~~~

por

~~~~text
**Integración en una solución** (detalle en [§11](#11-una-sola-solución-con-net-nodejs-y-python)): no hay lock común. **[criterio]** Un lock por ecosistema junto a su manifiesto; una compuerta que llama a los tres comandos estrictos; los registros de los tres declarados en el repo; el toolchain fijado antes que el lock (la versión de npm decide `lockfileVersion`, la de uv el formato de `uv.lock`); y un bot que entienda los tres locks. Dependabot soporta NuGet, npm, pnpm, Yarn, pip, Poetry y uv, con versiones máximas (npm ≤ v11, pnpm ≤ v10, uv v0.11) por debajo de las vigentes al 2026-10-07 (npm 12, pnpm 12, uv 0.12) [B107]; Renovate tiene `lockFileMaintenance`, deshabilitado por defecto [B108].
~~~~

17. Reemplazar la línea que empieza con «**Central Package Management (CPM).**» (hoy:)

~~~~text
**Central Package Management (CPM).** `Directory.Packages.props` con `ManagePackageVersionsCentrally=true` y `PackageVersion`; los `.csproj` referencian sin `Version` (`NU1008` si la llevan) [B85]. *Transitive pinning* hace que una `PackageVersion` gobierne también a la dependencia transitiva; no permite bajar versiones (`NU1109`) y, en bibliotecas, convierte esas transitivas en dependencias explícitas del paquete [B85] (E4-2). **CPM y lock no son alternativas**: CPM decide qué se pide, en un lugar; el lock registra qué se obtuvo, con hash. CPM solo no garantiza la versión pedida (E4-2 pidió 8.0.2 y obtuvo 9.0.0).
~~~~

por

~~~~text
**Central Package Management (CPM).** `Directory.Packages.props` con `ManagePackageVersionsCentrally=true` y `PackageVersion`; los `.csproj` referencian sin `Version` (`NU1008` si la llevan) [B85]. Con *transitive pinning*, una `PackageVersion` gobierna también a la transitiva; no permite bajar versiones (`NU1109`) y, en bibliotecas, vuelve explícitas esas transitivas en el paquete [B85] (E4-2). **CPM y lock no son alternativas**: CPM decide qué se pide; el lock registra qué se obtuvo, con hash. CPM solo no garantiza la versión pedida (E4-2: pidió 8.0.2, obtuvo 9.0.0).
~~~~

18. Reemplazar la línea que empieza con «**PEP 751 (`pylock.toml`)** está *Final*» (hoy:)

~~~~text
**PEP 751 (`pylock.toml`)** está *Final* (resuelta el 2025-03-31) y su especificación vigente vive en packaging.python.org [B100][B101]. Adopción al 2026-10-07: uv la exporta y conserva `uv.lock` como formato propio [B99]; pip 26.2.1 instala desde `pylock.toml` y tiene `pip lock`, ambos **experimentales**, y el lock de `pip lock` vale sólo para la plataforma actual [B103] (E4-5). **[criterio]** Hoy `pylock.toml` sirve como formato de **intercambio**, no como reemplazo del lock de la herramienta del proyecto.
~~~~

por

~~~~text
**PEP 751 (`pylock.toml`)** está *Final* (resuelta el 2025-03-31) y su especificación vive en packaging.python.org [B100][B101]. Al 2026-10-07, uv la exporta y conserva `uv.lock` como formato propio [B99]; pip 26.2.1 instala desde `pylock.toml` y tiene `pip lock`, ambos **experimentales**, con un lock que vale sólo para la plataforma actual [B103] (E4-5). **[criterio]** Hoy `pylock.toml` es un formato de **intercambio**, no el reemplazo del lock de la herramienta del proyecto.
~~~~

19. Reemplazar la línea que empieza con «Fijar versiones directas y congelar el grafo son operaciones» (hoy:)

~~~~text
Fijar versiones directas y congelar el grafo son operaciones sobre capas distintas de la misma cosa: la primera controla la **entrada** del resolvedor; la segunda guarda la **salida**. Un hash agrega una tercera garantía: que el contenido no cambió aunque nombre y versión sean los mismos.
~~~~

por

~~~~text
Fijar versiones directas controla la **entrada** del resolvedor; congelar el grafo guarda la **salida**; el hash agrega que el contenido no cambió aunque nombre y versión sean los mismos.
~~~~


### P-10 · §8 Contenedores: CI sin imagen propia, quién mueve el digest, `safe.directory`, buildx y señales

- **Hallazgos**: C2-13, C2-17, C2-11, C2-24, C2-37, C2-50.
- **Sección**: §8.2.2 puntos 1 y 3 L1372, L1374; §8.3 L1445; §8.5 L1475, L1480; §8.7 L1526.
- **Capa de origen**: guía + N5 (P-22). **Costo**: bajo. **Reversible**: sí. **Δ palabras**: prosa -9, evidencia y plantillas +25.
- **Verificación**: §8.5 JSONC válido; el `postCreateCommand` de §8.5 y el de A.9 llevan `safe.directory`; `devcontainer up` con A.9 da `"outcome":"success"` y `core.hooksPath=.githooks` (evidencia-auditor/x4-devcontainer-safe-directory/salida.txt); [B213] y [B216] definidas y citadas.

1. Reemplazar

~~~~text
Se escribe `repo:etiqueta@sha256:…`: la etiqueta queda como referencia humana y manda el digest.
~~~~

por

~~~~text
Se escribe `repo:etiqueta@sha256:…`: la etiqueta queda como referencia humana y manda el digest. Para 8a también vale el runner alojado con acciones de *setup* por SHA que leen `global.json`, `.nvmrc` y `.python-version` [B181]: la imagen del runner (capa 4) flota y queda en el log «Set up job» [B216]. La imagen propia hace falta para 8b, la reconstrucción bit a bit o la frontera A en la CI (§11.2.5).
~~~~

2. Reemplazar

~~~~text
3. **Actualización como PR**, no como accidente: un bot o un trabajo programado propone el digest nuevo y el PR pasa por las mismas compuertas (§10).
~~~~

por

~~~~text
3. **Actualización como PR**, no como accidente: un bot o un trabajo programado propone el digest nuevo y el PR pasa por las mismas compuertas (§10). Ningún ecosistema de Dependabot cubre el `container:` de un workflow [B107]; Renovate lo reconoce [B213], pero que mueva su digest **[no verificado]**: lo mueve el PR que abre el workflow que publica la imagen **[criterio]**.
~~~~

3. Reemplazar

~~~~text
| Transversal | Fijar imágenes por digest y actualizarlas por PR automatizado [B113]. Dependabot soporta `docker` y `devcontainers` para actualizaciones de versión (no de seguridad), y la tabla oficial marca `devcontainers` como **no soportado en repositorios privados** [B107]; Docker documenta que Dependabot actualiza etiqueta y digest de las imágenes base [B113]; la página de ecosistemas de GitHub no menciona digests [B107] y el laboratorio no lo observó **[no verificado]** (requiere la plataforma). Renovate documenta `pinDigests` [B108]. | fabricante |
~~~~

por

~~~~text
| Transversal | Fijar imágenes por digest y actualizarlas por PR automatizado [B113]. Dependabot: `docker` y `devcontainers`, sólo actualizaciones de versión, y `devcontainers` **no soportado en repositorios privados** [B107]; que mueva digests lo documenta Docker [B113] y no GitHub [B107] **[no verificado]** (§8.2.2). Renovate: `pinDigests` [B108]. | fabricante |
~~~~

4. Reemplazar

~~~~text
  "postCreateCommand": "git config core.hooksPath .githooks && dotnet --version && node --version"
}
~~~~

por

~~~~text
  // La imagen corre como root: sin safe.directory, git rechaza el repo montado (8.2.5).
  "postCreateCommand": "git config --global --add safe.directory ${containerWorkspaceFolder} && git config core.hooksPath .githooks && dotnet --version && node --version"
}
~~~~

5. Reemplazar

~~~~text
# ¿A qué digest apunta HOY una etiqueta? (sin bajar la imagen; E5-2)
~~~~

por

~~~~text
# ¿A qué digest apunta HOY una etiqueta? (sin bajar la imagen; E5-2, buildx v0.35.0; ver §0.4)
~~~~

6. Reemplazar

~~~~text
Señales de una versión pobre: «con devcontainer ya no hace falta `.gitattributes`»; «usamos `sdk:8.0`, así que todos tenemos lo mismo»; digests sin actualización; *feature* de Node sin `version`; creer que el lock de devcontainer fija la imagen; Alpine «porque es más chica» con Node o Python nativos; imágenes de dev y CI elegidas por nombre; un digest en el devcontainer de un repo privado que ningún bot actualiza.
~~~~

por

~~~~text
Señales de una versión pobre:

- «con devcontainer ya no hace falta `.gitattributes`» (§8.2.1);
- «usamos `sdk:8.0`, así que todos tenemos lo mismo» (§8.2.2);
- digests sin actualización, o un digest en el devcontainer de un repo privado que ningún bot actualiza (§8.2.2);
- *feature* de Node sin `version`, o creer que el lock de devcontainer fija la imagen (§8.2.3);
- Alpine «porque es más chica» con Node o Python nativos (§8.3);
- imágenes de dev y CI elegidas por nombre (§8.2.6).
~~~~

7. Reemplazar la línea que empieza con «Docker documenta que las etiquetas son mutables» (hoy:)

~~~~text
Docker documenta que las etiquetas son mutables y que fijar por digest garantiza la misma imagen, con el costo explícito de renunciar a las correcciones de seguridad automáticas; propone mitigarlo con Docker Scout o con Dependabot, que según Docker abre PR con la etiqueta y el digest nuevos [B113]; la página de ecosistemas de GitHub dice que el ecosistema `docker` actualiza las referencias de imagen de los Dockerfile sin mencionar digests [B107], y el laboratorio no lo observó **[no verificado]** (requiere la plataforma). El equipo de imágenes de .NET distingue etiquetas *fijas* (`8.0.11`: la versión de .NET no cambia) y *flotantes* (`8.0`), y aclara que **ambas** se rehacen cuando cambia la imagen base del SO: «para pedir un parche específico del sistema operativo hace falta fijar por digest» [B115]. Esas imágenes se reconstruyen dentro de las 12 horas de una actualización de su base, con cada versión de .NET, ante CVE críticos y una vez por mes, típicamente el segundo martes [B115].
~~~~

por

~~~~text
Docker documenta que las etiquetas son mutables y que fijar por digest garantiza la misma imagen, al costo de renunciar a las correcciones de seguridad automáticas; propone mitigarlo con Docker Scout o con Dependabot, que según Docker abre PR con etiqueta y digest nuevos [B113]. La página de ecosistemas de GitHub no menciona digests para `docker` [B107] y el laboratorio no lo observó **[no verificado]** (requiere la plataforma). Las imágenes de .NET distinguen etiquetas *fijas* (`8.0.11`: la versión de .NET no cambia) y *flotantes* (`8.0`), y **ambas** se rehacen cuando cambia la base del SO: «para pedir un parche específico del sistema operativo hace falta fijar por digest» [B115]. Se reconstruyen dentro de las 12 horas de una actualización de su base, con cada versión de .NET, ante CVE críticos y una vez por mes, típicamente el segundo martes [B115].
~~~~

8. Reemplazar la línea que empieza con «Dos imágenes que un equipo llamaría «la de .NET 10»» (hoy:)

~~~~text
Dos imágenes que un equipo llamaría «la de .NET 10» dieron SDK y binarios distintos; `global.json` detectó la diferencia sin que nadie mirara versiones. No se encontró una recomendación oficial de que deban ser la misma imagen; containers.dev presenta la especificación también como ayuda a la CI [B138] y mantiene una acción que corre la CI dentro del devcontainer [B134]. **[criterio]** No hace falta la misma imagen; hace falta **compartir la base que trae el toolchain** y que el repo verifique la coincidencia: o la CI corre dentro del devcontainer preconstruido (stacks simples), o la imagen de desarrollo se construye `FROM` el mismo `sdk@sha256` que usa la CI y le agrega herramientas (imágenes pesadas o multi-runtime, §11). Lo que no conviene son imágenes elegidas por separado por un nombre parecido.
~~~~

por

~~~~text
Dos imágenes que un equipo llamaría «la de .NET 10» dieron SDK y binarios distintos, y `global.json` lo detectó sin que nadie mirara versiones. No se encontró una recomendación oficial de usar la misma imagen; containers.dev presenta la especificación también como ayuda a la CI [B138] y mantiene una acción que corre la CI dentro del devcontainer [B134]. **[criterio]** Hace falta **compartir la base que trae el toolchain** y que el repo verifique la coincidencia: la CI dentro del devcontainer preconstruido (stacks simples) o la imagen de desarrollo `FROM` el mismo `sdk@sha256` de la CI, con herramientas agregadas (multi-runtime, §11); no imágenes elegidas por un nombre parecido.
~~~~

9. Reemplazar la línea que empieza con «Experimentos del capítulo: E5-1 (» (hoy:)

~~~~text
Experimentos del capítulo: E5-1 (qué fija y qué no), E5-2 (etiqueta movida, mismo SDK, otro OpenSSL), E5-3 (clon «Windows» en Linux), E5-4 (UID en bind mount), E5-5 y E5-5b (devcontainer por digest, lock de *features*, defaults de la CLI), E5-6 (imagen dev frente a CI), E5-7 (llaves en `.gitattributes`).
~~~~

por

~~~~text
Experimentos del capítulo: E5-1 a E5-7 y E5-5b (Anexo E).
~~~~


### P-11 · §9 Procedencia: §9.2.4 comprimido para 8b, `builder-id`, `npm pack`, ESC-04, contextos, `GITHUB_ENV`, rótulo y Práctica

- **Hallazgos**: C2-15, C2-16, C2-45, C2-23, C2-54, C2-26, C2-39, C2-14, C2-32, C2-50, C2-37.
- **Sección**: §9.2.4 L1634–L1665; §9.3 L1672; §9.4 L1683, L1686; §9.5 L1702–L1716; §9.6 L1731; §9.7 L1761; §9.9.2 L1770.
- **Capa de origen**: guía + N6 (P-22). **Costo**: medio. **Reversible**: sí. **Δ palabras**: prosa -167, evidencia y plantillas +37.
- **Verificación**: `awk '/^#### 9.2.4/,/^### 9.3/' | wc -w` → 604, de las que 5 son el encabezado de §9.3: ≤ 600 (antes 931); la tabla de plataformas pasa intacta a §9.3; conserva [B05] [B07] [B08] [B09] [B10] [B11] [B148] [B154] [B158] [B159] [B160] [B161] [B162] [B163] [B165] [B197] y agrega [B208]; `grep -c 'cómo completarlo en BuildKit no se verificó'` → 0; `grep -c '^export SOURCE_DATE_EPOCH'` → 1 (dentro de un script) y `GITHUB_ENV` en §9.5; `grep -oi ilustrativ` → 4 (antes 2); los enlaces a `#924-procedencia-slsa-y-firma` siguen resolviendo (el encabezado no cambia).

1. Reemplazar el rango que va desde «#### 9.2.4 Procedencia SLSA y firma» (incluido; ⏎ = salto de línea) hasta justo antes de «### 9.3 Qué propone la industria» por:

~~~~text
#### 9.2.4 Procedencia SLSA y firma

**[criterio] Para el caso** (repositorio privado, equipo chico, artefactos internos), la tercera pregunta se contesta con el **registro del entorno** y el SBOM que la CI graba junto al artefacto (§3.4, §9.6, A.17). Lo que sigue es para el paso 8b de §12 (consumidor externo que verifique, requisito contractual o repositorio público).

La versión aprobada de SLSA es la **v1.2** [B05]; agrega un *Source Track* y no enumera cambios al Build Track [B11]. Niveles del Build Track [B07]:

| Nivel | Exige | Protege contra |
|---|---|---|
| L1 | La plataforma genera automáticamente la procedencia (puede ser sin firma) | Errores de proceso; habilita inventario |
| L2 | L1 + plataforma **alojada** que **genera y firma** | Manipulación **después** de la build |
| L3 | L2 + aislamiento entre ejecuciones y secreto de firma inaccesible a los pasos del usuario | Manipulación **durante** la build |

Ningún nivel exige builds reproducibles, candidatas a un futuro L4 [B07][B08]. El `builder.id` es «el único determinante» del nivel, y el consumidor acepta sólo pares firmante/`builder.id` conocidos [B09].

**Una procedencia real (E6-5).** BuildKit la genera en formato in-toto [B160] con un builder `docker-container` o el almacén de containerd, predeterminado en Docker Engine 29 [B162] (el driver `docker` sobre el almacén clásico la rechaza). Para la DLL construida `FROM` el SDK por digest trae `predicateType=https://slsa.dev/provenance/v1`, `subject` con los sha256 de DLL y PDB, **la imagen del SDK por digest** en `resolvedDependencies`, el commit en `vcs:revision` y `builder.id` **vacío**, que no alcanza L1. Lo completa el parámetro `builder-id=` de `--provenance` [B208], con el valor que escribe quien invoca la build: identifica a la plataforma sólo junto al firmante. La DLL salió idéntica a la de otra build independiente. El default de BuildKit pasó de SLSA v0.2 a v1 en la v0.28.0 [B161], aunque la página de Docker todavía dice v0.2 [B160]: **[criterio]** pedir `--provenance=mode=max,version=v1`.

**La firma.** Sin firma, la procedencia es un JSON: E6-5 cambió `builder.id` y siguió válida. Firmada con cosign (DSSE [B163]): el original da `Verified OK`; con un byte más en el artefacto, `provided artifact digests do not match digests in statement`; con el predicado editado, `accepted signatures do not match threshold`. **[criterio]** Una clave de la CI usada por un paso del pipeline **no** es L2, que pide que firme la plataforma: a lo sumo, L1 firmado por un inquilino. `verify-blob-attestation` comprueba firma, `subject` y tipo de predicado, no su contenido (`builder.id`, repositorio, commit): eso pide una política aparte [B10].

Qué ofrece cada plataforma está en §9.3. Sin Enterprise Cloud, las atestaciones nativas de GitHub no están disponibles en un repo privado [B158], y las de npm y PyPI no aplican a paquetes privados. Quedan tres caminos, con su nivel sin inflar:

- **GitLab**: los metadatos del runner más un paso de firma [B159].
- **BuildKit + cosign con clave propia**, en un job aparte que no ejecuta código del PR, detrás de un entorno con aprobación: L1 firmado por un inquilino.
- **cosign sin clave**, con el token OIDC de la CI: certificado efímero de Fulcio atado al workflow y registro en el log público Rekor [B197]; en un repo privado esa identidad queda publicada, salvo con una instancia propia de Sigstore. No se ejercitó **[no verificado]**.

**Dónde se guarda.** SLSA pide publicar las atestaciones en al menos un lugar (junto al release, junto al artefacto o, su hash, en un log de transparencia) y que el consumidor verifique firma, `subject` y parámetros esperados [B10]. **[criterio]** Procedencia y SBOM junto al artefacto, con el mismo nombre base, donde se publica.

~~~~

2. Reemplazar

~~~~text
| `npm pack`: sí, `mtime` fijo **[observado]** |
~~~~

por

~~~~text
| `npm pack`: sí con npm 11.19.0 (E6-3), `mtime` fijo **[observado]** |
~~~~

3. Reemplazar

~~~~text
| ESC-04 Devcontainer | Con la misma imagen por digest que la CI, el lugar natural para reconstruir |
~~~~

por

~~~~text
| ESC-04 Devcontainer | Con la receta de la imagen de CI, el lugar natural para reconstruir |
~~~~

4. Reemplazar

~~~~text
En CTX-POLI (los tres ecosistemas en un repo) aparecen tres SBOM distintos
~~~~

por

~~~~text
Por contexto: en CTX-NET, metadatos del SDK y `ContinuousIntegrationBuild` (§9.2.1); en CTX-NODE, `npm pack`, `npm sbom` y la procedencia de npm (§9.2.2); en CTX-PY, ruedas con `SOURCE_DATE_EPOCH` y PEP 770 (§9.2.2). En CTX-POLI (los tres ecosistemas en un repo) aparecen tres SBOM distintos
~~~~

5. Reemplazar

~~~~text
```sh
# Paso común al principio del job de CI, para los tres ecosistemas.
# La fecha del COMMIT, no la de la build: dos builds del mismo commit incrustan la misma [B03].
export SOURCE_DATE_EPOCH=$(git log -1 --pretty=%ct)
```
~~~~

por

~~~~text
```sh
# Al principio del job de CI, para los tres ecosistemas: la fecha del COMMIT, no la de la build;
# dos builds del mismo commit incrustan la misma [B03]. En GitHub Actions cada run: es un shell
# propio: la variable llega a los pasos siguientes por el archivo GITHUB_ENV [B212].
echo "SOURCE_DATE_EPOCH=$(git log -1 --pretty=%ct)" >> "$GITHUB_ENV"
# Dentro de un mismo script (build.sh), alcanza con export:
export SOURCE_DATE_EPOCH=$(git log -1 --pretty=%ct)
```
~~~~

6. Reemplazar

~~~~text
# Consumidor:  gh attestation verify Pieza.1.4.0.nupkg -R <org>/<repo>
```
~~~~

por

~~~~text
# Consumidor:  gh attestation verify Pieza.1.4.0.nupkg -R <org>/<repo>
```

**Ilustrativo**: no ejecutado (requiere GitHub con repo público o Enterprise Cloud); el SHA de `actions/attest` v4.2.2 se resolvió con `git ls-remote` el 2026-10-09.
~~~~

7. Reemplazar

~~~~text
el 3, y el 4 si nadie lo trae, los agrega el registro del entorno.
~~~~

por

~~~~text
el 3, y el 4 si nadie lo trae, los agrega el registro del entorno (A.17).
~~~~

8. Reemplazar

~~~~text
Señales de una versión pobre: `ContinuousIntegrationBuild` sin condición (rompe la depuración local); `PathMap` a mano; comparar hashes de `.nupkg` en SDK 8 o 10; el SHA embebido como prueba de origen; confundir SBOM con procedencia; llamar procedencia a un JSON sin firma; declarar L2 con una clave propia; declarar L1 con una procedencia sin `builder.id`; dar por verificado el predicado porque `verify-blob-attestation` pasó; contar con atestaciones de GitHub en un repo privado de un plan Team; `npm publish --provenance` en un paquete privado.
~~~~

por

~~~~text
Señales de una versión pobre:

- `ContinuousIntegrationBuild` sin condición, que rompe la depuración local, o `PathMap` a mano (§9.2.1);
- comparar hashes de `.nupkg` en SDK 8 o 10 (§9.2.1);
- el SHA embebido como prueba de origen (§9.2.1);
- confundir SBOM con procedencia (§9.2.3);
- llamar procedencia a un JSON sin firma, declarar L2 con una clave propia o L1 con una procedencia sin `builder.id` (§9.2.4);
- dar por verificado el predicado porque `verify-blob-attestation` pasó (§9.2.4);
- contar con atestaciones de GitHub en un repo privado de un plan Team, o `npm publish --provenance` en un paquete privado (§9.2.4).
~~~~

9. Reemplazar

~~~~text
*Respuesta esperada*: trae el digest del artefacto, el commit y la imagen del SDK por digest; faltan la identidad de la plataforma (`builder.id` vacío) y el toolchain efectivo como dato propio.
~~~~

por

~~~~text
*Respuesta esperada*: trae (1) el digest del artefacto, (2) el commit, sin decir si el árbol estaba limpio, y (4) la imagen del SDK por digest; (5) aparece como SBOM de la imagen, con 2 paquetes, y hay que juzgar si ese alcance cubre el grafo; de (6) trae el cuándo (`startedOn`) y no el quién (`builder.id` vacío); falta (3), el toolchain efectivo como dato propio.
~~~~

10. Reemplazar la línea que empieza con «Experimentos del capítulo: E6-1 (» (hoy:)

~~~~text
Experimentos del capítulo: E6-1 (metadatos que graba el SDK y cuándo mienten), E6-2 y E6-2b (determinismo de DLL, PDB y `.nupkg`; SDK 11), E6-3 (`npm pack` y `npm sbom`), E6-4 (ruedas de Python, `SOURCE_DATE_EPOCH`, SBOM PEP 770), E6-5 (procedencia de BuildKit, reconstrucción, firma y verificación), E6-6 (SBOM .NET con CycloneDX y `sbom-tool`).
~~~~

por

~~~~text
Experimentos del capítulo: E6-1 a E6-6 y E6-2b (Anexo E).
~~~~

11. Reemplazar la línea que empieza con «`package.json` tiene `repository` con `url` y `directory` [B63];» (hoy:)

~~~~text
`package.json` tiene `repository` con `url` y `directory` [B63]; no hay un campo estándar para el SHA dentro del tarball, y `package-lock.json` nunca se publica [B63]: el grafo viaja en el SBOM o en la procedencia. **Con npm 11.19.0, `npm pack` dio el mismo tarball** desde dos rutas con fechas de archivo distintas: las dos entradas del paquete de prueba llevan `mtime` fijo 1985-10-26T08:15:00Z (E6-3) **[observado]**; no se probaron otro usuario, otro *umask* ni otra versión de npm; su documentación no lo menciona [B150], así que conviene que la compuerta lo **compruebe**. `npm publish --provenance` genera procedencia firmada con Sigstore, pero **sólo** desde GitHub Actions o GitLab con runners en la nube y con `repository` público [B148]: para un paquete privado de una organización no aplica tal cual.
~~~~

por

~~~~text
`package.json` tiene `repository` con `url` y `directory` [B63]; no hay campo estándar para el SHA en el tarball, y `package-lock.json` nunca se publica [B63]: el grafo viaja en el SBOM o en la procedencia. **Con npm 11.19.0, `npm pack` dio el mismo tarball** desde dos rutas con fechas de archivo distintas, con `mtime` fijo 1985-10-26T08:15:00Z en las dos entradas del paquete de prueba (E6-3) **[observado]**; no se probaron otro usuario, otro *umask* ni otra versión, y su documentación no lo menciona [B150]: conviene que la compuerta lo **compruebe**. `npm publish --provenance` firma con Sigstore **sólo** desde GitHub Actions o GitLab con runners en la nube y `repository` público [B148]: no aplica tal cual a un paquete privado.
~~~~

12. Reemplazar la línea que empieza con «En Python, los metadatos núcleo no tienen campo para el commit [B72];» (hoy:)

~~~~text
En Python, los metadatos núcleo no tienen campo para el commit [B72]; una versión local PEP 440 (`1.4.0+g9e618f9`) sirve en índices privados pero PyPI no debe aceptarla [B106]; `direct_url.json` registra el commit cuando se instala desde un VCS, pero describe la instalación, no la construcción [B153]. setuptools 84 dio ruedas **distintas** sin `SOURCE_DATE_EPOCH` e **idénticas** con ella; hatchling es reproducible por defecto [B152] (E6-4). PEP 770 reserva `.dist-info/sboms/` para SBOM dentro de la rueda [B151]; pero un SBOM con `timestamp` y `serialNumber` vuelve no reproducible la rueda que lo contiene (E6-4); `cyclonedx-py --output-reproducible` lo evita. **[criterio]** Todo lo que se incrusta en el artefacto tiene que ser reproducible; un SBOM con fecha viaja **al lado**. PyPI acepta atestaciones (PEP 740) firmadas por un proveedor de *Trusted Publishing* [B154].
~~~~

por

~~~~text
En Python, los metadatos núcleo no tienen campo para el commit [B72]; una versión local PEP 440 (`1.4.0+g9e618f9`) sirve en índices privados pero PyPI no debe aceptarla [B106]; `direct_url.json` registra el commit de una instalación desde un VCS, no de la construcción [B153]. setuptools 84 dio ruedas **distintas** sin `SOURCE_DATE_EPOCH` e **idénticas** con ella; hatchling es reproducible por defecto [B152] (E6-4). PEP 770 reserva `.dist-info/sboms/` para el SBOM [B151], pero uno con `timestamp` y `serialNumber` vuelve no reproducible la rueda (E6-4), salvo con `cyclonedx-py --output-reproducible`. **[criterio]** Lo incrustado tiene que ser reproducible; un SBOM con fecha viaja **al lado**. PyPI acepta atestaciones (PEP 740) firmadas por un proveedor de *Trusted Publishing* [B154].
~~~~

13. Reemplazar

~~~~text
| Procedencia en el registro | *Trusted Publishing* sin atestaciones documentadas [B165] | `--provenance` [B148] | PEP 740 [B154] | atestación en la imagen [B160] |
~~~~

por

~~~~text
| Procedencia en el registro | *Trusted Publishing* sin atestaciones documentadas [B165] | `--provenance` [B148] | PEP 740 [B154] | atestación en la imagen [B160] |

Procedencia firmada por plataforma, para el paso 8b (§9.2.4):

| Plataforma | Mecanismo | Nivel | Restricción |
|---|---|---|---|
| GitHub Actions | `actions/attest@v4`, permisos `id-token: write` y `attestations: write`; `gh attestation verify` [B158] | L2 por sí sola; L3 con *reusable workflows* [B158] | En planes Free, Pro y Team, sólo repos **públicos**; privados o internos requieren Enterprise Cloud [B158] |
| GitLab CI/CD | `RUNNER_GENERATE_ARTIFACTS_METADATA=true`: in-toto con predicado SLSA [B159] | L2 con firma por componente; L3 con aislamiento del runner [B159] | La firma es un paso adicional |
| npm | `npm publish --provenance` [B148] | Sigstore + log público | Repo público, runners en la nube |
| PyPI | PEP 740 vía *Trusted Publishing* [B154] | in-toto + SLSA | Proveedores admitidos por PyPI |
| nuget.org | *Trusted Publishing* por OIDC [B165] | — | Su documentación no describe atestaciones de procedencia **[no verificado]** (como ausencia) |
~~~~

14. Reemplazar la línea que empieza con «Desde el SDK 8, Source Link viene incluido» (hoy:)

~~~~text
Desde el SDK 8, Source Link viene incluido y el SHA del commit se agrega a `InformationalVersion` en todas las builds [B142][B143]. E6-1 lo muestra con un `dotnet pack`: `AssemblyInformationalVersion = 1.4.0+9e618f99…`, la URL del repo como `AssemblyMetadata`, el mapa de Source Link en el PDB y `<repository type="git" url="…" commit="…" />` en el `.nuspec` y el `.snupkg` (con `PublishRepositoryUrl=true`). El SDK **no** registra con qué SDK, imagen ni máquina se compiló; se puede agregar como `AssemblyMetadata` (`$(NETCoreSdkVersion)` y un digest que pase la CI), útil para diagnóstico, no como prueba. Y el SHA embebido **miente** con cambios sin commitear: en E6-1, modificar `Program.cs` sin commitear cambió la DLL y la versión informativa siguió diciendo el mismo SHA. En una estación, ese SHA es una pista.
~~~~

por

~~~~text
Desde el SDK 8, Source Link viene incluido y el SHA del commit se agrega a `InformationalVersion` en todas las builds [B142][B143]. E6-1 lo muestra con `dotnet pack`: `AssemblyInformationalVersion = 1.4.0+9e618f99…`, la URL del repo como `AssemblyMetadata`, el mapa de Source Link en el PDB y `<repository type="git" url="…" commit="…" />` en el `.nuspec` y el `.snupkg` (con `PublishRepositoryUrl=true`). El SDK **no** registra con qué SDK, imagen ni máquina se compiló; agregarlo como `AssemblyMetadata` (`$(NETCoreSdkVersion)` y un digest que pase la CI) sirve para diagnóstico, no como prueba. Y el SHA embebido **miente** con cambios sin commitear: en E6-1, un `Program.cs` modificado cambió la DLL con el mismo SHA. En una estación, es una pista.
~~~~

15. Reemplazar la línea que empieza con «**Build determinista.** El compilador de C#» (hoy:)

~~~~text
**Build determinista.** El compilador de C# es determinista por defecto, pero sus entradas incluyen la ruta del directorio actual, la versión del compilador y los datos de Source Link [B18]. `ContinuousIntegrationBuild=true` habilita `DeterministicSourcePaths`, que mapea las rutas a valores independientes de dónde está el código; la build totalmente determinista se activa con `Deterministic` y `ContinuousIntegrationBuild` juntos, y las raíces que se mapean son los ítems `SourceRoot` que aporta un repo git [B143][B144]. Microsoft lo condiciona a la CI porque en una estación el depurador deja de encontrar los fuentes locales [B144]. E6-2 compiló dos clones del mismo commit en rutas distintas:
~~~~

por

~~~~text
**Build determinista.** El compilador de C# es determinista por defecto, pero entre sus entradas están la ruta del directorio actual, la versión del compilador y los datos de Source Link [B18]. `ContinuousIntegrationBuild=true` habilita `DeterministicSourcePaths`, que mapea las rutas a valores independientes de dónde está el código; la build totalmente determinista pide `Deterministic` y `ContinuousIntegrationBuild` juntos, y las raíces mapeadas son los `SourceRoot` que aporta un repo git [B143][B144]. Microsoft lo condiciona a la CI porque en una estación el depurador deja de encontrar los fuentes [B144]. E6-2 compiló dos clones del mismo commit en rutas distintas:
~~~~

16. Reemplazar la línea que empieza con «**El `.nupkg` no es la DLL.**» (hoy:)

~~~~text
**El `.nupkg` no es la DLL.** Con DLL y PDB idénticos, el `.nupkg` salió distinto: el zip guarda las fechas del disco y un archivo `<GUID>.psmdcp` de nombre aleatorio (E6-2). NuGet documenta que **desde .NET 11** los paquetes son deterministas por defecto, salvo las fechas, que se fijan con `DeterministicTimestamp` o `SOURCE_DATE_EPOCH` [B147]. E6-2 y E6-2b lo confirman: con SDK 8 y la variable, distinto; con SDK 11 (preview.7 y RC1, la última publicada al 2026-10-07 [B62]) y la variable, idéntico. **[criterio]** En SDK 8 o 10 se compara **por contenido** (DLL, PDB, `.nuspec`), no por el hash del zip.
~~~~

por

~~~~text
**El `.nupkg` no es la DLL.** Con DLL y PDB idénticos, el `.nupkg` salió distinto: el zip guarda las fechas del disco y un `<GUID>.psmdcp` de nombre aleatorio (E6-2). **Desde .NET 11** los paquetes son deterministas por defecto, salvo las fechas, que se fijan con `DeterministicTimestamp` o `SOURCE_DATE_EPOCH` [B147]: con SDK 8 y la variable, distinto; con SDK 11 (preview.7 y RC1, la última publicada al 2026-10-07 [B62]) y la variable, idéntico (E6-2, E6-2b). **[criterio]** En SDK 8 o 10 se compara **por contenido** (DLL, PDB, `.nuspec`), no por el hash del zip.
~~~~

17. Reemplazar la línea que empieza con «CISA y agencias coautoras publicaron el 2026-07-29» (hoy:)

~~~~text
CISA y agencias coautoras publicaron el 2026-07-29 los «2026 Minimum Elements for a SBOM», que reemplazan a los de 2021 y agregan el **contexto de generación**: en qué fase se generó el SBOM, porque el contenido cambia según la fase [B157]. **[criterio]** Un SBOM del lock (antes de la build) dice lo que se **declaró**; uno de la salida (después), lo que se **entregó** (E6-6: `dotnet-CycloneDX` lista el paquete NuGet; `sbom-tool` lista además los archivos de salida con hash).
~~~~

por

~~~~text
CISA y agencias coautoras publicaron el 2026-07-29 los «2026 Minimum Elements for a SBOM», que reemplazan a los de 2021 y agregan el **contexto de generación**: la fase en que se generó, porque el contenido cambia según ella [B157]. **[criterio]** Un SBOM del lock (antes de la build) dice lo **declarado**; uno de la salida (después), lo **entregado** (E6-6: `dotnet-CycloneDX` lista el paquete NuGet; `sbom-tool`, además los archivos de salida con hash).
~~~~


### P-12 · §10 Compuertas: compuerta propia con descubrimiento y `requested` = `resolved`, alcance de `--staged`, qué no impide, ESC-04, pre-commit, Práctica, mapa y señales

- **Hallazgos**: C2-05, C2-06, C2-07, C2-03, C2-09, C2-19, C2-20, C2-44, C2-23, C2-25, C2-54, C2-37, C2-32, C2-38, C2-50, C2-35.
- **Sección**: §10.2 diagrama L1819; §10.2.2 L1845–L1849; §10.2.5 L1870; §10.2.7 L1904–L1910; §10.2.8 L1923; §10.4 L1938–L1944; §10.5 L1958; §10.7 L2025; §10.9 L2034.
- **Capa de origen**: guía + N7 (P-22) + laboratorio (P-23). **Costo**: alto. **Reversible**: sí. **Δ palabras**: prosa -34, evidencia y plantillas +21.
- **Verificación**: EA-1 paso 8 (P-23 L3), en la imagen de A.10: plantillas → `resultado=VERDE` con `toolchain Python: 3.12.15 cumple tools/gen/.python-version` y `grafo npm: … web/package-lock.json`; `.cs` cp1252 en `src/App/` → `¿cp1252?` y ROJO; imagen sin el paquete → `falta el paquete EditorConfig`; regresión de N7 con la compuerta nueva: E7-01, E7-03 y E7-07 (Node y Python) con veredictos y códigos iguales a las salidas versionadas (evidencia-auditor/x3-regresion-n7/salida.txt). `grep -c 'mismo diseño'` → 0; `grep -c 'minimum_pre_commit_version'` → 1; el bloque de §10.5 corre con pre-commit 4.4.0 (E1 de `Informe-desarrollador.md`, desarrollador-04); [B214] definida y citada; la fila de GitHub de §10.2.7 ya no cita [B186].

1. Reemplazar

~~~~text
    CI -->|registro de entorno| N6["§9 procedencia"]
~~~~

por

~~~~text
    CI -->|registro del entorno| N6["§9 procedencia"]
~~~~

2. Reemplazar

~~~~text
| grafo | los tres locks | `dotnet restore --locked-mode`, `npm ci`, `uv lock --check` | `NU1004`, `NU1403`, `EUSAGE`, «needs to be updated» |
~~~~

por

~~~~text
| grafo | los tres locks, donde estén | `dotnet restore --locked-mode` y `requested` = `resolved`, `npm ci`, `uv lock --check` | `NU1004`, `NU1403`, `pide [8.0.2, ) y resolvió 9.0.0`, `EUSAGE`, «needs to be updated» |
~~~~

3. Reemplazar

~~~~text
que sirve a la vez de registro de entorno para §9. Tres alcances: `--staged` (hook), `--base origin/main` (PR), sin argumentos (`main`, servidor, publicación).
~~~~

por

~~~~text
que sirve a la vez de registro del entorno para §9. Tres alcances: `--staged` (hook), `--base origin/main` (PR), sin argumentos (`main`, servidor, publicación). El alcance acota sólo el texto: toolchain y grafo miran el disco, y un lock modificado sin marcar pasa el hook y la CI lo rechaza (`NU1004`; git 2.39.5, SDK 8.0.425 **[observado]**).
~~~~

4. Reemplazar el rango que va desde «**Alcance declarado.** La compuerta de `Examples/N7-compuertas-y-gobierno/compuerta/` busca cada archivo **en la raíz** del repo:» (incluido; ⏎ = salto de línea) hasta justo antes de «#### 10.2.3 Hooks locales y frameworks de hooks» por:

~~~~text
**Alcance declarado.** La compuerta de A.11 busca `global.json` y `.nvmrc` en la raíz, y los `.python-version` y los locks en todo lo versionado (`git ls-files`): sirve con los proyectos en la raíz (E7-1, E7-7) o en subcarpetas, como recomienda §11.2.3 (EA-1); un manifiesto sin lock queda para la revisión. «Compuerta única» es un solo programa por repositorio: `verificar.sh` (N8) es la de la solución de referencia, con sus rutas escritas, y no se copia. Y **una herramienta que falta no es una violación**: la compuerta dice «falta `python3`» o «falta el paquete EditorConfig», para que nadie apague el hook por un falso rojo.

~~~~

5. Reemplazar

~~~~text
| `Dockerfile`, `devcontainer.json` y su lock | ¿Sigue por digest? ¿El SDK de la imagen coincide con `global.json`? | §8 |
~~~~

por

~~~~text
| `Dockerfile`, `devcontainer.json` y su lock | ¿Lo que construye artefactos publicados sigue por digest? ¿El devcontainer usa etiqueta fija o la receta de la CI, y su SDK coincide con `global.json`? | §8.2.2 |
~~~~

6. Reemplazar

~~~~text
a los administradores, salvo que se los incluya [B177] | [B177][B186][B200] |
~~~~

por

~~~~text
a los administradores, salvo que se los incluya [B177]; un estado con el mismo nombre publicado por otra fuente, si no se fijó la app esperada [B177] | [B177][B200] |
~~~~

7. Reemplazar

~~~~text
| Un MR que edita `.gitlab-ci.yml` o la compuerta, si la aprobación de dueños no es obligatoria (Premium/Ultimate) | [B185][B199] |
~~~~

por

~~~~text
| Un MR que edita `.gitlab-ci.yml` o la compuerta, si la aprobación de dueños no es obligatoria (Premium/Ultimate) | [B185][B199] |
| Validación de build obligatoria (Azure DevOps) | Completar el PR sin una build exitosa | A quien tiene permiso de *bypass* | [B186] |
~~~~

8. Reemplazar

~~~~text
| Nada mientras el hook corra en el servidor; su tiempo está acotado en GHES (abajo) | E7-5, [B175] |
~~~~

por

~~~~text
| A quien puede deshabilitarlo: el administrador del servidor y, en GHES, los de organización o repositorio si se les delegó [B214]; su tiempo está acotado en GHES (abajo) | E7-5, [B175][B214] |
~~~~

9. Reemplazar

~~~~text
lo empujó y los administradores están incluidos en la regla [B177].
~~~~

por

~~~~text
lo empujó, los administradores están incluidos en la regla y el chequeo exige como fuente la app de GitHub Actions [B177].
~~~~

10. Reemplazar

~~~~text
(GitHub permite a los administradores saltear la protección salvo que se configure lo contrario [B177]) y cómo queda registrado su uso.
~~~~

por

~~~~text
(GitHub permite a los administradores saltear la protección salvo que se configure lo contrario [B177]; en GHES, quien puede deshabilitar un `pre-receive` [B214]) y cómo queda registrado su uso.
~~~~

11. Reemplazar

~~~~text
| El hook de A.11 necesita en la estación `bash` (el de Git for Windows), `python3` con el paquete `EditorConfig==0.17.1` y los dos archivos de la compuerta en `tools/ci/`; para los pasos de toolchain y grafo, las herramientas que el repo declara. A mano, desde Git Bash en la raíz del clon: `bash tools/ci/compuerta.sh` **[no verificado]** (requiere Windows). La integración de git de Visual Studio con `core.hooksPath` **[no verificado]** (requiere Windows). Es donde el problema del caso no se ve: la CI en Linux lo revela. |
~~~~

por

~~~~text
| El hook necesita los prerrequisitos de A.11; a mano, desde Git Bash en la raíz: `bash tools/ci/compuerta.sh` **[no verificado]** (requiere Windows), igual que la integración de git de Visual Studio con `core.hooksPath`. El problema del caso no se ve acá: la CI en Linux lo revela. |
~~~~

12. Reemplazar

~~~~text
| Con la misma imagen que la CI, el hook da el veredicto de la CI; `postCreateCommand` puede activar el hook **[criterio]**. |
~~~~

por

~~~~text
| Con la misma imagen que la CI, el hook da el veredicto de la CI sobre lo que está en disco (`--staged` acota sólo el texto, §10.2.2); `postCreateCommand` activa el hook (A.9) **[criterio]**. |
~~~~

13. Reemplazar

~~~~text
| ESC-05 CI | Árbitro; registro de entorno para §9 |
~~~~

por

~~~~text
| ESC-05 CI | Árbitro; registro del entorno para §9 |
~~~~

14. Reemplazar

~~~~text
En CTX-POLI (los tres ecosistemas en un repo) la compuerta corre sus tres pasos para los tres ecosistemas a la vez, sobre el inventario de proyectos de §10.2.2;
~~~~

por

~~~~text
Por contexto, la misma compuerta corre los pasos cuyos archivos existen y deja `n/a` los demás (E7-1, E7-7); en CTX-POLI (los tres ecosistemas en un repo) corre sus tres pasos para los tres a la vez, sobre los proyectos que encuentra (§10.2.2);
~~~~

15. Reemplazar

~~~~text
# y packages.lock.json; .ps1, package-lock.json y uv.lock se agregan por la misma regla.
repos:
~~~~

por

~~~~text
# y packages.lock.json; .ps1, package-lock.json y uv.lock se agregan por la misma regla.
minimum_pre_commit_version: "4.4.0"     # "unsupported" no existe en versiones viejas
repos:
~~~~

16. Reemplazar

~~~~text
Señales de una versión pobre: el hook como única defensa; lógica distinta en hook y CI; hooks genéricos de BOM sin cruzar con `.editorconfig`; `dotnet restore` o `npm install` en la CI; `global.json` subido sin mover la imagen; un lock que cambió sin su manifiesto aprobado sin preguntar; un diff de línea entera aceptado sin mirar si sólo cambió el BOM; documentar «la CI bloquea el merge» sin protección de rama; acciones por etiqueta móvil mientras se exige digest en la imagen; un bot sin agrupación ni enfriamiento decidido; ningún ADR que explique por qué `rollForward` es `disable`; la compuerta dice `n/a` para un archivo que existe en una subcarpeta; la compuerta informa «violación» cuando lo que falta es una herramienta; documentar que la rama protegida «impide» sin decir qué no impide.
~~~~

por

~~~~text
Señales de una versión pobre, por quién las ve:

- **En la compuerta**: el hook como única defensa (§10.2.3); lógica distinta en hook y CI (§10.2.2); hooks genéricos de BOM sin cruzar con `.editorconfig` (§10.2.3); `dotnet restore` o `npm install` en la CI (§10.2.4); `n/a` para un archivo que existe en una subcarpeta, o «violación» cuando falta una herramienta (§10.2.2).
- **En la revisión**: `global.json` subido sin mover la imagen (§10.2.6); un lock que cambió sin su manifiesto aprobado sin preguntar, o un diff de línea entera aceptado sin mirar si sólo cambió el BOM (§10.2.5).
- **En la plataforma y el gobierno**: documentar «la CI bloquea el merge» sin protección de rama, o que la rama protegida «impide» sin decir qué no impide (§10.2.7); acciones por etiqueta móvil mientras se exige digest en la imagen (§10.2.4); un bot sin agrupación ni enfriamiento decidido, o ningún ADR que explique por qué `rollForward` es `disable` (§10.2.6).
~~~~

17. Reemplazar

~~~~text
2. Con la tabla de §10.2.7, escribí qué impide y qué no impide la configuración de tu plataforma y tu plan, y qué control compensatorio agregás donde no impide nada.
~~~~

por

~~~~text
2. Con la tabla de §10.2.7, escribí qué impide y qué no impide la configuración de tu plataforma y tu plan, y qué control compensatorio agregás donde no impide nada. *Criterio de corrección*: cada fila dice «impide» o «sólo avisa» en tu plan, qué no impide y su control compensatorio.

**Volver al mapa.** Releé §3.3 desde «Qué deja libre», y §3.5: para cada fila, nombrá el experimento que lo mostró; si no podés, volvé a su capítulo.
~~~~

18. Reemplazar la línea que empieza con «pre-commit (pre-commit.com) es un framework» (hoy:)

~~~~text
pre-commit (pre-commit.com) es un framework de hooks multi-lenguaje, vigente en 4.6.2; el lenguaje para hooks locales que usan un ejecutable del sistema pasó a llamarse `unsupported` (antes `system`) [B180]. Sus hooks genéricos de texto traen una política propia: E7-2 copió los «de manual» en un repo .NET con la política de §5 y encontró dos conflictos reales. `fix-byte-order-marker` quitó el BOM de un `.razor` que la política exige con BOM [B52]; `end-of-file-fixer` agregó un salto final a `packages.lock.json`, que NuGet vuelve a quitar en la siguiente regeneración: una ida y vuelta permanente de diffs sin contenido. **[criterio]** Un framework de hooks es un buen **orquestador** (instala, fija versiones, corre en paralelo); la política de texto la hace cumplir un chequeo que **lee** `.editorconfig`, y los hooks genéricos se recortan con `exclude` alineados a ella.
~~~~

por

~~~~text
pre-commit es un framework de hooks multi-lenguaje, vigente en 4.6.2; el lenguaje de los hooks locales que usan un ejecutable del sistema se llama `unsupported` (antes `system`) desde la 4.4 [B180]. Sus hooks genéricos de texto traen una política propia: en E7-2, sobre un repo .NET con la política de §5, `fix-byte-order-marker` quitó el BOM de un `.razor` que la política exige [B52], y `end-of-file-fixer` agregó a `packages.lock.json` un salto final que NuGet vuelve a quitar: diffs sin contenido de ida y vuelta. **[criterio]** Un framework de hooks es un buen **orquestador** (instala, fija versiones, corre en paralelo); la política la hace cumplir un chequeo que **lee** `.editorconfig`, y los hooks genéricos se recortan con `exclude` alineados a ella.
~~~~

19. Reemplazar la línea que empieza con «Experimentos del capítulo: E7-1 (» (hoy:)

~~~~text
Experimentos del capítulo: E7-1 (misma compuerta en hook y CI; hook no activo tras clonar; `--no-verify`), E7-2 (hooks genéricos contra la política), E7-3 (lista del revisor; cambio invisible de BOM; `NU1403`; SDK sin imagen), E7-4 (descongelar paquete y SDK), E7-5 y E7-5b (sin protección de rama; `publicar.sh`; `pre-receive`; tiempo de la compuerta), E7-6 (esquemas de `dependabot.yml` y `renovate.json`), E7-7 (misma compuerta en Node y Python).
~~~~

por

~~~~text
Experimentos del capítulo: E7-1 a E7-7 y E7-5b (Anexo E).
~~~~

20. Reemplazar la línea que empieza con «Los cambios invisibles necesitan una herramienta:» (hoy:)

~~~~text
Los cambios invisibles necesitan una herramienta: en E7-3 un IDE guardó un `.cs` con BOM; la web muestra la línea entera cambiada con el texto idéntico. El asistente del laboratorio (`Examples/N7-compuertas-y-gobierno/03-revisor-cambios-de-entorno/cambios-de-entorno.py`) normaliza y reporta `Program.cs: mismo texto; cambia sólo ['BOM']`, y la compuerta lo rechaza. **El revisor no tiene que encontrarlo a ojo: tiene que decidir si es la normalización acordada.** `CODEOWNERS` asigna los archivos de entorno a quien corresponde; su aprobación es obligatoria sólo con protección de rama, y en GitLab requiere Premium o Ultimate [B178][B185].
~~~~

por

~~~~text
Los cambios invisibles necesitan una herramienta: en E7-3 un IDE guardó un `.cs` con BOM y la web muestra la línea entera cambiada con el texto idéntico; `Examples/N7-compuertas-y-gobierno/03-revisor-cambios-de-entorno/cambios-de-entorno.py` normaliza y reporta `Program.cs: mismo texto; cambia sólo ['BOM']`, y la compuerta lo rechaza. **El revisor no lo busca a ojo: decide si es la normalización acordada.** `CODEOWNERS` asigna los archivos de entorno; su aprobación es obligatoria sólo con protección de rama, y en GitLab requiere Premium o Ultimate [B178][B185].
~~~~

21. Reemplazar la línea que empieza con «**Bots.** Automatizan la **propuesta**, no la decisión.» (hoy:)

~~~~text
**Bots.** Automatizan la **propuesta**, no la decisión. Dependabot soporta `dotnet-sdk` (para `global.json`), `nuget`, `npm`, `uv`, `pip`, `docker`, `devcontainers`, `github-actions` y `pre-commit`; ofrece `groups` y `cooldown`, aplica por defecto 3 días de enfriamiento a las actualizaciones de versión y no abre más de cinco PR a la vez [B182]; su tabla declara versiones máximas de gestor por debajo de las vigentes [B107], y cómo se comporta con versiones más nuevas **[no verificado]**. Microsoft sugiere expresamente Dependabot para el SDK de `global.json` y `CheckSdkVulnerabilities` para que la build avise [B58]. Renovate ofrece `minimumReleaseAge`, `lockFileMaintenance` y `pinDigests` [B108]. **[criterio]** Lo que se gana con un bot es que **cada descongelamiento llega como PR**: pasa por la misma compuerta, el mismo revisor y deja la misma traza; el enfriamiento deja que otros descubran una versión rota o maliciosa antes de adoptarla.
~~~~

por

~~~~text
**Bots.** Automatizan la **propuesta**, no la decisión. Dependabot soporta `dotnet-sdk` (para `global.json`), `nuget`, `npm`, `uv`, `pip`, `docker`, `devcontainers`, `github-actions` y `pre-commit`, con `groups` y `cooldown`; por defecto espera 3 días en las actualizaciones de versión y no abre más de cinco PR a la vez [B182]; su tabla declara versiones máximas de gestor por debajo de las vigentes [B107], y cómo se comporta con las más nuevas **[no verificado]**. Microsoft sugiere Dependabot para el SDK de `global.json` y `CheckSdkVulnerabilities` para que la build avise [B58]. Renovate ofrece `minimumReleaseAge`, `lockFileMaintenance` y `pinDigests` [B108]. **[criterio]** Con un bot, **cada descongelamiento llega como PR**, con la misma compuerta, el mismo revisor y la misma traza; el enfriamiento deja que otros descubran una versión rota o maliciosa antes.
~~~~

22. Reemplazar la línea que empieza con «Tres condiciones observables la convierten en árbitro:» (hoy:)

~~~~text
Tres condiciones observables la convierten en árbitro: **clon limpio** (sin hooks ni configuración local; E7-1 da el mismo diagnóstico que el hook); **la misma imagen** por digest o el toolchain instalado desde los archivos del repo [B181]; y **restauración estricta** (NuGet recomienda `--locked-mode` en CI/CD [B83]). Además, **todo lo que ejecuta la compuerta es parte del entorno**: GitHub indica que fijar una acción a un SHA completo es la única forma de usarla como versión inmutable, documenta políticas que lo exigen, y advierte que Dependabot no genera alertas de vulnerabilidad para acciones fijadas por SHA, aunque sí las actualiza [B183]. Lo mismo vale para el `rev` de pre-commit (SHA, `autoupdate --freeze`) [B180] y para la imagen de CI.
~~~~

por

~~~~text
Tres condiciones observables la convierten en árbitro: **clon limpio** (sin hooks ni configuración local; en E7-1 da el diagnóstico del hook); **la misma imagen** por digest o el toolchain instalado desde los archivos del repo [B181]; y **restauración estricta** (`--locked-mode` en CI/CD, recomienda NuGet [B83]). Y **todo lo que ejecuta la compuerta es parte del entorno**: fijar una acción a un SHA completo es la única forma de usarla como versión inmutable, hay políticas que lo exigen, y Dependabot no da alertas de vulnerabilidad para acciones fijadas por SHA, aunque sí las actualiza [B183]. Vale también para el `rev` de pre-commit (SHA, `autoupdate --freeze`) [B180] y para la imagen de CI.
~~~~

23. Reemplazar la línea que empieza con «En GitHub, las ramas protegidas, los dueños de código requeridos» (hoy:)

~~~~text
En GitHub, las ramas protegidas, los dueños de código requeridos y los *rulesets* están disponibles en repositorios **públicos** con el plan Free y en privados con Pro, que es un plan de cuentas personales, o con Team y Enterprise, los de organizaciones [B176][B177][B179]: para el repositorio de una organización, el mínimo es Team. En GitLab, las ramas protegidas y «Pipelines must succeed» están en Free —la segunda impide fusionar un *merge request* sin una pipeline exitosa, incluido el que no tiene ninguna [B199]—, pero la aprobación obligatoria de dueños es Premium/Ultimate [B185]. En Azure DevOps la validación de build obligatoria decide si el PR se completa, con permisos de *bypass* explícitos [B186].
~~~~

por

~~~~text
En GitHub, las ramas protegidas, los dueños de código requeridos y los *rulesets* están en repositorios **públicos** con Free y en privados con Pro (cuentas personales), Team o Enterprise (organizaciones) [B176][B177][B179]: para una organización, el mínimo es Team. En GitLab, las ramas protegidas y «Pipelines must succeed» están en Free —ésta impide fusionar un *merge request* sin pipeline exitosa, incluso sin ninguna [B199]—, y la aprobación obligatoria de dueños es Premium/Ultimate [B185]. En Azure DevOps la validación de build obligatoria decide si el PR se completa, con permisos de *bypass* explícitos [B186].
~~~~

24. Reemplazar la línea que empieza con «En GitHub Enterprise Server, los `pre-receive` de un repositorio» (hoy:)

~~~~text
En GitHub Enterprise Server, los `pre-receive` de un repositorio comparten un presupuesto acumulado de **5 segundos** y se desaconseja llamar servicios externos [B188]; la compuerta del laboratorio tardó 1,5–2,3 s en un repo de juguete (E7-5b), lo que no se generaliza a un repo real. **[criterio]** Ahí el `pre-receive` corre sólo el paso de texto, rápido y sin red. Renovate advierte que, sin chequeos requeridos, su fusión automática puede fusionar PR con pruebas fallidas [B108]: **sin protección de rama, no se habilita la fusión automática de ningún bot**. Y la recomendación honesta es **declarar el límite**, no escribir que «la CI bloquea» cuando no puede: el costo de un `main` rojo unas horas es bajo; el de una versión publicada desde un estado no verificado, no.
~~~~

por

~~~~text
En GitHub Enterprise Server, los `pre-receive` de un repositorio comparten un presupuesto acumulado de **5 segundos** y se desaconseja llamar servicios externos [B188]; la compuerta del laboratorio tardó 1,5–2,3 s en un repo de juguete (E7-5b), que no se generaliza. **[criterio]** Ahí el `pre-receive` corre sólo el paso de texto, rápido y sin red. Sin chequeos requeridos, la fusión automática de Renovate puede fusionar PR con pruebas fallidas [B108]: **sin protección de rama, ningún bot fusiona solo**. Y lo honesto es **declarar el límite**, no escribir que «la CI bloquea»: un `main` rojo unas horas cuesta poco; una versión publicada desde un estado no verificado, no.
~~~~

25. Reemplazar la línea que empieza con «Si el hook ejecuta una cosa y la CI otra, divergen,» (hoy:)

~~~~text
Si el hook ejecuta una cosa y la CI otra, divergen, y el desarrollador ve verde en su máquina y rojo en el PR sin poder reproducirlo. Las propias herramientas empujan en esa dirección: pre-commit indica correr la misma configuración en la CI [B180], y las acciones de *setup* de GitHub leen la versión de los **mismos** archivos del repo (`global-json-file`, `node-version-file`, `required-version` de uv) [B181]. La compuerta del laboratorio (`Examples/N7-compuertas-y-gobierno/compuerta/compuerta.sh`) tiene tres pasos, cada uno heredado de un capítulo:
~~~~

por

~~~~text
Si el hook ejecuta una cosa y la CI otra, divergen: verde en la máquina y rojo en el PR, sin poder reproducirlo. Las herramientas empujan a lo mismo: pre-commit indica correr su configuración en la CI [B180], y las acciones de *setup* de GitHub leen la versión de los **mismos** archivos del repo (`global-json-file`, `node-version-file`, `required-version` de uv) [B181]. La compuerta del laboratorio (`Examples/N7-compuertas-y-gobierno/compuerta/compuerta.sh`) tiene tres pasos, uno por capítulo:
~~~~

26. Reemplazar la línea que empieza con «El hook `pre-commit` aborta el commit si falla» (hoy:)

~~~~text
El hook `pre-commit` aborta el commit si falla y se saltea con `--no-verify` [B175]. Los hooks viven en `.git/hooks`, que **no se versiona**; `core.hooksPath` apunta git a una carpeta versionada (`.githooks/`), pero cada clon tiene que ejecutar **una vez** `git config core.hooksPath .githooks` [B37][B175]. E7-1 lo muestra en orden: tras clonar, un archivo en cp1252 entra sin aviso; con el hook activo, se rechaza; con `--no-verify`, entra de nuevo. **El hook es para el desarrollador** (el error a los diez segundos y no a los diez minutos en el PR), nunca la única defensa.
~~~~

por

~~~~text
El hook `pre-commit` aborta el commit si falla y se saltea con `--no-verify` [B175]. Vive en `.git/hooks`, que **no se versiona**; `core.hooksPath` apunta git a una carpeta versionada (`.githooks/`), y cada clon ejecuta **una vez** `git config core.hooksPath .githooks` [B37][B175]. En E7-1, tras clonar, un archivo en cp1252 entra sin aviso; con el hook activo, se rechaza; con `--no-verify`, entra. **El hook es para el desarrollador** (el error a los diez segundos y no a los diez minutos en el PR), nunca la única defensa.
~~~~

27. Reemplazar la línea que empieza con «El caso no pide sólo una configuración correcta:» (hoy:)

~~~~text
El caso no pide sólo una configuración correcta: pide «una mecánica» que mantenga el criterio. Los capítulos 5 a 8 dejan el entorno **declarado** en archivos del repositorio; éste se ocupa de que la declaración **se haga cumplir** todos los días y de que cambie sólo cuando alguien lo **decide**. Tres hallazgos lo ordenan: el hook local no es una compuerta sino una comodidad (E7-1); los hooks genéricos pueden contradecir la política del repo (E7-2); y sin protección de rama la CI avisa pero no impide (E7-5).
~~~~

por

~~~~text
El caso pide además «una mecánica» que mantenga el criterio. Los capítulos 5 a 8 dejan el entorno **declarado** en archivos del repositorio; éste se ocupa de que la declaración **se haga cumplir** todos los días y cambie sólo cuando alguien lo **decide**. Tres hallazgos lo ordenan: el hook local es una comodidad, no una compuerta (E7-1); los hooks genéricos pueden contradecir la política del repo (E7-2); y sin protección de rama la CI avisa pero no impide (E7-5).
~~~~


### P-13 · §11 Políglota: alcance de «registro», npm de E8-3, procedencia en tres partes, extracto literal de `verificar.sh`, `version=v1`, Práctica y señales

- **Hallazgos**: C2-35, C2-43, C2-52, C2-21, C2-48, C2-06, C2-27, C2-28, C2-14, C2-32, C2-50, C2-37.
- **Sección**: §11 L2040; §11.2.4 L2115–L2117; §11.2.5 L2127, L2139; §11.2.8 L2183; §11.2.9 L2205, L2212; §11.3 L2232, L2246; §11.5 L2271, L2300–L2327; §11.6 L2343, L2346; §11.7 L2368; §11.8 L2372; §11.9.
- **Capa de origen**: guía + N8 (P-22) + laboratorio (P-23). **Costo**: medio. **Reversible**: sí. **Δ palabras**: prosa -110, evidencia y plantillas +7.
- **Verificación**: `grep -c 'version=v1' ` en §11.5 → 1 y `grep -c 'Este comando no pide'` → 0; `e6-sbom-unificado/comando-de-la-guia.sh` con `,version=v1` da rc=0, `https://slsa.dev/provenance/v1`, `builder.id: ''` y cinco materiales por digest (evidencia-auditor/x5-version-v1/salida.txt); cada línea del extracto de `verificar.sh`, salvo `...`, está en el archivo (`grep -Fxf`); el comentario del `.csproj` de §11.5 es igual al de `solucion/src/Saludo/Saludo.csproj` tras P-23 L5; §11.9 tiene dos consignas; los dos diagramas renderizan (mermaid-cli); `grep -c 'piezas'` en §11 → 0; el ancla nueva de §11.2.4 no tiene enlaces entrantes que romper (`grep -c '#1124-'` → 0 antes del cambio).

1. Reemplazar

~~~~text
Éste junta las piezas en un repositorio
~~~~

por

~~~~text
Éste junta las partes en un repositorio
~~~~

2. Reemplazar

~~~~text
#### 11.2.4 Un lock y un registro por ecosistema
~~~~

por

~~~~text
#### 11.2.4 Un lock y un registro de paquetes por ecosistema
~~~~

3. Reemplazar

~~~~text
(`EBADDEVENGINES` con npm 10.9.8 y 11.19, E8-3)
~~~~

por

~~~~text
(`EBADDEVENGINES` con npm 10.9.8 en E8-3, que corre el npm del `PATH` y no el del Node antepuesto; con npm 11.19, E3-3)
~~~~

4. Reemplazar

~~~~text
| La CI publica el artefacto | B en la CI | Cada ecosistema corre una vez, con su comando estricto, entre la compuerta y el registro |
~~~~

por

~~~~text
| La CI publica el artefacto | B en la CI | Cada ecosistema corre una vez, con su comando estricto, entre la compuerta y el registro del entorno |
~~~~

5. Reemplazar

~~~~text
        NET["dotnet build -p:ConstruirPoliglota=false"]
~~~~

por

~~~~text
        NET["dotnet build<br/>(build.sh: -p:ConstruirPoliglota=false)"]
~~~~

6. Reemplazar

~~~~text
        PRV["procedencia firmada por la plataforma (commit)<br/>o de BuildKit (bases por digest, sin firma)"]
~~~~

por

~~~~text
        PRV["procedencia (§11.2.8): (a) la de la plataforma, firmada<br/>+ (b) materiales del entorno registrados<br/>+ (c) el vínculo firmado entre las dos"]
~~~~

7. Reemplazar

~~~~text
Las estrategias de §11.2 se apoyan en piezas documentadas de cada ecosistema
~~~~

por

~~~~text
Las estrategias de §11.2 se apoyan en mecanismos documentados de cada ecosistema
~~~~

8. Reemplazar

~~~~text
| SBOM | Multi-ecosistema / nativos + unión / BuildKit | Uno de los dos primeros para los locks; BuildKit para procedencia | E8-6 |
~~~~

por

~~~~text
| SBOM y procedencia | Multi-ecosistema / nativos + unión / BuildKit | SBOM de los locks: uno de los dos primeros; procedencia: (a)+(b)+(c) de §11.2.8 con imagen única, y por componente, además, BuildKit `mode=max` como materiales | E8-6 |
~~~~

9. Reemplazar

~~~~text
  <!-- true en la estación (F5); la CI pasa -p:ConstruirPoliglota=false y usa build.sh -->
~~~~

por

~~~~text
  <!-- true en la estación (F5) y en la prueba de regresión de la CI (§11.2.5); build.sh pasa false -->
~~~~

10. Reemplazar

~~~~text
**Compuerta: tres capas, tres ecosistemas** (extracto de `solucion/verificar.sh`):

```bash
echo "== 2. Toolchain: lo instalado contra los archivos NATIVOS del repo"
esperado_sdk=$(python3 -c 'import json;print(json.load(open("global.json"))["sdk"]["version"])')
esperado_node=$(tr -d '[:space:]' < .nvmrc)
esperado_py=$(tr -d '[:space:]' < tools/gen/.python-version)     # donde lo busca uv
# ... comparar con dotnet --version, node -v, uv python find; archivo sin herramienta = rojo
echo "== 3. Restauración estricta: un lock por ecosistema"
dotnet restore src/Saludo --locked-mode
(cd web && npm ci)
(cd tools/gen && uv sync --locked)
```
~~~~

por

~~~~text
**La compuerta propia de la solución de referencia: tres capas, tres ecosistemas, con sus rutas escritas** (extracto de `solucion/verificar.sh`; para otro repositorio, la compuerta de A.11, que encuentra los proyectos donde estén):

```bash
echo "== 2. Toolchain (N3): lo instalado contra los archivos del repo"
esperado_sdk=$(python3 -c 'import json;print(json.load(open("global.json"))["sdk"]["version"])')
esperado_node=$(tr -d '[:space:]' < .nvmrc)
esperado_py=$(tr -d "[:space:]" < tools/gen/.python-version)
...
echo "== 3. Restauración estricta (N4): un lock por ecosistema"
dotnet restore src/Saludo --locked-mode -v q --nologo || fallas=$((fallas+1))
(cd web && npm ci --no-audit --no-fund --loglevel=error) || fallas=$((fallas+1))
(cd tools/gen && uv sync --locked -q) || fallas=$((fallas+1))
```
~~~~

11. Reemplazar

~~~~text
  --provenance=mode=max --sbom=true \
~~~~

por

~~~~text
  --provenance=mode=max,version=v1 --sbom=true \
~~~~

12. Reemplazar

~~~~text
 Este comando no pide `version=v1`: el default de la versión de BuildKit usada ya es v1 (§9.2.4).
~~~~

por

~~~~text

~~~~

13. Reemplazar

~~~~text
Para el entorno, el registro del entorno de la CI y, si la build corre en contenedores, la procedencia de BuildKit,
~~~~

por

~~~~text
Para el entorno, el registro del entorno de la CI y, si la build corre por componentes con BuildKit, su procedencia,
~~~~

14. Reemplazar

~~~~text
fuera de MSBuild para que la CI corra cada ecosistema una vez, en modo estricto, entre la compuerta y el registro.
~~~~

por

~~~~text
fuera de MSBuild para que la CI corra cada ecosistema una vez, en modo estricto, entre la compuerta y el registro del entorno.
~~~~

15. Reemplazar

~~~~text
Señales de una versión pobre: «todo a UTF-8 con BOM»; creer que un `.sh` «anda» porque el paso terminó en verde; `.python-version` en la raíz con el proyecto uv en una subcarpeta; versiones en `mise.toml` además de los nativos; un target de MSBuild con `npm install`; el `.esproj` con sus defaults en CI; asumir que `global.json` fija Node y Python; comandos de bash en un `Exec`; bases por etiqueta; confundir el SBOM del artefacto con el de la build; locks marcados `linguist-generated`; una compuerta que dice `n/a` para los proyectos de las subcarpetas.
~~~~

por

~~~~text
Señales de una versión pobre:

- «todo a UTF-8 con BOM», o creer que un `.sh` «anda» porque el paso terminó en verde (§11.2.1);
- locks marcados `linguist-generated` (§11.2.2);
- `.python-version` en la raíz con el proyecto uv en una subcarpeta, o versiones en `mise.toml` además de los nativos (§11.2.3);
- un target de MSBuild con `npm install`, el `.esproj` con sus defaults en CI o comandos de bash en un `Exec` (§11.2.5);
- asumir que `global.json` fija Node y Python (§11.2.5);
- bases por etiqueta (§11.2.6);
- confundir el SBOM del artefacto con el de la build (§11.2.8);
- una compuerta que dice `n/a` para los proyectos de las subcarpetas (§10.2.2).
~~~~

16. Reemplazar

~~~~text
incluida la imagen multi-runtime de [A.10](#a10-dockerfile-de-la-imagen-multi-runtime), que EA-1 construye, y el devcontainer de A.9, que usa su receta.
~~~~

por

~~~~text
incluida la imagen multi-runtime de [A.10](#a10-dockerfile-de-la-imagen-multi-runtime), que EA-1 construye y donde corre la compuerta completa, el devcontainer de A.9, que usa su receta, y el registro del entorno de A.17. La CI de A.12 corre la compuerta, compila y registra el entorno; el SBOM y la publicación los agrega cada equipo (§9.2.3).
~~~~

17. Reemplazar

~~~~text
1. Copiá la compuerta de N7 (con `check_text_policy.py`) dentro de la solución de N8, corrélas a las dos y explicá cada diferencia. *Respuesta esperada*: la de N7 declara `n/a` el Python, el lock de npm y el de uv, porque los busca en la raíz; `verificar.sh` los encuentra porque tiene las rutas (§10.2.2).
~~~~

por

~~~~text
1. Antes de mirar la columna B de E8-1 («UTF-8 con BOM para todo»), predecí qué lectores fallan. *Respuesta esperada*: cinco —el shebang de `saluda.py`, `json.load`, `tomllib`, `JSON.parse` y la comparación de `.nvmrc`—; `hola.sh` corre, con un error en stderr: el daño silencioso de §4.2.4.
2. Con EA-1, predecí qué paso de la compuerta de A.11 pone en rojo un `.cs` en cp1252 dentro de `src/App/` y qué dice. *Respuesta esperada*: sólo el de texto, con `no es UTF-8 válido (byte 0xc7 …; ¿cp1252?)`; toolchain y grafo siguen en verde, porque la compuerta encuentra los proyectos en sus subcarpetas (§10.2.2).
~~~~

18. Reemplazar la línea que empieza con «La tabla cambia la pregunta del caso.» (hoy:)

~~~~text
La tabla cambia la pregunta del caso. **Lo primero que se rompe no es la compilación de C#, sino lo que un humano no ve**: los scripts con shebang, los parsers estrictos de JSON y TOML, y las comparaciones de texto que escribe el propio equipo. Las herramientas de paquetes (`npm`, `uv`, `dotnet`) toleran el BOM; los lectores genéricos y el kernel, no. Dos «OK» esconden daño: el `.sh` con BOM corre con otro intérprete y sale con 0 si lo lanza un shell, y falla con `Exec format error` si lo lanza `subprocess.run` de Python (§4.2.4); y Node lee el JSON en cp1252 **sin quejarse**, con el byte reemplazado por U+FFFD. Con código heredado, el ecosistema más permisivo es el que más tarde avisa: el caso disparador, en una solución políglota, rompe la compilación de C# en Linux, rompe a Python en el primer `open` estricto y **corrompe en silencio** lo que lee Node.
~~~~

por

~~~~text
La tabla cambia la pregunta del caso. **Lo primero que se rompe no es la compilación de C#, sino lo que un humano no ve**: los scripts con shebang, los parsers estrictos de JSON y TOML, y las comparaciones de texto del propio equipo; las herramientas de paquetes (`npm`, `uv`, `dotnet`) toleran el BOM. Dos «OK» esconden daño: el `.sh` con BOM corre con otro intérprete y sale con 0 si lo lanza un shell (§4.2.4), y Node lee el JSON en cp1252 **sin quejarse**, con U+FFFD. Con código heredado, el ecosistema más permisivo es el que más tarde avisa: el caso rompe a C# en Linux, a Python en el primer `open` estricto y **corrompe en silencio** lo que lee Node.
~~~~

19. Reemplazar la línea que empieza con «**La compuerta es lo que hace «único» al punto de verdad.**» (hoy:)

~~~~text
**La compuerta es lo que hace «único» al punto de verdad.** `verificar.sh` lee los tres archivos y los compara con lo instalado; si alguien sube `.nvmrc` y no reconstruye la imagen, falla con `node esperado 24.21.0, encontrado 22.23.2` (E8-2). Node nunca lo habría detectado solo: no lee `.nvmrc`. **mise y asdf como lectores, no como fuente**: mise 2026.10.3 por defecto no lee los archivos nativos; habilitados, lee los mismos que las herramientas; y si hay un `mise.toml` con `node = "24"`, **gana** y resuelve 24 sin decir que contradice a `.nvmrc` (E8-2) [B79]. Las *features* de devcontainer tampoco los leen: la de .NET usa `latest` por defecto, la de Node `lts`, la de Python `os-provided` [B137]; en una imagen con tres runtimes son tres versiones flotando a la vez si no se fijan y verifican.
~~~~

por

~~~~text
**La compuerta es lo que hace «único» al punto de verdad.** Lee los tres archivos y los compara con lo instalado: si alguien sube `.nvmrc` y no reconstruye la imagen, falla con `node esperado 24.21.0, encontrado 22.23.2` (E8-2, `verificar.sh`); Node no lo habría detectado, porque no lee `.nvmrc`. **mise y asdf, como lectores y no como fuente**: mise 2026.10.3 no lee los archivos nativos salvo que se lo habilite, y un `mise.toml` con `node = "24"` **gana** sin avisar que contradice a `.nvmrc` (E8-2) [B79]. Las *features* de devcontainer tampoco los leen: por defecto, la de .NET usa `latest`, la de Node `lts` y la de Python `os-provided` [B137]: tres versiones flotando si no se fijan y verifican.
~~~~

20. Reemplazar la línea que empieza con «**El proyecto JavaScript de Visual Studio (`.esproj`).**» (hoy:)

~~~~text
**El proyecto JavaScript de Visual Studio (`.esproj`).** Microsoft documenta el JavaScript Project System como la forma de tener proyectos Angular, React o Vue dentro de una solución de Visual Studio, y su referencia dice que en *Build* y *Restore* corre `npm install` (`ShouldRunNpmInstall`, `true` por defecto) y `npm run build` [B169]. E8-4 lo construyó en Linux: con el MSBuild del SDK 8, la versión 1.0.6887863 del SDK de JavaScript **no carga** (queda acoplada a la versión del SDK de .NET; `global.json` tiene una sección `msbuild-sdks` para fijar SDK de proyecto [B56]); con SDK 10 corre `npm install` y, ante un `package.json` que ya no coincide con el lock, **reescribe el lock** y la build termina en verde —exactamente el «regenera en silencio» que §7 prohíbe en verificación—. Con `ShouldRunNpmInstall=false` y un target propio que corre `npm ci` antes del target interno `RunNpmInstall`, la misma deriva falla con `EUSAGE`. El punto de enganche que la documentación sugiere (antes de `BeforeRestore`) no ejecutó `npm ci` en la versión probada, y `RunNpmInstall` es un nombre interno de `Sdk.targets`, no un contrato: hay que revisarlo al subir de versión. En Linux, además, el SDK intenta `cmd.exe` para `npm audit` y deja un directorio llamado literalmente `obj\Debug`.
~~~~

por

~~~~text
**El proyecto JavaScript de Visual Studio (`.esproj`).** Es la forma documentada de tener proyectos Angular, React o Vue en una solución de Visual Studio, y en *Build* y *Restore* corre `npm install` (`ShouldRunNpmInstall`, `true` por defecto) y `npm run build` [B169]. E8-4 lo construyó en Linux: con el MSBuild del SDK 8, la versión 1.0.6887863 del SDK de JavaScript **no carga** (queda acoplada a la versión del SDK de .NET; `global.json` fija SDK de proyecto en `msbuild-sdks` [B56]); con SDK 10 corre `npm install` y, ante un `package.json` que ya no coincide con el lock, **reescribe el lock** con la build en verde: el «regenera en silencio» que §7 prohíbe. Con `ShouldRunNpmInstall=false` y un target propio que corre `npm ci` antes del interno `RunNpmInstall`, la misma deriva falla con `EUSAGE`. El enganche que sugiere la documentación (antes de `BeforeRestore`) no ejecutó `npm ci` en la versión probada, y `RunNpmInstall` es un nombre interno de `Sdk.targets`, no un contrato: se revisa al subir de versión. En Linux, además, el SDK intenta `cmd.exe` para `npm audit` y deja un directorio llamado literalmente `obj\Debug`.
~~~~

21. Reemplazar la línea que empieza con «GitHub Actions ofrece `jobs.<id>.container`» (hoy:)

~~~~text
GitHub Actions ofrece `jobs.<id>.container`, que corre todos los pasos del job en una imagen [B135], y `strategy.matrix`, que crea un job por combinación [B171]. **[criterio]** Imagen única cuando el artefacto es uno: el job corre `./build.sh`, el mismo comando que la estación y el devcontainer. Por componente sólo si los componentes se publican por separado, con una etapa previa que corre la compuerta completa en la imagen única: el Dockerfile por componente del laboratorio sólo corre los comandos estrictos de cada ecosistema, no la compuerta de texto. Matriz cuando hay que probar varias versiones de un runtime o cada componente se publica aparte; no reemplaza a la compuerta. La matriz por **sistema operativo** es la forma barata de detectar en CI lo que mostró el caso —el cp1252 compila en un runner Windows y falla en uno Linux— **[no verificado]** (no hubo runner Windows); pero los *job containers* exigen runner Linux [B172], así que la celda Windows tiene que instalar los toolchains en el runner y depender todavía más de la compuerta. Dentro de un *job container* el shell por defecto de `run` es `sh`, no `bash` [B135].
~~~~

por

~~~~text
GitHub Actions ofrece `jobs.<id>.container`, que corre todos los pasos del job en una imagen [B135], y `strategy.matrix`, un job por combinación [B171]. **[criterio]** Imagen única cuando el artefacto es uno: el job corre `./build.sh`, el mismo comando que la estación y el devcontainer. Por componente sólo si los componentes se publican por separado, con una etapa previa que corre la compuerta completa en la imagen única: el Dockerfile por componente del laboratorio corre sólo los comandos estrictos, no la compuerta de texto. La matriz sirve para probar varias versiones de un runtime y no reemplaza a la compuerta; por **sistema operativo** es la forma barata de detectar lo que mostró el caso —el cp1252 compila en un runner Windows y falla en uno Linux— **[no verificado]** (no hubo runner Windows), pero los *job containers* exigen runner Linux [B172]: la celda Windows instala los toolchains en el runner y depende más de la compuerta. Dentro de un *job container* el shell por defecto de `run` es `sh`, no `bash` [B135].
~~~~

22. Reemplazar la línea que empieza con «La lección es de **alcance**:» (hoy:)

~~~~text
La lección es de **alcance**: el SBOM del artefacto (qué se entrega), el de las dependencias declaradas (qué terceros entraron a la build) y el del entorno de build (las imágenes) son tres documentos distintos, con 2, 4 y casi 900 componentes en el mismo laboratorio. **[criterio]** Una solución políglota necesita al menos los dos primeros y la procedencia, que nombra el entorno por digest; el SBOM completo del entorno sirve para auditar la cadena de suministro y no conviene confundirlo con el del producto. La procedencia exportada por BuildKit no está firmada y su `builder.id` sale vacío (§9.2.4). La que firma la plataforma, como la de `actions/attest`, exige en sus dependencias resueltas sólo el commit y deja el entorno como opcional [B202]. Para contestar «con qué entorno se ensambló» hay entonces tres piezas distintas **[criterio]**: (a) la procedencia de la plataforma, firmada, que nombra commit y workflow; (b) los materiales del entorno —digest de la imagen del job o de cada etapa, toolchain efectivo—, que registra un paso del pipeline; (c) cómo se atan: un predicado propio firmado en la misma corrida, rotulado como afirmación del pipeline y no de la plataforma (la vara de §9.2.4), o la atestación de la imagen del job, enlazada por su digest.
~~~~

por

~~~~text
La lección es de **alcance**: el SBOM del artefacto (qué se entrega), el de las dependencias declaradas (qué terceros entraron) y el del entorno de build (las imágenes) son tres documentos distintos, con 2, 4 y casi 900 componentes en el mismo laboratorio. **[criterio]** Una solución políglota necesita al menos los dos primeros y la procedencia; el SBOM del entorno sirve para auditar la cadena de suministro y no se confunde con el del producto. La procedencia de BuildKit no está firmada y su `builder.id` sale vacío (§9.2.4); la que firma la plataforma, como la de `actions/attest`, exige en sus dependencias sólo el commit y deja el entorno como opcional [B202]. Para contestar «con qué entorno se ensambló» hay entonces tres partes **[criterio]**: (a) la procedencia de la plataforma, firmada, que nombra commit y workflow; (b) los materiales del entorno —digest de la imagen del job o de cada etapa, toolchain efectivo—, que registra un paso del pipeline (A.17); (c) su vínculo: un predicado propio firmado en la misma corrida, rotulado como afirmación del pipeline y no de la plataforma (la vara de §9.2.4), o la atestación de la imagen del job, enlazada por su digest.
~~~~

23. Reemplazar la línea que empieza con «Experimentos del capítulo: E8-1 (» (hoy:)

~~~~text
Experimentos del capítulo: E8-1 (choque de convenciones con quince lectores), E8-2 (punto único de versiones; mise; límite de búsqueda de uv), E8-3 (frontera de la build: MSBuild llama a npm y uv frente a `build.sh`), E8-4 (`.esproj`), E8-5 (imagen única frente a por componente; mismo binario), E8-6 (SBOM multi-ecosistema, nativos unidos y BuildKit con procedencia).
~~~~

por

~~~~text
Experimentos del capítulo: E8-1 a E8-6 (Anexo E).
~~~~

24. Reemplazar la línea que empieza con «La regla es la de §5, y E8-1 la confirma en conjunto» (hoy:)

~~~~text
La regla es la de §5, y E8-1 la confirma en conjunto (la columna A pasa los quince lectores): **UTF-8 sin BOM y LF como regla general, con excepciones por extensión que exige el consumidor del archivo**. En una solución políglota la excepción no se decide por lenguaje sino por **quién lee ese archivo**: `.sh` sin BOM y con LF (el kernel); `.cmd`/`.bat` con CRLF (`cmd.exe`); `.razor`/`.cshtml`/`.sln` con BOM (las herramientas del SDK lo reponen); `.ps1` con BOM si se usa Windows PowerShell 5.1 [B54]; locks sin exigir salto final (NuGet no lo pone; `package-lock.json` y `uv.lock` sí terminan en `\n`). Dos detalles de `.editorconfig` que aparecen recién al juntar ecosistemas: `unset` permite que una sección posterior anule una propiedad de `[*]`, y la sección que aparece después gana, así que las excepciones van al final [B43].
~~~~

por

~~~~text
La regla es la de §5, y E8-1 la confirma en conjunto (la columna A pasa los quince lectores): **UTF-8 sin BOM y LF como regla general, con excepciones por extensión que exige quien lee el archivo**, no el lenguaje: `.sh` sin BOM y con LF (el kernel); `.cmd`/`.bat` con CRLF (`cmd.exe`); `.razor`/`.cshtml`/`.sln` con BOM (las herramientas del SDK lo reponen); `.ps1` con BOM si se usa Windows PowerShell 5.1 [B54]; locks sin exigir salto final (NuGet no lo pone; `package-lock.json` y `uv.lock` sí). En `.editorconfig`, `unset` anula una propiedad de `[*]` y la sección posterior gana, así que las excepciones van al final [B43].
~~~~

25. Reemplazar la línea que empieza con «**Los dos caminos tienen que producir lo mismo**,» (hoy:)

~~~~text
**Los dos caminos tienen que producir lo mismo**, y en el laboratorio lo hacen cuando ruta **y configuración** coinciden: `build.sh` en `Release` y `dotnet build -c Release` dieron la misma DLL (`4dd5d90f…`); el `dotnet build` sin `-c`, que es lo que hace F5, compila en `Debug` y da otra (medido durante la verificación del laboratorio N8; ver Anexo F). **[criterio]** La igualdad no se comprueba en la estación —F5 compila en `Debug` y sin `ContinuousIntegrationBuild` (§9.4)—: se comprueba en la CI como **prueba de regresión del `.csproj`**, con la misma imagen corriendo `dotnet build -c Release -p:ContinuousIntegrationBuild=true` con `ConstruirPoliglota=true` y `build.sh`, y comparando las DLL. Lo que demuestra es que los targets de A no divergen de B, no que la estación reproduzca a la CI.
~~~~

por

~~~~text
**Los dos caminos tienen que producir lo mismo**, y en el laboratorio lo hacen cuando ruta **y configuración** coinciden: `build.sh` en `Release` y `dotnet build -c Release` dieron la misma DLL (`4dd5d90f…`); el `dotnet build` sin `-c` de F5 compila en `Debug` y da otra (verificación del laboratorio N8; Anexo F). **[criterio]** La igualdad se comprueba en la CI, no en la estación (F5 compila en `Debug` y sin `ContinuousIntegrationBuild`, §9.4), como **prueba de regresión del `.csproj`**: en la misma imagen, `dotnet build -c Release -p:ContinuousIntegrationBuild=true` con `ConstruirPoliglota=true` y `build.sh`, comparando las DLL. Demuestra que los targets de A no divergen de B, no que la estación reproduzca a la CI.
~~~~

26. Reemplazar la línea que empieza con «No hay lock común (§7). Lo que se unifica es el procedimiento:» (hoy:)

~~~~text
No hay lock común (§7). Lo que se unifica es el procedimiento: los tres archivos de registros **en el repo** —`nuget.config` con `<clear />` y mapeo [B87][B86]; `.npmrc` del proyecto con el registro y los *scopes* [B109]; índices de paquetes de uv con la estrategia `first-index` contra la confusión de dependencias y `explicit = true` para los internos, que protege sólo lo asignado a ese índice [B110]—, ninguno dependiente de la configuración del usuario, cada uno con el hueco que dice §7.3, y la compuerta corriendo los tres comandos estrictos. El `.npmrc` del proyecto tiene la prioridad más alta de npm pero vale sólo en la raíz donde se corre npm [B109]; en un *workspace*, el `.npmrc` de un miembro se ignora con un aviso y vale el de la raíz (medido con npm 10.9.8 durante la verificación del laboratorio N8, sin script versionado; ver Anexo F).
~~~~

por

~~~~text
No hay lock común (§7). Se unifica el procedimiento: los tres archivos que declaran los registros de paquetes, **en el repo** —`nuget.config` con `<clear />` y mapeo [B87][B86]; `.npmrc` del proyecto con el registro y los *scopes* [B109]; índices de uv con la estrategia `first-index` y `explicit = true` para los internos, que protege sólo lo asignado a ese índice [B110]—, ninguno dependiente del usuario y cada uno con el hueco de §7.3, y la compuerta corriendo los tres comandos estrictos. El `.npmrc` del proyecto tiene la prioridad más alta de npm, pero sólo en la raíz donde se corre [B109]: en un *workspace*, el de un miembro se ignora con un aviso (npm 10.9.8, verificación del laboratorio N8 sin script versionado; Anexo F).
~~~~

27. Reemplazar la línea que empieza con «Con `.python-version` (3.12.15) en la **raíz** del repo» (hoy:)

~~~~text
Con `.python-version` (3.12.15) en la **raíz** del repo y el proyecto uv en `tools/gen/`, `uv run` desde `tools/gen/` usó 3.12.14 **sin aviso**, porque la petición salió de `requires-python` (E8-2): el archivo «único» de la raíz no gobernaba al único proyecto Python del repo. **[criterio]** Un archivo nativo por ecosistema, **ubicado donde lo busca la herramienta de ese ecosistema**: `global.json` y `.nvmrc` en la raíz; `.python-version` dentro del proyecto uv (o la raíz convertida en *workspace* de uv [B111], con el costo de un `pyproject.toml` en la raíz de una solución .NET).
~~~~

por

~~~~text
Con `.python-version` (3.12.15) en la **raíz** y el proyecto uv en `tools/gen/`, `uv run` desde `tools/gen/` usó 3.12.14 **sin aviso**, por `requires-python` (E8-2): el archivo «único» no gobernaba al único proyecto Python. **[criterio]** Un archivo nativo por ecosistema, **donde lo busca su herramienta**: `global.json` y `.nvmrc` en la raíz; `.python-version` dentro del proyecto uv (o la raíz como *workspace* de uv [B111], al costo de un `pyproject.toml` en la raíz de una solución .NET).
~~~~

28. Reemplazar la línea que empieza con «Ningún fabricante documenta la **build** integrada» (hoy:)

~~~~text
Ningún fabricante documenta la **build** integrada de los tres ecosistemas. Cada uno documenta cómo agrupar sus proyectos y, a veces, cómo invocar a otro; la excepción parcial es Aspire 13, que orquesta apps .NET, JavaScript y Python para **ejecutar y publicar** —no para compilar una DLL que embeba las salidas de los otros— y cuyos Dockerfiles detectan la versión de Node desde `.nvmrc` y la de Python desde `.python-version` [B167] **[no verificado]** (no ejercitado en el laboratorio). El laboratorio implementa dos diseños sobre el mismo `.csproj`.
~~~~

por

~~~~text
Ningún fabricante documenta la **build** integrada de los tres ecosistemas; cada uno documenta cómo agrupar sus proyectos y, a veces, cómo invocar a otro. La excepción parcial es Aspire 13, que orquesta apps .NET, JavaScript y Python para **ejecutar y publicar** —no para compilar una DLL que embeba las salidas de los otros— y cuyos Dockerfiles toman Node de `.nvmrc` y Python de `.python-version` [B167] **[no verificado]** (no ejercitado en el laboratorio). El laboratorio implementa dos diseños sobre el mismo `.csproj`.
~~~~

29. Reemplazar la línea que empieza con «**[criterio]** Las dos se fijan igual:» (hoy:)

~~~~text
**[criterio]** Las dos se fijan igual: cada base por digest, cada versión leída de los archivos nativos y la compuerta como prueba de que la imagen corresponde al repo. Construir la imagen de desarrollo `FROM` la misma base que la CI (§8.2.6) se cumple por construcción **si la CI también usa la imagen única**. Con CI por componente, el Python de desarrollo lo instala uv y el de la CI viene de `python:3.12.15-slim`: la misma versión, de dos orígenes, que hay que declarar.
~~~~

por

~~~~text
**[criterio]** Las dos se fijan igual: cada base por digest, cada versión leída de los archivos nativos y la compuerta como prueba de que la imagen corresponde al repo. La imagen de desarrollo `FROM` la base de la CI (§8.2.6) sale por construcción **si la CI usa la imagen única**; con CI por componente, el Python de desarrollo lo instala uv y el de la CI viene de `python:3.12.15-slim`: misma versión, dos orígenes, que se declaran.
~~~~

30. Reemplazar la línea que empieza con «E8-1 toma la solución y le aplica las dos políticas» (hoy:)

~~~~text
E8-1 toma la solución y le aplica las dos políticas «globales» que un equipo adopta sin pensar por extensión —la corrección del caso C# aplicada a todo («UTF-8 con BOM para todo») y el checkout de una estación Windows con `core.autocrlf=true` y sin `.gitattributes` («CRLF para todo»)— más el código heredado del caso (cp1252). Después corre quince lectores de los tres ecosistemas sobre los mismos bytes:
~~~~

por

~~~~text
E8-1 aplica a la solución las dos políticas «globales» que un equipo adopta sin pensar por extensión —la corrección del caso aplicada a todo («UTF-8 con BOM para todo») y el checkout de una estación Windows con `core.autocrlf=true` y sin `.gitattributes` («CRLF para todo»)— más el heredado del caso (cp1252), y corre quince lectores de los tres ecosistemas sobre los mismos bytes:
~~~~


### P-14 · §12 Hoja de ruta: paso 7 con dos caminos para la CI, registro del entorno, contrato completo y Práctica integradora

- **Hallazgos**: C2-13, C2-14, C2-55, C2-33.
- **Sección**: §12 tabla L2392–L2393; bloque YAML L2400–L2418; cierre.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras**: prosa +128, evidencia y plantillas +111.
- **Verificación**: El YAML de §12 es válido (PyYAML 6.0.3) y `validaciones` tiene una línea por paso 1–10 (11 líneas, con 8a y 8b); la ruta mínima de §0.2 remite a la «Práctica integradora», que existe; las salidas citadas en la Práctica están en `e2-migracion.txt`, `e3-compuerta.txt`, `E3-1.txt`, `e1-nuget-lock.txt`, `e4-npm-lock.txt`, `E7-04-*.txt`, `E5-6-*.txt`, `E5-1-*.txt`.
- **Nota**: El último op agrega la «Práctica integradora» (prosa) junto con el YAML (contrato); su Δ se imputa a prosa en el balance (§2).

1. Reemplazar

~~~~text
| 7 | Construir la imagen de CI **desde** los archivos de los pasos 5–6, con sus bases por digest y un bot que proponga los digests nuevos por PR; el devcontainer, si se ofrece, con la misma receta o con etiqueta fija de SDK y SO verificada por `global.json`. | ACT-OPS | La compuerta pasa en la imagen y falla si se desalinea | §8 |
~~~~

por

~~~~text
| 7 | Elegir dónde corre la CI: imagen propia construida **desde** los archivos de los pasos 5–6, con bases por digest que mueve un PR (para 8b, reconstrucción bit a bit o frontera A en la CI), o runner alojado con acciones de *setup* por SHA que los leen (alcanza para 8a). El devcontainer, si se ofrece, con la misma receta o con etiqueta fija de SDK y SO verificada por `global.json`. | ACT-ARQ, ACT-OPS | La compuerta pasa en la CI y falla si se desalinea | §8.2.2, A.12 |
~~~~

2. Reemplazar

~~~~text
registro del entorno (SDK, compilador y runtimes efectivos, digest de la imagen, commit y árbol limpio) y SBOM con alcance declarado. |
~~~~

por

~~~~text
registro del entorno (SDK, compilador y runtimes efectivos, digest de la imagen, commit y árbol limpio; A.17) y SBOM con alcance declarado. |
~~~~

3. Reemplazar

~~~~text
  - "imagen de CI con bases por digest y configuración del bot (paso 7)"
  - "registro del entorno y SBOM junto al artefacto (8a); procedencia si corresponde (8b)"
~~~~

por

~~~~text
  - "imagen de CI con bases por digest, o runner alojado con acciones por SHA (paso 7)"
  - "registro del entorno y SBOM junto al artefacto (8a); procedencia si corresponde (8b)"
  - "CODEOWNERS, configuración de los bots y ADR de descongelamiento (paso 9)"
  - "tabla por extensión revisada con los lectores de los tres ecosistemas (paso 10)"
~~~~

4. Reemplazar

~~~~text
validaciones:
  - "paso 3: tools/verificar-commit-mecanico.sh <sha> CP1252 -> 0 con cambio de contenido"
~~~~

por

~~~~text
validaciones:
  - "paso 1: e1-diagnostico.sh -> codificación, BOM y CR de cada archivo"
  - "paso 2: editorconfig y git check-attr resuelven lo decidido por extensión (EA-1, paso 1)"
  - "paso 3: tools/verificar-commit-mecanico.sh <sha> CP1252 -> 0 con cambio de contenido"
~~~~

5. Reemplazar

~~~~text
  - "paso 7: imagen desalineada con los archivos nativos -> compuerta en rojo"
```
~~~~

por

~~~~text
  - "paso 7: imagen desalineada con los archivos nativos -> compuerta en rojo"
  - "paso 8a: registro del entorno sin campos vacíos junto al artefacto (A.17)"
  - "paso 8b: la procedencia verifica con su par firmante/builder.id"
  - "paso 9: un PR que toca la compuerta pide la aprobación de su dueño (CODEOWNERS)"
  - "paso 10: los quince lectores de E8-1 pasan con la política por extensión (columna A)"
```

**Práctica integradora** (sin experimentos nuevos).

1. Para cada validación del contrato, nombrá el experimento que la mostró y predecí el mensaje. *Respuesta esperada*: paso 3, E2-2 (`0 con cambio de contenido`); 4, E2-3 (`¿cp1252?`); 5, E3-1 (`A compatible .NET SDK was not found`); 6, E4-1 y E4-4 (`NU1004`, `EUSAGE`); 7, E7-4 (rojo en la imagen vieja).
2. ¿Qué deja sin detectar empezar por el devcontainer (paso 7) antes de fijar el toolchain (paso 5)? *Respuesta esperada*: con imagen por etiqueta y sin `global.json`, el SDK cambia sin que el repo se entere (E5-6, §3.5), y la capa 1 sigue rota adentro (E5-1).
~~~~


### P-15 · Anexo A: plantillas copiables (A.1, A.3, A.4, A.4b, A.9, A.10, A.11, A.12) y dos nuevas (A.17, A.18)

- **Hallazgos**: C2-12, C2-04, C2-57, C2-01, C2-02, C2-11, C2-07, C2-05, C2-06, C2-08, C2-13, C2-14, C2-17, C2-18, C2-26, C2-53.
- **Sección**: Anexo A L2424, L2456–L2460, L2510, L2529–L2531, L2552–L2562, L2675–L2682, L2723–L2732, L2747–L2757, L2759–L2789; A.17 y A.18 nuevas tras A.16.
- **Capa de origen**: guía + laboratorio (P-23 L2, L3). **Costo**: alto. **Reversible**: sí. **Δ palabras**: prosa +278, evidencia y plantillas +506.
- **Verificación**: `aplicacion/anexoA.py` (ciclo 1) ampliado a A.17 y A.18: 22 de 22 bloques que son archivos, iguales byte a byte a `Examples/A-plantillas/repo/` (no lo son la salida de A.17 ni la variante de A.12; ya comprobado para los nueve bloques tocados contra `evidencia-auditor/x7-ea1-propuesto/repo/`); EA-1 rc=0 con los pasos 1c, 2c, 8, 9 y 10 (salida esperada: evidencia-auditor/x7-ea1-propuesto/salida.txt); el bloque `text` de A.17 se reemplaza por las líneas del paso 9 de EA-1, con `…` en los hashes (regla de §0.3); [B210] [B211] [B212] [B216] [B217] definidas y citadas; `grep -c 'verificar.sh de N8'` → 0.
- **Nota**: En el op de A.12 (rango) la prosa nueva es el párrafo «Ilustrativo» y la frase de la variante; en A.17/A.18, las preguntas y las dos frases finales. El balance de §2 los cuenta aparte (columna «prosa dentro de bloques mixtos»).

1. Reemplazar

~~~~text
condición de CI de `Directory.Build.props`, lock sólo en los ejecutables, la imagen de A.10 construida con la plantilla `web/` corriendo adentro, `devEngines`, uv, y sintaxis de JSONC, YAML y del esquema de `dependabot.yml`.
~~~~

por

~~~~text
condición de CI de `Directory.Build.props`, lock sólo en los ejecutables (también `WinExe`), variante B de A.1, la imagen de A.10 con la plantilla `web/` y la compuerta completa adentro, registro del entorno, `devEngines`, uv, `devcontainer up`, y sintaxis de JSONC, YAML y del esquema de `dependabot.yml`.
~~~~

2. Reemplazar

~~~~text
# Variante B (heredado YA convertido a UTF-8 con BOM, o elegida antes de migrar):
# descomentar. Con la variante A, lo que crea dotnet new console (Program.cs y el
# .csproj, con BOM) se normaliza antes del primer commit.
# [*.cs]
# charset = utf-8-bom
~~~~

por

~~~~text
# Variante B (heredado YA convertido a UTF-8 con BOM, como el del caso, o elegida
# antes de migrar): descomentar. Cubre los archivos de proyecto, que siguen la
# convención de *.cs (5.2.3); los Directory.Build.* de este anexo se guardan
# entonces con BOM. Con la variante A, lo que crea dotnet new console (Program.cs
# y el .csproj, con BOM) se normaliza antes del primer commit.
# [*.{cs,csproj,props,targets}]
# charset = utf-8-bom
~~~~

3. Reemplazar

~~~~text
EA-1 paso 1b: un `dotnet new console` dentro del repo deja dos violaciones con la variante A (`Program.cs` y el `.csproj` con BOM) y ninguna después de normalizarlos.
~~~~

por

~~~~text
EA-1 paso 1b: un `dotnet new console` dentro del repo deja dos violaciones con la variante A (`Program.cs` y el `.csproj` con BOM) y ninguna después de normalizarlos. Paso 1c: con la variante B, la solución que crea el SDK, convertida con BOM, no deja ninguna una vez guardados con BOM los `Directory.Build.*`.
~~~~

4. Reemplazar

~~~~text
Variante tolerante, sin lock files: `"version": "8.0.400", "rollForward": "latestPatch"` (el parche más alto de la banda 4xx). Costo de `disable`: toda estación, la imagen del devcontainer y la de CI necesitan exactamente 8.0.425, y la que tenga otro parche no compila (§6.4).
~~~~

por

~~~~text
8.0.425 es el SDK del caso; .NET 8 sale de soporte el 2026-11-10 [B61][B62]: un repo nuevo parte de la última 10.0.4xx. Variante tolerante, sin lock files: `"version": "8.0.400", "rollForward": "latestPatch"` (el parche más alto de la banda 4xx). Costo de `disable`: §6.4.
~~~~

5. Reemplazar

~~~~text
    <!-- Política SIN lock (guía, 6.4): descomentar. Una versión inexistente que NuGet
         aproxima corta el restore. Con lock, el lock desarma este aviso (E4-2). -->
    <!-- <WarningsAsErrors>$(WarningsAsErrors);NU1603</WarningsAsErrors> -->
~~~~

por

~~~~text
    <!-- NU1603 como error en las dos políticas de la guía (6.4): corta el restore de un
         proyecto sin lock cuando NuGet aproxima una versión que no existe. Con lock no se
         dispara (E4-2): esa aproximación la detecta la compuerta (requested = resolved). -->
    <WarningsAsErrors>$(WarningsAsErrors);NU1603</WarningsAsErrors>
~~~~

6. Reemplazar

~~~~text
       OutputType todavía no está definido y la condición no se cumple nunca. -->
  <PropertyGroup Condition="'$(OutputType)' == 'Exe'">
~~~~

por

~~~~text
       OutputType todavía no está definido y la condición no se cumple nunca.
       WinExe: WinForms y WPF (el SDK cambia Exe por WinExe en esas aplicaciones).
       Un proyecto de prueba no recibe lock por esta regla: su OutputType=Exe llega desde
       un paquete que el restore no evalúa; si se lo quiere congelar, se declara
       RestorePackagesWithLockFile en su .csproj. -->
  <PropertyGroup Condition="'$(OutputType)' == 'Exe' Or '$(OutputType)' == 'WinExe'">
~~~~

7. Reemplazar

~~~~text
EA-1 paso 2b: con `Directory.Build.targets`, `packages.lock.json` aparece en el ejecutable y no en la biblioteca, y en modo CI el restore pasa y falla con `NU1004` ante un cambio sin regenerar.
~~~~

por

~~~~text
EA-1 paso 2b: con `Directory.Build.targets`, `packages.lock.json` aparece en el ejecutable y no en la biblioteca, y en modo CI el restore pasa y falla con `NU1004` ante un cambio sin regenerar; paso 2c: un `WinExe` (WinForms con `EnableWindowsTargeting`) también recibe su lock [B215].
~~~~

8. Reemplazar

~~~~text
  // Hook versionado activado una vez por clon.
  "postCreateCommand": "git config core.hooksPath .githooks && dotnet --version && node --version && uv --version"
~~~~

por

~~~~text
  // Hook versionado activado una vez por clon. El contenedor corre como root: sin
  // safe.directory, git rechaza el repo montado (dubious ownership, guía 8.2.5).
  "postCreateCommand": "git config --global --add safe.directory ${containerWorkspaceFolder} && git config core.hooksPath .githooks && dotnet --version && node --version && uv --version"
~~~~

9. Reemplazar

~~~~text
Con `build.dockerfile` no hay *features* ni `devcontainer-lock.json`: lo que se congela es la receta, y sus bases van por digest. Fuentes: [B119], [B136].
~~~~

por

~~~~text
Con `build.dockerfile` no hay *features* ni `devcontainer-lock.json`: lo que se congela es la receta, y sus bases van por digest. EA-1 paso 10: `devcontainer up` (CLI 0.89.0) en host Linux da `outcome: success` con el hook activado. Fuentes: [B119], [B136], E5-3.
~~~~

10. Reemplazar

~~~~text
RUN test -n "$PYTHON_VERSION" \
 && uv python install "$PYTHON_VERSION" \
 && ln -s "$(uv python find "$PYTHON_VERSION")" /usr/local/bin/python3 \
 && chmod -R a+rX /opt/uv-python \
~~~~

por

~~~~text
# EditorConfig: lo importa el paso de texto de la compuerta (A.11).
RUN test -n "$PYTHON_VERSION" \
 && uv python install "$PYTHON_VERSION" \
 && ln -s "$(uv python find "$PYTHON_VERSION")" /usr/local/bin/python3 \
 && uv pip install --system --break-system-packages --python /usr/local/bin/python3 EditorConfig==0.17.1 \
 && chmod -R a+rX /opt/uv-python \
~~~~

11. Reemplazar

~~~~text
La plantilla vive en `Examples/A-plantillas/repo/imagen/Dockerfile` y EA-1 la construye y corre la plantilla `web/` adentro (Node 24.21.0, npm 11.19.0, glibc 2.36 en las dos bases).
~~~~

por

~~~~text
La plantilla vive en `Examples/A-plantillas/repo/imagen/Dockerfile` y EA-1 la construye y corre adentro la plantilla `web/` (Node 24.21.0, npm 11.19.0, glibc 2.36 en las dos bases) y la compuerta completa de A.11.
~~~~

12. Reemplazar

~~~~text
# Examples/N7-compuertas-y-gobierno/compuerta/compuerta.sh (un proyecto por ecosistema en la raíz)
# o Examples/N8-integracion-poliglota/solucion/verificar.sh (proyectos en subcarpetas, guía 10.2.2).
~~~~

por

~~~~text
# Examples/N7-compuertas-y-gobierno/compuerta/compuerta.sh (proyectos en la raíz o en subcarpetas).
~~~~

13. Reemplazar

~~~~text
**Qué se copia y adónde.** A `tools/ci/`: `compuerta.sh` de `Examples/N7-compuertas-y-gobierno/compuerta/` y `check_text_policy.py` de `Examples/N2-politica-de-texto-y-remediacion/tools/`; o, si los proyectos viven en subcarpetas, `verificar.sh` de N8 con su inventario de rutas (§10.2.2). A `.githooks/`: el hook de arriba. Activación, una vez por clon: `git config core.hooksPath .githooks` [B37].
~~~~

por

~~~~text
**Qué se copia y adónde.** A `tools/ci/`: `compuerta.sh` de `Examples/N7-compuertas-y-gobierno/compuerta/`, que encuentra los proyectos en la raíz o en subcarpetas, y `check_text_policy.py` de `Examples/N2-politica-de-texto-y-remediacion/tools/`. A `.githooks/`: el hook de arriba. Creados desde Windows, entran sin bit de ejecución (§8.2.5; en un Windows real, **[no verificado]**) y git ignora un hook sin él: antes del commit, `git update-index --chmod=+x tools/ci/compuerta.sh .githooks/pre-commit`. Activación, una vez por clon: `git config core.hooksPath .githooks` [B37].
~~~~

14. Reemplazar el rango que va desde «Preguntas: ¿la imagen del job sale de la misma receta que el devcontainer (A.10), publicada y nombrada por digest?» (incluido; ⏎ = salto de línea) hasta justo antes de «### A.13 `dependabot.yml`» por:

~~~~text
Preguntas: ¿imagen propia por digest, de la receta del devcontainer (A.10), o runner alojado (§8.2.2)? Si es privada, ¿el job puede descargarla y quién mueve su digest? ¿La revisión de dueños es obligatoria sobre `.github/` y `tools/ci/` (§10.2.7)? ¿Cada acción va por SHA? ¿El PR tiene la historia que necesita `--base`? ¿`SOURCE_DATE_EPOCH` llega a los pasos que construyen?

```yaml
# Anexo A.12. Ejemplo NO ejecutado en el laboratorio (requiere GitHub).
name: compuerta
on:
  pull_request:
  push:
    branches: [main]
permissions:
  contents: read
  packages: read          # descargar la imagen privada de GHCR (nace privada)
jobs:
  compuerta:
    runs-on: ubuntu-24.04
    # Imagen construida desde imagen/Dockerfile (A.10), la misma receta que el devcontainer (A.9),
    # publicada en el registro de imágenes del equipo. El digest se declara sólo acá: lo lee
    # registrar-entorno.sh (A.17) y lo mueve el PR que abre el workflow que publica la imagen.
    container:
      image: ghcr.io/org/imagen-ci@sha256:0000000000000000000000000000000000000000000000000000000000000000
      credentials:
        username: ${{ github.actor }}
        password: ${{ secrets.GITHUB_TOKEN }}
    steps:
      # Acción fijada por SHA completo; la etiqueta va como comentario.
      - uses: actions/checkout@3d3c42e5aac5ba805825da76410c181273ba90b1 # v7.0.1
        with:
          fetch-depth: 0
      # Cada run: es un shell propio: la variable llega a los pasos siguientes por GITHUB_ENV.
      - run: echo "SOURCE_DATE_EPOCH=$(git log -1 --pretty=%ct)" >> "$GITHUB_ENV"
      # bash explícito: no depende del bit de ejecución registrado en git.
      - run: bash tools/ci/compuerta.sh --base "origin/${{ github.base_ref }}"
        if: github.event_name == 'pull_request'
      - run: bash tools/ci/compuerta.sh
        if: github.event_name == 'push'
      # 8a: construir, registrar el entorno y, aparte, el SBOM con alcance declarado (9.2.3).
      - run: dotnet build src/App -c Release -o out
      - run: bash tools/ci/registrar-entorno.sh out/App.dll > out/registro-entorno.txt
```

**Ilustrativo**: validado como YAML y con sus `run:` corridos en la imagen de A.10 (EA-1, paso 9); no ejecutado en GitHub. SHA de `actions/checkout` resuelto con `git ls-remote` el 2026-10-07 [B193]. En GHCR un paquete nuevo nace privado [B210] y los permisos no declarados quedan en `none` [B211]: de ahí `packages: read` y `credentials` [B135]; `GITHUB_ENV`, [B212]; quién mueve el digest, §8.2.2. Fuentes: [B135], [B183].

Variante con runner alojado, que alcanza para 8a (§8.2.2); reemplaza `container:` y los pasos previos a la compuerta:

```yaml
    steps:
      - uses: actions/checkout@3d3c42e5aac5ba805825da76410c181273ba90b1 # v7.0.1
        with: { fetch-depth: 0 }
      - uses: actions/setup-dotnet@a98b56852c35b8e3190ac28c8c2271da59106c68 # v6.0.0
        with: { global-json-file: global.json }
      - uses: actions/setup-node@949feb2413d6458794dcd2491c4babbbce0c15c1 # v7.1.0
        with: { node-version-file: .nvmrc }
      - uses: actions/setup-python@5fda3b95a4ea91299a34e894583c3862153e4b97 # v7.0.0
        with: { python-version-file: tools/gen/.python-version }
      - uses: astral-sh/setup-uv@c18668ad3cf93ea998bef934396af7bb5c839dc7 # v10.2.0
        with: { working-directory: tools/gen }
      - run: python -m pip install EditorConfig==0.17.1
```

**Ilustrativo** **[no verificado]** (requiere GitHub): entradas de [B181]; SHA de [B217].

~~~~

15. Reemplazar

~~~~text
Un ADR aceptado no se edita: si la decisión cambia, uno nuevo lo reemplaza y se vinculan [B184]. Versión del laboratorio con un ejemplo real (subir de SDK 8 a 10): `Examples/N7-compuertas-y-gobierno/04-descongelamiento-controlado/ADR-plantilla-entorno.md`.

~~~~

por

~~~~text
Un ADR aceptado no se edita: si la decisión cambia, uno nuevo lo reemplaza y se vinculan [B184]. Versión del laboratorio con un ejemplo real (subir de SDK 8 a 10): `Examples/N7-compuertas-y-gobierno/04-descongelamiento-controlado/ADR-plantilla-entorno.md`.

### A.17 Registro del entorno

Preguntas: ¿qué no declara el repo y hay que grabar (§3.7)? ¿De dónde sale el digest de la imagen? ¿Qué artefactos se registran?

```sh
#!/bin/sh
# Anexo A.17. Registro del entorno (guía 9.6; 12, paso 8a). Lo corre la CI después de construir,
# en la misma imagen: tools/ci/registrar-entorno.sh <artefacto>... > registro-entorno.txt
# Sin firma: sirve para diagnosticar y reconstruir, no prueba nada ante un tercero (9.2.4).
set -eu
echo "commit=$(git rev-parse HEAD) arbol_limpio=$(git diff --quiet HEAD && echo si || echo NO)"
# El digest se declara UNA vez, en el container: del workflow (A.12); el registro lo lee de ahí.
img=$(sed -n 's/^ *\(container\|image\): *\([^ ]*@sha256:[0-9a-f]\{64\}\).*/\2/p' .github/workflows/ci.yml | head -1)
echo "imagen=${img:-NO DECLARADA (runner sin contenedor: capa 4 en el log «Set up job»)}"
sdk=$(dotnet --version); raiz=$(dirname "$(readlink -f "$(command -v dotnet)")")
echo "dotnet_sdk=$sdk compilador_csharp=$(dotnet exec "$raiz/sdk/$sdk/Roslyn/bincore/csc.dll" -version)"
echo "node=$(node --version) npm=$(npm --version)"
echo "python=$(python3 -c 'import platform;print(platform.python_version())') uv=$(uv --version | cut -d' ' -f2)"
git ls-files '*packages.lock.json' '*package-lock.json' '*uv.lock' | while read -r f; do
  echo "sha256 $f=$(sha256sum "$f" | cut -d' ' -f1)"; done
for a in "$@"; do echo "sha256 $a=$(sha256sum "$a" | cut -d' ' -f1)"; done
```

Salida en EA-1 (paso 9; digest de relleno de A.12):

```text
commit=6f6df869… arbol_limpio=si
imagen=ghcr.io/org/imagen-ci@sha256:0000000000000000000000000000000000000000000000000000000000000000
dotnet_sdk=8.0.425 compilador_csharp=4.11.0-3.25569.22 (3fb752d4)
node=v24.21.0 npm=11.19.0
python=3.12.15 uv=0.12.23
sha256 src/App/packages.lock.json=696d9560…
sha256 tools/gen/uv.lock=bcf2758b…
sha256 web/package-lock.json=72ab32c8…
sha256 out/App.dll=2bcec512…
```

El compilador sale de `csc -version`, el dato de `#error version` (`CS8304`, §9.6); sin `container:`, la capa 4 queda en el log del runner [B216]. Fuentes: [B02], §9.6.

### A.18 `.gitignore`

Preguntas: ¿qué genera cada ecosistema dentro del árbol?

```gitignore
# Anexo A.18. Lo generado no se versiona: la compuerta y los revisores miran lo versionado.
bin/
obj/
node_modules/
dist/
.venv/
__pycache__/
```

Sin él, `git add -A` versiona `obj/` y la compuerta revisa archivos generados (EA-1); `dotnet new gitignore` da uno más completo para .NET.

~~~~


### P-16 · Anexo B: listas por actor

- **Hallazgos**: C2-12, C2-01, C2-02, C2-23, C2-08, C2-26, C2-14.
- **Sección**: B.2 L2918, L2921; B.3 L2932–L2933; B.4 L2943.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras**: prosa +78, evidencia y plantillas +0.
- **Verificación**: Cada ítem tocado remite a una sección que, tras P-07…P-15, dice lo mismo; `grep -c '¿La imagen sigue fijada por digest'` → 0; B.4 tiene 8 ítems.

1. Reemplazar

~~~~text
- [ ] Para `*.cs` se eligió una variante (repo nuevo sin BOM; heredado convertido con BOM) y está declarada. (§5.2.3)
~~~~

por

~~~~text
- [ ] Para `*.cs` y los archivos de proyecto se eligió la variante según el estado del repo (nuevo → sin BOM; heredado todavía en cp1252 → la decidida antes del commit de política; heredado ya con BOM → `utf-8-bom`) y está declarada. (§5.2.3)
~~~~

2. Reemplazar

~~~~text
- [ ] Con la política con lock, cada ejecutable tiene su lock (`Directory.Build.targets`, A.4); los proyectos comunes no lo necesitan.
~~~~

por

~~~~text
- [ ] Con la política con lock, cada ejecutable (`Exe` o `WinExe`) tiene su lock (`Directory.Build.targets`, A.4), `NU1603` es error y la compuerta compara `requested` con `resolved`; los proyectos comunes no lo necesitan.
~~~~

3. Reemplazar

~~~~text
- [ ] La CI exporta `SOURCE_DATE_EPOCH` = fecha del commit y define `CI=true` o `TF_BUILD` para `ContinuousIntegrationBuild`. (§9.5, A.4)
~~~~

por

~~~~text
- [ ] `SOURCE_DATE_EPOCH` = fecha del commit llega a los pasos que construyen (en GitHub Actions, por `GITHUB_ENV`), y la CI define `CI=true` o `TF_BUILD` para `ContinuousIntegrationBuild`. (§9.5, A.4)
~~~~

4. Reemplazar

~~~~text
- [ ] Se graban el registro del entorno y el SBOM junto al artefacto;
~~~~

por

~~~~text
- [ ] Se graban el registro del entorno (A.17) y el SBOM junto al artefacto;
~~~~

5. Reemplazar

~~~~text
- [ ] ¿La imagen sigue fijada por digest y su SDK coincide con `global.json`? (§8)
~~~~

por

~~~~text
- [ ] ¿Lo que construye artefactos publicados sigue por digest? ¿El devcontainer usa etiqueta fija o la receta de la CI, y su SDK coincide con `global.json`? (§8.2.2)
- [ ] ¿Los `.sh` y el hook nuevos entran como `100755` (`git ls-files -s`)? (§8.2.5, A.11)
~~~~


### P-17 · Anexo C: «registro», «manifiesto», «VS» y el marco de §2

- **Hallazgos**: C2-35, C2-52.
- **Sección**: Anexo C (filas nuevas en orden alfabético); «Registro del entorno»; «Índice de paquetes».
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras**: prosa +92, evidencia y plantillas +0.
- **Verificación**: Los términos «Manifiesto», «Registro de paquetes / de imágenes», «VS» y «Escenario / contexto / actor» están en el Anexo C y remiten a secciones que existen; orden alfabético conservado.

1. Reemplazar

~~~~text
| Enfriamiento (*cooldown*) |
~~~~

por

~~~~text
| Escenario / contexto / actor | ESC-nn, CTX-… y ACT-…: dónde se trabaja, qué combina la solución, qué rol decide. | §2 |
| Enfriamiento (*cooldown*) |
~~~~

2. Reemplazar

~~~~text
| Índice de paquetes | Registro del que se descargan paquetes (en Python, *index*); sinónimo de registro. | §7.1 |
~~~~

por

~~~~text
| Índice de paquetes | Registro del que se descargan paquetes (en Python, *index*); sinónimo de registro de paquetes. | §7.1 |
~~~~

3. Reemplazar

~~~~text
| Mapeo de fuentes |
~~~~

por

~~~~text
| Manifiesto | Sin complemento, el del paquete (`package.json`, `.csproj`, `pyproject.toml`); «de la imagen», lo que nombra un digest; «de capas», el de E0-6. | §7.1, §8.1 |
| Mapeo de fuentes |
~~~~

4. Reemplazar

~~~~text
| Registro del entorno | Lo que se graba en la build sobre el entorno usado; sin firma. | §3.1 |
~~~~

por

~~~~text
| Registro de paquetes / de imágenes | De dónde se bajan paquetes (alias: índice, *feed*) o imágenes; siempre con su complemento. | §7.1, §8.1 |
| Registro del entorno | Lo que se graba en la build sobre el entorno usado; sin firma. | §3.1, A.17 |
~~~~

5. Reemplazar

~~~~text
| Verificación por reconstrucción |
~~~~

por

~~~~text
| VS | Visual Studio (no VS Code). | §2.1 |
| Verificación por reconstrucción |
~~~~


### P-18 · Anexo D: fuentes nuevas y promesa de citas de código

- **Hallazgos**: C2-49, C2-04, C2-10, C2-16, C2-17, C2-18, C2-20, C2-26, C2-29, C2-30, C2-41, C2-02, C2-13.
- **Sección**: Anexo D L3040; filas B205–B217 tras B204.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras**: prosa +8, evidencia y plantillas +251.
- **Verificación**: Script de bibliografía del ciclo 1: 217 `[Bnn]` definidas = 217 citadas, ninguna colgante ni duplicada; cada URL nueva se consultó el 2026-10-09 (WebFetch o `git ls-remote`, §4 de este documento).

1. Reemplazar

~~~~text
Las fuentes B01–B193 se consultaron el **2026-10-07**; B194–B204, el **2026-10-09**.
~~~~

por

~~~~text
Las fuentes B01–B193 se consultaron el **2026-10-07**; B194–B217, el **2026-10-09**.
~~~~

2. Reemplazar

~~~~text
Las fuentes de código (Roslyn, Node, VS Code) se citan por archivo y commit cuando el comportamiento no estaba documentado en prosa.
~~~~

por

~~~~text
Las fuentes de código (Roslyn, VS Code) se citan por archivo y commit cuando el comportamiento no estaba documentado en prosa; el cargador de Node, por la rama v22.x consultada.
~~~~

3. Reemplazar

~~~~text
| B204 | git — git-reset (`--hard`) | https://git-scm.com/docs/git-reset | 2026-10-09 |
~~~~

por

~~~~text
| B204 | git — git-reset (`--hard`) | https://git-scm.com/docs/git-reset | 2026-10-09 |
| B205 | Python — Python 3.15.0 (release, 2026-10-09; PEP 686 activo) | https://www.python.org/downloads/release/python-3150/ | 2026-10-09 |
| B206 | pnpm 10.x — Settings (`managePackageManagerVersions`, `packageManagerStrict`, `packageManagerStrictVersion`) | https://pnpm.io/10.x/settings | 2026-10-09 |
| B207 | Yarn — `yarn set version` (`--yarn-path`, `yarnPath`) | https://yarnpkg.com/cli/set/version | 2026-10-09 |
| B208 | Docker Docs — SLSA definitions (`builder.id`, parámetro `builder-id`) | https://docs.docker.com/build/metadata/attestations/slsa-definitions/ | 2026-10-09 |
| B209 | Git for Windows — Release notes, *Known issues* (conversión de rutas, `MSYS_NO_PATHCONV`) | https://github.com/git-for-windows/build-extra/blob/main/ReleaseNotes.md | 2026-10-09 |
| B210 | GitHub Docs — Working with the Container registry (visibilidad privada por defecto) | https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-container-registry | 2026-10-09 |
| B211 | GitHub Docs — Workflow syntax (`permissions`: lo no declarado queda en `none`) | https://docs.github.com/en/actions/reference/workflows-and-actions/workflow-syntax | 2026-10-09 |
| B212 | GitHub Docs — Workflow commands (`GITHUB_ENV`) | https://docs.github.com/en/actions/reference/workflows-and-actions/workflow-commands | 2026-10-09 |
| B213 | Renovate — manager `github-actions` (depType `container` y `service`) | https://docs.renovatebot.com/modules/manager/github-actions/ | 2026-10-09 |
| B214 | GitHub Enterprise Server 3.22 — Managing pre-receive hooks on your instance (delegación a administradores) | https://docs.github.com/en/enterprise-server@3.22/admin/enforcing-policies/enforcing-policy-with-pre-receive-hooks/managing-pre-receive-hooks-on-your-instance | 2026-10-09 |
| B215 | Microsoft Learn — Breaking change: `OutputType` set to `WinExe` for WPF and WinForms apps (SDK 5.0.100) | https://learn.microsoft.com/en-us/dotnet/core/compatibility/sdk/5.0/automatically-infer-winexe-output-type | 2026-10-09 |
| B216 | actions/runner-images — README (versión de la imagen en el log «Set up job») | https://github.com/actions/runner-images | 2026-10-09 |
| B217 | GitHub Actions — `setup-python` y etiquetas de `setup-dotnet` v6.0.0, `setup-node` v7.1.0, `setup-python` v7.0.0, `setup-uv` v10.2.0 (`git ls-remote`) | https://github.com/actions/setup-python · https://github.com/actions/setup-dotnet · https://github.com/actions/setup-node · https://github.com/astral-sh/setup-uv | 2026-10-09 |
~~~~


### P-19 · Anexo E: filas de E3-3 y EA-1

- **Hallazgos**: C2-30, C2-02, C2-07, C2-11, C2-12, C2-14.
- **Sección**: Anexo E, filas E3-3 y EA-1.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras**: prosa +12, evidencia y plantillas +0.
- **Verificación**: Cada ID del cuerpo tiene fila (72 citados); la fila de EA-1 nombra los pasos 1c, 2c, 8, 9 y 10 que existen en `Examples/A-plantillas/verificar.sh` tras P-23 L3.

1. Reemplazar

~~~~text
Corepack (Node 22/24/26); pnpm ≥ 11 y `pmOnFail` sin Corepack |
~~~~

por

~~~~text
Corepack (Node 22/24/26); pnpm 12 y `pmOnFail` sin Corepack |
~~~~

2. Reemplazar

~~~~text
| EA-1 | Todas las plantillas del Anexo A, juntas; `dotnet new console`, lock sólo en ejecutables, imagen A.10 |
~~~~

por

~~~~text
| EA-1 | Todas las plantillas del Anexo A, juntas; `dotnet new console`, variante B, lock en `Exe` y `WinExe`, imagen A.10 con la compuerta completa adentro, registro del entorno, `devcontainer up` |
~~~~


### P-20 · Anexo F: trazas, límites, Python 3.15, `builder.id` y fechas

- **Hallazgos**: C2-34, C2-16, C2-29, C2-49, C2-42, C2-04.
- **Sección**: Anexo F L3325–L3384.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras**: prosa +36, evidencia y plantillas +0.
- **Verificación**: R-03 remite a §3.7 y a §4–§11; P-09 a «n.3 de §4–§11»; `grep -c 'Formato de SBOM'` en el Anexo F → 0; `grep -c 'cómo completar .builder.id.'` → 0; `grep -c 'Datos volátiles al 2026-10-07'` → 0; el título nuevo coincide con su entrada del índice (P-01).

1. Reemplazar

~~~~text
## Anexo F. Límites y lo que no se verificó

Siguiendo la separación entre hechos e interpretaciones, esta lista reúne lo que la guía **no** afirma como hecho.
~~~~

por

~~~~text
## Anexo F. Trazas, límites y lo que no se verificó

Primero, qué pedido cubre cada sección; después, separados, los hechos que acotan el alcance, lo no verificado y las interpretaciones.
~~~~

2. Reemplazar

~~~~text
**Qué pedido cubre cada sección.** Los identificadores del campo `traces` del encabezado:
~~~~

por

~~~~text
**Qué pedido cubre cada sección.** Los identificadores del campo `traces` del encabezado: P-nn son los pedidos de contenido del caso; R-nn, los requisitos de forma del pedido, con su número (R-04 y R-05 regían el proceso de trabajo, no la guía).
~~~~

3. Reemplazar

~~~~text
| P-09 | Estrategias de la industria para .NET, Node.js y Python | «Qué propone la industria» de §4–§10 |
~~~~

por

~~~~text
| P-09 | Estrategias de la industria para .NET, Node.js y Python | n.3 («Qué propone la industria») de §4–§11 |
~~~~

4. Reemplazar

~~~~text
| R-03 | Snippets y preguntas guía que forman criterio | n.5, n.6 y n.9 de §3–§11; Anexo A |
~~~~

por

~~~~text
| R-03 | Snippets y preguntas guía que forman criterio | §3.7; n.5, n.6 y n.9 de §4–§11; Anexo A |
~~~~

5. Reemplazar

~~~~text
la DLL de `Debug` distinta de la de `Release` en la frontera A, y la versión de BuildKit del builder (v0.33.1).
~~~~

por

~~~~text
la DLL de `Debug` distinta de la de `Release` en la frontera A, y la versión de BuildKit del builder (v0.33.1). Tampoco los mensajes de deriva e integridad de Yarn 4.10.3, pnpm 10.18.0, uv 0.12.23 y Poetry 2.5.1 de la tabla de §7.3.
~~~~

6. Reemplazar

~~~~text
- El modo UTF-8 por defecto de Python 3.15 en una versión real (final prevista para el 2026-10-09).
~~~~

por

~~~~text
- El modo UTF-8 por defecto de Python 3.15.0, publicada el 2026-10-09 [B205]: el laboratorio usa 3.12.
~~~~

7. Reemplazar

~~~~text
- La firma sin clave con cosign y cómo completar `builder.id` en BuildKit (§9.2.4).
~~~~

por

~~~~text
- La firma sin clave con cosign (§9.2.4).
~~~~

8. Reemplazar

~~~~text
**Datos volátiles al 2026-10-07** (revisar antes de aplicar): SDK de .NET 10.0.401 vigente y .NET 11 en RC1; fin de soporte de .NET 8 y 9 el 2026-11-10;
~~~~

por

~~~~text
**Datos volátiles** (al 2026-10-07; los de B194–B217, al 2026-10-09; revisar antes de aplicar): SDK de .NET 10.0.401 vigente y .NET 11 en RC1; SDK 8.0.425, el del caso, y fin de soporte de .NET 8 y 9 el 2026-11-10;
~~~~

9. Reemplazar

~~~~text
Python 3.15.0 prevista para el 2026-10-09;
~~~~

por

~~~~text
Python 3.15.0 publicada el 2026-10-09;
~~~~

10. Reemplazar

~~~~text

**Formato de SBOM.** La guía recomienda un solo formato por solución, el que pida el consumidor, y CycloneDX cuando nadie pide otro (§9.2.3).
~~~~

por

~~~~text

~~~~


### P-21 · Control de cambios: celda breve, detalle debajo y fila 1.0.0

- **Hallazgos**: C2-36, C2-37, C2-40, C2-56.
- **Sección**: Control de cambios L3387–L3391.
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Δ palabras**: prosa -165, evidencia y plantillas +0.
- **Verificación**: Ninguna celda de la tabla supera 60 palabras (script de celdas del ciclo 2); `grep -c 'cerrado de cinco'` → 0; la fila 1.0.0 coincide con `version:` del encabezado.

1. Reemplazar el rango que va desde «| 1.0.0-rc.1 | 2026-10-09 | Revisión integral, ciclo 1. **Corrige**:» (incluido; ⏎ = salto de línea) hasta el final del archivo por:

~~~~text
| 1.0.0-rc.1 | 2026-10-09 | Revisión integral, ciclo 1 (abajo). |
| 1.0.0 | 2026-10-09 | Revisión integral, ciclo 2; versión vigente (abajo). |

**1.0.0-rc.1.** Corrige el *fallback* de Roslyn, la convención de BOM de .NET, la migración con *squash*, el costo de `disable`, el lock que calla `NU1603`, digest y bot donde se construye lo publicado, el nivel SLSA de un `builder.id` vacío, qué impide una rama protegida y la frontera de build políglota. Agrega ruta mínima y Práctica, mapa por contexto, preguntas situadas, trazas, glosario, B194–B204, E2-7, E2-8 y plantillas; fija cuatro marcas de juicio (§0.3).

**1.0.0.** Corrige las dos defensas contra `NU1603`, el lock de `WinExe`, la compuerta en subcarpetas y sus prerrequisitos, el devcontainer en host Linux, la variante B, pnpm 10, Python 3.15.0, la procedencia para 8b, los dos caminos de CI, qué no impiden un chequeo requerido y un `pre-receive`, y los extractos literales. Agrega A.17, A.18, la Práctica de §11 y §12, y B205–B217.
~~~~


## 4. P-22 · Capa de origen (bitácora): notas de solo agregado

- **Hallazgos**: C2-01, C2-02, C2-03, C2-05…C2-09, C2-11…C2-17, C2-23, C2-25, C2-26, C2-29, C2-30, C2-31, C2-40, C2-41, C2-48.
- **Capa**: `Bitcora/Nucleos/` y `Mesa/Ciclo-1/`. **Costo**: bajo. **Reversible**: sí (sólo se agregan líneas). **Δ palabras de la guía**: 0.
- **Formato**: cada nota se inserta como párrafo citado **al pie del bloque que contiene la frase ancla** (el mismo criterio de P-23 del ciclo 1). Antes de insertar, instantánea de los once archivos en `Ciclo-2/aplicacion/instantanea-origen/`.
- **Verificación**: `diff` de cada archivo contra la instantánea: sólo líneas `>`, 0 `<`; cada nota encontrada por su encabezado `Corrección mesa ciclo 2`; el `grep` de identificadores privados del contrato (R-PRIV) → 0 en las notas.

| # | Archivo | Ancla (bloque al pie del cual se inserta) | Nota a insertar |
|---|---|---|---|
| O-1 | `Nucleos/N4-congelamiento-de-dependencias.md` | la nota que empieza `> **Corrección mesa ciclo 1 (2026-10-09, C1-03, C1-58).**` (L99) | `> **Corrección mesa ciclo 2 (2026-10-09, C2-01, C2-03).** Se adoptan las dos defensas: `NU1603` como error en las dos políticas (A.4; con lock no se dispara, sin lock corta: `Mesa/Ciclo-2/evidencia-abogado-del-diablo/01-lock-por-defecto/`) y la comparación de `requested` con `resolved` en `compuerta.sh` (N7), sólo si `--locked-mode` pasó; con `Primitives 8.0.2` da `pide [8.0.2, ) y resolvió 9.0.0` y ROJO (`Mesa/Ciclo-2/evidencia-auditor/x7-ea1-propuesto/`, paso 8). **[criterio]** También marca una subida legítima, que se resuelve subiendo la `PackageVersion`. Cierra D-2. Guía §6.4, §7.2.1, A.4, A.11 (Ciclo-2, P-08, P-09, P-15).` |
| O-2 | `Nucleos/N4-congelamiento-de-dependencias.md` | la nota que empieza `> **Corrección mesa ciclo 1 (2026-10-09, C1-26).** El lock va **sólo en los ejecutables**` (L249) | `> **Corrección mesa ciclo 2 (2026-10-09, C2-02).** A.4b pasa a `'$(OutputType)' == 'Exe' Or '$(OutputType)' == 'WinExe'` y cierra D-1 (el SDK cambia `Exe` por `WinExe` en WinForms y WPF, [B215]); un WinForms con `EnableWindowsTargeting` recibe su lock (EA-1 paso 2c). Un proyecto de prueba no lo recibe por esta regla: su `OutputType=Exe` llega de `Microsoft.NET.Test.Sdk`, que el restore no evalúa (`Mesa/Ciclo-2/evidencia-senior-dotnet/lock-outputtype.txt`). Guía §7.2.1, A.4b (Ciclo-2, P-09, P-15).` |
| O-3 | `Nucleos/N3-fijacion-del-toolchain.md` | la nota `> **Corrección mesa ciclo 1 (2026-10-09, C1-31).**` (L91) | `> **Corrección mesa ciclo 2 (2026-10-09, C2-30, C2-41).** pnpm hace cumplir `packageManager` por sí mismo ya en la 10: `managePackageManagerVersions` (descarga, por defecto) y `packageManagerStrictVersion=true` (falla) [B206]; la 11 los unifica en `pmOnFail` [B196] (E1 de `Mesa/Ciclo-2/Informe-adhoc-AH-001.md`, AH-001-01: pnpm 10.18.0, `ERROR This project is configured to use v9.15.0 of pnpm`). Yarn depende de Corepack o de `yarnPath` (`yarn set version --yarn-path`) [B207]; [B81] es de pnpm. El diagrama se lee «pnpm (solo) · Yarn con Corepack o yarnPath». Guía §6.2.3, §6.6 (Ciclo-2, P-08).` |
| O-4 | `Nucleos/N2-politica-de-texto-y-remediacion.md` | el bloque `ini` que termina con `# Variante B: heredado ya convertido a UTF-8 CON BOM.` / `# [*.cs]` / `# charset = utf-8-bom` (L139–L142) | `> **Corrección mesa ciclo 2 (2026-10-09, C2-12).** La variante B cubre `[*.{cs,csproj,props,targets}]`: con sólo `[*.cs]`, los `.csproj` con BOM que crea el SDK quedan en violación; con la ampliada, y los `Directory.Build.*` guardados con BOM, 0 violaciones (`Mesa/Ciclo-2/evidencia-auditor/x5-variante-b/`; EA-1 paso 1c). Guía A.1, §5.2.3, §5.6, §5.9, B.2 (Ciclo-2, P-07, P-15, P-16).` |
| O-5 | `Nucleos/N5-entornos-en-contenedores.md` | la nota `> **Corrección mesa ciclo 1 (2026-10-09, C1-20, C1-21).**` (L112) | `> **Corrección mesa ciclo 2 (2026-10-09, C2-11, C2-13, C2-17, C2-23).** Cuatro filas de la guía (§6.4, §9.4, §10.2.5 y B.4) seguían pidiendo digest en el devcontainer: pasan a «etiqueta fija verificada por `global.json` o la receta de la CI». El `postCreateCommand` agrega `git config --global --add safe.directory ${containerWorkspaceFolder}` (CLI 0.89.0, host Linux: `outcome: success`, `Mesa/Ciclo-2/evidencia-auditor/x4-devcontainer-safe-directory/`). Para 8a vale también el runner alojado con acciones de *setup* por SHA (capa 4 en el log «Set up job» [B216]); el `container:` de un workflow no lo cubre ningún ecosistema de Dependabot [B107] y lo mueve el workflow que publica la imagen **[criterio]**. Guía §8.2.2, §8.5, A.9, A.12 (Ciclo-2, P-10, P-15).` |
| O-6 | `Nucleos/N6-procedencia-y-trazabilidad.md` | la lista que contiene `- `builder.id` **vacío**: una build local no tiene identidad de plataforma.` (L261) | `> **Corrección mesa ciclo 2 (2026-10-09, C2-15, C2-16).** `builder.id` se completa con el parámetro `builder-id=` de `--provenance` [B208], y su valor lo escribe quien invoca la build (`Mesa/Ciclo-2/evidencia-adhoc-AH-002/e1-builder-id.txt`: sin parámetro `''`; con él, el valor pasado; con `GITHUB_*` y sin parámetro, `''`): identifica a la plataforma sólo junto al firmante. La guía comprime §9.2.4 como rama de 8b (599 palabras) y lleva la tabla de plataformas a §9.3 (Ciclo-2, P-11).` |
| O-7 | `Nucleos/N6-procedencia-y-trazabilidad.md` | el bloque `sh` que contiene `export SOURCE_DATE_EPOCH=$(git log -1 --pretty=%ct)` (L356–L361) | `> **Corrección mesa ciclo 2 (2026-10-09, C2-26).** En GitHub Actions cada `run:` es un shell propio: un `export` como paso aparte no llega a los siguientes; se escribe en `GITHUB_ENV` [B212]. El `export` vale dentro de un mismo script. Guía §9.5, A.12 (Ciclo-2, P-11, P-15).` |
| O-8 | `Nucleos/N7-compuertas-y-gobierno.md` | la tabla que contiene la fila `\| ESC-04 Devcontainer \| Hook dentro del contenedor + CI \|` (L335) | `> **Corrección mesa ciclo 2 (2026-10-09, C2-05…C2-09, C2-25).** (a) `--staged` acota sólo el paso de texto: toolchain y grafo miran el disco, y un lock sin marcar pasa el hook y la CI lo rechaza (`Mesa/Ciclo-2/evidencia-lector-sin-contexto/salida-hook-lock-sin-stage.txt`); (b) `compuerta.sh` busca `.python-version` y los locks con `git ls-files`, nombra el paquete EditorConfig si falta y compara `requested` con `resolved`; E7-01, E7-03 y E7-07 sin cambios de veredicto (`Mesa/Ciclo-2/evidencia-auditor/x3-regresion-n7/`); (c) creados desde Windows, hook y compuerta necesitan `git update-index --chmod=+x`; (d) el `.pre-commit-config.yaml` lleva `minimum_pre_commit_version: "4.4.0"`. C2-05 se resolvió por síntesis (`Mesa/Ciclo-2/03-Parches.md` §1.1). Guía §10.2.2, §10.4, §10.5, A.11 (Ciclo-2, P-12, P-15).` |
| O-9 | `Nucleos/N8-integracion-poliglota.md` | el párrafo que empieza `**La compuerta es lo que hace «único» al punto de verdad.**` (L175) | `> **Corrección mesa ciclo 2 (2026-10-09, C2-06, C2-14, C2-48).** `verificar.sh` es la compuerta de esta solución, con sus rutas escritas: copiada a `tools/ci/` de otro repo da `texto: OK` ante un cp1252 y aborta (`Mesa/Ciclo-2/Informe-arquitecto-software.md`, X1), así que la guía ya no la ofrece como pieza copiable (A.11 usa la de N7, que encuentra los proyectos). `registrar-entorno.sh` deja de escribir `imagen=desconocida`; la plantilla copiable del registro es A.17. El comentario de `Saludo.csproj` nombra los dos usos de `ConstruirPoliglota=true` (F5 y la prueba de regresión). Guía §10.2.2, §11.5, A.17 (Ciclo-2, P-12, P-13, P-15).` |
| O-10 | `Nucleos/N1-codificacion-y-finales-de-linea.md` | la lista que contiene `- **[fabricante]** `open()` sin `encoding=` depende del *locale* hasta 3.14.` (L178) | `> **Corrección mesa ciclo 2 (2026-10-09, C2-29, C2-31).** Python 3.15.0 se publicó el 2026-10-09 con PEP 686 activo [B205]: desde 3.15, `open()` sin `encoding=` usa UTF-8; 3.14 y anteriores siguen dependiendo del *locale*. «Sólo Python falla siempre ante cp1252» se precisa: falla con el fuente en toda plataforma, aun en un comentario, salvo un cp1252 cuyos bytes forman UTF-8 válido (E1 de `Mesa/Ciclo-2/Informe-adhoc-CAT-FORMAL.md`, CAT-FORMAL-02, Python 3.13.5); la condición de plataforma es de Roslyn. Guía §4.2.4, §4.3, §11.2.2, Anexo F (Ciclo-2, P-06, P-13, P-20).` |
| O-11 | `Mesa/Ciclo-1/03-Parches.md` y `Mesa/Ciclo-1/05-Aplicacion.md` | al final de cada archivo | `> **Nota de solo agregado (ciclo 2, 2026-10-09, C2-40).** P-03 3e decía «Son las únicas cinco marcas» y §7 de la aplicación, «Sólo las cinco de §0.3»: la tabla de §0.3 define cuatro marcas de juicio, en negrita, y tres referencias sin negrita. La guía 1.0.0 dice «cuatro marcas de juicio» (Ciclo-2, P-02).` |

## 5. P-23 · Laboratorio (`Examples/`)

- **Hallazgos**: C2-01, C2-02, C2-03, C2-05, C2-06, C2-07, C2-08, C2-11, C2-12, C2-13, C2-14, C2-18, C2-26, C2-28, C2-48, C2-53.
- **Capa**: laboratorio. **Costo**: alto (re-correr EA-1 completo, N7 y E8-6). **Reversible**: sí, con la instantánea de `Examples/` (condición de riesgo, §8).
- **Fuentes ya probadas**: [`evidencia-auditor/propuestas/`](evidencia-auditor/propuestas/) (`compuerta.diff`, `plantillas.diff`) y [`evidencia-auditor/x7-ea1-propuesto/`](evidencia-auditor/x7-ea1-propuesto/) (`repo/`, `verificar.sh`, `salida.txt`): el `repo/` de x7 es exactamente el `Examples/A-plantillas/repo/` que resulta de esta tabla, y sus bloques coinciden byte a byte con el Anexo A de la guía parcheada (A.1, A.4, A.4b, A.9, A.10, A.11, A.12, A.17, A.18: 9 de 9 iguales).

| # | Archivo | Cambio | Fuente | Re-correr y esperar |
|---|---|---|---|---|
| L1 | `N7-compuertas-y-gobierno/compuerta/compuerta.sh` | descubrimiento de `.python-version` y locks con `git ls-files`; prerrequisito `import editorconfig`; `requested` = `resolved` tras un `--locked-mode` exitoso | `evidencia-auditor/propuestas/compuerta.diff` (98 líneas) | `bash correr-todo.sh` de N7: veredictos y códigos iguales a las salidas versionadas (X3: E7-01, E7-03, E7-07 Node y Python) |
| L2 | `N7-compuertas-y-gobierno/compuerta/probar-prerrequisitos.sh` | caso (d): sin el paquete EditorConfig, simulado con un módulo que falla al importarse | `evidencia-auditor/x6-prerrequisitos/probar-prerrequisitos.sh` (tres líneas del final) | `salidas/e7-prerrequisitos-de-la-compuerta.txt` con `falta el paquete EditorConfig de Python (…; prerrequisito, no una violación)` y rc=1 |
| L3 | `A-plantillas/repo/`: `Directory.Build.props`, `Directory.Build.targets`, `imagen/Dockerfile`, `.devcontainer/devcontainer.json`, `.editorconfig`, `tools/ci/compuerta.sh` (esqueleto), `.github/workflows/ci.yml`; nuevos `tools/ci/registrar-entorno.sh` (modo `100755`) y `.gitignore` | los bloques A.1, A.4, A.4b, A.9, A.10, A.11, A.12, A.17 y A.18 de la guía parcheada | `evidencia-auditor/x7-ea1-propuesto/repo/` (o `aplicacion/anexoA.py` del ciclo 1, ampliado a A.17 y A.18) | `anexoA.py`: 22 de 22 bloques iguales byte a byte |
| L4 | `A-plantillas/verificar.sh` | cabecera («pasos 1 a 10»; `npx` en el host); variables `EXAMPLES` y `COMPUERTA`; pasos 1c, 2c, 8, 9 y 10 | `evidencia-auditor/x7-ea1-propuesto/verificar.sh` | `salidas/EA-1-plantillas.txt` con lo de `x7-ea1-propuesto/salida.txt`: paso 1 «25 archivo(s)»; 1c, 2 y 0 violaciones; 2c `packages.lock.json: SI`; 8 VERDE, ROJO `¿cp1252?`, ROJO `pide [8.0.2, ) y resolvió 9.0.0`, ROJO npm; 9 registro sin campos vacíos; 10 `"outcome":"success"` y `core.hooksPath=.githooks`. Las líneas de A.17 (commit y hash de la DLL) se copian de esa salida |
| L5 | `N8-integracion-poliglota/solucion/src/Saludo/Saludo.csproj` | comentario de `ConstruirPoliglota`: `<!-- true en la estación (F5) y en la prueba de regresión de la CI (§11.2.5); build.sh pasa false -->` | P-13, op 11 | el extracto de §11.5 coincide con el archivo; DLL de E8-3/E8-5 sin cambio (es un comentario) |
| L6 | `N8-integracion-poliglota/solucion/registrar-entorno.sh` | `echo "imagen=${IMAGEN_DIGEST:-NO DECLARADA (la CI la pasa en IMAGEN_DIGEST)}"` en lugar de `desconocida` | C2-14 (costo-beneficio) | `grep -c desconocida` → 0 en `solucion/` |
| L7 | `N8-integracion-poliglota/e6-sbom-unificado/comando-de-la-guia.sh` | `--provenance=mode=max,version=v1` | `evidencia-auditor/x5-version-v1/` | `salidas/E8-6-comando-de-la-guia.txt`: rc=0, `https://slsa.dev/provenance/v1`, `builder.id: ''`, cinco materiales por digest (con un `DOCKER_CONFIG` temporal que enlaza `cli-plugins`, §0.4) |
| L8 | `README.md` de `Examples/`, de `A-plantillas/` y de N7 | sección «Ampliaciones de la revisión (ciclo 2, 2026-10-09)»: pasos nuevos de EA-1, compuerta con descubrimiento, caso (d); en N7, la fila de `compuerta.sh` dice «busca `.python-version` y locks en todo lo versionado» | — | los README nombran sólo archivos que existen |

## 6. Evidencia nueva del auditor (`evidencia-auditor/`)

| ID | Carpeta | Qué prueba | Resultado |
|---|---|---|---|
| X0 | `x0-docker-config/` | C2-24: un `DOCKER_CONFIG` vacío cambia `buildx`; enlazar `cli-plugins` lo conserva | v0.35.0 → 0.13.1+ds1 con uno vacío; v0.35.0 y una sola línea de digest con el enlace |
| X2 | `x2-compuerta-propuesta/` | C2-01…C2-03, C2-07, C2-14, C2-53: plantillas propuestas en la imagen de A.10 con el paquete EditorConfig | VERDE con proyectos en subcarpetas; `¿cp1252?`; `pide [8.0.2, ) y resolvió 9.0.0` sin `NU1603`; `WinExe` con lock; `EUSAGE` en `web/`; imagen sin el paquete → «falta el paquete EditorConfig»; registro del entorno; YAML de A.12 válido con `packages: read` y `credentials` |
| X3 | `x3-regresion-n7/` | C2-05/06: la compuerta nueva no cambia N7 | E7-01, E7-03, E7-07 Node y Python: veredictos y códigos iguales |
| X4 | `x4-devcontainer-safe-directory/` | C2-11 | `devcontainer up` (CLI 0.89.0), host Linux: `outcome: success`, uid 0, `core.hooksPath=.githooks` |
| X5 | `x5-variante-b/` y `x5-version-v1/` | C2-12 y C2-28 | A tal cual: 4 violaciones; B ampliada: 2 (los `Directory.Build.*` sin BOM) y 0 con BOM. `version=v1`: rc=0, `slsa.dev/provenance/v1`, `builder.id ''`, cinco materiales |
| X6 | `x6-prerrequisitos/` | C2-07 (b) | caso (d): «falta el paquete EditorConfig de Python», rc=1 |
| X7 | `x7-ea1-propuesto/` | todo el Anexo A propuesto, junto | EA-1 de diez pasos rc=0 (salida completa en la carpeta) |
| — | `propuestas/` | diffs para el laboratorio | `compuerta.diff`, `plantillas.diff` |
| — | `simulacion/` | P-01…P-21 aplicados a una copia de la guía | 0 anclas fallidas; `guia-parcheada.md`, `deltas.json` |

Fuentes consultadas el 2026-10-09 (filas B205–B217 de P-18), con la frase que sostiene cada afirmación nueva:

| Fuente | Frase verificada |
|---|---|
| B205 python.org, Python 3.15.0 | «Release Date: October 9, 2026»; «stable release»; «Python now uses UTF-8 as the default encoding» |
| B206 pnpm 10.x settings | `managePackageManagerVersions` (default `true`) «automatically download and run the version of pnpm specified in the `packageManager` field»; `packageManagerStrictVersion` (default `false`) «will fail if its version doesn't exactly match» |
| B207 yarnpkg, `set version` | con `--yarn-path`, «downloads the release … stores it within your project, and references it via the `yarnPath` setting» |
| B208 Docker, SLSA definitions | «This value can be set using the `builder-id` attestation parameter» |
| B209 Git for Windows, Known issues | conversión de opciones que empiezan con `/`; «you need to set the environment variable `MSYS_NO_PATHCONV` temporarily» |
| B210 GitHub, Container registry | «When you first publish a package, the default visibility is private» |
| B211 GitHub, Workflow syntax | «all of those that are not specified are set to `none`» |
| B212 GitHub, Workflow commands | «make an environment variable available to any subsequent steps … writing this to the `GITHUB_ENV` environment file» |
| B213 Renovate, manager github-actions | depType `container`: «A Docker image specified in a job's `container:` field»; la página no documenta actualizar su digest (de ahí el **[no verificado]**) |
| B214 GHES 3.22, managing pre-receive hooks | «Administrators can enable and disable this hook» (delegación a organizaciones) |
| B215 Microsoft Learn, WinExe | «when `OutputType` is set to `Exe`, it is automatically changed to `WinExe` for WPF and Windows Forms apps» (SDK 5.0.100) |
| B216 actions/runner-images | «To find out which image version … see `Set up job` (GitHub Actions) … step log» |
| B217 `git ls-remote` | `setup-dotnet` v6.0.0 `a98b5685…`, `setup-node` v7.1.0 `949feb24…`, `setup-python` v7.0.0 `5fda3b95…`, `setup-uv` v10.2.0 `c18668ad…`; `setup-python` lee `python-version-file`, `setup-uv` acepta `working-directory` (`action.yml` de cada uno) |

También se re-consultó [B177] (2026-10-09): «you can select an app that has recently set this check as the expected source of status updates»; «If you select "any source", you can still manually verify the author of each status». Y `releases.json` de .NET 8 [B62]: `latest-sdk 8.0.425`, `eol-date 2026-11-10`, `support-phase maintenance`.

## 7. Cobertura: hallazgo → parche

| Hallazgo | Parches |
|---|---|
| C2-01 | P-08, P-09, P-15, P-16, P-22, P-23 |
| C2-02 | P-09, P-15, P-16, P-18, P-19, P-22, P-23 |
| C2-03 | P-09, P-12, P-22, P-23 |
| C2-04 | P-08, P-15, P-18, P-20 |
| C2-05 | P-07, P-12, P-15, P-22, P-23 |
| C2-06 | P-12, P-13, P-15, P-22, P-23 |
| C2-07 | P-12, P-15, P-19, P-22, P-23 |
| C2-08 | P-07, P-15, P-16, P-22, P-23 |
| C2-09 | P-12, P-22 |
| C2-10 | P-02, P-18 |
| C2-11 | P-10, P-15, P-19, P-22, P-23 |
| C2-12 | P-07, P-15, P-16, P-19, P-22, P-23 |
| C2-13 | P-10, P-14, P-15, P-18, P-22, P-23 |
| C2-14 | P-01, P-11, P-13, P-14, P-15, P-16, P-19, P-22, P-23 |
| C2-15 | P-11, P-22 |
| C2-16 | P-11, P-18, P-20, P-22 |
| C2-17 | P-10, P-15, P-18, P-22 |
| C2-18 | P-15, P-18, P-23 |
| C2-19 | P-12 |
| C2-20 | P-12, P-18 |
| C2-21 | P-13 |
| C2-22 | P-04 |
| C2-23 | P-08, P-11, P-12, P-16, P-22 |
| C2-24 | P-02, P-10 |
| C2-25 | P-12, P-22 |
| C2-26 | P-11, P-15, P-16, P-18, P-22, P-23 |
| C2-27 | P-02, P-03, P-13 |
| C2-28 | P-13, P-23 |
| C2-29 | P-06, P-18, P-20, P-22 |
| C2-30 | P-08, P-18, P-19, P-22 |
| C2-31 | P-06, P-22 |
| C2-32 | P-02, P-08, P-11, P-12, P-13 |
| C2-33 | P-02, P-14 |
| C2-34 | P-01, P-20 |
| C2-35 | P-12, P-13, P-17 |
| C2-36 | P-21 |
| C2-37 | P-02, P-03, P-05, P-06, P-07, P-08, P-09, P-10, P-11, P-12, P-13, P-21 |
| C2-38 | P-05, P-12 |
| C2-39 | P-11 |
| C2-40 | P-02, P-21, P-22 |
| C2-41 | P-08, P-18, P-22 |
| C2-42 | P-09, P-20 |
| C2-43 | P-13 |
| C2-44 | P-12 |
| C2-45 | P-11 |
| C2-46 | P-09 |
| C2-47 | P-09 |
| C2-48 | P-13, P-22, P-23 |
| C2-49 | P-01, P-02, P-06, P-18, P-20 |
| C2-50 | P-07, P-08, P-09, P-10, P-11, P-12, P-13 |
| C2-51 | P-02, P-08 |
| C2-52 | P-04, P-13, P-17 |
| C2-53 | P-01, P-15, P-23 |
| C2-54 | P-11, P-12 |
| C2-55 | P-14 |
| C2-56 | P-01, P-21 |
| C2-57 | P-08, P-15 |
| C2-58 | P-06 |

## 8. Orden de aplicación y chequeos de cierre

1. **Condición de riesgo** (voto del juez de riesgo): `Guides/Metodologia-Entorno-Desarrollo/` no está bajo git; antes de tocar nada, copiar la guía y `Examples/` a `Ciclo-2/aplicacion/antes/` y registrar su `sha256sum`.
2. P-22 (capa de origen), con su instantánea.
3. P-18 (bibliografía), para que existan B205–B217 cuando los citen los demás.
4. P-23 (laboratorio): L1–L8, con sus corridas. Si una corrida no da lo esperado, el op de la guía que la cita no se aplica y se registra como regresión (marco §5.6).
5. P-01…P-17, P-19…P-21, en orden: es el orden en que `simulacion/gen.py` los aplicó sin fallas.
6. Chequeos mecánicos, ya pasados sobre `simulacion/guia-parcheada.md`: 217 `[Bnn]` definidas = 217 citadas; 0 anclas internas rotas; toda referencia `§n.m` y `A.n` existe (las tres que no, `§2.6`, `§12.2`, `§12.9.6`, son de documentos externos, como en el ciclo 1); 125 marcas fuera de código, como antes, todas en negrita y del vocabulario cerrado (cuatro **[no verificado]** pasan a dato verificado y entran cuatro **[observado]** con versión); los 77 IDs de experimento siguen citados; los 7 bloques YAML válidos (PyYAML 6.0.3); los 11 diagramas renderizan con `minlag/mermaid-cli`; 0 apariciones de `Windows + VS |`, `pnpm ≥ 11`, `mismo diseño`, `únicas cinco`, `prevista para el 2026-10-09`, `Sólo Python falla siempre`, `Este comando no pide`; §9.2.4 ≤ 600 palabras; privacidad (`grep` del contrato) → 0. Se repiten sobre la guía real después de aplicar.
7. Control de cambios y `version: 1.0.0` (P-01, P-21) **al final**, y sólo con el lote aprobado.

## 9. Lo que no se adopta, y por qué

| Ítem | Lo que no se hace | Motivo |
|---|---|---|
| C2-02 | Aviso de la compuerta ante un ejecutable sin lock | Exige evaluar cada proyecto con MSBuild en cada corrida (lento, y frágil en el hook); A.4b con `WinExe`, EA-1 paso 2c y B.2 cubren la regla. Queda como mejora si aparece otro `OutputType`. |
| C2-05 | editorconfig-checker como paso de texto **por defecto** | Empate 2-2; la síntesis de §1.1 lo deja como reemplazo declarado. Si la mesa de aprobación no la acepta, segunda ronda. |
| C2-09 | Hacer fallar el hook si hay un manifiesto marcado con su lock sin marcar | Costo y riesgo votaron declarar el límite; el hook podría bloquear commits legítimos sin experimento de los dos casos. |
| C2-13 | Que el registro del entorno lea la versión de la imagen del runner | Ninguna fuente de primera mano documenta una variable con ese dato; queda en el log «Set up job» [B216] y así se declara (C2-Q07 sigue abierta). |
| C2-35 | Reemplazo global de «registro» y «manifiesto» | Prohibido por riesgo (72 y 31 apariciones, anclas y citas literales); se fijan los términos y se corrigen las ocurrencias señaladas. Las dos «registro de entorno» que quedan están dentro de bloques que copian archivos del laboratorio (A.16 y el extracto de `publicar.sh`) y no se tocan. |
| C2-42 | Script versionado para los mensajes de Yarn, pnpm, uv y Poetry | Se rotulan **[observado]** con versión y se anotan en el Anexo F como mediciones sin script; sumarlos a E4-4/E4-5 queda para un ciclo próximo. |
| C2-Q04, C2-Q06 | Verificación en una estación Windows real | No hubo host Windows. Todo lo de Windows sigue **[no verificado]** y así figura en el Anexo F. |
