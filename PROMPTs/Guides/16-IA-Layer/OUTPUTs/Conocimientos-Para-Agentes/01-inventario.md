# Inventario del éxito y de los errores de PushDispatch (capa de IA, expediente 0043)

Fecha: 2026-11-11. Fuentes leídas en sólo lectura: dictámenes 70, 80, 100, 110, 120, 130 de la mesa de gestión IA, plan-pendientes.md, registro-frentes.md, 90-fase3 (batería r8, nota de latencias), actuaciones 004–021 del expediente 0043 y el log de PRs #463–#482 en origin/main del repo de PushDispatch.
Cobertura: **K** = conocimiento v1.0 (knowledge-AI-Layer-Integration-Designing-Specification.md); **G16** = guía 16 en origin/main (1.2.0); **FALTA** = no está en ninguno.
Regla de publicación: este inventario es interno. Al pasarlo a un conocimiento público se quitan nombres de organizaciones, hosts, modelos y el producto de referencia (se dice «un producto de referencia del mercado»).

## A. Arquitectura

| # | Qué se hizo | Evidencia | Por qué funcionó o falló | Cobertura |
|---|---|---|---|---|
| A1 | El código elige herramienta, alcance y destino; el modelo sólo redacta sobre cifras ya calculadas | Dictamen 100 §2 («Principio»); 110 y 130 lo citan como regla que rige | El modelo chico elegía mal herramientas y alcance (function calling limitado, ~3 s al primer token); el ruteo determinista es comprobable con pruebas | K parcial (§2, §4 «elige» 7 menciones); G16 sí (§3.7, cap. 9). Falta como regla operativa con prueba |
| A2 | Resolver el **alcance** (cuenta / aplicación / global) antes de responder | Dictamen 100 §1: «¿Cuántos suscriptores tengo?» respondía «¿Sobre qué aplicación?» (RuteoDeConsola.cs:116, AlcanceDe l.49); PR #481 | La falla no era de herramientas sino de alcance | FALTA en K; G16 parcial (§3.7) |
| A3 | RAG con filtro por rol **previo** al top-k, troceo por `##` y por párrafos ≤ 500 car., híbrido léxico + vectorial con umbral | Dictamen 70 §2.3; actuación 017 (troceo por párrafos desde crítica r3) | Filtrar después del top-k filtra información ajena y deja huecos | K parcial (§4); G16 sí (cap. 7–8) |
| A4 | El corpus debe existir antes del RAG: 0 páginas de organizaciones, 18 de 22 en borrador | Dictamen 70 §1 («aunque hubiera RAG, no había documento que recuperar»); 130 §2 (~7 de 38 `@page` con ayuda) | Se diagnosticó como fallo de búsqueda lo que era falta de corpus | FALTA (medir cobertura UI→corpus como compuerta) |
| A5 | Destino (deeplink) del catálogo, elegido por id y **revalidado por permiso** en el servidor; URLs libres del texto se eliminan | Dictamen 70 §2.5; actuación 013 (plantilla insegura corta el arranque); 017 (inyección «llevame a /usuarios» no ofreció destino) | El modelo nunca arma rutas; el permiso se mide en el servidor | FALTA en K; G16 parcial (3 menciones) |
| A6 | Distinguir **ver** la página de **hacer** la acción en el destino | registro-frentes: «Ir a Credenciales» a quien no puede cargar (el catálogo validaba PanelUI, no el POST Administracion) | Ofrecer un destino que termina en 403 es una negativa disfrazada | FALTA |
| A7 | Deeplink que **abre la acción** (`?alta=1`) y no sólo la página | Dictamen 100 §1 (modal sin parámetro); PR #481, Aplicaciones.razor:33 | Responder y llevar (P-2 del dictamen 130) | FALTA |
| A8 | Validador de cifras: cada número de la respuesta tiene origen en una herramienta; si falla, texto fijo | Dictamen 100 §2; G16 l.736 | Garantía por corrida, no estadística | G16 sí; K parcial |
| A9 | Habilitación con motivo exacto (`FaltaEndpoint`, `FaltaModelo`…) registrado una vez, sin dirección ni modelo | Actuación 018 §1; PR #479 | La IA quedaba apagada en silencio | FALTA (ver E3) |
| A10 | Plantilla de respaldo sin modelo, por pertinencia (no la introducción) | Actuación 018 §2 | Sin modelo la consola sigue siendo útil | K parcial («degradar»); FALTA el criterio de pertinencia |
| A11 | Minimización: el voto guarda la huella del turno, nunca la pregunta ni quién | Dictamen 120 §A.2 (tabla VotoDeConsola) | No hay enmascarador de texto libre; lo que no se guarda no se filtra | G16 sí (§3.7 l.648 «evento sin texto»); K parcial |

