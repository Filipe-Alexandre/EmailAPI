using EmailAPI.Interfaces;
using EmailAPI.Models;
using EmailAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        //configurar a injeção de dependencia
        private readonly IEmailService _emailService;

        //método construtor
        //para cada classe injetada precisa ter uma propriedade e um parametro da mesma interface no construtor
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public ActionResult Post([FromBody] EmailDTO email)
        {
            //verifica se os campos estão vazios
            if (email == null)
            {
                return BadRequest("Email é obrigatório!.");
            }
            if(string.IsNullOrEmpty(email.NomeRemetente))
            {
                return BadRequest("Nome do remetente é obrigatório!.");
            }
            if(string.IsNullOrEmpty(email.Assunto))
            {
                return BadRequest("Assunto é obrigatório!.");
            }
            if(string.IsNullOrEmpty(email.Mensagem))
            {
                return BadRequest("Mensagem é obrigatória!.");
            }
            //instaciar email service
            //EmailService emailService = new EmailService();
            //emailService.Enviar(email);

            //EmailService Injetado (injeção de dependencia)
            _emailService.Enviar(email);

            return Ok("E-mail Enviado com sucesso");
        }
    }
}
