---
doc_id: BIT-16-REC-05
doc_type: cierre-de-mesa
title: Cierre de la mesa de recuperación (guía 16, B-15)
status: cerrado; quedan decisiones del PO
origin: agent (presidencia del cierre)
last_review: 2026-10-30
---

# Cierre de la mesa de recuperación (guía 16)

Este documento cierra el plan [`03-Plan-De-Recuperacion.md`](03-Plan-De-Recuperacion.md), que ahora figura como «aprobado; aplicado». El detalle de cada bloque está en [`04-Aplicacion.md`](04-Aplicacion.md), y el de este cierre en su sección «B-15 · Cierre». La relectura está en [`Relectura/`](Relectura/). Como el resto de la carpeta, este cierre se escribe **sólo con roles**.

```yaml
cierre:
  fecha: 2026-10-30
  guia:
    version: 0.11.0
    status: en revisión            # pasar a «publicada» lo decide el PO
    sha256: c8defd8324497c4279a3dfd57ce5d2757326ad966813a9f9797d0196d9b7ce3d
  bloques:
    B-00: {estado: aplicado, nota: foto de la base}
    B-01: {estado: aplicado, nota: "tools/, arnés, variables sin defecto (M-A, M-K), compuerta-intervalos (M-C)"}
    B-02: {estado: aplicado, nota: "bitácora redactada; dictamen REC-33 adoptado"}
    B-03: {estado: aplicado, nota: "_Comun: lector sin cuerpos (M-I); guarda con el modelo de la llamada (M-F; DEU-09 no se abrió)"}
    B-04: {estado: aplicado}
    B-05: {estado: aplicado}
    B-06: {estado: aplicado}
    B-07: {estado: aplicado}
    B-08: {estado: aplicado, nota: "limitador portado (M-E 10/10; DEU-08 no se abrió)"}
    B-09: {estado: aplicado}
    B-10: {estado: aplicado}
    B-11: {estado: aplicado, nota: "fase con modelo única; cada corrida medida o «no medido» según su criterio previo; R-15 y R-15b «no medido»"}
    B-12: {estado: aplicado, nota: "cifras ⟦REC-02⟧ rellenadas; grep del marcador = 0"}
    B-13: {estado: aplicado, nota: "0.11.0 «en revisión»"}
    B-14: {estado: aplicado con pendientes, nota: "35 ítems RL; 34 parches aprobados (P-01…P-34), ninguno escalado; verificación 06 con PV-01 y PV-02 abiertos"}
    B-15: {estado: aplicado, nota: "barrido final, procedencia cerrada, limpieza, este cierre"}
  compuertas_finales:            # build y demo sobre copia, con turno (Relectura/06-Verificacion.md); R-PRIV de B-15
    AC-5: pasa
    AC-6: pasa
    verificar_build: "pasa, 561/561 en 18 suites"
    demo_pruebas: "pasa, 81/81"
    AC-7_AC-8_AC-9: pasan
    AC-10: pasa
    verificar_markdown: "pasa, rc 0, 180/180 REF"
    compuerta_cabeceras: "registros del build rc 0; árbol rc 2, igual que la base"
    marcador_REC-02: 0
    bin_obj_db_en_la_guia: vacío
    contar_sh: "130 % del tope (informativo)"
    compuerta_intervalos: "NO PASA, rc 1 (PV-01)"
    rpriv_final:
      guia_y_arbol: "0 en todas las clases; excepción declarada: el valor histórico de salidas-07.v1.json (D-B13-2)"
      prompts_16_ia_layer: "0 en todas las clases fuera de las excepciones declaradas por valor exacto (ver 04-Aplicacion, B-15)"
      compuerta_P-01_v2: "patrones 0 y cabeceras 0 en los dos repos; identificadores sólo en las excepciones declaradas"
  deuda:
    DEU-01: cerrada (endurecimiento aplicado)
    DEU-02: abierta (04 no registra el cierre; el modelo provisional sigue «provisional, no comparado»)
    DEU-03: cerrada (la oración de NUnit no entra porque ningún build la verificó)
    DEU-04: abierta (los tres pedidos al gestor van fuera del repo y esta mesa no los verifica)
    DEU-05: declarada (autorización MCP fuera de alcance)
    DEU-06: declarada (agujeros de la prueba de arquitectura)
    DEU-07: pasa a decisiones del PO
    DEU-08: no se abrió
    DEU-09: no se abrió
    DEU-10: "PV-01: 18 cifras sin fila en compuerta-intervalos.tsv y fila I22 sin ancla (P-08, P-09, P-14, P-18, P-19, P-21, P-22, P-28)"
    DEU-11: "PV-02: verificar.sh contra la estación vigente con turno y registro R-LLM (P-30, P-31)"
    DEU-12: "RL-21: MEJORAR_PLAN, sin parche"
    DEU-13: "Relectura/02-Voto-coherencia-historica.md tiene 0 bytes; se repone por agregado"
    DEU-14: "registros R-LLM fuera de la evidencia de la bitácora (R-02, R-15, R-15b, R-DG y partes de R-06, R-07 y R-16): quedan en {dir-de-trabajo}, que no se borró"
    DEU-15: "la carpeta del insumo y seis rutas internas llevan en su nombre el de un equipo; el contenido está redactado y los nombres de ruta no se cambiaron"
    DEU-16: "Reanudar.md queda fuera de commit (B-02 2.5); la presidencia todavía no lo trasladó al insumo"
  decisiones_del_PO:
    - publicar la demo
    - commitear la guía (con AC-10) y la bitácora; antes de hacerlo, resolver DEU-10 y DEU-15
    - pasar 0.11.0 a «publicada»
    - integrar por PR con la otra sesión, que es la dueña del repo
    - hacer la prueba móvil MD-1 en los emuladores de la estación 1 (nunca en la estación 2)
    - renombrar o excluir del commit las rutas del insumo de DEU-15
  entorno_al_cierre:
    estacion_1: "Ollama corriendo y sin modelos cargados (/api/ps vacío, 0.40.11)"
    estacion_2: "contenedor de Ollama detenido (ELV-02), sin modelos cargados antes de detenerlo; se conserva el volumen de modelos"
    trabajo: "copias verificadas borradas, con un tgz sin binarios en $FOTOS; las que tienen registros sin consolidar se conservan"
```

