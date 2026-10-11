# Mesa de aprobación, 2.ª vuelta: juez de evidencia

> Fecha: 2026-10-09. Objeto: la «Revisión 2» de P-23 (capa de origen) en `03-Parches.md`, L1213–L1304. Función objetivo: ¿cada nota está probada al nivel que declara? Las anclas las comprobé yo mismo (`sed -n` por línea y `grep -o` por frase) sobre los archivos de la bitácora tal como están hoy.

## 1. Anclas: línea y frase

Las veinte filas nuevas citan una línea y una frase literal. Comprobé las dos cosas en cada una.

| Fila | Archivo y línea | ¿Línea y frase coinciden? |
|---|---|---|
| R2-01 | N1 L75 | Sí: `E -- "Linux / macOS<br/>(o Windows con ACP UTF-8)" --> L[…]` |
| R2-02 | N1 L78 | Sí: «La rama «Windows con ACP UTF-8» es una deducción de [EV1-01], [EV1-05] y [EV1-08]» |
| R2-03 | N1 L328 | Sí: «Roslyn tuvo una regresión, introducida en febrero de 2026 (dotnet/roslyn #82159…» |
| R2-04 | N1 L281 | Sí: «`file` ayuda, pero es heurístico y sólo separa cp1252 de Latin-1 cuando el archivo tiene algún byte `80–9F`» |
| R2-05 | `04-Integracion.md` L245 | Sí: «la rama Windows del mecanismo de Roslyn (ACP 1252 y ACP UTF-8)» |
| R2-06 | N2 L90 | Sí: el párrafo **[criterio propio]** sobre `61-0A-62` frente a `61-0D-0A-62` |
| R2-07 | N2 L105 | Sí: la fila de `*.slnx`, `*.csproj`, `*.props`, `*.targets` → «UTF-8 sin BOM» |
| R2-08 | N2 L288 | Sí: «`.csproj` y `.slnx` sin BOM, porque la CLI no se lo agrega al editarlos» |
| R2-09 | N8 L140 | Sí: la fila «todo lo demás (`.cs`, …, `.csproj`…) \| UTF-8 sin BOM \| LF \| El lector más estricto…» |
| R2-10 | N3 L82, L165, L174, L252 | Sí, las cuatro (`"Corepack<br/>(si está)"`, `packageManager` y Corepack, «útil como **declaración**», fila de la tabla) |
| R2-11 | N4 L232 | Sí: `<!-- Directory.Build.props (raíz): lock en todos los proyectos; modo bloqueado sólo en CI. -->` |
| R2-12 | N0 L185–L190 | Sí: el comentario está en L186 y `RestorePackagesWithLockFile` en L190, dentro del rango |
| R2-13 | N4 L331 | Sí: «en una biblioteca que se publica, CPM sí y lock no (el fabricante desaconseja commitearlo)» |
| R2-14 | N4 L95 | Sí: «si la versión pedida no existe, NuGet resuelve la siguiente disponible **sin advertencia**» |
| R2-15 | N5 L107, L108, L318, L372 | Sí, las cuatro |
| R2-16 | N8 L230 | Sí: «[criterio] La comparación A = B se hace con la configuración de publicación explícita.» |
| R2-17 | N8 L255, L228, L491 | Sí, las tres |
| R2-18 | N8 L225 | Sí: «A en la estación, **con** `npm ci`, `uv run --locked`, `engine-strict` e Inputs/Outputs» |
| R2-19 | N7 L129–L152 | Sí: «tiene tres pasos» (L131) y «el toolchain y el grafo no, porque son propiedades del repositorio entero» (L152) |
| R2-20 | N6 L427 | Sí: «Los datos 1, 4, 6 y casi siempre 2 los da una procedencia SLSA generada por la plataforma (E6-5)…» |

Estado previo: `grep -c "Corrección mesa ciclo 1"` da 0 en los diez archivos de la capa de origen, así que todavía no hay notas que corran la numeración. Igual, la regla «si las notas anteriores corren la numeración, manda la frase» resuelve el riesgo que trae aplicar la revisión 1 primero.

## 2. Hechos que las notas afirman

| Afirmación | Fila | Cómo la verifiqué | Resultado |
|---|---|---|---|
| La prueba de #83320 dice «even when the UTF-8 locale setting is enabled» | R2-01, R2-02, R2-05 | Ya leída con la API de GitHub en la 1.ª vuelta (J6 de `04-Aprobacion-evidencia.md`) | Fiel. La nota la deja como pregunta abierta y **[no verificado]**, que es el nivel que corresponde |
| #83320 arregla la regresión de #82159 | R2-03 | J6 (título «Fix regression in CreateFallbackEncoding») | Fiel |
| `file` no detecta cp1252 cuando los bytes altos forman UTF-8 válido | R2-04 | **E1 propio (J-R2-1)**: `file-5.46`; `printf 'string s = "acci\xc3\xb3n";\n'` → `Unicode text, UTF-8 text`, y `iconv -f UTF-8 -t UTF-8` lo acepta; `printf '…acci\xf3n…'` → `ISO-8859 text` | Confirmado. P-22 tiene que incorporar el caso a `e1-file.sh`, como dice la nota |
| `dotnet new console` crea `Program.cs` y `.csproj` **con** BOM; la CLI no agrega BOM al editar un `.csproj` sin BOM | R2-07, R2-08 | `Examples/N2-…/salidas/e6-plantillas-dotnet.txt`: SDK 8.0.425 y 10.0.400 «Program.cs con BOM», «app.csproj con BOM»; tras `dotnet add reference`, `a.csproj sin BOM` | Confirmado |
| Seis repositorios `dotnet/*` con `* text=auto` sin `eol` global | R2-06 | `Informe-abogado-del-diablo.md` L187 (E1, `repos-de-referencia/salida.txt`, 2026-10-07) | Respaldado. La nota declara el límite («repositorios de Microsoft, no la industria») |
| pnpm ≥ 11 hace cumplir `packageManager` sin Corepack (`pmOnFail`) | R2-10 | [B196], literal en la 1.ª vuelta; `ERR_PNPM_BAD_PM_VERSION` en AH-001 | Fiel |
| Lock en `.props` con condición sobre `OutputType` → ningún lock; en `.targets` → sí | R2-11, R2-12 | `evidencia-auditor/lock-solo-ejecutables/salida.txt` (SDK 8.0.425): variante P → App y Lib «NO»; variante T → App «SI», Lib «NO»; cambio sin regenerar → `NU1004`, rc=1 | Confirmado |
| Con sólo `== 'Exe'`, WinExe restaura rc=0 sin lock; con `Or 'WinExe'`, sí | R2-11 | `evidencia-aprobacion-impacto/winexe-lock/salida*.txt`: «Win restore rc=0 / Win: packages.lock.json NO» y, con el arreglo, «SI» | Confirmado |
| [B83] habla de bibliotecas que **no** se distribuyen y de código común, y «no harm» | R2-13 | 1.ª vuelta, cita literal de [B83] | Fiel. La frase de N4 L331 («biblioteca que se publica») es efectivamente una mala cita |
| Con lock, `NU1603` desaparece; sin lock, falla | R2-14 | `evidencia-auditor/nu1603-sdk10/salida.txt` (10.0.400): A sin lock → `NU1603` rc=1; B con lock → rc=0 | Confirmado |
| `compuerta.sh` sólo filtra la salida de `dotnet restore` (L74) y busca nativos en la raíz (L60, L85) | R2-14, R2-19 | `sed -n` sobre `Examples/N7-…/compuerta/compuerta.sh`: L60 `if [ -f .python-version ]`, L74 `grep -iE 'error\|NU1\|not found\|requested'`, L85 `if [ -f uv.lock ]`. Ninguna compuerta compara `requested` con `resolved` (`grep` sobre los `.sh` del laboratorio: sólo aparecen en experimentos de N0, N4, N6 y N8) | Confirmado |
| Docker dice que Dependabot actualiza «tags and digests»; `devcontainers` no se soporta en privados | R2-15 | [B113] literal y V10 de la 1.ª vuelta | Fiel. Lo que falta se rotula **[no verificado]** |
| `devEngines.runtime` falla por defecto (`EBADDEVENGINES`) | R2-18 | AH-001 (npm 10.9.8 y 11.19) | Fiel |
| La procedencia de la plataforma da 1, 2 y 6, y el entorno es opcional | R2-20 | [B202] literal en la 1.ª vuelta; `builder.id` vacío en E6-5 | Fiel |

## 3. Observaciones (no bloquean)

1. **R2-11, R2-12 y R2-14 dependen de otras revisiones.** Remiten al texto final de las revisiones 2 de P-16 y P-10. El punto 4 de la verificación lo prevé: se revisan antes de aplicarse. Si la revisión 2 de P-10 incorpora la comparación `requested`/`resolved` a las compuertas, R2-14 tiene que nombrar el experimento que la muestra fallando. Hasta entonces, la nota dice lo que hay hoy, que comprobé.
2. **R2-16 y R2-17 son criterio de diseño de la CI**, no hechos. Así están escritos, y apoyados en E8-3. No piden más evidencia.
3. **El límite del método está declarado** (la pasada de `grep` no encuentra paráfrasis) y la tabla de destino justifica cada «Sin nota». Revisé las tres justificaciones que afirman hechos (N2 L286, `04-Integracion.md` L134/N8 L528 y `04-Integracion.md` L142): son coherentes con los parches que citan.

## 4. Voto

**APLICAR.** Las veinte anclas existen con su línea y su frase. Cada hecho que agregan las notas tiene una fuente leída o un experimento con salida versionada, y el de R2-04 lo reproduje yo. Lo que no se pudo ejecutar (Windows con ACP UTF-8, Dependabot en un repositorio privado) queda **[no verificado]**: el nivel declarado coincide con el probado. Nada de lo que aprobé en la 1.ª vuelta cambia.
