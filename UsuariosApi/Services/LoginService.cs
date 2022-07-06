using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Requests;
using UsuariosApi.Models;
using UsuariosApi.Services.Contracts;

namespace UsuariosApi.Services
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<CustomIdentityUser> _signInManager;
        private readonly ITokenService _tokenService;

        public LoginService(SignInManager<CustomIdentityUser> signInManager,
                            ITokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogarUsuario(LoginRequest request)
        {
            var resultadoIdentity = _signInManager
                .PasswordSignInAsync(request.UserName, request.Password, isPersistent: false, lockoutOnFailure: false)
                .Result;

            if (!resultadoIdentity.Succeeded)
                return Result.Fail("Login Falhou");

            var identityUser = _signInManager.UserManager.Users
                .FirstOrDefault(u => u.NormalizedUserName == request.UserName.ToUpper());

            var role = _signInManager.UserManager
                .GetRolesAsync(identityUser)
                .Result
                .FirstOrDefault();

            var token = _tokenService.CreateToken(identityUser, role);

            return Result.Ok().WithSuccess(token.Value);
        }

        public Result DeslocarUsuario()
        {
            var resultadoIdentity = _signInManager.SignOutAsync();
            if (resultadoIdentity.IsCompleted)
                return Result.Ok().WithSuccess("logout do sistema");

            return Result.Fail("Logut falhouo");
        }

        public Result SolicitarResetSenhaUsuario(SolicitaResetRequest request)
        {
            CustomIdentityUser identityUser = RecuperaUsuarioPorEmail(request.Email);

            if (identityUser == null)
                return Result.Fail("Falha ao solicitar redefinição");

            string codigoDeRecuperacao = _signInManager
                .UserManager
                .GeneratePasswordResetTokenAsync(identityUser)
                .Result;

            return Result.Ok().WithSuccess(codigoDeRecuperacao);
        }

        private CustomIdentityUser RecuperaUsuarioPorEmail(string email)
        {
            return _signInManager
                .UserManager
                .Users
                .FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }

        public Result ResetaSenhaUsuario(EfetuaResetRequest request)
        {
            CustomIdentityUser identityUser = RecuperaUsuarioPorEmail(request.Email);

            IdentityResult resultadoResetPassword = _signInManager
                .UserManager
                .ResetPasswordAsync(identityUser, request.Token, request.Password)
                .Result;

            if (resultadoResetPassword.Succeeded)
                return Result.Ok().WithSuccess("Senha redefinida com sucesso");

            return Result.Fail("Falha ao resetar senha!");
        }
    }
}