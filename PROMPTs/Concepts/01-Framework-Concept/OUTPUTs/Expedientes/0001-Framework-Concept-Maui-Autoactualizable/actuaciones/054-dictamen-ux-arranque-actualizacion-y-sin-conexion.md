| Campo | Valor |
|---|---|
| Tipo | dictamen |
| Fecha | 2026-10-30 |
| Autor | Mesa de experiencia de usuario y flujo |
| Expediente | 0001 · Framework Concept |
| Estado | borrador para el PO |

> **Rutas.** FC = `Lab-Documentos/Concepts/Framework-Concept`; src = `FC/Demo/src`; ACT = `Lab-Documentos.Documentacion/PROMPTs/Concepts/01-Framework-Concept/OUTPUTs/Expedientes/0001-…/actuaciones`.

# Arranque, actualización y sin conexión: qué ve el usuario en cada momento

## Lo que planteó el PO

El PO planteó cinco cosas el 2026-10-30:

1. Es normal y lógico que el primer arranque tarde, porque hay que instalar el contenido. Pregunta si se puede mejorar esa estrategia.
2. Qué pasa si al arrancar no hay conexión con el servidor. Pide una estrategia prolija, apoyada en lo que recomiendan las aplicaciones parecidas.
3. Cada vez que el usuario se loguea habría que verificar si hay actualizaciones, o si la versión del servidor es distinta, y recargar la aplicación. Como eso lleva tiempo, hay que **avisarle al usuario que se está actualizando**.
4. La pantalla en blanco se evita con un diseño que muestre que la app está trabajando, con un avance y una leyenda breve de lo que hace.
5. Los especialistas en experiencia de usuario y en flujo tienen que proponer alternativas y evaluarlas.

## Lo que hace hoy

| Momento | Comportamiento actual | Fuente |
|---|---|---|
| Primer arranque tras instalar | Instala y muestra la semilla firmada que viene en el APK, sin red, y consulta el canal en segundo plano. En el g42 midió **8 783, 7 930 y 8 572 ms**. | FC/00-Marco.md:94-100; ACT/053-constancia-v1s-semilla-del-apk.md:15-16 |
| Arranque normal | N = 0: no espera la red. Activa lo que haya en staging/ y muestra lo instalado. Midió **5 554, 5 064, 4 893 y 4 953 ms**. | ACT/035-informe-r2-jurado-veredicto.md:203,407; ACT/053:15-16 |
| Qué se ve mientras arranca | Una pantalla fija con el título «Framework Concept», un ActivityIndicator y «Arrancando…». No hay avance ni leyenda por etapa, y el contenido **aparece de golpe**. | src/FrameworkConcept.Shell/Pages/ArranquePage.xaml:10-12; ArranquePage.xaml.cs:67-86 |
| Sin red | La consulta devuelve SinRed y no bloquea. Aparecen dos bandas, «Sin conexión» y «Sin acceso al servidor», y lo cargado queda en el outbox. | src/FrameworkConcept.Core/Update/Actualizador.cs:360,437; FC/Developer-Guide.md:232,437 |
| Consulta del canal | Se hace al llegar Listo, o a los 10 s si no llega, una vez por proceso. Al reanudar, sólo si pasaron 15 minutos. | src/FrameworkConcept.Shell/Pages/ContenidoPage.xaml.cs:51-66; App.cs:24-33; Actualizador.cs:345-348 |
| Login | **No consulta.** P2 lo fija como disparador, pero `DisparadorDeConsulta.LoginExitoso` existe y nadie lo invoca. | src/FrameworkConcept.Core/Update/Resultados.cs:11-12; src/FrameworkConcept.Shell/Auth/SesionDelUsuario.cs:294 |
| Descarga y activación | La descarga va en silencio a staging/. Se activa en el próximo arranque en frío, una vez por proceso. **No hay ningún aviso**: sólo aparece en Diagnóstico. | src/FrameworkConcept.Shell/Actualizacion/ConsultasDelCanal.cs:7; DiagnosticoPage.xaml.cs:83; FC/01-Actualizacion-Sin-Tienda.md:111 |
| Rollback | Si no llega Listo en 2 cargas, vuelve a previous y marca la versión como fallida. El usuario no se entera. | FC/01-Actualizacion-Sin-Tienda.md:171-193; ContenidoPage.xaml.cs:107-123 |
| Pantallas de excepción | EstadoTerminalPage (con «Reintentar ahora» y «Diagnóstico») y WebViewViejoPage. | ArranquePage.xaml.cs:90-112; EstadoTerminalPage.xaml:11-16 |

