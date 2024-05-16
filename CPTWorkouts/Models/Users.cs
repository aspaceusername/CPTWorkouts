using System.ComponentModel.DataAnnotations;

namespace CPTWorkouts.Models
{
    /// <summary>
    /// atributos para todos os utilizadores
    /// corresponde a appusers do professor
    /// </summary>
    public class Users
    {
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// nif do utilizador
        /// </summary>
        public string NIF {  get; set; }
        /// <summary>
        /// nome do utilizador
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// password do utilizador
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// data de nascimento do utilizador
        /// </summary>
        public DateOnly dataDeNascimento { get; set; }
        //embora seja um numero, não vamos fazer operações aritméticas com o numero de telefone, logo guardamos como string
        // todos os country codes começam por +, e um + corresponde a 00
        // portanto 00 351 para portugal é o código para +351
        // 00 35100 0000000000 porque andorra é o maior country code com 5 números

        /// <summary>
        /// user's cell phone
        /// </summary>
        [StringLength(17)]
        //vamos escrever uma regular expression
        // na regular expression vamos definir que numeros têm de entrar no numero de telefone
        // () -> é para ser opcional
        // (+|00) ou seja, às vezes o utilizador mete + ou nao, e definimos que é ou + ou 00 que é o equivalente
        // ? -> i use or dont use, a plus or a zero zero or neither
        // (+|00) ?
        // country code has 2 minimum numbers and 5 at maximum
        // (+|00)?[0123456789]{2,5}
        // {2,5} 2 to 5 characters from the allowed characters "[0123456789]"
        // em vez de escrevermos 0123456789, escreve se: 0-9
        // (+|00)?[0-9]{2,5}?
        // mas e se o utilizador nao meter country code, fica obrigado a meter 2 digitos a mesma
        // (+|00)?[0-9]{2,5}[0-9]{7-10}
        // (+|00)?[0-9]{7,15}
        [RegularExpression("([+]|00)?[0-9]{7,15}",
                            ErrorMessage = "Please write a valid cell phone number")]
        public string CellPhone {  get; set; }

    }
}
