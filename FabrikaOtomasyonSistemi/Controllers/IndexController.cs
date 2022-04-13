using Microsoft.AspNetCore.Mvc;

namespace FabrikaOtomasyonSistemi.Controllers
{
    public class IndexController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