## B. Diseño conversacional

| # | Qué se hizo | Evidencia | Por qué | Cobertura |
|---|---|---|---|---|
| B1 | Forma de diálogo (burbuja derecha, cronológico, compositor abajo) en lugar de fichas | Dictamen 70 §1 (capturas 6/7); PR #466 | La ficha no se lee como conversación | Guía conversacional (coordinar); FALTA en K |
| B2 | Maqueta adoptada como modelo de comportamiento; piel traducida a los tokens del panel con apartamientos declarados (AP-1…AP-7) | Dictamen 80 §1–§2; actuación 014 | Sin descartes silenciosos; lo que cambia algo aprobado va al PO como aviso | FALTA (procedimiento de adopción de maqueta) |
| B3 | «No está en la ayuda» antes que inventar | Commit 7076cad2 (crítica r5), 2b130f3f (r4); G16 l.648, 669 | Abstención mejor que dato inventado | G16 sí; K FALTA |
| B4 | Aclaración entre candidatas (2–4, con cifras, «y k más») y entre cuentas | Dictamen 110 §2 B; PR #482 (resolutor puro); ConsolaDeIaService.cs:55-62 | «No encuentro esa aplicación» sin candidatas era un callejón | FALTA en K; G16 1 mención |
| B5 | Negativa útil: motivo + pasos + enlace + alternativa + próximo paso | Dictamen 70 §1; plan-pendientes PR-F | El bloqueo seco no orienta | FALTA |
| B6 | Votos útil/no útil con motivo cerrado que indica dónde arreglar; ningún voto cambia el comportamiento solo | Dictamen 120 §A.1 (autocrítica: «el voto se perdía, sólo LogInformation») | Cerrar el ciclo producto ← señal | G16 sí (§3.7); K FALTA |
| B7 | Torta o barras según el caso; 5 mayores + «Otras (k)» que suman el total exacto; nota de métrica («no son personas») | Dictamen 110 §2 A; dictamen 120 | Escala honesta, sin MAU sumado | FALTA |
| B8 | Chip de contexto de pantalla quitable y sugerencias por pantalla | Dictamen 80 §1; PR #474 (pruebas A3) | Contexto explícito y controlable | FALTA en K |
| B9 | Todos los roles tienen consola (el raíz no puede ser un callejón) | Dictamen 130 §1.2 y §2 (MainLayout.razor:26, AdaptadoresDeConsola.cs:21/29/38, ofrece «¿Cómo creo una aplicación?» a quien no puede) | Ver E2 | K parcial (§3 actores); FALTA la prueba por rol |
| B10 | Texto en plantilla del código, voseo, cita por oración, sin primera persona del asistente | Commits 3ca5e928, ed2c8ce5, 7076cad2; actuación 017 («Armaré/Pondré» se dejaba pasar) | Consistencia y verificabilidad | Guía conversacional (coordinar) |

## C. Verificación

