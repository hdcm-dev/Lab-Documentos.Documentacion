# Bitácora 01 — Contrato de entrada y encuadre

**Fecha:** 2026-09-17
**Prompt de origen:** `/LAB/Lab-Documentos.Documentacion/PROMPTs/Guides/07-Seguridad-Red-Windows-Guide/Crear-Seguridad-Red-Windows-Guide.md`
**Marco de ciclo:** `/IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md`
**Norma de estilo documental:** `/LAB/Lab-Documentos/Guides/UX-UI-Guide/UX-UI-Guide.md`

---

## 1. Contrato de entrada (§2 del marco)

```yaml
objeto:
  artefacto: documentación (guía de estudio)
  ruta/id: /LAB/Lab-Documentos/Guides/Seguridad-Red-Windows-Guide/Beginning-Security-Windows-Network-Guide.md
  version: 0 (archivo existente, vacío, creado 2026-09-17 12:23)
  capas_derivadas: []   # no hay artefactos que dependan de este todavía
objetivo: >
  Que una persona sin conocimientos previos de redes ni de sistemas operativos pueda auditar
  un servidor Windows dentro de una red Windows administrada con vicios, reconocer síntomas
  y rastros de intrusión, y entender los resultados de las pruebas que ejecuta.
restricciones_duras:
  - Lector sin experiencia previa: todo término se define antes de usarse.
  - Lenguaje claro sin perder el tecnicismo; prohibido el registro coloquial.
  - Documento autocontenido, no delta: no puede depender de otra guía para entenderse.
  - Estructura jerárquica con índice, definiciones, ejemplos, snippets y gráficos mermaid donde aporten.
  - Preguntas guía con respuestas explicativas, formadoras de criterio.
  - Cada comando debe declarar qué se espera ver y cómo interpretarlo.
  - No inventar información; toda afirmación respaldada por evidencia verificable.
  - Secciones finales sobre pentesting con herramientas reales de la industria y reproducción práctica.
decisiones_cerradas:
  - Idioma español; norma bibliográfica APA 7 (por herencia de UX-UI-Guide.md).
  - Un único documento entregable en la ruta indicada.
  - Prioridad a las herramientas nativas del sistema operativo; el tooling externo se presenta después.
fuera_de_alcance:
  - Respuesta a incidentes contractual o legal en jurisdicción concreta.
  - Configuración productiva de un SIEM comercial.
  - Desarrollo de exploits propios.
umbral_de_calidad: bloquean el cierre S1 y S2
presupuesto: { ciclos_max: 2, hallazgos_max_por_especialista: 7 }
```

### 1.1 Campos ausentes en el prompt y supuestos declarados

El marco (§10.1) obliga a resolver los faltantes con supuestos declarados, no con preguntas al usuario.

| Campo ausente | Supuesto adoptado | Fundamento |
|---|---|---|
| Versión de Windows Server objetivo | Windows Server 2016 en adelante; se marca lo que cambia en 2012 R2 | Es el piso donde existen PowerShell 5.1, `Get-NetTCPConnection` y la auditoría avanzada por GPO |
| Perfil del lector | Persona técnica adyacente (estudiante, administrativo con acceso al servidor) sin formación en redes | El prompt dice "sin conocimientos de redes y sistemas operativos" pero le pide ejecutar comandos en un servidor |
| Disponibilidad de laboratorio | El lector puede montar máquinas virtuales | Sin laboratorio no puede practicar sin riesgo; se agrega un capítulo de laboratorio |
| Autorización para pentesting | El lector opera sobre infraestructura propia o con autorización escrita | Sin ese supuesto la sección de pentesting sería inadmisible |
| Idioma de la interfaz de Windows | Se documentan nombres en español e inglés cuando difieren | El entorno del lector puede estar en cualquiera de los dos |

---

## 2. Tensión detectada en el contrato (para elevar a la mesa)

**T-01 — Lector sin conocimientos vs. servidor productivo comprometido.** El prompt pide una guía para alguien
sin experiencia, aplicada a un servidor con sospecha de intrusión activa. Ejecutar exploración sobre un sistema
comprometido por parte de un principiante puede destruir evidencia y alertar al intruso. La guía no puede
ignorarlo: necesita una sección de "reglas de no daño" antes del primer comando, y la práctica debe
canalizarse a un laboratorio.

**T-02 — "No inventar información" vs. "resultados esperados".** No hay un Windows disponible en el entorno de
redacción para capturar salidas reales. Toda salida mostrada debe rotularse explícitamente como ilustrativa
(forma de la salida y significado de cada columna), y no presentarse como captura de una corrida real.
Esta restricción se declara dentro del propio documento entregable.

**T-03 — Pentesting en una guía para principiantes.** Las herramientas ofensivas de la industria son de doble
uso. El tratamiento debe ser metodológico y reproducible en laboratorio, con el encuadre de autorización por
delante, no un recetario aplicable a la red de producción del lector.

---

## 3. Plan de trabajo

1. Descomposición conceptual en núcleos (`OUTPUTs/Nucleos/`) + documento de cohesión.
2. Registro de convocatoria de la mesa (`OUTPUTs/Mesa/`).
3. Redacción del entregable.
4. Panel a ciegas sobre el entregable, jurado, parches, verificación.
5. Bloque de cierre.
