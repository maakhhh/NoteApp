using Core.Domain;
using Core.Repositories;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddDbContext<NoteAppDbContext>();
        services.AddScoped<IRepository<Node>, NodeRepository>();
        services.AddScoped<INodeService, NodeService>();
        return services;
    }
}