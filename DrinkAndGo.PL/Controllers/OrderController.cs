using DrinkAndGo.BLL.Interfaces;
using DrinkAndGo.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrinkAndGo.PL.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        //[Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        //[Authorize]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some drinks first");
            }
            else 
            {
                // Populate OrderLines from the shopping cart items
                order.OrderLines = new List<OrderDetail>();
                foreach (var item in items)
                {
                    order.OrderLines.Add(new OrderDetail
                    {
                        DrinkId = item.Drink.DrinkId,
                        Amount = item.Amount,
                        Price = item.Drink.Price
                    });
                }
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                    Console.WriteLine(error.Exception);
                }
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order! :) ";
            return View();
        }
    }
}
