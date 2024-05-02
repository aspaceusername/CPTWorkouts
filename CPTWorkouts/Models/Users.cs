using System.ComponentModel.DataAnnotations;

namespace CPTWorkouts.Models
{
    public class Users
    {
        [Key]
        public int ID { get; set; }
        public string NIF {  get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
        public DateOnly dataDeNascimento { get; set; }

    }
}
