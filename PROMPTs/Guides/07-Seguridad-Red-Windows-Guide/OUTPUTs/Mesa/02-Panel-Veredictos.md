# Mesa evaluadora — Panel a ciegas, veredictos y parches

**Fecha:** 2026-09-17
**Artefacto:** `Beginning-Security-Windows-Network-Guide.md` v1.0 (1245 líneas)
**Ciclo:** 1 de máx. 2

---

## 1. Chequeos mecánicos previos (§5.1.a del marco)

| Chequeo de coherencia | Resultado |
|---|---|
| Índice ↔ secciones (12 caps + 3 apéndices) | OK: los 12 anclajes existen |
| Términos usados antes de definirse | OK tras revisión: cada término tiene su §def |
| Toda afirmación técnica con evidencia (regla del prompt) | Parcial → ver H-02 |
| Comandos con "qué se espera ver" + "cómo interpretarlo" | OK en todos los bloques operativos |
| Preguntas guía con respuesta por capítulo | OK (2 por capítulo) |
| Gráficos mermaid donde aportan | OK (7 diagramas) |
| Glosario sin solapamiento | OK |

---

## 2. Informes del panel (a ciegas, en paralelo)

Cada especialista declara además "lo que revisé y está bien" (máx. 3).

### E-SeguridadWin (seguridad en redes Windows)
- **Bien:** eventos 1102/104/4719 correctos; Logon Type 10 = RDP correcto; árbol de procesos como método anti-LOLBin, correcto.
- **H-01 (S2, E3):** el filtro regex de IP privada en §7.2 usa `172.(1[6-9]|2[0-9]|3[01])` — `2[0-9]` incluye 172.20–172.29 correctamente, pero también deja pasar como "no privada" nada indebido; sin embargo el bloque `Where-Object` de §5.4.1 depende del idioma del SO ("Tipo de inicio de sesión" / "Logon Type") y puede fallar silenciosamente. Ya está mitigado con el `|` bilingüe, pero conviene advertirlo.
- **H-05 (S3, E2):** §9.4 menciona 4662 y 4769 pero no aclara que requieren auditoría específica activada; un lector puede concluir "no aparece nada, no hay ataque".

### E-Didáctica
- **Bien:** progresión de dependencia conceptual; preguntas guía formadoras de criterio; laboratorio con ejercicios ataque/rastro.
- **H-02 (S2, E2):** la regla del prompt "no inventar información / evidencia verificable" está cumplida en prosa, pero varias afirmaciones fuertes (Prefetch conserva ejecuciones tras borrado del .exe; SRUM guarda volumen histórico) no llevan cita puntual. Recomienda anclar en la bibliografía ya presente o marcar como "comportamiento documentado del SO".
- **H-06 (S3, E3):** falta una "ruta de lectura" como la de UX-UI-Guide §1.3; el lector novato agradece un camino sugerido vs. lectura completa.

### E-Edición (material bibliográfico)
- **Bien:** metadatos APA; estructura jerárquica; glosario alfabético con referencias cruzadas.
- **H-03 (S3, E2):** inconsistencia de versión en el bloque de metadatos ("Estado: En revisión de mesa") — correcto durante el ciclo, pero debe pasar a "Aprobado" al cierre si la mesa aprueba.
- **H-07 (S4, E2):** algunas URLs de bibliografía son de secciones que cambian; aceptable para APA con recurso web.

### Lector novato (implementador ingenuo)
- **H-04 (S2, E3):** en §5.7 y §10.5 se usa `E:\evidencia` sin decir *antes* que hay que crear esa carpeta o conectar un pendrive; un novato ejecuta y `wevtutil epl` falla con ruta inexistente. Falta un paso previo explícito.
- **H-08 (S3, E3):** §9.2 usa `Get-ADGroupMember` que no existe en un servidor sin el módulo RSAT/AD; ya se da el fallback `net group`, pero recién al final de la sección; el novato choca primero.

### Abogado del diablo
- **H-09 (S3, E3):** la guía asume implícitamente que el investigador tiene credenciales de administrador legítimas sobre el servidor comprometido. No se explicita que, si el atacante cambió credenciales o el equipo está aislado, el acceso mismo puede ser un problema. Menor para el alcance introductorio, pero conviene una línea.

### AH-001 (ética / doble uso)
- **Bien:** encuadre de autorización al inicio del §11; laboratorio aislado obligatorio; par ataque/rastro con fin defensivo; P. de §11.7 sobre "usar con cuidado en la red real" respondida con "no sin autorización".
- **H-10 (S2, E4):** el aviso de uso responsable está al inicio del documento y al inicio del §11, correcto. Pero el §11.4 muestra `nmap` contra una IP concreta sin repetir, *en el propio bloque*, que es una IP de laboratorio; ya dice "contra su propia VM (aquí 10.10.10.5)". Cumple. Sin hallazgo nuevo; se confirma conforme.

---

## 3. Consolidación (relator) y veredictos del jurado

Voto por hallazgo (5 jueces: Evidencia/Impacto/CostoBeneficio/Coherencia/Riesgo).

| Hallazgo | Sev | Resumen | Veredicto | Conteo |
|---|---|---|---|---|
| H-02 | S2 | Afirmaciones sin ancla puntual | PROCEDE | 5-0 |
| H-04 | S2 | `E:\evidencia` sin paso de creación previa | PROCEDE | 5-0 |
| H-05 | S3 | 4662/4769 sin aclarar que requieren auditoría | PROCEDE | 4-1 |
| H-08 | S3 | `Get-ADGroupMember` sin RSAT choca antes del fallback | PROCEDE | 4-1 |
| H-06 | S3 | Falta ruta de lectura sugerida | PROCEDE | 3-2 |
| H-01 | S2 | Dependencia de idioma en filtro de Logon Type | NO_PROCEDE | 1-4 (ya mitigado con `|` bilingüe; se añade nota menor vía H-05 pattern) |
| H-03 | S3 | Estado del doc a "Aprobado" al cierre | PROCEDE | 5-0 (trivial) |
| H-09 | S3 | Supuesto de acceso admin no explicitado | PROCEDE | 3-2 |
| H-07 | S4 | URLs de sección | NO_PROCEDE | lote S4 |
| H-10 | — | Confirmado conforme | — | sin acción |

---

## 4. Parches diseñados y aplicados (cuerpo auditor)

| Parche | Cubre | Capa | Cambio | Verificación |
|---|---|---|---|---|
| P-01 | H-04 | doc | Agregar en §4.4 y §5.7 la creación previa de la carpeta de evidencia | grep de `New-Item .*evidencia` antes del primer uso de `E:\evidencia` |
| P-02 | H-02 | doc | Anclar Prefetch/SRUM/MFT a bibliografía (Zimmerman 2023; Microsoft) marcándolas como comportamiento documentado | las 3 afirmaciones citan fuente |
| P-03 | H-05, H-08 | doc | Añadir nota en §9.2/§9.4 sobre auditoría requerida y sobre módulo RSAT antes del comando | texto presente en ambas secciones |
| P-04 | H-06 | doc | Añadir §1.6 rutas de lectura | sección existe |
| P-05 | H-09 | doc | Línea en §4.1 sobre supuesto de acceso legítimo | texto presente |
| P-06 | H-03 | doc | Estado → Aprobado al cierre del ciclo | metadato actualizado |

Los parches se aplican sobre el entregable. Ver §5 de este registro para verificación.
