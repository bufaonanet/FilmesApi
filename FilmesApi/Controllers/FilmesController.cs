using FilmesApi.Data.DTOs.FilmeDtos;
using FilmesApi.Services.Contracts;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmeService _filmeService;

        public FilmesController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto createDto)
        {
            ReadFilmeDto readDto = _filmeService.AdicionarFilme(createDto);

            return CreatedAtAction(nameof(RecuperarFilmePorId), new { readDto.Id }, readDto);
        }

        [HttpGet]
        [Authorize(Roles = "admin,regular", Policy = "IdadeMinima")]
        public IActionResult RecuperarFilmes(int? classificacaoEtaria)
        {
            IEnumerable<ReadFilmeDto> readDtos = _filmeService.RecuperarFilmes(classificacaoEtaria);

            return Ok(readDtos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id)
        {
            ReadFilmeDto readDto = _filmeService.RecuperarFilmePorId(id);
            if (readDto is null)
                return NotFound($"Nenhum filme encontrado com Id {id}");

            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDto updateDto)
        {
            Result result = _filmeService.AtualizarFilme(id, updateDto);
            if (result.IsFailed)
                return NotFound(result.Reasons);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Result result = _filmeService.DeletarFilme(id);
            if (result.IsFailed)
                return NotFound(result.Reasons);

            return NoContent();
        }
    }

}