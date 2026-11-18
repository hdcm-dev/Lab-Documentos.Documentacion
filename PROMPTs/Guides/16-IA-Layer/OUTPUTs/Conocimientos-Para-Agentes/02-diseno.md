# Diseño del conjunto de conocimientos para agentes: integrar una capa de IA como en PushDispatch

Fecha: 2026-11-11 · Preside: ingeniero de conocimiento · Fuente: inventario.md (51 lecciones A/B/C/D/E/F)
Regla de coordinación: los libros (Guía 16 = `Dot-Net-Integration-AI-Layer-Guide.md` 1.2.0; Guía conversacional = `Conversational-Design-Framework-Guide.md`) son la fuente para personas. Cada conocimiento destila, remite `[Guía §x]` / `[GDC §x]` y nunca contradice. Contradicción o hueco del libro → `para-la-mesa-de-la-guia.md`, sin resolverlo acá.

## 1. Conjunto (5 conocimientos, en `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Conocimientos/`)

| # | Archivo | Acción | Versión | Espera a la GDC |
|---|---|---|---|---|
| K1 | knowledge-AI-Layer-Integration-Designing-Specification.md | actualizar | 1.0 → 1.1 | no (sólo 1 remisión a §3.7 de la Guía 16) |
| K2 | knowledge-AI-Layer-Console-Assistant-Building.md | crear | 1.0 | no (B-lecciones remiten a K5) |
| K3 | knowledge-AI-Layer-Verification-And-Acceptance.md | crear | 1.0 | no |
| K4 | knowledge-AI-Layer-Integration-Working-Method.md | crear | 1.0 | no |
| K5 | knowledge-AI-Layer-Conversational-Design.md | crear | 0.9 Borrador | sí: se cierra a 1.0 cuando la GDC se entregue |

Cadena: K1 especifica → K2 construye → K3 verifica/acepta; K4 gobierna cómo trabaja la mesa en las tres; K5 decide qué dice y cómo responde el asistente (consumido por K2 y medido por K3). Los antipatrones E1–E9 no van en un conocimiento aparte: cada uno vive en el conocimiento cuya fase lo previene, con su control, y K4 §8 tiene la tabla índice que los referencia (una sola fuente por regla).

## 2. Cabeceras

### K1 — Especificación (v1.1)
- Alias: AI-Layer-Integration-Designing-Specification
- Naturaleza: propio · Hereda-de: — · Sustituye: v1.0
- Compatible-con: Guía 16 1.2.0 (cambio de numeración respecto de 0.12.0 a revisar en la remisión); K2, K3, K4, K5
- Versión 1.1 · Estado: Vigente · Fecha: al publicar
- Cambios: (a) §3 nuevo «frontera de competencia» → [Guía §3.7] y K5; (b) §4 agrega A1 (el código elige herramienta/alcance/destino, el modelo sólo redacta), A2 alcance antes de responder, A3 filtro por rol antes de la búsqueda, A4 corpus antes que búsqueda (compuerta de cobertura), A5/A6 destino revalidado por permiso y «ver ≠ hacer»; (c) §9 nuevos REQ-IA con prueba: validador de cifras (A7), habilitación con motivo exacto (A8), huella de voto sin texto (A9-A11), modelo por variable de entorno (D1) con nombre único de clave (E: IA__Modelo); (d) §12 checklist + 8 ítems binarios; (e) §13 PushDispatch como caso aplicado diseñado desde cero (sin clientes ni marcas).
- Cita: Guía §1.2, §3.4–3.7, §5.3–5.4, §7.1, §8.4–8.5, §9, §12, §13, §14, Anexo B.

