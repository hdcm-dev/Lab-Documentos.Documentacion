# 03 — Plan del libro `MAUI-Framework-Developer-Guide.md`

> Registro retomable. Destino final: `Concepts/Framework-Concept/MAUI-Framework-Developer-Guide.md` (repo público). Redacción en cinco bloques paralelos: `libro/parte-1.md` … `libro/parte-5.md` en esta carpeta; N9 los une. Fuentes de hechos: `Nucleo-N1.md` … `Nucleo-N9.md`, `02-Cohesion-Global.md`, el repo y los folios del expediente 0001 (hasta 058) y los ensayos E01–E05.

## Índice

1. Convenciones comunes (obligatorias para los cinco bloques)
2. Índice detallado del libro
3. Reparto en cinco bloques
4. Protocolo de entrega y unión
5. Criterios de cierre

---

## 1. Convenciones comunes

### 1.1 Títulos y numeración
- `#` sólo para el título del libro. `##` Partes («Parte I. Fundamentos»), `###` capítulos («Capítulo 3. Actualizar sin tienda…»), `####` secciones «3.2 …», `#####` subsecciones «3.2.1 …». Nada más profundo.
- Anexos: «Anexo A. Glosario», secciones «A.1».
- Figuras «Figura 3.2. Título.» debajo del mermaid; tablas «Tabla 3.1. Título.» encima de la tabla. Numeración por capítulo.
- Anclas: las que genera GitHub desde el título; las referencias internas se escriben «(véase §3.2)» con enlace `[§3.2](#32-...)`.
- Cada capítulo abre con: **Objetivos** (3–5 viñetas), **Requisitos previos** (capítulos), y cierra con **En la industria** (recuadro), **Preguntas guía** y **Resumen**.

### 1.2 Lengua y estilo
- Español rioplatense técnico, voseo, oraciones cortas, voz activa. Sin emojis.
- Primera aparición de un término: **negrita**, definición en una oración, equivalente de industria entre paréntesis en cursiva: **índice del canal** (*channel index*). Después, siempre el término en español.
- Vocabulario fijo (02-Cohesión §3): «índice del canal» y «manifiesto del paquete», nunca «manifiesto» a secas; «cascarón» (*shell*), «contenido» (*web content*), «puente» (*bridge*), «capacidad» (*capability*), «servicio del cascarón», «semilla» (*seed*), «marca pendiente», «retirada», «cuatro líneas de versión».
- «Blazor Hybrid» sólo dentro del recuadro que explica que esto no lo es.
- Identificadores de código en `monoespaciado`, sin traducir (`mandatory`, `expires`, `Listo`).

### 1.3 Evidencia y citas
- Toda afirmación verificable lleva cita en línea, entre corchetes al final de la oración:
  - Repo: `[Demo/src/FrameworkConcept.Shell/Update/Actualizador.cs:35-39]` — ruta relativa a `Concepts/Framework-Concept/`.
  - Documento de la guía: `[03-Integracion-Y-Versionado.md:154]`.
  - Expediente (privado): `[folio 051]` sin enlace ni ruta.
  - Ensayo: `[E03 H-1]`.
  - Web: número de referencia `[R12]` que resuelve en el anexo B.
- Anexo B: `R<n>. Autor/organización. *Título*. URL. Consulta: AAAA-MM-DD.` Si N8 no la verificó todavía: `Consulta: a verificar`.
- Marcas de estado en negrita y mayúscula: **NO VERIFICADO**, **NO EJECUTADO**, **ESPECULACIÓN**, **HISTÓRICO (fecha)**. Cada una se lista en el anexo E.
- Cifras de pruebas o de tiempo medido: nunca en el texto normativo; se escriben «véase la corrida fechada (Anexo H)».
- Prohibido inventar: si no hay fuente, no va o va como **NO VERIFICADO**.

### 1.4 Rutas, enlaces y repo público
- Enlaces siempre relativos al archivo del libro: `[Actualizador.cs](Demo/src/FrameworkConcept.Shell/Update/Actualizador.cs)`. Nunca `](/LAB…`, nunca rutas del home.
- Roles neutros: «teléfono de medida», «emulador de ensayo», «host de compilación», «runner autoalojado». Prohibido: nombres de hosts, modelo o serie del teléfono, IPs, nombres de proyectos privados, datos personales.
- El repo del caso base no se nombra hasta confirmar que es público (02-Cohesión §6).

