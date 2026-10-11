# Mesa · Ciclo 1 · 02 — Voto del juez de impacto

> Fecha: 2026-10-07. Rol: juez de impacto (marco `Mesa-Evaluadora.md` §4.3/§5.3). Función objetivo: si no se corrige, ¿qué le pasa concretamente al lector de la guía (formación de criterio, error al aplicar)?
> Insumos: `01-Consolidado.md` y verificación puntual de las líneas citadas de la guía (L233, L474, L719, L885, L933, L1048, L1570, L2010, L2168, L3060), que dicen lo que el consolidado transcribe.
> En los ítems [CONTRADICCIÓN] el voto es sobre si procede corregir; la dirección preferida va en el fundamento, juzgada por el daño al lector.

| Id | Voto | Fundamento |
|---|---|---|
| C1-01 | PROCEDE | El lector que siga §6.4 pone `disable` creyendo que las estaciones siguen trabajando y cada desarrollador con otro parche queda con exit 145 sin poder compilar: error al aplicar inmediato y masivo. |
| C1-02 | PROCEDE | El lector aprende que NuGet calla siempre y no busca `NU1603`, la única señal que tiene si no adopta lock; además forma un modelo falso de qué protege el lock. |
| C1-03 | PROCEDE | Hoy el lector recibe una condición sin costos ni alternativa y, combinada con C1-01, bloquea estaciones. Dirección preferida (a): lock por defecto en .NET con su costo declarado (estaciones con SDK exacto, `NU1004`) y la variante sin lock (`latestPatch`/`latestFeature` + `NU1603` como error) descrita como alternativa con lo que deja de detectar; dos políticas completas duplicarían texto sin mejorar la decisión del caso. |
| C1-04 | PROCEDE | Un equipo con Visual Studio y SDK 8 cree tener el compilador fijado y diagnostica mal diferencias de build entre IDE y CI; el registro del compilador efectivo en §9 es lo que le permite verlo. |
| C1-05 | PROCEDE | El lector que adopta la disposición de §11 obtiene `[n/a]` en verde para archivos que existen: una compuerta que aprueba lo que no revisó es peor que no tenerla, porque da falsa seguridad. |
| C1-06 | PROCEDE | ESC-01 es la estación del caso disparador: sin prerrequisitos declarados el lector Windows ve commits válidos rechazados como «violación», no sabe correr la migración y, por WSL, verifica otro toolchain. Es el escenario principal sin vía ejecutable. |
| C1-07 | PROCEDE | Quien copie las plantillas «verificadas juntas» instala una compuerta que acepta cp1252: reproduce exactamente el defecto que la guía promete prevenir, convencido de estar protegido. |
| C1-08 | PROCEDE | El lector necesita una capa de texto que funcione en Windows sin depender de bash+python. Dirección preferida (b): editorconfig-checker + `dotnet format` por defecto (binarios Windows, mantenidos por terceros) y el script propio como ejemplo y para verificar el índice; reduce de raíz el daño de C1-05/06/07. En cualquier dirección, sumar la herramienta a §5.2.5. |
| C1-09 | PROCEDE | Pérdida irreversible de trabajo sin commitear de cada desarrollador que obedezca el paso 5: el daño más concreto e irrecuperable de toda la lista. |
| C1-10 | PROCEDE | El lector que aplica A.1 y corre `dotnet new console` obtiene dos violaciones en el primer minuto y concluye que la política está rota o que el SDK está mal. Dirección preferida (b): separar lo que decide un lector de lo que es convención del equipo, que forma criterio en vez de una tabla a memorizar; mencionar el caso heredado en cp1252. |
| C1-11 | PROCEDE | Ante un `SyntaxError` o `RZ1005` de un archivo cp1252 el lector descarta la codificación porque la guía le dijo «nunca»: diagnóstico desviado en el síntoma central de la guía. |
| C1-12 | PROCEDE | El lector concluye que debe usar `engines`+`engine-strict` y descarta `devEngines`, que la propia guía recomienda en §6.2.3: contradicción interna que lo deja sin saber qué configurar. |
| C1-13 | PROCEDE | Quien arme el entorno con el Anexo A obtiene `EBADDEVENGINES` dentro de la imagen de CI y un devcontainer sin Python: el anexo de copiar y pegar no funciona como juego. |
| C1-14 | PROCEDE | El lector que siga §11.3/§11.6 adopta para la CI una imagen que no corre la compuerta y con un Python distinto del de desarrollo: pierde la verificación y la equivalencia que motivan el capítulo. |
| C1-15 | PROCEDE | El comando de §11.5 falla copiado (builder inexistente, Python no encontrado); el lector no puede reproducir el SBOM unificado ni confiar en que lo mostrado es lo medido. |
| C1-16 | PROCEDE | El lector cree obtener en un solo paso firma y bases por digest; al implementarlo descubre que ningún camino lo da, o peor, afirma ante terceros algo que su procedencia no contiene. |
| C1-17 | PROCEDE | Un equipo declararía SLSA L1 ante un cliente o auditor con una procedencia que no lo cumple: afirmación de cumplimiento falsa con consecuencias fuera del equipo. |
| C1-18 | PROCEDE | Para el equipo chico con repo privado la ruta estándar impone firma sin plataforma que la dé y sin que lleve el entorno: costo sin beneficio y abandono del paso. Dirección preferida (b): 8a registro del entorno + SBOM para todos, 8b procedencia firmada si hay consumidor externo, contrato o repo público. |
| C1-19 | PROCEDE | El lector cree que la rama protegida le garantiza la compuerta y no cierra las vías (PR que edita la compuerta, job `skipped`, bypass de admins); además busca el plan «Pro» para una organización y no existe. |
| C1-20 | PROCEDE | Con rótulos contradictorios el lector no sabe si confiar en el bot para digests, y copiando A.13 se queda sin el ecosistema `docker`: digests congelados, que la guía misma señala como riesgo. |
| C1-21 | PROCEDE | En repo privado ningún bot actualiza la `image` del devcontainer: un digest ahí congela vulnerabilidades, que la propia guía desaconseja sin bot. Dirección preferida (b): etiqueta fija + `global.json` en el devcontainer; digest + bot donde se construye lo publicado. |
| C1-22 | PROCEDE | Sin *Aplica* el lector memoriza respuestas sin saber cuándo valen: falla la formación de criterio, que es el objetivo de una guía de estudio y regla explícita del PO. |
| C1-23 | PROCEDE | Sin actividades el lector no ejercita el criterio y el laboratorio de 71 experimentos queda como evidencia inaccesible; una práctica por capítulo sobre experimentos existentes es el puente. |
| C1-24 | PROCEDE | El primer tramo del Recorrido le presenta ~30 mecanismos sin explicar: el lector se pierde o abandona antes de §4. Basta con señalizar las dos velocidades. |
| C1-25 | PROCEDE | Términos usados decenas de veces sin definición (SLSA, BuildKit, RID…) y «índice» con tres sentidos producen lecturas equivocadas, en especial al confundir índice de git con registro de paquetes. |
| C1-26 | PROCEDE | La cita invertida de [B83] lleva al lector a activar el lock en bibliotecas por mandato de una fuente que dice lo contrario, y A.4 lo hace en la señal pobre que §7.7 condena. |
| C1-27 | PROCEDE | Los primeros comandos fallan copiados («Permiso denegado», `cd` inexistente): el lector pierde confianza en todo el laboratorio en el primer contacto. |
| C1-28 | PROCEDE | Quien copie el extracto corre la compuerta sobre su árbol de trabajo y publica algo que no es lo que está en el commit: anula la regla que el propio script enuncia. |
| C1-29 | PROCEDE | El lector intenta comprobar la igualdad de artefactos en su estación, obtiene hashes distintos y concluye que la frontera A está mal: un criterio no comprobable donde se aplica induce a error. |
| C1-30 | PROCEDE | `pip-compile --universal` sale con exit 2: el lector que use pip-tools no puede aplicar la recomendación y atribuye a pip-tools una propiedad que no tiene. |
| C1-31 | PROCEDE | El lector agrega Corepack para algo que pnpm ≥ 11 ya hace solo, o no activa `pmOnFail` y cree que `packageManager` es sólo declarativo: decisión de herramienta sobre premisa falsa. |
| C1-32 | PROCEDE | Un lector con repo privado que adopte la firma sin clave por su cuenta publica nombres en el log de transparencia sin saberlo, y quien verifique con `verify-blob-attestation` cree validar el builder. Alcance condicionado a la dirección de C1-18 (va en 8b). |
| C1-33 | PROCEDE | El lector cree que npm, pip y uv quedan tan cubiertos como NuGet contra confusión de dependencias; los huecos (`--extra-index-url`, paquetes sin scope) son la vía real del ataque. |
| C1-34 | PROCEDE | Un lector que cite la norma en un documento de cumplimiento atribuirá estatus ISO a SPDX 3.0.1: error factual que se propaga fuera del equipo. |
| C1-35 | PROCEDE | El lector Windows puede activar la ACP UTF-8 creyendo que el compilador leerá UTF-8 por eso, cuando la prueba de la fuente dice lo contrario: falsa solución para el síntoma central. |
| C1-36 | PROCEDE | El argumento actual enseña una razón que la guía misma refuta, y presenta como única una opción que los repos de referencia no usan: forma criterio sobre un fundamento falso. |
| C1-37 | PROCEDE | El lector descarta el squash, que suele ser su estrategia de merge obligatoria, por una incompatibilidad inexistente; y no recibe la advertencia útil (SHA que no está en `main`). |
| C1-38 | PROCEDE | Obligar a volver a §2 cada vez que aparece un ID corta la lectura y hace que el lector aplique a su escenario reglas que no le corresponden. Corrección barata. |
| C1-39 | PROCEDE | Dos indicaciones de orden opuestas confunden al lector sobre cómo estudiar; una frase basta para resolverlo. |
| C1-40 | PROCEDE | Las marcas de procedencia son la herramienta del lector para distinguir evidencia de criterio; con once variantes sin definir no puede ponderar qué es medido y qué es opinión. |
| C1-41 | PROCEDE | Con enlaces a `blob/main` el lector abre código que ya cambió y no encuentra lo citado, o encuentra algo que lo contradice. |
| C1-42 | PROCEDE | El mapa que contradice la tabla de capas y un índice con Partes inexistentes desorientan la navegación justo en el capítulo que la organiza. |
| C1-43 | PROCEDE | El lector encuentra en el entregable un actor interno y una decisión abierta: no sabe qué formato de SBOM elegir ni si la guía está terminada. |
| C1-44 | PROCEDE | Un lector que entra por su contexto (no por escenario) no encuentra qué cambia para él en §5–§8 y aplica la receta genérica. |
| C1-45 | PROCEDE | Sin comparación ni exclusión declarada, el lector no sabe si existen enfoques de entorno completo alternativos ni por qué la guía no los trata; una exclusión motivada en §0.1 alcanza para no sesgar su criterio. |
| C1-46 | NO_PROCEDE | Las trazas viven en metadatos del front matter que el lector humano no usa para estudiar ni aplicar; no produce error ni deforma criterio. La trazabilidad ya está en la bitácora. Si se toca, que sea para quitar `traces`, sin tabla nueva. |
| C1-47 | NO_PROCEDE | Los datos ya están en la prosa y el daño concreto de esos procedimientos (pérdida de trabajo en §5.2.6) lo cubre C1-09 con precondiciones y chequeo; el bloque YAML no evita ningún error adicional al lector. |
| C1-48 | PROCEDE | Sin entrada en la ia-db la guía queda invisible para los agentes y trabajos futuros que consultan el índice; corregir sólo como registro del apartamiento con la entrada propuesta, sin escribir la ia-db. |
