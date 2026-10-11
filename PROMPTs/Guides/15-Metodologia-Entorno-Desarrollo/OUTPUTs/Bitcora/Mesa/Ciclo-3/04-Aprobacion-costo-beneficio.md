# Mesa · Ciclo 3 · 04 — Aprobación: juez de costo-beneficio

> Fecha: 2026-10-09. Marco: `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` §5.5 (aprobación) y §6 (escalada). Insumo: `03-Parches.md` de esta carpeta y la guía 1.0.0 (`LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md`, 3605 líneas, 54 267 palabras, sha256 `a2b78179…c48a691fd`).
> Función objetivo: ¿el costo de corregir (extensión, complejidad, riesgo de diluir) es menor que el daño de no hacerlo? Chequeo obligatorio por parche: ¿corrige en la capa donde nació el defecto?
> Vara propia, la misma de mi voto (`02-Voto-costo-beneficio.md`): un parche que agrega prosa procede sólo si repara un daño concreto (un comando que falla, un registro falso, una afirmación refutada por un E1 o por una fuente). Un parche que recorta procede si saca repeticiones y deja cada tesis una vez, con remisión.

## 1. Comprobaciones propias antes de votar

| # | Qué | Cómo | Resultado |
|---|---|---|---|
| K1 | Los 23 parches de guía se aplican sobre la guía **actual** y el balance es el declarado | `sha256sum` de la guía; copia de `evidencia-auditor/simulacion/*.py` al scratchpad y `GUIA=<guía real> python3 -I gen.py` (no toca el original) | sha256 `a2b78179…`, igual al que midió el auditor: la guía no cambió. `fallas=0`; el Δ de cada parche es idéntico a §2 de `03-Parches.md`; **prosa 43 604 → 44 097 (+493)**, evidencia +481, `wc -w` 54 267 → 55 241 (+974). |
| K2 | El dato más volátil del lote: uv 0.13.0 (P-16 [B223], P-18) | WebFetch a https://github.com/astral-sh/uv/releases/tag/0.13.0 (consulta 2026-10-09) | Publicada el 2026-10-09; «The default stable Python version has changed from 3.14 to 3.15». [B223] se sostiene. |
| K3 | El dato que motiva el paso 5 de §12 (P-12) y [B224] | WebFetch a https://builds.dotnet.microsoft.com/dotnet/release-metadata/releases-index.json (consulta 2026-10-09) | `8.0`: `eol-date` 2026-11-10, `latest-sdk` 8.0.425, fase *maintenance*; `10.0`: `latest-sdk` 10.0.401, *active*. P-12 y [B224] se sostienen. |
| K4 | El criterio de corrección nuevo de «Volver al mapa» (P-10 op 11: «tres filas se reconocen respaldadas sólo por una fuente») | `awk` sobre §3.3 de la guía y de `guia-parcheada.md`: filas cuya columna «Evidencia» no tiene ID de experimento | Exactamente tres en las dos versiones: `PackageReference Version`, `requires-python` y `SOURCE_DATE_EPOCH`. El criterio es correcto. |
| K5 | Citas de la frase nueva sobre Python 3.15 en §11.2.2 (P-11 op 2: «desde 3.15 usa UTF-8 estricto [B29][B205]») | `grep` de las filas B29, B205 y B220 en `guia-parcheada.md` | [B29] es PEP 686 y [B205] el anuncio de 3.15.0: los dos sostienen «UTF-8 por defecto», pero el manejador **estricto** lo sostiene [B220] (Python `os`, UTF-8 Mode), que P-04 cita para la misma afirmación en §4.2.4. Falta esa cita. Ver la condición C-1. |

## 2. Votos

