---
doc_id: BIT-16-MESA-C3-OPERACION
doc_type: informe-de-especialista
title: Informe de Operación y entrega sobre el plan de integración v2
role: Operación y entrega (catálogo M§4.1.2)
objeto: ../../../04-Plan-De-Integracion.md (v2, ESTRUCTURA APROBADA v2)
modo: a ciegas respecto de los demás informes del ciclo 3 (se leyeron Ciclo-2/06, 07, 08 y 09 y el informe propio del ciclo 2 para no repetir)
fecha: 2026-10-26
---

# Informe de Operación y entrega · Ciclo 3 (último)

**Mandato.** DEP-14 y EMB-B/EMB-C según el estado real del gestor, presupuesto de turnos, inventario y limpieza, y las listas `$R_PRIV_LISTA` y `$RD_PO_LISTA`.

Las líneas citadas son las de `04-Plan-De-Integracion.md` v2 (1236 líneas al 2026-10-26). Lo que ya se corrigió en el ciclo 2 (OP-01…OP-07: arnés en el host, orden de pedido, medidor, `OLLAMA_SERVIDOR`, provisión del modelo, §E.6) no se repite. **Este informe no escribe nombres de host, direcciones ni usuarios**: cuando hace falta señalar uno, da el archivo y la línea.

## Estado real del gestor (medido a las 19:28 del 2026-10-26)

- `<gestor-de-turnos> estado [recurso-modelo-propio]` → «recurso desconocido '[recurso-modelo-propio]'», seguido de la lista de los siete recursos válidos (ninguno es [recurso-modelo-propio]). **DEP-14 no está resuelta.**
- `<gestor-de-turnos>` tiene fecha de modificación 08:12:26. El pedido PAR2-25 salió con `09-Respuestas-De-La-Presidencia.md`, que se escribió a las 19:26. Desde el pedido, el script no cambió.
- El registro append-only del gestor tiene 9 líneas, todas entre 07:45 y 08:12. No hay ningún alta de `[recurso-modelo-propio]`.
- `l. 23–24` (CUPO/TTL), `l. 39` (`TODOS`), `l. 98` (ttl ≤ 240), `l. 209` (`salud`, sin rama para el recurso): los cuatro puntos de la objeción de J5 a PAR2-25 siguen como estaban.
- La etiqueta `ollama/ollama:0.40.11` **existe** (Docker Hub, `tags/0.40.11`, amd64, 3.372.404.290 bytes) (E1). En el host de la corrida no está bajada: sólo están `latest` y `0.32.0-rc0`.

Conclusión operativa: **hoy rige EMB-C** (§E.5 TURNO-3, l. 752; §F.6, l. 900). Si el gestor cumple antes del cierre, la presidencia lo registra en `Ciclo-3/08-Cierre.md` (09 §3).

## Hallazgos

### OP3-01 · S1 · E1 · confianza 0,90 · Fuga R-PRIV nueva en `09-Respuestas-De-La-Presidencia.md`, escrita después del barrido que dio «0 reales»

