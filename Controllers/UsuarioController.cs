using catalogo_produto.Config;
using catalogo_produto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace catalogo_produto.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly DbConfig _dbconfig;

        public UsuarioController(DbConfig dbconfig)
        { 
            _dbconfig = dbconfig;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Editar(int id)
        {
            var usuario = await _dbconfig.usuarios.FindAsync(id);
            return View(usuario);
        }

        public async Task<ActionResult> Listar()
        {
            var usuarios = await _dbconfig.usuarios.ToListAsync();
            return View(usuarios);
        }

        [HttpPost]
        public ActionResult Cadastro()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Salvar(Usuario usuario)
        {
            await _dbconfig.usuarios.AddRangeAsync(usuario);
            return RedirectToRoute("Cadastro", "Usuario"); //return View("Cadastro");
        }

        [HttpPost]
        public async Task<ActionResult> Atualizar(Usuario usuario)
        {
            _dbconfig.usuarios.Update(usuario);
            await _dbconfig.SaveChangesAsync();
            return RedirectToRoute("Cadastro");
        }

        [HttpDelete]
        public async Task<ActionResult> Deletar(int id)
        {
            var usuario = _dbconfig.usuarios.Find(id);
            _dbconfig.usuarios.Remove(usuario);
            await _dbconfig.SaveChangesAsync();
            return RedirectToRoute("Index");
        }
    }
}