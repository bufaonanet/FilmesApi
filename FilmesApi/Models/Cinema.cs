using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo de {0} é obrigatório")]
    public string Nome { get; set; }

    public int? EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; }

    public int GerenteId { get; set; }
    public virtual Gerente Gerente { get; set; }
 
    public virtual List<Sessao> Sessoes { get; set; }
}