- **Ubicación**: `Mesa/Ciclo-2/09-Respuestas-De-La-Presidencia.md`, l. 31 (§3, encargo del Ollama propio). Relación con `Mesa/Ciclo-2/07-Aplicacion-Y-Verificacion.md`, l. 82 (fila R-PRIV).
- **Afirmación**: la l. 31 nombra **dos máquinas del laboratorio por su nombre de host** y la red privada superpuesta por la que se las alcanza. R-PRIV prohíbe los dos: «ni hostnames de la LAN» (00-Contrato, l. 68), y una fuga R-PRIV es S1 (00-Contrato, l. 106). El barrido de R-PRIV del ciclo 2 (07, l. 82: «0 reales en `OUTPUTs/`») se cerró a las 19:21. El 09 se escribió a las 19:26. Ninguna compuerta corrió sobre él, y como `$R_PRIV_LISTA` no existe, el barrido de nombres de host «se hizo con los nombres que la secretaría conoce» (07, l. 82). No puede detectar por sí solo un archivo que se escribe después.
- **Ancla**: `grep -n` con la lista de nombres que se conocen al día de hoy sobre `OUTPUTs/` da 3 líneas en el 09 (l. 31) y ninguna en el resto de la bitácora del ciclo 2. `ls -l`: 07 a las 19:21 y 09 a las 19:26.
- **Impacto**: el 09 es «insumo vinculante del ciclo 3». Lo van a citar la consolidación, el cierre y quizá el plan v3. Si se copia, la fuga se replica, y al primer commit del repo público queda en la historia de git, donde borrarla ya no basta.
- **Dirección**: en la l. 31 del 09, poner roles en lugar de nombres («una segunda máquina del laboratorio, no la de la corrida, porque esta está al límite de RAM»; «alcanzable sólo por la red privada del laboratorio»). Agregar al cierre de cada ciclo una regla: **la fila R-PRIV se corre después del último archivo escrito del ciclo**, respuestas de la presidencia incluidas, y con `$R_PRIV_LISTA` (OP3-02). Mientras la lista no exista, la fila tiene que decir «no verificable para nombres de host», no «0 reales».

### OP3-02 · S2 · E1 · confianza 0,85 · Las compuertas AC-7 y AC-8 pasan en verde sin lista, y los patrones de AC-7 no ven la red a la que la presidencia mandó el Ollama propio

- **Ubicación**: §F.10 AC-7 (l. 936) y AC-8 (l. 937); los patrones «sin cambio» son los de la v1, l. 822.
- **Afirmación**: hay tres defectos de mecanismo, comprobados en el scratchpad. (1) **Con GNU grep, una lista vacía es una compuerta verde**: `grep -nFi -f <archivo vacío>` sale con rc = 1 («sin coincidencias»), que es lo mismo que «pasa». Una variable sin definir da rc = 2. Si el script no distingue los dos casos, también pasa. (2) **El `grep` del shell de los agentes no es GNU grep.** Es una función que llama a `ugrep` con `--ignore-files` (respeta `.gitignore`) y con `-I`. Con un archivo de patrones vacío, **marca todas las líneas** (rc = 0). La misma compuerta da verde en un script y rojo en una sesión de agente, y si se corre a mano saltea lo ignorado por git (`registros/` y `datos/` de `Demos/`, §F.9). (3) Los patrones de IP de AC-7 cubren 10/8, 172.16/12 y 192.168/16, pero **no 100.64/10**, el rango de la red privada superpuesta. El 09 §3 ubica el Ollama propio «accesible sólo por» esa red, así que `OLLAMA_EMBED_ENDPOINT` va a valer una dirección de ese rango. Además, `<gestor-de-turnos> salud` de los emuladores ya imprime una dirección de ese rango (l. 230), y PROTOCOLO.md pide escalar «con la salida de `<gestor-de-turnos> estado`». Esa salida puede terminar pegada en una bitácora.
- **Ancla**: prueba en el scratchpad. `/usr/bin/grep -nFi -f vacia a.txt` → rc = 1. Con el `grep` de la sesión → la línea marcada, rc = 0. `type grep` → «es una función … `ugrep … --ignore-files --hidden -I`». Una dirección de prueba del rango 100.64/10 contra los tres patrones de la v1 l. 822 → rc = 1 (no la marca).
- **Impacto**: AC-7 es la última barrera antes del commit en un repo público. Tal como está, puede dar cero sin haber mirado nada, o mirar con otro motor distinto del que la mesa cree. La fuga más probable de la construcción (el endpoint del Ollama propio en un mensaje de error, en una salida de `salud` o en un README) no la marca ningún patrón.
- **Dirección**: (a) Sumar a AC-7 el patrón genérico `\b100\.(6[4-9]|[7-9][0-9]|1[01][0-9]|12[0-7])\.[0-9]+\.[0-9]+\b`. Es un rango, no una dirección, y puede ir en el repo. (b) La compuerta corre en un script con `/usr/bin/grep` explícito, nunca con el `grep` de la sesión, y **falla cerrada**: aborta si la variable no está definida, si el archivo no existe o si tiene cero líneas útiles. (c) Las listas viven fuera del repo, junto al directorio de estado del laboratorio, con una línea de texto fijo por término (`grep -F -i -f`). (d) La autoprueba de R-PRIV **no puede** copiar el patrón de `rd-po-4.positivos`, porque un archivo de positivos en el repo sería la fuga misma. Va fuera del repo, al lado de la lista, y la compuerta exige que marque todas sus líneas (ver la posición sobre las listas).

