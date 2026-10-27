| Campo | Valor |
| --- | --- |
| Tipo | providencia |
| Fecha | 2026-10-25 |
| Autor | Presidencia de la mesa |
| Corrige | — |

# Providencia — respuesta del Product Owner al lote del folio 021

El lote de cuatro preguntas del jurado de la ronda 1 se presentó al PO como selector de opciones. Las preguntas
están abreviadas con «…» (su texto completo está en el folio 021, «Abiertas»), y las respuestas son literales:

```testimonio
¿Autorizás proteger main de hdcm-dev/Lab-Documentos …? = Sí, proteger main (Recomendado)
XC-1, migración de la base local del teléfono … ¿Qué camino? = C-1 sobre fijo (Recomendado)
iOS: no hay Mac ni runner macOS medido. ¿Cómo queda? = Diseño sin ensayo (Recomendado)
¿El producto necesita poder atribuir un error de producción a versiones exactas …? = Sí, atribuir (Recomendado)
```

| Canal | Fecha-hora | Huella |
| --- | --- | --- |
| Selector de preguntas de Claude Code en VS Code (respuesta a las cuatro preguntas del folio 021) | 2026-10-25T20:45-03:00 | `c1ba6de381f1691e19c0d353e19bf186af7b99784b64ed9dcaf84e7a886b2173` |

## Clasificación: aprobaciones explícitas

| Ítem del lote | Decisión aprobada | Efecto |
| --- | --- | --- |
| 1 · main y runner | **Proteger `main` de `hdcm-dev/Lab-Documentos`** (PR obligatorio, `fw-ok` como único check requerido, sin excepción para administradores) y correr el workflow de la demo en `[self-hosted, i7infra-dev]` con guarda de mismo repositorio y aprobación de forks | P6 pasa de «I2 diseñado» a **I1 implantado**. Sale del default del jurado |
| 2 · XC-1 | **C-1, sobre fijo**: se cumple Versionado-Producto-Integral §2.7 cláusula 2; la migración al abrir no se implementa | La excepción decae; el ADR queda Aceptado con C-1 |
| 3 · iOS | **Diseño sin ensayo, NO VERIFICADO**, sin compilar, sin compuerta y sin job `macos-*` | Igual al default |
| 4 · Atribución | **Sí**: rige Versionado-Producto-Integral (condición de carga cumplida) | Igual al default; fase diseño |

Estas aprobaciones rigen sobre lo que dictamine la ronda 2 en esos cuatro puntos, salvo que la ronda 2 encuentre una
contradicción con E1 o E2; en ese caso vuelve al PO.

Sigue: veredicto de la ronda 2 y resolución · presidencia · Cierra con: folio resolucion