### K2 — Construcción del asistente de consola sobre un panel
- Alias: AI-Layer-Console-Assistant-Building
- Tema: construir un asistente de consola dentro de un panel de control Blazor: enrutado determinista (herramienta, alcance, destino), redacción acotada por el modelo, RAG sobre la ayuda filtrado por rol, deeplinks revalidados, votos y despliegue
- Consumidor: agente que implementa la capa en un panel existente o nuevo
- Condicion-de-carga: al implementar la consola o tocar su enrutado, corpus, destinos, votos o despliegue; por secciones según §0
- Hereda-de: K1 (la especificación manda; K2 no redefine requisitos, los implementa)
- Compatible-con: Knowledge-Template-Blazor-Interactive-Server-Panel-De-Control (estructura del panel; no se repite), Knowledge-Template-Blazor-Interactive-Server-Sistema-De-Diseno-V2(-Componentes), Knowledge-Bundle-JS (estilos/JS linkeados → E1), Knowledge-Parametros-De-Sistema, Knowledge-Release-Y-Despliegue-Versionado, K3, K5
- Versión 1.0 · Estado: Borrador hasta pasar K3 sobre un segundo sistema · Fecha
- Índice: 0 Propósito y mapa de carga · 1 Cuándo usarlo · 2 Reglas que no se negocian (A1, «No está en la ayuda», ninguna clave en registros E5) · 3 Pipeline: pregunta → alcance → rol → herramienta → contexto → redacción → validación de cifras → destino · 4 Corpus de ayuda: existencia, cobertura como compuerta, ingesta, precalentado de embeddings (D2) · 5 Destinos y deeplinks: revalidar permiso, ver vs hacer, abrir la acción · 6 Elegir entre candidatas (apps de nombre parecido, cuentas) — lógica; la forma del diálogo en K5 · 7 Visualizaciones (torta/barras con «Otras») — implementación; criterio en K5 · 8 Votos con motivo cerrado y huella sin texto persistida (no sólo log, E) · 9 Rol raíz: consola sí o no explícito (E: raíz olvidado) · 10 Despliegue: modelo por variable, un modelo cargado a la vez (D3), compuerta de arranque que avisa si la IA está apagada (E: IA__Modelo) · 11 Checklist binario · 12 Antipatrones de construcción con control · 13 Límites · Glosario
- Cita: Guía §5–9, §12, §13, §15 (como patrón, no como dominio); GDC §3, §5 (cuando cierre).

### K3 — Verificación y aceptación
- Alias: AI-Layer-Verification-And-Acceptance
- Tema: cómo se demuestra que la capa funciona: batería real ×3 contra el modelo con umbral, crítico con nota, lectura humana, capturas lado a lado 1280/390, sitio real con sesión por rol, cifras contra SQL, latencia fría y caliente
- Consumidor: agente verificador o crítico de una mesa de integración; quien decide cerrar una fase
- Condicion-de-carga: antes de declarar cerrada cualquier fase de la capa; al armar baterías o criterios de aceptación
- Hereda-de: — · Compatible-con: K1 (los REQ-IA son lo que se mide), K2, K4, Guía §11
- Versión 1.0 · Estado: Vigente · Fecha
- Índice: 0 Propósito y mapa de carga · 1 Principio: evidencia antes que «cerrado» (E: fases sin evidencia) · 2 Batería: diseño de casos por rol/anillo, ×3, umbral ≥ 90 %, reportar las tres corridas (E: 90 % sin repetir) · 3 Condiciones de medición: modelo frío y cambio de modelo pagado como en la app (E: medir con el modelo cargado) · 4 Crítico con nota ≥ 8 y rondas ajuste → verificación independiente → crítica · 5 Lectura humana de respuestas (dato inventado) · 6 Capturas 1280 y 390, desborde horizontal y corrimiento al recargar, estilos realmente aplicados (E1) · 7 Sitio real con sesión por rol (lo que la demo no muestra) · 8 Cifras contra la fuente SQL · 9 Pruebas de conformidad por reflexión · 10 Latencia · 11 Criterios de parada (cuándo se acepta, cuándo se escala a mesa) · 12 Checklist binario · 13 Plantilla de informe: separar MEDIDO de INFORME
- Cita: Guía §8.5, §11, §13, Anexo B, Anexo E.
- Nota: la guía no menciona «batería»; hueco ya anotado para la otra mesa. K3 no espera: es práctica medida.

