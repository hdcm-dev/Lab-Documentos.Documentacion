---
doc_id: B14-PANEL-abogado-del-diablo
titulo: Relectura integral de la guía 0.11.0 — abogado del diablo
fecha: 2026-10-29
objeto: Dot-Net-Integration-AI-Layer-Guide.md 0.11.0 (sha256 eeede578…fa18), Demos/, Examples/_Comun
insumo: Relectura/insumo/Informe-abogado-del-diablo.md (sólo como pista; nada se cita como evidencia)
---

# Panel · abogado del diablo

Leí a ciegas (sin Panel-*.md ajenos). Ubicación por ancla y texto único. Sin editar la guía.

## abogado-del-diablo-01 · mayor · §10.6 y su eco en ADR-10 y §14.6 quedaron atrás de R-15b
- Ancla: `#s10-6` («su repetición, con criterio propio, no había cerrado al escribir esta sección»); `#s13-11` Consecuencias («El LLM juez local no está calibrado: ninguna de sus salidas se pudo leer»); `#s14-6` («El de 15 es de la familia del generador y no quedó calibrado»).
- Problema: R-15b ya cerró (41/52 interpretables, IC95 CP [0,653; 0,889], `qwen3.5:4b`@`d8b0f5e9760c`, estación 2, Ollama 0.40.11, 2026-10-29) y no alcanzó el mínimo 45/52 de su criterio: el resultado es «no medido». La guía dice «no había cerrado», y ADR-10 y §14.6 generalizan a todo juez local lo que vale sólo para `qwen2.5:0.5b` del servidor retirado («ninguna salida se pudo leer»); con el 4b sí se leyeron 41. «No calibrado» y «no medido» no son lo mismo.
- Propuesta: §10.6 dice «no medido: 41/52 interpretables, por debajo del mínimo 45/52 fijado antes» con su rótulo R-LLM; ADR-10 y §14.6 separan historia (0.5b, 0/52 legibles) de la base (4b, no medido).

## abogado-del-diablo-02 · mayor · Cifras sin rótulo R-LLM completo
- Ancla: `#s11-7` («lo repitió en las 10 repeticiones de cada entrada, sin pedir la baja … Observado: `qwen3.5:4b`, estación 2, 2026-10-29»); `#s8-5` («propuso «3400» en 8 de 10 corridas … `qwen3.5:4b`»); preguntas de §6 («IC95 [0,398; 1] … `qwen3.5:4b`, servidor compartido, 2026-10-27»); `#s8-2` («`qwen2.5:0.5b` devolvió `"medio":"piedra"` … 6 de 10»).
- Problema: faltan digest y/o versión de Ollama; en §11.7, además, faltan k/n e IC95 (no se dice cuántas entradas ni el intervalo).
- Propuesta: completar desde el registro de cada corrida; si el registro no tiene el digest, rotular «digest no registrado» o quitar la cifra.

## abogado-del-diablo-03 · mayor · La regla 1 de origen no está en el camino del chat y ADR-06 declara confianza alta
- Ancla: `#s13-7` Confianza («Alta: … `ContextoNoConfiable_SinHerramientasDeEscritura` (comprueba la opción `conEscrituras: false`, no su uso en el chat)»); B.5 fila 4.
- Evidencia: `Demos/MovilidadUrbana.Asistente/src/MovilidadUrbana.Asistente/Infrastructure/AI/Chat/SesionDeChat.cs:73` llama `_herramientas.Crear()` con valores por defecto; es el único punto de llamada (`HerramientasDelAsistente.cs:46`). En la demo la regla 1 es código muerto; lo único vigente es la regla 2, medida sólo con el servidor retirado (0/6, §11.7, historia).
- Propuesta: bajar la confianza a «media» en esa parte, o decir que la demo sólo aplica la regla 2 y que la regla 2 con la composición de la base no está medida.

## abogado-del-diablo-04 · mayor · La guía excede su propio tope de extensión
- Evidencia: `contar.sh` da 58.820 palabras, 133 % del tope de 44.330 (00-Preparacion, conteo REC-21).
- Problema: el tope existe pero ninguna compuerta lo hace valer; la guía se presenta «en revisión» como si fuera aceptable. Una promesa de forma sin respaldo.
- Propuesta: declarar el exceso en la bitácora como deuda abierta con un plan de recorte, o retirar el tope; no darlo por cumplido.

## abogado-del-diablo-05 · menor · El juez por defecto es el que la guía documenta como inservible
- Evidencia: `Examples/_Comun/MovilidadUrbana.Asistente.Comun/AI/ConfiguracionDelModelo.cs:36,72` y A.12 (`qwen2.5:0.5b`); §10.6 dice que ese juez dio 0/52 salidas legibles.
- Propuesta: decirlo en A.12 («el valor por defecto reproduce el juez descartado») o cambiar el valor por defecto en el código y en su prueba.

## abogado-del-diablo-06 · menor · La salida `--fake` de 15 parece una medición
- Ancla: Ejemplos de §10 («llamadas al juez: 52 · salidas interpretables: 51/52 … juez: no descartado (9/10 ≥ 8)»).
- Problema: el aviso va antes y después, pero el bloque usa el mismo formato que una corrida real y queda junto al resultado real del juez. Quien lo copie lo puede tomar por una cifra.
- Propuesta: poner «[guion]» en la primera línea del bloque o en cada línea de cifra.

## Ataques que fallaron
- Los IC95 que recalculé (5/6, 1/12, 8/10, 0/6) coinciden con Clopper-Pearson.
- «Bajas sin aprobación: cero» se presenta como garantía del código y no como conducta del modelo (§10, §14.5): es coherente.
- La alternativa (d) del ADR-06 (que ninguna herramienta escriba) está declarada y descartada con su motivo.
