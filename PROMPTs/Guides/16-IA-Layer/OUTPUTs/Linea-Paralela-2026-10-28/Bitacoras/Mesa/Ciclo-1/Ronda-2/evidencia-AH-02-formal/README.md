# Evidencia de la consulta dirigida a AH-02 (PC-10), ciclo 1, ronda 2, 2026-10-28

| Archivo | Qué es |
|---|---|
| `sonda_pc10.py` | Sonda R-LLM. El criterio de éxito está escrito en el docstring ANTES de correr: exactamente una llamada y a `buscar_requisitos`, igual que EA-6 [R4]. El endpoint sale de `OLLAMA_ENDPOINT` y nunca se imprime. |
| `salida-pc10-qwen3.5-4b.jsonl` | Salida cruda: 1 cabecera y 59 corridas. La cabecera trae modelo@digest, versión de Ollama, opciones, sistema y pedidos. |
| `turno.log` | Concesión y liberación del recurso `<recurso-compartido>` (dueño `ah02-pc10`, rc=0). |
| `analisis_pc10.py` | Análisis sin modelo: Wilson por pedido, ICC, efecto de diseño, bootstrap por conglomerado, permutaciones, Fisher y reproducibilidad. |
| `salida-analisis-pc10.txt` | Salida de `python3 -I analisis_pc10.py salida-pc10-qwen3.5-4b.jsonl`. |

**Comando:**

```
export DIR_TURNOS={dir-de-turnos}
<envoltorio-de-turnos> <recurso-compartido> ah02-pc10 "PC-10 ICC semillas vs pedidos (60 corridas 4b)" 45 -- \
  python3 -I sonda_pc10.py qwen3.5:4b > salida-pc10-qwen3.5-4b.jsonl
```

**Corrida:** el Ollama propio en contenedor (estación 1), Ollama 0.40.11, `qwen3.5:4b@d8b0f5e9760c…`, `/api/chat`, T 0,7, `num_predict` 300, `think:false`. Inicio 2026-10-28T15:05:19Z; 25,4 min de pared en total.
