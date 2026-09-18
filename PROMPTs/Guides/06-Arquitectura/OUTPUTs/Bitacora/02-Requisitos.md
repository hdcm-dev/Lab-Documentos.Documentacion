# Bitácora 02 — Registro de requisitos R-01..R-17

**Fecha:** 2026-09-18
**Semilla:** matriz de `Mesa/Ciclo-1/04-Requisitos.md` §1; criterios ajustados por el jurado (`Mesa/02-Ciclo1-Veredictos.md` §7).
**Uso:** vara común del ciclo 2. Cada requisito tiene criterio verificable y el chequeo que lo prueba.

| ID | Pedido | Criterio de aceptación | Chequeo | Directivas |
|---|---|---|---|---|
| R-01 | Incorporar la respuesta «Cada objeto…» | Fuente archivada; cada afirmación F-01..F-12 trazada a una § existente | Bitácora 00, tabla sin filas vacías; las § existen en la guía | DR-01 |
| R-02 | Respuesta explicativa para cada pregunta de la tabla | §7.2 con 7 `####`, cada uno con respuesta en una línea, porqué, ✅/❌ y remisión Lnn | Conteo de `####` en §7.2 = 7; cada uno con `**Respuesta` | DR-19 |
| R-03 | Reedición entera, autocontenida, no delta | Toda sección vigente con destino (Bitácora 03 §2); la guía no remite a la versión anterior | grep «versión anterior\|guía vigente» = 0 | DR-03 |
| R-04 | Lector sin experiencia; lenguaje claro, técnico, no coloquial | Términos definidos antes de su uso; palabras prohibidas = 0; voseo solo en reglas y preguntas | grep lista DR-18; revisión Did/Ed/Novato | DR-16, DR-18 |
| R-05 | Definiciones, ejemplos, explicaciones | Cada capítulo §1–§6: prerrequisitos → definiciones → decisiones → práctica → cierre | Checklist por capítulo | DR-15 |
| R-06 | Comandos con resultado esperado y análisis | Cada paso Lnn: objetivo, comando, salida registrada, cómo leerla, qué confirma, qué puede cambiar | Anexo A completo; capturas existen | DR-05, DR-11 |
| R-07 | Entender y probar al mismo tiempo | Cada Lnn aparece en la § de su concepto (mapa §6 del veredicto) | Tabla §↔Lnn del Anexo A | DR-04 |
| R-08 | Guía de consulta para un problema real | §9 legible aislada: mapa §9.1, escalera, señales, caso resuelto §9.5 | Revisión Req/Did | DR-30 |
| R-09 | Preguntas guía formadoras de criterio con «cuándo sí/no» | Cada capítulo cierra con una pregunta de aplicabilidad en términos E-A..E-D | grep de «¿Cuándo no» por capítulo ≥ 1 en §1–§6 y §8; en §7 y §9 la pregunta de aplicabilidad es §7.5 y §9.3 (decisión del ciclo 2, C-17) | DR-15 |
| R-10 | Mermaid cuando corresponda | 6 diagramas de DR-22 con leyenda; ninguna flecha continua hacia afuera | Render sin error | DR-22 |
| R-11 | Jerarquía con índice | `##` 0–9 + anexos A–E; índice con glosa; anclas 100 % | Script de anclas | DR-13 |
| R-12 | Snippets representativos | Todo bloque `csharp` rotulado [Compilado] o [Fragmento ilustrativo] | Script de rótulos | DR-09 |
| R-13 | No inventar; evidencia verificable | Salidas con marca de captura; versiones/licencias con cita; criterio propio rotulado | Scripts DR-07, DR-10 | DR-05..DR-10 |
| R-14 | Mesa: didáctica, edición, arquitectura .NET + análisis de experto adicional | Registro de convocatoria con AH-001 | `Mesa/01-Registro-Convocatoria.md` | — |
| R-15 | La mesa revisa el documento final y corrige | Informe del ciclo 2 + parches aplicados y verificados | `Mesa/03-Ciclo2-*.md` | — |
| R-16 | Apuntes y debates en `06-Arquitectura/OUTPUTs` | Bitacora/, Nucleos/, Mesa/, Laboratorio/ | ls | — |
| R-17 | Descomposición en núcleos, cohesión, integración, bitácora | NC-00..NC-10 + Bitácora 03 con trazabilidad núcleo → § | Bitácora 03 §1 | DR-03 |
