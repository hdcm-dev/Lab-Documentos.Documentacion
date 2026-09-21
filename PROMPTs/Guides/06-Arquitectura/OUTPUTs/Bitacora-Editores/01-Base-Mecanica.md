# Bitácora de editores 01 — Base mecánica

**Fecha:** 2026-09-19 · **Objeto:** guía v2.0.2 @ dbdf9dd · Medido antes de despachar el panel. Lo enumerable entra con ancla E1.

## 1. Secciones `###`/`##` sin ningún bloque de código

Comando: script python sobre encabezados y cercas ```` ``` ````. Resultado: 45 de 71 secciones `###` (más los encabezados de capítulo y anexos). Se excluyen del juicio las que por naturaleza no llevan código (índice, §0.x, preguntas de cierre, anexos B–E). Quedan como **candidatas E1 de la pregunta Q1/Q2**:

- §1.1 Definiciones
- §1.3 ¿Por qué una referencia es una flecha con dirección?
- §1.6 Pregunta de cierre
- §2.3 ¿Qué cambia al partir un proyecto en capas? (L06, L07)
- §2.4 ¿Por qué Infrastructure depende de Domain, si es el dominio el que necesita guardar?
- §2.5 ¿Por qué la WebAPI referencia Infrastructure, si «no debería conocerla»?
- §2.6 ¿Qué se gana y qué se paga?
- §2.8 Pregunta de cierre
- §3.1 Definiciones
- §3.2 ¿Cómo se reconoce una Business Rule?
- §3.5 ¿Y si la Entity no tiene ninguna regla?
- §3.6 ¿Dónde vive una Business Rule en un programa orientado a objetos?
- §3.8 Pregunta de cierre
- §4.1 Definiciones
- §4.4 ¿Cómo se reconoce un Repository?
- §4.7 ¿De dónde vienen los nombres Command y Query?
- §4.8 ¿Esto es CQRS?
- §4.9 ¿Hace falta MediatR para tener Use Cases?
- §4.11 Pregunta de cierre
- §5.1 Definiciones
- §5.5 ¿Dónde se confirma la escritura, y hace falta un Repository si ya está EF Core? (L18)
- §5.7 Pregunta de cierre
- §6.1 Definiciones
- §6.4 Si el Blazor corre en el servidor y es el único cliente, ¿por qué no llamar directamente a Application?
- §6.6 Pregunta de cierre
- §7.1 La tabla
- §7.2 Las siete preguntas, respondidas
- §7.5 ¿Por qué no alcanza con una sola clase plana?
- §7.6 ¿Cuándo la clase única es la correcta, y cuál es el término medio?
- §8.2 ¿Las carpetas hacen cumplir la regla?
- §8.3 Referencias permitidas entre proyectos
- §8.4 ¿En qué idioma se nombra y con qué sufijo?
- §8.5 ¿Contracts desde el primer día o cuando aparece el cliente?
- §8.6 Pregunta de cierre
- §9.1 Mapa de entrada: ¿dónde está el problema?
- §9.3 ¿Cuándo subir un escalón y cuándo es sobreingeniería?
- §9.5 El problema conductor, resuelto
- §9.7 El criterio, en una línea

## 2. Las cinco secciones «Definiciones» (1.1, 3.1, 4.1, 5.1, 6.1)

49 viñetas de definición; **ninguna de las cinco secciones tiene un bloque de código**. La asociación definición↔snippet, cuando existe, está en otra sección (p. ej. Entity en §3.3, Handler en §4.5). Es el dato central para Q1.

## 3. Marcas de procedencia

13 `[Compilado]`, 10 `[Fragmento ilustrativo]`, 18 `Salida registrada`. Todo bloque C# nuevo debe caer en una de las dos primeras (§0.5 de la guía).

## 4. Preguntas guía

7 «Pregunta de cierre» (una por capítulo 1–8; el capítulo 9 cierra con §9.7) y 43 secciones con «**Respuesta:**». No hay preguntas guía intermedias con respuesta dentro de las secciones largas (§4.10, §9.6). Dato para Q3.

## 5. Diagramas

7 mermaid: diagramas 1, 1a, 2, 3, 4, 5, 6. Capítulos 3, 4 y 7 no tienen ninguno. Dato para Q4.

## 6. Referencias y enlaces

38 referencias en Anexo E; 114 enlaces internos, todos resuelven (verificación del PR #7). Citas textuales verificadas en la web durante la v2.0.2 (registro en la conversación de origen; las de la v2.0.1 en `OUTPUTs/Bitacora/`).
