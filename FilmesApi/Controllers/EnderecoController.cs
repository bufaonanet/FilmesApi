using FilmesApi.Data.DTOs.EnderecoDtos;
using FilmesApi.Services;
using FilmesApi.Services.Contracts;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto createDto)
        {
            var readDto = _enderecoService.AdicionaEndereco(createDto);

            return CreatedAtAction(nameof(RecuperaEnderecosPorId), new { readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaEnderecos()
        {
            var readDto = _enderecoService.RecuperarEnderecos();
            
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecosPorId(int id)
        {
            var readDto = _enderecoService.RecuperaEnderecosPorId(id);
            if (readDto == null)
                return NotFound($"Nenhum endereço encontrado com Id {id}");

            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDto createDto)
        {
            Result result = _enderecoService.AtualizarEndereco(id, createDto);
            if (result.IsFailed)
                return NotFound(result.Reasons);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEndereco(int id)
        {
            Result result = _enderecoService.DeletarEndereco(id);
            if (result.IsFailed)
                return NotFound(result.Reasons);

            return NoContent();
        }
    }
}
