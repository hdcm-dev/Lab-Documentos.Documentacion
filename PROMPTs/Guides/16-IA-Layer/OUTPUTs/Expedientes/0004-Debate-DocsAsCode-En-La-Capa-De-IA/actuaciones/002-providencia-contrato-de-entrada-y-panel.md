| Campo | Valor |
| --- | --- |
| Tipo | providencia |
| Fecha | 2026-11-03 |
| Autor | Presidencia de la mesa conjunta |
| Corrige | — |

# Providencia — contrato de entrada, enunciado, objetivo y panel

Norma leída: `Knowledge-Mesa-De-Expertos-A-Pedido` (IA.SDD, `Conocimiento/`) §0, §2.2, §2.3, §3.2, §4 y §5.3;
`Expediente-Rules.md` (IA.SDD, `SDD/Devs/Rules/`) entera. Lo que la presidencia agrega por su cuenta va marcado
**(agregado de la presidencia)**.

## 1. Alias

| Alias | Qué es |
| --- | --- |
| Sesión DocsAsCode | La sesión que llevó los expedientes 0002 y 0003 de Lab-Documentos.Documentacion y la aplicación del conocimiento de especificación DocsAsCode a Lab-Geometria y a un servicio privado |
| Sesión «Capa de IA» | La sesión que radica este expediente: guía 16 de Lab-Documentos (integración de una capa de IA en .NET), su aplicación a Lab-Geometria y a `{servicio-privado}`, y la mesa de evaluación de modelos |
| `{servicio-privado}` | Servicio privado de notificaciones con consulta en lenguaje natural para un operador; sólo como concepto |

## 2. Radicación y condición de apertura

Se radica en Lab-Documentos.Documentacion, carpeta `PROMPTs/Guides/16-IA-Layer/OUTPUTs/Expedientes/`, junto a
las bitácoras de la guía 16. Cumple las dos ramas de `Expediente-Rules.md` §1: el caso atraviesa dos sesiones y
tres repositorios (más uno privado), y entra material externo —normas y publicaciones— que funda la respuesta.
Ninguna exclusión lo describe entero: no es la mesa de un destino con `Audit/`, por eso los informes van como
folios verbatim (§3, «Lo que se asienta verbatim»).

## 3. Enunciado

| # | Frase | Origen |
| --- | --- | --- |
| E-1 | ¿Cómo, metodológicamente, en la industria, el concepto de Docs as Code se integra dentro de una capa de IA? | Folio 001, mensaje 1 |
| E-2 | Armar una mesa que cite a los expertos de ambas sesiones | Folio 001, mensaje 2 |
| E-3 | Generar un expediente **de debate** | Folio 001, mensaje 2 |
| E-4 | Que los expertos expongan sus conocimientos | Folio 001, mensaje 2 |
| E-5 | Cada sesión trae su posición, con su elenco, sus tesis y sus preguntas abiertas | Agregado de la presidencia: es la forma de «citar a los expertos de ambas sesiones» sin reabrir sus mesas |

## 4. Objetivo, con el origen de cada cláusula

| # | Cláusula | Origen |
| --- | --- | --- |
| O-1 | Un dictamen que responda E-1 sin «depende», con fuentes externas reales | E-1; regla de cierre de la clase (Mesa a pedido §2.2) |
| O-2 | Las dos posiciones y los cinco informes foliados verbatim | E-2, E-4 |
| O-3 | Una respuesta por separado a cada pregunta abierta de las dos sesiones y del refutador | Regla de cierre de la clase |
| O-4 | Un plan de adopción **sólo** con propuestas de objeto y costo bajo en Lab-Geometria y `{servicio-privado}`; lo demás, «ideas expuestas, no adoptadas» | Agregado de la presidencia, aceptado por el jurado tras el reparo O-1/O-3 del refutador (folio 011, «Clase de objeto»): el PO pidió un debate, no una aplicación |
| O-5 | El expediente no publica nada que el repositorio público no deba llevar | `Expediente-Rules.md` §4, S2 |

