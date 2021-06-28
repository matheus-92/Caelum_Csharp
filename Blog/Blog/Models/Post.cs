using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Post
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Campo obrigatório")]
        [StringLength(50, ErrorMessage = "Tamanho máximo de 50 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Resumo { get; set; }
        
        
        public string Categoria { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public bool Publicacao { get; set; }
    }
}
