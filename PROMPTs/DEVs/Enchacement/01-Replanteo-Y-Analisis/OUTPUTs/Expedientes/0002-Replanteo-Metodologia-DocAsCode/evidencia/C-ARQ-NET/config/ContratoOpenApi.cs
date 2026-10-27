using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;
using MovilidadUrbana.ApiWeb.Sessions;

namespace MovilidadUrbana.ApiWeb.Documentation;

/// <summary>Completa el contrato OpenAPI con lo que el código ya sabe y el generador no infiere.</summary>
public static class ContratoOpenApi
{
    /// <summary>Título del contrato y encabezado de sesión en cada operación.</summary>
    public static void Configurar(OpenApiOptions opciones)
    {
        opciones.AddDocumentTransformer((documento, _, _) =>
        {
            documento.Info.Title = "Movilidad Urbana — API";
            return Task.CompletedTask;
        });
        opciones.AddOperationTransformer((operacion, _, _) =>
        {
            operacion.Parameters ??= new List<IOpenApiParameter>();
            operacion.Parameters.Add(new OpenApiParameter
            {
                Name = SessionHeaderMiddleware.HeaderName,
                In = ParameterLocation.Header,
                Required = false,
                Description = "Identificador de sesión. Si falta, la respuesta trae uno nuevo en el mismo encabezado.",
                Schema = new OpenApiSchema { Type = JsonSchemaType.String, Format = "uuid" },
            });
            return Task.CompletedTask;
        });
    }
}
