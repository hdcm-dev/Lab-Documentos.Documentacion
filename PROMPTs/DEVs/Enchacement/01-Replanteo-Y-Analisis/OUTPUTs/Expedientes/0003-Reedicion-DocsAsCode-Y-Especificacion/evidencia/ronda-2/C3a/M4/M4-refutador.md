# M4 — Invenciones del caso C3a, ronda 2: verificación del refutador

Caso C3a, corridas `C3a-r1` y `C3a-r2` de la ronda 2. Medida M4 del folio previo de ensayos (§7; criterio de 099
§5.5): una invención es una cita `ruta:línea` que no existe o que no sostiene lo afirmado. Pasa si es 0. Todas las
rutas de este informe son relativas al directorio de cada corrida (`repo/`, `salida/`, `conocimiento.md`). El repo
leído es `repo/proyecto` (Colmenar, plantilla .NET MAUI más `README.md`); las citas de las fichas son relativas a su
raíz.

## Resultado

| Corrida | Citas extraídas (distintas) | En A-01 / en artefactos | Archivo o línea inexistente | Muestra abierta | No sostiene | Invenciones | M4 |
| --- | --- | --- | --- | --- | --- | --- | --- |
| C3a-r1 | 116 (64) | 68 / 48 | 0 | 20 | 0 | **0** | pasa |
| C3a-r2 | 91 (48) | 75 / 16 | 0 | 20 | 0 | **0** | pasa |

## Instrumento

`citas.py` (en esta carpeta) recorre `salida/A-01.md` y después todos los artefactos de `salida/` (incluidas las
salidas de `salida/inventario/`). Extrae cada cita `ruta:línea`, los rangos `a-b`, las listas con coma y las
continuaciones `` `:N` ``. Resuelve la ruta contra `repo/proyecto/`; un nombre suelto que no está en la raíz se busca
por nombre en `repo/` y en `salida/inventario/`. Comprueba que el archivo existe y que su número de líneas alcanza el
final del rango, en el árbol de trabajo y además en el commit `HEAD` del repo leído (`git show HEAD:<ruta>`): el
árbol está limpio y `HEAD` es el SHA que declaran las dos fichas (`d39dfbd`), así que las citas valen en ese SHA.

Comando: `python3 -I citas.py <corrida> --tsv citas-<corrida>.tsv`. Tablas completas: `citas-C3a-r1.tsv` y
`citas-C3a-r2.tsv` (columna `head`: comprobación contra el commit). Salida del script: `salida-script-C3a-r1.txt` y
`salida-script-C3a-r2.txt`.

**Salidas de grep del inventario.** Además, cada línea `ruta:n:texto` de `salida/inventario/` se comparó con la línea
`n` del archivo en `repo/proyecto`: 23 en C3a-r1 y 14 en C3a-r2, ninguna discrepa. El inventario no está fabricado.

**Respuestas del coordinador.** `salida/respuestas.md` cuenta como fuente sólo si la respuesta cita un archivo del
directorio. En las dos corridas todas las respuestas (Q-1 a Q-7 en r1, Q-1 a Q-5 en r2) son «no disponible», con
fuente «—»: ninguna sirve de fuente. Se revisó que ninguna ficha apoye un hecho en ellas: las dos sólo las usan para
marcar «pendiente», y cada `Q-n` citado coincide con lo que pide `salida/demandas.md` de su corrida (por ejemplo, la
organización es Q-4 en r1 y Q-5 en r2).

## Muestra abierta (20 por corrida)

Se leyó cada línea citada y se comparó con lo que la ficha afirma.

### C3a-r1

| # | Cita | Afirmación | Sostiene |
| --- | --- | --- | --- |
| 1 | `README.md:46-50` | no se recibieron el repo del paquete ni el de la API | sí (API en otro repo privado; paquete en repo propio) |
| 2 | `README.md:67-68` | espacio EX, a Colmenar le tocan EX-31 a EX-46 | sí, literal |
| 3 | `README.md:16-22` | perfiles con permisos distintos | sí (tabla de cinco perfiles) |
| 4 | `README.md:24-25` | confidencialidad resuelta en la API | sí |
| 5 | `Colmenar/AppShell.xaml:9-12` | una sola página | sí (un único `ShellContent` a `MainPage`) |
| 6 | `README.md:38-41` | sitio público decidido y pagado, dos idiomas, lo lee el asistente del organismo | sí |
| 7 | `README.md:77` | visibilidad sólo afirmada | sí («Este repositorio es público…») |
| 8 | `README.md:96-97` | la organización sólo admite automatismos propios | sí |
| 9 | `Colmenar/Colmenar.csproj:37-38` | `main` 1.0 | sí (`ApplicationDisplayVersion` 1.0) |
| 10 | `README.md:34-35` | líneas 2 y 3 en paralelo durante 2027 | sí |
| 11 | `README.md:70-71` | encabezado de la norma de calidad, 90 días | sí |
| 12 | `README.md:93`, `:94`, `:95` | runners Linux, Mac los jueves, Windows | sí |
| 13 | `README.md:98-99` | checks obligatorios afirmados | sí |
| 14 | `README.md:61-66` | delegación a programadora y asistentes; visto bueno del técnico sanitario jefe | sí |
| 15 | `README.md:59-60` | asistentes en los dos repos | sí |
| 16 | `README.md:11-12`, `:89` | propósito de enseñanza; curso en portugués | sí |
| 17 | `Colmenar/Colmenar.csproj:3-48` | sin `GenerateDocumentationFile` | sí (0 apariciones en todo el archivo) |
| 18 | `Colmenar/Colmenar.csproj:68-71` | la versión exacta del paquete del modelo no está en el csproj | sí (sólo `Microsoft.Maui.Controls` y `Logging.Debug`) |
| 19 | `README.md:51-52`, `:100-101` | tabla de productos veterinarios; chequeo diario en temporada y mensual fuera | sí |
| 20 | `README.md:58` | programadora a tiempo completo | sí |

