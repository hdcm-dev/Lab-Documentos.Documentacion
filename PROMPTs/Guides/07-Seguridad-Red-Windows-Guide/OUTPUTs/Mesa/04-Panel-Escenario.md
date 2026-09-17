# Mesa evaluadora — Ciclo 2 sobre el escenario testigo

**Fecha:** 2026-09-17
**Objeto:** `Escenario/Escenario-Testigo.md` + consistencia con las salidas ya presentes en el entregable v1.1
**Disparador del ciclo:** el usuario levanta la restricción "salidas ilustrativas" y pide derivarlas de un escenario coherente. Cambio de alcance menor y controlado (no reabre decisiones cerradas).

---

## 1. Convocatoria (delta respecto del ciclo 1)

- Se reconvoca el **núcleo** + **E-SeguridadWin** (coherencia técnica del ataque) + **E-Didáctica** (que el caso enseñe) + **Lector-novato**.
- **Nuevo rol formal/matemático (convocatoria automática):** el escenario introduce una **línea de tiempo con relaciones causales y de orden** (evento A antes que B, borrado que elimina lo previo). Señal presente ⇒ entra sin discusión, para verificar que la cronología no tenga imposibles.
- E-Edición y AH-001: no se reconvocan (sin señal nueva; el escenario no agrega material de doble uso).

## 2. Chequeo de coherencia del escenario (rol formal + E-SeguridadWin)

| Chequeo | Resultado |
|---|---|
| ¿La creación de `svc_update` (03:16) es posible con la cuenta `soporte`? | OK: `soporte` tiene admin local (vicio declarado §2), habilita 4720/4732 |
| ¿El acceso RDP desde IP pública es posible? | OK: RDP expuesto (vicio §2) |
| ¿El 4624 tipo 10 desde `203.0.113.14`? | OK: tipo 10 = RDP; IP externa RFC 5737 |
| ¿Coherencia del borrado total con lo que se ve después? | Ver H-11 |
| ¿RecordId salta o se reinicia? | Ver H-12 |
| ¿PID 9310 aparece igual en procesos, servicio y conexión? | OK, consistente en §6.1/§6.4/§7.2 |
| ¿Rangos IP: interno RFC 1918, externo RFC 5737? | OK en el escenario; ver H-13 sobre la guía |

## 3. Hallazgos (consistencia escenario ↔ entregable v1.1)

| ID | Sev | Evidencia | Hallazgo |
|---|---|---|---|
| **H-11** | S2 | E3 | El entregable v1.1 muestra en §5.3 eventos 4624/4720 como "20 más recientes" en el equipo local, pero el escenario borra el log a las 03:40, así que esos eventos **no pueden** estar en el log local. Deben mostrarse como provenientes del **colector WEF**, o el caso se autocontradice. |
| **H-12** | S2 | E2 | §5.5.1 enseña el "salto de RecordId" como señal. En un **borrado total** (el del escenario) el RecordId se **reinicia** (queda bajo), no "salta". El salto corresponde a **borrado de registros individuales**, otra técnica. Hay que distinguir ambos casos para no confundir al lector. |
| **H-13** | S2 | E4 | Varias salidas de la guía usan IPs externas fuera de rango de documentación (`185.230.62.14`, `40.126.32.68`). Norma de material didáctico: usar RFC 5737 (`203.0.113.0/24`). Alinear con el escenario. |
| **H-14** | S3 | E2 | Fechas/horas de las salidas de la guía (`2026-09-17 03:14`) deben pasar a la fecha del incidente del escenario (`2026-09-15`), y las cuentas de ejemplo (`jperez`) a las del escenario (`soporte`, `svc_update`). |
| **H-15** | S3 | E3 | Falta en la guía una sección que **presente el escenario testigo** y explique el mecanismo (una historia coherente, no salidas sueltas); sin ella el lector no sabe que las salidas están todas conectadas. |
| **H-16** | S3 | E3 | El aviso del encabezado ("no se ejecutaron / valores de ejemplo") quedó desactualizado: ahora las salidas derivan de un escenario coherente y hay que decirlo, manteniendo la honestidad de que es sintético. |

Verdicto del jurado: **H-11..H-16 PROCEDEN** (5-0 en H-11/H-12/H-13/H-16; 4-1 en H-14/H-15). Ninguno reabre decisión cerrada; es alineación pedida por el usuario.

## 4. Parches

| Parche | Cubre | Cambio |
|---|---|---|
| P-07 | H-15, H-16 | Nuevo §2.9 "El escenario testigo de esta guía" + reescritura del aviso del encabezado |
| P-08 | H-11 | En §5.3, etiquetar la salida como proveniente del colector WEF; agregar nota de que el log local arranca en el 1102 |
| P-09 | H-12 | Reescribir §5.5.1: distinguir borrado total (RecordId se reinicia) de borrado parcial (RecordId salta); el escenario es total |
| P-10 | H-13 | Reemplazar IPs externas por `203.0.113.14` (RFC 5737) en §7.2 y donde aparezcan |
| P-11 | H-14 | Alinear fechas a 15/09/2026 y cuentas a `soporte`/`svc_update` en §5.3, §5.5, §6.6 |
| P-12 | H-15 | Anexo D: referencia al escenario completo (vive en OUTPUTs) resumido en la guía |

## 5. Verificación (tras aplicar)
- grep: no debe quedar `185.230.62.14` ni `40.126.32.68` en el entregable.
- grep: `203.0.113.14` presente en §7.2.
- §5.3 debe contener la palabra "colector" en su nota.
- §5.5.1 debe contener "se reinicia" y "borrado parcial".
- Existe §2.9 y Anexo D.
