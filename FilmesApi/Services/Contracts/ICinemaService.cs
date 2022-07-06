using FilmesApi.Data.DTOs.CinemaDtos;
using FluentResults;

namespace FilmesApi.Services.Contracts;

public interface ICinemaService
{
    ReadCinemaDto AdicionarFilme(CreateCinemaDto createDto);
    Result AtualizarFilme(int id, UpdateCinemaDto cinemaDto);
    Result DeletarCinema(int id);
    ReadCinemaDto RecuperaCinemasPorId(int id);
    IEnumerable<ReadCinemaDto> RecuperarCinemas(string nomeDoFilme);
}