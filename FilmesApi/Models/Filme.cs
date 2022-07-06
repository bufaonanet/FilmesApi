using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;

public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo {0} título é obrigatório")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Range(1, 600, ErrorMessage = "A duração deve ter no mínimo {1} minuto e no máximo {2}.")]
    public int Duracao { get; set; }

    [StringLength(100, ErrorMessage = "O {0} não pode exceder {1} caracteres")]
    public string Diretor { get; set; }
    public string Genero { get; set; }
    public int ClassificacaoEtaria { get; set; } 
    public virtual List<Sessao> Sessoes { get; set; }
}
