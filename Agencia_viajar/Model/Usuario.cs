using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agencia_viajar.Model
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "Informe o id do usuario")]
        [StringLength(50)]

        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o nome do usuario")]


        public string Email { get; set; }
        [Required(ErrorMessage = "Informe um email para usuario")]


        public string Senha { get; set; }
        [Required(ErrorMessage = "Informe uma senha para usuario")]

        public string Endereco { get; set; }
       
    }
}
