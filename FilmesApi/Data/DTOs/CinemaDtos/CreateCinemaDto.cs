using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTOs.CinemaDtos;

public class CreateCinemaDto
{
    [Required(ErrorMessage = "O campo de {0} é obrigatório")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo de {0} é obrigatório")]
    public int EnderecoId { get; set; }

    [Required(ErrorMessage = "O campo de {0} é obrigatório")]
    public int GerenteId { get; set; }

}
