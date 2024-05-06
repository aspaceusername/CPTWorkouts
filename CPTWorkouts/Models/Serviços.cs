using System.ComponentModel.DataAnnotations;

namespace CPTWorkouts.Models
{
    public class Serviços
    {
        [Key]
        public int idServiço { get; set; }
        ///<summary>
        /// Nome do Serviço (Personal training, Acompanhamento online, Plano de treino...)
        ///</summary>
        public string nomeServiço { get; set; }
        public int Preço { get; set; }
    }
}
