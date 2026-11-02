# E7 · De caso a regla

> Etapa E7 del plan integrado (`../05-Plan-Integrado.md` §5, E7; C-5.5). Registro de sólo agregado.
> Fecha: 2026-11-01. Traza cada hallazgo de E5 (Geometría, `../Ejecucion/E5.md` §7) y de E6 (caso privado,
> sólo sus reglas abstractas, `../Ejecucion/E6.md` §2) a la regla general del Conocimiento v1
> (`Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Conocimientos/knowledge-AI-Layer-Integration-Designing-Specification.md`, en Lab-Documentos).
> Las secciones «§» son las del v1. Por C-7.3, el caso privado figura sólo como «un servicio privado de
> notificaciones» y sus reglas se escriben sin detalle del caso.

## Índice

- [1. Definiciones](#1-definiciones)
- [2. Hallazgos de E5 (Geometría)](#2-hallazgos-de-e5-geometría)
- [3. Hallazgos de E6 (caso privado, abstracto)](#3-hallazgos-de-e6-caso-privado-abstracto)
- [4. Hallazgos de la prueba de autocontención](#4-hallazgos-de-la-prueba-de-autocontención)
- [5. Conteo y aceptación](#5-conteo-y-aceptación)

## 1. Definiciones

- **Hallazgo:** lo que faltó, sobró o confundió al aplicar el v0 (o el v1 en prueba) sin la guía.
- **Regla:** el texto general del v1 que lo resuelve para cualquier caso, sin nombrar el caso.
- **Decisión:** cuando no se escribe regla, el motivo registrado.
- **Marca de origen** en el v1: `[Caso G]` (Geometría), `[Caso N]` (servicio privado de notificaciones),
  `[Prueba]` (prueba de autocontención).

## 2. Hallazgos de E5 (Geometría)

| K | Sev. | Hallazgo (resumen) | Regla o decisión en el v1 | § v1 |
|---|---|---|---|---|
| G-K01 | P1 | códigos ESC/CTX/ACT sin catálogo | catálogo de escenarios, contextos y actores; «no inventar códigos: el más cercano y anotarlo» | §3 |
| G-K02 | P1 | árbol binario en «¿alcanza una regla?» | rama «en parte»: la regla es el respaldo y el modelo debe superarla | §1, Figura 1.1 |
| G-K03 | P1 | escalera de conocimiento no listada | tabla K0–K3, −1 y carril aparte, con criterio de salto | §3 |
| G-K04 | P2 | *rechazado* supone que la capacidad escribe | tabla de resultados con columna «capacidad que sólo genera texto»: *rechazado* cae al respaldo | §5 |
| G-K05 | P1 | ficha A.11 sin campos | ficha de riesgo con sus nueve campos | §10 |
| G-K06 | P2 | ASI09 sólo desde A1 | variante «A0 con persona que firma» y ASI09 activado en ella | §3, §10 |
| G-K07 | P1 | LLM09 omitido sin motivo | fila LLM09 y regla «riesgos no listados: se agregan o se excluyen con motivo, nunca en silencio» | §10 |
| G-K08 | P2 | la prueba «sin terceros» deja pasar el SDK | «la prueba nombra el SDK de IA explícitamente»; criterio de REQ-IA-01 | §4, §9 |
| G-K09 | P2 | el script no distingue prueba escrita de especificada | columnas Tipo y Estado de la prueba | §9 |
| G-K10 | P2 | sin minimización del pedido | R-02 y REQ-IA-15; C-13 pide datos mínimos | §2, §9, §12 |
| G-K11 | P1 | sin patrón para texto libre | patrón «filtro determinista posterior + plantilla» y REQ-IA-13 | §5, §9 |
| G-K12 | P2 | el filtro no ve lo dicho en palabras | R-04 y C-19 | §2, §12 |
| G-K13 | P2 | sin paso de normas del repo | paso 0 del procedimiento y C-00 | §11, §12 |
| G-K14 | P3 | lista larga de NO APLICA en A0; §5 no aplica a web de servidor | requisitos base agrupados por nivel; fila «aplicación web renderizada en el servidor: no aplica» | §9, §6 |

## 3. Hallazgos de E6 (caso privado, abstracto)

| K | Sev. | Hallazgo (resumen) | Regla o decisión en el v1 | § v1 |
|---|---|---|---|---|
| N-K01 | P1 | sin regla de inquilino | R-01, REQ-IA-18 (grupo 0, si hay varios inquilinos), ASI03 y C-18 | §2, §9, §10, §12 |
| N-K02 | P1 | capas de referencia que un existente no tiene | tabla de correspondencia de capas en CTX-EXISTENTE; requisitos con nombres reales | §4, §11 paso 4 |
| N-K03 | P2 | sin hoja para herramientas sin escritura | A1 lectura y A1 escritura en el árbol y en la escalera; ASI09 no se activa en A1 lectura | §1, §3, §10 |
| N-K04 | P1 | nada ancla una respuesta libre que afirma datos | R-03 (anclaje) y REQ-IA-14; LLM09 | §2, §5, §9, §10 |
| N-K05 | P2 | sin inventario ni categoría irreversible y masiva | inventario de capacidades con estado; R-07 y REQ-IA-20 | §7, §2, §9 |
| N-K06 | P2 | inyección indirecta desde datos internos | R-05 y REQ-IA-19 | §2, §9 |
| N-K07 | P2 | caso de uso sin el filtro necesario | R-06: la brecha va a deuda; proyectar lo acotado sí, traer todo no | §2 |
| N-K08 | P1 | ADR mínimas con número fijo | ADR mínimas por tema (ADR-LLAMADA, -PROVEEDOR, -CAPAS, …) numeradas por el proyecto | §8 |
| N-K09 | P3 | falta nacer apagada | R-08 y REQ-IA-17 | §2, §9 |
| N-K10 | P3 | decisión escrita frente a firmada | campo Firma de la ADR; SÍ firmado o pendiente; PROD exige firma | §8, §12 |

## 4. Hallazgos de la prueba de autocontención

Salidas de las tres rondas en `Prueba-De-Autocontencion.md` y `Evidencia/`. Ronda 1 (A1), ronda 2 (A2 y B2),
ronda 3 (A3 y B3). Se corrigió entre rondas lo atribuible al conocimiento.

| Id | Sev. | Ronda | Hallazgo | Regla o decisión en el v1 | § v1 |
|---|---|---|---|---|---|
| T-01 | P2 | 1 | filas NO APLICA sin criterio hacían fallar el verificador | la fila conserva su criterio; «—» en niveles, tipo y estado | §9 |
| T-02 | P1 | 1 | la Figura de contenedores contradecía «Application no referencia Infrastructure» | Persistence implementa repositorios de Application (flecha invertida) | §4 |
| T-03 | P2 | 1 | rol de negocio fuera del catálogo ACT | los actores son roles; la persona toma el rol que ejerce | §3 |
| T-04 | P2 | 1 | línea base cuando el respaldo es manual | la persona medida sobre el mismo conjunto | §1 |
| T-05 | P2 | 1 | piloto sobre servicio en producción | PROTO/PROD se dice de la capacidad; piloto = CTX-PROTO con R-08 | §3 |
| T-06 | P2 | 1 | datos personales dentro del texto libre | R-02: CTX-SENS y ACT-SEC decide si se enmascara | §2 |
| T-07 | P1 | 2 | dato exacto pedido en lenguaje libre | arista del árbol a A1 lectura (carril aparte); si una pantalla de filtros alcanza, −1 | §1 |
| T-08 | P1 | 2 | «sólo diseño» sin reglas | exige sólo su fila con nivel previsto y motivo | §7 |
| T-09 | P1 | 2 | REQ-IA-18 sólo en A1 | pasa al grupo 0, si hay varios inquilinos; C-18 por capacidad especificada | §9, §12 |
| T-10 | P1 | 2 | matriz A0 remitía a requisitos de A1 | REQ-IA-21 (largo, concurrencia, sin reintentos); LLM01 y LLM10 con requisito por nivel; LLM09 también al clasificar | §9, §10 |
| T-11 | P2 | 2 | formato inválido sin resultado definido | *rechazado* | §5 |
| T-12 | P2 | 2 | A0 con persona que firma sólo para borradores | también una propuesta que una persona confirma | §3 |
| T-13 | P1 | 2 | verificador y herramienta de mermaid sin definir | reglas del verificador escritas en §9; se aplica a mano si no hay script | §9 |
| T-14 | P2 | 2 | checklist sin forma de marcar omisiones con motivo | NO con motivo no bloquea en DEBERÍA/PUEDE; «parcial» = NO | §12 |
| T-15 | P2 | 2 | rol sin designar | «pendiente de firma de ACT-x»; en PROD es NO | §12 |
| T-16 | P3 | 2 | Estado de ADR sin «propuesta» | propuesta, vigente o reemplazada | §8 |
| T-17 | P2 | 2 | R-06 sólo para herramientas | rige también para el código de una capacidad A0 | §2 |
| T-18 | P2 | 2 | C-00 con normas que existen pero no están a la vista | NO con la lista de lo que falta | §12 |
| T-19 | P1 | 2 | C-17 sin exigir valor | «umbral con su valor» | §12 |
| T-20 | P1 | 3 | línea base frente a umbral; denominador | C-17: métrica con denominador; en «en parte», umbral y no peor que la línea base; REQ-IA-12 informa la comparación | §12, §9 |
| T-21 | P2 | 3 | capacidad que sale en −1 dentro de un servicio con capa | estado «sin modelo» del inventario y ADR-SIN-IA por capacidad | §7, §8 |
| T-22 | P2 | 3 | quién aplica las reglas; entrada sobre el tope | formato y filtros, el adaptador; reglas del dominio, el caso de uso; sobre el tope, *degradado* | §5 |
| T-23 | P2 | 3 | niveles de REQ-IA-09, 12, 17 contra reglas del propio conocimiento | 09 DEBE con CTX-SENS; 12 y 17 DEBE en PROTO | §9 |
| T-24 | P2 | 3 | C-13 sin propuesta | la especificación propone una opción y ACT-SEC la firma | §12 |
| T-25 | P2 | 3 | R-01 con rol global ambiguo | el rol global elige el inquilino en un paso validado por el código | §2 |
| T-26 | P2 | 3 | riesgos no listados sin control | **decisión:** sin regla; el v1 dice que LLM03, LLM04 y LLM07 no traen control (§14); la guía no los asigna y no se inventa | §10, §14 |
| T-27 | P3 | 1–3 | medir sin sesgo cuando la persona ve la propuesta; consentimiento | **decisión:** límite declarado, es de ACT-SEC y del proyecto | §14 |
| T-28 | P3 | 1–3 | paquete del adaptador, sincronía, reintentos del mecanismo de tareas | **decisión:** fuera de alcance (implementación; la guía no decide la sincronía) | §0, §14 |

## 5. Conteo y aceptación

| Origen | P0 | P1 | P2 | P3 | Con regla | Con decisión | Sin regla ni decisión |
|---|---|---|---|---|---|---|---|
| E5 (G-K01…14) | 0 | 6 | 7 | 1 | 14 | 0 | 0 |
| E6 (N-K01…10) | 0 | 4 | 4 | 2 | 10 | 0 | 0 |
| Prueba (T-01…28) | 0 | 8 | 17 | 3 | 25 | 3 | 0 |

Criterio del plan «0 hallazgos P0/P1 de E5–E6 sin regla o sin decisión registrada»: **cumple** (10/10 P1 con regla).
