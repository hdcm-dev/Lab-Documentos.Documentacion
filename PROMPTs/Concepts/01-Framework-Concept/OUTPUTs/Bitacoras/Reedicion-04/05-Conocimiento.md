# 05 — Conocimiento (entregable 3 del prompt 04)

**Fecha:** 2026-11-01
**Estado:** borrador entregado, sin commitear.

## Qué se hizo

- Creado `Concepts/Framework-Concept/Conocimientos/Knowledge-App-Hibrida-OTA-Offline-First.md` (v1.0) y el
  `README.md` de la carpeta, en el worktree de la rama `fc/libro-guia-desarrolladores`.
- Formato tomado de los Knowledge de IA.Knowledge.Base (encabezado alias/naturaleza/tema/consumidor/condición de
  carga/versión/estado/fecha; §0 con mapa de carga).
- Secciones: cuándo usar y cuándo no; 13 principios con criterio y prioridad; arquitectura de referencia
  (mermaid); contrato del puente; OTA (firma, staging, rollback, economía de datos); offline-first y outbox;
  sesión, Keystore y pool de equipos compartidos; métricas de arranque; pruebas; procedimientos; checklist de
  arranque; referencias y casos de industria; límites.

## Mesa

Pasada única con los roles de la mesa a pedido aplicados por un mismo agente (comisión de redacción,
refutador de evidencia, jurado de alcance). No hubo despacho a subagentes separados: se declara como límite.
Criterio del refutador: toda afirmación remite a archivo:línea de `Demo/`, a sección del libro o a `Rn` del
Anexo B; lo no ensayado se marcó **propuesta** (economía de datos por red medida, despliegue por porcentaje,
pool de equipos, rotación de claves) o **NO VERIFICADO** (iOS, WASM ante tiendas, tendencias).

## Verificación hecha

- Rutas `../Demo/...` citadas: existen.
- Sin rutas del home, IPs ni datos privados (grep).

## Pendientes

1. Contrastar las secciones del libro citadas con el texto vigente si el libro se renumera.
2. Mesa del producto para las propuestas de §7.1 (pool de equipos) antes de llevarlas al libro.
3. Mermaid sin renderizar (mismo pendiente que el libro: Chromium en contenedor, negociar recursos).
4. Referencias R16–R62 siguen «Consulta: a verificar».
