# Mesa «cascarón»: consolidado del relator

Fecha: 2026-11-01. Insumos: `Termino-Cascaron.md`, `Respuesta-FC-2026-11-01.md` y `Mesa-Dictamen-1.md` a `Mesa-Dictamen-5.md` (esta carpeta).

## Resultado de la votación de los dictámenes

- Cinco de cinco eligen **B**: un término formal como principal y «cascarón» solo como aclaración informal. Ninguno vota por A ni por C.
- Cuatro eligen **X**, dos de ellos con un ajuste (dictámenes 1, 3, 4 y 5). Uno elige **Y**: «paquete de contenido firmado» (dictamen 2).
- Cinco de cinco proponen **«contenedor nativo»** como término en español. Lo que se discute es el equivalente en inglés: *native shell* (dictámenes 1, 4 y 5) o *native wrapper* (dictámenes 2 y 3).

## Puntos comunes a todas las opciones

1. «Cascarón» deja de ser término técnico. Se conserva en dos lugares: como aclaración en la primera mención de cada documento y como remisión en el Anexo A («cascarón (coloq.) → véase contenedor nativo»).
2. Siempre se escribe «contenedor nativo», nunca «contenedor» solo. Así no se confunde con Docker ni con el contenedor de inyección de dependencias.
3. Se corrige el falso amigo «App Shell model» en `Framework-Concept/README.md:30` y `MAUI-Framework-Developer-Guide.md:67`, porque contradice `Termino-Cascaron.md:96`. Esta corrección se hace con cualquiera de las opciones.
4. No se usan como término «Blazor Hybrid», «sitio empaquetado» ni «container app» suelto (`Termino-Cascaron.md:96-100`).
5. Las citas de `00-Marco.md:44-48`, las bitácoras históricas y el código no se tocan. `FrameworkConcept.Shell` aparece en 72 archivos y no se renombra en este paso.
6. Ningún nombre resuelve las pautas de Apple 2.5.2 y 4.7.2 ni la regla de Google sobre contenido no confiable (`Termino-Cascaron.md:114,123`).
7. **Alcance:**
   - **Guía 16:** se aplica de inmediato.
   - **Libro MAUI (unas 751 apariciones en 130 archivos):** se hace en el territorio de FRAMEWORK MAUI. Primero va un ADR y después un PR propio de renombre, revisado a mano y sin `sed` ciego. Ese PR se abre recién cuando fusionen los PR de las mesas DocsAsCode que están activas.

## Opciones votables

### Opción 1: B + X con *native shell* (dictámenes 1, 4 y 5)

| Pieza | Español | Inglés |
|---|---|---|
| App instalada | contenedor nativo | *native shell* (sinónimo: *native wrapper*) |
| Modelo | app híbrida | *hybrid app* |
| Pantallas | contenido web | *web content* |
| Unidad distribuida | paquete de actualización OTA | *OTA update bundle* |

- **Primera mención:** «contenedor nativo (*native shell*; en la jerga del proyecto, "cascarón")».
- **Ajuste del dictamen 5:** la primera mención del contenido dice «contenido web, distribuido como paquete de actualización OTA firmado».
- **A favor:** *native shell* ya figura en `MAUI-Framework-Developer-Guide.md:143` y coincide con `FrameworkConcept.Shell` (`Respuesta-FC:26`), así que cuesta menos.
- **En contra:** *Shell* choca con `Microsoft.Maui.Controls.Shell`. Este riesgo lo señala el dictamen 2 por conocimiento propio, no por los insumos.

### Opción 2: B + X con *native wrapper* (dictamen 3)

- Usa los mismos términos que la opción 1, pero el inglés principal es *native wrapper*. *Native shell* y *host app* quedan como sinónimos.
- El modelo se nombra «aplicación híbrida con contenido web remoto». La razón es que la literatura supone el contenido dentro del binario (`Termino-Cascaron.md:44`).
- **A favor:** *native wrapper* tiene aval académico [B1][B2] (`Termino-Cascaron.md:47-49`) y evita el choque con *Shell* de MAUI.
- **En contra:** la palabra «remoto» contradice el modelo, porque el contenido se sirve desde el disco (`Respuesta-FC:8`). Si se elige esta opción, conviene tomar la calificación del dictamen 4: «app híbrida con contenido OTA».

### Opción 3: B + Y con *native wrapper* y «paquete de contenido firmado» (dictamen 2)

| Pieza | Español | Inglés |
|---|---|---|
| App instalada | contenedor nativo | *native wrapper* (sinónimo: *native shell*) |
| Pantallas | contenido web | *web content* |
| Unidad distribuida | paquete de contenido firmado | *signed web content bundle* (sinónimo: *update bundle*) |
| Mecanismo | actualización OTA | *over-the-air update* |

- El Anexo A suma la entrada «paquete de contenido firmado».
- `FrameworkConcept.Shell` queda para que lo decida el ADR de FC. Si se renombra, los candidatos son `Host` o `Wrapper`.
- **A favor:** «firmado» hace visible la exigencia de origen confiable que piden las tiendas (`Termino-Cascaron.md:108,123,125`).
- **En contra:** reemplaza *update bundle*, que ya está en el Anexo A (`Respuesta-FC:10`), y deja abierta la posibilidad de renombrar el código.

## Recomendación del relator

La recomendación es la **opción 1**, con dos agregados:

- la calificación «app híbrida con contenido OTA» del dictamen 4;
- la primera mención «paquete de actualización OTA firmado» del dictamen 5, que recoge lo que aporta la opción 3 sin crear un término nuevo.

*Native wrapper* entra en el glosario como sinónimo. El choque con `Microsoft.Maui.Controls.Shell` se anota como riesgo en el ADR de FC, sin renombrar el código.
