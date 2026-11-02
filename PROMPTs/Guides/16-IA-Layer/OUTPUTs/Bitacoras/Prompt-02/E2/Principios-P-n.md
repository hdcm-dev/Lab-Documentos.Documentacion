# E2 · Principios P-n (lista congelada)

**Etapa:** E2 · **Fecha:** 2026-11-01 · **Dueños:** P-07 Editorial A y P-09 Revisión bibliográfica; ensayo de trazabilidad P-06 · **Fuente:** guía 0.11.0, sha256 `c8defd8324497c4279a3dfd57ce5d2757326ad966813a9f9797d0196d9b7ce3d` · **Estado:** congelada; E4 puede empezar (I-03).

## Índice

1. [Definiciones y reglas](#1-definiciones-y-reglas)
2. [Lista congelada](#2-lista-congelada)
3. [Ensayo de trazabilidad](#3-ensayo-de-trazabilidad)
4. [Lo que no entró y por qué](#4-lo-que-no-entró-y-por-qué)
5. [Uso por el libro y por el Conocimiento](#5-uso-por-el-libro-y-por-el-conocimiento)

## 1. Definiciones y reglas

- **Principio (P-n):** regla de diseño que la 0.11.0 ya aplica, enunciada sin nombrar un tipo .NET (C-3.3: si nombra un tipo, es arquitectura). Los Id van sin cero a la izquierda (P-1…P-10) para no confundirlos con las propuestas de la mesa (P-01…P-14).
- **Origen de la lista:** ADR-01…ADR-10 y §3.1 de la 0.11.0 (D-14 c). Ningún principio nuevo (C-3.1).
- **Ancla interna:** sección o ADR de la 0.11.0 donde el principio ya está escrito. **Fuente externa:** `[REF-n]` del Anexo D; si el enunciado es propio, «criterio de la guía» (C-3.4).
- **Regla de Agent Framework** («si una función resuelve la tarea, escribí la función» [REF-117]): criterio dentro de P-7, no principio propio (D-15 a).

## 2. Lista congelada

| Id | Nombre | Enunciado | Ancla 0.11.0 | Fuente |
|---|---|---|---|---|
| P-1 | Contrato antes que modelo | La capa de IA es un componente con contrato: el núcleo depende de interfaces que define él mismo y el modelo queda detrás de un adaptador. Ninguna dependencia va del modelo al dominio ni a los datos. | §3.1 (invariante), §4.4, ADR-01 (§13.2) | [REF-182], [REF-183] |
| P-2 | Proveedor reemplazable | El proveedor se elige en la raíz de composición, detrás de un contrato común; lo exclusivo de un proveedor se pide de forma explícita. Cambiar de adaptador no prueba que otro proveedor se comporte igual. | §5.6, ADR-02 (§13.3) | [REF-44], [REF-45] |
| P-3 | Dónde corre el modelo se decide por los datos | Local, servidor compartido o nube se eligen por qué datos salen, cuánta concurrencia hay, costo y capacidad; el modelo elegido es provisional mientras no se compare con otro. | §12.4, ADR-03 (§13.4) | criterio de la guía; [REF-55] para la concurrencia por defecto |
| P-4 | El dato exacto se consulta | Lo que calcula una consulta va por un caso de uso, nunca por recuperación por parecido; para el resto, el escalón más bajo de la escalera de conocimiento que alcanza. | §3.2, §6.1, ADR-04 (§13.5) | [REF-86], [REF-87]; la escalera, criterio de la guía |
| P-5 | Usar no es almacenar | El uso del conocimiento recuperado es de la capa de IA y su almacenamiento, de la de datos; el índice depende del modelo de embeddings y cambiarlo obliga a reindexar. | §3.1, §7.3, ADR-05 (§13.6) | [REF-89], [REF-102] |
| P-6 | Actuar por casos de uso, con aprobación | El modelo actúa sólo por casos de uso que aplican las reglas, con privilegio mínimo; toda escritura se aprueba sobre argumentos que arma el código, desde el escalón 1; con texto no confiable no se montan escrituras. | §8.4, §8.5, §11.2, ADR-06 (§13.7) | [REF-122], [REF-160], [REF-162] |
| P-7 | Mínima agencia | Se sube un escalón de agencia sólo cuando el de abajo no alcanza; si una función resuelve la tarea, se escribe la función. | §3.2, §8.1, ADR-07 (§13.8) | [REF-115], [REF-117] |
| P-8 | La salida del modelo es una propuesta | La forma no garantiza la validez: las reglas viven en el código, no en el prompt, y una salida inválida es un camino normal que se diseña. | §2.5, §5.3, ADR-08 (§13.9) | [REF-01], [REF-160] |
| P-9 | Una sola cadena transversal | Las mismas opciones valen para toda llamada, en un solo lugar y en un orden declarado; la telemetría se diseña y el contenido sensible sólo se registra por ambiente. | §5.4, §12.1, §12.2, ADR-09 (§13.10) | [REF-173], [REF-192] |
| P-10 | Evidencia del tipo correcto | Una garantía del código se prueba en cada build y sin modelo; una conducta del modelo se informa como k de M con rótulo (modelo, servidor, fecha) y como tendencia, no como compuerta. | §0.4, §10.1, ADR-10 (§13.11) | [REF-75], [REF-152] |

Tabla 1. Principios congelados.

## 3. Ensayo de trazabilidad

Comprobación mecánica (P-06, C-3.4): `python3 -I Evidencia/trazas.py <copia de la 0.11.0>` verifica que cada ancla interna existe como `<a id>` y que cada `[REF-n]` existe como entrada del Anexo D. Salida en `Evidencia/trazas.txt`: 30/30 anclas y 20/20 referencias, `fallas 0`, rc 0.

Comprobación de contenido (lectura, 2026-11-01): cada enunciado se cotejó con el texto de su ancla en la 0.11.0:

| Id | Texto de la 0.11.0 que lo sostiene (resumen) |
|---|---|
| P-1 | §3.1: «ninguna flecha va del modelo al repositorio ni al dominio»; ADR-01, criterio «el núcleo depende sólo de interfaces definidas en él» |
| P-2 | ADR-02, criterio «proveedor elegido en la raíz de composición»; consecuencia «cambiar de adaptador no prueba que otro proveedor se comporte igual» |
| P-3 | ADR-03, criterio «datos que salen, concurrencia, costo, capacidad»; modelo «provisional, no comparado» |
| P-4 | §6.1 «un dato exacto se consulta»; §3.2 «se sube un escalón cuando el de abajo no alcanza»; ADR-04, criterio |
| P-5 | §3.1 «el uso es de la capa de IA; el almacenamiento, de la de datos»; ADR-05 «cambiarlo obliga a reindexar» |
| P-6 | ADR-06, criterio «no saltear reglas, privilegio mínimo» y decisión «toda escritura aprobable… con texto que la aplicación no escribió, no se montan escrituras» |
| P-7 | §8.1, criterio de salto y la cita de MAF; ADR-07, criterio «¿alcanza una función?» |
| P-8 | ADR-08, título y criterio «reglas en código, no en el prompt; el JSON inválido es un camino normal»; §2.5 |
| P-9 | ADR-09, criterio «las mismas opciones en toda llamada» y decisión «contenido sólo en Development» |
| P-10 | §10.1 garantía del código frente a conducta del modelo; ADR-10, «el LLM juez como tendencia, no como compuerta» |

Resultado: **10/10 P-n con ancla resoluble y 0 inventados.** Ninguno nombra un tipo .NET.

## 4. Lo que no entró y por qué

| Candidato | Origen | Motivo |
|---|---|---|
| Transparencia (EU AI Act art. 50) | U-3.1 | Condicionado a leer el texto en EUR-Lex; no se leyó en esta etapa y no sale de ADR-01…10 ni de §3.1 (D-14 c). Queda fuera. |
| ADR-11, ADR-12, ADR-13 | §13.12–§13.14 | Son decisiones de estructura del laboratorio (carpetas o proyectos, ciclo de vida del cliente, un host); sus enunciados nombran piezas .NET (C-3.3). |
| «Diseñar para el error» como principio aparte | D-14 b | Queda dentro de P-8 (§2.5 es su ancla). |
| «Observabilidad diseñada» aparte | D-14 b | Queda dentro de P-9. |

## 5. Uso por el libro y por el Conocimiento

- El libro: el capítulo 1 enuncia los P-n una sola vez; los capítulos 4, 5 y 14 (ex §3, §4, §13) los citan por Id (C-3.5).
- El Conocimiento (E4): reproduce cada P-n condensado (regla · razón · fuente) y remite al capítulo 1 (D-17 b). Mismos Id (C-3.2).
- Un cambio en la lista después de este congelamiento vuelve a la mesa.
