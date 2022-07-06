using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.DTOs.SessaoDtos;
using FilmesApi.Models;
using FilmesApi.Services.Contracts;

namespace FilmesApi.Services;

public class SessaoService : ISessaoService
{
    private readonly FilmesApiContext _context;
    private readonly IMapper _mapper;

    public SessaoService(FilmesApiContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadSessaoDto AdicionasSessao(CreateSessaoDto createDto)
    {
        var sessao = _mapper.Map<Sessao>(createDto);
        _context.Sessoes.Add(sessao);
        _context.SaveChanges();
        return _mapper.Map<ReadSessaoDto>(sessao);
    }

    public IEnumerable<ReadSessaoDto> RecuperarSessoes()
    {
        return _mapper.Map<IEnumerable<ReadSessaoDto>>(_context.Sessoes);
    }

    public object RecuperarSessaoPorId(int id)
    {
        var sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
        if (sessao is null)
            return null;

        return _mapper.Map<ReadSessaoDto>(sessao);
    }
}
