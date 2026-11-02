# Mesa «cascarón». Dictamen 3: editor bibliográfico y académico

> Dictamen ciego del 2026-11-01. Sólo se citan textos leídos. Rutas de FC relativas a `LAB/Lab-Documentos/Lab-Documentos/Concepts/Framework-Concept/`. TC = `Termino-Cascaron.md` y RFC = `Respuesta-FC-2026-11-01.md`, los dos en esta carpeta.

## Opción preferida: B + X (con un ajuste)

**Término principal (es/en):** «**contenedor nativo**» / ***native wrapper***.
- Equivalente secundario en inglés: *native shell* / *host app*. Es el par que FC lee como más estable (RFC:26).
- Concepto de clase: «**aplicación híbrida**» / ***hybrid app*** (TC:33, [B1][B2]).

**Contenido:** «**contenido web**» / ***web content***. Su unidad de entrega es el «**paquete de actualización OTA**» / ***OTA update bundle***. Esto es la opción X. Respaldo: Expo «over-the-air» [W2] (TC:70) y *update bundle*, que ya figura en el Anexo A (RFC:10).

**«Cascarón»:** queda como **aclaración informal**, no como término.

## Regla de uso

1. **Primera mención por documento o capítulo:** «contenedor nativo (*native wrapper*; en el equipo, informalmente, “cascarón”)».
2. **Menciones siguientes:** sólo «contenedor nativo». Si el contexto no deja dudas, «el contenedor».
3. **Glosario (Anexo A):** la entrada principal es «Contenedor nativo». Se agrega «Cascarón → ver Contenedor nativo (coloquial, origen en `00-Marco.md:44-48`)», como remisión y no como definición.
4. **Código:** no se renombra `FrameworkConcept.Shell` (RFC:12). *Shell* equivale a *native shell* en inglés y la regla «patrón en inglés, dominio en español» lo cubre. Cambiarlo cuesta mucho y no gana nada.
5. **Prohibido en el libro:** «App Shell model» como equivalente. Hoy figura en `README.md:30` y `MAUI-Framework-Developer-Guide.md:67`. Es el falso amigo que señala Google [W4] (TC:96; RFC:23).

## Evidencia

- **«Cascarón» no tiene respaldo:** ninguna de las 11 fuentes lo usa (TC:94).
- **«Native wrapper» tiene respaldo académico:** [B1] «also referred to as Native-wrapper» y [B2] «relegated to the native wrapper» (TC:47-48). «Contenedor nativo» es su glosa natural.
- **«Container app» suelto no tiene respaldo** (TC:98). Por eso se propone «contenedor nativo» y no «app contenedora».
- **«OTA» es el término neutral.** «Live Updates» es una marca (TC:72 y 102). CodePush se cita sólo como antecedente retirado (RFC:20).
- **Límite de «híbrida»:** la definición académica supone contenido empaquetado (TC:44). Por eso se califica la primera vez como «aplicación híbrida con contenido web remoto» (TC:78) y se aclara que no es Blazor Hybrid [M1].
- **Magnitud del uso actual:** medí 751 apariciones de «cascar[oó]n» en 130 archivos de Framework-Concept, con `grep -rio`, el 2026-11-01.

## Riesgos y mitigación

| Riesgo | Mitigación |
|---|---|
| Renombre masivo (751 apariciones): ruido en diffs y choque con las mesas DocsAsCode que trabajan ahora | Un ADR y un PR propio de FC, secuenciado después de las mesas en curso. No editar mientras tanto (RFC:26). |
| «Contenedor» se confunde con contenedor Docker/OCI en un repo de infraestructura | Usar siempre «contenedor nativo» en la primera mención de cada sección. Nunca «contenedor» solo cerca de temas de despliegue. |
| La opción A (mantener) perpetúa un término sin fuente y el falso amigo «App Shell» | Se descarta A. |
| La opción C (eliminar) borra la trazabilidad con la guía del PO y con el habla del equipo | Se descarta C. La remisión en el glosario conserva la trazabilidad. |
| Apple 2.5.2 y 4.7.2 | El término no cambia el riesgo regulatorio (TC:108-114). Evitar «sitio empaquetado» (TC:99). |
