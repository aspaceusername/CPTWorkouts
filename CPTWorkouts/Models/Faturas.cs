using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTWorkouts.Models
{
    public class Faturas
    {
        [Key]
        public int Id { get; set; }
        ///<summary>
        /// Chave estrangeira correspondente à tabela dos Clientes
        ///</summary>
        [ForeignKey("Cliente")]
        public int idCliente { get; set; }
        ///<summary>
        /// Chave estrangeira correspondente aos serviços vendidos ao Cliente
        ///</summary>
        public string serviçosFK { get; set; }
        ///<summary>
        /// Valor de cada serviço adquirido pelo cliente
        ///</summary>
        public int Valor {  get; set; }

        // relação 1-1 com Clientes
        public Clientes Cliente { get; set; }
    }
}
