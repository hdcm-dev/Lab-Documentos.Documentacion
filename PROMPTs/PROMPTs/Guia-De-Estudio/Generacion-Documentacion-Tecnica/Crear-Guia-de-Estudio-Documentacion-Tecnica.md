# Crear guía de estudio — Documentación técnica

> **Invocación**:
> - `Lee y ejecuta /IA/IA.SDD.Documentacion/PROMPTs/Guias-Estudio/Generacion-Documentacion-Tecnica/Crear-Guia-de-Estudio-Documentacion-Tecnica.md`
> Overview: generación de guía de estudio sobre documentación técnica de software

---

# Contexto

La temática es la **documentación técnica de software**: tanto su comprensión como su elaboración, de modo que una pieza de software pueda ser operada, evolucionada o reconstruida por otros actores de la cadena de desarrollo.

El catálogo de tipos de documentación técnica a cubrir está en `/IA/IA.SDD.Documentacion/PROMPTs/Generacion-Documentacion-Tecnica/Inputs/Tipos-De-Documentacion-Tecnica.md`.

No existe todavía un cuerpo documental que ordene estos tipos, los relacione con las situaciones reales de un proyecto y permita a un lector formar criterio sobre cuál producir en cada caso.

---

# Objetivo

Existe en `/IA/IA.SDD.Documentacion/Guias-de-Estudios/Documentacion-Tecnica` una guía de estudio completa que permite a un lector:

- entender qué es cada tipo de documentación técnica, qué problema resuelve y qué no resuelve;
- ubicarse en una situación concreta de proyecto y saber qué documentación generar o consultar;
- leer e interpretar especificaciones ajenas, y describir software propio con el artefacto adecuado;
- formar criterio para intervenir en cada tema según el rol que ocupe.

---

# Solicitudes

## Marco de referencia

1. Definir los **escenarios** del dominio y dejarlos en un documento propio: desarrollo de software nuevo, migración a otro lenguaje o plataforma, evaluación de software existente con acceso al código, y evaluación de un producto solo desde afuera (navegando el sitio, relevando funcionalidades y características).
2. Definir los **contextos** en documento propio: desarrollo web, backend y soluciones fullstack.
3. Definir los **actores** que intervienen (QA, arquitecto de software, analista, desarrollador, product owner, entre otros): funciones, áreas, responsabilidades y alcance, con tablas y preguntas guía sobre hasta dónde llega cada uno.

## Cuerpo documental

4. Un documento por cada entrada de la **tabla** de tipos de documentación técnica del catálogo referenciado (27 en total, de Vision Document a RFC), siguiendo la estructura de documento temático del Profile y explicando en cada uno qué aporta ese tipo en cada escenario y cómo cambia según el contexto.
5. Los artefactos que el catálogo menciona solo dentro de su agrupación práctica y no figuran en la tabla —casos de uso, reglas de negocio, coding standards, git workflow, CI/CD, disaster recovery, tutoriales, FAQ, guías rápidas— se tratan como secciones dentro del documento de la familia que los contiene, no como documentos propios.
6. Conservar las siete familias del catálogo (visión, análisis, arquitectura, diseño, operativa, desarrollo, usuarios) como agrupación de la guía: una carpeta o índice por familia, con la pregunta que responde cada una.
7. Una serie de documentos sobre **métodos ágiles** (Scrum, Canvas y los que correspondan): en qué consiste cada uno, en qué se diferencian, criterios para elegir entre ellos y cómo se aplican en cada escenario y contexto.
8. Una serie de documentos sobre **modelos de arquitectura**: microservicios, hexagonal, monolítico, modelo de capas, cliente-servidor. Ordenar los conceptos, relacionarlos entre sí y vincular cada modelo con la documentación que exige.
9. Un documento sobre **UX, UI y flujo de usuario**: qué herramientas documentales existen, qué metodologías las acompañan y cómo se integran con el resto del marco documental.
10. Un documento sobre **Spec-Driven Development (SDD)** aplicado a la generación de código asistida por IA, y su integración con los demás artefactos de la guía.

## Mapa y cierre

11. Un **mapa conceptual** con tablas de entrada: por escenario (qué documentación aplica), por contexto (qué documentación interviene) y por artefacto (definición breve más un par de preguntas que ayuden a saber cuándo aplica y qué describe).
12. Generar `/IA/IA.SDD.Documentacion/Guias-de-Estudios/Documentacion-Tecnica/README.md` con la tabla de contenido de todo lo generado y la ruta de lectura sugerida.
13. Revisar la guía completa contra el mapa, detectar inconsistencias, huecos y solapamientos, preparar un plan de mejoras y aplicarlo.

## Contenido transversal

14. En todos los documentos: definiciones, ejemplos concretos por escenario y contexto, preguntas guía formadoras de criterio, diagramas Mermaid y anexos con plantillas comentadas.
15. Usar como referencia para los ejemplos, cuando corresponda: .NET C#, Blazor con páginas interactive server, ASP.NET MVC y .NET MAUI con patrón MVVM.
16. Referenciar estándares y prácticas de la industria, anexando extractos cuando aporten.

---

# Restricciones

- Escribir únicamente dentro de `/IA/IA.SDD.Documentacion/Guias-de-Estudios/Documentacion-Tecnica`. No modificar el catálogo de tipos ni ningún componente del Prompt Framework.
- Del catálogo de tipos, tomar la tabla y la agrupación en siete familias. Ignorar su sección final sobre HomeHub: es un caso particular ajeno al marco conceptual y sus ejemplos no deben aparecer en la guía.
- Todo documento temático debe cruzarse con los escenarios y contextos definidos en el marco de referencia: no incorporar temas que queden fuera de él.
- No duplicar contenido entre documentos: si un concepto ya está desarrollado en otro, referenciarlo.
- No inventar estándares ni atribuir prácticas a fuentes que no se hayan verificado.
- No realizar commit, push ni pull request.
- Investigar las fuentes que hagan falta para sostener la calidad, sin límite de tiempo ni de tokens, dejando el avance en estado retomable ante cortes por consumo.

---

# Framework

## Profile

Aplicar:

- `/IA/IA.Prompts/PromptFramework/Profiles/Study-Guide-Documentation.md`
