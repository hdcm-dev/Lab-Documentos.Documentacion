# 03 — Guía de estudio: Organización, estilo y patrones de código en .NET

> **Propósito**: cómo se organiza y se escribe código .NET, «desde cuántas unidades desplegables
> tiene un sistema hasta si una constante va en `PascalCase`», ordenado por costo de reversión.
> Cubre `Guides/Organizacion-Estilo-Patrones-Codigo/` (38 documentos, 11 321 líneas).
> **Fuente primaria**: `Guides/Organizacion-Estilo-Patrones-Codigo/README.md` (`GUIA-INDICE`,
> `last_review` 2026-07-20) y `01-Mapa-Conceptual/Mapa-Conceptual.md`.

## En una pantalla

- Rasgo distintivo: **cada afirmación normativa declara su nivel de autoridad** —lo que Microsoft
  especifica se cita con fuente `N-xx`; lo que es convención del ecosistema se declara `F-xx`; lo
  que es criterio de la guía se marca «esta guía recomienda». Ejemplo insignia: **Clean
  Architecture no es estándar de Microsoft**, aunque se presente así con enorme frecuencia.
- Distinción que ordena todo: **cómo se despliega un sistema y cómo se organiza su código son
  decisiones independientes**. `FAM-SRV` trata el despliegue; `FAM-INT` el código; se leen por
  separado. Partir en servicios no «ordena» un sistema desordenado.
- Evidencia de práctica real: inspección de `dotnet/runtime`, `dotnet/aspnetcore` y
  `dotnet/efcore`, elegidos porque difieren entre sí; esa inspección corrigió afirmaciones que la
  guía daba por sentadas.
- Tecnologías: .NET 10 y C#, ASP.NET Core, Blazor *interactive server*. Dominio: reserva de salas
  (compartido con [01](01_Documentacion-Tecnica.md)).

## Marco de referencia (`00-Marco-de-Referencia/`)

| Eje | Valores |
|---|---|
| Escenarios `ESC-` | `ESC-1` sistema nuevo · `ESC-2` evolución estructural · `ESC-3` normalización de código existente · `ESC-4` evaluación de código ajeno |
| Contextos `CTX-` | `CTX-1` aplicación web o cliente interactivo · `CTX-2` servicio backend o API · `CTX-3` biblioteca reutilizable · `CTX-4` solución distribuida |
| Actores `ACT-` | `ACT-01` arquitecto (partición, estructura, capas) · `02` desarrollador (su módulo, nombres) · `03` responsable técnico (el conjunto de convenciones y excepciones) · `04` revisor de código (si el cambio cumple lo acordado; **no** cambia lo acordado en la revisión) · `05` DevOps (cómo se automatiza; **no** cuál es la convención) · `06` mantenedor de biblioteca (superficie pública, versionado, rupturas) |
| Convenciones | Identificadores, frontmatter, estructura y **los tres niveles de autoridad** |

## Mapa conceptual (`01-Mapa-Conceptual/Mapa-Conceptual.md`)

Secciones: los seis niveles de decisión · la distinción que ordena el dominio · tablas de entrada
por escenario, por contexto y **por decisión concreta** (unas treinta preguntas frecuentes →
documento) · cruces escenario × familia y actor × familia · ruta de lectura en cinco tramos, cada
uno cerrando con algo que se puede decidir.

## Las seis familias, por costo de reversión

