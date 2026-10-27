# Rojos provocados del actualizador (tramo A2, demo del expediente 0001)

| Campo | Valor |
| --- | --- |
| Fecha | 2026-10-26 |
| Autor | Constructor del actualizador (despacho A2) |
| Producto | `Demo/src/FrameworkConcept.Core/Update/` |
| Suite | `Demo/tests/FrameworkConcept.Update.Tests/` (NUnit, 96 pruebas) |
| Entorno | Contenedor `lab-e2e-maui-dev:net10` (SDK 10.0.400), lanzado con `scripts/contenedor.sh`, `dotnet test -c Release` |

## Cómo se provocó cada rojo

Las mutaciones no se escribieron sobre el árbol de la demo, sino sobre una **copia de trabajo idéntica** en
`~/fc-work/demo/actualizador/`. El guion `mutar.py` (en `~/fc-work/demo/actualizador-rojos/`)
cambia **una sola línea o bloque** del producto y comprueba que el texto original aparezca exactamente una vez. Después
corre la suite, guarda la salida y revierte la copia desde el original. Al terminar se comparó la copia con el producto
(`diff -rq`): son iguales. El verde final, sin mutación, dio 96 de 96.

El método es el que pide el despacho («cambiá una línea del producto, corré, mirá el rojo, revertí»). La única diferencia
es que se trabajó sobre una copia, así que un corte a mitad de camino no podía dejar el producto mutado.

Al terminar, la copia se borró. Para repetir las mutaciones:

1. Copiar la demo, sin `bin/` ni `obj/`, a `~/fc-work/demo/actualizador/`.
2. Correr `correr.sh [Mnn]`, que está en la carpeta de los logs.

## Los tres rojos anotados

Los tres se volvieron a correr en esta retoma, el 2026-10-26. Las salidas completas están en
`~/fc-work/demo/actualizador-rojos/retoma/`.

### Rojo 1: anti-rollback del contenido (P2, casos C06 y C07 de E-SEG-1)

Mutación en `Actualizador.cs` (`ConsultarContenidoAsync`):

```diff
-        if (actual is not null && version <= actual)
+        if (false)
             return version.CompareTo(actual) == 0
```

Salida (extracto):

```text
  Con error C06_VersionVieja [17 ms]
     Assert.That(resultado.Estado, Is.EqualTo(EstadoDeConsulta.Rechazado))
  Expected: Rechazado
  But was:  Preparado
  Con error C07_MismaVersion [22 ms]
     Assert.That(resultado.Estado, Is.EqualTo(EstadoDeConsulta.AlDia))
  Expected: AlDia
  But was:  Preparado
Con error! - Con error:     7, Superado:    89, Omitido:     0, Total:    96
```

Además fallan `Retirada_NoRebajaLaMonotonia`, `SinCambios_NoDescarga`, las dos de reanudación y
`DefinicionNueva_SinContenidoNuevo`. Sin la monotonía, un índice firmado y viejo vuelve a instalar una versión menor, que
es el «rollback attack» de TUF §5.5.

En C07 la demo no *rechaza* el replay: lo trata como «al día» (`AlDia`), porque es la misma versión que ya está
instalada. Lo que se comprueba es lo mismo que en E-SEG-1: el replay no se prepara ni se activa.

### Rojo 2: clave revocada (P2, condición de revisión 4)

Mutación en `FirmaEs256.cs` (`VerificadorDeFirmaEs256.Verificar`):

```diff
-        if (clave.Revocada)
+        if (false)
             return ResultadoDeVerificacion.Rechazo(MotivoDeRechazo.ClaveRevocada);
```

Salida (extracto):

```text
  Con error ClaveRevocada [143 ms]
     Assert.That(resultado.Motivo, Is.EqualTo(MotivoDeRechazo.ClaveRevocada))
  Expected: ClaveRevocada
  But was:  Ninguno
Con error! - Con error:     1, Superado:    95, Omitido:     0, Total:    96
```

La suite **sí** provoca el rojo «clave revocada» (P2, condición de revisión 4), así que no hace falta declarar
«compromiso = release del cascarón». Ese rojo se vio en este contenedor; en el runner de GitHub **no se verificó**.

### Rojo 3: rollback por marca «pendiente» (P2, «Rollback local»)

Mutación en `Actualizador.cs` (`PrepararAsync`):

```diff
-        if (puntero.Pendiente is { } pendiente)
+        if (puntero.Pendiente is { } pendiente && false)
```

