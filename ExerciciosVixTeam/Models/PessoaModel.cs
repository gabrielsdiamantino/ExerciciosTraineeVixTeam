﻿using System.ComponentModel.DataAnnotations;

namespace ExerciciosVixTeam.Models

{
    public class PessoaModel
    {
        [Key]
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public int QuantidadeFilhos { get; set;}

        public decimal Salario { get; set;}

        public string Status { get; set; }

    }
}
