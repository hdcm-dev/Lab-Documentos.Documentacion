# Tool-Prompt — Crear Guide

> **Invocación**: Leer y ejecutar `/LAB/Lab-Documentos.Documentacion/PROMPTs/Guides/06-Seguridad-Red-Windows-Guide/Crear-Seguridad-Red-Windows-Guide.md`
>
> **Overview**: Crear guía de estudio para auditar seguridad en red windows.

---

## Contexto

  Tengo una red windows y sospecho que tengo intrusión y estan borrando los logs, necesito saber que mecanismos me permitan encontrar fugas de seguridad o intrusiones. Por ejemplo, si existen conexiones activas como puedo pueda revisar o tener chanse de encontrar indicios de que estoy siendo intrusado en mis sistemas?

  En base al contexto reciente, se necesita crear una guía de estudio que permita a una persona sin conocimientos de redes y sistemas oeprativos auditar e investigar fallos de seguridad en un servidor dentro de una red windows.


---

## Objetivos

  Generar una guía de estudio para quien comienza en auditoria de seguridad de un servidor windows dentro de un red windows con vicios en su administración y problemas sospechados de intrusión y adquirir las habilidades para reconocer síntomas o rastros de intrusión y/o anormalías propias de intrusiones en el sistema.

---

## Solicitudes
  
  1. Crear una guía de estudio que permita a una persona sin conocimientos de redes y sistemas oeprativos auditar e investigar fallos de seguridad en un servidor dentro de una red windows. La guía debe servir definiones, ejemplos y explicaciones, comandos que se puedan probar y de los resultados esperados el como analizarlos y entenderlos, todo en un lenguaje claro sin perder el tecnisimos y sin caer en un lenguaje coloquial, siempre teniendo en cuenta que el lector no tiene experiencia en este ambito. El relato debe permitir a un persona seguir la guía entendiendo los conceptos y al mismo tiempo hacer pruebas sobre el servicio y bajo esos conceptos entender los resultados que va entendiendo. El documeto dejalo en `/LAB/Lab-Documentos/Guides/Seguridad-Red-Windows-Guide/Beginning-Security-Windows-Network-Guide.md`

  El documento solicitado pretende ser una guía base para alguien que quiere diagnosticar un sistema con las herramientas propias del sistema viendo sintomas o anomalias, Al final de este documento agrega secciones explicativas como hacer pentesting, toma algunas herramientas de la industria para ilustrar el tema y poder reproducir un pentesting

  Re editar el prompt basado en este prompt base: `/IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md`, y en base al contexto, reglas, objetivos y solicitudes y debe plantear a la mesa el caso, la mesa debe estar formada por expertos en didactica, en edición de material bibliografico y seguridad informática en redes windows a modo que revisen la documentación generada, analiza si necesitas un experto mas. La mesa debe volver a analizar el documento una vez finalizado y hacer las correcciones pertinentes en edición y compresión ajustando su coherencia. La mesa puede llevar sus apuntes, borradores, debates y precompilaciones que luego serán parte de la edición del documento final en `/LAB/Lab-Documentos.Documentacion/PROMPTs/Guides/06-Seguridad-Red-Windows-Guide/OUTPUTs`

---

## Reglas
  - Los documentos markdown de documentación deben estar organizados en secciones jerárquicas con índices. Deben incluir definiciones, explicaciones, ejemplos claros y en cuando sea necesario gráficos mermaid. Deben ser autocontenidos, no delta. Debe tener ejemplos explicaciones, snipped de código representativos, preguntas guías acompañadas de respuestas explicativas que sean formadoras de criterios y que permitan o sirvan al lector identificar en que caso se aplica que cada concepto vertido en el documento. 
  - Aplicar: `/LAB/Lab-Documentos.Documentacion/Guides/UX-UI-Guide/UX-UI-Guide.md`

  - Aplica una estrategia de descomposición conceptual sobre la totalidad del prompt. 
  Identifica y agrupa las ideas que presenten una relación temática, semántica o de  dependencia fuerte, formando núcleos conceptuales coherentes. No fragmentes el  contenido únicamente por extensión o por párrafos: la unidad de segmentación debe
  estar determinada por la afinidad y dependencia entre las ideas.

  Aborda el análisis y la planificación por estos núcleos conceptuales o ejes  temáticos, documentando cada uno en un documento Markdown independiente. Mantén además un documento de cohesión global que describa las relaciones, dependencias, referencias y vínculos existentes entre los distintos núcleos.

  La segmentación debe permitir trabajar cada eje con mayor precisión sin perder  contexto ni relaciones con los demás. Cada núcleo debe poder analizarse, planificarse y validarse de manera relativamente independiente, pero debe conservarse la trazabilidad necesaria para integrarlo posteriormente en una solución global.

  Una vez abordados los distintos núcleos conceptuales, realiza una fase de integración en la que se consoliden sus resultados, se resuelvan dependencias o contradicciones entre ellos y se reconstruya el modelo completo.

  El objetivo de esta estrategia es transformar un prompt de gran volumen y alta  complejidad en un conjunto de unidades conceptuales manejables, manteniendo entre ellas una estructura de cohesión, dependencia y trazabilidad que permita presentar cada eje a la mesa evaluadora y planificadora y, finalmente, integrarlos en un todo coherente.
   
  Para poder cumplir con esta regla aproyate en ir generando registros que puedas retomar y evaluar markdowns en `/LAB/Lab-Documentos.Documentacion/PROMPTs/Guides/06-Seguridad-Red-Windows-Guide/OUTPUTs/Bitacora`

  - No inventar información. 
  - Toda afirmación debe estar respaldada por evidencia verificable.


