# E3 · Tramo 1 · Front matter, Prólogo y Parte I

Etapa E3, tramo 1 de 6 (`../05-Plan-Integrado.md` §5 E3). Fecha: 2026-11-01. Registro de sólo agregado. Recuento y compuertas: `Registro-Por-Parte.md` §2.

## Índice

1. [Definiciones](#1-definiciones)
2. [Qué se hizo](#2-qué-se-hizo)
3. [Cambios de E1 en el tramo](#3-cambios-de-e1-en-el-tramo)
4. [Decisiones de edición](#4-decisiones-de-edición)
5. [Pendientes para los tramos siguientes](#5-pendientes-para-los-tramos-siguientes)
6. [Archivos tocados](#6-archivos-tocados)

## 1. Definiciones

- **Número visible:** el número de capítulo o sección que lee la persona (§N.k). **Ancla:** el `id` al que apunta el enlace. En este tramo los enlaces del Prólogo muestran la numeración nueva y apuntan a las anclas viejas, que el libro conserva como alias (`../E2/Anclas-Viejo-Nuevo.md`).

## 2. Qué se hizo

1. **Front matter:** `version: 0.12.0`, `status: en revisión` (D-29 b), `last_review: 2026-11-01`, `tope_palabras: 60000` (tope votado), Conocimiento en `related`. La línea de versión ya no cuenta la historia de la redacción (HE-11).
2. **Prólogo, capítulo 0** (anclas `prologo`, `c0`, `c0-0`…`c0-7`, con los alias `parte-0`, `s0`, `s0-0`…`s0-5`): índice nuevo con el mermaid de las diez piezas (Figura 0.1) y la lista por parte y capítulo; OA con la numeración nueva y anclas `oa-*` intactas; rutas con tronco común que suma el capítulo 1; requisitos con un solo proveedor (CL-07); 0.4 con el patrón D-09 a (Tabla 0.2), NO VERIFICADO / NO EJECUTADO, numeración «Tabla N.m», sin la regla «Historia (hasta…)» (pasa al Anexo H, D-10 a); 0.5 remite al único mapa de ejemplos (C-2.7) y a `contar.sh` sin cifras (CL-01); 0.6 nueva, Conocimiento de especificación con enlace (U-2.3); 0.7 nueva, anclas estables (la tabla de alias, en forma de regla).
3. **Parte I, capítulo 1** desde `../Ejecucion/E2-Fundamentos-Parte-I-Borrador.md`: anclas `p-1`…`p-10` para que el Conocimiento y los capítulos citen cada principio; `c1-preguntas` y `c1-calidad`; cada pregunta guía atada a un OA existente (OA-0.2, OA-0.3, OA-D9); «5 de 5» reescrito sin cifra para no crear una figura fuera del mapa de `compuerta-intervalos.py`. Enunciados de P-1…P-10 sin cambios respecto de la lista congelada.
4. **Rótulos de las partes siguientes** (sólo la línea `# Parte …` y su ancla): Marco → Parte II, «Fundamentos» → Parte III · Arquitectura y SDK (CL-03, D-08 a), y IV a VII; cada una suma `parte-2`…`parte-7` y conserva `parte-i`…`parte-vi`. Hacía falta para que `contar.sh` no sumara dos «Parte I». El cuerpo de esas partes no se tocó.
5. **`tools/contar.sh`** reconoce «# Prólogo» y las Partes I–VII, con topes que suman 60.000.

## 3. Cambios de E1 en el tramo

| Id | Estado en el tramo 1 |
|---|---|
| CL-01 | aplicado en 0.5: sin cifras, remite a `contar.sh`; la medición con fecha va al Anexo E (pendiente del tramo de Anexos) |
| CL-02 | fuera del tramo (cap. 4, ex §3.1) |
| CL-03 | aplicado en el rótulo de la Parte III |
| CL-04, CL-05 | nada en el libro (E1 §2) |
| CL-06, CL-08 | fuera del tramo (caps. 7 y 9) |
| CL-07 | aplicado en 0.3 (un proveedor, Ollama por la API compatible con OpenAI); E.3 y A.12 quedan para el tramo de Anexos |
| Prácticas → README | no hay Prácticas en el Prólogo ni en la Parte I |

## 4. Decisiones de edición

- **Tabla de alias como regla, no como 283 filas:** la tabla completa ya existe en la bitácora; en el libro, 0.7 da la regla (M = N − 1, excepciones `s15`, `s3-0`, `s4-1`, partes).
- **Índice a nivel de capítulo:** la lista con todas las secciones excedía el tope del Prólogo; el índice congelado de E2 es por capítulo.
- **Topes por parte:** Prólogo 2.200 y Parte I 1.100 (en vez de 1.500, usadas 1.091); el resto, cerca de lo medido menos los recortes previstos; Parte VII suma 2.158 del capítulo 16. Suma 60.000.

## 5. Pendientes para los tramos siguientes

1. Encabezados de capítulo y sección de las Partes II–VII siguen con la numeración vieja (§N); cada tramo los pasa a «Capítulo N+1 · …» con anclas `cN` y alias `s…`. Mientras tanto el Prólogo muestra los números nuevos.
2. Anexo E: registrar la medición de `contar.sh` con fecha (CL-01). Anexo H «Procedencia»: el índice lo anuncia «en redacción».
3. Capítulo 16 y Anexo H aparecen en el índice sin enlace hasta que existan (E8 y tramo de Anexos).
4. Glosario (Anexo C): sus remisiones `[§0.4](#s0-4)` siguen resolviendo; el texto visible se renumera en el tramo de Anexos (C-2.3).
5. El Conocimiento declara compatibilidad con la numeración 0.11.0; las remisiones resuelven por alias. Actualizar su cabecera cuando E3 cierre (no es de este tramo).
6. `verificar.sh` completo y filtro U-7.1, al cierre de E3.

## 6. Archivos tocados

| Archivo (LD) | sha256 antes | sha256 después |
|---|---|---|
| `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Dot-Net-Integration-AI-Layer-Guide.md` | `c8defd8324497c4279a3dfd57ce5d2757326ad966813a9f9797d0196d9b7ce3d` | `95d8b0d35cc9be999ada788ed7e4b90fac59e5b68d2e41859b5efdaf898d94c9` |
| `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/tools/contar.sh` | `3c67d269ab3ca30ec4fab9d932da8ca64c9c3f0b33bbd028746ec1cb2515de16` | `cdcdb31d1cd052bc62ab149c3e755a50e0a6ef5244774a318594973ccb8e78c7` |

Sin commit, push ni PR. No se tocaron archivos comunes ni carpetas de otras sesiones. Sin mensajes ajenos a mitad de turno.