| Parche | Voto | Fundamento (costo vs. daño · capa) |
|---|---|---|
| P-01 | APLICAR | +28 por metadatos que hoy mienten (versión, 224 fuentes, 74 experimentos) y una fila de la ruta mínima; la regla «[no verificado] sin motivo = requiere Windows» es la que habilita el ahorro de P-23. `version: 1.1.0` **[criterio]** del auditor (§9): lo acepto, porque el lote agrega un experimento y siete fuentes. Capa: guía. |
| P-02 | APLICAR | +2: alinea la fila ACT-OPS con los pasos que de verdad le tocan. Capa: guía. |
| P-03 | APLICAR | −124, el segundo mayor ahorro: §3.5 deja de duplicar §8.2.1 (C3-35, recorte 1) y suma la fila de la capa 6 que el lector no encontraba (C3-30), sin agregar prosa. Capa: guía. |
| P-04 | APLICAR | +36 por tres afirmaciones refutadas: Python ≥ 3.15 con cp1252 (fuente oficial [B220] y E1 de AH-001), el BOM en un script según el resto del archivo (E8-1, rc=2) y `child_process` ahora con evidencia (X3). Capa: guía; origen en N1 por O-6. |
| P-05 | APLICAR | +92, uno de los más caros, pero cubre cuatro hallazgos con E1 (X2): una política de BOM con razones falsas (C3-16), dos secciones con órdenes incompatibles (C3-20) y un guardián que cierra la terminal en la que se pega (C3-25, X4). Sin él, el lector aplica la tabla por motivos que la CLI desmiente. Capa: guía; origen en N2 por O-3. |
| P-06 | APLICAR | +36. La guía recomienda `CheckSdkVulnerabilities`, que en los SDK del caso no existe (MSB4057), y atribuye a Microsoft una regla que es criterio propio ([B56]: rango en CI). Es falsa seguridad (S2) y se corrige con acotaciones, no con secciones nuevas. Capa: guía; origen en N3 por O-8. |
| P-07 | APLICAR | −16 y un snippet que hoy falla tal cual (MSB1003) pasa a funcionar. Capa: guía; origen en N4 por O-7. |
| P-08 | APLICAR | +146, el mayor crecimiento del lote, y lo acepto porque es la definición única que votamos 5-0 (C3-01 A): un párrafo en §8.2.2 con E5-8 y quince remisiones cortas en lugar de quince cláusulas (≈ +300 según el abogado). Además quita un «garantiza» refutado (C3-23), corrige «el mismo digest es la misma imagen» para índices multiplataforma (C3-10) y fusiona dos preguntas. Riesgo de diluir: bajo; la tesis queda en un solo lugar y los demás remiten. Capa: guía; origen en N5 y `04-Integracion.md` por O-1 y O-9. |
| P-09 | APLICAR | +80. Retira una plantilla que, conectada, rompe la reconstrucción (C3-12) y endurece una verificación de consumidor que hoy acepta cualquier workflow (C3-27, [B221]). Reconstrucción «con el mismo SDK» reemplaza un motivo refutado (C3-03). Capa: guía; origen en N6 por O-4. |
| P-10 | APLICAR | +132. Cada op corrige una promesa que la compuerta no cumple: deja que un par la desarme (C3-26, S2 de seguridad, X6), dos entradas de hooks que se excluyen sin aviso (C3-19), `n/a` sin lock que pasa en verde (C3-18), un bot que trae otro SDK con etiqueta flotante (C3-11). La consigna de §10.9 gana criterio de corrección y lo comprobé (K4). Capa: guía; origen en N7 por O-2. |
| P-11 | APLICAR, con la condición C-1 | +121. Corrige la pieza central del capítulo central: el diagrama y §11.4 mandaban a un archivo que el lector no tiene (C3-22) y el encadenamiento de §11.2.5–§11.2.7 daba lo opuesto de lo decidido en el ciclo 2 (C3-28). Partir tres párrafos de ≥ 150 palabras no agrega contenido; sólo agrega rótulos de regla, y baja el costo de lectura (C3-48). La única falta es la cita de K5: una cita, no prosa, y no justifica devolver el parche. Capa: guía; origen en N8 por O-5. |
| P-12 | APLICAR | +66. Hoy la hoja de ruta fija un SDK al que le quedan 32 días de soporte (K3), y el contrato YAML rechaza una CI que la guía aprueba (C3-04). La respuesta completa de la Práctica cuesta una línea y queda con 11 validaciones, verificado por `yaml-salida.txt`. Capa: guía; origen en N3 por O-8. |
| P-13 | APLICAR | +89 de prosa y +140 de plantillas, que el lector **copia**. Hoy esas plantillas: escriben un registro falso con 0 (C3-09); fallan en el primer commit (C3-17); apuntan a una etiqueta flotante (C3-11); y no traen receta para Windows, que es el caso disparador (C3-21, **[no verificado]**, rotulada). Cada bloque coincide byte a byte con `x1-ea1-propuesto/repo/`, que corre EA-1 con rc=0. Capa: guía + laboratorio (P-25). |
| P-14 | APLICAR | +29: B.3 y B.4 son donde cada actor busca su tarea; sin la remisión siguen enseñando un solo camino de CI. Capa: guía. |
| P-15 | APLICAR | +12 en el glosario: remisiones a la sección que define cada término y dos alias. Más barato que renombrar en el cuerpo. Capa: guía. |
| P-16 | APLICAR | Prosa 0, evidencia +176. Son las siete fuentes sin las cuales las afirmaciones nuevas de P-04 a P-13 quedarían sin respaldo. Verifiqué las dos más volátiles (K2, K3). Capa: guía. |
| P-17 | APLICAR | +3 de prosa. Cumple lo que §0.3 promete (la fecha de cada corrida, sacada de X7 y no estimada) y registra E5-8, que P-08 cita. Capa: guía. |
| P-18 | APLICAR | +48. Trazas incompletas y datos volátiles sin fuente anulan el Anexo F como registro; declarar como no verificado el log del runner y su retención es lo honesto. Capa: guía. |
| P-19 | APLICAR | −14. Fila 1.1.0 y compresión de los párrafos de versión. Capa: guía. |
| P-20 | APLICAR | −74. Repeticiones que remiten a §0.4 y a EA-1; no se pierde información. Capa: guía. |
| P-21 | APLICAR | −125, el mayor ahorro. Saca el mapa repetido, la lista de uniones, la receta repetida y la tesis de Visual Studio de §12, que queda en §8.2.4, donde funciona como advertencia (condición de riesgo en C3-35). Capa: guía. |
| P-22 | APLICAR | −58. Fusiona o remite preguntas guía que sólo repetían su sección; cada una conserva su *Aplica*. Capa: guía. |
| P-23 | APLICAR | −16. Saca la glosa en ocho lugares; la regla queda una vez en §0.3 (P-01). Va último, como indica el auditor, porque cuenta apariciones que otros parches tocan. Capa: guía. |
| P-24 | APLICAR | Es el parche de capa de origen: once notas de solo agregado, Δ 0 en la guía, reversibles por instantánea y con la evidencia citada. Cierra también los pendientes del ciclo 2 (O-5, O-12, C1-05 en N7). Sin él, el próximo ciclo volvería a derivar desde núcleos que todavía dicen lo que se corrigió. Observación menor, que no cambia el voto: O-9 se titula «ciclo 2 y 3» y se inserta en el 3; conviene que el aplicador lo deje así para que se lea como cierre del pendiente O-12, no como nota retroactiva. |
| P-25 | APLICAR | Costo de ejecución medio (≈ 9 min de corridas), sin prosa en la guía. El laboratorio es la capa de origen de C3-09, C3-17 y C3-32, y la guía parcheada cita salidas que sólo existen si estos cambios se corren. Que N8 no se toque es la decisión barata: describir la diferencia cuesta menos que regenerar E8-3, E8-5 y E8-6. |

