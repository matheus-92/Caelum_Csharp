using Blog.DAO;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        //dominio/Post/Index
        [HttpGet]
        public IActionResult Index()
        {
            PostDAO dao = new PostDAO();
            var listaDePost = dao.Listar();
            return View(listaDePost); // view tipada
        }

        //dominio/Post/Novo
        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(Post post)
        {
            PostDAO dao = new PostDAO();
            dao.Adicionar(post);
            return RedirectToAction("Index");
        }

        public IActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            PostDAO dao = new PostDAO();

            IList<Post> lista = dao.FiltrarPorCategoria(categoria);

            return View("Index", lista);
        }

        public IActionResult RemovePost(int id)
        {
            PostDAO dao = new PostDAO();
            dao.Remove(id);

            return RedirectToAction("Index");

        }

        public IActionResult Visualiza(int id)
        {
            PostDAO dao = new PostDAO();

            Post post = dao.BuscarPorId(id);
            
            return View(post);
        }

        public IActionResult EditaPost(Post post)
        {
            PostDAO dao = new PostDAO();
            dao.Atualiza(post);

            return RedirectToAction("Index");
        }

        public IActionResult PublicaPost(int id)
        {
            PostDAO dao = new PostDAO();
            dao.Publica(id);
            return RedirectToAction("Index");
        }
    }
}
