
Caso inventado para esta prueba; no sale de ningún proyecto real.

> **Red de Bibliotecas del Valle** (ficticia) tiene un servicio ASP.NET Core en producción desde hace tres años.
> Es un único proyecto con carpetas `Controllers/`, `Services/` y `Data/` (Entity Framework Core sobre
> PostgreSQL). Atiende cinco sedes; cada bibliotecario pertenece a una sede, y el administrador ve todas. Los
> lectores dejan **sugerencias de compra** en texto libre («quisiera la última novela de tal autora, en papel»);
> hoy un bibliotecario las lee, les pone una categoría temática del catálogo de 40 categorías y marca si el
> libro ya está en el catálogo. Guardan nombre y correo del lector.
>
> Quieren:
> 1. que un modelo **proponga** la categoría y si la sugerencia es un duplicado de un título del catálogo;
> 2. que el bibliotecario **pregunte en lenguaje natural** «¿cuántas sugerencias pendientes de historia tiene mi
>    sede este mes?»; ya existe `SugerenciasService.Listar(sede, estado, desde, hasta)`, sin filtro por categoría;
> 3. más adelante, que el modelo **avise por correo a todos los lectores** cuyos pedidos llegaron.
>
> El modelo correría en un servidor Ollama de la red (sin nube); es un piloto. El repositorio tiene
> `docs/adr/` con ADR-001 a ADR-014 y un `docs/Glosario.md` que pide agregar términos nuevos antes de usarlos.
> El error caro es una categoría equivocada que esconde la sugerencia de quien la busca, o un falso duplicado
> que la descarta. El jefe de bibliotecas fija los umbrales.
