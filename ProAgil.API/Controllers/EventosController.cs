
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
    }
}