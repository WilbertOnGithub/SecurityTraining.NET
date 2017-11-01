using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SecurityTraining.Models;

namespace SecurityTraining.Controllers
{
    public class OrderController : Controller
    {
        [Authorize(Roles = "Contact")]
        public ActionResult AddOrderForContact()
        {
            return View();
        }

        [Authorize(Roles = "Sales")]
        public ActionResult AddOrderForSales()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            string currentUserId = User.Identity.GetUserId();

            IList<Customer> customers = context.Customers.Where(x => x.SalesPerson.Id == currentUserId).ToList();
            AddOrderForSalesViewModel model = new AddOrderForSalesViewModel{ Customers = customers };

            return View(model);
        }

        [Authorize(Roles = "Contact")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddOrderForContact(AddOrderForContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationDbContext context = new ApplicationDbContext();

            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = context.Users.FirstOrDefault(x => x.Id == currentUserId);

            context.Orders.Add(new Order {Customer = currentUser.Customer, Name = model.Name});

            await context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Sales")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddOrderForSales(AddOrderForSalesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationDbContext context = new ApplicationDbContext();

            context.Orders.Add(new Order {Customer = model.Customer, Name = model.Name});

            await context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }

}