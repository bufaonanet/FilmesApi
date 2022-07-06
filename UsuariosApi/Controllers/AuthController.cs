using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Requests;
using UsuariosApi.Services.Contracts;

namespace UsuariosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public AuthController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("login")]
        public IActionResult LogarUsuario(LoginRequest request)
        {
            Result resultado = _loginService.LogarUsuario(request);
            if(resultado.IsFailed) 
                return Unauthorized(resultado.Reasons);      

            return Ok(resultado.Reasons);
        }

        [HttpPost("logout")]
        public IActionResult DeslocarUsuario()
        {
            Result resultado = _loginService.DeslocarUsuario();
            if (resultado.IsFailed)
                return Unauthorized(resultado.Reasons);

            return Ok(resultado.Reasons);
        }

        [HttpPost("solicita-reset")]
        public IActionResult SolicitarResetSenhaUsuario(SolicitaResetRequest request)
        {
            Result resultado = _loginService.SolicitarResetSenhaUsuario(request);
            if (resultado.IsFailed)
                return Unauthorized(resultado.Reasons);

            return Ok(resultado.Reasons);
        }

        [HttpPost("efetua-reset")]
        public IActionResult ResetaSenhaUsuario(EfetuaResetRequest request)
        {
            Result resultado = _loginService.ResetaSenhaUsuario(request);
            if (resultado.IsFailed)
                return Unauthorized(resultado.Reasons);

            return Ok(resultado.Reasons);
        }
    }
}