### OP3-03 · S2 · E1 · confianza 0,85 · El encargo de la presidencia mueve EMB-B a otra máquina, y el plan sigue escrito para un Ollama propio local

- **Ubicación**: §E.1 arnés, fase 2 (l. 633); §E.6 filas «Contenedor `<ollama>`» y «Volumen `<ollama>`», y la verificación al cerrar (l. 766–784); §G.2 R-02 (l. 962); §G.3 DEP-14 (l. 987).
- **Afirmación**: el 09 §3 le encarga al gestor montar el Ollama propio en **una segunda máquina** (no en la de la corrida), alcanzable sólo por la red privada y con los dos modelos. El plan v2 supone otra cosa en cuatro lugares. (1) §E.6 pone a `<ollama>` (contenedor y volumen) con **dueño «arnés»**, que lo borra al cerrar. La verificación de cierre (`docker ps -a --filter label=<etiqueta-del-arnés>`, `docker volume ls`) corre sólo contra el docker local, así que no ve nada de la otra máquina, y el arnés no tiene cómo borrar allá. (2) R-02 mitiga «la máquina de la corrida al límite» con la secuencia propia. Con el Ollama en otra máquina, la competencia de CPU con `build` desaparece (H2-020 deja de importar para EMB-B), pero aparece otra. El registro del gestor muestra que en esa máquina se crearon a las 08:12 dos emuladores **reservados a otras sesiones** (`emulador-gda`, `emulador-fc`), sobre los que esta corrida no tiene turno ni exclusión. (3) La calibración de `estado_cache` por ms/token (§E.1, l. 651) y los tiempos de 05 («B ≪ A con el mismo prefijo») suponen un Ollama propio **sin carga ajena**. Con emuladores de otras sesiones en la misma CPU, eso no se puede garantizar. (4) DEP-14 pide sólo el alta del recurso. No pide `salud` del endpoint remoto con timeout, que es lo que necesita el predicado de salto de §F.8.
- **Ancla**: 09 l. 31 (el encargo). El registro del gestor, 5 eventos de creación a las 08:12:50 (emuladores de otras sesiones en la segunda máquina). `<gestor-de-turnos> estado`: `emulador-gda` y `emulador-fc` «RESERVADO para» otras sesiones. Plan l. 770–783 (tabla de §E.6 y la verificación).
- **Impacto**: si el gestor cumple el encargo tal como se le pidió, el inventario de cierre da «vacío» con un contenedor y un volumen de ~1 GB vivos en otra máquina y sin dueño en la bitácora. Las cifras de 05 y la calibración de caché se miden con una carga ajena que no se registra.
- **Dirección**: separar en §F.9 y §E.6 **el camino del lector** (compose con `ollama-embed` local, como está) del **camino del laboratorio** (Ollama propio provisto por el gestor, por `OLLAMA_EMBED_ENDPOINT`). En §E.6, agregar la fila «Ollama propio remoto · dueño: gestor · se borra al liberar el encargo, con su propia verificación registrada por el gestor». En R-02, reemplazar la mitigación de CPU por la regla de medición: 02 y 05 alternan A/B dentro del mismo turno e informan **cocientes**, no tiempos absolutos, y el R-LLM agrega la carga de la máquina al pedir el turno (sin nombre ni dirección). Agregar a DEP-14 «`salud [recurso-modelo-propio]` responde dentro de 10 s».

