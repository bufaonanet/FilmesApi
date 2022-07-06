using AutoMapper;
using FilmesApi.Data.DTOs.CinemaDtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<UpdateCinemaDto, Cinema>();
        CreateMap<Cinema, ReadCinemaDto>()
            .ForMember(dest => dest.Endereco, opts => opts.MapFrom(orig => new { orig.Endereco.Logradouro, orig.Endereco.Bairro }))
            .ForMember(dest => dest.Gerente, opts => opts.MapFrom(orig => new { orig.Gerente.Id, orig.Gerente.Nome }));


        //CreateMap<Gerente, ReadGerenteDto>()
        //   .ForMember(gDto => gDto.Cinemas, opts => opts.MapFrom(gerente =>
        //   gerente.Cinemas.Select(c => new { c.Id, c.Nome, c.EnderecoId })));
    }
}

