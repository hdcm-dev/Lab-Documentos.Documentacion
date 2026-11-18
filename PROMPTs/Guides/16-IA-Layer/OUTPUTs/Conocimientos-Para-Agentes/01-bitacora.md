# Bitácora — Conocimientos para agentes de la capa de IA

## 2026-11-11 · Ronda de ajuste tras la prueba a ciegas

**Mesa:** ingeniería de conocimiento para agentes, coordinada con la mesa de la guía de diseño conversacional.
Regla: los libros (Guía 16 y guía conversacional) son la fuente; los conocimientos los destilan, remiten por
sección y no los contradicen; los huecos del libro se anotan para la otra mesa y no se resuelven acá.

**Entrada:** prueba a ciegas (un aplicador que nunca vio PushDispatch armó la integración para un sistema de
turnos médicos sólo con K1–K4; 17 huecos, tres altos) y tres lentes críticas (fidelidad a la experiencia,
aplicabilidad, autocontención), las tres con «no aprobado».

**Qué se corrigió (todo en `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Conocimientos/`):**

| Hueco o defecto | Arreglo | Dónde |
|---|---|---|
| HUECO-10 (alto) K5 inexistente | K5 creado como borrador provisorio 0.9: formas F1–F8, datos, candidatas, chip de destino, voz, medición | K5 |
| HUECO-2 (alto) conocimientos externos inaccesibles | Resumen autocontenido con porqué y prueba; los externos pasan a «opcionales» | K2 §16 (E-1 a E-5), K4 §14 (G, M, D, P, T) |
| HUECO-5 (alto) dominio de riesgo profesional | Regla provisoria F-7 (Afuera con texto fijo, excepción firmada) y anotado para la otra mesa | K1 §3.1 |
| HUECO-4 categorías especiales | Regla provisoria F-8 y anotado para la otra mesa | K1 §3.1 |
| Batería mal contada | Secuencia real: 19/20 en una corrida → 21/33 (64 %) ×3 → 27/30 ×3 → 36/36 ×3 y 81/81 | K1 §13, K2 §14, K3 R2.3 y §16, K4 E6 |
| Latencia simplificada | Modelo único en memoria (recarga de unos 3 a 7,5 s); configuración del servidor junto a cada cifra; reporte no reproducible corregido | K2 §10.4, K3 R3.1, R3.3a, K4 E4 |
| Texto de abstención | «No está en la ayuda» es nombre de plantilla, no literal | K1 §3.1, K2 R2, K5 §2 |
| HUECO-11 ids AP-n | Prefijos K2-AP-n, K3-AP-n, K5-AP-n con ancla; tabla índice única | K2 §13, K3 §14, K4 §8 |
| HUECO-12 cabecera de K1 | Enlaces a K2–K5 | K1 |
| HUECO-13 anclas | Anclas estables `k1-N`; §3.7.2 → `#c3-7-2` | K1, K2, K3 |
| HUECO-14 claro y oscuro | Cuatro pares de capturas también en K2 y K4 | K2 §11–§12, K4 §9–§11 |
| HUECO-3 roles | Subagentes distintos; mínimos por ronda | K4 §2.2, K3 R4.1 |
| HUECO-8 tamaño de batería | M ≥ 20 y una por celda rol × tipo | K3 R2.1a |
| HUECO-17 fases | Fases tipo F0–F5 con condición de salida | K4 §1.1 |
| HUECO-1 sin producto de referencia | Cómo elegirlo; brecha optativa con motivo | K4 §3 |
| HUECO-6 roles externos | Fuera salvo especificación propia | K2 §1 |
| HUECO-7 permiso por instancia | Revalidación por instancia en el caso de uso | K2 §5.6 |
| HUECO-9 datos personales | R9.4 sobre evidencias | K3 |
| HUECO-15 total frente a aclaración | Tabla de cinco filas | K5 §5, K2 §3 |
| HUECO-16 presupuesto de latencia | Derivado del uso | K3 R10.2a |
| Índice | README de la carpeta con orden de lectura | Conocimientos/README.md |

**Controles corridos:** script de anclas y remisiones sobre los seis archivos (0 errores, ningún `AP-n` sin
prefijo); búsqueda de nombres prohibidos y direcciones (0 coincidencias).

**Pendiente:** repetir la prueba a ciegas con otro agente sobre esta versión; K5 pasa a 1.0 cuando se publique la
guía conversacional; la otra mesa tiene la nota con lo que hay que alinear.
