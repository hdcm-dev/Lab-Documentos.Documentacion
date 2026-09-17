# Crear guía de estudio — Sobre Guía de despliegue

> **Invocación**:
> - `Lee y ejecuta /IA/IA.SDD.Documentacion/PROMPTs/Guia-De-Estudio/Generacion-Documentacion-Informe-Despliegue/Generacion-Documentacion-Informe-Despliegue.md`
> Overview: generación de guía de técnica sobre informes de despliegue


---

# Contexto


Tengo un desarrollo propio de sistema con varios servicios. El sistema sirva para administrar audiencias.
- Por cada terminal se instala un **progrmaa desktop** que se comunica con un servicio que corre en background en la misma terminal. Este es para el operador que genera y graba la audiencia.
- El **servicio background** corre por cada terminal, recibe las peticiones del **programa desktop**. y se encarga de manejar las grabaciones de las camaras y subir los videos al servidor de archivos. Las camaras se conectan a la terminal. 
- Tambien hay alojado en el servidor un **servicio web** - front end- para los administrativos, visualizacion de las audiencias y las grabaciones
- Ambos, el progrmaa desktop , servicio background, , por cada terminal, se conecta a un servicio backend que corre en un server.  A su véz el estos dos suben videos y archivos a otro servidor de archivos.
- El **servicio backend** se conecta a una base de datos postgresql.
- El servidor de archivos puede ser ftp o TUS 
- La instalación del programa desktop y servicio background 
- Todos los sistemas son desaollados en .net. El front es desarrollado en .net 10 blazor paginas interactive service
- Se prevee la caida del programa desktop, pudiendo recuperar el estado de la audiencia y su continuación.
- Al cerrar la audiencia los videos quedan subiendose en background, permitiendo generar una audiencia nueva.
- Permite iniciar y grabar una audiencia aunque el servidor backend y front esten caidos.


Se me solicita:
```
Para poder comprender mejor el enfoque general, nos sería de mucha utilidad contar con un documento que describa la solución propuesta en términos de arquitectura, despliegue y resolución de requisitos funcionales y no funcionales.
```

---

# Objetivo

Generar una guía que describa claramente arquictectura, despliegue, resolución de requisitos funcionales y no funcionales:

- Formar criterio de redacción 
- Contar con un modelo formal de documento para presentar a entornos técnicos

---

# Solicitudes


1. Investigar según lo que se conoce en el ámbiente técnico, vocabulario, tipo de informe, tipo de redacción, estructura y forma de estructurar el informe, que se ajuste al tipo de informe solicitado según lo marcado en los objetivos y con eso captura esos elementos elaborando un documento guía que permita al lector comprender lo que se le pide y elaborar un informe que se ajuste a esos requisitos.
2. Agregar definiciones o glosario partiendo de la base de lo que se pide o menciona en objetivos.
3. Ten en cuenta diferentes contextos de desarrollos de sistemas, arquitecturas. pero enfocados en .net, centrado en el ejemplo que te di pero generalizando tambien para tener una compresión con mayor amplitud de concepto.
4. Utiliza recursos como definiciones, preguntas guias de como hacer tal cosa o que debo preguntarme para redactar tal o cual sección o titulo, agregando ejemplos de frases  que sirvan de referencia y formadora de criterio al redactor

---

# Restricciones

- Escribir únicamente dentro de `/IA/IA.SDD.Documentacion/Guias-de-Estudios/Documentacion-Informe-Despliegue`. No modificar el catálogo de tipos ni ningún componente del Prompt Framework.
- Del catálogo de tipos, tomar la tabla y la agrupación en siete familias. Ignorar su sección final sobre HomeHub: es un caso particular ajeno al marco conceptual y sus ejemplos no deben aparecer en la guía.
- Todo documento temático debe cruzarse con los escenarios y contextos definidos en el marco de referencia: no incorporar temas que queden fuera de él.
- No duplicar contenido entre documentos: si un concepto ya está desarrollado en otro, referenciarlo.
- No inventar estándares ni atribuir prácticas a fuentes que no se hayan verificado.
- No realizar commit, push ni pull request.
- Investigar las fuentes que hagan falta para sostener la calidad, sin límite de tiempo ni de tokens, dejando el avance en estado retomable ante cortes por consumo.

---

# Framework

## Profile

Aplicar:

- `/IA/IA.Prompts/PromptFramework/Profiles/Study-Guide-Documentation.md`
