# Informe AH-001 — Especialista en ecosistemas Node.js y Python (ciclo 3)

- Rol: agente ad hoc «Especialista en ecosistemas Node.js y Python (toolchain, gestores, locks, empaquetado)».
- Pregunta: ¿lo que la guía afirma de cada herramienta de Node.js y de Python (qué declara, qué hace cumplir, su default y su estado al 2026-10-07) es exacto, y la recomendación por ecosistema coincide con la del fabricante o la PEP?
- Objeto: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (3605 líneas), leído a ciegas como obra terminada. Leí mi informe del ciclo 2 y las filas que me tocan del consolidado y de la aplicación del ciclo 2 (C2-29, C2-30, C2-41, C2-42, C2-43, C2-Q09); no leí informes de otros especialistas del ciclo 3.
- Experimentos: en el scratchpad de la sesión (no en el laboratorio), con `python:3.12-slim` (Python 3.12.14). `python:3.15-slim` no se pudo bajar (Docker Hub: `unauthorized`). Consultas web y al registro del 2026-10-09.
- Lo cerrado en el ciclo 2 está aplicado: pnpm 10 / ≥ 11 y `yarnPath` (C2-30, C2-41) en §6.2.3 y §6.6; los cinco mensajes medidos en §7.3 (C2-42) con su rótulo [observado]; npm 10.9.8 frente a 11.19 en §11.2.5 punto 3 (C2-43). No lo re-litigo.

## Hallazgos

### adhoc-AH-001-01 — Con el modo UTF-8 de Python ≥ 3.15, un archivo cp1252 no «se lee como UTF-8»: falla con `UnicodeDecodeError` — S3, E1 + E2

**Ubicación:** §4.2.4, tabla «Cómo supone la codificación cada lector», fila «Python `open()` sin `encoding=`», columna «cp1252 sin BOM» (L512).

**Ancla:** «≤ 3.14: según *locale*; ≥ 3.15: se lee como UTF-8 [B29]».

**Problema:** «se lee como UTF-8» sugiere que el archivo se lee (quizá con reemplazos, como en las filas de Node). No: en el modo UTF-8, `open()` usa el manejador de errores **estricto**. La documentación de Python, sección «Python UTF-8 Mode» (docs.python.org/3/library/os.html, consultada el 2026-10-09), dice: «`open()`, `io.open()`, and `codecs.open()` use the UTF-8 encoding by default. However, they still use the strict error handler by default». Para el caso disparador es el dato que importa: un script que en Windows con ACP 1252 leía bien datos cp1252 hasta 3.14 **deja de funcionar** al subir a 3.15, y ya no depende de la plataforma.

**E1** (Python 3.12.14; el modo UTF-8 se fuerza con `-X utf8`, que es el que PEP 686 vuelve predeterminado):

```
$ printf 'a\xf1o\n' > cp.txt
== -X utf8 (modo UTF-8 de PEP 686)
1                                   # sys.flags.utf8_mode
UnicodeDecodeError: 'utf-8' codec can't decode byte 0xf1 in position 1: invalid continuation byte
exit=1
== LC_ALL=C, -X utf8=0 (≤ 3.14 con locale ASCII)
ANSI_X3.4-1968
UnicodeDecodeError: 'ascii' codec can't decode byte 0xf1 in position 1: ordinal not in range(128)
```

**Dirección:** «≤ 3.14: según *locale* (correcto en Windows con ACP 1252; `UnicodeDecodeError` con un *locale* UTF-8); ≥ 3.15: **`UnicodeDecodeError`** (modo UTF-8 estricto) [B29]», y sumar la página del modo UTF-8 de Python como fuente (o citarla en [B30]). Opcional, una línea en §4.3: la recomendación de `encoding=` explícito vale doble, porque 3.15 convierte un error latente de Windows en uno visible.

### adhoc-AH-001-02 — §11.2.2 sigue hablando de Python 3.15 en futuro, contra §4.3 y el Anexo F — S4, E2 (coherencia interna)

**Ubicación:** §11.2.2, segundo párrafo (L2174).

**Ancla:** «porque hasta que el modo UTF-8 sea el predeterminado (Python 3.15) `open()` sin codificación usa `locale.getencoding()`».

**Problema:** §4.3 (L548) y el Anexo F (L3579, L3591) ya dicen que 3.15.0 se publicó el 2026-10-09 con PEP 686 activo [B205]. C2-29 pedía «calificar §11.2.2»; la frase quedó con el subjuntivo de futuro. El lector que llega por §11 lee que 3.15 todavía no existe.

