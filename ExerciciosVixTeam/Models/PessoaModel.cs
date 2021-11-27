using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ExerciciosVixTeam.Models

{
    public class PessoaModel
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage ="Campo obrigatório! Digite o seu nome.")]
        [StringLength (30, MinimumLength =3, ErrorMessage ="Nome deve conter minimo 3 letras e no maximo 30 ")]
        public string Nome { get; set; }



        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }



        [Required(ErrorMessage = "Campo obrigatorio! Informe sua data de nascimento!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0: dd/MM/yyyy}")]
        
        public DateTime DataNascimento { get; set; }


        [Required(ErrorMessage = "O capo deve ser preenchido com numero igual ou superior a 0.")]
        [RangeAttribute( 0, 50, ErrorMessage= "O campo deve ser preenchido com numero igual ou superior a 0.")]
        public int QuantidadeFilhos { get; set;}
        


        [Required(ErrorMessage ="Campo obrigatorio! Informe seu salario.")]
        [Range(1200.0,13000.0,ErrorMessage ="Salario não pode ser inferior a 1.200 nem superior a 13.000. ")]
        public decimal Salario { get; set;}



        public string Status { get; set; }

    }

}
