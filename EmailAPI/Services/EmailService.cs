using System.Net;
using System.Net.Mail;
using EmailAPI.Interfaces;
using EmailAPI.Models;

namespace EmailAPI.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Enviar(EmailDTO email)
        {
            //cria o emial
            MailMessage message = new MailMessage();
            //remetente
            message.From = new MailAddress(email.EmailRemetente, email.NomeRemetente);
            //destinatário
            message.To.Add(new MailAddress(_configuration["EmailSettings:FromEmail"], _configuration["EmailSettings:FromName"]));
            //assunto
            message.Subject = email.Assunto;
            //corpo do e-mail
            message.Body = email.Mensagem;

            //configurar o SMTPClient
            SmtpClient smtp = new SmtpClient();

            //dados do servidor (gmail)
            smtp.Host = _configuration["EmailSettings:SmtpHost"];
            smtp.Port = Convert.ToInt32(_configuration["EmailSettings:SmtpPort"]); //porta do gmail
            smtp.EnableSsl = true; //habilita o SSL
            smtp.UseDefaultCredentials = false; //não usa as credenciais padrão
            smtp.Credentials = new NetworkCredential
                (_configuration["EmailSettings:EmailUser"], _configuration["EmailSettings:EmailPassword"]);

            //envia o e-mail
            try
            {
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao enviar o e-mail: {ex.Message}");
            }
        }
    }
}
