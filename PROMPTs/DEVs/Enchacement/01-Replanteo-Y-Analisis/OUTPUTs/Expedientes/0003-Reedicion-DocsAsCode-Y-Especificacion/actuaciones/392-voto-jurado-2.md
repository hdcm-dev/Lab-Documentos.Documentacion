---
doc_id: EXP0003-F392
doc_type: voto
title: Voto del jurado 2 de 3 del ciclo 3 — audiencias (A-01 a A-15) y paneles, portales y formularios (B-01 a B-12)
status: borrador
origin: agent
confidence: alta en lo citado de F300, F380, F381 y F385; las fuentes externas no las reabrió esta silla: se apoya en las 16 que F385 §2 reabrió el 2026-11-02 y lo dice en cada caso
owner: presidencia de la reedición DocsAsCode (expediente 0003), jurado 2
last_review: 2026-11-02
audience: [presidencia, jurado del ciclo 3, PO]
traces: [EXP0003-F099, EXP0003-F204, EXP0003-F300, EXP0003-F380, EXP0003-F381, EXP0003-F385]
---

| Campo | Valor |
| --- | --- |
| Tipo | voto (a ciegas respecto de los jurados 1 y 3) |
| Fecha | 2026-11-02 (pedido del 2026-11-01; corte de energía en el medio) |
| Leído | `F300` (§5–§7); tableros y §7–§8 de `F380`; tablero de `F381`; `F385` completo; `F099` R-06 |
| Firmeza | R-06 (`F099` §4): FIRME = ventaja ≥ 3 celdas. Esta silla adopta además R3-08: FIRME sólo si AD-A y AD-B coinciden en ganadora **y** ambos dan ≥ 3; si no, CON REVISIÓN con condición comprobable |

## 1. Criterio del voto

Las fuentes de industria citadas abajo son las que `F385` §2 reabrió el 2026-11-02 (todas confirmadas); esta silla
**no** las reabrió por su cuenta y las rotula «vía F385». La norma ISO/IEC/IEEE 26514:2022 3.1.7 queda **sin
verificar** en la edición publicada (`F380` §5, `F385` §7). Los dos P0 del refutador (R3-01, R3-02) se aceptan: no
cambian ganadoras pero las condicionan.

## 2. Eje A

