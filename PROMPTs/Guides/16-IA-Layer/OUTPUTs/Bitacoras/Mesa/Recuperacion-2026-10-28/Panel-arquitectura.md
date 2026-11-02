# Panel · Arquitectura de software · Mesa de recuperación 2026-10-28

**Mandato:** dónde vive cada responsabilidad (capas, puertos, adaptadores, pipeline, ciclo de vida, composición), qué decisiones de arquitectura (ADR) cambian y cuánto código nuevo justifica cada aporte. Me abstengo en lo que es método estadístico, régimen R-PRIV, redacción editorial, didáctica y elección de modelo por desempeño.

**Hechos que verifiqué en la base:**
- ADR-11 (§13.12) declara cuatro reglas por reflexión. Admite como deuda que nada acota Presentación → Infrastructure/AI a `Chat.razor` ni obliga a Application a usar sólo `.Abstractions`. `ArquitecturaTests.cs` tiene cuatro métodos: Domain_SinDependenciasDeIa, Application_SinInfrastructureNiSdk, SdkDelProveedor_SoloEnInfrastructureAIyProgram y Herramientas_SinRepositorios.
- ADR-12 (§13.13) fija el criterio «ningún estado de conversación en un singleton». Se apoya en `Composicion_ValidateScopes` y su observado es del servidor compartido retirado.
- La demo ya registra `AddDbContextFactory<AppDbContext>` (`Infrastructure/DependencyInjection.cs`, l. 22).
- `LargoMaximoDelNombre` está declarado en `Domain/Rules/LocalidadRules.cs`, tanto en la demo como en `_Comun`. La tabla de delta de §14.1 ya tiene la columna «Modificado a causa de la IA».
- ADR-09 y §12.10 dejan el límite de concurrencia como algo que «falta en la demo».

## Posiciones

