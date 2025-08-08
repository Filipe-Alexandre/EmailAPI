using EmailAPI.Interfaces;
using EmailAPI.Models;

namespace EmailAPI.Services
{
    public class SimulaEmailService : IEmailService
    {
        public void Enviar(EmailDTO email)
        {
            Console.WriteLine("Email enviado com sucesso \n\t\t\t--by: Felps");
        }
    }
}
