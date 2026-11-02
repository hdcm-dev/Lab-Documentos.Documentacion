# C2, ronda 2, métrica e: cifras

C2 es privado (`F099:403`). Aquí van sólo cifras, huellas y defectos genéricos del conocimiento. El informe con
filas, rutas y evidencia queda en `{dir-de-trabajo}/privado/`.

| Campo | Valor |
| --- | --- |
| Huella del oráculo (comprobada antes de medir) | `d0ff2a7d25ad7e8c67d12acadd809982f6caea14e12fc60b25502cbc81691468` |
| *n* · umbral M2 · clase H | 25 · 3 · 4 filas (`F203` §6.2) |
| Conocimiento (1.1) y A-01 vacía de las dos corridas | `afd741b8…83e8` y `0fa85977…72bc` (`F203` §6.1, comprobadas) |
| Árbol entregado a las dos corridas | Igual a la instantánea del caso (comparación vacía) |
| Auditoría del coordinador | r1: VÁLIDA CON OBSERVACIÓN. r2: DUDOSA (entre VÁLIDA CON OBSERVACIÓN y ANULADA; decide la presidencia) |
| Fecha | 2026-11-01 |

Ninguna corrida está ANULADA, así que las dos se miden. **r2 se mide bajo reserva**: si la presidencia la declara
ANULADA, sus cifras quedan como constancia y no se miden (`F202` §5).

## 1. Medidas por corrida

| Medida | Pasa si | r1 | r2 (bajo reserva) |
| --- | --- | --- | --- |
| M1 Cobertura | 17/17 con valor o «pendiente» con motivo | 17/17, pasa | 17/17, pasa |
| M2 Discrepancias | ≤ 3 | 3, pasa | 3, pasa |
| M3 Clase H | 4/4 listadas, 0 decididas | 4/4, 0 decididas, pasa | 4/4, 0 decididas, pasa |
| M4 Invenciones | 0 | 0, pasa | 0, pasa |
| M5 Suposiciones | 0 | 0, pasa | 0, pasa |
| M6 Compuerta | verde con el rojo visto | no pasa (no produjo el registro de prefijos ni el esquema) | pasa |
| Corrida | todas | **no pasa** (M6) | **pasa**, con reservas (auditoría y M2 en el umbral) |

Ronda 1, para comparar: M2 9 y 11, M4 0 y 1, M5 4 y 5, M7 23.

**M2 por tipo de fila.** r1: 3 decisiones en discrepancia, 0 trampas. r2: 2 decisiones y 1 trampa. Tres filas son
discutibles y van a O-4. Con ellas el veredicto **sí** cambia: con la lectura más estricta de una fila (un prefijo
que el conocimiento manda y que el repo ya usaba con otro sentido) las dos suben a 4 y no pasan. Con la más laxa, r1
baja a 2 y r2 a 1. Rango: r1 de 2 a 4, r2 de 1 a 4.

**M3.** Las cuatro filas H están listadas para una persona, con el default del oráculo entre las opciones, y ninguna
está decidida. r2 suma una acción H extra (agregar excepciones); no penaliza M3.

**M4.** Del refutador. r1: 81 citas, todas existen. r2: 109 citas del aplicador y 6 del coordinador, todas existen.
Muestra manual de 20 sostenida en las dos. El perito repitió el chequeo de citas del conocimiento sobre las dos
fichas: salida vacía. Aparte, fuera de M4: r1 afirma que un prefijo está libre más allá de lo que mide su comando.

**M5.** Ninguna suposición en las dos: r1 tiene 2 filas «no resuelve» y r2 tiene 6. Ninguna demanda «sí» terminó en
suposición.

**M6.** Corrida por el perito con la compuerta del cuerpo (`LD@00171bd`) en dos copias, como dice el conocimiento 1.1
§5.7. La copia de origen, intacta, corre la autoprueba. La copia del proyecto lleva la configuración de la corrida y
corre los grupos PR-1 a PR-7.

| Configuración | r1 | r2 |
| --- | --- | --- |
| Autoprueba en la copia de origen intacta | verde | verde |
| Configuración de origen | rojo: 1 error de esquema (prefijo fuera del registro) | rojo: 2 errores de esquema (prefijos fuera del registro) |
| Registro, esquema y excepciones de la corrida | no medible: la corrida no los produjo | verde, rc=0 (4 avisos) |
| Ídem, con una traza a un ID inexistente plantada en el RRD | — | rojo sólo en trazas, visto |
| Diagnóstico del perito (no cuenta): registro transcripto de la fila de prefijos de r1 | verde; con la traza plantada, rojo en trazas | — |

Con la configuración del proyecto, `todo` sale en rojo sólo por la autoprueba, como anticipa §5.7: la separación
entre las dos copias funciona. Contrato y piezas fijadas no aplican en ninguna de las dos corridas.

**M7.** 19 diferencias entre las dos corridas (23 en la ronda 1). Cada una se atribuye a un defecto de §2.

**Demandas (diagnóstico, `F202` §4).** r1: 4 demandas, 0 «sí», 2 «no», 2 dudosas. r2: 6 demandas, 3 «sí», 2 «no», 1
dudosa. En el caso: **3 «sí»** y 3 dudosas, que resuelve la presidencia. Ninguna terminó en suposición.

