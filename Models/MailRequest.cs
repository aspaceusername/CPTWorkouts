namespace CPTWorkouts.Models
{
    public class MailRequest
    {
        ///<summary>
        /// Endereço de Email ao qual enviar a mensagem
        ///</summary>
        public string ToEmail { get; set; }
        ///<summary>
        /// Assunto do email
        ///</summary>
        public string Subject { get; set; }
        ///<summary>
        /// EConteúdo do Email
        ///</summary>
        public string Body { get; set; }
        ///<summary>
        /// Anexos do Email
        ///</summary>
        public List<IFormFile>? Attachments { get; set; }
    }
}
