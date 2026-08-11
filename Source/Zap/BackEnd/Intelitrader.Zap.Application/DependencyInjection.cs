using Microsoft.Extensions.DependencyInjection; 
using Intelitrader.Zap.Application.Messages.Services;
using MediatR;

namespace Intelitrader.Zap.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        services.AddScoped<IMessageService, MessageService>();

        return services;
    }
}