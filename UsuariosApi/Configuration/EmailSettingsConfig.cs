namespace UsuariosApi.Configuration;

public class EmailSettingsConfig
{
    public string From { get; set; }
    public string SmtpServer { get; set; }
    public int Port { get; set; }
    public string Password { get; set; }
    public string MailBoxName { get; set; }
}
