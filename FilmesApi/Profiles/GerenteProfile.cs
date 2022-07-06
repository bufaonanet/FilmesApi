using AutoMapper;
using FilmesApi.Data.DTOs.GerenteDtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

public class GerenteProfile : Profile
{
    public GerenteProfile()
    {
        CreateMap<CreateGerenteDto, Gerente>();
        //CreateMap<Gerente, ReadGerenteDto>();

        CreateMap<Gerente, ReadGerenteDto>()
            .ForMember(gDto => gDto.Cinemas, opts => opts.MapFrom(gerente =>
            gerente.Cinemas.Select(c => new { c.Id, c.Nome, c.EnderecoId })));
    }
}
