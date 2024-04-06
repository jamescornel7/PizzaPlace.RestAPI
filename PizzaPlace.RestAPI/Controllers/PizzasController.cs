using Microsoft.AspNetCore.Mvc;
using PizzaPlace.RestAPI.Model;
using PizzaPlace.RestAPI.Repository;

namespace PizzaPlace.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        // GET: api/<PizzasController>
        [HttpGet]
        public List<Pizzas> Get()
        {
            PizzaPlaceRepository repo = new PizzaPlaceRepository();
            return repo.GetPizzasList();
        }

        // GET api/<PizzasController>/5
        [HttpGet("{id}")]
        public List<Pizzas> Get(string id)
        {
            PizzaPlaceRepository repo = new PizzaPlaceRepository();
            return repo.GetSpecificPizzas(id);
        }
    }
}
