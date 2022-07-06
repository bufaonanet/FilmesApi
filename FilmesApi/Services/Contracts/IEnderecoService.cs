using FilmesApi.Data.DTOs.EnderecoDtos;
using FluentResults;

namespace FilmesApi.Services.Contracts;

public interface IEnderecoService
{
    ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto createDto);
    Result AtualizarEndereco(int id, UpdateEnderecoDto enderecoDto);
    Result DeletarEndereco(int id);
    ReadEnderecoDto RecuperaEnderecosPorId(int id);
    IEnumerable<ReadEnderecoDto> RecuperarEnderecos();
}