using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTOs.GerenteDtos;

public class CreateGerenteDto
{

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Nome { get; set; }
}
