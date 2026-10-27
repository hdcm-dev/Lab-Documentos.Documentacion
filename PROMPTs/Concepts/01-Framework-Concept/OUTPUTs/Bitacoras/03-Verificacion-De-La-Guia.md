# Bitácora 03 — Verificación de la guía Framework Concept (tramo A4)

> Cuadro hallazgo → acción de las tres revisiones de la guía en
> `/LAB/Lab-Documentos/Lab-Documentos/Concepts/Framework-Concept/`, del 2026-10-26. Las correcciones están en el
> árbol de trabajo, sin commit; la entrega por PR es el tramo A5 (folio 037).

## Índice

1. [Revisiones](#1-revisiones)
2. [Obligaciones normativas (R3 y perfil)](#2-obligaciones-normativas-r3-y-perfil)
3. [Lector sin contexto](#3-lector-sin-contexto)
4. [Coherencia y veracidad](#4-coherencia-y-veracidad)
5. [Verificación posterior](#5-verificación-posterior)
6. [Lo que queda abierto](#6-lo-que-queda-abierto)

## 1. Revisiones

| Id | Revisión | Insumo |
| --- | --- | --- |
| V-N | Obligaciones normativas | [R3](/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Concepts/01-Framework-Concept/OUTPUTs/Bitacoras/Relevamientos/R3-Reglas-De-Documentacion.md) y el perfil Study-Guide-Documentation |
| V-L | Lector sin contexto | Ejercicios 1 a 7 sobre una copia de `Demo/` (1–5 coincidieron) |
| V-C | Coherencia y veracidad | Cifras, rutas y comandos contra la demo y los ensayos |

## 2. Obligaciones normativas (R3 y perfil)

| # | Pri. | Hallazgo | Acción |
| --- | --- | --- | --- |
| N1 | P1 | Dos índices (`README.md` también `doc_type: indice`, `doc_id` fuera de prefijos) | `README.md` pasa a portada (`GUIA-PORTADA`, `doc_type: portada`) que remite al único índice; la tabla de documentos se mudó a `Developer-Guide.md` §3 |
| N2 | P1 | `Framework-APP.md` enlazado como parte del conjunto sin cumplir normas | Quitado del índice y de todo enlace (README, Developer-Guide §1, `01` §2.2, `08` §8); declarado insumo fuera del conjunto en `99-Anexos.md` §8 (X-1). No se editó |
| N3 | P1 | Lista de verificación sin marcar; falta anexo de revisión | `99-Anexos.md` §7 marcada con fecha y §9 «Revisión de consistencia» nueva, que remite a esta bitácora |
| N4 | P2 | `TEM-06` agrega §8 sin declarar la variante | Nota «Variante declarada» al inicio de `06`; registrada en `99-Anexos.md` §8 (X-2) |
| N5 | P2 | Sin Mermaid en `02`, `03`, `06` | `02` §2.5: secuencia de negociación cascarón ↔ contenido ↔ puente (con `Handshake.cs` L3–L10); `03` §2.6: taxonomía de líneas por vía de salida; `06` §8: flujo rama → `fw-ok` → merge → publicación |
| N6 | P2 | Fragmentos sin versión verificable | Las nueve líneas `*Fuente:*` llevan el `sha256` (12 dígitos) del archivo citado; el commit queda pendiente de A5 (`99-Anexos.md` §6) |
| N7 | P2 | Sin esqueleto de definición en `00` §2 y `08`; glosario no rotulado | `00-Marco.md` §2: cinco definiciones con «Cómo se aplica» y «Un caso» (5/5, escenas distintas); glosario rotulado como orientación (§1 y X-5); `08` declara que no define términos nuevos |
| N8 | P2 | Criterio propio sin marcar en `05`, `06`, `07` | «Criterio de esta guía» al inicio de §6 Criterios de calidad de los tres |
| N9 | P2 | ia-db y CHANGELOG sin actualizar | CHANGELOG: entrada 2026-10-26 en `/LAB/Lab-Documentos/Lab-Documentos/CHANGELOG.md`. ia-db: pendiente del tramo A5, registrado en `99-Anexos.md` §6 |
| N10 | P3 | Estructura plana sin carpetas de marco | Declarado como apartamiento X-3 |
| N11 | P3 | `08` rotulado `mapa` con `doc_id` fuera de prefijos | `doc_id: TEM-08`, `doc_type: tema`; `COHESION-GLOBAL` reemplazado en todas las trazas |
| N12 | P3 | Enlaces desde la raíz frente a OB-MD-08 | Precedencia declarada (X-4) |
| N13 | P3 | Folios y ensayos sin enlace individual | Tabla de enlaces a folios 004–038 y a E01–E03 en `99-Anexos.md` §4; glosario con enlaces |

## 3. Lector sin contexto

| # | Pri. | Hallazgo | Acción |
| --- | --- | --- | --- |
| L1 | P1 | Ejercicio 6 trabado por `salida/` copiada (P7 rechaza el paquete) | Paso previo `scripts/guion.sh limpiar` con el síntoma descrito; §6 explica cómo copiar sin `bin/`, `obj/`, `salida/` (`guion.sh` L37, L540–L544) |
| L2 | P2 | Ejercicio 7 nombra mal la segunda prueba | Dice «fuera de rango» (caso de `ElValidadorEquivaleAlCasoBase`, `DefinicionTests.cs` L64) y 2 con error / 209 superadas |
| L3 | P2 | Ejercicio 2 no dice qué pasa en el clon real | Tabla «Qué cambia según dónde lo corras» (copia, clon con `Demo/` en `main`, clon sin ella: NO VERIFICADO) con `ci-local.sh` L13–L16 |
| L4 | P2 | Siglas sin definir ni enlazar | Tabla «Cómo leer las referencias» en `Developer-Guide` §1; glosario suma arranque en frío, PO, folio, P1…P13, E01–E03, r01…r18, M-12/M-13; enlaces al glosario en §4.3 |
| L5 | P2 | §5.3 sin prefijo de comandos; Diagnóstico y «en frío» sin explicar | Filas 3, 6, 7 con `scripts/guion.sh`; intro de §5 con abrir en frío (`am force-stop`, `guion.sh` L329–L344) y ubicación de «Diagnóstico» (`ContenidoPage.xaml` L9 y botones) |
| L6 | P3 | Comentario del ejercicio 9 ambiguo | Reescrito: la privada del ejercicio 6 quedó en la copia; si se generan claves, rehacer publicar/definicion/firmar/semilla |
| L7 | P3 | Fecha 2026-10-27 01:11Z | Aclarado: UTC, 2026-10-26 22:11 hora argentina |
| L8 | P3 | Cómo copiar sin arrastrar salidas | Comando `rsync` con exclusiones en el encabezado de §6 |
| L9 | P3 | `MovilidadUrbana.MAUI` / Lab-E2E.WebBlazor quizá privado | **Descartado**: `https://api.github.com/repos/hdcm-dev/Lab-E2E.WebBlazor` responde 200 sin credenciales, es público |

## 4. Coherencia y veracidad

| # | Pri. | Hallazgo | Acción |
| --- | --- | --- | --- |
| C1 | P1 | `Framework-APP.md` nombra un repositorio privado | La guía ya no lo enlaza (N2); el archivo es del PO y no se edita: queda como decisión del PO en `99-Anexos.md` §6 y §8 |
| C2 | P2 | Enlace roto en `Framework-APP.md` | Igual que C1: fuera del conjunto, declarado en X-1 |
| C3 | P2 | `CTX-1` dice «teléfono físico sólo en E01» | Corregido: E01 y un intento anterior de E02 con TPR medido en el moto g42 (E02 §4.3), sin recorrido completo |
| C4 | P2 | Nombres de infraestructura (`i7infra-dev`, `i7infra-runner-dev`, `fc-android-emu-hpdev`) | **Descartado**: no son repositorios ni IPs, y están en el workflow publicado del mismo repositorio público (`framework-concept-demo.yml` L7, L12, L42); declarado en `99-Anexos.md` §7 |
| C5 | P3 | Cita abreviada `M-13-…patch` | Nombre completo en C-02 |
| C6 | P3 | Rutas plantilla tomadas como reales | Marcadas como plantilla en `03` §2.6 y `06` §8.4; `rutas.json` ya figuraba como desvío declarado |

## 5. Verificación posterior

- Enlaces: script sobre los 12 documentos del conjunto (sin `Framework-APP.md`): ningún enlace relativo, todos los
  destinos existen y todas las anclas resuelven contra los encabezados (incluido este archivo, creado al final).
- Frontmatter presente en los 12; Mermaid en todos los temas de flujo (`99-Anexos.md` sin diagrama, aceptado por V-N).
- `00-Marco.md`: «Cómo se aplica» = «Un caso» = 5.
- Ninguna ruta `/home/` ni nombre de repositorio privado en los 12 documentos.
- No se volvieron a correr los ejercicios tras las correcciones.

## 6. Lo que queda abierto

- Registro en la ia-db y commit de `Demo/`: tramo A5.
- `Framework-APP.md`: el PO decide si lo deja, corrige el nombre privado o lo saca de la carpeta.
- Paso 0 de la compuerta en un clon sin `Demo/` en `origin/main`: NO VERIFICADO.
- Ejercicios 8 a 10 (dispositivo, Chromium, Keycloak): no recorridos por el lector sin contexto.
