using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTWorkouts.Models
{
    public class Compram
    {
        public string nomeServiços { get; set; }

        [Key]
        [ForeignKey(nameof(idClientesFK))]

        public int idClientesFK { get; set; }
        public Clientes cliente {  get; set; }

        [Key]
        [ForeignKey(nameof(idServiçosFK))]
        public int idServiçosFK { get; set; }
        public Serviços servico { get; set; } 
    }
}
