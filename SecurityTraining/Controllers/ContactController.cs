using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SecurityTraining.Models;

namespace SecurityTraining.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult AddContactToCustomer()
        {
            return View();
        }

        [Authorize(Roles = "Sales")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddContactToCustomer(AddOrderForContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationDbContext context = new ApplicationDbContext();

            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = context.Users.FirstOrDefault(x => x.Id == currentUserId);

            context.Customers.Add(new Customer {Name = model.Name, SalesPerson = currentUser});

            await context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

    }
}