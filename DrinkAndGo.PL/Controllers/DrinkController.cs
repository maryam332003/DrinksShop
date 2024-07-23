using DrinkAndGo.BLL.Interfaces;
using DrinkAndGo.DAL.Models;
using DrinkAndGo.PL.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrinkAndGo.PL.Controllers
{
    public class DrinkController : Controller
    {
        private readonly IDrinkRepository _drinkRepository;
        private readonly ICategoryRepository _categoryRepository;

        public DrinkController(IDrinkRepository drinkRepository, ICategoryRepository categoryRepository)
        {
            _drinkRepository = drinkRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Drink> drinks;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                drinks = _drinkRepository.Drinks.OrderBy(p => p.DrinkId);
                currentCategory = "All drinks";
            }
            else
            {
                if (string.Equals("Cold-Drinks", _category, StringComparison.OrdinalIgnoreCase))
                    drinks = _drinkRepository.Drinks.Where(p => p.Category.CategoryName.Equals("Cold-Drinks")).OrderBy(p => p.Name);
                else
                    drinks = _drinkRepository.Drinks.Where(p => p.Category.CategoryName.Equals("Hot-Drinks")).OrderBy(p => p.Name);

                currentCategory = _category;
            }

            return View(new DrinkViewModel
            {
                Drinks = drinks,
                CurrentCategory = currentCategory
            });
        }


        //public ViewResult Search(string SearchInput)
        //{
        //    //string _searchString = searchString;
        //    //IEnumerable<Drink> drinks;
        //    var drinks = Enumerable.Empty<Drink>();
        //    string currentCategory = string.Empty;

        //    if (string.IsNullOrEmpty(SearchInput))
        //    {
        //        drinks = _drinkRepository.Drinks;
        //    }
        //    else
        //    {
        //        drinks = _drinkRepository.GetByName(SearchInput);
        //    }

        //    return View("~/Views/Drink/List.cshtml", new DrinksListViewModel { Drinks = drinks, CurrentCategory = "All drinks" });
        //}


        public IActionResult Search(string searchString)
        {
            IEnumerable<Drink> drinks;
            if (string.IsNullOrEmpty(searchString))
            {
                drinks = _drinkRepository.Drinks;
            }
            else
            {
                drinks = _drinkRepository.GetByName(searchString);
            }
            ViewData["SearchInput"] = searchString;
            return View("~/Views/Drink/List.cshtml", new DrinkViewModel { Drinks = drinks, CurrentCategory = "All drinks" });
        }


        public ViewResult Details(int drinkId)
        {
            var drink = _drinkRepository.Drinks.FirstOrDefault(d => d.DrinkId == drinkId);
            if (drink == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(drink);
        }
    }
}