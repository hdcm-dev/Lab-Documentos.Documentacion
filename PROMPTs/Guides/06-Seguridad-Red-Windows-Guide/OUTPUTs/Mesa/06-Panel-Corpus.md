# Mesa evaluadora — Ciclo 3 sobre el corpus de logs

**Fecha:** 2026-09-17
**Objeto:** `Escenario/Corpus-Logs.md` + una nueva sección pedida por el usuario: "qué mirar cuando el sistema está comprometido, qué ver, qué pasa cuando borran los logs y **cómo darse cuenta de que fue intencional**".
**Disparador:** ampliación de alcance pedida por el usuario (ejemplos de logs comentados + intencionalidad del borrado). Controlada, no reabre decisiones.

## 1. Convocatoria (delta)
- Núcleo + **E-SeguridadWin** (fidelidad de los renders y de los campos) + **E-Didáctica** (que "qué leer" enseñe).
- **Agente ad hoc AH-002 — Analista forense / DFIR**: señal = se introducen artefactos de log renderizados y criterios de intencionalidad, competencia que excede la seguridad de red general.

```yaml
agente_ad_hoc:
  id: AH-002
  nombre: Analista forense digital (DFIR) — logs de Windows
  señal_que_lo_justifica: { descripción: "renders de eventos y criterios para distinguir borrado intencional de accidental", ubicación: "Corpus-Logs.md §7-8" }
  pregunta_que_responde: "¿Los renders son fieles y los criterios de intencionalidad son correctos y no producen falsos positivos?"
  competencia: "estructura de eventos evtx, subestados de logon, semántica del 1102/104/1100/4719; NO opina de didáctica ni de redacción"
  evidencia_admisible: [E2, E4]
  tope_hallazgos: 5
  se_disuelve_cuando: cierre del ciclo
```

## 2. Hallazgos

| ID | Sev | Ev | Hallazgo |
|---|---|---|---|
| **H-17** | S2 | E4 | (AH-002) Falta la señal más importante de intencionalidad: distinguir que **1102/104 son acciones explícitas de vaciado** (no se generan por rotación ni por disco lleno). Sin eso, el lector no sabe por qué un 1102 "ya es" intencional. Debe ser el eje de la sección de intencionalidad. |
| **H-18** | S2 | E4 | (AH-002) El corpus muestra el 4625 con subestado `0xC000006A` pero no explota su valor diagnóstico frente a `0xC0000064` (usuario inexistente). Es justamente lo que distingue *password spraying* de *brute force sobre cuenta válida*. Llevarlo a la guía. |
| **H-19** | S2 | E3 | (E-SeguridadWin) La guía v1.2 detecta el borrado (§5.5) pero **no reúne en un solo lugar** la pregunta del usuario: "qué mirar cuando estás comprometido / cómo saber que el borrado fue intencional". Hace falta una sección explícita §5.5.3. |
| **H-20** | S3 | E3 | (E-Didáctica) Los renders comentados son muy valiosos pero viven en OUTPUTs; el lector de la guía no los ve. Debe existir un Anexo E con una galería de logs comentados. |
| **H-21** | S3 | E4 | (AH-002) Falta nombrar las **causas legítimas** de un log vacío/pequeño (rotación por tamaño/retención, reinstalación, migración) para que la intencionalidad se afirme por descarte, no por reflejo. Evita el falso positivo. |
| **H-22** | S3 | E2 | (E-Didáctica) Conviene un checklist accionable "sistema comprometido: los primeros 10 minutos" que ordene qué mirar y en qué orden, enlazando a los capítulos. |

Verdicto del jurado: **H-17..H-22 PROCEDEN** (5-0 en H-17/H-18/H-19; 4-1 en H-20/H-21/H-22).

## 3. Parches

| Parche | Cubre | Cambio en el entregable |
|---|---|---|
| P-13 | H-17, H-21 | Nueva §5.5.3 "Cómo saber que el borrado fue intencional": 1102/104 como acción explícita + tabla de señales de intencionalidad + causas legítimas a descartar |
| P-14 | H-18 | Ampliar §5.4 con la lectura del subestado del 4625 (spraying vs brute force) |
| P-15 | H-19, H-22 | Nueva §6.8 (renumerar) o §4.7 "Sistema comprometido: qué mirar primero" — checklist de los primeros 10 minutos. Se ubica como §4.7 (método) |
| P-16 | H-20 | Nuevo Anexo E "Galería de logs comentados" (subconjunto del corpus, con 'qué leer') |
| P-17 | — | Actualizar índice, versión 1.3, y referencia cruzada desde §5.5 al corpus |

## 4. Verificación posterior
- Existe §5.5.3 con "acción explícita" y una tabla de intencionalidad.
- Existe §4.7 con checklist numerado.
- Existe Anexo E con al menos los eventos 4624, 4625, 1102, 7045 renderizados.
- §5.4 menciona `0xC000006A` vs `0xC0000064`.
- Índice y versión actualizados; fences balanceados.
