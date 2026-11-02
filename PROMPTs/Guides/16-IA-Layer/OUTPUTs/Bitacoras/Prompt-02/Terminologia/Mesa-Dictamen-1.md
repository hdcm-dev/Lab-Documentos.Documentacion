# Mesa «cascarón» — Dictamen 1 (documentación técnica y terminología)

> Dictamen ciego, 2026-11-01. Insumos: `Termino-Cascaron.md`, `Respuesta-FC-2026-11-01.md` y el libro `Concepts/Framework-Concept/` (solo lectura).

## Opción preferida: **B + X, con un ajuste en X**

- **Término principal (es/en):** **contenedor nativo** / *native shell*.
  - Glosa académica de apoyo: *native wrapper* [B1][B2] (`Termino-Cascaron.md:47-49`).
  - Se conserva *native shell* en inglés porque el libro ya lo usa (`MAUI-Framework-Developer-Guide.md:143`) y FC lo da como el par más estable (`Respuesta-FC-2026-11-01.md:26`).
- **Concepto que lo engloba:** **app híbrida** / *hybrid app* [B1][B2]. Ya es el término vigente del libro (`Respuesta-FC…:6`).
- **Contenido:** **contenido web** / *web content*. Es más preciso que «contenido web remoto», porque se sirve desde el disco y no en vivo.
- **Unidad de distribución:** **paquete de actualización OTA** / *OTA update bundle*.
  - Une el *update bundle* del Anexo A (`Respuesta-FC…:10`) con «OTA», el término neutral (`Termino-Cascaron.md:72`).
  - «Live Updates» y «CodePush» son marcas y solo se mencionan como ejemplos (`Termino-Cascaron.md:102`).
- **Cascarón:** queda como **aclaración informal**, no como término.

## Regla de uso

1. **Primera mención en cada documento** (libro, Conocimiento, README): «contenedor nativo (*native shell*; en la jerga del proyecto, "cascarón")». Después se usa solo «contenedor nativo».
2. **Glosario (Anexo A):**
   - Una entrada principal para «contenedor nativo».
   - Una entrada de remisión: «cascarón (coloq.) → véase contenedor nativo».
   - Una nota de falso amigo: «app shell» (web.dev) no es este concepto (`Termino-Cascaron.md:96`).
   - Esto sigue la práctica de gestión terminológica: un término preferido, con los sinónimos admitidos o desaconsejados marcados como tales. Es la misma forma que usa ISO/IEC/IEEE 24765. No la verifiqué contra el texto de la norma, que figura como pendiente en `Termino-Cascaron.md:141`.
3. **Código:** no se renombra. `FrameworkConcept.Shell` (`Respuesta-FC…:12`) ya está en inglés y coincide con *native shell*. Las guías de estilo de Microsoft y Google piden que los identificadores no se traduzcan.
4. **Citas de la guía del PO** (`00-Marco.md:44-48`): se dejan textuales, porque son el origen histórico del término.
5. **Corrección inmediata:** `README.md:30` dice «native shell, App Shell model». «App Shell model» es el falso amigo que el propio estudio descarta (`Termino-Cascaron.md:96`; R de FC, `Respuesta-FC…:23`), así que hay que quitarlo.

## Por qué no A ni C

- **Contra A:**
  - Ninguna fuente define «cascarón» (`Termino-Cascaron.md:94`).
  - Un término coloquial como término técnico obliga a cada lector externo a aprenderlo del glosario, cuando ya existe un término equivalente con respaldo.
  - «Shell» invita a confundirlo con *app shell*.
- **Contra C:**
  - Hay unas 751 apariciones en `Concepts/Framework-Concept/` (conteo con grep, incluye código y props).
  - El término forma parte de la historia del proyecto (guía del PO, plan `Reedicion-04/03-Plan-Del-Libro.md:27`).
  - Si se elimina sin remisión, un lector que lo encuentre en commits, bitácoras o mensajes no tiene cómo resolverlo. Con B la búsqueda sigue funcionando.

## Riesgos y mitigación

- **Volumen del renombre:** son unas 751 apariciones. Conviene hacerlo en el PR propio de FC, con su ADR (`Respuesta-FC…:26`), y revisar a mano, no con un sed ciego: hay citas, código y props.
- **Coordinación con DocsAsCode:** el cambio toca el libro que están editando las mesas activas. El ADR va primero y el renombre después de que cierren sus PR, para evitar conflictos.
- **Ambigüedad de «contenedor»:** puede confundirse con Docker. Por eso siempre se escribe «contenedor nativo», nunca «contenedor» solo.
- **Tiendas:** no hay que describir la app como «sitio empaquetado» (Apple 4.2.2). El puente queda sujeto a Apple 4.7.2 y a la regla de Google sobre contenido no confiable (`Termino-Cascaron.md:114,123`). El término elegido no cambia esas obligaciones.