| Ítem | Opción | Fundamento |
|---|---|---|
| REC-01 | Abstención | Es versionado editorial y una decisión del PO. |
| REC-02 | A | Para la arquitectura cuenta que la re-corrida se haga una sola vez, sobre la guía integrada. Si no, los cambios de código de REC-09/12/13/22 obligarían a medir dos veces. Reparto por papel de estación sin acoplar el código a un equipo. La cantidad de corridas y el presupuesto los dejo al panel estadístico y al de entorno. |
| REC-03 | Abstención | Es organización de la mesa. |
| REC-04 | Abstención | |
| REC-05 | A | EMB-A y EMB-B como papeles (el mismo servidor del chat o uno aparte) son una frontera de configuración, no de código. Quitarlos del código (B) obliga a recompilar y no aporta nada. |
| REC-06 | A | Sin alternativa razonable. La única parte que es de mi mandato, el punto 6 (arnés y README), es necesaria para REC-07. |
| REC-07 | A | Basta una línea por lugar que lea el entorno con el valor actual como defecto, y el adaptador TURNO_CMD fuera del repo deja la frontera bien puesta: el repo nombra papeles y la máquina se resuelve en el borde. El renombre atómico de C toca 19 líneas de verificar.sh, ejemplo.json y los README y cambia hashes en plena recuperación. Puede hacerse después con su propio dictamen. |
| REC-08 | A | Fijar un mismo `num_ctx` para todos los clientes de un modelo es una invariante de composición: la capa de opciones única de ADR-09 es justo donde se impone. Sin la regla, el pipeline transversal queda incompleto. |
| REC-09 | A | Que un parcial cortado entre al historial como completo es un defecto de la capa que tiene el estado de la conversación. Decidir qué entra al historial es responsabilidad de esa capa y no se arregla con una frase. El costo es bajo: un chequeo y dos pruebas de cableado con GuionChatClient, sin modelo. |
| REC-10 | A | §5.6 es la tabla que justifica ADR-01/ADR-03, es decir, el cambio de adaptador. Si una vía descarta TopK o no acota MaxOutputTokens, el adaptador no es intercambiable sin aviso. La prueba de captura del cuerpo en 02 vuelve verificable esa frontera. |
| REC-11 | A | Las credenciales pertenecen al transporte (HttpClient/DelegatingHandler), no al mensaje. Es una regla de capas con una compuerta mecánica barata sobre las capturas que la guía ya enseña a guardar. |
| REC-12 | A | Una clave de caché sin sesión rompe en el pipeline el mismo aislamiento que ADR-12 pide en el ciclo de vida. Y cachear lo que pasa por herramientas sobre datos mutables contradice la ventaja que hoy declaran ADR-09 y §12.3. Como 17 es el ejemplo de pipeline, el caso rojo tiene que estar ahí, no sólo en la prosa. |
| REC-13 | A | La cola es un recurso compartido entre la API y Blazor, así que el lugar correcto para limitar es la entrada HTTP, donde se puede responder 503 con Retry-After. Un RateLimiter en el pipeline del cliente limita por instancia y no protege la cola. Cierra la deuda de ADR-09 con una prueba determinista. La capa del cliente queda como alternativa. |
| REC-14 | A | Es la prueba roja que le falta al criterio central de ADR-12. Además conviene documentar que ValidateScopes=true falla en cada llamada y no al construir el contenedor, porque cambia dónde detectarlo. La fábrica de DbContext ya está registrada (l. 22), así que sólo falta el párrafo del circuito. |
| REC-15 | Abstención | La elección por desempeño es de los paneles de modelo y estadístico. Desde arquitectura sólo pido que el modelo y el digest se fijen en configuración y no en código. |
| REC-16 | A | Una defensa que no cubre todos los campos es un hueco de diseño en GarantiaDelTexto, la frontera entre lo que propone el modelo y lo que escribe la aplicación. Hay que verificarla o extenderla con una prueba sin modelo antes de medir. |
| REC-17 | A | Las invariantes del dominio viven en Domain/Rules. `LargoMaximoDelNombre` ya está declarado ahí y no se aplica, y ponerlo en el normalizador del adaptador (C) duplicaría la regla y dejaría la API copiada sin protección. Primero las pruebas, y sólo si fallan se endurece en la fila «Modificado a causa de la IA», que ya existe para esto. |
| REC-18 | Abstención | |
| REC-19 | Abstención | Es método estadístico. |
| REC-20 | A | La aprobación impuesta por el código (ApprovalRequiredAIFunction más el pedido guardado) es la arquitectura correcta, y la evidencia del insumo (el modelo borra sin confirmar) la refuerza. Pasar a la AccionPropuesta (D) reabre una demo con 70/70 pruebas y AC-4. Corresponde registrarla en ADR-06 como alternativa descartada. |
| REC-21 | A | El detector que lanza y la guarda que marca son políticas distintas de la misma frontera: lanzar en CTX-PROD y marcar en desarrollo. Mostrarlo como alternativa sin reemplazar nada es la decisión por contexto que pide el marco. Hay que verificar que la estimación use el modelo de la llamada, porque es un acoplamiento oculto. |
| REC-22 | A | OllamaSharp no expone el valor, y el lugar correcto para leer metadatos del transporte es un DelegatingHandler en `_Comun`. Llena un campo (`estado_cache`) que hoy siempre dice «desconocido». Tiene una prueba sobre NDJSON fijo, sin modelo. |
| REC-23 | Abstención | Es del panel de seguridad. |
| REC-24 | Abstención | Es del panel de seguridad. Coincido con A en que publicar sólo en el bridge o en el loopback es parte de la composición. |
| REC-25 | A | Extender la garantía a las escrituras y probar «tools/list = esquema» cierra la frontera MCP sin agrandar el ejemplo. El Bearer (C) suma un mecanismo de autorización que la guía declara fuera de alcance. El catálogo único (D) es un refactor de 13 sin una falla que lo justifique, así que queda como alternativa declarada. |
| REC-26 | A | La quinta regla prometida es justo la deuda que ADR-11 admite (Presentación → Infrastructure/AI sólo por `Chat.razor`). Las reglas del insumo (C) cubren otras fronteras que la base no prometió. Las mutaciones Cuerpo y Atributo prueban que la prueba de arquitectura detecta lo que dice detectar, y declarar que el grep de AC-5 es débil es honesto. |
| REC-27 | A | Se ejecuta lo que se mostró: es el criterio de ADR-12 y alcanza también a la sesión persistida. Primero hay que verificar en 11, y sólo si falta se suma el caso rojo con la guarda y su límite declarado (si se comprometen los dos almacenes). |
| REC-28 | A | Mantener el perímetro de la demo. Las lecciones entran rotuladas y el código cambia poco: un caso no respondible en el oro. No cambia ninguna frontera. |
| REC-29 | Abstención | |
| REC-30 | A | Las trampas que fallan en silencio en una migración de SK piden casos rojos, porque la prosa sola no las detecta. Sin BuildSequential, para no ampliar la superficie. El glosario lo decide didáctica. |
| REC-31 | Abstención | Es de privacidad. |
| REC-32 | A | Una sola definición sostiene la escalera de ADR-07 (escalón de agencia). Con la definición del insumo, PD-1/5/6 cambiarían de escalón y habría que reescribir ADR-07. «MCP es transporte» es la distinción de capas correcta. |
| REC-33 | Abstención | Es régimen R-PRIV. |
| REC-34 | A | No encuentro desacuerdos de arquitectura entre las líneas en esas coincidencias, como MCP fuera de la demo o la sesión por código. |
| REC-35 | A | Si una PackageVersion no se usa, no hay que declararla: el manifiesto central tiene que reflejar el grafo real. El costo es acotado (build, AC-6 y hash), y hay que confirmar el transitivo de Agents.AI.Abstractions antes de retirarla. |

## Orden que recomiendo para el código

Primero REC-07 (no toca la lógica). Después REC-09, REC-17 (pruebas primero), REC-16, REC-14, REC-26, REC-27, REC-12, REC-13, REC-22, REC-10 y REC-35, todos verificables sin modelo. Al final, la fase con modelo única (REC-02). Cada cambio de demo lleva su fila en la tabla de delta (§14.1) y su procedencia.
