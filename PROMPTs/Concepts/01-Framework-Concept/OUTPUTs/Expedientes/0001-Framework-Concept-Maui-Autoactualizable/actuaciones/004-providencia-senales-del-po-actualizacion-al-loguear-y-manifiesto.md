| Campo | Valor |
| --- | --- |
| Tipo | providencia |
| Fecha | 2026-10-25 |
| Autor | Presidencia de la mesa |
| Corrige | — |

# Providencia — dos señales del Product Owner mientras corría la mesa

Llegaron dos mensajes mientras corría el refutador, el segundo a mitad de turno. Van uno por línea:

```testimonio
lo interesante creo que y es que veo algunas aplicaciones, que la actualizacion es interna - ahora por ejemplo una app híbrida de referencia de la organización es hibrida, una actualizacion del contenido solo es cambiar la aplicación web server , pero el tema es cuando se quiere trabajar en modo sin internet - muchas aplicaciones es como que se actualizan internamente al iniciar un logueo nuevo , sino son operativas perfectamente sin internet
habria que ver tambien las cuestiones de uso de dispositivos, porque el manifiesto no se puede actualizar
```

| Canal | Fecha-hora | Huella |
| --- | --- | --- |
| Chat de Claude Code en VS Code | 2026-10-25T19:45–19:50-03:00 | `80402a1783c53c26a8fce94df73894c374d153a4a4ca0cdb2ab4f8222b8252f6` |

## Clasificación

| Pasaje | Qué es para el caso |
| --- | --- |
| «una app híbrida de referencia de la organización es hibrida, una actualizacion del contenido solo es cambiar la aplicación web server» | Afirmación sobre el estado de un sistema: conjetura hasta medirla. Señala un **caso que funciona** (Mesa-De-Expertos-A-Pedido §3.3, «Caso que funciona antes que diseño»): se mide y se arma la tabla diferencial contra las opciones del borrador |
| «el tema es cuando se quiere trabajar en modo sin internet» | Reafirma la condición sin red, que ya estaba en el borrador (Framework-APP.md §1, ítem 7) |
| «muchas aplicaciones … se actualizan internamente al iniciar un logueo nuevo, sino son operativas perfectamente sin internet» | Señal nueva: **momento de actualización alternativo** (al iniciar sesión, además de al abrir la app) y **operación completa sin red entre sesiones**. Afirmación sobre la industria: hay que respaldarla con fuentes |
| «habria que ver tambien las cuestiones de uso de dispositivos, porque el manifiesto no se puede actualizar» | Señal nueva: **los permisos y capacidades del dispositivo** se declaran en el manifiesto del cascarón (AndroidManifest.xml, Info.plist), que sólo cambia por la tienda. Una actualización de contenido no puede sumar capacidades: hay que decidir el conjunto que trae el cascarón, cómo lo descubre el contenido y qué pasa cuando el contenido pide una que no está |

## Efecto sobre el objetivo y el despacho

- **El objetivo no se reescribe.** «Cuando el usuario abre la aplicación» (prompt) sigue siendo requisito. «Al iniciar un logueo nuevo» entra como alternativa a evaluar dentro de P1/P2, no como cláusula nueva. La operación sin red ya estaba en el objeto. Lectura que menos agrega, declarada.
- **Dos señales nuevas entran en caliente** (Mesa §3.4.3): una comisión ad hoc releva una app híbrida de referencia de la organización como caso de referencia (cómo se actualiza hoy y qué pasa sin red) y el patrón «actualizar al iniciar sesión, operar sin red» en la industria, y analiza la frontera de capacidades del dispositivo fijada por el manifiesto. Se suma la pregunta **P12**: ¿qué capacidades del dispositivo declara el cascarón de antemano, cómo las descubre y las pide el contenido, y qué hace el contenido cuando le falta una?
- **Corrida descartada:** el informe del refutador despachado a las 19:41 se terminó antes de estas señales. Queda sin editar como evidencia 012, fuera de la cuenta del paso 10. Su carta es la evidencia 010; la carta del análisis de decisiones (evidencia 011) se asentó pero ese despacho no llegó a correr. Vuelven a salir el refutador, el análisis de decisiones y el jurado de veredicto, con estas señales y el informe de la comisión en caliente como insumos.
- Las ocho comisiones de la ronda 1 conservan sus informes: sus cartas no cambian.

Sigue: comisión en caliente (caso de referencia (una app híbrida de la organización), actualización al iniciar sesión, capacidades del manifiesto), refutador, análisis de decisiones y jurado de veredicto · presidencia · Cierra con: folios informe correspondientes
