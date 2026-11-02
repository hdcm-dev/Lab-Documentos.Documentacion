# E10 · 07 — Cierre de las correcciones de la etapa 4 (2026-11-02)

> Insumo: `../Ejecucion/Verificacion-Etapa-4-1.md`, `-2.md`, `-3.md` y `../E11/Compuertas.md`. Un solo agente editando. Sin commit, push ni PR. No se tocaron archivos comunes (`dominios.txt`, `prefijos.txt`, `CHANGELOG`, `[gestor-de-turnos]`). `{guía}` = carpeta de la guía 16 en LD.

## 1. Cambios

| # | Hallazgo | Archivo | Cambio |
|---|---|---|---|
| 1 | H-1 (4-1) | `{guía}/Examples/08-…/README.md` l. 41 | «Contra el modelo no se corrió todavía…» → «Contra el modelo se corrió con su criterio fijado antes (…): el resultado está en «Límites declarados», corrida vigente.» Coincide con l. 79 (10/10) y libro l. 1480. |
| 2 | H-3 (4-1), U-7.1 (4-2), pendiente 4 (E11) | `{guía}/Examples/15-…/entradas/salidas-07.v2.json` (nuevo) | Mismas 16 salidas y mismo rótulo que la `v1` (comparación JSON: iguales). Cambian tres campos de `procedencia`: `version` `v2`; `registro` = `07-RAG-Con-Citas.modelo.jsonl (registro de trabajo no publicado; ver Anexo H)`; `turno_id` = `20261027T134714-<recurso>-3629776-15251`. sha256 `5a8951ec…e32a`. |
| 2 | ídem | `entradas/salidas-07.v1.json` | **Retirado** del ejemplo. Copia íntegra en `E10/Evidencia-07/salidas-07.v1.json` (bitácora, fuera de git). |
| 2 | ídem | `ejemplo.json` | entrada `salidas-07.v2.json` con su sha256. |
| 2 | ídem | `Application/CongeladorDeSalidas.cs` | sin ruta absoluta: `Registro = $"{Path.GetFileName(rutaDelRegistro)} (registro de trabajo no publicado; ver Anexo H)"`; `Version = "v2"`; `TurnoId = Enmascarar(…)` (regex `fecha-recurso-pid-n` → `fecha-<recurso>-pid-n`). |
| 2 | ídem | `Application/CasosDeEvaluacion.cs`, `Program.cs` | `Archivo` y comentario apuntan a `v2`. |
| 2 | ídem | `Examples/15-…/README.md` | tabla de entradas y `--congelar-salidas-07` en `v2`; el párrafo «es histórico y no se toca» se reemplaza por «la `v2` reemplaza a la `v1`» con qué cambió, por qué y que las cifras de la `v1` siguen valiendo. |
| 2 | ídem | libro, Anexo H, tabla H.1 | fila «Corridas de 01 a 04, 08, 09, 11 a 13 y 15 a 17 (y estímulo de 15) del servidor retirado»; sin delta («antes…»). Para respetar el tope de Anexos (13.000) se recortó «un» en la definición. |
| 3 | H-2 (4-1) | libro l. 3091 (§16, intro) | «La especificación y el banco del ensayo están en el expediente 0002 de Lab-Geometria y en su carpeta «ai-layer», en la rama de trabajo `g16/ai-layer-v1`, que no se fusionó a `main`; los enlaces… commit `5f07b12`.» |
| 3 | ídem | libro l. 3157 | «se fijó el criterio y se publicó el banco» → «se fijaron el criterio y el banco, versionados en esa rama de trabajo». Sin URL nueva. |
| 3 | ídem | `{guía}/tools/compuerta-referencias.excepciones` | `g16/ai-layer-v1` exceptuada (nombre de rama de otro repo, no ruta). Archivo propio de la guía. |
| 4 | 4-3 §4.5 | `../Ejecucion/E10.md` | sección «Fase 4 (ortotipografía)» en lugar del renglón suelto, desde `04-F4-Ortotipografia.md`. |

### Criterio de la `v2` y del retiro de la `v1`

