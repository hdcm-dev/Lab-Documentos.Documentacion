# Voto 4 del jurado: coherencia histórica

**Voto:** opción 1 (B + X con *native shell*), con los dos agregados del relator.
**Veto:** no.

## Fundamento

1. **Continuidad del inglés.** *Native shell* es el término que el libro usa desde siempre:
   - aparece en la definición, en `Framework-Concept/MAUI-Framework-Developer-Guide.md:143`;
   - aparece en el glosario, en `MAUI-Framework-Developer-Guide.md:2516` y en `99-Anexos.md:67`;
   - FC lo confirma en `Respuesta-FC-2026-11-01.md:7`.

   Con la opción 1 se cambia el español y el inglés queda igual. Así la historia sigue siendo legible.
2. **Continuidad del contenido.** El libro ya registra *update bundle* en `MAUI-Framework-Developer-Guide.md:2523` y `99-Anexos.md:68`, y FC lo señala en `Respuesta-FC-2026-11-01.md:10`.
   - La opción X conserva ese término.
   - La opción 3 (Y) lo reemplaza y deja abierto el renombre de `FrameworkConcept.Shell`, lo que rompe la continuidad con el código.
3. **Lectura de FC.** FC ya eligió el par «native shell / host app» + «web content / update bundle» como el más estable (`Respuesta-FC-2026-11-01.md:26`). La opción 1 sigue esa misma línea.
4. **Lugar de *native wrapper*.** Tiene aval académico (`Termino-Cascaron.md:47-49`), pero no tiene historia en el proyecto. Por eso le corresponde entrar como sinónimo en el glosario, que es justo lo que propone el relator.
5. **Rastro del término viejo.** Dejar «cascarón» en la primera mención y como remisión en el Anexo A conserva el rastro histórico sin que siga siendo el término principal.

## Condiciones
- Antes de agregar la remisión hay que quitar «App Shell model» de `README.md:30` y de `99-Anexos.md:67`. Este falso amigo también figura en el Anexo de FC.
- El choque con `Microsoft.Maui.Controls.Shell` se anota como riesgo en el ADR de FC.
- El PR de renombre del libro se abre recién cuando fusionen las mesas DocsAsCode que están trabajando ahora.