**Qué fija la norma P2 (folio 035).** Fija cinco cosas:
- N = 0 al abrir.
- Tres disparadores: arranque, reanudación a los 15 minutos y login.
- **Una sola regla de activación**: el próximo arranque en frío.
- El rollback por marca.
- La política para lo obligatorio y para un cascarón viejo.

Descartó dos cosas: la espera acotada al abrir (F3) y el login como punto de activación (H-04) (ACT/035:176,203,400-419). **La presentación queda libre**: P2 no regula qué se ve, qué se avisa ni cómo.

## Lo que recomiendan aplicaciones similares

| Referencia | Qué recomienda | Qué tomamos | Fuente |
|---|---|---|---|
| Expo Updates | `checkAutomatically` vale ON_LOAD por omisión. `fallbackToCacheTimeout` vale 0, así que nunca bloquea el arranque y usa lo que está en el dispositivo. | Consultar siempre, sin esperar al abrir. | https://docs.expo.dev/versions/latest/config/app/; ACT/018:45-47 |
| CodePush (retirado) | `installMode` vale ON_NEXT_RESTART por omisión. `mandatoryInstallMode` vale IMMEDIATE. `checkFrequency` puede ser ON_APP_START u ON_APP_RESUME. | Lo normal se aplica de forma diferida; sólo lo obligatorio es inmediato. | https://github.com/microsoft/react-native-code-push/blob/master/docs/api-js.md; ACT/018:100-101 |
| Capawesome Live Update | Consulta al arrancar y al reanudar, cada más de 15 minutos. Usa `readyTimeout` para volver al paquete por defecto. `reload()` descarta la memoria, así que conviene llamarlo en un momento seguro. | El aviso aparece en un momento seguro y nunca en medio de un formulario. | https://capawesome.io/docs/plugins/live-update/ |
| Android in-app updates | El modo *flexible* descarga en segundo plano y ofrece reiniciar. El modo *immediate* ocupa la pantalla completa y bloquea; se reserva para cambios críticos. | Dos niveles: normal y obligatoria. | https://developer.android.com/guide/playcore/in-app-updates |
| Service worker | La versión nueva queda en espera (*waiting*) mientras la actual sigue funcionando, y se activa por una acción del usuario (`skipWaiting`). | «Reiniciar ahora» queda a elección del usuario. | https://web.dev/articles/service-worker-lifecycle |
| NN/g, tiempos de respuesta | 0,1 s se percibe instantáneo. Pasado 1 s hay que mostrar que el sistema trabaja. Pasados 10 s hay que mostrar porcentaje y dar una forma de interrumpir. | Leyenda a partir de 1 s; salida a partir de 10 s. | https://www.nngroup.com/articles/response-times-3-important-limits/ |
| NN/g, pantallas esqueleto | Entre 2 y 10 s conviene un esqueleto de la página que viene. Por encima de 10 s, una barra con estimación. El esqueleto tiene que coincidir con la estructura real. | Esqueleto de la primera pantalla en el arranque normal. | https://www.nngroup.com/articles/skeleton-screens/ |
| Apple HIG, lanzamiento | La pantalla de lanzamiento se parece a la primera pantalla real y no lleva «cargando» (*paráfrasis, falta confirmar el texto*). | La capa nativa pasa a ser ese esqueleto. | https://developer.apple.com/design/human-interface-guidelines/launching |
| Material 3 | Indicador determinado si se conoce el total; indeterminado si no (*criterio general, sin extracto confirmado*). | Bytes y pasos medidos, determinado; base y sesión, indeterminado con leyenda. | https://m3.material.io/components/progress-indicators/guidelines |

