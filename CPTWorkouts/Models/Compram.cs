using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTWorkouts.Models
{
    [PrimaryKey(nameof(idClientesFK), nameof(idServiçosFK))]
    public class Compram
    {
        public string nomeServiços { get; set; }

        
        [ForeignKey(nameof(idClientesFK))]

        public int idClientesFK { get; set; }
        public Clientes cliente {  get; set; }

        
        [ForeignKey(nameof(idServiçosFK))]
        public int idServiçosFK { get; set; }
        public Serviços servico { get; set; } 
    }
}
