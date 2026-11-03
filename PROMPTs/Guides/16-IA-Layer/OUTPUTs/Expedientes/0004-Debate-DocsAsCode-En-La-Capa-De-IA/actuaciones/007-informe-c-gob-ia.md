| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-03 |
| Autor | Comisión C-GOB-IA |
| Corrige | — |

Incorporado verbatim desde la ruta de trabajo del rol. Lo que sigue a esta línea, hasta el pase, es la pieza.

---
doc_type: informe
title: Informe de la comisión C-GOB-IA — gobernanza y documentación regulatoria de sistemas de IA, sostenida por Docs as Code
status: borrador
origin: ia-generated
confidence: media
owner: comisión C-GOB-IA, mesa de expertos a pedido del expediente 0004
last_review: 2026-11-03
audience: [presidencia de la mesa, refutador, jurado, PO]
---

# Informe de la comisión C-GOB-IA (expediente 0004)

**Secciones de `Conocimiento/Knowledge-Mesa-De-Expertos-A-Pedido.md` leídas:** §0, §2.2, §3.2, §3.3 y §4
(enteras, con la unidad de sección de §0). No cargué `Knowledge-Cadena-De-Consecuencias.md` §2: la carta no
lo pidió; lo declaro para el cruce del paso 10. Clase de objeto: **diseño de una norma o decisión** (§2.2):
cito fuentes externas con su número y no cito apartados de los que no estoy seguro.

**Mandato.** Qué documentación exigen los marcos de gobernanza de IA y cómo la sostiene Docs as Code.
**No-competencia.** No opino sobre recuperación (RAG), seguridad de prompts, métricas estadísticas ni
didáctica salvo en lo que tienen de *documento exigible*.

**Convención de citas.** La de los dos folios de las partes (`LD`, `LDD`, `G16`, `DG`, `LG`, `AIL`,
`EXP2`, `EXP3`, `DEC-GEO`, `DEC-SP`, `BENCH`). Lo que verifiqué contra el árbol va con «(verificado)».
El servicio privado va como `{servicio-privado}`.

## 1. Cómo resuelve la industria la cuestión, desde este mandato

### 1.1 La respuesta corta

En la industria regulada, **la «capa de IA» no tiene documentación propia separada de la del sistema**:
los marcos piden *información documentada* del sistema de IA como un todo (propósito, datos, modelo,
evaluación, riesgos, supervisión humana, registros de operación, cambios) y exigen que esa información
esté **controlada**: versionada, revisada, aprobada, disponible para quien corresponde y conservada.
Docs as Code no aparece nombrado en ninguna norma, pero es hoy la forma más barata de cumplir el
requisito de *control* de la información documentada, porque el repositorio da gratis versión, autoría,
revisión (PR), aprobación (merge) y trazabilidad entre documento y artefacto. La integración
metodológica, entonces, no es «Docs as Code dentro de la capa de IA», sino **la documentación exigida
del sistema de IA tratada como código**, con los artefactos de la capa (prompt, banco, validador,
modelo elegido, corridas) como piezas documentadas más.

### 1.2 Qué exige cada fuente