### 1.5 Mermaid
- Un diagrama por idea, ≤ 15 nodos. Tipos: `flowchart LR/TD` (estructura), `stateDiagram-v2` (ciclos), `sequenceDiagram` (interacciones).
- Etiquetas en español, sin acentos en los IDs (`Cascaron`), con acentos en el texto visible: `Cascaron["Cascarón"]`.
- Sin estilos ni colores (`classDef`, `style`) para que rinda en tema claro y oscuro.
- Siempre con leyenda «Figura X.Y.» y una oración que diga qué mirar.

### 1.6 Ejemplos
- Fragmentos de código copiados del repo, ≤ 25 líneas, con su cita `archivo:líneas` encima. Si se recorta, `// …`.
- Comandos en bloques `bash` relativos a `Demo/`.

### 1.7 Glosario
- Fuente única: capítulo 1 define; el anexo A (bloque 5) junta. Cada bloque entrega al final de su parcial una lista `<!-- GLOSARIO: término | definición | equivalente | §origen -->` para que el bloque 5 la consolide.

---

## 2. Índice detallado del libro

**Portada.** Título, versión del libro, fecha, estado. Índice general. «Cómo leer este libro» (rutas de lectura por perfil, figura 0.1). Convención de marcas.

### Parte I. Fundamentos

**Capítulo 1. Fundamentos: una app híbrida que se actualiza sola y trabaja sin red** — N1 (+ recuadros de N7 y N8)
- 1.1 El problema: pantallas que cambian seguido y una tienda que tarda.
- 1.2 App híbrida: 1.2.1 Cascarón y contenido; 1.2.2 Qué no es (recuadro «Blazor Hybrid no es esto»); 1.2.3 Qué permiten las tiendas (WASM y AOT **NO VERIFICADO**).
- 1.3 Actualización OTA: 1.3.1 Índice del canal frente a manifiesto del paquete; 1.3.2 Ciclo de vida de una versión; 1.3.3 Disparadores (arranque en frío y reanudación implementados; login diseñado, pendiente).
- 1.4 Offline-first: 1.4.1 La base local como fuente de verdad; 1.4.2 El outbox; 1.4.3 Versiones de definición en vuelo (ESC-4).
- 1.5 Temas secundarios en una página: red, autenticación del dispositivo y Keystore (recuadro N7: «la biometría abre un secreto, la identidad la da el servidor, el entorno lo atestigua un tercero»), contrato del puente, capacidades.
- 1.6 Cuatro líneas de versión (definición; detalle en cap. 7).
- Fuentes: `00-Marco.md`, `01:63`, `ContenidoPage.xaml.cs:41-44`, `IndiceDelCanal.cs`, `ManifiestoContenido.cs`, `ParametrosDeProducto.cs:10-34`, `Developer-Guide.md:37`.
- Ejemplos: arranque de la demo (`App.cs:32`, `ArranquePage.xaml.cs:103,112`).
- Mermaid: F1.1 cascarón y contenido (flowchart); F1.2 ciclo de una versión (state); F1.3 outbox (sequence).

**Capítulo 2. Marco de referencia** — N1, N6
- 2.1 Siete escenarios (ESC-1…ESC-7) y su estado.
- 2.2 Contextos y actores.
- 2.3 Mapa del framework y de la demo.
- 2.4 Cómo se relacionan los capítulos (mapa de lectura).
- Fuentes: `00-Marco.md` (§6.3, ESC-6), `05-La-Demo-Como-Caso-De-Estudio.md`.
- Mermaid: F2.1 mapa de piezas; F2.2 mapa de lectura.

### Parte II. Mecanismo

**Capítulo 3. Actualizar sin tienda: OTA firmada con rollback** — N2
- 3.1 El problema y las políticas de las tiendas.
- 3.2 Vocabulario (índice, firma, staging, puntero `current`/`previous`, marca, fallida, retirada, semilla, zip frente a archivos planos).
- 3.3 Por qué confiar: orden de verificación, `expires` (30 días), claves; TUF como referencia.
- 3.4 Ciclo de vida corregido (con anotar fallida → volver a `previous` con marca propia → estado terminal «sin versión sana») y secuencia de consulta y activación en arranque en frío.
- 3.5 Rollback por evidencia: `Listo`, `CargasSinListoParaFallar` como parámetro, idempotencia ante cortes.
- 3.6 La semilla: primer arranque, cascarón nuevo con semilla más nueva que `current`, claves en clon nuevo.
- 3.7 Retención (2 en teléfono, 3 en servidor), retiradas, versión obligatoria (**NO EJECUTADO**).
- 3.8 Costos y arranque: tabla única de TPR (fecha, variante, fusionada) y ~9,13 MB por versión; arranque superpuesto como variante ensayada sin fusionar.
- 3.9 Práctica con `scripts/guion.sh` (pasos 3, 4, 6 y 7).
- 3.10 Lista de verificación de publicación.
- Fuentes: `Actualizador.cs:35-39,92-135,139-160,173-174`, `VerificacionDelIndice.cs:18-22,50`, `FirmaEs256.cs`, `AlmacenDeContenidoEnDisco.cs:61-76`, `ConsultasDelCanal.cs:5-7`, E02, E04.
- Mermaid: F3.1 estados de una versión; F3.2 secuencia consulta→staging→activación; F3.3 rollback.

