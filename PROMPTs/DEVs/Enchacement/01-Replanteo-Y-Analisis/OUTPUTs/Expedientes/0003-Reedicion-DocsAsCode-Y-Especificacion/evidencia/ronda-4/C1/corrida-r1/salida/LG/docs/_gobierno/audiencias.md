---
doc_id: AUD-REGISTRO
doc_type: registro-audiencias
title: Registro de audiencias y regla de entrega
description: Audiencias con acceso propio de Fábrica de Geometría, su jerarquía, nivel y punto de cumplimiento.
status: borrador
origin: ia-generated
confidence: media
owner: Product Owner
last_review: 2026-11-02
audience: [desarrollo, po]
traces: [FIC-FICHA]
---

# Registro de audiencias

Fuente de la regla de entrega (A-12 de la [ficha](../_diseno/ficha-diseno-documental.md)). Perfil mínimo: roles,
jerarquía, nivel de acceso y la regla `nivel-vs-repo`. Ninguna extensión se activa: el producto no declara alcances
por aplicación ni por inquilino.

| ID | Audiencia | Acceso propio | `incluye:` | Nivel | Punto de cumplimiento | Par de entrega |
| --- | --- | --- | --- | --- | --- | --- |
| AUD-01 | alumno | Acceso firmado con papel `Student` emitido al iniciar sesión | plana | `producto` | Servidor: comprobación de papel en el servicio de datos y de sesión en el front | pendiente |
| AUD-02 | administrador | Acceso firmado con papel `Administrator` emitido al iniciar sesión | plana: no incluye a `alumno`, que tiene puntos propios que lo rechazan | `producto` | Servidor: comprobación de papel en los casos de uso del administrador | pendiente |

Las rutas y líneas que sostienen cada celda están en la sección 5 de la ficha. La jerarquía es plana; cambiarla es una
decisión de clase H del Product Owner.

## Piezas por nivel

| Pieza | Nivel | Punto de aplicación |
| --- | --- | --- |
| Documento OpenAPI y explorador del servicio de datos | `publico` | Servidor: la configuración de despliegue decide si se sirven |
| Microtexto de las pantallas con sesión | `producto` | Servidor: el front exige sesión antes de dibujar la pantalla |
| Corpus `SDD/` y `docs/` | `publico` | Repositorio público |

## Regla `nivel-vs-repo`

El repositorio es público: ninguna fuente de nivel `restringido` o `interno` vive acá. Una pieza de esos niveles irá a
un repositorio o submódulo privado.
