using Microsoft.EntityFrameworkCore;
using Blog.Dominio;

namespace Blog.Repositorio
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base (options) {}

        public DbSet<Post> Posts { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}