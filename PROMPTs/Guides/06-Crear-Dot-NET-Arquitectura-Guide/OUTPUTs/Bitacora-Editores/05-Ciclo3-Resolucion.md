# Bitácora de editores 05 — Resolución del ciclo 3: procedencia, Invariant y materializadores

**Fecha:** 2026-09-21 · **Presidente** (no vota) · **Insumos:** `Ciclo-3/Informe-Fowler-Invariantes.md` y `Ciclo-3/Informe-DotNet-Materializadores.md` (verbatim) · **Objeto:** guía v2.2.0 @ rama `docs/arquitectura-v2.1.0-mesa-editores`

## 1. Pedido

Product Owner, 2026-09-21: «no sabía que era una práctica `Replace Constructor with Factory Function`, ¿quién propuso esta práctica? … mencionás sobre invariantes, ¿podés definírmelo y darme ejemplos? … también mencionás Dapper y serializador, no sé qué son esos términos … ¿podés agregar ejemplos, algo de código snippet para formar una idea visual respecto a esa tabla comparativa que das? … introducir estos temas en el documento».

## 2. Decisiones

| # | Cuestión | Decisión | Fundamento |
|---|---|---|---|
| E-1 | Procedencia de la refactorización | Se atribuye a **Fowler**, con el alias de la 1.ª edición (1999) y el nombre de la 2.ª (2018); sin coautor | Ficha del catálogo verificada |
| E-2 | ¿Se cita a Bloch? | **Sí, como convergencia y no como origen**: *Effective Java* 3.ª ed., cap. 2, ítem 1. Se dice que es posterior a *Refactoring* | Fuente primaria (TOC del editor, ISBN) |
| E-3 | Evans y la invariante de Aggregate | **No se cita** «whenever data changes»: no está en la *DDD Reference* 2015 y la guía no tiene el libro de 2003. Se usa «Define properties and invariants for the aggregate as a whole…» | Hallazgo negativo verificado sobre el PDF |
| E-4 | Definición de *Invariant* | Se completa con la tercera parte: **si se rompe, el objeto no debería existir** | P0 de Fowler |
| E-5 | Las tres piezas que la sostienen | Tabla de 3 filas en §3.6 con la columna «qué pasa si falta» (la fábrica la establece; el setter privado impide romperla; cada método la reverifica) | Hoy dispersas en §3.3, §3.4 y §3.7, nunca juntas |
| E-6 | Ejemplos formadores de criterio | Tabla de 7 filas en §3.7, con las tres preguntas como filtro y cuatro contraejemplos | P1 de Fowler |
| E-7 | Aggregate en §4.10 | Tres líneas: para qué sirve el borde (`Pedido.Confirmar`, `ItemPedido` `internal`) | P2 |
| E-8 | La tabla de los cuatro materializadores | **Se escribe en §5.4**: `Create` / EF Core / Dapper / `System.Text.Json`, con «para qué», «cómo construye» y «qué pasa si no hay constructor sin parámetros» | NET3-01: hoy no existe |
| E-9 | §7.4, «setters públicos y constructor sin parámetros» | **Se corrige**: es suficiente, no necesario; y se declara el modo de falla medido — constructor público con setters privados **no lanza y devuelve el objeto en cero** | NET3-03, P1, E1 |
| E-10 | Glosario y definiciones | Entradas nuevas: **ORM** (hoy se usa ocho veces sin expandir), **micro-ORM** y **serializador**, con la redacción que propone la comisión | NET3-02, costo cero en bloques |
| E-11 | Snippets | **Un solo bloque** con los cuatro usos lado a lado, junto a la tabla de §5.4. El segundo bloque del presupuesto queda para el ❌ medido del serializador en §7.4 | NET3-06 |
| E-12 | ¿Se compila el escenario? | **Sí**: escenario `materializadores` en `Variantes/FabricaYResultado/` (~130 líneas, capturas V09). Convierte en E1 lo que si no sería prosa, y el laboratorio ya es el lugar del volumen | Criterio del ciclo 1 |
| E-13 | Dapper como primer paquete de terceros del árbol | **Aceptado**, con fila nueva en el Anexo C (Dapper 2.1.86, Apache-2.0, verificado en el nuspec). Es coherente con §9.4, que da el criterio para adoptar un paquete: el laboratorio lo ejerce | Propio |
| E-14 | Presupuesto de la guía | **≤ +60 líneas y ≤ 2 bloques**, como se fijó al despachar. Fowler cifró +23 y 0 bloques; quedan ~37 líneas y los 2 bloques para E-8/E-9/E-10 | Propio |

## 3. Plan

1. **.NET**: escenario `materializadores` + capturas V09 (trasplanta las que ya midió), fila del Anexo C. No toca la guía.
2. **Editor**: E-1…E-11 y E-14 en §3.1, §3.6, §3.7, §4.10, §5.1, §5.4, §6.1, §7.4, Anexos C, D y E. CHANGELOG v2.3.0.
3. **Fowler**: dictamen post-aplicación.
4. Verificación y commit sobre la rama del PR #8.
