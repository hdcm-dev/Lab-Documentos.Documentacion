# E11 — Verificación independiente de la integración (A)

- **Fecha:** 2026-11-02. **Papel:** verificador adversarial; no arregla.
- **Veredicto:** **NO CIERRA.** La guía pasa todas las compuertas, pero hay dos defectos abiertos: la bitácora tiene una filtración nueva (a) y los PR de casos están abiertos, uno de ellos con la CI en rojo (c).

## (a) Bitácora enmascarada

Corrí `compuerta-rpriv.sh` sobre todo `OUTPUTs/`, que ahora tiene 2746 archivos (eran 2743 al enmascarar).

| Corrida | rc | Hallazgos |
|---|---|---|
| Listas privadas tal cual (`historicos=0`) | 1 | 44: `ip-privada` 43 · `identificadores` 1 |
| Copia `compuertas-con-versiones` (2 históricos) | 1 | 1: `identificadores` 1 |

- **`ip-privada` (43):** todos son números de versión de ensamblado, `10.11.0.0` y `10.0.0.0`, no direcciones. Es el falso positivo RPRI-19. Ya no son 41 sino 43 porque se sumaron archivos de E11 escritos después del enmascarado.
- **`identificadores` (1): FILTRACIÓN REAL.** Está en `Bitacoras/Prompt-02/E11/Ajustes-Finales.md`, l. 24. Ahí figura sin enmascarar el nombre del gestor de turnos, en la fila de `verificar.sh build`. El archivo se escribió a las 14:14, después del enmascarado (14:09), y repite el texto que en el resto de la bitácora quedó como `[gestor-de-turnos]`.
- **Filtro de términos privados**, sin distinguir mayúsculas: 1 archivo con coincidencia, el mismo.
- **Conservación de la idea:** muestreé 20 pasajes de 20 archivos (semilla 11) y los comparé con la copia original privada. En los 20, el número de líneas es igual y sólo cambió el identificador, que pasó a un rol (`[host-dev]`, `[host-ia]`, `[api-de-modelos]`, `[recurso-modelo]`, `[recurso-modelo-propio]`, `[gestor-de-turnos]`, `[ruta-trabajo]`). Las cifras, las fechas, los resultados y las referencias quedaron intactos. Hay una sola diferencia de forma: un `doc_id` pasó del nombre del equipo a `BIT-16-LINEA-PARALELA` y su identidad cambió, aunque el sentido se mantiene.
- **Observación menor:** `E11/Enmascarado-Mapa-sha256.tsv` publica el sha256 de los 132 originales sin enmascarar. Eso permite confirmar un original a quien lo adivine o lo tenga, pero no revela contenido. Lo dejo anotado.

## (b) Compuertas de la guía

Corrí `tools/verificar.sh build` con turno `build`, dueño `g16-e11-verif-a`, concedido y liberado. Usé registros, volúmenes y etiqueta propios.

- **rc 0**, 204 s, 18 «Passed!», 0 «Failed!».
- La R-PRIV interna dio 0 hallazgos (`historicos=0`).
- El log está en `[ruta-trabajo]/g16-p02/e11-verif-a/verificar.log`, con sha256 `8b7b1992881a5bdab17b00a1a35f7a10afe671653ea3c7fd0c3131ecc8af529d`.
- La guía declara `version: 0.12.0` y `status: en revisión`, lo que coincide con la decisión 3.

## (c) PR de casos

| PR | Estado | Cabeza | Checks | Diff |
|---|---|---|---|---|
| [Lab-Geometria #236](https://github.com/hdcm-dev/Lab-Geometria/pull/236) | abierto, sin fusionar, `clean` | b4832d4 | puertas, banco local y resumen en success; matriz omitida | 26 archivos. R-PRIV sobre las líneas agregadas: rc 0. El servicio privado no aparece y no hay tokens. |
| PR #423 del repo privado | abierto, sin fusionar, `unstable` | 121d3b9 | «Restore, build y pruebas»: **failure** | 7 archivos, sólo documentación. Hay 20 coincidencias de la lista, pero son los nombres del propio producto dentro de su propio repo privado. No hay URLs, IPs ni tokens. |

- **CI no está en verde en el repo privado.** Main (fa047ff) falla el mismo check, así que la falla viene de antes del PR.
- **La decisión 2 del PO (PR y fusión) no está cumplida:** ninguno de los dos PR está fusionado.

## Pendientes para el coordinador

1. Enmascarar `E11/Ajustes-Finales.md` l. 24 y volver a correr R-PRIV.
2. Decidir sobre los dos históricos de versión, o aceptar el rc 1 de RPRI-19.
3. Fusionar el #236.
4. Para el #423, aplicar la regla «PR de documentación: fusionar» o arreglar primero la CI de main.

Durante el turno no llegaron mensajes ajenos.
