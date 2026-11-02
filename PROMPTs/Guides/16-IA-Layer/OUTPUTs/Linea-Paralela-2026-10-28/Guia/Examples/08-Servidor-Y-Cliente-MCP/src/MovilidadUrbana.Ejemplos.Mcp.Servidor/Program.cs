using MovilidadUrbana.Ejemplos.Mcp.Servidor.Mcp;

// Servidor MCP de Movilidad Urbana, solo. La consola cliente lo levanta en proceso; esto es para correrlo aparte.
var builder = ServidorMcp.CrearBuilder(args);
builder.AgregarServidorMcp();
var app = builder.Build();
app.UsarServidorMcp();
app.Run();
