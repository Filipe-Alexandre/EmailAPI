namespace EmailAPI.Models
{
    public class EmailDTO
    {
        public string NomeRemetente { get; set; }
        public string EmailRemetente { get; set; }
        public string? Telefone { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
    }
}
