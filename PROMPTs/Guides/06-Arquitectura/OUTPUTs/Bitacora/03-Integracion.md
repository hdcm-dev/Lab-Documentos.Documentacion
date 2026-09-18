# Bitácora 03 — Integración de los núcleos

**Fecha:** 2026-09-18
**Uso:** DR-03. Completa NC-00 §4 (trazabilidad núcleo → capítulo), el inventario de la guía vigente y la tabla de términos canónicos.

## 1. Núcleo → sección del entregable

| Núcleo | Secciones |
|---|---|
| NC-01 Fundamentos | §1 (1.1–1.5); DI en §2.1 |
| NC-02 Dependencias | §2 (2.1–2.6); verificación en §5.3 |
| NC-03 Objetos por capa | Entity y VO en §3; Command/Query en §4; Persistence model y Response en §5; ViewModel y form model en §6; síntesis completa en §7 |
| NC-04 Backend | §3, §4, §5 |
| NC-05 Clientes | §6 |
| NC-06 Estructura física | §2.6 (solo Backend), §8.1–8.3, §8.5 |
| NC-07 Nombres | Recuadro §3.1; §8.4 |
| NC-08 Laboratorio | L00–L24 intercalados; Anexo A |
| NC-09 Criterios | §2.5, §3.4, §7.5, §9 (9.1–9.6); Anexo B |
| NC-10 Tecnologías | §4.5, §9.4; Anexo C |

Contradicciones X-01..X-06 de NC-00: X-01/X-04 → DA-2 (§6.3, §8.3, §8.5); X-02 → DA-1 (§8.1); X-03 → DR-26 (L14); X-05 → DR-12; X-06 → §9.

## 2. Inventario de la guía vigente → destino

| Sección vigente | Destino |
|---|---|
| §1 Glosario (Entity, VO, DTO, ViewModel, Persistence model, Use Case, CQRS, MediatR, Repository, RCL, Clean Architecture) | Definiciones en su capítulo (§1–§6) y Anexo D; MediatR a §4.5; CQRS a §4.4 |
| §2 Visión general | §2.1 (tabla anillo ↔ proyecto) y §2.6 |
| §3 Estructura de proyectos | §8.1 (DA-1) |
| §4 Domain | §3 |
| §5 Application | §4 |
| §6 Infrastructure | §5.3–5.5 |
| §7 WebAPI | §5.2, §5.6 |
| §8 WebFront | §6.1–6.3 |
| §9 Shared.UI | §6.5 (ilustrativo) |
| §10 Desktop | §6.5, renombrado `MyProject.Maui` (ilustrativo) |
| §11 Capa de servicios y autenticación | §6.2, §6.5 |
| §12 Diagrama final | Retirado: reemplazado por diagramas 2 y 3 (contradecía DC-1, HC-16) |
| §13 Reglas de dependencia | §8.3, condicionada (DR-23) |
| Resumen de decisiones tecnológicas | §9.4 (criterio) y Anexo C (datos fechados) |

## 3. Términos canónicos (DR-12)

| Canónico | Uso | Alias prohibidos |
|---|---|---|
| contrato | Solo el contrato HTTP y sus DTOs (`Contracts`) | «contratos» para interfaces |
| interfaz | Tipo `interface` de C# | «contrato» |
| mensaje | Command o Query | — |
| `CrearProductoRequest`, `ProductoResponse` | DTOs de Contracts | `CrearProductoRequestDto`, `ProductoResponseDto` |
| `ProductoDto` | Modelo de lectura de Application | — |
| `ProductoFormModel` | Modelo del formulario | `ProductoFormViewModel` |
| `MyProject.Maui` | Cliente MAUI Blazor Hybrid | «Desktop» |
| heredada (base de datos) | Esquema preexistente | «legada» |
| caso de uso | Intención del usuario implementada en Application | — |
| composition root | `Program.cs` de la WebAPI | — |
