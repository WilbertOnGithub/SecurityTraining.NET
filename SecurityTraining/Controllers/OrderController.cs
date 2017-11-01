using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SecurityTraining.Models;

namespace SecurityTraining.Controllers
{
    public class OrderController : Controller
    {
        [Authorize(Roles = "Sales,Contact")]
        public ActionResult AddOrder()
        {
            return View();
        }

        [Authorize(Roles = "Sales,Contact")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddOrder(AddOrderViewModel model)
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