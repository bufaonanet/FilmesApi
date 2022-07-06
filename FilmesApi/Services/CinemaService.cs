using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.DTOs.CinemaDtos;
using FilmesApi.Models;
using FilmesApi.Services.Contracts;
using FluentResults;

namespace FilmesApi.Services;

public class CinemaService : ICinemaService
{
    private readonly FilmesApiContext _context;
    private readonly IMapper _mapper;

    public CinemaService(FilmesApiContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadCinemaDto AdicionarFilme(CreateCinemaDto createDto)
    {
        var cinema = _mapper.Map<Cinema>(createDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();

        return _mapper.Map<ReadCinemaDto>(cinema);
    }

    public IEnumerable<ReadCinemaDto> RecuperarCinemas(string nomeDoFilme)
    {
        IEnumerable<Cinema> listaCinemas = _context.Cinemas;

        if (!string.IsNullOrEmpty(nomeDoFilme))
        {
            var query = from cinema in _context.Cinemas
                        where cinema.Sessoes.Any(s => s.Filme.Titulo.Contains(nomeDoFilme))
                        select cinema;

            listaCinemas = query.ToList();
        }


        return _mapper.Map<List<ReadCinemaDto>>(listaCinemas);
    }

    public ReadCinemaDto RecuperaCinemasPorId(int id)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null)
            return null;

        return _mapper.Map<ReadCinemaDto>(cinema);
    }

    public Result AtualizarFilme(int id, UpdateCinemaDto cinemaDto)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null)
            return Result.Fail("O filme a ser atualizado não existe");

        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return Result.Ok();
    }

    public Result DeletarCinema(int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema is null)
            return Result.Fail("O cinema a ser deletado não existe");

        _context.Cinemas.Remove(cinema);
        _context.SaveChanges();

        return Result.Ok();
    }
}
