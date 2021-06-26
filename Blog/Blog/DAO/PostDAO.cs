using Blog.Infra;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.DAO
{
    public class PostDAO
    {
        // método paraq listar todos os posts...
        public IList<Post> Listar()
        {
            IList<Post> listaDePost = new List<Post>();

            //Criar um objeto de SqlConnection
            using (BlogContext contexto = new BlogContext())
            {
                var lista = contexto.Posts.ToList();
                return lista;
            }
        }

        public void Adicionar(Post post)
        {
            using (BlogContext contexto = new BlogContext())
            {
                contexto.Posts.Add(post);
                contexto.SaveChanges();
            }
        }

        public IList<Post> FiltrarPorCategoria(string categoria)
        {
            using (BlogContext contexto = new BlogContext())
            {
                var lista = contexto.Posts.Where(p => p.Categoria.Contains(categoria)).ToList();
                
                return lista;
            }
        }

        public void Remove(int id)
        {
            using(BlogContext contexto = new BlogContext())
            {
                Post post = contexto.Posts.Find(id);
             
                contexto.Posts.Remove(post);
             
                contexto.SaveChanges();

            }
        }

        public Post BuscarPorId(int id)
        {
            using (BlogContext contexto = new BlogContext())
            {
                Post post = contexto.Posts.Find(id);

                return post;

            }
        }

        public void Atualiza(Post post)
        {
            using (BlogContext contexto = new BlogContext())
            {
                contexto.Entry(post).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        internal void Publica(int id)
        {
            using(BlogContext contexto = new BlogContext())
            {
                Post post = contexto.Posts.Find(id);
                post.Publicacao = true;
                post.DataPublicacao = DateTime.Now;
                contexto.SaveChanges();
            }
        }
    }
}