Ningún producto ofrece «al login» como modo con nombre: se arma a mano (ACT/018:217-218). Este dictamen lo arma así: **consulta al loguearse, aplicación diferida**.

## Alternativas evaluadas

Llegaron tres propuestas. La tercera se evaluó en sus dos variantes. La escala va de 1 a 10; en costo, 10 es lo más barato. Cada celda muestra los puntajes de los tres jurados: robustez, norma y costo.

| Alternativa | Claridad | Espera percibida | Robustez sin red / fallos | Encaje con P2 | Costo | Veredicto |
|---|---|---|---|---|---|---|
| UX-T «Transparencia y progreso» | 8 · 9 · 9 | 7 · 8 · 8 | 8 · 7 · 8 | 9 · 8 · 7 | 5 · 5 · 5 | **Se adopta su presentación** |
| «Nunca bloquear» (3 niveles) | 7 · 8 · 8 | 8 · 9 · 9 | 9 · 8 · 9 | 8 · 8 · 7 | 5 · 5 · 6 | **Se adopta como flujo base, con 2 niveles** |
| L: «verificar al loguearse», descargar y recargar antes de entrar | 8 · 7 · 7 | 3 · 4 · 5 | 5 · 5 · 7 | 3 · 5 · 4 | 6 · 6 · 4 | **Descartada para el caso normal**. Su pantalla de avance se usa sólo para la obligatoria |
| A: «consultar al loguearse, aplicar sin recargar en caliente» | 8 | 8 | 8 | 6 | 6 | **Se adopta la consulta y el aviso**; la recarga automática en el login queda para que decida el PO |

**Objeciones que cambiaron el diseño:**
- **No se suma espera al login.** La regla de UX-T que esperaba hasta 3 s en cada login se elimina: el login no espera, y el tope de 3 s sólo vale para la consulta, en segundo plano.
- **Pasos con pesos medidos.** Una barra de 4 pasos con pesos fijos se quedaría en «2/4» casi todo el primer arranque. Los pesos se miden en el g42, o el avance se cuenta por archivo.
- **Leyenda fija.** Tres leyendas que rotan en 5 s no se alcanzan a leer. Aparece una sola, cuando una etapa pasa de 1 s.
- **Se descarta el nivel «recomendada».** El usuario no lo distingue del normal, y Android tiene sólo dos niveles.
- **Reinicio de proceso real.** «Reiniciar ahora» relanza la app y termina el proceso. Recrear la Activity o la Window **no** es un arranque en frío, porque la activación corre una vez por proceso (ContenidoPage.xaml.cs:51-66). Hecho así, no hace falta un ADR sobre H-04.
- **Sin red nunca se bloquea**, ni siquiera con una obligatoria. Se elimina `permiteSinConexion` como vía de bloqueo (ACT/035:413-419).
- **Avisos nativos.** Los avisos de rollback y de versión lista son nativos y no se pintan en Blazor, porque si el contenido falla no aparecerían.
- **Inicio tras rollback.** Después de un rollback, la app vuelve al inicio y no a la ruta restaurada.
- **Sin promesas que dependen de la red.** Se elimina «Ya avisamos al equipo».
- **Integridad de la semilla.** La semilla perezosa no se adopta mientras pueda servirse algo sin verificar.

## Recomendación: flujo por escenario

El flujo base es «Nunca bloquear» con dos niveles, normal y obligatoria, y lo vestimos con la presentación de UX-T. El nivel lo marca el servidor en el manifiesto firmado. **No cambian** N = 0, la regla única de activación ni el outbox.

### 1. Primer arranque tras instalar

