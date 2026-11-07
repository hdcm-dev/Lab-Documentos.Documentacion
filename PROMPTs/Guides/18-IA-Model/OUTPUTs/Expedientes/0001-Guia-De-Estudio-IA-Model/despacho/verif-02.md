# Constancia de verificación técnica — núcleo 02 (Arquitectura Transformer y variantes)

Verificador técnico · 2026-11-07 · documento: `Guides/IA/IA-Model/02-Arquitectura-Transformer.md`
Banco: Ollama real por API en `$OLLAMA_HOST` (CTX-03). Entorno local: Python 3.11.2, numpy 1.24.2.
Logs crudos en `../evidencia/local/` (fuera del versionado).

## Corridas

### 1. Laboratorio 1 (§3.1) — atención a mano en numpy — VERIFICADO

- Comando: `python3 atencion_juguete.py` (script copiado carácter a carácter del documento; corrido con `python3 -I`).
- Log: `verif-02-lab1-atencion.log` — SHA-256 `85e41c4be2ea377215a4255d8210902aa83b68f43c9b4f5b4f8e3d387764a4ea`.
- Extracto: `siesta 0.01 0.00 0.01 0.97 0.01 0.00` / `Salida para 'duerme' ... [-0.89 -1.7 2.12 -0.07]`.
- Veredicto: **verificado** — la salida pegada en el documento coincide dígito a dígito con la corrida (determinismo por semilla 42 confirmado). Triángulo superior en cero y filas que suman 1, como el texto afirma.

### 2. Laboratorio 2, paso 0 (§3.2) — banco accesible — VERIFICADO

- Comando: `curl -s "${OLLAMA_HOST:-http://localhost:11434}/api/tags" >/dev/null && echo "banco accesible" || ...`
- Log: `verif-02-lab2-paso0.log` — SHA-256 `f8eeadd26f13e1bde95500387fb965429311c1c39084091c3edec7f687480f5b`.
- Extracto: `banco accesible`.
- Veredicto: **verificado**.

### 3. Laboratorio 2, paso 1 — `ollama show qwen3.5:4b` — ILUSTRATIVO

- El puesto de verificación no tiene el cliente `ollama` (sólo `curl`); el banco se usa por API y la carta prohíbe tocar su configuración. No se instaló el cliente (regla «consultar antes de instalar»).
- Veredicto: **ilustrativo** — marcado en el documento como `**[Ilustrativo — no verificado en el banco]**` con el motivo; la misma ficha queda verificada cruda en el paso 2.

### 4. Laboratorio 2, paso 2 — `/api/show` de `qwen3.5:4b` — CORREGIDO y verificado

- Comando: el del documento (`curl .../api/show -d '{"model":"qwen3.5:4b"}' | python3 -m json.tool | grep -E ... -i`).
- Corrección aplicada: se quitó `digest` del patrón de grep — verificado que `/api/show` no devuelve ningún campo digest (claves de nivel superior: license, modelfile, parameters, template, details, model_info, projector_info, tensors, capabilities, modified_at, requires); el digest vive en `/api/tags`. En consecuencia se corrigió también el «Si difiere» (el digest lo da `/api/tags` u `ollama list`, no `ollama show`).
- Log: `verif-02-lab2-paso2.log` — SHA-256 `3a868aa72e097af111b514d5d05b417904c312a41937d036c2fb51bbccad565d`.
- Extracto: `general.parameter_count: 4205751296`, `block_count: 32`, `head_count: 16` / `head_count_kv: 4`, `context_length: 262144`, `rope.freq_base: 10000000`, `quantization_level: Q4_K_M`.
- Veredicto: **corregido** (comando y texto) — salida real pegada en el documento con etiqueta y digest (`d8b0f5e9760c`). La ficha trae además un bloque `clip.*` (proyector de visión): se agregó una aclaración de lectura en el documento. La referencia «en el paso 1, dividí head_count…» se movió al paso 2 (el paso 1 quedó ilustrativo).

### 5. Laboratorio 2, paso 3 — `/api/show` de `qwen3.5:35b-a3b` — CORREGIDO y verificado

- Corrección aplicada: el patrón de grep original no incluía `ssm` ni `full_attention`, con lo que la lectura que el propio documento pide («si además aparece `full_attention_interval`…») jamás aparecía en la salida. Nuevo patrón: `...|expert|ssm\.|full_attention` (`ssm\.` evita arrastrar ~240 líneas de nombres de tensores `ssm_*`).
- Log: `verif-02-lab2-paso3.log` — SHA-256 `3307ea57f9921bcca5b632fb26d45523ac401c2ac3459160e2899c55e224fb26`.
- Extracto: `architecture: qwen35moe`, `parameter_count: 34660610688`, `expert_count: 256` / `expert_used_count: 8`, `full_attention_interval: 4`, `ssm.state_size: 128`, `head_count: 16` / `head_count_kv: 2`.
- Veredicto: **corregido** (comando) — salida real pegada con digest (`72aac7c28be8`).

## Afirmaciones ancladas verificadas contra la ficha real

- Mermaid §1.3 «32 en el modelo del laboratorio 2» → `qwen35.block_count: 32` ✓.
- §1.7 «16 cabezas Q contra 4 KV = GQA con grupos de 4» → coincide con la ficha del 4b ✓ (el MoE usa 16/2, grupo de 8; el texto lo presenta como ejemplo, no como cifra del MoE).
- §1.6 ícono «256 especialistas… cada paciente ve sólo a 8» → `expert_count: 256`, `expert_used_count: 8` ✓.
- §1.7 «SSM intercalados con atención completa cada cuatro capas» → `full_attention_interval: 4` y claves `ssm.*` presentes ✓; en los tensores, los bloques 3, 7, 11… no llevan `ssm_*` (atención completa), consistente.
- §1.5 ancla `rope.*` con `freq_base` alta → `rope.freq_base: 10000000` (vs 10 000 del diseño original) y `context_length: 262144` ✓.
- Paso 2 «la etiqueta redondea, la ficha no» → 4b vs 4 205 751 296 ✓.
- Cifras M3 con protocolo: el documento no tiene bloques «protocolo»; las cifras de literatura (Mixtral 47 B/13 B) van citadas a arXiv:2401.04088 y no tienen comando asociado — fuera del alcance de esta verificación.

## Resumen

- Verificados: 2 (lab 1; lab 2 paso 0). Corregidos: 2 (lab 2 pasos 2 y 3 — correcciones de comando/texto, con salida real pegada). Ilustrativos: 1 (lab 2 paso 1, `ollama show`). Bloqueados: 0.
- Front matter `entorno_validado` actualizado: laboratorio 2 verificado por API contra el banco (CTX-03), 2026-11-07.

## Dudas para el PO

- El paso 1 (`ollama show`) quedó ilustrativo por falta del cliente en el puesto de verificación. Si se quiere salida real también ahí, hace falta decidir dónde y con qué versión fija instalar el cliente `ollama` (regla «consultar antes de instalar»).
