# Mesa evaluadora — Registro de convocatoria (ciclo 1)

**Fecha:** 2026-09-18
**Artefacto bajo revisión:** `/LAB/Lab-Documentos/Guides/Arquitectura/Dot-NET-Arquitectura-Guide.md` (commit 063f4e9) y el plan de núcleos `OUTPUTs/Nucleos/`
**Marco:** `/IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §5.1

---

## 1. Barrido de señales (§5.1.b)

| Señal observable | Ubicación | Especialidad que activa |
|---|---|---|
| «permita a una persona sin conocimientos entender los conceptos» | Prompt, Contexto §1 | Didáctica |
| «lenguaje claro sin perder el tecnicismo… sin caer en lenguaje coloquial»; «secciones jerárquicas con índices» | Prompt, Contexto §1 y Reglas | Edición de material bibliográfico |
| Clean Architecture, capas, proyectos .NET, MediatR, EF Core, Blazor, MAUI | Guía vigente §1–§13 | Arquitectura .NET |
| «comandos que se puedan probar y de los resultados esperados» | Prompt, Contexto §1 | Verificación / QA (núcleo) |
| «No inventar información… evidencia verificable» | Prompt, Reglas | Verificación / QA (núcleo) |
| MediatR 12, AutoMapper, .NET 9, Refit, Scalar/Swagger en «Resumen de decisiones» | Guía vigente, última sección | Ecosistema y licenciamiento (ad hoc) |
| «guía base para quien está diseñando soluciones .NET desde cero… problema de la vida real» | Prompt, Contexto §2 | Requisitos (núcleo) |

## 2. Composición

### 2.1 Núcleo permanente

| Rol | Estado |
|---|---|
| Requisitos | CONVOCAR (automático) |
| Verificación / QA | CONVOCAR (automático) — evalúa qué del laboratorio es ejecutable y cómo se evidencia |
| Implementador ingenuo | CONVOCAR (automático) — opera como **lector novato** que nunca creó una solución .NET |
| Abogado del diablo | CONVOCAR (automático) |

### 2.2 Catálogo variable

| Rol | Voto | Resultado | Motivo |
|---|---|---|---|
| E-Didáctica | 5-0 | CONVOCAR | Pedido explícito del prompt |
| E-Edición bibliográfica | 5-0 | CONVOCAR | Pedido explícito del prompt |
| E-Arquitecto .NET | 5-0 | CONVOCAR | Pedido explícito; es el dominio |
| Interfaz / consumidor externo | 4-1 | NO_CONVOCAR | La API del ejemplo es didáctica, no pública; lo cubre el arquitecto |
| Seguridad y privacidad | 4-1 | NO_CONVOCAR | La autenticación JWT aparece como fragmento; no hay datos reales |

### 2.3 Agente ad hoc — el «experto más» que pide analizar el prompt

```yaml
agente_ad_hoc:
  id: AH-001
  nombre: Especialista en ecosistema .NET, versionado y licenciamiento de dependencias
  señal_que_lo_justifica:
    descripción: "La guía recomienda versiones y librerías de terceros (MediatR 12, AutoMapper, .NET 9, Refit) sin fuente; al menos dos cambiaron de licencia en 2025 según conocimiento previo no verificado"
    ubicación: "Guía vigente, sección «Resumen de Decisiones Tecnológicas» y §5"
  pregunta_que_responde: "¿Qué versiones y dependencias puede recomendar hoy la guía sin inducir a error, y con qué fuente primaria?"
  competencia: "Política de soporte de .NET, licencias y estado de mantenimiento de paquetes NuGet. NO opina sobre didáctica, redacción ni diseño de capas."
  evidencia_admisible: [E1, E2, E4]
  tope_hallazgos: 5
  se_disuelve_cuando: "Emite su informe del ciclo 1"
```

## 3. Reglas de trabajo del panel

- Informes a ciegas y en paralelo; cada uno en `Mesa/Ciclo-1/`.
- Máximo 7 hallazgos por especialista (5 el ad hoc), con nivel de evidencia E1–E4 o C.
- Cada uno declara hasta 3 cosas «revisadas y correctas».
- Lo que está fuera de mandato se emite como solicitud de convocatoria.
- Jurado: 5 funciones (evidencia, impacto, costo-beneficio, coherencia histórica, riesgo), votación por hallazgo; además resuelve DA-1..DA-4 y aprueba el índice del entregable (delegación del PO del 2026-09-14: «la propuesta mejor fundamentada queda aprobada»).
