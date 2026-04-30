using Intelitrader.Zap.Infrastructure;
using Intelitrader.Zap.Application;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info = new OpenApiInfo
        {
            Title = "Intelitrader SDDZap API",
            Version = "v1",
            Description = "Interface de Integração e Monitoramento Android Real-Time via Redis"
        };
        return Task.CompletedTask;
    });
});
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); 
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();