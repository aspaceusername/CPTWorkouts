using System.ComponentModel.DataAnnotations;

namespace CPTWorkouts.Models
{
    public class Aulas
    {
        public Aulas() {
            Treinadores = new HashSet<Treinadores>();
        }
        /// <summary>
        /// define o nome da aula
        /// </summary>
        [Key]
        public string Nome { get; set; }
        /// <summary>
        /// define a data em que decorrerá a aula
        /// </summary>
        public DateOnly Data {  get; set; }

        // Define a relação N-1 com Equipas
        public int equipaFK { get; set; }
        [ForeignKey(nameof(equipaFK))]
        public Equipas Equipa { get; set; }

        // Define a relação N-M com Treinadores
        public ICollection<Treinadores> Treinadores { get; set; }

    }
}
