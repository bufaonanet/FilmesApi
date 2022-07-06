using FilmesApi.Authorization;
using FilmesApi.Services;
using FilmesApi.Services.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace FilmesApi.Configurations;

public static class DependencyInjectionConfig
{
    public static IServiceCollection DependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IFilmeService, FilmeService>();
        services.AddScoped<ICinemaService, CinemaService>();
        services.AddScoped<IEnderecoService, EnderecoService>();
        services.AddScoped<IGerenteService, GerenteService>();
        services.AddScoped<ISessaoService, SessaoService>();
       
        services.AddSingleton<IAuthorizationHandler, IdadeMinimaHandler>();

        return services;
    }
}
