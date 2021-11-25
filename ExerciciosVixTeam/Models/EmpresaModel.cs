using System.ComponentModel.DataAnnotations;

namespace ExerciciosVixTeam.Models
{
    public class EmpresaModel
    {
        [Key]

        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
    }
}
