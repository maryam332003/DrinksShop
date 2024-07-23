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
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;


        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }


        public void CreateOrder(Order order)
        {
            // Set the order placed time
            order.OrderPlaced = DateTime.Now;

            // Add the order to the context and save it to generate OrderId
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();

            // Get the shopping cart items
            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            // Create OrderDetail for each shopping cart item using the saved OrderId
            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    DrinkId = shoppingCartItem.Drink.DrinkId,
                    OrderId = order.OrderId, // Use the generated OrderId
                    Price = shoppingCartItem.Drink.Price
                };

                // Add the order detail to the context
                _appDbContext.OrderDetails.Add(orderDetail);
            }

            // Save changes to the context
            _appDbContext.SaveChanges();
        }

    }
}