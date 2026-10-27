# Ensayo E-01 — *play testing*: documentar una pantalla siguiendo sólo la guía

| Campo | Valor |
|---|---|
| Fecha | 2026-10-26 |
| Quién | Comisión C-LECTOR (lector sin contexto) |
| Consigna | Escribir la página de ayuda de la pantalla «Editor de localidad» de MovilidadUrbana.MAUI usando **sólo** la guía `GUIA` (`/LAB/Lab-Documentos/Lab-Documentos/Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Sistema-Documentador-Tecnico-Guide.md`, Lab-Documentos `5d5c2b4`) y el código de la app (`/LAB/Lab-E2E.WebBlazor/Lab-E2E.WebBlazor/src/MovilidadUrbana.MAUI/`, commit `8fb4c3a`). Cada duda se anota sin preguntar |
| Por qué esta pantalla y no la mini demo | La mini demo todavía no existe. El jurado pidió centrar el ciclo 1 en la guía y en la ruta de lectura (condición K4, folio 004 §7). Lo que se prueba acá es **la guía**, aplicada a una app real |
| Regla de lectura | Una duda **con respuesta en el corpus** que el lector no encontró desde la guía es un hallazgo de navegación (`KB-privada/Rules/Rule-Mesa.md:199-204`). Una duda **sin respuesta** es un hueco de contenido |

## Índice

