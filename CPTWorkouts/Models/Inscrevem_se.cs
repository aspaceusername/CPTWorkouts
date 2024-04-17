using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CPTWorkouts.Models
{
    public class Inscrevem_se
    {
        
        public string nomeEquipas { get; set; }
        [Key]
        public int idClientesFK { get; set; }
        [Key]
        public int idEquipasFK { get; set; }


        // relação 1-N com Clientes
        public Clientes Cliente { get; set; }

        // relação 1-N com Equipas
        public Equipas Equipa { get; set; }
    }
}
