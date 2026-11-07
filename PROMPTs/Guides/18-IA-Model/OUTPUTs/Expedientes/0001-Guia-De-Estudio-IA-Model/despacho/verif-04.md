# Constancia de verificación técnica — Núcleo 04 (Datos y corpus)

Verificador técnico · 2026-11-07 · Documento: `Guides/IA/IA-Model/04-Datos-Y-Corpus.md`
Entorno: Python 3.11.2, CTX-01 (CPU, sin red, sin modelo — los tres laboratorios no usan el banco).
Insumos sembrados por el verificador desde los heredocs del propio documento, en directorio temporal.

## Corridas

### 1. Laboratorio 1, paso 1 — `python3 validar.py mini-dataset.jsonl`
- Log: `evidencia/local/verif-04-lab1-paso1.log`
- SHA-256: `aa781226bbee66e450ae801a5cc920fe2ff1ab8906274a2e9244a8c189f21725`
- Extracto: `ejemplos válidos: 12` / `errores: 0`
- Coincide exactamente con la salida pegada en §3.1. **Veredicto: verificado.**

### 2. Laboratorio 1, paso 2 — `python3 validar.py roto.jsonl` (dos líneas rotas agregadas)
- Log: `evidencia/local/verif-04-lab1-paso2.log`
- SHA-256: `a4b46de9bfbcf1969787ebba9d9f16ca26a8dacd137a1d129fb6aa9cccd2a8c6`
- Extracto: `errores: 2` / `línea 13: faltan campos ['respuesta']` / `línea 14: JSON inválido (Expecting ',' delimiter)`
- Coincide exactamente, incluido el mensaje del `JSONDecodeError` en Python 3.11.2. **Veredicto: verificado.**

### 3. Laboratorio 2 — `python3 dedup.py mini-dataset.jsonl`
- Log: `evidencia/local/verif-04-lab2.log`
- SHA-256: `cd9a562fb79f676bdce69d387db757162ea2b82125c3012327bef0c1055a1d0f`
- Extracto: `únicos tras deduplicar: 10` / `ds-005 duplica a ds-001` / `ds-006 duplica a ds-001`
- Coincide exactamente; `mini-dataset.dedup.jsonl` queda con 10 líneas, como anuncia el texto. **Veredicto: verificado.**

### 4. Laboratorio 3 — `python3 solapamiento.py mini-dataset.dedup.jsonl`
- Log: `evidencia/local/verif-04-lab3.log`
- SHA-256: `4825e4b7781efa7c58146855d0e644f232ad232137d984172156dba17ee50f75`
- Extracto: `ds-001 ~ ds-007: Jaccard 0.68` / `ds-012 solapa con ev-01: Jaccard 1.00`
- Coincide exactamente con §3.3, cifras incluidas (0,68 y 1,00). **Veredicto: verificado.**

### 5. Adversarial — claim «Si difiere» del lab 3 (correr sin el lab 2 previo)
- Log: `evidencia/local/verif-04-lab3-adversarial.log`
- SHA-256: `c3c4b391fb3d3a8d07023d866d6427f8b64f5b0a6c2d8cb12faeba2ea68cc860`
- Extracto: `FileNotFoundError: [Errno 2] No such file or directory: 'mini-dataset.dedup.jsonl'`
- El modo de falla anunciado por el documento es el real. **Veredicto: verificado.**

## Cifras y afirmaciones ancladas

- El documento no contiene bloques «protocolo» (M3): sus laboratorios son deterministas y no miden
  rendimiento; nada que verificar por esa vía.
- Afirmaciones ancladas a doc oficial con comando asociado: ninguna adicional a los laboratorios
  (las reglas JSONL, la carga por `datasets`, las cifras de The Pile/Alpaca/Longpre son citas
  bibliográficas sin comando; quedan bajo el régimen de citado de Convenciones §2, fuera de este
  mandato).
- Determinismo comprobado: los tres scripts no muestrean ni dependen del banco; la afirmación de
  §3 («la salida del lector debe coincidir exactamente») se sostiene.

## Resumen

| Clase | n |
| --- | --- |
| Verificados | 5 (4 corridas prescriptas + 1 adversarial del modo de falla) |
| Corregidos | 0 |
| Ilustrativos | 0 |
| BLOQUEO | 0 |

El documento no requirió ediciones: toda salida pegada coincide bit a bit con la corrida real.
Sin dudas para el PO.

> Nota: `evidencia/local/` no está versionada (gitignored); sus logs no se publican y se identifican por su huella SHA-256.
