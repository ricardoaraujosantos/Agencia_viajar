using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agencia_viajar.Model
{
    [Table("Hospedagem")]
    public class Hospedagem
    {
        [Key]
        public int HospedagemId { get; set; }
        [Required(ErrorMessage = "Informe o id da hospedagem")]
        [StringLength(50)]

        public string Empresa { get; set; }
        [Required(ErrorMessage = "Informe o nome da empresa")]

        public string Endereco { get; set; }
        [Required(ErrorMessage = "Informe o endereço da hospedagem")]

        public DateTime Data_hospedagem { get; set; }

        public double Valor_diaria { get; set; }
    }
}