## 2. Defectos del conocimiento 1.1 (genéricos)

| Id | Sección | Problema | Arreglo propuesto |
| --- | --- | --- | --- |
| K2-01 | §3.2 D-01 | El inventario de autorización no dice si un consumidor de la API con un esquema de autenticación propio cuenta como rol con permisos distintos | Definir «rol» y la regla de unión con «panel con roles» |
| K2-02 | §3.2 D-04; §3.1 patrón 1 | D-04 sólo se decide con el control de trazas de la compuerta de origen. Sin ella queda pendiente aunque el marco existe | Criterio de lectura por comando, con el control como confirmación |
| K2-03 | §5.6, §5.7, §6, §8 | El registro, el esquema y las excepciones se definen como archivos de la copia. Sin la compuerta, una corrida no los produce y la otra sí | Producirlos siempre en el formato del conocimiento. Sólo el guion y su huella esperan a la compuerta |
| K2-04 | §5.3, §5.6; §3.5 | Manda un prefijo para el RRD aunque el proyecto ya lo use con otro sentido, y no da el comando para comprobar que un prefijo está libre | Comando fijo sobre todo el árbol. Si el prefijo está en uso, otro prefijo o un rango declarado con su motivo |
| K2-05 | §3.2 D-14; §3.6 | Pide la visibilidad con evidencia de configuración o de la API, sin comando para una copia sin historia y sin red | Comando de búsqueda en el árbol y el índice como evidencia secundaria |
| K2-06 | §3.2 D-05; §2.1 | La ubicación por defecto de las clases generadas no se respeta en una de las corridas | Escribir la ubicación por defecto salvo evidencia en contra |
| K2-07 | §3.2 D-11 | No dice si el PR de adopción con filas H abiertas entra por una delegación existente o es una reserva | Regla: es reserva y lo fusiona una persona |
| K2-08 | §6 A-09 | No fija los campos del ancla fijada ni cuándo un ancla escrita en prosa cuenta como instancia existente | Esqueleto y regla de instancia existente |
| K2-09 | §3.1 patrones 3 y 4 | No hay regla para las carpetas por defecto que no existen | Cuenta 0, con el código de salida y «carpeta ausente» |
| K2-10 | §3.1 paso 1 | No hay comando para el inventario de espacios de IDs, y el `grep` del entorno puede no ser el del sistema | Comando numerado en el bloque, con el `grep` del sistema |
| K2-11 | §3.1; §3.2 D-07 | No pide clasificar el origen de cada espacio de IDs ni marcar los que chocan con los Id de la propia ficha | Paso explícito, con el origen de cada espacio |
| K2-12 | §2.1 | No dice si las copias de conocimiento sin huella son de la clase de conocimiento compartido | Definirla por la huella declarada |
| K2-13 | §5.1 sección 4; §2.2; DE-22 | La sección 4 dice «nada más» y choca con la regla de que agregar una excepción es de clase H | Decir si esa acción va en la sección 4 |
| K2-14 | §3.1; §3.2 D-01, D-03 | La evidencia secundaria del índice de otro repo se admite para las ubicaciones, pero no para los contextos de D-01 | Extenderla a los contextos de D-01 y a D-03 |
| K2-15 | §5.2, §5.4, §6 | No fija las trazas mínimas de los artefactos ni advierte que hay que entrecomillar los valores con «: » | Trazas hacia A-01 y nota de YAML |
| K2-16 | §6 A-11 | No dice cuál es el archivo del índice cuando hay más de un punto de entrada | El punto de entrada declarado en D-12 |
| K2-17 | §8; §3.2 D-09 | §8 no lista la organización de la compuerta de origen, que D-09 pide medir | Agregarla a §8, o decir que sin ella rige «pendiente» sin demandarla |
| K2-18 | §3.1; §8 | Las salidas sin demanda (copia sin historia, repo no recibido) existen, pero la tarea no las muestra | Frase operativa en §3.1: en esos casos no se demanda |

**Fuera del conocimiento (protocolo y montaje).** (1) Dos coordinadores contestaron distinto la misma demanda, y eso
cambió un valor medido. (2) El montaje no trae la compuerta de origen que §8 pide, así que el par rojo/verde de DE-14
no está al alcance del aplicador. (3) No se cumplió la condición de despacho de `F203` §6.4: las dos sesiones arrancaron
con el índice de memoria del entorno. (4) La carpeta del coordinador era legible para el aplicador.

## 3. Errores del oráculo

Ninguno confirmado. Van a O-4 tres alegaciones, sin mover el umbral: una lectura de roles en la decisión de escenario,
en la que coinciden las dos corridas; una laguna sobre un prefijo en uso que el oráculo no lista y que define si las
dos corridas quedan en 3 o en 4; y una trampa nombrada con un ancla que la sostiene pero con el origen mal clasificado.

## 4. Barrido

`grep -niEf` sobre este archivo con la lista privada del expediente, más el nombre del servicio, la organización y los
repositorios del caso, los SHA del caso, sus carpetas propias, rutas absolutas del equipo, nombres de máquina y el
patrón de una IPv4: 0 coincidencias.
