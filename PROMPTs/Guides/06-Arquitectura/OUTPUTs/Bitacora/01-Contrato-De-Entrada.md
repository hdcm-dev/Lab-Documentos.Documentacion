# Bitácora 01 — Contrato de entrada y encuadre

**Fecha:** 2026-09-18
**Prompt de origen:** `/LAB/Lab-Documentos.Documentacion/PROMPTs/Guides/06-Arquitectura/03-Reedicion-Arquitectura.md`
**Marco de ciclo:** `/IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md`
**Perfil:** `/IA/PROMPTs/IA.Prompts/PromptFramework/Profiles/Study-Guide-Documentation.md` (RuleSet-Study-Guide)
**Estilo de exposición:** `/IA/PROMPTs/IA.Prompts/Base/Estilo-Redaccion-Explicativo.md` (pregunta → respuesta en una línea → porqué → ejemplos contrastados)

---

## 1. Contrato de entrada (§2 del marco)

```yaml
objeto:
  artefacto: documentación (guía de estudio y de consulta de criterios)
  ruta/id: /LAB/Lab-Documentos/Guides/Arquitectura/Dot-NET-Arquitectura-Guide.md
  version: commit 063f4e9 de hdcm-dev/Lab-Documentos (1003 líneas)
  capas_derivadas: []   # ningún otro documento del repo la referencia
objetivo: >
  Que una persona sin experiencia en arquitectura .NET entienda los conceptos de una
  solución por capas (Clean Architecture), los compruebe con comandos reales cuyos
  resultados sepa leer, y quede con criterio para estructurar desde cero una solución
  .NET para un problema de la vida real.
restricciones_duras:
  - Reedición entera y autocontenida (no delta) del mismo archivo.
  - Incorporar la respuesta «Cada objeto responde una pregunta» (conversación del 2026-09-18)
    con una respuesta explicativa para cada pregunta.
  - Lector sin experiencia; lenguaje claro, técnico y no coloquial.
  - Definiciones, ejemplos, snippets, Mermaid, comandos que se puedan probar con su
    resultado esperado y cómo analizarlo.
  - Preguntas guía con respuestas explicativas, formadoras de criterio.
  - No inventar información; toda afirmación respaldada por evidencia verificable.
decisiones_cerradas:   # tomadas por el usuario en la conversación del 2026-09-18
  - DC-1 Los anillos concéntricos expresan dependencia, no contención de espacios de nombres:
         Domain, Application e Infrastructure son proyectos hermanos.
  - DC-2 Convención de nombres: arquitectura, capas, patrones y operaciones estándar en inglés
         (Repository, Handler, Command, AddAsync, GetById, Create…); conceptos del dominio del
         problema en español (Producto, CrearProductoCommand, ObtenerProductosQuery).
  - DC-3 IProductoRepository vive en Domain; las interfaces de servicios técnicos
         (IEmailService, ICurrentUserService) en Application.
  - DC-4 Idioma español; ejemplo conductor: Producto / Cliente / Pedido.
decisiones_abiertas_para_la_mesa:   # delegadas por memoria «la mesa decide y queda aprobado»
  - DA-1 Reestructuración de §3 (Backend/ vs Clients/) propuesta en la conversación.
  - DA-2 Contracts: ¿opcional u obligatorio? El front usa DTOs que hoy viven en Application.
  - DA-3 Versión de .NET de la guía (hoy .NET 9) frente a la LTS vigente.
  - DA-4 MediatR y AutoMapper: cambio de licencia en 2025 (a verificar con fuentes).
fuera_de_alcance:
  - Microservicios (tiene su propia guía: Guides/Arquitectura/Microservicios-Guide.md).
  - Despliegue productivo, CI/CD.
  - Implementación completa del Desktop MAUI (requiere workloads que no se validan aquí).
umbral_de_calidad: bloquean el cierre S1 y S2
presupuesto: { ciclos_max: 2, hallazgos_max_por_especialista: 7 }
```

### 1.1 Campos ausentes y supuestos declarados

| Campo ausente | Supuesto adoptado | Fundamento |
|---|---|---|
| Destino del entregable | El mismo archivo `Dot-NET-Arquitectura-Guide.md`, reescrito entero | «Reedita entera el documento …» |
| Ruta de la bitácora | `06-Arquitectura/OUTPUTs/Bitacora/`, no `07-Seguridad-…/OUTPUTs/Bitacora` | El prompt conserva la ruta del prompt 07 (copia); la carpeta `06-Arquitectura/OUTPUTs/Bitacora` ya existía vacía, creada por el usuario |
| Un documento o varios | Un único documento; los núcleos del perfil se vuelven capítulos | El prompt pide reeditar «el documento»; el perfil multi-documento cede ante el pedido explícito |
| Entorno para «comandos que se puedan probar» | SDK .NET en contenedor `mcr.microsoft.com/dotnet/sdk`; el lector usa el SDK instalado o el mismo contenedor | El host no tiene `dotnet`; existen las imágenes `sdk:8.0`, `9.0` y `10.0` |
| «Pruebas sobre el servicio» | La guía construye una solución de ejemplo mínima que compila, arranca y responde HTTP; las salidas mostradas son capturas reales | Regla «no inventar»: toda salida debe provenir de una corrida |

---

## 2. Tensiones detectadas (para la mesa)

**T-01 — Lector sin experiencia vs. guía de consulta para diseñar desde cero.** Son dos lecturas distintas: un recorrido de aprendizaje lineal y una referencia de criterios que se consulta salteada. El documento necesita ambas puertas: un recorrido numerado con laboratorio y un capítulo de criterios de decisión que se pueda abrir directamente.

**T-02 — «Comandos que se puedan probar» vs. alcance del ejemplo.** Un ejemplo completo (MediatR, EF Core, Refit, Blazor, MAUI) no cabe en una guía que se sigue a mano. Hay que decidir qué subconjunto se construye y ejecuta de verdad, y declarar lo que queda como fragmento ilustrativo.

**T-03 — «No inventar» vs. afirmaciones heredadas.** La guía actual afirma versiones y licencias (MediatR 12, AutoMapper, .NET 9, Refit «genera la implementación en compilación») sin fuente. Cada una se verifica o se retira.

**T-04 — Recomendación dogmática vs. criterio.** La guía actual presenta Clean + CQRS + MediatR como la respuesta. Un documento que forma criterio tiene que decir cuándo **no** conviene (CRUD pequeño, una sola app), como se discutió en la conversación con el esquema página → servicio → EF.

---

## 3. Plan

1. Descomposición en núcleos (`Nucleos/`) + documento de cohesión.
2. Mesa, ciclo 1 (planificación): panel a ciegas sobre la guía actual y los núcleos; jurado resuelve DA-1..DA-4 y los hallazgos.
3. Laboratorio: construir y correr la solución de ejemplo en contenedor; capturar salidas (`Laboratorio/`).
4. Redacción íntegra del entregable.
5. Mesa, ciclo 2 (revisión del documento final): panel a ciegas, jurado, parches, verificación.
6. Cierre, changelog, commit.
