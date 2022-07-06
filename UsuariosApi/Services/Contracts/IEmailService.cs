namespace UsuariosApi.Services.Contracts
{
    public interface IEmailService
    {
        void EnviarEmail(string[] destinatario, string assunto, int usuarioId, string code);
    }
}