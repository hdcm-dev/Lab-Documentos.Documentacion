# Verificación independiente final de la etapa 4 (2): forma y privacidad

Fecha: 2026-11-02. Lente adversarial de forma y privacidad. No se corrigió nada. Corrida reanudada después del corte de ssh: el estado en disco coincide con lo que E10 (F6) y E11 dejaron registrado y no hay ediciones a medias. La guía no tiene cambios sin commitear.

**Guía:** sha256 `5ebbfdbb2497b9e2e197851f453cb335311ca1d6a301548249e1a74db87b5e12` (4.434 líneas). Coincide con E10 F6 y con E11. **Conocimiento:** `16ab8280…b126` (599 líneas).

## Compuertas (rc)

| Control | rc | Resultado |
|---|---|---|
| `contar.sh` | 0 | 59.373/60.000 |
| `verificar-markdown.py guia` / `arbol` / `ejemplos` | 0/0/0 | 0 rotos, 4 rutas exceptuadas |
| Anclas internas del libro (script propio) | — | 1.610 remisiones `](#…)`, 517 ids, 0 sin destino, 0 ids duplicados |
| `compuerta-rpriv.sh .` con `COMPUERTAS_DIR` (clases privadas) | 0 | 0 hallazgos (patrones 3, lista 20, históricos 1) |
| `compuerta-rpriv.sh` sin rutas | 2 | uso: cierra sin rutas, como corresponde |
| `mermaid.sh` libro / Conocimiento | 0/0 | 25 y 2 bloques ok (27 en total) |
| docs-guard `mermaid-arroba` / `fuera` | 0/0 | verde, 27 bloques; verde |

## Hallazgos

1. **Ruta a la bitácora no publicable** (pendiente de E10 F1 → E11, sigue abierto): `Examples/15-Pruebas-Y-Evaluacion/entradas/salidas-07.v1.json:13` y `Examples/15-Pruebas-Y-Evaluacion/Application/CongeladorDeSalidas.cs:69` tienen el campo `registro` con la ruta `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/…/OUTPUTs/Bitacoras/Evidencia/R-LLM/07-RAG-Con-Citas.modelo.jsonl`. Apuntan a la bitácora excluida de git y al repo privado de documentación. No es un enlace markdown y por eso `fuera` y `verificar-markdown` no lo ven. E11 no lo registra como resuelto.
2. **U-7.1 contra R-PRIV**: un `grep -rniIF -f r-priv.lista` sobre la guía da **1** coincidencia, en `salidas-07.v1.json:10`. Es el `turno_id` histórico, que contiene el nombre de un servicio del laboratorio (10 caracteres; no se reproduce acá). R-PRIV da 0 porque ese valor está en `r-priv.historicos`. E11 informa «U-7.1: 0» con una lista negra de 27 líneas que no está en `[ruta-trabajo]/g16-p02/e11/compuertas/`, así que con lo que hay en disco no se pudo reproducir ese 0. Hay que decidir si el valor histórico se admite también en U-7.1 o si se enmascara.
3. **Deltas residuales**: no hay ninguno en el cuerpo. Las expresiones del tipo «ya no»/«anterior» que aparecen (l.147, 1501, 2211, 2476, 2635, 4344, 4421) describen el dominio o remiten a la procedencia del Anexo H, que es el mecanismo declarado. No narran cambios de la edición. En l.1501, l.2211 y l.2635, «NO EJECUTADO en esta versión» es un rótulo de estado, no un delta.
4. **Terminología del acta**: «App Shell» no aparece en ninguna parte (0). La única mención del contenedor nativo está en el Conocimiento (l.346) y es conforme: «contenedor nativo (*native shell*; en la jerga del proyecto, «cascarón»)», junto con «app híbrida con contenido OTA» y «paquete de actualización OTA firmado (*update bundle*)» en l.347. El libro no menciona el contenedor nativo. Ningún texto cita el puente con versión, así que no aplica 1.3.0.
5. **R-PRIV manual**: no hay rutas de home, IPs de tailnet ni privadas, series, hosts del laboratorio, nombres de usuario ni el servicio privado de notificaciones. Los endpoints que aparecen son `localhost:11434`, `*.invalid` y `ollama-embed` (nombre del compose), todos genéricos. «Estación N» es un rótulo neutro.
6. **Enlaces del libro a la bitácora**: ninguno. En `.md` sólo se encontraron las rutas del hallazgo 1, en datos y en código.

## Pendientes

- H1 (las dos rutas de 15): conviene una ruta relativa al `RLLM_DIR` o un marcador neutro. Hay que corregirlo antes de publicar.
- H2 (U-7.1 contra el histórico): decisión de criterio, de la mesa o del PO.
- Siguen abiertos los de coordinación que trae E11: `dominios.txt` (H-2, AI-4 87/91), `prefijos.txt` (12 errores de esquema) y los 256 hallazgos R-PRIV de la bitácora, que esperan decisión del PO.
