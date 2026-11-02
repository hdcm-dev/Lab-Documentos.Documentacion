# Voto 5 — jurado con lente de riesgo (veto acotado)

**Voto:** opción 1 (B + X con *native shell*), con los dos agregados que propone el relator.
**Veto:** no.

## Fundamento

1. **El riesgo regulatorio no depende del nombre.** Las restricciones que pesan sobre el puente son las mismas con cualquiera de las tres opciones: Apple 2.5.2 (`Termino-Cascaron.md:108`), Apple 4.7.2 (`Termino-Cascaron.md:114`) y la regla de Google sobre contenido no confiable (`Termino-Cascaron.md:123-125`). Por eso ninguna opción justifica un veto desde lo regulatorio.
2. **Hay que sacar «remoto».** «Contenido web remoto» (`Termino-Cascaron.md:35`, `:78`, `:86`, `:88`) sugiere ejecución en vivo desde el servidor. Para un revisor de Apple eso se parece a 2.5.2, cuando en realidad el contenido se baja, se verifica y se sirve desde disco. La opción 2 conserva esa redacción, así que es la que más riesgo trae. La opción 1 con «app híbrida con contenido OTA» lo evita.
3. **«Firmado» desde la primera mención.** El agregado «paquete de actualización OTA firmado» cubre lo que buscaba la opción 3: muestra que el contenido viene de un origen confiable, como pide `Termino-Cascaron.md:125`. Y lo logra sin tocar *update bundle*, que ya está en el glosario (`Framework-Concept/README.md:30`), ni dejar abierto el renombre del código.
4. **El choque con *Shell* de MAUI es un riesgo menor.** Nació del conocimiento propio del dictamen 2 y no está citado en los insumos. *Native shell* ya está en uso (`MAUI-Framework-Developer-Guide.md:143`, `:2516`), así que adoptarlo no agrega riesgo nuevo. Basta con anotarlo en el ADR de FC, como propone el relator.
5. **Riesgo de proceso.** El renombre del libro MAUI (unas 751 apariciones) tiene que esperar a que fusionen los PR de las mesas DocsAsCode que están trabajando ahora, para no generar conflictos. Esa condición ya está en el consolidado y la sostengo como condición del voto.

## Condiciones del voto
- Quitar «App Shell model» de `Framework-Concept/README.md:30`, porque es un falso amigo.
- Escribir siempre «contenedor nativo», nunca «contenedor» solo.
- Abrir el PR de renombre del libro solo después del ADR de FC y de la fusión de los PR de DocsAsCode.
