
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
    [Route("api/[controler]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly IProAgilRepository _repo;

        public EventosController(IProAgilRepository repo)
        {
            _repo = repo;
        }
         [HttpGet]
        public async Task <IActionResult> Get()
        {
            try
            {
                var results =  await _repo.GetAllEventoAsync(true);
                 return Ok(results);
            }
            catch (System.Exception)
            {
              return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de dados falhou");  
            }
            
        }

          [HttpGet("{EventoId}")]
        public async Task <IActionResult> Get(int EventoId)
        {
            try
            {
                var results = await _repo.GetEventoAsyncById(EventoId, true);

                 return Ok(results);
            }
            catch (System.Exception)
            {
              return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de dados falhou");  
            }
            
        }
    }
}