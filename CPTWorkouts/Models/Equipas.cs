using System.ComponentModel.DataAnnotations;

namespace CPTWorkouts.Models
{
    public class Equipas
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Logotype { get; set; }


        // relação M-N com clientes
        public ICollection<Inscrevem_se> Clientes { get; set; }

        // Relação M-N com trerinadores
        public ICollection<Pertencem> Treinadores { get; set; }

        // relação 1-N com Aulas
        public ICollection<Aulas> Aulas { get; set; }
    }
}