Salida (extracto):

```text
  Con error SinListo_VuelveAPrevious [9 ms]
     Assert.That(arranque.Version, Is.EqualTo(V("1.0.1")))
  Expected: <1.0.1>
  But was:  <1.0.2>
  Con error Corte antes de anotar la fallida [8 ms]
     Assert.That(caughtException, expression)
  Expected: <FrameworkConcept.Update.Tests.CorteProvocadoException>
  But was:  null
Con error! - Con error:     9, Superado:    87, Omitido:     0, Total:    96
```

Además fallan `DobleFallaSinRed_EstadoTerminal`, `EstadoTerminal_SeRecuperaConUnaNueva`, `Fallida_NoSeReinstala` y los
cortes provocados del rollback. Si se ignora la marca, una versión que nunca llamó a `Listo(version)` sigue activa para
siempre.

## Todas las mutaciones corridas

Las mutaciones M01 a M18 se corrieron el 2026-10-25 contra el mismo código, que no cambió desde entonces. M01, M03 y M06
se repitieron el 2026-10-26 con el mismo resultado. Hay un log por mutación en `~/fc-work/demo/actualizador-rojos/`.

| Id | Qué se rompe | Archivo | Rojos (de 96) | Ejemplo de prueba que cae |
| --- | --- | --- | --- | --- |
| M01 | Versión estrictamente mayor | Actualizador.cs | 7 | C06_VersionVieja |
| M02 | `expires` | VerificacionDelIndice.cs | 3 | C08_IndiceVencido |
| M03 | Clave revocada | FirmaEs256.cs | 1 | ClaveRevocada |
| M04 | sha256 del paquete | Actualizador.cs | 2 | C05_PaqueteAlterado |
| M05 | Firma ECDSA (`VerifyData` → `true`) | FirmaEs256.cs | 4 | C04_OtraClave |
| M06 | Marca «pendiente» | Actualizador.cs | 9 | SinListo_VuelveAPrevious |
| M07 | Retiradas | Actualizador.cs | 2 | CurrentRetirada_VuelveAPrevious |
| M08 | Orden promover → puntero | Actualizador.cs | 3 | CorteEntrePromoverYPuntero_SeRecupera |
| M09 | `requires` del predicado | PredicadoDeCompatibilidad.cs | 4 | RequiresFueraDeRango |
| M10 | Piso del WebView (94) | PredicadoDeCompatibilidad.cs | 1 | WebView 90 con un paquete que pide 80 |
| M11 | Semilla como destino de rollback | Actualizador.cs | 1 | SemillaMasVieja_NoSeToca |
| M12 | Marca al volver a previous | Actualizador.cs | 3 | CorteTrasVolverAPrevious_EsDobleFalla |
| M13 | Definición nunca baja (P13.9) | PoliticaDeDefiniciones.cs | 1 | DefinicionMasVieja_Rechazada |
| M14 | Conservar definiciones con pendientes (P13.3) | PoliticaDeDefiniciones.cs | 1 | Conservables_IncluyeLasDePendientes |
| M15 | Retención current + previous | Actualizador.cs | 5 | CorteTrasVolverAPrevious_EsDobleFalla |
| M16 | Reanudación cada 15 minutos | Actualizador.cs | 1 | Reanudacion_RespetaLos15Minutos |
| M17 | Índice de otro canal | VerificacionDelIndice.cs | 1 | OtroCanal |
| M18 | Anotar la fallida antes de mover el puntero | Actualizador.cs | 1 | Corte antes de anotar la fallida |

El predicado de P3 tiene tres dimensiones, y en esta tabla cada una tiene al menos un rojo: el puente cae con M09 y con
las pruebas parametrizadas de `PredicadoTests.Puente`; `requires` cae con M09, y el motor con M10. Por eso no se dispara
la condición de revisión 3 de P3 («una dimensión nunca rechaza»). Para el puente no se corrió una mutación propia: su
rechazo se ve en los casos «bajo el piso» y «en el techo» de esa prueba.

## NO VERIFICADO

- Que esta suite corra en el runner de GitHub. Sólo se corrió en el contenedor local.
- El actualizador dentro del cascarón en el teléfono: este tramo no lo integra (es el tramo A2/A3 del Shell).
- Que `AlmacenDeContenidoEnDisco` sobreviva a un corte de energía real (por ejemplo, un `fsync` del directorio). Lo que
  se probó son cortes simulados por excepción y restos dejados en `tmp/`.
