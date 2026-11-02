# Voto 3: jurado con lente costo-beneficio

**Voto:** opción 1 (B + X con *native shell*), con los dos agregados que propone el relator.
**Veto:** no.

## Por qué esta opción
- **Menor costo de cambio.** *Native shell* ya está en `Framework-Concept/MAUI-Framework-Developer-Guide.md:143`: «El **cascarón** (*native shell*) es la app .NET MAUI…». Con esta opción se cambia solo la palabra en español. El inglés y el nombre en código (`FrameworkConcept.Shell`) se quedan como están.
- **Se aprovecha lo que ya existe.** *Update bundle* ya aparece en `99-Anexos.md:68` y en `MAUI-Framework-Developer-Guide.md:2523`. La opción 3 lo reemplaza y suma una entrada al glosario. Eso agrega trabajo sin una ganancia a la altura.
- **La opción 2 rinde menos.** *Native wrapper* tiene un buen respaldo (`Termino-Cascaron.md:47-49`). Pero pasarlo a término principal obliga a cambiar el inglés en todo el libro y a corregir «remoto». Es más barato dejarlo como sinónimo en el glosario.
- **El riesgo del choque con `Microsoft.Maui.Controls.Shell` se contiene barato.** Basta anotarlo en el ADR de FC. Renombrar el código (opción 3) es lo más caro de todo y abre un frente mientras están activas las mesas DocsAsCode.
- **Lo que pide «firmado» ya queda cubierto.** El agregado del relator, «paquete de actualización OTA firmado» en la primera mención, cumple lo que buscaba la opción 3 sin agregar entradas nuevas.

## Condiciones de costo
- Esto vale en las tres opciones: el PR de renombre del libro (unas 751 apariciones) va recién después de que fusionen los PR DocsAsCode que están en curso. Se revisa a mano y en un solo PR.
- Corregir el falso amigo de `README.md:30` («App Shell model») y de `MAUI-Framework-Developer-Guide.md:67` cuesta poco y se gana mucho, así que va primero.
