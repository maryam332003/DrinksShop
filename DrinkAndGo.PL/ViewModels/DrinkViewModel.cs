using DrinkAndGo.DAL.Models;

namespace DrinkAndGo.PL.ViewModels
{
    public class DrinkViewModel
    {
        public IEnumerable<Drink> Drinks { get; set; }
        public string CurrentCategory { get; set; }
    }
}
