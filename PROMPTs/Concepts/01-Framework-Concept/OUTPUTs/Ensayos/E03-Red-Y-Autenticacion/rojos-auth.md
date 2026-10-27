# Rojos provocados del constructor de autenticación (E03)

| Campo | Valor |
| --- | --- |
| Incremento | Folio 038: sesión del usuario con los mecanismos del sistema operativo (`DISENO-RED-Y-AUTENTICACION.md` §3, §5, §10.1) |
| Fecha | 2026-10-26 |
| Dónde | Copia de trabajo `~/fc-work/demo/e03/auth/Demo` (sin `bin/obj` compartidos), `scripts/contenedor.sh dotnet test tests/FrameworkConcept.Core.Tests -c Release` |
| Cómo | `~/fc-work/demo/e03/auth/rojos/correr.sh`: `sync.sh` trae la demo, aplica UNA mutación en la copia, corre Core.Tests y vuelve a sincronizar (la mutación nunca toca la demo) |
| Regla (P8) | Cada suite de `tests/FrameworkConcept.Core.Tests/Auth/` se vio en rojo por una fila invertida antes del verde |

## Rojo 1: máquina de sesión (`TransicionesDeSesionTests`)

**Mutación** (fila de §3.2 «`Bloqueada` + `DesbloqueoCancelado` → `Bloqueada`»): cancelar el diálogo del sistema abre la app.

```csharp
(EstadoDeSesion.Bloqueada, EventoDeSesion.DesbloqueoCancelado) => EstadoDeSesion.Activa,
```

**Rojo:** 1 de 202 (log `~/fc-work/demo/e03/auth/rojos/r1-desbloqueo-cancelado.log`).

```text
Con error UnaFilaPorRenglon(Bloqueada,DesbloqueoCancelado,Bloqueada)
  Expected: Bloqueada
  But was:  Activa
```

## Rojo 2: outbox con dueño (`PropiedadDelOutboxTests`)

**Mutación** (P4: «nunca se envía con otra identidad»): `PropiedadDelOutbox.PuedeEnviarse` deja de comparar el dueño de la
fila con el dueño activo.

```csharp
&& duenoDeLaFila.Length > 0      // en lugar de: && string.Equals(duenoDeLaFila, duenoActivo, StringComparison.Ordinal)
```

**Rojo:** 3 de 202 (log `~/fc-work/demo/e03/auth/rojos/r2-dueno-ajeno.log`).

```text
Con error ElDuenoSeComparaExacto
Con error ModoDispositivoNoEnviaFilasDeOtraInstalacionNiDeUnaCuenta
Con error NuncaSaleUnaFilaDeOtroDueno
  Expected: False
  But was:  True
```

## Rojo 3: PKCE (`FlujoOidcTests`)

**Mutación** (RFC 7636 §4.2: el desafío es base64url sin relleno): `FlujoOidc.Desafio` usa base64 común.

```csharp
public static string Desafio(string verificador) => Convert.ToBase64String(...)
```

**Rojo:** 1 de 202 (log `~/fc-work/demo/e03/auth/rojos/r3-pkce-sin-url.log`), con el vector del Apéndice B:

```text
Con error VectorDelApendiceBDeRfc7636
  Expected string length 43 but was 44. Strings differ at index 40.
  Expected: "E9Melhoa2OwvFrEMTJguCHaoeK1t8URWbuGJSstw-cM"
  But was:  "E9Melhoa2OwvFrEMTJguCHaoeK1t8URWbuGJSstw+cM="
```

## Verde

Después de cada mutación `correr.sh` vuelve a sincronizar la copia desde la demo. Core.Tests en verde dentro de
`ci-local.sh` completo (log `~/fc-work/demo/e03/auth/ci-auth-2.log`).

## Receptor: el token se valida de verdad

No es una suite unitaria: es la prueba contra el receptor en marcha (`fc-demo-receptor`, `--oidc-emisor`), script
`~/fc-work/demo/e03/auth/receptor/probar.sh`, salida en `probar.log` y motivos en `motivos.log`.

| Caso | HTTP | Motivo en el log del receptor |
| --- | --- | --- |
| Sin token | 401 | — |
| Access token válido de `encuestador` (cuerpo vacío) | 400 | pasó la autenticación; el cuerpo no valida |
| Firma alterada (último carácter) | 401 | IDX10511 firma |
| `id_token` (aud `fc-demo-app`) | 401 | IDX10214 audiencia |
| Access token de las 13:43 (vencido) | 401 | IDX10223 vencimiento |
| Token del realm `master` (otro emisor) | 401 | IDX10205 emisor |

En el emulador, las respuestas aceptadas guardan el `sub` del dueño (A4 y A8, `a4-respuestas.json`, `a8-respuestas.json`).
