using Intelitrader.Application.Queries;
using Intelitrader.Domain.Services;
using Microsoft.OpenApi.Models; 

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Intelitrader - Desafio Harry Potter",
        Version = "v1",
        Description = "API de Cálculo de Descontos Otimizados."
    });
});
builder.Services.AddScoped<DescontoService>();
builder.Services.AddScoped<CalcularOrcamentoQuery>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Intelitrader API v1");
        options.RoutePrefix = "swagger";
    });
}
app.UseHttpsRedirection();
app.MapControllers();
app.Run();