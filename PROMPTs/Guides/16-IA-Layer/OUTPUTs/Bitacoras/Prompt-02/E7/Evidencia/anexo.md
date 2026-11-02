
> **Anexo de datos del caso** (agregado en la ronda 3; ficticio como el resto):
> - Normas: ADR-003 fija EF Core sobre PostgreSQL; ADR-007 fija autenticación con cuenta institucional que trae la
>   sede como dato validado; ADR-011 dice que las ADR anteriores no se editan y que las especificaciones viven en
>   `docs/especificaciones/`. `docs/Glosario.md` es una tabla «término · definición · desde»; «sede» ya existe.
>   Las demás ADR no tocan IA, datos ni capas.
> - Roles: el líder técnico es ACT-ARQ; el área de sistemas es ACT-OPS; la responsable de datos de la red es
>   ACT-SEC; el jefe de bibliotecas fija los umbrales.
> - Umbrales (capacidad 1): categoría correcta en ≥ 80 % sobre 200 sugerencias históricas etiquetadas de nuevo
>   por dos bibliotecarios sin ver la propuesta; falsos duplicados ≤ 2 %. ACT-SEC autoriza usar esas 200 con
>   nombre y correo quitados.
> - Capacidad 2: métrica, respuestas iguales al conteo manual en ≥ 95 % de 40 preguntas reales; hoy no hay
>   pantalla de filtros por categoría.
> - El catálogo es de toda la red; existe `CatalogoService.Buscar(titulo, autor)`; otro formato no es duplicado.
> - `Controllers/` sirve vistas Razor renderizadas en el servidor; no hay otro cliente.
> - El servidor Ollama es sólo de esta aplicación y lo opera sistemas. La propuesta se calcula en segundo plano
>   al guardar la sugerencia.
