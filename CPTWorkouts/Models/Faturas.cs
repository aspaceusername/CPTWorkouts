using System.ComponentModel.DataAnnotations;

namespace CPTWorkouts.Models
{
    public class Faturas
    {
        [Key]
        public int Id { get; set; }
        public int idCliente { get; set; }
        public string Serviços { get; set; }
        public int Valor {  get; set; }

        // relação 1-1 com Clientes
        public Clientes Cliente { get; set; }
    }
}
