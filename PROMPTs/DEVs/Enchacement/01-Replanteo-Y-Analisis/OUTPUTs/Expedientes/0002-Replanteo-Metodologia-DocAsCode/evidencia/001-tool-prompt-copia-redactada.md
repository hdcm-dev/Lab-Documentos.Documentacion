Método: copia del tool-prompt con `cp -p` y redacción S2 de dos tramos con `sed` (ver nota de origen)
Fecha-hora: 2026-10-26T14:45-03:00
Quién: presidencia de la mesa (despacho P00)

# Evidencia 001 — Tool-prompt del caso, copia redactada (S2)

> **Nota de origen.** Copia del archivo
> `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/DEVs/Enchacement/01-Replanteo-Y-Analisis/Replanteo-Y-Analisis.md`
> tomada el 2026-10-26 (modificado por última vez 2026-10-26 10:20:18 -03:00; 68 líneas —`wc -l` da 67—, 6992 bytes, sin salto de
> línea final). **Es una copia redactada, marcada como tal** (`Rule-Expediente.md` §3.6 y §3.8, clase «dato de un
> repositorio privado»): el original nombra el servicio de notificaciones push, que es privado. Se reemplazaron
> exactamente dos tramos y nada más:
>
> | Línea | Tramo original | Reemplazo |
> | --- | --- | --- |
> | 18 | ruta del `ia-db/README.md` del repositorio privado | `` `<destino privado: SDD-B>/ia-db/README.md` `` |
> | 30 | nombre del servicio entre acentos graves | `` `<SDD-B>` `` |
>
> El original byte a byte queda fuera del versionado en `evidencia/local/001-tool-prompt-original.md`, con huella
> SHA-256 `101e1bc4f8c933bb64d77a88e37f13d50ee49539b488b18bf6bd0bb256e826aa` (`sha256sum`, 2026-10-26). Ortografía,
> espacios y orden se conservan sin corregir; como el original no termina en salto de línea, se agregó uno antes del cerco de cierre. Las líneas de la copia coinciden una a una con las del original: la
> línea N de abajo es `TP:N`.

---

```text
# Tool-Prompt — Replanteo y analisis sistema de documentación DocAsCode

> **Invocación**:
> - ultracode leer y ejecutar `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/DEVs/Enchacement/01-Replanteo-Y-Analisis/Replanteo-Y-Analisis.md`
>
> Overview: Replanteo y analisis sistema de documentación DocAsCode

---

## Contexto

  Leer `/LAB/Lab-E2E.WebBlazor/Lab-E2E.WebBlazor.Documentacion/ia-db/README.md` son ejemplos, referido al proyecto `MovilidadUrbana.MAUI`

  Partiendo del desarrollo actual sobre lo que es materia de documentación a usuario de sistema, su diseño, desarrollo e implementación contamos con esto: 
   `/LAB/Lab-Documentos/Lab-Documentos/Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Sistema-Documentador-Tecnico-Guide.md`
  acompañado de ejemplos y/o demostración en `/LAB/Lab-Documentos/Lab-Documentos/Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Examples`.

  Se hace neceario investigar y establecer métodlogias de diseño, implementación e integración en  los sistemas. Actualmente se cuentan `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/ia-db/README.md`, el cual tiene su propio marco SDD de diseño asistido por IA y por otro lado tenemos `<destino privado: SDD-B>/ia-db/README.md` con su propio SDD; pero ambos se basan en agentes orquestadores y en conocimientos que pueden compartir.

  Para crear una metodología común de como analizar requerimientos documentales, diseño, implementación e integración usando DocAsCode queda entender que conviene hacer, si tener un repositorio dedicado a la documentación con su propio ciclo evolutivo o bien estar integrado en el mismo repositorio de codigo. Y aquí surgen problemas de desfase de versionado, y coordinación. Seguramente la industria ya tiene resuelto el abordaje metodologico de esta cuestión. Con la aparición de los agentes IA, integración con sistema multiagenticos, no solo son agentes humanos que accederan a esta documentación, así que hace falta un estudio profundo y se debe enriquecer la guía `Sistema-Documentador-Tecnico-Guide.md` y los ejemplos/demos anexados.
   
---

## Ojetivos

  Definir una metodlogía clara en evaluarción de requerimientos, analisis, diseño, implementación e integración de documetnación técnica de sistemas.

## Solicitudes

  - Analizar los temas planteados en el contexto y objetivos, las diferentes estrategias en base  a los sistemas que venimos cubriendo. Se puede enriqueser la guía actual, crear demostraciones y ejemplos (podes montar una mini demo basado en `MovilidadUrbana.MAUI` para usarlo de referencia inicial) y luego, se puede empezar una prueba piloto en con `Geometria` establecer un conocimeinto y  finalmente aplicarlo a `<SDD-B>` mejorando los agentes orquestadores de ambos para ser aplicado luego en el diseño de nuevos sitemas.

  - Es necesaario primero entender como se resuelve en la industria los problemas planteados en el contexto, y tener en cuenta que en esta tarea documental puedan intervenir de forma automática la IA o bien que los agentes humanos entiendan el flujo de trabajo para poder intervenir o realizar sus aportes.
   
  - Configura el wofklow con este runner de github :  `runs-on: [self-hosted, i7infra-dev]`
  
  - Crea una mesa basada en los conocimientos: `KB-privada/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` y `KB-privada/Knowledges/Knowledge-Mesa-Consulta-A-Un-Tercero.md` , en esta mesa determinar que especialistas en el tema necesitas reclutar  y convocalos inclui analistas en sistemas y arquitectos en software .NET, especialistas en analisis el cúal se le pida criterios de decisión y analisis de las decisiones, cita tambien academicos en edición de material bibliografico para consultar y crear ejemplos y material de consulta. A la mesa presentale el contexto, objetivos y las soliticitudes junto con las reglas dadas. La mesa debería abrir los expedientes si se requiere tal seguimiento. Que se debata la mejor forma, que consulten los estandares, los especialistas deben trazar una arquitectura clara, puede alternativas, pero se deben buscar las ventajas de simplicidad y practicidad, escalibilidad. Los investigadores especializados pueden ensayar y realizar todas las pruebas que sean necesarias, que se armen expedientes, se presenten y evaluen los resultados ante la mesa y los especialistas. Es importante basarse en las tendencias del mercado y los estandares de la industria.

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
    
    Para poder cumplir con esta regla aproyate en ir generando registros que puedas retomar y evaluar markdowns en `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/DEVs/Enchacement/01-Replanteo-Y-Analisis/OUTPUTs/Bitacoras`

  - No inventar información. 

  - Toda afirmación debe estar respaldada por evidencia verificable.

## Framework

### Profile

  Aplicar:
  - `/IA/IA.Prompts/PromptFramework/Profiles/Study-Guide-Documentation.md`
```
