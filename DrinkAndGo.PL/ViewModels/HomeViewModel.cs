using DrinkAndGo.DAL.Models;

namespace DrinkAndGo.PL.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Drink> PreferredDrinks { get; set; }

    }
}
