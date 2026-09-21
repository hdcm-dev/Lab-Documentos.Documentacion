# Bitácora de editores 03 — Cierre de la mesa

**Fecha:** 2026-09-19 · **Presidente** · **Objeto:** guía v2.0.2 @ dbdf9dd → **v2.1.0** (rama `docs/arquitectura-v2.1.0-mesa-editores`, PR en `hdcm-dev/Lab-Documentos`)

## Resultado

| | |
|---|---|
| Comisiones | Editor de libros técnicos, académico en pedagogía, Martin Fowler (personificado, citas verificadas en la web), especialista .NET/C# (compilación en SDK 10.0.400); refutador; dictamen post-aplicación de Fowler |
| Hallazgos | 47 → 22 sostenidos, 13 degradados, 1 tumbado, 7 duplicados, 4 elevados; 7 peritajes resueltos por el presidente (`02-Ciclo1-Resolucion.md` §2) |
| Ciclos | 1 + refutación + dictamen. No se abrió segundo ciclo (ningún P1 tumbado). Rendimiento: 5,5 hallazgos procedentes por comisión |
| Aplicado | 38 hallazgos (tabla en el informe del editor, `Ciclo-1/` y CHANGELOG v2.1.0); 14 observaciones del dictamen de Fowler aplicadas dentro de la frase (0 líneas netas) |
| Guía | 2126 → **2545 líneas**; bloques C# 23 → **39** (tope 41 ✓); `[Compilado]` 13 → 23 (+3 «sin captura» en §2.2), todos cotejados 23/23 contra su archivo con rango; `[Fragmento ilustrativo]` 10 → 13; mermaid 7; enlaces internos 129, 0 rotos; muletillas Rule-Narrative-Voice: 0 |
| Código | `Variantes/Pedidos/` + `Infrastructure` (EF Core Sqlite 10.0.12, `AppDbContext : IUnitOfWork`, repositorios con seguimiento, `CambiarPrecioProducto`, contraste `AsNoTracking` medido 1/0); V01/V02 regeneradas (líneas citadas idénticas) y V03 nueva; compilación independiente por el presidente: 0 errores. `MyProject/`, `lab.sh`, `Conceptos-DI/`, capturas L00–L24: sin cambios (`git diff` vacío) |
| Fidelidad | Dictamen Fowler post-aplicación: 8 conforme, 8 con observación (aplicadas), 0 no conforme |

## Apartamientos declarados

1. **Presupuesto de líneas excedido: +419 (19,7 %) contra ≤ +300.** Los bloques cumplen el tope (39 ≤ 41). El exceso son las 16 tablas «línea → concepto» que fijó el peritaje P-1 y las remisiones de las 41 viñetas de definiciones. Recortarlas contradecía decisiones cerradas; el presidente acepta el exceso porque el criterio de fondo del refutador —una materialización por concepto, en un solo lugar, sin código duplicado— se cumplió (propio).
2. `static factory method` se quitó en vez de citarse (Bloch no verificado en esta corrida).
3. PE-08 (pasos 5 y 6 de §9.6 en código) no se aplicó: fuera del plan; queda en deuda.

## Deuda declarada

- PE-08: materializar los pasos 5 y 6 de la escalera en código (Repository y Contracts del ABM de Personas).
- MF-09 (*Data Mapper* como nombre de lo que §5.4 describe): una frase, no aplicada por «una frase o nada» → nada.
- NET-09 (variante `ClienteApi/`): descartada por P-3; los objetos de cliente quedaron como fragmentos ilustrativos.
- El Anexo A no lista un guion que corra `Conceptos-DI/` (ED-09 se resolvió con la marca «Compilado sin captura»).

## Preguntas que sobrevivieron (lote, con default)

Ninguna: todo lo que las comisiones no podían decidir se resolvió en peritaje con la propuesta mejor fundamentada (delegación del PO, 2026-09-14).

## Reintegra

Rama `docs/arquitectura-v2.1.0-mesa-editores` → PR → `main` de `hdcm-dev/Lab-Documentos`. Merge: por el agente si el PO lo confirma (el pedido de esta mesa no repitió «hacé el merge»).