1. Splash del SO con el color de fondo de la app, sin animación.
2. Pantalla nativa de preparación con pasos. El avance se cuenta por archivos de la semilla o con pesos medidos en el g42.
3. Al llegar Listo, el esqueleto se funde con el contenido en 200 ms. La consulta del canal sigue en segundo plano, sin mostrar nada.
4. Si pasa de 10 s, la leyenda cambia a «Casi listo…» y aparece «¿Tarda demasiado? Ver detalle», que abre Diagnóstico.
5. Si no hay red, todo sigue igual, porque la semilla alcanza. Sólo aparece la banda de conectividad ya dentro del contenido.
6. En el primer login no se descarga nada delante del usuario, salvo una obligatoria.

```
+--------------------------------+
|        [icono de la app]       |
|      Preparando la app         |
|                                |
|  ███████████░░░░░░░░  2 de 4   |
|  Instalando el contenido       |
|  incluido…                     |
|                                |
|  Esto pasa sólo la primera vez.|
|  No necesita conexión.         |
+--------------------------------+
```
Leyendas en orden: «Abriendo el almacenamiento seguro…», «Instalando el contenido incluido…», «Verificando la firma…», «Preparando la primera pantalla…». Pasados 10 s: «Casi listo…» y «¿Tarda demasiado? Ver detalle».

**Mejoras de estrategia para medir:**
- Abrir la base mientras se instala la semilla.
- Mostrar el esqueleto real desde el paso 2.
- Llamar a `reportFullyDrawn` en Listo para medir el TTFD real (ACT/034:280-298).

### 2. Arranque normal

1. La capa nativa es el **esqueleto de la primera pantalla Blazor**: encabezado, bandas y tarjetas grises. Sus colores y alturas salen de tokens compartidos con el contenido.
2. Si una etapa pasa de 1 s, aparece una leyenda fija con un indicador fino indeterminado. No lleva porcentaje.
3. Si hay algo en staging/, se activa antes de mostrar y la leyenda dice «Aplicando la versión 1.4.0…».
4. Al llegar Listo, el fundido dura 200 ms. Nunca aparece de golpe.

```
+--------------------------------+
| ▓▓▓▓▓▓▓▓▓▓▓▓      ▓▓▓          |
|--------------------------------|
| ┌────────────┐ ┌────────────┐  |
| │░░░░░░░░    │ │░░░░░░░░    │  |
| │░░░░        │ │░░░░        │  |
| └────────────┘ └────────────┘  |
| ~~~~~~~~ (indeterminado) ~~~~~ |
| Recuperando tu sesión…         |   <- sólo si la etapa pasa de 1 s
+--------------------------------+
```
Leyendas: «Abriendo tus datos…», «Recuperando tu sesión…», «Cargando pantallas…», «Aplicando la versión X.Y.Z…». Después de activar, un aviso nativo aparece una sola vez durante 4 s: «Actualizado a 1.4.0», con «Ver novedades» sólo si la versión trae novedades visibles.

### 3. Sin conexión

1. El arranque no se entera de la red, porque N = 0.
2. Las dos bandas actuales se reemplazan por **una sola banda ámbar** con el contador del outbox. Al tocarla se abre el detalle.
3. La app reintenta en silencio cuando el SO avisa que volvió la conectividad. Al reconectar, la banda pasa a verde durante 3 s, se envía el outbox y se lanza la consulta.
4. Si la sesión del servidor venció y no hay red, se trabaja contra el outbox con la sesión local desbloqueada. Nunca se borra lo pendiente.
5. Si hay una obligatoria pendiente, se entra igual, con un aviso persistente.

```
| ⚠ Sin conexión · versión 1.3.2 guardada · tus cambios se envían al volver · Por enviar: 2 |
```
Variantes:
- Hay red pero no servidor: «Servidor no disponible · seguís trabajando con lo guardado».
- Al reconectar: «Conectado · enviando 2 pendientes…», y después «Todo enviado».
- Sesión vencida: «Volvé a conectarte para renovar tu sesión».
- Obligatoria pendiente: «Hay una actualización obligatoria pendiente. Se instalará cuando haya conexión.».

