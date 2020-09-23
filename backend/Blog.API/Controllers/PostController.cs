using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blog.Repositorio;
using Blog.Dominio;
using System.Threading.Tasks;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IBlogRepositorio _repo;

        public PostController(IBlogRepositorio repo) 
        {
            _repo = repo;
        }

        [HttpGet("{PostId}")]
        public async Task<IActionResult> Get(int PostId)
        {
            try
            {
                var results = await _repo.GetPostById(PostId);
                return Ok(results); // retorna resultado da bunca com status code 200
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Post model)
        {
            try
            {
                _repo.Add(model);

               if(await _repo.SaveChangesAsync()) 
                {
                    return Created($"/api/post/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }

            return BadRequest();
        }

        [HttpPut("{PostId}")]
        public async Task<IActionResult> Put(int PostId, Usuario model)
        {
            try
            {
                var post = await _repo.GetPostById(PostId);

                if(post == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync()) 
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }

            return BadRequest();
        }

        [HttpDelete("{PostId}")]
        public async Task<IActionResult> Delete(int PostId)
        {
            try
            {
                var post = await _repo.GetPostById(PostId);

                if(post == null) return NotFound();

                _repo.Delete(post);

                if(await _repo.SaveChangesAsync()) 
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }

            return BadRequest();
        }
        
    }
}