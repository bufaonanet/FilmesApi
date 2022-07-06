using FilmesApi.Data.DTOs.CinemaDtos;
using FilmesApi.Models;

namespace FilmesApi.Data.DTOs.GerenteDtos;

public class ReadGerenteDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public object Cinemas { get; set; }
}