### 4. Login con versión nueva (pedido 3 del PO)

1. Cuando la autenticación del SO responde bien, se invoca `DisparadorDeConsulta.LoginExitoso` (SesionDelUsuario.cs:294). **El ingreso no espera**: el manifiesto tiene un tope de 3 s y la consulta corre en segundo plano.
2. Un chip en la cabecera aparece sólo si hay algo que contar: «Descargando actualización 3,2 de 9 MB», con un anillo determinado. Si la versión está al día o no hay red, no se muestra nada intrusivo.
3. Una versión **normal** se descarga y se verifica en segundo plano. Después aparece una tarjeta nativa descartable, **en un momento seguro**: una pantalla de reposo, nunca con un formulario sin guardar.
4. **«Reiniciar ahora»** guarda el estado, relanza la app y termina el proceso, con lo que pasa por el arranque en frío de P2. La sesión se restaura desde el almacén seguro, y la autenticación del SO se vuelve a pedir sólo si la política de sesión lo exige. **«Más tarde»** deja la versión para el próximo arranque en frío, y la tarjeta no se repite hasta el próximo login.
5. Si el canal responde que la versión es obligatoria, se pasa al escenario 5.

```
C' chip (contenido en uso)
| Encuesta …              (◔) 3,2 / 9 MB |

C'' tarjeta (abajo, se puede descartar)
+--------------------------------+
| La versión 1.4.0 está lista.   |
| Se aplica al reiniciar         |
| (unos 5 s).                    |
| Tenés 2 envíos pendientes;     |
| se conservan.                  |
|  [Más tarde]  [Reiniciar ahora]|
+--------------------------------+

Reinicio controlado
+--------------------------------+
|     Actualizando a 1.4.0       |
|  ████████████░░░░░░   2 de 3   |
|  Aplicando…                    |
|  Tus datos se conservan.       |
+--------------------------------+
```
Leyendas del reinicio: «Verificando firma…», «Aplicando…», «Abriendo…».

### 5. Actualización obligatoria

1. Se detecta en el arranque o en el login, siempre con red, o cuando la API responde «contenido no soportado».
2. Primero se intenta enviar el outbox. Si falla, porque la sesión venció o el servidor rechaza, el envío **se difiere y no se descarta nada**.
3. Pantalla nativa completa con barra determinada por bytes y una leyenda por fase. Termina en un arranque en frío (ACT/035:413-419).
4. Si la descarga se corta, se descarta lo parcial. Staging se activa sólo con el paquete completo y la firma verificada. La reanudación por rangos está NO VERIFICADA.
5. Si el cascarón está por debajo de la versión mínima: In-App Updates immediate en Play, o una pantalla propia que lleva a la tienda (FC/00-Marco.md:149-156).

```
+--------------------------------+
|    Actualización necesaria     |
| Esta versión es necesaria para |
| seguir conectado con el        |
| servidor.                      |
|                                |
| ████████░░░░░░░░░░  35 %       |
| Descargando · 3,2 de 9 MB      |
| Tus datos se conservan.        |
+--------------------------------+
```
Fases: «Enviando tus 2 cambios pendientes…», «Descargando · X de Y MB», «Verificando firma…», «Instalando…», «Reiniciando la app…».
Corte: «Se cortó la descarga. Seguís con la 1.3.2 y se reintenta al volver la red.» [Reintentar] [Seguir con 1.3.2].
Cascarón viejo: «Hace falta actualizar la app desde la tienda para continuar.» [Actualizar en la tienda].

### 6. Fallo y rollback

1. Se mantiene la marca de 2 cargas sin Listo (ContenidoPage.xaml.cs:107-123). En la segunda carga, la leyenda del esqueleto dice «Volviendo a la versión anterior que funcionaba…».
2. Se persiste el flag `rollbackNoNotificado`. Ya en el contenido, un aviso nativo aparece **una sola vez** y la app abre en el inicio.
3. La versión fallida no se vuelve a ofrecer hasta que el servidor publique otra.
4. Si no hay ningún contenido sano, se muestra EstadoTerminalPage con texto llano.

