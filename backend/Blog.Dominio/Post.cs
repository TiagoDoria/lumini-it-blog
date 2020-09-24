using System;

namespace Blog.Dominio
{
    public class Post
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        
    }
}