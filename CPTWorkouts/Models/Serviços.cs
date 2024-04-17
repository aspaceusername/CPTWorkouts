using System.ComponentModel.DataAnnotations;

namespace CPTWorkouts.Models
{
    public class Serviços
    {
        [Key]
        public int idServiço { get; set; }
        public string nomeServiço { get; set; }
        public int Preço { get; set; }
    }
}
