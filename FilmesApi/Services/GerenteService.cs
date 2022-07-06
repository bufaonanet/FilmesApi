using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.DTOs.GerenteDtos;
using FilmesApi.Models;
using FilmesApi.Services.Contracts;
using FluentResults;

namespace FilmesApi.Services;

public class GerenteService : IGerenteService
{
    private readonly FilmesApiContext _context;
    private readonly IMapper _mapper;

    public GerenteService(FilmesApiContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadGerenteDto AdicionarGerente(CreateGerenteDto createDto)
    {
        var gerente = _mapper.Map<Gerente>(createDto);
        _context.Gerentes.Add(gerente);
        _context.SaveChanges();
        return _mapper.Map<ReadGerenteDto>(gerente);
    }

    public IEnumerable<ReadGerenteDto> RecuperarGerentes()
    {
        return _mapper.Map<List<ReadGerenteDto>>(_context.Gerentes);
    }

    public ReadGerenteDto RecuperarGerentePorId(int id)
    {
        var gerente = _context.Gerentes.FirstOrDefault(g => g.Id == id);
        if (gerente == null)
            return null;
        return _mapper.Map<ReadGerenteDto>(gerente);
    }

    public Result DeletarGerente(int id)
    {
        var gerente = _context.Gerentes.FirstOrDefault(g => g.Id == id);
        if (gerente is null)
            return Result.Fail("O gerente a ser deletado não existe");

        _context.Gerentes.Remove(gerente);
        _context.SaveChanges();

        return Result.Ok();
    }   
}
