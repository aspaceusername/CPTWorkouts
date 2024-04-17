using System.ComponentModel.DataAnnotations;

namespace CPTWorkouts.Models
{
    public class Aulas
    {
        [Key]
        public string Nome { get; set; }
        public DateOnly Data {  get; set; }

        // Define a relação N-1 com Equipas
        public int EquipaId { get; set; }
        public Equipas Equipa { get; set; }

        // Define a relação N-M com Treinadores
        public ICollection<Treinadores> Treinadores { get; set; }

    }
}