## 3. El saldo de prosa (+493) frente a C2-36

El lote no cumple el saldo ≤ 0 de C2-36, y el auditor lo declara (§2 de `03-Parches.md`). Mi dictamen:

1. **No voto en contra de ningún parche por el saldo.** Los recortes ya hechos (−427) son todos los que aprobó C3-35 y tres más. Lo que crece (+920) son correcciones con E1 o con fuente. Para llegar a ≤ 0 recortando correcciones, la guía seguiría afirmando cosas refutadas, y ese daño es mayor que +1,1 % de prosa. Comparado con la alternativa B de C3-01, el lote ya eligió la dirección más barata en cada caso.
2. **No apruebo en bloque la pasada del editor de cierre** (C3-Q09, ≈ −500), porque todavía no es un parche: no tiene texto exacto ni Δ medido, y toca párrafos con información (§6.2.2, §6.2.3, §7.2.1, §10.2.6). Aprobarla a ciegas saltearía §5.4 del marco. Propongo diseñarla como **P-26**, con texto exacto, Δ medido por `gen.py` y la misma vara de P-20 a P-22, y someterla a una vuelta de aprobación antes del cierre del ciclo. No bloquea la aplicación de P-01 a P-25.
3. Si P-26 no llega a ≤ 0, el excedente se registra como **deuda declarada** del ciclo 3 en el control de cambios (marco §5.5, NO_APLICAR consciente), con su cifra.