**Capítulo 4. El cascarón y el contrato del puente** — N3
- 4.1 Frontera entre cascarón y contenido.
- 4.2 El puente: `Call(sobre)`, JSON-RPC 2.0 + `v`, eventos, códigos de error (-32001, -32601, -32002, -32005…).
- 4.3 Transporte: `HybridWebView`, `hybridwebview.js`, ASCII, mayor de MAUI.
- 4.4 El contrato: tabla de métodos, catálogo, instantánea y huella; tipos compartidos en compilación (aclaración C1).
- 4.5 Servicios del cascarón frente a capacidades del dispositivo; `requires`/`optional`; detección por versión de entrada (`auth.session`).
- 4.6 Compatibilidad en tres capas: predicado, despachador, revalidación en el contenido.
- 4.7 Evolución: cambio menor o mayor, ciclo de un cambio, índice por mayor `/canal/puente-N/`.
- 4.8 Cómo se prueba y sus límites (puente simulado desfasable, `requires` sin dispositivo).
- 4.9 Plantilla de método nuevo (sin la pregunta «¿Tiene techo?»).
- Fuentes: `contrato.json` (1.2.0: 21 métodos, 4 eventos, 3 capacidades), `DespachadorDelPuente.cs:104-114`, `BridgeClient.cs:27`, `BridgeSession.cs:80`, `RangoDeVersion.cs:52-55`, `SesionDelContenido.cs:42-46`, `FrameworkConcept.Content.csproj:80`, `puente-simulado.js:32,47`.
- Mermaid: F4.1 frontera; F4.2 tres capas de compatibilidad; F4.3 secuencia de un cambio de contrato.

**Capítulo 5. Trabajo sin red: base local y outbox** — N4 (+ N1 H8)
- 5.1 Offline-first: definición y por qué.
- 5.2 Tablas reales (Outbox, Documentos, Definiciones, VersionesDeContenido, Configuracion) con EF Core SQLite.
- 5.3 Transacción única documento + fila del outbox.
- 5.4 Sincronizador: idempotencia, dueño, orden por entidad, backoff 5 s–10 min, pasada cada 30 s, «Enviar ahora», carta muerta.
- 5.5 Encuestas y versiones de definición en vuelo.
- 5.6 Actualizar sin tocar los pendientes (P13.7).
- Fuentes: `DbSqlite.cs:89,114-115`, `SincronizadorDelOutbox.cs:23-25,98-135,170`, `ContextoDelCascaron.cs:8-12`, `Tablas.cs`.
- Mermaid: F5.1 secuencia guardar→outbox→sincronizar; F5.2 estados de una fila.

**Capítulo 6. Red y sesión del dispositivo** — N4
- 6.1 Estado de red combinado: cuatro estados; salud `GET /salud`, timeout 3 s, caché 10 s, backoff 5–60 s.
- 6.2 Política de acciones (`SoloLocal`, `Encolable`, `SoloEnLinea`), cómo la aplica el despachador, plantilla.
- 6.3 Sesión e identidad: modo Formulario y modo Navegador (RFC 8252 + PKCE); ROPC sólo con el emisor de ensayo; recomendación para producción.
- 6.4 Desbloqueo local y Keystore: BiometricPrompt + `CryptoObject`; apartamiento H-1 (huella nueva no invalida la clave con credencial del dispositivo).
- 6.5 Ningún token cruza el puente.
- 6.6 Tabla única de tiempos (dos backoffs, 15 min de reanudación, 5 min de bloqueo).
- 6.7 Casos medidos (E03, E05) y lo que sigue sin verificar.
- 6.8 Decisiones abiertas D-N4-1…5.
- Fuentes: `TransicionesDeRed.cs:65-68`, `CofreDeSesion.cs:22-28,158-163`, `Oidc.cs:245,249`, `Sesion.cs:172`, `SinTokensEnElPuenteTests.cs:14`, `07-Red-Y-Autenticacion.md` §8.
- Mermaid: F6.1 estados de red; F6.2 secuencia modo Navegador; F6.3 cadena del secreto (biometría→Keystore→refresh token).

