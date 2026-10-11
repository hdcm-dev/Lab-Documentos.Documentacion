# Mesa · Ciclo 1 · 03 — Parches del cuerpo auditor

> Fecha: 2026-10-09. Rol: cuerpo auditor (marco `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §4.4 y §5.4). **No vota sus propios parches**: los somete a la mesa de aprobación (§5.5).
> Artefacto: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (1.0.0-borrador, 3060 líneas). «L*n*» = línea de esa versión. Insumos: `01-Consolidado.md`, los cinco `02-Voto-*.md` y los doce `Informe-*.md` de esta carpeta.
> Alcance: los 48 ítems con veredicto PROCEDE (C1-01 a C1-48) y el lote S4 completo (C1-49 a C1-58), que el auditor decide aplicar.
> Evidencia nueva del auditor: `evidencia-auditor/` (README con el índice). Fuentes nuevas consultadas el **2026-10-09** (B194–B204).

## 0. Cómo leer este documento

- Cada parche (`P-nn`) agrupa los hallazgos que tocan **la misma sección** de la guía (marco §5.4: parches solapados se fusionan). Un hallazgo que toca varias secciones aparece en varios parches; la tabla de cobertura (§3) dice dónde.
- **Texto exacto.** «Reemplazar» cita un fragmento único de la guía (búsqueda literal) y da el texto nuevo completo. «Insertar tras» cita la línea ancla. Las celdas de tabla se reemplazan como fila entera.
- **Capa de origen.** Si el defecto nació en un núcleo o en la integración de la bitácora, el parche P-23 lo corrige allí (marco §5.5, «chequeo obligatorio»).
- **Marcas.** Todo texto nuevo usa ya el vocabulario cerrado de P-03 (C1-40): `**[criterio]**`, `**[no verificado]** (motivo)`, `**[observado]**`, `**[interpretación]**`.
- **Orden de aplicación** (dependencias de los votos): P-23 (origen) → P-19 (bibliografía, para que existan B194–B204) → P-22 (laboratorio; se vuelven a correr los experimentos tocados) → P-01…P-18 en orden de sección → P-20, P-21 → P-24. Ninguno se aplica sin su verificación (§5.6 del marco).

## 1. Decisiones de dirección en las contradicciones

El jurado votó PROCEDE en las cinco; la dirección la indicaron cuatro jueces en su fundamento (el de evidencia se abstuvo de dirección).

| Ítem | Coherencia | Costo-beneficio | Impacto | Riesgo | Resultado | Lo que aplica el auditor |
|---|---|---|---|---|---|---|
| C1-03 | (b) | (a) | (a) | (a) | **(a) 3-1** | Lock por defecto en .NET con `disable` y su costo declarado, **más** la política sin lock completa en una tabla de §6.4. Así se cumple también lo que coherencia invoca de CI-05 («la guía presenta la elección»): las dos políticas quedan escritas, con una por defecto. |
| C1-08 | (a) | (a) | (b) | (a) | **(a) 3-1** | Script propio reparado (C1-05/06/07) y editorconfig-checker en §5.2.5 como alternativa con sus límites. |
| C1-10 | (a) | (b) | (b) | (a) | **Empate 2-2** | **Síntesis**: se conserva la tabla y sus remisiones (lo que pedían coherencia y riesgo), se le agrega una columna «Lo decide» que separa lector de convención (lo que pedían costo e impacto), la rama «heredado todavía en cp1252» y la corrección de `*.csproj` con E2-6. Se marca para la mesa de aprobación: si la síntesis no se acepta, el empate de dirección pasa a `INSUFICIENTE` y a segunda ronda (marco §5.3). |
| C1-18 | (b) | (b) | (b) | (b) | **(b) 4-0** | §12 paso 8a (registro del entorno + SBOM, todo equipo) y 8b (procedencia firmada si hay consumidor externo). |
| C1-21 | (b) | (b) | (b) | (b) | **(b) 4-0** | Digest + bot donde se construye lo publicado; en el devcontainer, etiqueta fija de SDK y SO + `global.json`, o la misma receta que la imagen de CI (sus bases por digest las mantiene el bot de la CI). |

Ítems con un NO_PROCEDE del juez de impacto (4-1, proceden): **C1-46** se resuelve **definiendo las trazas dentro de la guía** (Anexo F), no quitándolas, porque `traces` es parte del aparato común de las guías propias de la colección (ia-db, `00_MASTER-INDEX.md`, «Dos linajes»); **C1-47** se aplica con el alcance mínimo que pidió costo-beneficio (§5.2.6 y §12, no §10.2.2).

Pregunta de nivel C cerrada por el auditor: **C1-Q09** (¿se repite con SDK 10.0.400 el `NU1603` desarmado por el lock?) — sí: `evidencia-auditor/nu1603-sdk10/salida.txt`.

---

## 2. Parches

### P-01 · Front matter y apertura

- **Hallazgos**: C1-43 (status), C1-46 (trazas, ver P-21), C1-40 (fecha de fuentes).
- **Capa de origen**: guía. **Costo**: bajo. **Reversible**: sí. **Derivados**: ninguno.

1. Reemplazar `status: borrador (pendiente de relectura integral de la mesa)` por `status: borrador`.
2. Reemplazar `fuentes_consultadas: 2026-10-07` por `fuentes_consultadas: "2026-10-07; B194–B204: 2026-10-09"`.
3. `traces:` **se conserva**; P-21 agrega su resolución en el Anexo F.
4. Reemplazar `Todo lo que la guía presenta como salida de un comando se ejecutó el 2026-10-07 en el laboratorio` por `Todo lo que la guía presenta como salida de un comando se ejecutó el 2026-10-07 (las ampliaciones de la revisión, el 2026-10-09) en el laboratorio`.
5. Reemplazar `(193 fuentes, Anexo D), más 71 experimentos ejecutables (Anexo E).` por `(204 fuentes, Anexo D), más 73 experimentos ejecutables (Anexo E).`

**Verificación**: `grep -c 'de la mesa' GUIA` → 0 (junto con P-21); `grep -n '^traces:' GUIA` → 1 línea; `grep -c '204 fuentes' GUIA` → 1.

### P-02 · Índice

- **Hallazgos**: C1-42 (Partes inexistentes), C1-54 («fix»).
- **Capa**: guía. **Costo**: bajo. **Reversible**: sí.

1. Borrar las tres líneas `- ***Parte I — El problema y el mapa***`, `- ***Parte II — Cada capa, en los tres ecosistemas***` y `- ***Parte III — Integración***` (opción de menor costo votada; ningún enlace interno apunta a ellas).
2. Reemplazar `qué pasó, por qué Windows lo tapaba, qué resolvió el fix y qué dejó abierto.` por `qué pasó, por qué Windows lo tapaba, qué resolvió la corrección y qué dejó abierto.`
3. Reemplazar en la entrada de §10 `la compuerta única, la CI como árbitro` por `la compuerta única y su alcance, la CI como árbitro`.

**Verificación**: `grep -c 'Parte I' GUIA` → 0; las entradas `**[n. …](#…)**` del índice coinciden en orden con los encabezados `##` (script de slugs del ciclo).

### P-03 · §0 Cómo usar esta guía

- **Hallazgos**: C1-45 (exclusión de métodos y marcos), C1-55 (enlace a la guía de Despliegue), C1-24 (dos velocidades), C1-23 (ruta mínima y «Práctica»), C1-40 (vocabulario de marcas), C1-27 (comandos de §0.4), C1-06 (recuadro «Desde Windows»).
- **Capa**: guía. **Costo**: medio (las marcas tocan unas cien apariciones). **Reversible**: sí. **Derivados**: todas las secciones (marcas), Anexo E (ruta mínima).

**3a. §0.1, L61.** Reemplazar el párrafo que empieza `Quedan fuera: el despliegue y la operación en producción` por:

```markdown
Quedan fuera: el despliegue y la operación en producción (la guía termina en el artefacto construido y su procedencia; el procedimiento de verificar antes de instalar corresponde a la [guía de Despliegue](../Despliegue/) de esta misma colección), otros ecosistemas (Java, Go, Rust), las comparativas comerciales de productos de CI y la recomendación de una herramienta única «para todo». Tampoco compara los enfoques que reemplazan el entorno completo: sistemas de build herméticos que gestionan las herramientas como fuente (la definición de §3.1 se toma de uno de ellos, Bazel [B04]) o gestores declarativos del entorno de todo el sistema. **[criterio]** La guía parte de un repositorio que se edita con Visual Studio en Windows y se construye con las CLI nativas de cada ecosistema, y adopta un enfoque que conserva esas herramientas: archivos nativos de cada ecosistema, una compuerta y una imagen por digest. Quien evalúe un enfoque de entorno completo necesita otra comparación, con su propia evidencia; ésta no la hizo.
```

**3b. §0.2, fila «Recorrido» de la tabla.** Reemplazar `| **Recorrido** | §1 → §12 en orden; correr los experimentos que cada capítulo cita | Quien llega con el problema del caso y quiere entenderlo de raíz |` por:

```markdown
| **Recorrido** | §1 → §12 en orden. En §3, las secciones 3.1, 3.2, 3.4 y 3.7 (las tablas de 3.3, 3.5 y 3.6 son de consulta: se vuelve a ellas al terminar §10). Al cierre de cada capítulo, su **Práctica**, sobre la ruta mínima de abajo | Quien llega con el problema del caso y quiere entenderlo de raíz |
```

**3c. §0.2, L70.** Reemplazar `→ **Criterios de calidad** (cómo se distingue una versión buena de una pobre) → **Plantilla** (remite al Anexo A).` por `→ **Criterios de calidad** (cómo se distingue una versión buena de una pobre) → **Plantilla** (remite al Anexo A) → **Práctica** (dos consignas sobre experimentos que ya existen, con la respuesta esperada).`

**3d. §0.2, insertar tras el párrafo de L70:**

```markdown
**Ruta mínima del Recorrido.** Un experimento por capítulo, el que sostiene la idea central; los demás se corren al consultar. Cada carpeta de [`Examples/`](Examples/) dice cómo correrlo. Sólo N0 tiene tiempo medido: alrededor de un minuto y medio con las imágenes ya descargadas; los demás dependen sobre todo de la primera descarga de imágenes.

| Capítulo | Experimento | Qué tiene que quedar claro |
|---|---|---|
| §4 | E1-01 | El mismo `.cs` en cp1252: literal corrupto, identificador que no compila |
| §5 | E2-2 | Una migración de cien archivos que se revisa con un script |
| §6 | E3-1 | Qué SDK elige cada `global.json` y cuál falla |
| §7 | E4-2 | CPM sin lock no garantiza la versión pedida; el lock calla el aviso |
| §8 | E5-1 | El contenedor no arregla los bytes del fuente |
| §9 | E6-2 | Qué hace falta para que dos builds den el mismo hash |
| §10 | E7-1 | El hook se saltea; la CI no |
| §11 | E8-1 | Qué se rompe primero en un repo con los tres ecosistemas |
```

**3e. §0.3, tabla de marcas.** Reemplazar la fila `| **[observado]** | Comportamiento medido en el laboratorio que la documentación del fabricante no describe; puede cambiar sin aviso. |` por las dos filas:

```markdown
| **[observado]** | Comportamiento medido en el laboratorio que la documentación del fabricante no describe; se dice siempre con qué versión se observó, porque puede cambiar sin aviso. |
| **[interpretación]** | Inferencia de un hecho que no se observó directamente: compatible con la evidencia citada, pero no medida. El Anexo F las lista. |
```

E insertar tras la tabla, antes de `Un bloque de salida es un extracto literal`:

```markdown
Son las únicas cinco marcas, siempre en negrita. El motivo o el matiz va fuera del corchete: **[no verificado]** (requiere Windows), **[criterio]** (sobre la base del fabricante).
```

**3f. Normalización de marcas en todo el cuerpo (C1-40).** Reemplazos literales, fuera de los bloques de código:

| Forma actual | Forma nueva | Apariciones (L) |
|---|---|---|
| `**[no verificado en Windows]**` | `**[no verificado]** (requiere Windows)` | 442 (la reescribe P-07), 641 (P-08), 2050 (P-14) y las restantes |
| `**[no verificado en Visual Studio]**` | la reescribe P-09 | 885 |
| `**[no verificado como ausencia]**` | `**[no verificado]** (como ausencia)` | 1494 |
| `**[no verificado: no hubo runner Windows]**` | `**[no verificado]** (no hubo runner Windows)` | 1971 |
| `**[no medido]**` | `**[no verificado]** (no medido)` | 458 |
| `**[no ejercitado en el laboratorio]**` | `**[no verificado]** (no ejercitado en el laboratorio)` | 1919 |
| `**[hallazgo negativo, a revalidar]**` | `**[no verificado]** (hallazgo negativo, a revalidar)` | 1311 |
| `**[criterio sobre base del fabricante]**` | `**[criterio]** (sobre la base del fabricante)` | 1143 |
| `**[criterio, apoyado en E7-4 y en [B83]]**` | `**[criterio]** (apoyado en E7-4 y [B83])` | 1696 |
| `[criterio]` sin negrita | `**[criterio]**` | 30 apariciones (p. ej. L657, L1131, celda de encabezado de §10.3) |
| `**[criterio]** El ciclo típico de un commit de BOM` | `**[interpretación]** El ciclo típico de un commit de BOM` | 492 |

Las celdas «Fuente» de §3.1 con `fabricantes` las corrige P-06.

**3g. §0.4, bloque de comandos (C1-27).** Reemplazar el bloque:

````markdown
```bash
cd Examples/N0-modelo-de-capas-y-reproducibilidad && ./correr-todo.sh      # ~1 minuto
cd Examples/A-plantillas && ./verificar.sh                                   # las plantillas del Anexo A, juntas
```
````

por:

````markdown
```bash
# Desde la carpeta de esta guía. Cada línea en su propio subshell, para que el cd no se acumule.
( cd Examples/N0-modelo-de-capas-y-reproducibilidad && bash correr-todo.sh )   # ~1,5 minutos con imágenes en caché
( cd Examples/A-plantillas && bash verificar.sh )                              # las plantillas del Anexo A, juntas
```
````

**3h. §0.4, insertar al final de la sección (tras `el [Anexo F](#anexo-f-límites-y-lo-que-no-se-verificó) lo lista.`):**

```markdown
> **Desde Windows.** Los scripts del laboratorio, de la migración (§5.2.6) y de la compuerta (§10) son de shell POSIX. Hay dos vías, ninguna probada en esta guía **[no verificado]** (requiere Windows): Docker Desktop con contenedores Linux, corriendo los mismos `docker run` desde Git Bash o desde una terminal de WSL 2 con el clon en el sistema de archivos de WSL [B130][B132]; o Git Bash con los prerrequisitos de la compuerta instalados en Windows ([A.11](#a11-hook-versionado-y-esqueleto-de-la-compuerta)). Las expresiones `$PWD` y `$(id -u)` de los comandos son de shell POSIX: en PowerShell no valen.
```

**Verificación**: `grep -cE '\[(no verificado|criterio)[^]]+\]' GUIA` → 0 (sólo quedan `[no verificado]` y `[criterio]` exactos); `grep -oE '\*\*\[(criterio|no verificado|observado|interpretación)\]\*\*' GUIA | wc -l` igual a `grep -oE '\[(criterio|no verificado|observado|interpretación)\]' GUIA | wc -l` fuera de bloques de código (conteo antes/después registrado, voto de riesgo); `( cd Examples/N0-… && bash correr-todo.sh )` y `( cd Examples/A-plantillas && bash verificar.sh )` corren seguidos en un mismo shell con rc=0; el enlace `../Despliegue/` existe.

### P-04 · §1 El caso

- **Hallazgos**: C1-27 (comando de §1.2), C1-54 (fix/corrección, pieza/artefacto).
- **Capa**: guía. **Costo**: bajo. **Reversible**: sí.

1. Reemplazar `El caso real no se puede mostrar (es de un repositorio privado). El laboratorio lo reproduce con un ejemplo sintético: un \`.cs\` en cp1252 con un identificador \`Çaudal\` y un literal \`"Atención"\`, compilado con el SDK oficial de .NET en Linux.` por el mismo párrafo seguido de:

````markdown
Para reproducirlo, desde la carpeta de esta guía:

```bash
cd Examples/N1-codificacion-y-finales-de-linea
docker run --rm -u "$(id -u):$(id -g)" -v "$PWD":/w -w /w python:3.12-slim python generar.py      # crea work/
docker run --rm -u "$(id -u):$(id -g)" -e HOME=/tmp -v "$PWD":/w -w /w mcr.microsoft.com/dotnet/sdk:8.0 sh e1-roslyn.sh
```
````

2. Reemplazar `El fix funcionó, pero dejó tres preguntas` por `La corrección funcionó, pero dejó tres preguntas`.
3. Reemplazar el encabezado `### 1.4 Qué resolvió el fix y qué dejó abierto` por `### 1.4 Qué resolvió la corrección y qué dejó abierto` (ningún enlace interno usa su ancla).
4. Reemplazar `- y no queda registro de con qué se construyó cada pieza (` por `- y no queda registro de con qué se construyó cada artefacto (`. «Pieza» se conserva sólo en la pregunta 3 de §1.1, que reproduce el pedido del caso.

**Evidencia**: corrida del auditor en copia de N1 (2026-10-09): `generar.py` como usuario no root crea `work/`; `e1-roslyn.sh` reproduce `CS1056` y `FFFD 006E 003A`, y `work/` queda del usuario.
**Verificación**: los dos `docker run` en una copia limpia de N1 (sin `work/`) → la salida contiene `error CS1056` y `U+     : FFFD`; `stat -c %U work` = usuario actual.

### P-05 · §2 Marco de referencia

- **Hallazgos**: C1-35 (L180), C1-38, C1-49 (matriz y derechos de decisión).
- **Capa**: guía; origen parcial en `03-Marco-De-Referencia.md` (N6 «sólo CI», P-23). **Costo**: bajo. **Reversible**: sí. **Derivados**: §9.4, §10.2.8, §11.4.

1. L180: reemplazar `macOS no se separa de ESC-02 porque, para estos temas, se comporta como Linux: el propio equipo del compilador de C# fijó en una prueba que el *fallback* es UTF-8 en Linux y macOS [B15].` por `macOS no se separa de ESC-02 (estación Linux) porque, para estos temas, se comporta como Linux: fuera de Windows, .NET devuelve UTF-8 como página por defecto [B19], y la prueba que acompaña un arreglo del compilador de C# deja escrito que en Linux y macOS el *fallback* es UTF-8 [B15].`
2. §2.3, fila ACT-ARQ, columna «Decide»: reemplazar `si hay devcontainer, la estructura del repo políglota.` por `si hay devcontainer, la estrategia de imagen (única o por componente) y la estructura del repo políglota.`
3. §2.3, fila ACT-OPS, columna «Decide»: reemplazar `La imagen de CI y del devcontainer y su actualización; SBOM y procedencia; las compuertas; la protección de rama.` por `La construcción, el digest y la actualización de las imágenes de CI y del devcontainer; SBOM y procedencia; las compuertas; la protección de rama.`
4. §2.4, fila §9: reemplazar `| §9 Procedencia | — | — | — | ○ | ● |` por `| §9 Procedencia | ○ (diagnóstico) | ○ (reconstruir) | ○ (reconstruir) | ○ | ● |`.
5. L220: reemplazar el párrafo `La procedencia (§9) pesa sólo en CI por una decisión de esta guía **[criterio]**: …` por `La procedencia (§9) se **produce** sólo en la CI por una decisión de esta guía **[criterio]**: la que vale es la del artefacto que se publica, y ese sale de la CI. En las estaciones y el devcontainer, §9 sirve para diagnosticar (metadatos embebidos) y para reconstruir un artefacto publicado y comparar hashes; una build local no demuestra nada ante un tercero.`

**Verificación**: la matriz de §2.4 no tiene `—` en una celda cuyo capítulo trae una fila de aplicación para ese escenario (cotejo §2.4 contra §n.4 de §4–§11).

### P-06 · §3 El entorno como pila de capas

- **Hallazgos**: C1-42 (L233), C1-24 (dos velocidades), C1-54 (L241), C1-40 (L246–L247), C1-01 (L291), C1-04 (L291), C1-06 (L358), C1-21 (L361), C1-44 (entrada por contexto), C1-25 (L370), C1-02 (L381), C1-22 (§3.7).
- **Capa**: guía. **Costo**: medio. **Reversible**: sí. **Derivados**: §6.4, §8.2.2 (deben decir lo mismo).

1. L233: reemplazar `Es el mapa: los capítulos 4 a 10 desarrollan una capa cada uno.` por `Es el mapa: §4 y §5 tratan la capa 1; §6, §7 y §8, las capas 2, 3 y 4; §9, las capas 5 y 6; §10, cómo se hace cumplir todo lo anterior; y §11 cruza todas las capas en una solución con tres ecosistemas. En el Recorrido, leé ahora §3.1, §3.2, §3.4 y §3.7; las tablas de §3.3, §3.5 y §3.6 usan mecanismos que se explican recién en §6 a §10 y son de consulta.`
2. L241: reemplazar `variables de entorno que el build lee` por `variables de entorno que la build lee`.
3. L246, celda «Fuente» de **Fijar**: reemplazar `| fabricantes | Congelar. |` por `| [B56][B84][B106][B113] | Congelar. |`. L247, celda de **Congelar**: reemplazar `| fabricantes | «Congelar el entorno»: un lock congela una sola capa. |` por `| [B83][B93][B99][B101] | «Congelar el entorno»: un lock congela una sola capa. |`.
4. Insertar como primera línea de §3.3 (tras el encabezado): `*Tabla de consulta: usa mecanismos que se explican en §6 a §10.*` Y como primera línea de §3.6, la misma frase con «§4 a §11».
5. L291, fila de `global.json` + `disable`: reemplazar por

```markdown
| `global.json` con `version` + `rollForward: disable` | 2 (SDK exacto; con él, el compilador en la CLI; en Visual Studio depende del SDK, §6.2.2) | El runtime con que corre la app; capas 3–5 | Hace cumplir: `dotnet` y el resolvedor de MSBuild fallan **en toda máquina** que no tenga ese SDK exacto | [B56], E3-1 |
```

6. §3.6, título de la apertura: reemplazar `Tres puertas de entrada al resto de la guía, según lo que el lector tenga delante.` por `Cuatro puertas de entrada al resto de la guía, según lo que el lector tenga delante.`
7. §3.6, fila ESC-01 de «Por escenario»: reemplazar por

```markdown
| ESC-01 Windows + Visual Studio | Respetar `.editorconfig` (Visual Studio lo lee de fábrica [B44]); activar el hook **con sus prerrequisitos** ([A.11](#a11-hook-versionado-y-esqueleto-de-la-compuerta)); con `rollForward: disable`, tener el SDK exacto de `global.json` (instalador independiente si VS trae otro [B56]); correr la compuerta antes del push desde Git Bash **[no verificado]** (requiere Windows) | Decidir la política; la procedencia |
```

8. §3.6, fila ESC-04: reemplazar `| ESC-04 Devcontainer | Imagen por digest; \`devcontainer-lock.json\`; \`--frozen-lockfile\` | Creer que reemplaza a la política |` por `| ESC-04 Devcontainer | Etiqueta fija de SDK y SO verificada por \`global.json\`, o la misma receta que la imagen de CI (§8.2.2); \`devcontainer-lock.json\`; \`--frozen-lockfile\` | Creer que reemplaza a la política |`
9. Insertar tras la tabla «Por escenario» de §3.6:

```markdown
**Por contexto.**

| Mi solución es… | Qué cambia respecto de la regla general | Archivos mínimos | Andá a |
|---|---|---|---|
| CTX-NET (sólo .NET) | El BOM de la familia .NET es convención del equipo (§5.2.3); `rollForward` coherente con usar o no lock de NuGet (§6.4); Visual Studio como estación principal | `.editorconfig`, `.gitattributes`, `global.json`, `Directory.Build.props`, `Directory.Packages.props`, `nuget.config` | §5.2.3, §6.2.2, §7.2.1, §9.2.1 |
| CTX-NODE (sólo Node.js) | Node no tiene archivo de versión propio: `.nvmrc` para los gestores y `devEngines` para que npm falle; JSON sin BOM | `.nvmrc`, `package.json`, `package-lock.json`, `.npmrc` | §6.2.3, §7.2.2, §9.2.2 |
| CTX-PY (sólo Python) | `requires-python` + `.python-version` dentro del proyecto uv; `open()` con `encoding=` | `pyproject.toml`, `.python-version`, `uv.lock` | §6.2.4, §7.2.3, §9.2.2 |
| CTX-POLI (los tres en un repo) | Excepciones de texto por lector; un archivo nativo y un lock por ecosistema donde los busca su herramienta; frontera de la build; imagen única o por componente | todo lo anterior y una compuerta con inventario de proyectos | §11 |
```

10. §3.6, tabla «Por artefacto», fila capa 3: reemplazar `índices de uv` por `índices de paquetes de uv`.
11. §3.7, L381: reemplazar `(E4-2 muestra CPM pidiendo 8.0.2 y NuGet entregando 9.0.0 sin advertir, cosa que sólo el lock habría detectado)` por `(E4-2: CPM pidió 8.0.2, que no existe, y NuGet resolvió 9.0.0; sin lock lo avisa con \`NU1603\`, y con lock el aviso desaparece y el lock registra \`requested [8.0.2, )\` con \`resolved 9.0.0\`, §7.2.1)`.
12. §3.7, *Aplica* (C1-22). Agregar al final de cada respuesta:
    - `¿Por qué el mismo commit da resultados distintos…?`: ` *Aplica* al primer diagnóstico de todo «en mi máquina anda»: entre dos estaciones, entre la estación y la CI o entre dos corridas de la CI.`
    - `¿Un contenedor reemplaza al \`global.json\` o al lock?`: ` *Aplica* cuando se propone el devcontainer como reemplazo de la política; *no aplica* a la imagen de la CI, que sí es parte de lo que se fija (§8.2.2).`
    - `¿Un rango es siempre peligroso?`: ` *Aplica* al declarar dependencias en cualquier ecosistema: rango en el manifiesto y lock con modo estricto en la CI; para .NET sin lock, la política de §6.4.`
13. §3.7, insertar al final de la sección la pregunta situada:

```markdown
**El caso de §1 llega a tu equipo: el `.cs` en cp1252 compila en la estación Windows y falla en la CI Linux. ¿Por qué capa empezás y qué descartás?**
Por la capa 1, la más baja donde las dos máquinas difieren: los bytes del archivo no son UTF-8 válido y cada compilador los decodifica con la página ANSI de su sistema (§1.2). El SDK, los paquetes y la imagen se descartan por ahora: aunque estuvieran fijados, el archivo fallaría igual en Linux (E5-1). *Aplica* a todo fallo que aparece en un sistema operativo y no en otro con el mismo commit.
```

**Verificación**: `grep -c 'fabricantes' GUIA` → 0; `grep -c 'capítulos 4 a 10 desarrollan' GUIA` → 0; `grep -n 'Por contexto\.\*\*' GUIA` → 1 en §3.6; la fila de §3.3 y la de §6.4 (P-09) dicen lo mismo sobre `disable`.

### P-07 · §4 Codificación y finales de línea

- **Hallazgos**: C1-35 (L415, diagrama, L442), C1-52 (L450), C1-11 (L457, L459, L474), C1-40 (L458, L492), C1-38 (L513), C1-56 (L533), C1-22 (§4.6), C1-23 (§4.9).
- **Capa**: guía; origen de C1-11 en N1 (P-23). **Costo**: medio. **Reversible**: sí. **Derivados**: E1-04, E1-05 (P-22), Anexo F (P-21), §11.6 (P-14).

1. L415: reemplazar `El equipo del compilador fijó ese comportamiento en una prueba en abril de 2026: el *fallback* «no es UTF-8 en Windows» y «es UTF-8 en Linux/macOS» [B15].` por `En abril de 2026 el equipo del compilador corrigió una regresión que había hecho que \`GetEncoding(0)\` devolviera UTF-8 en .NET aunque el sistema tuviera otra página ANSI; la prueba que agregó afirma que en Windows el *fallback* es la página ANSI real «aun cuando la opción de configuración regional UTF-8 está activada», y que en Linux y macOS, donde no hay página ANSI, es UTF-8 [B15].`
2. Diagrama de §4.2.1: reemplazar la línea `    E -- "Linux / macOS (o Windows con ACP UTF-8)" --> L["UTF-8 tolerante ⇒ U+FFFD<br/>literal corrupto · identificador = CS1056"]` por las dos líneas:

```text
    E -- "Linux / macOS" --> L["UTF-8 tolerante ⇒ U+FFFD<br/>literal corrupto · identificador = CS1056"]
    E -. "Windows con ACP UTF-8" .-> Q["pregunta abierta: la prueba de B15<br/>dice que sigue siendo la ANSI real"]
```

3. L442: reemplazar el párrafo `La rama «Windows con ACP UTF-8» es una deducción de [B14], [B19] y [B22], no un experimento **[no verificado en Windows]**: con la opción beta de UTF-8 activada, una estación Windows se comportaría como Linux.` por `Queda abierta la estación Windows con la opción beta de UTF-8 activada [B22]. Una lectura de [B19] sugiere que se comportaría como Linux; la prueba que el compilador agregó en [B15] afirma lo contrario para el compilador, que registra el proveedor de páginas de códigos antes de pedir la página ANSI. **[no verificado]** (requiere Windows). La guía no recomienda activar esa opción como remedio del caso.`
4. L450 (C1-52): reemplazar `y con SDK 10.0.400 compila (E1-03); el mismo` por `y con SDK 10.0.400 compila (E1-03). En E1-03 la falla aparece con el servidor de compilación (\`VBCSCompiler\`) recién arrancado, desaparece si el servidor ya compiló antes un archivo con *fallback*, y no aparece con \`-p:UseSharedCompilation=false\`, que compila sin servidor; el mismo`.
5. §4.2.4, fila Razor (L457): reemplazar por

```markdown
| Razor (generador) | correcto | literal y HTML → U+FFFD, sin error; identificador → `RZ1005`/`CS1056` | correcto | **[no verificado]** (no medido) | no documentado | E1-04 |
```

6. §4.2.4, fila Node `require`/`import` (L459): reemplazar la celda `| U+FFFD, sin error |` (la de esa fila) por `| literal → U+FFFD, sin error; identificador → \`SyntaxError\` |`.
7. L474: reemplazar `- **Nadie falla ruidosamente ante cp1252 salvo Python.** Roslyn falla sólo si cae en un identificador; Node y Razor nunca.` por `- **Sólo Python falla siempre ante cp1252.** Roslyn, Razor y Node fallan sólo si el carácter cae en un identificador (\`CS1056\`, \`RZ1005\`, \`SyntaxError\`); en literales y en HTML corrompen sin error (E1-01, E1-04, E1-05).`
8. L492: lo cambia P-03 (`**[interpretación]**`).
9. L513: reemplazar `Por contexto: en CTX-NET el riesgo es el cp1252 heredado y los literales multilínea; en CTX-NODE, el BOM en JSON leídos con \`fs\`; en CTX-PY, \`open()\` sin \`encoding=\`; en CTX-POLI se suman todos,` por `Por contexto: en CTX-NET (sólo .NET) el riesgo es el cp1252 heredado y los literales multilínea; en CTX-NODE (sólo Node.js), el BOM en JSON leídos con \`fs\`; en CTX-PY (sólo Python), \`open()\` sin \`encoding=\`; en CTX-POLI (los tres en un repo) se suman todos,`.
10. L533 (C1-56): reemplazar `\`file\` ayuda, pero es heurístico: informa «ISO-8859 text» para cp1252 y Latin-1 mientras no aparezca ningún byte \`80–9F\`, y «Non-ISO extended-ASCII text» si aparece (E1-13).` por `\`file\` ayuda, pero es heurístico. En E1-13, con \`file\` 5.46, un cp1252 sin bytes \`80–9F\` salió como «ISO-8859 text» y uno con esos bytes como «Non-ISO extended-ASCII text»; y un cp1252 cuyos bytes no ASCII forman por casualidad UTF-8 válido —texto que ya tenía mojibake— sale como UTF-8 (E1-13). No es un detector de cp1252.` (P-22 agrega el caso mojibake a `e1-file.sh`).
11. §4.6, *Aplica* (C1-22), agregar al final de cada respuesta:
    - `¿Alcanza con que compile en Linux…?`: ` *Aplica* en ESC-02 (Linux) y ESC-05 (CI): un verde no cierra el diagnóstico de codificación.`
    - `¿Alcanza con \`-p:CodePage=1252\`…?`: ` *Aplica* sólo como paliativo mientras se prepara la migración de §5.2.6; *no aplica* a un árbol mixto. Con SDK 8, \`-p:UseSharedCompilation=false\` evita el \`CS2016\` (E1-03).`
    - `¿Un contenedor resuelve el problema?`: ` *Aplica* cuando se propone el devcontainer (ESC-04) como solución al caso.`
12. §4.6, insertar al final:

```markdown
**Un compañero en Windows dice que el `.razor` heredado «se ve bien», y en la CI Linux esa pantalla muestra `?` sin ningún error de compilación. ¿Qué pasa y cómo lo confirmás?**
El archivo está en cp1252 y los acentos caen en texto HTML o en literales: Razor los decodifica como U+FFFD sin fallar (E1-04), y la salida los muestra como `?` o `�`. Se confirma por bytes, no con el editor: `iconv -f UTF-8 -t UTF-8` falla en el primer byte inválido (§4.5). Si el acento cayera en un identificador, la CI habría fallado con `RZ1005` o `CS1056`. *Aplica* a todo `.razor`, `.cshtml` o `.cs` heredado que compila en Linux y muestra texto roto.
```

13. Insertar entre el párrafo de §4.8 Plantilla y el `---` que cierra el capítulo:

```markdown
### 4.9 Práctica

1. **Predecí antes de correr.** Antes de E1-01, anotá cuál de estas variantes compila en Linux y qué imprime el literal: cp1252 con el acento sólo en el literal; cp1252 con un identificador `Çaudal`; UTF-8 sin BOM. Compará con `Examples/N1-codificacion-y-finales-de-linea/salidas/e1-roslyn-sdk8.txt`. *Respuesta esperada*: compilan la primera, que imprime `Atenci�n`, y la tercera, que imprime bien; la segunda falla con `CS1056` (§4.2.2).
2. **Diagnosticá por bytes.** Con `work/` generado, corré `e1-diagnostico.sh` y armá una tabla archivo → ¿BOM? → ¿UTF-8 válido? → cantidad de CR. *Respuesta esperada*: la clasificación de `salidas/e1-diagnostico.txt`.
```

**Evidencia**: [B15] (PR #83320 y su prueba `CreateFallbackEncoding_IsNotUtf8OnWindows`, comentario «even when the UTF-8 locale setting is enabled», leídos con la API de GitHub el 2026-10-09); identificador cp1252 en Node 22.23.2 → `SyntaxError` y en Razor (SDK 8.0.425) → `RZ1005`/`CS1056` (Informe-adhoc-CAT-FORMAL, a incorporar a E1-04/E1-05 por P-22); `e1-roslyn-codepage-servidor.txt` (casos 1, 3b y 4); `e1-file.txt` línea 1 `file-5.46`.
**Verificación**: `grep -c 'Node y Razor nunca' GUIA` → 0; E1-04 y E1-05 re-corridos muestran las dos ramas (literal y identificador); el diagrama de §4.2.1 renderiza con `minlag/mermaid-cli`.

### P-08 · §5 Política de texto

- **Hallazgos**: C1-54 (L593), C1-38 (L606), C1-36 (L638, L641), C1-10 (síntesis: L645–L661, §5.6), C1-08 (§5.2.5), C1-06 (paso 3 y recuadro), C1-09 (paso 5), C1-37 (diagrama, paso 6, §5.6, §5.7), C1-47 (bloque YAML), C1-44 (§5.4), C1-22, C1-23, C1-55 (formato de preguntas).
- **Capa**: guía; origen en N2 y en CI-02 de `04-Integracion.md` (P-23). **Costo**: medio-alto. **Reversible**: sí. **Derivados**: A.1, A.2, A.15, B.1, §11.2.2, §12 pasos 2–3, E2-2, E2-7, E2-8, EA-1.

1. L593: reemplazar `El fix del caso convirtió cien archivos` por `La corrección del caso convirtió cien archivos`.
2. L606: reemplazar `cumplirse igual en ESC-01 a ESC-05.` por `cumplirse igual en los cinco escenarios (ESC-01 a ESC-05: Windows con Visual Studio, Linux, WSL 2, devcontainer y CI).`
3. L638: reemplazar `(la de \`dotnet/runtime\` y la base que propone GitHub [B41])` por `(la base que propone GitHub [B41], y la que declaraban al 2026-10-07 seis repositorios de \`dotnet/*\` relevados —\`runtime\`, \`roslyn\`, \`aspnetcore\`, \`sdk\`, \`msbuild\` y \`eShop\`— con \`eol\` sólo para \`.sh\` y, en algunos, \`.cmd\`, \`.bat\` y \`.sln\`; E2-8)`.
4. L641: reemplazar el párrafo que empieza `**[criterio]** Para un equipo que construye en Windows y en Linux a la vez, la segunda.` por:

```markdown
**[criterio]** Las dos dejan el índice en LF, así que ninguna produce commits de EOL (E2-1); lo que cambia es el disco de Windows. La segunda conviene cuando el equipo tiene literales multilínea de C# o datos leídos sin traducción cuyo contenido importa en las pruebas: con CRLF en la estación y LF en la CI, **la misma prueba da distinto** en las dos (§4.2.5). Si no los tiene, la primera es igual de válida, y es la que usan los repositorios del fabricante relevados. En las dos, las excepciones las exige el consumidor del archivo: `*.cmd` y `*.bat` con CRLF para `cmd.exe`, `*.sh` con LF obligatorio. Visual Studio declara soportar `end_of_line` [B45], así que trabajar con LF en Windows no debería requerir configuración local **[no verificado]** (requiere Windows). Las plantillas de esta guía (A.2) usan la segunda.
```

5. L645: reemplazar `La decisión real es **dónde va BOM**, y se toma por el lector más estricto de cada tipo de archivo (E2-5, E8-1):` por `La decisión real es **dónde va BOM**. En una parte de los archivos la toma un lector, que falla con la opción equivocada (E2-5, E8-1). En la familia .NET ningún lector decide —Roslyn y Razor leen UTF-8 con y sin BOM (§4.2.4)— y lo que se elige es una **convención del equipo**, que tiene que quedar declarada igual:`
6. Reemplazar la tabla completa de §5.2.3 (encabezado y once filas, L647–L659) por:

```markdown
| Tipo de archivo | Política | Lo decide | Por qué | Evidencia |
|---|---|---|---|---|
| `*.sh`, scripts con shebang | UTF-8 **sin** BOM, **LF obligatorio** | un lector: el kernel y el shell | Con BOM, `execve` falla o el script corre con otro intérprete; con CRLF no arranca | E2-5, E1-11, [B12] |
| `*.json` (incl. `package.json`, `appsettings.json`) | UTF-8 sin BOM | un lector: `JSON.parse`, `json.load`, `JsonDocument.Parse(bytes)` | Fallan con BOM; `require()` y `File.ReadAllText` lo toleran | E2-5 |
| `*.py`, `pyproject.toml` | UTF-8 sin BOM | un lector: `tomllib` | El intérprete lo tolera, pero `tomllib` falla con BOM; PEP 8 pide UTF-8 sin declaración | E2-5, [B34] |
| `*.ps1` | UTF-8 **con** BOM si el equipo usa Windows PowerShell 5.1 y hay texto no ASCII | un lector: Windows PowerShell 5.1 | Lee un script sin BOM como ANSI; PowerShell 7 usa UTF-8 sin BOM | [B54] |
| `*.cmd`, `*.bat` | UTF-8 sin BOM, **CRLF** | un lector para el CRLF (`cmd.exe`); convención para el BOM | Convención de repositorios de referencia; «sin BOM» es **[criterio]** | E2-6 |
| `*.js`, `*.ts`, `*.css`, `*.md`, `*.yml` | UTF-8 sin BOM, LF | convención (Node, Prettier [B53]) | Una plantilla web del SDK trae un `.js` con BOM: se normaliza | E2-6 |
| `*.cs` | UTF-8; **con o sin** BOM, una sola de las dos, **declarada** | convención del equipo | El compilador no necesita BOM, pero con BOM el archivo queda a salvo de `CodePage` y de la página ANSI de cada máquina (§4.2.3); `dotnet format` hace cumplir cualquiera de las dos; `dotnet new console` crea `Program.cs` **con** BOM (SDK 8 y 10) y las plantillas web, `.cs` sin BOM; los repositorios del fabricante difieren (`dotnet/roslyn` y `dotnet/eShop` con BOM, `dotnet/aspnetcore` sin) | E2-6, E2-8 |
| `*.razor`, `*.cshtml` | UTF-8 **con** BOM | convención: las plantillas | Las plantillas web del SDK 8 y 10 los crean así (10 de 10 y 12 de 12 `.razor`); pedir lo contrario obliga a corregir cada archivo nuevo | E2-6 |
| `*.sln` | UTF-8 **con** BOM | convención: la CLI | `dotnet sln add` repone el BOM aunque se lo quiten | E2-6 |
| `*.csproj`, `*.props`, `*.targets`, `*.slnx` | UTF-8; **con o sin** BOM, la misma convención que `*.cs` | convención del equipo | `dotnet new console` crea el `.csproj` **con** BOM y las plantillas web, sin; la CLI no les agrega BOM al editarlos; los repositorios del fabricante difieren (`dotnet/sdk` con BOM, `dotnet/msbuild` y `dotnet/runtime` sin); desde .NET 10, `dotnet new sln` crea `.slnx` [B55] | E2-6, E2-8 |
| Lock files | UTF-8 sin BOM, LF, **sin exigir salto final** | la herramienta que los escribe | NuGet escribe `packages.lock.json` sin salto final; un hook que lo agrega pelea con la herramienta | E7-2, E8-1, EA-1 |
```

7. L661: reemplazar el párrafo `**[criterio] Para \`*.cs\`.** En un repositorio nuevo, …` por:

```markdown
**[criterio] Para la familia .NET (`*.cs` y los archivos de proyecto).** Como ningún lector decide, se elige según el estado del repositorio y se declara; lo inaceptable es no declarar, porque entonces cada editor decide y vuelven los commits de BOM.

- **Repositorio nuevo**: UTF-8 **sin** BOM (variante A de la plantilla). EditorConfig desaconseja `utf-8-bom` [B43] y `dotnet format` corrige lo que traigan las plantillas. El costo: el `Program.cs` y el `.csproj` que crea `dotnet new console` llegan con BOM y hay que normalizarlos **antes del primer commit**; la compuerta los señala (EA-1).
- **Heredado todavía en cp1252**, el que va a correr la migración de §5.2.6: elegir A o B **antes** del commit de política, porque la migración produce de una vez lo que diga `.editorconfig`. Sin otra razón, A; con BOM (B) si durante la transición alguna parte se va a compilar con `CodePage`.
- **Heredado ya convertido a UTF-8 con BOM**, como el del caso: `utf-8-bom` para `*.cs` (variante B). Cumple lo mismo, protege cada archivo aunque alguien fije `CodePage` y evita un segundo commit masivo sólo para quitar firmas.

`*.razor`, `*.cshtml` y `*.sln` van con BOM en las dos variantes, porque las herramientas del SDK lo reponen.
```

8. §5.2.5, tabla «Herramienta existente»: insertar como primera fila de datos

```markdown
| editorconfig-checker 4.0.2 [B201] | Lee el mismo `.editorconfig` para todas las extensiones: no UTF-8, BOM distinto del `charset` resuelto y fin de línea incorrecto; binarios para Windows, paquetes de npm y PyPI e imagen de contenedor (E2-7) | Revisa el **working tree**, no el índice; su detector puede informar `windows-1252` como `iso-8859-1` [B201]; no da el diagnóstico «¿cp1252?»; como hook del framework pre-commit no se probó |
```

E insertar tras la tabla:

```markdown
**[criterio]** La guía mantiene su verificador porque mira el **índice** —lo que se commitea— y da el diagnóstico «¿cp1252?». Necesita `python3` y el paquete `EditorConfig==0.17.1` en cada lugar donde corre (A.11). Un equipo que prefiera no mantener un script puede armar el paso de texto con editorconfig-checker sobre un clon limpio en la CI y `dotnet format whitespace --verify-no-changes` para los `.cs`, con la misma regla de una sola compuerta en hook y CI (§10.2.2).
```

9. §5.2.6, diagrama: reemplazar `    Note over R: fusionar con merge commit: el SHA tiene que sobrevivir` por `    Note over R: un PR por commit (cualquier estrategia de fusión) o un PR con merge commit: se lista el SHA que quedó en main`.
10. §5.2.6, paso 3: reemplazar la primera línea del bloque `   # tools/migrar-a-utf8.sh (E2-2), por cada archivo que git considera texto:` por las dos líneas:

```text
   # Invocación (desde la raíz, con la política ya commiteada): tools/migrar-a-utf8.sh CP1252 [pathspec...]
   # Requiere bash, iconv, git y el CLI editorconfig (E2-2). Por cada archivo que git considera texto:
```

11. §5.2.6, paso 5: reemplazar `5. **Refrescar los working trees.** Los archivos en disco siguen con CRLF hasta el próximo checkout; \`git rm -rq --cached . && git reset -q --hard\` los rematerializa. Cada desarrollador lo hace una vez.` por:

````markdown
5. **Refrescar los working trees.** Los archivos en disco pueden seguir con CRLF hasta el próximo checkout. Cada desarrollador lo hace una vez, **con el árbol limpio y después de traer la migración**: `git reset --hard` sobrescribe los archivos con la versión del commit [B204], y un cambio sin commitear se pierde sin aviso.

   ```bash
   git diff --quiet && git diff --cached --quiet \
     || { echo "commiteá o guardá con git stash antes de seguir" >&2; exit 1; }
   git pull --ff-only                               # trae los commits de política y migración
   git rm -rq --cached . && git reset -q --hard     # rematerializa el disco con la política
   ```

   Si `git ls-files --eol` ya muestra en disco lo que pide la política (`w/lf`, y `w/crlf` en `.cmd` y `.bat`), el paso no hace falta.
````

12. §5.2.6, paso 6: reemplazar `Un \`--amend\`, un rebase o un *squash merge* cambian el SHA y rompen el aislamiento: el PR de migración se fusiona con merge commit **[criterio]**.` por `El SHA listado tiene que ser el que quedó en \`main\`: un \`--amend\` o un rebase posteriores lo cambian. La fusión por *squash* funciona si cada commit va en su propio PR —política, migración, \`.git-blame-ignore-revs\`— y el SHA se toma del *squash* ya fusionado: con git 2.47.3, \`blame\` vuelve a atribuir las líneas a sus autores (E2-2). Lo que el *squash* rompe es juntar los tres en un PR: los aplasta en uno y la verificación mecánica deja de aplicarse a un commit sólo mecánico **[criterio]**.`
13. §5.2.6, insertar tras el paso 6 (antes de `#### 5.2.7`):

````markdown
```yaml
# §5.2.6 como contrato, para agentes y revisores.
entradas:
  repositorio: clon con las ramas abiertas fusionadas o identificadas
  politica: .editorconfig y .gitattributes decididos (§5.2.3, A.1, A.2)
  codificacion_origen: CP1252
salidas:
  - "commit 1: política (.editorconfig, .gitattributes, compuerta)"
  - "commit 2: migración mecánica (tools/migrar-a-utf8.sh CP1252)"
  - "commit 3: .git-blame-ignore-revs con el SHA del commit 2 tal como quedó en main"
validaciones:
  - comando: tools/verificar-commit-mecanico.sh <sha-commit-2> CP1252
    esperado: "0 con cambio de contenido"
  - comando: python3 tools/check_text_policy.py
    esperado: "0 violación(es)"
  - comando: git diff --quiet && git diff --cached --quiet   # en cada estación, antes del paso 5
    esperado: código de salida 0
```

> **Desde Windows.** La migración la ejecuta una sola persona (ACT-ARQ); el resto sólo hace el paso 5, que es git puro. Los tres scripts necesitan `bash`, `iconv`, `git` y el CLI `editorconfig` (`pip install EditorConfig==0.17.1`), o la imagen de `Examples/N2-politica-de-texto-y-remediacion/tools/Dockerfile`, que los trae. Desde Windows: esa imagen con Docker Desktop montando el clon, o Git Bash con Python, el paquete y un `iconv` disponible **[no verificado]** (requiere Windows).
````

14. §5.4, insertar tras la tabla de escenarios: `Por contexto: en CTX-NET (sólo .NET), el BOM de \`.cs\` y \`.csproj\` es convención y se elige por estado del repositorio (§5.2.3); en CTX-NODE y CTX-PY no hay excepciones de BOM: todo sin BOM y LF; en CTX-POLI (los tres), la tabla completa de §5.2.3, con las excepciones al final del \`.editorconfig\` (§11.2.2).`
15. §5.6, formato (C1-55): en cada pregunta de §5.6, reemplazar `?** ` por `?**` + salto de línea (la respuesta pasa a la línea siguiente, como en §3.7 y §4.6).
16. §5.6, primera respuesta: reemplazar `Para Razor, con BOM: es lo que producen las plantillas y lo que declara \`dotnet/aspnetcore\`. Para C#, cualquiera, pero una sola y declarada. *Aplica*: repositorio nuevo → sin BOM; heredado ya convertido con BOM, como el del caso → declarar \`utf-8-bom\` para \`*.cs\` y no tocar más.` por `Para Razor, con BOM: es lo que producen las plantillas y lo que declara \`dotnet/aspnetcore\`. Para C# y los \`.csproj\`, ningún lector decide: es convención del equipo, una sola y declarada. *Aplica*: repositorio nuevo → sin BOM, normalizando lo que crea \`dotnet new\`; heredado todavía en cp1252 → la variante que se declare antes de migrar; heredado ya convertido con BOM, como el del caso → \`utf-8-bom\` para \`*.cs\` y no tocar más.`
17. §5.6, segunda respuesta: reemplazar `\`.sln\` con BOM porque la CLI lo repone; \`.csproj\` y \`.slnx\` sin.` por `\`.sln\` con BOM porque la CLI lo repone; \`.csproj\`, \`.props\` y \`.slnx\`, con la misma convención que \`.cs\`.`
18. §5.6, quinta respuesta: reemplazar `y fusión sin squash (§5.2.6).` por `y el \`.git-blame-ignore-revs\` con el SHA que quedó en \`main\` (§5.2.6).`
19. §5.6, *Aplica* faltantes: al final de `¿Cómo detecto en un PR…?` agregar ` *Aplica* a todo PR en la CI (ESC-05) y a cada commit si el hook está activo.`; al final de `¿Cuándo \`working-tree-encoding\` y cuándo convertir?` agregar ` *Aplica* a archivos que consume un programa que sólo lee otra codificación; *no aplica* al caso.`
20. §5.6, insertar al final:

```markdown
**Tu equipo va a migrar el heredado del caso, todavía en cp1252, y la mitad trabaja con Visual Studio. ¿Declarás `*.cs` con o sin BOM antes de correr la migración?**
Cualquiera de las dos, pero decidida antes del commit de política, porque la migración produce de una vez lo que diga `.editorconfig`. Ningún lector de .NET falla por una u otra (§4.2.4). Sin BOM sigue la recomendación de EditorConfig y obliga a normalizar lo que crea `dotnet new console`; con BOM protege cada archivo si durante la transición alguien compila con `CodePage` (§4.2.3). *Aplica* a todo heredado de CTX-NET o CTX-POLI antes del paso 2 de §12.
```

21. §5.7, señales pobres: reemplazar `el PR de migración fusionado con squash;` por `un \`.git-blame-ignore-revs\` con un SHA que no está en \`main\`; política, migración e ignore-revs aplastados en un solo *squash*;`.
22. Insertar entre el párrafo de §5.8 y el `---`:

```markdown
### 5.9 Práctica

1. Antes de mirar la salida de E2-2, decí cuántos archivos debería reportar `verificar-commit-mecanico.sh` con cambio de contenido y qué pasa si la migración además cambia `=> 42` por `=> 43`. *Respuesta esperada*: cero; con el cambio funcional, `CONTENIDO src/Sensor.cs` y código 1 (§5.2.6, paso 4).
2. Con la tabla de §5.2.3, escribí la política de un repo con `.sh`, `appsettings.json`, `.razor` y `.cs` heredados ya convertidos con BOM. Compará con A.1, variante B. *Respuesta esperada*: `[*]` sin BOM y LF; `.razor` y `.cs` con `utf-8-bom`; `.sh` sin BOM y LF también en `.gitattributes`.
```

**Evidencia**: E2-6 (`e6-plantillas-dotnet.txt`: `Program.cs` y `app.csproj` con BOM en SDK 8 y 10); relevamiento de seis repos `dotnet/*` (`evidencia-abogado-del-diablo/repos-de-referencia/`, 2026-10-07; pasa al laboratorio como E2-8); editorconfig-checker 4.0.2 contra el `.editorconfig` de §5.5 (`evidencia-abogado-del-diablo/editorconfig-checker/`, pasa como E2-7); squash + ignore-revs con git 2.47.3 (`evidencia-abogado-del-diablo/squash-y-blame/`, pasa a E2-2); pérdida de trabajo con el paso 5 (`evidencia-lector-sin-contexto/salida-receta.txt`); [B201] README de editorconfig-checker (versión 4.0.2, instalación, nota de detección de `windows-1252`), [B204] `git reset --hard`, consultados el 2026-10-09.
**Verificación**: E2-2, E2-7 y E2-8 corren con rc=0 y sus salidas quedan versionadas; `grep -c 'fusionado con squash\|fusión sin squash\|merge commit: el SHA tiene que sobrevivir' GUIA` → 0; el bloque YAML es YAML válido (`python3 -c 'import yaml,sys; yaml.safe_load(open(sys.argv[1]))'` sobre el bloque extraído); en una copia con `src/Program.cs` modificado, el bloque del paso 5 sale con código 1 y el archivo sigue modificado.

### P-09 · §6 Fijar el toolchain

- **Hallazgos**: C1-31 (diagrama, L893, L983), C1-03 (L883), C1-04 (L885, L975, L979), C1-38 (L910), C1-01 (§6.4), C1-44 (§6.4), C1-50 (§6.5), C1-22, C1-23, C1-55.
- **Capa**: guía; origen en N3 §3.4 y CI-05 (P-23). **Costo**: medio. **Reversible**: sí. **Derivados**: §3.3, A.3, B.1, §9.6, E3-2, E3-3.

1. Diagrama de §6.2.1: reemplazar `        PM["packageManager"] -- "Corepack, si está" --> PMV["pnpm / yarn"]` por `        PM["packageManager"] -- "pnpm ≥ 11 (pmOnFail) · Yarn con Corepack" --> PMV["pnpm / yarn"]`.
2. L883, al final del párrafo (tras `entre dos parches del SDK 8 [B90].`), agregar: ` Esa recomendación tiene un costo que conviene escribir: con \`disable\`, **toda** máquina —cada estación, la imagen del devcontainer y la de CI— necesita exactamente ese SDK, y \`dotnet\` falla con \`A compatible .NET SDK was not found\` en la que tenga otro parche (E3-1). §6.4 pone las dos políticas lado a lado.`
3. L885: reemplazar el párrafo `**¿Fijar el SDK fija el compilador?** Sí: el compilador viaja dentro del SDK. …` por:

```markdown
**¿Fijar el SDK fija el compilador?** En la CLI, sí: `dotnet build` compila con el Roslyn que viaja dentro del SDK (E3-2). En Visual Studio la build corre con el MSBuild del IDE y la respuesta depende de la versión del SDK. Los *targets* del SDK 8.0.425 no traen ninguna selección automática —sólo la opción `BuildWithNetFrameworkHostedCompiler`, y el paquete `Microsoft.Net.Sdk.Compilers.Toolset` no tiene versiones 8.x [B60]—, así que con el SDK 8 Visual Studio compila con su propio Roslyn. Los del SDK 10.0.400 usan el Roslyn del SDK cuando hay `DOTNET_HOST_PATH`, descargan el paquete *toolset* sólo si el MSBuild es anterior a 18.9 y, si no, caen en el compilador del IDE (E3-2, inspección de los *targets* de las imágenes oficiales). Qué compilador corre efectivamente en un Visual Studio real **[no verificado]** (requiere Visual Studio). Por eso el binario que vale es el de la CI, que compila con `dotnet build`, y el registro del entorno incluye la versión del compilador, no sólo la del SDK (§9.6).
```

4. L893: reemplazar el párrafo `**[criterio]** \`packageManager\` sigue siendo útil como declaración (la leen Corepack y pnpm [B81]), pero no es un mecanismo de cumplimiento estándar: con npm alcanza \`devEngines\`; con pnpm o Yarn, instalar Corepack o el gestor explícitamente, con versión fijada, en la imagen y en la CI.` por `**[criterio]** Quién hace cumplir \`packageManager\` depende del gestor. npm no lo usa: alcanza \`devEngines\`. pnpm, desde la 11, lo hace cumplir por sí mismo con el ajuste \`pmOnFail\` —por defecto \`download\`, que cambia a la versión declarada; con \`error\`, falla—, que gobierna también \`devEngines.packageManager\` [B196] (E3-3: pnpm 12.10.1 sin Corepack, con \`pmOnFail=error\`, \`ERR_PNPM_BAD_PM_VERSION\`). Yarn depende de Corepack o de instalarlo explícitamente [B81]. En la compuerta, pnpm con \`pmOnFail=error\`; en la imagen y en la CI, el gestor instalado con versión fijada.` (La oración siguiente, `Estado de las líneas al 2026-10-07: …`, queda igual.)
5. L910: reemplazar `en ESC-02 y ESC-03, configurado` por `en ESC-02 (Linux) y ESC-03 (WSL 2), configurado`.
6. §6.4, L933: reemplazar el párrafo `**[criterio] La elección de \`rollForward\`.** Con \`packages.lock.json\` y modo estricto: …` por:

```markdown
**[criterio] La elección de `rollForward`** va atada a si el repo usa lock files de NuGet, que es el camino por defecto de esta guía (§7.2.1). Las dos políticas, completas:

| Política | Qué exige | Qué cuesta | Qué detecta |
|---|---|---|---|
| **Con lock** (por defecto): `disable` + `packages.lock.json` en los ejecutables + `RestoreLockedMode` en CI | El SDK **exacto** en toda máquina: cada estación (en Windows, el instalador independiente si Visual Studio trae otro [B56]), la imagen del devcontainer y la de CI | Una estación con otro parche **no compila** (`A compatible .NET SDK was not found`, E3-1) hasta instalar el exacto; cada actualización de Visual Studio puede reemplazar su SDK [B59]; subir el SDK es un PR que mueve `global.json`, las imágenes y los locks (§10.2.6) | El SDK, el grafo completo y el `contentHash` |
| **Sin lock**: `latestPatch` (o `latestFeature`) + `NU1603` como error + el SDK registrado por la CI | Un SDK de la banda en cada estación | El SDK concreto varía entre máquinas, y la CI tiene que registrarlo (§9); se pierde el `contentHash` frente a un paquete re-publicado o una caché caliente (E4-3) | Versiones inexistentes que NuGet aproxima (`NU1603`, E4-2); no detecta un paquete re-publicado con otro contenido |

Lo que se limita a la CI es el **modo estricto del lock** (`RestoreLockedMode`, §7.4), no la selección del SDK: con `disable`, una estación desalineada queda bloqueada igual. Mezclar lock files con `rollForward` permisivo hace que otro parche del SDK rompa el lock en la CI con `NU1004` (E3-6). La política elegida y su costo van en un ADR (§10.2.6).

Por contexto: en CTX-NET (sólo .NET) la decisión central es la de arriba; en CTX-NODE, `.nvmrc` más `devEngines`, y el gestor según §6.2.3; en CTX-PY, `.python-version` más `required-version`; en CTX-POLI, además, que la build .NET que invoca `npm` o `python` usa los del `PATH` (§11.2.5).
```

7. §6.5, segundo bloque: reemplazar la primera línea `// package.json — declara para quien consume y hace cumplir para quien desarrolla (Anexo A.7).` por `// package.json ANOTADO, no copiable: npm rechaza los comentarios (EJSONPARSE). Copiable en A.7.`
8. §6.6, formato (C1-55): reemplazar `?** ` por `?**` + salto de línea en cada pregunta.
9. L975: reemplazar `Fija el SDK con que corren \`dotnet\` y MSBuild y, por arrastre, el compilador, los analizadores incorporados y los *targets*.` por `Fija el SDK que eligen \`dotnet\` y el resolvedor de MSBuild y, en la CLI, por arrastre, el compilador, los analizadores incorporados y los *targets*; en Visual Studio el motor MSBuild es el del IDE y, con el SDK 8, también el compilador (§6.2.2).`
10. L977: reemplazar `*Criterio*: exacto con lock files o reproducibilidad bit a bit; \`latestPatch\` si se prioriza no bloquear estaciones Windows y la CI registra la versión real.` por `*Criterio*: \`disable\` con lock files, aceptando su costo (el SDK exacto en cada estación); \`latestPatch\` sin lock files, con \`NU1603\` como error y la versión real registrada en la CI (§6.4).`
11. L979: reemplazar `El compilador sí; el runtime no.` por `El compilador, en la CLI sí y en Visual Studio depende del SDK (§6.2.2); el runtime no.`
12. *Aplica* faltantes en §6.6: al final de `¿\`engines\` impide instalar?` agregar ` *Aplica*: \`devEngines\` en la aplicación que desarrolla el equipo; \`engines\` en lo que se publica a npm.`; reemplazar la respuesta de `¿Cuál es el estado de Corepack y \`packageManager\`?` por `Corepack es experimental y no viene con Node desde la 25. \`packageManager\` lo hace cumplir pnpm ≥ 11 por sí mismo (\`pmOnFail\`, [B196]); con Yarn, Corepack o una instalación explícita. No basar la compuerta en Corepack. *Aplica* a toda imagen de Node 25 o posterior y a todo equipo que use pnpm o Yarn.`; al final de `¿\`requires-python\` o \`.python-version\`?` agregar ` *Aplica* a todo proyecto uv (CTX-PY, CTX-POLI); en un paquete que se publica, \`requires-python\` es además lo que ven sus consumidores.`; al final de `¿Qué respeta y qué ignora una estación Windows con Visual Studio?` agregar ` *Aplica* a ESC-01 (Windows con Visual Studio) en CTX-NODE, CTX-PY o CTX-POLI.`
13. §6.6, insertar al final:

```markdown
**Visual Studio se actualizó el lunes y desde entonces nadie del equipo Windows compila: `A compatible .NET SDK was not found`. La CI sigue verde. ¿Qué pasó y qué decidís?**
El repo tiene `rollForward: disable` y la actualización reemplazó el SDK del IDE por otro parche [B59]; la CI no se enteró porque su imagen trae el SDK exacto. Hay dos salidas legítimas: instalar el SDK exacto con el instalador independiente en cada estación (y dejarlo escrito en la lista B.1), o subir `global.json`, las imágenes y los locks en un PR coordinado. Pasar a `latestPatch` sólo vale adoptando entera la política sin lock de §6.4. *Aplica* a todo repo con `disable` y estaciones con Visual Studio.
```

14. Insertar entre §6.8 y el `---`:

```markdown
### 6.9 Práctica

1. Antes de correr E3-1, predecí qué SDK elige cada uno de los siete `global.json` contra los SDK 8.0.425 y 10.0.400 y cuáles fallan. *Respuesta esperada*: la de `Examples/N3-fijacion-del-toolchain/README.md`, sección E3-1; `8.0.300` sin `rollForward` falla y `latestMajor` toma 10.0.400.
2. Escribí el ADR de `rollForward` de tu equipo con la plantilla de A.16: política elegida de la tabla de §6.4, costo aceptado y quién instala qué en cada estación.
```

**Evidencia**: inspección de los *targets* de `sdk:8.0` (8.0.425) y `sdk:10.0` (10.0.400) y del índice de versiones de `Microsoft.Net.Sdk.Compilers.Toolset` (Informe-senior-dotnet, senior-dotnet-01; voto de evidencia V3: 94 versiones, ninguna 8.x); pasa a E3-2 por P-22. [B196] pnpm.io/settings/cli: `pmOnFail`, «Added in: v11.0.0», default `download`, opciones `download`/`error`/`warn`/`ignore`, «Overrides the `onFail` behavior of both the `packageManager` field and `devEngines.packageManager`» (2026-10-09); E1 de pnpm 12.10.1 (Informe-adhoc-AH-001, pasa a E3-3). `rollForward: disable` con 8.0.424 en SDK 8.0.425 → rc=145 (voto de evidencia V1).
**Verificación**: `grep -c 'no queda bloqueada' GUIA` → 0; `grep -c 'Corepack, si está' GUIA` → 0; E3-2 y E3-3 re-corridos con las ampliaciones; la tabla de §6.4, la fila de §3.3 (P-06), A.3 (P-16) y B.1 (P-17) dicen lo mismo sobre `disable`.

### P-10 · §7 Congelar las dependencias

- **Hallazgos**: C1-03 (L1009, §7.6 P1, §7.7), C1-02 (L1048, L1052), C1-26 (L1050, L1131, L1158), C1-25 (RID, CPM), C1-30 (L1062, L1075, L1137), C1-58 (L1075), C1-33 (L1076, P4, ver también P-14), C1-44 (§7.4), C1-55 (numeración, L1098), C1-38 (L1137), C1-22, C1-23, C1-40 (L1143).
- **Capa**: guía; origen en N4 y N0 (P-23). **Costo**: medio-alto. **Reversible**: sí. **Derivados**: A.4 (P-16), B.2 (P-17), §12 paso 6 (P-15), E4-2, E4-4.

1. §2.2, fila CTX-NET (C1-25, primera aparición de CPM en prosa): reemplazar `NuGet (CPM, \`packages.lock.json\`, \`nuget.config\`)` por `NuGet (*Central Package Management*, CPM; \`packages.lock.json\`; \`nuget.config\`)`.
2. L1009: reemplazar `Sin ese comando, el lock es una sugerencia que la herramienta reescribe en silencio. Los experimentos de este capítulo lo confirman en los tres ecosistemas.` por `Sin ese comando, el lock es una sugerencia que la herramienta reescribe en silencio. En npm y uv el fabricante pide versionar el lock [B93][B99]; en NuGet es *opt-in* [B83], y esta guía lo adopta por defecto con su costo declarado y una alternativa sin lock para quien no quiera pagarlo (§6.4, §7.2.1). Los experimentos de este capítulo lo confirman en los tres ecosistemas.`
3. L1048: reemplazar `E4-2 agregó otro caso: si la versión pedida no existe, NuGet resuelve la siguiente disponible **sin advertencia** (pedida 8.0.2, resuelta 9.0.0).` por:

```markdown
E4-2 muestra un cuarto: si la versión pedida no existe, NuGet resuelve la siguiente disponible (pedida 8.0.2, resuelta 9.0.0) y lo avisa con `NU1603` [B195]. En el mismo proyecto con `packages.lock.json`, ese aviso **no apareció**, y el lock registró `requested [8.0.2, )` con `resolved 9.0.0` (SDK 8.0.425 y 10.0.400). Con `NU1603` tratado como error, el restore sin lock se detiene y el restore con lock termina con 0: en este caso, activar el lock desarma esa defensa (E4-2). **[criterio]** Con lock, la compuerta compara `requested` con `resolved` en las entradas `Direct` y `CentralTransitive` del lock; sin lock, `NU1603` va en `WarningsAsErrors` (A.4).
```

4. L1050: reemplazar `Tres reglas del fabricante: commitear el lock en **aplicaciones** y no en bibliotecas que consumen otros [B83];` por `Tres reglas del fabricante: el lock que gobierna es el del proyecto en la punta de la cadena, y el de una biblioteca que no se distribuye o de un proyecto de código común del que dependen otros «no debería» versionarse —conservarlo «no hace daño», pero no fija lo que resuelve quien lo referencia— [B83];` y reemplazar `Además, **el conjunto de RID es parte del lock**:` por `Además, **el conjunto de RID (*runtime identifier*, la plataforma de destino: \`win-x64\`, \`linux-x64\` [B203]) es parte del lock**:`.
5. L1052: reemplazar `CPM solo no evita la deriva (E4-2 pidió 8.0.2 y obtuvo 9.0.0).` por `CPM solo no garantiza la versión pedida (E4-2 pidió 8.0.2 y obtuvo 9.0.0).`
6. L1062: reemplazar `pip-tools y \`uv pip compile\` producen un \`requirements.txt\` **por plataforma** salvo \`--universal\` [B98][B104]: en E4-5 el compilado en Linux **omitió** \`colorama\`, el modo de falla «funciona en Linux, en Windows falta un paquete».` por `\`uv pip compile\` produce un \`requirements.txt\` **por plataforma** salvo \`--universal\` [B98]; \`pip-compile\` (pip-tools) no tiene esa opción, y su README pide compilar en cada entorno de destino [B104]. En E4-5, \`uv pip compile\` sin \`--universal\` —usado como sustituto del estilo pip-tools— corrido en Linux **omitió** \`colorama\`: el modo de falla «funciona en Linux, en Windows falta un paquete».`
7. §7.3, filas de la tabla: reemplazar la fila `| Multiplataforma | …` por `| Multiplataforma | sólo los RID declarados | sí | sí | sí | sí, universal | sí, marcadores | no: \`pip-compile\` por entorno; \`uv pip compile\` sólo con \`--universal\` |`; la fila `| Registros en el repo | …` por `| Registros en el repo | \`nuget.config\` (\`<clear />\`, mapeo) [B87][B86]; hueco: la caché caliente (E4-3) | \`.npmrc\` del proyecto, un registro por *scope* [B109][B198]; hueco: un paquete interno sin *scope* va al registro por defecto | — | — | \`[[tool.uv.index]]\`, estrategia \`first-index\` [B110]; \`explicit = true\` protege sólo lo asignado a ese índice | — | \`--index-url\` único; agregar índices con la búsqueda combinada de pip reabre la confusión [B110] |`; y la fila `| Evidencia | E4-1, E4-2, E4-3 | E4-4 | E4-4 | — | E4-5 | E4-5 | E4-5 |` por `| Evidencia | E4-1, E4-2, E4-3 | E4-4 | E4-4 | E4-4 | E4-5 | E4-5 | E4-5 |`.
8. Insertar tras la tabla de §7.3, antes de `**Integración en una solución**`: `El riesgo de confusión de dependencias está en el momento de bloquear o actualizar: una vez bloqueado, el hash del lock —y en npm y uv también el origen— fija lo que se instala.`
9. §7.4, insertar tras la tabla de escenarios: `Por contexto: en CTX-NET la decisión es lock sí o no (§6.4) y, con lock, sólo en los ejecutables (A.4); en CTX-NODE y CTX-PY el lock no es opcional; en CTX-POLI, un lock por ecosistema junto a su manifiesto y una sola compuerta que corre los tres comandos estrictos.`
10. §7.4, tabla de actores: reemplazar `| ACT-REV | La lista de §7.6, pregunta 5. |` por `| ACT-REV | La pregunta de §7.6 sobre quién actualiza el lock y qué mira el revisor. |`
11. §7.6, formato (C1-55): quitar la numeración de las seis preguntas (`**1. ¿` → `**¿`, … `**6. ¿` → `**¿`).
12. §7.6, primera respuesta: reemplazar `CPM sin lock no impide la deriva (E4-2); lock sin CPM congela, pero cada actualización es proyecto por proyecto. *Aplica*: en una solución con varios proyectos que se despliega, las dos [criterio]; en una biblioteca que se publica, CPM sí y lock no [B83]; en un único ejecutable, el lock es lo imprescindible.` por `CPM sin lock no garantiza la versión pedida (E4-2); lock sin CPM congela, pero cada actualización es proyecto por proyecto. La alternativa sin lock —versiones existentes, sin flotantes, \`NU1603\` como error, registros con mapeo y el SDK registrado— detiene la aproximación de E4-2 que el lock deja pasar en silencio, y pierde el \`contentHash\` contra la caché caliente (E4-3) **[criterio]**. *Aplica*: en una solución con varios proyectos que se despliega, las dos, con el lock en los ejecutables **[criterio]**; el lock de un proyecto común no gobierna a quien lo referencia [B83]; en un único ejecutable, el lock es lo imprescindible; sin lock, la política de §6.4.`
13. §7.6, P2: agregar al final ` *Aplica* al escribir cualquier paso de la CI o de la compuerta (ESC-05).`
14. §7.6, P3 (L1137): reemplazar `Depende de si es universal: npm y uv sí (E4-4, E4-5); NuGet sólo para los RID declarados (E4-1); \`pip-compile\` sin \`--universal\` no (E4-5). *Aplica* siempre que ESC-01 conviva con ESC-02/04/05:` por `Depende de si es universal: npm, pnpm, Yarn y uv sí (E4-4, E4-5); NuGet sólo para los RID declarados (E4-1); \`uv pip compile\` sin \`--universal\` no, y \`pip-compile\` nunca (E4-5, [B104]). *Aplica* siempre que una estación Windows con Visual Studio (ESC-01) conviva con Linux, el devcontainer o la CI (ESC-02, ESC-04, ESC-05):`
15. §7.6, P4: reemplazar `El mapeo de fuentes ataca la **confusión de dependencias**, con sus huecos (E4-3). Hash y mapeo son complementarios.` por `El mapeo de fuentes ataca la **confusión de dependencias**, cada ecosistema con su hueco: en NuGet, la caché caliente (E4-3); en npm, los paquetes internos sin *scope*; en pip, la búsqueda combinada en varios índices; en uv, lo que no se asignó a un índice \`explicit\` (§7.3). Hash y mapeo son complementarios. *Aplica* en cuanto hay un feed o registro privado.`
16. §7.6, P5: reemplazar `**[criterio sobre base del fabricante]**` por `**[criterio]** (sobre la base del fabricante)` y agregar al final ` *Aplica* a ACT-DEV y ACT-REV en todo PR que toque un lock.`
17. §7.6, P6: agregar al final ` *Aplica* cuando se propone el devcontainer (ESC-04) o la imagen de CI como sustituto del congelamiento.`
18. §7.6, insertar al final:

```markdown
**Llega un PR que cambia `packages.lock.json` sin tocar `Directory.Packages.props` ni ningún `.csproj`, y la compuerta está en verde. ¿Qué mirás y qué decidís?**
Que la compuerta pase dice que el lock coincide con lo declarado, no por qué cambió. Si no cambió ninguna dependencia declarada, alguien lo regeneró —con otro SDK, que aporta otros paquetes implícitos (E3-6), o con otro conjunto de RID (E4-1)— o lo editó. Se mira el diff: paquetes nuevos, orígenes nuevos y hashes que cambian sin cambio de versión; se pregunta con qué SDK se generó, y un hash que cambia sin versión se rechaza hasta explicarlo. *Aplica* a ACT-REV en CTX-NET y CTX-POLI.
```

19. §7.7: reemplazar `- tiene un lock por ecosistema, commiteado junto a su manifiesto, generado por la herramienta;` por `- tiene un lock por ecosistema —en .NET, en los ejecutables, o la política sin lock de §6.4 escrita en un ADR—, commiteado junto a su manifiesto y generado por la herramienta;`; y en las señales pobres reemplazar `lock en una biblioteca;` por `el lock de una biblioteca o de un proyecto común tratado como garantía para quien la referencia; .NET sin lock y con \`NU1603\` como simple advertencia;`.
20. Insertar entre §7.8 y el `---`:

```markdown
### 7.9 Práctica

1. Leé la salida del paso 5 de E4-2 en sus dos variantes, con y sin lock, y decí qué habría detenido la aproximación 8.0.2 → 9.0.0 en cada una. *Respuesta esperada*: sin lock, `NU1603` como error; con lock, una compuerta que compare `requested` con `resolved` (§7.2.1).
2. En una copia de E4-4, cambiá una versión en `package.json` sin regenerar el lock y corré `npm install` y `npm ci`. ¿Cuál falla y cuál reescribe? *Respuesta esperada*: `npm install` reescribe el lock con código 0; `npm ci` falla con `EUSAGE` (§7.2.2).
```

**Evidencia**: [B195] NU1603 (learn.microsoft.com, «A higher version was used instead», 2026-10-09); `evidencia-auditor/nu1603-sdk10/salida.txt` (SDK 10.0.400: sin lock `error NU1603 … 9.0.0 was resolved instead`, rc=1; con lock rc=0, `CentralTransitive`); E1 del abogado con SDK 8.0.425 (rc=1 / rc=0); voto de evidencia V2; [B83] cita de *Make lock file part of your source repository* (Informe-senior-dotnet-04); `pip-compile 7.6.2 --universal` → `No such option`, exit 2 (voto de evidencia V5); `evidencia-auditor/locks-multiplataforma/salida.txt` (pnpm 10.18.0 y Yarn 4.10.3: 26 variantes de `@esbuild/*` con `cpu`/`os` en el lock, instalada sólo `linux-x64`); [B198] npm *scope* («a scope only ever points to one registry»), [B110] uv índices (`first-index` contra la confusión de dependencias; `unsafe-best-match`, la más cercana a pip, expone a ese ataque; `explicit = true`), [B203] catálogo de RID, consultados el 2026-10-09.
**Verificación**: `grep -c 'sin advertencia\|sin advertir' GUIA` → 0; `grep -c "pip-compile\` sin \`--universal\`" GUIA` → 0; `grep -c '\[no verificado\]' ` sobre la tabla de §7.3, columnas pnpm y Yarn, fila Multiplataforma → 0; E4-2 paso 5 muestra las dos variantes (con y sin lock, y con `NU1603` como error) para SDK 8 y 10; E4-4 incluye pnpm y Yarn.

### P-11 · §8 Contenedores, devcontainers y estaciones Windows

- **Hallazgos**: C1-20 (L1221, §8.3), C1-21 (política, §8.4, §8.5, §8.6, §8.7), C1-38 (L1264), C1-44 (§8.4), C1-40 (L1311), C1-55, C1-22, C1-23.
- **Capa**: guía; origen en N5 y CI-06 (P-23). **Costo**: medio. **Reversible**: sí. **Derivados**: §3.6 (P-06), A.9, A.13 (P-16), B.3 (P-17), §12 paso 7 (P-15).

1. L1223: reemplazar `propone mitigarlo con Docker Scout o con Dependabot, que abre PR con el digest nuevo [B113].` por `propone mitigarlo con Docker Scout o con Dependabot, que según Docker abre PR con la etiqueta y el digest nuevos [B113]; la página de ecosistemas de GitHub dice que el ecosistema \`docker\` actualiza las referencias de imagen de los Dockerfile sin mencionar digests [B107], y el laboratorio no lo observó **[no verificado]** (requiere la plataforma).`
2. §8.2.2, «Política recomendada»: reemplazar el punto 1 (`1. **Digest en todo lo versionado** que nombra una imagen: …`) por los dos puntos siguientes y renumerar los actuales 2, 3 y 4 como 3, 4 y 5:

```markdown
1. **Digest en todo lo que construye artefactos publicados**: el `FROM` de la imagen de CI y de los Dockerfile de build, y `container.image` de la CI. Se escribe `repo:etiqueta@sha256:…`: la etiqueta queda como referencia humana y manda el digest.
2. **En el devcontainer, «mismo SDK», no «misma imagen»** (§8.6): o una etiqueta **fija** de SDK y SO (`mcr.microsoft.com/dotnet/sdk:8.0.425-bookworm-slim`, o la versión semántica de `devcontainers/dotnet`, que su README recomienda para fijar versión y SO y reserva el digest para las imágenes `dev-*`, que se actualizan en el lugar [B118]) más `global.json`, que detecta la deriva de la capa 2 (E5-6); o la **misma receta** que la imagen de CI (`build.dockerfile`), cuyas bases por digest mantiene el bot de la CI. Un digest en la `image` de `devcontainer.json` sólo con un bot que lo actualice: en un repositorio privado el ecosistema `devcontainers` de Dependabot no está soportado [B107].
```

3. L1264: reemplazar `3. **Lo que tiene que ser idéntico entre ESC-01 y ESC-04**:` por `3. **Lo que tiene que ser idéntico entre la estación Windows (ESC-01) y el devcontainer (ESC-04)**:`
4. §8.3, primera fila «Transversal»: reemplazar `que Dependabot actualice un \`FROM …@sha256\` fijado por digest **[no verificado]** en la documentación oficial.` por `Docker documenta que Dependabot actualiza etiqueta y digest de las imágenes base [B113]; la página de ecosistemas de GitHub no menciona digests [B107] y el laboratorio no lo observó **[no verificado]** (requiere la plataforma).`
5. §8.4, fila ESC-01: reemplazar `**[hallazgo negativo, a revalidar]**` por `**[no verificado]** (hallazgo negativo, a revalidar)` (cubierto también por P-03). Fila ESC-04: reemplazar `| ESC-04 Devcontainer | Capas 2 y 4 por digest; *features* con lock | Capas 1, 3, 6 |` por `| ESC-04 Devcontainer | Capa 2 por etiqueta fija verificada con \`global.json\`, o la receta de la imagen de CI; *features* con lock | Capas 1, 3, 6 |`.
6. §8.4, insertar tras la tabla: `Por contexto: en CTX-NET el devcontainer no reemplaza a Visual Studio para quien trabaja en ESC-01 (§8.2.4); en CTX-NODE y CTX-PY, la imagen oficial del runtime con \`npm ci\` o \`uv sync --locked\`; en CTX-POLI, la imagen trae los tres toolchains o la build se parte por componente (§11.2.6).`
7. §8.5, bloque `devcontainer.json`: reemplazar el bloque por

````markdown
```jsonc
// .devcontainer/devcontainer.json — sólo .NET + Node; etiqueta FIJA de SDK y SO (§8.2.2).
// La variante políglota, construida con la receta de la imagen de CI, está en A.9.
{
  "name": "solucion",
  "image": "mcr.microsoft.com/dotnet/sdk:8.0.425-bookworm-slim",
  "features": {
    // Sin "version", la feature instala "lts", que cambia aunque el lock de features no cambie.
    "ghcr.io/devcontainers/features/node:1": { "version": "24.21.0" }
  },
  "postCreateCommand": "git config core.hooksPath .githooks && dotnet --version && node --version"
}
```
````

8. §8.6, formato (C1-55): quitar la numeración (`**1. ¿` → `**¿`, …) y poner la respuesta en línea propia (`?** ` → `?**` + salto de línea).
9. §8.6, P2: reemplazar la respuesta `Digest en todo lo que construye artefactos o define el entorno compartido; etiqueta flotante sólo donde se acepta deriva. El costo medido: con el digest de septiembre, la imagen siguió con OpenSSL 3.0.20 cuando la etiqueta ya traía 3.0.22. El digest convierte los parches en trabajo explícito.` por `Digest en todo lo que construye artefactos publicados, con un bot que proponga el digest nuevo; en el devcontainer, etiqueta fija de SDK y SO, o la receta de la imagen de CI. Etiqueta flotante sólo donde se acepta deriva. El costo medido: con el digest de septiembre, la imagen siguió con OpenSSL 3.0.20 cuando la etiqueta ya traía 3.0.22. El digest convierte los parches en trabajo explícito. *Aplica* a toda referencia a una imagen en el repo; en un repositorio privado, revisar antes qué ecosistemas del bot están soportados [B107].`
10. *Aplica* faltantes en §8.6: P4 ` *Aplica* a CTX-NET y CTX-POLI con estaciones Windows.`; P5 ` *Aplica* al escribir las reglas de convivencia del equipo (§8.2.4).`; P7 ` *Aplica* cuando alguien versiona \`devcontainer-lock.json\` y da por congeladas las dependencias.`
11. §8.6, insertar al final:

```markdown
**Tu repo es privado, el devcontainer apunta a `sdk:8.0@sha256:…` y nadie lo tocó en cinco meses. ¿Está bien congelado?**
Está congelado, no mantenido: el sistema de desarrollo no recibió parches desde que se fijó el digest (E5-2 muestra un mes de diferencia en OpenSSL), y en un repositorio privado el ecosistema `devcontainers` de Dependabot no está soportado [B107]. Para desarrollar alcanza «mismo SDK»: etiqueta fija de SDK y SO más `global.json`, o la receta de la imagen de CI, cuyo bot sí la actualiza. *Aplica* a ESC-04 en repositorios privados.
```

12. §8.7: reemplazar `- nombra toda imagen por digest y tiene un mecanismo (bot o trabajo) que propone el digest nuevo como PR;` por `- nombra por digest toda imagen que construye artefactos publicados, con un mecanismo (bot o trabajo) que propone el digest nuevo como PR; en el devcontainer usa una etiqueta fija verificada por \`global.json\` o la receta de la imagen de CI;`. Señales pobres: agregar al final, antes del punto, `; un digest en el devcontainer de un repo privado que ningún bot actualiza`.
13. Insertar entre §8.8 y el `---`:

```markdown
### 8.9 Práctica

1. Con la salida de E5-2, decí qué cambió entre los dos digests de `sdk:8.0` y si cambió el SDK. *Respuesta esperada*: el mismo SDK 8.0.425; cambiaron OpenSSL, `libexpat1`, `libpcre2-8-0`, Perl y `tzdata` (§8.2.2).
2. Antes de correr E5-1, predecí si el `.cs` en cp1252 compila dentro de la imagen fijada por digest. *Respuesta esperada*: no, `CS1056`; compila recién al convertir el archivo en el repo (§8.2.1).
```

**Evidencia**: [B107] tabla de Dependabot (2026-10-09: `docker` soportado en privados, «detect and update base image references in Dockerfiles», sin mención de digests; `devcontainers`, «Private Repositories: Not supported»); [B113] Docker; [B118] README de `devcontainers/images/src/dotnet` (2026-10-09: etiquetas `…-noble` «to pin to an OS version», semánticas `2.3.1-10.0-noble`, y «dev- prefix … may be updated in place; pin the image»); etiqueta `mcr.microsoft.com/dotnet/sdk:8.0.425-bookworm-slim` presente en el registro (`/v2/dotnet/sdk/tags/list`, 2026-10-09).
**Verificación**: `grep -c 'Digest en todo lo versionado' GUIA` → 0; el bloque de §8.5 es JSONC válido (mismo validador que EA-1); `docker buildx imagetools inspect mcr.microsoft.com/dotnet/sdk:8.0.425-bookworm-slim` devuelve un digest.

### P-12 · §9 Procedencia

- **Hallazgos**: C1-54 (pieza → artefacto), C1-57 (L1449), C1-43 (§9.2.3), C1-34 (L1459), C1-17 (L1484, L1570), C1-32 (L1486, L1496, §9.5), C1-18 (L1496, §9.4, §9.6, §9.7), C1-16 (§9.6 P1), C1-04 (§9.6 P1), C1-38 (L1520), C1-51 (§9.5), C1-22, C1-23, C1-55.
- **Capa**: guía; origen en N6 y en `03-Marco-De-Referencia.md` (P-23). **Costo**: medio. **Reversible**: sí. **Derivados**: §11.2.8, §11.6 (P-14), §12 paso 8 (P-15), B.3 (P-17), Anexo F.

1. Pieza → artefacto en §9: L1379 `una pieza que ya está publicada` → `un artefacto que ya está publicado`; fila de definición `| **Pieza** (artefacto) |` → `| **Artefacto** |`; `grabados **dentro** de la pieza` → `grabados **dentro** del artefacto`; `Inventario de los componentes de la pieza` → `Inventario de los componentes del artefacto`; `Atestación que identifica la pieza por digest` → `Atestación que identifica el artefacto por digest`; `Reconstruir la pieza desde el commit` → `Reconstruir el artefacto desde el commit`; diagrama `        A["pieza (sha256)"]` → `        A["artefacto (sha256)"]`; `Compilando la pieza .NET` → `Compilando el artefacto .NET`; `| Commit en la pieza |` → `| Commit en el artefacto |`; `| ESC-02 / ESC-03 | Reconstruir una pieza publicada` → `| ESC-02 / ESC-03 | Reconstruir un artefacto publicado`; `(1) el digest de la pieza;` → `(1) el digest del artefacto;`; `Una pieza trazable:` → `Un artefacto trazable:`. Los nombres de archivo `Pieza.dll` de los bloques de código quedan.
2. L1449 (C1-57): reemplazar `**\`npm pack\` dio el mismo tarball** desde dos rutas con fechas distintas: todas las entradas llevan \`mtime\` fijo 1985-10-26T08:15:00Z (E6-3) **[observado]**;` por `**Con npm 11.19.0, \`npm pack\` dio el mismo tarball** desde dos rutas con fechas de archivo distintas: las dos entradas del paquete de prueba llevan \`mtime\` fijo 1985-10-26T08:15:00Z (E6-3) **[observado]**; no se probaron otro usuario, otro *umask* ni otra versión de npm;`
3. L1459: reemplazar `| SPDX | 3.0.1 [B155] | ISO/IEC 5962:2021 [B155] |` por `| SPDX | 3.0.1 [B155] | ISO/IEC 5962:2021 normaliza la versión **2.2.1** [B194] |`.
4. L1462 (C1-43): reemplazar `**[criterio]** El formato lo elige el consumidor; conviene **uno solo** por solución, aunque cada ecosistema lo genere con su herramienta.` por `**[criterio]** El formato lo elige el consumidor, y conviene **uno solo** por solución aunque cada ecosistema lo genere con su herramienta. Sin un consumidor que pida otro, CycloneDX: es el que emitieron las tres vías que el laboratorio usó para cubrir una solución políglota (syft, los exportadores nativos y su unión con \`cyclonedx-cli\`, E8-6). SPDX cuando el consumidor lo exige o cita la norma ISO, sabiendo que la versión normalizada es la 2.2.1 [B194] y que BuildKit emite SPDX (E8-6).`
5. Tabla SBOM/procedencia de §9.2.3, fila «Firma»: reemplazar `| Firma | Opcional | Requisito desde SLSA Build L2 |` por `| Firma | Opcional | Requisito desde SLSA Build L2; L1 exige \`builder.id\` [B09] |`.
6. L1484 (C1-17): reemplazar `el commit en \`vcs:revision\`; \`builder.id\` **vacío**, porque una build local no tiene identidad de plataforma.` por `el commit en \`vcs:revision\`; \`builder.id\` **vacío**, porque una build local no tiene identidad de plataforma. Con \`builder.id\` vacío esa procedencia **no alcanza SLSA Build L1**: la especificación lo exige desde L1, lo presenta como «el único determinante» del nivel y pide al consumidor aceptar sólo pares firmante/\`builder.id\` conocidos [B09]. Llega a L1 cuando la plataforma de CI que corre BuildKit la identifica en \`builder.id\`; cómo completarlo en BuildKit no se verificó **[no verificado]**.`
7. L1486 (C1-32): reemplazar `Es mejor que nada, pero hay que llamarlo por su nombre.` por `Es mejor que nada, pero hay que llamarlo por su nombre: a lo sumo, L1 firmado por un inquilino de la plataforma. Y \`verify-blob-attestation\` comprueba la firma, el \`subject\` y el tipo de predicado; por sí solo no evalúa su contenido (\`builder.id\`, repositorio, commit, parámetros), de modo que un predicado falso firmado con la clave legítima verifica igual. Esa comprobación es un paso aparte, con una política que fije lo esperado [B10].`
8. L1496 (C1-18 b, C1-32): reemplazar el párrafo `**[criterio] Para el caso** (repositorio privado de una organización, equipo chico): …` por:

```markdown
**[criterio] Para el caso** (repositorio privado de una organización, equipo chico, artefactos internos), la tercera pregunta del caso se contesta con el **registro del entorno** y el SBOM que la CI graba junto al artefacto (§3.4, §9.6). La procedencia firmada se agrega cuando hay un consumidor externo que la verifique, un requisito contractual o un repositorio público (§12, paso 8b). Si se agrega y el plan no es Enterprise Cloud, las atestaciones nativas de GitHub no están disponibles para ese repo, y las de npm y PyPI no aplican a paquetes privados. Quedan tres caminos, cada uno con su nivel declarado sin inflarlo:

- **GitLab** con los metadatos del runner más un paso de firma [B159].
- **BuildKit + cosign con clave propia**: la clave en un job aparte que no ejecuta código del PR, detrás de un entorno con aprobación y fuera del alcance de los pasos de build; a lo sumo, L1 firmado por un inquilino.
- **cosign sin clave**, con el token OIDC de la CI: Fulcio emite un certificado efímero atado a la identidad del workflow, y el evento se registra en el log de transparencia público Rekor «para que sea auditable públicamente» [B197]. El costo, para un repositorio privado, es que esa identidad queda publicada en el log; la alternativa es una instancia propia de Sigstore [B197]. No se ejercitó en el laboratorio **[no verificado]**.
```

9. §9.4, fila ESC-05: reemplazar `| ESC-05 CI | **Todo**: \`ContinuousIntegrationBuild\`, \`SOURCE_DATE_EPOCH\`, SBOM, procedencia, firma, publicación junto al artefacto | — |` por `| ESC-05 CI | Siempre: \`ContinuousIntegrationBuild\`, \`SOURCE_DATE_EPOCH\`, registro del entorno y SBOM junto al artefacto. Si un consumidor la verifica: procedencia firmada, con su nivel declarado | — |`.
10. L1520: reemplazar `En CTX-POLI aparecen tres SBOM distintos según el **alcance** —artefacto, dependencias declaradas, entorno de build— y una procedencia que nombra por digest las imágenes de los tres toolchains` por `En CTX-POLI (los tres ecosistemas en un repo) aparecen tres SBOM distintos según el **alcance** —artefacto, dependencias declaradas, entorno de build— y una procedencia de BuildKit que nombra por digest las imágenes de los tres toolchains, sin firma ni \`builder.id\``.
11. §9.5, bloque YAML (C1-51): reemplazar `  - uses: actions/attest@v4` por `  - uses: actions/attest@1e69f48acb82d1966a394da916b4c1698aa569d6 # v4.2.2 (git ls-remote, 2026-10-09)`.
12. §9.5, bloque cosign: reemplazar `# Sin plataforma que firme (E6-5): cosign sobre la procedencia de BuildKit. NO es SLSA L2.` por `# Sin plataforma que firme (E6-5): cosign sobre la procedencia de BuildKit. NO es SLSA L2; con builder.id vacío, tampoco L1.`; y `--type slsaprovenance1 --insecure-ignore-tlog Pieza.dll        # falla si cambia 1 byte o el predicado` por `--type slsaprovenance1 --insecure-ignore-tlog Pieza.dll        # falla si cambia 1 byte o se edita lo firmado; NO verifica builder.id ni commit`.
13. §9.6, formato (C1-55): `?** ` → `?**` + salto de línea en cada pregunta.
14. §9.6, P1 (C1-04, C1-16): reemplazar `(3) el toolchain efectivo;` por `(3) el toolchain efectivo, incluida la versión del compilador (en .NET, \`#error version\` provoca el \`CS8304\` con la versión del compilador [B57]);` y reemplazar `Una procedencia SLSA de la plataforma da 1, 4, 6 y casi siempre 2; el SBOM da 5; el 3 hay que agregarlo si la procedencia no lo trae.` por `Una procedencia firmada por la plataforma da 1, 2 y 6, y deja el entorno como opcional [B202]; la de BuildKit da además 4, sin firma (§9.2.4); el SBOM da 5; el 3, y el 4 si nadie lo trae, los agrega el registro del entorno.`
15. *Aplica* faltantes en §9.6: `¿SBOM o procedencia?` → agregar ` *Aplica*: SBOM en todo artefacto que salga de la CI; procedencia firmada cuando un consumidor la verifica (§12, paso 8b).`; `¿Cómo verifico…?` → ` *Aplica* en Linux, WSL, devcontainer o CI (ESC-02 a ESC-05) con la misma imagen que la CI; en una estación Windows con Visual Studio no se espera el mismo hash (§8.2.4).`; `¿El SHA en \`InformationalVersion\` alcanza?` → ` *Aplica* al diagnosticar en cualquier escenario; nunca como prueba ante un tercero.`; `¿Meto el SBOM dentro del paquete?` → ` *Aplica* en CTX-PY (PEP 770); en CTX-NET y CTX-NODE el SBOM viaja al lado.`
16. §9.6, P4 (C1-17, C1-18): reemplazar la respuesta `**[criterio]** L1 de inmediato (BuildKit o el runner de GitLab ya la generan); L2 como objetivo en cuanto la plataforma lo ofrezca para el repositorio; L3 sólo con un requisito externo. Sin declarar L2 por firmar con una clave propia.` por `**[criterio]** Primero, el registro del entorno y el SBOM, que no dependen de ningún nivel. L1 cuando la CI genere la procedencia con un \`builder.id\` que la identifique: la de BuildKit tal como sale en E6-5, con \`builder.id\` vacío, no lo alcanza (§9.2.4). L2 cuando un consumidor la verifique y la plataforma lo ofrezca para el repositorio; L3 sólo con un requisito externo. Sin declarar L2 por firmar con una clave propia. *Aplica* a ACT-OPS al declarar un nivel ante un cliente o un auditor.`
17. §9.6, insertar al final:

```markdown
**Un cliente pide «procedencia SLSA L2» del binario que le entregan. El repo es privado, el plan es Team y la CI ya graba el registro del entorno y un SBOM. ¿Qué le contestás?**
Que hoy podés entregar registro del entorno y SBOM, y procedencia L1 cuando la CI la genere con un `builder.id` que la identifique. Las atestaciones nativas de GitHub, que darían L2, requieren Enterprise Cloud en un repositorio privado [B158], y una firma con clave propia no es L2 (§9.2.4). Las salidas honestas son cambiar de plan o de plataforma, o declarar el nivel alcanzado. *Aplica* a todo pedido de nivel SLSA sobre lo que sale de la CI (ESC-05).
```

18. §9.7: reemplazar `- su procedencia la firma la plataforma, o se declara con honestidad qué nivel se alcanzó;` por `- si un consumidor la verifica, su procedencia la firma la plataforma, o se declara con honestidad qué nivel se alcanzó;`. Señales pobres: agregar `declarar L1 con una procedencia sin \`builder.id\`; dar por verificado el predicado porque \`verify-blob-attestation\` pasó;` antes de `contar con atestaciones de GitHub`.
19. Insertar entre §9.8 y el `---`:

```markdown
### 9.9 Práctica

1. Con la salida de E6-2, decí qué cambia entre la corrida (1) y la (8) y por qué el `.nupkg` difiere aunque DLL y PDB coinciden. *Respuesta esperada*: en (8), el SDK 11 con `SOURCE_DATE_EPOCH` fija las fechas del zip; en (1), el zip guarda fechas del disco y un nombre aleatorio (§9.2.1).
2. Con la procedencia de E6-5, marcá cuáles de los seis metadatos de §9.6 trae y cuáles faltan. *Respuesta esperada*: trae el digest del artefacto, el commit y la imagen del SDK por digest; faltan la identidad de la plataforma (`builder.id` vacío) y el toolchain efectivo como dato propio.
```

**Evidencia**: [B194] IEC Webstore, ISO/IEC 5962:2021 «Information technology - SPDX® Specification V2.2.1», publicada el 2021-08-24 (2026-10-09); [B09] SLSA v1.2 *Build provenance*: `builder.id` «REQUIRED for SLSA Build L1», «intended to be the sole determiner of the SLSA Build level», «Consumers MUST accept only specific signer-builder pairs» (2026-10-09); salida E6-5 `runDetails.builder={'id': ''}`; [B197] Sigstore *Signing overview*: «Fulcio issues short-lived certificates binding an ephemeral key to an OpenID Connect identity», «Clients upload signing events to the transparency log so that the events are publicly auditable», configuración propia apuntando a servidores propios (2026-10-09); [B202] `slsa-framework/github-actions-buildtypes` `workflow/v1`: `resolvedDependencies` «SHOULD contain an entry identifying the resolved git commit ID» y «MAY contain … the specific versions of the virtual environments used» (2026-10-09); `git ls-remote https://github.com/actions/attest` → `1e69f48acb82d1966a394da916b4c1698aa569d6 refs/tags/v4` = `refs/tags/v4.2.2` (2026-10-09); salida E6-3 (`node v24.21.0 / npm 11.19.0`, dos entradas).
**Verificación**: `grep -c 'L1 de inmediato' GUIA` → 0; `grep -c 'actions/attest@v4$' GUIA` → 0; `grep -n '5962' GUIA` muestra «2.2.1»; `grep -cw 'pieza' GUIA` sólo en §1.1 (pregunta 3) y en nombres de archivo.

### P-13 · §10 Compuertas y gobierno

- **Hallazgos**: C1-05 (alcance, inventario, dos scripts, señal pobre), C1-06 (§10.4 ESC-01, falta de herramienta), C1-19 (§10.2.7), C1-28 (§10.5), C1-49 (§10.2.8), C1-08 (§10.6), C1-38 (L1759), C1-40 (L1696), C1-22, C1-23, C1-55.
- **Capa**: guía; origen en N7 (P-23) y en el laboratorio (`compuerta.sh`, P-22). **Costo**: medio. **Reversible**: sí. **Derivados**: A.11, A.12, A.14 (P-16), B.1, B.3 (P-17), §11 (P-14).

1. §10.2.2, insertar tras el párrafo de L1667 (`…La misma compuerta sirvió sin cambios para un repo .NET (E7-1), uno Node y uno Python (E7-7).`):

```markdown
**Alcance declarado.** La compuerta de `Examples/N7-compuertas-y-gobierno/compuerta/` busca cada archivo **en la raíz** del repo: vale para un repo con un proyecto por ecosistema en la raíz (E7-1, E7-7). En una solución políglota que ubica `.python-version`, `uv.lock` y `package-lock.json` en subcarpetas, como recomienda §11.2.3, esa misma compuerta los declara `n/a` aunque existan. Ahí hace falta un **inventario explícito de proyectos por ecosistema** —la variante de §11, `solucion/verificar.sh`, lo tiene escrito en el script— o un descubrimiento de manifiestos que falle ante uno que no figure en el inventario **[criterio]**. «Compuerta única» quiere decir un solo programa por repositorio: `compuerta.sh` (N7) y `verificar.sh` (N8) son dos ejemplos del mismo diseño para dos disposiciones, no dos compuertas para un mismo repo. Y **una herramienta que falta no es una violación**: la compuerta dice «falta `python3`» y no «la política no se cumple», para que nadie apague el hook por un falso rojo.
```

2. §10.2.6, L1696: lo cambia P-03 (`**[criterio]** (apoyado en E7-4 y [B83])`).
3. §10.2.7, L1716: reemplazar `En GitHub, las ramas protegidas, los dueños de código requeridos y los *rulesets* están disponibles en repositorios **públicos** con el plan Free y en privados sólo con Pro, Team o Enterprise [B176][B177][B179]. En GitLab las ramas protegidas están en Free, pero la aprobación obligatoria de dueños es Premium/Ultimate [B185].` por `En GitHub, las ramas protegidas, los dueños de código requeridos y los *rulesets* están disponibles en repositorios **públicos** con el plan Free y en privados con Pro, que es un plan de cuentas personales, o con Team y Enterprise, los de organizaciones [B176][B177][B179]: para el repositorio de una organización, el mínimo es Team. En GitLab, las ramas protegidas y «Pipelines must succeed» están en Free —la segunda impide fusionar un *merge request* sin una pipeline exitosa, incluido el que no tiene ninguna [B199]—, pero la aprobación obligatoria de dueños es Premium/Ultimate [B185].`
4. §10.2.7, tabla de controles: reemplazarla entera por

```markdown
| Control | Qué impide | Qué no impide | Evidencia |
|---|---|---|---|
| Rama protegida con chequeo requerido (GitHub, si el plan la ofrece) | El merge o el push sin el chequeo aprobado | Un PR que edita la compuerta o el workflow para que salgan 0: el evento `pull_request` corre el código del *merge commit* del PR [B200]; un job `skipped`, que satisface el chequeo; a los administradores, salvo que se los incluya [B177] | [B177][B186][B200] |
| Rama protegida sin push directo + «Pipelines must succeed» (GitLab, también en Free) | Fusionar sin una pipeline exitosa | Un MR que edita `.gitlab-ci.yml` o la compuerta, si la aprobación de dueños no es obligatoria (Premium/Ultimate) | [B185][B199] |
| `pre-receive` en un servidor propio | El push completo (`pre-receive hook declined`, `main` intacto) | Nada mientras el hook corra en el servidor; su tiempo está acotado en GHES (abajo) | E7-5, [B175] |
| Compuerta en el **acto irreversible**: publicar sólo desde `main`, corriendo la compuerta sobre ese commit en un clon limpio, sin reescribir una versión publicada | Publicar desde un estado que no cumple | Que `main` quede rojo un rato | E7-5 |
| Regla escrita + revisión periódica de que `main` está en verde | Nada en el momento; detecta | Todo | **[criterio]** |

**[criterio]** «Impide» vale de verdad cuando, además del chequeo requerido, la revisión de dueños es obligatoria sobre los archivos de la compuerta (`/.github/`, `/tools/ci/`, A.14), la aprobación del último push la hace alguien distinto de quien lo empujó y los administradores están incluidos en la regla [B177].
```

5. §10.2.8, tabla de roles: fila ACT-ARQ, columna «Decide»: reemplazar `Política de texto, toolchain, dependencias; cuándo se descongela una mayor` por `Política de texto, toolchain, dependencias, estrategia de imagen (única o por componente); cuándo se descongela una mayor`. Fila ACT-OPS, «Decide»: reemplazar `Imagen de CI y devcontainer, compuerta, bots, protección de rama` por `Construcción, digest y mantenimiento de las imágenes de CI y devcontainer; compuerta, bots, protección de rama`.
6. §10.4, fila ESC-01, columna «Qué cambia»: reemplazar por `El hook de A.11 necesita en la estación \`bash\` (el de Git for Windows), \`python3\` con el paquete \`EditorConfig==0.17.1\` y los dos archivos de la compuerta en \`tools/ci/\`; para los pasos de toolchain y grafo, las herramientas que el repo declara. A mano, desde Git Bash en la raíz del clon: \`bash tools/ci/compuerta.sh\` **[no verificado]** (requiere Windows). La integración de git de Visual Studio con \`core.hooksPath\` **[no verificado]** (requiere Windows). Es donde el problema del caso no se ve: la CI en Linux lo revela.`
7. L1759: reemplazar `En CTX-POLI la compuerta corre sus tres pasos para los tres ecosistemas a la vez;` por `En CTX-POLI (los tres ecosistemas en un repo) la compuerta corre sus tres pasos para los tres ecosistemas a la vez, sobre el inventario de proyectos de §10.2.2;`.
8. §10.5, bloque `publicar.sh` (C1-28): reemplazar el bloque por

````markdown
```bash
# publicar.sh <remoto> <commit> <version> — compuerta en el acto irreversible
# (extracto de E7-5; la ruta de la compuerta, adaptada a A.11).
tmp=$(mktemp -d); git clone -q "$remoto" "$tmp/r" && cd "$tmp/r" || exit 2   # clon limpio, no el árbol de quien publica
git merge-base --is-ancestor "$commit" origin/main || exit 1     # sólo desde main
git rev-parse -q --verify "refs/tags/v$version" && exit 1        # no reescribir lo publicado
git checkout -q "$commit" && tools/ci/compuerta.sh > compuerta.txt || exit 1
git tag -a "v$version" -m "v$version" && git push origin "v$version"
# compuerta.txt viaja con el artefacto como registro de entorno (§9)
```
````

9. §10.6, formato: `?** ` → `?**` + salto de línea.
10. *Aplica* faltantes en §10.6: `¿Alcanza con un hook?` → ` *Aplica* a todo equipo: el hook es para ACT-DEV; la defensa es la CI (ESC-05).`; `¿Uso pre-commit o un script propio?` → reemplazar `Si se adopta, la política la sigue haciendo cumplir un chequeo que lee \`.editorconfig\`.` por `Si se adopta, la política la sigue haciendo cumplir un chequeo que lee \`.editorconfig\`: el del laboratorio o editorconfig-checker (§5.2.5). *Aplica* al elegir cómo se instalan los hooks en las estaciones y el devcontainer (ESC-01 a ESC-04).`; `¿Cómo se descongela algo…?` → ` *Aplica* a ACT-ARQ y ACT-OPS en cada subida de SDK, runtime, imagen o paquete mayor.`; `¿Por qué un lock que cambia sin su manifiesto es sospechoso?` → ` *Aplica* a ACT-REV en CTX-NET y CTX-POLI.`; `¿Qué hago si la plataforma no ofrece protección de rama?` → ` *Aplica* a repositorios privados en planes sin protección de rama (§10.2.7).`; `¿Hay que fijar también las herramientas de la compuerta?` → ` *Aplica* a ACT-OPS al escribir la compuerta y su workflow.`
11. §10.6, insertar al final:

```markdown
**El hook de un compañero en Windows rechaza su commit con «la política de .editorconfig/.gitattributes no se cumple», pero su `.cs` es UTF-8 válido. ¿Qué mirás antes de dejarlo usar `--no-verify`?**
Si la estación tiene lo que la compuerta necesita: `bash`, `python3`, el paquete `EditorConfig` y `check_text_policy.py` junto a `compuerta.sh` (§10.4). Sin `python3` el verificador no corre, y una compuerta que no distingue «falta herramienta» de «violación» informa lo segundo. Se instala lo que falta o se corrige la compuerta para que lo diga; `--no-verify` sólo traslada el problema a la CI. *Aplica* a ESC-01 (Windows con Visual Studio).
```

12. §10.7, señales pobres: agregar al final, antes del punto, `; la compuerta dice \`n/a\` para un archivo que existe en una subcarpeta; la compuerta informa «violación» cuando lo que falta es una herramienta; documentar que la rama protegida «impide» sin decir qué no impide`.
13. Insertar entre §10.8 y el `---`:

```markdown
### 10.9 Práctica

1. Revisá el PR de E7-4 que sube el SDK con la lista B.4. ¿Lo aprobás? *Respuesta esperada*: sí, porque mueve juntos `global.json`, la receta de la imagen y el ADR, y la compuerta pasa en la imagen nueva (§10.2.6).
2. Con la tabla de §10.2.7, escribí qué impide y qué no impide la configuración de tu plataforma y tu plan, y qué control compensatorio agregás donde no impide nada.
```

**Evidencia**: [B177] GitHub *About protected branches* (2026-10-09: «Required status checks must have a `successful`, `skipped`, or `neutral` status»; «By default, the restrictions of a branch protection rule don't apply to people with admin permissions»; «the most recent reviewable push must be approved by someone other than the person who pushed it»); [B176] GitHub *plans* (Pro, plan de cuentas personales; Team, de organizaciones; ambos con ramas protegidas en privados); [B199] GitLab *Auto-merge* (Tier Free, Premium, Ultimate; «A merge request with no pipelines at all is not considered to have a successful pipeline, and cannot merge»); [B200] GitHub *Events that trigger workflows* (`pull_request`: `GITHUB_SHA` = «Last merge commit on the `GITHUB_REF` branch»; `pull_request_target` corre en el contexto de la rama base); E1 del arquitecto (compuerta de N7 sobre la solución de N8: `[n/a] toolchain Python`, `[n/a] grafo npm`, `[n/a] grafo uv`); `publicar.sh` de E7-5 (l. 8–17).
**Verificación**: la compuerta de N7 corrida sin `python3` imprime una línea que nombra la herramienta faltante y no la palabra «política» (P-22); `grep -c 'sólo con Pro, Team o Enterprise' GUIA` → 0; el extracto de `publicar.sh` contiene `git clone`.

### P-14 · §11 Una sola solución con .NET, Node.js y Python

- **Hallazgos**: C1-33 (L1915), C1-12 (punto 3, tabla), C1-29 (L1941, §11.7), C1-14 (§11.2.6, §11.3, §11.6 P2), C1-16 (§11.2.8, diagrama, §11.6 P4), C1-15 (§11.5), C1-06 (§11.4 ESC-01), C1-21 (§11.4 ESC-04), C1-18 (§11.4 ESC-05, §11.7), C1-11 (L2127), C1-38 (L2139), C1-13 (§11.8), C1-22, C1-23, C1-55.
- **Capa**: guía; origen en N8 (P-23) y en el laboratorio (P-22). **Costo**: alto. **Reversible**: sí. **Derivados**: E8-3, E8-6, `Dockerfile.por-componente`, A.9–A.12.

1. L1915 (C1-33): reemplazar `índices de uv con \`explicit = true\` y la estrategia \`first-index\` contra la confusión de dependencias [B110]—, ninguno dependiente de la configuración del usuario, y la compuerta corriendo los tres comandos estrictos.` por `índices de paquetes de uv con la estrategia \`first-index\` contra la confusión de dependencias y \`explicit = true\` para los internos, que protege sólo lo asignado a ese índice [B110]—, ninguno dependiente de la configuración del usuario, cada uno con el hueco que dice §7.3, y la compuerta corriendo los tres comandos estrictos.`
2. §11.2.5, punto 3 (C1-12): reemplazar `\`global.json\` no cubre a Node ni a Python; dentro de esta frontera, \`engines\` + \`engine-strict\` es lo único que hace cumplir la versión de Node.` por `\`global.json\` no cubre a Node ni a Python. Dentro de esta frontera hace cumplir la versión de Node lo que evalúa npm: \`devEngines.runtime\`, que falla por defecto en \`npm ci\` y \`npm run\` sin configuración adicional (\`EBADDEVENGINES\` con npm 10.9.8 y 11.19, E8-3), o, alternativamente, \`engines\` + \`engine-strict\`.`
3. Tabla «Criterio de elección», fila 1: reemplazar `| A en la estación, **con** \`npm ci\`, \`uv run --locked\`, \`engine-strict\` e \`Inputs\`/\`Outputs\` |` por `| A en la estación, **con** \`npm ci\`, \`uv run --locked\`, \`devEngines\` (o \`engine-strict\`) e \`Inputs\`/\`Outputs\` |`.
4. L1941 (C1-29): reemplazar `**[criterio]** La comparación A = B se hace con la configuración de publicación explícita.` por `**[criterio]** La igualdad no se comprueba en la estación —F5 compila en \`Debug\` y sin \`ContinuousIntegrationBuild\` (§9.4)—: se comprueba en la CI como **prueba de regresión del \`.csproj\`**, con la misma imagen corriendo \`dotnet build -c Release -p:ContinuousIntegrationBuild=true\` con \`ConstruirPoliglota=true\` y \`build.sh\`, y comparando las DLL. Lo que demuestra es que los targets de A no divergen de B, no que la estación reproduzca a la CI.`
5. L1967 (C1-14): reemplazar `Construir la imagen de desarrollo \`FROM\` la misma base que la CI (§8.2.6) en la variante única se cumple por construcción.` por `Construir la imagen de desarrollo \`FROM\` la misma base que la CI (§8.2.6) se cumple por construcción **si la CI también usa la imagen única**. Con CI por componente, el Python de desarrollo lo instala uv y el de la CI viene de \`python:3.12.15-slim\`: la misma versión, de dos orígenes, que hay que declarar.`
6. §11.2.7: insertar tras la primera oración `[criterio]` (tras `el mismo comando que la estación y el devcontainer.`): ` Por componente sólo si los componentes se publican por separado, con una etapa previa que corre la compuerta completa en la imagen única: el Dockerfile por componente del laboratorio sólo corre los comandos estrictos de cada ecosistema, no la compuerta de texto.`
7. §11.2.8, L1981 (C1-16): reemplazar `La procedencia exportada por BuildKit no está firmada: la firma la agrega la plataforma de CI (§9.2.4).` por:

```markdown
La procedencia exportada por BuildKit no está firmada y su `builder.id` sale vacío (§9.2.4). La que firma la plataforma, como la de `actions/attest`, exige en sus dependencias resueltas sólo el commit y deja el entorno como opcional [B202]. Para contestar «con qué entorno se ensambló» hay entonces tres piezas distintas **[criterio]**: (a) la procedencia de la plataforma, firmada, que nombra commit y workflow; (b) los materiales del entorno —digest de la imagen del job o de cada etapa, toolchain efectivo—, que registra un paso del pipeline; (c) cómo se atan: un predicado propio firmado en la misma corrida, rotulado como afirmación del pipeline y no de la plataforma (la vara de §9.2.4), o la atestación de la imagen del job, enlazada por su digest.
```

8. Diagrama de §11.2.9: reemplazar `        REG["registro del entorno"]` por `        REG["registro del entorno<br/>imagen por digest · toolchain efectivo"]`; `        PRV["procedencia: bases por digest, firmada en CI"]` por `        PRV["procedencia firmada por la plataforma (commit)<br/>o de BuildKit (bases por digest, sin firma)"]`; y `    MSB["Visual Studio / dotnet build<br/>(MSBuild llama a npm y uv)"] -.->|"mismo resultado (Release, misma ruta)"| NET` por `    MSB["Visual Studio / dotnet build<br/>(MSBuild llama a npm y uv)"] -.->|"mismo resultado: prueba de regresión en CI"| NET`.
9. §11.3, tabla de decisiones (C1-14): reemplazar las dos filas de «Imagen» por

```markdown
| Imagen | Única | **Devcontainer**, frontera A y **CI cuando el artefacto es uno** (§11.2.7) | E8-5 |
| | Por componente | **CI** cuando los componentes se publican por separado, con la compuerta completa corrida antes en la imagen única | E8-5 |
```

10. §11.4, fila ESC-01 (C1-06): reemplazar la celda de recomendación por `Frontera A en modo estricto; \`devEngines\` (o \`engine-strict=true\`); correr \`verificar.sh\` desde **Git Bash**, que usa el \`PATH\` de Windows, el mismo que la build de Visual Studio **[no verificado]** (requiere Windows). Por WSL la compuerta compara los archivos nativos con los runtimes de Linux: verifica las capas 1 y 3, no la 2 de Windows`.
11. §11.4, fila ESC-04: reemplazar `Imagen única construida desde los nativos, bases por digest` por `Imagen única construida desde los nativos con la receta de A.10, la misma que la CI (bases por digest en su Dockerfile)`. Fila ESC-05: reemplazar `Frontera B; imagen única o etapas por componente por digest; SBOM de locks y de artefacto; atestación firmada` por `Frontera B; imagen única si el artefacto es uno, etapas por componente si se publican por separado (§11.2.7); registro del entorno y SBOM de locks y de artefacto; procedencia firmada si un consumidor la verifica (§12, paso 8b)`.
12. §11.4, tabla de actores, fila ACT-OPS (C1-49): reemplazar `Mantiene el Dockerfile multi-runtime o las cuatro bases por digest;` por `Construye y mantiene el Dockerfile multi-runtime o las cuatro bases por digest, según la estrategia que decide ACT-ARQ;`.
13. §11.5, bloque `docker buildx build` (C1-15): reemplazar el bloque por

````markdown
```bash
# Una vez por máquina: un builder docker-container, que exporta procedencia y SBOM (§9.2.4).
docker buildx inspect n8-attest >/dev/null 2>&1 || docker buildx create --name n8-attest --driver docker-container
docker buildx build --builder n8-attest --target artefacto \
  --build-arg PY_IMAGE=python:3.12.15-slim@sha256:05cda9777409a9c3ffddd94a4c476b79f0769a0b4857f0c7ed9226b6800b0d6f \
  --provenance=mode=max --sbom=true \
  -f imagen/Dockerfile.por-componente --output type=local,dest=salida solucion
# salida/provenance.json : SLSA v1; materiales = SDK, Node, Python y uv por digest; builder.id vacío
# salida/sbom.spdx.json  : sólo lo que viaja (NuGet)
```

E8-6 agrega además `ARG BUILDKIT_SBOM_SCAN_STAGE=true` en las etapas de Python y Node para obtener un SBOM por etapa (§11.2.8). Este comando no pide `version=v1`: el default de la versión de BuildKit usada ya es v1 (§9.2.4).
````

14. §11.6, formato: quitar numeración (`**1. ¿` → `**¿`, …).
15. §11.6, P1 (C1-11): reemplazar `con cp1252 falla C# en Linux, falla Python y Node corrompe sin error (E8-1).` por `con cp1252 falla C# en Linux, falla Python y Node corrompe sin error los datos que lee (un identificador cp1252 en su propio código sí lo haría fallar, §4.2.4) (E8-1).`
16. §11.6, P2: reemplazar `*Aplica*: devcontainer y estación → imagen única; CI por etapas → por componente, con cuatro digests fijados.` por `*Aplica*: devcontainer y estación → imagen única; CI → la misma imagen única si el artefacto es uno, y por componente sólo si los componentes se publican por separado, con cuatro digests fijados y la compuerta completa corrida antes en la imagen única (§11.2.7).`
17. §11.6, P3: agregar ` *Aplica* a CTX-POLI en todos los escenarios; en ESC-01 la compuerta es lo único que verifica Node y Python.`
18. §11.6, P4 (C1-16): reemplazar la respuesta `Primero decidiendo el alcance: locks, artefacto, entorno. Para los locks, una herramienta multi-ecosistema o los exportadores nativos unidos; para el entorno, la procedencia de la plataforma, que nombra por digest las imágenes de los tres toolchains, firmada en la CI.` por `Primero decidiendo el alcance: locks, artefacto, entorno. Para los locks, una herramienta multi-ecosistema o los exportadores nativos unidos. Para el entorno, el registro del entorno de la CI y, si la build corre en contenedores, la procedencia de BuildKit, que nombra por digest las imágenes de los tres toolchains pero sale sin firma y sin \`builder.id\`. La procedencia que firma la plataforma nombra el commit, no el entorno: atar las dos cosas es un paso propio (§11.2.8). *Aplica* a la CI (ESC-05) en CTX-POLI.`
19. §11.6, P5: reemplazar `en ESC-01, fuera de MSBuild` por `en la estación Windows (ESC-01), fuera de MSBuild`; y `Los dos caminos tienen que dar lo mismo con la configuración de publicación.` por `Los dos caminos tienen que dar lo mismo, y eso se prueba en la CI (§11.2.5).`; agregar al final ` *Aplica* a CTX-POLI con estaciones Windows y CI.`
20. §11.6, P6: agregar ` *Aplica* a CTX-POLI y a todo repo con \`.esproj\`.`
21. §11.6, insertar al final:

```markdown
**Tu equipo copió A.10 para la imagen de CI y, por la tabla de §11.3, duda entre imagen única y por componente. El artefacto es una sola DLL. ¿Qué usás en la CI?**
La única. Con un solo artefacto, el job corre `build.sh`, el mismo comando que la estación y el devcontainer, y la compuerta completa corre en un lugar (§11.2.7). La variante por componente no corre la compuerta de texto y trae otro origen de Python (§11.2.6); conviene cuando los componentes se publican por separado. *Aplica* a la CI (ESC-05) en CTX-POLI.
```

22. §11.7: reemplazar `- elige su frontera de build por escenario, con modo estricto en ambas, y comprueba que las dos producen el mismo artefacto;` por `- elige su frontera de build por escenario, con modo estricto en ambas, y comprueba en la CI, con una prueba de regresión del \`.csproj\`, que las dos producen el mismo artefacto;`; reemplazar `- declara el alcance de cada SBOM y deja la procedencia firmada en la CI.` por `- declara el alcance de cada SBOM, graba el registro del entorno y, si un consumidor la verifica, deja en la CI una procedencia firmada que dice qué nombra y qué no.`; en señales pobres agregar al final, antes del punto, `; una compuerta que dice \`n/a\` para los proyectos de las subcarpetas`.
23. §11.8: reemplazar `Todas las del [Anexo A](#anexo-a-plantillas-comentadas), que forman juntas un repositorio políglota mínimo verificado por EA-1; la imagen multi-runtime en [A.10](#a10-dockerfile-de-la-imagen-multi-runtime).` por `Todas las del [Anexo A](#anexo-a-plantillas-comentadas), que forman juntas un repositorio políglota mínimo verificado por EA-1, incluida la imagen multi-runtime de [A.10](#a10-dockerfile-de-la-imagen-multi-runtime), que EA-1 construye, y el devcontainer de A.9, que usa su receta.`
24. Insertar entre §11.8 y el `---`:

```markdown
### 11.9 Práctica

1. Antes de mirar E8-1, predecí qué lectores fallan con «BOM para todo». *Respuesta esperada*: cinco —los dos shebangs, `json.load`, `tomllib`, `JSON.parse` y la comparación de `.nvmrc`—, ninguno de .NET (§11.2.1).
2. Copiá la compuerta de N7 (con `check_text_policy.py`) dentro de la solución de N8, corrélas a las dos y explicá cada diferencia. *Respuesta esperada*: la de N7 declara `n/a` el Python, el lock de npm y el de uv, porque los busca en la raíz; `verificar.sh` los encuentra porque tiene las rutas (§10.2.2).
```

**Evidencia**: E1 de `devEngines.runtime` sin `onFail` en npm 10.9.8 y 11.19.0/11.19.1 (Informe-adhoc-AH-001-01; pasa a E8-3 por P-22); `e6-sbom-unificado/experimento.sh` líneas 11, 32, 33–37 (builder `n8-attest`, `PY15` con su digest, `BUILDKIT_SBOM_SCAN_STAGE`); [B202]; ejecución de `Dockerfile.por-componente` sin `--build-arg` → `No interpreter found for Python 3.12.15` (Informe-desarrollador-04); E1 del arquitecto para los `n/a`.
**Verificación**: el bloque de §11.5, copiado y corrido desde `Examples/N8-integracion-poliglota/` en una máquina sin el builder, termina con rc=0 y su salida se versiona como `E8-6-comando-de-la-guia.txt`; E8-3 re-corrido con `devEngines` muestra `EBADDEVENGINES` con Node desalineado; `grep -c 'lo único que hace cumplir' GUIA` → 0; el diagrama de §11.2.9 renderiza.

### P-15 · §12 Hoja de ruta

- **Hallazgos**: C1-39 (L2168), C1-10 (paso 2), C1-37 (paso 3), C1-06 (paso 4), C1-03 (paso 6), C1-21 (paso 7), C1-18 (paso 8a/8b), C1-54 (paso 8), C1-40 / C1-Q01 (rótulo del hook en L2183), C1-47 (bloque YAML).
- **Capa**: guía. **Costo**: medio. **Reversible**: sí. **Derivados**: §0.2.

1. L2168: reemplazar `Los capítulos anteriores se pueden leer en cualquier orden; adoptarlos, no.` por `Los capítulos anteriores se pueden **consultar** en cualquier orden; para aprenderlos conviene el orden de §0.2, y para adoptarlos, el de esta tabla.`
2. Paso 2: reemplazar `elegir la variante de \`*.cs\` según el estado del repo.` por `elegir la convención de la familia .NET (\`*.cs\`, \`*.csproj\`) según el estado del repo: nuevo, heredado todavía en cp1252 o ya convertido con BOM (§5.2.3).`
3. Paso 3: reemplazar `\`.git-blame-ignore-revs\` después; fusión con merge commit.` por `\`.git-blame-ignore-revs\` después, con el SHA que quedó en \`main\`; un PR por commit o uno con merge commit.`
4. Paso 4: reemplazar `Poner la compuerta de texto en la CI y el hook versionado.` por `Poner la compuerta de texto en la CI y el hook versionado, con los prerrequisitos de cada estación declarados (A.11).`
5. Paso 6: reemplazar la fila por `| 6 | Congelar el grafo: lock en npm y uv; en .NET, lock en los ejecutables con \`disable\` (por defecto) o la política sin lock de §6.4, según el ADR del paso 5; CPM; registros en el repo; restauración estricta en la compuerta, activada en CI. | ACT-ARQ, ACT-OPS | \`NU1004\` / \`EUSAGE\` / «needs to be updated» ante deriva; sin lock, \`NU1603\` como error | §6.4, §7 |`.
6. Paso 7: reemplazar la fila por `| 7 | Construir la imagen de CI **desde** los archivos de los pasos 5–6, con sus bases por digest y un bot que proponga los digests nuevos por PR; el devcontainer, si se ofrece, con la misma receta o con etiqueta fija de SDK y SO verificada por \`global.json\`. | ACT-OPS | La compuerta pasa en la imagen y falla si se desalinea | §8 |`.
7. Paso 8: reemplazar la fila por las dos:

```markdown
| 8a | En la CI, para todo equipo: `ContinuousIntegrationBuild`, `SOURCE_DATE_EPOCH`, registro del entorno (SDK, compilador y runtimes efectivos, digest de la imagen, commit y árbol limpio) y SBOM con alcance declarado. | ACT-OPS | Artefacto, registro del entorno y SBOM publicados juntos | §9 |
| 8b | Si hay un consumidor externo que la verifique, un requisito contractual o un repositorio público: procedencia firmada por la plataforma si el plan lo permite, o con el nivel declarado honestamente. | ACT-OPS | Procedencia verificable con su par firmante/`builder.id` | §9.2.4 |
```

8. L2183: reemplazar `Los pasos 1 a 4 resuelven la primera pregunta del caso; 5 a 7, la segunda; 8, la tercera;` por `Los pasos 1 a 4 resuelven la primera pregunta del caso; 5 a 7, la segunda; 8a, la tercera; 8b, la misma pregunta cuando quien la hace es un tercero;`; y `restaura con NuGet y ejecuta el hook de git;` por `restaura con NuGet y, si su integración de git respeta \`core.hooksPath\`, ejecuta el hook **[no verificado]** (requiere Windows);`.
9. Insertar al final de §12, antes del `---`:

````markdown
```yaml
# La hoja de ruta como contrato, para agentes y revisores.
entradas:
  repositorio: el del caso (heredado; CTX-NET o CTX-POLI)
  plataforma: la CI disponible y su plan (protección de rama, atestaciones)
salidas:
  - ".editorconfig, .gitattributes y .git-blame-ignore-revs (pasos 1-3)"
  - "tools/ci/ con la compuerta y .githooks/pre-commit (paso 4)"
  - "global.json, devEngines, .python-version + required-version y el ADR de rollForward (paso 5)"
  - "locks y registros por ecosistema (paso 6)"
  - "imagen de CI con bases por digest y configuración del bot (paso 7)"
  - "registro del entorno y SBOM junto al artefacto (8a); procedencia si corresponde (8b)"
validaciones:
  - "paso 3: tools/verificar-commit-mecanico.sh <sha> CP1252 -> 0 con cambio de contenido"
  - "paso 4: un .cs en cp1252 en un PR -> compuerta en rojo"
  - "paso 5: un SDK distinto del de global.json -> A compatible .NET SDK was not found"
  - "paso 6: manifiesto cambiado sin regenerar el lock -> NU1004 / EUSAGE / needs to be updated"
  - "paso 7: imagen desalineada con los archivos nativos -> compuerta en rojo"
```
````

**Verificación**: `grep -c 'se pueden leer en cualquier orden' GUIA` → 0; la tabla de §12 tiene las filas 8a y 8b; el YAML es válido.

### P-16 · Anexo A

- **Hallazgos**: C1-07 (intro, A.11), C1-10 (A.1, EA-1), C1-36 (A.2), C1-03 / C1-01 (A.3), C1-26 / C1-53 / C1-02 (A.4), C1-21 / C1-13 (A.9, A.10, A.12), C1-06 / C1-08 (A.11), C1-19 (A.12, A.14), C1-20 (A.13), C1-37 (A.15).
- **Capa**: guía **y** laboratorio (`Examples/A-plantillas/repo/`, que tiene que seguir byte a byte igual a los bloques; P-22). **Costo**: alto. **Reversible**: sí. **Derivados**: EA-1, B.1–B.3.

1. Intro (L2189): reemplazar `y **EA-1** (\`Examples/A-plantillas/verificar.sh\`) las verifica en conjunto: resolución de \`.editorconfig\` y \`.gitattributes\`, compuerta de texto sobre las propias plantillas (21 archivos, 0 violaciones), condición de CI de \`Directory.Build.props\`, \`devEngines\`, uv, y sintaxis de JSONC, YAML y del esquema de \`dependabot.yml\`.` por `y **EA-1** (\`Examples/A-plantillas/verificar.sh\`) las verifica en conjunto: resolución de \`.editorconfig\` y \`.gitattributes\`, compuerta de texto sobre las propias plantillas, un \`dotnet new console\` creado dentro del repo, condición de CI de \`Directory.Build.props\`, lock sólo en los ejecutables, la imagen de A.10 construida con la plantilla \`web/\` corriendo adentro, \`devEngines\`, uv, y sintaxis de JSONC, YAML y del esquema de \`dependabot.yml\`. El esqueleto de compuerta de A.11 **falla a propósito** hasta que se lo reemplaza: copiar las plantillas no instala una red que no detecta nada.`
2. A.1, preguntas: reemplazar `¿El repo es nuevo o heredado ya convertido con BOM (variante B para \`*.cs\`)?` por `¿El repo es nuevo, heredado todavía en cp1252 o heredado ya convertido con BOM (variante B para \`*.cs\`)? ¿Se acepta normalizar lo que crea \`dotnet new console\` (\`Program.cs\` y \`.csproj\` con BOM) antes del primer commit?`
3. A.1, bloque: reemplazar las líneas `# Variante B (código heredado YA convertido a UTF-8 con BOM): descomentar.` por

```text
# Variante B (heredado YA convertido a UTF-8 con BOM, o elegida antes de migrar):
# descomentar. Con la variante A, lo que crea dotnet new console (Program.cs y el
# .csproj, con BOM) se normaliza antes del primer commit.
```

4. A.1, párrafo «Verificado en EA-1»: agregar al final `EA-1 paso 1b: un \`dotnet new console\` dentro del repo deja dos violaciones con la variante A (\`Program.cs\` y el \`.csproj\` con BOM) y ninguna después de normalizarlos.`
5. A.2, preguntas: reemplazar `¿el disco tiene que tener LF en todas las máquinas (sí, si se construye en Windows y Linux)?` por `¿hay literales multilínea o datos cuyo fin de línea importe en las pruebas de la estación (entonces \`eol=lf\`; si no, \`* text=auto\` también vale, §5.2.2)?`
6. A.3: preguntas — reemplazar `¿hay lock files de NuGet (entonces \`disable\`)?` por `¿hay lock files de NuGet (entonces \`disable\`)? ¿Quién instala el SDK exacto en cada estación Windows?`; y agregar tras `Variante tolerante, sin lock files: \`"version": "8.0.400", "rollForward": "latestPatch"\` (el parche más alto de la banda 4xx).` la oración: ` Costo de \`disable\`: toda estación, la imagen del devcontainer y la de CI necesitan exactamente 8.0.425, y la que tenga otro parche no compila (§6.4). La variante tolerante va con la política sin lock: \`NU1603\` como error y el SDK registrado en la CI.`
7. A.4: reemplazar el bloque XML por

```xml
<Project>
  <!-- Anexo A.4. Una sola definición de "estoy en CI" para todo el repo.
       CI=true lo definen GitHub Actions y GitLab; TF_BUILD=True, Azure Pipelines.
       Las comparaciones de MSBuild no distinguen mayúsculas. -->
  <PropertyGroup Condition="'$(CI)' == 'true' Or '$(TF_BUILD)' == 'true' Or '$(GITHUB_ACTIONS)' == 'true'">
    <!-- Rutas normalizadas (/_/) y build totalmente determinista. -->
    <ContinuousIntegrationBuild>true</ContinuousIntegrationBuild>
    <!-- Restauración estricta: si el lock no coincide, NU1004 en vez de reescribirlo. -->
    <RestoreLockedMode>true</RestoreLockedMode>
  </PropertyGroup>

  <PropertyGroup>
    <!-- Política SIN lock (guía, 6.4): descomentar. Una versión inexistente que NuGet
         aproxima corta el restore. Con lock, el lock desarma este aviso (E4-2). -->
    <!-- <WarningsAsErrors>$(WarningsAsErrors);NU1603</WarningsAsErrors> -->
    <!-- Capa 2: el TFM fija la versión de C#. Sólo si hace falta otra, y nunca "latest":
    <LangVersion>12.0</LangVersion> -->
    <!-- Capa 6: URL del repo y commit en el .nuspec; símbolos aparte. -->
    <PublishRepositoryUrl>true</PublishRepositoryUrl>
    <IncludeSymbols>true</IncludeSymbols>
    <SymbolPackageFormat>snupkg</SymbolPackageFormat>
    <!-- NO configurar PathMap a mano: no normaliza el mapa de SourceLink. -->
  </PropertyGroup>

  <ItemGroup>
    <!-- Lo que el SDK no graba: con qué SDK y en qué imagen (la pasa la CI). -->
    <AssemblyMetadata Include="SdkVersion" Value="$(NETCoreSdkVersion)" />
    <AssemblyMetadata Include="ImagenDigest" Value="$(ImagenDigest)" Condition="'$(ImagenDigest)' != ''" />
  </ItemGroup>
</Project>
```

   Y agregar tras el bloque, antes del párrafo «Verificado en EA-1»:

````markdown
`Directory.Build.targets` (raíz), para que el lock quede sólo en los ejecutables:

```xml
<Project>
  <!-- Anexo A.4b. El lock que gobierna es el del proyecto en la punta de la cadena.
       Va en .targets y no en .props: cuando se evalúa Directory.Build.props,
       OutputType todavía no está definido y la condición no se cumple nunca. -->
  <PropertyGroup Condition="'$(OutputType)' == 'Exe'">
    <RestorePackagesWithLockFile>true</RestorePackagesWithLockFile>
  </PropertyGroup>
</Project>
```
````

   Reemplazar en el párrafo «Verificado en EA-1» `\`LangVersion\` puede omitirse (lo fija el TFM) pero nunca valer \`latest\` [B57].` por `\`LangVersion\` se omite: lo fija el TFM, y un valor fijo para todo el repo deja a un proyecto \`net10.0\` en C# 12 sin aviso; si hace falta, nunca \`latest\` [B57]. EA-1 paso 2b: con \`Directory.Build.targets\`, \`packages.lock.json\` aparece en el ejecutable y no en la biblioteca, y en modo CI el restore pasa y falla con \`NU1004\` ante un cambio sin regenerar.`
8. A.9: reemplazar el bloque `jsonc` y el párrafo siguiente por

````markdown
```jsonc
// Anexo A.9. El devcontainer se construye con la MISMA receta que la imagen de CI (A.10):
// sus bases van por digest y las actualiza el bot de la CI (A.13, ecosistema docker).
// Variante sólo .NET sin receta propia (§8.5): "image": "mcr.microsoft.com/dotnet/sdk:8.0.425-bookworm-slim".
{
  "name": "solucion",
  "build": {
    "dockerfile": "../imagen/Dockerfile",
    "context": "../imagen",
    // Igual a tools/gen/.python-version: la compuerta compara lo instalado con el archivo.
    "args": { "PYTHON_VERSION": "3.12.15" }
  },
  // Hook versionado activado una vez por clon.
  "postCreateCommand": "git config core.hooksPath .githooks && dotnet --version && node --version && uv --version"
}
```

Con `build.dockerfile` no hay *features* ni `devcontainer-lock.json`: lo que se congela es la receta, y sus bases van por digest. Fuentes: [B119], [B136].
````

   y las preguntas de A.9 por `Preguntas que guían los campos: ¿la imagen de desarrollo comparte la receta de la CI (solución políglota) o basta una etiqueta fija de SDK y SO (sólo .NET)? ¿Hay un bot que actualice cada digest en un repo privado? ¿El host es Linux (entonces \`remoteUser\` + \`updateRemoteUserUID\` [B119])?`
9. A.10, bloque: reemplazar `# Imagen de desarrollo y CI con los TRES runtimes (variante "imagen única" de N8).` por `# Imagen de desarrollo y CI con los TRES runtimes (plantilla del Anexo A; la de N8 difiere sólo en NODE_IMAGE).` y `ARG NODE_IMAGE=node:22-bookworm-slim@sha256:d649c27dae7ba0137b3cef5dd75baa422c08dc3d9e3fc0c23dfb172dc3cc6436` por `ARG NODE_IMAGE=node:24-bookworm-slim@sha256:d6aa754f16b3197301076f047b5def2f02ea1dbbc2ca920407d46d7ec7f87b20`; y `# Base: el SDK de .NET (Debian 12, la misma familia que node:22-bookworm-slim,` por `# Base: el SDK de .NET (Debian 12, la misma familia que node:24-bookworm-slim,`. Párrafo siguiente: reemplazar `Archivo ejecutado en E8-3, E8-5 y E8-6: \`Examples/N8-integracion-poliglota/imagen/Dockerfile\`.` por `La plantilla vive en \`Examples/A-plantillas/repo/imagen/Dockerfile\` y EA-1 la construye y corre la plantilla \`web/\` adentro (Node 24.21.0, npm 11.19.0, glibc 2.36 en las dos bases). La de \`Examples/N8-integracion-poliglota/imagen/Dockerfile\`, usada en E8-3, E8-5 y E8-6, difiere sólo en \`NODE_IMAGE\`, porque N8 fija Node 22.23.2 en su \`.nvmrc\`.`
10. A.11, esqueleto: reemplazar el segundo bloque `sh` por

```sh
#!/bin/sh
# Anexo A.11 (esqueleto). FALLA A PROPÓSITO hasta que se lo reemplaza por la compuerta completa:
# Examples/N7-compuertas-y-gobierno/compuerta/compuerta.sh (un proyecto por ecosistema en la raíz)
# o Examples/N8-integracion-poliglota/solucion/verificar.sh (proyectos en subcarpetas, guía 10.2.2).
# Alcance: --staged (hook), --base <rev> (PR), sin argumentos (todo).
echo "compuerta: esqueleto sin reemplazar; copiá la compuerta completa (Anexo A.11)" >&2
exit 1
```

    y reemplazar el párrafo `Activación, una vez por clon: … la variante políglota, \`Examples/N8-integracion-poliglota/solucion/verificar.sh\`.` por

```markdown
**Qué se copia y adónde.** A `tools/ci/`: `compuerta.sh` de `Examples/N7-compuertas-y-gobierno/compuerta/` y `check_text_policy.py` de `Examples/N2-politica-de-texto-y-remediacion/tools/`; o, si los proyectos viven en subcarpetas, `verificar.sh` de N8 con su inventario de rutas (§10.2.2). A `.githooks/`: el hook de arriba. Activación, una vez por clon: `git config core.hooksPath .githooks` [B37].

**Prerrequisitos de cada estación**, para que el hook no dé un falso rojo: `bash` (en Windows, el de Git for Windows); `python3` con el paquete `EditorConfig==0.17.1`; y, para los pasos de toolchain y grafo, las herramientas que el repo declara (`dotnet`, `node`/`npm`, `uv`). En Windows se corre desde Git Bash, en la raíz del clon: `bash tools/ci/compuerta.sh --staged` **[no verificado]** (requiere Windows). La alternativa sin Python para el paso de texto es editorconfig-checker (§5.2.5).
```

11. A.12: preguntas — reemplazar `¿la imagen del job es la misma receta que el devcontainer, por digest?` por `¿la imagen del job sale de la misma receta que el devcontainer (A.10), publicada y nombrada por digest? ¿La revisión de dueños es obligatoria sobre \`.github/\` y \`tools/ci/\` (§10.2.7)?`; bloque — reemplazar `    # Misma receta que el devcontainer, por digest (completar).` por `    # Imagen construida desde imagen/Dockerfile (A.10), la misma receta que el devcontainer (A.9),\n    # publicada en el registro del equipo y nombrada por digest (completar).`
12. A.13: preguntas — agregar `¿Qué Dockerfile tiene bases por digest (ecosistema \`docker\`)?`; bloque — insertar antes de `  - package-ecosystem: "github-actions"`:

```yaml
  - package-ecosystem: "docker"
    directory: "/imagen"
    schedule:
      interval: "monthly"
```

    párrafo siguiente — reemplazar `Para imágenes por digest, Renovate documenta \`pinDigests\` [B108]; que Dependabot \`docker\` actualice un \`FROM …@sha256\` no está verificado.` por `Para las bases por digest de \`imagen/Dockerfile\` (A.10), el ecosistema \`docker\`: Docker documenta que Dependabot actualiza etiqueta y digest [B113]; la página de GitHub no menciona digests [B107] y el laboratorio no lo observó **[no verificado]** (requiere la plataforma). Renovate documenta \`pinDigests\` [B108]. \`devcontainers\` no se incluye: no está soportado en repositorios privados [B107], y el devcontainer de A.9 hereda las bases de A.10.`
13. A.14: preguntas — reemplazar `¿La aprobación del dueño es obligatoria en el plan del equipo [B177][B185]?` por `¿La aprobación del dueño es obligatoria en el plan del equipo (en GitHub, para una organización privada, desde Team; en GitLab, Premium) [B176][B177][B185]?`
14. A.15, bloque: reemplazar `# (merge commit: un squash o un rebase cambiarían el SHA).` por `# (con squash, un PR por commit: el SHA es el del squash ya en main; guía 5.2.6).`

**Evidencia**: `evidencia-auditor/lock-solo-ejecutables/salida.txt` (SDK 8.0.425: condición en `.props` → ningún lock; en `.targets` → `App` sí, `Lib` no; modo CI rc=0; cambio sin regenerar → `error NU1004`); `evidencia-auditor/a10-node24/salida.txt` (A.10 con Node 24 construye; v24.21.0, npm 11.19.0; glibc 2.36 en `node:24-bookworm-slim` y en `sdk:8.0@sha256:78235e09…`; `web/` pasa `devEngines`); [B57] (Informe-senior-dotnet-06); E2-6 para `dotnet new console`.
**Verificación**: `diff` byte a byte entre cada bloque del Anexo A y su archivo en `Examples/A-plantillas/repo/` (incluidos `Directory.Build.targets` e `imagen/Dockerfile`) sin diferencias; EA-1 con rc=0 y los pasos 1b, 2b y el de A.10; el hook de `A-plantillas` copiado y activado rechaza un `.cs` en cp1252 (exit ≠ 0) mientras el esqueleto no se reemplaza; el esquema de `dependabot.yml` valida con el ecosistema `docker`.

### P-17 · Anexo B

- **Hallazgos**: C1-01, C1-03 (B.1, B.2), C1-06 (B.1), C1-09 (B.1), C1-26 (B.2), C1-21, C1-18 (B.3).
- **Capa**: guía. **Costo**: bajo. **Reversible**: sí.

1. B.1: reemplazar `- [ ] Activé el hook una vez en este clon: \`git config core.hooksPath .githooks\`. (§10.2.3)` por `- [ ] Tengo los prerrequisitos del hook (\`bash\`, \`python3\` con \`EditorConfig==0.17.1\`, y las herramientas que el repo declara) y lo activé una vez en este clon: \`git config core.hooksPath .githooks\`. (A.11, §10.4)`
2. B.1: reemplazar `- [ ] Tengo instalado el SDK exacto de \`global.json\`; si Visual Studio trae otro, instalé el independiente. (§6.2.2)` por `- [ ] Si \`global.json\` usa \`rollForward: disable\`, tengo instalado ese SDK exacto (si Visual Studio trae otro, el independiente); si no, un SDK de la banda. (§6.4)`
3. B.1: reemplazar `- [ ] Corro la compuerta antes del push; si da rojo` por `- [ ] Corro la compuerta antes del push (en Windows, desde Git Bash); si da rojo`.
4. B.1: reemplazar `- [ ] Después de una migración de codificación, refresqué mi working tree una vez. (§5.2.6)` por `- [ ] Después de una migración de codificación, con el árbol limpio (commit o \`git stash\`) y la migración ya traída, refresqué mi working tree una vez. (§5.2.6, paso 5)`
5. B.2: reemplazar `- [ ] La elección de \`rollForward\` está escrita en un ADR, coherente con el uso de lock files. (§6.4)` por `- [ ] La política de §6.4 (con lock y \`disable\`, o sin lock con \`latestPatch\` y \`NU1603\` como error) está escrita en un ADR con su costo. (§6.4)`; y `- [ ] Cada ejecutable tiene lock; las bibliotecas que se publican, no. CPM centraliza las versiones directas. (§7.2.1)` por `- [ ] Con la política con lock, cada ejecutable tiene su lock (\`Directory.Build.targets\`, A.4); los proyectos comunes no lo necesitan. CPM centraliza las versiones directas. (§7.2.1)`
6. B.3: reemplazar `- [ ] Toda imagen (CI, devcontainer, ejecución) va por digest, y un bot o un trabajo propone el digest nuevo por PR con cadencia al menos mensual. (§8.2.2)` por `- [ ] Toda imagen que construye artefactos publicados va por digest, y un bot o un trabajo propone el digest nuevo por PR con cadencia al menos mensual; el devcontainer usa la misma receta o una etiqueta fija verificada por \`global.json\`. (§8.2.2)`; y `- [ ] Se generan SBOM y procedencia junto al artefacto; el nivel SLSA declarado coincide con lo que la plataforma firma. (§9.2.4)` por `- [ ] Se graban el registro del entorno y el SBOM junto al artefacto; si un consumidor la verifica, la procedencia lleva el nivel SLSA que la plataforma realmente da. (§9.2.4, §12 pasos 8a y 8b)`

**Verificación**: cada ítem de B.1–B.3 remite a una sección cuyo texto, tras P-06…P-15, dice lo mismo.

### P-18 · Anexo C Glosario

- **Hallazgos**: C1-25, C1-54.
- **Capa**: guía. **Costo**: bajo. **Reversible**: sí.

1. Reemplazar `| EOL | Final de línea: LF o CRLF. | §4.1 |` por `| Fin de línea (EOL) | LF o CRLF; en plural, «finales de línea». | §4.1 |` y, en §4.1, `| **Final de línea** (EOL) |` por `| **Fin de línea** (EOL) |`.
2. Reemplazar `| Índice / working tree | Lo que git guarda / lo que está en disco. | §5.1 |` por `| Índice (git) / working tree | Lo que git guarda y compara / lo que está en disco. No confundir con el índice de paquetes. | §5.1 |`.
3. Reemplazar `| Pieza (artefacto) | Lo que sale de la build, identificado por digest. | §9.1 |` por `| Artefacto | Lo que sale de la build y se distribuye, identificado por digest. El caso lo llama «pieza». | §9.1 |`; en `Procedencia` y `SBOM`, `una pieza` → `un artefacto`.
4. Insertar en orden alfabético estas filas:

```markdown
| Aislar de `blame` | Listar el SHA de un commit mecánico en `.git-blame-ignore-revs` para que `git blame` atribuya las líneas a sus autores. | §5.1 |
| Archivo nativo de versión | El que lee la herramienta del propio ecosistema (`global.json`, `.nvmrc`/`engines`, `.python-version`/`requires-python`), frente al de un gestor de terceros. | §11.1 |
| BuildKit | Motor de build de Docker; genera SBOM y procedencia SLSA de lo que construye. | §9.2.4 |
| Corepack | Herramienta de Node que hace cumplir `packageManager`; experimental y fuera de la distribución de Node desde la 25. | §6.2.3 |
| CycloneDX | Formato de SBOM normalizado como ECMA-424. | §9.2.3 |
| `devcontainer-lock.json` | Lock de las *features* de un devcontainer; no registra la imagen base. | §8.1 |
| Dueño del código | Revisor que la plataforma pide cuando un PR toca ciertas rutas (`CODEOWNERS`). | §10.1 |
| Grafo resuelto | Directas y transitivas con una versión concreta cada una, en un momento dado. | §7.1 |
| Imagen de desarrollo / de CI / de ejecución | La del desarrollador, la que compila en CI y la que corre la aplicación. | §8.1 |
| Imagen multi-runtime / por componente | Una imagen con los tres toolchains, o una oficial por ecosistema con las salidas pasadas entre etapas. | §11.1 |
| Índice de paquetes | Registro del que se descargan paquetes (en Python, *index*); sinónimo de registro. | §7.1 |
| in-toto | Formato de atestación (`subject`, `predicateType`, `predicate`) que usa la procedencia SLSA. | §9.1 |
| Integridad | Comprobar que los bytes descargados son los que registró el lock. | §7.1 |
| Metadatos embebidos | Datos de origen grabados dentro del artefacto (SHA del commit, URL del repo). | §9.1 |
| Monorepo | Varios proyectos versionados juntos; no implica una herramienta. | §11.1 |
| Orquestador | Quien decide el orden de los pasos de la build y los ejecuta. | §11.1 |
| Política de texto | Para cada tipo de archivo: codificación, BOM y fin de línea, declarados y verificados. | §5.1 |
| Resolución libre | Instalación que, si el manifiesto cambió, vuelve a resolver y reescribe el lock. | §7.1 |
| RID | *Runtime identifier*: plataforma de destino de .NET (`win-x64`, `linux-x64`); forma parte del lock de NuGet. | §7.2.1 |
| Runtime | Lo que ejecuta el programa; en .NET se elige al ejecutar, no lo fija el SDK. | §6.1 |
| SLSA | *Supply-chain Levels for Software Artifacts*: niveles de garantía de la build y su procedencia. | §9.2.4 |
| Source Link | Mapa en el PDB de cada archivo fuente a su URL en el repositorio y el commit. | §9.2.1 |
| SPDX | Formato de SBOM; la versión 2.2.1 está normalizada como ISO/IEC 5962:2021. | §9.2.3 |
```

5. Primera aparición en prosa (C1-25): en §1, L26 no es prosa (cabecera); en §3.1, fila **Procedencia**, reemplazar `en SLSA, desde el nivel L2` por `en SLSA (*Supply-chain Levels for Software Artifacts*), desde el nivel L2`; en §3.2, primera aparición de SBOM en prosa (`un SBOM puede describir`) → `un SBOM (*software bill of materials*, inventario de componentes) puede describir`. CPM y RID: P-10.

**Verificación**: script que cruza las filas en negrita de las tablas de definición (§3.1, §4.1, §5.1, §6.1, §7.1, §8.1, §9.1, §10.1, §11.1) con el Anexo C → 0 faltantes; `grep -c 'Supply-chain Levels' GUIA` ≥ 1.

### P-19 · Anexo D Bibliografía

- **Hallazgos**: C1-41 (B14, B49), C1-34 (B155), C1-35 (B15); fuentes nuevas de los parches.
- **Capa**: guía. **Costo**: bajo. **Reversible**: sí.

1. Intro (L2755): reemplazar `Todas las fuentes se consultaron el **2026-10-07**.` por `Las fuentes B01–B193 se consultaron el **2026-10-07**; B194–B204, el **2026-10-09**.`
2. B14: reemplazar la URL por `https://github.com/dotnet/roslyn/blob/9c298328ef910c8c592a6ac73c4a03af64a266b3/src/Compilers/Core/Portable/EncodedStringText.cs · https://github.com/dotnet/roslyn/blob/9c298328ef910c8c592a6ac73c4a03af64a266b3/src/Compilers/Core/Portable/CommandLine/CommandLineParser.cs` y la descripción por `dotnet/roslyn — \`EncodedStringText.cs\` y \`CommandLineParser.cs\` (commit \`9c298328ef91\`, 2026-04-24; histórico \`5a5e8027cb\`)`.
3. B15: reemplazar la descripción por `dotnet/roslyn — PR #83320, «Fix regression in CreateFallbackEncoding» (arreglo de #82159; prueba \`CreateFallbackEncoding_IsNotUtf8OnWindows\`)`.
4. B49: reemplazar la descripción por `microsoft/vscode — \`files.contribution.ts\` y \`encoding.ts\` (commit \`521857c60832\`, último de \`main\` al 2026-10-07)` y la URL por `https://github.com/microsoft/vscode/blob/521857c60832c41416f78e035c8977ad14d0ba9b/src/vs/workbench/contrib/files/browser/files.contribution.ts · https://github.com/microsoft/vscode/blob/521857c60832c41416f78e035c8977ad14d0ba9b/src/vs/workbench/services/textfile/common/encoding.ts`.
5. B155: reemplazar la descripción por `SPDX — Specification 3.0.1; especificaciones publicadas` (el estatus ISO pasa a B194).
6. Agregar al final de la tabla:

```markdown
| B194 | IEC Webstore — ISO/IEC 5962:2021, «Information technology - SPDX® Specification V2.2.1» (2021-08-24) | https://webstore.iec.ch/publication/70993 | 2026-10-09 |
| B195 | Microsoft Learn — NuGet Warning NU1603 | https://learn.microsoft.com/en-us/nuget/reference/errors-and-warnings/nu1603 | 2026-10-09 |
| B196 | pnpm — Settings: CLI (`pmOnFail`, desde v11.0.0) | https://pnpm.io/settings/cli | 2026-10-09 |
| B197 | Sigstore — Signing overview (firma sin clave, Rekor, instancia propia) | https://docs.sigstore.dev/cosign/signing/overview/ | 2026-10-09 |
| B198 | npm Docs v11 — scope (un *scope*, un registro) | https://docs.npmjs.com/cli/v11/using-npm/scope | 2026-10-09 |
| B199 | GitLab Docs — Auto-merge («Pipelines must succeed»; Free, Premium, Ultimate) | https://docs.gitlab.com/user/project/merge_requests/auto_merge/ | 2026-10-09 |
| B200 | GitHub Docs — Events that trigger workflows (`pull_request`, `pull_request_target`) | https://docs.github.com/en/actions/reference/workflows-and-actions/events-that-trigger-workflows | 2026-10-09 |
| B201 | editorconfig-checker — README (v4.0.2) | https://github.com/editorconfig-checker/editorconfig-checker | 2026-10-09 |
| B202 | slsa-framework/github-actions-buildtypes — `workflow/v1` (`resolvedDependencies`) | https://github.com/slsa-framework/github-actions-buildtypes/blob/main/workflow/v1/README.md | 2026-10-09 |
| B203 | Microsoft Learn — .NET Runtime Identifier (RID) catalog | https://learn.microsoft.com/en-us/dotnet/core/rid-catalog | 2026-10-09 |
| B204 | git — git-reset (`--hard`) | https://git-scm.com/docs/git-reset | 2026-10-09 |
```

**Verificación**: todas las URL nuevas y los permalinks de B14 y B49 responden 200 (`curl -s -o /dev/null -w '%{http_code}'`; comprobado por el auditor el 2026-10-09 para los cuatro permalinks); 204 `[Bnn]` definidas y 204 citadas, ninguna colgante (script de edición del ciclo).

### P-20 · Anexo E Laboratorio

- **Hallazgos**: C1-55 (numeración, rutas, N3), más los experimentos nuevos o ampliados de P-07…P-16.
- **Capa**: guía y laboratorio. **Costo**: bajo en la guía. **Reversible**: sí.

1. Intro: reemplazar `Fecha de todas las corridas: 2026-10-07, Linux x86_64 con Docker.` por `Fecha de las corridas: 2026-10-07 (las ampliaciones de la revisión, 2026-10-09), Linux x86_64 con Docker. Los IDs siguen el esquema \`E<n>-<m>\` de la guía; donde una carpeta o un archivo usan otra numeración (\`E1-N1-01\` en los scripts de N1; carpetas \`e1-…\` a \`e6-…\` de N2 que no coinciden con el ID; \`V7-01\`, la medición de tiempo de E7-5b), la fila lo dice. Las rutas son relativas a esta guía.`
2. Filas E3-1…E3-6, columna «Salida»: reemplazar `\`README.md\` de la carpeta` y `ídem` por `\`Examples/N3-fijacion-del-toolchain/salidas/E3-<m>.txt\` (también pegada en \`N3-…/README.md\`)`.
3. Filas ampliadas: E1-04 `Razor con cp1252 → U+FFFD en literales; \`RZ1005\`/\`CS1056\` en identificadores`; E1-05 agregar `; identificador cp1252 → \`SyntaxError\``; E1-13 agregar `; un cp1252 que forma UTF-8 válido sale como UTF-8`; E2-2 agregar `; fusión por *squash* con un PR por commit`; E3-2 agregar `; inspección de los *targets* del SDK 8 y 10 (compilador en Visual Studio)`; E3-3 agregar `; pnpm ≥ 11 y \`pmOnFail\` sin Corepack`; E4-2 agregar `; versión inexistente con y sin lock y con \`NU1603\` como error, SDK 8 y 10`; E4-4 `npm, pnpm y Yarn (multiplataforma)`; E8-3 agregar `; \`devEngines\` sin \`onFail\``; E8-6 agregar `; el comando de §11.5 tal como está escrito`; EA-1 agregar `; \`dotnet new console\`, lock sólo en ejecutables, imagen A.10`.
4. Filas nuevas, tras E2-6:

```markdown
| E2-7 | editorconfig-checker contra el `.editorconfig` de §5.5 | `Examples/N2-politica-de-texto-y-remediacion/e7-editorconfig-checker/` | `…/salidas/e7-editorconfig-checker.txt` |
| E2-8 | `.gitattributes`, `charset`, locks y `rollForward` en seis repos `dotnet/*` (2026-10-07) | `…/N2-…/e8-repos-de-referencia/` | `e8-repos-de-referencia.txt` |
```

**Verificación**: cada ID `E…` del cuerpo tiene fila; cada ruta de la tabla existe (`test -e`); 73 filas de experimentos.

### P-21 · Anexo F Límites

- **Hallazgos**: C1-43 (decisión pendiente), C1-46 (trazas), C1-20, C1-35, C1-Q09 cerrada.
- **Capa**: guía. **Costo**: bajo. **Reversible**: sí.

1. Insertar al principio del Anexo F, tras la primera oración:

```markdown
**Qué pedido cubre cada sección.** Los identificadores del campo `traces` del encabezado:

| ID | Pedido | Sección |
|---|---|---|
| P-01 | Código en cp1252 que en Linux falla al compilar y corrompe acentos; en Windows funciona | §1, §4.2.1–§4.2.2 |
| P-02 | Desarrollo simultáneo con Visual Studio en Windows, Linux y devcontainers | §2.1, §8.2.4 |
| P-03 | Criterio de codificación unificado, sin commits de BOM | §5, §10.2.5, A.1, A.2 |
| P-04 | Congelar paquetes NuGet | §7 |
| P-05 | Congelar versiones de compilador y SDK | §6 |
| P-06 | ¿Se puede con contenedores? | §3.5, §8 |
| P-07 | Integrarlo con herramientas en Windows y Linux | §8.2.4, §10, §12 |
| P-08 | Saber con qué entorno se ensambló cada artefacto | §3.2 (capa 6), §9 |
| P-09 | Estrategias de la industria para .NET, Node.js y Python | «Qué propone la industria» de §4–§10 |
| P-10 | Qué pasa al integrarlos en una única solución | §11 |
| R-01 | Secciones jerárquicas, definiciones, ejemplos, diagramas | índice; n.1 de cada capítulo; diagramas |
| R-02 | Autocontenida | toda la guía; Anexo C |
| R-03 | Snippets y preguntas guía que forman criterio | n.5, n.6 y n.9 de §3–§11; Anexo A |
| R-06, R-07 | Sin inventar; toda afirmación con evidencia | marcas de §0.3; Anexos D, E y F |
| R-PROF | Marco de referencia, mapa conceptual, estructura común, anexos | §2, §3.6, §4–§11, Anexos A–C |
| R-PRIV | Sin identificadores del caso privado | §1 (ejemplo sintético) |
```

2. «No verificado», primer ítem: reemplazar `- La rama Windows del mecanismo de Roslyn (ACP 1252 y ACP UTF-8), §4.2.1.` por `- La rama Windows del mecanismo de Roslyn (ACP 1252), y la estación con ACP UTF-8, que queda como pregunta abierta porque la prueba de [B15] contradice la deducción de [B19] (§4.2.1).`; y el ítem de Dependabot: reemplazar `si Dependabot \`docker\` actualiza un \`FROM …@sha256\`;` por `si Dependabot \`docker\` actualiza un \`FROM …@sha256\` (Docker lo documenta [B113]; GitHub no lo menciona [B107]);`. Agregar ítems: `- Qué compilador usa realmente Visual Studio con el SDK 8 y el 10 (§6.2.2; sólo se inspeccionaron los *targets*).` y `- Los prerrequisitos y comandos de la compuerta y la migración desde Git Bash en Windows (§5.2.6, §10.4, A.11).` y `- La firma sin clave con cosign y cómo completar \`builder.id\` en BuildKit (§9.2.4).`
3. «Interpretaciones declaradas»: reemplazar `- Que el ciclo típico de un «commit de BOM» sea el descrito en §4.2.6 (inferido de los defaults documentados).` por `- Que el ciclo típico de un «commit de BOM» sea el descrito en §4.2.6, marcado **[interpretación]** (inferido de los defaults documentados).`
4. Reemplazar el párrafo final `**Pendiente de decisión de la mesa.** Si la guía recomienda …` por `**Formato de SBOM.** La guía recomienda un solo formato por solución, el que pida el consumidor, y CycloneDX cuando nadie pide otro (§9.2.3).`

**Verificación**: `grep -c 'de la mesa' GUIA` → 0; cada ID de `traces:` aparece en la tabla.

### P-22 · Laboratorio (`Examples/`)

- **Hallazgos**: los cambios de laboratorio que exigen P-04, P-07…P-16, P-20; C1-27 (bits de ejecución y README).
- **Capa**: laboratorio. **Costo**: alto (re-correr experimentos). **Reversible**: sí. **Derivados**: salidas versionadas de cada experimento tocado.

| # | Archivo | Cambio exacto | Verificación |
|---|---|---|---|
| L1 | 20 scripts sin bit de ejecución (`find Examples -name '*.sh' ! -perm -u+x`) | `chmod +x` sobre esos 20; al primer commit, `git update-index --chmod=+x` si se versiona desde un sistema sin bits | `find Examples -name '*.sh' ! -perm -u+x \| wc -l` → 0 |
| L2 | `Examples/README.md`, columna «Cómo correr todo» | `./correr-todo.sh` → `bash correr-todo.sh` (N0) y `sh correr-todo.sh` (N1); `./verificar.sh` → `bash verificar.sh`; `./eN-…/experimento.sh` → `bash eN-…/experimento.sh` | cada comando copiado corre desde su carpeta |
| L3 | `N1/e1-node.mjs`, `N1/e1-razor.sh`, `N1/generar.py` | agregar un caso con identificador no ASCII en cp1252: `const a\xf1o = 2026;` para Node y `<p>@Çaudal</p>` + `public int Çaudal {get;set;}` en `@code` para Razor | salidas con `SyntaxError` y `RZ1005`/`CS1056` |
| L4 | `N1/e1-file.sh` | agregar `printf 'acentuaci\xc3\xb3n\n' > moji.txt; file moji.txt` | salida `Unicode text, UTF-8 text` con `file-5.46` |
| L5 | `N2/e2-migracion/` | agregar el caso de `evidencia-abogado-del-diablo/squash-y-blame/experimento.sh` | `blame` vuelve a la autora con el SHA del squash |
| L6 | `N2/e7-editorconfig-checker/` (nuevo) | copiar `evidencia-abogado-del-diablo/editorconfig-checker/` | 6 errores, rc=1, como la salida de la evidencia |
| L7 | `N2/e8-repos-de-referencia/` (nuevo) | copiar `evidencia-abogado-del-diablo/repos-de-referencia/relevar.sh` y su salida fechada (no se re-corre: es un relevamiento al 2026-10-07) | la salida trae los seis repos con su SHA corto |
| L8 | `N3/02-…/` | agregar `inspeccion-targets.sh` con los `grep`/`sed` de Informe-senior-dotnet-01 y la consulta del índice de versiones de `Microsoft.Net.Sdk.Compilers.Toolset` | salida con `BuildWithNetFrameworkHostedCompiler`, `_IsDisjointMSBuildVersion … 18.9` y 0 versiones `8.*` |
| L9 | `N3/03-…/` | agregar el E1 de pnpm 12.10.1 + `packageManager: pnpm@10.18.0` con y sin `pmOnFail=error` | `10.18.0`, rc=0; `ERR_PNPM_BAD_PM_VERSION`, rc=1 |
| L10 | `N3/salidas/` (nuevo) | versionar la salida completa de cada `correr.sh` como `E3-<m>.txt` | 6 archivos |
| L11 | `N4/e2-nuget-cpm-pinning/run.sh`, paso 5 | correrlo con y sin `RestorePackagesWithLockFile`, y con `<WarningsAsErrors>$(WarningsAsErrors);NU1603</WarningsAsErrors>`, en SDK 8 y 10 (como `evidencia-auditor/nu1603-sdk10/`) | sin lock: `NU1603` (rc=1 como error); con lock: rc=0 y `resolved 9.0.0` |
| L12 | `N4/e4-npm-lock/` | agregar `evidencia-auditor/locks-multiplataforma/experimento.sh` | 26 variantes en cada lock, una instalada |
| L13 | `N7/compuerta/compuerta.sh` | antes de llamar al verificador: `tiene python3 \|\| { mal "texto: falta python3 (prerrequisito, no violación)"; …; }` y lo mismo si falta `$DIR/check_text_policy.py` | sin `python3`, el mensaje nombra la herramienta |
| L14 | `N8/imagen/Dockerfile.por-componente` | `ARG PY_IMAGE=python:3.12.15-slim@sha256:05cda9777409a9c3ffddd94a4c476b79f0769a0b4857f0c7ed9226b6800b0d6f` | `docker buildx build` sin `--build-arg` pasa |
| L15 | `N8/solucion/web/package.json` | agregar `"devEngines": { "runtime": { "name": "node", "version": "22.23.2" } }` y re-correr E8-3 sin `engine-strict` | `EBADDEVENGINES` con Node 24 antepuesto |
| L16 | `N8/e6-sbom-unificado/` | agregar la corrida literal del bloque de §11.5 | `E8-6-comando-de-la-guia.txt`, rc=0 |
| L17 | `A-plantillas/repo/` | `.editorconfig` (comentario de A.1), `Directory.Build.props` (A.4), nuevo `Directory.Build.targets` (A.4b), `.devcontainer/devcontainer.json` (A.9), nuevo `imagen/Dockerfile` (A.10 con Node 24), `.github/workflows/…` (A.12), `.github/dependabot.yml` (A.13 con `docker`), `tools/ci/compuerta.sh` (esqueleto con `exit 1`), `.git-blame-ignore-revs` (A.15) | `diff` con cada bloque del Anexo A sin diferencias |
| L18 | `A-plantillas/verificar.sh` | pasos nuevos: 1b `dotnet new console -o tmp/Nueva` + compuerta de texto (2 violaciones con la variante A); 2b lock sólo en `App`; construir `imagen/Dockerfile` y correr `web/` adentro; comprobar que el hook con el esqueleto rechaza un `.cs` cp1252 | rc=0 y salida versionada en `salidas/EA-1-plantillas.txt` |

**Privacidad**: el `grep` de identificadores privados del contrato (R-PRIV, `00-Contrato-De-Entrada.md`) sobre `Examples/` y la guía → 0 líneas después de aplicar.

### P-23 · Capa de origen (bitácora)

- **Hallazgos**: los que nacieron en un núcleo o en la integración: C1-01/C1-03 (CI-05, N3, N4), C1-10 (CI-02, N2), C1-20/C1-21 (CI-06, N5), C1-11 (N1), C1-09/C1-37 (N2), C1-04 (N3), C1-02/C1-26/C1-30 (N4, N0), C1-17/C1-18/C1-34 (N6, `03-Marco-De-Referencia.md`), C1-19 (N7), C1-12/C1-16 (N8).
- **Capa**: bitácora. **Costo**: bajo. **Reversible**: sí. Se aplica **antes** que los parches de la guía.

Cada corrección se agrega como **nota fechada** al pie de la sección afectada, con el formato `> **Corrección mesa ciclo 1 (2026-10-09, C1-nn).** <texto>`, sin borrar el texto original (registro de solo agregado). Textos:

| Archivo y lugar | Nota |
|---|---|
| `04-Integracion.md`, CI-05 | Reabierta por E1 (exit 145): con `disable`, toda estación necesita el SDK exacto; el modo estricto sólo-CI es del lock, no del SDK. Política por defecto: con lock y `disable`, costo declarado; alternativa completa sin lock (`latestPatch` + `NU1603` como error + registro). Guía §6.4. |
| `04-Integracion.md`, CI-02 | Extendida: en la familia .NET el BOM es convención (ningún lector decide); tercera rama «heredado todavía en cp1252 → decidir antes de migrar»; `dotnet new console` crea `Program.cs` y `.csproj` con BOM (E2-6). Guía §5.2.3. |
| `04-Integracion.md`, CI-06 | Aplicada: digest + bot en lo que construye lo publicado; devcontainer con etiqueta fija o la receta de la CI; `docker` en A.13. Docker documenta la actualización de digests [B113]; GitHub no. |
| `04-Integracion.md`, §10 «Pendiente de la mesa» | Resuelto: CycloneDX por defecto si el consumidor no pide otro (guía §9.2.3). |
| `N1-…md`, L124 | «Node y Razor nunca» es falso en identificadores: `SyntaxError` (Node 22.23.2) y `RZ1005`/`CS1056` (SDK 8.0.425). |
| `N2-…md`, L205, L229, L294, L310 | El squash es compatible con `.git-blame-ignore-revs` si cada commit va en su PR y se lista el SHA de `main`; el paso de refresco exige árbol limpio y pull previo (pérdida de trabajo medida por lector-sin-contexto-01). |
| `N3-…md`, §3.4 y L356 | «Sí, de forma indirecta pero completa» vale en la CLI; en Visual Studio con SDK 8 no hay selección automática y el paquete *toolset* no existe para 8.x; con SDK 10, depende de `DOTNET_HOST_PATH` y de MSBuild < 18.9. |
| `N4-…md`, L95, L398, L440 | El «sin advertencia» lo produce el lock: sin lock aparece `NU1603` (SDK 8.0.425 y 10.0.400). |
| `N4-…md`, L171, L203, L354 | `--universal` es de `uv pip compile`; `pip-compile` no tiene esa opción (7.6.2, exit 2). pnpm y Yarn: multiplataforma, verificado. |
| `N0-…md`, L160 | [B83] habla de bibliotecas que **no** se distribuyen y de proyectos de código común; conservar el lock «no hace daño». |
| `N6-…md`, L217, L516, L566 | ISO/IEC 5962:2021 = SPDX 2.2.1 (IEC Webstore, 2026-10-09); deja de estar sin verificar. |
| `N6-…md`, L433 | «L1 de inmediato» no se sostiene: L1 exige `builder.id` y E6-5 lo trae vacío. |
| `03-Marco-De-Referencia.md`, decisión N6 «sólo CI» | Sometida a la mesa: la procedencia se **produce** sólo en CI; §9 aplica con matices en ESC-01 a ESC-04 (diagnóstico, reconstrucción). La procedencia firmada pasa a condicionarse a un consumidor externo (§12 paso 8b). |
| `N7-…md`, L288 | Para una organización privada el mínimo es Team (Pro es de cuentas personales). Lo que la rama protegida no impide: PR que edita la compuerta, job `skipped`, administradores por defecto. GitLab Free: «Pipelines must succeed». |
| `N8-…md`, L207 | «lo único» es falso: `devEngines.runtime` falla por defecto (npm 10.9.8 y 11.19). |
| `N8-…md`, L321 | La procedencia firmada por la plataforma no nombra las bases; la de BuildKit sí, sin firma ni `builder.id`. Tres piezas: procedencia, materiales del entorno y su atadura. |

**Verificación**: cada archivo de la tabla tiene su nota con el ID `C1-nn`; ninguna línea original borrada (`git diff --stat` sólo con inserciones en esos archivos, si la bitácora se versiona).

### P-24 · Rule-Indexing: apartamiento registrado para el PO

- **Hallazgo**: C1-48. **Capa**: proceso. **Costo**: nulo sobre la guía. **Reversible**: sí.
- **No se escribe la ia-db** (fuera del alcance de escritura de esta corrida). Se registra el apartamiento en el cierre de la mesa con esta entrada propuesta, para que el PO la copie:

`LAB/Lab-Documentos.Documentacion/ia-db/indexes/00_MASTER-INDEX.md`, tabla «Inventario de guías», fila nueva:

```markdown
| 16 | `Metodologia-Entorno-Desarrollo/` | Guía de estudio en un documento: caso + marco + mapa + 8 capítulos temáticos (estructura n.1–n.9) + hoja de ruta + anexos A–F, con laboratorio `Examples/` (73 experimentos) | 1 | ~3 300 | `GUIA-ENT-DEV` · 2026-10-09 | [10](10_Entorno-de-Desarrollo.md) |
```

y en «Dos linajes», «Guías propias con aparato común (1–9)» → «(1–9, 16)». Índice nuevo propuesto `10_Entorno-de-Desarrollo.md` con: propósito (fijar, hacer cumplir y registrar el entorno por capas en .NET, Node.js y Python y su combinación), mapa de secciones (§1 caso; §2 ESC/CTX/ACT; §3 seis capas; §4–§11 por capa; §12 hoja de ruta), IDs estables (ESC-01…05, CTX-NET/NODE/PY/POLI, ACT-DEV/ARQ/OPS/REV, E0-1…EA-1, B01…B204), dónde están las plantillas (Anexo A ↔ `Examples/A-plantillas/repo/`) y los límites (Anexo F: nada corrido en Windows).

**Verificación**: el cierre del ciclo (`Mesa/Cierre`) lista este apartamiento en «pendientes para el PO» con el texto de arriba (memoria del proyecto: avisar al PO todo apartamiento de una regla del marco).

---

## 3. Cobertura hallazgo → parche

| Ítem | Parches | Ítem | Parches |
|---|---|---|---|
| C1-01 | P-06, P-09, P-16, P-17, P-23 | C1-30 | P-10, P-23 |
| C1-02 | P-06, P-10, P-16, P-22, P-23 | C1-31 | P-09, P-22 |
| C1-03 | P-09, P-10, P-15, P-16, P-17, P-23 | C1-32 | P-12 |
| C1-04 | P-06, P-09, P-12, P-22, P-23 | C1-33 | P-10, P-14 |
| C1-05 | P-13, P-14, P-22 | C1-34 | P-12, P-19, P-23 |
| C1-06 | P-03, P-06, P-08, P-13, P-14, P-15, P-16, P-17, P-22 | C1-35 | P-05, P-07, P-19, P-21 |
| C1-07 | P-16, P-22 | C1-36 | P-08, P-16, P-22 |
| C1-08 | P-08, P-13, P-16, P-22 | C1-37 | P-08, P-15, P-16, P-22, P-23 |
| C1-09 | P-08, P-17, P-23 | C1-38 | P-05, P-07, P-08, P-09, P-10, P-11, P-12, P-13, P-14 |
| C1-10 | P-08, P-15, P-16, P-22, P-23 | C1-39 | P-15 |
| C1-11 | P-07, P-14, P-22, P-23 | C1-40 | P-03 (y todos los textos nuevos), P-07, P-15, P-21 |
| C1-12 | P-14, P-22, P-23 | C1-41 | P-19 |
| C1-13 | P-14, P-16, P-22 | C1-42 | P-02, P-06 |
| C1-14 | P-14 | C1-43 | P-01, P-12, P-21, P-23 |
| C1-15 | P-14, P-22 | C1-44 | P-06, P-08, P-09, P-10, P-11 |
| C1-16 | P-12, P-14, P-23 | C1-45 | P-03 |
| C1-17 | P-12, P-23 | C1-46 | P-21 |
| C1-18 | P-12, P-14, P-15, P-17, P-23 | C1-47 | P-08, P-15 |
| C1-19 | P-13, P-16, P-23 | C1-48 | P-24 |
| C1-20 | P-11, P-16, P-21, P-23 | C1-49 | P-05, P-13, P-14 |
| C1-21 | P-06, P-11, P-14, P-15, P-16, P-17, P-23 | C1-50 | P-09 |
| C1-22 | P-06…P-14 (*Aplica* y una pregunta situada por capítulo) | C1-51 | P-12 |
| C1-23 | P-03, P-07…P-14 (§n.9 Práctica) | C1-52 | P-07 |
| C1-24 | P-03, P-06 | C1-53 | P-16 |
| C1-25 | P-06, P-10, P-14, P-18 | C1-54 | P-02, P-04, P-06, P-08, P-12, P-15, P-18 |
| C1-26 | P-10, P-16, P-17, P-23 | C1-55 | P-03, P-08…P-14, P-20, P-22 |
| C1-27 | P-03, P-04, P-22 | C1-56 | P-07, P-22 |
| C1-28 | P-13 | C1-57 | P-12 |
| C1-29 | P-14 | C1-58 | P-10, P-22 |

## 4. Chequeos globales después de aplicar (marco §5.6)

1. Anclas internas y slugs: 0 rotas, 0 duplicadas (los encabezados nuevos §n.9 «Práctica» no colisionan).
2. `[Bnn]`: 204 definidas, 204 citadas.
3. IDs de experimento: cada `E…` citado tiene fila en el Anexo E y su ruta existe.
4. Diagramas: los 11 bloques mermaid renderizan con `minlag/mermaid-cli`.
5. Marcas: sólo las cinco de §0.3, en negrita (conteo antes/después).
6. Privacidad: el `grep` de identificadores privados sobre guía, laboratorio y bitácora → 0.
7. Preguntas guía: método declarado — cada pregunta en negrita de §3.7–§11.6 tiene, en su párrafo de respuesta, `*Aplica*`, `*No aplica*` o `*Criterio*`; se registran el conteo antes (método del voto de evidencia: 9 de 39 en la misma línea; método de requisitos: 20 de 57) y el de después (esperado: todas).
8. Laboratorio: los experimentos tocados por P-22 se re-corren y sus salidas versionadas se actualizan; EA-1 con rc=0.

## 5. Deuda y límites declarados por el auditor

- C1-45 se resuelve con **exclusión** en §0.1, no con la subsección comparativa (vigencia de las alternativas: C1-Q06, nivel C).
- C1-10: síntesis ante un empate de dirección; si la mesa de aprobación la rechaza, segunda ronda del jurado (marco §5.3).
- Afirmaciones de Windows que los parches agregan (Git Bash, Docker Desktop, `iconv` en Git Bash, compilador efectivo de Visual Studio, firma sin clave): todas rotuladas **[no verificado]** con su motivo; ninguna se presenta como hecho.
- `actions/attest` v4.2.2 y la etiqueta `sdk:8.0.425-bookworm-slim` son datos volátiles: se re-resuelven al cerrar la guía.

---

## Revisión 2

### P-23 · Capa de origen (bitácora) — Revisión 2

> Fecha: 2026-10-09. Vuelta 1 de 2 permitidas (marco §5.5). Responde a los MEJORAR_PLAN de `04-Aprobacion-costo-beneficio.md`, `04-Aprobacion-coherencia-historica.md` y `04-Aprobacion-riesgo.md`, y al pedido de `04-Aprobacion-impacto.md` (notas de origen para los ajustes de P-10 y P-16). `04-Aprobacion-evidencia.md` lo había aprobado: nada de lo aprobado cambia.

**Qué se conserva.** El mecanismo (nota fechada de solo agregado, `> **Corrección mesa ciclo 1 (2026-10-09, C1-nn).** <texto>`), el orden (P-23 antes que cualquier parche de la guía) y las **16 filas** de la revisión 1, tal cual.

**Qué cambia.**

1. **Anclaje.** Cada fila nueva cita la línea **y** una frase literal del archivo (versión del 2026-10-09). Si las notas anteriores corren la numeración, manda la frase. Las líneas se comprobaron con `sed -n` sobre cada archivo antes de escribir esta revisión.
2. **Veinte filas nuevas** (R2-01 a R2-20): dieciséis cubren los huecos que señalaron los cuatro jueces y cuatro (R2-04, R2-13, R2-18 y R2-20) salen de la pasada de `grep` que pidió riesgo (punto 3).
3. **Pasada de `grep` documentada.** Se tomaron los fragmentos que P-03…P-17 mandan reemplazar (`reemplazar \`…\` por`), se partieron en segmentos de 28 caracteres o más y se buscaron, sin marcas, en `Nucleos/*.md`, `03-Marco-De-Referencia.md` y `04-Integracion.md`. Hubo 19 coincidencias. Su destino está en la tabla de cierre.

#### Filas nuevas

| ID | Archivo, lugar y frase ancla | C1 | Pedida por | Nota |
|---|---|---|---|---|
| R2-01 | `N1-codificacion-y-finales-de-linea.md`, diagrama de §2.1, L75: `"Linux / macOS<br/>(o Windows con ACP UTF-8)"` | C1-35 | costo-beneficio (1), riesgo | La rama «(o Windows con ACP UTF-8)» no se sostiene. La prueba del PR que arregló el *fallback* (dotnet/roslyn #83320, [EV1-02]; [B15] en la guía) afirma que en Windows `GetEncoding(0)` devuelve la página ANSI real «even when the UTF-8 locale setting is enabled». El diagrama se lee sin esa rama, y el caso pasa a pregunta abierta, **[no verificado]** (requiere Windows con la opción beta activada). Guía §4.2.1 (P-07). |
| R2-02 | `N1-…md`, L78: «La rama «Windows con ACP UTF-8» es una deducción de [EV1-01], [EV1-05] y [EV1-08]» | C1-35 | costo-beneficio (1), riesgo | La deducción queda **contradicha por la fuente** (ver R2-01): ya no es una deducción sin verificar, es una pregunta abierta con una prueba del fabricante en contra. |
| R2-03 | `N1-…md`, §13, L328: «Roslyn tuvo una regresión, introducida en febrero de 2026 (dotnet/roslyn #82159…» | C1-35 | costo-beneficio (1) | Precisión: #83320 es el **arreglo** de esa regresión, no la fijación de un comportamiento, y su prueba es la fuente de R2-01. La ventana real (qué SDK o Visual Studio distribuyó #82159 sin #83320) sigue abierta como C1-Q03. |
| R2-04 | `N1-…md`, L281: «`file` ayuda, pero es heurístico y sólo separa cp1252 de Latin-1 cuando el archivo tiene algún byte `80–9F`» | C1-56 | pasada de `grep` | La regla se observó con `file` 5.46 sobre una muestra (E1-13) y no es bicondicional: un cp1252 cuyos bytes altos forman por casualidad UTF-8 válido (texto que ya tenía mojibake) sale como UTF-8. `file` no es un detector de cp1252. P-22 agrega ese caso a `e1-file.sh`. Guía §4.3 (P-07). |
| R2-05 | `04-Integracion.md`, §10, L245: «la rama Windows del mecanismo de Roslyn (ACP 1252 y ACP UTF-8)» | C1-35 | riesgo | Lo que queda por revalidar en Windows es la rama ACP 1252. ACP UTF-8 deja de ser una rama a revalidar: es una pregunta abierta con la prueba de #83320 en contra (R2-01). |
| R2-06 | `N2-politica-de-texto-y-remediacion.md`, §3.1, L90: «lo que rompe la reproducibilidad que persigue N6» | C1-36 | costo-beneficio (2) | El argumento se reemplaza: el EOL entra en los literales *verbatim* multilínea (E2-1, sección D), así que **la misma prueba da distinto en las dos máquinas**. La igualdad de binario entre estaciones, en cambio, la guía misma no la exige (§2.4, §8.2.4). `* text=auto`, sin `eol` global, es una opción válida: la usan los seis repositorios `dotnet/*` relevados (el límite está declarado: son repositorios de Microsoft, no «la industria»). La plantilla A.2 conserva la segunda como **[criterio]**. Guía §5.2.2 (P-08). |
| R2-07 | `N2-…md`, tabla de §3.2, L105: «`*.slnx`, `*.csproj`, `*.props`, `*.targets` \| UTF-8 sin BOM» | C1-10 | coherencia (2), riesgo | Para estas extensiones ningún lector decide el BOM: es **convención del equipo**. MSBuild compila un `.csproj` con BOM (E2-5), y `dotnet new console` crea `Program.cs` y el `.csproj` **con** BOM (E2-6, SDK 8.0.425). «La CLI no le agrega BOM» vale sólo para un archivo que ya no lo tenía. Con la variante sin BOM, lo que crea `dotnet new` se normaliza antes del primer commit. Rama nueva: heredado todavía en cp1252 → decidir la variante antes de migrar. Guía §5.2.3, columna «Lo decide» (P-08). |
| R2-08 | `N2-…md`, §14, L288: «`.csproj` y `.slnx` sin BOM, porque la CLI no se lo agrega al editarlos» | C1-10 | coherencia (2), riesgo | Igual que R2-07: es convención, no una regla de lector. El motivo citado describe la edición de un archivo sin BOM, no su creación. |
| R2-09 | `N8-integracion-poliglota.md`, tabla de codificación, L140: «todo lo demás (`.cs`, `.js`, `.mjs`, `.py`, `.json`, `.toml`, `.csproj`…) \| UTF-8 sin BOM \| LF \| El lector más estricto de cada tipo» | C1-10 | riesgo | Para `.cs` y `.csproj` no hay un lector que exija «sin BOM»: es convención del equipo (R2-07). La columna «Quién lo exige» vale para `.js`, `.mjs`, `.py`, `.json` y `.toml` (E8-1). |
| R2-10 | `N3-fijacion-del-toolchain.md`, diagrama, L82: `PM["packageManager"] -- "Corepack<br/>(si está)"`; §4.4, L165; criterio, L174: «sigue siendo útil como **declaración**»; tabla, L252 | C1-31 | costo-beneficio (3) | pnpm ≥ 11 hace cumplir `packageManager` **por sí mismo**, sin Corepack (`pmOnFail`, desde v11.0.0 [B196]). E1 (AH-001): pnpm 12.10.1 sin Corepack, con `packageManager: pnpm@10.18.0`, usa la 10.18.0, y con `pmOnFail=error` da `ERR_PNPM_BAD_PM_VERSION` y exit 1. Corepack queda para Yarn. El diagrama se lee «pnpm ≥ 11 (pmOnFail) · Yarn con Corepack». Guía §6.2 (P-09). |
| R2-11 | `N4-congelamiento-de-dependencias.md`, *snippet*, L232: «`<!-- Directory.Build.props (raíz): lock en todos los proyectos; modo bloqueado sólo en CI. -->`» | C1-26 (y objeción de impacto a P-16) | coherencia (3), impacto | El lock va **sólo en los ejecutables** y en `Directory.Build.targets`, no en `.props`. En `.props`, una condición sobre `OutputType` no surte efecto, porque al evaluarse el valor todavía está vacío (`evidencia-auditor/lock-solo-ejecutables/`, SDK 8.0.425). La condición tiene que incluir `WinExe`: con sólo `'$(OutputType)' == 'Exe'`, un proyecto WinForms/WPF restaura con rc=0, sin `packages.lock.json` y sin aviso. Con `'$(OutputType)' == 'Exe' Or '$(OutputType)' == 'WinExe'`, WinExe y Web generan su lock (J-I1, `evidencia-aprobacion-impacto/winexe-lock/`). El texto final de la condición es el que fije la revisión 2 de P-16 (guía A.4b). Si difiere, esta nota se ajusta en la misma pasada. |
| R2-12 | `N0-modelo-de-capas-y-reproducibilidad.md`, *snippet*, L185–L190: «`Directory.Build.props — capas 3 y 5 para todos los proyectos .NET del repo`» | C1-26 (P-16) | impacto (N0) | Igual que R2-11: el lock de la capa 3 va en `Directory.Build.targets` y sólo en los ejecutables (`Exe`, `WinExe`). `RestoreLockedMode` y `ContinuousIntegrationBuild` siguen en `.props`, porque no dependen de `OutputType`. |
| R2-13 | `N4-…md`, §12, L331: «en una biblioteca que se publica, CPM sí y lock no (el fabricante desaconseja» | C1-26 | pasada de `grep` | Se cita mal a [B83]. La fuente habla de proyectos de biblioteca que **no se distribuyen** y de proyectos de código común, y aclara que conservar el lock «no hace daño». El lock de un proyecto común no gobierna a quien lo referencia: por eso va en los ejecutables (R2-11). Es la misma corrección que la nota de N0 L160 de la revisión 1. Guía §7.6 (P-10). |
| R2-14 | `N4-…md`, L95: «si la versión pedida no existe, NuGet resuelve la siguiente disponible sin advertencia» (complementa la nota de la revisión 1 en ese lugar) | C1-03, C1-58 (objeción de impacto a P-10) | impacto (N4) | Con la política por defecto (con lock), el `NU1603` desaparece (E4-2; `evidencia-auditor/nu1603-sdk10/`, SDK 8.0.425 y 10.0.400). **Ninguna compuerta del laboratorio compara `requested` con `resolved`**: `compuerta.sh` (N7) sólo filtra la salida de `dotnet restore` (L74), y `verificar.sh` (N8) no lo hace. Mientras eso siga así, la defensa es revisar el diff del lock (guía §7.6, pregunta situada). Si la revisión 2 de P-10 incorpora la comparación a las compuertas (su opción a), la nota se completa con el ID del experimento que la muestra fallando ante 8.0.2 → 9.0.0. |
| R2-15 | `N5-entornos-en-contenedores.md`, §3, L107: «**Digest en todo lo versionado** que nombra una imagen: `FROM` del Dockerfile, `image` del `devcontainer.json`, `container.image` de la CI»; L108: «Dependabot soporta los ecosistemas `docker` y `devcontainers`»; §16, L318: «Digest en todo lo que construye artefactos o define el entorno compartido»; §18, L372 (fila N7) | C1-20, C1-21 | coherencia (1), riesgo | Política aplicada (dirección (b), 4-0): digest + bot **donde se construye lo publicado** (el `FROM` de la imagen de CI y `container.image`). En el `image` del `devcontainer.json` va una etiqueta fija de SDK y SO (p. ej. `8.0.425-bookworm-slim`, verificada con `global.json`) o la misma receta que la imagen de CI, cuyas bases por digest mantiene el bot de la CI. Docker documenta que Dependabot actualiza «tags and digests» [B113]. La tabla de GitHub no lo menciona y marca `devcontainers` como no soportado en repositorios privados [EV5-26]. Que actualice digests en un repositorio privado queda **[no verificado]** (requiere la plataforma). Guía §8.2.2 y A.13 (P-11, P-16). |
| R2-16 | `N8-…md`, §5.4, L230: «**[criterio]** La comparación A = B se hace con la configuración de publicación explícita.» | C1-29 | costo-beneficio (4), riesgo | La igualdad A = B no se comprueba en la estación: F5 compila en `Debug` y sin `ContinuousIntegrationBuild`. Se comprueba **en la CI, como prueba de regresión del `.csproj`**: con la misma imagen, `dotnet build -c Release -p:ContinuousIntegrationBuild=true` con `ConstruirPoliglota=true` contra `build.sh`, comparando las DLL. Demuestra que los *targets* de A no divergen de B, no que la estación reproduzca a la CI. Guía §11.2.5 (P-14, punto 4). |
| R2-17 | `N8-…md`, §5.5, tabla de criterio, L255: «Conviene para la **CI que publica** cuando cada etapa es independiente»; §5.4, L228: «Cada componente se publica por separado … B, con un job o etapa por componente»; §16, L491 (pregunta 2) | C1-14 | costo-beneficio (5) | En la CI, **imagen única si el artefacto es uno**. Por componente sólo si los componentes se publican por separado, y con una etapa previa que corra la compuerta completa en la imagen única: `Dockerfile.por-componente` sólo corre los comandos estrictos de cada ecosistema, no la compuerta de texto. Con la CI por componente, el Python de desarrollo lo instala uv y el de la CI viene de `python:3.12.15-slim`: es la misma versión, de dos orígenes, y hay que declararlo. Guía §11.2.6, §11.2.7, §11.3 y §11.6 P2 (P-14, puntos 5, 6, 9 y 16). |
| R2-18 | `N8-…md`, tabla de criterio de §5.4, L225: «A en la estación, **con** `npm ci`, `uv run --locked`, `engine-strict` e Inputs/Outputs» (complementa la nota de L207 de la revisión 1) | C1-12 | pasada de `grep` | `devEngines` (o, alternativamente, `engine-strict`): `devEngines.runtime` falla por defecto (`EBADDEVENGINES`, npm 10.9.8 y 11.19). Guía §11.2.5 (P-14, punto 3). |
| R2-19 | `N7-compuertas-y-gobierno.md`, §4.2–§4.3, L129–L152 («`compuerta/compuerta.sh` tiene tres pasos»; «el toolchain y el grafo no, porque son propiedades del repositorio entero») | C1-05 | costo-beneficio (6), condicional | Se verificó la condición del juez: N7 §4 no dice «cualquier disposición» con esas palabras, pero lo da a entender al tratar toolchain y grafo como propiedades del repositorio entero. Por eso la nota se agrega. **Alcance**: la compuerta busca los archivos nativos sólo en la raíz (`[ -f .python-version ]`, `[ -f uv.lock ]`, etc., en el directorio actual; `compuerta.sh` L60 y L85). Con proyectos en subcarpetas, como la solución de N8, da `n/a` para archivos que existen (E1 del arquitecto, C1-05). Sirve para un proyecto por ecosistema en la raíz. Para otra disposición, un inventario explícito de proyectos, como en `verificar.sh` de N8. «Falta la herramienta» y «violación» se informan distinto (P-22, L13). Guía §10.2.2 (P-13). |
| R2-20 | `N6-procedencia-y-trazabilidad.md`, §13, L427: «Los datos 1, 4, 6 y casi siempre 2 los da una procedencia SLSA generada por la plataforma (E6-5)… el 3 hay que agregarlo si la procedencia no lo trae» | C1-16 | pasada de `grep` | La procedencia firmada por la plataforma da 1, 2 y 6, y deja el entorno como opcional [B202]. La de BuildKit (E6-5) da además el 4, sin firma y con `builder.id` vacío. El SBOM da el 5. El 3, y el 4 si nadie lo trae, los agrega el registro del entorno. Guía §9.6 P1 (P-12, punto 14). |

#### Cobertura de cada objeción

| Juez | Pedido | Filas |
|---|---|---|
| costo-beneficio | (1) N1 L75, L78, L328 | R2-01, R2-02, R2-03 |
| | (2) N2 L90 | R2-06 |
| | (3) N3 L82, L165 | R2-10 (amplía a L174 y L252) |
| | (4) N8 L230 | R2-16 |
| | (5) N8 §5.5 y L228 | R2-17 (amplía a L491) |
| | (6) N7 §4, condicional | R2-19 (condición verificada) |
| coherencia-histórica | (1) N5 L107, L108, L372, L318 | R2-15 |
| | (2) N2 L105, L288 | R2-07, R2-08 |
| | (3) N4 L228–L240 | R2-11 |
| riesgo | N1 L75/L78 y `04-Integracion.md` L245 | R2-01, R2-02, R2-05 |
| | N2 L105, L288 y N8 L140 | R2-07, R2-08, R2-09 |
| | N5 L107, L108, L372 | R2-15 |
| | N8 L230 | R2-16 |
| | Pasada de `grep` sobre P-03…P-17 | punto 3 y tabla siguiente |
| impacto | Ajustes de P-10 en N4 | R2-14 (y R2-13) |
| | Ajustes de P-16 en N4 y N3/N0 | R2-11, R2-12. En N3 no hace falta nota: P-16 no toca nada que nazca en N3. Su A.10 con Node 24 aplica CI-10, ya cerrada (coherencia, fila P-16). |

#### Destino de las 19 coincidencias de la pasada de `grep`

| Parche | Archivo y línea | Destino |
|---|---|---|
| P-07 | N1 L124 | Ya cubierta (nota de la revisión 1, C1-11) |
| P-07 | N1 L281 | **R2-04** |
| P-08 | N2 L229 | Ya cubierta (nota de N2 de la revisión 1, refresco con árbol limpio) |
| P-08 | N2 L286 | Sin nota: la frase coincidente («heredado ya convertido con BOM → `utf-8-bom`») la conserva P-08. Lo que cambia en ese párrafo es la rama cp1252, que entra por R2-07 |
| P-08 | N2 L288 | **R2-08** |
| P-10 | N4 L19 | Sin nota: P-10 conserva la oración y agrega contexto (fabricante, *opt-in*) |
| P-10 | N4 L331 | **R2-13** (y C1-03 en R2-14) |
| P-10 | N4 L95 | Revisión 1 + **R2-14** |
| P-11 | N5 L151 | Sin nota: cambia sólo la marca (`[hallazgo negativo, a revalidar]` → vocabulario de P-03), y el vocabulario de marcas es de la guía, no de la bitácora |
| P-11 | N5 L165 | Sin nota: aclaración de redacción (se nombran ESC-01 y ESC-04) |
| P-12 | `04-Integracion.md` L134 | Sin nota: la coincidencia es la enumeración de alcances del SBOM, que P-12 conserva |
| P-12 | N6 L427 | **R2-20** |
| P-12 | N8 L528 | Sin nota: igual que `04-Integracion.md` L134 |
| P-14 | N8 L207 | Ya cubierta (revisión 1, C1-12) |
| P-14 | N8 L225 | **R2-18** |
| P-14 | N8 L230 | **R2-16** |
| P-14 | N8 L491 | **R2-17** |
| P-16 | `04-Integracion.md` L142 | Sin nota: describe qué verifica EA-1, y P-22 L18 lo actualiza en el laboratorio |
| — | `03-Marco-De-Referencia.md` | Sin coincidencias nuevas. La decisión N6 «sólo CI» ya tiene su nota de la revisión 1 |

**Límite del método.** La pasada encuentra las frases que el núcleo copió casi textuales a la guía. No encuentra una afirmación que en el núcleo esté dicha con otras palabras. Esos casos los cubren las líneas que señalaron los jueces (R2-01 a R2-03, R2-06, R2-07, R2-10, R2-11, R2-15 a R2-17, R2-19).

**Verificación** (se suma a la de la revisión 1):

1. Cada archivo de las dos tablas tiene sus notas con el ID `C1-nn`. `grep -c "Corrección mesa ciclo 1"` por archivo da la suma de las filas de la revisión 1 y de la revisión 2 que le corresponden.
2. Ninguna línea original se borra. Si la bitácora se versiona, `git diff --numstat` sólo muestra inserciones. Si no, se compara `wc -l` antes y después: crece exactamente en las líneas de las notas.
3. Se repite la pasada de `grep` (punto 3) después de aplicar P-03…P-17. Cada coincidencia con texto **viejo** que quede en la capa de origen tiene que tener debajo una nota `C1-nn`, o figurar como «Sin nota» en la tabla de destino.
4. R2-11, R2-12 y R2-14 se revisan contra el texto final de las revisiones 2 de P-16 y P-10 antes de aplicarse.

> **Nota de solo agregado (ciclo 2, 2026-10-09, C2-40).** P-03 3e decía «Son las únicas cinco marcas» y §7 de la aplicación, «Sólo las cinco de §0.3»: la tabla de §0.3 define cuatro marcas de juicio, en negrita, y tres referencias sin negrita. La guía 1.0.0 dice «cuatro marcas de juicio» (Ciclo-2, P-02).

> **Nota de solo agregado (ciclo 3, 2026-10-09; pendiente de P-22 del ciclo 2 y C3-12).** Tres textos de este documento se corrigieron en la guía sin nota acá: el chequeo requerido de GitHub se identifica por nombre y hay que fijar la app esperada (C2-19); un `pre-receive` lo puede deshabilitar quien administra el servidor o, en GHES, quien recibió la delegación (C2-20); «BuildKit para procedencia» no es alternativa en la disposición de un solo artefacto (C2-21). El `AssemblyMetadata ImagenDigest` del bloque de A.4 (L866) se retira en el ciclo 3 (C3-12). Ver `Mesa/Ciclo-2/05-Aplicacion.md` y `Mesa/Ciclo-3/03-Parches.md` P-13.
