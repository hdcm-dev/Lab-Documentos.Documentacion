---
doc_id: EXP0002-F133
doc_type: providencia
title: Criterios del escalón 1 (G-a) en Dado/Cuando/Entonces, con instrumento y evidencia esperada
status: vigente
origin: agent
confidence: alta en la transcripción de las aceptaciones de N10 §6; los umbrales de P-5 son criterio propio de la mesa (129 §4.3)
owner: presidencia de la mesa de Replanteo y análisis DocAsCode (despacho P30)
last_review: 2026-10-27
audience: [agentes que implementen E1, mesa de E1-G, bitacorista]
traces: [EXP0002-F129, EXP0002-F130, EXP0002-F131, EXP0002-F132, N09, N10, R07]
---

# 133 — Criterios del escalón 1

| Campo | Valor |
| --- | --- |
| Tipo | providencia (PRE-03 de `N10` §5; numerada 131 en el plan original, renumerada) |
| Fecha | 2026-10-27, anterior a la primera rama de E1 (G-a) |
| Autor | Presidencia (despacho P30) |

## Índice

1. [Definiciones](#1-definiciones)
2. [Criterios de compuerta (G-a…G-g)](#2-criterios-de-compuerta-g-ag-g)
3. [Criterios por unidad](#3-criterios-por-unidad)
4. [Umbrales provisionales P-5](#4-umbrales-provisionales-p-5)
5. [Corte](#5-corte)

## 1. Definiciones

- **Instrumento**: comando, corrida o lectura que produce la evidencia.
- **Evidencia esperada**: lo que queda en `evidencia/` (URL de corrida, SHA, salida de comando).
- **Par rojo/verde**: commit con defecto plantado en rama que no se fusiona (rojo) y su reversión (verde).
- **Conformación**: todo PR de E1 se fusiona por `CPA` (D08 FIRME, `130` §4), incluido el primer merge de cada repo.

## 2. Criterios de compuerta (G-a…G-g)

| # | Dado | Cuando | Entonces | Instrumento | Evidencia |
| --- | --- | --- | --- | --- | --- |
| G-a | este folio | se abre la primera rama de E1 | la fecha del folio es anterior | `git log` de la primera rama | fecha y SHA |
| G-b | el merge de cada unidad | corre `docs-guard`/`verificar` en `[self-hosted, i7infra-dev]` | la corrida es verde sobre el SHA del merge | API de Actions | URL y SHA |
| G-c | cada control bloqueante | se planta su defecto | la corrida da rojo | par rojo/verde | URL de ambas corridas |
| G-d | las `traces` de E1 | corre `traces-resolve` | 100 % resuelven | script | salida |
| G-e | el tutorial y la guía nueva | lee un lector sin contexto (P-LECT) | cero dudas sin respuesta | protocolo P-LECT | acta de lectura |
| G-f | todo lo versionado en repos públicos | corre el barrido S2 | sale vacío | `grep` de rutas de host, IPs privadas, usuarios y nombres privados | salida vacía |
| G-g | la lista VER-* aplicable (`R07` §5) | se revisa el cuerpo | 100 % de los obligatorios | lista marcada | tabla en el folio de E1-G |

## 3. Criterios por unidad

| Unidad | Dado / Cuando | Entonces | Instrumento |
| --- | --- | --- | --- |
| E1-U0a | el PR de arranque de Lab-Documentos | sección «Delegación del merge» con fecha, responsable y cita a `130` §2; `docs-guard` verde sobre `head.sha`; par rojo/verde de enlace roto; `self-hosted, i7infra-dev` sin `container:` | `grep`; API de Actions |
| E1-U0b | el PR de arranque de .Documentacion | sección de delegación; el job llamado corre en `i7infra-dev` (E-F12) o rige la copia con huella; par rojo/verde | registro del job |
| E1-U0c | el expediente y las bitácoras versionados | S2 vacío; `git ls-files EXP/evidencia/local \| wc -l` = 0; `verificar` verde | `grep`; `git` |
| E1-U1 | la guía actual saneada | `lychee --offline` exit 0; «adoptad» = 0 en la fila de `llms.txt`; línea de base 0 en PR-1 y PR-4 | `lychee`; `grep` |
| E1-U2 | `docs-guard` completo | par rojo/verde por control; AI-3 avisa sin bloquear; AI-4 avisa en el anexo; AK-7 rojo; carril semanal corrido a mano abre issue; E-F10 y E-F14 medidos; tag `docs-guard-v1.0.0` | Actions; API de issues |
| E1-U3 | la mini demo en `Examples/` | `traces-resolve` verde; `RN-LOC-01` rojo hasta corregir; diff de contrato 0 y 1 con plantado; «mini» ≤ 20 piezas, 1 workflow, < 15 min; P-LECT sin dudas; 0 archivos de Lab-E2E tocados | scripts; reloj del runner |
| E1-U4a | el esqueleto del cuerpo | `docs-guard` verde; diez campos + `description`; README con rutas (VER-G07); anexos enlazados desde el Mapa | validador de frontmatter |
| E1-U4b/c/d | cada tema | seis encabezados del Profile (VER-T01…T07); anterior/siguiente (VER-G08); APA con fecha y `ref-…`; plantilla «Cómo intervenir» con `scripts/ci-local.sh` (VER-A05); umbrales P-5 | validador; lectura |
| E1-U4e | `AGENTS.md` | existe, sus enlaces resuelven, excluido de AI-3 con huella | `lychee` |
| E1-U4f | la guía actual a `obsoleto` | tabla sección → `doc_id` completa; 0 URL sin fecha; `url-fecha` con prueba negativa | `grep`; control |
| E1-U5 | la ia-db reindexada | toda pieza nueva indexada; `base_commit` = merge de U4f | lectura del índice |
| E1-U6 | la propuesta a Lab-E2E (L7: sí) | carta con H-L07 y cambios de D19/D25; no toca código | `git diff --stat` |

## 4. Umbrales provisionales P-5

**[criterio propio]** (`129` §4.3): «estudio profundo» = cada tema cita ≥ 3 fuentes primarias con fecha y ≥ 1 ensayo
reproducible en `evidencia/`; «tendencias del mercado» = ≥ 2 adopciones públicas por práctica con fuente de ≤ 24
meses (TEM-01, TEM-03); «mini» = ≤ 20 piezas, 1 workflow, < 15 min.

## 5. Corte

`PROCEDE` si G-a…G-g cumplen; `NO_PROCEDE` ante un P0; `INSUFICIENTE` si falta una medida (vuelve una vez). La mesa de
E1-G se compone por `132` §3; el folio de E1-G incluye como anexo la propuesta al dueño del Profile (`131`, L6).
