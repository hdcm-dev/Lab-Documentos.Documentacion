---
doc_id: EXP0003-F391
doc_type: voto
title: Voto del jurado 1 del ciclo 3 — audiencias (eje A) y ayuda en paneles, portales y formularios (eje B)
status: vigente
origin: agent
confidence: alta en lo leído de F300, F380, F381 y F385 y en las dos fuentes reabiertas hoy (§2); media en las condiciones, que son juicio de esta silla y van con su motivo
owner: jurado del ciclo 3, silla 1
last_review: 2026-11-02
audience: [presidencia, jurados 2 y 3 del ciclo 3 (después de votar), refutador, PO]
traces: [EXP0003-F099, EXP0003-F204, EXP0003-F300, EXP0003-F310, EXP0003-F320, EXP0003-F330, EXP0003-F340, EXP0003-F350, EXP0003-F360, EXP0003-F370, EXP0003-F374, EXP0003-F376, EXP0003-F380, EXP0003-F381, EXP0003-F385]
---

| Campo | Valor |
| --- | --- |
| Tipo | voto |
| Fecha | 2026-11-02 (encargo del 2026-11-01; hubo un corte de energía en el medio) |
| Autor | Jurado 1 de 3. Voto a ciegas: no leí a los jurados 2 y 3 |
| Leído | `F300`; los informes `F310`–`F376` a través de los tableros de `F380` y `F381`; `F385` completo; `F099` §5.2 y `F204` §1 y §9, por la forma en que los citan los folios |

Convención: igual que `F380`. Firmeza según R-06 de `F099` §4: **FIRME** solamente si AD-A y AD-B eligen la misma
ganadora con FIRME y ningún ataque P0/P1 de `F385` la alcanza (con eso adopto R3-08). Si no, va **CON REVISIÓN** y
lleva una condición que se pueda comprobar.

## 1. Pronunciamientos que pidió la presidencia

1. **Término y definición.** El término es «audiencia». La definición es la de ISO/IEC/IEEE 26514 3.1.7 adaptada
   (a1 en ambos análisis). Además entra un segundo término: «regla de entrega». **Audiencia no es permiso**: la
   audiencia orienta la escritura, y la regla de entrega decide quién recibe el contenido. Aclaración: no tuve acceso a la
   edición publicada de la norma, así que la cita queda **sin verificar** (como ya marcaron `F380` y `F385`). «Audiencia primaria
   o secundaria» va como nota del glosario y no como campo.
2. **Dimensiones.** Son cuatro dimensiones de entrega, ortogonales entre sí:
   - **rol**, con su jerarquía declarada una vez y expandida en el build;
   - **tipo de alcance** (`generico` o `por-aplicacion`), con los valores en el producto;
   - **superficie**;
   - **nivel de acceso** (`publico`, `producto`, `restringido`, `interno`).

   **Lector** (persona o agente) es una dimensión de canal y no de acceso. **Idioma** no amplía el acceso. **Pericia** queda
   opcional. Obligatoriedad: el nivel se exige siempre que haya producto; rol y jerarquía, en `ESC-SDEI-3`; alcance y
   superficie, sólo si el inventario de D-01 los registra. Para el caso real de `{servicio-privado}` alcanza el perfil mínimo de
   R3-12: tres roles (administrador raíz, administrador por aplicación, integrador), alcance `por-aplicacion`, dos
   superficies (panel/portal y app móvil) y nivel.
3. **Tema nuevo o reescritura.** **No** se agrega un tema nuevo: se reescriben `TEM-04` y `TEM-05`.
   - `TEM-04` pasa a llamarse «Lectura por agentes»: el agente hereda la audiencia de su usuario, hay un filtro único y
     el MCP lee con el token del usuario.
   - `TEM-05` reemplaza `roles` por la regla de entrega y suma la sección «Ayuda en el punto de uso» (u1 de B-04b).
   - `TEM-06` recibe los controles.
   - `00-Marco.md` §2.5 cambia «Audiencias» por «Audiencias típicas» y saca a «agente» de esa fila.

   Motivos: B-04 (canal de `CL-06`, no clase nueva) se eligió casi por unanimidad, y R3-07 muestra que un tema nuevo arrastra la renumeración del libro.
