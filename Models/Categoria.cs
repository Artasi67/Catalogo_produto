using System.ComponentModel.DataAnnotations;

namespace catalogo_produto.Models
{
    public class Categoria
    {
        [Key]
        public int Id_categoria { get; set; }
        public string Nome_categoria { get; set; }
    }
}
