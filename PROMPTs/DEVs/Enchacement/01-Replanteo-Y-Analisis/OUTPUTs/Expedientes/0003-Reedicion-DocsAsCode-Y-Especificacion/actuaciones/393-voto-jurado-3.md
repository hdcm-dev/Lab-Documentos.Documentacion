---
doc_id: EXP0003-F393
doc_type: voto
title: Voto del jurado 3 de 3 del ciclo 3 — audiencias (A-01 a A-15) y paneles, portales y formularios (B-01 a B-12)
status: emitido
origin: agent
confidence: alta en lo citado de F300, F380, F381 y F385; alta en las dos fuentes reabiertas hoy por este jurado (§9); media en las condiciones, que son juicio de esta silla
owner: presidencia de la reedición DocsAsCode (expediente 0003), jurado 3 del ciclo 3
last_review: 2026-11-02
audience: [presidencia, jurado del ciclo 3, refutador, PO]
traces: [EXP0003-F099, EXP0003-F204, EXP0003-F300, EXP0003-F380, EXP0003-F381, EXP0003-F385]
---

| Campo | Valor |
| --- | --- |
| Tipo | voto |
| Fecha | 2026-11-02 (encargo fechado 2026-11-01) |
| Autor | Jurado 3 de 3, a ciegas respecto de los jurados 1 y 2 (no se abrieron F391 ni F392) |
| Corrige | — |

**Alcance de la lectura.** Se leyeron completos `F300`, `F385` y los tableros, el detalle por pregunta y el impacto
de `F380` y `F381`. Los informes `F310`–`F376` se leyeron a través de lo que citan los dos análisis y el refutador
(486 kB en total); donde este voto depende de un informe, cita el análisis que lo resume. Firmeza según R-06 de
`F099` §4; este jurado adopta la regla de R3-08: **FIRME sólo si los dos analistas coinciden en ganadora y firmeza y
ningún ataque P0/P1 la alcanza**; si no, CON REVISIÓN.

## 1. Sobre el refutador (F385)

| Ataque | Decisión | Motivo |
| --- | --- | --- |
| R3-01 P0 fuente en repo público | **Acepta** | Es un hueco real: el acceso se mide en tres puntos (repo, build, servidor). Entra la regla `nivel-vs-repo` en D-18 y el control en `docs-guard`; el ejemplo público usa contenido ficticio rotulado |
| R3-02 P0 variantes en `.resx` compilado | **Acepta** | La guía de Blazor (§9, fuente 2) confirma que en WebAssembly los ensamblados satélite se cargan en el cliente. Variantes de nivel > `producto` nunca en recursos distribuidos; se sirven por API con el token del usuario; control sobre el paquete construido. B-11 baja a CON REVISIÓN |
| R3-03 P1 síntesis del analista | **Acepta en parte** | i3 y v3 no entran a `K` como FIRME; sí entran como regla condicional marcada «propuesta de la mesa, sin puntuar por comisión», porque el contenido de v3 coincide con aa1 de CA-7 (F381) |
| R3-04 P1 `audiencias:` junto a `audience:` | **Acepta** | Clave inglesa no confundible: `delivery:`; control que rechace `audiencias`/`audiences`; limpieza de `agente` en `audience` del cuerpo en el mismo PR que A-04 |
| R3-05 P1 404 no es convergencia | **Acepta** | Verificado hoy: Redocly da 403 a quien tiene sesión sin el equipo y redirige al login a quien no la tiene (§9, fuente 1). Regla: «no entrega del contenido», 403 o 404 a elección declarada; prueba pareada autorizado 200 / no autorizado ≠ 200 sin contenido |
| R3-06 P1 ronda 3 confunde la causa | **Acepta con forma propia** | Ronda 3 con dos brazos declarados antes de sellar: brazo A casos sin roles/API/formulario (mide las correcciones de 1.2→1.3 sin D-18), brazo B casos con roles (mide D-18). *n* por brazo fijado en el folio previo |
| R3-07 P1 capítulos contra el plan | **Acepta en parte** | Se permiten capítulos nuevos, pero sólo con un apéndice a `F099` §5.2 que renumere IV–VI y anexos y revise el presupuesto L3, antes de tocar L3 |
| R3-08 P2 firmeza de una mano | **Acepta** | Regla adoptada arriba |
| R3-09 P2 controles sin par | **Acepta** | Ningún control bloquea sin par rojo/verde medido en la PoC-R; hasta entonces avisa |
| R3-10 P2 283 vs 30 | **Acepta** | Corrige el costo de b2/m2; no cambia la ganadora porque R3-04 la reformula |
| R3-11 P2 ID de contexto sin espacio de nombres | **Acepta** | `contexto: <app>/<id>`, siguiendo `@appname`+`@appid` de DITA (F385 §2 fuente 8) |
| R3-12 P3 complejidad | **Acepta** | Perfil mínimo obligatorio (roles planos + nivel + `nivel-vs-repo`); jerarquía, alcance, `canal_agente`, `cumple`, contexto, como extensiones activadas por el inventario de D-01 |

## 2. Votos por pregunta — eje A

