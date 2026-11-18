---
doc_id: BIT-GDC-00
doc_type: convocatoria
title: Guía de diseño conversacional · composición de la mesa y convenciones de estructura
status: vigente
origin: agent (coordinación)
last_review: 2026-11-11
traces: [REED-16 §8–§10, BIT-16-MESA-C1-01, BIT-16-05, GUIA-NET-IA v1.1.0 §0]
---

# Composición de la mesa y convenciones

Fuente: la mesa de la guía 16 (REED-16 §8, Ciclo-1/01-Convocatoria: 12 voces) y la estructura de la guía 16 v1.1.0. Se conservan los 12 roles y se suman los que pide el tema.

## 1. Roles

### 1.1 Núcleo permanente (se conserva)
| Rol | Encargo en esta guía |
|---|---|
| Requisitos | Cada pregunta del PO (criterio, por dónde empiezo, flujo, pasos del novato, sistema existente, sistema por desarrollar) y cada entregable por etapa tiene sección, plantilla y OA. |
| Verificación / QA | Toda afirmación con REF-nn verificada por WebFetch/WebSearch (fecha de consulta) o rotulada experiencia propia medida; grep de privacidad (OneSignal y marcas, clientes, Notions/GDA/MOVPARK, IPs, claves, modelo/servidor) en cero; anclas y mermaid. |
| Implementador ingenuo (fundido con desarrollador de código) | Un equipo sin experiencia lee de punta a punta y produce los entregables con las plantillas sin preguntar nada. |
| Abogado del diablo | Ataca la propuesta dominante («frontera por anillos», «todo con RAG», «el modelo redacta cifras», «la consola en primer plano sirve a todos»); entra último. |

### 1.2 Perfiles del PO (se conservan, adaptados)
| Rol | Encargo |
|---|---|
| Didáctica | Progresión de manual de trabajo, rutas por rol, preguntas guía con respuestas que forman criterio y dicen cuándo aplica cada concepto. |
| Edición bibliográfica | Jerarquía, índice, anclas estables, voz única rioplatense, Anexo de referencias, autocontención (no delta, no cita bitácoras). |
| Senior .NET | Snippets representativos (herramientas, catálogo de destinos, deeplink revalidado por permiso) coherentes con la guía 16 y sus versiones. |
| Experto en IA | RAG, tool calling, anclaje de la redacción, «No está en la ayuda», límites del modelo; sin nombrar modelo ni servidor. |
| Arquitectura | Dónde vive la consola en el sistema, frontera código/modelo (el código elige, el modelo redacta), puentes con la guía 16. |

### 1.3 Ad hoc heredados
| Rol | Encargo |
|---|---|
| AH-01 Seguridad LLM | Revalidar deeplink y datos por permiso/rol, aclaración entre cuentas, no prometer acciones que el software no hace, inyección. |
| AH-02 Evaluación LLM/RAG | Batería real x3, criterios de aceptación medibles, plan de medición (no-encontrado, votos con motivos cerrados, fuera de alcance, por intención, sin guardar texto). |
| Operación y entrega (postergado en la 16, entra ahora) | Telemetría de la frontera, ciclo de retroalimentación, privacidad de la medición. |

### 1.4 Nuevos por el tema
| Rol | Encargo |
|---|---|
| Diseño conversacional | Método de anillos de competencia, flujo de diseño, intenciones, desambiguación, reparación, preguntas sugeridas; contraste con guías de Google, Microsoft, NN/g. |
| UX writing | Voz y tono, primera explicación del término, mensajes de rechazo amable con ejemplos, chips y notas de métrica, glosario y sinónimos. |
| Accesibilidad | Lectores de pantalla en la consola, foco, alternativas textuales de gráficos (torta/barras), lenguaje claro, WCAG verificada. |
| Investigación de usuarios / dominio | Inventario de tareas y pantallas, vocabulario del inexperto, recorrido del panel como corpus; caso existente vs por desarrollar. |
| Visualización de datos | Regla torta/barras, top N + «Otras», totales con desglose ofrecido; cifras del código. |
| AH-03 Propiedad intelectual y privacidad editorial | Cero menciones de marcas registradas (el producto de referencia se describe como «un producto de referencia del mercado»), sin capturas con marca ni textos literales; separa guía pública y compañero privado. |

### 1.5 Órganos de proceso (sin cambios)
Relator (consolida, no vota); jurado de cinco (evidencia, impacto, costo/beneficio, coherencia histórica, riesgo; PROCEDE/NO_PROCEDE/INSUFICIENTE, mayoría ≥3, veto acotado del juez de riesgo); cuerpo auditor (texto exacto, capa, derivados, verificación, reversión); aprobación (APLICAR/MEJORAR_PLAN ≤2/NO_APLICAR/ESCALAR; corregir en la capa donde nació); relectura integral obligatoria de punta a punta. Reglas: informes a ciegas, ≤7 hallazgos + ≤3 «revisado y bien», cartas de mandato para ad hoc con tope 5, techo núcleo+5 por señal (perfiles del PO no consumen cupo, apartamiento declarado), apartamientos en el cierre.

## 2. Convenciones de estructura (verificables)
Ver la lista en la salida estructurada; resumen: front matter YAML; prólogo cap. 0 (0.0 TOC mermaid, 0.1 tabla única de OA, 0.2 rutas por rol, 0.3 qué necesitás, 0.4 patrón de capítulo y rótulos de evidencia, 0.5 mapa de plantillas/caso, 0.6 compañero privado, 0.7 anclas); Parte I principios P-n con razón; partes de lo general a lo particular; patrón por capítulo temático (definición, aplicación por escenario, ejemplo, decisión, preguntas guía ≤5 atadas a OA, criterios de calidad); caso PushDispatch como capítulo; cierre con autoevaluación; anexos plantillas, listas por rol, glosario, referencias REF-nn, versiones/fechas, lecturas, procedencia.
