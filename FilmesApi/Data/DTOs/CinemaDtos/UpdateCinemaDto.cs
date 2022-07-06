using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTOs.CinemaDtos;

public class UpdateCinemaDto
{
    [Required(ErrorMessage = "O campo de nome é obrigatório")]
    public string Nome { get; set; }
    public int EnderecoId { get; set; }   
}
