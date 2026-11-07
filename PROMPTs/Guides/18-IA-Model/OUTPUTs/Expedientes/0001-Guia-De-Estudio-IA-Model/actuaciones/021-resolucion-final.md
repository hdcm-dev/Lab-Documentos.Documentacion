# Folio 021 — Resolución final: cierre de la mesa y entrega de la guía

| Campo | Valor |
| --- | --- |
| Tipo | resolucion |
| Fecha | 2026-11-07 |
| Autor | presidencia de la mesa |
| Corrige | — |

Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas: las del presidente (§1–§8). La presidencia
consolida; el juicio es el del jurado (folios 011 y 020).

## 1. Cuenta de folios

- **Ronda de estructura**: 8 informes (folios 003, 005–011); fichas de excepción: 0. 45 PROCEDE /
  0 NO PROCEDE / 0 ARCHIVA. Cerrada por el folio 012.
- **Fase de elaboración**: 15 piezas escritas, 11 constancias de verificación
  (`despacho/verif-01…11`), edición académica completa; observaciones compiladas en evidencia/015.
  Cerrada por el folio 013.
- **Ronda 2 (revisión del borrador completo)**: 7 informes (folios 014–020: cinco comisiones a
  ciegas, refutador, jurado); fichas de excepción: 0. Hallazgos de comisiones: 47; del refutador: 10.
  Veredicto del jurado (folio 020): **54 PROCEDE / 0 NO PROCEDE / 3 ARCHIVA**; ningún C fundó parche.
- **Aplicación de parches**: 12 direcciones votadas (PA-01…PA-12) aplicadas en 8 lotes
  (`despacho/parches-01…08`), 19 ítems de constancia, **0 parches devueltos**; 2 deudas declaradas
  (PD-01, PD-02) con evento de cierre, NO aplicadas conforme al veredicto.
- Total de folios del expediente: 21 (001–021). La cuenta cierra.

## 2. Verificación de cierre (tres lentes independientes, posterior a los parches)

1. **Parches**: CONFORME — los 12 PA comprobados contra la dirección votada (anclas del jurado
   corridas); PD-01 y PD-02 comprobadas como NO aplicadas; condición de R2-REF-01 respetada
   (la sección de destilación entró en 11 §1.8 y la fila del glosario de M1 permanece).
2. **Editorial**: CONFORME — enlaces relativos y anclas: 564 verificados, 0 rotos (slug de guion
   largo → guion doble incluido); frontmatter 15/15 conforme a la norma parchada (owner `ACT-NN`,
   traces de forma única); `grep -c VERIFICAR` → 0 en las 15 piezas; índices contra encabezados
   reales: 0 desajustes. Mermaid: **12/12 documentos con diagrama validados** por la presidencia con
   el validador de medios del workspace (el lente editorial llegó a 4/13 renderizados, todos ok, al
   corte de su corrida; la presidencia completó la pasada: ok=12, fallos=0).
3. **Higiene de publicación**: CON-DEFECTOS en su corrida, **corregidos por la presidencia antes de
   esta resolución**: dos rutas internas del host en evidencia/015 reemplazadas por marcadores
   (`<scratchpad>`, `<area-agentes>`); constancias verif-01/04/05/06/09 y folios 012/013 ahora
   declaran `evidencia/local/` como no versionada. Verificado tras la corrección: barrido limpio.
   Huellas E-8 de los folios 001 y 004 recomputadas y coincidentes. `git ls-files -ci
   --exclude-standard` vacío en ambos worktrees; nada tocado fuera del objeto en ninguno.

## 3. Excepciones de barrido declaradas

1. **Folio 004**: la palabra «infravm» en el testimonio literal del PO (huella E-8 verificada). Es un
   alias de VM sin dirección, puerto ni credencial; alterar la transcripción rompería la huella.
2. **Folio 017, línea 27**: el patrón `'/vm/|/home/|…'` dentro de un comando `grep` citado por la
   comisión de sistemas. Es un regex de barrido, no una ruta real del host; se preserva el informe
   verbatim.

## 4. Cierre

Con los parches aplicados y verificados, la guía cumple la regla de cierre de la clase y el pedido:
ningún P0/P1 vigente, todo P2 con parche o deuda declarada con evento abrible, y las cuatro preguntas
del caso respondidas (folios 011 §2–§4 y 020 §4). Rondas completas: estructura (1) + revisión (2),
con 54 hallazgos procedentes en la segunda: no hay dos rondas seguidas limpias, por lo que el cierre
es **por decisión y no por criterio**, con lo abierto enumerado:

- **PD-01** — tramo final del lab 6.B (servir `taller-qwen` en el banco) y promoción de
  status/confidence de IAM-06; evento de cierre: respuesta del PO a la fila 1 del lote (§5).
- **PD-02** — fijación de la revisión del modelo de embeddings en los protocolos del doc 09; evento
  de cierre: constancia del verificador con dato observado.
- Cliente `ollama` en el puesto de verificación (fila 2 del lote).
- Habilitación de embeddings del banco (`/api/embed`), ya en el lote del folio 012.
- Fuentes primarias pendientes de 11 §1.5 (tarea de ACT-06 en la próxima revisión de la capa volátil).
- Condiciones de revisión asentadas en PA-01, PA-02 y PA-03.

Las 15 piezas quedan con `status: borrador` (así se entregan: la promoción a vigente es decisión del
PO como dueño del repo, con PD-01 resuelta o asentada). Se dispone la entrega por
Conformacion-Pull-Request-Automatico 2.0 en los dos repositorios (guía y expediente/bitácoras), con
el alta incremental en la ia-db incluida.

## 5. Lote al PO (Detencion-Y-Lote 1.1; nada se asienta por silencio)

| # | Pregunta | Por qué | Prioridad | SI NO RESPONDÉS |
| --- | --- | --- | --- | --- |
| 1 | ¿Autorizás crear los modelos de prueba del lab 6.B (`taller-qwen` y `taller-qwen-base`, ~1 GB) en el banco, correr los pasos 5–6 y borrarlos al terminar? | Es lo único que separa el tramo final del lab de «operable» y condiciona la promoción de IAM-06 (PD-01) | P2 | Los pasos quedan [Ilustrativo] declarados, IAM-06 conserva confidence media y PD-01 queda abierta con su evento |
| 2 | ¿Autorizás instalar el cliente `ollama` (versión fija, declarada antes) en el puesto de verificación? | El paso 1 del lab de fichas del doc 02 tendría salida real en vez de ilustrativa | P3 | No se instala nada; el paso queda ilustrativo y la verificación sigue por API |
| 3 | ¿Habilitás embeddings en el banco (`--embeddings` o un modelo de embeddings dedicado)? | El doc 09 usaría el banco para embeddings en vez de la biblioteca local (hoy el camino alternativo declarado) | P3 | Rige el camino alternativo; el doc 09 ya lo declara |
| 4 | Las filas del lote del folio 011 §5 (GPU/piso de hardware, imagen/audio conceptual, perfil ACT-01, ratificación de Qwen/Ollama como medio, frase trunca del prompt) siguen con sus defaults | Presentadas en sesión sin respuesta aún | P3 | Siguen los defaults declarados en el folio 011 |

Sigue: entrega (commits, PRs y fusión por ciclo automático en ambos repos) y bitácora 04 de cierre ·
despachos abiertos: ninguno · insumos: folios 001–020, constancias de despacho/, evidencia 001–019 ·
si se corta acá, el expediente queda cerrado y sólo se invalida la entrega, que puede relanzarse.
