using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tecnicos.Data.Context;

namespace Tecnicos.Data.DI;
public static class DbContextRegistar
{
    public static IServiceCollection RegisterDbContextFactory(this IServiceCollection services)
    {
        services.AddDbContextFactory<TecnicosContext>(o => o.UseSqlServer("Name=SqlConStr"));
        return services;
    }
}