| Fuente | Qué documentación pide | Qué rasgo de Docs as Code la sostiene |
| --- | --- | --- |
| NIST, *AI Risk Management Framework (AI RMF 1.0)*, NIST AI 100-1, 2023 | Cuatro funciones: GOVERN (políticas, roles, responsabilidades, documentación de procesos), MAP (contexto, uso previsto, límites conocidos), MEASURE (métodos y resultados de evaluación documentados, incluido lo que no se pudo medir), MANAGE (decisión de despliegue, respuesta y seguimiento). La documentación y la trazabilidad atraviesan las cuatro | Plantillas con frontmatter (contexto y uso previsto), evaluaciones versionadas junto al código (MEASURE), ADR con condición de revisión y PR de puesta en uso (MANAGE) |
| NIST, *AI RMF: Generative AI Profile*, NIST AI 600-1, 2024 | Aplica las cuatro funciones a doce riesgos propios de la IA generativa; para este caso pesan *confabulation*, *information integrity*, *information security*, *data privacy* y *value chain and component integration* (modelos de terceros). Pide documentar procedencia de contenido, pruebas previas al despliegue y el origen de los componentes de terceros | Campo `origin` de procedencia, corridas rotuladas con modelo y digest, ficha del componente de terceros |
| ISO/IEC 42001:2023, *AI management system* | Cláusula 7.5, **información documentada** (estructura armonizada de las normas de sistemas de gestión): crear y actualizar con identificación, formato, revisión y aprobación; **controlarla** (disponibilidad, protección, distribución, acceso, control de cambios, conservación y disposición). Anexo A: controles sobre evaluación de impacto, ciclo de vida, datos, información para las partes interesadas y uso responsable (no verifiqué la numeración de los controles) | 7.5 es casi la definición de un repo con PR: identificación (ruta y `doc_type`), revisión y aprobación (review y merge), control de cambios (historia), acceso (visibilidad del repo y regla de entrega por audiencia) |
| Reglamento (UE) 2024/1689 (AI Act) | Para sistemas de alto riesgo: documentación técnica (artículo 11 y Anexo IV: descripción general, elementos y proceso de desarrollo, datos, supervisión humana, métricas y limitaciones, gestión de riesgos, cambios a lo largo del ciclo de vida, plan de seguimiento poscomercialización), registros automáticos (artículo 12), instrucciones de uso para el que despliega (artículo 13) y conservación de la documentación (artículo 18). Para todo sistema que interactúa con personas o genera contenido, obligaciones de transparencia (artículo 50). Alfabetización en IA (artículo 4) | El Anexo IV pide explícitamente **los cambios a lo largo del ciclo de vida**: es la historia del repo. Lo demás es una plantilla por sección del Anexo IV más una prueba de completitud |
| Mitchell, M. et al. (2019). «Model Cards for Model Reporting». *FAT\* '19* | Ficha del modelo: detalles, uso previsto, factores, métricas, datos de evaluación, datos de entrenamiento, análisis cuantitativos, consideraciones éticas, salvedades y recomendaciones | Un `doc_type` con esquema; sus métricas se generan desde la corrida, no se tipean |
| Gebru, T. et al. (2021). «Datasheets for Datasets». *Communications of the ACM*, 64(12) | Ficha del conjunto de datos: motivación, composición, recolección, preprocesamiento y etiquetado, usos, distribución, mantenimiento | Aplica al **banco de evaluación**, que es el único dataset que estas capas producen |
| Arnold, M. et al. (2019). «FactSheets: Increasing trust in AI services through supplier's declarations of conformity». *IBM Journal of Research and Development*, 63(4/5) | Declaración del proveedor del **servicio** de IA, no del modelo: propósito, desempeño, seguridad, procedencia | Es el antecedente directo de la «ficha por capacidad» que propone la Capa de IA |
| *System cards* (por ejemplo, OpenAI, *GPT-4 System Card*, 2023) | Documento del sistema desplegado —modelo más mitigaciones, políticas y evaluaciones— porque los riesgos son del sistema, no del modelo suelto | Mismo argumento que la ficha por capacidad |

### 1.3 Tres consensos que sí son de la industria

1. **Se documenta el sistema, no el modelo.** NIST AI 600-1 (cadena de valor), las *system cards* y las
   *FactSheets* coinciden: quien integra un modelo de terceros documenta lo que él controla (uso, prompt,
   mitigaciones, evaluación propia) y referencia la ficha del proveedor para lo demás.
2. **La documentación es un registro vivo atado al cambio.** El Anexo IV pide los cambios del ciclo de
   vida; 42001 7.5 pide control de cambios; NIST MANAGE pide revisar cuando cambia el contexto. Un
   documento que no se invalida cuando cambia su entrada no cumple ninguna de las tres.
3. **La aprobación humana de la puesta en uso es una decisión documentada distinta de la integración del
   código.** Es la supervisión humana del artículo 14 del AI Act para alto riesgo, y la función MANAGE de
   NIST para el resto.

### 1.4 Encuadre regulatorio de los dos casos (sin opinión jurídica)

- **Geometría** (repo público, `LG`): da pistas a estudiantes y no evalúa. El Anexo III del AI Act, punto 3
  (educación), alcanza sistemas que evalúan resultados de aprendizaje, deciden admisión o vigilan
  exámenes; una pista no hace nada de eso, así que el caso **no es de alto riesgo** por esa vía. Le
  aplica la transparencia del artículo 50 (que el estudiante sepa que el texto lo generó una IA) y
  conviene documentar el *razonamiento de no-alto-riesgo* como un ADR más: si mañana la IA califica, el
  ADR «deja de valer».
