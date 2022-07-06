using FluentResults;
using UsuariosApi.Data.DTOs;
using UsuariosApi.Data.Requests;

namespace UsuariosApi.Services.Contracts;

public interface ICadastroService
{
    Result CadastrarUsuario(CreateUsuarioDto createDto);
    Result AtivarUsuario(AtivaContaRequest request);
}