# Mesa · Ciclo 1 · 02 — Voto del juez de coherencia histórica

> Fecha: 2026-10-07. Rol: juez 4, coherencia histórica (marco `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §4.3 y §5.3).
> Función objetivo: ¿el ítem reabre una decisión cerrada o contradice otro veredicto del ciclo?
> Decisiones cerradas consultadas: contrato `00-Contrato-De-Entrada.md` (DC-01…DC-07, SUP-01…SUP-06, `fuera_de_alcance`, R-ESCR); `01-Descomposicion-Conceptual.md` §3 (segmentación); `02-Cohesion-Global.md` §4 (tensiones resueltas) y §6 (estructura prevista); `03-Marco-De-Referencia.md` (N6 «sólo CI», de criterio propio y sometido a la mesa); `04-Integracion.md` §3 y §4 (CI-01…CI-12, con la regla «gana E1 o la fuente primaria; las recomendaciones se resuelven por escenario y contexto, nunca con una regla global»).
> Criterio aplicado: reabrir una decisión cerrada es legítimo sólo con evidencia nueva de nivel E1/E4 que la decisión no tuvo; en los ítems [CONTRADICCIÓN], voto la dirección que no contradice decisiones vigentes o, si alguna debe caer, la que trae esa evidencia.

| Id | Voto | Fundamento |
|---|---|---|
| C1-01 | PROCEDE | Reabre CI-05 («una estación desalineada no rompe localmente») y es legítimo: la premisa queda refutada por E1 (exit 145) y la regla de 04 §4 hace ganar a E1; se repara en CI-05 y en §6.4. |
| C1-02 | PROCEDE | No reabre nada: acota una generalización al caso medido; es coherente con la regla «gana E1» y no contradice otro ítem. |
| C1-03 | PROCEDE | Dirección (b): CI-05 ya cerró «con lock: `disable`; sin lock: `latestPatch`; la guía presenta la elección», y 04 §4 prohíbe la regla global; el «lock como condición» de la guía es lo que se aparta de lo cerrado. Fija el marco de C1-01 y C1-26. |
| C1-04 | PROCEDE | Corrección factual con E1+E2; no toca ninguna decisión cerrada ni otro ítem. |
| C1-05 | PROCEDE | Hace cumplir una decisión cerrada (N7 = un script de compuerta único, local = CI; 04 §4 cierre) que la guía hoy incumple con dos scripts y `n/a` en la disposición de N8. |
| C1-06 | PROCEDE | Coherente con SUP-05 (VS en Windows es estación válida) y con la severidad S2 del contrato §3 (ejemplo no reproducible desde Windows); no reabre la decisión «WSL dentro de N5», sólo la limita. |
| C1-07 | PROCEDE | Sostiene lo cerrado (Anexo A como plantillas que se verifican juntas, EA-1); no reabre nada. Se resuelve junto con C1-05 y C1-08. |
| C1-08 | PROCEDE | Dirección (a) + sumar la herramienta a §5.2.5: la compuerta única es decisión de N7 y CI-11 cerró «la política la hace cumplir un chequeo que lee `.editorconfig`», que editorconfig-checker cumple como alternativa; reemplazar la arquitectura de la compuerta reabriría N7 sin que el E1 la refute. |
| C1-09 | PROCEDE | Error de procedimiento con E1; no reabre decisiones ni choca con otro ítem. |
| C1-10 | PROCEDE | Dirección (a): CI-02 cerró el BOM «por estado del repositorio, lo inaceptable es no declarar»; agregar la rama «heredado sin convertir» y corregir `*.csproj` con el E1 de `dotnet new console` extiende CI-02, mientras (b) lo reabriría sin evidencia que lo refute. |
| C1-11 | PROCEDE | Precisión factual con E1; mismo criterio que CI-09 (adoptar la formulación que contiene a las otras). |
| C1-12 | PROCEDE | Resuelve una contradicción interna §11.2.5 vs §6.2.3 con E1; no reabre decisiones. |
| C1-13 | PROCEDE | La guía incumple CI-10 («las plantillas usan 24.21.0»): A.10 en Node 22 contradice lo cerrado; alinear a 24 es aplicar la decisión, no reabrirla. |
| C1-14 | PROCEDE | Aplica la tensión cerrada de 02 §4 / 04 §3 («imagen multi-runtime o varias: criterio por contexto», E8-5) y la compuerta única de N7; las secciones que deciden fijo la contradicen. |
| C1-15 | PROCEDE | Snippet que no corre como está escrito (S1/S2 del contrato §3); corrección factual sin decisión en juego. |
| C1-16 | PROCEDE | Corrige una afirmación falsa con E4; es compatible con cualquier resultado de C1-18 y conviene redactarla después de esa dirección. |
| C1-17 | PROCEDE | Corrección contra la especificación SLSA v1.2 (E4); no reabre decisiones y es coherente con C1-16. |
| C1-18 | PROCEDE | Dirección (b) §12 paso 8a/8b: 03 L84 dejó «sólo CI» como criterio propio sometido a la mesa, 04 §4 manda resolver por escenario, y C1-16/C1-17 muestran que el camino firmado no entrega lo prometido; (a) chocaría con esos dos veredictos. |
| C1-19 | PROCEDE | Precisión con E4; la fila de GitLab no viola `fuera_de_alcance` porque la guía ya usa GitLab (CI-01, [B191]); mantenerla en una línea. |
| C1-20 | PROCEDE | Aplica CI-06 (que actualice un `FROM …@sha256` está **no verificado**); §8.2.2 se aparta de lo cerrado; el rótulo cambia sólo si la verificación nueva en docs.github.com lo levanta. |
| C1-21 | PROCEDE | Dirección (b): coherente con la tensión cerrada de 02 §4 (la CI es la fuente de verdad y el devcontainer, una comodidad, SUP-05) y con CI-06 (sin `devcontainers` en repos privados; la actualización de digests, no verificada); (a) se apoya justo en lo que CI-06 dejó sin verificar. |
| C1-22 | PROCEDE | Aplica R-PO-3 y la S2 del contrato («recomendación sin el contexto en que aplica»); no reabre nada. |
| C1-23 | PROCEDE | Agrega una subsección a la plantilla de 02 §6 sin quitar ninguna pieza; no contradice DC-07 ni el Profile. Se registra como cambio de estructura para ciclos siguientes. |
| C1-24 | PROCEDE | Respeta 02 §6 (§3 = mapa conceptual de N0) si se resuelve con «dos velocidades»; reubicar §3.3 fuera de §3 sería reabrir la estructura y no lo apoyo. |
| C1-25 | PROCEDE | Aplica R-PO-2 (glosario en el Anexo C) y la univocidad terminológica que fundó N0; no reabre nada. |
| C1-26 | PROCEDE | La cita literal se corrige sin depender de nada; el alcance «lock sólo en ejecutables» se redacta después del veredicto de C1-03, para no contradecirlo. |
| C1-27 | PROCEDE | Comandos que fallan copiados (E1); corrección sin decisión en juego. |
| C1-28 | PROCEDE | Fidelidad del extracto al script real; no hay decisión cerrada en juego. |
| C1-29 | PROCEDE | E8-5 cerró la igualdad entre imágenes de CI, no la igualdad estación vs CI; la frase generaliza más allá de lo cerrado, y §8.2.4 ya admite hashes distintos. |
| C1-30 | PROCEDE | Atribución errónea refutada por E1; no reabre nada. |
| C1-31 | PROCEDE | Matiz factual con E1; no contradice decisiones del contrato ni CI-10. |
| C1-32 | PROCEDE | Compatible con cualquier dirección de C1-18; se redacta dentro de la rama de firma que deje C1-18 y no en la ruta estándar. |
| C1-33 | PROCEDE | Extiende a los tres ecosistemas lo que DC-02 y P-09 exigen; no reabre nada. |
| C1-34 | PROCEDE | Error de cita (E2); no hay decisión cerrada sobre SPDX. |
| C1-35 | PROCEDE | Corrige la caracterización de una fuente; no reabre la resolución de N1. |
| C1-36 | PROCEDE | No reabre la tensión cerrada «el atributo `eol` gana a `core.autocrlf`»: cambia el argumento y suma `text=auto` como opción, coherente con «criterio por contexto». |
| C1-37 | PROCEDE | Corrección con E1; no hay decisión cerrada sobre la forma de merge. |
| C1-38 | PROCEDE | Aplica la decisión cerrada de 03 (marco fijado una vez y referenciado) sin cambiar IDs (los IDs son estables). |
| C1-39 | PROCEDE | Repara una contradicción interna a favor de la ruta de lectura de §0 (02 §6, pieza README de DC-01). |
| C1-40 | PROCEDE | Aplica Rule-Evidences y la univocidad de N0; no reabre nada. |
| C1-41 | PROCEDE | Aplica R-EVID y lo que la propia guía promete; no hay decisión en juego. |
| C1-42 | PROCEDE | Repara el mapa contra la tabla de capas de N0 y la estructura de 02 §6; no la cambia. |
| C1-43 | PROCEDE | Aplica R-PO-2 / 02 §6 («la guía no remite a la bitácora»); el SBOM se resuelve con criterio por contexto, en línea con `fuera_de_alcance` («ninguna herramienta única»). |
| C1-44 | PROCEDE | Aplica R-PROF y el marco cerrado de 03 (CTX-*) que la guía no explota; no reabre nada. |
| C1-45 | PROCEDE | 02 §6 ya preveía «métodos y marcos» en §8; la guía se aparta de la estructura cerrada. La exclusión por DC-02 vale si se declara con fuente. |
| C1-46 | PROCEDE | Aplica Rule-Dual-Audience y la trazabilidad de 02 §5; ninguna decisión en contra. |
| C1-47 | PROCEDE | Aplica Rule-Dual-Audience («bloques entradas/salidas/validaciones») y Rule-Documentation; no reabre nada. |
| C1-48 | PROCEDE | Coherente con R-ESCR (la ia-db no se escribe): sólo se registra el apartamiento y se avisa al PO con la entrada propuesta, que es la vía prevista. |

## Dependencias de orden que este juez señala

- C1-03 decide antes que C1-01 (texto de §6.4) y C1-26 (alcance del lock en bibliotecas).
- C1-18 decide antes que C1-16, C1-17 y C1-32.
- C1-08 se aplica en el mismo parche que C1-05, C1-06 y C1-07 (misma sección: marco §5.4, «parches solapados se fusionan»).
- C1-21 se aplica junto con C1-13 y C1-20 (A.9, A.10, A.13).
- Decisiones de la bitácora que quedan reabiertas por evidencia nueva y deben repararse en su origen: **CI-05** (por C1-01 y C1-03). Se extiende **CI-02** (por C1-10). Se aplican sin reabrir: **CI-06** (C1-20, C1-21) y **CI-10** (C1-13).
