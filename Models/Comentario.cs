using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace catalogo_produto.Models
{
    public class Comentario
    {
        [Key]
        public int id_comentario {  get; set; }
        public string Texto_comentario { get; set; }
        public DateTime Data_comentario { get; set; }
        public int Id_usuario { get; set; }
        [ForeignKey("Id_usario")]
        public Usuario Usuario { get; set; }

        public int Id_produto { get; set; }
        [ForeignKey("Id_produto")]
        public Produto Produto { get; set; }
    }
}
