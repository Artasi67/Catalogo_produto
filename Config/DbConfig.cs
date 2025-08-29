using catalogo_produto.Models;
using Microsoft.EntityFrameworkCore;

namespace catalogo_produto.Config
{
    public class DbConfig : DbContext
    {
        public DbConfig(DbContextOptions<DbConfig>options) : base(options) { }

        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Produto> produtos { get; set; }
        public DbSet<Comentario> comentarios { get; set; }
        public DbSet<Categoria> categorias { get; set; }
     }
}
