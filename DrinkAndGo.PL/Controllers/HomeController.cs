using DrinkAndGo.BLL.Interfaces;
using DrinkAndGo.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DrinkAndGo.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDrinkRepository _drinkRepository;

        public HomeController(ILogger<HomeController> logger, IDrinkRepository drinkRepository)
        {
            _logger = logger;
            _drinkRepository = drinkRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PreferredDrinks = _drinkRepository.PreferredDrinks
            };
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}