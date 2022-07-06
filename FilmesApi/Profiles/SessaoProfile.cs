using AutoMapper;
using FilmesApi.Data.DTOs.SessaoDtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

public class SessaoProfile : Profile
{
    public SessaoProfile()
    {
        CreateMap<CreateSessaoDto, Sessao>();
        CreateMap<Sessao, ReadSessaoDto>()
            .ForMember(dest => dest.HoratioDeInicio, opts => 
            opts.MapFrom(orig => orig.HoratioDeEncerramento.AddMinutes(orig.Filme.Duracao * (-1))));        
    }
}
