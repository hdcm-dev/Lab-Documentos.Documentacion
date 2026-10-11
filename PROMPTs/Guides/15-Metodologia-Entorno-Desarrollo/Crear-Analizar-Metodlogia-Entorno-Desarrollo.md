
# Tool-Prompt — Investigación

> **Invocación**:
> - ultracode leer y ejecutar `/LAB/Lab-Documentos.Documentacion/PROMPTs/Guides/15-Metodologia-Entorno-Desarrollo/Crear-Analizar-Metodlogia-Entorno-Desarrollo.md`
>
> Overview: Investigación

---

## Contexto


  Recientemente tuve este comentario en un fix:

  ```
   100 archivos .cs/.razor en cp1252 pasados a UTF-8 con BOM. Roslyn en Linux los lee
  como UTF-8: SGM.Core.Services no compilaba (identificador ÇoordenadaExtacta en
  BotonPanico_*.cs) y los textos con acentos salían con '?'. En Windows no cambia nada.
  ```
  Esto surge porque se desarrolla código mediante visualstudio en windows y al mismo tiempo en entorno linux. O bien construye en entornos devcontainer linux. 

  El tema es como mantener un criterio en lo que es el setcode del codigo fuente unificado para no tener commits con cambios de BOM. 

  Surge al mismo tiempo mantener una mecanica que permita congelar nugets y versiones de compiladores, sdk, no se si esto se puede hacer mediante el desarrollo por medio de contenedores, como se puede integrar esto en entornos donde los desarrolladores utilizan herramientas sobre plataformas windows y linux.

  Esto es super importante porque si se construye una pieza de codigo seria bueno saber con que entorno se ensamblo esa pieza de codigo.
  
---

## Solicitudes

  Analizar las estrategias de lo que proponer la industria actual para diferentes entornos de desarrollo .net , nodejs, python , y  en especial que sucede cuando se integran todos estos en una unica solución.

  Re editar el prompt basado en este prompt base: `/IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md`, y en base al contexto, reglas, objetivos y solicitudes y debe plantear a la mesa el caso, la mesa debe estar formada por expertos en didactica, en edición de material bibliografico, senior en .net, arquitectos en software y desarrolladores de código a modo que revisen la documentación generada, analiza si necesitas un experto mas. La mesa debe volver a analizar el documento una vez finalizado y hacer las correcciones pertinentes en edición y compresión ajustando su coherencia. La mesa puede llevar sus apuntes, borradores, debates y precompilaciones que luego serán parte de la edición del documento final debe quedar en `/LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md`

---

## Reglas

  - Los documentos markdown de documentación deben estar organizados en secciones jerárquicas con índices. Deben incluir definiciones, explicaciones, ejemplos claros y en cuando sea necesario gráficos mermaid. Deben ser autocontenidos, no delta. Debe tener ejemplos explicaciones, snipped de código representativos, preguntas guías acompañadas de respuestas explicativas que sean formadoras de criterios y que permitan o sirvan al lector identificar en que caso se aplica que cada concepto vertido en el documento. 

  - Aplica una estrategia de descomposición conceptual sobre la totalidad del prompt. 
  
    Identifica y agrupa las ideas que presenten una relación temática, semántica o de  dependencia fuerte, formando núcleos conceptuales coherentes. No fragmentes el  contenido únicamente por extensión o por párrafos: la unidad de segmentación debe estar determinada por la afinidad y dependencia entre las ideas.

    Aborda el análisis y la planificación por estos núcleos conceptuales o ejes  temáticos, documentando cada uno en un documento Markdown independiente. Mantén además un documento de cohesión global que describa las relaciones, dependencias, referencias y vínculos existentes entre los distintos núcleos.

    La segmentación debe permitir trabajar cada eje con mayor precisión sin perder  contexto ni relaciones con los demás. Cada núcleo debe poder analizarse, planificarse y validarse de manera relativamente independiente, pero debe conservarse la trazabilidad necesaria para integrarlo posteriormente en una solución global.

    Una vez abordados los distintos núcleos conceptuales, realiza una fase de integración en la que se consoliden sus resultados, se resuelvan dependencias o contradicciones entre ellos y se reconstruya el modelo completo.

    El objetivo de esta estrategia es transformar un prompt de gran volumen y alta  complejidad en un conjunto de unidades conceptuales manejables, manteniendo entre ellas una estructura de cohesión, dependencia y trazabilidad que permita presentar cada eje a la mesa evaluadora y planificadora y, finalmente, integrarlos en un todo coherente.
   
    Para poder cumplir con esta regla aproyate en ir generando registros que puedas retomar y evaluar markdowns en `/LAB/Lab-Documentos.Documentacion/PROMPTs/Guides/15-Metodologia-Entorno-Desarrollo/OUTPUTs/Bitcora`

  - No inventar información. 

  - Toda afirmación debe estar respaldada por evidencia verificable.

---

## Framework

### Profile

  Aplicar:
  - `/IA/IA.Prompts/PromptFramework/Profiles/Study-Guide-Documentation.md`
  