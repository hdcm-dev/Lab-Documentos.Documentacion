# NC-02 — Dependencias y Clean Architecture

**Pregunta del lector:** ¿quién puede conocer a quién, y por qué?

## Conceptos
- **Regla de dependencia** (Martin, *Clean Architecture*, 2017; artículo «The Clean Architecture», blog 8th Light, 2012): el código fuente solo depende hacia adentro.
- **Anillos**: Entities, Use Cases, Interface Adapters, Frameworks & Drivers. Correspondencia práctica con proyectos .NET: Domain, Application, Infrastructure + WebAPI.
- **Contención = dependencia, no ubicación** (DC-1).
- **Inversión de dependencias** (DIP): la interfaz se declara adentro, la implementación vive afuera, el contenedor DI las une en el arranque (composition root = `Program.cs` de WebAPI).
- **Composition root**: único lugar que conoce todas las piezas.

## Preguntas guía
- ¿Por qué Infrastructure depende de Domain y no al revés si «Domain necesita guardar»? → DIP.
- ¿Por qué la WebAPI referencia Infrastructure si «no debería conocerla»? → solo para registrar DI; es el composition root.
- ¿Qué gano? → reemplazar la base o testear con un doble sin tocar Domain (E1: test con repositorio en memoria).
- ¿Qué pierdo? → más proyectos, más mapeos (enlace a NC-09).

## Relación con otros estilos
Hexagonal (Ports & Adapters, Cockburn 2005) y Onion (Palermo 2008) comparten la regla; la guía Documentacion-Tecnica/90-Modelos-de-Arquitectura/Hexagonal.md del repo la trata.

## Evidencia
Intento de referencia Domain→Infrastructure con Infrastructure→Domain existente → error de ciclo (E1). `dotnet list reference` por proyecto (E1).