### OP3-04 · S2 · E3 (aritmética sobre E1) · confianza 0,80 · «Qué entra según el tope» sólo vale con EMB-B, y el régimen que rige de hecho es EMB-C

- **Ubicación**: §E.5, l. 752 (TURNO-3), l. 754 (Tope) y la papeleta de RV-03 (l. 762).
- **Afirmación**: la tabla de topes y la papeleta de RV-03 suponen que 07, Estabilidad, PD-2, 15 y 16 corren. Con EMB-C, que es el régimen de hoy, no corren: §E.5 l. 752 deja «no ejecutado» a 07 y PD-2, y J1 (06-Aprobacion §2.1 (2)) ya señaló que Estabilidad y 15 dependen de 07. Recalculado con los pesimistas de la v2: **TURNO-1 con EMB-C = 12.400 − 1.280 (07) − 240 (Estabilidad) − 80 (PD-2) = 10.800 s (3,0 h)**. TURNO-2 ejecutable = 13 + 17 + 12 + 03 ext. + 04 ext. + 08 ext. = **5.840 s**. Si la calibración de 15 (20 llamadas M) no depende de 07, se suman 2.628 s con M = 131,4 s y da 8.468 s. Por eso: con **4 h** (quedan 3.600 s) entra hasta 04 ext. (2.640 s) y quedan afuera 08 ext. y la calibración de 15. Con **6 h** (quedan 10.800 s) entra **todo lo ejecutable**, con un margen de 2.332 a 4.960 s para repeticiones por truncado (la objeción de J3 a PAR2-06). Con **9 h** no entra nada más que con 6 h. Con EMB-B, la clase M a 131,4 s (J1) confirma que «con 6 h, hasta 15» es falso: 2.640 + 6.833 = 9.473 > 9.200.
- **Ancla**: §E.5 tablas TURNO-1 y TURNO-2 (l. 711–750). La fórmula de AJ-02 con p = 1.000 y s = 100: 106,4 + 25 = 131,4 s. Estado del gestor arriba (E1).
- **Impacto**: el jurado votaría RV-03 con una tabla que no describe el régimen que va a regir. Bajo EMB-C, la opción (c) gasta tres horas del servidor compartido sin ganar ninguna pieza, y la opción (a) deja sin margen la regla de no cortar TURNO-1 por repeticiones.
- **Dirección**: agregar a §E.5 una segunda columna de «Qué entra», con EMB-C, y votar RV-03 con las dos (ver la posición). Aceptar M = 131,4 s (o declarar s ≤ 50 para el juez, rotulado E3) y rehacer la frase de 6 h. Declarar en el punto 3 de la línea de corte si TURNO-2 **saltea** una pieza que no entra y sigue con la siguiente que sí, o si se detiene. Hoy dice «en el orden de la tabla mientras quede tope», y eso decide si 08 ext. corre detrás de un 15 que no entra.

### OP3-05 · S3 · E1 · confianza 0,80 · En el host de la corrida, docker no puede bajar de Docker Hub con su configuración por defecto, y el plan no lo dice