| # | Qué se hizo | Evidencia | Por qué | Cobertura |
|---|---|---|---|---|
| C1 | Batería real contra el modelo, umbral ≥ 90 %, repetida ×3 | Actuación 017: 19/20 (95 %); commits 908e229d («batería ×3»), 2cfda726 | Una corrida sola no distingue varianza de mejora | FALTA en K y G16 (0 menciones de «batería») |
| C2 | Rondas ajuste → verificación independiente → crítica (r2…r8), crítico con umbral (nota ≥ 8) | Commits c8b40a8b…3ca5e928 (críticas r2–r7); 90-fase3/bateria-r8.log | Quien ajusta no se evalúa a sí mismo | FALTA |
| C3 | Lectura humana honesta además del automático | Actuación 017: «1 inventada de ~16 mostradas», diferido D-2 | El automático pasó 95 % con un dato inventado adentro | FALTA |
| C4 | Capturas lado a lado a 1280 y 390, claro y oscuro, `scrollWidth == innerWidth`, CLS 0 | Actuación 016-evidencia (Playwright, tablas 1280/780/390); PR #477 | Evidencia visual medible; crítico «misma persona» contra Inicio | FALTA |
| C5 | Verificación en el sitio real con sesión por rol | Actuación 018 («dos defectos vistos en el sitio real»); /vm/agentes/pd-defectos-sitio (correr-real.sh); 90-fase3/sitio-pw-1..3 | La demo no mostraba la IA apagada ni la plantilla con la introducción | G16 parcial (4 menciones genéricas); FALTA como paso obligatorio |
| C6 | Cifras de la consola comparadas contra SQL directo (segunda derivación) | Actuación 016-cifras-de-m3-contra-sql; PR #475 | La misma lectura repetida no prueba nada | FALTA |
| C7 | Pruebas de conformidad por reflexión (filtros del catálogo vs `[SupplyParameterFromQuery]`) | Plan PR-C; PR #476 | Que el catálogo y las páginas no diverjan | FALTA |
| C8 | Latencia fría y caliente separadas; capacidad por M/D/1 | Actuación 006 (p95 caliente 84,3 s ≤ 96 s), 009 (25–30 consultas/h); 90-fase3/NOTA-latencias.md (con GPU no son comparables r1–r4 con r5+) | Comparar series de condiciones distintas engaña | G16 sí (16 menciones frío/caliente); K FALTA |
| C9 | Pruebas con vocabulario neutro | Commits 2b67167a, 4e5a2bf4 | Las pruebas viven en repo; no nombran clientes | FALTA |

## D. Despliegue

| # | Qué se hizo | Evidencia | Por qué | Cobertura |
|---|---|---|---|---|
| D1 | Modelo, endpoint y tiempos por variable de entorno, nunca en el repo | Actuación 004 l.43 («no se nombra en el repositorio, veto 7»); 006 l.207 | Repo sin direcciones ni modelos | G16 sí (cap. 13, A.12); K parcial |
| D2 | Precalentado de embeddings al arrancar, caché por SHA (modelo + texto) | Actuación 017 l.32, 49 | Primer pedido sin recarga | G16 parcial |
| D3 | Un modelo cargado a la vez: alternar redacción/embeddings recarga ~2 s | 90-fase3/NOTA-latencias.md | Determina la latencia real | FALTA |

## E. Errores que costaron (antipatrones con su control)

| # | Error | Evidencia | Control propuesto | Cobertura |
|---|---|---|---|---|
| E1 | Estilos de la consola sin linkear / en una rama sin PR | registro-frentes: feat/0043-consola-diseno deac2ddf «estilos en app.css, empujada, sin PR» ; dictamen 70 §1 (deac2ddf arregla «a medias») | Captura de la app real servida (no de la demo) y verificación de que la hoja se carga (computed style del componente) antes de declarar | FALTA (evidencia del «sin linkear» exacto a confirmar con la mesa) |
| E2 | Consola del raíz olvidada | Dictamen 130 §1.2 y §2: raíz excluido en MainLayout, Inicio, adaptadores, buscador y controlador; el PO lo reclamó | Matriz rol × pantalla con una prueba por rol que abre la consola y obtiene respuesta no vacía | FALTA |
| E3 | Variable del modelo faltante en el despliegue: la IA quedó apagada en silencio | Actuación 018 §1 (exigía `IA:Modelo`, se configuró `IA:ModeloDeRedaccion`); PR #479 | Motivo exacto registrado y /health o pantalla que lo muestre; chequeo post-despliegue en el sitio real | FALTA |
| E4 | Medir con el modelo ya cargado (latencia optimista; la batería no pagaba el cambio de modelo que paga la app) | Commit 2cfda726 «la batería paga el cambio de modelo como la app»; NOTA-latencias | Medir frío y caliente por separado, en las condiciones de la app | G16 parcial (frío/caliente); FALTA el control |
| E5 | Claves impresas en un registro | Mención del pedido; actuación 018 fija «el texto nombra la clave que falta, nunca la dirección ni el modelo» | Grep de secretos sobre logs y evidencias antes de commitear; nunca volcar config entera | K parcial (§10); evidencia puntual a confirmar |
| E6 | Un 90 % reportado sin repetir la medición | Commit 908e229d (r2 obligó «resultado ×3») | Toda cifra de batería se reporta como ×3 con mínimo y máximo | FALTA |
| E7 | Fases dadas por cumplidas sin evidencia | plan-pendientes §0: «ninguna fase cerrada está completa de verdad» | Checklist de salida por fase con artefacto de evidencia | FALTA |
| E8 | Diseñar el gesto sin el destino del dato (votos que se perdían) | Dictamen 120 §A autocrítica | Toda señal de UI tiene almacenamiento y lector definidos antes de implementarse | FALTA |
| E9 | Respuesta = puntero a la guía en vez de contexto para redactar; búsqueda que emparejó por «alta» | Dictamen 70 §1 | La ayuda es contexto, no respuesta; umbral real de rechazo | G16 parcial |

