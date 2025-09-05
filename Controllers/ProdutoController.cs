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

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Listar()
        {
            var produtos = await _dbConfig.produtos
                .Include(p => p.categoria)
                .Include(p => p.usuario)
                .ToListAsync();
            return View(produtos);
        }

        [Authorize]
        public async Task<ActionResult> ListarPorUsuarioId()
        {
            var usuario_id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var produtos = await _dbConfig.produtos
                .Where(p => p.Id_produto == int.Parse(usuario_id))
                .ToListAsync();

            return View(produtos);
        }

        [Authorize]
        public async Task<ActionResult> Cadastrar()
        {
            ViewBag.categorias = await _dbConfig.categorias.ToListAsync();
            return View();
        }

        [Authorize]
        public async Task<ActionResult> Salvar(Produto produto)
        {
            var usuario_id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (usuario_id != null)
            {
                produto.Id_usuario = int.Parse(usuario_id);
            }
            produto.Data_registro_produto = new DateTime();

            _dbConfig.produtos.Add(produto);
            await _dbConfig.SaveChangesAsync();
            return RedirectToAction("Listar");
        }

        [Authorize]
        public async Task<ActionResult> Editar(int id)
        {
            var produto = await _dbConfig.produtos
                .Include(p => p.usuario)
                .Include(p => p.categoria)
                .FirstOrDefaultAsync(
                    p => p.Id_produto == id
                );
            return View(produto);
        }

        [Authorize]
        public async Task<ActionResult> Atualizar(Produto produto)
        {
            _dbConfig.produtos.Update(produto);
            await _dbConfig.SaveChangesAsync();

            return RedirectToAction("Listar");
        }

        [Authorize]
        public async Task<ActionResult> Deletar(int id)
        {
            var produto = await _dbConfig.produtos.FindAsync(id);
            _dbConfig.produtos.Remove(produto);
            await _dbConfig.SaveChangesAsync();

            return RedirectToAction("Listar");
        }
    }
}