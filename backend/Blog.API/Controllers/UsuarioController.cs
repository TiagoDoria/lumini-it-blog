using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blog.Repositorio;
using Blog.Dominio;
using System.Threading.Tasks;


namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IBlogRepositorio _repo;

        public UsuarioController(IBlogRepositorio repo) 
        {
            _repo = repo;
        }
        
        [HttpGet("{UsuarioId}")]
        public async Task<IActionResult> Get(int UsuarioId)
        {
            try
            {
                var results = await _repo.GetUsuarioById(UsuarioId);
                return Ok(results); // retorna resultado da bunca com status code 200
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario model)
        {
            try
            {
                _repo.Add(model);

               if(await _repo.SaveChangesAsync()) 
                {
                    return Created($"/api/usuario/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }

            return BadRequest();
        }

        [HttpPut("{UsuarioId}")]
        public async Task<IActionResult> Put(int UsuarioId, Usuario model)
        {
            try
            {
                var usuario = await _repo.GetUsuarioById(UsuarioId);

                if(usuario == null) return NotFound();

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

    }
}