- **Ubicación**: §E.1 arnés y «Build» (l. 631–652); §F.9 (l. 919, `compose.yaml` con `ollama/ollama:0.40.11`); §E.6.
- **Afirmación**: `docker manifest inspect ollama/ollama:0.40.11`, y también `…:0.32.0-rc0`, falla en el host con «unauthorized: incorrect username or password»: hay una credencial vencida en la configuración por defecto de docker. Con una configuración vacía, que el laboratorio ya tiene preparada en su directorio de trabajo (fuera del repo), la misma orden responde. `mcr.microsoft.com/dotnet/sdk:10.0` sí resuelve con la configuración por defecto. Ninguna bitácora de `OUTPUTs/` documenta esa configuración alternativa (`grep -rl` = 0).
- **Ancla**: dos corridas de `docker manifest inspect`, con y sin `DOCKER_CONFIG` vacío, en este informe. `docker image ls ollama/ollama` → sólo `latest` y `0.32.0-rc0`.
- **Impacto**: con EMB-B local (camino del lector reproducido en el laboratorio), la primera fase que necesite `ollama/ollama:0.40.11` falla por credenciales y no por el plan, y cada constructor lo resuelve a su modo, o borrando la credencial del PO, que no es suya. Son además ~3,4 GB comprimidos para bajar, en una máquina al límite (R-02).
- **Dirección**: §E.1 «Build» dice que el arnés corre las bajadas de imágenes con una configuración de docker vacía, fuera del repo y referenciada por variable, y que no toca la configuración del usuario. La bajada de `ollama/ollama:0.40.11` sólo se hace si EMB-B es local. Con EMB-B remoto (OP3-03) no se baja nada en el host. §E.6 suma la imagen como recurso a borrar al cerrar si la bajó el arnés.

### OP3-06 · S3 · E1 · confianza 0,70 · El pedido PAR2-25 no cubre lo que el encargo nuevo exige y no tiene plazo, y el plan no dice quién declara EMB-C ni cuándo

- **Ubicación**: §G.3 DEP-14 (l. 987); §E.5 TURNO-3 (l. 752); 09 §3.
- **Afirmación**: PAR2-25 sigue como lo votó el ciclo 2, con las cuatro faltas de J5: TTL en el arreglo, `TODOS`, la rama de `salud` y el ttl ≤ 240 frente a TURNO-2. El 09 §3 le sumó al dueño un encargo distinto (montar el servicio en otra máquina) sin actualizar el criterio verificable. Además, «si no se resuelve antes de construir, rige EMB-C» no tiene fecha ni responsable. Como no hay ciclo 4, nadie va a re-votar, y la construcción puede arrancar en EMB-B «a la espera» y quedar a mitad de TURNO-3.
- **Ancla**: estado medido arriba (script sin cambios desde las 08:12, sin alta en el registro). `<gestor-de-turnos>` l. 98: `[ "$ttl" -le 240 ] || die`. 06-Aprobacion §2.8.
- **Impacto**: la deuda «02, 05, 06, 07, 16 y PD-2 sin modelo» se decide por omisión y no queda registrada con su motivo, que es lo que AC-3b exige («registrada por la mesa»).
- **Dirección**: en DEP-14, (1) criterio verificable ampliado: `<gestor-de-turnos> recursos` lista `[recurso-modelo-propio]`; `pedir`/`renovar`/`liberar` dan 0; `salud [recurso-modelo-propio]` responde en ≤ 10 s y lista los dos modelos; la regla de convivencia con los emuladores de la segunda máquina está escrita en PROTOCOLO.md; el cambio es sólo aditivo. (2) **Punto de decisión**: antes de pedir el primer turno `build`, el arnés corre `<gestor-de-turnos> salud [recurso-modelo-propio]`. Si da rc ≠ 0, exporta `EMB_PLAN=EMB-C`, lo escribe en `turnos.jsonl` con el motivo «DEP-14 sin resolver» y la construcción entera corre en EMB-C, sin cambiar de régimen a mitad. Ese registro es lo que cierra AC-3b.

## Revisado y bien

- **Orden global de pedido y fases sin anidar** (§E.1, l. 631–642): `build` → `[recurso-modelo-propio]` → `<recurso-compartido>`, de a uno, con un contenedor por fase y un medidor del repo. Cierra OP-03 del ciclo 2 sin depender de cambios en el gestor, y sigue valiendo si el Ollama propio pasa a otra máquina.
- **Inventario de §E.6 para lo local**: el estado de hoy coincide con lo que el plan declara. Hay volúmenes `<volumen-nuget>`, `<volumen-nuget-n3>` y `<ollama-n3>`, y cero contenedores con `label=<etiqueta-del-arnés>`. La regla «borrar un volumen sólo al cierre y después de verificar `Evidencia/`» es la correcta para algo irreversible.
- **EMB-C como salida explícita** (§F.6, l. 900): la demo no degrada sola, y si el endpoint no tiene la capacidad `embedding` arranca con un error que dice cómo pasar a EMB-C. Con el gestor como está hoy, es el camino que se va a recorrer, y está bien especificado.

