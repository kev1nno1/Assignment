using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        [HttpGet]
        public string GetOrder()
        {
            return "Fuck you Alikhan";
        }
    }
}