| Familia | Pregunta | Documentos (`doc_id`) y tesis |
|---|---|---|
| 1 Arquitectura de servicios `FAM-SRV` (`10-…`) · *la más cara de revertir* | ¿Cuántas unidades desplegables? | `TEM-MONO` (una unidad como decisión legítima por defecto) · `TEM-MODU` (módulos con límites explícitos) · `TEM-MICRO` (qué resuelve de verdad; el monolito distribuido) · `TEM-PART` (criterios verificables para partir o no) |
| 2 Organización de soluciones `FAM-SOL` (`20-…`) | ¿Cuántos proyectos y cómo se agrupan? | `TEM-TOPO` (cinco topologías; cuándo aparece el proyecto de contratos; proyectos y procesos son ejes independientes) · `TEM-SLN` (anatomía del repo, `.sln` vs `.slnx`, convención `src/tests`) · `TEM-SDK` (el atributo `Sdk` como definición real del tipo de proyecto) · `TEM-BUILD` (`Directory.Build.props`, versiones centralizadas, `global.json`) |
| 3 Organización interna `FAM-INT` (`30-…`) | ¿Cómo se reparte el código adentro? | `TEM-CAPAS` (N capas, Hexagonal, Onion, Clean: origen y diferencias reales; ninguna es estándar de Microsoft) · `TEM-SLICE` (Vertical Slice) · `TEM-CVP` (carpetas o proyectos: la única diferencia que importa) · `TEM-NS` (namespaces, `RootNamespace`, `global using`) · `TEM-MODELOS` (cuatro representaciones de un concepto; idioma por planos) |
| 4 Nomenclatura `FAM-NOM` (`40-…`) · *mayor densidad normativa* | ¿Cómo se llaman las cosas? | `TEM-CAPS` (PascalCase, camelCase…) · `TEM-NOMB` (palabras, sufijos, tests, español o inglés) · `TEM-ANTI` (húngara, `Manager`, `Helper`, abreviaturas, nombres que mienten) |
| 5 Estilo de codificación `FAM-EST` (`50-…`) · *máxima discusión, mínimo valor: automatizar* | ¿Cómo se dispone el texto? | `TEM-FORMATO` (Allman, K&R, 1TBS; cuál usa C#) · `TEM-LENG` (`var`, `record`, anulables, `async`, top-level statements) · `TEM-AUTO` (`.editorconfig`, analizadores, severidades, normalizar sin romper `git blame`) |
| 6 Patrones de código `FAM-PAT` (`60-…`) | ¿Qué formas estructurales se usan? | `TEM-ENDP` (Minimal APIs vs controllers, `MapGroup`) · `TEM-DATOS` (Repository sobre EF Core, Unit of Work, CQRS, DTO, migraciones) |
| 61 Análisis integral (`61-Analisis-Integral/Analisis-Integral.md`) | — | Documento adicional fuera de la tabla del README |

## Anexos (`99-Anexos/`) — «no se leen de corrido: se usan»

| Archivo | `doc_id` | Contenido |
|---|---|---|
| `Plantillas.md` | `ANEXO-PLANTILLAS` | Los diez archivos que se escriben una vez al arrancar un repo: esqueleto, `Directory.Build.props`, `Directory.Packages.props`, `global.json`, `.editorconfig`, `.csproj` web / de pruebas / de biblioteca publicable (`CTX-3`), `.git-blame-ignore-revs`, `.gitattributes` |
| `Listas-de-Verificacion.md` | `ANEXO-CHECK` | Lista 1 arranque (`ESC-1`) · 2 evaluar si partir (`ESC-2`) · 3 normalizar (`ESC-3`) · 4 evaluar código ajeno (`ESC-4`) · 5 publicar/mantener biblioteca (`CTX-3`) · cómo usarlas en una revisión automatizada |
| `Glosario.md` | `ANEXO-GLOSARIO` | Términos, alias y pares que se confunden |
| `Referencias.md` | `ANEXO-REFERENCIAS` | 35 fuentes: `N-xx` normativo Microsoft · `F-xx` convención de facto · `O-xx` obras · §4 **conceptos sin fuente normativa** (monolito modular, monolito distribuido, Screaming Architecture, CQRS, Specification, Monolith first, Strangler Fig, Ley de Conway: atribuidos con reserva) |

Regla de auditoría del README §Sobre la evidencia: toda afirmación normativa debe rastrearse a
una fila de `Referencias.md`; si no puede, falta la fuente o es criterio propio mal etiquetado.

## Relación con las otras guías

- `TEM-ENDP` es la contraparte «organización del código» de `TEM-MINIMAL` en la guía REST
  (`Organizacion-Estilo-Rest-API/80-Implementacion-en-NET/README.md`) → [04](04_Diseno-REST-API.md).
- `TEM-CAPAS` y la serie `ARQ-` de Documentación técnica tratan los mismos modelos desde ángulos
  distintos (código vs. documentación exigida) → [01](01_Documentacion-Tecnica.md).
- `Arquitectura/Dot-NET-Arquitectura-Guide.md` (material importado) propone una solución concreta
  Domain/Application/Infrastructure/WebAPI/WebFront/Shared.UI/Desktop; es una aplicación del
  modelo de capas que esta guía discute, no parte de ella → [08](08_Arquitectura-y-References.md).
