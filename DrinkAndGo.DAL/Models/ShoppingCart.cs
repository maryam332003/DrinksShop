using DrinkAndGo.DAL.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DrinkAndGo.DAL.Models
{
    public class ShoppingCart
    { 
        private AppDbContext? _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShoppingCart(AppDbContext? context, IHttpContextAccessor? httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;

        }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }


        public static ShoppingCart GetCart(AppDbContext? context, IHttpContextAccessor httpContextAccessor)
        {
            var httpContext = httpContextAccessor.HttpContext;

            // Try to get the cart ID from cookies
            string cartId = httpContext.Request.Cookies["CartId"];

            if (string.IsNullOrEmpty(cartId))
            {
                // Generate a new cart ID
                cartId = Guid.NewGuid().ToString();

                // Store the cart ID in a cookie
                httpContext.Response.Cookies.Append("CartId", cartId, new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(30) // Set cookie to expire in 30 days
                });
            }

            // Return a new instance of ShoppingCart
            return new ShoppingCart(context, httpContextAccessor) { ShoppingCartId = cartId };
        }



        public void AddToCart(Drink drink, int amount)
        {
            var shoppingCartItem = _context
                    .shoppingCartItems.SingleOrDefault(
                        s => s.Drink.DrinkId == drink.DrinkId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Drink = drink,
                    Amount = 1
                };

                _context.shoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public int RemoveFromCart(Drink drink)
        {
            var shoppingCartItem =
                    _context.shoppingCartItems.SingleOrDefault(
                        s => s.Drink.DrinkId == drink.DrinkId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _context.shoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _context.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _context.shoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Drink)
                           .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _context
                .shoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _context.shoppingCartItems.RemoveRange(cartItems);

            _context.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _context.shoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Drink.Price * c.Amount).Sum();
            return total;
        }
    }
}