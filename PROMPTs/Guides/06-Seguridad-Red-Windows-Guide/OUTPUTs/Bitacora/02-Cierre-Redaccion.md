# Bitácora 02 — Cierre de redacción y ciclo de mesa

**Fecha:** 2026-09-17

## Estado
- Entregable: `Beginning-Security-Windows-Network-Guide.md` v1.1 — **completo y aprobado** por la mesa (ciclo 1).
- 1268 líneas; 12 capítulos + 3 apéndices; 5 diagramas mermaid; 7 citas con entrada en bibliografía.

## Núcleos → capítulos (trazabilidad cumplida)
NC-01→§2, NC-02→§3, NC-03→§4, NC-04→§5, NC-05→§6, NC-06→§7, NC-07→§8, NC-08→§9, NC-09→§10, NC-10→§11, NC-11→§12.

## Ciclo de mesa
- Convocatoria: `Mesa/01-Registro-Convocatoria.md` (núcleo + 3 expertos pedidos + AH-001 ad hoc de doble uso; se determinó que SÍ hacía falta el experto adicional).
- Panel/veredictos/parches: `Mesa/02-Panel-Veredictos.md` (10 hallazgos, 7 procedentes, 6 parches).
- Cierre: `Mesa/03-Cierre.md`.

## Pendiente
- Ninguno bloqueante. Deuda declarada menor (H-07, H-01) en el cierre.

---

## Adenda 2026-09-17 (tarde) — Escenario testigo (ciclo 2)
- El usuario levantó la restricción de "salidas ilustrativas" y pidió derivarlas de un escenario hipotético típico, con la mesa auditándolo como mecanismo de no-inventar.
- Nuevo fixture: `Escenario/Escenario-Testigo.md` (servidor de archivos CONTOSO comprometido; vicios de administración; línea de tiempo 15/09; salidas canónicas).
- Mesa ciclo 2: `Mesa/04-Panel-Escenario.md` (+ rol formal por la cronología), 6 hallazgos, 6 parches; cierre en `Mesa/05-Cierre-Ciclo2.md`.
- Entregable v1.2: todas las salidas alineadas al escenario (svc_update/soporte/update.exe PID 9310/203.0.113.14/WinDefendUpd/\SystemUpdate), §2.9 presenta el caso, §12.1 lo cierra por cruce de indicios, Anexo D con línea de tiempo y mapa de salidas. Verificado: sin residuos de valores viejos, fences balanceados, nombres consistentes.

---

## Adenda 2026-09-17 (noche) — Corpus de logs e intencionalidad (ciclo 3)
- Nuevo fixture: `Escenario/Corpus-Logs.md` (eventos renderizados como los muestra Windows, con "qué leer" campo por campo).
- Mesa ciclo 3: `Mesa/06-Panel-Corpus.md` (+ AH-002 analista forense DFIR), 6 hallazgos, 6 parches; cierre en `Mesa/07-Cierre-Ciclo3.md`.
- Entregable v1.3 (1554 líneas): §4.6 checklist "primeros 10 minutos"; §5.4 lectura de subestados del 4625; §5.5.3 "cómo saber que el borrado fue intencional" (1102/104 como acción explícita + señales + causas legítimas a descartar); Anexo E galería de logs comentados. Verificado.

---

## Adenda 2026-09-17 (cierre) — Cuaderno de ejercicios (ciclo 4)
- Nuevo entregable compañero: `Guides/Seguridad-Red-Windows-Guide/Cuaderno-Ejercicios-Seguridad-Windows.md` v1.1 (294 líneas).
- 19 ejercicios en 7 módulos (dificultad 🟢🟡🔴), sección de respuestas explicativas al final (el porqué, con referencia a la guía), y sección de autoevaluación. Micro-casos nuevos coherentes (PC-VENTAS07 doc-malicioso, SRV-CONTA02 rotación legítima, casos A/B de subestados y de intencionalidad).
- Mesa ciclo 4: `Mesa/08-Panel-Cuaderno.md` (núcleo + E-Didáctica + E-SeguridadWin), 6 hallazgos, 6 parches; cierre en `Mesa/09-Cierre-Ciclo4.md`.
