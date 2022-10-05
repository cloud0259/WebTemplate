using Microsoft.AspNetCore.Mvc;
using Serilog;
namespace WebTemplate.API.Controllers
{
    /// <summary>
    /// This is a simple controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            //Using Log information with Serilog
            Log.Information(name);
            return NoContent();
        }


    }
}
