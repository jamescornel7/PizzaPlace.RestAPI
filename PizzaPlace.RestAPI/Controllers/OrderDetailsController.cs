using Microsoft.AspNetCore.Mvc;
using PizzaPlace.RestAPI.Model;
using PizzaPlace.RestAPI.Repository;

namespace PizzaPlace.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        // GET: api/<OrderDetailsController>
        [HttpGet]
        public List<OrderDetails> Get()
        {
            PizzaPlaceRepository repo = new PizzaPlaceRepository();
            return repo.GetOrderDetailsList();
        }

        // GET api/<OrderDetailsController>/5
        [HttpGet("{id}")]
        public List<OrderDetails> Get(int id)
        {
            PizzaPlaceRepository repo = new PizzaPlaceRepository();
            return repo.GetSpecificOrderDetails(id);
        }
    }
}
