using System.ComponentModel.DataAnnotations;

namespace CPTWorkouts.Models
{
    public class Users
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public DateOnly BirthDate { get; set; }

    }
}
