using System.ComponentModel.DataAnnotations;

namespace CPTWorkouts.Models
{
    public class Treinadores
    {
        [Key]
        public int idTreinadores { get; set; }
        ///<summary>
        /// Nome do Treinador
        ///</summary>
        public int Nome { get; set; }
    }
}
