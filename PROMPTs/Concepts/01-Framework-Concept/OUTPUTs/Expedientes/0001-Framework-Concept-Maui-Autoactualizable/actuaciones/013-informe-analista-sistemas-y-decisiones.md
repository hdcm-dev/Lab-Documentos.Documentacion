| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Comisión Analista de sistemas y decisiones |
| Corrige | — |

| Campo | Valor |
| --- | --- |
| Rol | Analista de sistemas con criterios de decisión y análisis de las decisiones (comisión; reemplaza a la comisión de criterios separada) |
| Fecha | 2026-10-25 |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Líneas 1–111 (cabecera y §0 con su «Mapa de carga»); fila «comisión»: la carta (§5.2), §2.2, §3.2, §3.3, §4 |
| Documentos cargados con versión | Cadena-De-Consecuencias 2.0 §2 · Excepcion-A-Un-Conocimiento 2.0 entero (propongo una excepción) · Escalas-De-Juicio 1.0 §3.1–§3.4 (la carta remite a §3.3) · Versionado-Producto-Integral 2.0 §0, §1, §2.7, §2.8 (convención que rige y que toca mi competencia) |
| Ficha de excepción | `despacho/analista-sistemas-y-decisiones-ficha-1.md` (migración de la base local al abrir) |
| Ensayo propio | E-ASD-1: outbox con clave de idempotencia y migración SQLite al arrancar, EF Core SQLite 10.0.11 (§2, H-03) |

Abreviaturas de rutas: `EXP` = la carpeta del expediente 0001; `BIT` = `OUTPUTs/Bitacoras`; `FAPP` =
`/LAB/Lab-Documentos/Lab-Documentos/Concepts/Framework-Concept/Framework-APP.md`; `VPI` =
`<base de conocimiento>/Knowledges/Knowledge-Versionado-Producto-Integral.md`.

## 1. Lectura del objetivo: lo que da por fijo sin origen

| Cláusula del contrato (folio 003) | Origen que declara | Lo que da por fijo sin origen |
| --- | --- | --- |
| OBJETIVO (003:46-51): arquitectura simple/práctica/escalable, Blazor híbrido, actualización al abrir sin tienda, PR/integración/versionado, guía y demo | prompt, cláusula por cláusula | Nada en el objetivo mismo. **Pero el objetivo no contiene login, datos locales, trabajo sin red ni cámara**, y las preguntas P4 y P5 (003:57-58) sí los piden, con origen sólo en el borrador `FAPP` §1 (FAPP:25-33), que el mismo contrato declara «insumo e hipótesis a refutar, no el objeto» (003:40-44). Queda sin declarar cuál de las dos lecturas rige: (L1) lo que «se quiere» en FAPP §1 es requisito del framework y de la demo; (L2) es hipótesis y sólo el prompt fija alcance. «Agregados de la presidencia: ninguno» (003:51) no lo resuelve. → **H-01** |
| DECISIONES CERRADAS (003:77-82): las convenciones de R4 §9 | barrido del índice | `Versionado-Producto-Integral` rige con una condición de carga **conjuntiva** («declara la necesidad de atribuir un error de producción a versiones exactas», VPI:7) que R4 dejó para que la declarara la presidencia (R4:162-166; NV-4, R4:555) y el contrato no declara. Tampoco declara la **fase** del producto (§2.8), y «una fase sin declarar se lee `operativa`» (VPI:292): eso fija qué se exige a la base local (T-3). → **H-02** |

## 2. Hallazgos

