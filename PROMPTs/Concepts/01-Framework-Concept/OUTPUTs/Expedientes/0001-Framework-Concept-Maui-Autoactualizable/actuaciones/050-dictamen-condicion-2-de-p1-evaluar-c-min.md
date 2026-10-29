| Campo | Valor |
|---|---|
| Tipo | dictamen |
| Fecha | 2026-10-29 |
| Autor | Mesa evaluadora |
| Asunto | Condición de revisión (2) de P1: el TPR en el g42 supera los 5 000 ms |
| Antecedentes | EXP/035 (veredicto de la ronda 2, P1 «modificado»), EXP/036 (aprobación del PO), constancia 049, `Ensayos/E03-Red-Y-Autenticacion/P1-TPR-G42.md` |

> Las rutas son relativas a `PROMPTs/Concepts/01-Framework-Concept/OUTPUTs/`. EXP significa `Expedientes/0001-Framework-Concept-Maui-Autoactualizable/actuaciones/`. Las rutas del código son relativas a `Concepts/Framework-Concept/Demo/src/` del repo Lab-Documentos.

# Dictamen sobre la condición de revisión (2) de P1: evaluar C-min

## Hecho

- **P1 vigente.** El modelo es «pantallas Blazor WebAssembly descargables más encuestas como datos». Corre sin AOT, con un solo HybridWebView y sin BlazorWebView (EXP/035-informe-r2-jurado-veredicto.md:305-321). El PO lo aprobó (EXP/036-providencia-respuesta-del-po-al-lote-de-la-ronda-2.md:13,21).
- **Método del umbral** (EXP/035:325-337):
  - La métrica TPR es la marca JS del primer render de Blazor. El reloj cuenta desde `Process.StartElapsedRealtime`.
  - Se mide en arranque en frío (`am force-stop` y después `am start -W`), con el contenido ya instalado.
  - El teléfono de medida es un moto g42.
  - El estadístico es el máximo de 5 corridas, y el umbral es de 5 000 ms o menos.
- **Medición del 2026-10-29** (constancia 049; `Ensayos/E03-Red-Y-Autenticacion/P1-TPR-G42.md:64-80`). Con el APK Release, las 5 corridas dieron **9 152, 7 309, 6 940, 6 928 y 6 874 ms**. El máximo es 9 152 ms, así que **no cumple**.
- **Qué manda la condición (2)** (EXP/035:366-368): si el TPR supera los 5 000 ms, «se evalúa C-min con E02-B como base». Pide evaluar, no adoptar. Pasar a C-min lo dispara solo la condición (1): que el PO responda que el costo no convence (EXP/035:365-366).
- **Qué es C-min** (EXP/034-informe-r2-analisis-de-decisiones.md:125): la encuesta viaja como datos versionados y la dibujan componentes Razor compilados en el cascarón, dentro de un BlazorWebView. Las demás pantallas quedan compiladas.
  - En el g42, E02-B midió entre 1 615 y 1 723 ms (EXP/034:162).
  - La matriz de la ronda 2 le da 26 puntos, contra 13 de A+datos (EXP/035:354).
  - Se descartó porque pierde las pantallas actualizables (EXP/035:358-359).

## Desglose del TPR

El cascarón pone las marcas `t=` con el mismo origen que el TPR (`FrameworkConcept.Shell/Bitacora.cs:13`; `Pages/ContenidoPage.xaml.cs:89,102-103`). El hito de inicio de carga es `req#1 GET /index.html` y no «carga iniciada», porque esa línea se escribe después de un guardado asíncrono en la base (`ContenidoPage.xaml.cs:105-115`).

Los tramos, en ms, salen de `Ensayos/E03-Red-Y-Autenticacion/p1-tpr-g42-cascaron-release-logcat.txt`, líneas 1-309:

| Corrida | A proceso→pantalla visible | B →ContenidoListo | C →HybridWebView agregado | D →req#1 | E pedidos `_framework` | F →primer render | TPR |
|---|---|---|---|---|---|---|---|
| R1 | 877 | 4 820 | 190 | 527 | 463 | 2 275 | 9 152 |
| R2 | 709 | 2 434 | 865 | 416 | 455 | 2 430 | 7 309 |
| R3 | 583 | 2 381 | 923 | 376 | 459 | 2 218 | 6 940 |
| R4 | 602 | 2 435 | 891 | 377 | 332 | 2 291 | 6 928 |
| R5 | 579 | 2 322 | 930 | 376 | 407 | 2 260 | 6 874 |

