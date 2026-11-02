# PV-02 · criterio previo (escrito antes de correr, 2026-10-30)

Corrida: `tools/verificar.sh correr 05-Contexto-Completo-Con-Prefijo --con-modelo` sobre una copia de la guía 0.11.0, sólo en la estación 1 (recurso `<recurso-compartido>`, rol de servidor «propio» por variable). La estación 2 sigue apagada (ELV-02) y no se usa. La fase `build` corre antes con su turno. Endpoint sólo por variable (`OLLAMA_PROPIO_URL_CMD`, dentro del turno).

Por qué 05: es el ejemplo de recurso `modelo-propio` (fase 3a) que ya corrió completo en la estación 1 (R-05) y ejerce justo lo que cambiaron P-30 y P-31: la precondición `propio()` con `DIGEST_CHAT_PROPIO` y el defecto de `OLLAMA_PROPIO_MODEL`.

**PV-02 pasa** si se cumplen las cinco condiciones:
1. `servidor-propio.jsonl` registra `ollama_version` 0.40.11, `qwen3.5:4b` = `d8b0f5e9760c` y `qwen3-embedding:0.6b` = `ac6da0dfba84`, y el arnés no aborta en la precondición.
2. `turnos.jsonl` tiene una fila `num-ctx` con `modelo` `qwen3.5:4b` (el defecto, sin `OLLAMA_PROPIO_MODEL` exportada) y `num_ctx_ps` 8192.
3. La fila de turno de la fase con modelo tiene `sin_turno:false`, y el gestor registra concedido y liberado.
4. `/api/ps` está vacío antes de cargar y otra vez después del `keep_alive 0`, todavía dentro del turno.
5. La consola del ejemplo termina sin error de configuración ni de conexión (rc 0, o un rc del ejemplo que sólo informa sus propias cifras).

**No pasa** si falla 1, 2 o 4. Si falla 3 o 5 por causa ajena a P-30/P-31 (por ejemplo, una salida sin respuesta en el plazo), el resultado es «no medido».

Las cifras del ejemplo (caché por contador y par-prefijo, k/n con IC95 Clopper-Pearson) son **informativas**. No reemplazan las de R-05 de la guía ni entran en ella, y no cambian el veredicto de PV-02.
