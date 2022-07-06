using FilmesApi.Data.DTOs.EnderecoDtos;
using FilmesApi.Data.DTOs.GerenteDtos;
using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTOs.CinemaDtos;

public class ReadCinemaDto
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo de nome é obrigatório")]
    public string Nome { get; set; }
    public object Gerente { get; set; }
    public object Endereco { get; set; }
}
