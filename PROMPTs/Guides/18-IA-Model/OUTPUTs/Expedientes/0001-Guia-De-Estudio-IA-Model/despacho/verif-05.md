# Constancia de verificación técnica — Documento 05 (Preentrenamiento y leyes de escala)

- **Documento**: `Guides/IA/IA-Model/05-Preentrenamiento-Y-Leyes-De-Escala.md` (worktree guía)
- **Verificador**: técnico adversarial, fase de elaboración, expediente 0001
- **Fecha**: 2026-11-07
- **Entorno**: python 3.11.2, CPU x86-64 (CTX-01), sin bibliotecas externas, sin venv (ningún
  paquete requerido). El banco de inferencia no interviene: ambos laboratorios son python puro
  local, tal como declara el propio documento (§3).

## Ejemplos operables encontrados: 2

### 1. IAM-05-L1 — `lab_preentrenamiento.py` (§3.1) — VERIFICADO

- **Comando**: `python3 lab_preentrenamiento.py` (script extraído literal del documento)
- **Resultado**: la salida real es **byte a byte idéntica** al bloque «Salida esperada» del
  documento (comparación programática `==` entre el bloque ```text y stdout: `True`). Incluye
  las muestras de texto: la semilla 42 las fija.
- **Cifras del protocolo M3 contrastadas**: pérdida 3,0445 → 1,5357 ✔; perplejidad 21,0 → 4,64 ✔
  (perplejidad inicial = V = 21 ✔); checkpoint 8 KiB ✔; corpus 1.544 tokens / 1.543 transiciones
  por época ✔ (coincide con el «1.543 veces» de §1.2); reanudación con pérdida idéntica ✔.
- **Corrección aplicada al documento**: duración del protocolo 1,4 s → 1,1 s (`time`, real
  0m1,076s en la corrida de verificación, que es la que funda el log archivado).
- **Log**: `evidencia/local/verif-05-lab1-preentrenamiento.log`
  SHA-256 `44e5124c41ef50c68a06b2512cb36bb3ae424aeeb56997e8b5c447ddadecc172`
- **Extracto mínimo**:
  ```text
  antes de entrenar  | loss 3.0445 | perplexity 21.0
  epoca 30 | loss 1.5357 | perplexity 4.64
  reanudado de la epoca 30 | loss 1.5357 | perplexity 4.64  (identica: la foto es completa)
  real	0m1,076s
  ```
- **Veredicto**: verificado (con corrección menor de una cifra de protocolo).

### 2. IAM-05-L2 — `lab_economia.py` (§3.2) — VERIFICADO

- **Comando**: `python3 lab_economia.py` (script extraído literal del documento)
- **Resultado**: salida real **byte a byte idéntica** al bloque «Salida esperada» (`True`).
- **Aritmética contrastada a mano**: `6·441·46290 = 1,22e8 ≈ 1.2e+08` ✔; fila 7B:
  `D = 1,4e11`, `C = 5,88e21 ≈ 5.9 ZFLOPs`, horas `= C/4e14/3600 = 4.083` ✔; crecimiento
  cuadrático de horas con N ✔.
- **Log**: `evidencia/local/verif-05-lab2-economia.log`
  SHA-256 `020bdbffdabafbc59341652dab80c607e479e9ed2dc3dfaab83a39f22f12e007`
- **Extracto mínimo**:
  ```text
           7B | 140,000,000,000 |   5.9 ZFLOPs |            4,083 |        8,167
  demo juguete: C = 6*441*46290 = 1.2e+08 FLOPs (una laptop hace eso en una fraccion de segundo)
  ```
- **Veredicto**: verificado.

## Afirmaciones ancladas con comando asociado

Ninguna: el documento no usa el banco (sin flags, endpoints ni formatos de API que probar por
comando). Las cifras bibliográficas (GPT-3 175B/300B tokens; Chinchilla 70B/1,4T, regla
D≈20·N; C≈6·N·D) coinciden con sus fuentes citadas y no tienen comando asociado — quedan como
citas, no como corridas.

## Resumen

- Verificados: 2 · Corregidos: 1 cifra de protocolo (duración L1) · Ilustrativos: 0 · BLOQUEO: 0
- Dudas para el PO: sin dudas.

> Nota: `evidencia/local/` no está versionada (gitignored); sus logs no se publican y se identifican por su huella SHA-256.
