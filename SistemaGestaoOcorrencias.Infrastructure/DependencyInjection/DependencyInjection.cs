using Microsoft.Extensions.DependencyInjection;
using SistemaGestaoOcorrencias.Infrastructure.Persistence;
using SistemaGestaoOcorrencias.Infrastructure.Repositories;

namespace SistemaGestaoOcorrencias.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<MemoryContext>();
            services.AddSingleton<IOcorrenciaRepository, OcorrenciaMemoryRepository>();

            return services;
        }
    }
}