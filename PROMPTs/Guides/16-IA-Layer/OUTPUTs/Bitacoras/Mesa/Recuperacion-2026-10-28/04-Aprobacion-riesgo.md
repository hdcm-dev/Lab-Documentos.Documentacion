---
doc_id: BIT-16-REC-04-RIESGO
doc_type: aprobacion-de-plan
title: Aprobación del plan de recuperación — juez de riesgo (mesa de recuperación, 2026-10-28)
status: MEJORAR_PLAN
origin: agent (jurado, juez de riesgo)
last_review: 2026-10-28
---

# Aprobación del plan de recuperación: juez de riesgo

**Objeto:** [`03-Plan-De-Recuperacion.md`](03-Plan-De-Recuperacion.md), revisado contra [`01-Matriz.md`](01-Matriz.md) y las cinco boletas `02-Voto-*.md`.
**Función:** riesgo e irreversibilidad. Miro dos cosas que no se pueden revertir: que un dato privado llegue a un commit de un repo público, y que se pierda evidencia sin copia. También miro que la evidencia de la fase con modelo no salga contaminada.

**Decisión: MEJORAR_PLAN.** El plan es sólido y casi todo está bien. Pero tiene dos puntos que contradicen lo que votó el jurado, y varias condiciones de los votos que no pasaron al plan. Ninguno de esos puntos requiere escalar: no hay conflicto con REED-16 §12 ni nada que deba decidir el PO. La presidencia los corrige en el plan antes de B-00 y el plan queda aprobado sin otra vuelta, salvo que la corrección cambie una ganadora.

## 1. Lo que verifiqué y está bien

- **Conteos de la tabla §0.3.** Recontados contra las cinco boletas:
  - REC-07 C da 3 a 2 (riesgo, coherencia e impacto por C; evidencia y costo-beneficio por A).
  - REC-15 B da 5 a 0.
  - REC-18 A da 4 a 1 (coherencia por C).
  - REC-21 C da 4 a 1 (evidencia por A).
  - REC-23 A da 3 a 2 (evidencia y coherencia por C).
  - REC-35 A da 4 a 1 (coherencia por B).
  - Hay un solo veto, el de REC-06 sobre B. Coincide con la ganadora.
  - **Sin errores.**
- **Condiciones transversales T1 a T4** de mi boleta:
  - T1: la foto previa fuera del árbol está en B-00 0.1, y el diff de cada `sed` en B-02 2.3.
  - T2: hay barrido sobre las capturas nuevas (B-11, preparación 2) y los endpoints viajan sólo como variable (§0.1).
  - T3 y T4: §0.2 regla 1.
  - **Las cuatro están.**
- **Irreversibles fuera de la mesa.** Publicar la demo, hacer el commit y pasar a «publicada» quedan para el PO (DEU-07, B-15). Es correcto.
- **Evidencia sin copia.**
  - Las capturas fijadas por hash no se tocan (B-02 2.3) y `recalcular-oraculos.sh` sigue verificando 365/365.
  - `salidas-07.v1.json` se declara histórico sin tocar el archivo (B-01 1.11).
  - El insumo sigue siendo de sólo lectura, con verificación en B-00 0.4.
- **R-PRIV del propio plan.** Barrí el plan buscando IPs, rutas del home, usuario, nombres de equipos y recursos del gestor y la clave de cabeceras: no hay ninguna aparición. Las únicas direcciones que nombra son `127.0.0.1` y «la interfaz del bridge», que son las permitidas.
- **Orden.** REC-35 entra en B-03, antes de B-11, así que hay un solo cambio de `paquetes_hash`. La guía se edita de a un bloque por vez y se ubica por ancla más texto. El marcador `⟦REC-02:…⟧` lleva su compuerta de cero. Todo esto reduce el riesgo de colisión y de cifras huérfanas.
- **Las listas de AC-7 y AC-8 fuera del árbol** usan `${COMPUERTAS_DIR:?}`. Si falta la variable, la compuerta falla y no pasa en verde. Es lo correcto.

## 2. Correcciones obligatorias (contradicen lo votado)

| # | Dónde | Problema | Corrección |
|---|---|---|---|
| M-1 | B-01 1.5 y B-11, preparación 4 | El plan dice que `OLLAMA_SERVIDOR` y `RLLM_MAQUINA` «se leen del entorno **con defecto**». En mi boleta hice mía la enmienda de AH-02, y el juez de evidencia la declaró **obligatoria**: en la fase con modelo esas dos variables van **sin valor por defecto**, y si faltan, la fase aborta. Si se deja un defecto, puede volver la contaminación silenciosa («compartido» o el rol que sea) que REC-07 vino a cerrar. Además, el defecto sería un valor escrito en el repo. | En 1.5 hay que decir que en `--fake` y `build` se permite un defecto neutro (`sin-servidor`). En `fase *`, `extension`, `estabilidad`, `embeddings` con modelo y `demo.sh embeddings` las variables son obligatorias (`${OLLAMA_SERVIDOR:?}` y `${RLLM_MAQUINA:?}`). Verificación nueva: `verificar.sh fase …` sin esas variables tiene que dar rc ≠ 0 con un mensaje, igual que con `RLLM_DIR` en 1.7. En B-11, preparación 4, hay que poner «obligatorias; sin ellas, aborta». |
| M-2 | B-06 6.9 (y lo que herede §5.6) | La frase prescrita, «el cliente lo envía; **el servidor no lo honra** según [REF-51]», sale de la opción A tal como estaba escrita en la matriz. Pero tres jurados (coherencia, costo-beneficio e impacto) votaron A **con la enmienda** del abogado del diablo, y la propia matriz dice que «que el servidor lo cumpla no está medido». Escribirla así es afirmar algo que no se midió, en un texto público. | La frase pasa a: «el cliente envía `tool_choice`; la documentación de `/v1` no lo lista [REF-51]; que el servidor lo cumpla no está medido». Además, hay que alinear las demás líneas de la guía que dicen «/v1 no admite» (`grep -n 'no admite'` en §5.6, §8 y Anexo F). |

