| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-03 |
| Autor | Sesión DocsAsCode (parte) |
| Corrige | — |

Incorporado **tal cual lo entregó la sesión DocsAsCode**, sin editar; la presidencia no le aplicó redacción. Lo que sigue a esta línea, hasta el pase, es la pieza.

---
doc_type: posicion
title: Posición inicial de la sesión DocsAsCode para el expediente 0004 — cómo se integra Docs as Code dentro de una capa de IA
status: borrador
origin: agent
owner: sesión «DocsAsCode» (expedientes 0002 y 0003 de Lab-Documentos.Documentacion y 0044 de un repo privado)
last_review: 2026-11-03
audience: [mesa conjunta del expediente 0004, sesión que abre el 0004, PO]
---

# Posición inicial de la sesión DocsAsCode (expediente 0004)

**Convención de citas.** `LDD` = Lab-Documentos.Documentacion; `EXP2/` y `EXP3/` = sus carpetas
`PROMPTs/DEVs/Enchacement/01-Replanteo-Y-Analisis/OUTPUTs/Expedientes/0002-Replanteo-Metodologia-DocAsCode/actuaciones/`
y `.../0003-Reedicion-DocsAsCode-Y-Especificacion/actuaciones/`; `Fnnn` = folio nnn del expediente que se nombra.
`LD` = Lab-Documentos; `K` = `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Conocimientos/knowledge-DocsAsCode-Designing-Specification.md`
(versión 1.4, publicada como borrador). `LG` = Lab-Geometria, expediente `SDD/Expedientes/0003-DocsAsCode/`.
Lo del servicio privado va por alias, `{servicio-privado}`, y sólo en términos genéricos: su evidencia queda en su repo.

## 1. Elenco: quién trabajó y qué dejó

