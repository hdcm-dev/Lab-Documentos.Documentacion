| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Análisis de decisiones |
| Corrige | — |

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Rol | Análisis de decisiones (Mesa-De-Expertos-A-Pedido §2.1, paso 6 bis). **No vota ni emite hallazgos** (§8) |
| Fecha | 2026-10-25 |
| Carta | `evidencia/015-carta-analisis-de-decisiones.md` |
| Norma | `<base de conocimiento>/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` 3.1 |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Cabecera y §0 (líneas 1–111). Por la fila «Hacés el análisis de decisiones (paso 6 bis)» del Mapa de carga: §2.2 (con su subsección), §3.3, §4 y §8. **Por respaldo**: §2.1 entera, porque la carta remite a «§2.1 paso 6 bis» |
| Documentos cargados con versión | `Excepcion-A-Un-Conocimiento` 2.0, entero · `Cadena-De-Consecuencias` 2.0, entero · `Escalas-De-Juicio` 1.0, §3.3 y §3.4 (por respaldo: Excepcion §5.3 remite a la clase `C`) · `Versionado-Producto-Integral` 2.0, cabecera, §2.7 y §2.8 (por respaldo: la ficha XC-1 los cita) · `Release-Y-Despliegue-Versionado` 2.0, invariantes 4 y 10 (por respaldo: el refutador los cita en su §6 y en R-12) |
| No cargados | `Mesa` (no voto ni compongo el panel) |
| Insumos leídos | Pedido (evidencia 001 desde la línea 4); folios 001 a 005; folio 006 como contexto (no figura entre mis insumos, pero lo usan `CRC` §4 y `REF` P2); los doce archivos de `despacho/`, incluidos `refutador.md`, `caso-de-referencia-y-capacidades.md` y la ficha `analista-sistemas-y-decisiones-ficha-1.md`. De los dossiers, relevamientos, borrador y E01 tomo los datos **por los informes que los citan**; abrí para comprobar E01 `INFORME.md` l. 157–172, 220, 243–248, R1 l. 54–95 y `Framework-APP.md` l. 95. **No leí la evidencia 012** |
| Ensayo propio | **E-AD-1** (§1.2): el «sobre fijo» que el refutador pidió medir para XC-1 |

# Análisis de decisiones — expediente 0001

## Índice

