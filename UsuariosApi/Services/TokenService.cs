using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosApi.Models;
using UsuariosApi.Services.Contracts;

namespace UsuariosApi.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;

    public TokenService(IConfiguration configuration)
    {
        _config = configuration;
    }

    public Token CreateToken(CustomIdentityUser usuario, string role)
    {
        Claim[] direitorUsuario =
        {
            new Claim("username", usuario.UserName),
            new Claim("id", usuario.Id.ToString()),
            new Claim(ClaimTypes.Role, role),
            new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString()),
        };

        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Token"]));

        var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: direitorUsuario,
            signingCredentials: credenciais,
            expires: DateTime.UtcNow.AddHours(1)
            );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return new Token(tokenString);
    }
}
