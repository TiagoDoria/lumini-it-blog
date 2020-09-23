using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repositorio
{
    public class BlogRepositorio : IBlogRepositorio
    {
        private readonly BlogContext _context;
        public BlogRepositorio(BlogContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Usuario> GetUsuarioById(int UsuarioId)
        {
            IQueryable<Usuario> query = _context.Usuarios
                .Where(user => user.Id == UsuarioId);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Post> GetPostById(int PostId)
        {
            IQueryable<Post> query = _context.Posts
                .Where(post => post.Id == PostId);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Post[]> GetAllPostsAsync()
        {
            IQueryable<Post> query = _context.Posts;
               
            return await query.ToArrayAsync();
        }
        
    }
}