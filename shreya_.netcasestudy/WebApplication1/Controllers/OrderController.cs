using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace YourAppName.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        // Action method to display the order form
        public IActionResult PlaceOrder(int productId)
        {
            // Retrieve the product from the database
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                return NotFound(); // Product not found
            }

            // Initialize a new order
            var order = new Order
            {
                ProductId = productId,
                UserId = 1, // Assuming there's a logged-in user, replace with actual user ID
                OrderDate = DateTime.Now,
                Status = "Pending" // Set initial order status
            };

            return View(order);
        }

        // Action method to process the order form submission
        [HttpPost]
        public IActionResult PlaceOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return View(order); // If validation fails, return the order form with validation errors
            }

            // Save the order to the database
            _context.Orders.Add(order);
            _context.SaveChanges();

            // Redirect to a confirmation page
            return RedirectToAction("OrderConfirmation");
        }

        // Action method to display a confirmation page after placing an order
        public IActionResult OrderConfirmation()
        {
            return View();
        }
    }
}