## F. Forma de trabajo

| # | Qué se hizo | Evidencia | Por qué | Cobertura |
|---|---|---|---|---|
| F1 | Mesas con especialistas, propuestas rivales (A/B/C) y refutador; dictamen con jurado | /vm/agentes/mesa-gestion-ia/10-propuesta-{A,B,C}, 20-refutacion.md, DICTAMEN.md | Las propuestas compiten y la refutación saca supuestos | FALTA (remitir a Knowledge-Mesa-De-Expertos-A-Pedido) |
| F2 | Leer el producto de referencia y tabular la brecha antes de diseñar | Dictamen 70 §1, 110 §1 | «Qué entendimos mal» explícito | FALTA |
| F3 | Dictamen que fija PRs pequeños ordenados y marcados [libre]/[F3] por choque de archivos | plan-pendientes §1–§2 (23 archivos, ~2.750 líneas de choque) | Paraleliza sin conflictos | FALTA |
| F4 | Registro de frentes medido (dueño, comando de medida, condición de salida) | registro-frentes.md; Knowledge-Razonamiento-Del-Gestor 1.2 | Estado verificable, no declarado | FALTA (remitir) |
| F5 | Coordinación entre sesiones por reparto de zonas y aviso con SHA | registro-frentes (Usuarios, DocsAsCode; «registra sobre mi SHA con merged=true») | Evita pisarse en un clon compartido | FALTA |
| F6 | PR con conformación automática, merge sólo con checks verdes | PRs #463–#482 | Ciclo sin frenar al PO | FALTA (remitir a Knowledge-Conformacion-Pull-Request-Automatico) |
| F7 | INFORME vs medido: lo no medido se declara como INFORME, no como cumplido | Actuaciones 012, 013 («INFORME (no medido en esta actuación)») | Honestidad de estado | FALTA |
| F8 | Autocrítica escrita de la mesa cuando un hueco era previsible | Dictamen 120 («la mesa debió preverlo») | Aprendizaje que alimenta el siguiente dictamen | FALTA |
| F9 | El reclamo del PO no se repregunta: se corrige | Dictamen 130 §1.2 | Ahorra una vuelta | FALTA |

## Resumen de huecos

- En K (v1.0, especificar) falta casi todo lo de verificación (C1–C9), errores (E1–E9) y forma de trabajo (F1–F9): v1.0 especifica la capa, no cómo se construye y prueba.
- En G16 están A1, A8, A11, B3, B6, C8, D1. **No están**: batería ×3 con umbral, crítico con nota, capturas 1280/390, sitio real por rol, aclaración entre candidatas, negativa útil, ver vs hacer, cobertura del corpus como compuerta. Se anotan para la mesa de la guía.
- Evidencias a confirmar antes de publicar: E1 (el commit exacto del «sin linkear») y E5 (el registro concreto con claves). No se encontraron en las fuentes leídas con esa redacción.