```
G rollback
+--------------------------------+
| La versión 1.4.0 no arrancó    |
| bien y volvimos a la 1.3.2.    |
| Tus datos están intactos.      |
|     [Ver detalle] [Entendido]  |
+--------------------------------+

H terminal
+--------------------------------+
|     No pudimos abrir la app.   |
| No hay una versión del         |
| contenido que funcione.        |
| [Diagnóstico] [Reintentar ahora]|
+--------------------------------+
```

### Reglas de redacción y presentación

| Regla | Contenido |
|---|---|
| R1 | Nunca hay pantalla en blanco ni contenido que aparece de golpe. Toda espera de más de 1 s dice qué se está haciendo (NN/g). |
| R2 | El indicador es determinado sólo con un total conocido (bytes o pasos medidos). En los demás casos, indeterminado con leyenda. |
| R3 | Por encima de 10 s: porcentaje o estimación, más una salida («Ver detalle», «Seguir con 1.3.2»). |
| R4 | Las leyendas van en gerundio, con un máximo de 40 caracteres, sin jerga y sin «error» ni códigos. Lo técnico va a Diagnóstico. |
| R5 | Siempre se dice qué pasa con los datos: «se conservan», «se envían al volver», «intactos». |
| R6 | El usuario ve la versión con su número legible (1.4.0). El hash queda sólo en Diagnóstico. |
| R7 | Cada aviso aparece como máximo una vez por versión. «Más tarde» no se repite hasta el próximo login o arranque. |
| R8 | Ámbar para sin red, verde transitorio al reconectar y rojo sólo para la pantalla terminal. |
| R9 | Accesibilidad: cada leyenda se anuncia con SemanticProperties (MAUI) o una live region (Blazor), se respeta «reducir movimiento» y el contraste es AA. |

## Qué cambia en la demo y en la norma

**En la demo** (sólo como propuesta; esta mesa no escribe en el repo):

1. **ArranquePage** (ArranquePage.xaml:10-12, .xaml.cs:67-86): tiene dos modos, preparación con pasos y esqueleto con leyenda. Cada etapa publica un `IProgress<EtapaDeArranque>`. El paso a ContenidoPage es un fundido.
2. **Login**: invoca al Actualizador con `LoginExitoso` y un tope de 3 s sin bloquear. Hay que corregir el comentario «En la demo no hay login» (Resultados.cs:11-12).
3. **Servicio observable `EstadoDeActualizacion`**, con estos estados: AlDia, Descargando(bytes), Lista(versión), Obligatoria(motivo), SinRed y Rollback(de, a). El Actualizador y ConsultasDelCanal informan los bytes (hoy la descarga es silenciosa: ConsultasDelCanal.cs:7).
4. **Avisos nativos superpuestos**: el chip, la tarjeta «lista», el aviso «actualizado» y el aviso de rollback. No necesitan un puente hacia Blazor para funcionar.
5. **Reinicio de proceso real** para «Reiniciar ahora» y para la obligatoria, con la sesión restaurada desde el almacén seguro.
6. **Banda única de conectividad**, que reemplaza las dos actuales (Developer-Guide.md:232,437) y se suscribe al evento de conectividad del SO.
7. **Manifiesto firmado**: suma el campo `nivel` (normal | obligatoria), un `motivo` y el tamaño en bytes. No se agregan «recomendada» ni `permiteSinConexion`.
8. **Activación atómica** de staging y flag `rollbackNoNotificado`.
9. **`reportFullyDrawn` en Listo** (U1).

**En la norma P2: no se reabre.**
- N = 0, los tres disparadores y la regla única de activación quedan como están.
- La consulta al loguearse ya estaba fijada; sólo falta implementarla.
- «Reiniciar ahora», hecho como reinicio de proceso, *es* el próximo arranque en frío.
- Se agrega un ADR **aditivo** de presentación con R1–R9, el nivel en el manifiesto y la regla «sin red nunca se bloquea, ni con una obligatoria». No cambia ninguna regla de P2.
- Queda fuera de esta entrega: la aplicación al reanudar después de 15 minutos (sería una segunda regla) y el nivel «recomendada».

