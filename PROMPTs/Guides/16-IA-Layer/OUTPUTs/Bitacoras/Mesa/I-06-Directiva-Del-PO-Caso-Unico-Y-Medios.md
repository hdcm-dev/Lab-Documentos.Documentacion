# I-06 — Directiva del PO: caso único y medios de prueba

> **Tipo**: directiva del PO, **vinculante** (2026-10-26). No se vota: la mesa la aplica y la usa como restricción dura del contrato de entrada.
> **Destinatarios**: toda la mesa, el plan de integración, los constructores de ejemplos y demo, la relectura integral.

---

## 1. Caso único: Movilidad Urbana

Palabras del PO, en paráfrasis: el borrador de agentes viene de otro proyecto privado y no se mezcla; el caso es Movilidad Urbana.

| ID | Restricción |
|---|---|
| RD-PO-1 | **El único caso práctico** de la guía, los ejemplos y la demo es **Movilidad Urbana** (Lab-E2E.WebBlazor: localidades, encuesta de transporte, sesiones), tomado de su ia-db y de su código (sólo lectura) |
| RD-PO-2 | **Nada de otros proyectos** entra a la guía, a los ejemplos, a la demo ni a la bitácora: ni dominio, ni arquitectura, ni stack concreto, ni nombres. Si un insumo trae ejemplos de otro proyecto, se toman sólo las ideas generales y se reilustran con Movilidad Urbana (ver [I-05](I-05-Insumo-Del-PO-Desarrollo-De-Agentes-En-NET.md)) |
| RD-PO-3 | **Los dominios inventados también se reemplazan.** Los dossiers N2 y N5 usan en sus snippets y preguntas un dominio genérico de «reclamos» que no existe en Movilidad Urbana (N2 §4 y P-*, N5 P7 y §4). No viene de otro proyecto, pero rompe la regla del caso único. Al redactar la guía, **todo snippet, pregunta guía y ejemplo usa entidades de Movilidad Urbana**: `Localidad`, `Provincia`, `RespuestaDeEncuesta`, medios de transporte, sesiones. Si una idea no encaja en ese dominio, la mesa decide si se reformula o se deja como explicación conceptual sin ejemplo |
| RD-PO-4 | La relectura integral verifica RD-PO-1 a RD-PO-3 con un barrido mecánico (términos de dominio ajenos) antes del cierre |

---

## 2. Medios de prueba disponibles

Palabras del PO: «si necesitás avanzar, o te turnás con los otros subagentes para usar el celular, o lanzás un emulador», y «construí la infraestructura que necesites, y comunicate con los subagentes en la gestión de los recursos».

| ID | Disposición |
|---|---|
| MD-1 | Para probar la demo en un cliente móvil (navegador del teléfono o la app MAUI de Movilidad Urbana, si la mesa decide incluirla) están disponibles un teléfono Android de prueba del PO (`<teléfono-de-prueba>`), por acceso remoto, y un **emulador Android** en contenedor |
| MD-2 | Los recursos compartidos (`<teléfono-de-prueba>`, emulador, servidor compartido, compilaciones pesadas) se usan **por turnos**, a través del gestor de turnos del laboratorio (privado). El protocolo lo mantiene el gestor y todo constructor o verificador que necesite un recurso lo pide por ahí; nadie lo toma por su cuenta |
| MD-3 | En el teléfono sólo se instalan o desinstalan **paquetes propios del ensayo**; las demás aplicaciones del teléfono no se tocan |
