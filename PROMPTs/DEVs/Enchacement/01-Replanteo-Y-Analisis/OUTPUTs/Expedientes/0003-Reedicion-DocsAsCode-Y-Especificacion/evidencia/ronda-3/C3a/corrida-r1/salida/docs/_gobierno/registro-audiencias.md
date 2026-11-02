---
doc_id: AUD-REGISTRO
doc_type: registro-audiencias
title: Registro de audiencias de Colmenar
description: Fuente de las audiencias de entrega; una fila por audiencia con nivel, alcance, superficie e incluye.
status: borrador
origin: ia-generated
confidence: media
owner: equipo de la app
last_review: 2026-11-02
audience: [humano, desarrollo, po]
traces: [FIC-FICHA]
---

# Registro de audiencias de Colmenar

Perfil mínimo más las extensiones tipo de alcance, superficie y columna `cumple`. La jerarquía (`incluye`) es una
propuesta: fijarla es una decisión de una persona.

| Audiencia | Nivel | Alcance | Superficie | Incluye | Punto de aplicación | Cumple |
| --- | --- | --- | --- | --- | --- | --- |
| publico | publico | ninguno | sitio público, paquete instalable | — | repositorio y build | pendiente |
| productor | producto | sus apiarios | Android (tienda) | publico | servidor | pendiente |
| peon | producto | visitas que carga | Android (instalador directo) | publico | servidor | pendiente |
| tecnico-sanitario | producto | todos los apiarios, tratamientos y alertas | iOS (tienda) | publico | servidor | pendiente |
| administracion | restringido | panel completo, tambores | Windows (instalador interno) | publico | servidor | pendiente |
| inspector | pendiente | tratamientos y alertas de 24 meses | pendiente | publico | servidor | pendiente |
| desarrollo | interno | repositorio | repositorio | publico | repositorio | pendiente |

Regla `nivel-vs-repo`: este repositorio es público; ninguna fuente de nivel `restringido` o `interno` vive en él. Lo
que viaja en la app instalada es `publico`. Los kilos y precios no se documentan acá: los filtra la API.
