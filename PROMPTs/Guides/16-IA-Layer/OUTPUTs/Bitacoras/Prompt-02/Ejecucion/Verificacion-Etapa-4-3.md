# Verificación independiente final · Etapa 4 · lente 3: completitud contra el prompt 02

> Fecha 2026-11-02. Sólo lectura sobre la guía; no se arregló nada. Retomada tras un corte de ssh: no había
> un archivo previo de esta verificación. Rutas relativas a `Prompt-02/` salvo indicación; `{guía}` =
> `LAB/Lab-Documentos/Lab-Documentos/Guides/IA/Dot-Net-Integration-AI-Layer-Guide`.

## Índice

1. [Huellas](#1-huellas)
2. [Matriz pedido → estado](#2-matriz-pedido--estado)
3. [Compuertas re-corridas](#3-compuertas-re-corridas)
4. [Faltantes y pendientes](#4-faltantes-y-pendientes)

## 1. Huellas

- Libro `{guía}/Dot-Net-Integration-AI-Layer-Guide.md`: 4.434 líneas, sha256 `5ebbfdbb2497b9e2e197851f453cb335311ca1d6a301548249e1a74db87b5e12` (igual al de E11).
- Conocimiento: 599 líneas, sha256 `16ab8280be520387203440b669d3d1202825358c4560c467c4545372b262b126` (igual al de E11).

## 2. Matriz pedido → estado

| # | Pedido del prompt 02 | Estado | Evidencia |
|---|---|---|---|
| 1 | Coherencia texto ↔ ejemplos/demo | Hecho | `E1/Matriz-Afirmacion-Artefacto.md`, `E1/Cambios-Al-Libro.md`; `Ejecucion/E1.md` |
| 2 | Libro unificado con nombre exigido | Hecho | `{guía}` contiene un solo `.md` de libro; partes Prólogo–VII + Anexos A–H (libro l. 24–4419) |
| 2a | Jerárquico, índice, definiciones, ejemplos, mermaid, autocontenido/no delta | Hecho | índice l. 54 y ss.; Glosario Anexo C l. 3747; 25 bloques mermaid (libro) + 2 (Conocimiento); Verificación-Etapa-3 §«Deltas residuales»: sin «antes decía»; Anexo H es procedencia (D-10 a) |
| 2b | Ronda de revisión «como libro» | Hecho con un hueco de registro | `E10/01…06-F*.md` existen las seis; `Ejecucion/E10.md` tiene resúmenes de Fases 1, 2, 3, 5, 6 pero **no de Fase 4** (l. 5, 9, 13, 18, 21), aunque `E10/04-F4-Ortotipografia.md` existe |
| 2c | Sección inicial de Fundamentos | Hecho | Parte I, cap. 1 «Fundamentos del framework», libro l. 175–178 (P-1…P-10) |
| 2d | Seis intervenciones editoriales (tabla del PO) | Hecho | `E10/01-F1-Contenido.md` … `06-F6-Pruebas.md` |
| 3 | Conocimiento de especificación | Hecho, estado parcial | `{guía}/Conocimientos/…Specification.md` l. 1–14; l. 12 «Vigente (falta la revisión humana del checklist…)»; H-6 abierto (PO) |
| 3a | Aplicado a Geometría | Hecho | `Ejecucion/E5.md` (V1/V2, A0, prueba con modelo l. 79); cap. 16 libro l. 3087 |
| 3b | Aplicado al caso privado (sin publicarlo) | Hecho | `Ejecucion/E6.md` §1 (commit local en rama `g16/*`, sin push); `E8.md`: 0 menciones del caso privado; Conocimiento cita `[Caso N]` abstracto |
| 3c | Enriquecer guía/ejemplos con Geometría | Hecho | cap. 16 + 5/5 enlaces a Lab-Geometria (`Ejecucion/E8.md`); sin Example 18 por decisión D-27 b |
| 4 | Referencias y casos de industria | Hecho | Anexo D.13 l. 4091 (REF-209…213), tabla §14.1 l. 2694; `Ejecucion/E9.md` (9 URL en 200) |
| 5 | Mesa con los especialistas pedidos (MAUI, analistas, decisiones, doc. técnica, académicos editoriales, revisión bibliográfica) | Hecho | `01-Convocatoria.md` l. 36–43 (E-02, E-05, E-06, E-07, E-09); votos `03-Voto-*.md`; `04-Aprobacion.md` |
| 6 | Expedientes | Hecho | Geometría: expediente 0002 (`05-Plan-Integrado.md` l. 142–144); privado: expediente correlativo en su repo (`E6.md` §1.2) |
| 7 | Núcleos, cohesión, integración, bitácoras | Hecho | `Nucleos/N-01…N-10` + `00-Cohesion.md`; integración `E11/Manifiesto-De-Integracion.md`; `05-Plan-Integrado.md` |
| 8 | Ensayos con la API de modelos de [host-dev] («[api-de-modelos]») | Hecho con reserva de trazabilidad | ensayos en «estación 1» (Ollama 0.40.11, `qwen3.5:4b`): `E1/Ensayos.md` l. 77–78, `E11/Compuertas.md` l. 26 (`verificar.sh --con-modelo` rc 0, 10.546 s). La palabra «[api-de-modelos]» sólo aparece en `Nucleos/00-Cohesion.md` l. 119; no hay renglón que diga explícitamente que estación 1 es la API pedida (por R-PRIV se abstrae, `Relevamiento/R4-Infra-Modelos.md` l. 10) |
| 9 | Terminología del acta (contenedor nativo) | Hecho en el Conocimiento | Conocimiento l. 346; el libro no menciona el tema (0 coincidencias de «cascar/native shell/App Shell») |
| 10 | No enlazar la bitácora desde lo público | Hecho en libro y Conocimiento (0 «Bitacoras»); **falta** en `Examples/15-…/entradas/salidas-07.v1.json` y `Examples/15-…/Application/CongeladorDeSalidas.cs` l. 69 (ruta absoluta del registro) |

## 3. Compuertas re-corridas

| Compuerta | rc | Resultado |
|---|---|---|
| `tools/verificar-markdown.py guia <libro>` | 0 | 82 rutas, 4 exceptuadas |
| `tools/verificar-markdown.py arbol` | 0 | — |
| `tools/compuerta-referencias.sh` | 0 | 0 rotas en 21 archivos |
| `tools/compuerta-rpriv.sh` (sin clases privadas) | 0 | — |
| `tools/contar.sh` | 0 | 59.373 / 60.000 |
| `tools/medios/mermaid.sh` sobre el libro | 0 | — |

No re-corridos (sí en E11): intervalos, cabeceras, docs-guard, `verificar.sh --con-modelo`.

## 4. Faltantes y pendientes

1. Libro en estado «en revisión» (front matter l. 6 y l. 19): no hay cierre editorial declarado.
2. H-6 (PO): checklist D-23 no al 100 % y revisión humana del Conocimiento pendiente.
3. H-2 / `prefijos.txt`: archivos comunes de docs-guard (AI-4 91, esquema 12): coordinación.
4. Ruta absoluta de la bitácora en dos archivos del ejemplo 15 (requiere `v2`, `E11/Compuertas.md` l. 74).
5. `Ejecucion/E10.md` sin resumen de la Fase 4 (sólo hueco de registro).
6. Bitácora con 256 hallazgos R-PRIV: no integrable a repo público sin decisión del PO (`Ejecucion/E11.md`).
7. Trazabilidad explícita «estación 1 = API de [host-dev] pedida» ausente en lo publicable (se cubre sólo por abstracción).
8. Separador de miles en cifras de 4 dígitos (`E10/04-F4-Ortotipografia.md`): pendiente declarado.
