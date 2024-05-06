using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTWorkouts.Models
{
    [PrimaryKey(nameof(idClientesFK), nameof(idServiçosFK))]
    public class Compram
    {
        /// <summary>
        /// define o nome dos serviços a serem prestados
        /// </summary>
        public string nomeServiços { get; set; }
        /// <summary>
        /// define a chave estrangeira que associa o atributo idclientesFK à tabela clientes
        /// </summary>
        public int idClientesFK { get; set; }
        [ForeignKey(nameof(idClientesFK))]
        public Clientes cliente {  get; set; }
        /// <summary>
        /// define a chave estrangeira que associa o atributo idserviçosFK à tabela serviço
        /// </summary>
        public int idServiçosFK { get; set; }
        [ForeignKey(nameof(idServiçosFK))]
        public Serviços servico { get; set; } 
    }
}
