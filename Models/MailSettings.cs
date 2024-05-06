namespace CPTWorkouts.Models
{
    public class MailSettings
    {
        ///<summary>
        /// Endereço do endereço de email que vai enviar a mensagem
        ///</summary>
        public string Mail { get; set; }
        ///<summary>
        /// Nome visto pelo recipiente no email
        ///</summary>
        public string DisplayName { get; set; }
        ///<summary>
        /// Chave utilizada pelo gmail para validar o utilizador e permitir o envio do email
        ///</summary>
        public string Password { get; set; }
        ///<summary>
        /// Utilizar se à o servidor SMTP da google que permite o envio de 2000 emails por dia grátis
        ///</summary>
        public string Host { get; set; }
        ///<summary>
        /// Definição do port a utilizar para o envio do email.
        ///</summary>
        public int Port { get; set; }
    }
}
