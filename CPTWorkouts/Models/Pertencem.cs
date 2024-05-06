using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTWorkouts.Models
{
    [PrimaryKey (nameof(idTreinadoresFK),nameof(idEquipasFK))]
    public class Pertencem
    {
        ///<summary>
        /// Chave estrangeira correspondente à tabela dos treinadores
        ///</summary>
        [ForeignKey("Treinador")]
        public int idTreinadoresFK { get; set; }
        ///<summary>
        /// Chave estrangeira correspondente à tabela das Equipas
        ///</summary>
        [ForeignKey("Equipa")]
        public int idEquipasFK { get; set; }
        ///<summary>
        /// Nome da Equipa
        ///</summary>
        public string nomeEquipas { get; set; }

        // relação 1-N com Treinadores
        public Treinadores Treinador { get; set; }

        // relação 1-N com Equipas
        public Equipas Equipa { get; set; }

    }
}