| Preg. | Voto | Firmeza | Condiciones |
| --- | --- | --- | --- |
| A-01 | a1: **«audiencia»** = conjunto de lectores destinatarios definido por sus necesidades y tareas (ISO/IEC/IEEE 26514 3.1.7 adaptada, **sin verificar** contra la edición publicada); **no es permiso**: a quién se entrega lo dice la **regla de entrega**. Dos términos | FIRME | Glosario: distinguir de lector (humano/agente), rol (del producto), *persona* (UX), actor; «audiencia primaria» como nota, no campo |
| A-02 | Dimensiones ortogonales: **rol, alcance, superficie, nivel de acceso**; derivadas: **jerarquía** (del rol); fuera del acceso: **lector** (canal) e **idioma** (no amplía acceso). Obligatorias: nivel siempre que haya producto; rol en ESC-SDEI-3; alcance y superficie sólo si el inventario D-01 los registra | FIRME | Perfil mínimo de R3-12 |
| A-03 | Decisión nueva; Marco §2.5 pasa a «Audiencias típicas»; «agente» sale de la fila | FIRME | — |
| A-04 | Lector como dimensión; `TEM-04` sigue como tema propio, renombrado «Lectura por agentes» | FIRME | El agente hereda la audiencia de su usuario, nunca tiene acceso propio |
| A-05 | Jerarquía declarada una vez (`incluye:`) y expandida en el build; cruce abajo→arriba = rojo | FIRME | Cambiar la jerarquía = H con reserva |
| A-06 | Cuatro niveles con punto de aplicación en **tres** puntos (repo, build, servidor) + pruebas negativas pareadas | CON REVISIÓN | R3-01 y R3-05 |
| A-07 | Documento OpenAPI por exposición; exponer = H; cada ensanchamiento = H por cambio; UI interactiva sólo en desarrollo | CON REVISIÓN | AD-A y AD-B difieren en firmeza; marca por propiedad sólo si la PoC la emite |
| A-08 | Tipo de alcance en el repo, valores en el producto; cruce de alcance = prueba del producto + barrido de literales | FIRME | Enmienda §6.3 de F300 |
| A-09 | Una fuente; salidas por superficie; paquete instalable sólo `publico` (texto **y** recursos compilados) | CON REVISIÓN | R3-02 obliga a sumar los recursos al control de paquete |
| A-10 | Filtro único como norma; `canal_agente: ninguno` por defecto en lo no público | CON REVISIÓN | Rotulado propuesta de la mesa (R3-03); se abre «por sesión» si AG-3 da verde con dos sesiones en la PoC-R |
| A-11 | Familias unificadas de F380 §5 A-11 + `nivel-vs-repo` + `delivery-clave-cercana`; dos escalones | CON REVISIÓN | Bloquean sólo con par medido (R3-09) |
| A-12 | D-18 «Audiencias y entrega»: registro fuente, matriz derivada; campo de página `delivery:` | CON REVISIÓN | R3-04 |
| A-13 | Ver §4 | CON REVISIÓN | R3-07 |
| A-14 | Ver §6 | CON REVISIÓN | R3-06 |
| A-15 | Extender `Prueba-Ayuda-Por-Rol` (PoC-R) | FIRME | Contenido ficticio rotulado (R3-01); incluye par de `nivel-vs-repo` y de recursos en paquete |

## 3. Votos por pregunta — eje B

| Preg. | Voto | Firmeza | Condiciones |
| --- | --- | --- | --- |
| B-01 | Escalera de capas con vocabulario cerrado `etiqueta · pista · info · ejemplo · validacion`; nada esencial en marcador ni *tooltip* | FIRME | Fuentes GOV.UK y NN/g confirmadas por F385 §2 |
| B-02 | Números interpolados de la regla; letra escrita («derivar no es generar») | FIRME | — |
| B-03 | Traza desde la ficha con anclas `muestra`/`valida`/`contiene`; catálogo como opción de D-13 | FIRME | Reemplaza «no se ancla» de D-13 sólo cuando exista el resolvedor |
| B-04 | Canal «punto de uso» de `CL-06`, no clase nueva | FIRME | — |
| B-04b | Sección nueva de `TEM-05` | CON REVISIÓN | Se vuelve tema propio sólo si supera un tercio de `TEM-05` |
| B-05 | Anclas + límite interpolado; `rule-text-drift` como prueba del producto donde la regla no está en atributos | CON REVISIÓN | Firmeza discrepante entre analistas |
| B-06 | Etiqueta y error iguales para todas las audiencias; variantes justificadas sólo en pista/ayuda ampliada; resolución en servidor | FIRME | Traducción atrasada: avisa |
| B-07 | ID de contexto estable en el frontmatter con espacio de nombres `contexto: <app>/<id>`; mapa derivado; el enlace panel→portal no transfiere permiso | CON REVISIÓN | R3-11; pasa a archivo aparte si una misma pantalla resuelve a páginas distintas por audiencia sin duplicar |
| B-08 | Plataformas de guía en producto sólo como canal que dirige; nunca con lo no público | CON REVISIÓN | Se activa sólo si el PO pide recorridos |
| B-09 | `aria-describedby` probado en pruebas de interfaz; `docs-guard` sólo exige etiqueta y error | FIRME | Es agregado: 3.3.2 no exige asociación programática (lo hacen 1.3.1/4.1.2) |
| B-10 | Regla condicional: si hay asistente, misma pieza, token del usuario, cita `ID@versión`, sugiere y no envía | CON REVISIÓN | R3-03; no obligatorio si no hay asistente |
| B-11 | `[Display]`/`.resx`/localizador por audiencia **sólo en servidor**; variantes no públicas nunca en recursos distribuidos | CON REVISIÓN | R3-02; vuelve a FIRME con el par rojo/verde sobre APK y `_framework` |
| B-12 | Formulario en la PoC-R extendida | CON REVISIÓN | Se suma la mini demo si su rojo sale sin tocar el código fijado por SHA |

