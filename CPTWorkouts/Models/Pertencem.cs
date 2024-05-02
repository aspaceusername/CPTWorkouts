using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CPTWorkouts.Models
{
    [PrimaryKey (nameof(idTreinadoresFK),nameof(idEquipasFK))]
    public class Pertencem
    {
        
        public int idTreinadoresFK { get; set; }
        
        public int idEquipasFK { get; set; }
        public string nomeEquipas { get; set; }

        // 1-N com Treinadores
        public Treinadores Treinador { get; set; }

        // 1-N com Equipas
        public Equipas Equipa { get; set; }

    }
}
