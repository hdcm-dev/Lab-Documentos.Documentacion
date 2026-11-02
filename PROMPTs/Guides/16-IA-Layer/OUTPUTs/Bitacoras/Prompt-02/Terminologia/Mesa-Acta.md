# Acta de mesa: el término «cascarón»

- **Fecha:** 2026-11-01
- **Forma:** Knowledge-Mesa-De-Expertos-A-Pedido + Knowledge-Mesa-Consulta-A-Un-Tercero
- **Pregunta del PO:** «cascarón» nació coloquial. ¿Se mantiene como término, se usa como aclaración informal junto a un término formal o se elimina? Los especialistas eligen el mejor modo y coordinan con las mesas DocsAsCode que están trabajando ahora.
- **Insumos:** `Termino-Cascaron.md` (11 fuentes verificadas), `Respuesta-FC-2026-11-01.md`, `Mesa-Consolidado.md`, `Mesa-Voto-1.md` … `Mesa-Voto-5.md`
- **Regla:** la mesa decide y la decisión queda aprobada.

## 1. Recuento

| Eje | Resultado de los dictámenes | Resultado de la votación final |
|---|---|---|
| Término | B 5/5: «contenedor nativo» es el principal y «cascarón» queda como aclaración informal | — |
| Contenido | X 4, Y 1 | — |
| Inglés | *native shell* 3, *native wrapper* 2 | — |
| Opción final | — | **Opción 1 con los dos agregados del relator: 5/5** |

## 2. Vetos

No hubo vetos (0 de 5).

Riesgo anotado: *native shell* puede confundirse con `Microsoft.Maui.Controls.Shell`. Lo aportó el dictamen 2 por conocimiento propio y no figura en los insumos. Se resuelve con una nota, sin renombrar nada.

## 3. Decisión (aprobada)

Se adopta la **opción B + X con *native shell***, con dos agregados:

1. El modelo se nombra «app híbrida con contenido OTA». No se usa «contenido web remoto», porque el contenido se sirve desde el disco del teléfono (Voto-5; `Termino-Cascaron.md:35`, `:78`, `:88`).
2. La primera mención del contenido dice «paquete de actualización OTA firmado». «Firmado» deja a la vista que el contenido viene de un origen confiable (`Termino-Cascaron.md:125`).

**Fundamento:**
- Ninguna fuente define «cascarón». En cambio, *hybrid app* y *native wrapper* tienen respaldo bibliográfico ([B1], [B2] y [W1] en `Termino-Cascaron.md:40-49`).
- El inglés *native shell* ya está en uso en `MAUI-Framework-Developer-Guide.md:143` y `:2516` y en `99-Anexos.md:67`, y FC lo confirma en `Respuesta-FC-2026-11-01.md:7` y `:26`.
- *Update bundle* ya está registrado en `99-Anexos.md:68` y en `MAUI-Framework-Developer-Guide.md:2523`.
- El nombre no cambia lo que exigen las tiendas: Apple 2.5.2 y 4.7.2 y la regla de Google sobre contenido no confiable rigen igual (`Termino-Cascaron.md:108`, `:114`, `:123-125`).

## 4. Términos finales

| Español | Inglés | Definición |
|---|---|---|
| **contenedor nativo** | *native shell* (sinónimo: *native wrapper*) | App .NET MAUI que se instala desde la tienda. Aloja el WebView, el puente nativo y el verificador de firma, y no trae las pantallas de negocio. |
| **app híbrida con contenido OTA** | *hybrid app with OTA content* | El modelo completo: un contenedor nativo que sirve contenido web descargado, firmado y guardado en el disco. No es Blazor Hybrid, que compila las pantallas dentro del binario. |
| **contenido web** | *web content* | Las pantallas de negocio en Blazor WASM que corren en el WebView. |
| **paquete de actualización OTA** | *OTA update bundle* | La unidad que se distribuye: se descarga, se verifica la firma y se sirve desde el disco. |
| cascarón (coloq.) | — | Solo es una remisión al término principal y no se usa como término. |

Términos descartados:
- «App Shell model»: es un falso amigo, porque en Google designa la cáscara de una app web ([W4], `Termino-Cascaron.md:96`).
- «Contenido web remoto».
- «Sitio empaquetado».

## 5. Regla de uso

1. **Primera mención en cada documento:**
   - Para la app: «contenedor nativo (*native shell*; en la jerga del proyecto, "cascarón")».
   - Para el contenido: «contenido web, distribuido como paquete de actualización OTA firmado».
2. **Menciones siguientes:** siempre «contenedor nativo», nunca «contenedor» solo. «Cascarón» no vuelve a aparecer.
3. **Entradas del glosario (Anexo A):**
   - «contenedor nativo (*native shell*; sin. *native wrapper*)», con la definición y la nota: «no confundir con `Microsoft.Maui.Controls.Shell`».
   - «cascarón (coloq.) → véase contenedor nativo».
   - Se quita «App Shell model» de `99-Anexos.md:67`.
4. **Nombre de código `FrameworkConcept.Shell`:** no se renombra. Coincide con *native shell*. El riesgo de confusión con el *Shell* de MAUI se anota en el ADR de FC.
5. **Qué no se toca:** las citas literales (`00-Marco.md:44-48`), las bitácoras y el código.

## 6. Plan de aplicación por territorio

| Territorio | Acción | Cuándo |
|---|---|---|
| Guía 16 | Aplica la regla en su reescritura. | Ya |
| FC (libro MAUI y su Knowledge) | Escribe un ADR propio con esta decisión y el riesgo del *Shell*. Después abre un PR de renombre aparte, revisado a mano, que cubre unas 751 apariciones en 130 archivos. Antes de ese PR, y con bajo costo, quita «App Shell model» de `Framework-Concept/README.md:30`, de `MAUI-Framework-Developer-Guide.md:67` y de `99-Anexos.md:67`. | El PR de renombre se abre recién cuando fusionen los PR de las mesas DocsAsCode en curso. |
| DocsAsCode | Si el término aparece en lo suyo, aplica la regla en su próximo PR. No interrumpe a las mesas que están trabajando. | Al cerrar sus PR actuales |

Lab-Documentos sigue en lectura: esta mesa no editó `Concepts/Framework-Concept/`.

## 7. Registro de terminología

| Fecha | Término | Estado | Fuente |
|---|---|---|---|
| 2026-11-01 | contenedor nativo / *native shell* | adoptado (principal) | esta acta |
| 2026-11-01 | *native wrapper* | sinónimo | [B1] `Termino-Cascaron.md:47-49` |
| 2026-11-01 | app híbrida con contenido OTA | adoptado | esta acta |
| 2026-11-01 | paquete de actualización OTA (firmado) / *OTA update bundle* | adoptado | `99-Anexos.md:68` |
| 2026-11-01 | cascarón | aclaración coloquial, solo en la primera mención y como remisión | esta acta |
| 2026-11-01 | App Shell model; contenido web remoto | descartados | [W4]; Voto-5 |
