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
    }
}