- **`{servicio-privado}`**: consulta en lenguaje natural sobre cifras para un operador. Tampoco cae en el
  Anexo III por lo que describen los folios. Le pesa más NIST AI 600-1 (*confabulation* e *information
  integrity*: la atribución falsa de `DEC-SP` es exactamente eso).
- En los dos, quien integra es *provider* o *deployer* del sistema, no del modelo de propósito general:
  las obligaciones del artículo 53 son del proveedor del modelo.

## 2. Contraste con lo que hicieron las dos sesiones

### 2.1 Coincide con la industria

| Práctica | Evidencia | Fuente con la que coincide |
| --- | --- | --- |
| ADR con «Deja de valer si» | `AIL/03-ADR.md`, seis ADR con esa fila (verificado) | NIST MANAGE; Anexo IV «cambios a lo largo del ciclo de vida» |
| Corrida con modelo y **digest** fijado y verificado antes de correr | `AIL/ensayos/pistas.py` aborta si el digest difiere (verificado) | NIST AI 600-1, procedencia de componentes; *model card*, «detalles del modelo» |
| Procedencia en frontmatter: `origin` ∈ {`human`, `ia-assisted`, `ia-generated`} y `confidence` obligatoria si no es humano | `DG/esquemas/` (verificado) | NIST AI 600-1, procedencia de contenido; artículo 50 del AI Act (marcar lo generado) |
| Banco, rúbrica y oráculo escritos antes de correr | `G16` §11.4, ADR-10 (citado por la Capa de IA) | NIST MEASURE |
| Puesta en uso como decisión separada del merge (IA apagada por defecto) | Folio Capa de IA §2.7; REQ-IA-15 | Supervisión humana, artículo 14 del AI Act; NIST MANAGE |
| Separar redactor y verificador, aprobación humana explícita en el PR | `EXP2/017` §5; `EXP2/290` | 42001 7.5 (revisión y aprobación) |
| Regla de entrega por audiencia en repo, build y servidor | `EXP3/399` §1 | 42001 7.5 (acceso y distribución controlados) |
| Rótulo honesto «borrador ensayado, no probado» | `EXP3/208` §9, `EXP3/209` §3 | NIST MEASURE: documentar lo que no se pudo validar |
| `G16` cita NIST AI 600-1 en su anexo de referencias | `G16` REF-06 (verificado) | — |

### 2.2 Falta

| P | Falta | Evidencia de la falta | Fuente que la pide |
| --- | --- | --- | --- |
| P1 | **Ficha de sistema por capacidad** (no por modelo). Hoy está repartida entre especificación, ADR y corrida, como reconoce la Capa de IA §2.3 | Búsqueda en `AIL/` y `G16`: ninguna *model card*, *system card* ni ficha equivalente (verificado: sólo REF-06 aparece) | Mitchell et al. 2019; *system cards*; Arnold et al. 2019 |
| P1 | **Datasheet del banco de evaluación** (motivación, composición, quién lo escribió, si incluye casos trampa, mantenimiento) | `AIL/ensayos/banco.json` existe sin ficha (verificado) | Gebru et al. 2021 |
| P1 | **Invalidación automática**: ninguna regla marca vencida una decisión cuando cambia prompt, modelo, opciones o banco. Lo vigila una persona | Capa de IA §2.2, último punto | 42001 7.5 (control de cambios); NIST MANAGE |
| P1 | **Registro de quién firmó y si fue humano** | Capa de IA §2.6; `AIL/05-Checklist-Completitud.md` firmado por mesa no humana | 42001 7.5 (aprobación); artículo 14 del AI Act |
| P2 | **Registro de riesgos e impacto** por capacidad (qué daño, a quién, mitigación, riesgo residual aceptado y por quién). Los hallazgos (pistas falsas que pasan el filtro, atribución falsa) existen pero como hallazgos de mesa, no como riesgo residual aceptado | `DEC-GEO`, `DEC-SP` (citados, fuera de repo) | NIST MAP y MANAGE; 42001, evaluación de impacto del Anexo A; ISO/IEC 42005:2025 |
| P2 | **Aviso de transparencia al usuario final** como documento con traza al texto que ve el estudiante u operador | No encontré la pieza en `AIL/` | Artículo 50 del AI Act |
| P2 | **Política de conservación**: qué corridas, registros y salidas se conservan y cuánto | Capa de IA §3 pregunta 3 lo deja abierto | 42001 7.5 (conservación y disposición); artículo 18 del AI Act como referencia de práctica |
| P3 | **Inventario de sistemas de IA** del repo (qué capacidades existen, estado, dueño) | — | NIST GOVERN (inventario) |

