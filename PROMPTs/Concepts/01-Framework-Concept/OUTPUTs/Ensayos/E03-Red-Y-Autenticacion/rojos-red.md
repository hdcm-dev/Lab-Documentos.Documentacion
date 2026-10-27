# Rojos provocados del constructor de red (E03)

| Campo | Valor |
| --- | --- |
| Incremento | Folio 038: red combinada y política de acciones (`DISENO-RED-Y-AUTENTICACION.md` §2, §4, §10.1) |
| Fecha | 2026-10-26 |
| Dónde | Copia de trabajo `~/fc-work/demo/e03/red/demo` (sin `bin/obj` compartidos), `scripts/contenedor.sh dotnet test tests/FrameworkConcept.Core.Tests -c Release` |
| Regla (P8) | Cada suite se vio en rojo antes del verde. La mutación se aplicó sólo en la copia y se revirtió con `sync.sh` |

## Rojo 0: el esqueleto

Con las funciones del esqueleto (`NotImplementedException`), las suites nuevas fallan enteras:
`Con error: 56, Superado: 77, Total: 133` (log `~/fc-work/demo/e03/red/rojo-0.log`). Prueba que las suites
llaman a la lógica real. No cuenta como rojo «de una fila»: los dos que siguen sí.

## Rojo A: máquina de estados (`TransicionesDeRedTests`)

**Mutación** (fila invertida de §2.2, la que el diagrama del borrador §6 no dibuja): en `TransicionesDeRed.Siguiente`,
una falla en línea por datos móviles se queda en línea:

```csharp
SenalDeRed.SaludFalla or SenalDeRed.LlamadaFallida => actual == EstadoDeRed.EnLineaMedida ? EstadoDeRed.EnLineaMedida : EstadoDeRed.RedSinServidor,
```

**Rojo:** 2 de 202.

```text
Con error EnLineaConFallaPasaARedSinServidor(EnLineaMedida,SaludFalla)
Con error EnLineaConFallaPasaARedSinServidor(EnLineaMedida,LlamadaFallida)
  Expected: RedSinServidor
  But was:  EnLineaMedida
```

Logs: `~/fc-work/demo/e03/red/rojo-A.log` (primera corrida) y `rojo-A2.log` (repetición del 2026-10-26, mismo resultado).

**Verde** con la fila restaurada: 202 de 202 (`core-verde.log`).

## Rojo B: política de acciones (`EvaluadorDeAccionesTests`)

**Mutación** (regla de §4.3 invertida): una `Encolable` sin red se bloquea en lugar de quedar pendiente:

```csharp
if (red == EstadoDeRed.SinRed) return Bloqueada("Sin conexión");
```

**Rojo:** 2 de 202.

```text
Con error EncolableNuncaSeBloqueaConLaEntradaAbierta          (SinRed / Dispositivo: Expected True, But was False)
Con error EncuestaSinServidorQuedaPendienteConMotivo(SinRed,"Sin conexión")   (Expected (True, True), But was (False, False))
```

Logs: `~/fc-work/demo/e03/red/rojo-B.log` y `rojo-B2.log` (repetición, mismo resultado).

**Verde** con la regla restaurada: 202 de 202.

## Lo que no cubren estas pruebas

Son de la lógica pura (Core). El monitor (`Shell/Red/MonitorDeRed.cs`: `Connectivity`, salud, backoff, caché) y el
`ManejadorDeRed` no tienen prueba unitaria: dependen de MAUI y se verifican en el emulador (DISENO §10.4, R1–R5).
