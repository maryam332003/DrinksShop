using Microsoft.AspNetCore.Mvc;

namespace DrinkAndGo.PL.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
