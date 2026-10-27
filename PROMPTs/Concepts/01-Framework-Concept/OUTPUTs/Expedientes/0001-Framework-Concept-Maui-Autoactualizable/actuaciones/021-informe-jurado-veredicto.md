| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Jurado de veredicto |
| Corrige | — |

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Rol | Jurado de veredicto (`Mesa` §3.5.4 y §3.5.5; paso 8 de `Mesa-De-Expertos-A-Pedido` §2.1). Vota; no diseña |
| Fecha | 2026-10-25 |
| Carta | `evidencia/016-carta-jurado-veredicto.md` |
| Norma | `<base de conocimiento>/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` 3.1 |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Cabecera y §0 (líneas 1–111). Por la fila «Sos el jurado (componés el panel o votás el veredicto)» del Mapa de carga: §2 (2.1, 2.2 con su subsección, 2.3), §3 (3.1 a 3.4), §4, §7 y §8 |
| Otros documentos cargados | `Excepcion-A-Un-Conocimiento` 2.0, entero · `Cadena-De-Consecuencias` 2.0, entero · `Mesa` 1.0: §3.5.4, §3.5.5, §3.5.6 y §3.5.7, por remisión del texto de mi acto (la carta nombra §3.5.4 y §3.5.5; el paso 8 de §2.1 remite a ellas) · `Escalas-De-Juicio` 1.0: §3.1 a §3.4, por remisión (la carta da la lectura P0–P3 y la regla «un hallazgo anclado sólo en C no procede») · `Versionado-Producto-Integral` 2.0: cabecera, §2.6, §2.7 y §2.8, por respaldo, para votar R-04, R-09 y la ficha XC-1 |
| No cargados | Dossiers N1–N5, relevamientos R1–R4, bitácoras 01 y 02: sus datos los tomo **por los informes que los citan**, que es lo que el jurado vota. Del borrador abrí sólo las líneas 90–145. La evidencia 012 (corrida descartada) **no se leyó** |
| Insumos leídos | Pedido (evidencia 001 desde la línea 4); folios 001 a 007; los trece archivos de `despacho/` (ocho comisiones de la ronda 1, la comisión en caliente, la ficha, el refutador, el análisis de decisiones y la composición del jurado); informe pericial E01 entero |
| Medios propios | Lectura del árbol: `wc -l` y `grep -n` sobre el folio 003 y la evidencia 001 (para verificar anclas, §1.3); `sed -n` sobre la cabecera y §2.6–§2.8 de `Versionado-Producto-Integral`. Ningún dispositivo, ninguna fuente externa nueva |
| Rótulo de este folio | No nombra el repositorio privado de la app de referencia del PO, ni hosts, direcciones o series de dispositivos (§2.3, barrido) |

# Veredicto del jurado — expediente 0001

## Índice

