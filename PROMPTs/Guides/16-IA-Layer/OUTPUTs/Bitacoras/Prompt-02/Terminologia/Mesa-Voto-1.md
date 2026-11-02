# Mesa «cascarón»: voto del jurado 1 (lente: evidencia)

**Voto:** opción 1 (B + X con *native shell*), con los dos agregados del relator.
**Veto:** no.

## Fundamento

1. **B tiene respaldo.** Ninguna fuente define «cascarón». *Hybrid app* y *native wrapper* sí tienen fuentes ([B1], [B2] y [W1] en `Termino-Cascaron.md:40-49`). Por eso «contenedor nativo» queda como término principal y «cascarón» pasa a ser una aclaración informal.
2. **X conserva lo que ya está en el texto.** El glosario ya registra *update bundle* (`Framework-Concept/99-Anexos.md:68`) y lo vuelve a usar en `MAUI-Framework-Developer-Guide.md:2523`. La opción Y lo reemplaza sin aportar una fuente nueva.
3. ***Native shell* ya está en uso.** Aparece en `MAUI-Framework-Developer-Guide.md:143` y en `Framework-Concept/README.md:30`.
4. ***Native wrapper* entra como sinónimo.** Tiene aval académico ([B1], `Termino-Cascaron.md:48`). El choque con `Microsoft.Maui.Controls.Shell` lo aportó el dictamen 2 por conocimiento propio y no figura en los insumos. Por eso alcanza con anotarlo como riesgo en el ADR de FC, sin renombrar el código.
5. **«Contenido web remoto» no describe el modelo.** El contenido se sirve desde el disco del teléfono, como dice la recomendación del relator. Corresponde «app híbrida con contenido OTA».
6. **El falso amigo está confirmado.** El texto «App Shell model» figura en `Framework-Concept/README.md:30`, así que hay que quitarlo como dice el consolidado.
7. **El alcance coordina con DocsAsCode.** El renombre del libro MAUI va después de que fusionen los PR de las mesas DocsAsCode que están trabajando ahora, y pasa primero por el ADR.