Las sumas cierran exactas. Por ejemplo, en R5: 579 + 2 322 + 930 + 376 + 407 + 2 260 = 6 874.

Lectura del desglose:

- **El tramo nativo pesa más que el WASM.** A, B, C y D no dependen de WASM y suman entre 4,2 y 4,6 s, cerca del 60 % del TPR. E y F son el costo propio de WASM: entre 2,6 y 2,9 s, cerca del 40 %.
- **El tramo B se lleva unos 1,6 s antes de comprobar el esquema de la base.** De pantalla visible a «db: esquema comprobado» van, por ejemplo, 2 310 − 709 = 1 601 ms (logcat:64-65). La sesión y las claves suman entre 330 y 400 ms, y el actualizador entre 345 y 445 ms.
- **R1 es la primera corrida después de instalar, y por eso fija el máximo.** En R1, B incluyó crear la base (t=3 090) y activar la semilla, que sola tardó 5 694 − 4 081 = 1 613 ms (logcat:2,6,7). El WebView recién arrancó en t=5 887.
- **F es el runtime Mono-WASM en modo intérprete más el primer render.** El contenido se compila sin AOT y sin compresión (`FrameworkConcept.Content/FrameworkConcept.Content.csproj:18,22`). Antes de la marca, el primer render espera el saludo del puente (`Content/Layout/MainLayout.razor:73-83`).
- **Cota firme.** Aunque E y F valieran cero, R5 quedaría en 6 874 − 407 − 2 260 = **4 207 ms**. Ningún cambio de renderizador baja de ahí sin tocar el tramo nativo.
- **El emulador no sirve para este ensayo.** Su tramo B va de 4,2 a 6,2 s (`p1-tpr-emulador-2-logcat.txt`), muy por encima del teléfono.

## Alternativas evaluadas

Tres jurados con lentes distintas (fidelidad a las cifras, fidelidad a la norma, costo y reversibilidad) llegaron a la misma ganadora. Los puntajes van de 1 a 5, en el orden norma / evidencia / costo-riesgo.

| Alternativa | Qué hace | TPR estimado (no medido) | Norma | Puntajes | Objeción principal |
|---|---|---|---|---|---|
| **C-min tal cual** | BlazorWebView con una RCL de encuesta y la definición firmada sobre el núcleo común. Quita E y F. | En régimen, de 3,8 a 4,8 s. En R1, de 5,2 a 6,3 s sin aliviar B. | Cambia P1, deja P2 a medias (la clase contenido y el rollback quedan sin uso) y transforma P3. | 2 / 2–3 / 2 | Su piso es 4 207 ms y R1 no cumple. Obliga a redefinir la métrica, pierde las pantallas actualizables (EXP/036:21) y la mejora de B le sirve igual a A+datos. |
| **A+datos con arranque solapado** | El WebView arranca en paralelo con `PrepararAsync`. Usa un puntero `activa.json` y sirve la semilla desde el APK. | En régimen, de 4,3 a 4,7 s según la propuesta, pero R2 sin penalización ya da 709 + 865 + 416 + 455 + 2 430 = 4 875 ms. En R1, de 4,8 a 5,3 s. | Conserva P1 y P3. El puntero abre una segunda fuente de verdad frente al rollback de P2. | 4 / 3 / 3 | Supone que C baja a unos 0,2 s, y ese valor de R1 no tiene causa explicada. |
| **Arranque superpuesto (ganadora)** | El HybridWebView se adjunta debajo de la pantalla nativa de arranque desde el principio. El cascarón retiene la respuesta a `bridge.handshake` hasta terminar `PrepararAsync`. La sesión, las claves y el actualizador pasan a segundo plano. La semilla de fábrica va firmada, con Listo y pendiente. | Corrida por corrida, sin penalización: 4 875 / 4 559 / 4 493 / 4 552 ms. Con penalización por CPU de 0 a 400 ms, de 4,5 a 5,3 s. En R1, unos 4 332 ms con C=190, o unos 5 072 con C=930. | No cambia P1, ni el contrato de P3, ni la métrica, ni el reloj. P5, P12 y P13 quedan intactos. | 5 / 4 / 4 | Queda en el borde. Hay que verificar que Chromium no frene un WebView tapado, y la penalización por CPU es un supuesto. |

