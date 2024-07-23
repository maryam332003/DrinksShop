using DrinkAndGo.BLL.Interfaces;
using DrinkAndGo.DAL.Data;
using DrinkAndGo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkAndGo.BLL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Categories()
        {
            var Categories=_context.Categories.ToList();
            return Categories;
        }
    }
}
