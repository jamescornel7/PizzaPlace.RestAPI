using Microsoft.AspNetCore.Mvc;
using PizzaPlace.RestAPI.Model;
using PizzaPlace.RestAPI.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaPlace.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesDataController : ControllerBase
    {
        // GET: api/<SalesDataController>
        [HttpGet]
        public List<MonthlySalesData> Get()
        {
            PizzaPlaceRepository repo = new PizzaPlaceRepository();
            return repo.GetMonthlySalesData();
        }
    }
}
