using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.DTOs;
using UsuariosApi.Data.Requests;
using UsuariosApi.Services.Contracts;

namespace UsuariosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly ICadastroService _cadastroService;

        public CadastroController(ICadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastrarUsuario([FromBody] CreateUsuarioDto createDto)
        {            
            Result resultado = _cadastroService.CadastrarUsuario(createDto);
            if (resultado.IsFailed) 
                return BadRequest(resultado.Reasons);
           
            return Ok(resultado.Reasons);
        }

        [HttpPost("ativa")]
        public IActionResult AtivarUsuario([FromBody] AtivaContaRequest request)
        {          
            Result resultado = _cadastroService.AtivarUsuario(request);
            if (resultado.IsFailed)
                return BadRequest(resultado.Reasons);

            return Ok(resultado.Reasons);
        }
    }
}
