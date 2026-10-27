| Campo | Valor |
| --- | --- |
| Número | 0002 |
| Título | Replanteo-Metodologia-DocAsCode |
| Objeto | Mesa de expertos a pedido que define una metodología común de evaluación de requerimientos, análisis, diseño, implementación e integración de documentación técnica con DocAsCode, y traza la arquitectura del sistema documentador entero (contenido, fuentes de verdad, topología de repositorios, versionado, audiencias humanas y agentes, publicación, CI y agentes). Decide en escalones con compuerta de dictamen: mini demo sobre MovilidadUrbana.MAUI con workflow en el runner self-hosted y enriquecimiento de la guía del sistema documentador; piloto en Lab-Geometria; aplicación a un SDD privado con mejora de los orquestadores de ambos marcos. |
| Apertura | 2026-10-26 |
| Origen | Product Owner, por tool-prompt en Lab-Documentos.Documentacion, invocado en el chat de Claude Code; folio 001 |
| Base | Lab-Documentos.Documentacion `8da0cd9`; Lab-Documentos `5d5c2b4`; KB-privada `1585af9` |

Índice: `ls actuaciones/`. Fecha y autor: `grep -h '^| Fecha |\|^| Autor |' actuaciones/*.md`. Qué se decidió: el folio `resolucion` (`grep -l '^| Tipo | resolucion' actuaciones/*.md`). Estado y qué sigue: el pase del último folio.

Convención de numeración (P-2, folio 120): los folios son `NNN-`; `0060-` y `0070-` son investigaciones complementarias intercaladas entre `004` y `010`, y el cuarto dígito evita colisión con la serie de comisiones. No se renombran. Corrigendas por referencia: folio `125`.

Estado (2026-10-27): ciclo 2 cerrado (acta `120`, resolución `129`). Sigue: **implementación E1** según `Bitacoras/N10-Plan-De-Implementacion.md` §5–§6 · presidencia.

Versión publicada (unidad E1-U0c, folio `230`): el árbol versionado reemplaza las rutas del equipo por rutas desde la raíz del workspace (`/LAB/…`, `/IA/…`, `/PROG2/…`) y usa estos alias en lugar de datos que no se publican:

| Alias | Qué reemplaza |
| --- | --- |
| `KB-privada` | La base de conocimientos privada del PO (repositorio no público); las rutas que siguen al alias son relativas a ella |
| `INFRA-privada`, `INFRA-privada-ensayo` | El repositorio privado de servicios de runners y su repo de ensayo |
| `{dir-de-trabajo}` | La carpeta de intermedios de los agentes, fuera del repo y borrada al cerrar |
| `{memoria-del-agente}` | La memoria persistente del agente en el equipo del PO |
| `{organización-del-SDD-B}`, `{runner-del-SDD-B}`, `{contenedor-del-runner-del-SDD-B}` | La organización privada del SDD-B, la etiqueta de su runner y su contenedor |
| `{cuenta-del-PO}`, `{usuario-del-host}` | La cuenta del PO y el usuario del equipo |

`evidencia/local/` no se versiona (`.gitignore`).