1. [Cómo vota este jurado](#1-cómo-vota-este-jurado)
2. [Votación de hallazgos, por especialista](#2-votación-de-hallazgos-por-especialista)
3. [Rendimiento por especialista](#3-rendimiento-por-especialista)
4. [Fichas de excepción](#4-fichas-de-excepción)
5. [Dictamen P1–P13](#5-dictamen-p1p13)
6. [Lo que queda abierto para quien pidió](#6-lo-que-queda-abierto-para-quien-pidió)
7. [Señales para la presidencia](#7-señales-para-la-presidencia)

---

## 1. Cómo vota este jurado

### 1.1 Funciones y votos

El jurado vota con las cinco funciones de `Mesa` §3.5.4: **Evidencia** (¿el ancla sostiene el nivel?), **Impacto**
(¿qué pasa si no se corrige, y sobre qué artefacto?), **Costo y beneficio**, **Coherencia histórica** (¿reabre una
decisión cerrada o contradice otro veredicto del ciclo?) y **Riesgo e irreversibilidad**. Cada ítem lleva un voto
(`PROCEDE`, `NO PROCEDE` o `ARCHIVA`, con los rótulos de la carta) y una línea de fundamento. Donde el nivel votado
difiere del declarado, se dice. El veto acotado del juez de riesgo no se usó.

**Declaración de método.** Este jurado es un solo agente que aplica las cinco funciones; no son cinco agentes
independientes. Los votos salieron unánimes en más del 80 % de los ítems (117 de 120 procedentes, §3), así que el
ciclo queda **marcado como sospechoso de homogeneidad** (`Mesa` §3.5.4): el refutador revisa los tres
`NO PROCEDE` (R-01, R-02 y ARQ H-10). Ver §7.

### 1.2 Lectura de los niveles

La del contrato (folio 003, líneas 66–70): **P0**, viola una restricción dura o hace imposible el objetivo; **P1**,
el plan saldría con retrabajo o lecturas divergentes; **P2**, pérdida acotada; **P3**, claridad.

### 1.3 Anclas de Verificación sobre el folio 003 (R-08)

R-08 midió que el folio 003 tiene 107 líneas y que `VER` cita líneas 117, 143, 148, 159 y 163. Comprobé que **cada
cita de `VER` es literal y está desplazada en 71 líneas exactas** (`grep -n` sobre el folio 003): «decidida, con
fuentes y ensayos» está en la 46 (VER: 117), «Sin observar: iOS» en la 88 (VER: 159), las reglas del caso base en la
77–78 (VER: 148–149), `runs-on` en la 73 (VER: 143–145), «QUIÉN APLICA» en la 92 (VER: 163) y el sujeto en la 15–16
(VER: 86–87). Como el texto citado existe tal cual, el juez de evidencia **reancla** esas citas a su línea real y vota
el hallazgo por su mérito. R-08 procede igual: la cita, como estaba, no se podía comprobar.

---

## 2. Votación de hallazgos, por especialista

Abreviaturas de los informes, las del refutador: `REQ`, `VER`, `LSC`, `ARQ`, `ASD`, `DEV`, `SEG`, `ACA`, `CRC`, `REF`.
`EV001` es el pedido; `F003`…`F007`, los folios.

### 2.1 Requisitos (`REQ`) — 12 hallazgos

| Id | Nivel | Voto | Fundamento |
| --- | --- | --- | --- |
| H-01 | P1 | PROCEDE | E2 exacta: F003:31-32 clasifica «pueden ensayar» como DATO y F003:46 lo vuelve obligación, con iOS sin medio (F003:88). Corrección en el dictamen: dos regímenes de verificación (§5, P1 y P9) |
| H-02 | P1 | PROCEDE | E1 (`grep -c atribu` → 0) + E4 (condición conjuntiva de VPI, línea 7, verificada). Mismo defecto que R-04; se resuelve en §5, «Premisas» |
| H-03 | P1 | PROCEDE | E2: F003:57-58 pregunta por login y datos locales sin cláusula en el objetivo. El dictamen declara la función de cada ítem del borrador §1 (§5, P4 y P5) |
| H-04 | P1 | PROCEDE | E2: EV001:37 limita la **documentación**; F003:72 lo extiende a todo el entregable. Lectura del literal adoptada en P11 |
| H-05 | P1 | PROCEDE | E2 + E1 (sin KVM en el runner, R2). P8 declara dónde corre cada suite |
| H-06 | P1 | PROCEDE | Repositorio, rama y grado (diseñado o implantado) sin fijar. P6 los fija y deja la implantación en el lote |
| H-07 | P1 | PROCEDE | E2 sobre los dossiers + SemVer 2.0.0 §10 citada: la regla `≤` no ordena metadatos de build. P7 fija una gramática por línea y la regla de orden |
| H-08 | P1 | PROCEDE | Tres mecanismos de compatibilidad sin precedencia, uno contra VPI §2.6. P3 fija un solo predicado |
| H-09 | P1 | PROCEDE | E2: N2 y N5 deciden D-05 al revés. P5 da una sola D-05 y el momento de las migraciones |
| H-10 | P1 | PROCEDE | Alcance de demo no único y sin receptor de las acciones encoladas. P11 da la lista cerrada |
| H-11 | P1 | PROCEDE | Sin umbral ni instrumento para D-01 y sin criterio para «función nueva de peso». P1 fija los dos |
| H-12 | P2 | PROCEDE | `skipped` aceptado como verde y dos nombres para el único check. P6 y P8 los cierran |

### 2.2 Verificación (`VER`) — 11 hallazgos

| Id | Nivel | Voto | Fundamento |
| --- | --- | --- | --- |
| H-01 | P1 | PROCEDE | Reanclado (§1.3) a F003:15-16, 46 y 88. Coincide con `REQ` H-01; agrega el criterio de cierre de iOS como evento comprobable |
| H-02 | P1 | PROCEDE | E4 verificada: VPI §2.8, «Una fase sin declarar se lee `operativa`». P7 declara `fase: diseño` |
| H-03 | P1 | PROCEDE | E2 `ci.yml:178` del caso base + E4 VPI §5.7. Criterio de aceptación con rojo provocado adoptado en P8 |
| H-04 | P1 | PROCEDE | E1: el grupo `Default` ya corre un repositorio público; `first_time_contributors`. Funda P6 y el ítem 1 del lote |
| H-05 | P1 | PROCEDE | E2 `Actualizador.cs:83-85`: la activación de E01 no es atómica. Se adopta la de E02-R con corte provocado (P2) |
| H-06 | P1 | PROCEDE | E1 medido en esta mesa: el manifiesto está en el camino crítico (1,1 s con servidor que responde error). P2 fija N = 0 |
| H-07 | P1 | PROCEDE | E2 + TUF 1.0.37. Los cuatro rojos (otra clave, versión menor, vencido, archivo alterado) pasan a la suite del actualizador (P8). E-SEG-1 ya los vio en una sonda, no en el actualizador |
| H-08 | P1 | PROCEDE | E1: el adb del teléfono no responde desde el runner; sin KVM. P8 declara la capa de dispositivo manual |
| H-09 | P0 → **P1** | PROCEDE | E1 (no hay `.github/`) + E2 N5 §6.3. Es el mismo defecto que `REQ` H-04 y se corrige leyendo la restricción con su literal: no hace imposible el objetivo |
| H-10 | P1 | PROCEDE | E2 + Android vitals citado. P1 fija métrica, dispositivo y umbral |
| H-11 | P2 | PROCEDE | Reanclado a F003:77-78. Las reglas del caso base para sus tres apps no tienen frase del PO que las extienda a la demo (`Mesa-De-Expertos-A-Pedido` §3.3, «Comportamiento no es restricción»). P10 y P11 las tratan como precedente |

### 2.3 Lector sin contexto (`LSC`) — 12 hallazgos

| Id | Nivel | Voto | Fundamento |
| --- | --- | --- | --- |
| H-01 | P1 | PROCEDE | E2 sobre F003:46-51 contra EV001:17, 35 y 39. El dictamen declara las lecturas («el workflow», «rama estable», «impedir», «ensayos») |
| H-02 | P1 | PROCEDE | E2 + fuente de Microsoft. P1 declara la lectura de «Blazor híbrido» y el glosario |
| H-03 | P1 | PROCEDE | E1: nadie definió el perfil de entrada del lector. P10 lo fija |
| H-04 | P1 | PROCEDE | E2: el único medio reproducible (emulador API 30) no corre la opción A. P11 fija el dispositivo de referencia |
| H-05 | P1 | PROCEDE | E1 + GitHub Docs. P11 ubica el workflow donde GitHub lo ejecuta |
| H-06 | P1 | PROCEDE | La regla de evidencia del pedido (EV001:64) contra iOS sin observar. P9 y P10 fijan el rótulo |
| H-07 | P1 | PROCEDE | Capacidades del borrador sin estatus. P4, P5 y P11 lo declaran |
| H-08 | P2 | PROCEDE | E1: «T-3» nombra dos tensiones distintas. Corrección de forma para la guía y la cohesión |
| H-09 | P2 | PROCEDE | E2: la bitácora de cohesión dice «Ninguna registrada» con contradicciones ya señaladas |
| H-10 | P2 | PROCEDE | E1: el borrador queda en la carpeta de entrega con un enlace roto. P10 decide su estatus |
| H-11 | P2 | PROCEDE | E2 `dev.sh`: depende de otro proyecto y apaga el adb de otro contenedor. P11 adopta la receta propia |
| H-12 | P2 | PROCEDE | La etiqueta del runner es del laboratorio. La guía explica qué reemplazar (P10) |

### 2.4 Arquitecto MAUI (`ARQ`) — 12 hallazgos

| Id | Nivel | Voto | Fundamento |
| --- | --- | --- | --- |
| H-01 | P1 | PROCEDE | E2 + [D3]. Se adopta su dirección: lectura (b), declarada (P1) |
| H-02 | P2 | PROCEDE | E1 (`grep` sin coincidencias en el pedido). Mismo defecto que `REQ` H-03, hallado a ciegas |
| H-03 | P1 | PROCEDE | E1: plantilla MAUI 10 con iOS 15.0 y bloques estáticos desde Safari 16.4 (MDN BCD con huella). P1 fija el piso de iOS |
| H-04 | P1 | PROCEDE | E1 E02-R: la marca pendiente funcionó (corridas 3–5); el temporizador no tiene de dónde fijar X. Adoptado en P2 |
| H-05 | P2 | PROCEDE | E2 + E1 E02-R. Coincide con `VER` H-05 (P2) |
| H-06 | P1 | PROCEDE | E4 VPI §2.6. El contrato real es el puente (P3) |
| H-07 | P2 | PROCEDE | E2 E01 l.46. Con A adoptada, el transporte entra al contrato del puente (P3) |
| H-08 | P2 | PROCEDE | E1 E02-B frente a E01/E02-R en el mismo teléfono. El costo medido de A va a la guía (P1) |
| H-09 | P1 | PROCEDE | E1 E02-R corrida 1 (render esperó la descarga) + Expo. P2 adopta «pedir al abrir, aplicar después» |
| H-10 | P2 | **NO PROCEDE** | Su premisa no se sostiene: el invariante 10 habla del artefacto del release, no de dónde se guarda, y el servidor con N ≥ 3 lo cumple (R-12). Volver a la semilla deja una versión vieja frente a datos nuevos (`ASD` H-07). Lo que sí vale, «la semilla es una versión completa del release», procede por `SEG` H-03 |
| H-11 | P1 | PROCEDE | E2 borrador l.291 y l.293: el contenido no puede migrar sin tienda ni hacer DDL. P5 adopta dos líneas de esquema |
| H-12 | P3 | PROCEDE | E2 sobre el código de MAUI [D8]: en iOS el origen es `app://0.0.0.1/`. Se reescribe C-6 como «documentado, sin ejecutar» (P9) |

### 2.5 Analista de sistemas y decisiones (`ASD`) — 11 hallazgos

| Id | Nivel | Voto | Fundamento |
| --- | --- | --- | --- |
| H-01 | P1 | PROCEDE | E2 + divergencia visible entre N2 y N5. P4, P5 y P11 lo resuelven |
| H-02 | P1 | PROCEDE | E2 sobre VPI líneas 7 y 292 (verificadas). Mismo defecto que `REQ` H-02 y `VER` H-02 |
| H-03 | P0 → **P1** | PROCEDE | E1 E-ASD-1 + E2 Android. La contradicción existe, pero E-AD-1 midió que con un sobre fijo la cláusula 2 se cumple y la app abre: no hace imposible el objetivo. Funda la ficha XC-1 (§4) |
| H-04 | P1 | PROCEDE | E3: usuario vinculado en modo avión no entra por el flujo del borrador. P4 separa entrada local y sesión |
| H-05 | P1 | PROCEDE | E3: encuestas de A enviadas con el token de B. P5 pone dueño a cada fila |
| H-06 | P1 | PROCEDE | E3 + E1. P5 y P13 registran acción, versión de payload, de contenido y de definición al encolar |
| H-07 | P1 | PROCEDE | E3: el rollback vuelve el código, no los datos. P5 adopta versión de forma y lector tolerante |
| H-08 | P1 | PROCEDE | E3: «en orden» tiene dos implementaciones. P5 adopta orden por entidad |
| H-09 | P1 | PROCEDE | E2. Coincide con `REQ` H-09 |
| H-10 | P1 | PROCEDE | E2: nadie recibe lo encolado. P11 suma el receptor didáctico |
| H-11 | P2 | PROCEDE | E2: tablas sin pesos ni fuente en los dossiers. El análisis de decisiones las reemplazó |

### 2.6 Integración, versionado y pruebas (`DEV`) — 12 hallazgos

| Id | Nivel | Voto | Fundamento |
| --- | --- | --- | --- |
| H-01 | P0 → **P1** | PROCEDE | Mismo defecto que `REQ` H-04. Se corrige con la lectura literal (P11): no hace imposible el objetivo |
| H-02 | P0 → **P1** | PROCEDE | E1 M-2 a M-5. Como dice R-05, que `main` esté sin proteger es estado del repositorio, no defecto del plan; el defecto es que el plan no diseñe T1. P6 lo diseña y la implantación va al lote |
| H-03 | P1 | PROCEDE | Doc oficial: la protección no frena a administradores sin «Do not allow bypassing». Adoptado en P6 |
| H-04 | P1 | PROCEDE | E1 M-6, M-9 + doc oficial. La guarda de mismo repositorio va a P6 |
| H-05 | P1 | PROCEDE | E2 + E4. Coincide con `REQ` H-12 y `VER` H-03 |
| H-06 | P1 | PROCEDE | E1 M-12 (verde) y M-13 (rojo): sin rojo provocado, E08 depende del parche que toque el lector. Adoptado en P8 |
| H-07 | P1 | PROCEDE | E2 `android.yml`: corre en otro runner y con `paths`. Tabla diferencial caso base → demo en la guía |
| H-08 | P1 | PROCEDE | E2 R2 + E01 §6.3. La capa de emulador queda fuera de la compuerta (P8) |
| H-09 | P1 | PROCEDE | E4 VPI §2.6 + E01 C-3: la versión del WebView es una dimensión de compatibilidad. Entra al predicado (P3) |
| H-10 | P2 | PROCEDE | E4 VPI §2.3 y §2.8. P7 declara la fase y la clase «paquete» |
| H-11 | P2 | PROCEDE | E2 R1 y R2: local y CI resuelven SDK distintos. P11 fija SDK y workload |
| H-12 | P2 | PROCEDE | E4 Versionado-Paquetes-NuGet §2.7. P8 y P9 declaran iOS sin compuerta |
| (C) | — | ARCHIVA | «Publicar Blazor WASM sin `wasm-tools` dentro del runner» viene anclado en C por la propia comisión: funda una pregunta, que va a §7 como medida pendiente. No cuenta como hallazgo |

### 2.7 Seguridad del canal y tiendas (`SEG`) — 12 hallazgos

| Id | Nivel | Voto | Fundamento |
| --- | --- | --- | --- |
| H-01 | P1 | PROCEDE | E2: el contrato juzga P0 contra las tiendas sin asentarlo como restricción. P1 lo asienta como condición de diseño |
| H-02 | P1 | PROCEDE | E2 sobre el texto de Play (abierto también por `REF`). La guía separa las dos oraciones (P1) |
| H-03 | P1 | PROCEDE | E2 App Review 4.2.3(ii). La semilla es una versión completa del contenido (P2) |
| H-04 | P1 | PROCEDE | E2 `Actualizador.cs:50` + E1 E-SEG-1 C06/C07. Monotonía por canal y vuelta atrás remota sólo hacia adelante (P2) |
| H-05 | P1 | PROCEDE | E1 (`grep` → 0 en N3) + E2. P2 fija la custodia |
| H-06 | P1 | PROCEDE | E2 borrador l.137 + TUF §5.3. Conjunto de claves con `keyId` (P2) |
| H-07 | P1 | PROCEDE | E1 (sin CSP en el contenido) + Play y MASVS. CSP, origen local y puente sólo para el origen local (P3) |
| H-08 | P2 | PROCEDE | E2: tráfico en claro en E01. La demo lo prohíbe (P2) |
| H-09 | P2 | PROCEDE | E1 + MASVS. El refresh token nunca cruza el puente (P4) |
| H-10 | P2 | PROCEDE | E2 App Review 2.1(a) y 5.1.1(v), Play. Va a la guía (P4) |
| H-11 | P1 | PROCEDE | E2. iOS como diseño sin ensayo, con sus riesgos nombrados (P9) |
| H-12 | P3 | PROCEDE | E2 inv. 3 y borrador. El campo `canal` interno informa y no controla (P2) |

Nota del juez de coherencia: la fila 2 de «Lo que revisé y está bien» de `SEG` (activación atómica medida) contradice
`ARQ` H-05 y `VER` H-05, y el código les da la razón a ellos (R-07). No es un hallazgo y no se vota; se registra.

### 2.8 Académico editor didáctico (`ACA`) — 12 hallazgos

| Id | Nivel | Voto | Fundamento |
| --- | --- | --- | --- |
| H-01 | P1 | PROCEDE | Procede por dos de sus tres partes: «sin experiencia» tiene dos lecturas y «corre» no tiene dónde. La tercera (no cambiar Lab-E2E es agregado) no tiene impacto, porque la receta se copia a `Demo/` (P11) |
| H-02 | P1 | PROCEDE | E1 propio: por el camino público no se llega a un APK; la imagen del laboratorio no está en ningún registro. P11 adopta la receta versionada |
| H-03 | P1 | PROCEDE | E2 E01 §6.3. Prerrequisito de dispositivo con su comprobación (P11) |
| H-04 | P1 | PROCEDE | E2 E01 l.105 y l.323. Un solo camino de red, medido antes de escribirse (P11) |
| H-05 | P1 | PROCEDE | La etapa E08 necesita el runner de la org. Equivalente local de la compuerta (P10, P11) |
| H-06 | P1 | PROCEDE | E1: 19 × 7 = 133 subsecciones frente a OB-MD-02 y OB-VOZ-06. Aplicación por escenario en tabla (P10) |
| H-07 | P2 | PROCEDE | GitHub Docs y Diátaxis. Inicio rápido (P10) |
| H-08 | P2 | PROCEDE | E1 propio: workload 10.0.403 frente a 10.0.20. `workloadVersion` en `global.json` (P11) |
| H-09 | P2 | PROCEDE | E2 R3 frente a N5. Las comprobaciones apuntan al rol `GUIA-INDICE` (P10) |
| H-10 | P2 | PROCEDE | E2. Mismo defecto que `LSC` H-09 |
| H-11 | P2 | PROCEDE | E2: reglas apoyadas en fuentes no leídas. La bibliografía cita sólo lo leído (P10) |
| H-12 | P3 | PROCEDE | E1: las dos rutas al perfil omiten `PROMPTs/` |

### 2.9 Caso de referencia y capacidades (`CRC`, en caliente) — 11 hallazgos

| Id | Nivel | Voto | Fundamento |
| --- | --- | --- | --- |
| H-01 | P1 | PROCEDE | E2 F003:46-50 frente al testimonio de F005. Mismo defecto que R-03 (§5, «Premisas») |
| H-02 | P1 | PROCEDE | E2: el caso que funciona del contrato no ejerce el mecanismo. La tabla diferencial de `CRC` §3.1 decide P1 |
| H-03 | P1 | PROCEDE | E2. Coincide con `ARQ` H-01 y `LSC` H-02 |
| H-04 | P1 | PROCEDE | E3 + CodePush y Capawesome. «Obligatorio» en punto seguro (P2) |
| H-05 | P2 | PROCEDE | E1 web: CodePush tenía `isMandatory`; N1 decía que no había equivalente |
| H-06 | P2 | PROCEDE | E2 borrador y E01 + Expo. Coincide con `ARQ` H-09 |
| H-07 | P1 | PROCEDE | E2: «al iniciar sesión» tiene dos lecturas. Disparadores de una misma rutina (P2). Que «muchas aplicaciones» lo hagan queda NO VERIFICADO, y eso no lo vota |
| H-08 | P1 | PROCEDE | E2 sobre la app de referencia (permiso pedido y no declarado) + documentación de Android y Apple. Funda P12 |
| H-09 | P1 | PROCEDE | E2 R1 + F005: lo que cambia seguido es la definición. P1 la separa como datos versionados |
| H-10 | P1 | PROCEDE | E3: respuesta v3 que llega con v4 vigente. Funda P13 |
| H-11 | P2 | PROCEDE | E1 web: Play Core es la interfaz con Play Store; para un APK fuera de Play la pantalla necesita salida propia (P2) |

### 2.10 Refutador (`REF`) — 15 hallazgos

| Id | Nivel | Voto | Fundamento |
| --- | --- | --- | --- |
| R-01 | P1 | **NO PROCEDE** | Su ancla no sostiene la conclusión. (1) EV001:21 pide aplicar actualizaciones «sin pasar por el ciclo de actualización rigido que imponen los store»: lo que pasa por la tienda es el binario, y una app ya baja datos sin tienda, así que la lectura (a) vacía el requisito. (2) El testimonio de F004 que cita dice que en la app de referencia «una actualizacion del contenido solo es cambiar la aplicación web server»: ese contenido es la aplicación web entera, pantallas y comportamiento (`CRC` §3.1). (3) F005: «si la encuesta cambia **o se arregla**». La lectura (b) tiene tres literales: no es un agregado. Sus cifras de costo de A son ciertas y se usan en P1 |
| R-02 | P1 | **NO PROCEDE** | Es lógicamente correcto que la lectura de Microsoft deja actualizar definiciones, pero su conclusión («falso dilema») depende de R-01, que no procede. Con la lectura (b), las páginas actualizables no pueden ser `BlazorWebView`. Lo que sí vale, declarar la lectura de «Blazor híbrido», procede por `ARQ` H-01, `LSC` H-02 y `CRC` H-03 |
| R-03 | P1 | PROCEDE | E2: F005 es testimonio de quien pidió, escrito mientras la mesa corría, y toca lo que el objetivo da por fijo (renglón 2 de §0) |
| R-04 | P1 | PROCEDE | E2 VPI línea 7 y 292 (verificadas) + E1. Pesa sobre P5, P6, P7 y XC-1. §5, «Premisas», muestra que las decisiones valen en las dos ramas |
| R-05 | P1 | PROCEDE | E1 (807 piezas de `Guides/`) + E2. Proteger `main` alcanza a terceros: la implantación va al lote (§6, ítem 1) |
| R-06 | P1 | PROCEDE | E3 GitHub *Secure use reference* + E1 de `VER` H-04. El riesgo residual de W2 lo acepta quien pidió, no el panel (§6, ítem 1) |
| R-07 | P1 | PROCEDE | E2 `Actualizador.cs:83-85` resuelve la contradicción entre `SEG` y `ARQ`/`VER` a favor de estos |
| R-08 | P2 | PROCEDE | E1: las citas de `VER` al folio 003 no existen en esas líneas. El jurado las reancló (§1.3) |
| R-09 | P1 | PROCEDE | E2: cuatro dimensiones de compatibilidad y un `minShellVersion` calculado que sigue siendo piso sin ficha. P3 adopta un solo predicado |
| R-10 | P2 | PROCEDE | E2: la prueba sobre Info.plist no tiene dónde correr en el runner Linux. P12 adopta la versión reducida |
| R-11 | P1 | PROCEDE | E2: `ASD` y `SEG` fijan dos demos. P4 y P11: demo sin IdP |
| R-12 | P2 | PROCEDE | E2 inv. 10: el artefacto del release se retiene en el servidor. P2 adopta r2 |
| R-13 | P2 | PROCEDE | E2 VPI §3.4 + E1 M-11. P8 adopta la compuerta mínima |
| R-14 | P2 | PROCEDE | 19 temas sin derivarlos de decisiones. P10 adopta O3-m-r |
| R-15 | P1 | PROCEDE | E2: la matriz de `ASD` puntuó B sin E02-B y la celda que separaba se apoyaba en el borrador. P1 no se decide por esa matriz |

---

## 3. Rendimiento por especialista

Procedente es lo que este jurado votó `PROCEDE` (`Mesa-De-Expertos-A-Pedido` §4, «Criterio de corte»). El análisis
de decisiones y el jurado no entran en el denominador.

| Especialista | Hallazgos | Procedentes | No procede | Archiva |
| --- | --- | --- | --- | --- |
| Requisitos | 12 | 12 | 0 | 0 |
| Verificación | 11 | 11 | 0 | 0 |
| Lector sin contexto | 12 | 12 | 0 | 0 |
| Arquitecto MAUI | 12 | 11 | 1 | 0 |
| Analista de sistemas y decisiones | 11 | 11 | 0 | 0 |
| Integración, versionado y pruebas | 12 | 12 | 0 | 0 (+1 ítem C archivado, fuera de la cuenta) |
| Seguridad del canal y tiendas | 12 | 12 | 0 | 0 |
| Académico editor didáctico | 12 | 12 | 0 | 0 |
| Caso de referencia y capacidades (en caliente) | 11 | 11 | 0 | 0 |
| Refutador | 15 | 13 | 2 | 0 |
| **Total** | **120** | **117** | **3** | **0** |

**Rendimiento: 117 procedentes / 10 especialistas = 11,7 por especialista.** Reclasificados de P0 a P1: `VER` H-09,
`ASD` H-03, `DEV` H-01 y `DEV` H-02. **Ningún hallazgo procedente queda en P0.**

---

## 4. Fichas de excepción

### XC-1 — migrar la base local al abrir, frente a VPI 2.0 §2.7, cláusula 2

| Cuestión | Voto | Fundamento |
| --- | --- | --- |
| ¿Procede la excepción? | **PROCEDE como ficha admisible**, condicionada a que VPI rija | La contradicción es real y está medida: si el esquema del cascarón cambia, cumplir la cláusula 2 al pie de la letra deja la app sin abrir («NO ARRANCA … codigo_salida=3», E-ASD-1 y E-AD-1 v3), recrear pierde lo encolado («pendientes=0», E-ASD-1), y en el teléfono no existe el «otro acto» que migre (E2, Android, «Other apps cannot access files stored within internal storage»). Es contradicción, no conveniencia (Excepcion §3) |
| ¿Está fundado el camino recomendado? | **SÍ: C-1 (sobre fijo, cumplir) está fundado** | E-AD-1 midió que con un sobre de columnas estables la cláusula 2 se cumple entera, v2 arranca con «exigida = leída» y conserva las pendientes. Criterios con fuente y pesos escritos antes de puntuar; total 31 sobre 36. La alternativa más cercana a cumplir está enumerada (Excepcion §5.3) |
| ¿Y C-2? | **Fundado como camino del evento** «el sobre cambia» (Alt-3, 25) | Es lo único que mantiene la app abierta en el release del cascarón que cambie el sobre. Corrección del jurado: la ficha promete «una transacción», pero EF Core no admite envolver `MigrateAsync` en una transacción explícita (Microsoft Learn, *Applying Migrations*, citado por el análisis §1.2). Si se elige C-2, lo que compensa es la **copia previa del archivo** más la compuerta exigido/leído después de migrar. El invariante 4 de Release-Y-Despliegue apoya esa forma (`REF` §6) |
| Rama de §4 | Reversibilidad, camino reversible | C-1 cumple: la excepción no corre de hecho. La demo no implementa la migración al abrir hasta la respuesta de quien pidió. Ningún paso irreversible se apoya en ella |
| Origen del hecho | De la corrida | La ficha nace en esta mesa. La autocorrección no alcanza porque reabriría una decisión cerrada (Excepcion §4): sale en el lote (§6, ítem 2) |

**Propuestas de excepción sin ficha:** el `minShellVersion` **calculado** de `CRC` §3.4 es un piso a secas frente a VPI
§2.6, sin contradicción que lo justifique. **Se cumple la convención** (R-09): `minShellVersion` sale del teléfono;
si queda como filtro del servidor, se declara derivado del predicado y con techo (P3).

**No admitidas:** ninguna.

---

## 5. Dictamen P1–P13

### Premisas que el dictamen fija antes de responder

| Premisa | Decisión del jurado | Por qué |
| --- | --- | --- |
| **Qué se actualiza** (R-01) | Lectura (b): **las pantallas y su comportamiento, además de los datos** | R-01 no procede (§2.10): EV001:21, F004 y F005 traen las tres el literal |
| **«Blazor híbrido»** (`ARQ` H-01, `LSC` H-02, `CRC` H-03) | Se toma la lectura amplia y se declara: **app híbrida .NET MAUI cuyas páginas se escriben con componentes Razor (Blazor)**. El glosario de la guía separa «Blazor Hybrid» de Microsoft (`BlazorWebView`, compilado en el APK, no descargable) de «Blazor WebAssembly servido en `HybridWebView`», con su «qué NO es» | Con la lectura de Microsoft, la lectura (b) del requisito sería imposible (E01 [D3]). Entre una lectura que vuelve imposible el objetivo y otra que lo cumple, se toma la que lo cumple y se declara |
| **Operación sin red** (R-03, `CRC` H-01) | **Requisito del escenario**: el encuestador toma encuestas sin internet y sincroniza al recuperar la red [F005] | Testimonio literal de quien pidió durante la corrida. La presidencia asienta la cláusula en el enunciado (§7) |
| **VPI rige** (R-04) | **Default mientras quien pidió no conteste: VPI rige, con `fase: diseño` declarada** (sale en el lote, §6, ítem 4) | Está en `decisiones_cerradas` del folio 003 y nadie lo retiró. Y **las decisiones de este dictamen cumplen VPI y valen igual si pasa a condicional**: P3 (predicado con techo), P5 (C-1 cumple), P7 (gramática). Lo único que cambia sin VPI es que XC-1 decae, y C-1 igual se sigue |
| **Conformidad con las tiendas** (`SEG` H-01) | Condición de diseño: lo que se diseña tiene que poder distribuirse por Play y App Store, aunque no se publique | La lectura P0 del contrato ya la usa (F003:67). No se publica nada en tiendas: eso sigue fuera de alcance |
| **Grado de verificación por plataforma** (`REQ` H-01, `VER` H-01, `LSC` H-06) | **Android: decidido con fuente y ensayo. iOS: decidido por fuente, rotulado «diseño sin ensayo, NO VERIFICADO»**, con su evento de cierre (P9) | «Pueden ensayar» es una autorización (F003:31-32), y no hay Mac (F003:88) |

### P1 — Modelo de contenido actualizable (D-01)

**Decisión: opción A, con la definición de la encuesta como datos versionados.**

- **Pantallas:** páginas Razor compiladas a Blazor WebAssembly, empaquetadas como contenido firmado, bajadas por el
  canal (P2) y servidas localmente por `HybridWebView` con `WebResourceRequested` (.NET 10).
- **Condiciones de E01 §7:**
  - C-1: `HybridWebView` + `WebResourceRequested`, no `HybridRoot`;
  - C-2: el paquete trae `_framework/hybridwebview.js` y `<base href="/">`;
  - C-3: Android System WebView ≥ 94, con pantalla propia «actualizá el WebView»;
  - C-4: archivos planos, sin `.br`/`.gz`.
- **Definición de la encuesta:** archivo de datos con `encuestaId` y `version` propios, que viaja **dentro del
  paquete de contenido** (un solo canal) y que dibujan páginas Razor genéricas del contenido (eje b de `CRC` H-09).
  Corregir la encuesta es publicar una definición nueva con versión nueva, aunque viaje en el mismo paquete.
- **Pantallas propias del cascarón** (arranque, error, «actualizá el WebView», «actualizá la app»): XAML, como el caso
  base (`ARQ` P1). `BlazorWebView` no se usa.
- **iOS:** piso del cascarón **iOS 16.4**, y el cascarón comprueba la capacidad del motor antes de cargar el
  contenido (`ARQ` H-03). Diseño sin ensayo (P9).
- **Umbral de arranque (`VER` H-10, `REQ` H-11):**
  - Métrica: TTFD, el tiempo desde el inicio del proceso hasta el primer render del contenido, marcado con
    `reportFullyDrawn`.
  - Condición de la medida: contenido ya instalado y manifiesto sin bloquear (P2).
  - Dispositivo de referencia: el teléfono de juicio, moto g42.
  - **Umbral: ≤ 5 000 ms.** Motivo: Android vitals considera excesivo un arranque en frío de 5 s o más; aplicarlo
    al TTFD es más exigente que Vitals, que lo mide sobre el TTID. Es **criterio del jurado**, anclado en esa fuente.
  - Lo medido lo cumple: 3 692–4 871 ms en E02-R, corridas 2, 4 y 5.
- **«Función nueva de peso» (regla R1 de N1; `REQ` H-11):** un contenido que cambie el propósito declarado en la
  ficha de la tienda, o que agregue un módulo visible que la ficha no describe, sale también por tienda. Lo decide
  quien aprueba el PR, con un campo obligatorio de la plantilla («¿cambia el propósito declarado en la ficha de
  tienda? sí/no»). Fuente: Apple DPLA §3.3.1 y App Review 2.5.2 (`SEG` P1, N1 §4.3). La forma operativa es
  **criterio del jurado**.

**Fundamento.**

- **El requisito:** EV001:21, F004 y F005, como dice §2.10.
- **Tabla diferencial de `CRC` §3.1.** La app de referencia del PO funciona y difiere de lo pedido en una sola
  columna: dónde vive lo que se ejecuta (remoto). F005 obliga a cambiar esa columna, porque sin red la referencia
  cancela toda navegación (E2). **A es la que iguala todo lo demás de la referencia** y cambia sólo esa columna: la
  aplicación web entera, ahora local y versionada. C-min cambia además qué se publica y quién dibuja.
- **Ensayos en Android:**
  - E01 §6.2: viable en el g42, v1→v2 sin reinstalar, sha adulterado rechazado, cero `Uncaught`;
  - E02-R: rollback por marca pendiente;
  - E-SEG-1: firma ECDSA verificada en el teléfono.
- **Play:** la excepción nombra «code that runs in a virtual machine or an interpreter» (`SEG` P1 y H-02; `REF` abrió
  el texto).
- **Análisis de decisiones §5:** si R-01 toma la lectura (b), P1 pasa a A más la definición como datos.

**Qué se descartó y por qué.**

- **D, sitio remoto:** sin red no opera (E2, `CRC` §3.1) y contradice F005.
- **C-min, sólo definiciones en `BlazorWebView`:** es la más barata medida (E02-B, 1,6–1,7 s), pero pierde la
  corrección de pantallas sin tienda que piden EV001:21, F004 y F005. La decisión del análisis por C-min dependía de
  R-01, que no procede.
- **A pura, con la encuesta como código:** ata la versión de la encuesta a la del código y complica P13 (`CRC` H-09).
- **C de N1, A más un renderizador en el cascarón:** dos modelos para un principiante (`ARQ` P1).
- **Corrección a la matriz del análisis:** su fila «C-full» (13 puntos) puntuó con celdas de la C de N1 (dos
  renderizadores). La forma que se adopta acá tiene el renderizador dentro del contenido: un solo runtime y un archivo
  de datos.

**Costos aceptados, que la guía escribe:**

- unos 2 s más de arranque que B y 9,13 MB por versión retenida (E1, `ARQ` H-08);
- WebView ≥ 94;
- iOS ≥ 16.4;
- `.wasm` frente a App Review 2.5.2, NO VERIFICADO;
- la mejora `InvariantGlobalization`, sin medir.

**Condición de revisión.** Cualquiera de estos hechos:

- el TTFD supera 5 000 ms en el teléfono de referencia, o en el de gama más baja que el producto declare soportar. Se
  evalúa B (C-min) para las pantallas, con E02-B como base;
- una revisión real de Apple rechaza el `.wasm`. iOS pasa a B;
- un PR cambia código Razor sólo para corregir una encuesta. Ese día la definición no alcanzó, y se revisa su esquema.

### P2 — Canal de actualización (D-02)

**Decisión.**

**Servidor y firma**

| Pieza | Decisión |
| --- | --- |
| Servidor | Estático, con un índice firmado por canal (`dev`/`beta`/`prod`). Cada canal es un índice distinto y el cliente rechaza el de otro canal |
| Qué se firma | El índice, byte a byte. Lista cada archivo con `size` y `sha256` |
| Algoritmo | ECDSA P-256 con SHA-256, de la plataforma, sin dependencias |
| Claves | Conjunto embebido con `keyId`: la activa y una de reserva fuera de línea |

**Verificación y activación en el cliente**

| Pieza | Decisión |
| --- | --- |
| Orden de verificación | Firma → `expires` → versión estrictamente mayor que la instalada en ese canal → hash por archivo sobre lo descargado → descomprimir en `staging/` |
| Activación | Directorios inmutables `versions/vN` y un `puntero.json` reemplazado con un solo `rename` (E02-R). El borrado de versiones viejas sale de la activación y va a la retención |
| Rollback local | Marca «pendiente» al activar, que el contenido borra con `Listo(version)` por el puente. Si el arranque siguiente la encuentra, vuelve a `previous`, que ya se había verificado, y anota la versión en una lista local de fallidas que no se reinstalan |
| Rollback remoto | No existe. Se vuelve **hacia adelante**: se republica el contenido bueno con una versión mayor. `rollBackToEmbedded` no entra |
| `expires` vencido | No se acepta contenido nuevo; lo instalado sigue funcionando sin red |
| Retención | Servidor: N ≥ 3 artefactos del release (inv. 10). Teléfono: `current` + `previous` |
| Semilla | Una versión **completa** del contenido, producida en el mismo pipeline y firmada igual. No es destino de rollback |
| Transporte | Sólo HTTPS. Sin tráfico en claro |

**Momento**

| Pieza | Decisión |
| --- | --- |
| Espera al abrir | **N = 0**: no se espera la red; arranca lo instalado |
| Consulta | En segundo plano, con tres disparadores de una misma rutina: arranque en frío (el requisito), reanudación y login con cuenta exitoso (F004). El desbloqueo local no dispara nada que necesite red |
| Activación | En el próximo arranque en frío |
| Temporizador X | No hay. El rollback es por marca, no por tiempo |

**Forzado (F006)**

| Pieza | Decisión |
| --- | --- |
| Contenido | `mandatory` en el índice. Se activa apenas está bajado y verificado, en el próximo **punto seguro**: un arranque en frío, o el fin de la encuesta en curso con un aviso |
| Sin red | No se fuerza, porque no se puede forzar lo que no se puede bajar |
| Pendientes | Ningún forzado descarta, migra ni invalida pendientes (P13) |
| Bloqueo | Sólo bloquea si el servidor **rechaza** la versión de contenido en uso |
| Cascarón | Política de soporte del servidor (versión mínima soportada del cascarón), separada de la compatibilidad de P3. Android desde Play: flujo inmediato de In-App Updates. APK fuera de Play: pantalla propia con enlace. iOS: pantalla de bloqueo y ficha de la App Store. Sin red no bloquea |

**Custodia de la clave**

- **Demo:** clave de demostración generada en la máquina de quien corre la demo por su guion. No se versiona ninguna
  clave privada. La compuerta del PR usa una clave **de prueba**.
- **Producción:** se enseña como diseño, no implantado. La firma corre en un job aparte con *environment* protegido y
  revisor obligatorio. La clave de contenido y el certificado de Apple son secretos distintos, con custodios distintos.

**Fundamento.**

- `SEG` P2 y E-SEG-1: 11 de 11 casos en el g42; verificar cuesta entre 1,5 y 8 ms después del primer uso.
- TUF 1.0.37 §5.3 y §5.5.
- Activación: `ARQ` H-05 y E02-R; R-07.
- Retención: R-12 e invariante 10, leído por el análisis.
- Semilla: `SEG` H-03, App Review 4.2.3(ii).
- Momento: `ARQ` H-09, `CRC` H-06 y Expo (`checkAutomatically` `ON_LOAD`, `fallbackToCacheTimeout` 0), abierta por `REF`.
- Forzado: `CRC` H-04 y §4.
- Custodia: `SEG` H-05 y H-06; `DEV` H-04 («nada de secretos en jobs de PR»).

**Qué se descartó y por qué.**

- **Activación de E01:** no es atómica (E2, `Actualizador.cs:83-85`).
- **Temporizador X:** no hay de dónde fijarlo (`ARQ` H-04).
- **Semilla como tercer respaldo:** volvería a una versión vieja contra datos nuevos (`ASD` H-07).
- **TUF completo:** sin biblioteca .NET móvil verificada.
- **Sigstore en el teléfono:** necesita red al arrancar.
- **Sólo HTTPS + sha256:** no protege frente a un servidor comprometido.
- **Ed25519:** necesita una dependencia de terceros y en iOS no está verificado.
- **Forzado `IMMEDIATE`:** pierde la entrada en curso (Capawesome, CodePush).

**Condición de revisión.**

- Una corrida en el g42 con `current` y `previous` fallidas a la vez, sin red. Revisa la retención.
- Un primer arranque que no puede funcionar con la semilla. Revisa la semilla y obliga a pedir conformidad con el
  tamaño (4.2.3(ii)).

### P3 — Cascarón, puente y compatibilidad

**Decisión.**

**Cascarón:** una app MAUI con:

- pantallas propias en XAML;
- el actualizador;
- el servidor de contenido (`WebResourceRequested`);
- el puente;
- el catálogo de capacidades (P12);
- un solo `HybridWebView`.

**Puente**

- Un único método `Call(sobre)`, registrado con `SetInvokeJavaScriptTarget`.
- Sobre con forma JSON-RPC 2.0 más `v`.
- Eventos por `InvokeJavaScriptAsync`.
- Al cargar, `bridge.handshake` y `Listo(version)`. El `handshake` devuelve la versión del puente y el catálogo.
- El transporte (`_framework/hybridwebview.js` y `__hwvInvokeDotNet`) **forma parte del contrato** y su dueño es el
  cascarón (`ARQ` H-07).
- Seguridad:
  - el puente atiende sólo al origen local;
  - el cascarón bloquea la navegación a otros orígenes;
  - el contenido lleva CSP: `default-src 'self'; script-src 'self' 'wasm-unsafe-eval'`, `connect-src` acotado y
    `object-src 'none'` (`SEG` H-07);
  - el refresh token nunca cruza el puente (`SEG` H-09).

**Compatibilidad:** un solo predicado, que el actualizador evalúa **antes de activar**:

```text
puente ∈ compatible-con-puente: >=A.B.C <(A+1).0.0
  ∧ requires ⊆ catálogo del cascarón
  ∧ motor ≥ mínimo   (Android: WebView ≥ 94; iOS: 16.4)
```

- La forma del rango es la canónica de VPI §2.6.
- `minShellVersion` **sale del teléfono**. Si el servidor lo usa como filtro para no ofrecer un paquete, se declara
  derivado del predicado y con techo.
- Lo opcional lo resuelve el `handshake`.

**Fundamento.** R-09; `ARQ` H-06 y H-07; `DEV` H-09; `CRC` §3.4 y H-08; VPI §2.6 («Nunca un piso a secas»),
verificada; Expo `runtimeVersion` (`ARQ` [D7]).

**Qué se descartó y por qué.**

- **(a) Sólo un rango sobre el puente:** no detecta una capacidad faltante, que es la falla que la app de referencia
  ya muestra en producción (`CRC` H-08).
- **(b) Rango + WebView:** mismo defecto.
- **`minShellVersion` como piso:** contra VPI §2.6 y sin ficha.
- **`handshake` como único decisor:** detecta tarde, con el contenido ya activado.

**Condición de revisión.** En los rojos provocados de la compuerta, una de las tres dimensiones nunca rechaza un
paquete. En ese caso se quita.

### P4 — Entrada del usuario y qué entra en la demo (D-03, D-07)

**Decisión para el framework** (se enseña en la guía; el flujo es F2 de `ASD`)

| Pieza | Decisión |
| --- | --- |
| Entrada local y sesión | Van **separadas**. Entrar a la app es el desbloqueo local; la sesión con el servidor es el token. La renovación corre en segundo plano y nunca bloquea la entrada. Las acciones `Encolable` esperan en el outbox hasta que haya sesión válida. **No hay período de gracia local**: sin red se opera sin límite de tiempo, y al vencer la sesión del servidor el usuario vuelve a ingresar con red antes de sincronizar |
| Primer ingreso | OIDC con *authorization code* + PKCE en el navegador del sistema (RFC 8252, citada por N2) |
| Desbloqueo local, Android | Keystore con `setUserAuthenticationParameters` (API ≥ 30) |
| Desbloqueo local, iOS | Keychain con `userPresence`; LocalAuthentication para rostro (App Review 2.5.13) |
| D-03 | **T1.** Sin bloqueo de pantalla, o con API < 30, el desbloqueo local no se ofrece |
| D-07 | **I1**: cualquier emisor OIDC; Keycloak en contenedor para ensayar |
| Outbox | Cada fila tiene **dueño**. Al cerrar sesión con pendientes se avisa y se ofrece enviar primero. Nunca se envía con otra identidad |
| Tiendas | Cuenta de demostración para la revisión. Si la cuenta se crea dentro de la app, borrado de cuenta dentro de la app y por la web (`SEG` H-10) |

**Decisión para la demo.** **Sin IdP**: la sesión por dispositivo del caso base. Login, desbloqueo y el disparador «al
iniciar sesión» van a la guía, rotulados «no ejecutado en la demo».

**Fundamento.** `ASD` H-04 y H-05 (E3); `SEG` P4 ([S12] Android, verificada por esa comisión); R-11; análisis P4 (26
frente a 16 puntos, y el paso 4 de la cadena).

**Qué se descartó y por qué.**

- **F1, del borrador:** el usuario sin red no entra (E3).
- **T2:** un token legible sin autenticación no vuelve si se filtra.
- **T3:** un mecanismo propio contra fuerza bruta.
- **I2:** reimplementar OIDC.
- **I3:** ata un repositorio público a una cuenta externa.
- **Demo con Keycloak:** el teléfono necesitó un túnel público para llegar al laboratorio (E01 l.323); costo sin medir.

**Condición de revisión.** El ensayo E-N2-1 cierra en verde en el g42 por un camino de red que la guía pueda enseñar.
Entonces el login entra a la demo como etapa opcional.

### P5 — Datos locales y trabajo sin red (D-04, D-05)

**Decisión.**

| Pieza | Decisión |
| --- | --- |
| Propiedad del esquema | El cascarón es dueño de sus tablas (outbox, registro de red, versión de contenido, configuración). El contenido **no hace DDL**: guarda documentos JSON en una tabla genérica (colección, id, versión de forma, json) por la API acotada del puente. Una actualización de contenido nunca necesita migración ni release del cascarón |
| D-05 | **S2: EF Core SQLite 10.0.11** para las tablas del cascarón, detrás de `IDb` |
| Migraciones | XC-1, **C-1**: sobre de columnas estables y cláusula 2 de VPI §2.7 cumplida (el binario exige su número y no arranca si no coincide). Cláusulas 1, 3 y 4 cumplidas. `fase: diseño` declarada (P7) |
| Datos del contenido | Cada documento lleva su versión de forma. El contenido lee con un lector tolerante (Fowler, *TolerantReader*). El rollback no revierte datos |
| Outbox | La fila se escribe en la misma transacción que el cambio local. Clave de idempotencia única (medida en E-ASD-1). Lleva dueño (P4), y desde que se encola, la acción, la versión de su payload, la versión de contenido y `{encuestaId, versionDefinicion}` (P13). Una reclasificación del índice no se aplica a lo ya encolado |
| Orden | **Por entidad**. Una fila en `Rechazado` o `Error` suspende sólo a sus dependientes. El estado terminal («carta muerta») se le muestra al usuario |
| D-04 | **C2**: versión + 412, con «último gana» declarado por acción |

**Fundamento.**

- E-ASD-1 y E-AD-1 (E1).
- Android, *Build an offline-first app*: «Write to the local data source first, then queue the write»
  (`ASD` P5, `CRC` [F7]).
- `ASD` H-05 a H-08; `ARQ` H-11.
- Análisis P5: empate 26–26 entre S1 y S2. Lo desempata, como **criterio del análisis que este jurado adopta**, que
  el riesgo que separa a S2 está entero en iOS, que no se compila (P9), mientras que la continuidad con el caso base
  se ejerce en cada etapa de la guía.

**Qué se descartó y por qué.**

- **S1 `sqlite-net-pcl`:** pierde la continuidad con el caso base y la migración ya medida; queda como caída.
- **«Conservar EF porque el caso base lo usa»** como restricción: el comportamiento no es restricción (§3.3).
- **Migrar al abrir como regla:** es C-2 de XC-1, y sólo para el evento en que cambie el sobre.
- **Recrear el almacén:** pierde lo encolado (3 → 0).
- **Orden global:** bloquea la cola o envía dependientes huérfanos.
- **C1 «último gana siempre»:** pierde datos en silencio.
- **C3 CRDT:** desproporcionado.

**Condición de revisión.**

- El primer build iOS en Release falla por EF Core con trimming. Se pasa a S1 o S3 detrás de `IDb`.
- Un PR cambia la constante de esquema exigido del cascarón. Ese PR trae la decisión entre C-1 y C-2 de XC-1.

### P6 — Procedimiento de PR e integración

**Decisión: procedimiento B de `DEV`, en seis piezas.**

1. **T1 primero.** Protección de `main` con:
   - PR obligatorio;
   - **un único** check requerido, `fw-ok`;
   - modo estricto;
   - «Do not allow bypassing the above settings», que alcanza a los administradores.

   La prueba de implantación es el parche M-13 (rojo medido: 2 pruebas fallan) en un PR, con la captura del botón de
   fusionar deshabilitado.
2. **Un solo workflow de PR**, sin `paths` en el `on:`. El alcance a `Demo/**` lo decide un paso del job.
3. **Agregador `fw-ok` estricto.** `skipped` cuenta como rojo, salvo los jobs de una lista declarada de omisiones
   legítimas, cada uno con su motivo (por ejemplo, `draft`).
4. **Runner** `runs-on: [self-hosted, i7infra-dev]`, con varias guardas:
   - guarda de mismo repositorio, así que los PR de forks nunca corren en el runner propio y el agregador los marca en
     rojo hasta que un mantenedor los traiga a una rama propia;
   - aprobación de forks para todos los colaboradores externos;
   - `permissions: contents: read`;
   - ningún secreto en los jobs de PR.
5. **Merge humano** según Conformacion-Pull-Request-Manual 2.0: lo hace alguien que no escribió el cambio.
6. **Plantilla de PR** con la unidad declarada, «qué sigue después del merge» y el campo de «función nueva de peso»
   (P1).

**Dónde se implanta.**

- Diseño: `main` de `hdcm-dev/Lab-Documentos` (I1).
- Implantarlo **requiere el permiso de quien pidió** (§6, ítem 1).
- Mientras ese permiso no llegue rige I2: T1 queda «diseñado, no implantado», la guía lo dice, y `fw-ok` corre como
  **aviso declarado**, no como check requerido (VPI §3.3, punto 1).

**Fundamento.**

- E1 de `DEV` (M-1 a M-13) y de `VER` H-04.
- GitHub Flow y *About protected branches*, citados por `DEV`.
- *Secure use reference*, abierta por `REF`.
- R-05 y R-06.

**Qué se descartó y por qué.**

- **A, sin protección:** es el problema del pedido (EV001:17).
- **C, rulesets:** no ensayado y más piezas.
- **D, merge queue:** desproporcionado para un equipo chico.
- **E, repositorio privado:** en el plan Free pierde la protección.
- **I3, repositorio nuevo:** publicación irreversible.

**Condición de revisión.**

- La API de corridas muestra PR de `Guides/` bloqueados por `fw-ok` sin tocar `Demo/**`: falla el filtro por paso.
- Más de N PR por día con choques de base: se evalúa la merge queue.

### P7 — Líneas de versión

**Decisión.**

| Línea | Gramática | Fuente única | Relación y regla de orden |
| --- | --- | --- | --- |
| Cascarón | `ApplicationDisplayVersion` = `MAYOR.MENOR.PARCHE` numérico, sin sufijo. `ApplicationVersion` = entero monótono (`versionCode` / `CFBundleVersion`) | Un archivo de propiedades importado | Implementa un mayor del puente |
| Puente | SemVer 2.0.0. El **mayor** es la identidad del contrato, transporte incluido | Una constante del cascarón | Lo consume el contenido con un rango con techo (P3) |
| Contenido | SemVer 2.0.0 con `+<commit>`; clase «paquete» (T-4) | El proyecto del contenido | El anti-rollback compara la **precedencia SemVer sin metadatos de build**. La identidad no se reutiliza jamás (Release inv. 2), así que no puede haber dos builds con el mismo número |
| Definición de encuesta | `encuestaId` + `version` entero monótono | El archivo de la definición | Cambia en cada publicación de la definición (ODK, `CRC` [F19]) |
| Catálogo de capacidades | Se versiona junto con el puente | Una constante del cascarón | P12 |
| Esquema del cascarón | Entero monótono (VPI §2.7) | El cascarón | Lo exige el binario (P5) |
| Paquetes NuGet, si los hay | Un mismo número para todos | Un archivo de propiedades | Independientes del cascarón de la demo |
| **Fase** | `diseño`, en `versionado/rutas.json` | — | Fija qué reglas rigen |

El canal (`dev`/`beta`/`prod`) **no** es una línea de versión: es un puntero que promueve el mismo artefacto (Release
inv. 1). La versión del cascarón, la del puente, la del contenido y la de la definición se ven en una pantalla de
diagnóstico del cascarón.

**Fundamento.** `DEV` P7 y H-10; `REQ` H-07 (SemVer 2.0.0 §10); VPI §2.6–§2.8; R-04.

**Qué se descartó y por qué.**

- **Un número único:** no permite atribuir un error a una combinación, y cambiarlo después alcanza a los
  dispositivos.
- **Piso `minShellVersion`:** contra VPI §2.6.
- **Fecha como versión de contenido** (N1): no es SemVer y no tiene regla de orden declarada.

**Condición de revisión.** Se declara la fase `candidata` (sufijo de pre-release, VPI §2.8). Entonces rigen los
tramos siguientes.

### P8 — Qué se prueba en cada capa y qué es compuerta

**Decisión: compuerta mínima obligatoria del PR**, todo en `[self-hosted, i7infra-dev]`, detrás de `fw-ok` estricto.

| Capa | Herramienta | ¿Compuerta? | Rojo provocado que se entrega |
| --- | --- | --- | --- |
| Build de la solución sin el proyecto MAUI, avisos como error | `dotnet build -warnaserror` | Sí | Un aviso promovido a error |
| Unitarias de dominio y ViewModels (`net10.0`) | Suite del caso base | Sí | El parche M-13, nunca el M-12 |
| Unitarias del actualizador | Los diez casos de N4 §3.6; C02–C08 de E-SEG-1 (otra clave, manifiesto o paquete alterado, versión menor, misma versión, vencido); corte provocado entre cada paso de la activación (`VER` H-05); el predicado de P3; las reglas de P13 | Sí | Cada caso visto en rojo contra el código de E01 antes de darse por cumplido |
| Catálogo frente a AndroidManifest | Prueba de lectura del manifiesto (P12) | Sí | Una capacidad del catálogo sin su permiso |
| APK del cascarón y empaquetado del contenido | `dotnet publish` + empaquetador | Sí | Un error de compilación |
| Componentes Razor (bUnit), contrato del puente y contenido WASM con Playwright y puente simulado | — | **Tramo siguiente** | — |
| Dispositivo Android | Manual al etiquetar, en un teléfono con WebView ≥ 94; logcat y captura versionados; resultado «k de n» | No | — |
| Emulador | Sólo con imagen de WebView ≥ 94 en un host con KVM fuera del runner | No | — |
| iOS | — | No: «iOS: sin compuerta», declarado | — |

- El tramo siguiente entra con su condición: se publica el primer paquete de contenido fuera de la demo, o se declara
  la fase `candidata`, lo que ocurra primero.
- Las pruebas intermitentes van a cuarentena con expediente, no a reintentos (Luo et al., FSE 2014, citado por `DEV`).
- Cada suite obligatoria entra con su rojo provocado medido (VPI §3.4, T2).

**Fundamento.** R-13; `DEV` P8, H-05, H-06 y H-08; `VER` H-03, H-05, H-07 y H-08; Vocke, «The Practical Test
Pyramid», 2018 (verificada en N4); análisis P8 (28 frente a 18 puntos).

**Qué se descartó y por qué.**

- **Siete capas obligatorias desde el primer PR:** bUnit, contrato y Playwright sin tiempo medido en el runner; es la
  «ceremonia que nadie completa» (§7).
- **O3, emulador en el PR:** imposible en el runner pedido (sin KVM).
- **O4, dispositivo en el PR:** un solo teléfono compartido, inviable como check requerido.
- **Cobertura mínima como compuerta:** no ve si la suite mira lo que dice mirar.

**Condición de revisión.** La de entrada del tramo siguiente, arriba.

### P9 — iOS (D-06)

**Decisión: no se compila iOS, y se declara.**

- Todo iOS sale en la guía y en el procedimiento de PR como **«diseño sin ensayo, NO VERIFICADO», sin compuerta**.
- Lo documentado se enseña como «documentado, sin ejecutar»:
  - el origen `app://0.0.0.1/`, interceptable por esquema propio (`ARQ` H-12; [D1] y [D8]);
  - ECDSA P-256 soportado ([S7]);
  - el piso iOS 16.4.
- Se nombran sus riesgos:
  - `.wasm` frente a 2.5.2 y DPLA §3.3.1 B;
  - el puente frente a 4.7.2;
  - la semilla frente a 4.2.3(ii), mitigado con la semilla completa;
  - EF Core con trimming.
- Un job `macos-*` es un **agregado** al mandato del runner: sale al lote (§6, ítem 3) y no lo impone la mesa.

**Fundamento.** Consenso de `DEV`, `SEG`, `VER` y `ARQ`. Microsoft, *Build an iOS app on macOS with .NET CLI*: compilar
iOS exige una Mac. El runner pedido es Linux y no hay Mac (F003:88).

**Qué se descartó y por qué.**

- **Mac propia:** compra irreversible y sin hardware.
- **Afirmar iOS como decidido:** viola «toda afirmación … evidencia verificable» (EV001:64).

**Condición de revisión.** Cualquiera de estos hechos:

- se asienta en el expediente una cuenta de Apple Developer, con su custodia;
- hay un `run_id` de un job `macos-*` verde que produce el `.ipa`;
- hay una corrida en un iPhone con captura equivalente a la corrida 3 de E01.

### P10 — Estructura de la guía

**Decisión: O3-m-r.**

**Perfil de entrada del lector** (`ACA` H-01, `LSC` H-03): sabe C#/.NET básico y git. No conoce MAUI, Blazor
WebAssembly, firma ni integración continua. Se declara en `Developer-Guide.md`.

**Criterio de aceptación de la guía:** un clon limpio, siguiendo **sólo la guía**, llega al inicio rápido.

**Estructura**

| Pieza | Qué lleva |
| --- | --- |
| `Developer-Guide.md` | El **único índice** (rol `GUIA-INDICE`): resumen, prerrequisitos medidos (dispositivo con WebView ≥ 94 y su comando de comprobación), «Cómo usar esta guía» con tres entradas (aprender, hacerlo ahora, evaluar), la ruta de lectura en Mermaid y las plataformas verificadas. `README.md` sólo remite a él. Las comprobaciones de R3 apuntan al rol, no al nombre de archivo |
| `00-Marco-de-Referencia/` | Cinco escenarios: primer arranque; actualización, con el fallo y el rollback; contenido incompatible o capacidad faltante; sin red, que es la encuesta de F005 con P13; PR y release. También contextos y actores |
| `01-Mapa-Conceptual/` | — |
| `05-Inicio-Rapido/` | La demo terminada muestra v1 → v2 al reabrir |
| `10-Tutorial/` | Variante declarada: un concepto nuevo por etapa, cada paso con un resultado visible |
| `20-` a `60-` | Temas. **Cada tema responde a una pregunta P1–P13 de este dictamen, o sale.** La aplicación por escenario va en **una tabla por tema**; «no aplica» va en una celda, con su motivo |
| `70-Como-Hacer/` | Variante declarada |
| `99-Anexos/` | Glosario con «Blazor Hybrid» frente a «Blazor WebAssembly en `HybridWebView`», cascarón, contenido, manifiesto, canal, compuerta y runner, cada uno con su «qué NO es». Referencias, sólo las leídas. Mapa guía↔demo. Pendientes, con los NO VERIFICADO |

**Contenido obligatorio de la guía**

- Toda salida es «salida registrada», con SDK, workload y pack en el encabezado.
- Las tensiones se nombran por documento (por ejemplo, R4-T-3).
- La etiqueta `i7infra-dev` se explica como dato del entorno: qué es y qué reemplazar.
- La tabla diferencial caso base → demo (runner, filtro y agregador).
- El costo medido de A (P1).

**Borrador `Framework-APP.md`:** no se edita, porque es del PO. Se exceptúa por nombre en el verificador, y la guía lo
cita como antecedente superado por este dictamen.

**Fundamento.** `ACA` P10 y H-06 a H-12; `LSC` P10 y H-08 a H-10; R-14; Diátaxis, *Tutorials* (abierta por `ACA` y
`LSC`); análisis P10 (28 frente a 25; lo decide el costo de aplicar).

**Qué se descartó y por qué.**

- **O1, un solo archivo:** incumple el marco en documentos propios del perfil.
- **O2, sin tutorial:** el principiante entra por definiciones.
- **O3 completa:** 133 subsecciones de relleno, contra R3.

**Condición de revisión.** El verificador V-03 exige un tema que no responde a ninguna pregunta decidida. Se agrega con
su motivo.

### P11 — Alcance mínimo de la demo, cómo se corre y dónde vive su workflow

**Alcance mínimo (M2, sobre la opción A).**

- **Base:** el caso base portado a páginas Razor servidas como contenido. «Tomar base» quiere decir conservar el
  dominio, las reglas (`EncuestaRules`, `LocalidadRules`) y las pruebas de ViewModels, copiadas y no referidas, con un
  mapa archivo por archivo en el Mapa guía↔demo.
- **Encuesta de tres pasos como definición versionada:**
  - v1 → v2 tomada al reabrir;
  - semilla completa;
  - un paquete con firma inválida rechazado;
  - un contenido que no avisa «arranqué» y vuelve a `previous`.
- **Un PR en rojo** con el parche M-13 en `i7infra-dev`, y su equivalente local en rojo en la máquina del lector.
- **Una encuesta tomada sin red**, enviada por el outbox con idempotencia a un **receptor didáctico** dentro de
  `Demo/`, declarado como doble de prueba: deduplica por clave y compara versión con `If-Match`. Una encuesta tomada con
  la definición v1 y sincronizada después de llegar v2 (P13).
- **Fuera del mínimo:** login, desbloqueo y cámara (P4).

**Cómo se corre (C3).**

- Una receta de contenedor versionada dentro de `Demo/`, copiada con su cierre de dependencias. No depende de imágenes
  locales ni de `dev.sh`.
- `global.json` con el SDK y `workloadVersion` fijados, y `MauiVersion` fijada en un archivo de propiedades.
- Un guion único que compila, sirve el contenido e instala.
- Dispositivo de referencia: Android con WebView ≥ 94, comprobado por comando. El emulador API 30 del laboratorio no
  sirve.
- **Un solo camino de red** entre el teléfono y el servidor del contenido, que no dependa de la topología del lector y
  que se **mida antes de escribirlo**. El túnel público queda excluido. Candidato: el reenvío inverso de puertos del
  canal de depuración. **NO VERIFICADO**: lo mide quien aplica antes de redactar la etapa.

**Dónde vive el workflow (W2).**

- `.github/workflows/` en la raíz de `hdcm-dev/Lab-Documentos`, con el alcance a `Concepts/Framework-Concept/Demo/**`
  decidido por un paso del job. La guía **cita** el YAML; no lo copia.
- Lectura del literal: EV001:37 limita la **documentación**, y un workflow no es documentación.
- El check requerido y el riesgo del runner en un repositorio público van al lote (§6, ítem 1). Mientras tanto corre
  como aviso, con la guarda de mismo repositorio.

**Criterio de aceptación de P11.** Una corrida real del workflow, con su `run_id` y sus jobs en `i7infra-runner-dev`
(API `actions/runs/{id}/jobs`), más la demo corrida desde un clon limpio siguiendo sólo la guía.

**Fundamento.** `ASD` P11 y H-10; R-11; `ACA` P11, H-02 a H-05 y H-08; `LSC` H-04, H-05 y H-11; `DEV` H-01 y P11;
`VER` H-09; `REQ` H-04 y H-10; F005; análisis P11.

**Qué se descartó y por qué.**

- **W1, YAML en `Demo/workflows/`:** GitHub no lo ejecuta, y no cumple «Configura el wofklow».
- **W3, repositorio propio:** publicación irreversible y enlaces rotos (va al lote como alternativa).
- **Los cuatro hechos de `ACA`:** no ejercitan F005 ni P13.
- **M2 con login:** P4.
- **C1, instalación manual:** no llegó a un APK en tres corridas (E1, `ACA`).
- **C2, imagen del laboratorio:** no está en ningún registro.

**Condición de revisión.**

- La demo pasa a un repositorio propio: el YAML se muda con ella.
- La medición del camino de red falla: se mide otro antes de escribir la etapa.

### P12 — Capacidades del dispositivo y el manifiesto (folio 004)

**Decisión: la versión reducida de R-10.**

- **Qué declara el cascarón de antemano.** Su **catálogo**: una lista constante en el código del cascarón, con una
  entrada por capacidad. Cada entrada lleva:
  - un id estable (por ejemplo `device.info`, `network.status`, `camera.capture`);
  - la versión de su contrato en el puente;
  - lo que declara en cada plataforma: permiso, clave de uso, feature o `<queries>`.

  El cascarón declara en AndroidManifest e Info.plist **sólo** lo que su catálogo implementa.
- **Cómo lo descubre el contenido.** Por el `bridge.handshake`, que devuelve la versión del puente y el catálogo.
- **Cómo lo pide el contenido.** El estado del permiso se consulta **en el uso**, nunca en el `handshake`:
  verificar, pedir en contexto, rationale y salida a ajustes.
- **Qué declara el contenido.** En el manifiesto del paquete, `capabilities: { requires, optional }`.
- **Qué hace cuando le falta una:**
  - si falta una de `requires`, el actualizador **no activa** el paquete y queda el instalado (predicado de P3);
  - si falta una de `optional`, el contenido oculta la función o explica por qué no está, y no pide nada;
  - con el permiso denegado, rationale y salida a ajustes.
- **Una capacidad nueva entra siempre en dos tiempos:** (1) release del cascarón por tienda, con la declaración y la
  entrada del catálogo; (2) contenido que la usa. Hasta que la base instalada se actualice, va como `optional`.
- **Compuerta:** una prueba de CI que cada entrada del catálogo tenga su declaración en AndroidManifest (P8). iOS:
  «sin compuerta», declarado.
- **Catálogo de la demo:** sólo lo que su contenido usa, sin permisos de tiempo de ejecución, porque la demo no tiene
  cámara. El rechazo por `requires` faltante se demuestra en la suite del actualizador.

**Fundamento.**

- Android, *Declare app permissions* y *Request runtime permissions*; Apple, `NSCameraUsageDescription` y *Requesting
  authorization to capture and save media* («the system terminates your app»). Todas citadas por `CRC` [F10], [F11],
  [F13] y [F15].
- `CRC` H-08: el permiso pedido y no declarado en la app de referencia.
- R-10; análisis P12 (28 frente a 19).

**Qué se descartó y por qué.**

- **La versión completa de `CRC`:** la prueba sobre Info.plist no tiene dónde correr en el runner Linux, y el
  `minShellVersion` calculado es un piso (R-09).
- **Sin catálogo:** la falla aparece en el campo, y en iOS como cierre de la app.

**Condición de revisión.** La misma que P9: con un job `macos-*` medido se suma la prueba sobre Info.plist.

### P13 — Encuestas tomadas con una versión cuando llega otra (folio 005)

**Decisión.**

1. La definición lleva `encuestaId` y `version` propios, que cambian en cada publicación.
2. Cada respuesta guarda `{encuestaId, versionDefinicion}` **desde que se empieza a cargar**. La encuesta en curso se
   termina con su versión; la nueva aplica a la próxima.
3. El cliente conserva una copia de toda definición que tenga respuestas en curso o pendientes, guardada en la base
   local junto a ellas e independiente de la retención de paquetes (P2).
4. El servidor (en la demo, el receptor didáctico) acepta las versiones publicadas y no retiradas. Retirar una versión
   es un acto explícito y anunciado.
5. Una respuesta de una versión retirada no se borra: queda en «carta muerta», visible al usuario.
6. La sincronización es idempotente y no depende de la versión de la app.
7. **Ninguna actualización, tampoco una obligatoria, descarta, migra en silencio ni invalida pendientes.** El forzado
   no espera a vaciar el outbox.

**Fundamento.**

- ODK: «the `version` must change in order for data collection clients to understand that they should update» y la
  edición con «the version of the form that was active when the form was originally filled» (`CRC` [F19] y [F21]).
- El service worker que espera a sus clientes (`CRC` [F6]).
- `CRC` H-10 (E3); `ASD` H-06; convergencia registrada por `REF` y por el análisis §4.

**Qué se descartó y por qué.**

- **Validar contra la versión vigente:** rechaza o corrompe pendientes (E3).
- **Forzar antes de sincronizar:** bloquea al encuestador sin red, contra F005.

**Condición de revisión.** Si la demo pasa a un servidor real, se verifica que acepte versiones anteriores, que hoy
está NO VERIFICADO para ODK Central (`CRC` §9).

---

## 6. Lo que queda abierto para quien pidió

Sólo lo que el árbol no contesta. Va en lote, cada pregunta con su default. Nada se asienta por silencio.

1. **Implantar la compuerta en `hdcm-dev/Lab-Documentos`.** ¿Autorizás tres cosas?
   - proteger `main` con PR obligatorio, `fw-ok` como único check requerido y sin excepción para administradores;
   - correr el workflow de la demo en el runner propio `[self-hosted, i7infra-dev]` sobre los PR de ese repositorio
     público, con la guarda de mismo repositorio y la aprobación de forks para todos los colaboradores externos;
   - o preferís un repositorio propio para la demo (W3, publicación irreversible).

   **SI NO RESPONDÉS:** el workflow se escribe en `.github/workflows/` de la raíz con la guarda de mismo repositorio, y
   `fw-ok` corre como **aviso declarado**, no como check requerido. T1 queda «diseñado, no implantado» y la guía lo
   dice. `main` no se toca, y no se crea ningún repositorio.

2. **XC-1, migración de la base local** (VPI §2.7, cláusula 2). ¿Elegís C-1, C-2 u otro camino?
   - **C-1, recomendado:** sobre fijo, se cumple la convención. Reversible.
   - **C-2:** sobre fijo, y migrar al abrir con copia previa del archivo sólo en el release del cascarón que cambie el
     sobre. Reversible hasta que haya terceros instalados.

   **SI NO RESPONDÉS:** se sigue C-1, provisorio y sin aprobar. La migración al abrir no se implementa y nada
   irreversible se apoya en ella. El ADR queda `Propuesto`.

3. **iOS.** ¿Hay cuenta de Apple Developer para el laboratorio, y quién custodia certificados y perfiles? ¿Sumás un job
   `macos-*` (runner de GitHub) como agregado al mandato `runs-on: [self-hosted, i7infra-dev]`, sin ser check
   requerido?

   **SI NO RESPONDÉS:** iOS queda «diseño sin ensayo, NO VERIFICADO», sin compilar ni compuerta, y no se agrega ningún
   job `macos-*`.

4. **Condición de `Versionado-Producto-Integral`** (R-04). ¿El producto necesita atribuir un error de producción a
   versiones exactas de cascarón, puente y contenido?

   **SI NO RESPONDÉS:** VPI rige como decisión cerrada del contrato, con `fase: diseño` declarada. Las decisiones de
   este dictamen valen igual si respondés que no; en ese caso XC-1 decae y se sigue C-1 de todos modos.

---

## 7. Señales para la presidencia

Ninguna de estas va a quien pidió.

| Señal | Qué pide |
| --- | --- |
| **Homogeneidad** (`Mesa` §3.5.4) | Votos unánimes en más del 80 % de los ítems, con un solo agente aplicando las cinco funciones. El refutador revisa los tres `NO PROCEDE`: R-01, R-02 y `ARQ` H-10 |
| **Inversión de lo comunicado** | P1 se aparta de lo que recomendaron el refutador y el análisis (C-min), porque R-01 no procede. Si la presidencia ya comunicó C-min, rige §2.1, paso 7: se rehace el enunciado antes de proponer salidas |
| **Enunciado** (R-03, `CRC` H-01) | Sumar al objetivo la cláusula «toma de encuestas sin red y sincronización al recuperarla [F005]», con su origen, y declarar las lecturas que este dictamen fija en «Premisas» |
| **Formal en el ciclo 2** (`JUR` §3) | El dictamen fija umbrales (TTFD ≤ 5 000 ms, N = 0, retención N ≥ 3 en el servidor, rangos con techo). La condición de `JUR` para Formal se cumple si hay otra ronda. Con una sola ronda, la mesa cierra **por decisión** (`Mesa` §3.5.7) |
| **Medidas pendientes** (obstáculos de una línea) | Que un administrador de `hdcm-dev` lea el grupo del runner (`DEV` M-7: 403). Una corrida en el runner real del `dotnet publish` de Blazor WASM sin `wasm-tools` (el ítem C de `DEV`). Medir el camino de red de la demo (P11). Arrancar E01 con la red cortada (`CRC` 6.4) |
| **Barrido antes de versionar** | Este folio no nombra el repositorio privado ni direcciones o series de dispositivos. Otros folios de `despacho/` sí los traen (`REF` §5): se redactan en la copia publicada |

Sigue: resolución con el plan y el lote al PO · presidencia · Cierra con: folio resolucion