Esto no es un disparador de §6. C2-36 es un criterio que votó la mesa, no una restricción dura del contrato, así que no aplica el disparador 2. Tampoco se lo reabre (disparador 7): se cumple con P-26 o se declara la deuda.

## 4. Condiciones que acompañan el voto

Ninguna cambia un APLICAR.

- **C-1** (P-11 op 2, K5). La frase sobre 3.15 cita también [B220]: «desde 3.15 usa UTF-8 estricto [B29][B205][B220]». Es una cita, sin cambio de prosa. La verificación de P-11 suma `grep -c 'estricto \[B29\]\[B205\]\[B220\]'` → 1.
- **C-2** (las condiciones del propio auditor, que sostengo). E5-8, E2-6 ampliado y E1-11 con Node se corren y se versionan **antes** de aplicar P-08, P-05 y P-04, que los citan. EA-1 se corre una sola vez, después de L-01 y L-01b, y el commit y el hash de la DLL de esa corrida se copian al extracto de A.17.
- **C-3** (orden). Primero la instantánea de `Examples/` y de los archivos de origen. Después P-24 → P-16 → P-25 → P-01…P-22 → P-23 al final. Por último se vuelven a correr `checks.py` y `anexoA.py` sobre la guía real. Si una corrida no da lo esperado, el op que la cita no se aplica y vuelve como `regresión` (marco §5.6).
- **C-4** (datos del día). El digest `ec9c0a0d…` de `sdk:8.0.425-bookworm-slim` es el del 2026-10-09. Si EA-1 (paso 6) muestra otro, va el digest de esa corrida, y A.10, O-1 y el Anexo F se ajustan juntos.

## 5. Resumen

- **APLICAR: 25 de 25** (P-11 con la condición C-1). MEJORAR_PLAN: 0. NO_APLICAR: 0. ESCALAR: 0.
- **Capa de origen**: todos corrigen donde nació el defecto. Los nacidos en la guía, en la guía. Los nacidos en núcleos, en `04-Integracion.md` o en la bitácora de ciclos anteriores llevan su nota en P-24 (O-1 a O-11). Los del laboratorio llevan su op en P-25 (L-01 a L-07).
- **Presupuesto**: prosa +493, reproducido (K1). No se corrige recortando correcciones. Va a un P-26 diseñado (§3) o, si no alcanza, se registra como deuda declarada.
- **Sin escalada**: ningún parche cambia lo que la guía promete (disparador 3) ni reabre una decisión cerrada (7). C3-02 (c) y C3-18 (a), que la reabrían, quedaron fuera por decisión del auditor, y lo comparto. Ningún parche toca consecuencias externas (5).
- **Supuestos registrados**: la fecha de trabajo es 2026-10-09, la del sistema y la de la bitácora. Las consultas de K2 y K3 son de ese día. No toqué la guía, `Examples/` ni el prompt del PO; la simulación de K1 corrió sobre una copia en el scratchpad.
