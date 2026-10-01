# Tool-Prompt — Crear Interactive Guide 

> **Invocación**: Leer y ejecutar `/LAB/Lab-Documentos.Documentacion/PROMPTs/Guides/06-Crear-Dot-NET-Arquitectura-Guide/03-Actividad-Interactiva.md`
>
> **Overview**: Desarrollar guia interactiva.

---

## Contexto

  En base a tu apunte , voy a ir leyendo tus conceptos, te voy a ir haciendo preguntas y refutando, vos me iras mejorando el apunte , utilizaras subagentes especializados en didactica, y en edición de libros para ir recolectando el material, que tus subagentes lleven sus notas en `/LAB/Lab-Documentos.Documentacion/PROMPTs/Guides/06-Crear-Dot-NET-Arquitectura-Guide/OUTPUTs` asi consulta y debanten entre ellos antes de actualizar el apunte.

  Mientras yo hago  una actividad práctica, esta va a estar basada en este apunte: `https://docs.google.com/document/d/1A80sKyEk1XlnOwxRyiZPeMgw3y6nYZrd/edit` yo iré leyendo y te pedire cosas y  te refutaré conceptos te pideré ayudas. Y por un lado con tus agentes en didactica y editores de material bibliografico podes ensamblar esa actividad y su desarrollo en `/LAB/Lab-Documentos/Guides/Dot-NET-Arquitectura-Guide/Dot-NET-Arquiectura-Interactive-Guide.md`

  Y por otro lado yo ire leyendo tu apunte: `/LAB/Lab-Documentos/Guides/Dot-NET-Arquitectura-Guide/Dot-NET-Arquitectura-Guide.md` y vos con tus subagentes irás mejorando ese punte.

  La actividad es una aplicación de escritorio, voy a hacer una versión basada en resapi, por lo tanto quiero me inicies la solución con un proyecto .net 10  .net con scalar instalado en `/LAB/Lab-Documentos/Guides/Dot-NET-Arquitectura-Guide/Interactive-Activities`, llamale la solución LaEstancia y el proyecto LaEstancia.WebAPI. no hagas lo demas solo la solución y el proyecto y el program, así yo empiezo a escribir los espacios de nombres y las clases 

  La experiencia va a ser interesante, quiero hacer algo interactivo con vos y tus agentes, podes si queres traerlo a martin fowler o algun otro crack del tema. Si necesitas llamar a la mesa para debatir conceptos y ediciciones que tus subagentes llamen a la mesa y planteen sus materiales y revisen el mejor entendimiento y conceptualización del tema siempre aportando definiciones claras y precesisas.



---

## Reglas

  - El documento markdown debe estar organizado en secciones jerárquicas con índices. Deben incluir definiciones, explicaciones, ejemplos claros y en cuando sea necesario gráficos mermaid. Deben ser autocontenidos, no delta. Debe tener ejemplos explicaciones, snipped de código representativos, preguntas guías acompañadas de respuestas explicativas que sean formadoras de criterios y que permitan o sirvan al lector identificar en que caso se aplica que cada concepto vertido en el documento. 

  - Aplica una estrategia de descomposición conceptual sobre la totalidad del prompt. 
  
    Identifica y agrupa las ideas que presenten una relación temática, semántica o de  dependencia fuerte, formando núcleos conceptuales coherentes. No fragmentes el  contenido únicamente por extensión o por párrafos: la unidad de segmentación debe estar determinada por la afinidad y dependencia entre las ideas.

    Aborda el análisis y la planificación por estos núcleos conceptuales o ejes  temáticos, documentando cada uno en un documento Markdown independiente. Mantén además un documento de cohesión global que describa las relaciones, dependencias, referencias y vínculos existentes entre los distintos núcleos.

    La segmentación debe permitir trabajar cada eje con mayor precisión sin perder  contexto ni relaciones con los demás. Cada núcleo debe poder analizarse, planificarse y validarse de manera relativamente independiente, pero debe conservarse la trazabilidad necesaria para integrarlo posteriormente en una solución global.

    Una vez abordados los distintos núcleos conceptuales, realiza una fase de integración en la que se consoliden sus resultados, se resuelvan dependencias o contradicciones entre ellos y se reconstruya el modelo completo.

    El objetivo de esta estrategia es transformar un prompt de gran volumen y alta  complejidad en un conjunto de unidades conceptuales manejables, manteniendo entre ellas una estructura de cohesión, dependencia y trazabilidad que permita presentar cada eje a la mesa evaluadora y planificadora y, finalmente, integrarlos en un todo coherente.
   
    Para poder cumplir con esta regla aproyate en ir generando registros que puedas retomar y evaluar markdowns en `/LAB/Lab-Documentos.Documentacion/PROMPTs/Guides/06-Crear-Dot-NET-Arquitectura-Guide/OUTPUTs/Bitacora-Editores`

  - No inventar información. 
  - Toda afirmación debe estar respaldada por evidencia verificable.

---

## Framework

### Profile

Aplicar:

  - `/IA/IA.Prompts/PromptFramework/Profiles/Study-Guide-Documentation.md`