| Preg. | Voto | Firmeza | Condiciones | Ataques |
| --- | --- | --- | --- | --- |
| A-01 | a1: término **«audiencia»** = conjunto de lectores a los que se dirige una pieza (ISO 26514 3.1.7 adaptada, *sin verificar* la edición publicada); **no es un permiso**. Término hermano **«regla de entrega»**: a quién se entrega y dónde se hace cumplir | FIRME (AD-A +3, AD-B +8) | «audiencia primaria/invocada» sólo como nota de glosario | Sin ataque (`F385` §6) |
| A-02 | Dimensiones: **rol, alcance, superficie, nivel de acceso** (ortogonales); **jerarquía** derivada del rol; **lector** humano/agente como canal, fuera del acceso; idioma no amplía acceso. Obligatorias por escenario (nivel siempre que haya producto; alcance y superficie sólo si existen) | FIRME (dimensiones); la forma del campo, CON REVISIÓN | — | Acepto R3-04 (ver A-12) |
| A-03 | Decisión nueva; `00-Marco.md` §2.5 pasa a «Audiencias típicas» y se le saca «agente» | FIRME (AD-B +5; AD-A lo trata con A-12) | — | — |
| A-04 | Lector = dimensión; `TEM-04` sigue como tema (renombre editorial a «Lectura por agentes») | FIRME (+3 / +3) | Limpiar `agente` de `audience` en `00-Marco.md` y `TEM-04` en el mismo PR (R3-04 c) | Acepto R3-04 (c) |
| A-05 | `incluye:` en el registro, expandido en el build; enlace abajo→arriba = rojo | FIRME (+4 / +8) | Cambiar la jerarquía = H | — |
| A-06 | Cuatro niveles (`publico`, `producto`, `restringido`, `interno`), cada uno con punto de aplicación; acceso se mide en **tres** puntos: repo, build, servidor | CON REVISIÓN (AD-B +2) | (1) Regla `nivel-vs-repo` de R3-01; (2) prueba negativa = par autorizado 200 con contenido / no autorizado ≠ 200 sin contenido; 403 o 404 a elección declarada | Acepto R3-01 (P0) y R3-05: Redocly da 403 y redirige al login (vía F385, fuente 7), Mintlify 404 (fuente 4); no hay convergencia |
| A-07 | Documento OpenAPI por exposición; UI interactiva sólo en desarrollo; ensanchar = H **por cada cambio** | FIRME (AD-B +5; AD-A +2 → se toma la coincidencia de ganadora; queda CON REVISIÓN por R3-08) | Control `contrato-por-exposicion`: sin grupo un endpoint va a todos los documentos (vía F385, fuente 1) | — |
| A-08 | Tipo de alcance en el repo, valores en el servidor | FIRME (+7 / +10) | Barrido de literales de inquilino en el repo | — |
| A-09 | Una fuente, salidas por superficie, paquete instalable sólo `publico` | FIRME (+14 / +4) | Sujeto a `nivel-vs-repo` (R3-01) | Acepto R3-01 como condición, no como inversión |
| A-10 | Filtro único para todos los canales; `canal_agente` con `ninguno` por defecto en lo no público **como propuesta** | CON REVISIÓN | i3 vuelve a CA-7 para puntuarse; no entra a `K` como FIRME este ciclo | Acepto R3-03 |
| A-11 | Controles en dos carriles, en dos escalones | CON REVISIÓN | Ningún control es bloqueante sin par rojo/verde en la PoC-R; hasta entonces avisa | Acepto R3-09 |
| A-12 | D-18 «Audiencias y entrega»: registro como fuente, matriz audiencia×página **derivada**, columna `cumple` opcional hasta que genere una prueba negativa que dé rojo; campo nuevo de entrega con **clave en inglés no homónima: `delivery:`**; `audience` queda de orientación | CON REVISIÓN (AD-A +1) | Control que rechace `audiencias:` y variantes cercanas; migración nula (lo heredado avisa) | Acepto R3-04 (a, b); acepto R3-10: la migración de b2 eran 30 archivos de `SDEI/`, no 283 (no cambia el voto) |
| A-13 | Sin capítulos nuevos en este ciclo: audiencias como secciones de los caps. 7–8 | CON REVISIÓN | Presupuesto L3 revisado en una línea de `F399`; capítulos nuevos sólo con apéndice de renumeración a `F099` §5.2 antes de tocar L3 | Acepto R3-07; rechazo k2/n2 (empates o +1) |
| A-14 | Ronda 3 **con dos brazos** declarados en el folio previo (casos sin roles con `K` 1.2; casos con roles/API/formulario con 1.3), *n* fijado antes; los oráculos de los casos con roles se re-sellan con filas de audiencia; criterio de caso sin cambio | CON REVISIÓN | Si no hay recursos para dos brazos: ronda 3 con 1.2 sin D-18 y audiencias a 1.3 | Acepto R3-06: con «ningún caso pasa» en ronda 2 (`F204` §1), cargar D-18 confunde la causa |
| A-15 | Extender `Examples/Prueba-Ayuda-Por-Rol/` con formulario y tres roles (raíz, administrador por aplicación, integrador) | FIRME (AD-B +10; AD-A +1 → CON REVISIÓN por R3-08) | Contenido **ficticio**, dicho en el README; nada `restringido`/`interno` real en repo público | Acepto R3-01 (3) |

## 3. Eje B

