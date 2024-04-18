using System.ComponentModel.DataAnnotations;

namespace CPTWorkouts.Models
{
    public class Equipas
    {
        public Equipas () {
            Clientes = new HashSet<Inscrevem_se> ();
            Treinadores = new HashSet<Pertencem> ();
            Aulas = new HashSet<Aulas> ();
        }
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Doit écrire un {0}")]
        [Display(Name = "Nom")]
        public string Name { get; set; }
            [StringLength(50)]
            public string? Logotype { get; set; }


        // relação M-N com clientes
        public ICollection<Inscrevem_se> Clientes { get; set; }

        // Relação M-N com trerinadores
        public ICollection<Pertencem> Treinadores { get; set; }

        // relação 1-N com Aulas
        public ICollection<Aulas> Aulas { get; set; }
    }
}
