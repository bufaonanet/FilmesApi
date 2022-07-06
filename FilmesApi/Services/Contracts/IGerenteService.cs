using FilmesApi.Data.DTOs.EnderecoDtos;
using FilmesApi.Data.DTOs.GerenteDtos;
using FluentResults;

namespace FilmesApi.Services.Contracts;

public interface IGerenteService
{
    ReadGerenteDto AdicionarGerente(CreateGerenteDto createDto);
    Result DeletarGerente(int id);
    IEnumerable<ReadGerenteDto> RecuperarGerentes();
    ReadGerenteDto RecuperarGerentePorId(int id);
}