4. **Decisiones y artefactos del conocimiento (`K` 1.3).**
   - **D-18 «Audiencias y entrega»**, nueva. Lleva: registro de audiencias con `incluye:`; los cuatro niveles, cada uno con su punto de
     aplicación; la regla **nivel ≤ visibilidad del repo de la fuente** (R3-01); exposición de API H, y ensanchar es **H
     por cambio**; variantes de nivel > `producto` **nunca** en recursos que viajan al cliente (R3-02).
   - D-01 inventaría audiencias, alcances, documentos OpenAPI y superficies.
   - D-12 remite al filtro único.
   - D-13 suma «punto de uso»: capas `etiqueta · pista · info · ejemplo · validacion`; números interpolados; traza desde la ficha;
     el catálogo como opción. Quita la frase «no se ancla» recién cuando exista el resolvedor.
   - §2.3 remite a D-18.
   - A-01 lleva la sección de audiencias.
   - A-03 cierra el campo de entrega al registro.

   Artefactos: plantilla del registro, matriz derivada y tabla de nombres de controles (j1).
5. **Cambios al libro.** Ni k1, ni k2, ni n2 **por ahora**. Acepto R3-07: la Parte III conserva los caps. 7 y 8. El 7 pasa a
   «Audiencias y lectura por agentes». El 8 «Ayuda al usuario final» suma 8.x «Ayuda en el punto de uso: pantallas,
   campos, paneles y portales». La API por exposición entra como sección del 7 y como caso del 18. El 1.5 se reescribe, el 3.2
   recibe la fila nueva, el 14 la PoC-R extendida y los anexos A, C y G se actualizan. El presupuesto de L3 se revisa en una línea de `F399`. **Condición**: si el
   borrador de L3 supera ese presupuesto o el 8.x pasa de un tercio del cap. 8, se abre un apéndice a `F099` §5.2 con la
   numeración nueva **antes** de redactar (con eso se atiende el «me interesa mucho» del PO sobre el eje B).
6. **Re-sello de ensayos.** Se re-sellan **sólo** los oráculos de casos con roles, API o formulario (l1/o1, con la fila
   D-18 y la de D-13 «microtexto»). Es versión nueva por decisión nueva y no corrección. **Acepto R3-06**: la ronda 3 de `F204` §9 se
   declara con **dos brazos** en el folio previo, casos sin roles (prueban las correcciones de la ronda 2) y casos con
   roles (prueban D-18), con *n* y umbrales fijados antes de correr. El criterio de caso no cambia y no hay ronda adicional.
7. **Orden de trabajo.**

   | # | Pieza | Depende de |
   | --- | --- | --- |
   | 1 | `LD`: glosario, Marco §2.5/§4, esquema de frontmatter (campo nuevo, sin migración), limpieza de `agente` en `audience` | `F399` |
   | 2 | `LD`: `TEM-04`, `TEM-05`, `TEM-06` (controles en «avisa») | 1 |
   | 3 | `K` 1.3, que cita líneas de 1–2 | 2 |
   | 4 | Oráculos re-sellados y folio previo de ronda 3 con dos brazos; la ronda 3 corre | 3 |
   | 5 | Expediente de herramienta `docs-guard` (familias de j1 con par rojo/verde, `nivel-vs-repo`, resolvedor `.resx`/JSON Schema) | 2 |
   | 6 | PoC-R extendida (m1/p1/cc1) con contenido ficticio, el par del APK y la prueba negativa de entrega | 5 |
   | 7 | Libro: lotes de la Parte III y afectados | 2 y 6 |

   La ronda 3 no espera a 5 ni a 6, como dice `F381` §8. Los controles se vuelven bloqueantes recién con su par corrido (R3-09).

