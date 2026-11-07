# Folio 002 — Providencia: contrato de entrada y despacho verificado

| Campo | Valor |
| --- | --- |
| Tipo | providencia |
| Fecha | 2026-11-07 |
| Autor | presidencia de la mesa |
| Corrige | — |

Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas: §0, §1, §2, §3, §4, §5, §6, §7, §8 (fila «Presidís
una mesa» del Mapa de carga). Además: Cadena-De-Consecuencias 2.0.

Marcadores de redacción: `<workspace>` = raíz del espacio de trabajo de la sesión;
`<worktree-doc>` = worktree de este repositorio (rama `g18/ia-model-outputs`);
`<worktree-guia>` = worktree de Lab-Documentos (rama `g18/ia-model-guide`). Las rutas internas del
host no se versionan: el repositorio es público.

## Contrato de entrada

```text
PEDIDO (literal): transcripto entero en el folio 001 (testimonio con huella E-8
  4e83fed9bc9f229e2ea4861756cea99531313a28e485e4b34e4249c9a4ed18f6). Autor: el PO. Fecha: 2026-11-07.
ENUNCIADO (§3.1): tabla frase→función en Bitacoras/01-arranque-y-enunciado.md §2, que esta providencia
  hace propia. Sujeto: la guía a crear (no existe: `Guides/IA/IA-Model/IA-Model-Guide.md` está vacío y
  sin versionar en el clon principal; comando: `wc -l` → 0; `git status --short Guides/IA/IA-Model/` →
  `??`). Caso que funciona (forma, no contenido): guías 01–16 fusionadas del repo destino, con las
  convenciones de `ia-db/indexes/10_Convenciones-y-Glosario.md`. Frase con dos lecturas, tomada la que
  menos agrega: «elaborar una guía en …/IA-Model-Guide.md» + Profile que exige conjunto documental →
  IA-Model-Guide.md es el documento raíz (índice y mapa de lectura) y el conjunto vive en
  `Guides/IA/IA-Model/`; la ronda de estructura lo ratifica o lo refuta.
CLASE DE OBJETO: diseño de una norma o decisión (el temario, el marco y la estructura de la guía).
  Clase descartada: corpus documental existente (la guía aún no existe).
OBJETO: la guía de estudio `Lab-Documentos/Guides/IA/IA-Model/` (a crear), rama `g18/ia-model-guide`
  sobre base 31660d3 (origin/main de Lab-Documentos al 2026-11-07).
OBJETIVO: producir una guía de estudio práctica y de referencia sobre modelos de IA
  generativa/NLP/multimodales («Contexto» y «Solicitudes» del pedido) que inicie a un estudiante sin
  conocimiento previo y le transfiera experiencia teórico-práctica («Objetivo» del pedido), organizada
  por núcleos conceptuales con documento de cohesión global («Reglas»), con definiciones, ejemplos
  operables, gráficos mermaid, cuadros comparativos y preguntas guía con respuestas («Solicitudes»),
  fundada en tendencias de mercado y estándares de la industria con evidencia verificable
  («Solicitudes», «Reglas»). Cada cláusula citada; sin agregados.
PREGUNTAS DEL CASO:
  1. ¿Qué núcleos conceptuales cubren el alcance temático que el pedido nombra, sin fragmentar por
     extensión ni dejar huecos?
  2. ¿Qué marco de referencia (escenarios, contextos, actores) sostiene el recorrido formativo?
  3. ¿Qué estructura documental realiza el Profile respetando la ruta pedida?
  4. ¿Qué ejemplos prácticos operables (montar, descargar, entrenar, inferir, medir, RAG) acompañan
     cada núcleo, verificables en un entorno local con modelos open source tipo Qwen?
LECTURA P0–P3: P0 = viola una restricción dura (inventar información; escribir fuera de las rutas;
  omitir un tema que el pedido nombra; romper la audiencia principiante). P1 = hueco, solapamiento o
  error que obliga a retrabajo del conjunto, o ejemplo práctico inviable. P2 = pérdida acotada
  (definición imprecisa, ejemplo mejorable, enlace faltante). P3 = claridad y estilo.
RESTRICCIONES DURAS: no inventar información; toda afirmación respaldada por evidencia verificable;
  documentos jerárquicos, autocontenidos y con índice; descomposición por núcleos conceptuales con
  cohesión global; bitácoras retomables en OUTPUTs/Bitacoras; entregable en
  `Guides/IA/IA-Model/IA-Model-Guide.md` (raíz); español; repositorio público: sin rutas internas del
  host, credenciales ni datos personales.
DECISIONES CERRADAS: las CONVENCIONES QUE RIGEN de abajo; las convenciones de la casa del destino
  (frontmatter doc_id, catálogos ESC-/CTX-/ACT-, marcas de autoridad — ia-db índice 10), como regla
  del producto con su fuente; la guía 16 ya fusionada se referencia, no se duplica (Rule-Documentation,
  única fuente de verdad); reglas R1–R8 de convivencia (worktrees, un PR por vez y por repo).
CONVENCIONES QUE RIGEN (índice: Index-Knowledge.md de IA.Knowledge.Base, cargado en <workspace>/IA/):
  Mesa-De-Expertos-A-Pedido 3.1 (proceso entero) · Mesa 1.1 (§2, §3.3–§3.6, §5) · Escalas-De-Juicio
  1.2 (§3.1–§3.4) · Detencion-Y-Lote 1.1 (§1, §3.1, §3.5) · Expediente 1.0 (forma del expediente) ·
  Excepcion-A-Un-Conocimiento 2.1 · Cadena-De-Consecuencias 2.0 · Mesa-Consulta-A-Un-Tercero 2.0
  (nombrada por el pedido; sin canal vivo: rige la recolección de dudas y el lote al PO) ·
  Logica-De-Decision 1.0 · Icono-Y-Ancla 2.0 (redacción de definiciones) · Indexing 2.1 (ia-db del
  destino) · Conformacion-Pull-Request-Automatico 2.0 (entrega).
  Barrido: grep '^| \[' Index-Knowledge.md | cut -d'|' -f4,6,12  (campo 4 Alias, 6 Tema, 12 Estado);
  salida recortada a alias y Estado en evidencia/003-barrido-indice.txt (47 filas, todas Vigente).
  Versión: grep -m1 '^\*\*Versión' sobre cada documento listado (salida en la misma pieza).
  Descartes (motivo por grupo): Forma-De-Conocimiento y Perfiles-Y-Extension (la guía no es pieza de
  la base ni perfil); Foro-De-Voces y Comunidad-Cientifica-Autoevolutiva (dispositivos distintos del
  pedido: la mesa fue pedida por nombre); Deduccion-De-Reglas-De-Negocio (no hay fuente de negocio);
  Conformacion-Pull-Request-Manual (rige la automática, regla del PO); WhatsApp-Web-MCP (no hay canal
  con tercero); Entorno-De-Ejecucion-Del-Agente (no toca el objeto); Turnos-De-Recursos y
  Valoracion-De-Recursos (el banco de ensayo no declara turno y no hay escasez que valorar);
  Bundle-JS, Clean-Architecture, DataTier*, Media-File-Service*, Migraciones*, Parametros-De-Sistema*,
  Red-Movil, Release-Y-Despliegue, Template-*, Versionado-*, Indexing-aparte-del-destino (dominio
  .NET/SQL/plantillas: su Tema no toca una guía de estudio sobre modelos de IA).
FUERA DE ALCANCE: integración de IA en apps .NET (guía 16, se referencia); creación de laboratorios
  ejecutables con compuerta de CI propia (ninguna frase del pedido los pide); despliegue del corpus
  fuera del repositorio; tocar `PROMPTs/` fuera de `OUTPUTs/` y `Guides/IA/references/` (material del
  usuario).
MEDIOS: lectura del repositorio y de la ia-db; investigación web con referencia y fecha; banco de
  ensayo de inferencia local (API Ollama alcanzable desde la sesión; verificación:
  `GET /api/tags` → 200, modelos qwen3-coder:30b entre otros; en el texto público, `localhost`).
  Sin observar: entrenamiento a escala (sin GPU dedicada declarada): los ejemplos de entrenamiento se
  limitan a lo reproducible en CPU/GPU chica o se marcan «ilustrativo» conforme a Rule-Markdown.
EXPEDIENTE: PROMPTs/Guides/18-IA-Model/OUTPUTs/Expedientes/0001-Guia-De-Estudio-IA-Model/
QUIÉN APLICA: quien convocó (la presidencia) con redactores especialistas fuera del panel, según el
  pedido («la elección de los especialistas y especialistas colaboradores que provean información
  formen el contenido y su edición»). La mesa no redacta la guía: debate, refuta y vota.
PRESUPUESTO: tope de 12 hallazgos por comisión; rondas: estructura (1) + revisión del borrador (2);
  con la regla de cierre propia de la clase cumplida, el cierre será «por decisión» salvo dos rondas
  seguidas limpias.
DESPACHO VERIFICADO: (a) guía destino vacía y sin versionar — comandos arriba, en ENUNCIADO;
  (b) banco de ensayo vivo — comando y salida en MEDIOS; (c) barrido del índice — comando y salida en
  CONVENCIONES; (d) base de Lab-Documentos 31660d3 y de este repo 2c68e21 — `git log --oneline -1`
  en cada worktree; (e) guía 16 fusionada — `git ls-files Guides/IA/ | head` muestra
  `Dot-Net-Integration-AI-Layer-Guide/`; (f) convenciones de la casa — ia-db README e índice 10.
```

## Decisiones de esta providencia

1. Se abre expediente (el caso atraviesa varias corridas y entra material externo): este, 0001.
2. El panel de la ronda de estructura lo vota el jurado (su folio se incorpora al llegar); los roles
   que el pedido manda y no emiten hallazgos quedan fuera del panel: bitacorista (bitácoras por fase),
   entrevistador (destilado de dudas y lote al PO en el cierre), secretaría (pliego y esqueleto, ya
   actuó: evidencia 002).
3. Las cartas de despacho se asientan en `evidencia/` antes de despachar, con los marcadores de
   redacción de arriba; el mapa marcador→ruta real viaja fuera de la carta, en el contexto de ejecución
   de cada agente.
4. La elaboración del contenido (fase 3) es aplicación, no panel: redactores, verificadores técnicos y
   editores reciben carta de mandato propia y sus piezas quedan en el repositorio destino; la mesa los
   revisa en la ronda 2.

Sigue: folio 003 (informe del jurado: composición del panel) · despachos abiertos: jurado-composición;
secretaría (cerrado, evidencia 002) · insumos: folios 001–002, pliego (evidencia 002), barrido
(evidencia 003) · si se corta acá, se invalida sólo la composición del panel: el contrato queda.
