using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using UsuariosApi.Configuration;
using UsuariosApi.Models;
using UsuariosApi.Services.Contracts;

namespace UsuariosApi.Services;

public class EmailService : IEmailService
{
    private readonly EmailSettingsConfig _emailSettings;

    public EmailService(IOptions<EmailSettingsConfig> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    public void EnviarEmail(string[] destinatario, string assunto, int usuarioId, string code)
    {
        var mensagem = new Mensagem(destinatario, assunto, usuarioId, code);
        var mensagemDeEmail = CriaCorpoDoEmail(mensagem);
        Enviar(mensagemDeEmail);
    }

    private void Enviar(MimeMessage mensagemDeEmail)
    {
        using (var client = new SmtpClient())
        {
            try
            {
                client.Connect(_emailSettings.SmtpServer, _emailSettings.Port);
                client.AuthenticationMechanisms.Remove("XOUATH2");
                client.Authenticate(_emailSettings.From, _emailSettings.Password);
                client.Send(mensagemDeEmail);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }

    private MimeMessage CriaCorpoDoEmail(Mensagem mensagem)
    {
        var mensagemDeEmail = new MimeMessage();
        mensagemDeEmail.From.Add(new MailboxAddress(_emailSettings.MailBoxName, _emailSettings.From));
        mensagemDeEmail.To.AddRange(mensagem.Destinatario);
        mensagemDeEmail.Subject = mensagem.Assunto;
        mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
        {
            Text = mensagem.Conteudo
        };

        return mensagemDeEmail;
    }
}