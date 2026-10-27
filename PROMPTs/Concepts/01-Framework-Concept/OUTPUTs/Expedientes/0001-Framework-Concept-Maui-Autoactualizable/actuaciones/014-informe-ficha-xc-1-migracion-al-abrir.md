| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Comisión Analista de sistemas y decisiones (ficha XC-1) |
| Corrige | — |

| Campo | Valor |
| --- | --- |
| Tipo | informe (ficha de excepción; la presidencia le asigna folio y número `XC-<n>` al incorporarla) |
| Fecha | 2026-10-25 |
| Autor | Analista de sistemas con criterios de decisión y análisis de las decisiones (comisión de la mesa del expediente 0001) |
| Informe que la sostiene | `despacho/analista-sistemas-y-decisiones.md`, hallazgo H-03 y respuesta a P5 |
| Documentos cargados | Excepcion-A-Un-Conocimiento 2.0 (entero) · Versionado-Producto-Integral 2.0 §0, §1, §2.7, §2.8 · Cadena-De-Consecuencias 2.0 §2 · Escalas-De-Juicio 1.0 §3.1–§3.4 |

# Ficha de excepción — migración de la base local al abrir la app

```text
EXCEPCIÓN XC-{{n}}  (número que asigna la presidencia al incorporarla)
  Conocimiento:           Versionado-Producto-Integral 2.0 §2.7, cláusula 2 — «El binario lo exige al arrancar y no
                          arranca si no coincide. La constante vive en el código del artefacto y el mensaje dice las
                          dos versiones y el acto que lo corrige. Aplicar migraciones al arrancar se rechaza: carreras
                          entre instancias, permisos de DDL en el proceso, ninguna vuelta atrás ni respaldo previo.»
                          (Knowledge-Versionado-Producto-Integral.md:264-266). Toca también §2.8, fila `operativa`
                          («El almacén no vuelve», :288), y la fila `diseño` («se recrea el almacén», :286).

  Alternativa de cumplir: Dos formas, las dos medidas:
                          (a) Cumplir literal: el cascarón v2 lleva la constante del esquema exigido, lee el de la
                              base SQLite del teléfono, y si no coincide no arranca y muestra «exigida/leída»; la
                              migración la aplica otro acto fuera del binario.
                          (b) Cumplir por la fase `diseño` (§2.8): al detectar esquema distinto, recrear el almacén
                              (borrar y crear), que es la vuelta atrás que esa fase declara.

  Costo de cumplir:       Medido (E1) con EF Core SQLite 10.0.11 (la versión del caso base, R1 §10), SDK 10.0.400, en
                          contenedor efímero mcr.microsoft.com/dotnet/sdk:10.0, 2026-10-25. Base v1 con 3 acciones
                          encoladas (outbox con clave de idempotencia única); binario v2 con una migración más
                          (columna `VersionPayload`):
                            caso cumplir (a):  «v2-cumplir: NO ARRANCA — exigida=20261025000002_VersionDePayload
                                                leída=20261025000001_Inicial» · codigo_salida=3
                            caso recrear (b):  «v2-recrear: esquema=20261025000002_VersionDePayload pendientes=0»
                                                (antes: pendientes=3) → las 3 acciones del usuario se pierden
                            caso migrar al abrir (lo que la cláusula rechaza):
                                               «v2-migrar: … pendientes=3 claves_conservadas=True ms=349»
                          Comando: `scratchpad/e-asd/correr.sh` (ruta local completa en el informe, §2, H-03);
                          sha256 de la salida: d07fa61db66880a597125428ad775dbc4c6f76d1290ec7bb8804a7bd653ebeac.
                          Eje que no quedó fijo: el dispositivo (Linux x64 en contenedor, no el g42).

  Por qué no se cumple:   Contradicción, no conveniencia.
                          E2 — En un teléfono no existe «otro acto» que pueda aplicar la migración: «Other apps cannot
                          access files stored within internal storage» (Android Developers, «Access app-specific
                          files», https://developer.android.com/training/data-storage/app-specific, consultado
                          2026-10-25). La base vive en `FileSystem.AppDataDirectory` (Framework-APP.md:289; caso base
                          `Data Source={AppDataDirectory}/movilidad.db`, R1 §8). El único proceso con acceso es el
                          binario mismo.
                          E1 — Por (a) el binario nuevo no abre (código 3): choca con el objetivo del contrato
                          («apps … que bajan sus actualizaciones del servidor al abrir», folio 003:46-48): una app que
                          no abre no baja nada. Por (b) se pierden las acciones encoladas (3 → 0); la fase `diseño` se
                          reconoce porque «no hay datos que alguien reclame» (VPI:286), y un outbox con pendientes
                          son datos que el usuario reclama. En `operativa` (fase que rige si no se declara, VPI:292)
                          (b) tampoco existe: «El almacén no vuelve» (VPI:288). Para un framework cuyas apps llegan a
                          `operativa`, cumplir es imposible: o la app no abre, o pierde datos del usuario.
                          Las tres premisas del rechazo son de servidor (carreras entre instancias, permisos de DDL
                          separados, vuelta atrás o respaldo por otro canal); la documentación oficial de EF Core las
                          presenta como «tradeoffs» de la migración en tiempo de ejecución y la admite «for
                          applications that prefer simple deployment and can tolerate startup migration behavior»
                          (https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying,
                          ms.date 2026-08-05, consultado 2026-10-25).

  Reversibilidad:         Hoy reversible: ninguna app del framework está instalada en teléfonos de terceros (producción
                          fuera de alcance, folio 003:84); volver a cumplir es un cambio de la guía y de la demo.
                          Deja de serlo cuando una app con este mecanismo esté instalada por terceros: desde ahí la
                          migración ya aplicada en cada teléfono no vuelve (Cadena-De-Consecuencias §2, paso 4).

  Lo que sigue rigiendo:  Cláusulas 1, 3 y 4 de §2.7 (la base declara su número; el número se expone en diagnóstico con
                          exigido y leído; una compuerta ata base, binario e instalación limpia) y, de la cláusula 2, la
                          parte «el binario lo exige al arrancar y no arranca si no coincide» **después** de intentar
                          migrar: si la migración falla, el contenido no arranca y el mensaje dice las dos versiones.
                          Las tres premisas del rechazo se compensan en el camino propuesto, no se ignoran: respaldo
                          previo (copia del archivo antes de migrar), migración en una sola transacción, y el
                          contenido no arranca hasta que la base quedó en el número exigido.

  Sostiene:               Analista de sistemas con criterios de decisión y análisis de las decisiones —
                          despacho/analista-sistemas-y-decisiones.md (H-03; P5)
  Aprobó:                 pendiente — sale en el cierre (Excepcion-A-Un-Conocimiento §5.2)
```

Nota para la presidencia: la ficha no trae el análisis del camino de compromiso (lo escribe el análisis de decisiones
en el paso 6 bis si el refutador la admite). El camino que este informe recomienda para P5 —migrar al abrir en el
cascarón, con respaldo previo del archivo y compuerta de esquema— está en el informe, §3, P5, con su cadena de
consecuencias.

Sigue: incorporación del siguiente informe y resolución · presidencia
