using UsuariosApi.Models;

namespace UsuariosApi.Services.Contracts
{
    public interface ITokenService
    {
        Token CreateToken(CustomIdentityUser usuario, string role);
    }
}