| Comisión / especialista | Mandato | Tesis principales | Evidencia más fuerte |
| --- | --- | --- | --- |
| Mesa del 0002 (diez comisiones, con C-AGENTES-IA) | Replantear la metodología DocAsCode y llevar el escalón 1 (E1) hasta una compuerta verificable | Separar redactor y verificador (los dos agentes, pero distintos); compuerta determinista en verde **antes** de que mire una persona (frontmatter, enlaces, trazas, anti-inyección); aprobación humana explícita en el PR | `EXP2/017-informe-c-agentes-ia.md` §5; compuerta `EXP2/290-compuerta-e1.md` (árbol del merge igual al auditado; PR #26 y #27 de LD) |
| Comisión CA-7 del 0003, «agentes y LLM como audiencia» | Ver si el agente es una audiencia más | El agente **no es una audiencia**: es un lector que actúa por una y hereda su alcance sin ampliarlo (OWASP LLM06). `llms.txt` y `AGENTS.md` no son control de acceso: el `llms.txt` es una salida más del filtro, uno por audiencia. La ayuda de un formulario que lee un asistente es contenido no confiable para él (la «lethal trifecta») | `EXP3/370-informe-agentes-como-audiencia.md` §1 |
| Resolución del ciclo 3 (audiencias) | Consolidar nueve comisiones, refutador y tres votos | Audiencia orienta la escritura y **no es un permiso**. Lo que recibe cada pieza lo decide una regla de entrega que se cumple en tres puntos: repo, build y servidor. La ayuda de formulario es un canal y su texto traza a la regla que valida el campo | `EXP3/399-resolucion-ciclo-3-audiencias.md` §1 |
| Mesa de diseño de Geometría (seis informes, propuesta, refutación y tres votos) | Aplicar K 1.4 a un repo público con panel y API | Todo nace en «avisa» y pasa a «bloquea» sólo con par rojo/verde y cero hallazgos; los controles de audiencia se reducen a uno, `delivery-publico`; la instantánea OpenAPI la regenera la automatización en push a main, en un job aislado con clave descartable; carril programado en ola 2 | Resolución de la mesa (§0, K-06, K-07, K-12; D-10, D-17), aplicada en `LG` por PR #248 a #250 |
| Mesa de diseño de `{servicio-privado}`, tramos 1 a 3 (expediente 0044) | Aplicar K a un servicio privado con portal de desarrolladores y contenido restringido | Lo restringido se compila embebido y nunca se sirve como archivo estático; un único documento OpenAPI por audiencia (el del integrador) y 404 sin cuerpo para todo lo demás, también al anónimo y al Bearer sin rol; las audiencias pedidas sin autenticación en código quedan como fila H, no como filtro; pruebas negativas obligatorias antes de abrir el portal | Resoluciones de la mesa (tramos 1–2 y tramo 3), con sus pruebas exigidas: el desarrollador recibe 200 en su contrato y el contrato no contiene rutas de consulta ni de administración |
| Coordinador y aplicador ciego de las rondas de ensayo (cuatro rondas) | Medir si K, solo, alcanza para que un agente sin contexto produzca la ficha A-01 correcta | El aplicador corre en aislamiento total (proceso aparte, sin memoria, sin MCP, sin red) y su única salida es el coordinador, que contesta sólo con insumos sellados y audita su registro de herramientas | `EXP3/202-providencia-coordinador-de-ensayos.md`; `EXP3/207-folio-previo-ronda-4.md` §2; resultado en `EXP3/208-resultado-ronda-4.md`: **ocho corridas válidas, ninguna pasa**, cuatro P0 abiertos; enmienda `EXP3/209-enmienda-f208.md` |
| Revisión general (cinco lentes) | Barrer el 0003 después de publicar K | Coherencia entre K y la plantilla, privacidad de la historia, completitud del plan | Revisión del 2026-11-02: COH-05 (K publicada «borrador ensayado, no probado» por decisión del PO), PRIV-01 (correo personal en metadatos de merge de un repo público), C-01 a C-06 (libro sin fusionar; los controles de las 13 familias y el pase a «bloquea» sin PR) |
| Especialista externo (Geometría y `{servicio-privado}`) | Correr de verdad los workflows en main y probar casos rojos en local | El diseño es bueno pero el circuito no cierra: con todo en «avisa», un main que contradice su contrato sale verde | Geometría: la instantánea OpenAPI cambió pero el job no pudo abrir el PR y el fallo quedó como warning en un run verde; el carril programado abrió el issue #251 con seis enlaces caídos. `{servicio-privado}`: el único control que bloquea (no publicar lo restringido) **no corre en ningún workflow**; un regex sensible a mayúsculas dejó pasar una ruta administrativa |

## 2. Posición inicial

### 2.1 Lo que aprendimos y aplica tal cual a una capa de IA

1. **Audiencia y entrega por pieza.** Cada pieza lleva `audience` (para quién se escribe) y `delivery` (quién la
   recibe). Sólo `delivery` decide. En una capa de IA, `delivery` es lo que tiene que leer el recuperador antes de
   meter un fragmento al contexto (`EXP3/399` §1).
2. **Contrato OpenAPI por audiencia.** No hay «el» OpenAPI: hay uno por audiencia, y lo que no le toca a una da 404 sin
   cuerpo. Una herramienta (tool) que la capa de IA expone a un modelo es un contrato más y entra en la misma regla.
3. **Ningún control sin su par rojo/verde.** Un control vale si hay un caso que lo hace fallar y otro que lo hace pasar,
   y los dos corren en CI (autoprueba de Geometría).
4. **«Avisa» antes que «bloquea», pero con fecha.** Arrancar en «avisa» evitó trabar la fusión automática. Pero la
   revisión externa mostró el costo: un main con una contradicción conocida sale verde. Toda promoción a «bloquea»
   necesita fecha o criterio escrito.
5. **Carril programado.** Lo que no cambia con un PR (enlaces externos, vigencia) se revisa por calendario y se avisa con
   un issue que no se duplica y que se cierra solo cuando el aviso desaparece (Geometría B1/B2).
6. **Prueba negativa de no publicación.** Probar que algo **no** sale (al anónimo, a otra audiencia, al artefacto
   publicado) vale más que probar que algo sale. Y tiene que correr en CI: en `{servicio-privado}` existía y no estaba
   conectada.
7. **Ensayo con aplicador ciego.** Es el único método que midió si un conocimiento sirve para un agente sin contexto. El
   resultado honesto fue «borrador ensayado, no probado» (`EXP3/208` §9, `EXP3/209` §3): el error fue estable entre
   corridas y lo explican defectos del conocimiento, no el azar.

### 2.2 Riesgos propios de la IA

- **Fuga de contenido restringido al prompt.** Si el índice de un asistente se arma con todo el repositorio, el filtro
  de audiencia deja de existir: el modelo no distingue `delivery`. El filtro tiene que estar **antes** del índice, no en
  la respuesta (CA-7 tesis 2).
- **Documentos que la IA lee vs. documentos que la IA escribe.** Lo que lee es contexto y puede traer inyección (texto
  de ayuda, comentarios, issues). Lo que escribe es borrador y necesita verificador distinto y compuerta antes de la
  persona (`EXP2/017` §5). Mezclar los dos en una misma carpeta borra la diferencia.
- **Vigencia.** Un documento vencido le hace menos daño a una persona, que duda, que a un modelo, que lo cita con
  confianza. En los ensayos, el defecto P0 de la 1.2 fue justamente dar por buena una excepción vencida y validar citas
  por archivo y rango sin mirar contenido (`EXP3/208` §5.3).
- **Instrucciones heredadas del entorno.** En la ronda 3 la memoria del entorno llegaba al aplicador; sólo el
  aislamiento total lo cerró (`EXP3/208` §1, L-1). Una capa de IA en producción tiene el mismo problema con sus
  archivos de instrucciones.
- **Fallo silencioso.** Un `|| echo warning` que se traga un error deja el run en verde; un agente que lee el estado de CI
  concluye que está todo bien.

### 2.3 Propuestas para debatir

1. **`delivery` como filtro obligatorio del recuperador**: ninguna pieza entra a un índice de embeddings, `llms.txt` o
   servidor MCP sin pasar por la misma regla de entrega que la página HTML, y un índice por audiencia, nunca uno global.
2. **Prueba negativa de contexto**: con la identidad de cada audiencia se pregunta al asistente por un contenido
   restringido sembrado (un canario) y se exige que no aparezca. Corre en CI y bloquea desde el día uno.
3. **Marcar el sentido de cada pieza**: `lee-ia` (contexto, se trata como no confiable) y `escribe-ia` (borrador, con
   verificador distinto y aprobación humana). Lo escrito por la IA no vuelve como contexto hasta que una persona lo
   aprueba.
4. **Vigencia como campo controlado**: `last_review` con caducidad por clase de documento; vencido = no se indexa, o se
   indexa con rótulo visible para el modelo.
5. **Herramientas de la capa como contratos OpenAPI por audiencia**, con la misma instantánea automática, el mismo
   diff y el mismo 404.
6. **Calendario de promoción**: cada control nace en «avisa» con fecha de pase a «bloquea»; el carril programado avisa
   si la fecha venció.
7. **Ensayo ciego del conocimiento de la capa de IA** antes de publicarlo, con el mismo coordinador y la misma
   auditoría de herramientas, y el mismo rótulo honesto si no pasa.

## 3. Preguntas abiertas para la mesa conjunta

1. ¿El filtro por `delivery` vive en el sistema documentador (genera un corpus por audiencia) o en la capa de IA
   (filtra en la recuperación)? ¿O en los dos, y quién es la fuente de verdad?
2. ¿Qué identidad usa la capa de IA para recuperar: la del usuario, la del agente o la del servicio? ¿Cómo se prueba que
   nunca amplía el alcance del usuario?
3. ¿La documentación que escribe un agente cuenta como fuente de la capa de IA antes de la aprobación humana? ¿Con qué
   rótulo?
4. ¿`AGENTS.md` y equivalentes son documentación (con frontmatter, audiencia y vigencia) o configuración (fuera del
   sistema documentador)?
5. ¿Qué controles de la capa de IA bloquean desde el principio, sin pasar por «avisa»? Proponemos al menos la prueba
   negativa de no publicación y el canario de contexto.
6. ¿Cómo se ensaya una capa de IA con aplicador ciego cuando el resultado no es una ficha sino respuestas de un modelo?
   ¿Qué oráculo y qué umbral?
7. Los cuatro P0 abiertos de K 1.4 (`EXP3/208` §5) ¿se cierran antes de integrar la capa o se integra sobre el
   borrador, rotulado?

Sigue: incorporar el informe siguiente · presidencia de la mesa