### Parte III. Ingeniería

**Capítulo 7. Integración y versionado** — N5 (03 + 06 en un capítulo)
- Parte A, Conceptos: 7.1 Rama estable y PR obligatorio; 7.2 Check agregador `fw-ok` y el peligro de `skipped`; 7.3 Compuerta local igual a la remota (`ci-local.sh`); 7.4 Dos caminos de publicación, cuatro líneas visibles y tres internas; 7.5 Canales y promoción del mismo artefacto.
- Parte B, Procedimientos: 7.6 Rama y PR con plantilla; 7.7 Qué corre el workflow (tabla de `fw-ok`); 7.8 Proteger `main` y probar la protección (folio 051); 7.9 Qué versión sube cada cambio; 7.10 Fusionar, etiquetar, firmar, promover.
- 7.11 Recuadro «Estado al día (2026-11-01)».
- Fuentes: `03-…`, `06-…`, workflow (bloques L166–170, L198–205), folios 048 y 051.
- Mermaid: F7.1 decisión de `fw-ok`; F7.2 líneas de versión y caminos.

**Capítulo 8. Estrategia de pruebas** — N5, N6
- 8.1 Pirámide de pruebas (Core, Update, Gate; compuertas `ElContenidoNoUsaAot`, `SemillaTests`, `SinTokensEnElPuenteTests`).
- 8.2 Rojo provocado: M-13 y el aviso `CS0219`.
- 8.3 Pruebas intermitentes: cuarentena, no reintentos.
- 8.4 Pruebas que atan texto y código (instantánea del contrato, catálogo vs. manifiesto); `FC_GATE_BASE`.
- 8.5 Ejercicio guiado: verde, rojo M-13, rojo aviso.
- Fuentes: `04-Estrategia-De-Pruebas.md`, `Repositorio.cs:57`, ensayo E-N5-01.
- Mermaid: F8.1 pirámide (sin cifras; remite al anexo H).

**Capítulo 9. Seguridad del entorno y cuentas: lo que hace la industria** — N7
- 9.1 Encuadre: qué se toma de las apps de consumo y qué no (F-058: no son modelo para equipos compartidos).
- 9.2 Conceptos: RASP, atestación (Play Integrity, App Attest), superposición, servicios de accesibilidad, acceso remoto, `FLAG_SECURE`.
- 9.3 Caso BNA+: detección de acceso remoto relatada por el PO; tabla mecanismo → API de Android posible; tres hipótesis del cierre (**ESPECULACIÓN**); ensayo E-N7-1 propuesto (sólo logcat).
- 9.4 Caso Mercado Libre: ingreso con la cuenta del teléfono (Credential Manager / «Iniciar sesión con Google»); una cuenta de Gmail no registrada no se da de alta en la app: el alta va separada del ingreso (relato del PO; mecanismo **ESPECULACIÓN**).
- 9.5 ¿Son híbridas? Server Driven UI nativo (F-058); páginas web embebidas con lista blanca y Custom Tabs; contraste con nuestro contenido empaquetado y firmado.
- 9.6 La demo frente a OWASP MASVS (STORAGE, NETWORK, AUTH, CODE, PLATFORM, RESILIENCE): qué cumple, qué no (sin RASP, `allowBackup="true"`, base sin cifrar).
- 9.7 Decisiones D-N7-1…5 (las que tocan código, como propuesta al PO).
- Fuentes: `AndroidManifest.xml`, `CofreDeSesion.cs:20-25`, `debug-overrides`, folio 058, relato del PO (sin folio).
- Mermaid: F9.1 capas de defensa del entorno; F9.2 secuencia ingreso vs. alta de cuenta.

### Parte IV. Práctica

**Capítulo 10. La demo como caso de estudio y ejercicios** — N2, N5, N6
- 10.1 Estructura de `Demo/` (src, tests, scripts, versionado).
- 10.2 Cómo correrla: `dotnet test FrameworkConcept.Demo.SinMaui.slnf`, `ci-local.sh`, `scripts/guion.sh`.
- 10.3 Recorrido guiado paso a paso (enlaza a 3.9, 7, 8.5).
- 10.4 Ejercicios propuestos con criterio de logro.
- Fuentes: `Demo/README.md`, `05-…`.
- Mermaid: F10.1 recorrido del guion.

