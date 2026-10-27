| Campo | Valor |
| --- | --- |
| Tipo | providencia |
| Fecha | 2026-10-25 |
| Autor | Presidencia de la mesa |
| Corrige | — |

# Providencia — contrato de entrada de la mesa

```text
PEDIDO (literal): folio 001 (invocación) + evidencia 001 (el prompt byte a byte). Product Owner, 2026-10-25.

ENUNCIADO (§3.1):
  - «Se hace necesario contar con un modelo de aplicación que permita aplicar actualizaciones desde el servidor sin
    pasar por el ciclo de actualización rigido que imponen los store» → REQUISITO. Sujeto: apps .NET MAUI con
    páginas Blazor híbridas, Android e iOS (Framework-APP.md §1).
  - «cuando el usuario abre la aplicación esta aplicación solicita bajar las actualizaciones de forma automatica»
    → REQUISITO (momento: al abrir).
  - «Sería muy intersante poder aplicar actualizaciones dinamicas» → DESEABLE en su forma; el párrafo previo lo
    vuelve requisito («Se hace necesario»). Lectura que menos agrega: requisito el modelo; «dinámicas» = al abrir.
  - «el equipo tiene problemas al introducir un PR sobre una rama estable … puede romper funcionaldiades» → DATO
    (el problema). «La necesidad pasa por tener prodicimientos claros en los PR y en los conceptos de integración y
    versionado del producto» → REQUISITO.
  - «Desarrollar una guía instructiva academica enfocada a un desarrollador sin experiencia … en
    Developer-Guide.md» → REQUISITO. «construir ejemplo de demostración en …/Demo … que sirva para ilustrar con
    ejemplo a dicha guía» → REQUISITO. «Tomar base … MovilidadUrbana.MAUI» → REQUISITO.
  - «Configura el wofklow con este runner de github: runs-on: [self-hosted, i7infra-dev]» → REQUISITO.
  - «Toda la documentación generarla en /LAB/Lab-Documentos/Lab-Documentos/Concepts/Framework-Concept» → REQUISITO.
  - «trazar una arquitectura clara, puede alternativas, … ventajas de simplicidad y practicidad, escalibilidad»
    → REQUISITO (criterio de juicio). «basarse en las tendencias del mercado y los estandares de la industria» → REQUISITO.
  - «Los investigadores especializados pueden ensayar y realizar todas las pruebas que sean necesarias» → DATO
    (autorización de ensayos). «que se armen expedientes, se presenten y evaluen los resultados» → REQUISITO.
  - Reglas del prompt (markdown jerárquico, definiciones, ejemplos, mermaid, autocontenido no delta, índices;
    descomposición por núcleos con bitácoras; no inventar; evidencia verificable; perfil Study-Guide) → REQUISITOS.
  - Mesa-Consulta-A-Un-Tercero citada → la mesa PUEDE consultar a un tercero; el prompt no nombra a la persona ni
    el canal. Lectura que menos agrega: el único interlocutor nombrado es el PO, por el canal de esta corrida.
  Caso que funciona: MovilidadUrbana.MAUI (Lab-E2E.WebBlazor 8fb4c3a): app MAUI Android con capas, tests de
    ViewModels en net10.0 (18/18 hoy, R1) y workflow android.yml. No tiene contenido actualizable ni Blazor.

CLASE DE OBJETO: diseño de una norma o decisión (el framework no existe). Descartada: corpus documental — el
  borrador Framework-APP.md es insumo e hipótesis a refutar, no el objeto.

OBJETO: el framework conceptual descripto por el prompt; insumo: Framework-APP.md (borrador 2026-10-03, sin versionar
  en Lab-Documentos 5d5c2b4) con D-01…D-07.

OBJETIVO: dejar decidida, con fuentes y ensayos, una arquitectura simple, práctica y escalable [prompt, Solicitudes]
  para apps .NET MAUI con páginas Blazor híbridas [prompt, Contexto] que bajan sus actualizaciones del servidor al
  abrir, sin la tienda [prompt, Contexto], con procedimientos de PR, integración y versionado que impidan romper la
  rama estable [prompt, Contexto]; enseñada en Developer-Guide.md para un desarrollador sin experiencia e ilustrada
  por una demo derivada de MovilidadUrbana.MAUI con su workflow en [self-hosted, i7infra-dev] [prompt, Solicitudes].
  Agregados de la presidencia: ninguno.

PREGUNTAS DEL CASO:
  P1 (D-01) ¿Qué modelo de contenido actualizable adopta el framework: WASM empaquetado (A), UI por datos (B), híbrido (C)?
  P2 (D-02) ¿Cómo es el canal de actualización: servidor, manifiesto, firma, canales, staging, rollback y retención?
  P3 ¿Cuál es la arquitectura del cascarón y del puente, y cómo se versiona el contrato y su compatibilidad?
  P4 (D-03, D-07) ¿Cómo entra el usuario: cuenta y luego la seguridad del teléfono; y qué de eso entra en la demo?
  P5 (D-04, D-05) ¿Cómo se guardan los datos locales y se trabaja sin red: SQLite, outbox, conflictos, migraciones?
  P6 ¿Qué procedimiento de PR e integración impide fusionar algo que rompe la rama estable, con runner i7infra-dev?
  P7 ¿Qué líneas de versión tiene el producto, con qué gramática y cómo se relacionan?
  P8 ¿Qué se prueba en cada capa y qué conjunto es compuerta obligatoria del PR?
  P9 (D-06) ¿Dónde se compila y firma iOS, y qué queda verificado y qué no?
  P10 ¿Cómo se estructura la guía: marco de referencia (escenarios, contextos, actores), documentos y recorrido?
  P11 ¿Cuál es el alcance mínimo de la demo, cómo se corre, y dónde vive su workflow?

LECTURA P0–P3:
  P0: viola una restricción dura o hace imposible el objetivo (p. ej. mecanismo que una tienda prohíbe; demo que no corre).
  P1: el plan saldría con retrabajo o con lecturas divergentes entre implementadores o lectores de la guía.
  P2: pérdida acotada (una opción peor sin consecuencia estructural; un ejemplo pobre).
  P3: claridad.

RESTRICCIONES DURAS (del pedido): rutas de entrega (Concepts/Framework-Concept, Developer-Guide.md, Demo/);
  runs-on: [self-hosted, i7infra-dev]; base MovilidadUrbana.MAUI; .NET MAUI + Blazor híbrido; no inventar y toda
  afirmación con evidencia verificable; Markdown jerárquico con índices, definiciones, ejemplos y mermaid,
  autocontenido y no delta; perfil Study-Guide-Documentation; bitácoras en OUTPUTs/Bitacoras.

DECISIONES CERRADAS: las convenciones que rigen (abajo). Restricciones del caso base en su ia-db: las tres apps de
  Movilidad Urbana no comparten proyectos; convención «arquitectura en inglés, dominio en español».

CONVENCIONES QUE RIGEN: bloque de R4 §9 (Bitacoras/Relevamientos/R4-Convenciones-Que-Rigen.md), con el barrido
  `grep '^| \[' Index-Knowledge.md | cut -d'|' -f4,6,12` → 42 filas Vigente; rigen 8, condicionales 3, conducción 8,
  descartadas 23 con motivo. Tensiones T-1…T-7 de R4 §7 van a la base mecánica como señales.

FUERA DE ALCANCE: publicar en tiendas; producción; la API del negocio real; cambiar Lab-E2E.WebBlazor.

MEDIOS: lectura de fuentes oficiales (web, fecha de consulta); compilación en contenedores (imagen lab-e2e-maui-dev:net10);
  emulador propio fc-android-emu (API 30); teléfono real moto g42 por adb remoto (folio 002); runner i7infra-runner-dev.
  Sin observar: iOS (no hay Mac ni runner macOS medidos).

EXPEDIENTE: OUTPUTs/Expedientes/0001-Framework-Concept-Maui-Autoactualizable/ (P = OUTPUTs/Expedientes/ de la carpeta del prompt).

QUIÉN APLICA: la presidencia (quien convoca): el pedido manda construir la guía y la demo. Nunca un rol del panel.

PRESUPUESTO: tope de 12 hallazgos por comisión; una ronda prevista, con segunda ronda si la refutación invierte una conclusión.
  Cierre esperado: por decisión (Mesa §3.5.7 exige dos rondas limpias para «por criterio»).

DESPACHO VERIFICADO:
  - Runner: `docker exec runner-github-dev cat /home/runner/.runner` → agentName i7infra-runner-dev, gitHubUrl
    https://github.com/hdcm-dev; env LABELS=i7infra,i7infra-dev,dotnet,maui-android; RUNNER_SCOPE=org; ephemeral true.
  - Repo destino: `git -C Lab-Documentos remote -v` → hdcm-dev/Lab-Documentos; HEAD 5d5c2b4; `Concepts/` sin versionar.
  - Visibilidad: `curl -s -o /dev/null -w '%{http_code}' https://api.github.com/repos/hdcm-dev/Lab-Documentos` → 200
    sin credenciales (2026-10-25T16:48-03:00): PÚBLICO. Igual Lab-Documentos.Documentacion y Lab-E2E.WebBlazor.
  - Caso base: R1 (MAUI.Tests 18/18, SDK 10.0.400, Maui 10.0.20, EF Core SQLite 10.0.11).
  - Teléfono: folio 002.
```

Sigue: base mecánica, composición del panel por el jurado y despacho de comisiones a ciegas · presidencia · Cierra con: folios informe de cada comisión, del refutador y del jurado
