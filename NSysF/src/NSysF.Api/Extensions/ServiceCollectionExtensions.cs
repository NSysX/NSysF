using MediatR;
using Microsoft.EntityFrameworkCore;
using NSysF.Application.Common;
using NSysF.Application.Infraestructure.Persistence;

namespace NSysF.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AgregaNSwag(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddOpenApiDocument(opt =>
            {
                opt.Title = "NSysF - Faltantes de Sucursales";
                opt.Version = "v1";
            });

            return services;
        }

        public static IServiceCollection AgregaPersistencia(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("defaultConnection");

            string? nombreCompleto = typeof(NSysFDbContext).FullName;


            services.AddDbContext<NSysFDbContext>(opt => opt.UseSqlServer(connectionString, c => c.MigrationsAssembly(
                     typeof(NSysFDbContext).Assembly.FullName)));

            return services;
        }

        public static IServiceCollection AgregaMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Application.Application));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));

            return services;
        }


    }
}
