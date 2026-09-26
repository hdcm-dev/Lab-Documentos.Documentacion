# Bitácora de editores 06 — Resolución del ciclo 4: citas explicadas y materializadas, y dosis

**Fecha:** 2026-09-21 · **Presidente** · **Insumos:** `Ciclo-4/Informe-Editor-Revision-Main.md` y `Ciclo-4/Informe-Fowler-Revision-Main.md` · **Objeto:** guía v2.3.0 publicada en `main` @ dade777

## 1. Instrucción que gobierna este ciclo

Product Owner, 2026-09-21: «no dudes en incluir citas … y si podés explicaciones de esas citas, con algún snippet de código que materialice esa idea». **Una cita verificada no se recorta por presupuesto. Si algo cede por extensión, cede prosa propia, no fuente.**

## 2. Decisiones

| # | Cuestión | Decisión |
|---|---|---|
| F-1 | **Atribuciones erróneas** (Fowler 3) | **Se corrigen todas, primero**: *Service Layer* → Randy Stafford, PoEAA **p. 133**; *Repository* → Hieatt y Mee; *Decorator* → Gamma et al.; «composition root» → Seemann. Son el hallazgo más grave del ciclo: la guía atribuye a un autor lo que firmó otro |
| F-2 | Evans 2003 de segunda mano (§9.6) | **Se reemplaza** por el «Therefore» de *Layered Architecture*, DDD Reference 2015 p. 10, materializado con `RegistrarPedidoHandler.cs` l. 19–33. Costo 0 |
| F-3 | Las 8 citas que faltan (C-1…C-8) | **Entran las 8**, con explicación y snippet; todas tienen código ya compilado salvo la del ViewModel, que va ilustrativa |
| F-4 | Los 7 recortes (R-1…R-7) | **Entran R-1 (*Data Mapper*), R-2, R-5, R-6, R-7**. R-3 y R-4 se cierran como **no-deuda**, con el fundamento de Fowler. R-2 sin fragmento nuevo: el `ProblemDetails` ya está medido en `capturas/L21-regla-traducida.txt` |
| F-5 | §3.6 (nueve citas del BRG, cero código) y §4.7 (cinco citas de CQS, cero código) | **Se materializan**: §3.6 con `Producto.cs` de la variante y `Pedido.Total` (ya comentado como *Derivation* en el fuente); §4.7 con `Desactivar()` contra `PrecioDeVenta()` |
| F-6 | **O-1, la misma regla en cuatro tablas** | **Se fusiona**: una sola clasificación, en §3.7; §3.2 y §3.6 remiten. Es prosa y tabla propias, que es lo que el PO autoriza a ceder |
| F-7 | O-2, §4.10 con 209 líneas | **Se parte en dos** secciones, renumerando |
| F-8 | O-5, pasos 5 y 6 de la escalera sin código | **Entran** (+12, sin bloques): cierra PE-08 del ciclo 1 |
| F-9 | O-6, O-7, O-10 | **Entran**: Anexo B actualizado con las secciones nuevas; la señal «hay que distinguir motivos de rechazo» en §9.3; §0.3 deja de prometer lo que §3.8, §4.10 y §9.6 no cumplen |
| F-10 | O-3, V06 | **Se corta la deuda**: se regenera V06 y se actualizan los cinco números en §3.8. Una captura que no se puede regenerar es una captura que envejece sola |
| F-11 | O-9, diagrama del capítulo 3 | **Sólo si F-6 deja lugar**; se decide al final, con el conteo en la mano |
| F-12 | Norma editorial nueva | **Adoptada**: cita sin snippet sólo cuando habla del método de la guía, no de un mecanismo. Se escribe en §0.5 |
| F-13 | Presupuesto | **No hay tope de citas.** Prosa propia: saldo objetivo ≤ +60 líneas netas tras las fusiones. Bloques: hasta 6 nuevos |
| F-14 | Versión | v2.4.0. Rama nueva desde `main`; `Exercices/` fuera de alcance y stageo explícito |

## 3. Orden de aplicación

1. F-1 y F-2 (corrigen lo que está mal). 2. F-6 y F-7 (hacen lugar). 3. F-3, F-4 y F-5 (las citas con su código). 4. F-8, F-9, F-12. 5. F-10 (V06 y los cinco números). 6. F-11 según saldo. 7. Dictamen y PR.
