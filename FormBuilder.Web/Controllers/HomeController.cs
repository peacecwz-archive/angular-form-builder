using Microsoft.AspNetCore.Mvc;

namespace FormBuilder.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}