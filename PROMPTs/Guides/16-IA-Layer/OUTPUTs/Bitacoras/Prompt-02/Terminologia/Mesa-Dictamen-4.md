# Mesa «cascarón» — Dictamen 4 (didáctica y lectores de guías de estudio)

> Dictamen ciego, 2026-11-01. Perfil: `IA/PROMPTs/IA.Prompts/PromptFramework/Profiles/Study-Guide-Documentation.md`.

## Opción preferida: **B + X**

Usar un término formal como principal y conservar «cascarón» como aclaración informal en lugares fijos. No elegir A ni C.

## Términos exactos

| Pieza | Español (principal) | Inglés | Aclaración informal |
|---|---|---|---|
| App instalada por tienda | **contenedor nativo** | *native shell* / *native wrapper* | «el cascarón» |
| Modelo completo | **app híbrida con contenido OTA** | *hybrid app with OTA-updated web content* | — |
| Pantallas de negocio | **contenido web** | *web content* | — |
| Unidad que se distribuye | **paquete de actualización OTA** | *OTA update bundle* | — |
| Canal JS↔.NET | **puente** | *bridge* | — |

## Regla de uso

1. **Primera mención de cada documento:** «contenedor nativo (*native shell*; en el equipo, "el cascarón")». Después, solo «contenedor nativo».
2. **Glosario (Anexo A):** la entrada principal es «Contenedor nativo». «Cascarón» queda como entrada de remisión: «coloquial del equipo → ver Contenedor nativo».
3. **Código:** `FrameworkConcept.Shell` no se cambia. El glosario aclara que *Shell* = contenedor nativo.
4. **Prohibido:** asociar el término con «App Shell model». Es el falso amigo de web.dev.

## Evidencia

- **No hay respaldo bibliográfico para «cascarón».** `Termino-Cascaron.md:94` dice que no aparece en ninguna fuente. «Native wrapper» sí lo tiene en las fuentes académicas [B1][B2] (`Termino-Cascaron.md:47-49`).
- **El libro ya mezcla «cascarón» con un falso amigo.** `Framework-Concept/README.md:30` y `MAUI-Framework-Developer-Guide.md:67` lo glosan como «*App Shell model*». `Termino-Cascaron.md:96` lo descarta porque ahí la cáscara es web y no nativa. Es un error que el lector arrastra.
- **El término ya está muy instalado.** Hay unas 751 apariciones de «cascarón» en `Concepts/Framework-Concept/` (conté con grep -io). El glosario lo define en `MAUI-Framework-Developer-Guide.md:2516` y en §1.2.1 (l. 143). Eliminarlo (C) dejaría huérfanos a los lectores, a los Knowledge y a la conversación del equipo.
- **Fundamento didáctico.** El perfil pide un «vocabulario común… nombrado de forma estable» (Study-Guide-Documentation.md, «Marco de referencia»). Un término principal único con remisión desde el coloquial es estable. Además le enseña al lector la palabra que va a encontrar en la literatura y en las tiendas (Apple 4.2: «repackaged website», `Termino-Cascaron.md:116`).
- **Contenido y paquete (X).** El libro ya registra «contenido» (*web content*) y *update bundle* (`Respuesta-FC-2026-11-01.md:8-10`). «OTA» es el término neutral, mientras que «Live Updates» es una marca (`Termino-Cascaron.md:72,102`). Basta con agregar «OTA» al nombre del paquete.

## Riesgos

- **Costo del renombre:** cientos de menciones. Se mitiga con un ADR y un PR propio de FRAMEWORK MAUI (`Respuesta-FC-2026-11-01.md:26`), por documento y no todo de una vez.
- **Etapa de transición:** si conviven los dos términos sin regla, el lector duda de si nombran cosas distintas. La regla 1 resuelve esto con la equivalencia explícita.
- **«Contenedor» es ambiguo** (Docker, contenedor de DI). Por eso va siempre como «contenedor nativo», nunca suelto.
- **«App híbrida» sola** hace pensar en contenido empaquetado (`Termino-Cascaron.md:44`) o en Blazor Hybrid (l. 100). Por eso va calificada con «con contenido OTA».
