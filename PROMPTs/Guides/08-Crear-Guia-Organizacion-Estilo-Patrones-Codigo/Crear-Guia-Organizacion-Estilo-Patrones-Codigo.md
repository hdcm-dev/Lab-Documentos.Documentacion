# Crear guía de estudio —  Sobre Estilos-Patrones-Codigo

> **Invocación**:
> - `Lee y ejecuta /IA/IA.SDD.Documentacion/PROMPTs/Guia-De-Estudio/Crear-Guia-Organizacion-Estilo-Patrones-Codigo/Crear-Guia-Organizacion-Estilo-Patrones-Codigo.md`
> Overview: crea una referencias sobre estructuras de proyectos, nomenclaturas.

---

# Contexto

Lee `/IA/IA.SDD.Documentacion/Guias-de-Estudios/Organizacion-Estilo-Patrones-Codigo/README.md` es un compendio de `Apuntes`

---

# Objetivo

Poder describir claramente la estructura de un proyecto, que patrón se va a seguir y que nomenclatura estandar se va a seguir.

---

# Solicitudes

En base a las siguientes preguntas, respuestas que logres y siguiento los objetivos propuestos construye un documento en `IA/IA.SDD.Documentacion/Guias-de-Estudios/Organizacion-Estilo-Patrones-Codigo/61-Analisis-Integral/Analisis-Integral.md`. El contenido del texto debe permitir desarrollar las preguntas solicidas. Genera analisis, puntos de vistas, criterios de referencias, ejemplos con codigo, estructura y jerarquías.

1. ¿Qué ocurrio con:?

Los patrones DAO, MVC, Repository y las entidades DTO como objetos de transporte en api, Entity para persistencia, muy usado en la epoca de JDBC o ADO.NET. 
Muchos proyectos se estructuraban así:

```
Proyecto
|- Models
|     |- TurnoModel.cs  < Como model del entidad de persistencia
|
|- Repositories   < o DAOs
|     |-  TurnoRepository  <- extención de consultas etc del orm o si es DAO del jbdc o ado .net
|
|- Services
|     |- TurnoServices.cs <  para gestionar turnos
|
|- Controllers                 < controllers Rest API
|     |- TurnosController.cs
|
|- DTOs
|     |- TurnoDTO.cs
|
|- ViewModels               <   o PageModels en MAU .NET
|     |- TurnosViewModels.cs   < inyecta Services aquí
|
|- Views                       <   o Pages
|     |- TurnosVies
|
|- Program.cs
```

Donde tengo TurnoModel.cs como mi objeto plano de persistencia o Entity , y tambien es objeto de intercambio entre repositoy y services, 

¿Donde quedó esta organización bajo el modelo de capa actual?  Cual es la nomenclatura a utilizar en relación a ese modelo estructural

2. ¿Cómo aplican los modelos estructurales nuevos?. Su equivalencia respecto al modelo anterior. Da ejemplos de jerarquía de proyectos en varios modelos de capas (N capas / Layered, Hexagonal, etc)

3. ¿Cómo especifico a un equipo de desarrollo la estructura del proyecto que quiero desarrollar? ¿Y como defino su nomenclatura de espacios de nombres? Dame una respuesta y un ejemplos en diferentes modelos de proyectos multicapa. Si quiero respetar el modelo antiguo de la pregunta 1 o bien quiero a algo mas nuevo

4. Aparece Domain, Infraestructura, Contracts, etc, podes construir definiciones con ejemplos de código muy simple tomando o desarrollando el ejemplo dado en la pregunta 1.
Como podes definir el concepto de domains para indentificarlo claramente. 
El concepto de Contracts, se implementa con register en .net , suena  los objetos planos de java o pojos o pocos en c# 


---

# Restricciones

- Base integramente en primer lugar en la cadena de documentos propuesta por `IA/IA.SDD.Documentacion/Guias-de-Estudios/Organizacion-Estilo-Patrones-Codigo/README.md` y luego puedes tomar otras referencias.

- No modifiques ningun documento salvo el solicitado.

- No inventar estándares ni atribuir prácticas a fuentes que no se hayan verificado.

- No realizar commit, push ni pull request.

- Investigar las fuentes que hagan falta para sostener la calidad, sin límite de tiempo ni de tokens, dejando el avance en estado retomable ante cortes por consumo.