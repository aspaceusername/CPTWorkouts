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
        /// <summary>
        /// auxiliary attribute to help us to write fee values
        /// como é string aceita qualquer valor, temos de escrever uma expressão regular para regular isso
        /// </summary>
        /// 
        /// 
        ///<summary>
        /// Valor de cada serviço adquirido pelo cliente
        ///</summary>
        public decimal Valor {  get; set; }

        // relação 1-1 com Clientes
        public Clientes Cliente { get; set; }
    }
}
