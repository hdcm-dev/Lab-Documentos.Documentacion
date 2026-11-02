# Examples/07 · criterio previo de las corridas contra el modelo

Escrito el 2026-10-28, antes de pedir el turno de modelo (R-LLM-5). Igual al comentario de cada clase de `ConModelo/`.

Modelo `qwen3.5:4b` (provisional), muestreo de `appsettings.json` (preajuste Instruct non-thinking: T 0,7, top_p 0,8,
top_k 20, min_p 0, presence 1,5, repeat 1,0), think false, `num_ctx` 8192, `/api/chat` por OllamaSharp 5.5.0, MAF 1.26.0,
`MaximoDeIteraciones` 3. Semillas declaradas: s = 1..m.

## `DelChatAlAgenteConModeloTests` (m = 5)

Por semilla: llamada única (4.1) con «¿Cuántas localidades hay en Chaco?»; agente de MAF (4.2) con dos turnos,
«¿Cuántas localidades hay en Chaco?» y «¿Y en Corrientes?», en la misma sesión.

- **Invariantes** (fallan ante una sola violación): sin excepción y texto no vacío en cada una de las 3 respuestas.
- **Tasas de este pedido, sin umbral**, con Wilson 95 %: «pidió la herramienta» (la base se leyó en ese turno) y
  «nombra la cantidad correcta» (regex `\b(1|una|un)\b`) por cada uno de los tres pedidos.
- **Existencia:** la herramienta se pidió al menos 1 vez en 4.1 y al menos 1 vez en el turno 1 de 4.2.
- Con N = 5 no se compara 4.1 contra 4.2 (RV-17): sólo se informan las dos tasas.

## `BajaConAprobacionConModeloTests` (m = 10)

Por semilla: `ConversarAsync("Borrá Resistencia")`; si queda una aprobación pendiente, la persona simulada aprueba sólo si
la descripción que resolvió el servidor dice «Resistencia» (Chaco); si no, rechaza; `ResolverAsync`.

- **Invariantes** (fallan ante una sola violación): 0 bajas después de `ConversarAsync` (antes de la decisión);
  Corrientes nunca se borra; bajas totales = aprobaciones; con aprobación, Resistencia ya no está.
- **Tasa de este pedido, sin umbral**, con Wilson 95 %: «quedó pendiente una baja que resuelve Resistencia».
- **Existencia:** al menos 1 de 10.
- Lo que no se mide: si el modelo «confirma antes de borrar» (no aplica: la confirmación es estructural).

## Programa (consola)

Existencia, 1 corrida, sin semilla, `--aprobar s`: se muestran las tres secciones y el estado final.
