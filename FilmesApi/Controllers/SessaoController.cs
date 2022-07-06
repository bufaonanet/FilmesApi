using FilmesApi.Data.DTOs.SessaoDtos;
using FilmesApi.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SessaoController : ControllerBase
    {
        private readonly ISessaoService _sessaoService;

        public SessaoController(ISessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdicionasSessao([FromBody] CreateSessaoDto createDto)
        {
            ReadSessaoDto readDto = _sessaoService.AdicionasSessao(createDto);

            return CreatedAtAction(nameof(RecuperarSessaoPorId), new { readDto.Id }, readDto);            
        }

        [HttpGet()]
        public IActionResult RecuperarSessoes()
        {           
            var readDto = _sessaoService.RecuperarSessoes();

            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarSessaoPorId(int id)
        {
            var readDto = _sessaoService.RecuperarSessaoPorId(id);
            if (readDto == null)
                return NotFound($"Nenhuma sessao encontrado com Id {id}");

            return Ok(readDto);            
        }
    }
}
