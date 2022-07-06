using FilmesApi.Data.DTOs.CinemaDtos;
using FilmesApi.Data.DTOs.FilmeDtos;

namespace FilmesApi.Data.DTOs.SessaoDtos;

public class ReadSessaoDto
{
    public int Id { get; set; }
    public DateTime HoratioDeEncerramento { get; set; }
    public DateTime HoratioDeInicio { get; set; }
    public ReadCinemaDto Cinema { get; set; }
    public ReadFilmeDto Filme { get; set; }
}