## 4. Pronunciamientos explícitos

1. **Término y definición.** «Audiencia» (A-01 arriba) y su par **«regla de entrega»**. Audiencia orienta; la regla
   de entrega protege.
2. **Dimensiones.** A-02 arriba: cuatro ortogonales, una derivada, dos fuera del acceso.
3. **¿Tema nuevo o reescribir TEM-04/TEM-05?** **Reescribir, sin tema nuevo en este ciclo.** `TEM-05` absorbe la
   entrega y la sección «Ayuda en el punto de uso»; `TEM-04` pasa a «Lectura por agentes». El modelo de audiencias
   vive en el Marco (§2.5) y en el glosario; un tema `TEM-nn Audiencias y entrega` se abre recién si `TEM-05`
   reescrito supera el doble de su largo actual.
4. **Decisiones y artefactos de `K`.** D-18 nueva «Audiencias y entrega» (registro, nivel, `nivel-vs-repo`,
   exposición H por cambio, perfil mínimo + extensiones); D-01 inventaría audiencias, alcances, superficies y
   documentos OpenAPI; D-13 suma el canal punto de uso; §2.3 remite a D-18; A-01 con sección de audiencias; A-03
   con `delivery` cerrado al registro. Artefactos: plantilla del registro, tabla de familias de controles con
   estado avisa/bloquea.
5. **Libro.** Parte III con tres capítulos: 7 «Audiencias y entrega» (nuevo), 8 «Lectura por agentes», 9 «Ayuda al
   usuario final» con 9.x punto de uso (k1/n2). No cuatro: el punto de uso es «muy interesante» para el PO pero hoy
   no tiene material medido propio; se separa si el lote L3 lo deja por encima de un tercio del cap. 9. API
   restringida como sección del 7 y del 18. **Condición previa**: apéndice a `F099` §5.2 con la renumeración y el
   presupuesto L3 (R3-07).
6. **Ensayos.** Se **re-sellan** sólo los oráculos de casos con roles, API o formulario, con versión nueva por
   decisión nueva; criterio de caso de `F204` sin cambio; la ronda 3 corre con `K` 1.3 **en dos brazos declarados**
   (R3-06). No hay ronda adicional.
7. **Orden de trabajo.** (1) `F399` + apéndice a `F099` §5.2; (2) PR de vocabulario y cuerpo: glosario, esquema
   (`delivery`, `contexto`), Marco, `TEM-04`, `TEM-05`, `TEM-06` con controles en «avisa»; (3) PoC-R extendida con
   los pares rojo/verde (incluye `nivel-vs-repo` y recursos en paquete); (4) expediente de herramienta `docs-guard`:
   los controles con par pasan a bloquear; (5) `K` 1.3 citando 2–3; (6) oráculos re-sellados y ronda 3 en dos
   brazos; (7) libro, lote L3. La PoC va antes de `K` porque cinco condiciones de este voto se resuelven en ella.

## 5. Recuento

27 votos (A-01…A-15, B-01…B-12, con B-04b): **13 FIRME, 14 CON REVISIÓN**. Ningún voto contra la ganadora de los
dos análisis donde coinciden; se cambian la clave del campo (`delivery`), el 404 por «no entrega», el espacio de
nombres del contexto y la forma de la ronda 3.

## 9. Fuentes reabiertas hoy por este jurado

| # | Fuente | Qué confirma |
| --- | --- | --- |
| 1 | https://redocly.com/docs/realm/access/page-permissions (2026-11-02) | «Users who are not signed in are redirected to the login page»; «Signed-in users who lack the required team see a 403 Forbidden page» |
| 2 | https://learn.microsoft.com/en-us/aspnet/core/blazor/globalization-localization (2026-11-02; act. 2026-10-31) | En WebAssembly la cultura se aplica «on the client before satellite assemblies load»: los satélites se cargan en el cliente |

Sin verificar por este jurado: ISO/IEC/IEEE 26514:2022 3.1.7; empaquetado de satélites en MAUI Android.

## 10. Mensajes e incidencias

No llegaron mensajes de otras sesiones durante este voto.

## 11. Barrido de lo privado

Sin nombres de máquina ni rutas locales; el caso real va como `{servicio-privado}`.
