using FluentResults;
using UsuariosApi.Data.Requests;

namespace UsuariosApi.Services.Contracts
{
    public interface ILoginService
    {
        Result LogarUsuario(LoginRequest request);
        Result DeslocarUsuario();
        Result SolicitarResetSenhaUsuario(SolicitaResetRequest request);
        Result ResetaSenhaUsuario(EfetuaResetRequest request);
    }
}