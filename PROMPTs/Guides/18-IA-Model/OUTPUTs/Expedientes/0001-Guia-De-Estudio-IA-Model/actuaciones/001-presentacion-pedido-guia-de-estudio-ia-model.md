# Presentación — pedido del PO: guía de estudio sobre modelos de IA generativa/NLP

| Campo | Valor |
| --- | --- |
| Tipo | presentacion |
| Fecha | 2026-11-07 |
| Autor | Product Owner |
| Corrige | — |

El Product Owner presenta el caso mediante un archivo de prompt. Se asienta su contenido completo, byte a
byte, como testimonio. El archivo original no está versionado en `origin/main` (base `2c68e21`): su copia,
con la huella del archivo tal cual (sin salto de línea final), es la evidencia 001.

```testimonio

# Tool-Prompt — Creación guía de estudio sobre modelos de IA y temas asociados

> **Invocación**:
> - ultracode leer y ejecutar `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Guides/18-IA-Model/01-Crear-Study.Guide.md`
>
> Overview: Creación guía de estudio sobre modelos de IA y temas asociados

---

## Contexto

  Es necesario construir Una guía de estudio práctica pensada para quien nunca a visto el tema y que tambien incluya ejemplos los pasos necesarios para montar modelos, descargarlos, entrenarlos, entender las arquitecturas que hay, conceptos como transformers, que operan, metricas, motor de inferencia, y toda los conceptos relacionadas que hacen al conocimiento de la tematica de procesamiento de lenguaje natural IA generativas, modelos IA generativas, modelos multimodales, arquitecturas, base de datos vectoriales, terminos asociados. Actualmente tenemos funcionando modelos open sorce con el modelo. Actualmente tenemos corriendo diferentes modelos de qween.



## Objetivo

  Iniciar a aquien a un estudiante que aun no conoce del tema, y transferir experiencia teorica -práctica del tema 

## Solicitudes 

  Elaborar una guía en `/LAB/Lab-Documentos/Lab-Documentos/Guides/IA/IA-Model/IA-Model-Guide.md`, incluir ejemplos prácticos, definiciones, gráficos, cuadros comparativos explicativos, preguntas guías formadoras de conceptos que formen criterio articuladas con respuestas explicativas y que realimenten el texto y ejemplos. Planifica primero el temario, luego elabora un borrado con los contenidos por temarios, evalua y reajusta el conjunto y luego por medio de la elección de los espcialistas y especilistas colaboradores que proveean información formen el contenido y su edición. Este material debe servir de consulta y tambien de referencia.

  Crea una mesa basada en los conocimientos: `IA/IA.Knowledge.Base/Knowledges/Knowledge-Mesa-Consulta-A-Un-Tercero.md` y `IA/IA.Knowledge.Base/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` , en esta mesa determinar que especialistas en el tema necesitas reclutar  y convocalos inclui analistas en sistemas y arquitectos de sistema y modelos IA, editores de material bibliograficos, académicos y de libros, y tambien publicadores cientificos, bitacoristas para que ayuden ante consulta de avances e historial por parte de los subagentes, y evalua los mejores especialistas que requieras. A la mesa presentale el contexto, objetivos y las soliticitudes junto con las reglas dadas. La mesa debería abrir los expedientes si se requiere tal seguimiento. Que se debata la estructuración de los contenidos y el mejor enfoquen. Los investigadores especializados pueden ensayar y realizar todas las pruebas que sean necesarias, que se armen expedientes, se presenten y evaluen los resultados ante la mesa y los especialistas. Es importante basarse en las tendencias del mercado y los estandares de la industria.

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
    
    Para poder cumplir con esta regla aproyate en ir generando registros que puedas retomar y evaluar markdowns en `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Guides/18-IA-Model/OUTPUTs/Bitacoras`

  - No inventar información. 

  - Toda afirmación debe estar respaldada por evidencia verificable.

## Framework

### Profile

  Aplicar:
  - `/IA/IA.Prompts/PromptFramework/Profiles/Study-Guide-Documentation.md`
  
```

| Campo | Valor |
| --- | --- |
| Canal | Archivo en el repositorio: `PROMPTs/Guides/18-IA-Model/01-Crear-Study.Guide.md` (clon de trabajo del PO; sin versionar en `origin/main` a la apertura) |
| Fecha-hora | 2026-11-07 08:20 -0300 |
| Huella | `4e83fed9bc9f229e2ea4861756cea99531313a28e485e4b34e4249c9a4ed18f6` |

El pasaje es un **pedido** (fuente de intención, `Rule-Expediente.md` §3.5): pasa a ancla E4 cuando quede
asentado como decisión cerrada o restricción dura en el contrato de entrada de la mesa. La huella es la del
bloque tal como lo extrae el comando E-8 de `Rule-Expediente.md` §6 (líneas terminadas en LF, con el salto
final); difiere de la del archivo original, que no termina en salto de línea y figura en la evidencia 001.

Comando usado para la huella del bloque (equivalente a la extracción de E-8 sobre este folio):
`{ cat PROMPTs/Guides/18-IA-Model/01-Crear-Study.Guide.md; printf '\n'; } | sha256sum`

Sigue: providencia con el contrato de entrada · presidencia de la mesa
