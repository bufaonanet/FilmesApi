using FilmesApi.Data.DTOs.SessaoDtos;

namespace FilmesApi.Services.Contracts;

public interface ISessaoService
{
    ReadSessaoDto AdicionasSessao(CreateSessaoDto createDto);
    object RecuperarSessaoPorId(int id);
    IEnumerable<ReadSessaoDto> RecuperarSessoes();
}