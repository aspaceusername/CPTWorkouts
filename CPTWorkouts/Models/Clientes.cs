using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// correspondente a classe students do professor

namespace CPTWorkouts.Models
{
    public class Clientes
    {
        public Clientes() {
            Equipas = new HashSet<Inscrevem_se> { };
            Serviços = new HashSet<Compram> { };

        }
        [Key]
        public int idClientes { get; set; }
        /// <summary>
        /// define o nome do cliente
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// define a data de nascimento do cliente
        /// </summary>
        public DateOnly dataDeNascimento { get; set; }
        /// <summary>
        /// atributo com nome placeholder para dados pessoais
        /// </summary>
        public string dadosPessoais { get; set; }

        [NotMapped] // não queremos este atributo na base de dados, em vez de fazermos uma DTO só por um atributo, usamos esta tag.
        [Display(Name = "Fee")]
        [StringLength(9)]
        [Required(ErrorMessage = "The {0] is required")]
        [RegularExpression("[0-9]{1,6}([,.][0-9]{1,2})?", ErrorMessage = "Write a number. Max 2 decimal digits.")]
        public string FeeAux { get; set; }
        /// <summary>
        /// fee to be paid by student at enrollment
        /// </summary>
        public decimal Fee { get; set; }

        // relação 1-1 com faturas
        public Faturas Fatura { get; set; }

        // relação N-M com Equipas
        public ICollection<Inscrevem_se> Equipas { get; set; }

        // relação N-M com serviços
        public ICollection<Compram> Serviços { get; set; }

    }
}
