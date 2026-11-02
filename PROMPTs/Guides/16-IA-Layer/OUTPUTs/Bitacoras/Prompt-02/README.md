# Bitácora del prompt 02 — guía 16 (IA Layer)

Registro de la planificación del prompt 02: reedición, coherencia, conocimiento de especificación y casos de uso. Etapa actual: planificación cerrada; ejecución según `05-Plan-Integrado.md`.

## Índice

- [1. Documentos de la mesa](#1-documentos-de-la-mesa)
- [2. Relevamiento](#2-relevamiento)
- [3. Núcleos conceptuales](#3-núcleos-conceptuales)
- [4. Propuestas de los especialistas](#4-propuestas-de-los-especialistas)
- [5. Orden de lectura](#5-orden-de-lectura)

## 1. Documentos de la mesa

| Archivo | Contenido |
|---|---|
| [00-Coordinacion-Entre-Sesiones.md](00-Coordinacion-Entre-Sesiones.md) | Reparto con FRAMEWORK MAUI y DocsAsCode (registro vivo, por agregado). |
| [01-Convocatoria.md](01-Convocatoria.md) | Convocatoria de la mesa y marco. |
| [02-Consolidado.md](02-Consolidado.md) | Consenso, propuestas únicas e ítems D-01…D-30. |
| [03-Voto-evidencia.md](03-Voto-evidencia.md) | Voto del jurado de evidencia. |
| [03-Voto-impacto.md](03-Voto-impacto.md) | Voto del jurado de impacto. |
| [03-Voto-costo-beneficio.md](03-Voto-costo-beneficio.md) | Voto del jurado de costo-beneficio. |
| [03-Voto-coherencia-historica.md](03-Voto-coherencia-historica.md) | Voto del jurado de coherencia histórica. |
| [03-Voto-riesgo.md](03-Voto-riesgo.md) | Voto y vetos del jurado de riesgo. |
| [04-Aprobacion.md](04-Aprobacion.md) | Escrutinio, vetos, homogeneidad y escalados al PO. |
| [05-Plan-Integrado.md](05-Plan-Integrado.md) | Integración de núcleos y plan de ejecución E1…E11. |

## 2. Relevamiento

| Archivo | Contenido |
|---|---|
| [R1-Guia.md](Relevamiento/R1-Guia.md) | Estado de la guía 0.11.0. |
| [R2-Geometria.md](Relevamiento/R2-Geometria.md) | Caso Geometría. |
| [R3-Caso-Privado.md](Relevamiento/R3-Caso-Privado.md) | Caso privado, en abstracto. |
| [R4-Infra-Modelos.md](Relevamiento/R4-Infra-Modelos.md) | Estaciones y modelos de prueba. |
| [R5-Marco.md](Relevamiento/R5-Marco.md) | Marco de la mesa y expedientes. |
| [R6-Industria.md](Relevamiento/R6-Industria.md) | Referencias y casos de industria. |

## 3. Núcleos conceptuales

| Archivo | Núcleo |
|---|---|
| [00-Cohesion.md](Nucleos/00-Cohesion.md) | Cohesión global entre núcleos. |
| [N-01](Nucleos/N-01-Coherencia-Texto-Ejemplos-Demo.md) | Coherencia texto ↔ ejemplos y demo. |
| [N-02](Nucleos/N-02-Libro-Unificado-Arquitectura-Editorial.md) | Libro unificado y arquitectura editorial. |
| [N-03](Nucleos/N-03-Fundamentos-Del-Framework.md) | Fundamentos del framework. |
| [N-04](Nucleos/N-04-Ronda-De-Revision-Tipo-Libro.md) | Ronda de revisión tipo libro. |
| [N-05](Nucleos/N-05-Conocimiento-De-Especificacion.md) | Conocimiento de especificación. |
| [N-06](Nucleos/N-06-Caso-De-Uso-Geometria.md) | Caso de uso Geometría. |
| [N-07](Nucleos/N-07-Caso-De-Uso-Privado.md) | Caso de uso privado. |
| [N-08](Nucleos/N-08-Referencias-Y-Casos-De-Industria.md) | Referencias y casos de industria. |
| [N-09](Nucleos/N-09-Infraestructura-De-Pruebas.md) | Infraestructura de pruebas. |
| [N-10](Nucleos/N-10-Gobernanza-Mesa-Expedientes-Coordinacion.md) | Gobernanza, mesa, expedientes y coordinación. |

## 4. Propuestas de los especialistas

| Archivo | Especialista |
|---|---|
| [P-01](Propuestas/P-01-Requisitos.md) | Requisitos |
| [P-02](Propuestas/P-02-Arq-Movil-MAUI.md) | Arquitectura móvil MAUI |
| [P-03](Propuestas/P-03-Arquitecto-MEAI.md) | Arquitectura MEAI |
| [P-04](Propuestas/P-04-Arquitecto.md) | Arquitecto arc42/C4/ADR |
| [P-05](Propuestas/P-05-Analista-Decisiones.md) | Analista de decisiones |
| [P-06](Propuestas/P-06-Doc-Tecnica.md) | Documentación técnica |
| [P-07](Propuestas/P-07-Editorial-A.md) | Comisión editorial A |
| [P-08](Propuestas/P-08-Comision-Editorial-B.md) | Comisión editorial B |
| [P-09](Propuestas/P-09-Revision-Bibliografica.md) | Revisión bibliográfica |
| [P-10](Propuestas/P-10-Seguridad-IA.md) | Seguridad de IA |
| [P-11](Propuestas/P-11-Investigador-Pruebas.md) | Investigador de pruebas |
| [P-12](Propuestas/P-12-Geometria.md) | Dominio Geometría |
| [P-13](Propuestas/P-13-Forma-Conocimiento.md) | Forma de conocimientos |
| [P-14](Propuestas/P-14-Lector-Sin-Contexto.md) | Lector sin contexto |

## 5. Orden de lectura

```mermaid
flowchart LR
  A["1 · Coordinación"] --> B["2 · Relevamiento R1–R6"]
  B --> C["3 · Núcleos y cohesión"]
  C --> D["4 · Propuestas P-01…P-14"]
  D --> E["5 · Consolidado"]
  E --> F["6 · Votos"]
  F --> G["7 · Aprobación"]
  G --> H["8 · Plan integrado"]
```

Las carpetas `E1/`…`E11/` se crean al ejecutar cada etapa del plan y se suman a este índice.
