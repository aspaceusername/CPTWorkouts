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
        /// <summary>
        /// define o nome da equipa
        /// </summary>
        [StringLength(100)]
        [Required(ErrorMessage = "Doit écrire un {0}")]
        [Display(Name = "Nom")]
        public string Name { get; set; }
        /// <summary>
        /// guarda o nome do logotipo da equipa
        /// </summary>
        [StringLength(50)]
        public string? Logotype { get; set; }


        // relação M-N com clientes
        /// <summary>
        /// lista de clientes existentes
        /// </summary>
        public ICollection<Inscrevem_se> Clientes { get; set; }

        // Relação M-N com treiinadores
        /// <summary>
        /// lista de treinadores das equipas
        /// </summary>
        public ICollection<Pertencem> Treinadores { get; set; }

        // relação 1-N com Aulas
        /// <summary>
        /// lista de aulas planeadas para equipas
        /// </summary>
        public ICollection<Aulas> Aulas { get; set; }
    }
}
