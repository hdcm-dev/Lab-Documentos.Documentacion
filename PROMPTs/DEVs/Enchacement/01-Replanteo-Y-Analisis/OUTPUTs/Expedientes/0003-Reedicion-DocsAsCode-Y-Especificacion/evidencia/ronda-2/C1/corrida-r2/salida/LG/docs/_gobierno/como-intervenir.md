---
doc_id: "{PREFIJO-PROCESO}-COMO-INTERVENIR"
doc_type: proceso
title: Cómo intervenir la documentación — Fábrica de Geometría
description: Instancia del proceso «Cómo intervenir» para LG y LGD, con los seis campos contestados por la adopción.
status: borrador
origin: ia-generated
confidence: media
owner: Product Owner
last_review: 2026-11-01
audience: [desarrollo, agente, po]
traces: [RD-05]
---

# Cómo intervenir la documentación — Fábrica de Geometría

> **Borrador de la adopción (A-06).** El prefijo de `doc_id` queda entre llaves hasta que exista el registro del
> proyecto (A-02, pendiente de la compuerta: ficha A-01, D-07 y D-09). Lo que depende de una decisión H abierta lo
> dice en su campo.

## 1. Escenario y clases activas

Panel con roles: dos papeles con permisos distintos, `Student` y `Administrator`
(`LG/src/GeometriaFactory.Domain/Values/Role.cs:12-19`). Clases activas: CL-01 a CL-09, CL-12 y CL-13; en baja
CL-10, CL-11 y CL-14 (detalle y motivos en la ficha A-01 §3).

## 2. Dónde vive cada pieza

| Pieza | Dónde |
| --- | --- |
| Especificación (CL-01) y ficha A-01 | `LG/SDD/Docs/`; la ficha, `LG/docs/_diseno/ficha-diseno-documental.md` |
| RRD (CL-02) | `LG/docs/_requisitos.md` |
| `AGENTS.md` (CL-03) | Raíz de `LG` (derivado de `SDD/Docs/Producto/11-Documentacion/Contrato-Agentes.md`) y raíz de `LGD` (propuesta sujeta a D-12) |
| Referencia de comentarios (CL-04) y contrato REST (CL-05) | En el código y en el build de `LG`; la generación está apagada o sin paso de extracción (ficha A-01 §3) |
| Ayuda al usuario final (CL-06) | Por rol, en el repo de la interfaz (`LG`); ruta pendiente |
| Documentación técnica (CL-07) | `LG/SDD/Docs/` (la carpeta por defecto `docs/tecnica/` no existe) |
| Índice para agentes (CL-08) | `LGD/ia-db/`, anclado por `LGD/ia-db/source.lock` |
| Expedientes, análisis y prompts (CL-09) | `LG/SDD/Expedientes/`, `LGD/Analisis/`, `LGD/PROMPTs/` (este último es del Product Owner: se lee, no se escribe) |
| Este proceso (CL-12) | `LG/docs/_gobierno/como-intervenir.md` |
| README y CHANGELOG (CL-13) | `README.md` y `changelog.md` de cada repo |

## 3. Guion de validación local

Hoy, en `LG`: `bash scripts/build.sh`, `bash scripts/test.sh`, `bash scripts/coverage.sh` (`LG/AGENTS.md:44-49`); en
`LGD`: `python .github/scripts/verificar.py` (`LGD/.github/workflows/verificar.yml:20`). El guion local de la
compuerta documental (A-07) está **pendiente**: depende de la copia de la compuerta de origen (D-09).

## 4. Workflow y runner de la compuerta

**Pendiente de D-09** (clase H). Default propuesto: copia con huella de la compuerta de origen, corrida con la
etiqueta de runner Linux del proyecto. Runners que el proyecto ya usa: `ubuntu-latest`
(`LG/.github/workflows/ci.yml:47`, `LGD/.github/workflows/verificar.yml:14`) y una etiqueta autohospedada,
`{etiqueta-runner}` (`LG/.github/workflows/e2e.yml:69`), cuya plataforma no está medida.

## 5. Quién decide y si hay delegación

- `LG`: el agente fusiona con los checks en verde y sin reserva; con reserva entrega el enlace y espera
  (`LG/AGENTS.md:65`).
- `LGD`: delegación asentada por escrito, con guarda G1–G4, techo de 20 minutos, excepciones y revocación
  (`LGD/README.md:11-28`).
- Fuera de esas delegaciones fusiona una persona, el Product Owner. Lo de clase H lo decide una persona (ficha
  A-01 §4).

## 6. Excepciones a la plantilla

- La compuerta corre como **copia con huella** (no el workflow reutilizable), si D-09 confirma el default: el
  registro de prefijos (A-02) es el `prefijos.txt` de esa copia y el esquema (A-03) su `esquemas/cuerpo.schema.json`.
  Ruta de la copia: pendiente de D-09.
- La documentación heredada de `LG/SDD/Docs/` usa el esquema de frontmatter del marco SDD
  (`LG/SDD/Docs/Producto/11-Documentacion/Contrato-Agentes.md:1-14`): avisa; lo nuevo bajo `docs/` bloquea cuando
  su línea de base sea 0 (D-08, D-10).
