using Blog.Infra;
using Blog.Models;
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
            using (SqlConnection conexao = ConnectionFactory.CriarConexaoAberta())
            {
                // não precisa mais abrir a conexão

                // Criar um comando para o BD
                SqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "select * from Posts";

                // Executar o comando
                SqlDataReader leitor = comando.ExecuteReader();

                // Ler linha a linhao resultado - para cada registro/linha a gente gera um Post
                while (leitor.Read())
                {
                    Post post = new Post()
                    {
                        // precisa converter - o valor do dicionário não é o esperado
                        Id = Convert.ToInt32(leitor["id"]),
                        Titulo = Convert.ToString(leitor["titulo"]),
                        Resumo = Convert.ToString(leitor["resumo"]),
                        Categoria = Convert.ToString(leitor["categoria"]),
                    };

                    listaDePost.Add(post);
                }

                return listaDePost;
            }
        }

        public void Adicionar(Post post)
        {
            using (SqlConnection conexao = ConnectionFactory.CriarConexaoAberta())
            {
                // criar comando para o banco de dados
                SqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into Posts (Titulo, Resumo, Categoria) " +
                    "values ('" + post.Titulo + "', '" + post.Resumo + "', '" + post.Categoria + "')";

                // executar o comando
                comando.ExecuteNonQuery();
            }
        }
    }
}
