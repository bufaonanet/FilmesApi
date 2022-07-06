﻿using AutoMapper;
using FilmesApi.Data.DTOs.FilmeDtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<Filme, ReadFilmeDto>();
        CreateMap<UpdateFilmeDto, Filme>();
    }
}