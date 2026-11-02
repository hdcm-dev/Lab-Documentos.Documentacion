# Voto 2 de la mesa: impacto en el lector

**Voto:** opción 1 (B + X con *native shell*), con los dos agregados del relator: «app híbrida con contenido OTA» y «paquete de actualización OTA firmado».

**Veto:** no.

## Fundamento

1. **Continuidad para quien ya leyó el libro.** El libro ya presenta «El **cascarón** (*native shell*)» en `Framework-Concept/Developer-Guide.md:143`. Si el inglés se mantiene, el lector solo tiene que aprender que cambia el término en español: «contenedor nativo». Con *native wrapper* tendría que reaprender las dos lenguas a la vez.
2. **Se quita el equívoco más dañino.** `Framework-Concept/README.md:30` dice «cascarón nativo (native shell, App Shell model)». Para Google, *app shell* es la cáscara web y no la nativa (`Termino-Cascaron.md:96`, [W4]). Un lector que busque «App Shell model» llega a otra arquitectura. Las tres opciones lo quitan; la 1 lo hace sin cambiar nada más.
3. **El lector puede buscar el término.** *Native wrapper* tiene aval académico (`Termino-Cascaron.md:46-49`, [B1][B2][W1]). Entrar al glosario como sinónimo alcanza para que el lector llegue a esa bibliografía.
4. **«Firmado» en la primera mención del contenido.** Le transmite al lector lo que piden las tiendas, que el contenido venga de un origen confiable, sin sumar una entrada de glosario (que era la ventaja de la opción 3). Y con «contenido OTA» no se le dice que el contenido es remoto cuando en realidad se sirve desde el disco.
5. **Riesgo para el lector.** *Native shell* puede confundirse con `Microsoft.Maui.Controls.Shell`. Este riesgo lo señaló el dictamen 2 por conocimiento propio y no figura en los insumos. Para el lector alcanza con una nota en el ADR de FC y en el Anexo A: «no confundir con Shell de .NET MAUI». No justifica cambiar el término inglés.

## Condiciones

- Mantengo lo que es común a todas las opciones: «cascarón» solo en la primera mención y como remisión en el Anexo A, y siempre «contenedor nativo» completo.
- El PR de renombre del libro se abre recién cuando fusionen los PR de las mesas DocsAsCode que están trabajando ahora.
