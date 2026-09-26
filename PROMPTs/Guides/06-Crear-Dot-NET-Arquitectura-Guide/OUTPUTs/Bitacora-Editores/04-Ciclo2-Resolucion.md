# Bitácora de editores 04 — Resolución del ciclo 2: fábricas, Guards y Values

**Fecha:** 2026-09-20 · **Presidente** (no vota) · **Insumos:** `Ciclo-2/Informe-Fowler-Factories.md` y `Ciclo-2/Informe-DotNet-Factories.md` (verbatim) · **Objeto:** guía v2.1.0 + corpus de contraste `PROG2/Geometria/Lab-Geometria/src/GeometriaFactory.Domain`

## 1. Pedido

Product Owner, 2026-09-20: «en el Domain del proyecto GeometriaFactory.Domain aparece el Entity discutido en el documento, pero también aparecen los Guards … en los entity el constructor pasa a ser privado y se crea una suerte de método tipo factory … podés ampliar este tema» + addendum sobre `Values/` y **la línea de pensamiento**: entidad → intención (Use Case) → hecho consumado (otra entidad); «¿dónde encajan Guards y Values en esa línea?».

## 2. Corrección de hecho antes de nada

El presidente afirmó en la conversación que `Work` y `Account` tienen **dos** constructores privados con propósitos opuestos. **Es falso** (E1: `grep -n 'private Work\|private Account\|new Work\|new Account'` → un solo `private Work()` l. 48, un solo `private Account()` l. 42; las fábricas usan inicializador de objeto). Los dos propósitos —materializar y constituir— conviven en el mismo constructor. Nada de esto entra a la guía en la forma equivocada; la corrección la trajo la comisión Fowler (hallazgo 1).

## 3. Decisiones (la mejor fundamentada queda aprobada; delegación del PO 2026-09-14)

| # | Cuestión | Decisión | Fundamento |
|---|---|---|---|
| D-1 | §5.4 afirma sin fuente que EF Core usa el constructor privado | **Se cita la documentación** que la comisión verificó y se agrega la medición (`ctor elegido = private Producto()`, `corrió 1 vez`) | P0 de Fowler; E1 de .NET |
| D-2 | El constructor sin parámetros como **costura del ORM** | Entra a §5.4 con las dos consecuencias medidas: sin él, `InvalidOperationException: No suitable constructor was found` en ejecución; y `{ get; }` sin setter **desaparece del modelo en silencio** (`propiedades mapeadas = Id,Precio`) | NET2-01/02/03, E1 |
| D-3 | Que el camino de materialización **no valide** | Se declara **Criterio de esta guía** con sus tres razones y la salida para E-C; ninguna fuente lo sostiene | Fowler P-03/P-04 |
| D-4 | El movimiento del constructor a la fábrica | Se nombra *Replace Constructor with Factory Function* (catálogo de refactorizaciones, verificado) y se muestra como **paso** (antes/después), no sólo como resultado | Fowler P-02 |
| D-5 | Excepción vs resultado | **Las dos entran, con criterio observable**: defecto de programación → excepción; rechazo esperable → resultado; el resto lo decide el contexto con las cuatro preguntas de Fowler. Se publican las dos mediciones que forman el par: 170× a favor del resultado (1.000.000 de rechazos: 4.340,6 ms vs 25,5 ms; 296 B vs 0 B) y **el resultado se puede ignorar sin un solo aviso** con `AnalysisMode=All`, la excepción no | Fowler P-06 + NET2-04/07, E1 |
| D-6 | *Notification* como tercera forma | Se nombra: `DomainResult` lleva **un** código y no una colección; para un formulario, la forma correcta es la *Notification* de Fowler (colección de motivos). Sin construirla en el laboratorio | Fowler, filo 6 |
| D-7 | `Admission` | Se nombra como **consulta sin efecto que devuelve un motivo** (CQS + *Notification* de un motivo) y se cierra el puente con `isValidForCheckIn` que §3.7 ya cita. **No** es *Specification* ni *Guard Clause* | Fowler 7, verificado |
| D-8 | `ConditionCode` | Entra a §7.2 d: **el contrato de error también es contrato**; códigos del vocabulario del dominio, sin texto de presentación («error codes rather than strings», *Notification*) | Fowler 8 |
| D-9 | `Values`: qué son | Se distinguen **tres especies**: conjuntos cerrados sin comportamiento (enums), catálogo de códigos (familia de los Guards) y valor con regla (*Value Object*). Se declara que el umbral «un valor se vuelve tipo cuando tiene una regla» es **más estricto que Evans y que PoEAA**: criterio propio, y se rotula también en §7.1 (hoy sólo en §3.8) | Fowler 9 |
| D-10 | Enum vs *Value Object* vs cadena | Entra la medición: `(WorkStatus)99` compila y no lanza; JSON sale como número; `CS8524` avisa y no es error; una fila con valor no declarado se relee con `IsDefined=False` **sin lanzar**, mientras `HasConversion<string>` falla fuerte. Conclusión: el único conjunto realmente cerrado es un *Value Object* con fábrica | NET2-11/13, E1 |
| D-11 | `const string` del catálogo | Una oración: se hornea en el ensamblado del consumidor (medido: el consumidor siguió imprimiendo el valor viejo tras recompilar sólo el catálogo). Riesgo real si `Domain` viaja como NuGet | NET2-12, E1 |
| D-12 | La línea de pensamiento del PO | Va a **§4.2**, que ya la tiene casi textual: se completa con las **dos preguntas transversales** (Values: «¿qué valores admite?»; Guards: «¿qué contesta cuando no puede?»), el matiz *Entity* vs *Domain Event* para el hecho consumado, y **un diagrama mermaid** | Fowler 10 |
| D-13 | ¿Se construye la variante? | **Sí**, `Variantes/FabricaYResultado/` como la propuso .NET (13 archivos, ≈420 líneas, capturas V04–V08): cierra en código NET2-01/02/03/04/11/13 y es la única forma de que D-1, D-2, D-5 y D-10 sean `[Compilado]` y no prosa | Cociente del ciclo 1: la variante que convierte más hallazgos en evidencia |
| D-14 | Presupuesto de la guía | **≤ +150 líneas y ≤ +6 bloques** en el .md (la guía ya creció 20 % en el ciclo 1). El volumen va al laboratorio, no a la página: lo que no entre se cita como captura | Criterio de corte del refutador del ciclo 1, aplicado (propio) |

## 4. Plan

1. **.NET** construye `Variantes/FabricaYResultado/`, compila con SDK 10.0.400 (0 advertencias) y deja V04–V08. No toca la guía.
2. **Editor** aplica D-1…D-12 en §3.1, §3.3, §3.4, §3.8, §4.2, §5.4, §5.6, §7.1, §7.2 d y el glosario, dentro del presupuesto D-14, citando las capturas nuevas. Corrige el CHANGELOG (v2.2.0: agrega secciones y una variante).
3. **Fowler** dictamina los parches de fidelidad post-aplicación.
4. Verificación: bloques contra archivos, anclas, presupuesto, compilación independiente. PR.

## 5. Sin segundo ciclo de comisiones

Las dos comisiones no se contradicen entre sí: la de Fowler aporta nombre y fuente, la de .NET aporta medición, y el único choque —cuántos constructores hay— es un hecho que se resolvió con un comando.