Las tres descartan de forma explícita los atajos que solo mejorarían el número: el primer render en HTML estático y C-min solo para la primera pantalla. No cuentan para el TPR, que exige el render de Blazor (EXP/035:325-337), o meten un segundo renderizador, que ya se descartó (EXP/035:358-363).

## Recomendación

1. **La condición (2) se da por cumplida con esta evaluación.** C-min no se adopta. Con las cifras medidas no resuelve el problema, porque el tramo nativo deja el piso en 4 207 ms y su propio cálculo para R1 (de 5,2 a 6,3 s) no cumple el umbral. Además rompe un P1 que el PO aprobó.
2. **P1 se mantiene.** La mesa recomienda atacar el tramo nativo con el **arranque superpuesto**, como ajuste del anfitrión bajo P1. No cambian el modelo, el contrato del puente ni la métrica.
3. **No se afirma que cumpla.** Las estimaciones quedan en el borde del umbral, entre 4,5 y 5,3 s. Hay que medirlo en el g42 antes de cerrar.
4. **C-min sigue como salida medida.** Si el arranque superpuesto no alcanza, se mide C-min con el mismo cascarón y el mismo reloj, y vuelve al PO con su precio funcional explícito.
5. **El núcleo común no se toca** (EXP/035:344-347). Cambiar de rama no tira trabajo.

## Experimento siguiente (E04)

Se mide con el mismo método del folio 049:

- moto g42, APK Release;
- `am force-stop` y después `am start -W`;
- 5 arranques en frío con la pantalla encendida;
- TPR escrito por el cascarón y estadístico máximo contra 5 000 ms.

Va en una rama descartable del Demo.

| Variante | Contenido |
|---|---|
| **V1** | El HybridWebView se adjunta a tamaño completo en ArranquePage, debajo de la capa nativa, y navega en `OnAppearing`. El cascarón retiene la respuesta al saludo hasta terminar `PrepararAsync`. La versión activa se sigue leyendo de la base, sin puntero. |
| **V2** | V1, más la sesión, las claves y el actualizador fuera del camino crítico, más `InvariantGlobalization` (mejora aceptada y sin medir, EXP/021-informe-jurado-veredicto.md:368-371). |
| **R1 aparte** | La app recién instalada, con la semilla de fábrica firmada servida desde el APK. |
| **Control** | C-min (la RCL de E02-B en un BlazorWebView) sobre el mismo cascarón, con la marca en `OnAfterRenderAsync(firstRender)` del componente raíz. |

**Hitos nuevos en la bitácora:** «HybridWebView adjunto», `req#1`, «último `_framework`», «saludo recibido» y «saludo respondido». Con ellos se separa la competencia por la CPU de la espera del saludo.

**Criterio:**

- **Máximo de 5 corridas, con R1 incluido, de 5 000 ms o menos en V1 o V2:** se documenta como ajuste del anfitrión bajo P1 y la condición (2) se cierra.
- **V2 por encima de unos 5,3 s:** la palanca que queda es la apertura de SQLite o el propio WASM, y se lleva al PO la comparación con el control C-min.

**Evidencia:** los logcats de cada serie y una constancia nueva en E04. La constancia deja escrito que la marca y el reloj no cambiaron.

## Lo que decide el PO

1. Si aprueba que la condición (2) se responda con el experimento E04 sobre el mismo modelo, en lugar de pasar a C-min.
2. Si acepta la semilla de fábrica firmada dentro del APK como versión implícita del primer arranque, con su Listo y su pendiente bajo P2.
3. Si acepta `InvariantGlobalization` en V2, que obliga a resolver los formatos de es-AR en el cascarón o con un formateo propio.
4. Si E04 no cumple: elegir entre C-min, que pierde las pantallas actualizables sin tienda, o revisar el umbral (decisión del PO, `Ensayos/E03-Red-Y-Autenticacion/P1-TPR-G42.md:79-80`).

## Pase

Al PO, para resolver los puntos de «Lo que decide el PO». Con su respuesta, la mesa construye E04 en una rama del Demo, lo mide en el g42 y eleva la constancia y el dictamen final de la condición (2).