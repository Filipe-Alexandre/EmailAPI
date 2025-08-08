using EmailAPI.Models;

namespace EmailAPI.Interfaces
{
    public interface IEmailService
    {
        public void Enviar(EmailDTO email);
    }
}