| Id | Nivel | Ancla | Hallazgo | Impacto si no se corrige | Dirección de la corrección |
| --- | --- | --- | --- | --- | --- |
| H-01 | P1 | **E2** · 003:46-51 (objetivo sin login/datos/offline) vs 003:57-58 (P4 «¿Cómo entra el usuario…?», P5 «¿Cómo se guardan los datos locales y se trabaja sin red…?») y 003:40-41 («el borrador … es insumo e hipótesis a refutar»). Divergencia ya visible: `BIT/Nucleos/N2…md:502-503` pone en la demo «Login OIDC + PKCE contra Keycloak … Sí» y «Desbloqueo local … Sí»; `BIT/Nucleos/N5…md:441-451` (etapas E00–E09) no tiene ninguna etapa de login | El contrato pregunta por materias que su objetivo no incluye y no dice si FAPP §1 es requisito o hipótesis | Dos implementadores arman dos demos distintas (con y sin IdP); la guía enseña un alcance que la demo no ejecuta, o la demo carga un IdP que nadie pidió | Escribir las dos lecturas (L1/L2) y tomar, declarada, la que menos agrega; lo que se tome de FAPP §1 entra al objetivo como **agregado marcado** con su origen (FAPP:25-33), separando «lo que el framework define en la guía» de «lo que la demo ejecuta». Mi propuesta concreta está en P4 y P11 |
| H-02 | P1 | **E2** · VPI:7 (condición conjuntiva) y VPI:292 («Una fase sin declarar se lee `operativa`»); R4:555 (NV-4: «lo tiene que declarar la presidencia en el contrato»); 003:77-82 (no la declara); R4:186 («[criterio propio] El framework y la demo nacen en `diseño`», sin asentarse en el contrato) | El contrato da por cerrada una convención cuya condición de carga no asentó, y deja sin fase al producto | Leída como `operativa`, la base local de la demo carga respaldo, clase de reversión y expandir/contraer (VPI:287-288) que en `diseño` son opcionales (VPI:286); leída como `diseño`, la guía enseña «se recrea el almacén», que borra el outbox (H-03). Lecturas divergentes sobre qué exige la base local | Asentar en el contrato el origen de la condición conjuntiva (o marcarla como agregado de la presidencia) y declarar la fase de la demo y la que la guía enseña para las apps que se construyan con el framework |
| H-03 | P0 | **E1** + **E2** · Ensayo E-ASD-1 (abajo). E2: VPI:264-266 («Aplicar migraciones al arrancar se rechaza») vs FAPP:291 («scripts numerados que corre el cascarón al arrancar») y la nota de Android «Other apps cannot access files stored within internal storage» (https://developer.android.com/training/data-storage/app-specific, consultado 2026-10-25). Señal previa: R4:478 (T-3) | En el teléfono el único proceso con acceso a la base es el binario. Cumplir §2.7 cláusula 2 literal deja la app sin abrir; cumplir por la fase `diseño` (recrear) borra las acciones encoladas. Medido: «v2-cumplir: NO ARRANCA … codigo_salida=3»; «v2-recrear: … pendientes=0» (antes 3); «v2-migrar: … pendientes=3 claves_conservadas=True ms=349» | Con la convención tal cual, una app del framework que cambie su esquema local tras una actualización por tienda no abre (objetivo imposible: «bajan sus actualizaciones … al abrir», 003:47-48) o pierde datos del usuario | Excepción por contradicción, no por conveniencia: **ficha** `despacho/analista-sistemas-y-decisiones-ficha-1.md`. Camino propuesto (P5): migrar al abrir, en el cascarón, antes del contenido, con respaldo previo del archivo, una transacción, compuerta de esquema exigido/leído después de migrar, y cláusulas 1, 3 y 4 de §2.7 cumplidas. **No detiene la mesa** (Excepcion-A-Un-Conocimiento §4) |
| H-04 | P1 | **E3** + **E2** · FAPP:152 («Ingresos siguientes: … se libera el refresh token, se renueva la sesión y se entra») y FAPP:175-181; `N2:232` (`E --> F[Renovar en el proveedor]`, sin rama para falla de red: sólo `F -- 400/401`); frente a FAPP:248 (`SoloLocal`: «Sin red: Se ejecuta») y `N5:443` (E01, «App abre en modo avión») | **Contraejemplo**: usuario ya vinculado, teléfono en modo avión. Pasa el desbloqueo local, «Renovar en el proveedor» falla por red (ni 400 ni 401): el flujo no dice qué pasa; leído literal, no entra. Las acciones `SoloLocal` y `Encolable` quedan inalcanzables justo cuando son útiles | La política de acciones sin red (FAPP §7) es letra muerta para un usuario con sesión; la etapa E01 de la demo contradice el flujo de N2 | Separar **entrar a la app** (desbloqueo local) de **tener sesión con el servidor** (token): la renovación pasa a segundo plano y no bloquea la entrada; declarar el período de gracia sin red y qué ve el usuario cuando vence (eso último es de seguridad: solicitud en §5) |
| H-05 | P1 | **E3** + **E2** · FAPP:196 («Cerrar sesión = borrar tokens y la clave del Keystore/Keychain»); FAPP:281 (campos del outbox: «id, acción, payload, clave de idempotencia, intentos, próximo intento, estado, error»: sin dueño); `N2:316-326` (estados sin dueño) | **Contraejemplo**: el usuario A encola dos encuestas sin red y cierra sesión; entra B en el mismo teléfono; vuelve la red: el sincronizador manda las encuestas de A con el token de B (atribución falsa), o, si el cierre borra el outbox, se pierden | Datos del usuario mal atribuidos o perdidos sin aviso; el outbox no dice de quién es cada fila | Cada fila del outbox lleva su dueño (identidad que la creó) y el cierre de sesión con pendientes tiene política declarada (avisar y ofrecer enviar primero; nunca enviar con otra identidad) |
| H-06 | P1 | **E3** + **E1** · FAPP:281 (el outbox no guarda versión del payload) y FAPP:284 («La política puede venir en el manifiesto de contenido … pasar una acción de `Encolable` a `SoloEnLinea`»); E-ASD-1: al migrar, las filas viejas quedan con «VersionPayload de filas viejas=1,1,1» (el valor por defecto, no el real) | **Contraejemplo**: el contenido v5 encola `encuesta.crear` con su forma de payload; al abrir otra vez se instala v6 (el requisito central) que cambió esa forma o reclasificó la acción. El sincronizador envía un payload v5 bajo reglas v6 | Rechazos o datos mal interpretados exactamente en el punto donde se cruzan los dos requisitos del pedido (actualizar al abrir + trabajar sin red) | Cada fila registra **al encolar** la acción, la versión de su payload y la versión del contenido que la creó; una reclasificación del manifiesto no se aplica retroactivamente a lo ya encolado; el contrato de la acción declara qué versiones de payload acepta |
| H-07 | P1 | **E3** · FAPP:138-139 («Conservar `vN-1` para rollback» · «Rollback automático: si el contenido no avisa "arranqué bien" … volver al anterior») y FAPP:293 (el contenido guarda por el puente: `db.save("pedidos", obj)`) | **Contraejemplo**: v7 arranca, guarda documentos con un campo nuevo, y en el arranque siguiente falla y vuelve a v6. v6 lee documentos con una forma que no conoce. El rollback vuelve el código, no los datos | El rollback, que es la red de seguridad del canal, puede romper la lectura de datos locales | Los documentos llevan versión de forma; el contenido lee tolerante (ignora lo que no conoce: Martin Fowler, «TolerantReader», bliki, 9-may-2011, https://martinfowler.com/bliki/TolerantReader.html); el manifiesto declara la versión mínima de datos que cada contenido lee; el rollback no revierte datos |
| H-08 | P1 | **E3** + **E2** · FAPP:282 («Un sincronizador la vacía … en orden, con backoff exponencial»); `N2:482` («sincronizador secuencial con backoff»); `N2:325` («Rechazado --> [*]: el usuario descarta o rehace») | **Contraejemplo**: la fila 1 (crear localidad) queda `Rechazado` (412) esperando al usuario; la fila 2 actualiza esa misma localidad; la fila 3 es una encuesta independiente. No está dicho si el sincronizador sigue (y manda la 2, que depende de la 1) o se detiene (y bloquea la 3 indefinidamente) | Dos implementaciones distintas de «en orden»: o cola bloqueada por un elemento (nada se envía) o envíos de dependientes huérfanos | Orden **por entidad** (clave de la entidad afectada), no global; una fila `Rechazado`/`Error` suspende sólo a sus dependientes; estado terminal tipo «carta muerta» visible al usuario |
| H-09 | P1 | **E2** · `N2:488` («D-05 → S1 (`sqlite-net-pcl`) para el framework») vs `N5:413` («Infrastructure/ EF Core SQLite del caso base, con migraciones en vez de EnsureCreated»); `BIT/02-Cohesion-Global.md:36` («Ninguna registrada todavía.») aunque `N2:345` pide registrar otra contradicción en la cohesión | Dos dossiers deciden D-05 en sentidos opuestos y la cohesión global declara cero contradicciones | La guía y la demo salen con dos librerías, o una se reescribe; la condicional `Versionado-Esquema-Base-De-Datos-EF-Layer` (R4 §9) queda indecidible | Una sola decisión de D-05 (mi propuesta en P5) y registrar en la cohesión las dos contradicciones (D-05 y SQLCipher) |
| H-10 | P1 | **E2** · `N5:417` (`servidor/` = «servidor estático de actualizaciones»), `N5:449` (E07: «Encuesta "pendiente" que pasa a "enviada"»), `N2:504` («Encuesta `Encolable` con idempotencia; edición de localidad con 412 · Sí»); 003:84 («FUERA DE ALCANCE: … la API del negocio real») | La demo planificada no tiene receptor de las acciones encoladas: nadie deduplica por `Idempotency-Key` ni responde 412 | La etapa E07 no puede mostrar «enviada», ni la idempotencia, ni el conflicto: lo que la guía enseña no se ejecuta | Un **receptor didáctico mínimo** dentro de `Demo/` (no la API real): deduplica por clave, compara versión con `If-Match`, y se declara como doble de prueba |
| H-11 | P2 | **E2** · `N1:418` («Escala: ●●● favorable, ●● intermedio, ● desfavorable») y filas `N1:422-427` (criterios Simplicidad, Practicidad, Escalabilidad, Riesgo, Costo, Madurez); `N2` §5.2–§5.7 (mismas columnas más Riesgo y Costo). Regla: Excepcion-A-Un-Conocimiento §5.3 («Los pesos se escriben antes de puntuar»; «Los criterios salen de estándares … y se citan») y la carta («matriz … con fuente y pesos fijados antes de puntuar») | Las tablas de decisión de los dossiers no tienen pesos ni fuente de criterio, y suman criterios que el pedido no nombra | El orden de las opciones depende de qué columna mire el lector; D-01…D-07 no son reproducibles | Matriz única con criterios del pedido, fuente y pesos fijados antes de puntuar (§3, «Matriz») |

**Ensayo E-ASD-1** (ancla E1 de H-03 y H-06). Ruta local: `{dir-de-trabajo}/e-asd/` (efímera; no versionable). Comando: `bash correr.sh` (contenedor efímero `fc-asd-e1` desde `mcr.microsoft.com/dotnet/sdk:10.0`, SDK 10.0.400, `Microsoft.EntityFrameworkCore.Sqlite/10.0.11`). Huellas: `src/Program.cs` 0a8a9099…1a391, `correr.sh` 83b53cce…70cd, `salida.txt` d07fa61d…beac. Extracto:

```text
== caso cumplir
v1: esquema=20261025000001_Inicial pendientes=3
v2-cumplir: NO ARRANCA — exigida=20261025000002_VersionDePayload leída=20261025000001_Inicial; …
codigo_salida=3
== caso recrear
v2-recrear: esquema=20261025000002_VersionDePayload pendientes=0
== caso migrar
v2-migrar: esquema=20261025000002_VersionDePayload pendientes=3 claves_conservadas=True ms=349
v2-migrar: VersionPayload de filas viejas=1,1,1
== idempotencia (sobre la base migrada)
sincronizar: envios=6 efectos_en_servidor=3 pendientes=0
duplicado: RECHAZADO (SQLite Error 19: 'UNIQUE constraint failed: Outbox.IdempotencyKey'.)
```

Ejes que no quedaron fijos: el dispositivo (Linux x64, no el g42 ni iOS). El «servidor» de la línea `sincronizar` es un
diccionario en proceso: **modela** la deduplicación, no la mide; lo medido es el índice único de la clave en el
cliente. **NO VERIFICADO**: el comportamiento de la tabla de bloqueo de migraciones de SQLite si Android mata el
proceso a mitad de la migración (la documentación de EF Core advierte que «the SQLite provider uses a lock table that
can become abandoned if the process terminates unexpectedly», https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying, consultado 2026-10-25).

## 3. Respuesta a las preguntas del caso

### Matriz de criterios D-01…D-07 (fijada antes de puntuar)

| Criterio | Peso | Fuente | Qué mide (para que dos lectores puntúen igual) |
| --- | --- | --- | --- |
| K-S Simplicidad | 1 | Pedido: «ventajas de simplicidad y practicidad, escalibilidad» (evidencia 001, Solicitudes); característica *maintainability* de ISO/IEC 25010:2023 (citada sin apartado) | Piezas y conceptos nuevos que un desarrollador sin experiencia debe sostener; 3 = ninguno nuevo, 0 = varios mecanismos propios |
| K-P Practicidad | 1 | Pedido (misma frase); MEDIOS del contrato (003:86-88) | Se construye y ensaya con lo disponible (contenedores Linux, g42, sin Mac); 3 = medido en el g42 o en el entorno, 0 = imposible con los medios |
| K-E Escalabilidad | 1 | Pedido (misma frase); ISO/IEC 25010:2023 (citada sin apartado; que «scalability» sea subcaracterística de *flexibility* queda **NO VERIFICADO**: la norma es de pago y la página de ISO devolvió 403) | Más pantallas, más apps o más usuarios sin cambiar el cascarón ni pasar por tienda; 3 = sin límite estructural |
| Reversibilidad | regla, no peso | Cadena-De-Consecuencias §2, paso 4 | Entre opciones de puntaje parecido gana la reversible; ante empate, decide ella |
| Restricciones duras | compuerta, no peso | 003:72-75 y lectura P0 (003:67) | Una opción que viola una restricción dura no se puntúa |

Pesos iguales porque el pedido enumera los tres criterios sin jerarquía; es la lectura que menos agrega. Cada celda
dice su evidencia; los hechos técnicos se toman como dato de los dossiers y de E01.

| Decisión | Opción | K-S | K-P | K-E | Total | Evidencia por celda (S · P · E) |
| --- | --- | --- | --- | --- | --- | --- |
| D-01 | A WASM en `HybridWebView` | 1 | 3 | 3 | **7** | dos runtimes, interceptor y puente (E01 C-1…C-6) · medido en el g42: v1→v2 sin reinstalar, sha adulterado rechazado (E01 §6.2) · cualquier página Razor (N1:424) |
| D-01 | A′ SPA JS | — | — | — | compuerta | viola «.NET MAUI + Blazor híbrido» (003:73) |
| D-01 | B UI por datos | 2 | 2 | 1 | 5 | sin WASM pero con esquema y renderizador propios (N1:422) · sin ensayo · «lógica nueva = release del cascarón» (FAPP:95) |
| D-01 | C A+B | 0 | 1 | 3 | 4 | suma ambas (N1:422) · dos modelos para el alumno (N1:423) · la más expresiva |
| D-02 | Estático (nginx + manifiesto por canal) | 3 | 3 | 2 | **8** | sin código de servidor · medido con nginx en E01 · rollout por porcentaje del lado del cliente: criterio de N1, sin fuente (N1 §7.4) |
| D-02 | Servicio con lógica | 1 | 1 | 3 | 5 | un servicio más · la API real está fuera de alcance (003:84) · canales por usuario |
| D-03 | T1 sin bloqueo no hay desbloqueo local | 3 | 2 | 3 | 8 | sin código extra · obliga a login con red (ver H-04) · lo que las plataformas imponen (N2 §5.3) |
| D-03 | T2 token sin atar a autenticación | 3 | 3 | 2 | 8 | sin código extra · entra sin red · seguridad degradada (fuera de mi competencia: §5) |
| D-03 | T3 PIN propio | 1 | 2 | 2 | 5 | mecanismo propio (N2 §5.3) |
| D-04 | C1 último gana siempre | 3 | 2 | 1 | 6 | trivial · pérdidas silenciosas (N2 §5.4) |
| D-04 | C2 + «último gana» declarado por acción | 2 | 3 | 3 | **8** | versión + 412 (N2:400) · el caso base trae los dos tipos de operación (N2:504) · escala por acción |
| D-04 | C3 fusión / CRDT | 0 | 0 | 3 | 3 | desproporcionado (N2:484) |
| D-05 | S1 `sqlite-net-pcl` + JSON | 3 | 2 | 2 | 7 | doc oficial MAUI (N2 §4.9) · abandona EF del caso base; migraciones a mano · iOS sin riesgo AOT conocido |
| D-05 | S2 EF Core SQLite (cascarón) + tabla de documentos JSON (contenido) | 2 | 3 | 2 | 7 | un ORM más una tabla genérica · continuidad con R1 (10.0.11) y migración medida en E-ASD-1 · NativeAOT de EF experimental en iOS (N2 §4.9, NO VERIFICADO en .NET 10) |
| D-05 | S3 `Microsoft.Data.Sqlite` | 2 | 2 | 3 | 7 | SQL a mano · sin ensayo · sin riesgo de ORM |
| D-06 | No compilar iOS y declararlo | 3 | 3 | 0 | 6 | nada que montar · posible con los medios · iOS no se atiende |
| D-06 | Runner macOS alojado | 2 | 2 | 3 | 7 | un job más · sin medir en este laboratorio · cubre iOS |
| D-06 | Mac propio | 1 | 0 | 2 | 3 | no hay Mac (003:88) |
| D-07 | I1 cualquier OIDC; Keycloak en contenedor para ensayar | 2 | 2 | 3 | **7** | un contenedor más · el g42 está en otra red y necesitó túnel para alcanzar el laboratorio (E01:323): costo del flujo OIDC en el teléfono sin medir · estándar (RFC 8252, N2 §4.3) |
| D-07 | I2 backend propio que emite tokens | 0 | 1 | 1 | 2 | reimplementar OIDC (N2 §5.7) |
| D-07 | I3 SaaS | 3 | 1 | 3 | 7 | sin infraestructura · cuenta externa en un repo público (003:101-102) |

Lectura de los empates (D-03, D-05, D-06, D-07) por la regla de reversibilidad y lo que cada uno pierde, en las
preguntas de abajo. D-06 queda como dato para la comisión que responde P9 (no es pregunta mía).

### P1 (D-01) — modelo de contenido actualizable

- **Alternativas**: A, A′ (fuera por compuerta), B, C.
- **Cadena de consecuencias.** *Dónde cae*: A cae en el arranque del teléfono y en el puente; B, en el cascarón
  (cada lógica nueva va por tienda); C, en el alumno (dos modelos). *Cuánto pesa*: A medido en el g42 — paquete
  3,39 MB comprimido, primer render a 4,4–6,3 s del inicio del proceso, ~2,1 s del WebView (E01 §6.2); WebView ≥ 94
  exigido (E01 §6.3). B y C, **sin medir**. *Qué pierde la alternativa*: elegir B pierde la actualización de
  comportamiento sin tienda, que es el núcleo del pedido; elegir A pierde ~9 MB planos y depende de la versión del
  WebView. *Reversibilidad*: antes de que haya apps instaladas, pasar de A a B reescribe páginas pero no datos (si
  los datos van como documentos con versión, P5): reversible.
- **Propuesta**: **A**, con la condición de E01 (versión mínima de WebView con pantalla propia). Sensibilidad: B
  sólo gana si la simplicidad pesa más de tres veces que cada uno de los otros dos, lo que el pedido no sostiene.
  Condición para revisarla: el ensayo iOS de D-06 muestra que el contenido no se puede servir por esquema propio.

### P2 (D-02) — canal de actualización

- **Alternativas**: servidor estático firmado vs servicio con lógica.
- **Cadena.** *Dónde cae*: el servicio cae en un componente más que operar y probar, fuera del alcance de la demo
  (003:84); el estático, en el formato del manifiesto. *Cuánto pesa*: estático medido con nginx en E01; el servicio,
  sin medir. *Qué pierde*: el estático pierde rollout por usuario del lado del servidor. *Reversibilidad*: el
  manifiesto queda igual si después lo sirve un servicio en la misma URL: reversible.
- **Propuesta**: **estático y firmado**, con canales `dev/beta/prod`. Desde mi competencia agrego dos requisitos al
  canal, por H-06 y H-07: el manifiesto declara, además de la compatibilidad con el cascarón, **la versión mínima de
  datos locales** que el contenido lee; y el rollback del canal no revierte datos. Retención y firma: son de otras
  comisiones (la retención N≥3 es T-2 de R4).

### P4 (D-03, D-07) — cómo entra el usuario y qué entra en la demo

- **Alternativas de flujo**: (F1) el del borrador, renovación en el proveedor bloqueante en cada entrada (FAPP:152);
  (F2) entrada local y sesión de servidor separadas, renovación en segundo plano; (F3) sin login (sesión por
  dispositivo, como el caso base, R1 §9).
- **Cadena.** *Dónde cae*: F1 cae en el usuario sin red, que no entra (H-04); F2, en una regla de gracia sin red que
  hay que declarar; F3, en las apps reales, que no tendrían identidad. *Cuánto pesa*: F1, contraejemplo E3; F2, sin
  medir; F3, medido en el caso base (la app de Movilidad Urbana funciona sin login, R1 §9). *Qué pierde*: F2 pierde
  la garantía de que cada entrada valide la cuenta contra el servidor; F1 pierde todo el modo sin red. *Reversibilidad*:
  las tres son reversibles mientras no haya usuarios.
- **Propuesta para el framework (guía)**: **F2**. Primer ingreso con cuenta por OIDC en el navegador del sistema
  (RFC 8252, «native apps MUST use an external user-agent», tomado de N2 §4.3); desbloqueo con la seguridad del
  teléfono; la renovación del token no bloquea la entrada y las acciones `Encolable` esperan en el outbox hasta que
  haya sesión. **D-03 = T1** (empate 8–8 con T2 en mi matriz; lo desempata la reversibilidad: un token legible sin
  autenticación que se filtra no vuelve, la comodidad perdida sí se recupera configurando un bloqueo). **D-07 = I1**
  (cualquier emisor OIDC; empate 7–7 con I3, lo desempata que I3 ata un repositorio público a una cuenta externa).
  Las filas del outbox llevan dueño y el cierre de sesión con pendientes tiene política (H-05).
- **Propuesta para la demo (lo mínimo)**: **F3** — la sesión por dispositivo del caso base, sin IdP ni desbloqueo
  local; login y desbloqueo quedan en la guía como concepto con sus diagramas, rotulados «no ejecutado en la demo», y
  como etapa opcional posterior. Motivos: el objetivo del contrato no incluye login (H-01); el g42 no alcanza la red
  del laboratorio sin túnel (E01:323), así que el costo de un IdP alcanzable con HTTPS desde el teléfono está sin
  medir; y agregar la etapa después es reversible. Condición para revisarlo: que la presidencia tome la lectura L1
  de H-01, o que un ensayo del flujo OIDC en el g42 contra Keycloak por túnel cierre en verde.

### P5 (D-04, D-05) — datos locales y trabajo sin red

- **Alternativas de librería**: S1, S2, S3 (empate 7–7–7). **Alternativas de migración**: cumplir §2.7 literal,
  recrear (fase `diseño`), migrar al abrir.
- **Cadena.** *Dónde cae*: con S1 o S3 la línea del esquema local queda sin realización en la base y la mesa tiene que
  declararla (R4 §5.9); con S2 rige la condicional EF-Layer. Cumplir §2.7 literal cae en el usuario (la app no abre);
  recrear, en sus datos encolados; migrar al abrir, en la robustez del arranque. *Cuánto pesa*: medido en E-ASD-1
  (código 3; 3→0 pendientes; 3 conservados en 349 ms). *Qué pierde*: S1 pierde la continuidad con el caso base que la
  guía usa; S2 carga el riesgo AOT de EF en iOS (sin medir); migrar al abrir pierde la separación de permisos de un
  servidor, que en el teléfono no existe. *Reversibilidad*: la librería queda detrás de una interfaz del cascarón
  (`IDb` en FAPP §11): reversible. Migrar al abrir es reversible hoy y deja de serlo cuando haya apps instaladas por
  terceros (ficha).
- **Propuesta**:
  1. **Propiedad del esquema**: el cascarón es dueño de sus tablas fijas (outbox, registro de red, versión de
     contenido); el contenido **no hace DDL**: guarda documentos JSON en una tabla genérica (colección, id, versión de
     forma, json), por la API acotada del puente (FAPP:293; coincide con el motivo de N2:488-494). Una actualización de
     contenido nunca necesita una migración ni una release del cascarón.
  2. **D-05 = S2 para las tablas del cascarón** (EF Core SQLite 10.0.11, continuidad con R1 y migración medida), con
     la tabla de documentos como entidad genérica, así el modelo de EF no depende del contenido. Desempate por
     reversibilidad y por la restricción «Tomar base … MovilidadUrbana.MAUI» (003:73). Condición para revisarla: el
     ensayo iOS (D-06) muestra que EF Core 10 falla con el trimming de Release; entonces S3 detrás de la misma interfaz.
  3. **Migración al abrir** en el cascarón, antes de crear el WebView, con respaldo previo del archivo, una transacción
     y compuerta exigido/leído después de migrar: **ficha XC** (H-03). Mientras se decide, rige el default de
     Excepcion-A-Un-Conocimiento §4 (camino reversible, provisorio). La demo se declara en fase `diseño` (H-02).
  4. **Outbox**: fila en la misma transacción que el cambio local (Richardson, tomado de N2 §4.8); clave de
     idempotencia única (medida en E-ASD-1); dueño (H-05); acción, versión de payload y versión de contenido al
     encolar (H-06); orden por entidad y suspensión de dependientes (H-08). Coincide con la estrategia «lazy writes»
     de Android: «Write to the local data source first, then queue the write to notify the network at the earliest
     opportunity», y su advertencia de conflictos (https://developer.android.com/topic/architecture/data-layer/offline-first,
     consultado 2026-10-25).
  5. **D-04 = C2 + «último gana» declarado por acción**. Android lo nombra: «For mobile apps, a common approach is
     "last write wins."» y «Conflict resolution often requires versioning» (misma URL); C2 agrega la versión que
     evita la pérdida silenciosa. Fuente académica: Martin Kleppmann, *Designing Data-Intensive Applications*,
     O'Reilly, 2017 (capítulo de replicación; sin número de página verificado).

### P11 — alcance mínimo de la demo

- **Alternativas**: (M1) demo completa según N2 §6.5 (IdP, desbloqueo, cámara, outbox, 412); (M2) demo mínima que
  ejecuta cada cláusula del objetivo; (M3) sólo actualización sin tienda.
- **Cadena.** *Dónde cae*: M1 cae en la infraestructura del ensayo (IdP alcanzable desde el g42, sin medir) y en la
  extensión de la guía; M3 cae en el problema de los PR, que quedaría sin demostrar; M2, en elegir bien lo mínimo.
  *Cuánto pesa*: lo del canal está medido (E01); lo demás, sin medir. *Reversibilidad*: sumar etapas es reversible;
  quitar las publicadas no tanto (lectores que ya las siguieron).
- **Propuesta: M2.** Lo mínimo que la demo ejecuta, cada ítem con su cláusula de origen:
  (1) caso base portado a páginas Razor servidas como contenido (prompt: «Tomar base … MovilidadUrbana.MAUI»;
  «paginas … blazor hibridas»); (2) actualización al abrir desde un servidor estático, con semilla, rechazo de paquete
  adulterado y rollback (prompt: «solicita bajar las actualizaciones de forma automatica»); (3) un PR que rompe una
  regla del dominio y queda en rojo en `[self-hosted, i7infra-dev]` (prompt, Contexto y Solicitudes); (4) una encuesta
  encolada sin red con clave de idempotencia, enviada al volver la red a un **receptor didáctico** (H-10), sin IdP.
  Login, desbloqueo y cámara: guía, no demo mínima (P4). Cómo se corre y dónde vive el workflow: la estructura
  `Demo/` y el destino del YAML son de otras comisiones (N5 T-3, N3); desde mi competencia sólo pido que la demo
  declare su fase (`diseño`) y su receptor como doble de prueba.

## 4. Lo que revisé y está bien

| Ítem | Por qué |
| --- | --- |
| E01 mide lo que D-01 necesitaba | Hipótesis única, corridas en el teléfono de juicio con evidencia y huellas, el caso que falla (WebView 83) explicado con su causa y su fuente (E01 §6.3) |
| La tabla de estados del outbox de N2 §4.8 | Distingue error de red, conflicto (412) y error del cliente (400/422), y no reintenta lo que no tiene sentido reintentar; el índice único de la clave lo confirmé en E-ASD-1 |
| R4 detectó T-3 como excepción por contradicción y no la resolvió en silencio | R4:478 deja la señal con doble ancla; este informe la mide y la ficha |

## 5. Solicitudes de convocatoria (fuera de mi competencia)

| Señal | Ubicación | A quién |
| --- | --- | --- |
| Período de gracia sin red con el refresh token y qué se muestra al vencer; empate T1/T2 de D-03 visto desde seguridad | H-04; FAPP:152, 195; N2 §4.4 | Seguridad |
| Si la convención de retención (N ≥ 3, T-2) y el rollback de contenido deben considerar la versión de datos locales (H-07) | R4:477; FAPP:138 | Comisión de versionado/release |
| El folio 001 dice que el pedido pasa a E4 al quedar en «el contrato de entrada (folio 002)»; el contrato es el folio 003 | `EXP/actuaciones/001-presentacion-pedido-del-po.md:21-22` | Presidencia (expediente) |
| D-06: un job iOS en runner macOS frente a «runs-on: [self-hosted, i7infra-dev]» del prompt | Matriz, fila D-06; R4 T-7 | DevOps e integración |

## 6. Fichas de excepción

| Ficha | Convención | Archivo |
| --- | --- | --- |
| Migración de la base local al abrir la app | Versionado-Producto-Integral 2.0 §2.7, cláusula 2 (y §2.8) | `despacho/analista-sistemas-y-decisiones-ficha-1.md` |

Sigue: incorporación del siguiente informe y resolución · presidencia
