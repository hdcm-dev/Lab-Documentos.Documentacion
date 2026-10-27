Comando: `wc -l` y `sha256sum` sobre cada archivo de la carpeta de bitácoras
Fecha-hora: 2026-10-26T14:46-03:00
Quién: presidencia de la mesa (despacho P00)

# Evidencia 002 — Índice de las bitácoras de fase 1 (insumos de la mesa)

> **Nota de origen.** Carpeta medida:
> `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/DEVs/Enchacement/01-Replanteo-Y-Analisis/OUTPUTs/Bitacoras/`
> (en adelante `B/`). Las bitácoras **no están versionadas** (la carpeta del caso figura sin seguimiento en
> Lab-Documentos.Documentacion, `R03:301`); por eso cada una lleva su huella SHA-256 al momento de incorporarse
> (`Rule-Expediente.md` §3.6: huella para lo que no está versionado). Una bitácora que cambie después de esta fecha
> se reconoce porque su huella deja de coincidir. Las bitácoras usan la ruta del host en sus citas, que la carta
> común tolera fuera del expediente; antes de versionarlas corre el barrido S2 (folio 001, §8, pendiente P7).
> Las bitácoras se citan en los folios con la forma `<Id>:<línea>` (por ejemplo `R01:172` = línea 172 de
> `B/R01-Protocolo-De-Mesa.md`).

