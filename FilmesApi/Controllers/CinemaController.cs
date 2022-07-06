using FilmesApi.Data.DTOs.CinemaDtos;
using FilmesApi.Services.Contracts;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaService _cinemaService;

        public CinemaController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto createDto)
        {
            ReadCinemaDto readDto = _cinemaService.AdicionarFilme(createDto);
            
            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarCinemas([FromQuery] string nomeDoFilme)
        {
            IEnumerable<ReadCinemaDto> readDtos = _cinemaService.RecuperarCinemas(nomeDoFilme);            

            if (readDtos is null || !readDtos.Any()) 
                return NotFound("Nenhum Cinema encontrado");
            
            return Ok(readDtos); 
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId(int id)
        {
            ReadCinemaDto readDto = _cinemaService.RecuperaCinemasPorId(id);
            if (readDto == null)
                return NotFound($"Nenhum cinema encontrado com Id {id}");

            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FromBody] UpdateCinemaDto updateDto)
        {
            Result result = _cinemaService.AtualizarFilme(id, updateDto);
            if (result.IsFailed)
                return NotFound(result.Reasons);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            Result result = _cinemaService.DeletarCinema(id);
            if (result.IsFailed)
                return NotFound(result.Reasons);

            return NoContent();
        }
    }
}
