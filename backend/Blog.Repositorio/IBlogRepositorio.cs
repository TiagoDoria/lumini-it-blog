using System.Threading.Tasks;
using Blog.Dominio;

namespace Blog.Repositorio
{
    public interface IBlogRepositorio
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Usuario
        Task<Usuario> GetUsuarioById(int UsuarioId);

        //Post
        Task<Post> GetPostById(int UsuarioId);
        Task<Post[]> GetAllPostsAsync();
    }
}