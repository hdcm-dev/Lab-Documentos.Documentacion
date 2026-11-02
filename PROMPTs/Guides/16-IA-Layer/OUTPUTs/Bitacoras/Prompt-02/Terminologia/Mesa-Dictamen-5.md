# Mesa «cascarón» — Dictamen 5 (análisis de decisión y costo de cambio)

Dictamen ciego, 2026-11-01. Especialista: análisis de decisiones y costo de cambio.

## Opción preferida: **B + X (con un ajuste)**

## Términos propuestos

| Pieza | Español (principal) | Inglés | «cascarón» |
|---|---|---|---|
| App instalada por tienda | **contenedor nativo** | *native shell* (sinónimo aceptado: *native wrapper*) | aclaración informal |
| Concepto de toda la solución | **aplicación híbrida** | *hybrid app* | — |
| Pantallas de negocio descargadas | **contenido web** | *web content* | — |
| Unidad que se baja, firma y verifica | **paquete de actualización OTA** (abreviado: «paquete de contenido») | *OTA update bundle* | — |

## Regla de uso

1. **Primera mención** en cada documento (libro, Knowledge, guía): «contenedor nativo (*native shell*; en la jerga del equipo, «cascarón»)». Después, solo «contenedor nativo».
2. **Glosario** (Anexo A del libro): la entrada es «contenedor nativo». Se agrega «cascarón → ver contenedor nativo» como término coloquial.
3. **Código: no se renombra.** `FrameworkConcept.Shell` ya está en inglés y coincide con *native shell*. El costo es alto: hay 72 archivos que lo mencionan en `Concepts/Framework-Concept/`. El beneficio es nulo. Los comentarios y textos en español del código se ajustan solo cuando se toque cada archivo, sin hacer un barrido.
4. **Prohibidos como término:** «app shell» (falso amigo), «Blazor Hybrid» para este modelo y «sitio empaquetado». Ver Termino-Cascaron.md:96-100.

## Por qué B y no A ni C

- **A (mantener) no tiene respaldo.** «cascarón» no aparece en ninguna fuente leída (Termino-Cascaron.md:94). En cambio, «native wrapper» y «hybrid app» tienen aval académico [B1][B2] (Termino-Cascaron.md:33-34). Un libro que se publica como referencia necesita el término principal citable.
- **C (eliminar) es la opción más cara y la que menos rinde.**
  - Hay 751 apariciones de «cascarón» en 130 archivos de `Concepts/Framework-Concept/`, que se contaron con grep. 87 de esos archivos están en `Demo/src`.
  - El término viene de la guía del PO (`00-Marco.md:44-48`, según Respuesta-FC-2026-11-01.md) y forma parte de la memoria oral del equipo.
  - Borrarlo del todo deja huérfanas las bitácoras y los commits que lo usan, y las búsquedas por «cascarón» dejan de encontrar algo.
- **B tiene un costo acotado y reversible.** El cambio se limita a la prosa: el libro, el Knowledge y el glosario. Se hace en un PR propio de FRAMEWORK MAUI con un ADR, tal como propone FC (Respuesta-FC-2026-11-01.md, punto 4). Como nunca hubo ADR ni mesa sobre el nombre (punto 3), el ADR nuevo no contradice ninguno anterior.

## Contenido y actualización: X, con un ajuste

- Se mantienen «contenido web» y «paquete de actualización OTA». Respaldo:
  - el Anexo A ya registra *update bundle* (Respuesta-FC, punto 1);
  - Expo, Appflow y Capawesome usan OTA / live updates (Termino-Cascaron.md:35; [W2] y [W3]).
- **Ajuste:** no hay que usar «contenido web remoto» como si se ejecutara en vivo. El contenido se baja, se verifica la firma y se sirve **desde el disco**. Por eso, la primera mención dice «contenido web, distribuido como paquete de actualización OTA firmado».
- Esta redacción también ayuda con las tiendas:
  - Apple 4.7 permite el software que no está embebido en el binario (Termino-Cascaron.md:111);
  - Google pide que el contenido venga de un origen confiable [G1].

## Plan de costo mínimo

1. Un ADR en FRAMEWORK MAUI con esta decisión y su vocabulario.
2. Un PR de prosa:
   - el libro §1.2.1 (l. 138-147, según Respuesta-FC) y el Anexo A;
   - `Knowledge-App-Hibrida-OTA-Offline-First.md`;
   - los README y las guías del Concept.
   Se hace con reemplazo guiado y revisión manual, no con sed ciego, porque hay que conservar la primera mención con la aclaración.
3. El código y las bitácoras históricas no se tocan.
4. Coordinación: la mesa DocsAsCode y FRAMEWORK MAUI están trabajando ahora sobre esos archivos. El PR va **después** de que fusionen, para no generar conflictos.

## Riesgos

- **Riesgo regulatorio, que no se resuelve con el nombre.** La pauta 4.7.2 de Apple exige permiso previo para exponer APIs nativas, y eso alcanza al puente (Termino-Cascaron.md:114). Cambiar el término no mitiga este riesgo, así que no hay que venderlo como si lo hiciera.
- **Deriva de vocabulario.** Mientras dure la transición van a convivir los dos términos. Se mitiga con la entrada de glosario y con una búsqueda de «cascarón» fuera de las primeras menciones como chequeo en la CI de documentación, si existe.
- **Ambigüedad de «contenedor».** Se puede confundir con un contenedor Docker, que el proyecto también usa. Por eso va siempre como «contenedor nativo» y nunca solo «contenedor». Si la mesa considera que el choque es grave, la alternativa es «app contenedora».