## 5. Clase de objeto

**Diseño de una norma o decisión** (Mesa a pedido §2.2): las comisiones de dominio citan normas con su número y
publicaciones con su autor y año, sin inventar cláusulas; el refutador ataca el costo de aplicar; el cierre
responde cada pregunta por separado. El jurado la mantiene **sólo para la forma del cierre** (folio 011).

## 6. Contrato de entrada

| Elemento | Valor |
| --- | --- |
| Insumos de las partes | Posición de la sesión DocsAsCode (folio 003) y de la sesión «Capa de IA» (folio 004) |
| Evidencia admitida | E1 lo que se verifica contra los repositorios públicos; `C` lo que se apoya en borradores fuera de los repos, que sólo funda pregunta |
| Restricciones | Repositorio público: `{servicio-privado}` por alias; sin máquinas, direcciones, puertos, usuarios, rutas del host ni credenciales; nombres de modelos y cifras de la evaluación admitidos sólo junto al producto público |
| Quién aplica | Quien convocó la mesa; ni el panel ni el jurado (Mesa a pedido §4) |
| Criterio de corte | Una ronda; cierre por decisión con lo abierto enumerado |

## 7. Composición del panel

| Rol | Mandato | Carta |
| --- | --- | --- |
| C-DAC-IND | Docs as Code como práctica de la industria: qué es, qué controla y dónde termina | evidencia 003 |
| C-DOCS-COMO-CONTEXTO | La documentación como insumo de agentes y de recuperación: `llms.txt`, `AGENTS.md`, MCP, filtro por audiencia, OWASP Top 10 para aplicaciones LLM 2025 | evidencia 004 |
| C-GOB-IA | Gobernanza y documentación de sistemas de IA: NIST AI RMF, ISO/IEC 42001, Reglamento (UE) 2024/1689, model cards, datasheets | evidencia 005 |
| C-LLMOPS | Prompts como código, evaluaciones versionadas, contratos de herramientas, métricas con intervalo, despliegue desde main | evidencia 006 |
| C-DIDACTICA | Cómo convierten estos dos proyectos en material de estudio de la capa de IA | evidencia 007 |
| Refutador | Ataca la lectura dominante, el objetivo contra el pedido literal y el costo de aplicar | evidencia 008 |
| Jurado de veredicto | Tres votos independientes (industria, gobernanza, aplicación), mayoría con disidencia asentada | evidencia 009 |
| Posición «Capa de IA» | Secretario de la sesión: elenco, posición y preguntas | evidencia 002 |
| Posición DocsAsCode | La propia sesión DocsAsCode, a pedido | Sin carta en este expediente: la escribió la otra sesión y entregó su folio |

**Descartes (agregado de la presidencia):**

- **Comisión de seguridad propia**: descartada; OWASP LLM y el principio de menor privilegio caen en el mandato
  de C-DOCS-COMO-CONTEXTO, y el refutador cubrió el riesgo de publicación (R-9).
- **Perito**: descartado; la clase no es investigación de un defecto.
- **Análisis de decisiones aparte del jurado**: descartado por ser una sola ronda; el jurado vota con disidencia.
- **Usuarios estándar y moderador de objetivos**: descartados; la clase no es interfaz en ejecución.
- **Reabrir las mesas de cada sesión**: descartado; cada sesión trae su elenco en su posición (E-5).

## 8. Despacho

Cartas asentadas en `evidencia/` (001 a 009). **Incidencia declarada:** las cartas no se asentaron antes de
despachar, como pide `Expediente-Rules.md` §3.5; se incorporan después, extraídas sin editar del registro de la
sesión, con las rutas del host redactadas por S2 y sin el rótulo del arnés que envuelve cada texto. No quedó vivo
un despacho anterior del mismo rol: es la primera mesa del caso.

Sigue: incorporar las dos posiciones y los siete informes · presidencia de la mesa · Cierra con: folio 011