**Dirección:** «porque en Python 3.14 y anteriores —el 3.12 del laboratorio— `open()` sin codificación usa `locale.getencoding()`, que en Windows es la página ANSI [B35]; desde 3.15 usa UTF-8 estricto [B29][B205], y un archivo en otra codificación falla en vez de leerse».

### adhoc-AH-001-03 — «npm y pip hacen cumplir `requires-python`» en ESC-01: en el proyecto de la guía lo hace cumplir uv, no pip — S4, E2

**Ubicación:** §6.4, fila ESC-01 (L1050); §6.6, pregunta «¿Qué respeta y qué ignora una estación Windows con Visual Studio?» (L1126).

**Anclas:** L1050 «npm y pip hacen cumplir `devEngines`, `engine-strict` y `requires-python`»; L1126 «`engines`, `devEngines` y `requires-python` se cumplen igual porque los aplican npm y pip».

**Problema:** pip valida `Requires-Python` de **lo que instala** (la propia guía lo dice bien en §6.2.4: «pip falla si el intérprete no coincide, salvo `--ignore-requires-python`»). En el proyecto tipo de la guía (A.8: uv, `package = false`) nadie instala el proyecto con pip; quien cruza `requires-python` con el intérprete es uv, como dice §6.6 dos preguntas antes («uv los cruza y falla si se contradicen (E3-4)») y la tabla §6.2.5 (uv: «Sí: valida contra `requires-python`»). La frase atribuye la garantía a la herramienta equivocada.

**Dirección:** «los aplican npm y uv (pip, sólo al instalar el paquete)» en L1126, y lo mismo en la celda de L1050.

### adhoc-AH-001-04 — Las fuentes de npm citan la documentación v11, mientras la guía da npm 12 como vigente — S4, E2

**Ubicación:** Anexo D, [B63], [B64], [B150] (L3304, L3305, L3391); contraste con §7.3 L1244 («las vigentes al 2026-10-07 (npm 12, …)») y [B93], que ya cita v11 y v12.

**Ancla:** «B63 | npm Docs v11 — `package.json` (`engines`, `devEngines`, `repository`) | https://docs.npmjs.com/cli/v11/configuring-npm/package-json».

**Evidencia:** registro de npm (2026-10-09): `latest` = 12.2.0 (2026-09-30), 12.0.0 del 2026-07-08. docs.npmjs.com/cli/v12/configuring-npm/package-json (2026-10-09) mantiene lo que la guía afirma: `devEngines` antes de `install`, `ci` y `run`; `onFail` «if left undefined is of the same value as `error`»; `engines` «advisory only» salvo `engine-strict`. La semántica no cambió; la cita queda una mayor atrás de la versión que la guía declara vigente.

**Dirección:** citar v12 (o «v11 y v12», como [B93]) en B63, B64 y B150; si se prefiere v11 porque es la de las mediciones (npm 10.9.8/11.19), decirlo en la fila.

## Revisado y bien

1. **Estado de Node y de npm al 2026-10-07:** nodejs.org/en/about/previous-releases (2026-10-09) da v26 *Current*, v24 y v22 LTS, v20 EOL y «Starting with Node.js 27, the release cycle will be annual and every major version will move to _LTS_», igual que §6.2.3; docs.npmjs.com v12: «As of npm v12, `npm-shrinkwrap.json` is no longer read or written by npm» y `lockfileVersion: 3` desde npm 9, igual que §7.2.2.
2. **pnpm y Yarn tras el ciclo 2:** pnpm.io/settings/cli (2026-10-09): `pmOnFail` desde v11.0.0, default `download`, valores `download`/`error`/`warn`/`ignore`, y «Overrides the `onFail` behavior of both the `packageManager` field and `devEngines.packageManager`», igual que §6.2.3 y §6.6; la versión E3-3 (pnpm 12.10.1, `ERR_PNPM_BAD_PM_VERSION`) está en la salida versionada.
3. **Versiones «vigentes» con su fecha:** en el registro, al 2026-10-07 eran las últimas npm 12.2.0, pnpm 12.10.1 (2026-10-06) y uv 0.12.23 (2026-10-03); uv 0.12.24 salió el 2026-10-08 y 0.13.0 el 2026-10-09, así que «uv 0.12» del Anexo F es exacto a su fecha declarada (y entra en «revisar antes de aplicar»). `tomllib` con BOM falla (`TOMLDecodeError Invalid statement (at line 1, column 1)`, Python 3.12.14), como dice §1.4.

## Solicitudes de convocatoria

Ninguna.