**Capítulo 11. Cohesión y mantenimiento de la guía** — N6
- 11.1 Definiciones: coherencia documental, dato vivo y dato fechado, fuente única.
- 11.2 De dónde sale cada cifra (tabla de fuentes únicas: `versionado/`, `contrato.json`, `ParametrosDeProducto.cs`, salida de `ci-local.sh`).
- 11.3 Caso didáctico «manda lo medido» (el comentario del cofre).
- 11.4 Cómo verificar: chequeo de referencias, corrida fechada, `docs-enlaces-semanal.yml`, búsqueda de datos de infraestructura.
- Fuentes: `08-Cohesion-Global.md`, Nucleo-N6.
- Mermaid: F11.1 fuentes → pruebas → capítulos.

### Parte V. Industria

**Capítulo 12. El framework en la industria** — N8
- 12.1 Familias híbridas: Cordova, Capacitor, React Native + Expo, Flutter, Blazor Hybrid, PWA (tabla).
- 12.2 Live updates: EAS Update, Appflow, Capawesome, Capgo, CodePush (retiro con App Center), Shorebird.
- 12.3 Equivalencias mecanismo a mecanismo (mayor del puente ≈ runtime version, canales, staging, rollback, semilla, retirada).
- 12.4 Lo que permiten las tiendas y cómo lo cumple la demo (inciso de Apple a verificar).
- 12.5 Estándares: MASVS/MASTG, TUF, RFC 8252/7636, SemVer, JSON-RPC.
- 12.6 Tendencias y extensiones: despliegue por porcentaje, atestación, rotación de claves.
- Mermaid: F12.1 equivalencias demo ↔ industria.

### Anexos
- **A.** Glosario bilingüe (consolidado de los cinco bloques).
- **B.** Referencias con URL y fecha de consulta (R1…Rn).
- **C.** Folios y ensayos citados (número, tema, sin rutas privadas).
- **D.** Mapa libro ↔ demo (sección → archivo).
- **E.** Lista de marcas NO VERIFICADO / NO EJECUTADO / ESPECULACIÓN.
- **F.** Plantillas (método del puente, acción, PR, publicación).
- **G.** Diferencias con el borrador `Framework-APP.md` (activación, rollback, `manifest.json`/`indice.json`, firma, `obligatorio`/`mandatory`, `sqlite-net-pcl`/EF Core, SQLCipher, `/health`/`/salud`, tablas, plugin de biometría, D-03).
- **H.** Historia de tramos y corrida fechada 2026-11-01 (Core 220/220, Update 102/102, Gate 56 + 2 omitidas sin `FC_GATE_BASE` y 58/58 con ella; SDK 10.0.40x).

---

## 3. Reparto en cinco bloques

| Bloque | Archivo | Contenido | Núcleos fuente | Peso |
|---|---|---|---|---|
| B1 | `libro/parte-1.md` | Portada, «Cómo leer», caps. 1–2 | N1, N6 (marco), recuadros N7/N8 | definiciones: los demás dependen de su glosario |
| B2 | `libro/parte-2.md` | Caps. 3–4 | N2, N3 | |
| B3 | `libro/parte-3.md` | Caps. 5–6 | N4 | |
| B4 | `libro/parte-4.md` | Caps. 7–9 | N5, N7 | |
| B5 | `libro/parte-5.md` | Caps. 10–12 y anexos A–H | N6, N8, glosarios de B1–B4 | consolida A, B, E al final |

Para paralelizar sin esperar a B1, todos usan el vocabulario fijo de §1.2; B1 sólo agrega definiciones.

## 4. Protocolo de entrega y unión

1. Cada bloque escribe sólo su parcial y deja al final tres comentarios HTML: `GLOSARIO`, `REFERENCIAS` (R provisorias con prefijo del bloque: `R-B3-1`) y `MARCAS`.
2. B5 renumera las referencias en el anexo B y reemplaza los prefijos en todos los parciales.
3. N9 concatena parte-1…5, regenera el índice general, aplica las seis intervenciones editoriales (contenido, académica, estilo, ortotipográfica, diseño editorial, corrección de pruebas) y publica en `Concepts/Framework-Concept/MAUI-Framework-Developer-Guide.md`.
4. En paralelo, N9 escribe `Conocimientos/Knowledge-App-Hibrida-OTA-Offline-First.md` y la nota de convivencia en `99-Anexos.md` §8.

## 5. Criterios de cierre

- `grep -n '](/LAB' MAUI-Framework-Developer-Guide.md` → 0; búsqueda de nombres de hosts, modelo de teléfono, IPs y rutas del home → 0.
- Toda figura y tabla numerada y referida en el texto; todo mermaid rinde en GitHub.
- Ninguna cifra de pruebas fuera del anexo H.
- Toda marca del texto está en el anexo E; toda `[Rn]` resuelve en el anexo B.
- Ningún término definido dos veces con textos distintos.
