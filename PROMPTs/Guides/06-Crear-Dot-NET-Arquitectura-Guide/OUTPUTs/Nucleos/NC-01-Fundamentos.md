# NC-01 — Fundamentos del ecosistema .NET

**Pregunta del lector:** ¿qué es lo que estoy armando?

## Conceptos a definir (en este orden)
1. **SDK de .NET** y CLI `dotnet`: la herramienta que crea, compila y ejecuta.
2. **Solución** (`.sln` / `.slnx`): agrupador de proyectos; no compila nada por sí misma.
3. **Proyecto** (`.csproj`): unidad de compilación; produce un **ensamblado** (`.dll`).
4. **Referencia de proyecto** (`<ProjectReference>`): «este proyecto puede usar los tipos públicos de aquel». Es la materialización física de una dependencia.
5. **Paquete NuGet** (`<PackageReference>`): dependencia hacia código de terceros.
6. **Espacio de nombres** (`namespace`): nombre lógico de los tipos; por convención sigue al proyecto y la carpeta, pero no crea dependencias.
7. **Tipo de proyecto / plantilla** (`classlib`, `webapi`, `blazor`, `razorclasslib`, `maui-blazor`).
8. **Inyección de dependencias (DI)**: el contenedor que entrega implementaciones a quien pide una interfaz.

## Preguntas guía
- ¿Por qué una referencia es una flecha con dirección? → porque el compilador solo deja usar tipos del proyecto referenciado, no al revés.
- ¿Un namespace anidado implica una referencia? → no; E1 a obtener compilando un tipo en `MyProject.Domain` que intenta usar `MyProject.Infrastructure` sin referencia.
- ¿Qué pasa si dos proyectos se referencian mutuamente? → el SDK lo rechaza (E1 a capturar).

## Evidencia necesaria (Laboratorio)
`dotnet --version`, `dotnet new sln`, `dotnet new classlib`, `dotnet sln add`, `dotnet add reference`, `dotnet list reference`, `dotnet build`; error de referencia circular; error CS0246 por tipo no referenciado.