### 2.3 Sobra (o pesa más de lo que la gobernanza pide)

- **Las 13 familias de controles de DocsAsCode aplicadas por igual a los documentos de la capa.** Para
  gobernanza no hace falta: lo que se exige es completitud de la ficha, vigencia y firma. Lo demás es
  calidad editorial, valiosa pero no exigible. No propongo quitarla; propongo no bloquear la capa por ella.
- **Pedir ensayo con aplicador ciego como condición de publicación del conocimiento de la capa**
  (DocsAsCode propuesta 7). Ninguna fuente lo pide; es buena práctica de I+D y su resultado honesto ya
  quedó en `EXP3/208`. Como compuerta de gobernanza sobra; como evidencia de MEASURE, suma.
- **Campos de procedencia duplicados** (`confidence` y `confidence_nota` de `G16`, más el Anexo H). Basta
  `origin`, `confidence`, `revisado_por` y `corrida`.

## 3. Respuestas

### 3.1 A las siete preguntas de DocsAsCode

1. **¿Dónde vive el filtro por `delivery`?** La fuente de verdad es **el sistema documentador**: 42001 7.5
   pone el control de acceso y distribución sobre la información documentada, no sobre su consumidor. La
   capa de IA aplica el mismo filtro como segunda barrera y **nunca** como fuente; si las dos divergen,
   manda el documentador y la divergencia es un hallazgo.
2. **¿Qué identidad usa la capa para recuperar?** La del usuario final, y la capa no puede tener una
   identidad propia con más alcance. Se prueba con la prueba negativa que ya propone DocsAsCode, y se
   documenta como requisito de la ficha de capacidad («identidad de recuperación: la del operador»).
3. **¿Lo que escribe un agente cuenta como fuente antes de la aprobación humana?** No. Entra con
   `origin: ia-generated`, `revisado_por: ninguno | agente-independiente` y **no se indexa ni habilita
   puesta en uso** hasta `revisado_por: humano`. Es la regla de procedencia de NIST AI 600-1 y la
   aprobación de 42001 7.5.
4. **¿`AGENTS.md` y equivalentes son documentación o configuración?** Son **información documentada
   controlada** en el sentido de 42001 7.5, porque gobiernan el comportamiento del sistema: llevan
   frontmatter, dueño, `last_review` y PR con revisión, como cualquier documento; además, como
   configuración, no se distribuyen por `delivery` a ninguna audiencia externa.
5. **¿Qué bloquea desde el principio?** Desde gobernanza, cuatro controles deterministas, sin «avisa»:
   (a) prueba negativa de no publicación; (b) canario de contexto; (c) prompt del código igual a su
   ficha; (d) **ninguna puesta en uso sin ficha de capacidad completa y firma humana**. El resto nace en
   «avisa» con fecha.
6. **¿Cómo se ensaya con aplicador ciego cuando el resultado son respuestas de un modelo?** Para
   gobernanza, el aplicador ciego no ensaya al modelo: ensaya **la ficha**. Se le da sólo la ficha de
   capacidad y se le pide decidir si el sistema puede ponerse en uso; el oráculo es la decisión que tomó
   la persona responsable con toda la evidencia; umbral: coincidencia en 100 % de los casos de un banco
   pequeño de fichas (con y sin defectos sembrados). Si una ficha no le alcanza a un lector sin contexto
   para decidir, no le alcanza a un auditor.
7. **¿Los cuatro P0 de K 1.4 se cierran antes de integrar la capa?** **Se integra sobre el borrador,
   rotulado**, y los P0 pasan a deuda declarada con fecha. Ninguna norma exige perfección antes de
   documentar; 42001 7.5 exige que el estado (versión, aprobación) sea visible. Condición: el rótulo
   «borrador» de K impide la puesta en uso de cualquier capacidad cuya ficha dependa de un P0 abierto.

