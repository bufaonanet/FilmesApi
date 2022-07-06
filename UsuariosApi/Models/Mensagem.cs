using MimeKit;

namespace UsuariosApi.Models
{
    public class Mensagem
    {

        public Mensagem(IEnumerable<string> destinatario, string assunto, int usuarioId, string code)
        {
            Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatario.Select(d => new MailboxAddress(name: "douglas", address: d)));
            Assunto = assunto;
            Conteudo = $"https://localhost:5001/cadastro/ativa?UsuarioId={usuarioId}&CodigoDeAtivacao={code}";
        }

        public List<MailboxAddress> Destinatario { get; }
        public string Assunto { get; }
        public string Conteudo { get; set; }
    }
}