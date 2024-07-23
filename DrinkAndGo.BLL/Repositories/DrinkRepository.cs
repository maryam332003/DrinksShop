using DrinkAndGo.BLL.Interfaces;
using DrinkAndGo.DAL.Data;
using DrinkAndGo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DrinkAndGo.BLL.Repositories
{
    public class DrinkRepository : IDrinkRepository
    {

        private readonly AppDbContext _appDbContext;
        public DrinkRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Drink> Drinks => _appDbContext.Drinks.Include(c => c.Category);

        public IEnumerable<Drink> PreferredDrinks => _appDbContext.Drinks.Where(p => p.IsPreferredDrink).Include(c => c.Category);

        public Drink GetDrinkById(int drinkId) => _appDbContext.Drinks.FirstOrDefault(p => p.DrinkId == drinkId);

        public IEnumerable<Drink> GetByName(string Name)
        {
            return _appDbContext.Drinks.Where(E => E.Name.ToLower().Contains(Name.ToLower())).ToList();
            //return _context.Employees.Where(E => E.Name.ToLower().Contains(Name.ToLower())).Include(E => E.Department).ToList();

        }

    }
}