## 3. Condiciones de los votos que faltan en el plan

| # | REC | Condición de origen | Qué hay que agregar |
|---|---|---|---|
| M-3 | REC-13 | Costo-beneficio e impacto votaron A con la condición de que, si la prueba determinista no sale en un tiempo razonable, cae a C. | En B-08 8.1 hay que agregar el **plan de caída**. Si la prueba de 4 simultáneos no queda verde 10 de 10 veces seguidas, no se porta el limitador. Se aplica REC-13 C (sólo prosa en §12.3, con la deuda declarada), se anota en `04-Aplicacion.md` y se ajustan en consecuencia 9.12, 10.3 y 10.7. Nunca debe quedar en la demo una prueba que falla a veces. |
| M-4 | REC-22 | En mi boleta: hay que recompilar completo y correr ArnesTests después de portar el lector a `_Comun`, y el lector **no puede guardar cuerpos completos en disco**. | En B-03 3.1 o 3.5 hay que verificar `verificar.sh build` n/n completo y ArnesTests en verde. También hay que comprobar que el lector sólo extrae `prompt_eval_cached_count` y no persiste el NDJSON (con un `grep` de escrituras a archivo en el `DelegatingHandler`, o con una prueba). |
| M-5 | REC-18 | El juez de evidencia votó A con condiciones: fijar en el criterio previo la **fracción mínima de interpretables** (si no se alcanza, «no medido») y no presentar el acuerdo como validación, porque el juez es de la misma familia. | En la fila R-15 de B-11 hay que agregar «fracción mínima de interpretables fijada en `criterio-15-juez.md`; si no se alcanza, no medido». En 9.7 hay que agregar «el acuerdo con el juez no es validación (misma familia)». |
| M-6 | REC-23 | En mi boleta: el texto inyectado que se cite tiene que ser **sintético** y pasar el barrido. Evidencia y coherencia (los 2 votos por C) pidieron el oráculo «reproduce el texto inyectado» en el criterio previo. Impacto pidió que sólo se cite como existencia y que se prefiera la medición de la base. | En R-16 hay que declarar ese oráculo en `criterio-16-inyeccion.md`. En 9.8 hay que agregar: si la re-corrida lo observa, entra esa cifra; si no, la observación del insumo entra **sólo** como existencia rotulada, nunca como tasa. Todo texto inyectado citado en la guía tiene que ser sintético y pasar el barrido ampliado. |
| M-7 | REC-02 | Mi boleta y la de evidencia piden que cada pieza corra entera en una sola estación y que ningún pareado cruce estaciones. Pero B-11, preparación 6, dice «un turno que no cabe se parte». | Hay que agregar que se parte **en la misma estación**. Una pieza o un pareado nunca se reparte entre la estación 1 y la 2. Si la estación asignada se cae a mitad, lo que falta queda «no medido» y no se completa en la otra estación. |
| M-8 | REC-21 | Coherencia (por C) pidió incluir en C la calibración por modelo. Evidencia condicionó su paso a C a lo mismo. Son precisiones en prosa de la guarda de la base, sin pieza nueva y sin riesgo. | En B-06 6.6 hay que agregar la frase «la calibración de caracteres por token es por modelo; la guarda estima con el modelo de la llamada», rotulada. Si `GuardaDeTruncado` hoy no estima con el modelo de la llamada, se declara como deuda, sin cambiar código en esta mesa. |
| M-9 | REC-02, REC-06.3 | Impacto, nota 1: el rótulo modelo de §0.4 (l. ~163) es la plantilla que el lector imita en toda la guía, y hoy remite al servidor retirado. | En B-06 hay que agregar un paso **6.0**: reescribir el rótulo modelo de §0.4 con el formato de rol («estación N, Ollama x.y.z, digest, fecha, estimando»), con el marcador `⟦REC-02:…⟧` donde haga falta. También hay que alinear §0.3 (l. ~139) con EMB-A y EMB-B por papel, que es la nota de impacto en REC-05. |

## 4. Observaciones menores (no bloquean)

- **R-06 de B-11.** La columna N («16 (oro v2 sin la nueva no respondible ≠ calibración)») es ambigua. Hay que escribir N exacto de evaluación y de calibración, y declarar que los dos conjuntos son disjuntos.
- **B-01 1.7.** El ejemplo `verificar.sh fase lan` conserva el nombre `lan` de la fase. Si 1.5 renombra papeles, conviene revisar si el nombre de la fase también filtra el rol retirado. Si se deja, la nota de equivalencia de 2.7 tiene que nombrarlo.
- **Clon limpio.** Con las listas de AC-7 y AC-8 fuera del árbol, alguien que clone el repo no puede correr esas compuertas. El README de `Compuertas/` tiene que decir que esas dos compuertas son del laboratorio y cómo se arma el archivo con el formato del repo, sin términos privados.

## 5. Firma

Juez de riesgo, mesa de recuperación de la guía 16, 2026-10-28. **MEJORAR_PLAN: M-1 a M-9.** Con esas correcciones aplicadas en el plan, mi aprobación queda dada sin otra vuelta, salvo que la corrección de M-3 cambie la ganadora de REC-13 por una causa distinta de la caída prevista. No ejerzo veto.