## Cómo se valida

**Medición en el g42** (con capturas de cada pantalla, según la regla de evidencia):

| Escenario | Qué se mide | Criterio |
|---|---|---|
| Primer arranque tras instalar | Tiempo hasta Listo, peso real de cada paso y TTFD con `reportFullyDrawn` | La barra no se queda quieta más de 3 s. No aparece de golpe. |
| Arranque normal: esqueleto frente a capa estática | TPR, TTFD y cuándo aparece la leyenda | Hay fundido. La leyenda aparece sólo cuando una etapa pasa de 1 s. |
| Modo avión y servidor caído | Que la banda distinga la causa, el outbox y la reconexión | Nunca bloquea. El texto cambia según la causa. |
| Login con versión normal | Tiempo agregado al ingreso, chip y tarjeta | **0 s** de espera agregada al login. |
| «Reiniciar ahora» | Tiempo del reinicio de proceso y cómo vuelve la sesión | Unos 5 s. Se activa staging y el outbox queda intacto. |
| Red lenta (1,5 Mbps) y descarga cortada | Avance por bytes y descarte de lo parcial | Nunca queda staging a medias. |
| Obligatoria con y sin red | Envío previo del outbox, fases y comportamiento sin red | Sin red se entra con lo instalado. |
| Versión rota | Dos cargas, rollback, aviso único y vuelta al inicio | El aviso aparece una sola vez. |
| Sesión vencida sin red | Banda de renovación y outbox | No se pierde nada. |

Las cifras de red y de recarga que figuran en las propuestas son **ESTIMADAS, NO MEDIDAS**. Esta corrida las reemplaza.

**Prueba con usuarios** (5 personas, que según NN/g alcanzan para encontrar la mayoría de los problemas de usabilidad):
- Tareas: instalar y abrir; abrir sin red y cargar una encuesta; loguearse con una versión nueva y decidir; vivir una obligatoria; vivir un rollback.
- Preguntas posteriores a cada tarea: «¿Qué estaba haciendo la app?», «¿Se perdió algo?», «¿Tuviste que hacer algo?».
- Éxito: 4 de 5 personas explican la espera con palabras propias y ninguna cree que perdió datos.

## Lo que decide el PO

1. **Recargar en el login sin preguntar cuando la versión ya está verificada en staging.** Cuesta unos 3–5 s más ese login, con la leyenda «Aplicando la versión X…».
   - *A favor:* responde literalmente a su pedido de «recargar al loguearse».
   - *En contra:* hay que hacerlo con un reinicio de proceso para no tocar H-04, y si esa versión falla, falla justo al entrar.
   - La mesa recomienda **no hacerlo por omisión** y ofrecer la tarjeta.
2. **La variante L completa (descargar y recargar antes de entrar), sólo para la obligatoria.** La mesa la recomienda así. En el caso normal queda descartada, porque cuesta de 5,5 a 37 s estimados en la puerta.
3. **Volver a pedir la autenticación del SO después de «Reiniciar ahora».** Depende de la política de sesión.
4. **Si el ADR de presentación entra como ADR propio del Framework Concept** o como anexo de P2.
5. **Prioridad.** Esto mejora la *percepción*, pero los ~5 s del arranque nativo (base, claves y sesión) siguen siendo el problema de fondo. Falta decidir si se atacan en paralelo.

## Pase

- Al PO: los cinco puntos de decisión de arriba.
- Después de su ok: un expediente de implementación con las 9 piezas de la demo y el ADR aditivo de presentación.
- A la mesa de medición: la matriz del g42 y la prueba con usuarios. Las cifras estimadas no se citan como medidas hasta tener esa corrida.
- Pendientes de confirmar en las fuentes: el texto literal de Apple HIG (lanzamiento) y de Material 3 (indicadores).