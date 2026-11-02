# 06 · Verificación independiente de la relectura

Fecha: 2026-10-30. Verificador independiente. No se confió en los informes: cada parche se cotejó contra el texto actual de la guía y del repo, y las compuertas se corrieron de nuevo.
Guía (`$DOC`) verificada: sha256 `c8defd8324497c4279a3dfd57ce5d2757326ad966813a9f9797d0196d9b7ce3d`. Es el valor de cierre del tramo P-31…P-34 de `05-Aplicacion-Parches.md`, y quedó igual al terminar: esta verificación **no editó** la guía ni el repo.
Copias: `{dir-de-trabajo}/verif-06/texto` para las compuertas de texto y `{dir-de-trabajo}/verif-06/guia` para compilar, con el turno `build` del gestor (concedido y liberado), el SDK 10.0 y el volumen de NuGet del laboratorio, sin servidor de modelos.

## 1. Parches (34 de 34 muestreados: son menos de 40)

| Parche | ¿Quedó como dice 05? | Comprobación |
|---|---|---|
| P-01 | sí, con el desvío declarado | 0 apariciones de «línea archivada», «línea paralela» y «línea de construcción», y ningún rótulo «otra composición: línea archivada» |
| P-02 | sí | La forma está fijada en §0.4. Quedan 0 «, servidor retirado)» |
| P-03 | sí, con deuda declarada | El Anexo C no tiene «Definición breve». `contar.sh` da Anexo C 452 y REF 180/180 |
| P-04 | sí | Las anclas `anexo-a-14` y `anexo-a-props` siguen las dos. El índice apunta a `#anexo-a-14`. La frase «A.n es la plantilla de §n» está |
| P-05 | sí | La frase de réplica exacta está una vez |
| P-06 | sí, con el desvío declarado | Quedan 0 «Presentación» en la guía. `Presentation_EntraAInfrastructureAI_SoloPorChat` está en `ArquitecturaTests.cs` de la demo y en la guía |
| P-07 | sí | «Otras tres reglas» en §4.3 y «Cuatro reglas cubren Domain, Application, el SDK y las herramientas» en §13.12 |
| P-08 | sí | La regla `ComunAIyPruebas_SoloEnInfrastructureAIyProgram` y el caso `Comun_FueraDeInfrastructureAI_DaRojo` están en el código. `demo.sh pruebas` da 81/81. La mutación roja no se repitió: rige la de 05 |
| P-09 | sí | «Salida vigente. Observado en el laboratorio…» con el rótulo completo |
| P-10 | sí | «un estímulo propio, con su propia composición» |
| P-11 | sí | «observado: 2.050 tokens, mecanismo no explicado» |
| P-12 | sí | §5.7 define «frio» (reutilizado < mitad, «no explicado»). §6.3: «la corrida real de §5.7 no reprodujo ese estado» |
| P-13 | sí, con el desvío declarado | La fila de A.12 está («modo de demostración, no patrón para CTX-PROD»). §5.5 no se tocó |
| P-14 | sí, con el desvío declarado | «digest no registrado» aparece 2 veces. §11.7 tiene el rótulo de R-16, sin IC |
| P-15 | sí | «17 entradas × 2 corridas = 34 consultas» |
| P-16 | sí | `ClienteMcp.cs` (líneas 14-17) tiene el texto aprobado |
| P-17 | sí | Primera línea del bloque `--fake` de §10 |
| P-18 | sí | Separación Historia/vigente («no medido (41/52 < 45/52», 3 apariciones). La fila 15 de E.1 está rotulada |
| P-19 | sí | §10.6 tiene el texto aprobado y no aparece 0,788. `ejemplo.json` de 15 es JSON válido y trae 41/52 |
| P-20 | sí | «juez y generador son el mismo modelo». En el README de 15, «distinto del generador» queda sólo después de «Historia (hasta el 2026-10-28)» |
| P-21 | sí | «Acuerdo no medido: 0 de 10 … (recuento, no tasa)». Quedan 0 «IC95 [0; 0,308]» |
| P-22 | sí | §11.2 muestra «4, 1, 3, 2, 2 y 4 de 10 … no se informa IC» |
| P-23 | sí, con el desvío de ubicación declarado | Está en el «Lado servidor» de §11.5 |
| P-24 | sí | La frase aparece 2 veces (§11.6 y §12.6) |
| P-25 | sí | «El id lo elige el cliente…» en la pregunta de §11 |
| P-26 | sí | `${SDK_IMAGEN:-…sdk:10.0}` en la guía (E.5 y §12.6), en `Examples/README.md` y en `compose.yaml`. La demo compila y prueba con el defecto |
| P-27 | sí | «no observada: se emite sin exportador» |
| P-28 | sí | Confianza «Media» y «La demo aplica sólo la regla 2» |
| P-29 | sí | El nodo «biblioteca común (_Comun)» y la flecha «DependencyInjection.cs → FabricaDeClientes» están |
| P-30 | **en parte (desvío)** | `verificar.sh:78` tiene `DIGEST_CHAT_PROPIO="d8b0f5e9760c"` y el defecto es `qwen3.5:4b` en las líneas 460, 588, 661 y 672. Las filas 02, 05 y 15 de E.1 están rotuladas. **Falta** la corrida de `verificar.sh` contra la estación vigente que pide el parche |
| P-31 | sí en el código y en la guía; la corrida falta (es la misma de P-30) | `ConfiguracionDelModelo.cs:36,72` y `CapaDeOpcionesTests.cs` tienen `qwen3.5:4b`. A.12 está rotulada. `Comun.Pruebas` da 73/73 |
| P-32 | sí | Ancla `anexo-f-4` (5 referencias, también en el índice). «prompts largos» aparece 0 veces |
| P-33 | sí | Tiene el texto aprobado. «tope de espera por llamada» y «no se escribe en el repositorio» aparecen 0 veces |
| P-34 | sí | E.6 tiene «Inventario y limpieza» con `docker ps -a` y `docker volume ls` filtrados por `label=${ETIQUETA:-proyecto=guia-ia}`, y el prune |

En total, 33 parches quedaron como dice 05 (los desvíos de P-01, P-06, P-13, P-14 y P-23 ya estaban declarados allí). P-30/P-31 tienen un desvío abierto: falta la corrida con modelo.

## 2. Compuertas de B-14 paso 3 sobre el estado final

| Compuerta | Ahora | Base (`compuertas-base/`) | ¿Regresión? |
|---|---|---|---|
| AC-5 `diff-dominio.sh` | rc 0, idénticos | igual | no |
| AC-6 | build: sólo la excepción `Azure.AI.OpenAI 2.9.0-beta.1`. Demo: sin previews | igual | no |
| `verificar.sh build` | rc 0. Las 18 suites dan 561/561 (`Comun.Pruebas` 73). R-PRIV del build: 0 | 561/561 | no |
| `demo.sh pruebas` | rc 0, 81/81 | 79/79 (las 2 nuevas son de P-08) | no |
| AC-7 | árbol rc 0 (40/40 positivos). Registros del build rc 0 (19 revisados) | igual | no |
| AC-8 | rc 0 (2 exceptuadas, 5/5 positivos, lista 11/11) | igual | no |
| AC-9 bloques | 57 bloques, 0 diferencias | igual | no |
| AC-10 `diff-base.sh` | rc 0: 27 iguales, 17 distintos, 60 nuevos, 0 quitados. Todo cambio está en la tabla de delta | 59 nuevos (el 60 es `Mutantes/Comun.cs` de P-08, que está declarado) | no |
| `verificar-markdown.py guia` · `arbol` | rc 0: 229 encabezados, 283 anclas, 180/180 REF, 111 rutas (4 exceptuadas) · rc 0 | rc 0 | no |
| R-PRIV ampliado (árbol de la guía) | rc 1: 1 «turnos» y 1 «identificadores», los dos en `Examples/15-…/entradas/salidas-07.v1.json`, el valor histórico declarado | igual | no |
| `compuerta-rpriv.sh` | 0 hallazgos | igual | no |
| `contar.sh` (informativo) | total 57.753/44.330 (130 %) | 58.820 (133 %) | no (bajó) |
| **`compuerta-intervalos.py`** (registros `Bitacoras/Evidencia/R-LLM`) | **rc 1: 81 figuras reconocidas, 63 en el mapa, 39 de 40 filas** | rc 0: 67/67, 40/40 | **sí** |
| `compuerta-cabeceras.sh` | registros del build: rc 0, «0 en 4 cuerpos». Árbol: rc 2, «ningún cuerpo» (D-B03-2) | igual | no |
| `grep -c '⟦REC-02:'` | 0 | 0 | no |
| `find` de bin/, obj/ y *.db en la guía | vacío. Volúmenes temporales borrados | vacío | no |

## 3. Pendientes

1. **PV-01. Regresión de `compuerta-intervalos.py`.** Los parches de la relectura agregaron cifras sin fila en `tools/compuerta-intervalos.tsv`. Hay 18 figuras sin mapa:
   - L838: «80 de 81». P-08 la agregó; es un recuento de pruebas, no del modelo.
   - L1107: «2 de 2». La agregó P-09.
   - L1589: «4 de 4». La agregó P-14.
   - L2972: «0 de 10». La agregó P-21.
   - L2974, L3090, L3811 y L4072: 41/52, 45/52 y 0/52. Las agregaron P-18 y P-19, con R-15b.
   - L3178: «4 de 10». La agregó P-22.
   - L3764 y L4622: «0/6». Las agregó P-28.

   Además, la fila **I22** («Acuerdo con la anotación: 0/10», IC95 [0; 0,308]) ya no encuentra su ancla, porque P-21 la quitó a propósito.

   No lo arreglé porque no es mecánico. Cada fila nueva pide decidir la clase (medicion, medicion-parcial, criterio, calculo o estimulo) y el registro. El registro de R-15b vive en `{dir-de-trabajo}`, no en `Bitacoras/Evidencia/R-LLM`. Lo que hay que hacer:
   - quitar o reescribir I22;
   - sumar las filas con su clase. 45/52 es «criterio». 0/52 es Historia. «80 de 81» no es una tasa del modelo: va como «calculo» o se excluye de la compuerta;
   - para 41/52, copiar el `.jsonl` de R-15b a la evidencia de la bitácora si se quiere la clase «medicion».

   Después se vuelve a correr la compuerta hasta rc 0. Es la única compuerta que pasaba en la base y falla ahora.
2. **PV-02. Corrida con modelo de P-30/P-31.** Falta volver a correr `tools/verificar.sh` contra la estación vigente (`qwen3.5:4b`@`d8b0f5e9760c`, Ollama 0.40.11) con turno, y registrar el resultado R-LLM. Hasta entonces, el esperado nuevo del script está comprobado sólo en el build sin servidor.
3. **RL-21.** Sigue como MEJORAR_PLAN para la vuelta siguiente, como dice 04, sin parche.
4. El voto `02-Voto-coherencia-historica.md` sigue en 0 bytes (anotación de 04 §7). Hay que reescribirlo por agregado.

Sin commit, push, PR ni ramas. No llegaron mensajes ajenos a la carta.
