using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.DTOs.FilmeDtos;
using FilmesApi.Models;
using FilmesApi.Services.Contracts;
using FluentResults;

namespace FilmesApi.Services;

public class FilmeService : IFilmeService
{
    private readonly FilmesApiContext _context;
    private readonly IMapper _mapper;

    public FilmeService(FilmesApiContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadFilmeDto AdicionarFilme(CreateFilmeDto filmeDTO)
    {
        var filme = _mapper.Map<Filme>(filmeDTO);

        _context.Filmes.Add(filme);
        _context.SaveChanges();

        return _mapper.Map<ReadFilmeDto>(filme);
    }

    public List<ReadFilmeDto> RecuperarFilmes(int? classificacaoEtaria)
    {
        IEnumerable<Filme> listaFilmes = _context.Filmes;

        if (classificacaoEtaria != null)
        {
            listaFilmes = _context.Filmes
                .Where(f => f.ClassificacaoEtaria >= classificacaoEtaria)
                .ToList();
        }

        return _mapper.Map<List<ReadFilmeDto>>(listaFilmes);
    }

    public ReadFilmeDto RecuperarFilmePorId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme is null)
            return null;

        return _mapper.Map<ReadFilmeDto>(filme);
    }

    public Result AtualizarFilme(int id, UpdateFilmeDto updateDto)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme is null)
            return Result.Fail("O filme a ser atualizado não existe");

        _mapper.Map(updateDto, filme);
        _context.SaveChanges();
        return Result.Ok();
    }

    public Result DeletarFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme is null)
            return Result.Fail("O filme a ser deletado não existe");

        _context.Filmes.Remove(filme);
        _context.SaveChanges();

        return Result.Ok();
    }
}
