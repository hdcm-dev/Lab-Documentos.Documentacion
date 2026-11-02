# I-03 — Insumo del PO: temario «AI Engineering: construye y despliega productos con IA»

> **Tipo**: insumo para la mesa. El PO lo entregó el 2026-10-26 («ahí tenés más para trabajar»).
> **Pieza**: [I-03-Temario-AI-Engineering.png](I-03-Temario-AI-Engineering.png): captura de un video de presentación (minuto 0:40 de 3:22), con el temario de un programa de LIDR («LIDR – Desarrollo potenciado por IA»).
> **Destinatarios**: especialistas de contenido y el plan de integración.
> **Núcleos afectados**: N0, N1, **N3 (aparece un tema nuevo: CAG)**, N4, N5.
> **Relación**: continúa [I-02](I-02-Insumo-Del-PO-Recorrido-AI-Engineer.md). Mismo criterio de clasificación.

---

## Índice

- [1. Clasificación](#1-clasificación)
- [2. Transcripción](#2-transcripción)
- [3. Lectura y cruce con los núcleos](#3-lectura-y-cruce-con-los-núcleos)
- [4. Tema nuevo: CAG (Cache-Augmented Generation)](#4-tema-nuevo-cag-cache-augmented-generation)
- [5. Propuestas de la presidencia a la mesa](#5-propuestas-de-la-presidencia-a-la-mesa)
- [6. Lo que la mesa decide](#6-lo-que-la-mesa-decide)

---

## 1. Clasificación

Es **fuente de forma y de cobertura, no de contenido ni citable**, igual que I-02. La guía no nombra el programa ni copia sus títulos.

Dato de procedencia: la imagen de entrada `INPUTs/AI-Layer.png` lleva la marca «L1DR» arriba a la derecha, y esta captura muestra el logo y el nombre del canal «LIDR – Desarrollo potenciado por IA». Por lo que se ve en las dos imágenes, la de entrada viene del mismo autor. Esto ajusta lo que N1 dejó como «no pude confirmar quién es LIDR»: ahora la autoría **visible** está identificada. Qué es LIDR como organización sigue **sin verificar**, y la guía no lo necesita.

---

## 2. Transcripción

«AI Engineering: Construye y despliega productos con IA» — seis módulos:

1. Fundamentos de productos con IA
2. Arquitectura CAG
3. Data-driven AI
4. Arquitectura RAG
5. Orquestación de agentes
6. Despliegue y puesta en producción

---

## 3. Lectura y cruce con los núcleos

Lectura de la presidencia, **criterio propio** (sólo se ven títulos):

| Módulo | Cobertura actual | Brecha |
|---|---|---|
| 1. Fundamentos de productos con IA | N0 (escenarios), N1 (conceptos) | **Mirada de producto**: cuándo la IA aporta valor y cuándo no, cómo se mide ese valor, qué cambia en el producto cuando la respuesta no es determinista. Hoy los núcleos miran la técnica, no el producto |
| 2. Arquitectura CAG | **ninguno** | Tema nuevo, ver §4 |
| 3. Data-driven AI | parcial en N3 (ingesta) y N5 (evaluación) | El título es ambiguo y **no se interpreta más allá de lo que dice**. Lectura posible: los datos propios como insumo de la capa de IA (calidad, preparación, conjuntos de evaluación, realimentación). La mesa decide si se trata y con qué alcance, siempre con fuentes |
| 4. Arquitectura RAG | N3 | Cubierto |
| 5. Orquestación de agentes | N4 | Cubierto; ver I-01 y PR-5 de I-02 |
| 6. Despliegue y puesta en producción | parcial en N5 (operación, local vs nube, Aspire) | El despliegue no está planteado como sección visible: contenedores, configuración del endpoint y del modelo por ambiente, secretos, modelo local o servicio gestionado, observabilidad en producción. Corresponde a la capa Infrastructure de la imagen |

**El orden del temario sugiere una escalera de estrategias de contexto**: CAG (todo el conocimiento entra al contexto) → RAG (se recupera sólo lo relevante) → agentes (el modelo decide qué buscar y qué hacer). Es la misma lógica de «empezar por lo más simple» que PR-4 y PR-5 de I-02 aplican a los agentes, ahora aplicada al conocimiento.

---

## 4. Tema nuevo: CAG (Cache-Augmented Generation)

**Fuente primaria verificada (E-PO-7)**: Chan, Chen, Cheng y Huang, «Don't Do RAG: When Cache-Augmented Generation is All You Need for Knowledge Tasks», arXiv 2412.15605, publicado el 2024-12-20 (consultado en la API de arXiv el 2026-10-26).

Lo que esta presidencia afirma hasta ahora es sólo esto: el término existe, tiene un paper de origen identificado y el título plantea CAG como alternativa a RAG para tareas de conocimiento. **Todo lo demás está sin investigar** y lo tiene que cubrir un dossier complementario con verificación adversarial:

- Definición según el paper: precargar el conocimiento en el contexto y reutilizar la caché KV calculada, en lugar de recuperar por consulta. Hay que confirmarla con la lectura del paper.
- Condiciones en las que conviene CAG o RAG: tamaño del corpus contra ventana de contexto, frecuencia de cambio de los datos, latencia, costo.
- Soporte real en .NET y en los proveedores:
  - si `Microsoft.Extensions.AI` expone algo para caché de prefijos o de prompts;
  - el *prompt caching* de los proveedores en la nube;
  - lo que hace Ollama: reutilización de la caché KV del prefijo con `keep_alive`, y su límite de contexto por defecto de 4096 que ya registró N5 (F17).
- Si es viable con el servidor Qwen de la LAN: el contexto efectivo lo mide el sondeo del entorno (`Sondeo-Entorno.md`).
- Relación con el middleware de caché de respuestas de M.E.AI (`UseDistributedCache`). Son cosas distintas y la guía no debe confundirlas: una guarda **respuestas**, la otra el **cálculo del contexto**.

---

## 5. Propuestas de la presidencia a la mesa

Continúan la numeración de I-02.

| ID | Propuesta | Núcleo | Esfuerzo |
|---|---|---|---|
| PR-8 | **Agregar CAG** como estrategia de contexto, con un dossier complementario (investigación + verificación adversarial) antes de redactar. En la guía, como primer escalón de una **escalera de estrategias de conocimiento**: prompt con contexto fijo → CAG → RAG → RAG con agentes, cada una con su criterio de elección. Si se valida, sumar un ejemplo chico que compare CAG y RAG sobre el mismo corpus de Movilidad Urbana, con tiempos medidos contra el servidor Qwen | N3 (o N3 bis) | medio |
| PR-9 | Sumar a N1 o N0 una **mirada de producto**: cuándo la IA aporta valor, qué cambia al diseñar con respuestas no deterministas y cómo se define el éxito (métrica de negocio, no sólo calidad del modelo). Con fuentes; lo que sea criterio propio se declara | N0/N1 | bajo |
| PR-10 | Decidir el tratamiento de **«datos para la IA»**: calidad y preparación de los datos propios, conjuntos de evaluación y realimentación. Sólo con fuentes verificables. Si no hay fuentes de peso, queda fuera de alcance, registrado | N3/N5 | medio |
| PR-11 | Convertir el **despliegue y la puesta en producción** en una sección visible, atada a la capa Infrastructure de la imagen: contenedores, configuración por ambiente, secretos, modelo local o gestionado, observabilidad y evaluación continua. La demo muestra el camino mínimo, que es la ejecución en contenedor con el endpoint configurable | N5 | medio |
| PR-12 | Usar el orden «fundamentos → estrategias de conocimiento → agentes → producción» como **candidato de columna vertebral** de la guía, para combinarlo con el orden de lo general a lo particular del Profile y con la escalera de agentes de PR-5 | Plan | bajo |

---

## 6. Lo que la mesa decide

1. Si PR-8 entra: en ese caso se convoca la investigación complementaria de CAG antes de la redacción.
2. Cuáles de PR-9 a PR-12 se aplican y cómo cambian el índice de la guía.
3. Cómo se integran con I-01 (marco de N4) e I-02 (tres niveles de ejemplos, «¿un agente o varios?»).
4. Registrar lo que se descarta, con su motivo.

### Evidencia

| ID | Comando | Resultado |
|---|---|---|
| E-PO-7 | `curl "https://export.arxiv.org/api/query?id_list=2412.15605"` y `https://arxiv.org/abs/2412.15605` | Título «Don't Do RAG: When Cache-Augmented Generation is All You Need for Knowledge Tasks»; publicado 2024-12-20T06:58:32Z; autores Brian J Chan, Chao-Ting Chen, Jui-Hung Cheng, Hen-Hsen Huang |
| E-PO-8 | `grep -i "cache-augmented\|CAG" Nucleos/*.md` | Sin coincidencias. N5 sólo menciona `OLLAMA_KV_CACHE_TYPE` y el contexto por defecto de 4096 (F17) |
