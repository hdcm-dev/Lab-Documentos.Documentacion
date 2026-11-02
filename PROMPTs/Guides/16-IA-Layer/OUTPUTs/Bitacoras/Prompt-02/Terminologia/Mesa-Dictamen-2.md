# Mesa «cascarón» — Dictamen 2 (arquitectura .NET MAUI e híbridas)

> Dictamen ciego, 2026-11-01. Especialista: arquitectura .NET MAUI e híbridas (Capacitor, Cordova, Blazor Hybrid, HybridWebView).
> Insumos: `Termino-Cascaron.md` (TC) y `Respuesta-FC-2026-11-01.md` (RFC), ambos en esta carpeta.

## Veredicto

**Opción B + Y.**

- **Término principal:** «contenedor nativo» (en: *native wrapper*; *native shell* se acepta como sinónimo en inglés).
- **«cascarón»:** queda como aclaración informal.
- **Contenido:** «contenido web» distribuido como **«paquete de contenido firmado»** (en: *signed web content bundle*) mediante **«actualización OTA»** (en: *over-the-air update*). Esto reemplaza la variante «contenido web remoto».

## Términos exactos

| Pieza | Español | Inglés | Respaldo |
|---|---|---|---|
| Concepto | app híbrida | hybrid app | TC:33, TC:41-43 [B1][B2] |
| App instalada | contenedor nativo | native wrapper (sin. native shell) | TC:47-49 [B1][B2][W1]; RFC:7, RFC:26 |
| Vista | vista web embebida (`HybridWebView`) | embedded web view | TC:52 [M2], TC:56 [M1] |
| Contenido | contenido web | web content | RFC:8 |
| Unidad que se distribuye | paquete de contenido firmado | signed web content bundle / update bundle | RFC:10 (Anexo A ya registra *update bundle*) |
| Mecanismo | actualización OTA | over-the-air (OTA) update | TC:70-72 [W2][W3] |
| Canal | puente JS↔.NET | bridge | TC:60-62 [B1] |

## Regla de uso

1. **Primera mención en cada capítulo o documento:** «contenedor nativo (*native wrapper*; en la jerga del proyecto, "cascarón")».
2. **Glosario (Anexo A):** entrada principal «contenedor nativo». Entrada «cascarón» de una línea: «Coloquial del proyecto; ver contenedor nativo». Entrada «paquete de contenido firmado», con *update bundle* como sinónimo.
3. **Cuerpo del texto:** solo el término formal. «cascarón» no aparece fuera de la primera mención y del glosario.
4. **Código:** no se renombra en este PR. `FrameworkConcept.Shell` (RFC:12) se evalúa en el ADR de renombre (ver Riesgo 1). Si se renombra, propongo `FrameworkConcept.Host` o `FrameworkConcept.Wrapper`.
5. **Texto ante tiendas** (fichas, notas de revisión): no se usan ni «cascarón» ni «sitio empaquetado» (TC:99, TC:116). Se describe la app por sus funciones nativas propias.

## Fundamentos

- **«cascarón» no tiene respaldo.** No aparece en ninguna de las 11 fuentes (TC:94), y su origen es coloquial (RFC:13, `00-Marco.md:44-48`). Igual tiene valor didáctico y está arraigado en cientos de menciones. Por eso conviene degradarlo a aclaración y no borrarlo (opción C). Borrarlo rompe la trazabilidad con la guía del PO y con el historial.
- **«contenedor nativo» es la glosa directa de *native wrapper*.** Ese término tiene aval académico (TC:47 [B1]: «wraps web assets into a publishable, deployable Native app»). Además, «contenedor» describe la función (aloja, actualiza, expone el puente) mejor que «app contenedora», que suena a producto.
- **El contenido no es «remoto» al ejecutarse.** En el modelo del libro se baja, se firma, se verifica y se sirve desde el disco (RFC:8). «Contenido web remoto» (TC:35) induce a pensar en carga en vivo desde el servidor, y eso choca con 2.5.2 y con el riesgo de Google por «untrusted web content» (TC:108, TC:123). «Paquete de contenido firmado» deja clara la frontera de confianza que piden las tiendas (TC:125).
- **OTA es el término neutral.** «Live Updates» es una marca (TC:72, TC:102). CodePush está retirado (RFC:20, R22).

## Diferencia con Blazor Hybrid

Blazor Hybrid es el pariente oficial de .NET, pero **no** es este modelo. En Blazor Hybrid el Razor va compilado en el binario y «WebAssembly isn't involved» (TC:56-57 [M1]; RFC:21). En el libro se nombra solo para contrastar, nunca como sinónimo. El modelo del proyecto se parece más a Capacitor o Cordova con OTA (Capawesome, Appflow, Expo) sobre `HybridWebView` (TC:52 [M2]).

## Riesgos

1. **Choque con `Shell` de MAUI.** En .NET MAUI, *Shell* (`Microsoft.Maui.Controls.Shell`, `AppShell.xaml`) es el contenedor de navegación de la app. Traducir *native shell* y nombrar el proyecto `FrameworkConcept.Shell` genera ambigüedad para cualquier desarrollador MAUI. Este es el motivo técnico más fuerte para preferir *native wrapper* en inglés. *Nota: el conocimiento de MAUI Shell es propio; no figura en TC ni en RFC.*
2. **Falso amigo «app shell»** (web.dev, PWA): ya está descartado (TC:96, RFC:23). El término «cascarón» lo evoca, y es otra razón para no usarlo como término principal.
3. **Costo del renombre.** Son cientos de menciones (RFC:5-13). Hay que hacerlo con ADR y en un PR propio en el territorio de FC (RFC:26), con reemplazo mecánico revisado. La «primera mención» debe quedar escrita una vez por capítulo y no en cada aparición.
4. **Puente y Apple 4.7.2.** Ningún nombre resuelve el requisito de permiso previo (TC:114). El texto no debe sugerir que «firmado» o «propio» alcanza para cumplirlo.
5. **Supuesto no verificado.** Tomo «firmado y servido desde disco» de RFC:8 y no lo verifiqué en el código. El Framework-Concept no se leyó en este dictamen.

## Coordinación

FC (FRAMEWORK MAUI) es el dueño del renombre. Este dictamen alimenta la mesa y no edita nada fuera de esta carpeta.
