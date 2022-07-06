using FilmesApi.Data.DTOs.GerenteDtos;
using FilmesApi.Services.Contracts;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GerenteController : ControllerBase
    {
        private readonly IGerenteService _gerenteService;

        public GerenteController(IGerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateGerenteDto createDto)
        {
            var readDto = _gerenteService.AdicionarGerente(createDto);
            return CreatedAtAction(nameof(RecuperarGerentePorId), new { readDto.Id }, readDto);  
        }

        [HttpGet]
        public IActionResult RecuperarEnderecos()
        {
            var readDto = _gerenteService.RecuperarGerentes();
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarGerentePorId(int id)
        {
            var readDto = _gerenteService.RecuperarGerentePorId(id);
            if (readDto == null)
                return NotFound($"Nenhum gerente encontrado com Id {id}");

            return Ok(readDto);           
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarGerente(int id)
        {
            Result result = _gerenteService.DeletarGerente(id);
            if (result.IsFailed)
                return NotFound(result.Reasons);

            return NoContent();
        }
    }
}