## En pocas palabras

Se aplicaron los dieciséis bloques del plan. La guía 0.11.0 queda «en revisión», con build 561/561 y demo 81/81. Todas las compuertas pasan menos una: `compuerta-intervalos.py` falla porque los parches de la relectura agregaron cifras sin sumar sus filas al mapa (DEU-10). Esa compuerta y la corrida con modelo de P-30/P-31 (DEU-11) son lo único que separa la guía de un commit limpio.

El barrido R-PRIV final da 0 en todas las clases sobre los dos repos y sobre el insumo archivado, salvo excepciones declaradas por valor exacto: capturas históricas, versiones de ensamblado y de paquete, y los nombres de ruta de DEU-15. El insumo se redactó en su contenido, con una foto previa, y la procedencia registra qué orígenes cambiaron de sha256.

Commitear, publicar, pasar a «publicada», integrar con la otra sesión y hacer la prueba móvil son decisiones del PO. Esta mesa no las ejecuta.

## Actualización 2026-10-30: deudas DEU-10, 11, 13, 14

Agregado el 2026-11-01 por un verificador independiente. Lo de arriba no se modificó. La guía no se tocó: sha256 `c8defd8324497c4279a3dfd57ce5d2757326ad966813a9f9797d0196d9b7ce3d`, igual antes y después. DEU-11 no propuso cambio de texto, así que no hubo parche.

```yaml
actualizacion_2026_10_30:
  deuda:
    DEU-10: "cerrada: compuerta-intervalos.py rc 0, 81 figuras, 81 en el mapa, 57/57 filas (sólo cambió tools/compuerta-intervalos.tsv, sha256 935052…ae9f7 → 719edac…91250)"
    DEU-11: "cerrada: PV-02 pasa; criterio escrito antes (Evidencia/R-LLM-2026-10-28/PV-02/criterio-2026-11-01.md, sha256 8cc2eee4…6718); corrida de 05 con modelo sólo en la estación 1, con turno; 5 condiciones cumplidas; sin cambio en la guía"
    DEU-13: "cerrada: Relectura/02-Voto-coherencia-historica.md reconstruido por deducción del recuento de 04-Aprobacion.md (declarado en el archivo); sin fundamentos, porque no constan"
    DEU-14: "cerrada: 309 registros copiados a Evidencia/R-LLM-2026-10-28/, sha256 origen = destino, manifiesto SHA256SUMS-DEU-14.txt; R-PRIV 0"
    DEU-12: "sigue: RL-21, MEJORAR_PLAN"
    DEU-15: "sigue"
    DEU-16: "sigue"
  compuertas_finales:            # copia {dir-de-trabajo}/verif-07, turno build concedido y liberado; copias borradas al terminar
    AC-5: "pasa, idénticos"
    AC-6: "pasa; sólo la excepción declarada Azure.AI.OpenAI 2.9.0-beta.1; demo sin previews"
    verificar_build: "pasa, rc 0, 561/561 en 18 suites; R-PRIV del build 0"
    demo_pruebas: "pasa, rc 0, 81/81"
    AC-7: "pasa, 40/40 positivos"
    AC-8: "pasa, 2 exceptuadas, 5/5 positivos, lista 11/11"
    AC-9: "pasa, 57 bloques, 0 diferencias"
    AC-10: "pasa: 27 iguales, 17 distintos, 60 nuevos, 0 quitados"
    verificar_markdown: "pasa: guía 229 encabezados, 283 anclas, 180/180 REF, 111 rutas (4 exceptuadas); árbol rc 0"
    rpriv_ampliado: "1 turnos + 1 identificadores, el mismo recuento que el histórico declarado (D-B13-2); resto 0"
    compuerta_rpriv: "0 hallazgos"
    compuerta_intervalos: "PASA, rc 0 (81/81, 57/57)"
    compuerta_cabeceras: "registros del build 0 en 4 cuerpos; árbol rc 2, igual que la base (D-B03-2)"
    marcador_REC-02: 0
    contar_sh: "130 % (informativo)"
    bin_obj_db_en_la_guia: vacío
```

Ninguna compuerta retrocede respecto de `Relectura/06-Verificacion.md`, y `compuerta-intervalos.py`, que fallaba allí, ahora pasa. Para commitear, la mesa ya no tiene nada técnico pendiente. Siguen las decisiones del PO: DEU-15 antes de commitear, publicar la demo, pasar 0.11.0 a «publicada», integrar por PR con la otra sesión y hacer la prueba móvil MD-1. Sin commit, push, PR ni ramas. No llegaron mensajes ajenos a la carta.
