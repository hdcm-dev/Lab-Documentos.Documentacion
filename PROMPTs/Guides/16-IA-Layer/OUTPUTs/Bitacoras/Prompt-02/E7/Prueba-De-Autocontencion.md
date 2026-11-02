# E7 · Prueba de autocontención del Conocimiento v1

> Etapa E7 del plan integrado (`../05-Plan-Integrado.md` §5, E7; C-5.6). Registro de sólo agregado.
> Fecha: 2026-11-01. §1 y §2 se escribieron **antes** de la primera llamada al agente; su sha256 queda en §3.

## Índice

- [1. Criterio R-LLM previo](#1-criterio-r-llm-previo)
- [2. Caso ficticio público](#2-caso-ficticio-público)
- [3. Corrida](#3-corrida)
- [4. Resultado](#4-resultado)
- [5. Hallazgos de la prueba](#5-hallazgos-de-la-prueba)

## 1. Criterio R-LLM previo

**Definición.** La prueba de autocontención pregunta si un agente que **sólo** tiene el Conocimiento v1 (sin la
guía, sin la bitácora, sin acceso a archivos) puede escribir una especificación completa de un caso nuevo.

**Agente A (especificador).** Proceso `claude -p` aparte, sin herramientas (`--tools ""`), sin persistencia de
sesión, sin MCP. Recibe por la entrada estándar: el texto del Conocimiento v1 y el caso de §2. No puede abrir la
guía porque no tiene herramientas de lectura. Se le pide la especificación en Markdown y, al final, una sección
«Dudas que no pude resolver con el conocimiento».

**Agente B (revisor sin la guía).** Otro proceso igual, que recibe el Conocimiento v1 y la salida de A y llena
el checklist de §12 columna PROTO, ítem por ítem, con SÍ + sección, NO APLICA + motivo, o NO.

**Revisor humano de la mesa (P-14).** Revisa la salida de B. Queda PENDIENTE si no lo hace en la etapa.

**Por qué no la estación 1.** El plan (E7) admite un agente sin la guía fuera de la estación 1; la estación 1
corre un modelo de 4 B con ventana de 8.192 tokens, menor que el Conocimiento (≈ 600 líneas) más la salida. Se
declara como divergencia; no se usa la estación 1 ni se toma turno.

**Pasa** la prueba si se cumplen las cinco:

1. B marca los ítems DEBE de PROTO en SÍ con sección o NO APLICA con motivo, **0 en NO** (D-23 al 100 %).
2. `E4-verificar-requisitos.py` sobre la salida de A da rc 0.
3. 0 códigos ESC-, CTX- o ACT- fuera del catálogo de §3 del Conocimiento (grep).
4. Las «dudas» de A no incluyen ninguna que bloquee la especificación (se clasifican P0–P3; pasa con 0 P0 y 0 P1).
5. La salida usa las reglas nuevas que el caso activa: R-01 (sedes), R-07 (aviso masivo), A1 lectura,
   correspondencia de capas, ADR por tema numeradas en el registro del proyecto, paso 0.

**Qué invalida una corrida:** que A o B hayan tenido herramientas; que la entrada contenga texto de la guía
fuera del Conocimiento. Una corrida inválida se repite una vez; si vuelve a fallar, NO EJECUTADO.

**Determinismo.** Una sola corrida de cada agente: es una prueba de suficiencia del documento, no una tasa.

## 2. Caso ficticio público

Caso inventado para esta prueba; no sale de ningún proyecto real.

> **Red de Bibliotecas del Valle** (ficticia) tiene un servicio ASP.NET Core en producción desde hace tres años.
> Es un único proyecto con carpetas `Controllers/`, `Services/` y `Data/` (Entity Framework Core sobre
> PostgreSQL). Atiende cinco sedes; cada bibliotecario pertenece a una sede, y el administrador ve todas. Los
> lectores dejan **sugerencias de compra** en texto libre («quisiera la última novela de tal autora, en papel»);
> hoy un bibliotecario las lee, les pone una categoría temática del catálogo de 40 categorías y marca si el
> libro ya está en el catálogo. Guardan nombre y correo del lector.
>
> Quieren:
> 1. que un modelo **proponga** la categoría y si la sugerencia es un duplicado de un título del catálogo;
> 2. que el bibliotecario **pregunte en lenguaje natural** «¿cuántas sugerencias pendientes de historia tiene mi
>    sede este mes?»; ya existe `SugerenciasService.Listar(sede, estado, desde, hasta)`, sin filtro por categoría;
> 3. más adelante, que el modelo **avise por correo a todos los lectores** cuyos pedidos llegaron.
>
> El modelo correría en un servidor Ollama de la red (sin nube); es un piloto. El repositorio tiene
> `docs/adr/` con ADR-001 a ADR-014 y un `docs/Glosario.md` que pide agregar términos nuevos antes de usarlos.
> El error caro es una categoría equivocada que esconde la sugerencia de quien la busca, o un falso duplicado
> que la descarta. El jefe de bibliotecas fija los umbrales.

## 3. Corrida

§1 y §2 quedaron con sha256 `5c3d340eee5cc6ce61249873ff60aa89053d5750c592c62e1af8c06e0c81b7a5` antes de la primera
llamada (archivo completo en ese momento). Todo lo que sigue se agrega después.

| Ronda | Hora (-03) | Conocimiento (sha256) | Entrada | Agentes | rc |
|---|---|---|---|---|---|
| 1 | 19:36–19:42 | `3895b96d…cd4b1` | caso de §2 | A | 0 |
| 2 | 19:44–19:53 | `e9593d41…75306` | caso de §2, sin cambios | A, B | 0, 0 |
| 3 | ~19:54–20:02 | `d7d348f2…b0f63d` | caso de §2 + anexo de datos (`Evidencia/anexo.md`) | A, B | 0, 0 |

Comando de cada agente: `claude -p --tools "" --no-session-persistence --strict-mcp-config --setting-sources ""`
con la entrada por la entrada estándar (instrucción `Evidencia/instr.txt` o `instrB.txt` + Conocimiento + caso).
Sin herramientas: ninguna corrida es inválida por §1. Salidas en `Evidencia/` (índice `SHA256SUMS`; los sha256 del
Conocimiento de cada ronda, en `sha-entradas.txt`). Sin estación 1 ni turno (divergencia declarada en §1).

**Divergencias respecto de §1, declaradas.** (a) Entre rondas se corrigió el Conocimiento con lo atribuible a él;
el criterio no cambió. (b) La ronda 3 agrega al caso un anexo con datos que un especificador real tendría (normas
del repo, umbrales, roles); se agregó porque las rondas 1 y 2 separaron los NO en «del conocimiento» y «del caso»,
y los del caso no miden el documento. Las rondas 1 y 2 quedan medidas con el caso original.

## 4. Resultado

| Criterio de §1 | Ronda 1 | Ronda 2 | Ronda 3 |
|---|---|---|---|
| 1. Checklist PROTO sin NO en DEBE (revisor B) | NO: el propio A marcó C-00 y C-17 | NO: C-00, C-04, C-10, C-17, C-18 | NO: C-00, C-13, C-17 |
| 2. Verificador de requisitos rc 0 | **NO**: 10 de 26 incompletos (rc 1) | SÍ: 23/23 (rc 0) | SÍ: 17/17 (rc 0) |
| 3. Códigos ESC/CTX/ACT fuera del catálogo | SÍ: 0 | SÍ: 0 | SÍ: 0 |
| 4. Dudas sin P0 ni P1 | NO: 1 P1 (T-02) | NO: 6 P1 | NO: 1 P1 (T-20) |
| 5. Usa las reglas que el caso activa | SÍ, salvo A1 lectura (la capacidad 2 quedó en «sólo diseño») | SÍ | SÍ (la capacidad 2 sale en −1 por el árbol, con ADR) |

**Veredicto: la prueba NO PASA** el criterio previo en ninguna ronda. Tendencia: los NO del checklist atribuibles
al conocimiento bajan de 3 (ronda 2: C-04, C-10, C-18) a 1 parcial (ronda 3: C-13, causa T-24); C-17 en ronda 3
es de la especificación (denominador del umbral) con causa parcial en el conocimiento (T-20); C-00 es un
artefacto de la prueba: el agente no tiene el repositorio y la regla manda marcarlo NO. Todo lo atribuible al
conocimiento en la ronda 3 se corrigió después en el v1 (sha256 final en `../Ejecucion/E7.md`), **sin una
cuarta ronda que lo confirme**. Revisor humano de la mesa (P-14): PENDIENTE.

## 5. Hallazgos de la prueba

Los 28 hallazgos (T-01 a T-28) y su regla o decisión están en `Caso-A-Regla.md` §4: 0 P0, 8 P1, 17 P2, 3 P3;
25 con regla, 3 con decisión registrada.