### K4 — Forma de trabajo de la mesa de integración
- Alias: AI-Layer-Integration-Working-Method
- Tema: cómo organiza el trabajo quien integra IA en un sistema como lo hizo el equipo de PushDispatch: mesa con especialistas y refutador, propuestas rivales, brecha con un producto de referencia del mercado, PRs ordenados por choque de archivos, registro de frentes medido, coordinación entre sesiones, autocrítica
- Consumidor: agente gestor que preside la integración
- Condicion-de-carga: al iniciar una integración de IA en un sistema nuevo; al planificar fases y PRs
- Hereda-de: Knowledge-Razonamiento-Del-Gestor
- Compatible-con: Knowledge-Mesa-De-Expertos-A-Pedido (formato de mesa: no se repite), Knowledge-Logica-De-Decision (filtrar antes de elevar al PO), Knowledge-Conformacion-Pull-Request-Automatico (PR: no se repite), Knowledge-Turnos-De-Recursos-Compartidos-En-Un-Host, K1, K2, K3, K5
- Versión 1.0 · Estado: Vigente · Fecha
- Índice: 0 Propósito y mapa de carga · 1 Secuencia de fases (especificar K1 → construir K2 → verificar K3, con K5 transversal) · 2 Composición de la mesa para IA: especialistas mínimos (arquitectura, conversacional, seguridad, QA, implementador ingenuo, refutador) · 3 Tabular la brecha con un producto de referencia (sin marca ni capturas con marca) · 4 Plan en PRs ordenados según archivos que chocan · 5 Registro de frentes medido · 6 Coordinación entre sesiones (aviso de SHA, clones compartidos sin checkout/stash) · 7 El reclamo del PO no se repregunta; se mide y se aplica · 8 Tabla índice de antipatrones E1–E9 → conocimiento y control · 9 Autocrítica y cierre · 10 Checklist · 11 Límites
- Cita: Guía §0.2, §3.4, §10, §14, Anexo H.

### K5 — Diseño conversacional del asistente
- Alias: AI-Layer-Conversational-Design
- Tema: qué contesta el asistente y cómo: anillos de competencia, vocabulario del inexperto, destinos y enlace profundo, formato de chat, negativa útil, «No está en la ayuda», aclaración entre candidatas, votos, visualizaciones y nota de métrica
- Consumidor: agente que diseña o revisa las respuestas del asistente
- Condicion-de-carga: al definir la frontera, redactar plantillas de respuesta o revisar una conversación
- Hereda-de: — · Compatible-con: GDC (fuente), Guía §3.7, K1, K2, K3
- Versión 0.9 · Estado: Borrador en espera de la GDC · Fecha
- Índice provisorio (alineado con los borradores cap-02…cap-05 de la otra mesa): 0 Mapa de carga · 1 Principios → [GDC cap. 2] · 2 Anillos y frontera → [GDC cap. 3] + [Guía §3.7] · 3 Vocabulario del inexperto → [GDC cap. 4] · 4 Destinos y enlace profundo → [GDC cap. 5] · 5 Formas de respuesta: chat vs fichas, negativa útil, «No está en la ayuda», elegir entre candidatas, nota de métrica, totales con desglose · 6 Visualización con «Otras» · 7 Votos con motivo cerrado · 8 Checklist · 9 Límites
- Hoy se escriben sólo §5–§7 desde la evidencia (B1–B10) marcadas «a alinear»; §1–§4 son remisiones vacías hasta la entrega.

## 3. Mapa de carga del conjunto (para el agente)
| Situación | Cargar |
|---|---|
| ¿Este sistema necesita IA? / especificar | K1 §0–§2, §11–§12 |
| Arrancar la integración, armar mesa y plan | K4 completo + Razonamiento-Del-Gestor |
| Implementar consola en un panel | K2 §0–§3 + sección del tema + Template Panel-De-Control |
| Redactar respuestas / frontera | K5 (y GDC) |
| Declarar fase cerrada | K3 §1–§3, §11–§12 |
| Desplegar | K2 §10 + Release-Y-Despliegue-Versionado + K3 §7 |

## 4. Reglas de redacción comunes
Imperativos verificables; cada regla con su porqué y su prueba; checklist binario por conocimiento; criterios de parada; anclas estables `#k2-5-deeplinks` etc.; autocontenidos pero sin repetir los conocimientos del workspace (se remiten por alias). Repo público: PushDispatch nombrable; nada de marca del producto de referencia, clientes, organizaciones, IPs, usuarios, claves, servidor ni modelo de IA concreto (se dice «el modelo de redacción» / «el modelo de embeddings»). Las cifras de evidencia (19/20, rondas r2–r8, ~2 s de recarga) se citan sin host.

## 5. Pendientes
- E1 (estilos sin linkear) y E5 (claves en un registro): «a confirmar»; si no aparece evidencia, entran como control preventivo sin anécdota.
- Sacar del inventario, al volcar: organización dueña, nombre del producto de referencia, host, modelos.
- Huecos de la Guía 16 (batería, crítico, capturas, sitio real, candidatas, negativa útil, ver/hacer, deeplink a la acción, cobertura del corpus) ya en para-la-mesa-de-la-guia.md.
- Registrar K2–K5 en Index-Knowledge del workspace sólo como referencia externa (no copiarlos).