## 2. Fuentes reabiertas hoy por esta silla

| Fuente | Lo que sostiene | Resultado 2026-11-02 |
| --- | --- | --- |
| https://redocly.com/docs/realm/access/page-permissions | «Users who are not signed in are redirected to the login page»; quien tiene sesión sin el equipo ve «403 Forbidden»; no menciona 404 | Confirma R3-05 |
| https://design-system.service.gov.uk/components/text-input/ | «Use hint text for help that's relevant to the majority of users»; «Do not use links in hint text»; «Do not use placeholder text in place of a label, or for hints or examples» | Confirma B-01 |

Las demás fuentes externas las tomo como las dejó `F385` §2, que las reabrió el 2026-11-02. Esta silla no las abrió
de nuevo.

## 3. Votos por pregunta

| Preg. | Voto | Firmeza | Condiciones | Ataques de `F385` |
| --- | --- | --- | --- | --- |
| A-01 | a1: audiencia + regla de entrega | FIRME | Cita ISO rotulada «sin verificar» hasta tener la edición publicada | Ninguno lo alcanza (`F385` §6) |
| A-02 | Cuatro dimensiones de §1.2; lector como canal | FIRME | Perfil mínimo por escenario (R3-12) | **Acepto R3-12** como perfil mínimo; el resto es extensión por escenario |
| A-03 | Decisión nueva D-18; Marco «Audiencias típicas» | FIRME | — | — |
| A-04 | Lector como dimensión; `TEM-04` sigue y se renombra | FIRME | Al mismo PR va la limpieza de `agente` en `audience` (`00-Marco.md`, `TEM-04`) | **Acepto R3-04 (c)** |
| A-05 | Jerarquía con `incluye:`, expandida en el build | FIRME | Cambiar la jerarquía = H con reserva | — |
| A-06 | Niveles con punto de aplicación medido en **tres** puntos (repo, build, servidor) + pruebas negativas | CON REVISIÓN | La prueba exige «no entrega del contenido» (403 o 404, elegido y declarado) y compara contra el mismo URL con usuario autorizado (200 con contenido) | **Acepto R3-01** (`nivel-vs-repo`, ejemplo ficticio) y **R3-05** (Redocly confirmado hoy) |
| A-07 | f1/g1: exposición por operación, contrato por exposición, ensanchar = H por cambio | CON REVISIÓN | Si la PoC no puede emitir la marca por propiedad con `AddOpenApi`, se queda en operación y la propiedad avisa | No hay ataque; `F385` §6 dice que la fuente 1 refuerza `contrato-por-exposicion` |
| A-08 | g1/h1: tipo de alcance en el repo, valores en el producto | FIRME | Contexto con espacio de nombres `<app>/<id>` (ver B-07) | — |
| A-09 | Una fuente; paquete instalable sólo `publico` | CON REVISIÓN | Firme cuando el control de APK/`_framework` dé rojo con una clave restringida y verde sin ella | **Acepto R3-01 y R3-02**: «paquete» incluye recursos compilados |
| A-10 | Filtro único como norma (j1 de AD-B). `canal_agente: ninguno` por defecto en lo no público, **como propuesta** | CON REVISIÓN | i3 vuelve a CA-7 para que lo puntúe; si AG-3 pasa con dos sesiones en la PoC-R, puede entrar en `K` 1.4 | **Acepto R3-03** |
| A-11 | j1/k1: familias con nombre unificado, dos escalones | CON REVISIÓN | Ningún control bloquea sin par rojo/verde corrido; `indice-sin-fuga` se complementa con prueba de entrega por token | **Acepto R3-09** y R3-08 (los analistas difieren en firmeza) |
| A-12 | D-18 con registro fuente y matriz derivada; `cumple` opcional hasta que su prueba negativa corra | CON REVISIÓN | Igual que la condición de b3 en `F380` | — |
| A-12b | Campo de entrega **nuevo**, sin migración, con clave **`delivery:`** (no `audiencias:`); `audience` queda de orientación | CON REVISIÓN | Control que rechaza `audiencias:`, `audiences:` y variantes cercanas | **Acepto R3-04 (a) y (b)**; **acepto R3-10**: el costo de migrar se corrige a 30 archivos de `SDEI/`, igual no se migra |
| A-13 | Secciones dentro de los caps. 7–8, sin renumerar (§1.5) | CON REVISIÓN | Apéndice a `F099` §5.2 si se pasa de presupuesto | **Acepto R3-07** |
| A-14 | l1/o1: re-sellar sólo los oráculos afectados; ronda 3 con dos brazos | CON REVISIÓN | *n* y umbrales en el folio previo | **Acepto R3-06** (variante de dos brazos, no la de sacar D-18) |
| A-15 | m1/p1: extender `Prueba-Ayuda-Por-Rol` | FIRME | Contenido ficticio, declarado en el README | **Acepto R3-01 (3)** |
| B-01 | Escalera de capas, vocabulario cerrado | FIRME | — | — (GOV.UK confirmado hoy) |
| B-02 | Números interpolados de la regla, letra escrita | FIRME | — | — |
| B-03 | Traza desde la ficha (`muestra`/`valida`); el catálogo como opción de D-13 | FIRME | — | — |
| B-04 | Canal «punto de uso» de `CL-06`; sección en `TEM-05` | FIRME (clase) / CON REVISIÓN (lugar) | Si la sección supera un tercio de `TEM-05`, se discute tema propio en otro ciclo | — |
| B-05 | q1/v1: anclas con `contiene` + límite interpolado; q2 como prueba unitaria del producto | CON REVISIÓN | — | — |
| B-06 | Etiqueta y error iguales; variantes justificadas; resueltas en servidor | FIRME | Nunca todas las variantes al cliente | Refuerza R3-02 |
| B-07 | ID de contexto en el frontmatter como **`contexto: <app>/<id>`**, mapa derivado, resolvedor en servidor; el enlace panel→portal no transfiere permiso | CON REVISIÓN | Pasa a s1b (archivo aparte) si una misma pieza necesita resolver distinto por audiencia | **Acepto R3-11** |
| B-08 | Plataformas sólo como canal que dirige, nunca con nivel no público | CON REVISIÓN | Se activa sólo si el PO pide recorridos; si no, el cuerpo dice «no se usa» | — |
| B-09 | `aria-describedby` probado en la interfaz; `docs-guard` sólo exige etiqueta y error | FIRME | El soporte en `ValidationMessage` de Blazor se mide en la PoC (sin verificar) | — |
| B-10 | **aa3** (nada obligatorio en `K` 1.3). v3 se registra como propuesta para CA-7/CA-8 | CON REVISIÓN | Si `{servicio-privado}` incorpora un asistente, se abre una pregunta con v3 puntuada | **Acepto R3-03** |
| B-11 | w1/bb1 **recortado**: `[Display]` + `.resx` sólo para el nivel ≤ `producto`; las variantes superiores por API con el token del usuario | CON REVISIÓN | Control sobre el APK/`_framework` con par rojo/verde; MAUI y WebAssembly: medir los satélites (sin verificar) | **Acepto R3-02** |
| B-12 | Formulario en la PoC-R extendida; se suma la mini demo si el rojo del 60/80 sale sin tocar código | CON REVISIÓN | — | — |

Ataques que rechazo: ninguno entero. Sólo rechazo una parte de **R3-06**: sacar D-18 de la ronda 3 la posterga sin dar
información; con dos brazos declarados se consigue la atribución que pide el ataque sin perder la ronda.

## 4. Mensajes e incidencias

Durante la redacción no llegaron mensajes de otras sesiones. Incidencia: el corte de energía del 2026-11-01.

## 5. Barrido de lo privado

El servicio figura sólo como `{servicio-privado}`. El folio no tiene nombres de máquina ni rutas absolutas.
