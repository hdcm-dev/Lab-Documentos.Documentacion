# Mesa evaluadora — Registro de convocatoria

**Fecha:** 2026-09-17
**Artefacto bajo revisión:** `Beginning-Security-Windows-Network-Guide.md` (guía de estudio)
**Marco:** `/IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §5.1

---

## 1. Barrido de señales (§5.1.b)

Inventario, no juicio. Cada señal citada con su ubicación en el prompt de origen.

| Señal observable | Ubicación en el prompt | Especialidad que activa |
|---|---|---|
| "persona sin conocimientos de redes y sistemas operativos" | Solicitudes §1 | Didáctica |
| "guía debe servir definiciones, ejemplos… lenguaje claro sin perder el tecnicismo" | Solicitudes §1 | Edición bibliográfica |
| "sospecho intrusión y están borrando los logs… fugas de seguridad" | Contexto | Seguridad informática (redes Windows) |
| "comandos que se puedan probar y… resultados esperados" | Solicitudes §1 | Verificación / QA (núcleo) |
| "hacer pentesting… herramientas de la industria… reproducir un pentesting" | Solicitudes §1 | Doble uso / encuadre legal-ético |
| "No inventar información… evidencia verificable" | Reglas | Verificación / QA (núcleo) |
| "gráficos mermaid… organizados en secciones jerárquicas con índices" | Reglas | Implementador ingenuo (núcleo) |
| "Aplicar UX-UI-Guide.md" | Reglas | Edición bibliográfica |

---

## 2. Voto de composición (§5.1.c)

Los 5 jueces votan por especialidad. Mayoría simple; empate ⇒ se convoca.

### 2.1 Núcleo permanente (se convoca siempre)

| Rol | Estado |
|---|---|
| Requisitos | CONVOCAR (automático) |
| Verificación / QA | CONVOCAR (automático) |
| Implementador ingenuo | CONVOCAR (automático) — aquí opera como "lector novato": ¿puede seguir la guía sin preguntar nada? |
| Abogado del diablo | CONVOCAR (automático) |

### 2.2 Catálogo variable

| Rol propuesto | Voto | Resultado | Motivo |
|---|---|---|---|
| **E-Didáctica** (experto en didáctica) | 5-0 | CONVOCAR | Pedido explícito del prompt; el lector no tiene base |
| **E-Edición** (edición de material bibliográfico) | 5-0 | CONVOCAR | Pedido explícito; hay norma de estilo heredada (APA 7, UX-UI-Guide) |
| **E-SeguridadWin** (seguridad en redes Windows) | 5-0 | CONVOCAR | Es el dominio; sin él no hay corrección técnica posible |
| **Seguridad y privacidad** (catálogo) | 5-0 | Cubierto por E-SeguridadWin | Se fusiona, no se duplica |
| **Cumplimiento / normativa** | 3-2 | NO_CONVOCAR | El caso es formativo, no un dictamen legal; se cubre con el agente ad hoc de doble uso, más acotado |

### 2.3 Agente ad hoc (§4.1.3)

El prompt pregunta si hace falta un experto más. La mesa determina que **sí**: el tratamiento de pentesting
introduce contenido de doble uso que ninguno de los tres expertos pedidos tiene en su mandato.

```yaml
agente_ad_hoc:
  id: AH-001
  nombre: Especialista en ética, doble uso y encuadre legal de seguridad ofensiva
  señal_que_lo_justifica:
    descripción: "La guía incluye pentesting con herramientas ofensivas reales para un lector principiante"
    ubicación: "Solicitudes §1, párrafo 2"
  pregunta_que_responde: >
    ¿El material ofensivo está encuadrado de modo que forme criterio defensivo sin
    convertirse en un recetario aplicable sin autorización?
  competencia: >
    Autorización, alcance, doble uso, minimización de daño, encuadre de laboratorio.
    NO opina sobre la corrección técnica de los comandos (eso es de E-SeguridadWin)
    ni sobre la claridad didáctica (E-Didáctica).
  evidencia_admisible: [E2, E3, E4]
  tope_hallazgos: 5
  se_disuelve_cuando: cierre del ciclo o retiro de la sección de pentesting
```

---

## 3. Composición final del panel

- **Núcleo:** Requisitos, Verificación/QA, Lector novato (implementador ingenuo), Abogado del diablo.
- **Variables:** E-Didáctica, E-Edición, E-SeguridadWin.
- **Ad hoc:** AH-001 (ética/doble uso).
- **Descartados con motivo:** Cumplimiento/normativa (3-2, cubierto por AH-001 de forma más acotada).
- **Postergados por cupo:** ninguno (4 núcleo + 4 variables/ad hoc = dentro del techo de 5 variables).

**Jurado:** los 5 fijos por función (evidencia, impacto, costo-beneficio, coherencia histórica, riesgo).

---

## 4. Cuándo actúa la mesa

Conforme al marco, el panel trabaja **a ciegas sobre el entregable una vez redactado** (§5.2). Este registro
queda cerrado; el resultado del panel se documenta en `02-Panel-Veredictos.md` tras la primera redacción.
