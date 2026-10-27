# Bitácora 01 — Descomposición del pedido en núcleos conceptuales

> Aplica la regla de descomposición conceptual del prompt: la unidad es la afinidad y la dependencia entre las
> ideas, no la extensión. Cada núcleo se documenta aparte en `Nucleos/`; las relaciones entre núcleos, en
> `02-Cohesion-Global.md`. Versión inicial de la presidencia; la mesa puede reagrupar con motivo.

## Índice

1. [Fuentes que se descomponen](#1-fuentes-que-se-descomponen)
2. [Los núcleos](#2-los-núcleos)
3. [Trazabilidad frase → núcleo](#3-trazabilidad-frase--núcleo)

## 1. Fuentes que se descomponen

- El prompt `Crear-Framework-Concept.md` (evidencia 001 del expediente).
- `Framework-APP.md`, borrador del PO del 2026-10-03 (decisiones abiertas D-01 a D-07, riesgos).
- El caso base `MovilidadUrbana.MAUI` (ia-db de Lab-E2E.WebBlazor).

## 2. Los núcleos

| Id | Núcleo | Qué lo une | Depende de |
| --- | --- | --- | --- |
| N1 | **Actualización dinámica sin tienda** | Separar cascarón y contenido, qué permiten las tiendas, opciones A/B/C, manifiesto, firma, staging, rollback y paquete semilla (D-01, D-02) | — (es el riesgo que condiciona todo) |
| N2 | **Cascarón y servicios nativos** | El puente versionado y lo que expone: login y biometría, cámara, red, política de acciones offline, outbox y SQLite (D-03, D-04, D-05, D-07) | N1 (la opción de contenido fija la forma del puente) |
| N3 | **Integración, PR y versionado del producto** | Proteger la rama estable: PR con pruebas obligatorias, compuertas, runner `[self-hosted, i7infra-dev]`, líneas de versión (cascarón, contenido, puente) y canales; dónde compila iOS (D-06) | N1 (qué se versiona), N4 (qué corre la compuerta) |
| N4 | **Estrategia de pruebas** | Qué se prueba en cada capa para que un PR no rompa lo que funcionaba: unitarias, contrato del puente, paquete y actualizador, E2E en emulador o teléfono | N1, N2 (qué se prueba), N3 (dónde corre) |
| N5 | **Guía didáctica y demo** | Guía académica para un desarrollador sin experiencia, demo derivada de `MovilidadUrbana.MAUI` que la ilustra, perfil Study-Guide (marco de referencia: escenarios, contextos, actores) | N1–N4 (contenido); es el entregable |

## 3. Trazabilidad frase → núcleo

| Frase del prompt | Núcleo |
| --- | --- |
| «aplicar actualizaciones desde el servidor sin pasar por el ciclo de actualización rigido que imponen los store» | N1 |
| «cuando el usuario abre la aplicación esta aplicación solicita bajar las actualizaciones de forma automatica» | N1 |
| «paginas .net blazor hibridas en .NET MAUI» | N1, N2 |
| «al introducir un PR sobre una rama estable, al no dispararse pruebas automatizadas puede romper funcionaldiades» | N3, N4 |
| «prodicimientos claros en los PR y en los conceptos de integración y versionado del producto» | N3 |
| «Configura el wofklow con este runner de github: `runs-on: [self-hosted, i7infra-dev]`» | N3 |
| «guía instructiva academica enfocada a un desarrollador sin experiencia» · «ejemplo de demostración … que sirva para ilustrar» · «Tomar base … `MovilidadUrbana.MAUI`» | N5 |
| «trazar una arquitectura clara … simplicidad y practicidad, escalibilidad» · «tendencias del mercado y los estandares de la industria» | Transversal: criterio de juicio de todos los núcleos |
