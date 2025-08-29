using catalogo_produto.Config;
using catalogo_produto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace catalogo_produto.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly DbConfig _dbConfig;
        public ProdutoController(DbConfig dbConfig) 
        {
            _dbConfig = dbConfig;
        }

        public ActionResult Index () 
        {
            return View();
        }

        public async Task<ActionResult> Listar()
        {
            var produtos = await _dbConfig.produtos.FindAsync();
            return View(produtos);
        }

        [Authorize]
        public async Task<ActionResult> Cadastrar() 
        {
            var categorias = await _dbConfig.categorias.ToListAsync();
            return View(categorias);
        }

        [Authorize]
        public async Task<ActionResult> Salvar(Produto produto)
        {
            var usuario_id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(usuario_id != null) 
            {
                produto.Id_usuario = int.Parse(usuario_id);
            }
        }

    }
}
