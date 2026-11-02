---
doc_id: BIT-16-05
doc_type: cierre-para-el-po
title: Cierre de la mesa de estructuración — una página para el PO
status: cerrado
origin: agent (secretaría de la mesa)
last_review: 2026-10-26
audience: [PO]
traces: [BIT-16-04 v3, BIT-16-MESA-C3-08]
---

# Cierre de la mesa de estructuración

La mesa terminó sus tres ciclos el 2026-10-26. La estructura de la guía, de los ejemplos y de la demo quedó fijada en [`04-Plan-De-Integracion.md`](04-Plan-De-Integracion.md), **v3 — FINAL**. Ninguna decisión quedó provisional. El detalle está en [`Mesa/Ciclo-3/08-Cierre.md`](Mesa/Ciclo-3/08-Cierre.md).

## Qué se decidió

- **Guía única** en ocho partes (0, I–VI, Cierre) y anexos, con **27 objetivos de aprendizaje**. Cada sección tiene un objetivo o se declara de encuadre. El tope es de **44.330 palabras**, con una regla de conteo que se puede ejecutar. No hay casos integradores aparte.
- **17 ejemplos** en `Examples/` (01–17; 14 queda opcional). La dificultad se escribe en palabras: básico, intermedio o avanzado, según el nivel que PR-3 le da al tema. No se fusiona ningún ejemplo.
- **La demo** es la aplicación existente de Movilidad Urbana con la capa de IA agregada (contexto de uso CTX-EXISTENTE × CTX-LOCAL × CTX-PROTO). Tiene seis pasos, de PD-1 a PD-6. Tres se corren contra Qwen (PD-2 ayuda con RAG, PD-3 alta desde texto, PD-6 baja con aprobación) y los otros tres cierran con pruebas de cableado. **La demo no expone MCP**: eso lo enseña el ejemplo 13. Los cinco escenarios los cubre el conjunto de guía, ejemplos y demo.
- **Seguridad**: toda escritura que viene después de leer texto que la app no escribió necesita una aprobación humana, y el pedido de aprobación lo arma el código. La inyección del ejemplo 16 está en el `Nombre` de una localidad.
- **Datos de prueba**: sólo Movilidad Urbana. Lo «escrito para el ejemplo» se rotula, se congela con su hash y se declara como estímulo del mismo autor.
- **Modelos**: Qwen en tu servidor de la LAN, con un tope de **4 h de turnos**. El Ollama propio del gestor de recursos lleva los embeddings y el juez del ejemplo 15 (`qwen2.5:0.5b`, distinto del generador). Lo verifiqué hoy y funciona.

## Qué se descartó

- Seguir la demo con un séptimo paso MCP (PD-7) y probar con modelo los seis pasos.
- Fusionar 01 con 02 o 06 con 07, y sumar casos integradores.
- El reglamento sintético del ejemplo 05 y el documento malicioso del 16, que salían del caso. Los reemplazan un padrón de localidades y una localidad con nombre malicioso.
- La sonda multiherramienta DEP-10. La baja usa `eliminar_localidad(nombre, provincia)` desde el inicio.

## Qué queda para la construcción

1. **Antes de construir**: crear las listas privadas de AC-7 y AC-8 fuera del repo (DEP-16, a cargo de la presidencia); correr `salud` del Ollama propio; medir las clases de tiempo (DEP-03, DEP-09, DEP-13).
2. **Primera entrega**: TURNO-1 (≈ 2,1 h de tu servidor) y TURNO-3 (≈ 1,5 h del propio). TURNO-2 es extensión y, con 4 h, quedan sin correr contra el modelo 04 ext., 08 ext. y 17.
3. **Antes de cualquier commit**: reescribir o rotular los seis archivos de investigación que todavía nombran dominios ajenos (R-06).
4. Lo que la guía va a declarar como no hecho (§14.6): autorización real, MCP en la demo o fuera de loopback, comparación de calidad entre contexto completo y RAG, varios ataques para 16, un juez de otra familia y tareas de varios pasos.

**Tu decisión, sólo si querés cambiarla**: ESC-001 (embeddings en tu servidor). Si no respondés, rige la opción B, que ya está funcionando.

La estructura **queda lista para construir**.

> **2026-10-29 — Recuperación (B-02, paso 2.10).** ESC-001 se cerró «sin objeto»: el servidor por el que preguntaba se retiró el 2026-10-28 y las dos estaciones vigentes ya tienen el modelo de embeddings. Ya no es una decisión pendiente (ver `Mesa/Ciclo-3/08-Cierre.md`, nota del 2026-10-29).
