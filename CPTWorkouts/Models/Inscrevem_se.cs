using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTWorkouts.Models
{
    [PrimaryKey(nameof(idClientesFK), nameof(idEquipasFK))]
    public class Inscrevem_se
    {
        ///<summary>
        /// Nome das equipas nas quais os clientes estão inscritos
        ///</summary>
        public string nomeEquipas { get; set; }
        ///<summary>
        /// Chave estrangeira correspondente à tabela dos Clientes
        ///</summary>
        [ForeignKey("Cliente")]
        public int idClientesFK { get; set; }
        ///<summary>
        /// Chave estrangeira correspondente à tabela das Equipas
        ///</summary>
        [ForeignKey("Equipa")]
        
        public int idEquipasFK { get; set; }


        // relação 1-N com Clientes
        public Clientes Cliente { get; set; }

        // relação 1-N com Equipas
        public Equipas Equipa { get; set; }
    }
}
