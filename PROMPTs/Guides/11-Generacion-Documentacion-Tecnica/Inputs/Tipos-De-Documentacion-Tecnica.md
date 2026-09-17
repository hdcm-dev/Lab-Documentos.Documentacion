

En ingeniería de software existe una gran cantidad de documentos, pero **no todos tienen el mismo objetivo**. Un error común es empezar escribiendo un documento de arquitectura cuando en realidad todavía falta definir la visión del producto, o escribir documentación de APIs antes de tener claro el dominio.

Te dejo un compendio resumido, ordenado aproximadamente en el ciclo de vida de un proyecto.

| Documento                               | Sigla | Propósito                                                                                                                                     |
| --------------------------------------- | ----- | --------------------------------------------------------------------------------------------------------------------------------------------- |
| **Vision Document**                     | —     | Explica qué es el producto, qué problema resuelve, objetivos, alcance y público objetivo. Es la visión de negocio.                            |
| **Business Requirements Document**      | BRD   | Describe las necesidades del negocio que justifican el proyecto.                                                                              |
| **Product Requirements Document**       | PRD   | Define las funcionalidades que debe tener el producto desde la perspectiva del usuario y del negocio.                                         |
| **Software Requirements Specification** | SRS   | Especifica de forma detallada los requisitos funcionales y no funcionales del sistema.                                                        |
| **Software Architecture Document**      | SAD   | Describe la arquitectura completa del sistema, sus componentes, relaciones, responsabilidades y principios de diseño.                         |
| **High Level Design**                   | HLD   | Diseño de alto nivel. Explica los módulos principales, la interacción entre ellos y la arquitectura conceptual, sin entrar en implementación. |
| **Low Level Design**                    | LLD   | Diseño detallado. Describe clases, interfaces, tablas, algoritmos, protocolos y detalles de implementación.                                   |
| **Architecture Decision Record**        | ADR   | Documenta una decisión arquitectónica importante, sus alternativas y la justificación de la elección.                                         |
| **Domain Model**                        | —     | Modela el dominio del problema: entidades, conceptos y relaciones del negocio.                                                                |
| **Data Model**                          | —     | Describe la estructura de los datos, entidades, atributos y relaciones (ER, UML, etc.).                                                       |
| **Deployment Guide**                    | —     | Explica cómo desplegar el sistema en distintos entornos.                                                                                      |
| **Installation Guide**                  | —     | Describe el proceso de instalación desde cero.                                                                                                |
| **Operations Guide**                    | —     | Manual para la operación diaria del sistema (monitoreo, mantenimiento, respaldo, recuperación, etc.).                                         |
| **Administrator Guide**                 | —     | Guía para administradores del sistema: configuración, usuarios, permisos, mantenimiento.                                                      |
| **Developer Guide**                     | —     | Manual para desarrolladores: estructura del proyecto, convenciones, arquitectura y flujo de trabajo.                                          |
| **API Specification**                   | —     | Documenta las APIs (REST, GraphQL, gRPC, WebSocket), contratos y ejemplos.                                                                    |
| **Integration Guide**                   | —     | Explica cómo integrar sistemas externos con la plataforma.                                                                                    |
| **Security Architecture**               | —     | Describe la arquitectura de seguridad: autenticación, autorización, cifrado, auditoría y amenazas.                                            |
| **Threat Model**                        | —     | Analiza amenazas, riesgos y mitigaciones desde el punto de vista de la seguridad.                                                             |
| **Test Plan**                           | —     | Define la estrategia de pruebas, tipos de pruebas y criterios de aceptación.                                                                  |
| **Test Cases**                          | —     | Documenta casos de prueba concretos y resultados esperados.                                                                                   |
| **User Manual**                         | —     | Manual orientado al usuario final.                                                                                                            |
| **Release Notes**                       | —     | Resume cambios, mejoras y correcciones de cada versión.                                                                                       |
| **Roadmap**                             | —     | Presenta la evolución prevista del producto y las funcionalidades futuras.                                                                    |
| **Change Log**                          | —     | Historial cronológico de cambios del proyecto.                                                                                                |
| **Runbook**                             | —     | Procedimientos operativos para resolver incidentes y ejecutar tareas repetitivas.                                                             |
| **Postmortem / Incident Report**        | —     | Análisis de incidentes ocurridos, causas y acciones correctivas.                                                                              |
| **RFC (Request for Comments)**          | RFC   | Documento de propuesta para discutir una nueva funcionalidad o cambio antes de implementarlo.                                                 |

---

# Una forma práctica de agruparlos

## 1. Documentación de visión

Responde:

> ¿Qué queremos construir?

Incluye:

* Vision Document
* BRD
* PRD
* Roadmap

---

## 2. Documentación de análisis

Responde:

> ¿Qué debe hacer el sistema?

Incluye:

* SRS
* Casos de uso
* Reglas de negocio
* Modelo de dominio

---

## 3. Documentación de arquitectura

Responde:

> ¿Cómo estará organizado el sistema?

Incluye:

* SAD
* HLD
* ADR
* Diagramas
* Arquitectura de seguridad
* Arquitectura de despliegue

---

## 4. Documentación de diseño

Responde:

> ¿Cómo se implementa cada componente?

Incluye:

* LLD
* Diagramas UML
* Modelo de datos
* APIs
* Contratos
* Interfaces

---

## 5. Documentación operativa

Responde:

> ¿Cómo se instala, mantiene y opera?

Incluye:

* Installation Guide
* Deployment Guide
* Operations Guide
* Runbooks
* Disaster Recovery

---

## 6. Documentación para desarrollo

Responde:

> ¿Cómo trabajamos sobre el proyecto?

Incluye:

* Developer Guide
* Coding Standards
* Git Workflow
* Convenciones
* CI/CD

---

## 7. Documentación para usuarios

Responde:

> ¿Cómo se utiliza el sistema?

Incluye:

* Manual del usuario
* Tutoriales
* FAQ
* Guías rápidas

---

# Para HomeHub, ¿qué haría primero?

Si hoy empezara desde cero, el orden sería:

1. **Vision Document** → definir qué es HomeHub y qué problemas resuelve.
2. **Software Architecture Document (SAD)** → establecer la arquitectura conceptual y las decisiones de diseño.
3. **Software Requirements Specification (SRS)** → detallar los requisitos funcionales y no funcionales.
4. **Architecture Decision Records (ADR)** → registrar las decisiones clave (por ejemplo, por qué usar Storage Nodes o segmentación de video).
5. **Low Level Design (LLD)** → recién cuando la arquitectura esté madura, bajar al nivel de implementación.

Ese flujo permite que las decisiones tecnológicas (como usar .NET, Docker, PostgreSQL o un proveedor de almacenamiento específico) sean consecuencia de una arquitectura bien pensada, y no el punto de partida.