Fuera de la muestra también se leyeron `README.md:1-4`, `:26-28`, `:77-81`, `:85-86`, `:105` y las salidas de
`salida/inventario/d01-autorizacion*.txt` (`Info.plist:35` y `:43` son `UIWindowSceneSessionRoleApplication`, como
se afirma) y `d11-acta.txt`. Todas sostienen lo afirmado.

**Afirmación sin cita que se revisó.** La ficha dice que el acta de delegación «no está en el árbol» aunque
`README.md:61-62` la declara «guardada en el repositorio». No es invención: la búsqueda está en
`salida/inventario/d11-acta.txt` y `git ls-files` sólo devuelve `AppDelegate.cs` y `SceneDelegate.cs`. La
contradicción es del insumo y la ficha la declara (Q-3).

### C3a-r2

| # | Cita | Afirmación | Sostiene |
| --- | --- | --- | --- |
| 1 | `Colmenar/Platforms/Windows/App.xaml.cs:8-16` | `///` sólo en ese archivo, 7 líneas | sí (7 líneas `///` en 8-10 y 13-16; ningún otro `.cs` las tiene) |
| 2 | `Colmenar/MauiProgram.cs:9-22` | la app es la plantilla de MAUI | sí (builder con fuentes y logging, nada más) |
| 3 | `README.md:11` | panel de la cooperativa | sí, literal |
| 4 | `README.md:48-50` | paquete .NET público, escrito a medias por el equipo | sí |
| 5 | `README.md:59-60` | asistentes en los dos repositorios | sí |
| 6 | `README.md:38-39` | sitio decidido y pagado, por publicar | sí |
| 7 | `README.md:67-69` | espacio EX externo | sí |
| 8 | `README.md:45` | la app, este repositorio | sí |
| 9 | `Colmenar/Colmenar.csproj:4-6` | en Linux compila sólo Android | sí (iOS y Mac Catalyst con condición `!linux`; Windows sólo en Windows) |
| 10 | `README.md:93-97` | máquinas de compilación y restricción de la organización | sí |
| 11 | `Colmenar/Colmenar.csproj:37-38` | versión 1.0 | sí |
| 12 | `README.md:34-35` | líneas 2 y 3 durante 2027 | sí |
| 13 | `README.md:58-66` | mapa de quién decide; acta declarada | sí |
| 14 | `README.md:28` | ayuda propia por perfil | sí, literal |
| 15 | `README.md:85-86` | español y portugués; audio para peones | sí |
| 16 | `README.md:12` | una escuela usa la app para enseñar programación | sí |
| 17 | `README.md:48` | identificadores del paquete (apiario, colmena, visita, tambor) | sí |
| 18 | `README.md:77-81` | lo privado: API, proveedor, organismo, ubicaciones, alumnos | sí |
| 19 | `README.md:65-66` | alertas y tratamientos con el técnico sanitario jefe | sí |
| 20 | `README.md:1` | `README.md` existe, empieza en `# Colmenar` | sí |

Fuera de la muestra también se leyeron `README.md:16-22`, `:24-26`, `:46-47`, `:51-52`, `:70-71`, `:72-73`, `:89`,
`:98-101` y las salidas de `salida/inventario/inventario-1.txt` e `inventario-2.txt`. Todas sostienen lo afirmado.
Las afirmaciones de comando sin cita (`git ls-files | grep -iE 'acta|deleg|aprob'` → sólo `AppDelegate.cs` y
`SceneDelegate.cs`; `git tag` vacío; 38 archivos) se repitieron sobre `repo/proyecto` y coinciden.

## Lista de invenciones

- C3a-r1: ninguna.
- C3a-r2: ninguna.
