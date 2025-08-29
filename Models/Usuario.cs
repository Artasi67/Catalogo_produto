using System.ComponentModel.DataAnnotations;

namespace catalogo_produto.Models
{
    public class Usuario
    {
        [Key]
        public int Id_usuario { get; set; }
        public string Nome_usuario { get; set; }
        public string Email_usuario { get; set; }
        public string Senha_usuario { get; set; }

    }
}
