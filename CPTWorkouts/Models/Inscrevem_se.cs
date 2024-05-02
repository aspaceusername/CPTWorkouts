using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CPTWorkouts.Models
{
    [PrimaryKey(nameof(idClientesFK), nameof(idEquipasFK))]
    public class Inscrevem_se
    {
        
        public string nomeEquipas { get; set; }
        
        public int idClientesFK { get; set; }
        
        public int idEquipasFK { get; set; }


        // relação 1-N com Clientes
        public Clientes Cliente { get; set; }

        // relação 1-N com Equipas
        public Equipas Equipa { get; set; }
    }
}