| Preg. | Voto | Firmeza | Condiciones | Ataques |
| --- | --- | --- | --- | --- |
| B-01 | Escalera de capas con vocabulario cerrado (etiqueta, pista, error, ayuda ampliada, enlace a página). Pista sin enlaces y sin placeholder por etiqueta (GOV.UK, vía F385 fuente 2; NN/g Sherwin 2014 rev. 2018, fuente 14) | FIRME (+6 / +4) | — | Sin ataque |
| B-02 | Números interpolados desde la regla; prosa escrita por persona | FIRME (+5 / +7) | — | Sin ataque |
| B-03 | Traza desde la ficha con anclas `muestra`/`valida` a la clave | FIRME (+3 / +4) | Catálogo YAML como opción | — |
| B-04 | Canal «punto de uso» de `CL-06`, **no** clase nueva; sección nueva de `TEM-05` «Ayuda en el punto de uso», **no** tema nuevo | FIRME en la clase; CON REVISIÓN en el lugar (AD-B +2) | Si la sección supera el presupuesto del cap. 8, se reabre como tema | — |
| B-05 | Anclas `contiene` + límite interpolado; campo con regla y sin ayuda = aviso | CON REVISIÓN (AD-B +2) | Bloqueante sólo con par | R3-09 |
| B-06 | Etiqueta y error iguales para todos; variante sólo si el texto cambia, con motivo; resuelta en servidor | FIRME (+5 / +8) | Sujeta a la regla de B-11 | — |
| B-07 | ID de contexto estable en el frontmatter con espacio de nombres `contexto: <app>/<id>` + resolvedor en servidor, mapa derivado | CON REVISIÓN (AD-A +2) | — | Acepto R3-11: DITA hace único `@appid` junto con `@appname` (vía F385, fuente 8) |
| B-08 | Plataformas de guía en producto sólo como canal derivado que dirige; nunca contenido restringido; fuera de lo normativo | CON REVISIÓN (AD-A +1) | La segmentación por propiedad del usuario (p. ej. Appcues `identify()`, vía F385 fuente 9) es visibilidad, no acceso | — |
| B-09 | `aria-describedby` probado en pruebas de interfaz; `docs-guard` sólo exige etiqueta y error | FIRME (+7 / +3) | Como agregado: WCAG 2.2 3.3.2 (nivel A) no exige asociación programática (vía F385, fuente 5) | Coincido con `F385` §6 |
| B-10 | Nada obligatorio; **si** hay asistente: misma pieza, con el token del usuario, sugiere y no envía (OWASP LLM06 «excessive agency», vía F385 fuente 3) | CON REVISIÓN | v3 vuelve a CA-7/CA-8 | Acepto R3-03 |
| B-11 | `[Display]` + anotaciones + `.resx` + localizador por audiencia **sólo en servidor**; `AddOpenApi` por documento | CON REVISIÓN (baja de FIRME) | Variantes de nivel > `producto` nunca en `.resx` de ensamblados distribuidos (MAUI, Blazor WebAssembly): se sirven por API autenticada; control que inspecciona el APK y `wwwroot/_framework` con par rojo/verde. Empaquetado de satélites en MAUI Android: *sin verificar*, se mide | Acepto R3-02 (P0) |
| B-12 | Igual que A-15 (formulario en la PoC-R extendida) | CON REVISIÓN (+1 en ambos) | Ver A-15 | — |

R3-12 (complejidad): **acepto** el perfil mínimo para `{servicio-privado}`: roles planos con jerarquía + nivel +
`nivel-vs-repo`; registro con alcance, `canal_agente`, `cumple`, localizador decorado y contexto como extensión por
escenario.

## 4. Pronunciamientos pedidos

1. **Término y definición.** «Audiencia» (en `K` y `SDEI/`), con la definición de A-01; se le suma «regla de
   entrega». «Doble audiencia» queda en el glosario como nombre anterior.
2. **Dimensiones.** Rol, alcance, superficie, nivel de acceso; jerarquía derivada; lector como canal.
3. **Tema nuevo o reescritura.** **No** se agrega tema nuevo al cuerpo en este ciclo: se reescriben `TEM-04`
   (agente como lector que hereda la audiencia de su usuario, filtro único) y `TEM-05` (`roles` → registro con
   jerarquía; superficies; sección «Ayuda en el punto de uso»). `TEM-06` recibe los controles como «propuestos».
4. **Conocimiento.** D-18 «Audiencias y entrega» (registro, nivel, punto de aplicación en tres puntos,
   `nivel-vs-repo`, exposición de API = H por cambio); D-01 inventaría audiencias, superficies y documentos OpenAPI;
   D-13 suma el canal «punto de uso» y quita «no se ancla»; §2.3 remite a D-18. Artefactos: registro de audiencias
   (`doc_type` propio, prefijo `AUD-`), campo `delivery:`, `contexto:` con espacio de nombres. `canal_agente` y
   `cumple` quedan como extensión opcional.
5. **Libro.** Parte III sin capítulos nuevos: secciones en caps. 7–8; presupuesto L3 revisado en `F399`; L3 sigue
   suspendido hasta `F399`.
6. **Ensayos.** Re-sello sólo de los oráculos de casos con roles, API o formulario, con filas de audiencia; ronda 3
   en dos brazos (o sin D-18 si no alcanza); criterio de caso igual.
7. **Orden de trabajo.** (1) `F399`; (2) PR de vocabulario (glosario, Marco §2.5/§4, esquema con `delivery:`,
   limpieza de `agente`); (3) `TEM-04`/`TEM-05`/`TEM-06`; (4) `docs-guard`: `nivel-vs-repo`, rechazo de
   `audiencias:`, inspección de paquete, todos con par rojo/verde; (5) PoC-R extendida con contenido ficticio;
   (6) `K` 1.3 citando 2–5; (7) oráculos y ronda 3 en dos brazos; (8) libro.

## 5. Mensajes e incidencias

Mensajes de otras sesiones durante el voto: ninguno. Incidencia: corte de energía el 2026-11-01.

## 6. Barrido de lo privado

El servicio va como `{servicio-privado}`; sin nombres de máquina ni rutas absolutas.
