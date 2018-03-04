using Microsoft.AspNetCore.Mvc;

namespace BuilderForm.Web.Controllers
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