### 3.2 A las preguntas de la Capa de IA que tocan este mandato

1. **¿La ficha de capacidad es un `doc_type` del documentador con esquema en `DG`, o forma libre en `AIL/`?**
   **`doc_type` nuevo, `ficha-capacidad-ia`, con esquema en `DG`**, y la instancia vive junto a la capa
   (`AIL/` en Geometría). Campos mínimos, tomados de Mitchell et al. 2019 y del Anexo IV recortado al
   caso: capacidad y uso previsto; usos fuera de alcance; modelo (nombre o código) y digest; opciones
   fijadas; prompt (ruta y huella); banco (ruta a su datasheet); última corrida (ruta, k/M e IC95);
   métrica y su versión; límites observados y riesgo residual aceptado; transparencia al usuario;
   identidad de recuperación; «deja de valer si»; `revisado_por`; decisión de puesta en uso (sí/no,
   quién, fecha).
2. **(Dueño del arnés)** No es de mi mandato, salvo esto: la versión del arnés usada **va en la corrida**,
   porque sin ella la corrida no es reproducible (NIST MEASURE).
3. **¿La corrida es documento o evidencia?** **Las dos, en dos piezas**: las salidas crudas son evidencia
   inmutable con SHA-256 (conservación de 42001 7.5); el resumen es documento con frontmatter, que cita la
   huella de la evidencia y se recalcula sin modelo. Es la misma separación que ya hace §2.3 de la norma de
   la mesa.
4. **¿Cómo se firma la revisión humana si el PO delegó en mesas de agentes?** La delegación cubre
   **integrar** (merge); **no cubre la puesta en uso**. La firma de un agente independiente se declara
   como tal y deja D-23 en «Parcial»; eso es correcto y **no** es un estado permanente: se cierra cuando el
   PO firma la decisión de puesta en uso, una sola firma humana por capacidad y por versión de la ficha.
   Es el mínimo de supervisión humana que piden el artículo 14 del AI Act y NIST MANAGE.
5. **¿El nombre del modelo puede ir en un repo público junto con la decisión de un producto privado?**
   **No.** En el repo público, el modelo se nombra sólo en la ficha del producto público. La ficha admite
   `modelo: <nombre>` o `modelo_codigo: <código>`, con la tabla de códigos en el repo privado; una ficha
   pública nunca menciona la decisión del privado. La norma propia del privado manda en su información
   documentada (42001 7.5, acceso).
6. **(AIL-n en `DG` o en la guía 16)** Desde gobernanza: los controles **de completitud y vigencia de la
   ficha** (esquema, «deja de valer si» vencido, firma) van en `DG`, porque el documento es del corpus; los
   que comparan con el código de la capa van en `G16/tools`.
7. **¿Dónde se documenta la carga cruzada de un servidor compartido sin escribir topología?** En una ficha
   del **componente de terceros compartido** (NIST AI 600-1, cadena de valor) con alias del servidor,
   capacidades que lo usan, supuestos de permanencia, cola y paralelismo, y el «deja de valer si»; cada
   ficha de capacidad la referencia por alias. La topología queda en el secreto del despliegue.

## 4. Lo que revisé y está bien

- El esquema de `DG` exige `confidence` cuando `origin` no es `human` (verificado en `DG/esquemas/`): la
  base de procedencia ya está y no hay que rehacerla.
- `DG/README.md` documenta AI-1 a AI-5 con su modo (bloquea o avisa) y el motivo de que AI-3 sólo avise
  (verificado): es exactamente el «control con criterio de promoción escrito» que pide la gobernanza.
- `AIL/03-ADR.md` tiene «Deja de valer si» en todos sus ADR (verificado), y la corrección de la 009 por la
  010 muestra que la condición funciona.
- `AIL/ensayos/pistas.py` fija y verifica el digest del modelo antes de correr (verificado): la corrida es
  reproducible en lo que importa a la procedencia.
- Las dos partes declaran lo que no verificaron (numeración del Anexo A de 42001; RAG sin experiencia;
  firma no humana): eso es información documentada honesta y no hay que corregirlo.
- La separación entre fusionar y poner en uso (IA apagada por defecto) es la decisión correcta en un repo
  donde main despliega.

Sigue: incorporar el informe siguiente · presidencia de la mesa
