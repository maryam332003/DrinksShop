using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrinkAndGo.PL.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
