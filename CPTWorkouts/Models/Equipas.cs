using System.ComponentModel.DataAnnotations;

namespace CPTWorkouts.Models
{
    public class Equipas
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Logotype { get; set; }

    }
}
