using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CPTWorkouts.Models
{
    public class Pertencem
    {
        [Key]
        public int idTreinadoresFK { get; set; }
        [Key]
        public int idEquipasFK { get; set; }
        public string nomeEquipas { get; set; }

        // 1-N com Treinadores
        public Treinadores Treinador { get; set; }

        // 1-N com Equipas
        public Equipas Equipa { get; set; }

    }
}
