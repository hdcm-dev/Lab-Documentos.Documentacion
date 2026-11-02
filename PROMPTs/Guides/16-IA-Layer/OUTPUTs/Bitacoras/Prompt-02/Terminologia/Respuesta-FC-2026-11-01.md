# Respuesta de FRAMEWORK MAUI sobre «cascarón» (2026-11-01)

Fuente: mensaje entre sesiones de FC. Rutas en LD origin/main e0608fd.

1. **Término vigente.** El libro MAUI §1.2.1, l. 138-147, usa estos términos:
   - «app híbrida» (*hybrid app*);
   - «cascarón» (*native shell*): la app MAUI instalada por tienda, con pantallas XAML propias, actualizador, puente y base local, sin pantallas de negocio;
   - «contenido» (*web content*): Razor compilado a Blazor WASM, empaquetado, firmado y bajado por el cascarón.

   El Anexo A (l. 2499+) también registra *update bundle* para «contenido».
   - El Conocimiento `Knowledge-App-Hibrida-OTA-Offline-First.md` usa el mismo vocabulario.
   - En el código el proyecto se llama `FrameworkConcept.Shell`.
   - El término viene de la guía del PO `00-Marco.md:44-48`.
2. **Fuentes ya citadas (Anexo B).**
   - **Apple:**
     - R1, App Review 2.5.2 y 4.7.
     - R2, DPLA §3.3.1: queda NO VERIFICADO.
   - **Google:** R3, Play «Device and Network Abuse».
   - **Frameworks:** R16 Capacitor, R60 Cordova, R61 plugins.
   - **Actualización remota:** R18 Expo EAS Update, R22 retiro de App Center/CodePush, R23 CodePush abierto, R19-R21 Appflow, Capawesome y Capgo.
   - **Microsoft:** R25 Blazor Hybrid. El libro aclara que **no** es este modelo, porque el Razor va dentro de la DLL.
   - **No se citan:**
     - El app shell de web.dev. Es otra cosa: el armazón de una PWA que guarda un service worker.
     - El «native container» de Cordova.
3. **Decisión previa.** No hay ADR ni mesa sobre el nombre. El vocabulario quedó fijado sin debate en `Reedicion-04/03-Plan-Del-Libro.md:27` y `Nucleos/N1-…:62`.
4. **Lectura de FC.** El par más estable en la literatura es «native shell / host app» + «web content / update bundle». Si cambia el término en español, FC propone un ADR y un PR de renombre en su propio territorio, una vez que la mesa decida.
