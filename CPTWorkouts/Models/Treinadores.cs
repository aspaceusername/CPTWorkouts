using System.ComponentModel.DataAnnotations;

namespace CPTWorkouts.Models
{
    //correspondente aos professores da classe feita nas aulas
    public class Treinadores
    {
        [Key]
        public int idTreinadores { get; set; }
        ///<summary>
        /// Nome do Treinador
        ///</summary>
        public string Email { get; set; }
        public string Password {  get; set; }
        public int Nome { get; set; }
    }
}
