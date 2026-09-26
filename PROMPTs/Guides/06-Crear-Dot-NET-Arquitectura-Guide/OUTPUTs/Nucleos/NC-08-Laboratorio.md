# NC-08 — Laboratorio

**Pregunta del lector:** ¿cómo compruebo cada concepto con la máquina?

## Principio
Toda salida mostrada en la guía proviene de una corrida registrada en `OUTPUTs/Laboratorio/`. Lo que no se ejecutó se rotula «fragmento ilustrativo».

## Entorno
- Lector: SDK .NET instalado, o contenedor `mcr.microsoft.com/dotnet/sdk:<versión>`.
- Redacción: mismo contenedor (el host no tiene `dotnet`).

## Recorrido propuesto (sujeto a la mesa)
1. Verificar SDK.
2. Crear solución y proyectos Domain, Application, Infrastructure, WebAPI (+ Contracts, + Tests).
3. Agregar referencias según la regla; listar referencias.
4. Romper la regla a propósito: ciclo, tipo no referenciado, setter privado.
5. Escribir Producto, repositorio, caso de uso, controller.
6. Compilar y correr la API; probar con `curl`: crear, listar, error de validación.
7. Test unitario del dominio y del caso de uso con repositorio en memoria (`dotnet test`).
8. Reemplazar la implementación del repositorio sin tocar Domain (demostración de DIP).

## Cada paso documenta
objetivo, comando, salida real, cómo leerla, qué concepto confirma.
