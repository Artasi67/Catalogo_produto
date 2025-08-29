using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace catalogo_produto.Models
{
    public class Produto
    {
        [Key]
        public int Id_produto { get; set; }
        public string Nome_produto { get; set; }
        public string Descricao_produto { get; set; }
        public DateTime Data_registro_produto { get; set; }
        public int Id_usuario { get; set; }
        [ForeignKey("Id_usuario")]
        public Usuario usuario { get; set; }

        public int Id_categoria { get; set; }
        [ForeignKey("Id_categoria")]
        public Categoria categoria { get; set; }
    }
}
