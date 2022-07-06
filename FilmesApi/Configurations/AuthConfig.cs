using FilmesApi.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FilmesApi.Configurations;

public static class AuthConfig
{
    public static IServiceCollection AddAuthConfig(this IServiceCollection services, IConfiguration config)
    {

        services.AddAuthentication(auth =>
        {
            auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(token =>
        {
            token.RequireHttpsMetadata = false;
            token.SaveToken = true;
            token.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Token"])),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };
        });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("IdadeMinima", policy =>
            {
                policy.Requirements.Add(new IdadeMinimaRequirement(18));
            });
        });

        return services;
    }
}
