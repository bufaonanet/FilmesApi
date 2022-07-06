using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.DTOs.EnderecoDtos;
using FilmesApi.Models;
using FilmesApi.Services.Contracts;
using FluentResults;

namespace FilmesApi.Services;

public class EnderecoService : IEnderecoService
{
    private readonly FilmesApiContext _context;
    private readonly IMapper _mapper;

    public EnderecoService(FilmesApiContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto createDto)
    {
        var endereco = _mapper.Map<Endereco>(createDto);
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();
        return _mapper.Map<ReadEnderecoDto>(endereco);
    }

    public IEnumerable<ReadEnderecoDto> RecuperarEnderecos()
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos);
    }

    public ReadEnderecoDto RecuperaEnderecosPorId(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null)
            return null;

        return _mapper.Map<ReadEnderecoDto>(endereco);
    }

    public Result AtualizarEndereco(int id, UpdateEnderecoDto enderecoDto)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null)
            return Result.Fail("O endereco a ser atualizado não existe");

        _mapper.Map(enderecoDto, endereco);
        _context.SaveChanges();
        return Result.Ok();
    }

    public Result DeletarEndereco(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco is null)
            return Result.Fail("O endereco a ser deletado não existe");

        _context.Enderecos.Remove(endereco);
        _context.SaveChanges();

        return Result.Ok();
    }
}
