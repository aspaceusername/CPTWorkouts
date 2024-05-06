﻿using System.ComponentModel.DataAnnotations;

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
        public string Nome { get; set; }
        public DateOnly dataDeNascimento { get; set; }
        public string dadosPessoais { get; set; }

        //vou adicionar um atributo decimal para efeitos das aulas
        public decimal Fee { get; set; }

        // relação 1-1 com faturas
        public Faturas Fatura { get; set; }

        // relação N-M com Equipas
        public ICollection<Inscrevem_se> Equipas { get; set; }

        // relação N-M com serviços
        public ICollection<Compram> Serviços { get; set; }

    }
}
