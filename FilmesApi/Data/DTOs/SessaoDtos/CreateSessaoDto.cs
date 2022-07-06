using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTOs.SessaoDtos;

public class CreateSessaoDto
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public int CinemaId { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public int FilmeId { get; set; }
    public DateTime HoratioDeEncerramento { get; set; }
}
