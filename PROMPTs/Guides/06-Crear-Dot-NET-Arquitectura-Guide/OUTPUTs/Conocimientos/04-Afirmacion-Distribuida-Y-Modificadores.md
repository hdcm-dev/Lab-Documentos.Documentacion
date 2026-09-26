# 04 — Afirmación distribuida, modificadores y sintonización del conjunto

**Fecha:** 2026-09-26
**Rol:** gramática del español y gramática del texto, aplicadas al análisis de enunciados de negocio.
**Qué es:** la corrección de **tres defectos medidos en uso** del criterio de corte
(`02-Criterio-De-Segmentacion.md`) y de su catálogo hermano (`03-Catalogo-De-Etiquetas.md`). El
primero es local y se arregla dentro de la jerarquía de indicios: **el conjunto de contraste se
buscaba en el lugar equivocado**, y dos preguntas distintas estaban colapsadas en una. El segundo es
estructural: **el procedimiento atomiza, y lo que sólo existe entre fragmentos no lo produce nunca**.
Acá se caracteriza ese fenómeno —la **afirmación distribuida**—, se define la **pasada de
recomposición** que lo recoge, y se fija con qué rótulo sale su producto y qué evidencia hay que
exhibir para que no sea una licencia para fabular.
**Qué no es:** no es un tratado de lingüística del texto ni una reescritura de los documentos
hermanos. No los edita: deja los **parches redactados** (§15) para que otro los aplique. Tampoco
decide si una afirmación es regla ni de qué especie: eso sigue siendo del cuerpo metodológico
(`Knowledge-Deduccion-De-Reglas-De-Negocio.md`), cuyos rótulos se reutilizan **sin crear ninguno
nuevo**. El tercero llegó después y es más grande que los dos primeros: **no es un indicio más, es un
cuestionamiento al algoritmo**. El procedimiento asigna **una** lectura por fragmento, decidida
localmente, y tira las alternativas; se propone abrir una gama de lecturas y resolver el conjunto por
consistencia mutua. La **Parte III** evalúa esa tesis y las otras tres que vienen con ella, resuelve
el freno de la explosión combinatoria, y agrega la pasada de **sintonización** con la **escalera de
diagnóstico** —ambigüedad de expresión, incompletitud, contradicción— que impide declarar defectuoso
lo que sólo estaba incompleto.

---

## Índice

