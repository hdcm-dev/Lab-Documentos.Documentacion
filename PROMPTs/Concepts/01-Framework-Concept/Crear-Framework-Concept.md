# Tool-Prompt — Crear modelo conceptual de framework 

> **Invocación**:
> - ultracode Leer y ejecutar `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Concepts/01-Framework-Concept/Crear-Framework-Concept.md`
>
> Overview: Crear modelo conceptual de framework 

---

## Contexto

  Leer `/LAB/Lab-Documentos/Lab-Documentos/Concepts/Framework-Concept/Framework-APP.md`, trata sobre una idea de aplicación movil en .net construida con paginas .net  blazor hibridas  en .NET MAUI.

  Actualmente el equipo tiene problemas al introducir un PR sobre una rama estable , al no dispararse pruebas automatizadas puede romper funcionaldiades que ya funcionaban correctamente. La necesidad pasa por tener prodicimientos claros en los PR y en los conceptos de integración  y versionado del producto

  Leer `/LAB/Lab-E2E.WebBlazor/Lab-E2E.WebBlazor.Documentacion/ia-db/README.md` son ejemplos, referido al proyecto `MovilidadUrbana.MAUI`

  Se hace necesario contar con un modelo de aplicación que permita aplicar actualizaciones desde el servidor sin pasar por el ciclo de actualización rigido que imponen los store o distribuidores de aplicaciones como play store de google o app connect de apple. Sería muy intersante poder aplicar actualizaciones dinamicas de tal forma que cuando el usuario abre la aplicación esta aplicación solicita bajar las actualizaciones de forma automatica

---

## Objetivos

   Se busca establecer un framwork para construir aplicacionet .net en maui conforme al contexto planteado

---

## Solicitudes

  - Desarrollar una guía instructiva academica enfocada a un desarrollador sin experiencia que describa la tecnica en `/LAB/Lab-Documentos/Lab-Documentos/Concepts/Framework-Concept/Developer-Guide.md`  y en base a esto construir Construir ejemplo de demostración en `/LAB/Lab-Documentos/Lab-Documentos/Concepts/Framework-Concept/Demo` que a su vez sirva esta demo para ilustrar con ejemplo a dicha guía. Tomar base para la construcción de la demo al proyecto `MovilidadUrbana.MAUI`.
 
  - Configura el wofklow con este runner de github :  `runs-on: [self-hosted, i7infra-dev]`

  - Toda la documentación generarla en `/LAB/Lab-Documentos/Lab-Documentos/Concepts/Framework-Concept`

  - Crea una mesa basada en los conocimientos: `<base de conocimiento>/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` y `<base de conocimiento>/Knowledges/Knowledge-Mesa-Consulta-A-Un-Tercero.md` , en esta mesa determinar que especialistas en el tema necesitas reclutar  y convocalos inclui analistas en sistemas y arquitectos en aplicaciones moviles en MAUI .NET, especialistas en analisis el cúal se le pida criterios de decisión y analisis de las decisiones, cita tambien academicos en edición de material bibliografico para consultar y crear ejemplos y material de consulta. A la mesa presentale el contexto, objetivos y las soliticitudes junto con las reglas dadas. La mesa debería abrir los expedientes si se requiere tal seguimiento. Que se debata la mejor forma, que consulten los estandares, los especialistas deben trazar una arquitectura clara, puede alternativas, pero se deben buscar las ventajas de simplicidad y practicidad, escalibilidad. Los investigadores especializados pueden ensayar y realizar todas las pruebas que sean necesarias, que se armen expedientes, se presenten y evaluen los resultados ante la mesa y los especialistas. Es importante basarse en las tendencias del mercado y los estandares de la industria.

---

## Reglas

  - Los documentos markdown de documentación deben estar organizados en secciones jerárquicas. Deben incluir definiciones, explicaciones, ejemplos claros y en cuando sea necesario gráficos mermaid. Debe ser autocontenida y no delta. Los documentos creados deben tener índices.

  - Vos y toda la mesa y sus subagentes debe seguir el concepto a apliciar como estrategia de descomposición conceptual sobre la totalidad del prompt. 

    Identifica y agrupa las ideas que presenten una relación temática, semántica o de  dependencia fuerte, formando núcleos conceptuales coherentes. No fragmentes el  contenido únicamente por extensión o por párrafos: la unidad de segmentación debe
    estar determinada por la afinidad y dependencia entre las ideas.

    Aborda el análisis y la planificación por estos núcleos conceptuales o ejes  temáticos, documentando cada uno en un documento Markdown independiente. Mantén además un documento de cohesión global que describa las relaciones, dependencias, referencias y vínculos existentes entre los distintos núcleos.

    La segmentación debe permitir trabajar cada eje con mayor precisión sin perder  contexto ni relaciones con los demás. Cada núcleo debe poder analizarse, planificarse y validarse de manera relativamente independiente, pero debe conservarse la trazabilidad necesaria para integrarlo posteriormente en una solución global.

    Una vez abordados los distintos núcleos conceptuales, realiza una fase de integración en la que se consoliden sus resultados, se resuelvan dependencias o contradicciones entre ellos y se reconstruya el modelo completo.

    El objetivo de esta estrategia es transformar un prompt de gran volumen y alta  complejidad en un conjunto de unidades conceptuales manejables, manteniendo entre ellas una estructura de cohesión, dependencia y trazabilidad que permita presentar cada eje a la mesa evaluadora y planificadora y, finalmente, integrarlos en un todo coherente.
    
    Para poder cumplir con esta regla aproyate en ir generando registros que puedas retomar y evaluar markdowns en `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Concepts/01-Framework-Concept/OUTPUTs/Bitacoras`

  - No inventar información. 

  - Toda afirmación debe estar respaldada por evidencia verificable.

## Framework

### Profile

  Aplicar:
  - `/IA/IA.Prompts/PromptFramework/Profiles/Study-Guide-Documentation.md`