## Posiciones sobre la agenda (dentro del mandato)

- **DEP-14 / EMB**: rige **EMB-C** desde ya. Hay que fijar el punto de decisión de OP3-06. EMB-B pasa a ser una mejora, no el supuesto del presupuesto.
- **RV-03**: **(b) 6 h**. Con EMB-C es el único tope que cubre todo lo ejecutable con margen para repeticiones, y 9 h no agrega ninguna pieza. Con EMB-B, 6 h llega hasta 04 ext. (y hasta 08 ext. si se permite saltear) (OP3-04).
- **RV-11**: **(a) sesgo declarado**. La opción (b) exige DEP-14 resuelta (plan l. 1131), y hoy no lo está.
- **H2-056 (fusiones)**: neutral en turnos. F1 y F3 ahorran 0 llamadas de `<recurso-compartido>`, y F2 sólo ahorra una fase de embeddings que con EMB-C no existe. Se decide por didáctica, no por presupuesto.
- **H2-054 (recorte de la demo)**: a favor de que los pasos PD que repiten un ejemplo queden **en `--fake` con su cableado**, sin corrida contra el modelo. Los pasos de clase L (PD-1, PD-5, PD-6) suman 3.325 s de TURNO-1, y cada uno que sale libera 950 a 1.425 s del servidor compartido. Conviene conservar al menos una corrida de humo integrada contra el modelo, para que la demo tenga evidencia propia.
- **Objeción de J5 a PAR2-25**: procede. Se integra en el criterio ampliado de OP3-06.
- **Objeción de J1 (clase M = 131,4 s)**: procede, y cambia la frase de 6 h (OP3-04).
- **Listas `$R_PRIV_LISTA` y `$RD_PO_LISTA`**: crearlas **antes de construir**, fuera del repo, junto al directorio de estado del laboratorio, con texto fijo por línea y una autoprueba de positivos también fuera del repo. Contenido de R-PRIV, por clase: nombres de host de las máquinas del laboratorio, el número de serie del teléfono, el usuario del sistema y su ruta de inicio, y los nombres de repos privados. El rango 100.64/10 va como patrón en el repo (OP3-02). `$RD_PO_LISTA` lleva los nombres de los otros proyectos del PO, que también son R-PRIV cuando son privados, y por eso no puede vivir en el repo. **Decisión que hay que tomar**: el usuario del sistema ya aparece en rutas absolutas de 11 archivos de `OUTPUTs/`, `00-Contrato-De-Entrada.md` l. 70 incluido. El resto del repo ya tiene 10 archivos versionados con esa ruta. Si la mesa lo considera R-PRIV («ni usuarios», l. 68), esos 11 archivos se reescriben con rutas relativas a la raíz del workspace. Si no, la lista lo excluye y la excepción queda escrita.

## Preguntas (no son hallazgos)

- Las 10 entradas de calibración de 15, ¿son salidas de 07 anotadas a ciegas (y entonces con EMB-C 15 queda entero afuera) o son independientes de 07? Cambia el margen de OP3-04 en 2.628 s.
- Si el gestor cumple el encargo con dos modelos residentes en la segunda máquina, ¿el `num_ctx` «propio: 8192» de §E.1 vale para los dos, o el modelo de embeddings necesita su propia regla de carga para no recargar al de chat de 05 entre llamadas?

## Solicitudes de convocatoria

Ninguna. OP3-01 lo corrige la secretaría (es una bitácora). OP3-03 y OP3-06 son de la presidencia y del dueño del gestor.
