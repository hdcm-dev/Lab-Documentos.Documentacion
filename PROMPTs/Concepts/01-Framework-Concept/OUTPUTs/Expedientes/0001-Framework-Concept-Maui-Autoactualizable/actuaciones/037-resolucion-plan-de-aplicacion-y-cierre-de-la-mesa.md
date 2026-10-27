| Campo | Valor |
| --- | --- |
| Tipo | resolucion |
| Fecha | 2026-10-25 |
| Autor | Presidencia de la mesa |
| Corrige | — |

# Resolución — decisión adoptada, plan de aplicación y cierre de la mesa

## 1. Decisión

Rige el **dictamen consolidado P1–P13 del jurado de la ronda 2 (folio 035, §3)**, con las aprobaciones del PO de los
folios 023 y 036. No se transcribe acá: dos copias divergen. Resumen para orientarse:

| Pregunta | Decisión vigente (detalle en folio 035) |
| --- | --- |
| P1 | Pantallas Razor compiladas a Blazor WebAssembly sin AOT, descargables y firmadas, servidas por HybridWebView con WebResourceRequested; encuestas como definición de datos (encuestaId + version) en entrada propia del índice firmado |
| P2 | Servidor estático; índice firmado ECDSA P-256 por canal y mayor del puente, con expires, retiradas y claves con keyId; activación en el próximo arranque en frío; rollback por marca pendiente y Listo; consulta sin bloquear al abrir, al reanudar (≤ 1 cada 15 min) y tras login; forzado en punto seguro, nunca sin red ni descartando pendientes |
| P3 | Cascarón MAUI + puente Call(sobre) JSON-RPC 2.0 con handshake; contrato = tabla de métodos + catálogo + transporte, fijado por instantánea; predicado único de compatibilidad (puente con techo, requires ⊆ catálogo con rango, WebView ≥ 94) |
| P4 | Framework: OIDC code + PKCE y desbloqueo local separado de la sesión; outbox con dueño. Demo: sin login |
| P5 | EF Core SQLite 10.0.11 detrás de IDb; esquema fijo del cascarón (C-1, folio 023); documentos JSON del contenido; outbox transaccional idempotente con versión de definición; D-04 = versión + 412 |
| P6 | main de hdcm-dev/Lab-Documentos protegido con fw-ok único requerido, estricto y sin bypass (folio 023); workflow único de PR en [self-hosted, i7infra-dev] con guarda de mismo repositorio; merge manual por defecto o automático con delegación asentada (folio 007) |
| P7 | Líneas: cascarón, puente (SemVer, mayor = contrato), contenido (SemVer + commit), definición (entero por encuestaId), catálogo por entrada, esquema; canal no es versión; cuatro versiones visibles en diagnóstico (folio 023 ítem 4) |
| P8 | Compuerta mínima con rojos provocados: build, unitarias de dominio/ViewModels y del actualizador, instantánea del contrato, definiciones contra esquema, catálogo frente a manifiesto, contenido sin AOT, APK y empaquetado |
| P9 | iOS: diseño sin ensayo, NO VERIFICADO (folio 023) |
| P10 | Developer-Guide.md único índice; marco con siete escenarios; inicio rápido v1 → v2; temas por pregunta; anexos con glosario, referencias, mapa guía ↔ demo y pendientes |
| P11 | Demo M2: caso base portado; encuesta de tres pasos como definición v1 → v2; contenido v1 → v2; semilla; firma inválida rechazada; rollback; encuesta sin red por outbox a un receptor didáctico; PR en rojo y en verde en i7infra-dev |
| P12 | Catálogo constante; capabilities {requires, optional} con rango; todo acceso al dispositivo por el puente; capacidad nueva en dos tiempos |
| P13 | Cada respuesta guarda {encuestaId, versionDefinicion}; se conservan definiciones con pendientes; el servidor acepta versiones publicadas no retiradas; retirar con 30 días de aviso; nada descarta pendientes |

## 2. Plan de aplicación (quién aplica: la presidencia, folio 003)

| Tramo | Qué | Cierra con |
| --- | --- | --- |
| A1 | Núcleo de la demo en `Concepts/Framework-Concept/Demo/`: solución, versiones fijas (global.json, MauiVersion), dominio y reglas portados con mapa por archivo, definiciones v1/v2 y su esquema | Build y unitarias en verde en contenedor |
| A2 | Componentes: cascarón (actualizador, servidor de contenido, puente, catálogo, SQLite + outbox, pantallas XAML); contenido Blazor WASM (páginas, renderizador de encuestas, cliente del puente); herramientas (empaquetado, firma, índice, servidor estático, receptor didáctico); suites de la compuerta con su rojo provocado | Cada suite vista en rojo y en verde |
| A3 | Integración: punta a punta en el moto g42 (candado compartido) con v1 → v2 de contenido y de definición, firma inválida, rollback y encuesta sin red sincronizada; workflow `.github/workflows/` en la raíz de Lab-Documentos con `runs-on: [self-hosted, i7infra-dev]` y su equivalente local | Capturas y logs en evidencia; un run_id real en i7infra-runner-dev |
| A4 | Guía en `Concepts/Framework-Concept/` según P10 y el perfil Study-Guide, con verificación de obligaciones (R3), lector sin contexto y crítico de coherencia | Verificador de R3 en verde; recorrido desde un clon limpio |
| A5 | Entrega por PR (Conformacion-Pull-Request-Automatico, folio 007); protección de main después de un fw-ok verde (folio 023); limpieza e inventario | Cierre del ciclo publicado |

**Reintegra:** lo decidido vuelve a la especificación del producto, que es la guía (A4); el borrador `Framework-APP.md`
del PO no se edita y la guía lo cita como antecedente.

## 3. Cierre de la mesa

```text
CIERRE: por decisión — dos rondas; la ronda 2 tuvo 57 hallazgos interpretativos (Mesa §3.5.7 exige dos rondas
        seguidas sin ellos para «por criterio»). Se cierra por decisión de la presidencia para aplicar; lo abierto
        abajo.
RONDAS: 2 · Rendimiento: r1 11,7 y r2 9,8 procedentes por especialista
FOLIOS: r1 13 informes + ficha (folio 022); r2: composición 024, comisiones 025–032 (8), refutador 033,
        análisis 034, veredicto 035 = 12 informes. Cuenta verificada.
EXCEPCIONES A CONOCIMIENTOS: XC-1 decaída (folio 023: C-1, se cumple VPI §2.7)
LOTE: respondido (folios 023 y 036). Sin preguntas abiertas al PO.
DEUDA DECLARADA: iOS sin ensayo; emulador con WebView < 94 no sirve para el contenido; comisión del académico
        editor postergada en r2 (su señal entra en A4 como verificación de la guía); Permissions-Policy NO VERIFICADO;
        aceptación de versiones viejas en servidores reales (ODK Central) NO VERIFICADO.
CORRIDAS DESCARTADAS: refutador r1 de las 19:41 (evidencia 012); carta 025 reescrita al reanudar r2.
```

Sigue: aplicación del plan, tramos A1 a A5 · presidencia · Cierra con: cierre del ciclo de PR publicado y folio archivo
