using Microsoft.AspNetCore.Mvc;
using PizzaPlace.RestAPI.Model;
using PizzaPlace.RestAPI.Repository;

namespace PizzaPlace.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET: api/<OrdersController>
        [HttpGet]
        public List<Orders> Get()
        {
            PizzaPlaceRepository repo = new PizzaPlaceRepository();
            return repo.GetOrdersList();
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public List<Orders> Get(int id)
        {
            PizzaPlaceRepository repo = new PizzaPlaceRepository();
            return repo.GetSpecificOrders(id);
        }
    }
}
