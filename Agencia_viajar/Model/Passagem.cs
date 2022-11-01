using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agencia_viajar.Model
{
    [Table("Passagem")]
    public class Passagem
    {
        [Key]
        public int PassagemId { get; set; }
        [Required(ErrorMessage = "Informe a descrição da Passagem")]
        [StringLength(50)]

        public string Empresa { get; set; }
        [Required(ErrorMessage = "Informe o nome da empresa")]

        public string Embarque { get; set; }
        [Required(ErrorMessage = "Informe o local de embarque")]

        public string Desembarque { get; set; }
        [Required(ErrorMessage = "Informe o local de desembarque")]

        public DateTime Data_passagem { get; set; }

        public double Valor_passagem { get; set; }

    }
}
