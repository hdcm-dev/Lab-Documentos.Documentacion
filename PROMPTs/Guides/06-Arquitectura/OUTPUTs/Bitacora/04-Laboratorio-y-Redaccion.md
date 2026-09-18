# Bitácora 04 — Laboratorio y redacción

**Fecha:** 2026-09-18
**Entregable:** `/LAB/Lab-Documentos/Guides/Arquitectura/Dot-NET-Arquitectura-Guide.md` v2.0.0 (1308 líneas) + `Dot-NET-Arquitectura-Lab/` (lab.sh, capturas, aserciones.log, MyProject/)

## 1. Laboratorio

Cuatro corridas completas de `Laboratorio/lab.sh` en `mcr.microsoft.com/dotnet/sdk:10.0@sha256:e1ffd2a9…` (SDK 10.0.400, runtime 10.0.11). La última: **68 PASS, 1 FAIL** (el provocado de L02, DR-06).

| Corrida | Resultado | Defecto encontrado | Corrección |
|---|---|---|---|
| 1 | 33 PASS / 32 FAIL | `dotnet remove … reference <carpeta>` no quita nada, responde «could not be found» y devuelve 0; el ciclo de L04 quedó armado y todo lo posterior falló con MSB4006. Además, `ok` buscaba en el encabezado de la captura, que repite el comando: L16/L17 dieron PASS falsos | L05 usa la ruta al `.csproj` y captura también la forma que falla (lección para §1.5); `ok`/`nok` leen solo la salida |
| 2 | 64 / 5 | `stop_api` no detenía la API: L18 y L21 consultaron una instancia vieja | Kill de grupo + `pkill` + espera de puerto libre; cada arranque verifica puerto libre; logs del servidor en `capturas/api-logs/` |
| 3 | 67 / 2 | L18: el JSON `[]` sin salto de línea quedaba pegado al pie de la captura | Pie con salto de línea previo |
| 4 | 68 / 1 | — | — |

## 2. Resultados que corrigen el plan o el veredicto

| Plan / veredicto | Captura | Qué se escribió |
|---|---|---|
| L10: CS0272 (veredicto §6) | **CS0200** «cannot be assigned to -- it is read only» | §3.3 con CS0200 |
| «el SDK rechaza el ciclo» (NC-01) | `add` con código 0; MSB4006 al compilar | §1.5 |
| — | `remove reference` con carpeta: falla silenciosa, código 0 | §1.5, regla práctica |
| — | SQLite devuelve `4500.0` donde la memoria devolvía `4500` | §5.3, interpretación rotulada |
| — | En contenedor, `--urls` pisa `HTTP_PORTS=8080` (advertencia) | §5.2, «qué puede cambiar» |
| Fuente para `.slnx` por defecto (DR-21) | La página de novedades del SDK 10 no lo menciona | Se afirma solo con L01 |
| Formas sustantivo-primero | Existen para `package` y `reference`; Microsoft las recomienda | §1.2 lo declara; se conserva la forma ejecutada |

## 3. Decisiones de redacción

- **Publicación del laboratorio junto a la guía** (`Guides/Arquitectura/Dot-NET-Arquitectura-Lab/`): las marcas «Salida registrada» deben resolverse desde el repositorio de la guía; `OUTPUTs/` vive en otro repositorio. No cambia el entregable (sigue siendo un documento); agrega su material de respaldo.
- **§5 recortado a 187 líneas** (DR-08: ≤190) pasando a prosa el bloque de `AddInfrastructure` y la salida de L17.
- **⚠ fuera de los títulos**: generaban anclas con guion final; quedan en el Anexo A.
- **Referencias verificadas por lectura directa** (2026-09-18): Martin 2012; Fowler 2002 (catálogo: Transaction Script, Domain Model, DTO, Repository), Fowler 2011 (CQRS); Bogard 2025; Microsoft Learn: soporte .NET, SDK 10, error handling APIs, persistencia (sección «Repositories shouldn't be mandatory»), `AddAsync` (remarks), Blazor Hybrid, Blazor configuration (advertencia de `wwwroot`), capitalización (Cwalina y Abrams 2008). Datos de licencias y soporte: informe AH-001 y L24.

## 4. Chequeos mecánicos (antes del ciclo 2)

| Chequeo | Resultado |
|---|---|
| Rutas `[Compilado]` existen en `Dot-NET-Arquitectura-Lab/` | 9/9 |
| Capturas citadas existen | 29/29 |
| Anclas internas | 100 % tras quitar ⚠ de títulos |
| Palabras prohibidas DR-18 / alias DR-12 | 0 (las 3 de «fundamental» están dentro de URLs) |
| Bloques `csharp` rotulados | 100 % |
| `#####` | 0 |
| Mermaid | 6/6 renderizan (`minlag/mermaid-cli`) |
| Extensión por `##` | §0 71, §1 108, §2 136, §3 98, §4 100, §5 187, §6 112, §7 143, §8 89, §9 74 |

## 5. Ciclo 2 (revisión del documento final) y cierre

**Mesa:** `Mesa/03-Ciclo2-Veredictos-y-Parches.md` + `Mesa/03-Ciclo2-Parches.json`. 8 informes a ciegas (`Mesa/Ciclo-2/`), 52 hallazgos → 26 raíces; 24 PROCEDE, 5 NO_PROCEDE/NO_APLICAR con motivo; ninguna decisión cerrada reabierta; sin escaladas. La corrida se interrumpió una vez por límite de sesión y se reanudó desde caché (4 agentes rehechos).

**Parches aplicados:** 93/93 (87 guía, 4 `lab.sh`, 2 bitácoras), cada fragmento encontrado exactamente una vez; P-SYNC (valores variables copiados de la corrida 5).

**Corrida 5 del laboratorio:** 74 PASS / 1 FAIL (el provocado). Nuevas aserciones: L12 verifica el nombre de cada prueba que falla; L15 captura el 404 de un id inexistente; L24 verifica la licencia leída del nuspec.

**Chequeos de cierre (todos en verde):** V-LIT 13/13 bloques con captura sin líneas sin respaldo (el árbol de §8.1 es un dibujo, no un extracto); rutas `[Compilado]` 9/9; capturas 31/31; anclas 0 rotas; referencias 0 huérfanas; palabras prohibidas y alias 0; bloques `csharp` 100 % rotulados; `#####` 0; Mermaid 6/6 renderizan; frontmatter válido (`prerequisites` 2, `traces` 27).

**Versión final:** 2.0.1, 1425 líneas. Extensión por `##`: §0 74, §1 121, §2 144, §3 113, §4 113, **§5 196 (D-03)**, §6 122, §7 143, §8 93, §9 75.

**Deuda declarada** (del bloque de cierre del jurado): D-01 tablas ✅/❌ no exigidas en toda decisión (§0.3 reescrito); D-02 letras 2026a–h sin criterio; D-03 §5 excede DR-08 por literalidad; D-04 rótulo «en tu equipo» en segunda persona por DR-11; D-05 extracto de L03 partido por política de recorte; D-06 escalón 2 sin práctica de laboratorio.

**Cierre:** por agotamiento de `ciclos_max` (2), sin S1/S2 abiertos; los parches S2 pasaron su verificación.