- El README de 15 fija el mecanismo: cambiar el archivo exige versión nueva. Se creó `v2`; no se editó la `v1` en el lugar.
- La `v1` se retira porque conservarla deja en el árbol publicable el nombre de un servicio del laboratorio (U-7.1) y una ruta a la bitácora, que es lo que se corrige. No se pierde nada: el estímulo es idéntico y la `v1` queda en la bitácora.
- Las cifras medidas con la `v1` siguen valiendo: el oráculo `acuerdo-del-juez` lee sólo `salidas` y el registro, que no cambian. Los registros históricos citan el sha256 de la `v1`; son de la bitácora y no se reescriben.
- `recalcular-oraculos.sh` no hacía falta para las cifras (el estímulo no cambió). Se corrió igual sobre el registro `--fake` nuevo de 15: 26/26 coinciden, rc 0.

### Nota para el PO (banco de Geometría)

El texto de §16 queda verdadero hoy: la rama `g16/ai-layer-v1` de Lab-Geometria existe sólo en local, sin push. **Si el PO aprueba publicar la rama, se ajustan l. 3091 y l. 3157 con el enlace** al expediente 0002 y a `ai-layer/ensayos/` en el commit publicado (y se quita la excepción de `compuerta-referencias.excepciones` si pasa a ser enlace).

## 2. Compuertas (después)

| Compuerta | rc | Resultado |
|---|---|---|
| `tools/verificar.sh build` (turno `build` por `[gestor-de-turnos]`, concedido y liberado; sin modelo) | 0 | 200 s; build -warnaserror; 18 proyectos de prueba en verde, 15: 37/37; consolas `--fake --verificar` en verde (15 lee `salidas-07.v2.json`, sha256 `5a8951ecbb34`); R-PRIV del build 0 |
| `tools/recalcular-oraculos.sh` sobre el registro `--fake` de 15 | 0 | 26/26 |
| `tools/contar.sh` | 0 | 59.385 / 60.000; Anexos 13.000 / 13.000 |
| `verificar-markdown.py guia` | 0 | 82 rutas, 4 exceptuadas |
| `verificar-markdown.py arbol` Examples · Conocimientos · Demos | 0 · 0 · 0 | — |
| `verificar-markdown.py ejemplos` | 0 | 18 archivos |
| `compuerta-referencias.sh` | 0 | 0 rotas en 21 archivos (primera pasada 1: `g16/ai-layer-v1`, exceptuada) |
| `compuerta-intervalos.py` libro + R-LLM | 0 | 28/28; 21/21 |
| `compuerta-rpriv.sh` con las listas privadas de E11 | 0 | 0 hallazgos |
| Filtro U-7.1 (`grep -rniIF -f r-priv.lista`, incluidos `bin/`/`obj/`) | — | **0** (antes 1, el `turno_id` de la `v1`) |
| `tools/medios/mermaid.sh` libro | 0 | — |

Turno de modelo: no se usó (no hizo falta). Sin emuladores ni KVM.

## 3. Huellas

- Libro: 4.434 líneas, sha256 `ffdfcf46705a6886789dd69c04ec490b95f50868075112e511e4f43dc1d3b046` (antes `5ebbfdbb…5e12`).
- README 08 `04d5ea13…a090`; README 15 `55f68bcf…5e8d`; `ejemplo.json` 15 `15f72e32…c2`; `CongeladorDeSalidas.cs` `ff4d03a5…ca66`; `salidas-07.v2.json` `5a8951ec…e32a`.

## 4. Pendientes

1. Publicación de la rama de Lab-Geometria (PO), ver nota.
2. Siguen los heredados: H-6 (PO), `dominios.txt`/`prefijos.txt` (coordinación), 256 hallazgos R-PRIV de la bitácora (PO).
3. `r-priv.historicos` de E11 conserva una entrada que ya no tiene coincidencias en la guía; está fuera del repo y no se tocó.

## 5. Mensajes ajenos

Ninguno.

## 5. Verificación independiente (2026-11-02)

Verificador adversarial; informe en `../Ejecucion/Verificacion-Cierre-Etapa-4.md`. Resultado: las cuatro correcciones se confirman y todas las compuertas dan rc 0 en una corrida nueva: `verificar.sh build` con turno propio concedido y liberado, 15 37/37, oráculos 26/26 y R-PRIV 0 también sin `historicos`. Las huellas coinciden. Hay tres observaciones menores que ya estaban antes de las correcciones: la `nota` de `calibracion.v1.json` cita la `v1` retirada; cuatro menciones a «la bitácora» sin ruta en `_Comun`, 06 y el Conocimiento; y una entrada que sobra en `r-priv.historicos`. No se arregló nada.