| Id | Archivo | Líneas | Tema | Huella SHA-256 |
| --- | --- | --- | --- | --- |
| B00 | `B/00-Bitacora-Maestra.md` | 137 | Índice de la corrida, fases, despachos, punto de continuación y pendientes B00-P1…P7 | `181c8ba3d968e368d25d59853a789e977a4730f26d40e79696717d56cb8e97db` |
| R01 | `B/R01-Protocolo-De-Mesa.md` | 664 | Protocolo de mesa: lectura del pedido, clasificación, composición, jurado, consulta a un tercero, expediente, cierre, plantillas | `4dd1f4bc85431e7e87f1116857266f57ae14f5b7801cce877bb059d61025c3cc` |
| R02 | `B/R02-Guia-Actual-Y-Ejemplos.md` | 346 | Guía actual y prueba de concepto reproducida; huecos y deuda inmediata | `bc4afa3471b829496a2689fcb561459f3a3cb669930d4c115496f0caf5ab7707` |
| R03 | `B/R03-SDD-Lab-Documentos.md` | 430 | Marco documental de Lab-Documentos: ia-db (índice), marco SDD de workspace, workflows y runner | `a624bcc2b972a0acbb5d26ed61ad192e795e02bf526362dad873631749db86cd` |
| R04 | `B/R04-SDD-B-Servicio-Push.md` | 337 | Marco SDD del servicio de notificaciones push (privado, con alias) | `a06b6eeaf8845aa8eddbb1f23a5bb7626e42ec357454098c6b8cea33e1503e0c` |
| R05 | `B/R05-MovilidadUrbana-MAUI.md` | 291 | MovilidadUrbana.MAUI como base de la mini demo; ensayo OpenAPI | `9b26aaf4016b07a01b966087e653067b57aa1d3d647d69a4ec39320c3d771602` |
| R06 | `B/R06-Geometria-Estado-Documental.md` | 300 | Estado documental de Lab-Geometria; punto de partida de la piloto | `5d4ca1b18ee0aa54e92da941ee6202e4147a0e083848a534bd6bc1c3efadf00b` |
| R07 | `B/R07-Reglas-PromptFramework.md` | 380 | Lista de verificación VER-* (104 ítems) y tensiones entre reglas | `a28a70c2cb8e7c59e340cbd4a4dfd907e1a93dd1870116a978557b1249b38b7a` |
| I01 | `B/I01-Topologia-De-Repositorios.md` | 276 | Topología: mismo repo, dedicado o híbrido; matriz D1–D8 | `3ea1d1c910d464842f4c62352c3a7ba002da5621590f913379c380e83e94fb89` |
| I02 | `B/I02-Versionado-Y-Deriva.md` | 470 | Versionado de documentación y deriva; cadena docs-guard propuesta | `ace6a2d5282a83119b635b48f7fc5c9144c87725a096d38d45deee9c5e98544f` |
| I03 | `B/I03-Documentacion-Para-Agentes-IA.md` | 361 | Canales para agentes, escritura por agentes, riesgos; requisitos R1–R20 | `6ec31657e7feffea6120bfea8cd7cbab85f581c493028333da3785d192a9308c` |
| I04 | `B/I04-Estandares-Y-Metodologias.md` | 435 | Serie ISO/IEC/IEEE 2651x, 15289, 12207, Diátaxis, DITA, arc42, C4, MADR | `84a14ab67847995a51b7fd1bbde06c0aefe6438a877df489bbd865cc7200a3c2` |
| I05 | `B/I05-Edicion-Academica-Y-Material-Formativo.md` | 364 | Calidad documental, APA 7, CQ-01…14, PE-01…12 | `42ece7f73aceb60709788b5498283fc8ce60aaa991be20f0bc7201d3625492dd` |
| N00 | `B/N00-Cohesion-Global.md` | 292 | Cohesión global: núcleos, grafo, contradicciones X1–X13, matriz de trazabilidad, orden, integración | `d6fa8e5ae04127e1a35f01a80bb4dc1cabfa29a6bf120f1f5bc3d7926dcf7aa0` |
| N01 | `B/N01-Gobierno-De-La-Mesa-Y-Evidencia.md` | 170 | Núcleo N01 — gobierno de la corrida | `57c8337fac6f7fc85f118b69c3cac123839831f1bb38d9b1ecf899f90404e40a` |
| N02 | `B/N02-Topologia-Versionado-Y-Coordinacion.md` | 168 | Núcleo N02 — topología, versionado y coordinación | `0277c712006d6d9925263ef5b3048c28c27eea58eb7756a938654cfaf094e9cf` |
| N03 | `B/N03-Doble-Audiencia-Humanos-Y-Agentes.md` | 160 | Núcleo N03 — doble audiencia: personas y agentes | `eaaba17342a684748353941c0b769b8bc494a155640482d68e969b556181ba45` |
| N04 | `B/N04-Metodologia-Del-Ciclo-Documental.md` | 166 | Núcleo N04 — metodología del ciclo documental | `147cb332de079635feda805754e501dcc3c0e01cf364fe7704c2467cb36c6e4b` |
| N05 | `B/N05-Arquitectura-De-Referencia-Y-CI.md` | 187 | Núcleo N05 — arquitectura de referencia y CI | `d7a5d530f1304e8d529663ff7d5797ec5b987babe646fa5d58a4dd402409f322` |
| N06 | `B/N06-Marco-SDD-Compartido-Y-Orquestadores.md` | 165 | Núcleo N06 — marco SDD compartido y orquestadores | `0930e91d6ab88f531d4e9ff339d81cef916fd1293113c20237d69a4c3126c078` |
| N07 | `B/N07-Demostraciones-Piloto-Y-Aplicacion.md` | 182 | Núcleo N07 — demo, piloto y aplicación | `3a17ec37c8f82a014c1e9b9ef1683e1cd1cbc5842811ecb8bc458725d11c2ebd` |
| N08 | `B/N08-Guia-Y-Material-Formativo.md` | 183 | Núcleo N08 — guía y material formativo | `13bc5be66294f6ba6306b77505b394c8fa85100acdd9c5aee1ee6fed570404f2` |
| C00 | `B/C00-Critica-De-Completitud.md` | 230 | Crítica adversarial de completitud; correcciones aplicadas; pendientes P1–P7 para la mesa | `6e3ef04b92c683fd44d5696af58e82e140ca7170874ffb9097e0ef47a86e7710` |

**Totales.** 23 bitácoras: 1 maestra (B00), 7 relevamientos (R01–R07), 5 investigaciones (I01–I05), 1 cohesión
global (N00), 8 núcleos (N01–N08) y 1 crítica (C00). Ningún despacho de fase 1 quedó caído (`B00:110-112`).

**Nombres de archivo.** El nombre de archivo `R04-SDD-B-Servicio-Push.md` usa el alias del servicio privado, no
su nombre; su contenido usa alias sistemáticos (`C00:194`). Los archivos de `B/` no traen, en su nombre, ningún
dato privado.