- [0. Procedencia, alcance y estatuto](#0-procedencia-alcance-y-estatuto)
  - [0.1 Los tres defectos, y por qué son el mismo visto desde tres alturas](#01-los-tres-defectos-y-por-qué-son-el-mismo-visto-desde-tres-alturas)
  - [0.2 Qué es propio y qué es tradición](#02-qué-es-propio-y-qué-es-tradición)
  - [0.3 Notación](#03-notación)
- [Parte I — Modificadores](#parte-i--modificadores)
- [1. El ámbito del conjunto de contraste](#1-el-ámbito-del-conjunto-de-contraste)
  - [1.1 El error, en el caso que lo produjo](#11-el-error-en-el-caso-que-lo-produjo)
  - [1.2 Los dos ejes: sobre qué conjunto, y en qué parte del texto](#12-los-dos-ejes-sobre-qué-conjunto-y-en-qué-parte-del-texto)
  - [1.3 Procedimiento de búsqueda del conjunto de contraste](#13-procedimiento-de-búsqueda-del-conjunto-de-contraste)
  - [1.4 La regla del ámbito agotado, y el criterio de corte de la búsqueda](#14-la-regla-del-ámbito-agotado-y-el-criterio-de-corte-de-la-búsqueda)
  - [1.5 Qué vale como ejemplar de contraste y qué no](#15-qué-vale-como-ejemplar-de-contraste-y-qué-no)
- [2. El indicio del paralelismo](#2-el-indicio-del-paralelismo)
  - [2.1 Formulación](#21-formulación)
  - [2.2 Las cuatro condiciones que lo habilitan](#22-las-cuatro-condiciones-que-lo-habilitan)
  - [2.3 Cuándo no vale](#23-cuándo-no-vale)
  - [2.4 Dónde entra en la jerarquía](#24-dónde-entra-en-la-jerarquía)
- [3. Restringir no es informar: las dos preguntas y los cuatro cuadrantes](#3-restringir-no-es-informar-las-dos-preguntas-y-los-cuatro-cuadrantes)
  - [3.1 Por qué colapsarlas induce el error](#31-por-qué-colapsarlas-induce-el-error)
  - [3.2 Las dos preguntas, con su prueba](#32-las-dos-preguntas-con-su-prueba)
  - [3.3 Los cuatro cuadrantes](#33-los-cuatro-cuadrantes)
  - [3.4 Un ejemplo por cuadrante](#34-un-ejemplo-por-cuadrante)
  - [3.5 El caso «central», resuelto](#35-el-caso-central-resuelto)
- [4. El adjetivo con dominio cerrado](#4-el-adjetivo-con-dominio-cerrado)
  - [4.1 Qué es: declarar los valores contra asignar uno](#41-qué-es-declarar-los-valores-contra-asignar-uno)
  - [4.2 Cómo se reconoce: cinco señales](#42-cómo-se-reconoce-cinco-señales)
  - [4.3 En qué se diferencia de la atribución, de la definición y de la cardinalidad](#43-en-qué-se-diferencia-de-la-atribución-de-la-definición-y-de-la-cardinalidad)
  - [4.4 Las tres afirmaciones que arrastra, y el tercer valor](#44-las-tres-afirmaciones-que-arrastra-y-el-tercer-valor)
  - [4.5 Etiqueta, marca y destino](#45-etiqueta-marca-y-destino)
- [Parte II — La afirmación distribuida](#parte-ii--la-afirmación-distribuida)
- [5. Caracterización del fenómeno](#5-caracterización-del-fenómeno)
  - [5.1 El caso, y qué afirmación se pierde](#51-el-caso-y-qué-afirmación-se-pierde)
  - [5.2 El aparato disponible, candidato por candidato](#52-el-aparato-disponible-candidato-por-candidato)
  - [5.3 Veredicto: son dos cosas, y hay que separarlas](#53-veredicto-son-dos-cosas-y-hay-que-separarlas)
  - [5.4 Por qué el procedimiento actual no puede producirla](#54-por-qué-el-procedimiento-actual-no-puede-producirla)
  - [5.5 Las tres clases de afirmación distribuida](#55-las-tres-clases-de-afirmación-distribuida)
- [6. La pasada de recomposición (P13)](#6-la-pasada-de-recomposición-p13)
  - [6.1 Qué se sostiene y qué se refuta de la propuesta](#61-qué-se-sostiene-y-qué-se-refuta-de-la-propuesta)
  - [6.2 El procedimiento, en ocho pasos](#62-el-procedimiento-en-ocho-pasos)
  - [6.3 La prueba de admisión: cinco condiciones](#63-la-prueba-de-admisión-cinco-condiciones)
  - [6.4 El criterio de corte](#64-el-criterio-de-corte)
  - [6.5 Lo que esta pasada no produce](#65-lo-que-esta-pasada-no-produce)
- [7. Rótulo de salida y evidencia exigible](#7-rótulo-de-salida-y-evidencia-exigible)
  - [7.1 Con qué rótulo sale cada clase](#71-con-qué-rótulo-sale-cada-clase)
  - [7.2 La ficha de afirmación distribuida](#72-la-ficha-de-afirmación-distribuida)
  - [7.3 La compuerta anti-fabulación: seis prohibiciones](#73-la-compuerta-anti-fabulación-seis-prohibiciones)
  - [7.4 Seis anti-patrones de sobreinterpretación](#74-seis-anti-patrones-de-sobreinterpretación)
- [8. Señales textuales de afirmación distribuida](#8-señales-textuales-de-afirmación-distribuida)
  - [8.1 Las ocho que sostengo](#81-las-ocho-que-sostengo)
  - [8.2 Las tres que descarto como señal, y por qué](#82-las-tres-que-descarto-como-señal-y-por-qué)
- [9. Ejemplo integrado](#9-ejemplo-integrado)
- [Parte III — Lecturas múltiples y sintonización](#parte-iii--lecturas-múltiples-y-sintonización-del-conjunto)
- [10. Las cuatro tesis, evaluadas una por una](#10-las-cuatro-tesis-evaluadas-una-por-una)
  - [10.1 T-1 — La redundancia del autor es funcional](#101-t-1--la-redundancia-del-autor-es-funcional)
  - [10.2 T-2 — La redundancia vuelve detectable la ambigüedad](#102-t-2--la-redundancia-es-lo-que-vuelve-detectable-la-ambigüedad)
  - [10.3 T-3 — El algoritmo actual es el equivocado](#103-t-3--el-algoritmo-actual-es-el-equivocado)
  - [10.4 T-4 — Alcance: qué es del lenguaje y qué es general](#104-t-4--vale-para-cualquier-texto-y-el-autor-lo-extiende-a-imágenes)
- [11. Reafirmación: adorno, triangulación, discordia](#11-reafirmación-adorno-triangulación-discordia)
  - [11.1 Qué cuenta como reafirmación](#111-qué-cuenta-como-reafirmación)
  - [11.2 Las cinco formas que se reconocen](#112-las-cinco-formas-que-se-reconocen)
  - [11.3 La prueba de la discriminación y sus tres resultados](#113-la-prueba-de-la-discriminación-y-sus-tres-resultados)
  - [11.4 La reformulación de I-07, y lo que le faltaba a I-06](#114-la-reformulación-de-i-07-y-lo-que-le-faltaba-a-i-06)
- [12. Apertura selectiva: el registro de lecturas abiertas](#12-apertura-selectiva-el-registro-de-lecturas-abiertas)
  - [12.1 La apertura no se busca, se cosecha](#121-la-apertura-no-se-busca-se-cosecha)
  - [12.2 Las nueve entradas que autorizan abrir](#122-las-nueve-entradas-que-autorizan-abrir)
  - [12.3 Cómo se escribe una lectura, y el techo de dos](#123-cómo-se-escribe-una-lectura-y-el-techo-de-dos)
  - [12.4 La cota global, y qué significa superarla](#124-la-cota-global-y-qué-significa-superarla)
- [13. La pasada de sintonización (P12)](#13-la-pasada-de-sintonización-p12)
  - [13.1 Por qué no hay explosión combinatoria](#131-por-qué-no-hay-explosión-combinatoria)
  - [13.2 El procedimiento, en siete pasos](#132-el-procedimiento-en-siete-pasos)
  - [13.3 El orden de resolución y el desempate determinista](#133-el-orden-de-resolución-y-el-desempate-determinista)
  - [13.4 Propagación y descarte con causa](#134-propagación-y-descarte-con-causa)
  - [13.5 Los ciclos sin casilla forzada](#135-los-ciclos-sin-casilla-forzada)
  - [13.6 La escalera de diagnóstico: expresión, incompletitud, contradicción](#136-la-escalera-de-diagnóstico-expresión-incompletitud-contradicción)
  - [13.7 La pieza faltante: una operación, tres manifestaciones](#137-la-pieza-faltante-una-operación-tres-manifestaciones)
  - [13.8 Criterio de corte y la única realimentación permitida](#138-criterio-de-corte-y-la-única-realimentación-permitida)
  - [13.9 Rótulo del producto y evidencia exigible](#139-rótulo-del-producto-y-evidencia-exigible)
- [14. Banco de pruebas: las reafirmaciones del párrafo](#14-banco-de-pruebas-las-reafirmaciones-del-párrafo)
  - [14.1 «instalaciones y viviendas»](#141-instalaciones-y-viviendas)
  - [14.2 «casco central / puestos rurales / son instalaciones»](#142-casco-central--puestos-rurales--son-instalaciones)
  - [14.3 «En el mismo acto»](#143-en-el-mismo-acto)
  - [14.4 Caso testigo de la escalera: la actividad sin lotes](#144-caso-testigo-de-la-escalera-la-actividad-sin-lotes)
  - [14.5 Qué muestra el banco](#145-qué-muestra-el-banco)
- [15. Parches redactados, listos para aplicar](#15-parches-redactados-listos-para-aplicar)
  - [15.1 Parches a `02-Criterio-De-Segmentacion.md`](#151-parches-a-02-criterio-de-segmentacionmd)
  - [15.2 Parches a `03-Catalogo-De-Etiquetas.md`](#152-parches-a-03-catalogo-de-etiquetasmd)
  - [15.3 Qué no se toca, y por qué](#153-qué-no-se-toca-y-por-qué)
  - [15.4 Parches a `Knowledge-Deduccion-De-Reglas-De-Negocio.md`](#154-parches-a-knowledge-deduccion-de-reglas-de-negociomd)
- [16. Límites declarados](#16-límites-declarados)
- [17. Control de cambios](#17-control-de-cambios)

---

## 0. Procedencia, alcance y estatuto

### 0.1 Los tres defectos, y por qué son el mismo visto desde tres alturas

El párrafo que los produjo, citado entero porque **de eso justamente se trata**:

> «Una estancia agropecuaria tiene un nombre y está compuesta por al menos un campo en su momento de
> conformación. En el mismo acto se establece **un casco central** a cargo de un Administrador **y
> varios puestos rurales**, de los cuales cada uno se puede conocer el nombre del encargado. **Tanto
> el casco como el puesto son instalaciones** y viviendas donde se aloja el dueño y personal de la
> estancia. La administración del casco y de los puestos se contempla en un futuro análisis del
> sistema.»

**Defecto 1.** Frente a «un casco central», el analista preguntó si «central» distinguía ese casco de
**otros cascos**. Como hay uno solo, concluyó que no había conjunto de contraste, y de ahí que el
adjetivo describía sin restringir. Fue un **error de alcance**: el contraste no era con otros cascos
—era con los **puestos rurales**, en posición paralela dentro de la misma oración—, y la tercera
oración cierra el conjunto al declarar que casco y puesto son ambos **instalaciones**. El conjunto de
contraste existía, y era *las instalaciones de la estancia*.

**Defecto 2.** El procedimiento corta el párrafo en oraciones, las oraciones en fragmentos, y etiqueta
cada fragmento. Esa atomización destruye lo que **sólo existe entre fragmentos**. Hay una afirmación
verdadera del negocio —*la instalación central de la unidad productiva es el casco, y las periféricas
son los puestos*— que sale de cruzar la oración 2 con la oración 3, que **ningún fragmento contiene**,
y que el procedimiento vigente, por construcción, no produce nunca.

**Defecto 3 —llegó después, y lo trae el autor del enunciado.** No sale de este párrafo solo: sale de
mirar cómo el procedimiento decide. Hoy asigna **una** lectura por fragmento, la decide **localmente**
y **descarta las alternativas sin registrarlas**. La tesis es que hace falta admitir una gama de
lecturas y **sintonizarlas entre sí**, y que el instrumento para hacerlo es la **redundancia del
propio autor**: las reafirmaciones son lo que permite que una lectura equivocada choque con algo en
vez de pasar inadvertida. Se trata entero en la **Parte III**, tesis por tesis, con su freno
combinatorio y con la escalera que separa la ambigüedad de la incompletitud y de la contradicción.

**Son el mismo defecto a tres alturas.** Lo que le faltó al indicio del contraste es exactamente lo que
le falta al procedimiento entero: **mirar más allá del fragmento**. El indicio 4 buscaba dentro del
sintagma un conjunto que estaba en la oración de al lado; el procedimiento busca dentro del fragmento
afirmaciones que están repartidas en el párrafo. Por eso los dos se tratan en un mismo documento: la
corrección del primero es el caso chico de la corrección del segundo, y el mecanismo que resuelve el
grande —la **hiperonimia diferida** de la tercera oración— es el mismo que resuelve el chico. Y el
tercero es el mismo error una altura más arriba: **decidir con la evidencia que hay a mano en vez de
esperar la que el texto va a dar más adelante**. Los tres se corrigen igual: guardando lo que el
procedimiento descartaba y dándole una pasada más, con prueba de admisión.

> **Orden de corrida, para tener el mapa completo:**
> P0 … P11 (corte y etiquetado, **sin cambios**) → **P12 sintonización** (Parte III) → **P13
> recomposición** (Parte II). La sintonización va primero porque componer premisas exige que cada
> premisa tenga **una sola lectura**.

> La frase que gobierna este documento, y es del autor del enunciado:
> *«el autor apuntó ideas en todo el conjunto del párrafo, no es que son simples frases
> independientes, sino que todas conjugadas van dando un sentido más amplio».*
>
> Y su contrapeso, que es de la casa:
> **el sentido más amplio se produce con evidencia exhibida, o no se produce.** Una pasada que busca
> «lo que el texto sugiere» sin prueba de admisión es una máquina de atribuirle al autor lo que no
> dijo.

### 0.2 Qué es propio y qué es tradición

Regla de la casa, heredada de `02` §0.3: **no se cita lo que no se cotejó.** Este documento no tuvo a
la vista ningún texto académico. Los nombres de tradición que aparecen en §5.2 —cohesión y coherencia,
progresión temática, isotopía, anáfora asociativa, presuposición, implicatura, marco— se dan **como
orientación bibliográfica y enunciados con mis palabras, sin comillas, sin página y sin garantía de
que la atribución sea exacta**. Y algo más importante: **ninguna decisión operativa de este documento
depende de que esa atribución sea correcta.** Si un nombre está mal asignado, el procedimiento de §6 y
la prueba de admisión de §6.3 siguen valiendo tal cual, porque no se apoyan en la autoridad del nombre
sino en la prueba que cada uno tiene al lado.

| Afirmación | Estatuto |
| --- | --- |
| Que la cohesión se realiza por recursos de superficie —referencia, elipsis, conexión, recurrencia léxica, hiperonimia— y que la coherencia es la construcción global del sentido | **Tradición corriente en gramática del texto**, con mis palabras, sin cotejo. Asociada al aparato de Halliday y Hasan; la atribución va sin garantía |
| Que la progresión temática describe cómo el tema de una oración se encadena con lo que la anterior aportó como rema | **Tradición corriente**, con mis palabras, sin cotejo. Asociada a Daneš; sin garantía |
| Que la isotopía es la recurrencia de un rasgo semántico que da unidad de lectura | **Tradición corriente**, con mis palabras, sin cotejo. Asociada a Greimas; sin garantía |
| Que existe una anáfora **asociativa**, en la que un grupo nominal definido se introduce sin antecedente porque un marco lo licencia | **Tradición corriente**, con mis palabras, sin cotejo. Asociada a Charolles; sin garantía. **Se cita para descartarla**: no describe este caso |
| Que la implicatura conversacional es cancelable sin contradicción, y la implicación lógica no | **Tradición corriente**, con mis palabras, sin cotejo. Asociada a Grice; sin garantía. **De acá sale una decisión operativa**, y se la sostiene con la prueba de la negación (§6.3), no con la autoridad |
| Que un marco de dominio suministra roles y expectativas al lector | **Tradición corriente**, con mis palabras, sin cotejo. Asociada a Fillmore; sin garantía |
| El nombre **afirmación distribuida** y su definición | **Criterio propio.** El fenómeno fue observado y descripto por el autor del enunciado; el nombre y la definición operativa son de este documento |
| Los **dos ejes** del conjunto de contraste (referencial y textual) y el orden de búsqueda | **Criterio propio** |
| La **regla del ámbito agotado** | **Criterio propio.** Es la corrección del defecto 1 |
| El **indicio del paralelismo** y sus cuatro condiciones | **Criterio propio** |
| La separación **restringe / informa** y los cuatro cuadrantes | **Criterio propio** |
| El tratamiento del **adjetivo con dominio cerrado** y sus tres afirmaciones arrastradas | **Criterio propio** |
| La clasificación AD-1 / AD-2 / AD-3 | **Criterio propio** |
| La pasada **P13**, la **prueba de las dos anclas**, la **prueba de la negación**, la **prueba de la supresión de premisa** y la cota de señales | **Criterio propio** |
| Los **rótulos** `Letra`, `Intención`, `Conjetura`, `Hallazgo`, `Pregunta para el autor` y la **frase de residuo** | **Recibidos** de `Knowledge-Deduccion-De-Reglas-De-Negocio.md` §3.2 y M-3. **Este documento no crea ningún rótulo nuevo**: es una decisión, y está fundada en §7.1 |
| Las **ocho señales** de §8 | **Criterio propio** en su formulación y en su prueba. Seis de las candidatas fueron aportadas con el encargo; dos son de este documento, y está dicho cuáles |
| Las **cuatro tesis T-1 a T-4** (§10) y su formulación | **Recibidas** del autor del enunciado, citadas. **Propios** son los veredictos, su fundamentación y los límites con que se aceptan |
| Los **tres frenos** a la explosión combinatoria —apertura selectiva, propagación en cadena desde la casilla forzada, distinguir la reafirmación que triangula de la que adorna— | **Recibidos como propuesta** con el encargo. **Propias** son la formulación de la apertura como **cosecha** y no como búsqueda (§12.1), la lista cerrada de nueve entradas (§12.2), los **compromisos** como mecanismo de compatibilidad (§12.3), el orden de resolución con **desempate determinista** (§13.3), el descarte con causa (§13.4) y el tratamiento de los ciclos (§13.5) |
| La **escalera de tres diagnósticos** —ambigüedad de expresión, incompletitud, contradicción—, su orden y la prueba *«¿puedo construir un caso donde las dos sean verdaderas a la vez?»* | **Recibidas** con el refinamiento del encargo, y así se declaran. **Propias** son la prueba E1 como peldaño con procedimiento, la obligación de declarar el descarte de los peldaños anteriores, y la integración con los ciclos |
| El veredicto sobre **unificar con I-08** (§13.7) y su fundamento por enumerabilidad | **Criterio propio** |
| La **triangulación** como operación, las **cinco formas de reafirmación** (§11.2) y la **prueba de la discriminación** con sus tres resultados (§11.3) | **Criterio propio**, sobre la tesis T-2 recibida |
| La **reformulación de I-07** y el agregado a **I-06** | **Criterio propio**, redactados como parche en §15.4 |
| El **caso testigo** de la actividad sin lotes y el caso de las tres formulaciones de T-2 | **Observados**, entregados con el encargo. No son invento de este documento |
| Todos los ejemplos, salvo el párrafo de la estancia y los dos casos observados | **Propios**, inventados para este documento |

### 0.3 Notación

Se hereda la de `02` §0.4 y la de `03` §0.2. Se agregan tres marcas, y nada más:

| Marca | Significado |
| --- | --- |
| `AD-nn` | **Afirmación distribuida.** Identificador de una proposición producida por la pasada de recomposición. No es un fragmento del paso 1: es un producto con ficha (§7.2) |
| `⟂` | **Eje de contraste.** Se escribe entre los dos polos: `central ⟂ rurales`. Marca que dos modificadores fueron leídos como los dos extremos de un mismo eje (§2) |
| `⊂ …` | **Conjunto de referencia.** Se anota pegado al modificador: `central ⊂ instalaciones`. Es el conjunto sobre el cual el modificador recorta, que **no siempre es la extensión del núcleo** (§1) |

| `⟪ … ⟫` | **Entrada del registro de lecturas abiertas.** Encierra el identificador del fragmento cuyas lecturas quedaron abiertas: `⟪ O2.3 ⟫` (§12.3) |
| `≡` | **Vínculo de reafirmación.** Une dos formulaciones del mismo concepto: `O2.3 ≡ O3.1` (§11) |
| `L-a`, `L-b` | Las lecturas de una entrada abierta. El techo son dos; una tercera se justifica por escrito |

Y una convención de lectura para toda la Parte I: cuando se dice que un modificador **restringe**, se
dice siempre *sobre qué conjunto*. «Restringe» a secas es la formulación que produjo el defecto 1 y
está prohibida en las fichas.

---

## Parte I — Modificadores

## 1. El ámbito del conjunto de contraste

### 1.1 El error, en el caso que lo produjo

El indicio 4 de `02` §4.3 dice, textualmente:

> «Nombrá, en el texto o en el dominio, **al menos un ejemplar** del que el modificador distinga. No
> podés nombrarlo → **describe**. Podés → **restringe**.»

La formulación es correcta y no hay que tocarla. Lo que falta es **decir dentro de qué buscar**, y sin
esa indicación el analista completó el hueco con lo más cercano: *un ejemplar del mismo sustantivo que
el adjetivo modifica*. Es decir, buscó «otro casco». Y no hay otro casco, así que concluyó «describe».

El error no fue de razonamiento: fue de **alcance de la búsqueda**, y tiene dos mitades.

1. **Mitad referencial.** Un modificador no recorta necesariamente sobre la extensión de su núcleo.
   Recorta sobre **el conjunto que el discurso pone a disposición**, que puede ser más amplio que el
   núcleo. «Central» no separa cascos de cascos: separa **una instalación de las otras instalaciones**.
2. **Mitad textual.** El ejemplar de contraste puede no estar en el sintagma ni en la oración: acá
   estaba a nueve palabras de distancia, en el otro miembro coordinado («varios puestos rurales»), y
   el conjunto que los reúne estaba en la **oración siguiente** («son instalaciones»).

De ahí que hagan falta **dos ejes** y un orden de recorrido para cada uno.

### 1.2 Los dos ejes: sobre qué conjunto, y en qué parte del texto

**Eje referencial — el conjunto de referencia.** Se sube desde el núcleo hasta el primer conjunto que
tenga **más de un miembro presente en el texto**:

| Nivel | Conjunto | Cómo se lo encuentra | Ejemplo propio |
| --- | --- | --- | --- |
| **N1** | La **extensión del núcleo** | Otros ejemplares del mismo sustantivo | «el turno **nocturno**» ⊂ turnos, si el texto nombra el diurno |
| **N2** | Los **núcleos coordinados** con él bajo el mismo predicado | El «y», el «como», la yuxtaposición de la misma oración | «la sala **de partos** y el pabellón **de aislamiento**» ⊂ dependencias, aunque la palabra no esté todavía |
| **N3** | El **hiperónimo declarado por el texto** | Una oración que dice «X e Y son Z», «ambos constituyen Z», «unos y otros son Z» | «son **instalaciones**» |
| **N4** | La **categoría del dominio**, no declarada en el texto | Conocimiento del negocio | «sitios de la estancia» |

**La regla del eje referencial:** se sube hasta N3 como máximo para **decidir la etiqueta**. N4 no
decide: si el único conjunto disponible es N4, el modificador se resuelve con los indicios siguientes
y, si nada resuelve, se marca `?` con la pregunta para el autor *«¿hay otras cosas de esta clase que
el sistema deba distinguir?»*. Esto no es una cautela decorativa: **N4 es exactamente por donde entra
la fabulación**, y por eso está separado del resto por una línea dura.

**Eje textual — el ámbito de búsqueda.** Se recorre de adentro hacia afuera:

| Ámbito | Qué abarca | Qué se encuentra típicamente ahí |
| --- | --- | --- |
| **Á1 Sintagma** | El grupo nominal y sus coordinados inmediatos | «el acceso principal y el acceso de servicio» |
| **Á2 Oración** | La oración ortográfica entera, con todos sus miembros | **El paralelismo** (§2): «central ⟂ rurales» |
| **Á3 Párrafo** | Las demás oraciones del mismo párrafo | **El hiperónimo diferido** (N3): «son instalaciones» |
| **Á4 Documento** | Glosario, títulos, tablas, otros párrafos del mismo enunciado | Un término definido antes, una enumeración de tipos |
| **Á5 Dominio** | Lo que el analista sabe del negocio | **No decide.** Puede orientar la búsqueda; se declara si orientó |

### 1.3 Procedimiento de búsqueda del conjunto de contraste

Reemplaza la celda «Cómo decide» del indicio 4 de `02` §4.3, sin cambiar su formulación de fondo.

> **Paso A — Fijar el conjunto de referencia.** Subí por el eje referencial N1 → N2 → N3 y parate en
> el **primer nivel que tenga al menos dos miembros nombrados en el texto**. Ese es el conjunto.
> Anotalo pegado al modificador con `⊂`. Si llegaste a N4, no hay conjunto de referencia textual:
> anotá `⊂ ?` y seguí con el indicio 5.
>
> **Paso B — Buscar el ejemplar de contraste dentro de ese conjunto**, recorriendo Á1 → Á2 → Á3 → Á4
> y parando en el primero donde puedas **nombrar** un ejemplar (§1.5).
>
> **Paso C — Concluir.**
> Encontraste ejemplar → **restringe sobre ese conjunto**. Escribilo así: *«central restringe sobre
> instalaciones; ejemplar de contraste: los puestos rurales, Á2»*.
> Agotaste Á1 a Á4 sin encontrarlo → **no restringe**. Y acá **no se termina**: hay que correr la
> segunda pregunta de §3.2, porque «no restringe» no dice todavía si aporta o no.

**Lo que este procedimiento cuesta.** Tres lecturas: el sintagma, la oración, el párrafo. La cuarta
—el documento— sólo si las tres anteriores fallaron. Es caro comparado con mirar la coma, y es barato
comparado con el defecto que evita: en el caso observado, la búsqueda correcta termina en **Á2**, o
sea en la misma oración, nueve palabras más allá.

### 1.4 La regla del ámbito agotado, y el criterio de corte de la búsqueda

Ésta es la corrección del defecto 1, y conviene enunciarla sola porque es la que cambia resultados.

> **Regla del ámbito agotado.** El indicio del conjunto de contraste **sólo concluye «no restringe»
> después de recorrer Á1 a Á4 sobre el conjunto de referencia fijado en el paso A.** Una búsqueda
> parcial que no encuentra contraste **no concluye nada**: no autoriza «describe», y el indicio pasa
> el turno al siguiente.

La asimetría es deliberada y es la misma de siempre: **encontrar prueba; no encontrar sólo prueba que
no buscaste bien**. Un ejemplar hallado en Á3 es un hecho; la ausencia de ejemplar es un hecho sólo si
el barrido fue completo, y el barrido completo es el que casi nadie hace.

**Criterio de corte de la búsqueda.** Se deja de buscar cuando pasa lo primero de estas tres:

1. **Aparece un ejemplar nombrable** → concluye, y se anota en qué ámbito apareció.
2. **Se agotó Á4** → concluye «no restringe», y se anota `ámbito agotado: Á4`, que es la constancia de
   que el barrido fue completo. Sin esa constancia, la conclusión no se admite.
3. **El barrido llegó a Á5** → **no concluye**: se anota `⊂ ?` y se eleva la pregunta. Nunca se usa el
   conocimiento del dominio para afirmar que *no* hay contraste, que es la forma sigilosa de meter
   supuestos: «en una estancia hay un solo casco» es conocimiento del analista, no del texto.

### 1.5 Qué vale como ejemplar de contraste y qué no

El indicio exige **nombrar**, y eso hay que precisarlo, o «nombrar» se convierte en imaginar.

**Vale como ejemplar:**

- Un **grupo nominal del texto** que designe otra cosa del mismo conjunto de referencia: *los puestos
  rurales*, *la sucursal de barrio*, *el turno diurno*.
- Un **término del glosario** ya fijado por el análisis, aunque en este párrafo no aparezca.
- El **polo opuesto nombrado por el propio texto** en otra oración: si en algún lado dice
  «no permanente», *permanente* tiene contraste.

**No vale como ejemplar:**

- La **negación del adjetivo construida por el analista**: «*el casco no central*» no existe. Si eso
  contara, todo adjetivo restringiría y el indicio no discriminaría nada. Es la trampa principal.
- Un ejemplar **posible en el mundo** pero ausente del texto y del glosario: eso es Á5.
- Un ejemplar de **otro conjunto de referencia**: «el encargado» no contrasta con «central».
- Un ejemplar que el mismo párrafo declara **fuera de alcance**: si el texto dice que algo no se va a
  tratar, no funda un contraste operativo; se anota como `E` (alcance) y se sigue.

---

## 2. El indicio del paralelismo

### 2.1 Formulación

**Criterio propio.**

> **Indicio del paralelismo.** Cuando **dos núcleos coordinados bajo un mismo predicado** llevan cada
> uno **un modificador de la misma clase y en la misma posición**, y los dos modificadores se pueden
> leer como los **dos extremos de un eje nombrable**, entonces los dos **restringen**, y el conjunto
> de referencia es **la unión de los dos núcleos** —o el hiperónimo que los cubra, si el texto lo
> declara—.
>
> **Es unidireccional.** Su presencia concluye «restringe»; **su ausencia no prueba nada**.

En el caso: «un casco **central** … y varios puestos **rurales**». Dos núcleos coordinados bajo «se
establece», dos adjetivos pospuestos, y un eje que se nombra en una palabra: **centro / periferia**.
`central ⟂ rurales`, `⊂ instalaciones`. El indicio concluye en Á2, antes de que haga falta la oración
siguiente.

**Por qué funciona.** Coordinar dos grupos bajo un mismo verbo es una manera de decir que las dos
cosas son comparables: el autor las puso en la misma bolsa. Y si además le colgó a cada una un
modificador de la misma clase, el trabajo que hacen esos modificadores es **separar una de otra**, que
es la definición misma de restringir. La unicidad del núcleo —que hay un solo casco— es entonces
irrelevante: el recorte no ocurre entre cascos, ocurre entre los miembros de la bolsa.

### 2.2 Las cuatro condiciones que lo habilitan

Se exigen **las cuatro**. Con tres, el indicio no corre.

| # | Condición | Cómo se verifica | Si falla |
| --- | --- | --- | --- |
| **C1** | **Coordinación real** | Los dos núcleos están coordinados o yuxtapuestos bajo el mismo predicado, o bajo predicados con elipsis verbal (`02` fila 3) | No hay paralelismo: son dos sintagmas de oraciones distintas, y cada modificador se resuelve por su cuenta |
| **C2** | **Isomorfía de posición** | Los dos modificadores están del mismo lado de su núcleo: los dos pospuestos, o los dos antepuestos | No corre. Un antepuesto contra un pospuesto no hacen eje: la posición antepuesta ya tiene su propio valor (`02` indicio 1) |
| **C3** | **Misma clase de modificador** | Adjetivo contra adjetivo, complemento preposicional contra complemento preposicional, relativa contra relativa | No corre. Un adjetivo contra una relativa pueden estar diciendo cosas de rango distinto |
| **C4** | **Eje nombrable** | Se puede nombrar en **una palabra o una pareja** lo que los opone: centro/periferia, alta/baja, interno/externo, permanente/transitorio, propio/tercerizado | No corre, y es la condición que más veces falla. Si no podés nombrar el eje, lo que tenés son dos descripciones sueltas, no un contraste |

**C4 es la que hace el trabajo, y merece una prueba propia.**

> **Prueba del eje.** Escribí la frase *«se distinguen por su ____»* y completá con un sustantivo.
> *Se distinguen por su **ubicación*** → hay eje. Si sólo podés completar con «por sus
> características» o «por cómo son», **no hay eje**: retirá el indicio.

### 2.3 Cuándo no vale

Seis casos, con ejemplos propios de dominios variados. En todos, **que el paralelismo no valga no
significa que el modificador describa**: significa que este indicio no opina y hay que seguir bajando
por la jerarquía.

| # | Caso | Ejemplo | Por qué no vale |
| --- | --- | --- | --- |
| **NV-1** | **Coordinación de conveniencia** | «Se asignan un coordinador administrativo y dos vehículos livianos» | Los núcleos no son del mismo género: no hay bolsa común, no hay de dónde recortar. Falla C4 |
| **NV-2** | **Modificadores del mismo polo** | «Se habilitan el acceso principal y la rampa principal» | El mismo adjetivo en los dos: no se oponen entre sí. El contraste de *principal*, si existe, está afuera, y se lo busca con §1.3 |
| **NV-3** | **Ejes distintos** | «Se transportan residuos sólidos y agua potable» | *Sólido* opone a líquido; *potable*, a no potable. Cada uno restringe, pero sobre **ejes diferentes**, y no son dos polos de uno solo. Falla C4. Los dos siguen restringiendo, cada uno por su cuenta |
| **NV-4** | **Paralelismo sólo tipográfico** | Dos viñetas alineadas: «• turnos matutinos» / «• turnos con recargo» | El formato alinea, la sintaxis no coordina bajo un predicado. Falla C1. Además las clases difieren: adjetivo contra complemento (C3) |
| **NV-5** | **Uno de los dos es argumento** | «Se convoca al jefe de turno y al inspector externo» | *De turno* satura la casilla de *jefe*: no es modificador, es argumento (filtro de `02` §4.3). Falla C3, y el filtro lo habría sacado antes |
| **NV-6** | **Coordinación de más de dos con uno sin modificador** | «Se registran las bajas voluntarias, las bajas por sanción y las bajas» | El miembro sin modificador delata que la lista no es una partición: probablemente hay un error de redacción o una categoría residual. Se marca `!` y se eleva; el paralelismo no se aplica sobre una serie rota |

### 2.4 Dónde entra en la jerarquía

**Antes de la unicidad referencial, y por eso mismo.** La unicidad —indicio 3 de `02` §4.3— fue la que
cerró el caso en falso: «el casco es único → describe». El paralelismo tiene que poder ganarle, porque
la unicidad del **núcleo** es compatible con la restricción sobre un conjunto **más amplio**.

Se propone insertarlo como **indicio 2-bis**, sin renumerar los demás. Dos razones, y la segunda pesa
más que la estética:

1. El orden por nombre ya está escrito en prosa en `02` §3.2 y en la hoja de bolsillo de `03`:
   renumerar obliga a tocar tres lugares más y a revisar cada referencia cruzada.
2. Los números de indicio **no se usan para rutear nada**: se usan para leer en orden. Un «2-bis» se
   lee en orden igual de bien, y deja el diff chico, que es lo que hace que un parche se aplique.

Y va acompañado de una **enmienda al indicio 3**, que es igual de importante:

> **Indicio 3, enmendado.** La unicidad referencial concluye «no restringe» **sólo si la unicidad se
> verifica sobre el conjunto de referencia fijado en el paso A del indicio 4**, no sobre la extensión
> del núcleo. Un referente único dentro de un conjunto de referencia que tiene otros miembros **sí se
> recorta de ellos**.

Con las dos enmiendas, el caso se resuelve en el indicio 2-bis y ni siquiera llega al 3.

---

## 3. Restringir no es informar: las dos preguntas y los cuatro cuadrantes

### 3.1 Por qué colapsarlas induce el error

`02` §4.3 entrega **una** salida binaria: *restringe* o *describe*. Y después, en el bloque «y no es
simétrico», aclara que «describe» no es inerte. La aclaración está bien escrita y **no alcanza**, por
una razón de palabras: *describir* es, en el uso corriente, lo que hace un epíteto. Quien lee
«describe» al lado de «no restringe» archiva el adjetivo y sigue. El documento dice lo contrario tres
líneas más abajo, pero la decisión ya se tomó.

El caso lo muestra limpio. «Central» **no reduce** el conjunto de cascos —hay uno— y sin embargo **no
es decorativo**: dice cuál de las instalaciones es la central, que es un dato del negocio que alguien
va a necesitar. Con una sola pregunta, esas dos verdades no entran juntas.

> **La corrección es de forma y de fondo a la vez: la salida de la jerarquía deja de ser una etiqueta
> y pasa a ser un par.** `(restringe?, informa?)`.

### 3.2 Las dos preguntas, con su prueba

**Pregunta 1 — ¿Restringe?** *¿Reduce la extensión del referente dentro de su conjunto de referencia?*

> **Prueba del conjunto.** Fijá el conjunto de referencia (paso A, §1.3). Sacá el modificador. ¿El
> grupo nominal designa **más miembros de ese conjunto** que con él? Sí → restringe. No → no
> restringe.

La prueba es la de la supresión de `02`, con la corrección que este documento aporta: **se corre sobre
el conjunto de referencia, no sobre la extensión del núcleo**. Ésa era la diferencia que faltaba, y es
la que hace que ahora sí concluya con adjetivos de una palabra, que era el límite declarado del
indicio 5.

**Pregunta 2 — ¿Informa?** *¿Aporta un hecho del negocio que no esté ya implicado por el núcleo, por
el glosario o por una afirmación anterior?*

> **Prueba de la pregunta contestada.** Escribí la pregunta del negocio que el modificador contesta:
> *«¿cuál de las instalaciones es la central?»*, *«¿qué cubre una beca completa?»*. Si podés
> escribirla y la respuesta **no estaba disponible sin el modificador**, informa.
>
> **Contraprueba obligatoria para decir que NO informa: nombrá dónde ya estaba.** Un modificador se
> declara no informativo **sólo si se puede señalar el lugar** —la definición del término en el
> glosario, o la afirmación previa— donde la propiedad ya estaba dicha. **Si no podés señalarlo, no es
> un epíteto: informa.**

Esa contraprueba es el candado contra el descarte, y es exactamente lo que faltaba. El documento
vigente confía en que el analista no descarte; acá se le exige **exhibir dónde** está la redundancia
que alega.

### 3.3 Los cuatro cuadrantes

| # | ¿Restringe? | ¿Informa? | Qué es | Marca en `02` | Letra en `03` | Destino |
| --- | --- | --- | --- | --- | --- | --- |
| **Q1** | **Sí** | **Sí** | **Restrictivo informativo.** Recorta, y además introduce la propiedad por la que recorta | `⟨C-restr⟩` **más** el hecho registrado aparte | `R`, o `R/A` si la propiedad es un dato de la cosa | Alcance de la afirmación **y** la propiedad al glosario como atributo nuevo |
| **Q2** | **Sí** | **No** | **Restrictivo por término ya definido.** Recorta usando una propiedad que el glosario o una regla anterior ya fijaron | `⟨C-restr⟩` | `R°` | Alcance. **No abre fila nueva** en el glosario: es segunda mención |
| **Q3** | **No** | **Sí** | **Predicativo no restrictivo.** No recorta y sin embargo afirma algo del negocio. **Es el caso «central» mal resuelto, y la puerta de entrada más frecuente a la afirmación distribuida** | **No** abre `C-restr`. Se registra como hecho propio colgado del término | `A`, o `R(estructura)` si lo que aporta es una atadura entre dos cosas del negocio | Glosario —si es una cualidad— o inventario de relaciones —si es una atadura—, **y candidato a §6** |
| **Q4** | **No** | **No** | **Epíteto.** Ni recorta ni aporta | Nada. Se queda con el término | `T°` sobre el fragmento entero | Nada, salvo la constancia de que se lo evaluó |

**Tres reglas de uso de la tabla, y las tres son antifraude.**

1. **Q4 se declara, no se supone.** Para poner Q4 hay que pasar la contraprueba de §3.2: nombrar dónde
   ya estaba la propiedad. Sin eso, el cuadrante es Q3.
2. **Q3 no es un cajón de descarte, es un cajón de producción.** Todo Q3 deja un hecho escrito en
   algún inventario. Un Q3 que no produjo ninguna línea es un Q4 mal declarado o un análisis
   incompleto.
3. **El cuadrante se escribe en la ficha.** No alcanza con la decisión: se anota `Q1`…`Q4` junto al
   modificador, porque es lo que permite auditar la pasada después. Un modificador sin cuadrante es lo
   mismo que un fragmento sin etiqueta: se pierde en silencio.

### 3.4 Un ejemplo por cuadrante

Ejemplos propios, de dominios distintos entre sí y distintos del caso.

> **Q1 — restringe e informa.** *«El personal **embarcado** percibe viático diario.»* Conjunto de
> referencia: el personal de la empresa, que el texto ya trató en bloque (N1, Á3). Contraste: el
> personal de tierra, nombrado dos párrafos antes. Restringe. ¿Informa? La condición de embarcado no
> estaba definida en ningún lado: sí. → `⟨C-restr⟩` + atributo nuevo *situación de revista* al
> glosario.
>
> **Q2 — restringe sin informar.** *«El afiliado **moroso** no accede a la cartilla.»* El glosario ya
> tiene *moroso* definido por una regla anterior —tres cuotas impagas—. Restringe sobre el conjunto de
> afiliados; no informa nada nuevo. → `⟨C-restr⟩`, `R°`. El valor de haberlo clasificado es negativo y
> es real: **evita abrir una segunda definición de moroso**, que es como nacen las inconsistencias.
>
> **Q3 — no restringe e informa.** *«La cámara **frigorífica** se ubica en el sector de despacho.»*
> Hay una sola cámara en todo el enunciado y ningún otro equipo con el que contrastar: no recorta.
> Pero *frigorífica* dice qué clase de cosa es, y eso manda: condiciona temperatura, mantenimiento y
> habilitación. → nada de `C-restr`; la cualidad va al glosario, pegada al término *cámara*. Y queda
> marcado como candidato de §6: si más adelante el texto habla de «los equipos», *frigorífica* se
> vuelve restrictiva retroactivamente.
>
> **Q4 — epíteto.** *«Se exige la firma **manuscrita** del interesado.»* — en un documento cuyo
> glosario ya dice «*firma*: trazo manuscrito del titular al pie del instrumento». La propiedad está
> nombrada en el lugar exacto, se exhibe, y el adjetivo no agrega. → `T°` sobre «la firma manuscrita
> del interesado», sin línea nueva. **Si el glosario no dijera eso, sería Q1**, porque en un mundo con
> firma digital el adjetivo recortaría.

Ese último par —el mismo adjetivo en Q4 o en Q1 según lo que diga el glosario— es la mejor prueba de
que las dos preguntas son independientes y de que **el cuadrante depende del documento, no del
adjetivo**.

### 3.5 El caso «central», resuelto

Con la maquinaria de §1, §2 y §3, y paso por paso, para que se vea dónde se destraba:

| Indicio | Resultado |
| --- | --- |
| Filtro argumento/adjunto | *Central* se le puede sacar a *casco* y el núcleo queda en pie: **entra** |
| 1 — posición | Pospuesto: **no concluye** (unidireccional) |
| 2 — determinante | «un»: indefinido, **no prueba nada** (ya corregido en `02` v1.1) |
| **2-bis — paralelismo** *(nuevo)* | C1 los dos núcleos coordinados bajo «se establece»: ✔. C2 los dos pospuestos: ✔. C3 adjetivo contra adjetivo: ✔. C4 eje nombrable, *ubicación*, centro/periferia: ✔. → **`central ⟂ rurales`, restringe**, ámbito Á2 |
| 3 — unicidad *(enmendado)* | No llega a correrse. Si se corriera: el casco es único **como casco**, pero **no como instalación**, y el conjunto de referencia es *instalaciones* → la unicidad no concluye |
| 4 — contraste *(con paso A y B)* | Confirma: conjunto de referencia N3 = *instalaciones*, declarado en la oración 3, Á3. Ejemplar: *los puestos*. **Restringe sobre instalaciones** |
| **Pregunta 2 — ¿informa?** | ¿Dónde estaba dicho antes que el casco es el central? En ningún lado: no se puede exhibir el lugar. → **informa** |
| **Cuadrante** | **Q1** |

**Veredicto corregido:** «central» es **Q1**, `⟨C-restr⟩ ⊂ instalaciones`, letra `R`, y aporta al
glosario el eje *ubicación: central / rural* sobre el término *instalación*. **No es `A` y nunca fue
un epíteto.**

Esto refuta tres cosas ya escritas, y los parches de §15 las nombran una por una: el ejemplo
«Adjetivo, no restrictivo» de `02` §4.3, el caso 6 del banco de pruebas de `03` §6, y la línea
«sin conjunto de contraste, describe: A» de la hoja de bolsillo de `03`.

---

## 4. El adjetivo con dominio cerrado

### 4.1 Qué es: declarar los valores contra asignar uno

> «El casco **es permanente o temporal**» no es «el casco **es central**».

La diferencia no es de grado: son dos operaciones distintas.

| | **Asignación** | **Dominio cerrado** |
| --- | --- | --- |
| Qué hace | Le pone **un valor** a un individuo o a una subclase | **Declara los valores posibles** de una propiedad de la clase |
| Sujeto | Un referente | La **clase**, genérica |
| Forma típica | «un casco central», «el casco es central» | «el casco es permanente **o** temporal», «los cascos se clasifican en permanentes y temporales» |
| Cómo se incumple | Si ese individuo no tiene el valor | Si **aparece un individuo con un valor que no está en la lista** |
| Qué produce | Un hecho, o un alcance | Un **atributo con dominio enumerado**, más las afirmaciones de §4.4 |

La consecuencia práctica es grande y conviene decirla sin rodeos: una asignación es un dato de una
fila; **un dominio cerrado es una decisión sobre la forma de una columna**, y sobre si esa columna es
una lista fija o una tabla que alguien va a administrar.

### 4.2 Cómo se reconoce: cinco señales

No hay que exigir las cinco. **Con la 1, la 2 y la 5 alcanza**; la 3 y la 4 confirman.

1. **Sujeto genérico o de clase.** «el casco», «un lote», «toda parcela», «los legajos» — sin referir
   a un individuo del caso. Si el sujeto es un referente concreto, es asignación.
2. **Disyunción de adjetivos bajo cópula o verbo de clasificación.** «es X o Y», «puede ser X, Y o Z»,
   «será de carácter X o Y», «se clasifican en X e Y», «reviste calidad de X o de Y».
3. **Incompatibilidad entre los valores** sobre un mismo individuo y en un mismo momento. Es la que
   separa el dominio cerrado de una simple lista de cualidades acumulables: «el envase es retornable y
   apilable» no es dominio cerrado, son dos atributos.
4. **Ausencia de sujeto obligado y de acto.** Nadie hace nada en la oración: no hay quién clasifique
   ni cuándo. Si lo hubiera —«el inspector clasifica el lote como X o Y»— hay además un acto, y eso va
   por su carril (`V`).
5. **Ausencia de consecuencia.** La oración no dice qué pasa con cada valor. Si lo dijera —«el
   permanente paga tasa plena y el temporal, media»— la oración es **una regla derivada** y el dominio
   cerrado es su presupuesto: se registran las dos cosas.

**Señal negativa fuerte:** la conjunción copulativa. «El beneficio es nominal **e** intransferible» son
dos atribuciones acumuladas, no un dominio. El dominio cerrado pide **disyunción**.

### 4.3 En qué se diferencia de la atribución, de la definición y de la cardinalidad

Tres desempates, porque los tres pares se confunden.

**Contra la atribución simple** (§4.1, tabla). La prueba rápida: *¿la oración me deja completar «los
valores posibles son: …»?* Si sí, dominio cerrado.

**Contra la definición** (`02` fila 15 y §3.5, que van al glosario y **no** al catálogo de reglas). La
prueba es la de la violación, P-3 de `02`, y **acá concluye distinto que en una definición**:

> Una definición no se puede incumplir: «se entiende por *parcela* la subdivisión catastral del lote»
> no tiene contraejemplo. Un dominio cerrado **sí lo tiene**: un casco que no sea ni permanente ni
> temporal viola la oración. → **el dominio cerrado es una afirmación**, de especie *restricción de
> dominio*, y va al catálogo además de al glosario.

Ésa es la diferencia operativa que justifica tratarlo aparte: con el criterio vigente se lo archivaba
como definición y se perdía una regla verificable.

**Contra la cardinalidad** (`C` en `03`). La cardinalidad cuenta *cuántos*; el dominio cerrado dice
*de qué clase*. «Hay a lo sumo dos cascos» es `C`. «El casco es permanente o temporal» es dominio. Se
confunden porque las dos suenan a restricción numérica: **el dominio cuenta valores de una propiedad,
no ejemplares de una cosa**.

### 4.4 Las tres afirmaciones que arrastra, y el tercer valor

Una predicación de dominio cerrado no dice una cosa: dice tres, y **tienen estatutos distintos**. Es
el punto más delicado del apartado.

| | Afirmación arrastrada | Enunciado | Rótulo | Por qué |
| --- | --- | --- | --- | --- |
| **D-1** | **Exhaustividad** | Todo casco tiene alguno de los valores; ninguno se queda sin valor | **`Letra`** | Está dicho: «el casco **es** permanente o temporal» afirma que es uno de los dos |
| **D-2** | **Exclusividad** | Ningún casco tiene dos valores a la vez | **`?`** hasta resolver | Depende de si el «o» es inclusivo o exclusivo. Se resuelve con `02` §3.3, y si no desempata se pregunta |
| **D-3** | **Clausura** | No hay un tercer valor | **`Intención`**, salvo marca explícita | El texto enumera; enumerar **no es** declarar que no hay más. Es la trampa del apartado |

**La clausura es la que hay que tratar con cuidado, y ésta es la regla:**

> **Regla de la clausura.** La clausura se registra como `Letra` **sólo si el texto la marca**:
> «únicamente», «sólo puede ser», «se clasifican en **dos** categorías», «no se admiten otras». Sin
> marca, sale como `Intención` **y con `Pregunta para el autor` obligatoria**: *¿la lista de valores
> es cerrada?*

Es la misma disciplina que `02` fila 10 ya impone a las enumeraciones —«registrar siempre si la lista
es cerrada o abierta: la lista abierta es un hueco»—, aplicada a los valores de un atributo en lugar
de a los ítems de una lista.

**¿Y si aparece un tercer valor?** Tres escenarios, tres respuestas distintas, y ninguna es corregir la
fuente:

1. **Aparece en el mismo documento.** Es una **inconsistencia de la fuente**. No se arbitra: se declara
   el conflicto entre los dos lugares, con las dos citas, y se eleva. Es lo que manda el régimen de
   pesos de evidencia de `Knowledge-Deduccion-De-Reglas-De-Negocio.md` §3.3.
2. **Aparece en el código del autor o en un caso de uso.** Es evidencia de intención de peso menor que
   la letra pero real: se registra como `Hallazgo sobre el código` y se eleva. El hallazgo típico es
   que la clausura era del analista, no del autor.
3. **Aparece después, en el negocio.** Entonces la clausura era una lectura, y se cumplió lo que la
   regla de arriba anticipaba. El daño depende de si se registró como `Intención` con pregunta —daño
   cero, la pregunta estaba hecha— o como `Letra` —daño real, y evitable—. **Ésa es toda la razón por
   la que D-3 no puede salir como `Letra`.**

### 4.5 Etiqueta, marca y destino

| Aspecto | Resolución |
| --- | --- |
| **¿Corta?** (`02`) | **NO.** La disyunción no corta (fila 7). Es **una** afirmación |
| **Especie** | *Restricción de dominio* — pasa P-3, a diferencia de la definición |
| **Etiqueta** (`03`) | **`A(dominio)`** — la letra es `A`, atributo, con la nota de hasta tres palabras que `03` §0.2 ya admite. **No se crea una novena letra**, y es deliberado: la nota no rutea, la letra sí, y el fragmento tiene que llegar a la tabla de términos y atributos, que es donde vive una columna con sus valores |
| **Qué registra** | Un atributo con **dominio enumerado**: `instalación.permanencia ∈ {permanente, temporal}` |
| **Qué produce además** | D-1 al catálogo como afirmación; D-2 al inventario de ambigüedades si el «o» no se resolvió; D-3 como `Intención` más pregunta obligatoria |
| **Fila nueva en `02`** | **Fila 39**, redactada en §15.1 |

---

## Parte II — La afirmación distribuida

## 5. Caracterización del fenómeno

### 5.1 El caso, y qué afirmación se pierde

Las dos oraciones que importan:

> O2: «En el mismo acto se establece **un casco central** … y **varios puestos rurales** …»
> O3: «**Tanto el casco como el puesto son instalaciones** …»

Y la afirmación verdadera del negocio que ninguna de las dos contiene:

> **AD:** *La instalación central de la unidad productiva es el casco; las periféricas son los
> puestos.*

Ni O2 la dice —O2 no menciona instalaciones— ni O3 la dice —O3 no menciona ni centralidad ni
periferia—. Está **entre** las dos, y el procedimiento que etiqueta fragmento por fragmento no tiene
ningún paso en el que pueda aparecer.

### 5.2 El aparato disponible, candidato por candidato

Todos los nombres van con el estatuto de §0.2: tradición enunciada con mis palabras, sin cotejo.

| Candidato | Qué describe | ¿Describe **este** caso? |
| --- | --- | --- |
| **Cohesión** | Los recursos de superficie que atan una oración con otra: referencia, elipsis, conectores, recurrencia léxica, **hiperonimia** | **Sí, parcialmente.** Describe **el rastro**: la repetición de «casco» y «puesto» en O3 y la aparición del hiperónimo «instalaciones». Es lo que el analista puede **señalar con el dedo**. Pero la cohesión **no produce la afirmación**: sólo tiende el cable |
| **Coherencia** | La construcción global del sentido, que el lector arma | **Sí, y es inútil.** Es el nombre del resultado, no del mecanismo. Decir «la afirmación surge de la coherencia del párrafo» no le dice a nadie dónde mirar. Sirve para ubicar el fenómeno en el mapa y para nada más |
| **Progresión temática** | Cómo lo que una oración aporta como rema se convierte en tema de la siguiente | **Sí, y es la señal más útil.** O2 introduce casco y puestos como información nueva; O3 los toma **agrupados** como tema. Ese movimiento —dos remas que vuelven como un tema único— es **observable y enumerable**, y es la señal S-3 de §8 |
| **Isotopía** | La recurrencia de un rasgo semántico que da unidad de lectura | **Sí, en el trasfondo.** El rasgo /ubicación/ recorre «central», «rurales» y, en la cuarta oración, «se aloja». Es lo que hace que «central» y «rurales» se lean como un eje, y por eso fundamenta el indicio del paralelismo (§2). Como señal operativa es **blanda**: exige juicio semántico y no se puede contar |
| **Anáfora asociativa** | Un grupo nominal definido que se introduce sin antecedente porque un marco lo licencia: «entramos a la casa; **la cocina** estaba a oscuras» | **No.** Acá no hay nada asociativo: casco y puesto se **re-mencionan por su nombre**. Forzar el término escondería que el vínculo es explícito y verificable, que es justamente lo que lo hace admisible |
| **Presuposición** | Lo que el enunciado da por sentado para poder decir lo que dice | **No, para este caso.** Sí para otro: la cuarta oración presupone que existe una *administración* del casco y de los puestos que nadie describió. Eso es un **hueco**, no una afirmación distribuida: clase AD-3 |
| **Implicatura** | Lo que el hablante deja entender sin decirlo, y **puede cancelar sin contradecirse** | **No, y hay que excluirla expresamente.** Si el autor pudiera agregar «…aunque el casco no es la instalación central» sin contradecirse, la conclusión no sería del texto. Acá **no puede**: la agregaría contra su propia oración 2. Esa diferencia —cancelable o no— es la que la prueba de la negación (§6.3) convierte en filtro |
| **Marco de dominio** | El conocimiento de mundo que suministra roles y expectativas: qué es una estancia, qué hay en ella | **Sí, y es el peligro.** El marco explica por qué el lector acepta el hiperónimo sin resistencia. **Y no puede ser premisa**: si se admite como premisa, el análisis empieza a producir lo que el analista sabe de estancias y lo firma como intención del autor |

### 5.3 Veredicto: son dos cosas, y hay que separarlas

**El caso no es un fenómeno: son dos, encadenados, y confundirlos es lo que hace que la pasada sea
peligrosa o inútil según de qué lado se caiga.**

> **Primero, un fenómeno de cohesión léxica: la hiperonimia diferida.** La tercera oración introduce
> el hiperónimo —*instalaciones*— de dos hipónimos que la segunda ya había puesto en juego. El vínculo
> está **en la superficie del texto**, se señala con el dedo y se verifica sin interpretar nada. Su
> efecto es **crear retroactivamente un conjunto** al que los dos referentes pertenecen. Esto es lo que
> resuelve el defecto 1, y es puramente descriptivo.
>
> **Segundo, una operación lógica: la composición de premisas.** Con el conjunto ya creado, se combinan
> dos proposiciones que son letra del texto:
> P1 (O2) — *el casco es central y los puestos son rurales*;
> P2 (O3) — *casco y puesto son instalaciones*;
> y se sigue C — *la instalación central es el casco; las periféricas, los puestos*.
> Esto **no es un fenómeno del texto**: es un paso deductivo que hace el analista. La gramática
> suministra las premisas; no suministra la conclusión.

**Por qué importa la separación.** Porque los dos tienen **estatuto epistémico distinto y rótulo
distinto**: la hiperonimia diferida es observable y sostiene una cita; la composición es una inferencia
y **nunca puede salir como `Letra`**. Todo el aparato de §7 se apoya en esta línea. Cuando alguien
mezcla las dos, pasa una de dos cosas: o firma inferencias como si fueran texto —fabulación—, o
desconfía de la inferencia y tira también el rastro cohesivo —y entonces pierde la afirmación, que es
donde estamos hoy—.

**Y una tercera cosa, que está afuera y tiene que quedar afuera:** el **marco de dominio**. Puede
guiar la búsqueda; no puede ser premisa. Se declara cuando guio.

### 5.4 Por qué el procedimiento actual no puede producirla

No es un olvido: es una consecuencia de su diseño, y por eso el defecto es estructural.

1. **La unidad de trabajo es el fragmento**, y el procedimiento sólo pregunta cosas *de* un fragmento:
   ¿tiene predicación?, ¿es autónomo?, ¿qué califica? Ninguna pregunta del procedimiento toma **dos**
   fragmentos como argumento.
2. **P10 pide residuo cero, que es cobertura, no relación.** «Todo tramo tiene exactamente un destino»
   garantiza que nada se perdió *del texto*; no dice nada de lo que hay entre los tramos. Y su
   redacción —«exactamente uno»— refuerza la partición: cada cosa en una caja.
3. **P11 pone una cota de atomización**, que es un freno contra producir de más. Un producto que **no
   sale de ninguna predicación** es exactamente lo que esa cota está diseñada para rechazar. Por eso
   P13 tiene que tener su **propia** cota, y no puede vivir bajo la de P11.
4. **El procedimiento lee de izquierda a derecha y el texto no se escribió así.** La definición llega
   después del uso, el hiperónimo después de los hipónimos, el alcance en la última oración. Cuando la
   oración 3 dice «son instalaciones», los fragmentos de la oración 2 **ya están etiquetados y
   cerrados**. Sin una pasada posterior, la información que llega tarde no alcanza a nadie.

El punto 4 es la razón de fondo, y conviene tenerla a mano: **la pasada de recomposición no agrega una
capacidad interpretativa; repara un desajuste entre el orden de lectura del procedimiento y el orden
de escritura del texto.** Enunciada así, es mucho más fácil ver hasta dónde está autorizada a llegar.

### 5.5 Las tres clases de afirmación distribuida

| Clase | Qué es | Mecanismo | De dónde salen las premisas | Rótulo de salida |
| --- | --- | --- | --- | --- |
| **AD-1** | **Recomposición referencial.** La afirmación **ya estaba** en un fragmento, pero era ilegible porque el referente se resolvía en otro | Anáfora, correferencia, elipsis | Del mismo texto, por restitución unívoca | **`Letra`** con `⟦ ⟧`. **No es producto de P13**: es una restitución que P7 debió hacer y no hizo. Se marca `!` y se corrige el fragmento |
| **AD-2** | **Composición de premisas.** La afirmación **no está** en ningún fragmento; se sigue de combinar dos o más que sí son letra | Cohesión léxica + deducción | Dos o más fragmentos, cada uno `Letra`, del mismo párrafo | **`Intención`**, con las anclas y la frase de residuo |
| **AD-3** | **Marco presupuesto.** El texto **supone** una regla, un acto o una entidad que no enunció | Presuposición, marco de dominio | **Al menos una premisa no está en el texto** | **`Conjetura`** + **`Pregunta para el autor`** obligatoria. **Nunca** entra como afirmación |

**AD-1 es la trampa de medición.** Es lo más fácil de producir y lo que más infla el resultado de una
pasada de recomposición, y no es un hallazgo: es deuda del paso anterior. Si P13 devuelve muchos AD-1,
lo que hay que arreglar es P7, no celebrar la pasada.

**AD-3 es el caso de FU-10 de `02` §6.2**, la regla general implícita que delata una concesiva, ya
tratada allí con la resolución correcta: *«el analista no tiene autoridad para enunciar la regla que el
autor calló»*. Este documento no la cambia; le pone nombre, la ubica en la misma familia y confirma su
rótulo.

---

## 6. La pasada de recomposición (P13)

> **Corre última.** P13 va después de **P12, sintonización** (Parte III), y la razón es de fondo: una
> premisa con dos lecturas vivas no es una premisa. Todo lo que sigue supone que cada fragmento que
> se va a usar como premisa **tiene una sola lectura**, sea porque nunca estuvo en duda, sea porque
> P12 la fijó y anotó qué la fijó.

### 6.1 Qué se sostiene y qué se refuta de la propuesta

La propuesta recibida es:

> *terminado el etiquetado, se lee el párrafo entero de corrido y se pregunta qué dice el párrafo que
> no dice ninguna de sus oraciones.*

**Se sostiene el lugar y se refuta la formulación.**

**Lo que se sostiene.** Que hace falta una pasada **después** del etiquetado y **sobre el párrafo
entero**: §5.4 muestra que ningún paso existente puede producir lo que ella produce, y que la causa es
estructural. El diagnóstico es correcto y la ubicación también.

**Lo que se refuta, y no es un detalle de redacción.** La pregunta *«¿qué dice el párrafo que no dice
ninguna de sus oraciones?»* es **abierta en las tres dimensiones en las que un procedimiento no puede
serlo**:

1. **No dice dónde mirar.** El analista mira donde su atención cae, que es donde su conocimiento del
   dominio le sugiere algo. O sea: la pasada queda dirigida por el marco, que es justamente lo que §5.3
   prohíbe como premisa.
2. **No dice cuándo parar.** Siempre se puede encontrar una cosa más que el párrafo «dice». Sin
   criterio de corte, la pasada termina cuando el analista se cansa, y eso significa que **el resultado
   depende de la energía disponible**, no del texto.
3. **No dice qué se admite.** Sin prueba de admisión, la diferencia entre una deducción y una
   ocurrencia la pone el buen criterio de quien la corre. Dos analistas honestos divergen —que es
   exactamente el reproche que `02` §1.2 le hace a «sin pérdida de sentido» en su falla F4—.

Es el mismo defecto que el documento hermano ya diagnosticó una vez, aparecido de nuevo un nivel más
arriba. La corrección tiene que ser la misma clase de corrección: **cerrar la pregunta**.

**Lo que se propone en su lugar.** Una pasada que es:

- **dirigida** — no se lee buscando, se **barren señales** de una lista cerrada (§8);
- **acotada** — el producto no puede superar la cantidad de señales detectadas;
- **cerrada** — toda candidata pasa una prueba de admisión de cinco condiciones (§6.3);
- **rotulada** — su producto nunca es `Letra` (§7);
- **contable** — la pasada cierra con una cuenta de tres números, como la recuenta del `?` de `03` §5.

### 6.2 El procedimiento, en ocho pasos

> **P13 — Recomposición.** Corre **después de P11** y **no modifica el corte**.

**P13.0 — Precondición.** P10 (residuo cero) y P11 (criterio de corte) cerrados. Si la pasada descubre
un corte mal hecho, **no vuelve atrás**: lo marca `!` y sigue, igual que el paso 2 de `03` §2.4.
Volver rompe el ritmo y en la práctica hace abandonar la pasada.

**P13.1 — Una lectura de corrido.** Leer el párrafo entero, **una sola vez**, sin la hoja de fragmentos
a la vista. El propósito de la lectura no es encontrar nada: es **deshacer la partición** en la cabeza
antes de barrer. Una sola, y se pasa al barrido. Releer para mejorar es lo que convierte la pasada en
una sesión de interpretación.

**P13.2 — Barrido de señales.** Recorrer la lista cerrada de §8 y **marcar cada ocurrencia** en el
texto, sin producir nada todavía. Esto es inventario, no producción, igual que P2 con los conectores.
Al terminar, anotar el número de señales detectadas: **es la cota**.

**P13.3 — Escribir las premisas.** Por cada señal marcada, escribir las proposiciones que la señal
conecta, **cada una con su identificador de fragmento y su cita textual**. Si no se pueden escribir
**dos** premisas con ancla, la señal se descarta ahí mismo y se anota como descartada. La mayoría de
las señales muere acá, y está bien que así sea.

**P13.4 — Escribir la conclusión.** Una sola oración, con los términos del glosario ya fijados, sin
palabras del diseño —tabla, campo, entidad, pantalla— y sin cuantificadores que no estén en alguna
premisa.

**P13.5 — Correr la prueba de admisión.** Las cinco condiciones de §6.3. La candidata que falla una
condición **no se arregla**: se descarta, o baja de rótulo según lo que falló (§7.1).

**P13.6 — Fichar.** Ficha de §7.2, completa. Una candidata admitida sin ficha no existe: el producto de
esta pasada **es la ficha**, no la oración.

**P13.7 — Enrutar.** Cada `AD-nn` admitida entra al paso 2 como un fragmento más, con su letra normal
—`R`, `A`, `R(estructura)`— y la nota `(AD)`, que no rutea. En el paso 4, su *Grado de certeza* es
**`inferencia`**, nunca `letra`.

**P13.8 — Cerrar con la cuenta.** Anotar tres números: `AD s señales / c candidatas / a admitidas`.
La cuenta es lo que hace auditable la pasada, y su valor está en las proporciones: muchas señales y
pocas admitidas es una pasada sana; pocas señales y muchas admitidas es una pasada que está
produciendo por fuera del barrido.

### 6.3 La prueba de admisión: cinco condiciones

Se exigen **las cinco**. La cuarta y la quinta son las que hacen el trabajo; las tres primeras son las
que hacen que la cuarta y la quinta se puedan correr.

| # | Condición | Cómo se verifica | Qué evita |
| --- | --- | --- | --- |
| **A1** | **Dos anclas** | La conclusión se apoya en **al menos dos fragmentos distintos**, cada uno citable textualmente y con su identificador | Con una sola ancla no hay nada distribuido: o ya estaba en el fragmento —y es un error de etiquetado— o la pusiste vos |
| **A2** | **Premisas de letra y de lectura única** | Cada premisa es texto de la fuente, o texto con `⟦ ⟧` de restitución **unívoca**. **Ninguna premisa puede ser `Intención`, `Conjetura` ni conocimiento de dominio.** Y ninguna puede ser un fragmento con **entrada abierta** en el registro de §12: si P12 no la cerró, no se compone sobre ella. Si P12 la cerró, se cita también **qué la fijó** | Las cadenas. Es la prohibición de componer sobre lo compuesto: sin ella, el error se multiplica en dos pasos y se vuelve irrastreable |
| **A3** | **Vecindad** | Las premisas están **en el mismo párrafo**, o una de ellas es una definición explícita de otro lugar del documento **y se la cita con su ubicación** | Que se combinen dos oraciones cualesquiera de un enunciado de cuarenta páginas, que es donde el número de combinaciones explota y todo «se sigue» de algo |
| **A4** | **Supresión de premisa** | Borrá cada premisa, una por vez. **La conclusión tiene que caerse con cada una.** Si sobrevive al borrado de alguna, esa premisa no era premisa | Las conclusiones que ya estaban en un fragmento —no son distribuidas— y las que vienen de afuera con una premisa de adorno para disimular |
| **A5** | **Negación** | Escribí la oración que **negaría** la conclusión y verificá que **contradice** el párrafo. Si el autor pudiera agregarla sin contradecirse, la conclusión no es del texto | **Las implicaturas.** Es el filtro conceptual del método: lo cancelable no entra (§5.2). Es además la prueba que un agente puede correr sin juicio de dominio |

**A4 y A5 en el caso.**

> **A4.** Sin O2 —sin «central» y «rurales»— la conclusión *la instalación central es el casco* no se
> puede formular: no queda quién sea central. Sin O3 —sin «son instalaciones»— tampoco: no queda el
> conjunto del que la conclusión habla. **Las dos son necesarias.** ✔
>
> **A5.** Negación: *«la instalación central de la estancia no es el casco»*. Puesta en el párrafo,
> contradice de frente a O2 leída junto con O3. El autor no podría agregarla sin corregirse. ✔

Y un contraejemplo, para ver la prueba rechazar:

> **Candidata rechazada.** *«Cada instalación tiene exactamente un responsable.»* Premisas alegadas:
> «a cargo de un Administrador» (O2) y «se puede conocer el nombre del encargado» (O2).
> **A1** ✔ dos tramos… pero **A4 falla**: la conclusión tiene «exactamente uno», y borrando cualquiera
> de las dos premisas el «exactamente» sigue sin apoyarse en nada, porque **no estaba en ninguna**.
> **A5 falla también**: «una instalación puede tener dos responsables» no contradice nada de lo
> escrito. → **Rechazada como AD-2.** Lo que sí sale es otra cosa, más chica y verdadera: *las dos
> clases de instalación tienen un responsable, y el texto los nombra distinto* —`Intención`—, más una
> `Pregunta para el autor`: *¿Administrador y encargado son dos roles o dos nombres del mismo rol?*
> El «exactamente uno» era mío, no del autor.

### 6.4 El criterio de corte

Tres condiciones, y se termina cuando se cumplen las tres:

| # | Condición | Si falla |
| --- | --- | --- |
| 1 | **Barrido completo**: las ocho señales de §8 fueron recorridas, y cada una quedó anotada como *detectada* o *ausente*. Ninguna en blanco | Volver a P13.2 |
| 2 | **Dentro de la cota**: `candidatas admitidas ≤ señales detectadas`. Si se admitió más de una candidata por señal, hay que justificarlo por escrito en la ficha | Revisar: casi siempre hay una candidata que no salió de ninguna señal |
| 3 | **Una pasada**: se corrió una vez y se cerró con la cuenta de P13.8 | — |

**Sobre la tercera, que es la más importante y la que más se va a querer violar.** Una segunda pasada
sobre el mismo párrafo **no está prohibida, pero se declara**, y se declara porque significa una de dos
cosas, las dos accionables: o la lista de señales de §8 está incompleta —y entonces lo que corresponde
es proponer una señal nueva, con su análisis, no seguir buscando a mano—, o el analista está leyendo
las señales con elasticidad creciente, que es el comienzo de la sobreinterpretación. En ninguno de los
dos casos la respuesta es «una pasada más».

### 6.5 Lo que esta pasada no produce

Cinco cosas, y conviene tenerlas escritas porque son las cinco que van a aparecer:

1. **No produce reglas nuevas.** Produce afirmaciones candidatas, con rótulo de inferencia. Si son
   reglas, y de qué especie, lo decide el cuerpo metodológico, como siempre.
2. **No produce estructura de datos.** Ninguna conclusión puede contener las palabras tabla, campo,
   entidad, clave, pantalla ni relación de cardinalidad. Una conclusión con vocabulario de diseño es un
   anti-patrón declarado (SI-1).
3. **No corrige la fuente ni el corte.** Marca `!` y sigue.
4. **No resuelve ambigüedades.** Si una premisa admite dos lecturas, la candidata no se admite: se
   anota la ambigüedad, que ya tenía que estar anotada.
5. **No completa el modelo.** La ausencia de una afirmación esperable no es una afirmación distribuida:
   es un **hueco**, y el inventario de huecos ya existe.

---

## 7. Rótulo de salida y evidencia exigible

Este apartado es tan importante como la pasada misma. Una pasada de recomposición sin esto es una
licencia para fabular, y la licencia se otorga por omisión: basta con no decir con qué rótulo sale el
producto para que termine conviviendo con la letra.

### 7.1 Con qué rótulo sale cada clase

**No se crea ningún rótulo nuevo.** `Knowledge-Deduccion-De-Reglas-De-Negocio.md` §3.2 ya tiene los
siete y son una lista cerrada; agregar uno debilitaría la lista más de lo que ordenaría este producto.
Lo que se fija acá es **el mapeo**, que es lo que faltaba.

| Situación | Rótulo | Evidencia exigida |
| --- | --- | --- |
| **AD-2 que pasa las cinco condiciones** | **`Intención`** | Las dos citas con su identificador, la operación escrita, el resultado de A4 y de A5, y la **frase de residuo** |
| **AD-2 que falla A2** porque una premisa es conocimiento del dominio | **`Conjetura`** + **`Pregunta para el autor`** | La cita de la premisa que sí es letra, y **la declaración explícita de cuál premisa puse yo** |
| **AD-2 que falla A3** (premisas de párrafos lejanos) | **`Conjetura`**, o `Intención` **si se cita la definición remota con su ubicación exacta** | Las dos ubicaciones |
| **AD-2 que falla A4 o A5** | **Se descarta.** No baja de rótulo: se descarta y se anota como candidata rechazada, con cuál condición falló | La anotación de rechazo. Las rechazadas se conservan: son la prueba de que la pasada se corrió con criterio |
| **AD-1** (era anáfora) | **`Letra`** con `⟦ ⟧` | El fragmento corregido y un `!` sobre P7 |
| **AD-3** (marco presupuesto) | **`Conjetura`** + **`Pregunta para el autor`** obligatoria | La cita de lo que el texto sí dice, y la formulación de lo que presupone |
| **Cualquier producto de P13** | **Nunca `Letra`** | Verificable por búsqueda: toda oración bajo `Letra` lleva cita textual entre comillas |

**La frase de residuo** es obligatoria y viene del mecanismo M-3 del cuerpo metodológico, que la exige
verificable por búsqueda. Formulación tipo, y va **dentro del texto de la conclusión**, no en una nota
al pie:

> *«El enunciado no lo afirma en ninguna de sus oraciones: surge de combinar O2 y O3.»*

**La compuerta de precedencia** M-4 se aplica sin cambios: ninguna `AD` se enuncia sobre una ficha que
no tenga ya su `Letra` anclada. Dicho de otro modo: **primero está todo el texto repartido, después se
recompone.** Es la misma razón por la que P13 corre después de P10.

### 7.2 La ficha de afirmación distribuida

El producto de la pasada **es esta ficha**. Una conclusión sin ficha no entra en ningún lado.

```text
AD-nn
  conclusión   : <una oración, con términos del glosario, sin vocabulario de diseño>
  rótulo       : Intención | Conjetura                  ← nunca Letra
  clase        : AD-1 | AD-2 | AD-3
  señal        : <cuál de las ocho de §8 la disparó>    ← sin señal, no se produce
  premisas     : P1 ← <frag id> «cita textual»
                 P2 ← <frag id> «cita textual»
  operación    : <hiperonimia diferida + composición | paralelismo + composición | …>
  A4 supresión : sin P1 → <qué queda>;  sin P2 → <qué queda>   ← las dos deben caerse
  A5 negación  : «<la oración que la negaría>» contradice <frag id>
  marco usado  : <si el conocimiento de dominio orientó la búsqueda, cuál>  | ninguno
  residuo      : «El enunciado no lo afirma en ninguna oración: surge de combinar …»
  consecuencia : <a qué inventario va: glosario / relaciones / regla candidata / pregunta>
  certeza      : inferencia
```

Dos campos merecen defensa, porque son los que se van a querer saltear:

- **`A4 supresión` escrito, no pensado.** Hay que dejar por escrito qué queda al borrar cada premisa.
  Pensada, la prueba siempre da bien; escrita, se cae sola cuando la premisa era de adorno.
- **`marco usado`.** Declarar que el conocimiento del dominio **orientó la búsqueda** no invalida nada
  —orientar está permitido—, y en cambio deja el rastro de por dónde entraría un sesgo si la
  conclusión resulta discutida después.

### 7.3 La compuerta anti-fabulación: seis prohibiciones

Enumeradas para poder verificarlas de a una, sobre el entregable terminado.

| # | Prohibición | Cómo se verifica sobre el entregable |
| --- | --- | --- |
| **G1** | **Nada sin señal.** No se produce una candidata que no salga de una señal marcada en P13.2 | Toda ficha tiene el campo `señal` lleno con una de las ocho |
| **G2** | **No se compone sobre lo compuesto.** Ninguna premisa es una `AD` | Buscar `AD-` dentro del campo `premisas`: tiene que dar cero |
| **G3** | **El dominio no es premisa.** Puede orientar; se declara si orientó | Campo `marco usado` presente, aunque diga «ninguno» |
| **G4** | **No se cruza el párrafo sin cita.** | Los identificadores de las premisas pertenecen al mismo párrafo, o hay una ubicación explícita |
| **G5** | **No se sube de rótulo.** Nada salido de P13 aparece después bajo `Letra` | Toda oración bajo `Letra` tiene comillas y cita. La frase de residuo es buscable |
| **G6** | **Se conservan las rechazadas.** Las candidatas que no pasaron quedan anotadas con la condición que fallaron | La cuenta de P13.8 cierra: `candidatas = admitidas + rechazadas` |

**G6 es la que menos parece una compuerta y la que más lo es.** Una pasada que sólo muestra lo que
admitió es indistinguible de una pasada que admitió todo lo que se le ocurrió. Las rechazadas son la
evidencia de que hubo criterio.

### 7.4 Seis anti-patrones de sobreinterpretación

Con su **delator**, que es lo que permite encontrarlos leyendo el entregable sin rehacer el análisis.

| # | Anti-patrón | Ejemplo propio | Delator |
| --- | --- | --- | --- |
| **SI-1** | **El completador de modelo.** Concluye estructura de datos | «…luego las instalaciones se registran en una tabla con un campo tipo» | La conclusión contiene una palabra de diseño. Búsqueda mecánica: tabla, campo, entidad, clave, pantalla, relación |
| **SI-2** | **El generalizador.** De dos casos saca el universal | El texto nombra dos sucursales con caja; concluye «toda sucursal tiene caja» | Hay un cuantificador —todo, siempre, ninguno, exactamente— en la conclusión y **en ninguna premisa** |
| **SI-3** | **El importador de dominio.** Usa lo que sabe del negocio | «…y como toda flota tiene un taller de cabecera, el depósito central es el taller» | Alguna premisa **no se puede citar**. Lo atrapa A2, y si se coló, el campo `marco usado` está vacío |
| **SI-4** | **El encadenador.** Compone sobre lo que compuso | AD-7 usa como premisa a AD-3 | Lo atrapa G2 con una búsqueda de texto |
| **SI-5** | **El corrector encubierto.** Dice «lo que el autor quiso decir» | «…en realidad quiso decir que el encargado es el administrador del puesto» | La conclusión **contradice** un fragmento en vez de componerse con él. A5 al revés: la negación de la conclusión **coincide** con la letra |
| **SI-6** | **El inflador de intención.** Presenta una conjetura como intención | «El texto sugiere que…» sin anclas | Falta la frase de residuo, o el campo `premisas` tiene una sola línea. Lo atrapa A1 |

---

## 8. Señales textuales de afirmación distribuida

### 8.1 Las ocho que sostengo

Cada una con: **dónde mirar**, **qué produce** y **qué ruido tiene**. El ruido importa tanto como el
resto: una señal que se dispara en todos lados no dirige nada.

| # | Señal | Dónde mirar | Qué produce | Ruido |
| --- | --- | --- | --- | --- |
| **S-1** | **Hiperónimo diferido** — el género aparece **después** de sus especies | Oraciones cuyo predicado es una cópula clasificadora con un sustantivo genérico: «son», «constituyen», «se consideran» | **Un conjunto de referencia creado retroactivamente**, y con él todo lo que los modificadores anteriores recortaban sin que se viera. Es la que resuelve el caso | **Bajo.** La cópula clasificadora es rara y se ve a simple vista |
| **S-2** | **Modificadores en paralelo sobre núcleos coordinados** | Cualquier «y», «como», «tanto… como» que una dos grupos nominales, cada uno con adjetivo o complemento | **Un eje con sus dos polos** (§2), y la restricción de los dos modificadores | **Bajo si se exige C4** —el eje nombrable—. Alto si no se exige: casi toda coordinación tiene modificadores |
| **S-3** | **Coordinados que reaparecen agrupados** | «ambos», «unos y otros», «tanto… como», «en todos los casos», «éstos», «los mismos», y todo plural que recoja dos singulares anteriores | **Lo que se predica del grupo se predica de cada uno**, y —por contraste— **se vuelve visible lo que los diferencia**. Es el movimiento de progresión temática de §5.2 | **Medio.** Hay reagrupamientos que sólo abrevian |
| **S-4** | **Definición diferida** — el término se usa y se define después | Cualquier definición, glosa o aposición explicativa que llegue **después** de la primera mención del término | **La relectura de todo lo dicho antes del término bajo la definición**. Es la señal que justifica que P13 exista (§5.4, punto 4) | **Bajo.** Las definiciones son pocas y se detectan por su forma |
| **S-5** | **Correlativos y pares léxicos cerrados** | «por un lado… por el otro», «interno/externo», «titular/suplente», «alta/baja», «propio/de terceros» | **Una partición**: el texto está dividiendo un conjunto. Dispara además la revisión de exhaustividad y clausura de §4.4 | **Bajo**, y con un beneficio extra: casi siempre destapa un dominio cerrado no declarado |
| **S-6** | **Repetición léxica con variación** — la misma cosa nombrada dos veces con distinta envoltura. *Es la forma **RF-1** de §11.2 vista desde acá: la misma marca sirve para recomponer y para triangular* | Dos menciones del mismo referente donde la segunda **agrega o quita un modificador**: «puestos rurales» → «el puesto»; «unidad productiva» → «la estancia» | O un **sinónimo para el glosario**, o un **cambio de perspectiva** que agrega un rasgo | **Alto**, y por eso va con una condición dura: **sólo se marca si la variación agrega o quita un modificador**. La repetición idéntica no es señal |
| **S-7** | **Cierre de alcance diferido** — una oración tardía saca algo de alcance | «se contempla en un futuro análisis», «se define por separado», «queda fuera de esta etapa», «no es objeto de este documento» | **Reetiqueta hacia atrás**: los términos y actos nombrados antes y alcanzados por el cierre pasan a ser cosas sin comportamiento. Produce `E` sobre fragmentos ya etiquetados. *Señal propia de este documento* | **Muy bajo.** Las fórmulas son fijas y se pueden buscar |
| **S-8** | **Asimetría de detalle entre coordinados** — dos cosas coordinadas y sólo una recibe un dato | Un miembro con complemento, relativa o atributo, y el otro sin nada | O una **diferencia real** —y entonces hay una afirmación distribuida sobre en qué se distinguen— o una **omisión**, y entonces hay una pregunta para el autor. Las dos salidas sirven. *Señal propia de este documento* | **Medio.** La asimetría a veces es sólo economía de redacción |

**Las cuatro que disparan en el párrafo del caso**, para ver que la lista no es teórica: S-1 («son
instalaciones»), S-2 («central» ⟂ «rurales»), S-3 («Tanto el casco como el puesto»), S-7 («se
contempla en un futuro análisis del sistema»), y S-8 —el casco recibe un Administrador, el puesto un
encargado, y sólo del segundo se dice que se conoce su nombre—. Cinco de ocho sobre un párrafo de
cuatro oraciones: el barrido no es un trámite.

**Dos notas sobre el uso de la tabla.** Primera: las señales **se marcan, no se interpretan**, y ése es
todo el punto de separarlas del producto. Segunda: una señal detectada que no produce candidata es un
resultado perfectamente bueno y hay que anotarlo igual, porque la cuenta de P13.8 se lee en
proporciones.

### 8.2 Las tres que descarto como señal, y por qué

No alcanza con enumerar lo que sirve: hay que decir qué se evaluó y se dejó afuera, o la lista parece
arbitraria.

| Candidata | Por qué no entra |
| --- | --- |
| **Anáfora pronominal y correferencia** | Es una señal de **restitución pendiente**, no de afirmación distribuida. Si P7 se corrió bien, ya está resuelta y no produce nada nuevo; si no se corrió bien, lo que hay es un error de P7 (clase AD-1, §5.5). Meterla en la lista inflaría el resultado de la pasada con deuda del paso anterior, que es el peor de los sesgos posibles: **hace que la pasada parezca más productiva cuanto peor se hizo el trabajo previo** |
| **Presuposición** | Real y frecuente, pero lo que produce es AD-3 —una `Conjetura` y una pregunta—, no una afirmación. Su lugar es el **inventario de huecos**, que ya existe y ya tiene procedimiento. Duplicarla acá haría que el mismo hallazgo entre dos veces por dos puertas |
| **Implicatura conversacional** | **Se descarta por principio, y es la exclusión más importante de la lista.** Una implicatura es cancelable: el autor puede negarla sin contradecirse. Una conclusión que el autor podría negar sin corregirse **no es una afirmación de su texto**, es una expectativa del lector. La prueba A5 la rechaza automáticamente, y esa coincidencia entre el criterio conceptual y la prueba mecánica es lo que da confianza en las dos |

---

## 9. Ejemplo integrado

Párrafo propio, de otro dominio, escrito para ejercitar varias señales a la vez:

> «El Comité de Becas se reúne una vez por cuatrimestre y resuelve sobre los legajos presentados. En
> cada reunión se otorgan becas completas, que cubren la totalidad del arancel, y becas parciales.
> Unas y otras son beneficios de ayuda económica y se asientan en el registro de becarios. El
> beneficio es nominal e intransferible, y se asigna por un ciclo lectivo. La reglamentación de las
> revocaciones se dictará por separado.»

**Estado al terminar P11** (resumido; el corte no es el objeto del ejemplo): cinco oraciones, ocho
afirmaciones, cuatro calificadores, dos actos candidatos, dos huecos.

**P13.1.** Una lectura de corrido.

**P13.2 — Barrido.** Ocho señales recorridas:

| Señal | ¿Detectada? | Dónde |
| --- | --- | --- |
| S-1 hiperónimo diferido | **Sí** | «Unas y otras son **beneficios de ayuda económica**» (O3), después de *becas completas* y *parciales* (O2) |
| S-2 paralelismo | **Sí** | «becas **completas** … y becas **parciales**» (O2). Eje: *cobertura*. C1–C4 ✔ |
| S-3 coordinados reagrupados | **Sí** | «**Unas y otras**» (O3) |
| S-4 definición diferida | No | — |
| S-5 correlativos | No | *completa/parcial* es el mismo par de S-2; no se cuenta dos veces |
| S-6 repetición con variación | **Sí** | «beca» (O2, O4) → «**el beneficio**» (O4): la segunda mención cambia de envoltura |
| S-7 cierre de alcance diferido | **Sí** | «La reglamentación de las revocaciones **se dictará por separado**» (O5) |
| S-8 asimetría de detalle | **Sí** | Sólo *completas* lleva relativa —«que cubren la totalidad del arancel»—; *parciales* no lleva nada |

**Señales detectadas: 6. Cota: 6 candidatas admitidas como máximo.**

**P13.3 a P13.6 — Candidatas.**

> **AD-1** *(clase AD-2, señal S-2 + S-8)*
> **Conclusión:** la beca parcial cubre una fracción del arancel, menor que la totalidad.
> **Premisas:** P1 ← O2 «becas completas, **que cubren la totalidad del arancel**» · P2 ← O2 «y becas
> **parciales**», en paralelo con *completas* sobre el eje *cobertura*.
> **A4:** sin P1 no hay con qué contrastar *parcial*; sin P2 no hay a quién atribuirle la fracción.
> Las dos se caen. ✔
> **A5:** «hay becas parciales que cubren la totalidad del arancel» contradice el eje de O2. ✔
> **Rótulo:** `Intención`. **Residuo:** *«El texto no dice qué cubre la beca parcial: surge de
> oponerla a la completa en la misma oración.»*
> **Consecuencia:** atributo *cobertura* sobre el término *beca*, y **`Pregunta para el autor`**: ¿qué
> fracción, y quién la fija?

> **AD-2** *(clase AD-2, señal S-1 + S-3)*
> **Conclusión:** toda beca, sea completa o parcial, se asienta en el registro de becarios.
> **Premisas:** P1 ← O2, las dos clases de beca · P2 ← O3 «**Unas y otras** son beneficios … y **se
> asientan en el registro de becarios**».
> **A4:** sin P1 no se sabe a qué alcanza «unas y otras»; sin P2 no hay asiento. ✔
> **A5:** «hay becas que no se asientan» contradice O3. ✔
> **Rótulo:** `Intención`. **Consecuencia:** regla candidata de completitud, con su momento de
> verificación por resolver.
> *Nota: está cerca de ser `Letra`, y no lo es, porque «unas y otras» exige que el analista resuelva
> a qué recoge. Resuelto, la conclusión se sigue; la resolución es del analista, y por eso el rótulo.*

> **AD-3** *(clase AD-3, señal S-7)*
> **Conclusión:** la revocación es un acto previsto del negocio y **este enunciado no la regula**.
> **Premisas:** P1 ← O4 «**puede ser revocada**» · P2 ← O5 «la reglamentación de las revocaciones **se
> dictará por separado**».
> **A4** ✔, **A5** ✔ para la segunda mitad. Pero la primera mitad —que exista un acto con actor,
> disparador y efecto— **no está en el texto**: es marco.
> **Rótulo:** la parte de alcance sale como `E` sobre el fragmento de O4, ya etiquetado; el acto sale
> como **`Conjetura`** más **`Pregunta para el autor`**: *¿quién revoca, con qué causal y con qué
> efecto sobre el ciclo lectivo en curso?* **No entra ninguna afirmación.**

> **AD-4 — rechazada** *(señal S-6)*
> **Conclusión intentada:** *beneficio* y *beca* son el mismo término.
> **A4 falla:** la conclusión sobrevive al borrado de cualquiera de las dos menciones, porque no se
> apoya en las dos: se apoya en que yo leí que son lo mismo. → **Rechazada.** Lo que corresponde es
> una entrada de sinonimia en el glosario, marcada `?`, y la pregunta al autor. La señal S-6 hizo su
> trabajo: **disparó y no produjo**, que es su resultado más frecuente.

**Dominio cerrado, de paso** (§4): «El beneficio es nominal **e** intransferible» es **conjunción**:
dos atribuciones acumuladas, **no** dominio cerrado —señal negativa de §4.2—. Y las dos clases de beca
sí son un dominio candidato: `beca.cobertura ∈ {completa, parcial}`, con **D-1 `Letra`**, **D-2
exclusividad** resuelta —una beca no puede ser completa y parcial a la vez, por el eje—, y **D-3
clausura como `Intención`** más la pregunta *¿hay otras clases de beca?*, porque el texto no dice
«únicamente».

**P13.8 — Cuenta:** `AD 6 señales / 4 candidatas / 3 admitidas` —dos `Intención`, una `Conjetura` con
`E`— **más una rechazada conservada**. Dentro de la cota. Proporción sana: seis señales, tres
productos.

**Lo que este ejemplo no ejercita.** Corre P13 sobre un párrafo cuyo registro de lecturas abiertas
está vacío, y por eso no muestra la sintonización. El banco de §14 cubre eso, sobre el párrafo del
caso.

**Qué se habría perdido sin la pasada.** La cobertura de la beca parcial —que es un dato que el
software va a necesitar y que nadie escribió—, la completitud del asiento en el registro, la marca de
alcance sobre la revocación, y la pregunta por la clausura de las clases de beca. Cuatro cosas, de un
párrafo de cinco oraciones que el paso 1 ya había dado por analizado con residuo cero.
---

## Parte III — Lecturas múltiples y sintonización del conjunto

> **Cuándo corre.** La pasada de esta parte —**P12, sintonización**— corre **antes** que la de la
> Parte II —**P13, recomposición**—, porque componer premisas exige que cada premisa tenga **una sola
> lectura**. Se expone después porque reutiliza su aparato: los rótulos, la ficha con anclas y la
> compuerta anti-fabulación de §7 valen igual acá, y no se repiten.
>
> **Orden de corrida completo:** P0 … P11 (corte) → **P12 sintonización** → **P13 recomposición**.

---

## 10. Las cuatro tesis, evaluadas una por una

La ampliación del encargo no trae un indicio más: trae un cuestionamiento al algoritmo. Se la trata
tesis por tesis, con veredicto explícito, porque tres se aceptan y una se acepta a medias, y las
consecuencias son distintas en cada caso.

### 10.1 T-1 — La redundancia del autor es funcional

> «el uso del contraste para reafirmar o formar un concepto entrelazando todo el conjunto — el
> contraste para remarcar y darle redundancia».

**Veredicto: aceptada, con dos límites.**

**Por qué se acepta.** Un texto de negocio no se lee una vez ni se lee entero ni se lee con atención
pareja. Un autor que quiere que un concepto sobreviva a esa lectura lo dice más de una vez y de
maneras distintas: primero por su nombre, después por su género, después por su función, después por
oposición a otra cosa. Eso no es torpeza de redacción: es **la única defensa que tiene un texto contra
su propio lector**. Tratarlo como defecto es tratar como ruido a la parte del texto que fue puesta a
propósito.

Y hay una consecuencia que cambia el análisis, no sólo la actitud: si la redundancia es funcional,
entonces **las formulaciones repetidas no son intercambiables**. Cada una dice el mismo concepto desde
un lugar distinto, y **ese lugar es información**. La vaga y la precisa no son la misma afirmación con
distinta suerte: son dos vistas, y la vaga suele traer la intención mientras la precisa trae el
criterio operativo.

**Límite 1 — no toda repetición es funcional.** Alguna es estilo, alguna es copiar y pegar, alguna es
una versión vieja que quedó. Distinguirlas es un problema real y tiene criterio propio: §11.3.

**Límite 2 — que la redundancia sea funcional no vuelve consistente al texto.** Al contrario: la
redundancia **expone** las inconsistencias que un texto dicho una sola vez esconde. T-1 no es un
permiso para dejar de reportar: es un cambio en **qué** se reporta. Lo que se reporta no es que dos
formulaciones se parezcan; es que **no cierran entre sí**.

### 10.2 T-2 — La redundancia es lo que vuelve detectable la ambigüedad

> «el uso de la redundancia en sí mismo para generar puntos de discordia al introducir
> ambigüedades».

**Veredicto: aceptada, y es la tesis que más cambia el método.** Las otras tres cambian el
procedimiento; ésta cambia **qué clase de cosa es una reafirmación**: deja de ser un objeto que se
reporta y pasa a ser un **instrumento que se usa**.

El argumento es simple y es fuerte. Una afirmación dicha una sola vez y leída mal **no deja rastro**:
la lectura equivocada es internamente consistente y nada la contradice. Dicha dos veces, la lectura
equivocada de una de las dos **choca con la otra**, y el choque es observable. Es decir:

> **La reafirmación es el único mecanismo por el cual un texto puede señalar sus propias
> ambigüedades sin que nadie las haya buscado.**

De ahí la operación que este documento incorpora, y que llamo **triangulación**: cuando un fragmento
admite dos lecturas, se buscan las otras formulaciones del mismo concepto y se pregunta cuál de las
dos lecturas sobrevive a todas. La que sobrevive es la lectura; el resto se descarta **con causa
escrita**.

**El caso que la respalda**, y conviene leerlo despacio porque el error es instructivo: un mismo
concepto tenía tres formulaciones en el enunciado —una precisa en un caso de uso, una vaga en el
párrafo («coherente»), y una tercera implícita en el denominador de un indicador—. El analista tomó
**la vaga aislada**, la declaró defectuosa y propuso reemplazarla. Cruzando las tres, la intención del
autor salía sola.

**El error no fue ser literal: fue tratar la repetición como defecto en lugar de como instrumento.**
Y hay algo más, que le toca directamente al cuerpo metodológico: la entrada **I-06** de
`Knowledge-Deduccion-De-Reglas-De-Negocio.md` —la palabra no verificable, «coherente» entre ellas— ya
ordena lo correcto, *«se recupera la intención, no se propone un reemplazo»*, pero **no dice cómo se
recupera**. La triangulación es el procedimiento que le faltaba: **la intención de una palabra vaga se
recupera cruzándola con las otras formulaciones del mismo concepto**, no mirándola fijo.

### 10.3 T-3 — El algoritmo actual es el equivocado

> «no alcanza con una segmentación del texto o de una imagen, sino que falta tener una gama de
> interpretaciones lógicas de cada segmento y luego sintonizar todas las partes en conjunto».

**Veredicto: se acepta el diagnóstico y se refuta la forma literal del remedio. Y la corrección sale
más barata de lo que la tesis supone, por una razón que vale la pena ver.**

**Lo que se acepta.** Es cierto que el procedimiento asigna **una** lectura por fragmento y la decide
**localmente**. También es cierto que eso pierde información, y por la misma causa que el defecto 2:
la decisión se toma **antes** de que llegue la evidencia que la resolvería. Cuando P5 decide si una
relativa restringe, la oración que lo aclararía todavía no se leyó. Y hay una agravante que el
documento vigente no ve: la decisión no sólo se toma temprano, **se toma y se tira la alternativa**.
Al final de P11 no queda registro de qué otras lecturas estaban vivas.

**Lo que se refuta.** «Abrir una gama de interpretaciones de cada segmento» es inaplicable, y **no
principalmente por costo**. Tres lecturas por fragmento y quince fragmentos son catorce millones de
combinaciones, es cierto, y eso alcanzaría para descartarlo. Pero hay una objeción anterior y más
seria: **abrir lecturas donde el texto no es ambiguo es fabricar ambigüedad**. Casi todo fragmento
admite una lectura rebuscada si uno se empeña. Un procedimiento que obliga a enumerarlas convierte al
analista en el productor de las dudas que después va a resolver, y el resultado ya no habla del texto.

**Y acá está la parte barata, que es lo que hace la tesis adoptable.** El procedimiento vigente **ya
produce** la lista exacta de los lugares donde más de una lectura sobrevive. Los produce y los
descarta:

- cada `?` de la regla de la duda;
- cada `?` de la regla de cierre de la jerarquía de modificadores (indicio 8);
- cada disyunción que no se pudo rotular inclusiva o exclusiva (`02` §3.3);
- cada restitución que admitió dos lecturas (P-4, P7);
- y —esto no estaba marcado en ningún lado— **cada decisión tomada por un indicio derrotable**: la
  puntuación del autor (indicio 6), la consistencia interna (indicio 7), la regla del error barato.

> **La corrección, entonces, no es abrir lecturas: es dejar de tirarlas.** No hace falta un paso de
> búsqueda nuevo. Hace falta **guardar lo que el procedimiento ya descartaba** y darle una pasada que
> intente cerrarlo contra el resto del texto.

Eso tiene tres consecuencias buenas a la vez. **Primera:** la apertura es selectiva sin que nadie
tenga que decidir dónde abrir, porque la lista se **cosecha**, no se busca (§12). **Segunda:** la
cantidad de entradas abiertas queda acotada por la disciplina que P11 ya impone, no por un tope
inventado. **Tercera:** encaja con algo que el material ya tiene: `03` §5 define **la compuerta del
`?`** —«un `?` que un criterio en mano resuelve no es una pregunta para el autor: es un criterio no
aplicado»—. La sintonización es exactamente **la segunda compuerta del `?`**: la primera pregunta
*¿hay un criterio que lo resuelva?*; la segunda pregunta *¿hay otra parte del texto que lo resuelva?*.
Recién lo que sobrevive a las dos es una pregunta para el autor.

**Qué cambia en P0–P11: nada.** Ni un paso, ni una decisión de corte. Lo único que cambia es que los
`?` y las decisiones derrotables **se anotan en un registro en vez de irse directo al cuestionario**,
y que después de P11 corre una pasada más.

### 10.4 T-4 — Vale para cualquier texto, y el autor lo extiende a imágenes

**Veredicto: la arquitectura es general; las pruebas son generales con una condición; las señales no
portan. Y no está probado fuera del lenguaje, así que se enuncia como forma, no como método
disponible.**

| Capa | ¿Es del lenguaje o general? | Qué haría falta para portarla |
| --- | --- | --- |
| **La arquitectura** — segmentar, admitir más de una lectura donde hay señal, resolver el conjunto por consistencia mutua, y buscar la pieza faltante antes de declarar conflicto | **General.** No hay nada lingüístico en ella: es cómo se resuelve cualquier interpretación de un material segmentado con evidencia parcial | Nada. Es transportable tal cual |
| **Las pruebas** — discriminación (§11.3), supresión de premisa (A4), negación (A5), la escalera de diagnóstico (§13.6) | **Generales con una condición**: el material tiene que tener una noción de **compatibilidad** entre lecturas y una de **caso posible**. La negación además exige una noción de **contradicción**, que en una imagen no es nativa: dos etiquetas de regiones solapadas se contradicen sólo si alguien declaró que no pueden coexistir | Declarar explícitamente la relación de incompatibilidad. En lenguaje viene gratis; en otros materiales hay que escribirla |
| **Las señales** — las ocho de §8, las nueve de §12.2, las formas de reafirmación de §11.2 | **Específicas del español y de la prosa normativa.** Hiperónimo diferido, correlativos, determinantes: nada de eso existe fuera del lenguaje | Reconstruir la lista entera para el material nuevo. En imágenes, los análogos plausibles serían la **vecindad** —solapamiento o contigüidad en lugar de párrafo—, la **reafirmación** —la misma región vista en otra toma, otra escala u otra modalidad— y la **compatibilidad** entre etiquetas de regiones solapadas |

**Lo que no se afirma.** No probé nada de esto fuera del lenguaje. La correspondencia con la
segmentación de imágenes se enuncia como **forma compartida**, porque la pregunta se hizo y merece
respuesta, y queda como límite declarado (§16).

---

## 11. Reafirmación: adorno, triangulación, discordia

### 11.1 Qué cuenta como reafirmación

> **Reafirmación.** Dos o más formulaciones **del mismo concepto** en el mismo documento, con
> palabras o estructuras distintas, ninguna de las cuales es cita de la otra.

Hay que separarla de dos cosas con las que se confunde:

- **No es la segunda mención de un referente.** «El casco… el casco» nombra dos veces la misma cosa;
  eso es cohesión referencial y lo maneja la marca `°` de `03`. Una reafirmación no repite el
  **nombre**: repite el **contenido**.
- **No es una regla derivada.** «Todo lote tiene responsable» y «ningún lote queda sin responsable»
  son la misma afirmación reafirmada. «Todo lote tiene responsable» y «el responsable firma el parte»
  son dos afirmaciones encadenadas, no dos formulaciones de una.

**Prueba rápida de reafirmación:** *¿las dos formulaciones se podrían borrar la una a la otra sin que
el documento pierda un concepto?* Si sí, hablan del mismo concepto —y entonces vale la pena
compararlas—. Si al borrar una se pierde un concepto entero, no eran reafirmación.

### 11.2 Las cinco formas que se reconocen

Ejemplos propios salvo donde se indica el caso.

| # | Forma | Cómo se ve | Qué aporta al análisis |
| --- | --- | --- | --- |
| **RF-1** | **Léxica** | El mismo concepto con otra palabra: «unidad productiva» / «la estancia»; «beneficio» / «beca» | O sinonimia para el glosario, o **dos facetas** del mismo referente. Alta frecuencia, valor medio |
| **RF-2** | **Hiperonímica** | El género después de las especies: «tanto el casco como el puesto **son instalaciones**» | **Crea el conjunto** y por lo tanto reafirma que los dos miembros son comparables. Es la forma más productiva de todas |
| **RF-3** | **Estructural o correlativa** | Una estructura que repite la relación ya dicha: «tanto… como», «unas y otras», «en ambos casos», un paralelismo de modificadores | Reafirma **la relación**, no los términos. Sirve para fijar **alcances**: sobre quién distribuye qué |
| **RF-4** | **De ancla** | Una expresión que reafirma un ancla ya puesta en vez de introducir una nueva: «**en el mismo acto**», «en esa misma oportunidad», «dentro del mismo plazo» | Fija **momento** o **ámbito** por remisión. Es la forma que más veces se lee como si introdujera algo nuevo, y no lo hace |
| **RF-5** | **Derivada u operacional** | El concepto reaparece dentro de un cálculo, un indicador, una validación o un ejemplo numérico: el denominador de un índice, la guarda de un caso de uso | **La más precisa de todas y la que menos se mira.** Un cálculo no tolera vaguedad: obliga al autor a comprometerse con una lectura. Cuando una formulación vaga y una operacional hablan del mismo concepto, **la operacional casi siempre desempata** |

RF-5 merece la insistencia porque es la que faltó en el caso de T-2: había una formulación vaga
—«coherente»— y una operacional —el denominador de un indicador—, y el análisis trabajó sobre la vaga
sin mirar la otra.

### 11.3 La prueba de la discriminación y sus tres resultados

Ésta es la respuesta al problema de distinguir la reafirmación que triangula de la que sólo adorna.
**Criterio propio.**

> **Prueba de la discriminación.** Escribí las lecturas abiertas del fragmento A —dos, normalmente—.
> Poné al lado la reafirmación B. Preguntá, para cada lectura de A, si B puede ser verdadera a la vez.

| Resultado | Qué significa | Qué se hace |
| --- | --- | --- |
| **B es compatible con todas las lecturas de A** | **Adorno**, al menos para esta entrada. B repite sin comprometerse | No se usa. Se anota «B no discrimina» y se sigue. **No se reporta como defecto** |
| **B es compatible con una e incompatible con las demás** | **Triangula.** B es un instrumento | Se fija la lectura que sobrevive, con `fijada por: B`. Es la resolución más barata y más sólida que tiene este método |
| **B es incompatible con todas las lecturas de A** | **Discordia.** Las dos formulaciones no cierran bajo ninguna lectura | **Es el hallazgo.** Va a la escalera de diagnóstico de §13.6, que dirá si falta información o si hay contradicción |

**Prueba de apoyo, para el caso dudoso:** *borrá B del documento. ¿Muere alguna lectura de A?* Si no
muere ninguna, es adorno. Es la misma prueba de supresión de A4, aplicada a una reafirmación en vez de
a una premisa, y sirve para lo mismo: **separar lo que sostiene de lo que acompaña**.

**Una advertencia sobre el adorno.** «Adorno» acá significa **«no discrimina esta entrada»**, no
«sobra». La misma reafirmación puede ser adorno para una entrada y triangular otra. Por eso el
veredicto se anota **por entrada**, no por reafirmación, y por eso no se borra nada.

### 11.4 La reformulación de I-07, y lo que le faltaba a I-06

**I-07 vigente:** *«Regla que es copia débil de otra — si la prueba de A pasa siempre que pasa la de
B, sospechar»*, con la nota, ya buena, de que se usa como argumento de intención y no como motivo de
borrado.

**Qué está bien y qué está mal.** La nota está bien y hay que conservarla entera: ya dice que no se
borra y que la regla que existe dice algo **más** que su vecina. Lo que está mal es **el título y el
síntoma**, y en un catálogo que se recorre entrada por entrada eso decide qué se busca:

1. **El título nombra un defecto.** «Copia débil» dice que una de las dos sobra. Bajo T-1, ninguna
   sobra: son dos vistas del mismo concepto y **la vista es información**.
2. **El síntoma es demasiado angosto.** «Si la prueba de A pasa siempre que pasa la de B» detecta
   **subsunción entre reglas ya formalizadas**, que es un caso particular tardío. No detecta la
   reafirmación léxica, ni la hiperonímica, ni la de ancla, ni la operacional —que es la más útil—, y
   sobre todo **no detecta las reafirmaciones que todavía no son reglas**, que son la mayoría.
3. **Falta la mitad productiva.** El catálogo sabe **reportar** redundancia y no sabe **usarla**. La
   reafirmación que cierra no es un hallazgo: es un instrumento, y hoy no hay ninguna entrada que
   mande a usarla.

**Parche redactado, para §3.6 del cuerpo metodológico** (se aplica en §15.4):

> | **I-07** | **Reafirmaciones que no cierran entre sí** | Dos o más formulaciones del mismo concepto —léxica, hiperonímica, estructural, de ancla u operacional— cuyo **desacuerdo** no se resuelve bajo ninguna lectura. **El hallazgo es el desacuerdo, no la duplicación.** La subsunción de pruebas —«la de A pasa siempre que pasa la de B»— es **uno** de sus síntomas, no su definición. Toda discordancia sale con el **diagnóstico declarado** de la escalera: ambigüedad de expresión, incompletitud o contradicción |

Y el agregado a la nota que sigue a la tabla:

> **I-07 tiene dos salidas, y la primera no es un hallazgo.** Si las formulaciones **cierran**, la
> reafirmación es un **instrumento de desambiguación** y se usa: la lectura que sobrevive a todas las
> formulaciones es la lectura (triangulación, `04` §11.3). Si **no cierran**, recién ahí es hallazgo,
> y sale con su diagnóstico. Se conserva sin cambios lo ya escrito: nunca es motivo de borrado, y si
> una regla existe, dice algo **más** que su vecina.

**Y lo que le faltaba a I-06.** La entrada de la palabra no verificable ordena recuperar la intención y
no propone cómo. Se agrega una línea, no una entrada: *la intención de una palabra no verificable se
recupera **triangulando** con las otras formulaciones del mismo concepto —en especial con la
operacional, RF-5— antes de declararla irrecuperable y mandarla al cuestionario.*

---

## 12. Apertura selectiva: el registro de lecturas abiertas

### 12.1 La apertura no se busca, se cosecha

> **Regla de no apertura.** **No se abre una lectura alternativa donde el procedimiento no dejó una
> marca.** No hay búsqueda de ambigüedades: hay recolección de las que P0–P11 ya encontró y descartó.

Es la diferencia entre un procedimiento acotado y una sesión de interpretación, y es la misma
disciplina que gobierna la pasada de recomposición: **nada sin señal** (G1). Acá la señal es todavía
más barata, porque no hay que detectarla: **quedó escrita en la hoja de trabajo del paso anterior**.

### 12.2 Las nueve entradas que autorizan abrir

Lista cerrada. Cada entrada del registro tiene que poder decir de cuál de estas nueve salió.

| # | Origen | De dónde se cosecha | Lecturas típicas |
| --- | --- | --- | --- |
| **AB-1** | **`?` de la regla de la duda** | `02` §0.1, P9 | corta / no corta |
| **AB-2** | **`?` de la regla de cierre de modificadores** (indicio 8) | `02` §4.3 | restringe / no restringe, o el cuadrante indeciso |
| **AB-3** | **Conjunto de referencia sin fijar** (`⊂ ?`, §1.3 paso A) | `04` §1 | dos conjuntos candidatos |
| **AB-4** | **Disyunción sin rotular** inclusiva o exclusiva | `02` §3.3 | una / una o las dos |
| **AB-5** | **Restitución no unívoca** | `02` P-4 y P7 | dos agentes, dos antecedentes, dos verbos elididos |
| **AB-6** | **Alcance no resuelto de un calificador o un cuantificador sobre miembros coordinados** | `02` §3.7, filas 2 y 8 | distribuye sobre uno / sobre los dos |
| **AB-7** | **Decisión tomada por un indicio derrotable** —puntuación (6), consistencia del autor (7)— o **por la regla del error barato** | `02` §3.2, §4.3 | la elegida / la derrotada. **Ésta no dejaba marca y hay que empezar a dejarla** |
| **AB-8** | **Desnominalización con más de una lectura** | `02` §3.5 | dos verbos, dos juegos de argumentos |
| **AB-9** | **Clausura de dominio no marcada** | `04` §4.4 D-3 | lista cerrada / lista abierta |

**AB-7 es la única que exige un cambio en los pasos anteriores**, y es chico: donde hoy se decide por
un indicio derrotable y se sigue, hay que anotar la entrada. Es una línea por decisión, y es
precisamente la información que hoy se pierde.

### 12.3 Cómo se escribe una lectura, y el techo de dos

Una lectura no es una paráfrasis: es un **compromiso**. Escribirla como compromiso es lo que después
permite propagar sin interpretar.

```text
⟪ frag-id ⟫  origen: AB-n
  L-a : <la lectura, en una oración>
        compromisos: referente=… · alcance=… · momento=… · cardinalidad=… · modalidad=…
  L-b : <la otra>
        compromisos: …
  vínculos: <fragmentos cuyos compromisos tocan los mismos casilleros>
  estado  : abierta | cerrada por ‹causa› | en ciclo ‹id›
```

**El techo son dos lecturas.** Una tercera se puede escribir, y exige una línea de justificación en la
entrada. La razón no es aritmética: es que **tres lecturas vivas sobre un fragmento casi siempre
significan que el fragmento está mal cortado o que el término no está definido**, y las dos cosas se
arreglan antes y mejor que sintonizando. Un registro con varias entradas de tres lecturas es un
síntoma, no un trabajo.

**Los compromisos son el mecanismo.** Dos lecturas son incompatibles cuando sus compromisos se
contradicen **en el mismo casillero** —el mismo referente, el mismo momento, el mismo alcance—. Con
los casilleros escritos, la compatibilidad se verifica comparando; sin ellos, se verifica por
impresión, y la propagación se vuelve una conversación.

### 12.4 La cota global, y qué significa superarla

> **Cota del registro.** Si el registro supera **una entrada abierta cada dos oraciones ortográficas**,
> el párrafo **no se sintoniza**: se eleva entero.

No es un tope de presupuesto: es un **diagnóstico**. Un texto con esa densidad de indecisión no tiene
un problema de análisis, tiene un problema de redacción, y sintonizarlo produciría una interpretación
del analista disfrazada de lectura del autor. Lo que corresponde es decir eso, con la cuenta al lado,
que es un hallazgo mucho más útil que treinta preguntas sueltas.

---

## 13. La pasada de sintonización (P12)

### 13.1 Por qué no hay explosión combinatoria

El freno está en tres lugares distintos, y conviene verlos juntos porque cada uno solo no alcanzaría:

1. **No se abren lecturas en todos lados.** Sólo donde el procedimiento dejó marca (§12.1). El
   exponente no es la cantidad de fragmentos: es la cantidad de entradas del registro, que la cota de
   §12.4 mantiene en el orden de la mitad de las oraciones.
2. **No se enumeran asignaciones globales.** La pasada **nunca** construye una combinación completa
   para evaluarla. Sólo hace dos cosas: **fijar** una lectura y **tachar** las lecturas vecinas
   incompatibles con ella, con la causa escrita. El trabajo crece con la cantidad de **vínculos**, no
   con el producto de las lecturas.
3. **Se resuelve desde la casilla forzada**, como se empieza un sudoku: primero lo que no tiene
   alternativa, y cada decisión achica las de al lado.

Y hay un cuarto freno, que es el que más recorta en la práctica y no es de diseño sino de hecho: **la
mayoría de las entradas se cierra por triangulación en el primer barrido**, porque los autores
reafirman mucho más de lo que creen. El banco de pruebas de §14 lo muestra sobre un párrafo de cuatro
oraciones.

### 13.2 El procedimiento, en siete pasos

> **P12 — Sintonización.** Corre después de P11 y antes de P13. **No modifica el corte** ni las
> etiquetas: modifica **cuál de las lecturas vivas queda**.

**P12.0 — Precondición.** P0 a P11 cerrados. Si la pasada descubre un corte mal hecho, marca `!` y
sigue.

**P12.1 — Cosechar el registro.** Recorrer la hoja de trabajo y levantar las nueve clases de entrada
de §12.2. Escribir cada una con sus lecturas y sus compromisos (§12.3). Contar: **`e` entradas
abiertas**. Aplicar la cota de §12.4 antes de seguir.

**P12.2 — Inventariar las reafirmaciones.** Barrer el párrafo buscando las cinco formas de §11.2 y
anotarlas con su vínculo: `O2.3 ≡ O3.1`. Igual que P2 y que P13.2, **esto es inventario, no
producción**: todavía no se resuelve nada.

**P12.3 — Fijar el tablero.** Todo fragmento que **no** está en el registro tiene una sola lectura y
es dato fijo. Es la mayor parte del párrafo, y es lo que hace que la propagación tenga de dónde
agarrarse.

**P12.4 — Propagar.** Por el orden de §13.3: fijar una lectura, tachar las incompatibles con causa
(§13.4), repetir. Hasta punto fijo: una vuelta entera que no tacha nada.

**P12.5 — Tratar lo que quedó.** Los ciclos, por §13.5. Cada discordancia, por la escalera de §13.6.
**En ese orden y sin saltear peldaños.**

**P12.6 — Fichar.** Cada entrada cerrada, con su causa. Cada discordancia, con su diagnóstico
declarado y el motivo por el que se descartaron los diagnósticos anteriores. Cada incompletitud, con
su **premisa faltante redactada bajo `Propuesta`** y los fragmentos que la hacen necesaria (§13.9).

**P12.7 — Cerrar con la cuenta.** Cinco números:
`SIN e abiertas / t cerradas por triangulación / p cerradas por propagación / c en ciclo / d discordancias (n1 expresión, n2 incompletitud, n3 contradicción)`.
Y la comprobación que tiene que dar exacta: **`e = t + p + c + d`**. Una entrada que no aparece en
ninguna columna es una entrada resuelta sin decir cómo.

### 13.3 El orden de resolución y el desempate determinista

Se elige la próxima entrada a resolver con este orden, y **el primero que discrimina, manda**:

| Prio | Criterio | Por qué va ahí |
| --- | --- | --- |
| 1 | **La que tiene una reafirmación discriminante apuntándola** (§11.3) | Cierra **sin depender de ninguna otra entrada**: es evidencia del texto, no consecuencia de una decisión previa. Todo lo que se cierre así es más firme que lo que se cierre por propagación |
| 2 | **La que tiene menos lecturas vivas** | Es la casilla más forzada |
| 3 | **La que tiene más vínculos con el tablero fijo** | Es la que más se apoya en lo que no está en duda, y la que más va a recortar al propagar |
| 4 | **Orden en el texto** | Desempate final |

**El cuarto criterio no es un detalle.** Sin un desempate determinista, el punto fijo al que llega la
propagación **puede depender del camino**, y entonces dos analistas honestos sobre el mismo texto
llegan a lecturas distintas —que es exactamente el reproche que `02` §1.2 le hace a «sin pérdida de
sentido» en su falla F4—. Con el desempate por orden de texto, la corrida es **repetible**, y por eso
**el orden en que se resolvieron las entradas se anota**: es parte de la evidencia, no un rastro
administrativo.

### 13.4 Propagación y descarte con causa

Al fijar una lectura `L-a` del fragmento X:

1. Recorrer los **vínculos** de X.
2. En cada entrada vinculada, tachar las lecturas cuyos **compromisos** se contradigan con los de
   `L-a` en el mismo casillero.
3. Escribir en cada lectura tachada: **`descartada por ‹X.L-a›`**.
4. Si una entrada queda con una sola lectura viva, **queda cerrada por propagación** y entra en la
   cola.
5. Si una entrada queda con **cero** lecturas vivas, **no se fuerza**: es una **discordancia**, se
   deshace el último tachado, se marca la entrada y va a la escalera de §13.6.

> **Regla del descarte con causa.** **Ninguna lectura se tacha sin escribir qué la tachó.** Es lo que
> convierte la pasada en auditable: al final, cada lectura descartada tiene una cadena que termina en
> un fragmento del texto o en una reafirmación, y la cadena se puede recorrer al revés. Una lectura
> tachada sin causa es indistinguible de una lectura que al analista no le gustó.

El punto 5 es el que impide que la propagación se convierta en una máquina de forzar: cuando el
tablero no cierra, **el resultado no es una asignación, es un hallazgo**.

### 13.5 Los ciclos sin casilla forzada

Un ciclo es un conjunto de entradas abiertas cuyas lecturas **sólo se restringen entre sí**: ninguna
está apuntada por una reafirmación y ninguna toca el tablero fijo. El sudoku sin casilla forzada.

**Qué se hace, en este orden:**

1. **Buscar una reafirmación externa al ciclo.** Es la salida limpia y la más frecuente: una tercera
   formulación del mismo concepto, en otra parte del párrafo o en el documento, que discrimine. RF-5
   —la operacional— es la que más veces la provee.
2. **Correr la escalera de diagnóstico** (§13.6) sobre el ciclo como unidad. Muy a menudo el ciclo no
   es una ambigüedad: es una **incompletitud**, y lo que falta es la premisa que lo articula. Ésa es
   la corrección que el refinamiento de T-3 trae, y es la que evita el peor resultado posible.
3. **Si sigue abierto:** aplicar la **regla del error barato** —la misma de `02` §3.2: se elige la
   lectura cuyo error sea reparable— **como lectura provisoria y marcada**, y elevar.

**Y la regla que da el mayor rendimiento de todo el apartado:**

> **Un ciclo produce una sola pregunta, no una por entrada.** Las entradas de un ciclo están atadas:
> contestada una, caen todas. Preguntar por cada una es hacerle al autor cuatro preguntas que son la
> misma, invitarlo a contestarlas de manera inconsistente entre sí, y gastar el capital de preguntas
> que el método tiene.

**Tres prohibiciones sobre ciclos**, porque son las tres salidas fáciles: no se resuelve por mayoría
—«dos lecturas apuntan para el mismo lado»—, no se resuelve por preferencia de dominio —«en una
estancia esto se hace así»—, y no se resuelve por eufonía —«suena mejor»—.

### 13.6 La escalera de diagnóstico: expresión, incompletitud, contradicción

Cuando dos afirmaciones o dos lecturas no cierran, el procedimiento vigente sólo sabe reportar
**conflicto**. Es el diagnóstico más caro de los tres y casi nunca es el correcto. Se recorren en
orden, **y está prohibido saltar peldaños**.

| Peldaño | Diagnóstico | Qué pasa | Cómo se resuelve | Quién lo paga |
| --- | --- | --- | --- | --- |
| **E1** | **Ambigüedad de expresión** | El texto admite dos lecturas y **una de ellas** hace consistente al conjunto | **Leyendo bien.** No hace falta información nueva | Nadie |
| **E2** | **Incompletitud** (indeterminación) | **Muchos mundos** satisfacen las dos afirmaciones; el texto no elige | **Nombrando la premisa faltante** | El autor confirma una pieza que ya tenía en la cabeza |
| **E3** | **Contradicción** (inconsistencia) | **Ningún mundo** las satisface | El autor corrige, y **algo se cae** | El autor reescribe, y el análisis hecho sobre lo que se cae se rehace |

**Las dos pruebas que separan los peldaños, y las dos son baratas:**

> **Prueba E1 — ¿alguna lectura disuelve el problema?** Probá las lecturas vivas **de los fragmentos
> involucrados solamente** —son dos o tres, no el párrafo entero—. Si alguna combinación cierra, es
> ambigüedad de expresión: fijala, anotá qué la fijó, y terminó.
>
> **Prueba E2 — ¿puedo construir un caso donde las dos sean verdaderas a la vez?** Bajo las lecturas
> ya fijadas, describí **un** estado de cosas concreto que satisfaga las dos afirmaciones. Si podés,
> **falta información**: el texto no elige entre los mundos que quedan, y lo que hay que hacer es
> nombrar la premisa que elige. Si no podés, **recién ahí** es contradicción.

**Obligación de declaración.** Toda discordancia sale con su diagnóstico **y con el motivo por el que
se descartaron los anteriores**:

```text
escalera : E1 descartada — ninguna combinación de las lecturas vivas de ‹X› e ‹Y› cierra
           E2 aplicada  — caso que satisface a las dos: ‹descripción en una oración›
```

**Por qué el orden es lo que importa.** Saltar al E3 es lo que el autor llama «invalidar la
ambigüedad»: declarar defectuoso lo que sólo estaba incompleto. Y el costo es asimétrico y silencioso:
un E2 reportado como E3 **manda a descartar una de las dos afirmaciones**. Con el autor disponible eso
se corrige en una conversación; con el autor ausente —que es la situación normal—, **una afirmación
verdadera del negocio se tira**, y no queda rastro de que se la tiró.

### 13.7 La pieza faltante: una operación, tres manifestaciones

La pregunta que trae el refinamiento es si conviene unificar esto con **I-08** del cuerpo metodológico
—«intención sin momento de verificación»—, que es la misma operación aplicada a actos.

**Veredicto: se unifica el diagnóstico y el rótulo; NO se unifica la búsqueda. Y la razón no es
conservadora, es aritmética.**

La operación es efectivamente una sola: *hay dos cosas que no cierran, ¿falta una tercera que las
una?* Y tiene tres manifestaciones:

| Manifestación | Qué falta | Búsqueda específica, que **no se puede perder** | Dónde vive |
| --- | --- | --- | --- |
| **Falta un momento o un acto** | El momento de verificación, o el caso de uso donde la regla cae | Recorrer **cada regla contra el inventario de actos**: la regla que no cae sobre ninguno | **I-08**, Deducción §3.6 |
| **Falta una premisa** | La afirmación que articula dos afirmaciones que no cierran | Recorrer **las discordancias del registro** con la prueba E2 | **Acá**, §13.6 |
| **Falta una definición** | La extensión de un término usado con dos alcances | Recorrer **el glosario contra los usos**: el mismo nombre sobre dos colecciones | **I-01 / I-02**, Deducción §3.6 |

**Por qué no se unifican las búsquedas.** Porque **el síntoma es lo que hace encontrable a la cosa**.
«La regla no cae sobre ningún acto» es una búsqueda que se corre recorriendo una lista contra otra, y
que se puede declarar «buscada, sin hallazgos». «¿Falta alguna pieza?» no es una búsqueda: es un
estado de ánimo. Y hay una consecuencia dura: el cuerpo metodológico exige en **P-9 un veredicto
explícito por entrada del catálogo**; fusionar tres entradas enumerables en una inenumerable
**reduciría la cobertura** mientras da la impresión de simplificar. Es el caso exacto en el que la
unificación elegante empeora el instrumento.

**Qué sí se unifica, y vale la pena:**

1. **El nombre y el diagnóstico.** Las tres son *pieza faltante*, peldaño E2. Que compartan nombre
   hace que quien encuentra una se acuerde de buscar las otras dos.
2. **El rótulo y el respaldo.** Las tres salen bajo **`Propuesta`** con la misma exigencia de §13.9.
3. **La remisión cruzada.** I-08 gana una línea que dice que su hallazgo es un E2 sobre actos, y la
   escalera gana una que dice que, si lo que falta es un momento, el hallazgo es un I-08 y se busca
   con su síntoma.

### 13.8 Criterio de corte y la única realimentación permitida

| # | Condición de terminación | Si falla |
| --- | --- | --- |
| 1 | **Punto fijo**: una vuelta entera de propagación no tacha nada | Seguir propagando |
| 2 | **Registro repartido**: `e = t + p + c + d` | Alguna entrada se resolvió sin decir cómo |
| 3 | **Escalera declarada**: toda discordancia tiene diagnóstico y descarte de los anteriores | P12.5 |
| 4 | **Causas escritas**: ninguna lectura tachada sin `descartada por` | P12.4 |
| 5 | **Ciclos elevados como unidad**: un ciclo, una pregunta | P12.5 |

**La realimentación con P13, que es el único bucle permitido.** La recomposición (P13) puede producir
una afirmación distribuida que cierre una entrada que P12 dejó abierta. Cuando pasa:

> Se vuelve a P12 **una sola vez**, se declara la vuelta, y la `AD` que la cerró se vuelve a verificar
> con la prueba de admisión **después** de la vuelta, porque ahora descansa sobre una lectura que ella
> misma ayudó a fijar. Si al reverificarla falla, **se deshacen las dos cosas**: la `AD` y el cierre
> de la entrada.

Una sola vuelta, y declarada. Sin ese tope, P12 y P13 se realimentan y el par converge a lo que el
analista esperaba encontrar, que es la forma más difícil de detectar de la sobreinterpretación:
**termina siendo coherente, y por eso convence**.

### 13.9 Rótulo del producto y evidencia exigible

Tres productos distintos, tres rótulos distintos. Ninguno es letra nueva.

| Producto | Rótulo | Evidencia exigida |
| --- | --- | --- |
| **La cita del fragmento** | **`Letra`**, sin cambios | Sigue siendo el texto del autor, con su puntuación original. **Sintonizar no reescribe la fuente** |
| **La lectura elegida** entre las que estaban abiertas | **`Intención`** | `fijada por:` —la reafirmación que discriminó, o la cadena de propagación—; los compromisos de la lectura elegida; y las lecturas descartadas **con su causa** |
| **La premisa faltante** (E2) | **`Propuesta`** | Los **fragmentos que la hacen necesaria**, nombrados; la descripción del caso que satisface a las dos afirmaciones sin ella; la **frase de residuo**; y la `Pregunta para el autor` que la acompaña |
| **La contradicción** (E3) | **`Hallazgo`** + **`Pregunta para el autor`** | Las dos citas completas y la constancia de que E1 y E2 se descartaron. **No se arbitra**: el régimen de pesos de evidencia de Deducción §3.3 manda declarar el conflicto, no resolverlo |

**Sobre la premisa faltante, que es lo más peligroso que produce este método.** La escribe el analista,
no está en ninguna parte del texto, y encima **suena razonable**, que es lo que la vuelve peligrosa.
Tres candados, y los tres vienen de mecanismos que ya existen:

1. **`Propuesta`, y sólo `Propuesta`.** Nunca `Intención`, porque no hay respaldo textual de que el
   autor la tuviera en la cabeza; lo único probado es que **hace falta**. En el modo de seis roles la
   escribe R6 (Deducción §3.2); en el modo compacto, quien cumpla ese papel, y se declara.
2. **Compuerta de precedencia (M-4).** No se propone una premisa faltante sobre una discordancia que
   no tenga las dos `Letra` ancladas. Es la misma compuerta que gobierna toda propuesta.
3. **Nombrar los fragmentos que la hacen necesaria.** Sin eso, «falta una premisa» es licencia para
   agregar cualquier cosa y decir que faltaba.

**Y la prueba propuesta en el encargo, evaluada:** *«si no se pueden señalar los dos o más fragmentos
que, combinados, producen la afirmación, no es una afirmación distribuida: es una ocurrencia del
analista»*. **Se acepta: es exactamente la condición A1 de §6.3**, a la que este documento llegó por su
lado, lo cual es una confirmación razonable de que la condición es la correcta. Con una precisión que
hay que agregar, porque la prueba sola se puede pasar haciendo trampa sin darse cuenta:

> **A1 es necesaria y no es suficiente.** Se pueden señalar dos fragmentos y aun así haber fabulado,
> si **una de las dos premisas no es del texto sino del dominio** (anti-patrón SI-3) o si **una de las
> dos no hace falta** (la conclusión sobrevive a su borrado). Por eso A1 va siempre con **A2**
> —premisas de letra— y **A4** —supresión—. Las tres juntas son la prueba; A1 sola es la puerta.

---

## 14. Banco de pruebas: las reafirmaciones del párrafo

Las tres estructuras de reafirmación del párrafo de la estancia, resueltas con el aparato de la Parte
III, más el caso testigo de la escalera. Es el único lugar del documento donde se vuelve al material
del encargo, y es a propósito: es lo que hay que poder resolver.

### 14.1 «instalaciones y viviendas»

> «Tanto el casco como el puesto son **instalaciones y viviendas** donde se aloja el dueño y personal
> de la estancia.»

**Entrada del registro: AB-6**, alcance de una coordinación.

| | |
| --- | --- |
| **L-a** | Cada uno de los dos —casco y puesto— es **a la vez** instalación y vivienda. *Compromisos:* alcance = los dos sustantivos sobre los dos sujetos; referente = uno solo con dos facetas |
| **L-b** | El conjunto {casco, puesto} **se reparte**: unos son instalaciones y otros, viviendas. *Compromisos:* alcance = distributivo cruzado; referentes = dos clases disjuntas |

**Resolución por triangulación (RF-3, estructural).** El correlativo «**tanto** el casco **como** el
puesto» distribuye el predicado entero sobre los dos sujetos —es la fila 8 de `02`, correlación de
grupos, que da sujeto múltiple y un solo predicado—. La prueba de la discriminación: el correlativo es
compatible con **L-a** e incompatible con **L-b**. → **L-a fijada**, `fijada por: RF-3 «tanto… como»`.
Y la relativa final —«donde se aloja el dueño y personal»— la confirma: reafirma **vivienda** y no
**instalación**, lo que sólo tiene sentido si el mismo referente es las dos cosas.

**Qué queda registrado.** No son dos términos: es **un término con dos facetas** —*instalación*, que
es la faceta productiva, y *vivienda*, que es la de uso—. Al glosario va **una** entrada con las dos
facetas, no dos entradas. Es la diferencia entre un modelo con dos jerarquías paralelas y un modelo
con una. Y queda una `Pregunta para el autor`, barata: *¿toda instalación es vivienda, o eso vale sólo
para estas dos?* —que es la clausura, §4.4 D-3, sobre otro eje—.

### 14.2 «casco central / puestos rurales / son instalaciones»

Es la triangulación de tres piezas, y es el caso que originó todo el encargo. Ya resuelto en §3.5
—cuadrante Q1— y en §5.1 —la afirmación distribuida—. Lo que la Parte III agrega es **ver las tres
piezas como lo que son**: tres formulaciones que se sostienen entre sí.

| Pieza | Forma | Qué aporta |
| --- | --- | --- |
| «casco **central**» ⟂ «puestos **rurales**» | RF-3, estructural por paralelismo | El **eje**: ubicación, centro contra periferia |
| «tanto el casco **como** el puesto» | RF-3, correlativa | Que los dos son **comparables**: hay una bolsa |
| «son **instalaciones**» | RF-2, hiperonímica | **Nombra la bolsa**: el conjunto de referencia |

Cada una sola es insuficiente y ninguna es redundante: **el eje sin la bolsa no dice sobre qué recorta;
la bolsa sin el eje no dice en qué se distinguen**. Es la ilustración más limpia de T-1: el autor dijo
tres veces lo mismo desde tres lugares distintos, y las tres hacían falta. Un análisis que trate la
tercera como repetición pierde exactamente la pieza que faltaba.

### 14.3 «En el mismo acto»

> O1: «…está compuesta por al menos un campo **en su momento de conformación**.»
> O2: «**En el mismo acto** se establece un casco central … y varios puestos rurales…»

**Entrada del registro: AB-5**, restitución no unívoca del antecedente de «el mismo».

| | |
| --- | --- |
| **L-a** | «El mismo acto» remite al **acto de conformación** de O1. *Compromisos:* momento = conformación; no hay acto nuevo |
| **L-b** | «El mismo acto» introduce **un acto propio** de O2, simultáneo pero distinto. *Compromisos:* momento = uno nuevo; hay un acto más en el inventario |

**Resolución (RF-4, reafirmación de ancla).** «El mismo» es un discriminante: exige un antecedente, y
en el párrafo hay **exactamente uno** —el momento de conformación de O1—. **L-b** requeriría un acto
que ninguna oración nombra. → **L-a fijada**, `fijada por: RF-4, antecedente único en O1`.

**Y de acá sale una afirmación distribuida**, que es de las que más valen porque es una restricción
temporal fuerte que el texto nunca enuncia de corrido:

> **AD:** *el casco y los puestos se establecen **en el acto de conformación** de la estancia, no
> después.*
> **Premisas:** P1 ← O1 «en su momento de conformación» · P2 ← O2 «en el mismo acto se establece…».
> **A4:** sin P1 no hay acto al que remitir; sin P2 el acto no alcanza al casco ni a los puestos. Las
> dos se caen. ✔ **A5:** «los puestos se agregan después de conformada la estancia» contradice a O2
> leída con O1. ✔ → **`Intención`**.

**Por qué importa, dicho sin diseñar nada:** una cosa es una estancia a la que se le pueden agregar
instalaciones, y otra distinta es una estancia cuyas instalaciones quedan fijadas en su acto
constitutivo. El párrafo dice lo segundo, y no lo dice en ninguna de sus oraciones. La cuarta oración
—que difiere la administración— **no lo contradice**: difiere la administración, no el alta. Es
justamente la clase de distinción que se pierde cuando «en el mismo acto» se lee como una fórmula de
relleno.

### 14.4 Caso testigo de la escalera: la actividad sin lotes

Del mismo enunciado, y es un caso cerrado con la respuesta del autor a la vista, así que sirve para
verificar la escalera contra un resultado conocido.

**La tensión.** Una regla afirmaba *«toda actividad tiene al menos un lote asignado»*; un caso de uso
daba de alta la actividad **sin** lotes. **Se reportó como contradicción (E3).**

**La escalera, corrida como corresponde:**

> **E1 — ¿alguna lectura disuelve el problema?** Las lecturas vivas de «tiene al menos un lote» son
> dos: *invariante en todo momento* / *completitud exigible en algún momento*. Ninguna de las dos está
> forzada por el texto, y **ninguna sola disuelve el problema**, porque la que lo disolvería —la
> segunda— necesita decir **desde cuándo**, y eso no está escrito. **E1 descartada.** *Nota: que a la
> regla le falte el momento es, por sí solo, un hallazgo **I-08**; la escalera y el catálogo señalan
> acá la misma pieza.*
>
> **E2 — ¿puedo construir un caso donde las dos sean verdaderas a la vez?** Sí, y es fácil: la
> actividad se da de alta sin lotes y la asignación ocurre después, con la exigencia verificándose en
> un momento posterior al alta. Las dos afirmaciones son verdaderas en ese caso. → **incompletitud**.
>
> **Premisa faltante, bajo `Propuesta`:** *la asignación de lotes es posterior al alta de la
> actividad, y la exigencia de al menos un lote se verifica en ese momento posterior y no en el alta.*
> **Fragmentos que la hacen necesaria:** la regla y el paso del caso de uso, nombrados. **Residuo:**
> *«El enunciado no fija el momento; la premisa la agrega el análisis para que las dos afirmaciones
> cierren.»* **Pregunta para el autor:** *¿en qué momento se exige el primer lote?*

**El desenlace real.** El autor no eligió un lado: **reescribió el párrafo para decir que la asignación
es posterior al alta**. O sea, agregó exactamente la pieza faltante. **El diagnóstico correcto era E2 y
se había reportado E3.**

**Qué se aprende, que es lo que justifica la escalera entera.** Funcionó igual porque el autor estaba
disponible. Con un autor ausente, el reporte de contradicción manda a **descartar una de las dos
afirmaciones**, y las dos eran verdaderas: lo único que pasaba es que faltaba la tercera. **El daño de
saltar al E3 no es equivocarse de nombre: es tirar información buena.**

### 14.5 Qué muestra el banco

Cuatro cosas, y ninguna es teórica:

1. **Sobre un párrafo de cuatro oraciones hay tres reafirmaciones, y las tres resuelven algo.** La
   densidad no es excepcional: es lo normal en prosa de negocio, que es lo que T-1 y T-2 sostienen.
2. **Las tres entradas del registro se cerraron por triangulación, ninguna por propagación y ninguna
   quedó en ciclo.** Es una muestra chica, pero apunta a que el freno combinatorio de §13.1 sobra por
   varios órdenes de magnitud en textos de este tamaño.
3. **Dos de las tres produjeron además una afirmación distribuida** —§14.2 y §14.3—, lo que confirma
   que P12 y P13 se alimentan y que el orden entre las dos importa: sin fijar «el mismo acto», la
   afirmación de §14.3 no se puede componer.
4. **El caso testigo muestra el error que la escalera evita**, y lo muestra con la corrección del
   autor como testigo independiente. No es un ejemplo construido para que dé bien.


---

## 15. Parches redactados, listos para aplicar

**Este documento no edita a sus hermanos.** Lo que sigue son los parches, sección por sección, para que
otro los aplique. Están ordenados por prioridad: los marcados **P0** corrigen afirmaciones hoy escritas
que este documento refuta, y hasta que se apliquen los dos documentos se contradicen entre sí.

### 15.1 Parches a `02-Criterio-De-Segmentacion.md`

| # | Prio | Sección | Qué hacer |
| --- | --- | --- | --- |
| **02-a** | **P0** | §4.3, bloque de ejemplos, primer recuadro «**Adjetivo, no restrictivo** — *se establece un casco central*» | **Reemplazar entero.** Hoy concluye «describe» y es la conclusión refutada por §3.5 de este documento. Texto de reemplazo abajo |
| **02-b** | **P0** | §4.3, indicio 4 «Conjunto de contraste», celda «Cómo decide» | **Reemplazar** por el procedimiento de paso A / paso B / paso C de §1.3, y **agregar la regla del ámbito agotado** de §1.4 como párrafo inmediatamente debajo de la tabla |
| **02-c** | **P0** | §4.3, tabla de indicios | **Insertar la fila `2-bis` — Paralelismo**, con las cuatro condiciones resumidas y la marca de unidireccional. Estatuto: criterio propio, de `04` §2. **No renumerar** las demás (razón en §2.4) |
| **02-d** | **P0** | §4.3, indicio 3 «Unicidad referencial» | **Agregar la enmienda** de §2.4: la unicidad concluye sólo si se verifica **sobre el conjunto de referencia**, no sobre la extensión del núcleo |
| **02-e** | **P0** | §4.3, bloque «**Y no es simétrico**» | **Reemplazar por la tabla de los cuatro cuadrantes** de §3.3, con las tres reglas de uso. Retitular la sección: «**§4.3 ¿Este modificador restringe? ¿e informa?**», y actualizar el índice y los dos punteros que la citan (§4 encabezado y el aviso en recuadro de §4) |
| **02-f** | P1 | §2, tabla de estructuras | **Agregar la fila 39** (texto abajo). Actualizar §2.6: «38 filas» → «39 filas» |
| **02-g** | P1 | §2, fila 37 «Adjetivo modificador» | En «Tratamiento», reemplazar «restringe → `⟨C-restr⟩`; describe → se queda con el término» por el par de cuadrantes: «se resuelve con §4.3 y sale con **cuadrante Q1 a Q4**» |
| **02-h** | P1 | §5, P5-bis | En la lista de resultados, reemplazar el par restringe/describe por los cuatro cuadrantes, y **agregar el paso A** —fijar el conjunto de referencia y anotarlo con `⊂`— como primera acción del paso |
| **02-i** | P1 | §5, después de P11 | **Agregar dos pasos, en este orden**: **P12 — Sintonización**, remitiendo a `04` §13, y **P13 — Recomposición**, remitiendo a `04` §6. En la tabla de P11 agregar dos condiciones de terminación: **7. Sintonización corrida y contada** —el registro de lecturas abiertas quedó repartido, `e = t + p + c + d`; si falla, volver a P12— y **8. Recomposición corrida y contada** —P13 cerró con su cuenta de tres números; si falla, volver a P13— |
| **02-r** | **P0** | §0.1 y §4.3 indicio 8; §3.2; §3.3; P-4 y P7 | **El `?` deja de ser terminal.** Donde hoy se marca `?` y se eleva, ahora se marca `?` **y se anota en el registro de lecturas abiertas** (`04` §12), que P12 intenta cerrar antes de que nada llegue al cuestionario del autor. Es la **segunda compuerta del `?`**, hermana de la de `03` §5 |
| **02-s** | **P0** | §3.2 y §4.3, indicios 6 y 7, y la regla del error barato | **Dejar marca donde hoy no la hay.** Toda decisión tomada por un **indicio derrotable** —puntuación, consistencia del autor— o por la **regla del error barato** se anota como entrada `AB-7` del registro, con la lectura elegida y la derrotada. Es una línea por decisión, y es la información que hoy se pierde entera |
| **02-t** | P1 | §6.2, tabla de falsas uniones, y §9 | **Agregar la escalera de diagnóstico** por remisión a `04` §13.6: ante dos afirmaciones que no cierran, se recorren en orden **ambigüedad de expresión → incompletitud → contradicción**, y **está prohibido saltar peldaños**. Declarar el diagnóstico aplicado y por qué se descartaron los anteriores |
| **02-j** | P1 | §3 | **Agregar §3.9 — «La predicación de dominio cerrado»**, remitiendo a `04` §4, y cruzarla con §3.3 (inclusivo/exclusivo) y con la fila 10 (listas cerradas) |
| **02-k** | P2 | §3.2, párrafo «Procedimiento, en este orden» | **Insertar «paralelismo»** en la cadena de indicios en prosa, entre «determinante del antecedente» y «unicidad referencial» |
| **02-l** | P2 | §6.2, nota final sobre FU-10 | **Agregar una línea**: FU-10 es el caso concesivo de la clase **AD-3** de `04` §5.5, y su rótulo —`Conjetura` más pregunta— es el mismo. La resolución vigente no cambia |
| **02-m** | P2 | §8.3, lista de control | **Agregar tres ítems**: (a) todo modificador salió con **cuadrante escrito**; (b) todo «no restringe» declarado tiene anotado **el ámbito agotado**; (c) **P13 corrida**, con su cuenta y sus candidatas rechazadas conservadas |
| **02-n** | P2 | §8.4, orden en una línea | Agregar al final: «→ **recomposición**» |
| **02-o** | P2 | §0.3, tabla de estatutos | **Agregar las filas** de §0.2 de este documento que correspondan a lo que se incorpora, con la remisión a `04` |
| **02-p** | P2 | §9, límites | **Agregar el límite**: la pasada de recomposición produce inferencias y su calidad depende de la lista de señales, que está calibrada sobre dos párrafos |
| **02-q** | P2 | §10, control de cambios | **Fila 1.2**, redactada abajo |

**Texto de reemplazo para 02-a** (recuadro de ejemplo en §4.3):

> **Adjetivo restrictivo sobre un conjunto que no es el del núcleo —el caso que corrigió la versión
> 1.2.** «se establece un casco **central** … y varios puestos **rurales**». Indicio 1: pospuesto, no
> concluye. Indicio 2: indefinido, no prueba nada. **Indicio 2-bis: paralelismo.** Dos núcleos
> coordinados bajo «se establece», dos adjetivos pospuestos, eje nombrable *ubicación*
> (centro/periferia) → **restringe**, y el conjunto de referencia es la unión de los dos núcleos, que
> la oración siguiente nombra: *instalaciones*. El indicio 3 **no concluye**: el casco es único **como
> casco** y no como instalación. Cuadrante: ¿informa? No se puede exhibir dónde estaba dicho antes que
> el casco es el central → **sí**. → **Q1**, `⟨C-restr⟩ ⊂ instalaciones`, y el eje *ubicación* al
> glosario. **La versión 1.1 daba este caso por «describe», y era una búsqueda de contraste hecha
> sobre la extensión del núcleo en lugar del conjunto de referencia.**

**Texto de la fila 39 para §2** (02-f):

> | 39 | `+` | **Predicación de dominio cerrado** | «es X o Y», «puede ser X, Y o Z», «se clasifican en…», con sujeto genérico y valores incompatibles | **NO** | Una sola A, de especie **restricción de dominio**: a diferencia de una definición, **pasa P-3** —un ejemplar sin ninguno de los valores la viola—. Produce un **atributo con dominio enumerado** al glosario, y arrastra tres afirmaciones con estatutos distintos: **exhaustividad** `Letra`, **exclusividad** `?` hasta resolver §3.3, **clausura** `Intención` más pregunta obligatoria salvo marca explícita («únicamente», «sólo», «dos categorías»). Ver `04` §4 |

**Fila de control de cambios para 02-q:**

> | 1.2 | ‹fecha› | **Aplicación de `04-Afirmacion-Distribuida-Y-Modificadores.md`.** §4.3 se retitula «¿Este modificador **restringe? ¿e informa?**» y su salida deja de ser binaria: pasa a ser el par `(restringe?, informa?)` con **cuatro cuadrantes** y etiqueta por cuadrante. El **indicio 4 recibe el procedimiento de dos ejes** —conjunto de referencia N1→N3, ámbito textual Á1→Á4— y la **regla del ámbito agotado**: no encontrar contraste sólo concluye después de un barrido completo. Se agrega el **indicio 2-bis, paralelismo**, con sus cuatro condiciones y sus seis casos de no aplicación, y se **enmienda el indicio 3**: la unicidad se verifica sobre el conjunto de referencia, no sobre la extensión del núcleo. **El ejemplo «un casco central» se reescribe: era `describe` y es `Q1`.** Nueva fila 39 (dominio cerrado) y nueva §3.9. Nuevo paso **P13, recomposición**, con su prueba de admisión de cinco condiciones, su cota de señales y su rótulo de salida —`Intención` o `Conjetura`, **nunca `Letra`**—. Nuevo paso **P12, sintonización**, que corre **antes** de P13: el `?` deja de ser terminal y se cosecha en un **registro de lecturas abiertas** que la pasada intenta cerrar por **triangulación** con las reafirmaciones del autor y por **propagación desde la casilla forzada**, con descarte con causa y desempate determinista; toda discordancia sale con el diagnóstico de la **escalera** —ambigüedad de expresión, incompletitud, contradicción, en ese orden y sin saltear—, y la **premisa faltante** sale bajo `Propuesta` nombrando los fragmentos que la hacen necesaria. Las decisiones tomadas por indicio derrotable pasan a dejar marca (`AB-7`). **Séptima y octava condiciones de terminación** en P11. |

### 15.2 Parches a `03-Catalogo-De-Etiquetas.md`

| # | Prio | Lugar | Qué hacer |
| --- | --- | --- | --- |
| **03-a** | **P0** | Hoja de bolsillo, bloque `MODIFICADORES` (≈ línea 63) | **Reemplazar el bloque entero.** La línea «sin conjunto de contraste, describe: A» es la formulación que produjo el defecto. Texto de reemplazo abajo |
| **03-b** | **P0** | §6, banco de pruebas, **caso 6** (≈ línea 1188) y la fila de «central» de la tabla de casos (≈ línea 954) | **Reescribir el veredicto**: la etiqueta correcta de «central» es **`R`** (cuadrante Q1), no `A`. Lo que el caso 6 sigue probando —que el `?` era ilegítimo porque había criterio en la mano— **se conserva y se refuerza**: había criterio, y además el criterio estaba mal aplicado. **Es un caso más valioso reescrito que borrado** |
| **03-c** | **P0** | §8, párrafos «El indicio 4 es el que resuelve los adjetivos…» y el ejemplo de cierre (≈ líneas 1334 y 1378) | **Corregir**: «un casco central → no hay otros cascos → no hay de dónde recortar» es falso. Hay de dónde recortar; el conjunto no era *cascos* sino *instalaciones*. Reemplazar por el análisis de §3.5 |
| **03-d** | **P0** | §8, tabla de indicios | **Insertar la fila `2-bis` paralelismo**, **enmendar el 3** y **reescribir la celda del paso 2** de la tabla «Qué le toca a cada paso»: hoy dice «Describe → `A`, o `R(estructura)`…; Restringe → `R`», y debe pasar a los **cuatro cuadrantes**: `Q1 → R` o `R/A` · `Q2 → R°` · `Q3 → A`, o `R(estructura)` si ata dos cosas · `Q4 → T°` |
| **03-e** | P1 | §4.1, par «`A` contra `R`» (≈ línea 501) y §4.3 (≈ líneas 522-523) | **Corregir el ejemplo**: «un casco central» dejó de ser el ejemplo del adjetivo que describe sin restringir. Reemplazarlo por uno de los Q3 de `04` §3.4 —«la cámara **frigorífica**»— que sí es del cuadrante que la ficha necesita |
| **03-f** | P1 | §0.2, tabla de notación | **Agregar**: la nota **`(AD)`** sobre un fragmento producido por la recomposición, con identificador `AD-nn`; y la nota **`A(dominio)`** para el dominio cerrado. **Ninguna letra nueva**: las dos son notas, y las notas no rutean (§7.3 del propio catálogo) |
| **03-g** | P1 | §0.1, tabla de los cinco pasos | En la fila del paso 1, agregar a «Qué entrega»: «**más las `AD-nn` de la pasada de recomposición, cada una con su ficha**» |
| **03-h** | P2 | Hoja de bolsillo | **Agregar dos líneas** al bloque de cierre: «`AD-nn` entra como fragmento con letra normal y nota `(AD)`; su certeza es **inferencia**, nunca letra» |
| **03-i** | P2 | §3.2 (`A` — atributo) | **Agregar el borde**: un `A` cuyo fragmento **declara los valores posibles** en lugar de asignar uno lleva la nota `A(dominio)` y arrastra las tres afirmaciones de `04` §4.4 |
| **03-j** | P2 | §10, límites | **Agregar**: el banco de pruebas de §6 contiene un veredicto corregido por `04`; el caso 6 es ahora un caso de **criterio mal aplicado**, no de criterio no aplicado |
| **03-k** | P2 | §11, control de cambios y §11.1 procedencia | **Fila nueva** con lo de arriba, y en procedencia la remisión a `04` |
| **03-l** | **P0** | §5, la compuerta del `?` | **Agregar el segundo tramo de la compuerta.** Hoy pregunta *¿hay un criterio en mano que lo resuelva?*; se agrega *¿hay otra parte del texto que lo resuelva?* —la triangulación de `04` §11.3—. Un `?` sólo llega al autor después de pasar **las dos**. La recuenta de cierre gana una columna: `? n/total → m/total → k/total` |
| **03-m** | P1 | §0.1, tabla de los cinco pasos | En la fila del paso 1, agregar a «Qué entrega»: «**más el registro de lecturas abiertas**, que P12 intenta cerrar». El paso 2 etiqueta el fragmento con la **lectura fijada**, y si la entrada quedó abierta, con la nota `(abierta)` |
| **03-n** | P2 | §0.2, notación | Agregar `⟪ … ⟫` (entrada del registro), `≡` (vínculo de reafirmación) y la nota `(abierta)`. **Ninguna letra nueva** |

**Texto de reemplazo para 03-a** (bloque de la hoja de bolsillo):

```text
MODIFICADORES ("un casco central")
  1. ¿es argumento?  → no entra
  2. antepuesto → describe   | 3. universal (todo, cada, los... que) → RESTRINGE
     el indefinido (un, una, unos) NO PRUEBA NADA
  4. PARALELISMO: dos coordinados, dos modificadores iguales,
     eje nombrable  →  RESTRINGEN los dos     (central ⟂ rurales)
  5. ¿CONTRA CUÁL?  primero fijá el CONJUNTO: núcleo → coordinados →
     hiperónimo del párrafo.  Después buscá: sintagma → oración →
     párrafo → documento.   NO ENCONTRAR sólo vale si barriste todo.
  6. unicidad → describe, PERO sobre el conjunto, no sobre el núcleo

  DOS PREGUNTAS, no una:
    ¿restringe? (¿recorta el conjunto?)   ¿informa? (¿dato nuevo?)
    Q1 sí/sí → R      Q2 sí/no → R°      Q3 no/sí → A      Q4 no/no → T°
    Para poner Q4 tenés que SEÑALAR dónde ya estaba dicho.
    Si no podés señalarlo, es Q3.  "No restringe" NO es "no importa".
```

### 15.3 Qué no se toca, y por qué

- **`Knowledge-Deduccion-De-Reglas-De-Negocio.md`: ningún parche de rótulos** —ver §15.4 para los tres
  parches de contenido que sí lleva, sobre I-06, I-07 e I-08—. Sus siete rótulos alcanzan, su
  frase de residuo (M-3) y su compuerta de precedencia (M-4) se aplican tal cual, y su campo *Grado de
  certeza* ya tiene el valor `inferencia`. **Crear un rótulo nuevo para la afirmación distribuida sería
  un error**: debilitaría la lista cerrada, que es el mecanismo M-2, a cambio de una distinción que la
  ficha `AD` ya hace con su campo `clase`.
- **`Knowledge-Icono-Y-Ancla.md`: ningún parche.** Las definiciones nuevas de este documento —
  afirmación distribuida, conjunto de referencia, eje, cuadrante, dominio cerrado— fueron escritas con
  verbo y escena, que es lo que esa norma exige; si una falla la prueba, se corrige acá.
- **El corte y las 38 filas vigentes de `02` §2: sin cambios**, salvo el agregado de la 39. Ninguna
  decisión de corte cambia por este documento. Lo que cambia es **la salida de la jerarquía de
  modificadores** y **lo que pasa después de P11**.

### 15.4 Parches a `Knowledge-Deduccion-De-Reglas-De-Negocio.md`

Tres parches, y ninguno toca la lista de rótulos ni la de mecanismos. **Los tres son sobre el catálogo
de inconsistencias de §3.6**, que es donde el cuerpo metodológico trata la redundancia y la
incompletitud, y donde hoy las trata como defectos sin saber usarlas.

| # | Prio | Lugar | Qué hacer |
| --- | --- | --- | --- |
| **KD-a** | **P0** | §3.6, fila **I-07**, y la nota que sigue a la tabla | **Reformular I-07**, con el texto ya redactado en §11.4: el hallazgo pasa a ser **el desacuerdo entre reafirmaciones**, no la duplicación; la subsunción de pruebas queda como **uno** de los síntomas; y se agrega la salida que hoy no existe —**la reafirmación que cierra es un instrumento y se usa**, no un hallazgo—. **Se conserva entera** la nota vigente: nunca es motivo de borrado, y si una regla existe dice algo más que su vecina |
| **KD-b** | P1 | §3.6, nota de **I-06** | **Agregar una línea**, no una entrada: la intención de una palabra no verificable se recupera **triangulando** con las otras formulaciones del mismo concepto —en especial con la operacional, RF-5— **antes** de declararla irrecuperable y mandarla al cuestionario. I-06 ya ordena recuperar la intención; lo que le falta es **cómo** |
| **KD-c** | P1 | §3.6, fila **I-08**, y §3.3 | **Remisión cruzada, sin fusionar.** I-08 gana una línea: su hallazgo es el diagnóstico de **incompletitud** (peldaño E2 de `04` §13.6) aplicado a actos, y sale bajo `Propuesta` con el mismo respaldo que una premisa faltante. **No se fusiona con I-01/I-02 ni con la escalera**: el fundamento del veredicto está en §13.7 y es que el síntoma específico de cada entrada es lo que la vuelve buscable, y P-9 exige veredicto por entrada enumerable |

**Lo que expresamente no se propone**, para que no quede como olvido: **no se crea una entrada I-13
«pieza faltante»**. Sería una entrada que no se puede recorrer —«¿falta algo?» no es un síntoma— y
haría bajar la cobertura de las tres búsquedas que hoy sí se pueden declarar corridas.

---

## 16. Límites declarados

1. **La pasada produce inferencias, y eso no se arregla con procedimiento.** Todo lo que sale de P13
   es más débil que la letra, por construcción. Las cinco condiciones de admisión no la vuelven
   verdadera: la vuelven **auditable**, que es distinto y es lo máximo a lo que se puede aspirar.
2. **La lista de ocho señales está calibrada sobre dos párrafos** —el de la estancia y el del ejemplo
   integrado—. Es poco. La prueba de la lista es la tercera y la cuarta corrida: si aparecen
   afirmaciones distribuidas que ninguna señal disparó, la lista crece **con el análisis de por qué**,
   no por acumulación.
3. **La cota de señales es una heurística, no un teorema**, con la misma salvedad que la cota de
   atomización de `02` P11.5: detecta producción por fuera del barrido; no detecta una candidata mala
   que ocupe el lugar de una buena dentro de la cota.
4. **El límite de vecindad (A3) es arbitrario en su borde.** El párrafo es la unidad porque es donde
   el autor apoya una idea, pero hay enunciados donde la unidad es el apartado. Cuando se mueva, se
   mueve **explícitamente y en el encargo**, no a criterio de quien corre la pasada.
5. **La prueba de la negación (A5) depende de juzgar si dos oraciones se contradicen**, y eso no es
   mecánico en todos los casos. Es la más fuerte de las cinco y también la que más se degrada en manos
   apuradas.
6. **No se cotejó ninguna fuente académica.** Vale acá todo lo dicho en §0.2: los nombres de tradición
   son orientación, ninguna decisión operativa depende de que la atribución sea exacta, y si alguna
   está mal asignada lo que hay que corregir es el nombre, no el procedimiento.
7. **El caso del defecto 1 es uno solo.** La corrección del ámbito de contraste se funda en un caso
   real y en ejemplos construidos. Es suficiente para corregir algo que está demostradamente mal, y no
   es suficiente para afirmar que la jerarquía quedó completa.
8. **La sintonización no se corrió sobre un enunciado completo.** El banco de §14 tiene tres entradas
   de registro y un caso testigo. Es suficiente para mostrar que el procedimiento produce y que la
   escalera corrige un error real; no alcanza para saber cómo se comporta con veinte entradas y
   ciclos de verdad, que es donde el orden de resolución empieza a importar.
9. **El punto fijo de la propagación puede depender del orden, y el desempate determinista lo
   disciplina sin eliminarlo.** Dos lecturas pueden ser incompatibles por algo que los casilleros de
   compromisos no captan; ahí la propagación no tacha lo que debería y el resultado depende de qué se
   fijó antes. La mitigación es que **el orden queda anotado** y la corrida es repetible; la falla no
   desaparece, se vuelve visible.
10. **La lista de nueve orígenes de apertura (§12.2) es cerrada por decisión y depende de que los
    pasos anteriores dejen marca.** `AB-7` —las decisiones tomadas por indicio derrotable— exige un
    cambio de hábito en P5 y P5-bis que no está probado en ninguna corrida. Si no se anota, la
    cosecha queda incompleta y la sintonización no ve la mitad de lo que podría cerrar.
11. **La cota de una entrada abierta cada dos oraciones (§12.4) es un número inventado.** Su función
    —detener el análisis y devolver el texto— es correcta; el umbral hay que calibrarlo con corridas.
12. **La prueba E2 depende de la imaginación del analista**, y la asimetría es deliberada: quien no
    logra construir el caso declara contradicción, y quien construye un caso forzado declara
    incompletitud donde había conflicto. Se eligió el error hacia E2 porque su producto es una
    `Propuesta` con pregunta al autor —visible y barata de corregir—, mientras que el error hacia E3
    manda a descartar una afirmación verdadera. **Es una elección de error barato, no una garantía.**
13. **T-4 no está probado fuera del lenguaje.** La correspondencia con la segmentación de imágenes es
    una afirmación sobre la **forma** del procedimiento, hecha sin haberlo corrido sobre otro material.
14. **Este documento está sobre el techo de su categoría**, igual que su hermano: `Rules-Base-Conocimiento.md`
    §6.2 fija 600 líneas para un documento `propio`, y con la Parte III el documento las triplica. La
    deuda queda declarada y **empeoró a propósito**: la Parte III llegó después y partir el documento
    en el mismo movimiento habría dejado tres archivos sin control de cambios común. La partición
    razonable, cuando se haga, es **Parte I aparte** —modificadores, que es materia del paso 1— y
    **Partes II y III juntas** —las dos pasadas posteriores, que comparten rótulos, ficha y
    compuerta—. Esa decisión no se toma acá.
15. **No se probó en una corrida completa.** Lo que hay es el caso que originó el encargo, resuelto,
    dos casos observados que se usan como testigos, y un ejemplo construido para ejercitar las
    señales. La primera corrida real sobre un enunciado ajeno es la prueba de todo esto, y puede
    devolver que las pasadas producen demasiado poco —y entonces sobran condiciones— o demasiado —y
    entonces faltan—.

---

## 17. Control de cambios

| Versión | Fecha | Cambios |
| --- | --- | --- |
| 1.0 | 2026-09-26 | Emisión inicial. **Defecto 1:** dos ejes para el conjunto de contraste —referencial N1 a N4 y textual Á1 a Á5—, procedimiento de búsqueda en tres pasos, **regla del ámbito agotado**, criterio de corte de la búsqueda y qué vale como ejemplar; **indicio del paralelismo** con cuatro condiciones habilitantes, prueba del eje y seis casos de no aplicación, insertado como 2-bis con enmienda al indicio de unicidad; separación de **restringe** e **informa** en dos preguntas con su prueba cada una, **cuatro cuadrantes** con etiqueta y destino, contraprueba obligatoria para declarar epíteto; **adjetivo con dominio cerrado**, cinco señales de reconocimiento, tres desempates y las tres afirmaciones arrastradas con estatutos distintos —exhaustividad `Letra`, exclusividad `?`, clausura `Intención`—. **Defecto 2:** caracterización del fenómeno como **dos cosas encadenadas** —hiperonimia diferida, que es cohesión léxica observable, y composición de premisas, que es inferencia del analista—, con ocho candidatos de aparato evaluados y tres descartados con fundamento; tres clases AD-1, AD-2 y AD-3 con rótulo distinto; **pasada P13** en ocho pasos, con la propuesta original refutada en su formulación y sostenida en su lugar; **prueba de admisión de cinco condiciones**, con la supresión de premisa y la negación como filtros principales; criterio de corte con cota de señales; **mapeo a los rótulos existentes sin crear ninguno nuevo**, ficha `AD`, seis prohibiciones de la compuerta anti-fabulación y seis anti-patrones con su delator; **ocho señales textuales** sostenidas con análisis y tres descartadas; ejemplo integrado de otro dominio; **parches redactados** para los dos documentos hermanos, con cinco marcados P0 porque corrigen afirmaciones hoy vigentes. **Defecto 3, incorporado durante la redacción:** las cuatro tesis del autor evaluadas una por una —T-1 redundancia funcional, **aceptada con dos límites**; T-2 la redundancia como detector, **aceptada, y es la que más cambia el método**; T-3 el algoritmo, **diagnóstico aceptado y remedio literal refutado**, porque abrir lecturas donde no hay señal fabrica ambigüedad y porque el procedimiento **ya produce** la lista de lugares indecisos y sólo hay que dejar de tirarla; T-4 alcance, **arquitectura general, pruebas condicionadas, señales intransferibles**—. **Reafirmación** definida y separada de la segunda mención, con cinco formas y la **prueba de la discriminación** de tres resultados —adorno, triangula, discordia—. **Apertura selectiva por cosecha**, con nueve orígenes cerrados, lecturas escritas como **compromisos**, techo de dos y cota global con su diagnóstico. **Pasada P12 de sintonización** en siete pasos: tablero fijo, orden de resolución con **desempate determinista por orden de texto**, propagación con **descarte con causa**, tratamiento de ciclos —**un ciclo, una pregunta**— y **escalera de diagnóstico** con obligación de declarar el descarte de los peldaños anteriores. **Veredicto sobre unificar con I-08: se unifica el diagnóstico y el rótulo, no la búsqueda**, por enumerabilidad. **Realimentación P12↔P13 acotada a una vuelta declarada.** Banco de pruebas con las tres reafirmaciones del párrafo y el caso testigo de la actividad sin lotes. **Parches nuevos**: cuatro más a `02` —dos P0—, cuatro más a `03` —uno P0— y **tres a `Knowledge-Deduccion-De-Reglas-De-Negocio.md`**, con la **reformulación de I-07** redactada. |