1. [Registro de dudas](#1-registro-de-dudas)
2. [Recuento](#2-recuento)
3. [Lo que el lector logró escribir](#3-lo-que-el-lector-logró-escribir)

## 1. Registro de dudas

Orden: el de la tarea, tal como un lector la recorre.

| # | Duda en el momento en que aparece | Qué dice la guía | ¿Respuesta en el corpus? | Clase |
|---|---|---|---|---|
| D01 | ¿Por dónde entro al material? | — | `README.md` del repo y `Guides/README.md` miden 0 bytes (E-03). La guía sólo aparece en la ia-db, por ruta en texto (`/LAB/Lab-Documentos/Lab-Documentos.Documentacion/ia-db/indexes/01_Documentacion-Tecnica.md:9`, `:19`) | Hallazgo de navegación |
| D02 | ¿La guía sirve para una app MAUI (cliente sin servidor)? | Su caso es un panel Blazor con roles (`GUIA:252-321`, `:325-533`); 0 menciones de MAUI, Android o móvil (`grep -ciE "maui\|android\|m[oó]vil"` → 0) | Sólo en la bitácora `R02:346` (fase 1), no en el material para lectores | Hueco |
| D03 | ¿Qué tipo de documento es la ayuda de una pantalla? | `FAM-USR` / `DOC-MANUAL` (`GUIA:199`). El enlace a la guía de familias está roto (`GUIA:189`, E-03) | Sí: `/LAB/Lab-Documentos/Lab-Documentos/Guides/Documentacion-Tecnica/Creacion-Guias-Tecnicas/README.md` | Hallazgo de navegación |
| D04 | ¿En qué repositorio y carpeta guardo la página? | Regla general: si cambia en el mismo PR que el código, va al repo de código (`GUIA:284`). El árbol de ejemplo es `src/GeometriaFactory.Web/Ayuda/` (`GUIA:380`) | La regla sí; la carpeta para un proyecto MAUI, no. La ia-db de Lab-E2E prohíbe tocar textos y `AutomationId` sin expediente (`R05` §8.4) | Hueco parcial |
| D05 | `roles` es obligatorio (`GUIA:405`); MovilidadUrbana no tiene roles. ¿Lo dejo vacío, lo omito, invento uno? | Nada | No (`R05` §4 lo constata; no lo resuelve) | Hueco |
| D06 | `traces` es obligatorio con `CU-…@versión` (`GUIA:407`); la app no tiene CU ni RN. ¿A qué trazo? | Nada | No: es la pregunta abierta N07-6 (`N07:142`) | Hueco |
| D07 | La tabla de derivación parte de las secciones de un CU (`GUIA:417-426`). Sin CU, ¿derivo del XAML, de la política o del servicio? | Nada | No | Hueco |
| D08 | La pantalla dice «Entre 3 y 60 caracteres» y la app guarda 70 (E-02). ¿Qué escribo? | «Reescrito desde el mensaje de la pantalla, no desde el código de error» (`GUIA:424`). No dice qué hacer cuando la pantalla y el comportamiento no coinciden | No. La regla «manda la evidencia» se cita para índices (`GUIA:430`), no para la ayuda | Hueco + hallazgo de producto |
| D09 | ¿Pongo capturas? ¿Cómo evito que envejezcan? | Nada sobre capturas en la ayuda | Hay 33 capturas reales (`/LAB/Lab-E2E.WebBlazor/Lab-E2E.WebBlazor/evidencia/2026-09-12-maui/`) y una idea de regenerarlas con Appium (`R05` §7, criterio propio) | Hueco |
| D10 | ¿Cómo llega la ayuda al usuario en MAUI? | El mecanismo es render en servidor con `HelpCatalog`, `/ayuda` y `<AyudaContextual>` (`GUIA:370-375`); la app «no … habla con ningún servidor» (`MovilidadUrbana.MAUI.csproj:3-6`) | Sólo en la bitácora `R02:346` | Hueco |
| D11 | ¿Creo carpeta por idioma? | Sí, `es/` desde el primer día, sin activar la localización (`GUIA:459`) | — | Respondida por la guía |
| D12 | ¿Qué valido antes de abrir el PR, y con qué comando? | Lista de chequeos, en su mayoría «Propuesto» (`GUIA:463-472`); ningún comando para quien escribe | No. En la prueba de concepto, el validador corre al arrancar la app, no en CI (`R02` §6.7) | Hueco |
| D13 | ¿Cómo abro el PR y quién lo aprueba? | Actores por fase, «criterio de este apunte … y no una matriz que la guía declare» (`GUIA:635-644`) | No hay `CONTRIBUTING`, `CODEOWNERS` ni `AGENTS.md` en Lab-Documentos ni en Lab-E2E.WebBlazor (`find -maxdepth 3`). Existe `.github/pull_request_template.md` sin versionar (`git status` → `?? .github/`), escrito para otra unidad del repo | Hueco |
| D14 | ¿Qué `status` lleva la página? | La convención es `vigente \| borrador \| obsoleto` (`GUIA:599`); la guía misma declara `status: draft` (`GUIA:5`); para la ayuda, «heredado del PR» (`GUIA:599`) | La convención, sí (`Creacion-Guias-Tecnicas/00-Marco-de-Referencia/Convenciones.md`) | Hallazgo (contradicción interna) |
| D15 | ¿Llevo `owner` y `last_review`? | La tabla del contrato no los tiene (`GUIA:401-409`); dos secciones después se propone agregarlos (`GUIA:609`) | Sí, en la propia guía, pero en otra sección | Hallazgo (contradicción interna) |
| D16 | ¿Qué son `ACT-10`, `FAM-USR`, `CU-`, `RN-`? | No están en el glosario (`GUIA:696-713`) | Sí, en `Creacion-Guias-Tecnicas/00-Marco-de-Referencia/` (destino de los enlaces rotos) | Hallazgo de navegación |

## 2. Recuento

| Clase | Cantidad | Dudas |
|---|---|---|
| Con respuesta en el corpus que el lector no alcanzó desde la guía (hallazgo, `Rule-Mesa.md:202-204`) | 5 | D01, D03, D14, D15, D16 |
| Sin respuesta en el material para lectores (hueco de contenido) | 10 | D02, D04 (parcial), D05, D06, D07, D08, D09, D10, D12, D13 |
| Respondidas por la guía | 1 | D11 |

**Dónde se corta la tarea.** El lector pudo escribir el cuerpo de la página (sección 3) porque el código es claro y la tabla de derivación (`GUIA:417-426`) se adapta. No pudo completar el frontmatter obligatorio (D05, D06), no supo dónde guardar el archivo (D04) ni cómo validarlo y proponerlo (D12, D13). La tarea queda en un **borrador sin destino ni circuito**.

## 3. Lo que el lector logró escribir

Fragmento ilustrativo: no se guardó en ningún repositorio. Los campos marcados `¿?` son las dudas sin respuesta.

```markdown
---
title: Agregar o editar una localidad
description: Cargar nombre, provincia, código postal y habitantes; eliminar una localidad.
roles: ¿?            # D05: la app no tiene roles
order: 20
traces: [¿?]         # D06: no hay CU; ¿LocalidadRules.cs:11-16?
topic: editor-de-localidad
---

# Agregar o editar una localidad

Sirve para dar de alta una localidad nueva o corregir una existente. Las localidades
que cargues aparecen después en el paso 1 de la encuesta.

## Antes de empezar

Estar en la pestaña **Localidades**.

## Pasos

1. Tocá **Agregar** (o tocá una localidad de la lista para editarla).
2. Completá **Nombre** (por ejemplo, «Goya»), elegí la **Provincia**, escribí el
   **Código postal** (4 dígitos) y la cantidad de **Habitantes** (1 o más).
3. Tocá **Guardar**. Vuelve a la lista con el aviso «Se agregó la localidad Goya.»

## Si algo sale mal

| Mensaje que ves | Qué hacer |
|---|---|
| «El nombre debe tener al menos 3 caracteres.» | Escribí un nombre más largo. |
| «Ya existe una localidad con ese nombre en la provincia.» | Cambiá el nombre o la provincia: no se repite el par. |
| «El código postal debe tener 4 dígitos.» | Escribí exactamente cuatro números. |
| «Ingrese una cantidad de habitantes mayor a cero.» | Escribí un número entero de 1 en adelante. |

## Eliminar una localidad

Abrí la localidad y tocá **Eliminar localidad**. La app pregunta
«¿Eliminar Goya? Esta acción no se puede deshacer.»; tocá **Eliminar** para confirmar.

<!-- D08: la pantalla promete «Entre 3 y 60 caracteres»; la app acepta hasta 80
     (E-02). ¿Se escribe 60 (lo que dice la pantalla) o se informa el defecto? -->
```

Procedencia del texto: rótulos y textos de `Pages/LocalidadEditorPage.xaml:19-64`; mensajes de `Application/Localidades/LocalidadService.cs:25,57,78-91`; confirmación de `Presentation/Localidades/LocalidadEditorViewModel.cs:104-108`; requisitos de `Application/Localidades/LocalidadPolicy.cs:15-24`.
