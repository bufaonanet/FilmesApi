using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.DTOs;
using UsuariosApi.Data.Requests;
using UsuariosApi.Models;
using UsuariosApi.Services.Contracts;

namespace UsuariosApi.Services;

public class CadastroService : ICadastroService
{
    private readonly IMapper _mapper;
    private readonly UserManager<CustomIdentityUser> _userManager;   
    private readonly IEmailService _emailService;

    public CadastroService(IMapper mapper,
                          UserManager<CustomIdentityUser> userManager,
                          IEmailService emailService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _emailService = emailService;        
    }


    public Result CadastrarUsuario(CreateUsuarioDto createDto)
    {
        var usuario = _mapper.Map<Usuario>(createDto);
        var usuarioIdentity = _mapper.Map<CustomIdentityUser>(usuario);

        var resultadoIdentity = _userManager
            .CreateAsync(usuarioIdentity, createDto.Password)
            .Result;

        if (!resultadoIdentity.Succeeded)
            return Result.Fail("Falha ao cadastrar usuário");

        //var createRoleResult = _roleManager
        //    .CreateAsync(new IdentityRole<int>("admin"))
        //    .Result;

        var usuarioRoleResult = _userManager
            .AddToRoleAsync(usuarioIdentity, "regular")
            .Result;

        var code = _userManager
            .GenerateEmailConfirmationTokenAsync(usuarioIdentity)
            .Result;

        //var encodedCode = HttpUtility.UrlEncode(code);

        //_emailService.EnviarEmail(new[] { usuarioIdentity.Email }, encodedCode, usuarioIdentity.Id, code);

        return Result.Ok()
            .WithSuccess(code)
            .WithSuccess(usuarioIdentity.Id.ToString());
    }

    public Result AtivarUsuario(AtivaContaRequest request)
    {
        var identityUser = _userManager.Users
            .FirstOrDefault(u => u.Id == request.UsuarioId);

        if(identityUser == null)
            return Result.Fail("Usuário não encontrado");

        var identityResult = _userManager
            .ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao)
            .Result;

        if (!identityResult.Succeeded)
        {
            return Result.Fail("Falha ao ativar usuario");
        }

        return Result.Ok().WithSuccess("Conta ativado com sucesso!");
    }
}