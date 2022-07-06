using FilmesApi.Data.DTOs.FilmeDtos;
using FluentResults;

namespace FilmesApi.Services.Contracts;

public interface IFilmeService
{
    ReadFilmeDto AdicionarFilme(CreateFilmeDto filmeDTO);
    Result AtualizarFilme(int id, UpdateFilmeDto updateDto);
    Result DeletarFilme(int id);
    ReadFilmeDto RecuperarFilmePorId(int id);
    List<ReadFilmeDto> RecuperarFilmes(int? classificacaoEtaria);
}