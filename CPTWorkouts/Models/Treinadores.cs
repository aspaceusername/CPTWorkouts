using System.ComponentModel.DataAnnotations;

namespace CPTWorkouts.Models
{
    public class Treinadores
    {
        [Key]
        public int idTreinadores { get; set; }
        public int Nome { get; set; }
    }
}
