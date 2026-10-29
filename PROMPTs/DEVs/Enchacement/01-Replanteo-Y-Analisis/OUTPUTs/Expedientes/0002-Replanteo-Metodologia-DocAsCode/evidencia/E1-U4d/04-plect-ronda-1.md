# E1-U4d — P-LECT de TEM-07, ronda 1, 2026-10-27
# Lector sin contexto: claude -p sin herramientas; recibe sólo 00-Marco (referencia) y TEM-07 en su estado de la ronda, con la consigna:
#   Prueba de lectura P-LECT. Sos un lector sin contexto: estudiante de sistemas que nunca vio este repositorio ni el proyecto. No uses herramientas ni leas otros archivos: sólo el texto de abajo (dos documentos de una guía: 00-Marco, que fija el vocabulario, y el tema TEM-07). Leé el Marco como referencia y evaluá el TEM-07. Anotá TODAS las dudas concretas sobre TEM-07 que el texto NO responde (términos sin definir en su primer uso, saltos, referencias a cosas que no están, contradicciones, instrucciones ambiguas, ejemplos que no se pueden reproducir). No anotes dudas que el propio texto responde: en ese caso indicá dónde. Formato de salida: una tabla Markdown con columnas | # | Sección de TEM-07 | Duda | ¿La responde el texto? (no / sí, en …) | Gravedad (alta/media/baja) |, y al final una línea «Dudas sin respuesta: N» y otra «Dudas altas sin respuesta: N». Respondé en castellano.

# Evaluación de lectura P-LECT: TEM-07 (Integración con un marco SDD)

