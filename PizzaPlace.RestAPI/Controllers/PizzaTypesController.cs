using Microsoft.AspNetCore.Mvc;
using PizzaPlace.RestAPI.Model;
using PizzaPlace.RestAPI.Repository;

namespace PizzaPlace.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaTypesController : ControllerBase
    {
        // GET: api/<PizzaTypesController>
        [HttpGet]
        public List<PizzaTypes> Get()
        {
            PizzaPlaceRepository repo = new PizzaPlaceRepository();
            return repo.GetPizzaTypesList();
        }

        // GET api/<PizzaTypesController>/5
        [HttpGet("{category}")]
        public List<PizzaTypes> Get(string category)
        {
            PizzaPlaceRepository repo = new PizzaPlaceRepository();
            return repo.GetPizzaTypesByCategory(category);
        }
    }
}
