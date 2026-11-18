# Tool-Prompt — Edición del material creado que define framework

> **Invocación**:
> - ultracode Leer y ejecutar `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Concepts/01-Framework-Concept/04-Ajuste-Coherencia-Reedicion-Documentacion.md`
>
> Overview: Edición del material creado que define framework

---

## Contexto

  En resumen tenemos hasta ahora estos conceptos sobre nuestro nuevo framework:

  El framework quedo planteado bajo la combinación de tres categorías conocidas, y en la industria se describiría como **«app híbrida offline-first con actualizaciones OTA (live updates)»**:

  | Rasgo de lo que planteamos | Cómo se llama | Referentes que relevó la mesa |
  |---|---|---|
  | Cascarón nativo (MAUI) y pantallas web dentro de un WebView | **App híbrida** (*hybrid app*). En .NET, el pariente oficial es **Blazor Hybrid**, que trae las pantallas compiladas en el binario | Capacitor/Ionic, Cordova, BlazorWebView |
  | Las pantallas se cambian sin pasar por la tienda | **Actualizaciones OTA** (*over-the-air*), también llamadas **live updates**, **hot code push** o **code push** | Expo Updates (EAS Update), CodePush de Microsoft (retirado), Capawesome Live Update, Ionic Appflow Deploy |
  | Trabaja sin red, guarda y envía después | **Offline-first**, con un **outbox** para las escrituras pendientes | El ciclo de vida de los service workers de las **PWA** es el modelo de la regla «se activa en el próximo arranque» |

  y se añadieron temas secundarios quedando como

  | Principal | Secundario |
  |---|---|
  | App híbrida | Estado de red e internet |
  | Actualizaciones OTA firmadas, con rollback | Autenticación del dispositivo (huella, PIN, patrón) y Keystore |
  | Offline-first con outbox | Contrato del puente versionado (P3) y capacidades del dispositivo por catálogo |`

---

## Objetivos

   Editar los contenidos generados y armonizar con respecto a ejemplos y demo construida.

---

## Solicitudes

  A partir de esto y sobre la documentación generada en

  `/LAB/Lab-Documentos/Lab-Documentos/Concepts/Framework-Concept`

  solicitar a la mesa de expertos una revisión de dichos documentos generados, incluir expertos en revisión bibliografica y edición de material bibliografico

  1- Coherencia de lo redactado - y que sea consecuente y congruente con las ejemplificaciones.

  2- que los editores editen un documento unificado siguiendo:
   
  ``` 
  Los documentos markdown de documentación deben estar organizados en secciones jerárquicas. Deben incluir definiciones, explicaciones, ejemplos claros y en cuando sea necesario gráficos mermaid. Debe ser autocontenida y no delta. Los documentos creados deben tener índices.
  ```

  Que este documento reuna los documentos individuales que se han generado en `/LAB/Lab-Documentos/Lab-Documentos/Concepts/Framework-Concept/MAUI-Framework-Developer-Guide.md`

  Luego que se le aplique una ronda de revisión como si fuera un libro.

  Es importante que tenga un sección inicial que explique estos fundamentos que hemos basado el framework

  3-En base a estos los expertos se reunan para confeccionar un conocimiento en `/LAB/Lab-Documentos/Lab-Documentos/Concepts/Framework-Concept/Conocimientos`

  4- Añadir referencias y casos según lo que se ha relevado en la industria.

  Te dejo una guía para que trabajes en tu plan con los editores bibliograficos

  | Intervención               | Qué modifica                           |
  | -------------------------- | -------------------------------------- |
  | Edición de contenido       | Ideas, estructura y argumentos         |
  | Edición académica          | Rigor, fuentes y consistencia          |
  | Corrección de estilo       | Lenguaje y expresión                   |
  | Corrección ortotipográfica | Ortografía y convenciones tipográficas |
  | Diseño editorial           | Presentación visual y diagramación     |
  | Corrección de pruebas      | Errores de la versión diagramada       |


  Con `/LAB/Lab-Documentos/Lab-Documentos/Concepts/Framework-Concept/MAUI-Framework-Developer-Guide.md` , sus proyectos ejemplos y proyecto demo nos queda el material suficiente para que un grupo de desarrolladores compuestos por agentes IA o agentes humanos trabaje en una aplicación basada en los principios que hemos trabajo.


  Crea una mesa basada en los conocimientos: `IA/IA.Knowledge.Base/Knowledges/Knowledge-Mesa-Consulta-A-Un-Tercero.md` y `IA/IA.Knowledge.Base/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` , en esta mesa determinar que especialistas en el tema necesitas reclutar  y convocalos inclui analistas en sistemas y arquitectos en aplicaciones moviles en MAUI .NET, especialistas en analisis el cúal se le pida criterios de decisión y analisis de las decisiones, cita tambien academicos en edición de material bibliografico y libros para consultar y crear ejemplos y material de consulta. A la mesa presentale el contexto, objetivos y las soliticitudes junto con las reglas dadas. La mesa debería abrir los expedientes si se requiere tal seguimiento. Que se debata la mejor forma, que consulten los estandares, los especialistas deben trazar una arquitectura clara, puede alternativas, pero se deben buscar las ventajas de simplicidad y practicidad, escalibilidad. Los investigadores especializados pueden ensayar y realizar todas las pruebas que sean necesarias, que se armen expedientes, se presenten y evaluen los resultados ante la mesa y los especialistas. Es importante basarse en las tendencias del mercado y los estandares de la industria.

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