0. [Qué hace este folio y cómo se lee](#0-qué-hace-este-folio-y-cómo-se-lee)
1. [Parte (a): camino de compromiso de XC-1](#1-parte-a-camino-de-compromiso-de-xc-1)
2. [Parte (b): criterios de decisión, fijados antes de puntuar](#2-parte-b-criterios-de-decisión-fijados-antes-de-puntuar)
3. [Parte (b): análisis por pregunta con alternativas en pie](#3-parte-b-análisis-por-pregunta-con-alternativas-en-pie)
4. [Preguntas sin alternativas en pie](#4-preguntas-sin-alternativas-en-pie)
5. [Dependencias entre decisiones](#5-dependencias-entre-decisiones)
6. [Obstáculos y medidas que faltan](#6-obstáculos-y-medidas-que-faltan)
7. [Resumen para el jurado](#7-resumen-para-el-jurado)

## 0. Qué hace este folio y cómo se lee

**Abreviaturas.** Las del refutador: `EV001` (pedido), `F003`…`F006` (folios de `actuaciones/`), `FAPP`
(`Framework-APP.md`), y los informes por su slug: `REQ`, `VER`, `LSC`, `ARQ`, `ASD`, `DEV`, `SEG`, `ACA`, `CRC`;
`REF` es el refutador y `JUR` la composición del jurado. `XC-1` es la ficha del analista; el número lo asigna la
presidencia. `VPI` es `Versionado-Producto-Integral` 2.0.

**Marcas.** `[CP]` señala un criterio propio de este análisis: no tiene fuente externa y el jurado lo puede
descartar sin contradecir evidencia. «sin medir» va donde nadie midió y no hay cifra (Cadena-De-Consecuencias §3);
no pongo una cifra supuesta en su lugar. Las clases de ancla son las de `Escalas-De-Juicio` §3.3: una celda que
sólo se apoya en `C` lo dice y no desempata (Excepcion §5.3).

**Qué no hace.** No vota, no emite hallazgos y no cambia el objetivo. Las tres cuestiones que `REF` dejó a la
presidencia (R-01: qué se actualiza; R-03: la cláusula sin red; R-04: si VPI rige) **no las resuelvo**. Cada
recomendación dice de cuál depende (§5).

**Cuántas preguntas.** La parte (b) de la carta nombra P1–P11, y la misma carta dice que las preguntas son P1–P13.
Analizo las que el «Mapa de disenso» de `REF` §7 muestra con más de una posición en pie: P1, P2, P3, P4, P5, P6,
P8, P10, P11 y P12. Sumo P12 porque tiene dos versiones en pie (la de `CRC` y la reducida de R-10). Es la lectura
que menos deja afuera, y la declaro. P7, P9 y P13 quedan en §4, sin matriz.

## 1. Parte (a): camino de compromiso de XC-1

### 1.1 Estado de la ficha

`REF` §6 admitió una sola ficha, **XC-1**: migrar la base local al abrir, frente a VPI 2.0 §2.7, cláusula 2.
La admitió **condicionada a R-04**: si la presidencia pasa VPI a condicional, la ficha decae porque no queda
convención a la que exceptuar. **Este análisis vale sólo si VPI rige.** No hay fichas no admitidas.

`REF` pidió además dos cosas al análisis:

- que se enumere la alternativa más cercana a cumplir, que la ficha no trae: **un esquema sobre fijo en el
  cascarón**;
- que se mida su costo: «Lo mediría repetir E-ASD-1 con el campo dentro del JSON; se le pide al análisis de
  decisiones».

La medí: es E-AD-1.

### 1.2 Ensayo E-AD-1: el sobre fijo, una variable respecto de E-ASD-1

- **Qué cambia:** dónde vive la versión del payload. En E-ASD-1 va en una columna nueva (`ALTER TABLE`, el esquema
  pasa de 001 a 002). En E-AD-1 va **dentro del JSON** de un sobre de columnas estables: id, acción, versión de
  forma, clave de idempotencia única, JSON y estado.
- **Qué queda fijo:** EF Core SQLite 10.0.11 (la versión del caso base, por `ASD`), SDK 10.0.400, el contenedor
  efímero `mcr.microsoft.com/dotnet/sdk:10.0`, tres acciones encoladas por el binario v1 y la cláusula 2 al pie de
  la letra (el binario exige su número, no arranca si no coincide y no migra).
- **Qué agrega:** un tercer caso, v3, en el que el **sobre** necesita una columna nueva (por ejemplo `Dueno`, que
  pide `ASD` H-05). Así se ve qué posterga el sobre fijo.

Comando: `bash correr.sh` (`docker run --rm --name fc-ad-e1 …`). Salida literal:

```text
10.0.400
== caso sobre fijo
v1: esquema=20261025100001_SobreFijo pendientes=3
v2-sobre-fijo: ARRANCA — exigida=20261025100001_SobreFijo leída=20261025100001_SobreFijo
v2-sobre-fijo: pendientes=4 claves_viejas_conservadas=True versionPayload_leido=1,1,1,2
codigo_salida=0
== caso el sobre cambia
v3-sobre-cambia: NO ARRANCA — exigida=20261025100002_Dueno leída=20261025100001_SobreFijo
codigo_salida=3
Microsoft.EntityFrameworkCore.Sqlite/10.0.11
```

**Lectura.** El cambio que en E-ASD-1 obligaba a migrar (la versión del payload) entra sin tocar el esquema. v2
arranca cumpliendo la cláusula 2 al pie de la letra, conserva las tres pendientes y lee las filas viejas como
versión 1 con un lector tolerante. Cuando el sobre mismo cambia (v3), vuelve la contradicción de la ficha: código 3,
igual que el caso «cumplir» de E-ASD-1. **El sobre fijo no elimina la contradicción: la mueve del cambio de
contenido al cambio del sobre**, que sólo llega con un release del cascarón por tienda.

- **Costo medido:** 76 líneas de programa contra las 83 de E-ASD-1 (`wc -l`). La compilación tardó 10,8 s.
- **Eje que no quedó fijo:** el dispositivo. Corrió en Linux x64, no en el g42.

Huellas (evidencia cruda local en `{tmp-de-sesiones}/<proyecto>/6e043f4a-ac59-44a7-a89a-8b2093f94f90/scratchpad/e-ad/`, no versionable):

| Pieza | sha256 |
| --- | --- |
| `src/Program.cs` | `3eb0526cdc254846abd08d4e9d6ba6a249c19a6cb6b83f1a6cca0fa001038f4f` |
| `correr.sh` | `eedc120709b5d1743d974dde3672f9bfa2b6ae839c18672b33bc0216a3162f90` |
| `salida.txt` | `b26401b97af17fe72dcf3e04429f2ce7704755f97ef29270796e6afe78c9f337` |

**Dos lecturas de fuente que tocan la ficha** (abiertas el 2026-10-25 con `curl`):

1. Microsoft Learn, *Applying Migrations* (EF Core, `ms.date` 2026-08-05), sha256 de la descarga `b700d12d…ec70`.
   Dice dos cosas que importan acá:
   - «Wrapping MigrateAsync in an explicit transaction is not supported».
   - «the SQLite provider uses a lock table that can become abandoned if the process terminates unexpectedly».

   La ficha compensa las premisas del rechazo con «migración en una sola transacción». Con EF Core esa transacción
   explícita no existe: lo que compensa de verdad es la **copia previa del archivo**. Lo señalo para el jurado; no es
   un hallazgo.
2. Android Developers, *Access app-specific files*, sha256 `e9bb79d8…c2c8`: «Other apps cannot access files stored
   within internal storage». Coincide con la cita de la ficha.

### 1.3 Análisis del camino de compromiso (Excepcion-A-Un-Conocimiento §5.3)

```text
ANÁLISIS DEL CAMINO DE COMPROMISO — XC-1 (ficha despacho/analista-sistemas-y-decisiones-ficha-1.md; folio que asigne la presidencia)
  Condición:               vale sólo si VPI rige (REF R-04). Si VPI pasa a condicional, la ficha decae y este análisis no se usa.
  Sigue rigiendo:          VPI §2.7, cláusulas 1, 3 y 4, enteras: la base declara un número, el número se expone con
                           exigido y leído, y una compuerta ata base, binario e instalación limpia. Cláusula 2 entera bajo
                           C-1. VPI §2.8: la fase se declara (VER H-02); §2.7 rige «desde la fase `diseño`», así que
                           declarar `diseño` no la quita.
  Fuera del documento:     quién y cuándo migra una base embebida cuyo único proceso con acceso es el binario. Las tres
                           premisas del rechazo de la cláusula 2 son de servidor (ficha, «Por qué no se cumple»). Ahí la
                           referencia es el estándar citado: Microsoft Learn, EF Core «Applying Migrations» (la migración en
                           tiempo de ejecución «can be acceptable for applications that prefer simple deployment and can
                           tolerate startup migration behavior»; sin transacción explícita; bloqueo de SQLite que puede
                           quedar abandonado) y Android Developers, «Access app-specific files».
  Alternativas:            Alt-1 (la más cercana a cumplir) sobre fijo en el cascarón, cumplir la cláusula 2 al pie de la
                             letra: el contenido no hace DDL y el número de esquema cambia sólo cuando cambia el sobre.
                           Alt-2 (la de la ficha) migrar al abrir, en el cascarón, antes del WebView, con copia previa del
                             archivo y compuerta exigido/leído después de migrar.
                           Alt-3 Alt-1 como regla, y Alt-2 sólo en el release del cascarón que cambie el sobre.
    Descartadas antes de ponderar:
                           Cumplir al pie de la letra sin sobre fijo: «v2-cumplir: NO ARRANCA … codigo_salida=3» (E1,
                             E-ASD-1). Choca con el objetivo, «bajan sus actualizaciones … al abrir» (F003:46-48).
                           Recrear el almacén (fase `diseño`): «pendientes=0» (antes 3) (E1, E-ASD-1). Pierde lo que el
                             usuario reclama, y en `operativa` «El almacén no vuelve» (E2, VPI §2.8).
  Criterios y pesos (fijados antes de puntuar):
    K-1 Cercanía a cumplir        — peso 3 — fuente: el documento que rige, VPI 2.0 §2.7
    K-2 Reversibilidad            — peso 3 — fuente: Cadena-De-Consecuencias §2, paso 4; definición de «reversible» de Excepcion §5.3
    K-3 Integridad de lo encolado — peso 3 — fuente: Android Developers, «Build an offline-first app»: «The local data
                                    source is the canonical source of truth for the app» (abierta 2026-10-25, sha256
                                    ee132cf1…3191) — por qué pesa así: lo encolado sin red es lo que el usuario reclama (F005)
    K-4 La app abre tras un release del cascarón — peso 2 — fuente: la cláusula del objetivo con la que choca la ficha
                                    (F003:46-48). No es un estándar: es la contradicción misma, y la declaro como tal — por
                                    qué pesa 2 y no 3: sólo se pone en juego cuando cambia el sobre, y eso pasa por tienda
    K-5 Simplicidad para quien aprende — peso 1 — fuente: pedido (EV001:33 y 39); ISO/IEC 25010:2023, mantenibilidad,
                                    citada sin apartado (no la leí) — por qué pesa 1: no decide la contradicción
  Ponderación:             (tabla abajo; total máximo 36)
  Caminos:
    C-1 (recomendado) Alt-1, sobre fijo y cumplir: total 31. Cumple la convención entera mientras el sobre no cambie
      (E-AD-1: ARRANCA, exigida = leída, 3 pendientes conservadas). Reversible: no deja nada aplicado en los teléfonos.
    C-2 Alt-3: total 25. Queda primera si K-4 pesa 6 o más (más del doble de K-1 a K-3), es decir, si la mesa juzga que
      una app que no abre en el release que cambia el sobre pesa más que todo lo demás. Es el camino para cuando ocurra
      ese evento. Reversible hasta que haya terceros instalados (ficha, «Reversibilidad»); desde ahí, la migración
      aplicada en cada teléfono no vuelve.
  Mientras se decide:      rama de la reversibilidad, camino reversible (Excepcion §4; REF §6). Se sigue C-1. Como C-1
                           cumple, ninguna excepción corre de hecho: la demo no implementa la migración al abrir hasta la
                           respuesta de quien pidió. Ningún paso irreversible se apoya en ella.
```

**Ponderación** (0 a 3; evidencia por celda):

| Alternativa | K-1 (×3) | K-2 (×3) | K-3 (×3) | K-4 (×2) | K-5 (×1) | Total |
| --- | --- | --- | --- | --- | --- | --- |
| Alt-1 sobre fijo, cumplir | 3. E1 E-AD-1: «ARRANCA — exigida=… leída=…» sin migrar | 3. Nada queda aplicado en el teléfono: el esquema no cambió (E-AD-1) | 3. «claves_viejas_conservadas=True», 3 + 1 pendientes (E-AD-1) | 1. En el primer cambio del sobre: «NO ARRANCA … codigo_salida=3» (E-AD-1, v3) | 2. Un concepto más, la versión de forma por fila con lector tolerante, que `ASD` H-06/H-07 ya piden por otro motivo | **31** |
| Alt-2 migrar al abrir | 1. Cumple las cláusulas 1, 3 y 4 y la parte de exigir de la 2; hace lo que la cláusula 2 rechaza (E2, VPI §2.7) | 2. Hoy reversible; deja de serlo con terceros instalados (ficha, «Reversibilidad») | 2. E-ASD-1 conserva las 3 (E1, 349 ms). Bloqueo de SQLite abandonado si el proceso muere: documentado (E2, EF Core), sin medir en Android | 3. «v2-migrar: … pendientes=3» (E1, E-ASD-1) | 2. Copia previa, `Migrate`, compuerta | **23** |
| Alt-3 sobre fijo + migrar sólo si cambia el sobre | 2. Cumple al pie de la letra salvo en el release que cambia el sobre | 2. Como Alt-2, pero sólo en ese release | 2. Como Alt-2 en ese release; como Alt-1 en el resto | 3. Abre siempre (E-AD-1 + E-ASD-1) | 1. Dos mecanismos que enseñar `[CP]` | **25** |

**Sin C-2 adicional.** La segunda es Alt-3. Alt-2 queda tercera y sólo pasaría primera con K-1 en 0, es decir,
ignorando el documento que rige; ese cambio no es razonable.

**Qué pierde C-1.** No resuelve la ficha: la posterga. El día en que el cascarón necesite otra columna en el sobre
(por ejemplo el dueño de `ASD` H-05 como columna indexada, en lugar de un campo del JSON), la contradicción vuelve
tal cual (E-AD-1, v3).

**Condición de revisión, comprobable:** que se agregue a la línea del cascarón una migración de EF con un número de
esquema exigido distinto del publicado. Es un evento que se ve en el diff del PR (la constante de la cláusula 2
cambia). Ese PR trae consigo la decisión entre C-1 (no se permite) y C-2.

**Para el cierre** (Excepcion §5.2): la pregunta es «¿Elegís C-1, C-2 u otro camino?». `SI NO RESPONDÉS`: se sigue C-1,
que cumple, y la migración al abrir no se implementa. El origen del hecho es de la corrida (la ficha nace en esta
mesa). La autocorrección no alcanza porque reabriría una decisión cerrada (Excepcion §4).

## 2. Parte (b): criterios de decisión, fijados antes de puntuar

Los escribo **antes** de la primera matriz y valen para todas. Escala de 0 a 3 por celda.

| Id | Criterio | Peso | Fuente | Qué mide | Por qué pesa así |
| --- | --- | --- | --- | --- | --- |
| K-S | Simplicidad | 2 | Pedido: «ventajas de simplicidad y practicidad, escalibilidad» (EV001:39); ISO/IEC 25010:2023, mantenibilidad, citada sin apartado | Piezas y conceptos propios que hay que sostener. 3 = ninguno nuevo; 0 = varios mecanismos propios | El pedido lo nombra como ventaja a buscar |
| K-P | Practicidad | 2 | Misma frase; MEDIOS del contrato (F003:86-88) | Se construye y se ensaya con lo disponible: contenedores Linux, runner `i7infra-dev`, g42, sin Mac. 3 = medido; 0 = imposible con los medios | Ídem |
| K-E | Escalabilidad | 2 | Misma frase | Más pantallas, encuestas, apps o usuarios sin cambiar el cascarón ni pasar por la tienda. 3 = sin límite estructural | Ídem. Los tres pesan igual porque el pedido los enumera sin jerarquía (la misma lectura que `ASD` §3) |
| K-D | Enseñabilidad a un desarrollador sin experiencia | 2 | Pedido: «guía instructiva academica enfocada a un desarrollador sin experiencia» (EV001:33); Diátaxis, *Tutorials* (citada y abierta por `ACA` y `LSC`) | Conceptos y términos nuevos para el lector, y si cada paso da un resultado observable. 3 = un concepto por paso y sin términos contradictorios | Es una de las dos solicitudes del pedido, al mismo nivel que los tres criterios nombrados |
| K-R | Riesgo | 1 | Lectura P0 del contrato: «mecanismo que una tienda prohíbe» (F003:67); OWASP MASVS (citado por `SEG`) | Probabilidad e impacto de una falla en el campo, en una tienda o en terceros. 3 = sin riesgo identificado; 0 = riesgo documentado sin mitigación | El pedido no lo nombra como criterio; es un agregado del análisis y pesa 1 `[CP]` |
| K-C | Costo de aplicar | 1 | Mesa-De-Expertos-A-Pedido §2.2, clase «diseño de una norma»: «El refutador ataca el costo de aplicarla» | Trabajo para quien aplica (la presidencia, F003:92) hasta tenerlo construido y verificado. 3 = existe o es trivial | Se superpone en parte con K-P: pesa 1 para no contarlo dos veces |
| K-V | Reversibilidad | 1 | Cadena-De-Consecuencias §2, paso 4, y §4 | Qué cuesta volver, incluido el efecto en terceros. 3 = cambiar un parámetro o borrar un archivo; 0 = alcanza a terceros que ya lo tomaron | Pesa 1 en la suma, pero **además es regla**: entre una opción reversible y una irreversible no hay empate, se toma la reversible (Cadena §4), sea cual sea la suma |

**Total máximo:** 2·(3+3+3+3) + 3 + 3 + 3 = **33**.

**Compuertas, no pesos.** Una alternativa que viola una restricción dura del contrato (F003:72-75), o una
convención que rige sin ficha (Excepcion §3), se descarta antes de puntuar y se dice con qué ancla. Una compuerta
que depende de algo que la presidencia no resolvió (R-01, R-03, R-04) se marca **condicional**: la alternativa se
puntúa igual, para que el jurado vea qué pasa en cada rama.

**Cómo uso la suma.** La suma ordena; no decide sola. En cada pregunta digo qué paso de la cadena decidió y qué
pierde la que no se elige. Una diferencia de 3 puntos o menos la trato como empate y la decide la cadena, no la
suma `[CP]`.

## 3. Parte (b): análisis por pregunta con alternativas en pie

### P1 — Modelo de contenido actualizable

**Alternativas en pie** (`REF` §7):

- **A**: pantallas Blazor WASM descargadas y servidas en `HybridWebView`; la definición de la encuesta va como código.
- **C-min**: la definición de la encuesta como datos versionados, dibujada por componentes Razor compilados en el
  cascarón dentro de `BlazorWebView`. A queda documentada como extensión. Es el «C mínima» de `REF` y el «B» de `ARQ`
  E02-B.
- **C-full**: A más la definición como datos (`CRC` §3.2, «A + definición como datos»).
- **D**: contenido remoto, como la app de referencia del PO.

**Compuerta condicional.** D no opera sin red: la referencia «cancela toda navegación» sin red (E2, `CRC` §3.1,
`ConnectionManagerService.cs:25-33`). Eso contradice F005, pero F005 todavía no está en el objetivo (R-03). Si la
presidencia suma la cláusula sin red, D cae por compuerta. La puntúo para que se vea qué pasa sin esa cláusula.

`REF` R-15 pidió volver a puntuar D-01 con E02-B y con el escenario del folio 005. Esta matriz lo hace.

| Alt. | K-S ×2 | K-P ×2 | K-E ×2 | K-D ×2 | K-R ×1 | K-C ×1 | K-V ×1 | Total |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| A | 1. Dos runtimes, interceptor y puente (`ASD` §3, celda de E01 C-1…C-6) | 3. v1→v2 sin reinstalar y adulterado rechazado, medido en el g42 (E01 §6.2; `ARQ` E02-R) | 3. Cualquier página Razor sin tienda (`ASD`, N1:424) | 1. «Blazor Hybrid» de Microsoft dice lo contrario de lo que hace A (`ARQ` H-01, `LSC` H-02, `CRC` H-03); dos runtimes | 1. +~2 s por arranque y 9,13 MB por versión (E1, `ARQ` H-08); WebView ≥ 94 (E01 l. 243); iOS ≥ 16.4, documental (`ARQ` H-03); `.wasm` frente a 2.5.2, NO VERIFICADO (`SEG`) | 2. El código de E01 existe; falta firma y activación atómica (`ARQ` H-05) | 2. «Sí, mientras el puente sea la frontera» (`ARQ` P1); reescribir páginas (`ASD` P1) | **21** |
| C-min | 2. Sin WASM, pero con un esquema de definición y un renderizador propios (`ASD` §3, fila B) | 3. E02-B dibujó «Encuesta de movilidad» desde un JSON en el g42: 1,6–1,7 s (E1, `ARQ` §7.1). El canal se midió con un zip (E01) y es el mismo (`SEG` P1). La definición descargada como tal, sin medir | 2. Encuestas nuevas o corregidas, sin tienda (F005; ODK [F19][F20] en `CRC`). «Lógica nueva = release del cascarón» (`FAPP` l. 95, abierto) | 3. Es Blazor Hybrid en el sentido de Microsoft (`REF` R-02); un runtime; precedente ODK enseñable | 2. Desaparecen iOS ≥ 16.4 y `.wasm` (`REF` P9). Los datos que dirigen la UI son entrada no confiable y van firmados (`SEG` P1, MASVS-CODE-4). 4.7.2 frente al puente, NO VERIFICADO | 2. Prototipo E02-B; esquema y renderizador sin medir | 3. «A se suma sin tocar» el canal (`REF` P1; `SEG` P1); «la definición puede volver a código» (`CRC` §3.2) | **27** |
| C-full | 0. Suma las dos (`ASD`, N1:422) | 2. Cada pieza medida por separado; juntas, sin medir | 3. La más expresiva (`ASD`) | 0. «Dos modelos mentales para un principiante» (`ARQ` P1) | 1. Todos los riesgos de A | 0. Los dos costos | 2. Como A | **13** |
| D | 3. Sin paquete ni manifiesto propio (`CRC` §3.1, fila R) | 3. Funciona en producción en la referencia (`CRC` §3.1, código leído) | 3. Todo cambio, sin tienda | 2. Un sitio web; nada que enseñar sobre trabajo sin red | 0. Sin red no opera (E2, `CRC` §3.1); riesgo 4.2 de Apple (`CRC` tabla, N1 §4.3) | 3. Existe el patrón | 3. «Alta en código» (`CRC` §3.2) | **28** |

**Lectura.** D queda primera por un punto, y eso muestra lo que señala R-03: **sin la cláusula sin red, la matriz
elige justo la opción que contradice lo que el PO dijo en F005.** Por eso no recomiendo por puntaje.

- **Qué decide:** la compuerta de F005 (condicional a R-03). Con ella, D cae.
- **Entre A y C-min:** decide el paso 4 de la cadena. Las dos son reversibles, C-min es la más barata medida y no
  depende de la lectura (b) de R-01.
- **Sensibilidad:** A pasaría delante de C-min sólo si K-E pesara más de 8, es decir, cuatro veces cada uno de los
  otros dos criterios del pedido. El pedido no lo sostiene.

**Recomendación del análisis: C-min.**

**Cadena de consecuencias de C-min** (Cadena §2):

1. **Dónde cae.** En dos lugares:
   - en el esquema de la definición y en su renderizador, que viven en el cascarón;
   - en que una pantalla o una lógica nueva va por tienda (`FAPP` l. 95).
2. **Cuánto pesa.**
   - Primer render: 1,6–1,7 s en el g42, 2,7 s en frío (E1, `ARQ` §7.1).
   - APK: 18,86 MB (ídem).
   - Peso de una definición y costo del esquema: sin medir. Los mediría un ensayo E02-B con la definición bajada por
     el canal firmado. Pedido a la presidencia (§6).
3. **Qué pierde la alternativa.**
   - Si se elige C-min, se pierde el cambio de **código** de pantallas sin tienda, que el pedido no nombra (`REF`
     R-01).
   - Si se elige A, se pierden unos 2 s por arranque, 9,13 MB por versión retenida, el piso de iOS 16.4 y el
     WebView ≥ 94, y el término «Blazor Hybrid» queda en contradicción con la documentación que el principiante va a
     encontrar.
4. **Reversible: sí.** A se suma después sin tocar el canal (`SEG` P1).

**Condición de revisión (comprobable):**

- **(i)** Quien pidió responde en el lote que también hay que actualizar código de pantallas (lectura (b) de R-01).
  Entonces se suma A como extensión, con el umbral de TTFD fijado **antes** de juzgar (`VER` H-10).
- **(ii)** Aparece la primera corrección de la encuesta del escenario de F005 que el esquema no puede expresar sin un
  release del cascarón. Se ve en un PR que toca el renderizador para cambiar una encuesta.

### P2 — Canal de actualización

En el canal (índice firmado con ECDSA P-256, monotonía, `expires`, staging) no hay disenso de fondo (`REF` P2). Para
el momento, «no bloquear, aplicar en el próximo arranque» es la única posición en pie: `ARQ` H-09, `CRC` H-06 y `REF`
coinciden, con Expo como fuente abierta por `REF`. Para el forzado del contenido, la única en pie es la de `CRC` §4a
(punto seguro, nunca sin red). Quedan dos sub-disensos.

**Activación.** No hay matriz: la alternativa de E01, la «cambio atómico `current`/`previous`» que `SEG` da por
medida, **se descarta antes de ponderar**, con E2. `Actualizador.cs:83-85` borra `previous` antes de tener la nueva
versión, y entre los dos renombres no existe `current` (citado literal por `REF` R-07, `ARQ` H-05 y `VER` H-05).
Queda en pie la de E02-R: versiones inmutables y un `puntero.json` cambiado con un solo `rename`, medida en el g42
(`ARQ` §7.2). Lleva el criterio de `VER` H-05: un corte provocado entre cada paso, visto en rojo contra E01.

**Retención:**

- **r1** (`ARQ` H-10): `current` + `previous` + semilla, que tiene que ser el mismo artefacto del release, en el
  teléfono.
- **r2** (`SEG` P2, `REF` R-12): N ≥ 3 en el servidor; en el teléfono `current` + `previous`. La semilla no es destino
  de rollback.

Las dos cumplen el invariante 10, según cómo se lea «artefacto del release». Lo abrí: «Lo que se conserva es **el
artefacto del release**, no una copia del estado vivo del destino». No dice que se conserve en el dispositivo.

| Alt. | K-S ×2 | K-P ×2 | K-E ×2 | K-D ×2 | K-R ×1 | K-C ×1 | K-V ×1 | Total |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| r1 | 2. La semilla se produce en el mismo pipeline, byte a byte (`ARQ` H-10) | 2. La semilla de E01 es un `index.html` mínimo, no un release (`ARQ` H-10): sin medir como release | 2. Disco: 9,13 MB por versión con A (E1, `ARQ` H-08); con C-min, sin medir | 2. Tres destinos de vuelta que explicar | 1. Volver a la semilla deja una versión vieja frente a datos escritos por versiones nuevas (`ASD` H-07; `REF` R-12) | 2 | 3. Un parámetro | **22** |
| r2 | 3. Dos directorios en el teléfono | 3. `versions/vN` + puntero, medido (`ARQ` E02-R) | 2. Igual | 3. «La semilla sólo sirve para el primer arranque» | 2. El servidor cumple el invariante 10 al pie de la letra; la vuelta local es sólo a `previous`, ya verificada (`SEG` H-04) | 3 | 3 | **30** |

**Recomendación: r2.** La semilla sigue siendo una versión **completa** del contenido (`SEG` H-03, por App Review
4.2.3(ii)). Lo único que cambia es que no se usa como destino de rollback.

**Cadena de r2:**

1. **Dónde cae.** En el teléfono que perdió `current` y `previous` sin red.
2. **Cuánto pesa.** Sin medir. No hay corrida con las dos versiones fallidas.
3. **Qué pierde la otra.**
   - Si se elige r2, se pierde un tercer respaldo local.
   - Si se elige r1, se carga un rollback que puede no leer los datos (`ASD` H-07).
4. **Reversible: sí.** Es un parámetro.

**Condición de revisión:** una corrida en el g42 en la que la lista local de fallidas contenga a la vez `current` y
`previous` sin red. Es el caso de `ARQ` E02-R corrida 4, con dos versiones rotas seguidas.

### P3 — Cascarón, puente y compatibilidad

**Alternativas en pie:**

- **a** (`ARQ` H-06): un rango sobre el puente, sin `minShellVersion`.
- **b** (`DEV` H-09): un rango sobre el puente más `webview-minimo`, con `minShellVersion` derivado.
- **d** (`REF` R-09): un solo predicado, `puente ∈ [>=A.B <A+1]` ∧ `requires ⊆ catálogo` ∧ `webview ≥ min`, y
  `minShellVersion` fuera del teléfono.

La versión de `CRC` (catálogo + `minShellVersion` calculado como piso) **cae por compuerta condicional**: si VPI rige,
choca con «Nunca un piso a secas» (VPI §2.6, citado por `ARQ`, `DEV`, `REQ` y `REF`). No trae ficha, así que se
cumple (Excepcion §3). Si R-04 deja VPI condicional, vuelve a estar en pie.

| Alt. | K-S ×2 | K-P ×2 | K-E ×2 | K-D ×2 | K-R ×1 | K-C ×1 | K-V ×1 | Total |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| a | 3. Una sola dimensión | 2. `handshake` y `Listo` medidos en E02-R; la evaluación del rango, sin ensayo | 1. No cubre capacidades: un contenido que usa una capacidad no declarada falla en el campo (E2, `CRC` H-08, Bluetooth en la referencia) | 3 | 0. En iOS, sin la clave de uso «the system terminates your app» (`CRC` [F15]); WebView 83 queda en «Loading» (E01 C-3) | 3 | 3. Un campo del manifiesto | **24** |
| b | 2. Dos dimensiones | 2. Ídem | 1. Igual que a para capacidades | 2 | 1. Cubre WebView, no capacidades | 2 | 3 | **20** |
| d | 2. Tres dimensiones en un predicado | 2. Sin ensayo del predicado; catálogo sin medir (`CRC` §3.4) | 3. Cubre lo que P12 agrega (F004) | 2 | 3. Se detecta antes de activar (`CRC` §3.4) | 1. Catálogo, `handshake` y validación | 3. «Es un campo más del manifiesto» (`CRC` §3.4) | **25** |

**Lectura.** a y d quedan a un punto: es empate y no lo decide la suma. Decide la existencia de P12, que la
presidencia agregó por F004: el contenido **tiene** que saber qué capacidades trae el cascarón, y a no lo modela.
Con a, la falla que la referencia del PO ya muestra en producción (Bluetooth sin declarar, `CRC` H-08) sigue sin
detectarse.

**Recomendación: d**, con el catálogo en su versión reducida (P12, R-10).

**Cadena de d:**

1. **Dónde cae.** En el actualizador, que evalúa tres condiciones antes de activar.
2. **Cuánto pesa.** Sin medir. Lo mediría una prueba unitaria del predicado en la compuerta mínima (P8).
3. **Qué pierde la otra.**
   - Si se elige d, se pierde la simplicidad de una sola dimensión.
   - Si se elige a, se pierde la detección de capacidad y de WebView antes de activar: la falla aparece en el teléfono
     del usuario, y en iOS como cierre de la app.
4. **Reversible: sí.**

**Condición de revisión:** que la compuerta del PR muestre que una de las tres dimensiones nunca discrimina, porque
ningún paquete de la demo se rechazó por ella en sus rojos provocados. En ese caso se quita.

**Con C-min (P1), el contrato es el esquema de la definición más el puente de servicios.** El transporte
`hybridwebview.js` entra al contrato sólo si se suma A (`REF` P3).

### P4 — Entrada del usuario: qué entra en la demo

Para el framework no hay disenso de fondo. F2 de `ASD` (entrada local separada de la sesión, renovación sin
bloquear) y T1 de `SEG` son compatibles. El disenso está en la demo:

- **sin IdP** (`ASD` F3, `REF` R-11);
- **con Keycloak y Keystore** (`SEG` P4).

| Alt. | K-S ×2 | K-P ×2 | K-E ×2 | K-D ×2 | K-R ×1 | K-C ×1 | K-V ×1 | Total |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Demo sin IdP | 3 | 3. El caso base funciona sin login (R1 §9, por `ASD`) | 1. Las apps reales sí tienen identidad (`ASD` P4) | 2. La guía enseña el login rotulado «no ejecutado» (`LSC` H-06) | 2 | 3 | 3. «Agregar la etapa después es reversible» (`ASD` P4) | **26** |
| Demo con Keycloak | 1. Un contenedor más y OIDC en el teléfono | 1. El g42 necesitó un túnel público (E01:323); E-N2-1 sin correr (`VER` P4) | 3 | 1. Depende de la topología de red del lector (`ACA` H-04) | 1. Túnel público (`REQ` §5); exigencias de las tiendas para apps con login (`SEG` H-10) | 1 | 2. Quitar una etapa publicada cuesta lectores (`ASD` P11) | **16** |

**Recomendación: demo sin IdP.** La decide la suma, con una diferencia amplia, y la confirma el paso 4: es
reversible.

**Cadena:**

1. **Dónde cae.** En lo que la guía enseña sin ejecutar: F2, T1 y el disparador «login con cuenta» de F004 (`CRC`
   H-07).
2. **Cuánto pesa.** Cuesta un rótulo NO VERIFICADO por tema. El costo de un IdP alcanzable desde el teléfono está
   sin medir.
3. **Qué pierde la otra.**
   - Si se elige la demo sin IdP, se pierde la demostración del momento «al iniciar sesión» que el PO señaló (F004).
   - Si se elige Keycloak, se carga un túnel público y una etapa que el lector no puede reproducir.
4. **Reversible: sí.**

**Condición de revisión:** que la presidencia tome la lectura L1 de `ASD` H-01, o que E-N2-1 cierre en verde en el
g42 por un camino de red que la guía pueda enseñar (`ACA` H-04).

### P5 — Datos locales: la librería

La migración al abrir va por XC-1 (§1). La propiedad del esquema tiene consenso: `ASD` P5.1 y `ARQ` P5 coinciden en
que el contenido no hace DDL y guarda documentos JSON. El disenso es de librería:

- **S1**: `sqlite-net-pcl` (`ARQ`, N2);
- **S2**: EF Core SQLite en el cascarón (`ASD`, N5, `REF`).

| Alt. | K-S ×2 | K-P ×2 | K-E ×2 | K-D ×2 | K-R ×1 | K-C ×1 | K-V ×1 | Total |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| S1 | 3. La usa la documentación oficial de MAUI (`ARQ` [D10]) | 2. Sin ensayo en este expediente | 2 | 2. Abandona el EF del caso base: otra API para el lector (`ASD` P5) | 3. Sin riesgo AOT conocido en iOS (`ASD` §3) | 2. Migraciones a mano | 3. Detrás de `IDb` (`ASD` P5) | **26** |
| S2 | 2 | 3. Medido en E-ASD-1 y en E-AD-1 (EF Core 10.0.11) | 2 | 3. Continuidad con el caso base que la guía usa (R1, por `ASD`) | 1. NativeAOT de EF «highly experimental» en iOS, NO VERIFICADO en .NET 10 (`ARQ` P5, N2 §4.9); bloqueo de SQLite abandonado (E2, EF Core, §1.2) | 2 | 3. Detrás de `IDb` | **26** |

**Lectura: empate exacto, y las dos son reversibles**, así que el paso 4 tampoco desempata. `REF` desempató por la
restricción literal «Tomar base … `MovilidadUrbana.MAUI`». Advierto que esa restricción no dice qué se conserva del
caso base (`REQ` H-10). Leerla como «conservar EF» es tratar el comportamiento del caso base como restricción, y
§3.3 («Comportamiento no es restricción») lo prohíbe sin una frase de quien pidió.

Lo que sí desempata, como criterio propio `[CP]`, es el alcance de P9: hay consenso en que iOS no se compila. El
riesgo que separa a S2 está entero en iOS, que no se ejecuta, mientras que la continuidad didáctica de S2 se ejerce
en cada etapa de la guía.

**Recomendación: S2**, por ese desempate, que declaro como criterio propio.

**Cadena:**

1. **Dónde cae.** En el primer build iOS en Release.
2. **Cuánto pesa.** Sin medir. Lo mediría un job `macos-*` que compile con trimming, lo que depende de la condición de
   P9.
3. **Qué pierde la otra.**
   - Si se elige S2, se carga el riesgo AOT en iOS.
   - Si se elige S1, se pierde la continuidad con la base que la guía enseña y la migración ya medida.
4. **Reversible: sí**, detrás de `IDb`.

**Condición de revisión:** el primer build iOS en Release falla por EF Core con trimming. Entonces S1 o S3
(`Microsoft.Data.Sqlite`) detrás de la misma interfaz (`ASD` P5.2).

### P6 — Procedimiento de PR: dónde se implanta T1

El procedimiento B de `DEV` no tiene disenso. El disenso está en la implantación:

- **I1**: T1 implantado en el `main` de Lab-Documentos (`DEV` H-02, como P0; `VER`).
- **I2**: T1 diseñado, con su rojo provocado, y «dónde» se pregunta al PO; mientras tanto, «diseñado, no implantado»
  (`REF` R-05).
- **I3**: un repositorio propio de la demo, con T1 (`DEV` W3).

| Alt. | K-S ×2 | K-P ×2 | K-E ×2 | K-D ×2 | K-R ×1 | K-C ×1 | K-V ×1 | Total |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| I1 | 3 | 3. `404 Branch not protected` y `admin: true`: se puede configurar (E1, `DEV` M-4 y M-5) | 1. Alcanza a quien escribe las 807 piezas de `Guides/` (E1, `REF` R-05) | 3. La guía muestra el botón deshabilitado real (VPI §3.4 T1, por `DEV`) | 1. Efecto sobre terceros no pedido (`REF` R-05) | 3 | 3. «Reversible: una configuración del repositorio» (`DEV` P6) | **27** |
| I2 | 2 | 3 | 2 | 1. La guía enseña «impedir» sin implantarlo: «diseñado, no implantado» (VPI §3.4 T5, por `DEV` H-01) | 2. Mientras tanto la compuerta es un aviso, el problema del pedido (EV001:17) | 3 | 3 | **24** |
| I3 | 2 | 1. Crear un repositorio público es una publicación: fase irreversible que va al PO (`DEV` W3) | 3 | 3 | 2 | 1 | 1. «Irreversible frente a terceros que clonen» (`DEV` W3) | **22** |

**Lectura.** I1 queda primera y es reversible. Lo que la separa de una decisión del panel no es el puntaje: es que
toca un repositorio compartido con terceros, y la mesa no aplica (Mesa-De-Expertos-A-Pedido §4, «Quién aplica»).
Con la cadena (§3, «Un obstáculo no es una decisión»): **la decisión está fundada y lo único que falta es la llave**,
el permiso de quien pidió sobre el `main` de Lab-Documentos. Eso no es una escalada ni un lote: es una pregunta de
una línea, en el momento (§6). I2 **no es una alternativa de diseño: es el estado mientras la llave no llega.**

**Recomendación: I1, condicionada al permiso de quien pidió.** Mientras no llegue, rige I2.

**Cadena de I1:**

1. **Dónde cae.** En quien abre PR en `Guides/`: espera un check.
2. **Cuánto pesa.** La compuerta de la demo mide 28 s de unitarias y unos 2 min de APK (E1, `DEV` M-11; R2). Para un PR
   de `Guides/` el agregador responde verde por decisión escrita en el paso (`DEV` P11). El tiempo de ese verde está
   sin medir.
3. **Qué pierde la otra.**
   - Si se elige I1, se pierde la separación entre demo y guías.
   - Si se elige I3, se carga una publicación irreversible.
   - Si queda I2 indefinidamente, se pierde el «impedir».
4. **Reversible: sí.** Es una configuración.

**Condición de revisión:** la API de corridas muestra PR de `Guides/` bloqueados por el check de la demo (un rojo que
no toca `Demo/**`). Eso indicaría que el filtro por paso falla.

**Dependencia con P11.** `REF` R-06 pide que el check **no** sea requerido hasta que el PO acepte el riesgo del runner
en un repositorio público. I1 lo hace requerido. Las dos cosas van en **la misma pregunta** al PO (§6).

### P8 — Qué es compuerta obligatoria

**Alternativas en pie:**

- **O2 con siete capas obligatorias** (`DEV` P8, `VER`);
- **O2 con compuerta mínima** (`REF` R-13): build `-warnaserror`, unitarias de dominio y del actualizador (con C02–C08
  de `SEG`), APK y agregador estricto. bUnit, el contrato y Playwright pasan al tramo siguiente.

| Alt. | K-S ×2 | K-P ×2 | K-E ×2 | K-D ×2 | K-R ×1 | K-C ×1 | K-V ×1 | Total |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Siete capas | 1. Siete suites, cada una con su rojo provocado | 1. bUnit, el contrato y Playwright sin tiempo medido en el runner; PactNet «por decidir con un ensayo» (`DEV` P8) | 3 | 1. La «ceremonia que nadie completa» (`REF` R-13) | 3 | 0 | 3. Se quitan suites | **18** |
| Compuerta mínima | 3 | 3. 18 pruebas en 28 s (E1, `DEV` M-11); APK ~2 min (R2) | 2. Las capas siguientes entran con condición | 2. La pirámide crece por tramos (Vocke, verificado en N4) | 2. Los componentes del contenido quedan sin cobertura hasta el tramo siguiente | 3 | 3. Se suman suites | **28** |

**Recomendación: compuerta mínima.** Con C-min (P1), la capa «contenido WASM en navegador con Playwright»
desaparece, y la de contrato pasa a ser la prueba del esquema de la definición.

**Cadena:**

1. **Dónde cae.** En una regresión de un componente Razor que llega a `main`.
2. **Cuánto pesa.** Sin medir: no hay historia de PR de la demo.
3. **Qué pierde la otra.**
   - Si se elige la mínima, se pierde la cobertura de componentes y de contrato desde el día uno.
   - Si se eligen las siete capas, se carga un primer PR con siete rojos provocados.
4. **Reversible: sí.**

**Condición de revisión, comprobable:** que se publique el primer paquete de contenido o de definición fuera de la
demo, o que se declare la fase `candidata` (VPI §3.4: los tramos se exigen desde la fase en que rigen sus reglas). Lo
que ocurra primero.

### P10 — Estructura de la guía

**Alternativas en pie:**

- **O3** (`LSC`);
- **O3-m** (`ACA`);
- **O3-m-r**: O3-m con los temas atados a una pregunta decidida (`REF` R-14).

| Alt. | K-S ×2 | K-P ×2 | K-E ×2 | K-D ×2 | K-R ×1 | K-C ×1 | K-V ×1 | Total |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| O3 | 1. 19 × 7 = 133 subsecciones (E1, `ACA` H-06; `LSC` P10) | 1. Unos 53 documentos (`ACA` P10) | 2 | 1. Relleno «no aplica»: carga extrínseca (`ACA` H-06) | 1. Choca con OB-MD-02 y OB-VOZ-06 de R3 (`ACA` H-06) | 0 | 3. «Fundir las familias después también es barato» (`LSC` P10) | **14** |
| O3-m | 2. 19 tablas de 5 filas (`ACA` P10) | 2 | 2 | 3. Inicio rápido y tutorial (Diátaxis; GitHub Docs, por `ACA` H-07) | 2 | 2 | 3. «Una tabla se despliega en subsecciones» (`ACA` P10) | **25** |
| O3-m-r | 3. Cada tema responde a una pregunta decidida o sale (`REF` R-14) | 2. Número de temas resultante sin medir | 2 | 3 | 2 | 3 | 3 | **28** |

**Recomendación: O3-m-r.** O3-m-r y O3-m quedan a 3 puntos, que trato como empate. Lo decide K-C: la diferencia sale
de no escribir temas que ninguna decisión pide, y esa diferencia **se puede medir** contando temas cuando el dictamen
esté cerrado.

**Cadena:**

1. **Dónde cae.** En un tema transversal que ninguna pregunta cubre.
2. **Cuánto pesa.** Sin medir.
3. **Qué pierde la otra.**
   - Si se elige O3-m-r, se pierde el árbol completo de N5, que algún lector podría echar en falta.
   - Si se elige O3-m, se escriben temas sin decisión que los sostenga.
4. **Reversible: sí.**

**Condición de revisión:** una obligación de R3 o del perfil exige un tema que no responde a ninguna pregunta decidida.
Lo detecta el verificador V-03 al correr sobre la guía. Ese tema se agrega con su motivo.

### P11 — Demo: dónde vive el workflow y cuál es el alcance

**Dónde vive el workflow.** W1 (YAML de referencia en `Demo/workflows/`) **se descarta antes de ponderar**:

- GitHub no lo ejecuta (E2: GitHub Docs, por `LSC` H-05 y `DEV` H-01);
- y no cumple «Configura el wofklow» (E2: EV001:35; E1 de `VER` H-09: no hay `.github/`).

Quedan en pie W2 (raíz de Lab-Documentos) y W3 (repositorio propio).

| Alt. | K-S ×2 | K-P ×2 | K-E ×2 | K-D ×2 | K-R ×1 | K-C ×1 | K-V ×1 | Total |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| W2 | 2. Filtro por paso; el agregador responde verde por decisión escrita en los PR de guías (`DEV` P11) | 3. «Un archivo» (`LSC` P11); `admin: true` (`DEV` M-5) | 2. Un repositorio de documentos mezclado con CI (`DEV` W2) | 2. El lector de un fork no tiene el runner (`ACA` H-05) | 1. Runner propio, como root, en un repositorio público con PR de guías (E1 de `VER` H-04; GitHub *Secure use reference*, abierta por `REF` R-06) | 3 | 3. «Se borra el archivo y la regla» (`DEV` W2) | **25** |
| W3 | 3 | 1. Crear un repositorio público va al PO (`DEV` W3) | 3 | 1. Separa la demo de la guía: los enlaces relativos dejan de resolver (`LSC` P11) | 2. El mismo riesgo del runner, con menos PR ajenos `[CP]` | 1 | 1. «Irreversible frente a terceros que clonen» (`DEV` W3) | **20** |

**Recomendación: W2.** La deciden la suma y el paso 4: W2 es reversible y W3 no.

**Cadena:**

1. **Dónde cae.** En el host i7infra, si un colaborador con escritura abre un PR malicioso.
2. **Cuánto pesa.** Sin medir. Atenuantes medidos: desde el contenedor del runner el adb no responde, y no hay socket
   de Docker ni `/dev/kvm` (E1, `VER` H-04).
3. **Qué pierde la otra.**
   - Si se elige W2, se mezcla CI en un repositorio de guías.
   - Si se elige W3, se publica un repositorio irreversible y se rompen los enlaces de la guía.
4. **Reversible: sí.**

**Condición de revisión:** que la demo pase a repositorio propio («si `Demo/` pasa a repositorio propio, el YAML se
muda con ella», `LSC` P11), o que la API de la org muestre que el grupo del runner no se puede acotar a repositorios
nombrados (`DEV` H-04; hoy 403, M-7).

**Alcance.** Alternativas en pie:

- **M2** (`ASD`, ajustado a C-min por `REF`): encuesta v1→v2 como definición, adulterado rechazado, rollback, PR en
  rojo y encuesta sin red por el outbox hacia un receptor didáctico;
- **los cuatro hechos de `ACA`**;
- **M2 con login** (`SEG`).

| Alt. | K-S ×2 | K-P ×2 | K-E ×2 | K-D ×2 | K-R ×1 | K-C ×1 | K-V ×1 | Total |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| M2 | 2. Suma el outbox y el receptor didáctico (`ASD` H-10) | 2. Outbox medido en Linux (E-ASD-1); receptor sin medir | 3 | 3. Ejercita el escenario que dio quien pidió (F005) | 2 | 2 | 3 | **27** |
| Cuatro hechos (`ACA`) | 3 | 3. Tres de los cuatro medidos en el g42 (E01 §6.2); el rojo, en M-13 | 1. No ejercita trabajo sin red ni P13 | 2. No ilustra F005 | 1. El cruce entre actualizar y trabajar sin red queda sin probar, y es el punto de mayor riesgo (`ASD` H-06) | 3 | 3 | **25** |
| M2 con login (`SEG`) | 1 | 1. Ver P4 | 3 | 1 | 1 | 0 | 2 | **15** |

**Recomendación: M2.** Entre M2 y los cuatro hechos hay 2 puntos, que trato como empate. Lo decide F005: es el
escenario de referencia de quien pidió, y los cuatro hechos no lo ejercitan. Esto depende de R-03.

**Cadena:**

1. **Dónde cae.** En una pieza más, el receptor didáctico, declarado como doble de prueba (`ASD` H-10).
2. **Cuánto pesa.** Sin medir.
3. **Qué pierde la otra.**
   - Si se elige M2, se agregan etapas.
   - Si se eligen los cuatro hechos, la demo no muestra lo que el PO describió.
4. **Reversible: sí.** Sumar una etapa es reversible; quitarla después cuesta lectores (`ASD` P11).

**Condición de revisión:** que la presidencia no sume la cláusula sin red (R-03) y quien pidió diga que F005 es sólo
ilustrativo. Entonces, los cuatro hechos.

**Cómo corre:** C3 de `ACA` (receta versionada dentro de `Demo/`) no tiene alternativa en pie. El camino público no
llegó a un APK en tres corridas (E1, `ACA` H-02).

### P12 — Capacidades del dispositivo

**Alternativas en pie:**

- **versión de `CRC` §3.4**: catálogo generado en el build, cinco estados, prueba de CI sobre AndroidManifest **e**
  Info.plist, y `minShellVersion` calculado;
- **versión reducida de `REF` R-10**: lista constante en el cascarón expuesta por el `handshake`, `requires`/`optional`
  validados antes de activar, y CI sólo sobre AndroidManifest, con iOS declarado «sin compuerta».

| Alt. | K-S ×2 | K-P ×2 | K-E ×2 | K-D ×2 | K-R ×1 | K-C ×1 | K-V ×1 | Total |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `CRC` | 1. Generador, cinco estados y un cálculo | 1. La prueba sobre Info.plist no tiene dónde correr: el runner es Linux (E1, `DEV` M-9; `REF` R-10) | 3 | 1 | 3. Cubre iOS, donde falta de clave = cierre (`CRC` [F15]) | 1 | 3 | **19** |
| R-10 | 3 | 2. Sin medir; AndroidManifest sí se puede leer en el runner `maui-android` `[CP]` | 2 | 3 | 2. iOS sin compuerta, declarado (`DEV` H-12) | 3 | 3. Ampliar la lista después | **28** |

**Recomendación: R-10.** Coincide con P9: iOS no se compila.

**Cadena:**

1. **Dónde cae.** En un cascarón iOS sin la clave de uso.
2. **Cuánto pesa.** Hoy no pesa nada: no hay build iOS.
3. **Qué pierde la otra.**
   - Si se elige R-10, se pierden la compuerta sobre Info.plist y los estados finos del `handshake`.
   - Si se elige la de `CRC`, se carga una prueba que no corre.
4. **Reversible: sí.**

**Condición de revisión:** la misma que P9. Existe un job `macos-*` medido o una cuenta de Apple Developer asentada
(`SEG` P9, `DEV` P9). Desde ahí se suma la prueba sobre Info.plist.

## 4. Preguntas sin alternativas en pie

| P | Por qué no hay matriz | Lo que queda en pie (de `REF` §7) |
| --- | --- | --- |
| P7 | Las alternativas (a) número único y (b) piso de `minShellVersion` no quedan en pie. (a) se descarta por el paso 4: «irreversible en la práctica» (`DEV` P7). (b) se descarta por VPI §2.6, si VPI rige. La divergencia de gramáticas de `REQ` H-07 es un defecto de los dossiers, no una alternativa | La tabla de `DEV` P7, más la línea «definición de encuesta» con C-min. **Depende de R-04** |
| P9 | Consenso de `DEV`, `SEG`, `VER` y `ARQ` | C ahora, con el job `macos-*` como agregado para el PO. Condición de revisión: cuenta de Apple Developer asentada o runner macOS medido |
| P13 | `CRC` §3.5 y `ASD` H-06 convergen | `{encuestaId, versionDefinicion}` en cada respuesta; el cliente conserva las definiciones con pendientes; ninguna actualización descarta pendientes. El receptor didáctico es pieza obligatoria (`REF` P13). Sin verificar: que ODK Central acepte versiones anteriores (`CRC` §9) |

## 5. Dependencias entre decisiones

| Si la presidencia… | Cambia |
| --- | --- |
| R-01 toma la lectura (b), «también código de pantallas» | P1 pasa a C-full (A como extensión, con umbral de TTFD previo); P3 suma el transporte al contrato; P8 suma Playwright; P9 recupera los riesgos de iOS ≥ 16.4 y `.wasm` |
| R-03 **no** suma la cláusula sin red | En P1, D vuelve a estar en pie y queda primera por suma (28); hay que decidirla por otro criterio. En P11, el alcance pasa a los cuatro hechos. P13 pierde su escenario |
| R-04 deja VPI condicional | XC-1 decae (§1). P3 recupera la versión de `CRC` con `minShellVersion` como piso. P7 pierde su gramática obligatoria. P8 deja de depender de los tramos de VPI §3.4 |
| El PO no da permiso sobre el `main` de Lab-Documentos | P6 queda en I2 («diseñado, no implantado») y P11 W2 queda con el check como aviso (`REF` R-06) |

**Cadena entre preguntas.** C-min (P1) simplifica P3, P8, P9 y P13 en la misma dirección. Si se revisa P1, hay que
revisar esas cuatro juntas: la unidad de aplicación es el dictamen entero, no una pregunta suelta (§3.3, «La unidad de
aplicación es el documento», por analogía `[CP]`).

## 6. Obstáculos y medidas que faltan

Cadena-De-Consecuencias §3: donde falta poder y no decidir, una pregunta de una línea a quien tiene la llave. No
tengo canal con quien pidió, así que se las entrego a la presidencia el 2026-10-25, con este folio, para que las haga
en el momento.

| Para | Pregunta de una línea | Destraba |
| --- | --- | --- |
| Quien pidió (PO) | «¿Autorizás proteger el `main` de Lab-Documentos con PR obligatorio y el check de la demo requerido, aceptando que el runner propio corra los PR de ese repositorio público?» | P6 (I1) y P11 (W2, `REF` R-06) |
| Quien administre la org `hdcm-dev` | «¿El grupo del runner `i7infra-runner-dev` se puede acotar a Lab-Documentos?» (hoy 403, `DEV` M-7) | Condición de revisión de P11 |
| Quien tenga el g42 (presidencia) | «Correr E02-B con la definición bajada por el canal firmado y medir el peso y el primer render» | La celda «sin medir» de C-min en P1 |

**Celdas «sin medir»** que no cambian las recomendaciones de arriba, porque cada una la decidió otro paso:

- P1: el peso de la definición y del esquema;
- P2: la doble falla sin red;
- P3: el costo del predicado;
- P5: EF Core en iOS;
- P8: el tiempo de las capas siguientes;
- P10: el número de temas;
- P11: el receptor didáctico;
- P12: el costo de la lista.

## 7. Resumen para el jurado

| P | Recomendación del análisis | Decidida por | Condición de revisión |
| --- | --- | --- | --- |
| XC-1 | C-1: sobre fijo, cumplir (31); C-2: Alt-3 (25), primera si K-4 pesa 6 o más | Suma, con K-1 a K-3 a peso 3; medida de E-AD-1 | Una migración del cascarón que cambie el número exigido. **Sólo si VPI rige** |
| P1 | C-min | Compuerta F005 (condicional a R-03) y paso 4; **no** la suma: D suma más | Lectura (b) de R-01, o una corrección de encuesta que el esquema no expresa |
| P2 | Activación de E02-R; retención r2 | Descarte por E2 y suma | Lista de fallidas con `current` y `previous` sin red |
| P3 | d, un predicado | P12 y la evidencia de falla en campo; la suma es empate | Una dimensión que nunca discrimina |
| P4 | Demo sin IdP | Suma y paso 4 | L1 de `ASD` H-01, o E-N2-1 en verde |
| P5 | S2, EF Core | Empate; desempate `[CP]` por el alcance de P9 | Primer build iOS Release que falla |
| P6 | I1 con permiso del PO; mientras tanto I2 | Obstáculo, no decisión (Cadena §3) | PR de `Guides/` bloqueados por el check |
| P8 | Compuerta mínima | Suma | Primer paquete publicado o fase `candidata` |
| P10 | O3-m-r | Empate con O3-m; lo decide K-C | V-03 exige un tema sin pregunta |
| P11 | W2; alcance M2; C3 | Paso 4 (W2); F005 (M2) | Repositorio propio; R-03 sin la cláusula |
| P12 | R-10 | Suma; alineada con P9 | Job `macos-*` medido |
| P7, P9, P13 | Sin matriz (§4) | — | — |

Este folio no emite hallazgos ni vota. Analiza una ficha admitida (XC-1). No hay fichas no admitidas.

Sigue: incorporación del siguiente informe y resolución · presidencia