| # | Sección de TEM-07 | Duda | ¿La responde el texto? | Gravedad |
| --- | --- | --- | --- | --- |
| 1 | Frontmatter | `traces` incluye `GP-SDEI-INTERVENIR`, `ANX-SDEI-CQ` y `ANX-SDEI-REFERENCIAS`. ¿Qué documentos son? El prefijo `GP-` no aparece ni en el Marco ni en el tema. | no | baja |
| 2 | Frontmatter | `audience` no incluye `po`, que sí está en el Marco. Sin embargo, el tema reparte decisiones de clase H a «la persona responsable» (§2.1, §2 frontera). ¿El PO no es audiencia de este tema? | no | baja |
| 3 | Intro, «Estado» | ¿Qué es un «escalón»? ¿Cuántos hay, qué es «la piloto» y cuándo se considera cumplido el escalón 2? (Vuelve a aparecer en §2.1.) | no | media |
| 4 | §1.1 | «Thoughtworks **la** ubica en el anillo "evaluar"»: ¿a qué se refiere «la»: al término, a la práctica SDD o a alguna herramienta? Tampoco explica qué es el «radar». | no | baja |
| 5 | §1.1 | Dice que integrar «quiere decir tres cosas, y sólo tres», y el párrafo siguiente agrega una cuarta (agregar clases propias). ¿Es parte de la integración o no? | no | baja |
| 6 | §1.1 punto 3 / §2 / §5 | El punto 3 dice que la traza resuelve contra el registro «fijado a un SHA», y §5 («Ancla explícita») lo repite. Pero §2 dice «etiqueta de cada línea» para ESC-SDEI-4 y «etiqueta y SHA» para ESC-SDEI-3. ¿Siempre es un SHA o depende del escenario? | no | media |
| 7 | §1.1 punto 2 / §2 | «El RRD vive junto a la especificación»: ¿en qué carpeta, con qué nombre y en qué formato? Además, escribirlo dentro del árbol del SDD ¿no es modificar algo ajeno, que según §2.1 sería clase H? | no | media |
| 8 | §1.2 | `CU-08002@1.11` aparece sin decir qué caso de uso es. | sí, en §3.1 («contrato de administración de cuentas») | baja |
| 9 | §3.1 | `CU-08002` se llama «contrato» siendo un caso de uso (`CU-`). ¿Es un caso de uso, un contrato o las dos cosas? | no | baja |
| 10 | §1.3 | «Rige la del SDD… y la diferencia se declara»: ¿dónde se declara y en qué forma? §2 dice «en el pull request», pero para clases que difieren, no para una regla del cuerpo que choca con la del SDD. | no | media |
| 11 | §1.3 | «Cualquiera que tenga un registro de IDs estable»: ¿qué hace que un registro sea «estable»? No hay criterio. | no | baja |
| 12 | §1.4 | Lección de decisión: «el nivel en que se tomó». ¿Qué niveles existen y quién los define? | no | media |
| 13 | §1.4 / §3.1 | Aparecen prefijos que no se definen: `RF` (se lista junto a `CU`, `RN`, `ADR` y `NB` como trazable), y también `H-`, `N-` y `BT-`. | no | baja |
| 14 | §1.4, diagrama | Según la leyenda, las flechas llenas son dependencias. ¿`NB → CU` significa que CU depende de NB o lo contrario? Además, sólo `CU` «declara» en el registro: ¿NB, RN y ADR no declaran? | no | baja |
| 15 | §1.4, diagrama / §2 | ¿Qué son CL-03, CL-06, etc.? | sí: Marco §1 (catálogo en el Mapa) y nombres en la tabla de frontera de §2 | baja |
| 16 | §2 | ¿Qué es el SDD-B? | sí, en Marco ESC-SDEI-4 | baja |
| 17 | §1.4 / §2 | ¿Qué es la «huella»? | sí, en Marco CTX-SDEI-4 y §1.4 (CL-11) | baja |
| 18 | §2, fila ESC-SDEI-1 | Afirma que «este tema le enseña… cómo citar un SDD de otro proyecto», pero no lo enseña. ¿Se cita con traza (que no resolvería contra el registro propio) o con enlace? El formato del Marco `Repo@ancla:corpus_id/doc_id` no sirve para un `CU-`, y la cita a IA.SDD de §2 usa otra forma. | no | media |
| 19 | §2, tablas | Vocabulario de IA.SDD sin definir: «categoría 11», «categorías 01, 02 y 05», «consolidación de cierre», «cuerpos integrador, mantenedor y operador». | no | media |
| 20 | §2 / §4 P4 | «Unidad de entrega» o «unidad que contiene la pantalla»: ¿qué es una unidad y cómo se sabe cuál contiene una pantalla? La regla central de la ayuda (CL-06) depende de esto. | no | media |
| 21 | §2, fila ESC-SDEI-3 | «La etiqueta y el SHA del proyecto»: ¿se usan los dos a la vez, o uno u otro según el caso? | no | media |
| 22 | §2 / §3.1 | IA.SDD se cita en su propio repositorio (`bac7e48`) y el ensayo usa `SDD/Docs` de Lab-Geometria (`5f07b12`). ¿El marco es un repositorio aparte copiado al proyecto? ¿Qué SHA se fija para resolver? | no | media |
| 23 | §2, tabla de frontera | Para ESC-SDEI-3 se lista CL-11, pero el Marco §2.5 activa en ESC-SDEI-3 sólo CL-01 a CL-08 y CL-12, sin CL-11. Es una contradicción. | no | media |
| 24 | §2, CTX-SDEI-2 | «Los prefijos de la especificación son **externos** en el registro de prefijos»: ¿qué significa «externo» y qué efecto tiene en la compuerta? | no | media |
| 25 | §2, CTX-SDEI-4 | «El SDD-B no puede llamar al workflow»: nada antes dice que el SDD-B esté fuera de la organización del runner. El Marco sólo dice que es privado. | no | media |
| 26 | §2, «Por contexto» | ¿Por qué cuenta sólo tres contextos y deja fuera CTX-SDEI-1? | sí, en Marco CTX-SDEI-1 («hoy ningún escenario publica sitio»), aunque implícito | baja |
| 27 | §2, «Una regla que no cambia» | El plan de sprint «se engancha en la fase del ciclo que corresponde»: ¿cuál? No hay criterio para mapear fases del SDD a las fases 1a–5. | no | media |
| 28 | §2, frontera CL-11 | «Aviso cuando la base avanza»: ¿qué control lo emite y cómo detecta el avance? El carril programado del Marco no lo incluye en su lista. | no | media |
| 29 | §2.1 | «Expediente 0002»: ¿qué es un expediente y dónde está? Además, el rótulo «[criterio de diseño del expediente…]» no figura en las convenciones del Marco, que sólo prevén [criterio propio]. | no | media |
| 30 | §2.1, capa A | ¿La capa A existe ya? ¿Cuál es concretamente la «base de conocimiento común», cómo se copia y cuáles son «las reglas que ya lo dicen»? | no | media |
| 31 | §2.1 | Que un agente decida «sin preguntar», ¿choca con ACT-SDEI-4 («nada de clase H»)? | sí, en §2.1 («no redefine qué se decide sin la persona») y Marco §4 | baja |
| 32 | §3.1 | La «página de ayuda de Lab-Geometria», ¿existe en el proyecto o es hipotética y se creó sólo para el ensayo? | no | baja |
| 33 | §3.1, bloque bash | El ensayo no se puede reproducir. Sólo está el comando del caso A. No se dice cómo crear `p-A` a `p-D`, cuál es el contenido exacto de `ayuda.md` (¿frontmatter completo o sólo `traces`?), ni qué `--fuente` usan B–D (¿`geo-vigente`?). | no | alta |
| 34 | §3.1, bloque bash | Ni el Marco ni el tema explican `tools/docs-guard/dg.py`, el subcomando `trazas` ni los parámetros `--raiz` y `--fuente`. Tampoco dan la URL para clonar Lab-Documentos ni la versión de Python. ¿Cómo se relaciona `dg.py` con el workflow `docs-guard` y con PR-5? | no | media |
| 35 | §3.1, bloque bash | El bloque se rotula «[Fragmento ilustrativo]», pero se presenta como «los comandos del ensayo». ¿Son los comandos exactos o una aproximación? | no | media |
| 36 | §3.1 | ¿`hdcm-dev/Lab-Geometria` es público? Si no lo es, ¿con qué acceso se clona? (El Marco exige alias para repositorios privados, pero no dice que este sea público.) | no | media |
| 37 | §3.1 | Las cifras 829/355 y 715/52: ¿con qué comando se obtuvieron? No se pueden verificar. | no | baja |
| 38 | §3.1, «La lección» | El ensayo excluye `_legacy/` borrando carpetas a mano. ¿Cómo se configura eso en la CI real (opción del workflow, parámetro, lista de exclusión)? ¿Cómo obtiene la CI el SDD en el SHA fijado? | no | alta |
| 39 | §3.1, caso D | «El SDD renumeró sus casos de uso»: ¿cómo se encuentra el ID nuevo que reemplaza a `CU-03`? | no | baja |
| 40 | §3.2 | `TEM-05` y `Examples/Prueba-Ayuda-Por-Rol/` se mencionan sin enlace ni descripción. | no | baja |
| 41 | §3.3 | El título habla de «tres fases», pero Spec Kit se describe con seis pasos (principios, especificación, plan, tareas, implementación, verificación). | no | media |
| 42 | §3.3 | «Hay que elegir qué encabezado declara el ID»: ¿quién lo elige, es clase H? Agregar IDs a los artefactos de Spec Kit o Kiro ¿no contradice «Norma respetada» (§5)? | no | media |
| 43 | §4, P5 | ¿Quién acepta cada fila del RRD? | sí, en Marco §4 (ACT-SDEI-2, analista) | baja |
| 44 | §4, P6 | ¿Cuándo hay que copiar el workflow con su huella? | sí, en §2 (CTX-SDEI-4) y Marco CTX-SDEI-4 | baja |
| 45 | §6 | «Se guarda junto a la instancia de "Cómo intervenir" del proyecto»: ¿qué es una «instancia» y dónde vive? El enlace lleva a la plantilla, no a una instancia. | no | media |
| 46 | §6 | «Ficha de integración» choca con «Ficha» del Marco (página con ID, versión y `ruta#Símbolo@SHA`). ¿Lleva frontmatter o ID? ¿Se puede trazar? | no | baja |
| 47 | §6, «Runner y workflow» | `uses:` no se explica. El Marco sólo dice «llaman al workflow reutilizable». | no | baja |

Dudas sin respuesta: 39
Dudas altas sin respuesta: 2
